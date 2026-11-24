// A creature frame's SVG as something a renderer draws: a tree of filled shapes (polygons and a fill rule, see
// Outline.cs, each with its paint and opacity) and layers (group opacity, clip paths, masks, filters), in output pixels. The rules are SVG's:
// inherited fill / stroke properties, opacity on the element, a group with opacity, clip-path, mask or filter drawn
// as one layer, clip paths in the user space of the element that uses them.
using System;
using System.Collections.Generic;

namespace SquishSquad.Vector
{
    public abstract class RenderNode { }

    public sealed class FillNode : RenderNode
    {
        public Shape Shape;
        public Paint Paint;
        public float Opacity = 1;
        public Box UserBox;           // the shape's box in its user space (objectBoundingBox gradients)
        public Affine UserToPx;       // its user space to output px (gradients are evaluated in user space)
    }

    public sealed class LayerNode : RenderNode
    {
        public readonly List<RenderNode> Children = new List<RenderNode>();
        public float Opacity = 1;
        public List<Shape> Clip;        // the clip's coverage (the union of these shapes), or null
        public LayerNode Mask;          // drawn on its own: its luminance x alpha multiplies this layer
        public Box MaskRegionPx = Box.Empty;
        public SvgNode Filter;          // the <filter> element, interpreted by the renderer
        public Affine UserToPx = Affine.Identity;
        public Box UserBox = Box.Empty; // the element's box in its user space (filter / mask regions in objectBoundingBox units)
        public string Name;
    }

    public sealed class SvgScene
    {
        public LayerNode Root;
        public readonly Dictionary<string, SvgNode> Ids = new Dictionary<string, SvgNode>();
        public double Tolerance = Geometry.DefaultTolerance;
        /// <summary>The pixel size of a picture an &lt;image&gt; names (for preserveAspectRatio); unknown: drawn as "none".</summary>
        public Func<string, (int w, int h)?> ImageSize;

        sealed class Style
        {
            public string Fill = "#000", Stroke = "none", FillRule = "nonzero", LineJoin = "miter", LineCap = "butt", Color = "#000", Visibility = "visible";
            public float FillOpacity = 1, StrokeOpacity = 1, StrokeWidth = 1, MiterLimit = 4;
            public Style Clone() => (Style)MemberwiseClone();
        }

        // the outermost <svg> mapped onto a box of `size` px (viewBox, preserveAspectRatio xMidYMid meet)
        public static SvgScene Compile(SvgNode root, double width, double height) => Compile(root, width, height, Affine.Identity);

        // `outer` maps the <svg>'s width x height box into the output (e.g. a margin for parts drawn outside it)
        public static SvgScene Compile(SvgNode root, double width, double height, Affine outer) => Compile(root, width, height, outer, null);

        public static SvgScene Compile(SvgNode root, double width, double height, Affine outer, Func<string, (int w, int h)?> imageSize)
        {
            var sc = new SvgScene { ImageSize = imageSize };
            Index(root, sc.Ids);
            var svg = Find(root, "svg");
            sc.Root = new LayerNode { Name = "root" };
            if (svg == null) return sc;
            var m = outer * ViewBoxTransform(svg, width, height);
            sc.Children(svg, m, new Style(), sc.Root.Children);
            return sc;
        }

        static SvgNode Find(SvgNode n, string tag) { if (n.Tag == tag) return n; foreach (var c in n.Children) { var r = Find(c, tag); if (r != null) return r; } return null; }
        static void Index(SvgNode n, Dictionary<string, SvgNode> ids) { var id = n["id"]; if (id != null && !ids.ContainsKey(id)) ids[id] = n; foreach (var c in n.Children) Index(c, ids); }

