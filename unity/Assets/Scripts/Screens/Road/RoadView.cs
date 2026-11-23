// src/screens/LevelRoadScreen.js, landscape (REDESIGN_V8), as pure C#: on the wood, the back orb, "Level Road", the
// player's level (its gold disc, the XP bar, the hint) and the coin / gem counters across the top; the road under them
// running left to right (a drag or the wheel; it opens on the first prize waiting, else the next one to reach): each
// level a column, its disc on the rail (gold once reached, the current one ringed) and its prize card (the coin, gem
// or chest picture, components/LevelBits.js PrizeArt; CLAIM once reached, a tick once claimed, the XP still to go or
// the level it needs); CLAIM ALL (n) under it when more than one waits; the toast. A claim is the server's (squad
// levelClaim / levelClaimAll, OnSquad); a chest prize opens in the smash (OnOpenChest, Screens/Chests). The road is
// config/levels' (ShopData.Levels: the default road while config/levels is missing).
// Not ported: the coins and gems flying out of the prize into the counters (the counters count when the profile
// brings the claim), the sounds, the next chests of a CLAIM ALL dropping in (they open one after the other).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Games.Sort;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;
using static SquishSquad.Screens.ShopArt;

namespace SquishSquad.Screens
{
    public sealed class RoadView : IScreenView, IWheel
    {
        public readonly float W, H;
        readonly Ticker _t;
        readonly Func<DateTime> _now;
        IDictionary<string, object> _profile;
        readonly string[] _hidden;
        public Func<string, Dictionary<string, object>, Task<IDictionary<string, object>>> OnSquad;
        public Action<ChestRequest> OnOpenChest;
        public Action OnBack;
        readonly Hits _hits = new Hits();

        const float COL = 128;
        static readonly string[] GOLD = { "#fff7b0", "#ffd23a", "#ff9c0a" };
        const string GOLD_RING = "#9c4d06";
        static readonly string[] WOOD = { "#e6b47c", "#cf955a", "#b47a42" };
        static readonly string[] BAR = { "#ffe08a", "#ffb347", "#f07a1c" };

        sealed class Node { public int Lv; public IDictionary<string, object> R; public bool Reached, Got, Claimable; }

        public RoadView(IDictionary<string, object> profile, float w, float h, Ticker ticker, Func<DateTime> now, string[] hidden = null, IList<int> autoClaim = null)
        {
            ShopData.Ensure();
            _profile = profile ?? new Dictionary<string, object>();
            W = w; H = h; _t = ticker; _now = now;
            _hidden = hidden ?? ShopData.Hidden;
            var nodes = Nodes();
            var cl = nodes.Where(n => n.Claimable).Select(n => n.Lv).ToList();
            var view = PlayerXp.PlayerLevel(PlayerXp.PxpOf(_profile));
            int i = cl.Count > 0 ? cl[0] - 1 : Math.Min(nodes.Count - 1, view.Level);
            _scroll = Math.Max(0, i - 1) * COL;
            if (autoClaim != null && autoClaim.Count > 0)
                _t.SetTimeout(() => Claim(autoClaim.Where(lv => lv - 1 < nodes.Count && nodes[lv - 1].Claimable).ToList()), 450);
        }

        public void SetProfile(IDictionary<string, object> p) => _profile = p ?? new Dictionary<string, object>();

        List<Node> Nodes()
        {
            var road = Prof.List(ShopData.Levels["road"]).Select(Prof.Map).ToList();
            int level = PlayerXp.PlayerLevel(PlayerXp.PxpOf(_profile)).Level;
            var got = Prof.Map(Prof.Get(_profile, "levelGot"));
            return road.Select((r, i) => { int lv = i + 1; bool reached = level >= lv, g = Prof.Truthy(Prof.Get(got, lv.ToString())); return new Node { Lv = lv, R = r, Reached = reached, Got = reached && g, Claimable = reached && !g }; }).ToList();
        }

        /// <summary>LevelBits.js prizeLabel: "1,200 coins", "50 gems", "Rare chest".</summary>
        public static string PrizeLabel(IDictionary<string, object> r)
        {
            if (r == null) return "";
            string k = Prof.Str(r["k"]);
            if (k == "coins") return $"{Prof.Fmt(Prof.Num(r["n"]))} coins";
            if (k == "gems") return $"{Prof.Fmt(Prof.Num(r["n"]))} gems";
            return $"{ShopData.SIZE_NAME[ShopData.SizeI(ShopData.ShownSize(Prof.Str(r["t"])))]} chest";
        }

