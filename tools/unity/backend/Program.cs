// End-to-end test of the Unity port's Firebase client (unity/Assets/Scripts/Backend) against the Firebase Local
// Emulator Suite (auth 9099, firestore 8080, functions 5001, project demo-squish). See README.md.
//
// Every request goes through LocalOnlyHttp, which refuses anything that isn't 127.0.0.1 / localhost: this can never
// reach the live project.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Backend;
using SquishSquad.Games.Stack;

static class Program
{
    sealed class LocalOnlyHttp : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(30));
        public int Requests;

        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http")
                throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            Interlocked.Increment(ref Requests);
            return Logged(r, cancel);
        }

        static readonly bool trace = Environment.GetEnvironmentVariable("TRACE_HTTP") == "1";

        async Task<HttpResult> Logged(HttpRequest r, CancellationToken cancel)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var res = await inner.Send(r, cancel);
                if (trace) Console.WriteLine($"    {r.Method} {r.Url} → {res.Status} ({sw.ElapsedMilliseconds} ms){(res.Ok ? "" : " " + res.Body.Replace("\n", " ").Substring(0, Math.Min(300, res.Body.Length)))}");
                return res;
            }
            catch (Exception e)
            {
                if (trace) Console.WriteLine($"    {r.Method} {r.Url} → {e.GetType().Name} ({sw.ElapsedMilliseconds} ms)");
                throw;
            }
        }
    }

    static readonly List<(string name, bool ok, string note)> results = new List<(string, bool, string)>();

    static async Task Check(string name, Func<Task<string>> body)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            string note = await body();
            results.Add((name, true, note ?? ""));
        }
        catch (Exception e)
        {
            var b = e is AggregateException a ? a.GetBaseException() : e;
            results.Add((name, false, b.GetType().Name + ": " + b.Message));
        }
    }

    static void Assert(bool cond, string what)
    {
        if (!cond) throw new Exception("expected " + what);
    }

    static async Task<T> Throws<T>(Func<Task> f) where T : Exception
    {
        try
        {
            await f();
        }
        catch (T e)
        {
            return e;
        }
        throw new Exception("expected a " + typeof(T).Name);
    }

    static IDictionary<string, object> M(object o) => o as IDictionary<string, object>;
    static double D(object o) => o is double d ? d : throw new Exception("not a double: " + (o?.GetType().Name ?? "null"));

    static async Task<int> Main(string[] args)
    {
        string host = Environment.GetEnvironmentVariable("EMULATOR_HOST") ?? "127.0.0.1";
        var cfg = FirebaseConfig.Emulator("demo-squish", host);
        Assert(cfg.ProjectId.StartsWith("demo-"), "a demo- project");
        var http = new LocalOnlyHttp();
        string run = DateTime.UtcNow.Ticks.ToString("x");
        string emailA = "a" + run + "@example.com", emailB = "b" + run + "@example.com";
        const string pw = "squish123";

        // --- offline: the codec ------------------------------------------------------------------------------
        await Check("codec: REST JSON → map shape", () =>
        {
            const string rest = @"{""fields"":{
              ""i"":{""integerValue"":""250""},""d"":{""doubleValue"":1.5},""b"":{""booleanValue"":true},
              ""s"":{""stringValue"":""hi é""},""n"":{""nullValue"":null},
              ""t"":{""timestampValue"":""2026-11-23T10:00:00.123456789Z""},
              ""r"":{""referenceValue"":""projects/demo-squish/databases/(default)/documents/users/x""},
              ""g"":{""geoPointValue"":{""latitude"":1.25,""longitude"":-2}},""y"":{""bytesValue"":""AQID""},
              ""a"":{""arrayValue"":{""values"":[{""stringValue"":""0""},{""integerValue"":""3""}]}},
              ""e"":{""arrayValue"":{}},
              ""m"":{""mapValue"":{""fields"":{""playTime"":{""mapValue"":{}},""x"":{""doubleValue"":""NaN""}}}}}}";
            var f = FirestoreValues.DecodeFields(Json.Get(Json.Parse(rest), "fields"), "projects/demo-squish/databases/(default)/documents/");
            Assert(D(f["i"]) == 250 && D(f["d"]) == 1.5 && (bool)f["b"] && (string)f["s"] == "hi é" && f["n"] == null, "scalars");
            var t = (DateTime)f["t"];
            Assert(t.Kind == DateTimeKind.Utc && t.Ticks % 10000000 == 1234567 && t.Hour == 10, "timestamp to 100 ns");
            Assert(((DocumentRef)f["r"]).Path == "users/x", "reference path");
            Assert(((GeoPoint)f["g"]).Longitude == -2 && ((byte[])f["y"]).SequenceEqual(new byte[] { 1, 2, 3 }), "geo / bytes");
            var a = (List<object>)f["a"];
            Assert(a.Count == 2 && (string)a[0] == "0" && D(a[1]) == 3 && ((List<object>)f["e"]).Count == 0, "arrays");
            var m = M(f["m"]);
            Assert(M(m["playTime"]).Count == 0 && double.IsNaN(D(m["x"])), "nested map");
            // and back
            var enc = Json.Write(FirestoreValues.EncodeFields(f, "projects/demo-squish/databases/(default)/documents/"));
            var again = FirestoreValues.DecodeFields(Json.Parse(enc), "projects/demo-squish/databases/(default)/documents/");
            Assert(Json.Write(FirestoreValues.EncodeFields(again, "p/")) == Json.Write(FirestoreValues.EncodeFields(f, "p/")), "round trip");
            Assert(enc.Contains("\"integerValue\":\"250\"") && enc.Contains("\"doubleValue\":1.5"), "250 as integerValue, 1.5 as double");
            return Task.FromResult("11 value types, round trip");
        });

        await Check("codec: field paths", () =>
        {
            Assert(FirestoreValues.QuotePath(FirestoreValues.SplitPath("stack.best.3")) == "stack.best.`3`", "digits quoted");
            Assert(FirestoreValues.QuotePath(FirestoreValues.SplitPath("lobby.sel")) == "lobby.sel", "plain");
            Assert(FirestoreValues.QuotePath(new[] { "a-b", "c`d" }) == "`a-b`.`c\\`d`", "odd characters");
            Assert(string.Join("|", FirestoreValues.SplitPath("a.`b.c`.d")) == "a|b.c|d", "quoted segment");
            var obj = Json.Parse("{\"a\":[1,2.5,\"x\\n\\u00e9\",true,null,{}],\"b\":-0.001e3}");
            Assert(Json.Write(obj) == "{\"a\":[1,2.5,\"x\\né\",true,null,{}],\"b\":-1}", "json round trip");
            return Task.FromResult("");
        });

        // --- auth ----------------------------------------------------------------------------------------------
        var storeA = new MemoryAuthStore();
        var fb = new FirebaseClient(cfg, storeA, http);
        var events = new List<string>();
        fb.Auth.AuthStateChanged += u => events.Add(u?.Uid ?? "null");
        string uidA = null, uidB = null;

        await Check("auth: start with no session", async () =>
        {
            var u = await fb.Auth.Start();
            Assert(u == null && events.SequenceEqual(new[] { "null" }), "signed out, one event");
            return "";
        });

        await Check("auth: sign up (registerWithEmail)", async () =>
        {
            fb.Auth.SetKeepSignedIn(true);
            var u = await fb.Auth.RegisterWithEmail(emailA, pw);
            uidA = u.Uid;
            Assert(!string.IsNullOrEmpty(u.Uid) && u.Email == emailA, "uid + email");
            Assert(u.ProviderIds.Contains("password") && u.NeedsVerification, "password provider, needs verification");
            Assert(events.Last() == uidA, "AuthStateChanged(user)");
            return "uid " + uidA;
        });

        await Check("auth: errors map to the app's messages", async () =>
        {
            var probe = new FirebaseAuth(cfg, http, new MemoryAuthStore());
            var dup = await Throws<FirebaseAuthException>(() => probe.RegisterWithEmail(emailA, pw));
            Assert(dup.Code == "auth/email-already-in-use" && dup.Message == "That email is already registered — try logging in instead.", "EMAIL_EXISTS (" + dup.Code + ")");
            var weak = await Throws<FirebaseAuthException>(() => probe.RegisterWithEmail("w" + emailA, "123"));
            Assert(weak.Code == "auth/weak-password" && weak.Message == "Password needs at least 6 characters.", "WEAK_PASSWORD (" + weak.Code + ")");
            var bad = await Throws<FirebaseAuthException>(() => probe.LoginWithEmail(emailA, "wrong-pass"));
            Assert(bad.Code == "auth/wrong-password" || bad.Code == "auth/invalid-credential", "wrong password (" + bad.Code + ")");
            var none = await Throws<FirebaseAuthException>(() => probe.LoginWithEmail("nobody" + emailA, pw));
            Assert(none.Code == "auth/user-not-found" || none.Code == "auth/invalid-credential", "no such user (" + none.Code + ")");
            var inv = await Throws<FirebaseAuthException>(() => probe.RegisterWithEmail("not-an-email", pw));
            Assert(inv.Code == "auth/invalid-email" && inv.Message == "That email address doesn't look right.", "INVALID_EMAIL (" + inv.Code + ")");
            var net = await Throws<FirebaseAuthException>(() =>
                new FirebaseAuth(FirebaseConfig.Emulator("demo-squish", "127.0.0.1", authPort: 9), http, null).LoginWithEmail(emailA, pw));
            Assert(net.Code == "auth/network-request-failed" && net.Message == "Network error — check your connection.", "no server → network error");
            return $"{dup.ServerCode}, {weak.ServerCode}, {bad.ServerCode}, {none.ServerCode}, {inv.ServerCode}, network";
        });

        await Check("auth: sign out, sign in (loginWithEmail)", async () =>
        {
            await fb.Auth.SignOut();
            Assert(fb.Auth.CurrentUser == null && events.Last() == "null", "signed out");
            var u = await fb.Auth.LoginWithEmail(emailA, pw);
            Assert(u.Uid == uidA && events.Last() == uidA, "same uid");
            return "";
        });

        await Check("auth: ID token cached, refreshed (forced and near expiry)", async () =>
        {
            string t1 = await fb.Auth.GetIdToken();
            string t1b = await fb.Auth.GetIdToken();
            Assert(t1 == t1b, "cached");
            var exp1 = fb.Auth.TokenExpiresAtUtc.Value;
            await Task.Delay(1100); // the token's iat is in seconds
            string t2 = await fb.Auth.GetIdToken(true);
            Assert(t2 != t1 && fb.Auth.TokenExpiresAtUtc.Value > exp1, "forced refresh: a new token, later expiry");
            var claims = FirebaseAuth.DecodeJwtPayload(t2);
            Assert(Json.Str(claims, "user_id") == uidA, "token is for the user");
            // 56 minutes on: inside the 5-minute window, so the next call refreshes by itself
            await Task.Delay(1100);
            fb.Auth.UtcNow = () => DateTime.UtcNow + TimeSpan.FromMinutes(56);
            string t3 = await fb.Auth.GetIdToken();
            fb.Auth.UtcNow = () => DateTime.UtcNow;
            Assert(t3 != t2, "refreshed before expiry");
            return "expires " + fb.Auth.TokenExpiresAtUtc.Value.ToString("HH:mm:ss") + "Z";
        });

        await Check("auth: session persists; 'Keep me signed in' off drops it", async () =>
        {
            var again = new FirebaseAuth(cfg, http, storeA);
            var u = await again.Start();
            Assert(u != null && u.Uid == uidA && u.Email == emailA, "restored from the store");
            Assert(!string.IsNullOrEmpty(await again.GetIdToken()), "token usable");
            again.SetKeepSignedIn(false);
            var third = new FirebaseAuth(cfg, http, storeA);
            string seen = "unset";
            third.AuthStateChanged += x => seen = x?.Uid ?? "null";
            Assert(await third.Start() == null && seen == "null", "dropped on start");
            Assert(await new FirebaseAuth(cfg, http, storeA).Start() == null, "and stays gone");
            // fb itself is still signed in (its own copy); keep it so for the rest, and save it again
            fb.Auth.SetKeepSignedIn(true);
            await fb.Auth.GetIdToken(true);
            Assert(await new FirebaseAuth(cfg, http, storeA).Start() != null, "saved again after a refresh");
            return "";
        });

        await Check("auth: email verification (sendOobCode + emulator link) and password reset", async () =>
        {
            await fb.Auth.SendVerification();
            Assert(!await fb.Auth.ReloadVerified(), "not verified yet");
            // the emulator keeps the mails' codes; applying one is what tapping the link does
            var res = await http.Send(new HttpRequest { Url = $"http://{host}:9099/emulator/v1/projects/demo-squish/oobCodes" });
            var codes = (List<object>)Json.Get(Json.Parse(res.Body), "oobCodes");
            var code = codes.Cast<IDictionary<string, object>>().Last(c => (string)c["email"] == emailA && (string)c["requestType"] == "VERIFY_EMAIL");
            var apply = await http.Send(new HttpRequest
            {
                Method = "POST",
                Url = $"http://{host}:9099/identitytoolkit.googleapis.com/v1/accounts:update?key=fake-api-key",
                Body = Json.Write(new Dictionary<string, object> { { "oobCode", code["oobCode"] } }),
            });
            Assert(apply.Ok, "link applied");
            Assert(await fb.Auth.ReloadVerified() && !fb.Auth.CurrentUser.NeedsVerification, "verified after reload");
            var claims = FirebaseAuth.DecodeJwtPayload(await fb.Auth.GetIdToken());
            Assert(Json.Get(claims, "email_verified") is bool v && v, "fresh token says email_verified");
            await fb.Auth.SendPasswordReset(emailA);
            return "";
        });

        // --- the profile ---------------------------------------------------------------------------------------
        IDictionary<string, object> profile = null;
        IProfileFeed feed = null;
        var feedSeen = new List<IDictionary<string, object>>();

        await Check("firestore: createUserProfile, read back as the app's map", async () =>
        {
            await fb.Data.CreateUserProfile(uidA, emailA, 14, "  Mittens ");
            profile = await fb.Data.GetProfile(uidA);
            Assert((string)profile["nickname"] == "Mittens" && D(profile["age"]) == 14, "nickname trimmed, age");
            Assert(D(profile["coins"]) == 250 && D(profile["totalEarned"]) == 250 && D(profile["generationCredits"]) == 1, "coins as double");
            Assert((bool)profile["adsFree"] == false && !profile.ContainsKey("tut") && D(profile["level"]) == 1 && D(profile["pxp"]) == 0, "flags");
            var owned = (List<object>)profile["ownedIds"];
            Assert(owned.Count == 1 && (string)owned[0] == "0", "ownedIds ['0']");
            var stats = M(profile["stats"]);
            Assert(D(stats["presses"]) == 0 && M(stats["playTime"]).Count == 0, "stats map");
            Assert((bool)M(profile["achievements"])["speedTap"] == false, "achievements map");
            var created = (DateTime)profile["createdAt"];
            Assert(Math.Abs((DateTime.UtcNow - created).TotalMinutes) < 5, "createdAt: server time");
            var rec = Levels.Record(profile);
            Assert(rec.Lv == 1 && rec.Best.Count == 0 && rec.Plays == 0 && !rec.Seen, "Levels.Record on a fresh profile");
            return profile.Count + " fields";
        });

        await Check("firestore: profile feed (polling) delivers the profile", async () =>
        {
            feed = fb.Data.SubscribeToUserProfile(uidA, TimeSpan.FromSeconds(2));
            feed.Changed += p => feedSeen.Add(p);
            for (int i = 0; i < 50 && !feed.Loaded; i++) await Task.Delay(100);
            Assert(feed.Loaded && feed.Current != null && D(feed.Current["coins"]) == 250, "first read");
            Assert(feedSeen.Count == 1, "one Changed");
            return "";
        });

        await Check("firestore: typical updates (increment, arrayUnion/Remove, dotted paths)", async () =>
        {
            await fb.Data.AddCoins(uidA, 25);
            await fb.Data.SetLobbySelected(uidA, "3");
            await fb.Data.MarkSquadSeen(uidA, new[] { "3", "5" });
            await fb.Data.SetOfferSeen(uidA, "starter", 1763892000000);
            await fb.Data.MarkAchievement(uidA, "speedTap");
            await fb.Data.SetTutorialStep(uidA, "lobby");
            await fb.Data.EnsureStarterCreaturesOwned(uidA, new List<object> { "7" });
            await fb.Firestore.Update("users/" + uidA, new Dictionary<string, object> { { "ownedIds", FieldValue.ArrayUnion("7", "8") } });
            await fb.Firestore.Update("users/" + uidA, new Dictionary<string, object> { { "ownedIds", FieldValue.ArrayRemove("8") } });
            await fb.Data.RecordPress(uidA, "12", 800);
            await fb.Data.RecordPress(uidA, "12", 300);
            var p = await fb.Data.GetProfile(uidA);
            Assert(D(p["coins"]) == 275 && D(p["totalEarned"]) == 275, "coins 250 + 25");
            var lobby = M(p["lobby"]);
            Assert((string)lobby["sel"] == "3" && string.Join(",", (List<object>)lobby["seen"]) == "3,5", "lobby.sel / lobby.seen");
            Assert(D(M(p["offerSeen"])["starter"]) == 1763892000000, "offerSeen.starter (ms, as a whole double)");
            Assert((bool)M(p["achievements"])["speedTap"] && (bool)M(p["achievements"])["watchAd"] == false, "achievements.speedTap only");
            Assert(string.Join(",", (List<object>)p["ownedIds"]) == "0,7", "ownedIds ∪ {7,8} − {8}");
            var stats = M(p["stats"]);
            Assert(D(stats["presses"]) == 2 && D(stats["longestHoldMs"]) == 800 && D(M(stats["playTime"])["12"]) == 1100, "recordPress transaction");
            Assert(D(M(p["xp"])["12"]) == 2, "xp.`12` (a numeric path segment)");
            Assert((string)p["tut"] == "lobby", "tut");
            // the feed saw all of it without waiting for a poll
            Assert(D(feed.Current["coins"]) == 275 && D(M(feed.Current["xp"])["12"]) == 2, "feed refreshed after writes");
            profile = p;
            return "";
        });

        await Check("firestore: saveStack(afterLevel) — write, local apply, read back via Levels.Record", async () =>
        {
            var spec = Levels.LevelSpec(1, 0);
            int par = spec.Par[0];
            var outcome = Levels.AfterLevel(profile, spec, par, true, par, false);
            Assert(outcome.Stars == 3 && outcome.Unlocked && outcome.Coins > 0 && outcome.Xp > 0, "a 3-star first win");
            double? levelAfter = outcome.LevelUps.Count > 0 ? outcome.After.Level : (double?)null;
            var save = fb.Data.SaveStack(uidA, outcome.Update, outcome.Coins, outcome.Xp, profile, levelAfter);
            // latency compensation: the feed has it before the server answers
            var local = Levels.Record(feed.Current);
            Assert(local.Lv == 2 && Js_ToNum(local.Best["1"]) == 3, "local apply: stack.lv 2, stack.best.1 = 3");
            await save;
            var p = await fb.Data.GetProfile(uidA);
            var rec = Levels.Record(p);
            Assert(rec.Lv == 2 && Js_ToNum(rec.Best["1"]) == 3 && rec.Wins == 1 && rec.Plays == 1 && rec.Seen, "server: the stack record");
            Assert(D(p["coins"]) == 275 + outcome.Coins && D(p["totalEarned"]) == 275 + outcome.Coins, "coins + totalEarned incremented");
            Assert(D(p["pxp"]) == outcome.Xp, "pxp incremented");
            if (levelAfter.HasValue) Assert(D(p["level"]) == levelAfter.Value, "level");
            Assert(Levels.Record(feed.Current).Lv == 2, "feed matches");
            // a loss: plays and skill only
            var lost = Levels.AfterLevel(p, Levels.LevelSpec(2, rec.Skill), 5, false, 9, false);
            await fb.Data.SaveStack(uidA, lost.Update, lost.Coins, lost.Xp, p);
            var rec2 = Levels.Record(await fb.Data.GetProfile(uidA));
            Assert(rec2.Plays == 2 && rec2.Wins == 1 && rec2.Skill == lost.Update["stack.skill"] as double?, "a loss");
            profile = await fb.Data.GetProfile(uidA);
            return $"+{outcome.Coins} coins, +{outcome.Xp} XP, {string.Join(" ", outcome.Update.Keys)}";
        });

        await Check("firestore: subcollections, add with serverTimestamp, list ordered, delete", async () =>
        {
            string basePath = "users/" + uidA + "/customCreatures/";
            await fb.Firestore.Set(basePath + "c1", new Dictionary<string, object> { { "name", "One" }, { "status", "ready" }, { "build", null }, { "createdAt", FieldValue.ServerTimestamp } });
            await Task.Delay(20);
            string id2 = await fb.Firestore.Add("users/" + uidA + "/customCreatures", new Dictionary<string, object> { { "name", "Two" }, { "status", "pending" }, { "progress", 0 }, { "createdAt", FieldValue.ServerTimestamp } });
            var list = await fb.Data.ListCustomCreatures(uidA);
            Assert(list.Count == 2 && (string)list[0]["name"] == "One" && (string)list[1]["id"] == id2 && list[1]["createdAt"] is DateTime, "two, in createdAt order");
            // retryCustomCreature: merge set with FieldValue.Delete
            await fb.Firestore.Update(basePath + id2, new Dictionary<string, object> { { "error", "boom" }, { "status", "failed" } });
            await fb.Firestore.Set(basePath + id2, new Dictionary<string, object> { { "status", "pending" }, { "progress", 0 }, { "error", FieldValue.Delete } }, merge: true);
            var d2 = (await fb.Firestore.Get(basePath + id2)).Data;
            Assert(!d2.ContainsKey("error") && (string)d2["status"] == "pending" && (string)d2["name"] == "Two", "merge set kept name, dropped error");
            await fb.Data.DeleteCustomCreature(uidA, "c1");
            Assert(await fb.Firestore.Get(basePath + "c1") == null, "deleted (Get → null)");
            await fb.Data.SaveCrib(uidA, new Dictionary<string, object> { { "rooms", new List<object> { new Dictionary<string, object> { { "id", "r1" } } } }, { "orient", "land" } });
            var crib = await fb.Data.LoadCrib(uidA);
            Assert((string)crib["orient"] == "land" && M(((List<object>)crib["rooms"])[0])["id"] as string == "r1", "crib/state");
            await fb.Data.SubmitFeedback(uidA, " love it ");
            return "id " + id2;
        });

        // --- Cloud Functions -----------------------------------------------------------------------------------
        await Check("functions: spinWheel (callable) and the profile it changed", async () =>
        {
            var r = M(await fb.Data.CallAndRefresh("spinWheel", new Dictionary<string, object> { { "tzOffsetMinutes", 0.0 } }));
            Assert(r != null && r.ContainsKey("kind") && r["amount"] is double && r["index"] is double, "a prize { index, kind, amount }");
            var p = feed.Current;
            Assert(D(p["spins"]) == 1 && p["lastSpinDay"] is string, "spins / lastSpinDay written by the function, seen by the feed");
            if ((string)r["kind"] == "coins") Assert(D(p["coins"]) == D(profile["coins"]) + D(r["amount"]), "coins prize credited");
            var again = M(await fb.Functions.Call("spinWheel", new Dictionary<string, object> { { "tzOffsetMinutes", 0.0 } }));
            Assert(again["already"] is bool b && b, "second spin today: { already: true }");
            return $"{r["kind"]} {r["amount"]}";
        });

        await Check("functions: errors (unknown squad move, signed out)", async () =>
        {
            var e = await Throws<FunctionsException>(() => fb.Functions.Call("squad", new Dictionary<string, object> { { "move", "nope" } }));
            Assert(e.Code == "invalid-argument" && e.Message == "Unknown move.", "HttpsError → code + message");
            var anon = new FirebaseClient(cfg, new MemoryAuthStore(), http);
            var e2 = await Throws<FunctionsException>(() => anon.Functions.Call("spinWheel"));
            Assert(e2.Message == "Not signed in", "callFunction.js's 'Not signed in'");
            return e.Code + ": " + e.Message;
        });

        await Check("firestore: a change made elsewhere reaches the feed at its next poll", async () =>
        {
            var other = new FirebaseClient(cfg, new MemoryAuthStore(), http); // A on a second device
            await other.Auth.LoginWithEmail(emailA, pw);
            double before = D(feed.Current["coins"]);
            await other.Data.AddCoins(uidA, 7);
            var sw = Stopwatch.StartNew();
            while (D(feed.Current["coins"]) != before + 7 && sw.ElapsedMilliseconds < 6000) await Task.Delay(100);
            Assert(D(feed.Current["coins"]) == before + 7, "seen within two poll intervals");
            return $"after {sw.ElapsedMilliseconds} ms (interval 2 s)";
        });

        // --- rules ---------------------------------------------------------------------------------------------
        var fbB = new FirebaseClient(cfg, new MemoryAuthStore(), http);
        await Check("rules: another user's doc and server-only fields are refused", async () =>
        {
            uidB = (await fbB.Auth.RegisterWithEmail(emailB, pw)).Uid;
            var r1 = await Throws<FirestoreException>(() => fbB.Firestore.Get("users/" + uidA));
            var r2 = await Throws<FirestoreException>(() => fbB.Firestore.Update("users/" + uidA, new Dictionary<string, object> { { "coins", FieldValue.Increment(1000) } }));
            var r3 = await Throws<FirestoreException>(() => fbB.Firestore.Set("users/" + uidA + "/crib/state", new Dictionary<string, object> { { "x", 1 } }));
            Assert(r1.Code == "permission-denied" && r2.Code == "permission-denied" && r3.Code == "permission-denied", "B can't read / write A");
            var r4 = await Throws<FirestoreException>(() => fb.Firestore.Update("users/" + uidA, new Dictionary<string, object> { { "gems", 9999 } }));
            var r5 = await Throws<FirestoreException>(() => fb.Firestore.Update("users/" + uidA, new Dictionary<string, object> { { "generationCredits", FieldValue.Increment(5) } }));
            Assert(r4.Code == "permission-denied" && r5.Code == "permission-denied", "A can't write gems / generationCredits");
            var r6 = await Throws<FirestoreException>(() => fbB.Data.CreateUserProfile(uidA, emailB, 20, "Thief"));
            Assert(r6.Code == "permission-denied", "B can't create A's profile");
            var r7 = await Throws<FirestoreException>(() => fbB.Firestore.Add("feedback", new Dictionary<string, object> { { "uid", uidA }, { "text", "spoof" } }));
            Assert(r7.Code == "permission-denied", "feedback must carry your own uid");
            var r8 = await Throws<FirestoreException>(() => fb.Firestore.List("feedback"));
            Assert(r8.Code == "permission-denied", "feedback can't be read back");
            // updating a doc that isn't there: not-found where the rules allow the write (B's own crib)…
            var missing = await Throws<FirestoreException>(() => fbB.Firestore.Update("users/" + uidB + "/crib/state", new Dictionary<string, object> { { "coins", 1 } }));
            Assert(missing.Code == "not-found", "update of a missing doc → not-found (" + missing.Code + ")");
            // …but permission-denied on users/{uid}: its update rule reads `resource`, which is null (as in production)
            var noProfile = await Throws<FirestoreException>(() => fbB.Firestore.Update("users/" + uidB, new Dictionary<string, object> { { "coins", 1 } }));
            Assert(noProfile.Code == "permission-denied", "update of a missing profile → permission-denied (" + noProfile.Code + ")");
            Assert(D((await fb.Data.GetProfile(uidA))["coins"]) == D(feed.Current["coins"]), "A unchanged");
            return "denied ×9, not-found ×1";
        });

        await Check("auth: custom token sign-in (social.js path, emulator's unsigned token)", async () =>
        {
            string B64(string s) => Convert.ToBase64String(Encoding.UTF8.GetBytes(s)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string jwt = B64("{\"alg\":\"none\",\"typ\":\"JWT\"}") + "." + B64(Json.Write(new Dictionary<string, object>
            {
                { "iss", "firebase-adminsdk@demo-squish.iam.gserviceaccount.com" },
                { "sub", "firebase-adminsdk@demo-squish.iam.gserviceaccount.com" },
                { "aud", "https://identitytoolkit.googleapis.com/google.identity.identitytoolkit.v1.IdentityToolkit" },
                { "iat", now }, { "exp", now + 3600 }, { "uid", "social-" + run },
            })) + ".";
            var c = new FirebaseClient(cfg, new MemoryAuthStore(), http);
            var u = await c.Auth.SignInWithCustomToken(jwt);
            Assert(u.Uid == "social-" + run && !u.NeedsVerification, $"signed in as the token's uid, no verification needed ({u.Uid}, {string.Join("/", u.ProviderIds)}, {u.EmailVerified})");
            var bad = await Throws<FirebaseAuthException>(() => c.Auth.SignInWithCustomToken("garbage"));
            Assert(bad.Code == "auth/invalid-custom-token", "bad token (" + bad.Code + ")");
            return u.Uid;
        });

        await Check("auth: sign out ends access", async () =>
        {
            int before = feedSeen.Count;
            await fb.Auth.SignOut();
            Assert(fb.Auth.CurrentUser == null && events.Last() == "null", "signed out");
            var e = await Throws<FirestoreException>(() => fb.Firestore.Get("users/" + uidA));
            Assert(e.Code == "permission-denied", "unauthenticated read refused");
            Assert(storeA.Read("squish.auth.user") == null, "session forgotten");
            await fbB.Auth.SignOut();
            return "";
        });

        // --- table ---------------------------------------------------------------------------------------------
        int w = results.Max(r => r.name.Length);
        Console.WriteLine();
        Console.WriteLine("  " + "TEST".PadRight(w) + "  RESULT  NOTE");
        Console.WriteLine("  " + new string('-', w) + "  ------  ----");
        foreach (var r in results) Console.WriteLine("  " + r.name.PadRight(w) + "  " + (r.ok ? "PASS  " : "FAIL  ") + "  " + r.note);
        int passed = results.Count(r => r.ok);
        Console.WriteLine();
        Console.WriteLine($"  {passed}/{results.Count} passed, {http.Requests} requests, all to {host} (emulators)");
        feed?.Dispose();
        return passed == results.Count ? 0 : 1;
    }

    static double Js_ToNum(object o) => o is double d ? d : double.NaN;
}
