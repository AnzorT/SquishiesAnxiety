// Squishdoku's differential test, C# side: loads out/fixtures.json (fixtures.mjs: inputs and the JS game's outputs),
// runs the Unity port on the same inputs and compares deeply. Prints each area's pass count and its first
// mismatches; exits 1 on any mismatch.
//   node tools/unity/games/squishdoku/fixtures.mjs && dotnet run -c Release --project tools/unity/games/squishdoku
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using SquishSquad.Games.Squishdoku;

static class Program
{
    static readonly Dictionary<string, int[]> Tally = new Dictionary<string, int[]>(); // area → [pass, fail]
    static readonly List<string> Order = new List<string>();
    static readonly Dictionary<string, List<string>> Fails = new Dictionary<string, List<string>>();

    static int Main(string[] args)
    {
        string dir = AppContext.BaseDirectory;
        string file = args.Length > 0 ? args[0] : FindFixtures(dir);
        if (file == null || !File.Exists(file))
        {
            Console.Error.WriteLine("out/fixtures.json not found: run node tools/unity/games/squishdoku/fixtures.mjs first");
            return 2;
        }
        using var doc = JsonDocument.Parse(File.ReadAllBytes(file));
        var F = doc.RootElement;
        var clock = System.Diagnostics.Stopwatch.StartNew();

        Engine_(F);
        Levels_(F);
        Profiles_(F);

        int total = 0, bad = 0;
        foreach (var area in Order)
        {
            var t = Tally[area];
            total += t[0] + t[1];
            bad += t[1];
            Console.WriteLine($"{(t[1] == 0 ? "ok  " : "FAIL")} {area,-22} {t[0],6} / {t[0] + t[1]}");
            if (t[1] > 0) foreach (var f in Fails[area]) Console.WriteLine("       " + f);
        }
        Console.WriteLine($"\n{total - bad} / {total} cases match the JS ({bad} mismatches) in {clock.ElapsedMilliseconds} ms");
        return bad == 0 ? 0 : 1;
    }

    static string FindFixtures(string dir)
    {
        for (var d = new DirectoryInfo(dir); d != null; d = d.Parent)
        {
            var f = Path.Combine(d.FullName, "out", "fixtures.json");
            if (File.Exists(f)) return f;
            var g = Path.Combine(d.FullName, "tools", "unity", "games", "squishdoku", "out", "fixtures.json");
            if (File.Exists(g)) return g;
        }
        return null;
    }

    // --- checking ------------------------------------------------------------------------

    static void Check(string area, string label, JsonElement expected, object actual)
    {
        if (!Tally.ContainsKey(area))
        {
            Tally[area] = new int[2];
            Order.Add(area);
            Fails[area] = new List<string>();
        }
        string err;
        try
        {
            err = Diff(expected, actual, "");
        }
        catch (Exception e)
        {
            err = "threw " + e.GetType().Name + ": " + e.Message;
        }
        if (err == null) Tally[area][0]++;
        else
        {
            Tally[area][1]++;
            if (Fails[area].Count < 5) Fails[area].Add(label + ": " + err);
        }
    }

    static void Run(string area, string label, JsonElement expected, Func<object> actual)
    {
        object a;
        try
        {
            a = actual();
        }
        catch (Exception e)
        {
            a = new Threw(e);
        }
        Check(area, label, expected, a);
    }

    sealed class Threw
    {
        public readonly Exception E;
        public Threw(Exception e) { E = e; }
        public override string ToString() { return "threw " + E.GetType().Name + ": " + E.Message; }
    }

    static bool IsNum(object o)
    {
        return o is double || o is int || o is long || o is float || o is uint;
    }

    static string Show(object o)
    {
        if (o == null) return "null";
        if (o is string s) return "\"" + s + "\"";
        if (o is bool b) return b ? "true" : "false";
        if (IsNum(o)) return Convert.ToDouble(o, CultureInfo.InvariantCulture).ToString("R", CultureInfo.InvariantCulture);
        return o.ToString();
    }

    static string Short(JsonElement e)
    {
        string s = e.GetRawText();
        return s.Length > 120 ? s.Substring(0, 120) + "..." : s;
    }

