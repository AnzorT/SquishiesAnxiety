// The quick-action wheel round the selected friend (HOUSE_PORT_PLAN.md stage 4), as the page's `qa` markup and qaStep:
// shown while a friend is selected and standing (0.18 s fade), at his head (hx clamped to 20..832, 148..704 open;
// hy above his name tag), unscaled by the camera; closed it's one button (…), open the close button and the seven room
// buttons on an arc (left (i - 3) * 42 - 16, top -sqrt(1 - (a / 150)²) * 55 - 34), each popping in (hsPop 0.22 s,
// 30 ms apart); a locked room's button dimmed (0.55) with its padlock. The pieces are the page's (export-hud.mjs).
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseWheel
    {
        public bool Open { get; private set; }
        readonly HouseCreatures _sim;
        readonly float _k;
        readonly Dictionary<string, (float w, float h)> _size = new Dictionary<string, (float, float)>();
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly Transform _parent;
        double _openAt, _shownAt = -1, _fade;
        bool _shown;
        const int Order = 2000 + 875 * 4;   // (z-index 875 in the box: over the pieces and creatures)

        public HouseWheel(Transform parent, HouseCreatures sim, float screenK, JObj hud)
        {
            _parent = parent; _sim = sim; _k = screenK;
            var w = hud.Obj("wheel");
            foreach (var id in w.Keys) { var a = w.Arr(id); _size[id] = ((float)(double)a[0], (float)(double)a[1]); }
        }

        UiPiece P(string id)
        {
            if (_p.TryGetValue(id, out var p)) return p;
            p = UiPiece.Create(_parent, id, Order);
            var (w, h) = _size[id];
            p.SetSvg(HouseRoomView.Res("hud/" + id), w, h, 10);
            _p[id] = p;
            return p;
        }

        static double L(int i) => Math.Round(((i - 3) * 42 - 16) * 10.0) / 10;
        static double T(int i) { double a = (i - 3) * 42; return Math.Round((-Math.Sqrt(1 - (a / 150) * (a / 150)) * 55 - 34) * 10) / 10; }
        static readonly Func<double, double> EaseOut = SquishSquad.Anim.Easing.Bezier(0, 0, 0.58, 1);

        public void SetOpen(bool open, double now) { Open = open; if (open) _openAt = now; else _openAt = now; }

        // where the wheel's origin is (the page's hx, hy: room box px)
        (double x, double y)? Origin()
        {
            var c = _sim.SelC; if (c == null || c.Moving) return null;
            double s = _sim.S.Geo.SAt(c.Y);
            double hx = Math.Max(Open ? 148 : 20, Math.Min(Open ? 704 : 832, c.X + c.Ox));
            double hy = Math.Max(Open ? 96 : 20, c.Y - c.Lift + c.Oy + (HouseCreatures.TagT - 108) * s - 20);
            return (hx, hy);
        }

        public void Update(double camK, double now)
        {
            var o = Origin();
            bool show = o != null;
            if (show != _shown) { _shown = show; _shownAt = now; }
            _fade = Math.Max(0, Math.Min(1, (now - _shownAt) / 180));
            double op = show ? _fade : 1 - _fade;
            if (_sim.SelC == null) Open = false;
            float pk = UiPiece.PxPerDp;
            foreach (var p in _p.Values) p.Opacity = 0;
            if (op <= 0 || o == null && !show) return;
            var (hx, hy) = o ?? (0, 0);
            double fx = 426 + camK * (hx - 426), fy = 393 + camK * (hy + HouseFrame.BoxTop - 393);
            Affine At(double x, double y, float w, float h, double popAt)
            {
                double t = EaseOut(Math.Max(0, Math.Min(1, (now - popAt) / 220))), sc = 0.92 + 0.08 * t;
                return Affine.ScaleBy(1 / pk, 1 / pk) * Affine.Translate((fx + x + w / 2) * _k, (fy + y + h / 2) * _k) * Affine.ScaleBy(_k * sc, _k * sc) * Affine.Translate(-w / 2, -h / 2);
            }
            double Pop(double popAt) => EaseOut(Math.Max(0, Math.Min(1, (now - popAt) / 220)));
            if (!Open)
            {
                var b = P("qa-open"); var (w, h) = _size["qa-open"];
                b.Transform = At(-15, -15, w, h, _shownAt); b.Opacity = (float)(op * Pop(_shownAt));
                return;
            }
            var x0 = P("qa-close"); var (cw, ch) = _size["qa-close"];
            x0.Transform = At(-13, -13, cw, ch, _openAt); x0.Opacity = (float)(op * Pop(_openAt));
            for (int i = 0; i < HouseCreatures.QA.Length; i++)
            {
                var q = HouseCreatures.QA[i];
                bool lk = q.Room != null && !_sim.S.IsOpen(q.Room);
                string id = "qa-" + q.Label.ToLowerInvariant() + (lk && _size.ContainsKey("qa-" + q.Label.ToLowerInvariant() + "-locked") ? "-locked" : "");
                if (!_size.ContainsKey(id)) continue;
                var b = P(id); var (w, h) = _size[id];
                double at = _openAt + i * 30;
                b.Transform = At(L(i), T(i), w, h, at);
                b.Opacity = (float)(op * Pop(at) * (lk ? 0.55 : 1));
            }
        }

        /// <summary>A tap at a frame point: "open", "close", a QA room's id, or null (not on the wheel).</summary>
        public string Tap(double fx, double fy, double camK)
        {
            var o = Origin(); if (o == null) return null;
            // the wheel isn't scaled by the camera: frame px from its origin
            double ox = 426 + camK * (o.Value.x - 426), oy = 393 + camK * (o.Value.y + HouseFrame.BoxTop - 393);
            double bx = fx - ox, by = fy - oy;
            bool In(double x, double y, double w, double h) => bx >= x && bx <= x + w && by >= y && by <= y + h;
            if (!Open) return In(-15, -15, 30, 30) ? "open" : null;
            if (In(-13, -13, 26, 26)) return "close";
            for (int i = 0; i < HouseCreatures.QA.Length; i++) if (In(L(i), T(i), 32, 43)) return HouseCreatures.QA[i].Id;
            return null;
        }

        public void Destroy() { foreach (var p in _p.Values) if (p != null) Object.Destroy(p.gameObject); _p.Clear(); }
    }
}