        static Affine ViewBoxTransform(SvgNode svg, double w, double h)
        {
            var vb = svg["viewBox"];
            if (string.IsNullOrEmpty(vb)) return Affine.Identity;
            int i = 0; SvgNum.TryRead(vb, ref i, out var x); SvgNum.TryRead(vb, ref i, out var y); SvgNum.TryRead(vb, ref i, out var vw); SvgNum.TryRead(vb, ref i, out var vh);
            if (vw <= 0 || vh <= 0) return Affine.Identity;
            // preserveAspectRatio: "none", or an alignment (xMin|xMid|xMax + YMin|YMid|YMax) and meet (fit) / slice (fill)
            var par = (svg["preserveAspectRatio"] ?? "xMidYMid meet").Trim();
            if (par.StartsWith("none")) return Affine.ScaleBy(w / vw, h / vh) * Affine.Translate(-x, -y);
            bool slice = par.Contains("slice");
            double s = slice ? Math.Max(w / vw, h / vh) : Math.Min(w / vw, h / vh);
            double ax = par.Contains("xMin") ? 0 : par.Contains("xMax") ? 1 : 0.5, ay = par.Contains("YMin") ? 0 : par.Contains("YMax") ? 1 : 0.5;
            double tx = (w - vw * s) * ax, ty = (h - vh * s) * ay;
            return Affine.Translate(tx, ty) * Affine.ScaleBy(s, s) * Affine.Translate(-x, -y);
        }

        static bool Hidden(SvgNode n)
        {
            var d = n.Prop("display");
            return d != null && d.Trim() == "none";
        }

        void Children(SvgNode parent, Affine m, Style st, List<RenderNode> into)
        {
            foreach (var c in parent.Children) Element(c, m, st, into);
        }

        Style Inherit(SvgNode n, Style parent)
        {
            var s = parent.Clone();
            string v;
            if ((v = n.Prop("fill")) != null) s.Fill = v;
            if ((v = n.Prop("stroke")) != null) s.Stroke = v;
            if ((v = n.Prop("fill-rule")) != null) s.FillRule = v;
            if ((v = n.Prop("stroke-linejoin")) != null) s.LineJoin = v;
            if ((v = n.Prop("stroke-linecap")) != null) s.LineCap = v;
            if ((v = n.Prop("color")) != null) s.Color = v;
            if ((v = n.Prop("visibility")) != null) s.Visibility = v;
            if ((v = n.Prop("fill-opacity")) != null) s.FillOpacity = Clamp01(SvgNum.Parse(v, 1));
            if ((v = n.Prop("stroke-opacity")) != null) s.StrokeOpacity = Clamp01(SvgNum.Parse(v, 1));
            if ((v = n.Prop("stroke-width")) != null) s.StrokeWidth = SvgNum.Parse(v, 1);
            if ((v = n.Prop("stroke-miterlimit")) != null) s.MiterLimit = SvgNum.Parse(v, 4);
            return s;
        }

        static float Clamp01(float v) => v < 0 ? 0 : v > 1 ? 1 : v;

