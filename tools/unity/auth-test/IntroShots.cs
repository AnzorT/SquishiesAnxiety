// The game intro's box (Menu/IntroArt.cs) over the intro's night picture (Resources/Intro/sunny/night.jpg), against the
// app's frame from capture-intro.mjs (the box landed and still, the ring, caption and Skip hidden).
//   dotnet run -c Release --project tools/unity/auth-test -- intro <dir>
using System;
using System.IO;
using SquishSquad.Menu;
using SquishSquad.Ui;

static class IntroShots
{
    public static int Run(string dir)
    {
        const float W = 832, H = 384, P = 2.8125f;
        // the night picture (a JPEG in the app: made a PNG with Pillow for the reference rasteriser)
        var png = Path.Combine(dir, "night.png");
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("python3", $"-c \"from PIL import Image; Image.open('{Program.Res("Intro/sunny/night.jpg.bytes")}').convert('RGBA').save('{png}')\"") { UseShellExecute = false })!.WaitForExit();
        var (pw, ph, _) = Program.LoadImage(png.Substring(0, png.Length - 4));
        // the canvas's frame at (145, 47) device px (intro.json canvas.frameAt)
        float s0 = Math.Max(W / 1000f, H / 460f), ox = (W - 1000 * s0) / 2, oy = H - 460 * s0;
        string F(double v) => UiSvg.F(v);
        var svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(W)}\" height=\"{F(H)}\" viewBox=\"0 0 {F(W)} {F(H)}\">"
            + $"<image href=\"{png.Substring(0, png.Length - 4)}\" x=\"{F(-145 / P)}\" y=\"{F(-47 / P)}\" width=\"{F(pw / P)}\" height=\"{F(ph / P)}\"/>"
            + $"<g transform=\"translate({F(ox)} {F(oy)}) scale({F(s0)})\">"
            + $"<ellipse cx=\"{F(IntroArt.BX)}\" cy=\"{F(IntroArt.BY + 1)}\" rx=\"{F(IntroArt.BW * 0.6)}\" ry=\"9\" fill=\"#0c0820\" opacity=\"0.42\"/>"
            + IntroArt.BoxBack(0) + IntroArt.BoxFront() + "</g></svg>";
        File.WriteAllText(Path.Combine(dir, "box.unity.svg"), svg);
        var (pct, _) = Program.Compare(svg, Path.Combine(dir, "box.png"), Path.Combine(dir, "box.unity.png"), Path.Combine(dir, "box.diff.png"), null);
        // and the box alone (its box in dp, a little room round it)
        var only = new SquishSquad.Ui.Screens.Frame(ox + (IntroArt.FX0 - 20) * s0, oy + (IntroArt.FTOP - 30) * s0, (IntroArt.BW + 40) * s0, (IntroArt.BH + 45) * s0);
        var (pb, _) = Program.Compare(svg, Path.Combine(dir, "box.png"), Path.Combine(dir, "box.unity.png"), Path.Combine(dir, "box-only.diff.png"), null, only);
        Console.WriteLine($"intro box: {pct:0.00} % of pixels differ visibly ({pb:0.00} % round the box)");
        return 0;
    }
}
