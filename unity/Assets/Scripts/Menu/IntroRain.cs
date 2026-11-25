// The game intro's rain or snow (develop's webgame/app/intro.js rainBuild, WEATHER): on the frame, in front of the
// house (it doesn't move with the camera) and under the captions, only when today's weather is rainy or snowy, falling
// from the night into the morning until the intro hands the screen back. Two layers, far and near, each a band of
// drops (or flakes) repeated down the screen, each row shifted along the drops' slant, slid one band per loop. Every
// number is intro.js's (the drops' places come from its hash; r1 rounds them to a tenth as it does). No UnityEngine
// here: MenuView.Intro.cs shows the layers, the tests (tools/unity/auth-test `rain`) draw them.
using System;
using System.Globalization;
using System.Text;

namespace SquishSquad.Menu
{
    public static class IntroRain
    {
        /// <summary>One layer: its picture (W x H dp, laid at (0, Top)), and its slide: every `LoopMs` it moves
        /// (DX, DY) and starts again.</summary>
        public sealed class Layer
        {
            public string Svg;
            public float W, H, Top, DX, DY;
            public double LoopMs;
            /// <summary>Where the layer is `ms` after the intro started (the slide's linear loop).</summary>
            public (float x, float y) At(double ms) { double p = (ms % LoopMs + LoopMs) % LoopMs / LoopMs; return ((float)(DX * p), (float)(Top + DY * p)); }
        }

        static string R1(double x) => (Math.Floor(x * 10 + 0.5) / 10).ToString("0.#", CultureInfo.InvariantCulture);

        /// <summary>The layers for a w x h dp frame in `weather` (none unless it's rainy or snowy), back to front.</summary>
        public static Layer[] Layers(float w, float h, string weather)
        {
            bool snow = weather == "snowy";
            if (weather != "rainy" && !snow || w <= 0 || h <= 0) return new Layer[0];
            double s = Math.Max(w / 1000.0, h / 460.0);
            double B = Math.Floor(115 * s + 0.5);   // (JS Math.round)
            int rows = (int)Math.Ceiling(h / B) + 1;
            double DX = snow ? 40.0 / 620 : 26.0 / 620;
            var defs = snow ? new[] { (10, 2.6, 0.85, 70.0), (8, 1.8, 0.55, 45.0) } : new[] { (9, 1.4, 0.6, 900.0), (7, 1.1, 0.4, 680.0) };
            var layers = new Layer[defs.Length];
            for (int li = 0; li < defs.Length; li++)
            {
                var (n, sw, op, v) = defs[li];
                var band = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    double H(int k) { double t = Math.Sin((i + li * 50) * 12.9898 + k * 78.233) * 43758.5453; return t - Math.Floor(t); }
                    band.Append('M').Append(R1(H(1) * (w + 60 * s))).Append(' ').Append(R1(H(2) * B));
                    // (a snowflake: a dot, a zero-length round-capped line as wide as the flake)
                    band.Append(snow ? "l0 0.01" : "l" + R1(-4 * s) + " " + R1(16 * s));
                }
                string d = band.ToString();
                var body = new StringBuilder();
                for (int k = 0; k < rows; k++) body.Append($"<path transform=\"translate({R1(-k * B * DX)} {k * B})\" d=\"{d}\"/>");
                float lw = float.Parse(R1(w + 60 * s), CultureInfo.InvariantCulture), lh = (float)(rows * B);
                string svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{R1(lw)}\" height=\"{lh}\" overflow=\"visible\">"
                    + $"<g stroke=\"{(snow ? "#ffffff" : "#c8d6ff")}\" stroke-width=\"{R1(sw * s)}\" stroke-linecap=\"round\" opacity=\"{op.ToString(CultureInfo.InvariantCulture)}\" fill=\"none\">{body}</g></svg>";
                layers[li] = new Layer
                {
                    Svg = svg, W = lw, H = lh, Top = (float)-B,
                    DX = float.Parse(R1(-B * DX), CultureInfo.InvariantCulture), DY = (float)B,
                    LoopMs = Math.Floor(B / (v * s) * 1000 + 0.5),
                };
            }
            return layers;
        }
    }
}
