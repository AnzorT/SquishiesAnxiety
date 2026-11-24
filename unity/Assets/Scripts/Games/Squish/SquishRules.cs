// Squish Time's rules, ported from the app: what a squish pays and counts (src/screens/SquishScreen.js: coins for
// moving the finger, the abuse guard, Speed Tapper), the multiplier on it (App.js coinMultiplier: src/progression.js
// streakMultiplier x TUTORIAL_BOOST in the tutorial's goal step), the creature's growth stage (src/squad/data.js
// stageOf), and the daily challenges a squish or its coins move (src/progression.js bumpDaily, written as
// src/firebase/firestore.js bumpDaily does, with the squishes' XP: src/playerXp.js). Plain C#, no Unity.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SquishSquad.Games.Squish
{
    public static class SquishRules
    {
        // SquishScreen.js
        public const double RippleLifetimeMs = 620;
        public const double BonusMs = 60000;
        public const double SpeedTapWindowMs = 60000;
        public const int SpeedTapThreshold = 60;
        public const double SoundMotionDp = 3;
        public const double EarnTickMs = 1500;
        public const int EarnPerTick = 5;
        public const double MotionGapMs = 180;
        public const double FloatingCoinMs = 1650, FloatingCoinRise = 72, FloatingCoinSize = 30;
        public const double RippleMax = 180;
        public static readonly (double windowMs, int limit)[] AbuseRules = { (1000, 5), (2000, 7) };
        public static readonly double AbuseMaxWindowMs = AbuseRules.Max(r => r.windowMs);
        // poke strength 1-5 -> multiplier on the tuned dent depth (3 = the tuned default)
        public static readonly double[] PokeStrengthScales = { 0.5, 0.75, 1, 1.25, 1.5 };
        public const double HoldAbuseMs = 400;   // a release sooner than this counts toward the abuse guard

        // src/progression.js
        public const double StreakBonus = 0.05;
        public const int StreakDays = 10;
        public const double TutorialBoost = 10;
        // config/levels xp defaults (functions/squad.js DEFAULT_LEVELS): 1 XP every squishEvery squishes, up to
        // squishDay a day; the curve's xpPerLevel
        public static double SquishEvery = 5, SquishDay = 200, XpPerLevel = 100;

        static object Get(IDictionary<string, object> d, string k) => d != null && d.TryGetValue(k, out var v) ? v : null;
        static double Num(object v, double dflt = 0) => v is double d ? d : v is int i ? i : v is long l ? l : dflt;

        // --- the coins (startEarning / noteEarnMotion / stopEarning) ---------------------------------------------------
        public sealed class Earner
        {
            public bool Earning;
            public double Accum, MovingMs, LastMotionAt;

            public void Start(double now)
            {
                if (Earning) return;
                Earning = true;
                Accum = 0;
                MovingMs = 0;
                LastMotionAt = now;
            }

            /// <summary>A counted movement: the coins it banks (one entry per earn tick, usually none).</summary>
            public List<int> NoteMotion(double now, bool bonusLive, double bonusMultiplier, double coinMultiplier)
            {
                var gains = new List<int>();
                if (!Earning) return gains;
                MovingMs += Math.Min(now - LastMotionAt, MotionGapMs);
                LastMotionAt = now;
                while (MovingMs >= EarnTickMs)
                {
                    MovingMs -= EarnTickMs;
                    int gain = (int)Math.Max(1, SquishToy.JsRound(EarnPerTick * (bonusLive ? bonusMultiplier : 1) * (coinMultiplier != 0 ? coinMultiplier : 1)));
                    Accum += gain;
                    gains.Add(gain);
                }
                return gains;
            }

            /// <summary>Flushes the banked total (the caller pays it: addCoins + bumpDaily 'earn').</summary>
            public double Stop()
            {
                Earning = false;
                MovingMs = 0;
                double earned = Accum;
                Accum = 0;
                return earned;
            }
        }

        // --- the abuse guard (registerAbuseTap) --------------------------------------------------------------------------
        public sealed class AbuseGuard
        {
            List<double> _taps = new List<double>();
            public bool Open;

            /// <summary>A quick jab: true when it trips the punishment (it opens; Dismiss closes it).</summary>
            public bool Register(double t)
            {
                if (Open) return false;
                var taps = _taps.Concat(new[] { t }).Where(ts => t - ts < AbuseMaxWindowMs).ToList();
                _taps = taps;
                bool violated = AbuseRules.Any(r => (taps.Count(ts => t - ts < r.windowMs) / (double)r.limit) * 100 >= 100);
                if (violated)
                {
                    _taps = new List<double>();
                    Open = true;
                }
                return violated;
            }

            public void Dismiss() { Open = false; _taps = new List<double>(); }
        }

        /// <summary>Speed Tapper: the releases in the last minute (tapTimestampsRef).</summary>
        public sealed class SpeedTaps
        {
            List<double> _ts = new List<double>();
            public int Note(double now)
            {
                _ts = _ts.Concat(new[] { now }).Where(t => now - t < SpeedTapWindowMs).ToList();
                return _ts.Count;
            }
        }

        // --- the profile's numbers -------------------------------------------------------------------------------------
        /// <summary>todayKey(now): the local date, yyyy-mm-dd.</summary>
        public static string TodayKey(DateTime local) => local.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        static string DayBefore(string date) =>
            TodayKey(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture).AddDays(-1));

        public static double StreakOf(IDictionary<string, object> profile, DateTime localNow)
        {
            string today = TodayKey(localNow);
            var last = Get(profile, "lastFull") as string;
            return last != null && (last == today || last == DayBefore(today)) ? Math.Max(0, Math.Floor(Num(Get(profile, "streak")))) : 0;
        }

        public static double StreakMultiplier(IDictionary<string, object> profile, DateTime localNow) =>
            1 + StreakBonus * Math.Min(StreakDays, StreakOf(profile, localNow));

        /// <summary>App.js: coinMultiplier = streakMultiplier x (×10 in the tutorial's goal step).</summary>
        public static double CoinMultiplier(IDictionary<string, object> profile, DateTime localNow) =>
            StreakMultiplier(profile, localNow) * ((Get(profile, "tut") as string) == "goal" ? TutorialBoost : 1);

        /// <summary>The tutorial is on (its coach marks replace the stage's hints): profile.tut set and not 'done'.</summary>
        public static bool TutorialOn(IDictionary<string, object> profile) => Get(profile, "tut") is string t && t != "done";

        /// <summary>stageOf(profile, id): the creature's growth stage (0 Baby, 1, 2 Best Friend).</summary>
        public static int StageOf(IDictionary<string, object> profile, string id)
        {
            var col = Get(profile, "col") as IDictionary<string, object>;
            var e = Get(col, id) as IDictionary<string, object>;
            return (int)Num(Get(e, "st"));
        }

        // --- the player's XP (src/playerXp.js; the curve is functions/squad.js's) ------------------------------------------
        public static double XpToNext(double L) => XpPerLevel * (Math.Max(1, Math.Floor(L)) + 1);
        public static double XpToReach(double L) => L <= 1 ? 0 : XpPerLevel * (L * (L + 1) - 2) / 2;
        public static double LevelOf(double pxp)
        {
            double x = Math.Max(0, Math.Floor(double.IsNaN(pxp) || double.IsInfinity(pxp) ? 0 : pxp));
            double L = Math.Max(1, Math.Floor((Math.Sqrt(9 + 8 * x / XpPerLevel) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return L;
        }
        public static double PxpOf(IDictionary<string, object> profile)
        {
            if (Get(profile, "pxp") is double p) return Math.Max(0, p);
            var sdk = Get(profile, "sdk") as IDictionary<string, object>;
            return XpToReach(Math.Max(1, Math.Floor(Num(Get(profile, "level"), 1)))) + Math.Max(0, Math.Floor(Num(Get(sdk, "xp"))));
        }

        // --- the daily challenges (src/progression.js) -------------------------------------------------------------------
        sealed class Def { public string Id, Ev; public int[] Goals; public Func<int, string> Title; public int Reward; }
        static readonly Def[] Game =
        {
            new Def { Id = "g_squish", Ev = "squish", Goals = new[] { 50, 80, 120 }, Title = n => $"Squish {n} times", Reward = 60 },
            new Def { Id = "g_earn", Ev = "earn", Goals = new[] { 200, 300, 500 }, Title = n => $"Earn {n} coins squishing", Reward = 80 },
            new Def { Id = "g_ad", Ev = "ad", Goals = new[] { 1 }, Title = _ => "Watch 1 bonus video", Reward = 40 },
        };
        static readonly Def[] Crib =
        {
            new Def { Id = "c_bath", Ev = "bath", Goals = new[] { 2, 3 }, Title = n => $"Give {n} friends a bath", Reward = 60 },
            new Def { Id = "c_feed", Ev = "feed", Goals = new[] { 2, 3 }, Title = n => $"Feed {n} friends a snack", Reward = 60 },
            new Def { Id = "c_sleep", Ev = "sleep", Goals = new[] { 1, 2 }, Title = n => $"Tuck {n} {(n > 1 ? "friends" : "friend")} into bed", Reward = 50 },
            new Def { Id = "c_dance", Ev = "dance", Goals = new[] { 2, 3 }, Title = n => $"Send {n} friends to dance", Reward = 50 },
            new Def { Id = "c_tv", Ev = "tv", Goals = new[] { 2 }, Title = n => $"Watch TV with {n} friends", Reward = 40 },
            new Def { Id = "c_play", Ev = "play", Goals = new[] { 2, 3 }, Title = n => $"Send {n} friends out to play", Reward = 40 },
        };
        static readonly string[] CribEvents = { "bath", "feed", "sleep", "dance", "tv", "play" };

        public sealed class Challenge { public string Id, Ev, Side; public int Goal; }
        public sealed class Row { public string Id, Ev, Title; public int Goal; public double Prog; public bool Claimable, Claimed; }

        /// <summary>challengesFor(date): today's six, from the design's seeded generator.</summary>
        public static List<Challenge> ChallengesFor(string date)
        {
            double seed = date.Split('-').Aggregate(7.0, (a, b) => a * 31 + double.Parse(b, CultureInfo.InvariantCulture)) % 233280;
            double R() { seed = (seed * 9301 + 49297) % 233280; return seed / 233280; }
            var crib = Crib.ToArray();
            for (int i = crib.Length - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(R() * (i + 1));
                var t = crib[i]; crib[i] = crib[j]; crib[j] = t;
            }
            Challenge Pick(Def c, string side) => new Challenge { Id = c.Id, Ev = c.Ev, Side = side, Goal = c.Goals[(int)Math.Floor(R() * c.Goals.Length)] };
            var list = Game.Select(c => Pick(c, "game")).ToList();
            list.AddRange(crib.Take(3).Select(c => Pick(c, "crib")));
            return list;
        }

        sealed class DayState { public IDictionary<string, object> Prog, Claimed; public bool Chest; }

        static DayState DailyState(IDictionary<string, object> profile, string date)
        {
            var d = Get(profile, "daily") as IDictionary<string, object>;
            if (d != null && Get(d, "date") as string == date)
                return new DayState
                {
                    Prog = Get(d, "prog") as IDictionary<string, object> ?? new Dictionary<string, object>(),
                    Claimed = Get(d, "claimed") as IDictionary<string, object> ?? new Dictionary<string, object>(),
                    Chest = Get(d, "chest") is bool b && b,
                };
            return new DayState { Prog = new Dictionary<string, object>(), Claimed = new Dictionary<string, object>(), Chest = false };
        }

        static bool Truthy(object v) => v is bool b ? b : v is double d ? d != 0 && !double.IsNaN(d) : v is string s ? s.Length > 0 : v != null;

        public static List<Row> DailyRows(IDictionary<string, object> profile, string date)
        {
            var s = DailyState(profile, date);
            var byId = Game.Concat(Crib).ToDictionary(c => c.Id);
            return ChallengesFor(date).Select(c =>
            {
                var def = byId[c.Id];
                double prog = Math.Min(c.Goal, Num(Get(s.Prog, c.Ev)));
                bool claimed = Truthy(Get(s.Claimed, c.Id));
                bool full = prog >= c.Goal;
                return new Row { Id = c.Id, Ev = c.Ev, Title = def.Title(c.Goal), Goal = c.Goal, Prog = prog, Claimed = claimed, Claimable = full && !claimed };
            }).ToList();
        }

        public sealed class Bump
        {
            public Dictionary<string, object> Daily;   // the `daily` field to write
            public List<string> Completed;            // challenges this completed (the toast)
            public double Xp;                         // squishes: today's count passing a squishEvery step
            public bool CribCare;                     // a Crib event: also cribCare += n
        }

        /// <summary>bumpDaily(profile, ev, n, date).</summary>
        public static Bump BumpDaily(IDictionary<string, object> profile, string ev, double n, string date)
        {
            var before = DailyRows(profile, date);
            var s = DailyState(profile, date);
            double had = Num(Get(s.Prog, ev));
            var prog = new Dictionary<string, object>(s.Prog) { [ev] = had + n };
            var next = new Dictionary<string, object>(profile ?? new Dictionary<string, object>())
            {
                ["daily"] = new Dictionary<string, object> { ["prog"] = prog, ["claimed"] = s.Claimed, ["chest"] = s.Chest, ["date"] = date },
            };
            var after = DailyRows(next, date);
            var completed = after.Where((r, i) => r.Claimable && !before[i].Claimable).Select(r => r.Title).ToList();
            double Steps(double k) => Math.Min(SquishDay, Math.Floor(k / SquishEvery));
            double xp = ev == "squish" ? Steps(had + n) - Steps(had) : 0;
            return new Bump
            {
                Daily = new Dictionary<string, object> { ["date"] = date, ["prog"] = prog, ["claimed"] = s.Claimed, ["chest"] = s.Chest },
                Completed = completed,
                Xp = xp,
                CribCare = Array.IndexOf(CribEvents, ev) >= 0,
            };
        }

        /// <summary>xpFields' level: the new level when `xp` more takes the profile up one, else null.</summary>
        public static double? LevelAfter(IDictionary<string, object> profile, double xp)
        {
            double r = Math.Max(0, SquishToy.JsRound(xp));
            double total = PxpOf(profile);
            double before = LevelOf(total), after = LevelOf(total + r);
            return after > before ? after : (double?)null;
        }
    }
}
