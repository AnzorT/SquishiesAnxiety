// The game intro's box (webgame/app/intro.js boxB / boxF: its inside and flaps behind Mittens, its face in front, both
// through brightness(.62) saturate(.85) at night) and its little shapes, as SVG in the scene's units (1000 x 460, the
// house's viewBox). Unity-free, so tools/unity/auth-test draws it beside the app's frame (MenuView.Intro.cs places it).
using System;
using SquishSquad.Ui;

namespace SquishSquad.Menu
{
    public static class IntroArt
    {
        public const float BX = 500, BY = 432, BW = 168, BH = 116, FX0 = BX - BW / 2, FX1 = BX + BW / 2, FTOP = BY - BH, TOPH = 20, IN = 18;

        static string F(double v) => UiSvg.F(v);
        public static string Pt(double x, double y) => F(x) + "," + F(y);
        static string InnerSvg(string m) { int a = m.IndexOf('>') + 1, b = m.LastIndexOf("</svg>", StringComparison.Ordinal); return m.Substring(a, b - a); }

        // CSS brightness(.62) then saturate(.85) (the filter's matrix) on one colour
        public static string Dim(string hex)
        {
            float cr = Convert.ToInt32(hex.Substring(1, 2), 16) / 255f * 0.62f, cg = Convert.ToInt32(hex.Substring(3, 2), 16) / 255f * 0.62f, cb = Convert.ToInt32(hex.Substring(5, 2), 16) / 255f * 0.62f;
            const float s = 0.85f;
            float r = (0.213f + 0.787f * s) * cr + (0.715f - 0.715f * s) * cg + (0.072f - 0.072f * s) * cb;
            float g = (0.213f - 0.213f * s) * cr + (0.715f + 0.285f * s) * cg + (0.072f - 0.072f * s) * cb;
            float b = (0.213f - 0.213f * s) * cr + (0.715f - 0.715f * s) * cg + (0.072f + 0.928f * s) * cb;
            int q(float v) => (int)Math.Round(Math.Max(0, Math.Min(1, v)) * 255);
            return $"#{q(r):x2}{q(g):x2}{q(b):x2}";
        }

        public static string BoxBack(double o)
        {
            var L0 = (FX0, FTOP); var L1 = (FX0 + IN, FTOP - TOPH); var R0 = (FX1, FTOP); var R1 = (FX1 - IN, FTOP - TOPH);
            string inside = $"<path d=\"M{Pt(L0.Item1, L0.Item2)} L{Pt(L1.Item1, L1.Item2)} L{Pt(R1.Item1, R1.Item2)} L{Pt(R0.Item1, R0.Item2)}Z\" fill=\"{Dim("#3e2412")}\" opacity=\"{F(Math.Max(0, Math.Min(1, o * 4)))}\"/>";
            double a = o * 2.3;
            string lf((float x, float y) h0, (float x, float y) h1, int sgn)
            {
                double w0 = (BX - h0.x) * sgn, w1 = (BX - h1.x) * sgn;
                return $"M{Pt(h0.x, h0.y)} L{Pt(h1.x, h1.y)} L{Pt(h1.x + Math.Cos(a) * w1 * sgn, h1.y - Math.Sin(a) * w1 * 0.85)} L{Pt(h0.x + Math.Cos(a) * w0 * sgn, h0.y - Math.Sin(a) * w0 * 0.85)}Z";
            }
            return inside
                + $"<path d=\"{lf(L0, L1, 1)}\" fill=\"{Dim("#d9a066")}\" stroke=\"{Dim("#5a3418")}\" stroke-width=\"2\" stroke-linejoin=\"round\"/>"
                + $"<path d=\"{lf(R0, R1, -1)}\" fill=\"{Dim("#c98f55")}\" stroke=\"{Dim("#5a3418")}\" stroke-width=\"2\" stroke-linejoin=\"round\"/>";
        }

