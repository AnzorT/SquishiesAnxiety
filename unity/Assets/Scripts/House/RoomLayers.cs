// The room's markup (HouseTemplate's Dom) cut into layers for the house screen (HOUSE_PORT_PLAN.md stage 3): the room box
// without its pieces (the base), each child of the pieces' stacking box (a piece, a piece's front part, a beach prop, a
// toy) alone with the region it draws in and its z-index, and the night overlay (a sibling of the box: drawn unzoomed).
// Creatures sort between the pieces by z-index as in the page. Each layer is an SVG (RoomCompose) the view draws once.
// Plain C#: tools/unity/house-test `layers` puts them back together and compares with stage 1's single picture.
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class RoomLayers
    {
        public sealed class Layer { public string Svg; public double[] Region; public double Z; }
        public string Base, Night;
        public readonly List<Layer> Pieces = new List<Layer>();
        public readonly List<string> Notes = new List<string>();

        /// <summary>`dom`: the template's output (camK 1); `view`: the base layer's region (frame px).</summary>
        public static RoomLayers Split(List<Dom> dom, double[] view, Func<RoomCompose> composer)
        {
            var L = new RoomLayers();
            var night = dom.FindAll(n => n.Tag == "div" && (n["style"] ?? "").Contains("z-index:860"));
            var room = dom.FindAll(n => !night.Contains(n));
            var path = PathTo(room, n => n.Tag == "div" && (n["style"] ?? "").Contains("inset:0; z-index:3;"));
            var kids = path != null ? new List<Dom>(path[path.Count - 1].Children) : new List<Dom>();
            string Compose(List<Dom> d, double[] v, bool bg) { var c = composer(); var s = c.Compose(d, null, v, bg); L.Notes.AddRange(c.Notes); return s; }
            if (path != null) path[path.Count - 1].Children.Clear();
            L.Base = Compose(room, view, true);
            if (path != null)
            {
                var box = path[path.Count - 1];
                foreach (var kid in kids)
                {
                    if (kid.Tag != "div") continue;
                    var region = RegionOf(kid) ?? view;
                    box.Children.Clear(); box.Children.Add(kid);
                    var saved = new List<List<Dom>>();
                    for (int i = 0; i < path.Count - 1; i++) { saved.Add(new List<Dom>(path[i].Children)); path[i].Children.Clear(); path[i].Children.Add(path[i + 1]); }
                    L.Pieces.Add(new Layer { Svg = Compose(new List<Dom> { path[0] }, region, false), Region = region, Z = ZOf(kid) });
                    for (int i = 0; i < path.Count - 1; i++) { path[i].Children.Clear(); path[i].Children.AddRange(saved[i]); }
                }
                box.Children.Clear(); box.Children.AddRange(kids);
            }
            if (night.Count > 0) L.Night = Compose(night, null, false);
            return L;
        }

        static List<Dom> PathTo(List<Dom> top, Func<Dom, bool> hit)
        {
            foreach (var n in top) { var p = PathTo(n, hit); if (p != null) return p; }
            return null;
        }
        static List<Dom> PathTo(Dom n, Func<Dom, bool> hit)
        {
            if (hit(n)) return new List<Dom> { n };
            foreach (var c in n.Children) { var p = PathTo(c, hit); if (p != null) { p.Insert(0, n); return p; } }
            return null;
        }

        static double Css(string style, string prop, double def = double.NaN)
        {
            var m = System.Text.RegularExpressions.Regex.Match(style ?? "", "(?:^|;)\\s*" + prop + ":\\s*(-?[\\d.]+)");
            return m.Success ? double.Parse(m.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture) : def;
        }
        static double ZOf(Dom d) => Css(d["style"], "z-index", 0);

        // a piece's box in the frame at camK 1 (the box sits 50 px down): its div's left / top / scale and its <svg>'s box,
        // with room around it for shadows, glows and parts drawn outside (overflow visible)
        static double[] RegionOf(Dom d)
        {
            string st = d["style"] ?? "";
            double L = Css(st, "left", 0), T = Css(st, "top", 0), S = 1;
            var sm = System.Text.RegularExpressions.Regex.Match(st, "scale\\((-?[\\d.]+)");
            if (sm.Success) S = double.Parse(sm.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
            double x0 = double.MaxValue, y0 = double.MaxValue, x1 = double.MinValue, y1 = double.MinValue;
            foreach (var c in d.Children)
            {
                if (c.Tag != "svg" && c.Tag != "div" && c.Tag != "img") continue;
                string cs = c["style"] ?? "";
                double bx = Css(cs, "left", 0), by = Css(cs, "top", 0), bw = Css(cs, "width", double.NaN), bh = Css(cs, "height", double.NaN);
                if (double.IsNaN(bw) || double.IsNaN(bh)) continue;
                x0 = Math.Min(x0, bx); y0 = Math.Min(y0, by); x1 = Math.Max(x1, bx + bw); y1 = Math.Max(y1, by + bh);
            }
            if (x0 == double.MaxValue) return null;   // (nothing sized: the whole region)
            double w = (x1 - x0) * Math.Abs(S), h = (y1 - y0) * Math.Abs(S), m = 0.5 * Math.Max(w, h) + 24;
            double ax = L + Math.Min(x0, x1) * S, ay = T + Math.Min(y0, y1) * S + HouseFrame.BoxTop;
            return new[] { Math.Floor(ax - m), Math.Floor(ay - m), Math.Ceiling(w + 2 * m), Math.Ceiling(h + 2 * m) };
        }

    }
}