        void Element(SvgNode n, Affine parentM, Style parentStyle, List<RenderNode> into)
        {
            switch (n.Tag)
            {
                case "defs": case "clipPath": case "mask": case "linearGradient": case "radialGradient": case "filter":
                case "#text": case "style": case "title": case "desc": case "metadata": case "symbol": case "marker": case "pattern":
                    return;
            }
            if (Hidden(n)) return;
            var m = parentM * Affine.Parse(n["transform"]);
            var st = Inherit(n, parentStyle);
            float opacity = Clamp01(n.Num("opacity", 1));
            if (n.Prop("opacity") != null && n["opacity"] == null) opacity = Clamp01(SvgNum.Parse(n.Prop("opacity"), 1));
            if (opacity <= 0) return;   // the rigs keep many parts at opacity 0 until they're needed: nothing to draw
            string clip = UrlId(n.Prop("clip-path")), mask = UrlId(n.Prop("mask")), filter = UrlId(n.Prop("filter"));
            bool isShape = n.Tag == "path" || n.Tag == "rect" || n.Tag == "circle" || n.Tag == "ellipse" || n.Tag == "line" || n.Tag == "polyline" || n.Tag == "polygon";
            // a layer for a group with opacity, and for anything clipped, masked or filtered; a lone shape's opacity
            // folds into its paint unless it has both a fill and a stroke (then they'd show through each other)
            bool bothPainted = isShape && Resolve(st.Fill, st.Color).Kind != PaintKind.None && Resolve(st.Stroke, st.Color).Kind != PaintKind.None && st.StrokeWidth > 0;
            bool layer = clip != null || mask != null || filter != null || (opacity < 1 && (!isShape || bothPainted));

            var list = into;
            LayerNode L = null;
            if (layer)
            {
                L = new LayerNode { Opacity = opacity, UserToPx = m, Name = n.Tag + (n["id"] != null ? "#" + n["id"] : "") };
                list = L.Children;
            }

            if (n.Tag == "g" || n.Tag == "svg" || n.Tag == "a" || n.Tag == "switch")
            {
                var cm = m;
                if (n.Tag == "svg" && n.Parent != null && n.Parent.Tag != "#root")
                {
                    // a nested <svg>: its viewport and viewBox
                    double x = n.Num("x"), y = n.Num("y");
                    double w = Colors.Fraction(n["width"], 1), h = Colors.Fraction(n["height"], 1);
                    if (n["width"] != null && !n["width"].EndsWith("%")) w = n.Num("width"); else w = 100 * w;
                    if (n["height"] != null && !n["height"].EndsWith("%")) h = n.Num("height"); else h = 100 * h;
                    cm = m * Affine.Translate(x, y) * ViewBoxTransform(n, w, h);
                }
                Children(n, cm, st, list);
            }
            else if (n.Tag == "use")
            {
                var href = n["href"] ?? n["xlink:href"];
                if (href != null && href.StartsWith("#") && Ids.TryGetValue(href.Substring(1), out var target) && !IsAncestor(target, n))
                    Element(target, m * Affine.Translate(n.Num("x"), n.Num("y")), st, list);
            }
            else if (isShape)
            {
                if (st.Visibility == "hidden" || st.Visibility == "collapse") { }
                else Shape(n, m, st, layer ? 1f : opacity, list, layer);
            }
            else if (n.Tag == "image")
            {
                if (st.Visibility != "hidden" && st.Visibility != "collapse") Image(n, m, layer ? 1f : opacity, list);
            }
            else return;   // text and unknown elements: the UI exporter turns text into glyph paths

            if (L == null) return;
            if (L.Children.Count == 0) return;
            L.UserBox = UserBoxOf(L.Children, m);
            if (clip != null && Ids.TryGetValue(clip, out var cp)) L.Clip = ClipCoverage(cp, m, L.UserBox);
            if (mask != null && Ids.TryGetValue(mask, out var mk)) MaskLayer(L, mk, m);
            if (filter != null && Ids.TryGetValue(filter, out var fe)) L.Filter = fe;
            into.Add(L);
        }

        static bool IsAncestor(SvgNode a, SvgNode n) { for (var p = n; p != null; p = p.Parent) if (p == a) return true; return false; }

