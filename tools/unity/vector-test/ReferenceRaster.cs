// A plain, slow, exact-as-possible rasteriser for SvgScene, to check the renderer core against Chrome outside Unity:
// each output pixel is SS x SS samples (point-sampled triangles, box-filtered), colours composited premultiplied in
// sRGB like the browser, layers (opacity, clip, mask, filter) drawn on their own and composited. The GPU renderer in
// Unity draws the same scene with meshes and shaders; this tells whether the scene itself is right.
using System;
using System.Collections.Generic;
using SquishSquad.Vector;

static class ReferenceRaster
{
    public sealed class Buffer
    {
        public readonly int W, H;
        public readonly float[] P;   // premultiplied RGBA, row-major
        public Buffer(int w, int h) { W = w; H = h; P = new float[w * h * 4]; }
    }

    public static Func<string, (int w, int h, float[] rgba)> LoadImage;   // straight RGBA 0..1, for feImage

    public static Buffer Render(SvgScene scene, int w, int h, int ss)
    {
        var buf = new Buffer(w * ss, h * ss);
        DrawChildren(scene, scene.Root.Children, buf, ss);
        return buf;
    }

    static void DrawChildren(SvgScene sc, List<RenderNode> nodes, Buffer into, int ss)
    {
        foreach (var n in nodes)
        {
            if (n is FillNode f) Fill(f, into, ss);
            else if (n is LayerNode l) Layer(sc, l, into, ss);
        }
    }

    // Which samples a shape covers, worked out the way the GPU's stencil does it: every polygon drawn as a triangle fan
    // from its first point, each triangle adding its orientation's sign to the samples it covers (NonZero / EvenOdd),
    // or just marking them (Union). Samples sit at the centres of the supersampled grid: (x + 0.5) / ss in output px.
    static bool[] Coverage(Shape sh, int W, int H, int ss, out int bx0, out int by0, out int bw, out int bh)
    {
        var bb = sh.Bounds;
        bx0 = Math.Max(0, (int)Math.Floor(bb.X0 * ss - 1)); by0 = Math.Max(0, (int)Math.Floor(bb.Y0 * ss - 1));
        int bx1 = Math.Min(W - 1, (int)Math.Ceiling(bb.X1 * ss + 1)), by1 = Math.Min(H - 1, (int)Math.Ceiling(bb.Y1 * ss + 1));
        bw = Math.Max(0, bx1 - bx0 + 1); bh = Math.Max(0, by1 - by0 + 1);
        var wind = new int[bw * bh];
        foreach (var poly in sh.Polygons)
        {
            for (int i = 1; i + 1 < poly.Count; i++)
            {
                Vec2 a = poly[0], c1 = poly[i], c2 = poly[i + 1];
                double area = (c1.X - a.X) * (c2.Y - a.Y) - (c1.Y - a.Y) * (c2.X - a.X);
                if (Math.Abs(area) < 1e-12) continue;
                int sign = area > 0 ? 1 : -1;
                if (area < 0) { var t = c1; c1 = c2; c2 = t; }
                int x0 = Math.Max(bx0, (int)Math.Floor(Math.Min(a.X, Math.Min(c1.X, c2.X)) * ss - 0.5)), x1 = Math.Min(bx0 + bw - 1, (int)Math.Ceiling(Math.Max(a.X, Math.Max(c1.X, c2.X)) * ss));
                int y0 = Math.Max(by0, (int)Math.Floor(Math.Min(a.Y, Math.Min(c1.Y, c2.Y)) * ss - 0.5)), y1 = Math.Min(by0 + bh - 1, (int)Math.Ceiling(Math.Max(a.Y, Math.Max(c1.Y, c2.Y)) * ss));
                for (int y = y0; y <= y1; y++)
                {
                    double py = (y + 0.5) / ss;
                    for (int x = x0; x <= x1; x++)
                    {
                        double px = (x + 0.5) / ss;
                        if (!Inside(a, c1, px, py) || !Inside(c1, c2, px, py) || !Inside(c2, a, px, py)) continue;
                        int k = (y - by0) * bw + (x - bx0);
                        if (sh.Rule == FillRule.Union) wind[k] = 1; else wind[k] += sign;
                    }
                }
            }
        }
        var cov = new bool[bw * bh];
        for (int i = 0; i < cov.Length; i++) cov[i] = sh.Rule == FillRule.EvenOdd ? (wind[i] & 1) != 0 : wind[i] != 0;
        return cov;
    }

