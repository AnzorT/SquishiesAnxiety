// The mini-games' shared cards, as the app has them on develop (src/squishdoku/Overlays.js; the user, 2026-11-16/17:
// "one result card for all of them", "less text, UI not text", one pause card for every game and Blitz, the fail cards'
// two buttons the same size with RETRY in the app's gold). Every one is a `column` card (Card.Column): the title and
// picture on top, the rest under them.
//   ResultCard  the title, three live characters (TrioItem; without them the stars, Squishdoku its score creatures and
//               PERFECT's stamp) popping in, the coins
//               counting up (×3 on a perfect), the XP bar with LEVEL n! beside it, MENU (Squishdoku: MAP) and REPLAY
//               white and NEXT ▶ gold, the three 100 x 48. No line of numbers, no "… for 3 stars", no LEVEL n UNLOCKED.
//   PauseCard   PAUSED, RESUME (gold) and QUIT (white) down the card: no body text, no RESTART.
//   FailCard    a title and a rocking head, a line, MENU / MAP (white) and RETRY (gold), each 150 wide.
// Each game keeps its words (its titles, its fail lines) in its own *Cards.cs.
using System;
using System.Collections.Generic;

namespace SquishSquad.Ui.Cards
{
    public static class GameCards
    {
        /// <summary>A level's win: `res` of ResultCard.</summary>
        public sealed class Result
        {
            public int Stars, LevelUps;
            public bool Perfect;
            public double Coins, Xp;
            public XpLevel? Before;
            public XpLevel After;
        }

        static readonly TextStyle Body = CardArt.Style(CardArt.Heavy, 14, CardArt.INK);

        /// <summary>trioFace: 100 x 48, the label 16 (a 105 dp ring around the face).</summary>
        public static CardButton Trio(string kind, string label, Action a) =>
            new CardButton(new CardArt.ButtonLook(kind, label, 16, 4, 0, 105) { FaceHeight = 48 }, a);
        /// <summary>pairFace: 150 wide, 8 x 11 in, the label 17.</summary>
        public static CardButton Pair(string kind, string label, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, 17, 8, 11, 155), a);
        /// <summary>wideFace: as wide as the card's column, 12 dp above and below the label.</summary>
        public static CardButton Wide(string kind, string label, float size, Action a) => new CardButton(new CardArt.ButtonLook(kind, label, size, 18, 12), a);

        /// <summary>The stars' moments without the characters (Overlays.js T0 / STEP when `keys` aren't drawn): the first star
        /// at 380 ms, then every 480; the coins 200 ms after the third; the buttons 300 ms after it.</summary>
        public const double StarsT0 = 380, StarsStep = 480;

        /// <summary>The one result card. `titles`: the 1, 2 and 3 star titles; `perfectTitle`: Squishdoku's perfect solve
        /// (PERFECT SQUISH!); `score`: what stands where the stars do (null: the three stars), with `scoreTop` (it's the top
        /// result: the title in gold) and its moments `coinsAt` / `buttonsAt`; `reward`: the coins row (null: the shared
        /// one); `last`: level 50, no NEXT; `keys`: the three characters' rig keys (Trio.js trioOf; null: the stars).</summary>
        public static Card ResultCard(float screenW, float screenH, Result res, string[] titles, bool last, Action onBack, Action onReplay, Action onNext,
            string backLabel = "MENU", string perfectTitle = null, CardItem score = null, bool? scoreTop = null, double? coinsAt = null, double? buttonsAt = null,
            Func<double, CardItem> reward = null, string[] keys = null)
        {
            var c = new Card(screenW, screenH) { Column = true };
            bool top = scoreTop ?? res.Stars == 3;
            string title = res.Perfect && perfectTitle != null ? perfectTitle : titles[Math.Max(0, Math.Min(titles.Length - 1, res.Stars - 1))];
            c.Left.Add(new TitleItem(new CardArt.Title(title, title.Length > 13 ? 27 : 30, top ? "gold" : "pink")) { Pop = new PopIn(80) });
            // since 2026-11-17 three live characters stand where the stars do (`keys`: TrioItem); the coins and the XP
            // then wait for them (`after(ms)`), the buttons come 1500 ms after the card opens
            string mode = TrioItem.ModeFor(keys);
            bool rigs = mode != null, stamp = rigs && res.Perfect && perfectTitle != null;
            if (rigs) c.Left.Add(new TrioItem(keys, res.Stars, TrioT0, TrioStep, mode == "live", ok => c.Go(), stamp));
            else c.Left.Add(score ?? new StarsItem(res.Stars, StarsT0, StarsStep));
            double cAt = rigs ? TrioT0 + 3 * TrioStep + (stamp ? 500 : 0) : coinsAt ?? StarsT0 + 3 * StarsStep + 200;
            var R = c.Right;
            var row = reward != null ? reward(cAt) : new RewardItem(res.Coins, res.Xp, cAt);
            row.Slide = new SlideIn(cAt - 150, 20);
            row.Waits = rigs;
            R.Add(row);
            int n = R.Count;
            CardParts.XpGainCompact(R, res.Xp, res.Before, res.After, res.LevelUps, cAt + 500);
            for (int i = n; i < R.Count; i++) R[i].Waits = rigs;
            var buttons = new List<CardButton> { Trio("white", backLabel, onBack), Trio("white", "REPLAY", onReplay) };
            if (!last) buttons.Add(Trio("gold", "NEXT ▶", onNext));
            R.Add(new ButtonsItem(false, buttons.ToArray()) { Slide = new SlideIn(rigs ? 1500 : buttonsAt ?? StarsT0 + 2 * StarsStep + 300, 30) });
            return c;
        }