        // one shape: its fill, then its stroke (with the element's opacity folded in when it's not drawn as a layer;
        // when both are painted and the opacity is below 1 the caller has made a layer)
        void Shape(SvgNode n, Affine m, Style st, float opacity, List<RenderNode> into, bool inLayer)
        {
            var fill = Resolve(st.Fill, st.Color);
            var stroke = Resolve(st.Stroke, st.Color);
            if (fill.Kind == PaintKind.None && stroke.Kind == PaintKind.None) return;
            var outline = Geometry.Flatten(n, m, Tolerance, out var box);
            if (outline.IsEmpty) return;
            if (fill.Kind != PaintKind.None)
            {
                var sh = Outline.Fill(outline, st.FillRule == "evenodd");
                if (!sh.IsEmpty) into.Add(new FillNode { Shape = sh, Paint = fill, Opacity = opacity * st.FillOpacity, UserBox = box, UserToPx = m });
            }
            if (stroke.Kind != PaintKind.None && st.StrokeWidth > 0)
            {
                var join = st.LineJoin == "round" ? Outline.Join.Round : st.LineJoin == "bevel" ? Outline.Join.Bevel : Outline.Join.Miter;
                var cap = st.LineCap == "round" ? Outline.Cap.Round : st.LineCap == "square" ? Outline.Cap.Square : Outline.Cap.Butt;
                var dashed = outline;
                var dash = n.Prop("stroke-dasharray");
                if (!string.IsNullOrEmpty(dash) && dash.Trim() != "none")
                {
                    var list = new List<double>();
                    int i = 0;
                    while (SvgNum.TryRead(dash, ref i, out var v)) list.Add(v * m.Scale);
                    if (list.Count % 2 == 1) list.AddRange(list.ToArray());
                    double off = SvgNum.Parse(n.Prop("stroke-dashoffset") ?? "0", 0) * m.Scale;
                    dashed = Outline.Dash(outline, list, off);
                }
                var sh = Outline.Stroke(dashed, st.StrokeWidth * m.Scale, join, cap, st.MiterLimit, Tolerance);
                if (!sh.IsEmpty) into.Add(new FillNode { Shape = sh, Paint = stroke, Opacity = opacity * st.StrokeOpacity, UserBox = box, UserToPx = m });
            }
        }

        // a picture in its viewport (x, y, width, height), placed by preserveAspectRatio: a rect filled with it, the
        // part of the picture's rect inside the viewport
        void Image(SvgNode n, Affine m, float opacity, List<RenderNode> into)
        {
            var href = n["href"] ?? n["xlink:href"];
            double x = n.Num("x"), y = n.Num("y"), w = n.Num("width"), h = n.Num("height");
            if (string.IsNullOrEmpty(href) || w <= 0 || h <= 0) return;
            double ix = x, iy = y, iw = w, ih = h;
            var size = ImageSize?.Invoke(href);
            var par = (n["preserveAspectRatio"] ?? "xMidYMid meet").Trim();
            if (size.HasValue && size.Value.w > 0 && size.Value.h > 0 && !par.StartsWith("none"))
            {
                double sw = size.Value.w, sh = size.Value.h;
                double k = par.Contains("slice") ? Math.Max(w / sw, h / sh) : Math.Min(w / sw, h / sh);
                iw = sw * k; ih = sh * k;
                double ax = par.Contains("xMin") ? 0 : par.Contains("xMax") ? 1 : 0.5, ay = par.Contains("YMin") ? 0 : par.Contains("YMax") ? 1 : 0.5;
                ix = x + (w - iw) * ax; iy = y + (h - ih) * ay;
            }
            double x0 = Math.Max(x, ix), y0 = Math.Max(y, iy), x1 = Math.Min(x + w, ix + iw), y1 = Math.Min(y + h, iy + ih);
            if (x1 <= x0 || y1 <= y0) return;
            var poly = Vec2Pool.Get(4); poly.Add(m.Apply(new Vec2(x0, y0))); poly.Add(m.Apply(new Vec2(x1, y0))); poly.Add(m.Apply(new Vec2(x1, y1))); poly.Add(m.Apply(new Vec2(x0, y1)));
            var shape = new Shape { Rule = FillRule.NonZero };
            shape.Polygons.Add(poly);
            var paint = new Paint { Kind = PaintKind.Image, Image = href, BoundingBoxUnits = false, UserToImage = Affine.ScaleBy(1 / iw, 1 / ih) * Affine.Translate(-ix, -iy) };
            var box = new Box { X0 = x0, Y0 = y0, X1 = x1, Y1 = y1 };
            into.Add(new FillNode { Shape = shape, Paint = paint, Opacity = opacity, UserBox = box, UserToPx = m });
        }

