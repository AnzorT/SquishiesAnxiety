// The robot vacuum as the page shows it (vac-bot.js): the robot's own sprite (the dock's drawing's Dr.vac, its SMIL:
// the side brushes and the lidar turning, the eyes blinking, the LED) redrawn 12 times a second, at its floor point
// (left / top), scaled for its depth, the turn wiggle about the floor point, the body's jitter about its middle, at its
// z-index among the pieces and the creatures; the dust sparkles it leaves (a four-point star of white light). Its run is
// House/HouseVac.cs.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseVacView
    {
        readonly HouseRoomView _room; readonly HouseCreatures _sim; readonly float _k;
        sealed class Bot { public UiPiece P; public List<Smil.Node> Nodes; public double[] Bb; public double Rd; public int Frame = -1; }
        readonly Dictionary<string, Bot> _bots = new Dictionary<string, Bot>();
        readonly List<UiPiece> _dust = new List<UiPiece>();
        const float DustDp = 10;
        const string DustSvg = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 100 100\"><defs><radialGradient id=\"vd\" gradientUnits=\"userSpaceOnUse\" cx=\"50\" cy=\"50\" r=\"70.71\">"
            + "<stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.18\" stop-color=\"#ffffff\"/><stop offset=\"0.34\" stop-color=\"#dff6ff\" stop-opacity=\"0.7\"/><stop offset=\"0.68\" stop-color=\"#dff6ff\" stop-opacity=\"0\"/></radialGradient></defs>"
            + "<polygon points=\"50,0 61,39 100,50 61,61 50,100 39,61 0,50 39,39\" fill=\"url(#vd)\"/></svg>";

        public HouseVacView(HouseRoomView room, HouseCreatures sim, float screenK) { _room = room; _sim = sim; _k = screenK; }

        // room px -> screen dp (the camera: the box scaled by k about (426, 393) of the frame), as the beach's props
        Affine Cam(double k)
        {
            float pk = UiPiece.PxPerDp;
            return Affine.ScaleBy(_k / pk, _k / pk) * Affine.Translate(426, 393) * Affine.ScaleBy(k, k) * Affine.Translate(-426, HouseFrame.BoxTop - 393);
        }

        public void Update(double now)
        {
            // the views of robots gone home or taken away
            List<string> gone = null;
            foreach (var key in _bots.Keys) if (!_sim.Vacs.TryGetValue(key, out var v) || v.Dead) (gone ??= new List<string>()).Add(key);
            if (gone != null) foreach (var key in gone) { Object.Destroy(_bots[key].P.gameObject); _bots.Remove(key); }
            var cam = Cam(_room.CamK);
            int nd = 0;
            foreach (var kv in _sim.Vacs)
            {
                var vac = kv.Value; if (vac.Dead) continue;
                if (!_bots.TryGetValue(kv.Key, out var b)) { b = Make(vac); if (b == null) continue; _bots[kv.Key] = b; }
                // its SMIL at 12 frames a second (from when it set off)
                int f = (int)Math.Floor(Math.Max(0, now - vac.T0) / 1000 * 12);
                if (f != b.Frame) { b.Frame = f; Draw(b, f / 12.0); }
                var (x, y, s, z, wig, lift, jit) = vac.Pose(now);
                double bx = b.Bb[0], by = b.Bb[1], bw = b.Bb[2], bh = b.Bb[3];
                var m = cam * Affine.Translate(x, y) * Affine.ScaleBy(s, s) * Affine.Rotate(wig) * Affine.Translate(0, -lift)
                    * Affine.Translate(bx + bw / 2, by + bh / 2) * Affine.Rotate(jit) * Affine.Translate(-bw / 2, -bh / 2) * Affine.ScaleBy(1 / b.Rd, 1 / b.Rd);
                b.P.Transform = m; b.P.Order = HouseRoomView.OrderOf(z); b.P.Visible = true;
                foreach (var d in vac.Dusts)
                {
                    var (op, sc, ty) = HouseVac.DustAt(d, now);
                    if (nd == _dust.Count) { var p = UiPiece.Create(_room.transform, "vac dust", 0); p.SetSvg(DustSvg, DustDp, DustDp, 1); _dust.Add(p); }
                    var dp = _dust[nd++];
                    dp.Transform = cam * Affine.Translate(d.L + d.Size / 2, d.T + d.Size / 2) * Affine.ScaleBy(sc, sc) * Affine.Translate(0, ty) * Affine.ScaleBy(d.Size / DustDp, d.Size / DustDp) * Affine.Translate(-DustDp / 2, -DustDp / 2);
                    dp.Opacity = (float)op; dp.Order = HouseRoomView.OrderOf(d.Z); dp.Visible = true;
                }
            }
            for (int i = nd; i < _dust.Count; i++) _dust[i].Visible = false;
        }

        Bot Make(HouseVac vac)
        {
            var it = FindItem(vac.Id); if (it == null) return null;
            var D = _sim.S.D.CatOf(it.Str("t"));
            bool sp = _sim.S.CanSpin(it);
            double? rot = sp ? it.Num("r") : D != null && D.Truthy("mount") ? (it.Truthy("w") ? it.Num("r") : 0) : (double?)null;
            var o = HouseDraw.Vac(D?.Str("reno") ?? "LIV-136", rot, _sim.S.Cur);
            var bb = o?.Arr("bb"); var src = o?.Str("src");
            if (bb == null || bb.Count < 4 || string.IsNullOrEmpty(src)) return null;
            var b = new Bot { Nodes = Smil.Parse(src), Bb = new[] { Convert.ToDouble(bb[0]), Convert.ToDouble(bb[1]), Convert.ToDouble(bb[2]), Convert.ToDouble(bb[3]) } };
            // (drawn at the size it shows at its dock with the camera at 1, so it stays sharp; px per sprite unit)
            b.Rd = Math.Max(0.5, vac.SAt(vac.Y) * _k / UiPiece.PxPerDp * 1.25);
            b.P = UiPiece.Create(_room.transform, "robot vacuum", HouseRoomView.OrderOf(HouseVac.Z(vac.Y)));
            return b;
        }

        JObj FindItem(string id)
        {
            foreach (var o in _sim.S.H.Obj("rooms")?[_sim.S.Cur] as List<object> ?? new List<object>()) if (o is JObj it && it.Str("id") == id) return it;
            return null;
        }

        void Draw(Bot b, double t)
        {
            var sb = new StringBuilder();
            foreach (var n in b.Nodes) Smil.Write(n, sb, t);
            float w = (float)(b.Bb[2] * b.Rd), h = (float)(b.Bb[3] * b.Rd);
            var svg = sb.ToString();
            int i = svg.IndexOf("<svg", StringComparison.Ordinal);
            if (i >= 0) svg = svg.Substring(0, i) + "<svg width=\"" + w.ToString("0.###", CultureInfo.InvariantCulture) + "\" height=\"" + h.ToString("0.###", CultureInfo.InvariantCulture) + "\" preserveAspectRatio=\"none\"" + svg.Substring(i + 4);
            b.P.SetSvg(svg, w, h, 2);
        }

        public void Clear()
        {
            foreach (var b in _bots.Values) if (b.P != null) Object.Destroy(b.P.gameObject);
            _bots.Clear();
            foreach (var p in _dust) if (p != null) Object.Destroy(p.gameObject);
            _dust.Clear();
        }
    }
}
