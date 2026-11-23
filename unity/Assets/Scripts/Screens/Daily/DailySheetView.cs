// src/screens/DailyChallengesSheet.js, landscape (REDESIGN_V7, V8: a wide panel the screen's height, the two lists side
// by side), as pure C#: over whatever is under it (the menu), the scrim and the panel: DAILY CHALLENGES with the time
// left today and the close button; "In Squish Squad" (3 game challenges, YOU ARE HERE) and "In the Crib" (3 Crib ones,
// OPEN CRIB), each row its progress bar, its reward pill, CLAIM +N when done, DONE once claimed, +N XP until then; and
// the daily chest along the bottom (OPEN once all six are claimed, OPENED after). The panel's content scrolls when it's
// taller than the panel (it is, by about 16 dp, on the reference phone); the scrim closes it.
// The rules and the rows: Progression (src/progression.js), read again every minute. Claims go through OnClaim /
// OnClaimChest (the host writes them: DailyWrites).
// Not ported: the sound; the scroll's fling (a drag scrolls it, no momentum).
using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class DailySheetView : IScreenView, IWheel
    {
        public readonly float W, H;
        public Action OnClose, OnOpenCrib, OnClaimChest;
        public Action<string> OnClaim;
        public DailyInfo V { get; private set; }
        public bool ShowBackground;   // (tests: the PageBg Preview.js puts under the sheet)

        IDictionary<string, object> _profile;
        readonly Ticker _t;
        readonly Func<DateTime> _now;
        readonly AnimatedValue _pulse = new AnimatedValue(0);
        double _readAt;
        public float ScrollY { get; private set; }

        public DailySheetView(IDictionary<string, object> profile, float w, float h, Ticker ticker, Func<DateTime> now, bool crib = true)
        {
            _profile = profile; W = w; H = h; _t = ticker; _now = now; _crib = crib;
            Read();
            Motion.PingPong(_pulse, 800).Start();
        }

        readonly bool _crib;   // opened from the menu (OPEN CRIB), not from the Crib
        void Read() { V = Progression.View(_profile, _now()); _readAt = _t.Now; _frames = null; _content = null; }

        /// <summary>The profile changed (a claim landed): the rows again.</summary>
        public void SetProfile(IDictionary<string, object> profile) { _profile = profile; Read(); }

        // ---- the panel's box --------------------------------------------------------------------------------------------
        float RingX => W * 0.06f;
        float RingW => W - 2 * RingX;
        const float RingY = 10;
        float RingH => H - 20;
        float VpX => RingX + 3 + 4;
        float VpY => RingY + 3 + 4;
        float VpW => RingW - 14;
        float VpH => RingH - 14;

        // ---- layout of the scrolling content (in content coordinates: 0, 0 its top-left) --------------------------------
        static readonly TextStyle ResetText = T(Heavy, 11, "#9a6a3a");
        static readonly TextStyle SectionTitle = T(Kit.Display, 15, "#b8641c");
        static readonly TextStyle HereText = T(Black, 10, "#9a6a3a", 1);
        static readonly TextStyle RowTitle = T(Heavy, 13, "#5b3418", 0, 16);
        static readonly TextStyle BarLabel = T(Heavy, 11, "#9a6a3a");
        static readonly TextStyle XpText = T(Black, 10, "#b8641c");
        static readonly TextStyle RewardText = T(Black, 12, "#c25e00");
        static readonly TextStyle DoneText = T(Black, 11, "#17652f");
        static readonly TextStyle ChestText = T(Black, 12, "#7a3d00", 0, 15);
        static readonly TextStyle ChestCount = T(Black, 12, "#7a3d00");
        static (float W, float H) TitleSize => OutlinedTitleSize("DAILY CHALLENGES", 24, 2, 0, 0, 0);

        CandyButton ClaimBtn(DailyRow r) => new CandyButton($"CLAIM +{Prof.JsStr(r.Reward)}", "gold", "xs", 12);
        static CandyButton OpenCrib => new CandyButton("OPEN CRIB", "blue", "xs", 11);
        static CandyButton OpenChest => new CandyButton("OPEN", "pink", "xs", 12);
        string ChestLine => $"Claim all {V.Total} for the daily chest · +{Prof.JsStr(V.ChestReward)} coins + {Prof.JsStr(V.ChestXp)} XP + your streak reward";

        Dictionary<string, Frame> _frames;
        float _contentH;

        Dictionary<string, Frame> Frames()
        {
            if (_frames != null) return _frames;
            var root = new FlexNode("content").Width(VpW).MinH(VpH).Padding(14).Padding(YGEdge.Top, 10).Padding(YGEdge.Bottom, 10).Gap(8);
            var head = root.Add(new FlexNode("header").Row().AlignItems(YGAlign.Center).Gap(10));
            var hc = head.Add(new FlexNode("headCol").Flex(1));
            var title = TitleSize;
            hc.Add(new FlexNode("titleBox").AlignItems(YGAlign.Center)).Add(FlexX.Box("title", title.W, title.H));
            hc.Add(FlexX.Txt("reset", $"New challenges in {V.ResetIn}", ResetText).Margin(YGEdge.Top, 6).AlignSelf(YGAlign.FlexStart));
            head.Add(FlexX.Box("close", 36, 40));
            var cols = root.Add(new FlexNode("cols").Row().Gap(12));
            Section(cols, "game", "In Squish Squad", V.Game, _crib ? "here" : null);
            Section(cols, "crib", "In the Crib", V.Crib, _crib ? "crib" : "here");
            var chest = root.Add(new FlexNode("chest").MarginAuto(YGEdge.Top).Row().AlignItems(YGAlign.Center).Gap(10).Padding(12).PadV(8).Border(2));
            chest.Add(FlexX.Box("chestIcon", 34, 32));
            var cc = chest.Add(new FlexNode("chestCol").Flex(1).Gap(5));
            cc.Add(FlexX.Para("chestText", new TextFlow(ChestLine, ChestText)));
            cc.Add(new FlexNode("chestBar").Height(10));
            if (V.ChestReady) chest.Add(FlexX.Box("open", OpenChest.FaceW, OpenChest.H));
            else if (V.ChestDone) chest.Add(new FlexNode("opened").PadH(10).PadV(4).Border(1.5f)).Add(FlexX.Txt("openedText", "OPENED", DoneText));
            chest.Add(FlexX.Txt("chestCount", $"{V.ClaimedN}/{V.Total}", ChestCount));
            root.Layout(VpW, float.NaN);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            _contentH = root.Frame.H;
            return _frames = f;
        }

        void Section(FlexNode cols, string id, string title, List<DailyRow> rows, string right)
        {
            var s = cols.Add(new FlexNode(id).Flex(1).Gap(6));
            var head = s.Add(new FlexNode(id + "-head").Row().AlignItems(YGAlign.Center).Justify(YGJustify.SpaceBetween));
            head.Add(FlexX.Txt(id + "-title", title, SectionTitle));
            if (right == "here") head.Add(FlexX.Txt(id + "-here", "YOU ARE HERE", HereText));
            else if (right == "crib") head.Add(FlexX.Box(id + "-crib", OpenCrib.FaceW, OpenCrib.H));
            foreach (var r in rows)
            {
                var row = s.Add(new FlexNode("row-" + r.Id).Row().AlignItems(YGAlign.Center).Gap(10).PadV(6).PadH(12).Border(2));
                var main = row.Add(new FlexNode("main-" + r.Id).Flex(1).MinW(0).Gap(6));
                main.Add(FlexX.Para("title-" + r.Id, new TextFlow(r.Title, RowTitle)));
                var br = main.Add(new FlexNode("barRow-" + r.Id).Row().AlignItems(YGAlign.Center).Gap(8));
                br.Add(new FlexNode("bar-" + r.Id).Flex(1).Height(10));
                br.Add(FlexX.Txt("label-" + r.Id, r.Label, BarLabel));
                var rc = row.Add(new FlexNode("reward-" + r.Id).AlignItems(YGAlign.Center).Gap(2));
                if (r.Open) rc.Add(new FlexNode("pill-" + r.Id).PadH(10).PadV(4).Border(1.5f)).Add(FlexX.Txt("pillText-" + r.Id, $"+{Prof.JsStr(r.Reward)}", RewardText));
                else if (r.Claimable) rc.Add(FlexX.Box("claim-" + r.Id, ClaimBtn(r).FaceW, ClaimBtn(r).H));
                else rc.Add(new FlexNode("done-" + r.Id).PadH(10).PadV(4).Border(1.5f)).Add(FlexX.Txt("doneText-" + r.Id, "DONE", DoneText));
                if (!r.Claimed) rc.Add(FlexX.Txt("xp-" + r.Id, $"+{Prof.JsStr(r.Xp)} XP", XpText));
            }
        }

        public void Wheel(float x, float y, float dy)
        {
            if (!InPanel(x, y)) return;
            float s = Math.Max(0, Math.Min(ScrollMax, ScrollY + dy));
            if (s != ScrollY) { ScrollY = s; _content = null; }
        }

        public float ScrollMax { get { Frames(); return Math.Max(0, _contentH - VpH); } }

        // ---- the pointer ---------------------------------------------------------------------------------------------
        string _pressed;
        bool _down, _dragging;
        float _y0, _scroll0;
        public void Down(float x, float y) { _down = true; _dragging = false; _y0 = y; _scroll0 = ScrollY; _pressed = Hit(x, y); }
        public void Move(float x, float y)
        {
            if (!_down) return;
            if (!_dragging && Math.Abs(y - _y0) > 8 && InPanel(x, _y0)) { _dragging = true; _pressed = null; }
            if (_dragging) { float s = Math.Max(0, Math.Min(ScrollMax, _scroll0 - (y - _y0))); if (s != ScrollY) { ScrollY = s; _content = null; } }
        }
        public void Up(float x, float y)
        {
            if (!_down) return;
            _down = false;
            if (_dragging) return;
            var h = Hit(x, y);
            var p = _pressed;
            _pressed = null;
            if (h == null || h != p) return;
            if (h == "close" || h == "scrim") OnClose?.Invoke();
            else if (h == "crib") OnOpenCrib?.Invoke();
            else if (h == "open") OnClaimChest?.Invoke();
            else if (h.StartsWith("claim-")) OnClaim?.Invoke(h.Substring(6));
        }

        bool InPanel(float x, float y) => x >= RingX && x < RingX + RingW && y >= RingY && y < RingY + RingH;

        string Hit(float x, float y)
        {
            if (!InPanel(x, y)) return "scrim";
            if (y < VpY || y >= VpY + VpH) return null;
            var f = Frames();
            float cx = x - VpX, cy = y - VpY + ScrollY;
            foreach (var kv in f)
            {
                if (!(kv.Key == "close" || kv.Key == "crib-crib" || kv.Key == "open" || kv.Key.StartsWith("claim-"))) continue;
                var r = kv.Value;
                float slop = kv.Key == "close" ? 8 : 0;
                if (cx >= r.X - slop && cx < r.Right + slop && cy >= r.Y - slop && cy < r.Bottom + slop)
                    return kv.Key == "crib-crib" ? "crib" : kv.Key;
            }
            return null;
        }

        // ---- the pieces --------------------------------------------------------------------------------------------------
        string _content;

        public List<ScreenPiece> Pieces()
        {
            if (_t.Now - _readAt >= 60000) Read();
            var f = Frames();
            var list = new List<ScreenPiece>();
            if (ShowBackground) list.Add(Piece("bg", PageBg(W, H), W, H, 0, 0, 1, null, 0));
            list.Add(Piece("scrim", new UiSvg(W, H).Box(0, 0, W, H, new BoxStyle { Background = "rgba(50,24,6,0.6)" }), 0, 0, 1, null, 0));
            // the ring (its shadow under it), the white rim and the paper
            var ring = new UiSvg(RingW, RingH);
            ring.Box(0, 0, RingW, RingH, new BoxStyle { Radius = 31, Background = "#8a3a0e", Shadows = new[] { new Shadow("rgba(63,36,18,0.5)", 0, 14, 20) } });
            ring.Box(3, 3, RingW - 6, RingH - 6, new BoxStyle { Radius = 28, Background = "#fffaf0", BorderWidth = 4, BorderColor = "#ffffff" });
            list.Add(Piece("panel", ring, RingX, RingY, 1, null, 40));
            // the content, clipped to the panel and scrolled (drawn again when it scrolls)
            list.Add(Piece("content", _content ??= Content(f), VpW, VpH, VpX, VpY, 1, null, 0));
            // the buttons over it (they sink when held)
            float sy = VpY - ScrollY;
            list.Add(Piece("close", Xml("round-close"), 36, 40, VpX + f["close"].X, sy + f["close"].Y, 1, null, 12));
            if (f.TryGetValue("crib-crib", out var cf)) Button(list, "crib", OpenCrib, cf, sy, 0);
            foreach (var r in V.Game.Concat(V.Crib))
                if (f.TryGetValue("claim-" + r.Id, out var bf)) Button(list, "claim-" + r.Id, ClaimBtn(r), bf, sy, 0);
            if (f.TryGetValue("open", out var of)) Button(list, "open", OpenChest, of, sy, _pulse.GetValue() * 0.04);
            return list;
        }

        void Button(List<ScreenPiece> list, string id, CandyButton b, Frame at, float sy, double pulse)
        {
            var p = About(b.FaceW, b.H, Affine.ScaleBy(1 + pulse, 1 + pulse));
            var face = _pressed == id ? Affine.Translate(0, b.Sz.Lip - 1) * About(b.FaceW, b.FaceH, Affine.ScaleBy(0.97, 0.97)) : Affine.Identity;
            list.Add(Piece(id + "-lip", b.LipSvg(), b.FaceW, b.H, VpX + at.X, sy + at.Y, 1, p));
            list.Add(Piece(id, b.FaceSvg(), b.FaceW, b.FaceH, VpX + at.X, sy + at.Y, 1, p * face, 16));
        }

        static readonly string[] BarFill = { "#ffe08a", "#ffb347", "#f07a1c" };
        static readonly float[] BarStops = { 0, 0.55f, 1 };

        string Content(Dictionary<string, Frame> f)
        {
            var s = new UiSvg(VpW, VpH);
            var clip = s.NewId("vp");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(0, 0, VpW, VpH, new[] { 24f, 24, 24, 24 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Open($"transform=\"translate(0 {F(-ScrollY)})\"");
            var tf = f["title"];
            OutlinedTitle(s, "DAILY CHALLENGES", "gold", 24, 2, 0, 0, 0, tf.X, tf.Y);
            var rt = f["reset"];
            s.Text($"New challenges in {V.ResetIn}", rt.X, rt.Y, ResetText);
            foreach (var (id, title, rows) in new[] { ("game", "In Squish Squad", V.Game), ("crib", "In the Crib", V.Crib) })
            {
                var st = f[id + "-title"];
                s.Text(title, st.X, st.Y, SectionTitle);
                if (f.TryGetValue(id + "-here", out var hf)) s.Text("YOU ARE HERE", hf.X, hf.Y, HereText);
                foreach (var r in rows) Row(s, f, r);
            }
            var ch = f["chest"];
            s.Box(ch.X, ch.Y, ch.W, ch.H, new BoxStyle { Radius = 18, Gradient = new[] { "#fff7d6", "#ffe9a8" } });
            s.Box(ch.X, ch.Y, ch.W, ch.H, new BoxStyle { Radius = 18, BorderWidth = 2, BorderColor = "#ffcd3c" });
            var ci = f["chestIcon"];
            s.Drawing("<rect x=\"3\" y=\"11\" width=\"24\" height=\"15\" rx=\"3\" fill=\"#cf955a\" stroke=\"#6b4426\" stroke-width=\"2\"/><path d=\"M3 13 Q3 3 15 3 Q27 3 27 13 Z\" fill=\"#e6b47c\" stroke=\"#6b4426\" stroke-width=\"2\" stroke-linejoin=\"round\"/><rect x=\"12\" y=\"10\" width=\"6\" height=\"8\" rx=\"1.5\" fill=\"#ffe045\" stroke=\"#a04a00\" stroke-width=\"1.6\"/>", ci.X, ci.Y, 34, 32, "0 0 30 28");
            var ct = f["chestText"];
            new TextFlow(ChestLine, ChestText).Draw(s, ct.X, ct.Y, ct.W);
            var cb = f["chestBar"];
            Bar(s, cb.X, cb.Y, cb.W, 10, (float)V.ChestPct, "#ffffff", 1.5f, "#ffcd3c", 6, new[] { "#fffbd6", "#ffe045", "#ff9500" }, new[] { 0f, 0.45f, 1 });
            if (f.TryGetValue("opened", out var op))
            {
                s.Box(op.X, op.Y, op.W, op.H, new BoxStyle { Radius = 999, Background = "#d8ffc2", BorderWidth = Bw(1.5f), BorderColor = "#26a94e" });
                var ot = f["openedText"];
                s.Text("OPENED", ot.X, ot.Y, DoneText);
            }
            var cn = f["chestCount"];
            s.Text($"{V.ClaimedN}/{V.Total}", cn.X, cn.Y, ChestCount);
            s.Close();
            s.Close();
            return s.Markup;
        }

        void Row(UiSvg s, Dictionary<string, Frame> f, DailyRow r)
        {
            var rf = f["row-" + r.Id];
            s.Box(rf.X, rf.Y, rf.W, rf.H, new BoxStyle { Radius = 16, Background = "#ffffff", BorderWidth = 2, BorderColor = "#ecd3b0", Shadows = new[] { new Shadow("#ecd3b0", 0, 3, 0) } });
            var tf = f["title-" + r.Id];
            new TextFlow(r.Title, RowTitle).Draw(s, tf.X, tf.Y, tf.W);
            var bf = f["bar-" + r.Id];
            Bar(s, bf.X, bf.Y, bf.W, 10, (float)r.Pct, "#f6ead8", 1.5f, "#e2c49c", 6, BarFill, BarStops);
            var lf = f["label-" + r.Id];
            s.Text(r.Label, lf.X, lf.Y, BarLabel);
            if (f.TryGetValue("pill-" + r.Id, out var pf))
            {
                s.Box(pf.X, pf.Y, pf.W, pf.H, new BoxStyle { Radius = 999, Background = "#fff5d6", BorderWidth = Bw(1.5f), BorderColor = "#ffcd3c" });
                var pt = f["pillText-" + r.Id];
                s.Text($"+{Prof.JsStr(r.Reward)}", pt.X, pt.Y, RewardText);
            }
            if (f.TryGetValue("done-" + r.Id, out var df))
            {
                s.Box(df.X, df.Y, df.W, df.H, new BoxStyle { Radius = 999, Background = "#d8ffc2", BorderWidth = Bw(1.5f), BorderColor = "#26a94e" });
                var dt = f["doneText-" + r.Id];
                s.Text("DONE", dt.X, dt.Y, DoneText);
            }
            if (f.TryGetValue("xp-" + r.Id, out var xf)) s.Text($"+{Prof.JsStr(r.Xp)} XP", xf.X, xf.Y, XpText);
        }
    }
}
