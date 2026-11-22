// What a GPU fills without triangulating ("stencil, then cover"): a shape is a set of polygons and a rule.
//   NonZero / EvenOdd: closed contours; each contour drawn as a triangle fan from its first point into the stencil
//     (incremented on one winding, decremented on the other, or inverted for even-odd) marks exactly the inside.
//   Union: a stroke, as pieces (one quad per segment, a polygon per join and cap), each convex; a pixel any piece
//     covers is inside, so a see-through stroke covers each pixel once, as the browser draws it.
// Then one quad over the shape's box draws the paint where the stencil says "inside", and clears it.
using System;
using System.Collections.Generic;

namespace SquishSquad.Vector
{
    public enum FillRule { NonZero, EvenOdd, Union }

    public sealed class Shape
    {
        public readonly List<List<Vec2>> Polygons = new List<List<Vec2>>();   // output px
        public FillRule Rule;
        public bool IsEmpty => Polygons.Count == 0;
        public Box Bounds { get { var b = Box.Empty; foreach (var p in Polygons) foreach (var v in p) b.Add(v); return b; } }
        public int PointCount { get { int n = 0; foreach (var p in Polygons) n += p.Count; return n; } }
    }

    public static class Outline
    {
        public static Shape Fill(Polyline outline, bool evenOdd)
        {
            var s = new Shape { Rule = evenOdd ? FillRule.EvenOdd : FillRule.NonZero };
            foreach (var c in outline.Contours) if (c.Count >= 3) s.Polygons.Add(c);
            return s;
        }

        public enum Join { Miter, Round, Bevel }
        public enum Cap { Butt, Round, Square }

        public static Shape Stroke(Polyline outline, double width, Join join, Cap cap, double miterLimit, double tolerance)
        {
            var s = new Shape { Rule = FillRule.Union };
            double hw = width / 2;
            if (hw <= 0) return s;
            int steps = Math.Max(6, Math.Min(48, (int)Math.Ceiling(Math.PI / Math.Acos(Math.Max(-1, 1 - Math.Min(tolerance, hw) / hw)))));
            List<Vec2> Circle(Vec2 c) { var l = new List<Vec2>(steps * 2); for (int i = 0; i < steps * 2; i++) { double a = Math.PI * i / steps; l.Add(new Vec2(c.X + hw * Math.Cos(a), c.Y + hw * Math.Sin(a))); } return l; }

            for (int ci = 0; ci < outline.Contours.Count; ci++)
            {
                var pts = Dedupe(outline.Contours[ci]);
                bool closed = outline.Closed[ci] && pts.Count > 2;
                if (pts.Count == 1)
                {
                    if (cap == Cap.Round) s.Polygons.Add(Circle(pts[0]));
                    else if (cap == Cap.Square) s.Polygons.Add(new List<Vec2> { pts[0] + new Vec2(-hw, -hw), pts[0] + new Vec2(hw, -hw), pts[0] + new Vec2(hw, hw), pts[0] + new Vec2(-hw, hw) });
                    continue;
                }
                if (pts.Count < 2) continue;
                int segs = closed ? pts.Count : pts.Count - 1;
                for (int i = 0; i < segs; i++)
                {
                    var a = pts[i]; var b = pts[(i + 1) % pts.Count];
                    var d = b - a; double len = d.Length; if (len < 1e-9) continue;
                    var nrm = new Vec2(-d.Y / len * hw, d.X / len * hw);
                    var ext = new Vec2(d.X / len * hw, d.Y / len * hw);
                    var a0 = a; var b0 = b;
                    if (!closed && cap == Cap.Square) { if (i == 0) a0 = a - ext; if (i == segs - 1) b0 = b + ext; }
                    s.Polygons.Add(new List<Vec2> { a0 + nrm, b0 + nrm, b0 - nrm, a0 - nrm });
                }
                int j0 = closed ? 0 : 1, j1 = closed ? pts.Count : pts.Count - 1;
                for (int i = j0; i < j1; i++)
                {
                    var p = pts[i]; var prev = pts[(i - 1 + pts.Count) % pts.Count]; var next = pts[(i + 1) % pts.Count];
                    var d0 = p - prev; var d1 = next - p; double l0 = d0.Length, l1 = d1.Length;
                    if (l0 < 1e-9 || l1 < 1e-9) continue;
                    double cross = d0.X * d1.Y - d0.Y * d1.X;
                    if (join == Join.Round)
                    {
                        // only where the outline turns enough to open a gap between the segment quads
                        if (Math.Abs(cross) / (l0 * l1) > 1e-4 || (d0.X * d1.X + d0.Y * d1.Y) < 0) s.Polygons.Add(Circle(p));
                        continue;
                    }
                    if (Math.Abs(cross) < 1e-12) continue;
                    var n0 = new Vec2(-d0.Y / l0, d0.X / l0); var n1 = new Vec2(-d1.Y / l1, d1.X / l1);
                    double side = cross > 0 ? -1 : 1;
                    var o0 = p + n0 * (hw * side); var o1 = p + n1 * (hw * side);
                    var poly = new List<Vec2> { p, o0, o1 };
                    if (join == Join.Miter)
                    {
                        double cosT = n0.X * n1.X + n0.Y * n1.Y;
                        double miterLen = 1 / Math.Sqrt(Math.Max(1e-12, (1 + cosT) / 2));
                        if (miterLen <= miterLimit)
                        {
                            var mid = new Vec2(n0.X + n1.X, n0.Y + n1.Y); double ml = mid.Length;
                            if (ml > 1e-12) poly = new List<Vec2> { p, o0, p + mid * (hw * side * miterLen / ml), o1 };
                        }
                    }
                    s.Polygons.Add(poly);
                }
                if (!closed && cap == Cap.Round) { s.Polygons.Add(Circle(pts[0])); s.Polygons.Add(Circle(pts[pts.Count - 1])); }
            }
            return s;
        }

        static List<Vec2> Dedupe(List<Vec2> c)
        {
            var o = new List<Vec2>(c.Count);
            foreach (var p in c) if (o.Count == 0 || Math.Abs(o[o.Count - 1].X - p.X) > 1e-6 || Math.Abs(o[o.Count - 1].Y - p.Y) > 1e-6) o.Add(p);
            return o;
        }
    }
}
