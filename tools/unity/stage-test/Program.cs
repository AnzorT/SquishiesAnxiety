// The mini-games' rig stages off Unity: tools/rig/sort.html and hop.html compiled into the rig's realm
// (tools/unity/rig/jsc.mjs), driven through Creatures/RigStage.cs with a scene's calls (scenes.json, from scenes.mjs),
// their squishies drawn as Creatures/StageView.cs draws them (each rig's tree from StageRig, placed by the page's box,
// the page's floor shadows, z order, opacity, the board's clip) with the reference rasteriser, and compared with the
// app's page in Chromium (capture.mjs).
//   node tools/unity/stage-test/scenes.mjs && node tools/unity/stage-test/capture.mjs <dir>
//   dotnet run -c Release --project tools/unity/stage-test -- <dir> [scene...]   -> <dir>/unity-<scene>.png, diff-<scene>.png
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Vector;

static class Program
{
    static string Here([System.Runtime.CompilerServices.CallerFilePath] string f = "") => Path.GetDirectoryName(f);
    static readonly string Repo = Path.GetFullPath(Path.Combine(Here(), "../../.."));
    static readonly string Work = Path.Combine(Repo, "webgame/test/out/unity-webgame");
    const int SS = 2;

    public static string Res(string p) => Path.Combine(Repo, "unity/Assets/Resources", p);

    // on the rig thread, as Unity calls the realm (Creatures/Js/RigThread: the compiled functions' frames need its stack)
    static int Main(string[] args) => SquishSquad.Creatures.Js.RigThread.Run(() => MainHere(args));

    static int MainHere(string[] args)
    {
        bool levelCheck = args[0] == "sortlevel", hopCheck = args[0] == "hoplevel";
        string dir = levelCheck ? args[1] : hopCheck ? "." : args[0];
        var want = args.Skip(1).ToHashSet();
        var errors = new List<string>();
        Rt.OnHostError = e => { if (errors.Count < 20) errors.Add(e.ToString()); };
        if (Environment.GetEnvironmentVariable("STAGE_DEBUG") == "1") Rt.OnConsole = t => Console.Error.WriteLine("[console] " + (t.Length > 800 ? t.Substring(0, 800) : t));
        // the app's page draws its rigs without a border look (Unity draws config/roster's: Creatures/Js/RigLooks), so they're
        // compared without one too (the look itself: tools/unity/rig/dump-frames.mjs --look and vector-test)
        RigLooks.Set(0, null);
        var sw = Stopwatch.StartNew();
        bool ok = RigHost.Boot(p => { var f = Path.Combine(Work, p); return File.Exists(f) ? File.ReadAllText(f) : null; });
        Console.Error.WriteLine($"booted in {sw.ElapsedMilliseconds} ms" + (RigHost.BootErrors.Count > 0 ? "; script errors: " + string.Join("; ", RigHost.BootErrors) : ""));
        if (!ok) return 2;
        ReferenceRaster.LoadImage = _ => (0, 0, null);
        if (hopCheck) { int rc = HopLevelCheck.Run(args.Length > 1 ? int.Parse(args[1]) : 12); foreach (var e in errors) Console.Error.WriteLine("[host error] " + e); return rc; }
        if (levelCheck) { int rc = SortLevelCheck.Run(dir, args.Length > 2 ? int.Parse(args[2]) : 12); foreach (var e in errors) Console.Error.WriteLine("[host error] " + e); return rc; }
        var doc = JsonDocument.Parse(File.ReadAllText(Path.Combine(Here(), "scenes.json"))).RootElement;
        string bg = doc.GetProperty("bg").GetString();
        foreach (var sc in doc.GetProperty("scenes").EnumerateArray())
        {
            string name = sc.GetProperty("name").GetString();
            if (want.Count > 0 && !want.Contains(name)) continue;
            Scene(dir, name, sc, bg);
        }
        foreach (var e in errors) Console.Error.WriteLine("[host error] " + e);
        return 0;
    }

    static object Obj(JsonElement e) => e.ValueKind switch
    {
        JsonValueKind.Object => e.EnumerateObject().ToDictionary(p => p.Name, p => Obj(p.Value)),
        JsonValueKind.Array => e.EnumerateArray().Select(Obj).ToList(),
        JsonValueKind.String => e.GetString(),
        JsonValueKind.Number => e.GetDouble(),
        JsonValueKind.True => true,
        JsonValueKind.False => false,
        _ => null,
    };

