// A real Squish Sort level (Games/Sort/SortLevel) with its rig calls going to the compiled sort page
// (Creatures/RigStage), the level's clock and the rig's stepped together 16 ms at a time, as SortGame does in Unity:
// the deal's cast goes out, the page draws it through the peek, the rigs take the deal at the tumble, and a tap on a
// squishy in the tray then on its home spot plays the right spot's hop. Prints what the rigs do against where the
// stills stand, and draws moments as Unity shows them (sort-test's Render for the level's layers, the rigs over them
// as Creatures/StageView draws them).
//   dotnet run -c Release --project tools/unity/stage-test -- sortlevel <out dir> [level]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Games.Sort;
using SquishSquad.Ui;
using SquishSquad.Vector;
using static SquishSquad.Games.Sort.SortGeometry;

static class SortLevelCheck
{
    const int PW = 2340, PH = 1080, SS = 2;

    public static int Run(string dir, int lv)
    {
        Directory.CreateDirectory(dir);
        UiFont.ReadJson = n => File.ReadAllText(Program.Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
        string bg = File.ReadAllText(Program.Res("Sort/bg.xml"));
        var profile = new Dictionary<string, object> { ["coins"] = 100.0, ["gems"] = 600.0, ["sort"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = (double)lv } };
        var stage = new RigStage("sort");
        for (int i = 0; i < 600 && !stage.Ready; i++) RigHost.Frame(16);
        if (!stage.Ready) { Console.WriteLine("the sort page never came up"); return 2; }
        stage.Messages();
        var tk = new Ticker(0);
        Ticker.Default = tk;
        var rnd = new Random(7);
        var level = new SortLevel("fridge", lv, 832, 384, Data(), profile) { Random = rnd.NextDouble };
        stage.Size(level.StageW, level.StageH);
        int calls = 0;
        level.Rig = (fn, args) => { calls++; if (!stage.Call(fn, args)) Console.WriteLine($"  (no call {fn})"); };
        level.Start();
        level.Update();
        string lastPhase = null; bool lastLive = false;
        bool Step(double until, Func<bool> stop = null)
        {
            while (tk.Now < until)
            {
                if (stop != null && stop()) return true;
                tk.Tick(Math.Min(tk.Now + 16, until));
                RigHost.Frame(16);
                foreach (var m in stage.Messages())
                {
                    var type = m["type"] as string;
                    if (type == "ready") level.RigReady();
                    else if (type == "cast") { Console.WriteLine($"  {tk.Now,6:0} ms: the page drew the cast {(m.TryGetValue("tag", out var t) ? t : "?")} ok {(m.TryGetValue("ok", out var ok) ? ok : "?")}"); level.RigCast(m.TryGetValue("tag", out var tg) ? tg as string : null, m.TryGetValue("ok", out var o) && o is bool b && b); }
                }
                level.Update();
                if (level.Phase != lastPhase || level.RigLive != lastLive) { Console.WriteLine($"  {tk.Now,6:0} ms: {level.Phase}{(level.RigLive ? ", rigs live" : "")} ({calls} calls)"); lastPhase = level.Phase; lastLive = level.RigLive; }
            }
            return stop != null && stop();
        }
        // to the sorting (the peek, the shake, the tumble: the rigs take the deal there if the page has drawn them), and
        // a moment for everyone to land
        if (!Step(60000, () => level.Phase == "place")) { Console.WriteLine("never got to the sorting"); return 1; }
        Step(tk.Now + 1500);
        Compare(level, stage, "at rest");
        Draw(dir, "sortlevel-place", bg, level, stage);
        // a tap on a squishy in the tray that has a home, then on that spot: the right spot's squash, hop and sparkles
        var B = level.Board; int pick = -1;
        for (int k = 0; k < B.Pieces.Count; k++) if (B.Pieces[k].Home != null && level.Play.At[k].IsTray) { pick = k; break; }
        if (pick < 0) { Console.WriteLine("no squishy in the tray with a home"); return 1; }
        var tc = TrayCenter(level.TrayGeo, level.Play.At[pick].I);
        var sc = SlotCenter(level.Geo, B.Pieces[pick].Home.Value);
        level.Down(tc.x + SortLevel.AreaX, tc.y); level.Up(tc.x + SortLevel.AreaX, tc.y);
        Step(tk.Now + 400);
        Draw(dir, "sortlevel-held", bg, level, stage);
        level.Down(sc.x + SortLevel.AreaX, sc.y); level.Up(sc.x + SortLevel.AreaX, sc.y);
        Step(tk.Now + 420);
        Draw(dir, "sortlevel-correct", bg, level, stage);
        Step(tk.Now + 1600);
        Compare(level, stage, "after the right spot");
        Draw(dir, "sortlevel-after", bg, level, stage);
        return 0;
    }

    // each rig where its still stands (sort.html draw: the still's square P x s, the rig's 0-100 box over its middle 88 %)
    static void Compare(SortLevel level, RigStage stage, string when)
    {
        var items = stage.Read().ToDictionary(i => i.Id);
        var B = level.Board; float P = level.PieceSize; var g = level.Geo; var tg = level.TrayGeo;
        float trayScale = Math.Min(1, tg.Cell * 0.94f / P);
        double worst = 0; int n = 0; var seen = new HashSet<string>();
        for (int k = 0; k < B.Pieces.Count; k++)
        {
            if (level.Play.Gone.Contains(k)) continue;
            var id = B.Pieces[k].Id; if (seen.Contains(id)) id = id + "#" + k; seen.Add(B.Pieces[k].Id);
            if (!items.TryGetValue(id, out var it)) { Console.WriteLine($"  {when}: no rig for piece {k} ({id})"); continue; }
            var at = level.Play.At[k];
            (double x, double y, double s) spot;
            if (at.IsSlot) { var c = SlotCenter(g, at.I); spot = (c.x - P / 2, c.y + g.S / 2 - P - 1, 1); }
            else { var c = TrayCenter(tg, at.I); spot = (c.x - P / 2, c.y - P / 2, trayScale); }
            double side = P * spot.s, ex = spot.x + P / 2 - side / 2 + 0.06 * side, ey = spot.y + P / 2 - side / 2 + 0.06 * side, ek = 0.88 * side / 100;
            double d = Math.Max(Math.Abs(it.Box.E - ex), Math.Max(Math.Abs(it.Box.F - ey), Math.Abs(it.Box.A - ek) * 100));
            worst = Math.Max(worst, d); n++;
        }
        Console.WriteLine($"  {when}: {n} rigs, the farthest {worst:0.###} dp from its still's spot (opacity {string.Join(" ", items.Values.Select(i => i.Opacity))})");
    }

    // the level's layers as Unity shows them (sort-test's Render), the rigs over them as StageView draws them
    static void Draw(string dir, string name, string bg, SortLevel level, RigStage stage)
    {
        var px = Render.Draw(bg, level.Layers, new SquishSquad.Ui.Blitz.ICardView[0], PW, PH);
        double k = PW / 832.0;
        var area = Affine.ScaleBy(k, k) * Affine.Translate(SortLevel.AreaX, 0);
        var clip = stage.Clip();
        double cl = clip == null ? double.NegativeInfinity : area.Apply(new Vec2(clip.Value.left, 0)).X, cr = clip == null ? double.PositiveInfinity : area.Apply(new Vec2(clip.Value.right, 0)).X;
        var items = stage.Read();
        var draw = new List<(double z, int dom, RigStage.Item it, bool shadow)>();
        foreach (var it in items) { draw.Add((it.Z, it.Index * 2 + 1, it, false)); if (it.HasShadow) draw.Add((it.ShadowZ, it.Index * 2, it, true)); }
        draw.Sort((p, q) => p.z != q.z ? p.z.CompareTo(q.z) : p.dom.CompareTo(q.dom));
        foreach (var (_, _, it, shadow) in draw)
        {
            double op = shadow ? it.ShadowOpacity : it.Opacity;
            if (op <= 0) continue;
            SvgScene scene;
            if (shadow) scene = SvgScene.Compile(SvgMarkup.Parse(Program.SHADOW), 100, 100, area * it.ShadowBox);
            else { var tree = new StageRig(it.Host, 0).TreeAt(0); if (tree == null) continue; scene = SvgScene.Compile(tree, 100, 100, area * it.Box); }
            var b = ReferenceRaster.Render(scene, PW, PH, SS);
            for (int y = 0; y < PH; y++)
                for (int x = 0; x < PW; x++)
                {
                    if (x + 0.5 < cl || x + 0.5 > cr) continue;
                    float r = 0, gg = 0, bl = 0, a = 0;
                    for (int sy = 0; sy < SS; sy++)
                        for (int sx = 0; sx < SS; sx++) { int i = ((y * SS + sy) * PW * SS + x * SS + sx) * 4; r += b.P[i]; gg += b.P[i + 1]; bl += b.P[i + 2]; a += b.P[i + 3]; }
                    float f = (float)op / (SS * SS); a *= f; if (a <= 0) continue;
                    int o = (y * PW + x) * 4;
                    px[o] = (byte)Math.Round(Math.Min(255, r * f * 255 + px[o] * (1 - a)));
                    px[o + 1] = (byte)Math.Round(Math.Min(255, gg * f * 255 + px[o + 1] * (1 - a)));
                    px[o + 2] = (byte)Math.Round(Math.Min(255, bl * f * 255 + px[o + 2] * (1 - a)));
                }
        }
        Png.Write(Path.Combine(dir, name + ".png"), PW, PH, px);
    }

    public static SortData Data()
    {
        var d = new SortData
        {
            BackXml = File.ReadAllText(Program.Res("Sort/back.xml")), BackLipXml = File.ReadAllText(Program.Res("Hop/back-lip.xml")),
            BackTopXml = File.ReadAllText(Program.Res("Hop/back-top.xml")), PauseTopXml = File.ReadAllText(Program.Res("Hop/pause-top.xml")),
        };
        var props = JsonDocument.Parse(File.ReadAllText(Program.Res("Sort/props.json"))).RootElement;
        foreach (var t in new[] { "fridge", "cupboard" }) d.Props[t] = props.GetProperty(t).EnumerateArray().Select(e => e.GetString()).ToList();
        var pools = JsonDocument.Parse(File.ReadAllText(Program.Res("Sort/sort.json"))).RootElement;
        foreach (var t in new[] { "fridge", "cupboard" }) d.Pools[t] = pools.GetProperty(t).EnumerateArray().Select(e => new PoolEntry(e.GetProperty("id").GetString(), "Stack/art/" + e.GetProperty("file").GetString())).ToList();
        return d;
    }
}
