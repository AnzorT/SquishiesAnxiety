// A creature frame's SVG markup (what the rig's element tree serialises to) as a small node tree. Only what the rigs
// write: elements, attributes, text; no DTDs or CDATA. Fast enough to run every frame (a frame is 15-60 KB).
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.Vector
{
    public sealed class SvgNode
    {
        public string Tag;
        public readonly List<KeyValuePair<string, string>> Attrs = new List<KeyValuePair<string, string>>(4);
        public readonly List<SvgNode> Children = new List<SvgNode>(2);
        public SvgNode Parent;
        public string Text;

        public string this[string name]
        {
            get
            {
                for (int i = 0; i < Attrs.Count; i++) if (Attrs[i].Key == name) return Attrs[i].Value;
                return null;
            }
        }

        public float Num(string name, float fallback = 0f)
        {
            var v = this[name];
            return v == null ? fallback : SvgNum.Parse(v, fallback);
        }

        // a style property: the attribute, or the same property in style="..."
        public string Prop(string name)
        {
            var v = this[name];
            if (v != null) return v;
            var st = this["style"];
            if (st == null) return null;
            foreach (var part in st.Split(';'))
            {
                int c = part.IndexOf(':');
                if (c > 0 && part.Substring(0, c).Trim() == name) return part.Substring(c + 1).Trim();
            }
            return null;
        }

        public override string ToString() => "<" + Tag + ">";
    }

    public static class SvgMarkup
    {
        public static SvgNode Parse(string s)
        {
            var root = new SvgNode { Tag = "#root" };
            var stack = new List<SvgNode> { root };
            int i = 0, n = s.Length;
            while (i < n)
            {
                int lt = s.IndexOf('<', i);
                if (lt < 0) lt = n;
                if (lt > i)
                {
                    var t = s.Substring(i, lt - i);
                    if (t.Trim().Length > 0) stack[stack.Count - 1].Children.Add(new SvgNode { Tag = "#text", Text = Unescape(t), Parent = stack[stack.Count - 1] });
                }
                if (lt >= n) break;
                if (Starts(s, lt, "<!--")) { int e = s.IndexOf("-->", lt + 4, StringComparison.Ordinal); i = e < 0 ? n : e + 3; continue; }
                if (lt + 1 < n && (s[lt + 1] == '!' || s[lt + 1] == '?')) { int e = s.IndexOf('>', lt); i = e < 0 ? n : e + 1; continue; }
                if (lt + 1 < n && s[lt + 1] == '/')
                {
                    int e = s.IndexOf('>', lt);
                    var name = s.Substring(lt + 2, (e < 0 ? n : e) - lt - 2).Trim();
                    for (int k = stack.Count - 1; k > 0; k--) if (stack[k].Tag == name) { stack.RemoveRange(k, stack.Count - k); break; }
                    i = e < 0 ? n : e + 1;
                    continue;
                }
                int j = lt + 1;
                while (j < n && !char.IsWhiteSpace(s[j]) && s[j] != '>' && s[j] != '/') j++;
                var node = new SvgNode { Tag = s.Substring(lt + 1, j - lt - 1), Parent = stack[stack.Count - 1] };
                bool selfClose = false;
                for (;;)
                {
                    while (j < n && char.IsWhiteSpace(s[j])) j++;
                    if (j >= n) break;
                    if (s[j] == '>') { j++; break; }
                    if (s[j] == '/') { selfClose = true; j++; continue; }
                    int a = j;
                    while (j < n && s[j] != '=' && !char.IsWhiteSpace(s[j]) && s[j] != '>' && s[j] != '/') j++;
                    var key = s.Substring(a, j - a);
                    while (j < n && char.IsWhiteSpace(s[j])) j++;
                    string val = "";
                    if (j < n && s[j] == '=')
                    {
                        j++;
                        while (j < n && char.IsWhiteSpace(s[j])) j++;
                        if (j < n && (s[j] == '"' || s[j] == '\''))
                        {
                            char q = s[j];
                            int e = s.IndexOf(q, j + 1);
                            if (e < 0) e = n;
                            val = Unescape(s.Substring(j + 1, e - j - 1));
                            j = e + 1;
                        }
                        else
                        {
                            int b = j;
                            while (j < n && !char.IsWhiteSpace(s[j]) && s[j] != '>') j++;
                            val = Unescape(s.Substring(b, j - b));
                        }
                    }
                    if (key.Length > 0) node.Attrs.Add(new KeyValuePair<string, string>(key, val));
                }
                stack[stack.Count - 1].Children.Add(node);
                if (!selfClose) stack.Add(node);
                i = j;
            }
            return root;
        }

        static bool Starts(string s, int at, string what) => string.CompareOrdinal(s, at, what, 0, what.Length) == 0;

        static string Unescape(string s)
        {
            if (s.IndexOf('&') < 0) return s;
            var sb = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '&') { sb.Append(s[i]); continue; }
                int e = s.IndexOf(';', i);
                if (e < 0) { sb.Append('&'); continue; }
                var ent = s.Substring(i + 1, e - i - 1);
                switch (ent)
                {
                    case "amp": sb.Append('&'); break;
                    case "lt": sb.Append('<'); break;
                    case "gt": sb.Append('>'); break;
                    case "quot": sb.Append('"'); break;
                    case "apos": sb.Append('\''); break;
                    case "nbsp": sb.Append(' '); break;
                    default:
                        if (ent.StartsWith("#x")) sb.Append((char)Convert.ToInt32(ent.Substring(2), 16));
                        else if (ent.StartsWith("#")) sb.Append((char)int.Parse(ent.Substring(1)));
                        else sb.Append('&').Append(ent).Append(';');
                        break;
                }
                i = e;
            }
            return sb.ToString();
        }
    }

    public static class SvgNum
    {
        public static float Parse(string s, float fallback = 0f)
        {
            int i = 0;
            return TryRead(s, ref i, out var v) ? v : fallback;
        }

        // one number at i (skipping spaces and commas before it); i moves past it
        public static bool TryRead(string s, ref int i, out float v)
        {
            v = 0;
            int n = s.Length;
            while (i < n && (char.IsWhiteSpace(s[i]) || s[i] == ',')) i++;
            if (i >= n) return false;
            int start = i;
            if (s[i] == '+' || s[i] == '-') i++;
            bool digits = false, dot = false;
            while (i < n && (char.IsDigit(s[i]) || (s[i] == '.' && !dot)))
            {
                if (s[i] == '.') dot = true; else digits = true;
                i++;
            }
            if (!digits) { i = start; return false; }
            if (i < n && (s[i] == 'e' || s[i] == 'E') && i + 1 < n && (char.IsDigit(s[i + 1]) || ((s[i + 1] == '-' || s[i + 1] == '+') && i + 2 < n && char.IsDigit(s[i + 2]))))
            {
                i += 2;
                while (i < n && char.IsDigit(s[i])) i++;
            }
            v = (float)Decimal(s, start, i);
            return true;
        }

        static readonly double[] Pow10 = { 1, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8, 1e9, 1e10, 1e11, 1e12, 1e13, 1e14, 1e15, 1e16, 1e17, 1e18, 1e19, 1e20, 1e21, 1e22 };
        // the number in s[a..b): up to 15 digits and no exponent as digits / 10^k (one correctly rounded division: the
        // same double as double.Parse, with no substring), else double.Parse
        static double Decimal(string s, int a, int b)
        {
            int i = a; bool neg = false;
            if (s[i] == '+' || s[i] == '-') { neg = s[i] == '-'; i++; }
            long m = 0; int digits = 0, frac = -1;
            for (; i < b; i++)
            {
                char c = s[i];
                if (c == '.') { frac = 0; continue; }
                if (c < '0' || c > '9') { digits = 99; break; }
                if (m != 0 || c != '0') digits++;
                m = m * 10 + (c - '0');
                if (frac >= 0) frac++;
            }
            if (digits <= 15 && (frac < 0 || frac <= 22))
            {
                double v = frac > 0 ? m / Pow10[frac] : m;
                return neg ? -v : v;
            }
            return double.Parse(s.Substring(a, b - a), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
