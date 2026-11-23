// dotnet run -c Release --project tools/unity/stack-test -- <capture dir>   (capture.mjs writes state.json + app.png)
// dotnet run -c Release --project tools/unity/stack-test -- cards <capture dir>   (cards.mjs: the cards, Cards.cs)
// Draws the Squish Stack level's screen around the board from the Unity code (the exported background, back orb and
// buttons, and StackArt's left column for the captured state) with the reference rasteriser, and compares it with
// the app's screenshot outside the board (where the squishies move).
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Games.Stack;
using SquishSquad.Ui;
using SquishSquad.Vector;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static int Main(string[] args)
    {
        if (args[0] == "cards")
        {
            UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
            UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, new JsonSerializerOptions { IncludeFields = true });
            return CardsTest.Run(args[1], Res);
        }
        var dir = args[0];
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        var st = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "state.json"))).RootElement;
        var layout = JsonDocument.Parse(File.ReadAllText(Res("Stack/stack.json"))).RootElement;
        var art = layout.GetProperty("art");
        var who = st.GetProperty("who").EnumerateArray().Select(k => { var a = art.GetProperty(k.GetString()); return new Squishy { Key = k.GetString(), Picture = "Stack/art/" + a.GetProperty("file").GetString(), Ar = (float)a.GetProperty("ar").GetDouble() }; }).ToArray();
        int moves = st.GetProperty("moves").GetInt32();
        var hud = new StackArt.Hud
        {
            Lv = st.GetProperty("lv").GetInt32(), Tier = st.GetProperty("tier").GetInt32(), Moves = moves, Par = st.GetProperty("par").GetInt32(),
            Stars = st.GetProperty("stars").GetInt32(), K = st.GetProperty("k").GetInt32(), Star = st.GetProperty("star").GetInt32(),
            TipText = st.GetProperty("tip").ValueKind == JsonValueKind.Null ? null : st.GetProperty("tip").GetString(),
            Who = who, Goal = st.GetProperty("goal").EnumerateArray().Select(v => v.GetInt32()).ToArray(),
        };
        // the screen: the page, the left column, the orb, the buttons (UNDO and RESTART off until a move, HINT on)
        string Inner(string svg) { int a = svg.IndexOf('>') + 1; return svg.Substring(a, svg.LastIndexOf("</svg>") - a); }
        // (each piece is its own SVG in Unity; nested in one here, their ids get a prefix so they don't clash)
        int nests = 0;
        string Nest(string svg, double x, double y)
        {
            var p = "p" + (nests++) + "-";
            var inner = Inner(svg).Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
            return $"<g transform=\"translate({UiSvg.F(x)} {UiSvg.F(y)})\">{inner}</g>";
        }
        string Xml(string name) => File.ReadAllText(Res("Stack/" + name + ".xml"));
        var screen = new System.Text.StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        screen.Append(Nest(Xml("bg"), 0, 0));
        screen.Append(Nest(StackArt.LeftColumn(hud, 384), 0, 0));
        var back = layout.GetProperty("back");
        screen.Append(Nest(Xml("back"), back[0].GetDouble(), back[1].GetDouble()));
        foreach (var (label, on) in new[] { ("undo", moves > 0), ("restart", moves > 0), ("hint", true) })
        {
            var name = $"btn-{label}-{(on ? "on" : "off")}";
            var b = layout.GetProperty("buttons").GetProperty(name);
            double bx = b.GetProperty("b")[0].GetDouble(), by = b.GetProperty("b")[1].GetDouble();
            screen.Append(Nest(Xml(name + "-lip"), bx + b.GetProperty("lip")[0].GetDouble(), by + b.GetProperty("lip")[1].GetDouble()));
            screen.Append(Nest(Xml(name + "-face"), bx + b.GetProperty("ring")[0].GetDouble(), by + b.GetProperty("ring")[1].GetDouble()));
        }
        screen.Append("</svg>");
        File.WriteAllText(Path.Combine(dir, "unity.svg"), screen.ToString());

        var (W, H, reference) = Png.Read(Path.Combine(dir, "app.png"));
        var images = new System.Collections.Generic.Dictionary<string, (int, int, float[])>();
        (int, int, float[]) Load(string href)
        {
            if (images.TryGetValue(href, out var c)) return c;
            var f = Res(href + ".png");
            if (!File.Exists(f)) return (0, 0, null);
            var (w, h, rgba) = Png.Read(f);
            var px = new float[w * h * 4];
            for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
            return images[href] = (w, h, px);
        }
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(screen.ToString()), W, H, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var ours = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, W, H, 2), 2, W, H);
        Png.Write(Path.Combine(dir, "unity.png"), W, H, ours);
        // compare outside the board (x 250..682 dp)
        double k = W / 832.0;
        int visible = 0, counted = 0;
        var diff = new byte[W * H * 4];
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                bool board = x >= 250 * k && x < 682 * k;
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                if (!board) { counted++; if (d > 24) visible++; }
                byte g = (byte)(ours[i] * 0.3 + 150);
                diff[i] = d > 24 && !board ? (byte)255 : g; diff[i + 1] = d > 24 && !board ? (byte)0 : g; diff[i + 2] = d > 24 && !board ? (byte)60 : g; diff[i + 3] = 255;
            }
        Png.Write(Path.Combine(dir, "diff.png"), W, H, diff);
        Console.WriteLine($"outside the board: {visible} of {counted} px differ visibly ({100.0 * visible / counted:0.00} %)");
        return 0;
    }
}
