// The compiled rig off Unity (run.mjs drives it): runs the scenarios a list names, in its order, and writes each one's
// snapshots, one JSON line per (creature, scenario); `bench` times frames.
//   dotnet bin/Release/net8.0/RigTest.dll run <list.json> <out.ndjson>
//   dotnet bin/Release/net8.0/RigTest.dll bench [key ...]
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Vector;

static class Program
{
    // (the repo from this file's own place, wherever the build went)
    static string Here([System.Runtime.CompilerServices.CallerFilePath] string f = "") => Path.GetDirectoryName(f);
    static readonly string Repo = Path.GetFullPath(Path.Combine(Here(), "../../.."));
    static readonly string Work = Path.Combine(Repo, "webgame/test/out/unity-webgame");

    static readonly Dictionary<int, RigTree> Trees = new Dictionary<int, RigTree>();
    static int TreeChecks, TreeBad;

    static int Main(string[] args)
    {
        var hostErrors = new List<string>();
        Rt.OnHostError = e => { if (hostErrors.Count < 20) hostErrors.Add(e.ToString()); };
        if (args.Length > 0 && args[0] == "console") Rt.OnConsole = s => Console.Error.WriteLine("[console] " + s);
        var sw = Stopwatch.StartNew();
        if (!RigHost.Boot(p => { var f = Path.Combine(Work, p); return File.Exists(f) ? File.ReadAllText(f) : null; })) { Console.Error.WriteLine(string.Join("\n", RigHost.BootErrors)); return 2; }
        Console.Error.WriteLine($"booted in {sw.ElapsedMilliseconds} ms" + (RigHost.BootErrors.Count > 0 ? "; script errors: " + string.Join("; ", RigHost.BootErrors) : ""));
        // the scenarios read the markup the way Unity does (RigHost.Svg), compared with the JS stand-in's own
        // ... and checks the tree Unity draws from (RigTree, no text) against the parsed markup, every snapshot
        Rt.GSet("__svgOf", Rt.Fn((s, n, a, b, c, d, r) =>
        {
            int id = (int)Rt.ToNum(a);
            var markup = RigHost.Svg(id);
            if (!Trees.TryGetValue(id, out var t)) Trees[id] = t = new RigTree();
            var tree = t.Build(RigHost.SvgElement(id));
            TreeChecks++;
            string where = "no tree";
            if (markup != null && (tree == null || !RigTree.Same(tree, SvgMarkup.Parse(markup), out where))) { TreeBad++; if (TreeBad < 4) Console.Error.WriteLine("[tree] differs from the parsed markup: " + where); }
            return markup;
        }, 1, "svgOf", false));
        if (args.Length > 0 && args[0] == "house") return House(args[1], args[2]);
        int rc = args.Length > 0 && args[0] == "bench" ? Bench(args) : Run(args[1], args[2]);
        foreach (var e in hostErrors) Console.Error.WriteLine("[host error] " + e);
        if (TreeChecks > 0) Console.Error.WriteLine($"direct trees: {TreeChecks - TreeBad}/{TreeChecks} the same as the parsed markup");
        if (TreeBad > 0) rc = Math.Max(rc, 3);
        return rc;
    }

