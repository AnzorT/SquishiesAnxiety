// Squish Hop's cards over the game (src/hop/Cards.js), built from the shared card pieces (SquishSquad.Ui.Cards):
//   Result  the win: the title pops, the stars pop in one by one (STEP 480 ms apart), the coins count up, the XP bar
//           fills, LEVEL n!, "LEVEL n+1 UNLOCKED · ROOM" (or NEXT: ...) pops, the buttons slide in
//   Stuck   nowhere left to hop: the title and the hopper's sad head pop, the head rocks; UNDO / RETRY
//   Pause   RESUME / RESTART / LEVELS
//   Hint    the hint costs an ad (free with Remove Ads) and one star
// Every delay is the app's. (How to play, RulesCard, is the level map's, not the level's: not here.)
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Hop
{
    public static class HopCards
    {
        public static readonly string[] RESULT_TITLES = { "CLEARED!", "NICE HOPPING!", "PERFECT HOPS!" };

        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);
        static readonly TextStyle Cost = CardArt.Style(CardArt.Display, 13, "#e01e4a");

        static CardButton Wide(string kind, string label, float size, Action a, bool disabled = false) =>
            new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12) { Disabled = disabled }, a);

        /// <summary>What the result shows (Game.js win()).</summary>
        public sealed class Result
        {
            public int Stars, Hops, Left;
            public double Coins, Xp;
            public XpLevel? Before;
            public XpLevel After;
            public int LevelUps;
            public bool Hinted, Unlocked;
        }

        /// <summary>The win (the shared card, src/hop/Cards.js RESULT_TITLES). `last`: level 100, no NEXT.</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, bool last, Action onNext, Action onReplay, Action onHub) =>
            GameCards.ResultCard(screenW, screenH, new GameCards.Result { Stars = res.Stars, Coins = res.Coins, Xp = res.Xp, Before = res.Before, After = res.After, LevelUps = res.LevelUps },
                RESULT_TITLES, last, onHub, onReplay, onNext);

        /// <summary>Nowhere left to hop (a column card). `who`: the hopper, shown whole (SadSquishy: its cut-out, the app's
        /// live rig crying over it once drawn; Unity shows the cut-out, as the app does while the rig loads), or null;
        /// `shut`: the ★ is next to it but still shut. RETRY only (no UNDO since 2026-11-17, the user).</summary>
        public static Card StuckCard(float screenW, float screenH, HopSquishy who, bool shut, Action onRetry)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true, Column = true };
            c.Left.Add(new TitleItem(new CardArt.Title("STUCK!", 32, "gold")) { Pop = new PopIn(60) });
            c.Left.Add(new SadBodyItem(who) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem(shut ? "The ★ stays shut until every other cushion is cleared, and there is nowhere else to hop." : "There is nowhere left to hop.", Body, 6));
            c.Right.Add(new ButtonsItem(false, GameCards.Pair("gold", "RETRY", onRetry)) { Slide = new SlideIn(380) });
            return c;
        }

        /// <summary>The shared pause card: RESUME / QUIT.</summary>
        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onQuit) => GameCards.PauseCard(screenW, screenH, onResume, onQuit);

        /// <summary>A hint costs an ad (free with Remove Ads) and one star off this level; asked the first time in a level.</summary>
        public static Card HintCard(float screenW, float screenH, bool adReady, bool adsFree, Action onWatch, Action onClose)
        {
            var c = new Card(screenW, screenH);
            c.Left.Add(new TitleItem(new CardArt.Title("NEED A HINT?", 28, "gold")));
            c.Left.Add(new TextItem(adsFree ? "We'll show you the next hop." : "Watch a short ad and we'll show you the next hop.", Body, 6));
            c.Left.Add(new TextItem("This level gives one star less", Cost));
            var watch = new CardButton(new CardArt.ButtonLook("gold", adsFree ? "SHOW ME" : adReady ? "▶ WATCH AD" : "LOADING AD…", 17, 18, 12) { Disabled = !adsFree && !adReady }, onWatch);
            c.Right.Add(new ButtonsItem(true, watch, Wide("white", "NO THANKS", 15, onClose)));
            return c;
        }

        /// <summary>Cards.js SadSquishy: a 150 x 128 box, the hopper's body 84 wide standing 6 dp above its bottom, centred
        /// (stack/Pieces.js Squishy: a still's margins hang outside the body).</summary>
        public sealed class SadBodyItem : CardItem
        {
            readonly HopSquishy _who;
            readonly CardLayer _layer;

            public SadBodyItem(HopSquishy who) { _who = who; _layer = Layer("sad squishy"); }
            public override bool IsStatic => false;
            public override void Measure(float colW)
            {
                W = 150; H = 128;
                var s = new UiSvg(W, H);
                if (_who != null && _who.Picture != null)
                {
                    const float w = 84;
                    float sw = w / (_who.Box[2] - _who.Box[0]), sh = sw * _who.Ar, bh = _who.BodyH(w);
                    float bx = (W - w) / 2, by = H - 6 - bh;
                    s.Image(_who.Picture, bx - _who.Box[0] * sw, by - _who.Box[1] * sh, sw, sh, "none");
                }
                _layer.Set(s.Markup, W, H, 2);
            }
        }
    }
}
