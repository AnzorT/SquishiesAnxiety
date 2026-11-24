// pixels: the C# room drawn by the reference rasteriser vs Chrome's screenshot of the same room
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SquishSquad.House;
using SquishSquad.Vector;

static partial class Program
{
    public const double FrameK = 0.9765, Dpr = 2.8125;   // the menu's framing ((832 / 852).toFixed(4)), the A15's density

    static readonly Dictionary<string, (int w, int h, float[] px)> PngCache = new Dictionary<string, (int, int, float[])>();
    static (int w, int h, float[] px) LoadPng(string href)
    {
        if (PngCache.TryGetValue(href, out var c)) return c;
        // the dance room's 3D floor: its picture drawn by HouseFlat from its tile
        if (href.StartsWith("flat:") && HouseFlat.Specs.TryGetValue(href, out var fs)) { var sw = Stopwatch.StartNew(); var r = PngCache[href] = HouseFlat.Render(fs, LoadPng); Console.WriteLine($"  (the 3D floor's picture: {r.w} x {r.h} px in {sw.ElapsedMilliseconds} ms)"); return r; }
        var f = Path.Combine(Res, "pics", href + ".png");
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = Png.Read(f); var px = new float[w * h * 4]; for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return PngCache[href] = (w, h, px);
    }

    public static RoomCompose Composer(HouseData d) => new RoomCompose
    {
        PicSvg = n => { var f = Path.Combine(Res, "pics", n + ".xml"); return File.Exists(f) ? File.ReadAllText(f) : null; },
        PicPng = n => File.Exists(Path.Combine(Res, "pics", n + ".png")) ? n : null,
    };

    static int Pixels(string only, bool keep)
    {
        var d = Data(); var tpl = Template(); var outDir = Path.Combine(Repo, "tools/unity/house-test/out"); Directory.CreateDirectory(outDir);
        ReferenceRaster.LoadImage = href => LoadPng(href);
        // --disco k: the light-up floor at moment k (HouseFlat.Disco, disco.json) against tools/unity/house/disco-capture.mjs's
        // <room>-<day|night>-d<k>.png (develop's SquishDisco showing that moment)
        if (DiscoK >= 0) HouseFlat.LoadDisco(File.ReadAllText(Path.Combine(Res, "disco.json")));
        var rows = new List<string>(); double worst = 0, sum = 0; int n = 0;
        foreach (var (fx, rk, night, cap, hs, vals, m) in Rooms(d, only))
        {
            var name = $"{fx}-{rk}-{(night ? "night" : "day")}";
            if (PixRoom != null && PixRoom != rk) continue;
            var refPng = Path.Combine(Cap, fx, name.Substring(fx.Length + 1) + (DiscoK >= 0 ? "-d" + DiscoK : "") + ".png");
            if (DiscoK >= 0) name += "-d" + DiscoK;
            if (vals == null || !File.Exists(refPng)) { Console.WriteLine(name + ": skipped"); continue; }
            var sw = Stopwatch.StartNew();
            var comp = Composer(d);
            var fence = vals.Obj("rt")?.Str("fenceHtml");
            var svg = comp.Compose(tpl.Render(vals), fence);
            if (DiscoK > 0) { var fm = System.Text.RegularExpressions.Regex.Match(svg, "href=\"(flat:[^\"]+)\""); var mh = fm.Success ? HouseFlat.Moment(fm.Groups[1].Value, DiscoK) : null; if (mh != null) svg = svg.Replace(fm.Value, "href=\"" + mh + "\""); }
            var root = SvgMarkup.Parse(svg);
            PatternExpand.Expanded = PatternExpand.Tiles = PatternExpand.Capped = 0;
            PatternExpand.Expand(root);
            var (W, H, reference) = Png.Read(refPng);
            double k = FrameK * Dpr;
            var scene = SvgScene.Compile(root, 852 * k, 393 * k, Affine.Identity, href => { var p = LoadPng(href); return p.px == null ? ((int, int)?)null : (p.w, p.h); });
            long tCompile = sw.ElapsedMilliseconds;
            const int ss = 2;
            var buf = ReferenceRaster.Render(scene, W, H, ss);
            var ours = ReferenceRaster.Resolve(buf, ss, W, H);
            // compare inside the house box (its last partly covered device-pixel row and column left out)
            int CW = (int)Math.Floor(852 * k), CH = (int)Math.Floor(393 * k), visible = 0, total = CW * CH;
            var diff = new byte[W * H * 4];
            for (int y = 0; y < H; y++) for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                int dd = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                bool inside = x < CW && y < CH;
                if (inside && dd > 24) visible++;
                byte gray = (byte)((reference[i] + reference[i + 1] + reference[i + 2]) / 3 * 0.35 + 160);
                if (inside && dd > 24) { diff[i] = 255; diff[i + 1] = 0; diff[i + 2] = 60; } else if (inside && dd > 8) { diff[i] = 255; diff[i + 1] = 170; diff[i + 2] = 0; } else { diff[i] = diff[i + 1] = diff[i + 2] = gray; }
                diff[i + 3] = 255;
            }
            Png.Write(Path.Combine(outDir, name + "-ours.png"), W, H, ours);
            Png.Write(Path.Combine(outDir, name + "-diff.png"), W, H, diff);
            if (keep) File.WriteAllText(Path.Combine(outDir, name + ".svg"), svg);
            double pct = 100.0 * visible / total; worst = Math.Max(worst, pct); sum += pct; n++;
            var notes = comp.Notes.Concat(m.Missing).Distinct().ToList();
            Console.WriteLine($"{name}: {pct:0.00}% of pixels differ visibly ({visible} of {total}); compose+compile {tCompile} ms, total {sw.ElapsedMilliseconds} ms; {PatternExpand.Expanded} pattern fills, {PatternExpand.Tiles} tiles{(PatternExpand.Capped > 0 ? ", " + PatternExpand.Capped + " capped" : "")}{(notes.Count > 0 ? "; not drawn: " + string.Join("; ", notes.Take(5)) : "")}");
        }
        if (n > 0) Console.WriteLine($"pixels: {n} rooms, mean {sum / n:0.00}% visibly different, worst {worst:0.00}%");
        return 0;
    }
}
