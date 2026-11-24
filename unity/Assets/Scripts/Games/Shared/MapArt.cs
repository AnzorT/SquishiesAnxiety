// The level map's pieces as SVG, drawn the way the UI exporter writes what Chrome painted (UiSvg), from
// src/sort/LevelMap.js's styles (units dp):
//   Node     a level's button: the lip, the ring, the gradient face in its white border with its shine, the number
//            with its shadow, the tier's dot; a lock on a locked one; the stars under a beaten one (60 x 60, 84 with stars)
//   Dots     three dots on the way to the next level, gold up to the current one
//   Banner   a band's sign: its words in the brown pill (wrapped to the sign's width, lines centred)
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;

namespace SquishSquad.Games.Shared
{
    public static class MapArt
    {
        public const float NODE = 60;
        public const string INK = "#5b3418";
        public const string Display = "Fredoka_700Bold", Heavy = "Nunito_800ExtraBold";
        public const string STAR_D = "M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z";
        static string F(double v) => UiSvg.F(v);
        static float Bw(float w) => FlexNode.Bw(w);

        static readonly TextStyle Num = new TextStyle { Font = Display, Size = 22, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 2, 1) } };
        static readonly TextStyle NumLocked = new TextStyle { Font = Display, Size = 22, Color = "#8f80a3", Shadows = new[] { new Shadow(INK, 0, 2, 1) } };

        /// <summary>The node's box height: 60, or 84 with its stars (marginTop 4, the big star 20).</summary>
        public static float NodeH(string state) => state == "done" ? NODE + 4 + 20 : NODE;

        public static string Node(int lv, string state, int stars, string tierColor)
        {
            float h = NodeH(state);
            var s = new UiSvg(NODE, h);
            string[] colors = state == "done" ? new[] { "#fff7b0", "#ffd23a", "#ff9c0a" } : state == "current" ? new[] { "#ffe2c8", "#ff9a4a", "#e0601c" } : new[] { "#f1ebe4", "#dacdbf", "#c2b2a1" };
            string ring = state == "done" ? "#9c4d06" : state == "current" ? "#8a3a0e" : "#7a6a8c";
            // the lip (5 dp down) and the ring
            s.Box(0, 5, NODE, NODE, new BoxStyle { Background = ring, Radius = NODE / 2 });
            s.Box(0, 0, NODE, NODE, new BoxStyle { Background = ring, Radius = NODE / 2 });
            // the face: 2.5 in, a white border; the gradient fills inside the border, the shine and the number are clipped to it
            float fx = 2.5f, fw = NODE - 5, b = Bw(3);
            s.Box(fx, fx, fw, fw, new BoxStyle { Background = "#ffffff", Radius = NODE / 2 });
            float px = fx + b, pw = fw - 2 * b;
            s.Box(px, px, pw, pw, new BoxStyle { Gradient = colors, GradientStops = new[] { 0f, 0.5f, 1 }, Radius = NODE / 2 - b });
            var clip = s.NewId("nc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, px, pw, pw, new[] { NODE / 2 - b, NODE / 2 - b, NODE / 2 - b, NODE / 2 - b })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(px + 8, px + 3, pw - 16, pw * 0.38f, new BoxStyle { Background = "rgba(255,255,255,0.5)", Radius = 99 });
            var t = state == "locked" ? NumLocked : Num;
            float lh = UiSvg.LineBox(t);
            s.Text(lv.ToString(), px, px + Snap((pw - lh) / 2), t, pw, 0.5f);
            // the tier's dot: 5 dp off the bottom, centred
            float dot = 8;
            s.Box(px + (pw - dot) / 2, px + pw - 5 - dot, dot, dot, new BoxStyle { Background = tierColor, Radius = 4, BorderWidth = Bw(1.5f), BorderColor = "#ffffff" });
            s.Close();
            if (state == "locked")
            {
                // the padlock: 6 dp over the top right; the shackle (no bottom border) over the body
                float lx = NODE + 6 - 26, ly = -6;
                float sw = Bw(3.5f);
                s.Box(lx + (26 - 14) / 2f, ly, 14, 14, new BoxStyle { Radius = 7, Borders = new[] { sw, sw, 0, sw }, BorderColor = "#7a6a8c" });
                s.Box(lx + (26 - 22) / 2f, ly + 14 - 3, 22, 15, new BoxStyle { Background = "#7a6a8c", Radius = 5, BorderWidth = Bw(2), BorderColor = "#ffffff" });
            }
            if (state == "done")
            {
                // three stars in a row (gap 1), the middle one bigger; the small ones 4 dp lower
                float x = (NODE - (16 + 1 + 20 + 1 + 16)) / 2, y = NODE + 4;
                for (int i = 0; i < 3; i++)
                {
                    float sz = i == 1 ? 20 : 16;
                    bool on = i < stars;
                    s.Raw($"<svg x=\"{F(x)}\" y=\"{F(y + (i == 1 ? 0 : 4))}\" width=\"{F(sz)}\" height=\"{F(sz)}\" viewBox=\"0 0 24 24\" overflow=\"visible\"><path d=\"{STAR_D}\" fill=\"{(on ? "#ffd23a" : "rgba(255,255,255,0.75)")}\" stroke=\"{(on ? "#b86200" : "#c9b9da")}\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></svg>");
                    x += sz + 1;
                }
            }
            return s.Markup;
        }

        static float Snap(double v) => (float)(Math.Floor(v * 64 + 1e-6) / 64);

        /// <summary>Three dots between two levels' centres, in a box from (x0, y0); returns the markup and its box.</summary>
        public static (string markup, float x0, float y0, float w, float h) Dots(float ax, float ay, float bx, float by, string color)
        {
            float x0 = Math.Min(ax, bx) - 4, y0 = Math.Min(ay, by) - 4, w = Math.Abs(bx - ax) + 8, h = Math.Abs(by - ay) + 8;
            var s = new UiSvg(w, h);
            for (int k = 1; k <= 3; k++)
            {
                float f = k / 4f;
                s.Box(ax + (bx - ax) * f - 4 - x0, ay + (by - ay) * f - 4 - y0, 8, 8, new BoxStyle { Background = color, Radius = 4 });
            }
            return (s.Markup, x0, y0, w, h);
        }

        // ---- a band's banner: Fredoka 14, letter-spacing 1.5, white on #b8641c, a 2.5 white border, 14 x 3 padding ------
        public static readonly TextStyle BannerText = new TextStyle { Font = Display, Size = 14, Color = "#ffffff", LetterSpacing = 1.5f };
        const float PadH = 14, PadV = 3;

        /// <summary>The banner's lines and box for `text` (\n: a new line) in a sign `signW` wide.</summary>
        public static (List<string> lines, float w, float h) BannerBox(string text, float signW)
        {
            float b = Bw(2.5f);
            float avail = signW - 2 * (PadH + b);
            var lines = new List<string>();
            float max = 0;
            bool wraps = false;
            foreach (var para in text.Split('\n'))
            {
                var flow = new TextFlow(para, BannerText, 0.5f);
                float mc = flow.MaxContent();
                if (mc > avail + 0.01f)
                {
                    wraps = true;
                    foreach (var l in flow.Lines(avail)) lines.Add(Join(l));
                }
                else lines.Add(para);
                max = Math.Max(max, mc);
            }
            float w = wraps ? signW : max + 2 * (PadH + b);
            float h = lines.Count * UiSvg.LineBox(BannerText) + 2 * (PadV + b);
            return (lines, w, h);
        }

        static string Join(TextFlow.Line l) { var sb = new System.Text.StringBuilder(); foreach (var p in l.Pieces) sb.Append(p.Text); return sb.ToString(); }

        public static string Banner(List<string> lines, float w, float h)
        {
            float b = Bw(2.5f);
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Background = "#b8641c", Radius = 16, BorderWidth = b, BorderColor = "#ffffff" });
            float lh = UiSvg.LineBox(BannerText), cw = w - 2 * (PadH + b);
            for (int i = 0; i < lines.Count; i++) s.Text(lines[i], b + PadH, b + PadV + i * lh, BannerText, cw, 0.5f);
            return s.Markup;
        }

        /// <summary>ui.js Head: a creature's still in a white sticker circle.</summary>
        public static string Head(float size, string picture, string ring = "#ffffff", string bg = "#f6efff")
        {
            var s = new UiSvg(size, size);
            Ui.Cards.CardArt.Head(s, 0, 0, size, picture, ring, bg);
            return s.Markup;
        }
    }
}