    static void Scene(string dir, string name, JsonElement sc, string bg)
    {
        string page = sc.GetProperty("page").GetString();
        int W = sc.GetProperty("W").GetInt32(), H = sc.GetProperty("H").GetInt32(); double dpr = sc.GetProperty("dpr").GetDouble();
        var stage = new RigStage(page);
        bool Until(Func<Dictionary<string, object>, bool> f, int max)
        {
            for (int i = 0; i < max; i++)
            {
                foreach (var m in stage.Messages()) if (f(m)) return true;
                RigHost.Frame(16);
            }
            return false;
        }
        if (!stage.Ready && !Until(m => (m["type"] as string) == "ready", 600)) { Console.WriteLine($"{name}: the {page} page never came up"); return; }
        stage.Messages();
        stage.Size(W, H);
        var sw = Stopwatch.StartNew();
        int frames = 0;
        foreach (var step in sc.GetProperty("steps").EnumerateArray())
        {
            if (step.TryGetProperty("wait", out var w))
            {
                if (w.ValueKind == JsonValueKind.String) { if (!Until(m => (m["type"] as string) == "cast", 900)) Console.WriteLine($"{name}: no cast message"); }
                else for (int i = 0; i < w.GetDouble() / 16; i++) { RigHost.Frame(16); frames++; }
                continue;
            }
            var a = step.GetProperty("args").EnumerateArray().Select(Obj).ToArray();
            if (!stage.Call(step.GetProperty("call").GetString(), a)) Console.WriteLine($"{name}: no call {step.GetProperty("call").GetString()}");
        }
        if (Environment.GetEnvironmentVariable("STAGE_DEBUG") == "1")
        {
            var api = Rt.Get(Rt.Get(Rt.Get(Rt.G("__stages"), page), "win"), page + "Stage");
            var C = Rt.Get(api, "_C");
            foreach (var id in new[] { "p", "f0", "2" })
            {
                var c = Rt.Invoke(C, "get", id); if (c.IsNullish) continue;
                var I = Rt.Get(c, "I"); var svg = Dom.FirstSvg(Rt.Get(c, "inner"));
                string bbox = "?"; try { var b = Rt.Invoke(svg, "getBBox"); bbox = Rt.ToNum(Rt.Get(b, "width")) + "x" + Rt.ToNum(Rt.Get(b, "height")); } catch (Exception e) { bbox = "throws " + e.Message; }
                Console.WriteLine($"  [debug] {id}: I {(I.IsNullish ? "none" : "yes")} generic {Rt.ToStr(Rt.Get(I, "generic"))} ready {Rt.ToStr(Rt.Get(I, "ready"))} bb {(Rt.Get(c, "bb").IsNullish ? "none" : "set")} svg {(svg.IsNullish ? "none" : "yes")} bbox {bbox} moves {Rt.ToNum(Rt.Get(Rt.Get(c, "moves"), "length"))}");
            }
        }
        var items = stage.Read();
        var clip = stage.Clip();
        Console.WriteLine($"{name}: {items.Count} squishies, {frames} frames in {sw.ElapsedMilliseconds} ms; clip {(clip == null ? "none" : clip.ToString())}");
        foreach (var it in items) Console.WriteLine($"  {it.Id} {it.Key}: box [{it.Box.A:0.###} {it.Box.B:0.###} {it.Box.C:0.###} {it.Box.D:0.###} {it.Box.E:0.##} {it.Box.F:0.##}] o {it.Opacity} z {it.Z} drew {it.Drew}" + (it.HasShadow ? $" shadow [{it.ShadowBox.A:0.###} {it.ShadowBox.D:0.###} {it.ShadowBox.E:0.##} {it.ShadowBox.F:0.##}] o {it.ShadowOpacity}" : ""));

        // drawn as StageView draws them: bottom to top by z, then the page's order (each squishy's shadow before it)
        int PW = (int)Math.Round(W * dpr), PH = (int)Math.Round(H * dpr);
        var canvas = new float[PW * SS * PH * SS * 4];
        var draw = new List<(double z, int dom, RigStage.Item it, bool shadow)>();
        foreach (var it in items) { draw.Add((it.Z, it.Index * 2 + 1, it, false)); if (it.HasShadow) draw.Add((it.ShadowZ, it.Index * 2, it, true)); }
        draw.Sort((p, q) => p.z != q.z ? p.z.CompareTo(q.z) : p.dom.CompareTo(q.dom));
        var px = Affine.ScaleBy(dpr, dpr);
        double rigShadow = 0;   // (the rig's own floor shadow: hidden on both pages; hop.html draws its .sh since 2026-11-26)
        foreach (var (_, _, it, shadow) in draw)
        {
            SvgScene scene; double op;
            if (shadow) { scene = SvgScene.Compile(SvgMarkup.Parse(SHADOW), 100, 100, px * it.ShadowBox); op = it.ShadowOpacity; }
            else
            {
                var tree = new StageRig(it.Host, rigShadow).TreeAt(0);
                if (tree == null) continue;
                scene = SvgScene.Compile(tree, 100, 100, px * it.Box); op = it.Opacity;
            }
            if (op <= 0) continue;
            var b = ReferenceRaster.Render(scene, PW, PH, SS);
            for (int i = 0; i < canvas.Length; i += 4)
            {
                float sa = b.P[i + 3] * (float)op; if (sa <= 0) continue;
                float k = 1 - sa;
                canvas[i] = b.P[i] * (float)op + canvas[i] * k; canvas[i + 1] = b.P[i + 1] * (float)op + canvas[i + 1] * k;
                canvas[i + 2] = b.P[i + 2] * (float)op + canvas[i + 2] * k; canvas[i + 3] = sa + canvas[i + 3] * k;
            }
        }
        // over the flat colour, box-filtered down
        float br = Convert.ToInt32(bg.Substring(1, 2), 16) / 255f, bgc = Convert.ToInt32(bg.Substring(3, 2), 16) / 255f, bb = Convert.ToInt32(bg.Substring(5, 2), 16) / 255f;
        var ours = new byte[PW * PH * 4];
        for (int y = 0; y < PH; y++)
            for (int x = 0; x < PW; x++)
            {
                float r = 0, g = 0, bl = 0;
                for (int sy = 0; sy < SS; sy++)
                    for (int sx = 0; sx < SS; sx++)
                    {
                        int i = ((y * SS + sy) * PW * SS + x * SS + sx) * 4; float k = 1 - canvas[i + 3];
                        r += canvas[i] + br * k; g += canvas[i + 1] + bgc * k; bl += canvas[i + 2] + bb * k;
                    }
                int o = (y * PW + x) * 4; float n = 1f / (SS * SS);
                ours[o] = (byte)Math.Round(Math.Min(1, r * n) * 255); ours[o + 1] = (byte)Math.Round(Math.Min(1, g * n) * 255); ours[o + 2] = (byte)Math.Round(Math.Min(1, bl * n) * 255); ours[o + 3] = 255;
            }
        Png.Write(Path.Combine(dir, "unity-" + name + ".png"), PW, PH, ours);
        var appF = Path.Combine(dir, name + ".png");
        if (!File.Exists(appF)) { Console.WriteLine($"{name}: drawn (no app shot)"); return; }
        var (aw, ah, app) = Png.Read(appF);
        if (aw != PW || ah != PH) { Console.WriteLine($"{name}: the app's shot is {aw}x{ah}, ours {PW}x{PH}"); return; }
        int visible = 0, inked = 0; var diff = new byte[PW * PH * 4];
        for (int i = 0; i < PW * PH * 4; i += 4)
        {
            int d = Math.Max(Math.Abs(app[i] - ours[i]), Math.Max(Math.Abs(app[i + 1] - ours[i + 1]), Math.Abs(app[i + 2] - ours[i + 2])));
            bool inApp = Math.Abs(app[i] - br * 255) > 6 || Math.Abs(app[i + 1] - bgc * 255) > 6 || Math.Abs(app[i + 2] - bb * 255) > 6;
            bool inOurs = Math.Abs(ours[i] - br * 255) > 6 || Math.Abs(ours[i + 1] - bgc * 255) > 6 || Math.Abs(ours[i + 2] - bb * 255) > 6;
            if (inApp || inOurs) inked++;
            bool v = d > 24; if (v) visible++;
            byte gr = (byte)(ours[i] * 0.3 + 150);
            diff[i] = v ? (byte)255 : gr; diff[i + 1] = v ? (byte)0 : gr; diff[i + 2] = v ? (byte)60 : gr; diff[i + 3] = 255;
        }
        Png.Write(Path.Combine(dir, "diff-" + name + ".png"), PW, PH, diff);
        Console.WriteLine($"{name}: {visible} of {inked} drawn px differ visibly ({100.0 * visible / Math.Max(1, inked):0.00} % of the squishies' px)");
    }

    public const string SHADOW = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\" viewBox=\"0 0 100 100\"><defs><radialGradient id=\"sh\" cx=\"50\" cy=\"50\" r=\"50\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-color=\"#6a1b9a\" stop-opacity=\"0.34\"/><stop offset=\"0.55\" stop-color=\"#6a1b9a\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#6a1b9a\" stop-opacity=\"0\"/></radialGradient></defs><circle cx=\"50\" cy=\"50\" r=\"50\" fill=\"url(#sh)\"/></svg>";
}
