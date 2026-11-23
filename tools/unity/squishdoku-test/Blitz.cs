// Blitz (blitz.mjs's run) from the Unity code: SdBlitz on a Ticker stepped as the page's virtual clock was (16 ms frames,
// T0 when the countdown's timers are set), the app's boards handed in, the same taps and presses at the same moments, the
// screen drawn at each moment the app's was shot and compared with it. The buddy (the app's live rig) is left out.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Vector;

static class BlitzTest
{
    public static readonly (float, float, float, float) Buddy = (650, 190, 810, 330);

    public static Dictionary<string, object> PreviewPlayer() => new Dictionary<string, object>
    {
        ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" },
        ["sdk"] = new Dictionary<string, object> { ["plays"] = 3.0, ["lv"] = 12.0 },
    };

    public static SdBlitz Make(Ticker tk, List<Puzzle> boards)
    {
        SdCreature mittens = null;
        foreach (var c in PlayTest.Art()) if (c.Key == "mittens") mittens = c;
        var b = new SdBlitz(832, 384, new[] { mittens }, mittens, n => File.ReadAllText(Program.Res("Squishdoku/" + n + ".xml")), tk) { AdsFree = true, Save = false };
        if (boards != null)
        {
            int k = 0;
            b.PuzzleSource = (n, tier) => boards[Math.Min(k++, boards.Count - 1)];
        }
        return b;
    }

    public static int Run(string dir)
    {
        var sc = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "blitz.json"))).RootElement;
        var boards = new List<Puzzle>();
        foreach (var b in sc.GetProperty("boards").EnumerateArray())
            boards.Add(new Puzzle { N = b.GetProperty("n").GetInt32(), Regions = b.GetProperty("regions").EnumerateArray().Select(v => v.GetInt32()).ToArray(), Solution = b.GetProperty("solution").EnumerateArray().Select(v => v.GetInt32()).ToArray() });
        // the C# engine makes the app's board from the same seed
        var made = Engine.MakePuzzle(4, 0, 1073741824);
        Console.WriteLine($"the engine's board from seed 1073741824 is the app's: {made.Regions.SequenceEqual(boards[0].Regions) && made.Solution.SequenceEqual(boards[0].Solution)}");
        SdLevel.Profile = PreviewPlayer();
        var tk = new Ticker(0);
        var g = Make(tk, boards);
        void RunTo(double ms) { while (tk.Now < ms - 1e-9) { tk.Tick(Math.Min(tk.Now + 16, ms)); } }
        while (g.CountdownAt < 0) tk.Tick(tk.Now + 16);
        double T0 = g.CountdownAt;
        double worst = 0, sum = 0; int shots = 0;
        foreach (var s in sc.GetProperty("steps").EnumerateArray())
        {
            double ms = s.GetProperty("at").GetDouble();
            RunTo(T0 + ms);
            if (s.TryGetProperty("tap", out var tap))
            {
                int row = s.GetProperty("row").GetInt32(), n = g.Puzzle.N, sol = g.Puzzle.Solution[row];
                g.TapCell(row * n + (tap.GetString() == "right" ? sol : (sol + 1) % n));
            }
            else if (s.TryGetProperty("press", out var label)) { if (!g.Press(label.GetString())) Console.WriteLine($"  no {label.GetString()} to press"); }
            else if (s.TryGetProperty("crib", out _)) { g.Down(34, 34); g.Up(34, 34); }
            else
            {
                var app = Path.Combine(dir, $"blitz-{ms}.png");
                if (!File.Exists(app)) continue;
                var svg = Program.Screen(g.Layers());
                File.WriteAllText(Path.Combine(dir, $"blitz-{ms}-unity.svg"), svg);
                double pct = Program.Compare(svg, app, Path.Combine(dir, $"blitz-{ms}-unity.png"), Path.Combine(dir, $"blitz-{ms}-diff.png"), out int v, out int total, Buddy);
                Console.WriteLine($"blitz {ms,6} ms ({g.Phase,-9}): {v,6} of {total} px differ visibly ({pct:0.00} %)");
                worst = Math.Max(worst, pct); sum += pct; shots++;
            }
        }
        Console.WriteLine($"mean {sum / Math.Max(1, shots):0.00} %, worst {worst:0.00} % (the buddy, x 650-810 y 190-330, left out)");
        return 0;
    }
}