        Paint Resolve(string value, string currentColor)
        {
            if (string.IsNullOrEmpty(value)) return Paint.None;
            value = value.Trim();
            if (value == "none") return Paint.None;
            if (value == "currentColor") value = currentColor;
            if (value.StartsWith("url("))
            {
                var id = UrlId(value);
                if (id != null && Ids.TryGetValue(id, out var g) && (g.Tag == "linearGradient" || g.Tag == "radialGradient")) return Gradient(g);
                // the fallback after the url, if any
                int e = value.IndexOf(')');
                var rest = e >= 0 ? value.Substring(e + 1).Trim() : "";
                return rest.Length > 0 ? Resolve(rest, currentColor) : Paint.None;
            }
            return Colors.TryParse(value, out var c) ? Paint.Solid(c) : Paint.None;
        }

        readonly Dictionary<SvgNode, Paint> _gradients = new Dictionary<SvgNode, Paint>();

        Paint Gradient(SvgNode g)
        {
            if (_gradients.TryGetValue(g, out var cached)) return cached;
            var p = new Paint { Kind = g.Tag == "linearGradient" ? PaintKind.Linear : PaintKind.Radial };
            // attributes and stops may come from a gradient this one links to
            SvgNode Attr(string name) { for (var x = g; x != null; x = Linked(x)) if (x[name] != null) return x; return null; }
            string A(string name) => Attr(name)?[name];
            p.BoundingBoxUnits = A("gradientUnits") != "userSpaceOnUse";
            p.GradientTransform = Affine.Parse(A("gradientTransform"));
            var spread = A("spreadMethod");
            p.Spread = spread == "reflect" ? 1 : spread == "repeat" ? 2 : 0;
            double D(string name, double def) => Colors.Fraction(A(name), def);
            if (p.Kind == PaintKind.Linear) { p.X1 = D("x1", 0); p.Y1 = D("y1", 0); p.X2 = D("x2", 1); p.Y2 = D("y2", 0); }
            else { p.Cx = D("cx", 0.5); p.Cy = D("cy", 0.5); p.R = D("r", 0.5); p.Fx = D("fx", p.Cx); p.Fy = D("fy", p.Cy); }
            SvgNode stopsFrom = g;
            for (var x = g; x != null; x = Linked(x)) { bool has = false; foreach (var c in x.Children) if (c.Tag == "stop") { has = true; break; } if (has) { stopsFrom = x; break; } }
            float last = 0;
            foreach (var s in stopsFrom.Children)
            {
                if (s.Tag != "stop") continue;
                float off = (float)Math.Max(last, Math.Min(1, Math.Max(0, Colors.Fraction(s["offset"], 0))));
                last = off;
                Colors.TryParse(s.Prop("stop-color") ?? "#000", out var col);
                col.A *= Clamp01(SvgNum.Parse(s.Prop("stop-opacity") ?? "1", 1));
                p.Stops.Add((off, col));
            }
            if (p.Stops.Count == 1) { var only = p.Stops[0].color; p = Paint.Solid(only); }
            else if (p.Stops.Count == 0) p = Paint.None;
            _gradients[g] = p;
            return p;
        }

        SvgNode Linked(SvgNode g)
        {
            var h = g["href"] ?? g["xlink:href"];
            return h != null && h.StartsWith("#") && Ids.TryGetValue(h.Substring(1), out var t) && t != g ? t : null;
        }

        static string UrlId(string v)
        {
            if (string.IsNullOrEmpty(v)) return null;
            int a = v.IndexOf("url(", StringComparison.Ordinal);
            if (a < 0) return null;
            int b = v.IndexOf(')', a);
            if (b < 0) return null;
            var inner = v.Substring(a + 4, b - a - 4).Trim().Trim('"', '\'');
            return inner.StartsWith("#") ? inner.Substring(1) : null;
        }

