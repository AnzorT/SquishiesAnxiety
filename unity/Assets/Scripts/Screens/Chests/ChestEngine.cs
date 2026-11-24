// Chest Smash v2's engine (chest-models.js Chest and Stage), ported line by line: the chest's warp (dents, lean, sag,
// soft wobble), its spring motion (hop, wobble, squash, pop), hits (dents, cracks, holes punched out as flying chunks,
// hinged parts swinging loose and tearing off), the knock-out (the chest breaking into shards, dust, debris, sparks,
// rings, the loot bursting out), the first-tap upgrade (the charge, its beams, motes and rings, the poof into the next
// size), the glow and rays, and every particle. It runs on the Ticker's frames (dt = the frame's time, at most 34 ms)
// and rolls its random numbers from `Random` in the order the page's code rolls Math.random, so on the same clock and
// the same generator (tools/unity/rig/virtual-clock.js) it plays the same smash.
// Drawing: each frame is recorded through Canvas2D as SVG (the screen's dp). The chest's layer (its parts, dents,
// cracks, the flash) is an SVG group; what the page composites on its canvases is done with groups: 'source-atop' on the
// layer is clipped to the chest's hull, 'destination-out' holes are a mask, a chunk or shard is the layer at that moment
// clipped to its polygon (the dark side: a colour matrix), covered() samples the hull minus the holes.
// The page's own changes to it (host.html): the chest's size (fitStage, Resize) and its HP by rarity (rarityHp, TierHp).
// Not as the page: 'lighter' particles blend as normal ones; no sounds.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Vector;

namespace SquishSquad.Screens
{
    /// <summary>virtual-clock.js's Math.random (xorshift32, seed 0x2f6b9a1): the same numbers the page rolls.</summary>
    public sealed class XorShift
    {
        uint _s;
        public XorShift(uint seed = 0x2f6b9a1) { _s = seed; }
        public double Next() { _s ^= _s << 13; _s ^= _s >> 17; _s ^= _s << 5; return _s / 4294967296.0; }
    }

    public sealed class ChestEngine
    {
        const double TAU = Math.PI * 2, LW = 300, LH = 290, OX = 150, OY = 255;
        static readonly double[] UPD = { 0, 1.1, 1.45, 1.85, 2.6 }, UPH = { 0, 1.0, 1.2, 1.5, 2.3 }, DK = { 0, 0.62, 0.74, 0.85, 0.94 };
        static string[] RB => ChestModels.RB;

        public Func<double> Random = new XorShift().Next;
        double Rnd(double a, double b) => a + Random() * (b - a);
        T Pick<T>(IList<T> a) => a[(int)Math.Floor(Random() * a.Count)];
        static double Clamp(double v, double a, double b) => v < a ? a : v > b ? b : v;

        /// <summary>The page's events: loaded, hp, step, upgradeDone, koStart, ko, charge.</summary>
        public Action<string, Dictionary<string, object>> On;

        // ---- the chest ---------------------------------------------------------------------------------------------------
        public sealed class Dent { public double X, Y, R, Rr, R2x, K, Nx, Ny, P; }
        public sealed class Chest
        {
            public ChestModel M;
            public double D, Lean, Seed;
            public List<Dent> Dents = new List<Dent>();
            public List<List<List<double[]>>> Cracks = new List<List<List<double[]>>>();   // genCrack() results (polylines), the last 24
            public List<double[][]> Holes = new List<double[][]>();
            public HashSet<string> Torn = new HashSet<string>();
            public Dictionary<string, double> Ang = new Dictionary<string, double>(), Av = new Dictionary<string, double>();
            public bool Gone;
            public void Warp(double x, double y, out double ox, out double oy)
            {
                var M2 = M.M; double d = D, X = x, Y = y;
                if (d > 0)
                {
                    double h = Clamp(-y / M.H, 0, 1.4); X += Lean * d * M2.Lean * h * h; Y += d * M2.Sag * h;
                    if (M2.Soft != 0) { double s = Seed, a = M2.Soft * d * 0.6; X += a * (Math.Sin(x * 0.19 + s) + Math.Sin(y * 0.23 + s * 1.7)); Y += a * (Math.Sin(y * 0.17 + s * 0.6) + Math.Sin(x * 0.21 + s * 2.3)); }
                    foreach (var q in Dents) { double dx = x - q.X, dy = y - q.Y, r2 = dx * dx + dy * dy; if (r2 > q.R2x) continue; double e = Math.Exp(-r2 / q.Rr); X += q.Nx * q.K * e - dx * q.P * e; Y += q.Ny * q.K * e - dy * q.P * e; }
                }
                ox = X; oy = Y;
            }
        }

        public sealed class P
        {
            public string Type, C, K;
            public double T, Life = 1.6, G = 1500, Drag = 0.4, Bounce = 0.35, R, Vr, Gz, A = 1;
            public double X, Y, Vx, Vy, S, W, H, R0, R1, Lw, Vf, Fl, Ph, Sx, Sy, Tx, Ty, Sw;
            public double[][] V;
        }
        public sealed class Spr
        {
            public string Img;     // the snapshot's id (the frame's defs)
            public double Wd, Hd, Cx, Cy;
            public double X, Y, Vx, Vy, Vr, Vf, R, Fp, Gz, Rest, T, Seed;
            public ChestMat M;
        }

        sealed class Mo { public double X, Vx, Y, Vy, R, Vr, Q, Vq, Ps = 1, Vps; }
        sealed class Charge { public int I; public double K, Rate, Acc, Ra; public string C; public bool Rb, Fin; public List<(double a, double w, double l, double at, double f)> Beams; }

        public double Time, Ts = 1;
        readonly List<(double t, Action fn)> _q = new List<(double, Action)>();
        public readonly List<Spr> Sprs = new List<Spr>();
        public readonly List<P> Pt = new List<P>();
        public Chest Ch;
        public string Group = "snack";
        public int Tier;
        public double Hp;
        readonly Mo _mo = new Mo();
        double _shake, _flash, _sflash, _stop, _dark, _lift, _burst, _burstR = 1, _pillar, _idleT, _lastB;
        int _burstI;
        string _sfc = "#ffffff";
        (double k, double rays, string c, bool rb) _glow;
        public object Open;
        Charge _charge;
        public bool Busy;
        int? _upTo;

        // the canvas: its CSS size, the ground line and the scale
        public double Wc, Hc, Gx, Gy, S;
        readonly double _ground, _top;

        public ChestEngine(double w, double h, double ground = 0.73, double top = 178)
        {
            _ground = ground; _top = top;
            Resize(w, h);
        }

        // The chest's size (host.html fitStage, 2026-11-16, the user: the chests "are too small"; BIG 2026-11-21: "make
        // the chest 50% bigger than what it is now"). Portrait keeps the engine's own sizing (from y `top` down to
        // `ground` of the height). Sideways the chest stands FOOT over the screen's bottom (just over the hint, on the
        // room's rug) and its tallest model (a Rainbow, ~TALL units) would reach the HUD's bottom (`hud`, +4); that fit
        // times BIG, so the tallest chests reach up behind the name plate and the HP bar.
        const double TALL = 225, FOOT = 50, BIG = 1.5;
        public void Resize(double w, double h, double hud = 0, double insetBottom = 0)
        {
            Wc = w; Hc = h;
            Gx = w / 2;
            if (w > h)
            {
                double top = hud > 0 ? hud + 4 : 104;
                Gy = h - insetBottom - FOOT;
                S = Math.Max(0.6, Math.Min(w / 290, BIG * (Gy - top) / TALL));
            }
            else
            {
                Gy = h * _ground;
                S = Math.Max(0.6, Math.Min(w / 290, (Gy - _top) / 238));
            }
            _layerKey = null;
        }

        /// <summary>THE CHEST HP by rarity (host.html rarityHp; the user, 2026-11-17: one tap = 1 HP, the same in every
        /// group), in place of the design's own (6 to 14), or null for the design's. With more HP than the design gave
        /// it, a chest punches a hole on a share of the hits that shrinks to match (Chunk), so it still ends up with
        /// about the design's holes.</summary>
        public double[] TierHp;

        void At(double t, Action fn) => _q.Add((t, fn));

        void Add(P o) { o.Gz = Rnd(-4, 16); Pt.Add(o); if (Pt.Count > 520) Pt.RemoveRange(0, Pt.Count - 520); }
        static P Np(string type) => new P { Type = type };

        public void Load(string group, int tier, bool pop)
        {
            Group = group; Tier = tier;
            var m = ChestModels.Model(group, tier, Random);
            if (m.Hp0 == 0) m.Hp0 = m.Hp;
            m.Hp = TierHp != null ? TierHp[Math.Max(0, Math.Min(4, tier))] : m.Hp0;
            Ch = new Chest { M = m };
            Ch.Lean = Random() < 0.5 ? -1 : 1;
            Ch.Seed = Random() * 100;
            Hp = m.Hp; Open = null; _charge = null;
            _mo.X = _mo.Vx = _mo.Y = _mo.Vy = _mo.R = _mo.Vr = _mo.Q = _mo.Vq = 0;
            if (pop) { _mo.Ps = 0.5; _mo.Vps = 4; } else { _mo.Ps = 1; _mo.Vps = 0; }
            _layerKey = null;
            On?.Invoke("loaded", new Dictionary<string, object> { ["tier"] = tier, ["hp"] = Hp, ["max"] = m.Hp, ["name"] = m.Name });
        }

        public void Reset(string group, int tier)
        {
            _q.Clear(); Sprs.Clear(); Pt.Clear(); Busy = false; _upTo = null; _glow.k = 0; _glow.rays = 0; _burst = 0; _pillar = 0;
            Load(group ?? Group, tier, true);
            var m = Ch.M;
            for (int i = 0; i < 10; i++)
            {
                double sd = i % 2 == 1 ? 1 : -1;
                var p = Np("dust"); p.X = sd * Rnd(10, m.W * 0.5); p.Y = Rnd(-4, 4); p.Vx = sd * Rnd(60, 160); p.Vy = -Rnd(10, 50); p.S = Rnd(12, 22); p.C = m.M.Dust; p.A = 0.75; p.Life = Rnd(0.6, 0.9); p.G = -20; p.Drag = 3;
                Add(p);
            }
        }

        (double, double) Tw(double x, double y)
        {
            var mo = _mo; double q = Clamp(mo.Q, -0.3, 0.4), sx = mo.Ps * (1 + q * 0.5), sy = mo.Ps * (1 - q), c = Math.Cos(mo.R), s = Math.Sin(mo.R);
            x *= sx; y *= sy; return (x * c - y * s + mo.X, x * s + y * c + mo.Y);
        }

        (double, double) FromClient(double cx, double cy)
        {
            var mo = _mo; double x = (cx - Gx) / S - mo.X, y = (cy - Gy) / S - mo.Y, c = Math.Cos(-mo.R), s = Math.Sin(-mo.R);
            return ((x * c - y * s) / mo.Ps, (x * s + y * c) / mo.Ps);
        }

        public void HitAt(double cx, double cy, double P)
        {
            if (Ch == null) return;
            var (x, y) = FromClient(cx, cy);
            var bb = Ch.M.Bb;
            Hit(Clamp(x, bb.x0 + 12, bb.x1 - 14), Clamp(y, bb.y0 + 14, bb.y1 - 10), P);
        }

