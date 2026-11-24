// The Game Park's games carousel (webgame/app/menu.js showGames / place / go / playAt / leavePark), as plain C#: where
// every piece is and how it moves, as a list of pictures to draw. No UnityEngine here, so tools/unity/park-test draws
// the same list outside Unity and compares it with the app's screenshots; ParkCarousel puts it on screen.
//
// Every motion is the app's CSS, with its durations, delays and cubic-bezier curves (CssEase):
//   .sq-pk.in (two frames after the carousel is made; at once when the app opens straight into the park)
//     .sq-pkdim  opacity .5s ease                       .mm-pgh  opacity .4s ease, translateY(-14px) .5s (.2,.9,.25,1)
//     .sq-rays   opacity -> .55 .6s ease, delay .2s     .sq-halo opacity .6s ease, delay .2s
//     .sq-gc     opacity .45s ease, translateX(160px) scale(.8) -> none .6s (.2,1.2,.4,1), delay .05s + .07s per
//                card away from the one in the middle when the carousel was made
//   place()  each slot: translate(±round(CW * .45 + |d| * 40), 0) scale(.8) off the middle, opacity 0 / 1 (transform
//            .5s (.3,1.3,.5,1), opacity .35s ease), z 50 - |d|; the middle one flashes (sqCen: brightness 1.35 -> 1,
//            .5s ease); PLAY on the others is saturate(.7); the arrows at the ends opacity .4; the dots .3s ease
//   playAt   the card scale(.94) .18s ease, scale(1.04) 180 ms later, the game opens 420 ms after the tap
//   leave    .in removed (everything above runs back), the carousel removed 420 ms later
//   Squish Time's creature: sqSqz 1.9s ease-in-out per keyframe, its squish lines sqLines 1.9s ease-out
// Sizes follow the screen as showGames does: a pu (the page's CSS px) is H / 393 screen px, the page is W / pu wide,
// carL = round(max(200, pgW * .29)), CW = max(300, round(pgW - carL - 118)). The cards are pictures cut at the
// reference's CW (487 pu): on a screen with another CW they're scaled to its width.
using System;
using System.Collections.Generic;
using SquishSquad.Vector;

namespace SquishSquad.Menu
{
    public sealed class ParkModel
    {
        /// <summary>One picture to draw: `M` maps its pixels (whole picture, y down) to screen px (y down); only the
        /// part `Uv` (x0, y0, x1, y1 in 0..1 of the picture, top-left origin) is drawn. A masked draw is clipped to the
        /// mask picture (its alpha) placed by `MaskM`. Res "clip:<card>" is the card's video (Size = the clip's).</summary>
        public struct Draw
        {
            public string Key, Res;
            public Affine M;
            public int W, H;
            public double U0, V0, U1, V1;
            public double Opacity, Bright;
            public string Mask;
            public Affine MaskM;
            public int MaskW, MaskH;
            public List<Draw> Children;   // Res "card": a layer made of these (in its own px), drawn as one
        }

        public readonly ParkLayout L;
        public readonly double ScreenW, ScreenH;
        public readonly double Pu, PgW, CarL, CW, CarT, CarH, Cx, Cy;
        readonly double _s;          // screen px per reference px for the pieces that keep their size (Pu / reference Pu)
        readonly double _sCard;      // the cards' extra scale on screens with another CW
        readonly int _n;

        public int Cur { get; private set; }
        public bool Leaving { get; private set; }
        public bool Done(double now) => Leaving && now >= _leftAt + 420;
        public bool Starting => _playAt >= 0;
        /// <summary>Called when the game in the middle changes (to remember it).</summary>
        public Action<int> OnSelect;

        readonly double _created, _inAt;
        /// <summary>When Squish Time's keyframes started (when the carousel was made).</summary>
        public double SquishEpoch;
        bool _in;
        double _leftAt;
        readonly int _cur0;          // the middle card when made (its cards' transition delays count from it)

