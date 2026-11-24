// JS regular expressions on .NET's: the pattern translated where the two differ (\d \w ASCII-only, `$` only at the
// very end, `.` not matching any line break, [^] matching anything), and exec / test / replace / split / match as
// ECMAScript runs them (lastIndex, capture groups as undefined when unmatched, split's empty matches).
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SquishSquad.Creatures.Js
{
    public sealed class JsRegExp : JsObject
    {
        public readonly Regex Rx;
        public readonly string Source, Flags;
        public readonly bool Global, Sticky;
        public JsRegExp(Regex rx, string src, string flags) : base(Rt.RegExpProto, 2)
        {
            Rx = rx; Source = src; Flags = flags; Global = flags.IndexOf('g') >= 0; Sticky = flags.IndexOf('y') >= 0;
            Put("lastIndex", 0, 1);
        }
        public override string ClassName => "RegExp";
        public int LastIndex { get => (int)Rt.ToNum(Get("lastIndex")); set => Set("lastIndex", value); }

        static readonly Dictionary<string, Regex> Cache = new Dictionary<string, Regex>();
        /// <summary>The .NET regex for a JS pattern and flags (cached).</summary>
        public static Regex Compile(string src, string flags)
        {
            string key = flags + "/" + src;
            if (Cache.TryGetValue(key, out var r)) return r;
            var opts = RegexOptions.CultureInvariant;
            if (flags.IndexOf('i') >= 0) opts |= RegexOptions.IgnoreCase;
            if (flags.IndexOf('m') >= 0) opts |= RegexOptions.Multiline;
            r = new Regex(Translate(src, flags.IndexOf('m') >= 0, flags.IndexOf('s') >= 0), opts);
            Cache[key] = r;
            return r;
        }
        static string Translate(string s, bool multi, bool dotAll)
        {
            var o = new StringBuilder(s.Length + 16);
            bool inClass = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '\\' && i + 1 < s.Length)
                {
                    char n = s[++i];
                    switch (n)
                    {
                        case 'd': o.Append(inClass ? "0-9" : "[0-9]"); continue;
                        case 'D': o.Append(inClass ? "\\D" : "[^0-9]"); continue;
                        case 'w': o.Append(inClass ? "a-zA-Z0-9_" : "[a-zA-Z0-9_]"); continue;
                        case 'W': o.Append(inClass ? "\\W" : "[^a-zA-Z0-9_]"); continue;
                        case '/': o.Append('/'); continue;
                        case 'u':
                            if (i + 1 < s.Length && s[i + 1] == '{') { int e = s.IndexOf('}', i); int cp = Convert.ToInt32(s.Substring(i + 2, e - i - 2), 16); o.Append(Regex.Escape(char.ConvertFromUtf32(cp))); i = e; continue; }
                            o.Append('\\').Append(n); continue;
                        default: o.Append('\\').Append(n); continue;
                    }
                }
                if (inClass) { if (c == ']') inClass = false; if (c == '[') { o.Append("\\["); continue; } o.Append(c); continue; }
                if (c == '[')
                {
                    if (i + 2 < s.Length && s[i + 1] == '^' && s[i + 2] == ']') { o.Append("[\\s\\S]"); i += 2; continue; }
                    if (i + 1 < s.Length && s[i + 1] == ']') { o.Append("(?!)"); i += 1; continue; }
                    inClass = true; o.Append('[');
                    if (i + 1 < s.Length && s[i + 1] == '^') { o.Append('^'); i++; }
                    if (i + 1 < s.Length && s[i + 1] == ']') { o.Append("\\]"); i++; }
                    continue;
                }
                if (c == '$' && !multi) { o.Append("(?!(?s:.))"); continue; }
                if (c == '.' && !dotAll) { o.Append("[^\\n\\r\\u2028\\u2029]"); continue; }
                o.Append(c);
            }
            return o.ToString();
        }

        /// <summary>RegExp.prototype.exec.</summary>
        public V Exec(string s)
        {
            int start = Global || Sticky ? LastIndex : 0;
            if (start > s.Length) { if (Global || Sticky) LastIndex = 0; return V.Null; }
            var m = Rx.Match(s, start);
            if (!m.Success || (Sticky && m.Index != start)) { if (Global || Sticky) LastIndex = 0; return V.Null; }
            if (Global || Sticky) LastIndex = m.Index + m.Length;
            return MatchArray(m, s);
        }
        internal V MatchArray(Match m, string s)
        {
            var a = new JsArray(m.Groups.Count);
            a.Push(m.Value);
            JsObject named = null;
            for (int g = 1; g < m.Groups.Count; g++)
            {
                var grp = m.Groups[g];
                V v = grp.Success ? (V)grp.Value : default;
                if (int.TryParse(grp.Name, out _)) a.Push(v);
                else { a.Push(v); (named ??= new JsObject(null)).Put(grp.Name, v, 0); }
            }
            a.Put("index", m.Index, 0);
            a.Put("input", s, 0);
            a.Put("groups", named != null ? named.V : default, 0);
            return a.V;
        }

        // ---------- the String methods' regex side
        public V Replace(string s, V repl)
        {
            var fn = repl.O as JsFunction;
            string rs = fn == null ? Rt.ToStr(repl) : null;
            var sb = new StringBuilder();
            int last = 0;
            int start = Global ? 0 : (Sticky ? LastIndex : 0);
            if (Global) LastIndex = 0;
            var m = Rx.Match(s, Math.Min(start, s.Length));
            while (m.Success)
            {
                if (Sticky && m.Index != start) break;
                sb.Append(s, last, m.Index - last);
                if (fn != null)
                {
                    var args = new List<V> { m.Value };
                    JsObject named = null;
                    for (int g = 1; g < m.Groups.Count; g++) { var gr = m.Groups[g]; args.Add(gr.Success ? (V)gr.Value : default); if (!int.TryParse(gr.Name, out _)) (named ??= new JsObject(null)).Put(gr.Name, gr.Success ? (V)gr.Value : default, 0); }
                    args.Add(m.Index); args.Add(s);
                    if (named != null) args.Add(named.V);
                    sb.Append(Rt.ToStr(Rt.CallList(fn, default, args)));
                }
                else Expand(sb, rs, m, s);
                last = m.Index + m.Length;
                if (!Global) break;
                m = m.Length == 0 ? (m.Index + 1 <= s.Length ? Rx.Match(s, m.Index + 1) : Match.Empty) : m.NextMatch();
                if (m.Length == 0 && m.Success && m.Index < last) m = Rx.Match(s, last);
            }
            if (Sticky && !Global) LastIndex = m.Success ? m.Index + m.Length : 0;
            sb.Append(s, last, s.Length - last);
            return sb.ToString();
        }
        // GetSubstitution: $$ $& $` $' $n $nn $<name>
        internal static void Expand(StringBuilder sb, string rs, Match m, string s)
        {
            if (rs.IndexOf('$') < 0) { sb.Append(rs); return; }
            int ng = m.Groups.Count - 1;
            for (int i = 0; i < rs.Length; i++)
            {
                char c = rs[i];
                if (c != '$' || i + 1 >= rs.Length) { sb.Append(c); continue; }
                char n = rs[i + 1];
                if (n == '$') { sb.Append('$'); i++; }
                else if (n == '&') { sb.Append(m.Value); i++; }
                else if (n == '`') { sb.Append(s, 0, m.Index); i++; }
                else if (n == '\'') { int e = m.Index + m.Length; sb.Append(s, e, s.Length - e); i++; }
                else if (n >= '0' && n <= '9')
                {
                    int d1 = n - '0';
                    if (i + 2 < rs.Length && rs[i + 2] >= '0' && rs[i + 2] <= '9' && d1 * 10 + (rs[i + 2] - '0') <= ng && d1 * 10 + (rs[i + 2] - '0') > 0)
                    { int g = d1 * 10 + (rs[i + 2] - '0'); if (m.Groups[g].Success) sb.Append(m.Groups[g].Value); i += 2; }
                    else if (d1 >= 1 && d1 <= ng) { if (m.Groups[d1].Success) sb.Append(m.Groups[d1].Value); i++; }
                    else sb.Append(c);
                }
                else if (n == '<')
                {
                    int e = rs.IndexOf('>', i);
                    if (e < 0) { sb.Append(c); continue; }
                    var g = m.Groups[rs.Substring(i + 2, e - i - 2)];
                    if (g.Success) sb.Append(g.Value);
                    i = e;
                }
                else sb.Append(c);
            }
        }
        public V MatchAllArray(string s)
        {
            LastIndex = 0;
            var a = new JsArray();
            var m = Rx.Match(s);
            while (m.Success)
            {
                a.Push(m.Value);
                m = m.Length == 0 ? (m.Index + 1 <= s.Length ? Rx.Match(s, m.Index + 1) : Match.Empty) : m.NextMatch();
            }
            return a.Len == 0 ? V.Null : a.V;
        }
        public List<V> MatchAllExec(string s)
        {
            var l = new List<V>();
            var m = Rx.Match(s);
            while (m.Success)
            {
                l.Add(MatchArray(m, s));
                m = m.Length == 0 ? (m.Index + 1 <= s.Length ? Rx.Match(s, m.Index + 1) : Match.Empty) : m.NextMatch();
            }
            return l;
        }
        public V Split(string s, uint limit)
        {
            var a = new JsArray();
            if (limit == 0) return a.V;
            if (s.Length == 0) { var m0 = Rx.Match(s); if (!(m0.Success && m0.Index == 0)) a.Push(s); return a.V; }
            int p = 0, q = 0;
            while (q < s.Length)
            {
                var m = Rx.Match(s, q);
                if (!m.Success) break;
                int e = m.Index + m.Length;
                if (m.Index >= s.Length) break;
                if (e == p || (m.Length == 0 && m.Index == p)) { q = m.Index + 1; continue; }
                a.Push(s.Substring(p, m.Index - p));
                if (a.Len == limit) return a.V;
                for (int g = 1; g < m.Groups.Count; g++) { a.Push(m.Groups[g].Success ? (V)m.Groups[g].Value : default); if (a.Len == limit) return a.V; }
                p = e; q = p == m.Index ? p + 1 : p;
            }
            a.Push(s.Substring(p));
            return a.V;
        }
    }
}
