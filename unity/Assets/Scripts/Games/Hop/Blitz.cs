// Squish Hop's BLITZ MODE rules (develop's src/hop/blitz.js and levels.js blitzPrize / afterBlitz; 2026-11-16, the
// user: "the same thing" as Squishdoku's): fresh small boards one after another, growing (a climb of twelve grids from
// 3×3 to 6×5, friends and arrows coming in), then 6×5 boards for good, each on its own short clock. A board is a random
// walk through its grid that visits about `fill` of the cells (S at its start, the ★ at its end, the friends and arrows
// on it), so it always has a full clear: the walk. Every board cleared pays (BLITZ_COINS by its grid). Pure functions,
// checked against the JS by tools/unity/games/hop (the same seeds give the same boards). No UnityEngine here.
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Games.Hop
{
    public sealed class BlitzShape { public int W, H, F, A, Past; public double Fill; }

    // afterBlitz(): { update, coins, xp, before, after, levelUps, newTop }
    public sealed class AfterBlitzResult
    {
        public Dictionary<string, object> Update;
        public int Coins;
        public double Xp;
        public PlayerLevelInfo Before, After;
        public List<int> LevelUps;
        public bool NewTop;
    }

    public static class Blitz
    {
        // the climb (w × h, how much of the grid the walk fills, friends, arrows), then the two past it in turn
        static readonly BlitzShape[] RAMP =
        {
            S(3, 3, 1, 0, 0), S(4, 3, 1, 0, 0), S(4, 3, 0.92, 1, 0), S(4, 4, 0.88, 0, 0), S(4, 4, 0.94, 1, 0), S(5, 4, 0.85, 1, 1),
            S(5, 4, 0.9, 2, 0), S(5, 4, 0.9, 1, 2), S(5, 5, 0.84, 1, 1), S(5, 5, 0.88, 2, 2), S(5, 5, 0.9, 2, 2), S(6, 5, 0.85, 2, 2),
        };
        static readonly BlitzShape[] PAST = { S(6, 5, 0.9, 2, 3), S(6, 5, 0.93, 3, 2) };
        static BlitzShape S(int w, int h, double fill, int f, int a) => new BlitzShape { W = w, H = h, Fill = fill, F = f, A = a };
        public static readonly int BLITZ_RAMP = RAMP.Length;

        // coins for a board cleared, by its grid's cells
        public static readonly IReadOnlyDictionary<int, int> BLITZ_COINS = new Dictionary<int, int> { { 9, 25 }, { 12, 35 }, { 16, 45 }, { 20, 60 }, { 25, 75 }, { 30, 95 } };

        // board i's grid (0 = the first), and how far past the climb it is
        public static BlitzShape ShapeOf(int i)
        {
            int past = Math.Max(0, i - RAMP.Length + 1);
            var s = i < RAMP.Length ? RAMP[i] : PAST[i % 2];
            return new BlitzShape { W = s.W, H = s.H, Fill = s.Fill, F = s.F, A = s.A, Past = past };
        }

        // a board's clock: five seconds and one a hop, 3 % shorter a board past the climb, down to three quarters
        public static int BlitzMs(int hops, int past = 0) => (int)(Math.Ceiling((5 + hops) * Math.Max(0.75, 1 - 0.03 * past)) * 1000);

        // mulberry32, as blitz.js seeded()
        public static Func<double> Seeded(int a)
        {
            return () =>
            {
                unchecked
                {
                    a = a + 0x6d2b79f5;
                    int t = (a ^ (int)((uint)a >> 15)) * (1 | a);
                    t = (t + (t ^ (int)((uint)t >> 7)) * (61 | t)) ^ t;
                    return (uint)(t ^ (int)((uint)t >> 14)) / 4294967296.0;
                }
            };
        }

        // a walk through `n` cells of the w × h grid, each step to a neighbour not yet visited, the ones with the fewest
        // ways on first (a little randomness to break ties), backing up when stuck; null if it gives up (3000 steps)
        static List<int> MakeWalk(int w, int h, int n, Func<double> rnd)
        {
            var used = new bool[w * h];
            var walk = new List<int>();
            int steps = 0;
            bool abort = false;
            List<int> Near(int i)
            {
                int x = i % w, y = i / w;
                var o = new List<int>(4);
                if (y > 0) o.Add(i - w);
                if (x < w - 1) o.Add(i + 1);
                if (y < h - 1) o.Add(i + w);
                if (x > 0) o.Add(i - 1);
                return o;
            }
            bool Go(int c)
            {
                if (++steps > 3000) { abort = true; return false; }
                walk.Add(c);
                used[c] = true;
                if (walk.Count == n) return true;
                // (JS: map then a stable sort by the key)
                var cand = Near(c).Where(j => !used[j]).Select(j => (j, key: Near(j).Count(k => !used[k]) + rnd() * 1.6)).ToList().OrderBy(p => p.key).ToList();
                foreach (var (j, _) in cand)
                {
                    if (Go(j)) return true;
                    if (abort) return false;
                }
                walk.RemoveAt(walk.Count - 1);
                used[c] = false;
                return false;
            }
            bool ok = Go((int)Math.Floor(rnd() * w * h));
            return ok && !abort ? walk : null;
        }

        static int DirOf(int w, int a, int b) => b == a - w ? 0 : b == a + 1 ? 1 : b == a + w ? 2 : 3;
        static readonly char[] ARROW_CH = { '^', '>', 'v', '<' };

        // the rows without the all-wall rows and columns round them
        static string[] Crop(List<string> rows)
        {
            int top = 0, bot = rows.Count - 1;
            while (top < bot && rows[top].All(ch => ch == '#')) top++;
            while (bot > top && rows[bot].All(ch => ch == '#')) bot--;
            var r = rows.GetRange(top, bot - top + 1);
            int l = 0, rt = r[0].Length - 1;
            while (l < rt && r.All(s => s[l] == '#')) l++;
            while (rt > l && r.All(s => s[rt] == '#')) rt--;
            return r.Select(s => s.Substring(l, rt - l + 1)).ToArray();
        }

        /// <summary>blitz.js makeBoard: a board of `shape` from `rnd` and its full clear (directions); a walk that fails,
        /// or too short for the friends and arrows, is tried again (400 times).</summary>
        public static (string[] map, int[] sol) MakeBoard(BlitzShape shape, Func<double> rnd)
        {
            int w = shape.W, h = shape.H, F = shape.F, A = shape.A;
            int n = Math.Max(4, (int)Js.Round(w * h * shape.Fill));
            for (int tries = 0; tries < 400; tries++)
            {
                var walk = MakeWalk(w, h, n, rnd);
                if (walk == null) continue;
                var cells = Enumerable.Repeat('#', w * h).ToArray();
                foreach (var c in walk) cells[c] = '.';
                cells[walk[0]] = 'S';
                cells[walk[walk.Count - 1]] = 'G';
                var mid = new List<(int c, int k)>();
                for (int k = 1; k < walk.Count - 1; k++) mid.Add((walk[k], k));
                for (int i = mid.Count - 1; i > 0; i--)
                {
                    int j = (int)Math.Floor(rnd() * (i + 1));
                    (mid[i], mid[j]) = (mid[j], mid[i]);
                }
                if (mid.Count < F + A) continue;
                for (int i = 0; i < F; i++) cells[mid[i].c] = 'F';
                for (int i = F; i < F + A; i++) cells[mid[i].c] = ARROW_CH[DirOf(w, mid[i].c, walk[mid[i].k + 1])];
                var rows = new List<string>();
                for (int y = 0; y < h; y++) rows.Add(new string(cells, y * w, w));
                var map = Crop(rows);
                var sol = new int[walk.Count - 1];
                for (int k = 0; k + 1 < walk.Count; k++) sol[k] = DirOf(w, walk[k], walk[k + 1]);
                var lv = Engine.Parse(map);
                var st = Engine.NewState(lv);
                bool ok = true;
                foreach (var d in sol)
                {
                    var m = Engine.TryMove(lv, st, d);
                    if (!m.Ok) { ok = false; break; }
                    st = m.St;
                }
                if (ok && st.Done && Engine.LeftOf(lv, st.Life) == 0) return (map, sol);
            }
            throw new InvalidOperationException($"no Blitz board for {w}x{h}");
        }

        /// <summary>blitz.js blitzSpec: board i of a run (0 = the first) from the run's seed, as a level's spec (played in
        /// the Dance Room by day), with its clock and its coins.</summary>
        public static LevelSpec BlitzSpec(int i, int seed)
        {
            var shape = ShapeOf(i);
            var (map, sol) = MakeBoard(shape, Seeded(unchecked(seed + i * 7919)));
            var board = Engine.Parse(map);
            var twists = new List<string>();
            if (board.Friends.Length > 0) twists.Add("friends");
            if (board.Arrow.Any(a => a >= 0)) twists.Add("arrows");
            return new LevelSpec
            {
                Lv = i + 1, Blitz = true, Map = map, Tier = i < 3 ? 0 : i < 8 ? 1 : i < RAMP.Length ? 2 : 3, News = null, Sols = 0, Effort = 0,
                Board = board, Sol = sol, Room = "dance", Phase = "day", StageKey = "dance:blitz", Beats = false,
                Cushions = board.Life.Count(x => x > 0), Twists = twists, Size = $"{board.W}×{board.H}",
                Ms = BlitzMs(sol.Length, shape.Past), Coins = BLITZ_COINS[shape.W * shape.H],
            };
        }

        /// <summary>levels.js blitzPrize: what `cleared` boards pay: their coins (by their grid), and the player's XP
        /// (config/levels `xp.blitz.hop` is the XP for ten boards).</summary>
        public static (int coins, double xp) BlitzPrize(int cleared)
        {
            int coins = 0;
            for (int i = 0; i < cleared; i++) { var b = ShapeOf(i); coins += BLITZ_COINS[b.W * b.H]; }
            return (coins, Js.Round(PlayerXp.BlitzHop / 10 * cleared));
        }

        /// <summary>levels.js afterBlitz: the fields to write when a run is over (`cleared`: the boards it cleared), and what
        /// it paid.</summary>
        public static AfterBlitzResult AfterBlitz(IDictionary<string, object> profile, int cleared)
        {
            var rec = Levels.Record(profile);
            var update = new Dictionary<string, object> { { "hop.blitz.runs", Js.ToNumber(rec.BlitzRuns) + 1 }, { "hop.seen", true } };
            bool newTop = cleared > Js.ToNumber(rec.BlitzTop);
            if (newTop) update["hop.blitz.top"] = (double)cleared;
            if (cleared == 0) return new AfterBlitzResult { Update = update, Coins = 0, Xp = 0, LevelUps = new List<int>(), NewTop = false };
            var (coins, xp) = BlitzPrize(cleared);
            var gain = PlayerXp.AddXp(profile, xp);
            return new AfterBlitzResult { Update = update, Coins = coins, NewTop = newTop, Xp = gain.Xp, Before = gain.Before, After = gain.After, LevelUps = gain.LevelUps };
        }
    }
}
