// Squish Hop's HUD down the left (src/hop/Game.js hudEl and stripEl, sideways: the column is only as wide as its goal
// card needs, leftW; padding 8 / 10, gap 8): the Crib's top bar (the back button is its own piece; src/crib/Hud.js
// RoomTitle, the tier chip under it; Blitz: "Blitz Mode" alone) and the brown glass strip: the goal card (the cushions
// still to clear with their count, the friends' stickers, ›, the ★ cushion), the stars still possible and the BEAT pill
// (Blitz: CLEARED, BEST and BEAT; wrapping). (No "SQUISH HOP · LEVEL n" line, LEFT / HOPS pills or tip since
// 2026-11-17, the user.) The arrow keys at the column's bottom are HopLevel's. Positions are what Chrome lays out
// (tools/unity/hop-test). Units are dp.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Hop
{
    public static class HopHud
    {
        const string INK = "#5b3a29";
        static string F(double v) => UiSvg.F(v);

        static readonly TextStyle TierText = new TextStyle { Font = "Fredoka_700Bold", Size = 9.5f, LetterSpacing = 0.6f, Color = "#ffffff" };
        static readonly TextStyle GoalLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, LetterSpacing = 1.2f, Color = "#6b3fa0" };
        static readonly TextStyle GoalArrow = new TextStyle { Font = "Fredoka_700Bold", Size = 14, Color = "#b9a6cc" };
        static readonly TextStyle PillText = new TextStyle { Font = "Fredoka_700Bold", Size = 12, LetterSpacing = 0.5f, Color = "#b86200" };
        static readonly TextStyle SlotNum = new TextStyle { Font = "Fredoka_700Bold", Size = 8.5f, Color = "#ffffff" };
        static readonly TextStyle BadgeText = new TextStyle { Font = "Fredoka_700Bold", Size = 11, Color = "#ffffff" };

        /// <summary>What the HUD shows.</summary>
        public sealed class Hud
        {
            public string Room;          // the room's name
            public int Tier, Stars, NextBeat;
            public bool Beats, Dance;
            public int Friends;          // slots in the goal card
            public int ToOpen;           // cushions still to clear before the ★ opens (✓ at 0; the mini ★ is shut while > 0)
            // BLITZ MODE: "Blitz Mode" with no tier chip, the boards cleared and the best run (gold NEW BEST once it's
            // beaten) in place of the stars
            public bool Blitz, BestBeaten;
            public int Cleared, Best;
        }

        // ---- the column's width --------------------------------------------------------------------------------------
        public static float SlotSize(int n) => n > 4 ? 19 : n > 2 ? 21 : n > 1 ? 24 : 27;
        // Game.js goalCardW: its two cushions, the friends and the › with the row's 3-point gaps, then its padding and border
        static float GoalCardW(int n, float slot) => Math.Max(104, 36 * 2 + n * slot + 8 + (n + 2) * 3 + 16);
        /// <summary>Game.js leftW (2026-11-21: only as wide as the goal card needs, so the board gets the room; Blitz keeps
        /// one width for the run).</summary>
        public static float LeftW(bool blitz, bool beats, int n) => blitz ? 230 : 10 + Math.Max(beats ? 186 : 156, GoalCardW(n, SlotSize(n)) + 16);

        // ---- where things are ------------------------------------------------------------------------------------------
        // the top bar: the back button (48 x 52) and the title box (RoomTitle 40.89 tall, the tier chip's row -2 under it,
        // 15 tall) side by side, centred on each other
        const float TitleH = 40.890625f;
        static float BarH(bool blitz) => blitz ? 52 : TitleH - 2 + 15;
        /// <summary>The back button's top.</summary>
        public static float BackY(bool blitz) => 8 + (BarH(blitz) - 52) / 2;
        static float TitleY(bool blitz) => 8 + (BarH(blitz) - (blitz ? TitleH : BarH(blitz))) / 2;
        /// <summary>The glass strip's top (8 under the bar, marginTop 4).</summary>
        static float StripY(bool blitz) => 8 + BarH(blitz) + 8 + 4;
        /// <summary>Where the goal card is (its top-left; inside the strip's 2 dp border and 6 dp padding), and its size.</summary>
        public const float GoalX = 18, GoalH = 64;
        public static float GoalY(bool blitz) => StripY(blitz) + 8;
        public static float GoalW(float leftW) => leftW - 10 - 16;

        // ---- the top bar ---------------------------------------------------------------------------------------------
        /// <summary>RoomTitle: Fredoka 26, a cream-to-peach gradient in a brown outline with a deeper drop (its svg at x, y).</summary>
        public static void RoomTitle(UiSvg s, float x, float y, string title)
        {
            const float size = 26, pad = 4, ls = 0.5f;
            var font = UiFont.Get("Fredoka_700Bold");
            double k = size / font.UnitsPerEm;
            float baseline = pad + size * 0.92f;
            // the fill's gradient spans the text's box (objectBoundingBox): the font's ascent above the baseline to its
            // descent below, in the glyphs' own units (y up from the baseline)
            double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
            var id = s.NewId("rt");
            s.Def($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\"><stop offset=\"0\" stop-color=\"#fffaf0\"/><stop offset=\"0.6\" stop-color=\"#ffe6b8\"/><stop offset=\"1\" stop-color=\"#ffcf80\"/></linearGradient>");
            string stroke = $"stroke=\"{INK}\" stroke-width=\"{F(5 / k)}\" stroke-linejoin=\"round\"";
            s.Glyphs(title, x + pad, y + baseline + 3, "Fredoka_700Bold", size, ls, INK, stroke);
            s.Glyphs(title, x + pad, y + baseline, "Fredoka_700Bold", size, ls, INK, stroke);
            s.Glyphs(title, x + pad, y + baseline, "Fredoka_700Bold", size, ls, $"url(#{id})");
        }

        // ---- the column ------------------------------------------------------------------------------------------------
        /// <summary>The column's svg width: the title runs on past the column (over the board, as on the phone).</summary>
        public static float SvgW(float leftW) => leftW + 260;

        /// <summary>The column without the back button, the goal card, the BEAT pill (it shakes on its own: `beat` is where it
        /// goes) and the arrow keys (their own pieces), SvgW x `h`.</summary>
        public static string Column(Hud d, float leftW, float h, out (float x, float y) beat)
        {
            beat = (0, 0);
            (float, float) beatAt = (0, 0);
            var s = new UiSvg(SvgW(leftW), h);
            // the top bar's title box: x 66 = 10 padding + 48 button + 8 gap
            float ty = TitleY(d.Blitz);
            RoomTitle(s, 66, ty, d.Room);
            if (!d.Blitz)
            {
                // the tier chip (paddingH 6, a 2 dp white border)
                float subY = ty + TitleH - 2;
                var tier = Levels.TIER_NAMES[d.Tier];
                float chipW = UiSvg.BoxWidth(tier, TierText) + 2 * 6 + 2 * 2;
                s.Box(66, subY, chipW, 15, new BoxStyle { Background = Levels.TIER_COLORS[d.Tier], Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(tier, 66 + 2 + 6, subY + 2, TierText);
            }

            // the strip's right part (under the goal card, 8 dp): the meter row, wrapping
            float rx = GoalX, ry = GoalY(d.Blitz) + GoalH + 8, rw = GoalW(leftW);
            var items = new List<(float w, float h, Action<float, float> draw)>();
            if (d.Blitz)
            {
                items.Add(Pill(s, $"CLEARED {d.Cleared}", "#ffd23a", PillText));
                items.Add(Pill(s, $"{(d.BestBeaten ? "NEW BEST" : "BEST")} {d.Best}", d.BestBeaten ? "#ffffff" : "#ffe6b8",
                    new TextStyle { Font = PillText.Font, Size = PillText.Size, LetterSpacing = PillText.LetterSpacing, Color = d.BestBeaten ? "#ffffff" : INK }, d.BestBeaten ? "#ffb02e" : "#ffffff"));
            }
            else items.Add((64, 24, (x, y) => Meter(s, x, y, d.Stars)));
            if (d.Beats) { var (bw, bh, _) = BeatPill(s, d.NextBeat); items.Add((bw, bh, (x, y) => beatAt = (x, y))); }
            // flex-wrap: items 6 apart, each centred in its line, lines 6 apart
            float y = ry;
            int i0 = 0;
            while (i0 < items.Count)
            {
                float lw = items[i0].w, lh = items[i0].h;
                int i1 = i0 + 1;
                while (i1 < items.Count && lw + 6 + items[i1].w <= rw + 0.01f) { lw += 6 + items[i1].w; lh = Math.Max(lh, items[i1].h); i1++; }
                float x = rx;
                for (int i = i0; i < i1; i++) { items[i].draw(x, y + (lh - items[i].h) / 2); x += items[i].w + 6; }
                y += lh;
                i0 = i1;
                if (i0 < items.Count) y += 6;
            }
            beat = beatAt;
            // the glass strip behind it all (drawn first: inserted under)
            float top = StripY(d.Blitz);
            var glass = new UiSvg(SvgW(leftW), h).Box(10, top, leftW - 10, y + 6 + 2 - top, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            var m = s.Markup;
            var gm = glass.Markup;
            int a = gm.IndexOf("</defs>") + 7, b = gm.LastIndexOf("</svg>");
            int at = m.IndexOf("</defs>") + 7;
            return m.Substring(0, at) + gm.Substring(a, b - a) + m.Substring(at);
        }

        // a pill: paddingH 8, paddingV 1, a 2 dp border (Chrome draws 2.5 as 2)
        static (float, float, Action<float, float>) Pill(UiSvg s, string text, string border, TextStyle t, string bg = "#ffffff")
        {
            float w = UiSvg.BoxWidth(text, t) + 2 * 8 + 2 * 2, h = UiSvg.LineBox(t) + 2 + 4;
            return (w, h, (x, y) =>
            {
                s.Box(x, y, w, h, new BoxStyle { Background = bg, Radius = 999, BorderWidth = 2, BorderColor = border });
                s.Text(text, x + 2 + 8, y + 2 + 1, t);
            });
        }

        /// <summary>Game.js BeatPill on its own (it shakes when a hop bumps an unlit tile): its markup, w x h.</summary>
        public static string BeatPillSvg(int next, out float w, out float h)
        {
            var probe = new UiSvg(1, 1);
            var (pw, ph, _) = BeatPill(probe, next);
            var s = new UiSvg(pw, ph);
            BeatPill(s, next).Item3(0, 0);
            w = pw; h = ph;
            return s.Markup;
        }

        // Game.js BeatPill: BEAT and the next three beats' colours, the next one big
        static (float, float, Action<float, float>) BeatPill(UiSvg s, int next)
        {
            var t = new TextStyle { Font = PillText.Font, Size = PillText.Size, LetterSpacing = PillText.LetterSpacing, Color = "#8a3a0e" };
            float tw = UiSvg.BoxWidth("BEAT", t), lh = UiSvg.LineBox(t);
            float inner = Math.Max(lh, 13);
            float w = tw + 4 + 13 + 4 + 9 + 4 + 9 + 2 * 8 + 2 * 2, h = inner + 2 + 4;
            return (w, h, (x, y) =>
            {
                s.Box(x, y, w, h, new BoxStyle { Background = "#ffffff", Radius = 999, BorderWidth = 2, BorderColor = "#ff5c8a" });
                float cx = x + 2 + 8, cy = y + 3;
                s.Text("BEAT", cx, cy + (inner - lh) / 2, t);
                cx += tw + 4;
                for (int k = 0; k < 3; k++)
                {
                    float d = k == 0 ? 13 : 9;
                    var col = HopArt.BEAT_COL[(next + k) % 3];
                    s.Box(cx, cy + (inner - d) / 2, d, d, k == 0 ? new BoxStyle { Background = col, Radius = 3, BorderWidth = 2, BorderColor = "#ffffff" } : new BoxStyle { Background = col, Radius = 3, Opacity = 0.5f });
                    cx += d + 4;
                }
            });
        }

        // Game.js Meter: three stars (19, 24, 19 dp; the small ones 3 dp lower), gap 1
        static void Meter(UiSvg s, float x, float y, int stars)
        {
            float cx = x;
            for (int i = 0; i < 3; i++)
            {
                float size = i == 1 ? 24 : 19, top = y + (i == 1 ? 0 : 3);
                bool on = i < stars;
                s.Raw($"<svg x=\"{F(cx)}\" y=\"{F(top)}\" width=\"{F(size)}\" height=\"{F(size)}\" viewBox=\"0 0 24 24\" overflow=\"visible\"><path d=\"{HopArt.STAR_D}\" fill=\"{(on ? "#ffd23a" : "rgba(255,255,255,0.55)")}\" stroke=\"{(on ? "#b86200" : "#b9a6cc")}\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></svg>");
                cx += size + 1;
            }
        }

        // ---- the goal card ---------------------------------------------------------------------------------------------
        /// <summary>Where slot k's box is in the goal card (its top-left), with `n` slots, the card `w` wide.</summary>
        public static (float x, float y) SlotAt(int n, int k, float w)
        {
            float size = SlotSize(n);
            return (RowX(n, w) + 36 + 3 + k * (size + 3), 19 + (38 - size) / 2);
        }

        // "›" in Fredoka Bold (its glyph is missing from Resources/Fonts/Fredoka_700Bold.json, which only has the
        // characters the menu needed): its outline and advance in 1000 units per em
        const string ARROW_D = "M42 28Q18 52 14 69.5Q10 87 22 104Q34 121 56 143L157 244L55 345Q35 367 23 383.5Q11 400 14.5 418Q18 436 42 460Q65 483 82.5 491Q100 499 117.5 492.5Q135 486 156 465L319 303Q334 288 340.5 274Q347 260 347 244Q347 228 340.5 213.5Q334 199 319 184L158 24Q138 4 120.5 -3.5Q103 -11 84.5 -3Q66 5 42 28Z";
        static float ArrowW => 0.36f * GoalArrow.Size;

        // goalRow: the cushions-left cushion, the friends, ›, the ★ cushion, 3 apart, centred in the card (its border 3 and
        // paddingH 5)
        static float RowX(int n, float w)
        {
            float size = SlotSize(n);
            float rowW = 36 + 3 + n * (size + 3) + ArrowW + 3 + 36;
            return Card.Snap(3 + 5 + (w - 16 - rowW) / 2);
        }

        /// <summary>The goal card (w x GoalH) without its stickers: GOAL; the cushions still to clear (a lilac cushion, or
        /// the Dance Room's mint tile, with their count on a purple badge, a green ✓ once they're gone); ›; the ★ cushion
        /// with the ★ (shut while cushions are left).</summary>
        public static string GoalCard(Hud d, float w)
        {
            var s = new UiSvg(w, GoalH);
            s.Box(0, 0, w, GoalH, new BoxStyle { Background = "rgba(255,255,255,0.95)", Radius = 15, BorderWidth = 3, BorderColor = "#ffffff" });
            s.Text("GOAL", 3, 4, GoalLabel, w - 6, 0.5f);
            int n = d.Friends;
            float x = RowX(n, w);
            // miniGoal 36 x 38: the flat cushion (or the dance tile) centred
            void Mini(float mx, string col, string id, string tile)
            {
                if (d.Dance) s.Box(mx + 3, 19 + 4, 30, 30, new BoxStyle { Background = tile, Radius = 5, BorderWidth = 2, BorderColor = "#140818" });
                else s.Raw(HopArt.FlatCushion(mx + 1, 19 + (38 - 34 * 1.06) / 2, 34, col, id));
            }
            Mini(x, "lilac", "hopLeft", "#5cf2c8");
            // leftBadge: right -4, top -3; at least 20 x 20, paddingH 3, a 2 dp white border
            {
                string t = d.ToOpen == 0 ? "✓" : d.ToOpen.ToString(CultureInfo.InvariantCulture);
                float bw = Math.Max(20, UiSvg.BoxWidth(t, BadgeText) + 2 * 3 + 2 * 2);
                float bx = x + 36 + 4 - bw, by = 19 - 3;
                s.Box(bx, by, bw, 20, new BoxStyle { Background = d.ToOpen == 0 ? "#16a86a" : "#6b3fa0", Radius = 10, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(t, bx + 2 + 3, by + 2 + (16 - UiSvg.LineBox(BadgeText)) / 2, BadgeText, bw - 10, 0.5f);
            }
            x += 36 + 3 + n * (SlotSize(n) + 3);
            {
                float k = GoalArrow.Size / 1000, baseline = UiSvg.Baseline(GoalArrow, 19 + (38 - UiSvg.LineBox(GoalArrow)) / 2);
                s.Raw($"<path d=\"{ARROW_D}\" fill=\"{GoalArrow.Color}\" transform=\"translate({F(x)} {F(baseline)}) scale({F(k)} {F(-k)})\"/>");
                x += ArrowW + 3;
            }
            Mini(x, "peach", "hopMini", "#ffffff");
            s.Raw(HopArt.StarAt(x + 8.5, 19 + 7, 19, d.ToOpen > 0));
            return s.Markup;
        }

        /// <summary>Game.js Slot: a friend's head in a sticker, dim until it's picked up, with its number on in-order levels
        /// (the number's chip hangs 5 dp out at the top right). `head`: its happy head, or null for its still
        /// (`picture`) in ui.js Head.</summary>
        public static string Slot(float size, string head, string picture, bool got, int n)
        {
            var s = new UiSvg(size, size);
            if (head != null)
            {
                s.Box(0, 0, size, size, new BoxStyle { Background = got ? "#ffffff" : "rgba(255,255,255,0.55)", Radius = size / 2 });
                float inner = size - 4;
                s.Box(2, 2, inner, inner, new BoxStyle { Background = got ? "#f6efff" : "rgba(255,255,255,0.35)", Radius = 999 });
                var clip = s.NewId("sc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(2, 2, inner, inner, new[] { 999f, 999, 999, 999 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                float iw = inner * 0.94f;
                s.Image(head, 2 + (inner - iw) / 2, 2 + (inner - iw) / 2, iw, iw, "xMidYMid meet", got ? 1 : 0.28f);
                s.Close();
            }
            else CardArt.Head(s, 0, 0, size, picture, dim: !got);
            if (n > 0)
            {
                var t = n.ToString(CultureInfo.InvariantCulture);
                float w = Math.Max(14, UiSvg.BoxWidth(t, SlotNum) + 2 * 2 + 2 * 1);
                float x = size + 5 - w;
                s.Box(x, -5, w, 14, new BoxStyle { Background = "#ff8a3d", Radius = 7, BorderWidth = 1, BorderColor = "#ffffff" });
                s.Text(t, x + 1 + 2, -5 + 1 + (12 - UiSvg.LineBox(SlotNum)) / 2, SlotNum, w - 6, 0.5f);
            }
            return s.Markup;
        }
    }
}
