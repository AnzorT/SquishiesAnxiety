// SVG <text> for the vector renderer (Vector/SvgScene.TextGlyphs): the element's line laid out in the app's own fonts
// (Resources/Fonts through UiFont: advances, kerning and letter-spacing as Chrome lays out a line), each character's
// glyph outline at its pen position. One line per element: its text with whitespace collapsed (xml:space default), at
// its first x / y (plus dx / dy), moved for text-anchor. That's what the exported art writes (the Game Park's "GAME
// PARK" sign and popcorn "POP!", the house's level, the rigs' "z"s): no tspans placed on their own, no textLength.
using System;
using System.Globalization;
using System.Text;
using SquishSquad.Vector;

namespace SquishSquad.Ui
{
    public static class SvgText
    {
        /// <summary>Lets SvgScene draw &lt;text&gt;. UiFont.ReadJson must be set before anything with text is drawn.</summary>
        public static void Install() => SvgScene.TextGlyphs ??= Glyphs;

        public static SvgScene.GlyphRun Glyphs(SvgNode n)
        {
            string text = Collapse(Content(n, new StringBuilder()).ToString());
            if (text.Length == 0) return null;
            UiFont f;
            try { f = UiFont.Get(FontFor(Inherited(n, "font-family"), Inherited(n, "font-weight"))); }
            catch (InvalidOperationException) { return null; }   // the fonts aren't loaded here (a test without them)
            float size = Px(Inherited(n, "font-size"), 16), ls = Px(Inherited(n, "letter-spacing"), 0);
            if (size <= 0) return null;
            float x = First(n["x"]) + First(n["dx"]), y = First(n["y"]) + First(n["dy"]);
            var xs = f.Layout(text, size, ls, out float width);
            var anchor = (Inherited(n, "text-anchor") ?? "start").Trim();
            if (anchor == "middle") x -= width / 2;
            else if (anchor == "end") x -= width;

            var run = new SvgScene.GlyphRun();
            var cps = UiFont.CodePoints(text);
            for (int i = 0; i < cps.Count; i++)
            {
                var src = f;
                var d = f.PathOf(cps[i]);
                if (string.IsNullOrEmpty(d)) { src = Fallback(cps[i]); d = src?.PathOf(cps[i]); }
                if (string.IsNullOrEmpty(d)) continue;   // a space, or a character no font has
                run.Glyphs.Add((d, x + xs[i], y, (double)size / src.UnitsPerEm));
            }
            double k = (double)size / f.UnitsPerEm;
            run.Box = new Box { X0 = x, X1 = x + width, Y0 = y - Math.Abs(f.Ascender) * k, Y1 = y + Math.Abs(f.Descender) * k };
            return run;
        }

        // the app's fonts by CSS family (the first one the font list names that the app ships) and the nearest weight
        static string FontFor(string family, string weight)
        {
            string fam = "Fredoka";
            foreach (var part in (family ?? "").Split(','))
            {
                var p = part.Trim().Trim('\'', '"');
                if (p.StartsWith("Fredoka") || p.StartsWith("Nunito") || p.StartsWith("Baloo")) { fam = p; break; }
            }
            var wv = (weight ?? "").Trim();
            int w = wv == "bold" || wv == "bolder" ? 700 : int.TryParse(wv, NumberStyles.Integer, CultureInfo.InvariantCulture, out var n) ? n : 400;
            if (fam.StartsWith("Nunito"))
                return w >= 900 ? "Nunito_900Black" : w >= 800 ? "Nunito_800ExtraBold" : w >= 700 ? "Nunito_700Bold" : w >= 600 ? "Nunito_600SemiBold" : "Nunito_400Regular";
            if (fam.StartsWith("Baloo"))
                return w >= 800 ? "Baloo2_800ExtraBold" : w >= 700 ? "Baloo2_700Bold" : "Baloo2_500Medium";
            return w >= 700 ? "Fredoka_700Bold" : w >= 600 ? "Fredoka_600SemiBold" : "Fredoka_500Medium";
        }

        // a character the font lacks: the fallback font's (Fallback.json, what Chrome falls back to), if it has it
        static UiFont Fallback(int cp)
        {
            try { var fb = UiFont.Get("Fallback"); return fb.Has(cp) ? fb : null; }
            catch (InvalidOperationException) { return null; }
        }

        // a property set on the element or on one of its ancestors (fonts and text-anchor are inherited)
        static string Inherited(SvgNode n, string name)
        {
            for (var p = n; p != null; p = p.Parent)
            {
                var v = p.Prop(name);
                if (v != null && v.Trim() != "inherit") return v;
            }
            return null;
        }

        static StringBuilder Content(SvgNode n, StringBuilder sb)
        {
            foreach (var c in n.Children)
            {
                if (c.Tag == "#text") sb.Append(c.Text);
                else Content(c, sb);
            }
            return sb;
        }

        static string Collapse(string s)
        {
            var sb = new StringBuilder(s.Length);
            bool space = false;
            foreach (var ch in s)
            {
                if (ch == ' ' || ch == '\n' || ch == '\r' || ch == '\t') { space = sb.Length > 0; continue; }
                if (space) { sb.Append(' '); space = false; }
                sb.Append(ch);
            }
            return sb.ToString();
        }

        // "15.5", "15.5px"; "normal" and anything unreadable: `fallback`
        static float Px(string v, float fallback)
        {
            if (string.IsNullOrEmpty(v)) return fallback;
            v = v.Trim();
            if (v.EndsWith("px")) v = v.Substring(0, v.Length - 2);
            return float.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out var f) ? f : fallback;
        }

        // the first number of an x / y list ("150", "10 20 30"), 0 if none
        static float First(string v)
        {
            if (string.IsNullOrEmpty(v)) return 0;
            int i = 0;
            return SvgNum.TryRead(v, ref i, out var f) ? f : 0;
        }
    }
}
