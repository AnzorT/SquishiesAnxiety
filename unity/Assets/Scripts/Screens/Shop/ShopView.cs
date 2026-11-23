// src/screens/ShopScreen.js, its royal branch (REDESIGN_V7-V9, landscape), as pure C#: on the wood, in the Stage's
// 393-tall units, the header (the back orb, "Shop", the coin and gem pills: tap one for Gems), the four tabs across the
// top (Daily, Chests, Deals, Gems; their red badges: the free / ad chests waiting, today's streak gift, 2X) and the tab:
//   Daily   (royal/ShopChestsRoyal.js ShopDailyRoyal): today's free chest (or its countdown), the Rare chest for a video
//           (FREE with Remove Ads; Unity has no ads yet, so WATCH only says so), the daily deal and the Lucky meter
//   Chests  (ShopChestsRoyal): a page per group (today's HOT ones, the season, the rest), its four chests, OPEN for the
//           price; the arrows, a swipe, the dots; the Rainbow line
//   Deals, Gems: ShopDeals.cs
// and over it the sheets (ShopSheets.cs: a chest's, the odds, not enough coins / gems) and the toasts. Every move goes
// to the server (OnSquad: the `squad` Cloud Function, ShopWrites); a chest's move hands the host the chest to open
// (OnOpenChest: the treasure vault and the smash, Screens/Chests). The profile listener brings the result in
// (SetProfile). The tab contents' timers and countdowns follow the clock (`now`).
// Not ported: the sounds, the tutorial's targets, the rewards flying into the pills (the pills count up instead).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;
using static SquishSquad.Screens.ShopArt;

namespace SquishSquad.Screens
{
    /// <summary>A chest on its way: the move (its server call) and the chest the smash shows while it answers.</summary>
    public sealed class ChestRequest
    {
        public string Group, Size;
        public Task<IDictionary<string, object>> Result;
        /// <summary>Chests already rolled (a bundle, a claim): the smash opens them one after the other.</summary>
        public List<IDictionary<string, object>> Rolled;
    }

    /// <summary>A rule error from the server ('not_enough_gems', 'deal_used' …): the message is its code.</summary>
    public sealed class SquadError : Exception { public SquadError(string code) : base(code) { } }

    public sealed partial class ShopView : IScreenView, IWheel
    {
        public readonly float W, H;
        readonly float K, SW;
        const float SH = 393;
        readonly Ticker _t;
        readonly Func<DateTime> _now;
        IDictionary<string, object> _profile;
        readonly IDictionary<string, object> _offers;
        readonly string[] _hidden;
        readonly List<string> _artIds;
        public string Tab { get; private set; }

        /// <summary>A squad move → its result, or a SquadError with the rule's code.</summary>
        public Func<string, Dictionary<string, object>, Task<IDictionary<string, object>>> OnSquad;
        /// <summary>A chest to open (the host shows the treasure vault and the smash; their COLLECT calls Collected).</summary>
        public Action<ChestRequest> OnOpenChest;
        /// <summary>A real-money product ('removeAds', 'gems450', 'offer:starter'): its grant, or null (not bought).</summary>
        public Func<string, Task<IDictionary<string, object>>> OnBuyProduct;
        /// <summary>The store's price label for a product (default: the set price, economy.js fallbackPriceLabel).</summary>
        public Func<string, string> PriceOf;
        public Action OnBack;
        /// <summary>A one-time offer seen for the first time (its window starts): id, ms.</summary>
        public Action<string, double> OnSeenOffer;
        /// <summary>A rewarded video before the ad chest (null: none in Unity yet).</summary>
        public Func<Task<bool>> ShowAd;

        public ShopView(IDictionary<string, object> profile, IDictionary<string, object> offers, string tab, float w, float h, Ticker ticker, Func<DateTime> now, string[] hidden = null)
        {
            ShopData.Ensure();
            _profile = profile ?? new Dictionary<string, object>();
            _offers = offers;
            W = w; H = h; _t = ticker; _now = now;
            K = StageK(w, h); SW = Math.Max(w, h) / K;
            _hidden = hidden ?? ShopData.Hidden;
            _artIds = ShopData.ArtIds(_hidden);
            Tab = tab ?? "chests";
            _day = Prof.DayKey(_now());
            Motion.Phase(_glow, 2400).Start();
            // the tab is built a couple of frames after the Shop opens (useAfterFirstFrame)
            _t.RequestAnimationFrame(() => _t.RequestAnimationFrame(() => BuildTab()));
        }

        public void SetProfile(IDictionary<string, object> p) { _profile = p ?? new Dictionary<string, object>(); _dirty = true; }
        public IDictionary<string, object> Profile => _profile;

        string _day;
        bool _built, _dirty = true;
        readonly AnimatedValue _glow = new AnimatedValue(0);
        readonly Hits _hits = new Hits();
        string _pressed;

        string PriceLabel(string key) => PriceOf?.Invoke(key) ?? ShopData.FallbackPrice(key, _offers);
        (double coins, double gems) Wallet => ShopData.Wallet(_profile);

        // ---- the tabs ------------------------------------------------------------------------------------------------------
        static readonly (string k, string label, string d)[] R_TABS =
        {
            ("daily", "Daily", "M4 6h16v14H4Z M4 10h16 M8 3v4 M16 3v4 M9 15l2 2 4-4"),
            ("chests", "Chests", "M4 10h16v9H4Z M4 10l2-5h12l2 5 M12 10v4"),
            ("deals", "Deals", "M3 12V4h8l10 10-8 8Z M7.5 7.5h.01"),
            ("gems", "Gems", "M6 3h12l4 6-10 12L2 9Z M2 9h20 M9 3l3 6 3-6"),
        };

        // the loops of the tab's pieces (made again when the tab is: React mounts it again)
        Loop[] _bob;
        Loop _dealBob;
        double _tabAt;

