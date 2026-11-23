// Draws a game screen as Unity shows it, with the reference rasteriser: the exported page (PageBg), then each layer
// (an SVG in its box plus its margin, or a picture filling its box; a Sort door projected with its perspective, as
// SortDoorPiece's mesh does), transformed and faded as UiPiece places it, then the cards' layers; and compares it with
// the app's screenshot.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SquishSquad.Games.Shared;
using SquishSquad.Games.Sort;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class Render
{
    const int SS = 2;
    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();

    static string Png(string href)
    {
        if (href.EndsWith(".jpg"))
        {
            // the world's JPEG bytes (Resources/<path>.bytes), decoded once to a PNG next to the test
            var png = Path.Combine(AppContext.BaseDirectory, href.Replace('/', '_') + ".png");
            if (!File.Exists(png))
            {
                var p = Process.Start(new ProcessStartInfo("python3", $"-c \"import sys; from PIL import Image; Image.open(sys.argv[1]).convert('RGBA').save(sys.argv[2])\" \"{Program.Res(href + ".bytes")}\" \"{png}\"") { UseShellExecute = false });
                p.WaitForExit();
            }
            return png;
        }
        return Program.Res(href + ".png");
    }

    static (int, int, float[]) Load(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Png(href);
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = global::Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    static string R(double v) => v.ToString("R", System.Globalization.CultureInfo.InvariantCulture);

    static string Nest(string svg, string p)
    {
        int a = svg.IndexOf('>') + 1;
        var inner = svg.Substring(a, svg.LastIndexOf("</svg>") - a);
        return inner.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
    }

    static void Layer(StringBuilder sb, ref int n, string markup, string picture, float w, float h, float margin, Affine m, float opacity)
    {
        var p = "p" + n++ + "-";
        sb.Append($"<g transform=\"matrix({R(m.A)} {R(m.B)} {R(m.C)} {R(m.D)} {R(m.E)} {R(m.F)})\"{(opacity < 1 ? $" opacity=\"{R(Math.Max(0, opacity))}\"" : "")}>");
        if (picture != null)
            sb.Append($"<image href=\"{picture}\" x=\"0\" y=\"0\" width=\"{UiSvg.F(w)}\" height=\"{UiSvg.F(h)}\" preserveAspectRatio=\"{(picture.EndsWith(".jpg") ? "none" : "xMidYMid meet")}\"/>");
        else
        {
            sb.Append($"<defs><clipPath id=\"{p}room\"><rect x=\"{UiSvg.F(-margin)}\" y=\"{UiSvg.F(-margin)}\" width=\"{UiSvg.F(w + 2 * margin)}\" height=\"{UiSvg.F(h + 2 * margin)}\"/></clipPath></defs>");
            sb.Append($"<g clip-path=\"url(#{p}room)\">{Nest(markup, p)}</g>");
        }
        sb.Append("</g>");
    }

    static (int, int)? Size(string href) { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); }

    static ReferenceRaster.Buffer Svg(string svg, int W, int H)
    {
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), W, H, Affine.Identity, Size);
        return ReferenceRaster.Render(scene, W, H, SS);
    }

    static void Over(ReferenceRaster.Buffer acc, ReferenceRaster.Buffer top)
    {
        for (int i = 0; i < acc.P.Length; i += 4)
        {
            float a = top.P[i + 3];
            if (a <= 0) continue;
            float k = 1 - a;
            acc.P[i] = top.P[i] + acc.P[i] * k; acc.P[i + 1] = top.P[i + 1] + acc.P[i + 1] * k; acc.P[i + 2] = top.P[i + 2] + acc.P[i + 2] * k; acc.P[i + 3] = a + acc.P[i + 3] * k;
        }
    }

    // a door: its face drawn on its own, every screen sample inside its projected outline takes the face's colour where
    // it falls on the door (the projection's inverse), as sort-test's Render does
    static void Door(ReferenceRaster.Buffer acc, ScreenLayer l, double k)
    {
        var d = l.Door;
        float m = l.Margin;
        int tw = (int)Math.Ceiling((l.W + 2 * m) * k), th = (int)Math.Ceiling((l.H + 2 * m) * k);
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(l.Markup), l.W * k, l.H * k, Affine.Translate(m * k, m * k), Size);
        var tex = ReferenceRaster.Render(scene, tw, th, SS);
        int TW = tw * SS, TH = th * SS;
        var corners = new[] { d.Map(-m, -m), d.Map(l.W + m, -m), d.Map(l.W + m, l.H + m), d.Map(-m, l.H + m) };
        double x0 = double.MaxValue, y0 = double.MaxValue, x1 = double.MinValue, y1 = double.MinValue;
        foreach (var c in corners) { x0 = Math.Min(x0, c.X); y0 = Math.Min(y0, c.Y); x1 = Math.Max(x1, c.X); y1 = Math.Max(y1, c.Y); }
        var inv = d.Post.Inverse();
        double a = d.Deg * Math.PI / 180, sn = Math.Sin(a), cs = Math.Cos(a), p = d.Persp, sg = d.Sign;
        int sx0 = Math.Max(0, (int)(x0 * k * SS) - 1), sx1 = Math.Min(acc.W - 1, (int)(x1 * k * SS) + 1);
        int sy0 = Math.Max(0, (int)(y0 * k * SS) - 1), sy1 = Math.Min(acc.H - 1, (int)(y1 * k * SS) + 1);
        float op = l.Opacity;
        for (int sy = sy0; sy <= sy1; sy++)
            for (int sx = sx0; sx <= sx1; sx++)
            {
                var q = inv.Apply(new Vec2((sx + 0.5) / SS / k, (sy + 0.5) / SS / k));
                double X = q.X - d.W / 2.0;
                double den = X * sn - p * cs;
                if (Math.Abs(den) < 1e-9) continue;
                double x1v = p * (sg * d.W / 2.0 - X) / den;
                double kk = p / (p + x1v * sn);
                if (kk <= 0) continue;
                double u = x1v + d.W / 2.0 + sg * d.W / 2.0, v = (q.Y - d.H / 2.0) / kk + d.H / 2.0;
                double tx = (u + m) * k * SS - 0.5, ty = (v + m) * k * SS - 0.5;
                int ix = (int)Math.Floor(tx), iy = (int)Math.Floor(ty);
                if (ix < -1 || iy < -1 || ix >= TW || iy >= TH) continue;
                double fx = tx - ix, fy = ty - iy;
                double r = 0, g = 0, b = 0, al = 0;
                for (int j = 0; j < 4; j++)
                {
                    int px = ix + (j & 1), py = iy + (j >> 1);
                    if (px < 0 || py < 0 || px >= TW || py >= TH) continue;
                    double wgt = ((j & 1) == 1 ? fx : 1 - fx) * ((j >> 1) == 1 ? fy : 1 - fy);
                    int ti = (py * TW + px) * 4;
                    r += tex.P[ti] * wgt; g += tex.P[ti + 1] * wgt; b += tex.P[ti + 2] * wgt; al += tex.P[ti + 3] * wgt;
                }
                if (al <= 0) continue;
                r *= op; g *= op; b *= op; al *= op;
                int ai = (sy * acc.W + sx) * 4;
                double kf = 1 - al;
                acc.P[ai] = (float)(r + acc.P[ai] * kf); acc.P[ai + 1] = (float)(g + acc.P[ai + 1] * kf); acc.P[ai + 2] = (float)(b + acc.P[ai + 2] * kf); acc.P[ai + 3] = (float)(al + acc.P[ai + 3] * kf);
            }
    }

    public static byte[] Draw(string bg, IReadOnlyList<ScreenLayer> layers, IEnumerable<Card> cards, int W, int H, string svgOut = null)
    {
        double k = W / 832.0;
        ReferenceRaster.Buffer acc = null;
        var sb = new StringBuilder();
        var all = new StringBuilder();
        int n = 0;
        void Begin() { sb.Clear(); sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">"); }
        void Flush()
        {
            sb.Append("</svg>");
            all.Append(sb.ToString()).Append('\n');
            var b = Svg(sb.ToString(), W, H);
            if (acc == null) acc = b; else Over(acc, b);
            Begin();
        }
        Begin();
        sb.Append(Nest(bg, "bg-"));
        foreach (var l in layers)
        {
            if (!l.Visible || l.Opacity <= 0) continue;
            if (l.Door != null) { Flush(); Door(acc, l, k); continue; }
            if (l.Markup == null && l.Picture == null) continue;
            Layer(sb, ref n, l.Markup, l.Picture, l.W, l.H, l.Margin, l.Transform, l.Opacity);
        }
        foreach (var c in cards)
            foreach (var l in c.Layers())
            {
                if (!l.Visible || l.Opacity <= 0 || l.Markup == null) continue;
                Layer(sb, ref n, l.Markup, null, l.W, l.H, l.Margin, l.Transform, l.Opacity);
            }
        Flush();
        if (svgOut != null) File.WriteAllText(svgOut, all.ToString());
        return ReferenceRaster.Resolve(acc, SS, W, H);
    }

    public static (int visible, int total) Compare(string bg, IReadOnlyList<ScreenLayer> layers, IEnumerable<Card> cards, string appPng, string outPng, string diffPng)
    {
        var (W, H, reference) = global::Png.Read(appPng);
        var ours = Draw(bg, layers, cards, W, H, Path.ChangeExtension(outPng, ".svg"));
        global::Png.Write(outPng, W, H, ours);
        int visible = 0, total = W * H;
        var diff = new byte[W * H * 4];
        for (int i = 0; i < W * H * 4; i += 4)
        {
            int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
            bool v = d > 24;
            if (v) visible++;
            byte gr = (byte)(ours[i] * 0.3 + 150);
            diff[i] = v ? (byte)255 : gr; diff[i + 1] = v ? (byte)0 : gr; diff[i + 2] = v ? (byte)60 : gr; diff[i + 3] = 255;
        }
        global::Png.Write(diffPng, W, H, diff);
        return (visible, total);
    }
}
