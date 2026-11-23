// The Yard Games (HOUSE_PORT_PLAN.md stage 11): yard-games.js's framework ported, plain C# (no UnityEngine).
// A game draws into two SVG layers (bg under the creatures, fg over them) of a 360 x 640 portrait stage, as the page
// does: a small retained SVG DOM (El: S() makes an element, Set() an attribute, Html() its innerHTML, Clear(),
// Remove(), InsertBefore()) so each game's code ports line by line; every change marks its top-level group dirty and
// Games/Yard/YardScreen.cs redraws only those. The helpers (cl, lerp, SM, r2, ease, track, cam, shadow, the shared
// defs and the backyard backdrop), the creatures (the player's live rig: x, y, size, roll, yaw, moves, ext channels,
// the house gait on the spot), the score, timer, hint, toasts, particle bursts, the intro and result cards, and the
// saved bests (yardgames.v1: best, plays, player) are the page's.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Games.Yard
{
    // ---------- the retained SVG ----------
    public sealed class El
    {
        public string Tag;
        public readonly List<KeyValuePair<string, string>> A = new List<KeyValuePair<string, string>>();
        public readonly List<El> Kids = new List<El>();
        public El Parent;
        public string Raw;          // innerHTML set as markup (its children are then the raw text)
        public string Text;         // a text node's content (Tag "#text")
        public int Ver;             // bumped on any change below (the screen redraws what changed)

        public El(string tag) { Tag = tag; }
        static string Fmt(object v) => v is double d ? Num(d) : v is float f ? Num(f) : v is int i ? i.ToString(CultureInfo.InvariantCulture) : v?.ToString() ?? "";
        public static string Num(double d) => SquishSquad.Anim.JsNumber.ToString(d);

        public void Touch() { for (var e = this; e != null; e = e.Parent) e.Ver++; }
        public string Get(string k) { foreach (var kv in A) if (kv.Key == k) return kv.Value; return null; }
        /// <summary>setAttribute (null: removeAttribute); unchanged values don't count as a change (the page's set()).</summary>
        public El Set(string k, object v)
        {
            string s = v == null ? null : Fmt(v);
            for (int i = 0; i < A.Count; i++) if (A[i].Key == k) { if (A[i].Value == s) return this; if (s == null) A.RemoveAt(i); else A[i] = new KeyValuePair<string, string>(k, s); Touch(); return this; }
            if (s != null) { A.Add(new KeyValuePair<string, string>(k, s)); Touch(); }
            return this;
        }
        public El Add(El c) { c.Parent?.Kids.Remove(c); c.Parent = this; Raw = null; Kids.Add(c); Touch(); return c; }
        public El InsertBefore(El c, El before) { c.Parent?.Kids.Remove(c); c.Parent = this; int i = before == null ? -1 : Kids.IndexOf(before); if (i < 0) Kids.Add(c); else Kids.Insert(i, c); Touch(); return c; }
        /// <summary>insertBefore(c, after.nextSibling)</summary>
        public El InsertAfter(El c, El after) { int i = Kids.IndexOf(after); return InsertBefore(c, i >= 0 && i + 1 < Kids.Count ? Kids[i + 1] : null); }
        public void Remove() { if (Parent == null) return; var p = Parent; p.Kids.Remove(this); Parent = null; p.Touch(); }
        /// <summary>innerHTML = '' </summary>
        public void Clear() { if (Kids.Count == 0 && Raw == null) return; foreach (var k in Kids) k.Parent = null; Kids.Clear(); Raw = null; Touch(); }
        /// <summary>innerHTML = markup</summary>
        public void Html(string markup) { foreach (var k in Kids) k.Parent = null; Kids.Clear(); Raw = markup; Touch(); }
        public void SetText(string t) { Clear(); Add(new El("#text") { Text = t }); }

        /// <summary>How a &lt;text&gt; element is written (the screen draws its glyphs as paths; null: as it is).</summary>
        public static Func<El, string> TextHook;
        public string TextContent() { var sb = new StringBuilder(); foreach (var k in Kids) if (k.Tag == "#text") sb.Append(k.Text); return sb.ToString(); }
        public void Write(StringBuilder sb)
        {
            if (Tag == "#text") { sb.Append(Esc(Text)); return; }
            if (Tag == "text" && TextHook != null) { sb.Append(TextHook(this)); return; }
            sb.Append('<').Append(Tag);
            foreach (var kv in A) sb.Append(' ').Append(kv.Key).Append("=\"").Append(Esc(kv.Value)).Append('"');
            if (Kids.Count == 0 && Raw == null) { sb.Append("/>"); return; }
            sb.Append('>'); if (Raw != null) sb.Append(Raw); foreach (var k in Kids) k.Write(sb); sb.Append("</").Append(Tag).Append('>');
        }
        static string Esc(string s) => s.Replace("&", "&amp;").Replace("<", "&lt;").Replace("\"", "&quot;");
    }

    public static class YK
    {
        public const double W = 360, H = 640, TAU = Math.PI * 2;
        /// <summary>S(tag, attrs, parent): an element; attrs as name, value pairs (null values left out).</summary>
        public static El S(string tag, El parent, params object[] kv)
        {
            var e = new El(tag); for (int i = 0; i + 1 < kv.Length; i += 2) if (kv[i + 1] != null) e.Set((string)kv[i], kv[i + 1]);
            parent?.Add(e); return e;
        }
        public static double cl(double v, double a, double b) => v < a ? a : v > b ? b : v;
        public static double lerp(double a, double b, double u) => a + (b - a) * u;
        public static double SM(double u) { u = cl(u, 0, 1); return u * u * (3 - 2 * u); }
        public static double r2(double v) => Math.Round(v * 100, MidpointRounding.AwayFromZero) / 100;
        public static string N(double v) => El.Num(r2(v));
        public static class ease
        {
            public static double o(double u) => 1 - (1 - u) * (1 - u);
            public static double i(double u) => u * u;
            public static double io(double u) => u < 0.5 ? 2 * u * u : 1 - 2 * (1 - u) * (1 - u);
            public static double back(double u) { const double c = 1.7; return 1 + (c + 1) * Math.Pow(u - 1, 3) + c * Math.Pow(u - 1, 2); }
        }
        /// <summary>A pose track: keys (t ms, channel values) -> the values at t (eased in-out between keys).</summary>
        public static Dictionary<string, double> track(IList<(double t, Dictionary<string, double> v)> keys, double t)
        {
            var o = new Dictionary<string, double>(); var chs = new List<string>();
            foreach (var k in keys) foreach (var c in k.v.Keys) if (!chs.Contains(c)) chs.Add(c);
            foreach (var c in chs)
            {
                (double t, Dictionary<string, double> v)? a = null, b = null;
                foreach (var k in keys) { if (!k.v.ContainsKey(c)) continue; if (k.t <= t) a = k; else { b = k; break; } }
                o[c] = a == null ? (b != null ? b.Value.v[c] : 0) : b == null ? a.Value.v[c] : lerp(a.Value.v[c], b.Value.v[c], ease.io((t - a.Value.t) / Math.Max(1, b.Value.t - a.Value.t)));
            }
            return o;
        }
        public static Dictionary<string, double> P(params object[] kv) { var d = new Dictionary<string, double>(); for (int i = 0; i + 1 < kv.Length; i += 2) d[(string)kv[i]] = Convert.ToDouble(kv[i + 1], CultureInfo.InvariantCulture); return d; }
        /// <summary>A camera behind the player: metres (x right, y up, z away) -> [screen x, screen y, px per metre there].</summary>
        public static Func<double, double, double, double[]> cam(double Dc, double CH, double HY, double K) => (x, y, z) => { double s = Dc / (Dc + z); return new[] { W / 2 + x * s * K, HY + (CH - y) * s * K, s * K }; };
        /// <summary>A soft ground shadow ellipse.</summary>
        public static El shadow(El p, double x, double y, double rx, double op = 0.18) => S("ellipse", p, "cx", x, "cy", y, "rx", rx, "ry", rx * 0.22, "fill", "#3a2a55", "opacity", op);

        /// <summary>The shared gradients and filters every game can use by id (each layer's SVG carries them).</summary>
        public const string Defs = "<radialGradient id=\"ygBall\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffb070\"/><stop offset=\"0.55\" stop-color=\"#f07a2e\"/><stop offset=\"1\" stop-color=\"#b44a14\"/></radialGradient>"
            + "<radialGradient id=\"ygWhite\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.6\" stop-color=\"#eef0f6\"/><stop offset=\"1\" stop-color=\"#b8bccb\"/></radialGradient>"
            + "<radialGradient id=\"ygGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient>"
            + "<linearGradient id=\"ygSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7cc6ff\"/><stop offset=\"0.65\" stop-color=\"#bfe6ff\"/><stop offset=\"1\" stop-color=\"#eaf7ff\"/></linearGradient>"
            + "<linearGradient id=\"ygGrass\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fdc6e\"/><stop offset=\"1\" stop-color=\"#5fb04a\"/></linearGradient>"
            + "<linearGradient id=\"ygWood\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#c98d54\"/><stop offset=\"0.5\" stop-color=\"#e2ad74\"/><stop offset=\"1\" stop-color=\"#b47740\"/></linearGradient>"
            + "<filter id=\"ygSoft\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"2.2\"/></filter>";

        /// <summary>The backyard backdrop: sky, clouds, trees, the picket fence, grass with seeded tufts and flowers.</summary>
        public static void yard(El p, double hz = 250, bool sky = true, bool trees = true, bool fence = true, bool flowers = true)
        {
            if (sky)
            {
                S("rect", p, "x", -20, "y", -20, "width", W + 40, "height", hz + 40, "fill", "url(#ygSky)");
                foreach (var (x, y, k) in new[] { (60.0, 70.0, 1.0), (250.0, 46.0, 0.8), (320.0, 120.0, 0.6), (140.0, 140.0, 0.55) })
                {
                    var g = S("g", p, "opacity", 0.92, "transform", "translate(" + El.Num(x) + " " + El.Num(y * hz / 250) + ") scale(" + El.Num(k) + ")");
                    foreach (var (a, b, r) in new[] { (-26, 4, 18), (0, -6, 24), (26, 4, 18), (10, 8, 18), (-12, 9, 16) }) S("circle", g, "cx", a, "cy", b, "r", r, "fill", "#ffffff");
                }
            }
            if (trees)
                foreach (var (x, k) in new[] { (18.0, 0.9), (342.0, 1.1), (300.0, 0.7) })
                {
                    var g = S("g", p, "transform", "translate(" + El.Num(x) + " " + El.Num(hz - 6) + ") scale(" + El.Num(k) + ")");
                    S("rect", g, "x", -4, "y", -34, "width", 8, "height", 36, "rx", 3, "fill", "#8a5a34");
                    foreach (var (a, b, r) in new[] { (-14, -44, 18), (12, -46, 20), (0, -62, 22), (-4, -40, 16) }) S("circle", g, "cx", a, "cy", b, "r", r, "fill", "#57a854");
                    S("circle", g, "cx", -6, "cy", -66, "r", 9, "fill", "#7cc46a", "opacity", 0.8);
                }
            if (fence)
            {
                double fy = hz - 34; var g = S("g", p);
                S("rect", g, "x", -10, "y", fy + 10, "width", W + 20, "height", 6, "fill", "#f3e8da"); S("rect", g, "x", -10, "y", fy + 26, "width", W + 20, "height", 6, "fill", "#f3e8da");
                for (double x = -6; x < W + 10; x += 18) S("path", g, "d", "M" + El.Num(x) + " " + El.Num(fy + 38) + "V" + El.Num(fy + 6) + "L" + El.Num(x + 6) + " " + El.Num(fy) + "L" + El.Num(x + 12) + " " + El.Num(fy + 6) + "V" + El.Num(fy + 38) + "Z", "fill", "#fff8ee", "stroke", "#e2cfb8", "stroke-width", 1);
            }
            S("rect", p, "x", -20, "y", hz, "width", W + 40, "height", H - hz + 20, "fill", "url(#ygGrass)");
            double sd = 7; double rnd() { sd = (sd * 9301 + 49297) % 233280; return sd / 233280; }
            var tg = S("g", p, "opacity", 0.55);
            for (int i = 0; i < 46; i++)
            {
                double x = rnd() * W, y = hz + 8 + rnd() * (H - hz - 10), k = 0.6 + (y - hz) / (H - hz) * 0.9;
                S("path", tg, "d", "M" + N(x - 3 * k) + " " + N(y) + "q" + N(1 * k) + " " + N(-6 * k) + " " + N(2 * k) + " " + N(-8 * k) + "q" + N(0.5 * k) + " " + N(5 * k) + " " + N(1.6 * k) + " " + N(8 * k) + "q" + N(1 * k) + " " + N(-5 * k) + " " + N(3 * k) + " " + N(-7 * k) + "q" + N(-0.6 * k) + " " + N(5 * k) + " " + N(0.4 * k) + " " + N(7 * k) + "Z", "fill", "#4f9a3e");
            }
            if (flowers)
                for (int i = 0; i < 9; i++)
                {
                    double x = rnd() * W, y = hz + 14 + rnd() * (H - hz - 30), k = 0.7 + (y - hz) / (H - hz) * 0.8; string c = new[] { "#ffd1e8", "#fff3a8", "#ffffff", "#d9c8ff" }[i % 4];
                    for (int j = 0; j < 5; j++) S("circle", p, "cx", r2(x + Math.Cos(j * 1.2566) * 2.6 * k), "cy", r2(y + Math.Sin(j * 1.2566) * 2.6 * k), "r", r2(1.9 * k), "fill", c);
                    S("circle", p, "cx", r2(x), "cy", r2(y), "r", r2(1.3 * k), "fill", "#ffb84a");
                }
        }
    }

    // ---------- a creature in a game ----------
    /// <summary>The player's (or an opponent's) live rig: feet at (X, Y) in stage units, its box Size high (feet ~93 %
    /// down it); E = ext channels (added to whatever move plays; Pose clears them and sets some), Yaw = facing (0 you,
    /// 180 away, 90 right), Rot = a whole-body roll about (Ox, Oy) % of its box, Walk = its house gait on the spot.</summary>
    public sealed class YardCreature
    {
        public string Key; public double X, Y, Size = 100, R, Ox = 50, Oy = 93, Z, YawDeg; public bool Hidden, Gone, Behind;
        public readonly Dictionary<string, double> E = new Dictionary<string, double>();
        public readonly SquishSquad.House.HouseWalk.State Ws = new SquishSquad.House.HouseWalk.State();
        public Action<string> OnPlay; public string Move = "idle";
        public YardCreature set(double? x = null, double? y = null, double? size = null) { if (x != null) X = x.Value; if (y != null) Y = y.Value; if (size != null) Size = size.Value; return this; }
        public YardCreature rot(double deg, double? ox = null, double? oy = null) { R = deg; if (ox != null) { Ox = ox.Value; Oy = oy ?? Oy; } return this; }
        public YardCreature yaw(double deg) { YawDeg = deg; return this; }
        public YardCreature play(string n) { Move = n; OnPlay?.Invoke(n); return this; }
        public YardCreature pose(Dictionary<string, double> p = null) { foreach (var k in new List<string>(E.Keys)) E[k] = 0; if (p != null) foreach (var kv in p) E[kv.Key] = kv.Value; return this; }
        public static SquishSquad.House.HouseWalk Walker;
        public YardCreature walk(double dt, double w, double spin = 0) { if (w > 0.01 && Walker != null) try { Walker.Step(Key, Ws, E, w, dt, 1, spin); } catch (Exception) { } return this; }
        public YardCreature depth(double z) { Z = z; return this; }
        public YardCreature hide(bool v) { Hidden = v; return this; }
    }

    // ---------- particles, toasts ----------
    public sealed class YardPart { public El E; public double X, Y, Vx, Vy, G, Life, T, Rot, Vr, K; }
    public sealed class YardToast { public string Txt, Col; public double X, Y, T0; public bool Big; }
    public sealed class BurstOpts { public double? Dir, G, V, Life, K; public double Spread = YK.TAU; public string Col; public El Layer; }

    /// <summary>A yard game: the page's YG.add({...}) entry and its make(ctx) instance.</summary>
    public abstract class YardGame
    {
        public string Id, Name, Item, Color, Icon, Hint; public double Dur; public double[] Stars; public double CoinK = 1; public string[] How;
        public (string id, string label)[] Options; public string Opt;
        protected YardCtx ctx;
        public virtual void Make(YardCtx c) { ctx = c; }
        public virtual void Start() { }
        public virtual void Update(double dt, double t) { }
        public virtual void Down(double x, double y, double t) { }
        public virtual void Move(double x, double y, double t) { }
        public virtual void Up(double x, double y, double t) { }
        public virtual bool TimeUp() => false;   // (true: the game handles the end itself)
        public virtual void Celebrate(int stars) { }
        public virtual void Destroy() { }
    }

    /// <summary>The running game's context (yard-games.js run()'s ctx) and its loop.</summary>
    public sealed class YardCtx
    {
        public const double W = YK.W, H = YK.H;
        /// <summary>The layers bottom to top: bg, the creatures marked Behind, mid (Ping-Pong's table), the other creatures, fg.</summary>
        public readonly El bg = new El("g"), mid = new El("g"), fg = new El("g");
        public readonly YardGame G;
        public string playerKey, playerName;
        public readonly List<YardCreature> Creatures = new List<YardCreature>();
        public readonly List<YardPart> Parts = new List<YardPart>();
        public readonly List<YardToast> Toasts = new List<YardToast>();
        /// <summary>A game's own row of marks in a pill under the top bar (Penalty Kick's five kicks): (mark, colour).</summary>
        public List<(string ch, string col)> Dots;
        /// <summary>A game's own pill at the top right under the bar (Cornhole's wind).</summary>
        public string Badge;
        /// <summary>A game's own text pill at the top centre under the bar (Ping-Pong's score).</summary>
        public string CenterPill;
        /// <summary>A game's own buttons in a bar at the bottom (Hopscotch's Hop / Split / Leap): id, label, colour, icon
        /// SVG, lit; pressed: OnButton(id).</summary>
        public sealed class Btn { public string Id, Label, Color, Icon; public bool Lit; public double PressedAt = -1e9; }
        public List<Btn> Buttons; public Action<string> OnButton;
        public void PressButton(string id) { var b = Buttons?.Find(x => x.Id == id); if (b != null) b.PressedAt = Now; OnButton?.Invoke(id); }
        public int score; public double left, ScoreBumpAt = -1e9; public bool playing, ended; public string TimerTxt, HintTxt; public bool Hurry;
        public double Now;            // ms since the game started (the page's rAF t)
        public Action<string> Sfx = n => { };
        public Func<IList<string>> Roster = () => new[] { "biscuit", "pip", "mallow", "nimbo", "ribbit", "bao", "mittens", "sealy", "frybo", "poppy" };
        public Func<string, string> NameOf = k => k;
        public Action<YardCreature> CreatureMade;
        public Action<Dictionary<string, object>> Finished;   // (the screen shows the results)
        public readonly Random Rnd = new Random();
        public double rand() => Rnd.NextDouble();

        public YardCtx(YardGame g, string key, string name) { G = g; playerKey = key; playerName = name; left = g.Dur; }

        public YardCreature creature(string key, double? x = null, double? y = null, double? size = null, double? yaw = null, bool behind = false)
        {
            var c = new YardCreature { Key = key, Behind = behind }; if (yaw != null) c.yaw(yaw.Value); c.set(x ?? W / 2, y ?? H - 60, size ?? 140);
            Creatures.Add(c); CreatureMade?.Invoke(c); return c;
        }
        public List<string> opponent(int n)
        {
            var pool = new List<string>(Roster()); pool.Remove(playerKey); var o = new List<string>();
            while (o.Count < n && pool.Count > 0) { int i = (int)Math.Floor(rand() * pool.Count); o.Add(pool[i]); pool.RemoveAt(i); }
            return o;
        }
        public string nameOf(string key) => NameOf(key);
        public void add(int n, double? x = null, double? y = null, string txt = null, string col = null) { score = Math.Max(0, score + n); ScoreBumpAt = Now; if (txt != null) toast(txt, x, y, col); }
        public void setScore(int n) => score = n;
        public void timer(string txt) => TimerTxt = txt;
        public void hint(string t) => HintTxt = t ?? "";
        public double time => left;
        public void toast(string txt, double? x = null, double? y = null, string col = null, bool big = false) => Toasts.Add(new YardToast { Txt = txt, X = x ?? W / 2, Y = y ?? H * 0.4, Col = col ?? "#ffffff", Big = big, T0 = Now });
        public void sfx(string n) => Sfx(n);

        /// <summary>A particle burst: 'spark' | 'star' | 'drop' | 'dust' | 'confetti'.</summary>
        public void burst(double x, double y, string kind, int n = 10, BurstOpts o = null)
        {
            o ??= new BurstOpts(); string[] cols = { "#ffd84a", "#ff8fc8", "#8fe0ff", "#b6f07a", "#ffffff" };
            for (int i = 0; i < n; i++)
            {
                double a = (o.Dir ?? -Math.PI / 2) + (rand() - 0.5) * o.Spread, v = (o.V ?? 120) * (0.5 + rand() * 0.7);
                string col = o.Col ?? (kind == "drop" ? "#8fd3ff" : kind == "dust" ? "#d8c7a8" : cols[i % 5]);
                var L = o.Layer ?? fg;
                El e = kind == "star" || kind == "spark" ? YK.S("path", L, "d", "M0-5L1.4-1.4L5 0L1.4 1.4L0 5L-1.4 1.4L-5 0L-1.4-1.4Z", "fill", col)
                    : kind == "confetti" ? YK.S("rect", L, "x", -2.5, "y", -1.5, "width", 5, "height", 3, "fill", col)
                    : YK.S("circle", L, "r", kind == "dust" ? 4 : 2.6, "fill", col, "opacity", kind == "dust" ? 0.6 : 0.9);
                Parts.Add(new YardPart { E = e, X = x, Y = y, Vx = Math.Cos(a) * v, Vy = Math.Sin(a) * v, G = o.G ?? (kind == "dust" ? -20 : 260), Life = (o.Life ?? 0.8) * (0.7 + rand() * 0.5), Rot = rand() * 360, Vr = (rand() - 0.5) * 600, K = o.K ?? (kind == "dust" ? 1.8 : 1) });
            }
        }

        public void finish(Dictionary<string, object> extra = null)
        {
            if (ended) return; ended = true; playing = false;
            Later(extra != null && extra.TryGetValue("delay", out var d) ? Convert.ToDouble(d) : 700, () => Finished?.Invoke(extra ?? new Dictionary<string, object>()));
        }

        // timers (the page's setTimeout), run by the loop
        readonly List<(double at, Action f)> _later = new List<(double, Action)>();
        public void Later(double ms, Action f) => _later.Add((Now + ms, f));

        /// <summary>start(): the clock, score 0, "Go!".</summary>
        public void Begin() { playing = true; ended = false; score = 0; left = G.Dur; toast("Go!", W / 2, H * 0.42, "#ffffff", true); sfx("pop"); G.Start(); }

        /// <summary>The page's loop: the clock (the last 5 s tick), the game's update, the particles, the timers.</summary>
        public void Step(double dt)
        {
            dt = Math.Min(0.05, dt); Now += dt * 1000;
            if (playing && G.Dur > 0)
            {
                double pl0 = Math.Ceiling(left); left = Math.Max(0, left - dt);
                if (Math.Ceiling(left) != pl0 && left <= 5 && left > 0) sfx("tick");
                timer(Math.Ceiling(left) + "s"); Hurry = left <= 5;
                if (left <= 0) { if (!G.TimeUp()) finish(); }
            }
            G.Update(dt, Now);
            for (int i = Parts.Count - 1; i >= 0; i--)
            {
                var q = Parts[i]; q.T += dt; if (q.T >= q.Life) { q.E.Remove(); Parts.RemoveAt(i); continue; }
                q.Vy += q.G * dt; q.X += q.Vx * dt; q.Y += q.Vy * dt; q.Rot += q.Vr * dt; double u = q.T / q.Life;
                q.E.Set("transform", "translate(" + YK.N(q.X) + " " + YK.N(q.Y) + ") rotate(" + Math.Round(q.Rot) + ") scale(" + YK.N((1 - u * 0.5) * q.K) + ")"); q.E.Set("opacity", YK.r2(1 - u * u));
            }
            for (int i = 0; i < _later.Count; i++) if (_later[i].at <= Now) { var f = _later[i].f; _later.RemoveAt(i--); f(); }
            Toasts.RemoveAll(t => Now - t.T0 > (t.Big ? 1400 : 1000));
        }
    }

    /// <summary>The saved bests and plays (the page's localStorage yardgames.v1), and the result card's numbers.</summary>
    public sealed class YardSave
    {
        public readonly Dictionary<string, int> Best = new Dictionary<string, int>(), Plays = new Dictionary<string, int>();
        public string Player;
        public (string title, int stars, bool newBest, int best, int coins) Result(YardGame G, int score, string title = null)
        {
            Best.TryGetValue(G.Id, out var best); bool nb = score > best; if (nb) Best[G.Id] = score;
            Plays[G.Id] = (Plays.TryGetValue(G.Id, out var p) ? p : 0) + 1;
            int st = 0; if (G.Stars != null) foreach (var v in G.Stars) if (score >= v) st++;
            return (title ?? (st >= 3 ? "Amazing!" : st == 2 ? "Great job!" : st == 1 ? "Nice!" : "Good try!"), st, nb, best, Math.Max(1, (int)Math.Round(score * G.CoinK)));
        }
    }
}
