// A yard game as the app's menu page shows it (develop: main-menu.js playGame in the Yard Games page, .mm-gp.land):
// the game's frame across the page (780 x 360, its height the page's less 6 px a side, a gold ring and a brown one),
// and what Unity draws itself over the game's own layers (those come straight from the compiled game, YardJs): the
// top bar (the app's orange back orb, the name, the score and time pills), the hint, the games' own pills and
// buttons, the toasts, the intro's how-to sheet and the results card in the app's look (webgame/app/games.js YPOP:
// cream card, outlined titles, numbered rules, gold / cream buttons), with their CSS animations (ygPop, ygToast,
// ygBump, ygStar). Every size is the page's CSS: yard-games.js's landscape rules (cqh = a hundredth of the frame's
// height) over the menu page's base ones, games.js's on top.
// Units: pu, the menu page's own px (main-menu.js puts the page at scale H / 393: K dp a pu). Plain C# (no UnityEngine):
// Games/Yard/View/YardScreen.cs shows the draws, tools/unity/yard-test draws them with the reference rasteriser.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;
using SquishSquad.Vector;

namespace SquishSquad.Games.Yard.View
{
    /// <summary>Where the game's frame is: the page at K dp a pu (screen height / 393), the frame in its middle (.mm-gp.land
    /// .mid: 6 px padding, the frame 100% high, 780 / 360 wide, centred).</summary>
    public sealed class YardGeom
    {
        public readonly double K, SW, SH, PW, FX, FY, FW, FH;
        public YardGeom(double screenWdp, double screenHdp)
        {
            SW = screenWdp; SH = screenHdp; K = screenHdp / 393.0; PW = screenWdp / K;
            FY = 6; FH = 393 - 12; FW = FH * 780 / 360; FX = (PW - FW) / 2;
        }
        /// <summary>1cqh: a hundredth of the frame's height (pu).</summary>
        public double Cq => FH / 100;
        /// <summary>One unit of the game's 780 x 360 stage (pu).</summary>
        public double Su => FH / 360;
        /// <summary>Page pu to screen dp.</summary>
        public Affine Page => Affine.ScaleBy(K, K);
        /// <summary>Stage units to screen dp.</summary>
        public Affine Stage => Affine.ScaleBy(K, K) * Affine.Translate(FX, FY) * Affine.ScaleBy(Su, Su);
        /// <summary>A screen point (dp) in stage units.</summary>
        public (double x, double y) ToStage(double xdp, double ydp) => ((xdp / K - FX) / Su, (ydp / K - FY) / Su);
    }

    /// <summary>One SVG to show: drawn in its own W x H pu box (Margin pu round it for what spills out), placed by M (its
    /// box's pu to screen dp), faded by Opacity. Key: the same key, the same picture (no redraw).</summary>
    public struct YardDraw
    {
        public string Key, Svg;
        public double W, H, Margin, Opacity;
        public Affine M;
    }

    public sealed class YardGameModel
    {
        public readonly YardGeom G;
        public YardGameModel(double screenWdp, double screenHdp) { G = new YardGeom(screenWdp, screenHdp); }

        /// <summary>The control under a held finger (drawn shrunk to 0.92 about its middle, as every button in the app).</summary>
        public string Held;
        /// <summary>The tap regions drawn this frame, in page pu: (id, x, y, w, h).</summary>
        public readonly List<(string id, double x, double y, double w, double h)> Hits = new List<(string, double, double, double, double)>();

        // the animations' clocks (ms): the score's bump, each toast, the cards' pops
        string _score, _phase;
        double _bumpAt = -1e9, _cardAt = -1e9;
        readonly Dictionary<int, double> _toastAt = new Dictionary<int, double>();

        const string Fred = "Fredoka_700Bold", Nun8 = "Nunito_800ExtraBold";
        const string INK = "#5b3418", BROWN = "#6b4426";
        static string F(double v) => UiSvg.F(v);
        static readonly Func<double, double> EaseOut = SquishSquad.Anim.Easing.Bezier(0, 0, 0.58, 1), Pop = SquishSquad.Anim.Easing.Bezier(0.2, 1.4, 0.4, 1), StarPop = SquishSquad.Anim.Easing.Bezier(0.2, 1.6, 0.4, 1), Ease = SquishSquad.Anim.Easing.Bezier(0.25, 0.1, 0.25, 1);

        double Cq => G.Cq;
        // a border width as Chrome lays it out: whole px from 1 up (0.85cqh = 3.24 -> 3; Ui/Screens/Flex.cs Bw), so the box's
        // inside is as wide as the page's (a how-to line that just fits there fits here)
        static double Bw(double w) => w >= 1 ? Math.Floor(w) : w;
        double B85 => Bw(0.85 * Cq);
        TextStyle T(string font, double cq, string color, double lh = 0, double ls = 0) => new TextStyle { Font = font, Size = (float)(cq * Cq), Color = color, LineHeight = lh > 0 ? (float)(cq * Cq * lh) : 0, LetterSpacing = (float)ls };
        static float Lh(TextStyle t) => t.LineHeight > 0 ? t.LineHeight : UiSvg.LineBox(t);

