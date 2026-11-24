// Squish Hop's board on the floor: a plane of tiles leaned back TILT degrees and seen in perspective, worked out here
// rather than with a 3D transform, so the squishies standing on it, the taps on it and the shapes drawn on it all use
// the same numbers. A port of src/hop/board.js; keep the two the same. Pure functions.
//
// Board units: a tile is 1 × 1; (u, v) is a point on the plane, u to the right and v toward the front (cell (x, y)
// covers u x…x+1, v y…y+1); z is the height above the plane, in tiles. On screen everything is T points a tile, seen
// from DEPTH tiles away (perspective(T × DEPTH) rotateX(38deg), turned about the plane's middle).
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.Games.Hop
{
    // layout(): where a W × H board goes (Cx, Cy: the plane's middle on screen; Tilt in degrees; C, Sn its cos, sin)
    public sealed class BoardLayout
    {
        public int W, H;
        public double T, Cx, Cy, Tilt, C, Sn;
    }

    // a point on screen, and S: how big a tile looks there (points per tile)
    public struct ScreenPoint
    {
        public double X, Y, S;
        public ScreenPoint(double x, double y, double s) { X = x; Y = y; S = s; }
    }

    public struct CellBox
    {
        public int Left, Top, Width, Height;
    }

    public static class BoardGeometry
    {
        public const double TILT = 38; // degrees (a board can lean less: Layout's `tilt`)
        public const double DEPTH = 13;

        // a point on a w × h plane leaned back by an angle with cosine c and sine sn, relative to its middle on
        // screen, with T = 1
        static ScreenPoint Unit(double w, double h, double u, double v, double z, double c, double sn)
        {
            double X = u - w / 2;
            double Y = v - h / 2;
            double yr = Y * c - z * sn;
            double zr = Y * sn + z * c;
            double s = DEPTH / (DEPTH - zr);
            return new ScreenPoint(X * s, yr * s, s);
        }

        /// <summary>How far the board's widest (front) edge keeps from the sides of its area (develop, 2026-11-21: it was 5,
        /// and on the Galaxy A15 the board ran into the goal panel and RESTART).</summary>
        public const double GUTTER = 20;

        // Where a w × h board goes in an area aw × ah whose floor starts floorY down (the room picture's floor line;
        // the board sits in the floor below it, and may reach a little above it).
        public static BoardLayout Layout(int w, int h, double aw, double ah, double floorY = 0, double tilt = TILT, double maxT = 96)
        {
            double c = Math.Cos((tilt * Math.PI) / 180);
            double sn = Math.Sin((tilt * Math.PI) / 180);
            var front = Unit(w, h, w, h, 0, c, sn);
            var back = Unit(w, h, 0, 0, 0, c, sn);
            double uw = 2 * front.X; // the front edge is the widest
            double uh = front.Y - back.Y;
            double top = JsMax(0, floorY);
            double space = ah - top + ah * 0.06;
            double T = JsMax(26, Math.Floor(JsMin(JsMin((aw - 2 * GUTTER) / uw, space / uh), maxT)));
            double bottom = JsMin(ah - 8, top + (ah - top) / 2 + (uh * T) / 2);
            return new BoardLayout { W = w, H = h, T = T, Cx = aw / 2, Cy = bottom - front.Y * T, Tilt = tilt, C = c, Sn = sn };
        }

        // Math.max / Math.min: NaN if either is NaN (as .NET Core's, spelled out for every runtime)
        static double JsMax(double a, double b) { return double.IsNaN(a) || double.IsNaN(b) ? double.NaN : a > b ? a : b; }
        static double JsMin(double a, double b) { return double.IsNaN(a) || double.IsNaN(b) ? double.NaN : a < b ? a : b; }

        // A point on the board on screen
        public static ScreenPoint Project(BoardLayout B, double u, double v, double z = 0)
        {
            var p = Unit(B.W, B.H, u, v, z, B.C, B.Sn);
            return new ScreenPoint(B.Cx + p.X * B.T, B.Cy + p.Y * B.T, p.S * B.T);
        }

        // The cell under a screen point (on the plane), or -1.
        public static int CellAt(BoardLayout B, double sx, double sy)
        {
            double x = (sx - B.Cx) / B.T;
            double y = (sy - B.Cy) / B.T;
            double Y = (y * DEPTH) / (DEPTH * B.C + y * B.Sn);
            double s = DEPTH / (DEPTH - Y * B.Sn);
            double u = x / s + B.W / 2.0;
            double v = Y + B.H / 2.0;
            if (u < 0 || v < 0 || u >= B.W || v >= B.H) return -1;
            if (double.IsNaN(u) || double.IsNaN(v)) return -1; // JS returns NaN here (a non-finite tap); never a cell
            return (int)(Math.Floor(v) * B.W + Math.Floor(u));
        }

        // where a squishy stands on cell i (a bit in front of the middle, as it looks on a cushion), `z` up
        public static ScreenPoint StandOn(BoardLayout B, int i, double z = 0)
        {
            return Project(B, (i % B.W) + 0.5, Math.Floor((double)i / B.W) + 0.56, z);
        }

        // --- shapes ----------------------------------------------------------------------------------------------

        static void Seg(StringBuilder sb, int k, ScreenPoint p, double ox, double oy)
        {
            if (k > 0) sb.Append(' ');
            sb.Append(k > 0 ? 'L' : 'M').Append(Js.ToFixed(p.X - ox, 1)).Append(' ').Append(Js.ToFixed(p.Y - oy, 1));
        }

        // The outline of a rounded rectangle on the plane (board units: x0, y0 to x1, y1, corners of radius r, at
        // height z), on screen, as an SVG path relative to (ox, oy).
        public static string RoundRect(BoardLayout B, double x0, double y0, double x1, double y1, double r, double z, double ox, double oy)
        {
            const int seg = 4;
            var corners = new[]
            {
                new[] { x1 - r, y0 + r, -Math.PI / 2 },
                new[] { x1 - r, y1 - r, 0 },
                new[] { x0 + r, y1 - r, Math.PI / 2 },
                new[] { x0 + r, y0 + r, Math.PI },
            };
            var sb = new StringBuilder();
            int n = 0;
            foreach (var cn in corners)
            {
                double cx = cn[0], cy = cn[1], a0 = cn[2];
                for (int k = 0; k <= seg; k++)
                {
                    double a = a0 + ((double)k / seg) * (Math.PI / 2);
                    Seg(sb, n++, Project(B, cx + r * Math.Cos(a), cy + r * Math.Sin(a), z), ox, oy);
                }
            }
            return sb.Append(" Z").ToString();
        }

        // a polyline of board points (at height z) as an SVG path relative to (ox, oy)
        public static string PolyPath(BoardLayout B, IList<double[]> pts, double z, double ox, double oy)
        {
            var sb = new StringBuilder();
            for (int k = 0; k < pts.Count; k++) Seg(sb, k, Project(B, pts[k][0], pts[k][1], z), ox, oy);
            return sb.ToString();
        }

        // The box on screen that cell (x, y)'s drawing fits in, up to height z (with room for a cushion's lip)
        public static CellBox CellBoxOf(BoardLayout B, double x, double y, double z = 0, double pad = 0.06)
        {
            var pts = new[]
            {
                Project(B, x - pad, y - pad, z),
                Project(B, x + 1 + pad, y - pad, z),
                Project(B, x - pad, y + 1 + pad, 0),
                Project(B, x + 1 + pad, y + 1 + pad, 0),
                Project(B, x - pad, y - pad, 0),
                Project(B, x + 1 + pad, y - pad, 0),
            };
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
            double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
            foreach (var p in pts)
            {
                minX = JsMin(minX, p.X); minY = JsMin(minY, p.Y);
                maxX = JsMax(maxX, p.X); maxY = JsMax(maxY, p.Y);
            }
            int left = (int)Math.Floor(minX), top = (int)Math.Floor(minY);
            int right = (int)Math.Ceiling(maxX), bottom = (int)Math.Ceiling(maxY);
            return new CellBox { Left = left, Top = top, Width = right - left, Height = bottom - top };
        }

        // the chevron of an arrow cushion (the Crib's back icon, M15 4 L7 12 L15 20 in a 24 box, pointing left),
        // turned to point `dir` (0 up, 1 right, 2 down, 3 left), `size` tiles across, centred on (u, v): board points
        public static double[][] Chevron(double u, double v, int dir, double size)
        {
            double rot = new[] { Math.PI / 2, Math.PI, -Math.PI / 2, 0 }[dir];
            double c = Math.Cos(rot);
            double s = Math.Sin(rot);
            var src = new[] { new[] { 15.0, 4 }, new[] { 7.0, 12 }, new[] { 15.0, 20 } };
            var outp = new double[3][];
            for (int k = 0; k < 3; k++)
            {
                double x = ((src[k][0] - 12 + 1.2) / 24) * size;
                double y = ((src[k][1] - 12) / 24) * size;
                outp[k] = new[] { u + x * c - y * s, v + x * s + y * c };
            }
            return outp;
        }
    }
}