        // a layer's box in the user space of its element (for objectBoundingBox clip / mask / filter units)
        static Box UserBoxOf(List<RenderNode> nodes, Affine m)
        {
            var inv = m.Inverse();
            var b = Box.Empty;
            foreach (var n in nodes)
            {
                if (n is FillNode f) { var px = f.Shape.Bounds; if (!px.IsEmpty) { b.Add(inv.Apply(new Vec2(px.X0, px.Y0))); b.Add(inv.Apply(new Vec2(px.X1, px.Y1))); b.Add(inv.Apply(new Vec2(px.X0, px.Y1))); b.Add(inv.Apply(new Vec2(px.X1, px.Y0))); } }
                else if (n is LayerNode l) { var ub = UserBoxOf(l.Children, m); b.Add(ub); }
            }
            return b;
        }

        // a clip path's coverage: the union of its shapes, in the user space of the clipped element
        List<Shape> ClipCoverage(SvgNode clipPath, Affine m, Box userBox)
        {
            var cm = m * Affine.Parse(clipPath["transform"]);
            if (clipPath["clipPathUnits"] == "objectBoundingBox" && !userBox.IsEmpty)
                cm = cm * Affine.Translate(userBox.X0, userBox.Y0) * Affine.ScaleBy(userBox.W, userBox.H);
            var list = new List<Shape>();
            void Add(SvgNode c, Affine at)
            {
                if (Hidden(c)) return;
                var cmm = at * Affine.Parse(c["transform"]);
                if (c.Tag == "use")
                {
                    var href = c["href"] ?? c["xlink:href"];
                    if (href != null && href.StartsWith("#") && Ids.TryGetValue(href.Substring(1), out var t)) Add(t, cmm * Affine.Translate(c.Num("x"), c.Num("y")));
                    return;
                }
                if (c.Tag == "g") { foreach (var k in c.Children) Add(k, cmm); return; }
                var outline = Geometry.Flatten(c, cmm, Tolerance, out _);
                if (outline.IsEmpty) return;
                var sh = Outline.Fill(outline, (c.Prop("clip-rule") ?? clipPath.Prop("clip-rule")) == "evenodd");
                if (!sh.IsEmpty) list.Add(sh);
            }
            foreach (var c in clipPath.Children) Add(c, cm);
            return list;
        }

        void MaskLayer(LayerNode L, SvgNode mask, Affine m)
        {
            var content = new LayerNode { Name = "mask" };
            var cm = m;
            if (mask["maskContentUnits"] == "objectBoundingBox" && !L.UserBox.IsEmpty)
                cm = m * Affine.Translate(L.UserBox.X0, L.UserBox.Y0) * Affine.ScaleBy(L.UserBox.W, L.UserBox.H);
            Children(mask, cm, new Style(), content.Children);
            L.Mask = content;
            // the mask's region (x, y, width, height), in px
            var b = L.UserBox;
            Box r;
            if (mask["maskUnits"] == "userSpaceOnUse")
                r = new Box { X0 = mask.Num("x", -1e6f), Y0 = mask.Num("y", -1e6f), X1 = mask.Num("x", -1e6f) + mask.Num("width", 2e6f), Y1 = mask.Num("y", -1e6f) + mask.Num("height", 2e6f) };
            else
            {
                double fx = Colors.Fraction(mask["x"], -0.1), fy = Colors.Fraction(mask["y"], -0.1), fw = Colors.Fraction(mask["width"], 1.2), fh = Colors.Fraction(mask["height"], 1.2);
                r = new Box { X0 = b.X0 + fx * b.W, Y0 = b.Y0 + fy * b.H, X1 = b.X0 + (fx + fw) * b.W, Y1 = b.Y0 + (fy + fh) * b.H };
            }
            var px = Box.Empty;
            px.Add(m.Apply(new Vec2(r.X0, r.Y0))); px.Add(m.Apply(new Vec2(r.X1, r.Y0))); px.Add(m.Apply(new Vec2(r.X0, r.Y1))); px.Add(m.Apply(new Vec2(r.X1, r.Y1)));
            L.MaskRegionPx = px;
        }
    }
}
