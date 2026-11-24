// dotnet run -c Release --project tools/unity/squishdoku-test -- play <capture dir>    (capture.mjs: the level, Play.cs)
// dotnet run -c Release --project tools/unity/squishdoku-test -- cards <capture dir>   (cards.mjs: the cards, Cards.cs)
// dotnet run -c Release --project tools/unity/squishdoku-test -- flow                  (touches and the level's flow, Flow.cs)
// dotnet run -c Release --project tools/unity/squishdoku-test -- blitz <capture dir>   (blitz.mjs: a Blitz run, Blitz.cs)
// dotnet run -c Release --project tools/unity/squishdoku-test -- screen <capture dir>  (screen.mjs: hub, map, slides, Screen.cs)
// dotnet run -c Release --project tools/unity/squishdoku-test -- blitzflow             (Blitz's, the shared run's and the
//                                                                                        screen's flows, BlitzFlow.cs)
// (cards.mjs also shoots the shared Blitz cards, Ui/Blitz: sd-revive, sd-blitzfail, sd-blitzwin)
// Plays Squishdoku from the Unity code (Games/Squishdoku: SdLevel, SdCards) on the same clock as the app's page, draws
// every layer where it is with the reference rasteriser, and compares the screen with the app's picture of the same
// moment: the % of pixels that differ visibly (any channel by more than 24 of 255).
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static int Main(string[] args)
    {
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        Card.LoadXml = n => File.ReadAllText(Res("Cards/" + n + ".xml"));
        // as the page: Expo web plays a native-driver loop once; Math.random is 0.5 (capture.mjs)
        Fx.LikeWeb = true;
        Fx.Random = SdLevel.Random = () => 0.5;
        if (args[0] == "cards") return CardsTest.Run(args[1]);
        if (args[0] == "play") return PlayTest.Run(args[1]);
        if (args[0] == "flow") return FlowTest.Run();
        if (args[0] == "blitz") return BlitzTest.Run(args[1]);
        if (args[0] == "screen") return ScreenTest.Run(args[1]);
        if (args[0] == "blitzflow") return BlitzFlowTest.Run();
        Console.WriteLine("play <dir> | cards <dir> | flow | blitz <dir> | screen <dir> | blitzflow");
        return 1;
    }

    // ---- drawing layers as one SVG, as UiPiece shows them -------------------------------------------------------------
    /// <summary>Device pixels per dp to put untransformed layers on whole pixels (as UiPiece may), or 0.</summary>
    public static double SnapPx = Environment.GetEnvironmentVariable("SD_SNAP") != null ? 2.8125 : 0;

    static string R(double v) => v.ToString("R", System.Globalization.CultureInfo.InvariantCulture);

    static string Nest(string svg, string p)
    {
        int a = svg.IndexOf('>') + 1;
        var inner = svg.Substring(a, svg.LastIndexOf("</svg>") - a);
        return inner.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
    }

    /// <summary>Each layer: its markup drawn in its box plus its margin (the texture UiPiece makes), or its picture filling
    /// the box; transformed, faded.</summary>
    public static string Screen(IEnumerable<SdLayer> layers, float w = 832, float h = 384)
    {
        var sb = new StringBuilder($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{UiSvg.F(w)}\" height=\"{UiSvg.F(h)}\" viewBox=\"0 0 {UiSvg.F(w)} {UiSvg.F(h)}\">");
        int n = 0;
        foreach (var l in layers)
        {
            if (!l.Visible || l.Opacity <= 0) continue;
            var p = "p" + n++ + "-";
            var m = l.Transform;
            if (SnapPx > 0 && m.A == 1 && m.D == 1 && m.B == 0 && m.C == 0)
                m = new Affine(1, 0, 0, 1, Math.Round(m.E * SnapPx) / SnapPx, Math.Round(m.F * SnapPx) / SnapPx);
            string op = l.Opacity < 1 ? $" opacity=\"{R(Math.Max(0, l.Opacity))}\"" : "";
            sb.Append($"<g transform=\"matrix({R(m.A)} {R(m.B)} {R(m.C)} {R(m.D)} {R(m.E)} {R(m.F)})\"{op}>");
            if (l.Picture != null)
                sb.Append($"<image href=\"{l.Picture}\" x=\"0\" y=\"0\" width=\"{R(l.W)}\" height=\"{R(l.H)}\" preserveAspectRatio=\"none\"/>");
            else if (l.Markup != null)
            {
                sb.Append($"<defs><clipPath id=\"{p}room\"><rect x=\"{UiSvg.F(-l.Margin)}\" y=\"{UiSvg.F(-l.Margin)}\" width=\"{UiSvg.F(l.W + 2 * l.Margin)}\" height=\"{UiSvg.F(l.H + 2 * l.Margin)}\"/></clipPath></defs>");
                sb.Append($"<g clip-path=\"url(#{p}room)\">{Nest(l.Markup, p)}</g>");
            }
            sb.Append("</g>");
        }
        return sb.Append("</svg>").ToString();
    }

    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    static (int, int, float[]) Load(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Res(href + ".png");
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    /// <summary>Draws `svg` at the app picture's size, writes it and the diff, and counts the pixels that differ visibly
    /// (outside `skip`: rectangles in dp the comparison leaves out).</summary>
    public static double Compare(string svg, string appPng, string outPng, string diffPng, out int visible, out int total, params (float x0, float y0, float x1, float y1)[] skip)
    {
        var (W, H, reference) = Png.Read(appPng);
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), W, H, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var ours = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, W, H, 2), 2, W, H);
        Png.Write(outPng, W, H, ours);
        double k = W / 832.0;
        visible = 0; total = 0;
        var diff = new byte[W * H * 4];
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                bool skipped = false;
                foreach (var s in skip) if (x >= s.x0 * k && x < s.x1 * k && y >= s.y0 * k && y < s.y1 * k) skipped = true;
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                bool v = d > 24 && !skipped;
                if (!skipped) { total++; if (v) visible++; }
                byte g = (byte)(ours[i] * 0.3 + (skipped ? 60 : 150));
                diff[i] = v ? (byte)255 : g; diff[i + 1] = v ? (byte)0 : g; diff[i + 2] = v ? (byte)60 : g; diff[i + 3] = 255;
            }
        Png.Write(diffPng, W, H, diff);
        return 100.0 * visible / total;
    }
}
