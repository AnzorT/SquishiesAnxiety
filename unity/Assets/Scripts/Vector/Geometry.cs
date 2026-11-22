// Shapes to polygons: affine transforms, SVG path data and the basic shapes flattened into contours of points in the
// output's pixels (a tolerance in pixels decides how finely curves are cut), and bounding boxes for gradients.
using System;
using System.Collections.Generic;

namespace SquishSquad.Vector
{
    public struct Vec2
    {
        public double X, Y;
        public Vec2(double x, double y) { X = x; Y = y; }
        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.X + b.X, a.Y + b.Y);
        public static Vec2 operator -(Vec2 a, Vec2 b) => new Vec2(a.X - b.X, a.Y - b.Y);
        public static Vec2 operator *(Vec2 a, double k) => new Vec2(a.X * k, a.Y * k);
        public double Length => Math.Sqrt(X * X + Y * Y);
        public override string ToString() => $"({X:0.###}, {Y:0.###})";
    }

    // [a c e; b d f]: x' = a x + c y + e, y' = b x + d y + f (SVG's matrix(a b c d e f))
    public struct Affine
    {
        public double A, B, C, D, E, F;
        public static readonly Affine Identity = new Affine { A = 1, D = 1 };
        public Affine(double a, double b, double c, double d, double e, double f) { A = a; B = b; C = c; D = d; E = e; F = f; }
        public Vec2 Apply(Vec2 p) => new Vec2(A * p.X + C * p.Y + E, B * p.X + D * p.Y + F);
        public Vec2 ApplyVector(Vec2 v) => new Vec2(A * v.X + C * v.Y, B * v.X + D * v.Y);
        public static Affine operator *(Affine m, Affine n) => new Affine(
            m.A * n.A + m.C * n.B, m.B * n.A + m.D * n.B,
            m.A * n.C + m.C * n.D, m.B * n.C + m.D * n.D,
            m.A * n.E + m.C * n.F + m.E, m.B * n.E + m.D * n.F + m.F);
        public double Scale => Math.Sqrt(Math.Abs(A * D - B * C));
        public bool IsIdentity => A == 1 && B == 0 && C == 0 && D == 1 && E == 0 && F == 0;
        public Affine Inverse()
        {
            double det = A * D - B * C;
            if (Math.Abs(det) < 1e-12) return Identity;
            double ia = D / det, ib = -B / det, ic = -C / det, id = A / det;
            return new Affine(ia, ib, ic, id, -(ia * E + ic * F), -(ib * E + id * F));
        }
        public static Affine Translate(double x, double y) => new Affine(1, 0, 0, 1, x, y);
        public static Affine ScaleBy(double x, double y) => new Affine(x, 0, 0, y, 0, 0);
        public static Affine Rotate(double deg) { double r = deg * Math.PI / 180, c = Math.Cos(r), s = Math.Sin(r); return new Affine(c, s, -s, c, 0, 0); }

        public static Affine Parse(string s)
        {
            var m = Identity;
            if (string.IsNullOrEmpty(s)) return m;
            int i = 0, n = s.Length;
            var v = new List<float>(6);
            while (i < n)
            {
                while (i < n && !char.IsLetter(s[i])) i++;
                int a = i;
                while (i < n && char.IsLetter(s[i])) i++;
                var name = s.Substring(a, i - a);
                int open = s.IndexOf('(', i), close = open < 0 ? -1 : s.IndexOf(')', open);
                if (open < 0 || close < 0) break;
                v.Clear();
                int j = open + 1;
                var inner = s.Substring(0, close);
                while (SvgNum.TryRead(inner, ref j, out var x)) v.Add(x);
                i = close + 1;
                Affine k;
                switch (name)
                {
                    case "matrix": if (v.Count < 6) continue; k = new Affine(v[0], v[1], v[2], v[3], v[4], v[5]); break;
                    case "translate": k = Translate(v.Count > 0 ? v[0] : 0, v.Count > 1 ? v[1] : 0); break;
                    case "scale": k = ScaleBy(v.Count > 0 ? v[0] : 1, v.Count > 1 ? v[1] : (v.Count > 0 ? v[0] : 1)); break;
                    case "rotate":
                        k = Rotate(v.Count > 0 ? v[0] : 0);
                        if (v.Count > 2) k = Translate(v[1], v[2]) * k * Translate(-v[1], -v[2]);
                        break;
                    case "skewX": k = new Affine(1, 0, Math.Tan((v.Count > 0 ? v[0] : 0) * Math.PI / 180), 1, 0, 0); break;
                    case "skewY": k = new Affine(1, Math.Tan((v.Count > 0 ? v[0] : 0) * Math.PI / 180), 0, 1, 0, 0); break;
                    default: continue;
                }
                m = m * k;
            }
            return m;
        }
    }

    public struct Box
    {
        public double X0, Y0, X1, Y1;
        public static Box Empty => new Box { X0 = double.MaxValue, Y0 = double.MaxValue, X1 = double.MinValue, Y1 = double.MinValue };
        public bool IsEmpty => X0 > X1 || Y0 > Y1;
        public double W => X1 - X0;
        public double H => Y1 - Y0;
        public void Add(Vec2 p) { if (p.X < X0) X0 = p.X; if (p.X > X1) X1 = p.X; if (p.Y < Y0) Y0 = p.Y; if (p.Y > Y1) Y1 = p.Y; }
        public void Add(Box b) { if (b.IsEmpty) return; Add(new Vec2(b.X0, b.Y0)); Add(new Vec2(b.X1, b.Y1)); }
    }

    // A flattened outline: contours of points, each closed or open (strokes care)
    public sealed class Polyline
    {
        public readonly List<List<Vec2>> Contours = new List<List<Vec2>>();
        public readonly List<bool> Closed = new List<bool>();
        public bool IsEmpty { get { foreach (var c in Contours) if (c.Count > 1) return false; return true; } }
    }

    public static class Geometry
    {
        // Curves are cut so no chord strays more than `tolerance` output pixels from the curve.
        public const double DefaultTolerance = 0.12;

        // a shape element (path, rect, circle, ellipse, line, polyline, polygon) in its own user space, flattened
        // through `toPx` (user space -> output px); also its user-space box (objectBoundingBox gradients use it)
        public static Polyline Flatten(SvgNode n, Affine toPx, double tolerance, out Box userBox)
        {
            var pb = new PathBuilder(toPx, tolerance);
            switch (n.Tag)
            {
                case "path": PathData(n["d"] ?? "", pb); break;
                case "rect":
                {
                    double x = n.Num("x"), y = n.Num("y"), w = n.Num("width"), h = n.Num("height");
                    double rx = n.Num("rx", -1), ry = n.Num("ry", -1);
                    if (rx < 0 && ry < 0) rx = ry = 0; else if (rx < 0) rx = ry; else if (ry < 0) ry = rx;
                    rx = Math.Min(rx, w / 2); ry = Math.Min(ry, h / 2);
                    if (w <= 0 || h <= 0) break;
                    if (rx <= 0 || ry <= 0) { pb.MoveTo(x, y); pb.LineTo(x + w, y); pb.LineTo(x + w, y + h); pb.LineTo(x, y + h); pb.Close(); }
                    else
                    {
                        pb.MoveTo(x + rx, y); pb.LineTo(x + w - rx, y); pb.Arc(rx, ry, 0, false, true, x + w, y + ry);
                        pb.LineTo(x + w, y + h - ry); pb.Arc(rx, ry, 0, false, true, x + w - rx, y + h);
                        pb.LineTo(x + rx, y + h); pb.Arc(rx, ry, 0, false, true, x, y + h - ry);
                        pb.LineTo(x, y + ry); pb.Arc(rx, ry, 0, false, true, x + rx, y); pb.Close();
                    }
                    break;
                }
                case "circle": Ellipse(pb, n.Num("cx"), n.Num("cy"), n.Num("r"), n.Num("r")); break;
                case "ellipse": Ellipse(pb, n.Num("cx"), n.Num("cy"), n.Num("rx"), n.Num("ry")); break;
                case "line": pb.MoveTo(n.Num("x1"), n.Num("y1")); pb.LineTo(n.Num("x2"), n.Num("y2")); break;
                case "polyline":
                case "polygon":
                {
                    var s = n["points"] ?? "";
                    int i = 0; bool first = true;
                    while (SvgNum.TryRead(s, ref i, out var x) && SvgNum.TryRead(s, ref i, out var y)) { if (first) pb.MoveTo(x, y); else pb.LineTo(x, y); first = false; }
                    if (n.Tag == "polygon") pb.Close();
                    break;
                }
            }
            userBox = pb.UserBox;
            return pb.Result;
        }

        static void Ellipse(PathBuilder pb, double cx, double cy, double rx, double ry)
        {
            if (rx <= 0 || ry <= 0) return;
            pb.MoveTo(cx + rx, cy);
            pb.Arc(rx, ry, 0, false, true, cx - rx, cy);
            pb.Arc(rx, ry, 0, false, true, cx + rx, cy);
            pb.Close();
        }

        public static void PathData(string d, PathBuilder pb)
        {
            int i = 0, n = d.Length;
            char cmd = ' ';
            Vec2 cur = default, start = default, lastC = default, lastQ = default;
            char prev = ' ';
            while (i < n)
            {
                while (i < n && (char.IsWhiteSpace(d[i]) || d[i] == ',')) i++;
                if (i >= n) break;
                if (char.IsLetter(d[i]) && d[i] != 'e' && d[i] != 'E') cmd = d[i++];
                char C = char.ToUpperInvariant(cmd);
                bool rel = cmd != C;
                if (C == 'Z') { pb.Close(); cur = start; prev = 'Z'; continue; }
                float a, b, c, e, f, g, h;
                switch (C)
                {
                    case 'M':
                        if (!SvgNum.TryRead(d, ref i, out a) || !SvgNum.TryRead(d, ref i, out b)) return;
                        cur = rel ? cur + new Vec2(a, b) : new Vec2(a, b); start = cur; pb.MoveTo(cur.X, cur.Y);
                        cmd = rel ? 'l' : 'L'; prev = 'M'; break;
                    case 'L':
                        if (!SvgNum.TryRead(d, ref i, out a) || !SvgNum.TryRead(d, ref i, out b)) return;
                        cur = rel ? cur + new Vec2(a, b) : new Vec2(a, b); pb.LineTo(cur.X, cur.Y); prev = 'L'; break;
                    case 'H':
                        if (!SvgNum.TryRead(d, ref i, out a)) return;
                        cur = new Vec2(rel ? cur.X + a : a, cur.Y); pb.LineTo(cur.X, cur.Y); prev = 'L'; break;
                    case 'V':
                        if (!SvgNum.TryRead(d, ref i, out a)) return;
                        cur = new Vec2(cur.X, rel ? cur.Y + a : a); pb.LineTo(cur.X, cur.Y); prev = 'L'; break;
                    case 'C':
                    case 'S':
                    {
                        Vec2 c1;
                        if (C == 'C')
                        {
                            if (!SvgNum.TryRead(d, ref i, out a) || !SvgNum.TryRead(d, ref i, out b)) return;
                            c1 = rel ? cur + new Vec2(a, b) : new Vec2(a, b);
                        }
                        else c1 = prev == 'C' ? cur * 2 - lastC : cur;
                        if (!SvgNum.TryRead(d, ref i, out c) || !SvgNum.TryRead(d, ref i, out e) || !SvgNum.TryRead(d, ref i, out f) || !SvgNum.TryRead(d, ref i, out g)) return;
                        var c2 = rel ? cur + new Vec2(c, e) : new Vec2(c, e);
                        var to = rel ? cur + new Vec2(f, g) : new Vec2(f, g);
                        pb.CubicTo(c1, c2, to); lastC = c2; cur = to; prev = 'C'; break;
                    }
                    case 'Q':
                    case 'T':
                    {
                        Vec2 q;
                        if (C == 'Q')
                        {
                            if (!SvgNum.TryRead(d, ref i, out a) || !SvgNum.TryRead(d, ref i, out b)) return;
                            q = rel ? cur + new Vec2(a, b) : new Vec2(a, b);
                        }
                        else q = prev == 'Q' ? cur * 2 - lastQ : cur;
                        if (!SvgNum.TryRead(d, ref i, out c) || !SvgNum.TryRead(d, ref i, out e)) return;
                        var to = rel ? cur + new Vec2(c, e) : new Vec2(c, e);
                        pb.CubicTo(cur + (q - cur) * (2.0 / 3), to + (q - to) * (2.0 / 3), to);
                        lastQ = q; cur = to; prev = 'Q'; break;
                    }
                    case 'A':
                    {
                        if (!SvgNum.TryRead(d, ref i, out a) || !SvgNum.TryRead(d, ref i, out b) || !SvgNum.TryRead(d, ref i, out c)) return;
                        if (!ReadFlag(d, ref i, out var large) || !ReadFlag(d, ref i, out var sweep)) return;
                        if (!SvgNum.TryRead(d, ref i, out h) || !SvgNum.TryRead(d, ref i, out f)) return;
                        var to = rel ? cur + new Vec2(h, f) : new Vec2(h, f);
                        pb.Arc(a, b, c, large, sweep, to.X, to.Y); cur = to; prev = 'A'; break;
                    }
                    default: i++; break;
                }
            }
        }

        static bool ReadFlag(string d, ref int i, out bool flag)
        {
            while (i < d.Length && (char.IsWhiteSpace(d[i]) || d[i] == ',')) i++;
            flag = false;
            if (i >= d.Length || (d[i] != '0' && d[i] != '1')) return false;
            flag = d[i] == '1'; i++;
            return true;
        }
    }

    // Collects a path in user space, flattens it in output px as it goes
    public sealed class PathBuilder
    {
        readonly Affine _m;
        readonly double _tol;
        readonly Polyline _out = new Polyline();
        List<Vec2> _cur;
        Vec2 _p, _start;
        Box _box = Box.Empty;

        public PathBuilder(Affine toPx, double tolerance) { _m = toPx; _tol = Math.Max(0.01, tolerance); }
        public Polyline Result { get { Flush(); return _out; } }
        public Box UserBox => _box;

        void Flush() { if (_cur != null && _cur.Count > 0) { _out.Contours.Add(_cur); _out.Closed.Add(false); } _cur = null; }
        void Emit(Vec2 user) { _box.Add(user); _cur.Add(_m.Apply(user)); }

        public void MoveTo(double x, double y) { Flush(); _cur = new List<Vec2>(); _p = _start = new Vec2(x, y); Emit(_p); }
        void Ensure() { if (_cur == null) { _cur = new List<Vec2>(); Emit(_p); } }
        public void LineTo(double x, double y) { Ensure(); _p = new Vec2(x, y); Emit(_p); }
        public void Close()
        {
            if (_cur != null && _cur.Count > 0) { _out.Contours.Add(_cur); _out.Closed.Add(true); }
            _cur = null; _p = _start;
        }

        public void CubicTo(Vec2 c1, Vec2 c2, Vec2 to)
        {
            Ensure();
            // segments from the control polygon's length in px (enough for curves this size)
            var a = _m.Apply(_p); var b = _m.Apply(c1); var c = _m.Apply(c2); var d = _m.Apply(to);
            double dd = Math.Max((a - b * 2 + c).Length, (b - c * 2 + d).Length);
            int n = Math.Max(1, Math.Min(256, (int)Math.Ceiling(Math.Sqrt(dd * 0.75 / _tol))));
            for (int i = 1; i <= n; i++)
            {
                double t = (double)i / n, u = 1 - t;
                var q = _p * (u * u * u) + c1 * (3 * u * u * t) + c2 * (3 * u * t * t) + to * (t * t * t);
                if (i == n) q = to;
                Emit(q);
            }
            // the box of the curve itself (extrema), for objectBoundingBox
            CurveBox(_p, c1, c2, to);
            _p = to;
        }

        void CurveBox(Vec2 p0, Vec2 p1, Vec2 p2, Vec2 p3)
        {
            foreach (var t in Extrema(p0.X, p1.X, p2.X, p3.X)) _box.Add(Bez(p0, p1, p2, p3, t));
            foreach (var t in Extrema(p0.Y, p1.Y, p2.Y, p3.Y)) _box.Add(Bez(p0, p1, p2, p3, t));
        }
        static Vec2 Bez(Vec2 a, Vec2 b, Vec2 c, Vec2 d, double t) { double u = 1 - t; return a * (u * u * u) + b * (3 * u * u * t) + c * (3 * u * t * t) + d * (t * t * t); }
        static IEnumerable<double> Extrema(double a, double b, double c, double d)
        {
            double A = -a + 3 * b - 3 * c + d, B = 2 * (a - 2 * b + c), C = b - a;
            if (Math.Abs(A) < 1e-12) { if (Math.Abs(B) > 1e-12) { var t = -C / B; if (t > 0 && t < 1) yield return t; } yield break; }
            double disc = B * B - 4 * A * C;
            if (disc < 0) yield break;
            double s = Math.Sqrt(disc);
            var t1 = (-B + s) / (2 * A); var t2 = (-B - s) / (2 * A);
            if (t1 > 0 && t1 < 1) yield return t1;
            if (t2 > 0 && t2 < 1) yield return t2;
        }

        // SVG arc (endpoint form), flattened from its centre form
        public void Arc(double rx, double ry, double angleDeg, bool large, bool sweep, double x, double y)
        {
            Ensure();
            var to = new Vec2(x, y);
            rx = Math.Abs(rx); ry = Math.Abs(ry);
            if (rx == 0 || ry == 0 || (to.X == _p.X && to.Y == _p.Y)) { LineTo(x, y); return; }
            double phi = angleDeg * Math.PI / 180, cs = Math.Cos(phi), sn = Math.Sin(phi);
            double dx = (_p.X - x) / 2, dy = (_p.Y - y) / 2;
            double x1 = cs * dx + sn * dy, y1 = -sn * dx + cs * dy;
            double lam = x1 * x1 / (rx * rx) + y1 * y1 / (ry * ry);
            if (lam > 1) { double k = Math.Sqrt(lam); rx *= k; ry *= k; }
            double num = rx * rx * ry * ry - rx * rx * y1 * y1 - ry * ry * x1 * x1, den = rx * rx * y1 * y1 + ry * ry * x1 * x1;
            double co = den == 0 ? 0 : Math.Sqrt(Math.Max(0, num / den)) * (large == sweep ? -1 : 1);
            double cxp = co * rx * y1 / ry, cyp = -co * ry * x1 / rx;
            double cx = cs * cxp - sn * cyp + (_p.X + x) / 2, cy = sn * cxp + cs * cyp + (_p.Y + y) / 2;
            double th1 = Math.Atan2((y1 - cyp) / ry, (x1 - cxp) / rx), th2 = Math.Atan2((-y1 - cyp) / ry, (-x1 - cxp) / rx);
            double dth = th2 - th1;
            if (sweep && dth < 0) dth += 2 * Math.PI; else if (!sweep && dth > 0) dth -= 2 * Math.PI;
            double pxr = Math.Max(rx, ry) * _m.Scale;
            int n = Math.Max(2, Math.Min(512, (int)Math.Ceiling(Math.Abs(dth) / (2 * Math.Acos(Math.Max(-1, 1 - _tol / Math.Max(pxr, 1e-6)))))));
            for (int i = 1; i <= n; i++)
            {
                double t = th1 + dth * i / n;
                var q = i == n ? to : new Vec2(cx + rx * Math.Cos(t) * cs - ry * Math.Sin(t) * sn, cy + rx * Math.Cos(t) * sn + ry * Math.Sin(t) * cs);
                Emit(q);
            }
            _p = to;
        }
    }
}
