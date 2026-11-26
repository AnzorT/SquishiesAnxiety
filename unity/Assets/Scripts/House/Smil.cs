// SVG markup with SMIL (animate, animateTransform, animateMotion), parsed and written back out at a moment t with the
// animated values in place (a still of it at t): the beach's scene (View/HouseBeachView.cs) and the robot vacuum's sprite
// (View/HouseVacView.cs) are redrawn from it a few times a second. Values / keyTimes / calcMode spline and discrete,
// begin offsets, repeatCount indefinite; animateMotion along an absolute M / C / L path. No UnityEngine.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SquishSquad.Anim;

namespace SquishSquad.House
{
    public static class Smil
    {
        // ---------- the markup ----------
        public sealed class Node
        {
            public string Tag, Text; public readonly List<KeyValuePair<string, string>> A = new List<KeyValuePair<string, string>>(); public readonly List<Node> Kids = new List<Node>(); public Node Parent;
            public string Get(string k) { foreach (var kv in A) if (kv.Key == k) return kv.Value; return null; }
            public bool Animated { get { if (Tag.StartsWith("animate")) return true; foreach (var c in Kids) if (c.Animated) return true; return false; } }
            public Func<double, double>[] Splines;
        }
        static readonly Regex Tok = new Regex("<(/?)([\\w:-]+)((?:\\s+[\\w:-]+=\"[^\"]*\")*)\\s*(/?)>|([^<]+)", RegexOptions.Compiled);
        static readonly Regex Att = new Regex("([\\w:-]+)=\"([^\"]*)\"", RegexOptions.Compiled);
        public static List<Node> Parse(string s)
        {
            var root = new Node { Tag = "#root" }; var cur = root;
            foreach (Match m in Tok.Matches(s ?? ""))
            {
                if (m.Groups[5].Success) { if (cur != root && m.Groups[5].Value.Trim().Length > 0) cur.Kids.Add(new Node { Tag = "#text", Text = m.Groups[5].Value, Parent = cur }); continue; }
                if (m.Groups[1].Value == "/") { if (cur.Parent != null) cur = cur.Parent; continue; }
                var n = new Node { Tag = m.Groups[2].Value, Parent = cur };
                foreach (Match a in Att.Matches(m.Groups[3].Value)) n.A.Add(new KeyValuePair<string, string>(a.Groups[1].Value, a.Groups[2].Value));
                cur.Kids.Add(n);
                if (m.Groups[4].Value != "/") cur = n;
            }
            return root.Kids;
        }
        public static int Size(Node n) { int s = 40; foreach (var kv in n.A) s += kv.Value.Length; foreach (var c in n.Kids) s += Size(c); return s; }