        public void Hit(double x, double y, double P)
        {
            var c = Ch;
            if (c == null || Busy || Open != null || c.Gone || Hp <= 0) return;
            if (P == 0) P = 1;
            var m = c.M; var M = m.M; var mo = _mo;
            Hp--; c.D = 1 - Hp / m.Hp; double d = c.D; bool final = Hp == 0;
            double ccx = (m.Bb.x0 + m.Bb.x1) / 2, ccy = -m.H * 0.5, nx = ccx - x, ny = ccy - y, nl = ChestModels.Hyp(nx, ny); if (nl == 0) nl = 1; nx /= nl; ny /= nl;
            double r = Rnd(16, 26) * Math.Sqrt(m.Sc);
            c.Dents.Add(new Dent { X = x, Y = y, R = r, Rr = r * r, R2x = r * r * 4.6, K = M.DentK * Rnd(0.7, 1.2) * P, Nx = nx, Ny = ny, P = 0.12 });
            if (c.Dents.Count > 18) c.Dents.RemoveAt(0);
            if (d > 0.1)
            {
                double len = Rnd(16, 30) * Math.Sqrt(m.Sc) * (0.7 + d);
                c.Cracks.Add(GenCrack(x, y, len, M.Crack));
                if (d > 0.55) { double ax = x + Rnd(-14, 14), ay = y + Rnd(-14, 14), l2 = Rnd(14, 26); c.Cracks.Add(GenCrack(ax, ay, l2, M.Crack)); }
                if (c.Cracks.Count > 24) c.Cracks.RemoveRange(0, c.Cracks.Count - 24);
            }
            foreach (var p in m.Parts) if (p.Hang != null && !c.Torn.Contains(p.Id)) c.Av[p.Id] = (c.Av.TryGetValue(p.Id, out var v) ? v : 0) + (x < p.Hang[0] ? 1 : -1) * Rnd(2.5, 5) * P;
            if (!final)
            {
                var fl = _flash; _flash = 0; RenderLayer(true); _flash = fl;
                if (d >= M.HoleFrom && Random() < M.HoleP) Chunk(x, y, P);
                foreach (var p in m.Parts) if (p.Tear != null && !c.Torn.Contains(p.Id) && d >= p.Tear - 1e-6) TearPart(p, x, y, P, false);
            }
            double side = x > ccx ? -1 : 1, ms = M.Mass * Math.Sqrt(m.Sc);
            mo.Vx += side * 240 * P / ms; mo.Vr += side * 1.1 * P / ms; mo.Vq += 4.5 * P / ms; if (M.Mass < 1.2) mo.Vy -= 170 * P;
            _stop = final ? 0 : 0.05; _shake = Math.Max(_shake, 3 + 2.5 * P * M.Mass); _flash = 0.9;
            var (wx, wy) = Tw(x, y);
            { var p = Np("ring"); p.X = wx; p.Y = wy; p.R0 = 8; p.R1 = 34 + 16 * P; p.C = "#ffffff"; p.Life = 0.3; p.G = 0; p.Bounce = -1; Add(p); }
            for (int i = 0; i < 3; i++) { var p = Np("dust"); p.X = wx + Rnd(-8, 8); p.Y = wy + Rnd(-8, 8); p.Vx = Rnd(-60, 60) - nx * 40; p.Vy = Rnd(-60, 10); p.S = Rnd(10, 18); p.C = M.Dust; p.A = 0.7; p.Life = Rnd(0.6, 0.9); p.G = 0; p.Drag = 3; Add(p); }
            Debris(wx, wy, (int)Math.Round(5 + 4 * P), P, Math.Atan2(-ny, -nx));
            if (M.Spark != null) for (int i = 0; i < 9; i++) Spark(wx, wy, 250, 520, 0.25, 0.45, 120, M.Spark);
            On?.Invoke("hp", new Dictionary<string, object> { ["hp"] = Hp, ["max"] = m.Hp });
            if (final) Ko(x, y);
        }


        void Spark(double x, double y, double v0, double v1, double l0, double l1, double up, string sp)
        {
            double a = Rnd(0, TAU), v = Rnd(v0, v1);
            var p = Np("spark"); p.X = x; p.Y = y; p.Vx = Math.Cos(a) * v; p.Vy = Math.Sin(a) * v - up; p.Life = Rnd(l0, l1); p.G = 900; p.C = sp == "rb" ? Pick(RB) : sp; p.Bounce = -1;
            Add(p);
        }

        void Debris(double x, double y, int n, double P, double? dirA)
        {
            var M = Ch.M.M;
            for (int i = 0; i < n; i++)
            {
                double a = dirA != null ? dirA.Value + Rnd(-1.2, 1.2) : Rnd(0, TAU), v = Rnd(120, 300) * P, vx = Math.Cos(a) * v, vy = Math.Sin(a) * v - Rnd(140, 280) * P;
                string col = Pick(M.Chips); double rr = Random();
                string kind = rr < 0.4 ? M.Deb : rr < 0.62 && M.Deb2 != null ? M.Deb2 : rr < 0.5 ? M.Deb : "chip";
                var p = Np(kind);
                p.X = x; p.Y = y;
                if (kind == "drop") { p.Vx = vx; p.Vy = vy; p.C = M.DropC ?? col; p.S = Rnd(3, 5.5); p.Bounce = 0.08; p.Life = Rnd(1.1, 1.7); Add(p); continue; }
                if (kind == "bubble") { p.Vx = vx * 0.35; p.Vy = -Rnd(40, 130); p.S = Rnd(3, 7.5); p.G = -70; p.Drag = 1.4; p.Bounce = -1; p.Life = Rnd(1, 1.8); p.Ph = Rnd(0, TAU); p.Fl = 70; Add(p); continue; }
                if (kind == "fluff") { p.Vx = vx * 0.6; p.Vy = vy * 0.6; p.C = col; p.S = Rnd(4, 8); p.G = 320; p.Drag = 2; p.Fl = 130; p.Ph = Rnd(0, TAU); p.Bounce = 0.05; p.Life = Rnd(1.6, 2.4); Add(p); continue; }
                p.Vx = vx; p.Vy = vy;
                if (kind == "shred") { p.C = col; p.W = Rnd(5, 11); p.H = Rnd(4, 8); p.Vr = Rnd(-8, 8); p.Vf = Rnd(6, 14); p.G = 650; p.Drag = 1.6; p.Fl = 260; p.Ph = Rnd(0, TAU); p.Bounce = 0.1; p.Life = Rnd(2.2, 3); }
                else if (kind == "splinter") { p.C = col; p.W = Rnd(10, 18); p.H = Rnd(2, 3.2); p.R = Rnd(0, TAU); p.Vr = Rnd(-14, 14); p.Bounce = 0.3; p.Life = Rnd(2, 2.8); }
                else if (kind == "bolt") { p.S = Rnd(2.5, 4); p.Bounce = 0.5; p.Life = Rnd(2, 2.8); }
                else if (kind == "gem") { p.C = col; p.S = Rnd(5, 9); p.R = Rnd(0, TAU); p.Vr = Rnd(-10, 10); p.Bounce = 0.4; p.Life = Rnd(2, 2.8); }
                else
                {
                    p.Type = "chip";
                    double s = Rnd(3, 7); int nv = 4 + (int)(Random() * 2);
                    var v2 = new double[nv][];
                    for (int k = 0; k < nv; k++) { double aa = (double)k / nv * TAU + Rnd(-0.3, 0.3), r2 = s * Rnd(0.6, 1); v2[k] = new[] { Math.Cos(aa) * r2, Math.Sin(aa) * r2 }; }
                    p.C = col; p.V = v2; p.R = Rnd(0, TAU); p.Vr = Rnd(-12, 12); p.Bounce = 0.35; p.Life = Rnd(2, 2.8);
                }
                Add(p);
            }
        }

        List<List<double[]>> GenCrack(double x, double y, double len, string style)
        {
            var outp = new List<List<double[]>>();
            double j = style == "scratch" ? 0.16 : 0.55;
            void Walk(double wx, double wy, double a, double L, int depth)
            {
                var pts = new List<double[]> { new[] { wx, wy } };
                int n = Math.Max(2, (int)Math.Round(L / 6));
                for (int i = 0; i < n; i++)
                {
                    a += Rnd(-j, j); wx += Math.Cos(a) * 6; wy += Math.Sin(a) * 6; pts.Add(new[] { wx, wy });
                    if (depth < 2 && Random() < 0.18) { double na = a + Rnd(0.6, 1.1) * (Random() < 0.5 ? -1 : 1); Walk(wx, wy, na, L * 0.45, depth + 1); }
                }
                outp.Add(pts);
            }
            int k = style == "scratch" ? 2 : style == "rip" ? 2 : 3;
            double a0 = Rnd(0, TAU);
            for (int i = 0; i < k; i++) { double aa = a0 + i * TAU / k + Rnd(-0.4, 0.4), ll = len * Rnd(0.6, 1); Walk(x, y, aa, ll, 0); }
            return outp;
        }

        double[][] HolePoly(double x, double y, double R, string jag)
        {
            var pts = new List<double[]>();
            if (jag == "splinter")
            {
                int n = 18;
                for (int i = 0; i < n; i++) { double a = (double)i / n * TAU, ca = Math.Cos(a), sa = Math.Sin(a), k = Rnd(0.75, 1); if (Math.Abs(ca) > 0.7) k *= i % 2 == 1 ? 1.4 : 0.78; pts.Add(new[] { x + ca * R * 1.5 * k, y + sa * R * 0.55 * k }); }
                return pts.ToArray();
            }
            int nn = jag == "tear" ? 22 : jag == "ragged" ? 14 : jag == "petal" ? 10 : jag == "shard" ? 7 : 12;
            for (int i = 0; i < nn; i++)
            {
                double a = (double)i / nn * TAU + Rnd(-0.1, 0.1), k = Rnd(0.72, 1);
                if (jag == "tear") k *= i % 2 == 1 ? 0.7 : 1.06; else if (jag == "petal") k *= i % 2 == 1 ? 0.55 : 1.12; else if (jag == "shard") k = Rnd(0.6, 1.15);
                pts.Add(new[] { x + Math.Cos(a) * R * k, y + Math.Sin(a) * R * k });
            }
            return pts.ToArray();
        }

        sealed class KoPoly { public List<double[]> Pts; public double? Vx, Up, Vr, Vf, Pow; }

