// What a shape is filled or stroked with: a colour or a gradient (linear / radial, objectBoundingBox or userSpaceOnUse
// units, gradientTransform, stops with opacity), evaluated the way SVG defines it (colours interpolated in sRGB).
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Vector
{
    public struct RGBA
    {
        public float R, G, B, A;   // 0..1, straight (not premultiplied)
        public RGBA(float r, float g, float b, float a) { R = r; G = g; B = b; A = a; }
        public static readonly RGBA Transparent = new RGBA(0, 0, 0, 0);
        public static RGBA Lerp(RGBA a, RGBA b, float t) => new RGBA(a.R + (b.R - a.R) * t, a.G + (b.G - a.G) * t, a.B + (b.B - a.B) * t, a.A + (b.A - a.A) * t);
        public override string ToString() => $"rgba({R * 255:0},{G * 255:0},{B * 255:0},{A:0.##})";
    }

    public enum PaintKind { None, Solid, Linear, Radial, Image }

    public sealed class Paint
    {
        public PaintKind Kind;
        public RGBA Color;
        public bool BoundingBoxUnits = true;
        public Affine GradientTransform = Affine.Identity;
        public double X1, Y1, X2 = 1, Y2, Cx = 0.5, Cy = 0.5, R = 0.5, Fx = 0.5, Fy = 0.5;
        public int Spread;   // 0 pad, 1 reflect, 2 repeat
        public readonly List<(float offset, RGBA color)> Stops = new List<(float, RGBA)>();
        // Image: the picture's name (an <image> href) and the map from user space to its 0..1 square (y down)
        public string Image;
        public Affine UserToImage = Affine.Identity;
        Affine _gti; bool _gtiReady;

        public static readonly Paint None = new Paint { Kind = PaintKind.None };
        public static Paint Solid(RGBA c) => new Paint { Kind = PaintKind.Solid, Color = c };

        // the colour at a gradient parameter t
        public RGBA At(double t)
        {
            if (Stops.Count == 0) return RGBA.Transparent;
            if (Spread == 1) { t = Math.Abs(t) % 2; if (t > 1) t = 2 - t; }
            else if (Spread == 2) t -= Math.Floor(t);
            if (t <= Stops[0].offset) return Stops[0].color;
            for (int i = 1; i < Stops.Count; i++)
            {
                if (t <= Stops[i].offset)
                {
                    var a = Stops[i - 1]; var b = Stops[i];
                    float span = b.offset - a.offset;
                    return span <= 0 ? b.color : RGBA.Lerp(a.color, b.color, (float)((t - a.offset) / span));
                }
            }
            return Stops[Stops.Count - 1].color;
        }

        // the gradient parameter at a user-space point, `box` the shape's user-space box (objectBoundingBox units)
        public double ParamAt(Vec2 user, Box box)
        {
            var p = user;
            if (BoundingBoxUnits)
            {
                if (box.W <= 0 || box.H <= 0) return 0;
                p = new Vec2((p.X - box.X0) / box.W, (p.Y - box.Y0) / box.H);
            }
            if (!_gtiReady) { _gti = GradientTransform.Inverse(); _gtiReady = true; }
            p = _gti.Apply(p);
            if (Kind == PaintKind.Linear)
            {
                double dx = X2 - X1, dy = Y2 - Y1, len2 = dx * dx + dy * dy;
                return len2 == 0 ? 0 : ((p.X - X1) * dx + (p.Y - Y1) * dy) / len2;
            }
            // radial with a focal point: the largest t >= 0 with p on the circle centred at f + t (c - f), radius t R
            // |e - t d|^2 = t^2 R^2  ->  (d.d - R^2) t^2 - 2 (e.d) t + e.e = 0,  e = p - f, d = c - f
            if (R <= 0) return 1;
            double ex = p.X - Fx, ey = p.Y - Fy, dx2 = Cx - Fx, dy2 = Cy - Fy;
            if (Math.Abs(dx2) < 1e-9 && Math.Abs(dy2) < 1e-9) return Math.Sqrt(ex * ex + ey * ey) / R;
            double qa = dx2 * dx2 + dy2 * dy2 - R * R, qb = ex * dx2 + ey * dy2, qc = ex * ex + ey * ey;
            if (Math.Abs(qa) < 1e-12) return qb == 0 ? 0 : qc / (2 * qb);
            double disc = qb * qb - qa * qc;
            if (disc < 0) return 1;
            double r1 = (qb + Math.Sqrt(disc)) / qa, r2 = (qb - Math.Sqrt(disc)) / qa, best = Math.Max(r1, r2);
            return best < 0 ? 1 : best;
        }
    }

    public static class Colors
    {
        static readonly Dictionary<string, uint> Named = new Dictionary<string, uint>
        {
            { "black", 0x000000 }, { "white", 0xffffff }, { "red", 0xff0000 }, { "green", 0x008000 }, { "blue", 0x0000ff },
            { "yellow", 0xffff00 }, { "orange", 0xffa500 }, { "pink", 0xffc0cb }, { "purple", 0x800080 }, { "gray", 0x808080 },
            { "grey", 0x808080 }, { "gold", 0xffd700 }, { "brown", 0xa52a2a }, { "cyan", 0x00ffff }, { "magenta", 0xff00ff },
            { "silver", 0xc0c0c0 }, { "navy", 0x000080 }, { "teal", 0x008080 }, { "lime", 0x00ff00 }, { "maroon", 0x800000 },
            { "olive", 0x808000 }, { "hotpink", 0xff69b4 }, { "skyblue", 0x87ceeb }, { "lightblue", 0xadd8e6 }, { "salmon", 0xfa8072 },
            { "coral", 0xff7f50 }, { "tomato", 0xff6347 }, { "ivory", 0xfffff0 }, { "beige", 0xf5f5dc }, { "tan", 0xd2b48c },
            { "khaki", 0xf0e68c }, { "violet", 0xee82ee }, { "indigo", 0x4b0082 }, { "crimson", 0xdc143c }, { "chocolate", 0xd2691e },
            { "lightgray", 0xd3d3d3 }, { "darkgray", 0xa9a9a9 }, { "whitesmoke", 0xf5f5f5 }, { "snow", 0xfffafa }, { "lavender", 0xe6e6fa },
        };

        public static bool TryParse(string s, out RGBA c)
        {
            c = RGBA.Transparent;
            if (string.IsNullOrEmpty(s)) return false;
            s = s.Trim();
            if (s == "transparent") return true;
            if (s[0] == '#')
            {
                var h = s.Substring(1);
                if (h.Length == 3 || h.Length == 4) h = string.Concat(h[0], h[0], h[1], h[1], h[2], h[2], h.Length == 4 ? new string(h[3], 2) : "");
                if ((h.Length != 6 && h.Length != 8) || !uint.TryParse(h, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var v)) return false;
                if (h.Length == 6) c = new RGBA(((v >> 16) & 255) / 255f, ((v >> 8) & 255) / 255f, (v & 255) / 255f, 1);
                else c = new RGBA(((v >> 24) & 255) / 255f, ((v >> 16) & 255) / 255f, ((v >> 8) & 255) / 255f, (v & 255) / 255f);
                return true;
            }
            if (s.StartsWith("rgb"))
            {
                int o = s.IndexOf('('), e = s.IndexOf(')');
                if (o < 0 || e < 0) return false;
                var parts = s.Substring(o + 1, e - o - 1).Split(new[] { ',', ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3) return false;
                float ch(string p) => p.EndsWith("%") ? float.Parse(p.TrimEnd('%'), CultureInfo.InvariantCulture) / 100f : float.Parse(p, CultureInfo.InvariantCulture) / 255f;
                float a = parts.Length > 3 ? (parts[3].EndsWith("%") ? float.Parse(parts[3].TrimEnd('%'), CultureInfo.InvariantCulture) / 100f : float.Parse(parts[3], CultureInfo.InvariantCulture)) : 1f;
                c = new RGBA(Clamp01(ch(parts[0])), Clamp01(ch(parts[1])), Clamp01(ch(parts[2])), Clamp01(a));
                return true;
            }
            if (s.StartsWith("hsl"))
            {
                // hsl(h, s%, l%) / hsla(h, s%, l%, a): Bubbly's shimmer animates its gradient through these
                int o = s.IndexOf('('), e = s.IndexOf(')');
                if (o < 0 || e < 0) return false;
                var parts = s.Substring(o + 1, e - o - 1).Split(new[] { ',', ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3) return false;
                double h = SvgNum.Parse(parts[0].Replace("deg", "")) / 360.0, sat = SvgNum.Parse(parts[1].TrimEnd('%')) / 100.0, lig = SvgNum.Parse(parts[2].TrimEnd('%')) / 100.0;
                float al = parts.Length > 3 ? (parts[3].EndsWith("%") ? SvgNum.Parse(parts[3].TrimEnd('%')) / 100f : SvgNum.Parse(parts[3])) : 1f;
                h -= Math.Floor(h);
                sat = Math.Max(0, Math.Min(1, sat)); lig = Math.Max(0, Math.Min(1, lig));
                double q = lig < 0.5 ? lig * (1 + sat) : lig + sat - lig * sat, p = 2 * lig - q;
                double hue(double t) { if (t < 0) t += 1; if (t > 1) t -= 1; return t < 1.0 / 6 ? p + (q - p) * 6 * t : t < 0.5 ? q : t < 2.0 / 3 ? p + (q - p) * (2.0 / 3 - t) * 6 : p; }
                c = new RGBA((float)hue(h + 1.0 / 3), (float)hue(h), (float)hue(h - 1.0 / 3), Clamp01(al));
                // the browser keeps colours in 8 bits per channel
                c = new RGBA((float)Math.Round(c.R * 255) / 255f, (float)Math.Round(c.G * 255) / 255f, (float)Math.Round(c.B * 255) / 255f, c.A);
                return true;
            }
            if (Named.TryGetValue(s.ToLowerInvariant(), out var n)) { c = new RGBA(((n >> 16) & 255) / 255f, ((n >> 8) & 255) / 255f, (n & 255) / 255f, 1); return true; }
            return false;
        }

        static float Clamp01(float v) => v < 0 ? 0 : v > 1 ? 1 : v;

        // a fraction or a percentage ("38%" -> 0.38)
        public static double Fraction(string s, double fallback)
        {
            if (string.IsNullOrEmpty(s)) return fallback;
            s = s.Trim();
            if (s.EndsWith("%")) return SvgNum.Parse(s.TrimEnd('%'), (float)(fallback * 100)) / 100.0;
            return SvgNum.Parse(s, (float)fallback);
        }
    }
}