        readonly Tr _dim = new Tr(0), _headO = new Tr(0), _headY = new Tr(-14), _rays = new Tr(0), _halo = new Tr(0);
        readonly Tr[] _gcO, _gcX, _gcS, _slotX, _slotS, _slotO, _dotW, _dotM;
        readonly double[] _cen;      // when each card's sqCen flash started (NaN: not the middle one)

        static readonly Func<double, double> Ease = CssEase.Ease, EaseOut = CssEase.EaseOut, EaseInOut = CssEase.EaseInOut;
        static readonly Func<double, double> HeadCurve = CssEase.Bezier(.2, .9, .25, 1), GcCurve = CssEase.Bezier(.2, 1.2, .4, 1), SlotCurve = CssEase.Bezier(.3, 1.3, .5, 1);

        /// <param name="now">when showGames runs (ms)</param>
        /// <param name="instant">the app opened straight into the park: .in at once, nothing comes in</param>
        public ParkModel(ParkLayout layout, double screenW, double screenH, int cur, double now, bool instant)
        {
            L = layout;
            ScreenW = screenW; ScreenH = screenH;
            _n = L.games.Length;
            Pu = screenH / 393.0;
            PgW = screenW / Pu;
            CarL = JsRound(Math.Max(200, PgW * 0.29));
            CW = Math.Max(300, JsRound(PgW - CarL - 118));
            CarT = 56; CarH = 393 - CarT;
            Cx = CarL + (PgW - CarL) / 2; Cy = CarT + CarH / 2;
            double uRef = L.reference.px[1] / 393.0;
            _s = Pu / uRef;
            _sCard = CW / L.reference.CW;
            Cur = _cur0 = Math.Max(0, Math.Min(_n - 1, cur));
            _created = SquishEpoch = now;
            _inAt = instant ? now : now + 33;   // two animation frames (requestAnimationFrame twice)
            _gcO = new Tr[_n]; _gcX = new Tr[_n]; _gcS = new Tr[_n];
            _slotX = new Tr[_n]; _slotS = new Tr[_n]; _slotO = new Tr[_n]; _dotW = new Tr[_n]; _dotM = new Tr[_n];
            _cen = new double[_n];
            for (int i = 0; i < _n; i++)
            {
                int d = i - Cur, a = Math.Abs(d);
                _slotX[i] = new Tr(d == 0 ? 0 : Math.Sign(d) * JsRound(CW * 0.45 + a * 40));
                _slotS[i] = new Tr(d == 0 ? 1 : 0.8);
                _slotO[i] = new Tr(d == 0 ? 1 : 0);
                _dotW[i] = new Tr(d == 0 ? 18 : 7);
                _dotM[i] = new Tr(d == 0 ? 1 : 0);
                _cen[i] = d == 0 ? now : double.NaN;
                _gcO[i] = new Tr(0); _gcX[i] = new Tr(160); _gcS[i] = new Tr(0.8);
            }
            if (instant) { _in = true; SetIn(true, now, true); }
        }

        static double JsRound(double v) => Math.Floor(v + 0.5);   // Math.round

        // the .in class added (or removed): every transition it drives starts at `t`
        void SetIn(bool on, double t, bool jump = false)
        {
            _dim.Set(on ? 1 : 0, t, 500, 0, Ease, jump);
            _headO.Set(on ? 1 : 0, t, 400, 0, Ease, jump);
            _headY.Set(on ? 0 : -14, t, 500, 0, HeadCurve, jump);
            _rays.Set(on ? 0.55 : 0, t, 600, 200, Ease, jump);
            _halo.Set(on ? 1 : 0, t, 600, 200, Ease, jump);
            for (int i = 0; i < _n; i++)
            {
                double delay = (0.05 + Math.Abs(i - _cur0) * 0.07) * 1000;
                delay = Math.Round(delay / 10) * 10;   // (the app writes it with two decimals of a second)
                _gcO[i].Set(on ? 1 : 0, t, 450, delay, Ease, jump);
                _gcX[i].Set(on ? 0 : 160, t, 600, delay, GcCurve, jump);
                _gcS[i].Set(on ? 1 : 0.8, t, 600, delay, GcCurve, jump);
            }
        }

