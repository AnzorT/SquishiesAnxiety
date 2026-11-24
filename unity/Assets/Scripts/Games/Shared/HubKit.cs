// The pieces the games' hubs are made of (src/squishdoku/ui.js, fx.js, Hub.js), laid out with Yoga (FlexNode, React
// Native's defaults) and drawn as layers:
//   HubButton   an SdButton: while pressed the whole button (lip, ring and face) shrinks to 0.92 about its centre, as
//               the menu's Level crest does (70 ms in, a spring out); in a Pulse (a forever scale up and down, one loop) or
//               not. Drawn from CardArt.ButtonLook, or exported (GO ⚡: its emoji is Chrome's)
//               An Area is a box tapped as a whole and drawn by its hub (royal Plaque with onPress: it shrinks to 0.92
//               while held)
//   ModeCard    squishdoku/Hub.js ModeCard: a card sliding in (SlideIn, dy 50): its title, its lines, a progress bar,
//               the pulsing button
//   Para        a Text with lines of its own (\n), each wrapped and centred
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    public sealed class HubButton
    {
        public readonly string Name;
        public readonly float W, H;   // the whole button: the ring and the lip under it
        readonly float _ringW, _ringH;
        readonly Func<string> _lip, _face;
        public readonly Press Press = new Press();
        public KeyLoop Pulse;
        Interpolator _pulseScale;
        public Action OnPress;
        Affine _at = Affine.Identity;
        const float Lip = 5;

        HubButton(string name, float ringW, float ringH, Func<string> lip, Func<string> face, Action onPress)
        {
            Name = name; _ringW = ringW; _ringH = ringH; W = ringW; H = ringH + Lip; _lip = lip; _face = face; OnPress = onPress;
        }

        /// <summary>An exported SdButton from anywhere in Resources (its lip and its ring, both ringW x ringH).</summary>
        public static HubButton FromXml(string name, string lipPath, string facePath, float ringW, float ringH, Action onPress) =>
            new HubButton(name, ringW, ringH, () => HubsData.LoadXml(lipPath), () => HubsData.LoadXml(facePath), onPress);

        /// <summary>A box tapped as a whole (a Plaque with onPress), drawn by its hub: Held while the finger's on it, no
        /// sound of its own; Place puts it on the screen.</summary>
        public static HubButton Area(string name, float w, float h, Action onPress) => new HubButton(name, w, h - Lip, null, null, onPress) { _area = true };

        bool _area;
        /// <summary>An Area under the finger.</summary>
        public bool Held { get; private set; }
        public void Place(Affine at) => _at = at;
        public void Down() { if (_area) Held = true; else Press.Down(); }
        public void Up() { if (_area) Held = false; else Press.Up(); }

        public static HubButton Drawn(string name, CardArt.ButtonLook look, Action onPress) => new HubButton(name, look.RingW, look.RingH, look.LipMarkup, look.FaceMarkup, onPress);

        /// <summary>An exported button (Resources/Hubs/&lt;lip&gt;.xml, &lt;face&gt;.xml, both ringW x ringH).</summary>
        public static HubButton Exported(string name, string lip, string face, Action onPress)
        {
            var (w, h) = HubsData.Current.Size(face);
            return new HubButton(name, w, h, () => HubsData.LoadXml("Hubs/" + lip), () => HubsData.LoadXml("Hubs/" + face), onPress);
        }

        /// <summary>In a Pulse (fx.js: scale 1 → `to` → 1 every `ms`).</summary>
        public HubButton Pulsing(double to, double ms)
        {
            Pulse = new KeyLoop(ms, KeyLoop.PHASE, KeyLoop.UP_DOWN);
            _pulseScale = Fx.Lerp(new[] { 0.0, 1 }, new[] { 1, to });
            return this;
        }

        public void Mount() => Pulse?.Mount();
        public void Unmount() => Pulse?.Unmount();

        /// <summary>`at`: the button's box (top-left) to the screen.</summary>
        public void Draw(LayerFrame f, Affine at, float opacity)
        {
            if (Pulse != null) { double p = _pulseScale.Evaluate(Pulse.Value); at = at * Fx.About(W, H, Affine.ScaleBy(p, p)); }
            _at = at;
            var whole = at * Press.Local(W, H);
            var lip = f.L(Name + " lip"); lip.Set("lip", _lip, _ringW, _ringH, 2); lip.Transform = whole * Affine.Translate(0, Lip); lip.Opacity = opacity;
            var face = f.L(Name + " face"); face.Set("face", _face, _ringW, _ringH, 2); face.Transform = whole; face.Opacity = opacity;
        }

        /// <summary>A screen point on it (hitSlop 6).</summary>
        public bool Hit(float x, float y)
        {
            var p = _at.Inverse().Apply(new Vec2(x, y));
            return p.X >= -6 && p.X <= W + 6 && p.Y >= -6 && p.Y <= H + 6;
        }
    }

    /// <summary>A Text whose lines are its own (\n), each wrapped to the box and aligned.</summary>
    public sealed class Para
    {
        readonly List<TextFlow> _paras = new List<TextFlow>();
        public readonly TextStyle Style;
        public readonly float Align;

        public Para(string text, TextStyle style, float align = 0)
        {
            Style = style; Align = align;
            foreach (var p in text.Split('\n')) _paras.Add(new TextFlow(p, style, align));
        }

        float MaxContent() { float m = 0; foreach (var p in _paras) m = Math.Max(m, p.MaxContent()); return m; }

        public (float w, float h) Measure(float avail)
        {
            float max = MaxContent();
            if (float.IsNaN(avail) || max <= avail + 0.01f) return (max, _paras.Count * UiSvg.LineBox(Style));
            int n = 0;
            foreach (var p in _paras) n += p.MaxContent() <= avail + 0.01f ? 1 : p.Lines(avail).Count;
            return (avail, n * UiSvg.LineBox(Style));
        }

        public FlexNode Leaf(string name) => FlexNode.Leaf(name, Measure);

        public void Draw(UiSvg s, float x, float y, float w)
        {
            float lh = UiSvg.LineBox(Style);
            foreach (var p in _paras)
            {
                int n = p.MaxContent() <= w + 0.01f ? 1 : p.Lines(w).Count;
                p.Draw(s, x, y, w);
                y += n * lh;
            }
        }
    }

    /// <summary>squishdoku/Hub.js ModeCard (landscape): build its nodes under a column, lay the column out, then draw.</summary>
    public sealed class ModeCard
    {
        public readonly string Name, Kind;
        public readonly SlideIn Slide;
        public readonly HubButton Cta;
        readonly string _title;
        readonly string[] _lines;
        readonly double? _progress;      // the progress bar's fill (0-1), or none
        readonly bool _exportedTitle;
        FlexNode _wrap, _face, _title_, _track;
        readonly List<(FlexNode node, Para text)> _texts = new List<(FlexNode, Para)>();
        FlexNode _cta;

        static readonly TextStyle Line = new TextStyle { Font = MapArt.Heavy, Size = 12.5f, Color = MapArt.INK };
        string Ring => Kind == "blitz" ? "#0c5a9c" : "#8a3a0e";
        string[] Colors => Kind == "blitz" ? new[] { "#e0fbff", "#9feeff", "#5fd0f5" } : new[] { "#fff6ea", "#ffd9b0", "#ffb877" };
        TextStyle TitleStyle => new TextStyle { Font = MapArt.Display, Size = 24, Color = Ring, LetterSpacing = 1 };

        /// <summary>`kind` "regular" or "blitz" (BLITZ ⚡ and GO ⚡ are the exported pieces).</summary>
        public ModeCard(string name, string kind, string title, string[] lines, double delay, Action onPress, double? progress = null)
        {
            Name = name; Kind = kind; _title = title; _lines = lines; _progress = progress;
            Slide = new SlideIn(delay, 50);
            _exportedTitle = kind == "blitz";
            Cta = kind == "blitz"
                ? HubButton.Exported(name + " cta", "go-lip", "go-face", onPress).Pulsing(1.06, 1300)
                : HubButton.Drawn(name + " cta", new CardArt.ButtonLook("green", "PLAY ▶", 18, 16, 12), onPress).Pulsing(1.06, 1300);
        }

        public FlexNode Build()
        {
            _wrap = new FlexNode(Name).AlignSelf(YGAlign.Stretch);
            var ring = _wrap.Add(new FlexNode(Name + " ring").Padding(2.5f).Padding(YGEdge.Bottom, 7));
            _face = ring.Add(new FlexNode(Name + " face").Row().AlignItems(YGAlign.Center).PadH(14).PadV(8).Gap(10).Border(3));
            var body = _face.Add(new FlexNode(Name + " body").Flex(1).Gap(2));
            if (_exportedTitle)
            {
                var (_, th) = HubsData.Current.Size("blitz-title");
                _title_ = body.Add(FlexNode.Leaf("title", w => (float.IsNaN(w) ? HubsData.Current.Size("blitz-title").w : w, th)));
            }
            else
            {
                var p = new Para(_title, TitleStyle);
                _title_ = body.Add(p.Leaf("title"));
                _texts.Add((_title_, p));
            }
            foreach (var l in _lines) { var p = new Para(l, Line); _texts.Add((body.Add(p.Leaf("line")), p)); }
            if (_progress != null) _track = body.Add(new FlexNode("track").Height(10).Margin(YGEdge.Top, 4));
            _cta = _face.Add(FlexNode.Leaf("cta", w => (Cta.W, Cta.H)));
            return _wrap;
        }

        public void Mount() { Slide.Trigger(); Cta.Mount(); }
        public void Unmount() { Slide.Stop(); Cta.Unmount(); }

        string Markup()
        {
            var w = _wrap.Frame;
            float ox = w.X, oy = w.Y;
            var s = new UiSvg(w.W, w.H);
            s.Box(0, 0, w.W, w.H, new BoxStyle { Background = Ring, Radius = 26 });
            var fc = _face.Frame;
            float fx = fc.X - ox, fy = fc.Y - oy, b = FlexNode.Bw(3);
            s.Box(fx, fy, fc.W, fc.H, new BoxStyle { Background = "#ffffff", Radius = 23.5f });
            float px = fx + b, py = fy + b, pw = fc.W - 2 * b, ph = fc.H - 2 * b, r = 23.5f - b;
            s.Box(px, py, pw, ph, new BoxStyle { Gradient = Colors, GradientStops = new[] { 0f, 0.5f, 1 }, Radius = r });
            var clip = s.NewId("mc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, py, pw, ph, new[] { r, r, r, r })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(px + 14, py + 3, pw - 28, ph * 0.35f, new BoxStyle { Background = "rgba(255,255,255,0.4)", Radius = 20 });
            foreach (var (n, p) in _texts) p.Draw(s, n.Frame.X - ox, n.Frame.Y - oy, n.Frame.W);
            if (_exportedTitle) s.Raw(Nest.Svg(HubsData.LoadXml("Hubs/blitz-title"), "bt", _title_.Frame.X - ox, _title_.Frame.Y - oy));
            if (_track != null)
            {
                var t = _track.Frame;
                float tx = t.X - ox, ty = t.Y - oy;
                s.Box(tx, ty, t.W, t.H, new BoxStyle { Background = "rgba(142,21,128,0.18)", Radius = 5 });
                var tc = s.NewId("tc");
                s.Def($"<clipPath id=\"{tc}\"><path d=\"{UiSvg.RRect(tx, ty, t.W, t.H, new[] { 5f, 5, 5, 5 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{tc})\"");
                float fw = (float)(t.W * Math.Max(4, _progress.Value * 100) / 100);
                s.Box(tx, ty, fw, t.H, new BoxStyle { Gradient = new[] { "#ffe38a", "#ffb02e" }, GradientAngle = 90, Radius = 5 });
                s.Close();
            }
            s.Close();
            return s.Markup;
        }

        string _key;
        public void Draw(LayerFrame f, Affine view, float opacity)
        {
            var w = _wrap.Frame;
            var at = view * Affine.Translate(w.X, w.Y) * Slide.Local;
            float op = opacity * Slide.Opacity;
            var l = f.L(Name);
            _key ??= Guid.NewGuid().ToString();
            l.Set(_key, Markup, w.W, w.H, 4);
            l.Transform = at; l.Opacity = op;
            Cta.Draw(f, at * Affine.Translate(_cta.Frame.X - w.X, _cta.Frame.Y - w.Y), op);
        }
    }

    /// <summary>One SVG inside another: its ids prefixed, placed at (x, y) (and transformed).</summary>
    public static class Nest
    {
        public static string Svg(string svg, string prefix, float x, float y, string transform = null)
        {
            int a = svg.IndexOf('>') + 1;
            var inner = svg.Substring(a, svg.LastIndexOf("</svg>", StringComparison.Ordinal) - a);
            inner = inner.Replace("id=\"", "id=\"" + prefix).Replace("href=\"#", "href=\"#" + prefix).Replace("url(#", "url(#" + prefix);
            string tr = $"translate({UiSvg.F(x)} {UiSvg.F(y)})" + (transform != null ? " " + transform : "");
            return $"<g transform=\"{tr}\">{inner}</g>";
        }
    }
}
