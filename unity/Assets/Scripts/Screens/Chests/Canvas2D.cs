// The canvas 2D calls Chest Smash v2's engine makes (android/app/src/main/assets/chest: chest-models.js), recorded as
// SVG for the Unity vector renderer (UiSvg markup, the screen's dp): paths (lines, quadratic and cubic curves, arcs,
// ellipses), fills and strokes in linear, radial and conic gradients, the transform stack, globalAlpha, clip(),
// shadowBlur (a blurred copy under the stroke or fill), line dashes, text (the fonts' own outlines), and drawImage of a
// layer recorded earlier (an SVG group). A path is kept in the canvas's device space, as canvas keeps it, and drawn back
// in the user space of the fill or stroke (so line widths and gradients are where canvas puts them).
// globalCompositeOperation 'lighter' (additive) wraps the draw in mix-blend-mode: plus-lighter (Vector/SvgScene.cs:
// it adds onto what's under it, as canvas does), and the canvas's markup is then an isolated group (isolation: isolate,
// a layer of its own), so the draws add onto the canvas's own pixels, not onto the page behind it, as a canvas does. Not as canvas: a conic gradient is drawn as 72 thin wedges of its
// colours. The engine does its compositing ('source-atop', 'destination-out') with groups and
// masks itself (ChestEngine.cs).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Screens
{
    /// <summary>A canvas fill or stroke style: a colour, or a gradient.</summary>
    public sealed class CanvasPaint
    {
        public string Color;
        public char Kind;            // 'l', 'r', 'k' (conic)
        public double[] Args;        // l: x0 y0 x1 y1; r: x0 y0 r0 x1 y1 r1; k: angle cx cy
        public List<(double o, string c)> Stops = new List<(double, string)>();
        public static implicit operator CanvasPaint(string c) => new CanvasPaint { Color = c };
        public CanvasPaint Add(double o, string c) { Stops.Add((o, c)); return this; }
    }

    public sealed class Canvas2D
    {
        sealed class St
        {
            public Affine M = Affine.Identity;
            public double Alpha = 1, LineWidth = 1, ShadowBlur;
            public CanvasPaint Fill = "#000", Stroke = "#000";
            public string Join = "miter", Cap = "butt", ShadowColor = "rgba(0,0,0,0)", Comp = "source-over";
            public double[] Dash;
            public List<string> Clips = new List<string>();
            public St Copy() { var s = (St)MemberwiseClone(); s.Clips = new List<string>(Clips); return s; }
        }

        St _s = new St();
        readonly Stack<St> _stack = new Stack<St>();
        readonly StringBuilder _body = new StringBuilder();
        public readonly StringBuilder Defs;
        readonly string _pre;
        static int _n;
        int _ids;
        readonly Dictionary<string, string> _glyphs = new Dictionary<string, string>();
        // the path: subpaths of device-space points (with curves flattened)
        readonly List<List<(double x, double y)>> _sub = new List<List<(double, double)>>();
        readonly List<bool> _closed = new List<bool>();
        List<(double x, double y)> _cur;

        /// <summary>`defs`: shared defs (gradients, clips) of the frame this canvas draws into.</summary>
        public Canvas2D(StringBuilder defs = null) { Defs = defs ?? new StringBuilder(); _pre = "cv" + (_n++) + "-"; }

        bool _lighter;   // a 'lighter' draw was recorded: the markup is isolated
        public string Markup => _lighter ? $"<g style=\"isolation:isolate\">{_body}</g>" : _body.ToString();
        public void Clear() { _lighter = false; _body.Clear(); _sub.Clear(); _closed.Clear(); _cur = null; _s = new St(); _stack.Clear(); }
        string Id(string k) => _pre + k + (_ids++);
        static string F(double v) => UiSvg.F(v);

        // ---- state ---------------------------------------------------------------------------------------------------
        public void Save() => _stack.Push(_s.Copy());
        public void Restore() { if (_stack.Count > 0) _s = _stack.Pop(); }
        public double GlobalAlpha { get => _s.Alpha; set => _s.Alpha = value; }
        public CanvasPaint FillStyle { get => _s.Fill; set => _s.Fill = value; }
        public CanvasPaint StrokeStyle { get => _s.Stroke; set => _s.Stroke = value; }
        public double LineWidth { get => _s.LineWidth; set => _s.LineWidth = value; }
        public string LineJoin { get => _s.Join; set => _s.Join = value; }
        public string LineCap { get => _s.Cap; set => _s.Cap = value; }
        public double ShadowBlur { get => _s.ShadowBlur; set => _s.ShadowBlur = value; }
        public string ShadowColor { get => _s.ShadowColor; set => _s.ShadowColor = value; }
        public string GlobalCompositeOperation { get => _s.Comp; set => _s.Comp = value; }
        public void SetLineDash(double[] d) => _s.Dash = d != null && d.Length > 0 ? d : null;
        public Affine Transform => _s.M;
        public void SetTransform(double a, double b, double c, double d, double e, double f) => _s.M = new Affine(a, b, c, d, e, f);
        public void Translate(double x, double y) => _s.M = _s.M * Affine.Translate(x, y);
        public void Rotate(double a) => _s.M = _s.M * Affine.Rotate(a * 180 / Math.PI);
        public void Scale(double x, double y) => _s.M = _s.M * Affine.ScaleBy(x, y);

        // ---- the path ------------------------------------------------------------------------------------------------
        (double, double) Dev(double x, double y) { var m = _s.M; return (m.A * x + m.C * y + m.E, m.B * x + m.D * y + m.F); }
        public void BeginPath() { _sub.Clear(); _closed.Clear(); _cur = null; }
        public void MoveTo(double x, double y) { _cur = new List<(double, double)> { Dev(x, y) }; _sub.Add(_cur); _closed.Add(false); _ux = x; _uy = y; _sx = x; _sy = y; }
        public void LineTo(double x, double y) { if (_cur == null) { MoveTo(x, y); return; } _cur.Add(Dev(x, y)); _ux = x; _uy = y; }
        double _ux, _uy, _sx, _sy;   // the current point and the subpath's start (user space)
        public void ClosePath()
        {
            if (_cur == null) return;
            _closed[_closed.Count - 1] = true;
            var start = _cur[0];
            _cur = new List<(double, double)> { start };
            _sub.Add(_cur); _closed.Add(false);
            _ux = _sx; _uy = _sy;
        }
        public void QuadraticCurveTo(double cx, double cy, double x, double y)
        {
            double x0 = _ux, y0 = _uy;
            int n = 12;
            for (int i = 1; i <= n; i++) { double t = (double)i / n, u = 1 - t; LineTo(u * u * x0 + 2 * u * t * cx + t * t * x, u * u * y0 + 2 * u * t * cy + t * t * y); }
        }
        public void BezierCurveTo(double c1x, double c1y, double c2x, double c2y, double x, double y)
        {
            double x0 = _ux, y0 = _uy;
            int n = 16;
            for (int i = 1; i <= n; i++)
            {
                double t = (double)i / n, u = 1 - t, a = u * u * u, b = 3 * u * u * t, c = 3 * u * t * t, d = t * t * t;
                LineTo(a * x0 + b * c1x + c * c2x + d * x, a * y0 + b * c1y + c * c2y + d * y);
            }
        }
        public void Arc(double x, double y, double r, double a0, double a1, bool ccw = false) => Ellipse(x, y, r, r, 0, a0, a1, ccw);
        public void Ellipse(double x, double y, double rx, double ry, double rot, double a0, double a1, bool ccw = false)
        {
            const double TAU = Math.PI * 2;
            double sweep = a1 - a0;
            if (!ccw) { if (sweep >= TAU) sweep = TAU; else { sweep %= TAU; if (sweep < 0) sweep += TAU; } }
            else { sweep = a0 - a1; if (sweep >= TAU) sweep = TAU; else { sweep %= TAU; if (sweep < 0) sweep += TAU; } sweep = -sweep; }
            int n = Math.Max(4, (int)Math.Ceiling(Math.Abs(sweep) / TAU * 64));
            double cr = Math.Cos(rot), sr = Math.Sin(rot);
            for (int i = 0; i <= n; i++)
            {
                double a = a0 + sweep * i / n, ex = rx * Math.Cos(a), ey = ry * Math.Sin(a);
                double px = x + ex * cr - ey * sr, py = y + ex * sr + ey * cr;
                if (i == 0 && _cur == null) MoveTo(px, py); else LineTo(px, py);
            }
        }
        public void Rect(double x, double y, double w, double h) { MoveTo(x, y); LineTo(x + w, y); LineTo(x + w, y + h); LineTo(x, y + h); ClosePath(); }

        /// <summary>The path's d in the user space of `m` (device points mapped back).</summary>
        string D(Affine m)
        {
            var inv = m.Inverse();
            var sb = new StringBuilder();
            for (int k = 0; k < _sub.Count; k++)
            {
                var sp = _sub[k];
                if (sp.Count < 2 && !_closed[k]) continue;
                for (int i = 0; i < sp.Count; i++)
                {
                    var (x, y) = sp[i];
                    double ux = inv.A * x + inv.C * y + inv.E, uy = inv.B * x + inv.D * y + inv.F;
                    sb.Append(i == 0 ? 'M' : 'L').Append(F(ux)).Append(' ').Append(F(uy)).Append(' ');
                }
                if (_closed[k]) sb.Append("Z ");
            }
            return sb.ToString();
        }

        // ---- painting ------------------------------------------------------------------------------------------------------
        string M(Affine m) => $"matrix({F(m.A)} {F(m.B)} {F(m.C)} {F(m.D)} {F(m.E)} {F(m.F)})";

        string PaintRef(CanvasPaint p)
        {
            if (p == null) return "none";
            if (p.Color != null) return p.Color;
            if (p.Kind == 'k') return p.Stops.Count > 0 ? p.Stops[0].c : "#000";
            var id = Id("g");
            var stops = new StringBuilder();
            foreach (var (o, c) in p.Stops) stops.Append($"<stop offset=\"{F(Math.Max(0, Math.Min(1, o)))}\" stop-color=\"{c}\"/>");
            var a = p.Args;
            if (p.Kind == 'l') Defs.Append($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"{F(a[0])}\" y1=\"{F(a[1])}\" x2=\"{F(a[2])}\" y2=\"{F(a[3])}\">{stops}</linearGradient>");
            else Defs.Append($"<radialGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" fx=\"{F(a[0])}\" fy=\"{F(a[1])}\" cx=\"{F(a[3])}\" cy=\"{F(a[4])}\" r=\"{F(Math.Max(1e-6, a[5]))}\">{stops}</radialGradient>");
            return $"url(#{id})";
        }

        void Emit(string el)
        {
            var sb = new StringBuilder();
            int open = 0;
            if (_s.Comp == "lighter") { _lighter = true; sb.Append("<g style=\"mix-blend-mode:plus-lighter\">"); open++; }
            foreach (var c in _s.Clips) { sb.Append($"<g clip-path=\"url(#{c})\">"); open++; }
            if (_s.Alpha < 0.999) { sb.Append($"<g opacity=\"{F(Math.Max(0, _s.Alpha))}\">"); open++; }
            sb.Append(el);
            for (int i = 0; i < open; i++) sb.Append("</g>");
            _body.Append(sb);
        }

        string Shadow()
        {
            if (_s.ShadowBlur <= 0 || _s.ShadowColor == null || _s.ShadowColor == "transparent" || _s.ShadowColor == "rgba(0,0,0,0)") return null;
            var id = Id("sh");
            // canvas's shadowBlur is in device pixels, sigma = blur / 2 (the frame's dp: the engine's canvas pixels)
            Defs.Append($"<filter id=\"{id}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\" filterUnits=\"objectBoundingBox\"><feGaussianBlur stdDeviation=\"{F(_s.ShadowBlur / 2 / Math.Max(1e-6, PxPerUnit))}\"/></filter>");
            return id;
        }

        /// <summary>Device pixels per unit of this canvas's device space (the shadow's blur is in device pixels).</summary>
        public double PxPerUnit = 1;

        public void Fill(string rule = "nonzero")
        {
            var m = _s.M;
            string d = D(m);
            if (d.Length == 0) return;
            if (_s.Fill != null && _s.Fill.Kind == 'k') { Conic(m, d, rule); return; }
            string sh = Shadow();
            if (sh != null) Emit($"<g transform=\"{M(m)}\"><path d=\"{d}\" fill=\"{_s.ShadowColor}\" fill-rule=\"{rule}\" filter=\"url(#{sh})\"/></g>");
            Emit($"<g transform=\"{M(m)}\"><path d=\"{d}\" fill=\"{PaintRef(_s.Fill)}\" fill-rule=\"{rule}\"/></g>");
        }

        public void Stroke()
        {
            var m = _s.M;
            string d = D(m);
            if (d.Length == 0) return;
            string dash = _s.Dash != null ? $" stroke-dasharray=\"{string.Join(" ", Array.ConvertAll(_s.Dash, v => F(v)))}\"" : "";
            string attrs = $"fill=\"none\" stroke-width=\"{F(_s.LineWidth)}\" stroke-linejoin=\"{_s.Join}\" stroke-linecap=\"{_s.Cap}\"{dash}";
            string sh = Shadow();
            if (sh != null) Emit($"<g transform=\"{M(m)}\"><path d=\"{d}\" stroke=\"{_s.ShadowColor}\" {attrs} filter=\"url(#{sh})\"/></g>");
            string paint = _s.Stroke != null && _s.Stroke.Kind == 'k' ? (_s.Stroke.Stops.Count > 0 ? _s.Stroke.Stops[_s.Stroke.Stops.Count / 2].c : "#000") : PaintRef(_s.Stroke);
            Emit($"<g transform=\"{M(m)}\"><path d=\"{d}\" stroke=\"{paint}\" {attrs}/></g>");
        }

        public void FillRect(double x, double y, double w, double h) { var save = SavePath(); BeginPath(); Rect(x, y, w, h); Fill(); RestorePath(save); }
        public void StrokeRect(double x, double y, double w, double h) { var save = SavePath(); BeginPath(); Rect(x, y, w, h); Stroke(); RestorePath(save); }
        public void ClearRect() { }

        (List<List<(double, double)>>, List<bool>, List<(double, double)>) SavePath() => (new List<List<(double, double)>>(_sub), new List<bool>(_closed), _cur);
        void RestorePath((List<List<(double, double)>> s, List<bool> c, List<(double, double)> cur) p) { _sub.Clear(); _sub.AddRange(p.s); _closed.Clear(); _closed.AddRange(p.c); _cur = p.cur; }

        public void Clip()
        {
            var id = Id("c");
            Defs.Append($"<clipPath id=\"{id}\" clipPathUnits=\"userSpaceOnUse\"><path d=\"{D(Affine.Identity)}\"/></clipPath>");
            _s.Clips.Add(id);
        }

        /// <summary>A conic gradient (createConicGradient) as 72 wedges of its colours, inside the path.</summary>
        void Conic(Affine m, string d, string rule)
        {
            var p = _s.Fill;
            var id = Id("kc");
            Defs.Append($"<clipPath id=\"{id}\"><path d=\"{d}\" clip-rule=\"{rule}\"/></clipPath>");
            double a0 = p.Args[0], cx = p.Args[1], cy = p.Args[2], R = 2000;
            var sb = new StringBuilder($"<g transform=\"{M(m)}\"><g clip-path=\"url(#{id})\">");
            int n = 72;
            for (int i = 0; i < n; i++)
            {
                double t0 = (double)i / n, t1 = (double)(i + 1) / n;
                double b0 = a0 + t0 * Math.PI * 2 - 0.004, b1 = a0 + t1 * Math.PI * 2 + 0.004;
                string col = ColorAt(p.Stops, (t0 + t1) / 2);
                sb.Append($"<path d=\"M{F(cx)} {F(cy)} L{F(cx + R * Math.Cos(b0))} {F(cy + R * Math.Sin(b0))} L{F(cx + R * Math.Cos(b1))} {F(cy + R * Math.Sin(b1))} Z\" fill=\"{col}\"/>");
            }
            sb.Append("</g></g>");
            Emit(sb.ToString());
        }

        /// <summary>A gradient's colour at t (its stops), as rgba().</summary>
        public static string ColorAt(List<(double o, string c)> stops, double t)
        {
            if (stops.Count == 0) return "#000";
            if (t <= stops[0].o) return stops[0].c;
            for (int i = 1; i < stops.Count; i++)
                if (t <= stops[i].o)
                {
                    double k = (t - stops[i - 1].o) / Math.Max(1e-9, stops[i].o - stops[i - 1].o);
                    var a = Rgba(stops[i - 1].c); var b = Rgba(stops[i].c);
                    return $"rgba({(int)Math.Round(a.r + (b.r - a.r) * k)},{(int)Math.Round(a.g + (b.g - a.g) * k)},{(int)Math.Round(a.b + (b.b - a.b) * k)},{F(a.a + (b.a - a.a) * k)})";
                }
            return stops[stops.Count - 1].c;
        }

        public static (double r, double g, double b, double a) Rgba(string c)
        {
            c = c.Trim();
            if (c.StartsWith("#"))
            {
                var h = c.Substring(1);
                if (h.Length == 3) h = $"{h[0]}{h[0]}{h[1]}{h[1]}{h[2]}{h[2]}";
                int n = int.Parse(h.Substring(0, 6), NumberStyles.HexNumber);
                return (n >> 16, (n >> 8) & 255, n & 255, 1);
            }
            int a0 = c.IndexOf('('), a1 = c.LastIndexOf(')');
            if (a0 < 0) return (0, 0, 0, 1);
            var parts = c.Substring(a0 + 1, a1 - a0 - 1).Split(',');
            double P(int i) => double.Parse(parts[i].Trim(), CultureInfo.InvariantCulture);
            return (P(0), P(1), P(2), parts.Length > 3 ? P(3) : 1);
        }

        // ---- text and pictures ---------------------------------------------------------------------------------------------
        /// <summary>fillText with textAlign 'center' and textBaseline 'middle' / 'alphabetic', in a font of the app's.</summary>
        public void FillText(string text, double x, double y, string font, float size, string baseline = "middle", string align = "center")
        {
            var t = new TextStyle { Font = font, Size = size };
            float w = UiSvg.Width(text, t);
            var f = UiFont.Get(font);
            double k = (double)size / f.UnitsPerEm;
            double by = baseline == "middle" ? y + (f.Ascender * k + f.Descender * k) / 2 : y;
            double bx = align == "center" ? x - w / 2 : x;
            // (the glyphs' outlines go in the frame's defs once per canvas, under this canvas's own ids)
            var defs = new StringBuilder();
            string g = f.Svg(text, (float)bx, (float)by, size, 0, _s.Fill?.Color ?? "#000", defs, _glyphs);
            Defs.Append(defs.ToString().Replace("id=\"gl", $"id=\"{_pre}gl"));
            Emit($"<g transform=\"{M(_s.M)}\">{g.Replace("href=\"#gl", $"href=\"#{_pre}gl")}</g>");
        }

        /// <summary>A layer recorded earlier (its SVG group, by id in the frame's defs: &lt;use&gt;), in the box x, y, w, h of
        /// the current user space, the layer's own units mapped by `layerToBox`.</summary>
        public void DrawLayer(string id, Affine layerToUser, string filter = null)
        {
            var m = _s.M * layerToUser;
            Emit($"<g transform=\"{M(m)}\"{(filter != null ? $" filter=\"url(#{filter})\"" : "")}><use href=\"#{id}\"/></g>");
        }

        /// <summary>Raw SVG in the current user space.</summary>
        public void Raw(string svg) => Emit($"<g transform=\"{M(_s.M)}\">{svg}</g>");
    }
}
