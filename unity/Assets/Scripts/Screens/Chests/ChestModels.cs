// Chest Smash v2's chest models (chest-models.js + chest-<group>.js), as the design's own code built them
// (Resources/Chests/models.json, tools/unity/export-shop.mjs): every group's five chests as parts of shapes (path
// commands, paints: colours, linear / radial / conic gradients), their materials and crack looks; and how they're drawn
// (flat(), paint(), drawShape(), drawPart(); the loot icons replayed from Resources/Chests/icons.json). fin()'s
// `peeks` (the loot glimpsed through holes) are rolled here when a model is first built, as the page does, from the
// same random numbers (ChestEngine's generator).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SquishSquad.Backend;

namespace SquishSquad.Screens
{
    public sealed class ChestShape
    {
        public List<(double[] p, bool c)> Sp, ClipSp;
        public object F, S;              // paint: a colour string or a gradient map { l | r | k, c, spin }
        public double W = 2, A = -1, Gb;
        public string Op, G, Txt, Font;
        public double X, Y, Rot;
    }

    public sealed class ChestPart
    {
        public string Id;
        public List<ChestShape> Sh, Scar;
        public bool Launch;
        public double LaunchV = 660, Hmax, Hdir;
        public double? Tear, Loose;
        public double[] Hang;
    }

    public sealed class ChestMat
    {
        public double Soft, Lean, Sag, DentK, DentShade, HoleFrom, HoleP, EdgeW, Mass = 1, Rest, Flutter;
        public double[] HoleR;
        public string Jag, Edge, Crack, Deb, Deb2, Dust, Spark, Glow, DropC;
        public string[] Chips, Cav;
        /// <summary>Its sound (chest-sfx.js: the material, pitch and accents).</summary>
        public Audio.ChestSounds.Spec Sfx;
    }

    public sealed class ChestModel
    {
        public string Name, Mat, Ko;
        public double Hp, W, H, Sc, PieN;
        /// <summary>The design's own HP (Hp is the one a chest loads with: ChestEngine.TierHp).</summary>
        public double Hp0;
        public bool Ring;
        public List<double[]> Rows;
        public string[] Loot;
        public List<ChestPart> Parts;
        public List<(double[] p, bool c)> HullSp;
        public (double x0, double y0, double x1, double y1) Bb;
        public ChestMat M;
        public List<(string k, double x, double y, double r, double s, string c)> Peeks;
        public int Rolls;
        public bool Spins;   // a shape with a spinning conic gradient (it changes every frame)
    }

    public static class ChestModels
    {
        public static readonly string[] RB = { "#ff8fd8", "#ffe38a", "#9ff7c8", "#9fd8ff", "#d6b3ff" };
        public sealed class Tier { public string K, N, C, Fx; public bool Rb; }
        public static List<Tier> TIER;
        public static Dictionary<string, List<(string col, double w, double ox, double oy, string glow)>> CRACK;
        static Dictionary<string, ChestMat> _mat;
        static Dictionary<string, List<IDictionary<string, object>>> _raw;
        static Dictionary<string, IList<object>> _icons;
        public static string[] Groups;
        static readonly Dictionary<string, ChestModel> Cache = new Dictionary<string, ChestModel>();

        static void Load()
        {
            if (_raw != null) return;
            var j = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/models") ?? throw new InvalidOperationException("Resources/Chests/models.json is missing: run node tools/unity/export-shop.mjs")));
            Groups = Prof.List(j["groups"]).Select(x => (string)x).ToArray();
            TIER = Prof.List(j["tier"]).Select(Prof.Map).Select(t => new Tier { K = (string)t["k"], N = (string)t["n"], C = (string)t["c"], Fx = (string)t["fx"], Rb = Prof.Truthy(Prof.Get(t, "rb")) }).ToList();
            CRACK = Prof.Map(j["crack"]).ToDictionary(kv => kv.Key, kv => Prof.List(kv.Value).Select(Prof.List).Select(a => ((string)a[0], Prof.D(a[1]), Prof.D(a[2]), Prof.D(a[3]), a.Count > 4 ? a[4] as string : null)).ToList());
            _mat = Prof.Map(j["mat"]).ToDictionary(kv => kv.Key, kv => Mat(Prof.Map(kv.Value)));
            _raw = Prof.Map(j["models"]).ToDictionary(kv => kv.Key, kv => Prof.List(kv.Value).Select(Prof.Map).ToList());
            _icons = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/icons") ?? "{}")).ToDictionary(kv => kv.Key, kv => Prof.List(kv.Value));
        }