    // null when equal, else where and how they differ
    static string Diff(JsonElement e, object a, string path)
    {
        string at = path.Length == 0 ? "" : path + ": ";
        if (a is Threw) return at + a;
        switch (e.ValueKind)
        {
            case JsonValueKind.Null:
                return a == null || (a is double d0 && double.IsNaN(d0)) ? null : at + $"expected null, got {Show(a)}";
            case JsonValueKind.True:
            case JsonValueKind.False:
                return a is bool b && b == (e.ValueKind == JsonValueKind.True) ? null : at + $"expected {e.GetRawText()}, got {Show(a)}";
            case JsonValueKind.Number:
                if (!IsNum(a)) return at + $"expected {e.GetRawText()}, got {Show(a)}";
                return e.GetDouble() == Convert.ToDouble(a, CultureInfo.InvariantCulture) ? null : at + $"expected {e.GetRawText()}, got {Show(a)}";
            case JsonValueKind.String:
                return a is string s && s == e.GetString() ? null : at + $"expected {e.GetRawText()}, got {Show(a)}";
            case JsonValueKind.Array:
            {
                if (!(a is IList list)) return at + $"expected {Short(e)}, got {Show(a)}";
                int n = e.GetArrayLength();
                if (list.Count != n) return at + $"expected {n} items {Short(e)}, got {list.Count}";
                int i = 0;
                foreach (var x in e.EnumerateArray())
                {
                    var r = Diff(x, list[i], path + "[" + i + "]");
                    if (r != null) return r;
                    i++;
                }
                return null;
            }
            case JsonValueKind.Object:
            {
                if (!(a is IDictionary<string, object> map)) return at + $"expected {Short(e)}, got {Show(a)}";
                int n = 0;
                foreach (var p in e.EnumerateObject())
                {
                    n++;
                    if (!map.TryGetValue(p.Name, out var v)) return at + $"missing key {p.Name}";
                    var r = Diff(p.Value, v, path + "." + p.Name);
                    if (r != null) return r;
                }
                if (map.Count != n)
                {
                    foreach (var k in map.Keys)
                    {
                        bool found = e.TryGetProperty(k, out _);
                        if (!found) return at + $"unexpected key {k}";
                    }
                }
                return null;
            }
        }
        return at + "unsupported " + e.ValueKind;
    }

    // --- JSON inputs ------------------------------------------------------------------------

    static double Num(JsonElement e)
    {
        if (e.ValueKind == JsonValueKind.String)
        {
            switch (e.GetString())
            {
                case "NaN": return double.NaN;
                case "Infinity": return double.PositiveInfinity;
                case "-Infinity": return double.NegativeInfinity;
            }
            throw new FormatException("not a number: " + e.GetString());
        }
        return e.GetDouble();
    }

    static int Int(JsonElement e) { return e.GetInt32(); }

    static int[] Ints(JsonElement e)
    {
        var a = new int[e.GetArrayLength()];
        int i = 0;
        foreach (var x in e.EnumerateArray()) a[i++] = x.GetInt32();
        return a;
    }

    // a profile as Firestore hands it over: maps, numbers as double, strings, bools, null, lists
    static object Model(JsonElement e)
    {
        switch (e.ValueKind)
        {
            case JsonValueKind.Object:
            {
                var d = new Dictionary<string, object>();
                foreach (var p in e.EnumerateObject()) d[p.Name] = Model(p.Value);
                return d;
            }
            case JsonValueKind.Array:
            {
                var l = new List<object>();
                foreach (var x in e.EnumerateArray()) l.Add(Model(x));
                return l;
            }
            case JsonValueKind.Number: return e.GetDouble();
            case JsonValueKind.String: return e.GetString();
            case JsonValueKind.True: return true;
            case JsonValueKind.False: return false;
            default: return null;
        }
    }

    static bool Has(JsonElement e, string key, out JsonElement v)
    {
        return e.TryGetProperty(key, out v) && v.ValueKind != JsonValueKind.Undefined;
    }

    // --- C# results as plain maps, keyed like the JS objects --------------------------------------

    static Dictionary<string, object> Obj(params object[] kv)
    {
        var d = new Dictionary<string, object>();
        for (int i = 0; i < kv.Length; i += 2) if (!(kv[i + 1] is Omit)) d[(string)kv[i]] = kv[i + 1];
        return d;
    }

    sealed class Omit { }
    static readonly Omit Absent = new Omit();

