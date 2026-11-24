// src/screens/StreakScreen.js, landscape (REDESIGN_V7 step 4, V8: all on one screen), as pure C#: on the left the title,
// the flame with the streak on it, the squishy's line and the coin bonus, today's card and the buttons; on the right
// all ten days' prizes, five to a row. The rules: Progression (src/progression.js).
//   intro      once a day after the Daily Spin (App.js): no back orb; LET'S GO! opens the daily challenges, Later goes
//              home (CONTINUE once today's chest is open)
//   otherwise  from the menu: the back orb; DAILY CHALLENGES
// Motion: the flame flickers from its base, the button breathes, today's tile pulses, the tiles pop in one after
// another as the screen opens, the jackpot tile's shine sweeps across.
// Not ported: the sounds. The squishy (`mascot`) isn't on the landscape screen; its name is in the line.
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
    public sealed class StreakView : IScreenView
    {
        public readonly float W, H;
        public readonly bool Intro;
        public Action OnClose, OnOpenDaily;
        public DailyInfo V { get; private set; }

        readonly Ticker _t;
        readonly Func<DateTime> _now;
        readonly IDictionary<string, object> _profile;
        readonly string _mascotName;
        readonly AnimatedValue _enter = new AnimatedValue(0), _fire = new AnimatedValue(0), _pulse = new AnimatedValue(0), _tilePulse = new AnimatedValue(0), _shine = new AnimatedValue(0);
        double _clockAt = double.NaN;

        public StreakView(IDictionary<string, object> profile, string mascotName, bool intro, float w, float h, Ticker ticker, Func<DateTime> now)
        {
            _t = ticker; _now = now; _profile = profile; _mascotName = mascotName; Intro = intro;
            Audio.Snd.Play(intro ? "sparkle" : "popOpen");
            W = w; H = h;
            Refresh();
            Motion.Timing(_enter, 1, 1400, Motion.OutQuad).Start();
            Motion.PingPong(_fire, 520, null, 640).Start();
            if (!V.ChestDone) Motion.PingPong(_pulse, 800).Start();
            Motion.PingPong(_tilePulse, 800).Start();
            Animated.Loop(Motion.Timing(_shine, 1, 2600, Easing.Bezier(0.42, 0, 0.58, 1))).Start();
        }

        /// <summary>The clock is read again every 30 s (the time left today).</summary>
        void Refresh() { V = Progression.View(_profile, _now()); _clockAt = _t.Now; _layout = null; }

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
            if (h == "back") OnClose?.Invoke();
            else if (h == "main") { if (!V.ChestDone) OnOpenDaily?.Invoke(); else OnClose?.Invoke(); }
            else if (h == "later") OnClose?.Invoke();
        }

        string Hit(float x, float y)
        {
            var f = Layout();
            bool In(string k, float slop) => f.TryGetValue(k, out var r) && x >= r.X - slop && x < r.Right + slop && y >= r.Y - slop && y < r.Bottom + slop;
            if (!Intro && In("orb", 8)) return "back";
            if (In("btn", 0)) return "main";
            if (In("later", 10)) return "later";
            return null;
        }

        // ---- layout (the StyleSheet's numbers, laid out by Yoga) ---------------------------------------------------------
        const string CARD_RING = "#b8641c", INK_C = "#5b3418", INK_SOFT = "#7a4a24";
        static readonly TextStyle BubbleText = T(Black, 11.5f, INK_C, 0, 15);
        static readonly TextStyle BonusText = T(Black, 12, "#a04a00");
        static readonly TextStyle PillText = T(Kit.Display, 12, "#ffffff", 0.6f);
        static readonly TextStyle ClockText = T(Black, 11, INK_SOFT), ClockHot = T(Black, 11, "#d9312a");
        static readonly TextStyle TodayText = T(Heavy, 12.5f, INK_SOFT, 0, 17), TodayStrong = T(Black, 12.5f, INK_C, 0, 17);
        static readonly TextStyle ProgText = T(Kit.Display, 13, INK_C);
        static readonly TextStyle FireLabel = Halo(13, 1);
        static readonly TextStyle LaterText = Halo(13, 0, Heavy);
        static readonly TextStyle SectionTitle = Halo(15, 1), SectionNote = Halo(11, 0, Heavy);
        static readonly TextStyle TileDay = T(Kit.Display, 11, "#000", 0.8f), TileCaption = T(Kit.Display, 12, "#000"), JackCaption = T(Kit.Display, 14, "#ffffff", 0, 0, Outline3("#8a3a0e", 2));
        static readonly TextStyle TagText = T(Kit.Display, 10, "#ffffff", 0.8f), CheckText = T(Black, 12, "#ffffff");

        int BonusPct(int streak) => (int)Prof.JsRound(Progression.STREAK_BONUS * Math.Min(Progression.STREAK_DAYS, streak) * 100);
        string Line => V.ChestDone ? $"Day {V.Streak} done! See you tomorrow!" : V.Streak > 0 ? $"{V.Streak} {(V.Streak == 1 ? "day" : "days")} in a row! Don’t let the fire go out!" : $"{_mascotName ?? "Your squishy"} wants to light the fire. Open today’s chest!";
        string Bonus => V.Streak > 0 ? $"+{BonusPct(V.Streak)}% squish coins today" : $"+{BonusPct(1)}% squish coins a streak day";
        StreakDay TodayDay => V.Track.FirstOrDefault(d => d.Today) ?? V.Track[0];
        string PillLabel => V.ChestDone ? $"DAY {TodayDay.N} DONE ✓" : $"TODAY · DAY {TodayDay.N}";
        string ClockLabel => $" {V.ResetIn} left";   // after the ⏱ (Chrome's emoji)

        TextFlow TodayFlow(float w)
        {
            if (V.ChestDone)
                return new TextFlow(TodayText, 0, new Run($"Today’s chest is open. Come back tomorrow for day {TodayDay.N + 1}: ", TodayText), new Run(Progression.StreakRewardText(Progression.StreakRewardOf(TodayDay.N + 1)), TodayStrong), new Run("!", TodayText));
            return new TextFlow(TodayText, 0, new Run("Claim all ", TodayText), new Run($"{V.Total} daily challenges", TodayStrong),
                new Run(V.Streak > 0 ? $" before midnight to open the chest and keep your {V.Streak}-day streak." : " to open the chest and light your streak.", TodayText));
        }

        CandyButton MainButton => !V.ChestDone ? new CandyButton(Intro ? "LET’S GO!" : "DAILY CHALLENGES", "gold", "md") : Intro ? new CandyButton("CONTINUE", "blue", "md") : null;

        Dictionary<string, Frame> _layout;
        float _gridW, _tileW;

        /// <summary>Every box of the layout (dp), for checking it against the app's.</summary>
        public Dictionary<string, Frame> Frames => Layout();

        Dictionary<string, Frame> Layout()
        {
            if (_layout != null) return _layout;
            var root = new FlexNode("root").Row().PadH(16).Gap(18);
            var left = root.Add(new FlexNode("left").WidthPct(40).Padding(YGEdge.Top, 10).Padding(YGEdge.Bottom, 10).Gap(8));
            var head = left.Add(new FlexNode("head").Row().AlignItems(YGAlign.Center).Gap(10));
            if (!Intro) head.Add(FlexX.Box("orb", 40, 40));
            var (lw, lh) = LetteringSize("Daily Streak", 26);
            head.Add(FlexX.Box("title", lw, lh));
            var hero = left.Add(new FlexNode("hero").Row().AlignItems(YGAlign.Center).Gap(10));
            var fireCol = hero.Add(new FlexNode("fireCol").AlignItems(YGAlign.Center));
            fireCol.Add(FlexX.Box("fire", 84, 84 * 1.15f));
            fireCol.Add(FlexX.Txt("fireLabel", "DAY STREAK", FireLabel).Margin(YGEdge.Top, 2));
            var side = hero.Add(new FlexNode("side").Flex(1).Gap(8).AlignItems(YGAlign.FlexStart));
            var bubble = side.Add(new FlexNode("bubble").AlignSelf(YGAlign.Stretch).Border(2.5f).PadH(10).PadV(7));
            bubble.Add(FlexX.Para("bubbleText", new TextFlow(Line, BubbleText, 0.5f)));
            var pill = side.Add(new FlexNode("bonus").Row().AlignItems(YGAlign.Center).Gap(6).AlignSelf(YGAlign.Stretch)
                .Padding(YGEdge.Left, 9).Padding(YGEdge.Right, 13).PadV(5).Border(2.5f));
            pill.Add(FlexX.Box("flame", 13, 13 * 16f / 14));
            pill.Add(FlexX.Para("bonusText", new TextFlow(Bonus, BonusText)).Shrink(1));
            var ring = left.Add(new FlexNode("cardRing").Padding(2.5f));
            var card = ring.Add(new FlexNode("card").Border(3).PadH(14).PadV(12).Gap(8));
            var th = card.Add(new FlexNode("todayHead").Row().AlignItems(YGAlign.Center).Justify(YGJustify.SpaceBetween).Gap(8));
            th.Add(new FlexNode("todayPill").PadH(11).PadV(4).Border(2)).Add(FlexX.Txt("todayPillText", PillLabel, PillText));
            if (!V.ChestDone)
            {
                var em = Emoji.Of("timer-11");
                var ct = V.Streak > 0 ? ClockHot : ClockText;
                th.Add(new FlexNode("clock").PadH(9).PadV(3)).Add(FlexNode.Leaf("clockText", _ => (em.Adv + W(ClockLabel, ct), Math.Max(LH(ct), em.H))));
            }
            card.Add(FlexNode.Leaf("todayText", a => TodayFlow(a).Measure(a)));
            if (!V.ChestDone)
            {
                var pr = card.Add(new FlexNode("progRow").Row().AlignItems(YGAlign.Center).Gap(8));
                pr.Add(new FlexNode("prog").Flex(1).Height(11 + 4));
                pr.Add(FlexX.Txt("progText", $"{V.ClaimedN}/{V.Total}", ProgText).MinW(30));
            }
            var foot = left.Add(new FlexNode("foot").Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(14).MarginAuto(YGEdge.Top));
            var b = MainButton;
            if (b != null) foot.Add(FlexX.Box("btn", b.FaceW, b.H));
            if (Intro && !V.ChestDone) foot.Add(new FlexNode("later").PadV(4).PadH(18)).Add(FlexX.Txt("laterText", "Later", LaterText));
            if (b == null && !(Intro && !V.ChestDone)) foot.Height(0);
            var right = root.Add(new FlexNode("right").Flex(1).Justify(YGJustify.Center).Gap(6));
            var sh = right.Add(new FlexNode("sectionHead").AlignItems(YGAlign.Center).Gap(2).Margin(YGEdge.Top, 4));
            sh.Add(FlexX.Txt("sectionTitle", "THE DAILY PRIZES", SectionTitle));
            sh.Add(FlexX.Txt("sectionNote", $"Every chest: {Prof.JsStr(Progression.CHEST_COINS)} coins + 1 token + the day’s prize", SectionNote));
            var grid = right.Add(new FlexNode("grid").Row().Wrap().RowGap(16).ColGap(8).Padding(YGEdge.Top, 6));
            for (int i = 0; i < Progression.STREAK_DAYS; i++) grid.Add(new FlexNode("tile" + i).WidthPct(18.6f).MinH(TileHOf(i)));
            root.Layout(W, H);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            _gridW = f["grid"].W;
            _tileW = f["tile0"].W;
            return _layout = f;
        }

        // the tile's height: ring 2.5 + border + paddings + DAY n, the art (36), the caption, gaps of 3
        float TileHOf(int i) => i == Progression.STREAK_DAYS - 1 ? TileH - LH(TileCaption) + LH(JackCaption) : TileH + (V.Track[i].Today ? 2 : 0);
        static float TileH => 2 * 2.5f + 2 * Bw(2.5f) + 6 + 7 + LH(TileDay) + 3 + 36 + 3 + LH(TileCaption);

        // ---- the pieces --------------------------------------------------------------------------------------------------
        public List<ScreenPiece> Pieces()
        {
            if (_t.Now - _clockAt >= 30000) Refresh();
            var f = Layout();
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", PageBg(W, H), W, H, 0, 0, 1, null, 0));
            if (!Intro) list.Add(Piece("orb", Xml("orb-back"), 40, 40, f["orb"].X, f["orb"].Y, 1, Shrink(_pressed == "back", 40, 40)));
            {
                var tf = f["title"];
                var s = new UiSvg(tf.W, tf.H);
                Lettering(s, "Daily Streak", "gold", 26, 0, 0);
                list.Add(Piece("title", s, tf.X, tf.Y));
            }
            Fire(list, f);
            Hero(list, f);
            Today(list, f);
            Foot(list, f);
            Prizes(list, f);
            return list;
        }

        void Fire(List<ScreenPiece> list, Dictionary<string, Frame> f)
        {
            var ff = f["fire"];
            bool cold = V.Streak == 0;
            float w = ff.W, h = ff.H;
            double t = _fire.GetValue();
            // [translateY h/2, rotate, scaleX, scaleY, translateY -h/2] about the centre: a flicker from its base
            var m = About(w, h, Affine.Translate(0, h / 2) * Affine.Rotate(-1.5 + 3 * t) * Affine.ScaleBy(1 - 0.03 * t, 1 + 0.06 * t) * Affine.Translate(0, -h / 2));
            var s = new UiSvg(w, h);
            s.Drawing(BigFlame(cold), 0, 0, w, h, "0 0 105 121");
            list.Add(Piece("fire", s, ff.X, ff.Y, 1, m));
            // the number on it: bottom 10 %, centred (34 dp: the flame is under 110 wide)
            float size = V.Streak >= 100 ? 26 : 34;
            var nt = T(Kit.Display, size, "#ffffff", 0, 0, Outline3(cold ? "#1d4f9a" : "#8a1d0c", 3));
            string n = V.Streak.ToString();
            float nw = W(n, nt), nh = LH(nt);
            list.Add(Piece("fireNumber", TextBox(n, nt), ff.X + (w - nw) / 2, ff.Bottom - h * 0.1f - nh));
            var lf = f["fireLabel"];
            list.Add(Piece("fireLabel", TextBox("DAY STREAK", FireLabel), lf.X, lf.Y));
        }

        static string BigFlame(bool cold)
        {
            var body = cold ? new[] { "#e0f2ff", "#8cc8ff", "#4f8fd6" } : new[] { "#ffc35a", "#ff7a3a", "#e5352a" };
            var heart = cold ? new[] { "#ffffff", "#d6ecff" } : new[] { "#fffbd0", "#ffd23a" };
            return $"<defs><linearGradient id=\"bfBody\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"{body[0]}\"/><stop offset=\"0.5\" stop-color=\"{body[1]}\"/><stop offset=\"1\" stop-color=\"{body[2]}\"/></linearGradient>"
                + $"<linearGradient id=\"bfHeart\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"{heart[0]}\"/><stop offset=\"1\" stop-color=\"{heart[1]}\"/></linearGradient></defs>"
                + $"<path d=\"M52 6 C67 36 97 46 91 82 C87 105 68 115 52 115 C30 115 14 99 14 76 C14 53 36 45 37 22 C45 30 51 37 52 6Z\" fill=\"url(#bfBody)\" stroke=\"{(cold ? "#1d4f9a" : "#7a2310")}\" stroke-width=\"5\" stroke-linejoin=\"round\"/>"
                + "<path d=\"M52 58 C61 74 72 79 68 95 C65 106 58 110 52 110 C42 110 36 102 36 92 C36 81 48 75 52 58Z\" fill=\"url(#bfHeart)\"/>"
                + "<path d=\"M33 50 C27 60 26 70 29 78\" stroke=\"#ffffff\" stroke-opacity=\"0.65\" stroke-width=\"6\" stroke-linecap=\"round\" fill=\"none\"/>";
        }

        const string FLAME = "<path d=\"M7 1 C9 5 13 6 12 11 C11.5 14 9 15 7 15 C4 15 2 13 2 10 C2 7 5 6 5 3 C6 4 7 5 7 1Z\" fill=\"#f2665a\" stroke=\"#5b3a29\" stroke-width=\"1.2\"/>"
            + "<path d=\"M7 8 C8 10 9.5 10.5 9 12.5 C8.6 14 7.6 14.4 7 14.4 C5.8 14.4 5 13.4 5 12.2 C5 10.8 6.4 10.2 7 8Z\" fill=\"#ffd66b\"/>";

        void Hero(List<ScreenPiece> list, Dictionary<string, Frame> f)
        {
            var bf = f["bubble"];
            var s = new UiSvg(bf.W, bf.H);
            s.Box(0, 0, bf.W, bf.H, new BoxStyle { Radius = 16, Background = "#ffffff", BorderWidth = Bw(2.5f), BorderColor = CARD_RING });
            var bt = f["bubbleText"];
            new TextFlow(Line, BubbleText, 0.5f).Draw(s, bt.X - bf.X, bt.Y - bf.Y, bt.W);
            list.Add(Piece("bubble", s, bf.X, bf.Y));
            var pf = f["bonus"];
            var p = new UiSvg(pf.W, pf.H);
            p.Box(0, 0, pf.W, pf.H, new BoxStyle { Radius = 999, Background = "#fff6d6", BorderWidth = Bw(2.5f), BorderColor = "#a04a00" });
            var fl = f["flame"];
            p.Drawing(FLAME, fl.X - pf.X, fl.Y - pf.Y, fl.W, fl.H, "0 0 14 16");
            var tf = f["bonusText"];
            new TextFlow(Bonus, BonusText).Draw(p, tf.X - pf.X, tf.Y - pf.Y, tf.W);
            list.Add(Piece("bonus", p, pf.X, pf.Y));
        }

        void Today(List<ScreenPiece> list, Dictionary<string, Frame> f)
        {
            var rf = f["cardRing"];
            var s = new UiSvg(rf.W, rf.H);
            s.Box(0, 0, rf.W, rf.H, new BoxStyle { Radius = 24, Background = CARD_RING });
            var cf = f["card"];
            float ox = rf.X, oy = rf.Y;
            s.Box(cf.X - ox, cf.Y - oy, cf.W, cf.H, new BoxStyle { Radius = 22, Background = "#fffaf0", BorderWidth = Bw(3), BorderColor = "#ffffff" });
            var pf = f["todayPill"];
            s.Box(pf.X - ox, pf.Y - oy, pf.W, pf.H, new BoxStyle { Radius = 999, Background = V.ChestDone ? "#26a94e" : "#e8681c", BorderWidth = 2, BorderColor = "#ffffff" });
            var pt = f["todayPillText"];
            s.Text(PillLabel, pt.X - ox, pt.Y - oy, PillText);
            if (f.TryGetValue("clock", out var kf) && !V.ChestDone)
            {
                s.Box(kf.X - ox, kf.Y - oy, kf.W, kf.H, new BoxStyle { Radius = 999, Background = V.Streak > 0 ? "#ffe1dc" : "#f6ead8" });
                var kt = f["clockText"];
                var em = Emoji.Of("timer-11");
                var ct = V.Streak > 0 ? ClockHot : ClockText;
                float lh = LH(ct);
                s.Image("Screens/emoji/timer-11", kt.X - ox, kt.Y - oy + (kt.H - em.H) / 2, em.W, em.H, "none");
                s.Text(ClockLabel, kt.X - ox + em.Adv, kt.Y - oy + (kt.H - lh) / 2, ct);
            }
            var tt = f["todayText"];
            TodayFlow(tt.W).Draw(s, tt.X - ox, tt.Y - oy, tt.W);
            if (f.TryGetValue("prog", out var gf) && !V.ChestDone)
            {
                Progress(s, gf.X - ox, gf.Y - oy, gf.W, (float)V.ClaimedN / V.Total * 100, 11, CARD_RING, new[] { "#fff3a0", "#ffc233" });
                var tx = f["progText"];
                string label = $"{V.ClaimedN}/{V.Total}";
                s.Text(label, tx.X - ox, tx.Y - oy, ProgText, tx.W, 1);
            }
            list.Add(Piece("today", s, rf.X, rf.Y));
        }

        void Foot(List<ScreenPiece> list, Dictionary<string, Frame> f)
        {
            var b = MainButton;
            if (b != null)
            {
                var bf = f["btn"];
                double p = V.ChestDone ? 0 : _pulse.GetValue();
                var pulse = About(bf.W, bf.H, Affine.ScaleBy(1 + 0.05 * p, 1 + 0.05 * p));
                // pressed: the whole button (its lip, face and caption) shrinks to 92 % about its middle, as the menu's
                // Level crest does
                var press = Shrink(_pressed == "main", b.FaceW, b.H);
                list.Add(Piece("btn-lip", b.LipSvg(), b.FaceW, b.H, bf.X, bf.Y, 1, pulse * press));
                list.Add(Piece("btn-face", b.FaceSvg(), b.FaceW, b.FaceH, bf.X, bf.Y, 1, pulse * press, 16));
            }
            if (f.TryGetValue("laterText", out var lt) && Intro && !V.ChestDone)
            {
                var ls = TextBox("Later", LaterText);
                list.Add(Piece("later", ls, lt.X, lt.Y, _pressed == "later" ? 0.6f : 1, Shrink(_pressed == "later", ls.W, ls.H)));
            }
        }

        /// <summary>A held button shrinks to 92 % about the middle of its w x h box, as the menu's Level crest does.</summary>
        static Affine Shrink(bool held, float w, float h) => held ? About(w, h, Affine.ScaleBy(0.92, 0.92)) : Affine.Identity;

        static readonly Dictionary<string, (string[] colors, string ring, string text)> LOOK = new Dictionary<string, (string[], string, string)>
        {
            ["done"] = (new[] { "#fffbd6", "#ffe045", "#ffad1f" }, "#a04a00", "#7a3d00"),
            ["today"] = (new[] { "#ffffff", "#ffe9d1", "#ffc690" }, "#e8681c", "#a04a00"),
            ["next"] = (new[] { "#ffffff", "#fff7ea", "#f6e2c4" }, "#b8865a", INK_C),
        };

        void Prizes(List<ScreenPiece> list, Dictionary<string, Frame> f)
        {
            var st = f["sectionTitle"]; list.Add(Piece("sectionTitle", TextBox("THE DAILY PRIZES", SectionTitle), st.X, st.Y));
            var sn = f["sectionNote"]; list.Add(Piece("sectionNote", TextBox($"Every chest: {Prof.JsStr(Progression.CHEST_COINS)} coins + 1 token + the day’s prize", SectionNote), sn.X, sn.Y));
            double enter = _enter.GetValue();
            for (int i = 0; i < Progression.STREAK_DAYS; i++)
            {
                var day = V.Track[i];
                var tf = f["tile" + i];
                double a = 0.05 + i * 0.06;
                float op = (float)Motion.Lerp(enter, new[] { a, a + 0.25 }, new[] { 0.0, 1 });
                double sc = Motion.Lerp(enter, new[] { a, a + 0.25, a + 0.4 }, new[] { 0.6, 1.06, 1 });
                var slot = About(tf.W, tf.H, Affine.ScaleBy(sc, sc));
                bool jack = i == Progression.STREAK_DAYS - 1;
                // (the row is as tall as its tallest tile: today's has a wider ring; each tile is its own height at the top)
                float th0 = TileHOf(i);
                var tile = jack ? JackTile(day, tf.W, th0) : DayTile(day, tf.W, th0);
                var pulse = day.Today && !jack ? About(tf.W, th0, Affine.ScaleBy(1 + 0.05 * _tilePulse.GetValue(), 1 + 0.05 * _tilePulse.GetValue())) : Affine.Identity;
                list.Add(Piece("tile" + i, tile, tf.W, th0, tf.X, tf.Y, op, slot * pulse, day.Today ? 16 : 6));
                if (jack)
                {
                    // ShineSweep: a soft white streak (40 % of the face's width) from -70 % to 140 % in the first 55 % of each
                    // 2.6 s, nothing clipping it
                    float fw = tf.W - 5 - 2 * Bw(2.5f), fh = TileH - 5 - 2 * Bw(2.5f);
                    double x = Motion.Lerp(_shine.GetValue(), new[] { 0, 0.55, 1 }, new[] { -0.7 * fw, 1.4 * fw, 1.4 * fw });
                    float inset = 2.5f + Bw(2.5f);
                    list.Add(new ScreenPiece { Id = "shine", Svg = ShineSvg(fw * 0.4f, fh), W = fw * 0.4f, H = fh, Margin = 0, Opacity = op * (day.Done ? 0.75f : 1), Transform = Affine.Translate(tf.X, tf.Y) * slot * Affine.Translate(inset + x, inset) });
                }
                if (day.Today)
                {
                    float tw = W("TODAY", TagText) + 16 + 4, th = LH(TagText) + 4 + 4;
                    var s = new UiSvg(tw, th);
                    s.Box(0, 0, tw, th, new BoxStyle { Radius = 999, Background = "#e8681c", BorderWidth = 2, BorderColor = "#ffffff" });
                    s.Text("TODAY", 10, 4, TagText);
                    list.Add(new ScreenPiece { Id = "tag", Svg = s.Markup, W = tw, H = th, Opacity = op, Transform = Affine.Translate(tf.X, tf.Y) * slot * Affine.Translate((tf.W - tw) / 2, -9) });
                }
            }
        }

        string ShineSvg(float w, float h)
        {
            var s = new UiSvg(w, h);
            double ang = 90 + Math.Atan2(0.2 * h, w) * 180 / Math.PI;
            s.Box(0, 0, w, h, new BoxStyle { Gradient = new[] { "rgba(255,255,255,0)", "rgba(255,255,255,0.6)", "rgba(255,255,255,0)" }, GradientAngle = (float)ang });
            return s.Markup;
        }

        static string RewardCaption(StreakReward r) => r.Kind == "coins" ? Prof.JsStr(r.Amount) : r.Kind == "gems" ? $"+{Prof.JsStr(r.Amount)} GEMS" : r.Kind == "chest" ? "FREE CHEST" : "50% OFF";

        // the tile: ring (2.5 padding, 3.5 today, with its orange glow), the gradient face in a white border, DAY n, the
        // prize's picture, its caption, ✓ when done
        string DayTile(StreakDay day, float w, float h)
        {
            var look = LOOK[day.Done ? "done" : day.Today ? "today" : "next"];
            var s = new UiSvg(w, h);
            float pad = day.Today ? 3.5f : 2.5f;
            s.Box(0, 0, w, h, new BoxStyle { Radius = 20, Background = look.ring, Shadows = day.Today ? new[] { new Shadow("rgba(255,138,61,0.8)", 0, 0, 12) } : null });
            float bw = Bw(2.5f);
            float fx = pad, fy = pad, fw = w - 2 * pad, fh = h - 2 * pad;
            s.Box(fx, fy, fw, fh, new BoxStyle { Radius = 18, Background = "#ffffff" });
            s.Box(fx + bw, fy + bw, fw - 2 * bw, fh - 2 * bw, new BoxStyle { Radius = 18 - bw, Gradient = look.colors, GradientStops = new[] { 0f, 0.5f, 1 } });
            TileContent(s, day, fx + bw, fy + bw, fw - 2 * bw, look.text, false);
            return s.Markup;
        }

        string JackTile(StreakDay day, float w, float h)
        {
            var s = new UiSvg(w, h);
            if (day.Done) s.Open("opacity=\"0.75\"");
            float pad = 2.5f, bw = Bw(2.5f);
            s.Box(0, 0, w, h, new BoxStyle { Radius = 20, Background = "#8a3a0e" });
            float fx = pad, fy = pad, fw = w - 2 * pad, fh = h - 2 * pad;
            s.Box(fx, fy, fw, fh, new BoxStyle { Radius = 18, Background = "#ffffff" });
            s.Box(fx + bw, fy + bw, fw - 2 * bw, fh - 2 * bw, new BoxStyle { Radius = 18 - bw, Gradient = new[] { "#ffe9b8", "#ffb347", "#e8681c" }, GradientStops = new[] { 0f, 0.5f, 1 } });
            TileContent(s, day, fx + bw, fy + bw, fw - 2 * bw, "#7a2310", true);
            if (day.Done) s.Close();
            return s.Markup;
        }

        void TileContent(UiSvg s, StreakDay day, float x, float y, float w, string ink, bool jack)
        {
            float cy = y + 6;
            var dt = T(Kit.Display, 11, ink, 0.8f);
            s.Text($"DAY {day.N}", x, cy, dt, w, 0.5f);
            cy += LH(dt) + 3;
            float cx = x + w / 2, artY = cy + 18;
            if (jack)
            {
                float bx = cx - 17, by = artY - 17, b = Bw(2.5f);
                s.Box(bx, by, 34, 34, new BoxStyle { Radius = 17, Background = "#ff8a3d", BorderWidth = b, BorderColor = "#ffffff" });
                s.Box(cx - 8, artY - 2.5f, 16, 5, new BoxStyle { Radius = 3, Background = "#ffffff" });
                s.Box(cx - 2.5f, artY - 8, 5, 16, new BoxStyle { Radius = 3, Background = "#ffffff" });
            }
            else
            {
                if (day.Done) s.Open("opacity=\"0.55\"");
                RewardArt(s, day.Reward, 32, cx, artY);
                if (day.Done) s.Close();
            }
            cy += 36 + 3;
            if (jack) s.Text("50% OFF", x, cy, JackCaption, w, 0.5f);
            else
            {
                var ct = T(Kit.Display, 12, ink);
                s.Text(Ellipsize(RewardCaption(day.Reward), ct, w - 8), x, cy, ct, w, 0.5f);
            }
            if (day.Done)
            {
                // ✓: absolute top -2, right -2 of the face's padding box
                float kx = x + w + 2 - 22, ky = y - 2;
                s.Box(kx, ky, 22, 22, new BoxStyle { Radius = 11, Background = "#26a94e", BorderWidth = 2, BorderColor = "#ffffff" });
                float tw = W("✓", CheckText), th = LH(CheckText);
                s.Text("✓", kx + 2 + (18 - tw) / 2, ky + 2 + (18 - th) / 2, CheckText);
            }
        }

        /// <summary>StreakScreen.js RewardArt, centred on (cx, cy): coins (three for 400 and more), gems, the silver chest.</summary>
        static void RewardArt(UiSvg s, StreakReward r, float size, float cx, float cy)
        {
            if (r.Kind == "coins")
            {
                float bw = size * 1.3f, x0 = cx - bw / 2, y0 = cy - size / 2;
                if (r.Amount >= 400)
                {
                    float c = size * 0.62f;
                    Embed(s, "coin-candy", x0, y0 + size * 0.18f, c, c);
                    Embed(s, "coin-candy", x0 + bw - c, y0 + size * 0.18f, c, c);
                }
                float m = size * 0.78f;
                Embed(s, "coin-candy", cx - m / 2, cy - m / 2, m, m);
            }
            else if (r.Kind == "gems")
            {
                float g = size * 0.8f;
                Embed(s, "gem", cx - g / 2, cy - g / 2, g, g);
            }
            else if (r.Kind == "chest")
            {
                float c = size * 1.1f, box = 320 * c / 240;
                s.Image("Screens/img/chest-silver", cx - box / 2, cy - box / 2, box, box, "none");
            }
        }
    }
}
