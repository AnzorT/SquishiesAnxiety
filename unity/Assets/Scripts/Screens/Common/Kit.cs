// The app's shared pieces these screens are built from, drawn as SVG the way tools/unity/ui/snap.js writes what Chrome
// paints (UiSvg), with the components' own numbers:
//   royal/  Lettering (the menu's gradient lettering), Plaque (wood / gold / pearl panels and buttons), Btn, Icon,
//           InkText, PageBg, WoodBg, the orbs (cut out by tools/unity/export-screens.mjs)
//   candy/  CandyButton, CandyProgress, Shine, ShadowText / outline3, HaloText, ToggleSwitch, RaysArt
//   squad/  CandyBtn + BtnText, CoinIcon / GemIcon
// Sizes are dp (the royal screens: the design's 393-tall units, Stage). Chrome draws a border at whole px (2.5 → 2),
// as FlexNode.Bw says; layouts here use the same widths.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Screens
{
    public static class Kit
    {
        public const string Display = "Fredoka_700Bold", DisplaySemi = "Fredoka_600SemiBold", DisplayMedium = "Fredoka_500Medium";
        public const string Body = "Nunito_700Bold", Heavy = "Nunito_800ExtraBold", Black = "Nunito_900Black";
        public const string INK = "#6b4426", CREAM = "#fff6e2";
        public static float Bw(float w) => FlexNode.Bw(w);
        public static string F(double v) => UiSvg.F(v);

        public static TextStyle T(string font, float size, string color, float ls = 0, float lh = 0, Shadow[] shadows = null) =>
            new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = ls, LineHeight = lh, Shadows = shadows };
        /// <summary>ShadowText's outline3: copies `down` dp down, 1 dp right and left (the first on top).</summary>
        public static Shadow[] Outline3(string c, float down = 2) => new[] { new Shadow(c, 0, down, 0), new Shadow(c, 1, 0, 0), new Shadow(c, -1, 0, 0) };
        /// <summary>A text-shadow with no blur (textShadowRadius 0.1).</summary>
        public static Shadow[] Drop(string c, float dy) => new[] { new Shadow(c, 0, dy, 0) };
        /// <summary>royal/theme.js TX_W: white text with the ink outline.</summary>
        public static readonly Shadow[] TX_W = { new Shadow(INK, 0, 1.6f, 0), new Shadow(INK, 1.2f, 0, 0), new Shadow(INK, -1.2f, 0, 0), new Shadow(INK, 0, -1.2f, 0), new Shadow(INK, 1, 1, 0), new Shadow(INK, -1, 1, 0) };
        public static TextStyle Ink(float size, string font = Display) => T(font, size, "#ffffff", 0, 0, TX_W);
        /// <summary>OutlinedTitle.js HaloText: white Fredoka with a soft brown drop (textShadow 0 2 2).</summary>
        public static TextStyle Halo(float size, float ls = 0, string font = Display) => T(font, size, "#ffffff", ls, 0, new[] { new Shadow(INK, 0, 2, 2) });

        public static float W(string text, TextStyle t) => string.IsNullOrEmpty(text) ? 0 : UiSvg.BoxWidth(text, t);
        public static float LH(TextStyle t) => UiSvg.LineBox(t);

        // ---- exported pieces ----------------------------------------------------------------------------------------
        static readonly Dictionary<string, string> Xmls = new Dictionary<string, string>();
        static int _embeds;
        /// <summary>Resources/Screens/&lt;name&gt;.xml (export-screens.mjs).</summary>
        public static string Xml(string name)
        {
            if (Xmls.TryGetValue(name, out var x)) return x;
            x = Roster.ReadText?.Invoke("Screens/" + name) ?? throw new InvalidOperationException($"Resources/Screens/{name}.xml is missing: run node tools/unity/export-screens.mjs");
            return Xmls[name] = x;
        }

        static readonly Regex Size = new Regex("width=\"([\\d.]+)\" height=\"([\\d.]+)\"");
        /// <summary>An exported piece (its own box w0 x h0) drawn into the box x, y, w, h (null: its own size); its ids
        /// made unique.</summary>
        public static void Embed(UiSvg s, string name, float x, float y, float w = -1, float h = -1)
        {
            var svg = Xml(name);
            var m = Size.Match(svg);
            float w0 = float.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture), h0 = float.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
            if (w < 0) { w = w0; h = h0; }
            int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>", StringComparison.Ordinal);
            var pre = "x" + (_embeds++) + "-";
            var inner = svg.Substring(a, b - a).Replace("id=\"", "id=\"" + pre).Replace("href=\"#", "href=\"#" + pre).Replace("url(#", "url(#" + pre);
            s.Raw($"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w0)} {F(h0)}\" overflow=\"visible\" preserveAspectRatio=\"none\">{inner}</svg>");
        }

        // ---- royal/Lettering.js -------------------------------------------------------------------------------------
        sealed class LetterLook { public string[] F; public string O; public bool Wht; public bool H; }
        static readonly Dictionary<string, LetterLook> LETTERING = new Dictionary<string, LetterLook>
        {
            ["gold"] = new LetterLook { F = new[] { "#fffbe6", "#ffe57e", "#ffbe2e", "#f08c10" }, O = INK, Wht = true },
            ["goldB"] = new LetterLook { F = new[] { "#fffbe6", "#ffe57e", "#ffbe2e", "#f08c10" }, O = "#4a1f04" },
            ["white"] = new LetterLook { F = new[] { "#ffffff", "#ffffff", "#fff6e2", "#ffe6b8" }, O = INK },
            ["whiteB"] = new LetterLook { F = new[] { "#ffffff", "#ffffff", "#fff6e2", "#ffe6b8" }, O = "#6a2c00" },
            ["wood"] = new LetterLook { F = new[] { "#fffbea", "#ffe9b8", "#f2c27a", "#d08a3c" }, O = "#3a1e0a" },
        };

        // react-native-svg on Android drops an I after an A: the app puts a hair space (U+200A) between them, which no
        // font here has; Chrome draws it 1/16 em wide (Fredoka's fallback), and it breaks the pair's kerning
        public const char HAIR = '\u200A';
        static string Safe(string t) => t.Replace("AI", "A" + HAIR + "I");
        /// <summary>A run's width with hair spaces in it (SVG text's: advances, kerning, letter-spacing).</summary>
        public static float SafeW(string t, TextStyle st)
        {
            float w = 0;
            var parts = t.Split(HAIR);
            for (int i = 0; i < parts.Length; i++)
            {
                if (i > 0) w += st.Size * 0.0625f + st.LetterSpacing;
                w += W(parts[i], st);
            }
            return w;
        }
        /// <summary>UiSvg.Glyphs for a run with hair spaces in it.</summary>
        public static void SafeGlyphs(UiSvg s, string t, float x, float baseline, string font, float size, float ls, string fill, string attrs = null)
        {
            var parts = t.Split(HAIR);
            var st = T(font, size, "#000", ls);
            for (int i = 0; i < parts.Length; i++)
            {
                if (i > 0) x += size * 0.0625f + ls;
                if (parts[i].Length > 0) s.Glyphs(parts[i], x, baseline, font, size, ls, fill, attrs);
                x += W(parts[i], st);
            }
        }

        /// <summary>candy/OutlinedTitle.js (Ui/Cards/CardArt.Title, with the hair space drawn as Chrome draws it): the
        /// sticker title, its box's top-left at (x, y).</summary>
        public static (float w, float h) OutlinedTitleSize(string text, float size, float outline, float ring, float drop, float ls)
        {
            float halo = outline + ring;
            return ((float)Math.Ceiling(W(text, T(Display, size, "#000", ls)) + halo * 2 + 2 + size * 0.12), (float)Math.Ceiling(size * 1.22 + halo * 2 + drop));
        }

        public static void OutlinedTitle(UiSvg s, string text, string fill, float size, float outline, float ring, float drop, float ls, float x, float y)
        {
            var (colors, stops) = Ui.Cards.CardArt.TITLE_FILLS.TryGetValue(fill, out var tf) ? tf : Ui.Cards.CardArt.TITLE_FILLS["pink"];
            float halo = outline + ring;
            var (w, _) = OutlinedTitleSize(text, size, outline, ring, drop, ls);
            var shown = Safe(text);
            var st = T(Display, size, "#000", ls);
            float start = w / 2 - SafeW(shown, st) / 2, baseline = halo + size * 0.96f;
            var font = UiFont.Get(Display);
            double k = (double)size / font.UnitsPerEm;
            double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
            var id = s.NewId("ot");
            var g = new StringBuilder($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\">");
            for (int i = 0; i < colors.Length; i++) g.Append($"<stop offset=\"{F(stops[i])}\" stop-color=\"{colors[i]}\"/>");
            s.Def(g.Append("</linearGradient>").ToString());
            string Stroke(string c, float wd) => $"stroke=\"{c}\" stroke-width=\"{F(wd / k)}\" stroke-linejoin=\"round\"";
            float x0 = x + start, y0 = y + baseline;
            if (halo > 0)
            {
                SafeGlyphs(s, shown, x0, y0 + drop, Display, size, ls, "#3f2412", Stroke("#3f2412", halo * 2));
                SafeGlyphs(s, shown, x0, y0, Display, size, ls, INK, Stroke(INK, halo * 2));
            }
            if (outline > 0) SafeGlyphs(s, shown, x0, y0, Display, size, ls, "#ffffff", Stroke("#ffffff", outline * 2));
            SafeGlyphs(s, shown, x0, y0, Display, size, ls, $"url(#{id})");
        }
        /// <summary>The lettering's box (its &lt;svg&gt;): the word's width plus room for the outlines.</summary>
        public static (float w, float h) LetteringSize(string text, float size)
        {
            float sw = Math.Max(2.4f, size * 0.19f);
            float w0 = W(text, T(Display, size, "#000", size * 0.02f));
            return ((float)Math.Ceiling(w0 + sw * 2.4f + 4), (float)Math.Ceiling(size * 1.32f + sw));
        }

        /// <summary>Draws Lettering with its box's top-left at (x, y).</summary>
        public static void Lettering(UiSvg s, string text, string variant, float size, float x, float y)
        {
            var S = LETTERING.TryGetValue(variant, out var l) ? l : LETTERING["white"];
            float sw = Math.Max(2.4f, size * 0.19f), ls = size * 0.02f;
            var (width, _) = LetteringSize(text, size);
            float baseline = size * 0.98f + sw / 2;
            var t = Safe(text);
            var font = UiFont.Get(Display);
            double k = (double)size / font.UnitsPerEm;
            float start = width / 2 - SafeW(t, T(Display, size, "#000", ls)) / 2;
            // the fill's gradient spans the text's box (objectBoundingBox: the font's ascent to its descent), in the
            // glyphs' own units, as Ui/Cards/CardArt.Title does
            double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
            var id = s.NewId("lt");
            var g = new StringBuilder($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\">");
            int n = S.F.Length - 1;
            for (int i = 0; i < S.F.Length; i++) g.Append($"<stop offset=\"{((double)i / n).ToString("0.00", CultureInfo.InvariantCulture)}\" stop-color=\"{S.F[i]}\"/>");
            s.Def(g.Append("</linearGradient>").ToString());
            string Stroke(string c, double w, string extra = "") => $"stroke=\"{c}\" stroke-width=\"{F(w / k)}\" stroke-linejoin=\"round\"{extra}";
            float x0 = x + start, y0 = y + baseline;
            if (S.Wht) SafeGlyphs(s, t, x0, y0, Display, size, ls, "#ffffff", Stroke("#ffffff", sw * 2.1));
            SafeGlyphs(s, t, x0, y0 + size * 0.06f, Display, size, ls, S.O, Stroke(S.O, sw * 1.25));
            SafeGlyphs(s, t, x0, y0, Display, size, ls, S.O, Stroke(S.O, sw));
            SafeGlyphs(s, t, x0, y0, Display, size, ls, $"url(#{id})");
            SafeGlyphs(s, t, x0, y0 - size * 0.03f, Display, size, ls, "none", Stroke("rgba(255,255,255,0.55)", size * 0.035));
        }

        // ---- royal/Plaque.js ----------------------------------------------------------------------------------------
        sealed class PlaqueLook { public string[] Fill; public float[] Stops; public float Angle = 180; public string[] Rim; public float[] RimStops; public float Gloss; public bool Sparkles, Stripes; }
        static readonly string[] RIM_C = { "#fffbe2", "#ffdd6e", "#f2ac2c", "#b8680c", "#ffd474" };
        static readonly float[] RIM_S = { 0, 0.24f, 0.55f, 0.82f, 1 };
        static readonly Dictionary<string, PlaqueLook> PLAQUES = new Dictionary<string, PlaqueLook>
        {
            ["vel"] = new PlaqueLook { Fill = new[] { "#e6b47c", "#cf955a", "#b47a42" }, Stops = new[] { 0f, 0.55f, 1 }, Rim = new[] { "#f8dcae", "#d9a066", "#a86e3a" }, RimStops = new[] { 0f, 0.5f, 1 }, Stripes = true },
            ["gold"] = new PlaqueLook { Fill = new[] { "#fff1b0", "#ffd650", "#f6a524", "#ffc84a" }, Stops = new[] { 0f, 0.4f, 0.76f, 1 }, Rim = new[] { "#fffbe8", "#e9a530", "#8a4a06" }, RimStops = new[] { 0f, 0.6f, 1 }, Gloss = 0.6f, Sparkles = true },
            ["pearl"] = new PlaqueLook { Fill = new[] { "#ffffff", "#fff6e6", "#f6e2c0" }, Stops = new[] { 0f, 0.45f, 1 }, Rim = new[] { "#f8dcae", "#d9a066", "#a86e3a" }, RimStops = new[] { 0f, 0.5f, 1 } },
            ["wood"] = new PlaqueLook { Fill = new[] { "#e9b97c", "#c4874a", "#8c5426" }, Stops = new[] { 0f, 0.45f, 1 }, Rim = new[] { "#ffe3b0", "#a8692e", "#5a3010" }, RimStops = new[] { 0f, 0.6f, 1 }, Stripes = true },
        };
        static readonly float[][] SPARK = { new[] { 0.14f, 0.28f, 1.2f, 0.95f }, new[] { 0.63f, 0.72f, 1.1f, 0.85f }, new[] { 0.86f, 0.22f, 1.3f, 0.9f }, new[] { 0.36f, 0.8f, 1f, 0.7f } };
        static readonly float[] GRAIN = { 0.08f, 0.2f, 0.33f, 0.47f, 0.6f, 0.74f, 0.87f };

        static float[] R4(float r) => new[] { r, r, r, r };

        /// <summary>A plaque in the box x, y, w, h: its lip and ink outline (round it), its rim and its fill.</summary>
        public static void Plaque(UiSvg s, float x, float y, float w, float h, string variant = "vel", float radius = 999, float rim = 2.5f, float ring = 1.6f, float lip = 3)
        {
            var P = PLAQUES.TryGetValue(variant, out var p) ? p : PLAQUES["vel"];
            s.Box(x - ring, y - ring + lip, w + 2 * ring, h + 2 * ring, new BoxStyle { Radius = radius + ring, Background = INK });
            s.Box(x - ring, y - ring, w + 2 * ring, h + 2 * ring, new BoxStyle { Radius = radius + ring, Background = INK });
            s.Box(x, y, w, h, new BoxStyle { Radius = radius, Gradient = P.Rim, GradientStops = P.RimStops });
            float ix = x + rim, iy = y + rim, iw = w - 2 * rim, ih = h - 2 * rim, ir = Math.Max(0, radius - rim);
            if (iw <= 0 || ih <= 0) return;
            var clip = s.NewId("pc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(ix, iy, iw, ih, R4(ir))}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(ix, iy, iw, ih, new BoxStyle { Gradient = P.Fill, GradientStops = P.Stops, GradientAngle = P.Angle });
            if (P.Gloss > 0) s.Box(ix, iy, iw, ih, new BoxStyle { Gradient = new[] { $"rgba(255,255,255,{F(P.Gloss)})", "rgba(255,255,255,0)" }, GradientStops = new[] { 0f, 0.46f } });
            if (P.Sparkles)
                for (int i = 0; i < SPARK.Length; i++)
                {
                    var sp = SPARK[i];
                    float r = sp[2];
                    s.Box(ix + iw * sp[0] - r, iy + ih * sp[1] - r, 2 * r, 2 * r, new BoxStyle { Radius = r, Background = i == 2 ? "#fff6c8" : "#ffffff", Opacity = sp[3] });
                }
            if (P.Stripes)
                foreach (var gx in GRAIN) s.Box(ix + iw * gx, iy, 2, ih, new BoxStyle { Background = "rgba(107,68,38,0.09)" });
            float sh = ih * 0.15f;
            s.Box(ix, iy + ih - sh, iw, sh, new BoxStyle { Gradient = new[] { "rgba(60,30,10,0)", "rgba(60,30,10,0.3)" } });
            s.Box(ix, iy, iw, 1.5f, new BoxStyle { Background = "rgba(255,255,255,0.55)" });
            s.Close();
        }

        /// <summary>Plaque.js Glow: the pulsing gold glow behind a button (its box; drawn `spread` round it).</summary>
        public static string Glow(float w, float h, float radius = 16, float spread = 10)
        {
            float gw = w + 2 * spread, gh = h + 2 * spread;
            var s = new UiSvg(gw, gh);
            var id = s.NewId("gl");
            s.Def($"<radialGradient id=\"{id}\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0.55\" stop-color=\"#ffd66e\" stop-opacity=\"0.9\"/><stop offset=\"1\" stop-color=\"#ffd66e\" stop-opacity=\"0\"/></radialGradient>");
            float rx = radius + spread;
            s.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(gw)}\" height=\"{F(gh)}\" rx=\"{F(rx)}\" fill=\"url(#{id})\"/>");
            return s.Markup;
        }

        /// <summary>royal/parts.js Icon: a 24 x 24 stroke icon with the ink drop under it, `size` across at (x, y).</summary>
        public static void Icon(UiSvg s, string d, float x, float y, float size = 20, string color = "#ffffff", float width = 2.5f, bool drop = true)
        {
            var inner = (drop ? $"<path d=\"{d}\" stroke=\"{INK}\" stroke-width=\"{F(width)}\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" transform=\"translate(0, 1.4)\"/>" : "")
                + $"<path d=\"{d}\" stroke=\"{color}\" stroke-width=\"{F(width)}\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>";
            s.Drawing(inner, x, y, size, size, "0 0 24 24");
        }

        // ---- backgrounds --------------------------------------------------------------------------------------------
        /// <summary>royal/parts.js PageBg: the amber gradient and the rays picture stretched over the screen.</summary>
        public static string PageBg(float w, float h)
        {
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Background = "#d27c3e" });
            s.Box(0, 0, w, h, new BoxStyle { Gradient = new[] { "#ffd98e", "#f3a95c", "#d27c3e", "#a95a2a" }, GradientStops = new[] { 0f, 0.4f, 0.8f, 1 } });
            s.Image("Screens/img/rays", 0, 0, w, h, "none");
            return s.Markup;
        }

        /// <summary>royal/parts.js WoodBg: the planks picture covering the screen.</summary>
        public static string WoodBg(float w, float h, float clipY = 0, float clipH = -1)
        {
            var s = new UiSvg(w, clipH < 0 ? h : clipH);
            if (clipH >= 0)
            {
                var c = s.NewId("wc");
                s.Def($"<clipPath id=\"{c}\"><rect x=\"0\" y=\"0\" width=\"{F(w)}\" height=\"{F(clipH)}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{c})\"");
            }
            if (clipY != 0) s.Open($"transform=\"translate(0 {F(-clipY)})\"");
            s.Box(0, 0, w, h, new BoxStyle { Background = "#cf955a" });
            s.Image("Screens/img/wood-bg", 0, 0, w, h, "xMidYMid slice");
            if (clipY != 0) s.Close();
            if (clipH >= 0) s.Close();
            return s.Markup;
        }

        // ---- candy/CandyButton.js -----------------------------------------------------------------------------------
        public sealed class ButtonSize { public float PadV, PadH, Font, Ring, Border, Lip; }
        public static readonly Dictionary<string, ButtonSize> SIZES = new Dictionary<string, ButtonSize>
        {
            ["lg"] = new ButtonSize { PadV = 14, PadH = 40, Font = 19, Ring = 2.5f, Border = 3, Lip = 5 },
            ["md"] = new ButtonSize { PadV = 11, PadH = 24, Font = 16, Ring = 2.5f, Border = 3, Lip = 5 },
            ["sm"] = new ButtonSize { PadV = 5, PadH = 14, Font = 13, Ring = 2, Border = 3, Lip = 4 },
            ["xs"] = new ButtonSize { PadV = 3, PadH = 11, Font = 12, Ring = 2, Border = 2.5f, Lip = 3 },
        };
        public static readonly Dictionary<string, (string[] colors, float[] stops, string ring)> VARIANTS = new Dictionary<string, (string[], float[], string)>
        {
            ["pink"] = (new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }, new[] { 0f, 0.55f, 1 }, "#8a3a0e"),
            ["blue"] = (new[] { "#b0fbff", "#3fd7f6", "#1695d6" }, new[] { 0f, 0.55f, 1 }, "#0c5a9c"),
            ["gold"] = (new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, new[] { 0f, 0.5f, 1 }, "#9c4d06"),
            ["grey"] = (new[] { "#efe6dc", "#d6c8b8", "#bfae9c" }, new[] { 0f, 0.55f, 1 }, "#8a7a6a"),
            ["purple"] = (new[] { "#f6d9b0", "#d9a066", "#a86e3a" }, new[] { 0f, 0.5f, 1 }, "#6b4426"),
        };

        /// <summary>A CandyButton's look and box: the caption, its size class and variant (`font`: textStyle's size).</summary>
        public sealed class CandyButton
        {
            public string Label, Variant;
            public ButtonSize Sz;
            public float FontSize;
            public CandyButton(string label, string variant, string size, float fontSize = 0)
            { Label = label; Variant = variant; Sz = SIZES[size]; FontSize = fontSize > 0 ? fontSize : Sz.Font; }

            public string Ring => VARIANTS[Variant].ring;
            public TextStyle Text => T(Display, FontSize, "#ffffff", 1, 0, Outline3(Ring));
            float RingW => Bw(Sz.Ring);
            float BorderW => Bw(Sz.Border);
            /// <summary>The ring's box (the face and its rings), and the whole button with the lip under it.</summary>
            public float FaceW => W(Label, Text) + 2 * Sz.PadH + 2 * BorderW + 2 * RingW;
            public float FaceH => LH(Text) + 2 * Sz.PadV + 2 * BorderW + 2 * RingW;
            public float H => FaceH + Sz.Lip;

            /// <summary>The lip (stays put): the ring's colour, Lip dp down.</summary>
            public string LipSvg() => new UiSvg(FaceW, H).Box(0, Sz.Lip, FaceW, FaceH, new BoxStyle { Radius = 999, Background = Ring }).Markup;

            /// <summary>The ring, the white border, the face's gradient, its shine and the caption (FaceW x FaceH); with its
            /// shadow under it (box-shadow 0 8 10 rgba(50,0,100,0.45)).</summary>
            public string FaceSvg(bool shadow = true)
            {
                var v = VARIANTS[Variant];
                float w = FaceW, h = FaceH, rw = RingW, bw = BorderW;
                var s = new UiSvg(w, h);
                s.Box(0, 0, w, h, new BoxStyle { Radius = 999, Background = v.ring, Shadows = shadow ? new[] { new Shadow("rgba(50,0,100,0.45)", 0, 8, 10) } : null });
                s.Box(rw, rw, w - 2 * rw, h - 2 * rw, new BoxStyle { Radius = 999, Background = "#ffffff" });
                float px = rw + bw, py = rw + bw, pw = w - 2 * px, ph = h - 2 * py;
                FaceFill(s, px, py, pw, ph, v.colors, v.stops);
                s.Text(Label, px + Sz.PadH, py + Sz.PadV, Text);
                return s.Markup;
            }
        }

        /// <summary>A candy face: the vertical gradient in a pill and Shine over its top 44%.</summary>
        public static void FaceFill(UiSvg s, float x, float y, float w, float h, string[] colors, float[] stops, float shineTop = 0)
        {
            s.Box(x, y, w, h, new BoxStyle { Radius = 999, Gradient = colors, GradientStops = stops });
            Shine(s, x, y, w, h);
        }

        /// <summary>CandyButton.js Shine: the white gloss over the top of a face (its box x, y, w, h), clipped by it.</summary>
        public static void Shine(UiSvg s, float x, float y, float w, float h, float inset = 0, float heightFrac = 0.44f, float radius = 999, float clipRadius = 999)
        {
            var clip = s.NewId("sc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x, y, w, h, R4(clipRadius))}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(x + inset, y, w - 2 * inset, h * heightFrac, new BoxStyle { Radius = radius, Gradient = new[] { "rgba(255,255,255,0.85)", "rgba(255,255,255,0.1)" } });
            s.Close();
        }

        // ---- candy/Decor.js CandyProgress -----------------------------------------------------------------------------
        /// <summary>The bar in the box x, y, w (its height: height + 4): ring, white rim, the track, the fill at pct.</summary>
        public static void Progress(UiSvg s, float x, float y, float w, float pct, float height, string ring, string[] fill, bool horizontal = true, string track = "rgba(80,12,140,0.45)")
        {
            float H = height + 4;
            s.Box(x, y, w, H, new BoxStyle { Radius = height, Background = ring });
            float tx = x + 2, ty = y + 2, tw = w - 4, th = height, bw = Bw(2.5f);
            s.Box(tx, ty, tw, th, new BoxStyle { Radius = height, Background = track, BorderWidth = bw, BorderColor = "#ffffff" });
            float ix = tx + bw, iy = ty + bw, iw = tw - 2 * bw, ih = th - 2 * bw;
            float fw = iw * Math.Max(0, Math.Min(100, pct)) / 100;
            if (fw <= 0 || ih <= 0) return;
            var clip = s.NewId("pg");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(ix, iy, iw, ih, R4(height - bw))}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(ix, iy, fw, ih, new BoxStyle { Radius = height, Gradient = fill, GradientAngle = horizontal ? 90 : 180 });
            s.Close();
        }

        /// <summary>A flat bar (the royal screens' wBar, the sheet's bars): a track with a border, and a gradient fill
        /// `pct` of its inside, clipped to it.</summary>
        public static void Bar(UiSvg s, float x, float y, float w, float h, float pct, string bg, float border, string borderColor, float radius, string[] fill, float[] stops = null, float fillRadius = -1)
        {
            float bw = Bw(border);
            s.Box(x, y, w, h, new BoxStyle { Radius = radius, Background = bg, BorderWidth = bw, BorderColor = borderColor });
            float ix = x + bw, iy = y + bw, iw = w - 2 * bw, ih = h - 2 * bw;
            float fw = iw * pct / 100;
            if (fw <= 0) return;
            var clip = s.NewId("bc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(ix, iy, iw, ih, R4(Math.Max(0, radius - bw)))}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(ix, iy, fw, ih, new BoxStyle { Radius = fillRadius < 0 ? radius : fillRadius, Gradient = fill, GradientStops = stops });
            s.Close();
        }

        // ---- squad/ui.js CandyBtn + BtnText -----------------------------------------------------------------------
        public static readonly Dictionary<string, (string[] colors, string ring)> BTN = new Dictionary<string, (string[], string)>
        {
            ["gold"] = (new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, "#9c4d06"),
            ["pink"] = (new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }, "#8a3a0e"),
            ["blue"] = (new[] { "#d6f3ff", "#5fb8ff", "#2f7fd6" }, "#1d4f9a"),
            ["green"] = (new[] { "#b8ffd9", "#3ddc97", "#16a86a" }, "#0d7a4a"),
        };

        /// <summary>A Ringed candy button: the ring (lip under it) round the white-bordered face (its box fx, fy, fw, fh
        /// inside the w x h ring), the face's gradient and the white shine strip (ui.js s.shine).</summary>
        public static UiSvg CandyBtnBody(float w, float h, string kind, float lip)
        {
            var s = new UiSvg(w, h);
            CandyBtnBody(s, 0, 0, w, h, kind, lip);
            return s;
        }

        public static void CandyBtnBody(UiSvg s, float x, float y, float w, float h, string kind, float lip)
        {
            var (colors, ring) = BTN[kind];
            float rw = 2.5f, bw = Bw(3);
            s.Box(x, y, w, h, new BoxStyle { Radius = 999 + rw, Background = ring });
            float fx = x + rw, fy = y + rw, fw = w - 2 * rw, fh = h - 2 * rw - lip;
            s.Box(fx, fy, fw, fh, new BoxStyle { Radius = 999, Background = "#ffffff" });
            float px = fx + bw, py = fy + bw, pw = fw - 2 * bw, ph = fh - 2 * bw;
            s.Box(px, py, pw, ph, new BoxStyle { Radius = 999, Gradient = colors, GradientStops = new[] { 0f, 0.5f, 1 } });
            s.Box(px + pw * 0.09f, py + 2, pw * 0.82f, ph * 0.42f, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.45)" });
        }

        // ---- the Stage (royal/parts.js): the design's 393-tall units on the phone ------------------------------------
        /// <summary>The design units' scale on a screen `h` dp tall.</summary>
        public static float StageK(float screenW, float screenH) => Math.Min(screenW, screenH) / 393f;

        /// <summary>Pieces laid out in the Stage's units, as they land on the screen: each drawn at the screen's scale (a
        /// group scaled by k in a box k times its size), its transform's moves scaled by k.</summary>
        public static List<ScreenPiece> Staged(List<ScreenPiece> pieces, float k)
        {
            if (k == 1) return pieces;
            var sk = Affine.ScaleBy(k, k);
            var si = Affine.ScaleBy(1 / k, 1 / k);
            foreach (var p in pieces)
            {
                p.Transform = sk * p.Transform * si;
                if (p.Slot) { p.W *= k; p.H *= k; continue; }
                if (string.IsNullOrEmpty(p.Svg)) continue;
                int a = p.Svg.IndexOf('>') + 1, b = p.Svg.LastIndexOf("</svg>", StringComparison.Ordinal);
                float w = p.W * k, h = p.H * k;
                p.Svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w)} {F(h)}\" overflow=\"visible\"><g transform=\"scale({F(k)})\">{p.Svg.Substring(a, b - a)}</g></svg>";
                p.W = w; p.H = h; p.Margin *= k;
            }
            return pieces;
        }

        /// <summary>A piece: `svg` (a UiSvg) at (x, y) moved by `extra` (piece-local, about its own top-left).</summary>
        public static ScreenPiece Piece(string id, UiSvg svg, float x, float y, float opacity = 1, Affine? extra = null, float margin = 6) =>
            new ScreenPiece { Id = id, Svg = svg.Markup, W = svg.W, H = svg.H, Opacity = opacity, Margin = margin, Transform = Affine.Translate(x, y) * (extra ?? Affine.Identity) };

        public static ScreenPiece Piece(string id, string markup, float w, float h, float x, float y, float opacity = 1, Affine? extra = null, float margin = 6) =>
            new ScreenPiece { Id = id, Svg = markup, W = w, H = h, Opacity = opacity, Margin = margin, Transform = Affine.Translate(x, y) * (extra ?? Affine.Identity) };

        /// <summary>An RN transform about the box's centre (w x h): translate(cx, cy) * m * translate(-cx, -cy).</summary>
        public static Affine About(float w, float h, Affine m) => Affine.Translate(w / 2.0, h / 2.0) * m * Affine.Translate(-w / 2.0, -h / 2.0);

        /// <summary>A text box (dp) with the string drawn at its top-left.</summary>
        public static UiSvg TextBox(string text, TextStyle t)
        {
            var s = new UiSvg(Math.Max(1, W(text, t)), Math.Max(1, LH(t)));
            s.Text(text, 0, 0, t);
            return s;
        }

        /// <summary>Chrome's text-overflow: ellipsis (numberOfLines 1): the longest start of `text` that fits `maxW` with "…".</summary>
        public static string Ellipsize(string text, TextStyle t, float maxW)
        {
            if (W(text, t) <= maxW + 0.01f) return text;
            for (int n = text.Length - 1; n > 0; n--)
            {
                var c = text.Substring(0, n).TrimEnd() + "…";
                if (W(c, t) <= maxW + 0.01f) return c;
            }
            return "…";
        }
    }
}
