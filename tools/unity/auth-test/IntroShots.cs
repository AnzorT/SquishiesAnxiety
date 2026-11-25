// The game intro's box (Menu/IntroArt.cs) over the intro's night picture (Resources/Intro/sunny/night.jpg), against the
// app's frame from capture-intro.mjs (the box landed and still, the ring, caption and Skip hidden).
//   dotnet run -c Release --project tools/unity/auth-test -- intro <dir>
//   dotnet run -c Release --project tools/unity/auth-test -- rain <dir> [ms]
//       the same on a rainy and a snowy day (capture-intro.mjs with WEATHER=rainy / snowy) with the rain or snow over it
//       (Menu/IntroRain.cs, its layers at `ms` into their loops: capture-intro.mjs's RAIN_MS)
//   dotnet run -c Release --project tools/unity/auth-test -- rainframes <dir> <rainy|snowy> [fps] [ms]
//       that night with its rain or snow falling, frame by frame (<dir>/frame-NNNN.png at 1040 x 480 px), for a video
using System;
using System.IO;
using SquishSquad.Menu;
using SquishSquad.Ui;

static class IntroShots
{
    public static int Run(string dir) => Shot(dir, "sunny", -1);

    public static int Rain(string dir, double ms) { Shot(dir, "rainy", ms); Shot(dir, "snowy", ms); return 0; }

    public static int RainFrames(string dir, string weather, int fps, double ms)
    {
        Directory.CreateDirectory(dir);
        int f = 0;
        for (double t = 0; t < ms; t += 1000.0 / fps)
        {
            var svg = Scene(dir, weather, t);
            Png.Write(Path.Combine(dir, $"frame-{f++:0000}.png"), 1040, 480, Program.Draw(svg, 1040, 480));
        }
        Console.WriteLine($"{f} frames at {fps} fps in {dir}");
        return 0;
    }

    // the day's night picture, the box landed and still, its rain or snow at `rainMs` (none if < 0)
    static string Scene(string dir, string weather, double rainMs)
    {
        const float W = 832, H = 384, P = 2.8125f;
        // the night picture (a JPEG in the app: made a PNG with Pillow for the reference rasteriser)
        var png = Path.Combine(dir, $"night-{weather}.png");
        if (!File.Exists(png)) System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("python3", $"-c \"from PIL import Image; Image.open('{Program.Res($"Intro/{weather}/night.jpg.bytes")}').convert('RGBA').save('{png}')\"") { UseShellExecute = false })!.WaitForExit();
        var (pw, ph, _) = Program.LoadImage(png.Substring(0, png.Length - 4));
        // the canvas's frame at (145, 47) device px (intro.json canvas.frameAt)
        float s0 = Math.Max(W / 1000f, H / 460f), ox = (W - 1000 * s0) / 2, oy = H - 460 * s0;
        string F(double v) => UiSvg.F(v);
        var svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(W)}\" height=\"{F(H)}\" viewBox=\"0 0 {F(W)} {F(H)}\">"
            + $"<image href=\"{png.Substring(0, png.Length - 4)}\" x=\"{F(-145 / P)}\" y=\"{F(-47 / P)}\" width=\"{F(pw / P)}\" height=\"{F(ph / P)}\"/>"
            + $"<g transform=\"translate({F(ox)} {F(oy)}) scale({F(s0)})\">"
            + $"<ellipse cx=\"{F(IntroArt.BX)}\" cy=\"{F(IntroArt.BY + 1)}\" rx=\"{F(IntroArt.BW * 0.6)}\" ry=\"9\" fill=\"#0c0820\" opacity=\"0.42\"/>"
            + IntroArt.BoxBack(0) + IntroArt.BoxFront() + "</g>";
        // the rain or snow: on the frame, in front of the house
        int ri = 0;
        foreach (var l in IntroRain.Layers(W, H, weather))
        {
            var (x, y) = l.At(rainMs);
            int a = l.Svg.IndexOf('>') + 1, b = l.Svg.LastIndexOf("</svg>");
            svg += $"<g transform=\"translate({F(x)} {F(y)})\" id=\"rain{ri++}\">{l.Svg.Substring(a, b - a)}</g>";
        }
        svg += "</svg>";
        return svg;
    }

    static int Shot(string dir, string weather, double rainMs)
    {
        var svg = Scene(dir, weather, rainMs);
        const float W = 832, H = 384;
        float s0 = Math.Max(W / 1000f, H / 460f), ox = (W - 1000 * s0) / 2, oy = H - 460 * s0;
        string name = weather == "sunny" ? "box" : "box-" + weather;
        File.WriteAllText(Path.Combine(dir, name + ".unity.svg"), svg);
        var (pct, _) = Program.Compare(svg, Path.Combine(dir, name + ".png"), Path.Combine(dir, name + ".unity.png"), Path.Combine(dir, name + ".diff.png"), null);
        if (weather != "sunny")
        {
            Console.WriteLine($"intro {weather}: {pct:0.00} % of pixels differ visibly (the box, the house and the {(weather == "snowy" ? "snow" : "rain")})");
            return 0;
        }
        // and the box alone (its box in dp, a little room round it)
        var only = new SquishSquad.Ui.Screens.Frame(ox + (IntroArt.FX0 - 20) * s0, oy + (IntroArt.FTOP - 30) * s0, (IntroArt.BW + 40) * s0, (IntroArt.BH + 45) * s0);
        var (pb, _) = Program.Compare(svg, Path.Combine(dir, name + ".png"), Path.Combine(dir, name + ".unity.png"), Path.Combine(dir, "box-only.diff.png"), null, only);
        Console.WriteLine($"intro box: {pct:0.00} % of pixels differ visibly ({pb:0.00} % round the box)");
        return 0;
    }
}