        static ChestMat Mat(IDictionary<string, object> m)
        {
            double N(string k, double d = 0) => Prof.Num(Prof.Get(m, k), d);
            string S(string k) => Prof.Get(m, k) as string;
            string[] A(string k) => A2(Prof.Get(m, k));
            string[] A2(object v) => Prof.List(v)?.Select(x => x as string).ToArray();
            return new ChestMat
            {
                Soft = N("soft"), Lean = N("lean"), Sag = N("sag"), DentK = N("dentK"), DentShade = N("dentShade"), HoleFrom = N("holeFrom"), HoleP = N("holeP"),
                HoleR = Prof.List(Prof.Get(m, "holeR"))?.Select(Prof.D).ToArray() ?? new[] { 15.0, 22 }, Jag = S("jag"), Edge = S("edge"), EdgeW = N("edgeW", 6), Crack = S("crack"),
                Chips = A("chips"), Deb = S("deb"), Deb2 = S("deb2"), Dust = S("dust"), Mass = N("mass", 1), Rest = N("rest"), Flutter = N("flutter"), Spark = S("spark"),
                Cav = A("cav"), Glow = S("glow"), DropC = S("dropC"),
                Sfx = Prof.Get(m, "sfx") is IDictionary<string, object> x
                    ? new Audio.ChestSounds.Spec { M = Prof.Get(x, "m") as string ?? "wood", P = Prof.Num(Prof.Get(x, "p"), 1), X = A2(Prof.Get(x, "x")) }
                    : null,
            };
        }

        public static IList<object> Icon(string k) { Load(); return _icons.TryGetValue(k, out var l) ? l : null; }
        public static ChestMat MatOf(string k) { Load(); return _mat[k]; }

        /// <summary>model(group, tier): built (fin()) the first time, with `rnd` for its peeks.</summary>
        public static ChestModel Model(string group, int tier, Func<double> random)
        {
            Load();
            tier = Math.Max(0, Math.Min(4, tier));
            if (!_raw.ContainsKey(group)) group = "snack";
            string key = group + tier;
            if (Cache.TryGetValue(key, out var m)) return m;
            var r = _raw[group][tier];
            m = new ChestModel
            {
                Name = (string)r["name"], Mat = (string)r["mat"], Hp = Prof.Num(r["hp"]), W = Prof.Num(r["W"]), H = Prof.Num(r["H"]), Ko = Prof.Get(r, "ko") as string,
                PieN = Prof.Num(Prof.Get(r, "pieN")), Ring = Prof.Truthy(Prof.Get(r, "ring")), Loot = Prof.List(r["loot"]).Select(x => (string)x).ToArray(),
                Rows = Prof.List(Prof.Get(r, "rows"))?.Select(x => Prof.List(x).Select(Prof.D).ToArray()).ToList(),
                Rolls = (int)Prof.Num(Prof.Get(r, "rolls")),
            };
            m.Parts = Prof.List(r["parts"]).Select(Prof.Map).Select(p => new ChestPart
            {
                Id = (string)p["id"], Sh = Prof.List(p["sh"]).Select(Prof.Map).Select(Shape).ToList(), Scar = Prof.List(Prof.Get(p, "scar"))?.Select(Prof.Map).Select(Shape).ToList(),
                Launch = Prof.Truthy(Prof.Get(p, "launch")), LaunchV = Prof.Num(Prof.Get(p, "launchV"), 660), Tear = Prof.IsNum(Prof.Get(p, "tear")) ? Prof.D(p["tear"]) : (double?)null,
                Loose = Prof.IsNum(Prof.Get(p, "loose")) ? Prof.D(p["loose"]) : (double?)null, Hang = Prof.List(Prof.Get(p, "hang"))?.Select(Prof.D).ToArray(), Hmax = Prof.Num(Prof.Get(p, "hmax")), Hdir = Prof.Num(Prof.Get(p, "hdir")),
            }).ToList();
            m.HullSp = Flat(Prof.List(r["hull"]));
            double x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
            foreach (var (p, _) in m.HullSp) for (int i = 0; i < p.Length; i += 2) { x0 = Math.Min(x0, p[i]); x1 = Math.Max(x1, p[i]); y0 = Math.Min(y0, p[i + 1]); y1 = Math.Max(y1, p[i + 1]); }
            m.Bb = (x0, y0, x1, y1);
            m.Sc = m.W / 150;
            m.M = _mat[m.Mat];
            double Rnd(double a, double b) => a + random() * (b - a);
            m.Peeks = new List<(string, double, double, double, double, string)>();
            for (int i = 0; i < 8; i++)
            {
                string k = m.Loot[i % m.Loot.Length];
                double px = Rnd(x0 + 16, x1 - 22), py = Rnd(y0 + 22, y1 - 14), pr = Rnd(-0.7, 0.7), ps = Rnd(15, 22);
                m.Peeks.Add((k, px, py, pr, ps, RB[i % 5]));
            }
            bool Sp(object f) => f is IDictionary<string, object> d && d.ContainsKey("k") && Prof.Truthy(Prof.Get(d, "spin"));
            m.Spins = m.Parts.Any(p => p.Sh.Concat(p.Scar ?? new List<ChestShape>()).Any(s => Sp(s.F) || Sp(s.S)));
            return Cache[key] = m;
        }

