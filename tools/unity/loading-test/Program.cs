// Squish Time's loading beat and sky, from the Unity code, against the app:
//
//   node tools/unity/loading-test/capture.mjs <dir>
//   dotnet run -c Release --project tools/unity/loading-test -- shots <dir>
//       each of capture.mjs's shots (LoadingScreen.js on the virtual clock, SkyBackground.js) drawn from
//       Games/Squish/SquishLoading.cs / SquishSky.cs at the same moment with the reference rasteriser
//       (tools/unity/vector-test) and compared with Chrome's screenshot: the share of pixels that differ visibly (any
//       channel > 24).
//   dotnet run -c Release --project tools/unity/loading-test -- frames <dir> [fps] [key]
//       the beat as Unity plays it, frame by frame (prep: the card comes at 900 ms; then the screen it fades to, the
//       sky): <dir>/frame-NNNN.png, for a video.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Games.Squish;
using SquishSquad.Screens;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);
    const float W = 832, H = 384;

    static int Main(string[] args)
    {
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        Roster.ReadText = n => File.Exists(Res(n + ".json")) ? File.ReadAllText(Res(n + ".json")) : null;
        string mode = args.Length > 0 ? args[0] : "shots";
        if (mode == "frames") return Frames(args[1], args.Length > 2 ? int.Parse(args[2]) : 30, args.Length > 3 ? args[3] : "mittens");
        return Shots(args.Length > 1 ? args[1] : "loading-shots");
    }

    // the beat at `ms` after it came up (prep: the card in at `cardAt`)
    static string Beat(string key, bool quick, double cardAt, double ms, out float opacity)
    {
        var b = new SquishLoading(key, W, H, quick, 0);
        // (ticked in frames as the app's: the card's arrival is seen on the next one)
        for (double t = 0; ; t = Math.Min(ms, t + 16))
        {
            if (!quick && t >= cardAt) b.ModelReady();
            b.Tick(t);
            if (t >= ms) break;
        }
        opacity = b.Opacity;
        return Pieces.Compose(b.Pieces(), W, H);
    }

    static int Shots(string dir)
    {
        var shots = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "shots.json"))).RootElement.EnumerateArray().ToList();
        double sum = 0; int n = 0;
        foreach (var s in shots)
        {
            string name = s.GetProperty("file").GetString().Replace(".png", "");
            // (the page's beat starts two frames after its mount, and fades over the black box it's mounted in)
            string svg = s.GetProperty("sky").GetBoolean()
                ? SquishSky.Svg(W, H)
                : OverBlack(Beat(s.GetProperty("key").GetString(), s.GetProperty("quick").GetBoolean(), s.GetProperty("cardAt").GetDouble(), Math.Max(0, s.GetProperty("ms").GetDouble() - 32), out _));
            var (pct, _) = Compare(svg, Path.Combine(dir, name + ".png"), Path.Combine(dir, name + ".unity.png"), Path.Combine(dir, name + ".diff.png"));
            Console.WriteLine($"{name,-24} {pct,6:0.00} % of pixels differ visibly");
            sum += pct; n++;
        }
        Console.WriteLine($"mean {sum / Math.Max(1, n):0.00} % over {n} shots");
        return 0;
    }

    static int Frames(string dir, int fps, string key)
    {
        Directory.CreateDirectory(dir);
        const float k = 1.25f;   // (frames at 1040 x 480 px: small enough to draw quickly)
        int w = (int)(W * k), h = (int)(H * k), f = 0;
        string sky = SquishSky.Svg(W, H);
        double step = 1000.0 / fps;
        // the "prep" beat (the card arriving at 900 ms), then 0.8 s of the sky it fades to
        for (double ms = 0; ; ms += step)
        {
            var beat = Beat(key, false, 900, ms, out float op);
            string frame = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\">"
                + Inner(sky) + (op > 0 ? $"<g opacity=\"{op:0.###}\">{Inner(beat)}</g>" : "") + "</svg>";
            Png.Write(Path.Combine(dir, $"frame-{f++:0000}.png"), w, h, Draw(frame, w, h));
            if (op <= 0 && ms > 2600) break;
        }
        Console.WriteLine($"{f} frames at {fps} fps in {dir}");
        return 0;
    }

    static string OverBlack(string svg) => $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\"><rect width=\"{W}\" height=\"{H}\" fill=\"#000\"/>{Inner(svg)}</svg>";

    // an SVG's content without its root element (for nesting), ids prefixed
    static int _pre;
    static string Inner(string svg)
    {
        int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>");
        var p = "n" + (_pre++) + "-";
        return svg.Substring(a, b - a).Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
    }

    // ---- drawing and comparing ---------------------------------------------------------------------------------------
    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    static (int, int, float[]) LoadImage(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Res(href + ".png");
        if (!File.Exists(f) && File.Exists(Res(href + ".jpg")))
        {
            f = Path.Combine(Path.GetTempPath(), "loading-test-" + href.Replace('/', '_') + ".png");
            if (!File.Exists(f))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("python3", $"-c \"from PIL import Image; Image.open('{Res(href + ".jpg")}').convert('RGBA').save('{f}')\"") { UseShellExecute = false })!.WaitForExit();
        }
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    static byte[] Draw(string svg, int w, int h)
    {
        ReferenceRaster.LoadImage = LoadImage;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), w, h, Affine.Identity, href => { var i = LoadImage(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        return ReferenceRaster.Resolve(ReferenceRaster.Render(scene, w, h, 2), 2, w, h);
    }

    static (double pct, int n) Compare(string svg, string appPng, string outPng, string diffPng)
    {
        var (w, h, reference) = Png.Read(appPng);
        var ours = Draw(svg, w, h);
        Png.Write(outPng, w, h, ours);
        int visible = 0;
        var diff = new byte[w * h * 4];
        for (int i = 0; i < w * h * 4; i += 4)
        {
            int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
            bool bad = d > 24;
            if (bad) visible++;
            byte g = (byte)(reference[i] * 0.3 + 150);
            diff[i] = bad ? (byte)255 : g; diff[i + 1] = bad ? (byte)0 : g; diff[i + 2] = bad ? (byte)60 : g; diff[i + 3] = 255;
        }
        Png.Write(diffPng, w, h, diff);
        return (100.0 * visible / (w * h), visible);
    }
}
