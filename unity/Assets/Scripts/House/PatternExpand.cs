// A stand-in for SVG <pattern> fills until the vector renderer (Assets/Scripts/Vector) draws them: every shape filled
// with url(#pattern) becomes its pattern's tiles (the pattern's content repeated over the shape's box, in the pattern's
// own space: x / y / width / height, patternTransform, userSpaceOnUse or objectBoundingBox units, image content too),
// clipped by the shape. Its stroke, if any, is drawn after. Each tile's content isn't clipped to its tile (patterns
// whose content crosses the tile edge differ there). The house uses patterns everywhere: the wall papers, the floor's
// paint speckle, the wood / fabric / metal grain on every house4 part, the renovated walls and fences.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Vector;

namespace SquishSquad.House
{
    public static class PatternExpand
    {
        public static int MaxTiles = 6000;
        public static int Expanded, Tiles, Capped;

        static string N(double v) => v.ToString("R", CultureInfo.InvariantCulture);

        public static void Expand(SvgNode root)
        {
            var ids = new Dictionary<string, SvgNode>();
            Index(root, ids);
            int clipN = 0;
            Walk(root, ids, ref clipN);
        }

        static void Index(SvgNode n, Dictionary<string, SvgNode> ids) { var id = n["id"]; if (id != null && !ids.ContainsKey(id)) ids[id] = n; foreach (var c in n.Children) Index(c, ids); }

        static string Prop(SvgNode n, string k)
        {
            var st = n["style"];
            if (st != null) foreach (var p in st.Split(';')) { int i = p.IndexOf(':'); if (i > 0 && p.Substring(0, i).Trim() == k) return p.Substring(i + 1).Trim(); }
            return n[k];
        }
        static string UrlId(string v) { if (v == null) return null; int a = v.IndexOf("url(#", StringComparison.Ordinal); if (a < 0) return null; int b = v.IndexOf(')', a); return b < 0 ? null : v.Substring(a + 5, b - a - 5).Trim('"', '\''); }

        static void Walk(SvgNode n, Dictionary<string, SvgNode> ids, ref int clipN)
        {
            for (int i = 0; i < n.Children.Count; i++)
            {
                var c = n.Children[i];
                if (c.Tag == "pattern" || c.Tag == "defs" || c.Tag == "clipPath" || c.Tag == "mask") continue;
                bool shape = c.Tag == "path" || c.Tag == "rect" || c.Tag == "circle" || c.Tag == "ellipse" || c.Tag == "polygon" || c.Tag == "polyline";
                var fill = shape ? Prop(c, "fill") : null; var pid = UrlId(fill);
                if (pid != null && ids.TryGetValue(pid, out var pat) && pat.Tag == "pattern")
                {
                    var g = Replace(c, pat, ids, ref clipN);
                    if (g != null) { g.Parent = n; n.Children[i] = g; Walk(g, ids, ref clipN); }   // (tiles can hold pattern fills of their own)
                    continue;
                }
                Walk(c, ids, ref clipN);
            }
        }

        static SvgNode El(string tag, params string[] kv) { var e = new SvgNode { Tag = tag }; for (int i = 0; i < kv.Length; i += 2) if (kv[i + 1] != null) e.Attrs.Add(new KeyValuePair<string, string>(kv[i], kv[i + 1])); return e; }
        static void Add(SvgNode p, SvgNode c) { c.Parent = p; p.Children.Add(c); }
        static SvgNode Clone(SvgNode n, bool dropFill)
        {
            var o = new SvgNode { Tag = n.Tag, Text = n.Text };
            foreach (var a in n.Attrs) { if (dropFill && (a.Key == "fill" || a.Key == "transform" || a.Key == "opacity" || a.Key == "fill-opacity" || a.Key == "style")) continue; o.Attrs.Add(a); }
            foreach (var c in n.Children) Add(o, Clone(c, false));
            return o;
        }
        // the pattern's attribute, following href links like gradients
        static string PA(SvgNode p, Dictionary<string, SvgNode> ids, string k)
        {
            for (var x = p; x != null;)
            {
                if (x[k] != null) return x[k];
                var h = x["href"] ?? x["xlink:href"]; x = h != null && h.StartsWith("#") && ids.TryGetValue(h.Substring(1), out var t) && t != x ? t : null;
            }
            return null;
        }
        static double Num(string v, double def) => v == null ? def : SvgNum.Parse(v, (float)def);