    // house.mjs: each call through RigHost.HouseEval (as House/HouseDraw.cs's Eval in Unity), the clock moved as
    // draw-server.mjs moves it first; the answers as a JSON array
    static int House(string callsFile, string outFile)
    {
        for (int i = 0; i < 20; i++) RigHost.Frame(40);
        int errs = 0;
        RigHost.HouseError = (n, e) => { if (errs++ < 3) Console.Error.WriteLine($"[house] {n}: {(e is JsThrow ? e.Message : e.ToString().Substring(0, Math.Min(1500, e.ToString().Length)))}"); };
        var calls = (JsArray)Rt.Invoke(Rt.G("JSON"), "parse", File.ReadAllText(callsFile)).O;
        var outs = new List<string>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < calls.Count; i++) outs.Add(RigHost.HouseEval(Rt.ToStr(calls.At(i))));
        Console.Error.WriteLine($"{calls.Count} house calls in {sw.ElapsedMilliseconds} ms");
        var sb = new StringBuilder("[");
        for (int i = 0; i < outs.Count; i++) { if (i > 0) sb.Append(','); sb.Append(outs[i] == null ? "null" : Rt.ToStr(Rt.Invoke(Rt.G("JSON"), "stringify", outs[i]))); }
        File.WriteAllText(outFile, sb.Append(']').ToString(), new UTF8Encoding(false));
        return 0;
    }

    static int Run(string listFile, string outFile)
    {
        var list = (JsArray)Rt.Invoke(Rt.G("JSON"), "parse", File.ReadAllText(listFile)).O;
        var scn = Rt.G("__scn");
        using var w = outFile == "-" ? new StreamWriter(Console.OpenStandardOutput(), new UTF8Encoding(false)) : new StreamWriter(outFile, false, new UTF8Encoding(false));
        var sw = Stopwatch.StartNew();
        long frames = 0;
        for (int i = 0; i < list.Count; i++)
        {
            var item = list.At(i);
            string key = Rt.ToStr(Rt.GetIdx(item, 0)), name = Rt.ToStr(Rt.GetIdx(item, 1));
            V shots;
            string err = null;
            try
            {
                Rt.Invoke(scn, "start", key, name);
                Rt.RunMicrotasks();
                shots = Rt.Invoke(scn, "run");
                Rt.RunMicrotasks();
                Rt.Invoke(scn, "stop");
                Rt.RunMicrotasks();
            }
            catch (Exception e) { shots = Rt.Arr(); err = e is JsThrow ? e.Message : e.ToString(); try { Rt.Invoke(scn, "stop"); } catch (Exception) { } }
            var line = Rt.NewObj(3).Put("key", key).Put("name", name).Put("frames", shots);
            if (err != null) line.Put("error", err);
            w.WriteLine(Rt.ToStr(Rt.Invoke(Rt.G("JSON"), "stringify", line.V)));
            w.Flush();
            frames += ((JsArray)shots.O).Count;
        }
        Console.Error.WriteLine($"{list.Count} runs, {frames} snapshots in {sw.ElapsedMilliseconds} ms");
        return 0;
    }

    // the whole per-frame path, one creature and three at once: the rig (clock), then what Unity does with each frame
    // until it draws: before, markup -> SvgMarkup.Parse -> SvgScene.Compile; now, RigTree (no text) -> SvgScene.Compile
    static int Bench(string[] args)
    {
        AllocListener al = null;
        if (args.Length > 1 && args[1] == "alloc") { al = new AllocListener(); args = args[1..]; }
        var keys = args.Length > 1 ? args[1..] : new[] { "mittens", "lumi", "biscuit" };
        foreach (var n in new[] { 1, 3 })
        {
            var ids = new List<int>();
            for (int i = 0; i < n; i++) ids.Add(RigHost.Mount(keys[i % keys.Length]));
            var trees = new Dictionary<int, RigTree>();
            var pool = new Vec2Pool();
            foreach (var id in ids) { RigHost.Play(id, "dance"); trees[id] = new RigTree(); }
            var modes = new (string name, Action<int> draw)[]
            {
                ("rig alone", id => { }),
                ("markup", id => RigHost.Svg(id)),
                ("markup + parse + compile (before)", id => SvgScene.Compile(SvgMarkup.Parse(RigHost.Svg(id)), 300, 300, Affine.Translate(75, 75))),
                ("tree + compile (now)", id => { using (Vec2Pool.Lend(pool)) SvgScene.Compile(trees[id].Build(RigHost.SvgElement(id)), 300, 300, Affine.Translate(75, 75)); pool.Recycle(); }),
            };
            for (int f = 0; f < 1500; f++) { RigHost.Frame(16); foreach (var id in ids) modes[3].draw(id); }   // warm up (the JIT's tiers)
            Console.WriteLine($"{n} creature(s) [{string.Join(", ", ids.ConvertAll(i => keys[(i - ids[0]) % keys.Length]))}]:");
            foreach (var (name, draw) in modes)
            {
                GC.Collect();
                long gc0 = GC.GetTotalAllocatedBytes(true);
                if (al != null) al.On = true;
                var sw = Stopwatch.StartNew();
                int frames = 600;
                for (int f = 0; f < frames; f++) { RigHost.Frame(16); foreach (var id in ids) draw(id); }
                double ms = sw.Elapsed.TotalMilliseconds / frames;
                long alloc = (GC.GetTotalAllocatedBytes(true) - gc0) / frames;
                Console.WriteLine($"   {name,-36} {ms,6:0.00} ms, {alloc / 1024,6} KB allocated per frame");
                if (al != null)
                {
                    al.On = false; long tot = 0; foreach (var v in al.ByType.Values) tot += v;
                    var l = new List<KeyValuePair<string, long>>(al.ByType); l.Sort((x, y) => y.Value.CompareTo(x.Value));
                    foreach (var kv in l.GetRange(0, Math.Min(8, l.Count))) Console.WriteLine($"        {kv.Value * 100.0 / Math.Max(1, tot),5:0.0} %  {kv.Key}");
                    al.ByType.Clear();
                }
            }
            foreach (var id in ids) RigHost.Unmount(id);
        }
        return 0;
    }
}
