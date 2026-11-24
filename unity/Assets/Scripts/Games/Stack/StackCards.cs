// Squish Stack's cards over the game (src/stack/Cards.js), built from the shared card pieces (SquishSquad.Ui.Cards):
//   Result  the shared result card (Ui/Cards/GameCards.cs): the stars, coins, XP, MENU / REPLAY / NEXT ▶
//   Fail    time's up (GameCards.FailCard)
//   Pause   the shared pause card: RESUME / QUIT
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
        public static readonly string[] RESULT_TITLES = { "STACKED!", "NICE STACKING!", "PERFECT STACK!" };

        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);
        static readonly TextStyle Cost = CardArt.Style(CardArt.Display, 13, "#e01e4a");

        // the cards' button faces (Cards.js styles)
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

        /// <summary>The win (the shared card, src/stack/Cards.js RESULT_TITLES). `last`: level 50, no NEXT; `keys`: its three
        /// characters (Trio.js trioOf).</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, bool last, Action onNext, Action onReplay, Action onHub, string[] keys = null) =>
            GameCards.ResultCard(screenW, screenH, new GameCards.Result { Stars = res.Stars, Coins = res.Coins, Xp = res.Xp, Before = res.Before, After = res.After, LevelUps = res.LevelUps },
                RESULT_TITLES, last, onHub, onReplay, onNext, keys: keys);

        /// <summary>The clock ran out (Blitz's old clock; develop's Squish Stack has none: see UNITY_SYNC_DEVELOP.md).</summary>
        public static Card FailCard(float screenW, float screenH, string picture, Action onRetry, Action onHub) =>
            GameCards.FailCard(screenW, screenH, "TIME'S UP!", 32, "gold", picture, "#efe9f5", "The clock ran out before the stack was done. Try again!", "MENU", onHub, onRetry);

        /// <summary>The shared pause card: RESUME / QUIT.</summary>
        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onQuit) => GameCards.PauseCard(screenW, screenH, onResume, onQuit);

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
