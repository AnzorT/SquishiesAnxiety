// "Heading home"'s night and lights, made the app's way (webgame/app/menu.js M.headingHome nightPics): the house by day
// (its picture, the door open) multiplied by the night's colours, then each light composited on top in the order they
// come on (its windows: the house by day cut to their shapes at 0.9, a warm halo in screen at 0.85, a pane in soft
// light at 0.75; the dance room's dome dimmer) and the canvas cut to that light's box: its own picture, faded in when it
// comes on. Canvas arithmetic on sRGB values, as Chrome's 2D canvas does it. Plain C# (MenuView.Heading.cs shows the
// pictures; tools/unity/heading-test draws them off Unity and compares them with the app).
// Pictures: RGB, 3 bytes a pixel, rows top-down. Scene units: main-menu-scene.js's 1000 x 460.
using System;
using System.Collections.Generic;

namespace SquishSquad.Menu
{
    public static class HeadingNight
    {
        /// <summary>A window (main-menu-scene.js win(): the intro's WIN list and the small round ones): 'r' a rect, 'a' an
        /// arch (a rect under a half circle w wide), 'c' a circle (X, Y its centre, W its radius), 'd' the dance room's
        /// dome (a half disc); K how far its light opens (the dome stays dimmer), R its halo's size when not its box's.</summary>
        public sealed class Win { public char Kind; public float X, Y, W, H, K = 1, R; }
        static Win Rw(float x, float y, float w, float h) => new Win { Kind = 'r', X = x, Y = y, W = w, H = h };
        static Win Aw(float x, float y, float w, float h, float R = 0) => new Win { Kind = 'a', X = x, Y = y, W = w, H = h, R = R };
        static Win Cw(float cx, float cy, float r) => new Win { Kind = 'c', X = cx, Y = cy, W = r };
        public static (float x, float y, float w, float h) BoxOf(Win w) => w.Kind == 'c' ? (w.X - w.W, w.Y - w.W, 2 * w.W, 2 * w.W) : (w.X, w.Y, w.W, w.H);

        public static readonly Dictionary<string, Win[]> HWIN = new Dictionary<string, Win[]>
        {
            ["living"] = new[] { Rw(434, 218, 36, 40), Rw(530, 218, 36, 40) },
            ["bedroom"] = new[] { Aw(298, 164, 42, 48), Rw(366, 176, 30, 30), Cw(340, 122, 5.2f) },
            ["kitchen"] = new[] { Rw(282, 246, 62, 36), Cw(385, 265, 13) },
            ["bathroom"] = new[] { Cw(629, 185, 17), Rw(668, 164, 46, 44), Cw(652, 122, 4) },
            ["movie"] = new[] { Rw(604, 242, 92, 40), Rw(712, 248, 16, 34) },
            ["dance"] = new[] { new Win { Kind = 'd', X = 454, Y = 124, W = 92, H = 46, K = 0.6f }, Cw(462, 178, 4.2f), Cw(481, 178, 4.2f), Cw(500, 178, 4.2f), Cw(519, 178, 4.2f), Cw(538, 178, 4.2f) },
        };
        /// <summary>The open doorway (its light already on: main-menu.js doorOpen) and the two porch lamps.</summary>
        public static readonly Win[] HDOOR = { Aw(488, 247, 24, 53, 34), Cw(476, 250.5f, 5), Cw(524, 250.5f, 5) };
        /// <summary>The rooms with windows, by the level each opens at (main-menu-scene.js ROOMS).</summary>
        public static readonly (string room, int lv)[] ROOMS = { ("living", 1), ("kitchen", 2), ("bathroom", 4), ("bedroom", 6), ("dance", 11), ("movie", 12) };

        public sealed class Light
        {
            public Win[] G;
            public float X0, Y0, X1, Y1;   // its box, scene units (its windows and their halos)
            public int PX, PY, PW, PH;     // the picture's part it covers (px)
            public byte[] Rgb;             // that part of the canvas once it has come on
        }

        /// <summary>The lights in the order they come on: each open room's windows (by the level it opens at), the door last.</summary>
        public static List<Light> LightsFor(int level)
        {
            var o = new List<Light>();
            foreach (var (room, lv) in ROOMS) if (level >= lv) o.Add(MakeLight(HWIN[room]));
            o.Add(MakeLight(HDOOR));
            return o;
        }