        static ChestShape Shape(IDictionary<string, object> s)
        {
            var o = new ChestShape
            {
                F = Prof.Get(s, "f"), S = Prof.Get(s, "s"), W = Prof.Num(Prof.Get(s, "w"), 2), A = Prof.IsNum(Prof.Get(s, "a")) ? Prof.D(s["a"]) : -1,
                Op = Prof.Get(s, "op") as string, G = Prof.Get(s, "g") as string, Gb = Prof.Num(Prof.Get(s, "gb"), 8), Txt = Prof.Get(s, "txt") as string, Font = Prof.Get(s, "font") as string,
                X = Prof.Num(Prof.Get(s, "x")), Y = Prof.Num(Prof.Get(s, "y")), Rot = Prof.Num(Prof.Get(s, "rot")),
            };
            if (Prof.Get(s, "d") is IList<object> d) o.Sp = Flat(d);
            if (Prof.Get(s, "clip") is IList<object> c) o.ClipSp = Flat(c);
            return o;
        }

        /// <summary>chest-models.js flat(): path commands as subpaths of points (lines cut every 9, curves every 6).</summary>
        public static List<(double[] p, bool c)> Flat(IList<object> cmds)
        {
            var subs = new List<(List<double> p, bool c)>();
            List<double> cur = null;
            double x = 0, y = 0, sx = 0, sy = 0;
            int ci = -1;
            void Seg(double x0, double y0, double x1, double y1, bool skipEnd)
            {
                int n = Math.Max(1, (int)Math.Ceiling(Hyp(x1 - x0, y1 - y0) / 9));
                for (int i = 1; i <= n; i++) { if (skipEnd && i == n) break; cur.Add(x0 + (x1 - x0) * i / n); cur.Add(y0 + (y1 - y0) * i / n); }
            }
            foreach (var o in cmds)
            {
                var c = Prof.List(o);
                string k = (string)c[0];
                double V(int i) => Prof.D(c[i]);
                if (k == "M") { cur = new List<double> { V(1), V(2) }; subs.Add((cur, false)); ci = subs.Count - 1; x = sx = V(1); y = sy = V(2); }
                else if (k == "L") { Seg(x, y, V(1), V(2), false); x = V(1); y = V(2); }
                else if (k == "Q")
                {
                    int n = Math.Max(2, (int)Math.Ceiling((Hyp(V(1) - x, V(2) - y) + Hyp(V(3) - V(1), V(4) - V(2))) / 6));
                    for (int i = 1; i <= n; i++) { double t = (double)i / n, u = 1 - t; cur.Add(u * u * x + 2 * u * t * V(1) + t * t * V(3)); cur.Add(u * u * y + 2 * u * t * V(2) + t * t * V(4)); }
                    x = V(3); y = V(4);
                }
                else if (k == "C")
                {
                    int n = Math.Max(3, (int)Math.Ceiling((Hyp(V(1) - x, V(2) - y) + Hyp(V(3) - V(1), V(4) - V(2)) + Hyp(V(5) - V(3), V(6) - V(4))) / 6));
                    for (int i = 1; i <= n; i++) { double t = (double)i / n, u = 1 - t, a = u * u * u, b = 3 * u * u * t, d = 3 * u * t * t, e = t * t * t; cur.Add(a * x + b * V(1) + d * V(3) + e * V(5)); cur.Add(a * y + b * V(2) + d * V(4) + e * V(6)); }
                    x = V(5); y = V(6);
                }
                else if (k == "Z") { subs[ci] = (cur, true); Seg(x, y, sx, sy, true); x = sx; y = sy; }
            }
            return subs.Select(s => (s.p.ToArray(), s.c)).ToList();
        }

