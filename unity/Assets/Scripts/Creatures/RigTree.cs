// A creature frame as the vector code's node tree (Vector/SvgMarkup.cs SvgNode), straight from the rig's element tree
// on the browser stand-in: no SVG text in between. It is the tree SvgMarkup.Parse makes of RigHost.Svg's markup (the
// same tags, attributes in the same order, the same values: the fabric tile's href as "grain", a line break or a
// no-break space as a space, as the text's escaping and parsing leave them); tools/unity/rig-test checks the two
// against each other for every snapshot. The nodes are kept and refilled each frame (one pool per creature), and the
// strings are the rig's own, so a frame allocates next to nothing here. Unity-free (rig-test builds it with dotnet).
using System;
using System.Collections.Generic;
using System.Text;
using SquishSquad.Creatures.Js;
using SquishSquad.Vector;

namespace SquishSquad.Creatures
{
    public sealed class RigTree
    {
        readonly List<SvgNode> _pool = new List<SvgNode>(256);
        int _used;
        readonly StringBuilder _css = new StringBuilder(64);

        SvgNode Node(string tag, SvgNode parent)
        {
            SvgNode n;
            if (_used < _pool.Count) { n = _pool[_used]; n.Attrs.Clear(); n.Children.Clear(); n.Text = null; }
            else { n = new SvgNode(); _pool.Add(n); }
            _used++;
            n.Tag = tag; n.Parent = parent;
            return n;
        }

        /// <summary>The tree for the creature's &lt;svg&gt; element (a #root holding it), refilled in place: valid until
        /// the next Build. Null when there's no svg.</summary>
        public SvgNode Build(V svg)
        {
            _used = 0;
            if (!(svg.O is JsObject)) return null;
            var root = Node("#root", null);
            Add(root, svg);
            return root;
        }

        void Add(SvgNode parent, V n)
        {
            var o = (JsObject)n.O;
            double type = Rt.ToNum(o.Get("nodeType", n));
            if (type == 3)
            {
                // (the parser keeps a text that isn't all white space; a no-break space was written as &nbsp;)
                string t = Rt.ToStr(o.Get("data", n));
                if (!Visible(t)) return;
                var tn = Node("#text", parent);
                tn.Text = Clean(t);
                parent.Children.Add(tn);
                return;
            }
            var kids = o.Get("childNodes", n).O as JsArray;
            if (type == 11) { if (kids != null) for (int i = 0; i < kids.Len; i++) if (kids.At(i).O is JsObject) Add(parent, kids.At(i)); return; }
            var e = Node(Rt.ToStr(o.Get("localName", n)), parent);
            parent.Children.Add(e);
            if (o.Get("_attrs", n).O is JsArray attrs)
                for (int i = 0; i < attrs.Len; i++)
                {
                    var kv = attrs.At(i).O as JsArray;
                    if (kv == null) continue;
                    string k = Rt.ToStr(kv.At(0)), v = Rt.ToStr(kv.At(1));
                    if (k.EndsWith("href", StringComparison.Ordinal) && v.StartsWith("shim-canvas:", StringComparison.Ordinal) && v.IndexOf('"') < 0) v = "grain";
                    else v = Clean(v);
                    e.Attrs.Add(new KeyValuePair<string, string>(k, v));
                }
            var st = o.Get("style", n);
            if (st.O is JsObject so && so.N > 0)
            {
                // Style's cssText (Js/Dom.cs Serialize: the same text)
                _css.Clear();
                foreach (var k in so.OwnKeys(true))
                {
                    var v = so.Get(k, st);
                    if ((v.O is string vs && vs.Length == 0) || v.IsNullish) continue;
                    if (_css.Length > 0) _css.Append(' ');
                    Dom.Kebab(_css, k);
                    _css.Append(": ").Append(Rt.ToStr(v)).Append(';');
                }
                if (_css.Length > 0)
                {
                    e.Attrs.Add(new KeyValuePair<string, string>("style", Clean(_css.ToString())));
                }
            }
            if (kids != null) for (int i = 0; i < kids.Len; i++) if (kids.At(i).O is JsObject) Add(e, kids.At(i));
        }

        static bool Visible(string t)
        {
            foreach (char c in t) if (c == ' ' || !char.IsWhiteSpace(c)) return true;
            return false;
        }

        // what writing and reading the text does to a value: line breaks (RigHost.Svg) and no-break spaces (&nbsp;, which
        // SvgMarkup reads as a space) become spaces
        static string Clean(string v)
        {
            if (v.IndexOf('\n') >= 0) v = v.Replace('\n', ' ');
            if (v.IndexOf(' ') >= 0) v = v.Replace(' ', ' ');
            return v;
        }

        /// <summary>Whether two trees are the same (tags, texts, attributes in order, children): the check that the
        /// direct tree is the parsed one.</summary>
        public static bool Same(SvgNode a, SvgNode b, out string where)
        {
            where = null;
            if (a.Tag != b.Tag || a.Text != b.Text) { where = a.Tag + " / " + b.Tag; return false; }
            if (a.Attrs.Count != b.Attrs.Count) { where = a.Tag + ": " + a.Attrs.Count + " / " + b.Attrs.Count + " attributes"; return false; }
            for (int i = 0; i < a.Attrs.Count; i++)
                if (a.Attrs[i].Key != b.Attrs[i].Key || a.Attrs[i].Value != b.Attrs[i].Value) { where = a.Tag + " " + a.Attrs[i].Key + "=" + a.Attrs[i].Value + " / " + b.Attrs[i].Key + "=" + b.Attrs[i].Value; return false; }
            if (a.Children.Count != b.Children.Count) { where = a.Tag + ": " + a.Children.Count + " / " + b.Children.Count + " children"; return false; }
            for (int i = 0; i < a.Children.Count; i++) if (!Same(a.Children[i], b.Children[i], out where)) return false;
            return true;
        }
    }
}
