// src/screens/DailySpinScreen.js, landscape (REDESIGN_V7 step 4: the wheel on the left sized by the height, the rest
// beside it), and src/dailySpin.js, as pure C#: "HI <NAME>!", "Daily Spin", the gold wheel (its rim's glow, 16 bulbs
// blinking in two groups, eight slices with their prizes kept upright while it turns, the pointer) and its SPIN hub,
// which is the button. SPIN asks the server (OnSpin: the spinWheel Cloud Function) for the prize: the wheel whirls while
// it waits (450 ms ramping up, then 100 turns over 15 s), then from wherever it is turns five more laps and eases onto
// the slice the server picked (4.5 s, bezier 0.12 0.72 0.06 1); the "You won!" card pops in (450 ms). After Collect:
// "Spin again" (one bonus spin a day, MAX_AD_SPINS; the server counts it too) and "Continue to my squad".
// The landscape screen has no creature (the app's portrait one shows Mittens' rig under the wheel).
// No ads in Unity yet: the bonus spin is offered only with Remove Ads (`adsFree`, where the app skips the video); for
// other players only Continue shows (the app plays a rewarded video first).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    /// <summary>spinWheel's answer: { index, kind, amount, jackpot } or { already, bonus } or an error.</summary>
    public sealed class SpinResult
    {
        public int Index; public string Kind = "coins"; public double Amount; public bool Jackpot, Already, Bonus, Error;

        public static SpinResult From(object data)
        {
            var m = Prof.Map(data);
            if (m == null) return new SpinResult { Error = true };
            return new SpinResult
            {
                Index = (int)Prof.Num(Prof.Get(m, "index")), Kind = Prof.Str(Prof.Get(m, "kind")) ?? "coins", Amount = Prof.Num(Prof.Get(m, "amount")),
                Jackpot = Prof.Truthy(Prof.Get(m, "jackpot")), Already = Prof.Truthy(Prof.Get(m, "already")), Bonus = Prof.Truthy(Prof.Get(m, "bonus")),
            };
        }
    }

    public sealed class SpinView : IScreenView
    {
        // dailySpin.js WHEEL (functions/dailySpin.js has the same eight, in the same order)
        public static readonly (string kind, double amount, string color)[] WHEEL =
        {
            ("coins", 100, "#ff8a3d"), ("gems", 5, "#c0702e"), ("coins", 250, "#ff8a3d"), ("coins", 150, "#c0702e"),
            ("coins", 50, "#ff8a3d"), ("gems", 15, "#2fc8f0"), ("coins", 500, "#ff8a3d"), ("gems", 50, "#ffb81f"),
        };
        public const double SLICE = 360.0 / 8;
        public const int MAX_AD_SPINS = 1;
        const float S = 366, DISC = 318, R = (DISC - 6) / 2, HUB = 100;
        const double SPIN_MS = 4500;
        const int LAPS = 5;
        const string PURPLE = "#6b4426", RIM = "#a0520a";
        static readonly Func<double, double> SpinEase = Easing.Bezier(0.12, 0.72, 0.06, 1);

        public readonly float W, H;
        public readonly string Name;
        public readonly bool AdsFree;
        public readonly int BonusLeft;
        /// <summary>Asks the server for the spin (bonus: the second one); the host calls spinWheel.</summary>
        public Func<bool, Task<SpinResult>> OnSpin;
        public Action OnDone;

        /// <summary>'idle' | 'spinning' | 'prize' | 'done' | 'adReady' | 'error'</summary>
        public string Phase { get; private set; } = "idle";
        public SpinResult Result { get; private set; }
        int _usedHere;
        bool _busy;

        readonly Ticker _t;
        readonly AnimatedValue _rot = new AnimatedValue(0), _pop = new AnimatedValue(0);
        readonly AnimatedValue[] _bulbs = new AnimatedValue[16];

        public SpinView(string name, int bonusLeft, bool adsFree, float w, float h, Ticker ticker)
        {
            Name = name; BonusLeft = bonusLeft; AdsFree = adsFree; W = w; H = h; _t = ticker;
            for (int i = 0; i < 16; i++)
            {
                var v = _bulbs[i] = new AnimatedValue(0);
                var loop = Animated.Loop(Animated.Sequence(Motion.Timing(v, 1, 450, Easing.InOut(Easing.Ease)), Motion.Timing(v, 0, 450, Easing.InOut(Easing.Ease))));
                _t.SetTimeout(() => loop.Start(), i % 2 == 1 ? 450 : 0);
            }
        }

        int SpinsLeft => Math.Max(0, Math.Min(BonusLeft, MAX_AD_SPINS - _usedHere));
        /// <summary>The wheel's current angle (degrees), for checking.</summary>
        public double Angle => _rot.GetValue();

        // ---- spinning ---------------------------------------------------------------------------------------------------
        public void Hub()
        {
            if (Phase == "idle") Spin(false);
            else if (Phase == "adReady") Spin(true);
        }

        async void Spin(bool bonus)
        {
            if (_busy) return;
            _busy = true;
            Phase = "spinning";
            _whirl = Audio.Snd.Loop("whirlLoop");
            // whirl straight away (ramping up) while the server decides
            _rot.StopAnimation(v => Animated.Sequence(Motion.Timing(_rot, v + 360, 450, Easing.In(Easing.Quad)), Motion.Timing(_rot, v + 360 + 36000, 15000, Motion.Linear)).Start());
            SpinResult res;
            try { res = OnSpin != null ? await OnSpin(bonus) : new SpinResult { Error = true }; }
            catch (Exception) { res = new SpinResult { Error = true }; }
            // (the answer is played in the next frame's callbacks, after the whirl's own: as a promise settles after a
            // browser frame)
            _t.RequestAnimationFrame(() => Answer(res, bonus));
        }

        Audio.ISndLoop _whirl;

        void Answer(SpinResult res, bool bonus)
        {
            _whirl?.Stop();
            _whirl = null;
            _busy = false;
            if (bonus && !res.Error) _usedHere++;
            if (res.Error || res.Already)
            {
                Audio.Snd.Play("fail");
                _rot.StopAnimation(v => Motion.Timing(_rot, v + 180, 900, Motion.OutQuad).Start());
                Result = res;
                Phase = "error";
                return;
            }
            Audio.Snd.Play("wheelSpin");
            _rot.StopAnimation(v =>
            {
                double stop = (360 - (res.Index * SLICE + SLICE / 2)) % 360;
                double target = v - (v % 360) + 360 * LAPS + stop;
                Motion.Timing(_rot, target, SPIN_MS, SpinEase).Start(r =>
                {
                    Result = res;
                    Phase = "prize";
                    Audio.Snd.Play(res.Jackpot ? "jackpot" : "win");
                    _pop.SetValue(0);
                    Motion.Timing(_pop, 1, 450, Motion.OutQuad).Start();
                });
            });
        }

        void Collect() => Phase = "done";
        void WatchAd() { if (AdsFree) Phase = "adReady"; }

        // ---- layout ------------------------------------------------------------------------------------------------------
        float K => Math.Min(1, (H - 40) / (S + 14));
        float RowX => (W - ((S + 6) * K + 40 + 360)) / 2;
        // the wheel's 366 box, scaled by K about its middle, in the screen
        Affine WheelM
        {
            get
            {
                float cw = (S + 6) * K, ch = (S + 14) * K;
                float x = RowX + (cw - S) / 2, y = (H - ch) / 2 + (S * K - S) / 2 + 3 * K;
                return Affine.Translate(x, y) * About(S, S, Affine.ScaleBy(K, K));
            }
        }
        float SideX => RowX + (S + 6) * K + 40;

        static readonly TextStyle HiT = T(Black, 12, PURPLE, 2);
        static readonly TextStyle SubT = T(Heavy, 13, PURPLE);
        static readonly TextStyle NoteT = T(Heavy, 13, PURPLE);
        static readonly TextStyle UnlockedT = T(Kit.Display, 17, "#e0601c");
        static readonly TextStyle AdSubT = T(Black, 10.5f, "#eafff3", 0.6f);
        static TextStyle BtnText(string ring, float size) => T(Kit.Display, size, "#ffffff", 0, 0, Outline3(ring, 2));

        // the side column's items, top to bottom: (id, height)
        List<(string id, float h, float w)> SideItems()
        {
            var l = new List<(string, float, float)>();
            string hi = $"HI {(Name ?? "friend").ToUpperInvariant()}!";
            l.Add(("hi", LH(HiT), W(hi, HiT)));
            var (lw, lh) = LetteringSize("Daily Spin", 38);
            l.Add(("title", lh, lw));
            l.Add(("sub", LH(SubT), W("One free spin every day", SubT)));
            if (Phase == "idle") l.Add(("tap", LH(SubT) + 14, W("Tap SPIN in the middle of the wheel!", SubT)));
            l.Add(("gap", 16, 0));
            if (Phase == "done" || Phase == "error")
            {
                float h = 2;
                if (Phase == "done" && SpinsLeft > 0 && AdsFree) h += GreenH + 9;
                else if (Phase == "done" && SpinsLeft == 0) h += NoteH("That’s all the spins for today. Come back tomorrow!") + 9;
                if (Phase == "error") h += NoteH(ErrorNote) + 9;
                h += PinkH;
                l.Add(("after", h, 360));
            }
            if (Phase == "adReady") l.Add(("unlocked", LH(UnlockedT) + 4, W("Spin unlocked! Tap SPIN.", UnlockedT)));
            return l;
        }

        string ErrorNote => Result != null && Result.Already ? (Result.Bonus ? "No more spins today. Come back tomorrow!" : "You already spun today. Come back tomorrow!") : "We couldn’t reach the wheel. Try again next time.";
        float NoteH(string t) => new TextFlow(t, NoteT, 0.5f).Measure(320).h;
        string SpinAgain => AdsFree ? "Spin again" : "Watch ad, spin again";
        float GreenFaceH => 3 + 8 + Math.Max(30, LH(BtnText("#000", 18)) + LH(AdSubT)) + 8 + 3;
        float GreenH => 2.5f + GreenFaceH + 2.5f + 5;
        float GreenW => 2.5f + 3 + 18 + 30 + 5 + 5 + Math.Max(W(SpinAgain, BtnText("#000", 18)), W("ONE BONUS SPIN PER DAY", AdSubT)) + 18 + 3 + 2.5f;
        float PinkH => 2.5f + 3 + 7 + LH(BtnText("#000", 17)) + 7 + 3 + 2.5f + 5;
        float PinkW => 2.5f + 3 + 28 + W("Continue to my squad", BtnText("#000", 17)) + 28 + 3 + 2.5f;

        Dictionary<string, Frame> Side()
        {
            var items = SideItems();
            float total = 0;
            foreach (var it in items) total += it.h;
            total += 6 * (items.Count - 1);
            float y = (H - total) / 2;
            var f = new Dictionary<string, Frame>();
            foreach (var it in items) { f[it.id] = new Frame(SideX + (360 - it.w) / 2, y, it.w, it.h); y += it.h + 6; }
            if (f.TryGetValue("after", out var af))
            {
                float ay = af.Y + 2;
                if (Phase == "done" && SpinsLeft > 0 && AdsFree) { f["green"] = new Frame(SideX + (360 - GreenW) / 2, ay, GreenW, GreenH); ay += GreenH + 9; }
                else if (Phase == "done" && SpinsLeft == 0) { var nh = NoteH("That’s all the spins for today. Come back tomorrow!"); f["note"] = new Frame(SideX + 20, ay, 320, nh); ay += nh + 9; }
                if (Phase == "error") { var nh = NoteH(ErrorNote); f["note"] = new Frame(SideX + 20, ay, 320, nh); ay += nh + 9; }
                f["pink"] = new Frame(SideX + (360 - PinkW) / 2, ay, PinkW, PinkH);
            }
            return f;
        }

        // the prize card: 300 wide, centred
        Frame CardBox(out float faceH)
        {
            var title = T(Kit.Display, 30, "#ffffff");
            faceH = 22 + LH(title) + 10 + 84 + 10 + 38 + 10 + LH(T(Black, 13, "#000", 1.5f)) + 10 + 6 + (2.5f + 3 + 8 + LH(BtnText("#000", 20)) + 8 + 3 + 2.5f + 5) + 20 + 6;
            float h = faceH + 6;
            return new Frame((W - 300) / 2, (H - h) / 2, 300, h);
        }

        // ---- the pointer ---------------------------------------------------------------------------------------------
        string _pressed;
        public void Down(float x, float y) { _pressed = Hit(x, y); }
        public void Move(float x, float y) { if (_pressed != null && Hit(x, y) != _pressed) _pressed = null; }
        public void Up(float x, float y)
        {
            var h = Hit(x, y);
            var p = _pressed;
            _pressed = null;
            if (h == null || h != p) return;
            Audio.Snd.Play("tap");
            if (h == "hub") Hub();
            else if (h == "collect") Collect();
            else if (h == "green") WatchAd();
            else if (h == "pink") OnDone?.Invoke();
        }

        string Hit(float x, float y)
        {
            if (Phase == "prize")
            {
                var cb = CardBox(out _);
                float by = cb.Bottom - 6 - 20 - (2.5f + 3 + 8 + LH(BtnText("#000", 20)) + 8 + 3 + 2.5f + 5);
                return x >= cb.X + 20 && x < cb.Right - 20 && y >= by && y < cb.Bottom - 26 ? "collect" : null;
            }
            var c = WheelM.Apply(new Vec2(S / 2, S / 2));
            double dx = x - c.X, dy = y - c.Y, r = (HUB / 2 + 3 + 6) * K;
            if (dx * dx + dy * dy <= r * r) return "hub";
            var f = Side();
            foreach (var k in new[] { "green", "pink" })
                if (f.TryGetValue(k, out var b) && x >= b.X && x < b.Right && y >= b.Y && y < b.Bottom) return k;
            return null;
        }

        // ---- the pieces --------------------------------------------------------------------------------------------------
        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", PageBg(W, H), W, H, 0, 0, 1, null, 0));
            var wm = WheelM;
            void Add(ScreenPiece p) { p.Transform = wm * p.Transform; list.Add(p); }
            Add(Piece("rim", RimSvg(), S + 100, S + 100, -50, -50, 1, null, 0));
            for (int i = 0; i < 16; i++)
            {
                double a = i * 22.5 * Math.PI / 180, t = _bulbs[i].GetValue();
                float cx = S / 2 + (float)(168 * Math.Sin(a)), cy = S / 2 - (float)(168 * Math.Cos(a));
                double sc = 1 - 0.25 * t;
                Add(Piece("bulb" + i, BulbSvg(), 29, 29, cx - 14.5f, cy - 14.5f, (float)(1 - 0.65 * t), About(29, 29, Affine.ScaleBy(sc, sc)) * About(29, 29, Affine.Rotate(i * 22.5)), 0));
            }
            double rot = _rot.GetValue();
            Add(Piece("disc", DiscSvg(), DISC, DISC, 24, 24, 1, About(DISC, DISC, Affine.Rotate(rot)), 0));
            for (int i = 0; i < 8; i++)
            {
                double ang = (i * SLICE + SLICE / 2 + rot) * Math.PI / 180;
                float cx = S / 2 + (float)(106 * Math.Sin(ang)), cy = S / 2 - (float)(106 * Math.Cos(ang));
                Add(Piece("label" + i, LabelSvg(i), 84, 52, cx - 42, cy - 26));
            }
            Add(Piece("pin", PinSvg(), S, 40, 0, -20, 1, null, 4));
            string hub = Phase == "spinning" ? "…" : "SPIN";
            Add(Piece("hub", HubSvg(hub), HUB + 6, HUB + 11, S / 2 - HUB / 2 - 3, S / 2 - HUB / 2 - 3, 1, _pressed == "hub" ? About(HUB + 6, HUB + 11, Affine.ScaleBy(0.94, 0.94)) : (Affine?)null));
            SidePieces(list);
            if (Phase == "prize" && Result != null) Card(list);
            return list;
        }

        void SidePieces(List<ScreenPiece> list)
        {
            var f = Side();
            string hi = $"HI {(Name ?? "friend").ToUpperInvariant()}!";
            list.Add(Piece("hi", TextBox(hi, HiT), f["hi"].X, f["hi"].Y));
            var tf = f["title"];
            var ts = new UiSvg(tf.W, tf.H);
            Lettering(ts, "Daily Spin", "gold", 38, 0, 0);
            list.Add(Piece("title", ts, tf.X, tf.Y));
            list.Add(Piece("sub", TextBox("One free spin every day", SubT), f["sub"].X, f["sub"].Y));
            if (f.TryGetValue("tap", out var tp)) list.Add(Piece("tap", TextBox("Tap SPIN in the middle of the wheel!", SubT), tp.X, tp.Y + 14));
            if (f.TryGetValue("unlocked", out var uf)) list.Add(Piece("unlocked", TextBox("Spin unlocked! Tap SPIN.", UnlockedT), uf.X, uf.Y + 4));
            if (f.TryGetValue("note", out var nf))
            {
                var ns = new UiSvg(nf.W, nf.H);
                new TextFlow(Phase == "error" ? ErrorNote : "That’s all the spins for today. Come back tomorrow!", NoteT, 0.5f).Draw(ns, 0, 0, nf.W);
                list.Add(Piece("note", ns, nf.X, nf.Y));
            }
            if (f.TryGetValue("green", out var gf))
            {
                var s = CandyBtnBody(gf.W, gf.H, "green", 5);
                float fx = 2.5f + 3 + 18, fh = GreenFaceH - 6, fy = 2.5f + 3 + 8;
                float inner = fh - 16;
                s.Box(fx, fy + (inner - 30) / 2, 30, 30, new BoxStyle { Radius = 15, Background = "#ffffff" });
                s.Raw($"<path d=\"M{F(fx + 15 - 5.5f + 1.5f)} {F(fy + inner / 2 - 7)} l11 7 l-11 7 Z\" fill=\"#14985a\"/>");
                var bt = BtnText("#0d7a4a", 18);
                float colH = LH(bt) + LH(AdSubT), cx = fx + 30 + 5 + 5, cy = fy + (inner - colH) / 2;
                s.Text(SpinAgain, cx, cy, bt);
                s.Text("ONE BONUS SPIN PER DAY", cx, cy + LH(bt), AdSubT);
                list.Add(Piece("green", s, gf.X, gf.Y + (_pressed == "green" ? 3 : 0)));
            }
            if (f.TryGetValue("pink", out var pf))
            {
                var s = CandyBtnBody(pf.W, pf.H, "pink", 5);
                s.Text("Continue to my squad", 2.5f + 3 + 28, 2.5f + 3 + 7, BtnText("#8a3a0e", 17));
                list.Add(Piece("pink", s, pf.X, pf.Y + (_pressed == "pink" ? 3 : 0)));
            }
        }

        void Card(List<ScreenPiece> list)
        {
            list.Add(Piece("scrim", new UiSvg(W, H).Box(0, 0, W, H, new BoxStyle { Background = "rgba(50,24,6,0.55)" }), 0, 0, 1, null, 0));
            var cb = CardBox(out float fh);
            var s = new UiSvg(cb.W, cb.H);
            s.Box(0, 0, cb.W, cb.H, new BoxStyle { Radius = 30, Background = "#b8641c" });
            s.Box(0, 0, cb.W, fh, new BoxStyle { Radius = 30, Background = "#ffffff" });
            float iw = cb.W - 6, ih = fh - 6;
            var clip = s.NewId("cc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(3, 3, iw, ih, new[] { 27f, 27, 27, 27 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            // the radial: a circle r 200 % at (50 %, 30 %), its gradient over the circle's box (cx 50 %, cy 30 %, r 80 %)
            double big = 2 * Math.Sqrt((iw * iw + ih * ih) / 2), ccx = 3 + iw * 0.5, ccy = 3 + ih * 0.3;
            var gid = s.NewId("pc");
            s.Def($"<radialGradient id=\"{gid}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(ccx)}\" cy=\"{F(ccy - big + 0.6 * big)}\" r=\"{F(1.6 * big)}\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.6\" stop-color=\"#fff6e8\"/><stop offset=\"1\" stop-color=\"#f6e2c4\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(ccx)}\" cy=\"{F(ccy)}\" r=\"{F(big)}\" fill=\"url(#{gid})\"/>");
            s.Close();
            var title = T(Kit.Display, 30, "#ffffff", 0, 0, new[] { new Shadow(PURPLE, 0, 3, 0), new Shadow(PURPLE, 2, 0, 0), new Shadow(PURPLE, -2, 0, 0), new Shadow(PURPLE, 0, -2, 0) });
            string t = Result.Kind == "gems" && Result.Amount >= 50 ? "JACKPOT!" : "You won!";
            float y = 3 + 22;
            s.Text(t, 0, y, title, cb.W, 0.5f);
            y += LH(title) + 10;
            Embed(s, Result.Kind == "gems" ? "gem" : "coin", (cb.W - 84) / 2, y, 84, 84);
            y += 84 + 10;
            var amt = T(Kit.Display, 34, "#8a3a0e", 0, 38);
            s.Text("+" + Prof.Fmt(Result.Amount), 0, y, amt, cb.W, 0.5f);
            y += 38 + 10;
            var what = T(Black, 13, "#9a6a3a", 1.5f);
            s.Text(Result.Kind.ToUpperInvariant(), 0, y, what, cb.W, 0.5f);
            y += LH(what) + 10 + 6;
            float bh = 2.5f + 3 + 8 + LH(BtnText("#000", 20)) + 8 + 3 + 2.5f + 5, bw = cb.W - 6 - 40;
            float by = y + (_pressed == "collect" ? 3 : 0);
            CandyBtnBody(s, 23, by, bw, bh, "pink", 5);
            s.Text("Collect", 23, by + 2.5f + 3 + 8, BtnText("#8a3a0e", 20), bw, 0.5f);
            double pop = _pop.GetValue();
            double sc = Motion.Lerp(pop, new[] { 0, 0.6, 1 }, new[] { 0.7, 1.06, 1 });
            list.Add(Piece("card", s, cb.X, cb.Y, (float)pop, About(cb.W, cb.H, Affine.ScaleBy(sc, sc)), 8));
        }

        static string Inner(string svg) { int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>", StringComparison.Ordinal); return svg.Substring(a, b - a); }

        // ---- the wheel's drawings ------------------------------------------------------------------------------------------
        static string _rim, _bulb, _disc, _pin;
        static readonly Dictionary<string, string> _hubs = new Dictionary<string, string>(), _labels = new Dictionary<string, string>();

        static string RimSvg()
        {
            if (_rim != null) return _rim;
            float o = 50, sz = S + 100;
            var s = new UiSvg(sz, sz);
            s.Def($"<radialGradient id=\"rimGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"{F(S / sz)}\" stop-color=\"#ffd250\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffd250\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(sz / 2)}\" cy=\"{F(sz / 2)}\" r=\"{F(sz / 2)}\" fill=\"url(#rimGlow)\"/>");
            s.Box(o - 3, o + 5, S + 6, S + 6, new BoxStyle { Radius = S, Background = RIM });
            s.Box(o - 3, o - 3, S + 6, S + 6, new BoxStyle { Radius = S, Background = RIM });
            s.Box(o, o, S, S, new BoxStyle { Radius = S, Background = "#ffffff" });
            var clip = s.NewId("rf");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(o + 4, o + 4, S - 8, S - 8, new[] { S, S, S, S })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(o + 4, o + 4, S - 8, S - 8, new BoxStyle { Gradient = new[] { "#fff3b0", "#ffcc33", "#e08a00" }, GradientStops = new[] { 0f, 0.4f, 1 } });
            s.Box(o + 4, o + 4, S - 8, 4, new BoxStyle { Background = "rgba(255,255,255,0.7)" });
            s.Close();
            // the disc's ring (the disc turns inside it)
            s.Box(o + 22, o + 22, DISC + 4, DISC + 4, new BoxStyle { Radius = DISC, Background = RIM });
            return _rim = s.Markup;
        }

        static string BulbSvg() => _bulb ??= new UiSvg(29, 29).Def(
            "<radialGradient id=\"bulbGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0.4\" stop-color=\"#fff0aa\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff0aa\" stop-opacity=\"0\"/></radialGradient>" +
            "<radialGradient id=\"bulb\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.4\" stop-color=\"#fff6c0\"/><stop offset=\"1\" stop-color=\"#ffb300\"/></radialGradient>")
            .Raw("<circle cx=\"14.5\" cy=\"14.5\" r=\"14.5\" fill=\"url(#bulbGlow)\"/><circle cx=\"14.5\" cy=\"14.5\" r=\"6.5\" fill=\"url(#bulb)\"/>").Markup;

        static string DiscSvg()
        {
            if (_disc != null) return _disc;
            var s = new UiSvg(DISC, DISC);
            float b = 3;
            var clip = s.NewId("dc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(b, b, DISC - 2 * b, DISC - 2 * b, new[] { DISC, DISC, DISC, DISC })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            var sb = new System.Text.StringBuilder($"<circle cx=\"{F(R)}\" cy=\"{F(R)}\" r=\"{F(R)}\" fill=\"#ffffff\"/>");
            for (int i = 0; i < 8; i++) sb.Append($"<path d=\"{Wedge(i)}\" fill=\"{WHEEL[i].color}\"/>");
            s.Drawing(sb.ToString(), b, b, R * 2, R * 2);
            s.Close();
            s.Box(0, 0, DISC, DISC, new BoxStyle { Radius = DISC, BorderWidth = b, BorderColor = "#ffffff" });
            return _disc = s.Markup;
        }

        static (double, double) Polar(double deg, double r) { double a = (deg - 90) * Math.PI / 180; return (R + r * Math.Cos(a), R + r * Math.Sin(a)); }
        static string Wedge(int i)
        {
            var (x0, y0) = Polar(i * SLICE, R + 1);
            var (x1, y1) = Polar((i + 1) * SLICE - 1.4, R + 1);
            return $"M{F(R)} {F(R)} L{F(x0)} {F(y0)} A{F(R + 1)} {F(R + 1)} 0 0 1 {F(x1)} {F(y1)} Z";
        }

        static string LabelSvg(int i)
        {
            var w = WHEEL[i];
            string key = w.kind + w.amount;
            if (_labels.TryGetValue(key, out var m)) return m;
            var s = new UiSvg(84, 52);
            var t = T(Kit.Display, 24, "#ffffff", 0, 26, new[] { new Shadow(PURPLE, 0, 2, 0), new Shadow(PURPLE, 1.5f, 0, 0), new Shadow(PURPLE, -1.5f, 0, 0), new Shadow(PURPLE, 0, -1.5f, 0) });
            float top = (52 - (26 + 2 + 26)) / 2;
            Embed(s, w.kind == "gems" ? "gem" : "coin", 29, top, 26, 26);
            s.Text(Prof.JsStr(w.amount), 0, top + 28, t, 84, 0.5f);
            return _labels[key] = s.Markup;
        }

        static string PinSvg()
        {
            if (_pin != null) return _pin;
            // in a box from y = -20 of the wheel: the drop (42 square, three round corners, turned -45°) and its shine
            var s = new UiSvg(S, 40);
            float x = S / 2 - 21, y = -16 + 20;
            s.Open($"transform=\"rotate(-45 {F(x + 21)} {F(y + 21)})\"");
            s.Box(x, y, 42, 42, new BoxStyle { Radii = new[] { 21f, 21, 21, 0 }, Background = "#8a3a0e" });
            float b = 3;
            s.Box(x + 2, y + 2, 38, 38, new BoxStyle { Radii = new[] { 19f, 19, 19, 0 }, Background = "#ffffff" });
            s.Box(x + 2 + b, y + 2 + b, 38 - 2 * b, 38 - 2 * b, new BoxStyle { Radii = new[] { 19 - b, 19 - b, 19 - b, 0 }, Gradient = new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }, GradientStops = new[] { 0f, 0.55f, 1 }, GradientAngle = 135 });
            s.Close();
            s.Box(S / 2 - 6, -3 + 20, 12, 8, new BoxStyle { Radius = 6, Background = "rgba(255,255,255,0.85)" });
            return _pin = s.Markup;
        }

        static string HubSvg(string label)
        {
            if (_hubs.TryGetValue(label, out var m)) return m;
            var s = new UiSvg(HUB + 6, HUB + 11);
            s.Box(0, 5, HUB + 6, HUB + 6, new BoxStyle { Radius = HUB, Background = RIM });
            s.Box(0, 0, HUB + 6, HUB + 6, new BoxStyle { Radius = HUB, Background = RIM });
            float b = 4, px = 3 + b, pw = HUB - 2 * b;
            var clip = s.NewId("hc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, px, pw, pw, new[] { HUB, HUB, HUB, HUB })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Def("<radialGradient id=\"hubG\" cx=\"35%\" cy=\"28%\" r=\"80%\"><stop offset=\"0\" stop-color=\"#fff7c0\"/><stop offset=\"0.45\" stop-color=\"#ffc233\"/><stop offset=\"1\" stop-color=\"#e08a00\"/></radialGradient>");
            s.Drawing($"<circle cx=\"{F(HUB / 2)}\" cy=\"{F(HUB / 2)}\" r=\"{F(HUB * 0.75)}\" fill=\"url(#hubG)\"/>", px, px, HUB, HUB);
            s.Close();
            s.Box(3, 3, HUB, HUB, new BoxStyle { Radius = HUB, BorderWidth = b, BorderColor = "#ffffff" });
            var t = T(Kit.Display, 25, "#ffffff", 0, 0, new[] { new Shadow(RIM, 0, 2, 0), new Shadow(RIM, 1.5f, 0, 0), new Shadow(RIM, -1.5f, 0, 0), new Shadow(RIM, 0, -1.5f, 0) });
            float tw = W(label, t), th = LH(t);
            s.Text(label, 3 + (HUB - tw) / 2, 3 + (HUB - th) / 2, t);
            return _hubs[label] = s.Markup;
        }
    }
}
