// dotnet run -c Release --project tools/unity/hop-test -- cards <capture dir>   (cards.mjs writes the app's pictures)
// dotnet run -c Release --project tools/unity/hop-test -- cardframes <out dir> [card] [to ms] [every]
//   the card as Unity plays it, frame by frame (every `every`-th 16 ms frame, 1040 x 480 px), the loops running, for a
//   video (the characters as their stills, as in `cards`)
// Builds each Squish Hop card from the Unity code (Games/Hop/HopCards.cs on Ui/Cards) with Preview.js's sample data,
// runs its clock frame by frame as cards.mjs ran the page's (16 ms frames, the last landing on the moment), draws the
// screen (the page behind, then every card layer where it is) with the reference rasteriser, and compares it with the
// app's picture of the same moment.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Hop;
using SquishSquad.Ui.Cards;

static class HopCardsTest
{
    static readonly Action Noop = () => { };

    // src/web/Preview.js: res, before, after, and each card's props
    static Card Build(string name)
    {
        const float W = 832, H = 384;
        switch (name)
        {
            case "hop-result":
            case "hop-result-stars":
                var res = new HopCards.Result
                {
                    Stars = 3, Coins = 90, Xp = 40, Hops = 14, Left = 2, LevelUps = 1, Unlocked = true, Hinted = false,   // (Preview.js: stars 3)
                    Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800),
                };
                // Preview.js KEYS: the first three cut-outs (stack/art.js), or ?keys=none: the stars
                return HopCards.ResultCard(W, H, res, false, Noop, Noop, Noop, name == "hop-result" ? new[] { "acorn", "aeroswift", "aurora" } : null);
            case "hop-stuck": return HopCards.StuckCard(W, H, null, true, Noop);   // (the app shows CAST[0], Acorn: not drawn here)
            case "hop-pause": return HopCards.PauseCard(W, H, Noop, Noop);
            case "hop-hint": return HopCards.HintCard(W, H, true, false, Noop, Noop);
        }
        throw new ArgumentException(name);
    }

    public static int Frames(string dir, string name, double to, int every)
    {
        Directory.CreateDirectory(dir);
        Setup();
        string bg = File.ReadAllText(Program.Res("Stack/bg.xml"));
        var tk = new Ticker(0);
        Ticker.Default = tk;
        var card = Build(name);
        card.Show();
        int f = 0, n = 0;
        for (double ms = 0; ms <= to; ms += 16)
        {
            tk.Tick(ms);
            card.Update();
            if (n++ % every != 0) continue;
            var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
            sb.Append(Program.Nest(bg, "bg-"));
            int k = 0;
            foreach (var l in card.Layers()) Program.Card(sb, l, ref k);
            Program.Render(sb.Append("</svg>").ToString(), Path.Combine(dir, $"frame-{f++:0000}.png"), 1040, 480);
        }
        Console.WriteLine($"{f} frames, one every {every * 16} ms, in {dir}");
        return 0;
    }

    static void Setup()
    {
        // the result's three characters as their grey stills (no live creatures here: the app's moments before they draw)
        TrioItem.Stills = true;
        var ars = new Dictionary<string, float>();
        foreach (var a in JsonDocument.Parse(File.ReadAllText(Program.Res("Stack/stack.json"))).RootElement.GetProperty("artList").EnumerateArray())
            ars[a.GetProperty("key").GetString()] = a.GetProperty("ar").GetSingle();
        TrioItem.ArOf = k => ars.TryGetValue(k, out var v) ? v : 1;
    }

    public static int Run(string dir)
    {
        Setup();
        // the page behind (GameBackground), as Squish Stack's exporter cut it
        string bg = File.ReadAllText(Program.Res("Stack/bg.xml"));
        var list = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "cards.json"))).RootElement;
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
                var app = Path.Combine(dir, $"{name}-{ms}.png");
                if (!File.Exists(app)) continue;
                var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
                sb.Append(Program.Nest(bg, "bg-"));
                int n = 0;
                foreach (var l in card.Layers()) Program.Card(sb, l, ref n);
                var svg = sb.Append("</svg>").ToString();
                File.WriteAllText(Path.Combine(dir, $"{name}-{ms}-unity.svg"), svg);
                var (t, _, _) = Program.Compare(svg, app, Path.Combine(dir, $"{name}-{ms}-unity.png"), Path.Combine(dir, $"{name}-{ms}-diff.png"));
                Console.WriteLine($"{name,-11} {ms,5} ms: {t:0.00} % of the screen differs visibly");
            }
        }
        return 0;
    }
}
