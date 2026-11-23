// The Unity port's game saves (Backend/GameSaves.cs, Games/*/…Save.cs, Games/Shared/AccountSaves.cs) against the
// Firebase Local Emulator Suite (auth 9099, firestore 8080, functions 5001, project demo-squish), compared with what
// the app writes for the same play.
//
//   WORK=<scratch> tools/unity/backend/start-emulators.sh      (leave it running: auth 9099, firestore 8080, functions 5001)
//   cd tools/unity/saves-test && dotnet run                  (Node 22 and the repo's node_modules for app.mjs; exit 1 on a failure)
//
// For each starting profile (a current one, and one from before player XP: no `pxp`), two fresh accounts get the
// same document: one plays a session of all four games through the Unity code, the other through the app's own
// JS (app.mjs: the games' levels.js and src/firebase/firestore.js saveX). The Unity side does what each game does at
// the point it finishes: the outcome from Levels.AfterLevel / AfterBlitz on the game's copy of the profile (seeded as
// MenuScreen.SeedGameProfiles does, from the profile feed), the game's save hook, then its Apply. Then:
//   - each step's outcome (the update, coins, XP, levels reached), Unity vs app
//   - the two documents afterwards, field by field (value and Firestore type), but for `email`
//   - the game's copy vs its account's document (what the screens show = what was saved)
//
// Every request goes through LocalOnlyHttp, which refuses anything that isn't 127.0.0.1 / localhost; app.mjs's fetch
// does the same.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Backend;
using SquishSquad.Games.Shared;
using St = SquishSquad.Games.Stack;
using So = SquishSquad.Games.Sort;
using Ho = SquishSquad.Games.Hop;
using Sd = SquishSquad.Games.Squishdoku;

