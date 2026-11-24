// dotnet run -c Release --project tools/unity/sort-test -- cards <capture dir>   (cards.mjs writes the app's pictures)
// Builds each Squish Sort card from the Unity code (Games/Sort/SortCards.cs on Ui/Cards) with Preview.js's sample data,
// runs its clock frame by frame as cards.mjs ran the page's (16 ms frames, the last landing on the moment), draws the
// screen (the page behind, then every card layer) with the reference rasteriser, and compares it with the app's picture
// of the same moment.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Sort;
using SquishSquad.Ui.Cards;

static class CardsTest
{
    static readonly Action Noop = () => { };

    // src/web/Preview.js: res, before, after, and each card's props
    static Card Build(string name)
    {
        const float W = 832, H = 384;
        switch (name)
        {
            case "sort-result":
            case "sort-result-stars":
                var res = new SortCards.Result
                {
                    Stars = 2, Coins = 90, Xp = 40, Mistakes = 0, Ms = 83000, LevelUps = 1, Unlocked = true,
                    Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800),
                };
                // Preview.js KEYS: the first three cut-outs (stack/art.js), or ?keys=none: the stars
                return SortCards.ResultCard(W, H, res, false, Noop, Noop, Noop, name == "sort-result" ? new[] { "acorn", "aeroswift", "aurora" } : null);
            case "sort-fail": return SortCards.FailCard(W, H, "hearts", null, Noop, Noop);
            case "sort-pause": return SortCards.PauseCard(W, H, Noop, Noop);
        }
        throw new ArgumentException(name);
    }

    public static int Run(string dir)
    {
        // the result's three characters as their grey stills (no live creatures here: the app's moments before they draw)
        TrioItem.Stills = true;
        var ars = new Dictionary<string, float>();
        foreach (var a in JsonDocument.Parse(File.ReadAllText(Program.Res("Stack/stack.json"))).RootElement.GetProperty("artList").EnumerateArray())
            ars[a.GetProperty("key").GetString()] = a.GetProperty("ar").GetSingle();
        TrioItem.ArOf = k => ars.TryGetValue(k, out var v) ? v : 1;
        string bg = File.ReadAllText(Program.Res("Sort/bg.xml"));
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
                var (visible, total) = Render.Compare(bg, new SortLayer[0], new[] { card }, app, Path.Combine(dir, $"{name}-{ms}-unity.png"), Path.Combine(dir, $"{name}-{ms}-diff.png"));
                Console.WriteLine($"{name,-12} {ms,5} ms: {visible,6} of {total} px differ visibly ({100.0 * visible / total:0.00} %)");
            }
        }
        return 0;
    }
}
