// The Dance Room's renovated floor (Squad House v6.dc.html rnFlat: "Dance Club renovated floor: repeating perspective
// surface"): a CSS 3D plane, 3000 x 1200 px at (-854, -550) of a 1292 x 643 box with perspective 450 px seen from
// (646, 230), turned rotateX(60deg) about its bottom middle, its background the floor's tile layers (floorRoom.layers:
// url, x, y, w, h, repeat) over the floor's colour. The vector renderer has no perspective, so the plane is drawn here
// into a picture (RoomCompose puts it in the room as <image href="flat:..">): each pixel of the picture is traced back
// onto the plane (the projection inverted) and the tile read there, from a mip level for its distance (the browser
// filters the far rows the same way). The tile itself is the export's picture of the floor's tile (SMIL stripped:
// 2026-11-21, patches.mjs rnFlat, the floor is a still; SquishDisco's light-up moments are app/menu.js's).
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.House
{
    public static class HouseFlat
    {
        public sealed class Layer { public string Url; public double X, Y, W, H; public bool Rep; }
        /// <summary>A plane as RoomCompose read it from the CSS (container px; the projected box it covers).</summary>
        public sealed class Spec
        {
            public double L, T, W, H, Ox, Oy, Angle, D, Px, Py;   // the plane's box, its transform-origin, rotateX (deg), perspective and its origin
            public double X0, Y0, X1, Y1;                         // the picture's box in the container
            public List<Layer> Layers = new List<Layer>(); public string Bg = "#08080a";
        }
        /// <summary>A renovated floor's tile layers and colour (floorRoom), by the floor's id: RoomModel puts them here as it
        /// gives the room `flat:&lt;id&gt;` for the plane's background.</summary>
        public static readonly Dictionary<string, (List<Layer> layers, string bg)> Floors = new Dictionary<string, (List<Layer>, string)>();
        /// <summary>href ("flat:..") -> its plane, registered by RoomCompose as it writes the image.</summary>
        public static readonly Dictionary<string, Spec> Specs = new Dictionary<string, Spec>();
        /// <summary>Picture px per container px the plane is drawn at.</summary>
        public const double K = 2;

        static double Rad(double deg) => deg * Math.PI / 180;

        /// <summary>A plane point (its own px) -> the container (x, y).</summary>
        public static (double x, double y) Project(Spec s, double u, double v)
        {
            double a = Rad(s.Angle), X = u - s.Ox, Y = v - s.Oy;
            double px = s.L + s.Ox + X, py = s.T + s.Oy + Y * Math.Cos(a), pz = Y * Math.Sin(a), k = s.D / (s.D - pz);
            return (s.Px + (px - s.Px) * k, s.Py + (py - s.Py) * k);
        }

        /// <summary>The container point (x, y) -> the plane point under it (false: off the plane / behind the eye).</summary>
        public static bool Unproject(Spec s, double x, double y, out double u, out double v, out double k)
        {
            double a = Rad(s.Angle), ca = Math.Cos(a), sa = Math.Sin(a), A = s.T + s.Oy - s.Py, dy = y - s.Py;
            double den = s.D * ca + dy * sa; u = v = k = 0;
            if (Math.Abs(den) < 1e-9) return false;
            double Y = s.D * (dy - A) / den; k = s.D / (s.D - Y * sa);
            if (k <= 0) return false;
            double X = (x - s.Px) / k - (s.L + s.Ox - s.Px);
            u = X + s.Ox; v = Y + s.Oy;
            return u >= 0 && u <= s.W && v >= 0 && v <= s.H;
        }

        /// <summary>The bounding box of the plane as drawn (the container's px).</summary>
        public static void Bounds(Spec s)
        {
            double x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
            foreach (var (u, v) in new[] { (0.0, 0.0), (s.W, 0.0), (s.W, s.H), (0.0, s.H) }) { var p = Project(s, u, v); x0 = Math.Min(x0, p.x); y0 = Math.Min(y0, p.y); x1 = Math.Max(x1, p.x); y1 = Math.Max(y1, p.y); }
            s.X0 = Math.Floor(x0); s.Y0 = Math.Floor(y0); s.X1 = Math.Ceiling(x1); s.Y1 = Math.Ceiling(y1);
        }

        sealed class Mip { public int W, H; public float[] Px; }
        static List<Mip> Pyramid(int w, int h, float[] rgba)
        {
            // premultiplied, so a level's average of a transparent edge doesn't darken
            var p0 = new float[rgba.Length]; for (int i = 0; i < rgba.Length; i += 4) { float al = rgba[i + 3]; p0[i] = rgba[i] * al; p0[i + 1] = rgba[i + 1] * al; p0[i + 2] = rgba[i + 2] * al; p0[i + 3] = al; }
            var L = new List<Mip> { new Mip { W = w, H = h, Px = p0 } };
            while (L[L.Count - 1].W > 1 || L[L.Count - 1].H > 1)
            {
                var m = L[L.Count - 1]; int nw = Math.Max(1, m.W / 2), nh = Math.Max(1, m.H / 2); var n = new float[nw * nh * 4];
                for (int y = 0; y < nh; y++) for (int x = 0; x < nw; x++) for (int c = 0; c < 4; c++)
                {
                    int x0 = Math.Min(m.W - 1, x * 2), x1 = Math.Min(m.W - 1, x * 2 + 1), y0 = Math.Min(m.H - 1, y * 2), y1 = Math.Min(m.H - 1, y * 2 + 1);
                    n[(y * nw + x) * 4 + c] = (m.Px[(y0 * m.W + x0) * 4 + c] + m.Px[(y0 * m.W + x1) * 4 + c] + m.Px[(y1 * m.W + x0) * 4 + c] + m.Px[(y1 * m.W + x1) * 4 + c]) / 4;
                }
                L.Add(new Mip { W = nw, H = nh, Px = n });
            }
            return L;
        }

        // bilinear, wrapping (fx, fy: 0..1 of the tile)
        static void Sample(Mip m, double fx, double fy, bool rep, float[] o)
        {
            double x = fx * m.W - 0.5, y = fy * m.H - 0.5; int ix = (int)Math.Floor(x), iy = (int)Math.Floor(y); float tx = (float)(x - ix), ty = (float)(y - iy);
            for (int c = 0; c < 4; c++) o[c] = 0;
            for (int j = 0; j < 2; j++) for (int i = 0; i < 2; i++)
            {
                int xx = ix + i, yy = iy + j;
                if (rep) { xx = ((xx % m.W) + m.W) % m.W; yy = ((yy % m.H) + m.H) % m.H; } else { xx = Math.Max(0, Math.Min(m.W - 1, xx)); yy = Math.Max(0, Math.Min(m.H - 1, yy)); }
                float wgt = (i == 0 ? 1 - tx : tx) * (j == 0 ? 1 - ty : ty); int b = (yy * m.W + xx) * 4;
                for (int c = 0; c < 4; c++) o[c] += m.Px[b + c] * wgt;
            }
        }

        static (float r, float g, float b) Hex(string c)
        {
            c = (c ?? "#000").Trim();
            if (c.StartsWith("#") && c.Length == 7) return (int.Parse(c.Substring(1, 2), NumberStyles.HexNumber) / 255f, int.Parse(c.Substring(3, 2), NumberStyles.HexNumber) / 255f, int.Parse(c.Substring(5, 2), NumberStyles.HexNumber) / 255f);
            if (c.StartsWith("#") && c.Length == 4) return (Convert.ToInt32(new string(c[1], 2), 16) / 255f, Convert.ToInt32(new string(c[2], 2), 16) / 255f, Convert.ToInt32(new string(c[3], 2), 16) / 255f);
            return (0, 0, 0);
        }

        /// <summary>The plane's picture (straight RGBA 0..1, w x h = its box at K px a container px). tile(url): a layer's
        /// picture (straight RGBA 0..1) or null.</summary>
        public static (int w, int h, float[] rgba) Render(Spec s, Func<string, (int w, int h, float[] rgba)> tile)
        {
            int W = Math.Max(1, (int)Math.Ceiling((s.X1 - s.X0) * K)), H = Math.Max(1, (int)Math.Ceiling((s.Y1 - s.Y0) * K));
            var outp = new float[W * H * 4];
            var mips = new List<List<Mip>>();
            foreach (var l in s.Layers) { var t = tile(l.Url); mips.Add(t.rgba != null ? Pyramid(t.w, t.h, t.rgba) : null); }
            var bg = Hex(s.Bg); var o = new float[4];
            // 2 x 2 samples a pixel (the far rows' fine lines don't shimmer into moiré), the mip level for the texel rate
            const int SS = 2;
            for (int py = 0; py < H; py++)
            {
                for (int px = 0; px < W; px++)
                {
                    float r = 0, g = 0, b = 0, a = 0;
                    for (int sy = 0; sy < SS; sy++) for (int sx = 0; sx < SS; sx++)
                    {
                        double x = s.X0 + (px + (sx + 0.5) / SS) / K, y = s.Y0 + (py + (sy + 0.5) / SS) / K;
                        if (!Unproject(s, x, y, out var u, out var v, out var k)) continue;
                        // plane px per picture px: across 1 / (k K), down that over the slant (the next row's v)
                        Unproject(s, x, y + 1 / K, out _, out var v2, out _);
                        double du = 1 / (k * K), dv = Math.Abs(v2 - v);
                        // the layers, the top one last over the others, over the floor's colour
                        float cr = bg.r, cg = bg.g, cb = bg.b;
                        for (int li = s.Layers.Count - 1; li >= 0; li--)
                        {
                            var l = s.Layers[li]; var M = mips[li]; if (M == null) continue;
                            double lu = (u - l.X) / l.W, lv = (v - l.Y) / l.H;
                            if (!l.Rep && (lu < 0 || lu > 1 || lv < 0 || lv > 1)) continue;
                            double texels = Math.Sqrt(du * M[0].W / l.W * dv * M[0].H / l.H) / SS;
                            int lev = Math.Max(0, Math.Min(M.Count - 1, (int)Math.Round(Math.Log(Math.Max(1, texels), 2))));
                            Sample(M[lev], lu - Math.Floor(lu), lv - Math.Floor(lv), l.Rep, o);
                            cr = o[0] + cr * (1 - o[3]); cg = o[1] + cg * (1 - o[3]); cb = o[2] + cb * (1 - o[3]);
                        }
                        r += cr; g += cg; b += cb; a += 1;
                    }
                    int i = (py * W + px) * 4; const float n = SS * SS;
                    if (a > 0) { outp[i] = r / a; outp[i + 1] = g / a; outp[i + 2] = b / a; }
                    outp[i + 3] = a / n;
                }
            }
            return (W, H, outp);
        }
    }
}
