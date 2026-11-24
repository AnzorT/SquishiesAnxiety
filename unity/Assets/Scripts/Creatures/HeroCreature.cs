// The chest unlock's creature after the BAM (Screens/Chests/ChestSmashView.cs "heroRig" slot, tools/chest/host.html
// rigReady / rigLive / popAt): the creature's native rig, its body's box at rest measured once (rigReady: idle at its
// first instant, getBBox), then it grows out of the middle of the burst (its middle kept on it, stretched tall, arms up,
// turning round once), hops, lands on its place (dust at its feet, sparkles over its head), squashes, wobbles and
// cheers ('happy'), then stands in its idle with its fidgets. Its feet stand at the slot's Fx, Fy, its body as big as
// fits W x H (rigPlace). Drawn by a CreatureView placed like the result cards' (CardCreatureView.Place).
using System;
using System.Collections.Generic;
using SquishSquad.Creatures.Js;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class HeroCreature
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Wire() => SquishSquad.Screens.ChestSmashView.LiveHero = _ => NativeRig.Ready();

        readonly Transform _parent;
        readonly string _key;
        NativeRig _rig;
        GameObject _holder;
        CreatureView _view;
        double[] _bb;   // cx, gy, bw, bh, top
        bool _played, _landed, _done;
        int _size;
        readonly Dictionary<string, double> _ext = new Dictionary<string, double>();

        public HeroCreature(Transform parent, string key) { _parent = parent; _key = key; _rig = NativeRig.Create(key); }
        public string Key => _key;
        public bool Failed => _rig == null;

        static double Clamp(double v, double a, double b) => Math.Max(a, Math.Min(b, v));
        static double SM(double x) { x = Clamp(x, 0, 1); return x * x * (3 - 2 * x); }
        static double OutBack(double t) { const double c1 = 1.70158, c3 = c1 + 1; return 1 + c3 * Math.Pow(t - 1, 3) + c1 * Math.Pow(t - 1, 2); }

        public void Sync(LiveCreature lc, Affine shake, float opacity, int order)
        {
            if (_rig == null) return;
            if (_bb == null)
            {
                _rig.FrameAt(0);
                var b = RigHost.RestBox(_rig.Id);
                if (b == null) return;
                _bb = new[] { b[0] + b[2] / 2, b[1] + b[3], b[2], b[3], b[1] };
                _size = Mathf.Clamp(Mathf.RoundToInt(100 * (float)Math.Min(lc.W / _bb[2], lc.H / _bb[3]) * 1.12f * UiPiece.PxPerDp), 32, 1024);
                _holder = new GameObject("hero creature " + _key);
                _holder.transform.SetParent(_parent, false);
                _view = CreatureView.Create(_holder.transform, _rig, new Rect(0, 0, _size, _size), order);
            }
            // popAt(t): grow (340 ms), hop (300), set (420)
            double t = lc.Ms, grow = 340, land = grow + 300, end = land + 420, k0 = 0.2, K = 1.12;
            double fit = Math.Min(lc.W / _bb[2], lc.H / _bb[3]), tall = _bb[3] * fit;
            Func<double, double> mid = kk => Math.Max(0, lc.Fy - lc.Cy - tall * kk / 2);
            double hop = Clamp(lc.Fy - 8 - tall * K - mid(K), 0, tall * 0.2), lift = 0, k = 1, sq = 0;
            if (!_done)
            {
                if (!_played) { _played = true; _rig.Play("surprised"); }
                if (t < grow) { double u = t / grow; k = k0 + (K - k0) * OutBack(u); lift = mid(k); sq = -0.26 * (1 - u); }
                else if (t < land) { double u = (t - grow) / 300; k = K - (K - 1) * u; lift = mid(K) * (1 - u) + hop * 4 * u * (1 - u); sq = -0.1 * Math.Sin(u * Math.PI); }
                else { double u = Clamp((t - land) / 420, 0, 1); sq = 0.32 * Math.Cos(u * Math.PI * 2.5) * (1 - u); }
                double arm = t < land ? 55 * SM(t / 160) : 55 * (1 - SM((t - land) / 250));
                _ext.Clear();
                _ext["spin"] = t < land ? 360 * SM(t / (land - 40)) : 0; _ext["armL"] = arm; _ext["armR"] = arm;
                if (t >= land && !_landed)
                {
                    _landed = true;
                    _rig.Emit("unDust", null, _bb[0], _bb[1] - 2, 0);
                    _rig.Emit("unSpark", null, _bb[0], _bb[4] + 4, 0);
                    _rig.Play("happy");
                }
                if (t >= end) { _done = true; _ext.Clear(); lift = 0; k = 1; sq = 0; }
                _rig.Ext(_ext);
            }
            // rigPlace: feet on its place, then the squash about its feet (rig units -> screen dp)
            double kk2 = fit * k, cx = _bb[0], gy = _bb[1], sqc = Clamp(sq, -0.45, 0.45), sx = 1 + sqc * 0.42, sy = 1 - sqc * 0.5;
            var m = shake * Affine.Translate(lc.Fx - cx * kk2, lc.Fy - gy * kk2 - lift) * Affine.ScaleBy(kk2, kk2);
            if (sqc != 0) m = m * Affine.Translate(cx, gy) * Affine.ScaleBy(sx, sy) * Affine.Translate(-cx, -gy);
            _view.Order = order;
            _view.SetOpacity(opacity);
            CardCreatureView.Place(_holder.transform, m, _size);
            if (!_holder.activeSelf) _holder.SetActive(true);
        }

        public void Hide() { if (_holder != null) _holder.SetActive(false); }

        public void Destroy()
        {
            _rig?.Dispose(); _rig = null;
            if (_holder != null) { if (Application.isPlaying) UnityEngine.Object.Destroy(_holder); else UnityEngine.Object.DestroyImmediate(_holder); }
        }
    }
}
