// Squish Stack's puzzle, ported from src/stack/engine.js (SQUISH_STACK.md): squishies sitting on cushions, a big one
// never on a smaller one (the Tower of Hanoi). Pure functions: the game draws and animates what these say.
//
// A state is where each squishy sits: pos[r] is the cushion of the squishy of size r (0 = the smallest). A cushion's
// stack follows from it, biggest at the bottom, so every state is a legal one. With k cushions and n squishies there
// are k^n states: few enough (65,536 at 8 on 4) to work out how far every one of them is from the goal, which gives
// the par, the hint and the "stars still possible" meter.
//
// Parity with the JS is checked by tools/unity/games/stack (fixtures.mjs + StackDiff): same puzzles for the same
// random numbers (and the same count of them drawn), same distances, same best move.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Stack
{
    // solve()'s result: how far every state is from the goal it was solved for. Dist is indexed by Enc(pos).
    public sealed class Solution
    {
        public readonly short[] Dist;
        public readonly int N;
        public readonly int K;
        readonly int[] pw;

        public Solution(short[] dist, int n, int k, int[] pw)
        {
            Dist = dist;
            N = n;
            K = k;
            this.pw = pw;
        }

        // pos → code (pos[i] × k^i summed)
        public int Enc(int[] p)
        {
            int s = 0;
            for (int i = 0; i < N; i++) s += p[i] * pw[i];
            return s;
        }
    }

    // makePuzzle()'s result: { start, goal, star, par, sol }. Star is the ★ cushion, or -1 for a picture goal.
    public sealed class Puzzle
    {
        public int[] Start;
        public int[] Goal;
        public int Star;
        public int Par;
        public Solution Sol;
    }

    public static class Engine
    {
        // the squishies on cushion p, bottom (biggest) to top
        public static int[] StackOf(int[] pos, int p)
        {
            var s = new List<int>();
            for (int r = pos.Length - 1; r >= 0; r--) if (pos[r] == p) s.Add(r);
            return s.ToArray();
        }

        // the squishy on top of cushion p, or -1 for an empty one
        public static int TopOf(int[] pos, int p)
        {
            for (int r = 0; r < pos.Length; r++) if (pos[r] == p) return r;
            return -1;
        }

        // Can the top squishy of `from` go onto `to`? Its size, or -1.
        public static int CanMove(int[] pos, int from, int to)
        {
            if (from == to) return -1;
            int r = TopOf(pos, from);
            if (r < 0) return -1;
            int t = TopOf(pos, to);
            return t < 0 || t > r ? r : -1;
        }

        public static bool Same(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
            return true;
        }

        static int IntPow(int k, int e)
        {
            int v = 1;
            for (int i = 0; i < e; i++) v *= k;
            return v;
        }

        // How far every state is from `goal` (a breadth-first search out from the goal; a move undoes itself, so the
        // distance back is the distance there). The JS algorithm and visiting order, on flat arrays.
        public static Solution Solve(int n, int k, int[] goal)
        {
            int N = IntPow(k, n);
            var pw = new int[n];
            for (int i = 0; i < n; i++) pw[i] = IntPow(k, i);
            var dist = new short[N];
            for (int i = 0; i < N; i++) dist[i] = -1;
            var q = new int[N];
            int head = 0, tail = 0;
            var sol = new Solution(dist, n, k, pw);
            int g = sol.Enc(goal);
            dist[g] = 0;
            q[tail++] = g;
            var top = new int[k];
            // 2 or 4 cushions: a digit is a bit field (no division); the same answer as s / k^i % k
            int bits = k == 2 ? 1 : k == 4 ? 2 : 0;
            int mask = k - 1;
            while (head < tail)
            {
                int s = q[head++];
                for (int a = 0; a < k; a++) top[a] = n;
                // the smallest squishy on each cushion is its top: walk from the biggest
                if (bits > 0) for (int i = n - 1; i >= 0; i--) top[(s >> (bits * i)) & mask] = i;
                else for (int i = n - 1; i >= 0; i--) top[s / pw[i] % k] = i;
                short dn = (short)(dist[s] + 1);
                for (int a = 0; a < k; a++)
                {
                    int r = top[a];
                    if (r == n) continue;
                    for (int b = 0; b < k; b++)
                    {
                        if (b == a || top[b] < r) continue;
                        int ns = s + (b - a) * pw[r];
                        if (dist[ns] < 0)
                        {
                            dist[ns] = dn;
                            q[tail++] = ns;
                        }
                    }
                }
            }
            return sol;
        }

        // moves left from `pos` to the goal it was solved for
        public static int Left(Solution sol, int[] pos) => sol.Dist[sol.Enc(pos)];

        // One move that brings `pos` a step closer: [r, from, to], or null when it's already there. The first such
        // move in from-then-to order, as in the JS.
        public static int[] BestMove(Solution sol, int[] pos)
        {
            int d = Left(sol, pos);
            if (d <= 0) return null;
            var next = new int[pos.Length];
            for (int from = 0; from < sol.K; from++)
            {
                for (int to = 0; to < sol.K; to++)
                {
                    int r = CanMove(pos, from, to);
                    if (r < 0) continue;
                    Array.Copy(pos, next, pos.Length);
                    next[r] = to;
                    if (Left(sol, next) == d - 1) return new[] { r, from, to };
                }
            }
            return null;
        }

        static Random shared;

        static Func<double> DefaultRand()
        {
            if (shared == null) shared = new Random();
            return shared.NextDouble;
        }

        static int Pick(Func<double> rand, int n) => (int)Math.Floor(rand() * n);

        // A goal picture: at least two cushions used, never everyone on one.
        static int[] PictureGoal(int n, int k, Func<double> rand)
        {
            for (;;)
            {
                var g = new int[n];
                for (int i = 0; i < n; i++) g[i] = Pick(rand, k);
                for (int i = 1; i < n; i++) if (g[i] != g[0]) return g;
            }
        }

        // A level's puzzle.
        //   spec.Start  "tower" (everyone on the first cushion, the classic) or "scrambled" (anywhere, `par` moves
        //               from the goal)
        //   spec.Goal   "star" (everyone on one cushion, `star`) or "picture"
        //   spec.Par    [lo, hi]: how many moves the best answer takes
        // A scrambled start is drawn from every state whose answer is in the range (widened a move at a time if none
        // is), never the goal itself. `rand` is Math.random's stand-in (System.Random when null): a tower draws no
        // number, a star goal one, a picture goal n per try, then one for the start.
        public static Puzzle MakePuzzle(LevelSpec spec, Func<double> rand = null)
        {
            if (rand == null) rand = DefaultRand();
            int n = spec.N, k = spec.K;
            if (spec.Start == "tower")
            {
                var tgoal = new int[n];
                for (int i = 0; i < n; i++) tgoal[i] = k - 1;
                var tsol = Solve(n, k, tgoal);
                var tstart = new int[n];
                return new Puzzle { Start = tstart, Goal = tgoal, Star = k - 1, Par = Left(tsol, tstart), Sol = tsol };
            }
            int star = spec.Goal == "picture" ? -1 : Pick(rand, k);
            int[] goal;
            if (star >= 0)
            {
                goal = new int[n];
                for (int i = 0; i < n; i++) goal[i] = star;
            }
            else goal = PictureGoal(n, k, rand);
            var sol = Solve(n, k, goal);
            int lo = spec.Par[0], hi = spec.Par[1];
            var dist = sol.Dist;
            var fits = new int[dist.Length];
            for (int widen = 0; widen < 40; widen++)
            {
                int count = 0;
                int min = Math.Max(1, lo);
                for (int s = 0; s < dist.Length; s++) if (dist[s] >= min && dist[s] <= hi) fits[count++] = s;
                if (count > 0)
                {
                    int s = fits[Pick(rand, count)];
                    var start = new int[n];
                    for (int i = 0, d = s; i < n; i++, d /= k) start[i] = d % k;
                    return new Puzzle { Start = start, Goal = goal, Star = star, Par = dist[s], Sol = sol };
                }
                lo -= 1;
                hi += 1;
            }
            throw new InvalidOperationException("no start for " + n + " on " + k);
        }
    }
}
