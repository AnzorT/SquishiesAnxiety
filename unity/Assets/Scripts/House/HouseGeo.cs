// The house's floor geometry (house4.js + the house page): the 3/4 camera's scale by depth, the side walls' edge,
// footprints, seat / use spots, and the footprint outlines every piece's shadow is drawn from. Numbers are JS's:
// doubles, Math.round's ties toward +infinity, the same hull, the same 0.1 rounding in paths.
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.House
{
    public sealed class HouseGeo
    {
        public readonly double FS, SA, CA, VW, FY0, FY1;
        public const double SK = 0.7;
        // the per-room geometry the page sets in geo(rk): RM.s (big rooms draw pieces smaller), RM.e (the dance room's curve)
        public double RmS = 1;
        public bool RoundRoom;
        public static readonly Dictionary<string, double> BIGR = new Dictionary<string, double> { { "living", 0.8 }, { "kitchen", 0.8 }, { "bathroom", 0.8 }, { "bedroom", 0.8 }, { "backyard", 0.72 }, { "dance", 0.8 }, { "movie", 0.8 }, { "beach", 0.72 } };

        public HouseGeo(HouseData d) { FS = d.FS; SA = d.SA; CA = d.CA; VW = d.VW; FY0 = d.FY0; FY1 = d.FY1; }

        /// <summary>geo(rk): the page calls it on entering a room and on every render.</summary>
        public void SetRoom(string rk) { RmS = BIGR.TryGetValue(rk ?? "", out var s) ? s : 1; RoundRoom = rk == "dance"; }

        public double SAt(double y) => (0.6 + 0.24 * (y - 128) / 228) * SK * RmS;
        public static double Edge0(double y) => y < 262 ? 100 - (y - 100) * 100 / 162 : 0;
        public static double EdgeR(double y) { if (y < 112) return 120; double v = (400 - y) / 300; return Math.Max(0, 426 - 600 * Math.Sqrt(Math.Max(0, 1 - v * v))); }
        public double Edge(double y) => RoundRoom ? EdgeR(y) : Edge0(y);

        /// <summary>Math.round (ties toward +infinity).</summary>
        public static double JsRound(double x) { if (double.IsNaN(x) || double.IsInfinity(x)) return x; var f = Math.Floor(x); return x - f >= 0.5 ? f + 1 : f; }
        public static double F1(double v) => JsRound(v * 10) / 10;
        public static string N(double v) => SquishSquad.Anim.JsNumber.ToString(v);

        public (double hx, double hz) Half(double w, double d, double rot)
        {
            double tr = rot * Math.PI / 180, c = Math.Abs(Math.Cos(tr)), s = Math.Abs(Math.Sin(tr));
            return ((w / 2 * c + d / 2 * s) * FS, (w / 2 * s + d / 2 * c) * FS);
        }

        public (double x, double z) UseXY(double ux, double uz, double rot)
        {
            double tr = rot * Math.PI / 180, c = Math.Cos(tr), sn = Math.Sin(tr);
            return ((ux * c + uz * sn) * FS, (-ux * sn + uz * c) * FS);
        }

        // ---- the footprint outline (house4.js render: fpR, hull, pathOf) ----
        static List<double[]> Ring(bool round, double a, double b, double r, int n)
        {
            var o = new List<double[]>();
            double Aa = Math.Max(0.05, a), Bb = Math.Max(0.05, b);
            if (round)
            {
                for (int i = 0; i < n; i++) { double t = (double)i / n * 2 * Math.PI; o.Add(new[] { Aa * Math.Cos(t), Bb * Math.Sin(t) }); }
                return o;
            }
            double rt = Math.Max(0, Math.Min(Math.Min(r, Aa), Bb)), rb = rt;
            const int S = 5;
            var C = new[] { (Aa, Bb, 0.0, rt), (-Aa, Bb, 90.0, rt), (-Aa, -Bb, 180.0, rb), (Aa, -Bb, 270.0, rb) };
            foreach (var (cx, cy, a0, R) in C)
            {
                double ox = cx - Math.Sign(cx) * R, oy = cy - Math.Sign(cy) * R;
                for (int i = 0; i <= S; i++) { double t = (a0 + 90.0 * i / S) * Math.PI / 180; o.Add(new[] { ox + R * Math.Cos(t), oy + R * Math.Sin(t) }); }
            }
            return o;
        }

        public static List<double[]> Hull(List<double[]> pts)
        {
            var p = new List<double[]>(pts);
            // Array.prototype.sort is stable; equal points keep their order
            var idx = new List<int>(); for (int i = 0; i < p.Count; i++) idx.Add(i);
            idx.Sort((i, j) => { int c = p[i][0].CompareTo(p[j][0]); if (c == 0) c = p[i][1].CompareTo(p[j][1]); return c != 0 ? c : i.CompareTo(j); });
            var q = new List<double[]>(); foreach (var i in idx) q.Add(p[i]);
            if (q.Count < 3) return q;
            double Cr(double[] o, double[] a, double[] b) => (a[0] - o[0]) * (b[1] - o[1]) - (a[1] - o[1]) * (b[0] - o[0]);
            var lo = new List<double[]>(); var up = new List<double[]>();
            foreach (var x in q) { while (lo.Count >= 2 && Cr(lo[lo.Count - 2], lo[lo.Count - 1], x) <= 0) lo.RemoveAt(lo.Count - 1); lo.Add(x); }
            for (int i = q.Count - 1; i >= 0; i--) { var x = q[i]; while (up.Count >= 2 && Cr(up[up.Count - 2], up[up.Count - 1], x) <= 0) up.RemoveAt(up.Count - 1); up.Add(x); }
            up.RemoveAt(up.Count - 1); lo.RemoveAt(lo.Count - 1);
            lo.AddRange(up);
            return lo;
        }

        public static string PathOf(List<double[]> P)
        {
            var sb = new StringBuilder("M");
            for (int i = 0; i < P.Count; i++) { if (i > 0) sb.Append('L'); sb.Append(N(F1(P[i][0]))).Append(' ').Append(N(F1(P[i][1]))); }
            return sb.Append('Z').ToString();
        }

        /// <summary>The footprint at k (1.04 shadow, 0.9 contact, 1.14 the edit outline), on screen, for a piece turned rot.</summary>
        public string Footprint(double w, double d, bool round, double rot, double k)
        {
            double tr = rot * Math.PI / 180, c = Math.Cos(tr), s = Math.Sin(tr);
            var ring = Ring(round, w / 2 * k, d / 2 * k, Math.Min(w, d) * 0.22, 20);
            var pts = new List<double[]>();
            foreach (var uv in ring)
            {
                double u = uv[0], v = uv[1];
                double x = (u * c + v * s) * FS, y = 0 * FS, z = (-u * s + v * c) * FS;
                pts.Add(new[] { x, z * SA - y * CA });
            }
            return PathOf(Hull(pts));
        }
    }
}
