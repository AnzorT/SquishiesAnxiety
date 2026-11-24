// Squish Sort's cards over the game (src/sort/Cards.js), built from the shared card pieces (SquishSquad.Ui.Cards):
//   Result  the win: the title pops, the stars pop in one by one (STEP 480 ms apart), the coins count up, the XP bar
//           fills, LEVEL n! and LEVEL n+1 UNLOCKED pop, the buttons slide in
//   Fail    out of hearts (OH NO!) or out of time (TIME'S UP!): the title and the squishy's head pop, the head rocks
//   Pause   the clock stopped: RESUME / RESTART LEVEL / QUIT
// Every delay is the app's.
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Sort
{
    public static class SortCards
    {
        static readonly string[] TITLES = { "", "SORTED!", "NICE SORTING!", "PERFECT MEMORY!" };
        const double STEP = 480;

        static readonly TextStyle Sub = CardArt.Style(CardArt.Display, 12, "#9a6a3a", 0.6f);
        static readonly TextStyle Hint = CardArt.Style(CardArt.Heavy, 11.5f, "#b86200");
        static readonly TextStyle Unlocked = CardArt.Style(CardArt.Display, 13, "#16a86a", 0.8f);
        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);

        static CardButton Small(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 15, 14, 10), a);
        static CardButton Big(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 18, 22, 12), a);
        static CardButton Wide(string kind, string label, float size, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12), a);

        /// <summary>What the result shows (Game.js win()).</summary>
        public sealed class Result
        {
            public int Stars, Mistakes, LevelUps;
            public double Coins, Xp, Ms;
            public XpLevel? Before;
            public XpLevel After;
            public bool Unlocked;
        }

        /// <summary>The win. `last`: level 50, no NEXT.</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, int lv, int tier, double parMs, bool last, Action onNext, Action onReplay, Action onHub)
        {
            var c = new Card(screenW, screenH);
            double coinsAt = 380 + 3 * STEP + 200;
            var L = c.Left;
            L.Add(new TitleItem(new CardArt.Title(TITLES[res.Stars], res.Stars == 3 ? 27 : 30, res.Stars == 3 ? "gold" : "pink")) { Pop = new PopIn(80) });
            var mist = res.Mistakes > 0 ? $" · {res.Mistakes} MISTAKE{(res.Mistakes > 1 ? "S" : "")}" : " · NO MISTAKES";
            L.Add(new TextItem($"LEVEL {lv} · {Levels.TIER_NAMES[tier]} · {Levels.Clock(res.Ms)}{mist}", Sub));
            if (res.Stars < 3 && res.Mistakes == 0) L.Add(new TextItem($"Under {Levels.Clock(parMs)} for 3 stars!", Hint));
            L.Add(new StarsItem(res.Stars, 380, STEP));
            var R = c.Right;
            R.Add(new RewardItem(res.Coins, res.Xp, coinsAt) { Slide = new SlideIn(coinsAt - 150, 20) });
            CardParts.XpGain(R, res.Xp, res.Before, res.After, res.LevelUps, coinsAt + 500);
            if (res.Unlocked) R.Add(new TextItem($"LEVEL {lv + 1} UNLOCKED", Unlocked) { Pop = new PopIn(coinsAt + 500) });
            var buttons = new List<CardButton> { Small("white", "MENU", onHub), Small("purple", "REPLAY", onReplay) };
            if (!last) buttons.Add(Big("green", "NEXT ▶", onNext));
            R.Add(new ButtonsItem(false, buttons.ToArray()) { Slide = new SlideIn(380 + 2 * STEP + 300, 30) });
            return c;
        }

        /// <summary>Out of hearts (`reason` "hearts") or of time ("time"); `picture`: the first squishy (its head), or null.</summary>
        public static Card FailCard(float screenW, float screenH, string reason, string picture, Action onRetry, Action onHub)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true };
            bool time = reason == "time";
            c.Left.Add(new TitleItem(new CardArt.Title(time ? "TIME'S UP!" : "OH NO!", 32, "gold")) { Pop = new PopIn(60) });
            c.Left.Add(new HeadItem(86, picture, "#ffffff", "#efe9f5", true, new Rock(8, 1800)) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem(time ? "The clock ran out. You saw where they go. Try again!" : $"{Levels.HEARTS} mistakes. You saw where they go. Try again!", Body, 6));
            c.Right.Add(new ButtonsItem(false, Small("white", "MENU", onHub), Big("pink", "RETRY", onRetry)) { Slide = new SlideIn(380) });
            return c;
        }

        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onRestart, Action onQuit)
        {
            var c = new Card(screenW, screenH);
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 30, "gold")));
            c.Left.Add(new TextItem("The clock is stopped.", Body, 6));
            c.Right.Add(new ButtonsItem(true, Wide("green", "RESUME", 18, onResume), Wide("purple", "RESTART LEVEL", 16, onRestart), Wide("white", "QUIT", 16, onQuit)));
            return c;
        }
    }
}
