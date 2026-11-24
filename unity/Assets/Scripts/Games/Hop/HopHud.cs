// Squish Hop's HUD down the left (src/hop/Game.js hudEl and stripEl, landscape: REDESIGN_V8's 250 dp column, padding
// 8 / 10, gap 8): the Crib's top bar (the back button is its own piece; src/crib/Hud.js RoomTitle, "SQUISH HOP · LEVEL
// n" cut short with an ellipsis, the tier chip) and the brown glass strip: the goal card (the friends' stickers, ›, the
// ★ cushion), the stars meter, LEFT, HOPS and BEAT pills (wrapping), and the tip (three lines always). Positions are
// what Chrome lays out (tools/unity/hop-test). Units are dp.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Hop
{
    public static class HopHud
    {
        public const float LeftW = 250;
        const string INK = "#5b3a29";
        static string F(double v) => UiSvg.F(v);

        static readonly TextStyle Sub = new TextStyle { Font = "Nunito_800ExtraBold", Size = 11, LetterSpacing = 0.6f, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 1, 1.5f) } };
        static readonly TextStyle TierText = new TextStyle { Font = "Fredoka_700Bold", Size = 9.5f, LetterSpacing = 0.6f, Color = "#ffffff" };
        static readonly TextStyle GoalLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, LetterSpacing = 1.2f, Color = "#6b3fa0" };
        static readonly TextStyle GoalArrow = new TextStyle { Font = "Fredoka_700Bold", Size = 14, Color = "#b9a6cc" };
        static readonly TextStyle PillText = new TextStyle { Font = "Fredoka_700Bold", Size = 12, LetterSpacing = 0.5f, Color = "#b86200" };
        static readonly TextStyle SlotNum = new TextStyle { Font = "Fredoka_700Bold", Size = 8.5f, Color = "#ffffff" };
        static readonly TextStyle Tip = new TextStyle { Font = "Nunito_800ExtraBold", Size = 12, LineHeight = 15, Color = "#ffffff" };

        /// <summary>What the HUD shows.</summary>
        public sealed class Hud
        {
            public string Room;          // the room's name
            public int Lv, Tier, Stars, Left, Hops, NextBeat;
            public bool Beats, Dance, TipWarn;
            public string Tip;
            public int Friends;          // slots in the goal card
            public int LeftToOpen;       // friends still to land in it (the mini ★ is shut while > 0)
            // BLITZ MODE: "Blitz Mode" with no tier line, the boards cleared and the best run (gold NEW BEST once it's
            // beaten) in place of the stars, LEFT and HOPS, and no tip
            public bool Blitz, BestBeaten;
            public int Cleared, Best;
        }

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

        /// <summary>Chrome's text-overflow: ellipsis: the longest start of `text` that fits `maxW` with "…" after it.</summary>
        public static string Ellipsize(string text, TextStyle t, float maxW)
        {
            if (UiSvg.Width(text, t) <= maxW + 0.01f) return text;
            float ell = UiSvg.Width("…", t);
            for (int n = text.Length - 1; n > 0; n--)
                if (UiSvg.Width(text.Substring(0, n), t) + ell <= maxW + 0.01f) return text.Substring(0, n) + "…";
            return "…";
        }

        // ---- the column ------------------------------------------------------------------------------------------------
        /// <summary>Where the goal card is (its top-left) and the glass strip's height.</summary>
        public const float GoalX = 30, GoalY = 81.890625f, GoalW = 200, GoalH = 64;

        /// <summary>The column without the back button and the goal card (their own pieces), 250 x `h`.</summary>
        public static string Column(Hud d, float h)
        {
            var s = new UiSvg(LeftW, h);
            // the top bar's title box: x 66 = 10 padding + 48 button + 8 gap, 53.89 tall from y 8
            RoomTitle(s, 66, 8, d.Room);
            float subY = 8 + 40.890625f - 2;
            if (!d.Blitz)
            {
                var tier = Levels.TIER_NAMES[d.Tier];
                float chipW = UiSvg.BoxWidth(tier, TierText) + 2 * 6 + 2 * 2;
                string full = $"SQUISH HOP · LEVEL {d.Lv}";
                float room = 184 - 6 - chipW;
                float subW = Math.Min(UiSvg.BoxWidth(full, Sub), room);
                s.Text(Ellipsize(full, Sub, room), 66, subY, Sub);
                float chipX = 66 + subW + 6;
                s.Box(chipX, subY, chipW, 15, new BoxStyle { Background = Levels.TIER_COLORS[d.Tier], Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(tier, chipX + 2 + 6, subY + 2, TierText);
            }

            // the strip's right part (under the goal card, 8 dp): the meter row, wrapping, then the tip
            float rx = 30, ry = GoalY + GoalH + 8, rw = 200;
            var items = new List<(float w, float h, Action<float, float> draw)>();
            if (d.Blitz)
            {
                items.Add(Pill(s, $"CLEARED {d.Cleared}", "#ffd23a", PillText));
                items.Add(Pill(s, $"{(d.BestBeaten ? "NEW BEST" : "BEST")} {d.Best}", d.BestBeaten ? "#ffffff" : "#ffe6b8",
                    new TextStyle { Font = PillText.Font, Size = PillText.Size, LetterSpacing = PillText.LetterSpacing, Color = d.BestBeaten ? "#ffffff" : INK }, d.BestBeaten ? "#ffb02e" : "#ffffff"));
            }
            else
            {
                items.Add((64, 24, (x, y) => Meter(s, x, y, d.Stars)));
                items.Add(Pill(s, $"LEFT {d.Left}", "#ffd23a", PillText));
                items.Add(Pill(s, $"HOPS {d.Hops}", "#ffe6b8", new TextStyle { Font = PillText.Font, Size = PillText.Size, LetterSpacing = PillText.LetterSpacing, Color = INK }));
            }
            if (d.Beats) items.Add(BeatPill(s, d.NextBeat));
            // flex-wrap: lines of items 6 apart, each item centred in its line, lines 6 apart
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
            // the tip: three lines always (numberOfLines 3), 5 dp under the meter row (Blitz: none)
            float tipY = y + 5;
            if (!d.Blitz)
            {
                var tip = new TextStyle { Font = Tip.Font, Size = Tip.Size, LineHeight = Tip.LineHeight, Color = d.TipWarn ? "#ffd0d6" : "#ffffff" };
                var lines = CardArt.Wrap(d.Tip ?? "", tip, rw);
                if (lines.Count > 3) { lines[2] = Ellipsize(string.Join(" ", lines.GetRange(2, lines.Count - 2)), tip, rw); lines.RemoveRange(3, lines.Count - 3); }
                for (int i = 0; i < lines.Count; i++) s.Text(lines[i], rx, tipY + i * 15, tip);
            }
            float bottom = d.Blitz ? y : tipY + 45;
            // the glass strip behind it all (drawn first: inserted under)
            var glass = new UiSvg(LeftW, h).Box(22, 73.890625f, 216, bottom + 6 + 2 - 73.890625f, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
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
        public static float SlotSize(int n) => n > 4 ? 19 : n > 2 ? 21 : n > 1 ? 24 : 27;

        /// <summary>Where slot k's box is in the goal card (its top-left), with `n` slots.</summary>
        public static (float x, float y) SlotAt(int n, int k)
        {
            float size = SlotSize(n);
            float x0 = RowX(n);
            return (x0 + k * (size + 3), 19 + (38 - size) / 2);
        }

        // "›" in Fredoka Bold (its glyph is missing from Resources/Fonts/Fredoka_700Bold.json, which only has the
        // characters the menu needed): its outline and advance in 1000 units per em
        const string ARROW_D = "M42 28Q18 52 14 69.5Q10 87 22 104Q34 121 56 143L157 244L55 345Q35 367 23 383.5Q11 400 14.5 418Q18 436 42 460Q65 483 82.5 491Q100 499 117.5 492.5Q135 486 156 465L319 303Q334 288 340.5 274Q347 260 347 244Q347 228 340.5 213.5Q334 199 319 184L158 24Q138 4 120.5 -3.5Q103 -11 84.5 -3Q66 5 42 28Z";
        static float ArrowW => 0.36f * GoalArrow.Size;

        static float RowX(int n)
        {
            float size = SlotSize(n);
            float rowW = (n > 0 ? n * size + 3 * n + ArrowW + 3 : 0) + 36;
            return Card.Snap(3 + 5 + (184 - rowW) / 2);
        }

        /// <summary>The goal card (GoalW x GoalH) without its stickers: GOAL, ›, the ★ cushion with the ★ (shut while
        /// friends are still to land).</summary>
        public static string GoalCard(Hud d)
        {
            var s = new UiSvg(GoalW, GoalH);
            s.Box(0, 0, GoalW, GoalH, new BoxStyle { Background = "rgba(255,255,255,0.95)", Radius = 15, BorderWidth = 3, BorderColor = "#ffffff" });
            s.Text("GOAL", 3, 4, GoalLabel, GoalW - 6, 0.5f);
            int n = d.Friends;
            float x = RowX(n) + (n > 0 ? n * (SlotSize(n) + 3) : 0);
            if (n > 0)
            {
                float k = GoalArrow.Size / 1000, baseline = UiSvg.Baseline(GoalArrow, 19 + (38 - UiSvg.LineBox(GoalArrow)) / 2);
                s.Raw($"<path d=\"{ARROW_D}\" fill=\"{GoalArrow.Color}\" transform=\"translate({F(x)} {F(baseline)}) scale({F(k)} {F(-k)})\"/>");
                x += ArrowW + 3;
            }
            // miniGoal 36 x 38: the flat cushion (or the dance tile) centred, the ★ at 8.5, 7
            if (d.Dance) s.Box(x + 3, 19 + 4, 30, 30, new BoxStyle { Background = "#ffffff", Radius = 5, BorderWidth = 2, BorderColor = "#140818" });
            else s.Raw(HopArt.FlatCushion(x + 1, 19 + (38 - 34 * 1.06) / 2, 34, "peach", "hopMini"));
            s.Raw(HopArt.StarAt(x + 8.5, 19 + 7, 19, d.LeftToOpen > 0));
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
