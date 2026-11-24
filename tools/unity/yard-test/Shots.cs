// dotnet run ... -- shots <dir> [game]: the game as Unity shows it (the page's wood, the frame, the game's own layers and
// creatures from the compiled realm, Games/Yard/View/YardGameArt.cs's top bar and cards) at three moments: the intro
// (3 s after it opens), the game (2.5 s after PLAY), the results (2.5 s after the game ends); each drawn with the
// reference rasteriser at the A15's size and, where <dir>/<game>-<moment>.png is the app's (capture.mjs), compared.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Creatures.Js;
using SquishSquad.Games.Yard;
using SquishSquad.Games.Yard.View;
using SquishSquad.Ui;
using SquishSquad.Vector;

static partial class Program
{
    const int PW = 2340, PH = 1080, SS = 2;
    const double DPR = 2.8125;

    static int Shots(string dir, string game = "hoop")
    {
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
        SvgText.Install();
        Directory.CreateDirectory(dir);
        var model = new YardGameModel(PW / DPR, PH / DPR);
        double now = 0;
        void Run(double ms) { for (double t = 0; t < ms; t += 16) { RigHost.Frame(16); now += 16; model.Draw(YardJs.Ui(), now); } }
        if (!YardJs.Open(game, "mittens")) return 1;
        Run(3000); Shot(dir, game + "-intro", model, now);
        YardJs.Click("play"); Run(2500); Shot(dir, game + "-play", model, now);
        Rt.Invoke(Rt.Get(Rt.Get(Rt.G("YardGames"), "_cur"), "ctx"), "finish", Rt.Invoke(Rt.G("JSON"), "parse", "{\"delay\":0}"));
        Run(2500); Shot(dir, game + "-result", model, now);
        return 0;
    }

