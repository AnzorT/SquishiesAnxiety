// Squish Hop: the rules and the solver. A port of src/hop/engine.js (SQUISH_HOP.md); keep the two the same. Checked
// against the JS by tools/unity/games/hop (fixtures.mjs + the hop-test console project).
//
// A level is a grid of cushions. The squishy hops one cell at a time; the cushion it leaves puffs away, so it can't go
// back there. Hopping onto the ★ cushion ends the level, and three stars need every other cushion cleared first.
// The twists:
//   pile      'D'  two cushions on top of each other: two hops to clear
//   friend    'F'  hop on to pick it up; the ★ opens when all are picked up
//   in order  '1'-'9'  numbered friends, picked up in that order
//   arrow     '^' '>' 'v' '<'  you can only hop off it the way it points
//   bubble    'o'  hop onto it and you bounce on, one cushion further the same way (and on again over more bubbles);
//                  you can't hop onto it if there's nothing to land on past it
//   beat      'a' 'b' 'c'  a beat tile lights up every third hop: you can only land on it on hop 3k+1 ('b'),
//                  3k+2 ('c') or 3k ('a')
// Other letters: '#' no cushion, '.' cushion, 'S' start, 'G' the ★. Any other character is a plain cushion (as in JS).
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Hop
{
    // A parsed level (engine.js parse()).
    public sealed class Level
    {
        public int W, H;
        public int[] Life;      // hops left on each cell (0 none, 1 cushion, 2 pile)
        public int Start, Goal;
        public int[] Friends;   // friend cells in reading order
        public int[][] Nb;      // Nb[i][d]: the cushion next to i in direction d, or -1
        public int[][] Nbrs;    // the cushions next to i (Nb[i] without the -1s)
        public int[] Fbit;      // a friend's bit (1 << k, 32-bit like JS: k wraps at 32)
        public int[] Need;      // the friend bits a numbered friend needs first
        public int[] Order;     // a numbered friend's number (0 otherwise)
        public int[] Arrow;     // -1 or a direction
        public bool[] Bubble;
        public int[] Beat;      // -1 or 0..2
        // (1 << friends) - 1 as JS computes it: a 32-bit shift, then a double subtraction (so 31 friends give
        // -2147483649, which no 32-bit `got` ever equals). A long holds that exactly.
        public long All;
    }

    public sealed class HopState
    {
        public int Cur;
        public int[] Life;
        public int Got;
        public int Hops;
        public bool Done;

        public HopState Clone()
        {
            return new HopState { Cur = Cur, Life = (int[])Life.Clone(), Got = Got, Hops = Hops, Done = Done };
        }
    }

    // tryMove()'s result: { ok: true, cells, st } or { ok: false, why, cell[, at] }.
    public sealed class MoveResult
    {
        public bool Ok;
        public int[] Cells;     // ok: every cell entered, bubbles included
        public HopState St;     // ok: the state after the hop
        public string Why;      // not ok: 'done', 'arrow', 'edge', 'gone', 'locked', 'order', 'beat' or 'bounce'
        public int Cell;        // not ok: the cell to show the bump on
        public bool HasAt;      // not ok: JS sets `at` only when the hop was tried (not for 'done' / 'arrow')
        public int At;
    }

    // moves()'s entries: { d, cells, st }
    public sealed class Move
    {
        public int D;
        public int[] Cells;
        public HopState St;
    }

    public sealed class SearchOptions
    {
        public double? Limit;       // nodes to visit at most (JS default 200000)
        public bool Count;          // collect up to Cap answers instead of stopping at the first
        public int? Cap;            // JS default 50 (only with Count)
        public Func<double> Rand;   // a 0..1 function: shuffles the order moves are tried in
    }

    public sealed class SearchResult
    {
        public int[] Path;          // the first answer, or null
        public List<int[]> Sols;
        public int Count;
        public int Nodes;
        public bool Aborted;
    }

    public sealed class ReplayResult
    {
        public bool Ok;
        public List<MoveResult> Steps;
        public HopState St;
    }

    public static class Engine
    {
        // up, right, down, left
        public static readonly int[][] DIRS = { new[] { 0, -1 }, new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 } };
        public const string DCH = "URDL";
        // { '^': 0, '>': 1, v: 2, '<': 3 } and { a: 0, b: 1, c: 2 }, in JS key order
        public static readonly KeyValuePair<char, int>[] ARROWS =
        {
            new KeyValuePair<char, int>('^', 0), new KeyValuePair<char, int>('>', 1),
            new KeyValuePair<char, int>('v', 2), new KeyValuePair<char, int>('<', 3),
        };
        public static readonly KeyValuePair<char, int>[] BEATS =
        {
            new KeyValuePair<char, int>('a', 0), new KeyValuePair<char, int>('b', 1), new KeyValuePair<char, int>('c', 2),
        };

        static int ArrowOf(char ch)
        {
            switch (ch) { case '^': return 0; case '>': return 1; case 'v': return 2; case '<': return 3; default: return -1; }
        }

        static int BeatOf(char ch)
        {
            switch (ch) { case 'a': return 0; case 'b': return 1; case 'c': return 2; default: return -1; }
        }

        public static Level Parse(IList<string> rows)
        {
            int h = rows.Count;
            if (h == 0) throw new ArgumentException("a level needs S and G"); // JS: new Array(-Infinity) throws
            int w = 0;
            for (int r = 0; r < h; r++) w = Math.Max(w, rows[r].Length);
            int n = w * h;
            var life = new int[n];
            var arrow = new int[n];
            var bubble = new bool[n];
            var beat = new int[n];
            var order = new int[n];
            for (int i = 0; i < n; i++) { arrow[i] = -1; beat[i] = -1; }
            var friends = new List<int>();
            int start = -1, goal = -1;
            for (int y = 0; y < h; y++)
            {
                string row = rows[y];
                for (int x = 0; x < w; x++)
                {
                    char ch = x < row.Length ? row[x] : '#';
                    int i = y * w + x;
                    if (ch == '#') continue;
                    life[i] = ch == 'D' ? 2 : 1;
                    if (ch == 'S') start = i;
                    else if (ch == 'G') goal = i;
                    else if (ch == 'F') friends.Add(i);
                    else if (ch >= '1' && ch <= '9')
                    {
                        friends.Add(i);
                        order[i] = ch - '0';
                    }
                    else if (ArrowOf(ch) >= 0) arrow[i] = ArrowOf(ch);
                    else if (ch == 'o') bubble[i] = true;
                    else if (BeatOf(ch) >= 0) beat[i] = BeatOf(ch);
                }
            }
            if (start < 0 || goal < 0) throw new ArgumentException("a level needs S and G");
            var nb = new int[n][];
            var nbrs = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int x = i % w;
                int y = i / w;
                var a = new int[4];
                int cnt = 0;
                for (int d = 0; d < 4; d++)
                {
                    int nx = x + DIRS[d][0];
                    int ny = y + DIRS[d][1];
                    a[d] = nx >= 0 && ny >= 0 && nx < w && ny < h && life[ny * w + nx] > 0 ? ny * w + nx : -1;
                    if (a[d] >= 0) cnt++;
                }
                nb[i] = a;
                var f = new int[cnt];
                cnt = 0;
                for (int d = 0; d < 4; d++) if (a[d] >= 0) f[cnt++] = a[d];
                nbrs[i] = f;
            }
            var fbit = new int[n];
            for (int k = 0; k < friends.Count; k++) fbit[friends[k]] = 1 << k; // C# masks the shift by 31, as JS does
            var need = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (order[i] == 0) continue;
                int m = 0;
                foreach (int c in friends)
                    if (order[c] != 0 && order[c] < order[i]) m |= fbit[c];
                need[i] = m;
            }
            return new Level
            {
                W = w, H = h, Life = life, Start = start, Goal = goal, Friends = friends.ToArray(), Nb = nb, Nbrs = nbrs,
                Fbit = fbit, Need = need, Order = order, Arrow = arrow, Bubble = bubble, Beat = beat,
                All = (long)(1 << friends.Count) - 1,
            };
        }

        // the cells still to clear (the ★ cushion isn't one), counting the one the squishy stands on
        public static int LeftOf(Level lv, int[] life)
        {
            int n = 0;
            for (int i = 0; i < life.Length; i++) if (i != lv.Goal) n += life[i];
            return n;
        }

        public static HopState NewState(Level lv)
        {
            return new HopState { Cur = lv.Start, Life = (int[])lv.Life.Clone(), Got = 0, Hops = 0, Done = false };
        }

        // Why a cell can't be landed on right now ("" if it can). `hops` is how many cells have been entered so far
        // (the start is entry 0).
        public static string BlockOf(Level lv, int[] life, int got, int hops, int j)
        {
            if (j < 0) return "edge";
            if (life[j] <= 0) return "gone";
            // the ★: shut until every other cushion is cleared (the user, 2026-11-16; `life` already has the cushion being
            // hopped off, and any bubbles bounced over, taken off)
            if (j == lv.Goal && (got != lv.All || LeftOf(lv, life) > 0)) return "locked";
            if ((lv.Need[j] & ~got) != 0) return "order";
            if (lv.Beat[j] >= 0 && (hops + 1) % 3 != lv.Beat[j]) return "beat";
            return "";
        }

        // Hop from where the squishy stands in direction d.
        public static MoveResult TryMove(Level lv, HopState st, int d)
        {
            if (st.Done) return new MoveResult { Ok = false, Why = "done", Cell = -1 };
            if (lv.Arrow[st.Cur] >= 0 && lv.Arrow[st.Cur] != d) return new MoveResult { Ok = false, Why = "arrow", Cell = st.Cur };
            var life = (int[])st.Life.Clone();
            int got = st.Got;
            int hops = st.Hops;
            int at = st.Cur;
            var cells = new List<int>();
            life[at]--;
            for (;;)
            {
                int j = lv.Nb[at][d];
                string why = BlockOf(lv, life, got, hops, j);
                if (why.Length > 0)
                    return new MoveResult { Ok = false, Why = cells.Count > 0 ? "bounce" : why, Cell = cells.Count > 0 ? cells[0] : j, HasAt = true, At = j };
                hops++;
                got |= lv.Fbit[j];
                cells.Add(j);
                at = j;
                if (j != lv.Goal && lv.Bubble[j])
                {
                    life[j]--;
                    continue;
                }
                break;
            }
            return new MoveResult
            {
                Ok = true, Cells = cells.ToArray(),
                St = new HopState { Cur = at, Life = life, Got = got, Hops = hops, Done = at == lv.Goal },
            };
        }

        public static List<Move> Moves(Level lv, HopState st)
        {
            var output = new List<Move>();
            for (int d = 0; d < 4; d++)
            {
                var m = TryMove(lv, st, d);
                if (m.Ok) output.Add(new Move { D = d, Cells = m.Cells, St = m.St });
            }
            return output;
        }

        // Depth-first search for move lists (directions) that clear every cushion and end on the ★. Limit caps the
        // nodes visited; Count collects up to Cap answers instead of stopping at the first; Rand shuffles the order
        // moves are tried in. Same visiting order, node count and answers as the JS.
        public static SearchResult Search(Level lv, HopState st, SearchOptions opts = null)
        {
            if (opts == null) opts = new SearchOptions();
            var s = new Searcher(lv, st, opts.Limit ?? 200000, opts.Count ? (opts.Cap ?? 50) : 1, opts.Rand);
            if (st.Done)
            {
                bool clear = s.Remaining == 0;
                return new SearchResult
                {
                    Path = clear ? new int[0] : null, Sols = clear ? new List<int[]> { new int[0] } : new List<int[]>(),
                    Count = clear ? 1 : 0, Nodes = 0, Aborted = false,
                };
            }
            bool aborted = false;
            if (s.Ok(st.Cur)) s.Rec(st.Cur, st.Got, st.Hops);
            if (s.Stop) aborted = s.Sols.Count < s.Cap;
            return new SearchResult
            {
                Path = s.Sols.Count > 0 ? s.Sols[0] : null, Sols = s.Sols, Count = s.Sols.Count, Nodes = s.Nodes, Aborted = aborted,
            };
        }

        static readonly int[] ORDER = { 0, 1, 2, 3 };

        // engine.js search()'s closure. JS throws ABORT to stop; here Stop is set and every level returns at once
        // (nothing after the throw point is observable, so the two agree).
        sealed class Searcher
        {
            readonly int[] life;
            readonly int n, goal;
            // flat copies of the level's neighbour lists: nb4[i * 4 + d], and cell i's live-at-parse neighbours in
            // nbrsAll[nbrsOff[i] .. nbrsOff[i + 1])
            readonly int[] nb4, nbrsOff, nbrsAll;
            int alive; // cells with life > 0, kept up to date (JS counts them in every ok())
            readonly int[] arrow, beat, fbit, need;
            readonly bool[] bubble;
            readonly long all;
            readonly double limit;
            public readonly int Cap;
            readonly Func<double> rand;
            public int Remaining;
            public int Nodes;
            public readonly List<int[]> Sols = new List<int[]>();
            readonly int[] path;
            int psp;
            readonly int[] seen, queue, bstack;
            int stamp, bsp;
            public bool Stop;

            public Searcher(Level lv, HopState st, double limit, int cap, Func<double> rand)
            {
                life = (int[])st.Life.Clone();
                n = life.Length;
                goal = lv.Goal; arrow = lv.Arrow; bubble = lv.Bubble; beat = lv.Beat;
                fbit = lv.Fbit; need = lv.Need; all = lv.All;
                this.limit = limit; Cap = cap; this.rand = rand;
                Remaining = LeftOf(lv, life);
                seen = new int[n];
                queue = new int[n];
                bstack = new int[n + 4];
                path = new int[n * 2 + 8];
                nb4 = new int[n * 4];
                nbrsOff = new int[n + 1];
                int total = 0;
                for (int i = 0; i < n; i++) total += lv.Nbrs[i].Length;
                nbrsAll = new int[total];
                total = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int d = 0; d < 4; d++) nb4[i * 4 + d] = lv.Nb[i][d];
                    nbrsOff[i] = total;
                    foreach (int m in lv.Nbrs[i]) nbrsAll[total++] = m;
                }
                nbrsOff[n] = total;
                for (int i = 0; i < n; i++) if (life[i] > 0) alive++;
            }

            bool Live(int j) { return j >= 0 && life[j] > 0; }

            void Dec(int i)
            {
                if (life[i]-- > 0 && life[i] <= 0) alive--;
            }

            void Inc(int i)
            {
                if (life[i]++ <= 0 && life[i] > 0) alive++;
            }

            // can everything still be cleared, judging from the board's shape?
            public bool Ok(int cur)
            {
                // every live cell (and the ★) in one piece with the squishy
                stamp++;
                int head = 0, tail = 0;
                queue[tail++] = cur;
                seen[cur] = stamp;
                while (head < tail)
                {
                    int c = queue[head++];
                    if (c == goal) continue; // the ★ ends the level: no way through it
                    for (int k = nbrsOff[c], ke = nbrsOff[c + 1]; k < ke; k++)
                    {
                        int m = nbrsAll[k];
                        if (life[m] > 0 && seen[m] != stamp)
                        {
                            seen[m] = stamp;
                            queue[tail++] = m;
                        }
                    }
                }
                if (tail != alive) return false;
                for (int c = 0; c < n; c++)
                {
                    if (c == cur || c == goal || life[c] <= 0) continue;
                    // an arrow has to have somewhere to send you
                    if (arrow[c] >= 0)
                    {
                        int t = nb4[c * 4 + arrow[c]];
                        if (!Live(t)) return false;
                    }
                    if (life[c] != 1) continue;
                    if (bubble[c])
                    {
                        // a bubble needs a way in and the way straight on out
                        bool any = false;
                        for (int d = 0; d < 4 && !any; d++)
                        {
                            int o = nb4[c * 4 + d];
                            int inn = nb4[c * 4 + (d + 2) % 4];
                            if (Live(o) && Live(inn) && inn != goal) any = true;
                        }
                        if (!any) return false;
                        continue;
                    }
                    // a single cushion with one live neighbour has to be entered from it and left back onto it, so
                    // that neighbour needs two hops left (a pile), and the ★ can't be it
                    int deg = 0, only = -1;
                    for (int k = nbrsOff[c], ke = nbrsOff[c + 1]; k < ke; k++)
                    {
                        int m = nbrsAll[k];
                        if (life[m] > 0) { deg++; only = m; }
                    }
                    if (deg == 0) return false;
                    if (deg == 1 && (only == goal || life[only] < 2)) return false;
                }
                return true;
            }

            public void Rec(int cur, int got, int hops)
            {
                if (++Nodes > limit) { Stop = true; return; }
                Dec(cur);
                Remaining--;
                int[] dirs;
                int nd;
                if (arrow[cur] >= 0) { dirs = null; nd = 1; }
                else
                {
                    dirs = ORDER;
                    nd = 4;
                    if (rand != null)
                    {
                        dirs = new[] { 0, 1, 2, 3 };
                        for (int i = 3; i > 0; i--)
                        {
                            int k = (int)Math.Floor(rand() * (i + 1));
                            int t = dirs[i];
                            dirs[i] = dirs[k];
                            dirs[k] = t;
                        }
                    }
                }
                for (int di = 0; di < nd; di++)
                {
                    int d = dirs == null ? arrow[cur] : dirs[di];
                    int at = cur;
                    int g = got;
                    int h = hops;
                    bool okMove = true;
                    int bse = bsp;
                    int j;
                    for (;;)
                    {
                        j = nb4[at * 4 + d];
                        if (j < 0 || life[j] <= 0 || (j == goal && (g != all || Remaining != 0)) || (need[j] & ~g) != 0 || (beat[j] >= 0 && (h + 1) % 3 != beat[j]))
                        {
                            okMove = false;
                            break;
                        }
                        h++;
                        g |= fbit[j];
                        at = j;
                        if (j != goal && bubble[j])
                        {
                            Dec(j);
                            Remaining--;
                            bstack[bsp++] = j;
                            continue;
                        }
                        break;
                    }
                    if (okMove)
                    {
                        path[psp++] = d;
                        if (j == goal)
                        {
                            if (Remaining == 0 && g == all)
                            {
                                var sol = new int[psp];
                                Array.Copy(path, sol, psp);
                                Sols.Add(sol);
                                if (Sols.Count >= Cap) { Stop = true; return; }
                            }
                        }
                        else if (Ok(j))
                        {
                            Rec(j, g, h);
                            if (Stop) return;
                        }
                        psp--;
                    }
                    Restore(bse);
                }
                Inc(cur);
                Remaining++;
            }

            void Restore(int bse)
            {
                while (bsp > bse)
                {
                    Inc(bstack[--bsp]);
                    Remaining++;
                }
            }
        }

        // the cells a list of moves enters (the first cell of each move, then any bubbles bounced over), and the state
        // after them
        public static ReplayResult Replay(Level lv, IEnumerable<int> dirs, HopState st0 = null)
        {
            var st = st0 ?? NewState(lv);
            var steps = new List<MoveResult>();
            foreach (int d in dirs)
            {
                var m = TryMove(lv, st, d);
                if (!m.Ok) return new ReplayResult { Ok = false, Steps = steps, St = st };
                steps.Add(m);
                st = m.St;
            }
            return new ReplayResult { Ok = true, Steps = steps, St = st };
        }

        // Stars for a finished level. Every win is a full clear now (the ★ only opens after it), so the stars count the
        // take-backs on the way (the user, 2026-11-16): 3 with no UNDO or RESTART, 2 with up to 3, else 1; a hint takes
        // one off (never below 1).
        public static int StarsFor(int takebacks, bool hinted)
        {
            int s = takebacks == 0 ? 3 : takebacks <= 3 ? 2 : 1;
            return Math.Max(1, s - (hinted ? 1 : 0));
        }

        // A quick check before the search: on a chessboard colouring the hops alternate colours, so the visits to
        // each colour must match up.
        public static bool ParityOk(Level lv)
        {
            int a = 0, b = 0;
            for (int i = 0; i < lv.Life.Length; i++)
            {
                int v = i == lv.Goal ? 1 : lv.Life[i];
                if (v == 0) continue;
                int x = i % lv.W;
                int y = i / lv.W;
                if ((x + y) % 2 != 0) a += v;
                else b += v;
            }
            int len = a + b;
            if (len % 2 == 0) return a == b && Col(lv, lv.Start) != Col(lv, lv.Goal);
            int major = a > b ? 1 : 0;
            return Math.Abs(a - b) == 1 && Col(lv, lv.Start) == major && Col(lv, lv.Goal) == major;
        }

        static int Col(Level lv, int i) { return (i % lv.W + i / lv.W) % 2; }
    }
}