        /// <summary>LevelBits.js PrizeArt: a coin or gem (one of the six, by i), or the chest of its size in `group`'s art
        /// (480 x 400 with the chest about half its width: drawn twice the size, spilling over its box).</summary>
        public static void PrizeArt(UiSvg s, IDictionary<string, object> r, string group, int i, float x, float y, float size, bool dim)
        {
            if (r == null) return;
            float op = dim ? 0.45f : 1;
            if (Prof.Str(r["k"]) == "chest")
            {
                float w = size * 2, h = w * 400 / 480;
                s.Image(Chest(ShopData.GroupOut(group, ShopData.Hidden) ? group : "snack", ShopData.ShownSize(Prof.Str(r["t"])) + "-grow"), x + (size - w) / 2, y + (size - h) / 2, w, h, "xMidYMid meet", op);
                return;
            }
            s.Image(Prof.Str(r["k"]) == "gems" ? Gem(i) : Coin(i), x, y, size, size, "none", op);
        }

        // ---- the road's scroll -----------------------------------------------------------------------------------------
        float _scroll;
        float ContentW(int n) => 16 + n * COL + 220 + 16;
        float Max(int n) => Math.Max(0, ContentW(n) - W);
        public void Wheel(float x, float y, float dy) { if (y > RoadY - 10) _scroll = Math.Max(0, Math.Min(Max(Nodes().Count), _scroll + dy)); }

        string _pressed;
        bool _down, _drag;
        float _dx, _dy, _s0;
        public void Down(float x, float y) { _down = true; _drag = false; _dx = x; _dy = y; _s0 = _scroll; _pressed = _hits.At(x, y); }
        public void Move(float x, float y)
        {
            if (!_down) return;
            if (!_drag && Math.Abs(x - _dx) > 8 && _dy > RoadY - 10) { _drag = true; _pressed = null; }
            if (_drag) _scroll = Math.Max(0, Math.Min(Max(Nodes().Count), _s0 - (x - _dx)));
        }
        public void Up(float x, float y)
        {
            if (!_down) return;
            _down = false;
            if (_drag) return;
            var h = _hits.At(x, y);
            var p = _pressed;
            _pressed = null;
            if (h == null || h != p) return;
            if (h == "back") OnBack?.Invoke();
            else if (h == "all") Claim(Nodes().Where(n => n.Claimable).Select(n => n.Lv).ToList());
            else if (h.StartsWith("claim:")) Claim(new List<int> { int.Parse(h.Substring(6)) });
        }

        // ---- claims ------------------------------------------------------------------------------------------------------
        bool _busy;
        static readonly Dictionary<string, string> ERRORS = new Dictionary<string, string>
        {
            ["claimed"] = "Already claimed", ["need_level"] = "Reach that level first", ["nothing_to_claim"] = "Nothing to claim yet", ["unknown_reward"] = "That prize isn't there any more",
        };

        public async void Claim(List<int> levels)
        {
            if (_busy || levels.Count == 0) return;
            _busy = true;
            var got = new List<IDictionary<string, object>>();
            try
            {
                if (OnSquad == null) throw new SquadError("offline");
                if (levels.Count > 1) got = (Prof.List(Prof.Get(await OnSquad("levelClaimAll", new Dictionary<string, object>()), "results")) ?? new List<object>()).Select(Prof.Map).ToList();
                else got.Add(await OnSquad("levelClaim", new Dictionary<string, object> { ["i"] = (double)levels[0] }));
            }
            catch (Exception e)
            {
                string code = e is SquadError ? e.Message : e.Message;
                Flash(ERRORS.TryGetValue(code, out var m) ? m : "Something went wrong. Try again!");
            }
            _busy = false;
            var chests = got.Where(r => Prof.Str(Prof.Get(r, "kind")) == "chest").Select(r => Prof.Map(r["chest"])).Where(c => c != null).ToList();
            if (chests.Count > 0) OnOpenChest?.Invoke(new ChestRequest { Group = Prof.Str(chests[0]["group"]), Size = Prof.Str(chests[0]["size"]), Rolled = chests });
        }

