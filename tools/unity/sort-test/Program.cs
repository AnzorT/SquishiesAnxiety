// dotnet run -c Release --project tools/unity/sort-test -- <capture dir> ["ms:x,y ..." taps]   (capture.mjs's output)
// dotnet run -c Release --project tools/unity/sort-test -- cards <capture dir>                   (cards.mjs: Cards.cs)
// Plays the captured Squish Sort level with the Unity code (Games/Sort/SortLevel on the app's board, the clock stepped
// 16 ms a frame as capture.mjs stepped the page's, the same taps at the same moments), draws each moment's layers as
// Unity shows them (the exported page, every SVG / picture layer transformed and faded, each door projected with its
// perspective) with the reference rasteriser, and compares it with the app's screenshot of that moment.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Sort;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static int Main(string[] args)
    {
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
        Card.LoadXml = n => File.ReadAllText(Res("Cards/" + n + ".xml"));
        Fx.LikeWeb = true;
        if (args[0] == "cards") return CardsTest.Run(args[1]);
        return Level(args[0], args.Length > 1 ? args[1] : "");
    }

    public static SortData Data()
    {
        var d = new SortData { BackXml = File.ReadAllText(Res("Sort/back.xml")) };
        var props = JsonDocument.Parse(File.ReadAllText(Res("Sort/props.json"))).RootElement;
        foreach (var t in new[] { "fridge", "cupboard" }) d.Props[t] = props.GetProperty(t).EnumerateArray().Select(e => e.GetString()).ToList();
        var pools = JsonDocument.Parse(File.ReadAllText(Res("Sort/sort.json"))).RootElement;
        foreach (var t in new[] { "fridge", "cupboard" }) d.Pools[t] = pools.GetProperty(t).EnumerateArray().Select(e => new PoolEntry(e.GetProperty("id").GetString(), "Stack/art/" + e.GetProperty("file").GetString())).ToList();
        return d;
    }

    // the app's picture of a squishy: its bundled Stack cut-out (Preview.js), or none (about:blank)
    static string Uri(string u)
    {
        var m = System.Text.RegularExpressions.Regex.Match(Uri2(u), @"assets/stack/(\w+)\.webp");
        return m.Success ? "Stack/art/" + m.Groups[1].Value : null;
    }
    static string Uri2(string u) => System.Net.WebUtility.UrlDecode(u ?? "");

    static BoardData BoardOf(JsonElement b)
    {
        var d = new BoardData { Rows = b.GetProperty("rows").GetInt32(), Cols = b.GetProperty("cols").GetInt32(), Slots = b.GetProperty("slots").GetInt32(), TrayCap = b.GetProperty("trayCap").GetInt32() };
        foreach (var p in b.GetProperty("pieces").EnumerateArray())
            d.Pieces.Add(new Piece { Id = p.GetProperty("id").GetString(), Uri = Uri(p.GetProperty("uri").GetString()), Home = p.TryGetProperty("home", out var h) && h.ValueKind == JsonValueKind.Number ? h.GetInt32() : (int?)null });
        foreach (var kv in b.GetProperty("start").EnumerateObject()) d.Start[int.Parse(kv.Name)] = kv.Value.GetInt32();
        foreach (var s in b.GetProperty("swaps").EnumerateArray()) d.Swaps.Add(s.EnumerateArray().Select(v => v.ValueKind == JsonValueKind.Number ? v.GetInt32() : (int?)null).ToArray());
        foreach (var kv in b.GetProperty("after").EnumerateObject()) d.After[int.Parse(kv.Name)] = new Place(kv.Value.GetProperty("kind").GetString(), kv.Value.GetProperty("i").GetInt32());
        foreach (var kv in b.GetProperty("foodBefore").EnumerateObject()) d.FoodBefore[int.Parse(kv.Name)] = kv.Value.GetInt32();
        foreach (var kv in b.GetProperty("foodAfter").EnumerateObject()) d.FoodAfter[int.Parse(kv.Name)] = kv.Value.GetInt32();
        return d;
    }

    static int Level(string dir, string tapsArg)
    {
        var st = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "state.json"))).RootElement;
        var tk = new Ticker(0);
        Ticker.Default = tk;
        // Preview.js's player: sort { seen, lv: 12 } (the fridge's record starts at level 1, skill 0)
        var profile = new Dictionary<string, object> { ["sort"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 } };
        // the boards the app dealt, in order (capture.mjs boards.json; the first one only in state.json)
        var boards = new List<BoardData> { BoardOf(st.GetProperty("board")) };
        var bf = Path.Combine(dir, "boards.json");
        if (File.Exists(bf)) boards = JsonDocument.Parse(File.ReadAllText(bf)).RootElement.EnumerateArray().Select(BoardOf).ToList();
        int dealt = 0;
        var level = new SortLevel(st.GetProperty("theme").GetString(), st.GetProperty("lv").GetInt32(), 832, 384, Data(), profile) { MakeBoardHook = _ => boards[Math.Min(dealt++, boards.Count - 1)] };
        var rf = Path.Combine(dir, "randoms.json");
        if (File.Exists(rf))
        {
            var q = new Queue<double>(JsonDocument.Parse(File.ReadAllText(rf)).RootElement.EnumerateArray().Select(e => e.GetDouble()));
            level.Random = () => q.Count > 0 ? q.Dequeue() : 0.5;
        }
        level.Start();
        level.Update();
        // the sizes the app worked out
        var g = st.GetProperty("g"); var tg = st.GetProperty("tg");
        var ours = level.Geo;
        Console.WriteLine($"S {ours.S}/{g.GetProperty("S").GetDouble()}  bx {ours.Bx}/{g.GetProperty("bx").GetDouble()}  by {ours.By}/{g.GetProperty("by").GetDouble()}  deg {ours.Deg}/{g.GetProperty("deg").GetDouble()}  tray {level.TrayGeo.Tx},{level.TrayGeo.Ty} {level.TrayGeo.Cell}/{tg.GetProperty("tx").GetDouble()},{tg.GetProperty("ty").GetDouble()} {tg.GetProperty("cell").GetDouble()}  peek {level.Spec.PeekMs}/{st.GetProperty("spec").GetProperty("peekMs").GetDouble()}");
        // the taps, as capture.mjs plays them (a tap: down, up 60 ms later; a drag: 8 moves 20 ms apart, up at 200)
        var events = new List<(double ms, int order, Action act)>();
        foreach (var s in tapsArg.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = s.Split(':'); double ms = double.Parse(parts[0]);
            var ab = parts[1].Split('>');
            float[] P(string q) => q.Split(',').Select(float.Parse).ToArray();
            var a = P(ab[0]); var b = ab.Length > 1 ? P(ab[1]) : null;
            events.Add((ms, 0, () => level.Down(a[0], a[1])));
            if (b != null) for (int k = 1; k <= 8; k++) { int kk = k; events.Add((ms + k * 20, 0, () => level.Move(a[0] + (b[0] - a[0]) * kk / 8, a[1] + (b[1] - a[1]) * kk / 8))); }
            var end = b ?? a;
            events.Add((ms + (b != null ? 200 : 60), 0, () => { if (b == null) level.Move(end[0], end[1]); level.Up(end[0], end[1]); }));
        }
        foreach (var f in Directory.GetFiles(dir, "app-*.png"))
        {
            var ms = double.Parse(Path.GetFileNameWithoutExtension(f).Substring(4));
            events.Add((ms, 1, null));
        }
        events.Sort((x, y) => x.ms != y.ms ? x.ms.CompareTo(y.ms) : x.order.CompareTo(y.order));
        string bg = File.ReadAllText(Res("Sort/bg.xml"));
        foreach (var e in events)
        {
            while (tk.Now < e.ms) { tk.Tick(Math.Min(tk.Now + 16, e.ms)); level.Update(); }
            if (e.act != null) { e.act(); level.Update(); continue; }
            level.Update();
            var name = Path.Combine(dir, $"unity-{e.ms}");
            var app = Path.Combine(dir, $"app-{e.ms}.png");
            var (visible, total) = Render.Compare(bg, level.Layers, level.Cards, app, name + ".png", Path.Combine(dir, $"diff-{e.ms}.png"));
            Console.WriteLine($"{level.Phase,-7} {e.ms,6} ms: {visible,6} of {total} px differ visibly ({100.0 * visible / total:0.00} %)");
            // (where the open cards' buttons are, to tap them in a capture)
            foreach (var c in level.Cards) foreach (var b in c.Buttons) { var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2)); Console.WriteLine($"    {b.Look.Label} at {p.X:0},{p.Y:0}"); }
        }
        return 0;
    }
}