        void BuildTab()
        {
            _built = true;
            _tabAt = _t.Now;
            _bob = new Loop[4];
            for (int i = 0; i < 4; i++) _bob[i] = new Loop(_t, 2800, Tab == "chests" ? (i * 0.7 % 2.8) * 1000 : 0);
            _dealBob = new Loop(_t, 2600);
            _page = Math.Max(0, Math.Min(_page, 99));
            BuildDealsLoops();
            _dirty = true;
        }

        public void GoTab(string k)
        {
            if (k == Tab) { CloseSheet(); return; }
            Tab = k;
            CloseSheet();
            _scrollX = 0;
            if (_built) BuildTab();
        }

        // ---- the pointer -----------------------------------------------------------------------------------------------------
        float _downX, _downY;
        bool _down, _dragging;
        float _drag0;
        public void Down(float x, float y)
        {
            x /= K; y /= K;
            _down = true; _dragging = false; _downX = x; _downY = y;
            _pressed = _hits.At(x, y);
            _drag0 = Tab == "chests" ? _pageX : _scrollX;
        }

        public void Move(float x, float y)
        {
            if (!_down) return;
            x /= K; y /= K;
            if (_sheet != null) return;
            if (!_dragging && Math.Abs(x - _downX) > 8 && _downY > 108 && (Tab == "chests" || Tab == "deals")) { _dragging = true; _pressed = null; StopPaging(); }
            if (!_dragging) return;
            if (Tab == "chests") _pageX = Math.Max(0, Math.Min(Pages.Count - 1, _drag0 - (x - _downX) / SW));
            else ScrollDeals(_drag0 - (x - _downX));
        }

        public void Up(float x, float y)
        {
            if (!_down) return;
            _down = false;
            x /= K; y /= K;
            if (_dragging)
            {
                _dragging = false;
                if (Tab == "chests") GoPage((int)Math.Round(_pageX + (x < _downX ? 0.3 : x > _downX ? -0.3 : 0)));
                return;
            }
            var h = _hits.At(x, y);
            var p = _pressed;
            _pressed = null;
            if (h == null || h != p) return;
            Audio.Snd.Play("tap");
            Tap(h);
        }

        public void Wheel(float x, float y, float dy)
        {
            if (Tab == "deals" && _sheet == null) ScrollDeals(_scrollX + dy);
            else if (_sheet != null) SheetWheel(dy);
        }

        void Tap(string h)
        {
            if (h == "scrim" || h == "sheet-close") { CloseSheet(); return; }
            if (h == "sheet") return;
            if (h == "back") { OnBack?.Invoke(); return; }
            if (h == "pill-coins" || h == "pill-gems") { GoTab("gems"); return; }
            if (h.StartsWith("tab-")) { GoTab(h.Substring(4)); return; }
            if (h == "free") { FreeChest(); return; }
            if (h == "ad") { AdChest(); return; }
            if (h == "deal") { DealChest(); return; }
            if (h == "odds") { OpenSheet(new Sheet { Type = "odds" }); return; }
            if (h == "arrow-left") { GoPage(_at - 1); return; }
            if (h == "arrow-right") { GoPage(_at + 1); return; }
            if (h.StartsWith("art:")) { var a = h.Split(':'); OpenSheet(new Sheet { Type = "gchest", Gk = a[1], Size = a[2] }); return; }
            if (h.StartsWith("buy:")) { var a = h.Split(':'); BuyGroup(a[1], a[2]); return; }
            if (h == "sheet-buy" && _sheet != null) { BuyGroup(_sheet.Gk, _sheet.Size); return; }
            if (h == "broke-go") { GoTab("gems"); return; }
            if (TapDeals(h)) return;
        }

        // ---- the moves ---------------------------------------------------------------------------------------------------------
        bool _busy;
        static readonly Dictionary<string, string> ERRORS = new Dictionary<string, string>
        {
            ["deal_used"] = "You already got today's deal", ["no_videos_left"] = "No more free chests today", ["no_chest"] = "That chest is already open",
            ["empty_chest"] = "Nothing in that chest yet. Coming soon!", ["owned"] = "Already in your squad", ["not_for_sale"] = "Not for sale",
            ["not_yet"] = "Your free chest isn't ready yet", ["unknown_chest"] = "That chest isn't in the shop any more", ["claimed"] = "Already claimed",
            ["need_xp"] = "Open more chests to earn pass XP first", ["need_pass"] = "This reward needs the season pass", ["season_over"] = "The season is over",
            ["unknown_reward"] = "That reward isn't there any more", ["rainbow_locked"] = "Unlock the rest of the group first", ["rainbow_opened"] = "That Rainbow chest is already open",
        };

        /// <summary>A squad move; a rule error becomes the broke sheet (`broke`: how many more) or a toast.</summary>
        async Task<IDictionary<string, object>> Run(string move, Dictionary<string, object> args, Func<string, double> broke = null)
        {
            if (_busy) return null;
            _busy = true;
            try
            {
                if (OnSquad == null) throw new SquadError("offline");
                return await OnSquad(move, args ?? new Dictionary<string, object>());
            }
            catch (Exception e)
            {
                string code = e is SquadError ? e.Message : e.InnerException is SquadError ? e.InnerException.Message : e.Message;
                if ((code == "not_enough_gems" || code == "not_enough_coins") && broke != null) OpenSheet(new Sheet { Type = "broke", Cur = code == "not_enough_gems" ? "gems" : "coins", Need = broke(code) });
                else Flash(ERRORS.TryGetValue(code, out var m) ? m : "Something went wrong. Try again!");
                return null;
            }
            finally { _busy = false; }
        }

        /// <summary>openGroup: the smash comes up at once on `group`/`size` and plays the server's answer when it lands.</summary>
        void OpenGroup(string move, Dictionary<string, object> args, Func<string, double> broke, string group, string size)
        {
            if (_busy) return;
            CloseSheet();
            var task = Run(move, args, broke);
            OnOpenChest?.Invoke(new ChestRequest { Group = group, Size = size, Result = task });
        }