        // the time-driven steps that happen on their own (the .in class, PLAY's steps), at the time they're due
        void Advance(double now)
        {
            if (!_in && !Leaving && now >= _inAt) { _in = true; SetIn(true, _inAt); }
            if (_playAt >= 0 && !_bounced && now >= _playAt + 180) { _bounced = true; _gcS[Cur].Set(1.04, _playAt + 180, 180, 0, Ease); }
        }

        // ---- go(i): a new game in the middle ----------------------------------------------------------------------
        public bool Go(int i, double now)
        {
            Advance(now);
            i = Math.Max(0, Math.Min(_n - 1, i));
            if (i == Cur || Leaving) return false;
            int old = Cur;
            Cur = i;
            for (int j = 0; j < _n; j++)
            {
                int d = j - Cur, a = Math.Abs(d);
                _slotX[j].Set(d == 0 ? 0 : Math.Sign(d) * JsRound(CW * 0.45 + a * 40), now, 500, 0, SlotCurve);
                _slotS[j].Set(d == 0 ? 1 : 0.8, now, 500, 0, SlotCurve);
                _slotO[j].Set(d == 0 ? 1 : 0, now, 350, 0, Ease);
                _dotW[j].Set(d == 0 ? 18 : 7, now, 300, 0, Ease);
                _dotM[j].Set(d == 0 ? 1 : 0, now, 300, 0, Ease);
            }
            _cen[old] = double.NaN;
            _cen[Cur] = now;
            OnSelect?.Invoke(Cur);
            return true;
        }

        // ---- PLAY on the middle card (playAt) ------------------------------------------------------------------------
        double _playAt = -1;
        bool _bounced, _fired;

        public bool Play(double now)
        {
            Advance(now);
            if (Leaving || _playAt >= 0) return false;
            _playAt = now; _bounced = false; _fired = false;
            _gcX[Cur].Set(0, now, 180, 0, Ease);
            _gcO[Cur].Set(1, now, 0, 0, Ease, true);
            _gcS[Cur].Set(0.94, now, 180, 0, Ease);
            return true;
        }

        /// <summary>The game to open now (420 ms after PLAY), once; -1 if none.</summary>
        public int TakePlay(double now)
        {
            Advance(now);
            if (_playAt < 0 || _fired || now < _playAt + 420) return -1;
            _fired = true;
            return Cur;
        }

        /// <summary>The game didn't open (not in the Unity version yet): the card settles back.</summary>
        public void PlayDone(double now)
        {
            if (_playAt < 0) return;
            _playAt = -1;
            _gcS[Cur].Set(1, now, 180, 0, Ease);
        }

        // ---- leavePark: .in removed, the carousel gone 420 ms later -------------------------------------------------
        public void Leave(double now)
        {
            Advance(now);
            if (Leaving) return;
            Leaving = true; _leftAt = now;
            if (_in) { _in = false; SetIn(false, now); }
        }

        // ---- input -------------------------------------------------------------------------------------------------
        public enum Hit { None, Back, Prev, Next, Dot, Play, Card }