    static object P(GradeResult g)
    {
        return Obj("solved", g.Solved, "grade", g.Grade, "steps", g.Steps, "effort", g.Effort, "solution", g.Solved ? (object)g.Solution : Absent);
    }

    static object P(Puzzle p)
    {
        return Obj("n", p.N, "regions", p.Regions, "solution", p.Solution, "grade", p.Grade, "effort", p.Effort, "tier", p.Tier, "steps", p.Steps, "seed", (double)p.Seed);
    }

    static object P(LevelSpec s)
    {
        var pz = s.Puzzle;
        return Obj("lv", s.Lv, "n", s.N, "tier", s.Tier, "effort", s.Effort,
            "puzzle", Obj("n", pz.N, "regions", pz.Regions, "solution", pz.Solution, "colors", pz.Colors, "effort", pz.Effort),
            "limitMs", s.LimitMs, "aMs", s.AMs, "bMs", s.BMs, "head", s.Head, "hearts", s.Hearts);
    }

    static object P(PlayerLevelInfo l)
    {
        return l == null ? (object)Absent : Obj("level", l.Level, "into", l.Into, "need", l.Need);
    }

    static object P(SdkRecord r)
    {
        return Obj("lv", r.Lv, "best", r.Best, "perfect", r.Perfect, "skill", r.Skill, "bSkill", r.BSkill, "blitz", r.Blitz, "plays", r.Plays, "solves", r.Solves, "head", r.Head);
    }

    static object P(LevelOutcome o)
    {
        return Obj("update", o.Update, "coins", o.Coins, "levelCoins", o.LevelCoins.HasValue ? (object)o.LevelCoins.Value : Absent, "xp", o.Xp, "levelUps", o.LevelUps, "unlocked", o.Unlocked, "before", P(o.Before), "after", P(o.After));
    }

    static object P(BlitzOutcome o)
    {
        return Obj("update", o.Update, "coins", o.Coins, "xp", o.Xp, "levelUps", o.LevelUps, "before", P(o.Before), "after", P(o.After), "newTop", o.NewTop);
    }

    static object P(XpGain g)
    {
        return Obj("xp", g.Xp, "before", P(g.Before), "after", P(g.After), "levelUps", g.LevelUps);
    }

    // --- engine.js --------------------------------------------------------------------------

