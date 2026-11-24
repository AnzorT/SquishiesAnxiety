// Opening a chest: "Chest Smash v2" (src/components/ChestSmash.js and its page, android/app/src/main/assets/chest/
// host.html), as pure C#, sideways (REDESIGN_V7: the whole app is; the page's portrait layout isn't ported).
// - The vault room of the chest's group (REDESIGN_V9, 2026-11-16: Resources/Chests/vault/<group>.jpg, its #vault box:
//   it covers the screen from the bottom middle), the twinkles popping on its treasure (#vault .tw, vTw; the spots in
//   vault/spots.json). No lanterns, no banners (2026-11-21, the user: "take out the 2 lamps and the two flags").
// - The chest (ChestEngine: its drawing and motion, the page's engine ported; fitStage: 1.5x bigger sideways, BIG
//   2026-11-21; rarityHp: 15 / 20 / 30 / 40 / 50 HP by rarity, 2026-11-17).
// - The HUD in the app's look: the cream tier chip, the chest's name in the gold lettering, the HP meter as the vault
//   lock's wood plate (a brass padlock on its left end that shakes when hit and opens when the chest bursts, five gold
//   bars draining); the banners slamming in (RARE!, OPENED!); the hint pill ("Tap to smash…", "Keep tapping!",
//   "Bursting open…", "Opened!").
// - 1.7 s after the knock-out the reveal (2026-11-17, the user: "display them with the new card designs + the +1 copy,
//   the progress bar and the collect need their designs updated"): the cards v6 card in the middle (the rarity's frame,
//   the group's background, the creature's still, its name in its rarity's lettering), its rarity chip and concept line
//   under it; on the left UPGRADED TO …, +1 COPY / NEW SQUISHY! / UNLOCKED! in gold lettering on a wood plaque, the
//   copies bar (the lock's wood plate, the creature's head, a gold fill), the coins, the Lucky meter's note; on the
//   right COLLECT, the app's gold button (OnCollect).
// - THE UNLOCK (2026-11-17, the user: "after we reach the number of cards we need to receive the character i [want]
//   there to be an animation where all the cards come together and them bam comes out the character"): the copy that
//   unlocks its creature opens the reveal on its copies fanning out into a ring round a count, the new one flying up
//   from the chest, the ring spinning in white-hot into one shaking stack, BAM (a flash, shockwaves, sparks) and the
//   creature popping out, then UNLOCKED!, the full bar and COLLECT. The app brings the creature out as its live rig;
//   here it's its still (HeroRig says where the live one would stand).
// The page's CSS animations and transitions are ported with their keyframes and timing functions, each started when
// the page's would be: at the end of the frame that set it off (where Chrome picks up the style change).
// The server has rolled the chest: Start(group, size, null) puts it up while the answer is on its way (a first tap
// meanwhile is held), Fill(result) brings the roll; the first tap of a Common or Rare plays its upgrade when the server
// rolled one. The creature's pictures are its stills in the app's default border look (src/squad/looks.js: Resources/
// Chests/look, tools/unity/export-chest.mjs; the Stack cut-out for the two creatures with no look). Sounds: the
// reveal's sparkle and the collect's coin shower (the box's own hit sounds and the unlock's, synthesized in the app's
// page, aren't ported).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Backend;
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
        // the page's Math.random: the engine's, the twinkles' and the unlock's, rolled in the page's order
        Func<double> Rnd => S.Random;

        static readonly (string n, string c, string ink)[] TN = { ("Common", "#8d7b6a", "#5a4636"), ("Rare", "#2f8cff", "#0e4aa8"), ("Epic", "#a24bf0", "#5a1a9a"), ("Legendary", "#f08c00", "#9a4a00"), ("Rainbow", "#e0459f", "#8a1a6a") };
        static readonly Dictionary<string, int> TI = new Dictionary<string, int> { ["common"] = 0, ["rare"] = 1, ["epic"] = 2, ["legendary"] = 3, ["set"] = 4, ["rainbow"] = 4 };
        // THE CHEST HP, by rarity, the same in every group (the user, 2026-11-17): one tap = 1 HP
        static readonly double[] HP = { 15, 20, 30, 40, 50 };
        static readonly Dictionary<string, string> GROUPS = new Dictionary<string, string>
        {
            ["snack"] = "Snack Shack", ["fruit"] = "Fruit Patch", ["ocean"] = "Ocean Pals", ["pet"] = "Pet Shop", ["forest"] = "Forest Friends", ["sky"] = "Sky & Stars",
            ["dream"] = "Dreamland", ["bakery"] = "Sweet Bakery", ["heroes"] = "Masked Heroes", ["elemental"] = "Elemental Heroes", ["spooky"] = "Spooky Squish",
        };
        public static readonly (string label, string bg, string ink)[] RAR_LOOK = { ("COMMON", "#d7f0ff", "#2f7fd6"), ("RARE", "#c9f7e1", "#16a86a"), ("EPIC", "#ead6ff", "#8f3cf2"), ("LEGENDARY", "#ffdcb0", "#d9772f"), ("RAINBOW", "#ffe0f3", "#d3179a") };

        /// <summary>What the reveal shows for the server's result (ChestSmash.js rewardOf).</summary>
        public sealed class Reward
        {
            public string Name = "", RarLabel = "", RarBg = "#ffffff", RarInk = "#45107a", Concept = "", Key, Set;
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
                    Name = c?.Name ?? "", Rar = c?.Rar ?? 0, RarLabel = c != null ? R.label : "", RarBg = c != null ? R.bg : "#ffffff", RarInk = c != null ? R.ink : "#45107a", Key = c?.Key, Set = c?.Set,
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
            S = new ChestEngine(w, h, 0.73, 178) { TierHp = HP };
            if (random != null) S.Random = random;
            // (sized for the HUD as it stands once painted: the page's stage measures it again after the first paint)
            S.Resize(w, h, HudBottom());
            S.On = Ev;
        }

        /// <summary>chestHost.start: a chest on screen (`result` null: the server's answer is on its way, Fill brings it).</summary>
        public void Start(string group, string size, IDictionary<string, object> result)
        {
            _gk = GROUPS.ContainsKey(group ?? "") ? group : "ocean";
            _start = TI.TryGetValue(size ?? "", out var s0) ? s0 : 0;
            _final = Math.Max(_start, result != null && TI.TryGetValue(Prof.Str(Prof.Get(result, "final")) ?? "", out var f) ? f : _start);
            _tier = _start; _hp = 0; _max = 1; _name = ""; _phase = result == null ? "wait" : "idle"; _first = true; _reward = result != null ? Reward.Of(result) : null; _held = null;
            _banner = null; _reveal = -1; _revealAt = -1; _revealKey++; _mg = null; _room = null; _pipW.Clear(); _lockHit = -1e9; _lockOpen = (false, -1e9); _fill = default;
            bool firstStart = S.Ch == null;
            if (firstStart) S.Load(_gk, _start, true); else S.Reset(_gk, _start);
            Paint();
            if (firstStart)
            {
                _last = _t.Now;
                void Loop() { _t.RequestAnimationFrame(() => { Loop(); OnFrame(); }); }
                Loop();
            }
            // the room is up (Unity has it at once: the page decodes its picture first), then its twinkles, then 'shown'
            Twinkles();
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

        // A frame, as the page's run: the styles timers changed picked up (their CSS animations start now, at the frame's
        // end), the engine's frame, the unlock's (mgFrame, its callback after the engine's), then the twinkles that ended
        // (their animationend, sent after the frame)
        void OnFrame()
        {
            if (_reveal >= 0 && _revealAt < 0) _revealAt = _t.Now;
            if (_fill.pending) { _fill.pending = false; _fill.at = _t.Now; }
            foreach (var w in _tw) if (w.On && w.At < 0) w.At = _t.Now;
            double dt = Math.Min(0.034, Math.Max(0, (_t.Now - _last) / 1000)); _last = _t.Now;
            S.Tick(dt * S.Ts); _frame = S.Draw();
            if (_mg != null) MgFrame();
            TwinkleEnds();
        }

        void Ev(string type, Dictionary<string, object> e)
        {
            double N(string k) => e.TryGetValue(k, out var v) && v != null ? Convert.ToDouble(v) : 0;
            if (type == "loaded") { _tier = (int)N("tier"); _hp = N("hp"); _max = (int)N("max"); _name = (string)e["name"]; }
            else if (type == "hp") { _hp = N("hp"); _max = (int)N("max"); _lockHit = _t.Now; }   // (the padlock shakes with every hit)
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

        // ---- the HUD, the hint, the bottom's fade (host.html paint) -------------------------------------------------------
        string _hint;
        double _hintAt, _bottomFrom = 1, _bottomTo = 1, _bottomAt;
        void Paint()
        {
            string idle = _first && _start <= 1 ? "Tap to smash. The first tap might upgrade it!" : "Keep tapping!";
            string h = _phase == "idle" || _phase == "wait" ? idle : _phase == "up" ? "Upgrading… tap to skip" : _phase == "ko" ? "Bursting open…" : _phase == "open" ? "Opened!" : "";
            if (h != _hint) { _hint = h; _hintAt = _t.Now; }
            double to = _phase == "ko" || _phase == "open" ? 0.4 : 1;
            if (to != _bottomTo) { _bottomFrom = BottomOpacity(); _bottomTo = to; _bottomAt = _t.Now; }
            bool open = _phase == "ko" || _phase == "open";
            if (open != _lockOpen.on) _lockOpen = (open, _t.Now);
            // five bars, a fifth of the HP each; the one being hit drains (`transition: width 0.2s`, from where it is)
            double per = Math.Max(1, _max) / 5.0;
            for (int i = 0; i < 5; i++)
            {
                double f = Math.Max(0, Math.Min(1, (_hp - i * per) / per));
                if (!_pipW.TryGetValue(i, out var p)) { _pipW[i] = (f, f, -1e9); continue; }
                if (p.to != f) _pipW[i] = (PipW(i), f, _t.Now);
            }
        }
        double BottomOpacity() { double k = Math.Min(1, (_t.Now - _bottomAt) / 300); return _bottomFrom + (_bottomTo - _bottomFrom) * Ease(k); }

        readonly Dictionary<int, (double from, double to, double at)> _pipW = new Dictionary<int, (double, double, double)>();
        double PipW(int i) { var p = _pipW[i]; double k = Math.Min(1, Math.Max(0, (_t.Now - p.at) / 200)); return p.from + (p.to - p.from) * Ease(k); }

        static readonly Func<double, double> Ease = Easing.Bezier(0.25, 0.1, 0.25, 1), EaseOut = Easing.Bezier(0, 0, 0.58, 1), EaseInOut = Easing.Bezier(0.42, 0, 0.58, 1), Linear = x => x,
            Pop = Easing.Bezier(0.2, 0.9, 0.3, 1.2), Pop13 = Easing.Bezier(0.2, 0.9, 0.3, 1.3), Pop14 = Easing.Bezier(0.2, 0.9, 0.3, 1.4), Shackle = Easing.Bezier(0.2, 1.6, 0.4, 1),
            RingE = Easing.Bezier(0.1, 0.7, 0.3, 1), BitE = Easing.Bezier(0.15, 0.75, 0.35, 1);

        /// <summary>A CSS keyframe animation's value at `ms` (keyframes: offsets and values; the timing function per segment;
        /// before its delay, its first keyframe: `both`).</summary>
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
        // _reveal: when showReveal ran (the unlock's clock starts there); _revealAt: the end of that frame, where its CSS
        // animations start
        double _reveal = -1, _revealAt = -1;
        // the copies bar's last copy going in (growBar, `transition: width 0.8s`): from the frame it was set in
        (bool pending, double at, bool grown) _fill;
        // the reveal's side (labels, bar, coins, COLLECT, the rarity chip): now, or after the unlock's BAM
        double _sideAt;
        void ShowReveal()
        {
            _reveal = _t.Now; _revealAt = -1; _fill = default;
            Audio.Snd.Play("sparkle");
            var rw = _reward ?? new Reward();
            if (Unlocks(rw)) MergeStart(rw);
            else SideIn(-1);
        }
        // the bar's last copy going in 900 ms after the side comes in (at `at`: -1 the reveal's own start)
        void SideIn(double at)
        {
            _sideAt = at;
            int k = _revealKey;
            _t.SetTimeout(() => { if (k == _revealKey) _fill = (true, 0, true); }, 900);
        }

        // ---- the pointer -----------------------------------------------------------------------------------------------
        public void Down(float x, float y)
        {
            if (_reveal >= 0)
            {
                // a tap while the copies gather: straight to the BAM
                if (_mg != null && !_mg.Bammed)
                {
                    double t = _t.Now - _mg.T0;
                    if (t < _mg.Bam - 60) { _mg.Quiet = true; _mg.T0 -= _mg.Bam - t; }
                    return;
                }
                _collectDown = InCollect(x, y); return;
            }
            Tap(x, y);
        }
        public void Move(float x, float y) { }
        public void Up(float x, float y)
        {
            if (_reveal >= 0 && _collectDown && InCollect(x, y) && _t.Now - _reveal > 700) { _collectDown = false; OnCollect?.Invoke(); }
            _collectDown = false;
        }
        bool _collectDown;
        bool InCollect(float x, float y) => _reveal >= 0 && _sideAt > -2 && (_mg == null || _mg.Side) && _collectBox.Contains(x, y);
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

        // ---- the vault room and its twinkles -----------------------------------------------------------------------------
        // #vault: the picture's own box (2340 x 1080), covering the screen from the bottom middle
        (float x, float y, float w, float h) Vault()
        {
            float vw = Math.Max(W, H * 2.1667f), vh = Math.Max(H, W * 0.4615f);
            return ((W - vw) / 2, H - vh, vw, vh);
        }

        // The shine on the treasure (the user, 2026-11-16: "add the shiny flicker that pops on gold and gems, and on the
        // legendary and rainbow chests"): a cream four-point star in a glow that pops, turns and fades (vTw, its --d), on
        // the spots tools/chest/vault-room.mjs saved (coin tops, gems, the group's Legendary and Rainbow chests; x / 1000
        // and y / 460 of the picture). Sixteen at a time, each popping somewhere else a moment after it's done.
        sealed class Tw { public bool On; public double At = -1, Dur; public float X, Y, Size; public string Kind = ""; }
        readonly List<Tw> _tw = new List<Tw>();
        static IDictionary<string, object> _spots;
        void Twinkles()
        {
            if (_tw.Count > 0) return;
            _spots ??= Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/vault/spots") ?? throw new InvalidOperationException("Resources/Chests/vault/spots.json is missing: run node tools/unity/export-shop.mjs")));
            for (int i = 0; i < 16; i++)
            {
                var w = new Tw();
                _tw.Add(w);
                Later(() => Place(w), Rnd() * 1400);
            }
        }
        void Place(Tw el)
        {
            IList<object> Any(IList<object> a) => Prof.List(a[(int)Math.Floor(Rnd() * a.Count)]);
            var boxes = Prof.List(Prof.Get(Prof.Map(_spots["chests"]), _gk)) ?? (IList<object>)new List<object>();
            double r = Rnd(), x, y, size;
            string kind = "";
            if (boxes.Count > 0 && r < 0.28)
            {
                var b = Any(boxes);
                double b0 = Prof.D(b[0]), b1 = Prof.D(b[1]), b2 = Prof.D(b[2]), b3 = Prof.D(b[3]);
                x = b0 + Rnd() * (b2 - b0); y = b1 + Rnd() * (b3 - b1); size = 34 + Rnd() * 18; kind = (string)b[4] == "rb" ? "rb" : "";
            }
            else if (r < 0.52)
            {
                var g = Any(Prof.List(_spots["gems"]));
                double g2 = Prof.D(g[2]);
                x = Prof.D(g[0]) + (Rnd() - 0.5) * g2 * 0.5; y = Prof.D(g[1]) + (Rnd() - 0.6) * g2 * 0.5; size = g2 * 0.95; kind = "gem";
            }
            else
            {
                var c = Any(Prof.List(_spots["gold"]));
                double c2 = Prof.D(c[2]);
                x = Prof.D(c[0]) + (Rnd() - 0.5) * c2 * 0.6; y = Prof.D(c[1]) - c2 * (0.1 + Rnd() * 0.25); size = c2 * 1.1;
            }
            el.X = (float)(x / 1000); el.Y = (float)(y / 460); el.Size = (float)(size / 1000); el.Kind = kind;
            el.Dur = Math.Round((0.75 + Rnd() * 0.4) * 100) * 10;   // (--d: to 0.01 s)
            el.On = true; el.At = -1;
        }
        // animationend: off, and on another spot 0.12 to 1 s later (in the order of the twinkles, as Chrome sends them)
        void TwinkleEnds()
        {
            foreach (var w in _tw)
            {
                if (!w.On || w.At < 0 || _t.Now - w.At < w.Dur) continue;
                w.On = false;
                var el = w;
                Later(() => Place(el), 120 + Rnd() * 900);
            }
        }
        // a timer `ms` from now in the frame the page's would fire in (the page's clock keeps a fraction of a ms, the
        // Ticker whole ones, as browsers do: rounded up, it still lands in that frame)
        void Later(Action fn, double ms) => _t.SetTimeout(fn, Math.Ceiling(_t.Now + ms) - _t.Now);
        static readonly Dictionary<string, string> TW_SVG = new Dictionary<string, string>();
        static string TwSvg(string kind)
        {
            if (TW_SVG.TryGetValue(kind, out var s)) return s;
            var (c1, c2) = kind == "gem" ? ("#d6e6ff", "#b8c8ff") : kind == "rb" ? ("#ffb8e6", "#9fd8ff") : ("#ffe680", "#ffd84a");
            return TW_SVG[kind] = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"40\" height=\"40\" viewBox=\"0 0 40 40\"><defs><radialGradient id=\"g\" cx=\"20\" cy=\"20\" r=\"20\" gradientUnits=\"userSpaceOnUse\">"
                + $"<stop offset=\"0\" stop-color=\"#fffdf0\" stop-opacity=\".95\"/><stop offset=\".32\" stop-color=\"{c1}\" stop-opacity=\".75\"/><stop offset=\"1\" stop-color=\"{c2}\" stop-opacity=\"0\"/></radialGradient></defs>"
                + "<circle cx=\"20\" cy=\"20\" r=\"20\" fill=\"url(#g)\"/><path d=\"M20 1 Q21.8 18.2 39 20 Q21.8 21.8 20 39 Q18.2 21.8 1 20 Q18.2 18.2 20 1Z\" fill=\"#fffdf0\"/></svg>";
        }

        // ---- pieces --------------------------------------------------------------------------------------------------------
        string _room;
        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            double now = _t.Now;
            var (vx, vy, vw, vh) = Vault();
            if (_room == null)
            {
                var b = new UiSvg(W, H);
                b.Box(0, 0, W, H, new BoxStyle { Background = "#c88a50" });
                b.Image("Chests/vault/" + _gk, vx, vy, vw, vh);
                _room = b.Markup;
            }
            list.Add(Piece("room", _room, W, H, 0, 0, 1, null, 0));
            for (int i = 0; i < _tw.Count; i++)
            {
                var w = _tw[i];
                if (!w.On || w.At < 0) continue;
                // vTw (ease-in-out): opacity 0 → 1 (45 %) → 0 (70 %) → 0; scale .3 → 1.15 → .4 → .3; turning 0 → 45° → 90° → 0
                double ms = now - w.At; var at = new[] { 0, 0.45, 0.7, 1 };
                double op = Kf(ms, w.Dur, 0, at, new[] { 0.0, 1, 0, 0 }, EaseInOut), sc = Kf(ms, w.Dur, 0, at, new[] { 0.3, 1.15, 0.4, 0.3 }, EaseInOut), rot = Kf(ms, w.Dur, 0, at, new[] { 0.0, 45, 90, 0 }, EaseInOut);
                if (op <= 0) continue;
                float d = w.Size * vw, k = d / 40;
                list.Add(Piece("tw" + i, TwSvg(w.Kind), 40, 40, 0, 0, (float)op, Affine.Translate(vx + w.X * vw, vy + w.Y * vh) * Affine.Rotate(rot) * Affine.ScaleBy(sc * k, sc * k) * Affine.Translate(-20, -20), 2));
            }
            list.Add(Piece("chest", $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(W)}\" height=\"{F(H)}\" viewBox=\"0 0 {F(W)} {F(H)}\" overflow=\"visible\">{_frame}</svg>", W, H, 0, 0, 1, null, 0));
            Top(list, now);
            if (_banner != null) BannerPiece(list, now);
            Hint(list, now);
            if (_reveal >= 0 && _revealAt >= 0) Reveal(list, now);
            return list;
        }

        // ---- the HUD -------------------------------------------------------------------------------------------------------
        // #top sideways: 8 dp down, the chip, the name and the plate 4 dp apart
        const float TOP = 8, NAME_LH = 26.390625f, PLATE_W = 300, PLATE_H = 35;
        static readonly TextStyle TierT0 = T(Black, 12, "#000", 1.4f, 16), HpT = T(Black, 11, "#5b3418");
        static float HudBottom() => TOP + 26 + 4 + NAME_LH + 4 + PLATE_H;
        static float Bw25 => Bw(2.5f);

        void Top(List<ScreenPiece> list, double now)
        {
            var T0 = TN[Math.Min(4, _tier)];
            // the chip: a cream pill in a brown rim; the name in the gold lettering
            string label = $"{GROUPS[_gk].ToUpperInvariant()} · {T0.n.ToUpperInvariant()}";
            var tt = T(Black, 12, T0.ink, 1.4f, 16);
            float tw = Kit.W(label, tt) + 26 + 4;
            var s = new UiSvg(W, TOP + 26 + 4 + NAME_LH);
            s.Box(W / 2 - tw / 2, TOP, tw, 26, new BoxStyle { Radius = 999, Background = CREAM, BorderWidth = 2, BorderColor = INK, Shadows = new[] { new Shadow(INK, 0, 2.5f, 0) } });
            s.Text(label, W / 2 - tw / 2 + 15, TOP + 5, tt);
            if (_name != "") Gold(s, _name, W / 2, TOP + 30, 24, NAME_LH, 0.5f, 0, 12, 0.5f);
            list.Add(Piece("top", s, 0, 0, 1, null, 8));
            Plate(list, now);
        }

        // the HP meter: the vault lock's plate (wood in a brown rim), the padlock on its left end, five gold bars, the HP
        void Plate(List<ScreenPiece> list, double now)
        {
            float px = W / 2 - PLATE_W / 2, py = TOP + 30 + NAME_LH + 4, bw = 2;
            var s = new UiSvg(PLATE_W, PLATE_H);
            Plaque(s, 0, 0, PLATE_W, PLATE_H, 14, new Shadow("rgba(40,20,5,0.3)", 0, 7, 12));
            string hp = $"{Prof.JsStr(_hp)} HP";
            float hw = Kit.W(hp, HpT) + 16 + 4, cy = bw + 5;
            float pipsW = PLATE_W - 2 * bw - 30 - 7 - 7 - hw, one = (pipsW - 12) / 5, x0 = bw + 30;
            for (int i = 0; i < 5; i++)
            {
                float x = x0 + i * (one + 3), y = cy + 3.5f;
                var clip = s.NewId("pp");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x, y, one, 14, new[] { 4f, 4, 4, 4 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Box(x, y, one, 14, new BoxStyle { Background = "rgba(70,34,10,0.55)" });
                Inset(s, x, y, one, 14, 4, 0, 2, 2, "rgba(0,0,0,0.35)");
                double f = _pipW.ContainsKey(i) ? PipW(i) : 0;
                if (f > 0 && _pipW[i].to > 0)
                {
                    float fw = (float)(one * f), b = Bw(1.5f);
                    s.Box(x, y, fw, 14, new BoxStyle { Radius = 4, Gradient = new[] { "#fff6c4", "#ffd84a", "#e8a020" }, GradientStops = new[] { 0f, 0.45f, 1 } });
                    Inset(s, x + b, y + b, fw - 2 * b, 14 - 2 * b, 4 - b, 0, 1.5f, 0, "rgba(255,255,255,0.7)");
                    s.Box(x, y, fw, 14, new BoxStyle { Radius = 4, BorderWidth = b, BorderColor = "#7a4510" });
                }
                s.Close();
            }
            float hx = x0 + pipsW + 7;
            s.Box(hx, cy, hw, 21, new BoxStyle { Radius = 999, Background = CREAM, BorderWidth = 2, BorderColor = "#5b3418" });
            s.Text(hp, hx + 10, cy + 3, HpT);
            list.Add(Piece("hpbar", s, px, py, 1, null, 24));
            // the padlock (38 x 44, 16 dp out of the plate's left end): lockHit 0.36 s ease-out on each hit (about 50 % 40 %),
            // the shackle springing up (0.35 s cubic-bezier(0.2, 1.6, 0.4, 1)) when the chest bursts
            double hm = now - _lockHit, rot = 0, sc = 1;
            if (hm < 360)
            {
                var at = new[] { 0, 0.25, 0.5, 0.75, 1 };
                rot = Kf(hm, 360, 0, at, new[] { 0.0, -16, 11, -5, 0 }, EaseOut); sc = Kf(hm, 360, 0, at, new[] { 1, 1.08, 1, 1, 1 }, EaseOut);
            }
            double ok = Shackle(Math.Min(1, Math.Max(0, (now - _lockOpen.at) / 350))), u = _lockOpen.on ? ok : 1 - ok;
            list.Add(Piece("lock", LockSvg(u), 38, 44, 0, 0, 1, Affine.Translate(px + bw - 16, py + bw + 15.5f - 25) * Affine.Translate(19, 17.6) * Affine.Rotate(rot) * Affine.ScaleBy(sc, sc) * Affine.Translate(-19, -17.6), 4));
        }

        static string LockSvg(double open)
        {
            string tf = open == 0 ? "" : $" transform=\"translate({F(-3 * open)} {F(-7 * open)}) rotate({F(-14 * open)})\"";
            return "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"38\" height=\"44\" viewBox=\"0 0 38 44\" overflow=\"visible\"><defs>"
                + "<linearGradient id=\"lkBrass\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff1b0\"/><stop offset=\".4\" stop-color=\"#f6c64e\"/><stop offset=\"1\" stop-color=\"#b8781e\"/></linearGradient>"
                + "<linearGradient id=\"lkSteel\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#c98a24\"/><stop offset=\".5\" stop-color=\"#ffe08a\"/><stop offset=\"1\" stop-color=\"#c98a24\"/></linearGradient></defs>"
                + $"<g{tf}><path d=\"M11 22 V14 a8 8 0 0 1 16 0 V22\" fill=\"none\" stroke=\"#5b3418\" stroke-width=\"8\" stroke-linecap=\"round\"/><path d=\"M11 22 V14 a8 8 0 0 1 16 0 V22\" fill=\"none\" stroke=\"url(#lkSteel)\" stroke-width=\"4\" stroke-linecap=\"round\"/></g>"
                + "<rect x=\"3.5\" y=\"19\" width=\"31\" height=\"23\" rx=\"6.5\" fill=\"url(#lkBrass)\" stroke=\"#5b3418\" stroke-width=\"2.6\"/>"
                + "<path d=\"M7.5 23.5 H30.5\" stroke=\"#fff8d8\" stroke-width=\"1.8\" stroke-linecap=\"round\" opacity=\".7\"/>"
                + "<circle cx=\"19\" cy=\"29\" r=\"3.4\" fill=\"#5b3418\"/><path d=\"M17.4 30 H20.6 L21.4 37 H16.6Z\" fill=\"#5b3418\"/></svg>";
        }
        double _lockHit = -1e9;
        (bool on, double at) _lockOpen;

        // ---- the app's pieces --------------------------------------------------------------------------------------------
        /// <summary>A wood plaque (.plq, the lock plate's look): the wood, a brown rim and its lip (0 4 0), the light along
        /// its top (inset 0 2 0), a soft drop (`drop`).</summary>
        static void Plaque(UiSvg s, float x, float y, float w, float h, float r, Shadow? drop, bool glowRing = false)
        {
            float b = Bw25;
            var sh = glowRing ? new[] { new Shadow("#5b3418", 0, 4, 0), new Shadow("#ffe27a", 0, 0, 0, 3), new Shadow("rgba(255,214,90,0.8)", 0, 0, 22, 8) } : new[] { new Shadow("#5b3418", 0, 4, 0), drop.Value };
            s.Box(x, y, w, h, new BoxStyle { Radius = r, Gradient = new[] { "#e9b97c", "#cf955a", "#a86c38" }, GradientStops = new[] { 0f, 0.55f, 1 }, Shadows = sh });
            if (!glowRing) Inset(s, x + b, y + b, w - 2 * b, h - 2 * b, Math.Max(0, r - b), 0, 2, 0, "rgba(255,236,200,0.6)");
            s.Box(x, y, w, h, new BoxStyle { Radius = r, BorderWidth = b, BorderColor = "#5b3418" });
        }

        /// <summary>A CSS inset box-shadow in the padding box (x, y, w, h, corner r): the box's edge offset (dx, dy) and
        /// shrunk by `spread`, blurred.</summary>
        static void Inset(UiSvg s, float x, float y, float w, float h, float r, float dx, float dy, float blur, string color, float spread = 0)
        {
            if (w <= 0 || h <= 0) return;
            var clip = s.NewId("ic");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x, y, w, h, new[] { r, r, r, r })}\"/></clipPath>");
            string f = "";
            if (blur > 0)
            {
                var id = s.NewId("ib");
                s.Def($"<filter id=\"{id}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"{F(blur / 2)}\"/></filter>");
                f = $" filter=\"url(#{id})\"";
            }
            float m = 20 + blur * 2, ir = Math.Max(0, r - spread);
            var hole = UiSvg.RRect(x + dx + spread, y + dy + spread, w - 2 * spread, h - 2 * spread, new[] { ir, ir, ir, ir });
            s.Raw($"<g clip-path=\"url(#{clip})\"><path d=\"M{F(x - m)} {F(y - m)} H{F(x + w + m)} V{F(y + h + m)} H{F(x - m)} Z {hole}\" fill-rule=\"evenodd\" fill=\"{color}\"{f}/></g>");
        }

        /// <summary>The gold lettering (#name, .gl; src/royal theme LETTERING.gold): a white sticker edge (::before, its
        /// `edge` stroke), the dark outline (a 6 dp stroke) and its drop (0 3 0), the gold fill (::after); the line box
        /// `lh` tall from `top`, centred on `cx`.</summary>
        static float Gold(UiSvg s, string text, float cx, float top, float size, float lh, float ls, float ws, float edge, float align = 0.5f)
        {
            var st = T(Display, size, "#000", ls, lh);
            int spaces = text.Count(c => c == ' ');
            float w = Kit.W(text, st) + ws * spaces, x = cx - w * align, baseline = UiSvg.Baseline(st, top);
            var font = UiFont.Get(Display);
            double k = (double)size / font.UnitsPerEm;
            string Stroke(string c, float wd) => $"stroke=\"{c}\" stroke-width=\"{F(wd / k)}\" stroke-linejoin=\"round\"";
            void Run(float dy, string fill, string attrs)
            {
                if (ws == 0) { s.Glyphs(text, x, baseline + dy, Display, size, ls, fill, attrs); return; }
                int i = 0, n = 0;
                while (i < text.Length)
                {
                    int j = text.IndexOf(' ', i);
                    if (j < 0) j = text.Length;
                    if (j > i) s.Glyphs(text.Substring(i, j - i), x + (i > 0 ? Kit.W(text.Substring(0, i), st) : 0) + ws * n, baseline + dy, Display, size, ls, fill, attrs);
                    i = j + 1; n++;
                }
            }
            var id = s.NewId("gold");
            // (in the glyphs' own space: font units up from the baseline)
            s.Def($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F((baseline - top) / k)}\" x2=\"0\" y2=\"{F(-(top + lh - baseline) / k)}\"><stop offset=\"0.08\" stop-color=\"#fffbe6\"/><stop offset=\"0.38\" stop-color=\"#ffe57e\"/><stop offset=\"0.68\" stop-color=\"#ffbe2e\"/><stop offset=\"0.96\" stop-color=\"#f08c10\"/></linearGradient>");
            Run(0, "#ffffff", Stroke("#ffffff", edge));
            Run(3, "#4a1f04", Stroke("#4a1f04", 6));
            Run(0, "#4a1f04", Stroke("#4a1f04", 6));
            Run(0, $"url(#{id})", null);
            return w;
        }

        /// <summary>A picture with the page's `drop-shadow(0 6px 8px rgba(60,30,10,0.3))` under it.</summary>
        static void DropImage(UiSvg s, string href, float x, float y, float w, float h)
        {
            var id = s.NewId("ds");
            s.Def($"<filter id=\"{id}\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feColorMatrix type=\"matrix\" values=\"0 0 0 0 0.2353 0 0 0 0 0.1176 0 0 0 0 0.0392 0 0 0 0.3 0\"/><feGaussianBlur stdDeviation=\"4\"/></filter>");
            s.Raw($"<g filter=\"url(#{id})\"><image href=\"{href}\" x=\"{F(x)}\" y=\"{F(y + 6)}\" width=\"{F(w)}\" height=\"{F(h)}\" preserveAspectRatio=\"none\"/></g>");
            s.Image(href, x, y, w, h);
        }

        static void TxtC(UiSvg s, string text, float cx, float y, TextStyle t) => s.Text(text, cx - Kit.W(text, t) / 2, y, t);

        void BannerPiece(List<ScreenPiece> list, double now)
        {
            var (text, tier, at) = _banner.Value;
            double ms = now - at;
            var kat = new[] { 0, 0.4, 0.65, 1 };
            double sc = Kf(ms, 600, 0, kat, new[] { 2.6, 0.92, 1.06, 1 }, Pop), rot = Kf(ms, 600, 0, kat, new[] { -8.0, 2, -1, 0 }, Pop), op = Kf(ms, 600, 0, kat, new[] { 0.0, 1, 1, 1 }, Pop);
            string ink = TN[tier].ink, glow = TN[tier].c;
            var sh = new List<Shadow> { new Shadow(ink, 3, 0, 0), new Shadow(ink, -3, 0, 0), new Shadow(ink, 0, 3, 0), new Shadow(ink, 0, -3, 0), new Shadow(ink, 2.4f, 2.4f, 0), new Shadow(ink, -2.4f, -2.4f, 0), new Shadow(ink, 2.4f, -2.4f, 0), new Shadow(ink, -2.4f, 2.4f, 0), new Shadow(ink, 0, 7, 0) };
            var bt = T(Kit.Display, 50, "#ffffff", 1, 50, sh.ToArray());
            float w = Kit.W(text, bt);
            var s = new UiSvg(w, 50);
            // the two soft glows under it (0 0 28 ink, 0 0 54 the tier's colour), blurred in a region that holds them
            float baseline = UiSvg.Baseline(bt, 0);
            foreach (var (col, blur) in new[] { (glow, 54f), (ink, 28f) })
            {
                var f = s.NewId("bg");
                s.Def($"<filter id=\"{f}\" filterUnits=\"userSpaceOnUse\" x=\"{F(-2 * blur)}\" y=\"{F(-2 * blur)}\" width=\"{F(w + 4 * blur)}\" height=\"{F(50 + 4 * blur)}\"><feGaussianBlur stdDeviation=\"{F(blur / 2)}\"/></filter>");
                s.Open($"filter=\"url(#{f})\"");
                s.Glyphs(text, 0, baseline, Kit.Display, 50, 1, col);
                s.Close();
            }
            s.Text(text, 0, 0, bt);
            list.Add(Piece("banner", s, W / 2 - w / 2, H * 0.24f, (float)Math.Max(0, Math.Min(1, op)), About(w, 50, Affine.Rotate(rot) * Affine.ScaleBy(sc, sc)), 70));
        }

        // the hint: a cream pill in a brown rim and its lip, 10 dp over the bottom (c2Rise 0.3 s on each new line)
        void Hint(List<ScreenPiece> list, double now)
        {
            if (string.IsNullOrEmpty(_hint)) return;
            var ht = T(Black, 14, "#5b3418");
            float b = Bw25, w = Kit.W(_hint, ht) + 36 + 2 * b, h = LH(ht) + 12 + 2 * b;
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Radius = 999, Background = CREAM, BorderWidth = b, BorderColor = INK, Shadows = new[] { new Shadow(INK, 0, 3, 0) } });
            s.Text(_hint, 18 + b, 6 + b, ht);
            double k = Math.Min(1, (now - _hintAt) / 300), e = EaseOut(k);
            float op = (float)(e * BottomOpacity());
            list.Add(Piece("hint", s, W / 2 - w / 2, H - 10 - h + (float)(10 * (1 - e)), op, null, 6));
        }

        // c2Rise (opacity 0 → 1, translateY 10 → 0, ease-out) of `dur` after `delay`
        static (float op, float dy) Rise(double ms, double dur, double delay)
        {
            double k = Math.Max(0, Math.Min(1, (ms - delay) / dur)), e = EaseOut(k);
            return ((float)e, (float)(10 * (1 - e)));
        }
        // c2Pop 0.5 s cubic-bezier(0.2, 0.9, 0.3, 1.3): opacity 0 → 1 (60 %); scale .4 → 1.12 → 1, turning -6° → 2° → 0
        static (float op, Affine m) PopIn(double ms, double delay, float w, float h)
        {
            var at = new[] { 0, 0.6, 1 };
            double op = Kf(ms, 500, delay, at, new[] { 0.0, 1, 1 }, Pop13), sc = Kf(ms, 500, delay, at, new[] { 0.4, 1.12, 1 }, Pop13), rot = Kf(ms, 500, delay, at, new[] { -6.0, 2, 0 }, Pop13);
            return ((float)Math.Max(0, Math.Min(1, op)), About(w, h, Affine.ScaleBy(sc, sc) * Affine.Rotate(rot)));
        }

        // ---- the cards v6 card (the Characters screen's: webgame export/cards4, SQ_CARD4.of) -------------------------------
        sealed class Cards4 { public Dictionary<string, float[][]> L = new Dictionary<string, float[][]>(); public Dictionary<string, string> Ink = new Dictionary<string, string>(); public Dictionary<string, (int rar, float ar)> Names = new Dictionary<string, (int, float)>(); public HashSet<string> Looks = new HashSet<string>(); public string[] Fr; }
        static Cards4 _c4;
        static Cards4 C4
        {
            get
            {
                if (_c4 != null) return _c4;
                var j = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/cards4") ?? throw new InvalidOperationException("Resources/Chests/cards4.json is missing: run node tools/unity/export-chest.mjs")));
                var c = new Cards4 { Fr = Prof.List(j["fr"]).Select(x => (string)x).ToArray() };
                foreach (var kv in Prof.Map(j["L"])) { var m = Prof.Map(kv.Value); c.L[kv.Key] = new[] { "bg", "art", "nm" }.Select(n => Prof.List(m[n]).Select(v => (float)Prof.D(v)).ToArray()).ToArray(); }
                foreach (var kv in Prof.Map(j["ink"])) c.Ink[kv.Key] = (string)kv.Value;
                foreach (var kv in Prof.Map(j["names"])) { var a = Prof.List(kv.Value); c.Names[kv.Key] = ((int)Prof.D(a[0]), (float)(Prof.D(a[1]) / Prof.D(a[2]))); }
                foreach (var k in Prof.List(j["looks"])) c.Looks.Add((string)k);
                return _c4 = c;
            }
        }
        /// <summary>The creature's still: its look picture (Chests/look), else the Stack cut-out in its square.</summary>
        static void Still(UiSvg s, string key, float x, float y, float w, float h, bool shadow)
        {
            if (key == null) return;
            float d = Math.Min(w, h), sx = x + (w - d) / 2, sy = y + h - d;
            if (C4.Looks.Contains(key)) { if (shadow) DropImage(s, "Chests/look/" + key, sx, sy, d, d); else s.Image("Chests/look/" + key, sx, sy, d, d); }
            else ShopView.CreaturePicPublic(s, key, sx, sy, d);
        }
        // a layer's box ([x0, y0, x1, y1] % of the card) in a card cw x ch at (x, y)
        static (float x, float y, float w, float h) Box(float[] b, float x, float y, float cw, float ch) => (x + b[0] / 100 * cw, y + b[1] / 100 * ch, (b[2] - b[0]) / 100 * cw, (b[3] - b[1]) / 100 * ch);
        static float CardH(float cw) => cw * 2528 / 1696;

        /// <summary>The card's layers in cw at (x, y): the group's background (cover, its bottom), the creature (contain,
        /// its feet at the bottom, `bob` up, its shadow under it on the big card), the shine (`shine`: its transform, null
        /// none), the frame, the name (its picture for its rarity, else its text in the rarity's ink).</summary>
        static void CardLayers(UiSvg s, Reward rw, string gk, float x, float y, float cw, double bob, Affine? shine, bool big)
        {
            float ch = CardH(cw);
            string rk = C4.Fr[Math.Max(0, Math.Min(4, rw.Rar))];
            var L = C4.L[rk];
            var (bx, by, bw, bh) = Box(L[0], x, y, cw, ch);
            var clip = s.NewId("cb");
            s.Def($"<clipPath id=\"{clip}\"><rect x=\"{F(bx)}\" y=\"{F(by)}\" width=\"{F(bw)}\" height=\"{F(bh)}\"/></clipPath>");
            float k = Math.Max(bw, bh);
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Image("Chests/card/bg-" + (rw.Set ?? gk), bx + (bw - k) / 2, by + bh - k, k, k);
            s.Close();
            var (ax, ay, aw, ah) = Box(L[1], x, y, cw, ch);
            Still(s, rw.Key, ax, ay + (float)bob, aw, ah, big);
            if (shine != null)
            {
                var g = s.NewId("sg");
                s.Def($"<linearGradient id=\"{g}\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>");
                var m = Affine.Translate(bx, by) * shine.Value;
                s.Raw($"<g clip-path=\"url(#{clip})\"><g transform=\"matrix({F(m.A)} {F(m.B)} {F(m.C)} {F(m.D)} {F(m.E)} {F(m.F)})\"><rect x=\"0\" y=\"0\" width=\"{F(bw * 0.4f)}\" height=\"{F(bh)}\" fill=\"url(#{g})\"/></g></g>");
            }
            s.Image("Chests/card/frame-" + rk, x, y, cw, ch);
            var (nx, ny, nw, nh) = Box(L[2], x, y, cw, ch);
            if (rw.Key != null && C4.Names.TryGetValue(rw.Key, out var nm) && nm.rar == rw.Rar)
            {
                float iw = Math.Min(nw, nh * nm.ar), ih = iw / nm.ar;
                s.Image("Chests/card/name/" + rw.Key, nx + (nw - iw) / 2, ny + (nh - ih) / 2, iw, ih);
            }
            else
            {
                var t = T(Display, 0.09f * cw, C4.Ink[rk], 0, 0.09f * cw);
                string n = rw.Name != "" ? rw.Name : "Loot!";
                s.Text(n, nx + (nw - Kit.W(n, t)) / 2, ny + (nh - 0.09f * cw) / 2, t);
            }
        }

        // ---- the reveal's layout (sideways: three columns, the card in the middle) ------------------------------------------
        // #reveal.on: a grid (minmax(0, 1fr) auto minmax(0, 1fr)), 12 / 20 dp padding, 22 dp between the columns, its
        // one row as tall as the screen, each column's content in its middle
        float CW => Math.Min(300, H - 74) * 1696 / 2528;
        float SideW => (W - 40 - 44 - CW) / 2;

        sealed class Item { public string Id; public float H, W; public Action<UiSvg, float> Draw; public Func<double, (float op, Affine m)> Anim; }

        void Reveal(List<ScreenPiece> list, double now)
        {
            var rw = _reward ?? new Reward();
            var T0 = TN[Math.Min(4, _tier)];
            double ms = now - _revealAt;
            bool unlock = Unlocks(rw);
            var mg = _mg;
            // the side's entrances: from the reveal, or (the unlock) from the BAM's side moment, hidden till then
            bool sideOn = !unlock || (mg != null && mg.Side);
            double sms = !unlock ? ms : sideOn ? now - mg.SideAt : -1;
            // #reveal's own c2Fade 0.3 s, over all of it
            float fade = (float)EaseOut(Math.Min(1, ms / 300));
            var bg = new UiSvg(W, H);
            float cx = W / 2, cy = H * 0.42f, far = (float)Math.Sqrt(Math.Max(cx, W - cx) * Math.Max(cx, W - cx) + Math.Max(cy, H - cy) * Math.Max(cy, H - cy));
            var g = bg.NewId("rv");
            bg.Def($"<radialGradient id=\"{g}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(cx)}\" cy=\"{F(cy)}\" r=\"{F(far)}\"><stop offset=\"0\" stop-color=\"rgba(255,184,90,0.5)\"/><stop offset=\"0.7\" stop-color=\"rgba(34,22,14,0.92)\"/></radialGradient>");
            bg.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(W)}\" height=\"{F(H)}\" fill=\"url(#{g})\"/>");
            list.Add(Piece("reveal-bg", bg, 0, 0, fade, null, 0));
            // the rays turning behind the card (14 s a turn), in the middle of the screen
            var rays = new UiSvg(820, 820);
            var mk = rays.NewId("rm");
            rays.Def($"<radialGradient id=\"{mk}g\" gradientUnits=\"userSpaceOnUse\" cx=\"410\" cy=\"410\" r=\"{F(410 * Math.Sqrt(2))}\"><stop offset=\"0.15\" stop-color=\"#fff\"/><stop offset=\"0.62\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient><mask id=\"{mk}\"><rect x=\"0\" y=\"0\" width=\"820\" height=\"820\" fill=\"url(#{mk}g)\"/></mask>");
            var d = new StringBuilder();
            for (int i = 0; i < 18; i++)
            {
                double a0 = (i * 20 - 90) * Math.PI / 180, a1 = (i * 20 + 8 - 90) * Math.PI / 180, R = 600;
                d.Append($"M410 410 L{F(410 + R * Math.Cos(a0))} {F(410 + R * Math.Sin(a0))} L{F(410 + R * Math.Cos(a1))} {F(410 + R * Math.Sin(a1))} Z ");
            }
            var rc = rays.NewId("rc");
            rays.Def($"<clipPath id=\"{rc}\"><circle cx=\"410\" cy=\"410\" r=\"410\"/></clipPath>");
            rays.Raw($"<g mask=\"url(#{mk})\" clip-path=\"url(#{rc})\"><path d=\"{d}\" fill=\"rgba(255,230,140,0.32)\"/></g>");
            list.Add(Piece("rays", rays, W / 2 - 410, H / 2 - 410, fade, About(820, 820, Affine.Rotate(ms / 14000 * 360 % 360)), 0));

            // the middle (#rvMain): the card (or the unlocked creature's place) and, under it, its rarity and line
            float cw = CW, ch = CardH(cw), col1 = 20, colM = col1 + SideW + 22, colE = colM + cw + 22;
            bool has = rw.Name != "";
            var rarT = T(Black, 12, has ? rw.RarInk : "#5b3418", 1);
            string rar = has ? rw.RarLabel : GROUPS[_gk].ToUpperInvariant();
            float rarW = Kit.W(rar, rarT) + 24 + 4, rarH = LH(rarT) + 4 + 4;
            var conT = T(Heavy, 12.5f, "#fff3dc", 0, 0, new[] { new Shadow("rgba(40,20,5,0.7)", 0, 1.5f, 0), new Shadow("rgba(40,20,5,0.6)", 0, 0, 6) });
            var con = rw.Concept != "" ? new TextFlow(rw.Concept, conT) : null;
            float conMax = cw + 40 - rarW - 8, conW = 0, conH = 0;
            if (con != null) (conW, conH) = con.Measure(Math.Min(260, conMax));
            float aboutH = Math.Max(rarH, conH), mainH = ch + 7 + aboutH, mainY = 12 + (H - 24 - mainH) / 2;
            // (the BAM's shake moves the middle and the unlock's layer: mgShake 0.42 s linear)
            var shake = Affine.Identity;
            if (mg != null && mg.Bammed && now - mg.BurstAt < 420)
            {
                var at = new[] { 0, 0.12, 0.26, 0.4, 0.55, 0.7, 0.85, 1 };
                double sm = now - mg.BurstAt;
                shake = Affine.Translate(Kf(sm, 420, 0, at, new[] { 0.0, -8, 7, -6, 5, -3, 2, 0 }, Linear), Kf(sm, 420, 0, at, new[] { 0.0, 5, -6, -3, 4, 2, -1, 0 }, Linear));
            }
            if (!unlock) RevealCard(list, rw, colM, mainY, cw, ms, fade, shake);
            else Hero(list, rw, colM, mainY, cw, now, fade, shake, sideOn ? sms : -1);
            if (sideOn)
            {
                // #rvAbout: the chip and the line beside it (c2Rise 0.4 s after 0.45 s)
                var (o, dy) = Rise(sms, 400, 450);
                float aw = rarW + (con != null ? 8 + conW : 0), ax = colM + cw / 2 - aw / 2, ay = mainY + ch + 7;
                var ab = new UiSvg(aw, aboutH);
                ab.Box(0, (aboutH - rarH) / 2, rarW, rarH, new BoxStyle { Radius = 999, Background = has ? rw.RarBg : "#ffffff", BorderWidth = 2, BorderColor = "#ffffff", Shadows = new[] { new Shadow("rgba(40,20,5,0.35)", 0, 2, 0) } });
                ab.Text(rar, 14, (aboutH - rarH) / 2 + 4, rarT);
                con?.Draw(ab, rarW + 8, (aboutH - conH) / 2, conW);
                list.Add(Piece("rvAbout", ab, ax, ay + dy, o * fade, shake, 10));
            }
            if (!sideOn) { if (mg != null) Merge(list, now, fade); return; }

            // the left column (#rvStart): what came, the bar, the coins, the lucky meter's note (12 dp apart)
            bool up = _tier > _start, copy = !rw.IsNew && rw.Copies > 0, counted = rw.Need > 1 && (copy || rw.IsNew);
            double coins = rw.Coins + rw.DupeCoins + rw.SetBonus;
            var items = new List<Item>();
            if (up)
            {
                var ut = T(Black, 12, T0.c, 1.2f, 16);
                string text = "UPGRADED TO " + T0.n.ToUpperInvariant() + "!";
                float w = Kit.W(text, ut) + 26 + 4;
                items.Add(new Item { Id = "rvUp", W = w, H = 26, Anim = m => { var (op, dy) = Rise(m, 400, 250); return (op, Affine.Translate(0, dy)); }, Draw = (s, x) =>
                {
                    s.Box(x, 0, w, 26, new BoxStyle { Radius = 999, Background = CREAM, BorderWidth = 2, BorderColor = INK, Shadows = new[] { new Shadow(INK, 0, 2.5f, 0) } });
                    s.Text(text, x + 15, 5, ut);
                } });
            }
            if (rw.IsNew || copy)
            {
                string text = copy ? "+1 COPY" : counted ? "UNLOCKED!" : "NEW SQUISHY!";
                var gt = T(Display, 25, "#000", 0.8f, 28.75f);
                float w = Kit.W(text, gt) + 4 * text.Count(c => c == ' ') + 44 + 4, h = 28.75f + 9 + 4;
                items.Add(new Item { Id = "rvNew", W = w, H = h, Anim = m => PopIn(m, 350, w, h), Draw = (s, x) =>
                {
                    Plaque(s, x, 0, w, h, 16, new Shadow("rgba(40,20,5,0.35)", 0, 8, 14));
                    Gold(s, text, x + w / 2, 2 + 3, 25, 28.75f, 0.8f, 4, 11);
                } });
            }
            if (counted)
            {
                float w = Math.Min(272, SideW - 16);
                double n = Math.Min(rw.Copies, rw.Need), left = rw.Need - n;
                var noteT = T(Black, 13.5f, "#fff3dc", 0, 0, new[] { new Shadow("rgba(40,20,5,0.8)", 0, 1.5f, 0), new Shadow("rgba(40,20,5,0.6)", 0, 0, 6) });
                var noteB = T(Black, 13.5f, "#ffd84a", 0, 0, noteT.Shadows);
                var note = left > 0 ? new TextFlow(noteT, 0.5f, new Run("Find ", noteT), new Run($"{Prof.JsStr(left)} more", noteB), new Run($" to unlock {rw.Name}!", noteT)) : new TextFlow($"{rw.Name} joins your squad!", noteT, 0.5f);
                var (nw, nh) = note.Measure(w);
                items.Add(new Item { Id = "rvCopies", W = w, H = 36 + 7 + nh, Anim = m => { var (op, dy) = Rise(m, 400, 450); return (op, Affine.Translate(0, dy)); }, Draw = (s, x) => { CopiesBar(s, rw, x, w, n, now); note.Draw(s, x + (w - nw) / 2, 43, nw); } });
            }
            if (coins > 0)
            {
                var lt = T(Display, 18, "#b86200");
                string ctext = "+" + Prof.Fmt(coins);
                float cwid = 8 + 20 + 6 + Kit.W(ctext, lt) + 14, chh = Math.Max(20, LH(lt)) + 12;
                var dt = T(Black, 13, "#8a4a00");
                bool dupe = !rw.IsNew && rw.DupeCoins > 0;
                // (a row: the pills as tall as the taller, their content in their middle)
                float lh = Math.Max(chh, dupe ? LH(dt) + 12 : 0), dw = dupe ? Kit.W("Duplicate", dt) + 28 : 0, lw = cwid + (dupe ? 8 + dw : 0);
                items.Add(new Item { Id = "loot", W = lw, H = lh, Anim = m => { var (op, dy) = Rise(m, 400, 500); return (op, Affine.Translate(0, dy)); }, Draw = (s, x) =>
                {
                    var ring = new[] { new Shadow("#a04a00", 0, 0, 0, 2), new Shadow("#a04a00", 0, 3, 0, 2) };
                    s.Box(x, 0, cwid, lh, new BoxStyle { Radius = 999, Background = "#ffffff", Shadows = ring });
                    // the coin: 20 dp, a white edge and a thin dark ring, its gold (circle at 50 % 42 % of its inside)
                    float ccx = x + 18, ccy = lh / 2;
                    var cg = s.NewId("cn");
                    s.Def($"<radialGradient id=\"{cg}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(ccx)}\" cy=\"{F(ccy - 8 + 16 * 0.42f)}\" r=\"{F(Math.Sqrt(8 * 8 + 9.28 * 9.28))}\"><stop offset=\"0\" stop-color=\"#fff6a8\"/><stop offset=\"0.42\" stop-color=\"#ffd83a\"/><stop offset=\"0.72\" stop-color=\"#ffb000\"/><stop offset=\"1\" stop-color=\"#f08c00\"/></radialGradient>");
                    s.Raw($"<circle cx=\"{F(ccx)}\" cy=\"{F(ccy)}\" r=\"11\" fill=\"#a04a00\"/><circle cx=\"{F(ccx)}\" cy=\"{F(ccy)}\" r=\"10\" fill=\"#ffffff\"/><circle cx=\"{F(ccx)}\" cy=\"{F(ccy)}\" r=\"8\" fill=\"url(#{cg})\"/>");
                    s.Text(ctext, x + 34, (lh - LH(lt)) / 2, lt);
                    if (dupe)
                    {
                        float dx = x + cwid + 8;
                        s.Box(dx, 0, dw, lh, new BoxStyle { Radius = 999, Background = "#fff3c4", Shadows = ring });
                        s.Text("Duplicate", dx + 14, (lh - LH(dt)) / 2, dt);
                    }
                } });
            }
            if (rw.Luck)
            {
                var pt = T(Black, 13, "#ffe27a");
                const string text = "Lucky meter paid out: guaranteed Epic or better!";
                var pf = new TextFlow(text, pt, 0.5f);
                var (pw, ph) = pf.Measure(SideW);
                items.Add(new Item { Id = "rvPity", W = pw, H = ph, Anim = m => (1f, Affine.Identity), Draw = (s, x) => pf.Draw(s, x, 0, pw) });
            }
            float sumH = items.Sum(i => i.H) + 12 * Math.Max(0, items.Count - 1), yy = 12 + (H - 24 - sumH) / 2;
            foreach (var it in items)
            {
                var s = new UiSvg(it.W, it.H);
                it.Draw(s, 0);
                var (op, m) = it.Anim(sms);
                list.Add(Piece(it.Id, s, col1 + SideW / 2 - it.W / 2, yy, op * fade, m, 30));
                yy += it.H + 12;
            }

            // the right column (#rvEnd): COLLECT, the app's gold button (c2Rise 0.4 s after 0.7 s)
            {
                var (o, dy) = Rise(sms, 400, 700);
                float bw = Math.Min(230, SideW), bh = 60, bx = colE + SideW / 2 - bw / 2, by = 12 + (H - 24 - bh) / 2;
                // held, the whole button (its lip and shadow with it) shrinks to 92 % about its middle, as the menu's
                // Level crest does
                bool down = _collectDown;
                var b = new UiSvg(bw, bh);
                b.Box(0, 0, bw, bh, new BoxStyle { Radius = 999, Gradient = new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, Shadows = new[] { new Shadow("#9c4d06", 0, 0, 0, 2.5f), new Shadow("#9c4d06", 0, 5, 0, 2.5f), new Shadow("rgba(60,30,5,0.4)", 0, 11, 18) } });
                // its padding box: the light on its top half (::before), the shine sweeping (::after, c2Shine 2.8 s after 1.4 s)
                float iw = bw - 6, ih = bh - 6;
                var clip = b.NewId("cc");
                b.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(3, 3, iw, ih, new[] { ih / 2, ih / 2, ih / 2, ih / 2 })}\"/></clipPath>");
                b.Open($"clip-path=\"url(#{clip})\"");
                b.Box(3 + iw * 0.08f, 3 + 2, iw * 0.84f, ih * 0.42f, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.45)" });
                ShineBand(b, 3, 3, iw, ih, 0.34f, ms, 2800, 1400, 0.6f);
                b.Close();
                b.Box(0, 0, bw, bh, new BoxStyle { Radius = 999, BorderWidth = 3, BorderColor = "#ffffff" });
                var ct = T(Display, 26, "#ffffff", 1, 0, new[] { new Shadow("#9c4d06", 0, 2.5f, 0), new Shadow("#9c4d06", 2, 0, 0), new Shadow("#9c4d06", -2, 0, 0), new Shadow("#9c4d06", 0, -1.5f, 0) });
                TxtC(b, "COLLECT", bw / 2, (bh - LH(ct)) / 2, ct);
                var press = down ? About(bw, bh + 5, Affine.ScaleBy(0.92, 0.92)) : Affine.Identity;   // (its 5 dp lip in)
                list.Add(Piece("collect", b, bx, by, o * fade, Affine.Translate(0, dy) * press, 30));
                _collectBox = new Frame(bx, by, bw, bh);
            }
            if (mg != null) Merge(list, now, fade);
        }

        /// <summary>c2Shine on a band `frac` of the box wide (a white sweep, `peak` at its middle): translateX -120 % →
        /// 220 % of itself by 60 % of `dur`, skewed -20°, every `dur` after `delay` (before it: where it stands, unmoved).</summary>
        static void ShineBand(UiSvg s, float x, float y, float w, float h, float frac, double ms, double dur, double delay, float peak)
        {
            float sw = w * frac;
            var g = s.NewId("sh");
            s.Def($"<linearGradient id=\"{g}\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"{F(peak)}\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>");
            var m = ShineAt(ms, dur, delay, sw, h);
            m = Affine.Translate(x, y) * m;
            s.Raw($"<g transform=\"matrix({F(m.A)} {F(m.B)} {F(m.C)} {F(m.D)} {F(m.E)} {F(m.F)})\"><rect x=\"0\" y=\"0\" width=\"{F(sw)}\" height=\"{F(h)}\" fill=\"url(#{g})\"/></g>");
        }
        static Affine ShineAt(double ms, double dur, double delay, float sw, float h)
        {
            if (ms < delay) return Affine.Identity;
            double tx = Kf(ms, dur, delay, new[] { 0, 0.6, 1 }, new[] { -1.2, 2.2, 2.2 }, EaseInOut, true) * sw;
            var skew = new Affine(1, 0, Math.Tan(-20 * Math.PI / 180), 1, 0, 0);
            return Affine.Translate(sw / 2, h / 2) * Affine.Translate(tx, 0) * skew * Affine.Translate(-sw / 2, -h / 2);
        }

        // the reveal's card: its glow, its layers, popping in (c2Card 0.6 s: scale .2 → 1.08 → 1, turning -14° → 3° → 0),
        // the creature bobbing (c2Bob 2.4 s), the shine sweeping its window (c2Shine 2.6 s after 0.6 s)
        void RevealCard(List<ScreenPiece> list, Reward rw, float x, float y, float cw, double ms, float fade, Affine shake)
        {
            float ch = CardH(cw), gx = cw * 0.14f, gy = ch * 0.09f;
            var cat = new[] { 0, 0.55, 1 };
            double sc = Kf(ms, 600, 0, cat, new[] { 0.2, 1.08, 1 }, Pop), rot = Kf(ms, 600, 0, cat, new[] { -14.0, 3, 0 }, Pop), op = Kf(ms, 600, 0, cat, new[] { 0.0, 1, 1 }, Pop);
            var s = new UiSvg(cw + 2 * gx, ch + 2 * gy);
            var gg = s.NewId("cg");
            s.Def($"<radialGradient id=\"{gg}\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"rgba(255,226,130,0.7)\"/><stop offset=\"0.6\" stop-color=\"rgba(255,226,130,0.25)\"/><stop offset=\"1\" stop-color=\"rgba(255,226,130,0)\"/></radialGradient>");
            s.Raw($"<ellipse cx=\"{F(cw / 2 + gx)}\" cy=\"{F(ch / 2 + gy)}\" rx=\"{F(cw / 2 + gx)}\" ry=\"{F(ch / 2 + gy)}\" fill=\"url(#{gg})\"/>");
            double bob = Kf(ms, 2400, 0, new[] { 0, 0.5, 1 }, new[] { 0.0, -5, 0 }, EaseInOut, true);
            var L = C4.L[C4.Fr[Math.Max(0, Math.Min(4, rw.Rar))]][0];
            var shine = ShineAt(ms, 2600, 600, (L[2] - L[0]) / 100 * cw * 0.4f, (L[3] - L[1]) / 100 * ch);
            CardLayers(s, rw, _gk, gx, gy, cw, bob, shine, true);
            var m = shake * Affine.Translate(x - gx, y - gy) * About(cw + 2 * gx, ch + 2 * gy, Affine.ScaleBy(sc, sc) * Affine.Rotate(rot));
            list.Add(new ScreenPiece { Id = "card", Svg = s.Markup, W = s.W, H = s.H, Opacity = (float)Math.Max(0, Math.Min(1, op)) * fade, Margin = 10, Transform = m });
        }

        // the copies bar: the lock plate's wood, the creature's head in a cream disc where the lock has its padlock, a gold
        // fill in a dark groove (growing to the new count 0.9 s after it comes in: 0.8 s cubic-bezier(0.2, 0.9, 0.3, 1.2)),
        // the count on it; it shines once the last copy is in
        void CopiesBar(UiSvg s, Reward rw, float x, float w, double n, double now)
        {
            float b = Bw25;
            Plaque(s, x, 0, w, 36, 15, new Shadow("rgba(40,20,5,0.35)", 0, 8, 14));
            // the head (44, 16 dp out of the plate's left end)
            float hx = x + b - 16, hy = b + 16 - 23, hb = Bw25;
            s.Box(hx, hy, 44, 44, new BoxStyle { Radius = 22, Shadows = new[] { new Shadow("#5b3418", 0, 3, 0) } });
            var hg = s.NewId("hd");
            float hi = 44 - 2 * hb;
            s.Def($"<radialGradient id=\"{hg}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(hx + 22)}\" cy=\"{F(hy + hb + hi * 0.38f)}\" r=\"{F(Math.Sqrt(hi * hi / 4 + (hi * 0.62) * (hi * 0.62)))}\"><stop offset=\"0\" stop-color=\"#fffaf0\"/><stop offset=\"0.6\" stop-color=\"#fff0d4\"/><stop offset=\"1\" stop-color=\"#f0d6a8\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(hx + 22)}\" cy=\"{F(hy + 22)}\" r=\"22\" fill=\"url(#{hg})\"/>");
            Inset(s, hx + hb, hy + hb, 44 - 2 * hb, 44 - 2 * hb, 22 - hb, 0, -3, 4, "rgba(160,100,40,0.25)");
            var hc = s.NewId("hc");
            s.Def($"<clipPath id=\"{hc}\"><circle cx=\"{F(hx + 22)}\" cy=\"{F(hy + 22)}\" r=\"{F(22 - hb)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{hc})\"");
            float iw = (44 - 2 * hb) * 0.86f;
            Still(s, rw.Key, hx + hb + (44 - 2 * hb) * 0.07f, hy + hb + (44 - 2 * hb) * 0.09f, iw, iw, false);
            s.Close();
            s.Box(hx, hy, 44, 44, new BoxStyle { Radius = 22, BorderWidth = hb, BorderColor = "#5b3418" });
            // the groove and its fill
            float gx = x + b + 34, gw = w - 2 * b - 34 - 9, gy = 18 - 9;
            s.Box(gx, gy, gw, 18, new BoxStyle { Radius = 9, Background = "rgba(70,34,10,0.6)", Shadows = new[] { new Shadow("rgba(255,236,200,0.45)", 0, 1, 0) } });
            Inset(s, gx, gy, gw, 18, 9, 0, 2, 3, "rgba(0,0,0,0.4)");
            double p0 = Math.Round((n - 1) / rw.Need * 1000) / 10, p1 = Math.Round(n / rw.Need * 1000) / 10, pct = p0;
            if (_fill.grown && _fill.at > 0) pct = p0 + (p1 - p0) * Pop(Math.Min(1, (now - _fill.at) / 800));
            var gc = s.NewId("gv");
            s.Def($"<clipPath id=\"{gc}\"><path d=\"{UiSvg.RRect(gx, gy, gw, 18, new[] { 9f, 9, 9, 9 })}\"/></clipPath>");
            float fw = (float)(gw * pct / 100), fb = Bw(1.5f);
            if (fw > 0)
            {
                s.Open($"clip-path=\"url(#{gc})\"");
                s.Box(gx, gy, fw, 18, new BoxStyle { Radius = 9, Gradient = new[] { "#fff6c4", "#ffd84a", "#e8a020" }, GradientStops = new[] { 0f, 0.45f, 1 } });
                Inset(s, gx + fb, gy + fb, fw - 2 * fb, 18 - 2 * fb, 9 - fb, 0, 1.5f, 0, "rgba(255,255,255,0.75)");
                if (n >= rw.Need)
                {
                    var fc = s.NewId("fc");
                    s.Def($"<clipPath id=\"{fc}\"><path d=\"{UiSvg.RRect(gx + fb, gy + fb, Math.Max(0, fw - 2 * fb), 18 - 2 * fb, new[] { 9 - fb, 9 - fb, 9 - fb, 9 - fb })}\"/></clipPath>");
                    s.Open($"clip-path=\"url(#{fc})\"");
                    ShineBand(s, gx + fb, gy + fb, fw - 2 * fb, 18 - 2 * fb, 0.45f, now - _revealAt, 1800, 1200, 0.8f);
                    s.Close();
                }
                s.Box(gx, gy, fw, 18, new BoxStyle { Radius = 9, BorderWidth = fb, BorderColor = "#7a4510" });
                s.Close();
            }
            var ct = T(Display, 14, "#ffffff", 0.8f, 0, new[] { new Shadow("#4a1f04", 0, 1.5f, 0), new Shadow("#4a1f04", 1.5f, 0, 0), new Shadow("#4a1f04", -1.5f, 0, 0), new Shadow("#4a1f04", 0, -1, 0) });
            string txt = $"{Prof.JsStr(n)} / {Prof.JsStr(rw.Need)}";
            TxtC(s, txt, gx + gw / 2, gy + (18 - LH(ct)) / 2, ct);
        }

        // ---- THE UNLOCK (host.html: #merge, mergeStart / mgFrame / cardAt / bam / heroUp) ---------------------------------
        // A creature's copies are counted toward unlocking it (rw.need of them, 5 to 14 by rarity); `isNew` with a count is
        // the copy that unlocks it.
        static bool Unlocks(Reward rw) => rw != null && rw.IsNew && rw.Need > 1 && rw.Name != "";
        // The timeline (ms from the reveal opening): the copies found before fan out of the middle one after another (OUT,
        // STEP apart, FLY each), the new one flies up from the chest (NEW) once they're nearly all out, a moment (HOLD), the
        // ring spins in (GATHER), the stack shakes (CHARGE), BAM; the rest of the reveal comes in SIDE after the BAM.
        const double OUT = 150, STEP = 55, FLY = 480, NEW = 650, HOLD = 330, GATHER = 1000, CHARGE = 430, SIDE = 350;

        sealed class Mc { public int J; public bool IsNew, Landed; public double S, End, Tilt; public double X, Y, Rot, Sc, Op, Hot; }
        sealed class Bit { public double Dx, Dy, Fall, R, D; public string C; public bool Star; }
        sealed class Mg
        {
            public Reward Rw; public int N, Count; public double T0, NewAt, NewEnd, Gather, Charge, Bam;
            public bool Flew, Full, Gathering, Bammed, Side, Quiet, Done;
            public double Cx, Cy, Mw, Mh, Rx, Ry, Wd, Ht;
            public readonly List<Mc> Cards = new List<Mc>();
            public double CountOp, CountSc = 1, CountPop = -1e9, GlowOp, GlowSc = 0.4, BurstAt, SideAt;
            public readonly List<(double x, double y, double at)> Pings = new List<(double, double, double)>();
            public readonly List<Bit> Bits = new List<Bit>();
        }
        Mg _mg;
        static double Clamp(double v, double a, double b) => Math.Max(a, Math.Min(b, v));
        static double SM(double x) { x = Clamp(x, 0, 1); return x * x * (3 - 2 * x); }
        static double OutQ(double u) => 1 - (1 - u) * (1 - u);
        static double InQ(double u) => u * u;
        static double OutC(double u) => 1 - Math.Pow(1 - u, 3);
        static double OutBack(double u) { double v = u - 1; return 1 + 2.70158 * v * v * v + 1.70158 * v * v; }
        static double Bez(double a, double b, double c, double u) => (1 - u) * (1 - u) * a + 2 * (1 - u) * u * b + u * u * c;

        // the creature's place (#hero, where the card would be) and the ring round its middle, as big as the screen allows
        (float x, float y, float w, float h) HeroBox()
        {
            float cw = CW, ch = CardH(cw), mainH = ch + 7 + 24;
            return (20 + SideW + 22, 12 + (H - 24 - mainH) / 2, cw, ch);
        }

        void MergeStart(Reward rw)
        {
            int n = (int)Clamp((int)rw.Need, 2, 16);
            double newAt = OUT + (n - 1) * STEP + FLY * 0.5, newEnd = newAt + NEW, gather = newEnd + HOLD, charge = gather + GATHER;
            var mg = new Mg { Rw = rw, N = n, T0 = _t.Now, NewAt = newAt, NewEnd = newEnd, Gather = gather, Charge = charge, Bam = charge + CHARGE, Wd = W, Ht = H };
            for (int j = 0; j < n; j++)
            {
                bool isNew = j == n - 1;
                double s = isNew ? newAt : OUT + j * STEP;
                mg.Cards.Add(new Mc { J = j, IsNew = isNew, S = s, End = s + (isNew ? NEW : FLY), Tilt = (((j * 37) % 11) - 5) * 1.3 });
            }
            var (hx, hy, hw, hh) = HeroBox();
            mg.Cx = hx + hw / 2; mg.Cy = hy + hh * 0.45;
            mg.Mw = Math.Round(Clamp(Math.Min(W, H) * 0.155, 40, 64)); mg.Mh = mg.Mw * 2528 / 1696;
            mg.Rx = Clamp(Math.Min(Math.Min(mg.Cx - mg.Mw / 2 - 8, W - mg.Cx - mg.Mw / 2 - 8), W * 0.36), 60, 250);
            mg.Ry = Clamp(Math.Min(mg.Cy - mg.Mh / 2 - 6, H - mg.Cy - mg.Mh / 2 - 6), 50, 150);
            _mg = mg;
            _sideAt = -2;
        }

        // card j's place in the ring (clockwise from the top; the new one, last, just left of the top)
        (double x, double y, double a) Slot(int j) { var M = _mg; double a = -Math.PI / 2 + 2 * Math.PI * j / M.N; return (M.Cx + Math.Cos(a) * M.Rx, M.Cy + Math.Sin(a) * M.Ry, a); }

        void MgFrame()
        {
            var M = _mg;
            if (M.Done) return;
            double now = _t.Now, t = now - M.T0;
            if (t < M.Bam)
            {
                // the stack's shake (one for all of them: they're one stack by then)
                double cu = t >= M.Charge ? (t - M.Charge) / CHARGE : 0, amp = cu != 0 ? 1.5 + 6 * cu : 0;
                double jx = (Rnd() - 0.5) * 2 * amp, jy = (Rnd() - 0.5) * 2 * amp, jr = (Rnd() - 0.5) * 8 * cu;
                foreach (var c in M.Cards) CardAt(c, t, jx, jy, jr);
                if (!M.Flew && t >= M.NewAt) M.Flew = true;
                // the new one in: the count full, a ping where it landed
                if (!M.Full && t >= M.NewEnd)
                {
                    M.Full = true; M.Count = M.N; M.CountPop = now;
                    var (x, y, _) = Slot(M.N - 1);
                    M.Pings.Add((x, y, now));
                    var ping = M.Pings[M.Pings.Count - 1];
                    _t.SetTimeout(() => M.Pings.Remove(ping), 700);
                }
                if (!M.Gathering && t >= M.Gather) M.Gathering = true;
                // the count over the middle, fading as they gather into it
                double gu = t < M.Gather ? 0 : Clamp((t - M.Gather) / (GATHER * 0.35), 0, 1);
                M.CountOp = M.Count > 0 ? 1 - gu : 0; M.CountSc = 1 + 0.4 * gu;
                // the light in the middle: growing as they gather, blazing as they shake
                double go = 0, gs = 0.4;
                if (t >= M.Charge) { go = 0.85 + 0.15 * cu; gs = 1.1 + 0.25 * cu + 0.06 * Math.Sin(cu * 40); }
                else if (t >= M.Gather) { double u = (t - M.Gather) / GATHER; go = 0.25 + 0.6 * u; gs = 0.5 + 0.6 * u; }
                else if (t >= M.NewEnd - 200) { double u = Clamp((t - M.NewEnd + 200) / 500, 0, 1); go = 0.25 * u; gs = 0.4 + 0.1 * u; }
                M.GlowOp = go; M.GlowSc = gs;
                return;
            }
            if (!M.Bammed) Bam();
            double tb = t - M.Bam;
            // the light bursts out and fades
            double ub = Clamp(tb / 450, 0, 1);
            M.GlowOp = 1 - ub; M.GlowSc = 1.35 + 1.6 * OutQ(ub);
            if (!M.Side && tb >= SIDE) { M.Side = true; M.SideAt = now; SideIn(now); }
            if (tb > 1200) M.Done = true;
        }

        // one copy at time t: flying out to its place (or, the new one, up from the chest), bobbing there, spinning in with
        // the ring as it shrinks and they go white-hot, then shaking in the stack
        void CardAt(Mc c, double t, double jx, double jy, double jr)
        {
            var M = _mg; var (sx, sy, a0) = Slot(c.J);
            double x, y, s, rot, o, hot = 0;
            if (t < M.Gather)
            {
                double u = Clamp((t - c.S) / (c.End - c.S), 0, 1);
                if (u <= 0) { x = M.Cx; y = M.Cy; s = 0.3; rot = 0; o = 0; }
                else if (!c.IsNew)
                {
                    double e = OutBack(u), q = OutQ(u), a = a0 - (1 - q) * 1.2;
                    x = M.Cx + Math.Cos(a) * M.Rx * e; y = M.Cy + Math.Sin(a) * M.Ry * e;
                    s = 0.35 + 0.65 * q; rot = c.Tilt - (1 - q) * 220; o = Clamp(u * 5, 0, 1);
                }
                else
                {
                    // from where the chest stood, in an arc up and over, spinning, big
                    double e = OutC(u), p0x = M.Wd / 2, p0y = M.Ht * 0.8, kx = p0x + (sx - p0x) * 0.25, ky = Math.Min(p0y, sy) - M.Ht * 0.25;
                    x = Bez(p0x, kx, sx, e); y = Bez(p0y, ky, sy, e);
                    s = 1.7 - 0.7 * e; rot = c.Tilt - 540 * (1 - e); o = Clamp(u * 6, 0, 1);
                }
                if (u >= 1)
                {
                    if (!c.Landed) { c.Landed = true; if (!c.IsNew) { M.Count++; M.CountPop = _t.Now; } }
                    y += Math.Sin(t / 140 + c.J) * 2.5 * Clamp((t - c.End) / 300, 0, 1);
                }
            }
            else if (t < M.Charge)
            {
                // the ring swells a little, then spins in faster and faster
                double u = (t - M.Gather) / GATHER, spin = Math.PI * 2 * 1.2 * u * u;
                double rf = u < 0.15 ? 1 + 0.1 * Math.Sin(u / 0.15 * Math.PI / 2) : 1.1 * (1 - InQ((u - 0.15) / 0.85));
                x = M.Cx + Math.Cos(a0 + spin) * M.Rx * rf; y = M.Cy + Math.Sin(a0 + spin) * M.Ry * rf;
                s = 1 - 0.28 * u; rot = c.Tilt * (1 - u) + spin * 57.3 * 0.4; o = 1; hot = SM((u - 0.2) / 0.65);
            }
            else
            {
                // one stack, shaking harder, swelling, then squeezed small just before it bursts
                double u = (t - M.Charge) / CHARGE;
                x = M.Cx + jx; y = M.Cy + jy; rot = jr;
                s = 0.72 + 0.14 * Math.Sin(u * Math.PI) - 0.25 * SM((u - 0.72) / 0.28); o = 1; hot = 1;
            }
            // (as the page writes them: px to 0.1, degrees to 0.1, the scale to 0.001, the white-hot to 0.001)
            c.X = Math.Round(x - M.Mw / 2, 1); c.Y = Math.Round(y - M.Mh / 2, 1); c.Rot = Math.Round(rot, 1); c.Sc = Math.Round(s, 3); c.Op = o;
            if (Math.Abs(c.Hot - hot) > 0.004) c.Hot = Math.Round(hot, 3);
        }

        // BAM: the cards gone in a flash, a shockwave and sparks (the creature's rarity colour among the gold), the screen
        // shaking, the creature bursting out
        void Bam()
        {
            var M = _mg;
            M.Bammed = true; M.BurstAt = _t.Now;
            M.CountOp = 0;
            var cols = new[] { "#ffe27a", "#fff6c4", "#ffffff", "#ffb52e", M.Rw.RarBg ?? "#ffd84a" };
            const int n = 30;
            for (int i = 0; i < n; i++)
            {
                bool star = i % 3 == 0;
                double a = (double)i / n * Math.PI * 2 + Rnd() * 0.4, dd = 110 + Rnd() * 230;
                var b = new Bit { Star = star, Dx = Math.Round(Math.Cos(a) * dd), Dy = Math.Round(Math.Sin(a) * dd * 0.8) };
                b.Fall = Math.Round(50 + Rnd() * 100); b.R = Math.Round((Rnd() - 0.5) * 900); b.D = Math.Round((0.8 + Rnd() * 0.5) * 100) / 100 * 1000;
                if (!star) b.C = cols[i % cols.Length];
                M.Bits.Add(b);
            }
        }

        /// <summary>Where the app's live creature stands once the unlock's BAM has brought it out (host.html heroBox: its
        /// feet at 80 % of the creature's place, its body as big as fits 96 % x 66 % of it), and which creature: null until
        /// then. The live one (a CreatureView playing its recorded rig, Resources/Creatures) belongs there, popping out of
        /// the burst (popAt: it grows out of the light turning once, hops, lands with a squash and cheers); its still is
        /// drawn there meanwhile (heroImg, unPop), as the app shows it while its rig isn't ready.</summary>
        public (string key, float feetX, float feetY, float w, float h)? HeroRig
        {
            get
            {
                if (_mg == null || !_mg.Bammed || _reveal < 0) return null;
                var (x, y, w, h) = HeroBox();
                return (_mg.Rw.Key, x + w / 2, y + h * 0.8f, w * 0.96f, h * 0.66f);
            }
        }

        // the unlock's middle: the glow it stands in, its floor shadow, its still popping out and bobbing, its name under it
        void Hero(List<ScreenPiece> list, Reward rw, float x, float y, float cw, double now, float fade, Affine shake, double sms)
        {
            var M = _mg;
            if (M == null || !M.Bammed) return;
            float ch = CardH(cw);
            double bm = now - M.BurstAt;
            // the glow (c2Fade 0.4 s, then c2Glow 2.4 s: brighter by a quarter and back) and the floor shadow (in 0.3 s
            // after 0.35 s)
            {
                float gl = -0.32f * cw, gw = cw * 1.64f, gt = 0.04f * ch, gh = 0.88f * ch;
                double go = EaseOut(Math.Min(1, bm / 400)), br = bm < 400 ? 1 : Kf(bm, 2400, 400, new[] { 0, 0.5, 1 }, new[] { 1, 1.25, 1 }, EaseInOut, true);
                var s = new UiSvg(gw, gh);
                var g = s.NewId("hg");
                string Br(int r, int gg, int b, double a) => $"rgba({Math.Min(255, Math.Round(r * br))},{Math.Min(255, Math.Round(gg * br))},{Math.Min(255, Math.Round(b * br))},{F(a)})";
                s.Def($"<radialGradient id=\"{g}\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"{Br(255, 238, 170, 0.8)}\"/><stop offset=\"0.55\" stop-color=\"{Br(255, 214, 110, 0.32)}\"/><stop offset=\"1\" stop-color=\"rgba(255,214,110,0)\"/></radialGradient>");
                s.Raw($"<ellipse cx=\"{F(gw / 2)}\" cy=\"{F(gh / 2)}\" rx=\"{F(gw / 2)}\" ry=\"{F(gh / 2)}\" fill=\"url(#{g})\"/>");
                list.Add(Piece("hglow", s, x + gl, y + gt, (float)go * fade, shake, 0));
                double fo = Ease(Clamp((bm - 350) / 300, 0, 1));
                float fl = 0.16f * cw, fw = cw * 0.68f, ft = 0.77f * ch, fh = 0.06f * ch;
                var f = new UiSvg(fw, fh);
                var fg = f.NewId("hf");
                f.Def($"<radialGradient id=\"{fg}\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"rgba(40,20,5,0.5)\"/><stop offset=\"1\" stop-color=\"rgba(40,20,5,0)\"/></radialGradient>");
                f.Raw($"<ellipse cx=\"{F(fw / 2)}\" cy=\"{F(fh / 2)}\" rx=\"{F(fw / 2)}\" ry=\"{F(fh / 2)}\" fill=\"url(#{fg})\"/>");
                list.Add(Piece("hfloor", f, x + fl, y + ft, (float)fo * fade, shake, 0));
            }
            // its still (#heroImg, 96 % x 66 % from 14 % down, feet at the bottom): unPop 0.9 s cubic-bezier(0.2, 0.9, 0.3,
            // 1.2) about its feet, then c2Bob 2.4 s
            {
                float iw = cw * 0.96f, ih = ch * 0.66f, ix = x + cw * 0.02f, iy = y + ch * 0.14f;
                var at = new[] { 0, 0.35, 0.7, 0.85, 1 };
                double ty = Kf(bm, 900, 0, at, new[] { -0.34, -0.26, 0, 0, 0 }, Pop) * ih, sx = Kf(bm, 900, 0, at, new[] { 0.2, 1.15, 1.06, 0.97, 1 }, Pop), sy = Kf(bm, 900, 0, at, new[] { 0.2, 1.15, 0.9, 1.04, 1 }, Pop);
                double op = Kf(bm, 900, 0, new[] { 0, 0.35, 1 }, new[] { 0.0, 1, 1 }, Pop);
                var m = Affine.Translate(0, ty) * Affine.Translate(iw / 2, ih) * Affine.ScaleBy(sx, sy) * Affine.Translate(-iw / 2, -ih);
                if (bm >= 900) m = Affine.Translate(0, Kf(bm, 2400, 900, new[] { 0, 0.5, 1 }, new[] { 0.0, -5, 0 }, EaseInOut, true));
                var s = new UiSvg(iw, ih);
                Still(s, rw.Key, 0, 0, iw, ih, true);
                list.Add(Piece("heroImg", s, ix, iy, (float)Clamp(op, 0, 1) * fade, shake * m, 16));
            }
            // its name in the gold lettering under its feet (c2Pop 0.5 s after 0.15 s, once the side comes in)
            if (sms >= 0)
            {
                var gt = T(Display, 24, "#000", 0.8f, 27.6f);
                float nw = Kit.W(rw.Name, gt) + 4 * rw.Name.Count(c => c == ' ') + 24, nh = 27.6f;
                var s = new UiSvg(nw, nh);
                Gold(s, rw.Name, nw / 2, 0, 24, 27.6f, 0.8f, 4, 11);
                var (op, pm) = PopIn(sms, 150, nw, nh);
                list.Add(Piece("heroNm", s, 0, 0, op * fade, shake * Affine.Translate(x + cw / 2 - nw / 2, y + 0.83f * ch) * pm, 14));
            }
        }

        // the unlock's layer (#merge, over the reveal): the light in the middle, the copies, the count, the BAM's flash, its
        // two shockwaves and sparks, the pings where the new copy landed
        void Merge(List<ScreenPiece> list, double now, float fade)
        {
            var M = _mg;
            var shake = Affine.Identity;
            if (M.Bammed && now - M.BurstAt < 420)
            {
                var at = new[] { 0, 0.12, 0.26, 0.4, 0.55, 0.7, 0.85, 1 };
                double sm = now - M.BurstAt;
                shake = Affine.Translate(Kf(sm, 420, 0, at, new[] { 0.0, -8, 7, -6, 5, -3, 2, 0 }, Linear), Kf(sm, 420, 0, at, new[] { 0.0, 5, -6, -3, 4, 2, -1, 0 }, Linear));
            }
            float cx = (float)M.Cx, cy = (float)M.Cy;
            if (M.GlowOp > 0)
            {
                var s = new UiSvg(360, 360);
                var g = s.NewId("mg");
                s.Def($"<radialGradient id=\"{g}\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#fffff4\"/><stop offset=\"0.28\" stop-color=\"rgba(255,240,170,0.85)\"/><stop offset=\"0.6\" stop-color=\"rgba(255,206,100,0.35)\"/><stop offset=\"1\" stop-color=\"rgba(255,206,100,0)\"/></radialGradient>");
                s.Raw($"<circle cx=\"180\" cy=\"180\" r=\"180\" fill=\"url(#{g})\"/>");
                double gs = Math.Round(M.GlowSc, 3);
                list.Add(Piece("mgGlow", s, 0, 0, (float)Math.Round(M.GlowOp, 3) * fade, shake * Affine.Translate(cx, cy) * Affine.ScaleBy(gs, gs) * Affine.Translate(-180, -180), 0));
            }
            if (!M.Bammed)
            {
                float mw = (float)M.Mw, mh = (float)M.Mh;
                double gm = now - M.T0;
                foreach (var c in M.Cards)
                {
                    if (c.Op <= 0) continue;
                    var s = new UiSvg(mw, mh);
                    CardLayers(s, M.Rw, _gk, 0, 0, mw, 0, null, false);
                    if (c.Hot > 0)
                    {
                        float hx = mw * 0.03f, hy = mh * 0.02f, hw = mw * 0.94f, hh = mh * 0.96f;
                        var hs = s.NewId("hs");
                        s.Def($"<filter id=\"{hs}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"8\"/></filter>");
                        var hg = s.NewId("hh");
                        s.Def($"<radialGradient id=\"{hg}\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#fffef8\"/><stop offset=\"0.55\" stop-color=\"#fff4c8\"/><stop offset=\"1\" stop-color=\"#ffd86e\"/></radialGradient>");
                        string rr = $"rx=\"{F(hw * 0.11f)}\" ry=\"{F(hh * 0.07f)}\"";
                        s.Raw($"<g opacity=\"{F(c.Hot)}\"><rect x=\"{F(hx - 6)}\" y=\"{F(hy - 6)}\" width=\"{F(hw + 12)}\" height=\"{F(hh + 12)}\" {rr} fill=\"rgba(255,232,150,0.9)\" filter=\"url(#{hs})\"/><rect x=\"{F(hx)}\" y=\"{F(hy)}\" width=\"{F(hw)}\" height=\"{F(hh)}\" {rr} fill=\"url(#{hg})\"/></g>");
                    }
                    if (c.IsNew)
                    {
                        // the new copy: a gold ring and glow round it (c2Glow 0.9 s: brighter by a quarter and back)
                        double br = Kf(gm, 900, 0, new[] { 0, 0.5, 1 }, new[] { 1, 1.25, 1 }, EaseInOut, true);
                        float ox = -mw * 0.06f, oy = -mh * 0.06f, ow = mw * 1.12f, oh = mh * 1.12f;
                        var gf = s.NewId("ng");
                        s.Def($"<filter id=\"{gf}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"9\"/></filter>");
                        string Bc(int r, int g2, int b, double a) => $"rgba({Math.Min(255, Math.Round(r * br))},{Math.Min(255, Math.Round(g2 * br))},{Math.Min(255, Math.Round(b * br))},{F(a)})";
                        float rx = ow * 0.12f, ry = oh * 0.08f;
                        string Rr(float e) => $"x=\"{F(ox - e)}\" y=\"{F(oy - e)}\" width=\"{F(ow + 2 * e)}\" height=\"{F(oh + 2 * e)}\" rx=\"{F(rx + e)}\" ry=\"{F(ry + e)}\"";
                        // (box-shadows: painted outside the ::after's box only)
                        var oc = s.NewId("oc");
                        s.Def($"<clipPath id=\"{oc}\"><path clip-rule=\"evenodd\" d=\"M{F(ox - 60)} {F(oy - 60)} h{F(ow + 120)} v{F(oh + 120)} h{F(-(ow + 120))} Z M{F(ox + rx)} {F(oy)} H{F(ox + ow - rx)} A{F(rx)} {F(ry)} 0 0 1 {F(ox + ow)} {F(oy + ry)} V{F(oy + oh - ry)} A{F(rx)} {F(ry)} 0 0 1 {F(ox + ow - rx)} {F(oy + oh)} H{F(ox + rx)} A{F(rx)} {F(ry)} 0 0 1 {F(ox)} {F(oy + oh - ry)} V{F(oy + ry)} A{F(rx)} {F(ry)} 0 0 1 {F(ox + rx)} {F(oy)} Z\"/></clipPath>");
                        s.Raw($"<g clip-path=\"url(#{oc})\"><g filter=\"url(#{gf})\"><rect {Rr(7)} fill=\"{Bc(255, 214, 90, 0.85)}\"/></g><rect {Rr(3)} fill=\"{Bc(255, 226, 122, 1)}\"/></g>");
                    }
                    var m = Affine.Translate(c.X, c.Y) * About(mw, mh, Affine.Rotate(c.Rot) * Affine.ScaleBy(c.Sc, c.Sc));
                    list.Add(Piece("mc" + c.J, s, 0, 0, (float)c.Op * fade, m, 30));
                }
                // the count: gold lettering on a wood plaque, popping as each copy lands (mgPop 0.3 s), its gold ring when full
                if (M.CountOp > 0 && M.Count > 0)
                {
                    string txt = $"{M.Count} / {M.N}";
                    var gt = T(Display, 30, "#000", 0.8f, 34.5f);
                    float w = Kit.W(txt, gt) + 4 * 2 + 36 + 4, h = 34.5f + 10 + 4;
                    var s = new UiSvg(w, h);
                    if (M.Full) Plaque(s, 0, 0, w, h, 16, null, true);
                    else Plaque(s, 0, 0, w, h, 16, new Shadow("rgba(40,20,5,0.35)", 0, 8, 14));
                    Gold(s, txt, w / 2, 2 + 3, 30, 34.5f, 0.8f, 4, 11);
                    double pk = Kf(now - M.CountPop, 300, 0, new[] { 0, 0.4, 1 }, new[] { 1, 1.25, 1 }, Pop14);
                    double cs = Math.Round(M.CountSc, 3);
                    // #mgCount at (cx, cy), scaled about its box's middle; the plaque in it centred on its corner
                    var m = Affine.Translate(cx, cy) * Affine.Translate(w / 2, h / 2) * Affine.ScaleBy(cs, cs) * Affine.Translate(-w / 2, -h / 2) * Affine.Translate(-w / 2, -h / 2) * About(w, h, Affine.ScaleBy(pk, pk));
                    list.Add(Piece("mgCount", s, 0, 0, (float)M.CountOp * fade, m, 40));
                }
            }
            foreach (var (px, py, pat) in M.Pings) Ring(list, "mgPing" + pat, (float)px, (float)py, 110, 6, "rgba(255,240,180,0.95)", now - pat, 550, 0, fade, Affine.Identity);
            if (M.Bammed)
            {
                double bm = now - M.BurstAt;
                // the flash (mgFlash 0.75 s ease-out: in by 7 %, out), the light round the burst
                double fo = Kf(bm, 750, 0, new[] { 0, 0.07, 1 }, new[] { 0.0, 1, 0 }, EaseOut);
                if (fo > 0)
                {
                    var s = new UiSvg(W, H);
                    var g = s.NewId("fl");
                    float far = (float)Math.Sqrt(Math.Max(cx, W - cx) * Math.Max(cx, W - cx) + Math.Max(cy, H - cy) * Math.Max(cy, H - cy));
                    s.Def($"<radialGradient id=\"{g}\" gradientUnits=\"userSpaceOnUse\" cx=\"{F(cx)}\" cy=\"{F(cy)}\" r=\"{F(far)}\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.22\" stop-color=\"rgba(255,251,230,0.96)\"/><stop offset=\"0.55\" stop-color=\"rgba(255,228,150,0.75)\"/><stop offset=\"1\" stop-color=\"rgba(255,210,110,0.4)\"/></radialGradient>");
                    s.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(W)}\" height=\"{F(H)}\" fill=\"url(#{g})\"/>");
                    list.Add(Piece("mgFlash", s, 0, 0, (float)fo * fade, shake, 0));
                }
                Ring(list, "mgRing", cx, cy, 200, 10, "rgba(255,240,180,0.95)", bm, 650, 0, fade, shake);
                Ring(list, "mgRingB", cx, cy, 200, 5, "#ffffff", bm, 650, 100, fade, shake);
                // the sparks: stars and confetti flying out and falling (mgBit, each its own --d, --dx, --dy, --fall, --r)
                for (int i = 0; i < M.Bits.Count; i++)
                {
                    var b = M.Bits[i];
                    var at = new[] { 0, 0.45, 1 };
                    double op = Kf(bm, b.D, 0, at, new[] { 1.0, 1, 0 }, BitE);
                    if (op <= 0) continue;
                    double bx = Kf(bm, b.D, 0, at, new[] { 0, 0.8 * b.Dx, b.Dx }, BitE), by = Kf(bm, b.D, 0, at, new[] { 0, 0.8 * b.Dy, b.Dy + b.Fall }, BitE);
                    double br = Kf(bm, b.D, 0, at, new[] { 0, 0.5 * b.R, b.R }, BitE), bs = Kf(bm, b.D, 0, at, new[] { 0.5, 1, 0.9 }, BitE);
                    float bw = b.Star ? 16 : 9, bh = b.Star ? 16 : 13;
                    var s = new UiSvg(bw, bh);
                    if (b.Star) s.Raw("<svg x=\"0\" y=\"0\" width=\"16\" height=\"16\" viewBox=\"0 0 40 40\"><path d=\"M20 1 Q21.8 18.2 39 20 Q21.8 21.8 20 39 Q18.2 21.8 1 20 Q18.2 18.2 20 1Z\" fill=\"#fffbe0\" stroke=\"#ffc93a\" stroke-width=\"2\"/></svg>");
                    else s.Box(0, 0, 9, 13, new BoxStyle { Radius = 2, Background = b.C });
                    float ox = b.Star ? -8 : -4, oy = b.Star ? -8 : -6;
                    var m = shake * Affine.Translate(cx + ox, cy + oy) * Affine.Translate(bx, by) * About(bw, bh, Affine.Rotate(br) * Affine.ScaleBy(bs, bs));
                    list.Add(Piece("mgBit" + i, s, 0, 0, (float)op * fade, m, 2));
                }
            }
        }

        // a shockwave (.mgRing / .mgPing): a ring `bw` thick with a glow outside and in, mgRing (cubic-bezier(0.1, 0.7, 0.3,
        // 1)): from .15 of its size to 3.2 times, fading
        void Ring(List<ScreenPiece> list, string id, float cx, float cy, float d, float bw, string col, double ms, double dur, double delay, float fade, Affine shake)
        {
            double op = Kf(ms, dur, delay, new[] { 0, 1.0 }, new[] { 1.0, 0 }, RingE), sc = Kf(ms, dur, delay, new[] { 0, 1.0 }, new[] { 0.15, 3.2 }, RingE);
            if (op <= 0) return;
            var s = new UiSvg(d, d);
            var f = s.NewId("rg");
            s.Def($"<filter id=\"{f}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"10\"/></filter>");
            float r = d / 2;
            s.Raw($"<g filter=\"url(#{f})\"><circle cx=\"{F(r)}\" cy=\"{F(r)}\" r=\"{F(r - bw / 2)}\" fill=\"none\" stroke=\"rgba(255,220,120,0.8)\" stroke-width=\"{F(bw)}\"/></g>");
            s.Raw($"<circle cx=\"{F(r)}\" cy=\"{F(r)}\" r=\"{F(r - bw / 2)}\" fill=\"none\" stroke=\"{col}\" stroke-width=\"{F(bw)}\"/>");
            list.Add(Piece(id, s, 0, 0, (float)op * fade, shake * Affine.Translate(cx - r, cy - r) * About(d, d, Affine.ScaleBy(sc, sc)), 30));
        }
    }
}
