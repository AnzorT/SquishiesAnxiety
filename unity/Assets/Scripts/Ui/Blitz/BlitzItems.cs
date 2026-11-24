// The card items the Blitz cards are made of, on top of Ui/Cards' (TextItem, TitleItem, RewardItem, XpGain...):
//   HeadsItem      Overlays.js Slot x 3: the creatures popping in (BLITZ CHAMPION!'s three, every one earned)
//   ButtonRowItem  a row of SdButtons with its own gap and widths (GAME OVER's two 190 dp faces 12 apart; the save
//                  card's three, flex 1 up to 220 dp each, across the column), each a ButtonLook or a custom face
//   CountItem      fx.js CountUp as a line of its own (GAME OVER's boards cleared)
//   ColumnFx       an FxLayer filling a card's column: bursts at points in the column (BLITZ CHAMPION!'s confetti)
// No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Blitz
{
    /// <summary>Three creatures' heads in sticker circles (64, 78, 64 dp in boxes 16 dp bigger, the middle one 10 dp higher),
    /// 6 dp below the line above and 22 dp above the next: an earned one bursts in with spinning rays and gold sparks, a
    /// missed one thuds in grey. `delays`: when each pops (Overlays.js Slot's `delay`).</summary>
    public sealed class HeadsItem : CardItem
    {
        sealed class Slot
        {
            public bool Earned, Big;
            public double Delay;
            public float S, Box, Mt, Bx, By;
            public readonly AnimatedValue T = new AnimatedValue(0);
            public CompositeAnimation A;
            public Interpolator Scale, Rotate;
            public readonly Spin Spin = new Spin();
            public CardLayer Ghost, Rays, Head;
            public int Timer;
            public readonly List<Burst> Bursts = new List<Burst>();
        }

        readonly Slot[] _slots = new Slot[3];
        readonly string[] _pictures;
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 0.0, 1, 1 });
        Ticker _tk;

        public HeadsItem(int earned, string[] pictures, double first, double step)
        {
            _pictures = pictures ?? new string[3];
            MarginTop = 6; MarginBottom = 22;
            for (int i = 0; i < 3; i++)
            {
                var s = new Slot { Earned = i < earned, Big = i == 1, Delay = first + i * step };
                s.S = s.Big ? 78 : 64;
                s.Box = s.S + 16;
                s.Mt = s.Big ? -10 : 6;
                s.Scale = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? 0 : 1.6, 1 });
                s.Rotate = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? -30.0 : 0, 0 });
                _slots[i] = s;
            }
        }

        public override bool IsStatic => false;
        string Pic(int i) => i < _pictures.Length ? _pictures[i] : null;

        static string HeadSvg(float size, string pic, string ring, string bg, bool dim)
        {
            var s = new UiSvg(size, size);
            CardArt.Head(s, 0, 0, size, pic, ring, bg, dim);
            return s.Markup;
        }

        public override void Measure(float colW)
        {
            W = 0; H = 0;
            foreach (var s in _slots) { W += s.Box; H = Math.Max(H, s.Mt + s.Box); }
            float x = 0;
            foreach (var s in _slots) { s.Bx = x; s.By = (H - (s.Mt + s.Box)) / 2 + s.Mt; x += s.Box; }
            for (int i = 0; i < 3; i++)
            {
                var s = _slots[i];
                (s.Ghost ??= new CardLayer("ghost")).Set(HeadSvg(s.S, Pic(i), "rgba(255,255,255,0.7)", "rgba(230,200,160,0.35)", true), s.S, s.S, 2);
                if (s.Earned) (s.Rays ??= new CardLayer("rays")).Set(CardArt.Rays(s.S * 1.9f, opacity: 0.6f, color: "#ffe45c", fadeSize: Fx.LikeWeb ? _slots[0].S * 1.9f : 0), s.S * 1.9f, s.S * 1.9f, 1);
                (s.Head ??= new CardLayer("head")).Set(s.Earned ? HeadSvg(s.S, Pic(i), "#ffd23a", "#fffbe6", false) : HeadSvg(s.S, Pic(i), "#cfc3dd", "#efe9f5", true), s.S, s.S, 2);
            }
            Rebuild();
        }

        void Rebuild()
        {
            Layers.Clear();
            foreach (var s in _slots)
            {
                Layers.Add(s.Ghost);
                if (s.Rays != null) Layers.Add(s.Rays);
                Layers.Add(s.Head);
                foreach (var b in s.Bursts) Layers.AddRange(b.Layers);
            }
        }

        public override void Mount()
        {
            _tk = Ticker.Default;
            foreach (var s in _slots)
            {
                var slot = s;
                s.T.SetValue(0);
                s.A = Animated.Spring(s.T, Fx.Spring(1, s.Earned ? 3.6 : 7, s.Earned ? 170 : 120, s.Delay));
                s.A.Start();
                if (s.Earned) s.Spin.Mount();
                s.Timer = _tk.SetTimeout(() =>
                {
                    if (!slot.Earned) return;
                    var b = new Burst("gold", slot.S / 2 + 8, slot.S / 2 + 8, 1);
                    slot.Bursts.Add(b);
                    b.Start(() => { slot.Bursts.Remove(b); Rebuild(); });
                    Rebuild();
                }, s.Delay + 60);
            }
        }

        public override void Unmount()
        {
            foreach (var s in _slots)
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
            foreach (var s in _slots)
            {
                double t = s.T.GetValue();
                var box = row * Affine.Translate(s.Bx, s.By);
                float o = (s.Box - s.S) / 2;
                s.Ghost.Transform = box * Affine.Translate(o, o);
                s.Ghost.Opacity = opacity;
                if (s.Rays != null)
                {
                    float r = s.S * 1.9f;
                    var (rx, ry) = ToWhole(X + s.Bx + s.Box / 2, Y + s.By + s.Box / 2);
                    s.Rays.Transform = box * Affine.Translate(s.Box / 2 + rx, s.Box / 2 + ry) * Fx.About(r, r, Affine.Rotate(s.Spin.Degrees));
                    s.Rays.Opacity = opacity * Clamp01(t);
                }
                double sc = s.Scale.Evaluate(t);
                s.Head.Transform = box * Affine.Translate(o, o) * Fx.About(s.S, s.S, Affine.ScaleBy(sc, sc) * Affine.Rotate(s.Rotate.Evaluate(t)));
                s.Head.Opacity = opacity * Clamp01(Op.Evaluate(t));
                foreach (var b in s.Bursts) b.Place(box, opacity);
            }
        }

        static float Clamp01(double v) => (float)Math.Max(0, Math.Min(1, v));
    }

    /// <summary>One button of a ButtonRowItem: its look, and (flex) whether it grows to share the row, up to MaxW. A Face
    /// draws a custom face over the look's ring (an icon between labels), FaceH its face's height then.</summary>
    public sealed class RowButton
    {
        public CardButton Button;
        public bool Flex;
        public float MaxW = float.MaxValue;
        public Func<CardArt.ButtonLook, string> Face;
        /// <summary>A line under the button (the save card's "You have n gems").</summary>
        public string Note;
        public TextStyle NoteStyle;
        public float X, W, H;
        public CardLayer NoteLayer;
    }

    /// <summary>SdButtons in a row: `gap` apart, centred (justifyContent centre), top-aligned (alignItems flex-start),
    /// `marginTop` below what's above; `stretch`: the row is as wide as the column (alignSelf stretch) and flex buttons
    /// share it.</summary>
    public sealed class ButtonRowItem : CardItem
    {
        readonly List<RowButton> _row = new List<RowButton>();
        readonly float _gap;
        readonly bool _stretch;

        public ButtonRowItem(float gap, float marginTop, bool stretch, params RowButton[] row)
        {
            _gap = gap; _stretch = stretch;
            MarginTop = marginTop;
            SetRow(row);
        }

        /// <summary>New buttons in the row (the props changed while the card is up: a used ad, an error); lay the card out
        /// again after (BroadCard.Relayout).</summary>
        public void SetRow(params RowButton[] row)
        {
            _row.Clear();
            _row.AddRange(row);
            Layers.Clear();
            foreach (var r in _row)
            {
                Layers.Add(r.Button.Lip); Layers.Add(r.Button.Face);
                if (r.Note != null) { r.NoteLayer = new CardLayer("note"); Layers.Add(r.NoteLayer); }
            }
        }

        public override bool IsStatic => false;
        public override IEnumerable<CardButton> Buttons { get { foreach (var r in _row) yield return r.Button; } }

        public override void Measure(float colW)
        {
            float fixedW = 0; int flex = 0;
            foreach (var r in _row) { if (r.Flex) flex++; else { r.Button.Build(); fixedW += r.Button.W; } }
            float share = flex > 0 ? (colW - fixedW - _gap * (_row.Count - 1)) / flex : 0;
            float sum = -_gap;
            H = 0;
            foreach (var r in _row)
            {
                if (r.Flex) { r.Button.Look.Width = Math.Min(r.MaxW, share); r.Button.Build(); }
                if (r.Face != null) r.Button.Face.Set(r.Face(r.Button.Look), r.Button.Look.RingW, r.Button.Look.RingH, 2);
                r.W = r.Button.W;
                r.H = r.Button.H;
                if (r.Note != null)
                {
                    var lines = CardArt.Wrap(r.Note, r.NoteStyle, r.W);
                    float lh = UiSvg.LineBox(r.NoteStyle) * lines.Count;
                    var s = new UiSvg(r.W, lh);
                    CardArt.Lines(s, lines, 0, 0, r.W, r.NoteStyle);
                    r.NoteLayer.Set(s.Markup, r.W, lh, 2);
                    r.H += lh;
                }
                sum += r.W + _gap;
                H = Math.Max(H, r.H);
            }
            W = _stretch ? colW : Math.Min(sum, colW);
            float x = (W - sum) / 2;
            foreach (var r in _row) { r.X = Card.Snap(x); x += r.W + _gap; }
        }

        public override void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            foreach (var r in _row)
            {
                r.Button.Place(m * Affine.Translate(r.X, 0), o);
                if (r.NoteLayer != null) { r.NoteLayer.Transform = m * Affine.Translate(r.X, r.Button.H); r.NoteLayer.Opacity = o; }
            }
        }

        /// <summary>ui.js BtnLabel's style for a button of `kind` (cream: brown letters; the rest: white, outlined in the
        /// ring's colour).</summary>
        public static TextStyle LabelStyle(string kind, float size) => kind == "white"
            ? CardArt.Style(CardArt.Display, size, "#6b4426")
            : new TextStyle { Font = CardArt.Display, Size = size, Color = "#ffffff", Shadows = CardArt.Outline3(CardArt.BTN.TryGetValue(kind, out var b) ? b.ring : CardArt.BTN["pink"].ring, 2) };

        /// <summary>An SdButton's ring and face (as ButtonLook.FaceMarkup) holding a row of labels and pictures, centred, 8 dp
        /// apart (the face's gap; a picture's `margin` either side, negative to pull in): (label, kind) or (picture, size).</summary>
        public static string Face(CardArt.ButtonLook look, string faceKind, params (string text, string kind, string picture, float size, float margin)[] parts)
        {
            var c = CardArt.BTN[look.Disabled ? "grey" : CardArt.BTN.ContainsKey(faceKind) ? faceKind : "pink"];
            float fw = look.FaceW, fh = look.FaceH;
            var s = new UiSvg(look.RingW, look.RingH);
            s.Box(0, 0, look.RingW, look.RingH, new BoxStyle { Background = c.ring, Radius = 999 });
            s.Box(2.5f, 2.5f, fw, fh, new BoxStyle { Background = "#ffffff", Radius = 999 });
            float px = 5.5f, py = 5.5f, pw = fw - 6, ph = fh - 6;
            s.Box(px, py, pw, ph, new BoxStyle { Gradient = c.colors, GradientStops = new[] { 0f, 0.5f, 1 }, Radius = 999 });
            var clip = s.NewId("bc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, py, pw, ph, new[] { 996f, 996, 996, 996 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(px + pw * 0.08f, py + 2, pw * 0.84f, ph * 0.42f, new BoxStyle { Background = "rgba(255,255,255,0.45)", Radius = 999 });
            float total = -8;
            foreach (var p in parts) total += 8 + (p.picture != null ? p.size + 2 * p.margin : UiSvg.BoxWidth(p.text, LabelStyle(p.kind, p.size)));
            float x = Card.Snap(px + (pw - total) / 2);
            foreach (var p in parts)
            {
                if (p.picture != null)
                {
                    x += p.margin;
                    s.Image(p.picture, x, py + (ph - p.size) / 2, p.size, p.size, "xMidYMid meet");
                    x += p.size + p.margin + 8;
                }
                else
                {
                    var t = LabelStyle(p.kind, p.size);
                    s.Text(p.text, x, py + (ph - UiSvg.LineBox(t)) / 2, t);
                    x += UiSvg.BoxWidth(p.text, t) + 8;
                }
            }
            s.Close();
            return s.Markup;
        }
    }

    /// <summary>fx.js CountUp in a Text of its own: the number counting up from `delay` over `ms`, centred, at least
    /// `minW` wide.</summary>
    public sealed class CountItem : CardItem
    {
        public readonly CountUp Count;
        readonly TextStyle _style;
        readonly float _minW;
        readonly string _prefix;
        readonly CardLayer _layer;
        int _shown = -1;

        public CountItem(double value, double delay, double ms, TextStyle style, float minW, string prefix = "", int ticks = 10)
        {
            Count = new CountUp(value, ms, delay, ticks);
            _style = style; _minW = minW; _prefix = prefix;
            _layer = Layer("count");
        }

        public override bool IsStatic => false;

        public override void Measure(float colW)
        {
            _shown = -1;
            H = UiSvg.LineBox(_style);
            Sized();
        }

        void Sized()
        {
            if (_shown == Count.Shown && _shown >= 0) return;
            _shown = Count.Shown;
            var t = _prefix + _shown;
            float w = UiSvg.BoxWidth(t, _style);
            W = Math.Max(_minW, w);
            _layer.Set(new UiSvg(W, H).Text(t, 0, 0, _style, W, 0.5f).Markup, W, H, 2);
            if (ColW > 0) X = Card.Snap(ColX + (ColW - W) / 2);
        }

        public override void Mount() { Count.Mount(); _shown = -1; Sized(); }
        public override void Unmount() { base.Unmount(); Count.Unmount(); }
        public override void Place(Affine card, float opacity) { Sized(); base.Place(card, opacity); }
    }

    /// <summary>An FxLayer over a card's column (absolutely placed: it takes no room in the column). `bursts`: (ms after
    /// the card opens, kind, x, y in the column, scale). Put it last in the column; `first` is the column's first item
    /// (where the column starts).</summary>
    public sealed class ColumnFx : CardItem
    {
        readonly CardItem _first;
        readonly (double at, string kind, double x, double y, double scale)[] _plan;
        readonly List<Burst> _bursts = new List<Burst>();
        readonly List<int> _timers = new List<int>();
        Ticker _tk;

        public ColumnFx(CardItem first, params (double at, string kind, double x, double y, double scale)[] plan)
        {
            _first = first; _plan = plan;
            MarginTop = -6;   // (the column's 6 dp gap before it, given back)
        }

        public override bool IsStatic => false;
        public override void Measure(float colW) { W = 0; H = 0; }

        public override void Mount()
        {
            _tk = Ticker.Default;
            foreach (var p in _plan)
            {
                var q = p;
                _timers.Add(_tk.SetTimeout(() =>
                {
                    var b = new Burst(q.kind, q.x, q.y, q.scale);
                    _bursts.Add(b);
                    b.Start(() => { _bursts.Remove(b); Rebuild(); });
                    Rebuild();
                }, q.at));
            }
        }

        public override void Unmount()
        {
            if (_tk != null) foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            foreach (var b in _bursts.ToArray()) b.Stop();
            _bursts.Clear();
            Rebuild();
        }

        void Rebuild() { Layers.Clear(); foreach (var b in _bursts) Layers.AddRange(b.Layers); }

        public override void Place(Affine card, float opacity)
        {
            var col = card * Affine.Translate(ColX, _first.Y - _first.MarginTop);
            foreach (var b in _bursts) b.Place(col, opacity);
        }
    }
}
