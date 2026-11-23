// The Unity views for shots.json's shots: Preview.js's "shop-…" screens and "road", the chest smash's page, the vault.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Screens;

static partial class Program
{
    static IScreenView Make(IDictionary<string, object> shot, Ticker t)
    {
        string preview = (string)(Prof.Get(shot, "preview") ?? Prof.Get(shot, "page"));
        var profile = Prof.Map(Prof.Get(shot, "profile"));
        Func<DateTime> now = () => T0.AddMilliseconds(t.Now);
        if (preview.StartsWith("shop-"))
        {
            var parts = preview.Split('-');
            var v = new ShopView(profile, null, parts[1], W, H, t, now);
            // Preview.js's "server": answers after 600 ms with its fixed roll
            v.OnSquad = (move, args) =>
            {
                var tcs = new TaskCompletionSource<IDictionary<string, object>>();
                t.SetTimeout(() => tcs.SetResult(FakeSquad(move, args, now())), 600);
                return tcs.Task;
            };
            return v;
        }
        return MoreViews(shot, preview, profile, t, now);
    }

    /// <summary>src/web/Preview.js fakeSquad.</summary>
    public static IDictionary<string, object> FakeSquad(string move, IDictionary<string, object> args, DateTime now)
    {
        var hot = ShopData.Lineup(Prof.DayKey(now));
        IDictionary<string, object> Pick(string group, string size)
        {
            SquadCreature c = ShopData.ById["1"];
            foreach (var x in ShopData.All) if (x.Set == group && !x.Reward && !x.Pass) { c = x; break; }
            return new Dictionary<string, object> { ["group"] = group, ["size"] = size, ["final"] = size, ["upgraded"] = false, ["id"] = c.Id, ["rar"] = (double)c.Rar, ["isNew"] = false, ["copies"] = 3.0, ["need"] = 5.0, ["coins"] = 0.0, ["dupeCoins"] = 0.0, ["setBonus"] = 0.0, ["luck"] = false };
        }
        switch (move)
        {
            case "groupChest": return Pick((string)args["group"], (string)args["size"]);
            case "freeChest": return Pick(hot[0], "common");
            case "adChest": return Pick(hot[1], "rare");
            case "dealChest": return Pick(hot[0], "legendary");
            case "rainbowChest": return Pick((string)args["group"], "set");
            case "streakClaim": return new Dictionary<string, object> { ["kind"] = "coins", ["n"] = 500.0, ["day"] = 3.0 };
            case "passClaim": return new Dictionary<string, object> { ["kind"] = "gems", ["n"] = 80.0, ["i"] = args["i"] };
            case "swap": return new Dictionary<string, object> { ["coins"] = new[] { 2000.0, 9000, 25000 }[(int)Prof.Num(args["i"])] };
            case "levelClaim": return new Dictionary<string, object> { ["kind"] = "coins", ["n"] = 500.0, ["lv"] = args["i"] };
        }
        return new Dictionary<string, object> { ["error"] = "unknown_move" };
    }
}
