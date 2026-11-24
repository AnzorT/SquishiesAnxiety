// The room's markup (HouseTemplate's Dom: SVG inside positioned HTML boxes) as one SVG the vector renderer draws: the
// 852 x 393 house box. What the page's CSS does is done here: each box's left / top / transform (scale about its
// transform-origin) becomes a group transform, boxes are painted in CSS stacking order (z-index, then document order),
// a background colour or radial-gradient becomes a rect with a gradient, and every picture (<image href="name">) is
// inlined from Resources/House/pics (its ids prefixed so pictures don't share gradients), or kept as an image when it
// ships as PNG; a box's clip-path: path(...) clips its children. The dance room's CSS-3D floor (rt.flatOn: a rotateX
// plane under a parent's perspective) is a picture HouseFlat draws (<image href="flat:..">). Not drawn yet: HTML text
// (sh.texts, signs): Notes says so.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public sealed class RoomCompose
    {
        /// <summary>name -> the picture's SVG text (null: not an SVG picture)</summary>
        public Func<string, string> PicSvg;
        /// <summary>name -> the picture's PNG href (what &lt;image&gt; gets) and its size in room units (from its viewBox)</summary>
        public Func<string, string> PicPng;
        public readonly List<string> Notes = new List<string>();
        int picN;

        static string N(double v) => v.ToString("R", CultureInfo.InvariantCulture);
        static double P(string s) { if (string.IsNullOrEmpty(s)) return 0; var m = Regex.Match(s, @"-?\d*\.?\d+(e-?\d+)?"); return m.Success ? double.Parse(m.Value, CultureInfo.InvariantCulture) : 0; }

        public static Dictionary<string, string> Style(string st)
        {
            var o = new Dictionary<string, string>();
            if (st == null) return o;
            foreach (var p in st.Split(';')) { int i = p.IndexOf(':'); if (i < 0) continue; o[p.Substring(0, i).Trim().ToLowerInvariant()] = p.Substring(i + 1).Trim(); }
            return o;
        }

        /// <summary>The whole house box (852 x 393): the room and the night overlay, from the template's output.
        /// `view` (x, y, w, h in frame px): the part of the frame drawn, 852 x 393 from 0, 0 by default; the house screen
        /// draws more around it (what the camera's 0.85 zoom shows; HouseRoomView). `background` false: no frame colour
        /// under it (a layer drawn over another: the night overlay).</summary>
        public string Compose(List<Dom> top, string fenceHtml, double[] view = null, bool background = true)
        {
            var sb = new StringBuilder();
            var v = view ?? new double[] { 0, 0, 852, 393 };
            string vb = string.Join(" ", Array.ConvertAll(v, d => d.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"").Append(vb).Append("\">");
            if (background) sb.Append("<rect x=\"").Append(v[0].ToString(System.Globalization.CultureInfo.InvariantCulture)).Append("\" y=\"").Append(v[1].ToString(System.Globalization.CultureInfo.InvariantCulture))
              .Append("\" width=\"").Append(v[2].ToString(System.Globalization.CultureInfo.InvariantCulture)).Append("\" height=\"").Append(v[3].ToString(System.Globalization.CultureInfo.InvariantCulture)).Append("\" fill=\"#f6ead8\"/>");
            foreach (var n in top) if (n.Tag == "div") Box(n, sb, 852, 393, fenceHtml);
            sb.Append("</svg>");
            return sb.ToString();
        }

        // a positioned HTML box: its transform, its background, its children (svgs and boxes) in stacking order
        // persp: the parent's CSS perspective (d, origin x, y in this box's parent's px), or null
        void Box(Dom d, StringBuilder sb, double pw, double ph, string fenceHtml, double[] persp = null)
        {
            var st = Style(d["style"]);
            if (st.TryGetValue("visibility", out var vis) && vis == "hidden") return;
            if (st.TryGetValue("opacity", out var op) && P(op) == 0) return;
            double left = 0, top = 0, w = pw, h = ph;
            bool inset0 = st.TryGetValue("inset", out var ins);
            if (inset0) { var v = ins.Split(' '); double t0 = P(v[0]); left = t0; top = t0; w = pw - 2 * t0; h = ph - 2 * t0; }
            if (st.TryGetValue("left", out var l)) left = P(l);
            if (st.TryGetValue("top", out var t)) top = P(t);
            if (st.TryGetValue("width", out var ws)) w = ws.EndsWith("%") ? pw * P(ws) / 100 : P(ws);
            else if (st.ContainsKey("right")) w = pw - left - P(st["right"]);
            if (st.TryGetValue("height", out var hs)) h = hs.EndsWith("%") ? ph * P(hs) / 100 : P(hs);
            else if (st.ContainsKey("bottom")) { if (!st.ContainsKey("top")) top = ph - P(st["bottom"]) - h; else h = ph - top - P(st["bottom"]); }
            var tf = "translate(" + N(left) + " " + N(top) + ")";
            // the dance room's 3D floor: a plane turned rotateX under the parent's perspective, drawn as its picture
            if (persp != null && st.TryGetValue("transform", out var tr3) && tr3.StartsWith("rotateX(") && st.TryGetValue("background", out var fb) && fb.StartsWith("flat:"))
            {
                Flat(fb.Substring(5).Trim(), st, left, top, w, h, P(tr3), persp, sb); return;
            }
            if (st.TryGetValue("transform", out var tr) && tr != "none")
            {
                double ox = 0, oy = 0;
                if (st.TryGetValue("transform-origin", out var org)) { var p = org.Split(' '); ox = p[0].EndsWith("%") ? w * P(p[0]) / 100 : P(p[0]); oy = p.Length > 1 ? (p[1].EndsWith("%") ? h * P(p[1]) / 100 : P(p[1])) : h / 2; }
                else { ox = w / 2; oy = h / 2; }
                var m = Regex.Match(tr, @"scale\(([^,)]+)(?:,\s*([^)]+))?\)");
                if (m.Success) { double sx = P(m.Groups[1].Value), sy = m.Groups[2].Success ? P(m.Groups[2].Value) : sx; tf += " translate(" + N(ox) + " " + N(oy) + ") scale(" + N(sx) + " " + N(sy) + ") translate(" + N(-ox) + " " + N(-oy) + ")"; }
                else Notes.Add("css transform not drawn: " + tr);
            }
            sb.Append("<g transform=\"").Append(tf).Append('"').Append(st.TryGetValue("opacity", out var o2) && P(o2) < 1 ? " opacity=\"" + N(P(o2)) + "\"" : "").Append('>');
            if (st.TryGetValue("background", out var bg)) Background(bg, w, h, st.TryGetValue("border-radius", out var br) && br == "50%", sb);
            bool clipped = false;
            if (st.TryGetValue("clip-path", out var cp) && cp != "none")
            {
                var pm = Regex.Match(cp, @"^path\(\s*['""]([^'""]*)['""]\s*\)$");
                if (pm.Success) { var cid = "cp" + (picN++); sb.Append("<defs><clipPath id=\"").Append(cid).Append("\"><path d=\"").Append(pm.Groups[1].Value).Append("\"/></clipPath></defs><g clip-path=\"url(#").Append(cid).Append(")\">"); clipped = true; }
                else Notes.Add("css clip-path box not drawn (" + cp.Substring(0, Math.Min(40, cp.Length)) + ")");
            }
            // a perspective for the children (CSS perspective, perspective-origin in this box's px)
            double[] kidP = null;
            if (st.TryGetValue("perspective", out var pv) && pv != "none")
            {
                double ppx = w / 2, ppy = h / 2;
                if (st.TryGetValue("perspective-origin", out var po)) { var q = po.Split(' '); ppx = Pos(q[0], w); ppy = q.Length > 1 ? Pos(q[1], h) : h / 2; }
                kidP = new[] { P(pv), ppx, ppy };
            }
            // children: CSS stacking inside this box (z-index auto first in order, then by z-index)
            var kids = new List<(int z, int i, Dom n)>();
            for (int i = 0; i < d.Children.Count; i++) { var c = d.Children[i]; var cs = Style(c["style"]); int z = cs.TryGetValue("z-index", out var zv) ? (int)P(zv) : 0; kids.Add((z, i, c)); }
            kids.Sort((a, b) => a.z != b.z ? a.z.CompareTo(b.z) : a.i.CompareTo(b.i));
            foreach (var (_, _, c) in kids)
            {
                if (c.Tag == "div") Box(c, sb, w, h, fenceHtml, kidP);
                else if (c.Tag == "svg") Svg(c, sb, w, h, fenceHtml);
                else if (c.Tag == "span" || c.Tag == "#text") { if (c.Inner().Trim().Length > 0) Notes.Add("html text not drawn: " + c.Inner()); }
            }
            if (clipped) sb.Append("</g>");
            sb.Append("</g>");
        }

        // rnFlat's plane: its box (left, top, w, h in the perspective box's px), transform-origin, rotateX (deg), the
        // perspective -> HouseFlat's picture, placed over the part of the box it covers
        void Flat(string floorId, Dictionary<string, string> st, double left, double top, double w, double h, double angle, double[] persp, StringBuilder sb)
        {
            double ox = w / 2, oy = h / 2;
            if (st.TryGetValue("transform-origin", out var org)) { var p = org.Split(' '); ox = Pos(p[0], w); oy = p.Length > 1 ? Pos(p[1], h) : h / 2; }
            if (!HouseFlat.Floors.TryGetValue(floorId, out var fl)) { Notes.Add("the dance floor " + floorId + " has no layers"); return; }
            var s = new HouseFlat.Spec { L = left, T = top, W = w, H = h, Ox = ox, Oy = oy, Angle = angle, D = persp[0], Px = persp[1], Py = persp[2], Layers = fl.layers, Bg = fl.bg };
            HouseFlat.Bounds(s);
            var href = "flat:" + floorId + "|" + string.Join(",", Array.ConvertAll(new[] { left, top, w, h, ox, oy, angle, persp[0], persp[1], persp[2] }, N));
            HouseFlat.Specs[href] = s;
            sb.Append("<image href=\"").Append(href).Append("\" x=\"").Append(N(s.X0)).Append("\" y=\"").Append(N(s.Y0)).Append("\" width=\"").Append(N(s.X1 - s.X0)).Append("\" height=\"").Append(N(s.Y1 - s.Y0)).Append("\" preserveAspectRatio=\"none\"/>");
        }

        static readonly Regex Rgba = new Regex(@"rgba?\(([^)]*)\)");
        static (string col, double a) Col(string c)
        {
            var m = Rgba.Match(c);
            if (!m.Success) return (c.Trim(), 1);
            var p = m.Groups[1].Value.Split(',');
            return ("rgb(" + p[0].Trim() + "," + p[1].Trim() + "," + p[2].Trim() + ")", p.Length > 3 ? P(p[3]) : 1);
        }

        // background: a colour, a radial-gradient (ellipse / circle, at x y, stops in % or px), or both (gradient over colour)
        void Background(string bg, double w, double h, bool ellipse, StringBuilder sb)
        {
            var layers = SplitTop(bg);
            for (int li = layers.Count - 1; li >= 0; li--)
            {
                var L = layers[li].Trim();
                var shape = ellipse ? "<ellipse cx=\"" + N(w / 2) + "\" cy=\"" + N(h / 2) + "\" rx=\"" + N(w / 2) + "\" ry=\"" + N(h / 2) + "\"" : "<rect x=\"0\" y=\"0\" width=\"" + N(w) + "\" height=\"" + N(h) + "\"";
                if (L.StartsWith("radial-gradient("))
                {
                    var args = SplitTop(L.Substring(16, L.Length - 17));
                    string first = args[0].Trim(); int si = 1; double cx = w / 2, cy = h / 2; bool circle = false, closest = false;
                    if (first.StartsWith("circle") || first.StartsWith("ellipse") || first.StartsWith("at ") || first.StartsWith("closest-side"))
                    {
                        circle = first.StartsWith("circle"); closest = first.Contains("closest-side");
                        var at = Regex.Match(first, @"at\s+(\S+)\s+(\S+)");
                        if (at.Success) { cx = Pos(at.Groups[1].Value, w); cy = Pos(at.Groups[2].Value, h); }
                    }
                    else si = 0;
                    double rx, ry;
                    if (closest) { rx = Math.Min(cx, w - cx); ry = Math.Min(cy, h - cy); if (circle) rx = ry = Math.Min(rx, ry); }
                    else if (circle) { rx = ry = Math.Max(Math.Max(Math.Sqrt(cx * cx + cy * cy), Math.Sqrt((w - cx) * (w - cx) + cy * cy)), Math.Max(Math.Sqrt(cx * cx + (h - cy) * (h - cy)), Math.Sqrt((w - cx) * (w - cx) + (h - cy) * (h - cy)))); }
                    else { double csx = Math.Min(cx, w - cx), csy = Math.Min(cy, h - cy), fx = Math.Max(cx, w - cx), fy = Math.Max(cy, h - cy), k = Math.Sqrt(fx * fx / (csx * csx) + fy * fy / (csy * csy)); rx = csx * k; ry = csy * k; }
                    var id = "bg" + (picN++);
                    sb.Append("<defs><radialGradient id=\"").Append(id).Append("\" gradientUnits=\"userSpaceOnUse\" cx=\"").Append(N(cx)).Append("\" cy=\"").Append(N(cy)).Append("\" r=\"").Append(N(rx)).Append('"');
                    if (Math.Abs(rx - ry) > 1e-9 && rx > 0) sb.Append(" gradientTransform=\"translate(" + N(cx) + " " + N(cy) + ") scale(1 " + N(ry / rx) + ") translate(" + N(-cx) + " " + N(-cy) + ")\"");
                    sb.Append('>');
                    int n = args.Count - si; double last = 0;
                    for (int k = si; k < args.Count; k++)
                    {
                        var a = args[k].Trim(); var m = Regex.Match(a, @"^(.*\))\s*([-\d.]+)(px|%)?$|^(\S+)\s+([-\d.]+)(px|%)$");
                        string c; double off;
                        if (m.Success) { c = m.Groups[1].Success && m.Groups[1].Value != "" ? m.Groups[1].Value : m.Groups[4].Value; var num = P(m.Groups[2].Success && m.Groups[2].Value != "" ? m.Groups[2].Value : m.Groups[5].Value); var unit = m.Groups[3].Success && m.Groups[3].Value != "" ? m.Groups[3].Value : m.Groups[6].Value; off = unit == "px" ? num / rx : num / 100; }
                        else { c = a; off = n == 1 ? 0 : (double)(k - si) / (n - 1); }
                        off = Math.Max(last, Math.Min(1, off)); last = off;
                        var (col, al) = Col(c);
                        sb.Append("<stop offset=\"").Append(N(off)).Append("\" stop-color=\"").Append(col).Append("\" stop-opacity=\"").Append(N(al)).Append("\"/>");
                    }
                    sb.Append("</radialGradient></defs>").Append(shape).Append(" fill=\"url(#").Append(id).Append(")\"/>");
                }
                else if (L.StartsWith("linear-gradient(") && LinearV(L, w, h, out var stops))
                {
                    // a top-to-bottom linear-gradient (to bottom / 180deg), stops in px or %: the dance floor's shading
                    var id = "bg" + (picN++);
                    sb.Append("<defs><linearGradient id=\"").Append(id).Append("\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"").Append(N(h)).Append("\">");
                    foreach (var (off, c) in stops) { var (col, al) = Col(c); sb.Append("<stop offset=\"").Append(N(off)).Append("\" stop-color=\"").Append(col).Append("\" stop-opacity=\"").Append(N(al)).Append("\"/>"); }
                    sb.Append("</linearGradient></defs>").Append(shape).Append(" fill=\"url(#").Append(id).Append(")\"/>");
                }
                else if (L != "none" && !L.StartsWith("url(") && !L.StartsWith("linear-gradient"))
                {
                    var (col, al) = Col(L);
                    sb.Append(shape).Append(" fill=\"").Append(col).Append("\" fill-opacity=\"").Append(N(al)).Append("\"/>");
                }
                else if (L != "none") Notes.Add("css background not drawn: " + L.Substring(0, Math.Min(40, L.Length)));
            }
        }
        // linear-gradient(to bottom | 180deg, colour [stop], ...) -> its stops (0..1 of h); false for other directions
        static bool LinearV(string L, double w, double h, out List<(double off, string col)> stops)
        {
            stops = new List<(double, string)>();
            var args = SplitTop(L.Substring(16, L.Length - 17)); int si = 0; var first = args[0].Trim();
            if (first == "to bottom" || first == "180deg") si = 1;
            else if (first.StartsWith("to ") || first.EndsWith("deg")) return false;
            int n = args.Count - si; double last = 0;
            for (int k = si; k < args.Count; k++)
            {
                var a = args[k].Trim(); var m = Regex.Match(a, @"^(.*?)\s+([-\d.]+)(px|%)$");
                string c = m.Success ? m.Groups[1].Value : a;
                double off = m.Success ? (m.Groups[3].Value == "%" ? P(m.Groups[2].Value) / 100 : P(m.Groups[2].Value) / h) : n == 1 ? 0 : (double)(k - si) / (n - 1);
                off = Math.Max(last, Math.Min(1, off)); last = off;
                stops.Add((off, c));
            }
            return true;
        }
        static double Pos(string v, double size) => v.EndsWith("%") ? size * P(v) / 100 : v == "center" ? size / 2 : v == "left" || v == "top" ? 0 : v == "right" || v == "bottom" ? size : P(v);
        static List<string> SplitTop(string s)
        {
            var o = new List<string>(); int depth = 0, st = 0;
            for (int i = 0; i < s.Length; i++) { if (s[i] == '(') depth++; else if (s[i] == ')') depth--; else if (s[i] == ',' && depth == 0) { o.Add(s.Substring(st, i - st)); st = i + 1; } }
            o.Add(s.Substring(st)); return o;
        }

        // an <svg> placed in a box: left / top / width / height and its viewBox
        void Svg(Dom s, StringBuilder sb, double pw, double ph, string fenceHtml)
        {
            var st = Style(s["style"]);
            double x = st.TryGetValue("left", out var l) ? P(l) : 0, y = st.TryGetValue("top", out var t) ? P(t) : 0;
            double w = st.TryGetValue("width", out var ws) ? (ws.EndsWith("%") ? pw * P(ws) / 100 : P(ws)) : pw, h = st.TryGetValue("height", out var hs) ? (hs.EndsWith("%") ? ph * P(hs) / 100 : P(hs)) : ph;
            sb.Append("<svg x=\"").Append(N(x)).Append("\" y=\"").Append(N(y)).Append("\" width=\"").Append(N(w)).Append("\" height=\"").Append(N(h)).Append('"');
            if (s["viewBox"] != null) sb.Append(" viewBox=\"").Append(s["viewBox"]).Append('"');
            if (s["preserveAspectRatio"] != null) sb.Append(" preserveAspectRatio=\"").Append(s["preserveAspectRatio"]).Append('"');
            sb.Append('>');
            foreach (var c in s.Children) El(c, sb, fenceHtml);
            sb.Append("</svg>");
        }

        // an element inside an svg, as is; pictures inlined; the fence's own markup put in its group
        void El(Dom e, StringBuilder sb, string fenceHtml)
        {
            if (e.Tag == "#text") { sb.Append(Esc(e.Text)); return; }
            if (e.Tag == "image") { Image(e, sb); return; }
            sb.Append('<').Append(e.Tag);
            foreach (var a in e.Attrs) { if (a.Key == "data-dc-tpl") continue; sb.Append(' ').Append(a.Key).Append("=\"").Append(Esc(a.Value)).Append('"'); }
            sb.Append('>');
            foreach (var c in e.Children) El(c, sb, fenceHtml);
            sb.Append("</").Append(e.Tag).Append('>');
        }
        static string Esc(string s) => s.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("<", "&lt;");

        // pictures inside a picture (<image href="data:image/svg+xml,...">, e.g. a window's view): inlined the same way
        static readonly Regex ImgRx = new Regex("<image\\b([^>]*?)(/>|>\\s*</image>)");
        static readonly Regex SmilRx = new Regex("<(animate|animateTransform|animateMotion|set|animateColor)\\b[^>]*/>");
        public string InlineImages(string svg, int depth)
        {
            if (depth > 4 || svg.IndexOf("data:image/svg+xml", StringComparison.Ordinal) < 0) return svg;
            return ImgRx.Replace(svg, m =>
            {
                var a = m.Groups[1].Value; var hm = Regex.Match(a, "(?:xlink:)?href=\"(data:image/svg\\+xml[^\"]*)\"");
                if (!hm.Success) return m.Value;
                var uri = System.Net.WebUtility.HtmlDecode(hm.Groups[1].Value); int c = uri.IndexOf(',');
                var body = uri.Substring(c + 1);
                var inner = uri.Substring(0, c).EndsWith(";base64") ? Encoding.UTF8.GetString(Convert.FromBase64String(body)) : Uri.UnescapeDataString(body);
                inner = SmilRx.Replace(inner, "");
                inner = InlineImages(inner, depth + 1);
                var pre = "n" + (picN++) + "_";
                inner = IdRx.Replace(inner, q => "id=\"" + pre + q.Groups[1].Value + "\""); inner = Regex.Replace(inner, @"url\(#", "url(#" + pre); inner = Regex.Replace(inner, "href=\"#", "href=\"#" + pre);
                var m0 = Regex.Match(inner, "<svg\\b[^>]*>"); if (!m0.Success) return "";
                string At(string k, string def) { var q = Regex.Match(a, "\\s" + k + "=\"([^\"]*)\""); return q.Success ? q.Groups[1].Value : def; }
                var vb = Regex.Match(m0.Value, "viewBox=\"([^\"]+)\"").Groups[1].Value;
                var par = At("preserveAspectRatio", Regex.Match(m0.Value, "preserveAspectRatio=\"([^\"]+)\"").Groups[1].Value is string pv && pv != "" ? pv : "xMidYMid meet");
                var tf = At("transform", null);
                var head = "<svg x=\"" + At("x", "0") + "\" y=\"" + At("y", "0") + "\" width=\"" + At("width", "0") + "\" height=\"" + At("height", "0") + "\"" + (vb != "" ? " viewBox=\"" + vb + "\"" : "") + " preserveAspectRatio=\"" + par + "\">";
                var res = head + inner.Substring(m0.Index + m0.Length);
                res = tf != null ? "<g transform=\"" + tf + "\">" + res + "</g>" : res;
                // (an image kept in <defs> for <use>: the Dance Room's round wall is 16 slices of one brick picture)
                var idm = Regex.Match(a, "\\sid=\"([^\"]*)\""); return idm.Success ? "<g id=\"" + idm.Groups[1].Value + "\">" + res + "</g>" : res;
            });
        }

        static readonly Regex IdRx = new Regex("\\bid=\"([^\"]+)\"");
        void Image(Dom e, StringBuilder sb)
        {
            var href = e["href"] ?? "";
            if (href == "" || href == "gif:empty") return;
            string vbOver = null; int hi = href.IndexOf("#viewBox=", StringComparison.Ordinal); if (hi >= 0) { vbOver = href.Substring(hi + 9); href = href.Substring(0, hi); }
            double x = P(e["x"]), y = P(e["y"]), w = P(e["width"]), h = P(e["height"]);
            var tf = e["transform"]; bool g = !string.IsNullOrEmpty(tf);
            if (g) sb.Append("<g transform=\"").Append(tf).Append("\">");
            var svg = PicSvg?.Invoke(href);
            if (svg != null)
            {
                svg = InlineImages(svg, 0);
                // the picture inline: its own ids made unique, its <svg> placed in the image's box (preserveAspectRatio none)
                var pre = "p" + (picN++) + "_";
                svg = IdRx.Replace(svg, m => "id=\"" + pre + m.Groups[1].Value + "\"");
                svg = Regex.Replace(svg, @"url\(#", "url(#" + pre); svg = Regex.Replace(svg, "href=\"#", "href=\"#" + pre);
                var m0 = Regex.Match(svg, "<svg\\b[^>]*>");
                var vb = vbOver ?? Regex.Match(m0.Value, "viewBox=\"([^\"]+)\"").Groups[1].Value;
                var par = e["preserveAspectRatio"] ?? "xMidYMid meet";
                sb.Append("<svg x=\"").Append(N(x)).Append("\" y=\"").Append(N(y)).Append("\" width=\"").Append(N(w)).Append("\" height=\"").Append(N(h)).Append("\" viewBox=\"").Append(vb).Append("\" preserveAspectRatio=\"").Append(par).Append("\">");
                sb.Append(svg, m0.Index + m0.Length, svg.Length - m0.Index - m0.Length);   // (its own </svg> closes ours)
            }
            else
            {
                var png = PicPng?.Invoke(href);
                if (png == null) Notes.Add("picture missing: " + href);
                else sb.Append("<image href=\"").Append(png).Append("\" x=\"").Append(N(x)).Append("\" y=\"").Append(N(y)).Append("\" width=\"").Append(N(w)).Append("\" height=\"").Append(N(h)).Append("\" preserveAspectRatio=\"none\"/>");
            }
            if (g) sb.Append("</g>");
        }
    }
}
