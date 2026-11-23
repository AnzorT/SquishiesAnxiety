// Port of src/squishdoku/engine.js: Squishdoku's puzzles (SQUISHDOKU.md), the "Queens" puzzle. An n×n grid cut into
// n coloured patches; one creature in every row, column and patch, and no two creatures touch, not even corner to
// corner. The same seed makes the same puzzle as the JS, bit for bit (checked by tools/unity/games/squishdoku).
//
// A puzzle is made on the phone, a new one every time:
//   1. place the n creatures (one per row and column, never touching),
//   2. grow one patch out of each creature's cell, at random,
//   3. solve it the way a player would (Grade). Only a puzzle that solves by logic alone is kept, so it has exactly
//      one answer.
// The solver's tricks, easiest first (the grade is the hardest one used): 1 singles, 2 peeks, 3 pairs, 4 groups,
// 5 chains. Effort adds up the moments with no single in sight, each costing its hardest trick (StallCost); the tier
// comes from it: easy (effort ≤ 1), medium (2-3), hard (4-7), expert (8+).
//
// Cells are numbered r * n + c. Pure C#, no Unity dependencies. makePuzzleAsync is not ported: call
// PuzzleMaker.Run(ms) once a frame (or MakePuzzle on a worker thread) instead.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squishdoku
{
    /// <summary>A made board: { n, regions: [n*n patch index], solution: [column per row], grade, effort, tier, steps, seed }.</summary>
    public sealed class Puzzle
    {
        public int N;
        public int[] Regions;
        public int[] Solution;
        public int Grade;
        public int Effort;
        public int Tier;
        public int Steps;
        public long Seed;
    }

    /// <summary>engine.js grade(): { solved, grade, steps, effort, solution } (Solution null when not solved).</summary>
    public sealed class GradeResult
    {
        public bool Solved;
        public int Grade;
        public int Steps;
        public int Effort;
        public int[] Solution;
    }

    public static class Engine
    {
        public static readonly string[] Tiers = { "easy", "medium", "hard", "expert" };

        public static int TierOf(int effort)
        {
            return effort <= 1 ? 0 : effort <= 3 ? 1 : effort <= 7 ? 2 : 3;
        }

        /// <summary>mulberry32, bit-exact with the JS rng(seed) (seed taken mod 2^32, like `seed >>> 0`).</summary>
        public static Func<double> Rng(long seed)
        {
            uint a = unchecked((uint)seed);
            return () =>
            {
                unchecked
                {
                    a = a + 0x6d2b79f5u;
                    uint t = a;
                    t = (t ^ (t >> 15)) * (t | 1u);
                    t ^= t + (t ^ (t >> 7)) * (t | 61u);
                    return (t ^ (t >> 14)) / 4294967296.0;
                }
            };
        }

        static List<T> Shuffled<T>(List<T> list, Func<double> r)
        {
            var a = new List<T>(list);
            for (int i = a.Count - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(r() * (i + 1));
                T tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
            }
            return a;
        }

        // --- 1. the creatures ------------------------------------------------------------

        /// <summary>A column for every row, all different, neighbouring rows at least 2 columns apart. Null if none
        /// exists (n = 2 or 3).</summary>
        public static int[] RandomSolution(int n, Func<double> r)
        {
            var sol = new int[n];
            for (int i = 0; i < n; i++) sol[i] = -1;
            var used = new bool[n];
            var keys = new List<int>(n);
            for (int i = 0; i < n; i++) keys.Add(i);
            bool Place(int row)
            {
                if (row == n) return true;
                foreach (int c in Shuffled(keys, r))
                {
                    if (used[c] || (row > 0 && Math.Abs(sol[row - 1] - c) < 2)) continue;
                    sol[row] = c;
                    used[c] = true;
                    if (Place(row + 1)) return true;
                    used[c] = false;
                }
                return false;
            }
            return Place(0) ? sol : null;
        }

        // --- 2. the patches --------------------------------------------------------------

        // up, down, left, right (the JS order); returns how many went into `out`
        static int Neighbours4(int n, int cell, int[] outBuf)
        {
            int r = cell / n;
            int c = cell % n;
            int k = 0;
            if (r > 0) outBuf[k++] = cell - n;
            if (r < n - 1) outBuf[k++] = cell + n;
            if (c > 0) outBuf[k++] = cell - 1;
            if (c < n - 1) outBuf[k++] = cell + 1;
            return k;
        }

        /// <summary>Patch i starts at row i's creature and grows a cell at a time into free neighbours until the grid
        /// is full; each step picks the patch at random, weighted.</summary>
        public static int[] GrowRegions(int n, int[] sol, Func<double> r)
        {
            var regions = new int[n * n];
            for (int i = 0; i < regions.Length; i++) regions[i] = -1;
            var weights = new double[n];
            for (int i = 0; i < n; i++)
            {
                regions[i * n + sol[i]] = i;
                double roll = r();
                weights[i] = roll < 0.2 ? 0.35 : roll > 0.85 ? 2.6 : 1;
            }
            int free = n * n - n;
            var open = new List<int>[n];
            for (int i = 0; i < n; i++) open[i] = new List<int>();
            var nb = new int[4];
            while (free > 0)
            {
                double total = 0;
                for (int i = 0; i < n; i++) open[i].Clear();
                for (int cell = 0; cell < n * n; cell++)
                {
                    if (regions[cell] < 0) continue;
                    int k = Neighbours4(n, cell, nb);
                    for (int q = 0; q < k; q++) if (regions[nb[q]] < 0) open[regions[cell]].Add(nb[q]);
                }
                for (int i = 0; i < n; i++) if (open[i].Count > 0) total += weights[i];
                double pick = r() * total;
                int reg = 0;
                for (; reg < n; reg++)
                {
                    if (open[reg].Count == 0) continue;
                    pick -= weights[reg];
                    if (pick <= 0) break;
                }
                if (reg >= n)
                {
                    reg = -1;
                    for (int i = 0; i < n; i++) if (open[i].Count > 0) { reg = i; break; }
                }
                var cells = open[reg];
                regions[cells[(int)Math.Floor(r() * cells.Count)]] = reg;
                free--;
            }
            return regions;
        }

        // An answer to the board other than `sol` (column per row), or null.
        static int[] OtherSolution(int n, int[] regions, int[] sol)
        {
            var cols = new bool[n];
            var regs = new bool[n];
            var cur = new int[n];
            bool Go(int row, int prev, bool same)
            {
                if (row == n) return !same;
                for (int c = 0; c < n; c++)
                {
                    int reg = regions[row * n + c];
                    if (cols[c] || regs[reg] || (prev >= 0 && Math.Abs(prev - c) < 2)) continue;
                    cols[c] = regs[reg] = true;
                    cur[row] = c;
                    bool found = Go(row + 1, c, same && c == sol[row]);
                    cols[c] = regs[reg] = false;
                    if (found) return true;
                }
                return false;
            }
            return Go(0, -1, true) ? (int[])cur.Clone() : null;
        }

        // Whether patch `reg` stays in one piece without `cell`.
        static bool ConnectedWithout(int n, int[] regions, int reg, int cell)
        {
            var cells = new List<int>();
            for (int i = 0; i < n * n; i++) if (regions[i] == reg && i != cell) cells.Add(i);
            if (cells.Count == 0) return false;
            var seen = new bool[n * n];
            int seenCount = 1;
            seen[cells[0]] = true;
            var todo = new List<int> { cells[0] };
            var nb = new int[4];
            while (todo.Count > 0)
            {
                int cur = todo[todo.Count - 1];
                todo.RemoveAt(todo.Count - 1);
                int k = Neighbours4(n, cur, nb);
                for (int q = 0; q < k; q++)
                {
                    int x = nb[q];
                    if (x != cell && regions[x] == reg && !seen[x])
                    {
                        seen[x] = true;
                        seenCount++;
                        todo.Add(x);
                    }
                }
            }
            return seenCount == cells.Count;
        }

        /// <summary>Mends random patches until `sol` is the only answer (moving a cell of the other answer's creature
        /// to a neighbouring patch each time). Null if it gets stuck. maxMoves defaults to 6n.</summary>
        public static int[] MakeUnique(int n, int[] regions, int[] sol, Func<double> r, int? maxMoves = null)
        {
            int max = maxMoves ?? 6 * n;
            var regs = (int[])regions.Clone();
            var ours = new HashSet<int>();
            for (int row = 0; row < sol.Length; row++) ours.Add(row * n + sol[row]);
            var nb = new int[4];
            for (int move = 0; move < max; move++)
            {
                int[] alt = OtherSolution(n, regs, sol);
                if (alt == null) return regs;
                var options = new List<int[]>();
                for (int row = 0; row < alt.Length; row++)
                {
                    int cell = row * n + alt[row];
                    if (ours.Contains(cell)) continue;
                    int k = Neighbours4(n, cell, nb);
                    for (int q = 0; q < k; q++)
                    {
                        if (regs[nb[q]] != regs[cell]) options.Add(new[] { cell, regs[nb[q]] });
                    }
                }
                int[] ok = null;
                foreach (var o in Shuffled(options, r))
                {
                    if (ConnectedWithout(n, regs, regs[o[0]], o[0])) { ok = o; break; }
                }
                if (ok == null) return null;
                regs[ok[0]] = ok[1];
            }
            return null;
        }

        // --- checking ----------------------------------------------------------------------

        /// <summary>How many answers a board has (stops at `limit`).</summary>
        public static int CountSolutions(int n, int[] regions, int limit = 2)
        {
            int count = 0;
            var cols = new bool[n];
            var regs = new bool[n];
            bool Go(int row, int prev)
            {
                if (row == n)
                {
                    count++;
                    return count >= limit;
                }
                for (int c = 0; c < n; c++)
                {
                    int reg = regions[row * n + c];
                    if (cols[c] || regs[reg] || (prev >= 0 && Math.Abs(prev - c) < 2)) continue;
                    cols[c] = regs[reg] = true;
                    bool stop = Go(row + 1, c);
                    cols[c] = regs[reg] = false;
                    if (stop) return true;
                }
                return false;
            }
            Go(0, -1);
            return count;
        }

        /// <summary>The cells of `cells` that break a rule (two in a row, column or patch, or two touching), in the
        /// order the JS Set holds them (first added first).</summary>
        public static List<int> Conflicts(int n, int[] regions, IList<int> cells)
        {
            var bad = new List<int>();
            var inBad = new HashSet<int>();
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = i + 1; j < cells.Count; j++)
                {
                    int a = cells[i];
                    int b = cells[j];
                    int ra = a / n;
                    int rb = b / n;
                    int ca = a % n;
                    int cb = b % n;
                    if (ra == rb || ca == cb || regions[a] == regions[b] || (Math.Abs(ra - rb) <= 1 && Math.Abs(ca - cb) <= 1))
                    {
                        if (inBad.Add(a)) bad.Add(a);
                        if (inBad.Add(b)) bad.Add(b);
                    }
                }
            }
            return bad;
        }

        // --- 3. solving like a player ------------------------------------------------------

        sealed class Solver
        {
            public int N;
            public int[][] Units;    // 3n lines: rows, columns, patches
            public int[][] UnitsOf;  // a cell's three lines
            public int[][] Shadows;  // the cells a creature at a cell rules out
            public bool[][] ShadowHas;
        }

        sealed class State
        {
            public bool[] Cand;
            public bool[] Placed;
            public bool[] Done;
            public int Count;

            public State Copy()
            {
                return new State { Cand = (bool[])Cand.Clone(), Placed = (bool[])Placed.Clone(), Done = (bool[])Done.Clone(), Count = Count };
            }
        }

        static Solver MakeSolver(int n, int[] regions)
        {
            var units = new List<int>[3 * n];
            for (int r = 0; r < n; r++)
            {
                units[r] = new List<int>(n);
                for (int c = 0; c < n; c++) units[r].Add(r * n + c);
            }
            for (int c = 0; c < n; c++)
            {
                units[n + c] = new List<int>(n);
                for (int r = 0; r < n; r++) units[n + c].Add(r * n + c);
            }
            for (int g = 0; g < n; g++) units[2 * n + g] = new List<int>();
            for (int cell = 0; cell < n * n; cell++) units[2 * n + regions[cell]].Add(cell);
            var S = new Solver { N = n, Units = new int[3 * n][], UnitsOf = new int[n * n][], Shadows = new int[n * n][], ShadowHas = new bool[n * n][] };
            for (int u = 0; u < 3 * n; u++) S.Units[u] = units[u].ToArray();
            for (int cell = 0; cell < n * n; cell++) S.UnitsOf[cell] = new[] { cell / n, n + (cell % n), 2 * n + regions[cell] };
            for (int cell = 0; cell < n * n; cell++)
            {
                // the JS Set's order: row and column interleaved, the eight around, the patch; minus the cell itself
                var has = new bool[n * n];
                var list = new List<int>();
                void Add(int x)
                {
                    if (!has[x]) { has[x] = true; list.Add(x); }
                }
                int r = cell / n;
                int c = cell % n;
                for (int i = 0; i < n; i++)
                {
                    Add(r * n + i);
                    Add(i * n + c);
                }
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int rr = r + dr;
                        int cc = c + dc;
                        if (rr >= 0 && rr < n && cc >= 0 && cc < n) Add(rr * n + cc);
                    }
                }
                for (int i = 0; i < n * n; i++) if (regions[i] == regions[cell]) Add(i);
                has[cell] = false;
                list.Remove(cell);
                S.Shadows[cell] = list.ToArray();
                S.ShadowHas[cell] = has;
            }
            return S;
        }

        static State Fresh(int n)
        {
            var s = new State { Cand = new bool[n * n], Placed = new bool[n * n], Done = new bool[3 * n], Count = 0 };
            for (int i = 0; i < s.Cand.Length; i++) s.Cand[i] = true;
            return s;
        }

        static void PlaceAt(Solver S, State s, int cell)
        {
            s.Placed[cell] = true;
            s.Cand[cell] = false;
            s.Count++;
            foreach (int u in S.UnitsOf[cell]) s.Done[u] = true;
            foreach (int x in S.Shadows[cell]) s.Cand[x] = false;
        }

        // a line still waiting for its creature with no free cell left
        static bool Stuck(Solver S, State s)
        {
            for (int u = 0; u < S.Units.Length; u++)
            {
                if (s.Done[u]) continue;
                bool any = false;
                foreach (int cell in S.Units[u]) if (s.Cand[cell]) { any = true; break; }
                if (!any) return true;
            }
            return false;
        }

        static int KindIndex(int start, int n)
        {
            return start == 0 ? 0 : start == n ? 1 : 2;
        }

        // One forced step, the cheapest kind first: the grade of the trick used (1-5), 0 when nothing is forced, -1
        // when the state is broken. `maxGrade` stops before the costlier tricks.
        static int Step(Solver S, State s, int maxGrade = 5)
        {
            int n = S.N;
            var units = S.Units;
            if (Stuck(S, s)) return -1;
            // 1 singles
            for (int u = 0; u < units.Length; u++)
            {
                if (s.Done[u]) continue;
                int freeCount = 0;
                int first = -1;
                foreach (int cell in units[u])
                {
                    if (!s.Cand[cell]) continue;
                    if (freeCount == 0) first = cell;
                    freeCount++;
                }
                if (freeCount == 1)
                {
                    PlaceAt(S, s, first);
                    return 1;
                }
            }
            if (maxGrade < 2) return 0;
            // 2 peeks: a creature here would leave another line no room
            for (int cell = 0; cell < n * n; cell++)
            {
                if (!s.Cand[cell]) continue;
                var sh = S.ShadowHas[cell];
                var mine = S.UnitsOf[cell];
                for (int u = 0; u < units.Length; u++)
                {
                    if (s.Done[u] || u == mine[0] || u == mine[1] || u == mine[2]) continue;
                    bool every = true;
                    foreach (int x in units[u])
                    {
                        if (s.Cand[x] && !sh[x]) { every = false; break; }
                    }
                    if (every)
                    {
                        s.Cand[cell] = false;
                        return 2;
                    }
                }
            }
            if (maxGrade < 3) return 0;
            // 3-4 pairs and groups: k lines of one kind whose free cells all sit in k lines of another kind own those
            // lines; every other free cell in them goes.
            int[] kinds = { 0, n, 2 * n };
            var mineSet = new bool[3 * n];
            var spanHas = new bool[3 * n];
            for (int k = 2; k < n; k++)
            {
                foreach (int a0 in kinds)
                {
                    int a1 = a0 + n;
                    foreach (int b0 in kinds)
                    {
                        if (a0 == b0) continue;
                        var open = new List<int>();
                        for (int u = a0; u < a1; u++) if (!s.Done[u]) open.Add(u);
                        if (open.Count <= k) continue;
                        int bIdx = KindIndex(b0, n);
                        int aIdx = KindIndex(a0, n);
                        // which b-lines each open a-line's free cells fall in (insertion order, like a JS Set)
                        var spans = new List<int>[open.Count];
                        for (int i = 0; i < open.Count; i++)
                        {
                            var list = new List<int>();
                            foreach (int cell in units[open[i]])
                            {
                                if (!s.Cand[cell]) continue;
                                int b = S.UnitsOf[cell][bIdx];
                                if (!list.Contains(b)) list.Add(b);
                            }
                            spans[i] = list;
                        }
                        bool found = Combos(open.Count, k, idx =>
                        {
                            var span = new List<int>();
                            foreach (int i in idx)
                            {
                                foreach (int b in spans[i])
                                {
                                    if (!spanHas[b]) { spanHas[b] = true; span.Add(b); }
                                }
                            }
                            foreach (int b in span) spanHas[b] = false;
                            if (span.Count != k) return false;
                            foreach (int i in idx) mineSet[open[i]] = true;
                            bool changed = false;
                            foreach (int b in span)
                            {
                                foreach (int cell in units[b])
                                {
                                    if (!s.Cand[cell]) continue;
                                    int a = S.UnitsOf[cell][aIdx];
                                    if (!mineSet[a])
                                    {
                                        s.Cand[cell] = false;
                                        changed = true;
                                    }
                                }
                            }
                            foreach (int i in idx) mineSet[open[i]] = false;
                            return changed;
                        });
                        if (found) return k == 2 ? 3 : 4;
                    }
                }
            }
            if (maxGrade < 5) return 0;
            // 5 chains: try a creature here, follow the easy steps; a dead end rules it out
            for (int cell = 0; cell < n * n; cell++)
            {
                if (!s.Cand[cell]) continue;
                var t = s.Copy();
                PlaceAt(S, t, cell);
                int g;
                int guard = 0;
                while ((g = Step(S, t, 2)) > 0 && guard++ < 200) { }
                if (g == -1)
                {
                    s.Cand[cell] = false;
                    return 5;
                }
            }
            return 0;
        }

        // Calls fn(indices) for every k-subset of 0..m-1 until it returns true.
        static bool Combos(int m, int k, Func<int[], bool> fn)
        {
            var idx = new int[k];
            for (int i = 0; i < k; i++) idx[i] = i;
            for (;;)
            {
                if (fn(idx)) return true;
                int i = k - 1;
                while (i >= 0 && idx[i] == m - k + i) i--;
                if (i < 0) return false;
                idx[i]++;
                for (int j = i + 1; j < k; j++) idx[j] = idx[j - 1] + 1;
            }
        }

        static readonly int[] StallCost = { 0, 0, 1, 3, 5, 8 };

        /// <summary>Solves a board like a player.</summary>
        public static GradeResult Grade(int n, int[] regions)
        {
            var S = MakeSolver(n, regions);
            var s = Fresh(n);
            int max = 0;
            int steps = 0;
            int effort = 0;
            int stall = 0;
            int g;
            while (s.Count < n && (g = Step(S, s)) > 0)
            {
                max = Math.Max(max, g);
                steps++;
                if (g == 1)
                {
                    effort += StallCost[stall];
                    stall = 0;
                }
                else stall = Math.Max(stall, g);
            }
            effort += StallCost[stall];
            if (s.Count < n) return new GradeResult { Solved = false, Grade = max, Steps = steps, Effort = effort };
            var solution = new int[n];
            for (int r = 0; r < n; r++)
            {
                solution[r] = -1;
                for (int c = 0; c < n; c++) if (s.Placed[r * n + c]) { solution[r] = c; break; }
            }
            return new GradeResult { Solved = true, Grade = max, Steps = steps, Effort = effort, Solution = solution };
        }

        // --- making one --------------------------------------------------------------------

        /// <summary>A board straight away (the JS makePuzzle). With no seed, one is drawn from `random`
        /// (Math.random's role; System.Random when null).</summary>
        public static Puzzle MakePuzzle(int n, int tier = 0, long? seed = null, int maxTries = 600, Func<double> random = null)
        {
            var m = new PuzzleMaker(n, tier, seed, maxTries, random);
            Puzzle p;
            while ((p = m.Run(50)) == null) { }
            return p;
        }
    }

    /// <summary>engine.js puzzleMaker: a maker for one board of size n at tier (0-3), worked a slice at a time.
    /// Run(ms) tries boards for about ms and returns the puzzle once it has one that fits (else null; call again).
    /// After maxTries it settles for the closest tier it saw. The seed fixes everything (timing never changes the
    /// result). Note (as in the JS): n = 2 or 3 never makes a board, so Run returns null for ever.</summary>
    public sealed class PuzzleMaker
    {
        readonly int n;
        readonly int tier;
        readonly int maxTries;
        readonly Func<double> r;
        int tries;
        Puzzle best;
        int bestScore;
        Puzzle result;

        public long Seed { get; private set; }
        public int Tries { get { return tries; } }

        public PuzzleMaker(int n, int tier = 0, long? seed = null, int maxTries = 600, Func<double> random = null)
        {
            this.n = n;
            this.tier = tier;
            this.maxTries = maxTries;
            if (seed.HasValue) Seed = seed.Value;
            else
            {
                if (random == null)
                {
                    var sys = new Random();
                    random = sys.NextDouble;
                }
                Seed = (long)Math.Floor(random() * 2147483648.0);
            }
            r = Engine.Rng(Seed);
        }

        Puzzle TryOne()
        {
            tries++;
            int[] sol = Engine.RandomSolution(n, r);
            if (sol == null) return null;
            int[] regions = Engine.MakeUnique(n, Engine.GrowRegions(n, sol, r), sol, r);
            if (regions == null) return null;
            var g = Engine.Grade(n, regions);
            if (!g.Solved) return null;
            var p = new Puzzle { N = n, Regions = regions, Solution = g.Solution, Grade = g.Grade, Effort = g.Effort, Tier = Engine.TierOf(g.Effort), Steps = g.Steps, Seed = Seed };
            int off = Math.Abs(p.Tier - tier);
            // a near miss: below the tier beats above it (too easy, not too hard)
            int score = off * 2 + (p.Tier > tier ? 1 : 0);
            if (best == null || score < bestScore)
            {
                best = p;
                bestScore = score;
            }
            return off == 0 ? p : null;
        }

        public Puzzle Run(double ms = 8)
        {
            if (result != null) return result;
            var clock = System.Diagnostics.Stopwatch.StartNew();
            do
            {
                var p = TryOne();
                if (p != null) return result = p;
                if (tries >= maxTries && best != null) return result = best;
            } while (clock.Elapsed.TotalMilliseconds < ms);
            return null;
        }
    }
}