static class Program
{
    sealed class LocalOnlyHttp : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(30));

        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http")
                throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            return inner.Send(r, cancel);
        }
    }

    const string Project = "demo-squish";
    const string Host = "127.0.0.1";
    static readonly HttpClient Raw = new HttpClient(new HttpClientHandler { UseProxy = false }) { Timeout = TimeSpan.FromSeconds(30) };
    static readonly List<(string name, bool ok, string note)> Results = new List<(string, bool, string)>();

    // --- the plan: one session of all four games ---------------------------------------------------------------------
    static Dictionary<string, object> S(string what, params (string k, object v)[] args)
    {
        var d = new Dictionary<string, object> { ["do"] = what };
        foreach (var (k, v) in args) d[k] = v;
        return d;
    }

    static readonly List<Dictionary<string, object>> Steps = new List<Dictionary<string, object>>
    {
        S("stack.seen"),
        S("stack.win", ("lv", 3.0), ("par", 6.0), ("moves", 6.0), ("hinted", false)),
        S("stack.lose", ("lv", 4.0), ("par", 8.0)),
        S("stack.win", ("lv", 2.0), ("par", 5.0), ("moves", 7.0), ("hinted", true)),
        S("stack.blitzLose", ("reached", 4.0)),
        S("stack.blitzWin", ("ms", 123456.0)),
        S("stack.blitzWin", ("ms", 150000.5)),
        S("sort.seen"),
        S("sort.win", ("theme", "fridge"), ("lv", 2.0), ("mistakes", 0.0), ("ms", 30000.0)),
        S("sort.lose", ("theme", "cupboard"), ("lv", 1.0), ("mistakes", 3.0)),
        S("sort.win", ("theme", "cupboard"), ("lv", 1.0), ("mistakes", 1.0), ("ms", 61234.0)),
        S("sort.blitzWin", ("ms", 200000.0)),
        S("sort.blitzLose", ("reached", 7.0)),
        S("hop.seen"),
        S("hop.win", ("lv", 2.0), ("left", 0.0), ("hinted", false)),
        S("hop.stuck"),
        S("hop.win", ("lv", 1.0), ("left", 3.0), ("hinted", true)),
        S("sdk.head", ("on", true)),
        S("sdk.win", ("lv", 4.0), ("head", true), ("stars", 3.0), ("perfect", true), ("ms", 40000.0), ("mistakes", 0.0)),
        S("sdk.lose", ("lv", 5.0), ("head", true)),
        S("sdk.head", ("on", false)),
        S("sdk.win", ("lv", 1.0), ("head", false), ("stars", 2.0), ("perfect", false), ("ms", 50000.0), ("mistakes", 1.0)),
        S("sdk.gemSave", ("i", 0.0)),
        S("sdk.gemSave", ("i", 1.0)),
        S("sdk.blitz", ("cleared", 7.0)),
        S("sdk.blitz", ("cleared", 0.0)),
    };

    // --- the starting profiles -----------------------------------------------------------------------------------------
    static Dictionary<string, object> M(params (string k, object v)[] kv)
    {
        var d = new Dictionary<string, object>();
        foreach (var (k, v) in kv) d[k] = v;
        return d;
    }

    static Dictionary<string, object> Base() => M(
        ("nickname", "Saver"), ("age", 12.0), ("adsFree", false), ("generationCredits", 1.0), ("tut", "done"),
        ("ownedIds", new List<object> { "0", "1" }), ("gems", 25.0),
        ("stats", M(("presses", 0.0), ("longestHoldMs", 0.0), ("playTime", M()))));

    static readonly (string name, Func<Dictionary<string, object>> make)[] Seeds =
    {
        ("current profile (pxp 1990, LV 5: the first win levels up)", () =>
        {
            var p = Base();
            p["coins"] = 1000.0; p["totalEarned"] = 5000.0; p["pxp"] = 1990.0; p["level"] = 5.0; p["lvSeen"] = 5.0;
            p["stack"] = M(("lv", 3.0), ("best", M(("1", 3.0), ("2", 1.0))), ("skill", 0.5), ("plays", 4.0), ("wins", 3.0));
            p["sort"] = M(("fridge", M(("lv", 2.0), ("best", M(("1", 2.0))), ("skill", 0.25))), ("plays", 1.0), ("wins", 1.0));
            p["hop"] = M(("lv", 2.0), ("best", M(("1", 2.0))), ("plays", 2.0), ("wins", 1.0));
            p["sdk"] = M(("lv", 4.0), ("best", M(("1", 3.0), ("2", 3.0), ("3", 2.0))), ("perfect", M(("1", true))), ("plays", 5.0), ("solves", 3.0),
                ("head", false), ("bSkill", 0.0), ("blitz", M(("top", 3.0), ("runs", 1.0))));
            return p;
        }),
        ("profile from before player XP (no pxp: LV 3 + 40 Puzzle XP)", () =>
        {
            var p = Base();
            p["coins"] = 250.0; p["totalEarned"] = 250.0; p["level"] = 3.0;
            p["stack"] = M(("seen", true));
            p["sdk"] = M(("xp", 40.0), ("lv", 1.0));
            return p;
        }),
    };

    // --- the Unity side: each step as the game does it ------------------------------------------------------------------
    static IDictionary<string, object> DeepCopy(IDictionary<string, object> m)
    {
        var c = new Dictionary<string, object>();
        foreach (var kv in m) c[kv.Key] = CopyValue(kv.Value);
        return c;
    }

    static object CopyValue(object v)
    {
        if (v is IDictionary<string, object> d) return DeepCopy(d);
        if (v is IList<object> l) return l.Select(CopyValue).ToList();
        return v;
    }

    // every game's Apply: the update's dotted paths into nested maps
    static void Apply(IDictionary<string, object> profile, IDictionary<string, object> update)
    {
        foreach (var kv in update)
        {
            var parts = kv.Key.Split('.');
            var m = profile;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (!(m.TryGetValue(parts[i], out var next) && next is IDictionary<string, object> nm)) { nm = new Dictionary<string, object>(); m[parts[i]] = nm; }
                m = nm;
            }
            m[parts[parts.Length - 1]] = kv.Value;
        }
    }

    static IDictionary<string, object> Section(IDictionary<string, object> p, string k)
    {
        if (p.TryGetValue(k, out var v) && v is IDictionary<string, object> d) return d;
        var n = new Dictionary<string, object>();
        p[k] = n;
        return n;
    }

    static double N(Dictionary<string, object> a, string k) => Convert.ToDouble(a[k], CultureInfo.InvariantCulture);
    static bool B(Dictionary<string, object> a, string k) => (bool)a[k];

    sealed class Said
    {
        public IDictionary<string, object> Update = new Dictionary<string, object>();
        public double Coins, Xp;
        public List<double> LevelUps = new List<double>();
        public string Error;
        public double? Paid;
    }

    static Said Out(IDictionary<string, object> u, double coins = 0, double xp = 0, IEnumerable<int> ups = null) =>
        new Said { Update = new Dictionary<string, object>(u), Coins = coins, Xp = xp, LevelUps = ups?.Select(x => (double)x).ToList() ?? new List<double>() };

    // P: the game's copy of the profile (StackGame.Profile, SortGame.Profile, HopGame.Profile, SdLevel.Profile — the
    // menu gives each the same copy; one is enough here)
    static async Task<Said> Unity(Dictionary<string, object> a, IDictionary<string, object> P)
    {
        switch ((string)a["do"])
        {
            // GameScreen.Start: `if (!Def.Seen) Def.MarkSeen()` (StackDef / SortDef / HopDef)
            case "stack.seen":
                if (St.Levels.Record(P).Seen) return Out(new Dictionary<string, object>());
                Section(P, "stack")["seen"] = true;
                St.StackSave.Record(new Dictionary<string, object> { { "stack.seen", true } });
                return Out(new Dictionary<string, object> { { "stack.seen", true } });
            // StackGame: Win() / Lose()
            case "stack.win":
            {
                var spec = St.Levels.LevelSpec(N(a, "lv"), St.Levels.Record(P).Skill);
                var o = St.Levels.AfterLevel(P, spec, (int)N(a, "par"), true, N(a, "moves"), B(a, "hinted"));
                St.StackSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "stack.lose":
            {
                var spec = St.Levels.LevelSpec(N(a, "lv"), St.Levels.Record(P).Skill);
                var o = St.Levels.AfterLevel(P, spec, (int)N(a, "par"), false, 0, false);
                St.StackSave.Record(o.Update);
                Apply(P, o.Update);
                return Out(o.Update);
            }
            // StackBlitz: BlitzWon() / BlitzLost()
            case "stack.blitzWin":
            {
                var o = St.Levels.AfterBlitz(P, true, St.Levels.BLITZ_ROUNDS, N(a, "ms"));
                St.StackSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "stack.blitzLose":
            {
                var o = St.Levels.AfterBlitz(P, false, N(a, "reached"), 0);
                St.StackSave.Record(o.Update);
                Apply(P, o.Update);
                return Out(o.Update);
            }

            case "sort.seen":
                if (So.Levels.Record(P).Seen) return Out(new Dictionary<string, object>());
                Section(P, "sort")["seen"] = true;
                So.SortSave.Record(new Dictionary<string, object> { { "sort.seen", true } });
                return Out(new Dictionary<string, object> { { "sort.seen", true } });
            // SortLevel: Win() / Lose()
            case "sort.win":
            {
                string theme = (string)a["theme"];
                var spec = So.Levels.LevelSpec(N(a, "lv"), So.Levels.Record(P).Of(theme).Skill);
                var o = So.Levels.AfterLevel(P, theme, spec, true, N(a, "mistakes"), N(a, "ms"));
                So.SortSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "sort.lose":
            {
                string theme = (string)a["theme"];
                var spec = So.Levels.LevelSpec(N(a, "lv"), So.Levels.Record(P).Of(theme).Skill);
                var o = So.Levels.AfterLevel(P, theme, spec, false, N(a, "mistakes"), null);
                So.SortSave.Record(o.Update);
                Apply(P, o.Update);
                return Out(o.Update);
            }
            // SortBlitz: RunWon() / RunLost()
            case "sort.blitzWin":
            {
                var o = So.Levels.AfterBlitz(P, true, So.Levels.BLITZ_ROUNDS, N(a, "ms"));
                So.SortSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "sort.blitzLose":
            {
                var o = So.Levels.AfterBlitz(P, false, N(a, "reached"));
                So.SortSave.Record(o.Update);
                Apply(P, o.Update);
                return Out(o.Update);
            }

            case "hop.seen":
                if (Ho.Levels.Record(P).Seen) return Out(new Dictionary<string, object>());
                Section(P, "hop")["seen"] = true;
                Ho.HopSave.Record(new Dictionary<string, object> { { "hop.seen", true } });
                return Out(new Dictionary<string, object> { { "hop.seen", true } });
            // HopLevel: the win, Retry()
            case "hop.win":
            {
                var o = Ho.Levels.AfterLevel(P, Ho.Levels.LevelSpec(N(a, "lv")), new Ho.HopResult { Left = (int)N(a, "left"), Hinted = B(a, "hinted") });
                Ho.HopSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "hop.stuck":
            {
                var u = Ho.Levels.AfterStuck(P);
                Ho.HopSave.Record(u);
                Apply(P, u);
                return Out(u);
            }

            // SquishdokuScreen: OnHeadChanged
            case "sdk.head":
            {
                bool on = B(a, "on");
                Section(P, "sdk")["head"] = on;
                Sd.SdSave.Record(new Dictionary<string, object> { { "sdk.head", on } });
                return Out(new Dictionary<string, object> { { "sdk.head", on } });
            }
            // SdLevel: Solved() / TimeUp() (OutOfHearts the same)
            case "sdk.win":
            {
                var spec = Sd.Levels.SpecOf(N(a, "lv"), B(a, "head"));
                var o = Sd.Levels.AfterLevel(P, spec, true, (int)N(a, "stars"), B(a, "perfect"));
                Sd.SdSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            case "sdk.lose":
            {
                var o = Sd.Levels.AfterLevel(P, Sd.Levels.SpecOf(N(a, "lv"), B(a, "head")), false);
                Sd.SdSave.Record(o.Update);
                Apply(P, o.Update);
                return Out(o.Update);
            }
            // SdBlitz: Settle()
            case "sdk.blitz":
            {
                var o = Sd.Levels.AfterBlitz(P, (int)N(a, "cleared"));
                Sd.SdSave.Paid(o, P);
                Apply(P, o.Update);
                return Out(o.Update, o.Coins, o.Xp, o.LevelUps);
            }
            // SdBlitz: SaveByGemsOnServer()
            case "sdk.gemSave":
            {
                int i = (int)N(a, "i");
                int price = Sd.Levels.BlitzSaveGems(i);
                string err = await Sd.SdSave.BlitzSave(i);
                if (err == null)
                {
                    double have = P.TryGetValue("gems", out var g) && g is double gd ? gd : 0;
                    P["gems"] = Math.Max(0, have - price);
                    return new Said { Paid = price };
                }
                return new Said { Error = err };
            }
        }
        throw new ArgumentException("no such step: " + a["do"]);
    }

    // --- the emulator, as its owner (rules off): seeding and reading the raw documents -------------------------------
    static string DocUrl(string uid) => $"http://{Host}:8080/v1/projects/{Project}/databases/(default)/documents/users/{uid}";
    static string DbPrefix => $"projects/{Project}/databases/(default)/documents/";

    static async Task OwnerSet(string uid, IDictionary<string, object> data)
    {
        var body = Json.Write(new Dictionary<string, object> { ["fields"] = FirestoreValues.EncodeFields(data, DbPrefix) });
        var req = new HttpRequestMessage(new HttpMethod("PATCH"), DocUrl(uid)) { Content = new StringContent(body, Encoding.UTF8, "application/json") };
        req.Headers.TryAddWithoutValidation("Authorization", "Bearer owner");
        var res = await Raw.SendAsync(req);
        if (!res.IsSuccessStatusCode) throw new Exception("seed failed: " + await res.Content.ReadAsStringAsync());
    }

    // the document's fields as Firestore holds them: path → (value, type), leaves only (maps flattened with dots)
    static async Task<SortedDictionary<string, (string value, string type)>> OwnerGet(string uid)
    {
        var req = new HttpRequestMessage(HttpMethod.Get, DocUrl(uid));
        req.Headers.TryAddWithoutValidation("Authorization", "Bearer owner");
        var res = await Raw.SendAsync(req);
        var text = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw new Exception("read failed: " + text);
        var doc = (IDictionary<string, object>)Json.Parse(text);
        var flat = new SortedDictionary<string, (string, string)>(StringComparer.Ordinal);
        Flatten((IDictionary<string, object>)doc["fields"], "", flat);
        return flat;
    }

    static void Flatten(IDictionary<string, object> fields, string prefix, SortedDictionary<string, (string, string)> into)
    {
        foreach (var kv in fields)
        {
            var v = (IDictionary<string, object>)kv.Value;
            string path = prefix + kv.Key;
            if (v.TryGetValue("mapValue", out var mv))
            {
                var inner = (mv as IDictionary<string, object>)?.TryGetValue("fields", out var f) == true ? (IDictionary<string, object>)f : new Dictionary<string, object>();
                if (inner.Count == 0) into[path] = ("{}", "mapValue");
                Flatten(inner, path + ".", into);
                continue;
            }
            var (type, value) = v.First();
            into[path] = (Json.Write(value), type);
        }
    }

    // --- comparing ------------------------------------------------------------------------------------------------------
    static string Canon(object v)
    {
        switch (v)
        {
            case null: return "null";
            case bool b: return b ? "true" : "false";
            case string s: return Json.Write(s);
            case IDictionary<string, object> d: return "{" + string.Join(",", d.OrderBy(kv => kv.Key, StringComparer.Ordinal).Select(kv => Json.Write(kv.Key) + ":" + Canon(kv.Value))) + "}";
            case IEnumerable<object> l: return "[" + string.Join(",", l.Select(Canon)) + "]";
            default: return Convert.ToDouble(v, CultureInfo.InvariantCulture).ToString("R", CultureInfo.InvariantCulture);
        }
    }

    static void Check(string name, bool ok, string note = "")
    {
        Results.Add((name, ok, note));
        Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {name}{(note.Length > 0 ? "  — " + note : "")}");
    }

    static async Task<int> Main()
    {
        var cfg = FirebaseConfig.Emulator(Project, Host);
        if (!cfg.ProjectId.StartsWith("demo-")) throw new Exception("not a demo- project");
        var http = new LocalOnlyHttp();
        string run = DateTime.UtcNow.Ticks.ToString("x");
        const string pw = "squish123";
        string node = Environment.GetEnvironmentVariable("NODE") ?? "node";
        string dir = FindHere();

        int seedNo = 0;
        foreach (var (seedName, make) in Seeds)
        {
            seedNo++;
            Console.WriteLine($"\n=== {seedName}");
            string emailU = $"unity{seedNo}-{run}@example.com", emailA = $"app{seedNo}-{run}@example.com";
            using var fbU = new FirebaseClient(cfg, new MemoryAuthStore(), http);
            using var fbA = new FirebaseClient(cfg, new MemoryAuthStore(), http);
            string uidU = (await fbU.Auth.RegisterWithEmail(emailU, pw)).Uid;
            string uidA = (await fbA.Auth.RegisterWithEmail(emailA, pw)).Uid;
            var seedU = make(); seedU["email"] = emailU;
            var seedA = make(); seedA["email"] = emailA;
            await OwnerSet(uidU, seedU);
            await OwnerSet(uidA, seedA);

            // Unity: signed in, the profile feed, the game's copy, the hooks on (MenuScreen.SeedGameProfiles)
            var feed = fbU.Data.SubscribeToUserProfile(uidU, TimeSpan.FromSeconds(60));
            for (int t = 0; !feed.Loaded && t < 200; t++) await Task.Delay(50);
            var P = DeepCopy(feed.Current);
            AccountSaves.Use(uidU, fbU.Data);
            var unity = new List<Said>();
            foreach (var step in Steps)
            {
                unity.Add(await Unity(step, P));
                await GameSaves.Idle();
            }
            AccountSaves.Use(null, null);
            // the feed: refreshed after the writes (Track), so the menu has them
            await feed.Refresh();
            var feedNow = feed.Current;

            // the app
            string plan = Path.Combine(Path.GetTempPath(), $"saves-plan-{run}-{seedNo}.json"), logPath = Path.ChangeExtension(plan, ".log.json");
            File.WriteAllText(plan, Json.Write(new Dictionary<string, object> { ["email"] = emailA, ["password"] = pw, ["steps"] = Steps.Cast<object>().ToList() }));
            var psi = new ProcessStartInfo(node, $"--disable-warning=MODULE_TYPELESS_PACKAGE_JSON --import ./register.mjs app.mjs \"{plan}\" \"{logPath}\"") { WorkingDirectory = dir, RedirectStandardError = true, RedirectStandardOutput = true };
            foreach (var k in new[] { "NO_PROXY", "no_proxy", "no_grpc_proxy" }) psi.Environment[k] = "127.0.0.1,localhost";
            foreach (var k in new[] { "grpc_proxy", "GRPC_PROXY" }) psi.Environment.Remove(k);
            using (var proc = Process.Start(psi))
            {
                var so = proc.StandardOutput.ReadToEndAsync(); var se = proc.StandardError.ReadToEndAsync();
                if (!proc.WaitForExit(120000)) { proc.Kill(); throw new Exception("app.mjs timed out"); }
                if (proc.ExitCode != 0) throw new Exception("app.mjs failed: " + await so + await se);
                var warn = (await se).Trim();
                if (warn.Length > 0) Console.WriteLine("  (app.mjs stderr) " + warn.Replace("\n", "\n  "));
            }
            var app = ((IList<object>)Json.Parse(File.ReadAllText(logPath))).Cast<IDictionary<string, object>>().ToList();

            // 1. each step's outcome
            Console.WriteLine("  -- each step: Unity's outcome vs the app's");
            for (int i = 0; i < Steps.Count; i++)
            {
                var u = unity[i];
                var j = app[i];
                string name = $"{seedNo}.{i + 1:00} {Steps[i]["do"]}";
                string jUpdate = Canon(j["update"]), uUpdate = Canon(u.Update);
                double jCoins = j.TryGetValue("coins", out var jc) && jc != null ? Convert.ToDouble(jc) : 0;
                double jXp = j.TryGetValue("xp", out var jx) && jx != null ? Convert.ToDouble(jx) : 0;
                string jUps = Canon(j.TryGetValue("levelUps", out var ju) && ju != null ? ju : new List<object>());
                string uUps = Canon(u.LevelUps.Cast<object>().ToList());
                string jErr = j.TryGetValue("error", out var je) ? je as string : null;
                double? jPaid = j.TryGetValue("paid", out var jp) && jp != null ? Convert.ToDouble(jp) : (double?)null;
                var diffs = new List<string>();
                if (jUpdate != uUpdate) diffs.Add($"update {uUpdate} vs app {jUpdate}");
                if (jCoins != u.Coins) diffs.Add($"coins {u.Coins} vs {jCoins}");
                if (jXp != u.Xp) diffs.Add($"xp {u.Xp} vs {jXp}");
                if (jUps != uUps) diffs.Add($"levelUps {uUps} vs {jUps}");
                if (jErr != u.Error) diffs.Add($"error {u.Error} vs {jErr}");
                if (jPaid != u.Paid) diffs.Add($"gems paid {u.Paid} vs {jPaid}");
                string what = u.Error != null ? "error " + u.Error : u.Paid != null ? $"paid {u.Paid} gems" : $"{u.Update.Count} fields, +{u.Coins} coins, +{u.Xp} XP{(u.LevelUps.Count > 0 ? ", LV " + uUps : "")}";
                Check(name, diffs.Count == 0, diffs.Count == 0 ? what : string.Join("; ", diffs));
            }

            // 2. the documents, field by field
            var du = await OwnerGet(uidU);
            var da = await OwnerGet(uidA);
            du.Remove("email"); da.Remove("email");
            Console.WriteLine($"  -- the documents afterwards ({du.Count} / {da.Count} fields), Unity vs app");
            var seedFlat = new SortedDictionary<string, (string, string)>(StringComparer.Ordinal);
            Flatten((IDictionary<string, object>)FirestoreValues.EncodeFields(make(), DbPrefix).ToDictionary(kv => kv.Key, kv => kv.Value), "", seedFlat);
            int same = 0;
            foreach (var path in du.Keys.Union(da.Keys).OrderBy(x => x, StringComparer.Ordinal))
            {
                bool hu = du.TryGetValue(path, out var vu), ha = da.TryGetValue(path, out var va);
                bool eq = hu && ha && vu.value == va.value && vu.type == va.type;
                bool changed = !seedFlat.TryGetValue(path, out var sv) || sv.Item1 != (hu ? vu.value : null) || sv.Item2 != (hu ? vu.type : null);
                string show(bool h, (string value, string type) v) => h ? $"{v.value} ({v.type.Replace("Value", "")})" : "(missing)";
                if (eq) same++;
                if (!eq || changed) Check($"{seedNo} doc {path}", eq, eq ? show(hu, vu) + (changed ? (seedFlat.ContainsKey(path) ? $"  (was {seedFlat[path].Item1})" : "  (new)") : "") : $"Unity {show(hu, vu)} vs app {show(ha, va)}");
            }
            Check($"{seedNo} doc: every field equal", same == du.Count && same == da.Count, $"{same} of {Math.Max(du.Count, da.Count)} (the unchanged ones not listed)");

            // 3. the game's copy = the account (what the screens show is what was saved), and the menu's feed has it
            var fresh = await fbU.Data.GetProfile(uidU);
            var keys = new[] { "pxp", "level", "coins", "totalEarned", "gems", "stack", "sort", "hop", "sdk" };
            string copyDiff = string.Join(", ", keys.Where(k => Canon(P.TryGetValue(k, out var x) ? x : null) != Canon(fresh.TryGetValue(k, out var y) ? y : null)));
            Check($"{seedNo} the game's copy matches the account", copyDiff.Length == 0, copyDiff.Length == 0 ? string.Join(" ", keys) : "differs: " + copyDiff);
            string feedDiff = string.Join(", ", keys.Where(k => Canon(feedNow.TryGetValue(k, out var x) ? x : null) != Canon(fresh.TryGetValue(k, out var y) ? y : null)));
            Check($"{seedNo} the menu's profile feed has the saves", feedDiff.Length == 0, feedDiff.Length == 0 ? "after refresh-after-write" : "differs: " + feedDiff);
            feed.Dispose();
        }

        // offline: nothing is sent, the copy keeps the game's fields only
        AccountSaves.Use(null, null);
        var off = new Dictionary<string, object> { ["pxp"] = 0.0 };
        var o2 = St.Levels.AfterLevel(off, St.Levels.LevelSpec(1, 0), 3, true, 3, false);
        St.StackSave.Paid(o2, off);
        Check("offline: no hook, no write, the copy untouched", St.StackSave.To == null && Sd.SdSave.BlitzSave == null && !off.ContainsKey("coins") && (double)off["pxp"] == 0);

        int failed = Results.Count(r => !r.ok);
        Console.WriteLine($"\n{Results.Count - failed} passed, {failed} failed");
        return failed == 0 ? 0 : 1;
    }

    static string FindHere()
    {
        for (var d = new DirectoryInfo(AppContext.BaseDirectory); d != null; d = d.Parent)
            if (File.Exists(Path.Combine(d.FullName, "app.mjs")) && File.Exists(Path.Combine(d.FullName, "SavesTest.csproj"))) return d.FullName;
        throw new Exception("can't find tools/unity/saves-test");
    }
}
