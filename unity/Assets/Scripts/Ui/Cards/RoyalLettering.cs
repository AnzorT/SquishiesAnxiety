// royal/Lettering.js, the menu's lettering, as SVG: the mode panels' names on the games' hubs (Squishdoku's SdHub and the
// GameHub of Squish Stack, Sort and Hop, Games/Shared/ModeHub). Moved here from SdArt so every hub can draw it.
using System;
using SquishSquad.Ui;

namespace SquishSquad.Ui.Cards
{
    public static class RoyalLettering
    {
        const string INK = "#5b3418", Display = "Fredoka_700Bold";
        static string F(double v) => UiSvg.F(v);

        /// <summary>royal/Lettering.js (the menu's lettering): Fredoka in a gradient, a dark outline and a drop under it, a thin
        /// white shine along the top, (gold) a white sticker edge round it all, as its own &lt;svg&gt;: (markup, w, h).</summary>
        public static (string svg, float w, float h) Draw(string text, float size, string variant = "white")
        {
            var (f, o, white) = variant == "gold" ? (new[] { "#fffbe6", "#ffe57e", "#ffbe2e", "#f08c10" }, INK, true) : (new[] { "#ffffff", "#ffffff", "#fff6e2", "#ffe6b8" }, INK, false);
            float sw = Math.Max(2.4f, size * 0.19f), ls = size * 0.02f;
            var shown = text.Replace("AI", "A I");
            var m = new TextStyle { Font = Display, Size = size, LetterSpacing = ls };
            float w = (float)Math.Ceiling(UiSvg.BoxWidth(text, m) + sw * 2.4 + 4), h = (float)Math.Ceiling(size * 1.32 + sw);
            float y = size * 0.98f + sw / 2, x = w / 2 - UiSvg.BoxWidth(shown, m) / 2;
            var font = UiFont.Get(Display);
            double k = (double)size / font.UnitsPerEm;
            double asc = Math.Round(font.Ascender * k), desc = Math.Round(-font.Descender * k);
            var s = new UiSvg(w, h);
            var id = s.NewId("lt");
            var g = new System.Text.StringBuilder($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(asc / k)}\" x2=\"0\" y2=\"{F(-desc / k)}\">");
            for (int i = 0; i < f.Length; i++) g.Append($"<stop offset=\"{F(Math.Round(i / (double)(f.Length - 1) * 100) / 100)}\" stop-color=\"{f[i]}\"/>");
            s.Def(g.Append("</linearGradient>").ToString());
            string Stroke(string c, double width) => $"stroke=\"{c}\" stroke-width=\"{F(width / k)}\" stroke-linejoin=\"round\"";
            if (white) s.Glyphs(shown, x, y, Display, size, ls, "#ffffff", Stroke("#ffffff", sw * 2.1));
            s.Glyphs(shown, x, y + size * 0.06f, Display, size, ls, o, Stroke(o, sw * 1.25));
            s.Glyphs(shown, x, y, Display, size, ls, o, Stroke(o, sw));
            s.Glyphs(shown, x, y, Display, size, ls, $"url(#{id})");
            s.Glyphs(shown, x, y - size * 0.03f, Display, size, ls, "none", Stroke("rgba(255,255,255,0.55)", size * 0.035));
            return (s.Markup, w, h);
        }
    }
}
