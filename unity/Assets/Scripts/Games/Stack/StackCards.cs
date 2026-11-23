// Squish Stack's cards over the game (src/stack/Cards.js), built from the shared card pieces (SquishSquad.Ui.Cards):
//   Result  the win: the title pops, the stars pop in one by one (STEP 480 ms apart), the coins count up, the XP bar
//           fills, LEVEL n! and LEVEL n+1 UNLOCKED pop, the buttons slide in
//   Fail    time's up: the title and the squishy's head pop, the head rocks
//   Pause   the clock stopped: RESUME / NEW PUZZLE / QUIT
//   Hint    the hint costs an ad (free with Remove Ads) and one star
// Every delay is the app's.
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Stack
{
    public static class StackCards
    {
        static readonly string[] TITLES = { "", "STACKED!", "NICE STACKING!", "PERFECT STACK!" };
        const double STEP = 480;

        static readonly TextStyle Sub = CardArt.Style(CardArt.Display, 12, "#9a6a3a", 0.6f);
        static readonly TextStyle Hint = CardArt.Style(CardArt.Heavy, 11.5f, "#b86200");
        static readonly TextStyle Unlocked = CardArt.Style(CardArt.Display, 13, "#16a86a", 0.8f);
        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);
        static readonly TextStyle Cost = CardArt.Style(CardArt.Display, 13, "#e01e4a");

        // the cards' button faces (Cards.js styles)
        static CardButton Small(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 15, 14, 10), a);
        static CardButton Big(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 18, 22, 12), a);
        static CardButton Wide(string kind, string label, float size, Action a, bool disabled = false) =>
            new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12) { Disabled = disabled }, a);

        /// <summary>What the result shows (Game.js win()).</summary>
        public sealed class Result
        {
            public int Stars, Moves, Par;
            public double Coins, Xp;
            public XpLevel? Before;
            public XpLevel After;
            public int LevelUps;
            public bool Hinted, Unlocked;
        }

        /// <summary>The win. `last`: level 50, no NEXT.</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, int lv, int tier, bool last, Action onNext, Action onReplay, Action onHub)
        {
            var c = new Card(screenW, screenH);
            double coinsAt = 380 + 3 * STEP + 200;
            var L = c.Left;
            L.Add(new TitleItem(new CardArt.Title(TITLES[res.Stars], res.Stars == 3 ? 27 : 30, res.Stars == 3 ? "gold" : "pink")) { Pop = new PopIn(80) });
            L.Add(new TextItem($"LEVEL {lv} · {Levels.TIER_NAMES[tier]} · {res.Moves} MOVES · PAR {res.Par}{(res.Hinted ? " · HINT" : "")}", Sub));
            if (res.Stars < 3 && !res.Hinted) L.Add(new TextItem($"Do it in {res.Par} moves for 3 stars!", Hint));
            if (res.Hinted) L.Add(new TextItem("A hint costs one star", Hint));
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

        /// <summary>The clock ran out. `picture`: the squishy whose head shows (Resources path), or null.</summary>
        public static Card FailCard(float screenW, float screenH, string picture, Action onRetry, Action onHub)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("TIME'S UP!", 32, "gold")) { Pop = new PopIn(60) });
            c.Left.Add(new HeadItem(86, picture, "#ffffff", "#efe9f5", true, new Rock(8, 1800)) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem("The clock ran out before the stack was done. Try again!", Body, 6));
            c.Right.Add(new ButtonsItem(false, Small("white", "MENU", onHub), Big("pink", "RETRY", onRetry)) { Slide = new SlideIn(380) });
            return c;
        }

        public static Card PauseCard(float screenW, float screenH, bool clock, Action onResume, Action onRestart, Action onQuit)
        {
            var c = new Card(screenW, screenH);
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 30, "gold")));
            if (clock) c.Left.Add(new TextItem("The clock is stopped.", Body, 6));
            c.Right.Add(new ButtonsItem(true, Wide("green", "RESUME", 18, onResume), Wide("purple", "NEW PUZZLE", 16, onRestart), Wide("white", "QUIT", 16, onQuit)));
            return c;
        }

        /// <summary>A hint costs an ad (free with Remove Ads) and one star off this level; asked the first time in a level.</summary>
        public static Card HintCard(float screenW, float screenH, bool adReady, bool adsFree, Action onWatch, Action onClose)
        {
            var c = new Card(screenW, screenH);
            c.Left.Add(new TitleItem(new CardArt.Title("NEED A HINT?", 28, "gold")));
            c.Left.Add(new TextItem(adsFree ? "We'll show you the next best move." : "Watch a short ad and we'll show you the next best move.", Body, 6));
            c.Left.Add(new TextItem("This level gives one star less", Cost));
            var watch = new CardButton(new CardArt.ButtonLook("gold", adsFree ? "SHOW ME" : adReady ? "▶ WATCH AD" : "LOADING AD…", 17, 18, 12) { Disabled = !adsFree && !adReady }, onWatch);
            c.Right.Add(new ButtonsItem(true, watch, Wide("white", "NO THANKS", 15, onClose)));
            return c;
        }
    }
}