        /// <summary>The characters' moments (Overlays.js T0 / STEP with `rigs`): the first fills 420 ms after the run
        /// starts, then every 760; the coins after the third.</summary>
        public const double TrioT0 = 420, TrioStep = 760;

        /// <summary>Trio.js trioOf: three rig keys for a result, `want`'s with any missing ones topped up from `pool` (no
        /// repeats while there are others), or null with none at all.</summary>
        public static string[] TrioOf(IList<string> want, IEnumerable<string> pool = null)
        {
            var used = new HashSet<string>();
            foreach (var k in want) if (!string.IsNullOrEmpty(k)) used.Add(k);
            var spare = new List<string>();
            if (pool != null) foreach (var k in pool) if (!string.IsNullOrEmpty(k) && !used.Contains(k) && !spare.Contains(k)) spare.Add(k);
            var o = new string[3];
            string any = null;
            for (int i = 0; i < 3; i++)
            {
                string w = i < want.Count ? want[i] : null;
                if (string.IsNullOrEmpty(w) && spare.Count > 0) { w = spare[0]; spare.RemoveAt(0); }
                o[i] = string.IsNullOrEmpty(w) ? null : w;
                any ??= o[i];
            }
            if (any == null) return null;
            for (int i = 0; i < 3; i++) o[i] ??= any;
            return o;
        }

        /// <summary>The one pause card (every game, Regular and Blitz).</summary>
        public static Card PauseCard(float screenW, float screenH, Action onResume, Action onQuit)
        {
            var c = new Card(screenW, screenH) { Column = true };
            c.Left.Add(new TitleItem(new CardArt.Title("PAUSED", 30, "gold")));
            c.Right.Add(new ButtonsItem(true, Wide("gold", "RESUME", 18, onResume), Wide("white", "QUIT", 16, onQuit)));
            return c;
        }

        /// <summary>The one fail card (Squish Hop's STUCK!, every game's since 2026-11-26): `title` (`size`, `fill`), the
        /// character of `picture` (its cut-out, a Resources path) whole and sad, live once its rig draws (SadBodyItem),
        /// `line`, then `backLabel` (white; none: null) and RETRY (gold).</summary>
        public static Card FailCard(float screenW, float screenH, string title, float size, string fill, string picture, string line,
            string backLabel, Action onBack, Action onRetry)
        {
            var c = new Card(screenW, screenH) { Tint = "rgba(80,0,30,0.5)", RetriggerOnHide = true, Column = true };
            c.Left.Add(new TitleItem(new CardArt.Title(title, size, fill)) { Pop = new PopIn(60) });
            c.Left.Add(new SadBodyItem(picture) { Pop = new PopIn(220) });
            c.Right.Add(new TextItem(line, Body, 6));
            var b = new List<CardButton>();
            if (backLabel != null) b.Add(Pair("white", backLabel, onBack));
            b.Add(Pair("gold", "RETRY", onRetry));
            c.Right.Add(new ButtonsItem(false, b.ToArray()) { Slide = new SlideIn(380) });
            return c;
        }
    }
}