        List<KoPoly> KoPolys(ChestModel m)
        {
            var bb = m.Bb; double cx = (bb.x0 + bb.x1) / 2, cy = (bb.y0 + bb.y1) / 2, BIG = 420;
            double J = m.Mat == "paper" ? 5 : m.Mat == "card" ? 4 : m.Mat == "wood" ? 3 : m.Mat == "metal" ? 2.5 : m.Mat == "candy" ? 2 : 3;
            var outp = new List<KoPoly>();
            if (m.Ko == "halves")
            {
                var seam = new List<double[]>();
                for (double y = bb.y0 - 40; y <= 40; y += 6) seam.Add(new[] { cx - 4 + Rnd(-J, J) + (seam.Count % 2 == 1 ? 3.5 : -3.5), y });
                var a = new List<double[]> { new[] { -BIG, bb.y0 - 40 } }; a.AddRange(seam); a.Add(new[] { -BIG, 40.0 });
                outp.Add(new KoPoly { Pts = a, Vx = -60, Up = 0.28, Vr = -Rnd(2.4, 3.4), Vf = Rnd(-1.2, 1.2), Pow = 0.3 });
                var b = new List<double[]> { new[] { BIG, bb.y0 - 40 } }; b.AddRange(seam); b.Add(new[] { BIG, 40.0 });
                outp.Add(new KoPoly { Pts = b, Vx = 60, Up = 0.28, Vr = Rnd(2.4, 3.4), Vf = Rnd(-1.2, 1.2), Pow = 0.3 });
            }
            else if (m.Ko == "planks")
            {
                foreach (var row in m.Rows)
                {
                    double y0 = row[0], y1 = row[1], sx = cx + Rnd(-0.28, 0.28) * m.W;
                    var cut = new List<double[]>();
                    for (double y = y0; y <= y1; y += 5) cut.Add(new[] { sx + Rnd(-4, 4) + (cut.Count % 2 == 1 ? 2.5 : -2.5), y });
                    var a = new List<double[]> { new[] { -BIG, y0 } }; a.AddRange(cut); a.Add(new[] { -BIG, y1 });
                    var b = new List<double[]> { new[] { BIG, y0 } }; b.AddRange(cut); b.Add(new[] { BIG, y1 });
                    outp.Add(new KoPoly { Pts = a }); outp.Add(new KoPoly { Pts = b });
                }
            }
            else
            {
                int n = m.PieN > 0 ? (int)m.PieN : 7; double R = 360; bool ring = m.Ring; double a0 = Rnd(0, TAU);
                var edges = new List<(List<double[]> pts, int ri, double a, double rr)>();
                for (int i = 0; i < n; i++)
                {
                    double a = a0 + (i + Rnd(-0.22, 0.22)) / n * TAU, ca = Math.Cos(a), sa = Math.Sin(a), rr = Math.Min(m.W, m.H) * 0.27 * Rnd(0.8, 1.2);
                    var pts = new List<double[]> { new[] { cx, cy } }; int ri = 0;
                    for (double r = 10; r < R; r += 10)
                    {
                        if (ring && ri == 0 && r >= rr) { pts.Add(new[] { cx + ca * rr, cy + sa * rr }); ri = pts.Count - 1; }
                        double jj = r < 150 ? Rnd(-J, J) * 1.3 : 0;
                        pts.Add(new[] { cx + ca * r - sa * jj, cy + sa * r + ca * jj });
                    }
                    pts.Add(new[] { cx + ca * R, cy + sa * R });
                    edges.Add((pts, ri, a, rr));
                }
                for (int i = 0; i < n; i++)
                {
                    var A = edges[i]; var B = edges[(i + 1) % n];
                    if (!ring) { var l = new List<double[]>(A.pts); var rb = new List<double[]>(B.pts); rb.Reverse(); l.AddRange(rb); outp.Add(new KoPoly { Pts = l }); continue; }
                    double aB = B.a; if (aB < A.a) aB += TAU;
                    var arc = new List<double[]>();
                    for (int k = 1; k < 6; k++) { double t = k / 6.0, an = A.a + (aB - A.a) * t, r = A.rr + (B.rr - A.rr) * t + Rnd(-J, J); arc.Add(new[] { cx + Math.Cos(an) * r, cy + Math.Sin(an) * r }); }
                    var inner = A.pts.Take(A.ri + 1).ToList(); inner.AddRange(arc); var bi = B.pts.Take(B.ri + 1).ToList(); bi.Reverse(); inner.AddRange(bi);
                    outp.Add(new KoPoly { Pts = inner, Pow = 0.8 });
                    var outer = A.pts.Skip(A.ri).ToList(); var bo = B.pts.Skip(B.ri).ToList(); bo.Reverse(); outer.AddRange(bo); var ar = new List<double[]>(arc); ar.Reverse(); outer.AddRange(ar);
                    outp.Add(new KoPoly { Pts = outer });
                }
            }
            return outp;
        }

        // ---- the layer and its snapshots ---------------------------------------------------------------------------------
        public sealed class Snap { public string Id, Markup; }
        public readonly Dictionary<string, Snap> Snaps = new Dictionary<string, Snap>();
        int _snapN;
        string _layer;          // the layer's SVG (chest coordinates), as renderLayer last drew it
        string _layerKey;
        bool _cav;

        /// <summary>covered(): enough of the polygon (chest coordinates) is chest (the hull, the holes left out).</summary>
        bool Covered(List<double[]> pts, double x0, double y0, double x1, double y1)
        {
            int w = Math.Max(1, (int)Math.Ceiling(x1 - x0)), h = Math.Max(1, (int)Math.Ceiling(y1 - y0)), n = 0;
            var hull = Ch.M.HullSp.Select(s => Warped(s.p)).ToList();
            var holes = Ch.Holes.Select(hp => hp.SelectMany(p => { Ch.Warp(p[0], p[1], out var a, out var b); return new[] { a, b }; }).ToArray()).ToList();
            var poly = pts.SelectMany(p => p).ToArray();
            int step = Math.Max(1, (int)Math.Sqrt(w * h / 6000.0));
            for (int yy = 0; yy < h; yy += step)
                for (int xx = 0; xx < w; xx += step)
                {
                    double px = x0 + xx + 0.5, py = y0 + yy + 0.5;
                    if (!Inside(poly, px, py)) continue;
                    if (!hull.Any(hp => Inside(hp, px, py))) continue;
                    if (holes.Any(hp => Inside(hp, px, py))) continue;
                    n += step * step;
                }
            return n >= Math.Max(3, w * h * 0.03);
        }

        double[] Warped(double[] p) { var o = new double[p.Length]; for (int i = 0; i < p.Length; i += 2) Ch.Warp(p[i], p[i + 1], out o[i], out o[i + 1]); return o; }

        static bool Inside(double[] poly, double x, double y)
        {
            bool c = false;
            for (int i = 0, j = poly.Length - 2; i < poly.Length; j = i, i += 2)
                if ((poly[i + 1] > y) != (poly[j + 1] > y) && x < (poly[j] - poly[i]) * (y - poly[i + 1]) / (poly[j + 1] - poly[i + 1]) + poly[i]) c = !c;
            return c;
        }

        /// <summary>crop(): the source (the layer, or `src`) clipped to the polygon: a snapshot, its box and middle.</summary>
        (Snap img, Snap dk, double w, double h, double cx, double cy)? Crop(List<double[]> pts, bool check, string src = null)
        {
            double x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
            foreach (var p in pts) { x0 = Math.Min(x0, p[0]); x1 = Math.Max(x1, p[0]); y0 = Math.Min(y0, p[1]); y1 = Math.Max(y1, p[1]); }
            x0 = Math.Max(x0 - 2, -OX); y0 = Math.Max(y0 - 2, -OY); x1 = Math.Min(x1 + 2, LW - OX); y1 = Math.Min(y1 + 2, LH - OY);
            if (x1 - x0 < 2 || y1 - y0 < 2) return null;
            if (check && !Covered(pts, x0, y0, x1, y1)) return null;
            double cx = (x0 + x1) / 2, cy = (y0 + y1) / 2;
            var d = new StringBuilder();
            for (int i = 0; i < pts.Count; i++) d.Append(i == 0 ? 'M' : 'L').Append(F(pts[i][0] - cx)).Append(' ').Append(F(pts[i][1] - cy)).Append(' ');
            d.Append('Z');
            string id = "snap" + (_snapN++);
            // the snapshot in the sprite's own units (its middle at 0, 0), clipped to the polygon and to its box
            var body = $"<clipPath id=\"{id}c\"><path d=\"{d}\"/></clipPath><clipPath id=\"{id}b\"><rect x=\"{F(x0 - cx)}\" y=\"{F(y0 - cy)}\" width=\"{F(x1 - x0)}\" height=\"{F(y1 - y0)}\"/></clipPath>"
                + $"<g clip-path=\"url(#{id}b)\"><g clip-path=\"url(#{id}c)\"><g transform=\"translate({F(-cx)} {F(-cy)})\">{src ?? _layer}</g></g></g>";
            var img = new Snap { Id = id, Markup = body };
            // the dark side: 42 % of rgba(30, 12, 0) over it ('source-atop'), as a colour matrix
            var dk = new Snap { Id = id + "d", Markup = $"<filter id=\"{id}f\" x=\"-10%\" y=\"-10%\" width=\"120%\" height=\"120%\"><feColorMatrix type=\"matrix\" values=\"0.58 0 0 0 {F(0.42 * 30 / 255)} 0 0.58 0 0 {F(0.42 * 12 / 255)} 0 0 0.58 0 0 0 0 0 1 0\"/></filter><g filter=\"url(#{id}f)\"><use href=\"#{id}\"/></g>" };
            Snaps[img.Id] = img; Snaps[dk.Id] = dk;
            return (img, dk, x1 - x0, y1 - y0, cx, cy);
        }

        static string F(double v) => Ui.UiSvg.F(v);

        void AddSpr((Snap img, Snap dk, double w, double h, double cx, double cy) s, double x, double y, double vx, double vy, double vr, double vf, double r0)
        {
            var sp = new Spr { Img = s.img.Id, Wd = s.w, Hd = s.h, Cx = s.cx, Cy = s.cy, X = x, Y = y, Vx = vx, Vy = vy, Vr = vr, Vf = vf, R = r0, Fp = 0, M = Ch.M.M };
            sp.Gz = Rnd(-4, 18); sp.Rest = 0; sp.T = 0; sp.Seed = Rnd(0, TAU);
            Sprs.Add(sp);
            if (Sprs.Count > 70) Sprs.RemoveAt(0);
        }

        void Chunk(double x, double y, double P)
        {
            // (TierHp: a hole on hp0 / hp of the hits that would punch one)
            if (Ch.M.Hp0 > 0 && Ch.M.Hp > Ch.M.Hp0 && Random() > Ch.M.Hp0 / Ch.M.Hp) return;
            var c = Ch; var M = c.M.M;
            double R = Rnd(M.HoleR[0], M.HoleR[1]) * Math.Sqrt(c.M.Sc);
            var poly = HolePoly(x, y, R, M.Jag);
            var wp = poly.Select(p => { c.Warp(p[0], p[1], out var a, out var b); return new[] { a, b }; }).ToList();
            var s = Crop(wp, true);
            c.Holes.Add(poly);
            _layerKey = null;
            if (s == null) return;
            var (wx, wy) = Tw(s.Value.cx, s.Value.cy);
            double a2 = Math.Atan2(y + c.M.H * 0.5, x - (c.M.Bb.x0 + c.M.Bb.x1) / 2), v = Rnd(140, 260) * P / Math.Sqrt(M.Mass);
            double vy = Math.Sin(a2) * v * 0.5 - Rnd(180, 300) * P, vr = Rnd(-7, 7), vf = Rnd(-9, 9);
            AddSpr(s.Value, wx, wy, Math.Cos(a2) * v, vy, vr, vf, _mo.R);
            for (int i = 0; i < 4; i++) { var p = Np("dust"); p.X = wx + Rnd(-6, 6); p.Y = wy + Rnd(-6, 6); p.Vx = Rnd(-50, 50); p.Vy = Rnd(-50, 0); p.S = Rnd(12, 20); p.C = M.Dust; p.A = 0.75; p.Life = Rnd(0.6, 1); p.G = 0; p.Drag = 3; Add(p); }
        }

