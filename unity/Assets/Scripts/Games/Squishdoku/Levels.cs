// Port of src/squishdoku/levels.js: Squishdoku's levels, timers, scoring and rewards (SQUISHDOKU.md), and the
// profile's `sdk` record they're saved in. Pure functions: the screen writes what they return. Behaviour matches the
// JS exactly (tools/unity/games/squishdoku checks it), quirks included.
//
// Profiles are plain maps as Firestore returns them: IDictionary<string, object> with numbers as double (any numeric
// type is accepted), bools, strings, null and nested IDictionary<string, object>. The patches returned (`update`)
// use the same model and the JS's dotted keys ('sdk.plays', 'sdk.best.12', ...). Pure C#, no Unity dependencies.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class LevelInfo
    {
        public int N;
        public int Tier;
        public int Effort;
    }

    /// <summary>A level's board: { n, regions (each cell's patch), solution (each row's column), colors (each
    /// patch's PATCHES colour), effort }.</summary>
    public sealed class LevelPuzzle
    {
        public int N;
        public int[] Regions;
        public int[] Solution;
        public int[] Colors;
        public int Effort;
    }

    /// <summary>levelSpec(): { lv, n, tier, effort, puzzle, limitMs, aMs, bMs, head, hearts }.</summary>
    public sealed class LevelSpec
    {
        public int Lv;
        public int N;
        public int Tier;
        public int Effort;
        public LevelPuzzle Puzzle;
        public int LimitMs;
        public int AMs;
        public int BMs;
        public bool Head;
        public int Hearts;
    }

    public sealed class StageInfo
    {
        public string Room;
        public string Phase;
        public string Key;
    }

    public sealed class StarsResult
    {
        public int Stars;
        public bool Perfect;
    }

    public sealed class BlitzSpec
    {
        public int Lv;
        public int N;
        public int Tier;
        public int Ms;
    }

    public sealed class BlitzPrizeResult
    {
        public int Coins;
        public double Xp;
    }

    /// <summary>record(): the profile's `sdk` with its defaults filled in. Best, Perfect and Blitz are the
    /// profile's own maps (Blitz: the defaults, then every key the profile has).</summary>
    public sealed class SdkRecord
    {
        public double Lv;
        public IDictionary<string, object> Best;
        public IDictionary<string, object> Perfect;
        public double Skill;
        public double BSkill;
        public Dictionary<string, object> Blitz;
        public double Plays;
        public double Solves;
        public bool Head;
    }

    /// <summary>afterLevel(): { update, coins, levelCoins, xp, levelUps, unlocked, before, after }. When the level
    /// wasn't solved, LevelCoins, Before and After are null (the JS leaves them out).</summary>
    public sealed class LevelOutcome
    {
        public Dictionary<string, object> Update;
        public int Coins;
        public int? LevelCoins;
        public double Xp;
        public List<int> LevelUps;
        public bool Unlocked;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
    }

    /// <summary>afterBlitz(): { update, coins, xp, levelUps, before, after, newTop }. When nothing was cleared,
    /// Before and After are null (the JS leaves them out) and NewTop is false.</summary>
    public sealed class BlitzOutcome
    {
        public Dictionary<string, object> Update;
        public int Coins;
        public double Xp;
        public List<int> LevelUps;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
        public bool NewTop;
    }

    public static class Levels
    {
        /// <summary>LEVELS: 600 levels, one fixed board each (LevelData.g.cs).</summary>
        public static readonly int LevelCount = LevelData.All.Length;
        public const int Chapter = 20;
        public static readonly int Chapters = (int)Math.Ceiling((double)LevelCount / Chapter);

        public static int ChapterOf(double lv)
        {
            return (int)Math.Floor((Math.Max(1, Math.Min(LevelCount, lv)) - 1) / Chapter) + 1;
        }

        /// <summary>Tiers by effort: EASY ≤1, MEDIUM ≤3, HARD ≤7, EXPERT ≤15, MASTER ≤23, then LEGEND.</summary>
        public static int TierOfEffort(int e)
        {
            return e <= 1 ? 0 : e <= 3 ? 1 : e <= 7 ? 2 : e <= 15 ? 3 : e <= 23 ? 4 : 5;
        }

        public static readonly LevelInfo[] LevelList = BuildLevelList();

        static LevelInfo[] BuildLevelList()
        {
            var list = new LevelInfo[LevelData.All.Length];
            for (int i = 0; i < list.Length; i++)
            {
                var d = LevelData.All[i];
                list[i] = new LevelInfo { N = d.N, Tier = TierOfEffort(d.E), Effort = d.E };
            }
            return list;
        }

        // Seconds per grid size: the level's limit, and the times A (3 creatures) and B (2 creatures)
        static double[] Times(int n)
        {
            switch (n)
            {
                case 4: return new double[] { 60, 15, 30 };
                case 5: return new double[] { 90, 30, 55 };
                case 6: return new double[] { 150, 50, 90 };
                case 7: return new double[] { 210, 75, 130 };
                case 8: return new double[] { 300, 110, 185 };
                case 9: return new double[] { 420, 150, 260 };
                default: throw new ArgumentOutOfRangeException(nameof(n));
            }
        }

        /// <summary>HEAD_START: the first row's creature is placed for you; the clock × 0.8, coins and XP × 0.6.</summary>
        public const double HeadStartTime = 0.8;
        public const double HeadStartReward = 0.6;

        public const int Hearts = 3;
        public const int HeartsFrom = 46;

        /// <summary>Level lv (1-600, clamped; 0 or NaN is level 1).</summary>
        public static LevelSpec SpecOf(double lv, bool head = false)
        {
            double f = Math.Floor(lv);
            double L0 = Math.Max(1, Math.Min(LevelCount, (double.IsNaN(f) || f == 0) ? 1 : f));
            int L = (int)L0;
            var d = LevelData.All[L - 1];
            double k = (1 + 0.05 * Math.Min(30, d.E)) * (head ? HeadStartTime : 1);
            var t = Times(d.N);
            var ms = new int[3];
            for (int i = 0; i < 3; i++) ms[i] = (int)(Js.Round((t[i] * k) / 5) * 5 * 1000);
            var puzzle = new LevelPuzzle { N = d.N, Regions = new int[d.R.Length], Solution = new int[d.S.Length], Colors = new int[d.C.Length], Effort = d.E };
            for (int i = 0; i < d.R.Length; i++) puzzle.Regions[i] = d.R[i] - 97;
            for (int i = 0; i < d.S.Length; i++) puzzle.Solution[i] = d.S[i] - '0';
            for (int i = 0; i < d.C.Length; i++) puzzle.Colors[i] = d.C[i] - '0';
            return new LevelSpec
            {
                Lv = L, N = d.N, Tier = TierOfEffort(d.E), Effort = d.E, Puzzle = puzzle,
                LimitMs = ms[0], AMs = ms[1], BMs = ms[2], Head = head, Hearts = L >= HeartsFrom ? Hearts : 0,
            };
        }

        // The Crib room a level is played in, and its time of day.
        static readonly string[] ChapterRooms = { "living", "kitchen", "bath", "bed", "yard", "dance" };
        static readonly string[] FourPhases = { "morning", "day", "evening", "night" };
        static readonly string[] DayOnly = { "day" };

        static string[] PhasesOf(string room)
        {
            return room == "bath" || room == "dance" ? DayOnly : FourPhases;
        }

        /// <summary>The room of chapter c (1 and up).</summary>
        public static string RoomOfChapter(int c)
        {
            return ChapterRooms[(c - 1) % ChapterRooms.Length];
        }

        public static StageInfo StageOf(double lv)
        {
            double L = Math.Max(1, Math.Min(LevelCount, lv));
            int c = ChapterOf(L);
            string room = RoomOfChapter(c);
            var phases = PhasesOf(room);
            int k = (int)Math.Min(phases.Length - 1, Math.Floor((((L - 1) % Chapter) / Chapter) * phases.Length));
            return new StageInfo { Room = room, Phase = phases[k], Key = room + ":" + Js.NumberToString(k) };
        }

        // --- adaptive difficulty (Blitz only) ----------------------------------------------

        public const double SkillMin = -2;
        public const double SkillMax = 2;

        public static int SkillShift(double skill)
        {
            return skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0;
        }

        static double ClampSkill(double s)
        {
            return Js.Round(Math.Max(SkillMin, Math.Min(SkillMax, s)) * 100) / 100;
        }

        // --- scoring --------------------------------------------------------------------

        /// <summary>How many creatures a solve earns (1-3), and whether it was PERFECT (no ✕ and no mistakes).</summary>
        public static StarsResult StarsFor(LevelSpec spec, double ms, int mistakes, bool usedX)
        {
            if (mistakes == 0 && !usedX) return new StarsResult { Stars = 3, Perfect = true };
            if (mistakes != 0) return new StarsResult { Stars = 1, Perfect = false };
            return new StarsResult { Stars = ms <= spec.AMs ? 3 : ms <= spec.BMs ? 2 : 1, Perfect = false };
        }

        /// <summary>How many creatures are still on offer at ms into the level.</summary>
        public static int StarsLeft(LevelSpec spec, double ms, int mistakes)
        {
            if (mistakes != 0) return 1;
            return ms <= spec.AMs ? 3 : ms <= spec.BMs ? 2 : 1;
        }

        static int BaseCoins(int n)
        {
            switch (n)
            {
                case 4: return 15;
                case 5: return 25;
                case 6: return 35;
                case 7: return 50;
                case 8: return 65;
                case 9: return 85;
                default: throw new ArgumentOutOfRangeException(nameof(n));
            }
        }

        static readonly double[] StarMult = { 0, 1, 1.5, 2 };
        public const int PerfectMult = 3;

        static double HeadCut(LevelSpec spec)
        {
            return spec.Head ? HeadStartReward : 1;
        }

        /// <summary>stars: 0-3.</summary>
        public static int CoinsFor(LevelSpec spec, int stars, bool perfect)
        {
            return (int)Js.Round(BaseCoins(spec.N) * (perfect ? PerfectMult : StarMult[stars]) * (1 + 0.15 * spec.Tier) * HeadCut(spec));
        }

        public static double XpFor(LevelSpec spec, double stars, bool perfect)
        {
            int b = 10 + 5 * (spec.N - 4) + 5 * spec.Tier;
            return Js.Round(b * (0.6 + 0.2 * stars) * (perfect ? 1.5 : 1) * HeadCut(spec));
        }

        // --- Blitz -----------------------------------------------------------------------

        // the sizes the run climbs through: 4×4 twice, 5×5 three times, 6×6 four, 7×7 five, then 8×8 for good
        static readonly int[] BlitzRamp = { 4, 4, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7 };

        /// <summary>BLITZ_SECS: a board's clock, in seconds, by size (4-8).</summary>
        public static int BlitzSecs(int n)
        {
            switch (n)
            {
                case 4: return 12;
                case 5: return 20;
                case 6: return 30;
                case 7: return 42;
                case 8: return 56;
                default: throw new ArgumentOutOfRangeException(nameof(n));
            }
        }

        /// <summary>BLITZ_COINS: coins for each board cleared, by size (4-8).</summary>
        public static int BlitzCoins(int n)
        {
            switch (n)
            {
                case 4: return 30;
                case 5: return 50;
                case 6: return 70;
                case 7: return 100;
                case 8: return 130;
                default: throw new ArgumentOutOfRangeException(nameof(n));
            }
        }

        /// <summary>Board i of a run (0 = the first; i ≥ 0).</summary>
        public static BlitzSpec BlitzSpecOf(int i, double skill = 0)
        {
            int n = i < BlitzRamp.Length ? BlitzRamp[i] : 8;
            int past = Math.Max(0, i - BlitzRamp.Length + 1);
            int b = i < 5 ? 0 : i < BlitzRamp.Length ? i % 2 : past >= 7 ? 2 : 1;
            int tier = Math.Max(0, Math.Min(2, b + SkillShift(skill)));
            int ms = (int)(Js.Round(BlitzSecs(n) * Math.Max(0.75, 1 - 0.03 * past)) * 1000);
            return new BlitzSpec { Lv = i + 1, N = n, Tier = tier, Ms = ms };
        }

        /// <summary>A gem save's price: 10, doubling with each save `i` already had in the run, up to 320.</summary>
        public static int BlitzSaveGems(double i)
        {
            double v = double.IsNaN(i) || i == 0 ? 0 : i;
            return (int)(10 * Math.Pow(2, Math.Max(0, Math.Min(5, Math.Floor(v)))));
        }

        /// <summary>BlitzSaveGems with JS Number() coercion of any value (null, bool, string, number).</summary>
        public static int BlitzSaveGems(object i)
        {
            return BlitzSaveGems(Js.ToNumber(i));
        }

        /// <summary>What `cleared` boards pay: their coins, and the player's XP.</summary>
        public static BlitzPrizeResult BlitzPrize(int cleared, double skill = 0)
        {
            int coins = 0;
            for (int i = 0; i < cleared; i++) coins += BlitzCoins(BlitzSpecOf(i, skill).N);
            return new BlitzPrizeResult { Coins = coins, Xp = Js.Round((PlayerXp.Rules.BlitzSquishdoku / 10) * cleared) };
        }

        // --- the profile's record -------------------------------------------------------

        static object Get(IDictionary<string, object> d, string key)
        {
            object v;
            return d != null && d.TryGetValue(key, out v) ? v : null;
        }

        public static SdkRecord Record(IDictionary<string, object> profile)
        {
            var s = Get(profile, "sdk") as IDictionary<string, object>;
            var blitz = new Dictionary<string, object> { { "top", 0.0 }, { "runs", 0.0 }, { "reached", 0.0 }, { "bestMs", 0.0 }, { "wins", 0.0 } };
            var sb = Get(s, "blitz") as IDictionary<string, object>;
            if (sb != null) foreach (var kv in sb) blitz[kv.Key] = kv.Value;
            return new SdkRecord
            {
                Lv = Math.Max(1, Math.Min(LevelCount, Js.OrNumber(Get(s, "lv"), 1))),
                Best = Get(s, "best") as IDictionary<string, object> ?? new Dictionary<string, object>(),
                Perfect = Get(s, "perfect") as IDictionary<string, object> ?? new Dictionary<string, object>(),
                Skill = Js.OrNumber(Get(s, "skill"), 0),
                BSkill = Js.OrNumber(Get(s, "bSkill"), 0),
                Blitz = blitz,
                Plays = Js.OrNumber(Get(s, "plays"), 0),
                Solves = Js.OrNumber(Get(s, "solves"), 0),
                Head = Js.Truthy(Get(s, "head")),
            };
        }

        /// <summary>The fields to write after a Regular level, and what it paid. stars: 1-3 (0-3) for a solve.</summary>
        public static LevelOutcome AfterLevel(IDictionary<string, object> profile, LevelSpec spec, bool solved, int stars = 0, bool perfect = false)
        {
            var rec = Record(profile);
            var update = new Dictionary<string, object> { { "sdk.plays", rec.Plays + 1 } };
            if (!solved) return new LevelOutcome { Update = update, Coins = 0, Xp = 0, LevelUps = new List<int>(), Unlocked = false };
            int coins = CoinsFor(spec, stars, perfect);
            string key = Js.IntKey(spec.Lv);
            object bestRaw = Get(rec.Best, key);
            double best = Js.OrNumber(bestRaw, 0);
            double? prev = null;
            if (Js.Truthy(bestRaw)) prev = PlayerXp.GameXp(XpFor(spec, best, Js.Truthy(Get(rec.Perfect, key))));
            double xp = PlayerXp.WinXp(PlayerXp.GameXp(XpFor(spec, stars, perfect)), prev);
            var gain = PlayerXp.AddXp(profile, xp);
            update["sdk.solves"] = rec.Solves + 1;
            if (stars > best) update["sdk.best." + key] = (double)stars;
            if (perfect && !Js.Truthy(Get(rec.Perfect, key))) update["sdk.perfect." + key] = true;
            bool unlocked = spec.Lv == rec.Lv && rec.Lv < LevelCount;
            if (unlocked) update["sdk.lv"] = rec.Lv + 1;
            return new LevelOutcome { Update = update, Coins = coins, LevelCoins = coins, Xp = xp, LevelUps = gain.LevelUps, Unlocked = unlocked, Before = gain.Before, After = gain.After };
        }

        /// <summary>The fields to write when a Blitz run is over (`cleared`: the boards it cleared), and what it paid.</summary>
        public static BlitzOutcome AfterBlitz(IDictionary<string, object> profile, int cleared)
        {
            var rec = Record(profile);
            var update = new Dictionary<string, object>
            {
                { "sdk.bSkill", ClampSkill(rec.BSkill + (cleared >= 10 ? 0.4 : cleared < 5 ? -0.3 : 0)) },
                { "sdk.blitz.runs", Js.OrNumber(Get(rec.Blitz, "runs"), 0) + 1 },
            };
            bool newTop = cleared > Js.ToNumber(Get(rec.Blitz, "top"));
            if (newTop) update["sdk.blitz.top"] = (double)cleared;
            if (cleared == 0) return new BlitzOutcome { Update = update, Coins = 0, Xp = 0, LevelUps = new List<int>(), NewTop = false };
            // the skill the run's boards were dealt at (blitzSpec), so the coins match what was played
            var prize = BlitzPrize(cleared, rec.BSkill);
            var gain = PlayerXp.AddXp(profile, prize.Xp);
            return new BlitzOutcome { Update = update, Coins = prize.Coins, Xp = prize.Xp, LevelUps = gain.LevelUps, Before = gain.Before, After = gain.After, NewTop = newTop };
        }

        /// <summary>1:05 / 0:09</summary>
        public static string Clock(double ms)
        {
            double s = Math.Max(0, Math.Ceiling(ms / 1000));
            string sec = Js.NumberToString(s % 60);
            if (sec.Length < 2) sec = new string('0', 2 - sec.Length) + sec;
            return Js.NumberToString(Math.Floor(s / 60)) + ":" + sec;
        }
    }
}
