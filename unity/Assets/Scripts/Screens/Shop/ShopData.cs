// The Shop's tables and rules, as the app reads them (functions/squad.js through src/squad/data.js; src/screens/
// ShopChests.js chestInfo / allChests; src/economy.js prices): the tables are Resources/Shop/shop.json, written from
// the server's own file by tools/unity/export-shop.mjs, so they can't drift; the rules that pick from them (today's
// HOT groups, what a chest can drop, the Rainbow chest, copies, the gem jar) are ported here.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SquishSquad.Backend;

namespace SquishSquad.Screens
{
    public sealed class SquadCreature
    {
        public string Id, Key, Name, Set;
        public int Rar;
        public bool Reward, Pass, Base;
    }

    /// <summary>A chest size: its key, drop odds (Common, Rare, Epic, Legendary %) and price.</summary>
    public sealed class ChestSize
    {
        public string K, Cur;
        public double[] Odds;
        public double Price;
        public int I;
    }

    /// <summary>What a chest's card and sheet say (ShopChests.js chestInfo / rainbowInfo).</summary>
    public sealed class ChestInfo
    {
        public int Ti;
        public ChestSize T;
        public List<SquadCreature> Pool;
        public int Have;
        public string Name, Odds, DupeCoins, UpNote;
        public string[] LookBg; public string LookRim, LookInk, LookTs;
        public RainbowEarned Earned;   // an earned Rainbow chest (rainbow 'chest'), else null
    }

    public sealed class RainbowEarned
    {
        public SquadCreature Reward;
        public bool Ready, Opened;
        public int Have, Need;
    }

    public static class ShopData
    {
        static IDictionary<string, object> _j;
        static IDictionary<string, object> J
        {
            get
            {
                if (_j != null) return _j;
                var t = Roster.ReadText?.Invoke("Shop/shop") ?? throw new InvalidOperationException("Resources/Shop/shop.json is missing: run node tools/unity/export-shop.mjs");
                _j = Prof.Map(Json.Parse(t));
                Load();
                return _j;
            }
        }

        public static List<(string key, string name)> Groups;
        public static string SeasonKey;
        public static string[] Hidden, Sets;
        public static List<SquadCreature> All;
        public static Dictionary<string, SquadCreature> ById;
        public static Dictionary<string, (string[] ids, string reward)> SetOf;
        public static List<ChestSize> Sizes;
        public static Dictionary<string, double> Upgrade, DupeCoins;
        public static double[] Copies;
        public static double DealGems, DealWas, DealCoins, LuckMax, AdChests, FreeMs, StartGems;
        public static string DealSize, RainbowMode;
        public static bool SetRewards;
        public static List<(double coins, double gems)> Swaps;
        public static Dictionary<string, string[]> ChestNames;
        public static Dictionary<string, (string base_, double usd)> Products;
        public static IDictionary<string, object> DefaultOffers, Levels;

