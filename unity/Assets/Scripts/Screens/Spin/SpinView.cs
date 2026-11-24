// src/screens/DailySpinScreen.js, landscape (REDESIGN_V7 step 4: the wheel on the left sized by the height, the rest
// beside it), and src/dailySpin.js, as pure C#: "HI <NAME>!", "Daily Spin", the wheel and its SPIN hub, which is the
// button. 2026-11-17/18 (the user), the wheel in the game's look: a gold rim with an ink outline; cream, wood, gold and
// amethyst slices; the menu's coins and gems and, on one slice, today's Mystery Box (a Common chest of today's first HOT
// group); the prizes and the rim's 16 lights (blinking in two groups) turn with the wheel; the pointer is a flapper hung
// above the rim, its tip in between the gold pegs: each peg knocks it aside and it springs back (stepFlap).
// SPIN asks the server (OnSpin: the spinWheel Cloud Function) for the prize: the wheel whirls while it waits (450 ms
// ramping up, then 100 turns over 15 s), then from wherever it is turns five more laps and eases onto the slice the
// server picked (4.5 s, bezier 0.12 0.72 0.06 1); the "You won!" card pops in (450 ms), the prize and its amount on one
// row. Collect (Open for the Mystery Box: OnOpenChest, the treasure vault and the smash); then "Spin again" (one bonus
// spin a day, MAX_AD_SPINS; the server counts it too) and "Continue to my squad", in the games' gold and white.
// No ads in Unity yet: the bonus spin is offered only with Remove Ads (`adsFree`, where the app skips the video); for
// other players only Continue shows (the app plays a rewarded video first).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    /// <summary>spinWheel's answer: { index, kind, amount, jackpot, size, chest } or { already, bonus } or an error.</summary>
    public sealed class SpinResult
    {
        public int Index; public string Kind = "coins", Size; public double Amount; public bool Jackpot, Already, Bonus, Error;
        /// <summary>The Mystery Box's chest, opened by the server (squad.js openGroup's result), for the smash.</summary>
        public IDictionary<string, object> Chest;

        public static SpinResult From(object data)
        {
            var m = Prof.Map(data);
            if (m == null) return new SpinResult { Error = true };
            return new SpinResult
            {
                Index = (int)Prof.Num(Prof.Get(m, "index")), Kind = Prof.Str(Prof.Get(m, "kind")) ?? "coins", Amount = Prof.Num(Prof.Get(m, "amount")),
                Jackpot = Prof.Truthy(Prof.Get(m, "jackpot")), Already = Prof.Truthy(Prof.Get(m, "already")), Bonus = Prof.Truthy(Prof.Get(m, "bonus")),
                Size = Prof.Str(Prof.Get(m, "size")), Chest = Prof.Map(Prof.Get(m, "chest")),
            };
        }
    }

    public sealed class SpinView : IScreenView
    {
        // dailySpin.js WHEEL (functions/dailySpin.js has the same eight, in the same order): `tone` the slice's look
        public static readonly (string kind, double amount, string tone, string size)[] WHEEL =
        {
            ("coins", 100, "cream", null), ("gems", 5, "wood", null), ("coins", 250, "cream", null), ("chest", 1, "gold", "common"),
            ("coins", 50, "cream", null), ("gems", 15, "wood", null), ("coins", 500, "cream", null), ("gems", 50, "jewel", null),
        };
        public const double SLICE = 360.0 / 8;
        public const int MAX_AD_SPINS = 1;
        const float S = 366, DISC = 318, R = DISC / 2, SEAT = R + 4, LIGHTS_R = 173, LABEL_R = 100, HUB = 98;
        const double SPIN_MS = 4500;
        const int LAPS = 5;
        const string BROWN = "#6b4426";
        const double REST = 360 - SLICE / 2;   // the wheel's turn before the first spin: slice 0's middle under the pointer
        // the flapper (wheel box units): its pivot above the rim, the tip FLAP_L below it (in past the pegs' circle)
        const float PEG_R = R - 10, PIV_Y = -16, FLAP_L = 60, PEG_GAP = 7, CAP = 32;
        const double D2R = Math.PI / 180;
        static readonly Func<double, double> SpinEase = Easing.Bezier(0.12, 0.72, 0.06, 1);
        // a slice's colours, from the middle out (royal/theme.js: the cream labels, the wood plaques, the gold plaque, the amethyst one)
        static readonly Dictionary<string, (float o, string c)[]> TONES = new Dictionary<string, (float, string)[]>
        {
            ["cream"] = new[] { (0f, "#fffaf0"), (0.55f, "#fbe7c4"), (1f, "#f0c88c") },
            ["wood"] = new[] { (0f, "#eebf86"), (0.55f, "#d59a5c"), (1f, "#b47a42") },
            ["gold"] = new[] { (0f, "#fff1b0"), (0.5f, "#ffd650"), (1f, "#f6a524") },
            ["jewel"] = new[] { (0f, "#e6c8ff"), (0.5f, "#a565ff"), (1f, "#6420c8") },
        };
        // royal/theme.js RIM (--rimG, top to bottom)
        static readonly (float o, string c)[] RIM = { (0, "#fffbe2"), (0.24f, "#ffdd6e"), (0.55f, "#f2ac2c"), (0.82f, "#b8680c"), (1, "#ffd474") };

        public readonly float W, H;
        public readonly string Name;
        public readonly bool AdsFree;
        public readonly int BonusLeft;
        /// <summary>Today's Mystery Box group (the first HOT one: the server gives its chest).</summary>
        public readonly string Group;
        /// <summary>Asks the server for the spin (bonus: the second one); the host calls spinWheel.</summary>
        public Func<bool, Task<SpinResult>> OnSpin;
        public Action OnDone;
        /// <summary>The Mystery Box's Open: the host smashes the chest the server opened (under the treasure vault).</summary>
        public Action<IDictionary<string, object>> OnOpenChest;

        /// <summary>'idle' | 'spinning' | 'prize' | 'done' | 'adReady' | 'error'</summary>
        public string Phase { get; private set; } = "idle";
        public SpinResult Result { get; private set; }
        int _usedHere;
        bool _busy;

        readonly Ticker _t;
        readonly double _t0;
        readonly AnimatedValue _rot = new AnimatedValue(REST), _pop = new AnimatedValue(0);

        public SpinView(string name, int bonusLeft, bool adsFree, float w, float h, Ticker ticker, Func<DateTime> now = null)
        {
            Name = name; BonusLeft = bonusLeft; AdsFree = adsFree; W = w; H = h; _t = ticker;
            _t0 = _t.Now;
            var day = (now ?? (() => DateTime.Now))().ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var hot = ShopData.Lineup(day, ShopData.Hidden);
            Group = hot.Count > 0 ? hot[0] : "snack";
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

        void Collect()
        {
            if (Result != null && Result.Kind == "chest" && Result.Chest != null) OnOpenChest?.Invoke(Result.Chest);
            Phase = "done";
        }
        void WatchAd() { if (AdsFree) Phase = "adReady"; else Ui.AdHook.Show(() => Phase = "adReady"); }

        // ---- the flapper (DailySpinScreen.js stepFlap / useFlapper) --------------------------------------------------------
        // One step (a: its angle in degrees, + = its tip to the left; w: its speed) with the disc turned theta: a damped
        // spring pulls it straight down (~11 Hz, a few wobbles), the hinge stops it at ±48°, and the peg nearest the top,
        // while it's within the tip's reach, keeps to its side of the flapper, pushing it along until it slips out under it.
        sealed class Flap { public double A, Wv; public int? N; public int Side = 1; public double? Lim; }
        static void StepFlap(Flap F, double theta, double dt)
        {
            F.Wv += (-4800 * F.A - 26 * F.Wv) * dt;
            F.A += F.Wv * dt;
            if (F.A > 48) { F.A = 48; F.Wv *= -0.3; } else if (F.A < -48) { F.A = -48; F.Wv *= -0.3; }
            int n = (int)Math.Round(theta / SLICE, MidpointRounding.AwayFromZero);
            if (theta / SLICE - Math.Floor(theta / SLICE) == 0.5) n = (int)Math.Floor(theta / SLICE) + 1;   // (Math.round: halves up)
            double d = (theta - n * SLICE) * D2R;
            double px = PEG_R * Math.Sin(d), py = S / 2 - PEG_R * Math.Cos(d) - PIV_Y;
            double rho = Math.Sqrt(px * px + py * py);
            if (rho > FLAP_L + 2) { F.N = null; F.Lim = null; return; }
            double beta = Math.Atan2(-px, py) / D2R, delta = Math.Asin(Math.Min(1, PEG_GAP / rho)) / D2R;
            if (F.N != n) { F.N = n; F.Side = beta > F.A ? 1 : -1; F.Lim = null; }
            double lim = beta - F.Side * delta;
            if (F.Side * (F.A - lim) > 0)
            {
                double push = F.Lim == null ? 0 : (lim - F.Lim.Value) / dt;
                F.A = lim;
                if (F.Side * (F.Wv - push) > 0) F.Wv = push;
            }
            F.Lim = lim;
        }

        readonly Flap _flap = new Flap();
        double _sim = REST, _flapLast, _shown;
        bool _flapOn;
        int _still;

        // every frame: the physics runs while the wheel turns or the flapper still moves
        void TickFlap()
        {
            double th = _rot.GetValue(), now = _t.Now;
            if (!_flapOn) { if (th == _sim) return; _flapOn = true; _flapLast = 0; }
            double dt = Math.Min(0.05, _flapLast > 0 ? (now - _flapLast) / 1000 : 1 / 60.0);
            _flapLast = now;
            double t0 = _sim, t1 = th;
            int steps = Math.Max(1, Math.Min(160, (int)Math.Ceiling(Math.Max(Math.Abs(t1 - t0) / 0.75, dt * 240))));
            for (int i = 1; i <= steps; i++) StepFlap(_flap, t0 + (t1 - t0) * i / steps, dt / steps);
            _sim = t1;
            if (Math.Abs(_flap.A - _shown) > 0.05) _shown = _flap.A;
            bool moving = t1 != t0 || Math.Abs(_flap.A) > 0.05 || Math.Abs(_flap.Wv) > 1;
            _still = moving ? 0 : _still + 1;
            if (_still >= 3) { _flapOn = false; _flapLast = 0; _flap.A = 0; _flap.Wv = 0; _shown = 0; _still = 0; }
        }

        // ---- layout ------------------------------------------------------------------------------------------------------
        float K => Math.Min(1, (H - 40) / (S + 14 + CAP));
        float RowX => (W - ((S + 6) * K + 40 + 360)) / 2;
        // the wheel's 366 box, scaled by K about its middle, in the screen (CAP: the room the flapper's cap needs above it)
        Affine WheelM
        {
            get
            {
                float cw = (S + 6) * K, ch = (S + 14 + CAP) * K;
                float x = RowX + (cw - S) / 2, y = (H - ch) / 2 + (S * K - S) / 2 + (3 + CAP) * K;
                return Affine.Translate(x, y) * About(S, S, Affine.ScaleBy(K, K));
            }
        }
        float SideX => RowX + (S + 6) * K + 40;

        static readonly TextStyle HiT = T(Black, 12, BROWN, 2);
        static readonly TextStyle SubT = T(Heavy, 13, BROWN);
        static readonly TextStyle NoteT = T(Heavy, 13, BROWN);
        static readonly TextStyle UnlockedT = T(Kit.Display, 17, "#9c4d06");
        static readonly TextStyle AdSubT = T(Black, 10.5f, "#8a4a06", 0.6f);
        static TextStyle GoldLabel(float size) => T(Kit.Display, size, "#ffffff", 0, 0, CardArt.Outline3(CardArt.BTN["gold"].ring, 2));

        // the buttons (squishdoku/ui.js SdButton): the gold "Watch ad, spin again" (its face 16 x 7, a play disc and two
        // lines), the white "Continue to my squad" (26 x 7)
        string SpinAgain => AdsFree ? "Spin again" : "Watch ad, spin again";
        CardArt.ButtonLook AdBtn
        {
            get
            {
                float colW = Math.Max(UiSvg.BoxWidth(SpinAgain, GoldLabel(18)), UiSvg.BoxWidth("ONE BONUS SPIN PER DAY", AdSubT));
                float colH = UiSvg.LineBox(GoldLabel(18)) + LH(AdSubT);
                float faceW = 3 + 16 + 30 + 2 + 8 + colW + 16 + 3, faceH = 3 + 7 + Math.Max(30, colH) + 7 + 3;
                return new CardArt.ButtonLook("gold", "", 18, 16, 7, faceW + 5) { FaceHeight = faceH };
            }
        }
        static CardArt.ButtonLook GoBtn => new CardArt.ButtonLook("white", "Continue to my squad", 17, 26, 7);

        // the side column's items, top to bottom: (id, height, width)
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
                if (Phase == "done" && SpinsLeft > 0 && (AdsFree || Ui.AdHook.Available)) h += AdBtn.H + 9;
                else if (Phase == "done" && SpinsLeft == 0) h += NoteH(DoneNote) + 9;
                if (Phase == "error") h += NoteH(ErrorNote) + 9;
                h += GoBtn.H;
                l.Add(("after", h, 360));
            }
            if (Phase == "adReady") l.Add(("unlocked", LH(UnlockedT) + 4, W("Spin unlocked! Tap SPIN.", UnlockedT)));
            return l;
        }

        const string DoneNote = "That’s all the spins for today. Come back tomorrow!";
        string ErrorNote => Result != null && Result.Already ? (Result.Bonus ? "No more spins today. Come back tomorrow!" : "You already spun today. Come back tomorrow!") : "We couldn't reach the wheel. Try again next time.";
        float NoteH(string t) => new TextFlow(t, NoteT, 0.5f).Measure(320).h;

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
                if (Phase == "done" && SpinsLeft > 0 && (AdsFree || Ui.AdHook.Available)) { var b = AdBtn; f["ad"] = new Frame(SideX + (360 - b.W) / 2, ay, b.W, b.H); ay += b.H + 9; }
                else if (Phase == "done" && SpinsLeft == 0) { var nh = NoteH(DoneNote); f["note"] = new Frame(SideX + 20, ay, 320, nh); ay += nh + 9; }
                if (Phase == "error") { var nh = NoteH(ErrorNote); f["note"] = new Frame(SideX + 20, ay, 320, nh); ay += nh + 9; }
                var g = GoBtn;
                f["go"] = new Frame(SideX + (360 - g.W) / 2, ay, g.W, g.H);
            }
            return f;
        }

        // ---- the prize card: at most 300 wide, centred (the title, the prize and its amount on one row, Collect / Open) ---
        static readonly TextStyle CardTitle = T(Kit.Display, 30, "#ffffff", 0, 0, new[] { new Shadow(BROWN, 0, 3, 0), new Shadow(BROWN, 2, 0, 0), new Shadow(BROWN, -2, 0, 0), new Shadow(BROWN, 0, -2, 0) });
        static readonly TextStyle CardAmt = T(Kit.Display, 34, "#8a3a0e", 0, 38);
        static readonly TextStyle CardWhat = T(Black, 13, "#9a6a3a", 1.5f);
        float CardW => Math.Min(300, W - 48);
        CardArt.ButtonLook CollectBtn => new CardArt.ButtonLook("gold", Result != null && Result.Kind == "chest" && Result.Chest != null ? "Open" : "Collect", 20, 18, 8, CardW - 6 - 40);
        float RowH => Math.Max(Result != null && Result.Kind == "chest" ? 60 : 62, 38 + LH(CardWhat)) + 16;
        Frame CardBox(out float faceH)
        {
            faceH = 3 + 20 + LH(CardTitle) + 12 + RowH + 12 + 2 + CollectBtn.H + 18 + 3;
            float h = faceH + 6;
            return new Frame((W - CardW) / 2, (H - h) / 2, CardW, h);
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
            else if (h == "ad") WatchAd();
            else if (h == "go") OnDone?.Invoke();
        }

        string Hit(float x, float y)
        {
            if (Phase == "prize")
            {
                var cb = CardBox(out float fh);
                var b = CollectBtn;
                float by = cb.Y + fh - 3 - 18 - b.H;
                return x >= cb.X + 23 - 6 && x < cb.X + 23 + b.W + 6 && y >= by - 6 && y < by + b.H + 6 ? "collect" : null;
            }
            var c = WheelM.Apply(new Vec2(S / 2, S / 2));
            double dx = x - c.X, dy = y - c.Y, r = ((HUB + 8) / 2 + 6) * K;
            if (dx * dx + dy * dy <= r * r) return "hub";
            var f = Side();
            foreach (var k in new[] { "ad", "go" })
                if (f.TryGetValue(k, out var bx) && x >= bx.X - 6 && x < bx.Right + 6 && y >= bx.Y - 6 && y < bx.Bottom + 6) return k;
            return null;
        }

        // ---- the pieces --------------------------------------------------------------------------------------------------
        // idleLoop.js usePingPong(900): 0 -> 1 -> 0 eased (UP_DOWN), read through 17 keyframes
        double PingPong(double ms, double delay)
        {
            double u = _t.Now - _t0 - delay;
            if (u < 0) return 0;
            double p = u / ms % 1 * 16;
            int i = Math.Min(15, (int)Math.Floor(p));
            double k(int j) => (1 - Math.Cos(2 * Math.PI * j / 16)) / 2;
            return k(i) + (k(i + 1) - k(i)) * (p - i);
        }

        public List<ScreenPiece> Pieces()
        {
            TickFlap();
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", PageBg(W, H), W, H, 0, 0, 1, null, 0));
            var wm = WheelM;
            void Add(ScreenPiece p) { p.Transform = wm * p.Transform; list.Add(p); }
            Add(Piece("rim", RimGlowSvg(), S + 100, S + 100, -50, -50, 1, null, 0));
            Add(Piece("frame", FrameSvg(), S + 6, S + 12, -3, -3, 1, null, 2));
            double rot = _rot.GetValue();
            // the rim's lights, turning with the wheel: a stud each, its light blinking over it
            for (int i = 0; i < 16; i++)
            {
                double a = (i * 22.5 + 11.25 + rot) * D2R, t = PingPong(900, i % 2 == 1 ? 450 : 0);
                float cx = S / 2 + (float)(LIGHTS_R * Math.Sin(a)), cy = S / 2 - (float)(LIGHTS_R * Math.Cos(a));
                Add(Piece("stud" + i, StudSvg(), 29, 29, cx - 14.5f, cy - 14.5f, 1, null, 2));
                Add(Piece("bulb" + i, BulbSvg(), 29, 29, cx - 14.5f, cy - 14.5f, (float)(1 - 0.85 * t), null, 0));
            }
            Add(Piece("disc", DiscSvg(), DISC, DISC, (S - DISC) / 2, (S - DISC) / 2, 1, About(DISC, DISC, Affine.Rotate(rot)), 4));
            // each prize fixed in its slice, standing out from the middle (84 x 76, about the disc's middle)
            for (int i = 0; i < 8; i++)
            {
                double ang = i * SLICE + SLICE / 2 + rot;
                var m = Affine.Translate(S / 2, S / 2) * Affine.Rotate(ang) * Affine.Translate(0, -LABEL_R) * Affine.Translate(-42, -38);
                Add(new ScreenPiece { Id = "label" + i, Svg = LabelSvg(i, Group), W = 84, H = 76, Margin = 28, Transform = m });
            }
            // the flapper, turned about its pivot
            const float FW = 44, FH = 2 * (FLAP_L + 16), FP = FH / 2;
            Add(Piece("flap", FlapSvg(), FW, FH, S / 2 - FW / 2, PIV_Y - FP, 1, About(FW, FH, Affine.Rotate(_shown)), 4));
            string hub = Phase == "spinning" ? "…" : "SPIN";
            bool live = Phase == "idle" || Phase == "adReady";
            float B = HUB + 8;
            Add(Piece("hub", HubSvg(hub, live), B, B + 5, S / 2 - B / 2, S / 2 - B / 2, 1, _pressed == "hub" && live ? About(B, B + 5, Affine.ScaleBy(0.94, 0.94)) : (Affine?)null, 4));
            SidePieces(list);
            if (Phase == "prize" && Result != null) Card(list);
            return list;
        }

        void Button(List<ScreenPiece> list, string id, CardArt.ButtonLook b, float x, float y, Action<UiSvg> content = null)
        {
            bool down = _pressed == id;
            list.Add(Piece(id + "-lip", b.LipMarkup(), b.RingW, b.RingH, x, y + CardArt.ButtonLook.Lip, 1, null, 2));
            var face = b.FaceMarkup();
            if (content != null)
            {
                var s = new UiSvg(b.RingW, b.RingH);
                s.Raw(Inner(face));
                content(s);
                face = s.Markup;
            }
            list.Add(Piece(id, face, b.RingW, b.RingH, x, y + (down ? CardArt.ButtonLook.Lip - 1 : 0), 1, down ? About(b.RingW, b.RingH, Affine.ScaleBy(0.93, 0.93)) : (Affine?)null, 2));
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
                new TextFlow(Phase == "error" ? ErrorNote : DoneNote, NoteT, 0.5f).Draw(ns, 0, 0, nf.W);
                list.Add(Piece("note", ns, nf.X, nf.Y));
            }
            if (f.TryGetValue("ad", out var af))
            {
                var b = AdBtn;
                Button(list, "ad", b, af.X, af.Y, s =>
                {
                    // the play disc and the two lines, in a row in the face (padding 16 x 7 inside the 3 white border)
                    float fx = 2.5f + 3 + 16, inner = b.FaceH - 6 - 14, fy = 2.5f + 3 + 7;
                    s.Box(fx, fy + (inner - 30) / 2, 30, 30, new BoxStyle { Radius = 15, Background = "#ffffff" });
                    s.Raw($"<path d=\"M{F(fx + 15 - 5.5f + 1.5f)} {F(fy + inner / 2 - 7)} l11 7 l-11 7 Z\" fill=\"#c66f0a\"/>");
                    var bt = GoldLabel(18);
                    float colH = UiSvg.LineBox(bt) + LH(AdSubT), cx = fx + 30 + 2 + 8, cy = fy + (inner - colH) / 2;
                    s.Text(SpinAgain, cx, cy, bt);
                    s.Text("ONE BONUS SPIN PER DAY", cx, cy + UiSvg.LineBox(bt), AdSubT);
                });
            }
            if (f.TryGetValue("go", out var gf)) Button(list, "go", GoBtn, gf.X, gf.Y);
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
            string t = Result.Kind == "gems" && Result.Amount >= 50 ? "JACKPOT!" : "You won!";
            float y = 3 + 20;
            s.Text(t, 0, y, CardTitle, cb.W, 0.5f);
            y += LH(CardTitle) + 12;
            // the prize and how much, on one row (the user, 2026-11-17)
            float rx = 23, rw = cb.W - 46, rh = RowH;
            s.Box(rx, y, rw, rh, new BoxStyle { Radius = 20, Background = "rgba(184,100,28,0.10)" });
            bool chest = Result.Kind == "chest";
            float art = chest ? 60 : 62;
            string amount = "+" + Prof.Fmt(Result.Amount), what = chest ? "MYSTERY BOX" : Result.Kind.ToUpperInvariant();
            float colW = Math.Max(W(amount, CardAmt), W(what, CardWhat)), rowW = art + 12 + colW, x0 = rx + (rw - rowW) / 2;
            var prize = new Dictionary<string, object> { ["k"] = Result.Kind, ["t"] = Result.Size ?? "common" };
            string group = Prof.Str(Prof.Get(Result.Chest, "group")) ?? Group;
            RoadView.PrizeArt(s, prize, group, 0, x0, y + (rh - art) / 2, art, false);
            float colH = 38 + LH(CardWhat), cy = y + (rh - colH) / 2;
            s.Text(amount, x0 + art + 12, cy, CardAmt);
            s.Text(what, x0 + art + 12, cy + 38, CardWhat);
            y += rh + 12 + 2;
            double pop = _pop.GetValue();
            double sc = Motion.Lerp(pop, new[] { 0, 0.6, 1 }, new[] { 0.7, 1.06, 1 });
            var about = About(cb.W, cb.H, Affine.ScaleBy(sc, sc));
            list.Add(Piece("card", s, cb.X, cb.Y, (float)pop, about, 8));
            // Collect / Open, scaling with the card (its place in the card's box)
            var b = CollectBtn;
            bool down = _pressed == "collect";
            var lip = Piece("collect-lip", b.LipMarkup(), b.RingW, b.RingH, 0, 0, (float)pop, null, 2);
            lip.Transform = Affine.Translate(cb.X, cb.Y) * about * Affine.Translate(23, y + CardArt.ButtonLook.Lip);
            list.Add(lip);
            var face = Piece("collect", b.FaceMarkup(), b.RingW, b.RingH, 0, 0, (float)pop, null, 2);
            face.Transform = Affine.Translate(cb.X, cb.Y) * about * Affine.Translate(23, y + (down ? CardArt.ButtonLook.Lip - 1 : 0)) * (down ? About(b.RingW, b.RingH, Affine.ScaleBy(0.93, 0.93)) : Affine.Identity);
            list.Add(face);
        }

        static string Inner(string svg) { int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>", StringComparison.Ordinal); return svg.Substring(a, b - a); }

        // ---- the wheel's drawings ------------------------------------------------------------------------------------------
        static string _glow, _frame, _stud, _bulb, _disc, _flapSvg;
        static readonly Dictionary<string, string> _hubs = new Dictionary<string, string>(), _labels = new Dictionary<string, string>();
        static string Stops((float o, string c)[] st) { var sb = new System.Text.StringBuilder(); foreach (var (o, c) in st) sb.Append($"<stop offset=\"{F(o)}\" stop-color=\"{c}\"/>"); return sb.ToString(); }

        // the warm glow round the rim
        static string RimGlowSvg()
        {
            if (_glow != null) return _glow;
            float sz = S + 100;
            var s = new UiSvg(sz, sz);
            s.Def($"<radialGradient id=\"dsRimGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"{F(S / sz)}\" stop-color=\"#ffd250\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffd250\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(sz / 2)}\" cy=\"{F(sz / 2)}\" r=\"{F(sz / 2)}\" fill=\"url(#dsRimGlow)\"/>");
            return _glow = s.Markup;
        }

        // the frame: an ink lip and outline, the menu's gold rim (--rimG), and the ink seat the disc turns in
        static string FrameSvg()
        {
            if (_frame != null) return _frame;
            var s = new UiSvg(S + 6, S + 12);
            float c = S / 2 + 3;
            s.Def($"<linearGradient id=\"dsRim\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\">{Stops(RIM)}</linearGradient>");
            s.Raw($"<circle cx=\"{F(c)}\" cy=\"{F(S / 2 + 9)}\" r=\"{F(S / 2 + 3)}\" fill=\"{BROWN}\"/>");
            s.Raw($"<circle cx=\"{F(c)}\" cy=\"{F(c)}\" r=\"{F(S / 2 + 3)}\" fill=\"{BROWN}\"/>");
            s.Raw($"<circle cx=\"{F(c)}\" cy=\"{F(c)}\" r=\"{F(S / 2)}\" fill=\"url(#dsRim)\"/>");
            s.Raw($"<circle cx=\"{F(c)}\" cy=\"{F(c)}\" r=\"{F(S / 2 - 2.5f)}\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.55\" stroke-width=\"2\"/>");
            s.Raw($"<circle cx=\"{F(c)}\" cy=\"{F(c)}\" r=\"{F(SEAT)}\" fill=\"{BROWN}\"/>");
            return _frame = s.Markup;
        }

        static string StudSvg() => _stud ??= new UiSvg(29, 29)
            .Def("<radialGradient id=\"dsStud\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fff3c4\"/><stop offset=\"0.55\" stop-color=\"#e2b14a\"/><stop offset=\"1\" stop-color=\"#8a5d1a\"/></radialGradient>")
            .Raw($"<circle cx=\"14.5\" cy=\"14.5\" r=\"6\" fill=\"url(#dsStud)\" stroke=\"{BROWN}\" stroke-width=\"1.4\"/>").Markup;

        static string BulbSvg() => _bulb ??= new UiSvg(29, 29)
            .Def("<radialGradient id=\"dsGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0.35\" stop-color=\"#fff6c8\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff0aa\" stop-opacity=\"0\"/></radialGradient>")
            .Raw("<circle cx=\"14.5\" cy=\"14.5\" r=\"14.5\" fill=\"url(#dsGlow)\"/><circle cx=\"14.5\" cy=\"14.5\" r=\"4.6\" fill=\"#ffffff\"/>").Markup;

        static (double, double) Polar(double deg, double r) { double a = (deg - 90) * D2R; return (R + r * Math.Cos(a), R + r * Math.Sin(a)); }
        static string Wedge(int i)
        {
            var (x0, y0) = Polar(i * SLICE, R);
            var (x1, y1) = Polar((i + 1) * SLICE, R);
            return $"M{F(R)} {F(R)} L{F(x0)} {F(y0)} A{F(R)} {F(R)} 0 0 1 {F(x1)} {F(y1)} Z";
        }

        // the disc: the slices, ink lines between them with gold pegs at the rim
        static string DiscSvg()
        {
            if (_disc != null) return _disc;
            var s = new UiSvg(DISC, DISC);
            foreach (var kv in TONES) s.Def($"<radialGradient id=\"dsT{kv.Key}\" cx=\"{F(R)}\" cy=\"{F(R)}\" r=\"{F(R)}\" fx=\"{F(R)}\" fy=\"{F(R)}\" gradientUnits=\"userSpaceOnUse\">{Stops(kv.Value)}</radialGradient>");
            s.Def("<radialGradient id=\"dsPeg\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fffbe2\"/><stop offset=\"0.5\" stop-color=\"#ffd34e\"/><stop offset=\"1\" stop-color=\"#b8680c\"/></radialGradient>");
            for (int i = 0; i < 8; i++) s.Raw($"<path d=\"{Wedge(i)}\" fill=\"url(#dsT{WHEEL[i].tone})\"/>");
            for (int i = 0; i < 8; i++) { var (x, y) = Polar(i * SLICE, R); s.Raw($"<line x1=\"{F(R)}\" y1=\"{F(R)}\" x2=\"{F(x)}\" y2=\"{F(y)}\" stroke=\"{BROWN}\" stroke-width=\"3\" stroke-linecap=\"round\"/>"); }
            // a soft dark edge round the disc, then its ink line
            s.Raw($"<circle cx=\"{F(R)}\" cy=\"{F(R)}\" r=\"{F(R - 7)}\" fill=\"none\" stroke=\"{BROWN}\" stroke-opacity=\"0.12\" stroke-width=\"10\"/>");
            s.Raw($"<circle cx=\"{F(R)}\" cy=\"{F(R)}\" r=\"{F(R - 1.5f)}\" fill=\"none\" stroke=\"{BROWN}\" stroke-width=\"3\"/>");
            for (int i = 0; i < 8; i++) { var (x, y) = Polar(i * SLICE, R - 10); s.Raw($"<circle cx=\"{F(x)}\" cy=\"{F(y)}\" r=\"4.6\" fill=\"url(#dsPeg)\" stroke=\"{BROWN}\" stroke-width=\"1.5\"/>"); }
            return _disc = s.Markup;
        }

        // a prize (84 x 76, a column centred, gap 1): the coin (34) or gem (36) and its amount in ink lettering (22, line 25),
        // or the Mystery Box: today's chest (LevelBits.js PrizeArt, 46)
        static readonly TextStyle LabelT = T(Kit.Display, 22, "#ffffff", 0, 25, TX_W);
        static string LabelSvg(int i, string group)
        {
            var w = WHEEL[i];
            string key = w.kind + w.amount + (w.kind == "chest" ? group : "");
            if (_labels.TryGetValue(key, out var m)) return m;
            var s = new UiSvg(84, 76);
            if (w.kind == "chest")
                RoadView.PrizeArt(s, new Dictionary<string, object> { ["k"] = "chest", ["t"] = w.size }, group, 0, 42 - 23, 38 - 23, 46, false);
            else
            {
                float sz = w.kind == "gems" ? 36 : 34, th = 25, top = (76 - (sz + 1 + th)) / 2;
                RoadView.PrizeArt(s, new Dictionary<string, object> { ["k"] = w.kind }, group, 0, 42 - sz / 2, top, sz, false);
                s.Text(Prof.JsStr(w.amount), 0, top + sz + 1, LabelT, 84, 0.5f);
            }
            return _labels[key] = s.Markup;
        }

        // the flapper: a gold tongue hung from a round cap with a screw, its tip pointing down into the wheel; its box is
        // centred on the pivot so it turns about it
        static string FlapSvg()
        {
            if (_flapSvg != null) return _flapSvg;
            const float FW = 44, FH = 2 * (FLAP_L + 16), FP = FH / 2;
            string Tongue(float dy) => $"M{F(FW / 2 - 12)} {F(FP + dy)} L{F(FW / 2 - 3.2f)} {F(FP + FLAP_L - 4 + dy)} Q{F(FW / 2)} {F(FP + FLAP_L + 2 + dy)} {F(FW / 2 + 3.2f)} {F(FP + FLAP_L - 4 + dy)} L{F(FW / 2 + 12)} {F(FP + dy)} Z";
            var s = new UiSvg(FW, FH);
            s.Def("<linearGradient id=\"dsPin\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#fff1b0\"/><stop offset=\"0.45\" stop-color=\"#ffd650\"/><stop offset=\"1\" stop-color=\"#f08c10\"/></linearGradient>");
            s.Def("<radialGradient id=\"dsCap\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fff7c8\"/><stop offset=\"0.5\" stop-color=\"#ffd34e\"/><stop offset=\"1\" stop-color=\"#e08a12\"/></radialGradient>");
            s.Raw($"<path d=\"{Tongue(3)}\" fill=\"{BROWN}\"/>");
            s.Raw($"<path d=\"{Tongue(0)}\" fill=\"url(#dsPin)\" stroke=\"{BROWN}\" stroke-width=\"3\" stroke-linejoin=\"round\"/>");
            s.Raw($"<line x1=\"{F(FW / 2 - 6.5f)}\" y1=\"{F(FP + 14)}\" x2=\"{F(FW / 2 - 2)}\" y2=\"{F(FP + FLAP_L - 12)}\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"2.2\" stroke-linecap=\"round\"/>");
            s.Raw($"<circle cx=\"{F(FW / 2)}\" cy=\"{F(FP + 3)}\" r=\"13\" fill=\"{BROWN}\"/>");
            s.Raw($"<circle cx=\"{F(FW / 2)}\" cy=\"{F(FP)}\" r=\"13\" fill=\"url(#dsCap)\" stroke=\"{BROWN}\" stroke-width=\"3\"/>");
            s.Raw($"<circle cx=\"{F(FW / 2)}\" cy=\"{F(FP)}\" r=\"5\" fill=\"#fff6e2\" stroke=\"{BROWN}\" stroke-width=\"2\"/>");
            s.Raw($"<line x1=\"{F(FW / 2 - 3)}\" y1=\"{F(FP)}\" x2=\"{F(FW / 2 + 3)}\" y2=\"{F(FP)}\" stroke=\"{BROWN}\" stroke-width=\"1.6\" stroke-linecap=\"round\"/>");
            s.Raw($"<ellipse cx=\"{F(FW / 2 - 5)}\" cy=\"{F(FP - 6)}\" rx=\"4\" ry=\"2.4\" fill=\"#ffffff\" fill-opacity=\"0.8\"/>");
            return _flapSvg = s.Markup;
        }

        // the gold SPIN button in the middle (the menu's gold plaque, round); its word dimmed while it can't be pressed
        static string HubSvg(string label, bool live)
        {
            string key = label + live;
            if (_hubs.TryGetValue(key, out var m)) return m;
            float B = HUB + 8;
            var s = new UiSvg(B, B + 5);
            s.Def($"<linearGradient id=\"dsHubRim\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\">{Stops(RIM)}</linearGradient>");
            s.Def("<radialGradient id=\"dsHub\" cx=\"38%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#fff7c8\"/><stop offset=\"0.45\" stop-color=\"#ffd34e\"/><stop offset=\"1\" stop-color=\"#f09a1c\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(B / 2)}\" cy=\"{F(B / 2 + 5)}\" r=\"{F(B / 2)}\" fill=\"{BROWN}\"/>");
            s.Raw($"<circle cx=\"{F(B / 2)}\" cy=\"{F(B / 2)}\" r=\"{F(B / 2)}\" fill=\"{BROWN}\"/>");
            s.Raw($"<circle cx=\"{F(B / 2)}\" cy=\"{F(B / 2)}\" r=\"{F(B / 2 - 2.5f)}\" fill=\"url(#dsHubRim)\"/>");
            s.Raw($"<circle cx=\"{F(B / 2)}\" cy=\"{F(B / 2)}\" r=\"{F(B / 2 - 8)}\" fill=\"url(#dsHub)\" stroke=\"{BROWN}\" stroke-opacity=\"0.55\" stroke-width=\"1.5\"/>");
            s.Raw($"<ellipse cx=\"{F(B / 2)}\" cy=\"{F(B / 2 - 21)}\" rx=\"27\" ry=\"11\" fill=\"#ffffff\" fill-opacity=\"0.45\"/>");
            var (lw, lh) = LetteringSize(label, 25);
            if (!live) s.Open("opacity=\"0.75\"");
            Lettering(s, label, "whiteB", 25, (B - lw) / 2, (B - lh) / 2);
            if (!live) s.Close();
            return _hubs[key] = s.Markup;
        }
    }
}
