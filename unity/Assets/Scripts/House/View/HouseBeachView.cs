// The Beach's picture (HOUSE_PORT_PLAN.md stage 10): beach.js's live scene (the sea, the pier, the dunes, palms,
// clouds, the season and the night; __house.beach in the draw host) drawn over the room's base as the page injects it
// (the room svg's last child), cut into runs of its top-level parts: the still ones drawn once, the moving ones (SMIL:
// animate, animateTransform, animateMotion, sampled here) redrawn 12 times a second at a lower resolution; the props
// (shells, snowmen, the fishing sign) at their z-index among the creatures, and their taps. The creatures' gear and
// wading are drawn by HouseSquadView (Gear, Wet).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseBeachView
    {
        readonly HouseRoomView _room; readonly HouseCreatures _sim; readonly float _k;
        public static JObj Data;   // the last __house.beach (board / rod for HouseSquadView)
        string _key; int _shellsVer = -1; bool _fishSign;
        readonly List<Run> _runs = new List<Run>();
        readonly List<Prop> _props = new List<Prop>();
        readonly List<Object> _made = new List<Object>();
        string _defs;
        const float AnimRes = 0.6f;
        const int Order = 11;   // (over the room's base, under the pieces)

        sealed class Run { public bool Anim; public readonly List<Node> Nodes = new List<Node>(); public Mesh Mesh; public RenderTexture Tex; public Material Mat; public double Next; public GameObject Go; }
        sealed class Prop { public string Id, Kind; public JObj Shell; public double L, T, W, H, Z; public UiPiece P; }

        public HouseBeachView(HouseRoomView room, HouseCreatures sim, float screenK) { _room = room; _sim = sim; _k = screenK; }

        static double[] View => HouseRoomView.View;   // (g space: frame px at camK 1; room y = g y - BoxTop)

        public void Update(double now)
        {
            if (_sim.S.Cur != "beach" || !HouseDraw.On) { if (_key != null) Clear(); return; }
            var o = Opts(); var key = HouseJson.Stringify(o);
            if (key != _key)
            {
                Clear(); _key = key;
                string js = null; try { js = HouseDraw.Eval("__house.beach(" + Quote(key) + ")"); } catch (Exception) { }
                if (js == null || js == "null") return;
                Data = (JObj)HouseJson.Parse(js); _defs = Data.Str("defs");
                Split(Parse(Data.Str("body")));
                foreach (var r in _runs) Draw(r, 0, true);
                _shellsVer = -1;
            }
            double t = now / 1000, k = _room.CamK;
            foreach (var r in _runs)
            {
                if (r.Anim && now >= r.Next) { r.Next = now + 1000 / 12.0; Draw(r, t, false); }
                Place(r, k);
            }
            Props(now, k);
        }

        JObj Opts()
        {
            var H = _sim.S.H; var RT = H.Obj("rtex")?.Obj("beach") ?? new JObj(); var SF = H.Obj("surf")?.Obj("beach") ?? new JObj();
            double Tier(string id) { if (id == null) return 0; var r = _sim.S.D.Row(Regex.Replace(id, "^rv_", "")); return r != null ? r.Num("tier") : 0; }
            double sand = Tier(RT.Str("ground")), pier = Tier(RT.Str("fence"));
            var season = _sim.SeasonNow(); HouseCreatures.Beach.Season = season;
            return new JObj { ["season"] = season, ["night"] = H.Obj("night").Truthy("bedroom"), ["sand"] = sand > 0 ? sand : 1, ["pier"] = pier > 0 ? pier : 1, ["light"] = Tier(SF.Str("ylight")) };
        }
        static string Quote(string s) => "\"" + s.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";

        // ---------- the scene's markup ----------
        sealed class Node
        {
            public string Tag, Text; public readonly List<KeyValuePair<string, string>> A = new List<KeyValuePair<string, string>>(); public readonly List<Node> Kids = new List<Node>(); public Node Parent;
            public string Get(string k) { foreach (var kv in A) if (kv.Key == k) return kv.Value; return null; }
            public bool Animated { get { if (Tag.StartsWith("animate")) return true; foreach (var c in Kids) if (c.Animated) return true; return false; } }
            public Func<double, double>[] Splines;
        }
        static readonly Regex Tok = new Regex("<(/?)([\\w:-]+)((?:\\s+[\\w:-]+=\"[^\"]*\")*)\\s*(/?)>|([^<]+)", RegexOptions.Compiled);
        static readonly Regex Att = new Regex("([\\w:-]+)=\"([^\"]*)\"", RegexOptions.Compiled);
        static List<Node> Parse(string s)
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
        /// <summary>Runs of top-level parts: still ones of any size alone, small still ones folded into the moving run
        /// around them (fewer textures).</summary>
        void Split(List<Node> top)
        {
            Run r = null;
            foreach (var n in top)
            {
                bool a = n.Animated;
                if (!a && r != null && r.Anim && Size(n) < 600) { r.Nodes.Add(n); continue; }
                if (r == null || r.Anim != a) { r = new Run { Anim = a }; _runs.Add(r); }
                r.Nodes.Add(n);
            }
        }
        static int Size(Node n) { int s = 40; foreach (var kv in n.A) s += kv.Value.Length; foreach (var c in n.Kids) s += Size(c); return s; }

        // ---------- SMIL at time t ----------
        static readonly Regex NumRx = new Regex("-?(?:\\d+\\.?\\d*|\\.\\d+)(?:e[-+]?\\d+)?", RegexOptions.Compiled);
        static double Secs(string v) { if (string.IsNullOrEmpty(v)) return 0; v = v.Trim(); double k = 1; if (v.EndsWith("ms")) { k = 0.001; v = v.Substring(0, v.Length - 2); } else if (v.EndsWith("s")) v = v.Substring(0, v.Length - 1); return double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out var d) ? d * k : 0; }
        static string Lerp(string a, string b, double u)
        {
            var ma = NumRx.Matches(a); var mb = NumRx.Matches(b); if (ma.Count != mb.Count) return u < 0.5 ? a : b;
            int i = 0;
            return NumRx.Replace(a, m => { double x = double.Parse(m.Value, CultureInfo.InvariantCulture), y = double.Parse(mb[i++].Value, CultureInfo.InvariantCulture); return HouseGeo.N(Math.Round((x + (y - x) * u) * 100) / 100); });
        }
        /// <summary>An animation's value at t (null before it begins).</summary>
        static string Value(Node a, double t, out double u)
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
        static (double x, double y) Along(string d, double u)
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

        static void Write(Node n, StringBuilder sb, double t)
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

        // ---------- drawing ----------
        void Draw(Run r, double t, bool first)
        {
            var v = View; float res = r.Anim ? AnimRes : 1;
            var sb = new StringBuilder();
            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"").Append(F(v[0])).Append(' ').Append(F(v[1] - HouseFrame.BoxTop)).Append(' ').Append(F(v[2])).Append(' ').Append(F(v[3])).Append("\"><defs>").Append(_defs).Append("</defs>");
            foreach (var n in r.Nodes) Write(n, sb, t);
            sb.Append("</svg>");
            float tw = (float)(v[2] * _k * res), th = (float)(v[3] * _k * res);
            int w = Mathf.CeilToInt(tw), h = Mathf.CeilToInt(th);
            if (r.Tex == null)
            {
                r.Tex = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32) { name = "beach layer" }; r.Tex.Create(); _made.Add(r.Tex);
                r.Go = new GameObject(r.Anim ? "beach (moving)" : "beach"); r.Go.transform.SetParent(_room.transform, false); _made.Add(r.Go);
                r.Mesh = new Mesh { name = "beach quad" }; r.Mesh.MarkDynamic(); _made.Add(r.Mesh);
                r.Mesh.SetVertices(new Vector3[4]); r.Mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) }); r.Mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
                r.Go.AddComponent<MeshFilter>().sharedMesh = r.Mesh;
                var mr = r.Go.AddComponent<MeshRenderer>(); r.Mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = r.Tex }; _made.Add(r.Mat);
                mr.sharedMaterial = r.Mat; mr.sortingOrder = Order + _runs.IndexOf(r);
            }
            var msaa = RenderTexture.GetTemporary(new RenderTextureDescriptor(w, h, RenderTextureFormat.ARGB32, 24) { msaaSamples = 4 });
            var root = SvgMarkup.Parse(sb.ToString());
            PatternExpand.Expand(root);
            var scene = SvgScene.Compile(root, tw, th, Affine.Identity, null);
            using (var vr = new VectorRenderer()) vr.Render(scene, msaa);
            Graphics.Blit(msaa, r.Tex);
            RenderTexture.ReleaseTemporary(msaa);
        }
        static string F(double v) => HouseGeo.N(Math.Round(v * 1000) / 1000);

        // a layer's quad: its corners (g space at camK 1) scaled by k about (426, 393) as the room's pieces
        void Place(Run r, double k)
        {
            if (r.Mesh == null) return;
            var v = View; Vector3 V(double gx, double gy) { double fx = 426 + k * (gx - 426), fy = 393 + k * (gy - 393); return new Vector3((float)(fx * _k), (float)(-fy * _k), 0); }
            r.Mesh.SetVertices(new[] { V(v[0], v[1]), V(v[0] + v[2], v[1]), V(v[0] + v[2], v[1] + v[3]), V(v[0], v[1] + v[3]) });
            r.Mesh.RecalculateBounds();
        }

        // ---------- the props: shells, the season's, the fishing sign ----------
        void Props(double now, double k)
        {
            bool fs = _sim.FishSign;
            if (_shellsVer != _sim.ShellsVer || fs != _fishSign)
            {
                _shellsVer = _sim.ShellsVer; _fishSign = fs;
                foreach (var p in _props) Object.Destroy(p.P.gameObject); _props.Clear();
                var G = _sim.S.Geo; var shells = Data.Arr("shells");
                foreach (JObj q in _sim.Shells)
                {
                    double y = q.Num("y"), s = G.SAt(y) / 0.42, w = 24 * s, h = 19 * s;
                    Add(new Prop { Id = q.Str("id"), Kind = "shell", Shell = q, L = q.Num("x") - w / 2, T = y - h * 0.7, W = w, H = h, Z = Math.Round(y) }, (string)shells[(int)q.Num("k") % shells.Count]);
                }
                foreach (JObj q in Data.Arr("props"))
                {
                    double y = q.Num("y"), s = G.SAt(y) / 0.42 * 0.62;
                    Add(new Prop { Id = q.Str("id"), Kind = "prop", L = q.Num("x") - q.Num("ax") * s, T = y - q.Num("ay") * s, W = q.Num("w") * s, H = q.Num("h") * s, Z = Math.Round(y) }, q.Str("src"));
                }
                if (fs) { double x = HouseCreatures.Beach.XP1 - 40, y = HouseCreatures.Beach.Py0 - 30; Add(new Prop { Id = "fishsign", Kind = "fish", L = x - 13, T = y - 13, W = 26, H = 26, Z = 900 }, Data.Str("fish")); }
            }
            float pk = UiPiece.PxPerDp;
            foreach (var p in _props)
            {
                // room px -> screen px (the camera about (426, 393) of the frame), as dp
                double gy = p.T + HouseFrame.BoxTop, fx = 426 + k * (p.L - 426), fy = 393 + k * (gy - 393);
                p.P.Transform = Affine.Translate(fx * _k / pk, fy * _k / pk) * Affine.ScaleBy(k, k);
            }
        }
        void Add(Prop p, string svg)
        {
            if (string.IsNullOrEmpty(svg)) return;
            float pk = UiPiece.PxPerDp, w = (float)(p.W * _k / pk), h = (float)(p.H * _k / pk);
            svg = Regex.Replace(svg, "^<svg", $"<svg width=\"{F(w)}\" height=\"{F(h)}\" preserveAspectRatio=\"none\"");
            p.P = UiPiece.Create(_room.transform, "beach " + p.Id, HouseRoomView.OrderOf(p.Z));
            p.P.SetSvg(svg, w, h, 4);
            _props.Add(p);
        }

        /// <summary>A tap on a prop (room px): a shell (the selected friend picks it), the fishing sign, a snowman.</summary>
        public bool Tap(double x, double y, double now)
        {
            Prop top = null;
            foreach (var p in _props) if (x >= p.L && x <= p.L + p.W && y >= p.T && y <= p.T + p.H && (top == null || p.Z >= top.Z)) top = p;
            if (top == null) return false;
            if (top.Kind == "shell") _sim.BPick(top.Shell, now);
            else if (top.Kind == "fish") _sim.Act("fish", null, now);
            else { var c = _sim.SelC; if (c != null) _sim.Say(c, "Brrr!", now); }
            return true;
        }

        public void Clear()
        {
            _key = null; _runs.Clear();
            foreach (var p in _props) if (p.P != null) Object.Destroy(p.P.gameObject); _props.Clear();
            foreach (var o in _made) if (o != null) { if (o is RenderTexture rt) rt.Release(); Object.Destroy(o); }
            _made.Clear();
        }
    }
}
