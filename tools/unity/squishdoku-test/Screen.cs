// Squishdoku's screen (screen.mjs's run) from the Unity code: SdScreen with Preview.js's made-up player, the hub up for
// as long as the page's was before its clock was replaced, then the same taps at the same moments on a Ticker stepped
// 16 ms a frame, each moment the app's screen was shot drawn and compared with it. The buddy (the app's live rig, in the
// level and the run) is left out.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Vector;

static class ScreenTest
{
    public static string HeadOf(SdCreature c) => c != null && File.Exists(Program.Res("Squishdoku/heads/" + c.Key + ".png")) ? "Squishdoku/heads/" + c.Key : null;

    public static SdScreen Make(Ticker tk, out SdCreature mittens)
    {
        mittens = null;
        foreach (var c in PlayTest.Art()) if (c.Key == "mittens") mittens = c;
        SdLevel.Profile = BlitzTest.PreviewPlayer();
        SdScreen.Today = () => new DateTime(2026, 11, 23);
        return new SdScreen(832, 384, new[] { mittens }, mittens, n => File.ReadAllText(Program.Res("Squishdoku/" + n + ".xml")), HeadOf, tk) { AdsFree = true, Save = false };
    }

    static bool PressLabel(SdScreen s, string label)
    {
        s.Layers();
        IEnumerable<SquishSquad.Ui.Cards.CardButton> buttons = new SquishSquad.Ui.Cards.CardButton[0];
        var all = new List<SquishSquad.Ui.Cards.CardButton>();
        if (s.Level != null) foreach (var c in s.Level.Cards) all.AddRange(c.Buttons);
        if (s.Blitz != null) foreach (var c in s.Blitz.Cards) all.AddRange(c.Buttons);
        foreach (var b in s.RulesButtons()) all.Add(b);
        foreach (var b in all)
            if (b.Look.Label.StartsWith(label))
            {
                var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                s.Tap((float)p.X, (float)p.Y);
                return true;
            }
        return false;
    }

    public static int Run(string dir)
    {
        var sc = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "screen.json"))).RootElement;
        var tk = new Ticker(0);
        var s = Make(tk, out _);
        void RunTo(double ms) { while (tk.Now < ms - 1e-9) tk.Tick(Math.Min(tk.Now + 16, ms)); }
        RunTo(7000);
        var skip = new List<(float, float, float, float)>();
        double worst = 0, sum = 0; int shots = 0;
        void Shot(string name)
        {
            var app = Path.Combine(dir, $"screen-{name}.png");
            if (!File.Exists(app)) return;
            if (Environment.GetEnvironmentVariable("SD_ONLY") is string only && Array.IndexOf(only.Split(','), name) < 0) return;
            var svg = Program.Screen(s.Layers());
            File.WriteAllText(Path.Combine(dir, $"screen-{name}-unity.svg"), svg);
            // the buddy: a level's and a run's (the app's live rig)
            var buddy = s.View == "play" ? PlayTest.Buddy : s.View == "blitz" ? BlitzTest.Buddy : (0f, 0f, 0f, 0f);
            double pct = Program.Compare(svg, app, Path.Combine(dir, $"screen-{name}-unity.png"), Path.Combine(dir, $"screen-{name}-diff.png"), out int v, out int total, buddy);
            Console.WriteLine($"screen {name,6} ({s.View,-5}{(s.Ready ? "" : " bones")}): {v,6} of {total} px differ visibly ({pct:0.00} %)");
            worst = Math.Max(worst, pct); sum += pct; shots++;
        }
        Shot("hub");
        double T0 = tk.Now;
        foreach (var st in sc.GetProperty("steps").EnumerateArray())
        {
            double ms = st.GetProperty("at").GetDouble();
            RunTo(T0 + ms);
            if (st.TryGetProperty("tap", out var tap)) s.Tap((float)tap[0].GetDouble(), (float)tap[1].GetDouble());
            else if (st.TryGetProperty("press", out var label)) { if (!PressLabel(s, label.GetString())) Console.WriteLine($"  no {label.GetString()} to press"); }
            else Shot(ms.ToString());
        }
        Console.WriteLine($"mean {sum / Math.Max(1, shots):0.00} %, worst {worst:0.00} %");
        return 0;
    }
}
