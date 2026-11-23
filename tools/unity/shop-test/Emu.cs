// The `squad` moves the Shop, the chest opening and the Level Road call, against the Firebase Local Emulator Suite
// (tools/unity/backend/start-emulators.sh: auth 9099, firestore 8080, functions 5001, project demo-squish), through the
// Unity Backend client (ShopWrites.Squad). Every request goes through LocalOnly, which refuses anything but
// 127.0.0.1 / localhost: this can never reach the live project. The wallet is set with testWallet (a tester claim set
// on the emulator's account), as the server writes coins and gems itself.
//   groupChest (paid in coins / gems, the roll from the group, the pull counted), not enough gems, freeChest (and its
//   timer), adChest (three a day), dealChest (once a day), swap, streakClaim (once a day), passClaim (the default
//   season is over), rainbowChest (locked), levelClaim / levelClaimAll; and ShopView / RoadView / ChestOpening driven
//   by those answers (the buy button → the server's chest in the smash → COLLECT → the toast; CLAIM ALL).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Screens;

static class Emu
{
    sealed class LocalOnly : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(60));
        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http") throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            return inner.Send(r, cancel);
        }
    }

    static int pass, fail;
    static void Check(bool ok, string what) { if (ok) pass++; else fail++; Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {what}"); }
    static double N(IDictionary<string, object> p, string path) => Prof.Num(Prof.At(p, path));
    static string IdOf(IDictionary<string, object> r) { var v = Prof.Get(r, "id"); return v == null ? "" : Prof.IsNum(v) ? Prof.JsStr(Prof.D(v)) : v.ToString(); }

    static async Task<string> Err(Func<Task> f)
    {
        try { await f(); return null; } catch (SquadError e) { return e.Message; } catch (Exception e) { return "other: " + e.Message; }
    }

    public static async Task<int> Run()
    {
        SynchronizationContext.SetSynchronizationContext(null);
        ShopData.Ensure();
        var http = new LocalOnly();
        var fb = new FirebaseClient(FirebaseConfig.Emulator("demo-squish", "127.0.0.1"), new MemoryAuthStore(), http);
        await fb.Auth.Start();
        string run = DateTime.UtcNow.Ticks.ToString("x");
        var user = await fb.Auth.RegisterWithEmail($"unity-shop-{run}@example.com", "secret12");
        string uid = user.Uid;
        await fb.Data.CreateUserProfile(uid, $"unity-shop-{run}@example.com", 14, "Mia");
        var data = fb.Data;
        var now = DateTime.Now;
        string today = Prof.DayKey(now);
        Task<IDictionary<string, object>> Squad(string move, Dictionary<string, object> args = null) => ShopWrites.Squad(fb.Functions, move, args ?? new Dictionary<string, object>(), DateTime.Now);
        // a tester, so testWallet sets the wallet
        await http.Send(new HttpRequest
        {
            Method = "POST",
            Url = "http://127.0.0.1:9099/identitytoolkit.googleapis.com/v1/projects/demo-squish/accounts:update",
            Headers = { ["Authorization"] = "Bearer owner" },
            Body = Json.Write(new Dictionary<string, object> { ["localId"] = uid, ["customAttributes"] = "{\"tester\":true}" }),
        });
        await fb.Auth.GetIdToken(true);
        await ScreenWrites.TestWallet(fb.Functions, new Dictionary<string, object> { ["coins"] = 5000.0, ["gems"] = 700.0, ["level"] = 5.0 }, now);
        var p = await data.GetProfile(uid);
        Check(N(p, "coins") == 5000 && N(p, "gems") == 700, $"testWallet: coins {N(p, "coins")}, gems {N(p, "gems")}, pxp {N(p, "pxp")}");

        // the creatures' catalog (the server rolls only creatures with art: the `creatures` collection), seeded as the
        // emulator's owner (Bearer owner bypasses the rules)
        var writes = ShopData.All.Select(c => (object)new Dictionary<string, object> { ["update"] = new Dictionary<string, object> { ["name"] = $"projects/demo-squish/databases/(default)/documents/creatures/{c.Id}", ["fields"] = new Dictionary<string, object> { ["name"] = new Dictionary<string, object> { ["stringValue"] = c.Name } } } }).ToList();
        var seeded = await http.Send(new HttpRequest { Method = "POST", Url = "http://127.0.0.1:8080/v1/projects/demo-squish/databases/(default)/documents:commit", Headers = { ["Authorization"] = "Bearer owner" }, Body = Json.Write(new Dictionary<string, object> { ["writes"] = writes }) });
        Check(seeded.Ok, $"the catalog: {writes.Count} creatures seeded");
        Console.WriteLine("chests:");
        var hot = ShopData.Lineup(today);
        // the free chest first: a new player's is the welcome chest (Mittens, whole)
        var free = await Squad("freeChest");
        p = await data.GetProfile(uid);
        Check(Prof.Str(free["group"]) == ShopData.ById["1"].Set && Prof.Str(Prof.Get(free, "id")) == "1" && Prof.Owns(p, "1"), $"freeChest (welcome): {free["group"]} {free["size"]}, {Prof.Get(free, "id")}, Mittens owned");
        Check(N(p, "freeAt") > DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 3.9 * 3600e3, "the free chest's timer: 4 hours");
        Check(await Err(() => Squad("freeChest")) == "not_yet", "a second free chest: not_yet");
        double coins = N(p, "coins"), gems = N(p, "gems");
        var g1 = await Squad("groupChest", new Dictionary<string, object> { ["group"] = hot[0], ["size"] = "common" });
        p = await data.GetProfile(uid);
        Console.WriteLine("    (groupChest answered: " + Json.Write(g1) + ")");
        var c1 = ShopData.ById[IdOf(g1)];
        Check(Prof.Str(g1["group"]) == hot[0] && Prof.Str(g1["size"]) == "common" && c1.Set == hot[0] && N(p, "coins") == coins - 300, $"groupChest {hot[0]} common: {c1.Name} (rar {c1.Rar}), coins {coins} → {N(p, "coins")}");
        Check(N(p, "chestOpens") == 2 && N(p, "passXp") > 0, $"the pull counted: chestOpens {N(p, "chestOpens")}, passXp {N(p, "passXp")}");
        Check(Prof.IsNum(Prof.Get(g1, "copies")) || Prof.Truthy(Prof.Get(g1, "isNew")) || Prof.IsNum(Prof.Get(g1, "dupeCoins")), $"the roll says copies / new / duplicate: copies {Prof.Get(g1, "copies")}, need {Prof.Get(g1, "need")}, isNew {Prof.Get(g1, "isNew")}");
        var g2 = await Squad("groupChest", new Dictionary<string, object> { ["group"] = hot[1], ["size"] = "epic" });
        p = await data.GetProfile(uid);
        Check(Prof.Str(g2["size"]) == "epic" && N(p, "gems") == gems - 120, $"groupChest {hot[1]} epic: gems {gems} → {N(p, "gems")}");
        Check(await Err(() => Squad("groupChest", new Dictionary<string, object> { ["group"] = hot[0], ["size"] = "set" })) == "unknown_chest", "a Rainbow chest isn't sold: unknown_chest");
        await ScreenWrites.TestWallet(fb.Functions, new Dictionary<string, object> { ["gems"] = 100.0 }, now);
        Check(await Err(() => Squad("groupChest", new Dictionary<string, object> { ["group"] = hot[0], ["size"] = "legendary" })) == "not_enough_gems", "Legendary with 100 gems: not_enough_gems");
        Check(await Err(() => Squad("dealChest")) == "not_enough_gems", "the deal with 100 gems: not_enough_gems");
        await ScreenWrites.TestWallet(fb.Functions, new Dictionary<string, object> { ["gems"] = 700.0, ["coins"] = 1000.0 }, now);
        var deal = await Squad("dealChest");
        p = await data.GetProfile(uid);
        Check(Prof.Str(deal["group"]) == hot[0] && Prof.Str(deal["size"]) == "legendary" && N(p, "gems") == 380 && N(p, "coins") >= 3000 && Prof.Str(Prof.Get(p, "dealDay")) == today, $"dealChest: {deal["group"]} legendary, gems 380 ({N(p, "gems")}), +2,000 coins ({N(p, "coins")}), dealDay {Prof.Get(p, "dealDay")}");
        Check(await Err(() => Squad("dealChest")) == "deal_used", "the deal again: deal_used");
        for (int i = 0; i < 3; i++)
        {
            var a = await Squad("adChest");
            Check(Prof.Str(a["group"]) == hot[1] && Prof.Str(a["size"]) == "rare", $"adChest {i + 1}: {a["group"]} rare");
        }
        Check(await Err(() => Squad("adChest")) == "no_videos_left", "a fourth ad chest: no_videos_left");
        var rbGroup = ShopData.Groups.Select(x => x.key).First(k => ShopData.SetOf.TryGetValue(k, out var so) && so.reward != null);
        Check(await Err(() => Squad("rainbowChest", new Dictionary<string, object> { ["group"] = rbGroup })) == "rainbow_locked", $"{rbGroup}'s Rainbow chest before the group's unlocked: rainbow_locked");

        Console.WriteLine("deals:");
        p = await data.GetProfile(uid);
        coins = N(p, "coins"); gems = N(p, "gems");
        var sw = await Squad("swap", new Dictionary<string, object> { ["i"] = 0.0 });
        p = await data.GetProfile(uid);
        Check(N(sw, "coins") == 2000 && N(p, "coins") == coins + 2000 && N(p, "gems") == gems - 50, $"swap 0: +2,000 coins for 50 gems ({N(p, "coins")}, {N(p, "gems")})");
        var st = await Squad("streakClaim");
        p = await data.GetProfile(uid);
        var day1 = ShopData.Streak(null)[0];
        Check(Prof.Str(st["kind"]) == Prof.Str(day1["k"]) && N(st, "n") == Prof.Num(day1["n"]) && N(p, "shopStreak.count") == 1 && Prof.Str(Prof.At(p, "shopStreak.last")) == today, $"streakClaim: day {Prof.Get(st, "day")}, {st["kind"]} {Prof.Get(st, "n")}, shopStreak {N(p, "shopStreak.count")}");
        Check(await Err(() => Squad("streakClaim")) == "claimed", "the streak again today: claimed");
        Check(await Err(() => Squad("passClaim", new Dictionary<string, object> { ["i"] = 0.0 })) == "season_over", "passClaim on the default pass (ended 2026-10-31): season_over");

        Console.WriteLine("the level road:");
        p = await data.GetProfile(uid);
        coins = N(p, "coins");
        var road = Prof.List(ShopData.Levels["road"]).Select(Prof.Map).ToList();
        var l1 = await Squad("levelClaim", new Dictionary<string, object> { ["i"] = 1.0 });
        p = await data.GetProfile(uid);
        Check(Prof.Str(l1["kind"]) == "coins" && N(l1, "n") == Prof.Num(road[0]["n"]) && N(p, "coins") == coins + N(l1, "n") && Prof.Truthy(Prof.At(p, "levelGot.1")), $"levelClaim 1: {l1["kind"]} {Prof.Get(l1, "n")}, coins {N(p, "coins")}");
        Check(await Err(() => Squad("levelClaim", new Dictionary<string, object> { ["i"] = 1.0 })) == "claimed", "level 1 again: claimed");
        Check(await Err(() => Squad("levelClaim", new Dictionary<string, object> { ["i"] = 9.0 })) == "need_level", "level 9 at level 5: need_level");
        // RoadView's CLAIM ALL: levels 2-5 in one call; the chest prize (level 3) opens in the smash
        var t = new Ticker(0);
        Ticker.Default = t;
        var rv = new RoadView(p, 832, 384, t, () => DateTime.Now) { OnSquad = (m, a) => Squad(m, a) };
        ChestRequest opened = null;
        rv.OnOpenChest = r => opened = r;
        rv.Claim(new List<int> { 2, 3, 4, 5 });
        for (int i = 0; i < 100 && opened == null; i++) await Task.Delay(100);
        p = await data.GetProfile(uid);
        Check(Enumerable.Range(1, 5).All(lv => Prof.Truthy(Prof.At(p, "levelGot." + lv))), "levelClaimAll: levels 1-5 claimed");
        Check(opened != null && opened.Rolled != null && opened.Rolled.Count == 1 && Prof.Str(opened.Rolled[0]["size"]) == "common", $"level 3's Common chest handed to the smash ({opened?.Rolled?[0]["group"]})");
        Check(await Err(() => Squad("levelClaimAll")) == "nothing_to_claim", "CLAIM ALL again: nothing_to_claim");

        Console.WriteLine("the Shop's screens on the server's answers:");
        await ScreenWrites.TestWallet(fb.Functions, new Dictionary<string, object> { ["coins"] = 5000.0 }, now);
        p = await data.GetProfile(uid);
        var sv = new ShopView(p, null, "chests", 832, 384, t, () => DateTime.Now) { OnSquad = (m, a) => Squad(m, a) };
        ChestRequest req = null;
        sv.OnOpenChest = r => req = r;
        for (double ms = 16; ms <= 100; ms += 16) t.Tick(ms);
        sv.Pieces();
        // OPEN on the first page's Common card (its button: the Stage's units × K)
        float K = 384f / 393f, sw2 = 832 / K, cx = (sw2 - 676) / 2 + 10 + 70, cy = 147 + 163 + 19;
        sv.Down(cx * K, cy * K); sv.Up(cx * K, cy * K);
        Check(req != null && req.Group == ShopData.AllChests(today, ShopData.Hidden)[0].K && req.Size == "common", $"OPEN · 300: the smash comes up on {req?.Group} {req?.Size}");
        var res = req != null ? await req.Result : null;
        Check(res != null && Prof.Str(res["group"]) == req.Group, $"its answer: {res?["group"]} {res?["size"]}, {(res != null ? ShopData.ById[IdOf(res)].Name : "")}");
        var op = new ChestOpening(new ChestRequest { Group = res?["group"] as string, Size = res?["size"] as string, Rolled = new List<IDictionary<string, object>> { res } }, 832, 384, t, "mittens", new XorShift().Next);
        IDictionary<string, object> collected = null;
        op.OnCollected = r => { collected = r; sv.Collected(r); };
        // smash it: taps on the chest until it opens, then COLLECT once the reveal is in
        double now2 = 100;
        for (int i = 0; i < 900 && collected == null; i++)
        {
            now2 += 16; t.Tick(now2);
            op.Pieces();
            if (i > 140 && i % 12 == 0) { op.Down(416, 240); op.Up(416, 240); }
            if (i % 12 == 0) { op.Down(554, 300); op.Up(554, 300); }
        }
        Check(collected == res && op.Finished, "smashed open, COLLECT: the opening ends");
        Check(sv.ToastText != null && sv.ToastText.StartsWith(ShopData.ById[IdOf(res)].Name), "the toast: " + sv.ToastText);

        Console.WriteLine($"{pass} passed, {fail} failed");
        return fail == 0 ? 0 : 1;
    }
}
