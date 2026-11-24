// Squishdoku's own Blitz cards (src/squishdoku/Overlays.js), one wide column each (Overlay `broad`, Ui/Blitz BroadCard);
// develop's Squish Stack Blitz shows them too, with its own `unit` ("puzzle": Game.js):
//   Save   a mistake or the clock ended the run: TIME'S UP! / OOPS!, "Save your run and keep going on board n?", and in a
//          row (each up to 220 dp): SAVE IT (an ad, once a run; free with Remove Ads), SAVE FOR <gem> price (twice the
//          last each time), END RUN
//   Over   GAME OVER: the boards cleared counting up, NEW BEST! or BEST n, what the run paid, the XP bar, QUIT and PLAY
//          AGAIN (190 dp faces, 12 apart)
// The shared Blitz cards (Revive, Fail, Win, Pause) are in Ui/Blitz/BlitzCards.cs. No UnityEngine here.
using System;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdBlitzCards
    {
        /// <summary>The gem's picture (squad/currencyArt.js GEM[0]), Resources path.</summary>
        public const string Gem = "Squishdoku/gem";
        static readonly TextStyle Err = CardArt.Style(CardArt.Heavy, 12, "#e01e4a");
        static readonly TextStyle BigNum = CardArt.Style(CardArt.Display, 40, "#b86200");
        static readonly TextStyle NewBest = CardArt.Style(CardArt.Display, 13, "#16a86a", 0.8f);
        static readonly TextStyle BestPlain = CardArt.Style(CardArt.Display, 13, "#9a6a3a", 0.8f);

        /// <summary>BlitzSaveCard's props.</summary>
        public sealed class SaveState
        {
            public string Reason = "mistake", Unit = "board";
            public int Board = 1, Cleared, Gems, Price = 10;
            public bool AdUsed, AdReady, AdsFree, Saving;
            public string Error;
            /// <summary>What went wrong, over the question (Squish Hop's: "That hop left cushions you can't clear."), or null.</summary>
            public string Why;
        }

        public static BroadCard Save(float screenW, float screenH, SaveState s, Action onAd, Action onGems, Action onEnd)
        {
            var c = new BroadCard(screenW, screenH) { Tint = BlitzCards.Tint, RetriggerOnHide = true };
            bool shortOf = s.Gems < s.Price;
            c.Add(new TitleItem(new CardArt.Title(s.Reason == "time" ? "TIME'S UP!" : "OOPS!", 34, "pink")) { Pop = new PopIn(40) });
            if (s.Why != null) c.Add(new TextItem(s.Why, BlitzCards.SmallText));
            c.Add(new TextItem($"Save your run and keep going on {s.Unit} {s.Board}?", BlitzCards.Body, 6));
            c.Add(new TextItem($"{s.Cleared} {s.Unit}{(s.Cleared == 1 ? "" : "s")} cleared so far", BlitzCards.SmallText));
            c.Add(new ButtonRowItem(10, 10, true, SaveRow(s, onAd, onGems, onEnd)));
            return c;
        }

        /// <summary>The save card's row of buttons for `s` (BlitzSaveCard's saveRow).</summary>
        public static RowButton[] SaveRow(SaveState s, Action onAd, Action onGems, Action onEnd)
        {
            bool shortOf = s.Gems < s.Price;
            var row = new System.Collections.Generic.List<RowButton>();
            // (rowFace: 11 dp above and below, 8 at the sides)
            if (!s.AdUsed)
            {
                var label = s.AdsFree ? "SAVE IT (FREE)" : s.AdReady ? "▶ WATCH AD TO SAVE" : "LOADING AD…";
                row.Add(new RowButton { Flex = true, MaxW = 220, Button = new CardButton(new CardArt.ButtonLook("gold", label, 15, 8, 11) { Disabled = s.Saving || (!s.AdsFree && !s.AdReady) }, onAd) });
            }
            // SAVE FOR <gem> price: the gem (22 dp, 3 dp pulled in either side) makes the face taller than a label alone
            float lb = UiSvg.LineBox(ButtonRowItem.LabelStyle("cyan", 15));
            bool off = s.Saving || shortOf;
            var gemLook = new CardArt.ButtonLook("cyan", s.Saving ? "SAVING…" : "SAVE FOR", 15, 8, s.Saving ? 11 : 11 + Math.Max(0, 22 - lb) / 2) { Disabled = off };
            var gem = new RowButton { Flex = true, MaxW = 220, Button = new CardButton(gemLook, onGems) };
            string kind = off ? "grey" : "cyan", priceKind = shortOf ? "grey" : "cyan";
            if (s.Saving) gem.Face = look => ButtonRowItem.Face(look, "cyan", ("SAVING…", "grey", null, 15, 0));
            else gem.Face = look => ButtonRowItem.Face(look, "cyan", ("SAVE FOR", kind, null, 15, 0), (null, null, Gem, 22, -3), (s.Price.ToString(), priceKind, null, 15, 0));
            if (s.Error != null || shortOf) { gem.Note = s.Error ?? $"You have {s.Gems} gems"; gem.NoteStyle = Err; }
            row.Add(gem);
            row.Add(new RowButton { Flex = true, MaxW = 220, Button = new CardButton(new CardArt.ButtonLook("white", "END RUN", 15, 8, 11) { Disabled = s.Saving }, onEnd) });
            return row.ToArray();
        }

        /// <summary>BlitzOverCard's `res`.</summary>
        public sealed class OverResult
        {
            public int Cleared, Best;
            public bool NewTop;
            public double Coins, Xp;
            public int LevelUps;
            public XpLevel? Before;
            public XpLevel After;
        }

        public static BroadCard Over(float screenW, float screenH, OverResult res, Action onAgain, Action onQuit, string unit = "board")
        {
            var c = new BroadCard(screenW, screenH) { Tint = BlitzCards.TintDeep, RetriggerOnHide = true };
            c.Add(new TitleItem(new CardArt.Title("GAME OVER", 32, res.NewTop ? "gold" : "pink")) { Pop = new PopIn(40, 2.4, -12, 6, 160) });
            c.Add(new TextItem($"{unit.ToUpperInvariant()}S CLEARED", BlitzCards.Sub));
            c.Add(new CountItem(res.Cleared, 300, 700, BigNum, 80));
            c.Add(new TextItem(res.NewTop ? "NEW BEST!" : $"BEST {res.Best}", res.NewTop ? NewBest : BestPlain));
            if (res.Coins != 0) c.Add(new RewardItem(res.Coins, res.Xp, 800, 1000) { Slide = new SlideIn(700, 20) });
            if (res.Xp != 0)
            {
                var xp = new System.Collections.Generic.List<CardItem>();
                CardParts.XpGain(xp, res.Xp, res.Before, res.After, res.LevelUps, 1300);
                foreach (var i in xp) c.Add(i);
            }
            c.Add(new ButtonRowItem(12, 6, false,
                new RowButton { Button = new CardButton(new CardArt.ButtonLook("white", "QUIT", 17, 8, 11, 195), onQuit) },
                new RowButton { Button = new CardButton(new CardArt.ButtonLook("gold", "PLAY AGAIN", 17, 8, 11, 195), onAgain) }) { Slide = new SlideIn(900, 30) });
            return c;
        }
    }
}
