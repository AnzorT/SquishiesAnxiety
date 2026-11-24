// The yard games off Unity (Games/Yard/YardJs.cs on the compiled realm, tools/unity/rig/jsc.mjs):
//   dotnet run -c Release --project tools/unity/yard-test -- smoke [game] [ms]      a game opened, played `ms`, what Unity
//                                                                                   reads back printed
//   dotnet run -c Release --project tools/unity/yard-test -- shots <capture dir>    (capture.mjs's states) drawn as Unity
//                                                                                   draws them and compared with the app's
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SquishSquad.Creatures.Js;
using SquishSquad.Games.Yard;

static partial class Program
{
    static string Here([System.Runtime.CompilerServices.CallerFilePath] string f = "") => Path.GetDirectoryName(f);
    public static readonly string Repo = Path.GetFullPath(Path.Combine(Here(), "../../.."));
    static readonly string Work = Path.Combine(Repo, "webgame/test/out/unity-webgame");
    public static string Res(string p) => Path.Combine(Repo, "unity/Assets/Resources", p);

    static readonly List<string> HostErrors = new List<string>();
    public static string SaveJson;

    public static bool Boot()
    {
        Rt.OnHostError = e => { if (HostErrors.Count < 20) HostErrors.Add(e.ToString()); };
        if (Environment.GetEnvironmentVariable("YARD_CONSOLE") == "1") Rt.OnConsole = s => Console.Error.WriteLine("[console] " + (s.Length > 600 ? s.Substring(0, 600) : s));
        var sw = Stopwatch.StartNew();
        bool ok = RigHost.Boot(p =>
        {
            if (p == "local/yardgames.v1") return SaveJson;
            var f = Path.Combine(Work, p); return File.Exists(f) ? File.ReadAllText(f) : null;
        });
        Console.Error.WriteLine($"booted in {sw.ElapsedMilliseconds} ms" + (RigHost.BootErrors.Count > 0 ? "; script errors: " + string.Join("; ", RigHost.BootErrors) : ""));
        return ok && YardJs.Available;
    }

    static int Main(string[] args)
    {
        string mode = args.Length > 0 ? args[0] : "smoke";
        if (!Boot()) { Console.Error.WriteLine("the yard games aren't in the realm"); return 2; }
        int rc = mode switch
        {
            "smoke" => Smoke(args.Length > 1 ? args[1] : "hoop", args.Length > 2 ? double.Parse(args[2]) : 2000),
            "shots" => Shots(args[1], args.Length > 2 ? args[2] : "hoop"),
            _ => 1,
        };
        foreach (var e in HostErrors) Console.Error.WriteLine("[host error] " + e);
        return rc;
    }

    static int Smoke(string game, double ms)
    {
        if (!YardJs.Open(game, "mittens")) { Console.Error.WriteLine("no game " + game); return 1; }
        for (int i = 0; i < 60; i++) RigHost.Frame(16);
        Console.WriteLine("intro: " + YardJs.UiJson());
        YardJs.Click("play");
        var sw = Stopwatch.StartNew();
        int frames = (int)(ms / 16);
        for (int i = 0; i < frames; i++) RigHost.Frame(16);
        Console.WriteLine($"{frames} frames in {sw.ElapsedMilliseconds} ms");
        Console.WriteLine("play: " + YardJs.UiJson());
        foreach (var el in YardJs.Stage())
        {
            string tag = YardJs.Tag(el), cls = YardJs.Class(el);
            if (tag == "svg") Console.WriteLine($"  svg {cls}: {YardJs.Markup(el).Length} chars");
            else if (YardJs.Has(el, "yg-crl")) foreach (var h in YardJs.Children(el)) Console.WriteLine($"  creature [{string.Join(", ", YardJs.Box(h))}] svg {(YardJs.FirstSvg(h).IsNullish ? "none" : YardJs.Markup(YardJs.FirstSvg(h)).Length + " chars")}");
            else Console.WriteLine($"  {tag} .{cls}");
        }
        Console.WriteLine("sfx: " + string.Join(",", YardJs.Sfx()));
        return 0;
    }
}
