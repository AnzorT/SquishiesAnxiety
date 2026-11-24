// Squish Hop's BLITZ MODE run (HopLevel with `blitz`, Games/Hop/HopBlitz.cs) played through from the Unity code, its
// moments checked against develop's src/hop/Game.js: the countdown and GO, a board's clock starting 760 ms after it drops
// in, a cleared board (CLEARED 300 ms later, the next board at 1100 with BOARD n), a hop that leaves no full clear (the
// save card 1000 ms later; SAVE IT takes the hop back, the clock running on), the clock running out (TIME'S UP 900 ms
// later; SAVE FOR gems starts the board's clock again), pause hiding the board, END RUN (GAME OVER, the run paid and its
// record kept), PLAY AGAIN (a new run with its own seed), back once it's over (leaves).
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Games.Hop;

static class HopBlitzFlow
{
    static int _fails;
    static void Check(bool ok, string what) { Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {what}"); if (!ok) _fails++; }

    public static int Run(List<HopSquishy> cast)
    {
        var tk = new Ticker(0);
        var profile = Program.Player();
        int seeds = 0;
        var g = new HopLevel(832, 384, 1, cast, profile, tk, true, run => 12345 + run * 7 + seeds++ * 0) { Save = true };
        bool exited = false;
        g.OnExit = () => exited = true;
        void Run(double ms) { double to = tk.Now + ms; while (tk.Now < to) { tk.Tick(Math.Min(tk.Now + 16, to)); g.Update(); } }
        var shots = Environment.GetEnvironmentVariable("HOP_SHOTS");
        void Shot(string name) { if (shots == null) return; g.Update(); System.IO.Directory.CreateDirectory(shots); Program.Render(Program.Screen(g), System.IO.Path.Combine(shots, $"hop-blitz-{name}.png")); }
        bool Hidden() => !g.Layers.Any(l => l.Name.StartsWith("cushion"));

        Console.WriteLine("Squish Hop BLITZ MODE");
        Check(g.IsBlitz && g.Phase == "intro" && !g.ClockRunning, "the run opens in its countdown, no clock yet");
        Run(250); Check(Hidden(), "3: the board hidden under the countdown");
        Shot("count3");
        Run(2100); Check(!Hidden() && g.Phase == "intro", "GO! (2300 ms): the first board drops in");
        Run(800); Check(g.Phase == "play" && g.ClockRunning && Math.Abs(g.ClockLeft - g.Spec.Ms) < 200, "its clock starts 760 ms after GO");
        Shot("play");
        // board 1: the full clear
        foreach (var d in g.Spec.Sol) { g.HopDir(d); Run(420); }
        Check(g.Phase == "won" && !g.ClockRunning, "the full clear onto the ★: the clock stops");
        Run(320); Check(g.Cleared == 1, "CLEARED 1 (300 ms after)");
        Run(900); Check(g.Idx == 1 && g.Phase == "intro" && !Hidden(), "the next board at 1100 ms, straight in (no countdown)");
        Run(300); Shot("board2");
        Run(800); Check(g.Phase == "play" && g.ClockRunning, "and its clock starts 760 ms later");
        // a hop that leaves no full clear: the run stops
        int bad = -1;
        foreach (var m in Engine.Moves(g.Spec.Board, g.State))
        {
            var r = Engine.Search(g.Spec.Board, m.St, new SearchOptions { Limit = 60000 });
            if (r.Path == null && !r.Aborted && !m.St.Done) { bad = m.D; break; }
        }
        Check(bad >= 0, "board 2 has a first hop that leaves no full clear");
        double left = g.ClockLeft;
        g.HopDir(bad); Run(400);
        Check(g.Phase == "held" && !g.ClockRunning && g.BlitzCard == null, "after it lands: held, the clock stopped");
        Run(1000); Check(g.BlitzCard == "save", "the save card 1000 ms later (OOPS!)");
        Run(500); Shot("save");
        Check(g.PressCard("SAVE IT"), "SAVE IT (FREE, Remove Ads / no ads in this build)");
        Run(400);
        Check(g.Phase == "play" && g.AdUsed && g.MovesMade == 0 && g.ClockRunning && Math.Abs(g.ClockLeft - left) < 600, "saved: the hop taken back, the clock running on");
        // the clock running out
        Run(g.ClockLeft + 200);
        Check(g.Phase == "held" && !g.ClockRunning, "the clock runs out: held");
        Run(950); Check(g.BlitzCard == "save", "the save card (TIME'S UP!) 900 ms later");
        Check(g.PressCard("SAVE FOR"), "SAVE FOR 10 gems");
        Run(50);
        Check(g.Phase == "play" && g.GemSaves == 1 && (double)profile["gems"] == 590 && g.ClockLeft > g.Spec.Ms - 300, "saved after the clock: 600 → 590 gems, the board's clock starts again");
        // pause
        g.Back(); Run(50);
        Check(Hidden() && !g.ClockRunning && g.Cards.Any(c => c.Visible), "back: paused, the board hidden, the clock stopped");
        g.Back(); Run(50);
        Check(!Hidden() && g.Phase == "play" && g.ClockRunning, "back again: RESUME");
        // another mistake, END RUN
        g.HopDir(bad); Run(1500);
        Check(g.BlitzCard == "save", "another mistake: the save card again");
        Check(g.PressCard("END RUN"), "END RUN");
        Run(100);
        var rec = Levels.Record(profile);
        Run(2000); Shot("over");
        Check(g.BlitzCard == "over" && Js.ToNumber(rec.BlitzTop) == 1 && Js.ToNumber(rec.BlitzRuns) == 1, "GAME OVER: the run paid out and its record kept (best 1, one run)");
        Run(500);
        Check(g.PressCard("PLAY AGAIN"), "PLAY AGAIN");
        Run(50);
        Check(g.Idx == 0 && g.Cleared == 0 && g.Phase == "intro" && g.BlitzCard == null, "a new run from board 1, with its countdown");
        Run(250); Check(Hidden(), "3 again");
        Run(2900);
        g.HopDir(bad >= 0 ? bad : 0); Run(100);
        g.Back(); Run(50);
        Check(g.Cards.Any(c => c.Visible), "back while playing: paused");
        Check(g.PressCard("QUIT"), "QUIT");
        Check(exited && Js.ToNumber(Levels.Record(profile).BlitzRuns) == 2, "leaves, the run paid out first (two runs)");
        Console.WriteLine(_fails == 0 ? "blitzflow: all ok" : $"blitzflow: {_fails} FAILED");
        return _fails == 0 ? 0 : 1;
    }
}
