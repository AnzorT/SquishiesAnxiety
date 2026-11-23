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
        static readonly string[] TITLES = { "", "HOPPED!", "NICE HOPPING!", "ALL CLEAR!" };
        const double STEP = 480;

        static readonly TextStyle Sub = CardArt.Style(CardArt.Display, 12, "#9a6a3a", 0.6f);
        static readonly TextStyle Hint = CardArt.Style(CardArt.Heavy, 11.5f, "#b86200");
        static readonly TextStyle Unlocked = CardArt.Style(CardArt.Display, 12.5f, "#16a86a", 0.6f);
        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);
        static readonly TextStyle Cost = CardArt.Style(CardArt.Display, 13, "#e01e4a");

        static CardButton Small(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 15, 14, 10), a);
        static CardButton Big(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 18, 22, 12), a);
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

        /// <summary>The win. `nextRoom`: the next level's room's name (null on the last level).</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, int lv, int tier, bool dance, string nextRoom, Action onNext, Action onReplay, Action onHub)
        {
            var c = new Card(screenW, screenH);
            double coinsAt = 380 + 3 * STEP + 200;
            bool last = lv >= Levels.LEVELS;
            string what = dance ? "tile" : "cushion";
            var L = c.Left;
            L.Add(new TitleItem(new CardArt.Title(TITLES[res.Stars], res.Stars == 3 ? 30 : 28, res.Stars == 3 ? "gold" : "pink")) { Pop = new PopIn(80) });
            L.Add(new TextItem($"LEVEL {lv} · {Levels.TIER_NAMES[tier]} · {res.Hops} HOPS · {res.Left} LEFT{(res.Hinted ? " · HINT" : "")}", Sub));
            if (res.Left > 0 && !res.Hinted) L.Add(new TextItem($"Clear every {what} before the ★ for 3 stars!", Hint));
            if (res.Hinted) L.Add(new TextItem("A hint costs one star", Hint));
            L.Add(new StarsItem(res.Stars, 380, STEP));
            var R = c.Right;
            R.Add(new RewardItem(res.Coins, res.Xp, coinsAt) { Slide = new SlideIn(coinsAt - 150, 20) });
            CardParts.XpGain(R, res.Xp, res.Before, res.After, res.LevelUps, coinsAt + 500);
            string room = (nextRoom ?? "").ToUpperInvariant();
            string next = last ? "YOU HOPPED THROUGH THE WHOLE CRIB!" : res.Unlocked ? $"LEVEL {lv + 1} UNLOCKED · {room}" : $"NEXT: LEVEL {lv + 1} · {room}";
            R.Add(new TextItem(next, Unlocked) { Pop = new PopIn(coinsAt + 500) });
            var buttons = new List<CardButton> { Small("white", "MENU", onHub), Small("purple", "REPLAY", onReplay) };
            if (!last) buttons.Add(Big("green", "NEXT ▶", onNext));
            R.Add(new ButtonsItem(false, buttons.ToArray()) { Slide = new SlideIn(380 + 2 * STEP + 300, 30) });
            return c;
        }

        /// <summary>Nowhere left to hop. `sadHead`: the hopper's sad head (Resources path) or null, then `picture` its
        /// still in a dim sticker; `shut`: the ★ is next to it but still shut.</summary>
        public static Card StuckCard(float screenW, float screenH, string sadHead, string picture, bool shut, Action onUndo, Action onRetry)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("STUCK!", 32, "gold")) { Pop = new PopIn(60) });
            var rock = new Rock(8, 1800);
            c.Left.Add(sadHead != null ? (CardItem)new SadHeadItem(sadHead, rock) { Pop = new PopIn(220) } : new HeadItem(86, picture, "#ffffff", "#efe9f5", true, rock) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem(shut ? "The ★ is shut until every friend is with you, and there is nowhere else to hop." : "There is nowhere left to hop.", Body, 6));
            c.Right.Add(new ButtonsItem(false, Small("white", "UNDO", onUndo), Big("pink", "RETRY", onRetry)) { Slide = new SlideIn(380) });
            return c;
        }

        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onRestart, Action onQuit)
        {
            var c = new Card(screenW, screenH);
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 30, "gold")));
            c.Right.Add(new ButtonsItem(true, Wide("green", "RESUME", 18, onResume), Wide("purple", "RESTART", 16, onRestart), Wide("white", "LEVELS", 16, onQuit)));
            return c;
        }

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

        /// <summary>Cards.js StuckCard's sad head: an 86 dp white circle, 5 dp in a cream one, the head 92 % of it
        /// (contain), rocking.</summary>
        public sealed class SadHeadItem : CardItem
        {
            readonly string _head;
            readonly Rock _rock;
            readonly CardLayer _layer;

            public SadHeadItem(string head, Rock rock) { _head = head; _rock = rock; _layer = Layer("sad head"); }
            public override bool IsStatic => false;
            public override void Measure(float colW)
            {
                W = H = 86;
                var s = new UiSvg(W, H);
                s.Box(0, 0, 86, 86, new BoxStyle { Background = "#ffffff", Radius = 43 });
                s.Box(5, 5, 76, 76, new BoxStyle { Background = "#f3e6d4", Radius = 40 });
                var clip = s.NewId("sh");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(5, 5, 76, 76, new float[] { 40, 40, 40, 40 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                float iw = 76 * 0.92f;
                s.Image(_head, 5 + (76 - iw) / 2, 5 + (76 - iw) / 2, iw, iw, "xMidYMid meet");
                s.Close();
                _layer.Set(s.Markup, W, H, 2);
            }
            public override void Mount() => _rock.Mount();
            public override void Unmount() { base.Unmount(); _rock.Unmount(); }
            public override void Place(Affine card, float opacity)
            {
                var (m, o) = Box(card, opacity);
                _layer.Transform = m * _rock.Local(W, H);
                _layer.Opacity = o;
            }
        }
    }
}
