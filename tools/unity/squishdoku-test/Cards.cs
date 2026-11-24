// Squishdoku's cards from the Unity code (Games/Squishdoku/SdCards.cs on Ui/Cards) with src/web/Preview.js's sample data,
// run frame by frame as cards.mjs ran the page (16 ms frames, the last landing on the moment), drawn over the page behind
// (Preview's GameBackground: Squish Stack's exported bg) and compared with the app's picture of the same moment.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;

static class CardsTest
{
    static readonly Action Noop = () => { };

    // Preview.js: res (2 stars, a mistake, 1:23, LEVEL 7!) and best (PERFECT, HEAD START), uris all null
    static Card Build(string name)
    {
        const float W = 832, H = 384;
        var before = new XpLevel(6, 560, 700);
        var res = new SdCards.Result { Stars = 2, Perfect = false, Ms = 83000, Mistakes = 1, LevelCoins = 90, Xp = 40, LevelUps = 1, Unlocked = true, Before = before, After = new XpLevel(7, 40, 800) };
        switch (name)
        {
            // Preview.js KEYS: the first three cut-outs (stack/art.js), or ?keys=none: the score creatures
            case "sd-result": return SdCards.ResultCard(W, H, res, new string[3], false, Noop, Noop, Noop, new[] { "acorn", "aeroswift", "aurora" });
            case "sd-result-stars": return SdCards.ResultCard(W, H, res, new string[3], false, Noop, Noop, Noop);
            case "sd-perfect":
                var best = new SdCards.Result { Stars = 3, Perfect = true, Ms = 83000, Mistakes = 0, LevelCoins = 270, Xp = 40, LevelUps = 1, Unlocked = true, Before = before, After = new XpLevel(7, 40, 800) };
                return SdCards.ResultCard(W, H, best, new string[3], false, Noop, Noop, Noop);
            case "sd-timeup": return SdCards.TimeUpCard(W, H, 0, null, Noop, Noop);
            case "sd-hearts": return SdCards.TimeUpCard(W, H, 3, null, Noop, Noop);
            case "sd-pause": return SdCards.PauseCard(W, H, Noop, Noop);
            // Preview.js: the shared Blitz cards (unit "board")
            case "sd-revive": return BlitzCards.Revive(W, H, 4, "board", true, false, Noop, Noop);
            case "sd-blitzfail": return BlitzCards.Fail(W, H, "mistake", 4, 6, "board", Noop, Noop);
            case "sd-blitzwin":
                return BlitzCards.Win(W, H, new BlitzCards.WinResult { Ms = 412000, Coins = 600, Xp = 120, NewBest = true, LevelUps = 0, Before = before, After = new XpLevel(6, 680, 700) }, "board", Noop, Noop);
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
        var bg = new SdLayer("page").Set(File.ReadAllText(Program.Res("Stack/bg.xml")), 832, 384, 0);
        var mirrors = new Dictionary<CardLayer, SdLayer>();
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
                var layers = new List<SdLayer> { bg };
                foreach (var l in card.Layers()) layers.Add(SdLayer.Mirror(l, mirrors));
                var svg = Program.Screen(layers);
                File.WriteAllText(Path.Combine(dir, $"{name}-{ms}-unity.svg"), svg);
                double pct = Program.Compare(svg, app, Path.Combine(dir, $"{name}-{ms}-unity.png"), Path.Combine(dir, $"{name}-{ms}-diff.png"), out int visible, out int total);
                Console.WriteLine($"{name,-11} {ms,5} ms: {visible,6} of {total} px differ visibly ({pct:0.00} %)");
            }
        }
        return 0;
    }
}
