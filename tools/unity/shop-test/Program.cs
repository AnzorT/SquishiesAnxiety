// The Unity port's Shop, chest opening and Level Road, checked against the app:
//
//   node tools/unity/shop-test/capture.mjs <dir> [shot ...]
//   dotnet run -c Release --project tools/unity/shop-test -- shots <dir> [shot ...]
//       each shot (shots.mjs: a Preview.js screen and its made-up player, or the chest smash's own page; taps at set
//       moments of a virtual clock) rebuilt from the Unity code on the same clock, frames 16 ms apart; at each moment
//       shot, its pieces drawn with the reference rasteriser (tools/unity/vector-test) and compared with Chrome's
//       screenshot: the share of pixels that differ visibly (any channel > 24), outside the shot's masks.
//   dotnet run --project tools/unity/shop-test -- emu
//       the `squad` moves these screens call, through the Unity Backend client against the Firebase Local Emulator
//       Suite (tools/unity/backend/start-emulators.sh; 127.0.0.1 only).
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Screens;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

static partial class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static async Task<int> Main(string[] args)
    {
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        Roster.ReadText = n => File.Exists(Res(n + ".json")) ? File.ReadAllText(Res(n + ".json")) : File.Exists(Res(n + ".xml")) ? File.ReadAllText(Res(n + ".xml")) : null;
        string mode = args.Length > 0 ? args[0] : "shots";
        if (mode == "emu") return await Emu.Run();
        return Shots(args.Length > 1 ? args[1] : "shop-shots", args.Skip(2).ToArray());
    }

    const float W = 832, H = 384;
    /// <summary>The virtual clock's start (tools/unity/rig/virtual-clock.js T0: 2026-11-13 12:00 UTC), the page's time zone UTC.</summary>
    static readonly DateTime T0 = new DateTime(2026, 11, 13, 12, 0, 0, DateTimeKind.Unspecified);

    static int Shots(string dir, string[] only)
    {
        var shots = Prof.List(Json.Parse(File.ReadAllText(Path.Combine(dir, "shots.json"))));
        foreach (var o in shots)
        {
            var shot = Prof.Map(o);
            string name = (string)shot["name"];
            if (only.Length > 0 && !only.Contains(name)) continue;
            var t = new Ticker(0);
            Ticker.Default = t;
            var view = Make(shot, t);
            if (view == null) { Console.WriteLine($"{name}: no Unity view"); continue; }
            var masks = (Prof.List(Prof.Get(shot, "mask")) ?? new List<object>()).Select(m => Prof.List(m).Select(v => (float)Prof.Num(v)).ToArray()).Select(a => new Frame(a[0], a[1], a[2], a[3])).ToArray();
            var events = new List<(double ms, float[] tap)>();
            foreach (var tp in Prof.List(Prof.Get(shot, "taps")) ?? new List<object>()) { var a = Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray(); events.Add((a[0], new[] { a[1], a[2] })); }
            foreach (var tp in Prof.List(Prof.Get(shot, "drag")) ?? new List<object>()) { var a = Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray(); events.Add((a[0], new[] { a[1], a[2], a[3], 0 })); }
            foreach (var tp in Prof.List(Prof.Get(shot, "wheel")) ?? new List<object>()) { var a = Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray(); events.Add((a[0], new[] { a[1], a[2], a[3] })); }
            foreach (var tp in Prof.List(Prof.Get(shot, "wheelX")) ?? new List<object>()) { var a = Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray(); events.Add((a[0], new[] { a[1], a[2], a[3] })); }
            foreach (var tp in Prof.List(Prof.Get(shot, "scrollTo")) ?? new List<object>()) { var a = Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray(); events.Add((a[0], new[] { 416f, 250, a[1] })); }
            foreach (var ms in Prof.List(shot["at"])) events.Add((Prof.Num(ms), null));
            events = events.OrderBy(e => e.ms).ThenBy(e => e.tap == null ? 1 : 0).ToList();
            foreach (var (ms, tap) in events)
            {
                while (t.Now < ms) { t.Tick(Math.Min(t.Now + 16, ms)); Frame(view); }
                if (tap != null && tap.Length == 4)
                {
                    view.Down(tap[0], tap[1]);
                    for (int i = 1; i <= 6; i++) view.Move(tap[0] + tap[2] * i / 6, tap[1]);
                    view.Up(tap[0] + tap[2], tap[1]);
                    continue;
                }
                if (tap != null && tap.Length == 3) { view.Pieces(); if (view is IWheel wv) wv.Wheel(tap[0], tap[1], tap[2]); continue; }
                if (tap != null) { view.Pieces(); view.Down(tap[0], tap[1]); view.Up(tap[0], tap[1]); continue; }
                var app = Path.Combine(dir, $"{name}-{ms}.png");
                if (!File.Exists(app)) { Console.WriteLine($"{name}-{ms}: no {app}"); continue; }
                var svg = Pieces.Compose(view.Pieces(), W, H);
                File.WriteAllText(Path.Combine(dir, $"{name}-{ms}.unity.svg"), svg);
                var (pct, _) = Compare(svg, app, Path.Combine(dir, $"{name}-{ms}.unity.png"), Path.Combine(dir, $"{name}-{ms}.diff.png"), masks);
                Console.WriteLine($"{name + "-" + ms,-26} {pct,6:0.00} % of pixels differ visibly{(masks.Length > 0 ? " (outside the masks)" : "")}");
            }
        }
        if (ReferenceRaster.Unsupported.Count > 0) Console.WriteLine("unsupported: " + string.Join(", ", ReferenceRaster.Unsupported));
        return 0;
    }

    /// <summary>Some views take their pieces each frame (what they show moves on the frame, as React renders it). The
    /// Shop's too, as its host draws it: the Deals, Special offers and Gems cards' loops start the frame they're first
    /// drawn (as each mounts in the app).</summary>
    static void Frame(IScreenView v) { if (v is IFramed f) f.Frame(); else if (v is ShopView) v.Pieces(); }

    // ---- drawing and comparing (as tools/unity/screens-test) ------------------------------------------------------------
    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    public static (int, int, float[]) LoadImage(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Res(href + ".png");
        if (!File.Exists(f))
        {
            // a JPEG: decoded once to a PNG next to the tests' output (Pillow)
            var jpg = Res(href + ".jpg");
            if (!File.Exists(jpg)) return (0, 0, null);
            f = Path.Combine(Path.GetTempPath(), "shop-test-" + href.Replace('/', '_') + ".png");
            if (!File.Exists(f)) Process.Start("python3", new[] { "-c", "import sys; from PIL import Image; Image.open(sys.argv[1]).convert('RGBA').save(sys.argv[2])", jpg, f }).WaitForExit();
        }
        var (w, h, rgba) = Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    public static byte[] Draw(string svg, int w, int h)
    {
        ReferenceRaster.LoadImage = LoadImage;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), w, h, Affine.Identity, href => { var i = LoadImage(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        return ReferenceRaster.Resolve(ReferenceRaster.Render(scene, w, h, 2), 2, w, h);
    }

    public static (double pct, int n) Compare(string svg, string appPng, string outPng, string diffPng, Frame[] masks)
    {
        var (w, h, reference) = Png.Read(appPng);
        var ours = Draw(svg, w, h);
        Png.Write(outPng, w, h, ours);
        double k = w / 832.0;
        int visible = 0, counted = 0;
        var diff = new byte[w * h * 4];
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                int i = (y * w + x) * 4;
                float dx = (float)(x / k), dy = (float)(y / k);
                bool skip = masks.Any(m => m.Contains(dx, dy));
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                bool bad = !skip && d > 24;
                if (!skip) { counted++; if (bad) visible++; }
                byte g = (byte)(reference[i] * 0.3 + (skip ? 60 : 150));
                diff[i] = bad ? (byte)255 : g; diff[i + 1] = bad ? (byte)0 : g; diff[i + 2] = bad ? (byte)60 : g; diff[i + 3] = 255;
            }
        Png.Write(diffPng, w, h, diff);
        return (100.0 * visible / Math.Max(1, counted), visible);
    }
}

/// <summary>A view that does something every frame besides its pieces (the chest smash's engine).</summary>
interface IFramed { void Frame(); }
