// Squish Sort's drawings as SVG for UiPiece, copied from the app's components the way the UI exporter
// (tools/unity/ui/snap.js) writes what Chrome painted (UiSvg): boxes as React Native Web lays them out (borders inside
// the box, absolute children from the padding box, overflow: hidden clipping to the padding box's rounded rect),
// react-native-svg drawings as they are.
//   the fridge     src/sort/Container.js (SortArt.Fridge.cs): Body (the floor shadow, the feet, the cabinet, what's
//                  above and below the inside), the inside (InsideBack, Lamp: the lamp fades on its own), the clutter
//                  (src/sort/props.js, exported to Resources/Sort/props.json), and each door's front and back
//   the tray, the squishies' marks, the drop spot, the banner, the HUD's left column   src/sort/Game.js
// Units are dp. Pieces are drawn in their own box (top-left 0, 0); SortLevel places them.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;
using static SquishSquad.Games.Sort.SortGeometry;

namespace SquishSquad.Games.Sort
{
    public static partial class SortArt
    {
        public const string INK = "#5b3418";   // squishdoku/theme.js
        public const string Display = "Fredoka_700Bold", Heavy = "Nunito_800ExtraBold";
        const string HEART_D = "M12 20 C5 14.5 2 11 2 7 C2 4 4.3 2 7 2 C9 2 10.8 3.2 12 5 C13.2 3.2 15 2 17 2 C19.7 2 22 4 22 7 C22 11 19 14.5 12 20 Z";
        const string STAR_D = "M12 2.5 L14.6 8.6 L21.2 9.2 L16.2 13.5 L17.7 20 L12 16.6 L6.3 20 L7.8 13.5 L2.8 9.2 L9.4 8.6 Z";

        static string F(double v) => UiSvg.F(v);

        static float[] R4(float r) => new[] { r, r, r, r };

        /// <summary>overflow: hidden: what's drawn next is clipped to the padding box of x, y, w, h (radii less the border).</summary>
        static void Clip(UiSvg s, float x, float y, float w, float h, float[] radii, float border)
        {
            var id = s.NewId("sc");
            var inner = new[] { Math.Max(0, radii[0] - border), Math.Max(0, radii[1] - border), Math.Max(0, radii[2] - border), Math.Max(0, radii[3] - border) };
            s.Def($"<clipPath id=\"{id}\"><path d=\"{UiSvg.RRect(x + border, y + border, w - 2 * border, h - 2 * border, inner)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{id})\"");
        }

        static string Svg(float x, float y, float w, float h, string viewBox, string inner, string extra = "") =>
            $"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"{viewBox}\"{extra}>{inner}</svg>";

        static TextStyle T(string font, float size, string color, float ls = 0) => new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = ls };

        // ---- the inside (W x (H + crisper), at INSET, RING + BORDER + top in the body; SortArt.Fridge.cs draws it) ------
        public static float InsideX => INSET;
        public static float InsideY(ContainerGeo g) => RING + BORDER + g.Top;
        // (Container.js Inside: overflow hidden, borderRadius 4)
        static float[] InsideRadii(SortModel m) => R4(4);

        /// <summary>The clutter on the shelves (slot -> kind), `q` dp each, tilted, in the inside's box; clipped by it.</summary>
        public static string Clutter(SortModel m, ContainerGeo g, IEnumerable<KeyValuePair<int, int>> food, float q, IList<string> props)
        {
            float W = g.W, hd = g.H + g.Crisper, S = g.S;
            var s = new UiSvg(W, hd);
            Clip(s, 0, 0, W, hd, InsideRadii(m), 0);
            foreach (var kv in food)
            {
                int i = kv.Key;
                int tilt = ((i * 37) % 13) - 6;
                float dx = (((i * 53) % 9) - 4) * (S / 90f);
                float x = (i % g.Cols) * S + (S - q) / 2 + dx, y = (i / g.Cols) * (S + SHELF) + S - q;
                s.Raw($"<g transform=\"rotate({tilt} {F(x + q / 2)} {F(y + q / 2)})\">{Svg(x, y, q, q, "0 0 64 64", props[kv.Value % props.Count])}</g>");
            }
            s.Close();
            return s.Markup;
        }

        /// <summary>Where the doors are in the body: (x, y) of door `i`, its width, the doors' height.</summary>
        public static (float x, float y, float w, float h, string hinge) DoorBox(SortModel m, ContainerGeo g, int i)
        {
            float x0 = INSET, y0 = RING + BORDER + g.Top - g.Up, dh = g.H + g.Crisper + g.Up;
            if (m.Doors == 1) return (x0, y0, g.W, dh, m.Hinge);
            return (x0 + (i == 0 ? 0 : g.W / 2), y0, g.W / 2, dh, i == 0 ? "left" : "right");
        }

