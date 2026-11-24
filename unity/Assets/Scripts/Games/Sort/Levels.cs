// Squish Sort's levels, difficulty, scoring and rewards, and the profile's
// `sort` record they're saved in: ported from src/sort/levels.js
// (SQUISH_SORT.md). Pure functions: the screen writes what they return.
//
// Profiles are the Firestore profile as plain data: IDictionary<string,
// object> with numbers (any numeric type), bools, null and nested
// IDictionary<string, object> maps. The updates returned are Firestore
// field-path patches ('sort.fridge.lv' ...) with double and bool values.
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Games.Sort
{
    // a level of LEVEL_LIST: { band, model, rows, cols, base, tier, first, more }
    public sealed class LevelInfo
    {
        public int Band;
        public int Model;
        public int Rows;
        public int Cols;
        public int Base;
        public int Tier;
        public bool First;
        public bool More;
    }

    // levelSpec's (and blitzSpec's: Round) result. MakeBoard reads Rows,
    // Cols, Count, Foods, Decoys, Swaps and Mixed.
    public sealed class LevelSpec
    {
        public int Lv;
        public int Band;
        public int Model;
        public bool First;
        public bool More;
        public int Rows;
        public int Cols;
        public int Tier;
        public int BaseTier;
        public int Count;
        public int Foods;
        public int Decoys;
        public int Swaps;
        public int Mixed;
        public int PeekMs;
        public int LimitMs;
        public int ParMs;
        // blitzSpec only (1-10); null on a Regular level
        public int? Round;

        public LevelSpec Clone() => (LevelSpec)MemberwiseClone();
    }

    public sealed class ThemeRecord
    {
        // (a number as stored, clamped to 1-50; not always an integer)
        public double Lv;
        // the stored map, { "<level>": stars } (shared with the profile, as in JS)
        public IDictionary<string, object> Best;
        public double Skill;
    }

    public sealed class BlitzRecord
    {
        // null: stored as null (the JS keeps the stored null; arithmetic
        // reads it as 0). Top: the most rounds cleared in one run (the endless
        // Blitz, 2026-11-17), Runs: how many runs; Reached / BestMs / Wins
        // were the ten-round runs'
        public double? Top;
        public double? Runs;
        public double? Reached;
        public double? BestMs;
        public double? Wins;
    }

    public sealed class SortRecord
    {
        public ThemeRecord Fridge;
        public double Plays;
        public double Wins;
        public bool Seen;
        public double BSkill;
        public BlitzRecord Blitz;

        public ThemeRecord Of(string theme)
        {
            if (theme == "fridge") return Fridge;
            throw new ArgumentException("not a Squish Sort theme: " + theme, nameof(theme));
        }
    }

    // afterLevel's / afterBlitz's result. Before / After are null on a loss
    // (the JS leaves them out); Stars / Unlocked are afterLevel's only.
    public sealed class SortOutcome
    {
        public Dictionary<string, object> Update = new Dictionary<string, object>();
        public double Coins;
        public double Xp;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
        public List<int> LevelUps = new List<int>();
        public double Stars;
        public bool Unlocked;
        // afterBlitz: the run is the player's new record
        public bool NewTop;
    }

    public static class Levels
    {
        public const int LEVELS = 50;

        sealed class Step { public int Rows, Base; public int[] Tiers; public Step(int rows, int b, params int[] tiers) { Rows = rows; Base = b; Tiers = tiers; } }
        sealed class ModelSize { public int Cols; public Step[] Steps; public ModelSize(int cols, params Step[] steps) { Cols = cols; Steps = steps; } }

        // the seven containers, small to very very large (models.js)
        static readonly ModelSize[] MODEL_SIZES =
        {
            new ModelSize(3, new Step(1, 2, 0, 0), new Step(2, 3, 0, 0, 0)), //  1-5   SMALL
            new ModelSize(3, new Step(3, 3, 1, 0, 1), new Step(4, 4, 0, 1, 1)), //  6-11  MEDIUM
            new ModelSize(4, new Step(3, 5, 0, 1, 1), new Step(4, 6, 1, 2, 1, 2)), // 12-18  BIG
            new ModelSize(4, new Step(5, 7, 0, 1, 2), new Step(6, 7, 1, 2, 2, 3)), // 19-25  LARGE
            new ModelSize(5, new Step(5, 8, 1, 1, 2), new Step(6, 8, 1, 2, 3, 2)), // 26-32  EXTRA LARGE
            new ModelSize(5, new Step(7, 9, 1, 2, 2, 3), new Step(8, 9, 1, 2, 3, 2, 3)), // 33-41  XXL
            new ModelSize(6, new Step(7, 10, 1, 2, 3, 2), new Step(8, 10, 2, 3, 2, 3, 3)), // 42-50  VERY VERY LARGE
        };

        public static readonly IReadOnlyList<LevelInfo> LEVEL_LIST = BuildList();
        // the first level of each model
        public static readonly IReadOnlyList<int> MODEL_STARTS = BuildStarts();

        static List<LevelInfo> BuildList()
        {
            var list = new List<LevelInfo>();
            int bands = 0;
            for (int model = 0; model < MODEL_SIZES.Length; model++)
            {
                var m = MODEL_SIZES[model];
                for (int k = 0; k < m.Steps.Length; k++)
                {
                    var st = m.Steps[k];
                    int band = bands++;
                    for (int j = 0; j < st.Tiers.Length; j++)
                        list.Add(new LevelInfo { Band = band, Model = model, Rows = st.Rows, Cols = m.Cols, Base = st.Base, Tier = st.Tiers[j], First = k == 0 && j == 0, More = k > 0 && j == 0 });
                }
            }
            return list;
        }

        static List<int> BuildStarts()
        {
            var s = new List<int>();
            for (int i = 0; i < LEVEL_LIST.Count; i++) if (LEVEL_LIST[i].First) s.Add(i + 1);
            return s;
        }

        public static readonly IReadOnlyList<string> TIER_NAMES = new[] { "EASY", "MEDIUM", "HARD", "EXPERT" };
        public static readonly IReadOnlyList<string> TIER_COLORS = new[] { "#3ddc97", "#5fb8ff", "#ff8a4a", "#e01e4a" };
        public const int HEARTS = 3;

        // The twists, by the tier: medium has one, hard two, expert all three.
        static readonly string[] TWISTS = { "decoys", "mixed", "swaps" };
        static List<string> TwistsFor(int lv, int tier)
        {
            if (tier <= 0) return new List<string>();
            string first = TWISTS[lv % 3];
            if (tier == 1) return new List<string> { first };
            if (tier == 2)
            {
                var l = new List<string>();
                foreach (var t in TWISTS) if (t != TWISTS[(lv + 1) % 3]) l.Add(t);
                return l;
            }
            return new List<string>(TWISTS);
        }

        // Level `lv` (1-50; anything else is clamped, NaN or 0 is level 1) at a skill.
        public static LevelSpec LevelSpec(double lv, double skill = 0)
        {
            double f = Math.Floor(lv);
            if (f == 0 || double.IsNaN(f)) f = 1;
            int L = (int)Math.Max(1, Math.Min(LEVELS, f));
            var b = LEVEL_LIST[L - 1];
            int tier = Math.Max(0, Math.Min(3, b.Tier + SkillShift(skill)));
            int slots = b.Rows * b.Cols;
            int count = Math.Min(slots - 1, b.Base + tier);
            // (a spot or more left empty: one on the small shelves, three on big ones)
            int foods = Math.Max(0, Math.Min(slots - count - (slots <= 8 ? 1 : 3), (int)JsMath.Round(slots * 0.4) + tier));
            var tw = TwistsFor(L, tier);
            int decoys = tw.Contains("decoys") ? Math.Min(3, 1 + (tier == 3 ? 1 : 0) + (b.Model >= 4 ? 1 : 0)) : 0;
            int swaps = tw.Contains("swaps") ? 1 + (tier == 3 ? 1 : 0) : 0;
            int mixed = tw.Contains("mixed") ? Math.Min(count - 1, 2 + (tier == 3 ? 1 : 0) + (b.Model >= 4 ? 1 : 0)) : 0;
            int peekMs = Math.Max(3800, 5000 + Math.Max(0, count - 5) * 350 - tier * 300);
            return new LevelSpec
            {
                Lv = L,
                Band = b.Band,
                Model = b.Model,
                First = b.First,
                More = b.More,
                Rows = b.Rows,
                Cols = b.Cols,
                Tier = tier,
                BaseTier = b.Tier,
                Count = count,
                Foods = foods,
                Decoys = decoys,
                Swaps = swaps,
                Mixed = mixed,
                PeekMs = peekMs,
                // to put them all back: generous, but it runs out
                LimitMs = (20 + 4 * count) * 1000,
                // under this with no mistakes: 3 stars
                ParMs = (int)JsMath.Round((5 + 2.6 * count + 1.5 * mixed + 1.5 * decoys) * 1000),
            };
        }

        // --- adaptive difficulty ---------------------------------------------------

        public const double SKILL_MIN = -2;
        public const double SKILL_MAX = 2;
        public static int SkillShift(double skill) => skill <= -1 ? -1 : skill >= 1.2 ? 1 : 0;
        static double ClampSkill(double s) => JsMath.Round(JsMath.Max(SKILL_MIN, JsMath.Min(SKILL_MAX, s)) * 100) / 100;

        // After a level: fast clean wins raise it, mistakes and fails lower it.
        public static double NextSkill(double skill, bool won, double stars = 0, double mistakes = 0)
        {
            if (!won) return ClampSkill(skill - 0.5);
            double gain = stars == 3 ? 0.35 : stars == 2 ? 0.15 : 0;
            return ClampSkill(skill + gain - 0.12 * JsMath.Min(3, mistakes));
        }

        // --- scoring ---------------------------------------------------------------

        // 3: no mistakes and under the par time; 2: no more than one mistake;
        // 1: won. A null is a field left out (undefined in JS): no mistakes for
        // `!mistakes` but not "<= 1"; a missing time is never under par.
        public static int StarsFor(LevelSpec spec, double? mistakes, double? ms)
        {
            bool noMistakes = mistakes == null || mistakes.Value == 0 || double.IsNaN(mistakes.Value);
            if (noMistakes && ms != null && ms.Value <= spec.ParMs) return 3;
            if (mistakes != null && mistakes.Value <= 1) return 2;
            return 1;
        }

        static readonly double[] STAR_MULT = { 0, 1, 1.5, 2 };
        static double StarMult(double stars)
        {
            if (stars == 0 || stars == 1 || stars == 2 || stars == 3) return STAR_MULT[(int)stars];
            return double.NaN; // STAR_MULT[stars]: undefined
        }

        public static double CoinsFor(LevelSpec spec, double stars)
        {
            int b = 6 + 3 * spec.Count + 4 * spec.Decoys + 6 * spec.Swaps + 3 * spec.Mixed;
            return JsMath.Round(b * StarMult(stars) * (1 + 0.15 * spec.Tier));
        }

        // The player's XP for a win.
        public static double XpFor(LevelSpec spec, double stars) => JsMath.Round((10 + Math.Floor(spec.Lv / 2.0) + 5 * spec.Tier) * (0.6 + 0.2 * stars));

        // --- Blitz -------------------------------------------------------------------

        // BLITZ MODE (2026-11-17, the user: "its unlimited and it should behave
        // like the others, 1 fail means you failed it all"): round after round
        // with no end, each on its own clock (only while you sort). A mistake,
        // or the round's clock running out, stops the run: GAME OVER unless
        // it's saved (an ad once a run, or gems). Every round cleared pays;
        // the record is the most rounds cleared in one run (sort.blitz.top).

        // the rounds climb as the first Blitz's ten did, on through the XXL
        // fridge to the very very large one; then its eight-shelf levels in
        // turn, for good
        static readonly int[] BLITZ_RAMP = { 2, 5, 8, 11, 14, 17, 20, 24, 28, 33, 36, 39, 42 };
        static readonly int[] BLITZ_LAST = { 46, 47, 48, 49, 50 };
        // a round's clock: a third more than the level's 3-star time, in whole
        // seconds; past the climb each one 3% shorter than the last, down to
        // three quarters
        public const double BLITZ_PAR = 1.33;

        // Round `i` of a run (0 = the first) at the Blitz skill: that Regular
        // level's spec, its round, and its own clock (LimitMs). (A round before
        // the first: level 1's spec, as the JS's undefined level.)
        public static LevelSpec BlitzSpec(int i, double skill = 0)
        {
            int past = Math.Max(0, i - BLITZ_RAMP.Length + 1);
            double lv = i < BLITZ_RAMP.Length ? (i >= 0 ? BLITZ_RAMP[i] : double.NaN) : BLITZ_LAST[(i - BLITZ_RAMP.Length) % BLITZ_LAST.Length];
            var s = LevelSpec(lv, skill);
            s.Round = i + 1;
            s.LimitMs = (int)(Math.Ceiling(s.ParMs * BLITZ_PAR / 1000 * Math.Max(0.75, 1 - 0.03 * past)) * 1000);
            return s;
        }

        // coins for a round cleared: twice what the same level pays Regular
        // with 1 star (as Squishdoku's Blitz boards)
        public static double BlitzCoins(LevelSpec spec) => 2 * CoinsFor(spec, 1);

        // What `cleared` rounds pay: their coins, and the player's XP
        // (config/levels `xp.blitz.sort` is the XP for ten rounds)
        public static (double coins, double xp) BlitzPrize(double cleared, double skill = 0)
        {
            double coins = 0;
            for (int i = 0; i < cleared; i++) coins += BlitzCoins(BlitzSpec(i, skill));
            return (coins, JsMath.Round(PlayerXp.BlitzSort / 10 * cleared));
        }

        // The fields to write when a Blitz run is over (`cleared`: the rounds
        // it cleared), and what it paid. The skill moves up after a run of 10
        // or more, down after one of under 5.
        public static SortOutcome AfterBlitz(IDictionary<string, object> profile, double cleared)
        {
            var rec = Record(profile);
            var o = new SortOutcome();
            o.Update["sort.bSkill"] = ClampSkill(rec.BSkill + (cleared >= 10 ? 0.4 : cleared < 5 ? -0.3 : 0));
            double runs = rec.Blitz.Runs ?? 0;
            o.Update["sort.blitz.runs"] = (double.IsNaN(runs) || runs == 0 ? 0 : runs) + 1;
            o.Update["sort.seen"] = true;
            double top = rec.Blitz.Top ?? 0;
            o.NewTop = cleared > top;
            if (o.NewTop) o.Update["sort.blitz.top"] = cleared;
            if (cleared == 0 || double.IsNaN(cleared)) { o.NewTop = false; return o; }
            // the skill the run's rounds were dealt at (BlitzSpec), so the coins match what was played
            var (coins, xp) = BlitzPrize(cleared, rec.BSkill);
            Apply(o, PlayerXp.AddXp(profile, xp));
            o.Coins = coins;
            return o;
        }

        static void Apply(SortOutcome o, XpGain g)
        {
            o.Xp = g.Xp;
            o.Before = g.Before;
            o.After = g.After;
            o.LevelUps = g.LevelUps;
        }

        // --- the profile's record ----------------------------------------------------

        // (only the fridge since 2026-11-17: "delete the toy cupboard")
        public static readonly IReadOnlyList<string> THEME_KEYS = new[] { "fridge" };

        static ThemeRecord Of(IDictionary<string, object> s, string k)
        {
            var t = JsMath.AsMap(JsMath.Get(s, k));
            return new ThemeRecord
            {
                Lv = JsMath.Max(1, JsMath.Min(LEVELS, JsMath.OrNum(JsMath.Get(t, "lv"), 1))),
                Best = JsMath.AsMap(JsMath.Get(t, "best")) ?? new Dictionary<string, object>(),
                Skill = JsMath.OrNum(JsMath.Get(t, "skill"), 0),
            };
        }

        static double? BlitzField(IDictionary<string, object> b, string key)
        {
            bool found;
            object v = JsMath.Get(b, key, out found);
            if (!found) return 0;
            if (v == null) return null;
            return JsMath.ToNum(v);
        }

        public static SortRecord Record(IDictionary<string, object> profile)
        {
            var s = JsMath.AsMap(JsMath.Get(profile, "sort")) ?? new Dictionary<string, object>();
            var b = JsMath.AsMap(JsMath.Get(s, "blitz"));
            return new SortRecord
            {
                Fridge = Of(s, "fridge"),
                Plays = JsMath.OrNum(JsMath.Get(s, "plays"), 0),
                Wins = JsMath.OrNum(JsMath.Get(s, "wins"), 0),
                Seen = JsMath.Truthy(JsMath.Get(s, "seen")),
                BSkill = JsMath.OrNum(JsMath.Get(s, "bSkill"), 0),
                Blitz = new BlitzRecord { Top = BlitzField(b, "top"), Runs = BlitzField(b, "runs"), Reached = BlitzField(b, "reached"), BestMs = BlitzField(b, "bestMs"), Wins = BlitzField(b, "wins") },
            };
        }

        static double BestOf(ThemeRecord t, double lv) => JsMath.OrNum(JsMath.Get(t.Best, JsMath.Key(lv)), 0);

        // total stars won in a theme
        public static double StarsIn(SortRecord rec, string theme)
        {
            double a = 0;
            foreach (var n in OrderedValues(rec.Of(theme).Best)) a = a + JsMath.OrNum(n, 0);
            return a;
        }

        // Object.values order: integer-like keys ascending, then the rest as inserted
        static IEnumerable<object> OrderedValues(IDictionary<string, object> map)
        {
            var ints = new List<KeyValuePair<double, object>>();
            var rest = new List<object>();
            foreach (var e in map)
            {
                uint u;
                if (uint.TryParse(e.Key, NumberStyles.None, CultureInfo.InvariantCulture, out u) && u != uint.MaxValue && u.ToString(CultureInfo.InvariantCulture) == e.Key)
                    ints.Add(new KeyValuePair<double, object>(u, e.Value));
                else rest.Add(e.Value);
            }
            ints.Sort((x, y) => x.Key.CompareTo(y.Key));
            foreach (var e in ints) yield return e.Value;
            foreach (var v in rest) yield return v;
        }

        // every level of a theme beaten
        public static double DoneIn(SortRecord rec, string theme)
        {
            var t = rec.Of(theme);
            return t.Lv - 1 + (JsMath.Truthy(JsMath.Get(t.Best, JsMath.Key(LEVELS))) ? 1 : 0);
        }

        // The fields to write after a level of `theme`, and what it paid.
        // result: won, mistakes and ms (null: left out, as undefined in JS).
        public static SortOutcome AfterLevel(IDictionary<string, object> profile, string theme, LevelSpec spec, bool won, double? mistakes, double? ms)
        {
            var rec = Record(profile);
            var t = rec.Of(theme);
            int stars = won ? StarsFor(spec, mistakes, ms) : 0;
            var o = new SortOutcome();
            double m = mistakes == null || double.IsNaN(mistakes.Value) ? 0 : mistakes.Value;
            o.Update["sort.plays"] = rec.Plays + 1;
            o.Update["sort.seen"] = true;
            o.Update["sort." + theme + ".skill"] = NextSkill(t.Skill, won, stars, m);
            if (!won) return o;
            double coins = CoinsFor(spec, stars);
            double best = BestOf(t, spec.Lv);
            double xp = PlayerXp.WinXp(PlayerXp.GameXp(XpFor(spec, stars)), best != 0 && !double.IsNaN(best) ? PlayerXp.GameXp(XpFor(spec, best)) : (double?)null);
            o.Update["sort.wins"] = rec.Wins + 1;
            if (stars > best) o.Update["sort." + theme + ".best." + JsMath.Key(spec.Lv)] = (double)stars;
            bool unlocked = spec.Lv == t.Lv && t.Lv < LEVELS;
            if (unlocked) o.Update["sort." + theme + ".lv"] = t.Lv + 1;
            o.Coins = coins;
            Apply(o, PlayerXp.AddXp(profile, xp));
            o.Stars = stars;
            o.Unlocked = unlocked;
            return o;
        }

        // 0:42
        public static string Clock(double ms)
        {
            double s = JsMath.Max(0, Math.Ceiling(ms / 1000));
            long ss = (long)s;
            return (ss / 60).ToString(CultureInfo.InvariantCulture) + ":" + (ss % 60).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
        }
    }
}