    static void Fill(FillNode f, Buffer b, int ss)
    {
        var cov = Coverage(f.Shape, b.W, b.H, ss, out int bx0, out int by0, out int bw, out int bh);
        var inv = f.UserToPx.Inverse();
        bool solid = f.Paint.Kind == PaintKind.Solid;
        if (f.Paint.Kind == PaintKind.Image)
        {
            // bilinear, like a GPU texture lookup
            var img = LoadImage?.Invoke(f.Paint.Image);
            if (img == null || img.Value.rgba == null || img.Value.w <= 0) return;
            var (iw, ih, px) = img.Value;
            var toImg = f.Paint.UserToImage * inv;
            for (int y = 0; y < bh; y++)
                for (int x = 0; x < bw; x++)
                {
                    if (!cov[y * bw + x]) continue;
                    int X = bx0 + x, Y = by0 + y;
                    var uv = toImg.Apply(new Vec2((X + 0.5) / ss, (Y + 0.5) / ss));
                    double fx = uv.X * iw - 0.5, fy = uv.Y * ih - 0.5;
                    int ix = (int)Math.Floor(fx), iy = (int)Math.Floor(fy);
                    float tx = (float)(fx - ix), ty = (float)(fy - iy);
                    float r = 0, g = 0, bl = 0, a = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        int sx = Math.Clamp(ix + (j & 1), 0, iw - 1), sy = Math.Clamp(iy + (j >> 1), 0, ih - 1);
                        float w = ((j & 1) == 1 ? tx : 1 - tx) * ((j >> 1) == 1 ? ty : 1 - ty);
                        int o = (sy * iw + sx) * 4;
                        float pa = px[o + 3] * w;
                        r += px[o] * pa; g += px[o + 1] * pa; bl += px[o + 2] * pa; a += pa;
                    }
                    if (a > 0) Over(b, X, Y, r / a, g / a, bl / a, a * f.Opacity);
                }
            return;
        }
        for (int y = 0; y < bh; y++)
            for (int x = 0; x < bw; x++)
            {
                if (!cov[y * bw + x]) continue;
                int X = bx0 + x, Y = by0 + y;
                RGBA col = solid ? f.Paint.Color : f.Paint.At(f.Paint.ParamAt(inv.Apply(new Vec2((X + 0.5) / ss, (Y + 0.5) / ss)), f.UserBox));
                Over(b, X, Y, col.R, col.G, col.B, col.A * f.Opacity);
            }
    }

    static bool Inside(Vec2 a, Vec2 b, double px, double py)
    {
        double e = (b.X - a.X) * (py - a.Y) - (b.Y - a.Y) * (px - a.X);
        if (e > 0) return true;
        if (e < 0) return false;
        // on the edge: top edge (horizontal, pointing right in this winding) or left edge (pointing up)
        return (a.Y == b.Y && b.X > a.X) || b.Y < a.Y;
    }

    static void Over(Buffer b, int x, int y, float r, float g, float bl, float a)
    {
        if (a <= 0) return;
        int i = (y * b.W + x) * 4;
        float k = 1 - a;
        b.P[i] = r * a + b.P[i] * k; b.P[i + 1] = g * a + b.P[i + 1] * k; b.P[i + 2] = bl * a + b.P[i + 2] * k; b.P[i + 3] = a + b.P[i + 3] * k;
    }

    static void Layer(SvgScene sc, LayerNode l, Buffer into, int ss)
    {
        var lb = new Buffer(into.W, into.H);
        DrawChildren(sc, l.Children, lb, ss);
        if (l.Filter != null) lb = Filter(l, lb, ss);
        float[] clip = null;
        if (l.Clip != null)
        {
            clip = new float[lb.W * lb.H];
            foreach (var sh in l.Clip)
            {
                var cov = Coverage(sh, lb.W, lb.H, ss, out int bx0, out int by0, out int bw, out int bh);
                for (int y = 0; y < bh; y++) for (int x = 0; x < bw; x++) if (cov[y * bw + x]) clip[(by0 + y) * lb.W + bx0 + x] = 1;
            }
        }
        float[] mask = null;
        if (l.Mask != null)
        {
            var mb = new Buffer(lb.W, lb.H);
            DrawChildren(sc, l.Mask.Children, mb, ss);
            mask = new float[lb.W * lb.H];
            for (int y = 0; y < lb.H; y++)
                for (int x = 0; x < lb.W; x++)
                {
                    int i = y * lb.W + x; double px = (x + 0.5) / ss, py = (y + 0.5) / ss;
                    var r = l.MaskRegionPx;
                    if (!r.IsEmpty && (px < r.X0 || px > r.X1 || py < r.Y0 || py > r.Y1)) { mask[i] = 0; continue; }
                    // luminance of the (premultiplied) mask colour: luminance x alpha
                    mask[i] = 0.2125f * mb.P[i * 4] + 0.7154f * mb.P[i * 4 + 1] + 0.0721f * mb.P[i * 4 + 2];
                }
        }
        for (int i = 0; i < lb.W * lb.H; i++)
        {
            float k = l.Opacity * (clip == null ? 1 : clip[i]) * (mask == null ? 1 : mask[i]);
            if (k <= 0) continue;
            int j = i * 4;
            float a = lb.P[j + 3] * k;
            if (a <= 0) continue;
            float inv = 1 - a;
            into.P[j] = lb.P[j] * k + into.P[j] * inv; into.P[j + 1] = lb.P[j + 1] * k + into.P[j + 1] * inv;
            into.P[j + 2] = lb.P[j + 2] * k + into.P[j + 2] * inv; into.P[j + 3] = a + into.P[j + 3] * inv;
        }
    }

    // ---- filters: the primitives the rigs use, in linearRGB (the SVG default for filters) -------------------------
    static float ToLin(float c) => c <= 0.04045f ? c / 12.92f : (float)Math.Pow((c + 0.055f) / 1.055f, 2.4);
    static float ToSrgb(float c) => c <= 0.0031308f ? c * 12.92f : 1.055f * (float)Math.Pow(c, 1 / 2.4) - 0.055f;

    public static readonly HashSet<string> Unsupported = new HashSet<string>();

    // the filter region in samples (filters only work there; outside it the result is transparent)
    static int RX0, RY0, RX1, RY1;

    static void SetRegion(LayerNode l, SvgNode f, int ss, int w, int h)
    {
        RX0 = 0; RY0 = 0; RX1 = w - 1; RY1 = h - 1;
        var b = l.UserBox;
        if (b.IsEmpty) return;
        Box r;
        if (f["filterUnits"] == "userSpaceOnUse") r = new Box { X0 = f.Num("x", -1e6f), Y0 = f.Num("y", -1e6f), X1 = f.Num("x", -1e6f) + f.Num("width", 2e6f), Y1 = f.Num("y", -1e6f) + f.Num("height", 2e6f) };
        else
        {
            double fx = Colors.Fraction(f["x"], -0.1), fy = Colors.Fraction(f["y"], -0.1), fw = Colors.Fraction(f["width"], 1.2), fh = Colors.Fraction(f["height"], 1.2);
            r = new Box { X0 = b.X0 + fx * b.W, Y0 = b.Y0 + fy * b.H, X1 = b.X0 + (fx + fw) * b.W, Y1 = b.Y0 + (fy + fh) * b.H };
        }
        var px = Box.Empty;
        foreach (var v in new[] { new Vec2(r.X0, r.Y0), new Vec2(r.X1, r.Y0), new Vec2(r.X0, r.Y1), new Vec2(r.X1, r.Y1) }) px.Add(l.UserToPx.Apply(v));
        RX0 = Math.Max(0, (int)Math.Floor(px.X0 * ss) - 1); RY0 = Math.Max(0, (int)Math.Floor(px.Y0 * ss) - 1);
        RX1 = Math.Min(w - 1, (int)Math.Ceiling(px.X1 * ss) + 1); RY1 = Math.Min(h - 1, (int)Math.Ceiling(px.Y1 * ss) + 1);
    }

    static Buffer Filter(LayerNode l, Buffer src, int ss)
    {
        var f = l.Filter;
        SetRegion(l, f, ss, src.W, src.H);
        bool linear = (f["color-interpolation-filters"] ?? "linearRGB") != "sRGB";
        int n = src.W * src.H;
        // SourceGraphic into the filter's colour space (premultiplied)
        var S = new float[n * 4];
        for (int i = 0; i < n; i++)
        {
            float a = src.P[i * 4 + 3]; S[i * 4 + 3] = a;
            for (int c = 0; c < 3; c++) { float v = a > 0 ? src.P[i * 4 + c] / a : 0; S[i * 4 + c] = (linear ? ToLin(v) : v) * a; }
        }
        var results = new Dictionary<string, float[]> { ["SourceGraphic"] = S };
        float[] last = S;
        var inv = l.UserToPx.Inverse();
        foreach (var p in f.Children)
        {
            float[] In(string name) => name != null && results.TryGetValue(name, out var r) ? r : last;
            float[] o = new float[n * 4];
            switch (p.Tag)
            {
                case "feImage":
                {
                    var href = p["href"] ?? p["xlink:href"];
                    var img = href != null && LoadImage != null ? LoadImage(href) : (0, 0, null);
                    if (img.rgba == null) break;
                    double x = p.Num("x"), y = p.Num("y"), w = p.Num("width", 1), h = p.Num("height", 1);
                    for (int py = RY0; py <= RY1; py++)
                        for (int px = RX0; px <= RX1; px++)
                        {
                            var u = inv.Apply(new Vec2((px + 0.5) / ss, (py + 0.5) / ss));
                            double fx = (u.X - x) / w * img.w - 0.5, fy = (u.Y - y) / h * img.h - 0.5;
                            if (fx < -0.5 || fy < -0.5 || fx > img.w - 0.5 || fy > img.h - 0.5) continue;
                            int ix = Math.Max(0, Math.Min(img.w - 1, (int)Math.Round(fx))), iy = Math.Max(0, Math.Min(img.h - 1, (int)Math.Round(fy)));
                            int si = (iy * img.w + ix) * 4, di = (py * src.W + px) * 4;
                            float a = img.rgba[si + 3];
                            for (int c = 0; c < 3; c++) o[di + c] = (linear ? ToLin(img.rgba[si + c]) : img.rgba[si + c]) * a;
                            o[di + 3] = a;
                        }
                    break;
                }
                case "feComposite":
                {
                    var A = In(p["in"]); var B = In(p["in2"]);
                    var op = p["operator"] ?? "over";
                    for (int i = 0; i < n; i++)
                    {
                        int j = i * 4; float aa = A[j + 3], ab = B[j + 3];
                        float ka, kb;
                        switch (op) { case "in": ka = ab; kb = 0; break; case "out": ka = 1 - ab; kb = 0; break; case "atop": ka = ab; kb = 1 - aa; break; case "xor": ka = 1 - ab; kb = 1 - aa; break; default: ka = 1; kb = 1 - aa; break; }
                        for (int c = 0; c < 4; c++) o[j + c] = A[j + c] * ka + B[j + c] * kb;
                    }
                    break;
                }
                case "feBlend":
                {
                    var A = In(p["in"]); var B = In(p["in2"]);
                    var mode = p["mode"] ?? "normal";
                    for (int i = 0; i < n; i++)
                    {
                        int j = i * 4; float qa = A[j + 3], qb = B[j + 3];
                        for (int c = 0; c < 3; c++)
                        {
                            float ca = A[j + c], cb = B[j + c];
                            o[j + c] = mode == "multiply" ? (1 - qa) * cb + (1 - qb) * ca + ca * cb
                                     : mode == "screen" ? cb + ca - ca * cb
                                     : (1 - qa) * cb + ca;
                        }
                        o[j + 3] = 1 - (1 - qa) * (1 - qb);
                    }
                    break;
                }
                case "feTurbulence":
                {
                    var bf = (p["baseFrequency"] ?? "0").Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    double fx = bf.Length > 0 ? SvgNum.Parse(bf[0]) : 0, fy = bf.Length > 1 ? SvgNum.Parse(bf[1]) : fx;
                    int oct = (int)p.Num("numOctaves", 1); long seed = (long)Math.Round(p.Num("seed", 0));
                    bool fractal = p["type"] == "fractalNoise";
                    var T = Turbulence.For(seed);
                    var pt = new double[2];
                    for (int py = RY0; py <= RY1; py++)
                        for (int px = RX0; px <= RX1; px++)
                        {
                            var u = inv.Apply(new Vec2((px + 0.5) / ss, (py + 0.5) / ss));
                            pt[0] = u.X; pt[1] = u.Y;
                            int di = (py * src.W + px) * 4;
                            float a = 0; var col = new float[4];
                            for (int c = 0; c < 4; c++)
                            {
                                double v = T.Turb(c, pt, fx, fy, oct, fractal);
                                v = fractal ? (v + 1) / 2 : v;
                                col[c] = (float)Math.Max(0, Math.Min(1, v));
                            }
                            a = col[3];
                            for (int c = 0; c < 3; c++) o[di + c] = col[c] * a;
                            o[di + 3] = a;
                        }
                    break;
                }
                case "feColorMatrix":
                {
                    var A = In(p["in"]);
                    var type = p["type"] ?? "matrix";
                    var vals = (p["values"] ?? "").Split(new[] { ' ', ',', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var M = new double[20];
                    if (type == "matrix" && vals.Length >= 20) for (int k = 0; k < 20; k++) M[k] = SvgNum.Parse(vals[k]);
                    else if (type == "saturate")
                    {
                        double sv = vals.Length > 0 ? SvgNum.Parse(vals[0]) : 1;
                        M = new double[] { 0.213 + 0.787 * sv, 0.715 - 0.715 * sv, 0.072 - 0.072 * sv, 0, 0, 0.213 - 0.213 * sv, 0.715 + 0.285 * sv, 0.072 - 0.072 * sv, 0, 0, 0.213 - 0.213 * sv, 0.715 - 0.715 * sv, 0.072 + 0.928 * sv, 0, 0, 0, 0, 0, 1, 0 };
                    }
                    else if (type == "hueRotate")
                    {
                        double h = (vals.Length > 0 ? SvgNum.Parse(vals[0]) : 0) * Math.PI / 180, cs = Math.Cos(h), sn = Math.Sin(h);
                        M = new double[] { 0.213 + cs * 0.787 - sn * 0.213, 0.715 - cs * 0.715 - sn * 0.715, 0.072 - cs * 0.072 + sn * 0.928, 0, 0,
                                           0.213 - cs * 0.213 + sn * 0.143, 0.715 + cs * 0.285 + sn * 0.140, 0.072 - cs * 0.072 - sn * 0.283, 0, 0,
                                           0.213 - cs * 0.213 - sn * 0.787, 0.715 - cs * 0.715 + sn * 0.715, 0.072 + cs * 0.928 + sn * 0.072, 0, 0, 0, 0, 0, 1, 0 };
                    }
                    else if (type == "luminanceToAlpha") M = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.2125, 0.7154, 0.0721, 0, 0 };
                    else { M = new double[] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 }; }
                    for (int i = 0; i < n; i++)
                    {
                        int j = i * 4; float a = A[j + 3];
                        double r = a > 0 ? A[j] / a : 0, g = a > 0 ? A[j + 1] / a : 0, b = a > 0 ? A[j + 2] / a : 0;
                        double nr = M[0] * r + M[1] * g + M[2] * b + M[3] * a + M[4], ng = M[5] * r + M[6] * g + M[7] * b + M[8] * a + M[9];
                        double nb = M[10] * r + M[11] * g + M[12] * b + M[13] * a + M[14], na = M[15] * r + M[16] * g + M[17] * b + M[18] * a + M[19];
                        na = Math.Max(0, Math.Min(1, na));
                        o[j] = (float)(Math.Max(0, Math.Min(1, nr)) * na); o[j + 1] = (float)(Math.Max(0, Math.Min(1, ng)) * na); o[j + 2] = (float)(Math.Max(0, Math.Min(1, nb)) * na); o[j + 3] = (float)na;
                    }
                    break;
                }
                case "feDisplacementMap":
                {
                    var A = In(p["in"]); var B = In(p["in2"]);
                    double scale = p.Num("scale") * l.UserToPx.Scale * ss;
                    int xc = "RGBA".IndexOf((p["xChannelSelector"] ?? "A")[0]), yc = "RGBA".IndexOf((p["yChannelSelector"] ?? "A")[0]);
                    if (xc < 0) xc = 3; if (yc < 0) yc = 3;
                    for (int py = RY0; py <= RY1; py++)
                        for (int px = RX0; px <= RX1; px++)
                        {
                            int j = (py * src.W + px) * 4; float ba = B[j + 3];
                            double dx = ((xc == 3 ? ba : ba > 0 ? B[j + xc] / ba : 0) - 0.5) * scale, dy = ((yc == 3 ? ba : ba > 0 ? B[j + yc] / ba : 0) - 0.5) * scale;
                            int sx = (int)Math.Floor(px + dx + 0.5), sy = (int)Math.Floor(py + dy + 0.5);
                            if (sx < 0 || sy < 0 || sx >= src.W || sy >= src.H) continue;
                            int k = (sy * src.W + sx) * 4;
                            for (int c = 0; c < 4; c++) o[j + c] = A[k + c];
                        }
                    break;
                }
                case "feGaussianBlur":
                {
                    var A = In(p["in"]);
                    var sd = (p["stdDeviation"] ?? "0").Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    double sxd = (sd.Length > 0 ? SvgNum.Parse(sd[0]) : 0) * l.UserToPx.Scale * ss, syd = (sd.Length > 1 ? SvgNum.Parse(sd[1]) : sxd / (l.UserToPx.Scale * ss)) * (sd.Length > 1 ? l.UserToPx.Scale * ss : 1);
                    if (sd.Length <= 1) syd = sxd;
                    var tmp = Blur1D(A, src.W, src.H, sxd, true);
                    o = Blur1D(tmp, src.W, src.H, syd, false);
                    break;
                }
                case "feOffset":
                {
                    var A = In(p["in"]);
                    var d = l.UserToPx.ApplyVector(new Vec2(p.Num("dx"), p.Num("dy")));
                    int ox = (int)Math.Round(d.X * ss), oy = (int)Math.Round(d.Y * ss);
                    for (int py = RY0; py <= RY1; py++)
                        for (int px = RX0; px <= RX1; px++)
                        {
                            int sx = px - ox, sy = py - oy;
                            if (sx < 0 || sy < 0 || sx >= src.W || sy >= src.H) continue;
                            Array.Copy(A, (sy * src.W + sx) * 4, o, (py * src.W + px) * 4, 4);
                        }
                    break;
                }
                case "feFlood":
                {
                    Colors.TryParse(p.Prop("flood-color") ?? "#000", out var fc);
                    float fa = fc.A * (float)Math.Max(0, Math.Min(1, SvgNum.Parse(p.Prop("flood-opacity") ?? "1", 1)));
                    for (int i = 0; i < n; i++) { int j = i * 4; o[j] = (linear ? ToLin(fc.R) : fc.R) * fa; o[j + 1] = (linear ? ToLin(fc.G) : fc.G) * fa; o[j + 2] = (linear ? ToLin(fc.B) : fc.B) * fa; o[j + 3] = fa; }
                    break;
                }
                case "feMerge":
                {
                    foreach (var mn in p.Children)
                    {
                        if (mn.Tag != "feMergeNode") continue;
                        var A = In(mn["in"]);
                        for (int i = 0; i < n; i++) { int j = i * 4; float k = 1 - A[j + 3]; for (int c = 0; c < 4; c++) o[j + c] = A[j + c] + o[j + c] * k; }
                    }
                    break;
                }
                default:
                    Unsupported.Add(p.Tag);
                    Array.Copy(In(p["in"]), o, o.Length);
                    break;
            }
            // the filter region (x, y, width, height; objectBoundingBox units by default: -10 % / 120 %)
            ClipToRegion(o, src.W, src.H, ss, l, f);
            last = o;
            var res = p["result"];
            if (res != null) results[res] = o;
        }
        // back to sRGB, straight
        var outB = new Buffer(src.W, src.H);
        for (int i = 0; i < n; i++)
        {
            float a = Math.Min(1, last[i * 4 + 3]); outB.P[i * 4 + 3] = a;
            for (int c = 0; c < 3; c++) { float v = a > 0 ? Math.Min(1, last[i * 4 + c] / a) : 0; outB.P[i * 4 + c] = (linear ? ToSrgb(v) : v) * a; }
        }
        return outB;
    }

    static void ClipToRegion(float[] o, int w, int h, int ss, LayerNode l, SvgNode f)
    {
        var b = l.UserBox;
        if (b.IsEmpty) return;
        Box r;
        if (f["filterUnits"] == "userSpaceOnUse") r = new Box { X0 = f.Num("x", -1e6f), Y0 = f.Num("y", -1e6f), X1 = f.Num("x", -1e6f) + f.Num("width", 2e6f), Y1 = f.Num("y", -1e6f) + f.Num("height", 2e6f) };
        else
        {
            double fx = Colors.Fraction(f["x"], -0.1), fy = Colors.Fraction(f["y"], -0.1), fw = Colors.Fraction(f["width"], 1.2), fh = Colors.Fraction(f["height"], 1.2);
            r = new Box { X0 = b.X0 + fx * b.W, Y0 = b.Y0 + fy * b.H, X1 = b.X0 + (fx + fw) * b.W, Y1 = b.Y0 + (fy + fh) * b.H };
        }
        var inv = l.UserToPx.Inverse();
        for (int py = 0; py < h; py++)
            for (int px = 0; px < w; px++)
            {
                var u = inv.Apply(new Vec2((px + 0.5) / ss, (py + 0.5) / ss));
                if (u.X >= r.X0 && u.X <= r.X1 && u.Y >= r.Y0 && u.Y <= r.Y1) continue;
                int j = (py * w + px) * 4; o[j] = o[j + 1] = o[j + 2] = o[j + 3] = 0;
            }
    }

    static float[] Blur1D(float[] a, int w, int h, double sigma, bool horizontal)
    {
        var o = new float[a.Length];
        if (sigma <= 0) { Array.Copy(a, o, a.Length); return o; }
        int rad = (int)Math.Ceiling(sigma * 3);
        var k = new double[rad * 2 + 1]; double sum = 0;
        for (int i = -rad; i <= rad; i++) { k[i + rad] = Math.Exp(-i * i / (2 * sigma * sigma)); sum += k[i + rad]; }
        for (int i = 0; i < k.Length; i++) k[i] /= sum;
        for (int y = RY0; y <= RY1; y++)
            for (int x = RX0; x <= RX1; x++)
            {
                double r = 0, g = 0, b = 0, al = 0;
                for (int t = -rad; t <= rad; t++)
                {
                    int sx = horizontal ? x + t : x, sy = horizontal ? y : y + t;
                    if (sx < 0 || sy < 0 || sx >= w || sy >= h) continue;
                    int j = (sy * w + sx) * 4; double kk = k[t + rad];
                    r += a[j] * kk; g += a[j + 1] * kk; b += a[j + 2] * kk; al += a[j + 3] * kk;
                }
                int d = (y * w + x) * 4; o[d] = (float)r; o[d + 1] = (float)g; o[d + 2] = (float)b; o[d + 3] = (float)al;
            }
        return o;
    }

    // SS x SS box filter down to the output, over white, 8-bit
    public static byte[] Resolve(Buffer b, int ss, int W, int H)
    {
        var o = new byte[W * H * 4];
        float k = 1f / (ss * ss);
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                float r = 0, g = 0, bl = 0, a = 0;
                for (int sy = 0; sy < ss; sy++)
                    for (int sx = 0; sx < ss; sx++)
                    {
                        int i = ((y * ss + sy) * b.W + x * ss + sx) * 4;
                        r += b.P[i]; g += b.P[i + 1]; bl += b.P[i + 2]; a += b.P[i + 3];
                    }
                r *= k; g *= k; bl *= k; a *= k;
                int j = (y * W + x) * 4;
                o[j] = (byte)Math.Round(Math.Min(1, r + (1 - a)) * 255); o[j + 1] = (byte)Math.Round(Math.Min(1, g + (1 - a)) * 255); o[j + 2] = (byte)Math.Round(Math.Min(1, bl + (1 - a)) * 255); o[j + 3] = 255;
            }
        return o;
    }
}
