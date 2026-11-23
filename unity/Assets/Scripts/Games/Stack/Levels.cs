// Squish Stack's levels, difficulty, scoring and rewards, ported from src/stack/levels.js (SQUISH_STACK.md), and the
// profile's `stack` record they're saved in. Pure functions: the screen writes what they return.
//
// 50 levels in bands of one size (squishies × cushions), each level asking for a difficulty tier (0 easy, 1 medium,
// 2 hard, 3 expert) that rises inside its band, with breathers in between. A hidden skill score moves the tier one
// step either way (adaptive difficulty); the size never changes. The tier sets how many moves the best answer takes
// (the par) and whether the goal is a picture. Wins pay coins and the player's XP (StackXp).
//
// Profiles are the Firestore document as a map (numbers as double, maps as IDictionary<string, object>); the updates
// are Firestore field patches keyed like "stack.lv", numbers as double.
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Games.Stack
{
    // levelSpec() / blitzSpec(): { lv, round, band, n, k, tier, baseTier, start, goal, par, clock, news }
    public sealed class LevelSpec
    {
        public int Lv;
        public int? Round; // Blitz only (1-10)
        public int Band;
        public int N;
        public int K;
        public int Tier;
        public int BaseTier;
        public string Start; // "tower" or "scrambled"
        public string Goal; // "star" or "picture"
        public int[] Par; // [lo, hi]
        public bool Clock;
        public string News; // "picture", "clock", "cushion" or null
    }

    // LEVEL_LIST's entries: { band, n, k, tier }
    public sealed class LevelEntry
    {
        public int Band;
        public int N;
        public int K;
        public int Tier;
    }

    public sealed class BlitzRecord
    {
        public double Reached;
        public double BestMs;
        public double Wins;
    }

    // record(): the profile's `stack`, filled in
    public sealed class StackRecord
    {
        public double Lv;
        public IDictionary<string, object> Best; // level ("1"-"50") → stars
        public double Skill;
        public double Plays;
        public double Wins;
        public bool Seen;
        public double BSkill;
        public BlitzRecord Blitz;
    }

    // afterLevel() / afterBlitz(): the fields to write and what it paid. Before / After are null when lost; Stars and
    // Unlocked are afterLevel's only.
    public sealed class StackOutcome
    {
        public Dictionary<string, object> Update;
        public double Coins;
        public double Xp;
        public PlayerLevel Before;
        public PlayerLevel After;
        public List<int> LevelUps;
        public int Stars;
        public bool Unlocked;
    }

    public static class Levels
    {
        public const int LEVELS = 50;

        sealed class BandDef
        {
            public int N, K;
            public int[] Tiers;
            public int[][] Par;
        }

        // par: the best answer's length [lo, hi] for each tier. The 4th cushion makes towers much shorter, so band 5
        // is a breather after the long 5-on-3 ones.
        static readonly BandDef[] BANDS =
        {
            new BandDef { N = 3, K = 3, Tiers = new[] { 0, 0, 0 }, Par = new[] { new[] { 3, 5 }, new[] { 5, 7 }, new[] { 6, 7 }, new[] { 7, 7 } } }, //  1-3
            new BandDef { N = 4, K = 3, Tiers = new[] { 0, 0, 1, 0, 1 }, Par = new[] { new[] { 6, 9 }, new[] { 9, 12 }, new[] { 12, 15 }, new[] { 14, 15 } } }, //  4-8
            new BandDef { N = 4, K = 3, Tiers = new[] { 0, 1, 1, 0, 1, 2 }, Par = new[] { new[] { 7, 10 }, new[] { 9, 12 }, new[] { 11, 14 }, new[] { 13, 15 } } }, //  9-14
            new BandDef { N = 5, K = 3, Tiers = new[] { 0, 1, 1, 2, 1, 2, 2 }, Par = new[] { new[] { 10, 14 }, new[] { 13, 18 }, new[] { 17, 22 }, new[] { 21, 26 } } }, // 15-21
            new BandDef { N = 5, K = 4, Tiers = new[] { 0, 1, 2, 1, 2, 2, 3 }, Par = new[] { new[] { 6, 8 }, new[] { 7, 9 }, new[] { 9, 11 }, new[] { 10, 13 } } }, // 22-28
            new BandDef { N = 6, K = 4, Tiers = new[] { 1, 1, 2, 1, 2, 3, 2, 3 }, Par = new[] { new[] { 9, 11 }, new[] { 11, 13 }, new[] { 12, 15 }, new[] { 14, 17 } } }, // 29-36
            new BandDef { N = 7, K = 4, Tiers = new[] { 1, 2, 2, 1, 2, 3, 3 }, Par = new[] { new[] { 12, 15 }, new[] { 14, 17 }, new[] { 16, 19 }, new[] { 18, 22 } } }, // 37-43
            new BandDef { N = 8, K = 4, Tiers = new[] { 1, 2, 2, 3, 2, 3, 3 }, Par = new[] { new[] { 15, 19 }, new[] { 18, 22 }, new[] { 21, 25 }, new[] { 24, 28 } } }, // 44-50
        };

        static readonly LevelEntry[] levelList = BuildList();

        static LevelEntry[] BuildList()
        {
            var list = new List<LevelEntry>();
            for (int band = 0; band < BANDS.Length; band++)
                foreach (int tier in BANDS[band].Tiers)
                    list.Add(new LevelEntry { Band = band, N = BANDS[band].N, K = BANDS[band].K, Tier = tier });
            return list.ToArray();
        }

        public static IReadOnlyList<LevelEntry> LEVEL_LIST => levelList;

        public static readonly string[] TIER_NAMES = { "EASY", "MEDIUM", "HARD", "EXPERT" };
        public static readonly string[] TIER_COLORS = { "#3ddc97", "#5fb8ff", "#ff8a4a", "#e01e4a" };

        // The classic: everyone starts on the first cushion and goes to the last. On level 1, and when a band brings a
        // new size (4 squishies, a 4th cushion, 6).
        static readonly int[] TOWERS = { 1, 4, 22, 29 };
        // the goal card's first level (before it, every goal is one ★ cushion)
        public const int PICTURE_FROM = 9;
        // "for a certain level it will start a timer" (the user, 2026-10-24)
        public const int CLOCK_FROM = 15;

        // Level `lv` (1-50; anything else is clamped, 0 / NaN is 1) at a skill.
        public static LevelSpec LevelSpec(double lv, double skill = 0)
        {
            double f = Math.Floor(lv);
            if (f == 0 || double.IsNaN(f)) f = 1;
            int L = (int)Math.Max(1, Math.Min(LEVELS, f));
            var b = levelList[L - 1];
            var band = BANDS[b.Band];
            int tier = Math.Max(0, Math.Min(3, b.Tier + SkillShift(skill)));
            bool tower = Array.IndexOf(TOWERS, L) >= 0;
            bool picture = !tower && L >= PICTURE_FROM && (tier >= 2 || (tier == 1 && L % 2 == 1));
            string news = null;
            if (L == PICTURE_FROM) news = "picture";
            else if (L == CLOCK_FROM) news = "clock";
            else if (L > 1 && b.K > levelList[L - 2].K) news = "cushion";
            return new LevelSpec
            {
                Lv = L,
                Band = b.Band,
                N = b.N,
                K = b.K,
                Tier = tier,
                BaseTier = b.Tier,
                Start = tower ? "tower" : "scrambled",
                Goal = tower ? "star" : picture ? "picture" : "star",
                Par = (int[])band.Par[tier].Clone(),
                Clock = L >= CLOCK_FROM,
                News = news,
            };
        }

        // The clock for a puzzle whose best answer is `par` moves, in ms (0: no clock): generous, but it runs out
        // (thinking time up front, then a few seconds a move).
        public static int LimitFor(LevelSpec spec, int par)
        {
            if (!spec.Clock) return 0;
            double s = 20 + par * (spec.Tier >= 2 ? 3 : 3.6);
            return (int)(Math.Ceiling(s / 5) * 5 * 1000);
        }

        // --- adaptive difficulty -------------------------------------------------------

        public const double SKILL_MIN = -2;
        public const double SKILL_MAX = 2;
        public static int SkillShift(double skill) => skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0;
        static double ClampSkill(double s) => Js.Round(Math.Max(SKILL_MIN, Math.Min(SKILL_MAX, s)) * 100) / 100;

        // After a level: wins in few moves raise it; fails and hints lower it.
        public static double NextSkill(double skill, bool won, int stars = 0, bool hinted = false)
        {
            if (!won) return ClampSkill(skill - 0.5);
            double gain = stars == 3 ? 0.35 : stars == 2 ? 0.15 : 0;
            return ClampSkill(skill + gain - (hinted ? 0.15 : 0));
        }

        // --- scoring --------------------------------------------------------------------

        // moves allowed for 2 stars
        public static int TwoStarMoves(int par) => par + (int)Math.Max(2, Math.Ceiling(par * 0.5));

        // 3: the par (the fewest moves there are); 2: a few over; 1: solved. A hint takes one off, never the last.
        public static int StarsFor(int par, double moves, bool hinted)
        {
            int s = moves <= par ? 3 : moves <= TwoStarMoves(par) ? 2 : 1;
            return Math.Max(1, s - (hinted ? 1 : 0));
        }

        static readonly double[] STAR_MULT = { 0, 1, 1.5, 2 };

        public static double CoinsFor(LevelSpec spec, double par, int stars)
        {
            double b = 6 + 2 * spec.N + 0.6 * par + (spec.Goal == "picture" ? 3 : 0) + (spec.Clock ? 4 : 0);
            return Js.Round(b * STAR_MULT[stars] * (1 + 0.15 * spec.Tier));
        }

        // The player's XP for a win: Squish Sort's formula, by the level number. A hint's lost star costs XP too.
        public static double XpFor(LevelSpec spec, double stars) =>
            Js.Round((10 + Math.Floor(spec.Lv / 2.0) + 5 * spec.Tier) * (0.6 + 0.2 * stars));

        // --- Blitz -----------------------------------------------------------------------
        //
        // Ten puzzles in a row on one clock. They grow from 3 squishies on 3 cushions to 7 on 4, all scrambled, some
        // with a goal card.

        sealed class BlitzDef
        {
            public int N, K, Tier;
            public int[] Par;
            public string Goal;
        }

        static readonly BlitzDef[] BLITZ =
        {
            new BlitzDef { N = 3, K = 3, Tier = 0, Par = new[] { 4, 6 } },
            new BlitzDef { N = 3, K = 3, Tier = 0, Par = new[] { 5, 7 } },
            new BlitzDef { N = 4, K = 3, Tier = 0, Par = new[] { 6, 9 } },
            new BlitzDef { N = 4, K = 3, Tier = 1, Par = new[] { 8, 11 } },
            new BlitzDef { N = 4, K = 3, Tier = 1, Par = new[] { 9, 12 }, Goal = "picture" },
            new BlitzDef { N = 5, K = 4, Tier = 1, Par = new[] { 7, 9 } },
            new BlitzDef { N = 5, K = 4, Tier = 2, Par = new[] { 8, 10 }, Goal = "picture" },
            new BlitzDef { N = 6, K = 4, Tier = 2, Par = new[] { 10, 12 } },
            new BlitzDef { N = 6, K = 4, Tier = 2, Par = new[] { 11, 13 }, Goal = "picture" },
            new BlitzDef { N = 7, K = 4, Tier = 3, Par = new[] { 13, 16 } },
        };

        public static readonly int BLITZ_ROUNDS = BLITZ.Length;
        // the best answers add up to about 93 moves: some 2.6 s a move
        public const int BLITZ_MS = 4 * 60 * 1000;
        public const int BLITZ_COINS = 800;
        // a won run's XP: config/levels `xp.blitz.stack` (this by default: StackXp.Rules.BlitzStack)
        public const int BLITZ_XP = 200;

        // Puzzle i (0-9) at the Blitz skill, as a level spec (Engine.MakePuzzle): a skill step moves its par range 2
        // moves either way.
        public static LevelSpec BlitzSpec(int i, double skill = 0)
        {
            var b = BLITZ[i];
            int shift = SkillShift(skill);
            return new LevelSpec
            {
                Lv = i + 1,
                Round = i + 1,
                Band = 0,
                N = b.N,
                K = b.K,
                Tier = Math.Max(0, Math.Min(3, b.Tier + shift)),
                BaseTier = b.Tier,
                Start = "scrambled",
                Goal = b.Goal ?? "star",
                Par = new[] { Math.Max(2, b.Par[0] + 2 * shift), b.Par[1] + 2 * shift },
                Clock = false,
                News = null,
            };
        }

        // The fields to write after a Blitz run ends (won or not), and what it paid. `ms` matters only for a win.
        public static StackOutcome AfterBlitz(IDictionary<string, object> profile, bool won, double reached, double ms)
        {
            var rec = Record(profile);
            var update = new Dictionary<string, object>
            {
                { "stack.bSkill", ClampSkill(rec.BSkill + (won ? 0.4 : reached >= 6 ? 0 : -0.3)) },
                { "stack.blitz.reached", Math.Max(rec.Blitz.Reached, reached) },
            };
            if (!won) return new StackOutcome { Update = update, Coins = 0, Xp = 0, LevelUps = new List<int>() };
            update["stack.blitz.wins"] = rec.Blitz.Wins + 1;
            if (rec.Blitz.BestMs == 0 || double.IsNaN(rec.Blitz.BestMs) || ms < rec.Blitz.BestMs) update["stack.blitz.bestMs"] = ms;
            double xp;
            PlayerLevel before, after;
            List<int> ups;
            StackXp.AddXp(profile, StackXp.Rules.BlitzStack, out xp, out before, out after, out ups);
            return new StackOutcome { Update = update, Coins = BLITZ_COINS, Xp = xp, Before = before, After = after, LevelUps = ups };
        }

        // --- the profile's record -----------------------------------------------------------

        public static StackRecord Record(IDictionary<string, object> profile)
        {
            var s = Js.Get(profile, "stack") as IDictionary<string, object>;
            var blitz = new BlitzRecord();
            var sb = Js.Get(s, "blitz") as IDictionary<string, object>;
            if (sb != null)
            {
                object v;
                // { reached: 0, bestMs: 0, wins: 0, ...s.blitz }: a null that's there stays null (it counts as 0)
                if (sb.TryGetValue("reached", out v)) blitz.Reached = Js.ToNum(v);
                if (sb.TryGetValue("bestMs", out v)) blitz.BestMs = Js.ToNum(v);
                if (sb.TryGetValue("wins", out v)) blitz.Wins = Js.ToNum(v);
            }
            var best = Js.Get(s, "best") as IDictionary<string, object>;
            return new StackRecord
            {
                Lv = Math.Max(1, Math.Min(LEVELS, Js.ToNum(Js.Or(Js.Get(s, "lv"), 1.0)))),
                Best = best ?? new Dictionary<string, object>(),
                Skill = Js.ToNum(Js.Or(Js.Get(s, "skill"), 0.0)),
                Plays = Js.ToNum(Js.Or(Js.Get(s, "plays"), 0.0)),
                Wins = Js.ToNum(Js.Or(Js.Get(s, "wins"), 0.0)),
                Seen = Js.Truthy(Js.Get(s, "seen")),
                BSkill = Js.ToNum(Js.Or(Js.Get(s, "bSkill"), 0.0)),
                Blitz = blitz,
            };
        }

        static string Key(int lv) => lv.ToString(CultureInfo.InvariantCulture);

        // total stars won
        public static double StarsOf(StackRecord rec)
        {
            double a = 0;
            foreach (var kv in rec.Best) a += Js.ToNum(Js.Or(kv.Value, 0.0));
            return a;
        }

        // levels beaten
        public static double DoneOf(StackRecord rec) =>
            rec.Lv - 1 + (Js.Truthy(Js.Get(rec.Best, Js.Int(LEVELS))) ? 1 : 0);

        // The fields to write after a level, and what it paid: coins, the player's XP (half on a replay: winXp) and
        // the levels it reached (Before / After: the result's XP bar).
        public static StackOutcome AfterLevel(IDictionary<string, object> profile, LevelSpec spec, int par, bool won,
            double moves, bool hinted)
        {
            var rec = Record(profile);
            int stars = won ? StarsFor(par, moves, hinted) : 0;
            var update = new Dictionary<string, object>
            {
                { "stack.plays", rec.Plays + 1 },
                { "stack.seen", true },
                { "stack.skill", NextSkill(rec.Skill, won, stars, hinted) },
            };
            if (!won) return new StackOutcome { Update = update, Coins = 0, Xp = 0, LevelUps = new List<int>(), Stars = 0, Unlocked = false };
            double coins = CoinsFor(spec, par, stars);
            string lvKey = Key(spec.Lv);
            object bestRaw = Js.Or(Js.Get(rec.Best, lvKey), 0.0); // rec.best[spec.lv] || 0
            bool hadBest = Js.Truthy(bestRaw);
            double best = Js.ToNum(bestRaw);
            double xpWon = StackXp.WinXp(StackXp.GameXp(XpFor(spec, stars)), hadBest ? StackXp.GameXp(XpFor(spec, best)) : (double?)null);
            update["stack.wins"] = rec.Wins + 1;
            if (stars > best) update["stack.best." + lvKey] = (double)stars;
            bool unlocked = spec.Lv == rec.Lv && rec.Lv < LEVELS;
            if (unlocked) update["stack.lv"] = rec.Lv + 1;
            double xp;
            PlayerLevel before, after;
            List<int> ups;
            StackXp.AddXp(profile, xpWon, out xp, out before, out after, out ups);
            return new StackOutcome { Update = update, Coins = coins, Xp = xp, Before = before, After = after, LevelUps = ups, Stars = stars, Unlocked = unlocked };
        }

        // 0:42
        public static string Clock(double ms)
        {
            double s = Math.Max(0, Math.Ceiling(ms / 1000));
            return Js.Int(Math.Floor(s / 60)) + ":" + Js.Int(s % 60).PadLeft(2, '0');
        }
    }
}
