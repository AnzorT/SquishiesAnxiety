// dotnet run -c Release --project tools/unity/vector-test -- <framesDir> [outDir] [--ss 4]
// For every <name>.svg + <name>.png pair (tools/unity/rig/dump-frames.mjs): compile the SVG with the Unity app's
// vector core (SvgScene), draw it with ReferenceRaster, and compare with Chrome's picture. Prints, per frame, how many
// pixels differ visibly (> 24 in a channel) and slightly (> 8), and writes <outDir>/<name>-ours.png and -diff.png.
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SquishSquad.Vector;

static class Program
{
    static int Main(string[] args)
    {
        var dir = args.Length > 0 ? args[0] : ".";
        var outDir = args.Length > 1 && !args[1].StartsWith("--") ? args[1] : Path.Combine(dir, "out");
        int ss = args.Contains("--ss") ? int.Parse(args[Array.IndexOf(args, "--ss") + 1]) : 4;
        Directory.CreateDirectory(outDir);
        ReferenceRaster.LoadImage = href =>
        {
            var f = Path.Combine(dir, href);
            if (!File.Exists(f)) return (0, 0, null);
            var (w, h, rgba) = Png.Read(f);
            var px = new float[w * h * 4];
            for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
            return (w, h, px);
        };
        int worst = 0;
        long compileTicks = 0; int frames = 0;
        foreach (var svgPath in Directory.GetFiles(dir, "*.svg").OrderBy(x => x))
        {
            var name = Path.GetFileNameWithoutExtension(svgPath);
            var refPath = Path.Combine(dir, name + ".png");
            if (!File.Exists(refPath)) continue;
            var (size, refH, reference) = Png.Read(refPath);
            var markup = File.ReadAllText(svgPath);
            var sw = Stopwatch.StartNew();
            var scene = SvgScene.Compile(SvgMarkup.Parse(markup), size, size);
            sw.Stop(); compileTicks += sw.ElapsedTicks; frames++;
            var buf = ReferenceRaster.Render(scene, size, ss);
            var ours = ReferenceRaster.Resolve(buf, ss, size);
            int visible = 0, slight = 0; double sum = 0;
            var diff = new byte[size * size * 4];
            for (int i = 0; i < size * size * 4; i += 4)
            {
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                sum += d;
                if (d > 24) visible++;
                if (d > 8) slight++;
                byte gray = (byte)((reference[i] + reference[i + 1] + reference[i + 2]) / 3 * 0.35 + 160);
                if (d > 24) { diff[i] = 255; diff[i + 1] = 0; diff[i + 2] = 60; } else if (d > 8) { diff[i] = 255; diff[i + 1] = 170; diff[i + 2] = 0; } else { diff[i] = diff[i + 1] = diff[i + 2] = gray; }
                diff[i + 3] = 255;
            }
            Png.Write(Path.Combine(outDir, name + "-ours.png"), size, size, ours);
            Png.Write(Path.Combine(outDir, name + "-diff.png"), size, size, diff);
            worst = Math.Max(worst, visible);
            Console.WriteLine($"{name}: {visible} px differ visibly (>24), {slight} slightly (>8), mean {sum / (size * size):0.00}; {CountNodes(scene.Root)} meshes");
        }
        Console.WriteLine($"compile (parse + flatten + stroke outlines): {compileTicks * 1000.0 / Stopwatch.Frequency / Math.Max(1, frames):0.0} ms per frame on average");
        if (ReferenceRaster.Unsupported.Count > 0) Console.WriteLine("filter primitives not drawn yet: " + string.Join(", ", ReferenceRaster.Unsupported));
        return 0;
    }

    static int CountNodes(LayerNode l) { int n = 0; foreach (var c in l.Children) n += c is LayerNode k ? CountNodes(k) + (k.Mask != null ? CountNodes(k.Mask) : 0) : 1; return n; }
}