        List<double[]> PartBox(ChestPart p)
        {
            var c = Ch; double a = c.Ang.TryGetValue(p.Id, out var av) ? av : 0; double[] pv = null;
            if (a != 0 && p.Hang != null) { c.Warp(p.Hang[0], p.Hang[1], out var hx, out var hy); pv = new[] { hx, hy }; }
            double ca = Math.Cos(a), sa = Math.Sin(a), x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
            void Add2(double x, double y)
            {
                c.Warp(x, y, out var X, out var Y);
                if (pv != null) { double dx = X - pv[0], dy = Y - pv[1]; X = pv[0] + dx * ca - dy * sa; Y = pv[1] + dx * sa + dy * ca; }
                x0 = Math.Min(x0, X); x1 = Math.Max(x1, X); y0 = Math.Min(y0, Y); y1 = Math.Max(y1, Y);
            }
            foreach (var s in p.Sh)
            {
                if (s.Sp != null) foreach (var (pp, _) in s.Sp) for (int i = 0; i < pp.Length; i += 2) Add2(pp[i], pp[i + 1]);
                else if (s.Txt != null) { Add2(s.X - 36, s.Y - 10); Add2(s.X + 36, s.Y + 10); }
            }
            double pad = 6;
            return new List<double[]> { new[] { x0 - pad, y0 - pad }, new[] { x1 + pad, y0 - pad }, new[] { x1 + pad, y1 + pad }, new[] { x0 - pad, y1 + pad } };
        }

        void TearPart(ChestPart p, double hx, double hy, double P, bool launch)
        {
            var c = Ch; if (c.Torn.Contains(p.Id)) return;
            // (the part's own defs, its gradients and its lettering's glyphs, go with its snapshot: the frame's are new each frame)
            var pd = new StringBuilder();
            var cv = new Canvas2D(pd);
            ChestModels.DrawPart(cv, p, c.Warp, Time, c.Ang.TryGetValue(p.Id, out var a) ? a : 0);
            var s = Crop(PartBox(p), false, $"<defs>{pd}</defs>{cv.Markup}");
            c.Torn.Add(p.Id);
            _layerKey = null;
            if (s == null) return;
            var (wx, wy) = Tw(s.Value.cx, s.Value.cy);
            double dx = s.Value.cx - hx, dy = s.Value.cy - hy, L = ChestModels.Hyp(dx, dy); if (L == 0) L = 1; dx /= L; dy /= L;
            double vx, vy, vr, vf;
            if (launch) { double lv = p.LaunchV; vx = Rnd(-90, 90) + dx * 60; vy = -Rnd(lv * 0.85, lv * 1.15); vr = Rnd(-5, 5); vf = Rnd(-4, 4); }
            else if (p.Hang != null) { vx = dx * Rnd(40, 90) * P; vy = -Rnd(30, 120) * P; vr = (c.Av.TryGetValue(p.Id, out var av) ? av : 0) * 0.8 + Rnd(-2, 2); vf = Rnd(-2, 2); }
            else { vx = dx * Rnd(160, 280) * P; vy = dy * Rnd(80, 160) * P - Rnd(200, 330) * P; vr = Rnd(-8, 8); vf = Rnd(-8, 8); }
            AddSpr(s.Value, wx, wy, vx, vy, vr, vf, _mo.R);
            if (c.M.M.Spark != null && !launch) for (int i = 0; i < 6; i++) Spark(wx, wy, 200, 420, 0.2, 0.4, 100, c.M.M.Spark);
        }

        void Ko(double hx, double hy)
        {
            var c = Ch; var m = c.M; var M = m.M; Busy = true; On?.Invoke("koStart", new Dictionary<string, object>());
            _stop = 0.13; _shake = 20; _sflash = 0.9; _flash = 0;
            RenderLayer(true);
            foreach (var p in m.Parts) if (p.Launch && !c.Torn.Contains(p.Id)) TearPart(p, 0, -m.H * 0.2, 1.4, true);
            RenderLayer(true);
            double ex = (m.Bb.x0 + m.Bb.x1) / 2, ey = -m.H * 0.45;
            foreach (var pl in KoPolys(m))
            {
                var s = Crop(pl.Pts, true);
                if (s == null) continue;
                var (wx, wy) = Tw(s.Value.cx, s.Value.cy);
                double dx = s.Value.cx - ex, dy = s.Value.cy - ey, L = ChestModels.Hyp(dx, dy); if (L == 0) L = 1; dx /= L; dy /= L;
                double sp = Rnd(150, 300) * (pl.Pow ?? 1) / Math.Sqrt(M.Mass);
                double vy = dy * sp * 0.6 - Rnd(220, 400) * (pl.Up ?? 1);
                double vr = pl.Vr ?? Rnd(-6, 6), vf = pl.Vf ?? Rnd(-7, 7);
                AddSpr(s.Value, wx, wy, dx * sp + (pl.Vx ?? 0), vy, vr, vf, _mo.R);
            }
            c.Gone = true;
            var (cx, cy) = Tw(ex, ey);
            { var p = Np("ring"); p.X = cx; p.Y = cy; p.R0 = 10; p.R1 = m.W * 0.95; p.C = "#ffffff"; p.Life = 0.45; p.G = 0; p.Bounce = -1; Add(p); }
            { var p = Np("ring"); p.X = cx; p.Y = cy; p.R0 = 10; p.R1 = m.W * 0.7; p.C = ChestModels.TIER[Tier].Fx; p.Life = 0.55; p.G = 0; p.Bounce = -1; Add(p); }
            for (int i = 0; i < 24; i++) { double sd = i % 2 == 1 ? 1 : -1; var p = Np("dust"); p.X = _mo.X + Rnd(-m.W * 0.5, m.W * 0.5); p.Y = Rnd(-6, 4); p.Vx = sd * Rnd(70, 260); p.Vy = -Rnd(10, 70); p.S = Rnd(18, 34); p.C = M.Dust; p.A = 0.85; p.Life = Rnd(1, 1.6); p.G = -24; p.Drag = 2.4; Add(p); }
            for (int i = 0; i < 12; i++) { var p = Np("dust"); p.X = cx + Rnd(-30, 30); p.Y = cy + Rnd(-30, 30); p.Vx = Rnd(-140, 140); p.Vy = Rnd(-160, 40); p.S = Rnd(18, 30); p.C = M.Dust; p.A = 0.8; p.Life = Rnd(0.8, 1.3); p.G = -10; p.Drag = 2.6; Add(p); }
            Debris(cx, cy, 34, 1.6, null);
            if (M.Spark != null) for (int i = 0; i < 26; i++) Spark(cx, cy, 300, 640, 0.3, 0.55, 160, M.Spark);
            At(Time + 0.32, Reveal);
        }

        void Reveal()
        {
            var m = Ch.M; int n = new[] { 12, 16, 22, 30, 40 }[Tier]; double cx = _mo.X, cy = -m.H * 0.35;
            var kinds = m.Loot.Concat(Tier >= 3 ? new[] { "gem", "gem", "star" } : new string[0]).ToList();
            Open = new object();
            for (int i = 0; i < n; i++)
            {
                double a = -Math.PI / 2 + Rnd(-1, 1) * (0.6 + Tier * 0.1), v = Rnd(420, 760);
                var p = Np("loot"); p.K = Pick(kinds); p.X = cx + Rnd(-10, 10); p.Y = cy; p.Vx = Math.Cos(a) * v; p.Vy = Math.Sin(a) * v; p.S = Rnd(16, 24); p.R = Rnd(-0.5, 0.5); p.Vr = Rnd(-6, 6); p.G = 1300; p.Bounce = 0.42; p.Life = Rnd(3.2, 4.2); p.C = Pick(RB);
                Add(p);
            }
            var T = ChestModels.TIER[Tier];
            for (int i = 0; i < 18 + Tier * 6; i++)
            {
                double a = Rnd(0, TAU), v = Rnd(120, 360);
                var p = Np("star"); p.X = cx; p.Y = cy; p.Vx = Math.Cos(a) * v; p.Vy = Math.Sin(a) * v - 80; p.S = Rnd(6, 13); p.C = T.Rb ? Pick(RB) : T.Fx; p.Life = Rnd(0.6, 1); p.G = 200; p.Drag = 2; p.Bounce = -1;
                Add(p);
            }
            Busy = false; On?.Invoke("ko", new Dictionary<string, object> { ["tier"] = Tier });
        }

        public void Upgrade(int to)
        {
            if (Busy || Ch == null || to <= Tier) return;
            Busy = true; _upTo = to; double t = Time + 0.05;
            for (int i = Tier + 1; i <= to; i++)
            {
                bool fin = i == to; double dur = UPD[i] * (fin ? 1 : 0.55); int ti = i;
                At(t, () => BeginCharge(ti, dur, fin)); At(t + dur, () => Poof(ti, fin)); t += dur + (fin ? 0 : 0.6);
            }
            At(t + UPH[to], EndUp);
        }

        public void SkipUp() { if (_upTo == null) return; _q.Clear(); _charge = null; if (Tier != _upTo) Poof(_upTo.Value, true); EndUp(); }
        void EndUp() { var to = _upTo; Busy = false; _upTo = null; On?.Invoke("upgradeDone", new Dictionary<string, object> { ["tier"] = to }); }

        void BeginCharge(int i, double dur, bool fin)
        {
            int n = 5 + 3 * i;
            var beams = new List<(double, double, double, double, double)>();
            for (int j = 0; j < n; j++) { double a = (j + Rnd(-0.3, 0.3)) / n * TAU, w = Rnd(0.04, 0.1), l = Rnd(0.8, 1.25), at = Rnd(0.06, 0.85), f = Rnd(0, TAU); beams.Add((a, w, l, at, f)); }
            _charge = new Charge { I = i, K = 0, Rate = 1 / dur, C = ChestModels.TIER[i].Fx, Rb = ChestModels.TIER[i].Rb, Fin = fin, Beams = beams };
            On?.Invoke("charge", new Dictionary<string, object> { ["tier"] = i });
        }

