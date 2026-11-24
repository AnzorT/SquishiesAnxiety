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
        public static readonly string[] RESULT_TITLES = { "SORTED!", "NICE SORTING!", "PERFECT MEMORY!" };


        /// <summary>What the result shows (Game.js win()).</summary>
        public sealed class Result
        {
            public int Stars, Mistakes, LevelUps;
            public double Coins, Xp, Ms;
            public XpLevel? Before;
            public XpLevel After;
            public bool Unlocked;
        }

        /// <summary>The win (the shared card). `last`: level 50, no NEXT.</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, bool last, Action onNext, Action onReplay, Action onHub) =>
            GameCards.ResultCard(screenW, screenH, new GameCards.Result { Stars = res.Stars, Coins = res.Coins, Xp = res.Xp, Before = res.Before, After = res.After, LevelUps = res.LevelUps },
                RESULT_TITLES, last, onHub, onReplay, onNext);

        /// <summary>Out of hearts (`reason` "hearts") or of time ("time"); `picture`: the first squishy (its head), or null.</summary>
        public static Card FailCard(float screenW, float screenH, string reason, string picture, Action onRetry, Action onHub)
        {
            bool time = reason == "time";
            return GameCards.FailCard(screenW, screenH, time ? "TIME'S UP!" : "OH NO!", 32, "gold", picture, "#efe9f5",
                time ? "The clock ran out. You saw where they go. Try again!" : $"{Levels.HEARTS} mistakes. You saw where they go. Try again!", "MENU", onHub, onRetry);
        }

        /// <summary>The shared pause card: RESUME / QUIT.</summary>
        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onQuit) => GameCards.PauseCard(screenW, screenH, onResume, onQuit);
    }
}
