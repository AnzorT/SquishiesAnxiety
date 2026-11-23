// Replays ref.mjs's scenario on the C# SquishToy (same seed, idle phase, clock, touches and random kicks) and compares
// its state with the app's, frame by frame: the press points, the springs, the group's transform and world matrix,
// and the shader's uniforms as uploaded.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SquishSquad.Backend;
using SquishSquad.Games.Squish;

static class ToyTest
{
    public static Dictionary<string, CardData> Moves()
    {
        var data = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Program.Res("Squish/squish.json")));
        return SquishCard.ParseMoves((IDictionary<string, object>)data["moves"]);
    }

    static double D(object o) => o is double d ? d : o is bool b ? (b ? 1 : 0) : double.NaN;

    /// <summary>Builds the toy and runs the scenario, calling `frame(f, toy, refState)` after each frame's tick.</summary>
    public static void Replay(string dir, Action<int, SquishToy, IDictionary<string, object>> frame)
    {
        var r = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Path.Combine(dir, "frames.json")));
        var sc = (IDictionary<string, object>)r["scenario"];
        string id = (string)r["id"];
        int stage = (int)D(r["stage"]);
        double dt = D(r["dt"]), t0 = D(r["t0"]);
        var moves = Moves();
        var toy = SquishToy.MakeCard(moves.TryGetValue(id, out var cd) ? cd : null, stage, D(sc["seed"]), D(sc["idlePhase"]));
        var events = new Dictionary<int, List<IDictionary<string, object>>>();
        foreach (IList<object> e in (IList<object>)sc["events"])
        {
            int f = (int)D(e[0]);
            if (!events.ContainsKey(f)) events[f] = new List<IDictionary<string, object>>();
            events[f].Add((IDictionary<string, object>)e[1]);
        }
        var frames = (IList<object>)r["frames"];
        for (int f = 0; f < frames.Count; f++)
        {
            double now = t0 + dt * (f + 1);
            toy.Tick(f == 0 ? 0 : dt / 1000, now);
            frame(f, toy, (IDictionary<string, object>)frames[f]);
            if (!events.TryGetValue(f, out var evs)) continue;
            foreach (var e in evs)
            {
                switch ((string)e["t"])
                {
                    case "down": toy.PointerDown(D(e["x"]), D(e["y"])); break;
                    case "move": toy.PointerMove(D(e["x"]), D(e["y"])); break;
                    case "up":
                        var rs = new Queue<double>(((IList<object>)e["r"]).Select(D));
                        toy.Random = () => rs.Dequeue();
                        toy.PointerUp(now);
                        break;
                    case "orbit": toy.Orbit(D(e["dx"]), D(e["dy"])); break;
                    case "endOrbit": toy.EndOrbit(); break;
                    case "cancel": toy.CancelPoke(); break;
                }
            }
        }
    }

    public static int Run(string dir)
    {
        var worst = new Dictionary<string, (double err, int frame)>();
        int pressCountMismatch = 0, frames = 0;
        void Note(string k, double a, double b, int f)
        {
            double e = Math.Abs(a - b);
            if (double.IsNaN(a) != double.IsNaN(b)) e = double.PositiveInfinity;
            if (!worst.TryGetValue(k, out var w) || e > w.err) worst[k] = (e, f);
        }
        Replay(dir, (f, toy, st) =>
        {
            frames++;
            var pr = (IList<object>)st["presses"];
            if (pr.Count != toy.Presses.Count) { pressCountMismatch++; return; }
            for (int j = 0; j < pr.Count; j++)
            {
                var p = (IDictionary<string, object>)pr[j];
                var q = toy.Presses[j];
                Note("press.xyz", D(p["x"]), q.X, f); Note("press.xyz", D(p["y"]), q.Y, f); Note("press.xyz", D(p["z"]), q.Z, f);
                Note("press.amp", D(p["amp"]), q.Amp, f); Note("press.vel", D(p["vel"]), q.Vel, f);
                Note("press.target", D(p["target"]), q.Target, f); Note("press.meanF", D(p["meanF"]), q.MeanF, f);
                Note("press.driven", D(p["driven"]), q.Driven ? 1 : 0, f);
            }
            Note("lift", D(st["lift"]), toy.Lift, f);
            Note("globalSquash", D(st["globalSquash"]), toy.GlobalSquash, f);
            Note("wobble", D(st["wobbleRotX"]), toy.WobbleRotX, f); Note("wobble", D(st["wobbleRotZ"]), toy.WobbleRotZ, f);
            Note("userRot", D(st["userRotX"]), toy.UserRotX, f); Note("userRot", D(st["userRotY"]), toy.UserRotY, f);
            var mv = (IDictionary<string, object>)st["mv"];
            Note("mv", D(mv["sx"]), toy.Mv.Sx, f); Note("mv", D(mv["sy"]), toy.Mv.Sy, f); Note("mv", D(mv["rot"]), toy.Mv.Rot, f);
            Note("mv", D(mv["tx"]), toy.Mv.Tx, f); Note("mv", D(mv["ty"]), toy.Mv.Ty, f);
            var m = (IList<object>)st["matrix"];
            for (int i = 0; i < 16; i++) Note("matrixWorld", D(m[i]), toy.MatrixWorld[i], f);
            Note("mode", st["mode"] == null ? 0 : (string)st["mode"] == "poke" ? 1 : 2, (int)toy.Mode, f);
            if (st["uniforms"] is IDictionary<string, object> u && toy.Uploaded)
            {
                var pu = (IList<object>)u["press"];
                for (int i = 0; i < pu.Count; i++) Note("uniform.press", D(pu[i]), toy.PressUniform[i], f);
                Note("uniform.count", D(u["count"]), toy.UniformCount, f);
                var dr = (IList<object>)u["dir"];
                for (int i = 0; i < 3; i++) Note("uniform.dir", (float)D(dr[i]), toy.UniformDir[i], f);
                var de = (IList<object>)u["dent"];
                for (int i = 0; i < 4; i++) Note("uniform.dent", (float)D(de[i]), toy.UniformDent[i], f);
            }
        });
        Console.WriteLine($"{frames} frames; press-count mismatches: {pressCountMismatch}");
        foreach (var kv in worst.OrderBy(k => k.Key)) Console.WriteLine($"  {kv.Key,-16} max |diff| {kv.Value.err:G3} (frame {kv.Value.frame})");
        double max = worst.Values.Max(v => v.err);
        bool ok = pressCountMismatch == 0 && max < 1e-9;
        Console.WriteLine(ok ? "OK: the port's squish state matches the app's" : "MISMATCH");
        return ok ? 0 : 1;
    }
}