        void Poof(int i, bool fin)
        {
            _charge = null; Load(Group, i, true);
            var m = Ch.M; var T = ChestModels.TIER[i]; double cy = -m.H * 0.5, P = fin ? 1 : 0.7;
            string Col() => T.Rb ? Pick(RB) : T.Fx;
            _mo.Ps = 0.3; _mo.Vps = 6 + i;
            _burst = 1; _burstI = i; _burstR = 1 / (0.75 + 0.3 * i); _pillar = Math.Max(_pillar, (0.45 + 0.15 * i) * P); _stop = (0.05 + 0.03 * i) * P;
            int nd = 18 + 6 * i;
            for (int k = 0; k < nd; k++)
            {
                double a = (double)k / nd * TAU + Rnd(-0.1, 0.1), ex = Math.Cos(a) * m.W * 0.5, ey = Math.Sin(a) * m.H * 0.48, v = 1 + i * 0.18;
                var p = Np("dust"); p.X = ex; p.Y = cy + ey; p.Vx = Math.Cos(a) * Rnd(110, 240) * v; p.Vy = Math.Sin(a) * Rnd(80, 190) * v - 30; p.S = Rnd(20, 36); p.C = k % 3 != 0 ? "#ffffff" : Col(); p.A = 0.95; p.Life = Rnd(0.7, 1.2); p.G = -30; p.Drag = 2.6;
                Add(p);
            }
            for (int k = 0; k < (24 + i * 16) * P; k++)
            {
                double a = Rnd(0, TAU), v = Rnd(180, 460 + i * 60);
                var p = Np("star"); p.X = Rnd(-20, 20); p.Y = cy; p.Vx = Math.Cos(a) * v; p.Vy = Math.Sin(a) * v; p.S = Rnd(6, 14 + i); p.C = T.Rb ? Pick(RB) : (k % 3 != 0 ? T.Fx : "#ffffff"); p.Life = Rnd(0.6, 1.1); p.G = 120; p.Drag = 2.2; p.Bounce = -1;
                Add(p);
            }
            for (int k = 0; k <= i; k++)
            {
                int kk = k;
                At(Time + k * 0.11, () => { var p = Np("ring"); p.X = 0; p.Y = cy; p.R0 = 20; p.R1 = m.W * (1.1 + kk * 0.45); p.C = kk % 2 == 1 ? "#ffffff" : (T.Rb ? RB[(kk * 2) % 5] : T.Fx); p.Lw = 12 - kk; p.Life = 0.55 + kk * 0.08; p.G = 0; p.Bounce = -1; Add(p); });
            }
            { var p = Np("gring"); p.X = 0; p.Y = 0; p.R0 = 10; p.R1 = m.W * (1.3 + 0.25 * i); p.C = T.Rb ? "#ffffff" : T.Fx; p.Lw = 10; p.Life = 0.75; p.G = 0; p.Bounce = -1; Add(p); }
            if (i >= 3 && fin)
            {
                var cc = T.Rb ? RB.Concat(new[] { "#ffd23a", "#ffffff" }).ToArray() : new[] { "#ffd23a", "#fff6c0", "#ffb020", "#ffffff" };
                for (int k = 0; k < (T.Rb ? 80 : 34); k++)
                {
                    var p = Np("shred"); p.X = Rnd(-20, 20); p.Y = cy; p.Vx = Rnd(-440, 440); p.Vy = -Rnd(450, 980); p.C = Pick(cc); p.W = Rnd(6, 11); p.H = Rnd(4, 7); p.R = 0; p.Vr = Rnd(-8, 8); p.Vf = Rnd(6, 14); p.G = 700; p.Drag = 1.4; p.Fl = 300; p.Ph = Rnd(0, TAU); p.Bounce = 0.1; p.Life = Rnd(2.4, 3.4);
                    Add(p);
                }
            }
            if (T.Rb && fin)
                for (int k = 1; k < 5; k++)
                {
                    int kk = k;
                    At(Time + 0.2 + k * 0.2, () =>
                    {
                        _sflash = Math.Max(_sflash, 0.32); _sfc = RB[kk % 5]; _shake = Math.Max(_shake, 7);
                        { var p = Np("ring"); p.X = 0; p.Y = cy; p.R0 = 30; p.R1 = m.W * (1.6 + kk * 0.3); p.C = RB[kk % 5]; p.Lw = 9; p.Life = 0.7; p.G = 0; p.Bounce = -1; Add(p); }
                        for (int j = 0; j < 14; j++)
                        {
                            double a = Rnd(0, TAU), v = Rnd(200, 420);
                            var p = Np("star"); p.X = Math.Cos(a) * 30; p.Y = cy + Math.Sin(a) * 30; p.Vx = Math.Cos(a) * v; p.Vy = Math.Sin(a) * v; p.S = Rnd(7, 13); p.C = RB[(kk + j) % 5]; p.Life = Rnd(0.6, 1); p.G = 80; p.Drag = 2.2; p.Bounce = -1;
                            Add(p);
                        }
                    });
                }
            _sflash = (0.75 + i * 0.06) * P; _sfc = "#ffffff"; _shake = (8 + i * 4) * P;
            On?.Invoke("step", new Dictionary<string, object> { ["tier"] = i, ["hp"] = Hp, ["max"] = m.Hp, ["name"] = m.Name });
        }

        // ---- a frame -----------------------------------------------------------------------------------------------------
        public void Tick(double dt)
        {
            Time += dt; double T = Time;
            if (_q.Count > 0)
            {
                // (Array.sort by t is stable: equal times keep their order)
                var sorted = _q.Select((e, i) => (e, i)).OrderBy(x => x.e.t).ThenBy(x => x.i).Select(x => x.e).ToList();
                _q.Clear(); _q.AddRange(sorted);
                while (_q.Count > 0 && _q[0].t <= T) { var f = _q[0].fn; _q.RemoveAt(0); f(); }
            }
            _flash = Math.Max(0, _flash - dt * 6); _sflash = Math.Max(0, _sflash - dt * 2.6); _shake *= Math.Exp(-9 * dt);
            var ch = Ch; var m = ch?.M; var mo = _mo;
            if (_stop > 0) { _stop -= dt; return; }
            mo.Vx += (-110 * mo.X - 12 * mo.Vx) * dt; mo.X += mo.Vx * dt;
            mo.Vr += (-140 * mo.R - 11 * mo.Vr) * dt; mo.R += mo.Vr * dt;
            mo.Vq += (-420 * mo.Q - 15 * mo.Vq) * dt; mo.Q += mo.Vq * dt;
            mo.Vy += 2600 * dt; mo.Y += mo.Vy * dt; if (mo.Y > 0) { mo.Y = 0; mo.Vy = mo.Vy > 200 ? -mo.Vy * 0.25 : 0; }
            mo.Vps += (-170 * (mo.Ps - 1) - 10 * mo.Vps) * dt; mo.Ps += mo.Vps * dt;
            if (ch != null && !ch.Gone)
                foreach (var p in m.Parts)
                {
                    if (p.Hang == null || ch.Torn.Contains(p.Id)) continue;
                    double lo = p.Loose ?? (p.Tear != null ? p.Tear.Value - 0.3 : 0), te = p.Tear ?? 1, l = Clamp((ch.D - lo) / Math.Max(0.05, te - lo), 0, 1);
                    double a = ch.Ang.TryGetValue(p.Id, out var av0) ? av0 : 0, v = ch.Av.TryGetValue(p.Id, out var vv) ? vv : 0, nv = v + (-55 * (a - p.Hdir * p.Hmax * l * l) - 3.2 * v) * dt;
                    ch.Av[p.Id] = nv; ch.Ang[p.Id] = a + nv * dt;
                }
            var tr = ChestModels.TIER[Tier];
            double tk = Tier == 3 ? 0.4 : Tier == 4 ? 0.55 : 0, rays = Tier == 4 ? 0.3 : 0;
            if (_charge != null)
            {
                var C = _charge; C.K = Math.Min(1, C.K + dt * C.Rate); tk = 0.5 + 0.8 * C.K; rays = Math.Max(rays, C.K > 0.4 ? C.K : 0); C.Acc += dt * (30 + (40 + 26 * C.I) * C.K);
                while (C.Acc > 1)
                {
                    C.Acc--;
                    double a = Rnd(0, TAU), dd = Rnd(170, 280), cy = -m.H * 0.5 + _lift;
                    var p = Np("mote"); p.X = Math.Cos(a) * dd; p.Y = cy + Math.Sin(a) * dd; p.Sx = Math.Cos(a) * dd; p.Sy = cy + Math.Sin(a) * dd; p.Tx = 0; p.Ty = cy; p.S = Rnd(4, 9 + C.I);
                    p.C = C.Rb ? Pick(RB) : (Random() < 0.3 ? "#ffffff" : C.C); p.Life = Rnd(0.4, 0.6); p.G = 0; p.Bounce = -1; p.Sw = C.Rb ? Rnd(1.6, 2.6) : C.I >= 3 ? Rnd(0.5, 1) : 0;
                    Add(p);
                }
            }
            if (Open != null) { tk = 1.15; rays = 1; }
            if (ch != null && ch.Gone && Open == null) tk = 0.8;
            {
                var C = _charge; int ci = C != null ? C.I : Tier; double dk = _upTo != null ? DK[ci] * (C != null ? 0.7 + 0.3 * Math.Min(1, C.K * 2) : 1) : 0;
                _dark += (dk - _dark) * Math.Min(1, dt * (dk > _dark ? 4 : 1.8));
                double lt = C != null ? -(6 + 5 * C.I) * (1 - Math.Pow(1 - C.K, 2)) : 0; _lift += (lt - _lift) * Math.Min(1, dt * (C != null ? 6 : 9));
                if (_burst > 0) _burst = Math.Max(0, _burst - dt * _burstR);
                if (C == null) _pillar = Math.Max(0, _pillar - dt * 0.9);
                if (C != null && m != null)
                {
                    _pillar = Math.Max(_pillar, C.K * C.K * (0.15 + 0.12 * C.I)); C.Ra += dt; double iv = Math.Max(0.09, 0.34 - 0.04 * C.I - 0.16 * C.K);
                    if (C.Ra > iv) { C.Ra = 0; var p = Np("iring"); p.X = mo.X; p.Y = -m.H * 0.5 + _lift; p.R0 = m.W * (1.25 + 0.1 * C.I); p.R1 = m.W * 0.3; p.C = C.Rb ? Pick(RB) : C.C; p.Lw = 3 + C.I; p.Life = 0.5; p.G = 0; p.Bounce = -1; Add(p); }
                }
            }
            _glow.k += (tk - _glow.k) * Math.Min(1, dt * 5); _glow.rays += (rays - _glow.rays) * Math.Min(1, dt * 4); _glow.c = _charge != null ? _charge.C : tr.Fx; _glow.rb = _charge != null ? _charge.Rb : tr.Rb;
            _idleT += dt;
            if (ch != null && !ch.Gone && Tier >= 3 && _idleT > (Tier == 4 ? 0.16 : 0.45))
            {
                _idleT = 0; var bb = m.Bb;
                double px = Rnd(bb.x0 + 8, bb.x1 - 8), py = Rnd(bb.y0 + 8, bb.y1 - 8);
                var (wx, wy) = Tw(px, py);
                var p = Np("star"); p.X = wx; p.Y = wy; p.Vx = 0; p.Vy = -10; p.S = Rnd(5, 10); p.C = Tier == 4 ? Pick(RB) : "#fff6c0"; p.Life = Rnd(0.5, 0.8); p.G = 0; p.Bounce = -1;
                Add(p);
            }
            for (int i = Sprs.Count - 1; i >= 0; i--)
            {
                var s = Sprs[i]; var M = s.M; s.T += dt;
                s.Vy += (M.Flutter != 0 ? 1050 : 1500) * dt;
                if (M.Flutter != 0) { s.Vx += Math.Sin(s.T * 5 + s.Seed) * 110 * M.Flutter * dt; s.Vx *= Math.Exp(-1.1 * dt); s.Vy *= Math.Exp(-0.9 * M.Flutter * dt); }
                s.X += s.Vx * dt; s.Y += s.Vy * dt; s.R += s.Vr * dt; s.Fp += s.Vf * dt;
                double fl = Math.Abs(Math.Cos(s.Fp)), hw = s.Wd / 2 * Math.Max(0.12, fl), hh = s.Hd / 2, e = Math.Abs(hw * Math.Sin(s.R)) + Math.Abs(hh * Math.Cos(s.R));
                if (s.Y + e > s.Gz)
                {
                    s.Y = s.Gz - e;
                    if (s.Vy > 110)
                    {
                        if (s.Vy > 260 && T - _lastB > 0.07) _lastB = T;
                        if (s.Vy > 300) for (int k = 0; k < 2; k++) { var p = Np("dust"); p.X = s.X + Rnd(-hw, hw); p.Y = s.Gz - 2; p.Vx = Rnd(-80, 80); p.Vy = -Rnd(10, 40); p.S = Rnd(10, 16); p.C = M.Dust; p.A = 0.6; p.Life = 0.6; p.G = -10; p.Drag = 3; Add(p); }
                        s.Vy = -s.Vy * M.Rest; s.Vx *= 0.55; s.Vr *= 0.45; s.Vf *= 0.5;
                    }
                    else
                    {
                        s.Vy = 0; double f = Math.Exp(-9 * dt); s.Vx *= f; s.Vr *= f; s.Vf *= f;
                        double bse = s.Hd > s.Wd * fl ? Math.PI / 2 : 0, tr2 = bse + Math.Round((s.R - bse) / Math.PI, MidpointRounding.AwayFromZero) * Math.PI;
                        s.R += (tr2 - s.R) * Math.Min(1, dt * 5); s.Fp += (JsRound(s.Fp / Math.PI) * Math.PI - s.Fp) * Math.Min(1, dt * 5); s.Rest += dt;
                    }
                }
                if (s.Rest > 3.2 || s.Y > 900 || Math.Abs(s.X) > 900) Sprs.RemoveAt(i);
            }
            for (int i = Pt.Count - 1; i >= 0; i--)
            {
                var p = Pt[i]; p.T += dt; if (p.T >= p.Life) { Pt.RemoveAt(i); continue; }
                if (p.Type == "ring" || p.Type == "iring" || p.Type == "gring") continue;
                if (p.Type == "mote")
                {
                    double k = p.T / p.Life, e2 = k * k, x = p.Sx + (p.Tx - p.Sx) * e2, y = p.Sy + (p.Ty - p.Sy) * e2;
                    if (p.Sw != 0) { double a = p.Sw * e2, dx = x - p.Tx, dy = y - p.Ty, ca = Math.Cos(a), sa = Math.Sin(a); x = p.Tx + dx * ca - dy * sa; y = p.Ty + dx * sa + dy * ca; }
                    p.X = x; p.Y = y; continue;
                }
                p.Vy += p.G * dt; if (p.Drag != 0) { double f = Math.Exp(-p.Drag * dt); p.Vx *= f; p.Vy *= f; }
                if (p.Fl != 0) p.Vx += Math.Sin(p.T * 7 + p.Ph) * p.Fl * dt;
                p.X += p.Vx * dt; p.Y += p.Vy * dt; p.R += p.Vr * dt;
                if (p.Bounce >= 0 && p.Y > p.Gz && p.Vy > 0) { p.Y = p.Gz; if (p.Vy > 90) { p.Vy *= -p.Bounce; p.Vx *= 0.6; p.Vr *= 0.6; } else { p.Vy = 0; double f = Math.Exp(-12 * dt); p.Vx *= f; p.Vr *= f; } }
            }
        }

