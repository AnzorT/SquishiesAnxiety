// One level of Squish Stack and the ones after it, as src/stack/Game.js plays it (Blitz, puzzle after puzzle until a
// mistake: StackBlitz.cs, the same class), in landscape (develop, the user 2026-11-16: the back orb top left and the goal
// bottom left; the counter, MOVES n / par and the tier, at the top in the middle with the cushions under it; RESTART and
// HINT side by side at the bottom right. The two side columns are 200 dp each, so the cushions sit in the middle).
//   intro  the level's number and what's in it          deal  the squishies drop onto their cushions
//   play   tap a cushion to lift its top squishy, tap another to put it there; or drag it. Lifted, it stretches up and
//          dangles from its top (dragged, it swings against the way it's moved, then like a pendulum); the one under it
//          springs up, relieved. Dropped, it lands with a squash that runs down the tower to the cushion, and a puff of
//          dust. A big one dropped on a smaller one flattens it like a pancake (dizzy stars, a red flash, TOO BIG!),
//          boings off shaking its head "nope" and arcs home (no move counted). No clock and no UNDO (the user,
//          2026-11-16): RESTART and HINT (two hops).
//   won    a bounce wave up each tower with a sparkle off each one; the result card 1500 ms later: MENU / REPLAY / NEXT
//   The back orb (or Escape, Android's back) while playing pauses: the pause card (RESUME / QUIT). The first HINT of a
//   level asks first (the hint card: it costs a star, and an ad without Remove Ads).
// The moves are develop's of 2026-11-17 (SQUISH_STACK.md "Moves"): each a phase 0 → 1 read through keyframes, a path
// one timing per axis (PathTiming), as Game.js's pieceAnims.
// Every motion is the app's: the same Animated timings, springs and easings (SquishSquad.Anim is React Native's
// Animated in C#), the same geometry. The pieces: Resources/Stack (tools/unity/export-stack.mjs) and StackArt; the
// cards: StackCards on Ui/Cards.
// Profile is the game's copy of the player's
// (MenuScreen.SeedGameProfiles); signed in, each outcome is also saved to the account where the app saves it (StackSave).
using System;
using System.Collections.Generic;
using SquishSquad.Audio;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Stack
{
    public sealed partial class StackGame : MonoBehaviour
    {
        // ---- setup --------------------------------------------------------------------------------------------------
        public Action OnExit;
        public static IDictionary<string, object> Profile = new Dictionary<string, object>();   // until Firebase (step 3)
        /// <summary>Remove Ads (or no ads in this build: Ui/AdHook): a hint is free.</summary>
        public static bool AdsFree => AdHook.AdsFree(Profile);
        /// <summary>Whether a rewarded ad is loaded. Only read without AdsFree.</summary>
        static bool AdReady => AdHook.Ready();
        /// <summary>The app asks before the first hint of a level even with Remove Ads ("We'll show you the next best move.",
        /// SHOW ME): the hint costs a star either way (Game.js askHint). false: hints come at once, without the card.</summary>
        public const bool AskBeforeHint = true;

        float W, H;                      // the screen, dp
        Ticker _anim;
        int _lv, _round;
        LevelSpec _spec;
        Puzzle _puzzle;
        Squishy[] _who;
        int _limit;
        Geometry _g;
        PieceAnims[] _anims;
        AnimatedValue[] _bumps;
        static StackLayout _layout;

        // pieces
        UiPiece _bg, _counter, _goal, _back, _rug, _colGlow, _bannerPiece;
        UiPiece[] _seats, _halos, _badges, _pieces;
        readonly List<Btn> _btns = new List<Btn>();

        const float GAP = 16;
        static readonly Func<double, double> GRAVITY = Easing.Bezier(0.55, 0, 1, 0.45);
        const float SideW = StackArt.SideW;
        // the cushions' area: between the side columns, under the counter's row (6 dp padding over the counter)
        float AreaX => SideW;
        float _areaY;

        public static StackGame Create(Transform parent, int startLv, float screenW = 0, float screenH = 0)
        {
            var go = new GameObject("Squish Stack");
            go.transform.SetParent(parent, false);
            var g = go.AddComponent<StackGame>();
            g._lv = Mathf.Clamp(startLv, 1, Levels.LEVELS);
            g._screenW = screenW; g._screenH = screenH;
            return g;
        }

        float _screenW, _screenH;   // the screen in px (default: Screen)
        bool _started;
        double _t0;

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen with the clock at `nowMs` (Unity calls it; CI screenshots call it outside play mode).</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            Snd.Preload(new[] { "st_lift", "st_land", "st_cushion", "st_ouch", "st_bounce", "st_undo", "st_hint", "st_empty", "st_news", "sd_tick", "sd_solve", "sd_confetti", "sd_boardIn", "sd_timeUp" });
            _layout ??= StackLayout.Load();
            _anim = new Ticker(nowMs);
            Ticker.Default = _anim;
            W = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp;
            H = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            _bg = Piece("bg", 0);
            _bg.SetSvg(Xml("bg"), 832, 384, 0);
            // the page stretched over the whole screen (it's a gradient and rays)
            _bg.Transform = Affine.ScaleBy(W / 832, H / 384);
            _counter = Piece("counter", 10);
            _goal = Piece("goal", 10);
            _back = Piece("back", 11);
            _back.SetSvg(Xml("back"), 40, 40);
            _back.Transform = Affine.Translate(_layout.back[0], _layout.back[1]);
            _areaY = 6 + StackArt.CounterSize(new StackArt.Counter { Blitz = _blitz, Moves = 0, Par = 1 }).h;
            // RESTART and HINT side by side at the bottom right (sideR: 12 dp in, 10 up, 8 apart), as the reference screen
            // has them; Blitz has no HINT: RESTART alone at the right
            var (rx, ry, rw, rh) = _layout.Button("btn-restart-on");
            var (hx, _, hw, _) = _layout.Button("btn-hint-on");
            float right = W - 12, bottom = H - 10;
            _btns.Add(new Btn(this, "restart", _blitz ? right - rw : right - (832 - 12 - rx), bottom - rh, rw, rh, 22, () => Restart()));
            if (!_blitz) _btns.Add(new Btn(this, "hint", right - (832 - 12 - hx), bottom - rh, hw, rh, 24, () => AskHint()));
            _rug = Piece("rug", 30);
            _colGlow = Piece("column glow", 31);
            _bannerPiece = Piece("banner", 200);
            // TOO BIG!'s quick red flash over the play area (zIndex 110), the dizzy stars over it (120)
            _flashPiece = Piece("too big flash", 150);
            _flashPiece.Visible = false;
            for (int i = 0; i < 3; i++) { _dizzyPieces[i] = Piece("dizzy star " + i, 160); _dizzyPieces[i].Visible = false; }
            _cardPieces = new CardPieces(transform, 300);
            _bumps = new AnimatedValue[4];
            for (int i = 0; i < 4; i++) _bumps[i] = new AnimatedValue(0);
            if (_blitz) BlitzInit();
            NewPuzzle();
        }

        UiPiece Piece(string name, int order) => UiPiece.Create(transform, name, order);
        static string Xml(string name) => Resources.Load<TextAsset>("Stack/" + name)?.text ?? throw new InvalidOperationException("Resources/Stack/" + name + ".xml is missing: run node tools/unity/export-stack.mjs");

        // ---- geometry (Game.js geometry, spotsOf) ---------------------------------------------------------------------
        sealed class Geometry
        {
            public float W, H, ColW, CushW, CushH, Surface, Hover;
            public int K;
            public float[] Bw, Bh;
        }

        static (float sx, float sy) WeightOf(int above) => (1 + 0.035f * above, Math.Max(0.8f, 1 - 0.045f * above));

        struct Line { public int R; public float Yb, Sx, Sy; }

        static (List<Line> lines, float height) StackLines(List<int> list, float[] bh)
        {
            float yb = 0;
            var out_ = new List<Line>();
            for (int j = 0; j < list.Count; j++)
            {
                var (sx, sy) = WeightOf(list.Count - 1 - j);
                out_.Add(new Line { R = list[j], Yb = yb, Sx = sx, Sy = sy });
                yb -= bh[list[j]] * sy * (1 - StackArt.OVER);
            }
            float height = list.Count > 0 ? -(out_[out_.Count - 1].Yb - bh[list[list.Count - 1]]) : 0;
            return (out_, height);
        }

        static Geometry Geom(float w, float h, int n, int k, Squishy[] who)
        {
            float colW = w / k;
            float cushW = Math.Min(colW * 0.86f, 150);
            float cushH = Math.Max(24, Math.Min(cushW * 0.34f, 44));
            float surface = h - 18 - cushH * 0.6f;
            var ratio = new float[n];
            for (int r = 0; r < n; r++) ratio[r] = who[r].BodyH(1);
            float[] Widths(float m) { var a = new float[n]; for (int r = 0; r < n; r++) a[r] = m * (n == 1 ? 1 : 0.5f + 0.5f * r / (n - 1)); return a; }
            float maxW = Math.Min(colW * 0.94f, 140);
            var bw = Widths(maxW);
            var bh = new float[n];
            for (int r = 0; r < n; r++) bh[r] = bw[r] * ratio[r];
            var all = new List<int>();
            for (int i = 0; i < n; i++) all.Add(n - 1 - i);
            float tower = StackLines(all, bh).height;
            float maxBh = 0; foreach (var v in bh) maxBh = Math.Max(maxBh, v);
            float s = Math.Max(0.3f, Math.Min(1, (surface - 10) / (tower + GAP + maxBh)));
            bw = Widths(maxW * s);
            for (int r = 0; r < n; r++) bh[r] = bw[r] * ratio[r];
            return new Geometry { W = w, H = h, K = k, ColW = colW, CushW = cushW, CushH = cushH, Surface = surface, Bw = bw, Bh = bh, Hover = surface - tower * s - GAP };
        }

        float Cx(int p) => _g.ColW * (p + 0.5f);

        struct Spot { public float X, Y, Sx, Sy; public int Z; }

        Dictionary<int, Spot> SpotsOf(int[] pos, int skip = -1)
        {
            var m = new Dictionary<int, Spot>();
            for (int p = 0; p < _g.K; p++)
            {
                var list = new List<int>();
                foreach (var r in Engine.StackOf(pos, p)) if (r != skip) list.Add(r);
                var (lines, _) = StackLines(list, _g.Bh);
                for (int j = 0; j < lines.Count; j++)
                {
                    var o = lines[j];
                    m[o.R] = new Spot { X = Cx(p) - _g.Bw[o.R] / 2, Y = _g.Surface + o.Yb - _g.Bh[o.R], Sx = o.Sx, Sy = o.Sy, Z = 10 + j };
                }
            }
            return m;
        }

        // ---- how the squishies move (develop's Game.js, 2026-11-17, the user's list: SQUISH_STACK.md "Moves") -------------
        // Every move is one timing: a phase 0 → 1 read through keyframes (every list starts and ends at rest), or a place
        // reached along a path whose turns are worked into the timing's easing (PathTiming).
        static Interpolator Kf(double[] at, double[] v) => Fx.Lerp(at, v);
        // landing: squashed flat, a springy wobble back up (LdA how hard: a soft landing is about half)
        static readonly double[] LAND_AT = { 0, 0.1, 0.3, 0.5, 0.7, 1 };
        static readonly Interpolator LandX = Kf(LAND_AT, new[] { 0, 0.26, -0.1, 0.06, -0.02, 0 }), LandY = Kf(LAND_AT, new[] { 0, -0.28, 0.12, -0.05, 0.02, 0 });
        const double LAND_MS = 420;
        // lifted: stretched up tall, then settling
        static readonly double[] PICK_AT = { 0, 0.25, 0.5, 0.75, 1 };
        static readonly Interpolator PickX = Kf(PICK_AT, new[] { 1, 0.8, 1.08, 0.97, 1 }), PickY = Kf(PICK_AT, new[] { 1, 1.26, 0.92, 1.03, 1 });
        const double PICK_MS = 360;
        // the one under a lifted squishy, relieved of its weight: springs up a little (hop in its heights)
        static readonly double[] REL_AT = { 0, 0.2, 0.45, 0.7, 0.85, 1 };
        static readonly Interpolator RelHop = Kf(REL_AT, new[] { 0, 0.04, -0.16, 0, -0.03, 0 }), RelX = Kf(REL_AT, new[] { 1, 1.08, 0.92, 1.04, 0.99, 1 }), RelY = Kf(REL_AT, new[] { 1, 0.9, 1.14, 0.96, 1.01, 1 });
        const double RELIEF_MS = 440;
        // squashed by one landing on it: flat and bulging sideways, then springing back (RipA how hard: less further down)
        static readonly double[] RIP_AT = { 0, 0.14, 0.36, 0.56, 0.76, 1 };
        static readonly Interpolator RipX = Kf(RIP_AT, new[] { 0, 0.34, -0.1, 0.06, -0.02, 0 }), RipY = Kf(RIP_AT, new[] { 0, -0.32, 0.1, -0.05, 0.02, 0 });
        const double RIPPLE_MS = 460, RIPPLE_STEP = 60;
        // too big: the small one flattened like a pancake, held, then springing back
        static readonly double[] PAN_AT = { 0, 0.06, 0.55, 0.7, 0.82, 0.92, 1 };
        static readonly Interpolator PanX = Kf(PAN_AT, new[] { 1, 1.75, 1.66, 0.84, 1.1, 0.97, 1 }), PanY = Kf(PAN_AT, new[] { 1, 0.3, 0.34, 1.22, 0.92, 1.03, 1 });
        const double PANCAKE_MS = 950;
        // "nope": a shake of the head (degrees, from its feet)
        static readonly Interpolator Nope = Kf(new[] { 0, 0.12, 0.3, 0.48, 0.66, 0.84, 1 }, new[] { 0.0, 13, -13, 10, -6, 3, 0 });
        const double NOPE_MS = 560;
        // the win: a squash, a stretch up and a squash again (the wave runs up each tower); the hop is WaveH of its height
        static readonly double[] WAVE_AT = { 0, 0.18, 0.32, 0.55, 0.75, 0.88, 1 };
        static readonly Interpolator WaveHop = Kf(WAVE_AT, new[] { 0, 0, -0.26, -1, 0, -0.1, 0 }), WaveX = Kf(WAVE_AT, new[] { 1, 1.18, 0.86, 0.96, 1.2, 0.97, 1 }), WaveY = Kf(WAVE_AT, new[] { 1, 0.82, 1.18, 1.04, 0.8, 1.03, 1 });
        const double WAVE_MS = 620, WAVE_STEP = 85;
        // the hint: two hops
        static readonly Interpolator HintHop = Kf(new[] { 0, 0.23, 0.5, 0.73, 1 }, new[] { 0, -0.28, 0, -0.28, 0 });
        const double HINT_MS = 760;
        // stuck squishies (Blitz's mistake): drooped (sunk and wide), swaying slowly (a loop)
        const double DROOP_X = 1.07, DROOP_Y = 0.86, SWAY_MS = 2000;
        // lifted and hovering: a gentle dangle from its top (a loop); dragged: a swing from how fast it's moved
        const double HOVER_MS = 1150;
        static readonly Interpolator Swing1 = Fx.Lerp(KeyLoop.PHASE, KeyLoop.SWING);
        // the cushions' bump: one timing whose easing wobbles back to 0
        static readonly Func<double, double> BUMP_EASE = Curve(new[] { (0.0, 0.0), (0.16, 1.0), (0.4, -0.35), (0.6, 0.15), (0.8, -0.05), (1.0, 0.0) });
        static Func<double, double> Curve((double t, double v)[] K) => t =>
        {
            int i = 1;
            while (i < K.Length - 1 && t > K[i].t) i++;
            var (t0, a) = K[i - 1]; var (t1, b) = K[i];
            return a + (b - a) * (t1 > t0 ? Math.Min(1, Math.Max(0, (t - t0) / (t1 - t0))) : 1);
        };
        // eased progress that waits `d` of its time first
        static Func<double, double> After(double d, Func<double, double> ease = null) => t => t <= d ? 0 : (ease ?? (u => u))((t - d) / (1 - d));

        // ---- a squishy's motion values (Game.js pieceAnims) ------------------------------------------------------------
        sealed class PieceAnims
        {
            public AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), O = new AnimatedValue(0), Wx = new AnimatedValue(1), Wy = new AnimatedValue(1),
                Ld = new AnimatedValue(1), LdA = new AnimatedValue(1), Pk = new AnimatedValue(1), Rel = new AnimatedValue(1), Rip = new AnimatedValue(1), RipA = new AnimatedValue(0),
                Pan = new AnimatedValue(1), No = new AnimatedValue(1), Wave = new AnimatedValue(1), WaveH = new AnimatedValue(0.4), Hint = new AnimatedValue(1),
                Droop = new AnimatedValue(0), Sway = new AnimatedValue(0), Hov = new AnimatedValue(0), Swing = new AnimatedValue(0);
            public (double x, double y)? Tgt;
            public (double x, double y) At;
            public double Wgt = -1;
            public int Tok, SwingT = -1;
            public CompositeAnimation HovLoop, SwayLoop;

            static double Dev(Interpolator k, double ph, double amp) => 1 + k.Evaluate(ph) * amp;
            public double Sx => Dev(LandX, Ld.GetValue(), LdA.GetValue()) * PickX.Evaluate(Pk.GetValue()) * RelX.Evaluate(Rel.GetValue()) * Dev(RipX, Rip.GetValue(), RipA.GetValue())
                * PanX.Evaluate(Pan.GetValue()) * WaveX.Evaluate(Wave.GetValue()) * (1 + (DROOP_X - 1) * Droop.GetValue());
            public double Sy => Dev(LandY, Ld.GetValue(), LdA.GetValue()) * PickY.Evaluate(Pk.GetValue()) * RelY.Evaluate(Rel.GetValue()) * Dev(RipY, Rip.GetValue(), RipA.GetValue())
                * PanY.Evaluate(Pan.GetValue()) * WaveY.Evaluate(Wave.GetValue()) * (1 + (DROOP_Y - 1) * Droop.GetValue());
            /// <summary>Of its height.</summary>
            public double Lift => RelHop.Evaluate(Rel.GetValue()) + WaveHop.Evaluate(Wave.GetValue()) * WaveH.GetValue() + HintHop.Evaluate(Hint.GetValue());
            /// <summary>Degrees, from its feet: the nope and the sad sway.</summary>
            public double RotFeet => Nope.Evaluate(No.GetValue()) + Swing1.Evaluate(Sway.GetValue()) * 5;
            /// <summary>Degrees, from its top: the drag's swing and the hover's dangle.</summary>
            public double RotTop => Swing.GetValue() + Swing1.Evaluate(Hov.GetValue()) * 6;
        }

        // ---- TOO BIG!: the red flash and the dizzy stars (Game.js Dizzy: three stars on a tilted ring, one loop, fading
        // out at the end of its 1250 ms; gone at 1300) ------------------------------------------------------------------
        readonly AnimatedValue _flash = new AnimatedValue(0), _dizzyLife = new AnimatedValue(0);
        UiPiece _flashPiece;
        readonly UiPiece[] _dizzyPieces = new UiPiece[3];
        KeyLoop _dizzySpin;
        (float x, float y, float w)? _dizzy;
        int _dizzyKey;
        const string DIZZY_STAR = "M12 2 L14.6 8.6 L21.6 9.2 L16.3 13.8 L18 20.8 L12 17 L6 20.8 L7.7 13.8 L2.4 9.2 L9.4 8.6 Z";

        void ShowDizzy(float x, float y, float w)
        {
            _dizzy = (x, y, w);
            int key = ++_dizzyKey;
            _dizzySpin?.Unmount();
            _dizzySpin = new KeyLoop(760, KeyLoop.PHASE, KeyLoop.PHASE);
            _dizzySpin.Mount();
            _dizzyLife.SetValue(0);
            Animated.Timing(_dizzyLife, Timing(1, 1250, Easing.Linear)).Start();
            float size = Math.Max(12, w * 0.2f);
            var star = new UiSvg(size, size).Raw($"<svg x=\"0\" y=\"0\" width=\"{UiSvg.F(size)}\" height=\"{UiSvg.F(size)}\" viewBox=\"0 0 24 24\"><path d=\"{DIZZY_STAR}\" fill=\"#ffe045\" stroke=\"#b86200\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></svg>").Markup;
            foreach (var d in _dizzyPieces) d.SetSvg(star, size, size, 2);
            Later(1300, () => { if (_dizzyKey != key) return; _dizzy = null; _dizzySpin?.Unmount(); _dizzySpin = null; });
        }

        void DrawTooBig(float ax, float ay)
        {
            double f = _flash.GetValue();
            float fo = (float)Piecewise(f, new[] { 0, 0.18, 1 }, new[] { 0.0, 0.32, 0 });
            _flashPiece.Visible = fo > 0.001f;
            if (_flashPiece.Visible)
            {
                _flashPiece.SetSvg(new UiSvg(_g.W, _g.H).Box(0, 0, _g.W, _g.H, new BoxStyle { Background = "#ff2d55", Radius = 24 }).Markup, _g.W, _g.H);
                _flashPiece.Transform = Affine.Translate(ax, ay);
                _flashPiece.Opacity = fo;
            }
            for (int i = 0; i < 3; i++) _dizzyPieces[i].Visible = _dizzy.HasValue;
            if (!_dizzy.HasValue) return;
            var (x, y, w) = _dizzy.Value;
            float size = Math.Max(12, w * 0.2f);
            double life = _dizzyLife.GetValue(), spin = _dizzySpin?.Value ?? 0;
            float op = (float)Piecewise(life, new[] { 0, 0.08, 0.8, 1 }, new[] { 0.0, 1, 1, 0 });
            for (int i = 0; i < 3; i++)
            {
                double o = i / 3.0;
                var ang = Array.ConvertAll(KeyLoop.PHASE, q => 2 * Math.PI * (q + o));
                double tx = Fx.Lerp(KeyLoop.PHASE, Array.ConvertAll(ang, q => Math.Cos(q) * w * 0.34)).Evaluate(spin);
                double ty = Fx.Lerp(KeyLoop.PHASE, Array.ConvertAll(ang, q => Math.Sin(q) * w * 0.1)).Evaluate(spin);
                double k = Fx.Lerp(KeyLoop.PHASE, Array.ConvertAll(ang, q => 0.75 + 0.3 * Math.Sin(q))).Evaluate(spin);
                var cc = Affine.Translate(size / 2.0, size / 2.0); var cci = Affine.Translate(-size / 2.0, -size / 2.0);
                _dizzyPieces[i].Transform = Affine.Translate(ax + x - size / 2, ay + y - size / 2) * cc * Affine.Translate(tx, ty) * Affine.ScaleBy(k, k) * cci;
                _dizzyPieces[i].Opacity = op;
            }
        }

        // ---- state ----------------------------------------------------------------------------------------------------
        string _phase = "load";
        int[] _pos;
        (int r, int from)? _held;
        int _moves, _top = -1, _dragCol = -1;
        bool _hinted;
        (int from, int to)? _glow;
        readonly List<int> _timers = new List<int>();
        double _clockStart, _clockPaused = -1;
        int _secs;

        void Later(double ms, Action fn) => _timers.Add(_anim.SetTimeout(() => { if (this != null) fn(); }, ms));
        void ClearTimers() { foreach (var t in _timers) _anim.ClearTimeout(t); _timers.Clear(); }

        double RateOf(int r) => 1.25 - 0.45 * r / Math.Max(1, _spec.N - 1);
        float HoverY(int r) => _g.Hover - _g.Bh[r];
        float XOf(int r, int p) => Cx(p) - _g.Bw[r] / 2;

        static SpringConfig Spring(double to, double friction, double tension) => new SpringConfig { ToValue = to, Friction = friction, Tension = tension, UseNativeDriver = true };
        static TimingConfig Timing(double to, double ms, Func<double, double> easing = null) => new TimingConfig { ToValue = to, Duration = ms, Easing = easing, UseNativeDriver = true };

        // Everyone not lifted springs to where they belong, squished by what's on them.
        void Settle()
        {
            if (_g == null) return;
            var m = SpotsOf(_pos, _held?.r ?? -1);
            foreach (var kv in m)
            {
                var A = _anims[kv.Key];
                var s = kv.Value;
                if (A.Wgt != s.Sy)
                {
                    A.Wgt = s.Sy;
                    Animated.Parallel(Animated.Spring(A.Wx, Spring(s.Sx, 5, 140)), Animated.Spring(A.Wy, Spring(s.Sy, 5, 140))).Start();
                }
                if (A.Tgt.HasValue && Math.Abs(A.Tgt.Value.x - s.X) < 0.5 && Math.Abs(A.Tgt.Value.y - s.Y) < 0.5) continue;
                A.Tgt = (s.X, s.Y);
                A.At = (s.X, s.Y);
                A.Tok += 1;
                Animated.Parallel(Animated.Spring(A.X, Spring(s.X, 7, 120)), Animated.Spring(A.Y, Spring(s.Y, 7, 120))).Start();
            }
        }

        struct Step { public double X, Y, Ms; public Func<double, double> Ex, Ey; }

        // One timing taking `v` from `from` through `keys` ((t 0…1, value, easing?), the last at t = 1) in `ms` (Game.js
        // pathTiming: a path with turns is still one animation). Null when there's nowhere to go.
        static CompositeAnimation PathTiming(AnimatedValue v, double from, List<(double t, double v, Func<double, double> e)> keys, double ms)
        {
            var pts = new List<(double t, double v, Func<double, double> e)> { (0, from, null) };
            pts.AddRange(keys);
            double far = from;
            foreach (var q in pts) if (Math.Abs(q.v - from) > Math.Abs(far - from)) far = q.v;
            if (Math.Abs(far - from) < 0.5)
            {
                double end = keys[keys.Count - 1].v;
                return Math.Abs(end - from) < 0.01 ? null : Animated.Timing(v, Timing(end, ms));
            }
            double span = far - from;
            Func<double, double> easing = t =>
            {
                int i = 1;
                while (i < pts.Count - 1 && t > pts[i].t) i++;
                var (t0, a, _) = pts[i - 1];
                var (t1, b, e) = pts[i];
                double u = t1 > t0 ? Math.Min(1, Math.Max(0, (t - t0) / (t1 - t0))) : 1;
                return (a + (b - a) * (e ?? Easing.InOut(Easing.Quad))(u) - from) / span;
            };
            return Animated.Timing(v, Timing(far, ms, easing));
        }

        // steps one after another, as ONE timing per axis; `done` only if nothing else moved it meanwhile
        void Fly(int r, Step[] steps, Action done)
        {
            double total = 0; foreach (var st in steps) total += st.Ms;
            double t = 0;
            var kx = new List<(double, double, Func<double, double>)>();
            var ky = new List<(double, double, Func<double, double>)>();
            foreach (var st in steps) { t += st.Ms; kx.Add((t / total, st.X, st.Ex)); ky.Add((t / total, st.Y, st.Ey)); }
            FlyKeys(r, kx, ky, total, done);
        }
        // the same with each axis's own keys: an arc's x and y turn at different times
        void FlyKeys(int r, List<(double t, double v, Func<double, double> e)> kx, List<(double t, double v, Func<double, double> e)> ky, double ms, Action done)
        {
            var A = _anims[r];
            int tok = ++A.Tok;
            var end = (kx[kx.Count - 1].v, ky[ky.Count - 1].v);
            var from = A.At;
            A.Tgt = end;
            A.At = end;
            var list = new List<CompositeAnimation>();
            var ax = PathTiming(A.X, from.x, kx, ms); if (ax != null) list.Add(ax);
            var ay = PathTiming(A.Y, from.y, ky, ms); if (ay != null) list.Add(ay);
            Animated.Parallel(list).Start(res => { if (res.Finished && A.Tok == tok && done != null) done(); });
        }

        // one go of a phase 0 → 1, after `delay` ms (worked into the timing)
        static void Play(AnimatedValue v, double ms, double delay = 0)
        {
            v.SetValue(0);
            Animated.Timing(v, Timing(1, ms + delay, After(delay / (ms + delay)))).Start();
        }

        // a loop of a phase (the hover dangle, the sad sway), or stopped and back at rest
        static void LoopOf(ref CompositeAnimation loop, AnimatedValue v, double ms, bool on)
        {
            loop?.Stop();
            loop = null;
            if (!on) { Animated.Timing(v, Timing(0, 160)).Start(); return; }
            v.SetValue(0);
            loop = Animated.Loop(Animated.Timing(v, Timing(1, ms, Easing.Linear)), -1);
            loop.Start();
        }

        // lifted: a gentle dangle from its top while it hovers (off: back still, and any swing let go)
        void Hover(int r, bool on)
        {
            var A = _anims[r];
            LoopOf(ref A.HovLoop, A.Hov, HOVER_MS, on);
            if (!on) Animated.Spring(A.Swing, Spring(0, 2.6, 70)).Start();
        }
        // dragged: it swings from its top against the way it's moved, by how fast (let go, it swings back and forth like a
        // pendulum and settles)
        void SwingOf(int r, double vx)
        {
            var A = _anims[r];
            double deg = Math.Max(-30, Math.Min(30, vx * 22));
            Animated.Spring(A.Swing, Spring(deg, 5, 120)).Start();
            if (A.SwingT >= 0) _anim.ClearTimeout(A.SwingT);
            A.SwingT = _anim.SetTimeout(() => Animated.Spring(A.Swing, Spring(0, 2.4, 60)).Start(), 90);
        }

        // a cushion's bump (k: how hard; negative springs it up), one timing whose easing wobbles back to 0
        void Bump(int p, double k = 1)
        {
            var B = _bumps[p];
            B.SetValue(0);
            Animated.Timing(B, Timing(k, 420, BUMP_EASE)).Start();
        }

        void PickUp(int r, int p)
        {
            var A = _anims[r];
            _held = (r, p);
            Snd.Play("st_lift", rate: RateOf(r));
            Snd.Tap();
            _top = r;
            _glow = null;
            if (A.Wgt != 1)
            {
                A.Wgt = 1;
                Animated.Parallel(Animated.Spring(A.Wx, Spring(1, 5, 140)), Animated.Spring(A.Wy, Spring(1, 5, 140))).Start();
            }
            // stretched up tall as it's lifted
            Play(A.Pk, PICK_MS);
            // the one under it springs up, relieved of the weight (or, from the cushion, the cushion does)
            var st = Engine.StackOf(_pos, p);
            int at = Array.IndexOf(st, r);
            if (at > 0) Play(_anims[st[at - 1]].Rel, RELIEF_MS);
            else Bump(p, -0.7);
            A.Tgt = (XOf(r, p), HoverY(r));
            var from = A.At;
            A.At = A.Tgt.Value;
            A.Tok += 1;
            var list = new List<CompositeAnimation>();
            var ax = PathTiming(A.X, from.x, new List<(double, double, Func<double, double>)> { (1, A.Tgt.Value.x, Easing.Out(Easing.Quad)) }, 160); if (ax != null) list.Add(ax);
            var ay = PathTiming(A.Y, from.y, new List<(double, double, Func<double, double>)> { (1, A.Tgt.Value.y, Easing.Out(Easing.Back(1.6))) }, 220); if (ay != null) list.Add(ay);
            Animated.Parallel(list).Start();
            Hover(r, true);
            Settle();   // the stack under it stands up a little
            Hud();
        }

        void Land(int r, bool soft = false)
        {
            if (_held.HasValue && _held.Value.r == r) return;
            Settle();   // the ones under it squish down a little
            var A = _anims[r];
            A.LdA.SetValue(soft ? 0.5 : 1);
            Play(A.Ld, LAND_MS);
            int p = _pos[r];
            var st = Engine.StackOf(_pos, p);
            int below = Array.IndexOf(st, r);
            if (below == 0) { Bump(p, soft ? 0.6 : 1); Snd.Play("st_cushion", rate: RateOf(r)); }
            else Snd.Play("st_land", rate: RateOf(r));
            if (soft) return;
            Snd.Place();
            // the one under it squashes flat and bulges, and the squash runs down the tower, smaller at each level, to the
            // cushion; a puff of dust off the cushion
            for (int j = below - 1, k = 0; j >= 0; j--, k++)
            {
                var U = _anims[st[j]];
                U.RipA.SetValue(0.95 * Math.Pow(0.62, k));
                Play(U.Rip, RIPPLE_MS, k * RIPPLE_STEP);
            }
            if (below > 0) Later(below * RIPPLE_STEP, () => Bump(p, Math.Max(0.35, 0.8 * Math.Pow(0.62, below))));
            Later(below * RIPPLE_STEP, () => Spray("puff", Cx(p), _g.Surface - _g.CushH * 0.1, Math.Max(0.8, _g.CushW / 110)));
            if (_phase == "play" && Engine.Same(_pos, _puzzle.Goal)) Win();
        }

        // the lifted one let go over cushion p
        void Drop(int p, bool dragged = false)
        {
            if (!_held.HasValue) return;
            var (r, from) = _held.Value;
            Hover(r, false);
            _dragCol = -1;
            _held = null;
            if (p == from || p < 0)
            {
                var s0 = SpotsOf(_pos)[r];
                Fly(r, new[] { new Step { X = s0.X, Y = s0.Y, Ms = 170, Ey = GRAVITY } }, () => Land(r, true));
                Hud();
                return;
            }
            if (Engine.CanMove(_pos, from, p) < 0) { BounceOff(r, from, p, dragged); Hud(); return; }
            var next = (int[])_pos.Clone();
            next[r] = p;
            _pos = next;
            _moves += 1;
            var s = SpotsOf(_pos)[r];
            float dx = Math.Abs(Cx(p) - Cx(from));
            if (dragged) Fly(r, new[] { new Step { X = s.X, Y = s.Y, Ms = 200, Ex = Easing.Out(Easing.Quad), Ey = GRAVITY } }, () => Land(r));
            else Fly(r, new[] { new Step { X = s.X, Y = HoverY(r), Ms = 110 + dx * 0.45 }, new Step { X = s.X, Y = s.Y, Ms = 170, Ey = GRAVITY } }, () => Land(r));
            Hud();
        }

        // Too big for cushion p: it lands on the small one's head and flattens it like a pancake (dizzy stars, a quick red
        // flash), boings off, shakes its head "nope" and arcs back home. No move counted.
        void BounceOff(int r, int from, int p, bool dragged = false)
        {
            int t = Engine.TopOf(_pos, p);
            var ts = SpotsOf(_pos)[t];
            float sit = ts.Y + _g.Bh[t] * 0.66f - _g.Bh[r];   // on the flattened one (PANCAKE leaves it a third as tall)
            float dx = Math.Abs(Cx(p) - Cx(from));
            _top = r;
            // (let go from a drag: straight down from where it was dropped; from a tap: over from its hover, then down)
            var there = dragged
                ? new[] { new Step { X = XOf(r, p), Y = sit, Ms = 190, Ex = Easing.Out(Easing.Quad), Ey = GRAVITY } }
                : new[] { new Step { X = XOf(r, p), Y = HoverY(r), Ms = 110 + dx * 0.45 }, new Step { X = XOf(r, p), Y = sit, Ms = 140, Ey = GRAVITY } };
            Fly(r, there, () =>
            {
                var T = _anims[t];
                var A = _anims[r];
                Play(T.Pan, PANCAKE_MS);
                ShowDizzy(Cx(p), ts.Y + _g.Bh[t] * 0.62f, _g.Bw[t]);
                _flash.SetValue(0);
                Animated.Timing(_flash, Timing(1, 340, Easing.Linear)).Start();
                Snd.Play("st_ouch");
                Snd.Wrong();
                Spray("angry", Cx(p), ts.Y + _g.Bh[t] * 0.6, 1);
                Say("TOO BIG!", small: true, ink: "#8e1030", hold: 380, sub: _spec.Lv <= 3 ? "Big ones never sit on smaller ones" : null);
                if (_blitz) BlitzMistake();
                // the big one: squashed on landing, then boing, up and away in an arc, shaking its head, and home
                A.LdA.SetValue(1);
                Play(A.Ld, LAND_MS);
                int tok = A.Tok;
                Later(200, () =>
                {
                    if (A.Tok != tok || (_held.HasValue && _held.Value.r == r)) return;
                    Snd.Play("st_bounce");
                    Play(A.Pk, PICK_MS);
                    Play(A.No, NOPE_MS, 60);
                    var home = SpotsOf(_pos)[r];
                    // (not so high that it leaves the play area for the counter over it)
                    double peak = Math.Max(-_g.Bh[r] * 0.05, Math.Min(sit, HoverY(r)) - _g.Bh[r] * 0.22);
                    double ms = 520 + dx * 0.4;
                    FlyKeys(r, new List<(double, double, Func<double, double>)> { (0.15, XOf(r, p), null), (1, home.X, Easing.InOut(Easing.Sin)) },
                        new List<(double, double, Func<double, double>)> { (0.45, peak, Easing.Out(Easing.Quad)), (1, home.Y, GRAVITY) }, ms, () => Land(r, true));
                });
            });
        }

        // everyone back where this puzzle started (the clock keeps going)
        void Restart()
        {
            if (_phase != "play" || _paused) return;
            if (_held.HasValue) { Hover(_held.Value.r, false); _held = null; }
            _pos = (int[])_puzzle.Start.Clone();
            _moves = 0;
            _glow = null;
            Snd.Play("st_undo", rate: 0.8);
            Settle();
            Hud();
        }

        // ---- the cards over the game ----------------------------------------------------------------------------------
        Card _result, _fail, _pause, _hintAsk;
        readonly List<(Card card, int rank)> _cards = new List<(Card, int)>();   // on screen (closing ones too), bottom first
        CardPieces _cardPieces;
        bool _paused;
        const int RESULT = 0, FAIL = 1, PAUSE = 2, HINT = 3;   // Game.js's order: a later one shows over an earlier one

        Card Open(Card c, int rank)
        {
            int at = _cards.Count;
            while (at > 0 && _cards[at - 1].rank > rank) at--;
            _cards.Insert(at, (c, rank));
            c.Show();
            return c;
        }

        IEnumerable<Card> Cards { get { foreach (var c in _cards) yield return c.card; } }

        static void Close(ref Card c, bool emptied = false) { c?.Hide(emptied); c = null; }

        bool CardOpen { get { foreach (var c in _cards) if (c.card.Visible) return true; return false; } }

        // the first hint of a level asks first (Game.js askHint / watchHint); after that, straight away
        void AskHint()
        {
            if (_phase != "play" || _paused) return;
            if (_hinted || !AskBeforeHint) WatchHint();
            else if (_hintAsk == null) _hintAsk = Open(StackCards.HintCard(W, H, AdReady, AdsFree, WatchHint, () => Close(ref _hintAsk)), HINT);
        }

        void WatchHint()
        {
            Close(ref _hintAsk);
            // (without Remove Ads, a rewarded ad first; the hint once its reward is earned)
            if (AdsFree) ShowHint();
            else AdHook.Show(ShowHint);
        }

        void ShowHint()
        {
            if (_phase != "play") return;
            if (_held.HasValue) Drop(_held.Value.from);
            var m = Engine.BestMove(_puzzle.Sol, _pos);
            if (m == null) return;
            int r = m[0], from = m[1], to = m[2];
            _hinted = true;
            Snd.Play("st_hint");
            Spray("spark", Cx(to), _g.Surface - 4, 1);
            _glow = (from, to);
            Play(_anims[r].Hint, HINT_MS);
            Later(2800, () => { if (_glow.HasValue && _glow.Value.from == from && _glow.Value.to == to) { _glow = null; Hud(); } });
            Hud();
        }

        void Win()
        {
            _phase = "won";
            PauseClock();
            _glow = null;
            Snd.Play("sd_solve");
            Snd.Win();
            // (Blitz keeps its confetti for the end of the run)
            if (!_blitz)
            {
                Later(250, () => { Snd.Play("sd_confetti"); Spray("confetti", _g.W / 2, _g.H * 0.35, 1.2); });
                Later(650, () => Spray("confetti", _g.W * 0.25, _g.H * 0.5, 1));
                Later(800, () => Spray("confetti", _g.W * 0.75, _g.H * 0.5, 1));
            }
            // a bounce wave up each tower, bottom to top, a sparkle off each one as it jumps (over before the result card)
            var ws = SpotsOf(_pos);
            for (int p = 0; p < _spec.K; p++)
            {
                var st = Engine.StackOf(_pos, p);
                for (int j = 0; j < st.Length; j++)
                {
                    int r = st[j], pp = p;
                    double d = 120 + j * WAVE_STEP + p * 45;
                    _anims[r].WaveH.SetValue(j == st.Length - 1 ? 0.42 : 0.1);
                    Play(_anims[r].Wave, WAVE_MS, d);
                    Later(d + WAVE_MS * 0.45, () => Spray("spark", Cx(pp), ws[r].Y + _g.Bh[r] * 0.1, Math.Max(0.7, _g.Bw[r] / 90)));
                }
            }
            // Blitz: one more cleared; on to the next puzzle
            if (_blitz) { BlitzCleared(); Hud(); return; }
            var outc = Levels.AfterLevel(Profile, _spec, _puzzle.Par, true, _moves, _hinted);
            StackSave.Paid(outc, Profile);   // (signed in: saveStack)
            Apply(outc.Update);
            var res = new StackCards.Result
            {
                Stars = outc.Stars, Coins = outc.Coins, Xp = outc.Xp, LevelUps = outc.LevelUps?.Count ?? 0, Unlocked = outc.Unlocked,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
                Moves = _moves, Par = _puzzle.Par, Hinted = _hinted,
            };
            int lv = _spec.Lv, tier = _spec.Tier;
            Later(1500, () => _result = Open(StackCards.ResultCard(W, H, res, _lv >= Levels.LEVELS, Next, Replay, Leave, Trio()), RESULT));
            Hud();
        }

        // the result's NEXT and REPLAY, the fail's RETRY, the pause's NEW PUZZLE: a new round
        void Next()
        {
            _lv = Math.Min(Levels.LEVELS, _lv + 1);
            Menu.MenuState.StackLevel = _lv;
            Replay();
        }

        void Replay()
        {
            _round++;
            NewPuzzle();
        }

        // ---- pause (the back orb, Android's back) ----------------------------------------------------------------------
        void Pause()
        {
            if (_phase != "play" || _paused) return;
            if (_held.HasValue) Drop(_held.Value.from);
            PauseClock();
            _paused = true;
            _pause = Open(StackCards.PauseCard(W, H, Resume, Leave), PAUSE);
            Hud();
        }

        void Resume()
        {
            if (!_paused) return;
            _paused = false;
            Close(ref _pause);
            Hud();
        }

        // BackHandler: the hint card closes, a pause resumes, play pauses, anything else leaves
        void Back()
        {
            if (_hintAsk != null) Close(ref _hintAsk);
            else if (_paused) Resume();
            else if (_phase == "play") Pause();
            else if (_blitz && _blitzCard == "save") EndRun();
            else if (_blitz && _phase == "held") return;
            else Leave();
        }

        // the profile update as Firestore takes it: dotted field paths ("stack.best.12") into nested maps
        static void Apply(Dictionary<string, object> update)
        {
            foreach (var kv in update)
            {
                var parts = kv.Key.Split('.');
                IDictionary<string, object> m = Profile;
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (!(m.TryGetValue(parts[i], out var next) && next is IDictionary<string, object> nm)) { nm = new Dictionary<string, object>(); m[parts[i]] = nm; }
                    m = nm;
                }
                m[parts[parts.Length - 1]] = kv.Value;
            }
        }

        void Lose()
        {
            if (_phase != "play") return;
            if (_blitz) return;
            _phase = "lost";
            PauseClock();
            _glow = null;
            Snd.Play("sd_timeUp");
            Snd.Wrong();
            if (_held.HasValue) Drop(_held.Value.from);
            var outc = Levels.AfterLevel(Profile, _spec, _puzzle.Par, false, 0, false);
            StackSave.Record(outc.Update);
            Apply(outc.Update);
            var picture = _who.Length > 0 ? _who[0].Picture : null;
            Later(1300, () => _fail = Open(StackCards.FailCard(W, H, picture, Replay, Leave), FAIL));
            Hud();
        }

        // ---- the round ------------------------------------------------------------------------------------------------
        void StartPlay()
        {
            _phase = "play";
            if (_blitz) _runStarted = true;
            Hud();
        }

        void PauseClock() { if (_clockPaused < 0) _clockPaused = _anim.Now; }
        double Elapsed => (_clockPaused >= 0 ? _clockPaused : _anim.Now) - _clockStart;

        void Deal()
        {
            _phase = "deal";
            var m = SpotsOf(_puzzle.Start);
            double last = 0;
            for (int p = 0; p < _spec.K; p++)
            {
                var st = Engine.StackOf(_puzzle.Start, p);
                for (int j = 0; j < st.Length; j++)
                {
                    int r = st[j];
                    double d = p * 110 + j * 130;
                    last = Math.Max(last, d);
                    Later(d, () =>
                    {
                        Animated.Timing(_anims[r].O, Timing(1, 120)).Start();
                        Fly(r, new[] { new Step { X = m[r].X, Y = m[r].Y, Ms = 380, Ey = GRAVITY } }, () => Land(r, true));
                    });
                }
            }
            Later(last + 560, () =>
            {
                var rec = Levels.Record(Profile);
                bool seen = rec.Best != null && rec.Best.ContainsKey(_spec.Lv.ToString());
                var news = _spec.News != null && !seen ? NEWS(_spec.News) : (null, null);
                if (news.Item1 == null) { StartPlay(); return; }
                Snd.Play("st_news");
                Say(news.Item1, small: true, sub: news.Item2, hold: 1300, ink: "#0c5a9c");
                Later(1750, StartPlay);
            });
        }

        static (string, string) NEWS(string k) => k switch
        {
            "picture" => ("GOAL CARD!", "Make the cushions look like the picture"),
            "clock" => ("BEAT THE CLOCK!", "From now on, every level has a timer"),
            "cushion" => ("A 4TH CUSHION!", "Big towers move much faster now"),
            _ => (null, null),
        };

        void NewPuzzle()
        {
            ClearTimers();
            Sad(false, true);   // (the last puzzle's squishies stop swaying)
            // the cards close (a result card empties at once: its `res` is gone); Blitz's are the run's
            Close(ref _result, true);
            Close(ref _fail);
            Close(ref _pause);
            Close(ref _hintAsk);
            _paused = false;
            var rec = Levels.Record(Profile);
            _spec = _blitz ? Levels.BlitzSpec(_idx, rec.BSkill) : Levels.LevelSpec(_lv, rec.Skill);
            _puzzle = PuzzleSource != null ? PuzzleSource(_spec) : Engine.MakePuzzle(_spec);
            _who = CastSource != null ? CastSource(_spec.N) : PickCast(_spec.N);
            _limit = 0;   // (no clock any more: the user, 2026-11-16, levels.js)
            _g = Geom(W - 2 * SideW, H - _areaY, _spec.N, _spec.K, _who);
            BuildBoard();
            _held = null; _top = -1; _dragCol = -1; _glow = null;
            _pos = (int[])_puzzle.Start.Clone();
            _moves = 0; _hinted = false;
            _secs = (int)Math.Ceiling(_limit / 1000.0);
            _clockStart = _anim.Now; _clockPaused = _anim.Now;
            // everyone above their spot, waiting to drop in
            var m = SpotsOf(_puzzle.Start);
            for (int r = 0; r < _anims.Length; r++)
            {
                var A = _anims[r];
                A.Tok += 1;
                A.HovLoop?.Stop(); A.HovLoop = null; A.SwayLoop?.Stop(); A.SwayLoop = null;
                foreach (var v in new[] { A.Ld, A.Pk, A.Rel, A.Rip, A.Pan, A.No, A.Wave, A.Hint }) { v.StopAnimation(); v.SetValue(1); }
                foreach (var v in new[] { A.Droop, A.Sway, A.Hov, A.Swing, A.O }) { v.StopAnimation(); v.SetValue(0); }
                A.Wx.SetValue(m[r].Sx); A.Wy.SetValue(m[r].Sy); A.Wgt = m[r].Sy;
                A.X.SetValue(m[r].X); A.Y.SetValue(m[r].Y - _g.H * 0.6);
                A.Tgt = (m[r].X, m[r].Y);
                A.At = (m[r].X, m[r].Y - _g.H * 0.6);
            }
            _phase = "intro";
            if (_blitz && BlitzIntro()) { Hud(); return; }
            var chips = new List<string> { Levels.TIER_NAMES[_spec.Tier] };
            if (_spec.Goal == "picture") chips.Add("GOAL CARD");
            if (_spec.K == 4) chips.Add("4 CUSHIONS");
            Say(_blitz ? "PUZZLE " + _spec.Round : "LEVEL " + _spec.Lv, chips: chips.ToArray(), hold: 900);
            Snd.Play("sd_boardIn");
            Hud();
            // (the app waits for any picture still downloading; Unity's are all here)
            Later(1250, Deal);
        }

        // the result card's three: from the level's stack (Game.js trio)
        string[] Trio()
        {
            var want = new List<string>();
            for (int i = 0; i < 3; i++) want.Add(i < _who.Length ? _who[i]?.Key : null);
            return GameCards.TrioOf(want, CastKeys());
        }

        // the squishies Stack may use (src/stack/roster.js castOf): out (config/roster), never the Masked or Elemental
        // Heroes, no season-pass creature (all of them, should that leave too few for a level). InGames: set by
        // Screens/RosterConfig in Unity; null (tools/unity's tests): every one
        public static Func<string, bool> InGames;
        List<string> CastKeys(int atLeast = 3)
        {
            var keys = new List<string>();
            foreach (var k in _layout.art.Keys) if (InGames == null || InGames(k)) keys.Add(k);
            return keys.Count >= atLeast ? keys : new List<string>(_layout.art.Keys);
        }

        // `n` different squishies, in a random order (roster.js pickCast; the player's own first once the profile is real)
        Squishy[] PickCast(int n)
        {
            var keys = CastKeys(n);
            var rand = new System.Random();
            for (int i = keys.Count - 1; i > 0; i--) { int j = rand.Next(i + 1); (keys[i], keys[j]) = (keys[j], keys[i]); }
            var who = new Squishy[n];
            for (int i = 0; i < n; i++) who[i] = _layout.art[keys[i]];
            return who;
        }

        void BuildBoard()
        {
            float ax = AreaX, ay = _areaY;
            // pieces from the last puzzle
            if (_pieces != null) foreach (var p in _pieces) Destroy(p.gameObject);
            if (_seats != null) { foreach (var p in _seats) Destroy(p.gameObject); foreach (var p in _halos) Destroy(p.gameObject); foreach (var p in _badges) Destroy(p.gameObject); }
            _anims = new PieceAnims[_spec.N];
            _pieces = new UiPiece[_spec.N];
            for (int r = 0; r < _spec.N; r++)
            {
                _anims[r] = new PieceAnims();
                var pc = Piece("squishy " + _who[r].Key, 40);
                var tex = Resources.Load<Texture2D>(_who[r].Picture);
                pc.SetPicture(tex, _g.Bw[r], _g.Bh[r]);
                _pieces[r] = pc;
            }
            // the rug under the cushions: area bottom, cushH x 1.9 tall, fully rounded
            float rugH = _g.CushH * 1.9f;
            // (no dashed outline: the user, 2026-11-16)
            _rug.SetSvg(new UiSvg(_g.W, rugH).Box(0, 0, _g.W, rugH, new BoxStyle { Background = "rgba(255,255,255,0.16)", Radius = _g.W }).Markup, _g.W, rugH);
            _rug.Transform = Affine.Translate(ax, ay + _g.H - rugH);
            _colGlow.SetSvg(new UiSvg(_g.ColW - 8, _g.H).Box(0, 0, _g.ColW - 8, _g.H, new BoxStyle { Background = "rgba(255,255,255,0.16)", Radius = 26 }).Markup, _g.ColW - 8, _g.H);
            _seats = new UiPiece[_spec.K]; _halos = new UiPiece[_spec.K]; _badges = new UiPiece[_spec.K];
            for (int p = 0; p < _spec.K; p++)
            {
                float w = _g.CushW, h = _g.CushH;
                _halos[p] = Piece("halo " + p, 32);
                _seats[p] = Piece("cushion " + p, 33);
                _seats[p].SetSvg(StackArt.Cushion(w, h, p), w, h + 5);
                _badges[p] = Piece("star " + p, 34);
                _badges[p].SetSvg(StackArt.StarBadge(28), 28, 28);
            }
        }

        // ---- the banner (sort/Game.js Banner) -------------------------------------------------------------------------
        AnimatedValue _bannerT = new AnimatedValue(0);
        CompositeAnimation _bannerAnim;
        float _bannerW, _bannerH;

        void Say(string text, bool small = false, string ink = "#5b3418", double hold = 700, string sub = null, string[] chips = null)
        {
            var big = new TextStyle { Font = "Fredoka_700Bold", Size = small ? 30 : 40, Color = "#ffffff", Shadows = Outline3(ink, 3) };
            float lineH = UiSvg.LineBox(big);
            float w = _g != null ? _g.W : W - 2 * SideW;
            float y = 0;
            var s = new UiSvg(w, 200);
            s.Text(text, 0, y, big, w, 0.5f);
            y += lineH;
            if (chips != null && chips.Length > 0)
            {
                var ct = new TextStyle { Font = "Fredoka_700Bold", Size = 12, LetterSpacing = 0.6f, Color = "#ffffff" };
                y += 8;
                float total = -6, ch = UiSvg.LineBox(ct) + 6 + 4;
                foreach (var c in chips) total += UiSvg.Width(c, ct) + 18 + 4 + 6;
                float cx = (w - total) / 2;
                foreach (var c in chips)
                {
                    float cw = UiSvg.Width(c, ct) + 18 + 4;
                    s.Box(cx, y, cw, ch, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                    s.Text(c, cx + 2 + 9, y + 2 + 3, ct);
                    cx += cw + 6;
                }
                y += ch;
            }
            if (sub != null)
            {
                var st = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#ffffff" };
                y += 6;
                float sw = UiSvg.Width(sub, st) + 24, sh = UiSvg.LineBox(st) + 8;
                s.Box((w - sw) / 2, y, sw, sh, new BoxStyle { Background = "rgba(69,16,122,0.8)", Radius = 999 });
                s.Text(sub, (w - sw) / 2 + 12, y + 4, st);
                y += sh;
            }
            _bannerW = w; _bannerH = y;
            _bannerPiece.SetSvg(s.Markup.Replace("height=\"200\"", $"height=\"{UiSvg.F(y)}\"").Replace("viewBox=\"0 0 " + UiSvg.F(w) + " 200\"", $"viewBox=\"0 0 {UiSvg.F(w)} {UiSvg.F(y)}\""), w, y, 12);
            _bannerT.SetValue(0);
            _bannerAnim?.Stop();
            _bannerAnim = Animated.Sequence(
                Animated.Spring(_bannerT, Spring(1, 5, 140)),
                Animated.Timing(_bannerT, Timing(1, hold)),
                Animated.Timing(_bannerT, Timing(2, 220, Easing.In(Easing.Quad))));
            _bannerAnim.Start();
        }

        static Shadow[] Outline3(string color, float down) => new[] { new Shadow(color, 0, down, 0), new Shadow(color, 1, 0, 0), new Shadow(color, -1, 0, 0) };

        // ---- the HUD: the counter at the top in the middle, the goal bottom left, the buttons ------------------------------
        string _counterKey;
        object _goalFor;

        void Hud()
        {
            if (_g == null || _puzzle == null) return;
            var d = _blitz ? BlitzCounter() : new StackArt.Counter { Moves = _moves, Par = _puzzle.Par, Tier = _spec.Tier };
            var key = $"{d.Blitz}|{d.Moves}|{d.Par}|{d.Tier}|{d.Cleared}|{d.Best}|{d.Beat}";
            if (key != _counterKey)
            {
                _counterKey = key;
                var (cw, ch) = StackArt.CounterSize(d);
                _counter.SetSvg(StackArt.CounterSvg(d), cw, ch, 2);
                // centred over the cushions, 6 dp down (counterRow)
                _counter.Transform = Affine.Translate(AreaX + ((W - 2 * SideW) - cw) / 2, 6);
            }
            if (!ReferenceEquals(_goalFor, _puzzle))
            {
                _goalFor = _puzzle;
                var (svg, gh) = StackArt.Goal(_who, _puzzle.Goal, _spec.K, _puzzle.Star);
                _goal.SetSvg(svg, 118, gh, 4);
                // the side column's bottom: 10 dp padding (the goal sits at the bottom of the left column)
                _goal.Transform = Affine.Translate(12, H - 10 - gh);
            }
            bool playing = _phase == "play" && !_paused;
            _btns[0].SetOn(playing && _moves > 0);
            if (!_blitz) _btns[1].SetOn(playing && !(_hinted && !AdsFree && !AdReady));
        }

        // ---- every frame ----------------------------------------------------------------------------------------------
        readonly KeyLoop[] _haloLoop = { new KeyLoop(960, KeyLoop.PHASE, KeyLoop.UP_DOWN), new KeyLoop(960, KeyLoop.PHASE, KeyLoop.UP_DOWN), new KeyLoop(960, KeyLoop.PHASE, KeyLoop.UP_DOWN), new KeyLoop(960, KeyLoop.PHASE, KeyLoop.UP_DOWN) };
        readonly bool[] _haloOn = new bool[4];

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the game with it).</summary>
        public void Advance(double nowMs)
        {
            TickAll(nowMs);
            Draw();
            foreach (var p in GetComponentsInChildren<UiPiece>(true)) p.Apply();
        }

        /// <summary>Plays a move as a tap on cushion `from` then on cushion `to` would (CI screenshots).</summary>
        public void TapMove(int from, int to)
        {
            if (_phase != "play") return;
            int r = Engine.TopOf(_pos, from);
            if (r < 0) return;
            PickUp(r, from);
            Drop(to);
        }

        /// <summary>Opens a card as the game would, with src/web/Preview.js's sample data for the result (CI screenshots):
        /// "result", "fail", "pause" (while playing) or "hint".</summary>
        public void ShowCard(string which)
        {
            switch (which)
            {
                case "pause": Pause(); break;
                case "hint": AskHint(); break;
                case "fail":
                    _phase = "lost";
                    PauseClock();
                    _fail = Open(StackCards.FailCard(W, H, _who.Length > 0 ? _who[0].Picture : null, Replay, Leave), FAIL);
                    break;
                case "result":
                    _phase = "won";
                    PauseClock();
                    var res = new StackCards.Result
                    {
                        Stars = 2, Coins = 90, Xp = 40, Moves = 9, Par = 7, LevelUps = 1, Unlocked = true,
                        Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800),
                    };
                    _result = Open(StackCards.ResultCard(W, H, res, false, Next, Replay, Leave, Trio()), RESULT);
                    break;
            }
            Hud();
        }

        void Update()
        {
            if (!_started) return;
            TickAll(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            if (_spec != null && !_blitz && _limit > 0 && _phase == "play" && !_paused)
            {
                double ms = _limit - Elapsed;
                int s = Math.Max(0, (int)Math.Ceiling(ms / 1000));
                if (s != _secs) { _secs = s; Hud(); if (s > 0 && s <= 5) { Snd.Play("sd_tick", rate: 1.3); Snd.Tick(); } }
                if (ms <= 0) Lose();
            }
            Draw();
        }

        // ---- the effects (squishdoku/fx.js FxLayer over the board: dust, sparks, angry puffs, confetti) -------------------
        readonly List<Burst> _fx = new List<Burst>();
        readonly List<UiPiece> _fxPool = new List<UiPiece>();
        void Spray(string kind, double x, double y, double scale = 1)
        {
            var b = new Burst(kind, x, y, scale);
            _fx.Add(b);
            b.Start();
        }
        void DrawFx(float ax)
        {
            _fx.RemoveAll(b => b.Done);
            int n = 0;
            var at = Affine.Translate(ax, _areaY);
            foreach (var b in _fx)
            {
                b.Place(at, 1);
                foreach (var c in b.Layers)
                {
                    if (n == _fxPool.Count) _fxPool.Add(Piece("fx " + n, 190));   // (over the squishies, under the banner)
                    var p = _fxPool[n++];
                    p.Visible = c.Visible;
                    p.SetSvg(c.Markup, c.W, c.H, c.Margin);
                    p.Transform = c.Transform;
                    p.Opacity = c.Opacity;
                }
            }
            for (int i = n; i < _fxPool.Count; i++) _fxPool[i].Visible = false;
        }

        void Draw()
        {
            if (_g == null) return;
            float ax = AreaX, ay = _areaY;
            DrawFx(ax);
            // the squishies (Game.js Piece): placed (x, y), squished by the ones on them from their feet, their own squash /
            // hop / wiggle on top; each view's transform about its centre
            var zOf = new Dictionary<int, int>();
            for (int p = 0; p < _spec.K; p++) { var st = Engine.StackOf(_pos, p); for (int j = 0; j < st.Length; j++) zOf[st[j]] = 10 + j; }
            for (int r = 0; r < _spec.N; r++)
            {
                var A = _anims[r];
                float w = _g.Bw[r], h = _g.Bh[r];
                // Game.js Piece: squished by the ones on it (wx, wy, from its feet), its own squash, stretch, hops and sways
                // (from its feet), and dangling from its top while it's lifted
                double wy = A.Wy.GetValue(), wx = A.Wx.GetValue();
                double wT = Lerp3(wy, 0, 1, h / 2.0, 0);
                var c = Affine.Translate(w / 2.0, h / 2.0); var ci = Affine.Translate(-w / 2.0, -h / 2.0);
                var m = Affine.Translate(ax + A.X.GetValue(), ay + A.Y.GetValue())
                        * c * Affine.Translate(0, wT) * Affine.ScaleBy(wx, wy) * ci
                        * c * Affine.Translate(0, h / 2.0) * Affine.Translate(0, A.Lift * h) * Affine.Rotate(A.RotFeet) * Affine.ScaleBy(A.Sx, A.Sy) * Affine.Translate(0, -h / 2.0) * ci
                        * c * Affine.Translate(0, -h / 2.0) * Affine.Rotate(A.RotTop) * Affine.Translate(0, h / 2.0) * ci;
                _pieces[r].Transform = m;
                _pieces[r].Opacity = (float)A.O.GetValue();
                _pieces[r].Order = 40 + (r == _top ? 99 : zOf.TryGetValue(r, out var z) ? z : 10);
            }
            // the cushions bump when something lands; the hint's and the first level's glow pulses (each cushion's own loop,
            // from when its glow comes on: idleLoop.js usePingPong(960, { on }))
            int nudge = _spec.Lv == 1 && _moves == 0 && _phase == "play" ? (_held.HasValue ? _puzzle.Star : 0) : -1;
            for (int p = 0; p < _spec.K; p++)
            {
                float w = _g.CushW, h = _g.CushH, x = ax + Cx(p) - w / 2, top = ay + _g.Surface - h * 0.4f;
                double b = _bumps[p].GetValue();
                double ty = Piecewise(b, new[] { -1.0, 0, 1 }, new[] { -h * 0.04, 0, h * 0.09 });
                double bsx = Piecewise(b, new[] { -1.0, 0, 1 }, new[] { 0.97, 1, 1.07 }), bsy = Piecewise(b, new[] { -1.0, 0, 1 }, new[] { 1.06, 1, 0.8 });
                var c = Affine.Translate(w / 2.0, (h + 5) / 2.0); var ci = Affine.Translate(-w / 2.0, -(h + 5) / 2.0);
                _seats[p].Transform = Affine.Translate(x, top) * c * Affine.Translate(0, ty) * Affine.ScaleBy(bsx, bsy) * ci;
                _badges[p].Visible = _puzzle.Star == p;
                _badges[p].Transform = Affine.Translate(x + w / 2 - 14, top + h - 9);
                string glow = _glow.HasValue ? (p == _glow.Value.to ? "gold" : p == _glow.Value.from ? "white" : null) : p == nudge ? "white" : null;
                if ((glow != null) != _haloOn[p]) { _haloOn[p] = glow != null; if (_haloOn[p]) _haloLoop[p].Mount(); else _haloLoop[p].Unmount(); }
                double pulse = _haloLoop[p].Value;
                _halos[p].Visible = glow != null;
                if (glow != null)
                {
                    _halos[p].SetSvg(new UiSvg(w + 20, h + 20).Box(0, 0, w + 20, h + 20, new BoxStyle { Background = glow == "gold" ? "rgba(255,224,69,0.85)" : "rgba(255,255,255,0.8)", Radius = h }).Markup, w + 20, h + 20);
                    float hw = w + 20, hh = h + 20;
                    double k = 0.94 + 0.14 * pulse;
                    var hc = Affine.Translate(hw / 2.0, hh / 2.0); var hci = Affine.Translate(-hw / 2.0, -hh / 2.0);
                    _halos[p].Transform = Affine.Translate(x - 10, top - 9) * hc * Affine.ScaleBy(k, k) * hci;
                    _halos[p].Opacity = (float)(0.3 + 0.65 * pulse);
                }
            }
            for (int p = _spec.K; p < 4; p++) if (_haloOn[p]) { _haloOn[p] = false; _haloLoop[p].Unmount(); }
            DrawTooBig(ax, ay);
            _colGlow.Visible = _dragCol >= 0;
            if (_dragCol >= 0) _colGlow.Transform = Affine.Translate(ax + _g.ColW * _dragCol + 4, ay);
            // the banner: over the area's top, scaled and turned about its centre
            double t = _bannerT.GetValue();
            _bannerPiece.Opacity = (float)Piecewise(t, new[] { 0.0, 0.2, 1, 2 }, new[] { 0.0, 1, 1, 0 });
            double bs = Piecewise(t, new[] { 0.0, 1, 2 }, new[] { 0.3, 1, 1.25 }), br = Piecewise(t, new[] { 0.0, 1, 2 }, new[] { -12.0, -3, 0 });
            var bc = Affine.Translate(_bannerW / 2.0, _bannerH / 2.0); var bci = Affine.Translate(-_bannerW / 2.0, -_bannerH / 2.0);
            _bannerPiece.Transform = Affine.Translate(ax, ay + 4) * bc * Affine.ScaleBy(bs, bs) * Affine.Rotate(br) * bci;
            _back.Transform = Affine.Translate(_layout.back[0], _layout.back[1]) * Fx.Pressed(40, 40, _backDown ? 1 : 0);   // (held: it shrinks to 0.92)
            foreach (var b in _btns) b.Draw();
            if (_blitz) BlitzDraw();
            // the cards: placed, and gone once closed
            _cardPieces.Sync(AllCards());
            _cards.RemoveAll(c => !c.card.Shown);
        }

        static double Lerp3(double v, double i0, double i1, double o0, double o1) => o0 + (v - i0) / (i1 - i0) * (o1 - o0);

        // Animated's interpolate with "extend" at both ends
        static double Piecewise(double v, double[] input, double[] output)
        {
            int i = 1;
            while (i < input.Length - 1 && v > input[i]) i++;
            return Lerp3(v, input[i - 1], input[i], output[i - 1], output[i]);
        }

        // ---- touch: tap a cushion to lift its top one, tap another to put it there; or drag it ------------------------
        sealed class Touch { public float X0, Y0; public bool Moved, Picked, Dead; public int Col = -1; public double Lt = -1, Lx; }
        Touch _touch;
        Btn _pressed;
        bool _backDown, _cardDown;

        void HandleInput()
        {
            bool down, held, up;
            Vector2 px;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                px = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up;
            }
            else { px = Input.mousePosition; down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0); held = Input.GetMouseButton(0); }
            float x = px.x / UiPiece.PxPerDp, y = (Screen.height - px.y) / UiPiece.PxPerDp;
            if (Input.GetKeyDown(KeyCode.Escape)) { Back(); return; }

            // an open card takes every tap (its buttons); one closing lets them through
            if (_cardDown)
            {
                if (up) { _cardDown = false; CardsUp(x, y); }
                return;
            }
            if (down && AnyCardOpen)
            {
                CardsDown(x, y);
                _cardDown = true;
                _touch = null;
                return;
            }
            if (AnyCardOpen) return;

            // the back orb and the buttons
            if (down)
            {
                var b = _layout.back;
                if (x >= b[0] - 6 && x <= b[0] + 46 && y >= b[1] - 6 && y <= b[1] + 46) { _backDown = true; return; }
                foreach (var btn in _btns) if (btn.Hit(x, y) && btn.On) { _pressed = btn; btn.Press(true); return; }
            }
            if (_backDown) { if (up) { _backDown = false; if (_phase == "play") Pause(); else Leave(); } return; }
            if (_pressed != null)
            {
                if (up) { var b = _pressed; _pressed = null; b.Press(false); if (b.Hit(x, y)) b.Action(); }
                return;
            }

            float ax = x - AreaX;
            y -= _areaY;
            if (_g == null) return;
            int Col(float cx) => Math.Max(0, Math.Min(_g.K - 1, (int)Math.Floor(cx / _g.ColW)));
            bool inArea = ax >= 0 && ax < _g.W;
            if (down && inArea && _phase == "play")
            {
                _touch = new Touch { X0 = ax, Y0 = y };
                if (_held.HasValue) return;
                int col = Col(ax);
                int r = Engine.TopOf(_pos, col);
                if (r < 0) { _touch.Dead = true; Snd.Play("st_empty"); Bump(col, -1); return; }
                PickUp(r, col);
                _touch.Picked = true;
                return;
            }
            if (_touch != null && held && !up)
            {
                var T = _touch;
                if (T.Dead || !_held.HasValue) return;
                if (!T.Moved) { if (Math.Sqrt((ax - T.X0) * (ax - T.X0) + (y - T.Y0) * (y - T.Y0)) < 9) return; T.Moved = true; }
                // held by its middle, a little above the finger so it can be seen
                var h = _held.Value;
                var A = _anims[h.r];
                float bw = _g.Bw[h.r], bh = _g.Bh[h.r];
                A.Tok += 1; A.Tgt = null;
                A.X.StopAnimation(); A.Y.StopAnimation();
                double nx = Math.Max(0, Math.Min(_g.W - bw, ax - bw / 2)), ny = Math.Max(-bh * 0.3, Math.Min(_g.Surface - bh, y - bh * 0.85));
                A.X.SetValue(nx);
                A.Y.SetValue(ny);
                A.At = (nx, ny);
                // the swing: from how fast it's moved sideways (dp a ms), every few frames
                double now = _anim.Now;
                if (T.Lt < 0) { T.Lt = now; T.Lx = nx; LoopOf(ref A.HovLoop, A.Hov, HOVER_MS, false); }
                else if (now - T.Lt >= 40) { SwingOf(h.r, (nx - T.Lx) / (now - T.Lt)); T.Lt = now; T.Lx = nx; }
                int col = Col(ax);
                if (col != T.Col) { T.Col = col; _dragCol = col; }
                return;
            }
            if (_touch != null && up)
            {
                var T = _touch;
                _touch = null;
                if (T.Dead || !_held.HasValue || _phase != "play") return;
                int col = Col(ax);
                if (T.Moved) Drop(col, true);
                else if (!T.Picked) Drop(col);
                // a tap that lifted it: it stays up for the next tap
            }
        }

        void Leave()
        {
            ClearTimers();
            if (_blitz) PayOut();
            OnExit?.Invoke();
            Destroy(gameObject);
        }

        // ---- a button (squishdoku/ui.js SdButton): while pressed the whole button (lip and face) shrinks to 0.92 about its
        // centre, as the menu's Level crest does (timing 70 ms in, spring friction 3.5 tension 260 out)
        sealed class Btn
        {
            readonly StackGame _game;
            readonly string _name;
            readonly UiPiece _lip, _face;
            readonly float _x, _y, BW, BH;
            public readonly Action Action;
            readonly AnimatedValue _t = new AnimatedValue(0);
            public bool On { get; private set; }
            bool _built;
            const float Lip = 5;

            /// <summary>`w` x `h`: the whole button (its ring and the lip under it), as exported.</summary>
            public Btn(StackGame g, string name, float x, float y, float w, float h, int order, Action action)
            {
                _game = g; _name = name; _x = x; _y = y; BW = w; BH = h; Action = action;
                _lip = g.Piece(name + " lip", order);
                _face = g.Piece(name + " face", order + 1);
                SetOn(false, true);
            }

            public void SetOn(bool on, bool force = false)
            {
                if (on == On && _built && !force) return;
                On = on; _built = true;
                var key = $"btn-{_name}-{(on ? "on" : "off")}";
                _lip.SetSvg(Xml(key + "-lip"), BW, BH - Lip);
                _face.SetSvg(Xml(key + "-face"), BW, BH - Lip);
            }

            public bool Hit(float x, float y) => x >= _x - 6 && x <= _x + BW + 6 && y >= _y - 6 && y <= _y + BH + 6;

            public void Press(bool down)
            {
                if (down) Animated.Timing(_t, Timing(1, 70)).Start();
                else Animated.Spring(_t, Spring(0, 3.5, 260)).Start();
            }

            public void Draw()
            {
                var whole = Affine.Translate(_x, _y) * Fx.Pressed(BW, BH, _t.GetValue());
                _lip.Transform = whole * Affine.Translate(0, Lip);
                _face.Transform = whole;
            }
        }
    }

    /// <summary>Resources/Stack/stack.json: where the exported pieces sit on the reference screen, and the squishies.</summary>
    public sealed class StackLayout
    {
        public float[] back;
        public readonly Dictionary<string, float[]> buttons = new Dictionary<string, float[]>();
        public Dictionary<string, Squishy> art = new Dictionary<string, Squishy>();
        /// <summary>A button's box on the reference screen (x, y, w, h: its ring and lip).</summary>
        public (float x, float y, float w, float h) Button(string name) { var b = buttons[name]; return (b[0], b[1], b[2], b[3]); }

        [Serializable] sealed class Raw { public float[] back; public Btn[] buttonList; public ArtEntry[] artList; }
        [Serializable] sealed class Btn { public string name; public float[] b; }
        [Serializable] sealed class ArtEntry { public string key, file; public float ar; }

        public static StackLayout Load()
        {
            var text = Resources.Load<TextAsset>("Stack/stack")?.text ?? throw new InvalidOperationException("Resources/Stack/stack.json is missing: run node tools/unity/export-stack.mjs");
            var raw = JsonUtility.FromJson<Raw>(text);
            var l = new StackLayout { back = raw.back };
            if (raw.buttonList != null) foreach (var b in raw.buttonList) l.buttons[b.name] = b.b;
            foreach (var a in raw.artList) l.art[a.key] = new Squishy { Key = a.key, Picture = "Stack/art/" + a.file, Ar = a.ar };
            return l;
        }
    }
}