        /// <summary>Math.hypot.</summary>
        public static double Hyp(double a, double b) => Math.Sqrt(a * a + b * b);

        // ---- drawing ---------------------------------------------------------------------------------------------------
        public delegate void Warp(double x, double y, out double ox, out double oy);

        public static void Trace(Canvas2D c, List<(double[] p, bool c)> sp, Warp w)
        {
            c.BeginPath();
            foreach (var (p, closed) in sp)
            {
                for (int i = 0; i < p.Length; i += 2)
                {
                    double x = p[i], y = p[i + 1];
                    if (w != null) w(x, y, out x, out y);
                    if (i > 0) c.LineTo(x, y); else c.MoveTo(x, y);
                }
                if (closed) c.ClosePath();
            }
        }

        /// <summary>paint(): a shape's colour or gradient at time T.</summary>
        public static CanvasPaint Paint(object f, double T)
        {
            if (f == null) return null;
            if (f is string s) return s;
            var m = Prof.Map(f);
            var p = new CanvasPaint();
            if (Prof.Get(m, "l") is IList<object> l) { p.Kind = 'l'; p.Args = l.Select(Prof.D).ToArray(); }
            else if (Prof.Get(m, "r") is IList<object> r) { var a = r.Select(Prof.D).ToArray(); p.Kind = 'r'; p.Args = new[] { a[0], a[1], 0, a[0], a[1], a[2] }; }
            else if (Prof.Get(m, "k") is IList<object> k) { var a = k.Select(Prof.D).ToArray(); p.Kind = 'k'; p.Args = new[] { a[2] + Prof.Num(Prof.Get(m, "spin")) * T, a[0], a[1] }; }
            var cs = Prof.List(m["c"]);
            int n = cs.Count;
            for (int i = 0; i < n; i++)
            {
                if (cs[i] is IList<object> st) p.Add(Prof.D(st[0]), (string)st[1]);
                else p.Add(n > 1 ? (double)i / (n - 1) : 0, (string)cs[i]);
            }
            return p;
        }

        public static void DrawShape(Canvas2D c, ChestShape s, Warp w, double T)
        {
            if (s.Txt != null)
            {
                w(s.X, s.Y, out var tx, out var ty);
                c.Save(); c.Translate(tx, ty); if (s.Rot != 0) c.Rotate(s.Rot); if (s.A >= 0) c.GlobalAlpha *= s.A;
                var (font, size) = Font(s.Font);
                c.FillStyle = s.F as string ?? "#000";
                c.FillText(s.Txt, 0, 0, font, size);
                c.Restore();
                return;
            }
            c.Save();
            if (s.A >= 0) c.GlobalAlpha *= s.A;
            if (s.Op != null) c.GlobalCompositeOperation = s.Op;
            if (s.ClipSp != null) { Trace(c, s.ClipSp, w); c.Clip(); }
            Trace(c, s.Sp, w);
            if (s.F != null) { c.FillStyle = Paint(s.F, T); c.Fill(); }
            if (s.S != null)
            {
                c.LineWidth = s.W; c.StrokeStyle = Paint(s.S, T); c.LineJoin = "round"; c.LineCap = "round";
                if (s.G != null) { c.ShadowColor = s.G; c.ShadowBlur = s.Gb; }
                c.Stroke();
            }
            c.Restore();
        }

        public static void DrawPart(Canvas2D c, ChestPart p, Warp w, double T, double ang)
        {
            bool turn = ang != 0 && p.Hang != null;
            if (turn) { w(p.Hang[0], p.Hang[1], out var px, out var py); c.Save(); c.Translate(px, py); c.Rotate(ang); c.Translate(-px, -py); }
            foreach (var s in p.Sh) DrawShape(c, s, w, T);
            if (turn) c.Restore();
        }

