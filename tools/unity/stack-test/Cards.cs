// dotnet run -c Release --project tools/unity/stack-test -- cards <capture dir>   (cards.mjs writes the app's pictures)
// Builds each Squish Stack card from the Unity code (Games/Stack/StackCards.cs on Ui/Cards) with Preview.js's sample
// data, runs its clock frame by frame as cards.mjs ran the page's (16 ms frames, the last landing on the moment), draws
// the screen (the page behind, then every card layer where it is, clipped to the room UiPiece gives it) with the
// reference rasteriser, and compares it with the app's picture of the same moment.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Stack;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

static class CardsTest
{
    static readonly Action Noop = () => { };

    // src/web/Preview.js: res, before, after, and each card's props
    static Card Build(string name)
    {
        const float W = 832, H = 384;
        switch (name)
        {
            case "stack-result":
            case "stack-result-stars":
                var res = new StackCards.Result
                {
                    Stars = 2, Coins = 90, Xp = 40, Moves = 9, Par = 7, LevelUps = 1, Unlocked = true, Hinted = false,
                    Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800),
                };
                // Preview.js KEYS: the first three cut-outs (stack/art.js), or ?keys=none: the stars
                return StackCards.ResultCard(W, H, res, false, Noop, Noop, Noop, name == "stack-result" ? new[] { "acorn", "aeroswift", "aurora" } : null);
            case "stack-fail": return StackCards.FailCard(W, H, null, Noop, Noop);
            case "stack-pause": return StackCards.PauseCard(W, H, Noop, Noop);
            case "stack-hint": return StackCards.HintCard(W, H, true, false, Noop, Noop);
        }
        throw new ArgumentException(name);
    }

    public static int Run(string dir, Func<string, string> res)
    {
        Fx.LikeWeb = true;
        // the result's three characters as their grey stills (no live creatures here: the app's moments before they draw)
        TrioItem.Stills = true;
        var ars = new Dictionary<string, float>();
        foreach (var a in JsonDocument.Parse(File.ReadAllText(res("Stack/stack.json"))).RootElement.GetProperty("artList").EnumerateArray())
            ars[a.GetProperty("key").GetString()] = a.GetProperty("ar").GetSingle();
        TrioItem.ArOf = k => ars.TryGetValue(k, out var v) ? v : 1;
        Card.LoadXml = n => File.ReadAllText(res("Cards/" + n + ".xml"));
        string bg = File.ReadAllText(res("Stack/bg.xml"));
        var list = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "cards.json"))).RootElement;
        int worst = 0;
        foreach (var c in list.EnumerateArray())
        {
            var name = c.GetProperty("card").GetString();
            var tk = new Ticker(0);
            Ticker.Default = tk;
            var card = Build(name);
            card.Show();
            foreach (var tEl in c.GetProperty("times").EnumerateArray())
            {
                double ms = tEl.GetDouble();
                while (tk.Now < ms) tk.Tick(Math.Min(tk.Now + 16, ms));
                card.Update();
                if (Environment.GetEnvironmentVariable("CARDS_DEBUG") != null) { var m = card.CardTransform; Console.WriteLine($"  card at {ms}: matrix({m.A} {m.B} {m.C} {m.D} {m.E} {m.F})"); foreach (var l in card.Layers()) Console.WriteLine($"    {l.Name} {l.Transform.E:0.###} {l.Transform.F:0.###} {l.W}x{l.H} o={l.Opacity:0.###}"); }
                var app = Path.Combine(dir, $"{name}-{ms}.png");
                if (!File.Exists(app)) continue;
                var svg = Screen(bg, card);
                File.WriteAllText(Path.Combine(dir, $"{name}-{ms}-unity.svg"), svg);
                double pct = Compare(svg, app, Path.Combine(dir, $"{name}-{ms}-unity.png"), Path.Combine(dir, $"{name}-{ms}-diff.png"), res, out int visible, out int total);
                Console.WriteLine($"{name,-13} {ms,5} ms: {visible,6} of {total} px differ visibly ({pct:0.00} %)");
            }
        }
        return Flow() ? worst : 1;
    }

    // the cards' taps and closing, as StackGame uses them: a tap on a button (down and up on it) presses it, an open card
    // takes taps anywhere, a closing one doesn't; a result card closes empty, a fail card's pops start again as it closes
    static bool Flow()
    {
        var tk = new Ticker(0);
        Ticker.Default = tk;
        void Run(double ms) { double end = tk.Now + ms; while (tk.Now < end) { tk.Tick(Math.Min(tk.Now + 16, end)); } }
        string pressed = null;
        var res = new StackCards.Result { Stars = 3, Coins = 270, Xp = 40, Moves = 7, Par = 7, Before = new XpLevel(6, 560, 700), After = new XpLevel(6, 600, 700) };
        var card = StackCards.ResultCard(832, 384, res, false, () => pressed = "next", () => pressed = "replay", () => pressed = "menu");
        card.Show();
        Run(7200);
        card.Update();
        bool ok = true;
        void Check(bool c, string what) { Console.WriteLine($"  {(c ? "ok  " : "FAIL")} {what}"); ok &= c; }
        CardButton next = null;
        foreach (var b in card.Buttons) if (b.Look.Label.StartsWith("NEXT")) next = b;
        var p = next.Face.Transform.Apply(new Vec2(next.W / 2, next.H / 2));
        Check(card.Down((float)p.X, (float)p.Y), "an open card takes a tap");
        Run(40); card.Update();
        Check(next.Press.T > 0.3, "NEXT squashes while held");
        card.Up((float)p.X, (float)p.Y);
        Check(pressed == "next", "a tap on NEXT presses it");
        pressed = null;
        card.Down(5, 5); card.Up(5, 5);
        Check(pressed == null, "a tap beside the buttons presses nothing");
        int layers = 0; foreach (var _ in card.Layers()) layers++;
        card.Hide(true);
        int empty = 0; foreach (var _ in card.Layers()) empty++;
        Check(empty == 2 && layers > 10 && card.CardW == 380, $"closing, the result card empties at once ({layers} layers -> {empty}, 380 dp wide)");
        Check(!card.Down(400, 200), "a closing card lets taps through");
        Run(200); card.Update();
        Check(!card.Shown, "it's gone 180 ms later");
        var fail = StackCards.FailCard(832, 384, null, () => { }, () => { });
        fail.Show();
        Run(3000); fail.Update();
        float before = 0; foreach (var l in fail.Layers()) if (l.Name == "title") before = l.Opacity;
        fail.Hide();
        Run(16); fail.Update();
        float after = -1; foreach (var l in fail.Layers()) if (l.Name == "title") after = l.Opacity;
        Check(before == 1 && after == 0, "a fail card's title pops again as it closes (trigger={visible})");
        return ok;
    }

    // the page, then each layer as UiPiece shows it: its markup drawn in its box plus its margin, transformed, faded
    static string Screen(string bg, Card card)
    {
        var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        int n = 0;
        sb.Append(Nest(bg, "p" + n++ + "-"));
        foreach (var l in card.Layers())
        {
            if (!l.Visible || l.Opacity <= 0 || l.Markup == null) continue;
            var p = "p" + n++ + "-";
            var m = l.Transform;
            sb.Append($"<defs><clipPath id=\"{p}room\"><rect x=\"{UiSvg.F(-l.Margin)}\" y=\"{UiSvg.F(-l.Margin)}\" width=\"{UiSvg.F(l.W + 2 * l.Margin)}\" height=\"{UiSvg.F(l.H + 2 * l.Margin)}\"/></clipPath></defs>");
            sb.Append($"<g transform=\"matrix({R(m.A)} {R(m.B)} {R(m.C)} {R(m.D)} {R(m.E)} {R(m.F)})\"{(l.Opacity < 1 ? $" opacity=\"{R(Math.Max(0, l.Opacity))}\"" : "")}><g clip-path=\"url(#{p}room)\">{Nest(l.Markup, p)}</g></g>");
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
            byte g = (byte)(ours[i] * 0.3 + 150);
            diff[i] = v ? (byte)255 : g; diff[i + 1] = v ? (byte)0 : g; diff[i + 2] = v ? (byte)60 : g; diff[i + 3] = 255;
        }
        Png.Write(diffPng, W, H, diff);
        return 100.0 * visible / total;
    }
}