        static void Load()
        {
            var j = _j;
            Groups = Prof.List(j["groups"]).Select(Prof.Map).Select(m => ((string)m["key"], (string)m["name"])).ToList();
            SeasonKey = (string)Prof.Map(j["season"])["key"];
            Hidden = Prof.List(j["hidden"]).Select(x => (string)x).ToArray();
            Sets = Prof.List(j["sets"]).Select(x => (string)x).ToArray();
            All = Prof.List(j["roster"]).Select(Prof.Map).Select(m => new SquadCreature
            {
                Id = (string)m["id"], Key = (string)m["key"], Name = (string)m["name"], Set = (string)m["set"], Rar = (int)Prof.Num(m["rar"]),
                Reward = Prof.Truthy(m["reward"]), Pass = Prof.Truthy(m["pass"]), Base = Prof.Truthy(m["base"]),
            }).ToList();
            ById = All.ToDictionary(c => c.Id);
            SetOf = Prof.Map(j["setOf"]).ToDictionary(kv => kv.Key, kv => { var m = Prof.Map(kv.Value); return (Prof.List(m["ids"]).Select(x => (string)x).ToArray(), Prof.Str(Prof.Get(m, "reward"))); });
            int si = 0;
            Sizes = Prof.List(j["sizes"]).Select(Prof.Map).Select(m => { var p = Prof.Map(m["price"]); return new ChestSize { K = (string)m["k"], Odds = m.ContainsKey("odds") ? Prof.List(m["odds"]).Select(Prof.D).ToArray() : null, Cur = (string)p["cur"], Price = Prof.Num(p["n"]), I = si++ }; }).ToList();
            Upgrade = Prof.Map(j["upgrade"]).ToDictionary(kv => kv.Key, kv => Prof.D(kv.Value));
            DupeCoins = Prof.Map(j["dupeCoins"]).ToDictionary(kv => kv.Key, kv => Prof.D(kv.Value));
            Copies = Prof.List(j["copies"]).Select(Prof.D).ToArray();
            var d = Prof.Map(j["deal"]);
            DealGems = Prof.Num(d["gems"]); DealWas = Prof.Num(d["was"]); DealCoins = Prof.Num(d["coins"]); DealSize = (string)d["size"];
            LuckMax = j.ContainsKey("luckMax") ? Prof.Num(j["luckMax"]) : 0; AdChests = Prof.Num(j["adChests"]); FreeMs = Prof.Num(j["freeMs"]);
            StartGems = Prof.Num(Prof.Map(j["start"])["gems"]);
            RainbowMode = (string)j["rainbow"]; SetRewards = Prof.Truthy(j["setRewards"]);
            Swaps = Prof.List(j["swaps"]).Select(Prof.Map).Select(m => (Prof.Num(m["coins"]), Prof.Num(m["gems"]))).ToList();
            ChestNames = Prof.Map(j["chestNames"]).ToDictionary(kv => kv.Key, kv => Prof.List(kv.Value).Select(x => (string)x).ToArray());
            Products = Prof.Map(j["products"]).ToDictionary(kv => kv.Key, kv => { var m = Prof.Map(kv.Value); return ((string)m["base"], Prof.Num(m["usd"])); });
            DefaultOffers = Prof.Map(j["offers"]);
            Levels = Prof.Map(j["levels"]);
        }

        public static void Ensure() { var _ = J; }

        // ---- names ----------------------------------------------------------------------------------------------------
        public static readonly string[] SIZE_NAME = { "Common", "Rare", "Epic", "Legendary", "Rainbow" };
        public static readonly string[] SIZE_KEYS = { "common", "rare", "epic", "legendary", "set" };
        public static int SizeI(string k) => Array.IndexOf(SIZE_KEYS, k);
        public static readonly Dictionary<string, string> GROUP_LABEL = new Dictionary<string, string>
        {
            ["snack"] = "Snack Shack", ["fruit"] = "Fruit Patch", ["ocean"] = "Ocean Pals", ["pet"] = "Pet Shop", ["forest"] = "Forest Friends", ["sky"] = "Sky & Stars",
            ["dream"] = "Dreamland", ["bakery"] = "Sweet Bakery", ["heroes"] = "Masked Heroes", ["elemental"] = "Elemental Heroes", ["spooky"] = "Spooky Squish",
        };
        public static string GroupName(string k) { Ensure(); foreach (var g in Groups) if (g.key == k) return g.name; return k; }
        public static string ChestName(string gk, int ti) { Ensure(); return ChestNames.TryGetValue(gk, out var n) && ti < n.Length ? n[ti] : SIZE_NAME[ti] + " chest"; }