        static SvgNode Replace(SvgNode shape, SvgNode pat, Dictionary<string, SvgNode> ids, ref int clipN)
        {
            // the shape's box in its own user space
            var tmp = Clone(shape, true);
            Geometry.Flatten(tmp, Affine.Identity, 0.5, out var box);
            var tf = shape["transform"];
            var g = El("g", "transform", tf, "opacity", Prop(shape, "opacity"));
            double fo = Num(Prop(shape, "fill-opacity"), 1);
            var stroke = Prop(shape, "stroke");
            if (!box.IsEmpty && box.X1 - box.X0 > 0 && box.Y1 - box.Y0 > 0)
            {
                var cid = "__pc" + (clipN++);
                var cp = El("clipPath", "id", cid); Add(cp, Clone(shape, true)); Add(g, cp);
                var inner = El("g", "clip-path", "url(#" + cid + ")", "opacity", fo < 1 ? N(fo) : null); Add(g, inner);
                bool bbUnits = PA(pat, ids, "patternUnits") != "userSpaceOnUse";
                bool contentBB = PA(pat, ids, "patternContentUnits") == "objectBoundingBox";
                double bw = box.X1 - box.X0, bh = box.Y1 - box.Y0;
                double px = Num(PA(pat, ids, "x"), 0), py = Num(PA(pat, ids, "y"), 0), pw = Num(PA(pat, ids, "width"), 0), ph = Num(PA(pat, ids, "height"), 0);
                if (bbUnits) { px = box.X0 + px * bw; py = box.Y0 + py * bh; pw *= bw; ph *= bh; }
                var ptf = Affine.Parse(PA(pat, ids, "patternTransform"));
                // the pattern's content (it may come from a linked pattern)
                SvgNode src = pat; for (var x = pat; x != null;) { if (x.Children.Count > 0) { src = x; break; } var h = x["href"] ?? x["xlink:href"]; x = h != null && h.StartsWith("#") && ids.TryGetValue(h.Substring(1), out var t2) && t2 != x ? t2 : null; }
                if (pw > 0 && ph > 0)
                {
                    // the shape's box in pattern space -> the tiles that cover it
                    var inv = ptf.Inverse(); var pb = Box.Empty;
                    foreach (var q in new[] { new Vec2(box.X0, box.Y0), new Vec2(box.X1, box.Y0), new Vec2(box.X0, box.Y1), new Vec2(box.X1, box.Y1) }) pb.Add(inv.Apply(q));
                    int i0 = (int)Math.Floor((pb.X0 - px) / pw), i1 = (int)Math.Ceiling((pb.X1 - px) / pw), j0 = (int)Math.Floor((pb.Y0 - py) / ph), j1 = (int)Math.Ceiling((pb.Y1 - py) / ph);
                    long n = (long)(i1 - i0) * (j1 - j0);
                    if (n > MaxTiles) { Capped++; n = 0; }
                    var tiles = El("g", "transform", PA(pat, ids, "patternTransform"));
                    var vb = PA(pat, ids, "viewBox");
                    for (int j = j0; j < j1 && n > 0; j++)
                        for (int i = i0; i < i1; i++)
                        {
                            string ct = "translate(" + N(px + i * pw) + " " + N(py + j * ph) + ")";
                            if (contentBB) ct += " scale(" + N(bw) + " " + N(bh) + ")";
                            else if (vb != null) { var v = vb.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries); double vx = Num(v[0], 0), vy = Num(v[1], 0), vw = Num(v[2], 1), vh = Num(v[3], 1); ct += " scale(" + N(pw / vw) + " " + N(ph / vh) + ") translate(" + N(-vx) + " " + N(-vy) + ")"; }
                            var tg = El("g", "transform", ct);
                            foreach (var c in src.Children) Add(tg, Clone(c, false));
                            Add(tiles, tg); Tiles++;
                        }
                    Add(inner, tiles);
                }
                Expanded++;
            }
            if (stroke != null && stroke != "none")
            {
                var s2 = Clone(shape, true); s2.Attrs.Add(new KeyValuePair<string, string>("fill", "none"));
                var st = shape["style"]; if (st != null) s2.Attrs.Add(new KeyValuePair<string, string>("style", System.Text.RegularExpressions.Regex.Replace(st, @"fill\s*:[^;]*;?", "")));
                Add(g, s2);
            }
            return g;
        }
    }
}
