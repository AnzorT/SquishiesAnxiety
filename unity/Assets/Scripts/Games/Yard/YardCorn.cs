// CORNHOLE (yg-corn.js): pull back from anywhere and let go to toss a bean bag (further = farther, to one side = aim
// the other way); the wind (the flag, the pill) drifts it. 8 bags: on the board 1, in the hole 3 (Airmail!); bags
// slide, knock each other, fall off the board.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardCorn : YardGame
    {
        public YardCorn()
        {
            Id = "corn"; Name = "Cornhole"; Item = "Cornhole Boards"; Color = "#4f8fff"; Stars = new double[] { 8, 13, 18 }; CoinK = 2;
            Hint = "Pull back and let go to toss · mind the wind";
            How = new[] { "Pull back from anywhere and let go to toss your bean bag.", "Pull further to throw farther; pull to one side to aim the other way.", "8 bags. On the board = 1, in the hole = 3. Watch the wind flag!" };
        }

        const double G = 9.8, BW = 0.86, ZF = 3.0, ZB = 4.6, YF = 0.08, YB = 0.34, HZ = 4.3, HR = 0.115, BS = 0.075, mz = 0.42, mx = -0.42;
        static readonly double[] REL = { mx + 0.2, 0.72, mz + 0.18 };
        Func<double, double, double, double[]> P;
        El restG, shG, flyG, guideG, cloth; double[] fp2; YardCreature me;
        sealed class Bag { public El g, sh, b, st; public double x, y, z, vx, vy, vz, rot, vr, sp, ht; public string st8 = "hand"; public double[] dir = { 0, 1 }; }
        List<Bag> bags = new List<Bag>(); Bag cur; int left = 8, inHole; double wind, tNow, throwT = -9, settleT; string phase = "aim";
        (double x0, double y0, double x, double y)? drag;

        static double? yb(double x, double z) => Math.Abs(x) <= BW / 2 && z >= ZF && z <= ZB ? lerp(YF, YB, (z - ZF) / (ZB - ZF)) : (double?)null;

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg; P = cam(2.4, 1.45, 210, 269);
            yard(bg, 210);
            El quad(double[][] pts, El p, params object[] a) { var e = S("path", p ?? bg, "d", "M" + string.Join("L", Array.ConvertAll(pts, q => { var s = P(q[0], q[1], q[2]); return N(s[0]) + " " + N(s[1]); })) + "Z"); for (int i = 0; i + 1 < a.Length; i += 2) e.Set((string)a[i], a[i + 1]); return e; }
            double[][] Q(params double[] v) { var o = new double[v.Length / 3][]; for (int i = 0; i < o.Length; i++) o[i] = new[] { v[3 * i], v[3 * i + 1], v[3 * i + 2] }; return o; }
            var boardG = S("g", bg);
            {
                var g0 = P(0, 0, (ZF + ZB) / 2); shadow(boardG, g0[0], g0[1] + 6, 0.62 * g0[2], 0.2);
                foreach (var x in new[] { -BW / 2 + 0.06, BW / 2 - 0.06 }) quad(Q(x - 0.025, 0, ZB - 0.05, x + 0.025, 0, ZB - 0.05, x + 0.025, YB, ZB - 0.05, x - 0.025, YB, ZB - 0.05), boardG, "fill", "#1d4fa0");
                quad(Q(-BW / 2, YF - 0.06, ZF, BW / 2, YF - 0.06, ZF, BW / 2, YF, ZF, -BW / 2, YF, ZF), boardG, "fill", "#2a5fb0");
                quad(Q(-BW / 2, YF, ZF, BW / 2, YF, ZF, BW / 2, YB, ZB, -BW / 2, YB, ZB), boardG, "fill", "#3b7fe0");
                quad(Q(-BW / 2 + 0.04, YF + 0.003, ZF + 0.04, BW / 2 - 0.04, YF + 0.003, ZF + 0.04, BW / 2 - 0.04, YB + 0.003, ZB - 0.04, -BW / 2 + 0.04, YB + 0.003, ZB - 0.04), boardG, "fill", "none", "stroke", "#ffffff", "stroke-width", 1.6, "opacity", 0.55);
                double zm = ZF + 0.55; quad(Q(-BW / 2, lerp(YF, YB, (zm - ZF) / 1.6), zm, BW / 2, lerp(YF, YB, (zm - ZF) / 1.6), zm, BW / 2, lerp(YF, YB, (zm + 0.08 - ZF) / 1.6), zm + 0.08, -BW / 2, lerp(YF, YB, (zm + 0.08 - ZF) / 1.6), zm + 0.08), boardG, "fill", "#ffffff", "opacity", 0.8);
                var d = ""; for (int i = 0; i <= 24; i++) { double a = i / 24.0 * Math.PI * 2, x = Math.Cos(a) * HR, z = HZ + Math.Sin(a) * HR; var s = P(x, lerp(YF, YB, (z - ZF) / 1.6) + 0.002, z); d += (i > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1]); }
                S("path", boardG, "d", d + "Z", "fill", "#14213a", "stroke", "#2a5fb0", "stroke-width", 1.5);
            }
            restG = S("g", bg); shG = S("g", bg); flyG = S("g", fg); guideG = S("g", fg);
            var flag = S("g", bg); var fp = P(BW / 2 + 0.45, 0, ZB - 0.1); fp2 = P(BW / 2 + 0.45, 1.25, ZB - 0.1); S("path", flag, "d", "M" + N(fp[0]) + " " + N(fp[1]) + "L" + N(fp2[0]) + " " + N(fp2[1]), "stroke", "#ffffff", "stroke-width", 2.4);
            cloth = S("path", flag, "fill", "#ffcf3a", "stroke", "#e09a14", "stroke-width", 1);
            me = c.creature(c.playerKey, yaw: 198); var mp = P(mx, 0, mz); me.set(mp[0], mp[1], 0.78 * mp[2]); shadow(shG, mp[0], mp[1] - 2, 0.3 * mp[2], 0.2);
            NewWind(); cur = MkBag();
        }

        Bag MkBag()
        {
            var g = S("g", flyG);
            return new Bag { g = g, sh = S("ellipse", shG, "fill", "#3a2a55", "opacity", 0.18), b = S("path", g, "fill", "#e8483c", "stroke", "#b5322a", "stroke-width", 1), st = S("path", g, "fill", "none", "stroke", "#ffd2cc", "stroke-width", 0.9, "stroke-dasharray", "1.6 1.6"), x = REL[0], y = REL[1], z = REL[2] };
        }
        void NewWind() { wind = Math.Round((ctx.rand() - 0.5) * 2 * 6, MidpointRounding.AwayFromZero) / 10; ctx.Badge = wind == 0 ? "No wind" : "Wind " + (wind < 0 ? "← " : "→ ") + Math.Abs(wind).ToString("F1", System.Globalization.CultureInfo.InvariantCulture); }
        (double vx, double vy, double vz) Vel(double px, double py)
        {
            double len = Math.Sqrt(px * px + py * py), p = cl(len / 220, 0.05, 1.3), a = Math.Atan2(-px, py), th = 38 * Math.PI / 180, v = 3.6 + p * 4.2, ph = Math.Atan2(-REL[0], HZ - REL[2]) + a * 0.42;
            return (Math.Sin(ph) * v * Math.Cos(th), v * Math.Sin(th), Math.Cos(ph) * v * Math.Cos(th));
        }
        void Toss(double px, double py)
        {
            if (cur == null || phase != "aim") return; double len = Math.Sqrt(px * px + py * py); if (py < 18 || len < 30) { cur.st8 = "hand"; return; }
            var (vx, vy, vz) = Vel(px, py); cur.st8 = "fly"; cur.vx = vx; cur.vz = vz; cur.vy = vy; cur.vr = (ctx.rand() - 0.5) * 700;
            bags.Add(cur); cur = null; left--; phase = "fly"; throwT = tNow; ctx.sfx("whoosh"); ctx.timer("Bags " + left);
        }
        int Tally() { int s = 0; inHole = 0; foreach (var b in bags) { if (b.st8 == "hole") { s += 3; inHole++; } else if ((b.st8 == "board" || b.st8 == "slide") && yb(b.x, b.z) != null) s += 1; } return s; }
        void Settle() { int now = Tally(); if (now != ctx.score) ctx.setScore(now); }
        void Hole(Bag b, double t, string txt, int n) { b.st8 = "hole"; b.ht = t; ctx.sfx("swish"); ctx.Later(60, () => ctx.sfx("score")); var s = P(0, YB, HZ); ctx.toast(txt, s[0], s[1] - 40, "#ffe36e"); ctx.burst(s[0], s[1], "confetti", n); }

        public override void Start() { foreach (var b in bags) { b.g.Remove(); b.sh.Remove(); } bags = new List<Bag>(); left = 8; cur ??= MkBag(); phase = "aim"; ctx.setScore(0); ctx.timer("Bags 8"); NewWind(); }
        public override void Down(double x, double y, double t) { if (phase == "aim" && cur != null) drag = (x, y, x, y); }
        public override void Move(double x, double y, double t) { if (drag != null) drag = (drag.Value.x0, drag.Value.y0, x, y); }
        public override void Up(double x, double y, double t) { if (drag == null) return; var d = drag.Value; drag = null; Toss(x - d.x0, y - d.y0); }
        public override void Celebrate(int st) { me.yaw(0); me.play(st >= 2 ? "happy" : "idle"); }

        public override void Update(double dt, double t)
        {
            tNow = t;
            foreach (var b in bags)
            {
                const int n = 4;
                for (int i = 0; i < n; i++)
                {
                    double h = dt / n;
                    if (b.st8 == "fly")
                    {
                        b.vy -= G * h; b.vx += wind * h; b.x += b.vx * h; b.y += b.vy * h; b.z += b.vz * h; b.rot += b.vr * h; var y0 = yb(b.x, b.z);
                        if (y0 != null && b.y <= y0 + 0.02)
                        {
                            if (Math.Sqrt(b.x * b.x + (b.z - HZ) * (b.z - HZ)) < HR - 0.02) Hole(b, t, "Airmail! +3", 14);
                            else { b.st8 = "slide"; b.y = y0.Value + 0.02; double hl = Math.Sqrt(b.vx * b.vx + b.vz * b.vz); b.sp = hl * 0.5; if (hl == 0) hl = 1; b.dir = new[] { b.vx / hl, b.vz / hl }; b.vr *= 0.2; ctx.sfx("thud"); }
                        }
                        else if (b.y <= 0.03) { b.st8 = "grass"; b.y = 0.03; ctx.sfx("thud"); }
                    }
                    else if (b.st8 == "slide")
                    {
                        b.sp = Math.Max(0, b.sp - 3.2 * h); b.x += b.dir[0] * b.sp * h; b.z += b.dir[1] * b.sp * h; b.rot += b.vr * h * 0.2; var y0 = yb(b.x, b.z);
                        if (y0 == null) { b.st8 = "fall"; b.vy = 0; b.vx = b.dir[0] * b.sp; b.vz = b.dir[1] * b.sp; }
                        else
                        {
                            b.y = y0.Value + 0.02;
                            if (Math.Sqrt(b.x * b.x + (b.z - HZ) * (b.z - HZ)) < HR - 0.035) Hole(b, t, "In the hole! +3", 12);
                            foreach (var o in bags)
                                if (o != b && (o.st8 == "board" || o.st8 == "slide") && Math.Sqrt((o.x - b.x) * (o.x - b.x) + (o.z - b.z) * (o.z - b.z)) < BS * 2)
                                {
                                    double nx = o.x - b.x, nz = o.z - b.z, nl = Math.Sqrt(nx * nx + nz * nz); if (nl == 0) nl = 1;
                                    o.st8 = "slide"; o.dir = new[] { nx / nl, nz / nl }; o.sp = Math.Max(o.sp, b.sp * 0.75); b.sp *= 0.3; o.x = b.x + o.dir[0] * BS * 2.02; o.z = b.z + o.dir[1] * BS * 2.02; ctx.sfx("tap");
                                }
                            if (b.sp <= 0) b.st8 = "board";   // (as the page: even right after the hole)
                        }
                    }
                    else if (b.st8 == "fall") { b.vy -= G * h; b.x += b.vx * h; b.z += b.vz * h; b.y += b.vy * h; if (b.y <= 0.03) { b.y = 0.03; b.st8 = "grass"; } }
                }
            }
            if (phase == "fly" && !bags.Exists(b => b.st8 == "fly" || b.st8 == "slide" || b.st8 == "fall") && t - throwT > 500)
            {
                Settle(); phase = "wait"; settleT = t; var last = bags[bags.Count - 1];
                if (last.st8 == "board") ctx.toast("On the board +1", W / 2, 250, "#ffffff"); else if (last.st8 == "grass") ctx.toast(last.z < ZF ? "Short" : "Missed", W / 2, 250, "#ffffff");
            }
            if (phase == "wait" && t - settleT > 650)
            {
                if (left > 0) { cur = MkBag(); phase = "aim"; NewWind(); }
                else { phase = "done"; Settle(); ctx.finish(new Dictionary<string, object> { ["sub"] = inHole + " in the hole · " + bags.FindAll(b => b.st8 == "board").Count + " on the board" }); }
            }
            double pull = drag != null ? cl(Math.Sqrt(Math.Pow(drag.Value.x - drag.Value.x0, 2) + Math.Pow(drag.Value.y - drag.Value.y0, 2)) / 200, 0, 1) : 0, ts = t - throwT;
            var E = ts < 600 ? track(new List<(double, Dictionary<string, double>)> { (0, P_("armR", -40, "lean", -4, "sq", 0.04)), (120, P_("armR", 165, "lean", 6, "sq", -0.06, "lift", 2)), (600, P_("armR", 20, "lean", 0, "sq", 0, "lift", 0)) }, ts)
                : P_("armR", lerp(30, -60, pull), "lean", -6 * pull, "sq", 0.06 * pull, "armL", 20 + 30 * pull);
            me.pose(E); me.yaw(198 + Math.Sin(t / 1100) * 4);
            {
                double k = wind, w = 22 * (k == 0 ? 0.25 : Math.Min(1, Math.Abs(k) / 0.6 + 0.3)), sg = k == 0 ? 1 : Math.Sign(k), wv = Math.Sin(t / 120) * 3; var bs = fp2;
                cloth.Set("d", "M" + N(bs[0]) + " " + N(bs[1]) + "Q" + N(bs[0] + sg * w * 0.5) + " " + N(bs[1] + wv + (k == 0 ? 8 : 0)) + " " + N(bs[0] + sg * w) + " " + N(bs[1] + 5 + wv * 0.5 + (k == 0 ? 10 : 0)) + "L" + N(bs[0]) + " " + N(bs[1] + 13) + "Z");
            }
            if (cur != null) { cur.x = REL[0] - 0.08 * pull; cur.y = REL[1] - 0.12 * pull + Math.Sin(t / 380) * 0.01; cur.z = REL[2] - 0.1 * pull; }
            var all = new List<Bag>(); if (cur != null) all.Add(cur); all.AddRange(bags);
            foreach (var b in all)
            {
                bool onB = b.st8 == "board" || b.st8 == "slide" || b.st8 == "grass" || b.st8 == "hole";
                if (onB && b.g.Parent != restG) restG.Add(b.g); var s = P(b.x, b.y, b.z); double sc = s[2] * BS, o = 1, sq = onB ? 0.42 : 0.9;
                if (b.st8 == "hole") { double u = cl((t - b.ht) / 260, 0, 1); o = 1 - u; sq = 0.42 * (1 - u * 0.5); }
                double rr = b.rot, cs = Math.Cos(rr * Math.PI / 180), sn = Math.Sin(rr * Math.PI / 180);
                var pts = new List<double[]>(); foreach (var (u, v) in new[] { (-1, -1), (1, -1), (1, 1), (-1, 1) }) { double X = u * cs - v * sn, Y = (u * sn + v * cs) * sq; pts.Add(new[] { s[0] + X * sc, s[1] + Y * sc }); }
                double[] m(double[] a, double[] bb) => new[] { (a[0] + bb[0]) / 2, (a[1] + bb[1]) / 2 };
                var m0 = m(pts[3], pts[0]); var d = "M" + N(m0[0]) + " " + N(m0[1]);
                for (int i = 0; i < 4; i++) { var a = pts[i]; var mm = m(a, pts[(i + 1) % 4]); d += "Q" + N(a[0]) + " " + N(a[1]) + " " + N(mm[0]) + " " + N(mm[1]); }
                b.b.Set("d", d + "Z"); b.st.Set("d", d + "Z"); b.st.Set("transform", "translate(" + N(s[0] * 0.18) + " " + N(s[1] * 0.18) + ") scale(0.82)"); b.g.Set("opacity", r2(o));
                var g0y = yb(b.x, b.z); double gy = g0y != null && b.st8 != "grass" && b.st8 != "fall" ? g0y.Value : 0; var gs = P(b.x, gy, b.z); double hk = cl(1 - (b.y - gy) / 1.5, 0.3, 1);
                b.sh.Set("cx", r2(gs[0])); b.sh.Set("cy", r2(gs[1])); b.sh.Set("rx", r2(sc * 1.1 * hk)); b.sh.Set("ry", r2(sc * 0.35 * hk)); b.sh.Set("opacity", b.st8 == "hole" ? 0 : r2(0.22 * hk));
            }
            guideG.Clear();
            if (drag != null && cur != null)
            {
                double px = drag.Value.x - drag.Value.x0, py = drag.Value.y - drag.Value.y0;
                if (py > 18)
                {
                    var (vx, vy, vz) = Vel(px, py); double x = cur.x, y = cur.y, z = cur.z;
                    for (int i = 0; i < 9; i++) { const double h = 0.045; vy -= G * h; x += vx * h; y += vy * h; z += vz * h; var s = P(x, y, z); S("circle", guideG, "cx", r2(s[0]), "cy", r2(s[1]), "r", r2(Math.Max(1.5, 3.4 - i * 0.2)), "fill", "#ffffff", "opacity", r2(0.9 - i * 0.08)); }
                }
            }
        }
        static Dictionary<string, double> P_(params object[] kv) => YK.P(kv);
    }
}
