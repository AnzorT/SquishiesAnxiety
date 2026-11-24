// dotnet run -c Release --project tools/unity/maps-test -- <capture dir> [scenario ...]     (capture.mjs's output; DUMP=1
//   lists each shot's layers)
// dotnet run -c Release --project tools/unity/maps-test -- fling     (the map's drag and fling at a few finger speeds)
// Plays each scenario of scenarios.json on the Unity code (Games/Shared GameScreen with StackDef / SortDef / HopDef, the
// made-up player of src/web/Preview.js, the clock stepped 16 ms a frame as capture.mjs stepped the page's, the same
// taps and scrolls at the same moments), draws each shot's layers as Unity shows them with the reference rasteriser,
// and compares it with the app's screenshot of that moment: the pixels whose colour differs by more than 24 of 255.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Shared;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    // Preview.js's PLAYER (numbers as JSON gives them: doubles)
    static Dictionary<string, object> Player() => new Dictionary<string, object>
    {
        ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" },
        ["sort"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
        ["stack"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
        ["hop"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
    };

    static object FromJson(JsonElement e) => e.ValueKind switch
    {
        JsonValueKind.Object => e.EnumerateObject().ToDictionary(p => p.Name, p => FromJson(p.Value)),
        JsonValueKind.Array => e.EnumerateArray().Select(FromJson).ToList(),
        JsonValueKind.Number => e.GetDouble(),
        JsonValueKind.True => true,
        JsonValueKind.False => false,
        JsonValueKind.String => e.GetString(),
        _ => null,
    };

    // the scroll's drag and fling: a finger moving left at a steady speed, then lifted; where the content goes
    static int Fling()
    {
        foreach (var speed in new[] { 100.0, 600, 2000, 6000 })   // dp/s
        {
            var m = new MapScroll { Max = 4000 };
            m.ScrollTo(1000);
            double t = 0; float x = 600;
            m.Down(x, t);
            for (int i = 0; i < 10; i++) { t += 16; x -= (float)(speed * 0.016); m.Move(x, t); }
            double atUp = m.X;
            m.Up(x, t);
            double t0 = t, last = m.X;
            while (m.Flinging && t < t0 + 10000) { t += 16; m.Update(t); }
            Console.WriteLine($"{speed,5} dp/s: dragged to {atUp:0.#} (slop 8 dp), flung {m.X - atUp:0.#} dp more in {t - t0:0} ms");
        }
        return 0;
    }

    static int Main(string[] args)
    {
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
        Card.LoadXml = n => File.ReadAllText(Res("Cards/" + n + ".xml"));
        HubsData.LoadXml = n => File.ReadAllText(Res(n + ".xml"));
        HubsData.Current = JsonSerializer.Deserialize<HubsData>(File.ReadAllText(Res("Hubs/hubs.json")), new JsonSerializerOptions { IncludeFields = true });
        Fx.LikeWeb = true;
        if (args[0] == "fling") return Fling();
        string dir = args[0];
        var only = args.Skip(1).ToHashSet();
        var scen = JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "../../../scenarios.json"))).RootElement;
        string bg = File.ReadAllText(Res("Stack/bg.xml"));
        var summary = new List<string>();
        foreach (var s in scen.EnumerateArray())
        {
            string name = s.GetProperty("name").GetString();
            if (only.Count > 0 && !only.Contains(name)) continue;
            var sdir = Path.Combine(dir, name);
            if (!Directory.Exists(sdir)) { Console.WriteLine($"{name}: not captured"); continue; }
            var tk = new Ticker(0);
            Ticker.Default = tk;
            var profile = Player();
            if (s.TryGetProperty("profile", out var pj))
                foreach (var sec in pj.EnumerateObject())
                {
                    var d = (Dictionary<string, object>)profile[sec.Name];
                    foreach (var kv in (Dictionary<string, object>)FromJson(sec.Value)) d[kv.Key] = kv.Value;
                }
            string card = s.GetProperty("card").GetString();
            GameDef def = card == "game-stack" ? new SquishSquad.Games.Stack.StackDef(profile)
                : card == "game-sort" ? new SquishSquad.Games.Sort.SortDef(profile)
                : (GameDef)new SquishSquad.Games.Hop.HopDef(profile);
            var screen = new GameScreen(def, 832, 384) { Season = Environment.GetEnvironmentVariable("SEASON") ?? "rainy" };
            screen.Start();
            screen.Update();
            var log = JsonDocument.Parse(File.ReadAllText(Path.Combine(sdir, "log.json"))).RootElement.EnumerateArray().ToList();
            foreach (var e in s.GetProperty("steps").EnumerateArray().OrderBy(e => e.GetProperty("at").GetDouble()))
            {
                double at = e.GetProperty("at").GetDouble();
                while (tk.Now < at) { tk.Tick(Math.Min(tk.Now + 16, at)); screen.Update(); }
                if (e.TryGetProperty("tap", out var tap))
                {
                    float x = tap[0].GetSingle(), y = tap[1].GetSingle();
                    screen.Down(x, y); screen.Up(x, y); screen.Update();
                }
                else if (e.TryGetProperty("scroll", out var sc))
                {
                    var got = log.FirstOrDefault(l => l.GetProperty("at").GetDouble() == at && l.TryGetProperty("scroll", out _));
                    double x = got.ValueKind == JsonValueKind.Object ? got.GetProperty("scroll").GetDouble() : sc.GetDouble();
                    screen.Map?.Scroll.ScrollTo(x);
                    screen.Update();
                }
                else if (e.TryGetProperty("shot", out _))
                {
                    screen.Update();
                    var app = Path.Combine(sdir, $"app-{at}.png");
                    if (!File.Exists(app)) continue;
                    if (Environment.GetEnvironmentVariable("DUMP") == "1")
                        foreach (var l in screen.Frame.List) Console.WriteLine($"   {l.Name,-28} {l.Transform.E,8:0.###} {l.Transform.F,8:0.###} {l.W,8:0.###} {l.H,8:0.###} op {l.Opacity:0.###}");
                    var (visible, total) = Render.Compare(bg, screen.Frame.List, screen.Cards, app, Path.Combine(sdir, $"unity-{at}.png"), Path.Combine(sdir, $"diff-{at}.png"));
                    var entry = log.FirstOrDefault(l => l.GetProperty("at").GetDouble() == at && l.TryGetProperty("shot", out _));
                    string sl = entry.ValueKind == JsonValueKind.Object && entry.GetProperty("scrollLeft").ValueKind == JsonValueKind.Number ? $" scroll {entry.GetProperty("scrollLeft").GetDouble()}/{screen.Map?.Scroll.X:0.##}" : "";
                    var line = $"{name,-14} {at,6} ms  {screen.View,-4}: {visible,6} of {total} px differ visibly ({100.0 * visible / total:0.00} %){sl}";
                    Console.WriteLine(line);
                    summary.Add(line);
                }
            }
        }
        File.WriteAllLines(Path.Combine(dir, "summary.txt"), summary);
        return 0;
    }
}
