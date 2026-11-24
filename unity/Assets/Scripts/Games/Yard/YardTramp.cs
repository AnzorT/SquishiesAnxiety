// BOUNCE UP (yg-tramp.js): tap just as your creature lands on the mat to bounce higher (no tap: the bounces shrink);
// tap in the air to twirl for points, finished before landing. Height (+5 a metre), stars (+10, gold +30), twirls. 40 s.
// The sky darkens to a starry night as you climb. Two looks: the sport trampoline, the old one.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardTramp : YardGame
    {
        public YardTramp()
        {
            Id = "tramp"; Name = "Bounce Up"; Item = "Trampolines"; Color = "#7d8cff"; Dur = 40; Stars = new double[] { 200, 450, 800 }; CoinK = 0.08;
            Hint = "Tap as you land = higher · tap in the air = twirl";
            How = new[] { "Tap just as your creature lands on the mat to bounce higher.", "No tap and the bounces get smaller.", "Tap in the air to twirl for points; finish it before you land!" };
            Options = new[] { ("sport", "Sport Trampoline"), ("old", "Old Trampoline") };
        }

        const double K = 108, BASE = 588, MY = 0.78, G = 9.8 * 0.72;
        double[] PX(double x, double y, double cam) => new[] { W / 2 + x * K, BASE - (y - cam) * K };
        El sky, skyG, space, world, ground, deco, ruler, starsG, tramp, recLine, matF, matB, pad, legs, padF, padF2, bal;
        sealed class Cloud { public El g; public double x, y, k, v; }
        sealed class Bird { public El g; public double y, x, v; }
        sealed class Star { public El g; public double x, y; public bool gold, taken; }
        readonly List<Cloud> clouds = new List<Cloud>(); readonly List<Bird> birds = new List<Bird>(); List<Star> stars = new List<Star>();
        string look = "sport"; YardCreature me;
        double cy = MY, vy, cam, contact = -1, vin, sag, tapAt = -9, maxH, tNow, wob; int twirls, combo, lastMeter, perfect, gotStars; bool started, ru;
        sealed class Tw { public double t0, d; public bool q; }
        Tw tw;

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; var fg = c.fg; var R = c.Rnd;
            sky = S("rect", bg, "x", -20, "y", -20, "width", W + 40, "height", H + 40, "fill", "#9fd6ff"); skyG = S("rect", bg, "x", -20, "y", -20, "width", W + 40, "height", H + 40, "fill", "url(#ygSky)", "opacity", 1);
            space = S("g", bg, "opacity", 0); for (int i = 0; i < 40; i++) S("circle", space, "cx", r2(R.NextDouble() * W), "cy", r2(R.NextDouble() * H), "r", r2(0.6 + R.NextDouble() * 1.3), "fill", "#ffffff", "opacity", r2(0.4 + R.NextDouble() * 0.6));
            world = S("g", bg); ground = S("g", world); deco = S("g", world); ruler = S("g", world); starsG = S("g", world); tramp = S("g", world);
            { var g = S("g", ground, "transform", "translate(0 " + El.Num(BASE - 250) + ")"); yard(g, 196, sky: false, flowers: false); }
            for (int i = 0; i < 22; i++)
            {
                double y = 4 + i * 2.2 + R.NextDouble() * 1.2, x = (R.NextDouble() - 0.5) * 3.6, k = 0.5 + R.NextDouble() * 0.7; var g = S("g", deco, "opacity", 0.85);
                foreach (var (a, b, r) in new[] { (-22, 4, 15), (0, -5, 20), (22, 4, 15), (8, 7, 14) }) S("circle", g, "cx", a, "cy", b, "r", r, "fill", "#ffffff");
                clouds.Add(new Cloud { g = g, x = x, y = y, k = k, v = (R.NextDouble() - 0.5) * 0.25 });
            }
            int bi = 0; foreach (var y in new double[] { 7, 12, 18 }) { var g = S("path", deco, "d", "M-7 0Q-3.5 -5 0 0Q3.5 -5 7 0", "fill", "none", "stroke", "#3a2a55", "stroke-width", 2, "stroke-linecap", "round"); birds.Add(new Bird { g = g, y = y, x = -2 + bi, v = 0.6 + bi * 0.2 }); bi++; }
            bal = S("g", deco); S("path", bal, "d", "M0 14Q3 26 -2 40", "stroke", "#ffffff", "stroke-width", 1.2, "fill", "none"); S("ellipse", bal, "cx", 0, "cy", 0, "rx", 11, "ry", 14, "fill", "#ff7fbf"); S("ellipse", bal, "cx", -4, "cy", -5, "rx", 3, "ry", 4.5, "fill", "#ffffff", "opacity", 0.5);
            matF = S("path", tramp); matB = S("path", tramp); pad = S("g", tramp); legs = S("g", tramp);
            recLine = S("g", world);
            padF2 = S("path", fg, "fill", "none", "stroke-width", 13, "stroke-linecap", "round"); padF = S("path", fg, "fill", "none", "stroke-width", 9, "stroke-linecap", "round");
            me = c.creature(c.playerKey, yaw: 0); me.depth(2);
            DrawTramp(0, 0); me.set(W / 2, PX(0, MY, 0)[1], 1.02 * K); SeedStars();
        }

        void DrawTramp(double sagv, double camv)
        {
            bool sp = look == "sport"; string Lpad = sp ? "#c9ced6" : "#a7c79a", LpadD = sp ? "#9aa3b2" : "#7c9a70", Lmat = sp ? "#2f3340" : "#3a3a3a", Lleg = sp ? "#2c2f38" : "#7a6a58";
            const double Rr = 1.45; double y0 = PX(0, MY, camv)[1], x0 = W / 2, rx = Rr * K, ry = 0.17 * K; legs.Clear(); pad.Clear();
            foreach (var x in new[] { -1.25, 0, 1.25 }) { var a = PX(x * 0.95, MY - 0.02, camv); var b = PX(x * 1.05 + (x != 0 ? Math.Sign(x) * 0.12 : 0), 0, camv); S("path", legs, "d", "M" + N(a[0]) + " " + N(a[1]) + "L" + N(b[0]) + " " + N(b[1]), "stroke", Lleg, "stroke-width", 5, "stroke-linecap", "round"); }
            { var a = PX(-1.4, 0.02, camv); var b = PX(1.4, 0.02, camv); S("path", legs, "d", "M" + N(a[0]) + " " + N(a[1]) + "Q" + N(x0) + " " + N(a[1] - 6) + " " + N(b[0]) + " " + N(b[1]), "stroke", Lleg, "stroke-width", 4, "fill", "none", "opacity", 0.8); shadow(legs, x0, a[1] + 2, rx * 0.95, 0.18); }
            double sg = sagv * K;
            matB.Set("d", "M" + N(x0 - rx * 0.86) + " " + N(y0) + "Q" + N(x0) + " " + N(y0 - ry * 1.5 + sg * 0.6) + " " + N(x0 + rx * 0.86) + " " + N(y0)); matB.Set("fill", Lmat); matB.Set("stroke", "none");
            matF.Set("d", "M" + N(x0 - rx * 0.86) + " " + N(y0) + "Q" + N(x0) + " " + N(y0 + ry * 1.4 + sg * 2) + " " + N(x0 + rx * 0.86) + " " + N(y0) + "Z"); matF.Set("fill", Lmat);
            for (int i = 0; i <= 14; i++) { double u = i / 14.0, x = x0 - rx * 0.92 + u * rx * 1.84, y = y0 + Math.Sin(u * Math.PI) * ry * 0.85; S("path", pad, "d", "M" + N(x) + " " + N(y - 3) + "l2 1.5l-4 1.5l4 1.5l-2 1.5", "stroke", "#b8bcc6", "stroke-width", 1, "fill", "none"); }
            S("path", pad, "d", "M" + N(x0 - rx) + " " + N(y0) + "A" + N(rx) + " " + N(ry) + " 0 0 1 " + N(x0 + rx) + " " + N(y0), "stroke", LpadD, "stroke-width", 9, "fill", "none");
            string d = "M" + N(x0 - rx) + " " + N(y0) + "A" + N(rx) + " " + N(ry) + " 0 0 0 " + N(x0 + rx) + " " + N(y0);
            padF.Set("d", d); padF.Set("stroke", Lpad); padF2.Set("d", d); padF2.Set("stroke", LpadD);
        }

        void SeedStars()
        {
            starsG.Clear(); stars = new List<Star>(); var R = ctx.Rnd;
            for (double y = 3.2; y < 60; y += 1.6 + R.NextDouble() * 1.4)
            {
                bool gold = R.NextDouble() < 0.18; var g = S("g", starsG);
                S("circle", g, "r", 14, "fill", "url(#ygGlow)", "opacity", 0.8);
                S("path", g, "d", "M0-11L3.2-3.4L11-2.4L5 3L6.8 11L0 6.8L-6.8 11L-5 3L-11-2.4L-3.2-3.4Z", "fill", gold ? "#ffcf3a" : "#ffffff", "stroke", gold ? "#e09a14" : "#ffd84a", "stroke-width", 1.5, "stroke-linejoin", "round");
                stars.Add(new Star { g = g, x = (R.NextDouble() - 0.5) * 0.5, y = y, gold = gold });
            }
        }

        double TToMat() { double a = -G / 2, b = vy, c = cy - MY, disc = b * b - 4 * a * c; if (disc < 0) return 9; double t1 = (-b - Math.Sqrt(disc)) / (2 * a); return t1 > 0 ? t1 : 9; }
        void Tap()
        {
            if (!ctx.playing) return; double ttm = contact < 0 ? TToMat() : 0;
            if (contact >= 0 || ttm < 0.22) { tapAt = tNow; return; }
            if (tw == null) { tw = new Tw { t0 = tNow, d = 520 }; ctx.sfx("whoosh"); } else if (!tw.q) tw.q = true;
        }

        public override void Start() { cy = 2.0; vy = 0; cam = 0; contact = -1; twirls = 0; combo = 0; maxH = 0; lastMeter = 0; perfect = 0; tw = null; gotStars = 0; SeedStars(); started = true; look = Opt ?? "sport"; me.play("idle"); }
        public override void Down(double x, double y, double t) => Tap();
        public override bool TimeUp() { ctx.finish(new Dictionary<string, object> { ["sub"] = "Highest " + maxH.ToString("F1", System.Globalization.CultureInfo.InvariantCulture) + " m · " + gotStars + " stars · " + twirls + " twirls" }); return true; }
        public override void Celebrate(int st) => me.play(st >= 2 ? "happy" : "idle");

        public override void Update(double dt, double t)
        {
            tNow = t; var E = new Dictionary<string, double>();
            if (started)
            {
                if (contact < 0)
                {
                    vy -= G * dt; cy += vy * dt;
                    if (cy <= MY && vy < 0) { contact = 0; vin = -vy; cy = MY; ctx.sfx("boing"); if (tw != null) { tw = null; wob = 1; combo = 0; ctx.toast("Wobble!", W / 2, 300, "#ff7a8a"); E["spin"] = 0; } }
                }
                if (contact >= 0)
                {
                    contact += dt; const double CT = 0.22; double u = contact / CT; sag = Math.Sin(Math.Min(1, u) * Math.PI) * Math.Min(0.42, 0.08 + vin * 0.035); cy = MY - sag;
                    if (u >= 1)
                    {
                        double mid = t - CT * 500, d = Math.Abs(tapAt - mid), e = 0.84, boost = 0; string j = "";
                        if (wob > 0) { e = 0.62; wob = 0; j = "wobble"; } else if (d < 110) { e = 1.0; boost = 1.55; j = "Perfect!"; perfect++; combo++; } else if (d < 210) { e = 1.0; boost = 0.6; j = "Good"; combo++; } else combo = 0;
                        if (j != "" && j != "wobble") { var p = PX(0, MY, cam); ctx.toast(j + (combo >= 3 ? " x" + combo : ""), p[0] + 70, p[1] - 30, j == "Perfect!" ? "#ffe36e" : "#8fe0ff"); ctx.sfx("pop"); }
                        vy = Math.Min(24, Math.Max(4.3, vin * e + boost)); contact = -1; sag = 0; tapAt = -9;
                    }
                }
                double hgt = cy - MY;
                if (hgt > maxH) { maxH = hgt; int m = (int)Math.Floor(maxH); if (m > lastMeter) { ctx.add(5 * (m - lastMeter)); lastMeter = m; if (m % 5 == 0) { ctx.toast(m + " m!", W / 2 + 90, 200, "#ffffff"); ctx.sfx("score"); } } }
                foreach (var s in stars)
                    if (!s.taken && Math.Abs(s.y - (cy + 0.45)) < 0.45)
                    { s.taken = true; gotStars++; var p = PX(s.x, s.y, cam); ctx.add(s.gold ? 30 : 10, p[0] + 40, p[1], s.gold ? "+30" : "+10", s.gold ? "#ffcf3a" : "#ffffff"); ctx.burst(p[0], p[1], "star", 8, new BurstOpts { V = 110, Life = 0.6, G = 0 }); ctx.sfx("pop"); s.g.Set("opacity", 0); }
                if (tw != null)
                {
                    double u = (t - tw.t0) / tw.d; E["spin"] = 360 * SM(Math.Min(1, u));
                    if (u >= 1) { twirls++; int pts = 15 + Math.Min(30, combo * 3); var p = PX(0, cy + 0.6, cam); ctx.add(pts, p[0] - 80, p[1], "Twirl! +" + pts, "#ff8fc8"); tw = tw.q ? new Tw { t0 = t, d = 520 } : null; }
                }
            }
            double up = cl(vy / 10, -1, 1);
            if (contact >= 0) { E["sq"] = sag * 0.9; E["armL"] = 10; E["armR"] = 10; E["close"] = 0.3; }
            else { double ar = lerp(50, 150, cl(up, 0, 1)) + (up < 0 ? 40 * -up : 0); E["armL"] = ar; E["armR"] = ar; E["sq"] = -0.05 * Math.Abs(up); E["smile"] = 0.6; E["hap"] = Math.Abs(up) < 0.3 ? 0.8 : 0.3; E["open"] = cl(up, 0, 1) * 0.4; E["footL"] = 2 * cl(-up, 0, 1); E["footR"] = 2 * cl(-up, 0, 1); }
            me.pose(E);
            double tc = Math.Max(0, cy - 2.6); cam += (tc - cam) * (1 - Math.Exp(-dt * 7)); world.Set("transform", "translate(0 " + N(cam * K) + ")");
            var pp = PX(0, cy, cam); me.set(pp[0], pp[1] + K * 0.02, 1.02 * K);
            DrawTramp(sag, 0);
            padF.Set("transform", "translate(0 " + N(cam * K) + ")"); padF2.Set("transform", "translate(0 " + N(cam * K) + ")");
            double hk = cl(cam / 35, 0, 1); skyG.Set("opacity", r2(1 - hk)); sky.Set("fill", hk < 0.5 ? "#8fb4ff" : "#4a3a9a"); space.Set("opacity", r2(cl((cam - 18) / 15, 0, 1)));
            foreach (var c in clouds) { c.x += c.v * dt; if (c.x > 2.4) c.x = -2.4; if (c.x < -2.4) c.x = 2.4; var q = PX(c.x, c.y, 0); c.g.Set("transform", "translate(" + N(q[0]) + " " + N(q[1]) + ") scale(" + El.Num(c.k) + ")"); }
            foreach (var b in birds) { b.x += b.v * dt; if (b.x > 2.2) b.x = -2.2; var q = PX(b.x, b.y, 0); b.g.Set("transform", "translate(" + N(q[0]) + " " + N(q[1] + Math.Sin(t / 200 + b.y) * 3) + ") scale(1 " + N(0.6 + 0.4 * Math.Abs(Math.Sin(t / 120 + b.y))) + ")"); }
            { var q = PX(-1.2 + Math.Sin(t / 3000) * 0.3, 24 + Math.Sin(t / 1700) * 0.4, 0); bal.Set("transform", "translate(" + N(q[0]) + " " + N(q[1]) + ")"); }
            foreach (var s in stars) if (!s.taken) { var q = PX(s.x, s.y, 0); s.g.Set("transform", "translate(" + N(q[0]) + " " + N(q[1]) + ") rotate(" + N(Math.Sin(t / 400 + s.y) * 12) + ") scale(" + N(1 + 0.08 * Math.Sin(t / 250 + s.y)) + ")"); }
            if (!ru)
            {
                ru = true;
                for (int m = 1; m <= 60; m++)
                {
                    var q = PX(1.5, MY + m, 0); S("path", ruler, "d", "M" + N(W - (m % 5 != 0 ? 10 : 18)) + " " + N(q[1]) + "H" + El.Num(W), "stroke", "#ffffff", "stroke-width", m % 5 != 0 ? 1.5 : 2.5, "opacity", 0.8);
                    if (m % 5 == 0) S("text", ruler, "x", W - 22, "y", r2(q[1] + 4), "text-anchor", "end", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 12, "fill", "#ffffff").SetText(m + " m");
                }
            }
            recLine.Clear();
            if (maxH > 1) { var q = PX(0, MY + maxH, 0); S("path", recLine, "d", "M0 " + N(q[1]) + "H" + El.Num(W), "stroke", "#ffcf3a", "stroke-width", 2, "stroke-dasharray", "6 6", "opacity", 0.8); S("text", recLine, "x", 8, "y", r2(q[1] - 5), "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 12, "fill", "#ffcf3a").SetText(maxH.ToString("F1", System.Globalization.CultureInfo.InvariantCulture) + " m"); }
        }
    }
}