    static void Engine_(JsonElement F)
    {
        foreach (var c in F.GetProperty("rng").EnumerateArray())
        {
            long seed = c.GetProperty("seed").GetInt64();
            Run("rng", "seed " + seed, c.GetProperty("out"), () =>
            {
                var r = Engine.Rng(seed);
                var l = new List<double>();
                for (int i = 0; i < 64; i++) l.Add(r());
                return l;
            });
        }

        foreach (var c in F.GetProperty("pipeline").EnumerateArray())
        {
            int n = Int(c.GetProperty("n"));
            long seed = c.GetProperty("seed").GetInt64();
            string label = $"n={n} seed={seed}";
            var r = Engine.Rng(seed);
            int[] sol = null;
            Run("randomSolution", label, c.GetProperty("sol"), () => sol = Engine.RandomSolution(n, r));
            if (sol == null)
            {
                Run("rng position", label, c.GetProperty("next"), () => r());
                continue;
            }
            var regions = Engine.GrowRegions(n, sol, r);
            Check("growRegions", label, c.GetProperty("regions"), regions);
            Run("makeUnique", label, c.GetProperty("unique"), () => Engine.MakeUnique(n, regions, sol, r));
            Run("rng position", label, c.GetProperty("next"), () => r());
            Run("makeUnique maxMoves", label + " max 1", c.GetProperty("unique1"), () => Engine.MakeUnique(n, regions, sol, Engine.Rng(seed + 7), 1));
            Run("makeUnique maxMoves", label + " max 2", c.GetProperty("unique2"), () => Engine.MakeUnique(n, regions, sol, Engine.Rng(seed + 8), 2));
            Run("countSolutions", label, c.GetProperty("count"), () => Engine.CountSolutions(n, regions));
            Run("countSolutions", label + " limit 1", c.GetProperty("count1"), () => Engine.CountSolutions(n, regions, 1));
            Run("countSolutions", label + " limit 50", c.GetProperty("count50"), () => Engine.CountSolutions(n, regions, 50));
            Run("grade", label + " raw", c.GetProperty("grade"), () => P(Engine.Grade(n, regions)));
            if (Has(c, "uniqueCount", out var uc))
            {
                var unique = Ints(c.GetProperty("unique"));
                Run("countSolutions", label + " mended", uc, () => Engine.CountSolutions(n, unique));
                Run("grade", label + " mended", c.GetProperty("uniqueGrade"), () => P(Engine.Grade(n, unique)));
            }
        }

        int bi = 0;
        foreach (var b in F.GetProperty("boards").EnumerateArray())
        {
            int n = Int(b.GetProperty("n"));
            var regions = Ints(b.GetProperty("regions"));
            string label = bi < 600 ? $"level {bi + 1}" : $"board {bi} n={n}";
            Run("grade boards", label, b.GetProperty("grade"), () => P(Engine.Grade(n, regions)));
            Run("countSolutions boards", label, b.GetProperty("count"), () => Engine.CountSolutions(n, regions));
            Run("countSolutions boards", label + " limit 5", b.GetProperty("count5"), () => Engine.CountSolutions(n, regions, 5));
            bi++;
        }

        foreach (var c in F.GetProperty("conflicts").EnumerateArray())
        {
            int n = Int(c.GetProperty("n"));
            var regions = Ints(c.GetProperty("regions"));
            var cells = Ints(c.GetProperty("cells"));
            Run("conflicts", $"n={n} cells={c.GetProperty("cells").GetRawText()}", c.GetProperty("out"), () => Engine.Conflicts(n, regions, cells));
        }

        int mi = 0;
        foreach (var c in F.GetProperty("makePuzzle").EnumerateArray())
        {
            int n = Int(c.GetProperty("n"));
            int tier = Int(c.GetProperty("tier"));
            long seed = c.GetProperty("seed").GetInt64();
            var mt = c.GetProperty("maxTries");
            int maxTries = mt.ValueKind == JsonValueKind.Null ? 600 : mt.GetInt32();
            string label = $"n={n} tier={tier} seed={seed} maxTries={maxTries}";
            var m = new PuzzleMaker(n, tier, seed, maxTries);
            Puzzle p = null;
            double slice = mi % 2 == 1 ? 0 : 50;
            Run("puzzleMaker", label, c.GetProperty("out"), () =>
            {
                while ((p = m.Run(slice)) == null) { }
                return P(p);
            });
            Check("puzzleMaker tries", label, c.GetProperty("tries"), m.Tries);
            Check("puzzleMaker again", label, c.GetProperty("again"), p != null && ReferenceEquals(m.Run(5), p));
            Run("makePuzzle", label, c.GetProperty("viaMake"), () => P(Engine.MakePuzzle(n, tier, seed, maxTries)));
            mi++;
        }

        foreach (var c in F.GetProperty("tierOf").EnumerateArray())
            Run("tierOf", "e=" + c.GetProperty("e"), c.GetProperty("out"), () => Engine.TierOf(Int(c.GetProperty("e"))));
    }

    // --- levels.js --------------------------------------------------------------------------

