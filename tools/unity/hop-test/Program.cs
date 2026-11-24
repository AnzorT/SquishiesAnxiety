// dotnet run -c Release --project tools/unity/hop-test -- <capture dir> [scene ...]   (capture.mjs: the app's shots)
// dotnet run -c Release --project tools/unity/hop-test -- cards <capture dir>          (cards.mjs: the cards alone)
// Builds the Squish Hop level from the Unity code (Games/Hop/HopLevel: the port of src/hop/Game.js) for each scene the
// app was captured in, runs its clock frame by frame as capture.mjs ran the page's (16 ms frames; the same taps at the
// same moments, at the same spots), draws the whole screen at each shot (every layer as Unity shows it: an SVG drawn
// into its box plus its margin, a picture, a picture cut to a box, the rug in perspective as a grid of small pieces;
// then the cards) with the reference rasteriser, and compares it with the app's screenshot of the same moment.
// Reports the pixels that differ visibly (any channel > 24 of 255): on the whole screen, on the board's area and on the
// HUD columns. Writes <shot>-unity.png and <shot>-diff.png (red: differs) next to the app's.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Hop;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static int Main(string[] args)
    {
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        HopLevel.LoadXml = n => File.ReadAllText(Res("Hop/" + n + ".xml"));
        SquishSquad.Ui.Cards.Card.LoadXml = n => File.ReadAllText(Res("Cards/" + n + ".xml"));
        Fx.LikeWeb = true;
        HopLevel.PixelSnap = 2.8125f;   // the reference phone
        if (args[0] == "cards") return HopCardsTest.Run(args[1]);
        if (args[0] == "stuck")
        {
            // the shortest way to get stuck on a level (for capture.mjs's STUCK! scene): hops as U R D L
            var spec = Levels.LevelSpec(int.Parse(args[1]));
            var q = new Queue<(HopState st, string path)>();
            q.Enqueue((Engine.NewState(spec.Board), ""));
            while (q.Count > 0)
            {
                var (st, path) = q.Dequeue();
                var ms = Engine.Moves(spec.Board, st);
                if (ms.Count == 0 && !st.Done && path.Length > 0) { Console.WriteLine(path); return 0; }
                if (path.Length < 12) foreach (var m in ms) if (!m.St.Done) q.Enqueue((m.St, path + Engine.DCH[m.D]));
            }
            return 1;
        }
        var dir = args[0];
        OutDir = Path.GetFullPath(dir);
        var only = args.Skip(1).ToHashSet();
        var cast = LoadCast();
        var scenes = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "scenes.json"))).RootElement;
        var all = new List<(string shot, double total, double board, double hud)>();
        foreach (var sc in scenes.EnumerateArray())
        {
            var name = sc.GetProperty("name").GetString();
            if (only.Count > 0 && !only.Contains(name)) continue;
            int lv = sc.GetProperty("lv").GetInt32();
            // (a level switched to: level 12 first, as the app opened it from the map, then the switch)
            bool switched = sc.TryGetProperty("switchAt", out var sw);
            double settle = switched ? sw.GetDouble() : sc.GetProperty("settle").GetDouble();
            var tk = new Ticker(0);
            var level = new HopLevel(832, 384, switched ? 12 : lv, cast, Player(), tk);
            void Run(double to) { while (tk.Now < to) { tk.Tick(Math.Min(tk.Now + 16, to)); level.Update(); } }
            if (switched) { Run(settle); level.Switch(lv); }
            var events = new List<(double at, Action act, double shot)>();
            foreach (var s in sc.GetProperty("steps").EnumerateArray())
            {
                if (s.TryGetProperty("path", out var path))
                {
                    var pts = path.EnumerateArray().Select(q => ((float)q[0].GetDouble(), (float)q[1].GetDouble())).ToArray();
                    events.Add((s.GetProperty("at").GetDouble(), () =>
                    {
                        level.Down(pts[0].Item1, pts[0].Item2);
                        for (int i = 1; i < pts.Length; i++) level.Move(pts[i].Item1, pts[i].Item2);
                        level.Up(pts[^1].Item1, pts[^1].Item2);
                    }, -1));
                    continue;
                }
                float x = (float)s.GetProperty("x").GetDouble(), y = (float)s.GetProperty("y").GetDouble();
                events.Add((s.GetProperty("at").GetDouble(), () => { level.Down(x, y); level.Up(x, y); }, -1));
            }
            foreach (var s in sc.GetProperty("shots").EnumerateArray()) events.Add((s.GetDouble(), null, s.GetDouble()));
            events = events.OrderBy(e => e.at).ThenBy(e => e.act == null ? 1 : 0).ToList();
            Run(settle);
            foreach (var e in events)
            {
                Run(settle + e.at);
                if (e.act != null) { e.act(); level.Update(); continue; }
                var app = Path.Combine(dir, $"{name}-{e.shot}.png");
                if (!File.Exists(app)) continue;
                level.Update();
                var svg = Screen(level);
                File.WriteAllText(Path.Combine(dir, $"{name}-{e.shot}-unity.svg"), svg);
                var (t, b, h) = Compare(svg, app, Path.Combine(dir, $"{name}-{e.shot}-unity.png"), Path.Combine(dir, $"{name}-{e.shot}-diff.png"));
                Console.WriteLine($"{name,-10} {e.shot,6} ms: {t,5:0.00} % of the screen differs visibly (board {b:0.00} %, HUD {h:0.00} %)");
                all.Add(($"{name}-{e.shot}", t, b, h));
            }
        }
        if (all.Count > 0) Console.WriteLine($"mean: {all.Average(a => a.total):0.00} % (board {all.Average(a => a.board):0.00} %, HUD {all.Average(a => a.hud):0.00} %), worst {all.Max(a => a.total):0.00} %");
        return 0;
    }

    // src/web/Preview.js's PLAYER: owns Mittens, level 12 unlocked, nothing won yet
    public static Dictionary<string, object> Player() => new Dictionary<string, object>
    {
        ["coins"] = 100.0, ["gems"] = 600.0, ["ownedIds"] = new List<object> { "1" },
        ["hop"] = new Dictionary<string, object> { ["seen"] = true, ["lv"] = 12.0 },
    };

    static List<HopSquishy> LoadCast()
    {
        var j = JsonDocument.Parse(File.ReadAllText(Res("Hop/hop.json"))).RootElement;
        var heads = j.GetProperty("heads").EnumerateArray().Select(h => h.GetString()).ToHashSet();
        return j.GetProperty("cast").EnumerateArray().Select(c =>
        {
            var key = c.GetProperty("key").GetString();
            var file = c.GetProperty("file").GetString();
            return new HopSquishy
            {
                Id = c.GetProperty("id").GetString(), Key = key, Ar = (float)c.GetProperty("ar").GetDouble(),
                Box = c.GetProperty("box").EnumerateArray().Select(v => (float)v.GetDouble()).ToArray(),
                Picture = string.IsNullOrEmpty(file) ? null : "Stack/art/" + file,
                Happy = heads.Contains(key) ? "Hop/heads/" + key + "-happy" : null,
                Sad = heads.Contains(key) ? "Hop/heads/" + key + "-sad" : null,
            };
        }).ToList();
    }

    // ---- the screen as one SVG, every layer as Unity shows it --------------------------------------------------------
    static string Screen(HopLevel level)
    {
        var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        int n = 0;
        var layers = level.Layers.Select((l, i) => (l, i)).OrderBy(p => p.l.Order).ThenBy(p => p.i).Select(p => p.l).ToList();
        bool cardsDone = false;
        foreach (var l in layers)
        {
            if (!cardsDone && l.Order >= HopLevel.CardOrder) { foreach (var c in level.Cards) { c.Update(); foreach (var cl in c.Layers()) Card(sb, cl, ref n); } cardsDone = true; }
            if (!l.Visible || l.Opacity <= 0) continue;
            var p = "p" + n++ + "-";
            var m = l.Transform;
            string op = l.Opacity < 1 ? $" opacity=\"{R(l.Opacity)}\"" : "";
            if (l.Markup != null)
            {
                sb.Append($"<defs><clipPath id=\"{p}room\"><rect x=\"{UiSvg.F(-l.Margin)}\" y=\"{UiSvg.F(-l.Margin)}\" width=\"{UiSvg.F(l.W + 2 * l.Margin)}\" height=\"{UiSvg.F(l.H + 2 * l.Margin)}\"/></clipPath></defs>");
                sb.Append($"<g transform=\"{M(m)}\"{op}><g clip-path=\"url(#{p}room)\">{Nest(l.Markup, p)}</g></g>");
            }
            else if (l.Grid != null)
            {
                // the rug on the plane: drawn here straight from the board's perspective (Unity draws it as a fine grid of
                // small quads with the same corners; the two differ by less than a pixel)
                sb.Append($"<g{op}><image href=\"{Plane(level, l)}\" width=\"832\" height=\"384\" preserveAspectRatio=\"none\"/></g>");
            }
            else if (l.Picture != null)
            {
                if (l.TileW > 0) continue;   // the flash's dots: only while a room switches
                string clip = "";
                if (l.Clip != null)
                {
                    sb.Append($"<defs><clipPath id=\"{p}c\"><rect x=\"{R(l.Clip[0])}\" y=\"{R(l.Clip[1])}\" width=\"{R(l.Clip[2])}\" height=\"{R(l.Clip[3])}\"/></clipPath></defs>");
                    clip = $" clip-path=\"url(#{p}c)\"";
                }
                sb.Append($"<g transform=\"{M(m)}\"{op}><g{clip}><image href=\"{l.Picture}\" width=\"{R(l.W)}\" height=\"{R(l.H)}\" preserveAspectRatio=\"none\"/></g></g>");
            }
        }
        if (!cardsDone) foreach (var c in level.Cards) { c.Update(); foreach (var cl in c.Layers()) Card(sb, cl, ref n); }
        return sb.Append("</svg>").ToString();
    }

    public static void Card(StringBuilder sb, CardLayer l, ref int n)
    {
        if (!l.Visible || l.Opacity <= 0 || l.Markup == null) return;
        var p = "c" + n++ + "-";
        sb.Append($"<defs><clipPath id=\"{p}room\"><rect x=\"{UiSvg.F(-l.Margin)}\" y=\"{UiSvg.F(-l.Margin)}\" width=\"{UiSvg.F(l.W + 2 * l.Margin)}\" height=\"{UiSvg.F(l.H + 2 * l.Margin)}\"/></clipPath></defs>");
        sb.Append($"<g transform=\"{M(l.Transform)}\"{(l.Opacity < 1 ? $" opacity=\"{R(Math.Max(0, l.Opacity))}\"" : "")}><g clip-path=\"url(#{p}room)\">{Nest(l.Markup, p)}</g></g>");
    }

    // A picture laid on the plane as the layer's grid says (its corners at grid points 0 and N on each side), drawn at the
    // reference screen's pixels by following each pixel back onto the plane (BoardGeometry.CellAt's inverse), sampled
    // bilinearly; saved as a picture the SVG can show.
    static readonly Dictionary<string, string> Planes = new Dictionary<string, string>();
    static string OutDir;
    static string Plane(HopLevel level, HopLayer l)
    {
        var B = level.Board;
        string key = $"{l.Picture}-{B.W}x{B.H}-{B.T}-{B.Cx}-{B.Cy}";
        if (Planes.TryGetValue(key, out var file)) return file;
        var (tw, th, tex) = Load(l.Picture);
        const int W = 2340, H = 1080;
        double k = W / 832.0;
        var px = new byte[W * H * 4];
        // the grid's corners in board units: the layer's first and last points, followed back onto the plane
        (double u, double v) Back(double sx, double sy)
        {
            double x = (sx - B.Cx) / B.T, y = (sy - B.Cy) / B.T;
            double Y = (y * BoardGeometry.DEPTH) / (BoardGeometry.DEPTH * B.C + y * B.Sn);
            double s = BoardGeometry.DEPTH / (BoardGeometry.DEPTH - Y * B.Sn);
            return (x / s + B.W / 2.0, Y + B.H / 2.0);
        }
        int n = l.GridN, last = (n + 1) * (n + 1) - 1;
        var a = Back(l.Grid[0] - HopLevel.LeftW, l.Grid[1]);
        var b = Back(l.Grid[last * 2] - HopLevel.LeftW, l.Grid[last * 2 + 1]);
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                var (u, v) = Back((x + 0.5) / k - HopLevel.LeftW, (y + 0.5) / k);
                double tx = (u - a.u) / (b.u - a.u) * tw - 0.5, ty = (v - a.v) / (b.v - a.v) * th - 0.5;
                if (double.IsNaN(tx) || tx < -1 || ty < -1 || tx > tw || ty > th) continue;
                int x0 = (int)Math.Floor(tx), y0 = (int)Math.Floor(ty);
                double fx = tx - x0, fy = ty - y0;
                double r = 0, g = 0, bl = 0, al = 0;
                for (int j = 0; j < 2; j++)
                    for (int i = 0; i < 2; i++)
                    {
                        int xx = x0 + i, yy = y0 + j;
                        if (xx < 0 || yy < 0 || xx >= tw || yy >= th) continue;
                        double w = (i == 0 ? 1 - fx : fx) * (j == 0 ? 1 - fy : fy);
                        int o = (yy * tw + xx) * 4;
                        double aa = tex[o + 3] * w;
                        r += tex[o] * aa; g += tex[o + 1] * aa; bl += tex[o + 2] * aa; al += aa;
                    }
                if (al <= 0) continue;
                int q = (y * W + x) * 4;
                px[q] = (byte)Math.Round(r / al * 255); px[q + 1] = (byte)Math.Round(g / al * 255); px[q + 2] = (byte)Math.Round(bl / al * 255); px[q + 3] = (byte)Math.Round(al * 255);
            }
        file = Path.Combine(OutDir, $"plane-{Planes.Count}");
        Png.Write(file + ".png", W, H, px);
        return Planes[key] = file;
    }

    static string M(Affine m) => $"matrix({R(m.A)} {R(m.B)} {R(m.C)} {R(m.D)} {R(m.E)} {R(m.F)})";
    static string R(double v) => v.ToString("R", System.Globalization.CultureInfo.InvariantCulture);

    public static string Nest(string svg, string p)
    {
        int a = svg.IndexOf('>') + 1;
        var inner = svg.Substring(a, svg.LastIndexOf("</svg>") - a);
        return inner.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
    }

    // ---- the comparison -------------------------------------------------------------------------------------------------
    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    static (int, int, float[]) Load(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = href.StartsWith("/") ? href + ".png" : Res(href + ".png");
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    public static (double total, double board, double hud) Compare(string svg, string appPng, string outPng, string diffPng)
    {
        var (W, H, reference) = Png.Read(appPng);
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), W, H, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var ours = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, W, H, 2), 2, W, H);
        Png.Write(outPng, W, H, ours);
        double k = W / 832.0;
        int vis = 0, visB = 0, nB = 0;
        var diff = new byte[W * H * 4];
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                bool v = d > 24, board = x >= 250 * k && x < 682 * k;
                if (v) vis++;
                if (board) { nB++; if (v) visB++; }
                byte g = (byte)(ours[i] * 0.3 + 150);
                diff[i] = v ? (byte)255 : g; diff[i + 1] = v ? (byte)0 : g; diff[i + 2] = v ? (byte)60 : g; diff[i + 3] = 255;
            }
        Png.Write(diffPng, W, H, diff);
        int total = W * H;
        return (100.0 * vis / total, 100.0 * visB / nB, 100.0 * (vis - visB) / (total - nB));
    }
}