        public static string BoxFront()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append($"<defs><linearGradient id=\"siCard\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"{Dim("#e6b075")}\"/><stop offset=\"1\" stop-color=\"{Dim("#b9783e")}\"/></linearGradient>");
            sb.Append($"<linearGradient id=\"siTape\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"{Dim("#f3dca6")}\"/><stop offset=\"1\" stop-color=\"{Dim("#e2c27e")}\"/></linearGradient></defs>");
            sb.Append($"<path d=\"M{F(FX0)} {F(FTOP)} H{F(FX1)} V{F(BY)} H{F(FX0)}Z\" fill=\"url(#siCard)\" stroke=\"{Dim("#5a3418")}\" stroke-width=\"2.6\" stroke-linejoin=\"round\"/>");
            sb.Append($"<path d=\"M{F(FX0 + 5)} {F(BY - 8)} H{F(FX1 - 5)}\" stroke=\"{Dim("#9a6030")}\" stroke-width=\"2\" opacity=\"0.45\" fill=\"none\"/>");
            sb.Append($"<path d=\"M{F(FX0 + 6)} {F(FTOP + 3.5)} H{F(FX1 - 6)}\" stroke=\"{Dim("#f6d3a0")}\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.7\" fill=\"none\"/>");
            sb.Append($"<rect x=\"{F(BX - 12)}\" y=\"{F(FTOP)}\" width=\"24\" height=\"{F(BH * 0.42)}\" fill=\"url(#siTape)\" opacity=\"0.95\"/>");
            // the FRAGILE label (its words drawn as glyphs, the app's Fredoka)
            var lab = new UiSvg(74, 30);
            lab.Raw($"<rect x=\"0\" y=\"0\" width=\"74\" height=\"30\" rx=\"4\" fill=\"{Dim("#fff4e0")}\" stroke=\"{Dim("#d2453a")}\" stroke-width=\"2\"/>");
            var t1 = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, Color = Dim("#d2453a"), LetterSpacing = 0.8f };
            var t2 = new TextStyle { Font = "Fredoka_700Bold", Size = 9.5f, Color = Dim("#d2453a"), LetterSpacing = 0.5f };
            SquishSquad.Screens.Kit.SafeGlyphs(lab, "FRAGILE", 37 - UiSvg.BoxWidth("FRAGILE", t1) / 2, 13, t1.Font, t1.Size, t1.LetterSpacing, t1.Color);
            // "SQUISHY \u2665": Fredoka has no heart, the app's falls back to a small one (about 4.8 x 4.8, on the baseline)
            float sq = UiSvg.BoxWidth("SQUISHY ", t2), hw = 4.8f, x0 = 37 - (sq + hw) / 2, hx = x0 + sq + hw / 2;
            SquishSquad.Screens.Kit.SafeGlyphs(lab, "SQUISHY", x0, 25, t2.Font, t2.Size, t2.LetterSpacing, t2.Color);
            lab.Raw($"<g fill=\"{Dim("#d2453a")}\"><circle cx=\"{F(hx - 1.2)}\" cy=\"21.4\" r=\"1.3\"/><circle cx=\"{F(hx + 1.2)}\" cy=\"21.4\" r=\"1.3\"/><path d=\"M{F(hx - 2.45)} 21.8 L{F(hx + 2.45)} 21.8 L{F(hx)} 25Z\"/></g>");
            sb.Append($"<g transform=\"translate({F(BX - 66)} {F(FTOP + 54)}) rotate(-6)\">{InnerSvg(lab.Markup)}</g>");
            sb.Append($"<g transform=\"translate({F(BX + 46)} {F(FTOP + 58)}) rotate(10)\" fill=\"{Dim("#7a3a6a")}\" opacity=\"0.85\"><ellipse cx=\"0\" cy=\"6\" rx=\"9\" ry=\"7.5\"/><circle cx=\"-9\" cy=\"-3.5\" r=\"3.6\"/><circle cx=\"-3\" cy=\"-8\" r=\"3.6\"/><circle cx=\"4\" cy=\"-8\" r=\"3.6\"/><circle cx=\"9.6\" cy=\"-3\" r=\"3.6\"/></g>");
            foreach (var (dx, dy2) in new[] { (-56, 26), (-44, 26), (50, 92), (62, 92) }) sb.Append($"<circle cx=\"{F(BX + dx)}\" cy=\"{F(FTOP + dy2)}\" r=\"3\" fill=\"{Dim("#3a2010")}\"/>");
            return sb.ToString();
        }

        public static string Star(double X, double Y, double r) =>
            $"M{Pt(X, Y - r * 1.4)} Q{Pt(X, Y)} {Pt(X + r * 1.4, Y)} Q{Pt(X, Y)} {Pt(X, Y + r * 1.4)} Q{Pt(X, Y)} {Pt(X - r * 1.4, Y)} Q{Pt(X, Y)} {Pt(X, Y - r * 1.4)}Z";
    }
}