        /// <summary>A CSS font ("700 8px Fredoka, Nunito, sans-serif") as one of the app's fonts.</summary>
        public static (string font, float size) Font(string css)
        {
            var parts = (css ?? "700 10px Fredoka").Split(' ');
            int weight = int.TryParse(parts[0], out var wv) ? wv : 400;
            float size = float.Parse(parts[1].Replace("px", ""), CultureInfo.InvariantCulture);
            string fam = parts.Length > 2 ? parts[2].Trim(',') : "Fredoka";
            string font = fam == "Fredoka" ? (weight >= 700 ? "Fredoka_700Bold" : weight >= 600 ? "Fredoka_600SemiBold" : "Fredoka_500Medium")
                : weight >= 900 ? "Nunito_900Black" : weight >= 800 ? "Nunito_800ExtraBold" : weight >= 700 ? "Nunito_700Bold" : "Nunito_600SemiBold";
            return (font, size);
        }

        /// <summary>drawIcon(c, k, s, col): the icon's recorded canvas calls (at size 100, colour "#COL"), scaled to s.</summary>
        public static void DrawIcon(Canvas2D c, string k, double s, string col)
        {
            var ops = Icon(k) ?? Icon("gem");
            if (ops == null) return;
            double f = s / 100;
            c.LineJoin = "round";
            string Col(object v) => v is string str ? str.Replace("#COL", col ?? "#9fd8ff") : null;
            CanvasPaint Style(object v)
            {
                if (v is string str) return Col(str);
                var m = Prof.Map(v);
                if (m == null) return "#000";
                var a = Prof.List(m["a"]).Select(x => Prof.D(x) * f).ToArray();
                var p = new CanvasPaint { Kind = (string)m["g"] == "l" ? 'l' : 'r', Args = a };
                foreach (var st in Prof.List(m["s"]).Select(Prof.List)) p.Add(Prof.D(st[0]), Col(st[1]));
                return p;
            }
            foreach (var o in ops)
            {
                var op = Prof.List(o);
                string name = (string)op[0];
                double A(int i) => Prof.D(op[i]);
                switch (name)
                {
                    case "set":
                        string prop = (string)op[1];
                        if (prop == "fillStyle") c.FillStyle = Style(op[2]);
                        else if (prop == "strokeStyle") c.StrokeStyle = Style(op[2]);
                        else if (prop == "lineWidth") c.LineWidth = Prof.D(op[2]) * f;
                        else if (prop == "lineJoin") c.LineJoin = (string)op[2];
                        else if (prop == "lineCap") c.LineCap = (string)op[2];
                        else if (prop == "globalAlpha") c.GlobalAlpha = Prof.D(op[2]);
                        break;
                    case "beginPath": c.BeginPath(); break;
                    case "closePath": c.ClosePath(); break;
                    case "moveTo": c.MoveTo(A(1) * f, A(2) * f); break;
                    case "lineTo": c.LineTo(A(1) * f, A(2) * f); break;
                    case "quadraticCurveTo": c.QuadraticCurveTo(A(1) * f, A(2) * f, A(3) * f, A(4) * f); break;
                    case "bezierCurveTo": c.BezierCurveTo(A(1) * f, A(2) * f, A(3) * f, A(4) * f, A(5) * f, A(6) * f); break;
                    case "arc": c.Arc(A(1) * f, A(2) * f, A(3) * f, A(4), A(5), op.Count > 6 && Prof.Truthy(op[6])); break;
                    case "ellipse": c.Ellipse(A(1) * f, A(2) * f, A(3) * f, A(4) * f, A(5), A(6), A(7), op.Count > 8 && Prof.Truthy(op[8])); break;
                    case "rect": c.Rect(A(1) * f, A(2) * f, A(3) * f, A(4) * f); break;
                    case "fill": c.Fill(); break;
                    case "stroke": c.Stroke(); break;
                    case "fillRect": c.FillRect(A(1) * f, A(2) * f, A(3) * f, A(4) * f); break;
                    case "save": c.Save(); break;
                    case "restore": c.Restore(); break;
                    case "translate": c.Translate(A(1) * f, A(2) * f); break;
                    case "rotate": c.Rotate(A(1)); break;
                    case "scale": c.Scale(A(1), A(2)); break;
                }
            }
        }
    }
}
