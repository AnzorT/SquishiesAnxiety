// A board of plush cushions lying on a room's floor (src/squishdoku/RoomBoard.js), as Regular (SdLevel) and Blitz play
// it: the cushions cascade in (intro) and out (outro); a tap on a placed creature wiggles it; now and then one does a
// trick while the board isn't locked. The creatures have three faces (src/squishdoku/bodies.js: idle, happy, sad, whole
// body and all; Resources/Squishdoku/bodies) and move like Squish Hop's squishies (hop/Pieces.js freshPose juicy):
//   right   pops up out of its cushion with a squash, turns happy, hops for joy, sparkles; the row, column and patch it
//           completes ripple with a happy wave (the cushions bob, a glow and a star on each)
//   wrong   pops up the same, turns sad, flashes red, shakes its head "no", then drops away in a poof (the cell glows
//           red, the board shakes, everyone startles with a worried look)
//   win     every creature turns happy, and a bounce ripples over the board from the last one placed (HopAll)
//   lose    one after another every creature turns sad, droops and sinks a little, and stays so (SadAll; CheerUp
//           brings them back)
// Touches: a tap on a cushion (onTap), on a placed creature (onTapPiece); with `allowX`, long-press and drag paint ✕
// (onMark). A creature with no faces (one published since) is its Squish Stack cut-out. No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdBoard
    {
        public readonly int N;
        public readonly Board B;
        readonly int[] _regions, _solution, _colors;
        readonly SdCreature[] _pieces;
        readonly Ticker _tk;
        readonly Func<bool> _locked;
        readonly Func<bool> _allowX;
        readonly Action<Action> _effect;
        readonly List<int> _timers = new List<int>();
        readonly int _cells;
        public Action<int> OnTap, OnTapPiece;
        public Action<int, bool> OnMark;
        public Func<bool> XTool = () => false;

        // Squish Hop's squishy moves (freshPose juicy: the ones Squishdoku uses), plus the faces (0 … 1 each) and the
        // red flash (a phase)
        sealed class Pose
        {
            public readonly AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), K = new AnimatedValue(1), O = new AnimatedValue(1),
                Shadow = new AnimatedValue(1), Rot = new AnimatedValue(0), Hp = new AnimatedValue(0), LiftH = new AnimatedValue(0),
                Land = new AnimatedValue(1), No = new AnimatedValue(0), Droop = new AnimatedValue(0),
                Happy = new AnimatedValue(0), Sad = new AnimatedValue(0), Red = new AnimatedValue(0);
            public KeyLoop Breathe, Peek;
            public SdLayer ShadowL, Body, HappyL, SadL, RedL;
            public int HopGen, FaceGen;
        }
        sealed class CellA { public readonly AnimatedValue A = new AnimatedValue(0), Bump = new AnimatedValue(0); public SdLayer L; public Board.Box Box; }

        readonly CellA[] _cellA;
        readonly Pose[] _poses;
        readonly bool[] _markOn, _placed, _shown;
        readonly AnimatedValue[] _markT;
        readonly SdLayer[] _markL;
        readonly Board.Box[] _markBox;
        int _red = -1;
        KeyLoop _redPulse;
        SdLayer _redL;
        Board.Box _redBox;
        readonly AnimatedValue _shakeX = new AnimatedValue(0);
        readonly List<Burst> _bursts = new List<Burst>();
        readonly List<Wave> _waves = new List<Wave>();
        int _trick = -1;
        readonly float _pw;
        double _landAt;   // when the last creature placed lands (HopAll's ripple starts with its hop for joy)
        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();

        const float PIECE_W = 0.7f;   // a creature's body, in tiles
        const double POP_MS = 200;    // a creature popping up out of its cushion
        const double WAVE_STEP = 55;  // a happy wave, per cell out
        public const double SAD_STEP = 140;   // a lost level: between one creature drooping and the next
        static readonly double[] PEEK_AT = { 0, 0.84, 0.88, 0.92, 0.96, 1 };
        static readonly double[] PEEK_DEG = { 0, 0, -9, 8, -3, 0 };
        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        /// <summary>`colors`: each patch's colour (a 600-levels board's), or null (Blitz's: in order). `effect`: runs what the
        /// app runs in an effect (a native loop starting once its view is up). `allowX`: whether ✕ can be painted.</summary>
        public SdBoard(Board b, int n, int[] regions, int[] solution, int[] colors, SdCreature[] pieces, Ticker tk, Func<bool> locked, Func<bool> allowX, Action<Action> effect)
        {
            B = b; N = n; _regions = regions; _solution = solution; _colors = colors; _pieces = pieces; _tk = tk; _locked = locked; _allowX = allowX;
            _effect = effect ?? (a => a());
            _cells = n * n;
            _cellA = new CellA[_cells]; _poses = new Pose[_cells];
            _markOn = new bool[_cells]; _placed = new bool[_cells]; _shown = new bool[_cells];
            _markT = new AnimatedValue[_cells]; _markL = new SdLayer[_cells]; _markBox = new Board.Box[_cells];
            _pw = (float)(B.T * PIECE_W);
            for (int cell = 0; cell < _cells; cell++)
            {
                var (svg, box) = SdArt.Cushion(B, cell, ColorIdx(_regions[cell]));
                _cellA[cell] = new CellA { L = new SdLayer("cushion " + cell).Set(svg, (float)box.Width, (float)box.Height, 2), Box = box };
                var p = _poses[cell] = new Pose();
                var c = PieceOf(cell);
                float h = HOf(cell);
                p.ShadowL = new SdLayer("shadow " + cell).Set(SdArt.Shadow(_pw * 0.72f, h * 0.15f, "rgba(69,16,122,0.28)"), _pw * 0.72f, h * 0.15f, 1);
                // each patch's creature drawn in its three faces (one render so they line up), or its cut-out
                if (c.Body != null)
                {
                    p.Body = new SdLayer("creature " + cell).SetPicture(c.Body + "-idle", _pw, h);
                    p.HappyL = new SdLayer("creature happy " + cell).SetPicture(c.Body + "-happy", _pw, h);
                    p.SadL = new SdLayer("creature sad " + cell).SetPicture(c.Body + "-sad", _pw, h);
                    p.RedL = new SdLayer("creature red " + cell).SetPicture(c.Body + "-red", _pw, h);
                }
                else p.Body = new SdLayer("creature " + cell).SetPicture(c.Picture, _pw, h);
            }
            // now and then one placed creature does a trick, so a board in progress never sits still
            Action trick = null;
            trick = () =>
            {
                _trick = _tk.SetTimeout(trick, 1400);
                if (_locked()) return;
                var on = PlacedCells();
                if (on.Count == 0) return;
                int cell = on[(int)Math.Floor(SdLevel.Random() * on.Count)];
                if (SdLevel.Random() < 0.5) Hop(cell, 0, 0.3);
                else Rock(cell, new[] { -0.5, 0.5, 0 }, 420);
            };
            _trick = _tk.SetTimeout(trick, 1400);
        }

        /// <summary>The board goes (its timers, its loops).</summary>
        public void Unmount()
        {
            foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            _tk.ClearTimeout(_trick);
            foreach (var p in _poses) { p.Breathe?.Unmount(); p.Peek?.Unmount(); }
            _redPulse?.Unmount();
            foreach (var b in _bursts.ToArray()) b.Stop();
            _bursts.Clear();
            foreach (var w in _waves) w.Stop();
            _waves.Clear();
        }

        int ColorIdx(int reg) => _colors != null ? _colors[reg] : reg;
        SdCreature PieceOf(int cell) { int r = _regions[cell]; return r < _pieces.Length && _pieces[r] != null ? _pieces[r] : _pieces[0]; }
        float HOf(int cell) { var c = PieceOf(cell); return _pw * (c.Body != null ? c.BodyAr : c.Ar); }
        int ZOf(int cell) => 10 + cell / N * 3;
        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));
        List<int> PlacedCells() { var on = new List<int>(); for (int i = 0; i < _cells; i++) if (_placed[i]) on.Add(i); return on; }
        double Gap(int a, int b) => Math.Sqrt((a / N - b / N) * (a / N - b / N) + (a % N - b % N) * (a % N - b % N));

        static TimingConfig T(double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            new TimingConfig { ToValue = to, Duration = ms, Easing = easing ?? Easing.Out(Easing.Quad), Delay = delay, UseNativeDriver = true };
        static void Run(AnimatedValue v, double to, double ms, Func<double, double> easing = null) => Animated.Timing(v, T(to, ms, easing)).Start();
        static void Stop(AnimatedValue v, double to) { v.StopAnimation(); v.SetValue(to); }

        public bool IsPlaced(int cell) => _placed[cell];
        public bool IsMarked(int cell) => _markOn[cell];

        // poseAt: where a creature of `k` stands on its cushion (its feet on the cushion's middle)
        (double x, double y, double k) PoseAt(int cell, double k)
        {
            var q = B.StandOn(cell);
            float h = HOf(cell);
            return (q.X - _pw / 2.0, q.Y - h / 2.0 * (1 + k), k);
        }
        (double x, double y, double k) PoseOn(int cell) => PoseAt(cell, B.StandOn(cell).S / B.T);

        void Show(int cell, bool on)
        {
            if (_shown[cell] == on) return;
            _shown[cell] = on;
            var p = _poses[cell];
            if (on)
            {
                double delay = cell * 530 % 2600;
                var br = p.Breathe = new KeyLoop(2200, KeyLoop.PHASE, KeyLoop.UP_DOWN, delay);
                var pk = p.Peek = new KeyLoop(6000, PEEK_AT, PEEK_DEG, delay);
                _effect(() => { if (p.Breathe == br) { br.Mount(); pk.Mount(); } });
            }
            else { p.Breathe?.Unmount(); p.Peek?.Unmount(); p.Breathe = p.Peek = null; }
        }

        public void SetMark(int cell, bool on)
        {
            if (_markOn[cell] == on) return;
            _markOn[cell] = on;
            if (on && !_placed[cell]) MountMark(cell);
        }

        void MountMark(int cell)
        {
            var (svg, box) = SdArt.XMark(B, cell);
            _markL[cell] ??= new SdLayer("x " + cell);
            _markL[cell].Set(svg, (float)box.Width, (float)box.Height, 2);
            _markBox[cell] = box;
            var t = _markT[cell] = new AnimatedValue(0);
            _effect(() => Animated.Spring(t, Fx.Spring(1, 5, 180)).Start());
        }

        // a creature pops up out of its cushion: growing from small at its feet (its size and place ease alike, so the feet
        // stay put) with an overshoot, then landing with a squash; `done` once it's up
        void Pop(int cell, Action done)
        {
            var P = _poses[cell];
            var p = PoseOn(cell);
            foreach (var v in new[] { P.Rot, P.Hp, P.No, P.Droop, P.Red, P.Happy, P.Sad }) Stop(v, 0);
            Stop(P.Land, 1);
            P.Shadow.SetValue(1);
            P.X.SetValue(p.x);
            double k0 = p.k * 0.12;
            P.K.SetValue(k0);
            P.Y.SetValue(PoseAt(cell, k0).y);
            P.O.SetValue(0);
            Show(cell, true);
            // (once it's on screen: a native animation started before its view is there can be lost)
            Later(30, () =>
            {
                var e = Easing.Out(Easing.Back(2.2));
                Animated.Parallel(Animated.Timing(P.K, T(p.k, POP_MS, e)), Animated.Timing(P.Y, T(p.y, POP_MS, e)), Animated.Timing(P.O, T(1, 70, Easing.Linear))).Start(r =>
                {
                    P.Land.SetValue(0);
                    Run(P.Land, 1, 320, Easing.Linear);
                    done?.Invoke();
                });
            });
        }

        // a little hop on the spot (`high` tiles up)
        void Hop(int cell, double delay = 0, double high = 0.45)
        {
            var P = _poses[cell];
            int gen = P.HopGen;
            Later(delay, () =>
            {
                if (P.HopGen != gen) return;
                P.Hp.SetValue(0);
                P.LiftH.SetValue(B.T * high);
                Animated.Timing(P.Hp, T(1, 340, Easing.Linear)).Start(r =>
                {
                    P.Land.SetValue(0);
                    Run(P.Land, 1, 220, Easing.Linear);
                });
            });
        }
        void CancelHops(int cell) => _poses[cell].HopGen++;

        // a face ("happy", "sad" or "idle") from `delay` ms, fading in over `ms`, for `hold` ms (then back to idle;
        // Infinity: until another face)
        void Face(int cell, string which, double delay = 0, double hold = double.PositiveInfinity, double ms = 110)
        {
            var P = _poses[cell];
            int gen = ++P.FaceGen;
            Later(delay, () =>
            {
                if (P.FaceGen != gen) return;
                Run(P.Happy, which == "happy" ? 1 : 0, ms, Easing.Linear);
                Run(P.Sad, which == "sad" ? 1 : 0, ms, Easing.Linear);
                if (which == "idle" || double.IsPositiveInfinity(hold)) return;
                Later(hold, () =>
                {
                    if (P.FaceGen != gen) return;
                    Run(P.Happy, 0, 220, Easing.Linear);
                    Run(P.Sad, 0, 220, Easing.Linear);
                });
            });
        }

        void Rock(int cell, double[] seq, double ms)
        {
            var a = new CompositeAnimation[seq.Length];
            for (int i = 0; i < seq.Length; i++) a[i] = Animated.Timing(_poses[cell].Rot, T(seq[i], ms / seq.Length, Easing.InOut(Easing.Quad)));
            Animated.Sequence(a).Start();
        }

        void Bounce(int cell, double delay)
        {
            var b = _cellA[cell].Bump;
            Later(delay, () =>
            {
                b.SetValue(0);
                Animated.Sequence(Animated.Timing(b, T(1, 110)), Animated.Timing(b, T(0, 220, Easing.InOut(Easing.Quad)))).Start();
            });
        }

        public void Shake()
        {
            _shakeX.SetValue(0);
            var ks = new[] { 1, -0.85, 0.65, -0.45, 0.25, -0.1, 0 };
            var a = new CompositeAnimation[ks.Length];
            for (int i = 0; i < ks.Length; i++) a[i] = Animated.Timing(_shakeX, new TimingConfig { ToValue = ks[i] * 9, Duration = 42, UseNativeDriver = true });
            Animated.Sequence(a).Start();
        }

        // fx.js FxLayer burst: a busy board never piles up more than a dozen at once
        void Burst(string kind, double x, double y, double scale)
        {
            var b = new Burst(kind, x, y, scale);
            if (_bursts.Count > 11) { var first = _bursts[0]; first.Stop(); _bursts.Remove(first); }
            _bursts.Add(b);
            b.Start(() => _bursts.Remove(b));
        }

        // fx.js FxLayer wave: the last three at most
        void StartWave(List<Wave.Spot> pts, double flat)
        {
            if (pts.Count == 0) return;
            if (_waves.Count > 2) { _waves[0].Stop(); _waves.RemoveAt(0); }
            var w = new Wave(pts, flat);
            _waves.Add(w);
            w.Start(() => _waves.Remove(w));
        }

        Dictionary<int, int> DistancesInPatch(int from)
        {
            int n = N;
            var dist = new Dictionary<int, int> { [from] = 0 };
            var todo = new Queue<int>();
            todo.Enqueue(from);
            int[][] dirs = { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
            while (todo.Count > 0)
            {
                int cell = todo.Dequeue(), r = cell / n, c = cell % n;
                foreach (var d in dirs)
                {
                    int rr = r + d[0], cc = c + d[1];
                    if (rr < 0 || rr >= n || cc < 0 || cc >= n) continue;
                    int nb = rr * n + cc;
                    if (_regions[nb] != _regions[from] || dist.ContainsKey(nb)) continue;
                    dist[nb] = dist[cell] + 1;
                    todo.Enqueue(nb);
                }
            }
            return dist;
        }

        // the floor's middle of a cell, and a cushion's width there (the waves' spots)
        Wave.Spot Spot(int cell, double d, bool glow = true)
        {
            var q = B.Project(cell % N + 0.5, cell / N + 0.5, 0);
            return new Wave.Spot { X = q.X, Y = q.Y, S = q.S, D = d, Glow = glow };
        }

        // A right creature completes its row, its column and its patch (each holds one): a happy wave runs out along all
        // three from it, from `start` ms; the cushions bob, a glow and a star on each.
        void RowWave(int cell, double start)
        {
            int n = N, r = cell / n, c = cell % n;
            var steps = new Dictionary<int, int>();   // (a Map: in the order the cells were put)
            var order = new List<int>();
            void Put(int x, int k) { if (!steps.TryGetValue(x, out var was)) { steps[x] = k; order.Add(x); } else if (was > k) steps[x] = k; }
            var dist = DistancesInPatch(cell);
            foreach (var kv in dist) Put(kv.Key, kv.Value);
            for (int i = 0; i < n; i++) { Put(r * n + i, Math.Abs(i - c)); Put(i * n + c, Math.Abs(i - r)); }
            var pts = new List<Wave.Spot>();
            foreach (var x in order)
            {
                int k = steps[x];
                Bounce(x, start + k * WAVE_STEP);
                if (x != cell) pts.Add(Spot(x, k * WAVE_STEP));
            }
            Later(start, () => StartWave(pts, B.C * 0.9));
        }

        /// <summary>A right creature on `cell`: it pops up out of its cushion with a squash, lights up happy, sparkles and
        /// hops for joy; a happy wave runs along its row, its column and its patch; everyone cheers with a happy hop.</summary>
        public void Place(int cell)
        {
            var before = (bool[])_placed.Clone();
            _placed[cell] = true;
            _markOn[cell] = false;
            CancelHops(cell);
            const double land = 30 + POP_MS;
            _landAt = _tk.Now + land;
            Pop(cell, () =>
            {
                var q = B.StandOn(cell);
                Burst("pop", q.X, q.Y - q.S * 0.2, q.S / 56);
                Burst("spark", q.X, q.Y - q.S * 0.5, q.S / 56);
            });
            Face(cell, "happy", delay: 120, hold: 1100);
            Hop(cell, land + 120, 0.4);
            Later(land + 260, () =>
            {
                var q = B.StandOn(cell);
                Burst("spark", q.X, q.Y - q.S * 0.85, q.S / 70);
            });
            RowWave(cell, land);
            int n = N, r = cell / n, c = cell % n;
            for (int other = 0; other < _cells; other++)
            {
                if (!before[other] || other == cell) continue;
                int d = Math.Abs(other / n - r) + Math.Abs(other % n - c);
                Hop(other, land + 60 + d * 55, 0.3);
                Face(other, "happy", delay: land + 60 + d * 55, hold: 420);
            }
        }

        /// <summary>A wrong creature on `cell`: it pops up the same, turns sad, flashes red (its cell glowing red) and shakes
        /// its head "no", then drops away in a poof; the board shakes, everyone startles with a worried look.</summary>
        public void Wrong(int cell)
        {
            _markOn[cell] = false;
            SetRed(cell);
            CancelHops(cell);
            var P = _poses[cell];
            Pop(cell, () =>
            {
                Face(cell, "sad", ms: 100);
                Run(P.Red, 1, 640, Easing.Linear);
                Run(P.No, 1, 620, Easing.Linear);
                Later(130, () => Rock(cell, new[] { 0.45, -0.45, 0.35, -0.2, 0 }, 480));
                Later(740, () =>
                {
                    var q = B.StandOn(cell);
                    var p = PoseOn(cell);
                    var e = Easing.In(Easing.Quad);
                    Burst("poof", q.X, q.Y - q.S * 0.3, q.S / 56);
                    Animated.Parallel(
                        Animated.Timing(P.Y, T(p.y + B.T * 0.5, 320, e)),
                        Animated.Timing(P.K, T(p.k * 0.5, 320, e)),
                        Animated.Timing(P.Rot, T(1.6, 320, e)),
                        Animated.Timing(P.O, T(0, 320, Easing.In(Easing.Cubic))),
                        Animated.Timing(P.Shadow, T(0, 140))).Start(r =>
                    {
                        Show(cell, false);
                        if (_red == cell) SetRed(-1);
                    });
                });
            });
            Later(260, () => { var q = B.StandOn(cell); Burst("angry", q.X, q.Y - q.S * 0.6, q.S / 56); });
            Later(200, Shake);
            for (int other = 0; other < _cells; other++)
            {
                if (!_placed[other]) continue;
                double at = 240 + SdLevel.Random() * 80;
                Hop(other, at, 0.18);
                Face(other, "sad", delay: at, hold: 420);
            }
        }

        public void Wiggle(int cell)
        {
            Face(cell, "happy", hold: 380);
            Rock(cell, new[] { -0.7, 0.7, -0.4, 0 }, 380);
        }

        void SetRed(int cell)
        {
            if (_red == cell) return;
            _redPulse?.Unmount();
            _redPulse = null;
            _red = cell;
            if (cell < 0) return;
            var (svg, box) = SdArt.RedGlow(B, cell);
            (_redL ??= new SdLayer("red glow")).Set(svg, (float)box.Width, (float)box.Height, 2);
            _redBox = box;
            _redPulse = new KeyLoop(260, KeyLoop.PHASE, Array.ConvertAll(TRIANGLE, k => 0.35 + (0.9 - 0.35) * k));
            var pulse = _redPulse;
            _effect(() => { if (_redPulse == pulse) pulse.Mount(); });
        }

        /// <summary>The board cascading in, a diagonal wave from the back left.</summary>
        public void Intro()
        {
            for (int cell = 0; cell < _cells; cell++)
            {
                var A = _cellA[cell];
                A.A.SetValue(0);
                Animated.Timing(A.A, T(1, 300, Easing.Out(Easing.Back(1.4)), (cell % N + cell / N) * 34)).Start();
            }
        }

        public void Outro()
        {
            for (int cell = 0; cell < _cells; cell++)
                Animated.Timing(_cellA[cell].A, T(0, 220, Easing.In(Easing.Quad), (2 * N - 2 - cell % N - cell / N) * 18)).Start();
        }

        /// <summary>The win: every creature turns happy, and a bounce ripples out over the board from `from` (the last one
        /// placed): the cushions bob, the creatures jump (twice unless `once`), a wave of stars over half the cells. It
        /// starts with the last one's hop for joy (Place). `spread`: ms from the first jump to the farthest. Returns when each
        /// creature jumps (ms from now, in order), for the games' hop sounds.</summary>
        public List<double> HopAll(int from = 0, double spread = 380, bool once = false)
        {
            double start = Math.Max(0, _landAt + 120 - _tk.Now);
            double far = 1;
            for (int x = 0; x < _cells; x++) far = Math.Max(far, Gap(x, from));
            double step = Math.Min(70, spread / far);
            var beats = new List<double>();
            var pts = new List<Wave.Spot>();
            for (int cell = 0; cell < _cells; cell++)
            {
                double d = Gap(cell, from) * step;
                Bounce(cell, start + d);
                // stars on half the cells, no glows: a 9×9's every cell would mount ~150 views at once
                if ((cell / N + cell) % 2 == 0) pts.Add(Spot(cell, d, false));
                if (!_placed[cell]) continue;
                CancelHops(cell);
                Face(cell, "happy", delay: cell == from ? 0 : 60);
                Hop(cell, start + d, 0.6);
                if (!once) Hop(cell, start + d + 380, 0.32);
                beats.Add(start + d);
            }
            Later(start, () => StartWave(pts, B.C * 0.9));
            beats.Sort();
            return beats;
        }

        /// <summary>A lost level: one creature after another (nearest `from` first, else back to front) turns sad, droops
        /// and sinks a little, and stays so, `step` ms apart. Returns how long that takes (ms).</summary>
        public double SadAll(int from = -1, double step = SAD_STEP)
        {
            var on = PlacedCells();
            // (Array.sort is stable: equal gaps keep their order)
            if (from >= 0) { var idx = new Dictionary<int, int>(); for (int i = 0; i < on.Count; i++) idx[on[i]] = i; on.Sort((a, b) => { int c = Gap(a, from).CompareTo(Gap(b, from)); return c != 0 ? c : idx[a].CompareTo(idx[b]); }); }
            for (int i = 0; i < on.Count; i++)
            {
                int cell = on[i];
                double at = 60 + i * step;
                var P = _poses[cell];
                CancelHops(cell);
                Face(cell, "sad", delay: at, ms: 180);
                Later(at, () =>
                {
                    var p = PoseOn(cell);
                    int side = (cell + cell / N) % 2 != 0 ? 1 : -1;
                    Run(P.Droop, 1, 460, Easing.Out(Easing.Back(1.4)));
                    Run(P.Y, p.y + B.T * 0.06, 460, Easing.Out(Easing.Quad));
                    Run(P.Rot, side * 0.35, 460, Easing.InOut(Easing.Quad));
                });
            }
            return on.Count > 0 ? 60 + (on.Count - 1) * step + 460 : 0;
        }

        /// <summary>After a lost run is saved (Blitz): everyone perks back up with a hop.</summary>
        public void CheerUp()
        {
            var on = PlacedCells();
            for (int i = 0; i < on.Count; i++)
            {
                int cell = on[i];
                var P = _poses[cell];
                var p = PoseOn(cell);
                Face(cell, "idle", ms: 200);
                Run(P.Droop, 0, 260);
                Run(P.Y, p.y, 260);
                Run(P.Rot, 0, 260);
                Hop(cell, 160 + i * 40, 0.35);
            }
        }

        // ---- touches (the board area's own dp) ------------------------------------------------------------------------
        const double LONG_PRESS_MS = 380, MOVE_SLOP = 8;
        sealed class Gesture { public int Start = -1, Last = -1; public bool Painting, PaintOn = true, Moved, LongDone; public int Timer = -1; public float X0, Y0; }
        Gesture _g;

        void Paint(int cell)
        {
            var g = _g;
            if (cell < 0 || cell == g.Last) return;
            g.Last = cell;
            if (_placed[cell] || _markOn[cell] == g.PaintOn) return;
            OnMark?.Invoke(cell, g.PaintOn);
        }

        public void Down(float x, float y)
        {
            var g = _g = new Gesture { X0 = x, Y0 = y };
            g.Start = B.CellAt(x, y);
            if (_locked() || g.Start < 0) return;
            bool allowX = _allowX();
            if (XTool() && allowX) { g.Painting = true; g.PaintOn = !_markOn[g.Start]; }
            else if (allowX && !_placed[g.Start])
                g.Timer = _tk.SetTimeout(() => { g.LongDone = true; g.Painting = true; g.PaintOn = !_markOn[g.Start]; Paint(g.Start); }, LONG_PRESS_MS);
        }

        public void Move(float x, float y)
        {
            var g = _g;
            if (g == null || _locked()) return;
            if (!g.Moved && Math.Abs(x - g.X0) + Math.Abs(y - g.Y0) > MOVE_SLOP)
            {
                g.Moved = true;
                if (!g.Painting) _tk.ClearTimeout(g.Timer);
                if (g.Painting && g.Last < 0) Paint(g.Start);
            }
            if (g.Painting && g.Moved) Paint(B.CellAt(x, y));
        }

        public void Up()
        {
            var g = _g;
            _g = null;
            if (g == null) return;
            _tk.ClearTimeout(g.Timer);
            if (_locked() || g.Start < 0 || g.LongDone || g.Moved) return;
            if (_placed[g.Start]) { OnTapPiece?.Invoke(g.Start); return; }
            OnTap?.Invoke(g.Start);
        }

        // ---- every frame ---------------------------------------------------------------------------------------------
        static Interpolator L(double[] i, double[] o, bool clamp = false) => Fx.Lerp(i, o, clamp);
        static readonly Interpolator CushScale = L(new[] { 0.0, 1 }, new[] { 0.3, 1 }), BumpScale = L(new[] { 0.0, 1 }, new[] { 1, 1.09 });
        static readonly Interpolator XScale = L(new[] { 0.0, 1 }, new[] { 1.6, 1 });

        // hop/Pieces.js's juicy moves, each a phase 0 → 1 read through keyframes (the ones Squishdoku's board plays)
        const double CROUCH = 0.24;
        static Interpolator ArcFrom(double t0, double peak = 1)
        {
            double[] u = { 0, 0.1, 0.25, 0.5, 0.75, 0.9, 1 };
            var at = new List<double>(); var o = new List<double>();
            if (t0 > 0) { at.Add(0); o.Add(0); }
            foreach (var x in u) { at.Add(t0 + x * (1 - t0)); o.Add(-4 * x * (1 - x) * peak); }
            return L(at.ToArray(), o.ToArray());
        }
        // a hop: squashed down in the crouch, stretched tall as it takes off and while it falls
        static readonly Interpolator HopArc = ArcFrom(CROUCH);
        static readonly double[] HOP_AT = { 0, 0.2, 0.32, 0.48, 0.66, 0.86, 1 };
        static readonly Interpolator HopSx = L(HOP_AT, new[] { 1, 1.2, 0.84, 0.92, 1, 0.93, 1 }), HopSy = L(HOP_AT, new[] { 1, 0.76, 1.24, 1.1, 1, 1.09, 1 });
        // the landing: squashed flat, a springy wobble back up
        static readonly double[] LAND_AT = { 0, 0.08, 0.2, 0.38, 0.56, 0.74, 0.88, 1 };
        static readonly Interpolator LandSx = L(LAND_AT, new[] { 1, 1.3, 1.26, 0.9, 1.06, 0.97, 1.01, 1 }), LandSy = L(LAND_AT, new[] { 1, 0.7, 0.74, 1.12, 0.95, 1.03, 0.99, 1 });
        // `no`, a shake of the head (degrees, about the middle)
        static readonly Interpolator NoDeg = L(new[] { 0, 0.22, 0.32, 0.46, 0.6, 0.74, 0.86, 1 }, new[] { 0.0, 0, 36, -32, 22, -11, 4, 0 });
        // drooped: sunk down and wide, its top hanging toward the camera
        const double DROOP_X = 1.08, DROOP_Y = 0.86, DROOP_TILT = -14;
        // two squashes at once (a landing still wobbling as the next hop crouches) give way softly
        static readonly Interpolator SoftX = L(new[] { 0, 0.7, 1.34, 3 }, new[] { 0.64, 0.7, 1.34, 1.46 }), SoftY = L(new[] { 0, 0.66, 1.36, 3 }, new[] { 0.6, 0.66, 1.36, 1.5 });
        static readonly Interpolator ShadowK = L(new[] { -1.8, 0 }, new[] { 0.45, 1 }, true);
        static readonly Interpolator RotDeg = L(new[] { -1.0, 1 }, new[] { -10.0, 10 });
        // FacedSquishy: the idle one goes once a face is all the way in; the red copy flashes twice, ~0.6 strong
        static readonly Interpolator IdleOp = L(new[] { 0, 0.97, 1 }, new[] { 1.0, 1, 0 }, true);
        static readonly Interpolator RedOp = L(new[] { 0, 0.12, 0.32, 0.46, 1 }, new[] { 0, 0.62, 0.12, 0.62, 0 }, true);

        static Affine About(double w, double h, Affine m) => Affine.Translate(w / 2, h / 2) * m * Affine.Translate(-w / 2, -h / 2);
        static Affine Feet(double h, Affine m) => Affine.Translate(0, h / 2) * m * Affine.Translate(0, -h / 2);

        /// <summary>The board's layers, bottom first, with the board area's top-left at `area` (the board shakes inside it),
        /// all `opacity` (hidden: 0).</summary>
        public void Layers(Affine area, List<SdLayer> o, float opacity = 1)
        {
            area = area * Affine.Translate(_shakeX.GetValue(), 0);
            for (int cell = 0; cell < _cells; cell++)
            {
                var A = _cellA[cell];
                double a = A.A.GetValue(), b = A.Bump.GetValue(), k = CushScale.Evaluate(a) * BumpScale.Evaluate(b);
                A.L.Transform = area * Affine.Translate(A.Box.Left, A.Box.Top) * About(A.Box.Width, A.Box.Height, Affine.Translate(0, b * -B.T * 0.06) * Affine.ScaleBy(k, k));
                A.L.Opacity = (float)a * opacity;
                o.Add(A.L);
            }
            for (int cell = 0; cell < _cells; cell++)
            {
                if (!_markOn[cell] || _placed[cell] || _markL[cell] == null) continue;
                double t = _markT[cell].GetValue(), k = XScale.Evaluate(t);
                var bx = _markBox[cell];
                _markL[cell].Transform = area * Affine.Translate(bx.Left, bx.Top) * About(bx.Width, bx.Height, Affine.ScaleBy(k, k));
                _markL[cell].Opacity = (float)t * opacity;
                o.Add(_markL[cell]);
            }
            if (_red >= 0)
            {
                _redL.Transform = area * Affine.Translate(_redBox.Left, _redBox.Top);
                _redL.Opacity = (float)_redPulse.Value * opacity;
                o.Add(_redL);
            }
            var order = new List<int>();
            for (int cell = 0; cell < _cells; cell++) if (_shown[cell]) order.Add(cell);
            order.Sort((p, q) => ZOf(p) != ZOf(q) ? ZOf(p).CompareTo(ZOf(q)) : p.CompareTo(q));
            foreach (var cell in order) PlacePiece(cell, area, o, opacity);
            // the FxLayer: the waves, then the bursts
            foreach (var w in _waves) w.Place(area, opacity, o);
            foreach (var bu in _bursts) { bu.Place(area, opacity); foreach (var l in bu.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
        }

        // hop/Pieces.js Piece (juicy): placed and sized by x, y, k; hopping by lift; leaning (rotateX: drooped), rocked and
        // squashed from its feet; its head turned (rotateY: the "no"), drawn flat as a narrowing; breathing and peeking;
        // a creature with faces shows them by happy / sad and flashes red (FacedSquishy)
        void PlacePiece(int cell, Affine area, List<SdLayer> o, float opacity)
        {
            var P = _poses[cell];
            double w = _pw, h = HOf(cell);
            double hp = P.Hp.GetValue(), land = P.Land.GetValue(), droop = P.Droop.GetValue();
            double arc = HopArc.Evaluate(hp);
            double sx = SoftX.Evaluate(HopSx.Evaluate(hp) * LandSx.Evaluate(land) * (1 + (DROOP_X - 1) * droop));
            double sy = SoftY.Evaluate(HopSy.Evaluate(hp) * LandSy.Evaluate(land) * (1 + (DROOP_Y - 1) * droop));
            double tilt = DROOP_TILT * droop * Math.PI / 180, yaw = NoDeg.Evaluate(P.No.GetValue()) * Math.PI / 180;
            double br = P.Breathe?.Value ?? 0, peek = P.Peek?.Value ?? 0;
            double k = P.K.GetValue();
            var outer = area * About(w, h, Affine.Translate(P.X.GetValue(), P.Y.GetValue()) * Affine.ScaleBy(k, k));
            float op = (float)P.O.GetValue() * opacity;
            double sk = ShadowK.Evaluate(arc);
            P.ShadowL.Transform = outer * Affine.Translate(0.14 * w, 0.9 * h) * About(0.72 * w, 0.15 * h, Affine.ScaleBy(sk, sk));
            P.ShadowL.Opacity = op * (float)P.Shadow.GetValue();
            o.Add(P.ShadowL);
            var body = outer * Affine.Translate(0, arc * P.LiftH.GetValue())
                * About(w, h, Feet(h, Affine.ScaleBy(1, Math.Cos(tilt)) * Affine.Rotate(RotDeg.Evaluate(P.Rot.GetValue())) * Affine.ScaleBy(sx, sy)))
                * About(w, h, Affine.ScaleBy(Math.Cos(yaw), 1))
                * About(w, h, Feet(h, Affine.ScaleBy(1 + 0.03 * br, 1 - 0.03 * br) * Affine.Rotate(peek)));
            if (P.HappyL == null)
            {
                P.Body.Transform = body;
                P.Body.Opacity = op;
                o.Add(P.Body);
                return;
            }
            double happy = P.Happy.GetValue(), sad = P.Sad.GetValue(), red = RedOp.Evaluate(P.Red.GetValue());
            void Add(SdLayer l, double v) { if (v <= 0) return; l.Transform = body; l.Opacity = op * (float)Math.Min(1, v); o.Add(l); }
            Add(P.Body, IdleOp.Evaluate(happy + sad));
            Add(P.HappyL, happy);
            Add(P.SadL, sad);
            Add(P.RedL, red);
        }

        /// <summary>fx.js Wave: one spot after another (`d` ms in) lights up, a soft glow on the floor (`glow`: false for a
        /// spot with a creature standing on it) and a little star popping up off it and fading. All of it one timing of the
        /// wave's own milliseconds, each spot reading its own window of it.</summary>
        sealed class Wave
        {
            public struct Spot { public double X, Y, S, D; public bool Glow; }
            const double LIFE = 560;
            static readonly string[] STARS = { "#fff3a0", "#ffd1f5", "#c9f5ff", "#ffffff", "#ffe066", "#b8ffd9" };
            sealed class Part { public Spot P; public SdLayer Glow, Star; public double Gw, Gh, St, Side; }
            readonly List<Part> _parts = new List<Part>();
            readonly AnimatedValue _t = new AnimatedValue(0);
            readonly double _end;
            CompositeAnimation _a;

            public Wave(List<Spot> points, double flat)
            {
                double end = 0;
                for (int i = 0; i < points.Count; i++)
                {
                    var p = points[i];
                    end = Math.Max(end, p.D);
                    double gw = p.S * 0.72, st = Math.Max(6, p.S * 0.2);
                    var part = new Part { P = p, Gw = gw, Gh = gw * flat, St = st, Side = (i % 2 != 0 ? 1 : -1) * p.S * 0.12 };
                    if (p.Glow) part.Glow = new SdLayer("wave glow").Set(new UiSvg((float)gw, (float)(gw * flat)).Box(0, 0, (float)gw, (float)(gw * flat), new BoxStyle { Background = "#fff6cf", Radius = (float)gw }).Markup, (float)gw, (float)(gw * flat), 1);
                    part.Star = new SdLayer("wave star").Set(new UiSvg((float)st, (float)st).Box(0, 0, (float)st, (float)st, new BoxStyle { Background = STARS[i % STARS.Length], Radius = (float)(st * 0.18), BorderWidth = 1, BorderColor = "rgba(255,255,255,0.9)" }).Markup, (float)st, (float)st, 1);
                    _parts.Add(part);
                }
                _end = end + LIFE;
            }

            public void Start(Action done)
            {
                _a = Animated.Timing(_t, new TimingConfig { ToValue = _end, Duration = _end, Easing = Easing.Linear, UseNativeDriver = true });
                _a.Start(r => done());
            }
            public void Stop() => _a?.Stop();

            // a spot's window: keyframes at d + k × LIFE, clamped
            static double At(double t, Spot p, double[] ks, double[] o)
            {
                double u = (t - p.D) / LIFE;
                if (u <= ks[0]) return o[0];
                for (int i = 1; i < ks.Length; i++) if (u <= ks[i]) return o[i - 1] + (o[i] - o[i - 1]) * (u - ks[i - 1]) / (ks[i] - ks[i - 1]);
                return o[o.Length - 1];
            }
            static readonly double[] G_AT = { 0, 0.16, 0.62 }, G_OP = { 0, 0.5, 0 }, G_K = { 0.4, 1, 1.15 };
            static readonly double[] S_OP_AT = { 0.04, 0.18, 0.7, 1 }, S_OP = { 0, 1, 1, 0 }, S_AT2 = { 0.04, 1 }, S_Y_AT = { 0.04, 0.5, 1 }, S_K_AT = { 0.04, 0.22, 1 }, S_K = { 0.2, 1.15, 0.5 }, S_ROT = { 45, 225 };

            public void Place(Affine area, float opacity, List<SdLayer> o)
            {
                double t = _t.GetValue();
                foreach (var q in _parts)
                {
                    if (q.Glow == null) continue;
                    double op = At(t, q.P, G_AT, G_OP), k = At(t, q.P, G_AT, G_K);
                    if (op <= 0) continue;
                    q.Glow.Transform = area * Affine.Translate(q.P.X - q.Gw / 2, q.P.Y - q.Gh / 2) * About(q.Gw, q.Gh, Affine.ScaleBy(k, k));
                    q.Glow.Opacity = (float)op * opacity;
                    o.Add(q.Glow);
                }
                foreach (var q in _parts)
                {
                    var p = q.P;
                    double op = At(t, p, S_OP_AT, S_OP);
                    if (op <= 0) continue;
                    double tx = At(t, p, S_AT2, new[] { 0, q.Side }), ty = At(t, p, S_Y_AT, new[] { -p.S * 0.05, -p.S * 0.55, -p.S * 0.7 });
                    double rot = At(t, p, S_AT2, S_ROT), k = At(t, p, S_K_AT, S_K);
                    q.Star.Transform = area * Affine.Translate(p.X - q.St / 2, p.Y - q.St / 2) * About(q.St, q.St, Affine.Translate(tx, ty) * Affine.Rotate(rot) * Affine.ScaleBy(k, k));
                    q.Star.Opacity = (float)op * opacity;
                    o.Add(q.Star);
                }
            }
        }
    }
}
