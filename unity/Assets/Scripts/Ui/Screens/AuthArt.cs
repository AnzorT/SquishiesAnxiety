// src/screens/AuthScreen.js drawn from the Unity code, sideways (the phone's landscape, `wide`): Mittens, the title and
// the line under it on the left, the card on the right: the Log in / Register switch with its gold pill, the squad name
// and age row (register), email and password side by side, the error line, the gold button beside "Keep me signed in",
// OR, and the Google / Facebook / TikTok row; or, for an age under 13, the parent line. Laid out by Yoga from the
// StyleSheet's numbers (each FlexNode below is one of the component's Views or Texts), drawn the way the UI exporter
// writes what Chrome paints (UiSvg). The logos and the tick are the app's own SVG drawings.
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Screens
{
    /// <summary>What's moving or held on the screen (not the form's data, which is AuthModel).</summary>
    public sealed class AuthUi
    {
        public string Focus;            // "nick", "age", "email", "pass" or null
        public bool CaretOn = true;
        public double PillX;            // ModeSwitch's x: 0 log in, 1 register (overshoots on its bezier)
        public double LabelT = 1;       // useFadeUp: 0..1
        public string Pressed;          // the button held down ("submit", "google", ...)
        public double DotsMs;           // HopDots' clock while submitting
        public float ScrollY;           // the card column scrolled (when it's taller than the screen)
        /// <summary>Frames to draw at instead of the layout's (LayoutAnimation in between two layouts).</summary>
        public Dictionary<string, Frame> FramesOverride;
        public Dictionary<string, float> Fade;   // pieces fading in / out with LayoutAnimation (id -> opacity)
    }

    public sealed class AuthArt
    {
        // REDESIGN_V8's wood colours (AuthScreen.js)
        public const string PURPLE = "#6b4426", LABEL = "#8a5a34", INK = "#5b3418", LINE = "#ecd3ae", FOCUS = "#e08a2c";
        public const string GOLD_RING = "#9c4d06";
        public static readonly string[] GOLD = { "#fff7b0", "#ffd23a", "#ff9c0a" };
        const float GAP = 8, INPUT_H = 48;   // the card's gap in landscape (cardWide)
        static float B25 => FlexNode.Bw(2.5f);   // borderWidth 2.5, as drawn

        public const string Display = "Fredoka_700Bold", Black = "Nunito_900Black", Heavy = "Nunito_800ExtraBold";

        public readonly float W, H;
        public AuthArt(float w, float h) { W = w; H = h; }

        static TextStyle T(string font, float size, string color, float ls = 0, float lh = 0) => new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = ls, LineHeight = lh };
        public static readonly TextStyle TitleStyle = new TextStyle
        {
            Font = Display, Size = 38, LineHeight = 44, Color = "#ffffff",
            Shadows = new[] { new Shadow(PURPLE, 0, 4, 0), new Shadow(PURPLE, 2.5f, 0, 0), new Shadow(PURPLE, -2.5f, 0, 0), new Shadow(PURPLE, 0, -2.5f, 0) },
        };
        static readonly TextStyle SubStyle = T(Heavy, 13.5f, PURPLE);
        static readonly TextStyle TabStyle = T(Display, 16, INK);
        static readonly TextStyle LabelStyle = T(Black, 11, LABEL, 1, 16);
        static readonly TextStyle InputStyle = T(Heavy, 15, INK);
        static readonly TextStyle EyeStyle = T(Black, 12, FOCUS);
        static readonly TextStyle ErrorStyle = T(Heavy, 12.5f, "#c4204f", 0, 17);
        static readonly TextStyle BlockedStyle = T(Heavy, 15, INK, 0, 22);
        static readonly TextStyle KeepStyle = T(Heavy, 13, INK);
        static readonly TextStyle OrStyle = T(Black, 10.5f, "#b48a5e", 1.2f);
        static readonly TextStyle SocialStyle = T(Black, 11, INK);
        public static TextStyle BtnStyle(float size, string ring) => new TextStyle
        {
            Font = Display, Size = size, Color = "#ffffff",
            // outline3(ring, 2): [0, 2], [1, 0], [-1, 0]
            Shadows = new[] { new Shadow(ring, 0, 2, 0), new Shadow(ring, 1, 0, 0), new Shadow(ring, -1, 0, 0) },
        };
        static readonly TextStyle SubmitText = BtnStyle(18, GOLD_RING);

        public const string Sub = "Log in or make an account to save your squad.";
        public const string BlockedText = "This game needs a parent or guardian to help set up an account. Ask them to continue!";
        static readonly (string id, string label, string logo)[] Socials = { ("google", "Google", GoogleLogo), ("facebook", "Facebook", FacebookLogo), ("tiktok", "TikTok", TikTokLogo) };

        // the fields: id, label, placeholder, the model's value, password
        public static readonly string[] FieldIds = { "nick", "age", "email", "pass" };

        static FlexNode Txt(string name, TextFlow flow) => FlexNode.Leaf(name, flow.Measure);
        static FlexNode Txt(string name, string text, TextStyle st) => Txt(name, new TextFlow(text, st));

        // ---- layout --------------------------------------------------------------------------------------------
        /// <summary>Every node's frame (dp, on screen) for this state. `ScrollMax` tells how far the card column scrolls.</summary>
        public Dictionary<string, Frame> Layout(AuthModel m, out float scrollMax)
        {
            // <IntroBackground><KeyboardAvoidingView style={[flex, wideRow]}>
            var root = new FlexNode("root").Row();
            var hero = root.Add(new FlexNode("hero").WidthPct(34).AlignItems(YGAlign.Center).Justify(YGJustify.Center).PadH(12));
            hero.Add(new FlexNode("mittens").Size(132, 132).Margin(YGEdge.Bottom, -6));
            hero.Add(Txt("title", "Squish Squad", TitleStyle));
            hero.Add(Txt("sub", new TextFlow(Sub, SubStyle, 0.5f)).AlignSelf(YGAlign.Center).Margin(YGEdge.Top, 6).Margin(YGEdge.Bottom, 12));
            var scroll = root.Add(new FlexNode("scroll").Flex(1));
            root.Layout(W, H);
            var frames = new Dictionary<string, Frame>();
            root.Walk(n => frames[n.Name] = n.Frame);
            var sf = frames["scroll"];

            // the ScrollView's content: flexGrow 1, centred, padding 10 / 26 right / 4 left (scrollContent + scrollWide)
            var content = new FlexNode("content").Width(sf.W).Justify(YGJustify.Center)
                .Padding(YGEdge.Top, 10).Padding(YGEdge.Bottom, 10).Padding(YGEdge.Left, 4).Padding(YGEdge.Right, 26);
            Facebook.Yoga.YGNodeStyleAPI.YGNodeStyleSetMinHeight(content.Node, sf.H);
            var lip = content.Add(new FlexNode("lip").Padding(YGEdge.Bottom, 5));
            var card = lip.Add(new FlexNode("card").Border(2.5f).Padding(YGEdge.Top, 10).PadH(16).Padding(YGEdge.Bottom, 12).Gap(GAP));
            var track = card.Add(new FlexNode("track").Row().Padding(4));
            track.Add(new FlexNode("tab-login").Flex(1).AlignItems(YGAlign.Center).PadV(9)).Add(Txt("tab-login-t", "Log in", TabStyle));
            track.Add(new FlexNode("tab-register").Flex(1).AlignItems(YGAlign.Center).PadV(9)).Add(Txt("tab-register-t", "Register", TabStyle));
            if (m.Blocked)
                card.Add(Txt("blocked", new TextFlow(BlockedText, BlockedStyle, 0.5f)).PadV(8));
            else
            {
                if (m.Register)
                {
                    var reg = card.Add(new FlexNode("row-reg").Row().Gap(10));
                    reg.Add(Field("nick", "SQUAD NAME").Flex(1));
                    reg.Add(Field("age", "AGE").Width(84));
                }
                var cred = card.Add(new FlexNode("row-cred").Row().Gap(10));
                cred.Add(Field("email", "EMAIL").Flex(1));
                cred.Add(Field("pass", "PASSWORD").Flex(1));
                if (!string.IsNullOrEmpty(m.Error))
                    card.Add(Txt("error", new TextFlow(m.Error, ErrorStyle)).PadH(11).PadV(8));
                var sub = card.Add(new FlexNode("submit-row").Row().AlignItems(YGAlign.Center).Gap(14));
                // TutTarget (flex 1) > CandyBtn (alignSelf stretch) > Ringed: the ring with its lip > the face
                var tut = sub.Add(new FlexNode("submit").Flex(1));
                var ring = tut.Add(new FlexNode("submit-ring").AlignSelf(YGAlign.Stretch).Padding(2.5f).Padding(YGEdge.Bottom, 7.5f));
                var face = ring.Add(new FlexNode("submit-face").Border(3).PadV(8).PadH(14).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(5));
                if (m.Submitting) face.Add(new FlexNode("dots").Row().Gap(5).Padding(YGEdge.Top, 7).Height(26).With(new FlexNode("dot0").Size(14, 16), new FlexNode("dot1").Size(14, 16), new FlexNode("dot2").Size(14, 16)));
                else face.Add(Txt("label", m.ButtonLabel, SubmitText));
                var keep = sub.Add(new FlexNode("keep").Row().AlignItems(YGAlign.Center).Gap(8).AlignSelf(YGAlign.FlexStart));
                keep.Add(new FlexNode("keep-box").Size(20, 20));
                keep.Add(Txt("keep-t", "Keep me signed in", KeepStyle));
                var or = card.Add(new FlexNode("or").Row().AlignItems(YGAlign.Center).Gap(10).Margin(YGEdge.Top, 2));
                or.Add(new FlexNode("or-l1").Flex(1).Height(2));
                or.Add(Txt("or-t", "OR", OrStyle));
                or.Add(new FlexNode("or-l2").Flex(1).Height(2));
                var socials = card.Add(new FlexNode("socials").Row().Gap(7));
                foreach (var (id, label, _) in Socials)
                {
                    var s = socials.Add(new FlexNode("s-" + id).Flex(1).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(6)
                        .Padding(YGEdge.Top, 6).Padding(YGEdge.Bottom, 5).Border(2.5f).Border(YGEdge.Bottom, 4));
                    s.Add(new FlexNode("s-" + id + "-logo").Size(26, 26));
                    s.Add(Txt("s-" + id + "-t", label, SocialStyle));
                }
            }
            content.Layout(sf.W, float.NaN);
            float ch = content.Frame.H;
            scrollMax = Math.Max(0, ch - sf.H);
            content.Offset(sf.X, sf.Y);
            content.Walk(n => frames[n.Name] = n.Frame);
            return frames;
        }

        static FlexNode Field(string id, string label)
        {
            var f = new FlexNode("f-" + id);
            f.Add(Txt("f-" + id + "-label", label, LabelStyle).Margin(YGEdge.Bottom, 4));
            f.Add(new FlexNode("f-" + id + "-input").Height(INPUT_H));
            return f;
        }

        // ---- drawing -------------------------------------------------------------------------------------------
        public static string Value(AuthModel m, string id) => id == "nick" ? m.Nickname : id == "age" ? m.Age : id == "email" ? m.Email : m.Password;
        static string Placeholder(string id) => id == "nick" ? "Captain Squish" : id == "age" ? "13+" : id == "email" ? "you@example.com" : "At least 6 characters";

        public List<ScreenPiece> Pieces(AuthModel m, AuthUi ui, Dictionary<string, Frame> layout)
        {
            var f = ui.FramesOverride ?? layout;
            var list = new List<ScreenPiece>();
            float sy = -ui.ScrollY;
            bool Has(string k) => f.ContainsKey(k);
            Frame Fr(string k) { var r = f[k]; return r; }
            Frame Sc(string k) { var r = f[k]; r.Y += sy; return r; }   // in the scrolled column
            float Fade(string id) => ui.Fade != null && ui.Fade.TryGetValue(id, out var o) ? o : 1;
            ScreenPiece Add(string id, UiSvg svg, Frame at, float opacity = 1, Affine? extra = null)
            {
                var p = new ScreenPiece { Id = id, Svg = svg.Markup, W = svg.W, H = svg.H, Opacity = opacity * Fade(id) };
                p.Transform = Affine.Translate(Screens.Pieces.Snap(at.X), Screens.Pieces.Snap(at.Y)) * (extra ?? Affine.Identity);
                list.Add(p);
                return p;
            }

            list.Add(new ScreenPiece { Id = "bg", Svg = IntroArt.Svg(W, H), W = W, H = H, Margin = 0 });
            var mf = Fr("mittens");
            list.Add(new ScreenPiece { Id = "mittens", Slot = true, W = mf.W, H = mf.H, Transform = Affine.Translate(mf.X, mf.Y) });
            var tf = Fr("title");
            Add("title", new UiSvg(tf.W, tf.H).Text("Squish Squad", 0, 0, TitleStyle), tf);
            var subf = Fr("sub");
            { var s = new UiSvg(subf.W, subf.H); new TextFlow(Sub, SubStyle, 0.5f).Draw(s, 0, 0, subf.W); Add("sub", s, subf); }

            // the card: the lip (the brown under it) and the cream card in its brown outline
            var lf = Sc("lip"); var cf = Sc("card");
            {
                var s = new UiSvg(lf.W, lf.H);
                s.Box(0, 0, lf.W, lf.H, new BoxStyle { Radius = 26, Background = PURPLE });
                s.Box(cf.X - lf.X, cf.Y - lf.Y, cf.W, cf.H, new BoxStyle { Radius = 26, Background = "#fff6e2", BorderWidth = B25, BorderColor = PURPLE });
                Add("card", s, lf);
            }
            // Log in | Register: the track, the pill under the chosen side, the labels
            var trf = Sc("track");
            Add("track", new UiSvg(trf.W, trf.H).Box(0, 0, trf.W, trf.H, new BoxStyle { Radius = 999, Background = "#f3dfbd" }), trf);
            float half = (trf.W - 8) / 2;
            {
                float ph = trf.H - 8;
                var s = new UiSvg(half, ph);
                s.Box(-2, -2, half + 4, ph + 7, new BoxStyle { Radius = 999, Background = GOLD_RING });
                s.Box(0, 0, half, ph, new BoxStyle { Radius = 999, Gradient = GOLD, GradientStops = new[] { 0f, 0.55f, 1f } });
                Add("pill", s, new Frame(trf.X + 4, trf.Y + 4, half, ph), 1, Affine.Translate(ui.PillX * half, 0));
            }
            foreach (var (id, label, reg) in new[] { ("tab-login", "Log in", false), ("tab-register", "Register", true) })
            {
                var tt = Sc(id + "-t");
                var st = T(Display, 16, m.Register == reg ? INK : LABEL);
                Add(id, new UiSvg(tt.W, tt.H).Text(label, 0, 0, st), tt);
            }

            if (Has("blocked"))
            {
                var bf = Sc("blocked");
                var s = new UiSvg(bf.W, bf.H);
                new TextFlow(BlockedText, BlockedStyle, 0.5f).Draw(s, 0, 8, bf.W);
                Add("blocked", s, bf);
                return list;
            }

            foreach (var id in FieldIds)
            {
                if (!Has("f-" + id)) continue;
                var lab = Sc("f-" + id + "-label");
                string label = id == "nick" ? "SQUAD NAME" : id == "age" ? "AGE" : id == "email" ? "EMAIL" : "PASSWORD";
                Add("f-" + id + "-label", new UiSvg(lab.W, lab.H).Text(label, 0, 0, LabelStyle), lab);
                var inf = Sc("f-" + id + "-input");
                var (box, caretX) = Input(id, Value(m, id), inf.W, ui.Focus == id, id == "pass" && !m.ShowPass, id == "pass");
                Add("f-" + id + "-input", box, inf);
                if (id == "pass")
                {
                    // Show / Hide inside the input's right end (right 12, centred)
                    string eye = m.ShowPass ? "Hide" : "Show";
                    float ew = UiSvg.BoxWidth(eye, EyeStyle), eh = UiSvg.LineBox(EyeStyle);
                    var ef = new Frame(inf.Right - 12 - ew, inf.Y + (inf.H - eh) / 2, ew, eh);
                    Add("eye", new UiSvg(ew, eh).Text(eye, 0, 0, EyeStyle), ef);
                    f["eye"] = ef;   // (for the tap)
                }
                if (ui.Focus == id && ui.CaretOn)
                {
                    float lh = UiSvg.LineBox(InputStyle);
                    Add("caret", new UiSvg(1.5f, lh).Box(0, 0, 1.5f, lh, new BoxStyle { Background = INK }), new Frame(inf.X + caretX, inf.Y + (INPUT_H - lh) / 2, 1.5f, lh));
                }
            }

            if (Has("error"))
            {
                var ef = Sc("error");
                var s = new UiSvg(ef.W, ef.H);
                s.Box(0, 0, ef.W, ef.H, new BoxStyle { Radius = 12, Background = "#ffe6ee" });
                new TextFlow(m.Error, ErrorStyle).Draw(s, 11, 8, ef.W - 22);
                Add("error", s, ef);
            }

            // the gold button (CandyBtn kind gold, padV 8, lip 5): it moves down 3 while held
            var press = ui.Pressed == "submit" ? Affine.Translate(0, 3) : Affine.Identity;
            var rf = Sc("submit-ring"); var ff = Sc("submit-face");
            Add("submit", CandyBody(rf.W, rf.H, ff.X - rf.X, ff.Y - rf.Y, ff.W, ff.H, GOLD, new[] { 0f, 0.5f, 1f }, GOLD_RING), rf, 1, press);
            if (Has("label"))
            {
                var lb = Sc("label");
                // useFadeUp: opacity t, translateY 6 -> 0
                double t = ui.LabelT;
                Add("label", new UiSvg(lb.W, lb.H).Text(m.ButtonLabel, 0, 0, SubmitText), lb, (float)t, Affine.Translate(0, 6 * (1 - t)) * press);
            }
            for (int i = 0; i < 3; i++)
            {
                if (!Has("dot" + i)) continue;
                var df = Sc("dot" + i);
                var (svg, tr, op) = HopDot(i, ui.DotsMs, 14);
                Add("dot" + i, svg, df, op, press * tr);
            }
            // Keep me signed in
            var kb = Sc("keep-box");
            Add("keep-box", KeepBox(m.Keep), kb);
            var kt = Sc("keep-t");
            Add("keep-t", new UiSvg(kt.W, kt.H).Text("Keep me signed in", 0, 0, KeepStyle), kt);
            // OR
            foreach (var l in new[] { "or-l1", "or-l2" }) { var lf2 = Sc(l); Add(l, new UiSvg(lf2.W, lf2.H).Box(0, 0, lf2.W, lf2.H, new BoxStyle { Radius = 1, Background = LINE }), lf2); }
            var ot = Sc("or-t");
            Add("or-t", new UiSvg(ot.W, ot.H).Text("OR", 0, 0, OrStyle), ot);
            // the social buttons: they move down 2 while held
            foreach (var (id, label, logo) in Socials)
            {
                var sf = Sc("s-" + id);
                var s = new UiSvg(sf.W, sf.H);
                s.Box(0, 0, sf.W, sf.H, new BoxStyle { Radius = 16, Background = "#ffffff", Borders = new[] { B25, B25, 4f, B25 }, BorderColor = LINE });
                var lg = Sc("s-" + id + "-logo");
                s.Drawing(logo, lg.X - sf.X, lg.Y - sf.Y, 26, 26, "0 0 24 24");
                var lt = Sc("s-" + id + "-t");
                s.Text(label, lt.X - sf.X, lt.Y - sf.Y, SocialStyle);
                Add("s-" + id, s, sf, 1, ui.Pressed == id ? Affine.Translate(0, 2) : Affine.Identity);
            }
            return list;
        }

        // ---- pieces shared with the other intro screens -----------------------------------------------------------

        /// <summary>The input (white, rounded, its border orange while focused) with its text or placeholder, the text
        /// scrolled so its end shows. Returns the caret's x in the box.</summary>
        public static (UiSvg svg, float caretX) Input(string id, string value, float w, bool focus, bool secure, bool eye)
        {
            var s = new UiSvg(w, INPUT_H);
            s.Box(0, 0, w, INPUT_H, new BoxStyle { Radius = 16, Background = "#ffffff", BorderWidth = B25, BorderColor = focus ? FOCUS : LINE });
            float x0 = B25 + 14, x1 = w - B25 - (eye ? 64 : 14);
            string shown = string.IsNullOrEmpty(value) ? Placeholder(id) : secure ? new string('•', value.Length) : value;
            var st = string.IsNullOrEmpty(value) ? T(Heavy, 15, "#b9976e") : InputStyle;
            float tw = UiSvg.Width(shown, st);
            float scroll = string.IsNullOrEmpty(value) ? 0 : Math.Max(0, tw + 1.5f - (x1 - x0));
            float lh = UiSvg.LineBox(st);
            float top = (INPUT_H - lh) / 2;
            var clip = s.NewId("ic");
            s.Def($"<clipPath id=\"{clip}\"><rect x=\"{UiSvg.F(x0)}\" y=\"{UiSvg.F(B25)}\" width=\"{UiSvg.F(Math.Max(0, x1 - x0))}\" height=\"{UiSvg.F(INPUT_H - 2 * B25)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"").Text(shown, x0 - scroll, top, st).Close();
            float caret = string.IsNullOrEmpty(value) ? x0 : x0 + tw - scroll;
            return (s, caret);
        }

        /// <summary>CandyBtn's Ringed look: the ring colour round it with a deeper lip, a white 3 dp rim, the gradient face
        /// and its shine (left / right 9 %, top 2, 42 % tall, white 45 %).</summary>
        public static UiSvg CandyBody(float w, float h, float fx, float fy, float fw, float fh, string[] colors, float[] stops, string ring)
        {
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Radius = 1001.5f, Background = ring });
            // the face: its gradient over the padding box, under the white border
            s.Box(fx + 3, fy + 3, fw - 6, fh - 6, new BoxStyle { Radius = 996, Gradient = colors, GradientStops = stops });
            s.Box(fx, fy, fw, fh, new BoxStyle { Radius = 999, BorderWidth = FlexNode.Bw(3), BorderColor = "#ffffff" });
            float pw = fw - 6, ph = fh - 6;
            s.Box(fx + 3 + pw * 0.09f, fy + 3 + 2, pw * 0.82f, ph * 0.42f, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.45)" });
            return s;
        }

        static UiSvg KeepBox(bool on)
        {
            var s = new UiSvg(20, 20);
            if (on)
            {
                s.Box(0, 0, 20, 20, new BoxStyle { Radius = 7, Background = "#ffffff" });
                s.Box(B25, B25, 20 - 2 * B25, 20 - 2 * B25, new BoxStyle { Radius = 7 - B25, Gradient = new[] { "#ffd23a", "#ff9c0a" } });
                s.Box(0, 0, 20, 20, new BoxStyle { Radius = 7, BorderWidth = B25, BorderColor = FOCUS });
                s.Drawing(Tick, 4, 4, 12, 12, "0 0 12 12");
            }
            else s.Box(0, 0, 20, 20, new BoxStyle { Radius = 7, Background = "#ffffff", BorderWidth = B25, BorderColor = FOCUS });
            return s;
        }

        // HopDots: one ball (pink, gold, blue) on its 1 s loop, `delay` 0 / 150 / 300 ms in
        static readonly double[] HopIn = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.85, 0.92, 1 };
        static readonly double[] HopUp = { 0, 0.44, 0.75, 0.94, 1, 0.94, 0.75, 0.44, 0, 0, 0, 0 };
        static readonly (string[] colors, float[] stops, string ring)[] DotKinds =
        {
            (new[] { "#ffe2c8", "#ff9a4a", "#e0601c" }, new[] { 0f, 0.55f, 1f }, "#8a3a0e"),
            (new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, new[] { 0f, 0.5f, 1f }, "#9c4d06"),
            (new[] { "#b0fbff", "#3fd7f6", "#1695d6" }, new[] { 0f, 0.55f, 1f }, "#0c5a9c"),
        };

        static double Interp(double p, double[] xs, double[] ys)
        {
            for (int i = 0; i < xs.Length - 1; i++) if (p <= xs[i + 1]) return ys[i] + (ys[i + 1] - ys[i]) * (p - xs[i]) / (xs[i + 1] - xs[i]);
            return ys[ys.Length - 1];
        }

        public static (UiSvg svg, Affine tr, float opacity) HopDot(int i, double ms, float size)
        {
            var (colors, stops, ring) = DotKinds[i];
            double t = ms - i * 150;
            double p = t < 0 ? 0 : (t % 1000) / 1000;
            float hop = size / 2;
            double ty = -Interp(p, HopIn, HopUp) * hop;
            double sx = Interp(p, new[] { 0, 0.8, 0.85, 0.92, 1 }, new[] { 1, 1, 1.18, 1, 1 });
            double sy = Interp(p, new[] { 0, 0.8, 0.85, 0.92, 1 }, new[] { 1, 1, 0.8, 1, 1 });
            double op = Interp(p, new[] { 0, 0.4, 0.8, 1 }, new[] { 0.65, 1, 0.65, 0.65 });
            float r = size / 2, rw = Math.Max(1, size / 12);
            var s = new UiSvg(size, size + 2);
            s.Box(0, 2, size, size, new BoxStyle { Radius = r, Background = ring });   // the lip (top 2)
            s.Box(0, 0, size, size, new BoxStyle { Radius = r, Background = ring });
            s.Box(rw, rw, size - 2 * rw, size - 2 * rw, new BoxStyle { Radius = r, Background = "#ffffff" });
            float fi = 2 * rw, fs = size - 4 * rw;
            s.Box(fi, fi, fs, fs, new BoxStyle { Radius = r, Gradient = colors, GradientStops = stops });
            s.Box(fi, fi, fs, fs * 0.44f, new BoxStyle { Radius = 999, Gradient = new[] { "rgba(255,255,255,0.85)", "rgba(255,255,255,0.1)" } });
            // transform about the ball's centre (RN's default origin)
            float cx = size / 2, cy = (size + 2) / 2;
            var tr = Affine.Translate(0, ty) * Affine.Translate(cx, cy) * Affine.ScaleBy(sx, sy) * Affine.Translate(-cx, -cy);
            return (s, tr, (float)op);
        }

        // ---- taps ----------------------------------------------------------------------------------------------------
        /// <summary>What a tap at (x, y) dp hits: a tab, a field, the eye, the button, the box, a social button.</summary>
        public string HitTest(Dictionary<string, Frame> f, AuthUi ui, float x, float y)
        {
            float sy = ui.ScrollY;
            bool In(string k, float slop = 0) => f.TryGetValue(k, out var r) && r.Inset(slop).Contains(x, y + sy);
            if (f.ContainsKey("eye") && f["eye"].Inset(8).Contains(x, y)) return "eye";
            foreach (var id in FieldIds) if (In("f-" + id + "-input")) return id;
            if (In("tab-login")) return "tab-login";
            if (In("tab-register")) return "tab-register";
            if (In("submit-ring")) return "submit";
            if (In("keep", 6)) return "keep";
            foreach (var (id, _, _) in Socials) if (In("s-" + id)) return id;
            return null;
        }

        // ---- the app's own drawings (AuthScreen.js) ------------------------------------------------------------------
        public const string Tick = "<path d=\"M2.5 6.2 L5 8.6 L9.6 3.4\" stroke=\"#ffffff\" stroke-width=\"2.2\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>";
        const string GoogleLogo =
            "<path d=\"M21.6 12.2c0-.7-.1-1.4-.2-2H12v3.8h5.4a4.6 4.6 0 0 1-2 3v2.5h3.2c1.9-1.7 3-4.3 3-7.3z\" fill=\"#4285F4\"/>" +
            "<path d=\"M12 22c2.7 0 5-.9 6.6-2.5l-3.2-2.5c-.9.6-2 1-3.4 1a5.9 5.9 0 0 1-5.6-4.1H3.1v2.6A10 10 0 0 0 12 22z\" fill=\"#34A853\"/>" +
            "<path d=\"M6.4 13.9a6 6 0 0 1 0-3.8V7.5H3.1a10 10 0 0 0 0 9z\" fill=\"#FBBC05\"/>" +
            "<path d=\"M12 6c1.5 0 2.8.5 3.8 1.5l2.9-2.9A10 10 0 0 0 3.1 7.5l3.3 2.6A5.9 5.9 0 0 1 12 6z\" fill=\"#EA4335\"/>";
        const string FacebookLogo =
            "<circle cx=\"12\" cy=\"12\" r=\"11\" fill=\"#1877F2\"/>" +
            "<path d=\"M13.2 19v-6.1h2.1l.3-2.4h-2.4V9c0-.7.2-1.2 1.2-1.2h1.3V5.7c-.2 0-1-.1-1.9-.1-1.9 0-3.1 1.1-3.1 3.2v1.7H8.6v2.4h2.1V19z\" fill=\"#ffffff\"/>";
        const string TT = "M14.6 6.5c.4 1.3 1.4 2.2 2.7 2.3v2a4.6 4.6 0 0 1-2.7-.9v4.2a3.6 3.6 0 1 1-3.6-3.6h.4v2.1a1.5 1.5 0 1 0 1.1 1.5V6.5z";
        const string TikTokLogo =
            "<circle cx=\"12\" cy=\"12\" r=\"11\" fill=\"#111111\"/>" +
            "<path d=\"" + TT + "\" fill=\"#25F4EE\" transform=\"translate(-0.5,-0.4)\"/>" +
            "<path d=\"" + TT + "\" fill=\"#FE2C55\" transform=\"translate(0.5,0.4)\"/>" +
            "<path d=\"" + TT + "\" fill=\"#ffffff\"/>";
    }
}
