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

        sealed class Run { public bool Anim; public readonly List<Smil.Node> Nodes = new List<Smil.Node>(); public Mesh Mesh; public RenderTexture Tex; public Material Mat; public double Next; public GameObject Go; }
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
                Split(Smil.Parse(Data.Str("body")));
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

        // ---------- the scene's runs (its markup parsed and sampled by House/Smil.cs) ----------
        /// <summary>Runs of top-level parts: still ones of any size alone, small still ones folded into the moving run
        /// around them (fewer textures).</summary>
        void Split(List<Smil.Node> top)
        {
            Run r = null;
            foreach (var n in top)
            {
                bool a = n.Animated;
                if (!a && r != null && r.Anim && Smil.Size(n) < 600) { r.Nodes.Add(n); continue; }
                if (r == null || r.Anim != a) { r = new Run { Anim = a }; _runs.Add(r); }
                r.Nodes.Add(n);
            }
        }

        // ---------- drawing ----------
        void Draw(Run r, double t, bool first)
        {
            var v = View; float res = r.Anim ? AnimRes : 1;
            var sb = new StringBuilder();
            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"").Append(F(v[0])).Append(' ').Append(F(v[1] - HouseFrame.BoxTop)).Append(' ').Append(F(v[2])).Append(' ').Append(F(v[3])).Append("\"><defs>").Append(_defs).Append("</defs>");
            foreach (var n in r.Nodes) Smil.Write(n, sb, t);
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
