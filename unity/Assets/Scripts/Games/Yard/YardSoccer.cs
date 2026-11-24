// PENALTY KICK (yg-soccer.js): 5 penalties against a goalkeeper creature. Swipe up from the ball: the swipe's
// direction aims left / right, its length sets the height (too long = over the bar). The keeper reads some shots (more
// each kick); corners and top shots are harder to save but easy to put wide. Goal 100, corner +50, top +50.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardSoccer : YardGame
    {
        public YardSoccer()
        {
            Id = "soccer"; Name = "Penalty Kick"; Item = "Soccer Goal"; Color = "#5cc2ff"; Stars = new double[] { 250, 450, 700 }; CoinK = 0.06;
            Hint = "Swipe up from the ball · direction aims · longer swipe = higher";
            How = new[] { "Swipe up from the ball to shoot.", "The swipe direction aims; a longer swipe sends it higher (too long flies over the bar).", "5 penalties. Corners and top shots score bonus points." };
        }

        const double G = 9.8, GZ = 4.1, GW = 1.3, GH = 1.4, BR = 0.11, NDp = 0.9; const int NX = 14, NY = 7;
        static readonly double[] B0 = { 0, BR, 1.3 };
        Func<double, double, double, double[]> P;
        El netG, shG, postG, ballSlotBack, kShadow, pShadow, bShadow, bG, bC, bP, guide;
        YardCreature keeper, kick; string kpName; double KZ;
        (double x, double y, double a, double t) bulge = (0, 0, 0, -9);
        sealed class Ball { public double x, y, z, vx, vy, vz, spin, tx, ty, t; public string st = "rest"; }
        readonly List<int?> res = new List<int?>(); int shot; string phase = "aim"; double ph0, tNow; Ball ball;
        double kx, kTarget, kDive, kDiveDir, kReact, kH, kwx, kwz, skill = 0.35; double[] runFrom; string outcome;
        (double x0, double y0, double x, double y)? drag;

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg; P = cam(2.6, 1.5, 230, 247);
            yard(bg, 230);
            void line(double[][] pts, double w = 2.5, El p = null, double op = 0.9) => S("path", p ?? bg, "d", "M" + string.Join("L", Array.ConvertAll(pts, q => { var s = P(q[0], 0, q[1]); return N(s[0]) + " " + N(s[1]); })), "fill", "none", "stroke", "#ffffff", "stroke-width", w, "opacity", op, "stroke-linejoin", "round");
            double[][] Q(params double[] v) { var o = new double[v.Length / 2][]; for (int i = 0; i < o.Length; i++) o[i] = new[] { v[2 * i], v[2 * i + 1] }; return o; }
            for (int i = 0; i < 7; i++) { double z0 = -0.6 + i * 1.1; var a = P(-4, 0, z0); var b = P(4, 0, z0); var cc = P(4, 0, z0 + 0.55); var d = P(-4, 0, z0 + 0.55); S("path", bg, "d", "M" + string.Join("L", Array.ConvertAll(new[] { a, b, cc, d }, s => N(s[0]) + " " + N(s[1]))) + "Z", "fill", "#ffffff", "opacity", 0.07); }
            line(Q(-3.2, GZ, 3.2, GZ)); line(Q(-2.1, GZ, -2.1, GZ - 1.3, 2.1, GZ - 1.3, 2.1, GZ)); line(Q(-3.4, GZ, -3.4, -0.6), 2, bg, 0.5); line(Q(3.4, GZ, 3.4, -0.6), 2, bg, 0.5);
            { var d = ""; for (int i = 0; i <= 18; i++) { double a = Math.PI * i / 18; var s = P(Math.Cos(a) * 0.9, 0, GZ - 2.2 - Math.Sin(a) * 0.55); d += (i > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1]); } S("path", bg, "d", d, "fill", "none", "stroke", "#ffffff", "stroke-width", 2.2, "opacity", 0.8); }
            var spot = P(0, 0, B0[2]); S("ellipse", bg, "cx", spot[0], "cy", spot[1], "rx", 5, "ry", 1.6, "fill", "#ffffff", "opacity", 0.9);
            netG = S("g", bg); shG = S("g", bg); postG = S("g", fg); ballSlotBack = S("g", bg);
            {
                var a = P(-GW, 0, GZ); var b = P(-GW, GH, GZ); var cc = P(GW, GH, GZ); var d = P(GW, 0, GZ); double w = 0.07 * a[2];
                string path = "M" + N(a[0]) + " " + N(a[1]) + "L" + N(b[0]) + " " + N(b[1]) + "L" + N(cc[0]) + " " + N(cc[1]) + "L" + N(d[0]) + " " + N(d[1]);
                S("path", postG, "d", path, "fill", "none", "stroke", "#c9d2dc", "stroke-width", r2(w + 1.6), "stroke-linejoin", "round");
                S("path", postG, "d", path, "fill", "none", "stroke", "#ffffff", "stroke-width", r2(w), "stroke-linejoin", "round");
            }
            var kp = c.opponent(1)[0]; kpName = c.nameOf(kp); KZ = GZ - 0.32; keeper = c.creature(kp, yaw: 0); kick = c.creature(c.playerKey, yaw: 200);
            kShadow = shadow(shG, 0, 0, 20, 0.2); pShadow = shadow(shG, 0, 0, 30, 0.2); bShadow = S("ellipse", shG, "fill", "#3a2a55", "opacity", 0.2);
            bG = S("g", fg); bC = S("circle", bG, "fill", "url(#ygWhite)", "stroke", "#3a3a44", "stroke-width", 1); bP = S("path", bG, "fill", "#3a3a44");
            ResetShot(); Place(); DrawNet(0);
        }

        void DrawDots()
        {
            ctx.Dots = new List<(string, string)>();
            for (int i = 0; i < 5; i++) { int? r = i < res.Count ? res[i] : null; ctx.Dots.Add((r == null ? "○" : r == 1 ? "●" : "✕", r == null ? "#b9a8d6" : r == 1 ? "#2fb24a" : "#e8483c")); }
        }

        void DrawNet(double t)
        {
            netG.Clear(); double k = bulge.a * Math.Exp(-(t - bulge.t) / 420) * (1 + 0.2 * Math.Sin((t - bulge.t) / 60));
            double[] pt(double x, double y) { double back = NDp * (1 - y / GH * 0.55), d = Math.Sqrt((x - bulge.x) * (x - bulge.x) + (y - bulge.y) * (y - bulge.y)), push = k * Math.Exp(-d * d / 0.18) * 0.5; return P(x, y, GZ + back + push); }
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i <= NX; i++) { double x = -GW + 2 * GW * i / NX; for (int j = 0; j <= NY; j++) { double y = GH * j / NY; var s = pt(x, y); sb.Append((j > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1])); } }
            for (int j = 0; j <= NY; j++) { double y = GH * j / NY; for (int i = 0; i <= NX; i++) { double x = -GW + 2 * GW * i / NX; var s = pt(x, y); sb.Append((i > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1])); } }
            for (int j = 0; j <= NY; j++) { double y = GH * j / NY; var a = P(-GW, y, GZ); var b = pt(-GW, y); var c = P(GW, y, GZ); var e = pt(GW, y); sb.Append("M" + N(a[0]) + " " + N(a[1]) + "L" + N(b[0]) + " " + N(b[1]) + "M" + N(c[0]) + " " + N(c[1]) + "L" + N(e[0]) + " " + N(e[1])); }
            S("path", netG, "d", sb.ToString(), "fill", "none", "stroke", "#ffffff", "stroke-width", 0.9, "opacity", 0.75);
            var fb = new[] { P(-GW, 0, GZ + NDp), P(-GW, GH * 0.95, GZ + NDp * 0.48), P(GW, GH * 0.95, GZ + NDp * 0.48), P(GW, 0, GZ + NDp) };
            S("path", netG, "d", "M" + string.Join("L", Array.ConvertAll(fb, s => N(s[0]) + " " + N(s[1]))), "fill", "none", "stroke", "#dfe6ee", "stroke-width", 2.6);
        }

        void Place()
        {
            var k = P(kx, 0, KZ); keeper.set(k[0], k[1] - kH * k[2], 1.15 * k[2]); keeper.depth(1); kShadow.Set("cx", r2(k[0])); kShadow.Set("cy", r2(k[1])); kShadow.Set("rx", r2(0.36 * k[2]));
            var kk = P(kwx, 0, kwz); kick.set(kk[0], kk[1], 0.98 * kk[2]); kick.depth(3); pShadow.Set("cx", r2(kk[0])); pShadow.Set("cy", r2(kk[1])); pShadow.Set("rx", r2(0.36 * kk[2]));
        }

        void ResetShot()
        {
            ball = new Ball { x = B0[0], y = B0[1], z = B0[2] }; kwx = -0.82; kwz = 0.72; kx = 0; kTarget = 0; kDive = 0; kH = 0; keeper.rot(0); keeper.play("idle"); kick.play("idle"); phase = "aim"; outcome = null;
            skill = 0.3 + shot * 0.12; ctx.timer("Kick " + (shot + 1) + "/5"); DrawDots();
        }

        void Shoot(double fx, double fy)
        {
            if (phase != "aim") return; double len = Math.Sqrt(fx * fx + fy * fy); if (fy > -25 || len < 40) return;
            double ang = Math.Atan2(fx, -fy), X = Math.Tan(cl(ang, -1.1, 1.1)) * 3.0 + (ctx.rand() - 0.5) * 0.12, Y = 0.12 + cl((len - 60) / 250, 0, 1.25) * 1.55 + (ctx.rand() - 0.5) * 0.08;
            ball.tx = X; ball.ty = Y; phase = "run"; ph0 = tNow; runFrom = new[] { kwx, kwz }; ctx.sfx("tap");
        }

        void Launch()
        {
            double T = 0.62 - Math.Min(0.12, Math.Abs(ball.ty) * 0.05), dz = GZ + 0.05 - ball.z;
            ball.vx = (ball.tx - ball.x) / T; ball.vz = dz / T; ball.vy = (ball.ty - ball.y + 0.5 * G * T * T) / T; ball.st = "fly"; ball.t = 0; ctx.sfx("thud"); ctx.sfx("whoosh");
            bool read = ctx.rand() < skill;
            kDiveDir = read ? (Math.Sign(ball.tx) != 0 ? Math.Sign(ball.tx) : (ctx.rand() < 0.5 ? -1 : 1)) : (ctx.rand() < 0.34 ? 0 : ctx.rand() < 0.5 ? -1 : 1);
            kTarget = read ? cl(ball.tx, -1.25, 1.25) : kDiveDir * (0.6 + ctx.rand() * 0.6); kReact = tNow + 140 + ctx.rand() * 110; phase = "fly";
        }

        void Settle(bool goal, string txt = null, string col = null)
        {
            if (outcome != null) return; outcome = goal ? "goal" : "miss"; while (res.Count <= shot) res.Add(null); res[shot] = goal ? 1 : 0; DrawDots(); phase = "after"; ph0 = tNow;
            if (goal)
            {
                int pts = 100; bool corner = Math.Abs(ball.x) > 0.8, top = ball.y > 0.9; if (corner) pts += 50; if (top) pts += 50; var g = P(ball.x, ball.y, GZ);
                ctx.add(pts, W / 2, 200, (corner && top ? "Top corner! " : corner ? "Corner! " : top ? "Top shelf! " : "Goal! ") + "+" + pts, "#ffe36e"); ctx.burst(g[0], g[1], "confetti", 22, new BurstOpts { V = 170 }); ctx.sfx("score"); kick.play("happy"); keeper.play("surprised");
            }
            else { ctx.toast(txt, W / 2, 200, col ?? "#ffffff", true); ctx.sfx("miss"); if (txt == "Saved!") keeper.play("happy"); kick.play("surprised"); }
        }

        public override void Start() { shot = 0; res.Clear(); ctx.setScore(0); ResetShot(); }
        public override void Down(double x, double y, double t) { if (phase == "aim") drag = (x, y, x, y); }
        public override void Move(double x, double y, double t) { if (drag != null) drag = (drag.Value.x0, drag.Value.y0, x, y); }
        public override void Up(double x, double y, double t) { if (drag == null) return; double fx = x - drag.Value.x0, fy = y - drag.Value.y0; drag = null; Shoot(fx, fy); }
        public override void Celebrate(int st) => kick.play(st >= 2 ? "happy" : "idle");

        public override void Update(double dt, double t)
        {
            tNow = t; double ts = t - ph0; var KE = P_("armL", 30, "armR", 30, "sq", 0.03);
            if (phase == "aim") { kx = Math.Sin(t / 700) * 0.18; KE = P_("armL", 40 + 10 * Math.Sin(t / 300), "armR", 40 + 10 * Math.Sin(t / 300 + 1), "sq", 0.06 + 0.02 * Math.Sin(t / 150), "lean", Math.Sin(t / 700) * 3); kick.pose(); }
            if (phase == "run") { double u = cl(ts / 520, 0, 1); kwx = lerp(runFrom[0], -0.36, u); kwz = lerp(runFrom[1], 1.1, u); kick.pose(); kick.walk(dt, 1, 160); if (u >= 1) { Launch(); ph0 = t; } }
            else if (phase != "aim")
            {
                double kt = t - (phase == "fly" ? ph0 : ph0 - 400);
                kick.pose(track(new List<(double, Dictionary<string, double>)> { (0, P_("lean", 10, "sq", -0.06, "footR", 0, "armL", 60, "armR", -10)), (90, P_("lean", 6, "sq", 0.04, "footR", 3, "armL", 90, "armR", 30)), (420, P_("lean", 0, "sq", 0, "footR", 0, "armL", 0, "armR", 0)) }, kt));
            }
            if ((phase == "fly" || phase == "after") && t > kReact) { kDive = Math.Min(1, kDive + dt / 0.32); kx = lerp(kx, kTarget, 1 - Math.Pow(0.0005, dt)); }
            double dd = SM(kDive) * kDiveDir; kH = Math.Sin(Math.Min(1, kDive) * Math.PI) * (kDiveDir != 0 ? 0.25 : 0.45);
            if (phase == "fly" || phase == "after") KE = P_("armL", 160 * Math.Min(1, kDive * 1.5), "armR", 160 * Math.Min(1, kDive * 1.5), "sq", -0.04, "lean", dd * 8);
            keeper.rot(dd * 62, 50, 55); keeper.pose(KE); Place();
            if (ball.st == "fly" || ball.st == "net" || ball.st == "out")
            {
                const int n = 3;
                for (int i = 0; i < n; i++)
                {
                    double h = dt / n, pz = ball.z; ball.vy -= G * h; ball.x += ball.vx * h; ball.y += ball.vy * h; ball.z += ball.vz * h; ball.spin += h * 14;
                    if (ball.y < BR) { ball.y = BR; ball.vy = Math.Abs(ball.vy) * 0.45; ball.vx *= 0.8; ball.vz *= 0.8; }
                    if (ball.st == "fly" && pz < KZ && ball.z >= KZ - 0.05)
                    {
                        double ang = dd * 62 * Math.PI / 180, rx = ball.x - kx, ry = ball.y - kH, along = rx * Math.Sin(ang) + ry * Math.Cos(ang), across = rx * Math.Cos(ang) - ry * Math.Sin(ang);
                        if (along > -0.1 && along < 1.15 + (kDive > 0.2 ? 0.25 : 0) && Math.Abs(across) < 0.32 + (kDive > 0.2 ? 0.12 : 0))
                        { ball.vz = -Math.Abs(ball.vz) * 0.35; ball.vx = (ctx.rand() - 0.5) * 3 + (rx != 0 ? Math.Sign(rx) : 1) * 1.5; ball.vy = 2.5; ball.st = "out"; Settle(false, "Saved!", "#8fe0ff"); ctx.sfx("thud"); }
                    }
                    if (ball.st == "fly" && pz < GZ && ball.z >= GZ)
                    {
                        double ax = Math.Abs(ball.x);
                        if (Math.Abs(ax - GW) < BR + 0.04 && ball.y < GH + 0.05 || Math.Abs(ball.y - GH) < BR + 0.04 && ax < GW + 0.05)
                        { ball.vz = -Math.Abs(ball.vz) * 0.5; ball.vx += (ax < GW ? -1 : 1) * Math.Sign(ball.x) * 1.2; ball.st = "out"; ctx.sfx("clang"); Settle(false, Math.Abs(ball.y - GH) < 0.2 ? "Off the bar!" : "Off the post!"); }
                        else if (ax < GW && ball.y < GH) { ball.st = "net"; bulge = (ball.x, ball.y, 1, t); ctx.sfx("swish"); Settle(true); }
                        else { ball.st = "out"; Settle(false, ball.y >= GH ? "Over the bar!" : "Wide!"); }
                    }
                    if (ball.st == "net")
                    {
                        if (ball.z > GZ + 0.55) { ball.z = GZ + 0.55; ball.vz = -0.3; ball.vx *= 0.3; }
                        if (Math.Abs(ball.x) > GW - 0.12) { ball.x = Math.Sign(ball.x) * (GW - 0.12); ball.vx *= -0.3; }
                        if (ball.y > GH - 0.12) { ball.y = GH - 0.12; ball.vy = -Math.Abs(ball.vy) * 0.3; }
                    }
                }
            }
            DrawNet(t);
            var s = P(ball.x, ball.y, ball.z); double r = BR * s[2]; bool inG = ball.z > GZ - 0.02;
            if (inG && bG.Parent != ballSlotBack) ballSlotBack.Add(bG); else if (!inG && bG.Parent != ctx.fg) ctx.fg.InsertAfter(bG, postG);
            bC.Set("cx", r2(s[0])); bC.Set("cy", r2(s[1])); bC.Set("r", r2(r));
            var pd = ""; for (int i = 0; i < 5; i++) { double a = ball.spin + i * 1.2566; pd += (i > 0 ? "L" : "M") + N(s[0] + Math.Cos(a) * r * 0.42) + " " + N(s[1] + Math.Sin(a) * r * 0.42); } bP.Set("d", pd + "Z");
            var g0 = P(ball.x, 0, ball.z); double hk = cl(1 - ball.y / 2.5, 0.3, 1); bShadow.Set("cx", r2(g0[0])); bShadow.Set("cy", r2(g0[1])); bShadow.Set("rx", r2(BR * g0[2] * 1.2 * hk)); bShadow.Set("ry", r2(BR * g0[2] * 0.35 * hk));
            guide ??= S("path", ctx.fg, "fill", "none", "stroke", "#ffffff", "stroke-width", 3, "stroke-dasharray", "2 7", "stroke-linecap", "round", "opacity", 0);
            if (drag != null && phase == "aim")
            {
                double fx = drag.Value.x - drag.Value.x0, fy = drag.Value.y - drag.Value.y0, len = Math.Sqrt(fx * fx + fy * fy);
                if (fy < -10)
                {
                    double ang = Math.Atan2(fx, -fy), X = Math.Tan(cl(ang, -1.1, 1.1)) * 3.0, Y = 0.12 + cl((len - 60) / 250, 0, 1.25) * 1.55; var tg = P(X, Y, GZ); var b0 = P(ball.x, ball.y, ball.z);
                    guide.Set("d", "M" + N(b0[0]) + " " + N(b0[1]) + "Q" + N((b0[0] + tg[0]) / 2) + " " + N(Math.Min(b0[1], tg[1]) - 30) + " " + N(tg[0]) + " " + N(tg[1])); guide.Set("opacity", 0.75);
                }
            }
            else guide.Set("opacity", 0);
            if (phase == "after" && ts > 1700) { shot++; if (shot >= 5) { phase = "done"; int g = res.FindAll(x => x == 1).Count; ctx.finish(new Dictionary<string, object> { ["sub"] = g + "/5 goals vs " + kpName }); } else ResetShot(); }
        }
        static Dictionary<string, double> P_(params object[] kv) => YK.P(kv);
    }
}