        // ---- the roster ---------------------------------------------------------------------------------------------------
        public static bool IsOut(SquadCreature c, string[] hidden) => !hidden.Contains(c.Set) && !hidden.Contains(c.Id);
        public static bool GroupOut(string k, string[] hidden) { Ensure(); return All.Any(c => c.Set == k && !c.Reward && !c.Pass && IsOut(c, hidden)); }
        /// <summary>outIds over the whole roster (every creature has its picture in Unity).</summary>
        public static List<string> ArtIds(string[] hidden) { Ensure(); return All.Where(c => IsOut(c, hidden)).Select(c => c.Id).ToList(); }
        public static int DropRar(SquadCreature c) => c.Reward || c.Rar > 3 ? 3 : c.Rar;
        public static bool InGroupChest(SquadCreature c, string k, bool setRewards, string rainbow) => c.Set == k && !c.Pass && (!c.Reward || (!setRewards && rainbow != "chest"));
        public static double CopiesHad(IDictionary<string, object> p, string id) => Prof.Num(Prof.Get(Prof.Map(Prof.Get(p, "copies")), id));
        // (no Rainbow count since 2026-11-17: a Rainbow creature takes Legendary's)
        public static double NeedOf(SquadCreature c) { Ensure(); return c == null ? 1 : Copies[Math.Min(c.Rar, Copies.Length - 1)]; }
        /// <summary>functions/squad.js chestPool: what a chest of group `k` holds, only its own rarity (2026-11-18).</summary>
        public static List<SquadCreature> ChestPool(string k, string size, List<string> artIds, bool setRewards = false, string rainbow = "chest") { Ensure(); int r = SizeI(size); return All.Where(c => c.Rar == r && InGroupChest(c, k, setRewards, rainbow) && artIds.Contains(c.Id)).ToList(); }
        /// <summary>ShopChests.js groupCollected: how many of a group's chest creatures, of every rarity, are owned.</summary>
        public static (int have, int total) GroupCollected(string k, IDictionary<string, object> p, List<string> artIds, bool setRewards = false, string rainbow = "chest") { Ensure(); var all = All.Where(c => InGroupChest(c, k, setRewards, rainbow) && artIds.Contains(c.Id)).ToList(); return (all.Count(c => Prof.Owns(p, c.Id)), all.Count); }

        // ---- money ------------------------------------------------------------------------------------------------------
        /// <summary>squad/data.js wallet: gems before the first squad move are the starting ones.</summary>
        public static (double coins, double gems) Wallet(IDictionary<string, object> p)
        {
            Ensure();
            var g = Prof.Get(p, "gems");
            return (Prof.Num(Prof.Get(p, "coins")), g == null ? StartGems : Prof.Num(g));
        }

        /// <summary>economy.js fallbackPriceLabel: "$0.99" (the price set for the product, until the store's loads).</summary>
        public static string FallbackPrice(string key, IDictionary<string, object> offers = null)
        {
            Ensure();
            double usd = -1;
            if (key.StartsWith("offer:"))
            {
                var id = key.Substring(6);
                foreach (var o in OfferList(offers)) if (Prof.Str(Prof.Get(o, "id")) == id && Prof.IsNum(Prof.Get(o, "usd"))) usd = Prof.D(Prof.Get(o, "usd"));
            }
            else if (Products.TryGetValue(key, out var p)) usd = p.usd;
            if (usd < 0) return "";
            return "$" + (Math.Round(usd * 100) / 100).ToString("0.00", CultureInfo.InvariantCulture);
        }

        /// <summary>economy.js productKey for a gem pack's product ("gems_450" → "gems450").</summary>
        public static string ProductKey(string product)
        {
            Ensure();
            foreach (var kv in Products) if (kv.Value.base_ == product) return kv.Key;
            return null;
        }

        // ---- today's chests --------------------------------------------------------------------------------------------
        static double DayNumber(string day) => Math.Floor((DateTime.ParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture) - new DateTime(1970, 1, 1)).TotalDays);

