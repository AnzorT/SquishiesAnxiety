// dotnet run -c Release --project tools/unity/heading-test -- <capture dir>   (capture.mjs's app.png, state.json)
// "Heading home"'s night as Unity makes it (Menu/HeadingNight.cs on the menu's house picture, the open door drawn in
// as MenuView.Home.cs draws it), every open room lit and the door not yet, placed as MenuView puts the house on the
// reference screen; compared with the app's screenshot (the lettering, the tip, the moon and the stars aren't drawn
// here: their boxes are left out of the count).
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using SquishSquad.Menu;
using SquishSquad.Vector;

static class Program
{
    static string Here([System.Runtime.CompilerServices.CallerFilePath] string f = "") => Path.GetDirectoryName(f);
    static readonly string Repo = Path.GetFullPath(Path.Combine(Here(), "../../.."));
    const int PW = 2340, PH = 1080;

    static int Main(string[] args)
    {
        string dir = args[0];
        var st = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "state.json"))).RootElement;
        int level = st.GetProperty("level").GetInt32(); string season = st.GetProperty("season").GetString();
        var menu = JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo, "unity/Assets/Resources/Menu/menu.json"))).RootElement.GetProperty("scene");
        float u = (float)menu.GetProperty("unitsPerPx").GetDouble();
        float ox = (float)menu.GetProperty("originUnits")[0].GetDouble(), oy = (float)menu.GetProperty("originUnits")[1].GetDouble();
        var (W, H, rgba) = Jpeg(Path.Combine(Repo, $"unity/Assets/Resources/Menu/scene/{season}-{level}.jpg.bytes"));
        var day = new byte[W * H * 3];
        for (int i = 0; i < W * H; i++) { day[i * 3] = rgba[i * 4]; day[i * 3 + 1] = rgba[i * 4 + 1]; day[i * 3 + 2] = rgba[i * 4 + 2]; }
        DoorInto(day, W, H, u, ox, oy, level);
        var lights = HeadingNight.LightsFor(level);
        var sw = Stopwatch.StartNew();
        var night = HeadingNight.Make(day, W, H, u, ox, oy, lights);
        Console.WriteLine($"{W}x{H} picture, {lights.Count} lights, made in {sw.ElapsedMilliseconds} ms");
        // every room's light on (the door's, last, not yet)
        for (int li = 0; li < lights.Count - 1; li++)
        {
            var L = lights[li]; if (L.Rgb == null) continue;
            for (int y = 0; y < L.PH; y++) Buffer.BlockCopy(L.Rgb, y * L.PW * 3, night, ((L.PY + y) * W + L.PX) * 3, L.PW * 3);
        }
        // on the reference screen: k = max(2340 / 1000, 1080 / 460), the house's top-left at (ox, oy) x k from the scene's
        double k = Math.Max(PW / 1000.0, PH / 460.0), sx0 = (PW - 1000 * k) / 2 + ox * k, sy0 = PH - 460 * k + oy * k, s = k * u;
        var ours = new byte[PW * PH * 4];
        for (int y = 0; y < PH; y++)
            for (int x = 0; x < PW; x++)
            {
                int px = (int)Math.Floor((x + 0.5 - sx0) / s), py = (int)Math.Floor((y + 0.5 - sy0) / s), o = (y * PW + x) * 4;
                if (px < 0 || py < 0 || px >= W || py >= H) { ours[o + 3] = 255; continue; }
                int j = (py * W + px) * 3; ours[o] = night[j]; ours[o + 1] = night[j + 1]; ours[o + 2] = night[j + 2]; ours[o + 3] = 255;
            }
        Png.Write(Path.Combine(dir, "unity.png"), PW, PH, ours);
        var (aw, ah, app) = Png.Read(Path.Combine(dir, "app.png"));
        // left out: the lettering (top 22 %), the tip (bottom 9 %), the moon's corner (right 18 %, top 25 %)
        bool Skip(int x, int y) => y < PH * 0.22 || y > PH * 0.91 || (x > PW * 0.82 && y < PH * 0.25);
        int visible = 0, total = 0; var diff = new byte[PW * PH * 4];
        for (int y = 0; y < PH; y++)
            for (int x = 0; x < PW; x++)
            {
                int i = (y * PW + x) * 4;
                int d = Math.Max(Math.Abs(app[i] - ours[i]), Math.Max(Math.Abs(app[i + 1] - ours[i + 1]), Math.Abs(app[i + 2] - ours[i + 2])));
                bool skip = Skip(x, y), v = !skip && d > 24;
                if (!skip) total++; if (v) visible++;
                byte g = (byte)(ours[i] * 0.3 + 150);
                diff[i] = v ? (byte)255 : skip ? (byte)90 : g; diff[i + 1] = v ? (byte)0 : skip ? (byte)90 : g; diff[i + 2] = v ? (byte)60 : skip ? (byte)90 : g; diff[i + 3] = 255;
            }
        Png.Write(Path.Combine(dir, "diff.png"), PW, PH, diff);
        Console.WriteLine($"the night: {visible} of {total} px differ visibly ({100.0 * visible / total:0.00} %)");
        return 0;
    }

    // MenuView.Home.cs's open door (t = 1), drawn by the reference rasteriser at the picture's px, over the house
    static void DoorInto(byte[] day, int W, int H, float u, float ox, float oy, int level)
    {
        int tier = level < 5 ? 0 : level < 15 ? 1 : level < 25 ? 2 : 3;
        string door = tier >= 3 ? "#7a2a3a" : tier == 0 ? "#8a6a52" : "#a0643a", OL = "#4a3a2e";
        string seam = Darker(door);
        string arch = "M488 300 V259 A12 12 0 0 1 512 259 V300Z";
        const float t = 1, x0 = 480, y0 = 244, w = 40, h = 60;
        string F(float v) => v.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
        var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + F(w) + "\" height=\"" + F(h) + "\" viewBox=\"" + F(x0) + " " + F(y0) + " " + F(w) + " " + F(h) + "\">"
            + "<defs><radialGradient id=\"mmDoorL\" cx=\"0.5\" cy=\"0.7\" r=\"0.8\"><stop offset=\"0\" stop-color=\"#fffbe6\"/><stop offset=\"0.55\" stop-color=\"#ffe39a\"/><stop offset=\"1\" stop-color=\"#ffb84a\"/></radialGradient></defs>"
            + "<path d=\"" + arch + "\" fill=\"#3a2418\"/><path d=\"" + arch + "\" fill=\"url(#mmDoorL)\" opacity=\"" + F(t) + "\"/>"
            + "<g transform=\"translate(488 273.5) scale(" + F(1 - 0.82f * t) + " 1) skewY(" + F(-6 * t) + ") translate(-488 -273.5)\">"
            + "<path d=\"" + arch + "\" fill=\"" + door + "\" stroke=\"" + OL + "\" stroke-width=\"1.1\"/><path d=\"M494 298 V262 M500 298 V256 M506 298 V262\" stroke=\"" + seam + "\" stroke-width=\"0.8\"/>"
            + "<circle cx=\"500\" cy=\"263\" r=\"4.2\" fill=\"#fff4d0\" stroke=\"" + OL + "\" stroke-width=\"0.9\"/><circle cx=\"507\" cy=\"281\" r=\"1.6\" fill=\"#ffd66b\" stroke=\"#8a6a1a\" stroke-width=\"0.5\"/></g>"
            + "<rect x=\"478\" y=\"300\" width=\"44\" height=\"5\" rx=\"1\" fill=\"#b8ab98\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<rect x=\"472\" y=\"304\" width=\"56\" height=\"5\" rx=\"1\" fill=\"#a89a86\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<rect x=\"417\" y=\"293\" width=\"166\" height=\"8\" fill=\"#b8ab98\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<path d=\"M481 293 V301 M495 293 V301 M509 293 V301\" stroke=\"#8a7c6a\" stroke-width=\"0.7\"/></svg>";   // (MenuView.Home.cs DoorFront)
        int dw = (int)Math.Ceiling(w / u), dh = (int)Math.Ceiling(h / u);
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), w / u, h / u, Affine.Identity, null);
        const int SS = 2;
        var b = ReferenceRaster.Render(scene, dw, dh, SS);   // (premultiplied, 0..1, SS x SS per px)
        int bx = (int)Math.Round((x0 - ox) / u), by = (int)Math.Round((y0 - oy) / u);
        for (int y = 0; y < dh; y++)
            for (int x = 0; x < dw; x++)
            {
                int X = bx + x, Y = by + y; if (X < 0 || Y < 0 || X >= W || Y >= H) continue;
                float r = 0, g = 0, bl = 0, a = 0;
                for (int sy = 0; sy < SS; sy++)
                    for (int sx = 0; sx < SS; sx++)
                    {
                        int i = ((y * SS + sy) * b.W + x * SS + sx) * 4;
                        r += b.P[i]; g += b.P[i + 1]; bl += b.P[i + 2]; a += b.P[i + 3];
                    }
                float k = 1f / (SS * SS); r *= k; g *= k; bl *= k; a *= k;
                int j = (Y * W + X) * 3;
                day[j] = (byte)Math.Round(Math.Min(255, r * 255 + day[j] * (1 - a)));
                day[j + 1] = (byte)Math.Round(Math.Min(255, g * 255 + day[j + 1] * (1 - a)));
                day[j + 2] = (byte)Math.Round(Math.Min(255, bl * 255 + day[j + 2] * (1 - a)));
            }
    }
    static string Darker(string hex)
    {
        int r = Convert.ToInt32(hex.Substring(1, 2), 16), g = Convert.ToInt32(hex.Substring(3, 2), 16), b = Convert.ToInt32(hex.Substring(5, 2), 16);
        return $"#{(int)(r * 0.75):x2}{(int)(g * 0.75):x2}{(int)(b * 0.75):x2}";
    }
    // a JPEG through PIL (python), as RGBA
    static (int, int, byte[]) Jpeg(string f)
    {
        var png = Path.GetTempFileName() + ".png";
        var p = Process.Start(new ProcessStartInfo("python", $"-I -c \"from PIL import Image; Image.open(r'{f}').convert('RGBA').save(r'{png}')\"") { UseShellExecute = false });
        p.WaitForExit();
        var r = Png.Read(png); File.Delete(png); return r;
    }
}
