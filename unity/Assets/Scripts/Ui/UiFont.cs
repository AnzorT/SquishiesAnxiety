// The app's fonts (Resources/Fonts/<name>.json, written by tools/unity/ui/fonts.py): glyph outlines, advances and
// pair kerning, and text laid out from them the way Chrome lays out a line: each character's advance plus the pair's
// kerning plus letter-spacing, in px at the font size.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Ui
{
    [Serializable]
    public sealed class UiFontData
    {
        public string name;
        public int unitsPerEm;
        public int ascender, descender, lineGap, typoAscender, typoDescender, typoLineGap;
        public bool useTypo;
        public string chars;
        public Glyph[] glyphs;
        public string[] pairs;
        public int[] kern;

        [Serializable]
        public sealed class Glyph
        {
            public int adv;
            public string d;
        }
    }

    public sealed class UiFont
    {
        public readonly string Name;
        public readonly int UnitsPerEm;
        public readonly int Ascender, Descender;
        readonly Dictionary<int, int> _index = new Dictionary<int, int>();   // code point -> glyph
        readonly UiFontData.Glyph[] _glyphs;
        readonly Dictionary<long, int> _kern = new Dictionary<long, int>();

        public UiFont(UiFontData d)
        {
            Name = d.name;
            UnitsPerEm = d.unitsPerEm;
            Ascender = d.ascender;
            Descender = d.descender;
            _glyphs = d.glyphs;
            int gi = 0;
            for (int i = 0; i < d.chars.Length; i++)
            {
                int cp = char.ConvertToUtf32(d.chars, i);
                if (char.IsHighSurrogate(d.chars[i])) i++;
                _index[cp] = gi++;
            }
            if (d.pairs != null)
                for (int i = 0; i < d.pairs.Length; i++)
                {
                    var p = d.pairs[i];
                    int a = char.ConvertToUtf32(p, 0), b = char.ConvertToUtf32(p, char.IsHighSurrogate(p[0]) ? 2 : 1);
                    _kern[Key(a, b)] = d.kern[i];
                }
        }

        static long Key(int a, int b) => ((long)a << 32) | (uint)b;

        public bool Has(int cp) => _index.ContainsKey(cp);
        public string PathOf(int cp) => _index.TryGetValue(cp, out var g) ? _glyphs[g].d : null;
        public int Advance(int cp) => _index.TryGetValue(cp, out var g) ? _glyphs[g].adv : UnitsPerEm / 2;
        public int Kern(int a, int b) => _kern.TryGetValue(Key(a, b), out var k) ? k : 0;

        /// <summary>Each character's pen x (px from the line's start) for `text` at `size` px with `letterSpacing`
        /// px after every character, and the line's width. Positions are snapped to 1/64 px, as Chrome's layout is.</summary>
        public float[] Layout(string text, float size, float letterSpacing, out float width)
        {
            var cps = CodePoints(text);
            var xs = new float[cps.Count];
            double k = (double)size / UnitsPerEm, x = 0;
            for (int i = 0; i < cps.Count; i++)
            {
                xs[i] = Snap(x);
                x += Advance(cps[i]) * k + letterSpacing;
                if (i + 1 < cps.Count) x += Kern(cps[i], cps[i + 1]) * k;
            }
            width = Snap(x);
            return xs;
        }

        static float Snap(double v) => (float)(Math.Round(v * 64) / 64);

        public static List<int> CodePoints(string s)
        {
            var l = new List<int>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                l.Add(char.ConvertToUtf32(s, i));
                if (char.IsHighSurrogate(s[i])) i++;
            }
            return l;
        }

        // ---- fonts by name ------------------------------------------------------------------------------------------
        static readonly Dictionary<string, UiFont> Loaded = new Dictionary<string, UiFont>();
        /// <summary>Reads a font's JSON (Unity: Resources/Fonts/&lt;name&gt;); set by the host.</summary>
        public static Func<string, string> ReadJson;
        public static Func<string, UiFontData> ParseJson;

        public static UiFont Get(string name)
        {
            if (Loaded.TryGetValue(name, out var f)) return f;
            var json = ReadJson?.Invoke(name);
            if (json == null || ParseJson == null) throw new InvalidOperationException("font " + name + " isn't loaded (Resources/Fonts)");
            f = new UiFont(ParseJson(json));
            Loaded[name] = f;
            return f;
        }

        // ---- as SVG: glyphs once in <defs>, each character a <use> -------------------------------------------------
        /// <summary>SVG for a line of text whose first character's pen is at (x, baseline), filled with `fill`.
        /// Glyphs are defined in `defs` once per font and character (ids from `ids`).</summary>
        public string Svg(string text, float x, float baseline, float size, float letterSpacing, string fill, StringBuilder defs, Dictionary<string, string> ids)
        {
            var cps = CodePoints(text);
            var xs = Layout(text, size, letterSpacing, out _);
            var sb = new StringBuilder();
            sb.Append("<g fill=\"").Append(fill).Append("\">");
            string k = F(size / UnitsPerEm);
            for (int i = 0; i < cps.Count; i++)
            {
                var d = PathOf(cps[i]);
                if (string.IsNullOrEmpty(d)) continue;
                var key = Name + "\u0000" + cps[i];
                if (!ids.TryGetValue(key, out var id))
                {
                    id = "gl" + ids.Count;
                    ids[key] = id;
                    defs.Append("<path id=\"").Append(id).Append("\" d=\"").Append(d).Append("\"/>");
                }
                sb.Append("<use href=\"#").Append(id).Append("\" transform=\"translate(").Append(F(x + xs[i])).Append(' ').Append(F(baseline))
                  .Append(") scale(").Append(k).Append(" -").Append(k).Append(")\"/>");
            }
            sb.Append("</g>");
            return sb.ToString();
        }

        static string F(double v) => v.ToString("0.####", CultureInfo.InvariantCulture);
    }
}
