// src/achievements.js computeAchievements: the 72 achievements in the app's order and words, each worked out from the
// player's profile (ownedIds, totalEarned, stats, chests, spins, the level, the streak, the Crib, the collection...).
// `creatures`: the catalog the app counts (App.js `counted`; Roster.Counted by default).
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Screens
{
    public sealed class Achievement
    {
        public string Key, Title, Desc, BadgeLabel;
        public Creature Creature;          // a creature badge (null: a label badge)
        public bool Done;
        public double ProgCur, ProgMax;    // the bar for multi-step goals not done yet (ProgMax 0: none)
        public bool HasProgress => ProgMax > 0;
    }

    public static class AchievementList
    {
        public static List<Achievement> Compute(IList<Creature> creatures, IDictionary<string, object> profile, int customCount = 0)
        {
            profile ??= new Dictionary<string, object>();
            creatures ??= Roster.Counted(profile);
            var owned = Prof.Owned(profile);
            var byId = creatures.GroupBy(c => c.Id).ToDictionary(g => g.Key, g => g.First());
            var stats = Prof.Map(Prof.Get(profile, "stats")) ?? new Dictionary<string, object>();
            var flags = Prof.Map(Prof.Get(profile, "achievements")) ?? new Dictionary<string, object>();

            double Has(string id) => owned.Contains(id) ? 1 : 0;
            string NameOf(string id, string fallback) => byId.TryGetValue(id, out var c) && c.Name != null ? c.Name : fallback;
            int total = creatures.Count > 0 ? creatures.Count : 30;
            int ownedCount = creatures.Count > 0 ? creatures.Count(c => owned.Contains(c.Id)) : owned.Count;
            List<Creature> OfTier(string tier) => creatures.Where(c => Roster.TierOf(c.Id) == tier).ToList();
            double OwnedOfTier(string tier) => OfTier(tier).Count(c => owned.Contains(c.Id));
            string FirstOfTier(string tier, string fallback) { var l = OfTier(tier); return l.Count > 0 ? l[0].Id : fallback; }
            double earned = Prof.Num(Prof.Get(profile, "totalEarned"));
            double presses = Prof.Num(Prof.Get(stats, "presses"));
            double holdS = Math.Floor(Prof.Num(Prof.Get(stats, "longestHoldMs")) / 1000);
            var pt = Prof.Map(Prof.Get(stats, "playTime"));
            double played = pt == null ? 0 : pt.Values.Count(v => Prof.Num(v) > 0);
            double ads = Math.Max(Prof.Num(Prof.Get(profile, "adsWatched")), Prof.Truthy(Prof.Get(flags, "watchAd")) ? 1 : 0);
            double boxes = Prof.Num(Prof.Get(profile, "chestOpens")) + Prof.Num(Prof.Get(profile, "boxOpens"));
            var pulls = Prof.Map(Prof.Get(profile, "tierPulls")) ?? new Dictionary<string, object>();
            double spins = Prof.Num(Prof.Get(profile, "spins"));
            double lv = Progression.Level(profile);
            double bestStreak = Math.Max(Prof.Num(Prof.Get(profile, "bestStreak")), Prof.Num(Prof.Get(profile, "streak")));
            double chests = Prof.Num(Prof.Get(profile, "chests"));
            double care = Prof.Num(Prof.Get(profile, "cribCare"));
            double buys = Prof.Num(Prof.Get(profile, "cribBuys"));
            double cribSize = Prof.Num(Prof.Get(profile, "cribSize"));
            var col = (Prof.Map(Prof.Get(profile, "col")) ?? new Dictionary<string, object>()).Values.Select(Prof.Map).Where(e => e != null).ToList();
            double Finishes(string k) => col.Count(e => Prof.Truthy(Prof.Get(Prof.Map(Prof.Get(e, "f")), k)));
            double grown = col.Count(e => Prof.Num(Prof.Get(e, "st")) >= 1);
            double bestFriends = col.Count(e => Prof.IsNum(Prof.Get(e, "st")) && Prof.Num(Prof.Get(e, "st")) == 2);
            double setsDone = Roster.Sets.Count(k => Roster.SetIds(k).All(id => Prof.Owns(profile, id)));
            double Pull(string k) => Prof.Num(Prof.Get(pulls, k));

            var list = new List<(string key, string title, string desc, string creature, string badge, double value, double max)>();
            void C(string key, string title, string desc, string creatureId, double value, double max = 1) => list.Add((key, title, desc, creatureId, null, value, max));
            void B(string key, string title, string desc, string badge, double value, double max = 1) => list.Add((key, title, desc, null, badge, value, max));

            C("unlock3", "Bun Appétit", $"Unlock {NameOf("3", "Bao")}", "3", Has("3"));
            C("unlock4", "Sweet Tooth", $"Unlock {NameOf("4", "Dunkie")}", "4", Has("4"));
            C("unlock5", "Hot & Crispy", $"Unlock {NameOf("5", "Frybo")}", "5", Has("5"));
            C("unlock6", "Waddle Squad", $"Unlock {NameOf("6", "Pip")}", "6", Has("6"));
            C("unlock7", "Stacked!", $"Unlock {NameOf("7", "Bunbun")}", "7", Has("7"));
            B("earn10k", "Pocket Change", "Earn 10,000 Squish Points", "10K", earned, 10000);
            B("earn100k", "Squish Tycoon", "Earn 100,000 Squish Points", "100K", earned, 100000);
            B("unlockAll", "Collector Supreme", $"Unlock all {total} creatures", "ALL", ownedCount, total);
            B("speedTap", "Speed Squisher", "Tap 60 times in 60 seconds", "60", Prof.Truthy(Prof.Get(flags, "speedTap")) ? 1 : 0);
            B("watchAd", "Ad Enthusiast", "Watch a video ad", "AD", ads);
            B("press1", "First Squish", "Squish any creature once", "1", presses);
            B("press10", "Warming Up", "Squish 10 times", "10", presses, 10);
            B("press50", "Squishy Fingers", "Squish 50 times", "50", presses, 50);
            B("press100", "Century Squeeze", "Squish 100 times", "100", presses, 100);
            B("press250", "Jelly Juggler", "Squish 250 times", "250", presses, 250);
            B("press500", "Squish Machine", "Squish 500 times", "500", presses, 500);
            B("press1000", "Thousand Hugs", "Squish 1,000 times", "1K", presses, 1000);
            B("press5000", "Squish Legend", "Squish 5,000 times", "5K", presses, 5000);
            B("hold3", "Big Hug", "Hold a squish for 3 seconds", "3s", holdS, 3);
            B("hold10", "Bear Hug", "Hold a squish for 10 seconds", "10s", holdS, 10);
            B("hold30", "Never Let Go", "Hold a squish for 30 seconds", "30s", holdS, 30);
            B("earn1k", "Coin Sprout", "Earn 1,000 coins in total", "1K", earned, 1000);
            B("earn50k", "Gold Rush", "Earn 50,000 coins in total", "50K", earned, 50000);
            B("earn250k", "Coin Mountain", "Earn 250,000 coins in total", "250K", earned, 250000);
            B("own5", "Squad of Five", "Own 5 creatures", "×5", ownedCount, 5);
            B("own10", "Double Digits", "Own 10 creatures", "×10", ownedCount, 10);
            B("own15", "Almost There", "Own 15 creatures", "×15", ownedCount, 15);
            C("own16", "Legend Found", "Unlock a Legendary creature", FirstOfTier("Legendary", "24"), OwnedOfTier("Legendary"));
            C("own17", "Twin Legends", "Unlock 2 Legendary creatures", FirstOfTier("Legendary", "24"), OwnedOfTier("Legendary"), 2);
            B("own18", "Over the Rainbow", "Get a Rainbow squishy", "RBW", Finishes("r"));
            B("own19", "Golden Touch", "Get a Golden squishy", "GLD", Finishes("g"));
            B("box1", "Peek Inside", "Open your first chest", "BOX", boxes);
            B("box5", "Box Fan", "Open 5 chests", "5", boxes, 5);
            B("box10", "Unboxing Pro", "Open 10 chests", "10", boxes, 10);
            B("box25", "Box Hoarder", "Open 25 chests", "25", boxes, 25);
            B("box50", "Mystery Master", "Open 50 chests", "50", boxes, 50);
            B("pullEpic", "Epic Luck", "Pull an Epic from a chest", "EPIC", Pull("Epic"));
            B("pullLegendary", "Legendary Pull", "Pull a Legendary from a chest", "LEG", Pull("Legendary"));
            B("pullRainbow", "Rainbow Pull", "Pull a Rainbow finish from a chest", "RBW", Pull("Rainbow"));
            B("pullGolden", "Pure Gold", "Pull a Golden finish from a chest", "GLD", Pull("Golden"));
            B("secret", "Set Collector", "Complete a set", "SET", setsDone);
            B("spin1", "Lucky Spin", "Spin the daily wheel", "SPIN", spins);
            B("spin7", "Week of Spins", "Spin the wheel 7 times", "7", spins, 7);
            B("jackpot", "Jackpot!", "Win the 50 gems JACKPOT on the Daily Spin", "★", Prof.Truthy(Prof.Get(profile, "wheelJackpot")) ? 1 : 0);
            B("ads5", "Movie Night", "Watch 5 video ads", "▶5", ads, 5);
            B("boost4", "Max Boost", "Activate a ×4 coin boost", "×4", Prof.Num(Prof.Get(profile, "maxMult")) >= 4 ? 1 : 0);
            B("custom1", "Creator", "Create your own squishy", "NEW", customCount);
            B("custom3", "Toy Designer", "Create 3 custom squishies", "×3", customCount, 3);
            B("play5", "Friendly Squisher", "Play with 5 different creatures", "5♥", played, 5);
            B("play10", "Best Friends", "Play with 10 different creatures", "10♥", played, 10);
            B("lv3", "Challenger", "Reach level 3 and unlock Daily Challenges", "LV3", lv, 3);
            B("lv5", "Rising Star", "Reach level 5", "LV5", lv, 5);
            B("lv10", "Squish Regular", "Reach level 10", "10", lv, 10);
            B("lv25", "Dedicated Squisher", "Reach level 25", "25", lv, 25);
            B("lv50", "Half Way There", "Reach level 50", "50", lv, 50);
            B("lv75", "Squish Veteran", "Reach level 75", "75", lv, 75);
            B("lv100", "Squish Centurion", "Reach level 100", "100", lv, 100);
            B("chest1", "Treasure Hunter", "Open your first daily chest", "CHEST", chests);
            B("chest30", "Chest Collector", "Open 30 daily chests", "×30", chests, 30);
            B("streak3", "On a Roll", "Keep a 3-day streak", "3🔥", bestStreak, 3);
            B("streak7", "Week Warrior", "Keep a 7-day streak", "7🔥", bestStreak, 7);
            B("streak10", "Half Price Hero", "Reach day 10 of a streak", "10🔥", bestStreak, 10);
            B("streak30", "Unstoppable", "Keep a 30-day streak", "30🔥", bestStreak, 30);
            B("care1", "Caretaker", "Send a friend to a bath, snack, nap or play in the Crib", "♥", care);
            B("care50", "Super Sitter", "Take care of your Crib friends 50 times", "50♥", care, 50);
            B("care250", "Crib Parent", "Take care of your Crib friends 250 times", "250", care, 250);
            B("buy1", "First Makeover", "Buy something for the Crib", "NEW", buys);
            B("buy10", "Home Decorator", "Buy 10 things for the Crib", "×10", buys, 10);
            B("buy30", "Dream House", "Buy 30 things for the Crib", "×30", buys, 30);
            B("crib10", "Full House", "Have 10 friends living in the Crib", "10", cribSize, 10);
            B("double1", "Growing Up", "Grow a squishy to Grown", "UP", grown);
            B("double25", "Best Friends", "Make a squishy your Best Friend", "BFF", bestFriends);

            return list.Select(a =>
            {
                bool done = a.value >= a.max;
                return new Achievement
                {
                    Key = a.key, Title = a.title, Desc = a.desc, BadgeLabel = a.badge ?? "",
                    Creature = a.creature != null && byId.TryGetValue(a.creature, out var c) ? c : null,
                    Done = done,
                    ProgCur = !done && a.max > 1 ? Math.Min(a.max, a.value) : 0,
                    ProgMax = !done && a.max > 1 ? a.max : 0,
                };
            }).ToList();
        }
    }
}
