// The browser stand-in's (tools/unity/rig/dom-shim.js) hottest function done natively: serialize(), the element tree
// to markup (outerHTML / innerHTML), which the host reads for every creature every frame. jsc.mjs puts this in place of
// the JS one; it reads the same objects (nodeType, data, localName, _attrs, style, childNodes) and writes the same
// characters (run.mjs compares it with the JS stand-in's own).
using System.Text;

namespace SquishSquad.Creatures.Js
{
    public static class Dom
    {
        public static readonly JsFn SerializeFn = (s, n, a, b, c, d, r) => Serialize(a);

        [System.ThreadStatic] static StringBuilder _sb;
        public static string Serialize(V node)
        {
            var sb = _sb ?? (_sb = new StringBuilder(1 << 16));
            if (sb.Length > 0) sb = new StringBuilder(1 << 12);   // (re-entered: a getter serializing inside)
            Write(sb, node);
            var s = sb.ToString();
            if (ReferenceEquals(sb, _sb)) { sb.Clear(); if (sb.Capacity > 1 << 22) _sb = null; }
            return s;
        }

        static void Write(StringBuilder sb, V n)
        {
            var o = n.O as JsObject;
            double type = Rt.ToNum(Rt.Get(n, "nodeType"));
            if (type == 3) { Esc(sb, Rt.ToStr(Rt.Get(n, "data")), false); return; }
            var kids = Rt.Get(n, "childNodes").O as JsArray;
            if (type == 11) { if (kids != null) for (int i = 0; i < kids.Len; i++) Write(sb, kids.At(i)); return; }
            string tag = Rt.ToStr(Rt.Get(n, "localName"));
            sb.Append('<').Append(tag);
            if (Rt.Get(n, "_attrs").O is JsArray attrs)
                for (int i = 0; i < attrs.Len; i++)
                {
                    var kv = attrs.At(i);
                    sb.Append(' ').Append(Rt.ToStr(Rt.GetIdx(kv, 0))).Append("=\"");
                    Esc(sb, Rt.ToStr(Rt.GetIdx(kv, 1)), true);
                    sb.Append('"');
                }
            var st = Rt.Get(n, "style");
            if (st.O is JsObject so && so.N > 0)
            {
                // Style's cssText getter: its own properties (for-in lists those first, in this order) that aren't ''
                // or null, kebab-cased
                StringBuilder css = null;
                foreach (var k in so.OwnKeys(true))
                {
                    var v = so.Get(k, st);
                    if ((v.O is string vs && vs.Length == 0) || v.IsNullish) continue;
                    if (css == null) css = new StringBuilder(); else css.Append(' ');
                    Kebab(css, k); css.Append(": ").Append(Rt.ToStr(v)).Append(';');
                }
                if (css != null) { sb.Append(" style=\""); Esc(sb, css.ToString(), true); sb.Append('"'); }
            }
            sb.Append('>');
            if (kids != null) for (int i = 0; i < kids.Len; i++) Write(sb, kids.At(i));
            sb.Append("</").Append(tag).Append('>');
        }

        /// <summary>el.querySelector('svg'): the first element named svg under `el`, in document order.</summary>
        public static V FirstSvg(V el)
        {
            var kids = Rt.Get(el, "childNodes").O as JsArray;
            if (kids == null) return V.Null;
            for (int i = 0; i < kids.Len; i++)
            {
                var c = kids.At(i);
                if (!(c.O is JsObject) || Rt.ToNum(Rt.Get(c, "nodeType")) != 1) continue;
                if (string.Equals(Rt.ToStr(Rt.Get(c, "localName")), "svg", System.StringComparison.OrdinalIgnoreCase)) return c;
                var r = FirstSvg(c);
                if (!r.IsNullish) return r;
            }
            return V.Null;
        }

        // kebab(): camelCase to kebab-case, webkit- to -webkit-
        public static void Kebab(StringBuilder sb, string k)
        {
            int start = sb.Length;
            foreach (char c in k) { if (c >= 'A' && c <= 'Z') sb.Append('-').Append((char)(c + 32)); else sb.Append(c); }
            if (sb.Length - start >= 7 && sb[start] == 'w' && sb.ToString(start, 7) == "webkit-") sb.Insert(start, '-');
        }

        // escAttr / escText: & < > (and " in attributes), a no-break space as &nbsp;
        static void Esc(StringBuilder sb, string s, bool attr)
        {
            int last = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                string e = c == '&' ? "&amp;" : c == '<' ? "&lt;" : c == '>' ? "&gt;" : c == ' ' ? "&nbsp;" : c == '"' && attr ? "&quot;" : null;
                if (e == null) continue;
                sb.Append(s, last, i - last).Append(e);
                last = i + 1;
            }
            sb.Append(s, last, s.Length - last);
        }
    }
}