        // ---- the toast (components/squad/Toast.js: fade and rise 10, 220 ms; gone after 2.6 s) --------------------------
        string _toast;
        readonly AnimatedValue _toastV = new AnimatedValue(0);
        int _tk;
        public string ToastText => _toast;
        void Flash(string text)
        {
            _toast = text;
            int k = ++_tk;
            _toastV.SetValue(0);
            Motion.Timing(_toastV, 1, 220, Easing.InOut(Easing.Ease)).Start();
            _t.SetTimeout(() => { if (k == _tk) _toast = null; }, 2600);
        }

        // ---- pieces ------------------------------------------------------------------------------------------------------
        static readonly TextStyle DiscT = T(Kit.Display, 15, "#7a3d00"), MidNum = T(Kit.Display, 21, "#7a3d00");
        static readonly TextStyle BarText = T(Kit.Display, 12, "#ffffff", 0, 0, new[] { new Shadow("#3f2412", 0, 1, 3) });
        static readonly TextStyle Hint = T(Heavy, 11, CREAM), Prize = T(Kit.Display, 15, "#5b3418", 0, 18), LockT = T(Black, 11, "#8a7560"), Foot = T(Heavy, 12, "#5b3418");
        float RoadY;

        public List<ScreenPiece> Pieces()
        {
            _hits.Clear();
            var list = new List<ScreenPiece>();
            var nodes = Nodes();
            var view = PlayerXp.PlayerLevel(PlayerXp.PxpOf(_profile));
            var claimable = nodes.Where(n => n.Claimable).Select(n => n.Lv).ToList();
            list.Add(Piece("bg", WoodBg(W, H), W, H, 0, 0, 1, null, 0));
            // the top row: orb, title, the level ring (flex 1, max 300), the counters
            var (tw, th) = LetteringSize("Level Road", 26);
            float innerH = Math.Max(44, 22 + 5 + LH(Hint)) + 12 + 2 * Bw(3), ringH = innerH + 2 * 2.5f + 4;
            float rowH = Math.Max(Math.Max(40, th), ringH);
            float y0 = 10, cy = y0 + rowH / 2;
            var w = ShopData.Wallet(_profile);
            var pT = T(Black, 13.5f, "#b86200"); var gT = T(Black, 13.5f, "#1d6fb8");
            float bw = Bw(2.5f);
            float coinW = 2 + bw + 7 + (22 - 4) + 5 + W(Prof.Fmt(w.coins), pT) + 9 + bw + 2;
            float gemW = 2 + bw + 7 + (24 - 5) + 5 + W(Prof.Fmt(w.gems), gT) + 9 + bw + 2;
            float purseH = 2 + bw + 4 + Math.Max(LH(pT), 22 - 10) + 4 + bw + 2 + 3;
            float pursesW = coinW + 6 + gemW;
            float x = 16;
            list.Add(Piece("orb-back", Xml("orb-back"), 40, 40, x, cy - 20 + (_pressed == "back" ? 2 : 0)));
            _hits.Add("back", x, cy - 20, 40, 40, 8);
            x += 40 + 12;
            var ts = new UiSvg(tw, th);
            Lettering(ts, "Level Road", "gold", 26, 0, 0);
            list.Add(Piece("title", ts, x, cy - th / 2));
            x += tw + 12;
            float ringW = Math.Min(300, W - 16 - pursesW - 12 - x);
            LevelRing(list, x, cy - ringH / 2, ringW, ringH, innerH, view);
            Purse(list, "coins", W - 16 - pursesW, cy - purseH / 2, coinW, purseH, Prof.Fmt(w.coins), pT, Coin(0), 22, 4, 5);
            Purse(list, "gems", W - 16 - gemW, cy - purseH / 2, gemW, purseH, Prof.Fmt(w.gems), gT, Gem(0), 24, 5, 6);
            // the road and CLAIM ALL, centred in what's under the top row
            float topBottom = y0 + rowH + 4;
            // (the list is as tall as its tallest column, the current level's (its disc is 42), and shrinks to leave room for
            // CLAIM ALL (a ScrollView shrinks in a column); justifyContent center)
            var allBtn = claimable.Count > 1 ? new CandyBtnArt($"CLAIM ALL ({claimable.Count})", _busy ? "grey" : "gold", 8, 26, 5, 17) : null;
            float midH = H - topBottom - 8;
            float colH = Math.Min(4 + 42 + 8 + (168 + 2 * 2 + 3), midH - (allBtn != null ? 12 + allBtn.H : 0));
            float total = colH + (allBtn != null ? 12 + allBtn.H : 0);
            float ry = topBottom + (midH - total) / 2;
            RoadY = ry;
            var group = ShopData.Lineup(Prof.DayKey(_now()), _hidden)[0];
            _scroll = Math.Min(_scroll, Max(nodes.Count));
            int first = Math.Max(0, (int)Math.Floor((_scroll - 16) / COL) - 1), last = Math.Min(nodes.Count - 1, (int)Math.Ceiling((_scroll + W) / COL));
            for (int i = first; i <= last; i++) Column(list, nodes[i], 16 + i * COL - _scroll, ry, i == nodes.Count - 1, nodes[i].Lv == view.Level, group, nodes[i].Lv == view.Level + 1 ? view.Need - view.Into : 0, nodes.Count);
            float fx = 16 + nodes.Count * COL - _scroll;
            if (fx < W)
            {
                var ff = new TextFlow($"The road ends at level {nodes.Count}. Every level after it still counts toward your trophies.", Foot);
                float fw = 220 - 32, fh = ff.Measure(fw).h;
                var fs = new UiSvg(fw, fh);
                ff.Draw(fs, 0, 0, fw);
                list.Add(Piece("foot", fs, fx + 16, ry, 1, null, 2));
            }
            if (allBtn != null)
            {
                float bx = (W - allBtn.W) / 2, by = ry + colH + 12;
                list.Add(Piece("all", allBtn.Svg(), allBtn.W, allBtn.H, bx, by + (_pressed == "all" ? 3 : 0), 1, null, 8));
                if (!_busy) _hits.Add("all", bx, by, allBtn.W, allBtn.H);
            }
            if (_toast != null)
            {
                var tt = T(Body, 12.5f, "#5b3418");
                float tw2 = W(_toast, tt) + 40 + 3, th2 = LH(tt) + 20 + 3;
                var s = new UiSvg(tw2, th2);
                s.Box(0, 0, tw2, th2, new BoxStyle { Radius = 999, Background = "#ffffff", BorderWidth = Bw(1.5f), BorderColor = "#7a4a24" });
                s.Text(_toast, 20 + Bw(1.5f), 10 + Bw(1.5f), tt);
                double v = _toastV.GetValue();
                list.Add(Piece("toast", s, (W - tw2) / 2, H - 8 - 24 - th2 + (float)(10 * (1 - v)), (float)v, null, 4));
            }
            return list;
        }