        /// <summary>Today's three HOT groups (squad.js lineup): [0] the free chest and the deal, [1] the ad chest, [2] the streak's.</summary>
        public static List<string> Lineup(string day, string[] hidden = null)
        {
            Ensure();
            hidden ??= Hidden;
            double d = DayNumber(day);
            var keys = Groups.Select(g => g.key).Where(k => k != SeasonKey).ToList();
            double seed = ((d % 233280) * 9301 + 49297) % 233280;
            double Rnd() => (seed = (seed * 9301 + 49297) % 233280) / 233280;
            for (int i = keys.Count - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(Rnd() * (i + 1));
                (keys[i], keys[j]) = (keys[j], keys[i]);
            }
            return keys.Where(k => GroupOut(k, hidden)).Take(3).ToList();
        }

        public sealed class GroupPageInfo { public string K, Tag; public string[] TagBg; }

        /// <summary>ShopChests.js allChests: the three HOT groups, the season, the rest.</summary>
        public static List<GroupPageInfo> AllChests(string day, string[] hidden)
        {
            var hot = Lineup(day, hidden);
            var l = hot.Select(k => new GroupPageInfo { K = k, Tag = "HOT TODAY", TagBg = new[] { "#ff3d6e", "#ff7a3d" } }).ToList();
            l.Add(new GroupPageInfo { K = SeasonKey, Tag = "SEASON", TagBg = new[] { "#ff8a1e", "#b03a00" } });
            foreach (var g in Groups) if (g.key != SeasonKey && !hot.Contains(g.key) && GroupOut(g.key, hidden)) l.Add(new GroupPageInfo { K = g.key, Tag = "" });
            return l;
        }

        static readonly string[] GOLD_BG = { "#fff3b0", "#ffd83a", "#ffb000" }, PURPLE_BG = { "#f3d2ff", "#b65cff", "#6a22d6" }, GREY_BG = { "#f7f3fc", "#ece6f6", "#e2d8f0" }, GREEN_BG = { "#d8ffc2", "#6fe07a", "#26a94e" };

        public static (int have, int need, string reward) RainbowProgress(IDictionary<string, object> p, string k, List<string> artIds)
        {
            Ensure();
            if (!SetOf.TryGetValue(k, out var s)) return (0, 0, null);
            var ids = s.ids.Where(artIds.Contains).ToList();
            return (ids.Count(id => Prof.Owns(p, id)), ids.Count, s.reward);
        }

        public static bool RainbowReady(IDictionary<string, object> p, string k, List<string> artIds)
        {
            var r = RainbowProgress(p, k, artIds);
            return r.reward != null && artIds.Contains(r.reward) && !Prof.Owns(p, r.reward) && r.need > 0 && r.have == r.need;
        }

        public static ChestInfo Chest(string gk, string size, IDictionary<string, object> profile, List<string> artIds, bool setRewards = false, string rainbow = "chest")
        {
            Ensure();
            if (size == "set" && rainbow == "chest")
            {
                var r = RainbowProgress(profile, gk, artIds);
                var reward = r.reward != null && artIds.Contains(r.reward) ? ById[r.reward] : null;
                bool opened = reward != null && Prof.Owns(profile, reward.Id), ready = RainbowReady(profile, gk, artIds);
                return new ChestInfo
                {
                    Ti = 4, T = Sizes[4], Have = r.have,
                    Pool = (SetOf.TryGetValue(gk, out var so) ? so.ids : new string[0]).Where(artIds.Contains).Select(id => ById[id]).ToList(),
                    Name = ChestName(gk, 4), LookBg = ready ? GREEN_BG : GREY_BG, LookRim = ready ? "#17652f" : "#b8a8d4", LookInk = ready ? "#ffffff" : "#8a78b0", LookTs = ready ? "#17652f" : null,
                    Odds = reward != null ? $"{reward.Name} 100%" : "", DupeCoins = "", UpNote = "",
                    Earned = new RainbowEarned { Reward = reward, Ready = ready, Opened = opened, Have = r.have, Need = r.need },
                };
            }
            int ti = SizeI(size);
            var T = Sizes[ti];
            var pool = ChestPool(gk, size, artIds, setRewards, rainbow);   // (only this chest's own rarity)
            bool coins = T.Cur == "coins";
            return new ChestInfo
            {
                Ti = ti, T = T, Pool = pool, Have = pool.Count(c => Prof.Owns(profile, c.Id)),
                Name = ChestName(gk, ti),
                LookBg = coins ? GOLD_BG : PURPLE_BG, LookRim = coins ? "#b86200" : "#45189a", LookInk = coins ? "#7a3d00" : "#ffffff", LookTs = coins ? null : "#45189a",
                Odds = $"Only {SIZE_NAME[ti]} pals",
                DupeCoins = "+" + Prof.Fmt(DupeCoins[size]),
                UpNote = ti <= 1 ? $"{Prof.JsStr(Upgrade[size])}% chance it upgrades on your first smash" : "",
            };
        }