        // ---------- SMIL at time t ----------
        static readonly Regex NumRx = new Regex("-?(?:\\d+\\.?\\d*|\\.\\d+)(?:e[-+]?\\d+)?", RegexOptions.Compiled);
        public static double Secs(string v) { if (string.IsNullOrEmpty(v)) return 0; v = v.Trim(); double k = 1; if (v.EndsWith("ms")) { k = 0.001; v = v.Substring(0, v.Length - 2); } else if (v.EndsWith("s")) v = v.Substring(0, v.Length - 1); return double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out var d) ? d * k : 0; }
        static string Lerp(string a, string b, double u)
        {
            var ma = NumRx.Matches(a); var mb = NumRx.Matches(b); if (ma.Count != mb.Count) return u < 0.5 ? a : b;
            int i = 0;
            return NumRx.Replace(a, m => { double x = double.Parse(m.Value, CultureInfo.InvariantCulture), y = double.Parse(mb[i++].Value, CultureInfo.InvariantCulture); return HouseGeo.N(Math.Round((x + (y - x) * u) * 100) / 100); });
        }
        /// <summary>An animation's value at t (null before it begins).</summary>
        public static string Value(Node a, double t, out double u)
        {
            u = 0; double dur = Secs(a.Get("dur")), b = Secs(a.Get("begin")); if (dur <= 0 || t < b) return null;
            u = ((t - b) % dur) / dur;
            var vals = (a.Get("values") ?? "").Split(';'); if (vals.Length == 0 || vals[0].Length == 0) return a.Get("to");
            if (vals.Length == 1) return vals[0].Trim();
            int n = vals.Length - 1; double[] kt = new double[n + 1];
            var kts = a.Get("keyTimes")?.Split(';'); for (int i = 0; i <= n; i++) kt[i] = kts != null && kts.Length == n + 1 ? double.Parse(kts[i], CultureInfo.InvariantCulture) : (double)i / n;
            int s = 0; while (s < n - 1 && u >= kt[s + 1]) s++;
            double lu = kt[s + 1] > kt[s] ? Math.Max(0, Math.Min(1, (u - kt[s]) / (kt[s + 1] - kt[s]))) : 1;
            if (a.Get("calcMode") == "spline")
            {
                if (a.Splines == null) { var ks = (a.Get("keySplines") ?? "").Split(';'); a.Splines = new Func<double, double>[n]; for (int i = 0; i < n; i++) { var p = i < ks.Length ? NumRx.Matches(ks[i]) : null; a.Splines[i] = p != null && p.Count == 4 ? Easing.Bezier(D(p[0]), D(p[1]), D(p[2]), D(p[3])) : (x => x); } }
                lu = a.Splines[s](lu);
            }
            else if (a.Get("calcMode") == "discrete") return vals[Math.Min(n, (int)(u * (n + 1)))].Trim();
            return Lerp(vals[s].Trim(), vals[s + 1].Trim(), lu);
        }
        static double D(Match m) => double.Parse(m.Value, CultureInfo.InvariantCulture);
        public static (double x, double y) Along(string d, double u)
        {
            // M x y then C / L segments, absolute (beach.js's cloud paths), sampled
            var nums = NumRx.Matches(d); var pts = new List<(double, double)>();
            if (nums.Count < 2) return (0, 0);
            double px = D(nums[0]), py = D(nums[1]); pts.Add((px, py)); int i = 2; bool cub = d.Contains("C");
            while (i + (cub ? 5 : 1) < nums.Count)
            {
                if (cub) { double x1 = D(nums[i]), y1 = D(nums[i + 1]), x2 = D(nums[i + 2]), y2 = D(nums[i + 3]), x3 = D(nums[i + 4]), y3 = D(nums[i + 5]); for (int k = 1; k <= 24; k++) { double s = k / 24.0, m = 1 - s; pts.Add((m * m * m * px + 3 * m * m * s * x1 + 3 * m * s * s * x2 + s * s * s * x3, m * m * m * py + 3 * m * m * s * y1 + 3 * m * s * s * y2 + s * s * s * y3)); } px = x3; py = y3; i += 6; }
                else { px = D(nums[i]); py = D(nums[i + 1]); pts.Add((px, py)); i += 2; }
            }
            double total = 0; for (int j = 1; j < pts.Count; j++) total += Dist(pts[j - 1], pts[j]);
            double want = u * total;
            for (int j = 1; j < pts.Count; j++) { double l = Dist(pts[j - 1], pts[j]); if (want <= l && l > 0) { double f = want / l; return (pts[j - 1].Item1 + (pts[j].Item1 - pts[j - 1].Item1) * f, pts[j - 1].Item2 + (pts[j].Item2 - pts[j - 1].Item2) * f); } want -= l; }
            return pts[pts.Count - 1];
        }
        static double Dist((double, double) a, (double, double) b) => Math.Sqrt((a.Item1 - b.Item1) * (a.Item1 - b.Item1) + (a.Item2 - b.Item2) * (a.Item2 - b.Item2));

        public static void Write(Node n, StringBuilder sb, double t)
        {
            if (n.Tag == "#text") { sb.Append(n.Text); return; }
            if (n.Tag.StartsWith("animate") || n.Tag == "set") return;
            // this element's animated attributes now
            Dictionary<string, string> ov = null; string motion = null;
            foreach (var a in n.Kids)
            {
                if (!a.Tag.StartsWith("animate")) continue;
                var v = Value(a, t, out var u);
                if (a.Tag == "animateMotion") { if (a.Get("path") != null && Secs(a.Get("dur")) > 0 && t >= Secs(a.Get("begin"))) { var p = Along(a.Get("path"), u); motion = "translate(" + HouseGeo.N(Math.Round(p.x * 100) / 100) + " " + HouseGeo.N(Math.Round(p.y * 100) / 100) + ")"; } continue; }
                if (v == null) continue;
                ov ??= new Dictionary<string, string>();
                if (a.Tag == "animateTransform") ov["transform"] = (a.Get("type") ?? "translate") + "(" + v + ")";
                else if (a.Get("attributeName") != null) ov[a.Get("attributeName")] = v;
            }
            sb.Append('<').Append(n.Tag);
            var done = new HashSet<string>();
            foreach (var kv in n.A)
            {
                string v = ov != null && ov.TryGetValue(kv.Key, out var o) ? o : kv.Value; done.Add(kv.Key);
                if (kv.Key == "transform" && motion != null) { v = motion + " " + v; motion = null; }
                sb.Append(' ').Append(kv.Key).Append("=\"").Append(v).Append('"');
            }
            if (ov != null) foreach (var kv in ov) if (!done.Contains(kv.Key)) { var v = kv.Key == "transform" && motion != null ? motion + " " + kv.Value : kv.Value; if (kv.Key == "transform") motion = null; sb.Append(' ').Append(kv.Key).Append("=\"").Append(v).Append('"'); }
            if (motion != null) sb.Append(" transform=\"").Append(motion).Append('"');
            sb.Append('>');
            foreach (var c in n.Kids) Write(c, sb, t);
            sb.Append("</").Append(n.Tag).Append('>');
        }
    }
}
