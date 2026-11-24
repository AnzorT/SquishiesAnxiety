// SLIDE & SPLASH (yg-slide.js): tap to push off (the swinging bar sets how hard), tap again at the end of the slide to
// jump (Perfect right at the lip), land in a ring of the kiddie pool: near 10, middle 30, far 50; the glowing one
// doubles. 5 slides. Three looks: rainbow, gold, wooden (a little faster / slower).
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardSlide : YardGame
    {
        sealed class Look { public string[] chute; public string edge, rail, railD, plat, post; public double sp; public bool ball; }
        static readonly Dictionary<string, Look> LOOK = new Dictionary<string, Look>
        {
            ["rainbow"] = new Look { chute = new[] { "#8fb4ff", "#9be27a", "#ffab5c", "#ffe36e", "#7ee0d6", "#c9b8f2" }, edge = "#ffffff", rail = "#eef1f8", railD = "#b9c0d0", plat = "#c9b8f2", post = "#e8ebf3", sp = 1.0 },
            ["gold"] = new Look { chute = new[] { "#f6cf5c" }, edge = "#d79a22", rail = "#f4f6fb", railD = "#b9c0d0", plat = "#e7b544", post = "#e8ebf3", sp = 1.06, ball = true },
            ["wood"] = new Look { chute = new[] { "#c98d54" }, edge = "#8e5a2e", rail = "#b47740", railD = "#7f4f28", plat = "#f3ede3", post = "#a46c3a", sp = 0.94 },
        };
        public YardSlide()
        {
            Id = "slide"; Name = "Slide & Splash"; Item = "Slides"; Color = "#3fd0c0"; Stars = new double[] { 100, 170, 240 }; CoinK = 0.15;
            Hint = "Tap to push off · tap again at the end of the slide to jump";
            How = new[] { "Tap to push off; the swinging bar sets how hard.", "Tap again as you reach the end of the slide to jump; Perfect right at the lip.", "Land in a ring: near 10, middle 30, far 50. The glowing ring scores double!" };
            Options = new[] { ("rainbow", "Rainbow"), ("gold", "Gold"), ("wood", "Wooden") };
        }

        const double KX = 74, KY = 118, K = 96, OX = 14, GY = 578, X0 = 0.52, X1 = 1.95, TOP = 2.2, DROP = 1.75, UP = 0.12, WL = 0.24, G = 9.8, MU = 0.6, CD = 0.2, PH = 0.3;
        static readonly double[] POOL = { 2.95, 4.52 };
        static readonly (double x, double r, int p, string c)[] RINGS = { (3.3, 0.2, 10, "#ffe36e"), (3.76, 0.17, 30, "#ff8fc8"), (4.2, 0.15, 50, "#7ee0d6") };
        static double[] PX(double x, double y) => new[] { OX + x * KX, GY - y * KY };
        static double yC(double x) { double t = cl((x - X0) / (X1 - X0), 0, 1); return TOP - DROP * (3 * t * t - 2 * t * t * t) + UP * Math.Pow(Math.Max(0, (t - 0.82) / 0.18), 2); }
        static double dyC(double x) => (yC(x + 0.001) - yC(x - 0.001)) / 0.002;
        El slideG, poolB, shG, poolF, uiG, pwr, pwF, lipMk, meSh; YardCreature me; double[] pw0;
        string look = "rainbow", phase = "push", jumped = ""; double ph0, tNow, power, x, y, v, vx, vy, rot, jv; int slide, bonus = 1;
        readonly List<int> results = new List<int>(); readonly List<(double x, double t)> splashes = new List<(double, double)>();

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg;
            yard(bg, GY - 90);
            { var s = S("g", bg, "transform", "translate(300 110)"); S("circle", s, "r", 40, "fill", "#fff6c2", "opacity", 0.6); S("circle", s, "r", 26, "fill", "#ffe36e"); }
            slideG = S("g", bg); poolB = S("g", bg); shG = S("g", bg); poolF = S("g", fg); uiG = S("g", fg);
            pwr = S("g", uiG, "opacity", 0); pw0 = PX(0.86, TOP + 1.05); S("rect", pwr, "x", r2(pw0[0] - 9), "y", r2(pw0[1]), "width", 18, "height", 90, "rx", 9, "fill", "#ffffff", "stroke", "#4a1a73", "stroke-width", 2);
            pwF = S("rect", pwr, "x", r2(pw0[0] - 6), "width", 12, "rx", 6, "fill", "#ff5cae"); S("text", pwr, "x", r2(pw0[0]), "y", r2(pw0[1] - 6), "text-anchor", "middle", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 12, "fill", "#4a1a73").SetText("PUSH");
            lipMk = S("g", uiG, "opacity", 0); var lp = PX(X1, yC(X1)); S("circle", lipMk, "cx", r2(lp[0]), "cy", r2(lp[1] - 22), "r", 16, "fill", "none", "stroke", "#ffe36e", "stroke-width", 3.5);
            S("text", lipMk, "x", r2(lp[0]), "y", r2(lp[1] - 18), "text-anchor", "middle", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 11, "fill", "#ffffff", "stroke", "#4a1a73", "stroke-width", 3, "paint-order", "stroke").SetText("JUMP");
            me = c.creature(c.playerKey, yaw: 90); meSh = shadow(shG, 0, 0, 20, 0.18); me.depth(2);
            DrawSlide(); DrawPool(0); Reset(); { var s = PX(0.24, TOP); me.set(s[0], s[1] + 3, K); }
        }

        void DrawSlide()
        {
            slideG.Clear(); var L = LOOK[look];
            void ln(double[] a, double[] b, double w, string c) => S("path", slideG, "d", "M" + N(a[0]) + " " + N(a[1]) + "L" + N(b[0]) + " " + N(b[1]), "stroke", c, "stroke-width", w, "stroke-linecap", "round");
            shadow(slideG, PX(1.0, 0)[0], GY + 2, 1.1 * KX, 0.16);
            foreach (var xx in new[] { 0.1, 0.38 }) ln(PX(xx, 0), PX(xx, TOP + 0.34), 5, L.rail); for (double yy = 0.24; yy < TOP; yy += 0.26) ln(PX(0.1, yy), PX(0.38, yy), 3.4, L.railD);
            var pa = PX(0.04, TOP + 0.02); var pb = PX(X0 + 0.04, TOP - 0.05); S("rect", slideG, "x", r2(pa[0]), "y", r2(pa[1]), "width", r2(pb[0] - pa[0]), "height", 9, "rx", 3, "fill", L.plat, "stroke", L.railD, "stroke-width", 1);
            ln(PX(0.1, TOP + 0.34), PX(X0 - 0.02, TOP + 0.28), 4, L.rail); ln(PX(X0 - 0.02, TOP + 0.28), PX(X0 - 0.02, TOP), 4, L.rail);
            if (L.ball) S("circle", slideG, "cx", r2(PX(0.1, TOP + 0.38)[0]), "cy", r2(PX(0.1, TOP + 0.38)[1]), "r", 6, "fill", "#f6cf5c", "stroke", "#d79a22", "stroke-width", 1.2);
            foreach (var xx in new[] { X0 + 0.5, X1 - 0.07 }) ln(PX(xx, 0), PX(xx, yC(xx) - 0.06), 5, L.post);
            const int Nn = 36; var top = new List<double[]>(); var bot = new List<double[]>();
            for (int i = 0; i <= Nn; i++) { double xx = X0 + (X1 - X0) * i / Nn, yy = yC(xx); top.Add(PX(xx, yy + 0.1)); bot.Add(PX(xx, yy - 0.05)); }
            int segs = L.chute.Length;
            for (int s = 0; s < segs; s++)
            {
                int a = (int)Math.Round(Nn * (double)s / segs, MidpointRounding.AwayFromZero), b = (int)Math.Round(Nn * (double)(s + 1) / segs, MidpointRounding.AwayFromZero);
                var pts = top.GetRange(a, b - a + 1); var bb = bot.GetRange(a, b - a + 1); bb.Reverse(); pts.AddRange(bb);
                S("path", slideG, "d", "M" + string.Join("L", pts.ConvertAll(q => N(q[0]) + " " + N(q[1]))) + "Z", "fill", L.chute[s], "stroke", L.chute[s], "stroke-width", 0.6);
            }
            S("path", slideG, "d", "M" + string.Join("L", top.ConvertAll(q => N(q[0]) + " " + N(q[1]))), "fill", "none", "stroke", L.edge, "stroke-width", 2.4, "stroke-linecap", "round");
            S("path", slideG, "d", "M" + string.Join("L", bot.ConvertAll(q => N(q[0]) + " " + N(q[1]))), "fill", "none", "stroke", "#000", "stroke-opacity", 0.18, "stroke-width", 2);
            S("path", slideG, "d", "M" + string.Join("L", top.ConvertAll(q => N(q[0]) + " " + N(q[1] + 3))), "fill", "none", "stroke", "#ffffff", "stroke-width", 1.4, "opacity", 0.55);
        }

        double SplashWave(double xx, double t)
        {
            double s = 0; foreach (var q in splashes) { double age = (t - q.t) / 1000; if (age > 2) continue; double d = Math.Abs(xx - q.x); s += Math.Sin(d / 9 - age * 12) * 5 * Math.Exp(-age * 2.2) * Math.Exp(-d / 70); }
            return s;
        }

        void DrawPool(double t)
        {
            poolB.Clear(); poolF.Clear(); double pl = POOL[0], pr = POOL[1]; var a = PX(pl, 0); var b = PX(pr, PH); shadow(poolB, (a[0] + b[0]) / 2, GY + 2, (b[0] - a[0]) * 0.55, 0.16);
            S("rect", poolB, "x", r2(a[0]), "y", r2(b[1] - 6), "width", r2(b[0] - a[0]), "height", 12, "rx", 6, "fill", "#3e9fe0");
            double wl = PX(0, WL)[1]; var d = new System.Text.StringBuilder("M" + N(a[0] + 4) + " " + N(wl));
            for (double xx = a[0] + 4; xx <= b[0] - 4; xx += 6) d.Append("L" + N(xx) + " " + N(wl + Math.Sin(xx / 14 + t / 300) * 1.6 + SplashWave(xx, t)));
            d.Append("L" + N(b[0] - 4) + " " + N(a[1]) + "L" + N(a[0] + 4) + " " + N(a[1]) + "Z"); S("path", poolB, "d", d.ToString(), "fill", "#7fd0ff");
            for (int i = 0; i < RINGS.Length; i++)
            {
                var R = RINGS[i]; var c = PX(R.x, WL); double rx = R.r * KX, ry = 4.5, bob = Math.Sin(t / 420 + i) * 1.2; bool glow = i == bonus;
                if (glow) S("ellipse", poolB, "cx", r2(c[0]), "cy", r2(c[1] + bob), "rx", r2(rx + 8), "ry", 9, "fill", "#fff6a8", "opacity", 0.5 + 0.3 * Math.Sin(t / 150));
                S("path", poolB, "d", "M" + N(c[0] - rx) + " " + N(c[1] + bob) + "A" + N(rx) + " " + El.Num(ry) + " 0 0 1 " + N(c[0] + rx) + " " + N(c[1] + bob), "fill", "none", "stroke", R.c, "stroke-width", 6);
                S("path", poolF, "d", "M" + N(c[0] - rx) + " " + N(c[1] + bob) + "A" + N(rx) + " " + El.Num(ry) + " 0 0 0 " + N(c[0] + rx) + " " + N(c[1] + bob), "fill", "none", "stroke", R.c, "stroke-width", 7);
                S("path", poolF, "d", "M" + N(c[0] - rx * 0.5) + " " + N(c[1] + bob + 3.5) + "A" + N(rx * 0.5) + " 2 0 0 0 " + N(c[0] + rx * 0.5) + " " + N(c[1] + bob + 3.5), "fill", "none", "stroke", "#ffffff", "stroke-width", 2, "opacity", 0.7);
                var tg = S("g", poolF, "transform", "translate(" + N(c[0]) + " " + N(c[1] - 26 + bob) + ")"); S("rect", tg, "x", -15, "y", -10, "width", 30, "height", 18, "rx", 9, "fill", glow ? "#ffcf3a" : "#ffffff", "stroke", R.c, "stroke-width", 2);
                S("text", tg, "y", 4, "text-anchor", "middle", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 12, "fill", "#4a1a73").SetText((glow ? R.p * 2 : R.p).ToString());
            }
            var fw = PX(pl, 0); var fh = PX(pr, 0.17); S("rect", poolF, "x", r2(fw[0]), "y", r2(fh[1]), "width", r2(fh[0] - fw[0]), "height", r2(fw[1] - fh[1]), "rx", 10, "fill", "#5cb8f0");
            S("rect", poolF, "x", r2(fw[0]), "y", r2(fh[1] - 2), "width", r2(fh[0] - fw[0]), "height", 9, "rx", 4.5, "fill", "#8fd6ff");
            for (double xx = fw[0] + 12; xx < fh[0] - 6; xx += 22) S("rect", poolF, "x", r2(xx), "y", r2(fh[1] + 9), "width", 8, "height", r2(fw[1] - fh[1] - 13), "rx", 4, "fill", "#ffffff", "opacity", 0.5);
        }

        void Reset() { phase = "push"; ph0 = tNow; x = 0.24; y = TOP; jumped = ""; rot = 0; bonus = (int)Math.Floor(ctx.rand() * 3); me.yaw(90).rot(0).hide(false); me.play("idle"); ctx.timer("Slide " + (slide + 1) + "/5"); }
        double PwVal() { double u = ((tNow - ph0) / 900) % 2; return u < 1 ? u : 2 - u; }
        void Tap()
        {
            if (!ctx.playing) return;
            if (phase == "push") { power = PwVal(); phase = "walk"; ph0 = tNow; ctx.sfx("tap"); }
            else if (phase == "slide" && jumped == "") { double d = X1 - x; if (d < 0.08) Jump("Perfect!", 1.0); else if (d < 0.24) Jump("Good", 0.6); else { jumped = "early"; ctx.toast("Too early", W / 2, 260, "#ffffff"); } }
            else if (phase == "air" && jumped == "" && tNow - ph0 < 120) { vy += 0.35; jumped = "Late"; ctx.toast("Late jump", W / 2, 260, "#ffffff"); }
        }
        void Jump(string txt, double j) { jumped = txt; jv = j; ctx.toast(txt, PX(X1, 0)[0] + 20, PX(0, yC(X1) + 0.9)[1], txt == "Perfect!" ? "#ffe36e" : "#8fe0ff"); ctx.sfx("boing"); }
        void Land()
        {
            phase = "splash"; ph0 = tNow; bool inPool = x > POOL[0] + 0.05 && x < POOL[1] - 0.05; int pts = 0; string txt;
            if (inPool)
            {
                int bi = -1; double bd = 1e9; for (int i = 0; i < RINGS.Length; i++) { double d = Math.Abs(x - RINGS[i].x); if (d < RINGS[i].r + 0.04 && d < bd) { bd = d; bi = i; } }
                if (bi >= 0) { pts = RINGS[bi].p * (bi == bonus ? 2 : 1); txt = (bi == bonus ? "Bonus ring! +" : "Ring! +") + pts; } else { pts = 5; txt = "Splash! +5"; }
                if (jumped == "Perfect!") pts += 10; var s = PX(x, WL); splashes.Add((s[0], tNow)); ctx.burst(s[0], s[1], "drop", 26, new BurstOpts { V = 190, Spread = 1.6, Life = 0.9 }); ctx.sfx("splash"); if (pts >= 30) ctx.Later(200, () => ctx.sfx("score"));
            }
            else { txt = x <= POOL[0] + 0.05 ? "Too short!" : "Too far!"; ctx.sfx("thud"); }
            ctx.add(pts, PX(x, 0)[0], PX(0, 1.2)[1], txt, pts >= 30 ? "#ffe36e" : "#ffffff"); results.Add(pts);
            if (!inPool) { phase = "bonk"; me.play("surprised"); } else if (pts >= 30) me.play("happy");
        }

        public override void Start() { slide = 0; results.Clear(); look = Opt ?? "rainbow"; DrawSlide(); Reset(); }
        public override void Down(double xx, double yy, double t) => Tap();
        public override void Celebrate(int st) { me.hide(false).rot(0).yaw(0); var s = PX(1.3, 0); me.set(s[0], s[1], K); me.play(st >= 2 ? "happy" : "idle"); }
        void Next() { slide++; if (slide >= 5) { phase = "done"; ctx.finish(new Dictionary<string, object> { ["sub"] = results.FindAll(p => p >= 10).Count + "/5 rings" }); } else Reset(); }

        public override void Update(double dt, double t)
        {
            tNow = t; var L = LOOK[look]; var E = new Dictionary<string, double>();
            if (phase == "push")
            {
                double p = PwVal(); pwF.Set("y", r2(pw0[1] + 90 - 3 - p * 84)); pwF.Set("height", r2(p * 84)); pwF.Set("fill", p > 0.8 ? "#ff5c5c" : p > 0.45 ? "#ffb020" : "#5cc87a"); pwr.Set("opacity", 1);
                x = 0.24; y = TOP; E = P("armL", 40 + 30 * Math.Sin(t / 200), "armR", 40 + 30 * Math.Sin(t / 200 + 1), "sq", 0.04 * Math.Sin(t / 150));
            }
            else pwr.Set("opacity", 0);
            if (phase == "walk") { double u = cl((t - ph0) / 350, 0, 1); x = lerp(0.24, X0, u); y = TOP + Math.Sin(u * Math.PI) * 0.06; me.walk(dt, 1, 90); if (u >= 1) { phase = "slide"; v = (0.6 + power * 3.6) * L.sp; ph0 = t; ctx.sfx("whoosh"); } }
            if (phase == "slide")
            {
                const int n = 4;
                for (int i = 0; i < n; i++) { double h = dt / n, th = Math.Atan(dyC(x)), acc = -G * Math.Sin(th) - MU * G * Math.Cos(th) - CD * v * v; v = Math.Max(0.2, v + acc * h); x += v * Math.Cos(th) * h; }
                y = yC(x); rot = Math.Atan(dyC(x) * KY / KX) * -180 / Math.PI; E = P("armL", 150, "armR", 150, "open", 0.5, "smile", 1, "hap", 0.6, "sq", -0.04);
                lipMk.Set("opacity", cl((x - (X1 - 0.5)) / 0.25, 0, 1) * (jumped != "" ? 0.3 : 1));
                if (x >= X1) { double th = Math.Atan(dyC(X1 - 0.001)); vx = v * Math.Cos(th); vy = v * Math.Sin(th) + (jv != 0 && jumped != "early" ? jv : 0); x = X1; phase = "air"; ph0 = t; jv = 0; }
            }
            else lipMk.Set("opacity", 0);
            if (phase == "air")
            {
                vy -= G * dt; x += vx * dt; y += vy * dt; rot = lerp(rot, cl(-Math.Atan2(vy * KY, vx * KX) * 180 / Math.PI * 0.6, -45, 45), 1 - Math.Exp(-dt * 8)); E = P("armL", 160, "armR", 160, "open", 0.6, "smile", 1, "hap", 0.4, "footL", 2, "footR", 2);
                if (y <= WL && vy < 0 && x > POOL[0] - 0.1) { y = WL; Land(); } else if (y <= 0) { y = 0; Land(); }
            }
            if (phase == "splash") { double u = (t - ph0) / 1000; rot = lerp(rot, 0, 1 - Math.Exp(-dt * 6)); y = WL - 0.3 + Math.Sin(u * 5) * 0.03 * Math.Exp(-u); E = P("armL", 120 + 30 * Math.Sin(u * 8), "armR", 120 - 30 * Math.Sin(u * 8), "smile", 1, "hap", 1, "close", 0.6); if (u > 1.6) Next(); }
            if (phase == "bonk") { double u = (t - ph0) / 1000; rot = lerp(rot, 0, 1 - Math.Exp(-dt * 6)); E = P("tilt", Math.Sin(u * 14) * 6 * Math.Exp(-u * 2), "sq", 0.08); if (u > 1.6) Next(); }
            me.pose(E); me.rot(rot, 50, 90); var sp = PX(x, y); me.set(sp[0], sp[1] + 3, K);
            double gy = phase == "slide" || phase == "walk" || phase == "push" ? Math.Max(0, y) : x > POOL[0] && x < POOL[1] ? WL : 0; var gs = PX(x, gy);
            meSh.Set("cx", r2(gs[0])); meSh.Set("cy", r2(gs[1] + 2)); meSh.Set("rx", r2(0.28 * K * cl(1 - (y - gy) / 2, 0.3, 1))); meSh.Set("ry", r2(0.06 * K)); meSh.Set("opacity", phase == "splash" ? 0 : 0.18);
            DrawPool(t); splashes.RemoveAll(q => t - q.t >= 2000);
        }
    }
}
