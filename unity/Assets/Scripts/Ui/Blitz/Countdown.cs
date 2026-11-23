// The big 3, 2, 1, GO! of a Blitz run (src/squishdoku/BlitzGame.js Countdown, Squish Stack's Blitz too): each number
// slams in (2.6x and turned -15° down to 1 in the first fifth) and swells away (GO! to 1.5x, the numbers to 0.8x),
// fading in over the first 15% and out after 70%, 650 ms, ease-out cubic, started again whenever the value changes.
// Fredoka 110 white on a blue drop (GO!: 96, gold on brown), centred in its area (the board's).
//   var cd = new Countdown();  cd.Set("3") ... cd.Set("GO!") ... cd.Set(null);
//   each frame: cd.Place(areaX, areaY, areaW, areaH); draw cd.Layers
// No UnityEngine here.
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Blitz
{
    public sealed class Countdown
    {
        static readonly TextStyle Num = new TextStyle { Font = "Fredoka_700Bold", Size = 110, Color = "#ffffff", Shadows = new[] { new Shadow("#0c5a9c", 0, 7, 1) } };
        static readonly TextStyle Go = new TextStyle { Font = "Fredoka_700Bold", Size = 96, Color = "#ffd23a", Shadows = new[] { new Shadow("#9c4d06", 0, 7, 1) } };
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.15, 0.7, 1 }, new[] { 0.0, 1, 1, 0 });
        static readonly Interpolator Rot = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { -15.0, 0, 0 });
        static readonly Interpolator ScaleNum = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 2.6, 1, 0.8 });
        static readonly Interpolator ScaleGo = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 2.6, 1, 1.5 });

        readonly AnimatedValue _t = new AnimatedValue(0);
        readonly CardLayer _layer = new CardLayer("countdown");
        CompositeAnimation _a;
        float _w, _h;

        /// <summary>What it shows ("3", "2", "1", "GO!"), or null when it's gone.</summary>
        public string Value { get; private set; }
        public readonly List<CardLayer> Layers = new List<CardLayer>();

        /// <summary>Shows `value` (a new one slams in), or nothing (null). Call when the app's `count` state changes, from the
        /// frame its render lands on.</summary>
        public void Set(string value)
        {
            if (value == Value) return;
            Value = value;
            Layers.Clear();
            _a?.Stop();
            if (value == null) return;
            var st = value == "GO!" ? Go : Num;
            _w = UiSvg.BoxWidth(value, st);
            _h = UiSvg.LineBox(st);
            _layer.Set(new UiSvg(_w, _h).Text(value, 0, 0, st).Markup, _w, _h, 12);
            Layers.Add(_layer);
            _t.SetValue(0);
            _a = Animated.Timing(_t, Fx.Timing(1, 650, Easing.Out(Easing.Cubic)));
            _a.Start();
        }

        /// <summary>Centres it in the area (x, y, w, h; screen dp), under `parent` (the area's own transform, or identity).</summary>
        public void Place(float x, float y, float w, float h) => Place(Affine.Identity, x, y, w, h);

        public void Place(Affine parent, float x, float y, float w, float h)
        {
            if (Value == null) return;
            double t = _t.GetValue(), s = (Value == "GO!" ? ScaleGo : ScaleNum).Evaluate(t);
            _layer.Transform = parent * Affine.Translate(Card.Snap(x + (w - _w) / 2), Card.Snap(y + (h - _h) / 2)) * Fx.About(_w, _h, Affine.ScaleBy(s, s) * Affine.Rotate(Rot.Evaluate(t)));
            _layer.Opacity = (float)Op.Evaluate(t);
        }
    }
}