    static void Levels_(JsonElement F)
    {
        var blitzSecs = new Dictionary<string, object>();
        var blitzCoins = new Dictionary<string, object>();
        for (int n = 4; n <= 8; n++)
        {
            blitzSecs[n.ToString(CultureInfo.InvariantCulture)] = Levels.BlitzSecs(n);
            blitzCoins[n.ToString(CultureInfo.InvariantCulture)] = Levels.BlitzCoins(n);
        }
        var list = new List<object>();
        foreach (var l in Levels.LevelList) list.Add(Obj("n", l.N, "tier", l.Tier, "effort", l.Effort));
        Run("constants", "constants", F.GetProperty("constants"), () => Obj(
            "TIERS", Engine.Tiers, "LEVELS", Levels.LevelCount, "CHAPTER", Levels.Chapter, "CHAPTERS", Levels.Chapters,
            "LEVEL_LIST", list, "HEAD_START", Obj("time", Levels.HeadStartTime, "reward", Levels.HeadStartReward),
            "HEARTS", Levels.Hearts, "HEARTS_FROM", Levels.HeartsFrom, "SKILL_MIN", Levels.SkillMin, "SKILL_MAX", Levels.SkillMax,
            "PERFECT_MULT", Levels.PerfectMult, "BLITZ_SECS", blitzSecs, "BLITZ_COINS", blitzCoins));

        foreach (var c in F.GetProperty("levelSpec").EnumerateArray())
        {
            double lv = Num(c.GetProperty("lv"));
            bool head = c.GetProperty("head").GetBoolean();
            Run("levelSpec", $"lv={lv} head={head}", c.GetProperty("out"), () => P(Levels.SpecOf(lv, head)));
        }
        foreach (var c in F.GetProperty("chapterOf").EnumerateArray())
            Run("chapterOf", "lv=" + c.GetProperty("lv"), c.GetProperty("out"), () => Levels.ChapterOf(Num(c.GetProperty("lv"))));
        foreach (var c in F.GetProperty("stageOf").EnumerateArray())
            Run("stageOf", "lv=" + c.GetProperty("lv"), c.GetProperty("out"), () =>
            {
                var s = Levels.StageOf(Num(c.GetProperty("lv")));
                return Obj("room", s.Room, "phase", s.Phase, "key", s.Key);
            });
        foreach (var c in F.GetProperty("roomOfChapter").EnumerateArray())
            Run("roomOfChapter", "c=" + c.GetProperty("c"), c.GetProperty("out"), () => Levels.RoomOfChapter(Int(c.GetProperty("c"))));
        foreach (var c in F.GetProperty("tierOfEffort").EnumerateArray())
            Run("tierOfEffort", "e=" + c.GetProperty("e"), c.GetProperty("out"), () => Levels.TierOfEffort(Int(c.GetProperty("e"))));

        foreach (var c in F.GetProperty("stars").EnumerateArray())
        {
            var spec = Levels.SpecOf(Num(c.GetProperty("lv")), c.GetProperty("head").GetBoolean());
            double ms = Num(c.GetProperty("ms"));
            int mistakes = Int(c.GetProperty("mistakes"));
            bool usedX = c.GetProperty("usedX").GetBoolean();
            string label = $"lv={spec.Lv} head={spec.Head} ms={ms} mistakes={mistakes} usedX={usedX}";
            Run("starsFor", label, c.GetProperty("starsFor"), () =>
            {
                var s = Levels.StarsFor(spec, ms, mistakes, usedX);
                return Obj("stars", s.Stars, "perfect", s.Perfect);
            });
            Run("starsLeft", label, c.GetProperty("starsLeft"), () => Levels.StarsLeft(spec, ms, mistakes));
        }
        foreach (var c in F.GetProperty("rewards").EnumerateArray())
        {
            var spec = Levels.SpecOf(Num(c.GetProperty("lv")), c.GetProperty("head").GetBoolean());
            string label = $"lv={spec.Lv} head={spec.Head}";
            var coins = new List<object>();
            var xp = new List<object>();
            foreach (bool perfect in new[] { false, true })
                for (int stars = 0; stars <= 3; stars++)
                {
                    coins.Add(Levels.CoinsFor(spec, stars, perfect));
                    xp.Add(Levels.XpFor(spec, stars, perfect));
                }
            Check("coinsFor", label, c.GetProperty("coins"), coins);
            Check("xpFor", label, c.GetProperty("xp"), xp);
        }
        foreach (var c in F.GetProperty("skillShift").EnumerateArray())
            Run("skillShift", "skill=" + c.GetProperty("skill"), c.GetProperty("out"), () => Levels.SkillShift(Num(c.GetProperty("skill"))));

        foreach (var c in F.GetProperty("blitzSpec").EnumerateArray())
        {
            int i = Int(c.GetProperty("i"));
            double skill = Num(c.GetProperty("skill"));
            Run("blitzSpec", $"i={i} skill={skill}", c.GetProperty("out"), () =>
            {
                var s = Levels.BlitzSpecOf(i, skill);
                return Obj("lv", s.Lv, "n", s.N, "tier", s.Tier, "ms", s.Ms);
            });
        }
        foreach (var c in F.GetProperty("blitzSaveGems").EnumerateArray())
            Run("blitzSaveGems", "i=" + c.GetProperty("i").GetRawText(), c.GetProperty("out"), () => Levels.BlitzSaveGems(Model(c.GetProperty("i"))));
        foreach (var c in F.GetProperty("blitzSaveGemsNum").EnumerateArray())
            Run("blitzSaveGems", "i=" + c.GetProperty("i").GetRawText(), c.GetProperty("out"), () => Levels.BlitzSaveGems(Num(c.GetProperty("i"))));

        foreach (var c in F.GetProperty("clock").EnumerateArray())
            Run("clock", "ms=" + c.GetProperty("ms").GetRawText(), c.GetProperty("out"), () => Levels.Clock(Num(c.GetProperty("ms"))));
    }