        // an SVG W x H pu at (x, y) pu on the page
        YardDraw Svg(string key, double x, double y, double w, double h, Func<UiSvg, UiSvg> draw, double margin = 8, double opacity = 1, Affine? around = null)
        {
            var s = draw(new UiSvg((float)w, (float)h));
            double K = G.K;
            var svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w * K)}\" height=\"{F(h * K)}\" viewBox=\"0 0 {F(w)} {F(h)}\" overflow=\"visible\">{Inner(s.Markup)}</svg>";
            return new YardDraw { Key = key, Svg = svg, W = w, H = h, Margin = margin, Opacity = opacity, M = G.Page * (around ?? Affine.Identity) * Affine.Translate(x, y) * Affine.ScaleBy(1 / K, 1 / K) };
        }
        static string Inner(string svg) { int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>", StringComparison.Ordinal); return svg.Substring(a, b - a); }
        static Affine About(double cx, double cy, double s) => Affine.Translate(cx, cy) * Affine.ScaleBy(s, s) * Affine.Translate(-cx, -cy);
        Affine Press(string id, double cx, double cy) => Held == id ? About(cx, cy, 0.92) : Affine.Identity;

        // ---- the frame ----------------------------------------------------------------------------------------------
        /// <summary>The ring round the frame (.mm-gp .mid .yg-frame: 4 px gold, 6 px brown, a drop 14 / 30) and its own
        /// background (#eaf7ff, 26 px corners).</summary>
        public YardDraw Frame(string inside = "#eaf7ff")
        {
            double w = G.FW, h = G.FH;
            return Svg("frame|" + inside, G.FX, G.FY, w, h, u => u.Box(0, 0, (float)w, (float)h, new BoxStyle
            {
                Background = inside, Radius = 26,
                Shadows = new[] { new Shadow("#ffd76a", 0, 0, 0, 4), new Shadow("#6b4426", 0, 0, 0, 6), new Shadow("rgba(0,0,0,0.45)", 0, 14, 30) },
            }), 60);
        }
        /// <summary>The frame's clip (26 px corners), in stage units: what the game's layers are cut to.</summary>
        public string ClipPath(string id) => $"<clipPath id=\"{id}\"><path d=\"{UiSvg.RRect(0, 0, 780, 360, Rx(26 / G.Su))}\"/></clipPath>";
        static float[] Rx(double r) => new[] { (float)r, (float)r, (float)r, (float)r };

        // ---- the HUD -------------------------------------------------------------------------------------------------
        /// <summary>What Unity draws over the game's layers this frame (bottom to top): the top bar, the hint, the games'
        /// own pills and buttons, the toasts, the intro's sheet or the results card. `now` ms.</summary>
        public List<YardDraw> Draw(YardUi u, double now)
        {
            var o = new List<YardDraw>();
            Hits.Clear();
            if (u.Phase != _phase) { _phase = u.Phase; _cardAt = now; }
            if (u.Score != _score) { if (_score != null && u.Phase == "play") _bumpAt = now; _score = u.Score; }
            // (the intro's poster covers the HUD and the toasts: .yg-ov sits over both)
            bool intro = u.Phase == "intro";
            if (!intro) { TopBar(o, u, now); Hint(o, u); Extras(o, u); Toasts(o, u, now); }
            if (intro) Sheet(o, u, now);
            else if (u.Phase == "result") Result(o, u, now);
            return o;
        }

        // the app's orange back orb (games.js BACK), 10cqh, its ‹ glyph
        void Orb(UiSvg s, double x, double y)
        {
            double d = 10 * Cq, b = Bw(0.7 * Cq);
            s.Box((float)x, (float)y, (float)d, (float)d, new BoxStyle
            {
                Gradient = new[] { "#ffc58a", "#ff9a4a", "#e0601c" }, GradientStops = new[] { 0f, 0.55f, 1f }, Radius = 999,
                BorderWidth = (float)b, BorderColor = "#ffffff",
                Shadows = new[] { new Shadow("#8a3a0e", 0, 0, 0, (float)(0.6 * Cq)), new Shadow("#8a3a0e", 0, (float)(1.1 * Cq), 0, (float)(0.6 * Cq)) },
            });
            // the glyph: Fredoka 700 8cqh, line-height 1, centred in the content box (padding-bottom 1cqh)
            var t = T(Fred, 8, "#ffffff", 1); t.Shadows = new[] { new Shadow("#8a3a0e", 0, (float)(0.3 * Cq), 0) };
            double ch = d - 2 * b - 1 * Cq;
            s.Text("‹", (float)(x + b), (float)(y + b + (ch - Lh(t)) / 2), t, (float)(d - 2 * b), 0.5f);
        }

        void TopBar(List<YardDraw> o, YardUi u, double now)
        {
            double pad = 2.6 * Cq, padX = 3 * Cq, gap = 2 * Cq, barH = 10 * Cq + 2 * pad, W = G.FW;
            o.Add(Svg("top", G.FX, G.FY, W, barH, s => s.Box(0, 0, (float)W, (float)barH, new BoxStyle { Gradient = new[] { "rgba(255,255,255,0.85)", "rgba(255,255,255,0)" } }), 2));
            double bx = G.FX + padX, by = G.FY + pad, d = 10 * Cq;
            o.Add(Svg("back", bx, by, d, d, s => { Orb(s, 0, 0); return s; }, 12, 1, Press("back", bx + d / 2, by + d / 2)));
            Hits.Add(("back", bx, by, d, d));
            // the pills, right to left: the time, then the score (min 11cqh, padding 1.4 / 2.8cqh)
            var pt = T(Fred, 4.4, "#4a1a73", 1);
            double ph = 4.4 * Cq + 2.8 * Cq, pr = G.FX + W - padX, cy = G.FY + pad + d / 2;
            double PillW(string txt) => Math.Max(11 * Cq, UiSvg.BoxWidth(txt, pt)) + 5.6 * Cq;
            if (!string.IsNullOrEmpty(u.Time))
            {
                double w = PillW(u.Time);
                string bg = u.Hurry ? "#ff7a8a" : "#ffffff", tc = u.Hurry ? "#ffffff" : "#4a1a73";
                o.Add(Svg("time|" + u.Time + bg, pr - w, cy - ph / 2, w, ph, s => s.Box(0, 0, (float)w, (float)ph, new BoxStyle { Background = bg, Radius = 999, Shadows = new[] { new Shadow("rgba(106,47,176,0.25)", 0, (float)(0.8 * Cq), 0) } })
                    .Text(u.Time, (float)(2.8 * Cq), (float)(1.4 * Cq), T(Fred, 4.4, tc, 1), (float)(w - 5.6 * Cq), 0.5f)));
                pr -= w + 1.6 * Cq;
            }
            {
                string sc = u.Score ?? "0"; double w = PillW(sc), x = pr - w;
                // ygBump .35s ease-out: 1 -> 1.25 (40 %) -> 1
                double bu = (now - _bumpAt) / 350, k = 1;
                if (bu >= 0 && bu < 1) { double e = EaseOut(bu); k = e < 0.4 ? 1 + 0.25 * (e / 0.4) : 1.25 - 0.25 * ((e - 0.4) / 0.6); }
                o.Add(Svg("score|" + sc, x, cy - ph / 2, w, ph, s => s.Box(0, 0, (float)w, (float)ph, new BoxStyle { Background = "#ffe36e", Radius = 999, Shadows = new[] { new Shadow("rgba(106,47,176,0.25)", 0, (float)(0.8 * Cq), 0) } })
                    .Text(sc, (float)(2.8 * Cq), (float)(1.4 * Cq), pt, (float)(w - 5.6 * Cq), 0.5f), 8, 1, About(x + w / 2, cy, k)));
                pr = x - gap;
            }
            // the name: Fredoka 5.2cqh / 1.1, after the orb, centred on the bar's line
            var tt = T(Fred, 5.2, "#4a1a73", 1.1);
            double tx = bx + d + gap, tw = Math.Max(1, pr - tx), th = Lh(tt);
            o.Add(Svg("ttl|" + u.Title, tx, cy - th / 2, tw, th, s => s.Text(u.Title, 0, 0, tt), 4));
        }

        // the hint: bottom right (right 3cqh, bottom 2.6cqh, at most 44 % wide), Nunito 800 3.6cqh / 1.25, white with
        // its shadows, right-aligned lines
        void Hint(List<YardDraw> o, YardUi u)
        {
            if (string.IsNullOrEmpty(u.Hint)) return;
            var t = T(Nun8, 3.6, "#ffffff", 1.25);
            t.Shadows = new[] { new Shadow("rgba(40,60,20,0.6)", 0, 1, 0), new Shadow("rgba(40,60,20,0.45)", 0, 0, 6) };
            double maxW = G.FW * 0.44;
            var lines = Wrap(u.Hint, t, maxW);
            double w = 0; foreach (var l in lines) w = Math.Max(w, UiSvg.BoxWidth(l, t));
            double lh = Lh(t), h = lines.Count * lh, x = G.FX + G.FW - 3 * Cq - w, y = G.FY + G.FH - 2.6 * Cq - h;
            o.Add(Svg("hint|" + u.Hint, x, y, w, h, s => { for (int i = 0; i < lines.Count; i++) s.Text(lines[i], 0, (float)(i * lh), t, (float)w, 1); return s; }, 10));
        }

        static List<string> Wrap(string text, TextStyle t, double maxW)
        {
            var lines = new List<string>(); string cur = "";
            foreach (var w in (text ?? "").Split(' '))
            {
                var tr = cur.Length == 0 ? w : cur + " " + w;
                if (cur.Length > 0 && UiSvg.Width(tr, t) > maxW + 0.01) { lines.Add(cur); cur = w; } else cur = tr;
            }
            if (cur.Length > 0) lines.Add(cur);
            return lines;
        }

        // ---- the games' own: pills (inline styles in page px) and Hopscotch's buttons ------------------------------------
        static Dictionary<string, string> Css(string css)
        {
            var d = new Dictionary<string, string>();
            foreach (var part in (css ?? "").Split(';'))
            {
                int i = part.IndexOf(':'); if (i < 0) continue;
                d[part.Substring(0, i).Trim()] = part.Substring(i + 1).Trim();
            }
            return d;
        }
        static double Num(string v, double d = 0) { if (v == null) return d; var s = v.Replace("px", "").Replace("%", "").Trim(); return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var n) ? n : d; }

        void Extras(List<YardDraw> o, YardUi u)
        {
            for (int i = 0; i < u.Pills.Count; i++)
            {
                var p = u.Pills[i]; var c = Css(p.Css);
                double size = Num(c.TryGetValue("font-size", out var fs) ? fs : null, 4.4 * Cq);
                var pad = (c.TryGetValue("padding", out var pd) ? pd : "").Split(' ');
                double py = pad.Length > 0 ? Num(pad[0], 1.4 * Cq) : 1.4 * Cq, px = pad.Length > 1 ? Num(pad[1], 2.8 * Cq) : py;
                double gap = c.TryGetValue("gap", out var gp) ? Num(gp) : 0;
                var t = new TextStyle { Font = Fred, Size = (float)size, Color = "#4a1a73", LineHeight = (float)size };
                // its words: the spans (each its colour, `gap` apart) or the text
                var parts = new List<(string text, string col)>();
                if (p.Spans.Count > 0) foreach (var sp in p.Spans) parts.Add((sp.text, string.IsNullOrEmpty(sp.color) ? "#4a1a73" : sp.color)); else parts.Add((p.Text, "#4a1a73"));
                double tw = -gap; foreach (var pp in parts) tw += UiSvg.BoxWidth(pp.text, t) + gap;
                double cw = c.ContainsKey("display") ? tw : Math.Max(11 * Cq, tw);   // (min-width 11cqh: a block pill; the flex one is as wide as its marks)
                double w = cw + 2 * px, h = size + 2 * py;
                double x = c.TryGetValue("right", out var rt) && rt != "auto" ? G.FX + G.FW - G.FW * Num(rt) / 100 - w : G.FX + G.FW * Num(c.TryGetValue("left", out var lf) ? lf : "50") / 100 - (c.ContainsKey("transform") ? w / 2 : 0);
                double y = G.FY + G.FH * Num(c.TryGetValue("top", out var tp) ? tp : "12.5") / 100;
                var key = "pill" + i + "|" + p.Css + "|" + p.Text;
                o.Add(Svg(key, x, y, w, h, s =>
                {
                    s.Box(0, 0, (float)w, (float)h, new BoxStyle { Background = "#ffffff", Radius = 999, Shadows = new[] { new Shadow("rgba(106,47,176,0.25)", 0, (float)(0.8 * Cq), 0) } });
                    double cx = px + (cw - tw) / 2;
                    foreach (var pp in parts) { s.Text(pp.text, (float)cx, (float)py, new TextStyle { Font = Fred, Size = (float)size, Color = pp.col, LineHeight = (float)size }); cx += UiSvg.BoxWidth(pp.text, t) + gap; }
                    return s;
                }));
            }
            if (u.Bar != null && u.Bar.List.Count > 0)
            {
                // Hopscotch's bar: right 2.5 %, 40 % wide, bottom 4 %, gap 3 %; each button flex 1 (at most 30 %), 1.65 : 1,
                // 22 % corners, white, its colour's lip (1.2cqw), its icon (46 %) over its word (clamp(12px, 4.6cqw, 20px))
                var bar = u.Bar; int n = bar.List.Count;
                double bw = G.FW * 0.40, gap = bw * 0.03, cqw = G.FW / 100;
                double each = Math.Min(bw * 0.30, (bw - gap * (n - 1)) / n), bh = each / 1.65;
                double x0 = G.FX + G.FW - G.FW * 0.025 - bw + (bw - (each * n + gap * (n - 1))) / 2, y0 = G.FY + G.FH - G.FH * 0.04 - bh;
                double fs = Math.Max(12, Math.Min(20, 4.6 * cqw));
                for (int i = 0; i < n; i++)
                {
                    var b = bar.List[i]; double x = x0 + i * (each + gap); string id = "btn:" + i;
                    double ic = bh * 0.46, lineH = fs, gapV = bh * 0.04, total = ic + gapV + lineH, top = (bh - total) / 2;
                    o.Add(Svg("btn" + i + "|" + b.Label + b.Color, x, y0, each, bh, s =>
                    {
                        s.Box(0, 0, (float)each, (float)bh, new BoxStyle { Background = "#ffffff", Radius = (float)(Math.Min(each, bh) * 0.22), Radii = new[] { (float)(each * 0.22), (float)(each * 0.22), (float)(each * 0.22), (float)(each * 0.22) }, Shadows = new[] { new Shadow(b.Color, 0, (float)(1.2 * cqw), 0) } });
                        if (!string.IsNullOrEmpty(b.Icon)) s.Raw(Icon(b.Icon.Replace("currentColor", b.Color), (each - ic) / 2, top, ic, ic));
                        s.Text(b.Label, 0, (float)(top + ic + gapV), new TextStyle { Font = Fred, Size = (float)fs, Color = b.Color, LineHeight = (float)fs }, (float)each, 0.5f);
                        return s;
                    }, 8, 1, Press(id, x + each / 2, y0 + bh / 2)));
                    Hits.Add((id, x, y0, each, bh));
                }
            }
        }

        static string Icon(string svg, double x, double y, double w, double h)
        {
            int a = svg.IndexOf("<svg", StringComparison.Ordinal); if (a < 0) return "";
            int b = svg.IndexOf('>', a);
            return $"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\"" + svg.Substring(a + 4, b - a - 4) + svg.Substring(b);
        }

        // ---- the toasts (ygToast: 1 s, 1.4 s when big, ease-out between keys) -------------------------------------------
        void Toasts(List<YardDraw> o, YardUi u, double now)
        {
            var seen = new HashSet<int>();
            foreach (var t in u.Toasts)
            {
                seen.Add(t.Id);
                if (!_toastAt.TryGetValue(t.Id, out var t0)) _toastAt[t.Id] = t0 = now;
                double dur = t.Big ? 1400 : 1000, p = Math.Min(1, (now - t0) / dur);
                double size = (t.Big ? 12 : 6) * Cq;
                var f = UiFont.Get(Fred);
                double w = f.BoxWidth(t.Text, (float)size, 0), h = size;   // (line-height 1)
                // the keys: opacity 0 / 18 % 1 / 75 % 1 / 100 % 0; transform 0 (-30 %, 0.6) / 18 % (-50 %, 1.12) / 30 %
                // (-50 %, 1) / 100 % (-110 %, 1)
                double op = Seg(p, new[] { 0, 0.18, 0.75, 1 }, new[] { 0.0, 1, 1, 0 });
                double ty = Seg(p, new[] { 0, 0.18, 0.30, 1 }, new[] { -0.3, -0.5, -0.5, -1.1 }), sc = Seg(p, new[] { 0, 0.18, 0.30, 1 }, new[] { 0.6, 1.12, 1, 1 });
                double cx = G.FX + G.FW * t.X / 100, cy = G.FY + G.FH * t.Y / 100;
                double sw = 0.5 * Cq;
                var M = Affine.Translate(cx, cy) * Affine.Translate(-w / 2, ty * h) * About(w / 2, h / 2, sc);
                o.Add(Svg("toast" + t.Id + "|" + t.Text + t.Color + t.Big, 0, 0, w, h, s =>
                {
                    float base_ = UiSvg.Baseline(new TextStyle { Font = Fred, Size = (float)size, LineHeight = (float)size }, 0);
                    s.Glyphs(t.Text, 0, base_, Fred, (float)size, 0, "#4a1a73", $"stroke=\"#4a1a73\" stroke-width=\"{F(sw * f.UnitsPerEm / size)}\" stroke-linejoin=\"round\"");
                    s.Glyphs(t.Text, 0, base_, Fred, (float)size, 0, t.Color);
                    return s;
                }, 12, op, M));
            }
            foreach (var id in new List<int>(_toastAt.Keys)) if (!seen.Contains(id)) _toastAt.Remove(id);
        }
        static double Seg(double p, double[] at, double[] v)
        {
            int i = 1; while (i < at.Length - 1 && p > at[i]) i++;
            double u = Math.Max(0, Math.Min(1, (p - at[i - 1]) / (at[i] - at[i - 1])));
            return v[i - 1] + (v[i] - v[i - 1]) * EaseOut(u);
        }

        // ---- the app's lettering (games.js sqTitle: OutlinedTitle) ---------------------------------------------------------
        static readonly Dictionary<string, string[]> FILLS = new Dictionary<string, string[]> { ["gold"] = new[] { "#fffbd6", "#ffe045", "#ff9500" }, ["orange"] = new[] { "#fff0d6", "#ffb05a", "#e8681c" } };
        // `text` upper case at `size` cqh, centred in a `w` wide box (its height 1.42 x size), its baseline at 1.06 x size:
        // a deep drop, a brown halo, a white outline, the gradient letters (letter-spacing .03em)
        void Title(UiSvg s, string text, string fill, double size, double x, double y, double w, string id)
        {
            var T0 = (text ?? "").ToUpperInvariant();
            double px = size * Cq, ls = 0.03 * px;
            var f = UiFont.Get(Fred);
            double tw = f.BoxWidth(T0, (float)px, (float)ls) - ls;   // (text-anchor middle: the advance less the last spacing)
            double x0 = x + w / 2 - tw / 2, base_ = y + size * 1.06 * Cq;
            var cols = FILLS.TryGetValue(fill, out var c) ? c : FILLS["gold"];
            // (the gradient spans the text's box, its advance by the font's ascent and descent, as Chrome maps a text's
            // objectBoundingBox paint)
            double asc = f.Ascender * px / f.UnitsPerEm, desc = -f.Descender * px / f.UnitsPerEm;
            s.Def($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(base_ - asc)}\" x2=\"0\" y2=\"{F(base_ + desc)}\"><stop offset=\"0\" stop-color=\"{cols[0]}\"/><stop offset=\"0.5\" stop-color=\"{cols[1]}\"/><stop offset=\"1\" stop-color=\"{cols[2]}\"/></linearGradient>");
            string St(string col, double k) => $"stroke=\"{col}\" stroke-width=\"{F(k * f.UnitsPerEm)}\" stroke-linejoin=\"round\"";
            s.Open($"transform=\"translate(0 {F(size * 0.15 * Cq)})\"");
            s.Glyphs(T0, (float)x0, (float)base_, Fred, (float)px, (float)ls, "#3f2412", St("#3f2412", 0.34));
            s.Close();
            s.Glyphs(T0, (float)x0, (float)base_, Fred, (float)px, (float)ls, BROWN, St(BROWN, 0.34));
            s.Glyphs(T0, (float)x0, (float)base_, Fred, (float)px, (float)ls, "#ffffff", St("#ffffff", 0.2));
            // the gradient letters: a box painted with it, cut to the glyphs (a fill on the glyphs themselves would map the
            // gradient in each glyph's own flipped units)
            var clip = new UiSvg(1, 1); clip.Glyphs(T0, (float)x0, (float)base_, Fred, (float)px, (float)ls, "#000");
            var cm = clip.Markup; int ca = cm.IndexOf("<defs>", StringComparison.Ordinal) + 6, cb = cm.IndexOf("</defs>", StringComparison.Ordinal);
            string glyphDefs = cm.Substring(ca, cb - ca).Replace("id=\"gl", "id=\"" + id + "gl"), glyphs = cm.Substring(cb + 7, cm.LastIndexOf("</svg>", StringComparison.Ordinal) - cb - 7).Replace("href=\"#gl", "href=\"#" + id + "gl");
            s.Def(glyphDefs + $"<clipPath id=\"{id}c\">{glyphs}</clipPath>");
            s.Raw($"<rect x=\"{F(x0 - px)}\" y=\"{F(base_ - asc - px)}\" width=\"{F(tw + 2 * px)}\" height=\"{F(asc + desc + 2 * px)}\" fill=\"url(#{id})\" clip-path=\"url(#{id}c)\"/>");
        }

        // the app's card (games.js CARD: cream, a white edge, the brown ring and lip, a soft shadow; 8cqh corners)
        BoxStyle Card() => new BoxStyle
        {
            Gradient = new[] { "#fffaf0", "#fff1dc", "#f6e2c4" }, GradientStops = new[] { 0f, 0.55f, 1f }, Radius = (float)(8 * Cq),
            BorderWidth = (float)B85, BorderColor = "#ffffff",
            Shadows = new[] { new Shadow(BROWN, 0, 0, 0, (float)(0.85 * Cq)), new Shadow(BROWN, 0, (float)(2.2 * Cq), 0, (float)(0.85 * Cq)), new Shadow("rgba(40,16,4,0.35)", 0, (float)(5 * Cq), (float)(12 * Cq)) },
        };

        // the app's SdButton (games.js .yg-btn: gold, or cream with brown words): a white edge, a darker ring and lip, the
        // shine (::before) over the top, the words in capitals (Fredoka 700, letter-spacing .03em)
        void Btn(UiSvg s, string label, double x, double y, double w, double h, double fontCq, bool gold)
        {
            string ring = gold ? "#9c4d06" : BROWN;
            s.Box((float)x, (float)y, (float)w, (float)h, new BoxStyle
            {
                Gradient = gold ? new[] { "#fff7b0", "#ffd23a", "#ff9c0a" } : new[] { "#ffffff", "#fff6e8", "#f3dfbd" }, GradientStops = new[] { 0f, 0.5f, 1f },
                Radius = 999, BorderWidth = (float)B85, BorderColor = "#ffffff",
                Shadows = new[] { new Shadow(ring, 0, 0, 0, (float)(0.75 * Cq)), new Shadow(ring, 0, (float)(1.5 * Cq), 0, (float)(0.75 * Cq)) },
            });
            double b = B85, iw = w - 2 * b, ih = h - 2 * b;
            s.Box((float)(x + b + iw * 0.08), (float)(y + b + 0.5 * Cq), (float)(iw * 0.84), (float)(ih * 0.42), new BoxStyle { Background = "rgba(255,255,255,0.45)", Radius = 999 });
            var t = T(Fred, fontCq, gold ? "#ffffff" : BROWN, 1, 0.03 * fontCq * Cq);
            if (gold)
            {
                double a = 0.45 * Cq, c = 0.32 * Cq;
                t.Shadows = new[] { new Shadow("#9c4d06", (float)-a, 0, 0), new Shadow("#9c4d06", (float)a, 0, 0), new Shadow("#9c4d06", 0, (float)-a, 0), new Shadow("#9c4d06", 0, (float)a, 0),
                    new Shadow("#9c4d06", (float)-c, (float)-c, 0), new Shadow("#9c4d06", (float)c, (float)-c, 0), new Shadow("#9c4d06", (float)-c, (float)c, 0), new Shadow("#9c4d06", (float)c, (float)c, 0) };
            }
            string L = (label ?? "").ToUpperInvariant();
            s.Text(L, (float)(x + b), (float)(y + b + (ih - Lh(t)) / 2), t, (float)iw, 0.5f);
        }
        double BtnW(string label, double fontCq, double padX) { var t = T(Fred, fontCq, "#fff", 1, 0.03 * fontCq * Cq); return UiSvg.BoxWidth((label ?? "").ToUpperInvariant(), t) + 2 * padX * Cq + 2 * B85; }

        // ygPop .35s cubic-bezier(.2,1.4,.4,1): scale 0.7 -> 1, opacity 0 -> 1
        (double k, double op) PopAt(double now) { double p = Math.Min(1, Math.Max(0, (now - _cardAt) / 350)), e = Pop(p); return (0.7 + 0.3 * e, Math.Min(1, e)); }

        // ---- the intro's how-to sheet (down the right: right / top / bottom 3cqh, 43 % wide, a flex column centred) ------
        void Sheet(List<YardDraw> o, YardUi u, double now)
        {
            var I = u.IntroSheet ?? new YardUi.Intro();
            double d = 10 * Cq, bx = G.FX + 3 * Cq, by = G.FY + 3 * Cq;
            o.Add(Svg("iback", bx, by, d, d, s => { Orb(s, 0, 0); return s; }, 12, 1, Press("iback", bx + d / 2, by + d / 2)));
            Hits.Add(("iback", bx, by, d, d));
            double w = G.FW * 0.43, x = G.FX + G.FW - 3 * Cq - w, y = G.FY + 3 * Cq, h = G.FH - 6 * Cq;
            double b = B85, padT = 3 * Cq, padB = 4 * Cq, padX = 5 * Cq, cw = w - 2 * b - 2 * padX;
            // the column's parts and their heights
            double titleH = 6.4 * 1.42 * Cq;
            var ht = T(Nun8, 3.4, INK, 1.32);
            double disc = 7 * Cq, textW = cw - disc - 2.2 * Cq, lh = Lh(ht);
            var rules = new List<List<string>>(); double listH = 0;
            foreach (var r in I.How) { var l = Wrap(r, ht, textW); rules.Add(l); listH += Math.Max(l.Count * lh, disc - 0.4 * Cq); }
            if (rules.Count > 1) listH += (rules.Count - 1) * 1.6 * Cq;
            var ot = T(Nun8, 3.2, BROWN, 1);
            double optH = I.Opts.Count > 0 ? 3.2 * Cq + 2 * 1.6 * Cq + 2 * Bw(0.6 * Cq) : 0;
            double goH = 5.6 * Cq + 2 * 2.8 * Cq + 2 * b;
            var bt = T(Nun8, 3.2, "#9a6a3a", 1);
            double total = titleH + 2.2 * Cq + listH + 0.6 * Cq + (optH > 0 ? 1.4 * Cq + optH + 0.2 * Cq : 0) + 3 * Cq + goH + 1.8 * Cq + Lh(bt);
            double inner = h - 2 * b - padT - padB, y0 = b + padT + (inner - total) / 2;
            // the hits (page pu)
            double yy = y0 + titleH + 2.2 * Cq + listH + 0.6 * Cq;
            var opts = new List<(double x, double w)>();
            if (optH > 0)
            {
                yy += 1.4 * Cq; double tot = -2 * Cq; foreach (var op in I.Opts) tot += UiSvg.BoxWidth(op.label, ot) + 2 * 3.4 * Cq + 2 * Bw(0.6 * Cq) + 2 * Cq;
                double ox = b + padX + (cw - tot) / 2;
                for (int i = 0; i < I.Opts.Count; i++) { double ow = UiSvg.BoxWidth(I.Opts[i].label, ot) + 2 * 3.4 * Cq + 2 * Bw(0.6 * Cq); opts.Add((ox, ow)); Hits.Add(("opt:" + i, x + ox, y + yy, ow, optH)); ox += ow + 2 * Cq; }
                yy += optH + 0.2 * Cq;
            }
            double goY = yy + 3 * Cq, goX = b + padX;
            Hits.Add(("play", x + goX, y + goY, cw, goH));
            var (k, op_) = PopAt(now);
            string held = Held != null && (Held == "play" || Held.StartsWith("opt:")) ? Held : "";
            o.Add(Svg("sheet|" + string.Join("|", I.How) + I.Best + string.Join(",", I.Opts) + held, x, y, w, h, s =>
            {
                s.Box(0, 0, (float)w, (float)h, Card());
                Title(s, "How to play", "gold", 6.4, b + padX, y0, cw, "sht");
                double ly = y0 + titleH + 2.2 * Cq;
                for (int i = 0; i < rules.Count; i++)
                {
                    double dx = b + padX, dy = ly - 0.4 * Cq;
                    s.Box((float)dx, (float)dy, (float)disc, (float)disc, new BoxStyle { Background = "#ff8a3d", Radius = 999, BorderWidth = (float)Bw(0.7 * Cq), BorderColor = "#ffffff", Shadows = new[] { new Shadow("#e0601c", 0, 0, 0, (float)(0.35 * Cq)) } });
                    var nt = T(Fred, 3.6, "#ffffff", 1);
                    s.Text((i + 1).ToString(CultureInfo.InvariantCulture), (float)dx, (float)(dy + (disc - Lh(nt)) / 2), nt, (float)disc, 0.5f);
                    for (int j = 0; j < rules[i].Count; j++) s.Text(rules[i][j], (float)(dx + disc + 2.2 * Cq), (float)(ly + j * lh), ht);
                    ly += Math.Max(rules[i].Count * lh, disc - 0.4 * Cq) + 1.6 * Cq;
                }
                for (int i = 0; i < opts.Count; i++)
                {
                    var (ox, ow) = opts[i]; bool on = I.Opts[i].on; double oy = yy - optH - 0.2 * Cq;
                    if (held == "opt:" + i) s.Open($"transform=\"translate({F(ox + ow / 2)} {F(oy + optH / 2)}) scale(0.92) translate({F(-(ox + ow / 2))} {F(-(oy + optH / 2))})\"");
                    s.Box((float)ox, (float)oy, (float)ow, (float)optH, new BoxStyle
                    {
                        Background = on ? null : "#fff6e8", Gradient = on ? new[] { "#fff7b0", "#ffd23a", "#ff9c0a" } : null, GradientStops = on ? new[] { 0f, 0.5f, 1f } : null,
                        Radius = 999, BorderWidth = (float)Bw(0.6 * Cq), BorderColor = "#ffffff", Shadows = new[] { new Shadow(on ? "#9c4d06" : BROWN, 0, 0, 0, (float)(0.4 * Cq)) },
                    });
                    s.Text(I.Opts[i].label, (float)ox, (float)(oy + (optH - Lh(ot)) / 2), T(Nun8, 3.2, on ? "#7a3a04" : BROWN, 1), (float)ow, 0.5f);
                    if (held == "opt:" + i) s.Close();
                }
                if (held == "play") s.Open($"transform=\"translate({F(goX + cw / 2)} {F(goY + goH / 2)}) scale(0.92) translate({F(-(goX + cw / 2))} {F(-(goY + goH / 2))})\"");
                Btn(s, "Play", goX, goY, cw, goH, 5.6, true);
                if (held == "play") s.Close();
                s.Text(I.Best, (float)goX, (float)(goY + goH + 1.8 * Cq), bt, (float)cw, 0.5f);
                return s;
            }, 40, op_, About(x + w / 2, y + h / 2, k)));
        }

        // ---- the results card (in the middle: the dim, the card at least 46 % and at most 60 % of the ov's width) --------
        void Result(List<YardDraw> o, YardUi u, double now)
        {
            var R = u.Res ?? new YardUi.Result();
            o.Add(Svg("dim", G.FX, G.FY, G.FW, G.FH, s => s.Box(0, 0, (float)G.FW, (float)G.FH, new BoxStyle { Background = "rgba(50,24,6,0.55)", Radius = 26 }), 0));
            double b = B85, padT = 3.6 * Cq, padB = 4.6 * Cq, padX = 6 * Cq;
            // the parts: the title (8.4cqh lettering, 1.42 high), the stars (11cqh, gap 2cqh; margin 2 / 1cqh), the score
            // (12cqh / 1), the sub (3.6cqh / 1.3, margin-top 1cqh), the coins (4.6cqh, the coin 6.6cqh; margin 2.4 / 3.6cqh),
            // the buttons (5cqh, padding 2.6 / 6cqh, gap 3cqh)
            double titleH = 8.4 * 1.42 * Cq, starsH = 11 * Cq, scoreH = 12 * Cq;
            var sub = T(Nun8, 3.6, "#9a6a3a", 1.3); var ct = T(Fred, 4.6, "#b86200", 1);
            double coinS = 6.6 * Cq, coinsW = coinS + 1.4 * Cq + UiSvg.BoxWidth(R.Coins, ct), coinsH = coinS;
            var labels = R.Buttons.Count > 0 ? R.Buttons : new List<string> { "Yard games", "Play again" };
            double bh = 5 * Cq + 2 * 2.6 * Cq + 2 * b, rowW = -3 * Cq; var bws = new List<double>();
            foreach (var l in labels) { double bw = BtnW(l, 5, 6); bws.Add(bw); rowW += bw + 3 * Cq; }
            double ovW = G.FW - 8 * Cq, contentW = Math.Max(rowW, Math.Max(UiSvg.BoxWidth(R.Sub, sub), coinsW));
            double w = Math.Min(ovW * 0.60, Math.Max(ovW * 0.46, contentW + 2 * padX + 2 * b)), cw = w - 2 * padX - 2 * b;
            double h = 2 * b + padT + titleH + 2 * Cq + starsH + 1 * Cq + scoreH + 1 * Cq + Lh(sub) + 2.4 * Cq + coinsH + 3.6 * Cq + bh + padB;
            double x = G.FX + (G.FW - w) / 2, y = G.FY + (G.FH - h) / 2;
            double yStars = b + padT + titleH + 2 * Cq, yScore = yStars + starsH + 1 * Cq, ySub = yScore + scoreH + 1 * Cq, yCoins = ySub + Lh(sub) + 2.4 * Cq, yRow = yCoins + coinsH + 3.6 * Cq;
            double rx = b + padX + (cw - rowW) / 2;
            var hitX = new List<double>(); { double xx = rx; foreach (var bw in bws) { hitX.Add(xx); xx += bw + 3 * Cq; } }
            for (int i = 0; i < labels.Count; i++) Hits.Add(("res:" + i, x + hitX[i], y + yRow, bws[i], bh));
            var (k, op_) = PopAt(now);
            // the stars pop in one by one (.45s, delays 0.1 / 0.25 / 0.4 s): the card is drawn again until they're in
            double since = (now - _cardAt) / 1000; int phase = since < 0.1 ? 0 : (int)Math.Min(20, Math.Floor((since - 0.1) / 0.04)) + 1;
            string held = Held != null && Held.StartsWith("res:") ? Held : "";
            string fill = R.Stars >= 3 ? "gold" : "orange";
            o.Add(Svg("res|" + R.Title + R.Stars + R.Score + R.Sub + R.Coins + "|" + phase + held, x, y, w, h, s =>
            {
                s.Box(0, 0, (float)w, (float)h, Card());
                Title(s, R.Title, fill, 8.4, b + padX, b + padT, cw, "rst");
                // the stars: ★ (11cqh), gold with a brown edge when won, pale with a sandy one when not
                var st = T(Fred, 11, "#eadbc6", 1);
                double sw = UiSvg.BoxWidth("★", st), sx = b + padX + (cw - (3 * sw + 4 * Cq)) / 2;
                for (int i = 0; i < 3; i++)
                {
                    double cx = sx + i * (sw + 2 * Cq);
                    bool on = i < R.Stars;
                    var t = T(Fred, 11, on ? "#ffd23a" : "#eadbc6", 1);
                    double a = (on ? 0.45 : 0.4) * Cq;
                    string edge = on ? "#9c4d06" : "#c9b293";
                    t.Shadows = new[] { new Shadow(edge, (float)-a, 0, 0), new Shadow(edge, (float)a, 0, 0), new Shadow(edge, 0, (float)-a, 0), new Shadow(edge, 0, (float)((on ? 0.9 : 0.6) * Cq), 0) };
                    if (on)
                    {
                        double su = Math.Max(0, Math.Min(1, (since - (i * 0.15 + 0.1)) / 0.45)), kk = StarPop(su);
                        if (kk <= 0.001) continue;
                        double mx = cx + sw / 2, my = yStars + starsH / 2;
                        s.Open($"transform=\"translate({F(mx)} {F(my)}) rotate({F(-40 * (1 - kk))}) scale({F(kk)}) translate({F(-mx)} {F(-my)})\"");
                        s.Text("★", (float)cx, (float)yStars, t);
                        s.Close();
                    }
                    else s.Text("★", (float)cx, (float)yStars, t);
                }
                s.Text(R.Score, (float)(b + padX), (float)yScore, T(Fred, 12, "#8a3a0e", 1), (float)cw, 0.5f);
                s.Text(R.Sub, (float)(b + padX), (float)ySub, sub, (float)cw, 0.5f);
                double cx0 = b + padX + (cw - coinsW) / 2;
                s.Raw(CoinSvg(cx0, yCoins, coinS));
                s.Text(R.Coins, (float)(cx0 + coinS + 1.4 * Cq), (float)(yCoins + (coinsH - Lh(ct)) / 2), ct);
                for (int i = 0; i < labels.Count; i++)
                {
                    bool pr = held == "res:" + i; double bx = hitX[i];
                    if (pr) s.Open($"transform=\"translate({F(bx + bws[i] / 2)} {F(yRow + bh / 2)}) scale(0.92) translate({F(-(bx + bws[i] / 2))} {F(-(yRow + bh / 2))})\"");
                    Btn(s, labels[i], bx, yRow, bws[i], bh, 5, i == labels.Count - 1);
                    if (pr) s.Close();
                }
                return s;
            }, 40, op_, About(x + w / 2, y + h / 2, k)));
        }

        /// <summary>The coin on the results' reward row (the app's SquishCoin.coin(0), exported by
        /// tools/unity/house/export-yardgames.mjs): a picture href the caller resolves.</summary>
        public static string CoinHref = "Yard/game/coin";
        static string CoinSvg(double x, double y, double s) => $"<image href=\"{CoinHref}\" x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(s)}\" height=\"{F(s)}\" preserveAspectRatio=\"xMidYMid meet\"/>";

        /// <summary>The control at a screen point (dp), or null.</summary>
        public string Hit(double xdp, double ydp)
        {
            double x = xdp / G.K, y = ydp / G.K;
            for (int i = Hits.Count - 1; i >= 0; i--) { var h = Hits[i]; if (x >= h.x && x <= h.x + h.w && y >= h.y && y <= h.y + h.h) return h.id; }
            return null;
        }
    }
}
