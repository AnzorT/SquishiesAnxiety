// Squishdoku's cards over the board (src/squishdoku/Overlays.js), built from the shared card pieces (Ui/Cards):
//   Result   the shared result card (Ui/Cards/GameCards.cs) with Squishdoku's three score creatures (STEP 520 ms apart; an
//            earned one bursts in with rays and gold sparks, a missed one thuds in grey), PERFECT!'s stamp and ×3 coins,
//            then MAP / REPLAY / NEXT ▶
//   TimeUp   the clock ran out, or (hearts) the mistakes did: the shared fail card, MAP / RETRY
//   Pause    the shared pause card: RESUME / QUIT
// Every delay and spring is the app's. The score creatures' slots and the stamp are Squishdoku's own items (Slot,
// Stamp); the rest is the shared kit.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdCards
    {
        public const double STEP = 520;
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

        public static readonly string[] RESULT_TITLES = { "SOLVED!", "NICE ONE!", "SQUISHTASTIC!" };

        /// <summary>The solve, on the shared card: the three score creatures (`pictures`: Resources paths, or null) and on a
        /// perfect solve PERFECT's stamp and ×3 coins; MAP / REPLAY / NEXT ▶. `last`: no NEXT; `keys`: the score creatures' rigs
        /// (the live characters in their place, RegularGame.js keys).</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, string[] pictures, bool last, Action onNext, Action onReplay, Action onMap, string[] keys = null)
        {
            double cAt = CoinsAt(res);
            return GameCards.ResultCard(screenW, screenH,
                new GameCards.Result { Stars = res.Stars, Perfect = res.Perfect, Coins = res.LevelCoins, Xp = res.Xp, Before = res.Before, After = res.After, LevelUps = res.LevelUps },
                RESULT_TITLES, last, onMap, onReplay, onNext, "MAP", "PERFECT SQUISH!",
                score: new SlotsItem(res.Stars, pictures, res.Perfect), scoreTop: res.Perfect, coinsAt: cAt, buttonsAt: 420 + 2 * STEP + 300,
                reward: at => new RewardItem(res.LevelCoins, res.Xp, at, res.Perfect), keys: keys);
        }

        /// <summary>The clock ran out, or (`hearts`, their number) the hearts were all lost. `picture`: the first score
        /// creature's still.</summary>
        public static Card TimeUpCard(float screenW, float screenH, int hearts, string picture, Action onRetry, Action onMap) =>
            GameCards.FailCard(screenW, screenH, hearts > 0 ? "OUT OF HEARTS!" : "TIME'S UP!", hearts > 0 ? 28 : 32, "pink", picture, "#f3e6d4",
                hearts > 0 ? $"{hearts} mistakes. The same board is waiting: think it through and try again!" : "The same board is waiting. Try it again!", "MAP", onMap, onRetry);

        /// <summary>The shared pause card: RESUME / QUIT.</summary>
        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onQuit) => GameCards.PauseCard(screenW, screenH, onResume, onQuit);

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

            readonly int _stars;

            /// <summary>develop's slots: { marginTop 0, marginBottom 2 } (26 with the stamp under them), each Slot 78 (the
            /// middle) or 64, x 0.72 in a column card; their sounds at their moments (ResultCard's timers).</summary>
            public SlotsItem(int stars, string[] pictures, bool perfect)
            {
                _pictures = pictures ?? new string[3];
                _perfect = perfect;
                _stars = stars;
                MarginTop = 0; MarginBottom = perfect ? 26 : 2;
                for (int i = 0; i < 3; i++)
                {
                    var s = new Slot { Earned = i < stars, Big = i == 1, Delay = 420 + i * STEP };
                    Size(s);
                    s.Scale = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? 0 : 1.6, 1 });
                    s.Rotate = Fx.Lerp(new[] { 0.0, 1 }, new[] { s.Earned ? -30.0 : 0, 0 });
                    _slots[i] = s;
                }
            }

            public override bool IsStatic => false;

            string Pic(int i) => i < _pictures.Length ? _pictures[i] : null;

            void Size(Slot s)
            {
                s.S = (float)Math.Round((s.Big ? 78 : 64) * (Compact ? 0.72 : 1), MidpointRounding.AwayFromZero);
                s.Box = s.S + 16;
                s.Mt = Compact ? 0 : s.Big ? -10 : 6;
            }

            public override void Measure(float colW)
            {
                W = 0; H = 0;
                foreach (var s in _slots) Size(s);
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
                    // the stamp: a 3.5 dp red border, 10 x 1 padding, PERFECT! (develop: no NO ✕ · NO MISTAKES line)
                    float tw = UiSvg.BoxWidth("PERFECT!", StampText), l1 = UiSvg.LineBox(StampText);
                    _stampW = tw + 2 * 10 + 7; _stampH = l1 + 2 + 7;
                    var st = new UiSvg(_stampW, _stampH);
                    st.Box(0, 0, _stampW, _stampH, new BoxStyle { Background = "rgba(255,255,255,0.92)", Radius = 10, BorderWidth = 3.5f, BorderColor = "#e01e4a" });
                    st.Text("PERFECT!", 13.5f, 4.5f, StampText, tw, 0.5f);
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
                    int n = Array.IndexOf(_slots, s) + 1;
                    _sounds.Add(_tk.SetTimeout(() => Snd.Play(slot.Earned ? "sd_star" + n : "sd_starEmpty"), s.Delay));
                    s.Timer = _tk.SetTimeout(() =>
                    {
                        if (!slot.Earned) return;
                        var b = new Burst("gold", slot.S / 2 + 8, slot.S / 2 + 8, 1);
                        slot.Bursts.Add(b);
                        b.Start(() => { slot.Bursts.Remove(b); Rebuild(); });
                        Rebuild();
                    }, s.Delay + 60);
                }
                if (_perfect) _sounds.Add(_tk.SetTimeout(() => Snd.Play("sd_perfect"), 420 + 3 * STEP));
                if (_perfect)
                {
                    _stampT.SetValue(0);
                    _stampA = Animated.Timing(_stampT, Fx.Timing(1, 260, Easing.In(Easing.Cubic), 420 + 3 * STEP - 120));
                    _stampA.Start();
                }
            }

            readonly List<int> _sounds = new List<int>();

            public override void Unmount()
            {
                foreach (var id in _sounds) _tk?.ClearTimeout(id);
                _sounds.Clear();
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