        public static readonly string[] GREY_LOOK_BG = GREY_BG;

        // ---- the offers ----------------------------------------------------------------------------------------------------
        /// <summary>squad.js offersOf: config/offers' lists, the design's where missing.</summary>
        public static List<IDictionary<string, object>> OfferList(IDictionary<string, object> cfg)
        {
            Ensure();
            var l = Prof.List(Prof.Get(cfg, "offers"));
            if (l != null) return l.Select(Prof.Map).Where(o => o != null && Prof.Truthy(Prof.Get(o, "id")) && Prof.Truthy(Prof.Get(o, "kind"))).ToList();
            return Prof.List(DefaultOffers["offers"]).Select(Prof.Map).ToList();
        }

        public static List<IDictionary<string, object>> Packs(IDictionary<string, object> cfg)
        {
            Ensure();
            var l = Prof.List(Prof.Get(cfg, "packs"));
            if (l != null) return l.Select(Prof.Map).Where(o => o != null && Prof.Truthy(Prof.Get(o, "product")) && Prof.Num(Prof.Get(o, "gems")) > 0).ToList();
            return Prof.List(DefaultOffers["packs"]).Select(Prof.Map).ToList();
        }

        public static IDictionary<string, object> Pass(IDictionary<string, object> cfg)
        {
            Ensure();
            var p = Prof.Map(Prof.Get(cfg, "pass"));
            return p != null && Prof.List(Prof.Get(p, "nodes")) != null ? p : Prof.Map(DefaultOffers["pass"]);
        }

        public static List<IDictionary<string, object>> Streak(IDictionary<string, object> cfg)
        {
            Ensure();
            var l = Prof.List(Prof.Get(cfg, "streak"));
            return (l != null && l.Count > 0 ? l : Prof.List(DefaultOffers["streak"])).Select(Prof.Map).ToList();
        }

        /// <summary>The gem jar: one gem per `per` coins earned since it was last broken.</summary>
        public static double JarGems(IDictionary<string, object> p, IDictionary<string, object> jar)
        {
            if (jar == null) return 0;
            double max = Prof.Num(Prof.Get(jar, "max")); if (max == 0) max = 1500;
            double per = Prof.Num(Prof.Get(jar, "per")); if (per == 0) per = 25;
            return Math.Max(0, Math.Min(max, Math.Floor((Prof.Num(Prof.Get(p, "totalEarned")) - Prof.Num(Prof.Get(p, "jarBase"))) / per)));
        }

        /// <summary>A chest of `size` as it's given (squad.js givenSize; data.js shownSize).</summary>
        public static string ShownSize(string t) { Ensure(); return t == "set" && RainbowMode == "chest" ? "legendary" : t; }

        // ---- time ----------------------------------------------------------------------------------------------------------
        /// <summary>squad/ui.js hms: "05:12:30".</summary>
        public static string Hms(double ms)
        {
            long sec = (long)Math.Max(0, Math.Floor(ms / 1000));
            return $"{sec / 3600:00}:{sec / 60 % 60:00}:{sec % 60:00}";
        }

        /// <summary>Milliseconds to the player's next midnight.</summary>
        public static double UntilMidnight(DateTime now) => (now.Date.AddDays(1) - now).TotalMilliseconds;
    }
}
