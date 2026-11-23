// Squishdoku's cards over the board (src/squishdoku/Overlays.js), built from the shared card pieces (Ui/Cards):
//   Result   the solve: the title pops, the three score creatures pop in one by one (STEP 520 ms apart; an earned one
//            bursts in with rays and gold sparks, a missed one thuds in grey), PERFECT!'s stamp slams down, the coins
//            count up (×3 on a PERFECT), the XP bar fills, LEVEL n! and LEVEL n+1 UNLOCKED pop, MAP / REPLAY / NEXT slide in
//   TimeUp   the clock ran out, or (hearts) the mistakes did: the title and the creature's head pop, the head rocks
//   Pause    the clock frozen, the board hidden: RESUME / RESTART / QUIT
// Every delay and spring is the app's. The score creatures' slots and the stamp are Squishdoku's own items (Slot,
// Stamp); the rest is the shared kit.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdCards
    {
        public const double STEP = 520;
        static readonly TextStyle Sub = CardArt.Style(CardArt.Display, 12.5f, "#9a6a3a", 0.6f);
        static readonly TextStyle Unlocked = CardArt.Style(CardArt.Display, 13, "#16a86a", 0.8f);
        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);

        static CardButton Small(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 15, 14, 10), a);
        static CardButton Big(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 18, 22, 12), a);
        static CardButton Wide(string kind, string label, float size, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12), a);

        /// <summary>The result's `res`: { stars, perfect, ms, mistakes, levelCoins, xp, levelUps, before, after, unlocked }.</summary>
        public sealed class Result
        {
            public int Stars, Mistakes, LevelUps;
            public bool Perfect, Unlocked;
            public double Ms, LevelCoins, Xp;
            public XpLevel? Before;
            public XpLevel After;
        }

        public static double CoinsAt(Result res) => 420 + 3 * STEP + (res.Perfect ? 600 : 100);

        /// <summary>The solve. `pictures`: the three score creatures (Resources paths, or null); `last`: no NEXT.</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, int lv, int n, bool head, string[] pictures, bool last, Action onNext, Action onReplay, Action onMap)
        {
            var c = new Card(screenW, screenH);
            double cAt = CoinsAt(res);
            string title = res.Perfect ? "PERFECT SQUISH!" : res.Stars == 3 ? "SQUISHTASTIC!" : res.Stars == 2 ? "NICE ONE!" : "SOLVED!";
            c.Left.Add(new TitleItem(new CardArt.Title(title, res.Perfect ? 26 : 30, res.Perfect ? "gold" : "pink")) { Pop = new PopIn(80) });
            var mis = res.Mistakes > 0 ? $" · {res.Mistakes} MISTAKE{(res.Mistakes > 1 ? "S" : "")}" : "";
            c.Left.Add(new TextItem($"LEVEL {lv} · {n}×{n} · {Levels.Clock(res.Ms)}{mis}{(head ? " · HEAD START" : "")}", Sub));
            c.Left.Add(new SlotsItem(res.Stars, pictures, res.Perfect));
            c.Right.Add(new RewardItem(res.LevelCoins, res.Xp, cAt, res.Perfect) { Slide = new SlideIn(cAt - 150, 20) });
            CardParts.XpGain(c.Right, res.Xp, res.Before, res.After, res.LevelUps, cAt + 500);
            if (res.Unlocked) c.Right.Add(new TextItem($"LEVEL {lv + 1} UNLOCKED", Unlocked) { Pop = new PopIn(cAt + 600) });
            var buttons = new List<CardButton> { Small("white", "MAP", onMap), Small("purple", "REPLAY", onReplay) };
            if (!last) buttons.Add(Big("green", "NEXT ▶", onNext));
            c.Right.Add(new ButtonsItem(false, buttons.ToArray()) { Slide = new SlideIn(420 + 2 * STEP + 300, 30) });
            return c;
        }

        /// <summary>The clock ran out, or (`hearts`, their number) the hearts were all lost. `picture`: the first score
        /// creature's still.</summary>
        public static Card TimeUpCard(float screenW, float screenH, int hearts, string picture, Action onRetry, Action onMap)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title(hearts > 0 ? "OUT OF HEARTS!" : "TIME'S UP!", hearts > 0 ? 28 : 32, "pink")) { Pop = new PopIn(60) });
            c.Left.Add(new HeadItem(86, picture, "#ffffff", "#f3e6d4", true, new Rock(8, 1800)) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem(hearts > 0 ? $"{hearts} mistakes. The same board is waiting: think it through and try again!" : "The same board is waiting. Try it again!", Body, 6));
            c.Right.Add(new ButtonsItem(false, Small("white", "MAP", onMap), Big("pink", "RETRY", onRetry)) { Slide = new SlideIn(380) });
            return c;
        }

        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onRestart, Action onQuit)
        {
            var c = new Card(screenW, screenH) { RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 32, "pink")) { Pop = new PopIn(40) });
            c.Left.Add(new TextItem("The clock is frozen. The board is hidden so no peeking!", Body, 6));
            c.Right.Add(new ButtonsItem(true, Wide("green", "RESUME", 18, onResume), Wide("purple", "RESTART", 16, onRestart), Wide("white", "QUIT", 16, onQuit)));
            return c;
        }

        // ==== Squishdoku's own items ======================================================================================

        /// <summary>Overlays.js's slots row: the three score creatures (Slot: 64, 78, 64 dp heads in boxes 16 dp bigger, the
        /// middle one 10 dp higher), 6 dp below the line above and 22 dp above the next, with PERFECT!'s stamp across their
        /// feet.</summary>
        public sealed class SlotsItem : CardItem
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
            readonly bool _perfect;
            readonly AnimatedValue _stampT = new AnimatedValue(0);
            CompositeAnimation _stampA;
            CardLayer _stamp;
            float _stampW, _stampH;
            static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 0.0, 1, 1 });
            static readonly Interpolator StampOp = Fx.Lerp(new[] { 0, 0.3, 1 }, new[] { 0.0, 1, 1 });
            static readonly Interpolator StampScale = Fx.Lerp(new[] { 0.0, 1 }, new[] { 3.2, 1 });
            static readonly Interpolator StampRot = Fx.Lerp(new[] { 0.0, 1 }, new[] { -30.0, -9 });
            static readonly TextStyle StampText = CardArt.Style(CardArt.Display, 22, "#e01e4a", 2);
            static readonly TextStyle StampSub = CardArt.Style(CardArt.Display, 8.5f, "#e01e4a", 1);
            Ticker _tk;

            public SlotsItem(int stars, string[] pictures, bool perfect)
            {
                _pictures = pictures ?? new string[3];
                _perfect = perfect;
                MarginTop = 6; MarginBottom = 22;
                for (int i = 0; i < 3; i++)
                {
                    var s = new Slot { Earned = i < stars, Big = i == 1, Delay = 420 + i * STEP };
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

            public override void Measure(float colW)
            {
                W = 0; H = 0;
                foreach (var s in _slots) { W += s.Box; H = Math.Max(H, s.Mt + s.Box); }
                float x = 0;
                foreach (var s in _slots) { s.Bx = x; s.By = (H - (s.Mt + s.Box)) / 2 + s.Mt; x += s.Box; }
                for (int i = 0; i < 3; i++)
                {
                    var s = _slots[i];
                    s.Ghost ??= new CardLayer("ghost");
                    s.Ghost.Set(SdArt.Head(s.S, Pic(i), "rgba(255,255,255,0.7)", "rgba(230,200,160,0.35)", true), s.S, s.S, 2);
                    if (s.Earned) (s.Rays ??= new CardLayer("rays")).Set(CardArt.Rays(s.S * 1.9f, opacity: 0.6f, color: "#ffe45c", fadeSize: Fx.LikeWeb ? _slots[0].S * 1.9f : 0), s.S * 1.9f, s.S * 1.9f, 1);
                    s.Head ??= new CardLayer("head");
                    s.Head.Set(s.Earned ? SdArt.Head(s.S, Pic(i), "#ffd23a", "#fffbe6") : SdArt.Head(s.S, Pic(i), "#cfc3dd", "#efe9f5", true), s.S, s.S, 2);
                }
                if (_perfect)
                {
                    // the stamp: a 3.5 dp red border, 10 x 1 padding; PERFECT! over NO ✕ · NO MISTAKES (2 dp up)
                    float tw = Math.Max(UiSvg.BoxWidth("PERFECT!", StampText), UiSvg.BoxWidth("NO ✕ · NO MISTAKES", StampSub));
                    float l1 = UiSvg.LineBox(StampText), l2 = UiSvg.LineBox(StampSub);
                    _stampW = tw + 2 * 10 + 7; _stampH = l1 - 2 + l2 + 2 + 7;
                    var st = new UiSvg(_stampW, _stampH);
                    st.Box(0, 0, _stampW, _stampH, new BoxStyle { Background = "rgba(255,255,255,0.92)", Radius = 10, BorderWidth = 3.5f, BorderColor = "#e01e4a" });
                    st.Text("PERFECT!", 13.5f, 4.5f, StampText, tw, 0.5f);
                    st.Text("NO ✕ · NO MISTAKES", 13.5f, 4.5f + l1 - 2, StampSub, tw, 0.5f);
                    (_stamp ??= new CardLayer("stamp")).Set(st.Markup, _stampW, _stampH, 2);
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
                if (_stamp != null) Layers.Add(_stamp);
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
                if (_perfect)
                {
                    _stampT.SetValue(0);
                    _stampA = Animated.Timing(_stampT, Fx.Timing(1, 260, Easing.In(Easing.Cubic), 420 + 3 * STEP - 120));
                    _stampA.Start();
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
                _stampA?.Stop();
                Rebuild();
            }

            public override void Place(Affine card, float opacity)
            {
                var row = card * Affine.Translate(X, Y);
                foreach (var s in _slots)
                {
                    double t = s.T.GetValue();
                    var box = row * Affine.Translate(s.Bx, s.By);
                    // the ghost and the head are centred in the box; an svg lands on whole dp
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
                if (_stamp != null)
                {
                    double t = _stampT.GetValue(), sc = StampScale.Evaluate(t);
                    // absolute, bottom -18, centred across the row
                    var at = row * Affine.Translate(Card.Snap((W - _stampW) / 2), H + 18 - _stampH);
                    _stamp.Transform = at * Fx.About(_stampW, _stampH, Affine.ScaleBy(sc, sc) * Affine.Rotate(StampRot.Evaluate(t)));
                    _stamp.Opacity = opacity * Clamp01(StampOp.Evaluate(t));
                }
            }

            static float Clamp01(double v) => (float)Math.Max(0, Math.Min(1, v));
        }

        /// <summary>The result's reward row: the coin, the coins counting up (at least 70 dp wide), ×3 on a PERFECT,
        /// "+n XP" (8 dp further).</summary>
        public sealed class RewardItem : CardItem
        {
            public readonly CountUp Count;
            readonly double _xp;
            readonly bool _mult;
            readonly CardLayer _coin, _num, _x3, _xpPlus;
            static readonly TextStyle CoinsText = CardArt.Style(CardArt.Display, 28, "#b86200");
            static readonly TextStyle MultText = CardArt.Style(CardArt.Display, 16, "#e01e4a");
            static readonly TextStyle XpPlusText = CardArt.Style(CardArt.Display, 16, "#b8641c");
            int _shown = -1;
            float _numW, _xpW, _multW;

            public RewardItem(double coins, double xp, double countDelay, bool mult)
            {
                _xp = xp; _mult = mult;
                Count = new CountUp(coins, 800, countDelay);
                _coin = Layer("coin");
                _num = Layer("coins");
                if (mult) _x3 = Layer("x3");
                if (xp != 0) _xpPlus = Layer("xp plus");
            }

            public override bool IsStatic => false;

            public override void Measure(float colW)
            {
                _coin.Set(Card.LoadXml("coin"), 26, 26, 2);
                if (_x3 != null)
                {
                    _multW = UiSvg.BoxWidth("×3", MultText);
                    _x3.Set(new UiSvg(_multW, UiSvg.LineBox(MultText)).Text("×3", 0, 0, MultText).Markup, _multW, UiSvg.LineBox(MultText));
                }
                if (_xpPlus != null)
                {
                    var t = "+" + _xp.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) + " XP";
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
                W = 26 + 6 + _numW + (_x3 != null ? 6 + _multW : 0) + (_xpPlus != null ? 6 + 8 + _xpW : 0);
                H = Math.Max(26, lh);
                if (ColW > 0) X = Card.Snap(ColX + (ColW - W) / 2);
            }

            public override void Mount() { Count.Mount(); _shown = -1; Sized(); }
            public override void Unmount() { base.Unmount(); Count.Unmount(); }

            public override void Place(Affine card, float opacity)
            {
                Sized();
                var (m, o) = Box(card, opacity);
                var (cx, cy) = ToWhole(X, Y + (H - 26) / 2);
                _coin.Transform = m * Affine.Translate(cx, (H - 26) / 2 + cy);
                _num.Transform = m * Affine.Translate(32, (H - _num.H) / 2);
                float x = 32 + _numW + 6;
                if (_x3 != null) { _x3.Transform = m * Affine.Translate(x, (H - _x3.H) / 2); x += _multW + 6; }
                if (_xpPlus != null) _xpPlus.Transform = m * Affine.Translate(x + 8, (H - _xpPlus.H) / 2);
                foreach (var l in Layers) l.Opacity = o;
            }
        }
    }
}
