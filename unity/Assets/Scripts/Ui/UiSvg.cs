// Builds the SVG for a piece of UI made in Unity (a pill with a number in it, a goal card), drawn the way the UI
// exporter (tools/unity/ui/snap.js) writes what Chrome painted, so pieces made here look like the exported ones:
// rounded boxes (CSS radii), a background colour or linear-gradient, borders, box shadows, text from the app's fonts
// (UiFont) with Chrome's baseline rule, pictures, and the app's own SVG drawings as they are. Units are dp.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Ui
{
    public struct Shadow
    {
        public string Color; public float X, Y, Blur, Spread;
        public Shadow(string color, float x, float y, float blur, float spread = 0) { Color = color; X = x; Y = y; Blur = blur; Spread = spread; }
    }

    public sealed class BoxStyle
    {
        public string Background;                 // a CSS colour, or null
        public string[] Gradient;                 // linear-gradient colours top to bottom (evenly spaced), or null
        public float[] GradientStops;             // their offsets 0..1 (default: even)
        public float GradientAngle = 180;         // CSS degrees (180 = to bottom)
        public float Radius;                      // all corners, or Radii
        public float[] Radii;                     // top-left, top-right, bottom-right, bottom-left
        public float BorderWidth;                 // all sides, or Borders
        public float[] Borders;                   // top, right, bottom, left
        public string BorderColor;
        public bool Dashed;
        public Shadow[] Shadows;
        public float Opacity = 1;
    }

    public sealed class TextStyle
    {
        public string Font = "Fredoka_700Bold";
        public float Size = 14;
        public string Color = "#000";
        public float LetterSpacing;
        public float LineHeight;                  // 0: "normal"
        public Shadow[] Shadows;                  // CSS text-shadow, drawn under the text in order (the first on top)
        public float Opacity = 1;
    }

    public sealed class UiSvg
    {
        public readonly float W, H;
        readonly StringBuilder _defs = new StringBuilder(), _body = new StringBuilder();
        readonly Dictionary<string, string> _glyphs = new Dictionary<string, string>();
        int _ids;

        public UiSvg(float w, float h) { W = w; H = h; }

        public string Markup => $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(W)}\" height=\"{F(H)}\" viewBox=\"0 0 {F(W)} {F(H)}\" overflow=\"visible\"><defs>{_defs}</defs>{_body}</svg>";

        public UiSvg Raw(string svg) { _body.Append(svg); return this; }
        public UiSvg Def(string svg) { _defs.Append(svg); return this; }
        public string NewId(string prefix) => prefix + (_ids++);
        public UiSvg Open(string attrs) { _body.Append("<g ").Append(attrs).Append('>'); return this; }
        public UiSvg Close() { _body.Append("</g>"); return this; }

        // ---- boxes ---------------------------------------------------------------------------------------------------
        public UiSvg Box(float x, float y, float w, float h, BoxStyle s)
        {
            var r = s.Radii ?? new[] { s.Radius, s.Radius, s.Radius, s.Radius };
            var bw = s.Borders ?? new[] { s.BorderWidth, s.BorderWidth, s.BorderWidth, s.BorderWidth };
            var outer = RRect(x, y, w, h, r);
            if (outer.Length == 0) return this;
            if (s.Opacity < 1) Open($"opacity=\"{F(s.Opacity)}\"");
            if (s.Shadows != null)
                for (int i = s.Shadows.Length - 1; i >= 0; i--)
                {
                    var sh = s.Shadows[i];
                    var sp = RRect(x + sh.X - sh.Spread, y + sh.Y - sh.Spread, w + 2 * sh.Spread, h + 2 * sh.Spread, Array.ConvertAll(r, v => v > 0 ? v + sh.Spread : 0));
                    string f = "";
                    if (sh.Blur > 0)
                    {
                        var id = NewId("bs");
                        _defs.Append($"<filter id=\"{id}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"{F(sh.Blur / 2)}\"/></filter>");
                        f = $" filter=\"url(#{id})\"";
                    }
                    _body.Append($"<path d=\"{sp}\" fill=\"{sh.Color}\"{f}/>");
                }
            if (s.Background != null) _body.Append($"<path d=\"{outer}\" fill=\"{s.Background}\"/>");
            if (s.Gradient != null && s.Gradient.Length > 0)
            {
                double a = s.GradientAngle * Math.PI / 180, len = Math.Abs(w * Math.Sin(a)) + Math.Abs(h * Math.Cos(a));
                double cx = x + w / 2.0, cy = y + h / 2.0, dx = Math.Sin(a) * len / 2, dy = -Math.Cos(a) * len / 2;
                var id = NewId("lg");
                _defs.Append($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"{F(cx - dx)}\" y1=\"{F(cy - dy)}\" x2=\"{F(cx + dx)}\" y2=\"{F(cy + dy)}\">");
                for (int i = 0; i < s.Gradient.Length; i++)
                {
                    float off = s.GradientStops != null ? s.GradientStops[i] : s.Gradient.Length == 1 ? 0 : (float)i / (s.Gradient.Length - 1);
                    _defs.Append($"<stop offset=\"{F(off)}\" stop-color=\"{s.Gradient[i]}\"/>");
                }
                _defs.Append("</linearGradient>");
                _body.Append($"<path d=\"{outer}\" fill=\"url(#{id})\"/>");
            }
            if (s.BorderColor != null && (bw[0] > 0 || bw[1] > 0 || bw[2] > 0 || bw[3] > 0))
            {
                if (s.Dashed)
                {
                    float t = Math.Max(Math.Max(bw[0], bw[1]), Math.Max(bw[2], bw[3]));
                    var mid = RRect(x + t / 2, y + t / 2, w - t, h - t, Array.ConvertAll(r, v => Math.Max(0, v - t / 2)));
                    _body.Append($"<path d=\"{mid}\" fill=\"none\" stroke=\"{s.BorderColor}\" stroke-width=\"{F(t)}\" stroke-dasharray=\"{F(t * 3)} {F(t * 3)}\"/>");
                }
                else
                {
                    var inR = new[] { Math.Max(0, r[0] - Math.Max(bw[3], bw[0])), Math.Max(0, r[1] - Math.Max(bw[0], bw[1])), Math.Max(0, r[2] - Math.Max(bw[1], bw[2])), Math.Max(0, r[3] - Math.Max(bw[2], bw[3])) };
                    var ring = outer + " " + RRect(x + bw[3], y + bw[0], w - bw[1] - bw[3], h - bw[0] - bw[2], inR);
                    _body.Append($"<path d=\"{ring}\" fill-rule=\"evenodd\" fill=\"{s.BorderColor}\"/>");
                }
            }
            if (s.Opacity < 1) Close();
            return this;
        }

        // ---- text ----------------------------------------------------------------------------------------------------
        /// <summary>Where Chrome puts a line's baseline in a text box whose content starts at `top`.</summary>
        public static float Baseline(TextStyle t, float top)
        {
            var f = UiFont.Get(t.Font);
            float k = t.Size / f.UnitsPerEm;
            float asc = (float)Math.Round(f.Ascender * k), desc = (float)Math.Round(-f.Descender * k);
            float half = t.LineHeight > 0 ? (float)Math.Floor((t.LineHeight - asc - desc) / 2) : 0;
            return top + half + asc;
        }

        /// <summary>A line's height as Chrome lays it out: lineHeight, or (normal) the font's rounded ascent + descent + gap.</summary>
        public static float LineBox(TextStyle t)
        {
            if (t.LineHeight > 0) return t.LineHeight;
            var f = UiFont.Get(t.Font);
            float k = t.Size / f.UnitsPerEm;
            return (float)(Math.Round(f.Ascender * k) + Math.Round(-f.Descender * k));
        }

        public static float Width(string text, TextStyle t)
        {
            UiFont.Get(t.Font).Layout(text, t.Size, t.LetterSpacing, out var w);
            return w;
        }

        /// <summary>The width of the box Chrome gives a line of text (what centres it, what a row of them adds up to).</summary>
        public static float BoxWidth(string text, TextStyle t) => UiFont.Get(t.Font).BoxWidth(text, t.Size, t.LetterSpacing);

        /// <summary>A line of text with its box's top-left at (x, top); `align` 0 left, 0.5 centre, 1 right of `boxW`.</summary>
        public UiSvg Text(string text, float x, float top, TextStyle t, float boxW = 0, float align = 0)
        {
            if (string.IsNullOrEmpty(text)) return this;
            var f = UiFont.Get(t.Font);
            float w = Width(text, t);
            float x0 = x + (boxW - w) * align;
            if (align > 0) x0 = Snap(x0);
            float y = Baseline(t, top);
            if (t.Opacity < 1) Open($"opacity=\"{F(t.Opacity)}\"");
            if (t.Shadows != null)
                for (int i = t.Shadows.Length - 1; i >= 0; i--)
                {
                    var sh = t.Shadows[i];
                    string extra = "";
                    if (sh.Blur > 0)
                    {
                        var id = NewId("ts");
                        _defs.Append($"<filter id=\"{id}\" x=\"-20%\" y=\"-20%\" width=\"140%\" height=\"140%\"><feGaussianBlur stdDeviation=\"{F(sh.Blur / 2)}\"/></filter>");
                        extra = $" filter=\"url(#{id})\"";
                    }
                    if (extra.Length > 0) Open(extra.Trim());
                    _body.Append(f.Svg(text, x0 + sh.X, y + sh.Y, t.Size, t.LetterSpacing, sh.Color, _defs, _glyphs));
                    if (extra.Length > 0) Close();
                }
            _body.Append(f.Svg(text, x0, y, t.Size, t.LetterSpacing, t.Color, _defs, _glyphs));
            if (t.Opacity < 1) Close();
            return this;
        }

        /// <summary>A run of glyphs with its first pen at (x, baseline) (SVG text's layout: no box, no alignment), filled
        /// with `fill`; `attrs` (a stroke, say) go on a group round it, in the glyphs' own units (1/unitsPerEm of the size).</summary>
        public UiSvg Glyphs(string text, float x, float baseline, string font, float size, float letterSpacing, string fill, string attrs = null)
        {
            var g = UiFont.Get(font).Svg(text, x, baseline, size, letterSpacing, fill, _defs, _glyphs);
            if (attrs != null) _body.Append("<g ").Append(attrs).Append('>').Append(g).Append("</g>");
            else _body.Append(g);
            return this;
        }

        // ---- pictures and drawings --------------------------------------------------------------------------------------
        public UiSvg Image(string href, float x, float y, float w, float h, string preserveAspectRatio = "none", float opacity = 1)
        {
            _body.Append($"<image href=\"{href}\" x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" preserveAspectRatio=\"{preserveAspectRatio}\"{(opacity < 1 ? $" opacity=\"{F(opacity)}\"" : "")}/>");
            return this;
        }

        /// <summary>An &lt;svg&gt; drawing (inner markup, its own viewBox) in the box x, y, w, h.</summary>
        public UiSvg Drawing(string inner, float x, float y, float w, float h, string viewBox = null)
        {
            _body.Append($"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"{viewBox ?? $"0 0 {F(w)} {F(h)}"}\" overflow=\"visible\">{inner}</svg>");
            return this;
        }

        // ---- the exporter's rounded rect (CSS: radii scaled down together when they don't fit) -------------------------
        public static string RRect(float x, float y, float w, float h, float[] radii)
        {
            if (w <= 0 || h <= 0) return "";
            float tl = Math.Max(0, radii[0]), tr = Math.Max(0, radii[1]), br = Math.Max(0, radii[2]), bl = Math.Max(0, radii[3]);
            float f = Math.Min(1, Math.Min(Math.Min(w / Nz(tl + tr), w / Nz(bl + br)), Math.Min(h / Nz(tl + bl), h / Nz(tr + br))));
            if (f < 1) { tl *= f; tr *= f; br *= f; bl *= f; }
            const float k = 0.5522847498f;
            var p = new StringBuilder();
            p.Append($"M{F(x + tl)} {F(y)} H{F(x + w - tr)}");
            if (tr > 0) p.Append($" C{F(x + w - tr + tr * k)} {F(y)} {F(x + w)} {F(y + tr - tr * k)} {F(x + w)} {F(y + tr)}");
            p.Append($" V{F(y + h - br)}");
            if (br > 0) p.Append($" C{F(x + w)} {F(y + h - br + br * k)} {F(x + w - br + br * k)} {F(y + h)} {F(x + w - br)} {F(y + h)}");
            p.Append($" H{F(x + bl)}");
            if (bl > 0) p.Append($" C{F(x + bl - bl * k)} {F(y + h)} {F(x)} {F(y + h - bl + bl * k)} {F(x)} {F(y + h - bl)}");
            p.Append($" V{F(y + tl)}");
            if (tl > 0) p.Append($" C{F(x)} {F(y + tl - tl * k)} {F(x + tl - tl * k)} {F(y)} {F(x + tl)} {F(y)}");
            p.Append(" Z");
            return p.ToString();
        }

        static float Nz(float v) => v == 0 ? 1 : v;
        static float Snap(float v) => (float)(Math.Round(v * 64) / 64);
        public static string F(double v) => Math.Round(v, 3).ToString("0.###", CultureInfo.InvariantCulture);
    }
}