    static int _nest;
    // an <svg> element's markup nested in the composite: its ids made its own
    static string Nest(string svg, string extraAttrs, bool own = true)
    {
        string p = "n" + (++_nest) + "-";
        if (own) svg = svg.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p).Replace("url(&quot;#", "url(&quot;#" + p);
        int a = svg.IndexOf("<svg", StringComparison.Ordinal);
        if (a < 0) return "";
        // (the element's own size attributes go: the caller places it)
        int b = svg.IndexOf('>', a);
        var head = System.Text.RegularExpressions.Regex.Replace(svg.Substring(a, b - a), "\\s(x|y|width|height|style|class)=\"[^\"]*\"", "");
        return head + " " + extraAttrs + svg.Substring(b);
    }

    static string M(Affine m) => $"matrix({F(m.A)} {F(m.B)} {F(m.C)} {F(m.D)} {F(m.E)} {F(m.F)})";
    static string F(double v) => UiSvg.F(v);

    static void Shot(string dir, string name, YardGameModel model, double now)
    {
        var u = YardJs.Ui();
        var g = model.G;
        var sb = new StringBuilder();
        double k = DPR;   // dp -> px
        sb.Append($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{PW}\" height=\"{PH}\" viewBox=\"0 0 {PW} {PH}\">");
        sb.Append($"<image href=\"Yard/page/bg\" x=\"0\" y=\"0\" width=\"{PW}\" height=\"{PH}\" preserveAspectRatio=\"none\"/>");
        void Draw(YardDraw d) => sb.Append($"<g transform=\"scale({F(k)}) {M(d.M)}\" opacity=\"{F(d.Opacity)}\">{Nest(d.Svg, $"width=\"{F(d.W * g.K)}\" height=\"{F(d.H * g.K)}\" overflow=\"visible\"")}</g>");
        Draw(model.Frame(u.Phase == "intro" ? "#24103e" : "#eaf7ff"));
        // the game's stage, cut to the frame
        var st = g.Stage;
        sb.Append($"<defs>{model.ClipPath("frame")}</defs><g transform=\"scale({F(k)}) {M(st)}\" clip-path=\"url(#frame)\">");
        foreach (var el in YardJs.Stage())
        {
            // (the stage's layers share one document's ids, as on the page: a gradient in the bg's defs paints the fg)
            if (YardJs.Tag(el) == "svg") { sb.Append(Nest(YardJs.Markup(el), "x=\"0\" y=\"0\" width=\"780\" height=\"360\" preserveAspectRatio=\"none\" overflow=\"visible\"", false)); continue; }
            if (!YardJs.Has(el, "yg-crl")) continue;
            var hosts = YardJs.Children(el);
            var order = new List<(double z, int i)>(); for (int i = 0; i < hosts.Count; i++) order.Add((YardJs.Box(hosts[i])[7], i));
            order.Sort((a, b) => a.z != b.z ? a.z.CompareTo(b.z) : a.i.CompareTo(b.i));
            foreach (var (_, i) in order)
            {
                var b = YardJs.Box(hosts[i]); if (b[8] > 0 || b[9] > 0) continue;
                var svg = YardJs.FirstSvg(hosts[i]); if (svg.IsNullish) continue;
                double x = 780 * b[0] / 100, y = 360 * b[1] / 100, w = 780 * b[2] / 100, h = 360 * b[3] / 100, ox = x + w * b[5] / 100, oy = y + h * b[6] / 100;
                var markup = YardJs.Markup(svg).Replace("href=\"shim-canvas:", "data-x=\"");
                sb.Append($"<g transform=\"rotate({F(b[4])} {F(ox)} {F(oy)})\">{Nest(markup, $"x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" overflow=\"visible\"")}</g>");
            }
        }
        if (u.Phase == "intro")
        {
            var art = YardJs.Art();
            var psvg = art.IsNullish ? V.Null : YardJs.FirstSvg(art);
            if (!psvg.IsNullish) sb.Append(Nest(YardJs.Markup(psvg).Replace("href=\"shim-canvas:", "data-x=\""), "x=\"0\" y=\"0\" width=\"780\" height=\"360\" overflow=\"visible\""));
        }
        sb.Append("</g>");
        foreach (var d in model.Draw(u, now)) Draw(d);
        sb.Append("</svg>");
        File.WriteAllText(Path.Combine(dir, "unity-" + name + ".svg"), sb.ToString());
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(sb.ToString()), PW, PH, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var px = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, PW, PH, SS), SS, PW, PH);
        Png.Write(Path.Combine(dir, "unity-" + name + ".png"), PW, PH, px);
        var app = Path.Combine(dir, name + ".png");
        if (!File.Exists(app)) { Console.WriteLine($"{name}: drawn (no app shot to compare)"); return; }
        var (w0, h0, reference) = Png.Read(app);
        if (w0 != PW || h0 != PH) { Console.WriteLine($"{name}: the app's shot is {w0}x{h0}"); return; }
        int visible = 0; var diff = new byte[PW * PH * 4];
        for (int i = 0; i < PW * PH * 4; i += 4)
        {
            int dd = Math.Max(Math.Abs(reference[i] - px[i]), Math.Max(Math.Abs(reference[i + 1] - px[i + 1]), Math.Abs(reference[i + 2] - px[i + 2])));
            bool v = dd > 24; if (v) visible++;
            byte gr = (byte)(px[i] * 0.3 + 150);
            diff[i] = v ? (byte)255 : gr; diff[i + 1] = v ? (byte)0 : gr; diff[i + 2] = v ? (byte)60 : gr; diff[i + 3] = 255;
        }
        Png.Write(Path.Combine(dir, "diff-" + name + ".png"), PW, PH, diff);
        Console.WriteLine($"{name}: {visible} of {PW * PH} px differ visibly ({100.0 * visible / (PW * PH):0.00} %)");
    }

    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    static (int, int, float[]) Load(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        string f = null;
        foreach (var ext in new[] { ".png.bytes", ".jpg.bytes", ".png" }) { var p = Res(href + ext); if (File.Exists(p)) { f = p; break; } }
        if (f == null) return Images[href] = (0, 0, null);
        byte[] bytes = File.ReadAllBytes(f);
        (int w, int h, byte[] rgba) img;
        if (f.Contains(".jpg")) img = Jpeg(bytes); else { var tmp = Path.GetTempFileName(); File.WriteAllBytes(tmp, bytes); img = Png.Read(tmp); File.Delete(tmp); }
        if (img.rgba == null) return Images[href] = (0, 0, null);
        var px = new float[img.w * img.h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = img.rgba[i] / 255f;
        return Images[href] = (img.w, img.h, px);
    }
    // (a JPEG: decoded by the system's tools when there's one; else none)
    static (int, int, byte[]) Jpeg(byte[] b)
    {
        try
        {
            var tmp = Path.GetTempFileName() + ".jpg"; File.WriteAllBytes(tmp, b);
            var png = tmp + ".png";
            var p = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("python", $"-c \"from PIL import Image; Image.open(r'{tmp}').convert('RGBA').save(r'{png}')\"") { UseShellExecute = false });
            p.WaitForExit();
            var r = Png.Read(png); File.Delete(tmp); File.Delete(png); return r;
        }
        catch (Exception) { return (0, 0, null); }
    }
}
