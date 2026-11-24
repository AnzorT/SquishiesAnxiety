// dotnet run -c Release --project tools/unity/squishdoku-test -- blitzflow
// The flows, played as a player would (no pictures):
//   Squishdoku's Blitz (SdBlitz): the countdown, boards cleared, a mistake → the save card → saved by the ad, by gems
//     (the price doubling), END RUN → GAME OVER (paid out, the record saved) → PLAY AGAIN; the clock running out and
//     being saved (a fresh clock); pause and back; not enough gems
//   the shared run (Ui/Blitz BlitzRun, as Squish Stack and Squish Sort play it): a mistake → the revive → another
//     mistake → BACK TO PUZZLE 1 (the pips drain) → GO AGAIN; ten rounds → BLITZ CHAMPION!
//   the screen (SdScreen): hub → map → a level → map (kept) → hub → Blitz → hub → out; HEAD START; the rules on a
//     first visit
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class BlitzFlowTest
{
    static bool _ok = true;
    static void Check(bool c, string what) { Console.WriteLine($"  {(c ? "ok  " : "FAIL")} {what}"); _ok &= c; }

    public static int Run()
    {
        Console.WriteLine("Squishdoku's Blitz");
        SdLevel.Profile = BlitzTest.PreviewPlayer();
        var tk = new Ticker(0);
        var g = BlitzTest.Make(tk, null);
        g.Save = true;
        bool exited = false;
        g.OnExit = () => exited = true;
        void Run(double ms) { double end = tk.Now + ms; while (tk.Now < end) tk.Tick(Math.Min(tk.Now + 16, end)); g.Layers(); }
        int Sol(int r) => g.Puzzle.Solution[r];
        void Right(int r) => g.TapCell(r * g.Puzzle.N + Sol(r));
        void Wrong(int r) => g.TapCell(r * g.Puzzle.N + (Sol(r) + 1) % g.Puzzle.N);
        int open() { int n = 0; foreach (var c in g.Cards) if (c.Visible) n++; return n; }
        Check(g.Phase == "countdown", "a run opens with the countdown");
        Run(250); Check(g.Count == "3", "3 at 200 ms");
        Run(2100); Check(g.Count == "GO!", "GO! at 2300 ms");
        Run(500); Check(g.Phase == "countdown" && g.Board.IsPlaced(Sol(0)), "the first row's creature is given once the board has landed (2788 ms)");
        Run(300); Check(g.Phase == "play" && g.ClockRunning && g.Count == null, "then the board's clock starts (3138 ms)");
        for (int r = 1; r < g.Puzzle.N; r++) Right(r);
        Check(g.Phase == "between" && g.Cleared == 1, "the last right creature clears the board");
        Run(320); Check(g.ClearedShown == 1, "CLEARED goes up 300 ms later");
        Run(1100); Check(g.Idx == 1 && g.Phase == "intro", "the next board is up 350 ms after the win's last jump (~1360 ms), cascading in (no countdown)");
        Run(900); Check(g.Phase == "play", "and its clock starts once its given creature has dropped in");
        double left = g.ClockLeft;
        Wrong(1);
        Check(g.Phase == "between" && !g.ClockRunning, "a wrong creature stops the clock");
        Run(1300); Check(g.Phase == "save" && open() == 1, "the save card once everyone has drooped (~1270 ms)");
        g.Press("SAVE IT");
        Run(50);
        Check(g.Phase == "play" && g.AdUsed && Math.Abs(g.ClockLeft - left) < 200, "SAVE IT (FREE, Remove Ads): the run goes on, the board's clock running on");
        Wrong(2); Run(1300);
        bool adButton = false; foreach (var c in g.Cards) if (c.Visible) foreach (var b in c.Buttons) if (b.Look.Label.Contains("SAVE IT")) adButton = true;
        Check(g.Phase == "save" && !adButton, "another mistake: the save card again, without the ad (once a run)");
        g.Press("SAVE FOR");
        Run(50);
        Check(g.Phase == "play" && g.GemSaves == 1 && Levels.BlitzSaveGems(1) == 20 && (double)SdLevel.Profile["gems"] == 590, "SAVE FOR 10 gems: saved, 600 → 590 gems, the next save 20");
        Wrong(3); Run(1300);
        g.Press("END RUN");
        Run(50);
        var rec = Levels.Record(SdLevel.Profile);
        Check(g.Phase == "over" && Js.ToNumber(rec.Blitz["top"]) == 1 && Js.ToNumber(rec.Blitz["runs"]) == 1, "END RUN: GAME OVER, the run paid out and its record saved (best 1)");
        Run(3000);
        g.Press("PLAY AGAIN");
        Run(50);
        Check(g.Phase == "countdown" && g.Idx == 0 && g.ClearedShown == 0, "PLAY AGAIN: a new run from board 1, with its countdown");
        Run(3200);
        Check(g.Phase == "play", "playing");
        Run(Levels.BlitzSpecOf(0).Ms + 200);
        Check(g.Phase == "between", "the clock runs out: the board shakes");
        Run(950); Check(g.Phase == "save", "the save card (TIME'S UP!) 900 ms later");
        g.Press("SAVE IT"); Run(50);
        Check(g.Phase == "play" && g.ClockLeft > Levels.BlitzSpecOf(0).Ms - 200, "saved after the clock ran out: the board's clock starts again");
        g.Pause(); Run(50);
        bool cushion = false; foreach (var l in g.Layers()) if (l.Name.StartsWith("cushion") && l.Opacity > 0) cushion = true;
        Check(g.Phase == "paused" && !cushion && open() == 1, "pause: the board hidden, the pause card");
        g.Press("RESUME"); Run(50);
        Check(g.Phase == "play", "RESUME");
        SdLevel.Profile["gems"] = 5.0;
        Wrong(1); Run(1300);
        bool note = false, gemsOff = false;
        foreach (var c in g.Cards) if (c.Visible) foreach (var b in c.Buttons) if (b.Look.Label == "SAVE FOR") { gemsOff = !b.Enabled; }
        foreach (var c in g.Cards) if (c.Visible) foreach (var l in c.Layers()) if (l.Name == "note") note = true;
        Check(g.Phase == "save" && gemsOff && note, "5 gems: SAVE FOR is off, \"You have 5 gems\" under it");
        g.Back(); Run(50);
        Check(g.Phase == "over", "back on the save card: GAME OVER");
        g.Back();
        Check(exited, "back once it's over leaves");

        Console.WriteLine("the shared Blitz run (Squish Stack's rules)");
        var tk2 = new Ticker(0);
        Ticker.Default = tk2;
        var run = new BlitzRun(832, 384, "puzzle", new BlitzRun.Timings { MistakeMs = 1000, NextMs = 1300, WinMs = 1000 }) { AdsFree = true };
        var pips = new Pips(10, true);
        int next = 0; string lost = null; bool won = false, revived = false, again = false;
        run.OnNext = i => next = i; run.OnLost = (r, reached) => lost = r + reached; run.OnRevived = () => revived = true; run.OnAgain = () => again = true;
        run.OnWon = () => { won = true; return new BlitzCards.WinResult { Ms = 300000, Coins = 300, Xp = 50, Before = new XpLevel(3, 10, 400), After = new XpLevel(3, 60, 400) }; };
        run.OnDone = d => pips.SetDone(d);
        void R(double ms) { double end = tk2.Now + ms; while (tk2.Now < end) tk2.Tick(Math.Min(tk2.Now + 16, end)); foreach (var _ in run.Layers()) { } }
        bool PressRun(string label)
        {
            foreach (var c in run.Cards()) if (c.Visible) foreach (var b in c.Buttons) if (b.Look.Label.StartsWith(label)) { var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2)); run.Down((float)p.X, (float)p.Y); run.Up((float)p.X, (float)p.Y); return true; }
            return false;
        }
        run.Cleared(); R(310);
        Check(run.Done == 1 && pips.Done == 1, "a puzzle cleared: its pip fills 300 ms later");
        R(1000); Check(next == 1 && run.Idx == 1, "the next puzzle 1300 ms after");
        run.Mistake(); R(1010);
        Check(run.CardName == "revive", "a mistake: OOPS! (the revive) 1000 ms later");
        R(400); PressRun("REVIVE"); R(50);
        Check(revived && run.Revived && run.CardName == null, "REVIVE (FREE): back to the puzzle");
        run.Mistake(); R(1010);
        Check(run.CardName == "fail" && lost == "mistake2", "another mistake: BACK TO PUZZLE 1! (the revive used)");
        R(620); Check(run.Done == 0 && pips.Done == 0, "the pips drain 600 ms later");
        R(400); PressRun("GO AGAIN"); R(50);
        Check(again && run.Idx == 0 && !run.Revived && run.CardName == null, "GO AGAIN: a new run from puzzle 1");
        for (int i = 0; i < 10; i++) { run.Cleared(); R(i < 9 ? 1310 : 1010); }
        Check(won && run.CardName == "win" && pips.Done == 10, "ten puzzles: BLITZ CHAMPION!");
        run.TimeUp();
        Check(run.CardName == "fail" && run.FailReason == "time", "the clock running out ends a run (fail, \"time\")");

        Console.WriteLine("the screen");
        var tk3 = new Ticker(0);
        var s = ScreenTest.Make(tk3, out _);
        bool left3 = false;
        s.OnExit = () => left3 = true;
        void S(double ms) { double end = tk3.Now + ms; while (tk3.Now < end) tk3.Tick(Math.Min(tk3.Now + 16, end)); s.Layers(); }
        S(1000);
        Check(s.View == "hub" && !s.RulesOpen, "the hub (no rules: the player has played)");
        var r0 = s.Hub.Regular;
        s.Tap(r0.x + 100, r0.y + 100); s.Layers();
        Check(s.View == "map" && !s.Ready, "REGULAR MODE: the map slides in, its placeholders first");
        S(60); Check(s.Ready, "built two frames later");
        S(1000);
        var p12 = s.Map.NodeAt(12).Value;
        s.Tap(p12.x, p12.y); S(100);
        Check(s.View == "play" && s.Level != null && s.Level.Lv == 12, "a tap on level 12 opens it");
        S(1500);
        s.Back(); S(50); s.Back(); S(50);
        Check(s.View == "map" && s.Ready, "pause, back: the level leaves, and the map (kept under it) is up at once");
        s.Back(); S(100);
        Check(s.View == "hub", "back on the map: the hub");
        S(1000);
        var t0 = s.Hub.Toggle;
        s.Tap(t0.x + 20, t0.y + 10);
        Check(s.HeadStart, "a tap on HEAD START's switch turns it on");
        var b0 = s.Hub.Blitz;
        s.Tap(b0.x + 100, b0.y + 100); S(100);
        Check(s.View == "blitz" && s.Blitz != null, "BLITZ MODE: a run");
        S(4000);
        s.Back(); S(50); s.Press("QUIT");
        S(100);
        Check(s.View == "hub", "pause, QUIT: back to the hub");
        S(500);
        s.Back();
        Check(left3, "back on the hub leaves Squishdoku");
        var tk4 = new Ticker(0);
        SdLevel.Profile = new Dictionary<string, object>();
        SdCreature m = null; foreach (var c in PlayTest.Art()) if (c.Key == "mittens") m = c;
        var first = new SdScreen(832, 384, new[] { m }, m, n => System.IO.File.ReadAllText(Program.Res("Squishdoku/" + n + ".xml")), ScreenTest.HeadOf, tk4);
        while (tk4.Now < 800) { tk4.Tick(tk4.Now + 16); first.Layers(); }
        Check(first.RulesOpen, "a first visit: HOW TO PLAY 700 ms in");
        Console.WriteLine(_ok ? "blitzflow: all ok" : "blitzflow: FAILED");
        return _ok ? 0 : 1;
    }
}
