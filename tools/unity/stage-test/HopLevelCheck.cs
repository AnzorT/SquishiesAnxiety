// A real Squish Hop level (Games/Hop/HopLevel) with its rig calls going to the compiled hop page (Creatures/RigStage),
// both clocks stepped together 16 ms at a time as HopGame does in Unity: the board's cast goes out as it comes in, the
// page draws it, the rigs come on (the cut-outs step aside), and a few swipes hop the hopper about. Prints where the
// page stands each character (its feet, the page's own numbers) against the cell the level has it on.
//   dotnet run -c Release --project tools/unity/stage-test -- hoplevel [level]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Games.Hop;
using SquishSquad.Ui;

static class HopLevelCheck
{
    public static int Run(int lv)
    {
        UiFont.ReadJson = n => File.ReadAllText(Program.Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
        HopLevel.LoadXml = n => File.ReadAllText(Program.Res("Hop/" + n + ".xml"));
        SquishSquad.Ui.Cards.Card.LoadXml = n => File.ReadAllText(Program.Res("Cards/" + n + ".xml"));
        var stage = new RigStage("hop");
        for (int i = 0; i < 600 && !stage.Ready; i++) RigHost.Frame(16);
        if (!stage.Ready) { Console.WriteLine("the hop page never came up"); return 2; }
        stage.Messages();
        stage.Size(832, 384);
        var tk = new Ticker(0);
        Ticker.Default = tk;
        int calls = 0;
        var profile = new Dictionary<string, object> { ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" }, ["hop"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = (double)lv } };
        var level = new HopLevel(832, 384, lv, LoadCast(), profile, tk, false, null, (fn, args) => { calls++; if (!stage.Call(fn, args)) Console.WriteLine($"  (no call {fn})"); });
        level.Update();
        bool lastOn = false;
        void Step(double ms)
        {
            double until = tk.Now + ms;
            while (tk.Now < until)
            {
                tk.Tick(Math.Min(tk.Now + 16, until));
                RigHost.Frame(16);
                foreach (var m in stage.Messages())
                {
                    var type = m["type"] as string;
                    if (type == "ready") level.RigReady();
                    else if (type == "cast") level.RigCast(m.TryGetValue("tag", out var t) ? t as string : null, m.TryGetValue("ok", out var o) && o is bool b && b);
                }
                level.Update();
                if (level.RigsOn != lastOn) { lastOn = level.RigsOn; Console.WriteLine($"  {tk.Now,6:0} ms: rigs {(lastOn ? "on" : "off")} ({calls} calls)"); }
            }
        }
        Step(2500);
        Check(level, stage, "in");
        // a swipe each way (a hop where it can, a bump where it can't), each played out
        var B = level.Board;
        foreach (var (dx, dy) in new[] { (70, 0), (0, 70), (-70, 0), (0, -70) })
        {
            var q = SquishSquad.Games.Hop.BoardGeometry.StandOn(B, level.HopperCell);
            float x = (float)(q.X + level.LeftW), y = (float)q.Y - 20;
            level.Down(x, y); for (int i = 1; i <= 4; i++) { level.Move(x + dx * i / 4f, y + dy * i / 4f); Step(16); } level.Up(x + dx, y + dy);
            Step(1200);
            Check(level, stage, $"after a swipe ({dx}, {dy}), on cell {level.HopperCell}");
        }
        var cut = level.Layers.Where(l => l.Name.Contains("pic") || l.Name.Contains("shadow")).Select(l => l.Name + (l.Visible ? " shown" : " hidden"));
        Console.WriteLine("  the cut-outs: " + string.Join(", ", cut));
        return 0;
    }

    // each character's feet on the page (its c.x, c.y: the board area's plus the origin) against its cell's
    static void Check(HopLevel level, RigStage stage, string when)
    {
        var api = Rt.Get(Rt.Get(Rt.Get(Rt.G("__stages"), "hop"), "win"), "hopStage");
        var C = Rt.Get(api, "_C");
        var B = level.Board;
        var want = new List<(string id, int cell)> { ("p", level.HopperCell) };
        for (int k = 0; k < level.FriendCells.Length; k++) want.Add(("f" + k, level.FriendCells[k]));
        foreach (var (id, cell) in want)
        {
            var c = Rt.Invoke(C, "get", id); if (c.IsNullish) { Console.WriteLine($"  {when}: no {id} on the page"); continue; }
            var q = SquishSquad.Games.Hop.BoardGeometry.StandOn(B, cell, level.LifeAt(cell) == 2 ? HopArt.PILE_TOP : 0);
            double x = Rt.ToNum(Rt.Get(c, "x")), y = Rt.ToNum(Rt.Get(c, "y")), s = Rt.ToNum(Rt.Get(c, "s")), o = Rt.ToNum(Rt.Get(c, "o"));
            Console.WriteLine($"  {when}: {id} feet ({x:0.##}, {y:0.##}) s {s:0.###} o {o} | its cell's ({q.X + level.LeftW:0.##}, {q.Y:0.##}) s {q.S / B.T:0.###}");
        }
    }

    static List<HopSquishy> LoadCast()
    {
        var j = JsonDocument.Parse(File.ReadAllText(Program.Res("Hop/hop.json"))).RootElement;
        var heads = j.GetProperty("heads").EnumerateArray().Select(h => h.GetString()).ToHashSet();
        return j.GetProperty("cast").EnumerateArray().Select(c =>
        {
            var key = c.GetProperty("key").GetString(); var file = c.GetProperty("file").GetString();
            return new HopSquishy
            {
                Id = c.GetProperty("id").GetString(), Key = key, Ar = (float)c.GetProperty("ar").GetDouble(),
                Box = c.GetProperty("box").EnumerateArray().Select(v => (float)v.GetDouble()).ToArray(),
                Picture = string.IsNullOrEmpty(file) ? null : "Stack/art/" + file,
                Happy = heads.Contains(key) ? "Hop/heads/" + key + "-happy" : null, Sad = heads.Contains(key) ? "Hop/heads/" + key + "-sad" : null,
            };
        }).ToList();
    }
}
