// A card a host can show whichever layout it has: Ui/Cards' Card (two columns, what comes before <Split />, the rest)
// through CardView, or a BroadCard (one column, as wide as a two-column card: src/squishdoku/Overlays.js Overlay
// `broad`, Blitz's save card and GAME OVER in landscape). Same surface as Card, so a game keeps one list of them.
// No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Blitz
{
    public interface ICardView
    {
        /// <summary>On screen (also while closing).</summary>
        bool Shown { get; }
        /// <summary>Open: takes every tap on the screen.</summary>
        bool Visible { get; }
        void Show();
        void Hide(bool emptied = false);
        void Update();
        IEnumerable<CardLayer> Layers();
        IEnumerable<CardButton> Buttons { get; }
        bool Down(float x, float y);
        bool Up(float x, float y);
    }

    /// <summary>A Ui/Cards Card as an ICardView.</summary>
    public sealed class CardView : ICardView
    {
        public readonly Card Card;
        public CardView(Card card) { Card = card; }
        public bool Shown => Card.Shown;
        public bool Visible => Card.Visible;
        public void Show() => Card.Show();
        public void Hide(bool emptied = false) => Card.Hide(emptied);
        public void Update() => Card.Update();
        public IEnumerable<CardLayer> Layers() => Card.Layers();
        public IEnumerable<CardButton> Buttons => Card.Buttons;
        public bool Down(float x, float y) => Card.Down(x, y);
        public bool Up(float x, float y) => Card.Up(x, y);
        public static implicit operator CardView(Card c) => new CardView(c);
    }

    /// <summary>Overlay `broad` in landscape: the card springs up as Card's does (friction 6.5, tension 90; out in 180 ms),
    /// maxWidth 660, one column of items centred across (the fill 16 dp in at the sides, 12 above and below, 6 between).
    /// An item as wide as the column (alignSelf stretch) sets its W to the column's.</summary>
    public sealed class BroadCard : ICardView
    {
        public readonly List<CardItem> Items = new List<CardItem>();
        public string Tint = "rgba(50,24,6,0.55)";
        public bool RetriggerOnHide;

        readonly float _sw, _sh;
        readonly CardLayer _scrim = new CardLayer("scrim"), _frame = new CardLayer("card");
        readonly AnimatedValue _t = new AnimatedValue(0);
        CompositeAnimation _anim;
        bool _empty;
        CardButton _pressed;

        public bool Shown { get; private set; }
        public bool Visible { get; private set; }
        public float CardX { get; private set; }
        public float CardY { get; private set; }
        public float CardW { get; private set; }
        public float CardH { get; private set; }
        public float ColW { get; private set; }
        public Affine CardTransform { get; private set; } = Affine.Identity;

        static readonly Interpolator ScrimOp = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.0, 1 }, true);
        static readonly Interpolator CardOp = Fx.Lerp(new[] { 0, 0.3, 1 }, new[] { 0.0, 1, 1 }, true);
        static readonly Interpolator Rise = Fx.Lerp(new[] { 0.0, 1 }, new[] { 120.0, 0 });
        static readonly Interpolator Grow = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.7, 1 });

        public BroadCard(float screenW, float screenH) { _sw = screenW; _sh = screenH; }

        public BroadCard Add(CardItem item) { Items.Add(item); return this; }

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

        const float Gap = 6;

        void Layout()
        {
            float avail = _sw - 20;
            float fillH;
            if (_empty) { CardW = Math.Min(avail, 380); fillH = 24; }
            else
            {
                CardW = Math.Min(avail, 660);
                ColW = CardW - 12 - 32;
                float h = 0;
                for (int i = 0; i < Items.Count; i++)
                {
                    Items[i].Measure(ColW);
                    h += Items[i].MarginTop + Items[i].H + Items[i].MarginBottom + (i > 0 ? Gap : 0);
                }
                fillH = h + 24;
                float y = 18;
                foreach (var it in Items)
                {
                    y += it.MarginTop;
                    it.ColX = 22; it.ColW = ColW;
                    it.X = Card.Snap(22 + (ColW - it.W) / 2);
                    it.Y = y;
                    y += it.H + it.MarginBottom + Gap;
                }
            }
            CardH = fillH + 17;
            CardX = Card.Snap(10 + (avail - CardW) / 2);
            CardY = Card.Snap(10 + (_sh - 20 - CardH) / 2);
            foreach (var i in Items) { i.OX = CardX; i.OY = CardY; i.Snapped(); }
            var s = new UiSvg(CardW, CardH);
            float fx = Card.Whole(CardX) - CardX, fy = Card.Whole(CardY) - CardY;
            if (fx != 0 || fy != 0) s.Open($"transform=\"translate({UiSvg.F(fx)} {UiSvg.F(fy)})\"");
            CardArt.Frame(s, CardW, fillH);
            if (fx != 0 || fy != 0) s.Close();
            if (!_empty) foreach (var i in Items) if (i.IsStatic) i.DrawStatic(s);
            _frame.Set(s.Markup, CardW, CardH, 4);
            _scrim.Set(new UiSvg(_sw, _sh).Box(0, 0, _sw, _sh, new BoxStyle { Background = Tint }).Markup, _sw, _sh, 0);
        }

        /// <summary>Lays it out again (an item changed size: a button's label, an error line).</summary>
        public void Relayout() { if (Shown && !_empty) Layout(); }

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

        public IEnumerable<CardLayer> Layers()
        {
            if (!Shown) yield break;
            yield return _scrim;
            yield return _frame;
            if (_empty) yield break;
            foreach (var i in Items) foreach (var l in i.Layers) yield return l;
        }

        public IEnumerable<CardButton> Buttons { get { foreach (var i in Items) foreach (var b in i.Buttons) yield return b; } }

        public bool Down(float x, float y)
        {
            if (!Visible) return false;
            foreach (var b in Buttons)
                if (b.Enabled && b.Hit(x, y)) { _pressed = b; b.Press.Down(); break; }
            return true;
        }

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
}
