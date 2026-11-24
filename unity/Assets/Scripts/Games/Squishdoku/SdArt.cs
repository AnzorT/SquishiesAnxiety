// Squishdoku's drawings as SVG for UiPiece, copied from the app's components (units dp; text laid out as Chrome does,
// UiSvg / UiFont):
//   cushions, ✕, the red glow     src/squishdoku/RoomBoard.js (Cushion, XMark, RedGlow) on src/hop/Pieces.js cushionParts
//   the room title                src/crib/Hud.js RoomTitle (outlined SVG text with a gradient)
//   chips, the glass panels       src/squishdoku/RegularGame.js styles (landscape, REDESIGN_V8), ui.js Chip
//   the score heads, timer bar    src/squishdoku/Hud.js ScoreRow, TimerBar, Marker; ui.js Head
//   hearts                        src/components/Hearts.js
//   the phase pill                src/crib/Hud.js PhasePill
//   the buddy's speech bubble     src/squishdoku/Buddy.js
//   the LEVEL banner              RegularGame.js banner
// Positions are what Chrome lays out on the reference screen (tools/unity/squishdoku-test checks them).
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdArt
    {
        public const string INK = "#5b3418", RING = "#6b4426", CRIB_INK = "#5b3a29";
        public const string Display = "Fredoka_700Bold", Heavy = "Nunito_800ExtraBold", Black = "Nunito_900Black";
        public static readonly string[] TIER_NAMES = { "EASY", "MEDIUM", "HARD", "EXPERT", "MASTER", "LEGEND" };
        public static readonly string[] TIER_COLORS = { "#3ddc97", "#5fb8ff", "#ff8a4a", "#e01e4a", "#8f3cf2", "#f5a300" };

        /// <summary>cushions.js: the nine patch colours, [edge shade, body, light].</summary>
        public static readonly string[][] PATCHES =
        {
            new[] { "#9a2a78", "#d64f9f", "#f39acb" }, new[] { "#1d6fa0", "#3c9fdc", "#94d2f7" }, new[] { "#b07a12", "#e5ad3a", "#fbd88a" },
            new[] { "#55309f", "#8460d8", "#bba2f2" }, new[] { "#1f7650", "#3aa774", "#8ad8ae" }, new[] { "#ad5428", "#e2804a", "#f7b892" },
            new[] { "#29489e", "#4c78da", "#9bb6f5" }, new[] { "#16767c", "#2ba7a6", "#86d8d2" }, new[] { "#a12d45", "#dc5a6c", "#f5a2ad" },
        };

        static string F(double v) => UiSvg.F(v);
        static string R(double v) => v.ToString("R", CultureInfo.InvariantCulture);
        static double JsRound(double v) => Math.Floor(v + 0.5);

        // RoomBoard.js colorOf: a patch's Jewel colour as a cushion (its body going to its deep edge, on a darker ring)
        static string Darker(string hex, double k)
        {
            int v = int.Parse(hex.Substring(1), NumberStyles.HexNumber);
            int Ch(int sh) => (int)JsRound(((v >> sh) & 255) * k);
            return $"rgb({Ch(16)},{Ch(8)},{Ch(0)})";
        }

        public static (string c1, string c2, string ring) ColorOf(int col)
        {
            var p = PATCHES[col % PATCHES.Length];
            return (p[1], p[0], Darker(p[0], 0.72));
        }

        // ---- the board (hop/Pieces.js cushionParts, RoomBoard.js) ---------------------------------------------------------
        const double GAP = 0.04;

        /// <summary>A cushion on cell (x, y) at height z, `k` of full size, as SVG elements relative to (ox, oy).</summary>
        public static string CushionParts(Board B, int x, int y, double z, double k, (string c1, string c2, string ring) c, string id, double ox, double oy)
        {
            double S = (1 - 2 * GAP) * k, cx = x + 0.5, cy = y + 0.5;
            double Rr(double d) => Math.Max(0.01, (S / 2 - d) * 0.42);
            string Rect(double d, double dv = 0) => B.RoundRect(cx - S / 2 + d, cy - S / 2 + d + dv, cx + S / 2 - d, cy + S / 2 - d + dv, Rr(d), z, ox, oy);
            var mid = B.Project(cx, cy + 0.03 * S, z);
            double px = mid.S, stroke = Math.Max(1.2, B.T * 0.032);
            return $"<defs><radialGradient id=\"{id}\" cx=\"50%\" cy=\"34%\" rx=\"70%\" ry=\"70%\"><stop offset=\"0\" stop-color=\"{c.c1}\"/><stop offset=\"1\" stop-color=\"{c.c2}\"/></radialGradient></defs>" +
                   $"<path d=\"{Rect(0, 0.06 * S)}\" fill=\"{c.ring}\"/>" +
                   $"<path d=\"{Rect(0)}\" fill=\"{c.ring}\"/>" +
                   $"<path d=\"{Rect(0.035 * S)}\" fill=\"#ffffff\"/>" +
                   $"<path d=\"{Rect(0.075 * S)}\" fill=\"url(#{id})\"/>" +
                   $"<path d=\"{Rect(0.17 * S)}\" fill=\"none\" stroke=\"rgba(255,255,255,0.75)\" stroke-width=\"{R(stroke)}\" stroke-dasharray=\"{R(stroke * 2.5)} {R(stroke * 2)}\"/>" +
                   $"<ellipse cx=\"{R(mid.X - ox)}\" cy=\"{R(mid.Y - oy)}\" rx=\"{R(0.065 * S * px)}\" ry=\"{R(0.055 * S * px * 0.8)}\" fill=\"{c.ring}\" opacity=\"0.45\"/>";
        }

        static string Svg(double w, double h, string inner) => $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w)} {F(h)}\" overflow=\"visible\">{inner}</svg>";

        /// <summary>RoomBoard.js Cushion: cell `cell`'s cushion in its box (cellBox z 0.02, pad 0.1).</summary>
        public static (string svg, Board.Box box) Cushion(Board B, int cell, int col)
        {
            int x = cell % B.W, y = cell / B.W;
            var box = B.CellBox(x, y, 0.02, 0.1);
            return (Svg(box.Width, box.Height, CushionParts(B, x, y, 0, 1, ColorOf(col), "sdk" + cell, box.Left, box.Top)), box);
        }

        /// <summary>RoomBoard.js XMark: a ✕ printed on a cushion, white with a brown edge.</summary>
        public static (string svg, Board.Box box) XMark(Board B, int cell)
        {
            int x = cell % B.W, y = cell / B.W;
            var box = B.CellBox(x, y, 0.02, 0.1);
            const double k = 0.2;
            var a = B.PolyPath(new[] { new[] { x + k + 0.04, y + k + 0.02 }, new[] { x + 1 - k - 0.04, y + 1 - k - 0.04 } }, 0.01, box.Left, box.Top);
            var b = B.PolyPath(new[] { new[] { x + 1 - k - 0.04, y + k + 0.02 }, new[] { x + k + 0.04, y + 1 - k - 0.04 } }, 0.01, box.Left, box.Top);
            double w = Math.Max(3, B.T * 0.1);
            return (Svg(box.Width, box.Height,
                $"<path d=\"{a} {b}\" stroke=\"{INK}\" stroke-width=\"{R(w + 3)}\" stroke-linecap=\"round\" fill=\"none\"/>" +
                $"<path d=\"{a} {b}\" stroke=\"#ffffff\" stroke-width=\"{R(w)}\" stroke-linecap=\"round\" fill=\"none\"/>"), box);
        }

        /// <summary>RoomBoard.js RedGlow: the red glow round a cell a wrong creature was put on.</summary>
        public static (string svg, Board.Box box) RedGlow(Board B, int cell)
        {
            int x = cell % B.W, y = cell / B.W;
            var box = B.CellBox(x, y, 0, 0.16);
            var d = B.RoundRect(x - 0.03, y - 0.03, x + 1.03, y + 1.03, 0.26, 0, box.Left, box.Top);
            return (Svg(box.Width, box.Height, $"<path d=\"{d}\" fill=\"rgba(255,77,109,0.45)\" stroke=\"#ff4d6d\" stroke-width=\"{R(Math.Max(2.5, B.T * 0.06))}\"/>"), box);
        }

        /// <summary>hop/Pieces.js Piece's shadow: a soft ellipse under a creature's feet (w x h box).</summary>
        public static string Shadow(float w, float h, string shade) => new UiSvg(w, h).Box(0, 0, w, h, new BoxStyle { Background = shade, Radius = 999 }).Markup;

        // ---- the left column (landscape) --------------------------------------------------------------------------------
        public const float LeftW = 236, RightW = 206;
        public const string GLASS = "rgba(91,58,41,0.75)";
        static readonly TextStyle SubText = new TextStyle { Font = Heavy, Size = 11, Color = "#ffffff", LetterSpacing = 0.6f, Shadows = new[] { new Shadow(CRIB_INK, 0, 1, 1.5f) } };
        static readonly TextStyle ChipText = new TextStyle { Font = Display, Size = 11.5f, LetterSpacing = 0.5f, Color = "#ffffff" };
        static readonly TextStyle PerfectText = new TextStyle { Font = Display, Size = 10.5f, LetterSpacing = 0.6f, Color = "#ffe08a" };
        static readonly TextStyle LostText = new TextStyle { Font = Display, Size = 10.5f, LetterSpacing = 0.6f, Color = "#e9d6ff" };
        static readonly TextStyle PhaseText = new TextStyle { Font = Black, Size = 11, LetterSpacing = 0.6f, Color = "#ffffff" };
        public static readonly TextStyle BarLabel = new TextStyle { Font = Display, Size = 13.5f, Color = INK };

        // where the left column's pieces are (dp from the screen's top-left): the header row 8 down, 62.891 tall (the
        // title 40.891 + its chips 24 - 2), the glass 6 + 2 below it, the phase pill 6 below the glass
        public const float HeaderY = 8, TitleH = 40.891f, ChipsY = HeaderY + TitleH - 2;
        public const float CribX = 10, CribY = HeaderY + (TitleH - 2 + 24 - 52) / 2;   // centred in the header row
        public const float GlassX = 10, GlassY = HeaderY + TitleH - 2 + 24 + 6 + 2, GlassW = LeftW - 10;
        public const float RowY = GlassY + 2 + 4, RowH = 52;
        public static float PerfectY => RowY + RowH + 2;
        /// <summary>The glass's line: one centred line, or wrapped (left-aligned) in the glass's 198 dp when it's too long.</summary>
        public static List<string> PerfectLines(bool perfect)
        {
            var t = perfect ? PerfectText : LostText;
            var line = perfect ? "NO ✕ + NO MISTAKES = PERFECT ×3" : "BEAT THE CREATURES ON THE CLOCK";
            return UiSvg.BoxWidth(line, t) <= GlassW - 28 ? new List<string> { line } : CardArt.Wrap(line, t, GlassW - 28);
        }
        public static float BarY(bool perfect) => PerfectY + UiSvg.LineBox(PerfectText) * PerfectLines(perfect).Count + 22;
        public const float BarW = 196, BarH = 34;
        public static float BarX => GlassX + GlassW / 2 - BarW / 2;
        public static float GlassH(bool perfect) => BarY(perfect) + BarH + 8 + 2 - GlassY;
        public static float PhaseY(bool perfect) => GlassY + GlassH(perfect) + 6;
        /// <summary>The score heads: 40, 46, 40 dp, each in a box 6 dp bigger, 4 dp apart, centred in the glass.</summary>
        public static readonly float[] SlotW = { 46, 52, 46 };
        public static float RowX => GlassX + GlassW / 2 - (46 + 52 + 46 + 8) / 2f;
        public static float SlotX(int i) => RowX + (i == 0 ? 0 : i == 1 ? 50 : 106);

        public sealed class Left
        {
            public string Room, Phase, Sub;           // the room's name, the time of day (null: no pill), "LEVEL 12 · 5×5"
            public int Tier;
            public bool Head;                         // HEAD START's chip
            public bool Perfect;                      // NO ✕ + NO MISTAKES (or BEAT THE CREATURES)
        }

        /// <summary>The left column's still parts (the room title, the chips, the glass panel, its line of text, the time
        /// of day), 236 x h.</summary>
        public static string LeftColumn(Left d, float h) => LeftColumn(d, h, out _);

        /// <summary>`w`: its width, 236 unless the chips run on past the column (they do, over the board, with HEAD START).</summary>
        public static string LeftColumn(Left d, float h, out float w)
        {
            w = Math.Max(LeftW, ChipsEnd(d) + 2);
            var s = new UiSvg(w, h);
            RoomTitle(s, d.Room, 66, HeaderY);
            // the chips row: the level, the tier, HEAD START (alignItems centre, 5 apart, 24 tall)
            float x = 66;
            s.Text(d.Sub, x, ChipsY + (24 - UiSvg.LineBox(SubText)) / 2, SubText);
            x += UiSvg.BoxWidth(d.Sub, SubText) + 5;
            x += Chip(s, x, ChipsY, TIER_NAMES[d.Tier], TIER_COLORS[d.Tier]) + 5;
            if (d.Head) Chip(s, x, ChipsY, "HEAD START", "#ffb02e");
            // the glass
            s.Box(GlassX, GlassY, GlassW, GlassH(d.Perfect), new BoxStyle { Background = GLASS, Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            var pt = d.Perfect ? PerfectText : LostText;
            var lines = PerfectLines(d.Perfect);
            if (lines.Count == 1) s.Text(lines[0], Card.Snap(GlassX + GlassW / 2 - UiSvg.BoxWidth(lines[0], pt) / 2), PerfectY, pt);
            else for (int i = 0; i < lines.Count; i++) s.Text(lines[i], GlassX + 14, PerfectY + i * UiSvg.LineBox(pt), pt);
            if (d.Phase != null) PhasePill(s, 10, PhaseY(d.Perfect), d.Phase);
            return s.Markup;
        }

        static float ChipsEnd(Left d)
        {
            float x = 66 + UiSvg.BoxWidth(d.Sub, SubText) + 5 + UiSvg.BoxWidth(TIER_NAMES[d.Tier], ChipText) + 22;
            if (d.Head) x += 5 + UiSvg.BoxWidth("HEAD START", ChipText) + 22;
            return x;
        }

        // ui.js Chip: 9 x 3 padding, a 2 dp white border; its width
        public static float Chip(UiSvg s, float x, float y, string text, string bg)
        {
            float w = UiSvg.BoxWidth(text, ChipText) + 18 + 4, h = UiSvg.LineBox(ChipText) + 6 + 4;
            s.Box(x, y + (24 - h) / 2, w, h, new BoxStyle { Background = bg, Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text(text, x + 2 + 9, y + (24 - h) / 2 + 2 + 3, ChipText);
            return w;
        }

        /// <summary>crib/Hud.js RoomTitle: Fredoka 26 in a cream-to-peach gradient inside a brown outline with a deeper
        /// drop, its &lt;svg&gt; (the text's width + 12 x 40.9) at (x, y).</summary>
        public static void RoomTitle(UiSvg s, string title, float x, float y)
        {
            const float size = 26, pad = 4;
            var font = UiFont.Get(Display);
            double k = size / (double)font.UnitsPerEm;
            float baseline = pad + size * 0.92f;
            double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
            var id = s.NewId("rt");
            s.Def($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\"><stop offset=\"0\" stop-color=\"#fffaf0\"/><stop offset=\"0.6\" stop-color=\"#ffe6b8\"/><stop offset=\"1\" stop-color=\"#ffcf80\"/></linearGradient>");
            string stroke = $"stroke=\"{CRIB_INK}\" stroke-width=\"{F(5 / k)}\" stroke-linejoin=\"round\"";
            s.Glyphs(title, x + pad, y + baseline + 3, Display, size, 0.5f, CRIB_INK, stroke);
            s.Glyphs(title, x + pad, y + baseline, Display, size, 0.5f, CRIB_INK, stroke);
            s.Glyphs(title, x + pad, y + baseline, Display, size, 0.5f, $"url(#{id})");
        }

        /// <summary>royal/Lettering.js (the menu's lettering): Ui/Cards/RoyalLettering, shared with the other games' hubs.</summary>
        public static (string svg, float w, float h) Lettering(string text, float size, string variant = "white") => RoyalLettering.Draw(text, size, variant);

        /// <summary>crib/Hud.js PhasePill: "● EVENING" on the brown glass.</summary>
        public static void PhasePill(UiSvg s, float x, float y, string phase)
        {
            var (label, sun, _) = Rooms.Phase(phase);
            float tw = UiSvg.BoxWidth(label, PhaseText), lh = UiSvg.LineBox(PhaseText);
            float w = 2 + 11 + 9 + 6 + tw + 11 + 2, h = 2 + 4 + lh + 4 + 2;
            s.Box(x, y, w, h, new BoxStyle { Background = GLASS, Radius = 999, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            s.Box(x + 13, y + (h - 9) / 2, 9, 9, new BoxStyle { Background = sun, Radius = 5 });
            s.Text(label, x + 13 + 9 + 6, y + 6, PhaseText);
        }

        /// <summary>ui.js Head: a creature's still in a sticker circle, as its own piece (size x size).</summary>
        public static string Head(float size, string picture, string ring, string bg, bool dim = false)
        {
            var s = new UiSvg(size, size);
            CardArt.Head(s, 0, 0, size, picture, ring, bg, dim);
            return s.Markup;
        }

        /// <summary>Hud.js ScoreRow's glow: the gold band behind the heads (192 x 40, a horizontal fade).</summary>
        public static string Glow() =>
            new UiSvg(192, 40).Box(0, 0, 192, 40, new BoxStyle { Gradient = new[] { "rgba(255,226,92,0)", "rgba(255,226,92,0.85)", "rgba(255,226,92,0)" }, GradientAngle = 90, Radius = 999 }).Markup;

        /// <summary>Hud.js TimerBar under its label and markers: the track with the fill `frac` of the way, yellow then red as
        /// it runs down, and the last seconds' red wash (`warn` its opacity). 196 x 34.</summary>
        public static string Bar(double frac, double warn)
        {
            const float w = BarW, inner = w - 6;
            var s = new UiSvg(w, BarH);
            var track = new BoxStyle { Background = "rgba(91,52,24,0.28)", Radius = 999 };
            s.Box(0, 6, w, 22, track);
            var clip = s.NewId("bc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(3, 9, inner, 16, new[] { 996f, 996, 996, 996 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            double f = Math.Max(0, Math.Min(1, frac));
            double shift = -inner * (1 - f);
            double yellow = Clamp01((0.45 - frac) / 0.25), red = Clamp01((0.2 - frac) / 0.14);
            if (f > 0)
            {
                s.Open($"transform=\"translate({F(shift)} 0)\"");
                s.Box(3, 9, inner, 16, new BoxStyle { Gradient = new[] { "#b8ffd9", "#3ddc97" } });
                if (yellow > 0) s.Box(3, 9, inner, 16, new BoxStyle { Gradient = new[] { "#fff3a0", "#ffc233" }, Opacity = (float)yellow });
                if (red > 0) s.Box(3, 9, inner, 16, new BoxStyle { Gradient = new[] { "#ffb3c0", "#ff4d6d" }, Opacity = (float)red });
                s.Box(9, 11, inner - 12, 5, new BoxStyle { Background = "rgba(255,255,255,0.55)", Radius = 9 });
                s.Close();
            }
            if (warn > 0) s.Box(3, 9, inner, 16, new BoxStyle { Background = "rgba(255,40,80,0.35)", Opacity = (float)warn });
            s.Close();
            s.Box(0, 6, w, 22, new BoxStyle { BorderWidth = 3, BorderColor = "#ffffff", Radius = 999 });
            return s.Markup;
        }

        /// <summary>The bar's label, centred on it (red in the last seconds).</summary>
        public static string BarText(string label, bool warn)
        {
            var t = warn ? new TextStyle { Font = Display, Size = 13.5f, Color = "#c4002b" } : BarLabel;
            float lw = UiSvg.BoxWidth(label, t), lh = UiSvg.LineBox(t);
            return new UiSvg(BarW, BarH).Text(label, Card.Snap(BarW / 2 - lw / 2), Card.Snap((BarH - lh) / 2), t).Markup;
        }

        /// <summary>Hud.js Marker: a creature riding on the bar (its head on a pin), 26 x 34.</summary>
        public static string Marker(string picture)
        {
            var s = new UiSvg(26, 34);
            s.Box(11.5f, 22, 3, 12, new BoxStyle { Background = "#ffffff", Radius = 2 });
            CardArt.Head(s, 0, 0, 26, picture, "#ffffff", "#f6efff");
            return s.Markup;
        }

        // ---- Hearts.js -------------------------------------------------------------------------------------------------
        const string HEART_D = "M12 21 C5 15.5 2 12 2 7.8 C2 4.6 4.4 2.5 7.2 2.5 C9.2 2.5 11 3.6 12 5.4 C13 3.6 14.8 2.5 16.8 2.5 C19.6 2.5 22 4.6 22 7.8 C22 12 19 15.5 12 21 Z";
        public static string HeartEmpty(float size, string empty) =>
            new UiSvg(size, size).Drawing($"<path d=\"{HEART_D}\" fill=\"{empty}\" stroke=\"#ffffff\" stroke-width=\"2\"/>", 0, 0, size, size, "0 0 24 24").Markup;
        public static string HeartFull(float size) =>
            new UiSvg(size, size).Drawing($"<path d=\"{HEART_D}\" fill=\"#ff4d7d\" stroke=\"#ffffff\" stroke-width=\"2\"/><path d=\"M6.5 7 C7 5.6 8.2 5 9.2 5.2\" stroke=\"#ffd6e4\" stroke-width=\"1.6\" stroke-linecap=\"round\" fill=\"none\"/>", 0, 0, size, size, "0 0 24 24").Markup;

        // ---- the right column: the buddy and the tools on the glass ----------------------------------------------------------
        public static readonly TextStyle HintText = new TextStyle { Font = Heavy, Size = 11, LineHeight = 14, Color = "#ffffff" };
        public const float ToolW = 112.375f, ToolH = 53, BuddySize = 84;

        public static string[] HintLines(bool xTool) => xTool ? new[] { "Tap or drag to mark ✕", "using ✕ ends a PERFECT run" } : new[] { "Tap to place", "long-press to mark ✕" };

        /// <summary>Where the right column's pieces are on a screen w x h: the glass, the buddy, the tools, the hint.</summary>
        public struct RightLayout { public float GX, GY, GW, GH, BuddyX, BuddyY, ToolX, ToolY, HintX, HintY, HintW; }

        public static RightLayout Right(float w, float h, bool xTool)
        {
            float hintW = 0;
            foreach (var l in HintLines(xTool)) hintW = Math.Max(hintW, UiSvg.BoxWidth(l, HintText));
            float inner = Math.Max(BuddySize, Math.Max(ToolW, hintW));
            float colH = ToolH * 2 + 8 + 2 + 2 * 14 + 2;
            var r = new RightLayout { GW = 2 + 12 + inner + 12 + 2, GH = 2 + 4 + BuddySize + 10 + colH + 6 + 2, HintW = hintW };
            r.GX = Card.Snap(w - RightW + (RightW - r.GW) / 2);
            r.GY = h - 10 - r.GH;
            r.BuddyX = Card.Snap(r.GX + 14 + (inner - BuddySize) / 2);
            r.BuddyY = r.GY + 6;
            r.ToolX = Card.Snap(r.GX + 14 + (inner - ToolW) / 2);
            r.ToolY = r.BuddyY + BuddySize + 10;
            r.HintX = Card.Snap(r.GX + 14 + (inner - hintW) / 2);
            r.HintY = r.ToolY + ToolH * 2 + 8 + 2;
            return r;
        }

        /// <summary>The right column's still parts: the glass, the buddy's floor shadow, the hint (w x h, the screen).</summary>
        public static string RightColumn(RightLayout r, float w, float h, bool xTool)
        {
            var s = new UiSvg(w, h);
            s.Box(r.GX, r.GY, r.GW, r.GH, new BoxStyle { Background = GLASS, Radius = 22, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            const float B = BuddySize;
            s.Box(r.BuddyX + B * 0.19f, r.BuddyY + B - 2 - B * 0.1f, B * 0.62f, B * 0.1f, new BoxStyle { Background = "rgba(69,16,122,0.2)", Radius = 999 });
            var lines = HintLines(xTool);
            for (int i = 0; i < lines.Length; i++) s.Text(lines[i], r.HintX, r.HintY + i * 14, HintText, r.HintW, 0.5f);
            return s.Markup;
        }

        /// <summary>Buddy.js's speech bubble (its box w x h, the tail hanging under it).</summary>
        public static (string svg, float w, float h) Bubble(string text, bool bad)
        {
            var t = new TextStyle { Font = Display, Size = 13, Color = bad ? "#e01e4a" : "#6b4426" };
            string edge = bad ? "#e01e4a" : "#6b4426", fill = bad ? "#fff0f3" : "#ffffff";
            float tw = UiSvg.BoxWidth(text, t), lh = UiSvg.LineBox(t);
            float w = Math.Max(54, tw + 20 + 5), h = lh + 6 + 5;
            var s = new UiSvg(w, h + 7);
            s.Box(0, 0, w, h, new BoxStyle { Background = fill, Radius = 14, BorderWidth = 2.5f, BorderColor = edge });
            // the tail: a 12 dp square with its right and bottom edges, turned 45° about its middle, 7 dp below
            s.Open($"transform=\"rotate(45 {F(w / 2)} {F(h + 1)})\"");
            s.Box(w / 2 - 6, h + 1 - 6, 12, 12, new BoxStyle { Background = fill, Borders = new[] { 0f, 2.5f, 2.5f, 0 }, BorderColor = edge });
            s.Close();
            s.Text(text, 2.5f, 2.5f + 3, t, w - 5, 0.5f);
            return (s.Markup, w, h);
        }

        // ---- the LEVEL banner -----------------------------------------------------------------------------------------
        static readonly TextStyle BannerText = new TextStyle { Font = Display, Size = 40, LetterSpacing = 2, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 4, 1) } };
        static readonly TextStyle BannerSub = new TextStyle { Font = Display, Size = 17, LetterSpacing = 1, Color = "#ffe08a", Shadows = new[] { new Shadow(INK, 0, 2, 1) } };

        public static (string svg, float w, float h) Banner(string text, string[] sub)
        {
            float w = UiSvg.BoxWidth(text, BannerText), h = UiSvg.LineBox(BannerText);
            if (sub != null) foreach (var l in sub) w = Math.Max(w, UiSvg.BoxWidth(l, BannerSub));
            float total = h + (sub != null ? 4 + sub.Length * UiSvg.LineBox(BannerSub) : 0);
            var s = new UiSvg(w, total);
            s.Text(text, 0, 0, BannerText);   // (no textAlign: left, when the line under it is wider)
            if (sub != null) for (int i = 0; i < sub.Length; i++) s.Text(sub[i], 0, h + 4 + i * UiSvg.LineBox(BannerSub), BannerSub, w, 0.5f);
            return (s.Markup, w, total);
        }

        static double Clamp01(double v) => Math.Max(0, Math.Min(1, v));
    }
}