        /// <summary>What a tap at screen px `p` (y down) is on, and the dot's index for Hit.Dot.</summary>
        public Hit HitTest(double x, double y, out int index)
        {
            index = -1;
            if (Leaving) return Hit.None;
            var hb = L.header.box; var b = L.header.back;
            double hx = hb[0] * Pu, hy = (hb[1] + _headY.Last) * Pu;
            if (In(x, y, hx + b[0] * _s, hy + b[1] * _s, b[2] * _s, b[3] * _s)) return Hit.Back;
            if (In(x, y, (CarL + 10) * Pu, (Cy - 20) * Pu, 40 * Pu, 40 * Pu)) return Hit.Prev;
            if (In(x, y, (PgW - 52) * Pu, (Cy - 20) * Pu, 40 * Pu, 40 * Pu)) return Hit.Next;
            var dots = DotBoxes(double.MaxValue);
            for (int i = 0; i < _n; i++) if (In(x, y, dots[i * 2] * Pu, (393 - 14) * Pu, dots[i * 2 + 1] * Pu, 7 * Pu)) { index = i; return Hit.Dot; }
            // only the middle card takes taps (the others are pointer-events: none): its PLAY button and its window
            var c = L.cards[Cur];
            var m = CardMatrix(Cur, double.MaxValue);
            if (InMapped(m, c.go, x, y)) return Hit.Play;
            if (InMapped(m, c.win, x, y)) return Hit.Play;
            if (InMapped(m, new float[] { 0, 0, (float)(L.reference.CW * RefU), (float)(318 * RefU) }, x, y)) return Hit.Card;
            return Hit.None;
        }

        /// <summary>The carousel's own area, where a swipe counts (.sq-car).</summary>
        public bool InCarousel(double x, double y) => !Leaving && In(x, y, CarL * Pu, CarT * Pu, (PgW - CarL) * Pu, CarH * Pu);

        /// <summary>A swipe from (x0, y0) to (x1, y1), screen px: more than 36 pu sideways (and more sideways than
        /// down) goes to the next or previous game.</summary>
        public bool Swipe(double x0, double y0, double x1, double y1, double now)
        {
            double dx = (x1 - x0) / Pu, dy = (y1 - y0) / Pu;
            if (Math.Abs(dx) > 36 && Math.Abs(dx) > Math.Abs(dy)) { Go(Cur + (dx < 0 ? 1 : -1), now); return true; }
            return false;
        }

        /// <summary>PLAY held down: .sq-gc .go:active translateY(2px).</summary>
        public bool PlayPressed;

        static bool In(double x, double y, double l, double t, double w, double h) => x >= l && x < l + w && y >= t && y < t + h;
        bool InMapped(Affine m, float[] r, double x, double y)
        {
            var p = m.Inverse().Apply(new Vec2(x, y));
            return p.X >= r[0] && p.X < r[0] + r[2] && p.Y >= r[1] && p.Y < r[1] + r[3];
        }

        double RefU => L.reference.px[1] / 393.0;

        /// <summary>A card's CSS values at `now` (for the tests): slot translateX, scale, opacity; card translateX,
        /// scale, opacity; brightness.</summary>
        public double[] Css(int i, double now)
        {
            Advance(now);
            double br = !double.IsNaN(_cen[i]) && now - _cen[i] < 500 ? 1.35 + (1 - 1.35) * Ease(Math.Max(0, (now - _cen[i]) / 500)) : 1;
            return new[] { _slotX[i].At(now), _slotS[i].At(now), _slotO[i].At(now), _gcX[i].At(now), _gcS[i].At(now), _gcO[i].At(now), br };
        }

        // ---- placement -----------------------------------------------------------------------------------------------

        // a card's pixels (reference px from its slot's top-left) to screen px, with its slot's and its own transforms
        Affine CardMatrix(int i, double now)
        {
            double sx = Cx, sy = CarT + CarH / 2 - 175 + 159;   // the slot's centre (transform-origin), pu
            double refW = L.reference.CW * RefU, refH = 318 * RefU;
            bool rest = now == double.MaxValue;
            double tx = rest ? _slotX[i].To : _slotX[i].At(now), sc = rest ? _slotS[i].To : _slotS[i].At(now);
            double gx = rest ? _gcX[i].To : _gcX[i].At(now), gs = rest ? _gcS[i].To : _gcS[i].At(now);
            // card px -> pu around the slot's centre (scaled to this screen's CW), then the CSS transforms, then px
            var local = Affine.Translate(sx, sy) * Affine.ScaleBy(_sCard / RefU, _sCard / RefU) * Affine.Translate(-refW / 2, -refH / 2);
            var css = Affine.Translate(sx, sy) * Affine.Translate(tx, 0) * Affine.ScaleBy(sc, sc) * Affine.Translate(gx, 0) * Affine.ScaleBy(gs, gs) * Affine.Translate(-sx, -sy);
            return Affine.ScaleBy(Pu, Pu) * css * local;
        }

