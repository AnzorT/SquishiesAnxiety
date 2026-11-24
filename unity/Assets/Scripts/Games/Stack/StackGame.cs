// One level of Squish Stack and the ones after it, as src/stack/Game.js plays it (Blitz, ten puzzles on one clock:
// StackBlitz.cs, the same class), in landscape (REDESIGN_V8: the HUD in a 250 dp column on the left, the cushions in the middle, UNDO / RESTART /
// HINT down a 150 dp column on the right).
//   intro  the level's number and what's in it          deal  the squishies drop onto their cushions
//   play   tap a cushion to lift its top squishy, tap another to put it there; or drag it. A big one dropped on a
//          smaller one squashes it flat and boings home (no move counted). The clock runs from level 15.
//   won    the result card 1500 ms later: NEXT / REPLAY / MENU          lost   the clock ran out: the fail card 1300 ms
//          later: RETRY / MENU
//   The back orb (or Escape, Android's back) while playing pauses: the clock stops, the pause card (RESUME / NEW PUZZLE /
//   QUIT). The first HINT of a level asks first (the hint card: it costs a star, and an ad without Remove Ads).
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
        UiPiece _bg, _left, _back, _rug, _colGlow, _bannerPiece;
        UiPiece[] _seats, _halos, _badges, _pieces;
        readonly List<Btn> _btns = new List<Btn>();

        const float GAP = 16;
        static readonly Func<double, double> GRAVITY = Easing.Bezier(0.55, 0, 1, 0.45);
        const float LeftW = 250, RightW = 150;

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
            _left = Piece("left column", 10);
            _back = Piece("back", 11);
            _back.SetSvg(Xml("back"), 40, 40);
            _back.Transform = Affine.Translate(_layout.back[0], _layout.back[1]);
            // the buttons, centred down the right column as on the reference screen (Blitz has no HINT: the two others
            // centre 32.5 dp lower)
            float bx = W - RightW + 14, by0 = H / 2 + (_layout.buttonsTop - 192) + (_blitz ? 32.5f : 0);
            _btns.Add(new Btn(this, "undo", bx, by0, 20, () => Undo()));
            _btns.Add(new Btn(this, "restart", bx, by0 + 65, 22, () => Restart()));
            if (!_blitz) _btns.Add(new Btn(this, "hint", bx, by0 + 130, 24, () => AskHint()));
            _rug = Piece("rug", 30);
            _colGlow = Piece("column glow", 31);
            _bannerPiece = Piece("banner", 200);
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

        // ---- a squishy's motion values (Game.js anims) ---------------------------------------------------------------
        sealed class PieceAnims
        {
            public AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), O = new AnimatedValue(0), Wx = new AnimatedValue(1), Wy = new AnimatedValue(1),
                Sq = new AnimatedValue(0), Hop = new AnimatedValue(0), Rot = new AnimatedValue(0);
            public (double x, double y)? Tgt;
            public double Wgt = -1;
            public int Tok;
            public CompositeAnimation Wig;
        }

        // ---- state ----------------------------------------------------------------------------------------------------
        string _phase = "load";
        int[] _pos;
        (int r, int from)? _held;
        int _moves, _top = -1, _dragCol = -1;
        bool _hinted, _canUndo;
        (int from, int to)? _glow;
        readonly List<int[]> _hist = new List<int[]>();
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
                A.Tok += 1;
                Animated.Parallel(Animated.Spring(A.X, Spring(s.X, 7, 120)), Animated.Spring(A.Y, Spring(s.Y, 7, 120))).Start();
            }
        }

        struct Step { public double X, Y, Ms; public Func<double, double> Ex, Ey; }

        // one step after another; `done` only if nothing else moved it meanwhile
        void Fly(int r, Step[] steps, Action done)
        {
            var A = _anims[r];
            int tok = ++A.Tok;
            var last = steps[steps.Length - 1];
            A.Tgt = (last.X, last.Y);
            var seq = new CompositeAnimation[steps.Length];
            for (int i = 0; i < steps.Length; i++)
            {
                var s = steps[i];
                seq[i] = Animated.Parallel(
                    Animated.Timing(A.X, Timing(s.X, s.Ms, s.Ex ?? Easing.InOut(Easing.Quad))),
                    Animated.Timing(A.Y, Timing(s.Y, s.Ms, s.Ey ?? Easing.InOut(Easing.Quad))));
            }
            Animated.Sequence(seq).Start(res => { if (res.Finished && A.Tok == tok && done != null) done(); });
        }

        void Wiggle(int r, bool on)
        {
            var A = _anims[r];
            A.Wig?.Stop();
            A.Wig = null;
            if (!on) { Animated.Spring(A.Rot, Spring(0, 4, 160)).Start(); return; }
            A.Wig = Animated.Loop(Animated.Sequence(
                Animated.Timing(A.Rot, Timing(1, 260, Easing.InOut(Easing.Sin))),
                Animated.Timing(A.Rot, Timing(-1, 260, Easing.InOut(Easing.Sin)))));
            A.Wig.Start();
        }

        void Bump(int p, double k = 1)
        {
            var B = _bumps[p];
            B.SetValue(0);
            Animated.Sequence(Animated.Timing(B, Timing(k, 80, Easing.Out(Easing.Quad))), Animated.Spring(B, Spring(0, 3.5, 170))).Start();
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
            A.Tgt = (XOf(r, p), HoverY(r));
            A.Tok += 1;
            Animated.Parallel(
                Animated.Timing(A.X, Timing(A.Tgt.Value.x, 150, Easing.Out(Easing.Quad))),
                Animated.Timing(A.Y, Timing(A.Tgt.Value.y, 200, Easing.Out(Easing.Back(1.6))))).Start();
            Wiggle(r, true);
            Settle();   // the stack under it stands up a little
            Hud();
        }

        void Land(int r, bool soft = false)
        {
            if (_held.HasValue && _held.Value.r == r) return;
            Settle();   // the ones under it squish down a little
            var A = _anims[r];
            A.Sq.SetValue(0);
            Animated.Sequence(Animated.Timing(A.Sq, Timing(soft ? 0.6 : 1, 70)), Animated.Spring(A.Sq, Spring(0, 3.5, 170))).Start();
            int p = _pos[r];
            var st = Engine.StackOf(_pos, p);
            if (st.Length > 0 && st[0] == r) { Bump(p, soft ? 0.6 : 1); Snd.Play("st_cushion", rate: RateOf(r)); }
            else Snd.Play("st_land", rate: RateOf(r));
            if (soft) return;
            Snd.Place();
            var ls = SpotsOf(_pos)[r];
            Spray("dust", Cx(p), ls.Y + _g.Bh[r] * 0.98, 0.8);
            if (_phase == "play" && Engine.Same(_pos, _puzzle.Goal)) Win();
        }

        // the lifted one let go over cushion p
        void Drop(int p, bool dragged = false)
        {
            if (!_held.HasValue) return;
            var (r, from) = _held.Value;
            Wiggle(r, false);
            _dragCol = -1;
            _held = null;
            if (p == from || p < 0)
            {
                var s0 = SpotsOf(_pos)[r];
                Fly(r, new[] { new Step { X = s0.X, Y = s0.Y, Ms = 170, Ey = GRAVITY } }, () => Land(r, true));
                Hud();
                return;
            }
            if (Engine.CanMove(_pos, from, p) < 0) { BounceOff(r, from, p); Hud(); return; }
            var next = (int[])_pos.Clone();
            next[r] = p;
            _pos = next;
            _hist.Add(new[] { r, from, p });
            _canUndo = true;
            _moves += 1;
            var s = SpotsOf(_pos)[r];
            float dx = Math.Abs(Cx(p) - Cx(from));
            if (dragged) Fly(r, new[] { new Step { X = s.X, Y = s.Y, Ms = 200, Ex = Easing.Out(Easing.Quad), Ey = GRAVITY } }, () => Land(r));
            else Fly(r, new[] { new Step { X = s.X, Y = HoverY(r), Ms = 110 + dx * 0.45 }, new Step { X = s.X, Y = s.Y, Ms = 170, Ey = GRAVITY } }, () => Land(r));
            Hud();
        }

        // Too big for cushion p: it lands on the small one's head, squashes it flat, and boings home. No move counted.
        void BounceOff(int r, int from, int p)
        {
            int t = Engine.TopOf(_pos, p);
            var ts = SpotsOf(_pos)[t];
            float sit = ts.Y + _g.Bh[t] * (1 - ts.Sy) + _g.Bh[t] * 0.42f - _g.Bh[r];
            float dx = Math.Abs(Cx(p) - Cx(from));
            _top = r;
            Fly(r, new[] { new Step { X = XOf(r, p), Y = HoverY(r), Ms = 110 + dx * 0.45 }, new Step { X = XOf(r, p), Y = sit, Ms = 140, Ey = GRAVITY } }, () =>
            {
                var T = _anims[t];
                T.Sq.SetValue(0);
                Animated.Sequence(Animated.Timing(T.Sq, Timing(1.7, 80)), Animated.Timing(T.Sq, Timing(1.55, 180)), Animated.Spring(T.Sq, Spring(0, 3, 140))).Start();
                Snd.Play("st_ouch");
                Snd.Wrong();
                Spray("angry", Cx(p), ts.Y + _g.Bh[t] * 0.5, 1);
                Say("TOO BIG!", small: true, ink: "#8e1030", hold: 380, sub: _spec.Lv <= 3 ? "Big ones never sit on smaller ones" : null);
                if (_blitz) BlitzMistake();
                int tok = _anims[r].Tok;
                Later(260, () =>
                {
                    if (_anims[r].Tok != tok || (_held.HasValue && _held.Value.r == r)) return;
                    Snd.Play("st_bounce");
                    var s = SpotsOf(_pos)[r];
                    Fly(r, new[]
                    {
                        new Step { X = XOf(r, p), Y = HoverY(r) - 24, Ms = 220, Ey = Easing.Out(Easing.Quad) },
                        new Step { X = s.X, Y = HoverY(r) - 10, Ms = 130 + dx * 0.45 },
                        new Step { X = s.X, Y = s.Y, Ms = 170, Ey = GRAVITY },
                    }, () => Land(r, true));
                });
            });
        }

        void Undo()
        {
            if (_phase != "play" || _paused) return;
            if (_held.HasValue) Drop(_held.Value.from);
            if (_hist.Count == 0) return;
            var m = _hist[_hist.Count - 1];
            _hist.RemoveAt(_hist.Count - 1);
            _canUndo = _hist.Count > 0;
            Snd.Play("st_undo");
            int r = m[0], from = m[1], to = m[2];
            var next = (int[])_pos.Clone();
            next[r] = from;
            _pos = next;
            _top = r;
            _glow = null;
            var s = SpotsOf(_pos)[r];
            Fly(r, new[]
            {
                new Step { X = XOf(r, to), Y = HoverY(r), Ms = 140, Ey = Easing.Out(Easing.Quad) },
                new Step { X = s.X, Y = HoverY(r), Ms = 150 },
                new Step { X = s.X, Y = s.Y, Ms = 160, Ey = GRAVITY },
            }, () => Land(r, true));
            Settle();   // the stack it left stands up
            Hud();
        }

        // everyone back where this puzzle started (the clock keeps going)
        void Restart()
        {
            if (_phase != "play" || _paused) return;
            if (_held.HasValue) { Wiggle(_held.Value.r, false); _held = null; }
            _pos = (int[])_puzzle.Start.Clone();
            _hist.Clear();
            _canUndo = false;
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
            var A = _anims[r];
            var hops = new List<CompositeAnimation>();
            for (int i = 0; i < 2; i++)
            {
                hops.Add(Animated.Timing(A.Hop, Timing(-_g.Bh[r] * 0.28, 170, Easing.Out(Easing.Quad))));
                hops.Add(Animated.Timing(A.Hop, Timing(0, 200, Easing.Bounce)));
            }
            Animated.Sequence(hops).Start();
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
            if (!_blitz || _run.Idx == Levels.BLITZ_ROUNDS - 1)
            {
                Later(250, () => { Snd.Play("sd_confetti"); Spray("confetti", _g.W / 2, _g.H * 0.35, 1.2); });
                Later(650, () => Spray("confetti", _g.W * 0.25, _g.H * 0.5, 1));
                Later(800, () => Spray("confetti", _g.W * 0.75, _g.H * 0.5, 1));
            }
            int i = 0;
            for (int p = 0; p < _spec.K; p++)
            {
                var st = Engine.StackOf(_pos, p);
                for (int j = st.Length - 1; j >= 0; j--)
                {
                    int r = st[j];
                    double d = 150 + i++ * 70;
                    Later(d, () => Animated.Sequence(
                        Animated.Timing(_anims[r].Hop, Timing(-_g.Bh[r] * 0.3, 170, Easing.Out(Easing.Quad))),
                        Animated.Timing(_anims[r].Hop, Timing(0, 220, Easing.Bounce))).Start());
                }
            }
            // Blitz: a pip fills, then the next puzzle or the run is won (BlitzRun)
            if (_blitz) { _clk.Pause(); StopInterval(); RunCall(_run.Cleared); Hud(); return; }
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
            if (_blitz) { BlitzPause(); return; }
            PauseClock();
            _paused = true;
            _pause = Open(StackCards.PauseCard(W, H, Resume, Leave), PAUSE);
            Hud();
        }

        void Resume()
        {
            if (!_paused) return;
            if (_blitz) { PressCard("RESUME"); return; }   // (the run's pause card resumes: BlitzResumed)
            _paused = false;
            Close(ref _pause);
            if (_spec.Clock && _clockPaused >= 0) { _clockStart += _anim.Now - _clockPaused; _clockPaused = -1; }
            Hud();
        }

        // BackHandler: the hint card closes, a pause resumes, play pauses, anything else leaves
        void Back()
        {
            if (_hintAsk != null) Close(ref _hintAsk);
            else if (_paused) Resume();
            else if (_phase == "play") Pause();
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
            if (_blitz) { Effect(() => RunCall(_run.TimeUp)); return; }   // BlitzRun: the fail card (on the render), then BlitzLost
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
            if (_blitz) { BlitzStartPlay(); return; }
            if (_spec.Clock) { _clockStart = _anim.Now; _clockPaused = -1; }
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
            // the cards close (a result card empties at once: its `res` is gone); Blitz's are the run's
            Close(ref _result, true);
            Close(ref _fail);
            Close(ref _pause);
            Close(ref _hintAsk);
            _paused = false;
            var rec = Levels.Record(Profile);
            _spec = _blitz ? Levels.BlitzSpec(_run.Idx, rec.BSkill) : Levels.LevelSpec(_lv, rec.Skill);
            _puzzle = PuzzleSource != null ? PuzzleSource(_spec) : Engine.MakePuzzle(_spec);
            _who = CastSource != null ? CastSource(_spec.N) : PickCast(_spec.N);
            _limit = Levels.LimitFor(_spec, _puzzle.Par);
            _g = Geom(W - LeftW - RightW, H, _spec.N, _spec.K, _who);
            BuildBoard();
            _held = null; _top = -1; _dragCol = -1; _glow = null;
            _pos = (int[])_puzzle.Start.Clone();
            _hist.Clear(); _canUndo = false; _moves = 0; _hinted = false;
            _secs = (int)Math.Ceiling(_limit / 1000.0);
            _clockStart = _anim.Now; _clockPaused = _anim.Now;
            // everyone above their spot, waiting to drop in
            var m = SpotsOf(_puzzle.Start);
            for (int r = 0; r < _anims.Length; r++)
            {
                var A = _anims[r];
                A.Wig?.Stop(); A.Wig = null; A.Tok += 1;
                A.Rot.SetValue(0); A.Sq.SetValue(0); A.Hop.SetValue(0); A.O.SetValue(0);
                A.Wx.SetValue(m[r].Sx); A.Wy.SetValue(m[r].Sy); A.Wgt = m[r].Sy;
                A.X.SetValue(m[r].X); A.Y.SetValue(m[r].Y - _g.H * 0.6);
                A.Tgt = (m[r].X, m[r].Y);
            }
            _phase = "intro";
            if (_blitz) { StopInterval(); if (BlitzIntro()) { Hud(); return; } }
            var chips = new List<string> { Levels.TIER_NAMES[_spec.Tier] };
            if (_spec.Goal == "picture") chips.Add("GOAL CARD");
            if (_spec.K == 4) chips.Add("4 CUSHIONS");
            if (_spec.Clock) chips.Add("⏱ " + Levels.Clock(_limit));
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
            return GameCards.TrioOf(want, _layout.art.Keys);
        }

        // `n` different squishies, in a random order (roster.js pickCast; the player's own first once the profile is real)
        Squishy[] PickCast(int n)
        {
            var keys = new List<string>(_layout.art.Keys);
            var rand = new System.Random();
            for (int i = keys.Count - 1; i > 0; i--) { int j = rand.Next(i + 1); (keys[i], keys[j]) = (keys[j], keys[i]); }
            var who = new Squishy[n];
            for (int i = 0; i < n; i++) who[i] = _layout.art[keys[i]];
            return who;
        }

        void BuildBoard()
        {
            float ax = LeftW;
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
            _rug.SetSvg(new UiSvg(_g.W, rugH).Box(0, 0, _g.W, rugH, new BoxStyle { Background = "rgba(255,255,255,0.16)", Radius = _g.W, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.4)", Dashed = true }).Markup, _g.W, rugH);
            _rug.Transform = Affine.Translate(ax, _g.H - rugH);
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
            float w = _g != null ? _g.W : W - LeftW - RightW;
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

        // ---- the HUD's left column ------------------------------------------------------------------------------------
        void Hud()
        {
            if (_g == null || _puzzle == null) return;
            if (_blitz) { BlitzHud(); return; }
            int can = Levels.StarsFor(_puzzle.Par, _moves + Engine.Left(_puzzle.Sol, _pos), _hinted);
            var d = new StackArt.Hud
            {
                Lv = _spec.Lv, Tier = _spec.Tier, Moves = _moves, Par = _puzzle.Par, Stars = can, K = _spec.K, Star = _puzzle.Star,
                Who = _who, Goal = _puzzle.Goal,
                TipText = _spec.Clock ? null : TipFor(),
                ClockText = _spec.Clock ? Levels.Clock(_secs * 1000.0) : null,
                ClockFrac = _spec.Clock && _limit > 0 ? (float)Math.Max(0, 1 - Elapsed / _limit) : 1,
                ClockRed = _phase == "play" && _secs <= 10,
            };
            _left.SetSvg(StackArt.LeftColumn(d, H), LeftW, H, 4);
            bool playing = _phase == "play" && !_paused;
            _btns[0].SetOn(playing && _canUndo);
            _btns[1].SetOn(playing && _moves > 0);
            _btns[2].SetOn(playing);
        }

        string TipFor()
        {
            if (_spec.Lv == 1 && _moves == 0) return _held.HasValue ? "Now tap the ★ cushion to put it there!" : "Tap a cushion to lift the squishy on top.";
            if (_spec.Lv <= 3) return "A big squishy can never sit on a smaller one!";
            if (_spec.Goal == "picture") return "Make the cushions look like the GOAL card.";
            return "Get everyone onto the ★ cushion.";
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
            if (_spec != null && !_blitz && _spec.Clock && _phase == "play" && !_paused)
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
            var at = Affine.Translate(ax, 0);
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
            float ax = LeftW;
            DrawFx(ax);
            // the squishies (Game.js Piece): placed (x, y), squished by the ones on them from their feet, their own squash /
            // hop / wiggle on top; each view's transform about its centre
            var zOf = new Dictionary<int, int>();
            for (int p = 0; p < _spec.K; p++) { var st = Engine.StackOf(_pos, p); for (int j = 0; j < st.Length; j++) zOf[st[j]] = 10 + j; }
            for (int r = 0; r < _spec.N; r++)
            {
                var A = _anims[r];
                float w = _g.Bw[r], h = _g.Bh[r];
                double wy = A.Wy.GetValue(), wx = A.Wx.GetValue(), sq = A.Sq.GetValue();
                double wT = Lerp3(wy, 0, 1, h / 2.0, 0);
                double sqX = Piecewise(sq, new[] { -1.0, 0, 1 }, new[] { 0.9, 1, 1.22 }), sqY = Piecewise(sq, new[] { -1.0, 0, 1 }, new[] { 1.12, 1, 0.74 });
                double sqT = Piecewise(sq, new[] { -1.0, 0, 1 }, new[] { -0.06 * h, 0, 0.13 * h });
                double rot = Piecewise(A.Rot.GetValue(), new[] { -1.0, 1 }, new[] { -6.0, 6 });
                var c = Affine.Translate(w / 2.0, h / 2.0); var ci = Affine.Translate(-w / 2.0, -h / 2.0);
                var m = Affine.Translate(ax + A.X.GetValue(), A.Y.GetValue())
                        * c * Affine.Translate(0, wT) * Affine.ScaleBy(wx, wy) * ci
                        * c * Affine.Translate(0, A.Hop.GetValue()) * Affine.Translate(0, sqT) * Affine.ScaleBy(sqX, sqY) * Affine.Rotate(rot) * ci;
                _pieces[r].Transform = m;
                _pieces[r].Opacity = (float)A.O.GetValue();
                _pieces[r].Order = 40 + (r == _top ? 99 : zOf.TryGetValue(r, out var z) ? z : 10);
            }
            // the cushions bump when something lands; the hint's and the first level's glow pulses (each cushion's own loop,
            // from when its glow comes on: idleLoop.js usePingPong(960, { on }))
            int nudge = _spec.Lv == 1 && _moves == 0 && _phase == "play" ? (_held.HasValue ? _puzzle.Star : 0) : -1;
            for (int p = 0; p < _spec.K; p++)
            {
                float w = _g.CushW, h = _g.CushH, x = ax + Cx(p) - w / 2, top = _g.Surface - h * 0.4f;
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
            _colGlow.Visible = _dragCol >= 0;
            if (_dragCol >= 0) _colGlow.Transform = Affine.Translate(ax + _g.ColW * _dragCol + 4, 0);
            // the banner: over the area's top, scaled and turned about its centre
            double t = _bannerT.GetValue();
            _bannerPiece.Opacity = (float)Piecewise(t, new[] { 0.0, 0.2, 1, 2 }, new[] { 0.0, 1, 1, 0 });
            double bs = Piecewise(t, new[] { 0.0, 1, 2 }, new[] { 0.3, 1, 1.25 }), br = Piecewise(t, new[] { 0.0, 1, 2 }, new[] { -12.0, -3, 0 });
            var bc = Affine.Translate(_bannerW / 2.0, _bannerH / 2.0); var bci = Affine.Translate(-_bannerW / 2.0, -_bannerH / 2.0);
            _bannerPiece.Transform = Affine.Translate(ax, 4) * bc * Affine.ScaleBy(bs, bs) * Affine.Rotate(br) * bci;
            foreach (var b in _btns) b.Draw();
            if (_blitz) BlitzDraw();
            // the cards: placed, and gone once closed
            _cardPieces.Sync(_blitz ? _run.Cards() : Cards);
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
        sealed class Touch { public float X0, Y0; public bool Moved, Picked, Dead; public int Col = -1; }
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
                if (x >= b[0] - 6 && x <= b[0] + 46 && y >= b[1] + _backDy - 6 && y <= b[1] + _backDy + 46) { _backDown = true; return; }
                foreach (var btn in _btns) if (btn.Hit(x, y) && btn.On) { _pressed = btn; btn.Press(true); return; }
            }
            if (_backDown) { if (up) { _backDown = false; if (_phase == "play") Pause(); else Leave(); } return; }
            if (_pressed != null)
            {
                if (up) { var b = _pressed; _pressed = null; b.Press(false); if (b.Hit(x, y)) b.Action(); }
                return;
            }

            float ax = x - LeftW;
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
                A.X.SetValue(Math.Max(0, Math.Min(_g.W - bw, ax - bw / 2)));
                A.Y.SetValue(Math.Max(-bh * 0.3, Math.Min(_g.Surface - bh, y - bh * 0.85)));
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
            if (_blitz) { StopInterval(); _run.ClearTimers(); _clk.Reset(); }
            OnExit?.Invoke();
            Destroy(gameObject);
        }

        // ---- a button (squishdoku/ui.js SdButton): the lip stays, the face moves down 4 dp while pressed and the whole
        // button shrinks to 0.93 (timing 70 ms in, spring friction 3.5 tension 260 out)
        sealed class Btn
        {
            readonly StackGame _game;
            readonly string _name;
            readonly UiPiece _lip, _face;
            readonly float _x, _y;
            public readonly Action Action;
            readonly AnimatedValue _t = new AnimatedValue(0);
            public bool On { get; private set; }
            bool _built;
            const float BW = 122, BH = 55, Lip = 5;

            public Btn(StackGame g, string name, float x, float y, int order, Action action)
            {
                _game = g; _name = name; _x = x; _y = y; Action = action;
                _lip = g.Piece(name + " lip", order);
                _face = g.Piece(name + " face", order + 1);
                SetOn(false, true);
            }

            public void SetOn(bool on, bool force = false)
            {
                if (on == On && _built && !force) return;
                On = on; _built = true;
                var key = $"btn-{_name}-{(on ? "on" : "off")}";
                _lip.SetSvg(Xml(key + "-lip"), BW, 50);
                _face.SetSvg(Xml(key + "-face"), BW, 50);
            }

            public bool Hit(float x, float y) => x >= _x - 6 && x <= _x + BW + 6 && y >= _y - 6 && y <= _y + BH + 6;

            public void Press(bool down)
            {
                if (down) Animated.Timing(_t, Timing(1, 70)).Start();
                else Animated.Spring(_t, Spring(0, 3.5, 260)).Start();
            }

            public void Draw()
            {
                double t = _t.GetValue();
                double s = 1 + (0.93 - 1) * t, ty = (Lip - 1) * t;
                var c = Affine.Translate(BW / 2.0, BH / 2.0); var ci = Affine.Translate(-BW / 2.0, -BH / 2.0);
                var whole = Affine.Translate(_x, _y) * c * Affine.ScaleBy(s, s) * ci;
                _lip.Transform = whole * Affine.Translate(0, Lip);
                _face.Transform = whole * Affine.Translate(0, ty);
            }
        }
    }

    /// <summary>Resources/Stack/stack.json: where the exported pieces sit on the reference screen, and the squishies.</summary>
    public sealed class StackLayout
    {
        public float[] back;
        public float buttonsTop;
        public Dictionary<string, Squishy> art = new Dictionary<string, Squishy>();

        [Serializable] sealed class Raw { public float[] back; public Btn[] buttonList; public ArtEntry[] artList; }
        [Serializable] sealed class Btn { public string name; public float[] b; }
        [Serializable] sealed class ArtEntry { public string key, file; public float ar; }

        public static StackLayout Load()
        {
            var text = Resources.Load<TextAsset>("Stack/stack")?.text ?? throw new InvalidOperationException("Resources/Stack/stack.json is missing: run node tools/unity/export-stack.mjs");
            var raw = JsonUtility.FromJson<Raw>(text);
            var l = new StackLayout { back = raw.back, buttonsTop = 96.5f };
            if (raw.buttonList != null) foreach (var b in raw.buttonList) if (b.name == "btn-undo-on") l.buttonsTop = b.b[1];
            foreach (var a in raw.artList) l.art[a.key] = new Squishy { Key = a.key, Picture = "Stack/art/" + a.file, Ar = a.ar };
            return l;
        }
    }
}
