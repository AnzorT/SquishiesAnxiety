// The level (capture.mjs's scenario) from the Unity code: SdLevel on a Ticker stepped as the page's virtual clock was
// (16 ms frames; a pause, a second, RESTART: T0), the same taps at the same moments, the screen drawn at each moment
// the app's was shot and compared with it. The buddy is left out (the app's is the creature's live rig, Unity's its still
// for now), and the left-out rectangle is reported.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui.Cards;

static class PlayTest
{
    public static readonly (float, float, float, float) Buddy = (658, 80, 800, 214);

    public static SdCreature[] Art()
    {
        var doc = JsonDocument.Parse(File.ReadAllText(Program.Res("Squishdoku/squishdoku.json"))).RootElement;
        var list = new List<SdCreature>();
        foreach (var a in doc.GetProperty("artList").EnumerateArray())
            list.Add(new SdCreature(a.GetProperty("key").GetString(), "Stack/art/" + a.GetProperty("file").GetString(), (float)a.GetProperty("ar").GetDouble()));
        return list.ToArray();
    }

    public static int Run(string dir)
    {
        var sc = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "scenario.json"))).RootElement;
        int lv = sc.GetProperty("lv").GetInt32();
        bool head = sc.TryGetProperty("head", out var hd) && hd.GetBoolean();
        SdCreature mittens = null;
        foreach (var c in Art()) if (c.Key == "mittens") mittens = c;
        // Preview.js's made-up player (its XP, its Squishdoku record)
        SdLevel.Profile = new Dictionary<string, object> { ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" }, ["sdk"] = new Dictionary<string, object> { ["plays"] = 3.0, ["lv"] = 12.0 } };
        var tk = new Ticker(0);
        var level = new SdLevel(832, 384, lv, head, new[] { mittens }, mittens, n => File.ReadAllText(Program.Res("Squishdoku/" + n + ".xml")), tk);
        string lastPhase = null; double t0 = 0;
        void RunTo(double ms)
        {
            while (tk.Now < ms - 1e-9)
            {
                tk.Tick(Math.Min(tk.Now + 16, ms));
                if (Environment.GetEnvironmentVariable("SD_DEBUG") != null && level.Phase != lastPhase) { lastPhase = level.Phase; Console.WriteLine($"  {tk.Now - t0,8} ms: {lastPhase}"); }
            }
        }
        // played for a while, paused, a second, RESTART
        RunTo(4000);
        level.Pause();
        double p = tk.Now;
        RunTo(p + sc.GetProperty("pauseFor").GetDouble());
        level.Layers();
        CardButton restart = null;
        foreach (var c in level.Cards) foreach (var b in c.Buttons) if (b.Look.Label == "RESTART") restart = b;
        var at = restart.Face.Transform.Apply(new SquishSquad.Vector.Vec2(restart.W / 2, restart.H / 2));
        level.Down((float)at.X, (float)at.Y);
        level.Up((float)at.X, (float)at.Y);
        double T0 = tk.Now; t0 = T0;
        double worst = 0, sum = 0;
        int shots = 0;
        var only = Environment.GetEnvironmentVariable("SD_ONLY");
        foreach (var s in sc.GetProperty("steps").EnumerateArray())
        {
            if (only != null && s.TryGetProperty("shot", out _) && !only.Split(',').Contains(s.GetProperty("at").GetDouble().ToString())) { RunTo(T0 + s.GetProperty("at").GetDouble()); continue; }
            double ms = s.GetProperty("at").GetDouble();
            RunTo(T0 + ms);
            if (s.TryGetProperty("tap", out var tap))
            {
                level.TapCell(tap[0].GetInt32() * level.Spec.N + tap[1].GetInt32());
            }
            else if (s.TryGetProperty("tool", out var tool))
            {
                var r = SdArt.Right(832, 384, level.XTool);
                float x = r.ToolX + SdArt.ToolW / 2, y = r.ToolY + (tool.GetString() == "place" ? 0 : SdArt.ToolH + 8) + SdArt.ToolH / 2;
                level.Down(x, y); level.Up(x, y);
            }
            else
            {
                var app = Path.Combine(dir, $"play-{ms}.png");
                if (!File.Exists(app)) continue;
                var layers = level.Layers();
                if (Environment.GetEnvironmentVariable("SD_LAYERS") is string want)
                    foreach (var l in layers) if (l.Name.StartsWith(want)) { var m = l.Transform; Console.WriteLine($"  {l.Name}: matrix({m.A:0.####} {m.B:0.####} {m.C:0.####} {m.D:0.####} {m.E:0.##} {m.F:0.##}) o={l.Opacity:0.###} {l.W}x{l.H}"); }
                var svg = Program.Screen(layers);
                File.WriteAllText(Path.Combine(dir, $"play-{ms}-unity.svg"), svg);
                double pct = Program.Compare(svg, app, Path.Combine(dir, $"play-{ms}-unity.png"), Path.Combine(dir, $"play-{ms}-diff.png"), out int v, out int total, Buddy);
                Console.WriteLine($"play {ms,6} ms ({level.Phase,-8}): {v,6} of {total} px differ visibly ({pct:0.00} %)");
                worst = Math.Max(worst, pct); sum += pct; shots++;
            }
        }
        Console.WriteLine($"mean {sum / Math.Max(1, shots):0.00} %, worst {worst:0.00} % (the buddy, x 658-800 y 80-214, left out)");
        return 0;
    }
}
