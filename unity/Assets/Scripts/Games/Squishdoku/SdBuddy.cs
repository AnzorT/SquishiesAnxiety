// The buddy under or beside the board (src/squishdoku/Buddy.js): the creature picked in the Lobby, `size` dp, on a soft
// floor shadow; it hops at a right creature (higher on a streak, highest at a solve), shakes at a mistake or the clock,
// and says a word in a bubble for most moments (1100 ms). Its still stands in for the app's live rig (which takes over
// after 700 ms there). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdBuddy
    {
        public readonly float Size;
        readonly SdCreature _c;
        readonly Ticker _tk;
        readonly SdLayer _floor, _body, _bubbleL;
        readonly AnimatedValue _jump = new AnimatedValue(0), _shake = new AnimatedValue(0), _bubble = new AnimatedValue(0);
        int _hideTimer = -1;
        bool _bad;
        float _bw, _bh;

        static readonly Dictionary<string, string[]> SAY = new Dictionary<string, string[]>
        {
            ["start"] = new[] { "Let's go!", "You got this!", "Squish time!" },
            ["right"] = new[] { "Yay!", "Nice!", "Squishy!", "Woo!", "Yes!" },
            ["streak"] = new[] { "On fire!", "Unstoppable!", "So good!" },
            ["wrong"] = new[] { "Oops!", "Uh-oh!", "Not there!", "Hmm…" },
            ["hurry"] = new[] { "Hurry!", "Quick quick!" },
            ["solve"] = new[] { "We did it!", "Squishtastic!", "Hooray!" },
            ["timeup"] = new[] { "Aww…", "So close!" },
        };

        public SdBuddy(SdCreature c, float size, Ticker tk)
        {
            _c = c; Size = size; _tk = tk;
            _floor = new SdLayer("buddy floor").Set(new Ui.UiSvg(size * 0.62f, size * 0.1f).Box(0, 0, size * 0.62f, size * 0.1f, new Ui.BoxStyle { Background = "rgba(69,16,122,0.2)", Radius = 999 }).Markup, size * 0.62f, size * 0.1f, 1);
            _body = new SdLayer("buddy");
            if (c != null)
            {
                float w = size, h = size;
                if (c.Ar >= 1) w = h / c.Ar; else h = w * c.Ar;
                _body.SetPicture(c.Picture, w, h);
            }
            _bubbleL = new SdLayer("bubble");
        }

        public void React(string kind, int n = 0)
        {
            var k = kind == "right" && n >= 3 ? "streak" : kind;
            if (k == "wrong" || k == "timeup")
            {
                _shake.SetValue(0);
                var vs = new[] { 1, -1, 0.8, -0.8, 0.4, 0 };
                var a = new CompositeAnimation[vs.Length];
                for (int i = 0; i < vs.Length; i++) a[i] = Animated.Timing(_shake, new TimingConfig { ToValue = vs[i], Duration = 55, UseNativeDriver = true });
                Animated.Sequence(a).Start();
            }
            else
            {
                double height = k == "solve" ? 1 : k == "streak" ? 0.8 : 0.5;
                _jump.SetValue(0);
                Animated.Sequence(
                    Animated.Timing(_jump, new TimingConfig { ToValue = height, Duration = 180, Easing = Easing.Out(Easing.Quad), UseNativeDriver = true }),
                    Animated.Timing(_jump, new TimingConfig { ToValue = 0, Duration = 220, Easing = Easing.Bounce, UseNativeDriver = true })).Start();
            }
            if (k != "right" || SdLevel.Random() < 0.55)
            {
                var list = SAY[k];
                Speak(list[(int)Math.Floor(SdLevel.Random() * list.Length)], k == "wrong" || k == "timeup");
            }
        }

        void Speak(string text, bool bad)
        {
            var (svg, w, h) = SdArt.Bubble(text, bad);
            _bubbleL.Set(svg, w, h + 7, 3);
            _bw = w; _bh = h; _bad = bad;
            _bubble.SetValue(0);
            Animated.Spring(_bubble, Fx.Spring(1, 5, 180)).Start();
            _tk.ClearTimeout(_hideTimer);
            _hideTimer = _tk.SetTimeout(() => Animated.Timing(_bubble, new TimingConfig { ToValue = 0, Duration = 180, UseNativeDriver = true }).Start(), 1100);
        }

        public void Unmount() => _tk.ClearTimeout(_hideTimer);

        /// <summary>Its layers with its box's top-left at (x, y).</summary>
        public void Layers(float x, float y, List<SdLayer> o, float opacity = 1)
        {
            _floor.Transform = Affine.Translate(x + Size * 0.19f, y + Size - 2 - Size * 0.1f);
            _floor.Opacity = opacity;
            o.Add(_floor);
            if (_c != null)
            {
                double jy = -Size * 0.32 * _jump.GetValue(), sx = Size * 0.08 * _shake.GetValue();
                _body.Transform = Affine.Translate(x + (Size - _body.W) / 2 + sx, y + (Size - _body.H) / 2 + jy);
                _body.Opacity = opacity;
                o.Add(_body);
            }
            double bub = _bubble.GetValue();
            if (_bubbleL.Markup != null && bub > 0)
            {
                double k = 0.4 + 0.6 * bub;
                _bubbleL.Transform = Affine.Translate(x + Card.Snap((Size - _bw) / 2), y + Size - Size * 0.86 - _bh)
                    * Fx.About(_bw, _bh, Affine.ScaleBy(k, k) * Affine.Rotate(_bad ? 4 : -4));
                _bubbleL.Opacity = (float)Math.Min(1, bub) * opacity;
                o.Add(_bubbleL);
            }
        }
    }
}
