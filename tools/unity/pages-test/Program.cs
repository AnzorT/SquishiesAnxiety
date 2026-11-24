// node tools/unity/export-pages.mjs, then:
//   dotnet run -c Release --project tools/unity/pages-test [-- lp|ch|yd]
// Runs the Unity pages' own code (unity/Assets/Scripts/Menu/LevelPassModel.cs, CharactersModel.cs: what they show for
// the test player, where every piece goes, every motion) for the moments the exporter screenshotted in the app, and
// writes what they would draw (draws.json; the texts Unity draws with the app's fonts rasterised here by the
// reference rasteriser of tools/unity/vector-test), then compose.py draws that over the app's menu as the GPU will
// and counts the pixels that differ visibly from the app's screenshot.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using SquishSquad.Menu;
using SquishSquad.Ui;
using SquishSquad.Vector;

static partial class Program
{
    public static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string rel) => Path.Combine(Root, "unity/Assets/Resources", rel);
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { IncludeFields = true };
    static string _out;

    static int Main(string[] args)
    {
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, Opts);
        var shotsDir = Path.Combine(Root, "webgame/test/out/unity-pages");
        _out = Path.Combine(shotsDir, "unity");
        Directory.CreateDirectory(Path.Combine(_out, "svg"));
        var which = args.Length > 0 ? args[0] : "lp,ch";
        var jobs = new List<object>();
        if (which == "smoke") { jobs.AddRange(Smoke()); which = ""; }
        if (which == "shape")
        {
            // the pages at rest on another screen shape (no comparison): -- shape W H
            double sw = double.Parse(args[1]), sh = double.Parse(args[2]);
            jobs.AddRange(Shapes(sw, sh));
            which = "";
        }
        if (which.Contains("yd")) jobs.AddRange(YardScenes());
        if (which.Contains("lp")) jobs.AddRange(LevelPassScenes());
        if (which.Contains("ch") && File.Exists(Res("Characters/characters.json"))) jobs.AddRange(CharactersScenes());
        var json = Path.Combine(_out, "draws.json");
        File.WriteAllText(json, JsonSerializer.Serialize(new { shots = shotsDir, scenes = jobs }));
        var p = Process.Start(new ProcessStartInfo("python3", $"\"{Path.Combine(Root, "tools/unity/pages-test/compose.py")}\" \"{json}\" \"{_out}\"") { UseShellExecute = false });
        p.WaitForExit();
        return p.ExitCode;
    }

    // ---- the Level Pass ----------------------------------------------------------------------------------------------
    static IEnumerable<object> LevelPassScenes()
    {
        var text = File.ReadAllText(Res("LevelPass/levelpass.json"));
        var L = JsonSerializer.Deserialize<LevelPassLayout>(text, Opts);
        var doc = JsonDocument.Parse(text).RootElement;
        var pl = doc.GetProperty("player");
        var prof = new Dictionary<string, object> { ["pxp"] = pl.GetProperty("pxp").GetDouble(), ["coins"] = pl.GetProperty("coins").GetDouble() };
        var got = new Dictionary<string, object>();
        foreach (var g in pl.GetProperty("levelGot").EnumerateArray()) got[g.GetInt32().ToString()] = true;
        prof["levelGot"] = got;
        string day = pl.GetProperty("day").GetString();
        PagePic you = null;
        if (File.Exists(Res("Characters/characters.json")))
        {
            var ch = JsonDocument.Parse(File.ReadAllText(Res("Characters/characters.json"))).RootElement;
            foreach (var s in ch.GetProperty("stills").EnumerateArray()) if (s.GetProperty("key").GetString() == "mittens") you = JsonSerializer.Deserialize<PagePic>(s.GetProperty("you").GetRawText(), Opts);
        }
        double W = L.reference.px[0], H = L.reference.px[1];
        // the layout's own numbers against what the app measured
        {
            var m = new LevelPassModel(L, W, H, LevelPassData.FromProfile(prof, day, "mittens"), 0);
            var (all, lvx, pill, _) = m.HeaderXs();
            var M = L.measured;
            Console.WriteLine($"header: CLAIM ALL x {all:0.###} (app {M.all[0]}), LV pill x {lvx:0.###} (app {M.lvx[0]}), coins pill x {pill:0.###} (app {M.pill[0]})");
        }
        foreach (var s in doc.GetProperty("shots").GetProperty("list").EnumerateArray())
        {
            string name = s.GetProperty("name").GetString();
            int sel = s.GetProperty("sel").GetInt32();
            double scroll = s.GetProperty("scroll").GetDouble(), endless = s.GetProperty("endless").GetDouble();
            bool opening = s.TryGetProperty("ms", out var msE);
            double now = opening ? msE.GetDouble() : 5000;
            var m = new LevelPassModel(L, W, H, LevelPassData.FromProfile(prof, day, "mittens"), 0) { YouArt = k => you };
            if (m.Sel != sel) m.TapLevel(sel, 0);
            if (s.TryGetProperty("pending", out var pend)) { m.OnClaim = (ls, all) => { }; foreach (var p in pend.EnumerateArray()) m.Claim(p.GetInt32(), 0); }
            m.Track.Value = scroll;
            m.BobEpoch = now - endless;
            yield return Scene(name, s.GetProperty("file").GetString(), (s.TryGetProperty("plate", out var pl1) ? pl1.GetString() : doc.GetProperty("shots").GetProperty("plate").GetString()), "LevelPass", m.Draw(now));
        }
    }

    // ---- the draws -> json, the drawn SVGs rasterised ----------------------------------------------------------------
    public static object Scene(string name, string reference, string plate, string page, PageDraw root, double[] size = null) =>
        new { name, reference, plate, size, res = Res(page), draws = new List<object> { Item(root) } };

    static IEnumerable<object> Shapes(double W, double H)
    {
        var L = JsonSerializer.Deserialize<LevelPassLayout>(File.ReadAllText(Res("LevelPass/levelpass.json")), Opts);
        var prof = new Dictionary<string, object> { ["pxp"] = 2930.0, ["coins"] = 12345.0, ["levelGot"] = new Dictionary<string, object> { ["1"] = true, ["2"] = true } };
        var m = new LevelPassModel(L, W, H, LevelPassData.FromProfile(prof, "2026-11-13", "mittens"), 0);
        yield return Scene($"shape-lp-{W}x{H}", null, null, "LevelPass", m.Draw(5000), new[] { W, H });
        var C = JsonSerializer.Deserialize<CharactersLayout>(File.ReadAllText(Res("Characters/characters.json")), Opts);
        var c = new CharactersModel(C, W, H, C.demo.owned, C.demo.sel, 0);
        yield return Scene($"shape-ch-{W}x{H}", null, null, "Characters", c.Draw(9000), new[] { W, H });
    }

    static object Item(PageDraw d)
    {
        string file = null;
        if (d.Svg != null) file = Raster(d.Svg, d.W, d.H, d.SvgScale);
        return new
        {
            key = d.Key, res = d.Res, file, jpeg = d.Jpeg, m = new[] { d.M.A, d.M.B, d.M.C, d.M.D, d.M.E, d.M.F }, w = d.W, h = d.H,
            uv = new[] { d.U0, d.V0, d.U1, d.V1 }, opacity = d.Opacity,
            clip = d.Clip ? new[] { d.CX0, d.CY0, d.CX1, d.CY1 } : null,
            layer = d.Layer?.Select(Item).ToList(),
        };
    }

    static readonly Dictionary<string, string> Rastered = new Dictionary<string, string>();

    static string Raster(string svg, int w, int h, double scale)
    {
        var key = Convert.ToHexString(SHA1.HashData(Encoding.UTF8.GetBytes(svg + "|" + w + "|" + h + "|" + scale))).Substring(0, 16);
        if (Rastered.TryGetValue(key, out var f)) return f;
        f = Path.Combine(_out, "svg", key + ".png");
        if (!File.Exists(f))
        {
            var root = SvgMarkup.Parse(svg);
            double sw = double.Parse(Find(root)["width"], System.Globalization.CultureInfo.InvariantCulture);
            double sh = double.Parse(Find(root)["height"], System.Globalization.CultureInfo.InvariantCulture);
            var scene = SvgScene.Compile(root, sw * scale, sh * scale, Affine.Identity, null);
            const int ss = 3;
            var b = ReferenceRaster.Render(scene, w, h, ss);
            var o = new byte[w * h * 4];
            float k = 1f / (ss * ss);
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    float r = 0, g = 0, bl = 0, a = 0;
                    for (int sy = 0; sy < ss; sy++)
                        for (int sx = 0; sx < ss; sx++)
                        {
                            int i = ((y * ss + sy) * b.W + x * ss + sx) * 4;
                            r += b.P[i]; g += b.P[i + 1]; bl += b.P[i + 2]; a += b.P[i + 3];
                        }
                    r *= k; g *= k; bl *= k; a *= k;
                    int j = (y * w + x) * 4;
                    float ia = a > 1e-6f ? 1 / a : 0;
                    o[j] = (byte)Math.Round(Math.Min(1, r * ia) * 255); o[j + 1] = (byte)Math.Round(Math.Min(1, g * ia) * 255); o[j + 2] = (byte)Math.Round(Math.Min(1, bl * ia) * 255); o[j + 3] = (byte)Math.Round(Math.Min(1, a) * 255);
                }
            Png.Write(f, w, h, o);
        }
        return Rastered[key] = f;
    }

    static SvgNode Find(SvgNode n) { if (n.Tag == "svg") return n; foreach (var c in n.Children) { var r = Find(c); if (r != null) return r; } return null; }
}