        // each dot's left edge and width, pu (a centred row: the widths animate, so do the places)
        double[] DotBoxes(double now)
        {
            var o = new double[_n * 2];
            double total = 6 * (_n - 1);
            for (int i = 0; i < _n; i++) { o[i * 2 + 1] = now == double.MaxValue ? _dotW[i].To : _dotW[i].At(now); total += o[i * 2 + 1]; }
            double x = Cx - total / 2;
            for (int i = 0; i < _n; i++) { o[i * 2] = x; x += o[i * 2 + 1] + 6; }
            return o;
        }

        static double Snap(double v) { double r = Math.Round(v); return Math.Abs(v - r) < 1e-3 ? r : v; }

        // a picture at (x, y) screen px, `s` screen px per picture px (whole pixels when it lands at scale 1)
        static Affine Place(double x, double y, double sx, double sy)
        {
            if (Math.Abs(sx - 1) < 1e-9 && Math.Abs(sy - 1) < 1e-9) { x = Snap(x); y = Snap(y); }
            return Affine.Translate(x, y) * Affine.ScaleBy(sx, sy);
        }

        // a whole picture: everything but the cards keeps the reference's size in pu
        Draw Pic(string key, ParkLayout.Pic p, double boxXpu, double boxYpu, double opacity)
        {
            var m = Place(boxXpu * Pu + p.at[0] * _s, boxYpu * Pu + p.at[1] * _s, _s, _s);
            return new Draw { Key = key, Res = p.res, M = m, W = p.size[0], H = p.size[1], U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = opacity, Bright = 1 };
        }

        static Draw OnCard(string key, ParkLayout.Pic p, Affine card, double boxX, double boxY, double opacity, double bright)
        {
            var m = card * Affine.Translate(boxX + p.at[0], boxY + p.at[1]);
            m = SnapM(m);
            return new Draw { Key = key, Res = p.res, M = m, W = p.size[0], H = p.size[1], U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = opacity, Bright = bright };
        }

        static Affine SnapM(Affine m)
        {
            if (Math.Abs(m.A - 1) < 1e-9 && Math.Abs(m.D - 1) < 1e-9 && Math.Abs(m.B) < 1e-12 && Math.Abs(m.C) < 1e-12) { m.E = Snap(m.E); m.F = Snap(m.F); }
            return m;
        }

        /// <summary>Everything to draw at `now` (ms), back to front.</summary>
        public List<Draw> Draws(double now)
        {
            Advance(now);
            var o = new List<Draw>();
            double gone = Done(now) ? 0 : 1;
            if (gone == 0) return o;

            // the dim layer: stretched to the screen (two gradients, one along x and one along y)
            double dimO = _dim.At(now);
            if (dimO > 0)
                o.Add(new Draw { Key = "dim", Res = L.dim.res, M = Place(0, 0, ScreenW / L.dim.rect[2], ScreenH / L.dim.rect[3]), W = L.dim.rect[2], H = L.dim.rect[3], U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = dimO, Bright = 1 });

            // the header: the back orb and "Game Park" (16 pu in, 12 down; slides down 14 pu as it comes in)
            double ho = _headO.At(now);
            if (ho > 0) o.Add(Pic("header", L.header, L.header.box[0], L.header.box[1] + _headY.At(now), ho));

            // the rays and the halo behind the middle card
            double ro = _rays.At(now), lo = _halo.At(now);
            if (ro > 0) o.Add(Pic("rays", L.rays, Cx - 246, Cy - 260, ro));   // (.sq-rays 492 px since 2026-11-20, was 560)
            if (lo > 0) o.Add(Pic("halo", L.halo, Cx - 160, Cy - 174, lo));

            // the cards, lowest z first (z 50 - |d|; DOM order among equals)
            var order = new List<int>();
            for (int i = 0; i < _n; i++) order.Add(i);
            order.Sort((a, b) => { int za = 50 - Math.Abs(a - Cur), zb = 50 - Math.Abs(b - Cur); return za != zb ? za.CompareTo(zb) : a.CompareTo(b); });
            foreach (int i in order) AddCard(o, i, now);

            // the position dots (z 55), then the arrows (z 60)
            var dots = DotBoxes(now);
            for (int i = 0; i < _n; i++)
            {
                double w = dots[i * 2 + 1], m = _dotM[i].At(now);
                if (m < 1) AddDot(o, "dot" + i + "off", L.dotOff, 7, dots[i * 2], w, 1 - m);
                if (m > 0) AddDot(o, "dot" + i + "on", L.dotOn, 18, dots[i * 2], w, m);
            }
            o.Add(Pic("arrowL", L.arrowL, CarL + 10, Cy - 20, Cur == 0 ? 0.4 : 1));
            o.Add(Pic("arrowR", L.arrowR, PgW - 52, Cy - 20, Cur == _n - 1 ? 0.4 : 1));
            return o;
        }

