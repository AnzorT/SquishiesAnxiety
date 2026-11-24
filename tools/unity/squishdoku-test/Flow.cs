// dotnet run -c Release --project tools/unity/squishdoku-test -- flow
// The level's rules of touch and its flow, played through SdLevel as a player would (no pictures): long-press and
// drag to mark ✕, the ✕ tool, a tap on a placed creature, a mistake's ✕ 950 ms later, pause and back, the solve and NEXT,
// hearts running out and RETRY, the clock running out, HEAD START.
using System;
using System.Collections.Generic;
using System.IO;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class FlowTest
{
    static bool _ok = true;
    static void Check(bool c, string what) { Console.WriteLine($"  {(c ? "ok  " : "FAIL")} {what}"); _ok &= c; }

    sealed class Game
    {
        public Ticker Tk = new Ticker(0);
        public SdLevel L;
        public int? Exited; public bool Left;
        public Game(int lv, bool head = false)
        {
            SdLevel.Profile = new Dictionary<string, object>();
            SdCreature m = null;
            foreach (var c in PlayTest.Art()) if (c.Key == "mittens") m = c;
            L = new SdLevel(832, 384, lv, head, new[] { m }, m, n => File.ReadAllText(Program.Res("Squishdoku/" + n + ".xml")), Tk);
            L.OnExit = u => { Left = true; Exited = u; };
        }
        public void Run(double ms) { double end = Tk.Now + ms; while (Tk.Now < end) Tk.Tick(Math.Min(Tk.Now + 16, end)); L.Layers(); }
        public (float x, float y) Cell(int r, int c) { var q = L.BoardGeo.Project(c + 0.5, r + 0.5); return ((float)(L.AreaX + q.X), (float)q.Y); }
        public int Sol(int r) => L.Spec.Puzzle.Solution[r];
        public int Wrong(int r) => (Sol(r) + 1) % L.Spec.N;
        public void Tap(int r, int c) { var (x, y) = Cell(r, c); L.Down(x, y); L.Up(x, y); }
        public bool Press(string label)
        {
            L.Layers();
            foreach (var card in L.Cards)
                foreach (var b in card.Buttons)
                    if (b.Look.Label.StartsWith(label))
                    {
                        var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                        L.Down((float)p.X, (float)p.Y); L.Up((float)p.X, (float)p.Y);
                        return true;
                    }
            return false;
        }
        public int CardCount() { int n = 0; foreach (var c in L.Cards) if (c.Visible) n++; return n; }
    }

    public static int Run()
    {
        var g = new Game(12);
        int n = g.L.Spec.N;
        Check(g.L.Phase == "intro", "a level starts with its intro");
        g.Run(900);
        Check(g.L.Phase == "play", "and is played from 816 ms (60 + (2n-1)·34 + 450)");
        // long press: a ✕
        var (x, y) = g.Cell(2, g.Wrong(2));
        g.L.Down(x, y); g.Run(400); g.L.Up(x, y);
        Check(g.L.IsMarked(2 * n + g.Wrong(2)) && !g.L.Perfect, "a long press marks ✕, and ends the PERFECT run");
        // a short tap on it: a mistake? no: it's wrong, the creature poofs, the ✕ comes back 950 ms later
        // drag with the ✕ tool: paints across
        g.L.SetXTool(true);
        var (ax, ay) = g.Cell(3, 0); var (bx, by) = g.Cell(3, 1);
        g.L.Down(ax, ay); g.L.Move(ax + 5, ay); g.L.Move(bx, by); g.L.Up(bx, by);
        Check(g.L.IsMarked(3 * n) && g.L.IsMarked(3 * n + 1), "with the ✕ tool, a drag paints ✕ on every cell it crosses");
        g.Tap(3, 0);
        Check(!g.L.IsMarked(3 * n), "with the ✕ tool, a tap takes a ✕ off");
        g.L.SetXTool(false);
        g.Tap(0, g.Sol(0));
        Check(g.L.IsPlaced(g.Sol(0)), "a tap on the right cell places its creature");
        g.Run(800);
        g.Tap(0, g.Sol(0));
        Check(g.L.IsPlaced(g.Sol(0)) && g.L.Phase == "play", "a tap on a placed creature wiggles it (nothing else)");
        g.Tap(1, g.Wrong(1));
        g.Run(500);
        Check(!g.L.IsMarked(n + g.Wrong(1)), "a wrong creature: no ✕ yet...");
        g.Run(500);
        Check(g.L.IsMarked(n + g.Wrong(1)) && !g.L.IsPlaced(n + g.Wrong(1)), "... the cell gets its ✕ 950 ms later, and stays empty");
        g.Run(300);
        Check(g.L.ScoreLeft == 1, "a mistake leaves one score creature");
        // pause: the board hidden, the clock frozen
        g.L.Pause();
        g.Run(400);
        bool cushions = false; foreach (var l in g.L.Layers()) if (l.Name.StartsWith("cushion")) cushions = true;
        Check(g.L.Phase == "paused" && !cushions && g.CardCount() == 1, "pause hides the board and opens the pause card");
        g.Press("RESUME"); g.Run(300);
        Check(g.L.Phase == "play" && g.CardCount() == 0, "RESUME");
        // solve the rest
        for (int r = 1; r < n; r++) { g.Tap(r, g.Sol(r)); g.Run(100); }
        Check(g.L.Phase == "solved", "the last creature solves it");
        g.Run(1800);
        Check(g.L.Phase == "result" && g.CardCount() == 1, "the result card 1700 ms later");
        g.Run(4000);
        g.Press("NEXT");
        Check(g.L.Lv == 13 && g.L.Phase == "intro", "NEXT: the next level");
        g.Run(1000);
        g.L.Back();
        Check(g.L.Phase == "paused", "back while playing pauses");
        g.L.Back();
        Check(g.Left, "back while paused leaves");

        // hearts from level 46
        var h = new Game(46);
        h.Run(1600);
        int hn = h.L.Spec.N;
        Check(h.L.Spec.Hearts == 3, "level 46 has three hearts");
        h.Tap(0, h.Wrong(0)); h.Run(300); h.Tap(1, h.Wrong(1)); h.Run(300);
        Check(h.L.HeartsLost == 2 && h.L.Phase == "play", "two mistakes, two hearts gone");
        h.Tap(2, h.Wrong(2));
        Check(h.L.Phase == "out", "the third: the board locks");
        h.Run(1100);
        Check(h.L.Phase == "nohearts" && h.CardCount() == 1, "OUT OF HEARTS 1000 ms later");
        h.Run(2000);
        h.Press("RETRY");
        Check(h.L.Lv == 46 && h.L.Phase == "intro" && h.L.HeartsLost == 0, "RETRY: the same level again, hearts back");

        // the clock
        var t = new Game(12);
        t.Run(900 + t.L.Spec.LimitMs + 300);
        Check(t.L.Phase == "out" && t.CardCount() == 0, "the clock runs out: the board locks, everyone droops");
        t.Run(500);
        Check(t.L.Phase == "timeup" && t.CardCount() == 1, "TIME'S UP once they have (500 ms on an empty board)");
        t.Press("MAP");
        Check(t.Left, "MAP leaves");

        // HEAD START: row 0's creature dropped in for you, the clock 450 ms later
        var s = new Game(12, true);
        s.Run(820);
        Check(s.L.IsPlaced(s.Sol(0)) && s.L.Phase == "intro", "HEAD START places row 0's creature");
        s.Run(500);
        Check(s.L.Phase == "play" && s.L.Spec.LimitMs < Levels.SpecOf(12).LimitMs, $"then the clock starts ({s.L.Spec.LimitMs / 1000} s, not {Levels.SpecOf(12).LimitMs / 1000})");
        Console.WriteLine(_ok ? "flow: all ok" : "flow: FAILED");
        return _ok ? 0 : 1;
    }
}
