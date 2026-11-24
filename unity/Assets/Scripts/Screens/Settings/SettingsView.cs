// src/screens/royal/SettingsRoyal.js (REDESIGN_V7 step 3, landscape), as pure C#: the header (back orb, "Settings",
// "Playing as <name>"); three columns of wood panels: Sound (Music, Sound effects, and a tester's FPS counter), Nickname
// (its field) and Your squad (Stats), More (Send feedback, a tester's Test wallet, LOG OUT; develop: no Replay tutorial, the guided tutorial was removed); SAVE in
// the middle at the bottom with its pulsing glow; the toast; the feedback box (a modal: CANCEL / SEND); a tester's Test
// wallet (TestWalletView) over it all. In the design's 393-tall units (royal Stage).
// The switches are candy/ToggleSwitch: the knob springs across (friction 6, tension 140), the colours cross-fade, the
// knob squashes while held. Text goes in through the host (Focused / SetText: App/TextEntry on the phone's keyboard).
// Music / Sound effects: OnSound (the host sets Sfx's switches).
using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class SettingsView : IScreenView, IWheel
    {
        public readonly float ScreenW, ScreenH, K, SW, SH = 393;
        public readonly bool Tester;
        public Action OnBack, OnLogout, OnReplayTutorial, OnOpenStats, OnToggleFps;
        public Action<string> OnSaveNickname;
        /// <summary>Sends the feedback; a failed task shows "Could not send. Try again!".</summary>
        public Func<string, System.Threading.Tasks.Task> OnSubmitFeedback;
        /// <summary>Music / effects switched (the setting to keep).</summary>
        public Action<bool, bool> OnSound;
        public TestWalletView Wallet;   // a tester's Test wallet (null: not a tester)

        public string Nickname;
        public string Nick { get; private set; }
        public bool Music { get; private set; } = true;
        public bool Effects { get; private set; } = true;
        public bool Fps { get; private set; }
        public string Toast { get; private set; }
        public string Feedback { get; private set; }   // the text while the feedback box is open (null: closed)
        public bool WallOpen { get; private set; }
        /// <summary>The field being typed in: "nick", "feedback", or a Test wallet field (the host opens the keyboard).</summary>
        public string Focused { get; private set; }
        public bool CaretOn = true;

        readonly Ticker _t;
        readonly Dictionary<string, Toggle> _toggles = new Dictionary<string, Toggle>();
        readonly AnimatedValue _glow = new AnimatedValue(0), _modal = new AnimatedValue(0);

        sealed class Toggle { public AnimatedValue Pos, Press; }

        public SettingsView(string nickname, bool tester, float screenW, float screenH, Ticker ticker, bool music = true, bool effects = true, bool fps = false)
        {
            _t = ticker; Tester = tester; Nickname = nickname; Music = music; Effects = effects; Fps = fps;
            Audio.Snd.Play("popOpen");
            ScreenW = screenW; ScreenH = screenH; K = StageK(screenW, screenH); SW = Math.Max(screenW, screenH) / K;
            Nick = Cut(nickname);
            foreach (var k in new[] { "music", "effects", "fps" }) _toggles[k] = new Toggle { Pos = new AnimatedValue(On(k) ? 1 : 0), Press = new AnimatedValue(0) };
            // Glow: usePingPong(2400, 0.35 → 1): one linear phase read through eased keyframes
            Motion.Phase(_glow, 2400).Start();
        }

        static string Cut(string s) { s ??= ""; return s.Length > 10 ? s.Substring(0, 10) : s; }
        bool On(string k) => k == "music" ? Music : k == "effects" ? Effects : Fps;

        // ---- text from the host -------------------------------------------------------------------------------------
        public void SetText(string field, string text)
        {
            if (field == "nick") Nick = Cut(text);
            else if (field == "feedback" && Feedback != null) Feedback = text ?? "";
            else Wallet?.SetText(field, text);
        }
        public void Blur() => Focused = null;
        public string TextOf(string field) => field == "nick" ? Nick : field == "feedback" ? Feedback : Wallet?.TextOf(field);

        // ---- what the buttons do --------------------------------------------------------------------------------------
        void Flash(string t)
        {
            Toast = t;
            _t.SetTimeout(() => { if (Toast == t) Toast = null; }, 2200);
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(Nick)) return;
            Focused = null;
            OnSaveNickname?.Invoke(Nick.Trim());
            Nickname = Nick.Trim();
            Flash("Nickname updated!");
        }

        async void Send()
        {
            var t = (Feedback ?? "").Trim();
            if (t.Length == 0) return;
            try
            {
                if (OnSubmitFeedback != null) await OnSubmitFeedback(t);
                CloseFeedback();
                Flash("Thanks for the feedback!");
            }
            catch (Exception) { Flash("Could not send. Try again!"); }
        }

        void OpenFeedback() { Feedback = ""; _modal.SetValue(0); Motion.Timing(_modal, 1, 300, Easing.Ease).Start(); Focused = "feedback"; }
        void CloseFeedback() { Feedback = null; if (Focused == "feedback") Focused = null; }

        void Switch(string k)
        {
            if (k == "music") Music = !Music; else if (k == "effects") Effects = !Effects; else { Fps = !Fps; OnToggleFps?.Invoke(); }
            if (k != "fps") OnSound?.Invoke(Music, Effects);
            Animated.Spring(_toggles[k].Pos, new SpringConfig { ToValue = On(k) ? 1 : 0, Friction = 6, Tension = 140, UseNativeDriver = true }).Start();
        }

        /// <summary>Android's back: the feedback box, then the wallet, then the screen.</summary>
        public void Back()
        {
            if (Feedback != null) CloseFeedback();
            else if (WallOpen) WallOpen = false;
            else OnBack?.Invoke();
        }

        // ---- layout ----------------------------------------------------------------------------------------------------
        Dictionary<string, Frame> _f;
        static readonly TextStyle InkT = Ink(15);
        static readonly TextStyle InputT = T(Heavy, 15, "#ffffff");
        static readonly TextStyle Placeholder = T(Heavy, 15, "#e8c9a0");
        static readonly TextStyle ToastT = T(Kit.Display, 14, INK);
        static readonly (string id, string label, string d)[] More =
        {
            ("feedback", "Send feedback", "M4 5h16v11H8l-4 4Z"),
            ("wallet", "Test wallet", "M4 7h16v12H4Z M4 7l3-3h10l3 3 M15 13h2"),
        };
        const string STATS_D = "M5 20V11 M12 20V5 M19 20v-6";

        Dictionary<string, Frame> Layout()
        {
            if (_f != null) return _f;
            var cols = new FlexNode("cols").Row().Gap(18);
            FlexNode Col() => cols.Add(new FlexNode("col" + cols.Children.Count).Flex(1).Gap(14));
            FlexNode Panel(FlexNode col, string id, string title)
            {
                var p = col.Add(new FlexNode(id).AlignItems(YGAlign.Stretch).PadH(16).Padding(YGEdge.Top, 10).Padding(YGEdge.Bottom, 14).Gap(10));
                var (lw, lh) = LetteringSize(title, 19);
                p.Add(new FlexNode(id + "-titleBox").AlignItems(YGAlign.Center)).Add(FlexX.Box(id + "-title", lw, lh));
                return p;
            }
            var c0 = Col();
            var sound = Panel(c0, "sound", Tester ? "Options" : "Sound");
            foreach (var (k, label) in new[] { ("music", "Music"), ("effects", "Sound effects"), ("fps", "FPS counter") })
            {
                if (k == "fps" && !Tester) continue;
                var row = sound.Add(new FlexNode("row-" + k).Row().AlignItems(YGAlign.Center).Justify(YGJustify.SpaceBetween).Gap(10));
                row.Add(FlexX.Txt("label-" + k, label, InkT));
                row.Add(FlexX.Box("toggle-" + k, 58, 33));
            }
            var c1 = Col();
            var nick = Panel(c1, "nickPanel", "Nickname");
            nick.Add(new FlexNode("input").AlignSelf(YGAlign.Stretch).Height(38));
            var squad = Panel(c1, "squad", "Your squad");
            squad.Add(new FlexNode("link-stats").Height(42));
            var c2 = Col();
            var more = Panel(c2, "more", "More");
            foreach (var (id, _, _) in More) if (id != "wallet" || Tester) more.Add(new FlexNode("link-" + id).Height(42));
            more.Add(new FlexNode("logout").Height(40).Margin(YGEdge.Top, 4));
            cols.Layout(SW - 44, SH - 142);
            var f = new Dictionary<string, Frame>();
            cols.Offset(22, 70);
            cols.Walk(n => f[n.Name] = n.Frame);
            return _f = f;
        }

        Frame SaveBox => new Frame((SW - 190) / 2, SH - 16 - 44, 190, 44);
        Frame ToastBox => new Frame(SW * 0.35f, SH - 72 - 34, SW * 0.3f, 34);
        Frame FbBox
        {
            get
            {
                var (lw, lh) = LetteringSize("Feedback", 20);
                float h = 12 + lh + 12 + 110 + 12 + 38 + 16;
                // (an RN Modal: the whole screen, in dp, not the Stage's units)
                return new Frame((ScreenW - 460) / 2, (ScreenH - h) / 2, 460, h);
            }
        }

        // ---- the pointer (screen dp → design units) ----------------------------------------------------------------------
        string _pressed;
        public void Down(float sx, float sy)
        {
            float x = sx / K, y = sy / K;
            _lastY = y; _dragged = 0;
            _pressed = Hit(x, y);
            if (_pressed != null && _pressed.StartsWith("toggle-")) Motion.Timing(_toggles[_pressed.Substring(7)].Press, 1, 90, Motion.OutQuad).Start();
            if (_pressed != null && _pressed.StartsWith("w:")) Wallet?.Down(_pressed.Substring(2));
        }
        public void Wheel(float x, float y, float dy) { if (WallOpen && Wallet != null) Wallet.Scroll(dy); }

        float? _lastY;
        float _dragged;
        public void Move(float sx, float sy)
        {
            float y = sy / K;
            if (_lastY.HasValue && WallOpen && Wallet != null)
            {
                _dragged += Math.Abs(y - _lastY.Value);
                Wallet.Scroll(_lastY.Value - y);
                if (_dragged > 8) _pressed = null;
            }
            _lastY = y;
        }
        public void Up(float sx, float sy)
        {
            float x = sx / K, y = sy / K;
            _lastY = null;
            var h = Hit(x, y);
            var p = _pressed;
            _pressed = null;
            if (p != null && p.StartsWith("toggle-")) Motion.Timing(_toggles[p.Substring(7)].Press, 0, 90, Motion.OutQuad).Start();
            if (h == null || h != p) { if (h == null && Focused == "nick") Focused = null; return; }
            Audio.Snd.Play("tap");
            switch (h)
            {
                case "back": OnBack?.Invoke(); break;
                case "input": Focused = "nick"; break;
                case "save": Save(); break;
                case "link-stats": OnOpenStats?.Invoke(); break;
                case "link-feedback": OpenFeedback(); break;
                case "link-tutorial": OnReplayTutorial?.Invoke(); break;
                case "link-wallet": WallOpen = true; break;
                case "logout": OnLogout?.Invoke(); break;
                case "fb-cancel": CloseFeedback(); break;
                case "fb-send": Send(); break;
                case "fb-input": Focused = "feedback"; break;
                case "wall-close": WallOpen = false; break;
                default:
                    if (h.StartsWith("toggle-")) Switch(h.Substring(7));
                    else if (h.StartsWith("w:")) { var r = Wallet?.Tap(h.Substring(2)); if (r != null) Focused = r; }
                    break;
            }
            if (h != "input" && h != "fb-input" && !(h.StartsWith("w:") && Focused != null && Focused.StartsWith("w")) && Focused == "nick") Focused = null;
        }

        string Hit(float x, float y)
        {
            bool In(Frame r, float slop = 0) => x >= r.X - slop && x < r.Right + slop && y >= r.Y - slop && y < r.Bottom + slop;
            if (Feedback != null)
            {
                var b = FbBox;
                x *= K; y *= K;
                var (cancel, send, input) = FbParts(b);
                if (In(cancel)) return "fb-cancel";
                if (In(send)) return "fb-send";
                if (In(input)) return "fb-input";
                return "fb";
            }
            if (WallOpen && Tester)
            {
                var wf = WallBox;
                if (In(new Frame(SW / 2 + 196, 18, 34, 34), 8)) return "wall-close";
                if (In(wf) && Wallet != null) { var w = Wallet.Hit(x - wf.X, y - wf.Y); return w != null ? "w:" + w : "wall"; }
                return "wall";
            }
            if (In(new Frame(16, 15, 40, 40), 8)) return "back";
            if (In(SaveBox)) return "save";
            var f = Layout();
            foreach (var k in f.Keys)
                if ((k.StartsWith("toggle-") || k.StartsWith("link-") || k == "logout" || k == "input") && In(f[k], k.StartsWith("toggle-") ? 8 : 0))
                    return k;
            return null;
        }

        Frame WallBox => new Frame((SW - 420) / 2, (SH - 330) / 2, 420, 330);

        (Frame cancel, Frame send, Frame input) FbParts(Frame b)
        {
            var (_, lh) = LetteringSize("Feedback", 20);
            float iy = b.Y + 12 + lh + 12;
            float by = iy + 110 + 12;
            float bx = b.X + (b.W - 256) / 2;
            return (new Frame(bx, by, 120, 38), new Frame(bx + 136, by, 120, 38), new Frame(b.X + 18, iy, b.W - 36, 110));
        }

        // ---- the pieces --------------------------------------------------------------------------------------------------
        public List<ScreenPiece> Pieces()
        {
            var f = Layout();
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", PageBg(SW, SH), SW, SH, 0, 0, 1, null, 0));
            StatsView.Header(list, "Settings", string.IsNullOrEmpty(Nickname) ? null : $"Playing as {Nickname}", _pressed == "back");
            foreach (var (id, title) in new[] { ("sound", Tester ? "Options" : "Sound"), ("nickPanel", "Nickname"), ("squad", "Your squad"), ("more", "More") })
            {
                var pf = f[id];
                var s = new UiSvg(pf.W, pf.H);
                Plaque(s, 0, 0, pf.W, pf.H, "vel", 22, 3.5f, 2, 4);
                var tf = f[id + "-title"];
                Lettering(s, title, "gold", 19, tf.X - pf.X, tf.Y - pf.Y);
                list.Add(Piece("panel-" + id, s, pf.X, pf.Y, 1, null, 8));
            }
            foreach (var k in new[] { "music", "effects", "fps" })
            {
                if (!f.TryGetValue("label-" + k, out var lf)) continue;
                string label = k == "music" ? "Music" : k == "effects" ? "Sound effects" : "FPS counter";
                list.Add(Piece("label-" + k, TextBox(label, InkT), lf.X, lf.Y));
                ToggleSwitch(list, k, f["toggle-" + k]);
            }
            Input(list, f["input"]);
            Link(list, "link-stats", "Stats", STATS_D, f["link-stats"]);
            foreach (var (id, label, d) in More) if (f.TryGetValue("link-" + id, out var lf)) Link(list, "link-" + id, label, d, lf);
            Btn(list, "logout", "LOG OUT", "vel", 16, f["logout"], 14, false);
            Btn(list, "save", "SAVE", "gold", 18, SaveBox, 15, true);
            if (WallOpen && Tester) WallPieces(list);
            if (Toast != null)
            {
                var tb = ToastBox;
                var s = new UiSvg(tb.W, tb.H);
                Plaque(s, 0, 0, tb.W, tb.H, "gold");
                s.Text(Toast, 0, (tb.H - LH(ToastT)) / 2, ToastT, tb.W, 0.5f);
                list.Add(Piece("toast", s, tb.X, tb.Y));
            }
            Staged(list, K);
            if (Feedback != null) FeedbackPieces(list);
            return list;
        }

        void Link(List<ScreenPiece> list, string id, string label, string d, Frame at)
        {
            var s = new UiSvg(at.W, at.H);
            Plaque(s, 0, 0, at.W, at.H, "vel", 14);
            float lw = W(label, InkT), lh = LH(InkT);
            Icon(s, d, 14, (at.H - 18) / 2, 18, "#ffffff", 2.3f);
            s.Text(label, 14 + 18 + 10, (at.H - lh) / 2, InkT);
            list.Add(Piece(id, s, at.X, at.Y + (_pressed == id ? 2 : 0), 1, null, 8));
        }

        void Btn(List<ScreenPiece> list, string id, string label, string variant, float size, Frame at, float radius, bool glow)
        {
            if (glow)
            {
                double ph = _glow.GetValue();
                float op = (float)(0.35 + 0.65 * Motion.UpDown(ph));
                list.Add(Piece(id + "-glow", Glow(at.W, at.H, Math.Min(radius, 40), 10), at.W + 20, at.H + 20, at.X - 10, at.Y - 10, op, null, 0));
            }
            var s = new UiSvg(at.W, at.H);
            Plaque(s, 0, 0, at.W, at.H, variant, radius);
            var (lw, lh) = LetteringSize(label, size);
            Lettering(s, label, variant == "gold" ? "whiteB" : "white", size, (at.W - lw) / 2, (at.H - lh) / 2);
            list.Add(Piece(id, s, at.X, at.Y + (_pressed == id ? 2 : 0), 1, null, 8));
        }

        void Input(List<ScreenPiece> list, Frame at)
        {
            var s = new UiSvg(at.W, at.H);
            s.Box(0, 0, at.W, at.H, new BoxStyle { Radius = 12, Background = "rgba(60,30,10,0.4)", BorderWidth = Bw(1.5f), BorderColor = "rgba(255,236,170,0.55)" });
            float lh = LH(InputT), ty = (at.H - lh) / 2;
            float bw = Bw(1.5f);
            if (string.IsNullOrEmpty(Nick)) s.Text("Your name", 12 + bw, ty, Placeholder);
            else s.Text(Nick, 12 + bw, ty, InputT);
            if (Focused == "nick" && CaretOn) s.Box(12 + bw + W(Nick ?? "", InputT), ty, 1.5f, lh, new BoxStyle { Background = "#ffffff" });
            list.Add(Piece("input", s, at.X, at.Y));
        }

        // candy/ToggleSwitch.js: 58 x 30 (+ 3 lip), the ring crossfading OFF → ON, the face's two gradients and captions
        // crossfading, the shine, the knob sliding across (and squashing while held)
        const float TW = 58, TH = 30, KNOB = TH - (2 + 2.5f) * 2 - 4, TRAVEL = TW - (2 + 2.5f) * 2 - KNOB - 4;
        static string _tOff, _tOn, _tLipOff, _tLipOn, _tShine, _tKnob;

        void ToggleSwitch(List<ScreenPiece> list, string k, Frame at)
        {
            var tg = _toggles[k];
            double pos = tg.Pos.GetValue(), press = tg.Press.GetValue();
            float onOp = (float)Math.Max(0, Math.Min(1, pos)), offOp = 1 - onOp;
            _tLipOff ??= new UiSvg(TW, TH + 3).Box(0, 0, TW, TH + 3, new BoxStyle { Radius = TH / 2 + 1.5f, Background = INK }).Markup;
            _tLipOn ??= new UiSvg(TW, TH + 3).Box(0, 0, TW, TH + 3, new BoxStyle { Radius = TH / 2 + 1.5f, Background = "#0b6f68" }).Markup;
            _tOff ??= ToggleFace(false);
            _tOn ??= ToggleFace(true);
            float rimB = Bw(2.5f), px = 2 + rimB, pw = TW - 2 * px, ph = TH - 2 * px;
            _tShine ??= ShineOnly(px, pw, ph);
            _tKnob ??= Knob();
            list.Add(Piece("tg-lipoff-" + k, _tLipOff, TW, TH + 3, at.X, at.Y, offOp));
            list.Add(Piece("tg-lipon-" + k, _tLipOn, TW, TH + 3, at.X, at.Y, onOp));
            list.Add(Piece("tg-off-" + k, _tOff, TW, TH, at.X, at.Y, offOp, null, 2));
            list.Add(Piece("tg-on-" + k, _tOn, TW, TH, at.X, at.Y, onOp, null, 2));
            list.Add(Piece("tg-shine-" + k, _tShine, TW, TH, at.X, at.Y, 1, null, 0));
            var m = Affine.Translate(px + 2 + TRAVEL * pos, px + 2) * About(KNOB, KNOB, Affine.ScaleBy(1 + 0.18 * press, 1 - 0.14 * press));
            list.Add(Piece("tg-knob-" + k, _tKnob, KNOB, KNOB + 1.5f, at.X, at.Y, 1, m, 2));
        }

        static string ToggleFace(bool on)
        {
            var colors = on ? new[] { "#c8fff4", "#4fe6cf", "#14b3a0" } : new[] { "#efe6dc", "#d6c2a8", "#b39878" };
            string ring = on ? "#0b6f68" : INK;
            var s = new UiSvg(TW, TH);
            float rimB = Bw(2.5f);
            // the rim's white border (2 in from the ring) and, inside it, the gradient and the caption
            s.Box(2, 2, TW - 4, TH - 4, new BoxStyle { Radius = TH / 2, BorderWidth = rimB, BorderColor = "#ffffff" });
            float px = 2 + rimB, pw = TW - 2 * px, ph = TH - 2 * px;
            s.Box(px, px, pw, ph, new BoxStyle { Radius = TH / 2 - rimB, Gradient = colors, GradientStops = new[] { 0f, 0.55f, 1 } });
            var cap = T(Kit.Display, 10, "#ffffff", 0.6f, TH - (2 + 2.5f) * 2, Outline3(ring, 1.5f));
            string text = on ? "ON" : "OFF";
            float x = on ? px + 7 : px + pw - 6 - W(text, cap);
            s.Text(text, x, px, cap);
            return s.Markup;
        }

        static string ShineOnly(float px, float pw, float ph)
        {
            var s = new UiSvg(TW, TH);
            Shine(s, px, px, pw, ph, 0, 0.44f, 999, TH / 2 - (px - 2));
            return s.Markup;
        }

        static string Knob()
        {
            var s = new UiSvg(KNOB, KNOB + 1.5f);
            s.Box(0, 1.5f, KNOB, KNOB, new BoxStyle { Radius = KNOB / 2, Background = "rgba(69,24,154,0.35)" });
            s.Box(0, 0, KNOB, KNOB, new BoxStyle { Radius = KNOB / 2, Gradient = new[] { "#ffffff", "#fff6ea", "#f0dcc0" }, GradientStops = new[] { 0f, 0.5f, 1 } });
            s.Box(KNOB * 0.18f, KNOB * 0.12f, KNOB * 0.42f, KNOB * 0.32f, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.95)" });
            return s.Markup;
        }

        void FeedbackPieces(List<ScreenPiece> list)
        {
            float op = (float)_modal.GetValue();
            list.Add(Piece("fb-scrim", new UiSvg(ScreenW, ScreenH).Box(0, 0, ScreenW, ScreenH, new BoxStyle { Background = "rgba(40,20,8,0.55)" }), 0, 0, op, null, 0));
            var b = FbBox;
            var s = new UiSvg(b.W, b.H);
            Plaque(s, 0, 0, b.W, b.H, "vel", 22, 3.5f, 2, 4);
            var (lw, lh) = LetteringSize("Feedback", 20);
            Lettering(s, "Feedback", "gold", 20, (b.W - lw) / 2, 12);
            var (cancel, send, input) = FbParts(b);
            float ix = input.X - b.X, iy = input.Y - b.Y;
            s.Box(ix, iy, input.W, input.H, new BoxStyle { Radius = 14, Background = "rgba(60,30,10,0.4)", BorderWidth = Bw(1.5f), BorderColor = "rgba(255,236,170,0.55)" });
            var ft = T(Body, 14, "#ffffff");
            float bw = Bw(1.5f);
            if (string.IsNullOrEmpty(Feedback)) s.Text("Tell us what you think...", ix + 12 + bw, iy + 12 + bw, T(Body, 14, "#e8c9a0"));
            else new Ui.Screens.TextFlow(Feedback, ft).Draw(s, ix + 12 + bw, iy + 12 + bw, input.W - 24 - 2 * bw);
            list.Add(Piece("fb", s, b.X, b.Y, op, null, 8));
            int n = list.Count;
            Btn(list, "fb-cancel", "CANCEL", "vel", 15, cancel, 12, false);
            Btn(list, "fb-send", "SEND", "gold", 15, send, 12, false);
            for (int i = n; i < list.Count; i++) list[i].Opacity *= op;
        }

        void WallPieces(List<ScreenPiece> list)
        {
            list.Add(Piece("wall-scrim", new UiSvg(SW, SH).Box(0, 0, SW, SH, new BoxStyle { Background = "rgba(40,20,8,0.55)" }), 0, 0, 1, null, 0));
            var wb = WallBox;
            var s = new UiSvg(wb.W, wb.H);
            Plaque(s, 0, 0, wb.W, wb.H, "pearl", 22, 3.5f, 2, 4);
            list.Add(Piece("wall", s, wb.X, wb.Y, 1, null, 8));
            if (Wallet != null)
                foreach (var p in Wallet.Pieces(Focused, CaretOn))
                {
                    p.Transform = Affine.Translate(wb.X, wb.Y) * p.Transform;
                    list.Add(p);
                }
            list.Add(Piece("orb-close34", Xml("orb-close34"), 34, 34, SW / 2 + 196, 18 + (_pressed == "wall-close" ? 2 : 0)));
        }
    }
}
