// The squad drawn in the house (HOUSE_PORT_PLAN.md stage 3), as the page's `crs` markup: each creature's 120 x 120 box
// at translate(x - 60 + ox, y - 108 - lift + oy) rotate(rot) scale(sAt(y)) about (60, 108), scaled again by CRDEF, its
// two floor shadows and the selection ring, the rig (CreatureView: live with the walk's ext channels, else its
// recording; without either, its cut-out picture), the name tag when selected and the speech bubble; sorted with the
// room's pieces by z-index (HouseRoomView.OrderOf); and the particles (spawn's keyframes). Positions follow the camera.
using System;
using System.Collections.Generic;
using SquishSquad.Creatures;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseSquadView
    {
        sealed class One
        {
            public HouseCreature C;
            public GameObject Root;
            public CreatureView Rig;
            public IHouseRig Live;
            public UiPiece Still, Floor, Tag, Say, Board, Rod, Ring;
            public string TagFor, SayFor;
            public float K0, StillW, StillH;
        }

        const string RingSvg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"76\" height=\"16\" viewBox=\"0 0 76 16\"><defs><radialGradient id=\"bw\"><stop offset=\"0\" stop-color=\"rgb(150,225,245)\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"rgb(150,225,245)\" stop-opacity=\"0.12\"/></radialGradient></defs><ellipse cx=\"38\" cy=\"8\" rx=\"36.75\" ry=\"6.75\" fill=\"url(#bw)\" stroke=\"rgba(255,255,255,0.9)\" stroke-width=\"2.5\"/></svg>";
        static UiPiece Gear(One o, UiPiece p, string what, bool on, int order, Affine box)
        {
            if (!on) { if (p != null) p.Visible = false; return p; }
            var svg = HouseBeachView.Data?.Str(what); if (svg == null) return p;
            if (p == null) { p = UiPiece.Create(o.Root.transform, what, order); p.SetSvg(svg.Replace("<svg ", "<svg xmlns=\"http://www.w3.org/2000/svg\" "), 120, 120, 30); }
            p.Visible = true; p.Order = order; p.Transform = box; return p;
        }
        readonly Transform _parent;
        readonly HouseCreatures _sim;
        readonly Dictionary<HouseCreature, One> _all = new Dictionary<HouseCreature, One>();
        readonly List<UiPiece> _fx = new List<UiPiece>();
        float _k;   // screen px per frame px

        public HouseSquadView(Transform parent, HouseCreatures sim, float screenK)
        {
            _parent = parent; _sim = sim; _k = screenK;
            sim.Fidg = c => _all.TryGetValue(c, out var o) && o.Live != null && o.Live.InFidget();
            sim.PlayIdle = c => { if (_all.TryGetValue(c, out var o)) o.Rig?.Play("idle"); };
            sim.Play = (c, n) => { if (_all.TryGetValue(c, out var o)) o.Rig?.Play(n); };
        }

        static readonly TextStyle TagStyle = new TextStyle { Font = "Fredoka_700Bold", Size = 16, Color = "#5b3418" };
        static readonly TextStyle SayStyle = new TextStyle { Font = "Fredoka_700Bold", Size = 17, Color = "#5b3418" };

        /// <summary>The room changed: the creatures in it (Vis) get their views, the others' go.</summary>
        public void Rebuild()
        {
            foreach (var o in _all.Values) Kill(o);
            _all.Clear();
            foreach (var c in _sim.Vis) _all[c] = Make(c);
        }

        One Make(HouseCreature c)
        {
            var o = new One { C = c, Root = new GameObject("creature " + c.Key) };
            o.Root.transform.SetParent(_parent, false);
            // texture resolution: his biggest size on screen (front of the floor, camK 1)
            o.K0 = (float)(_k * _sim.S.Geo.SAt(_sim.S.Geo.FY1) * HouseCreatures.CRDEF);
            var rig = Rigs.For(c.Key);
            if (rig != null)
            {
                o.Rig = CreatureView.Create(o.Root.transform, rig, new Rect(-60 * o.K0, -108 * o.K0, 120 * o.K0, 120 * o.K0), 0);
                o.Live = rig as IHouseRig;
            }
            else
            {
                // no rig here (the live one off, no recording): his cut-out standing in the box (feet at 108)
                var tex = Resources.Load<Texture2D>("Stack/art/" + c.Key);
                if (tex != null)
                {
                    o.Still = UiPiece.Create(o.Root.transform, "still", 0);
                    float ar = (float)tex.width / tex.height;
                    o.StillH = ar >= 1 ? 92 / ar : 92; o.StillW = o.StillH * ar;
                    o.Still.SetPicture(tex, o.StillW, o.StillH);
                }
            }
            o.Floor = UiPiece.Create(o.Root.transform, "floor", 0);
            return o;
        }

        static void Kill(One o)
        {
            if (o.Rig != null) Object.Destroy(o.Rig.gameObject);
            if (o.Root != null) Object.Destroy(o.Root);
        }

        // the page's two shadows under him and, selected, the gold ring (the 120 x 120 box's own px)
        static string FloorSvg(bool sel)
        {
            var s = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"120\" height=\"120\" viewBox=\"0 0 120 120\" overflow=\"visible\"><defs>" +
                    "<radialGradient id=\"s1\"><stop offset=\"0\" stop-color=\"rgb(48,26,10)\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"rgb(48,26,10)\" stop-opacity=\"0\"/></radialGradient>" +
                    "<radialGradient id=\"s2\"><stop offset=\"0\" stop-color=\"rgb(36,18,6)\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"rgb(36,18,6)\" stop-opacity=\"0\"/></radialGradient>" +
                    (sel ? "<filter id=\"g\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"5\"/></filter>" : "") + "</defs>" +
                    "<ellipse cx=\"60\" cy=\"108\" rx=\"38\" ry=\"10\" fill=\"url(#s1)\"/><ellipse cx=\"60\" cy=\"107.5\" rx=\"22\" ry=\"4.5\" fill=\"url(#s2)\"/>";
            if (sel) s += "<ellipse cx=\"60\" cy=\"108\" rx=\"36\" ry=\"11\" fill=\"none\" stroke=\"rgba(255,214,107,0.9)\" stroke-width=\"6\" filter=\"url(#g)\"/>" +
                          "<ellipse cx=\"60\" cy=\"108\" rx=\"34.5\" ry=\"9.5\" fill=\"none\" stroke=\"#ffd66b\" stroke-width=\"3\"/>";
            return s + "</svg>";
        }

        // a bubble / tag: cream, rounded, a brown ring (the page's box-shadow 0 0 0 2.5px #6b4426 and its drop)
        static (string svg, float w, float h) Bubble(string text, TextStyle st, float padH, float padV, float radius, bool say)
        {
            float tw = UiSvg.BoxWidth(text, st), lh = UiSvg.LineBox(st), w = tw + 2 * padH, h = lh + 2 * padV;
            var shadows = say
                ? new[] { new Shadow("#6b4426", 0, 0, 0, 2.5f), new Shadow("rgba(107,68,38,0.3)", 0, 3, 0, 2.5f), new Shadow("rgba(60,35,15,0.2)", 0, 6, 10, 0) }
                : new[] { new Shadow("#6b4426", 0, 0, 0, 2.5f), new Shadow("rgba(107,68,38,0.35)", 0, 3, 0, 2.5f) };
            var s = new UiSvg(w, h).Box(0, 0, w, h, new BoxStyle { Background = "#fff6e2", Radius = radius, Shadows = shadows });
            s.Text(text, padH, padV, st);
            return (s.Markup, w, h);
        }

        /// <summary>Each frame, after the simulation's tick: everyone where the page puts them, at the camera's k.</summary>
        public void Update(double camK, double now)
        {
            float pk = UiPiece.PxPerDp;
            for (int i = 0; i < _sim.Vis.Count; i++)
            {
                var c = _sim.Vis[i];
                if (!_all.TryGetValue(c, out var o)) _all[c] = o = Make(c);
                var (tx, ty, rot, s, z) = _sim.Transform(c);
                // the box's origin point (60, 108) in the frame at the camera's k
                double bx = tx + 60, by = ty + 108;
                double fx = 426 + camK * (bx - 426), fy = 393 + camK * (by + HouseFrame.BoxTop - 393);
                double scale = camK * s * HouseCreatures.CRDEF;   // frame px per box px
                // UiPiece (dp, y down): the box's own px -> screen
                Affine Box(double sub = 1) => Affine.ScaleBy(1 / pk, 1 / pk) * Affine.Translate(fx * _k, fy * _k) * Affine.ScaleBy(_k * scale, _k * scale) * Affine.Rotate(rot) * Affine.Translate(-60, -108);
                int order = HouseRoomView.OrderOf(z);
                bool sel = _sim.SelC == c;
                o.Floor.SetSvg(FloorSvg(sel), 120, 120, 30);
                o.Floor.Transform = Box(); o.Floor.Order = order + 1;
                // the beach (bWet, bGear): wading cuts him off at the water line (20 + 18 x depth px of his box) with a
                // ring of water there and no shadow; the board under him, the rod in front
                bool wet = c.Wet && !c.Rsw; double ins = wet ? Math.Round(20 + 18 * c.Wd) : 0;
                o.Rig?.ClipBottom(wet ? (float)((120 - ins) / 120) : -1);
                o.Floor.Opacity = wet ? 0 : 1;
                if (wet)
                {
                    if (o.Ring == null) { o.Ring = UiPiece.Create(o.Root.transform, "ring", 0); o.Ring.SetSvg(RingSvg, 76, 16, 4); }
                    double ru = now % 2200 / 1100, re = ru > 1 ? 2 - ru : ru; re = re * re * (3 - 2 * re);
                    o.Ring.Visible = true; o.Ring.Order = order + 3;
                    o.Ring.Transform = Box() * Affine.Translate(60, 120 - ins) * Affine.ScaleBy(0.94 + 0.12 * re, 0.88 + 0.22 * re) * Affine.Translate(-38, -8);
                }
                else if (o.Ring != null) o.Ring.Visible = false;
                o.Board = Gear(o, o.Board, "board", c.Gear == "board", order + 1, Box());
                o.Rod = Gear(o, o.Rod, "rod", c.Gear == "rod", order + 3, Box());
                if (o.Rig != null)
                {
                    var t = o.Root.transform;
                    t.localPosition = new Vector3((float)(fx * _k), (float)(-fy * _k), 0);
                    t.localRotation = Quaternion.Euler(0, 0, (float)-rot);
                    float sc = (float)(_k * scale / o.K0);
                    t.localScale = new Vector3(sc, sc, 1);
                    o.Rig.GetComponent<MeshRenderer>().sortingOrder = order + 2;
                    o.Live?.Ext(c.Ext);
                    if (o.Live != null) foreach (var n in o.Live.Events()) _sim.OnRig(c, n, now);
                    o.Live?.Fidgets(!c.Moving && c.Mode == "free");
                }
                else if (o.Still != null)
                {
                    o.Still.Transform = Box() * Affine.Translate(60 - o.StillW / 2, 108 - o.StillH);
                    o.Still.Order = order + 2;
                }
                // the name tag (selected) and the speech bubble: unscaled by his size, at the page's tagT / sayT
                double tagT = HouseCreatures.TagT, sayT = sel ? tagT - 76 : tagT - 28;
                Affine Above(double top, float w) => Affine.ScaleBy(1 / pk, 1 / pk) * Affine.Translate(fx * _k, fy * _k) * Affine.ScaleBy(_k * camK * s, _k * camK * s) * Affine.Rotate(rot) * Affine.Translate(-w / 2, top - 108);
                if (sel)
                {
                    o.Tag ??= UiPiece.Create(o.Root.transform, "tag", 0);
                    var b = Bubble(c.Name ?? c.Key, TagStyle, 10, 1, 6, false);
                    if (o.TagFor != c.Name) { o.Tag.SetSvg(b.svg, b.w, b.h, 8); o.TagFor = c.Name; }
                    o.Tag.Transform = Above(tagT, b.w); o.Tag.Order = order + 3; o.Tag.Opacity = 1;
                }
                else if (o.Tag != null) o.Tag.Opacity = 0;
                double since = now - c.SayAt;
                if (c.SayText != null && since < HouseCreatures.SayMs + 250)
                {
                    o.Say ??= UiPiece.Create(o.Root.transform, "say", 0);
                    var b = Bubble(c.SayText, SayStyle, 12, 3, 12, true);
                    if (o.SayFor != c.SayText) { o.Say.SetSvg(b.svg, b.w, b.h, 14); o.SayFor = c.SayText; }
                    // opacity / translateY ease in over 0.25 s, out 0.25 s after 1.6 s (CSS transitions)
                    double inT = Math.Min(1, since / 250), outT = since > HouseCreatures.SayMs ? Math.Min(1, (since - HouseCreatures.SayMs) / 250) : 0;
                    double op = Ease(inT) * (1 - Ease(outT)), dy = -8 * op;
                    o.Say.Transform = Above(sayT + dy, b.w); o.Say.Order = order + 3; o.Say.Opacity = (float)op;
                }
                else if (o.Say != null) o.Say.Opacity = 0;
            }
            DrawFx(camK, now);
        }

        static double Ease(double t) => SquishSquad.Anim.Easing.Bezier(0.25, 0.1, 0.25, 1)(Math.Max(0, Math.Min(1, t)));

        // ---- the particles: spawn's elements and their Web Animations keyframes ----
        static readonly Dictionary<string, string> FxSvg = new Dictionary<string, string>();

        static string ParticleSvg(HouseParticle p, out float w, out float h)
        {
            switch (p.Type)
            {
                case "bubble":
                    w = h = (float)p.Size;
                    return $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{w}\" height=\"{h}\" viewBox=\"0 0 {w} {h}\"><defs><radialGradient id=\"b\" cx=\"32%\" cy=\"30%\" r=\"80%\"><stop offset=\"0\" stop-color=\"#fff\" stop-opacity=\"0.95\"/><stop offset=\"0.6\" stop-color=\"rgb(180,225,250)\" stop-opacity=\"0.3\"/></radialGradient></defs><circle cx=\"{w / 2}\" cy=\"{h / 2}\" r=\"{w / 2 - 1}\" fill=\"url(#b)\" stroke=\"rgba(255,255,255,0.95)\" stroke-width=\"2\"/></svg>";
                case "steam":
                    w = h = 18;
                    return "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"18\" height=\"18\" viewBox=\"0 0 18 18\" overflow=\"visible\"><defs><filter id=\"f\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"3\"/></filter></defs><circle cx=\"9\" cy=\"9\" r=\"9\" fill=\"rgba(255,255,255,0.75)\" filter=\"url(#f)\"/></svg>";
                case "note":
                    var st = new TextStyle { Font = "Fredoka_700Bold", Size = 20, Color = p.Color, Shadows = new[] { new Shadow("#45189a", 0, 1.5f, 0) } };
                    w = Math.Max(8, UiSvg.BoxWidth(p.Glyph, st)); h = UiSvg.LineBox(st);
                    return new UiSvg(w, h).Text(p.Glyph, 0, 0, st).Markup;
                case "drop":
                    w = 7; h = 10;
                    return "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"7\" height=\"10\" viewBox=\"0 0 7 10\"><ellipse cx=\"3.5\" cy=\"5\" rx=\"3.5\" ry=\"5\" fill=\"#5cc8f0\"/><path d=\"M1 7 Q3.5 10 6 7\" fill=\"none\" stroke=\"#1e8fc4\" stroke-width=\"1\"/></svg>";
                case "sand":
                    w = h = 6;
                    return "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\"><circle cx=\"3\" cy=\"3\" r=\"3\" fill=\"#e2c27a\"/></svg>";
                default:
                    w = h = 10;
                    return "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 10 10\"><polygon points=\"5,0 6.2,3.8 10,5 6.2,6.2 5,10 3.8,6.2 0,5 3.8,3.8\" fill=\"#ffd66b\"/></svg>";
            }
        }

        // spawn's keyframes: (offset, tx, ty, scale, rot, opacity); bubble / steam / note / spark ease-out, drop / sand linear
        static (double tx, double ty, double sc, double rot, double op) Key(HouseParticle p, double t)
        {
            double sx = p.Sx;
            (double o, double tx, double ty, double sc, double rot, double op)[] k = p.Type switch
            {
                "bubble" => new[] { (0.0, 0.0, 0.0, 0.3, 0.0, 0.0), (0.2, sx * 0.4, -16.0, 1.0, 0.0, 1.0), (1.0, sx, -66.0, 1.1, 0.0, 0.0) },
                "steam" => new[] { (0.0, 0.0, 0.0, 0.6, 0.0, 0.0), (0.2, sx * 0.3, -14.0, 1.0, 0.0, 0.9), (1.0, sx * 0.8, -60.0, 2.2, 0.0, 0.0) },
                "note" => new[] { (0.0, 0.0, 0.0, 0.5, -10.0, 0.0), (0.25, sx * 0.3, -14.0, 1.0, 6.0, 1.0), (1.0, sx, -56.0, 1.0, -8.0, 0.0) },
                "drop" => new[] { (0.0, 0.0, 0.0, 1.0, 0.0, 1.0), (0.45, sx * 0.5, -34.0, 1.0, 0.0, 1.0), (1.0, sx, 12.0, 1.0, 0.0, 0.0) },
                "sand" => new[] { (0.0, 0.0, 0.0, 1.0, 0.0, 1.0), (0.45, sx * 0.6, -26.0, 1.0, 0.0, 1.0), (1.0, sx * 1.2, 8.0, 1.0, 0.0, 0.0) },
                _ => new[] { (0.0, 0.0, 0.0, 0.2, 0.0, 0.0), (0.4, 0.0, 0.0, 1.3, 45.0, 1.0), (1.0, 0.0, -24.0, 0.4, 90.0, 0.0) },
            };
            bool lin = p.Type == "drop" || p.Type == "sand";
            double e = lin ? t : SquishSquad.Anim.Easing.Bezier(0, 0, 0.58, 1)(t);   // (the easing is over the whole animation)
            int i = e < k[1].o ? 0 : 1;
            double u = (e - k[i].o) / (k[i + 1].o - k[i].o);
            double L(double a, double b) => a + (b - a) * u;
            return (L(k[i].tx, k[i + 1].tx), L(k[i].ty, k[i + 1].ty), L(k[i].sc, k[i + 1].sc), L(k[i].rot, k[i + 1].rot), L(k[i].op, k[i + 1].op));
        }

        void DrawFx(double camK, double now)
        {
            float pk = UiPiece.PxPerDp;
            var list = _sim.Particles;
            while (_fx.Count < list.Count) _fx.Add(UiPiece.Create(_parent, "fx", HouseRoomView.OrderOf(820)));
            for (int i = 0; i < _fx.Count; i++)
            {
                if (i >= list.Count) { _fx[i].Opacity = 0; continue; }
                var p = list[i];
                string svg = ParticleSvg(p, out float w, out float h);
                _fx[i].SetSvg(svg, w, h, 6);
                var (tx, ty, sc, rot, op) = Key(p, Math.Min(1, (now - p.Born) / p.Ms));
                double fx = 426 + camK * (p.X - 426), fy = 393 + camK * (p.Y + HouseFrame.BoxTop - 393);
                _fx[i].Transform = Affine.ScaleBy(1 / pk, 1 / pk) * Affine.Translate(fx * _k, fy * _k) * Affine.ScaleBy(_k * camK, _k * camK) * Affine.Translate(tx, ty) * Affine.Rotate(rot) * Affine.ScaleBy(sc, sc) * Affine.Translate(-w / 2, -h / 2);
                _fx[i].Opacity = (float)op;
            }
        }

        /// <summary>The creature under a frame point (the topmost by z-index), as Vis's index, or -1.</summary>
        public int HitCreature(double fx, double fy, double camK)
        {
            int best = -1, bestZ = int.MinValue;
            for (int i = 0; i < _sim.Vis.Count; i++)
            {
                var c = _sim.Vis[i];
                var (tx, ty, rot, s, z) = _sim.Transform(c);
                // the frame point back into his box's own px
                double bx = (fx - 426) / camK + 426 - (tx + 60), by = (fy - 393) / camK + 393 - HouseFrame.BoxTop - (ty + 108);
                double r = -rot * Math.PI / 180, ux = bx * Math.Cos(r) - by * Math.Sin(r), uy = bx * Math.Sin(r) + by * Math.Cos(r);
                double sc = s * HouseCreatures.CRDEF; ux = ux / sc + 60; uy = uy / sc + 108;
                if (ux >= 0 && ux <= 120 && uy >= 0 && uy <= 120 && z > bestZ) { best = i; bestZ = z; }
            }
            return best;
        }

        public void Destroy()
        {
            foreach (var o in _all.Values) Kill(o);
            _all.Clear();
            foreach (var f in _fx) if (f != null) Object.Destroy(f.gameObject);
            _fx.Clear();
        }
    }
}
