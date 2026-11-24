// src/screens/AuthScreen.js (develop, 2026-11-20: remodelled in the game's wood and gold, src/screens/auth/kit.js),
// drawn from the Unity code. The front door of the same game: the Main Menu's house softened behind (assets/auth/
// house-bg.jpg, "cover"), along the top Mittens (the live creature in its slot; the app's still, assets/auth/mittens.png,
// until it's drawn) beside the plush SQUISH SQUAD logo, and under them one wood panel (royal Plaque "vel"): the Log in |
// Register switch (a gold pill springing across a dark inset track), email and password side by side (to register the
// squad name and the age join the row), the gold button the panel's whole width (Btn: its light sweeping across every
// 3.4 s) with "Keep me signed in" under it, then OR (or the error in its place) and the Google / Facebook / TikTok
// pearl plaques. An age under 13: "Ask a grown-up!" and the parent line. Sizes follow the phone's height (useAuthSizes:
// 360, 384, 412). Laid out by Yoga (FlexNode), drawn the way the UI exporter writes what Chrome paints (UiSvg), the
// royal pieces from Screens/Kit.
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Screens;
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
        public double DotsMs;           // the waiting dots' clock while submitting
        public double GlintMs;          // the button's light sweep's clock (its 3.4 s loop)
        public bool CreatureShown;      // the live creature is in its slot (the still goes)
        public float ScrollY;           // (kept: the panel always fits now)
        /// <summary>Frames to draw at instead of the layout's (LayoutAnimation in between two layouts).</summary>
        public Dictionary<string, Frame> FramesOverride;
        public Dictionary<string, float> Fade;   // pieces fading in / out with LayoutAnimation (id -> opacity)
    }

    /// <summary>kit.js useAuthSizes: the screen's sizes for its height (360, 384, 412 dp: small, the test phone, tall).</summary>
    public sealed class AuthSizes
    {
        public float W, H, Top, Head, LogoW, CardW, PadH, PadT, PadB, Gap, Track, Input, Font, Btn, BtnFont, Social;
        public static AuthSizes For(float w, float h)
        {
            float W = Math.Max(w, h), H = Math.Min(w, h);
            int t = H < 376 ? 0 : H < 400 ? 1 : 2;
            float P(float a, float b, float c) => t == 0 ? a : t == 1 ? b : c;
            return new AuthSizes
            {
                W = W, H = H, Top = P(6, 9, 10), Head = P(52, 58, 64), LogoW = P(262, 296, 324), CardW = Math.Min(P(450, 470, 490), W - 28),
                PadH = P(14, 16, 18), PadT = P(10, 12, 14), PadB = P(12, 14, 16), Gap = P(7, 9, 11), Track = P(30, 34, 36), Input = P(36, 40, 42),
                Font = P(14, 15, 15), Btn = P(38, 42, 46), BtnFont = P(17, 19, 20), Social = P(32, 36, 38),
            };
        }
    }

    public sealed class AuthArt
    {
        public const string Display = "Fredoka_700Bold", Black = "Nunito_900Black", Heavy = "Nunito_800ExtraBold";
        public const string INK = "#6b4426", CREAM = "#fff6e2", GOLD_TXT = "#ffd650", ROOT_BG = "#94a280";
        const string PLACEHOLDER = "rgba(255,236,200,0.55)", INSET = "rgba(60,30,10,0.42)", INSET_ON = "rgba(60,30,10,0.55)", RIM = "rgba(255,236,170,0.55)";
        public const string HOUSE = "Auth/house-bg", LOGO = "Auth/logo", MITTENS = "Auth/mittens";
        const float LOGO_RATIO = 981f / 133, TRACK_PAD = 3;
        // (kept for VerifyArt until it's remodelled too: the old candy button's colours)
        public const string GOLD_RING = "#9c4d06";
        public static readonly string[] GOLD = { "#fff7b0", "#ffd23a", "#ff9c0a" };

        public readonly float W, H;
        public readonly AuthSizes Z;
        public AuthArt(float w, float h) { W = w; H = h; Z = AuthSizes.For(w, h); }

        static TextStyle T(string font, float size, string color, float ls = 0, float lh = 0, Shadow[] sh = null) => new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = ls, LineHeight = lh, Shadows = sh };
        static readonly Shadow[] SoftInk = { new Shadow("rgba(80,40,12,0.75)", 0, 1, 0) };
        public static readonly TextStyle LabelStyle = T(Black, 10.5f, CREAM, 1.2f, 13, SoftInk);
        static readonly TextStyle EyeStyle = T(Black, 12, GOLD_TXT);
        static readonly TextStyle TabOn = T(Display, 16, INK);
        static readonly TextStyle TabOff = Kit.Ink(16);
        static readonly TextStyle KeepStyle = Kit.Ink(14);
        static readonly TextStyle OrStyle = T(Black, 10.5f, CREAM, 1.5f);
        static readonly TextStyle ErrStyle = T(Black, 12, "#ffffff", 0, 15);
        static readonly TextStyle SocialStyle = T(Display, 15, INK);
        public static readonly TextStyle BlockedStyle = T(Heavy, 15, CREAM, 0, 21, SoftInk);
        static TextStyle InputStyle(float size) => T(Heavy, size, "#ffffff");
        static TextStyle PlaceholderStyle(float size) => T(Heavy, size, PLACEHOLDER);

        public const string BlockedTitle = "Ask a grown-up!";
        public const string BlockedText = "This game needs a parent or guardian to help set up an account. Ask them to continue!";
        static readonly (string id, string label, string logo)[] Socials = { ("google", "Google", GoogleLogo), ("facebook", "Facebook", FacebookLogo), ("tiktok", "TikTok", TikTokLogo) };

        public static readonly string[] FieldIds = { "nick", "age", "email", "pass" };

        static FlexNode Txt(string name, TextFlow flow) => FlexNode.Leaf(name, flow.Measure);
        static FlexNode Txt(string name, string text, TextStyle st) => Txt(name, new TextFlow(text, st));

        // ---- layout --------------------------------------------------------------------------------------------
        /// <summary>Every node's frame (dp, on screen) for this state (the panel always fits: no scrolling).</summary>
        public Dictionary<string, Frame> Layout(AuthModel m, out float scrollMax)
        {
            scrollMax = 0;
            var z = Z;
            bool reg = m.Register;
            // col: the screen's height, the header along the top, the panel centred under it
            var root = new FlexNode("root").AlignItems(YGAlign.Center).Padding(YGEdge.Top, z.Top).Padding(YGEdge.Bottom, z.Top);
            var header = root.Add(new FlexNode("header").Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(6).Height(z.Head));
            header.Add(new FlexNode("mittens").Size(z.Head, z.Head));
            header.Add(new FlexNode("logo").Size(z.LogoW, z.LogoW / LOGO_RATIO));
            var area = root.Add(new FlexNode("area").Flex(1).AlignSelf(YGAlign.Stretch).AlignItems(YGAlign.Center).Justify(YGJustify.Center));
            var card = area.Add(new FlexNode("card").Width(z.CardW).PadH(z.PadH).Padding(YGEdge.Top, z.PadT).Padding(YGEdge.Bottom, z.PadB).Gap(z.Gap));
            // ModeSwitch
            var track = card.Add(new FlexNode("track").Row().Height(z.Track).Padding(TRACK_PAD).Border(1.5f));
            track.Add(new FlexNode("tab-login").Flex(1).AlignItems(YGAlign.Center).Justify(YGJustify.Center)).Add(Txt("tab-login-t", "Log in", reg ? TabOff : TabOn));
            track.Add(new FlexNode("tab-register").Flex(1).AlignItems(YGAlign.Center).Justify(YGJustify.Center)).Add(Txt("tab-register-t", "Register", reg ? TabOn : TabOff));
            if (m.Blocked)
            {
                var b = card.Add(new FlexNode("blocked").AlignItems(YGAlign.Center).Gap(6).PadV(14).PadH(24));
                var (lw, lh) = Kit.LetteringSize(BlockedTitle, 20);
                b.Add(new FlexNode("blocked-title").Size(lw, lh));
                b.Add(Txt("blocked-t", new TextFlow(BlockedText, BlockedStyle, 0.5f)));
            }
            else
            {
                var row = card.Add(new FlexNode("row-cred").Row().Gap(reg ? 6 : 8));
                if (reg)
                {
                    row.Add(Field("nick", "SQUAD NAME", z)).Flex(0.8f);
                    row.Add(Field("age", "AGE", z)).Width(56);
                }
                var em = row.Add(Field("email", "EMAIL", z)); em.Flex(reg ? 1.1f : 1);
                var pw = row.Add(Field("pass", "PASSWORD", z)); pw.Flex(reg ? 1.05f : 1);
                // the gold button, the panel's width
                var btn = card.Add(new FlexNode("submit-ring").Height(z.Btn).AlignItems(YGAlign.Center).Justify(YGJustify.Center));
                if (m.Submitting) btn.Add(new FlexNode("dots").Row().AlignItems(YGAlign.FlexEnd).Gap(6).Height(20).With(new FlexNode("dot0").Size(10, 10), new FlexNode("dot1").Size(10, 10), new FlexNode("dot2").Size(10, 10)));
                else { var (lw, lh) = Kit.LetteringSize(m.ButtonLabel, z.BtnFont); btn.Add(new FlexNode("label").Size(lw, lh)); }
                var keep = card.Add(new FlexNode("keep").Row().AlignItems(YGAlign.Center).Gap(8).AlignSelf(YGAlign.Center));
                keep.Add(new FlexNode("keep-box").Size(22, 22));
                keep.Add(Txt("keep-t", "Keep me signed in", KeepStyle));
                var or = card.Add(new FlexNode("or").Row().Height(20).AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(10));
                if (!string.IsNullOrEmpty(m.Error))
                {
                    var err = or.Add(new FlexNode("error").PadH(12).PadV(2).Border(1.6f).Justify(YGJustify.Center));
                    Facebook.Yoga.YGNodeStyleAPI.YGNodeStyleSetMinHeight(err.Node, 20);
                    err.Add(Txt("error-t", new TextFlow(m.Error, ErrStyle, 0.5f)));
                }
                else
                {
                    or.Add(new FlexNode("or-l1").Flex(1).Height(1.5f));
                    or.Add(Txt("or-t", "OR", OrStyle));
                    or.Add(new FlexNode("or-l2").Flex(1).Height(1.5f));
                }
                var socials = card.Add(new FlexNode("socials").Row().Gap(12));
                float ls = (float)Math.Round(z.Social * 0.62);
                foreach (var (id, label, _) in Socials)
                {
                    var s = socials.Add(new FlexNode("s-" + id).Flex(1).Height(z.Social).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(8));
                    s.Add(new FlexNode("s-" + id + "-logo").Size(ls, ls));
                    s.Add(Txt("s-" + id + "-t", label, SocialStyle));
                }
            }
            root.Layout(W, H);
            var frames = new Dictionary<string, Frame>();
            root.Walk(n => frames[n.Name] = n.Frame);
            return frames;
        }

        static FlexNode Field(string id, string label, AuthSizes z)
        {
            var f = new FlexNode("f-" + id);
            f.Add(Txt("f-" + id + "-label", label, LabelStyle).Margin(YGEdge.Bottom, 3).Margin(YGEdge.Left, 2));
            f.Add(new FlexNode("f-" + id + "-input").Height(z.Input));
            return f;
        }

        // ---- drawing -------------------------------------------------------------------------------------------
        public static string Value(AuthModel m, string id) => id == "nick" ? m.Nickname : id == "age" ? m.Age : id == "email" ? m.Email : m.Password;
        /// <summary>The fields' hints (to register the password shares its row with three more fields: a shorter one).</summary>
        public static string Placeholder(string id, bool register) => id == "nick" ? "Squishy" : id == "age" ? "13+" : id == "email" ? "you@mail.com" : register ? "6+ chars" : "6+ characters";

        public List<ScreenPiece> Pieces(AuthModel m, AuthUi ui, Dictionary<string, Frame> layout)
        {
            var f = ui.FramesOverride ?? layout;
            var z = Z;
            var list = new List<ScreenPiece>();
            bool Has(string k) => f.ContainsKey(k);
            Frame Fr(string k) => f[k];
            float Fade(string id) => ui.Fade != null && ui.Fade.TryGetValue(id, out var o) ? o : 1;
            ScreenPiece Add(string id, UiSvg svg, Frame at, float opacity = 1, Affine? extra = null, float margin = 6)
            {
                var p = new ScreenPiece { Id = id, Svg = svg.Markup, W = svg.W, H = svg.H, Opacity = opacity * Fade(id), Margin = margin };
                p.Transform = Affine.Translate(Screens.Pieces.Snap(at.X), Screens.Pieces.Snap(at.Y)) * (extra ?? Affine.Identity);
                list.Add(p);
                return p;
            }

            Backdrop(list, W, H);
            Header(list, Fr("mittens"), Fr("logo"), ui.CreatureShown);

            // the panel: Settings' wood plaque (radius 22, rim 3.5, ring 2, lip 4)
            var cf = Fr("card");
            {
                const float ring = 2, lip = 4;
                var s = new UiSvg(cf.W + 2 * ring, cf.H + 2 * ring + lip);
                Kit.Plaque(s, ring, ring, cf.W, cf.H, "vel", 22, 3.5f, ring, lip);
                Add("card", s, new Frame(cf.X - ring, cf.Y - ring, s.W, s.H), 1, null, 2);
            }
            // Log in | Register: the dark inset track, the gold pill (a gold plaque) springing across, the labels
            var trf = Fr("track");
            Add("track", new UiSvg(trf.W, trf.H).Box(0, 0, trf.W, trf.H, new BoxStyle { Radius = 999, Background = INSET, BorderWidth = FlexNode.Bw(1.5f), BorderColor = RIM }), trf);
            {
                float half = (trf.W - 2 * TRACK_PAD) / 2, ph = trf.H - 2 * 1.5f - 2 * 1.5f;
                const float ring = 1.4f, lip = 2.5f;
                var s = new UiSvg(half + 2 * ring, ph + 2 * ring + lip);
                Kit.Plaque(s, ring, ring, half, ph, "gold", 999, 2, ring, lip);
                Add("pill", s, new Frame(trf.X + 1.5f + 1.5f - ring, trf.Y + 1.5f + 1.5f - ring, s.W, s.H), 1, Affine.Translate(ui.PillX * half, 0));
            }
            foreach (var (id, label, isReg) in new[] { ("tab-login", "Log in", false), ("tab-register", "Register", true) })
            {
                var tt = Fr(id + "-t");
                Add(id, new UiSvg(tt.W, tt.H).Text(label, 0, 0, m.Register == isReg ? TabOn : TabOff), tt, 1, Shrink(ui.Pressed == id, tt, tt.X + tt.W / 2, tt.Y + tt.H / 2));
            }

            if (Has("blocked"))
            {
                var bt = Fr("blocked-title");
                var s = new UiSvg(bt.W, bt.H);
                Kit.Lettering(s, BlockedTitle, "gold", 20, 0, 0);
                Add("blocked-title", s, bt);
                var bf = Fr("blocked-t");
                var s2 = new UiSvg(bf.W, bf.H);
                new TextFlow(BlockedText, BlockedStyle, 0.5f).Draw(s2, 0, 0, bf.W);
                Add("blocked", s2, bf);
                return list;
            }

            foreach (var id in FieldIds)
            {
                if (!Has("f-" + id)) continue;
                var lab = Fr("f-" + id + "-label");
                string label = id == "nick" ? "SQUAD NAME" : id == "age" ? "AGE" : id == "email" ? "EMAIL" : "PASSWORD";
                Add("f-" + id + "-label", new UiSvg(lab.W, lab.H).Text(label, 0, 0, LabelStyle), lab);
                var inf = Fr("f-" + id + "-input");
                var (box, caretX) = Input(id, Value(m, id), inf.W, inf.H, z.Font, ui.Focus == id, id == "pass" && !m.ShowPass, id == "pass", m.Register);
                Add("f-" + id + "-input", box, inf);
                if (id == "pass")
                {
                    // Show / Hide inside the input's right end (right 11, centred)
                    string eye = m.ShowPass ? "Hide" : "Show";
                    float ew = UiSvg.BoxWidth(eye, EyeStyle), eh = UiSvg.LineBox(EyeStyle);
                    var ef = new Frame(inf.Right - 11 - ew, inf.Y + (inf.H - eh) / 2, ew, eh);
                    Add("eye", new UiSvg(ew, eh).Text(eye, 0, 0, EyeStyle), ef, 1, Shrink(ui.Pressed == "eye", ef, ef.X + ew / 2, ef.Y + eh / 2));
                    f["eye"] = ef;   // (for the tap)
                }
                if (ui.Focus == id && ui.CaretOn)
                {
                    float lh = UiSvg.LineBox(InputStyle(z.Font));
                    Add("caret", new UiSvg(1.5f, lh).Box(0, 0, 1.5f, lh, new BoxStyle { Background = GOLD_TXT }), new Frame(inf.X + caretX, inf.Y + (inf.H - lh) / 2, 1.5f, lh));
                }
            }

            // the gold button (Btn: a gold plaque, radius 15; it shrinks to 92 % while held, its glint, label and dots with
            // it), its light sweeping across
            var rf = Fr("submit-ring");
            bool held = ui.Pressed == "submit";
            float bcx = rf.X + rf.W / 2, bcy = rf.Y + rf.H / 2 + 1.5f;   // the button's middle (its 3 dp lip in)
            {
                const float ring = 1.6f, lip = 3;
                var s = new UiSvg(rf.W + 2 * ring, rf.H + 2 * ring + lip);
                Kit.Plaque(s, ring, ring, rf.W, rf.H, "gold", 15, 2.5f, ring, lip);
                var bf = new Frame(rf.X - ring, rf.Y - ring, s.W, s.H);
                Add("submit", s, bf, 1, Shrink(held, bf, bcx, bcy), 2);
                if (!m.Submitting) Add("glint", Glint(rf.W, rf.H, ui.GlintMs), rf, 1, Shrink(held, rf, bcx, bcy), 0);
            }
            if (Has("label"))
            {
                var lb = Fr("label");
                var s = new UiSvg(lb.W, lb.H);
                Kit.Lettering(s, m.ButtonLabel, "whiteB", z.BtnFont, 0, 0);
                // useFadeUp: opacity t, translateY 6 -> 0
                double t = ui.LabelT;
                Add("label", s, lb, (float)t, Shrink(held, lb, bcx, bcy) * Affine.Translate(0, 6 * (1 - t)));
            }
            for (int i = 0; i < 3; i++)
            {
                if (!Has("dot" + i)) continue;
                var df = Fr("dot" + i);
                var (svg, tr) = Dot(i, ui.DotsMs, 10);
                Add("dot" + i, svg, df, 1, Shrink(held, df, bcx, bcy) * tr);
            }
            // Keep me signed in: a gold tick box
            var kb = Fr("keep-box");
            var kt = Fr("keep-t");
            bool keepHeld = ui.Pressed == "keep";
            // (the box and its words shrink as one, about their middle)
            float kcx = (kb.X + kt.X + kt.W) / 2, kcy = (Math.Min(kb.Y, kt.Y) + Math.Max(kb.Y + kb.H, kt.Y + kt.H)) / 2;
            Add("keep-box", KeepBox(m.Keep), kb, 1, Shrink(keepHeld, kb, kcx, kcy));
            Add("keep-t", new UiSvg(kt.W, kt.H).Text("Keep me signed in", 0, 0, KeepStyle), kt, 1, Shrink(keepHeld, kt, kcx, kcy));
            // OR, or the error in its place
            if (Has("error"))
            {
                var ef = Fr("error");
                var s = new UiSvg(ef.W, ef.H);
                s.Box(0, 0, ef.W, ef.H, new BoxStyle { Radius = 10, Background = "#d9412c", BorderWidth = FlexNode.Bw(1.6f), BorderColor = "#5a1a08" });
                var et = Fr("error-t");
                new TextFlow(m.Error, ErrStyle, 0.5f).Draw(s, et.X - ef.X, et.Y - ef.Y, et.W);
                Add("error", s, ef);
            }
            else
            {
                foreach (var l in new[] { "or-l1", "or-l2" }) { var lf2 = Fr(l); Add(l, new UiSvg(lf2.W, lf2.H).Box(0, 0, lf2.W, lf2.H, new BoxStyle { Radius = 1, Background = "rgba(255,236,170,0.45)" }), lf2); }
                var ot = Fr("or-t");
                Add("or-t", new UiSvg(ot.W, ot.H).Text("OR", 0, 0, OrStyle), ot);
            }
            // Google / Facebook / TikTok: pearl plaques (radius 14), shrinking to 92 % while held
            foreach (var (id, label, logo) in Socials)
            {
                var sf = Fr("s-" + id);
                const float ring = 1.6f, lip = 3;
                var s = new UiSvg(sf.W + 2 * ring, sf.H + 2 * ring + lip);
                Kit.Plaque(s, ring, ring, sf.W, sf.H, "pearl", 14, 2.5f, ring, lip);
                var lg = Fr("s-" + id + "-logo");
                s.Drawing(logo, lg.X - sf.X + ring, lg.Y - sf.Y + ring, lg.W, lg.H, "0 0 24 24");
                var lt = Fr("s-" + id + "-t");
                s.Text(label, lt.X - sf.X + ring, lt.Y - sf.Y + ring, SocialStyle);
                var at = new Frame(sf.X - ring, sf.Y - ring, s.W, s.H);
                Add("s-" + id, s, at, 1, Shrink(ui.Pressed == id, at, sf.X + sf.W / 2, sf.Y + (sf.H + lip) / 2), 2);
            }
            return list;
        }

        // ---- pieces ---------------------------------------------------------------------------------------------------

        /// <summary>kit.js AuthBg: the house, "cover", over its average colour (the sign-in screens' one full-screen picture).</summary>
        public static void Backdrop(List<ScreenPiece> list, float w, float h)
        {
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Background = ROOT_BG });
            s.Image(HOUSE, 0, 0, w, h, "xMidYMid slice");
            list.Add(new ScreenPiece { Id = "bg", Svg = s.Markup, W = w, H = h, Margin = 0 });
        }

        /// <summary>kit.js AuthHeader: Mittens on a soft floor shadow (the app's still until the live creature is drawn in its
        /// slot), the SQUISH SQUAD logo beside it.</summary>
        public static void Header(List<ScreenPiece> list, Frame mf, Frame lf, bool creatureShown)
        {
            var s = new UiSvg(mf.W, mf.H);
            float hf = mf.H * 0.12f;
            s.Box(mf.W * 0.2f, mf.H - 1 - hf, mf.W * 0.6f, hf, new BoxStyle { Radius = 999, Background = "rgba(40,20,6,0.28)" });
            if (!creatureShown) s.Image(MITTENS, 0, 0, mf.W, mf.H, "xMidYMid meet");
            list.Add(new ScreenPiece { Id = "mittens-still", Svg = s.Markup, W = mf.W, H = mf.H, Margin = 0, Transform = Affine.Translate(Screens.Pieces.Snap(mf.X), Screens.Pieces.Snap(mf.Y)) });
            list.Add(new ScreenPiece { Id = "mittens", Slot = true, W = mf.W, H = mf.H, Transform = Affine.Translate(mf.X, mf.Y) });
            list.Add(new ScreenPiece { Id = "logo", Svg = new UiSvg(lf.W, lf.H).Image(LOGO, 0, 0, lf.W, lf.H).Markup, W = lf.W, H = lf.H, Margin = 0, Transform = Affine.Translate(Screens.Pieces.Snap(lf.X), Screens.Pieces.Snap(lf.Y)) });
        }

        /// <summary>A royal plaque as a piece: its box `at` (the ring and the lip drawn round it).</summary>
        public static UiSvg PlaqueSvg(float w, float h, string variant, float radius, float rim = 2.5f, float ring = 1.6f, float lip = 3)
        {
            var s = new UiSvg(w + 2 * ring, h + 2 * ring + lip);
            Kit.Plaque(s, ring, ring, w, h, variant, radius, rim, ring, lip);
            return s;
        }

        /// <summary>kit.js ErrorPill: white on red (#d9412c, a 1.6 dp dark rim, radius 10, 12 x 2 in).</summary>
        public static void ErrorPill(UiSvg s, float w, float h)
            => s.Box(0, 0, w, h, new BoxStyle { Radius = 10, Background = "#d9412c", BorderWidth = FlexNode.Bw(1.6f), BorderColor = "#5a1a08" });
        public static readonly TextStyle ErrorText = new TextStyle { Font = Black, Size = 12, Color = "#ffffff", LineHeight = 15 };

        /// <summary>Btn's light sweep (see Glint).</summary>
        public static UiSvg GlintSvg(float w, float h, double ms) => Glint(w, h, ms);

        /// <summary>kit.js Field's input: Settings' dark inset (radius 12, 12 dp in, a 1.5 dp rim; while typed in, a 2 dp gold
        /// rim and a darker inset), its text white or its hint, scrolled so its end shows. Returns the caret's x.</summary>
        public static (UiSvg svg, float caretX) Input(string id, string value, float w, float h, float font, bool focus, bool secure, bool eye, bool register)
        {
            var s = new UiSvg(w, h);
            float bw = FlexNode.Bw(focus ? 2 : 1.5f);
            s.Box(0, 0, w, h, new BoxStyle { Radius = 12, Background = focus ? INSET_ON : INSET, BorderWidth = bw, BorderColor = focus ? GOLD_TXT : RIM });
            float x0 = bw + 12, x1 = w - bw - (eye ? 50 : 12);
            string shown = string.IsNullOrEmpty(value) ? Placeholder(id, register) : secure ? new string('•', value.Length) : value;
            var st = string.IsNullOrEmpty(value) ? PlaceholderStyle(font) : InputStyle(font);
            float tw = UiSvg.Width(shown, st);
            // (scrolled so its end shows while it's typed in; at rest a TextInput shows its start)
            float scroll = string.IsNullOrEmpty(value) || !focus ? 0 : Math.Max(0, tw + 1.5f - (x1 - x0));
            float lh = UiSvg.LineBox(st);
            var clip = s.NewId("ic");
            s.Def($"<clipPath id=\"{clip}\"><rect x=\"{UiSvg.F(x0)}\" y=\"{UiSvg.F(bw)}\" width=\"{UiSvg.F(Math.Max(0, x1 - x0))}\" height=\"{UiSvg.F(h - 2 * bw)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"").Text(shown, x0 - scroll, (h - lh) / 2, st).Close();
            float caret = string.IsNullOrEmpty(value) ? x0 : x0 + tw - scroll;
            return (s, caret);
        }

        static UiSvg KeepBox(bool on)
        {
            var s = new UiSvg(22, 22);
            if (on)
            {
                s.Box(0, 0, 22, 22, new BoxStyle { Radius = 7, Gradient = new[] { "#fff1b0", "#ffd650", "#f6a524" }, GradientStops = new[] { 0f, 0.45f, 1 }, BorderWidth = FlexNode.Bw(1.6f), BorderColor = INK });
                Kit.Icon(s, "M5 12.5l4.5 4.5L19 7.5", 3.5f, 3.5f, 15, INK, 3.6f, false);
            }
            else s.Box(0, 0, 22, 22, new BoxStyle { Radius = 7, Background = INSET, BorderWidth = FlexNode.Bw(1.6f), BorderColor = "rgba(255,236,170,0.7)" });
            return s;
        }

        // royal/parts.js Glint: a soft white band (26 % of the button's width, skewed -18°) sweeping across between 1.9 and
        // 2.9 s of a 3.4 s loop (ease-in-out in 8 steps), clipped to the button (radius 18)
        const double GLINT_MS = 3400, GLINT_A = 1900 / GLINT_MS, GLINT_B = 2900 / GLINT_MS;
        static readonly double[] GLINT_AT, GLINT_K;
        static AuthArt()
        {
            GLINT_AT = new double[11]; GLINT_K = new double[11];
            GLINT_AT[0] = 0; GLINT_K[0] = 0; GLINT_AT[10] = 1; GLINT_K[10] = 1;
            for (int i = 0; i <= 8; i++)
            {
                double s = i / 8.0;
                GLINT_AT[i + 1] = GLINT_A + (GLINT_B - GLINT_A) * s;
                GLINT_K[i + 1] = s < 0.5 ? 2 * s * s : 1 - 2 * (1 - s) * (1 - s);
            }
        }
        static UiSvg Glint(float w, float h, double ms)
        {
            double p = (ms % GLINT_MS) / GLINT_MS, k = Interp(p, GLINT_AT, GLINT_K);
            float x = (float)(-w * 0.5 + w * 1.8 * k), bw = w * 0.26f;
            var s = new UiSvg(w, h);
            var clip = s.NewId("gc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(0, 0, w, h, new[] { 18f, 18, 18, 18 })}\"/></clipPath>");
            var g = s.NewId("gg");
            s.Def($"<linearGradient id=\"{g}\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>");
            // skewX(-18°) about the band's centre (RN's default origin), the band 10 dp past the top and bottom
            float cx = x + bw / 2, cy = h / 2;
            s.Raw($"<g clip-path=\"url(#{clip})\"><rect x=\"{UiSvg.F(x)}\" y=\"-10\" width=\"{UiSvg.F(bw)}\" height=\"{UiSvg.F(h + 20)}\" fill=\"url(#{g})\" transform=\"translate({UiSvg.F(cx)} {UiSvg.F(cy)}) skewX(-18) translate({UiSvg.F(-cx)} {UiSvg.F(-cy)})\"/></g>");
            return s;
        }

        static double Interp(double p, double[] xs, double[] ys)
        {
            for (int i = 0; i < xs.Length - 1; i++) if (p <= xs[i + 1]) return xs[i + 1] == xs[i] ? ys[i + 1] : ys[i] + (ys[i + 1] - ys[i]) * (p - xs[i]) / (xs[i + 1] - xs[i]);
            return ys[ys.Length - 1];
        }

        /// <summary>kit.js Dots: three white dots (a 1.6 dp brown rim) hopping in turn (a 900 ms loop; dot i lifts 0.7 of its
        /// size over [0.18 i, 0.18 i + 0.32] of it).</summary>
        public static (UiSvg svg, Affine tr) Dot(int i, double ms, float size)
        {
            double p = (ms % 900) / 900, st = i * 0.18;
            double ty = Interp(p, new[] { 0, st, st + 0.16, st + 0.32, 1 }, new[] { 0.0, 0, -size * 0.7, 0, 0 });
            var s = new UiSvg(size, size);
            s.Box(0, 0, size, size, new BoxStyle { Radius = size / 2, Background = "#ffffff", BorderWidth = FlexNode.Bw(1.6f), BorderColor = "#6a2c00" });
            return (s, Affine.Translate(0, ty));
        }

        // (the old candy pieces VerifyArt still draws until it's remodelled)
        public static TextStyle BtnStyle(float size, string ring) => new TextStyle
        {
            Font = Display, Size = size, Color = "#ffffff",
            Shadows = new[] { new Shadow(ring, 0, 2, 0), new Shadow(ring, 1, 0, 0), new Shadow(ring, -1, 0, 0) },
        };

        // ---- taps ----------------------------------------------------------------------------------------------------
        // a held button (the gold one, the socials, and the smaller taps: the tabs, Show / Hide, Keep me signed in) shrinks
        // to 92 % about its middle (cx, cy: screen dp), as the menu's Level crest does: the extra transform for one of its
        // pieces drawn at `at` (Add puts a piece at its frame's snapped top-left)
        const double PRESS = 0.92;
        static Affine Shrink(bool held, Frame at, float cx, float cy)
        {
            if (!held) return Affine.Identity;
            double lx = cx - Screens.Pieces.Snap(at.X), ly = cy - Screens.Pieces.Snap(at.Y);
            return Affine.Translate(lx, ly) * Affine.ScaleBy(PRESS, PRESS) * Affine.Translate(-lx, -ly);
        }

        /// <summary>What a tap at (x, y) dp hits: a tab, a field, the eye, the button, the box, a social button.</summary>
        public string HitTest(Dictionary<string, Frame> f, AuthUi ui, float x, float y)
        {
            bool In(string k, float slop = 0) => f.TryGetValue(k, out var r) && r.Inset(slop).Contains(x, y);
            if (f.ContainsKey("eye") && f["eye"].Inset(8).Contains(x, y)) return "eye";
            foreach (var id in FieldIds) if (In("f-" + id + "-input")) return id;
            if (In("tab-login")) return "tab-login";
            if (In("tab-register")) return "tab-register";
            if (In("submit-ring")) return "submit";
            if (In("keep", 6)) return "keep";
            foreach (var (id, _, _) in Socials) if (In("s-" + id)) return id;
            return null;
        }

        // ---- the app's own drawings (auth/Socials.js) --------------------------------------------------------------
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