        // a dot `w` pu wide made from a picture of one `w0` wide: its round ends as they are, the straight middle
        // stretched (the dots are stadiums: 7 pu tall, ends of radius 3.5)
        void AddDot(List<Draw> o, string key, ParkLayout.Dot p, double w0, double xpu, double w, double opacity)
        {
            double ypu = 393 - 14;
            if (Math.Abs(w - w0) < 1e-6) { o.Add(Pic(key, p, xpu, ypu, opacity)); return; }
            double refU = RefU, bx = -p.at[0];                         // the box's left edge in the picture, px
            double cap = 3.5 * refU, L0 = bx + cap, R0 = bx + (w0 - 3.5) * refU;
            if (R0 - L0 < 1) { double c = (L0 + R0) / 2; L0 = c - 0.5; R0 = c + 0.5; }
            double mid = Math.Max(0, (w - 7) * refU);                  // the middle's width at this size, reference px
            double x0 = xpu * Pu + p.at[0] * _s, y0 = ypu * Pu + p.at[1] * _s;
            double W = p.size[0], H = p.size[1];
            void Part(string k, double sx0, double sx1, double dx0, double dw)
            {
                if (sx1 <= sx0 || dw <= 0) return;
                var m = Affine.Translate(x0 + dx0 * _s, y0) * Affine.ScaleBy(dw / (sx1 - sx0) * _s, _s) * Affine.Translate(-sx0, 0);
                o.Add(new Draw { Key = key + k, Res = p.res, M = m, W = p.size[0], H = p.size[1], U0 = sx0 / W, V0 = 0, U1 = sx1 / W, V1 = 1, Opacity = opacity, Bright = 1 });
            }
            Part("a", 0, L0, 0, L0);
            Part("b", L0, R0, L0, mid);
            Part("c", R0, W, L0 + mid, W - R0);
        }

        // A card is one layer, as CSS makes it (its opacity and the sqCen flash are on .sq-slot / .sq-gc): its pieces
        // are drawn into the card's own picture (Res "card", Children, in the card's px less `GroupPad`), and that is
        // drawn with the card's transform, opacity and brightness. Drawing the pieces one by one at half opacity would
        // let the card show through PLAY and the creature.
        public const int GroupPad = 40;

