// The Unity port's start-up flow, checked two ways:
//
//   dotnet run -c Release --project tools/unity/auth-test -- shots <dir>
//       <dir> from capture.mjs (the app's splash, log in / register states and verify screen): each state rebuilt from
//       the Unity code (Ui/Screens: the same model values, laid out by Yoga, drawn as SVG), drawn with the reference
//       rasteriser and compared with the app's screenshot; the share of pixels that differ visibly (any channel > 24),
//       outside Mittens' box (a live rig in both, not frozen at the same frame).
//   dotnet run -c Release --project tools/unity/auth-test -- menu <dir>
//       <dir> from menu.mjs: the menu's coin / gem pills and the crest's number / XP ring for several profiles, drawn
//       from Menu/HudArt.cs over the app's menu with those parts hidden, against the app's menu with them.
//   dotnet run --project tools/unity/auth-test -- emu
//       the screens' sign-in logic (AuthModel, VerifyModel) and the profile -> HUD values against the Firebase Local
//       Emulator Suite (tools/unity/backend/start-emulators.sh; demo-squish; every request to 127.0.0.1 only).
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SquishSquad.Anim;
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
        if (Environment.GetEnvironmentVariable("YOGA_ROUND") is string r) FlexNode.PointScale = float.Parse(r, System.Globalization.CultureInfo.InvariantCulture);
        string mode = args.Length > 0 ? args[0] : "shots";
        if (mode == "emu") return await Emu.Run();
        if (mode == "menu") return MenuShots.Run(args[1]);
        return Shots(args.Length > 1 ? args[1] : "auth-shots", args.Skip(2).ToArray());
    }

    // ---- the start-up screens ----------------------------------------------------------------------------------------
    const float W = 832, H = 384;

    static int Shots(string dir, string[] only)
    {
        var states = new (string name, Func<(List<ScreenPiece> pieces, Frame? mask)> build)[]
        {
            ("login", () => Auth(m => { })),
            ("login-error", () => Auth(m => m.Error = "Enter your email and password.")),
            ("login-filled", () => Auth(m => { m.Error = "Enter your email and password."; m.Email = "mia.squish@example.com"; m.Password = "secret12"; })),
            ("login-shown", () => Auth(m => { m.Error = "Enter your email and password."; m.Email = "mia.squish@example.com"; m.Password = "secret12"; m.ShowPass = true; })),
            ("register", () => Auth(m => { Typed(m); m.Register = true; })),
            ("register-blocked", () => Auth(m => { m.Register = true; m.Blocked = true; })),
            ("register-error", () => Auth(m => { Typed(m); m.Register = true; m.Nickname = "Captain"; m.Error = "Enter your age."; })),   // (capture.mjs typed it before the age)
            ("verify", Verify),
        };
        Console.WriteLine($"Yoga rounding: {(FlexNode.PointScale > 0 ? FlexNode.PointScale + " px per dp" : "off")}");
        int worst = 0;
        foreach (var (name, build) in states)
        {
            if (only.Length > 0 && !only.Contains(name)) continue;
            var app = Path.Combine(dir, name + ".png");
            if (!File.Exists(app)) { Console.WriteLine($"{name}: no {app} (run capture.mjs)"); continue; }
            var (pieces, mask) = build();
            var svg = Pieces.Compose(pieces, W, H);
            File.WriteAllText(Path.Combine(dir, name + ".unity.svg"), svg);
            var (pct, _) = Compare(svg, app, Path.Combine(dir, name + ".unity.png"), Path.Combine(dir, name + ".diff.png"), mask);
            Console.WriteLine($"{name,-18} {pct,6:0.00} % of pixels differ visibly{(mask.HasValue ? " (outside Mittens' box)" : "")}");
            worst = Math.Max(worst, (int)Math.Ceiling(pct));
        }
        return 0;
    }

    // what capture.mjs typed before it went to Register (the form keeps it)
    static void Typed(AuthModel m) { m.Email = "mia.squish@example.com"; m.Password = "secret12"; m.ShowPass = true; }

    static (List<ScreenPiece>, Frame?) Auth(Action<AuthModel> set)
    {
        var m = new AuthModel();
        set(m);
        var ui = new AuthUi { PillX = m.Register ? 1 : 0, CaretOn = false };
        // Chrome paints a ScrollView's content (a composited scroller) about a device pixel lower than its layout box
        // says; SCROLL_SNAP_PX shifts the card column the same way to see what's left once that's accounted for
        if (Environment.GetEnvironmentVariable("SCROLL_SNAP_PX") is string snap) ui.ScrollY = -float.Parse(snap, System.Globalization.CultureInfo.InvariantCulture) / 2.8125f;
        var art = new AuthArt(W, H);
        var f = art.Layout(m, out _);
        var mf = f["mittens"];
        return (art.Pieces(m, ui, f), mf.Inset(30));
    }

    static (List<ScreenPiece>, Frame?) Verify()
    {
        var m = new VerifyModel { Email = "new.player@example.com" };
        var art = new VerifyArt(W, H);
        var f = art.Layout(m);
        return (art.Pieces(m, new VerifyUi(), f), f["mittens"].Inset(30));
    }

    static (List<ScreenPiece>, Frame?) Splash()
    {
        // settled: 7 s in, the app not ready yet (the bar at 90 %)
        var ticker = new Ticker(0);
        var m = new SplashModel(ticker);
        for (double t = 16; t <= 7000; t += 16) ticker.Tick(t);
        return (new SplashArt(W, H).Pieces(m), null);
    }

    // ---- drawing and comparing ---------------------------------------------------------------------------------------
    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    public static (int, int, float[]) LoadImage(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Res(href + ".png");
        if (!File.Exists(f) && File.Exists(Res(href + ".jpg")))
        {
            // (a JPEG, as the sign-in screens' house: made a PNG once with Pillow, the reference rasteriser reads PNGs)
            f = Path.Combine(Path.GetTempPath(), "auth-test-" + href.Replace('/', '_') + ".png");
            if (!File.Exists(f))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("python3", $"-c \"from PIL import Image; Image.open('{Res(href + ".jpg")}').convert('RGBA').save('{f}')\"") { UseShellExecute = false })!.WaitForExit();
        }
        if (!File.Exists(f)) return (0, 0, null);
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

    /// <summary>Draws `svg` at the screenshot's size, writes it and a picture of the pixels that differ visibly
    /// (outside `maskDp`), returns their share.</summary>
    public static (double pct, int n) Compare(string svg, string appPng, string outPng, string diffPng, Frame? maskDp, Frame? onlyDp = null)
    {
        var (w, h, reference) = Png.Read(appPng);
        var ours = Draw(svg, w, h);
        Png.Write(outPng, w, h, ours);
        return Diff(reference, ours, w, h, diffPng, maskDp, onlyDp);
    }

    public static (double pct, int n) Diff(byte[] reference, byte[] ours, int w, int h, string diffPng, Frame? maskDp, Frame? onlyDp = null)
    {
        double k = w / 832.0;
        int visible = 0, counted = 0;
        var diff = new byte[w * h * 4];
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                int i = (y * w + x) * 4;
                bool skip = (maskDp.HasValue && maskDp.Value.Contains((float)(x / k), (float)(y / k))) || (onlyDp.HasValue && !onlyDp.Value.Contains((float)(x / k), (float)(y / k)));
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
