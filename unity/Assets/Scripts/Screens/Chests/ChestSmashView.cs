// Opening a chest: "Chest Smash v2" (src/components/ChestSmash.js and its page, android/app/src/main/assets/chest/
// host.html), as pure C#. The vault room (Resources/Chests/vault-room.jpg) with its two torches flickering and two
// banners in the group's colour; the chest (ChestEngine: its drawing and motion, the page's engine ported); over it the
// size and group, the chest's name, its HP pips; the hint ("Tap to smash…", "Keep tapping!", "Bursting open…",
// "Opened!"); the banners slamming in (RARE!, OPENED!); 1.7 s after the knock-out the reveal: the creature's card
// popping in (its picture bobbing, the shine sweeping), UPGRADED TO …, NEW SQUISHY! / +1 COPY / UNLOCKED! and the
// copies bar filling, the coins, the Lucky meter's note, COLLECT (OnCollect). The page's CSS animations are ported with
// their keyframes and timing functions.
// The server has rolled the chest: Start(group, size, null) puts it up while the answer is on its way (a first tap
// meanwhile is held), Fill(result) brings the roll; the first tap of a Common or Rare plays its upgrade when the server
// rolled one. The reveal's picture is the creature's still (the Stack cut-out, Roster.Picture), where the app shows its
// front art (export/tripo/<key>-front.svg). No sounds.
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class ChestSmashView : IScreenView
    {
        public readonly float W, H;
        readonly Ticker _t;
        public readonly ChestEngine S;
        public Action OnCollect;
        /// <summary>The scene has painted (ChestSmash.js onShown: the treasure vault plays its way out).</summary>
        public Action OnShown;

        static readonly (string n, string c, string ink)[] TN = { ("Common", "#8d7b6a", "#5a4636"), ("Rare", "#2f8cff", "#0e4aa8"), ("Epic", "#a24bf0", "#5a1a9a"), ("Legendary", "#f08c00", "#9a4a00"), ("Rainbow", "#e0459f", "#8a1a6a") };
        static readonly Dictionary<string, int> TI = new Dictionary<string, int> { ["common"] = 0, ["rare"] = 1, ["epic"] = 2, ["legendary"] = 3, ["set"] = 4, ["rainbow"] = 4 };
        static readonly Dictionary<string, (string name, string ban)> GROUPS = new Dictionary<string, (string, string)>
        {
            ["snack"] = ("Snack Shack", "#ffb59a"), ["fruit"] = ("Fruit Patch", "#c4eba4"), ["ocean"] = ("Ocean Pals", "#a8e2ff"), ["pet"] = ("Pet Shop", "#e6caff"),
            ["forest"] = ("Forest Friends", "#b8e0a0"), ["sky"] = ("Sky & Stars", "#b8c8ff"), ["dream"] = ("Dreamland", "#e2d2ff"), ["bakery"] = ("Sweet Bakery", "#bff0e2"),
            ["heroes"] = ("Masked Heroes", "#ffc2c2"), ["elemental"] = ("Elemental Heroes", "#c8ccf0"), ["spooky"] = ("Spooky Squish", "#d8c2f4"),
        };
        static readonly string[] RCARD = { "#e6f5ff", "#e2fbef", "#f1e6ff", "#fff0dc", "#ffe9f6" }, RLIP = { "#5a9ad2", "#38a878", "#8a5ae0", "#d08a20", "#d3179a" };
        public static readonly (string label, string bg, string ink)[] RAR_LOOK = { ("COMMON", "#d7f0ff", "#2f7fd6"), ("RARE", "#c9f7e1", "#16a86a"), ("EPIC", "#ead6ff", "#8f3cf2"), ("LEGENDARY", "#ffdcb0", "#d9772f"), ("RAINBOW", "#ffe0f3", "#d3179a") };

        /// <summary>What the reveal shows for the server's result (ChestSmash.js rewardOf).</summary>
        public sealed class Reward
        {
            public string Name = "", RarLabel = "", RarBg = "#ffffff", RarInk = "#45107a", Concept = "", Key;
            public int Rar;
            public bool IsNew, Luck;
            public double Copies, Need, Coins, DupeCoins, SetBonus;
            public static Reward Of(IDictionary<string, object> r)
            {
                ShopData.Ensure();
                var id = Prof.Get(r, "id");
                var c = id == null ? null : ShopData.ById.TryGetValue(Prof.IsNum(id) ? Prof.JsStr(Prof.D(id)) : id.ToString(), out var cc) ? cc : null;
                var R = c != null ? RAR_LOOK[Math.Min(4, c.Rar)] : default;
                return new Reward
                {
                    Name = c?.Name ?? "", Rar = c?.Rar ?? 0, RarLabel = c != null ? R.label : "", RarBg = c != null ? R.bg : "#ffffff", RarInk = c != null ? R.ink : "#45107a", Key = c?.Key,
                    IsNew = Prof.Truthy(Prof.Get(r, "isNew")), Copies = Prof.Num(Prof.Get(r, "copies")), Need = Prof.Num(Prof.Get(r, "need")), Coins = Prof.Num(Prof.Get(r, "coins")),
                    DupeCoins = Prof.Num(Prof.Get(r, "dupeCoins")), SetBonus = Prof.Num(Prof.Get(r, "setBonus")), Luck = Prof.Truthy(Prof.Get(r, "luck")),
                };
            }
        }

        // the page's state (host.html st)
        string _gk, _name = "", _phase;
        int _start, _final, _tier, _max = 1;
        double _hp;
        bool _first;
        Reward _reward;
        (float x, float y)? _held;
        double _last;
        bool _shownSent;

        public ChestSmashView(float w, float h, Ticker ticker, Func<double> random = null)
        {
            W = w; H = h; _t = ticker;
            S = new ChestEngine(w, h, 0.73, 178);
            if (random != null) S.Random = random;
            S.On = Ev;
        }

        /// <summary>chestHost.start: a chest on screen (`result` null: the server's answer is on its way, Fill brings it).</summary>
        public void Start(string group, string size, IDictionary<string, object> result)
        {
            _gk = GROUPS.ContainsKey(group ?? "") ? group : "ocean";
            _start = TI.TryGetValue(size ?? "", out var s0) ? s0 : 0;
            _final = Math.Max(_start, result != null && TI.TryGetValue(Prof.Str(Prof.Get(result, "final")) ?? "", out var f) ? f : _start);
            _tier = _start; _hp = 0; _max = 1; _name = ""; _phase = result == null ? "wait" : "idle"; _first = true; _reward = result != null ? Reward.Of(result) : null; _held = null;
            _banner = null; _reveal = -1; _bg = null; _pips.Clear();
            bool firstStart = S.Ch == null;
            if (firstStart) S.Load(_gk, _start, true); else S.Reset(_gk, _start);
            Paint();
            if (firstStart)
            {
                _last = _t.Now;
                void Loop() { _t.RequestAnimationFrame(() => { Loop(); double dt = Math.Min(0.034, Math.Max(0, (_t.Now - _last) / 1000)); _last = _t.Now; S.Tick(dt * S.Ts); _frame = S.Draw(); }); }
                Loop();
            }
            _t.RequestAnimationFrame(() => _t.RequestAnimationFrame(() => { if (!_shownSent) { _shownSent = true; OnShown?.Invoke(); } }));
        }

        /// <summary>chestHost.fill: the server's answer for the chest Start put up.</summary>
        public void Fill(IDictionary<string, object> result)
        {
            _final = Math.Max(_start, TI.TryGetValue(Prof.Str(Prof.Get(result, "final")) ?? "", out var f) ? f : _start);
            _reward = Reward.Of(result);
            if (_phase != "wait") return;
            _phase = "idle";
            var h = _held; _held = null;
            if (h != null) Tap(h.Value.x, h.Value.y); else Paint();
        }

        string _frame = "";

        void Ev(string type, Dictionary<string, object> e)
        {
            double N(string k) => e.TryGetValue(k, out var v) && v != null ? Convert.ToDouble(v) : 0;
            if (type == "loaded") { _tier = (int)N("tier"); _hp = N("hp"); _max = (int)N("max"); _name = (string)e["name"]; }
            else if (type == "hp") { _hp = N("hp"); _max = (int)N("max"); }
            else if (type == "step") { _tier = (int)N("tier"); _hp = N("hp"); _max = (int)N("max"); _name = (string)e["name"]; Banner(TN[_tier].n.ToUpperInvariant() + "!", _tier); }
            else if (type == "upgradeDone") _phase = "idle";
            else if (type == "koStart") _phase = "ko";
            else if (type == "ko")
            {
                _phase = "open"; Banner("OPENED!", (int)N("tier"));
                int k = ++_revealKey;
                _t.SetTimeout(() => { if (k == _revealKey) ShowReveal(); }, 1700);
            }
            Paint();
        }

        int _revealKey;

        // ---- the hint, the bottom's fade -------------------------------------------------------------------------------
        string _hint;
        double _hintAt, _bottomFrom = 1, _bottomTo = 1, _bottomAt;
        void Paint()
        {
            string idle = _first && _start <= 1 ? "Tap to smash. The first tap might upgrade it!" : "Keep tapping!";
            string h = _phase == "idle" || _phase == "wait" ? idle : _phase == "up" ? "Upgrading… tap to skip" : _phase == "ko" ? "Bursting open…" : _phase == "open" ? "Opened!" : "";
            if (h != _hint) { _hint = h; _hintAt = _t.Now; }
            double to = _phase == "ko" || _phase == "open" ? 0.4 : 1;
            if (to != _bottomTo) { _bottomFrom = BottomOpacity(); _bottomTo = to; _bottomAt = _t.Now; }
        }
        double BottomOpacity() { double k = Math.Min(1, (_t.Now - _bottomAt) / 300); return _bottomFrom + (_bottomTo - _bottomFrom) * Ease(k); }

        static readonly Func<double, double> Ease = Easing.Bezier(0.25, 0.1, 0.25, 1), EaseOut = Easing.Bezier(0, 0, 0.58, 1), EaseInOut = Easing.Bezier(0.42, 0, 0.58, 1), Pop = Easing.Bezier(0.2, 0.9, 0.3, 1.2);

        /// <summary>A CSS keyframe animation's value at `ms` (keyframes: offsets and values; the timing function per segment).</summary>
        static double Kf(double ms, double dur, double delay, double[] at, double[] v, Func<double, double> tf, bool loop = false)
        {
            double t = ms - delay;
            if (t < 0) return v[0];
            double p = loop ? (t % dur) / dur : Math.Min(1, t / dur);
            int i = 1;
            while (i < at.Length - 1 && p > at[i]) i++;
            double k = (p - at[i - 1]) / Math.Max(1e-9, at[i] - at[i - 1]);
            return v[i - 1] + (v[i] - v[i - 1]) * tf(Math.Max(0, Math.Min(1, k)));
        }

        // ---- the banners -----------------------------------------------------------------------------------------------
        (string text, int tier, double at)? _banner;
        int _bannerKey;
        void Banner(string text, int tier)
        {
            _banner = (text, tier, _t.Now);
            int k = ++_bannerKey;
            _t.SetTimeout(() => { if (k == _bannerKey) _banner = null; }, 1500);
        }

        // ---- the reveal ------------------------------------------------------------------------------------------------
        double _reveal = -1;
        void ShowReveal() => _reveal = _t.Now;

        // ---- the pointer -----------------------------------------------------------------------------------------------
        public void Down(float x, float y)
        {
            if (_reveal >= 0) { _collectDown = InCollect(x, y); return; }
            Tap(x, y);
        }
        public void Move(float x, float y) { }
        public void Up(float x, float y)
        {
            if (_reveal >= 0 && _collectDown && InCollect(x, y) && _t.Now - _reveal > 700) { _collectDown = false; OnCollect?.Invoke(); }
            _collectDown = false;
        }
        bool _collectDown;
        bool InCollect(float x, float y) => _reveal >= 0 && _collectBox.Contains(x, y);
        Frame _collectBox;

        void Tap(float x, float y)
        {
            if (_phase == "wait") { _held ??= (x, y); return; }
            if (_phase == "up") { S.SkipUp(); return; }
            if (_phase != "idle") return;
            if (_first)
            {
                _first = false;
                if (_final > _tier) { _phase = "up"; Paint(); S.Upgrade(_final); return; }
            }
            S.HitAt(x, y, 1);
            Paint();
        }

        // ---- pieces --------------------------------------------------------------------------------------------------------
        string _bg;
        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            double now = _t.Now;
            if (_bg == null)
            {
                var b = new UiSvg(W, H);
                b.Box(0, 0, W, H, new BoxStyle { Background = "#22160e" });
                // the room "center bottom / cover", and the warm light where the chest stands (circle at 50% 66%, 30%)
                float k = Math.Max(W / 2340f, H / 1080f), iw = 2340 * k, ih = 1080 * k;
                b.Image("Chests/vault-room", (W - iw) / 2, H - ih, iw, ih);
                float cx = W / 2, cy = H * 0.66f, far = (float)Math.Sqrt(Math.Max(cx, W - cx) * Math.Max(cx, W - cx) + Math.Max(cy, H - cy) * Math.Max(cy, H - cy));
                var g = b.NewId("lt");
                b.Def($"<radialGradient id=\"{g}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(cx)}\" cy=\"{F(cy)}\" r=\"{F(far)}\"><stop offset=\"0\" stop-color=\"rgba(255,226,160,0.3)\"/><stop offset=\"0.3\" stop-color=\"rgba(255,226,160,0)\"/></radialGradient>");
                b.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(W)}\" height=\"{F(H)}\" fill=\"url(#{g})\"/>");
                Banners(b);
                _bg = b.Markup;
            }
            list.Add(Piece("room", _bg, W, H, 0, 0, 1, null, 0));
            Torch(list, "torch-l", 0.20f, now);
            Torch(list, "torch-r", 0.80f, now + 700);
            list.Add(Piece("chest", $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(W)}\" height=\"{F(H)}\" viewBox=\"0 0 {F(W)} {F(H)}\" overflow=\"visible\">{_frame}</svg>", W, H, 0, 0, 1, null, 0));
            Top(list);
            if (_banner != null) BannerPiece(list, now);
            Hint(list, now);
            if (_reveal >= 0) Reveal(list, now - _reveal);
            return list;
        }

        void Banners(UiSvg b)
        {
            string col = GROUPS[_gk ?? "ocean"].ban;
            foreach (float lx in new[] { 0.265f, 0.735f })
            {
                float w = W * 0.048f, h = H * 0.33f, x = W * lx - W * 0.024f, y = H * 0.05f;
                float iy = y + 4, ih = h - 4;
                var clip = b.NewId("bn");
                b.Def($"<clipPath id=\"{clip}\"><path d=\"M{F(x)} {F(iy)} L{F(x + w)} {F(iy)} L{F(x + w)} {F(iy + ih)} L{F(x + w / 2)} {F(iy + ih * 0.84f)} L{F(x)} {F(iy + ih)} Z\"/></clipPath>");
                b.Open($"clip-path=\"url(#{clip})\"");
                b.Box(x, iy, w, ih, new BoxStyle { Background = col });
                b.Box(x, iy, w, ih, new BoxStyle { Gradient = new[] { "rgba(0,0,0,0.18)", "rgba(255,255,255,0.12)", "rgba(0,0,0,0.22)" }, GradientStops = new[] { 0f, 0.45f, 1 }, GradientAngle = 90 });
                b.Box(x, iy, 4, ih, new BoxStyle { Background = "#e8b84a" });
                b.Box(x + w - 4, iy, 4, ih, new BoxStyle { Background = "#e8b84a" });
                b.Close();
                float rx = x - w * 0.18f, rw = w * 1.36f;
                b.Box(rx - 1.5f, y - 1.5f, rw + 3, 10, new BoxStyle { Radius = 5.5f, Background = "#2a1a10" });
                b.Box(rx, y, rw, 7, new BoxStyle { Radius = 4, Background = "#8a5a32" });
            }
        }

        void Torch(List<ScreenPiece> list, string id, float lx, double ms)
        {
            // vFlick 1.6 s ease-in-out: opacity 0.7 → 1 (30 %) → 0.8 (55 %) → 0.95 (80 %) → 0.7; scale 1 → 1.08 → 0.95 → 1.04 → 1
            var at = new[] { 0, 0.3, 0.55, 0.8, 1 };
            double op = Kf(ms, 1600, 0, at, new[] { 0.7, 1, 0.8, 0.95, 0.7 }, EaseInOut, true), sc = Kf(ms, 1600, 0, at, new[] { 1, 1.08, 0.95, 1.04, 1 }, EaseInOut, true);
            float d = W * 0.15f, x = W * lx - W * 0.075f, y = H * 0.226f - W * 0.075f;
            var s = new UiSvg(d, d);
            var g = s.NewId("tg");
            s.Def($"<radialGradient id=\"{g}\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"rgba(255,214,120,0.5)\"/><stop offset=\"0.55\" stop-color=\"rgba(255,160,60,0.18)\"/><stop offset=\"1\" stop-color=\"rgba(255,160,60,0)\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(d / 2)}\" cy=\"{F(d / 2)}\" r=\"{F(d / 2)}\" fill=\"url(#{g})\"/>");
            list.Add(Piece(id, s, x, y, (float)op, About(d, d, Affine.ScaleBy(sc, sc)), 0));
        }

        static readonly TextStyle TierT0 = T(Black, 12, "#000", 1.4f), HpT = T(Black, 11, "#5b3418");
        static TextStyle NameT => T(Kit.Display, 24, "#ffffff", 0, 25.2f, Ring("#5b3418", 1.5f, 1.2f, 3));
        static Shadow[] Ring(string c, float a, float d, float down) => new[] { new Shadow(c, a, 0, 0), new Shadow(c, -a, 0, 0), new Shadow(c, 0, a, 0), new Shadow(c, 0, -a, 0), new Shadow(c, d, d, 0), new Shadow(c, -d, -d, 0), new Shadow(c, d, -d, 0), new Shadow(c, -d, d, 0), new Shadow(c, 0, down, 0) };

        void Top(List<ScreenPiece> list)
        {
            var T0 = TN[Math.Min(4, _tier)];
            string label = $"{GROUPS[_gk].name.ToUpperInvariant()} · {T0.n.ToUpperInvariant()}";
            var tt = T(Black, 12, T0.c, 1.4f);
            float tw = W(label, tt) + 28, th = LH(tt) + 8;
            var s = new UiSvg(W, 110);
            s.Box(W / 2 - tw / 2, 12, tw, th, new BoxStyle { Radius = 999, Background = "#ffffff", Shadows = new[] { new Shadow("rgba(60,30,10,0.25)", 0, 3, 0) } });
            s.Text(label, W / 2 - tw / 2 + 14, 12 + 4, tt);
            float y = 12 + th + 5;
            var nt = NameT;
            if (_name != "") TxtC(s, _name, W / 2, y, nt);
            y += 25.2f + 5;
            float bx = W / 2 - 150;
            s.Box(bx, y, 300, 33, new BoxStyle { Radius = 999, Background = "rgba(50,28,12,0.55)", BorderWidth = 2, BorderColor = "rgba(255,255,255,0.7)" });
            string hp = $"{Prof.JsStr(_hp)} HP";
            float hw = W(hp, HpT) + 16, hh = LH(HpT) + 4;
            float px = bx + 2 + 8, pw = 300 - 4 - 8 - 6 - 8 - hw, py = y + 2 + 5 + (19 - 13) / 2f;
            int max = Math.Max(1, _max);
            float one = (pw - 3 * (max - 1)) / max;
            for (int i = 0; i < max; i++)
            {
                bool on = i < _hp;
                float x = px + i * (one + 3);
                var clip = s.NewId("pp");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x, py, one, 13, new[] { 6.5f, 6.5f, 6.5f, 6.5f })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Box(x, py, one, 13, new BoxStyle { Background = PipColor(i, on) });
                s.Box(x, py + 10, one, 3, new BoxStyle { Background = on ? "#3aa83a" : "rgba(0,0,0,0.15)" });
                s.Box(x, py, one, 2, new BoxStyle { Background = "rgba(255,255,255,0.55)" });
                s.Close();
            }
            float hx = bx + 300 - 2 - 6 - hw;
            s.Box(hx, y + 2 + (29 - hh) / 2, hw, hh, new BoxStyle { Radius = 999, Background = "#ffffff" });
            s.Text(hp, hx + 8, y + 2 + (29 - hh) / 2 + 2, HpT);
            list.Add(Piece("top", s, 0, 0, 1, null, 6));
        }

        // the pips' `transition: background 0.2s` (ease), in premultiplied colour as CSS does
        readonly Dictionary<int, (bool on, double at)> _pips = new Dictionary<int, (bool, double)>();
        string PipColor(int i, bool on)
        {
            const string ON = "#7ee87a", OFF = "rgba(255,255,255,0.25)";
            if (!_pips.TryGetValue(i, out var st)) { _pips[i] = (on, -1e9); return on ? ON : OFF; }
            if (st.on != on) { _pips[i] = st = (on, _t.Now); }
            double k = Ease(Math.Min(1, Math.Max(0, (_t.Now - st.at) / 200)));
            if (k >= 1) return on ? ON : OFF;
            var a = Canvas2D.Rgba(on ? OFF : ON); var b = Canvas2D.Rgba(on ? ON : OFF);
            double al = a.a + (b.a - a.a) * k;
            double C(double x, double y) => al <= 0 ? 0 : (x * a.a + (y * b.a - x * a.a) * k) / al;
            return $"rgba({Math.Round(C(a.r, b.r))},{Math.Round(C(a.g, b.g))},{Math.Round(C(a.b, b.b))},{al.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture)})";
        }

        static void TxtC(UiSvg s, string text, float cx, float y, TextStyle t) => s.Text(text, cx - Kit.W(text, t) / 2, y, t);

        void BannerPiece(List<ScreenPiece> list, double now)
        {
            var (text, tier, at) = _banner.Value;
            double ms = now - at;
            var kat = new[] { 0, 0.4, 0.65, 1 };
            double sc = Kf(ms, 600, 0, kat, new[] { 2.6, 0.92, 1.06, 1 }, Pop), rot = Kf(ms, 600, 0, kat, new[] { -8.0, 2, -1, 0 }, Pop), op = Kf(ms, 600, 0, kat, new[] { 0.0, 1, 1, 1 }, Pop);
            string ink = TN[tier].ink, glow = TN[tier].c;
            var sh = new List<Shadow> { new Shadow(ink, 3, 0, 0), new Shadow(ink, -3, 0, 0), new Shadow(ink, 0, 3, 0), new Shadow(ink, 0, -3, 0), new Shadow(ink, 2.4f, 2.4f, 0), new Shadow(ink, -2.4f, -2.4f, 0), new Shadow(ink, 2.4f, -2.4f, 0), new Shadow(ink, -2.4f, 2.4f, 0), new Shadow(ink, 0, 7, 0), new Shadow(ink, 0, 0, 28), new Shadow(glow, 0, 0, 54) };
            var bt = T(Kit.Display, 50, "#ffffff", 1, 50, sh.ToArray());
            float w = Kit.W(text, bt);
            var s = new UiSvg(w, 50);
            s.Text(text, 0, 0, bt);
            list.Add(Piece("banner", s, W / 2 - w / 2, H * 0.24f, (float)Math.Max(0, Math.Min(1, op)), About(w, 50, Affine.Rotate(rot) * Affine.ScaleBy(sc, sc)), 70));
        }

        void Hint(List<ScreenPiece> list, double now)
        {
            if (string.IsNullOrEmpty(_hint)) return;
            var ht = T(Black, 14, "#5b3418");
            float w = Kit.W(_hint, ht) + 36, h = LH(ht) + 16;
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.94)", Shadows = new[] { new Shadow("rgba(90,40,10,0.25)", 0, 3, 0) } });
            s.Text(_hint, 18, 8, ht);
            double k = Math.Min(1, (now - _hintAt) / 300), e = EaseOut(k);
            float op = (float)(e * BottomOpacity());
            list.Add(Piece("hint", s, W / 2 - w / 2, H - 14 - h + (float)(10 * (1 - e)), op, null, 6));
        }

        // c2Rise (opacity 0 → 1, translateY 10 → 0, ease-out) of `dur` after `delay`
        static (float op, float dy) Rise(double ms, double dur, double delay)
        {
            double k = Math.Max(0, Math.Min(1, (ms - delay) / dur)), e = EaseOut(k);
            return ((float)e, (float)(10 * (1 - e)));
        }

        void Reveal(List<ScreenPiece> list, double ms)
        {
            var rw = _reward ?? new Reward();
            var T0 = TN[Math.Min(4, _tier)];
            double fade = EaseOut(Math.Min(1, ms / 300));
            var bg = new UiSvg(W, H);
            float cx = W / 2, cy = H * 0.42f, far = (float)Math.Sqrt(Math.Max(cx, W - cx) * Math.Max(cx, W - cx) + Math.Max(cy, H - cy) * Math.Max(cy, H - cy));
            var g = bg.NewId("rv");
            bg.Def($"<radialGradient id=\"{g}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(cx)}\" cy=\"{F(cy)}\" r=\"{F(far)}\"><stop offset=\"0\" stop-color=\"rgba(255,184,90,0.5)\"/><stop offset=\"0.7\" stop-color=\"rgba(34,22,14,0.92)\"/></radialGradient>");
            bg.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(W)}\" height=\"{F(H)}\" fill=\"url(#{g})\"/>");
            // the right column's rows (display: none ones keep their gaps)
            bool up = _tier > _start, copy = !rw.IsNew && rw.Copies > 0, counted = rw.Need > 1 && (copy || rw.IsNew);
            double coins = rw.Coins + rw.DupeCoins + rw.SetBonus;
            var upT = T(Black, 12, T0.c, 1); var newT = T(Kit.Display, 18, "#ffffff", 1); var noteT = T(Black, 13, "#ffe27a"); var pityT = T(Black, 13, "#ffe27a");
            float upH = up ? LH(upT) + 8 : 0, newH = rw.IsNew || copy ? LH(newT) + 10 + 6 : 0, cpH = counted ? 26 + 5 + LH(noteT) : 0, lootH = coins > 0 ? 32 + 3 : 0, pityH = rw.Luck ? LH(pityT) : 0, colH = 64 + 6;
            float[] rows = { upH, newH, cpH, lootH, pityH, colH };
            // the card
            var rarT = T(Black, 12, rw.RarInk, 1); var nameT = T(Kit.Display, 26, "#5b3418", 0, 26); var conT = T(Body, 12.5f, "#6a4a9a");
            bool has = rw.Name != "";
            float cardH = 4 + 12 + 168 + 6 + (LH(rarT) + 6) + 6 + 26 + 6 + (rw.Concept != "" ? LH(conT) : 0) + 14 + 4;
            float sum = rows.Sum() + 50;
            int empty = rows.Count(r => r == 0);
            float extra = Math.Max(0, cardH - sum) / Math.Max(1, empty);
            float gridH = Math.Max(cardH, sum), y0 = (H - gridH) / 2, x0 = (W - (232 + 44 + 300)) / 2;
            var rowY = new float[6];
            float yy = y0;
            for (int i = 0; i < 6; i++) { rowY[i] = yy; yy += (rows[i] == 0 ? extra : rows[i]) + 10; }
            list.Add(Piece("reveal-bg", bg, 0, 0, (float)fade, null, 0));
            // the rays turning behind the card: absolutely placed in grid-column 1 (its end `auto`: the grid's right edge)
            // and rows 1-6, at left 50 %, top 40 % of that
            float rcx = x0 + (W - x0) * 0.5f, rcy = y0 + gridH * 0.4f;
            var rays = new UiSvg(820, 820);
            var mk = rays.NewId("rm");
            rays.Def($"<radialGradient id=\"{mk}g\" gradientUnits=\"userSpaceOnUse\" cx=\"410\" cy=\"410\" r=\"{F(410 * Math.Sqrt(2))}\"><stop offset=\"0.15\" stop-color=\"#fff\"/><stop offset=\"0.62\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient><mask id=\"{mk}\"><rect x=\"0\" y=\"0\" width=\"820\" height=\"820\" fill=\"url(#{mk}g)\"/></mask>");
            var d = new System.Text.StringBuilder();
            for (int i = 0; i < 18; i++)
            {
                double a0 = (i * 20 - 90) * Math.PI / 180, a1 = (i * 20 + 8 - 90) * Math.PI / 180, R = 600;
                d.Append($"M410 410 L{F(410 + R * Math.Cos(a0))} {F(410 + R * Math.Sin(a0))} L{F(410 + R * Math.Cos(a1))} {F(410 + R * Math.Sin(a1))} Z ");
            }
            var rc = rays.NewId("rc");
            rays.Def($"<clipPath id=\"{rc}\"><circle cx=\"410\" cy=\"410\" r=\"410\"/></clipPath>");
            rays.Raw($"<g mask=\"url(#{mk})\" clip-path=\"url(#{rc})\"><path d=\"{d}\" fill=\"rgba(255,230,140,0.32)\"/></g>");
            list.Add(Piece("rays", rays, rcx - 410, rcy - 410, (float)fade, About(820, 820, Affine.Rotate(ms / 14000 * 360 % 360)), 0));
            // the card: c2Card 0.6 s (scale 0.2 → 1.08 → 1, rotate -14 → 3 → 0)
            var cat = new[] { 0, 0.55, 1 };
            double sc = Kf(ms, 600, 0, cat, new[] { 0.2, 1.08, 1 }, Pop), rot = Kf(ms, 600, 0, cat, new[] { -14.0, 3, 0 }, Pop), cop = Kf(ms, 600, 0, cat, new[] { 0.0, 1, 1 }, Pop);
            float cyc = y0 + (gridH - cardH) / 2;
            var card = new UiSvg(232, cardH);
            string lip = has ? RLIP[Math.Min(4, rw.Rar)] : "#8e1580";
            card.Box(0, 0, 232, cardH, new BoxStyle { Radius = 30, Background = has ? RCARD[Math.Min(4, rw.Rar)] : "#ffffff", Shadows = new[] { new Shadow(lip, 0, 0, 0, 3), new Shadow(lip, 0, 8, 0, 3), new Shadow("rgba(255,220,120,0.45)", 0, 0, 50, 10) } });
            // the shine sweeping (c2Shine 2.6 s after 0.6 s: -120 % → 220 % by 60 %, skewed)
            var cl = card.NewId("cs");
            card.Def($"<clipPath id=\"{cl}\"><path d=\"{UiSvg.RRect(4, 4, 224, cardH - 8, new[] { 26f, 26, 26, 26 })}\"/></clipPath>");
            double sx = Kf(ms, 2600, 600, new[] { 0, 0.6, 1 }, new[] { -1.2, 2.2, 2.2 }, EaseInOut, true);
            if (ms < 600) sx = -1.2;
            float sw = 224 * 0.4f;
            card.Open($"clip-path=\"url(#{cl})\"");
            card.Raw($"<g transform=\"translate({F(4 + sx * sw)} 4) skewX(-20)\"><rect x=\"0\" y=\"0\" width=\"{F(sw)}\" height=\"{F(cardH - 8)}\" fill=\"url(#{cl}g)\"/></g>");
            card.Def($"<linearGradient id=\"{cl}g\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"rgba(255,255,255,0)\"/><stop offset=\"0.5\" stop-color=\"rgba(255,255,255,0.65)\"/><stop offset=\"1\" stop-color=\"rgba(255,255,255,0)\"/></linearGradient>");
            card.Close();
            card.Box(0, 0, 232, cardH, new BoxStyle { Radius = 30, BorderWidth = 4, BorderColor = "#ffffff" });
            double bob = Kf(ms, 2400, 0, new[] { 0, 0.5, 1 }, new[] { 0.0, -5, 0 }, EaseInOut, true);
            if (rw.Key != null) ShopView.CreaturePicPublic(card, rw.Key, 32, 16 + (float)bob, 168);
            float ry = 16 + 168 + 6;
            string rar = has ? rw.RarLabel : GROUPS[_gk].name.ToUpperInvariant();
            var rt = T(Black, 12, has ? rw.RarInk : "#5b3418", 1);
            float rwid = Kit.W(rar, rt) + 24;
            card.Box(116 - rwid / 2, ry, rwid, LH(rt) + 6, new BoxStyle { Radius = 999, Background = has ? rw.RarBg : "#ffffff" });
            card.Text(rar, 116 - rwid / 2 + 12, ry + 3, rt);
            ry += LH(rt) + 6 + 6;
            TxtC(card, has ? rw.Name : "Loot!", 116, ry, nameT);
            var cm = Affine.Translate(x0, cyc) * About(232, cardH, Affine.Rotate(rot) * Affine.ScaleBy(sc, sc));
            list.Add(new ScreenPiece { Id = "card", Svg = card.Markup, W = 232, H = cardH, Opacity = (float)Math.Max(0, Math.Min(1, cop)), Margin = 70, Transform = cm });
            // the right column
            float rx = x0 + 232 + 44;
            if (up)
            {
                var (o, dy) = Rise(ms, 400, 250);
                string ut = "UPGRADED TO " + T0.n.ToUpperInvariant() + "!";
                float uw = Kit.W(ut, upT) + 28;
                var u = new UiSvg(uw, upH);
                u.Box(0, 0, uw, upH, new BoxStyle { Radius = 999, Background = "#ffffff" });
                u.Text(ut, 14, 4, upT);
                list.Add(Piece("rvUp", u, rx + 150 - uw / 2, rowY[0] + dy, o));
            }
            if (rw.IsNew || copy)
            {
                var (o, dy) = Rise(ms, 400, 350);
                string nt = copy ? "+1 COPY" : counted ? "UNLOCKED!" : "NEW SQUISHY!";
                float nw = Kit.W(nt, newT) + 32 + 6;
                var n = new UiSvg(nw, newH - 3);
                n.Box(0, 0, nw, newH - 3, new BoxStyle { Radius = 999, Gradient = copy ? new[] { "#d9b8ff", "#8f3cf2" } : new[] { "#ff8f8f", "#e01e4a" }, BorderWidth = 3, BorderColor = "#ffffff", Shadows = new[] { new Shadow(copy ? "#45189a" : "#8e1030", 0, 3, 0) } });
                n.Text(nt, 19, 8, newT);
                list.Add(Piece("rvNew", n, rx + 150 - nw / 2, rowY[1] + dy, o));
            }
            if (counted)
            {
                var (o, dy) = Rise(ms, 400, 450);
                double nn = Math.Min(rw.Copies, rw.Need);
                bool full = nn >= rw.Need;
                double p0 = Math.Round((nn - 1) / rw.Need * 1000) / 10, p1 = Math.Round(nn / rw.Need * 1000) / 10;
                double pk = ms < 900 ? 0 : Pop(Math.Min(1, (ms - 900) / 800));
                double pct = p0 + (p1 - p0) * pk;
                var c = new UiSvg(280, cpH);
                c.Box(0, 0, 280, 26, new BoxStyle { Radius = 13, Background = "rgba(255,255,255,0.2)", Shadows = new[] { new Shadow("rgba(40,22,10,0.45)", 0, 4, 0) } });
                var fc = c.NewId("cf");
                c.Def($"<clipPath id=\"{fc}\"><path d=\"{UiSvg.RRect(3, 3, 274, 20, new[] { 10f, 10, 10, 10 })}\"/></clipPath>");
                c.Open($"clip-path=\"url(#{fc})\"");
                float fw = (float)(274 * pct / 100);
                if (fw > 0)
                {
                    c.Box(3, 3, fw, 20, new BoxStyle { Radius = 13, Gradient = full ? new[] { "#d8ffc2", "#6fe07a", "#26a94e" } : new[] { "#ffd6f4", "#ff5cc6", "#c02bd9" }, GradientStops = full ? new[] { 0f, 0.55f, 1 } : new[] { 0f, 0.45f, 1 } });
                    c.Box(3, 3, fw, 2, new BoxStyle { Background = "rgba(255,255,255,0.6)" });
                }
                c.Close();
                c.Box(0, 0, 280, 26, new BoxStyle { Radius = 13, BorderWidth = 3, BorderColor = "#ffffff" });
                var ct = T(Kit.Display, 14, "#ffffff", 0.8f, 0, new[] { new Shadow("#5b3418", 0, 1.5f, 0), new Shadow("#5b3418", 1, 0, 0), new Shadow("#5b3418", -1, 0, 0), new Shadow("#5b3418", 0, -1, 0) });
                string txt = $"{Prof.JsStr(nn)} / {Prof.JsStr(rw.Need)}";
                TxtC(c, txt, 140, (26 - LH(ct)) / 2, ct);
                double left = rw.Need - nn;
                string note = left > 0 ? $"Find {Prof.JsStr(left)} more to unlock {rw.Name}!" : $"{rw.Name} joins your squad!";
                TxtC(c, note, 140, 31, noteT);
                list.Add(Piece("rvCopies", c, rx + 10, rowY[2] + dy, o));
            }
            if (coins > 0)
            {
                var (o, dy) = Rise(ms, 400, 500);
                var lt = T(Kit.Display, 18, "#b86200");
                string ctext = "+" + Prof.Fmt(coins);
                float lw = 8 + 20 + 6 + Kit.W(ctext, lt) + 14;
                var l = new UiSvg(lw, 32);
                l.Box(0, 0, lw, 32, new BoxStyle { Radius = 999, Background = "#ffffff", Shadows = new[] { new Shadow("#a04a00", 0, 0, 0, 2), new Shadow("#a04a00", 0, 3, 0, 2) } });
                l.Box(8, 6, 20, 20, new BoxStyle { Radius = 10, Gradient = new[] { "#fff6a8", "#ffd83a", "#ffb000", "#f08c00" }, BorderWidth = 2, BorderColor = "#ffffff" });
                l.Text(ctext, 34, (32 - LH(lt)) / 2, lt);
                list.Add(Piece("loot", l, rx + 150 - lw / 2, rowY[3] + dy, o));
            }
            if (rw.Luck)
            {
                var (o, dy) = Rise(ms, 400, 0);
                string pt = "Lucky meter paid out: guaranteed Epic or better!";
                var p = new UiSvg(Kit.W(pt, pityT), LH(pityT));
                p.Text(pt, 0, 0, pityT);
                list.Add(Piece("rvPity", p, rx + 150 - p.W / 2, rowY[4] + dy, o));
            }
            {
                var (o, dy) = Rise(ms, 400, 700);
                var b = new UiSvg(230, 64);
                b.Box(0, 0, 230, 64, new BoxStyle { Radius = 24, Gradient = new[] { "#d8ffc2", "#6fe07a", "#26a94e" }, GradientStops = new[] { 0f, 0.55f, 1 }, BorderWidth = 3, BorderColor = "#ffffff", Shadows = new[] { new Shadow("#17652f", 0, 0, 0, 2.5f), new Shadow("#17652f", 0, 6, 0, 2.5f), new Shadow("rgba(20,80,40,0.35)", 0, 12, 20) } });
                var ctt = T(Kit.Display, 26, "#ffffff", 1, 0, new[] { new Shadow("#17652f", 0, 2.5f, 0), new Shadow("#17652f", 2, 0, 0), new Shadow("#17652f", -2, 0, 0) });
                TxtC(b, "COLLECT", 115, (64 - LH(ctt)) / 2, ctt);
                float by = rowY[5] + 6 + (_collectDown ? 4 : 0);
                list.Add(Piece("collect", b, rx + 35, by + dy, o, null, 30));
                _collectBox = new Frame(rx + 35, rowY[5] + 6, 230, 64);
            }
        }
    }
}