        void AddCard(List<Draw> o, int i, double now)
        {
            double op = _slotO[i].At(now) * _gcO[i].At(now);
            if (op <= 0) return;
            var c = L.cards[i];
            // sqCen: brightness(1.35) -> none over .5s ease, on the card that just came to the middle
            double br = 1;
            if (!double.IsNaN(_cen[i]) && now - _cen[i] < 500) br = 1.35 + (1 - 1.35) * Ease(Math.Max(0, (now - _cen[i]) / 500));
            string k = "card" + i;
            double gx = c.card.at[0] - GroupPad, gy = c.card.at[1] - GroupPad;
            var group = new Draw { Key = k, Res = "card", M = SnapM(CardMatrix(i, now) * Affine.Translate(gx, gy)), W = c.card.size[0] + 2 * GroupPad, H = c.card.size[1] + 2 * GroupPad, U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = op, Bright = br, Children = new List<Draw>() };
            var ch = group.Children;
            var m = Affine.Translate(-gx, -gy);   // card px -> the group's picture
            ch.Add(OnCard(k + "body", c.card, m, 0, 0, 1, 1));
            double wx = c.win[0], wy = c.win[1];
            var mask = c.mask;
            var maskM = SnapM(m * Affine.Translate(wx + mask.at[0], wy + mask.at[1]));
            if (c.hasClip && c.clip != null && c.clip.size != null && c.clip.size.Length == 2 && i == Cur && !Leaving)
            {
                // the clip, object-fit: cover in the window (Unity shows it once it has a frame; the card shows its
                // first frame until then, as the app's poster does)
                double vw = c.clip.size[0], vh = c.clip.size[1], s = Math.Max(c.win[2] / vw, c.win[3] / vh);
                var vm = m * Affine.Translate(wx + (c.win[2] - vw * s) / 2, wy + (c.win[3] - vh * s) / 2) * Affine.ScaleBy(s, s);
                ch.Add(new Draw { Key = k + "clip", Res = "clip:" + i, M = vm, W = (int)vw, H = (int)vh, U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = 1, Bright = 1, Mask = mask.res, MaskM = maskM, MaskW = mask.size[0], MaskH = mask.size[1] });
            }
            if (c.hasSquish && c.squish != null && c.squish.img != null && !string.IsNullOrEmpty(c.squish.img.res))
            {
                double t = ((now - SquishEpoch) % 1900 + 1900) % 1900 / 1900;
                Squash(t, out double sx, out double sy, out double rot);
                var b = c.squish.img.box;
                double ox = wx + b[0] + b[2] / 2, oy = wy + b[1] + b[3];        // transform-origin: 50% 100%
                var sq = m * Affine.Translate(ox, oy) * Affine.ScaleBy(sx, sy) * Affine.Rotate(rot) * Affine.Translate(-ox, -oy);
                var d = OnCard(k + "sqz", c.squish.img, sq, wx + b[0], wy + b[1], 1, 1);
                d.Mask = mask.res; d.MaskM = maskM; d.MaskW = mask.size[0]; d.MaskH = mask.size[1];
                ch.Add(d);
                double lo = Lines(t);
                if (lo > 0)
                    foreach (var part in new[] { c.squish.l, c.squish.r })
                    {
                        var dl = OnCard(k + "sqz" + (part == c.squish.l ? "l" : "r"), part, m, wx + part.box[0], wy + part.box[1], lo, 1);
                        dl.Mask = mask.res; dl.MaskM = maskM; dl.MaskW = mask.size[0]; dl.MaskH = mask.size[1];
                        ch.Add(dl);
                    }
            }
            ch.Add(OnCard(k + "over", c.over, m, wx, wy, 1, 1));
            // PLAY: saturate(.7) off the middle; 2 pu down while held
            bool mid = i == Cur;
            var gp = mid ? (ParkLayout.Pic)L.go : L.goDim;
            double press = mid && PlayPressed && !Leaving ? 2 * RefU : 0;   // (2 pu in the card's own px)
            ch.Add(OnCard(k + "go", gp, m, c.go[0], c.go[1] + press, 1, 1));
            o.Add(group);
        }