        static Light MakeLight(Win[] g)
        {
            var L = new Light { G = g, X0 = 1e9f, Y0 = 1e9f, X1 = -1e9f, Y1 = -1e9f };
            void Grow(float x, float y, float w, float h) { L.X0 = Math.Min(L.X0, x); L.Y0 = Math.Min(L.Y0, y); L.X1 = Math.Max(L.X1, x + w); L.Y1 = Math.Max(L.Y1, y + h); }
            foreach (var w in g)
            {
                var (x, y, bw, bh) = BoxOf(w); Grow(x, y, bw, bh);
                float R = w.R > 0 ? w.R : Math.Max(bw, bh);
                Grow(x + bw / 2 - R * 1.3f, y + bh / 2 - R * 1.1f, R * 2.6f, R * 2.2f);
            }
            L.X0 -= 1; L.Y0 -= 1; L.X1 += 1; L.Y1 += 1;
            return L;
        }

        /// <summary>The night (returned) and each light's picture (into its Rgb) from the house by day: `day` W x H px,
        /// `u` scene units a px, (ox, oy) the scene point at its top-left.</summary>
        public static byte[] Make(byte[] day, int W, int H, float u, float ox, float oy, List<Light> lights)
        {
            var c = new float[W * H * 3];
            float[] g0 = { 0x1c / 255f, 0x22 / 255f, 0x60 / 255f }, g1 = { 0x2a / 255f, 0x30 / 255f, 0x70 / 255f }, g2 = { 0x26 / 255f, 0x2a / 255f, 0x5a / 255f };
            for (int py = 0; py < H; py++)
            {
                // the night's gradient: #1c2260 (0), #2a3070 (.45), #262a5a (1) down the scene's 460 units, multiplied
                float f = Clamp01((oy + (py + 0.5f) * u) / 460f), q;
                float[] a, b; if (f < 0.45f) { a = g0; b = g1; q = f / 0.45f; } else { a = g1; b = g2; q = (f - 0.45f) / 0.55f; }
                float gr = a[0] + (b[0] - a[0]) * q, gg = a[1] + (b[1] - a[1]) * q, gb = a[2] + (b[2] - a[2]) * q;
                for (int px = 0; px < W; px++) { int j = (py * W + px) * 3; c[j] = day[j] / 255f * gr; c[j + 1] = day[j + 1] / 255f * gg; c[j + 2] = day[j + 2] / 255f * gb; }
            }
            var night = Pack(c, W, 0, 0, W, H);
            foreach (var L in lights)
            {
                foreach (var w in L.G)
                {
                    // the window: the house by day at 0.9 (the dome: 0.9 x its K)
                    var (bx, by, bw, bh) = BoxOf(w); float k = w.K;
                    Each(W, H, u, ox, oy, bx - 1, by - 1, bw + 2, bh + 2, (sx, sy, j) =>
                    {
                        float al = 0.9f * k * Cover(w, sx, sy, u); if (al <= 0) return;
                        for (int ch = 0; ch < 3; ch++) c[j + ch] += (day[j + ch] / 255f - c[j + ch]) * al;
                    });
                }
                foreach (var w in L.G)
                {
                    // its halo: a radial gradient over an ellipse R x 1.3 by R x 1.1, in screen at 0.85
                    var (bx, by, bw, bh) = BoxOf(w);
                    float R = w.R > 0 ? w.R : Math.Max(bw, bh), cx = bx + bw / 2, cy = by + bh / 2, rx = R * 1.3f, ry = R * 1.1f;
                    Each(W, H, u, ox, oy, cx - rx, cy - ry, 2 * rx, 2 * ry, (sx, sy, j) =>
                    {
                        float q = (float)Math.Sqrt(Sq((sx - cx) / rx) + Sq((sy - cy) / ry));
                        if (q >= 1) return;
                        // its stops: 0 rgba(255,231,166,.8), .45 rgba(255,196,90,.3), 1 rgba(255,154,42,0)
                        float g, b, al;
                        if (q < 0.45f) { float t = q / 0.45f; g = Lerp(231, 196, t) / 255f; b = Lerp(166, 90, t) / 255f; al = Lerp(0.8f, 0.3f, t); }
                        else { float t = (q - 0.45f) / 0.55f; g = Lerp(196, 154, t) / 255f; b = Lerp(90, 42, t) / 255f; al = Lerp(0.3f, 0, t); }
                        al *= 0.85f;
                        c[j] += (1 - (1 - c[j]) * (1 - 1) - c[j]) * al;
                        c[j + 1] += (1 - (1 - c[j + 1]) * (1 - g) - c[j + 1]) * al;
                        c[j + 2] += (1 - (1 - c[j + 2]) * (1 - b) - c[j + 2]) * al;
                    });
                }
                foreach (var w in L.G)
                {
                    // its pane: #fff2c0 down to #ffb347 over its box, in soft light at 0.75 (the dome: 0.75 x its K)
                    var (bx, by, bw, bh) = BoxOf(w); float k = w.K;
                    Each(W, H, u, ox, oy, bx - 1, by - 1, bw + 2, bh + 2, (sx, sy, j) =>
                    {
                        float al = 0.75f * k * Cover(w, sx, sy, u); if (al <= 0) return;
                        float t = Clamp01((sy - by) / Math.Max(0.001f, bh));
                        float sg = Lerp(0xf2, 0xb3, t) / 255f, sb = Lerp(0xc0, 0x47, t) / 255f;
                        c[j] += (SoftLight(c[j], 1) - c[j]) * al; c[j + 1] += (SoftLight(c[j + 1], sg) - c[j + 1]) * al; c[j + 2] += (SoftLight(c[j + 2], sb) - c[j + 2]) * al;
                    });
                }
                // the light's own picture: the canvas cut to its box
                int p0 = Math.Max(0, (int)Math.Floor((L.X0 - ox) / u)), q0 = Math.Max(0, (int)Math.Floor((L.Y0 - oy) / u));
                int p1 = Math.Min(W, (int)Math.Ceiling((L.X1 - ox) / u)), q1 = Math.Min(H, (int)Math.Ceiling((L.Y1 - oy) / u));
                if (p1 > p0 && q1 > q0) { L.PX = p0; L.PY = q0; L.PW = p1 - p0; L.PH = q1 - q0; L.Rgb = Pack(c, W, p0, q0, L.PW, L.PH); }
            }
            return night;
        }

