// The Blitz cards the games share (src/squishdoku/Overlays.js, used by Squish Stack's and Squish Sort's Blitz too), on
// the shared card kit (Ui/Cards), every delay and spring the app's:
//   Revive   OOPS!: a mistake with the revive unused; REVIVE (an ad, or free with Remove Ads) or BACK TO <UNIT> 1
//   Fail     BACK TO <UNIT> 1!: the run's over (a mistake, or the clock); GO AGAIN / QUIT
//   Win      BLITZ CHAMPION!: every round cleared; the three creatures pop in, the coins count up, the XP bar, confetti
//   Pause    PAUSED (the Blitz variant): RESUME / START OVER / QUIT
// `unit` is what one step of the run is called: "board" (Squishdoku), "puzzle" (Squish Stack), "round" (Squish Sort).
// Each returns a Ui/Cards Card: show it with Show(), close it with Hide(), place it with Update(), draw Layers(), feed
// it Down / Up (see Ui/Cards/Card.cs).
using System;
using System.Globalization;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Ui.Blitz
{
    public static class BlitzCards
    {
        public static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);
        public static readonly TextStyle SmallText = CardArt.Style(CardArt.Bold, 12, "#9a6a3a");
        public static readonly TextStyle Sub = CardArt.Style(CardArt.Display, 12.5f, "#9a6a3a", 0.6f);
        public const string Tint = "rgba(80,0,30,0.5)", TintDeep = "rgba(80,0,30,0.55)";

        // the card styles' faces: smallFace 14 x 10, bigFace 22 x 12, wideFace 18 (SdButton's own) x 12
        public static CardButton Small(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 15, 14, 10), a);
        public static CardButton Big(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 18, 22, 12), a);
        public static CardButton Wide(string kind, string label, float size, Action a, bool disabled = false) =>
            new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12) { Disabled = disabled }, a);

        /// <summary>Where a lost run goes back to: Squishdoku's says level, the others their unit.</summary>
        public static string BackTo(string unit) => unit == "board" ? "BACK TO LEVEL 1" : $"BACK TO {unit.ToUpperInvariant()} 1";

        /// <summary>fx.js / levels.js clock: 1:05.</summary>
        public static string Clock(double ms)
        {
            double s = Math.Max(0, Math.Ceiling(ms / 1000));
            return Math.Floor(s / 60).ToString(CultureInfo.InvariantCulture) + ":" + (s % 60).ToString("00", CultureInfo.InvariantCulture);
        }

        /// <summary>ReviveCard: a mistake on step `board` of the run, the one revive still there.</summary>
        public static Card Revive(float screenW, float screenH, int board, string unit, bool adReady, bool adsFree, Action onRevive, Action onGiveUp)
        {
            var c = new Card(screenW, screenH) { Tint = Tint, RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("OOPS!", 34, "pink")) { Pop = new PopIn(40) });
            c.Left.Add(new TextItem($"That's a mistake. Keep your run going on {unit} {board}?", Body, 6));
            c.Left.Add(new TextItem("One revive per run", SmallText));
            var label = adsFree ? "REVIVE (FREE)" : adReady ? "▶ WATCH AD TO REVIVE" : "LOADING AD…";
            c.Right.Add(new ButtonsItem(true, Wide("gold", label, 17, onRevive, !adsFree && !adReady), Wide("white", BackTo(unit), 15, onGiveUp)));
            return c;
        }

        /// <summary>BlitzFailCard: the run's over (`reason` "mistake" or "time") on step `reached`; `best` the record.</summary>
        public static Card Fail(float screenW, float screenH, string reason, int reached, int best, string unit, Action onAgain, Action onQuit)
        {
            var c = new Card(screenW, screenH) { Tint = TintDeep, RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title($"{BackTo(unit)}!", 26, "pink")) { Pop = new PopIn(40, 2.4, -12, 6, 160) });
            c.Left.Add(new TextItem(reason == "time" ? "The Blitz clock ran out." : "One mistake sends the whole squad home.", Body, 6));
            c.Left.Add(new TextItem($"You reached {unit} {reached} · best {Math.Max(best, reached)}", SmallText));
            c.Right.Add(new ButtonsItem(true, Wide("cyan", "GO AGAIN", 18, onAgain), Wide("white", "QUIT", 15, onQuit)));
            return c;
        }

        /// <summary>BlitzWinCard's `res`: the run's time, what it paid, and the player's XP before / after.</summary>
        public sealed class WinResult
        {
            public double Ms, Coins, Xp;
            public bool NewBest;
            public int LevelUps;
            public XpLevel? Before;
            public XpLevel After;
            /// <summary>The three creatures (Resources paths, or null).</summary>
            public string[] Pictures = new string[3];
        }

        /// <summary>BlitzWinCard: all `rounds` steps cleared (10 in Squish Stack's and Squish Sort's Blitz).</summary>
        public static Card Win(float screenW, float screenH, WinResult res, string unit, Action onAgain, Action onQuit, int rounds = 10)
        {
            var c = new Card(screenW, screenH) { RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("BLITZ CHAMPION!", 26, "gold")) { Pop = new PopIn(60) });
            c.Left.Add(new TextItem($"{rounds} {unit.ToUpperInvariant()}S · {Clock(res.Ms)}{(res.NewBest ? " · NEW BEST!" : "")}", Sub));
            c.Left.Add(new HeadsItem(3, res.Pictures, 300, 300));
            var reward = new RewardItem(res.Coins, res.Xp, 1400, 1100) { Slide = new SlideIn(1300, 20) };
            c.Right.Add(reward);
            CardParts.XpGain(c.Right, res.Xp, res.Before, res.After, res.LevelUps, 1900);
            c.Right.Add(new ButtonsItem(false, Small("white", "DONE", onQuit), Big("cyan", "AGAIN", onAgain)) { Slide = new SlideIn(1700, 30) });
            // the FxLayer over the right column: three confetti bursts as it opens
            c.Right.Add(new ColumnFx(reward, (0, "confetti", 60, 40, 1), (450, "confetti", 140, 40, 1), (900, "confetti", 220, 40, 1)));
            return c;
        }

        /// <summary>PauseCard `blitz`: the Blitz clock frozen.</summary>
        public static Card Pause(float screenW, float screenH, Action onResume, Action onRestart, Action onQuit)
        {
            var c = new Card(screenW, screenH) { RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 32, "pink")) { Pop = new PopIn(40) });
            c.Left.Add(new TextItem("The Blitz clock is frozen. Take a breath!", Body, 6));
            c.Right.Add(new ButtonsItem(true, Wide("green", "RESUME", 18, onResume), Wide("purple", "START OVER", 16, onRestart), Wide("white", "QUIT", 16, onQuit)));
            return c;
        }
    }
}
