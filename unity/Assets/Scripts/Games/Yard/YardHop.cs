// HOPSCOTCH (yg-hop.js): press the move as the ring closes on the next square: pink Hop for one square, blue Split
// for the double squares, yellow Leap over the stone. 3 hearts; each lap the beat speeds up and the stone moves; 6 laps.
using System;
using System.Collections.Generic;
using static SquishSquad.Games.Yard.YK;

namespace SquishSquad.Games.Yard
{
    public sealed class YardHop : YardGame
    {
        static readonly object[][] ROWS = { new object[] { 1 }, new object[] { 2 }, new object[] { 3 }, new object[] { 4, 5 }, new object[] { 6 }, new object[] { 7, 8 }, new object[] { 9 }, new object[] { "HOME" } };
        static readonly string[] COL = { "#ffd1e8", "#fff3a8", "#c8f0b6", "#cfe6ff", "#ffd9b8", "#e4d4ff", "#ffd1e8", "#fff3a8" };
        static readonly Dictionary<string, (string c, string t)> ACT = new Dictionary<string, (string, string)> { ["hop"] = ("#ff5cae", "Hop"), ["split"] = ("#3d9bff", "Split"), ["leap"] = ("#ffb020", "Leap") };
        static readonly int[] STONES = { 0, 1, 2, 4, 6 };

        public YardHop()
        {
            Id = "hop"; Name = "Hopscotch"; Item = "Hopscotch Court"; Color = "#ff7fc0"; Stars = new double[] { 180, 420, 700 }; CoinK = 0.08;
            Hint = "Pink = Hop · Blue = Split · Yellow = Leap over the stone";
            How = new[] { "Press the move as the ring closes on the next square.", "Pink Hop for one square, blue Split for the double squares, yellow Leap over the stone.", "Keys: ← hop · ↓ split · ↑ leap. 3 hearts, the beat speeds up each lap." };
        }

        const double Z0 = 0.35, RL = 0.5, SW = 0.5;
        Func<double, double, double, double[]> P;
        readonly List<List<(double x, double z)>> cells = new List<List<(double, double)>>();
        El stoneG, ringG, shG, meSh; YardCreature me;
        sealed class Mv { public int row; public string act; public double due; public bool done; }
        sealed class HopA { public double from, to, t0, dur; public int row; public string act; public bool bad; }
        int lap, hearts = 3, mi, stone, combo, perfect, bi0 = int.MinValue; double beat = 760, t0, tNow, ph0; bool fin;
        List<Mv> moves = new List<Mv>(); (double z, int row) cur = (0.2, -1); HopA hopA; string phase = "idle";

