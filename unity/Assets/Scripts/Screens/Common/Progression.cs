// src/progression.js, the parts the streak screen and the daily challenges sheet need: today's six challenges (picked
// by the date, the same for every player), their progress from the profile's `daily`, the daily chest, the streak and
// its ten days' prizes, the time left today; and the profile updates a claim writes (claimDaily / claimChest).
// `now` is the player's local time (the JS reads the device's clock and time zone).
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Screens
{
    public sealed class StreakReward
    {
        public int Day; public string Kind; public double Amount; public string Label;
        public StreakReward(int day, string kind, double amount, string label) { Day = day; Kind = kind; Amount = amount; Label = label; }
    }

    public sealed class DailyRow
    {
        public string Id, Ev, Side, Title, Label;
        public double Prog, Goal, Pct, Reward, Xp;
        public bool Claimable, Claimed, Open;
    }

    public sealed class StreakDay { public int N; public StreakReward Reward; public bool Done, Today; }

    public sealed class DailyInfo
    {
        public string Date, ResetIn;
        public List<DailyRow> Game, Crib;
        public int Claimable, ClaimedN, Total, Streak;
        public double ChestPct, ChestReward, ChestXp;
        public bool ChestReady, ChestDone;
        public List<StreakDay> Track;
    }

    public static class Progression
    {
        public const int DAILY_LEVEL = 3;
        public const double CHEST_COINS = 250;
        public const double STREAK_BONUS = 0.05;
        public const int STREAK_DAYS = 10;
        /// <summary>config/levels `xp` (functions/squad.js levelsOf: challenge 25, chest 100 by default).</summary>
        public static double ChallengeXp = 25, ChestXp = 100;

        public static readonly StreakReward[] STREAK_REWARDS =
        {
            new StreakReward(1, "coins", 100, "100"), new StreakReward(2, "coins", 150, "150"), new StreakReward(3, "gems", 10, "+10"),
            new StreakReward(4, "coins", 250, "250"), new StreakReward(5, "chest", 0, "CHEST"), new StreakReward(6, "coins", 400, "400"),
            new StreakReward(7, "gems", 20, "+20"), new StreakReward(8, "coins", 600, "600"), new StreakReward(9, "chest", 0, "CHEST"),
            new StreakReward(10, "half", 0, "50%"),
        };
        public static StreakReward StreakRewardOf(int n) => STREAK_REWARDS[(Math.Max(1, n) - 1) % STREAK_DAYS];
        public static string StreakRewardText(StreakReward r)
        {
            if (r.Kind == "coins") return $"+{Prof.JsStr(r.Amount)} coins";
            if (r.Kind == "gems") return $"+{Prof.JsStr(r.Amount)} gems";
            if (r.Kind == "chest") return "a free chest in the Shop";
            return "half price on your next creation";
        }

        sealed class Def { public string Id, Ev; public int[] Goals; public Func<int, string> Title; public double Reward; }
        static readonly Def[] GAME =
        {
            new Def { Id = "g_squish", Ev = "squish", Goals = new[] { 50, 80, 120 }, Title = n => $"Squish {n} times", Reward = 60 },
            new Def { Id = "g_earn", Ev = "earn", Goals = new[] { 200, 300, 500 }, Title = n => $"Earn {n} coins squishing", Reward = 80 },
            new Def { Id = "g_ad", Ev = "ad", Goals = new[] { 1 }, Title = _ => "Watch 1 bonus video", Reward = 40 },
        };
        static readonly Def[] CRIB =
        {
            new Def { Id = "c_bath", Ev = "bath", Goals = new[] { 2, 3 }, Title = n => $"Give {n} friends a bath", Reward = 60 },
            new Def { Id = "c_feed", Ev = "feed", Goals = new[] { 2, 3 }, Title = n => $"Feed {n} friends a snack", Reward = 60 },
            new Def { Id = "c_sleep", Ev = "sleep", Goals = new[] { 1, 2 }, Title = n => $"Tuck {n} {(n > 1 ? "friends" : "friend")} into bed", Reward = 50 },
            new Def { Id = "c_dance", Ev = "dance", Goals = new[] { 2, 3 }, Title = n => $"Send {n} friends to dance", Reward = 50 },
            new Def { Id = "c_tv", Ev = "tv", Goals = new[] { 2 }, Title = n => $"Watch TV with {n} friends", Reward = 40 },
            new Def { Id = "c_play", Ev = "play", Goals = new[] { 2, 3 }, Title = n => $"Send {n} friends out to play", Reward = 40 },
        };
        static Def ById(string id) => GAME.Concat(CRIB).First(d => d.Id == id);

        public struct Challenge { public string Id, Ev, Side; public int Goal; }

        /// <summary>challengesFor(date): the design's seeded generator from the date.</summary>
        public static List<Challenge> ChallengesFor(string date)
        {
            double seed = 7;
            foreach (var part in date.Split('-')) seed = seed * 31 + double.Parse(part, System.Globalization.CultureInfo.InvariantCulture);
            seed %= 233280;
            double R() { seed = (seed * 9301 + 49297) % 233280; return seed / 233280; }
            var crib = CRIB.ToList();
            for (int i = crib.Count - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(R() * (i + 1));
                (crib[i], crib[j]) = (crib[j], crib[i]);
            }
            Challenge Pick(Def c, string side) => new Challenge { Id = c.Id, Ev = c.Ev, Side = side, Goal = c.Goals[(int)Math.Floor(R() * c.Goals.Length)] };
            var list = GAME.Select(c => Pick(c, "game")).ToList();
            list.AddRange(crib.Take(3).Select(c => Pick(c, "crib")).ToList());
            return list;
        }

        public sealed class DayState { public IDictionary<string, object> Prog, Claimed; public bool Chest; public string Date; }

        public static DayState DailyState(IDictionary<string, object> profile, string date)
        {
            var d = Prof.Map(Prof.Get(profile, "daily"));
            if (d != null && Prof.Str(Prof.Get(d, "date")) == date)
                return new DayState { Prog = Prof.Map(Prof.Get(d, "prog")) ?? new Dictionary<string, object>(), Claimed = Prof.Map(Prof.Get(d, "claimed")) ?? new Dictionary<string, object>(), Chest = Prof.Truthy(Prof.Get(d, "chest")), Date = date };
            return new DayState { Prog = new Dictionary<string, object>(), Claimed = new Dictionary<string, object>(), Chest = false, Date = date };
        }

        public static List<DailyRow> DailyRows(IDictionary<string, object> profile, string date)
        {
            var s = DailyState(profile, date);
            return ChallengesFor(date).Select(c =>
            {
                var def = ById(c.Id);
                double prog = Math.Min(c.Goal, Prof.Num(Prof.Get(s.Prog, c.Ev)) is double v && v != 0 ? v : 0);
                bool claimed = Prof.Truthy(Prof.Get(s.Claimed, c.Id));
                bool full = prog >= c.Goal;
                return new DailyRow
                {
                    Id = c.Id, Ev = c.Ev, Side = c.Side, Title = def.Title(c.Goal), Prog = prog, Goal = c.Goal,
                    Pct = Prof.JsRound(prog / c.Goal * 100), Label = $"{Prof.JsStr(prog)} / {c.Goal}", Reward = def.Reward, Xp = ChallengeXp,
                    Claimable = full && !claimed, Claimed = claimed, Open = !full,
                };
            }).ToList();
        }

        public static DailyInfo View(IDictionary<string, object> profile, DateTime now)
        {
            string date = Prof.DayKey(now);
            var s = DailyState(profile, date);
            var rows = DailyRows(profile, date);
            int claimedN = rows.Count(r => r.Claimed);
            var midnight = now.Date.AddDays(1);
            double mins = Math.Max(0, Prof.JsRound((midnight - now).TotalMilliseconds / 60000));
            return new DailyInfo
            {
                Date = date,
                Game = rows.Where(r => r.Side == "game").ToList(),
                Crib = rows.Where(r => r.Side == "crib").ToList(),
                Claimable = rows.Count(r => r.Claimable),
                ClaimedN = claimedN,
                Total = rows.Count,
                ChestPct = Prof.JsRound((double)claimedN / rows.Count * 100),
                ChestReady = claimedN == rows.Count && !s.Chest,
                ChestDone = s.Chest,
                ChestReward = CHEST_COINS,
                ChestXp = ChestXp,
                ResetIn = $"{Math.Floor(mins / 60)}h {mins % 60}m",
                Streak = StreakOf(profile, now),
                Track = StreakTrack(profile, now),
            };
        }

        public static List<StreakDay> StreakTrack(IDictionary<string, object> profile, DateTime now)
        {
            int streak = StreakOf(profile, now);
            bool openedToday = Prof.Str(Prof.Get(profile, "lastFull")) == Prof.DayKey(now) && streak > 0;
            int todayN = openedToday ? streak : streak + 1;
            int first = (todayN - 1) / STREAK_DAYS * STREAK_DAYS + 1;
            var l = new List<StreakDay>();
            for (int i = 0; i < STREAK_DAYS; i++)
            {
                int n = first + i;
                l.Add(new StreakDay { N = n, Reward = StreakRewardOf(n), Done = n < todayN || (n == todayN && openedToday), Today = n == todayN });
            }
            return l;
        }

        public static int StreakOf(IDictionary<string, object> profile, DateTime now)
        {
            string today = Prof.DayKey(now);
            string last = Prof.Str(Prof.Get(profile, "lastFull"));
            return !string.IsNullOrEmpty(last) && (last == today || last == Prof.DayBefore(today)) ? (int)Math.Max(0, Math.Floor(Prof.Num(Prof.Get(profile, "streak")))) : 0;
        }

        public static int Level(IDictionary<string, object> profile) => Games.Sort.PlayerXp.PlayerLevel(Games.Sort.PlayerXp.PxpOf(profile)).Level;

        // ---- the updates a claim writes (merge-style: the whole `daily` map) -----------------------------------------
        public sealed class Claim { public double Coins, Xp; public Dictionary<string, object> Update; public StreakReward Reward; }

        static Dictionary<string, object> Copy(IDictionary<string, object> m) => m == null ? new Dictionary<string, object>() : new Dictionary<string, object>(m);

        /// <summary>claimDaily: a completed challenge's coins and XP; null if it can't be claimed.</summary>
        public static Claim ClaimDaily(IDictionary<string, object> profile, string id, string date)
        {
            var row = DailyRows(profile, date).FirstOrDefault(r => r.Id == id);
            if (row == null || !row.Claimable) return null;
            var s = DailyState(profile, date);
            var claimed = Copy(s.Claimed);
            claimed[id] = true;
            return new Claim
            {
                Coins = row.Reward, Xp = ChallengeXp,
                Update = new Dictionary<string, object> { ["daily"] = new Dictionary<string, object> { ["date"] = date, ["prog"] = Copy(s.Prog), ["claimed"] = claimed, ["chest"] = s.Chest } },
            };
        }

        /// <summary>claimChest: once every challenge is claimed, the chest's coins, XP, the streak and its day's reward.</summary>
        public static Claim ClaimChest(IDictionary<string, object> profile, string date)
        {
            var s = DailyState(profile, date);
            var rows = DailyRows(profile, date);
            if (s.Chest || !rows.All(r => r.Claimed)) return null;
            string last = Prof.Str(Prof.Get(profile, "lastFull"));
            double prior = Math.Floor(Prof.Num(Prof.Get(profile, "streak")));
            bool alive = last == Prof.DayBefore(date);
            double streak = alive ? prior + 1 : last == date ? prior : 1;
            var update = new Dictionary<string, object>
            {
                ["daily"] = new Dictionary<string, object> { ["date"] = date, ["prog"] = Copy(s.Prog), ["claimed"] = Copy(s.Claimed), ["chest"] = true },
                ["streak"] = streak,
                ["lastFull"] = date,
                ["bestStreak"] = Math.Max(streak, Math.Floor(Prof.Num(Prof.Get(profile, "bestStreak")))),
            };
            return new Claim { Coins = CHEST_COINS, Xp = ChestXp, Update = update, Reward = StreakRewardOf((int)streak) };
        }
    }
}
