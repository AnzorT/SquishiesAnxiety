// PING-PONG (yg-pong.js): slide left and right to move your paddle; hit on the paddle's edge (or while moving) to
// angle the ball. First to 7 against a creature that gets better as you lead; long rallies score extra.
// Layers: the opponent behind the table (a Behind creature), the table (ctx.mid), you in front.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardPong : YardGame
    {
        public YardPong()
        {
            Id = "pong"; Name = "Ping-Pong"; Item = "Ping-Pong Table"; Color = "#2f9e6f"; Stars = new double[] { 100, 160, 220 }; CoinK = 0.25;
            Hint = "Slide left and right to move your paddle · first to 7";
            How = new[] { "Slide your finger left and right to move your paddle.", "Hit the ball on the paddle's edge (or while moving) to angle it.", "First to 7 wins. Long rallies score extra!" };
        }

        const double G = 8.2, TW = 0.6, Z0 = 0.55, Z1 = 2.95, ZN = 1.75, TY = 0.76, NH = 0.13, BR = 0.022, ZP = 0.45, ZO = 3.06;
        Func<double, double, double, double[]> P;
        El oppPad, ballSh, ballG, myPad, ball, trail; YardCreature opp, me; string okName;
        sealed class B { public double x, y, z, vx, vy, vz; public int bounces, side; }
        B b; readonly int[] pts = { 0, 0 }; int rally, best, serve, serveN, lastHit; double px, pxT, pv, ox, oxT, ph0, tNow, swingP = -9, swingO = -9, skill = 0.55; string phase = "serve";
        readonly List<double[]> trailPts = new List<double[]>();

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg; var tbl = c.mid; P = cam(1.4, 2.6, 60, 348);
            yard(bg, 60, trees: false);
            El quad(double[][] pts, El p, params object[] a) { var e = S("path", p, "d", "M" + string.Join("L", Array.ConvertAll(pts, q => { var s = P(q[0], q[1], q[2]); return N(s[0]) + " " + N(s[1]); })) + "Z"); for (int i = 0; i + 1 < a.Length; i += 2) e.Set((string)a[i], a[i + 1]); return e; }
            double[][] Q(params double[] v) { var o = new double[v.Length / 3][]; for (int i = 0; i < o.Length; i++) o[i] = new[] { v[3 * i], v[3 * i + 1], v[3 * i + 2] }; return o; }
            quad(Q(-1.6, 0, -0.5, 1.6, 0, -0.5, 1.6, 0, 4.2, -1.6, 0, 4.2), bg, "fill", "#d9d4cc"); for (double z = -0.5; z < 4.2; z += 0.5) quad(Q(-1.6, 0, z, 1.6, 0, z, 1.6, 0, z + 0.015, -1.6, 0, z + 0.015), bg, "fill", "#c7c0b4");
            for (double x = -1.6; x <= 1.6; x += 0.5) quad(Q(x, 0, -0.5, x + 0.015, 0, -0.5, x + 0.015, 0, 4.2, x, 0, 4.2), bg, "fill", "#c7c0b4");
            {
                var g0 = P(0, 0, (Z0 + Z1) / 2); shadow(tbl, g0[0], g0[1], 0.9 * g0[2], 0.22);
                foreach (var (x, z) in new[] { (-TW + 0.08, Z0 + 0.15), (TW - 0.08, Z0 + 0.15), (-TW + 0.08, Z1 - 0.15), (TW - 0.08, Z1 - 0.15) }) { var a = P(x, 0, z); var bb = P(x, TY - 0.03, z); S("path", tbl, "d", "M" + N(a[0]) + " " + N(a[1]) + "L" + N(bb[0]) + " " + N(bb[1]), "stroke", "#3a3a44", "stroke-width", r2(0.04 * a[2]), "stroke-linecap", "round"); }
                quad(Q(-TW, TY - 0.04, Z0, TW, TY - 0.04, Z0, TW, TY, Z0, -TW, TY, Z0), tbl, "fill", "#245a9e");
                quad(Q(-TW, TY, Z0, TW, TY, Z0, TW, TY, Z1, -TW, TY, Z1), tbl, "fill", "#2f6fc0");
                void ln(double ax, double az, double bx, double bz, double w) { var p = P(ax, TY + 0.001, az); var q = P(bx, TY + 0.001, bz); S("path", tbl, "d", "M" + N(p[0]) + " " + N(p[1]) + "L" + N(q[0]) + " " + N(q[1]), "stroke", "#ffffff", "stroke-width", w, "opacity", 0.92); }
                ln(-TW + 0.015, Z0, -TW + 0.015, Z1, 2.4); ln(TW - 0.015, Z0, TW - 0.015, Z1, 2.4); ln(-TW, Z0 + 0.01, TW, Z0 + 0.01, 2.4); ln(-TW, Z1 - 0.01, TW, Z1 - 0.01, 1.6); ln(0, Z0, 0, Z1, 1.2);
                quad(Q(-TW + 0.1, TY + 0.001, Z0 + 0.15, -0.05, TY + 0.001, Z0 + 0.15, -0.25, TY + 0.001, Z1 - 0.2, -TW + 0.1, TY + 0.001, Z1 - 0.2), tbl, "fill", "#ffffff", "opacity", 0.06);
            }
            S("g", tbl); oppPad = S("g", tbl); var netFront = S("g", fg); ballSh = S("ellipse", tbl, "fill", "#10203a", "opacity", 0.3); ballG = S("g", fg); myPad = S("g", fg);
            {
                var a = P(-TW - 0.06, TY, ZN); var bb = P(TW + 0.06, TY, ZN); var cc = P(TW + 0.06, TY + NH, ZN); var d = P(-TW - 0.06, TY + NH, ZN);
                S("path", netFront, "d", "M" + string.Join("L", Array.ConvertAll(new[] { a, bb, cc, d }, s => N(s[0]) + " " + N(s[1]))) + "Z", "fill", "#eef2f8", "opacity", 0.55);
                var m = new System.Text.StringBuilder();
                for (int i = 0; i <= 30; i++) { double x = -TW - 0.06 + (2 * TW + 0.12) * i / 30; var p = P(x, TY, ZN); var q = P(x, TY + NH, ZN); m.Append("M" + N(p[0]) + " " + N(p[1]) + "L" + N(q[0]) + " " + N(q[1])); }
                for (int j = 1; j < 4; j++) { double y = TY + NH * j / 4; var p = P(-TW - 0.06, y, ZN); var q = P(TW + 0.06, y, ZN); m.Append("M" + N(p[0]) + " " + N(p[1]) + "L" + N(q[0]) + " " + N(q[1])); }
                S("path", netFront, "d", m.ToString(), "stroke", "#3a3a44", "stroke-width", 0.6, "opacity", 0.6); S("path", netFront, "d", "M" + N(d[0]) + " " + N(d[1]) + "L" + N(cc[0]) + " " + N(cc[1]), "stroke", "#ffffff", "stroke-width", 3);
                S("path", netFront, "d", "M" + N(a[0]) + " " + N(a[1] + 3) + "L" + N(d[0]) + " " + N(d[1]), "stroke", "#3a3a44", "stroke-width", 3); S("path", netFront, "d", "M" + N(bb[0]) + " " + N(bb[1] + 3) + "L" + N(cc[0]) + " " + N(cc[1]), "stroke", "#3a3a44", "stroke-width", 3);
            }
            ball = S("circle", ballG, "r", 5, "fill", "#ffffff", "stroke", "#e6dccb", "stroke-width", 0.8); trail = S("path", ballG, "fill", "none", "stroke", "#ffffff", "stroke-width", 3, "stroke-linecap", "round", "opacity", 0.35);
            var ok = c.opponent(1)[0]; okName = c.nameOf(ok); opp = c.creature(ok, yaw: 0, behind: true); me = c.creature(c.playerKey, yaw: 180);
            NewBall(0); Say();
        }

        void Paddle(El g, double x, double y, double z, string col, double tilt)
        {
            g.Clear(); var s = P(x, y, z); double r = 0.085 * s[2]; var gg = S("g", g, "transform", "translate(" + N(s[0]) + " " + N(s[1]) + ") rotate(" + N(tilt) + ")");
            S("rect", gg, "x", -r * 0.16, "y", r * 0.7, "width", r * 0.32, "height", r * 1.1, "rx", r * 0.12, "fill", "#a4703f"); S("ellipse", gg, "cx", 0, "cy", 0, "rx", r, "ry", r * 1.06, "fill", col, "stroke", "#3a2a20", "stroke-width", 1); S("ellipse", gg, "cx", -r * 0.3, "cy", -r * 0.35, "rx", r * 0.35, "ry", r * 0.22, "fill", "#ffffff", "opacity", 0.25);
        }
        void Say() { ctx.CenterPill = "You " + pts[0] + " – " + pts[1] + " " + okName; ctx.timer(""); }
        void NewBall(int who) { b = new B { x = who == 1 ? ox : px + 0.04, y = TY + 0.3, z = who == 1 ? ZO - 0.02 : ZP + 0.02, side = -1 }; phase = "serve"; ph0 = tNow; serve = who; if (who == 0) ctx.hint("Tap to serve · slide to move"); }
        void Send(int from, double lx, double lz)
        {
            double T = Math.Max(0.34, 0.6 - rally * 0.012) * (from == 1 ? 1.05 : 1); b.vx = (lx - b.x) / T; b.vz = (lz - b.z) / T; b.vy = (TY + BR - b.y + 0.5 * G * T * T) / T;
            double tn = (ZN - b.z) / b.vz; if (tn > 0 && tn < T) { double yn = b.y + b.vy * tn - 0.5 * G * tn * tn; if (yn < TY + NH + BR + 0.03) b.vy += (TY + NH + BR + 0.05 - yn) / tn; }
            b.bounces = 0; b.side = from; lastHit = from;
        }
        void HitByMe() { double off = (b.x - px) / 0.11, lx = cl(b.x + off * 0.35 + pv * 0.18 + (ctx.rand() - 0.5) * 0.06, -TW + 0.06, TW - 0.06), lz = 2.25 + ctx.rand() * 0.5; Send(0, lx, lz); rally++; swingP = tNow; ctx.sfx("pop"); if (rally > 1 && rally % 5 == 0) ctx.toast("Rally " + rally + "!", W / 2, 200, "#ffe36e"); }
        void HitByOpp()
        {
            double away = Math.Abs(px) < 0.25 ? (ctx.rand() < 0.5 ? -1 : 1) : -Math.Sign(px), aim = ctx.rand() < skill * 0.6 ? away * (0.3 + ctx.rand() * 0.25) : (ctx.rand() - 0.5) * 0.7;
            Send(1, cl(aim, -TW + 0.08, TW - 0.08), 0.8 + ctx.rand() * 0.55); rally++; swingO = tNow; ctx.sfx("tap");
        }
        void Point(bool win, string why)
        {
            if (phase == "point") return; phase = "point"; ph0 = tNow; pts[win ? 0 : 1]++; best = Math.Max(best, rally); Say();
            if (win) { ctx.add(10, W / 2, 240, why ?? "Point!", "#ffe36e"); ctx.sfx("score"); me.play("happy"); opp.play("surprised"); }
            else { ctx.toast(why ?? "Point " + okName, W / 2, 240, "#ffffff"); ctx.sfx("miss"); opp.play("happy"); }
            rally = 0; skill = cl(0.5 + (pts[0] - pts[1]) * 0.06 + (pts[0] + pts[1]) * 0.015, 0.4, 0.85);
        }
        double KxAt() => P(0, TY, ZP)[2];

        public override void Start() { pts[0] = pts[1] = 0; rally = 0; best = 0; serveN = 0; ctx.setScore(0); Say(); NewBall(0); me.play("idle"); opp.play("idle"); }
        public override void Down(double x, double y, double t)
        {
            pxT = cl((x - W / 2) / KxAt(), -TW - 0.1, TW + 0.1);
            if (phase == "serve" && serve == 0 && tNow - ph0 > 300) { phase = "play"; ctx.hint(""); b.x = px + 0.04; HitByMe(); }
        }
        public override void Move(double x, double y, double t) => pxT = cl((x - W / 2) / KxAt(), -TW - 0.1, TW + 0.1);
        public override void Celebrate(int st) { me.yaw(0); me.play(st >= 2 ? "happy" : "idle"); }

        public override void Update(double dt, double t)
        {
            tNow = t; double px0 = px; px += (pxT - px) * (1 - Math.Exp(-dt * 16)); pv = (px - px0) / Math.Max(dt, 0.001);
            if (b != null && phase == "serve" && serve == 1 && t - ph0 > 900) { phase = "play"; HitByOpp(); }
            if (b != null && phase == "serve" && serve == 0) { b.x = px + 0.04; b.y = TY + 0.3 + Math.Abs(Math.Sin((t - ph0) / 260)) * 0.15; b.z = ZP + 0.02; }
            if (b != null && (phase == "play" || phase == "point"))
            {
                const int n = 4;
                for (int i = 0; i < n; i++)
                {
                    double h = dt / n, pz = b.z; b.vy -= G * h; b.x += b.vx * h; b.y += b.vy * h; b.z += b.vz * h;
                    if (b.y <= TY + BR && b.vy < 0 && Math.Abs(b.x) <= TW && b.z >= Z0 && b.z <= Z1)
                    {
                        b.y = TY + BR; b.vy = -b.vy * 0.82; b.bounces++; ctx.sfx("tap"); int hs = b.z < ZN ? 0 : 1;
                        if (phase == "play") { if (hs == lastHit) Point(lastHit == 1, lastHit == 1 ? "Fault!" : "Fault"); else if (b.bounces >= 2) Point(hs == 1, hs == 1 ? "Point!" : null); }
                    }
                    if (phase == "play" && (pz - ZN) * (b.z - ZN) <= 0 && b.y < TY + NH + BR && Math.Abs(b.x) < TW + 0.06) { b.vz = -b.vz * 0.15; b.vx *= 0.3; ctx.sfx("thud"); Point(lastHit == 1, lastHit == 1 ? "Net!" : "Into the net"); }
                    if (b.y < BR) { if (phase == "play" && b.bounces == 0) Point(lastHit == 1, lastHit == 1 ? "Out!" : "Out"); b.y = BR; b.vy = -b.vy * 0.5; b.vx *= 0.7; b.vz *= 0.7; }
                    if (phase == "play")
                    {
                        if (b.vz < 0 && pz >= ZP && b.z < ZP && b.y < TY + 0.75) { if (Math.Abs(b.x - px) < 0.13) { if (b.bounces == 1 || b.side == 1 && b.bounces >= 1) HitByMe(); else if (b.bounces == 0) HitByMe(); } }
                        if (b.z < ZP - 0.35) Point(false, null);
                        if (b.vz > 0 && pz <= ZO && b.z > ZO && b.y < TY + 0.75) { double pMiss = cl(0.05 + rally * 0.012 - (skill - 0.5) * 0.12, 0.03, 0.32); if (Math.Abs(b.x - ox) < 0.13 && ctx.rand() > pMiss) HitByOpp(); else if (Math.Abs(b.x - ox) < 0.2) swingO = tNow; }
                        if (b.z > ZO + 0.4) Point(true, "Point!");
                    }
                }
            }
            if (phase == "point" && t - ph0 > 1200)
            {
                if (pts[0] >= 7 || pts[1] >= 7)
                {
                    phase = "done"; bool won = pts[0] > pts[1];
                    if (won) ctx.add(50 + best * 5, W / 2, 260, "You win! +" + (50 + best * 5), "#ffe36e"); else ctx.add(best * 5);
                    ctx.finish(new Dictionary<string, object> { ["title"] = won ? "You win!" : okName + " wins", ["sub"] = "You " + pts[0] + " – " + pts[1] + " · best rally " + best, ["delay"] = 900.0 });
                }
                else { serveN++; NewBall((serveN / 2) % 2); }
            }
            if (b != null && phase == "play" && b.vz > 0) { double tz = (ZO - b.z) / b.vz, gx = b.x + b.vx * tz, err = (1 - skill) * 0.16 * Math.Sin(t / 300 + rally); oxT = cl(gx + err, -TW, TW); }
            else if (phase != "serve" || serve == 0) oxT = lerp(oxT, 0, 1 - Math.Exp(-dt * 2));
            double sp = 0.9 + skill * 1.4; ox += cl(oxT - ox, -sp * dt, sp * dt);
            if (phase == "serve" && serve == 1) { ox = lerp(ox, 0, 0.1); b.x = ox; b.y = TY + 0.28 + Math.Abs(Math.Sin((t - ph0) / 240)) * 0.12; b.z = ZO - 0.02; }
            double sP = t - swingP, sO = t - swingO;
            var EP = sP < 420 ? track(new List<(double, Dictionary<string, double>)> { (0, P_("armR", 40)), (90, P_("armR", 150, "lean", 4)), (420, P_("armR", 60, "lean", 0)) }, sP) : P_("armR", 60, "armL", 20);
            if (!EP.ContainsKey("lean")) EP["lean"] = cl(pv * 3, -5, 5);   // (Object.assign({ lean }, track / rest): the track's lean wins)
            me.pose(EP); { double kx = KxAt(); me.set(W / 2 + (px - 0.2) * kx, 700, 215); me.yaw(196 + cl(pv * 4, -8, 8)); }
            var EO = sO < 420 ? track(new List<(double, Dictionary<string, double>)> { (0, P_("armR", 40)), (90, P_("armR", 150)), (420, P_("armR", 60)) }, sO) : P_("armR", 55, "armL", 25);
            if (!EO.ContainsKey("lean")) EO["lean"] = 0; opp.pose(EO);
            { var fe = P(ox + 0.1, TY, Z1); opp.set(fe[0], fe[1] + 16, 128); }
            Paddle(myPad, px, TY + 0.14 + (sP < 300 ? 0.05 * Math.Sin(sP / 300 * Math.PI) : 0), ZP, "#e8483c", cl(-pv * 6, -25, 25) + (sP < 300 ? -30 * Math.Sin(sP / 300 * Math.PI) : 0));
            Paddle(oppPad, ox, TY + 0.14, ZO, "#3a3a44", sO < 300 ? 30 * Math.Sin(sO / 300 * Math.PI) : 0);
            if (b != null)
            {
                var s = P(b.x, b.y, b.z); double r = Math.Max(2.4, BR * s[2]); ball.Set("cx", r2(s[0])); ball.Set("cy", r2(s[1])); ball.Set("r", r2(r));
                bool onT = Math.Abs(b.x) <= TW && b.z >= Z0 && b.z <= Z1; double gy = onT ? TY : 0; var g0 = P(b.x, gy, b.z); double hk = cl(1 - (b.y - gy) / 1.0, 0.2, 1);
                ballSh.Set("cx", r2(g0[0])); ballSh.Set("cy", r2(g0[1])); ballSh.Set("rx", r2(r * 1.2 * hk)); ballSh.Set("ry", r2(r * 0.5 * hk)); ballSh.Set("opacity", r2(0.35 * hk));
                trailPts.Add(new[] { s[0], s[1] }); if (trailPts.Count > 6) trailPts.RemoveAt(0); trail.Set("d", phase == "play" ? "M" + string.Join("L", trailPts.ConvertAll(q => N(q[0]) + " " + N(q[1]))) : "");
            }
        }
        static Dictionary<string, double> P_(params object[] kv) => YK.P(kv);
    }
}
