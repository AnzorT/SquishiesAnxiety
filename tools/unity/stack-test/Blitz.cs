// dotnet run -c Release --project tools/unity/stack-test -- blitz <capture dir>   (blitz.mjs writes the app's run)
// Squish Stack's Blitz (blitz.mjs's run) from the Unity code: StackGame.CreateBlitz itself, run outside Unity on
// UnityStubs.cs, its Ticker stepped as the page's virtual clock was (16 ms frames from T0, when the countdown's timers
// are set), the app's puzzles and squishies handed in, the same taps and card presses at the same moments; at each
// moment the app was shot, every UiPiece the game shows is drawn with the reference rasteriser (its SVG, or its picture,
// where it is, faded, in sorting order) and compared with the app's screenshot.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Stack;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

static class BlitzTest
{
    // src/web/Preview.js PLAYER
    static Dictionary<string, object> Player() => new Dictionary<string, object>
    {
        ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" },
        ["sdk"] = new Dictionary<string, object> { ["plays"] = 3.0, ["lv"] = 12.0 },
        ["sort"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
        ["stack"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
        ["hop"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
    };

    static readonly int[] BLITZ_K = { 3, 3, 3, 3, 3, 4, 4, 4, 4, 4 };

    public static int Run(string dir, Func<string, string> res)
    {
        Fx.LikeWeb = true;
        Card.LoadXml = n => File.ReadAllText(res("Cards/" + n + ".xml"));
        Resources.Loader = (p, t) =>
        {
            if (t == typeof(TextAsset))
            {
                foreach (var ext in new[] { ".xml", ".json", ".txt" }) if (File.Exists(res(p + ext))) return new TextAsset { name = p, text = File.ReadAllText(res(p + ext)) };
                return null;
            }
            if (t == typeof(Texture2D) || t == typeof(Texture)) return File.Exists(res(p + ".png")) ? new Texture2D { name = p } : null;
            return null;
        };
        var sc = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "blitz.json"))).RootElement;
        var layout = JsonDocument.Parse(File.ReadAllText(res("Stack/stack.json"))).RootElement.GetProperty("art");
        Squishy Who(string key)
        {
            if (key != "" && layout.TryGetProperty(key, out var a)) return new Squishy { Key = key, Picture = "Stack/art/" + a.GetProperty("file").GetString(), Ar = (float)a.GetProperty("ar").GetDouble() };
            // a creature with no cut-out: the app shows its rig still (here a blank page) on a typical body box
            return new Squishy { Key = key, Picture = "Stack/art/(none)", Ar = 0.75f / 0.76f };
        }
        var puzzles = sc.GetProperty("puzzles").EnumerateArray().ToList();
        StackGame.Profile = Player();
        var root = new GameObject("root");
        var g = StackGame.CreateBlitz(root.transform, 2340, 1080);
        int next = 0, cur = 0;
        bool movesSame = true;
        g.PuzzleSource = spec =>
        {
            cur = Math.Min(next++, puzzles.Count - 1);
            var p = puzzles[cur];
            int[] Ints(string k) => p.GetProperty(k).EnumerateArray().Select(v => v.GetInt32()).ToArray();
            var goal = Ints("goal");
            var pz = new Puzzle { Start = Ints("start"), Goal = goal, Star = p.GetProperty("star").GetInt32(), Par = p.GetProperty("par").GetInt32(), Sol = Engine.Solve(spec.N, spec.K, goal) };
            if (Engine.Left(pz.Sol, pz.Start) != pz.Par) { Console.WriteLine($"  puzzle {cur + 1}: the C# solver's par {Engine.Left(pz.Sol, pz.Start)} isn't the app's {pz.Par}"); movesSame = false; }
            return pz;
        };
        g.CastSource = n => puzzles[cur].GetProperty("who").EnumerateArray().Select(k => Who(k.GetString())).ToArray();
        if (sc.TryGetProperty("heads", out var heads) && heads.ValueKind == JsonValueKind.Array)
            g.WinPictures = () => heads.EnumerateArray().Select(k => Who(k.GetString()).Picture).ToArray();
        g.Save = false;
        g.Init(0);
        double T0 = g.CountdownAt;
        void RunTo(double ms) { double now = Ticker.Default.Now; while (now < ms - 1e-9) { now = Math.Min(now + 16, ms); g.Advance(now); } }
        double worst = 0, sum = 0;
        int shots = 0;
        var report = new List<string>();
        foreach (var s in sc.GetProperty("steps").EnumerateArray())
        {
            double ms = s.GetProperty("at").GetDouble();
            RunTo(T0 + ms);
            if (s.TryGetProperty("move", out var mv))
            {
                int from = mv[0].GetInt32(), to = mv[1].GetInt32();
                // the C# engine's best move is the app's (a deliberate mistake aside)
                if (!s.TryGetProperty("what", out var w) || w.GetString() != "mistake")
                {
                    var best = BestFrom(g);
                    if (best == null || best.Value.from != from || best.Value.to != to) { movesSame = false; Console.WriteLine($"  at {ms}: the C# best move {best} isn't the app's {from} -> {to}"); }
                }
                g.TapMove(from, to);
            }
            else if (s.TryGetProperty("press", out var label)) { if (!g.PressCard(label.GetString())) Console.WriteLine($"  at {ms}: no {label.GetString()} to press"); }
            else if (s.TryGetProperty("back", out _)) g.TapBack();
            else if (s.TryGetProperty("shot", out var file))
            {
                var app = Path.Combine(dir, file.GetString());
                if (!File.Exists(app)) continue;
                var only = Environment.GetEnvironmentVariable("SHOTS");   // e.g. SHOTS=600,3040: just those
                if (only != null && !only.Split(',').Contains(((long)ms).ToString())) continue;
                g.Advance(T0 + ms);
                var stem = Path.Combine(dir, Path.GetFileNameWithoutExtension(file.GetString()));
                var svg = Screen();
                File.WriteAllText(stem + "-unity.svg", svg);
                double pct = Compare(svg, app, stem + "-unity.png", stem + "-diff.png", res, out int v, out int total);
                var name = s.GetProperty("name").GetString();
                if (Environment.GetEnvironmentVariable("BLITZ_DEBUG") != null)
                    Console.WriteLine("  " + string.Join(" ", new[] { "_phase", "_paused", "_canUndo", "_moves", "_held" }.Select(f => f + "=" + typeof(StackGame).GetField(f, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(g))));
                Console.WriteLine($"{ms,7} ms  {name,-34} ({g.Phase,-5}): {v,6} of {total} px differ visibly ({pct:0.00} %)");
                worst = Math.Max(worst, pct); sum += pct; shots++;
            }
        }
        Console.WriteLine($"mean {sum / Math.Max(1, shots):0.00} %, worst {worst:0.00} %; the C# engine's moves {(movesSame ? "are" : "are NOT")} the app's");
        return Flow() ? 0 : 1;
    }

    // what the app's run wasn't shot doing: the clock running out, Android's back on a pause, QUIT
    static bool Flow()
    {
        bool ok = true;
        void Check(bool c, string what) { Console.WriteLine($"  {(c ? "ok  " : "FAIL")} {what}"); ok &= c; }
        StackGame.Profile = Player();
        var g = StackGame.CreateBlitz(new GameObject("flow").transform, 2340, 1080);
        g.Save = false;
        bool left = false;
        g.OnExit = () => left = true;
        g.Init(0);
        double now = 0;
        void Run(double ms) { double end = now + ms; while (now < end) { now = Math.Min(now + 16, end); g.Advance(now); } }
        Run(5000);
        Check(g.Phase == "play", "playing once dealt");
        g.TapBack();
        Run(500);
        Check(g.Run.Paused && g.Run.CardOpen, "the back orb pauses");
        Run(10000);
        typeof(StackGame).GetMethod("Back", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(g, null);
        Run(500);
        Check(!g.Run.Paused && g.Phase == "play", "Android's back resumes");
        Run(Levels.BLITZ_MS - 5000);
        Check(g.Phase == "play", "the clock froze while paused (10 s): still playing 3:55 later");
        Run(5000);
        Check(g.Phase == "lost" && g.Run.CardName == "fail" && g.Run.FailReason == "time", "then it runs out: BACK TO PUZZLE 1! (the clock)");
        Run(2000);
        Check(g.Run.Done == 0, "the pips drained");
        Check(g.PressCard("QUIT") && left, "QUIT leaves");
        return ok;
    }

    // the C# engine's best move from where the game's squishies are (its private state, read through the test hook)
    static (int from, int to)? BestFrom(StackGame g)
    {
        var pos = (int[])typeof(StackGame).GetField("_pos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(g);
        var pz = (Puzzle)typeof(StackGame).GetField("_puzzle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(g);
        var m = Engine.BestMove(pz.Sol, pos);
        return m == null ? ((int, int)?)null : (m[1], m[2]);
    }

    // every piece on screen, in sorting order (ties: the order they were made), as UiPiece shows it
    static string Screen()
    {
        var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        int n = 0;
        foreach (var p in UiPiece.All.Where(p => !p.Destroyed && p.Visible && p.Opacity > 0 && (p.Markup != null || p.Picture != null)).OrderBy(p => p.Order).ThenBy(p => p.Seq))
        {
            var m = p.Transform;
            var op = p.Opacity < 1 ? $" opacity=\"{R(p.Opacity)}\"" : "";
            var tr = $"matrix({R(m.A)} {R(m.B)} {R(m.C)} {R(m.D)} {R(m.E)} {R(m.F)})";
            if (p.Picture != null)
            {
                sb.Append($"<g transform=\"{tr}\"{op}><image href=\"{p.Picture}\" x=\"0\" y=\"0\" width=\"{R(p.W)}\" height=\"{R(p.H)}\" preserveAspectRatio=\"none\"/></g>");
                continue;
            }
            var id = "p" + n++ + "-";
            sb.Append($"<defs><clipPath id=\"{id}room\"><rect x=\"{UiSvg.F(-p.Margin)}\" y=\"{UiSvg.F(-p.Margin)}\" width=\"{UiSvg.F(p.W + 2 * p.Margin)}\" height=\"{UiSvg.F(p.H + 2 * p.Margin)}\"/></clipPath></defs>");
            sb.Append($"<g transform=\"{tr}\"{op}><g clip-path=\"url(#{id}room)\">{Nest(p.Markup, id)}</g></g>");
        }
        return sb.Append("</svg>").ToString();
    }

    static string R(double v) => v.ToString("R", System.Globalization.CultureInfo.InvariantCulture);

    static string Nest(string svg, string p)
    {
        int a = svg.IndexOf('>') + 1;
        var inner = svg.Substring(a, svg.LastIndexOf("</svg>") - a);
        return inner.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
    }

    static double Compare(string svg, string appPng, string outPng, string diffPng, Func<string, string> res, out int visible, out int total)
    {
        var (W, H, reference) = Png.Read(appPng);
        var images = new Dictionary<string, (int, int, float[])>();
        (int, int, float[]) Load(string href)
        {
            if (images.TryGetValue(href, out var c)) return c;
            var f = res(href + ".png");
            if (!File.Exists(f)) return (0, 0, null);
            var (w, h, rgba) = Png.Read(f);
            var px = new float[w * h * 4];
            for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
            return images[href] = (w, h, px);
        }
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), W, H, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var ours = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, W, H, 2), 2, W, H);
        Png.Write(outPng, W, H, ours);
        visible = 0; total = W * H;
        var diff = new byte[W * H * 4];
        for (int i = 0; i < W * H * 4; i += 4)
        {
            int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
            bool v = d > 24;
            if (v) visible++;
            byte gr = (byte)(ours[i] * 0.3 + 150);
            diff[i] = v ? (byte)255 : gr; diff[i + 1] = v ? (byte)0 : gr; diff[i + 2] = v ? (byte)60 : gr; diff[i + 3] = 255;
        }
        Png.Write(diffPng, W, H, diff);
        return 100.0 * visible / total;
    }
}
