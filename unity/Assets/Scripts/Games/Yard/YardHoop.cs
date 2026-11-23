// HOOP SHOT (yg-hoop.js): flick up from your creature to shoot; the flick's direction aims, its length is the power.
// Real ball physics in metres: the rim (a ring the ball can rattle on), backboard bank shots, the net, bounces on the
// driveway. Swish +3, rim-in / bank +2, 3 in a row = On fire (double points). From 20 points the hoop slides. 45 s.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardHoop : YardGame
    {
        public YardHoop()
        {
            Id = "hoop"; Name = "Hoop Shot"; Item = "Basketball Hoop"; Color = "#ff9a4a"; Dur = 45; Stars = new double[] { 16, 32, 50 }; CoinK = 0.5;
            Hint = "Flick up to shoot · longer flick = harder throw";
            How = new[] { "Flick up from your creature to shoot the ball.", "Aim with the direction, power with the length.", "Swish = 3, rim or bank = 2. Three in a row sets you on fire!" };
            Icon = "<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"58\" width=\"120\" height=\"26\" fill=\"#9fdc6e\"/><path d=\"M14 84L36 58H84L106 84Z\" fill=\"#d9d4cc\"/>"
                + "<rect x=\"57\" y=\"22\" width=\"5\" height=\"40\" rx=\"2\" fill=\"#3a3a44\"/><rect x=\"38\" y=\"8\" width=\"44\" height=\"28\" rx=\"3\" fill=\"#fff\" stroke=\"#e8483c\" stroke-width=\"2.5\"/><rect x=\"51\" y=\"18\" width=\"18\" height=\"12\" fill=\"none\" stroke=\"#e8483c\" stroke-width=\"2\"/>"
                + "<ellipse cx=\"60\" cy=\"34\" rx=\"10\" ry=\"3\" fill=\"none\" stroke=\"#f07a2e\" stroke-width=\"2.4\"/><path d=\"M51 35L54 46H66L69 35M55 35L57 46M65 35L63 46M60 35V46\" stroke=\"#fff\" stroke-width=\"1.2\" fill=\"none\"/>"
                + "<circle cx=\"34\" cy=\"40\" r=\"9\" fill=\"#f07a2e\"/><path d=\"M25 40H43M34 31V49M27.5 33.5Q34 40 27.5 46.5M40.5 33.5Q34 40 40.5 46.5\" stroke=\"#7a3410\" stroke-width=\"1.2\" fill=\"none\"/></svg>";
        }

        const double G = 9.8, BR = 0.12, RR = 0.23, RT = 0.018, RY = 3.05, RZ = 3.8, BZ = 4.18, PZ = 4.5;
        Func<double, double, double, double[]> P;
        El hoopG, backG, slotB, frontG, slotF, shG, guide;
        double hx, netSw, netAt = -9;
        YardCreature me;
        static readonly double[] HOLD = { 0, 1.0, 0.36 };
        sealed class Ball { public El g, sh, b, sm, hl, fl; public double x, y, z, vx, vy, vz, spin, t; public string st = "hold"; public int rim, board, bounces, fire; public bool scored, missed; }
        readonly List<Ball> balls = new List<Ball>(); Ball held;
        double nextAt, shotT = -9, cheerT = -9, clangAt, tNow; int streak, fire, made; bool moving;
        (double x, double y, double x0, double y0)? drag;

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg; P = cam(2.4, 1.9, 210, 189);
            yard(bg, 210);
            El quad(double[][] pts, El p, params object[] a)
            {
                var d = "M" + string.Join("L", Array.ConvertAll(pts, q => { var s = P(q[0], 0, q[1]); return N(s[0]) + " " + N(s[1]); })) + "Z";
                var e = S("path", p ?? bg, "d", d); for (int i = 0; i + 1 < a.Length; i += 2) e.Set((string)a[i], a[i + 1]); return e;
            }
            double[][] Q(params double[] v) { var o = new double[v.Length / 2][]; for (int i = 0; i < o.Length; i++) o[i] = new[] { v[2 * i], v[2 * i + 1] }; return o; }
            quad(Q(-2.6, -0.6, 2.6, -0.6, 2.6, 6.5, -2.6, 6.5), null, "fill", "#d9d4cc"); quad(Q(-2.6, -0.6, 2.6, -0.6, 2.6, -0.45, -2.6, -0.45), null, "fill", "#c5beb3");
            for (double z = 0.6; z < 6.4; z += 1.2) quad(Q(-2.6, z, 2.6, z, 2.6, z + 0.02, -2.6, z + 0.02), null, "fill", "#c9c2b7");
            quad(Q(-0.9, 1.6, 0.9, 1.6, 0.9, 4.4, -0.9, 4.4), null, "fill", "none", "stroke", "#ffffff", "stroke-width", 2.2, "opacity", 0.9);
            { var d = ""; for (int i = 0; i <= 20; i++) { double a = Math.PI * i / 20; var s = P(Math.Cos(a) * 0.9, 0, 1.6 - Math.Sin(a) * 0.9); d += (i > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1]); } S("path", bg, "d", d, "fill", "none", "stroke", "#ffffff", "stroke-width", 2.2, "opacity", 0.9); }
            hoopG = S("g", bg); backG = S("g", hoopG); slotB = S("g", hoopG); frontG = S("g", hoopG); slotF = S("g", fg); shG = new El("g");
            bg.InsertBefore(shG, hoopG);
            me = c.creature(c.playerKey, yaw: 180); var f0 = P(0, 0, 0.25); me.set(f0[0], f0[1], 1.12 * f0[2]); shadow(shG, f0[0], f0[1] - 2, 42, 0.2);
            DrawHoop(0); held = MkBall();
        }

        void DrawHoop(double t)
        {
            backG.Clear(); frontG.Clear();
            var pb = P(hx, 0, PZ); var pt2 = P(hx, 3.55, PZ); shadow(backG, pb[0], pb[1], 16, 0.22);
            S("rect", backG, "x", r2(pb[0] - 4), "y", r2(pt2[1]), "width", 8, "height", r2(pb[1] - pt2[1]), "rx", 3, "fill", "#3a3a44"); S("rect", backG, "x", r2(pb[0] - 1.5), "y", r2(pt2[1]), "width", 2, "height", r2(pb[1] - pt2[1]), "fill", "#5a5a66");
            var a1 = P(hx, 3.5, PZ); var a2 = P(hx, 3.4, BZ + 0.02); S("path", backG, "d", "M" + N(a1[0]) + " " + N(a1[1]) + "L" + N(a2[0]) + " " + N(a2[1]), "stroke", "#3a3a44", "stroke-width", 5, "stroke-linecap", "round");
            var b1 = P(hx - 0.9, 3.85, BZ); var b2 = P(hx + 0.9, 2.78, BZ); S("rect", backG, "x", r2(b1[0]), "y", r2(b1[1]), "width", r2(b2[0] - b1[0]), "height", r2(b2[1] - b1[1]), "rx", 3, "fill", "#ffffff", "stroke", "#e8483c", "stroke-width", 3.4);
            S("rect", backG, "x", r2(b1[0] + 3), "y", r2(b1[1] + 3), "width", r2(b2[0] - b1[0] - 6), "height", 5, "rx", 2, "fill", "#eef6ff");
            var s1 = P(hx - 0.3, 3.5, BZ); var s2 = P(hx + 0.3, 3.08, BZ); S("rect", backG, "x", r2(s1[0]), "y", r2(s1[1]), "width", r2(s2[0] - s1[0]), "height", r2(s2[1] - s1[1]), "fill", "none", "stroke", "#e8483c", "stroke-width", 2.6);
            var br = P(hx, RY - 0.02, BZ - 0.01); var c = P(hx, RY, RZ); S("rect", backG, "x", r2(br[0] - 4), "y", r2(br[1] - 2), "width", 8, "height", 5, "rx", 1.5, "fill", "#c8501e");
            double rx = RR * c[2], ry = RR * c[2] * 0.3;
            void arc(double A0, double A1, double w, string col, El g) { var d = ""; for (int i = 0; i <= 16; i++) { double a = A0 + (A1 - A0) * i / 16; var s = P(hx + Math.Cos(a) * RR, RY, RZ + Math.Sin(a) * RR); d += (i > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1]); } S("path", g, "d", d, "fill", "none", "stroke", col, "stroke-width", w, "stroke-linecap", "round"); }
            arc(0, Math.PI, 3.2, "#c8501e", backG);
            double sw = netSw * Math.Sin((t - netAt) / 70) * Math.Exp(-(t - netAt) / 500); var nd = new System.Text.StringBuilder();
            double[][] ring(double yy, double rr, double k) { var o = new double[12][]; for (int i = 0; i < 12; i++) { double a = i / 12.0 * Math.PI * 2; o[i] = P(hx + Math.Cos(a) * rr + sw * 0.05 * k, yy, RZ + Math.Sin(a) * rr); } return o; }
            var r0 = ring(RY, RR, 0); var r1 = ring(RY - 0.22, RR * 0.82, 1); var r2b = ring(RY - 0.42, RR * 0.6, 2);
            for (int i = 0; i < 12; i++) { int j = (i + 1) % 12; nd.Append("M" + N(r0[i][0]) + " " + N(r0[i][1]) + "L" + N(r1[j][0]) + " " + N(r1[j][1]) + "L" + N(r2b[i][0]) + " " + N(r2b[i][1])); nd.Append("M" + N(r0[j][0]) + " " + N(r0[j][1]) + "L" + N(r1[i][0]) + " " + N(r1[i][1]) + "L" + N(r2b[j][0]) + " " + N(r2b[j][1])); }
            S("path", frontG, "d", nd.ToString(), "fill", "none", "stroke", "#ffffff", "stroke-width", 1.1, "opacity", 0.95); arc(Math.PI, Math.PI * 2, 3.6, "#f07a2e", frontG);
            S("ellipse", frontG, "cx", r2(c[0]), "cy", r2(c[1]), "rx", r2(rx), "ry", r2(ry), "fill", "none", "stroke", "#ffb070", "stroke-width", 1, "opacity", 0.6);
        }

        Ball MkBall()
        {
            var g = S("g", slotF);
            return new Ball { g = g, sh = S("ellipse", shG, "fill", "#3a2a55", "opacity", 0.18), b = S("circle", g, "r", 10, "fill", "url(#ygBall)"),
                sm = S("path", g, "fill", "none", "stroke", "#7a3410", "stroke-width", 1.4, "stroke-linecap", "round", "opacity", 0.85), hl = S("ellipse", g, "fill", "#ffffff", "opacity", 0.35),
                fl = S("circle", g, "fill", "none", "stroke", "#ffd84a", "stroke-width", 2, "opacity", 0), x = HOLD[0], y = HOLD[1], z = HOLD[2] };
        }

        void Shoot(double fx, double fy)
        {
            if (held == null) return; double len = Math.Sqrt(fx * fx + fy * fy); if (fy > -18 || len < 30) return;
            double p = cl(len / 230, 0.15, 1.25); var sb = P(held.x, held.y, held.z); var sr = P(hx, RY, RZ); double aT = Math.Atan2(sr[0] - sb[0], sb[1] - sr[1]), a = Math.Atan2(fx, -fy);
            double dx = hx - held.x, dz = RZ + 0.03 - held.z, L = Math.Sqrt(dx * dx + dz * dz), dy = RY - held.y, th = 65 * Math.PI / 180, ct = Math.Cos(th), v0 = Math.Sqrt(G * L * L / (2 * ct * ct * (L * Math.Tan(th) - dy)));
            double v = v0 * (1 + (p - 0.55) * 0.15), ph = Math.Atan2(dx, dz) + (a - aT) * 0.24, vh = v * ct;
            held.st = "fly"; held.vx = Math.Sin(ph) * vh; held.vz = Math.Cos(ph) * vh; held.vy = v * Math.Sin(th); held.t = 0; held.spin = 0; held.fire = fire > 0 ? 1 : 0;
            balls.Add(held); held = null; nextAt = tNow + 520; shotT = tNow; ctx.sfx("whoosh");
        }

        void StepBall(Ball b, double dt)
        {
            double py = b.y, ins0 = Math.Sqrt((b.x - hx) * (b.x - hx) + (b.z - RZ) * (b.z - RZ));
            b.vy -= G * dt; b.x += b.vx * dt; b.y += b.vy * dt; b.z += b.vz * dt; b.spin += dt * 9;
            double rx = b.x - hx, rz = b.z - RZ, d = Math.Sqrt(rx * rx + rz * rz); if (d == 0) d = 1e-6;
            double qx = hx + RR * rx / d, qz = RZ + RR * rz / d, ex = b.x - qx, ey = b.y - RY, ez = b.z - qz, dist = Math.Sqrt(ex * ex + ey * ey + ez * ez);
            if (dist < BR + RT)
            {
                double nx = ex / dist, ny = ey / dist, nz = ez / dist, vn = b.vx * nx + b.vy * ny + b.vz * nz;
                if (vn < 0) { b.vx -= 1.55 * vn * nx; b.vy -= 1.55 * vn * ny; b.vz -= 1.55 * vn * nz; b.vx *= 0.92; b.vz *= 0.92; b.rim++; if (tNow - clangAt > 120) { ctx.sfx("clang"); clangAt = tNow; } }
                b.x = qx + nx * (BR + RT); b.y = RY + ny * (BR + RT); b.z = qz + nz * (BR + RT);
            }
            if (b.vz > 0 && b.z + BR > BZ && b.z < BZ + 0.08 && Math.Abs(b.x - hx) < 0.9 + BR * 0.5 && b.y > 2.78 - BR * 0.5 && b.y < 3.85 + BR * 0.5) { b.vz = -b.vz * 0.6; b.vx *= 0.9; b.z = BZ - BR; b.board++; ctx.sfx("thud"); }
            double din = Math.Sqrt((b.x - hx) * (b.x - hx) + (b.z - RZ) * (b.z - RZ));
            if (b.y < RY && b.y > RY - 0.45 && ins0 < RR && py >= RY - 0.45) { if (din > RR * 0.78 - BR * 0.4) { double k = (RR * 0.78 - BR * 0.4) / din; b.x = hx + (b.x - hx) * k; b.z = RZ + (b.z - RZ) * k; } b.vx *= 0.9; b.vz *= 0.9; b.vy *= 0.97; }
            if (!b.scored && py >= RY && b.y < RY && b.vy < 0 && Math.Sqrt((b.x - hx) * (b.x - hx) + (b.z - RZ) * (b.z - RZ)) < RR - 0.02) Basket(b);
            if (b.y < BR) { b.y = BR; if (Math.Abs(b.vy) > 1.2) { ctx.sfx("thud"); b.bounces++; } b.vy = -b.vy * 0.55; b.vx *= 0.8; b.vz *= 0.8; if (Math.Abs(b.vy) < 0.6) b.vy = 0; }
        }

        void Basket(Ball b)
        {
            b.scored = true; made++; bool sw = b.rim == 0 && b.board == 0; streak++;
            if (streak >= 3 && fire == 0) { fire = 1; ctx.toast("On fire!", W / 2, 150, "#ffb03a", true); ctx.sfx("win"); }
            int pts = (sw ? 3 : 2) * (fire > 0 ? 2 : 1); var c = P(hx, RY, RZ); ctx.add(pts, c[0], c[1] - 34, (sw ? "Swish! +" : "+") + pts, sw ? "#8fe0ff" : "#ffffff");
            ctx.burst(c[0], c[1] + 10, "confetti", 14, new BurstOpts { V = 140, Life = 0.9 }); netSw = 1; netAt = tNow; cheerT = tNow; ctx.sfx("swish"); ctx.Later(80, () => ctx.sfx("score"));
            if (streak % 5 == 0) me.play("happy");
        }

        public override void Start()
        {
            held ??= MkBall(); foreach (var b in balls) { b.g.Remove(); b.sh.Remove(); } balls.Clear(); streak = 0; fire = 0; made = 0; moving = false; hx = 0;
        }
        public override void Down(double x, double y, double t) => drag = (x, y, x, y);
        public override void Move(double x, double y, double t) { if (drag is var d && d != null) drag = (x, y, d.Value.x0, d.Value.y0); }
        public override void Up(double x, double y, double t) { if (drag == null) return; double fx = x - drag.Value.x0, fy = y - drag.Value.y0; drag = null; Shoot(fx, fy); }
        public override bool TimeUp() { ctx.finish(new Dictionary<string, object> { ["sub"] = made + " basket" + (made == 1 ? "" : "s") }); return true; }
        public override void Celebrate(int st) { if (st >= 2) me.play("happy"); }

        public override void Update(double dt, double t)
        {
            tNow = t;
            if (ctx.score >= 20 && !moving) { moving = true; ctx.toast("The hoop moves!", W / 2, 160, "#ffe36e"); }
            if (moving) hx = Math.Sin((t / 1000) * 0.9) * 0.75;
            if (held == null && t > nextAt && ctx.playing) held = MkBall();
            foreach (var b in balls)
            {
                const int n = 4; for (int i = 0; i < n; i++) StepBall(b, dt / n); b.t += dt;
                if (b.st == "fly" && !b.scored && (b.bounces >= 1 || b.t > 2.2) && !b.missed) { b.missed = true; if (streak > 0) { streak = 0; if (fire > 0) { fire = 0; ctx.toast("Fire out", W / 2, 160, "#ffffff"); } } }
            }
            balls.RemoveAll(b => { if (b.t > 3.2) { b.g.Remove(); b.sh.Remove(); return true; } return false; });
            double ts = t - shotT, tc = t - cheerT; bool hasB = held != null;
            var E = track(new List<(double, Dictionary<string, double>)> { (0, P_("armL", 128, "armR", 128, "lift", 0, "sq", 0)), (90, P_("armL", 168, "armR", 168, "lift", 4, "sq", -0.06)), (260, P_("armL", 150, "armR", 150, "lift", 0, "sq", 0.04)), (460, P_("armL", hasB ? 128 : 40, "armR", hasB ? 128 : 40, "lift", 0, "sq", 0)) }, ts);
            if (tc < 700) { double u = tc / 700, s = Math.Sin(u * Math.PI); E["lift"] += s * 9; E["armL"] = lerp(E["armL"], 150 + 20 * Math.Sin(tc / 60), s); E["armR"] = lerp(E["armR"], 150 - 20 * Math.Sin(tc / 60), s); E["smile"] = s; }
            me.pose(E); me.yaw(180 + Math.Sin(t / 900) * 6);
            DrawHoop(t);
            var all = new List<Ball>(); if (held != null) all.Add(held); all.AddRange(balls);
            foreach (var b in all)
            {
                if (b == held) { double k = cl(ts / 450, 0, 1); b.x = HOLD[0]; b.y = HOLD[1] + (1 - SM(k)) * -0.3 + Math.Sin(t / 400) * 0.015; b.z = HOLD[2]; }
                var s = P(b.x, b.y, b.z); double r = BR * s[2]; bool behind = b.z > RZ - 0.35 && b.y < RY + 0.9 && b.st == "fly";
                if (behind && b.g.Parent != slotB) slotB.Add(b.g); else if (!behind && b.g.Parent != slotF) slotF.Add(b.g);
                b.b.Set("cx", r2(s[0])); b.b.Set("cy", r2(s[1])); b.b.Set("r", r2(r));
                double sp = b.spin, cs = Math.Cos(sp), sn = Math.Sin(sp);
                b.sm.Set("d", "M" + N(s[0] - r * cs) + " " + N(s[1] - r * sn) + "L" + N(s[0] + r * cs) + " " + N(s[1] + r * sn) + "M" + N(s[0] + r * sn) + " " + N(s[1] - r * cs) + "Q" + N(s[0] - r * 0.25 * cs) + " " + N(s[1] - r * 0.25 * sn) + " " + N(s[0] - r * sn) + " " + N(s[1] + r * cs));
                b.hl.Set("cx", r2(s[0] - r * 0.35)); b.hl.Set("cy", r2(s[1] - r * 0.4)); b.hl.Set("rx", r2(r * 0.4)); b.hl.Set("ry", r2(r * 0.25));
                b.fl.Set("cx", r2(s[0])); b.fl.Set("cy", r2(s[1])); b.fl.Set("r", r2(r + 2)); b.fl.Set("opacity", b.fire > 0 ? 0.5 + 0.4 * Math.Sin(t / 60) : 0);
                var g0 = P(b.x, 0, b.z); double hgt = cl(1 - b.y / 4, 0.25, 1); b.sh.Set("cx", r2(g0[0])); b.sh.Set("cy", r2(g0[1])); b.sh.Set("rx", r2(BR * g0[2] * 1.1 * hgt)); b.sh.Set("ry", r2(BR * g0[2] * 0.3 * hgt)); b.sh.Set("opacity", r2(0.22 * hgt));
                if (b.fire > 0 && ctx.rand() < 0.5 && b.st == "fly") ctx.burst(s[0], s[1], "spark", 1, new BurstOpts { V = 30, Life = 0.4, G = -40, Col = "#ffb03a" });
            }
            if (drag != null && held != null && guide == null) guide = S("path", ctx.fg, "fill", "none", "stroke", "#ffffff", "stroke-width", 3, "stroke-dasharray", "2 7", "stroke-linecap", "round", "opacity", 0.8);
            if (guide != null)
            {
                if (drag != null && held != null) { double fx = drag.Value.x - drag.Value.x0, fy = drag.Value.y - drag.Value.y0; var s0 = P(held.x, held.y, held.z); guide.Set("d", "M" + N(s0[0]) + " " + N(s0[1]) + "l0 0l" + N(fx * 0.6) + " " + N(fy * 0.6)); guide.Set("opacity", cl(-fy / 60, 0, 0.8)); }
                else guide.Set("opacity", 0);
            }
        }
        static Dictionary<string, double> P_(params object[] kv) => YK.P(kv);
    }
}
