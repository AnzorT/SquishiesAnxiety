// What the games' cards are drawn from, as SVG for UiPiece, built the way the UI exporter (tools/unity/ui/snap.js)
// writes what Chrome painted (UiSvg), from the app's own components:
//   OutlinedTitle            src/components/candy/OutlinedTitle.js (the sticker title: layered, stroked glyphs)
//   Star                     src/sort/Cards.js (a result star)
//   Rays                     src/components/candy/Decor.js RaysArt (the sunburst behind an earned star)
//   Head                     src/squishdoku/ui.js (a creature's still in a sticker circle)
//   Button                   src/squishdoku/ui.js SdButton + BtnLabel (the lip, the ring, the face, its shine, the label)
//   Frame, XpBar, LevelUp    src/squishdoku/Overlays.js (the card, the player's XP bar, LEVEL n!)
// Units are dp. Text is laid out as Chrome does (UiFont).
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    public static class CardArt
    {
        public const string INK = "#5b3418";                  // squishdoku/theme.js
        public const string Display = "Fredoka_700Bold";      // F.display
        public const string Heavy = "Nunito_800ExtraBold";    // F.heavy
        public const string Bold = "Nunito_700Bold";          // F.bold

        static string F(double v) => UiSvg.F(v);
        public static TextStyle Style(string font, float size, string color, float letterSpacing = 0) =>
            new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = letterSpacing };

        /// <summary>Greedy line breaking at spaces, as Chrome wraps a paragraph into `maxW`.</summary>
        public static List<string> Wrap(string text, TextStyle t, float maxW)
        {
            var lines = new List<string>();
            string line = null;
            foreach (var word in text.Split(' '))
            {
                if (line == null) { line = word; continue; }
                var next = line + " " + word;
                if (UiSvg.BoxWidth(next, t) <= maxW + 0.001f) line = next;
                else { lines.Add(line); line = word; }
            }
            if (line != null) lines.Add(line);
            return lines;
        }

        /// <summary>Wrapped lines centred in a box `w` wide (each line its own box, as Chrome centres them).</summary>
        public static void Lines(UiSvg s, List<string> lines, float x, float top, float w, TextStyle t)
        {
            float lh = UiSvg.LineBox(t);
            for (int i = 0; i < lines.Count; i++) s.Text(lines[i], x, top + i * lh, t, w, 0.5f);
        }

        // ---- OutlinedTitle ---------------------------------------------------------------------------------------------
        public static readonly Dictionary<string, (string[] colors, float[] stops)> TITLE_FILLS = new Dictionary<string, (string[], float[])>
        {
            ["gold"] = (new[] { "#fffbd6", "#ffe045", "#ff9500" }, new[] { 0f, 0.45f, 1 }),
            ["pink"] = (new[] { "#fff0d6", "#ffb05a", "#e8681c" }, new[] { 0f, 0.52f, 1 }),
        };
        const string OutlineColor = "#6b4426", OutlineDeepColor = "#3f2412";   // candyColors.outline / outlineDeep

        public sealed class Title
        {
            public string Text, Fill = "pink";
            public float Size = 30, Outline = 3, Ring = 2, LetterSpacing = 1, WordSpacing = 0;
            public float? Drop;
            public Title(string text, float size, string fill) { Text = text; Size = size; Fill = fill; }

            float Halo => Outline + Ring;
            float DropPx => Drop ?? (Size >= 26 ? 5 : Size >= 18 ? 4 : 3);
            TextStyle Measure => new TextStyle { Font = Display, Size = Size, LetterSpacing = LetterSpacing };
            /// <summary>The Svg's box (the app measures the word with an invisible Text first).</summary>
            public float W
            {
                get
                {
                    int spaces = WordSpacing != 0 ? Text.Split(' ').Length - 1 : 0;
                    return (float)Math.Ceiling(UiSvg.BoxWidth(Text, Measure) + spaces * WordSpacing + Halo * 2 + 2 + Size * 0.12);
                }
            }
            public float H => (float)Math.Ceiling(Size * 1.22 + Halo * 2 + DropPx);

            /// <summary>Draws the title with its box's top-left at (x, y).</summary>
            public void Draw(UiSvg s, float x, float y)
            {
                // react-native-svg on Android dropped the I after an A: a hair space between them
                var shown = Text.Replace("AI", "A I");
                var font = UiFont.Get(Display);
                float w = W, baseline = Halo + Size * 0.96f;
                // text-anchor middle: the run (letter-spacing after every character) centred on x = w / 2
                float start = w / 2 - UiSvg.BoxWidth(shown, Measure) / 2;
                double k = (double)Size / font.UnitsPerEm;
                // the fill's gradient spans the text's box (objectBoundingBox): the font's ascent above the baseline to
                // its descent below, rounded as Chrome does; in the glyphs' own units (y up from the baseline)
                double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
                var (colors, stops) = TITLE_FILLS.TryGetValue(Fill, out var tf) ? tf : TITLE_FILLS["pink"];
                var id = s.NewId("tf");
                var g = new System.Text.StringBuilder($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\">");
                for (int i = 0; i < colors.Length; i++) g.Append($"<stop offset=\"{F(stops[i])}\" stop-color=\"{colors[i]}\"/>");
                s.Def(g.Append("</linearGradient>").ToString());
                string Stroke(string c, float width) => $"stroke=\"{c}\" stroke-width=\"{F(width / k)}\" stroke-linejoin=\"round\"";
                s.Glyphs(shown, x + start, y + baseline + DropPx, Display, Size, LetterSpacing, OutlineDeepColor, Stroke(OutlineDeepColor, Halo * 2));
                s.Glyphs(shown, x + start, y + baseline, Display, Size, LetterSpacing, OutlineColor, Stroke(OutlineColor, Halo * 2));
                s.Glyphs(shown, x + start, y + baseline, Display, Size, LetterSpacing, "#ffffff", Stroke("#ffffff", Outline * 2));
                s.Glyphs(shown, x + start, y + baseline, Display, Size, LetterSpacing, $"url(#{id})");
            }

            public string Markup() { var s = new UiSvg(W, H); Draw(s, 0, 0); return s.Markup; }
        }

        // ---- the result star (sort/Cards.js Star) ----------------------------------------------------------------------
        public const string STAR_D = "M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z";

        public static string Star(float size, bool earned) =>
            new UiSvg(size, size).Raw(
                $"<svg x=\"0\" y=\"0\" width=\"{F(size)}\" height=\"{F(size)}\" viewBox=\"0 0 24 24\" overflow=\"visible\">" +
                $"<path d=\"{STAR_D}\" fill=\"{(earned ? "#b86200" : "rgba(107,68,38,0.25)")}\" transform=\"translate(0 1.2)\" stroke-linejoin=\"round\"/>" +
                $"<path d=\"{STAR_D}\" fill=\"{(earned ? "#ffd23a" : "rgba(255,255,255,0.7)")}\" stroke=\"#ffffff\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/>" +
                (earned ? "<path d=\"M8 9.6 L10.4 9.2 L11.3 7\" stroke=\"#fff6c4\" stroke-width=\"1.4\" stroke-linecap=\"round\" fill=\"none\"/>" : "") +
                "</svg>").Markup;

        // ---- Decor.js RaysArt: wedges filled with a radial fade ----------------------------------------------------------
        /// <summary>`fadeSize`: the size whose fade it takes (Fx.LikeWeb), its own by default.</summary>
        public static string Rays(float size, float rayDeg = 8, float gapDeg = 14, float opacity = 0.45f, float fadeStart = 0.15f, float fadeEnd = 0.65f, string color = "#ffffff", float fadeSize = 0)
        {
            double c = size / 2.0, fc = fadeSize > 0 ? fadeSize / 2.0 : c;
            double step = rayDeg + gapDeg;
            int n = (int)JsRound(360 / step);
            var s = new UiSvg(size, size);
            s.Def($"<radialGradient id=\"rayFade\" cx=\"{F(fc)}\" cy=\"{F(fc)}\" r=\"{F(fc)}\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"{F(fadeStart)}\" stop-color=\"{color}\" stop-opacity=\"{F(opacity)}\"/><stop offset=\"{F(fadeEnd)}\" stop-color=\"{color}\" stop-opacity=\"0\"/></radialGradient>");
            var sb = new System.Text.StringBuilder("<g>");
            for (int i = 0; i < n; i++)
            {
                double a0 = i * (360.0 / n), a1 = a0 + rayDeg;
                double Rad(double a) => (a - 90) * Math.PI / 180;
                string P(double v) => v.ToString("0.00", CultureInfo.InvariantCulture);
                sb.Append($"<path d=\"M{F(c)} {F(c)} L{P(c + c * Math.Cos(Rad(a0)))} {P(c + c * Math.Sin(Rad(a0)))} A{F(c)} {F(c)} 0 0 1 {P(c + c * Math.Cos(Rad(a1)))} {P(c + c * Math.Sin(Rad(a1)))} Z\" fill=\"url(#rayFade)\"/>");
            }
            s.Raw(sb.Append("</g>").ToString());
            return s.Markup;
        }

        static double JsRound(double v) => Math.Floor(v + 0.5);

        // ---- ui.js Head: a creature's still in a sticker circle -----------------------------------------------------------
        public static void Head(UiSvg s, float x, float y, float size, string picture, string ring = "#ffffff", string bg = "#f6efff", bool dim = false)
        {
            float pad = size * 0.06f, inner = size - 2 * pad;
            s.Box(x, y, size, size, new BoxStyle { Background = ring, Radius = size });
            s.Box(x + pad, y + pad, inner, inner, new BoxStyle { Background = bg, Radius = size });
            if (picture == null) return;
            var clip = s.NewId("hc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x + pad, y + pad, inner, inner, new[] { size, size, size, size })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            float iw = inner * 0.92f;
            s.Image(picture, x + pad + (inner - iw) / 2, y + pad + (inner - iw) / 2, iw, iw, "xMidYMid meet", dim ? 0.25f : 1);
            s.Close();
        }

        // ---- Overlays.js Overlay: the card (a brown rim, a white ring, the cream fill) -----------------------------------
        public static void Frame(UiSvg s, float w, float fillH)
        {
            float h = fillH + 17;
            s.Box(0, 0, w, h, new BoxStyle { Background = "#6b4426", Radius = 30 });
            s.Box(3, 3, w - 6, fillH + 6, new BoxStyle { Background = "#ffffff", Radius = 27 });
            s.Box(6, 6, w - 12, fillH, new BoxStyle { Gradient = new[] { "#fffaf0", "#fff1dc", "#f6e2c4" }, GradientStops = new[] { 0f, 0.55f, 1 }, Radius = 24 });
        }

        // ---- Overlays.js XpBar: LV badge, the track, "XP" (260 x 30); the fill is its own piece -------------------------
        public const float XpW = 260, XpH = 30;
        const float TrackX = 38, TrackY = 8, TrackH = 14;   // (the track: XpBar(w) - 100 wide)

        /// <summary>The bar `w` wide (xpRow: the badge 30, the track, "XP" 54, 8 dp apart).</summary>
        public static string XpBar(double level, float w = XpW)
        {
            float TrackW = w - 30 - 54 - 16;
            var s = new UiSvg(w, XpH);
            s.Box(0, 0, 30, 30, new BoxStyle { Background = "#b8641c", Radius = 15, BorderWidth = 2.5f, BorderColor = "#ffffff" });
            var lt = Style(Display, 14, "#ffffff");
            s.Text(((long)level).ToString(CultureInfo.InvariantCulture), 2.5f, 2.5f + (25 - UiSvg.LineBox(lt)) / 2, lt, 25, 0.5f);
            s.Box(TrackX, TrackY, TrackW, TrackH, new BoxStyle { Background = "rgba(107,68,38,0.18)", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            var xt = Style(Display, 9.5f, "#9a6a3a");
            s.Text("XP", TrackX + TrackW + 8, (XpH - UiSvg.LineBox(xt)) / 2, xt);
            return s.Markup;
        }

        /// <summary>The fill: `frac` of the track's inside, its gradient across its own width, clipped by the track.</summary>
        public static string XpFill(double frac, float width = XpW)
        {
            float TrackW = width - 30 - 54 - 16;
            var s = new UiSvg(width, XpH);
            float x = TrackX + 2, y = TrackY + 2, w = (float)(frac * (TrackW - 4)), h = TrackH - 4;
            if (w <= 0) return s.Markup;
            var clip = s.NewId("xc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x, y, TrackW - 4, h, new[] { 997f, 997, 997, 997 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(x, y, w, h, new BoxStyle { Gradient = new[] { "#ffe08a", "#f0a21c" }, GradientAngle = 90, Radius = 999 });
            s.Close();
            return s.Markup;
        }

        // ---- Overlays.js levelUp: "LEVEL n!" and its line in a brown box (the lines rock inside) --------------------------
        public static readonly TextStyle LevelUpText = Style(Display, 17, "#ffffff");
        public static readonly TextStyle LevelUpSub = Style(Heavy, 11, "#ffe9cc");
        public static readonly TextStyle LevelUpTextSmall = Style(Display, 13, "#ffffff");
        public static readonly TextStyle LevelUpSubSmall = Style(Heavy, 9, "#ffe9cc");

        // ---- ui.js SdButton -------------------------------------------------------------------------------------------
        public static readonly Dictionary<string, (string ring, string[] colors)> BTN = new Dictionary<string, (string, string[])>
        {
            ["pink"] = ("#8a3a0e", new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }),
            ["gold"] = ("#9c4d06", new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }),
            ["green"] = ("#0d7a4a", new[] { "#b8ffd9", "#3ddc97", "#16a86a" }),
            ["blue"] = ("#1d4f9a", new[] { "#d6f3ff", "#5fb8ff", "#2f7fd6" }),
            ["cyan"] = ("#0c5a9c", new[] { "#b0fbff", "#3fd7f6", "#1695d6" }),
            ["purple"] = ("#6b4426", new[] { "#f6d9b0", "#d9a066", "#a86e3a" }),
            ["white"] = ("#6b4426", new[] { "#ffffff", "#fff6e8", "#f3dfbd" }),
            ["grey"] = ("#8a7a6a", new[] { "#efe6dc", "#d6c8b8", "#bfae9c" }),
            ["red"] = ("#8e1030", new[] { "#ffc2cc", "#ff5c7a", "#e01e4a" }),
        };

        /// <summary>An SdButton with a BtnLabel: `kind` its colours, `size` the label's, the face's padding (the card
        /// styles: smallFace 14 x 10, bigFace 22 x 12, wideFace 18 x 12), `width` when it's stretched.</summary>
        public sealed class ButtonLook
        {
            public string Kind = "pink", Label = "";
            public float Size = 17, PadH = 18, PadV = 9;
            public bool Disabled;
            public float? Width;
            /// <summary>A fixed face height (faceStyle height: the result card's trioFace, 48), the label centred in it.</summary>
            public float? FaceHeight;
            public const float Lip = 5;

            public ButtonLook(string kind, string label, float size, float padH, float padV, float? width = null)
            { Kind = kind; Label = label; Size = size; PadH = padH; PadV = padV; Width = width; }

            TextStyle LabelStyle => Kind == "white"
                ? Style(Display, Size, "#6b4426")
                : new TextStyle { Font = Display, Size = Size, Color = "#ffffff", Shadows = Outline3(BTN.TryGetValue(Kind, out var b) ? b.ring : BTN["pink"].ring, 2) };

            public float FaceW => Width.HasValue ? Width.Value - 5 : UiSvg.BoxWidth(Label, LabelStyle) + 2 * PadH + 6;
            public float FaceH => FaceHeight ?? UiSvg.LineBox(LabelStyle) + 2 * PadV + 6;
            public float RingW => FaceW + 5;
            public float RingH => FaceH + 5;
            /// <summary>The whole button: the ring and the lip under it.</summary>
            public float W => RingW;
            public float H => RingH + Lip;

            (string ring, string[] colors) Colors => BTN[Disabled ? "grey" : BTN.ContainsKey(Kind) ? Kind : "pink"];

            /// <summary>The lip (RingW x RingH, shown Lip dp below the ring's top; pressed, it shrinks with the face).</summary>
            public string LipMarkup() => new UiSvg(RingW, RingH).Box(0, 0, RingW, RingH, new BoxStyle { Background = Colors.ring, Radius = 999 }).Markup;

            /// <summary>The ring with the face in it (pressed, the whole button shrinks to 0.92: CardFx Press): RingW x RingH.</summary>
            public string FaceMarkup()
            {
                var c = Colors;
                float fw = FaceW, fh = FaceH;
                var s = new UiSvg(RingW, RingH);
                s.Box(0, 0, RingW, RingH, new BoxStyle { Background = c.ring, Radius = 999 });
                s.Box(2.5f, 2.5f, fw, fh, new BoxStyle { Background = "#ffffff", Radius = 999 });
                // the gradient fills the padding box (inside the white border); the shine and label are clipped to it
                float px = 5.5f, py = 5.5f, pw = fw - 6, ph = fh - 6;
                s.Box(px, py, pw, ph, new BoxStyle { Gradient = c.colors, GradientStops = new[] { 0f, 0.5f, 1 }, Radius = 999 });
                var clip = s.NewId("bc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, py, pw, ph, new[] { 996f, 996, 996, 996 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Box(px + pw * 0.08f, py + 2, pw * 0.84f, ph * 0.42f, new BoxStyle { Background = "rgba(255,255,255,0.45)", Radius = 999 });
                s.Close();
                s.Text(Label, px + PadH, FaceHeight.HasValue ? py + (ph - UiSvg.LineBox(LabelStyle)) / 2 : py + PadV, LabelStyle, pw - 2 * PadH, 0.5f);
                return s.Markup;
            }
        }

        /// <summary>ShadowText's outline3: hard copies 2 dp down, 1 dp right and 1 dp left (the first on top).</summary>
        public static Shadow[] Outline3(string color, float down = 2) => new[] { new Shadow(color, 0, down, 0), new Shadow(color, 1, 0, 0), new Shadow(color, -1, 0, 0) };
    }
}
