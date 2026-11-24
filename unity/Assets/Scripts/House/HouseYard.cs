// The yard games' toys in the house (webgame/app/games.js, 2026-11-18, the user: "in the yard, the games, they will not
// be placable, they will be purchasable and each game that is purchased will unlock in the yard games icon on the top
// right corner"): a yard game opens once one of its toys is bought in the Backyard's catalog (owned['R:<id>'] > 0);
// a toy is bought once (any one of a game's toys unlocks it, so the others aren't for sale after it), never placed
// (not in Renovate's tray; one standing in the yard from before is taken out on load, and stays bought), and buying
// it puts a NEW badge on the YARD GAMES button until the Yard Games are opened. The house's catalog asks these as the
// page asks SquishApp.yardGameOf / yardStrip / yardNew (webgame/patches.mjs, Squad House v6).
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public static class HouseYard
    {
        // games.js YARD_ITEMS: the catalog's toys today; rows whose name matches YARD_RE count too (a new hoop or slide)
        public static readonly Dictionary<string, string[]> Items = new Dictionary<string, string[]>
        {
            ["hoop"] = new[] { "YRD-102" }, ["soccer"] = new[] { "YRD-104" }, ["hop"] = new[] { "YRD-101" }, ["tramp"] = new[] { "YRD-120", "YRD-121" },
            ["slide"] = new[] { "YRD-123", "YRD-124", "YRD-125" }, ["corn"] = new[] { "YRD-037" }, ["pong"] = new[] { "YRD-057" },
        };
        static readonly (string id, Regex re)[] Re =
        {
            ("hoop", new Regex("basketball hoop", RegexOptions.IgnoreCase)), ("soccer", new Regex("soccer goal", RegexOptions.IgnoreCase)),
            ("hop", new Regex("hopscotch", RegexOptions.IgnoreCase)), ("tramp", new Regex("trampoline", RegexOptions.IgnoreCase)),
            ("slide", new Regex(@"\bslide\b", RegexOptions.IgnoreCase)), ("corn", new Regex("cornhole", RegexOptions.IgnoreCase)),
            ("pong", new Regex("ping-?pong|table tennis", RegexOptions.IgnoreCase)),
        };
        public static readonly Dictionary<string, string> Names = new Dictionary<string, string>
        {
            ["hoop"] = "Hoop Shot", ["soccer"] = "Penalty Kick", ["hop"] = "Hopscotch", ["tramp"] = "Bounce Up", ["slide"] = "Slide & Splash", ["corn"] = "Cornhole", ["pong"] = "Ping-Pong",
        };
        static readonly Dictionary<string, string> ItemGame = new Dictionary<string, string>();
        static HouseYard() { foreach (var kv in Items) foreach (var i in kv.Value) ItemGame[i] = kv.Key; }

        /// <summary>gameKey: the yard game an item id ('R:YRD-102' or 'YRD-102') opens, or null; row (optional): its catalog
        /// row, so a new toy counts by its name.</summary>
        public static string GameKey(string id, JObj row = null)
        {
            var k = (id ?? "").StartsWith("R:") ? id.Substring(2) : id ?? "";
            if (ItemGame.TryGetValue(k, out var g)) return g;
            if (row != null && (row.Str("room") == "YRD" || row.Str("room") == "backyard"))
            {
                var nm = row.Str("name") ?? row.Str("n") ?? "";
                foreach (var (gid, re) in Re) if (re.IsMatch(nm)) return gid;
            }
            return null;
        }

        /// <summary>yardIds: a game's toys (the catalog's rows by name included).</summary>
        public static List<string> Ids(string game, HouseData d)
        {
            var ids = new List<string>(Items.TryGetValue(game, out var a) ? a : new string[0]);
            Regex re = null; foreach (var (gid, r) in Re) if (gid == game) re = r;
            if (d != null && re != null) foreach (var r in d.Rows) if (r.Str("room") == "YRD" && re.IsMatch(r.Str("name") ?? "") && !ids.Contains(r.Str("id"))) ids.Add(r.Str("id"));
            return ids;
        }

        /// <summary>yardLocked: none of the game's toys is owned.</summary>
        public static bool Locked(string game, JObj owned, HouseData d)
        {
            if (!Items.ContainsKey(game)) return false;
            foreach (var i in Ids(game, d)) if ((owned?.Num("R:" + i) ?? 0) > 0) return false;
            return true;
        }

        public sealed class Game { public string Id, Name; public bool Open; }

        /// <summary>yardGameOf: { id, name, open } for a house item that opens a yard game, else null.</summary>
        public static Game Of(string id, JObj row, JObj owned, HouseData d)
        {
            var g = GameKey(id, row); if (g == null) return null;
            return new Game { Id = g, Name = Names[g], Open = !Locked(g, owned, d) };
        }

        /// <summary>yardStrip: the rooms without the yard games' toys (one placed before this rule is taken out).</summary>
        public static void Strip(JObj rooms)
        {
            if (rooms == null) return;
            foreach (var rk in new List<string>(rooms.Keys))
                if (rooms[rk] is List<object> L) L.RemoveAll(o => o is JObj it && GameKey(it.Str("t")) != null);
        }

        /// <summary>The cheapest toy that opens a game (yardToy) and the words for buying it (yardNeedText).</summary>
        public static string NeedText(string game, HouseData d)
        {
            JObj best = null;
            foreach (var i in Ids(game, d)) { var r = d?.Row(i); if (r != null && (best == null || r.Num("cost") < best.Num("cost"))) best = r; }
            if (best == null) return "Buy it in the Backyard catalog to play";
            var c = best.Num("cost");
            return "Buy " + d.ShortName(best) + " in the Backyard catalog" + (c > 0 ? " (" + c.ToString("#,0", System.Globalization.CultureInfo.InvariantCulture) + " coins)" : "");
        }
    }
}