        // ---- the tray (landscape: a column at the right) ----------------------------------------------------------------
        /// <summary>The tray in the play area's coordinates (its own box: tw x th at tx, ty): the same glass as the HUD's
        /// panel with a soft spot under each place (develop: no COUNTER label since 2026-11-17).</summary>
        public static string Tray(TrayGeo tg, int cap)
        {
            var s = new UiSvg(tg.Tw, tg.Th);
            s.Box(0, 0, tg.Tw, tg.Th, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            for (int j = 0; j < cap; j++)
            {
                var (cx, cy) = TrayCenter(tg, j);
                s.Box(cx - tg.Tx - tg.Cell * 0.36f, cy - tg.Ty + tg.Cell * 0.22f, tg.Cell * 0.72f, tg.Cell * 0.2f, new BoxStyle { Background = "rgba(255,255,255,0.13)", Radius = 999 });
            }
            return s.Markup;
        }

        // ---- a squishy's marks (Game.js Piece; each its own piece over or under the picture, P x P) ---------------------
        /// <summary>The soft floor shadow: 74 % x 14 % of the piece, at its bottom, centred (its own box).</summary>
        public static string PieceShadow(float w, float h)
        {
            var s = new UiSvg(w, h);
            s.Def("<radialGradient id=\"pieceFloor\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#45107a\" stop-opacity=\"0.28\"/><stop offset=\"1\" stop-color=\"#45107a\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(w / 2)}\" ry=\"{F(h / 2)}\" fill=\"url(#pieceFloor)\"/>");
            return s.Markup;
        }

        public static string SelRing(float p)
        {
            float i = p * 0.04f;
            return new UiSvg(p, p).Box(i, i, p - 2 * i, p - 2 * i, new BoxStyle { Background = "rgba(255,240,150,0.35)", Radius = 999, BorderWidth = 3, BorderColor = "#ffd23a" }).Markup;
        }

        /// <summary>A sweat drop (Game.js styles.sweat, d = 16 % of the piece): round but for its top-left corner.</summary>
        public static string SweatDrop(float d)
        {
            float r = d / 2;
            return new UiSvg(d, d).Box(0, 0, d, d, new BoxStyle { Background = "#8fd3ff", Radii = new[] { 0, r, r, r }, BorderWidth = 1.2f, BorderColor = "#ffffff" }).Markup;
        }

        /// <summary>The mixed-up one's "?" (22 x 22).</summary>
        public static string Huh()
        {
            var s = new UiSvg(22, 22);
            s.Box(0, 0, 22, 22, new BoxStyle { Background = "#ff8a3d", Radius = 11, BorderWidth = 2, BorderColor = "#ffffff" });
            var t = T(Display, 13, "#ffffff");
            s.Text("?", 2, 2 + (18 - UiSvg.LineBox(t)) / 2, t, 18, 0.5f);
            return s.Markup;
        }

        /// <summary>The tick on one that's home (20 x 20).</summary>
        public static string Tick()
        {
            var s = new UiSvg(20, 20);
            s.Box(0, 0, 20, 20, new BoxStyle { Background = "#26a94e", Radius = 10, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Raw(Svg(4, 5, 12, 10, "0 0 12 10", "<path d=\"M1.5 5 L4.5 8 L10.5 2\" stroke=\"#ffffff\" stroke-width=\"2.4\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>"));
            return s.Markup;
        }

        /// <summary>The spot under a dragged squishy (S x S).</summary>
        public static string Hover(float S) => new UiSvg(S, S).Box(0, 0, S, S, new BoxStyle { Background = "rgba(255,230,120,0.28)", Radius = S * 0.24f, BorderWidth = 3, BorderColor = "#ffd23a" }).Markup;

        // ---- the banner (Game.js Banner) -------------------------------------------------------------------------------
        static Shadow[] Outline3(string color, float down) => new[] { new Shadow(color, 0, down, 0), new Shadow(color, 1, 0, 0), new Shadow(color, -1, 0, 0) };

        /// <summary>The big words over the container, `w` wide (the area's width); returns the markup and its height.</summary>
        public static (string markup, float h) Banner(float w, string text, bool small, string ink, string[] chips, string sub)
        {
            var big = new TextStyle { Font = Display, Size = small ? 30 : 40, Color = "#ffffff", Shadows = Outline3(ink ?? INK, 3) };
            float y = 0;
            var s = new UiSvg(w, 400);
            s.Text(text, 0, y, big, w, 0.5f);
            y += UiSvg.LineBox(big);
            if (chips != null && chips.Length > 0)
            {
                var ct = T(Display, 12, "#ffffff", 0.6f);
                y += 8;
                float ch = UiSvg.LineBox(ct) + 6 + 4, total = -6;
                foreach (var c in chips) total += UiSvg.BoxWidth(c, ct) + 18 + 4 + 6;
                float cx = (w - total) / 2;
                foreach (var c in chips)
                {
                    float cw = UiSvg.BoxWidth(c, ct) + 18 + 4;
                    s.Box(cx, y, cw, ch, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                    s.Text(c, cx + 2 + 9, y + 2 + 3, ct);
                    cx += cw + 6;
                }
                y += ch;
            }
            if (sub != null)
            {
                var st = T(Display, 13, "#ffffff");
                y += 6;
                float sw = UiSvg.BoxWidth(sub, st) + 24, sh = UiSvg.LineBox(st) + 8;
                s.Box((w - sw) / 2, y, sw, sh, new BoxStyle { Background = "rgba(69,16,122,0.8)", Radius = 999 });
                s.Text(sub, (w - sw) / 2 + 12, y + 4, st);
                y += sh;
            }
            var mk = s.Markup.Replace($"height=\"400\" viewBox=\"0 0 {F(w)} 400\"", $"height=\"{F(y)}\" viewBox=\"0 0 {F(w)} {F(y)}\"");
            return (mk, y);
        }

        // ---- the HUD's left column (develop's Game.js topEl, 2026-11-17, the user: "make sure the screens of squish sort
        // matches the other game's screen": Squish Hop's top bar and glass; the column 240 wide, padding 8 / 10, gap 8) ----
        public const float LeftW = 240;
        public sealed class Hud
        {
            public string ModelName, BarLabel;
            public int Tier;
            /// <summary>The glass bar's icon: the eye while you look (peek, deal), else the clock.</summary>
            public bool Eye;
            /// <summary>Blitz: "Blitz Mode" with no tier chip; on the glass the rounds cleared and the best run (gold NEW
            /// BEST once beaten) and the rule (1 MISTAKE = GAME OVER) in the hearts' place.</summary>
            public bool Blitz, BestBeaten;
            public int Cleared, Best;
        }

        const float TitleH = 40.890625f;
        // the top bar: the back button (48 x 52) beside the title box (RoomTitle, the tier chip's row -2 under it)
        static float BarH0(bool blitz) => blitz ? 52 : TitleH - 2 + 15;
        /// <summary>The back button's top (CribButton, 48 x 52 at x 10).</summary>
        public static float BackY(bool blitz) => 8 + (BarH0(blitz) - 52) / 2;
        static float GlassY(bool blitz) => 8 + BarH0(blitz) + 8 + 4;
        // the glass's inside: 10 in from x 10 + its 2 dp border, 206 wide (230 - 4 - 20), 9 dp down; its rows 8 apart
        const float InX = 10 + 2 + 10, InW = LeftW - 10 - 4 - 20;
        static readonly TextStyle PillText = T(Display, 12, "#b86200", 0.5f);
        static float PillH => UiSvg.LineBox(PillText) + 2 + 4;
        static float ChipH => UiSvg.LineBox(SquishSquad.Games.Squishdoku.SdArt.ChipText) + 6 + 4;
        /// <summary>Where the hearts (26 dp, 30 apart) and the bar's row (the 20 dp icon, the 186 dp TimerBar 6 after it,
        /// 212 wide: wider than the glass's inside, so it hangs out evenly) are.</summary>
        public static (float heartsX, float heartsY, float barX, float barY) HudLayout(Hud d)
        {
            float y = GlassY(d.Blitz) + 2 + 9;
            float heartsY = y;
            y += d.Blitz ? PillH + 8 + ChipH : 26;
            return (InX + (InW - 86) / 2, heartsY, InX + (InW - 212) / 2 + 26, y + 8);
        }
        public const float BarW = 186;

        /// <summary>The column without the back button, the hearts and the TimerBar (pieces of their own), its title
        /// running on past the column as on the phone (LeftW + 200 x `h`).</summary>
        public static string LeftColumn(Hud d, float h)
        {
            var s = new UiSvg(LeftW + 200, h);
            float ty = 8 + (BarH0(d.Blitz) - (d.Blitz ? TitleH : BarH0(d.Blitz))) / 2;
            SquishSquad.Games.Squishdoku.SdArt.RoomTitle(s, d.Blitz ? "Blitz Mode" : d.ModelName, 66, ty);
            if (!d.Blitz)
            {
                var tt = T(Display, 9.5f, "#ffffff", 0.6f);
                var tier = Levels.TIER_NAMES[d.Tier];
                float chipW = UiSvg.BoxWidth(tier, tt) + 2 * 6 + 2 * 2;
                s.Box(66, ty + TitleH - 2, chipW, 15, new BoxStyle { Background = Levels.TIER_COLORS[d.Tier], Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(tier, 66 + 2 + 6, ty + TitleH - 2 + 2, tt);
            }
            var L = HudLayout(d);
            float gy = GlassY(d.Blitz), gh = L.barY + SquishSquad.Games.Squishdoku.SdArt.BarH + 9 + 2 - gy;
            s.Box(10, gy, LeftW - 10, gh, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            if (d.Blitz)
            {
                // the pills (Squish Hop's), centred, 6 apart; then the rule's chip (ui.js Chip)
                var a = $"CLEARED {d.Cleared}";
                var b = $"{(d.BestBeaten ? "NEW BEST" : "BEST")} {d.Best}";
                var bt = T(Display, 12, d.BestBeaten ? "#ffffff" : "#5b3a29", 0.5f);
                float aw = UiSvg.BoxWidth(a, PillText) + 16 + 4, bw = UiSvg.BoxWidth(b, bt) + 16 + 4;
                float x = InX + (InW - aw - 6 - bw) / 2;
                s.Box(x, L.heartsY, aw, PillH, new BoxStyle { Background = "#ffffff", Radius = 999, BorderWidth = 2, BorderColor = "#ffd23a" });
                s.Text(a, x + 2 + 8, L.heartsY + 2 + 1, PillText);
                x += aw + 6;
                s.Box(x, L.heartsY, bw, PillH, new BoxStyle { Background = d.BestBeaten ? "#ffb02e" : "#ffffff", Radius = 999, BorderWidth = 2, BorderColor = d.BestBeaten ? "#ffffff" : "#ffe6b8" });
                s.Text(b, x + 2 + 8, L.heartsY + 2 + 1, bt);
                var ct = SquishSquad.Games.Squishdoku.SdArt.ChipText;
                const string rule = "1 MISTAKE = GAME OVER";
                float cw = UiSvg.BoxWidth(rule, ct) + 18 + 4, cy = L.heartsY + PillH + 8;
                s.Box(InX + (InW - cw) / 2, cy, cw, ChipH, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(rule, InX + (InW - cw) / 2 + 2 + 9, cy + 2 + 3, ct);
            }
            // the bar's icon (Game.js BarIcon, 20 dp): an eye while you look, a clock while you sort
            float ix = L.barX - 26, iy = L.barY + (SquishSquad.Games.Squishdoku.SdArt.BarH - 20) / 2;
            s.Raw(Svg(ix, iy, 20, 20, "0 0 24 24", d.Eye
                ? "<path d=\"M2 12 C5 6.5 8.5 4.5 12 4.5 C15.5 4.5 19 6.5 22 12 C19 17.5 15.5 19.5 12 19.5 C8.5 19.5 5 17.5 2 12 Z\" fill=\"#ffffff\"/><ellipse cx=\"12\" cy=\"12\" rx=\"4.2\" ry=\"4.2\" fill=\"#5b3a29\"/><ellipse cx=\"13.4\" cy=\"10.6\" rx=\"1.3\" ry=\"1.3\" fill=\"#ffffff\"/>"
                : "<ellipse cx=\"12\" cy=\"13\" rx=\"9\" ry=\"9\" fill=\"#ffffff\"/><path d=\"M12 8 V13 L15.5 15\" stroke=\"#5b3a29\" stroke-width=\"2.4\" stroke-linecap=\"round\" stroke-linejoin=\"round\" fill=\"none\"/><path d=\"M9 2.5 H15\" stroke=\"#ffffff\" stroke-width=\"2.6\" stroke-linecap=\"round\"/>"));
            return s.Markup;
        }

        /// <summary>A heart of the HUD (components/Hearts.js Heart, `size` dp): the empty one (`empty` its fill) under, the
        /// full one (its own piece) over it.</summary>
        const string HUD_HEART_D = "M12 21 C5 15.5 2 12 2 7.8 C2 4.6 4.4 2.5 7.2 2.5 C9.2 2.5 11 3.6 12 5.4 C13 3.6 14.8 2.5 16.8 2.5 C19.6 2.5 22 4.6 22 7.8 C22 12 19 15.5 12 21 Z";
        public static string HeartEmpty(float size, string empty) => new UiSvg(size, size).Raw(Svg(0, 0, size, size, "0 0 24 24", $"<path d=\"{HUD_HEART_D}\" fill=\"{empty}\" stroke=\"#ffffff\" stroke-width=\"2\"/>")).Markup;
        public static string HeartFull(float size) => new UiSvg(size, size).Raw(Svg(0, 0, size, size, "0 0 24 24",
            $"<path d=\"{HUD_HEART_D}\" fill=\"#ff4d7d\" stroke=\"#ffffff\" stroke-width=\"2\"/><path d=\"M6.5 7 C7 5.6 8.2 5 9.2 5.2\" stroke=\"#ffd6e4\" stroke-width=\"1.6\" stroke-linecap=\"round\" fill=\"none\"/>")).Markup;
    }
}
