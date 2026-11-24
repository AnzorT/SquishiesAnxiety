// The compiled rig off Unity (run.mjs drives it): runs the scenarios a list names, in its order, and writes each one's
// snapshots, one JSON line per (creature, scenario); `bench` times frames.
//   dotnet bin/Release/net8.0/RigTest.dll run <list.json> <out.ndjson>
//   dotnet bin/Release/net8.0/RigTest.dll bench [key ...]
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SquishSquad.Creatures.Js;

static class Program
{
    static readonly string Repo = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../.."));
    static readonly string Work = Path.Combine(Repo, "webgame/test/out/unity-webgame");

    static int Main(string[] args)
    {
        var hostErrors = new List<string>();
        Rt.OnHostError = e => { if (hostErrors.Count < 20) hostErrors.Add(e.ToString()); };
        if (args.Length > 0 && args[0] == "console") Rt.OnConsole = s => Console.Error.WriteLine("[console] " + s);
        var sw = Stopwatch.StartNew();
        if (!RigHost.Boot(p => { var f = Path.Combine(Work, p); return File.Exists(f) ? File.ReadAllText(f) : null; })) { Console.Error.WriteLine(string.Join("\n", RigHost.BootErrors)); return 2; }
        Console.Error.WriteLine($"booted in {sw.ElapsedMilliseconds} ms" + (RigHost.BootErrors.Count > 0 ? "; script errors: " + string.Join("; ", RigHost.BootErrors) : ""));
        int rc = args.Length > 0 && args[0] == "bench" ? Bench(args) : Run(args[1], args[2]);
        foreach (var e in hostErrors) Console.Error.WriteLine("[host error] " + e);
        return rc;
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

    // frames per second of the rig alone (clock + markup), one creature and three at once
    static int Bench(string[] args)
    {
        var keys = args.Length > 1 ? args[1..] : new[] { "mittens", "lumi", "biscuit" };
        foreach (var n in new[] { 1, 3 })
        {
            var ids = new List<int>();
            for (int i = 0; i < n; i++) { ids.Add(RigHost.Mount(keys[i % keys.Length])); }
            foreach (var id in ids) RigHost.Play(id, "dance");
            for (int f = 0; f < 120; f++) { RigHost.Frame(16); foreach (var id in ids) RigHost.Svg(id); }   // warm up
            GC.Collect();
            long gc0 = GC.GetTotalAllocatedBytes(true);
            var sw = Stopwatch.StartNew();
            int frames = 600;
            for (int f = 0; f < frames; f++) { RigHost.Frame(16); foreach (var id in ids) RigHost.Svg(id); }
            double ms = sw.Elapsed.TotalMilliseconds / frames;
            long alloc = (GC.GetTotalAllocatedBytes(true) - gc0) / frames;
            var sw2 = Stopwatch.StartNew(); long g2 = GC.GetTotalAllocatedBytes(true);
            for (int f = 0; f < frames; f++) RigHost.Frame(16);
            Console.WriteLine($"   the rig alone (no markup): {sw2.Elapsed.TotalMilliseconds / frames:0.00} ms, {(GC.GetTotalAllocatedBytes(true) - g2) / frames / 1024} KB per frame");
            Console.WriteLine($"{n} creature(s) [{string.Join(", ", ids.ConvertAll(i => keys[(i - ids[0]) % keys.Length]))}]: {ms:0.00} ms per frame ({1000 / ms:0} frames/s), {alloc / 1024} KB allocated per frame");
            foreach (var id in ids) RigHost.Unmount(id);
        }
        return 0;
    }
}