        static float Sq(float v) => v * v;
        static float Lerp(float a, float b, float t) => a + (b - a) * t;
        static float Clamp01(float v) => v < 0 ? 0 : v > 1 ? 1 : v;
        static float SoftLight(float b, float s)
        {
            if (s <= 0.5f) return b - (1 - 2 * s) * b * (1 - b);
            float d = b <= 0.25f ? ((16 * b - 12) * b + 4) * b : (float)Math.Sqrt(b);
            return b + (2 * s - 1) * (d - b);
        }
        static byte[] Pack(float[] c, int W, int x0, int y0, int w, int h)
        {
            var o = new byte[w * h * 3];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int j = ((y0 + y) * W + x0 + x) * 3, k = (y * w + x) * 3;
                    for (int ch = 0; ch < 3; ch++) { int v = (int)Math.Round(c[j + ch] * 255); o[k + ch] = (byte)(v < 0 ? 0 : v > 255 ? 255 : v); }
                }
            return o;
        }
        // each px of a scene box: its middle (scene units) and its index in the canvas
        static void Each(int W, int H, float u, float ox, float oy, float x, float y, float w, float h, Action<float, float, int> f)
        {
            int p0 = Math.Max(0, (int)Math.Floor((x - ox) / u)), q0 = Math.Max(0, (int)Math.Floor((y - oy) / u));
            int p1 = Math.Min(W, (int)Math.Ceiling((x + w - ox) / u)), q1 = Math.Min(H, (int)Math.Ceiling((y + h - oy) / u));
            for (int py = q0; py < q1; py++)
                for (int px = p0; px < p1; px++)
                    f(ox + (px + 0.5f) * u, oy + (py + 0.5f) * u, (py * W + px) * 3);
        }
        /// <summary>A window's coverage of the px whose middle is (sx, sy), scene units: 1 inside, 0 outside, a ramp one px
        /// wide across its edge (Chrome's antialiased clip).</summary>
        public static float Cover(Win w, float sx, float sy, float u)
        {
            float d;   // the signed distance to its edge, scene units (negative inside)
            switch (w.Kind)
            {
                case 'c': d = (float)Math.Sqrt(Sq(sx - w.X) + Sq(sy - w.Y)) - w.W; break;
                case 'r': d = Math.Max(Math.Max(w.X - sx, sx - (w.X + w.W)), Math.Max(w.Y - sy, sy - (w.Y + w.H))); break;
                case 'a':
                {
                    float r = w.W / 2, cx = w.X + r, cy = w.Y + r;
                    float dRect = Math.Max(Math.Max(w.X - sx, sx - (w.X + w.W)), Math.Max(cy - sy, sy - (w.Y + w.H)));
                    float dCirc = sy <= cy ? (float)Math.Sqrt(Sq(sx - cx) + Sq(sy - cy)) - r : 1e9f;
                    d = Math.Min(dRect, dCirc);
                    break;
                }
                default: d = Math.Max((float)Math.Sqrt(Sq(sx - 500) + Sq(sy - 170)) - 46, sy - 170); break;   // M454 170A46 46 0 0 1 546 170Z
            }
            return Clamp01(0.5f - d / u);
        }
    }
}
