// A paragraph of text as Chrome lays out a react-native-web <Text> (white-space: pre-wrap, break-word): runs of styled
// text (a nested <Text> is a run), broken into lines at spaces (and after a hyphen or around an em dash) so each line
// fits the box, a long word broken where it must, each line `lineHeight` tall, aligned left / centre. Sizes from the
// app's own font metrics (UiFont), so the lines break where the app's do.
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.Ui.Screens
{
    public struct Run
    {
        public string Text;
        public TextStyle Style;
        public Run(string text, TextStyle style) { Text = text; Style = style; }
    }

    public sealed class TextFlow
    {
        public readonly Run[] Runs;
        public readonly TextStyle Para;        // the outer <Text>'s style: line height
        public readonly float Align;           // 0 left, 0.5 centre, 1 right

        public TextFlow(TextStyle para, float align, params Run[] runs) { Para = para; Align = align; Runs = runs; }
        public TextFlow(string text, TextStyle style, float align = 0) : this(style, align, new Run(text, style)) { }

        public float LineHeight => UiSvg.LineBox(Para);

        // a piece of a line: text of one run
        public struct Piece { public int Run; public string Text; public float X, W; }
        public sealed class Line { public readonly List<Piece> Pieces = new List<Piece>(); public float Width; }

        // the text cut into tokens: a word (with what breaks after it) or spaces, each in one run
        struct Tok { public int Run; public string Text; public bool Space; public bool BreakAfter; }

        List<Tok> Tokens()
        {
            var l = new List<Tok>();
            for (int r = 0; r < Runs.Length; r++)
            {
                var s = Runs[r].Text ?? "";
                int i = 0;
                while (i < s.Length)
                {
                    bool sp = s[i] == ' ';
                    int j = i;
                    if (sp) { while (j < s.Length && s[j] == ' ') j++; l.Add(new Tok { Run = r, Text = s.Substring(i, j - i), Space = true, BreakAfter = true }); i = j; continue; }
                    while (j < s.Length && s[j] != ' ')
                    {
                        char c = s[j];
                        j++;
                        // a break opportunity after a hyphen between letters, and before / after an em dash
                        if ((c == '-' && j < s.Length && char.IsLetter(s[j]) && j - 1 > i) || c == '—') break;
                        if (j < s.Length && s[j] == '—') break;
                    }
                    l.Add(new Tok { Run = r, Text = s.Substring(i, j - i), Space = false, BreakAfter = true });
                    i = j;
                }
            }
            return l;
        }

        static float W(string t, TextStyle s) => string.IsNullOrEmpty(t) ? 0 : UiSvg.Width(t, s);

        /// <summary>The widest the text gets on one line (CSS max-content), as Chrome sizes its box.</summary>
        public float MaxContent()
        {
            float w = 0;
            foreach (var r in Runs) w += string.IsNullOrEmpty(r.Text) ? 0 : UiSvg.BoxWidth(r.Text, r.Style);
            return w;
        }

        /// <summary>The lines in a box `width` wide (NaN: one line).</summary>
        public List<Line> Lines(float width)
        {
            var toks = Tokens();
            var lines = new List<Line>();
            var cur = new List<Tok>();
            float curW = 0;
            const float Eps = 0.01f;
            void Flush()
            {
                // trailing spaces hang (pre-wrap): they don't count
                while (cur.Count > 0 && cur[cur.Count - 1].Space) { curW -= W(cur[cur.Count - 1].Text, Runs[cur[cur.Count - 1].Run].Style); cur.RemoveAt(cur.Count - 1); }
                lines.Add(Build(cur));
                cur = new List<Tok>();
                curW = 0;
            }
            foreach (var t0 in toks)
            {
                var t = t0;
                float tw = W(t.Text, Runs[t.Run].Style);
                if (t.Space) { cur.Add(t); curW += tw; continue; }
                if (!float.IsNaN(width) && curW + tw > width + Eps && cur.Exists(x => !x.Space))
                    Flush();
                // a word longer than the whole line: broken by characters (overflow-wrap: break-word)
                while (!float.IsNaN(width) && tw > width + Eps && t.Text.Length > 1)
                {
                    int n = 1;
                    while (n < t.Text.Length && W(t.Text.Substring(0, n + 1), Runs[t.Run].Style) <= width - curW + Eps) n++;
                    cur.Add(new Tok { Run = t.Run, Text = t.Text.Substring(0, n) });
                    Flush();
                    t.Text = t.Text.Substring(n);
                    tw = W(t.Text, Runs[t.Run].Style);
                }
                cur.Add(t);
                curW += tw;
            }
            Flush();
            return lines;
        }

        // one line: neighbouring tokens of the same run joined (so they're laid out as Chrome shapes them, in one go)
        Line Build(List<Tok> toks)
        {
            var line = new Line();
            var sb = new StringBuilder();
            int run = -1;
            float x = 0;
            void End()
            {
                if (run < 0 || sb.Length == 0) return;
                var s = sb.ToString();
                float w = W(s, Runs[run].Style);
                line.Pieces.Add(new Piece { Run = run, Text = s, X = x, W = w });
                x += w;
                sb.Clear();
            }
            foreach (var t in toks)
            {
                if (t.Run != run) { End(); run = t.Run; }
                sb.Append(t.Text);
            }
            End();
            line.Width = x;
            return line;
        }

        /// <summary>Yoga's measure: the box Chrome gives the text with `avail` dp across (NaN: as wide as it wants).</summary>
        public (float w, float h) Measure(float avail)
        {
            float max = MaxContent();
            if (float.IsNaN(avail) || max <= avail + 0.01f) return (max, LineHeight);
            return (avail, Lines(avail).Count * LineHeight);
        }

        /// <summary>Draws the text in the box (x, y, w): each line `LineHeight` below the last.</summary>
        public void Draw(UiSvg svg, float x, float y, float w)
        {
            var lines = Lines(MaxContent() <= w + 0.01f ? float.NaN : w);
            float lh = LineHeight;
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                float x0 = x + (w - line.Width) * Align;
                if (Align > 0) x0 = (float)(Math.Round(x0 * 64) / 64);
                foreach (var p in line.Pieces)
                {
                    var st = Runs[p.Run].Style;
                    // each run in the paragraph's line box (its line height), so the baselines line up
                    var s2 = new TextStyle { Font = st.Font, Size = st.Size, Color = st.Color, LetterSpacing = st.LetterSpacing, LineHeight = Para.LineHeight > 0 ? Para.LineHeight : st.LineHeight, Shadows = st.Shadows, Opacity = st.Opacity };
                    svg.Text(p.Text, x0 + p.X, y + i * lh, s2);
                }
            }
        }
    }
}