    // --- the profile ------------------------------------------------------------------------

    static void Profiles_(JsonElement F)
    {
        var P0 = F.GetProperty("profiles");
        var configs = new List<XpRules>();
        foreach (var c in P0.GetProperty("configs").EnumerateArray())
            configs.Add(new XpRules { XpPerLevel = c.GetProperty("xpPerLevel").GetDouble(), Games = c.GetProperty("games").GetDouble(), Replay = c.GetProperty("replay").GetDouble(), BlitzSquishdoku = c.GetProperty("blitzSquishdoku").GetDouble() });
        // a fresh copy for every call, so nothing a call might do to a profile leaks into the next
        var profiles = new List<JsonElement>();
        foreach (var p in P0.GetProperty("list").EnumerateArray()) profiles.Add(p);
        IDictionary<string, object> ProfileAt(JsonElement c) => Model(profiles[Int(c.GetProperty("p"))]) as IDictionary<string, object>;
        void Use(JsonElement c) => PlayerXp.Rules = configs[Int(c.GetProperty("config"))];

        foreach (var c in P0.GetProperty("playerLevel").EnumerateArray())
        {
            Use(c);
            Run("playerLevel", $"cfg={c.GetProperty("config")} pxp={c.GetProperty("pxp")}", c.GetProperty("out"), () => P(PlayerXp.PlayerLevel(Num(c.GetProperty("pxp")))));
        }
        foreach (var c in P0.GetProperty("addXp").EnumerateArray())
        {
            Use(c);
            Run("addXp", $"cfg={c.GetProperty("config")} p={c.GetProperty("p")} n={c.GetProperty("n")}", c.GetProperty("out"), () => P(PlayerXp.AddXp(ProfileAt(c), Num(c.GetProperty("n")))));
        }
        foreach (var c in P0.GetProperty("record").EnumerateArray())
        {
            Use(c);
            Run("record", $"cfg={c.GetProperty("config")} p={c.GetProperty("p")}", c.GetProperty("out"), () => P(Levels.Record(ProfileAt(c))));
        }
        foreach (var c in P0.GetProperty("afterLevel").EnumerateArray())
        {
            Use(c);
            var res = c.GetProperty("result");
            bool solved = res.GetProperty("solved").GetBoolean();
            int stars = Has(res, "stars", out var st) ? st.GetInt32() : 0;
            bool perfect = Has(res, "perfect", out var pf) && pf.GetBoolean();
            double lv = Num(c.GetProperty("lv"));
            bool head = c.GetProperty("head").GetBoolean();
            Run("afterLevel", $"cfg={c.GetProperty("config")} p={c.GetProperty("p")} lv={lv} head={head} result={res.GetRawText()}", c.GetProperty("out"),
                () => P(Levels.AfterLevel(ProfileAt(c), Levels.SpecOf(lv, head), solved, stars, perfect)));
        }
        foreach (var c in P0.GetProperty("afterBlitz").EnumerateArray())
        {
            Use(c);
            int cleared = Int(c.GetProperty("cleared"));
            Run("afterBlitz", $"cfg={c.GetProperty("config")} p={c.GetProperty("p")} cleared={cleared}", c.GetProperty("out"), () => P(Levels.AfterBlitz(ProfileAt(c), cleared)));
        }
        foreach (var c in P0.GetProperty("blitzPrize").EnumerateArray())
        {
            Use(c);
            int cleared = Int(c.GetProperty("cleared"));
            double skill = Num(c.GetProperty("skill"));
            Run("blitzPrize", $"cfg={c.GetProperty("config")} cleared={cleared} skill={skill}", c.GetProperty("out"), () =>
            {
                var b = Levels.BlitzPrize(cleared, skill);
                return Obj("coins", b.Coins, "xp", b.Xp);
            });
        }
        PlayerXp.Rules = new XpRules();
    }
}
