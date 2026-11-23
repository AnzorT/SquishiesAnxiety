// dotnet run -c Release --project tools/unity/hop-test -- cards <capture dir>   (cards.mjs writes the app's pictures)
// Builds each Squish Hop card from the Unity code (Games/Hop/HopCards.cs on Ui/Cards) with Preview.js's sample data,
// runs its clock frame by frame as cards.mjs ran the page's (16 ms frames, the last landing on the moment), draws the
// screen (the page behind, then every card layer where it is) with the reference rasteriser, and compares it with the
// app's picture of the same moment.
using System;
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
                var res = new HopCards.Result
                {
                    Stars = 2, Coins = 90, Xp = 40, Hops = 14, Left = 2, LevelUps = 1, Unlocked = true, Hinted = false,
                    Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800),
                };
                return HopCards.ResultCard(W, H, res, 9, 1, false, "Kitchen", Noop, Noop, Noop);
            case "hop-stuck": return HopCards.StuckCard(W, H, null, null, true, Noop, Noop);
            case "hop-pause": return HopCards.PauseCard(W, H, Noop, Noop, Noop);
            case "hop-hint": return HopCards.HintCard(W, H, true, false, Noop, Noop);
        }
        throw new ArgumentException(name);
    }

    public static int Run(string dir)
    {
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