        static double JsRound(double v) => Math.Floor(v + 0.5);

        // the frame's defs (gradients, clips, the layer and the snapshots are shared by everything in it)
        StringBuilder _defs = new StringBuilder();

        /// <summary>renderLayer(): the chest's parts, its dents' shading, cracks, the charge's and burst's and hit's flash
        /// ('source-atop': clipped to the hull), the holes cut out ('destination-out': a mask) with their edges; and the
        /// cavity seen through the holes.</summary>
        void RenderLayer(bool force = false)
        {
            var c = Ch; if (c == null) return;
            var m = c.M; var M = m.M; double T = Time;
            var key = new StringBuilder($"{Tier}|{c.Seed}|{Hp}|{c.D}|{c.Dents.Count}|{c.Cracks.Count}|{c.Holes.Count}|{c.Torn.Count}|{_flash}|{(_burst > 0.55 ? _burst : 0)}");
            foreach (var kv in c.Ang) key.Append('|').Append(Math.Round(kv.Value * 3000));
            if (_charge != null || m.Spins) key.Append('|').Append(T);
            var k = key.ToString();
            if (!force && k == _layerKey && _layer != null) return;
            _layerKey = k;
            var defs = new StringBuilder();
            var L = new Canvas2D(defs);
            foreach (var p in m.Parts)
            {
                if (c.Torn.Contains(p.Id)) { if (p.Scar != null) foreach (var s in p.Scar) ChestModels.DrawShape(L, s, c.Warp, T); continue; }
                ChestModels.DrawPart(L, p, c.Warp, T, c.Ang.TryGetValue(p.Id, out var a) ? a : 0);
            }
            string parts = L.Markup;
            // 'source-atop': on the chest only (its hull, warped)
            string hullId = "hull" + (_snapN++);
            var hd = new StringBuilder();
            foreach (var (pp, _) in m.HullSp) { var w = Warped(pp); for (int i = 0; i < w.Length; i += 2) hd.Append(i == 0 ? 'M' : 'L').Append(F(w[i])).Append(' ').Append(F(w[i + 1])).Append(' '); hd.Append('Z'); }
            defs.Append($"<clipPath id=\"{hullId}\"><path d=\"{hd}\"/></clipPath>");
            var A = new Canvas2D(defs);
            foreach (var q in c.Dents)
            {
                c.Warp(q.X, q.Y, out var X, out var Y); double R = q.R * 1.15, a = M.DentShade * Math.Min(1, q.K / 5);
                A.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { X - R * 0.22, Y - R * 0.22, 0, X - R * 0.22, Y - R * 0.22, R } }.Add(0, $"rgba(40,15,5,{a:0.000})").Add(1, "rgba(40,15,5,0)");
                A.FillRect(X - R * 1.3, Y - R * 1.3, R * 2.6, R * 2.6);
                A.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { X + R * 0.34, Y + R * 0.34, 0, X + R * 0.34, Y + R * 0.34, R * 0.55 } }.Add(0, $"rgba(255,255,255,{a * 0.9:0.000})").Add(1, "rgba(255,255,255,0)");
                A.FillRect(X - R, Y - R, R * 2, R * 2);
            }
            var CS = ChestModels.CRACK[M.Crack];
            foreach (var (col, w, ox, oy, glow) in CS)
            {
                A.StrokeStyle = col; A.LineWidth = w; A.LineJoin = "round"; A.LineCap = "round"; A.ShadowColor = glow ?? "transparent"; A.ShadowBlur = glow != null ? 6 : 0;
                foreach (var grp in c.Cracks)
                foreach (var pl in grp)
                {
                    A.BeginPath();
                    for (int i = 0; i < pl.Count; i++) { c.Warp(pl[i][0], pl[i][1], out var X, out var Y); if (i > 0) A.LineTo(X + ox, Y + oy); else A.MoveTo(X + ox, Y + oy); }
                    A.Stroke();
                }
            }
            A.ShadowBlur = 0;
            if (_charge != null)
            {
                var C = _charge;
                A.FillStyle = Rgba(C.Rb ? RB[(int)Math.Floor(T * 8) % 5] : C.C, Math.Min(0.75, C.K * (0.3 + 0.1 * C.I))); A.FillRect(-OX, -OY, LW, LH);
                if (C.K > 0.7) { A.FillStyle = $"rgba(255,255,255,{Math.Min(0.85, (C.K - 0.7) * (1 + 0.45 * C.I)):0.000})"; A.FillRect(-OX, -OY, LW, LH); }
            }
            if (_burst > 0.55) { A.FillStyle = $"rgba(255,255,255,{(_burst - 0.55) * 1.9:0.000})"; A.FillRect(-OX, -OY, LW, LH); }
            if (_flash > 0) { A.FillStyle = $"rgba(255,255,255,{_flash * 0.55:0.000})"; A.FillRect(-OX, -OY, LW, LH); }
            string atop = $"<g clip-path=\"url(#{hullId})\">{A.Markup}</g>";
            _cav = c.Holes.Count > 0;
            string body;
            if (_cav)
            {
                var holeD = new StringBuilder();
                foreach (var h in c.Holes) { for (int i = 0; i < h.Length; i++) { c.Warp(h[i][0], h[i][1], out var X, out var Y); holeD.Append(i == 0 ? 'M' : 'L').Append(F(X)).Append(' ').Append(F(Y)).Append(' '); } holeD.Append('Z'); }
                string maskId = "hm" + (_snapN++), holesClip = "hc" + (_snapN++);
                defs.Append($"<mask id=\"{maskId}\" maskUnits=\"userSpaceOnUse\" x=\"{F(-OX)}\" y=\"{F(-OY)}\" width=\"{F(LW)}\" height=\"{F(LH)}\"><rect x=\"{F(-OX)}\" y=\"{F(-OY)}\" width=\"{F(LW)}\" height=\"{F(LH)}\" fill=\"#fff\"/><path d=\"{holeD}\" fill=\"#000\"/></mask>");
                defs.Append($"<clipPath id=\"{holesClip}\"><path d=\"{holeD}\"/></clipPath>");
                // the edges ('source-atop' after the holes are cut)
                var E = new Canvas2D(defs);
                E.LineJoin = "round";
                foreach (var h in c.Holes)
                {
                    TracePts(E, h, c);
                    E.StrokeStyle = M.Edge; E.LineWidth = M.EdgeW; if (M.Crack == "glow") { E.ShadowColor = "#ffffff"; E.ShadowBlur = 8; }
                    E.Stroke(); E.ShadowBlur = 0;
                    if (M.Jag == "ragged") { E.SetLineDash(new[] { 2.0, 3 }); E.LineWidth = 3; E.StrokeStyle = "rgba(120,70,20,0.7)"; E.Stroke(); E.SetLineDash(null); }
                    if (M.Jag == "petal") { E.LineWidth = 9; E.StrokeStyle = "rgba(30,5,0,0.25)"; E.Stroke(); }
                }
                // the cavity behind (the page's `scr`: the holes, inside the layer, drawn under it)
                var Cv = new Canvas2D(defs);
                DrawCavity(Cv, c);
                string cav = $"<g clip-path=\"url(#{holesClip})\"><g clip-path=\"url(#{hullId})\">{Cv.Markup}</g></g>";
                body = cav + $"<g mask=\"url(#{maskId})\">{parts}{atop}<g clip-path=\"url(#{hullId})\">{E.Markup}</g></g>";
            }
            else body = parts + atop;
            // (the layer canvas is LW x LH: what's outside it is cut off)
            string boxId = "lb" + (_snapN++);
            defs.Append($"<clipPath id=\"{boxId}\"><rect x=\"{F(-OX)}\" y=\"{F(-OY)}\" width=\"{F(LW)}\" height=\"{F(LH)}\"/></clipPath>");
            _layer = $"<defs>{defs}</defs><g clip-path=\"url(#{boxId})\">{body}</g>";
        }

        static void TracePts(Canvas2D c, double[][] pts, Chest ch)
        {
            c.BeginPath();
            for (int i = 0; i < pts.Length; i++) { ch.Warp(pts[i][0], pts[i][1], out var x, out var y); if (i > 0) c.LineTo(x, y); else c.MoveTo(x, y); }
            c.ClosePath();
        }

        static string Rgba(string h, double a) { var c = Canvas2D.Rgba(h); return $"rgba({(int)c.r},{(int)c.g},{(int)c.b},{a.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)})"; }

        void DrawCavity(Canvas2D c, Chest ch)
        {
            var m = ch.M; var bb = m.Bb; var M = m.M;
            c.FillStyle = new CanvasPaint { Kind = 'l', Args = new[] { 0, bb.y0, 0, bb.y1 } }.Add(0, M.Cav[0]).Add(1, M.Cav[1]);
            c.FillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, bb.y1 - bb.y0 + 40);
            double gy = -m.H * 0.45;
            c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { 0, gy, 0, 0, gy, m.W * 0.62 } }.Add(0, Rgba(M.Glow, 0.95)).Add(0.5, Rgba(M.Glow, 0.35)).Add(1, Rgba(M.Glow, 0));
            c.FillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, bb.y1 - bb.y0 + 40);
            foreach (var pk in m.Peeks) { c.Save(); c.Translate(pk.x, pk.y); c.Rotate(pk.r); ChestModels.DrawIcon(c, pk.k, pk.s, pk.c); c.Restore(); }
            c.FillStyle = new CanvasPaint { Kind = 'l', Args = new[] { 0, bb.y0, 0, bb.y0 + 40 } }.Add(0, "rgba(0,0,0,0.5)").Add(1, "rgba(0,0,0,0)");
            c.FillRect(bb.x0 - 20, bb.y0 - 20, bb.x1 - bb.x0 + 40, 60);
        }

        void DrawGlow(Canvas2D c)
        {
            var G = _glow; var m = Ch?.M; if (m == null || (G.k < 0.02 && G.rays < 0.02)) return;
            double cx = _mo.X, cy = Open != null ? -m.H * 0.4 : -m.H * 0.5 * _mo.Ps + _lift, R = Math.Max(m.W, m.H) * (0.8 + 0.55 * G.k), T = Time;
            if (G.rays > 0.02)
            {
                c.Save(); c.Translate(cx, cy); c.Rotate(T * 0.35); int N = 14; double RR = R * 1.9;
                for (int i = 0; i < N; i++)
                {
                    string col = G.rb ? RB[i % 5] : G.c;
                    c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { 0, 0, 0, 0, 0, RR } }.Add(0, Rgba(col, 0.55 * G.rays)).Add(1, Rgba(col, 0));
                    c.BeginPath(); c.MoveTo(0, 0); c.Arc(0, 0, RR, (double)i / N * TAU, (i + 0.42) / N * TAU); c.ClosePath(); c.Fill();
                }
                c.Restore();
            }
            if (G.k > 0.02)
            {
                double pulse = 1 + Math.Sin(T * 4) * 0.04, a = Math.Min(1, G.k) * pulse;
                var g = new CanvasPaint { Kind = 'r', Args = new[] { cx, cy, 0, cx, cy, R } }.Add(0, $"rgba(255,255,255,{0.85 * a:0.000})");
                if (G.rb) { g.Add(0.3, Rgba("#ff9fd6", 0.55 * a)); g.Add(0.55, Rgba("#9fd8ff", 0.3 * a)); } else g.Add(0.35, Rgba(G.c, 0.6 * a));
                g.Add(1, Rgba(G.rb ? "#d6b3ff" : G.c, 0));
                c.FillStyle = g; c.FillRect(cx - R, cy - R, R * 2, R * 2);
            }
        }

        /// <summary>draw(): the frame as SVG (the canvas's CSS size, its top-left at 0, 0).</summary>
        public string Draw()
        {
            _defs = new StringBuilder();
            var c = new Canvas2D(_defs);
            double sh = _shake, ox = sh > 0.3 ? Rnd(-sh, sh) : 0, oy = sh > 0.3 ? Rnd(-sh, sh) * 0.6 : 0;
            DrawStageFx(c);
            c.Translate(Gx + ox, Gy + oy); c.Scale(S, S);
            var ch = Ch; var m = ch?.M; var mo = _mo; double T = Time;
            DrawGlow(c); DrawUpFx(c, false);
            if (ch != null && !ch.Gone)
            {
                double hop = Clamp(1 + (mo.Y + _lift) / 260, 0.3, 1), rx = m.W * 0.55 * mo.Ps * (1 + Clamp(mo.Q, -0.3, 0.4) * 0.4);
                c.Save(); c.Translate(0, 2); c.Scale(1, 0.14); c.Translate(0, -2);
                c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { mo.X, 2, 0, mo.X, 2, rx } }.Add(0, $"rgba(42,10,40,{0.34 * hop:0.000})").Add(1, "rgba(42,10,40,0)");
                c.BeginPath(); c.Arc(mo.X, 2, rx, 0, TAU); c.Fill(); c.Restore();
                RenderLayer();
                c.Save();
                var C = _charge; double rum = C != null ? C.K : 0, ra = C != null ? 2 + 2 * C.I : 0, q = Clamp(mo.Q, -0.3, 0.4) + Math.Sin(T * 2.4) * 0.008;
                double pul = C != null ? 1 + C.K * (0.03 + 0.008 * C.I) * Math.Max(0, Math.Sin(T * (7 + 16 * C.K))) : 1;
                double tx = mo.X + (rum != 0 ? Rnd(-1, 1) * rum * ra : 0), ty = mo.Y + _lift;
                c.Translate(tx, ty);
                double rr = mo.R + (rum != 0 ? Rnd(-1, 1) * rum * 0.012 * ra : 0);
                c.Rotate(rr); c.Scale(mo.Ps * (1 + q * 0.5) * pul, mo.Ps * (1 - q) * pul);
                _defs.Append($"<g id=\"layer\">{_layer}</g>");
                c.DrawLayer("layer", Affine.Identity);
                c.Restore();
            }
            DrawUpFx(c, true);
            foreach (var s in Sprs.OrderBy(s => s.Gz).ToList())
            {
                double fl = Math.Cos(s.Fp), sc = Math.Abs(fl) < 0.1 ? (fl < 0 ? -0.1 : 0.1) : fl, a = s.Rest > 2.4 ? Clamp(1 - (s.Rest - 2.4) / 0.8, 0, 1) : 1;
                if (a <= 0) continue;
                c.Save(); c.GlobalAlpha = a; c.Translate(s.X, s.Y); c.Rotate(s.R); c.Scale(sc, 1);
                c.DrawLayer(fl < 0 ? s.Img + "d" : s.Img, Affine.Identity);
                c.Restore();
            }
            foreach (var p in Pt) DrawP(c, p);
            // the snapshots the sprites show
            var used = new HashSet<string>();
            foreach (var s in Sprs) { used.Add(s.Img); used.Add(s.Img + "d"); }
            foreach (var id in used) if (Snaps.TryGetValue(id, out var sn)) _defs.Append($"<g id=\"{sn.Id}\">{sn.Markup}</g>");
            foreach (var k in Snaps.Keys.Where(k => !used.Contains(k)).ToList()) Snaps.Remove(k);
            if (_sflash > 0) { c.SetTransform(1, 0, 0, 1, 0, 0); c.FillStyle = Rgba(_sfc, Math.Min(0.92, _sflash * 0.85)); c.FillRect(0, 0, Wc, Hc); }
            return $"<defs>{_defs}</defs>{c.Markup}";
        }

        void DrawStageFx(Canvas2D c)
        {
            var m = Ch?.M; if (m == null || (_dark < 0.01 && _pillar < 0.01)) return;
            double s = S, X = Gx + _mo.X * s, Y = Gy + (_lift - m.H * 0.5) * s, T = Time; int ti = _charge != null ? _charge.I : (_burst > 0 ? _burstI : Tier);
            bool rb = ChestModels.TIER[ti].Rb; string col = ChestModels.TIER[ti].Fx;
            if (_dark > 0.01)
            {
                double R = ChestModels.Hyp(Wc, Hc) * 0.75, a = _dark; string bse = rb ? "#16062c" : "#0b0618";
                c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { X, Y, 0, X, Y, R } }.Add(0, Rgba(bse, a * 0.12)).Add(0.16, Rgba(bse, a * 0.7)).Add(1, Rgba(bse, a));
                c.FillRect(0, 0, Wc, Hc);
            }
            if (_pillar > 0.01)
            {
                double p = Math.Min(1, _pillar), w = m.W * s * (0.3 + 0.45 * p); string cl = rb ? RB[(int)Math.Floor(T * 6) % 5] : col;
                c.Save(); c.GlobalCompositeOperation = "lighter";
                c.FillStyle = new CanvasPaint { Kind = 'l', Args = new[] { X - w, 0, X + w, 0 } }.Add(0, Rgba(cl, 0)).Add(0.32, Rgba(cl, 0.42 * p)).Add(0.5, Rgba("#ffffff", 0.85 * p)).Add(0.68, Rgba(cl, 0.42 * p)).Add(1, Rgba(cl, 0));
                c.FillRect(X - w, 0, w * 2, Gy);
                double rx = m.W * s * (0.7 + 0.6 * p);
                c.Translate(X, Gy); c.Scale(1, 0.2); c.Translate(-X, -Gy);
                c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { X, Gy, 0, X, Gy, rx } }.Add(0, Rgba("#ffffff", 0.8 * p)).Add(0.4, Rgba(cl, 0.5 * p)).Add(1, Rgba(cl, 0));
                c.BeginPath(); c.Arc(X, Gy, rx, 0, TAU); c.Fill(); c.Restore();
            }
        }

        void DrawUpFx(Canvas2D c, bool front)
        {
            var m = Ch?.M; var C = _charge; double B = _burst, T = Time; if (m == null || (C == null && B < 0.01)) return;
            double cx = _mo.X, cy = -m.H * 0.5 + _lift; int i = C != null ? C.I : _burstI; bool rb = ChestModels.TIER[i].Rb; string col = ChestModels.TIER[i].Fx, hue = RB[(int)Math.Floor(T * 8) % 5];
            void Wedge(double L, double a, double w, string cl, double al)
            {
                c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { cx, cy, 0, cx, cy, L } }.Add(0, Rgba("#ffffff", al)).Add(0.32, Rgba(cl, 0.7 * al)).Add(1, Rgba(cl, 0));
                c.BeginPath(); c.MoveTo(cx, cy); c.Arc(cx, cy, L, a - w, a + w); c.ClosePath(); c.Fill();
            }
            void Orbit(bool half)
            {
                if (C == null || i < 3) return;
                int n = rb ? 3 : 1; double k = Math.Min(1, C.K * 1.4);
                for (int j = 0; j < n; j++)
                {
                    double tl = (j - (n - 1) / 2.0) * 0.55, rx = m.W * (0.72 + 0.08 * j), ry = m.W * 0.2, sp = T * (2.4 + j * 0.7) * (j % 2 == 1 ? -1 : 1); int N = 36;
                    for (int q = 0; q < N; q++)
                    {
                        double a0 = (double)q / N * TAU, a1 = (q + 1.15) / N * TAU, am = (a0 + a1) / 2; if ((Math.Sin(am) > 0) != half) continue;
                        (double, double) Pt(double a) { double x = Math.Cos(a + sp) * rx, y = Math.Sin(a) * ry; return (cx + x * Math.Cos(tl) - y * Math.Sin(tl), cy + x * Math.Sin(tl) + y * Math.Cos(tl)); }
                        var p0 = Pt(a0); var p1 = Pt(a1);
                        c.StrokeStyle = Rgba(rb ? RB[(q + (int)Math.Floor(T * 10)) % 5] : (q % 2 == 1 ? "#ffd23a" : "#fff6c0"), 0.85 * k); c.LineWidth = 4 + 2 * Math.Sin(am); c.LineCap = "round";
                        c.BeginPath(); c.MoveTo(p0.Item1, p0.Item2); c.LineTo(p1.Item1, p1.Item2); c.Stroke();
                    }
                }
            }
            c.Save(); c.GlobalCompositeOperation = "lighter";
            if (!front)
            {
                if (C != null)
                {
                    double k = C.K;
                    for (int j = 0; j < C.Beams.Count; j++)
                    {
                        var b = C.Beams[j]; if (k < b.at) continue; double e = Math.Min(1, (k - b.at) / 0.15);
                        Wedge(m.W * (0.8 + 1.7 * k) * b.l * (0.85 + 0.15 * Math.Sin(T * 30 + b.f)), b.a + T * (0.2 + 0.3 * k), b.w * (0.6 + k), rb ? RB[j % 5] : col, 0.85 * e);
                    }
                    double R = m.W * (0.3 + 0.55 * k);
                    c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { cx, cy, 0, cx, cy, R } }.Add(0, Rgba("#ffffff", 0.8 * k)).Add(0.5, Rgba(rb ? hue : col, 0.5 * k)).Add(1, Rgba(col, 0));
                    c.FillRect(cx - R, cy - R, R * 2, R * 2);
                    Orbit(false);
                }
                if (B > 0.01)
                {
                    int N = 16 + 6 * i; double L = m.W * (1.5 + 2.4 * (1 - B)), rot = T * 0.4;
                    for (int j = 0; j < N; j++) Wedge(L * (j % 3 != 0 ? 1 : 1.35), rot + (double)j / N * TAU, j % 2 == 1 ? 0.035 : 0.075, rb ? RB[j % 5] : (j % 2 == 1 ? col : "#ffffff"), B);
                    double R = m.W * (0.6 + 1.3 * (1 - B));
                    c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { cx, cy, 0, cx, cy, R } }.Add(0, Rgba("#ffffff", B)).Add(0.45, Rgba(rb ? hue : col, 0.6 * B)).Add(1, Rgba(col, 0));
                    c.FillRect(cx - R, cy - R, R * 2, R * 2);
                }
            }
            else
            {
                Orbit(true);
                double f = C != null ? Math.Max(0, (C.K - 0.55) / 0.45) * (0.5 + 0.12 * i) : B * B;
                if (f > 0.01)
                {
                    double w = m.W * (1 + 1.9 * f), h = 3 + 7 * f; string cl = rb ? hue : col;
                    c.FillStyle = new CanvasPaint { Kind = 'l', Args = new[] { cx - w, 0, cx + w, 0 } }.Add(0, Rgba(cl, 0)).Add(0.5, Rgba("#ffffff", Math.Min(1, 0.9 * f))).Add(1, Rgba(cl, 0));
                    c.FillRect(cx - w, cy - h / 2, w * 2, h);
                    double vh = w * 0.45;
                    c.FillStyle = new CanvasPaint { Kind = 'l', Args = new[] { 0, cy - vh, 0, cy + vh } }.Add(0, Rgba(cl, 0)).Add(0.5, Rgba("#ffffff", Math.Min(1, 0.7 * f))).Add(1, Rgba(cl, 0));
                    c.FillRect(cx - h * 0.35, cy - vh, h * 0.7, vh * 2);
                }
            }
            c.Restore();
        }

        void DrawP(Canvas2D c, P p)
        {
            double k = p.T / p.Life, fade = p.Life - p.T < 0.4 ? (p.Life - p.T) / 0.4 : 1;
            if (p.Type == "dust")
            {
                double s = p.S * (1 + k * 1.4), a = p.A * Math.Pow(1 - k, 1.6);
                c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { p.X - s * 0.2, p.Y - s * 0.25, 0, p.X, p.Y, s } }.Add(0, Rgba("#ffffff", a)).Add(0.45, Rgba(p.C, a * 0.85)).Add(1, Rgba(p.C, 0));
                c.BeginPath(); c.Arc(p.X, p.Y, s, 0, TAU); c.Fill(); return;
            }
            if (p.Type == "ring" || p.Type == "gring")
            {
                double r = p.R0 + (p.R1 - p.R0) * (1 - Math.Pow(1 - k, 2.4));
                c.Save(); if (p.Lw != 0) c.GlobalCompositeOperation = "lighter"; c.StrokeStyle = Rgba(p.C, (1 - k) * 0.95); c.LineWidth = (p.Lw != 0 ? p.Lw : 6) * (1 - k) + 1; c.Translate(p.X, p.Y); if (p.Type == "gring") c.Scale(1, 0.22);
                c.BeginPath(); c.Arc(0, 0, r, 0, TAU); c.Stroke(); c.Restore(); return;
            }
            if (p.Type == "iring")
            {
                double r = p.R0 + (p.R1 - p.R0) * k * k;
                c.Save(); c.GlobalCompositeOperation = "lighter"; c.StrokeStyle = Rgba(p.C, Math.Min(1, k * 2.5) * 0.85); c.LineWidth = p.Lw * (0.4 + k); c.BeginPath(); c.Arc(p.X, p.Y, r, 0, TAU); c.Stroke(); c.Restore(); return;
            }
            if (p.Type == "mote" || p.Type == "star" || p.Type == "spark")
            {
                c.Save(); c.GlobalCompositeOperation = "lighter";
                if (p.Type == "spark") { c.StrokeStyle = Rgba(p.C, 1 - k); c.LineWidth = 2.2; c.LineCap = "round"; c.BeginPath(); c.MoveTo(p.X, p.Y); c.LineTo(p.X - p.Vx * 0.03, p.Y - p.Vy * 0.03); c.Stroke(); }
                else if (p.Type == "mote") { c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { p.X, p.Y, 0, p.X, p.Y, p.S } }.Add(0, "rgba(255,255,255,0.95)").Add(0.4, Rgba(p.C, 0.8)).Add(1, Rgba(p.C, 0)); c.BeginPath(); c.Arc(p.X, p.Y, p.S, 0, TAU); c.Fill(); }
                else
                {
                    double s = p.S * Math.Sin(Math.PI * Math.Min(1, k * 1.1 + 0.05));
                    c.FillStyle = Rgba(p.C, 0.95); c.Translate(p.X, p.Y); c.Rotate(p.T * 3);
                    c.BeginPath(); c.MoveTo(0, -s); c.LineTo(s * 0.22, -s * 0.22); c.LineTo(s, 0); c.LineTo(s * 0.22, s * 0.22); c.LineTo(0, s); c.LineTo(-s * 0.22, s * 0.22); c.LineTo(-s, 0); c.LineTo(-s * 0.22, -s * 0.22); c.ClosePath(); c.Fill();
                }
                c.Restore(); return;
            }
            c.Save(); c.GlobalAlpha = fade; c.Translate(p.X, p.Y); c.Rotate(p.R);
            switch (p.Type)
            {
                case "chip":
                    c.BeginPath(); for (int i = 0; i < p.V.Length; i++) { if (i > 0) c.LineTo(p.V[i][0], p.V[i][1]); else c.MoveTo(p.V[i][0], p.V[i][1]); } c.ClosePath(); c.FillStyle = p.C; c.Fill(); c.StrokeStyle = "rgba(40,15,5,0.35)"; c.LineWidth = 1; c.Stroke(); break;
                case "shred":
                    { double sx = Math.Cos(p.T * p.Vf); c.Scale(sx == 0 ? 0.1 : sx, 1); }
                    c.FillStyle = p.C; c.BeginPath(); c.MoveTo(-p.W / 2, -p.H / 2); c.LineTo(p.W / 2, -p.H / 2 + 1.5); c.LineTo(p.W / 2 - 1, p.H / 2); c.LineTo(-p.W / 2 + 1.5, p.H / 2 - 1); c.ClosePath(); c.Fill(); c.StrokeStyle = "rgba(90,50,15,0.3)"; c.LineWidth = 0.8; c.Stroke(); break;
                case "splinter":
                    c.FillStyle = p.C; c.BeginPath(); c.MoveTo(-p.W / 2, 0); c.LineTo(-p.W / 4, -p.H / 2); c.LineTo(p.W / 2, -p.H / 4); c.LineTo(p.W / 3, p.H / 2); c.ClosePath(); c.Fill(); c.StrokeStyle = "rgba(70,30,5,0.5)"; c.LineWidth = 0.8; c.Stroke(); break;
                case "bolt":
                    c.FillStyle = new CanvasPaint { Kind = 'r', Args = new[] { -p.S * 0.3, -p.S * 0.3, 0, 0, 0, p.S } }.Add(0, "#ffffff").Add(0.5, "#c9d3e0").Add(1, "#5f6b80"); c.BeginPath(); c.Arc(0, 0, p.S, 0, TAU); c.Fill(); break;
                case "gem":
                    { double s = p.S; c.FillStyle = p.C; c.BeginPath(); c.MoveTo(0, -s); c.LineTo(s * 0.8, s * 0.6); c.LineTo(-s * 0.7, s * 0.7); c.ClosePath(); c.Fill(); c.StrokeStyle = "rgba(255,255,255,0.9)"; c.LineWidth = 1.2; c.BeginPath(); c.MoveTo(0, -s); c.LineTo(-s * 0.7, s * 0.7); c.Stroke(); }
                    break;
                case "loot": ChestModels.DrawIcon(c, p.K, p.S, p.C); break;
                case "drop":
                    { c.Rotate(Math.Atan2(p.Vy, p.Vx) - p.R + Math.PI / 2); double s = p.S; c.BeginPath(); c.MoveTo(0, s * 1.6); c.BezierCurveTo(s * 0.6, s * 0.6, s, 0, s, -s * 0.2); c.Arc(0, -s * 0.2, s, 0, Math.PI, true); c.BezierCurveTo(-s, 0, -s * 0.6, s * 0.6, 0, s * 1.6); c.FillStyle = p.C; c.Fill(); c.FillStyle = "rgba(255,255,255,0.6)"; c.BeginPath(); c.Arc(-s * 0.35, -s * 0.35, s * 0.3, 0, TAU); c.Fill(); }
                    break;
                case "bubble":
                    c.Rotate(-p.R); c.StrokeStyle = "rgba(255,255,255,0.9)"; c.LineWidth = 1.4; c.BeginPath(); c.Arc(0, 0, p.S, 0, TAU); c.Stroke(); c.FillStyle = "rgba(190,240,255,0.25)"; c.Fill(); c.FillStyle = "rgba(255,255,255,0.9)"; c.BeginPath(); c.Arc(-p.S * 0.35, -p.S * 0.35, p.S * 0.25, 0, TAU); c.Fill(); break;
                case "fluff":
                    c.FillStyle = p.C;
                    foreach (var (x, y, kk) in new[] { (0.0, 0.0, 1.0), (p.S * 0.6, -p.S * 0.2, 0.7), (-p.S * 0.5, p.S * 0.3, 0.65) }) { c.BeginPath(); c.Arc(x, y, p.S * kk, 0, TAU); c.Fill(); }
                    c.FillStyle = "rgba(255,255,255,0.5)"; c.BeginPath(); c.Arc(-p.S * 0.3, -p.S * 0.3, p.S * 0.35, 0, TAU); c.Fill(); break;
            }
            c.Restore();
        }
    }
}
