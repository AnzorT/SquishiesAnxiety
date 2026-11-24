// The result card's three characters (src/squishdoku/Trio.js, the user, 2026-11-17: "i want a genuine character there
// that is grayed and once they are filled their color changes and they jump from joy, not a fast jump, a slow one and
// they show happy animations"), and what the app's page does with them (tools/rig/result.html, through
// hop/RigStage.js): they pop in grey; at T0 + i × STEP an earned one fills with colour from its feet up, jumps slowly
// for joy and then keeps playing happy moves, with the gold rays behind it; a missed one sighs and stays grey.
//
// The page's part is here, move for move (the body's lift, squash and tilt about its feet, the pop in, the fill's edge,
// the floor shadow, the arms and turns it hands the rig as `ext`); the rig itself (its face, its own states resWait /
// resWow / resHappy / resMiss / resSad) is a live creature the host draws (CardLayer.Creature: Ui/Cards/CardPieces.cs
// with Creatures/ResultRig.cs). While the creatures load (and in the pixel tests, which can't draw them), each one's
// cut-out (stack/art.js) stands in as a soft grey shape, as in the app; the card's stars, sounds and coins wait for the
// characters (Card.Go).
//
// Which way a card goes (GameCards.ResultCard): live when the host can draw all three (`LiveFor`), else the stills
// (`Stills`: the tests, and the app's grey shapes while it waits) or the gold stars (the app's fallback when its rigs
// can't draw: `Characters` off, or no rig).
// No UnityEngine here, so the cards run outside Unity as well.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    /// <summary>A rig's body box at rest, in its 0-100 units (result.html measure(): the svg's getBBox without the floor
    /// shadow).</summary>
    public sealed class RigBody
    {
        public double Cx, Gy, Bw, Bh, Top, Left;
    }

    /// <summary>A live character a card layer stands for (the layer's Transform maps its rig's 0-100 box to the screen,
    /// dp). The item sets what the rig plays; the host draws it and says when its body is known.</summary>
    public sealed class CardCreature
    {
        public string Key;
        /// <summary>"result" (the result card's, its rig with result.html's states) or "walk" (Squish Stack's forest
        /// walker: the plain rig, turned by `Yaw`, walking its own gait while `Walk` is on).</summary>
        public string Kind = "result";
        /// <summary>The walker: its turn (degrees; 0 faces you, ±90 side-on: rive-rig's spinOff), its gait's weight
        /// (0 standing … 1 walking: HouseWalk.step's) and the way it walks (±90).</summary>
        public double Yaw, Walk, WalkSpin;
        /// <summary>The rig's state now (result.html's play(): resWait, resWow, resHappy, resMiss) and, for a rig played
        /// from recordings, the clip that stands for this stretch ("wait", "fill", "happy", "miss") and when it began
        /// (the card's clock, ms).</summary>
        public string State = "resWait", Clip = "wait";
        public double ClipAt;
        /// <summary>The page's moves on the rig this frame (its arms, turn, feet: rive-rig's `ext`).</summary>
        public readonly Dictionary<string, double> Ext = new Dictionary<string, double>();
        /// <summary>Grey above this line (a fraction of the 0-100 box from its top): 2 all grey, -1 none.</summary>
        public float GreyAbove = 2;
        /// <summary>Its pixel size: dp per rig unit at rest.</summary>
        public float Unit;
        /// <summary>Set by the host: the body box once the rig has drawn (null until then); Failed when it can't.</summary>
        public RigBody Body;
        public bool Failed;
        /// <summary>Particle bursts for the host to start (result.html burst(): the kind, at x, y in rig units or at the
        /// rig's own spot `at` such as "eyeL", and how many).</summary>
        public readonly List<(string kind, string at, double x, double y, int n)> Bursts = new List<(string, string, double, double, int)>();
    }

    public sealed class TrioItem : CardItem
    {
        /// <summary>The live characters on (Unity's host sets LiveFor) or the stars. The switch for the whole app.</summary>
        public static bool Characters = true;
        /// <summary>The host: whether it can draw these three live (Unity: CardPieces, from Creatures/ResultRig). Null
        /// outside Unity.</summary>
        public static Func<string[], bool> LiveFor;
        /// <summary>The pixel tests: the trio with its grey stills in place of the stars, without live creatures.</summary>
        public static bool Stills;
        /// <summary>A cut-out's height / width (stack/art.js `ar`; Resources/Stack/stack.json artList).</summary>
        public static Func<string, float> ArOf = _ => 1;

        /// <summary>How this card shows its three: "live", "stills" or null (the stars).</summary>
        public static string ModeFor(string[] keys)
        {
            if (!Characters || keys == null || keys.Length != 3 || Array.Exists(keys, k => string.IsNullOrEmpty(k))) return null;
            if (LiveFor != null && LiveFor(keys)) return "live";
            return Stills ? "stills" : null;
        }

        // Trio.js: the page is given WAIT_MS to draw the three; it's made MOUNT_MS in; the shapes fade in at SHAPES_MS
        const double WAIT_MS = 4000, MOUNT_MS = 650, SHAPES_MS = 380;
        // where the three stand (fractions of the row's width), the row TW x TH, each one's most width and height
        static readonly double[] AT = { 0.17, 0.5, 0.83 };
        const float TW = 300, TH = 88;
        static readonly float[] LW = { 62, 74, 62 }, LH = { 70, 84, 70 };

        sealed class Move
        {
            public double T0, Dur;
            public bool HasBefore;
            public Func<double, Out> Run;
            public Action Done;
        }
        sealed class Out
        {
            public double K = double.NaN, O = double.NaN, Lift, Sq, Tilt;
            public Dictionary<string, double> Ext;
        }
        sealed class Happy { public double T0, Next = -1, At; public int N; public HappyMove Mv; }
        sealed class HappyMove { public double Ms; public Func<double, Out> F; }
        sealed class One
        {
            public int I;
            public string Key;
            public bool Earned, Shown;
            public float W, H, Ar;
            public string Mode = "wait";
            public List<Move> Moves = new List<Move>();
            public Happy Happy;
            public double Fill = -1;   // the colour's rise while it fills (0..1), -1 not filling
            public CardLayer Rays, Shape, Shadow, Rig, Edge;
            public CardCreature C;
            public readonly AnimatedValue Glow = new AnimatedValue(0);
            public readonly Spin Spin = new Spin();
        }

        readonly One[] _one = new One[3];
        readonly int _stars;
        readonly double _t0, _step;
        readonly bool _live;
        readonly Action<bool> _onGo;
        readonly AnimatedValue _shapes = new AnimatedValue(0);
        CompositeAnimation _shapesA;
        Ticker _tk;
        double _mountAt;
        bool _on, _went, _ok;
        readonly List<int> _timers = new List<int>();
        static readonly Interpolator GlowScale = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.4, 1 });

        /// <summary>`keys`' three (Trio.js), `stars` of them earned, the first filling at `t0` ms after the run starts,
        /// then every `step`; `live`: the host draws them (else the stills); `onGo(ok)`: the run starts (the card's
        /// Go: its coins and XP).</summary>
        public TrioItem(string[] keys, int stars, double t0, double step, bool live, Action<bool> onGo, bool stampRoom = false)
        {
            MarginTop = 2; MarginBottom = stampRoom ? 30 : 4;
            _stars = stars; _t0 = t0; _step = step; _live = live; _onGo = onGo;
            for (int i = 0; i < 3; i++)
            {
                var o = new One { I = i, Key = keys[i], Earned = i < stars, W = LW[i], H = LH[i], Ar = ArOf(keys[i]) };
                _one[i] = o;
            }
        }

        public override bool IsStatic => false;

        public override void Measure(float colW)
        {
            W = TW; H = TH;
            foreach (var o in _one)
            {
                if (o.Earned)
                {
                    int S = (int)Math.Floor(o.W * 1.9 + 0.5);
                    (o.Rays ??= new CardLayer("trio rays")).Set(CardArt.Rays(S, opacity: 0.55f, color: "#ffe45c"), S, S, 1);
                }
                // its cut-out as a soft grey shape (tintColor #dccfbf), or in colour once it's earned and the rigs can't play
                float w = (float)Math.Min(o.W, o.H / o.Ar), h = w * o.Ar;
                o.Shape ??= new CardLayer("trio shape");
                ShapeArt(o, w, h, true);
            }
            Rebuild();
        }

        void ShapeArt(One o, float w, float h, bool grey)
        {
            var s = new UiSvg(w, h);
            if (grey)
            {
                var f = s.NewId("tint");
                s.Def($"<filter id=\"{f}\" x=\"0\" y=\"0\" width=\"1\" height=\"1\" color-interpolation-filters=\"sRGB\"><feFlood flood-color=\"#dccfbf\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/></filter>");
                s.Open($"filter=\"url(#{f})\"");
            }
            s.Image("Stack/art/" + o.Key, 0, 0, w, h);
            if (grey) s.Close();
            o.Shape.Set(s.Markup, w, h, 0);
        }

        void Rebuild()
        {
            Layers.Clear();
            foreach (var o in _one) if (o.Rays != null) Layers.Add(o.Rays);
            foreach (var o in _one) Layers.Add(o.Shape);
            if (!_on) return;
            foreach (var o in _one)
            {
                if (o.Rig == null) continue;
                Layers.Add(o.Shadow);
                Layers.Add(o.Rig);
                Layers.Add(o.Edge);
            }
        }

        // ---- the run ----------------------------------------------------------------------------------------------------
        public override void Mount()
        {
            Unmount();
            _tk = Ticker.Default;
            _mountAt = _tk.Now;
            _went = _ok = _on = false;
            foreach (var o in _one)
            {
                o.Moves.Clear(); o.Happy = null; o.Mode = "wait"; o.Shown = false; o.Fill = -1;
                o.Glow.SetValue(0);
                if (o.Earned) o.Spin.Mount();
            }
            _shapes.SetValue(0);
            _shapesA = Animated.Timing(_shapes, Fx.Timing(1, 260, null, SHAPES_MS));
            _shapesA.Start();
            _timers.Add(_tk.SetTimeout(() => { if (_live) MakeRigs(); }, MOUNT_MS));
            _timers.Add(_tk.SetTimeout(() => Go(false), WAIT_MS));
            Rebuild();
        }

        public override void Unmount()
        {
            base.Unmount();
            if (_tk != null) foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            _shapesA?.Stop();
            foreach (var o in _one) { o.Spin.Unmount(); o.Rig = null; o.C = null; }
            _on = false;
            Rebuild();
        }

        // the page's characters (RigStage's cast): one live creature each, its floor shadow and its fill's shine
        void MakeRigs()
        {
            _on = true;
            foreach (var o in _one)
            {
                o.C = new CardCreature { Key = o.Key };
                o.Rig = new CardLayer("trio creature") { Creature = o.C };
                o.Rig.Set("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"/>", 100, 100, 0);
                o.Shadow = new CardLayer("trio shadow");
                o.Shadow.Set("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\" viewBox=\"0 0 100 100\"><defs><radialGradient id=\"sh\" cx=\"50\" cy=\"50\" r=\"50\" gradientUnits=\"userSpaceOnUse\">" +
                    "<stop offset=\"0\" stop-color=\"#6b4426\" stop-opacity=\"0.3\"/><stop offset=\"0.55\" stop-color=\"#6b4426\" stop-opacity=\"0.16\"/><stop offset=\"1\" stop-color=\"#6b4426\" stop-opacity=\"0\"/></radialGradient></defs>" +
                    "<ellipse cx=\"50\" cy=\"50\" rx=\"50\" ry=\"50\" fill=\"url(#sh)\"/></svg>", 100, 100, 0);
                o.Edge = new CardLayer("trio edge");
                o.Shadow.Opacity = o.Rig.Opacity = o.Edge.Opacity = 0;
            }
            Rebuild();
        }

        /// <summary>Trio.js go(): the run starts once (the characters drawn: ok; or they can't be: the stills stay).</summary>
        void Go(bool ok)
        {
            if (_went) return;
            _went = true; _ok = ok;
            _onGo?.Invoke(ok);
            // ResultCard: each star's sound at its moment (the characters' or the stars'), PERFECT after the third
            for (int i = 0; i < 3; i++)
            {
                int n = i + 1; bool earned = i < _stars;
                _timers.Add(_tk.SetTimeout(() => Snd.Play(earned ? "sd_star" + n : "sd_starEmpty"), _t0 + i * _step));
            }
            if (_stars == 3) _timers.Add(_tk.SetTimeout(() => Snd.Play("sd_perfect"), _t0 + 3 * _step));
            // the gold rays behind each earned one, as its colour fills in
            for (int i = 0; i < _stars; i++) Animated.Timing(_one[i].Glow, Fx.Timing(1, 520, null, _t0 + i * _step + 320)).Start();
            if (!ok)
            {
                // (no characters: an earned one's cut-out takes its colour as its moment comes, a missed one stays grey)
                foreach (var o in _one)
                {
                    if (!o.Earned) continue;
                    var one = o;
                    _timers.Add(_tk.SetTimeout(() => { float w = one.Shape.W, h = one.Shape.H; ShapeArt(one, w, h, false); }, _t0 + one.I * _step));
                }
                return;
            }
            // the grey shapes give way to the characters popping in
            _shapesA?.Stop();
            _shapesA = Animated.Timing(_shapes, Fx.Timing(0, 220));
            _shapesA.Start();
            double now = _tk.Now;
            foreach (var o in _one)
            {
                var one = o;
                o.Moves.Clear(); o.Happy = null; o.Mode = "wait"; o.Shown = true;
                o.C.GreyAbove = 2;
                Enter(o, now, o.I * 90);
                _timers.Add(_tk.SetTimeout(() => { if (one.Earned) Filled(one); else Missed(one); }, _t0 + o.I * _step));
            }
        }

        // ---- result.html's moves ----------------------------------------------------------------------------------------
        const double FILL = 560, CROUCH = 360, RISE = 640, HANG = 320, FALL = 460, LAND = 480;

        static void Play(One o, string state, string clip, double at) { o.C.State = state; if (clip != null) { o.C.Clip = clip; o.C.ClipAt = at; } }
        void Later(double ms, Action a) => _timers.Add(_tk.SetTimeout(a, ms));

        void Burst(One o, string kind, string where, int n = 0)
        {
            var b = o.C?.Body; if (b == null) return;
            if (where == "feet") o.C.Bursts.Add((kind, null, b.Cx, b.Gy - 2, n));
            else if (where == "head") o.C.Bursts.Add((kind, null, b.Cx, b.Top + 4, n));
            else o.C.Bursts.Add((kind, where, 50, 50, n));
        }

        // popping in, grey
        void Enter(One o, double now, double delay)
        {
            const double D = 440;
            o.Moves.Add(new Move { T0 = now + delay, Dur = D, HasBefore = true, Run = t => new Out
            {
                K = 0.3 + 0.7 * OutBack(Clamp(t / D, 0, 1)), O = Clamp(t / 120, 0, 1),
                Sq = Kv(new (double, double, char)[] { (0, 0, 'l'), (D * 0.45, -0.2, 'o'), (D * 0.75, 0.1, 'I'), (D, 0, 'I') }, t),
            } });
            Later(delay, () => Play(o, "resWait", "wait", _tk.Now));
        }

        // Filled: the colour rises from its feet to its head, it lights up, crouches, and jumps for joy, slowly
        void Filled(One o)
        {
            o.Mode = "fill";
            double now = _tk.Now;
            Play(o, "resWait", "fill", now);
            double H = o.H * 0.62;
            double a = FILL, b = a + CROUCH, top = b + RISE, down = top + HANG, ground = down + FALL, D = ground + LAND;
            o.Fill = 0;
            o.C.GreyAbove = FillLine(o, 0);
            Later(FILL * 0.62, () => Play(o, "resWow", null, 0));
            Later(FILL, () => Burst(o, "resSpark", "head", 7));
            Later(b + 40, () => Snd.Play("sd_hop"));
            Later(ground, () => { Burst(o, "resDust", "feet"); Burst(o, "resSpark", "feet", 5); });
            Later(top - 120, () => Burst(o, "resHeart", "head", 1));
            Later(top + 160, () => Burst(o, "resHeart", "head", 1));
            var sqK = new (double, double, char)[] { (0, 0, 'x'), (a * 0.7, -0.08, 'I'), (a, 0, 'I'), (b, 0.32, 'I'), (b + 110, -0.3, 'o'), (top, -0.08, 'I'), (down, -0.04, 'I'), (ground - 60, -0.18, 'i'),
                (ground, 0.34, 'o'), (ground + 130, -0.16, 'I'), (ground + 250, 0.08, 'I'), (ground + 360, -0.03, 'I'), (D, 0, 'I') };
            var armK = new (double, double, char)[] { (0, 0, 'x'), (a, 6, 'I'), (b, -16, 'I'), (b + 160, 52, 'o'), (down, 46, 'I'), (ground, 30, 'I'), (ground + 120, -10, 'o'), (D, 14, 'I') };
            var tiltK = new (double, double, char)[] { (0, 0, 'x'), (b, 0, 'I'), (b + 200, 5, 'I'), (top, -4, 'I'), (down, 3, 'I'), (ground, 0, 'I') };
            o.Moves.Add(new Move { T0 = now, Dur = D, Run = t =>
            {
                o.Fill = SM(t / FILL);
                double lift = 0;
                if (t > b && t <= top) lift = H * OutQ((t - b) / RISE);
                else if (t > top && t <= down) lift = H * (1 - 0.06 * SM((t - top) / HANG));
                else if (t > down && t <= ground) lift = H * 0.94 * (1 - InQ((t - down) / FALL));
                double arm = Kv(armK, t), wave = t > b + 160 && t < down ? 10 * Math.Sin((t - b) / 95) : 0;
                double spin = t < b + 80 ? 0 : t > ground - 40 ? 0 : 360 * SM((t - b - 80) / (ground - 40 - b - 80));
                double foot = t > b && t < ground ? 2 : 0;
                return new Out { Lift = lift, Sq = Kv(sqK, t), Tilt = Kv(tiltK, t),
                    Ext = new Dictionary<string, double> { ["armL"] = arm + wave, ["armR"] = arm - wave, ["spin"] = spin, ["footL"] = foot, ["footR"] = foot } };
            }, Done = () =>
            {
                o.Fill = -1; o.C.GreyAbove = -1; o.Mode = "happy";
                o.Happy = new Happy { T0 = _tk.Now, N = o.I };
                Play(o, "resHappy", "happy", _tk.Now);
            } });
        }

        // Missed: grey still, a little sigh
        void Missed(One o)
        {
            o.Mode = "miss";
            Play(o, "resMiss", "miss", _tk.Now);
            var k = new (double, double, char)[] { (0, 0, 'x'), (300, -0.06, 'o'), (600, 0.08, 'I'), (900, 0.05, 'I') };
            o.Moves.Add(new Move { T0 = _tk.Now, Dur = 900, Run = t => new Out { Sq = Kv(k, t) } });
            Later(700, () => Burst(o, "resTear", "eyeL"));
        }

        // The happy loop, once landed: a sway on the spot, and one of its happy moves every couple of seconds, taking turns
        static Dictionary<string, double> AR(double v) => new Dictionary<string, double> { ["armL"] = v, ["armR"] = v };
        static readonly HappyMove[] HAPPY =
        {
            new HappyMove { Ms = 1000, F = t => { double u = t / 1000, h = Math.Max(Parab(u * 2), Parab(u * 2 - 1)); return new Out { Lift = 0.2 * h, Sq = -0.14 * h + 0.16 * Math.Max(0, Math.Cos(u * Math.PI * 4)) * (1 - h), Ext = AR(30 * h + 8) }; } },
            new HappyMove { Ms = 1300, F = t => { double e = Math.Sin(Clamp(t / 1300, 0, 1) * Math.PI), w = Math.Sin(t / 85); return new Out { Tilt = -4 * e, Ext = new Dictionary<string, double> { ["armR"] = (54 + 16 * w) * e, ["armL"] = -6 * e, ["htilt"] = 6 * e } }; } },
            new HappyMove { Ms = 1100, F = t => { double e = Math.Sin(Clamp(t / 1100, 0, 1) * Math.PI), w = Math.Sin(t / 90); return new Out { Tilt = 8 * w * e, Sq = 0.05 * Math.Abs(w) * e, Ext = new Dictionary<string, double> { ["lean"] = 2.2 * w * e, ["armL"] = (24 + 14 * w) * e, ["armR"] = (24 - 14 * w) * e } }; } },
            new HappyMove { Ms = 1200, F = t => { double u = t / 1200, h = Parab((u - 0.15) / 0.7); var x = AR(40 * h); x["spin"] = 360 * SM((u - 0.2) / 0.62);
                return new Out { Lift = 0.32 * h, Sq = Kv(new (double, double, char)[] { (0, 0, 'x'), (150, 0.24, 'I'), (260, -0.26, 'o'), (900, -0.06, 'I'), (1000, 0.22, 'o'), (1200, 0, 'I') }, t), Ext = x }; } },
        };
        const double CALM_MS = 15000;

        Out HappyNow(One o, double now)
        {
            var hp = o.Happy; if (hp == null) return null;
            double w = (now - hp.T0) / 1000;
            bool calm = now - hp.T0 > CALM_MS;
            double sway = 1 - Clamp((now - hp.T0 - CALM_MS) / 900, 0, 1);
            var outp = new Out { Tilt = 2.5 * sway * Math.Sin(w * 2.2 + o.I), Sq = 0.03 * sway * Math.Sin(w * 4.4 + o.I), Ext = AR(10 + 6 * sway * Math.Sin(w * 3 + o.I)) };
            if (hp.Mv == null && now >= (hp.Next >= 0 ? hp.Next : hp.T0 + 500 + o.I * 650))
            {
                hp.Mv = HAPPY[hp.N % HAPPY.Length]; hp.N += 1; hp.At = now;
                if (hp.N % 2 == 0) Burst(o, "resHeart", "head", 1);
            }
            if (hp.Mv != null)
            {
                double t = now - hp.At;
                if (t >= hp.Mv.Ms)
                {
                    hp.Mv = null;
                    // (the page then rests longer once calm, woken by a timer: the same rest, without the sleep)
                    hp.Next = now + (calm ? 2600 + (o.I * 523 + hp.N * 311) % 1800 : 900 + (o.I * 397 + hp.N * 211) % 700);
                }
                else
                {
                    var r = hp.Mv.F(t);
                    outp.Lift += r.Lift * o.H; outp.Sq += r.Sq; outp.Tilt += r.Tilt;
                    if (r.Ext != null) foreach (var kv in r.Ext) outp.Ext[kv.Key] = (outp.Ext.TryGetValue(kv.Key, out var v) ? v : 0) + kv.Value;
                }
            }
            return outp;
        }

        // the colour's edge (result.html setFill) as the grey line, a fraction of the 0-100 box
        static float FillLine(One o, double f)
        {
            var b = o.C.Body; if (b == null) return 2;
            double T = b.Top - 14, B = b.Gy + 6;
            return (float)((B - (B - T) * f) / 100);
        }

        // ---- every frame: the moves, then each one placed (result.html frame() and draw()) ------------------------------
        public override void Place(Affine card, float opacity)
        {
            var (m, op) = Box(card, opacity);
            double now = _tk != null ? _tk.Now : 0;
            if (_live && _on && !_went)
            {
                bool all = true, failed = false;
                foreach (var o in _one) { if (o.C == null || o.C.Body == null) all = false; if (o.C != null && o.C.Failed) failed = true; }
                if (failed) Go(false);
                else if (all) Go(true);
            }
            float shapes = (float)_shapes.GetValue();
            foreach (var o in _one)
            {
                float fx = (float)(TW * AT[o.I]);
                if (o.Rays != null)
                {
                    float S = o.Rays.W, g = (float)o.Glow.GetValue(), sc = (float)GlowScale.Evaluate(g);
                    o.Rays.Transform = m * Affine.Translate(fx - S / 2, TH - 4 - o.H * 0.48f - S / 2) * Fx.About(S, S, Affine.ScaleBy(sc, sc) * Affine.Rotate(o.Spin.Degrees));
                    o.Rays.Opacity = op * g;
                }
                // the shapes stay when the characters can't come; the earned ones' colour pictures show from their moment
                o.Shape.Transform = m * Affine.Translate(fx - o.Shape.W / 2, TH - 4 - o.Shape.H);
                o.Shape.Opacity = op * (_went && !_ok ? 1 : shapes);
                if (o.Rig != null) PlaceRig(o, m, op, now, fx);
            }
        }

        void PlaceRig(One o, Affine m, float op, double now, float feetX)
        {
            var c = o.C; var bb = c.Body;
            if (bb == null) { o.Rig.Opacity = o.Shadow.Opacity = o.Edge.Opacity = 0; return; }
            double k0 = Math.Min(o.W / bb.Bw, o.H / bb.Bh);
            c.Unit = (float)k0;
            double K = 1, O = double.NaN, lift = 0, sq = 0, tilt = 0;
            var ext = new Dictionary<string, double>();
            bool before = false;
            foreach (var mv in o.Moves.ToArray())
            {
                double t = now - mv.T0;
                if (t < 0) { if (mv.HasBefore) before = true; continue; }
                if (t >= mv.Dur) { mv.Run(mv.Dur); o.Moves.Remove(mv); mv.Done?.Invoke(); continue; }
                var r = mv.Run(t);
                if (!double.IsNaN(r.K)) K *= r.K;
                if (!double.IsNaN(r.O)) O = (double.IsNaN(O) ? 1 : O) * r.O;
                lift += r.Lift; sq += r.Sq; tilt += r.Tilt;
                if (r.Ext != null) foreach (var kv in r.Ext) ext[kv.Key] = (ext.TryGetValue(kv.Key, out var v) ? v : 0) + kv.Value;
            }
            if (before) O = 0;
            var hp = HappyNow(o, now);
            if (hp != null)
            {
                lift += hp.Lift; sq += hp.Sq; tilt += hp.Tilt;
                foreach (var kv in hp.Ext) ext[kv.Key] = (ext.TryGetValue(kv.Key, out var v) ? v : 0) + kv.Value;
            }
            c.Ext.Clear(); foreach (var kv in ext) c.Ext[kv.Key] = kv.Value;
            if (o.Fill >= 0) c.GreyAbove = FillLine(o, o.Fill);
            // draw(): feet on (x, y), its body as big as fits W x H, squashed and tilted about its feet
            double k = k0 * K, fx = bb.Cx, fy = bb.Gy, q = Clamp(sq, -0.45, 0.45), sx = 1 + q * 0.42, sy = 1 - q * 0.5;
            double feetY = TH - 4, x = feetX - fx * k, y = feetY - fy * k - lift;
            var body = Affine.Translate(x, y) * Affine.ScaleBy(k, k) * Affine.Translate(fx, fy) * Affine.Rotate(tilt) * Affine.ScaleBy(sx, sy) * Affine.Translate(-fx, -fy);
            float o1 = (float)((o.Shown ? 1 : 0) * (double.IsNaN(O) ? 1 : O));
            o.Rig.Transform = m * body;
            o.Rig.Opacity = op * o1;
            // its floor shadow, smaller and fainter the higher it is
            double f = 1 - Clamp(lift / (o.H * 0.9), 0, 0.6), w = bb.Bw * k * 0.9 * f, h = w * 0.2;
            o.Shadow.Transform = m * Affine.Translate(feetX - w / 2, feetY - h * 0.55) * Affine.ScaleBy(w / 100, h / 100);
            o.Shadow.Opacity = op * o1 * (float)f;
            // the edge of the colour as it rises: a soft gold shine
            if (o.Fill > 0.02 && o.Fill < 0.98)
            {
                double ew = bb.Bw * 1.1, ey = c.GreyAbove * 100;
                if (o.Edge.W != (float)ew)
                {
                    var s = new UiSvg((float)ew, 12);
                    s.Def("<radialGradient id=\"edge\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#fff6be\" stop-opacity=\"0.95\"/><stop offset=\"0.55\" stop-color=\"#ffd65a\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffd65a\" stop-opacity=\"0\"/></radialGradient>");
                    s.Raw($"<ellipse cx=\"{UiSvg.F(ew / 2)}\" cy=\"6\" rx=\"{UiSvg.F(ew / 2)}\" ry=\"6\" fill=\"url(#edge)\"/>");
                    o.Edge.Set(s.Markup, (float)ew, 12, 0);
                }
                o.Edge.Transform = m * body * Affine.Translate(bb.Left - bb.Bw * 0.05, ey - 6);
                o.Edge.Opacity = op * o1;
            }
            else o.Edge.Opacity = 0;
        }

        // ---- the page's sums ----------------------------------------------------------------------------------------------
        static double Clamp(double v, double a, double b) => Math.Max(a, Math.Min(b, v));
        static double SM(double x) { x = Clamp(x, 0, 1); return x * x * (3 - 2 * x); }
        static double OutQ(double u) => 1 - (1 - u) * (1 - u);
        static double InQ(double u) => u * u;
        static double OutBack(double u) { double v = u - 1; return 1 + 2.70158 * v * v * v + 1.70158 * v * v; }
        static double Parab(double u) => u <= 0 || u >= 1 ? 0 : 4 * u * (1 - u);

        // rive-rig.js kv(): keyframes (t, v, easing) read at t; the easings 'l' straight, 'I' (io: in and out), 'o' out,
        // 'i' in ('x' only on the first key, never read)
        static readonly Func<double, double> IO = Bez(0.45, 0, 0.55, 1);
        static double Ease(char e, double x) => e == 'l' ? x : e == 'o' ? 1 - Math.Pow(1 - x, 2.4) : e == 'i' ? Math.Pow(x, 2.2) : IO(x);
        static double Kv((double t, double v, char e)[] K, double t)
        {
            if (t <= K[0].t) return K[0].v;
            for (int i = 1; i < K.Length; i++)
            {
                var b = K[i];
                if (t <= b.t) { var a = K[i - 1]; return a.v + (b.v - a.v) * Ease(b.e, (t - a.t) / Math.Max(1, b.t - a.t)); }
            }
            return K[K.Length - 1].v;
        }
        static Func<double, double> Bez(double x1, double y1, double x2, double y2)
        {
            double cx = 3 * x1, bx = 3 * (x2 - x1) - cx, ax = 1 - cx - bx, cy = 3 * y1, by = 3 * (y2 - y1) - cy, ay = 1 - cy - by;
            double X(double t) => ((ax * t + bx) * t + cx) * t;
            double dX(double t) => (3 * ax * t + 2 * bx) * t + cx;
            double Y(double t) => ((ay * t + by) * t + cy) * t;
            return x =>
            {
                if (x <= 0) return 0; if (x >= 1) return 1;
                double t = x;
                for (int i = 0; i < 8; i++) { double d = dX(t); if (Math.Abs(d) < 1e-5) break; t = Clamp(t - (X(t) - x) / d, 0, 1); }
                return Y(t);
            };
        }
    }
}
