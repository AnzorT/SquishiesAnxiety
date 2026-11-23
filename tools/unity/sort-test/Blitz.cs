// dotnet run -c Release --project tools/unity/sort-test -- blitz <capture dir>   (blitz.mjs's output)
// Plays the captured Blitz run with the Unity code (SortLevel.Blitz on the boards the app dealt, the tumble's random
// numbers it drew, the win card's creatures it picked; Preview.js's player with Remove Ads and nothing saved), the clock
// stepped 16 ms a frame as blitz.mjs stepped the page's, the same taps at the same moments, and compares each moment's
// screen with the app's.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Sort;
using SquishSquad.Vector;

static class BlitzTest
{
    public static int Run(string dir)
    {
        var js = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "blitz.json"))).RootElement;
        var tk = new Ticker(0);
        Ticker.Default = tk;
        var profile = new Dictionary<string, object> { ["coins"] = 100.0, ["gems"] = 600.0, ["sort"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 } };
        var boards = js.GetProperty("boards").EnumerateArray().Select(Program.BoardOf).ToList();
        int dealt = 0;
        var level = SortLevel.Blitz(832, 384, Program.Data(), profile);
        level.Save = false;
        level.MakeBoardHook = _ => boards[Math.Min(dealt++, boards.Count - 1)];
        var q = new Queue<double>(js.GetProperty("randoms").EnumerateArray().Select(e => e.GetDouble()));
        level.Random = () => q.Count > 0 ? q.Dequeue() : 0.5;
        if (js.TryGetProperty("uris", out var u) && u.ValueKind == JsonValueKind.Array)
        {
            var pics = u.EnumerateArray().Select(e => e.ValueKind == JsonValueKind.String ? Program.Uri(e.GetString()) : null).ToArray();
            level.PickCreatures = (_, k) => pics;
        }
        level.Start();
        level.Update();
        string bg = File.ReadAllText(Program.Res("Sort/bg.xml"));
        var only = Environment.GetEnvironmentVariable("ONLY");
        foreach (var e in js.GetProperty("events").EnumerateArray())
        {
            double ms = e.GetProperty("ms").GetDouble();
            // (DT: draw the shots that much earlier or later, to see whether a difference is a frame's timing)
            var dt = Environment.GetEnvironmentVariable("DT");
            double at = ms + (dt != null && e.GetProperty("kind").GetString() == "shot" ? double.Parse(dt) : 0);
            while (tk.Now < at) { tk.Tick(Math.Min(tk.Now + 16, at)); level.Update(); }
            if (e.GetProperty("kind").GetString() == "tap")
            {
                float x = (float)e.GetProperty("x").GetDouble(), y = (float)e.GetProperty("y").GetDouble();
                level.Down(x, y); level.Update();
                level.Up(x, y); level.Update();
                continue;
            }
            level.Update();
            var app = Path.Combine(dir, $"blitz-{ms}.png");
            if (!File.Exists(app) || (only != null && !only.Split(',').Contains(ms.ToString()))) continue;
            var (visible, total) = Render.Compare(bg, level.Layers, level.Cards, app, Path.Combine(dir, $"unity-{ms}.png"), Path.Combine(dir, $"diff-{ms}.png"));
            Console.WriteLine($"{level.Phase,-7} r{level.Run.Idx + 1,-2} {ms,6} ms {e.GetProperty("name").GetString(),-22}: {visible,6} of {total} px differ visibly ({100.0 * visible / total:0.00} %)");
        }
        return 0;
    }
}
