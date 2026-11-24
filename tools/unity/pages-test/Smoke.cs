// -- smoke: the pages' interactions run once (claims, the flying coins, a note, the arrows, a drag and its glide,
// CHOOSE, "Find it in chests"), a few frames written as pictures to look at (no comparison).
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SquishSquad.Menu;

static partial class Program
{
    static IEnumerable<object> Smoke()
    {
        var L = JsonSerializer.Deserialize<LevelPassLayout>(File.ReadAllText(Res("LevelPass/levelpass.json")), Opts);
        double W = 2340, H = 1080;
        var prof = new Dictionary<string, object> { ["pxp"] = 2930.0, ["coins"] = 12345.0, ["levelGot"] = new Dictionary<string, object> { ["1"] = true } };
        var m = new LevelPassModel(L, W, H, LevelPassData.FromProfile(prof, "2026-11-13", "mittens"), 0);
        m.TapLevel(2, 100); m.TapLevel(2, 200);                     // a second tap claims (offline: done at once, coins fly)
        yield return Scene("smoke-lp-burst", null, null, "LevelPass", m.Draw(600), new[] { W, H });
        var sent = new List<string>();
        m.OnClaim = (ls, all) => sent.Add(string.Join(",", ls) + (all ? " all" : ""));
        m.ClaimAll(1000);
        m.Answer(false, "need_level", 1200);
        yield return Scene("smoke-lp-toast", null, null, "LevelPass", m.Draw(1500), new[] { W, H });
        Console.WriteLine("claims sent: " + string.Join(" | ", sent));
        m.Track.Down(600, 2000); m.Track.Move(500, 2016); m.Track.Move(300, 2032); bool drag = m.Track.Up(2033);
        yield return Scene("smoke-lp-glide", null, null, "LevelPass", m.Draw(2600), new[] { W, H });
        Console.WriteLine($"drag {drag}, row at {m.Track.Value:0.#} of {m.Track.Max}");

        var C = JsonSerializer.Deserialize<CharactersLayout>(File.ReadAllText(Res("Characters/characters.json")), Opts);
        var c = new CharactersModel(C, W, H, C.demo.owned, C.demo.sel, 0);
        string chose = null; bool shop = false;
        c.OnChoose = k => chose = k; c.OnShop = () => shop = true;
        c.Draw(3000);
        c.Jump(1, 3000);
        c.Draw(3500);
        Console.WriteLine($"next group: row at {c.Row.Value} (prev off {c.PrevOff}, next off {c.NextOff})");
        c.Choose("hoot", 4000); c.Act(4000);
        c.Choose("octo", 4100); c.Act(4100);
        yield return Scene("smoke-ch-chosen", null, null, "Characters", c.Draw(4300), new[] { W, H });
        Console.WriteLine($"chose {chose}, in use {c.InUse}, shop {shop}");
    }
}