        void LevelRing(List<ScreenPiece> list, float x, float y, float w, float h, float innerH, PlayerLevelInfo view)
        {
            var s = new UiSvg(w, h);
            ShopView.CandyRingedPublic(s, 0, 0, w, innerH, "#6b4426", WOOD, 4, 2.5f, 3, false, 18);
            float ix = 2.5f + Bw(3) + 10, iy = 2.5f + (innerH - 44) / 2;
            s.Box(ix, iy, 44, 44, new BoxStyle { Radius = 22, Gradient = GOLD, GradientStops = new[] { 0f, 0.5f, 1 }, BorderWidth = Bw(2.5f), BorderColor = "#ffffff" });
            string lv = view.Level.ToString();
            var mn = MidNum;
            if (W(lv, mn) > 44 - 2 * Bw(2.5f) - 6) mn = T(Kit.Display, 21 * (44 - 2 * Bw(2.5f) - 6) / W(lv, mn), "#7a3d00");
            TxtC(s, lv, ix + 22, iy + (44 - LH(mn)) / 2, mn);
            float cx = ix + 44 + 10, cw = w - 2.5f - Bw(3) - 10 - cx;
            float colH = 22 + 5 + LH(Hint), cy = 2.5f + (innerH - colH) / 2;
            int pct = (int)Math.Max(3, Math.Min(100, Math.Round(view.Into / view.Need * 100)));
            s.Box(cx, cy, cw, 22, new BoxStyle { Radius = 11, Background = "rgba(63,36,18,0.45)" });
            var clip = s.NewId("bc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(cx + 2, cy + 2, cw - 4, 18, new[] { 9f, 9, 9, 9 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(cx + 2, cy + 2, (cw - 4) * pct / 100f, 18, new BoxStyle { Radius = 9, Gradient = BAR, GradientAngle = 90 });
            s.Close();
            s.Box(cx, cy, cw, 22, new BoxStyle { Radius = 11, BorderWidth = 2, BorderColor = "#ffffff" });
            string bt = $"{Prof.Fmt(view.Into)} / {Prof.Fmt(view.Need)} XP";
            TxtC(s, bt, cx + cw / 2, cy + (22 - LH(BarText)) / 2, BarText);
            s.Text(Ellipsize("Mini-games, challenges and squishing give XP", Hint, cw), cx, cy + 22 + 5, Hint);
            list.Add(Piece("level", s, x, y, 1, null, 4));
        }

        void Purse(List<ScreenPiece> list, string id, float x, float y, float w, float h, string text, TextStyle t, string img, float size, float ml, float mv)
        {
            var s = new UiSvg(w, h);
            float faceH = h - 4 - 3;
            ShopView.CandyRingedPublic(s, 0, 0, w, faceH, "#6b4426", new[] { "#ffffff", "#ffffff" }, 3, 2, 2.5f, false);
            float ix = 2 + Bw(2.5f) + 7, cy = 2 + faceH / 2;
            s.Image(img, ix - ml, cy - size / 2, size, size);
            s.Text(text, ix - ml + size + 5, cy - LH(t) / 2, t);
            list.Add(Piece("purse-" + id, s, x, y, 1, null, 4));
        }

        void Column(List<ScreenPiece> list, Node n, float x, float y, bool last, bool current, string group, double toGo, int count)
        {
            var s = new UiSvg(COL, 4 + 42 + 8 + 168 + 7);
            // the rail through the disc's middle
            float rl = n.Lv == 1 ? COL / 2 : 0, rr = last ? COL / 2 : COL;
            s.Box(rl, 4 + 19 - 3, rr - rl, 6, new BoxStyle { Background = n.Reached ? "#ffc23a" : "#e2cfb4" });
            float d = current ? 42 : 38, dx = (COL - d) / 2;
            if (n.Reached) s.Box(dx, 4, d, d, new BoxStyle { Radius = d / 2, Gradient = GOLD, GradientStops = new[] { 0f, 0.5f, 1 }, BorderWidth = current ? 3 : Bw(2.5f), BorderColor = current ? "#ff8a3d" : "#ffffff" });
            else s.Box(dx, 4, d, d, new BoxStyle { Radius = d / 2, Background = "#f3e6d4", BorderWidth = Bw(2.5f), BorderColor = "#ffffff" });
            var dt = n.Reached ? DiscT : T(Kit.Display, 15, "#a88d70");
            TxtC(s, n.Lv.ToString(), COL / 2, 4 + (d - LH(dt)) / 2, dt);
            // the card (Ringed: ring, lip 3, border 2.5, radius 18)
            float cy = 4 + d + 8, cw = COL - 12, cx = 6;
            string ring = n.Claimable ? GOLD_RING : n.Reached ? "#c8955e" : "#e2cfb4";
            s.Box(cx, cy, cw, 168 + 4 + 3, new BoxStyle { Radius = 20, Background = ring });
            s.Box(cx + 2, cy + 2, cw - 4, 168, new BoxStyle { Radius = 18, Background = n.Got ? "#f6ece0" : "#ffffff", BorderWidth = Bw(2.5f), BorderColor = "#ffffff" });
            var pt = T(Kit.Display, 15, n.Got ? "#a88d70" : !n.Reached ? "#8a7560" : "#5b3418", 0, 18);
            var flow = new TextFlow(PrizeLabel(n.R), pt, 0.5f);
            float iw = cw - 4 - 2 * Bw(2.5f) - 12, fh = Math.Max(36, Math.Min(36, flow.Measure(iw).h));
            // column: art (56), the label (min 36, 2 lines), the check / CLAIM / lock; gap 6, padding 10
            float artY = cy + 2 + Bw(2.5f) + 10;
            float actionH = n.Got ? 30 : n.Claimable ? new CandyBtnArt("CLAIM", "gold", 5, 12, 4, 14).H : LH(LockT) + 10;
            PrizeArt(s, n.R, group, n.Lv, COL / 2 - 25, artY + 3, 50, n.Got);
            float ly = artY + 56 + 6;
            float lh = flow.Measure(iw).h;
            flow.Draw(s, cx + 2 + Bw(2.5f) + 6, ly + (fh - lh) / 2, iw);
            float ay = ly + fh + 6;
            if (n.Got) Check(s, COL / 2 - 15, ay, 30);
            else if (!n.Claimable)
            {
                string lt = toGo > 0 ? $"{Prof.Fmt(toGo)} XP" : $"LV {n.Lv}";
                float lw = 12 + 4 + W(lt, LockT) + 18, lhh = LH(LockT) + 10;
                float lx = COL / 2 - lw / 2;
                s.Box(lx, ay, lw, lhh, new BoxStyle { Radius = 999, Background = "#f6ead8" });
                float lky = ay + (lhh - 13) / 2;
                s.Box(lx + 9 + (12 - 6.6f) / 2, lky + 0.6f, 6.6f, 5.2f, new BoxStyle { Radii = new[] { 3.3f, 3.3f, 0, 0 }, Borders = new[] { 1.7f, 1.7f, 0, 1.7f }, BorderColor = "#a88d70" });
                s.Box(lx + 9 + (12 - 9.2f) / 2, lky + 0.6f + 5.2f, 9.2f, 6.5f, new BoxStyle { Radius = 1.8f, Background = "#a88d70" });
                s.Text(lt, lx + 9 + 12 + 4, ay + 5, LockT);
            }
            list.Add(Piece("col-" + n.Lv, s, x, y, 1, null, 8));
            if (n.Claimable)
            {
                var b = new CandyBtnArt("CLAIM", _busy ? "grey" : "gold", 5, 12, 4, 14);
                float bx = x + COL / 2 - b.W / 2;
                list.Add(Piece("claim-" + n.Lv, b.Svg(), b.W, b.H, bx, y + ay + (_pressed == "claim:" + n.Lv ? 3 : 0), 1, null, 8));
                if (!_busy) _hits.Add("claim:" + n.Lv, bx, y + ay, b.W, b.H);
            }
        }
    }