        // sqSqz: 0%,100% scale(1,1); 18% scale(1.22,.72); 30% scale(.9,1.14); 42% scale(1.05,.95); 54% scale(1,1);
        // 70% scale(1.12,.84) rotate(-4deg); 82% scale(.95,1.06) rotate(3deg); ease-in-out between keyframes
        static readonly double[] SqT = { 0, .18, .30, .42, .54, .70, .82, 1 };
        static readonly double[] SqX = { 1, 1.22, .9, 1.05, 1, 1.12, .95, 1 };
        static readonly double[] SqY = { 1, .72, 1.14, .95, 1, .84, 1.06, 1 };
        static readonly double[] SqR = { 0, 0, 0, 0, 0, -4, 3, 0 };
        static void Squash(double t, out double sx, out double sy, out double rot)
        {
            int k = 0;
            while (k < SqT.Length - 2 && t >= SqT[k + 1]) k++;
            double p = EaseInOut((t - SqT[k]) / (SqT[k + 1] - SqT[k]));
            sx = SqX[k] + (SqX[k + 1] - SqX[k]) * p;
            sy = SqY[k] + (SqY[k + 1] - SqY[k]) * p;
            rot = SqR[k] + (SqR[k + 1] - SqR[k]) * p;
        }

        // sqLines: 0%,12% opacity 0; 20% 1; 46%,100% 0; ease-out between keyframes
        static double Lines(double t)
        {
            if (t < .12 || t >= .46) return 0;
            if (t < .20) return EaseOut((t - .12) / .08);
            return 1 - EaseOut((t - .20) / .26);
        }

        // ---- a CSS transition of one number ----------------------------------------------------------------------
        sealed class Tr
        {
            double _from, _start, _dur, _delay;
            Func<double, double> _ease;
            public double To { get; private set; }
            public double Last { get; private set; }
            public Tr(double v) { _from = To = Last = v; _dur = 0; }

            public double At(double t)
            {
                double v;
                if (_dur <= 0 || t >= _start + _delay + _dur) v = To;
                else if (t <= _start + _delay) v = _from;
                else v = _from + (To - _from) * _ease((t - _start - _delay) / _dur);
                Last = v;
                return v;
            }

            // a new end value at time t: from wherever it is then (CSS starts a new transition only on a change)
            public void Set(double to, double t, double dur, double delay, Func<double, double> ease, bool jump = false)
            {
                if (jump || dur <= 0) { _from = To = Last = to; _dur = 0; return; }
                if (to == To) return;
                _from = At(t); To = to; _start = t; _dur = dur; _delay = delay; _ease = ease;
            }
        }
    }

    /// <summary>CSS timing functions: cubic-bezier(x1, y1, x2, y2) solved as Chrome's gfx::CubicBezier does
    /// (Newton's method, then bisection).</summary>
    public static class CssEase
    {
        public static readonly Func<double, double> Ease = Bezier(.25, .1, .25, 1);
        public static readonly Func<double, double> EaseOut = Bezier(0, 0, .58, 1);
        public static readonly Func<double, double> EaseIn = Bezier(.42, 0, 1, 1);
        public static readonly Func<double, double> EaseInOut = Bezier(.42, 0, .58, 1);

        public static Func<double, double> Bezier(double x1, double y1, double x2, double y2)
        {
            double cx = 3 * x1, bx = 3 * (x2 - x1) - cx, ax = 1 - cx - bx;
            double cy = 3 * y1, by = 3 * (y2 - y1) - cy, ay = 1 - cy - by;
            double X(double t) => ((ax * t + bx) * t + cx) * t;
            double Y(double t) => ((ay * t + by) * t + cy) * t;
            double dX(double t) => (3 * ax * t + 2 * bx) * t + cx;
            return x =>
            {
                if (x <= 0) return 0;
                if (x >= 1) return 1;
                double t = x;
                for (int i = 0; i < 8; i++)
                {
                    double e = X(t) - x;
                    if (Math.Abs(e) < 1e-7) return Y(t);
                    double d = dX(t);
                    if (Math.Abs(d) < 1e-6) break;
                    t -= e / d;
                }
                double lo = 0, hi = 1; t = x;
                for (int i = 0; i < 64 && lo < hi; i++)
                {
                    double v = X(t);
                    if (Math.Abs(v - x) < 1e-7) break;
                    if (x > v) lo = t; else hi = t;
                    t = (lo + hi) / 2;
                }
                return Y(t);
            };
        }
    }
}
