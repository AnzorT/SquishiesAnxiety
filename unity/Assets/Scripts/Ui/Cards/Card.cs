// A popup card over a game, as src/squishdoku/Overlays.js Overlay shows one in landscape (REDESIGN_V8): the screen
// dims, and the card springs up into the middle (friction 6.5, tension 90; out in 180 ms, ease-in quad). What comes
// before <Split /> is its left column, the rest its right column, each a column of items centred across, 6 dp apart.
// Items are what the games' cards are made of (Overlays.js, fx.js, ui.js, sort/Cards.js): texts, the sticker title,
// stars, the coins counting up, the XP bar, LEVEL n!, a creature's head, rows and columns of buttons; each may pop in
// (PopIn) or slide in (SlideIn) as the app's do, with the same delays.
// Layout follows what Chrome lays out (checked by tools/unity/stack-test cards): sizes in dp, positions snapped to 1/64.
// A card is drawn as CardLayers: the dimmed screen, the card with everything that doesn't move on it, then each
// moving item's own layers. No UnityEngine here; CardPieces shows the layers in Unity.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    /// <summary>A player level as src/playerXp.js gives it (before / after a game).</summary>
    public struct XpLevel
    {
        public double Level, Into, Need;
        public XpLevel(double level, double into, double need) { Level = level; Into = into; Need = need; }
    }

    public class Card
    {
        /// <summary>The text of a piece exported from the app (Resources/Cards/&lt;name&gt;.xml); set by the host.</summary>
        public static Func<string, string> LoadXml;

        public readonly List<CardItem> Left = new List<CardItem>(), Right = new List<CardItem>();
        public string Tint = "rgba(50,24,6,0.55)";
        /// <summary>Its PopIns and SlideIns are keyed on `visible` (trigger={visible}): they start again as it closes.</summary>
        public bool RetriggerOnHide;

        readonly float _sw, _sh;
        readonly CardLayer _scrim = new CardLayer("scrim"), _frame = new CardLayer("card");
        readonly AnimatedValue _t = new AnimatedValue(0);
        CompositeAnimation _anim;
        bool _empty;
        CardButton _pressed;

        /// <summary>On screen (also while closing).</summary>
        public bool Shown { get; private set; }
        /// <summary>Open: takes every tap on the screen.</summary>
        public bool Visible { get; private set; }
        public float CardX { get; private set; }
        public float CardY { get; private set; }
        public float CardW { get; private set; }
        public float CardH { get; private set; }
        public Affine CardTransform { get; private set; } = Affine.Identity;

        static readonly Interpolator ScrimOp = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.0, 1 }, true);
        static readonly Interpolator CardOp = Fx.Lerp(new[] { 0, 0.3, 1 }, new[] { 0.0, 1, 1 }, true);
        static readonly Interpolator Rise = Fx.Lerp(new[] { 0.0, 1 }, new[] { 120.0, 0 });
        static readonly Interpolator Grow = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.7, 1 });

        /// <summary>A card over a screen `screenW` x `screenH` dp.</summary>
        public Card(float screenW, float screenH) { _sw = screenW; _sh = screenH; }

        public IEnumerable<CardItem> Items { get { foreach (var i in Left) yield return i; foreach (var i in Right) yield return i; } }

        public void Show()
        {
            if (Visible) return;
            Visible = Shown = true;
            _empty = false;
            Layout();
            foreach (var i in Items) i.Mount();
            foreach (var i in Items) i.Trigger();
            _anim?.Stop();
            _t.SetValue(0);
            _anim = Animated.Spring(_t, Fx.Spring(1, 6.5, 90));
            _anim.Start();
        }

        /// <summary>Closes it (180 ms). `emptied`: its content goes at once and the empty card closes (a ResultCard whose
        /// `res` went null: `&lt;Overlay visible={false} /&gt;`).</summary>
        public void Hide(bool emptied = false)
        {
            if (!Visible) return;
            Visible = false;
            if (_pressed != null) { _pressed.Press.Up(); _pressed = null; }
            if (emptied)
            {
                foreach (var i in Items) i.Unmount();
                _empty = true;
                Layout();
            }
            else if (RetriggerOnHide) foreach (var i in Items) i.Trigger();
            _anim?.Stop();
            _anim = Animated.Timing(_t, Fx.Timing(0, 180, Easing.In(Easing.Quad)));
            _anim.Start(r =>
            {
                if (Visible) return;
                Shown = false;
                if (!_empty) foreach (var i in Items) i.Unmount();
            });
        }

        // ---- layout -------------------------------------------------------------------------------------------------
        /// <summary>To Chrome's layout grid, 1/64 dp, as it splits free space (a centred box): rounded down.</summary>
        public static float Snap(double v) => (float)(Math.Floor(v * 64 + 1e-6) / 64);
        /// <summary>The nearest whole dp (halves up), where Chrome puts an &lt;svg&gt; (a title, a star, the coin).</summary>
        public static float Whole(double v) => (float)Math.Floor(v + 0.5);

        void Layout()
        {
            float avail = _sw - 20;   // the overlay's padding (landscape: 10)
            float fillH;
            if (_empty)
            {
                CardW = Math.Min(avail, 380);
                fillH = 24;
            }
            else
            {
                // two columns: maxWidth 660, the fill 20 dp in at the sides, 22 dp between the columns
                CardW = Math.Min(avail, 660);
                float colW = (CardW - 12 - 40 - 22) / 2;
                float hl = Measure(Left, colW), hr = Measure(Right, colW), inner = Math.Max(hl, hr);
                fillH = inner + 24;
                Place(Left, 26, 18 + (inner - hl) / 2, colW);
                Place(Right, 26 + colW + 22, 18 + (inner - hr) / 2, colW);
            }
            CardH = fillH + 17;
            CardX = Snap(10 + (avail - CardW) / 2);
            CardY = Snap(10 + (_sh - 20 - CardH) / 2);
            foreach (var i in Items) { i.OX = CardX; i.OY = CardY; i.Snapped(); }
            var s = new UiSvg(CardW, CardH);
            // Chrome paints the card's own boxes (a transformed view) on whole dp: a card at y 59.5 shows at 60, while
            // what's in it stays where it was laid out
            float fx = Whole(CardX) - CardX, fy = Whole(CardY) - CardY;
            if (fx != 0 || fy != 0) s.Open($"transform=\"translate({UiSvg.F(fx)} {UiSvg.F(fy)})\"");
            CardArt.Frame(s, CardW, fillH);
            if (fx != 0 || fy != 0) s.Close();
            if (!_empty) foreach (var i in Items) if (i.IsStatic) i.DrawStatic(s);
            _frame.Set(s.Markup, CardW, CardH, 4);
            _scrim.Set(new UiSvg(_sw, _sh).Box(0, 0, _sw, _sh, new BoxStyle { Background = Tint }).Markup, _sw, _sh, 0);
        }

        const float Gap = 6;

        static float Measure(List<CardItem> col, float colW)
        {
            float h = 0;
            for (int i = 0; i < col.Count; i++)
            {
                col[i].Measure(colW);
                h += col[i].MarginTop + col[i].H + col[i].MarginBottom + (i > 0 ? Gap : 0);
            }
            return h;
        }

        static void Place(List<CardItem> col, float x, float y, float colW)
        {
            foreach (var it in col)
            {
                y += it.MarginTop;
                it.ColX = x; it.ColW = colW;
                it.X = Snap(x + (colW - it.W) / 2);
                it.Y = y;
                y += it.H + it.MarginBottom + Gap;
            }
        }

        // ---- every frame --------------------------------------------------------------------------------------------
        /// <summary>Places every layer for the clock's current time (call after the Ticker's tick).</summary>
        public void Update()
        {
            double t = _t.GetValue();
            CardTransform = Affine.Translate(CardX, CardY) * Fx.About(CardW, CardH, Affine.Translate(0, Rise.Evaluate(t)) * Affine.ScaleBy(Grow.Evaluate(t), Grow.Evaluate(t)));
            float op = (float)CardOp.Evaluate(t);
            _scrim.Opacity = (float)ScrimOp.Evaluate(t);
            _frame.Transform = CardTransform;
            _frame.Opacity = op;
            if (!_empty) foreach (var i in Items) i.Place(CardTransform, op);
        }

        /// <summary>Its layers in paint order (nothing once it's closed).</summary>
        public IEnumerable<CardLayer> Layers()
        {
            if (!Shown) yield break;
            yield return _scrim;
            yield return _frame;
            if (_empty) yield break;
            foreach (var i in Items) foreach (var l in i.Layers) yield return l;
        }

        // ---- taps (screen dp) -----------------------------------------------------------------------------------------
        public IEnumerable<CardButton> Buttons { get { foreach (var i in Items) foreach (var b in i.Buttons) yield return b; } }

        /// <summary>A finger down: true when the card takes it (it's open: nothing under it gets taps).</summary>
        public bool Down(float x, float y)
        {
            if (!Visible) return false;
            foreach (var b in Buttons)
                if (b.Enabled && b.Hit(x, y)) { _pressed = b; b.Press.Down(); break; }
            return true;
        }

        /// <summary>The finger up: a pressed button that it's still over is pressed.</summary>
        public bool Up(float x, float y)
        {
            if (_pressed == null) return Visible;
            var b = _pressed;
            _pressed = null;
            b.Press.Up();
            if (b.Hit(x, y)) b.OnPress?.Invoke();
            return true;
        }
    }

    // ==== the items ======================================================================================================

    public abstract class CardItem
    {
        public float W, H, MarginTop, MarginBottom;
        /// <summary>The box's top-left on the card, and its column.</summary>
        public float X, Y, ColX, ColW;
        /// <summary>The card's top-left on the screen as laid out (before it moves).</summary>
        public float OX, OY;
        public readonly List<CardLayer> Layers = new List<CardLayer>();
        public PopIn Pop;
        public SlideIn Slide;

        /// <summary>Drawn on the card itself (it never moves on it).</summary>
        public virtual bool IsStatic => Pop == null && Slide == null;
        public abstract void Measure(float colW);
        public virtual void DrawStatic(UiSvg s) { }
        public virtual void Mount() { }
        public virtual void Unmount() { Pop?.Stop(); Slide?.Stop(); }
        public virtual void Trigger() { Pop?.Trigger(); Slide?.Trigger(); }
        public virtual IEnumerable<CardButton> Buttons { get { yield break; } }
        /// <summary>Laid out, the card placed: an &lt;svg&gt; (a title, a star, the coin) moves to whole dp on the screen, where
        /// Chrome paints it (measured on the app's pictures, tools/unity/stack-test cards).</summary>
        public virtual void Snapped() { }
        /// <summary>How far an svg at card-local (x, y) moves to land on whole dp.</summary>
        protected (float dx, float dy) ToWhole(float x, float y) => (Card.Whole(OX + x) - (OX + x), Card.Whole(OY + y) - (OY + y));

        /// <summary>The box's transform (card-local box top-left → screen) with its PopIn / SlideIn, and its opacity.</summary>
        protected (Affine m, float o) Box(Affine card, float opacity)
        {
            var m = card * Affine.Translate(X, Y);
            if (Pop != null) return (m * Pop.Local(W, H), opacity * Pop.Opacity);
            if (Slide != null) return (m * Slide.Local, opacity * Slide.Opacity);
            return (m, opacity);
        }

        public virtual void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            foreach (var l in Layers) { l.Transform = m; l.Opacity = o; }
        }

        protected CardLayer Layer(string name) { var l = new CardLayer(name); Layers.Add(l); return l; }
    }

    /// <summary>A Text: one line, or wrapped into the column (centred lines), with padding at the sides.</summary>
    public sealed class TextItem : CardItem
    {
        readonly string _text;
        readonly TextStyle _style;
        readonly float _padH;
        List<string> _lines;
        CardLayer _layer;

        public TextItem(string text, TextStyle style, float padH = 0) { _text = text; _style = style; _padH = padH; }

        public override void Measure(float colW)
        {
            float full = UiSvg.BoxWidth(_text, _style);
            _lines = full + 2 * _padH <= colW ? new List<string> { _text } : CardArt.Wrap(_text, _style, colW - 2 * _padH);
            W = _lines.Count == 1 ? full + 2 * _padH : colW;
            H = UiSvg.LineBox(_style) * _lines.Count;
            if (!IsStatic)
            {
                _layer ??= Layer("text");
                var s = new UiSvg(W, H);
                CardArt.Lines(s, _lines, _padH, 0, W - 2 * _padH, _style);
                _layer.Set(s.Markup, W, H);
            }
        }

        public override void DrawStatic(UiSvg s) => CardArt.Lines(s, _lines, X + _padH, Y, W - 2 * _padH, _style);
    }

    /// <summary>OutlinedTitle.</summary>
    public sealed class TitleItem : CardItem
    {
        readonly CardArt.Title _title;
        CardLayer _layer;
        public TitleItem(CardArt.Title title) { _title = title; }
        public override void Measure(float colW)
        {
            W = _title.W; H = _title.H;
            if (!IsStatic) (_layer ??= Layer("title")).Set(_title.Markup(), W, H, 8);
        }
        public override void DrawStatic(UiSvg s) => _title.Draw(s, X, Y);
        public override void Snapped() { var (dx, dy) = ToWhole(X, Y); X += dx; Y += dy; }   // (an svg, popping or not)
    }

    /// <summary>ui.js Head in a PopIn, rocking (FailCard).</summary>
    public sealed class HeadItem : CardItem
    {
        readonly float _size;
        readonly string _picture, _ring, _bg;
        readonly bool _dim;
        readonly Rock _rock;
        readonly CardLayer _layer;

        public HeadItem(float size, string picture, string ring, string bg, bool dim, Rock rock)
        {
            _size = size; _picture = picture; _ring = ring; _bg = bg; _dim = dim; _rock = rock;
            _layer = Layer("head");
        }
        public override bool IsStatic => false;
        public override void Measure(float colW)
        {
            W = H = _size;
            var s = new UiSvg(W, H);
            CardArt.Head(s, 0, 0, _size, _picture, _ring, _bg, _dim);
            _layer.Set(s.Markup, W, H, 2);
        }
        public override void Mount() => _rock?.Mount();
        public override void Unmount() { base.Unmount(); _rock?.Unmount(); }
        public override void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            _layer.Transform = _rock != null ? m * _rock.Local(W, H) : m;
            _layer.Opacity = o;
        }
    }

    /// <summary>sort/Cards.js Star, three in a row (the result's stars): an earned one bursts in with spinning rays and
    /// gold sparks, a missed one thuds in.</summary>
    public sealed class StarsItem : CardItem
    {
        sealed class OneStar
        {
            public bool Earned, Big;
            public double Delay;
            public float S, Box, Mt, Bx, By;
            public readonly AnimatedValue T = new AnimatedValue(0);
            public CompositeAnimation A;
            public Interpolator Scale, Rotate;
            public readonly Spin Spin = new Spin();
            public CardLayer Rays, Star;
            public int Timer;
            public readonly List<Burst> Bursts = new List<Burst>();
        }

        readonly OneStar[] _stars = new OneStar[3];
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 0.0, 1, 1 });
        Ticker _tk;

        /// <summary>`stars` earned of three, the first popping at `first` ms, then every `step`.</summary>
        public StarsItem(int stars, double first = 380, double step = 480)
        {
            MarginTop = 4; MarginBottom = 8;
            for (int i = 0; i < 3; i++)
            {
                var s = new OneStar { Earned = i < stars, Big = i == 1, Delay = first + i * step };
                s.S = s.Big ? 74 : 60;
                s.Box = s.S + 20;
                s.Mt = s.Big ? -12 : 6;
                s.Scale = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? 0 : 1.5, 1 });
                s.Rotate = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? -40.0 : 0, 0 });
                _stars[i] = s;
            }
        }

        public override bool IsStatic => false;

        public override void Measure(float colW)
        {
            W = 0; H = 0;
            foreach (var s in _stars) { W += s.Box; H = Math.Max(H, s.Mt + s.Box); }
            float x = 0;
            foreach (var s in _stars) { s.Bx = x; s.By = (H - (s.Mt + s.Box)) / 2 + s.Mt; x += s.Box; }
            Rebuild();
        }

        void Rebuild()
        {
            Layers.Clear();
            float first = 0;
            foreach (var s in _stars)
            {
                if (s.Earned)
                {
                    if (first == 0) first = s.S * 1.8f;
                    s.Rays ??= new CardLayer("rays");
                    s.Rays.Set(CardArt.Rays(s.S * 1.8f, opacity: 0.6f, color: "#ffe45c", fadeSize: Fx.LikeWeb ? first : 0), s.S * 1.8f, s.S * 1.8f, 1);
                    Layers.Add(s.Rays);
                }
                s.Star ??= new CardLayer("star");
                s.Star.Set(CardArt.Star(s.S, s.Earned), s.S, s.S, 3);
                Layers.Add(s.Star);
                foreach (var b in s.Bursts) Layers.AddRange(b.Layers);
            }
        }

        public override void Mount()
        {
            _tk = Ticker.Default;
            foreach (var s in _stars)
            {
                var star = s;
                s.T.SetValue(0);
                s.A = Animated.Spring(s.T, Fx.Spring(1, s.Earned ? 3.6 : 7, s.Earned ? 170 : 120, s.Delay));
                s.A.Start();
                if (s.Earned) s.Spin.Mount();
                s.Timer = _tk.SetTimeout(() =>
                {
                    if (!star.Earned) return;
                    var b = new Burst("gold", star.S / 2 + 10, star.S / 2 + 10, 1);
                    star.Bursts.Add(b);
                    b.Start(() => { star.Bursts.Remove(b); Rebuild(); });
                    Rebuild();
                }, s.Delay + 60);
            }
        }

        public override void Unmount()
        {
            foreach (var s in _stars)
            {
                s.A?.Stop();
                s.Spin.Unmount();
                _tk?.ClearTimeout(s.Timer);
                foreach (var b in s.Bursts.ToArray()) b.Stop();
                s.Bursts.Clear();
            }
            Rebuild();
        }

        public override void Place(Affine card, float opacity)
        {
            var row = card * Affine.Translate(X, Y);
            foreach (var s in _stars)
            {
                double t = s.T.GetValue();
                var box = row * Affine.Translate(s.Bx, s.By);
                if (s.Rays != null)
                {
                    // RaysSpin sits in a 0 x 0 view at the star's centre: its top-left there, turning about its own centre
                    float r = s.S * 1.8f;
                    var (rx, ry) = ToWhole(X + s.Bx + s.Box / 2, Y + s.By + s.Box / 2);
                    s.Rays.Transform = box * Affine.Translate(s.Box / 2 + rx, s.Box / 2 + ry) * Fx.About(r, r, Affine.Rotate(s.Spin.Degrees));
                    s.Rays.Opacity = opacity * Clamp01(t);
                }
                double sc = s.Scale.Evaluate(t);
                var (dx, dy) = ToWhole(X + s.Bx + 10, Y + s.By + 10);
                s.Star.Transform = box * Affine.Translate(10 + dx, 10 + dy) * Fx.About(s.S, s.S, Affine.ScaleBy(sc, sc) * Affine.Rotate(s.Rotate.Evaluate(t)));
                s.Star.Opacity = opacity * Clamp01(Op.Evaluate(t));
                foreach (var b in s.Bursts) b.Place(box, opacity);
            }
        }

        static float Clamp01(double v) => (float)Math.Max(0, Math.Min(1, v));
    }

    /// <summary>The result's reward row: the coin, the coins counting up (CountUp, at least 70 dp wide), "+n XP".</summary>
    public sealed class RewardItem : CardItem
    {
        public readonly CountUp Count;
        readonly double _xp;
        readonly CardLayer _coin, _num, _xpPlus;
        static readonly TextStyle CoinsText = CardArt.Style(CardArt.Display, 28, "#b86200");
        static readonly TextStyle XpPlusText = CardArt.Style(CardArt.Display, 16, "#b8641c");
        int _shown = -1;
        float _numW, _xpW;

        public RewardItem(double coins, double xp, double countDelay, double countMs = 800)
        {
            _xp = xp;
            Count = new CountUp(coins, countMs, countDelay);
            _coin = Layer("coin");
            _num = Layer("coins");
            if (xp != 0) _xpPlus = Layer("xp plus");
        }

        public override bool IsStatic => false;

        public override void Measure(float colW)
        {
            _coin.Set(Card.LoadXml("coin"), 26, 26, 2);
            if (_xpPlus != null)
            {
                var t = "+" + Num(_xp);
                _xpW = UiSvg.BoxWidth(t, XpPlusText);
                _xpPlus.Set(new UiSvg(_xpW, UiSvg.LineBox(XpPlusText)).Text(t, 0, 0, XpPlusText).Markup, _xpW, UiSvg.LineBox(XpPlusText));
            }
            Sized();
        }

        void Sized()
        {
            if (_shown == Count.Shown && _shown >= 0) return;
            _shown = Count.Shown;
            var t = "+" + _shown;
            _numW = Math.Max(70, UiSvg.BoxWidth(t, CoinsText));
            float lh = UiSvg.LineBox(CoinsText);
            _num.Set(new UiSvg(_numW, lh).Text(t, 0, 0, CoinsText).Markup, _numW, lh);
            W = 26 + 6 + _numW + (_xpPlus != null ? 6 + 8 + _xpW : 0);
            H = Math.Max(26, Math.Max(lh, _xpPlus != null ? UiSvg.LineBox(XpPlusText) : 0));
            // (its width follows the number: the row stays centred in the column)
            if (ColW > 0) X = Card.Snap(ColX + (ColW - W) / 2);
        }

        static string Num(double v) => v.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) + " XP";

        public override void Mount() { Count.Mount(); _shown = -1; Sized(); }
        public override void Unmount() { base.Unmount(); Count.Unmount(); }

        public override void Place(Affine card, float opacity)
        {
            Sized();
            var (m, o) = Box(card, opacity);
            var (cx, cy) = ToWhole(X, Y + (H - 26) / 2);
            _coin.Transform = m * Affine.Translate(cx, (H - 26) / 2 + cy);
            _num.Transform = m * Affine.Translate(32, (H - _num.H) / 2);
            if (_xpPlus != null) _xpPlus.Transform = m * Affine.Translate(32 + _numW + 6 + 8, (H - _xpPlus.H) / 2);
            foreach (var l in Layers) l.Opacity = o;
        }
    }

    /// <summary>Overlays.js XpBar (in its SlideIn): the level badge, the track filling up.</summary>
    public sealed class XpBarItem : CardItem
    {
        readonly XpFill _fill;
        readonly CardLayer _bar, _fillLayer;
        double _lv = double.NaN, _frac = double.NaN;

        public XpBarItem(XpLevel before, XpLevel after, double delay)
        {
            _fill = new XpFill(before.Level, before.Into, before.Need, after.Level, after.Into, after.Need, delay);
            _bar = Layer("xp bar");
            _fillLayer = Layer("xp fill");
        }
        public override bool IsStatic => false;
        public override void Measure(float colW) { W = CardArt.XpW; H = CardArt.XpH; Redraw(); }
        void Redraw()
        {
            if (_fill.Level != _lv) { _lv = _fill.Level; _bar.Set(CardArt.XpBar(_lv), W, H, 2); }
            if (_fill.Frac != _frac) { _frac = _fill.Frac; _fillLayer.Set(CardArt.XpFill(_frac), W, H, 2); }
        }
        public override void Mount() => _fill.Mount();
        public override void Unmount() { base.Unmount(); _fill.Unmount(); }
        public override void Place(Affine card, float opacity) { Redraw(); base.Place(card, opacity); }
    }

    /// <summary>Overlays.js levelUp: "LEVEL n!" and "A new prize on your level road" in a brown box, rocking inside it.</summary>
    public sealed class LevelUpItem : CardItem
    {
        readonly string _title, _sub;
        readonly Rock _rock = new Rock(3);
        readonly CardLayer _box, _text;
        float _rw;
        const float RockH = 36;

        public LevelUpItem(double level, string sub = "A new prize on your level road")
        {
            _title = "LEVEL " + level.ToString(System.Globalization.CultureInfo.InvariantCulture) + "!";
            _sub = sub;
            _box = Layer("level up");
            _text = Layer("level up text");
        }
        public override bool IsStatic => false;
        public override void Measure(float colW)
        {
            _rw = Math.Max(UiSvg.BoxWidth(_title, CardArt.LevelUpText), UiSvg.BoxWidth(_sub, CardArt.LevelUpSub));
            float lh = UiSvg.LineBox(CardArt.LevelUpText), lh2 = UiSvg.LineBox(CardArt.LevelUpSub);
            W = _rw + 2 * 14 + 6;
            H = lh + lh2 + 2 * 5 + 6;
            _box.Set(new UiSvg(W, H).Box(0, 0, W, H, new BoxStyle { Background = "#b8641c", Radius = 16, BorderWidth = 3, BorderColor = "#ffffff" }).Markup, W, H, 2);
            var s = new UiSvg(_rw, lh + lh2);
            s.Text(_title, 0, 0, CardArt.LevelUpText, _rw, 0.5f);
            s.Text(_sub, 0, lh, CardArt.LevelUpSub, _rw, 0.5f);
            _text.Set(s.Markup, _rw, lh + lh2, 4);
        }
        public override void Mount() => _rock.Mount();
        public override void Unmount() { base.Unmount(); _rock.Unmount(); }
        public override void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            _box.Transform = m;
            _text.Transform = m * Affine.Translate(3 + 14, 3 + 5) * _rock.Local(_rw, _text.H);
            _box.Opacity = _text.Opacity = o;
        }
    }

    /// <summary>An SdButton on a card.</summary>
    public sealed class CardButton
    {
        public readonly CardArt.ButtonLook Look;
        public Action OnPress;
        public readonly Press Press = new Press();
        public readonly CardLayer Lip = new CardLayer("lip"), Face = new CardLayer("face");
        public float X, Y;   // in its row / column
        Affine _at = Affine.Identity;
        public bool Enabled => !Look.Disabled;
        public float W => Look.W;
        public float H => Look.H;

        public CardButton(CardArt.ButtonLook look, Action onPress) { Look = look; OnPress = onPress; }

        public void Build()
        {
            Lip.Set(Look.LipMarkup(), Look.RingW, Look.RingH, 2);
            Face.Set(Look.FaceMarkup(), Look.RingW, Look.RingH, 2);
        }

        /// <summary>`at`: the button's box (top-left) to the screen. The lip stays, the face moves down 4 dp while pressed
        /// and the whole button shrinks to 0.93.</summary>
        public void Place(Affine at, float opacity)
        {
            _at = at;
            double t = Press.T, s = 1 + (0.93 - 1) * t, ty = (CardArt.ButtonLook.Lip - 1) * t;
            var whole = at * Fx.About(W, H, Affine.ScaleBy(s, s));
            Lip.Transform = whole * Affine.Translate(0, CardArt.ButtonLook.Lip);
            Face.Transform = whole * Affine.Translate(0, ty);
            Lip.Opacity = Face.Opacity = opacity;
        }

        /// <summary>A screen point on it (hitSlop 6).</summary>
        public bool Hit(float x, float y)
        {
            var p = _at.Inverse().Apply(new Vec2(x, y));
            return p.X >= -6 && p.X <= W + 6 && p.Y >= -6 && p.Y <= H + 6;
        }
    }

    /// <summary>Buttons in a row (btnRow: gap 8, centred, may overflow the column) or down the column, as wide as it
    /// (col: gap 4), 6 dp below what's above them; in a SlideIn or not.</summary>
    public sealed class ButtonsItem : CardItem
    {
        readonly List<CardButton> _buttons;
        readonly bool _column;

        public ButtonsItem(bool column, params CardButton[] buttons)
        {
            _column = column;
            _buttons = new List<CardButton>(buttons);
            MarginTop = 6;
            foreach (var b in _buttons) { Layers.Add(b.Lip); Layers.Add(b.Face); }
        }

        public override bool IsStatic => false;
        public override IEnumerable<CardButton> Buttons => _buttons;

        public override void Measure(float colW)
        {
            if (_column)
            {
                W = colW; H = 0;
                foreach (var b in _buttons)
                {
                    b.Look.Width = colW;
                    b.Build();
                    b.X = 0; b.Y = H;
                    H += b.H + 4;
                }
                H -= 4;
                return;
            }
            float sum = -8;
            H = 0;
            foreach (var b in _buttons) { b.Build(); sum += b.W + 8; H = Math.Max(H, b.H); }
            W = Math.Min(sum, colW);
            float x = (W - sum) / 2;
            foreach (var b in _buttons) { b.X = Card.Snap(x); b.Y = 0; x += b.W + 8; }
        }

        public override void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            foreach (var b in _buttons) b.Place(m * Affine.Translate(b.X, b.Y), o);
        }
    }

    /// <summary>The shared pieces of the result cards.</summary>
    public static class CardParts
    {
        /// <summary>Overlays.js XpGain: under a result's coins, the XP bar from `delay` (sliding in 200 ms before), and LEVEL
        /// n! 600 ms after it when the level rose. Nothing without XP.</summary>
        public static void XpGain(List<CardItem> col, double xp, XpLevel? before, XpLevel after, int levelUps, double delay)
        {
            if (xp == 0 || before == null) return;
            col.Add(new XpBarItem(before.Value, after, delay) { Slide = new SlideIn(delay - 200, 16) });
            if (levelUps > 0) col.Add(new LevelUpItem(after.Level) { Pop = new PopIn(delay + 600) });
        }
    }
}
