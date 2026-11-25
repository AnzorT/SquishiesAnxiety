// The chest unlock's creature coming out of the BAM (tools/chest/host.html popAt / rigPlace), without UnityEngine:
// Creatures/HeroCreature.cs drives the native rig with it in the app, the tests (tools/unity/shop-test `unlockframes`)
// off Unity. From the body's box at rest (host.html rigReady: idle at its first instant, getBBox) it grows out of the
// middle of the burst (its middle kept on it, stretched tall, arms up, turning round once), hops, lands on its place
// (dust at its feet, sparkles over its head), squashes, wobbles and cheers ('happy'), then stands in its idle. Its feet
// stand at the slot's Fx, Fy, its body as big as fits W x H.
using System;
using System.Collections.Generic;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Creatures
{
    /// <summary>What popAt asks of the creature's rig.</summary>
    public interface IHeroRig
    {
        void Play(string move);
        void Ext(IDictionary<string, double> e);
        void Emit(string kind, double x, double y);
    }

    public sealed class HeroPop
    {
        readonly double[] _bb;   // cx, gy (its feet), bw, bh, top: the body's box at rest, rig units
        bool _played, _landed, _done;
        readonly Dictionary<string, double> _ext = new Dictionary<string, double>();

        /// <summary>`rest`: the body's box at rest (x, y, w, h: RigHost.RestBox).</summary>
        public HeroPop(double[] rest) { _bb = new[] { rest[0] + rest[2] / 2, rest[1] + rest[3], rest[2], rest[3], rest[1] }; }

        /// <summary>The rig's scale that fits its body in the slot's W x H.</summary>
        public double Fit(LiveCreature lc) => Math.Min(lc.W / _bb[2], lc.H / _bb[3]);

        static double Clamp(double v, double a, double b) => Math.Max(a, Math.Min(b, v));
        static double SM(double x) { x = Clamp(x, 0, 1); return x * x * (3 - 2 * x); }
        static double OutBack(double t) { const double c1 = 1.70158, c3 = c1 + 1; return 1 + c3 * Math.Pow(t - 1, 3) + c1 * Math.Pow(t - 1, 2); }

        /// <summary>popAt(lc.Ms): moves the rig (its moves, arms, spin, the landing's dust and sparkles) and returns where
        /// it's drawn: rig units -> the slot's screen dp (before the screen's shake).</summary>
        public Affine Step(LiveCreature lc, IHeroRig rig)
        {
            // popAt(t): grow (340 ms), hop (300), set (420)
            double t = lc.Ms, grow = 340, land = grow + 300, end = land + 420, k0 = 0.2, K = 1.12;
            double fit = Fit(lc), tall = _bb[3] * fit;
            Func<double, double> mid = kk => Math.Max(0, lc.Fy - lc.Cy - tall * kk / 2);
            double hop = Clamp(lc.Fy - 8 - tall * K - mid(K), 0, tall * 0.2), lift = 0, k = 1, sq = 0;
            if (!_done)
            {
                if (!_played) { _played = true; rig.Play("surprised"); }
                if (t < grow) { double u = t / grow; k = k0 + (K - k0) * OutBack(u); lift = mid(k); sq = -0.26 * (1 - u); }
                else if (t < land) { double u = (t - grow) / 300; k = K - (K - 1) * u; lift = mid(K) * (1 - u) + hop * 4 * u * (1 - u); sq = -0.1 * Math.Sin(u * Math.PI); }
                else { double u = Clamp((t - land) / 420, 0, 1); sq = 0.32 * Math.Cos(u * Math.PI * 2.5) * (1 - u); }
                double arm = t < land ? 55 * SM(t / 160) : 55 * (1 - SM((t - land) / 250));
                _ext.Clear();
                _ext["spin"] = t < land ? 360 * SM(t / (land - 40)) : 0; _ext["armL"] = arm; _ext["armR"] = arm;
                if (t >= land && !_landed)
                {
                    _landed = true;
                    rig.Emit("unDust", _bb[0], _bb[1] - 2);
                    rig.Emit("unSpark", _bb[0], _bb[4] + 4);
                    rig.Play("happy");
                }
                if (t >= end) { _done = true; _ext.Clear(); lift = 0; k = 1; sq = 0; }
                rig.Ext(_ext);
            }
            // rigPlace: feet on its place, then the squash about its feet (rig units -> screen dp)
            double kk2 = fit * k, cx = _bb[0], gy = _bb[1], sqc = Clamp(sq, -0.45, 0.45), sx = 1 + sqc * 0.42, sy = 1 - sqc * 0.5;
            var m = Affine.Translate(lc.Fx - cx * kk2, lc.Fy - gy * kk2 - lift) * Affine.ScaleBy(kk2, kk2);
            if (sqc != 0) m = m * Affine.Translate(cx, gy) * Affine.ScaleBy(sx, sy) * Affine.Translate(-cx, -gy);
            return m;
        }
    }
}