    /// <summary>squad/ui.js CandyBtn (Ringed: ring 2.5, border 3, lip) with a BtnText caption.</summary>
    public sealed class CandyBtnArt
    {
        static readonly Dictionary<string, (string[] c, string ring)> BTN = new Dictionary<string, (string[], string)>
        {
            ["gold"] = (new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, "#9c4d06"), ["grey"] = (new[] { "#e6dcf0", "#c9b9da", "#b9a6cc" }, "#7a6a8c"),
            ["pink"] = (new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }, "#8a3a0e"), ["green"] = (new[] { "#b8ffd9", "#3ddc97", "#16a86a" }, "#0d7a4a"),
        };
        public readonly string Label, Kind;
        public readonly float PadV, PadH, Lip, Size, W, H, FaceH;
        readonly TextStyle _t;
        public CandyBtnArt(string label, string kind, float padV, float padH, float lip, float size)
        {
            Label = label; Kind = kind; PadV = padV; PadH = padH; Lip = lip; Size = size;
            _t = T(Kit.Display, size, "#ffffff", 0, 0, Outline3(BTN[kind].ring, 2));
            FaceH = LH(_t) + 2 * padV + 2 * Bw(3);
            W = W(label, _t) + 2 * padH + 2 * Bw(3) + 5;
            H = FaceH + 5 + lip;
        }
        public string Svg()
        {
            var s = new UiSvg(W, H);
            ShopView.CandyRingedPublic(s, 0, 0, W, FaceH, BTN[Kind].ring, BTN[Kind].c, Lip, 2.5f, 3);
            s.Text(Label, 2.5f + Bw(3) + PadH, 2.5f + Bw(3) + PadV, _t);
            return s.Markup;
        }
    }
}
