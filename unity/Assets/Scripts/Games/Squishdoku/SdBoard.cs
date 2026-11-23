// A board of plush cushions lying on a room's floor (src/squishdoku/RoomBoard.js), as Blitz plays it: the cushions
// cascade in (intro) and out (outro), a right creature drops on (its patch ripples, its row and column bob, everyone
// hops), a wrong one shakes its head and poofs (the cell glows red, the board shakes), everyone hops row by row
// (hopAll), a tap on a placed creature wiggles it, and now and then one does a trick while the board isn't locked.
// Touches: a tap on a cushion (onTap), on a placed creature (onTapPiece); with `allowX`, long-press and drag paint ✕
// (onMark). SdLevel has the same board built in (Regular, the code it was ported from); this one stands alone so Blitz
// can make a new one for every board. No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
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
        readonly bool _allowX;
        readonly Action<Action> _effect;
        readonly List<int> _timers = new List<int>();
        readonly int _cells;
        public Action<int> OnTap, OnTapPiece;
        public Action<int, bool> OnMark;
        public Func<bool> XTool = () => false;

        sealed class Pose
        {
            public readonly AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), K = new AnimatedValue(1), O = new AnimatedValue(1),
                Shadow = new AnimatedValue(1), Rot = new AnimatedValue(0), Hp = new AnimatedValue(0), LiftH = new AnimatedValue(0),
                Land = new AnimatedValue(1);
            public KeyLoop Breathe, Peek;
            public SdLayer ShadowL, Body;
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
        int _trick = -1;
        readonly float _pw;
        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();

        static readonly double[] PEEK_AT = { 0, 0.84, 0.88, 0.92, 0.96, 1 };
        static readonly double[] PEEK_DEG = { 0, 0, -9, 8, -3, 0 };
        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        /// <summary>`colors`: each patch's colour (a 600-levels board's), or null (Blitz's: in order). `effect`: runs what the
        /// app runs in an effect (a native loop starting once its view is up).</summary>
        public SdBoard(Board b, int n, int[] regions, int[] solution, int[] colors, SdCreature[] pieces, Ticker tk, Func<bool> locked, bool allowX, Action<Action> effect)
        {
            B = b; N = n; _regions = regions; _solution = solution; _colors = colors; _pieces = pieces; _tk = tk; _locked = locked; _allowX = allowX;
            _effect = effect ?? (a => a());
            _cells = n * n;
            _cellA = new CellA[_cells]; _poses = new Pose[_cells];
            _markOn = new bool[_cells]; _placed = new bool[_cells]; _shown = new bool[_cells];
            _markT = new AnimatedValue[_cells]; _markL = new SdLayer[_cells]; _markBox = new Board.Box[_cells];
            _pw = (float)(B.T * 0.7);
            for (int cell = 0; cell < _cells; cell++)
            {
                var (svg, box) = SdArt.Cushion(B, cell, ColorIdx(_regions[cell]));
                _cellA[cell] = new CellA { L = new SdLayer("cushion " + cell).Set(svg, (float)box.Width, (float)box.Height, 2), Box = box };
                var p = _poses[cell] = new Pose();
                var c = PieceOf(cell);
                float h = HOf(cell);
                p.ShadowL = new SdLayer("shadow " + cell).Set(SdArt.Shadow(_pw * 0.72f, h * 0.15f, "rgba(69,16,122,0.28)"), _pw * 0.72f, h * 0.15f, 1);
                p.Body = new SdLayer("creature " + cell).SetPicture(c.Picture, _pw, h);
            }
            // now and then one placed creature does a trick, so a board in progress never sits still
            Action trick = null;
            trick = () =>
            {
                _trick = _tk.SetTimeout(trick, 1400);
                if (_locked()) return;
                var on = new List<int>();
                for (int i = 0; i < _cells; i++) if (_placed[i]) on.Add(i);
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
        }

        int ColorIdx(int reg) => _colors != null ? _colors[reg] : reg;
        SdCreature PieceOf(int cell) { int r = _regions[cell]; return r < _pieces.Length && _pieces[r] != null ? _pieces[r] : _pieces[0]; }
        float HOf(int cell) => _pw * PieceOf(cell).Ar;
        int ZOf(int cell) => 10 + cell / N * 3;
        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));

        static TimingConfig T(double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            new TimingConfig { ToValue = to, Duration = ms, Easing = easing ?? Easing.Out(Easing.Quad), Delay = delay, UseNativeDriver = true };

        public bool IsPlaced(int cell) => _placed[cell];
        public bool IsMarked(int cell) => _markOn[cell];

        (double x, double y, double k) PoseOn(int cell)
        {
            var q = B.StandOn(cell);
            float h = HOf(cell);
            double k = q.S / B.T;
            return (q.X - _pw / 2.0, q.Y - h / 2.0 * (1 + k), k);
        }

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

        void Drop(int cell, Action done)
        {
            var P = _poses[cell];
            var p = PoseOn(cell);
            P.Rot.SetValue(0); P.Hp.SetValue(0);
            P.Land.SetValue(1); P.Shadow.SetValue(1);
            P.X.SetValue(p.x); P.K.SetValue(p.k);
            P.Y.SetValue(p.y - B.T * 0.9);
            P.O.SetValue(0);
            Show(cell, true);
            Later(30, () => Animated.Parallel(Animated.Timing(P.Y, T(p.y, 200, Easing.In(Easing.Quad))), Animated.Timing(P.O, T(1, 90, Easing.Linear))).Start(r =>
            {
                P.Land.SetValue(0);
                Animated.Timing(P.Land, T(1, 240)).Start();
                done?.Invoke();
            }));
        }

        void Hop(int cell, double delay = 0, double high = 0.45)
        {
            var P = _poses[cell];
            Later(delay, () =>
            {
                P.Hp.SetValue(0);
                P.LiftH.SetValue(B.T * high);
                Animated.Timing(P.Hp, T(1, 340, Easing.Linear)).Start(r =>
                {
                    P.Land.SetValue(0);
                    Animated.Timing(P.Land, T(1, 200)).Start();
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

        void Burst(string kind, double x, double y, double scale)
        {
            var b = new Burst(kind, x, y, scale);
            if (_bursts.Count > 11) { var first = _bursts[0]; first.Stop(); _bursts.Remove(first); }
            _bursts.Add(b);
            b.Start(() => _bursts.Remove(b));
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

        /// <summary>A right creature on `cell`.</summary>
        public void Place(int cell)
        {
            var before = (bool[])_placed.Clone();
            _placed[cell] = true;
            _markOn[cell] = false;
            Drop(cell, () =>
            {
                var q = B.StandOn(cell);
                Burst("pop", q.X, q.Y - q.S * 0.2, q.S / 56);
                Burst("spark", q.X, q.Y - q.S * 0.5, q.S / 56);
                Hop(cell, 60, 0.35);
            });
            const double land = 200;
            int n = N;
            var dist = DistancesInPatch(cell);
            foreach (var kv in dist) Bounce(kv.Key, land + kv.Value * 45);
            int r = cell / n, c = cell % n;
            for (int i = 0; i < n; i++)
            {
                int row = r * n + i, col = i * n + c;
                if (!dist.ContainsKey(row)) Bounce(row, land + Math.Abs(i - c) * 35);
                if (!dist.ContainsKey(col)) Bounce(col, land + Math.Abs(i - r) * 35);
            }
            for (int other = 0; other < _cells; other++)
            {
                if (!before[other] || other == cell) continue;
                int d = Math.Abs(other / n - r) + Math.Abs(other % n - c);
                Hop(other, land + 60 + d * 55, 0.3);
            }
        }

        /// <summary>A wrong creature on `cell`.</summary>
        public void Wrong(int cell)
        {
            _markOn[cell] = false;
            SetRed(cell);
            var P = _poses[cell];
            Drop(cell, () =>
            {
                Rock(cell, new[] { -0.9, 0.9, -0.7, 0.7, -0.3, 0 }, 560);
                Later(620, () =>
                {
                    var q = B.StandOn(cell);
                    Animated.Parallel(Animated.Timing(P.K, T(0.05, 220, Easing.In(Easing.Quad))), Animated.Timing(P.O, T(0, 220))).Start(r =>
                    {
                        Show(cell, false);
                        if (_red == cell) SetRed(-1);
                    });
                    Burst("poof", q.X, q.Y - q.S * 0.3, q.S / 56);
                });
            });
            Later(260, () => { var q = B.StandOn(cell); Burst("angry", q.X, q.Y - q.S * 0.6, q.S / 56); });
            Later(200, Shake);
            for (int other = 0; other < _cells; other++) if (_placed[other]) Hop(other, 240 + SdLevel.Random() * 80, 0.18);
        }

        public void Wiggle(int cell) => Rock(cell, new[] { -0.7, 0.7, -0.4, 0 }, 380);

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

        public void HopAll()
        {
            for (int cell = 0; cell < _cells; cell++)
            {
                double d = cell / N * 75;
                if (_placed[cell]) Hop(cell, d, 0.6);
                Bounce(cell, d + 120);
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
            if (XTool() && _allowX) { g.Painting = true; g.PaintOn = !_markOn[g.Start]; }
            else if (_allowX && !_placed[g.Start])
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
        static Interpolator L(double[] i, double[] o) => Fx.Lerp(i, o);
        static readonly Interpolator CushScale = L(new[] { 0.0, 1 }, new[] { 0.3, 1 }), BumpScale = L(new[] { 0.0, 1 }, new[] { 1, 1.09 });
        static readonly Interpolator Arc = L(new[] { 0, 0.25, 0.5, 0.75, 1 }, new[] { 0, -0.75, -1, -0.75, 0 });
        static readonly Interpolator HpX = L(new[] { 0, 0.4, 1 }, new[] { 1, 0.9, 1 }), LandX = L(new[] { 0, 0.55, 1 }, new[] { 1.14, 0.96, 1 });
        static readonly Interpolator HpY = L(new[] { 0, 0.4, 1 }, new[] { 1, 1.12, 1 }), LandY = L(new[] { 0, 0.55, 1 }, new[] { 0.86, 1.05, 1 });
        static readonly Interpolator RotDeg = L(new[] { -1.0, 1 }, new[] { -10.0, 10 }), ShadowK = L(new[] { -1.0, 0 }, new[] { 0.6, 1 });
        static readonly Interpolator XScale = L(new[] { 0.0, 1 }, new[] { 1.6, 1 });

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
            foreach (var bu in _bursts) { bu.Place(area, opacity); foreach (var l in bu.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
        }

        void PlacePiece(int cell, Affine area, List<SdLayer> o, float opacity)
        {
            var P = _poses[cell];
            double w = _pw, h = HOf(cell);
            double hp = P.Hp.GetValue(), land = P.Land.GetValue(), arc = Arc.Evaluate(hp);
            double sx = HpX.Evaluate(hp) * LandX.Evaluate(land), sy = HpY.Evaluate(hp) * LandY.Evaluate(land);
            double br = P.Breathe?.Value ?? 0, peek = P.Peek?.Value ?? 0;
            double k = P.K.GetValue();
            var outer = area * About(w, h, Affine.Translate(P.X.GetValue(), P.Y.GetValue()) * Affine.ScaleBy(k, k));
            float op = (float)P.O.GetValue() * opacity;
            double sk = ShadowK.Evaluate(arc);
            P.ShadowL.Transform = outer * Affine.Translate(0.14 * w, 0.9 * h) * About(0.72 * w, 0.15 * h, Affine.ScaleBy(sk, sk));
            P.ShadowL.Opacity = op * (float)P.Shadow.GetValue();
            o.Add(P.ShadowL);
            P.Body.Transform = outer * Affine.Translate(0, arc * P.LiftH.GetValue())
                * About(w, h, Feet(h, Affine.ScaleBy(sx, sy) * Affine.Rotate(RotDeg.Evaluate(P.Rot.GetValue()))))
                * About(w, h, Feet(h, Affine.ScaleBy(1 + 0.03 * br, 1 - 0.03 * br) * Affine.Rotate(peek)));
            P.Body.Opacity = op;
            o.Add(P.Body);
        }
    }
}