        public override void Make(YardCtx c)
        {
            base.Make(c); var bg = c.bg; P = cam(2.0, 2.2, 54, 245.7);
            yard(bg, 54, trees: false);
            El quad(double[][] pts, El p, params object[] a) { var e = S("path", p ?? bg, "d", "M" + string.Join("L", Array.ConvertAll(pts, q => { var s = P(q[0], 0, q[1]); return N(s[0]) + " " + N(s[1]); })) + "Z"); for (int i = 0; i + 1 < a.Length; i += 2) e.Set((string)a[i], a[i + 1]); return e; }
            double[][] Q(params double[] v) { var o = new double[v.Length / 2][]; for (int i = 0; i < o.Length; i++) o[i] = new[] { v[2 * i], v[2 * i + 1] }; return o; }
            quad(Q(-0.95, -0.4, 0.95, -0.4, 0.95, 5.2, -0.95, 5.2), null, "fill", "#dcd6cc"); for (double z = -0.4; z < 5.2; z += 0.6) quad(Q(-0.95, z, 0.95, z, 0.95, z + 0.012, -0.95, z + 0.012), null, "fill", "#c7c0b4");
            quad(Q(-0.95, -0.4, -0.9, -0.4, -0.9, 5.2, -0.95, 5.2), null, "fill", "#c2bbae"); quad(Q(0.9, -0.4, 0.95, -0.4, 0.95, 5.2, 0.9, 5.2), null, "fill", "#c2bbae");
            var court = S("g", bg); object[] chalk = { "fill", "none", "stroke", "#ffffff", "stroke-width", 2.2, "stroke-linejoin", "round", "opacity", 0.92 };
            for (int i = 0; i < ROWS.Length; i++)
            {
                var r = ROWS[i]; double z0 = Z0 + RL * i, z1 = z0 + RL;
                if (r[0] is string)
                {
                    var d = ""; const int n = 20; for (int k = 0; k <= n; k++) { double a = Math.PI * k / n; var s = P(-Math.Cos(a) * SW * 0.9, 0, z0 + Math.Sin(a) * RL * 1.3); d += (k > 0 ? "L" : "M") + N(s[0]) + " " + N(s[1]); }
                    S("path", court, "d", d + "Z", "fill", COL[i], "opacity", 0.75); var ch = S("path", court, "d", d + "Z"); for (int q = 0; q < chalk.Length; q += 2) ch.Set((string)chalk[q], chalk[q + 1]);
                    cells.Add(new List<(double, double)> { (0, z0 + RL * 0.55) });
                }
                else
                {
                    var xs = r.Length == 2 ? new[] { (-SW, 0.0), (0.0, SW) } : new[] { (-SW / 2, SW / 2) }; var L = new List<(double, double)>();
                    foreach (var (a, b) in xs) { quad(Q(a, z0, b, z0, b, z1, a, z1), court, "fill", COL[i], "opacity", 0.75); quad(Q(a, z0, b, z0, b, z1, a, z1), court, chalk); L.Add(((a + b) / 2, (z0 + z1) / 2)); }
                    cells.Add(L);
                }
                for (int j = 0; j < r.Length; j++)
                {
                    var cc = j < cells[i].Count ? cells[i][j] : cells[i][0]; var s = P(cc.x, 0, cc.z); double k = s[2] / 245.7; string lb = r[j].ToString();
                    S("text", court, "x", 0, "y", 0, "transform", "translate(" + N(s[0]) + " " + N(s[1] + 6 * k) + ") scale(" + N(k * 1.1) + " " + N(k * 0.62) + ")", "text-anchor", "middle", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", lb == "HOME" ? 20 : 30, "fill", "#ffffff", "opacity", 0.9).SetText(lb);
                }
            }
            for (int i = 0; i < 8; i++) { var s = P((i % 2 == 1 ? 1 : -1) * (0.62 + (i * 0.07) % 0.2), 0, 0.5 + i * 0.55); S("ellipse", court, "cx", r2(s[0]), "cy", r2(s[1]), "rx", r2(9 * s[2] / 245.7), "ry", r2(3 * s[2] / 245.7), "fill", COL[i], "opacity", 0.4); }
            { var s = P(0.7, 0, 0.15); S("rect", court, "x", r2(s[0] - 9), "y", r2(s[1] - 3), "width", 18, "height", 6, "rx", 3, "fill", "#ff8fc8", "transform", "rotate(-20 " + N(s[0]) + " " + N(s[1]) + ")"); }
            stoneG = S("g", bg); ringG = S("g", bg); shG = S("g", bg);
            me = c.creature(c.playerKey, yaw: 180); meSh = shadow(shG, 0, 0, 30, 0.2);
            c.hint("");
            c.Buttons = new List<YardCtx.Btn>
            {
                new YardCtx.Btn { Id = "hop", Label = "Hop", Color = ACT["hop"].c, Icon = "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"12\" cy=\"13\" rx=\"4.5\" ry=\"6.5\" fill=\"currentColor\"/><circle cx=\"9\" cy=\"4.5\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"12.5\" cy=\"3.6\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"15.6\" cy=\"4.8\" r=\"1.5\" fill=\"currentColor\"/></svg>" },
                new YardCtx.Btn { Id = "split", Label = "Split", Color = ACT["split"].c, Icon = "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"6.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><ellipse cx=\"17.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><circle cx=\"5\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"8\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"16\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"19\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/></svg>" },
                new YardCtx.Btn { Id = "leap", Label = "Leap", Color = ACT["leap"].c, Icon = "<svg viewBox=\"0 0 24 24\"><path d=\"M3 19Q12 -2 21 19\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><path d=\"M17.5 16.5L21 19.5L22 15\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><ellipse cx=\"12\" cy=\"20\" rx=\"4\" ry=\"2\" fill=\"#8a8f99\"/></svg>" },
            };
            c.OnButton = Press;
            Plan();
        }

        string Hearts() => new string('♥', Math.Max(0, hearts)) + new string('♡', 3 - Math.Max(0, hearts));
        void Plan()
        {
            stone = STONES[lap % STONES.Length]; moves = new List<Mv>(); int r = -1;
            while (r < 7) { int nx = r + 1; string a; if (nx == stone) { nx++; a = "leap"; } else a = ROWS[nx].Length == 2 ? "split" : "hop"; moves.Add(new Mv { row = nx, act = a }); r = nx; }
            beat = Math.Max(430, 760 * Math.Pow(0.92, lap)); t0 = tNow + beat * 2; for (int i = 0; i < moves.Count; i++) moves[i].due = t0 + beat * i; mi = 0; DrawStone(); ctx.timer(Hearts());
        }
        void DrawStone()
        {
            stoneG.Clear(); var c = cells[stone][0]; var s = P(c.x, 0, c.z); double k = s[2] / 245.7;
            S("ellipse", stoneG, "cx", r2(s[0]), "cy", r2(s[1] + 2 * k), "rx", r2(11 * k), "ry", r2(4.2 * k), "fill", "#6f7480"); S("ellipse", stoneG, "cx", r2(s[0]), "cy", r2(s[1]), "rx", r2(10 * k), "ry", r2(4.6 * k), "fill", "#9aa0ab"); S("ellipse", stoneG, "cx", r2(s[0] - 3 * k), "cy", r2(s[1] - 1.4 * k), "rx", r2(4 * k), "ry", r2(1.6 * k), "fill", "#c9ced6");
        }
        void Judge(Mv m, string act, double dt)
        {
            m.done = true; mi++; bool ok = act == m.act; double a = Math.Abs(dt); string txt, col; int pts = 0;
            if (!ok) { txt = act != null ? "Oops!" : "Miss!"; col = "#ff7a8a"; hearts--; combo = 0; ctx.sfx("miss"); }
            else if (a < 85) { txt = "Perfect!"; col = "#ffe36e"; pts = 30; perfect++; } else if (a < 165) { txt = "Good"; col = "#8fe0ff"; pts = 15; } else { txt = "OK"; col = "#ffffff"; pts = 5; }
            if (ok) { combo++; pts += Math.Min(20, (combo / 4) * 5); ctx.sfx("pop"); }
            var c = cells[m.row][0]; var s = P(c.x, 0, c.z); if (pts > 0) ctx.add(pts, s[0], s[1] - 50, txt + (combo >= 8 ? " x" + combo : ""), col); else ctx.toast(txt, s[0], s[1] - 50, col);
            ctx.timer(Hearts());
            hopA = new HopA { from = cur.z, to = cells[m.row][0].z, row = m.row, act = m.act, t0 = tNow, dur = Math.Min(400, beat * 0.72) * (m.act == "leap" ? 1.25 : 1), bad = !ok }; cur.row = m.row;
            if (hearts <= 0) { phase = "over"; ph0 = tNow; }
        }
        void Press(string k)
        {
            if (!ctx.playing || phase != "run") return; var m = mi < moves.Count ? moves[mi] : null; if (m == null) return; double dt = tNow - m.due;
            if (dt < -230) { ctx.sfx("tap"); return; } Judge(m, k, dt);
        }

        public override void Start() { lap = 0; hearts = 3; combo = 0; perfect = 0; cur = (0.2, -1); hopA = null; phase = "run"; Plan(); me.yaw(180); }
        public override void Celebrate(int st) { me.yaw(0); me.play(st >= 2 ? "happy" : "idle"); }

        public override void Update(double dt, double t)
        {
            tNow = t;
            if (phase == "run")
            {
                var m = mi < moves.Count ? moves[mi] : null; if (m != null && t > m.due + 230) Judge(m, null, 999);
                int bi = (int)Math.Floor((t - t0) / beat); if (bi != bi0 && bi >= -2) { bi0 = bi; if (bi < 0) ctx.sfx("tick"); }
                if (mi >= moves.Count && hopA == null) { phase = "lap"; ph0 = t; lap++; ctx.add(50 + lap * 10, W / 2, 250, "Lap " + lap + "! +" + (50 + lap * 10), "#ffe36e"); ctx.sfx("score"); me.yaw(0); me.play("happy"); }
            }
            if (phase == "lap")
            {
                double u = (t - ph0) / 1000;
                if (u > 1.1 && u < 2.1) { cur.z = lerp(cells[7][0].z, 0.2, SM((u - 1.1) / 1)); me.yaw(0); me.walk(dt, 1, 0); }
                if (u >= 2.1) { me.yaw(180); me.play("idle"); cur = (0.2, -1); if (lap >= 6) { phase = "over"; ctx.finish(new Dictionary<string, object> { ["sub"] = "6 laps! " + perfect + " perfect", ["title"] = "Champion!" }); } else { phase = "run"; Plan(); ctx.toast("Faster!", W / 2, 260, "#ffffff"); } }
            }
            if (phase == "over" && t - ph0 > 300 && !fin) { fin = true; if (hearts <= 0) { me.yaw(0); me.play("surprised"); ctx.finish(new Dictionary<string, object> { ["sub"] = lap + " lap" + (lap == 1 ? "" : "s") + " · " + perfect + " perfect" }); } }
            double z = cur.z, lift = 0; var E = new Dictionary<string, double>();
            if (hopA != null)
            {
                double u = cl((t - hopA.t0) / hopA.dur, 0, 1), sn = Math.Sin(u * Math.PI); z = lerp(hopA.from, hopA.to, SM(u)); double hh = hopA.act == "leap" ? 0.42 : 0.22; lift = sn * hh;
                E = hopA.act == "split" ? P_("armL", 100 * sn + 30, "armR", 100 * sn + 30, "footL", 2 * sn, "footR", 2 * sn, "sq", u > 0.85 ? 0.12 : -0.05)
                    : hopA.act == "leap" ? P_("armL", 150 * sn, "armR", 150 * sn, "spin", 360 * SM(u), "sq", u > 0.85 ? 0.1 : -0.06) : P_("armL", 40, "armR", 40, "footR", 3 * sn, "sq", u > 0.85 ? 0.08 : -0.04);
                if (hopA.bad) E["tilt"] = Math.Sin(u * 20) * 6 * (1 - u * 0.5); if (u >= 1) { cur.z = hopA.to; hopA = null; }
            }
            else if (phase == "run") { var m = mi < moves.Count ? moves[mi] : null; double pre = m != null ? cl(1 - (m.due - t) / beat, 0, 1) : 0; E = P_("sq", 0.06 * pre, "armL", 20 + 25 * pre, "armR", 20 + 25 * pre); }
            if (phase == "run" || phase == "lap") me.pose(E);
            var s = P(0, lift, z); var g = P(0, 0, z); me.set(s[0], s[1], 1.0 * s[2]); meSh.Set("cx", r2(g[0])); meSh.Set("cy", r2(g[1])); meSh.Set("rx", r2(0.3 * g[2] * (1 - lift))); meSh.Set("ry", r2(0.08 * g[2] * (1 - lift)));
            ringG.Clear(); var mm = phase == "run" && mi < moves.Count ? moves[mi] : null;
            foreach (var b in ctx.Buttons) b.Lit = false;
            if (mm != null)
            {
                double u = cl(1 - (mm.due - t) / beat, 0, 1.2), rad = lerp(0.62, 0.27, Math.Min(1, u)); var A = ACT[mm.act]; var cs = cells[mm.row];
                foreach (var c in cs)
                {
                    var d = ""; for (int i = 0; i <= 28; i++) { double a = i / 28.0 * Math.PI * 2; var q = P(c.x + Math.Cos(a) * rad * (cs.Count == 2 ? 0.55 : 1), 0, c.z + Math.Sin(a) * rad * 0.8); d += (i > 0 ? "L" : "M") + N(q[0]) + " " + N(q[1]); }
                    S("path", ringG, "d", d + "Z", "fill", A.c, "fill-opacity", 0.12 + 0.2 * u, "stroke", A.c, "stroke-width", 3.2, "opacity", cl(u * 2, 0, 1));
                }
                var cc = cs.Count == 2 ? (0.0, cs[0].z) : cs[0]; var q2 = P(cc.Item1, 0, cc.Item2);
                var tag = S("g", ringG, "transform", "translate(" + N(q2[0]) + " " + N(q2[1] - 22 * q2[2] / 245.7 - 8) + ")", "opacity", cl(u * 2, 0, 1));
                S("rect", tag, "x", -22, "y", -11, "width", 44, "height", 20, "rx", 10, "fill", A.c); S("text", tag, "y", 4, "text-anchor", "middle", "font-family", "Fredoka, sans-serif", "font-weight", 700, "font-size", 12, "fill", "#ffffff").SetText(A.t);
                foreach (var b in ctx.Buttons) b.Lit = b.Id == mm.act && u > 0.5;
            }
        }
        static Dictionary<string, double> P_(params object[] kv) => YK.P(kv);
    }
}
