// The house room's template: the page's own markup (Squad House v6.dc.html, the room box from the shell's <svg> to
// the night overlay, exported as Resources/House/room-template.html by tools/unity/house/export-house.mjs), evaluated
// in C# the way the dc runtime does: <sc-if value="{{ x }}"> keeps its children when x is truthy, <sc-for list="{{ l }}"
// as="f"> repeats them per element, {{ a.b }} in attributes and text is replaced by the value (an attribute whose whole
// value is one {{ }} with no value is left out, as React leaves out null props). Event handlers and refs are dropped.
// The values are the C# port's renderVals (RoomModel). The result is a small DOM (Dom) the room is drawn from and the
// page's DOM is compared with.
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.House
{
    public sealed class Dom
    {
        public string Tag;   // "#text" for text
        public string Text;
        public readonly List<KeyValuePair<string, string>> Attrs = new List<KeyValuePair<string, string>>();
        public readonly List<Dom> Children = new List<Dom>();
        public string this[string k] { get { foreach (var a in Attrs) if (a.Key == k) return a.Value; return null; } }
        public void Set(string k, string v) { for (int i = 0; i < Attrs.Count; i++) if (Attrs[i].Key == k) { Attrs[i] = new KeyValuePair<string, string>(k, v); return; } Attrs.Add(new KeyValuePair<string, string>(k, v)); }
        public string Inner() { var sb = new StringBuilder(); foreach (var c in Children) if (c.Tag == "#text") sb.Append(c.Text); else sb.Append(c.Inner()); return sb.ToString(); }
    }

    public sealed class HouseTemplate
    {
        readonly Dom root;

        public HouseTemplate(string markup) { root = Parse(markup); }

        // ---- parsing (the template's own subset of HTML: explicit closing tags, quoted attributes, comments) ----
        static Dom Parse(string s)
        {
            var top = new Dom { Tag = "#root" }; var stack = new Stack<Dom>(); stack.Push(top);
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] == '<')
                {
                    if (string.CompareOrdinal(s, i, "<!--", 0, 4) == 0) { int e = s.IndexOf("-->", i, StringComparison.Ordinal); i = e < 0 ? s.Length : e + 3; continue; }
                    if (i + 1 < s.Length && s[i + 1] == '/') { int e = s.IndexOf('>', i); var name = s.Substring(i + 2, e - i - 2).Trim(); while (stack.Count > 1 && stack.Peek().Tag != name) stack.Pop(); if (stack.Count > 1) stack.Pop(); i = e + 1; continue; }
                    int j = i + 1; while (j < s.Length && !char.IsWhiteSpace(s[j]) && s[j] != '>' && s[j] != '/') j++;
                    var el = new Dom { Tag = s.Substring(i + 1, j - i - 1) };
                    i = j; bool selfClose = false;
                    for (;;)
                    {
                        while (i < s.Length && char.IsWhiteSpace(s[i])) i++;
                        if (s[i] == '>') { i++; break; }
                        if (s[i] == '/' && s[i + 1] == '>') { i += 2; selfClose = true; break; }
                        int a = i; while (i < s.Length && s[i] != '=' && !char.IsWhiteSpace(s[i]) && s[i] != '>') i++;
                        var an = s.Substring(a, i - a); string av = "";
                        if (s[i] == '=') { i++; char q = s[i]; if (q == '"' || q == '\'') { int e = s.IndexOf(q, i + 1); av = s.Substring(i + 1, e - i - 1); i = e + 1; } else { int b = i; while (!char.IsWhiteSpace(s[i]) && s[i] != '>') i++; av = s.Substring(b, i - b); } }
                        el.Attrs.Add(new KeyValuePair<string, string>(an, Unescape(av)));
                    }
                    stack.Peek().Children.Add(el);
                    if (!selfClose) stack.Push(el);
                }
                else
                {
                    int e = s.IndexOf('<', i); if (e < 0) e = s.Length;
                    var t = s.Substring(i, e - i);
                    if (t.Trim().Length > 0) stack.Peek().Children.Add(new Dom { Tag = "#text", Text = Unescape(t.Trim()) });
                    i = e;
                }
            }
            return top;
        }

        static string Unescape(string s) => s.IndexOf('&') < 0 ? s : s.Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#39;", "'").Replace("&amp;", "&");

        // ---- evaluation ----
        public sealed class Scope
        {
            public readonly JObj Vals; public readonly Scope Up; public readonly string Name; public readonly object Value;
            public Scope(JObj vals) { Vals = vals; }
            public Scope(Scope up, string name, object value) { Up = up; Name = name; Value = value; Vals = up.Vals; }
            public object Get(string path)
            {
                var parts = path.Split('.');
                object cur = null; bool found = false;
                for (var s = this; s != null; s = s.Up) if (s.Name == parts[0]) { cur = s.Value; found = true; break; }
                if (!found) cur = Vals[parts[0]];
                for (int i = 1; i < parts.Length; i++) cur = (cur as JObj)?[parts[i]];
                return cur;
            }
        }

        /// <summary>The room's markup for these values, with what the page puts in by hand after rendering (the fence's
        /// own markup into its group, fSync).</summary>
        public List<Dom> Render(JObj vals)
        {
            var o = new List<Dom>(); foreach (var c in root.Children) Eval(c, new Scope(vals), o);
            var fence = (vals["rt"] as JObj)?.Str("fenceHtml");
            if (!string.IsNullOrEmpty(fence))
            {
                var room = o.Find(x => x.Tag == "div"); var svg = room?.Children.Find(x => x.Tag == "svg");
                var g = svg?.Children.Find(x => x.Tag == "g" && (x["style"] ?? "").Replace(" ", "").Contains("pointer-events:none"));
                if (g != null) g.Children.AddRange(Parse(fence).Children);
            }
            return o;
        }

        static object Expr(string v, Scope sc, out bool whole)
        {
            whole = false;
            var t = v.Trim();
            if (t.StartsWith("{{") && t.EndsWith("}}") && t.IndexOf("{{", 2, StringComparison.Ordinal) < 0) { whole = true; return sc.Get(t.Substring(2, t.Length - 4).Trim()); }
            return null;
        }

        static string Interp(string v, Scope sc)
        {
            if (v.IndexOf("{{", StringComparison.Ordinal) < 0) return v;
            var sb = new StringBuilder(); int i = 0;
            while (i < v.Length)
            {
                int a = v.IndexOf("{{", i, StringComparison.Ordinal); if (a < 0) { sb.Append(v, i, v.Length - i); break; }
                sb.Append(v, i, a - i); int b = v.IndexOf("}}", a, StringComparison.Ordinal);
                var val = sc.Get(v.Substring(a + 2, b - a - 2).Trim());
                sb.Append(val == null || val == HouseJson.Undefined ? "" : HouseJson.JsString(val));
                i = b + 2;
            }
            return sb.ToString();
        }

        static void Eval(Dom n, Scope sc, List<Dom> into)
        {
            if (n.Tag == "#text") { into.Add(new Dom { Tag = "#text", Text = Interp(n.Text, sc) }); return; }
            if (n.Tag == "sc-if")
            {
                var v = Expr(n["value"] ?? "", sc, out _);
                if (HouseJson.Truthy(v)) foreach (var c in n.Children) Eval(c, sc, into);
                return;
            }
            if (n.Tag == "sc-for")
            {
                var list = Expr(n["list"] ?? "", sc, out _) as List<object>; var name = n["as"];
                if (list != null) foreach (var e in list) { var s2 = new Scope(sc, name, e); foreach (var c in n.Children) Eval(c, s2, into); }
                return;
            }
            var d = new Dom { Tag = n.Tag };
            foreach (var a in n.Attrs)
            {
                var k = a.Key;
                if (k == "ref" || k.StartsWith("on") || k.StartsWith("hint-") || k.StartsWith("style-")) continue;
                var v = Expr(a.Value, sc, out var whole);
                if (whole) { if (v == null || v == HouseJson.Undefined || v is JObj || v is List<object>) continue; d.Attrs.Add(new KeyValuePair<string, string>(k, HouseJson.JsString(v))); }
                else d.Attrs.Add(new KeyValuePair<string, string>(k, Interp(a.Value, sc)));
            }
            foreach (var c in n.Children) Eval(c, sc, d.Children);
            into.Add(d);
        }
    }
}