        void BuyGroup(string gk, string size)
        {
            if (size == "set" && ShopData.RainbowMode == "chest") { OpenRainbow(gk); return; }
            var T = ShopData.Sizes[ShopData.SizeI(size)];
            var w = Wallet;
            double have = T.Cur == "gems" ? w.gems : w.coins;
            if (have < T.Price) { OpenSheet(new Sheet { Type = "broke", Cur = T.Cur, Need = T.Price - have }); return; }
            Audio.Snd.Play("coin");
            OpenGroup("groupChest", new Dictionary<string, object> { ["group"] = gk, ["size"] = size }, _ => T.Price - have, gk, size);
        }

        void OpenRainbow(string gk)
        {
            var r = ShopData.RainbowProgress(_profile, gk, _artIds);
            if (r.reward == null || !_artIds.Contains(r.reward)) { Flash($"{ShopData.GroupName(gk)} has no Rainbow chest"); return; }
            if (Prof.Owns(_profile, r.reward)) { Flash($"{ShopData.ById[r.reward].Name} is already in your squad"); return; }
            if (!ShopData.RainbowReady(_profile, gk, _artIds)) { Flash($"Unlock every {ShopData.GroupName(gk)} pal to earn it: {r.have} / {r.need}"); return; }
            Audio.Snd.Play("coin");
            OpenGroup("rainbowChest", new Dictionary<string, object> { ["group"] = gk }, null, gk, "set");
        }

