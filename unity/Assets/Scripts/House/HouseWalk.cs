// house-walk.js in C#: every creature's own gait in the Squad House, driven per frame through the rig's ext channels.
// Step(key, st, E, w, dt, spd, spin) ADDS to E (the ext channels), w = the walk's weight (0..1), spd = phase speed
// (0: frozen while he stops), spin = facing in degrees; returns the speed multiplier this frame and a particle kind (or
// null). The gaits are the page's functions; the profiles, run extras and aliases are the page's data
// (Resources/House/walk.json, tools/unity/house/export-walk.mjs). The fx timers' Math.random comes from `Rand`.
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class HouseWalk
    {
        public sealed class State { public double Rk, Ph, T, FxAt, RuAt, Ra, Rv; public bool Run, Ld; }
        public sealed class Profile
        {
            public string G = "trot", Wing, Dust, FxKind;
            public double A = 1, R = 1, FxMs;
            public double? Dl, Sm;
            public List<(string k, double[] q)> X = new List<(string, double[])>();
            public List<(string k, double v)> C = new List<(string, double)>(), M = new List<(string, double)>();
        }
        public struct Result { public double V; public string Fx; }

        delegate (double v, double? land) Gait(double p, double A, Dictionary<string, double> o, Profile P);
        sealed class GaitDef { public double R, Dl; public Gait F; }

        const double TAU = Math.PI * 2, PI = Math.PI;
        static double S(double x) => Math.Sin(x);
        static double C(double x) => Math.Cos(x);
        static double Ab(double x) => Math.Abs(x);
        static double Pos(double x) => x > 0 ? x : 0;
        static double Pw(double x, double k) => Math.Pow(Math.Abs(x), k);
        static (double air, double au, double gb) Jmp(double p, double a, double b)
        {
            double u = ((p / TAU) % 1 + 1) % 1;
            if (u > a && u < b) { double au = (u - a) / (b - a); return (S(PI * au), au, 0); }
            return (0, -1, S(PI * (((u - b + 1) % 1) / (1 - b + a))));
        }
        static readonly (double, double?) NoV = (double.NaN, null);   // the gait returns nothing (v 1, no landing)

        static readonly Dictionary<string, GaitDef> G = new Dictionary<string, GaitDef>
        {
            ["trot"] = new GaitDef { R = 1, Dl = 2, F = (p, A, o, P) => { double s = S(p); o["footL"] = 2.6 * A * Pos(s); o["footR"] = 2.6 * A * Pos(-s); o["armL"] = 12 * A * s; o["armR"] = -12 * A * s; o["tilt"] = 2.2 * A * s; o["lift"] = 2.6 * A * Ab(s); o["sq"] = 0.035 * A * Pw(C(p), 6) - 0.02 * A * Ab(s); o["htilt"] = -2.5 * A * s; o["pitch"] = 0.04; o["wag"] = 12 * S(2 * p); return NoV; } },
            ["waddle"] = new GaitDef { R = 0.72, Dl = 1, F = (p, A, o, P) => { double s = S(p); o["tilt"] = 7 * A * s; o["x"] = 1.1 * A * s; o["footL"] = 1.9 * A * Pos(s); o["footR"] = 1.9 * A * Pos(-s); o["armL"] = 16 * A + 8 * A * s; o["armR"] = 16 * A - 8 * A * s; o["lift"] = 1.3 * A * Ab(s); o["htilt"] = -4 * A * s; o["sq"] = 0.03 * A * Pw(C(p), 6); return (0.8 + 0.4 * Ab(s), null); } },
            ["hop"] = new GaitDef { R = 0.6, Dl = 2, F = (p, A, o, P) => { var j = Jmp(p, 0.2, 0.8); o["lift"] = 14 * A * j.air; o["sq"] = 0.12 * A * j.gb - 0.07 * A * j.air; o["footL"] = o["footR"] = 2 * A * j.air; o["armL"] = o["armR"] = 20 * A * j.air; o["pitch"] = j.au >= 0 ? -0.05 * C(PI * j.au) : 0.03 * j.gb; return (j.au >= 0 ? 1.5 : 0.18, j.gb); } },
            ["bounce"] = new GaitDef { R = 0.7, Dl = 1.5, F = (p, A, o, P) => { var j = Jmp(p, 0.22, 0.78); o["lift"] = 12 * A * j.air; o["sq"] = 0.2 * A * j.gb - 0.09 * A * j.air; o["armL"] = o["armR"] = 18 * A * j.air; o["tilt"] = 3 * A * S(2 * p); o["htilt"] = 2 * A * S(2 * p + 1); return (j.au >= 0 ? 1.5 : 0.22, j.gb); } },
            ["float"] = new GaitDef { R = 0.42, Dl = 4, F = (p, A, o, P) => { double s = S(p); o["lift"] = 3 + 2.5 * A * s; o["x"] = 0.8 * A * S(p + 0.8); o["tilt"] = 2.5 * A * S(p + 0.8); o["armL"] = 6 + 7 * A * S(2 * p); o["armR"] = 6 + 7 * A * S(2 * p + PI); o["pitch"] = 0.06; o["sq"] = 0.025 * A * S(2 * p); return NoV; } },
            ["flutter"] = new GaitDef { R = 0.55, Dl = 5, F = (p, A, o, P) => { double s = S(p); o["lift"] = A * (9 + 3 * S(2 * p)); o["tilt"] = 2 * A * s; o["pitch"] = 0.07; o["footL"] = o["footR"] = 0.8; if (P.Wing == "own") { o["armL"] = 8 + 5 * S(2 * p); o["armR"] = 8 + 5 * S(2 * p + PI); } else { o["armL"] = o["armR"] = 34 + 30 * S(6 * p); } o["sq"] = -0.03 * S(6 * p); return NoV; } },
            ["galumph"] = new GaitDef { R = 0.55, Dl = 1.5, F = (p, A, o, P) => { var j = Jmp(p, 0.3, 0.75); o["lift"] = 6 * A * j.air; o["sq"] = 0.14 * A * j.gb - 0.04 * A * j.air; o["pitch"] = 0.06 * j.gb - 0.08 * j.air; o["armL"] = o["armR"] = 8 + 16 * A * j.air; o["wag"] = 18 * A * S(p + 1.2); return (0.4 + 1.3 * j.air, j.gb); } },
            ["shuffle"] = new GaitDef { R = 1.35, Dl = 1, F = (p, A, o, P) => { double s = S(p); o["tilt"] = 4.5 * A * s; o["footL"] = 1.4 * A * Pos(s); o["footR"] = 1.4 * A * Pos(-s); o["lift"] = 1.2 * A * Ab(s); o["armL"] = 7 * A * s; o["armR"] = -7 * A * s; o["htilt"] = -2 * A * s; o["sq"] = 0.02 * A * Pw(C(p), 4); return NoV; } },
            ["stomp"] = new GaitDef { R = 0.62, Dl = 1, F = (p, A, o, P) => { double s = S(p), c = Pw(C(p), 8); o["footL"] = 3.4 * A * Pos(s); o["footR"] = 3.4 * A * Pos(-s); o["tilt"] = 4 * A * s; o["lift"] = 2.6 * A * Ab(s); o["sq"] = 0.07 * A * c; o["armL"] = 16 * A * s; o["armR"] = -16 * A * s; o["htilt"] = -3 * A * s; o["pitch"] = 0.03; return (double.NaN, c); } },
            ["prance"] = new GaitDef { R = 0.9, Dl = 1.5, F = (p, A, o, P) => { double s = S(p), k = Pw(s, 0.7); o["footL"] = 3.4 * A * Math.Pow(Pos(s), 0.7); o["footR"] = 3.4 * A * Math.Pow(Pos(-s), 0.7); o["lift"] = 3.6 * A * k; o["armL"] = 20 * A + 5 * A * s; o["armR"] = 20 * A - 5 * A * s; o["pitch"] = -0.05; o["htilt"] = 3 * A * S(2 * p); o["tilt"] = 1.5 * A * s; o["sq"] = 0.02 * A * Pw(C(p), 6) - 0.03 * A * k; return NoV; } },
            ["skip"] = new GaitDef { R = 0.8, Dl = 2, F = (p, A, o, P) => { double s = S(p), k = Pw(s, 0.6); o["lift"] = 6 * A * k; o["footL"] = 3 * A * Pos(s); o["footR"] = 3 * A * Pos(-s); o["armL"] = 24 * A * s; o["armR"] = -24 * A * s; o["tilt"] = 3 * A * s; o["sq"] = 0.06 * A * Pw(C(p), 8) - 0.04 * A * k; o["htilt"] = 3 * A * s; return NoV; } },
            ["scurry"] = new GaitDef { R = 1.9, Dl = 2.5, F = (p, A, o, P) => { double s = S(p); o["footL"] = 1.3 * A * Pos(s); o["footR"] = 1.3 * A * Pos(-s); o["lift"] = 1.1 * A * Ab(s); o["tilt"] = 1.5 * A * s; o["armL"] = 6 + 4 * A * s; o["armR"] = 6 - 4 * A * s; o["pitch"] = 0.06; o["sq"] = 0.03; return (1.1, null); } },
            ["plod"] = new GaitDef { R = 0.45, Dl = 0.5, F = (p, A, o, P) => { double s = S(p); o["footL"] = 1.7 * A * Pos(s); o["footR"] = 1.7 * A * Pos(-s); o["armL"] = 8 * A * -s; o["armR"] = 8 * A * s; o["tilt"] = 2.5 * A * s; o["lift"] = 0.8 * A * Ab(s); o["pitch"] = 0.03; return (0.75, null); } },
            ["crawl"] = new GaitDef { R = 0.6, Dl = 1.5, F = (p, A, o, P) => { double s = S(p); o["lift"] = 2 * A * Ab(s); o["tilt"] = 2.2 * A * s; o["x"] = 0.6 * A * s; o["sq"] = 0.04 * A * S(2 * p); o["armL"] = 10 + 12 * A * s; o["armR"] = 10 - 12 * A * s; o["footL"] = 1.2 * A * Pos(s); o["footR"] = 1.2 * A * Pos(-s); return NoV; } },
            ["zombie"] = new GaitDef { R = 0.5, Dl = 0.5, F = (p, A, o, P) => { double s = S(p); o["armL"] = 84 + 4 * S(2 * p); o["armR"] = 84 + 4 * S(2 * p + 1); o["htilt"] = 7 * A * s; o["tilt"] = 5 * A * s; o["footL"] = 1.1 * A * Pos(s); o["footR"] = 1.1 * A * Pos(-s); o["lift"] = 0.6 * A * Ab(s); o["x"] = 0.6 * A * s; return (0.7, null); } },
            ["glide"] = new GaitDef { R = 0.4, Dl = 5, F = (p, A, o, P) => { double s = S(p); o["lift"] = 3 + 1.5 * A * s; o["pitch"] = 0.05; o["armL"] = 10 + 4 * S(p + 1); o["armR"] = 10 + 4 * S(p + 1 + PI); o["tilt"] = 1.5 * A * S(p + 0.6); o["sq"] = 0.02 * A * S(2 * p); return NoV; } },
            ["roll"] = new GaitDef { R = 0.9, Dl = 1, F = (p, A, o, P) => { double s = S(p); o["tilt"] = 8 * A * s; o["turn"] = 0.18 * A * s; o["lift"] = 1.5 * A * Ab(s); o["sq"] = 0.03 * A * Pw(C(p), 4); o["armL"] = 10 * A * s; o["armR"] = -10 * A * s; o["x"] = 0.8 * A * s; return NoV; } },
            ["strut"] = new GaitDef { R = 0.85, Dl = 1, F = (p, A, o, P) => { double s = S(p); o["footL"] = 2.6 * A * Pos(s); o["footR"] = 2.6 * A * Pos(-s); o["lift"] = 1.6 * A * Ab(s); o["tilt"] = 2 * A * s; o["pitch"] = 0.02 + 0.1 * A * Pos(S(2 * p)); o["armL"] = 10 + 6 * A * S(2 * p); o["armR"] = 10 + 6 * A * S(2 * p); o["sq"] = 0.03 * A * Pw(C(p), 6); return NoV; } },
            // (snack2-house.js / fruit-house.js) the egg-shaped ones: arms paddle, a little squash
            ["eggroll"] = new GaitDef { R = 0.9, Dl = 0, F = (p, A, o, P) => { o["armL"] = 24 + 7 * A * Math.Sin(p); o["armR"] = 24 - 7 * A * Math.Sin(p); o["sq"] = 0.02 * A * Math.Sin(2 * p); return NoV; } },
        };

        readonly Dictionary<string, Profile> _prof = new Dictionary<string, Profile>();
        readonly Dictionary<string, List<(string k, double v)>> _run = new Dictionary<string, List<(string, double)>>();
        readonly Dictionary<string, string> _alias = new Dictionary<string, string>();
        static readonly Profile DEF = new Profile();
        public double DLS = 1;
        public Func<double> Rand = () => new Random().NextDouble();

        /// <summary>From Resources/House/walk.json.</summary>
        public HouseWalk(string walkJson)
        {
            var j = (JObj)HouseJson.Parse(walkJson);
            var prof = j.Obj("prof");
            foreach (var key in prof.Keys)
            {
                var o = prof.Obj(key); var P = new Profile();
                if (o.Str("g") != null) P.G = o.Str("g");
                if (o["a"] is double a) P.A = a;
                if (o["r"] is double r) P.R = r;
                if (o["dl"] is double dl) P.Dl = dl;
                if (o["sm"] is double sm) P.Sm = sm;
                P.Wing = o.Str("wing"); P.Dust = o.Str("dust");
                if (o.Arr("fx") is List<object> fx && fx.Count == 2) { P.FxKind = fx[0] as string; P.FxMs = (double)fx[1]; }
                if (o.Obj("x") is JObj x) foreach (var k in x.Keys) { var q = x.Arr(k); var d = new double[4]; for (int i = 0; i < q.Count && i < 4; i++) d[i] = q[i] is double v ? v : HouseJson.Truthy(q[i]) ? 1 : 0; if (q.Count < 2) d[1] = 0; P.X.Add((k, d)); }
                if (o.Obj("c") is JObj c) foreach (var k in c.Keys) P.C.Add((k, c.Num(k)));
                if (o.Obj("m") is JObj m) foreach (var k in m.Keys) P.M.Add((k, m.Num(k)));
                _prof[key] = P;
            }
            var run = j.Obj("run");
            foreach (var key in run.Keys) { var l = new List<(string, double)>(); var o = run.Obj(key); foreach (var k in o.Keys) l.Add((k, o.Num(k))); _run[key] = l; }
            var al = j.Obj("alias");
            foreach (var key in al.Keys) _alias[key] = al.Str(key);
        }

        string Alias(string key) => key != null && _alias.TryGetValue(key, out var a) ? a : key;

        /// <summary>HouseWalk.prof(key): the creature's profile (trot when he has none).</summary>
        public Profile Prof(string key) => _prof.TryGetValue(Alias(key) ?? "", out var p) ? p : DEF;

        /// <summary>HouseWalk.period(key): one cycle in ms (two steps, one hop).</summary>
        public double Period(string key) { var P = Prof(key); var g = G.TryGetValue(P.G, out var gg) ? gg : G["trot"]; return 1000 * TAU / (11 * g.R * P.R); }

        public Result Step(string key, State st, Dictionary<string, double> E, double w, double dt, double spd, double spin)
        {
            var r = Step0(key, st, E, w, dt, spd, spin);
            if (key == "sunny" || key == "blueby" || key == "coco") Roll(st, E, w, dt, spd, spin);
            return r;
        }

        // snack2-house.js / fruit-house.js wrap step for the egg-shaped ones: they roll from place to place (rl follows
        // the ground covered, clockwise walking right, slower toward / away from you) and rock back upright on the
        // nearest side when they stop (a spring with some overshoot)
        static void Roll(State st, Dictionary<string, double> E, double w, double dt, double spd, double spin)
        {
            double dir = Math.Sin(spin * Math.PI / 180); bool mv = spd > 0 && w > 0.3;
            if (mv) { double tv = 300 * spd * (st.Run ? 1.6 : 1) * (Math.Abs(dir) < 0.3 ? (dir < 0 ? -0.3 : 0.3) : dir); st.Rv += (tv - st.Rv) * Math.Min(1, dt * 6); st.Ra += st.Rv * dt; }
            else
            {
                double tg = Math.Floor(st.Ra / 360 + 0.5) * 360;   // (Math.round)
                st.Rv += ((tg - st.Ra) * 60 - st.Rv * 7) * Math.Min(dt, 0.05); st.Ra += st.Rv * Math.Min(dt, 0.05);
                if (Math.Abs(tg - st.Ra) < 0.3 && Math.Abs(st.Rv) < 2) { st.Ra = 0; st.Rv = 0; }
            }
            E["rl"] = (E.TryGetValue("rl", out var v) ? v : 0) + ((st.Ra % 360) + 540) % 360 - 180;
        }

        Result Step0(string key, State st, Dictionary<string, double> E, double w, double dt, double spd, double spin)
        {
            key = Alias(key);
            double rk = st.Rk = st.Rk + ((st.Run ? 1 : 0) - st.Rk) * Math.Min(1, dt * 6);
            var P = Prof(key); var g = G.TryGetValue(P.G, out var gg) ? gg : G["trot"];
            double A = P.A * (1 + 0.28 * rk);
            st.Ph = st.Ph + dt * 11 * g.R * P.R * spd * (1 + 0.6 * rk);
            if (w < 0.002) return new Result { V = 1 };
            double p = st.Ph, sr = spin * PI / 180, sd = 0.45 + 0.55 * Ab(C(sr));
            var o = new Dictionary<string, double>();
            var (mv, land) = g.F(p, A, o, P);
            if (o.TryGetValue("tilt", out var t0) && t0 != 0) o["tilt"] = t0 * sd;
            if (o.TryGetValue("x", out var x0) && x0 != 0) o["x"] = x0 * sd;
            o["tilt"] = (o.TryGetValue("tilt", out var t1) ? t1 : 0) + DLS * (P.Dl ?? g.Dl) * S(sr);
            double Get(string k) => o.TryGetValue(k, out var v) ? v : 0;
            foreach (var (k, q) in P.X) { double v = S((q[1] != 0 ? q[1] : 1) * p + q[2]); o[k] = Get(k) + q[0] * (q[3] != 0 ? Ab(v) : v); }
            foreach (var (k, v) in P.C) o[k] = Get(k) + v;
            foreach (var (k, v) in P.M) if (o.ContainsKey(k)) o[k] *= v;
            if (rk > 0.01)
            {
                void Add(string k, double v) => o[k] = Get(k) + v * rk;
                Add("tilt", 3.5 * DLS * S(sr)); Add("pitch", -0.06); Add("open", 0.32); Add("mw", -0.25); Add("hap", 0.7); Add("smile", 0.3); Add("wide", 0.25); Add("earL", 10); Add("earR", -10);
                if (_run.TryGetValue(key, out var RX)) foreach (var (k, v) in RX) Add(k, v);
            }
            foreach (var kv in o) E[kv.Key] = (E.TryGetValue(kv.Key, out var e) ? e : 0) + kv.Value * w;
            string fx = null; double now = st.T = st.T + dt * 1000;
            if (w > 0.6 && spd != 0)
            {
                if (P.FxKind != null && now > st.FxAt) { st.FxAt = now + P.FxMs * (0.7 + Rand() * 0.6); fx = P.FxKind; }
                if (P.Dust != null && land != null) { bool ld = land.Value > 0.9; if (ld && !st.Ld) fx = P.Dust; st.Ld = ld; }
                if (rk > 0.5 && fx == null && now > st.RuAt) { st.RuAt = now + 260; fx = P.Dust; }
            }
            return new Result { V = double.IsNaN(mv) || mv == 0 ? 1 : mv, Fx = fx };
        }
    }
}
