// src/screens/SplashScreen.js from the Unity code: the white "Squish / Squad" title outlined in deep purple, the pink
// loading bar in its ring with a lip, and "WAKING UP THE SQUAD… N%" / "READY!", on the intro sky. Mittens' spot above
// the title stays empty, as in the app on a brand-new install (its picture comes from the creature catalog's cache,
// which Unity doesn't have yet). SplashModel is its clock: the bar runs to 90 % while the app starts, fills the rest
// once it's ready (1.5 s in at the earliest, 10 s at the latest) and moves on 250 ms after 100 %.
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Screens
{
    public sealed class SplashModel
    {
        public const double SOFT_MS = 2600, SOFT_TO = 0.9, MIN_MS = 1500, END_MS = 320, MAX_MS = 10000;
        static readonly Func<double, double> SoftEase = Easing.Out(Easing.Quad);
        public const float TRACK_W = 210;

        readonly Ticker _ticker;
        public readonly AnimatedValue Fill = new AnimatedValue(0);
        readonly double _start;
        double? _endAt;
        bool _due, _done;
        public int Pct { get; private set; }
        /// <summary>Raised once, 250 ms after the bar is full.</summary>
        public event Action Finished;
        public bool IsFinished => _done;

        static double Soft(double ms) => SOFT_TO * SoftEase(Math.Min(1, ms / SOFT_MS));

        /// <summary>Starts the bar on `ticker`'s clock (its Now is the start).</summary>
        public SplashModel(Ticker ticker)
        {
            _ticker = ticker;
            _start = ticker.Now;
            WithTicker(() => Animated.Timing(Fill, new TimingConfig { ToValue = SOFT_TO, Duration = SOFT_MS, Easing = SoftEase }).Start());
            _ticker.SetTimeout(() => SetReady(), MAX_MS);   // timedOut
            LabelTick();
        }

        void WithTicker(Action a) { var was = Ticker.Default; Ticker.Default = _ticker; try { a(); } finally { Ticker.Default = was; } }

        // LoadLabel: every 120 ms, the percentage on the same curve
        void LabelTick()
        {
            double now = _ticker.Now;
            double from = _endAt.HasValue ? Soft(_endAt.Value - _start) : 0;
            double p = _endAt.HasValue && now >= _endAt.Value ? from + (1 - from) * Math.Min(1, (now - _endAt.Value) / END_MS) : Soft(now - _start);
            Pct = (int)Math.Floor(p * 100 + 0.5);
            if (p < 1) _ticker.SetTimeout(LabelTick, 120);
        }

        public string Label => Pct >= 100 ? "READY!" : "WAKING UP THE SQUAD… " + Pct + "%";

        /// <summary>The app is ready (signed in or not, and the profile loaded); for good once seen.</summary>
        public void SetReady()
        {
            if (_due) return;
            _due = true;
            _ticker.SetTimeout(() =>
            {
                _endAt = _ticker.Now;
                WithTicker(() => Animated.Timing(Fill, new TimingConfig { ToValue = 1, Duration = END_MS, Easing = SoftEase }).Start(r =>
                {
                    if (r.Finished) _ticker.SetTimeout(() => { if (_done) return; _done = true; Finished?.Invoke(); }, 250);
                }));
            }, Math.Max(0, MIN_MS - (_ticker.Now - _start)));
        }
    }

    public sealed class SplashArt
    {
        const string PURPLE = "#45107a", PINK_RING = "#8a3a0e";
        static readonly string[] PINK = { "#ffe2c8", "#ff9a4a", "#e0601c" };
        public static readonly TextStyle TitleStyle = new TextStyle
        {
            Font = "Fredoka_700Bold", Size = 54, LineHeight = 52, Color = "#ffffff",
            Shadows = new[] { new Shadow(PURPLE, 0, 5, 0), new Shadow(PURPLE, 3, 0, 0), new Shadow(PURPLE, -3, 0, 0), new Shadow(PURPLE, 0, -3, 0) },
        };
        static readonly TextStyle LoadStyle = new TextStyle { Font = "Nunito_900Black", Size = 12, LetterSpacing = 1.5f, Color = PURPLE };
        static readonly string[] Lines = { "Squish", "Squad" };

        public readonly float W, H;
        public SplashArt(float w, float h) { W = w; H = h; }

        public Dictionary<string, Frame> Layout(string label)
        {
            float ms = Math.Min(230, (float)Math.Round(H * 0.42));
            var col = new FlexNode("column").Flex(1).AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(12);
            var root = new FlexNode("root").With(col);
            col.Add(new FlexNode("mascot").Size(ms, ms));
            float tw = 0;
            foreach (var l in Lines) tw = Math.Max(tw, UiSvg.BoxWidth(l, TitleStyle));
            col.Add(new FlexNode("title").Size(tw, 52 * Lines.Length));
            var ring = col.Add(new FlexNode("ring").Margin(YGEdge.Top, 14).Width(215).Padding(2.5f).Padding(YGEdge.Bottom, 6.5f));
            ring.Add(new FlexNode("bar").Height(14));
            col.Add(new FlexNode("load").Size(UiSvg.BoxWidth(label, LoadStyle), UiSvg.LineBox(LoadStyle)));
            root.Layout(W, H);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            return f;
        }

        public List<ScreenPiece> Pieces(SplashModel m)
        {
            var f = Layout(m.Label);
            var list = new List<ScreenPiece> { new ScreenPiece { Id = "bg", Svg = IntroArt.Svg(W, H), W = W, H = H, Margin = 0 } };
            var tf = f["title"];
            var t = new UiSvg(tf.W, tf.H);
            for (int i = 0; i < Lines.Length; i++) t.Text(Lines[i], 0, i * 52, TitleStyle, tf.W, 0.5f);
            list.Add(new ScreenPiece { Id = "title", Svg = t.Markup, W = tf.W, H = tf.H }.At(tf.X, tf.Y));
            // the bar: the ring with its lip, the white track, and the fill sliding in from the left (clipped by the track)
            var rf = f["ring"]; var bf = f["bar"];
            var r = new UiSvg(rf.W, rf.H).Box(0, 0, rf.W, rf.H, new BoxStyle { Radius = 999, Background = PINK_RING })
                .Box(bf.X - rf.X, bf.Y - rf.Y, bf.W, bf.H, new BoxStyle { Radius = 999, Background = "#ffffff" });
            list.Add(new ScreenPiece { Id = "ring", Svg = r.Markup, W = rf.W, H = rf.H }.At(rf.X, rf.Y));
            float x = (float)((m.Fill.GetValue() - 1) * SplashModel.TRACK_W);
            var fill = new UiSvg(bf.W, bf.H);
            var clip = fill.NewId("bar");
            fill.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(0, 0, bf.W, bf.H, new float[] { 7, 7, 7, 7 })}\"/></clipPath>");
            fill.Open($"clip-path=\"url(#{clip})\"").Box(x, 0, SplashModel.TRACK_W, bf.H, new BoxStyle { Radius = 999, Gradient = PINK, GradientStops = new[] { 0f, 0.55f, 1f } }).Close();
            list.Add(new ScreenPiece { Id = "fill", Svg = fill.Markup, W = bf.W, H = bf.H, Margin = 0 }.At(bf.X, bf.Y));
            var lf = f["load"];
            list.Add(new ScreenPiece { Id = "load", Svg = new UiSvg(lf.W, lf.H).Text(m.Label, 0, 0, LoadStyle).Markup, W = lf.W, H = lf.H }.At(lf.X, lf.Y));
            return list;
        }
    }
}