        /// <summary>Date.now(): the clock in ms since 1970 UTC.</summary>
        double NowMs => (_now().ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        void FreeChest()
        {
            if (Prof.Num(Prof.Get(_profile, "freeAt")) > NowMs && !Prof.Truthy(Prof.Get(_profile, "freeBonus"))) { Flash(ERRORS["not_yet"]); return; }
            bool welcome = !Prof.Owns(_profile, "1") && !Prof.Truthy(Prof.Get(_profile, "chestOpens"));
            OpenGroup("freeChest", null, null, welcome ? ShopData.ById["1"].Set : ShopData.Lineup(_day, _hidden)[0], "common");
        }

        int AdsUsed { get { var a = Prof.Map(Prof.Get(_profile, "adChests")); return a != null && Prof.Str(Prof.Get(a, "day")) == _day ? (int)Prof.Num(Prof.Get(a, "n")) : 0; } }

        async void AdChest()
        {
            if (AdsUsed >= ShopData.AdChests) { Flash("No more ad chests today. Back tomorrow!"); return; }
            void Claim() => OpenGroup("adChest", null, null, ShopData.Lineup(_day, _hidden)[1], "rare");
            if (Prof.Truthy(Prof.Get(_profile, "adsFree"))) { Claim(); return; }
            if (ShowAd == null) { Flash("No video right now. Try again in a moment"); return; }
            if (await ShowAd()) Claim();
        }

        void DealChest()
        {
            if (Prof.Str(Prof.Get(_profile, "dealDay")) == _day) { Flash(ERRORS["deal_used"]); return; }
            var w = Wallet;
            if (w.gems < ShopData.DealGems) { OpenSheet(new Sheet { Type = "broke", Cur = "gems", Need = ShopData.DealGems - w.gems }); return; }
            OpenGroup("dealChest", null, _ => ShopData.DealGems - w.gems, ShopData.Lineup(_day, _hidden)[0], ShopData.DealSize);
        }

        /// <summary>The smash's COLLECT on a chest (its server result): the toast the app shows.</summary>
        public void Collected(IDictionary<string, object> r)
        {
            var id = Prof.Get(r, "id");
            if (id == null) return;
            var c = ShopData.ById.TryGetValue(Prof.IsNum(id) ? Prof.JsStr(Prof.D(id)) : id.ToString(), out var cc) ? cc : null;
            if (c == null) return;
            var rb = Prof.Str(Prof.Get(r, "rainbow"));
            if (rb != null) Flash($"{c.Name} joined! The {ShopData.GroupName(rb)} Rainbow chest is yours to open");
            else if (Prof.Truthy(Prof.Get(r, "isNew"))) Flash($"{c.Name} joined your squad!");
            else if (Prof.Truthy(Prof.Get(r, "copies"))) Flash($"{c.Name}: {Prof.JsStr(Prof.Num(Prof.Get(r, "copies")))} / {Prof.JsStr(Prof.Num(Prof.Get(r, "need")))} found");
            else Flash($"{c.Name} again: +{Prof.Fmt(Prof.Num(Prof.Get(r, "dupeCoins")))} coins");
        }

        // ---- the toast (ShopScreen.js Toast: in 260 ms, 1.6 s, out 340 ms) -------------------------------------------------
        string _toast;
        readonly AnimatedValue _toastT = new AnimatedValue(0);
        int _toastKey;
        public string ToastText => _toast;

        public void Flash(string text)
        {
            _toast = text;
            int key = ++_toastKey;
            _toastT.StopAnimation();
            _toastT.SetValue(0);
            Animated.Sequence(Motion.Timing(_toastT, 1, 260, Motion.OutQuad), Animated.Delay(1600), Motion.Timing(_toastT, 2, 340))
                .Start(r => { if (key == _toastKey) _toast = null; });
        }

        // ---- pieces ------------------------------------------------------------------------------------------------------------
        public List<ScreenPiece> Pieces()
        {
            var today = Prof.DayKey(_now());
            if (today != _day) { _day = today; _dirty = true; }
            TickPaging();
            _hits.Clear();
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", WoodBg(SW, SH), SW, SH, 0, 0, 1, null, 0));
            Header(list);
            Tabs(list);
            if (_built)
            {
                if (Tab == "daily") Daily(list);
                else if (Tab == "chests") Chests(list);
                else if (Tab == "deals") Deals(list);
                else if (Tab == "gems") Gems(list);
            }
            SheetPieces(list);
            var staged = Staged(list, K);
            if (_toast != null) ToastPiece(staged);
            _dirty = false;
            return staged;
        }

        static readonly TextStyle PurseT = Ink(13.5f);

        void Header(List<ScreenPiece> list)
        {
            list.Add(Piece("orb-back", Xml("orb-back"), 40, 40, 16, 15 + (_pressed == "back" ? 2 : 0)));
            _hits.Add("back", 16, 15, 40, 40, 8);
            var (lw, lh) = LetteringSize("Shop", 30);
            var s = new UiSvg(lw, lh);
            Lettering(s, "Shop", "gold", 30, 0, 0);
            list.Add(Piece("title", s, 16 + 40 + 12, 12 + (46 - lh) / 2));
            // the pills, right to left
            var w = Wallet;
            float x = SW - 16;
            foreach (var (cur, n) in new[] { ("gems", w.gems), ("coins", w.coins) })
            {
                string text = Prof.Fmt(n);
                float pw = 32 + W(text, PurseT) + 14;
                x -= pw;
                var p = new UiSvg(pw, 32);
                Plaque(p, 0, 0, pw, 32, "vel");
                Contain(p, cur == "gems" ? Gem(0) : Coin(0), -15, -6, 44, 44);
                p.Text(text, 32, (32 - LH(PurseT)) / 2, PurseT);
                list.Add(Piece("pill-" + cur, p, x, 19 + (_pressed == "pill-" + cur ? 2 : 0), 1, null, 20));
                _hits.Add("pill-" + cur, x, 19, pw, 32);
                x -= 14 + 9;
            }
        }

        static readonly TextStyle TabOn = T(Kit.Display, 16, INK), TabOff = Ink(16), BadgeT = T(Black, 10, "#ffffff");

        Dictionary<string, string> Badges()
        {
            int ads = AdsUsed;
            int chest = (Prof.Num(Prof.Get(_profile, "freeAt")) <= NowMs ? 1 : 0) + (ads < ShopData.AdChests ? 1 : 0);
            bool streakWaiting = Prof.Str(Prof.Get(Prof.Map(Prof.Get(_profile, "shopStreak")), "last")) != _day;
            var first = Prof.Map(Prof.Get(_profile, "gemFirst"));
            bool doubleLeft = _offers == null || ShopData.Packs(_offers).Any(p => !Prof.Truthy(Prof.Get(first, Prof.Str(Prof.Get(p, "product")))));
            return new Dictionary<string, string> { ["daily"] = chest > 0 ? chest.ToString() : "", ["chests"] = "", ["deals"] = streakWaiting ? "1" : "", ["gems"] = doubleLeft ? "2X" : "" };
        }

        void Tabs(List<ScreenPiece> list)
        {
            var badges = Badges();
            float total = 4 * 124 + 3 * 14, x = (SW - total) / 2;
            foreach (var (k, label, d) in R_TABS)
            {
                bool on = k == Tab;
                var s = new UiSvg(124, 36);
                Plaque(s, 0, 0, 124, 36, on ? "gold" : "vel", 16);
                var lt = on ? TabOn : TabOff;
                float lw = W(label, lt), cw = 18 + 7 + lw, cx = (124 - cw) / 2;
                Icon(s, d, cx, 9, 18, on ? INK : CREAM, 2.4f, !on);
                s.Text(label, cx + 25, (36 - LH(lt)) / 2, lt);
                if (badges[k] != "")
                {
                    float bw = Math.Max(20, W(badges[k], BadgeT) + 14);
                    s.Box(124 + 8 - bw, -8, bw, 20, new BoxStyle { Radius = 10, Background = "#ff5a2a", BorderWidth = 2, BorderColor = "#ffffff" });
                    s.Text(badges[k], 124 + 8 - bw / 2 - W(badges[k], BadgeT) / 2, -8 + (20 - LH(BadgeT)) / 2, BadgeT);
                }
                list.Add(Piece("tab-" + k, s, x, 62 + (_pressed == "tab-" + k ? 2 : 0), 1, null, 12));
                _hits.Add("tab-" + k, x, 62, 124, 36);
                x += 124 + 14;
            }
        }

        void ToastPiece(List<ScreenPiece> list)
        {
            double t = _toastT.GetValue();
            float op = (float)Motion.Lerp(t, new[] { 0.0, 1, 2 }, new[] { 0.0, 1, 0 }), dy = (float)Motion.Lerp(t, new[] { 0.0, 1, 2 }, new[] { 12.0, 0, -6 });
            var tt = T(Kit.Display, 14, "#8a3a0e");
            float tw = W(_toast, tt), th = LH(tt);
            float iw = tw + 32, ih = th + 16, ow = iw + 5, oh = ih + 5 + 4;
            var s = new UiSvg(ow, oh);
            s.Box(0, 0, ow, oh, new BoxStyle { Radius = 999, Background = "#8a3a0e" });
            s.Box(2.5f, 2.5f, iw, ih, new BoxStyle { Radius = 999, Background = "#ffffff" });
            s.Text(_toast, 2.5f + 16, 2.5f + 8, tt);
            // (bottom: the window's height - 70, so its bottom edge is 70 dp from the top)
            list.Add(Piece("toast", s, (W - ow) / 2, 70 - oh + dy, op, null, 4));
        }

        // ---- Daily ----------------------------------------------------------------------------------------------------------
        static readonly TextStyle HeadTimer = T(Heavy, 11, CREAM);
        static TextStyle Note(float size, string color = CREAM) => T(Body, size, color);
        const float CARD_H = 206, CARDS_Y = 108 + 2 + 32 + 2 + 3;

        /// <summary>A column laid out with justifyContent: space-between in (y0, h) with its padding.</summary>
        static float[] Between(float y0, float h, float padT, float padB, params float[] hs)
        {
            // (with no room left it packs them from the top, as CSS does: no negative gaps)
            float sum = hs.Sum(), gap = hs.Length > 1 ? Math.Max(0, (h - padT - padB - sum) / (hs.Length - 1)) : 0;
            var ys = new float[hs.Length];
            float y = y0 + padT;
            for (int i = 0; i < hs.Length; i++) { ys[i] = y; y += hs[i] + gap; }
            return ys;
        }

        void PageHead(List<ScreenPiece> list, string id, float y, string tag, string[] tagBg, string title, string right, TextStyle rightT, bool chip)
        {
            var tagT = T(Black, 9, "#ffffff", 0.8f);
            float tagW = tag != null ? W(tag, tagT) + 16 + 3 : 0, tagH = LH(tagT) + 6 + 3;
            var (lw, lh) = LetteringSize(title, 24);
            float rw = W(right, rightT), rh = LH(rightT);
            float chipW = chip ? rw + 18 : rw, chipH = chip ? rh + 4 : rh;
            float total = (tag != null ? tagW + 10 : 0) + lw + 10 + chipW, x = (SW - total) / 2;
            var s = new UiSvg(total, 32);
            float cx = 0;
            if (tag != null)
            {
                s.Box(0, (32 - tagH) / 2, tagW, tagH, new BoxStyle { Radius = 999, Gradient = tagBg, GradientAngle = 90, BorderWidth = Bw(1.5f), BorderColor = "#ffffff" });
                s.Text(tag, Bw(1.5f) + 8, (32 - tagH) / 2 + Bw(1.5f) + 3, tagT);
                cx = tagW + 10;
            }
            Lettering(s, title, "gold", 24, cx, (32 - lh) / 2);
            cx += lw + 10;
            if (chip) s.Box(cx, (32 - chipH) / 2, chipW, chipH, new BoxStyle { Radius = 999, Background = "rgba(107,68,38,0.55)" });
            s.Text(right, cx + (chip ? 9 : 0), (32 - rh) / 2, rightT);
            list.Add(Piece(id, s, x, y, 1, null, 8));
        }

        void Daily(List<ScreenPiece> list)
        {
            var now = _now();
            var hot = ShopData.Lineup(_day, _hidden);
            bool welcome = !Prof.Owns(_profile, "1") && !Prof.Truthy(Prof.Get(_profile, "chestOpens"));
            int adsLeft = (int)Math.Max(0, ShopData.AdChests - AdsUsed);
            PageHead(list, "head", 110, null, null, "Today", $"Hot picks change in {ShopData.Hms(ShopData.UntilMidnight(now))}", HeadTimer, false);
            float x = (SW - (156 * 3 + 200 + 36)) / 2, y = CARDS_Y;
            // Free chest
            string freeGk = welcome ? ShopData.ById["1"].Set : hot[0];
            double freeAt = Prof.Num(Prof.Get(_profile, "freeAt"));
            int n = (freeAt <= NowMs ? 1 : 0) + (int)Prof.Num(Prof.Get(_profile, "freeBonus"));
            Tile(list, "free", x, y, "Free chest", "Every 4 hours", Chest(freeGk, "common-tile"), _bob[0]);
            if (n > 0) GoldBtn(list, "free", n > 1 ? $"OPEN FREE · {n}" : "OPEN FREE", x + (156 - 136) / 2, TileBtnY(y, 38), 136, 38, 15, true, "gold");
            else WaitPlaque(list, "free-wait", $"Next in {ShopData.Hms(freeAt - NowMs)}", 12.5f, x + 78, TileBtnY(y, 34));
            x += 156 + 12;
            // Rare chest for a video
            Tile(list, "ad", x, y, "Rare chest", "Watch and open", Chest(hot[1], "rare-tile"), _bob[1]);
            string adLabel = adsLeft > 0 ? $"{(Prof.Truthy(Prof.Get(_profile, "adsFree")) ? "FREE" : "WATCH")} · {adsLeft}" : "TOMORROW";
            GoldBtn(list, adsLeft > 0 ? "ad" : "ad-off", adLabel, x + 10, TileBtnY(y, 38), 136, 38, 15, false, adsLeft > 0 ? "gold" : "vel", adsLeft > 0 ? 1 : 0.55f);
            x += 156 + 12;
            Deal(list, hot[0], Prof.Str(Prof.Get(_profile, "dealDay")) == _day, x, y, now);
            x += 200 + 12;
            Lucky(list, x, y);
        }

        static readonly float TILE_LETTER = LetteringSize("Free chest", 17).h;
        static float NoteH(float size) => LH(Note(size));
        static float TileBtnY(float y, float bh) => Between(y, CARD_H, 10, 10, TILE_LETTER, NoteH(11), 112, bh)[3];

        void Tile(List<ScreenPiece> list, string id, float x, float y, string title, string sub, string art, Loop bob)
        {
            var s = new UiSvg(156, CARD_H);
            Plaque(s, 0, 0, 156, CARD_H, "vel", 18, 3, 2, 4);
            var ys = Between(0, CARD_H, 10, 10, TILE_LETTER, NoteH(11), 112, 38);
            var (lw, _) = LetteringSize(title, 17);
            Lettering(s, title, "white", 17, (156 - lw) / 2, ys[0]);
            TxtC(s, sub, 78, ys[1], Note(11));
            list.Add(Piece("tile-" + id, s, x, y, 1, null, 8));
            var a = new UiSvg(112, 112);
            Contain(a, art, 0, 0, 112, 112);
            list.Add(Piece("tile-art-" + id, a, x + 22, y + ys[2] + bob.PingPong(0, -6), 1, null, 0));
        }

        /// <summary>The royal Btn with a Lettering label (or `content` drawn into its face).</summary>
        void GoldBtn(List<ScreenPiece> list, string id, string label, float x, float y, float w, float h, float size, bool glow, string variant = "gold", float opacity = 1, float radius = 14, Action<UiSvg> content = null)
        {
            if (glow) BtnGlow(list, id, x, y, w, h, radius, _glow.GetValue());
            var s = new UiSvg(w, h);
            Plaque(s, 0, 0, w, h, variant, radius);
            if (content != null) content(s);
            else
            {
                var (lw, lh) = LetteringSize(label, size);
                Lettering(s, label, variant == "gold" ? "whiteB" : "white", size, (w - lw) / 2, (h - lh) / 2);
            }
            bool down = _pressed == id && opacity >= 1;
            list.Add(Piece("btn-" + id, s, x, y + (down ? 2 : 0), opacity, null, 8));
            if (opacity >= 1) _hits.Add(id, x, y, w, h);
        }

        /// <summary>A wood plaque with an InkText line (the countdowns, "Bought!"), centred on cx.</summary>
        void WaitPlaque(List<ScreenPiece> list, string id, string text, float size, float cx, float y)
        {
            var it = Ink(size);
            float w = W(text, it) + 24;
            var s = new UiSvg(w, 34);
            Plaque(s, 0, 0, w, 34, "vel", 14);
            s.Text(text, 12, (34 - LH(it)) / 2, it);
            list.Add(Piece(id, s, cx - w / 2, y, 1, null, 8));
        }

        void Deal(List<ScreenPiece> list, string gk, bool done, float x, float y, DateTime now)
        {
            var chipT = T(Kit.Display, 9.5f, INK, 0.8f);
            var timerT = T(Heavy, 9.5f, "#fff6c8");
            string name = ShopData.ChestName(gk, 3);
            var (nw, nh) = LetteringSize(name, 14);
            var noteT = Note(11, "#ffffff");
            float topH = Math.Max(20, LH(timerT)), rowH = Math.Max(16, LH(noteT)), bh = done ? 34 : 38;
            var ys = Between(0, CARD_H, 9, 9, topH, 96, nh, rowH, bh);
            var s = new UiSvg(200, CARD_H);
            Plaque(s, 0, 0, 200, CARD_H, "vel", 18, 3, 2, 4);
            string timer = $"Ends in {ShopData.Hms(ShopData.UntilMidnight(now))}";
            float chipW = W("DAILY DEAL", chipT) + 14, tw = chipW + 6 + W(timer, timerT), tx = (200 - tw) / 2;
            float cy = ys[0] + (topH - 20) / 2;
            Plaque(s, tx, cy, chipW, 20, "gold", 8);
            s.Text("DAILY DEAL", tx + 7, cy + (20 - LH(chipT)) / 2, chipT);
            s.Text(timer, tx + chipW + 6, ys[0] + (topH - LH(timerT)) / 2, timerT);
            Lettering(s, name, "gold", 14, (200 - nw) / 2, ys[2]);
            string line = $"+{Prof.Fmt(ShopData.DealCoins)} · {(ShopData.GROUP_LABEL.TryGetValue(gk, out var gl) ? gl : "")}";
            float rw = 16 + 4 + W(line, noteT), rx = (200 - rw) / 2;
            Contain(s, Coin(1), rx, ys[3] + (rowH - 16) / 2, 16, 16);
            s.Text(line, rx + 20, ys[3] + (rowH - LH(noteT)) / 2, noteT);
            list.Add(Piece("deal", s, x, y, 1, null, 8));
            // the art and its -50% badge, bobbing
            var a = new UiSvg(130, 96);
            Contain(a, Chest(gk, "legendary-deal"), 0, 0, 130, 96);
            var badgeT = T(Kit.Display, 13, "#a3001f");
            float bw = W("-50%", badgeT) + 14 + 4, bhh = LH(badgeT) + 6 + 4;
            a.Open($"transform=\"translate({F(130 + 6 - bw / 2)} {F(4 + bhh / 2)}) rotate(12) translate({F(-bw / 2)} {F(-bhh / 2)})\"");
            a.Box(0, 0, bw, bhh, new BoxStyle { Radius = 10, Gradient = new[] { "#fff3b0", "#ffd83a", "#ffb000" }, BorderWidth = 2, BorderColor = INK });
            a.Text("-50%", 9, 5, badgeT);
            a.Close();
            list.Add(Piece("deal-art", a, x + 35, y + ys[1] + _dealBob.PingPong(0, -7), 1, null, 24));
            if (done) WaitPlaque(list, "deal-wait", "Bought! New deal tomorrow", 12, x + 100, y + ys[4]);
            else
                GoldBtn(list, "deal", null, x + 12, y + ys[4], 176, 38, 0, true, "gold", 1, 14, b =>
                {
                    var wasT = T(Heavy, 12, "#8a4a06");
                    string was = Prof.JsStr(ShopData.DealWas), price = Prof.Fmt(ShopData.DealGems);
                    var (pw, ph) = LetteringSize(price, 19);
                    float rw2 = W(was, wasT) + 2 + 5 + 24 + 5 + pw, x0 = (176 - rw2) / 2;
                    Strike(b, was, x0, (38 - LH(wasT)) / 2, wasT);
                    x0 += W(was, wasT) + 2 + 5;
                    Contain(b, Gem(0), x0, 7, 24, 24);
                    Lettering(b, price, "whiteB", 19, x0 + 29, (38 - ph) / 2);
                });
        }

        void Lucky(List<ScreenPiece> list, float x, float y)
        {
            double max = ShopData.LuckMax;
            int n = (int)Math.Min(Prof.Num(Prof.Get(_profile, "epic")), max);
            int left = (int)Math.Max(1, max - n);
            string note = $"Epic or better in {left} {(left == 1 ? "chest" : "chests")}";
            var (lw, lh) = LetteringSize("Lucky meter", 16);
            var noteT = Note(11);
            var linkT = T(Heavy, 11, CREAM);
            float linkH = LH(linkT) + 10, linkW = W("Drop odds", linkT) + 24;
            float total = 34 + 7 + lh + 7 + LH(noteT) + 7 + 13 + 7 + 6 + linkH;
            float cy = (CARD_H - total) / 2;
            var s = new UiSvg(156, CARD_H);
            Plaque(s, 0, 0, 156, CARD_H, "vel", 18, 3, 2, 4);
            s.Drawing($"<path d=\"M12 2L14.6 8.6L21.5 9.2L16.2 13.7L17.9 20.5L12 16.8L6.1 20.5L7.8 13.7L2.5 9.2L9.4 8.6Z\" fill=\"#ffc928\" stroke=\"{INK}\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/>", 61, cy, 34, 34, "0 0 24 24");
            cy += 34 + 7;
            Lettering(s, "Lucky meter", "white", 16, (156 - lw) / 2, cy);
            cy += lh + 7;
            TxtC(s, note, 78, cy, noteT);
            cy += LH(noteT) + 7;
            float bx = 8 + (140 - (10 * (float)max + 3 * ((float)max - 1))) / 2;
            for (int i = 0; i < max; i++)
                s.Box(bx + i * 13, cy, 10, 13, new BoxStyle { Radius = 4, Background = i < n ? (i >= max - 3 ? "#ff8a1e" : "#ffd24a") : "rgba(107,68,38,0.35)" });
            cy += 13 + 7 + 6;
            float lx = (156 - linkW) / 2;
            s.Box(lx, cy, linkW, linkH, new BoxStyle { Radius = 999, Background = "rgba(107,68,38,0.45)" });
            s.Text("Drop odds", lx + 12, cy + 5, linkT);
            list.Add(Piece("lucky", s, x, y, 1, null, 8));
            _hits.Add("odds", x + lx, y + cy, linkW, linkH);
        }

        // ---- Chests: a page per group ----------------------------------------------------------------------------------------
        List<ShopData.GroupPageInfo> _pages;
        string _pagesDay;
        List<ShopData.GroupPageInfo> Pages
        {
            get { if (_pages == null || _pagesDay != _day) { _pages = ShopData.AllChests(_day, _hidden); _pagesDay = _day; } return _pages; }
        }
        int _page, _at;
        float _pageX;   // the list's offset in pages (moves while it slides)
        CompositeAnimation _slide;
        readonly AnimatedValue _slideV = new AnimatedValue(0);
        bool _sliding;

        void StopPaging() { _slide?.Stop(); _sliding = false; }

        /// <summary>FlatList scrollToIndex({ animated: true }): the browser's smooth scroll, ~a third of a second.</summary>
        void GoPage(int i)
        {
            int n = Math.Max(0, Math.Min(Pages.Count - 1, i));
            _at = n;
            _page = n;
            float from = _pageX;
            _slideV.StopAnimation();
            _slideV.SetValue(0);
            _sliding = true;
            _slide = Motion.Timing(_slideV, 1, 350, Easing.InOut(Easing.Ease));
            _slide.Start(r => _sliding = false);
            _slideFrom = from;
        }
        float _slideFrom;

        void TickPaging()
        {
            if (_sliding) _pageX = _slideFrom + (_page - _slideFrom) * (float)_slideV.GetValue();
            else if (!_dragging && Tab == "chests") _pageX = _page;
            if (Tab == "chests") _at = (int)Math.Round(_pageX);
        }

        static readonly string[] SIZE_INK = { "#8a5a34", "#1f6fd6", "#8a2ad8", "#c46a00" };
        static readonly string[][] SIZE_DOT = { new[] { "#f5e6d3", "#b08a68" }, new[] { "#d4ecff", "#2f8cff" }, new[] { "#ecd8ff", "#a24bf0" }, new[] { "#fff3b8", "#f08c00" }, new[] { "#ff8fd8", "#ffe38a", "#9ff7c8", "#9fd8ff", "#d6b3ff" } };

        void Chests(List<ScreenPiece> list)
        {
            var pages = Pages;
            int first = (int)Math.Floor(_pageX), last = (int)Math.Ceiling(_pageX);
            for (int i = Math.Max(0, first); i <= Math.Min(pages.Count - 1, last); i++)
                GroupPage(list, pages[i], (i - _pageX) * SW, i == 0);
            // the arrows and the dots
            bool lOff = _at == 0, rOff = _at >= pages.Count - 1;
            float ay = 108 + 285 / 2f - 36;
            list.Add(Piece("orb-left", Xml("orb-left"), 40, 40, 16, ay + (_pressed == "arrow-left" && !lOff ? 2 : 0), lOff ? 0.35f : 1));
            list.Add(Piece("orb-right", Xml("orb-right"), 40, 40, SW - 56, ay + (_pressed == "arrow-right" && !rOff ? 2 : 0), rOff ? 0.35f : 1));
            if (!lOff) _hits.Add("arrow-left", 16, ay, 40, 40, 8);
            if (!rOff) _hits.Add("arrow-right", SW - 56, ay, 40, 40, 8);
            float dw = 16 + (pages.Count - 1) * 6 + (pages.Count - 1) * 5;
            var d = new UiSvg(dw, 6);
            float dx = 0;
            for (int i = 0; i < pages.Count; i++)
            {
                bool on = i == _at;
                d.Box(dx, 0, on ? 16 : 6, 6, new BoxStyle { Radius = 3, Background = on ? CREAM : "rgba(107,68,38,0.45)" });
                dx += (on ? 16 : 6) + 5;
            }
            list.Add(Piece("dots", d, (SW - dw) / 2, SH - 3 - 6, 1, null, 0));
        }

        static readonly string[] SOLD = { "common", "rare", "epic", "legendary" };

        void GroupPage(List<ScreenPiece> list, ShopData.GroupPageInfo g, float ox, bool first)
        {
            var c0 = ShopData.Chest(g.K, "common", _profile, _artIds);
            string label = ShopData.GROUP_LABEL.TryGetValue(g.K, out var gl) ? gl : g.K;
            PageHead(list, "head-" + g.K, 110, g.Tag != "" ? g.Tag : null, g.TagBg, label, $"{c0.Have} / {c0.Pool.Count} collected", T(Heavy, 10.5f, CREAM), true);
            Shift(list, ox);
            float x = (SW - (160 * 4 + 36)) / 2 + ox, y = CARDS_Y;
            for (int ti = 0; ti < 4; ti++)
            {
                var info = ti == 0 ? c0 : ShopData.Chest(g.K, SOLD[ti], _profile, _artIds);
                ChestCard(list, g.K, SOLD[ti], ti, info, x, y);
                x += 160 + 12;
            }
            RainbowLine(list, g.K, ox);
        }

        /// <summary>Moves the last piece by dx (a page's head as the list slides).</summary>
        static void Shift(List<ScreenPiece> list, float dx)
        {
            var p = list[list.Count - 1];
            p.Transform = Affine.Translate(dx, 0) * p.Transform;
        }

        static readonly TextStyle SizeChipT0 = T(Black, 9, "#000", 0.8f);

        void ChestCard(List<ScreenPiece> list, string gk, string size, int ti, ChestInfo C, float x, float y)
        {
            var (nw, nh) = LetteringSize(C.Name, 13);
            var oddsT = Note(10);
            float bh = 38;
            var ys = Between(0, CARD_H, 8, 10, 112, nh, LH(oddsT), bh);
            var s = new UiSvg(160, CARD_H);
            Plaque(s, 0, 0, 160, CARD_H, "vel", 18, 3, 2, 4);
            // the backdrop (cover, inside the gold border)
            var clip = s.NewId("ct");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(10, ys[0] + 2, 140, 108, new[] { 10f, 10, 10, 10 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            Cover(s, Backdrop(gk), 10, ys[0] + 2, 140, 108);
            s.Close();
            s.Box(8, ys[0], 144, 112, new BoxStyle { Radius = 12, BorderWidth = 2, BorderColor = "#ffd76a" });
            Lettering(s, C.Name, "white", 13, (160 - nw) / 2, ys[1]);
            string odds = Ellipsize(C.Odds, oddsT, 144);
            TxtC(s, odds, 80, ys[2], oddsT);
            list.Add(Piece($"card-{gk}-{size}", s, x, y, 1, null, 8));
            _hits.Add($"art:{gk}:{size}", x + 8, y + ys[0], 144, 112);
            // the art, bobbing, and the size chip over it
            var a = new UiSvg(116, 100);
            Contain(a, Chest(gk, size + "-grow"), 0, 0, 116, 100);
            list.Add(Piece($"art-{gk}-{size}", a, x + 22, y + ys[0] + 6 + _bob[ti].PingPong(0, -7), 1, null, 0));
            var chipT = T(Black, 9, SIZE_INK[ti], 0.8f);
            string chip = ShopData.SIZE_NAME[ti].ToUpperInvariant();
            float cw = W(chip, chipT) + 14 + 2 * Bw(1.5f), ch = LH(chipT) + 4 + 2 * Bw(1.5f);
            var cs = new UiSvg(cw, ch);
            cs.Box(0, 0, cw, ch, new BoxStyle { Radius = 999, Gradient = SIZE_DOT[ti], GradientAngle = 135, BorderWidth = Bw(1.5f), BorderColor = "#ffffff" });
            cs.Text(chip, 7 + Bw(1.5f), 2 + Bw(1.5f), chipT);
            list.Add(Piece($"chip-{gk}-{size}", cs, x + 8 + 2 + 5, y + ys[0] + 2 + 5, 1, null, 2));
            // OPEN · price
            bool gems = C.T.Cur == "gems";
            string price = Prof.Fmt(C.T.Price);
            GoldBtn(list, $"buy:{gk}:{size}", null, x + 10, y + ys[3], 140, 38, 0, false, "gold", 1, 14, b =>
            {
                var (ow, oh) = LetteringSize("OPEN", 15);
                var (pw, ph) = LetteringSize(price, 15);
                float rw = ow + 5 + 22 + 5 + pw, x0 = (140 - rw) / 2;
                Lettering(b, "OPEN", "whiteB", 15, x0, (38 - oh) / 2);
                Contain(b, gems ? Gem(0) : Coin(0), x0 + ow + 5, 8, 22, 22);
                Lettering(b, price, "whiteB", 15, x0 + ow + 32, (38 - ph) / 2);
            });
        }

        void RainbowLine(List<ScreenPiece> list, string gk, float ox)
        {
            if (ShopData.RainbowMode != "chest") return;
            var C = ShopData.Chest(gk, "set", _profile, _artIds);
            var rb = C.Earned;
            float y = CARDS_Y - 3 + 212;
            if (rb == null || rb.Reward == null) return;
            if (rb.Ready && !rb.Opened)
            {
                GoldBtn(list, $"buy:{gk}:set", "RAINBOW CHEST READY · OPEN", (SW - 300) / 2 + ox, y - 3, 300, 32, 14, true);
                return;
            }
            var nt = Note(11);
            string text = rb.Opened ? $"{rb.Reward.Name}, this group's Rainbow, is in your squad." : $"Collect all {(ShopData.GROUP_LABEL.TryGetValue(gk, out var gl) ? gl : "this group")} pals for its Rainbow chest · {rb.Have} / {rb.Need}";
            float tw = 14 + 7 + W(text, nt);
            var s = new UiSvg(tw, 26);
            s.Box(0, 6, 14, 14, new BoxStyle { Radius = 7, Gradient = SIZE_DOT[4], GradientAngle = 90, BorderWidth = Bw(1.5f), BorderColor = "#ffffff" });
            s.Text(text, 21, (26 - LH(nt)) / 2, nt);
            list.Add(Piece("rb-" + gk, s, (SW - tw) / 2 + ox, y, 1, null, 4));
        }
    }
}
