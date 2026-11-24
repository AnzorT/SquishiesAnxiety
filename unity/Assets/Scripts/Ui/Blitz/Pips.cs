// A Blitz run's pips (src/squishdoku/Hud.js Pips, Squish Stack's and Squish Sort's Blitz): one numbered circle per
// round, the done ones filled cyan (each springing in as it fills: friction 4, tension 180), the current one pulsing gold
// (a straight 0 → 1 → 0 every second); emptied right to left (`Done` back to 0: friction 7, 50 ms apart from the
// right) when the run goes back to round 1. `small`: landscape's narrow left column (17 dp pips 2.5 apart, not 24 and 5).
//   var pips = new Pips(10, small);  pips.SetDone(3);  pips.Current = 3;
//   each frame: pips.Place(x, y) (the row's top-left); draw pips.Layers.  Size: pips.W x pips.H.
// No UnityEngine here.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Blitz
{
    public sealed class Pips
    {
        public readonly int Count;
        public readonly bool Small;
        /// <summary>The pip that pulses (-1: none, once the run's over).</summary>
        public int Current = -1;
        public int Done { get; private set; }
        public readonly List<CardLayer> Layers = new List<CardLayer>();
        public float W => Count * D + (Count - 1) * Gap;
        public float H => D;

        readonly float D, Gap, Border;
        readonly AnimatedValue[] _v;
        readonly CompositeAnimation[] _a;
        readonly KeyLoop _now;
        readonly CardLayer[] _base, _fill, _num;
        readonly CardLayer _pulse = new CardLayer("pip now");
        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        public Pips(int count = 10, bool small = false)
        {
            Count = count; Small = small;
            D = small ? 17 : 24; Gap = small ? 2.5f : 5; Border = small ? 2 : 2.5f;
            _v = new AnimatedValue[count]; _a = new CompositeAnimation[count];
            _base = new CardLayer[count]; _fill = new CardLayer[count]; _num = new CardLayer[count];
            float inner = D - 2 * Border;
            var txt = new TextStyle { Font = CardArt.Display, Size = small ? 8.5f : 10.5f, Color = "#ffffff" };
            for (int i = 0; i < count; i++)
            {
                _v[i] = new AnimatedValue(0);
                _base[i] = new CardLayer("pip");
                _base[i].Set(new UiSvg(D, D).Box(0, 0, D, D, new BoxStyle { Background = "rgba(91,52,24,0.3)", Radius = D / 2, BorderWidth = Border, BorderColor = "#ffffff" }).Markup, D, D, 1);
                _fill[i] = new CardLayer("pip fill");
                _fill[i].Set(new UiSvg(inner, inner).Box(0, 0, inner, inner, new BoxStyle { Background = "#3fd7f6", Radius = 12 }).Markup, inner, inner, 1);
                var label = (i + 1).ToString(CultureInfo.InvariantCulture);
                _num[i] = new CardLayer("pip number");
                _num[i].Set(new UiSvg(inner, inner).Text(label, 0, (inner - UiSvg.LineBox(txt)) / 2, txt, inner, 0.5f).Markup, inner, inner, 2);
            }
            _pulse.Set(new UiSvg(inner, inner).Box(0, 0, inner, inner, new BoxStyle { Background = "#ffd23a", Radius = 12 }).Markup, inner, inner, 1);
            _now = new KeyLoop(1000, KeyLoop.PHASE, TRIANGLE);
        }

        /// <summary>Starts the current pip's pulse (when the pips mount).</summary>
        public void Mount() => _now.Mount();
        public void Unmount() { _now.Unmount(); foreach (var a in _a) a?.Stop(); }

        /// <summary>`done` pips filled: those that change spring there (Hud.js's effect on `done`).</summary>
        public void SetDone(int done)
        {
            if (done == Done) return;
            Done = done;
            for (int i = 0; i < Count; i++)
            {
                bool on = i < done;
                _a[i]?.Stop();
                _a[i] = Animated.Spring(_v[i], Fx.Spring(on ? 1 : 0, on ? 4 : 7, 180, on ? 0 : (Count - i) * 50));
                _a[i].Start();
            }
        }

        /// <summary>Places the row with its top-left at (x, y) under `parent`.</summary>
        public void Place(float x, float y) => Place(Affine.Identity, x, y, 1);

        public void Place(Affine parent, float x, float y, float opacity)
        {
            Layers.Clear();
            for (int i = 0; i < Count; i++)
            {
                var at = parent * Affine.Translate(x + i * (D + Gap), y);
                _base[i].Transform = at; _base[i].Opacity = opacity;
                Layers.Add(_base[i]);
                double v = _v[i].GetValue(), k = 0.3 + 0.7 * v;
                float inner = D - 2 * Border;
                var inside = at * Affine.Translate(Border, Border);
                _fill[i].Transform = inside * Fx.About(inner, inner, Affine.ScaleBy(k, k));
                _fill[i].Opacity = (float)Math.Max(0, Math.Min(1, v)) * opacity;
                if (_fill[i].Opacity > 0) Layers.Add(_fill[i]);
                if (i == Current)
                {
                    _pulse.Transform = inside;
                    _pulse.Opacity = (float)_now.Value * opacity;
                    if (_pulse.Opacity > 0) Layers.Add(_pulse);
                }
                _num[i].Transform = inside; _num[i].Opacity = opacity;
                Layers.Add(_num[i]);
            }
        }
    }
}
