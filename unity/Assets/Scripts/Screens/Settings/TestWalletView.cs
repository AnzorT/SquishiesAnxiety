// src/components/TestWallet.js (a tester's panel in Settings), as pure C#: coins, gems and the level with their quick
// buttons, the Deals streak's next day / start over, the level road's prizes again, the FPS counter, Set. Each one
// calls the testWallet Cloud Function (OnSet: the host's Backend client; the function checks the tester claim again).
// It scrolls inside the pearl panel (drag); laid out by Yoga from the StyleSheet.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class TestWalletView
    {
        public const float VW = 420, VH = 330;   // the scroll view: the 420 x 330 panel (its content padded 10)
        /// <summary>testWallet's data ({ coins } / { gems } / { level } / { streak: 'next' } ...): the host calls the function.</summary>
        public Func<IDictionary<string, object>, Task> OnSet;
        public Func<bool> FpsOn = () => false;
        public Action OnToggleFps;
        public double Coins, Gems, Level;
        public string Msg = "";
        public float ScrollY;

        readonly Ticker _t;
        readonly Dictionary<string, string> _draft = new Dictionary<string, string>();
        Dictionary<string, Frame> _f;
        float _h;

        public TestWalletView(Ticker t, double coins, double gems, double level) { _t = t; Coins = coins; Gems = gems; Level = level; }

        /// <summary>The wallet changed (the profile): drafts are dropped, as the app's effect does.</summary>
        public void SetWallet(double coins, double gems, double level) { Coins = coins; Gems = gems; Level = level; _draft.Clear(); }

        static double N(object v) => Math.Max(0, Prof.JsRound(v is string s && double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var d) ? d : Prof.Num(v)));
        public string TextOf(string field) => _draft.TryGetValue(field, out var d) ? d : Prof.JsStr(field == "wcoins" ? Coins : field == "wgems" ? Gems : Level);
        public void SetText(string field, string text) { _draft[field] = text ?? ""; }

        async void Set(Dictionary<string, object> w, string done = "Done!")
        {
            Msg = "…";
            try
            {
                if (OnSet != null) await OnSet(w);
                Msg = done;
            }
            catch (Exception e)
            {
                Msg = e is Backend.FunctionsException fe && fe.Code == "permission-denied" ? "Not a tester account" : "Could not set it";
            }
            string shown = Msg;
            _t.SetTimeout(() => { if (Msg == shown) Msg = ""; }, done == "Done!" ? 1500 : 3000);
        }

        void Apply()
        {
            var w = new Dictionary<string, object>();
            foreach (var (k, f) in new[] { ("coins", "wcoins"), ("gems", "wgems"), ("level", "wlevel") })
                if (_draft.TryGetValue(f, out var d) && d != "") w[k] = N(d);
            Set(w);
        }

        // ---- layout -------------------------------------------------------------------------------------------------
        static readonly TextStyle HeadT = T(Kit.Display, 16, "#ffffff"), NoteT = T(Kit.Display, 12, "#ffffff");
        static TextStyle Label(string c) => T(Black, 14, c);
        static readonly TextStyle InputT = T(Heavy, 14, "#5b3418"), QuickT = T(Kit.Display, 12, "#000"), StepT = T(Kit.Display, 15, "#8a3a0e"), SetT = T(Kit.Display, 16, "#7a3d00");
        static readonly (string id, string label, string color)[] Rows = { ("coins", "Coins", "#b86200"), ("gems", "Gems", "#5a22c8") };
        sealed class Quick { public string Id, Label, Border, Bg, Color; public Action Do; }
        List<(string row, List<Quick> quicks)> QuickRows() => new List<(string, List<Quick>)>
        {
            ("coins", new List<Quick> { Q("c1k", "+1K", "gold", () => Set(new Dictionary<string, object> { ["coins"] = Coins + 1000 })), Q("c10k", "+10K", "gold", () => Set(new Dictionary<string, object> { ["coins"] = Coins + 10000 })), Q("c0", "0", "gold", () => Set(new Dictionary<string, object> { ["coins"] = 0.0 })) }),
            ("gems", new List<Quick> { Q("g100", "+100", "violet", () => Set(new Dictionary<string, object> { ["gems"] = Gems + 100 })), Q("g1k", "+1K", "violet", () => Set(new Dictionary<string, object> { ["gems"] = Gems + 1000 })), Q("g0", "0", "violet", () => Set(new Dictionary<string, object> { ["gems"] = 0.0 })) }),
            ("streak", new List<Quick> { Q("snext", "Next day", "fire", () => Set(new Dictionary<string, object> { ["streak"] = "next" }, "Next day ready in Deals")), Q("sreset", "Start over", "fire", () => Set(new Dictionary<string, object> { ["streak"] = "reset" }, "Back to day 1")) }),
            ("road", new List<Quick> { Q("road", "Claim prizes again", "pink", () => Set(new Dictionary<string, object> { ["road"] = "replay" }, "LEVEL UP shows on the lobby")) }),
        };
        static Quick Q(string id, string label, string tone, Action a)
        {
            var (b, bg, c) = tone == "gold" ? ("#ffd27a", "#fff6dc", "#b86200") : tone == "violet" ? ("#c9b2ff", "#efe8ff", "#5a22c8") : tone == "fire" ? ("#ffb98a", "#fff0e4", "#c2531c") : ("#f2c39e", "#fff1e4", "#8a3a0e");
            return new Quick { Id = id, Label = label, Border = b, Bg = bg, Color = c, Do = a };
        }

        Dictionary<string, Frame> Layout()
        {
            if (_f != null) return _f;
            var root = new FlexNode("root").Width(VW).Padding(10);
            var box = root.Add(new FlexNode("box").Border(3).Margin(YGEdge.Bottom, 14));
            var head = box.Add(new FlexNode("head").Row().AlignItems(YGAlign.Center).Justify(YGJustify.SpaceBetween).PadV(9).PadH(14));
            head.Add(FlexX.Txt("headText", "Test wallet", HeadT));
            head.Add(FlexNode.Leaf("headNote", _ => (Math.Max(W("tester only", NoteT), 1), LH(NoteT))));
            var body = box.Add(new FlexNode("body").Gap(10).Padding(12));
            var qr = QuickRows();
            foreach (var (id, label, color) in Rows)
            {
                var row = body.Add(new FlexNode("row-" + id).Row().AlignItems(YGAlign.Center).Gap(8));
                row.Add(FlexX.Txt("label-" + id, label, Label(color)).Flex(1));
                row.Add(new FlexNode("w" + id).Width(110).PadV(5).PadH(8).Border(2)).Add(FlexX.Txt("wt" + id, "0", InputT));
                Quicks(body, qr.Find(q => q.row == id).quicks, id);
            }
            var lv = body.Add(new FlexNode("row-level").Row().AlignItems(YGAlign.Center).Gap(8));
            lv.Add(FlexX.Txt("label-level", "Level", Label("#8a3a0e")).Flex(1));
            lv.Add(FlexX.Box("lvminus", 28, 28));
            lv.Add(new FlexNode("wlevel").Width(52).PadV(5).PadH(8).Border(2)).Add(FlexX.Txt("wtlevel", "0", InputT));
            lv.Add(FlexX.Box("lvplus", 28, 28));
            body.Add(new FlexNode("row-streak").Row()).Add(FlexX.Txt("label-streak", "Daily streak (Shop)", Label("#c2531c")).Flex(1));
            Quicks(body, qr.Find(q => q.row == "streak").quicks, "streak");
            body.Add(new FlexNode("row-road").Row()).Add(FlexX.Txt("label-road", "Level road", Label("#8a3a0e")).Flex(1));
            Quicks(body, qr.Find(q => q.row == "road").quicks, "road");
            var fps = body.Add(new FlexNode("row-fps").Row().AlignItems(YGAlign.Center).Gap(8));
            fps.Add(FlexX.Txt("label-fps", "FPS counter", Label("#17652f")).Flex(1));
            fps.Add(FlexX.Box("fps", 58, 33));
            body.Add(new FlexNode("set").Padding(2).Padding(YGEdge.Bottom, 5)).Add(new FlexNode("setFace").AlignItems(YGAlign.Center).PadV(8).Border(3)).Add(FlexX.Txt("setText", "Set", SetT));
            root.Layout(VW, float.NaN);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            _h = root.Frame.H;
            return _f = f;
        }

        void Quicks(FlexNode body, List<Quick> qs, string row)
        {
            var r = body.Add(new FlexNode("quicks-" + row).Row().Gap(5).Padding(YGEdge.Left, 26).Margin(YGEdge.Top, -4));
            foreach (var q in qs) r.Add(new FlexNode("q-" + q.Id).Flex(1).AlignItems(YGAlign.Center).PadV(4).Border(2)).Add(FlexX.Txt("qt-" + q.Id, q.Label, QuickT));
        }

        public float ScrollMax { get { Layout(); return Math.Max(0, _h - VH); } }

        // ---- taps (dp in the scroll view's box) ------------------------------------------------------------------------
        string _down;
        public string Hit(float x, float y)
        {
            if (x < 0 || y < 0 || x >= VW || y >= VH) return null;
            var f = Layout();
            y += ScrollY;
            foreach (var kv in f)
            {
                if (!(kv.Key.StartsWith("q-") || kv.Key == "wcoins" || kv.Key == "wgems" || kv.Key == "wlevel" || kv.Key == "lvminus" || kv.Key == "lvplus" || kv.Key == "fps" || kv.Key == "set")) continue;
                var r = kv.Value;
                if (x >= r.X && x < r.Right && y >= r.Y && y < r.Bottom) return kv.Key;
            }
            return null;
        }

        public void Down(string id) { _down = id; }
        /// <summary>The finger left the button it went down on (or came back): it grows back (shrinks again).</summary>
        public void Hold(bool on, string id) { _down = on ? id : null; }
        /// <summary>A held button shrinks to 92 % about its middle (cx, cy), as the page's others and the menu's Level crest
        /// do: opens its group (true: Close it after drawing the button).</summary>
        bool Shrink(UiSvg s, string id, float cx, float cy)
        {
            if (_down != id) return false;
            s.Open($"transform=\"translate({F(cx)} {F(cy)}) scale(0.92) translate({F(-cx)} {F(-cy)})\"");
            return true;
        }

        /// <summary>A tap on `id`; returns the field to type into, if it's one.</summary>
        public string Tap(string id)
        {
            _down = null;
            if (id == "wcoins" || id == "wgems" || id == "wlevel") return id;
            if (id == "lvminus") Set(new Dictionary<string, object> { ["level"] = Math.Max(1, Level - 1) });
            else if (id == "lvplus") Set(new Dictionary<string, object> { ["level"] = Math.Min(99, Level + 1) });
            else if (id == "fps") OnToggleFps?.Invoke();
            else if (id == "set") Apply();
            else if (id.StartsWith("q-")) foreach (var (_, qs) in QuickRows()) foreach (var q in qs) if ("q-" + q.Id == id) q.Do();
            return null;
        }

        // ---- the pieces (in the scroll view's box) ---------------------------------------------------------------------
        public List<ScreenPiece> Pieces(string focused, bool caretOn)
        {
            var f = Layout();
            var s = new UiSvg(VW, VH);
            var clip = s.NewId("tw");
            s.Def($"<clipPath id=\"{clip}\"><rect x=\"0\" y=\"0\" width=\"{F(VW)}\" height=\"{F(VH)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Open($"transform=\"translate(0 {F(-ScrollY)})\"");
            var bx = f["box"];
            s.Box(bx.X, bx.Y, bx.W, bx.H, new BoxStyle { Radius = 22, Background = "#fffaf0", BorderWidth = 3, BorderColor = "#ffffff" });
            var hd = f["head"];
            var hc = s.NewId("hc");
            s.Def($"<clipPath id=\"{hc}\"><path d=\"{UiSvg.RRect(bx.X + 3, bx.Y + 3, bx.W - 6, bx.H - 6, new[] { 19f, 19, 19, 19 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{hc})\"");
            s.Box(hd.X, hd.Y, hd.W, hd.H, new BoxStyle { Gradient = new[] { "#e6b47c", "#cf955a", "#b47a42" }, GradientStops = new[] { 0f, 0.55f, 1 } });
            s.Close();
            var ht = f["headText"]; s.Text("Test wallet", ht.X, ht.Y, HeadT);
            var hn = f["headNote"]; string note = Msg != "" ? Msg : "tester only";
            s.Text(note, hn.Right - W(note, NoteT), hn.Y, NoteT);
            foreach (var (id, label, color) in Rows) Field(s, f, "w" + id, focused, caretOn);
            Field(s, f, "wlevel", focused, caretOn, true);
            foreach (var key in new[] { "coins", "gems", "level", "streak", "road", "fps" })
            {
                var lf = f["label-" + key];
                string text = key == "coins" ? "Coins" : key == "gems" ? "Gems" : key == "level" ? "Level" : key == "streak" ? "Daily streak (Shop)" : key == "road" ? "Level road" : "FPS counter";
                string c = key == "coins" ? "#b86200" : key == "gems" ? "#5a22c8" : key == "streak" ? "#c2531c" : key == "fps" ? "#17652f" : "#8a3a0e";
                s.Text(text, lf.X, lf.Y, Label(c));
            }
            foreach (var (_, qs) in QuickRows())
                foreach (var q in qs)
                {
                    var qf = f["q-" + q.Id];
                    bool gq = Shrink(s, "q-" + q.Id, qf.X + qf.W / 2, qf.Y + qf.H / 2);
                    s.Box(qf.X, qf.Y, qf.W, qf.H, new BoxStyle { Radius = 999, Background = q.Bg, BorderWidth = 2, BorderColor = q.Border });
                    var qt = f["qt-" + q.Id];
                    s.Text(q.Label, qt.X, qt.Y, T(Kit.Display, 12, q.Color));
                    if (gq) s.Close();
                }
            foreach (var (k, ch) in new[] { ("lvminus", "−"), ("lvplus", "+") })
            {
                var sf = f[k];
                bool gk = Shrink(s, k, sf.X + 14, sf.Y + 14);
                s.Box(sf.X, sf.Y, 28, 28, new BoxStyle { Radius = 14, Background = "#fff1e4", BorderWidth = 2, BorderColor = "#f2c39e" });
                // (no font here has U+2212: a bar the minus sign's size)
                if (k == "lvminus") s.Box(sf.X + 14 - 4, sf.Y + 14 - 0.9f, 8, 1.8f, new BoxStyle { Background = "#8a3a0e" });
                else s.Text(ch, sf.X, sf.Y + (28 - LH(StepT)) / 2, StepT, 28, 0.5f);
                if (gk) s.Close();
            }
            var fp = f["fps"];
            bool gf = Shrink(s, "fps", fp.X + 29, fp.Y + 16.5f);
            bool on = FpsOn();
            s.Box(fp.X, fp.Y, 58, 33, new BoxStyle { Radius = 16.5f, Background = on ? "#0b6f68" : INK });
            s.Box(fp.X + 2, fp.Y + 2, 54, 26, new BoxStyle { Radius = 15, Gradient = on ? new[] { "#c8fff4", "#4fe6cf", "#14b3a0" } : new[] { "#efe6dc", "#d6c2a8", "#b39878" }, GradientStops = new[] { 0f, 0.55f, 1 }, BorderWidth = Bw(2.5f), BorderColor = "#ffffff" });
            s.Box(fp.X + 6 + (on ? 28 : 0), fp.Y + 6, 17, 17, new BoxStyle { Radius = 8.5f, Gradient = new[] { "#ffffff", "#fff6ea", "#f0dcc0" } });
            if (gf) s.Close();
            var st = f["set"];
            bool gs = Shrink(s, "set", st.X + st.W / 2, st.Y + st.H / 2);
            s.Box(st.X, st.Y, st.W, st.H, new BoxStyle { Radius = 18, Background = "#b86200" });
            var sfc = f["setFace"];
            s.Box(sfc.X, sfc.Y, sfc.W, sfc.H, new BoxStyle { Radius = 16, Gradient = new[] { "#fff3b0", "#ffd83a", "#ffb000" }, BorderWidth = 3, BorderColor = "#ffffff" });
            var stt = f["setText"]; s.Text("Set", stt.X, stt.Y, SetT);
            if (gs) s.Close();
            s.Close(); s.Close();
            return new List<ScreenPiece> { Piece("wallet", s, 0, 0, 1, null, 0) };
        }

        void Field(UiSvg s, Dictionary<string, Frame> f, string id, string focused, bool caretOn, bool centre = false)
        {
            var r = f[id];
            s.Box(r.X, r.Y, r.W, r.H, new BoxStyle { Radius = 10, Background = "#ffffff", BorderWidth = 2, BorderColor = "#e2cfb4" });
            string v = TextOf(id);
            float tw = W(v, InputT), x = centre ? r.X + (r.W - tw) / 2 : r.Right - 10 - tw;
            float y = r.Y + (r.H - LH(InputT)) / 2;
            s.Text(v, x, y, InputT);
            if (focused == id && caretOn) s.Box(x + tw, y, 1.5f, LH(InputT), new BoxStyle { Background = "#5b3418" });
        }

        public void Scroll(float dy) => ScrollY = Math.Max(0, Math.Min(ScrollMax, ScrollY + dy));
    }
}
