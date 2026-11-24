// Squish Sort's drawings as SVG for UiPiece, copied from the app's components the way the UI exporter
// (tools/unity/ui/snap.js) writes what Chrome painted (UiSvg): boxes as React Native Web lays them out (borders inside
// the box, absolute children from the padding box, overflow: hidden clipping to the padding box's rounded rect),
// expo-linear-gradient's angles, react-native-svg drawings as they are.
//   the fridge or cupboard  src/sort/Container.js: Body (the ring, the face, what's above and below the inside, the
//                           feet), the inside (InsideBack / Lamp / InsideFront: the lamp fades on its own), the clutter
//                           (src/sort/props.js, exported to Resources/Sort/props.json), and each door's front and back
//   the tray, the squishies' marks, the drop spot, the banner, the HUD's left column   src/sort/Game.js
// Units are dp. Pieces are drawn in their own box (top-left 0, 0); SortLevel places them.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;
using static SquishSquad.Games.Sort.SortGeometry;

namespace SquishSquad.Games.Sort
{
    public static class SortArt
    {
        public const string INK = "#5b3418";   // squishdoku/theme.js
        public const string Display = "Fredoka_700Bold", Heavy = "Nunito_800ExtraBold";
        const string HEART_D = "M12 20 C5 14.5 2 11 2 7 C2 4 4.3 2 7 2 C9 2 10.8 3.2 12 5 C13.2 3.2 15 2 17 2 C19.7 2 22 4 22 7 C22 11 19 14.5 12 20 Z";
        const string STAR_D = "M12 2.5 L14.6 8.6 L21.2 9.2 L16.2 13.5 L17.7 20 L12 16.6 L6.3 20 L7.8 13.5 L2.8 9.2 L9.4 8.6 Z";

        static string F(double v) => UiSvg.F(v);

        // ---- React Native Web's boxes --------------------------------------------------------------------------------
        /// <summary>A box in its parent's padding box (pw x ph) from absolute-position style (null: not set); the static
        /// position (sx, sy) when neither side is set.</summary>
        public struct Box
        {
            public float X, Y, W, H;
            public Box(float x, float y, float w, float h) { X = x; Y = y; W = w; H = h; }
        }

        static Box Abs(float pw, float ph, float? l = null, float? t = null, float? r = null, float? b = null, float? w = null, float? h = null, float sx = 0, float sy = 0)
        {
            float bw = w ?? (l.HasValue && r.HasValue ? pw - l.Value - r.Value : 0);
            float bh = h ?? (t.HasValue && b.HasValue ? ph - t.Value - b.Value : 0);
            float x = l ?? (r.HasValue ? pw - r.Value - bw : sx);
            float y = t ?? (b.HasValue ? ph - b.Value - bh : sy);
            return new Box(x, y, bw, bh);
        }

        /// <summary>expo-linear-gradient on the web: the CSS angle for start -> end on a w x h box.</summary>
        static float Angle(float w, float h, float sx, float sy, float ex, float ey) => (float)(90 + Math.Atan2((ey - sy) * h, (ex - sx) * w) * 180 / Math.PI);

        /// <summary>CSS stop positions: a location only where expo-linear-gradient writes one (a truthy one), the rest
        /// filled in as CSS does (first 0, last 1, the ones between evenly spaced).</summary>
        static float[] Stops(int n, float[] loc)
        {
            var p = new float?[n];
            if (loc != null) for (int i = 0; i < n && i < loc.Length; i++) if (loc[i] != 0) p[i] = Math.Max(0, Math.Min(1, loc[i]));
            if (!p[0].HasValue) p[0] = 0;
            if (!p[n - 1].HasValue) p[n - 1] = Math.Max(1, p[0].Value);
            for (int i = 1; i < n; i++) if (p[i].HasValue && p[i] < p[i - 1]) p[i] = p[i - 1];
            for (int i = 1; i < n - 1; i++)
                if (!p[i].HasValue)
                {
                    int j = i; while (!p[j].HasValue) j++;
                    float a = p[i - 1].Value, b = p[j].Value;
                    for (int k = i; k < j; k++) p[k] = a + (b - a) * (k - i + 1) / (j - i + 1);
                }
            var o = new float[n];
            for (int i = 0; i < n; i++) o[i] = p[i].Value;
            return o;
        }

        /// <summary>A LinearGradient filling x, y, w, h: top to bottom, across (start 0,0 end 1,0) or any start / end.</summary>
        static void Grad(UiSvg s, float x, float y, float w, float h, string[] colors, float[] loc = null, float sx = 0, float sy = 0, float ex = 0, float ey = 1, float[] radii = null)
        {
            if (w <= 0 || h <= 0) return;
            s.Box(x, y, w, h, new BoxStyle { Gradient = colors, GradientStops = Stops(colors.Length, loc), GradientAngle = Angle(w, h, sx, sy, ex, ey), Radii = radii ?? new float[4] });
        }
        static void GradAcross(UiSvg s, float x, float y, float w, float h, string[] colors) => Grad(s, x, y, w, h, colors, null, 0, 0, 1, 0);

        static float[] R4(float r) => new[] { r, r, r, r };

        /// <summary>overflow: hidden: what's drawn next is clipped to the padding box of x, y, w, h (radii less the border).</summary>
        static void Clip(UiSvg s, float x, float y, float w, float h, float[] radii, float border)
        {
            var id = s.NewId("sc");
            var inner = new[] { Math.Max(0, radii[0] - border), Math.Max(0, radii[1] - border), Math.Max(0, radii[2] - border), Math.Max(0, radii[3] - border) };
            s.Def($"<clipPath id=\"{id}\"><path d=\"{UiSvg.RRect(x + border, y + border, w - 2 * border, h - 2 * border, inner)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{id})\"");
        }

        static void Fill(UiSvg s, Box b, string color, float radius = 0, float opacity = 1) => s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Background = color, Radius = radius, Opacity = opacity });

        // ---- little things -------------------------------------------------------------------------------------------
        // a bar handle (chrome or brass), upright (its gradient across) or lying down (`flat`); x, y in the parent's
        // coordinates
        static void BarH(UiSvg s, ModelColors c, Box b, bool flat)
        {
            var r = R4(5);
            s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Radius = 5 });
            Clip(s, b.X, b.Y, b.W, b.H, r, 1.5f);
            if (flat) Grad(s, b.X + 1.5f, b.Y + 1.5f, b.W - 3, b.H - 3, c.Handle);
            else GradAcross(s, b.X + 1.5f, b.Y + 1.5f, b.W - 3, b.H - 3, c.Handle);
            s.Close();
            s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Radius = 5, BorderWidth = 1.5f, BorderColor = "#ffffff" });
        }

        static void Knob(UiSvg s, ModelColors c, float x, float y, float size)
        {
            var r = R4(size / 2);
            Clip(s, x, y, size, size, r, 2);
            Grad(s, x + 2, y + 2, size - 4, size - 4, c.Handle);
            s.Close();
            s.Box(x, y, size, size, new BoxStyle { Radius = size / 2, BorderWidth = 2, BorderColor = "#ffffff" });
        }

        // a drawer front with a handle (fridge: a long bar; cupboard: a pull or a knob)
        static void Drawer(UiSvg s, SortModel m, float x, float y, float w, float h, bool knob)
        {
            var c = m.C;
            float rad = m.Kind == "fridge" ? 8 : 4;
            s.Box(x, y, w, h, new BoxStyle { Radius = rad, BorderWidth = 2, BorderColor = c.Trim });
            Clip(s, x, y, w, h, R4(rad), 2);
            float px = x + 2, py = y + 2, pw = w - 4, ph = h - 4;
            Grad(s, px, py, pw, ph, c.Door);
            Fill(s, Abs(pw, ph, l: 6, r: 6, t: 2, h: 3).At(px, py), "rgba(255,255,255,0.55)", 2);
            if (m.Kind == "fridge") BarH(s, c, Abs(pw, ph, l: w * 0.18f, r: w * 0.18f, t: Math.Min(8, h * 0.2f), h: 8).At(px, py), true);
            else if (knob) { float k = Math.Min(14, h * 0.45f); Knob(s, c, px + w / 2 - k / 2 - 2, py + h / 2 - k / 2 - 2, k); }
            else BarH(s, c, Abs(pw, ph, l: w / 2 - Math.Min(22, w * 0.18f), w: Math.Min(44, w * 0.36f), t: h / 2 - 5, h: 7).At(px, py), true);
            s.Close();
            s.Box(x, y, w, h, new BoxStyle { Radius = rad, BorderWidth = 2, BorderColor = c.Trim });
        }

        static Box At(this Box b, float x, float y) => new Box(b.X + x, b.Y + y, b.W, b.H);

        // a kick-plate grille: a dark strip with upright slits
        static void Grille(UiSvg s, float x, float y, float w, float h, string color)
        {
            int n = Math.Max(3, (int)Math.Floor((w - 12) / 9));
            var d = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                double sx = 6 + (w - 12) * (i + 0.5) / n;
                d.Append($"M{JsFixed1(sx)} 3 V{F(h - 3)} ");
            }
            s.Box(x, y, w, h, new BoxStyle { Background = color, Radius = 4 });
            Clip(s, x, y, w, h, R4(4), 0);
            s.Raw($"<g transform=\"translate({F(x)} {F(y)})\"><path d=\"{d}\" stroke=\"rgba(255,255,255,0.28)\" stroke-width=\"2.4\" stroke-linecap=\"round\"/></g>");
            s.Close();
        }

        static string JsFixed1(double v) => (Math.Round(v * 10, MidpointRounding.AwayFromZero) / 10).ToString("0.0", CultureInfo.InvariantCulture);

        // stainless steel's faint brushed lines, in a pw x ph padding box at x, y
        static void Brushed(UiSvg s, float x, float y, float pw, float ph)
        {
            foreach (var f in new[] { 0.22f, 0.47f, 0.78f }) s.Box(x + pw * f, y, 1.5f, ph, new BoxStyle { Background = "rgba(255,255,255,0.32)" });
        }

        static void Led(UiSvg s, float x, float y, string color, float opacity = 1) =>
            s.Box(x, y, 8, 8, new BoxStyle { Background = color, Radius = 4, BorderWidth = 1.5f, BorderColor = "#ffffff", Opacity = opacity });

        static string Svg(float x, float y, float w, float h, string viewBox, string inner, string extra = "") =>
            $"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"{viewBox}\"{extra}>{inner}</svg>";

        static TextStyle T(string font, float size, string color, float ls = 0) => new TextStyle { Font = font, Size = size, Color = color, LetterSpacing = ls };

        // ---- above the inside (in the face's padding box; w the face's width, W x h the inside's width and the room) ----
        static void Top(UiSvg s, SortModel m, float ox, float oy, float w, float W, float h, float up)
        {
            var c = m.C;
            switch (m.TopKind)
            {
                case "icebox":
                {
                    if (m.Radius[0] > 30)
                    {
                        float x = ox + WALL + W * 0.2f, y = oy + (h - up) * 0.45f - 3, bw = W * 0.6f;
                        Clip(s, x, y, bw, 6, R4(4), 1);
                        Grad(s, x + 1, y + 1, bw - 2, 4, c.Handle);
                        s.Close();
                        s.Box(x, y, bw, 6, new BoxStyle { Radius = 4, BorderWidth = 1, BorderColor = "#ffffff" });
                    }
                    float lx = ox + WALL, ly = oy + h - up, lw = W, lh = up + 12;
                    var lr = new[] { 10f, 10, 0, 0 };
                    Clip(s, lx, ly, lw, lh, lr, 0);
                    Grad(s, lx, ly, lw, lh, new[] { c.Inside[0], c.Inside[1] });
                    var ib = Abs(lw, lh, l: lw * 0.08f, r: lw * 0.08f, t: 6, b: 18).At(lx, ly);
                    s.Box(ib.X, ib.Y, ib.W, ib.H, new BoxStyle { Radius = 6, BorderWidth = 2, BorderColor = c.Shelf.Edge });
                    Clip(s, ib.X, ib.Y, ib.W, ib.H, R4(6), 2);
                    float px = ib.X + 2, py = ib.Y + 2, pw = ib.W - 4, ph = ib.H - 4;
                    Grad(s, px, py, pw, ph, new[] { "#f7fbfe", "#d6e6f0", "#b9cfde" });
                    Fill(s, Abs(pw, ph, l: 6, r: 6, t: 4, h: 4).At(px, py), "rgba(255,255,255,0.8)", 2);
                    // the grip: in the flow, at the bottom, centred
                    float gw = pw * 0.28f;
                    s.Box(px + (pw - gw) / 2, py + ph - 4 - 4, gw, 4, new BoxStyle { Background = c.Shelf.Edge, Radius = 2 });
                    s.Close();
                    s.Box(ib.X, ib.Y, ib.W, ib.H, new BoxStyle { Radius = 6, BorderWidth = 2, BorderColor = c.Shelf.Edge });
                    s.Close();
                    break;
                }
                case "band":
                    Led(s, ox + w / 2 - 14, oy + h / 2 - 4, "#5fd4ff");
                    Led(s, ox + w / 2 - 14 + 8 + 6, oy + h / 2 - 4, "#7be884");
                    break;
                case "freezer":
                {
                    float x = ox + WALL, y = oy + 4, pw0 = W, ph0 = h - 8;
                    s.Box(x, y, pw0, ph0, new BoxStyle { Radius = 10, BorderWidth = 2, BorderColor = c.Trim });
                    Clip(s, x, y, pw0, ph0, R4(10), 2);
                    float px = x + 2, py = y + 2, pw = pw0 - 4, ph = ph0 - 4;
                    Grad(s, px, py, pw, ph, c.Door, null, 0, 0, 1, 1);
                    // the shine: no side given, so at its static place, the padding box's left
                    Fill(s, Abs(pw, ph, t: 8, b: 8, w: 5).At(px, py), "rgba(255,255,255,0.6)", 3);
                    bool right = m.Hinge == "left";   // the handle's side
                    float bh = Math.Max(16, (h - 8) * 0.45f);
                    BarH(s, c, Abs(pw, ph, l: right ? (float?)null : 6, r: right ? 6 : (float?)null, b: 6, h: bh, w: 9).At(px, py), false);
                    float fx = m.Hinge == "left" ? px + 12 : px + pw - 12 - 20, fy = py + (h - 8) / 2 - 12;
                    var flake = new StringBuilder();
                    foreach (var a in new[] { 0, 60, 120 }) flake.Append($"<path d=\"M12 2 V22 M12 5 L9.5 3 M12 5 L14.5 3 M12 19 L9.5 21 M12 19 L14.5 21\" stroke=\"#9cc6de\" stroke-width=\"2\" stroke-linecap=\"round\" fill=\"none\" transform=\"rotate({a} 12 12)\"/>");
                    s.Raw(Svg(fx, fy, 20, 20, "0 0 24 24", flake.ToString()));
                    s.Close();
                    s.Box(x, y, pw0, ph0, new BoxStyle { Radius = 10, BorderWidth = 2, BorderColor = c.Trim });
                    break;
                }
                case "header":
                {
                    float x = ox + WALL - 2, y = oy + 4, hw = W + 4, hh = h - 8;
                    s.Box(x, y, hw, hh, new BoxStyle { Background = c.Dark, Radius = 6, BorderWidth = 1.5f, BorderColor = "rgba(255,255,255,0.35)" });
                    // a row: the thermometer at the left, the vents at the right, centred up and down (padding 8)
                    var lt = T(Display, 11, "#ff5a4a", 0.5f);
                    float tw = UiSvg.BoxWidth("3°C", lt), lh = UiSvg.LineBox(lt);
                    float lw = tw + 12 + 2, lhh = lh + 2 + 2;
                    float ix = x + 1.5f + 8, iy = y + 1.5f, ih = hh - 3;
                    float ly = iy + (ih - lhh) / 2;
                    s.Box(ix, ly, lw, lhh, new BoxStyle { Background = "#0d1114", Radius = 4, BorderWidth = 1, BorderColor = "#56616c" });
                    s.Text("3°C", ix + 1 + 6, ly + 1 + 1, lt);
                    float vw = Math.Min(90, W * 0.32f), vh = 4 * 2.5f + 3 * 3;
                    float vx = x + hw - 1.5f - 8 - vw, vy = iy + (ih - vh) / 2;
                    for (int i = 0; i < 4; i++) s.Box(vx, vy + i * 5.5f, vw, 2.5f, new BoxStyle { Background = "rgba(255,255,255,0.35)", Radius = 2 });
                    break;
                }
                case "drawer":
                    Drawer(s, m, ox + WALL, oy + 5, W, h - 9, true);
                    break;
                case "cornice":
                    s.Box(ox, oy, w, h * 0.42f, new BoxStyle { Background = c.Trim });
                    s.Box(ox + 4, oy + h * 0.42f, w - 8, h * 0.22f, new BoxStyle { Background = c.Ring, Opacity = 0.35f });
                    break;
                case "star":
                {
                    float x = ox + WALL - 2, y = oy + 4, pw0 = W + 4, ph0 = h - 8;
                    s.Box(x, y, pw0, ph0, new BoxStyle { Radius = 12, BorderWidth = 2, BorderColor = c.Trim });
                    Clip(s, x, y, pw0, ph0, R4(12), 2);
                    float px = x + 2, py = y + 2, pw = pw0 - 4, ph = ph0 - 4;
                    Grad(s, px, py, pw, ph, new[] { c.Body[0], c.Body[1] });
                    Fill(s, Abs(pw, ph, l: 8, r: 8, t: 3, h: ph * 0.35f).At(px, py), "rgba(255,255,255,0.55)", 8);
                    var cv = Abs(pw, ph, l: 10, r: 10, t: 6, b: 6).At(px, py);
                    s.Box(cv.X, cv.Y, cv.W, cv.H, new BoxStyle { Radius = 10, BorderWidth = 2, BorderColor = c.Trim, Opacity = 0.35f });
                    s.Raw(Svg(px + (pw - 30) / 2, py + (ph - 30) / 2, 30, 30, "0 0 24 24", $"<path d=\"{STAR_D}\" fill=\"#ffd23a\" stroke=\"#ffffff\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/>"));
                    s.Close();
                    s.Box(x, y, pw0, ph0, new BoxStyle { Radius = 12, BorderWidth = 2, BorderColor = c.Trim });
                    break;
                }
                case "arch":
                {
                    var d = $"M4 {F(h - 3)} V{F(h * 0.62)} Q{F(w / 2)} {F(-h * 0.35)} {F(w - 4)} {F(h * 0.62)} V{F(h - 3)} Z";
                    var inner = $"<path d=\"{d}\" fill=\"{c.Door[1]}\" stroke=\"{c.Trim}\" stroke-width=\"2\"/>" +
                                $"<path d=\"M{F(w * 0.18)} {F(h * 0.78)} Q{F(w / 2)} {F(h * 0.05)} {F(w * 0.82)} {F(h * 0.78)}\" stroke=\"{c.Trim}\" stroke-width=\"1.6\" fill=\"none\" opacity=\"0.7\"/>" +
                                $"<circle cx=\"{F(w / 2)}\" cy=\"{F(h * 0.5)}\" r=\"{F(Math.Min(9, h * 0.18))}\" fill=\"{c.Trim}\" stroke=\"{c.Dark}\" stroke-width=\"1.4\"/>" +
                                $"<circle cx=\"{F(w / 2)}\" cy=\"{F(h * 0.5)}\" r=\"{F(Math.Min(4, h * 0.08))}\" fill=\"{c.Dark}\" opacity=\"0.5\"/>";
                    s.Raw(Svg(ox, oy, w, h, $"0 0 {F(w)} {F(h)}", inner));
                    break;
                }
                case "cabinets":
                    Drawer(s, m, ox + WALL, oy + 4, W / 2 - 2, h - 8, true);
                    Drawer(s, m, ox + WALL + W / 2 + 2, oy + 4, W / 2 - 2, h - 8, true);
                    break;
                default:
                    // 'lip': the door's top seam
                    s.Box(ox + WALL, oy + h - 3, W, 2, new BoxStyle { Background = "rgba(0,0,0,0.1)", Radius = 1 });
                    break;
            }
        }

        // ---- below the inside (y: its top in the face's padding box) -------------------------------------------------
        static void Bottom(UiSvg s, SortModel m, float ox, float oy, float fw, float W, float y, float h)
        {
            var c = m.C;
            switch (m.BottomKind)
            {
                case "grille": Grille(s, ox + WALL + 2, oy + y + 3, W - 4, h - 6, c.Dark); break;
                case "kick": Grille(s, ox + WALL + 6, oy + y + 3, W - 12, h - 6, c.Trim); break;
                case "chrome":
                {
                    float x = ox + WALL, yy = oy + y + 3, hh = h - 6;
                    Clip(s, x, yy, W, hh, R4(4), 1);
                    Grad(s, x + 1, yy + 1, W - 2, hh - 2, c.Handle);
                    s.Close();
                    s.Box(x, yy, W, hh, new BoxStyle { Radius = 4, BorderWidth = 1, BorderColor = "#ffffff" });
                    break;
                }
                case "drawer":
                    Drawer(s, m, ox + WALL, oy + y + 4, W, h - 16, false);
                    Grille(s, ox + WALL + 8, oy + y + h - 10, W - 16, 8, c.Dark);
                    break;
                case "drawers":
                    Drawer(s, m, ox + WALL, oy + y + 4, W / 2 - 2, h - 16, false);
                    Drawer(s, m, ox + WALL + W / 2 + 2, oy + y + 4, W / 2 - 2, h - 16, false);
                    Grille(s, ox + WALL + 8, oy + y + h - 10, W - 16, 8, c.Dark);
                    break;
                case "drawer1": Drawer(s, m, ox + WALL, oy + y + 4, W, h - 8, false); break;
                case "drawers2":
                    Drawer(s, m, ox + WALL, oy + y + 4, W / 2 - 2, h - 8, false);
                    Drawer(s, m, ox + WALL + W / 2 + 2, oy + y + 4, W / 2 - 2, h - 8, false);
                    break;
                case "drawersRow":
                    for (int k = 0; k < 3; k++) Drawer(s, m, ox + WALL + k * (W + 4) / 3, oy + y + 4, (W + 4) / 3 - 4, h - 14, true);
                    s.Box(ox, oy + y + h - 7, fw, 7, new BoxStyle { Background = c.Ring });
                    break;
                case "skirt":
                {
                    float sw = W + 2 * WALL;
                    var d = $"M0 0 H{F(sw)} V{F(h * 0.45)} Q{F(sw * 0.75)} {F(h)} {F(sw / 2)} {F(h * 0.55)} Q{F(sw * 0.25)} {F(h)} 0 {F(h * 0.45)} Z";
                    s.Raw(Svg(ox, oy + y, sw, h, $"0 0 {F(sw)} {F(h)}", $"<path d=\"{d}\" fill=\"{c.Door[2]}\" stroke=\"{c.Trim}\" stroke-width=\"1.6\"/>"));
                    break;
                }
                case "plinth": s.Box(ox, oy + y + 3, fw, h - 3, new BoxStyle { Background = c.Ring, Opacity = 0.55f }); break;
                default: s.Box(ox, oy + y + 2, fw, h - 2, new BoxStyle { Background = "rgba(0,0,0,0.12)" }); break;   // 'base'
            }
        }

        // ---- what it stands on (w x h, its top 6 dp up into the body) ---------------------------------------------------
        static string FeetShapes(SortModel m, float w, float h)
        {
            var c = m.C;
            var at = new[] { w * 0.13f, w * 0.87f };
            var sb = new StringBuilder();
            switch (m.FeetKind)
            {
                case "legs":
                    for (int i = 0; i < 2; i++)
                    {
                        float x = at[i], sg = i == 1 ? 1 : -1;
                        sb.Append($"<path d=\"M{F(x - 6)} 0 H{F(x + 6)} L{F(x + 3 + sg * 5)} {F(h)} H{F(x - 3 + sg * 5)} Z\" fill=\"#c9d0d7\" stroke=\"#7d8894\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/>");
                    }
                    break;
                case "casters":
                    foreach (var x in new[] { w * 0.1f, w * 0.5f, w * 0.9f })
                        sb.Append($"<rect x=\"{F(x - 7)}\" y=\"0\" width=\"14\" height=\"{F(h * 0.45)}\" rx=\"2\" fill=\"#4c5560\"/><circle cx=\"{F(x)}\" cy=\"{F(h - 6)}\" r=\"6\" fill=\"#22282e\"/><circle cx=\"{F(x)}\" cy=\"{F(h - 6)}\" r=\"2.2\" fill=\"#9aa5b1\"/>");
                    break;
                case "tapered":
                    foreach (var x in at) sb.Append($"<path d=\"M{F(x - 7)} 0 H{F(x + 7)} L{F(x + 3)} {F(h)} H{F(x - 3)} Z\" fill=\"{c.Feet}\"/>");
                    break;
                case "balls":
                    foreach (var x in at) sb.Append($"<circle cx=\"{F(x)}\" cy=\"{F(h / 2 + 1)}\" r=\"{F(h / 2 - 1)}\" fill=\"{c.Feet}\"/>");
                    break;
                case "buns":
                    foreach (var x in at) sb.Append($"<ellipse cx=\"{F(x)}\" cy=\"{F(h / 2 + 1)}\" rx=\"15\" ry=\"{F(h / 2 - 1)}\" fill=\"{c.Feet}\"/>");
                    break;
                case "bracket":
                    sb.Append($"<path d=\"M3 0 H32 Q20 2 14 {F(h)} H3 Z\" fill=\"{c.Feet}\"/>");
                    sb.Append($"<path d=\"M{F(w - 3)} 0 H{F(w - 32)} Q{F(w - 20)} 2 {F(w - 14)} {F(h)} H{F(w - 3)} Z\" fill=\"{c.Feet}\"/>");
                    break;
                default:
                    foreach (var x in at) sb.Append($"<rect x=\"{F(x - 8)}\" y=\"0\" width=\"16\" height=\"{F(h)}\" rx=\"4\" fill=\"{c.Feet}\"/>");
                    break;
            }
            return sb.ToString();
        }

        /// <summary>The body: the feet, the ring with its lip, the white-bordered face with what's above and below the
        /// inside. bodyW x (bodyH + feet).</summary>
        public static string Body(SortModel m, ContainerGeo g)
        {
            var c = m.C;
            float rt = m.Radius[0], rb = m.Radius[1];
            var s = new UiSvg(g.BodyW, g.BodyH + g.Feet);
            if (g.Feet > 0) s.Raw(Svg(0, g.BodyH - 6, g.BodyW, g.Feet + 6, $"0 0 {F(g.BodyW)} {F(g.Feet + 6)}", FeetShapes(m, g.BodyW, g.Feet + 6)));
            s.Box(0, 0, g.BodyW, g.BodyH, new BoxStyle { Background = c.Ring, Radii = new[] { rt, rt, rb, rb } });
            float fx = RING, fy = RING, fw = g.BodyW - 2 * RING, fh = g.BodyH - 2 * RING - LIP;
            var fr = new[] { Math.Max(2, rt - RING), Math.Max(2, rt - RING), Math.Max(2, rb - RING), Math.Max(2, rb - RING) };
            s.Box(fx, fy, fw, fh, new BoxStyle { Radii = fr, BorderWidth = BORDER, BorderColor = "#ffffff" });
            Clip(s, fx, fy, fw, fh, fr, BORDER);
            float px = fx + BORDER, py = fy + BORDER, pw = fw - 2 * BORDER, ph = fh - 2 * BORDER;
            Grad(s, px, py, pw, ph, c.Body, null, 0, 0, 1, 1);
            if (m.Has("brushed")) Brushed(s, px, py, pw, ph);
            s.Box(px + 3, py + 10, 5, ph - 20, new BoxStyle { Background = "rgba(255,255,255,0.5)", Radius = 3 });
            Top(s, m, px, py, pw, g.W, g.Top, g.Up);
            Bottom(s, m, px, py, pw, g.W, g.Top + g.H + g.Crisper, g.Bottom);
            s.Close();
            s.Box(fx, fy, fw, fh, new BoxStyle { Radii = fr, BorderWidth = BORDER, BorderColor = "#ffffff" });
            return s.Markup;
        }

        // ---- the inside (W x (H + crisper), at INSET, RING + BORDER + top in the body) ----------------------------------
        public static float InsideX => INSET;
        public static float InsideY(ContainerGeo g) => RING + BORDER + g.Top;
        static float[] InsideRadii(SortModel m) => R4(m.Kind == "fridge" ? 10 : 4);

        /// <summary>The inside's back: its gradient, the vents or the planks, the rail.</summary>
        public static string InsideBack(SortModel m, ContainerGeo g)
        {
            var c = m.C;
            float W = g.W, hd = g.H + g.Crisper;
            var s = new UiSvg(W, hd);
            Clip(s, 0, 0, W, hd, InsideRadii(m), 0);
            Grad(s, 0, 0, W, hd, c.Inside, new[] { 0, 0.55f, 1 });
            if (m.Kind == "fridge")
                for (int i = 0; i < 2; i++) s.Box(W / 2 - 16, 8 + i * 6, 32, 3, new BoxStyle { Background = "rgba(80,120,150,0.22)", Radius = 2 });
            else
                for (int k = 0; k < g.Cols; k++) s.Box((k + 0.5f) * g.S - 1, 0, 2, hd, new BoxStyle { Background = "rgba(120,70,20,0.16)" });
            if (m.Has("rail"))
            {
                Clip(s, 4, 4, W - 8, 5, R4(3), 0);
                Grad(s, 4, 4, W - 8, 5, new[] { "#ffffff", "#c9d0d7", "#8995a2" });
                s.Close();
            }
            s.Close();
            return s.Markup;
        }

        /// <summary>The lamp's glow (its opacity is the game's `light`).</summary>
        public static string Lamp(SortModel m, ContainerGeo g)
        {
            var c = m.C;
            bool fridge = m.Kind == "fridge";
            float W = g.W, hd = g.H + g.Crisper;
            var s = new UiSvg(W, hd);
            Clip(s, 0, 0, W, hd, InsideRadii(m), 0);
            s.Def($"<radialGradient id=\"lamp\" cx=\"50%\" cy=\"0%\" r=\"75%\"><stop offset=\"0\" stop-color=\"{c.Lamp}\" stop-opacity=\"{(fridge ? "0.95" : "0.8")}\"/><stop offset=\"0.5\" stop-color=\"{c.Lamp}\" stop-opacity=\"{(fridge ? "0.35" : "0.25")}\"/><stop offset=\"1\" stop-color=\"{c.Lamp}\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<rect x=\"0\" y=\"0\" width=\"{F(W)}\" height=\"{F(hd)}\" fill=\"url(#lamp)\"/>");
            if (fridge) s.Raw($"<ellipse cx=\"{F(W / 2)}\" cy=\"3\" rx=\"{F(Math.Min(28, W * 0.12))}\" ry=\"4\" fill=\"#ffffff\"/>");
            s.Close();
            return s.Markup;
        }

        /// <summary>The shelves (glass, wire or wood) and the salad drawers.</summary>
        public static string InsideFront(SortModel m, ContainerGeo g)
        {
            var c = m.C;
            float W = g.W, H = g.H, cr = g.Crisper, hd = H + cr, S = g.S;
            var s = new UiSvg(W, hd);
            Clip(s, 0, 0, W, hd, InsideRadii(m), 0);
            var wire = new StringBuilder();
            for (int r = 0; r < g.Rows; r++)
            {
                float y = (r + 1) * (S + SHELF) - SHELF;
                s.Box(0, y, W, 3, new BoxStyle { Background = c.Shelf.Top });
                s.Box(0, y + 3, W, 5, new BoxStyle { Background = c.Shelf.Face, Borders = new[] { 0f, 0, 2, 0 }, BorderColor = c.Shelf.Edge });
                if (c.Shelf.Wire) for (float x = 5; x < W; x += 9) wire.Append($"M{F(x)} {F(y + 3)} V{F(y + SHELF - 1)} ");
            }
            if (wire.Length > 0) s.Raw($"<path d=\"{wire}\" stroke=\"{c.Shelf.Edge}\" stroke-width=\"1.2\" opacity=\"0.7\"/>");
            if (cr > 0)
                for (int k = 0; k < 2; k++)
                {
                    float x = k == 1 ? W / 2 + 2 : 4, y = H + 2, w = W / 2 - 6, h = cr - 6;
                    s.Box(x, y, w, h, new BoxStyle { Background = "rgba(255,255,255,0.25)", Radius = 6, BorderWidth = 2, BorderColor = c.Shelf.Edge });
                    Clip(s, x, y, w, h, R4(6), 2);
                    float px = x + 2, py = y + 2, pw = w - 4, ph = h - 4;
                    float v1w = cr * 0.55f, v1h = cr * 0.5f, v2w = cr * 0.45f, v2h = cr * 0.45f;
                    s.Box(px + pw * 0.12f, py + ph + 3 - v1h, v1w, v1h, new BoxStyle { Background = k == 1 ? "#ff9a3d" : "#7be884", Radius = 999 });
                    s.Box(px + pw * 0.48f, py + ph + 3 - v2h, v2w, v2h, new BoxStyle { Background = k == 1 ? "#ff5a4a" : "#3ddc97", Radius = 999 });
                    s.Box(px, py, pw, ph, new BoxStyle { Background = "rgba(225,242,252,0.55)" });
                    s.Box(px + (pw - pw * 0.3f) / 2, py + 4, pw * 0.3f, 4, new BoxStyle { Background = "rgba(80,120,150,0.3)", Radius = 2 });
                    s.Close();
                    s.Box(x, y, w, h, new BoxStyle { Radius = 6, BorderWidth = 2, BorderColor = c.Shelf.Edge });
                }
            s.Close();
            return s.Markup;
        }

        /// <summary>The clutter on the shelves (slot -> kind), `q` dp each, tilted, in the inside's box; clipped by it.</summary>
        public static string Clutter(SortModel m, ContainerGeo g, IEnumerable<KeyValuePair<int, int>> food, float q, IList<string> props)
        {
            float W = g.W, hd = g.H + g.Crisper, S = g.S;
            var s = new UiSvg(W, hd);
            Clip(s, 0, 0, W, hd, InsideRadii(m), 0);
            foreach (var kv in food)
            {
                int i = kv.Key;
                int tilt = ((i * 37) % 13) - 6;
                float dx = (((i * 53) % 9) - 4) * (S / 90f);
                float x = (i % g.Cols) * S + (S - q) / 2 + dx, y = (i / g.Cols) * (S + SHELF) + S - q;
                s.Raw($"<g transform=\"rotate({tilt} {F(x + q / 2)} {F(y + q / 2)})\">{Svg(x, y, q, q, "0 0 64 64", props[kv.Value % props.Count])}</g>");
            }
            s.Close();
            return s.Markup;
        }

        // ---- the doors --------------------------------------------------------------------------------------------------
        static float DoorRadius(SortModel m) => m.Kind == "fridge" ? Math.Min(10, m.Radius[1]) : Math.Min(8, m.Radius[1]);

        // its handle, by the edge away from the hinge; in the door face's padding box (px, py, pw x ph), w x h the door
        static void Handle(UiSvg s, SortModel m, bool freeRight, float px, float py, float pw, float ph, float w, float h)
        {
            var c = m.C;
            Box Side(float off, float top, float bw, float bh) => new Box(freeRight ? px + pw - off - bw : px + off, py + top, bw, bh);
            switch (m.Handle)
            {
                case "recess":
                {
                    var b = Side(4, h * 0.1f, 8, Math.Max(20, h * 0.5f));
                    s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Background = c.Trim, Radius = 4 });
                    Clip(s, b.X, b.Y, b.W, b.H, R4(4), 0);
                    s.Box(b.X, b.Y, 3, b.H, new BoxStyle { Background = "rgba(0,0,0,0.18)" });
                    s.Close();
                    break;
                }
                case "lever":
                {
                    float lw = Math.Min(46, w * 0.32f);
                    BarH(s, c, Side(8, h * 0.34f, lw, 11), true);
                    var k = Side(4, h * 0.34f - 3, 17, 17);
                    Knob(s, c, k.X, k.Y, 17);
                    break;
                }
                case "pocket": BarH(s, c, Side(6, Math.Max(6, h * 0.05f), 9, Math.Max(22, h * 0.26f)), false); break;
                case "bar":
                case "long":
                {
                    bool lng = m.Handle == "long";
                    float y0 = h * (lng ? 0.16f : 0.12f), y1 = h * (lng ? 0.62f : 0.66f);
                    var sh = Side(5, y0 + 2, 9, y1 - y0);
                    s.Box(sh.X, sh.Y, sh.W, sh.H, new BoxStyle { Background = "rgba(0,0,0,0.16)", Radius = 5 });
                    BarH(s, c, Side(7, y0, lng ? 11 : 9, y1 - y0), false);
                    break;
                }
                case "pull": BarH(s, c, Side(8, h * 0.42f, 7, Math.Max(18, h * 0.16f)), false); break;
                default:
                {
                    var k = Side(8, h / 2 - 8, 16, 16);
                    Knob(s, c, k.X, k.Y, 16);
                    break;
                }
            }
        }

        static void Inset(UiSvg s, SortModel m, float px, float py, float pw, float top, float bottomOrH, bool isHeight, float opacity, float ph)
        {
            float h = isHeight ? bottomOrH : ph - top - bottomOrH;
            s.Box(px + 8, py + top, pw - 16, h, new BoxStyle { Radius = 4, BorderWidth = 2, BorderColor = m.C.Trim, Opacity = opacity });
        }

        // what's on the door: `i` which door (0 the left one or the only one)
        static void Deco(UiSvg s, SortModel m, int i, string hinge, float px, float py, float pw, float ph, float w, float h)
        {
            var c = m.C;
            bool hingeLeft = hinge == "left";
            float HX(float off, float bw) => hingeLeft ? px + off : px + pw - off - bw;   // from the hinge's edge
            float FX(float off, float bw) => hingeLeft ? px + pw - off - bw : px + off;   // from the free edge
            foreach (var d in m.Deco)
            {
                switch (d)
                {
                    case "brushed": Brushed(s, px, py, pw, ph); break;
                    case "note":
                    {
                        float nw = Math.Min(Math.Min(46, w * 0.3f), h * 0.55f), nh = nw * 1.1f;
                        float x = HX(w * 0.2f, nw), y = py + Math.Max(8, h * 0.16f);
                        s.Open($"transform=\"rotate(-6 {F(x + nw / 2)} {F(y + nh / 2)})\"");
                        s.Box(x, y, nw, nh, new BoxStyle { Background = "#fffdf2", Radius = 2, BorderWidth = 1, BorderColor = "rgba(0,0,0,0.08)" });
                        float ix = x + 1, iy = y + 1, iw = nw - 2;
                        s.Box(ix + iw * 0.18f, iy + nw * 0.42f, iw - 2 * iw * 0.18f, 1.5f, new BoxStyle { Background = "rgba(95,184,255,0.7)" });
                        s.Box(ix + iw * 0.18f, iy + nw * 0.62f, iw - iw * 0.18f - nw * 0.3f, 1.5f, new BoxStyle { Background = "rgba(95,184,255,0.7)" });
                        s.Raw(Svg(ix + iw * 0.35f, iy - 6, 14, 13, "0 0 24 22", $"<path d=\"{HEART_D}\" fill=\"#ff6fae\" stroke=\"#ffffff\" stroke-width=\"2.4\"/>"));
                        s.Close();
                        break;
                    }
                    case "magnets":
                    {
                        float nw = Math.Min(54, w * 0.3f), nh = nw * 0.82f;
                        float x = HX(w * 0.16f, nw), y = py + h * 0.14f;
                        s.Open($"transform=\"rotate(5 {F(x + nw / 2)} {F(y + nh / 2)})\"");
                        s.Box(x, y, nw, nh, new BoxStyle { Background = "#fffdf2", Radius = 2, BorderWidth = 1, BorderColor = "rgba(0,0,0,0.08)" });
                        float ix = x + 1, iy = y + 1, iw = nw - 2;
                        s.Raw(Svg(ix, iy, nw, nh, "0 0 30 24",
                            "<circle cx=\"15\" cy=\"13\" r=\"7\" fill=\"none\" stroke=\"#ff8a3d\" stroke-width=\"1.8\"/><circle cx=\"12.5\" cy=\"11.5\" r=\"1.1\" fill=\"#45107a\"/><circle cx=\"17.5\" cy=\"11.5\" r=\"1.1\" fill=\"#45107a\"/>" +
                            "<path d=\"M12 15 Q15 18 18 15\" stroke=\"#45107a\" stroke-width=\"1.4\" fill=\"none\" stroke-linecap=\"round\"/>"));
                        s.Box(ix + iw * 0.42f, iy - 5, 10, 10, new BoxStyle { Background = "#5fb8ff", Radius = 5, BorderWidth = 1.5f, BorderColor = "#ffffff" });
                        s.Close();
                        s.Raw(Svg(FX(22, 20), py + h * 0.58f, 20, 20, "0 0 24 24", $"<path d=\"{STAR_D}\" fill=\"#ffd23a\" stroke=\"#ffffff\" stroke-width=\"2\" stroke-linejoin=\"round\"/>"));
                        break;
                    }
                    case "badge":
                    {
                        float bw = Math.Min(70, w * 0.44f), x = px + w / 2 - bw / 2, y = py + Math.Max(8, h * 0.08f);
                        Clip(s, x, y, bw, 16, R4(8), 1);
                        Grad(s, x + 1, y + 1, bw - 2, 14, c.Handle);
                        s.Close();
                        s.Box(x, y, bw, 16, new BoxStyle { Radius = 8, BorderWidth = 1, BorderColor = "#ffffff" });
                        var bt = T(Display, 9, "#5b6670", 1.2f);
                        float lh = UiSvg.LineBox(bt);
                        Clip(s, x, y, bw, 16, R4(8), 1);
                        s.Text("SQUISHY", x + 1, y + 1 + (14 - lh) / 2, bt, bw - 2, 0.5f);
                        s.Close();
                        break;
                    }
                    case "dispenser":
                    {
                        if (i != 0) break;
                        float dh = Math.Min(h * 0.3f, w * 0.85f), x = px + w * 0.2f, y = py + h * 0.14f, dw = w * 0.6f;
                        s.Box(x, y, dw, dh, new BoxStyle { Background = "#161c22", Radius = 8, BorderWidth = 2, BorderColor = "#9aa5b1" });
                        Clip(s, x, y, dw, dh, R4(8), 2);
                        float ipw = dw - 4, ix = x + 2, iy = y + 2 + 5, ih = dh - 4 - 10;
                        float lever = dh * 0.36f, free = ih - 8 - lever - 4, gap = free / 2;
                        // the leds (a row, 8 + 4 + 8), the lever, the tray; spaced between, centred across
                        float lx = ix + (ipw - 20) / 2;
                        Led(s, lx, iy, "#5fd4ff");
                        Led(s, lx + 12, iy, "#5fd4ff", 0.5f);
                        float lvw = ipw * 0.34f;
                        s.Box(ix + (ipw - lvw) / 2, iy + 8 + gap, lvw, lever, new BoxStyle { Background = "#56616c", Radius = 4 });
                        float tw = ipw * 0.76f;
                        s.Box(ix + (ipw - tw) / 2, iy + 8 + gap + lever + gap, tw, 4, new BoxStyle { Background = "#56616c", Radius = 2 });
                        s.Close();
                        s.Box(x, y, dw, dh, new BoxStyle { Radius = 8, BorderWidth = 2, BorderColor = "#9aa5b1" });
                        break;
                    }
                    case "display":
                    {
                        if (i != 1) break;
                        float x = px + w * 0.25f, y = py + h * 0.16f, dw = w * 0.5f;
                        s.Box(x, y, dw, 20, new BoxStyle { Background = "#161c22", Radius = 5, BorderWidth = 1.5f, BorderColor = "#9aa5b1" });
                        var dt = T(Display, 11, "#5fd4ff");
                        float tw = UiSvg.BoxWidth("3°", dt), lh = UiSvg.LineBox(dt);
                        float total = tw + 4 + 11, cx = x + 1.5f + (dw - 3 - total) / 2, iy = y + 1.5f, ih = 17;
                        s.Text("3°", cx, iy + (ih - lh) / 2, dt);
                        s.Raw(Svg(cx + tw + 4, iy + (ih - 11) / 2, 11, 11, "0 0 24 24", $"<path d=\"{HEART_D}\" fill=\"#5fd4ff\"/>"));
                        break;
                    }
                    case "lock":
                    {
                        if (i != 0) break;
                        float x = FX(7, 12), y = py + h * 0.68f;
                        s.Box(x, y, 12, 12, new BoxStyle { Background = "#c9d0d7", Radius = 6, BorderWidth = 1.5f, BorderColor = "#56616c" });
                        s.Box(x + 6 - 0.9f, y + 6 - 3, 1.8f, 6, new BoxStyle { Background = "#56616c" });
                        break;
                    }
                    case "panel": Inset(s, m, px, py, pw, 10, 10, false, 0.45f, ph); break;
                    case "panel2":
                        Inset(s, m, px, py, pw, 10, h * 0.56f - 14, true, 0.45f, ph);
                        Inset(s, m, px, py, pw, h * 0.56f + 4, 10, false, 0.45f, ph);
                        break;
                    case "mirror":
                        if (i == 0)
                        {
                            Inset(s, m, px, py, pw, 10, h * 0.56f - 14, true, 0.45f, ph);
                            Inset(s, m, px, py, pw, h * 0.56f + 4, 10, false, 0.45f, ph);
                        }
                        else
                        {
                            float x = px + 8, y = py + 10, mw = pw - 16, mh = ph - 20;
                            s.Box(x, y, mw, mh, new BoxStyle { Radius = 4, BorderWidth = 2, BorderColor = c.Trim });
                            Clip(s, x, y, mw, mh, R4(4), 2);
                            float ix = x + 2, iy = y + 2, iw = mw - 4, ih = mh - 4;
                            Grad(s, ix, iy, iw, ih, new[] { "#f4fbff", "#c6e2f5", "#9cc4e4" }, null, 0, 0, 1, 1);
                            foreach (var (l, t, sw) in new[] { (0.18f, 0.08f, 14f), (0.48f, 0.3f, 8f) })
                            {
                                float sx = ix + iw * l, sy = iy + ih * t, shh = ih * 1.4f;
                                s.Open($"transform=\"rotate(28 {F(sx + sw / 2)} {F(sy + shh / 2)})\"");
                                s.Box(sx, sy, sw, shh, new BoxStyle { Background = "rgba(255,255,255,0.45)" });
                                s.Close();
                            }
                            s.Close();
                            s.Box(x, y, mw, mh, new BoxStyle { Radius = 4, BorderWidth = 2, BorderColor = c.Trim });
                        }
                        break;
                    case "cutouts":
                        Inset(s, m, px, py, pw, 10, 10, false, 0.45f, ph);
                        s.Raw(Svg(px + w / 2 - 9, py + 16, 18, 16, "0 0 24 22", $"<path d=\"{(i == 1 ? STAR_D : HEART_D)}\" fill=\"{c.Trim}\" opacity=\"0.5\"/>"));
                        break;
                    case "arched":
                    {
                        const float p = 9;
                        float r = Math.Min(w * 0.3f, h * 0.2f);
                        s.Raw(Svg(px, py, w, h, $"0 0 {F(w)} {F(h)}",
                            $"<path d=\"M{F(p)} {F(h - p)} V{F(p + r)} Q{F(w / 2)} {F(p - r * 0.55)} {F(w - p)} {F(p + r)} V{F(h - p)} Z\" fill=\"rgba(0,0,0,0.07)\" stroke=\"{c.Trim}\" stroke-width=\"2\" opacity=\"0.85\"/>" +
                            $"<circle cx=\"{F(w / 2)}\" cy=\"{F(p + r * 0.55)}\" r=\"3.5\" fill=\"{c.Trim}\"/>"));
                        break;
                    }
                }
            }
        }

        /// <summary>A door's outside (w x h): the finish, a shine, what's on it, its handle.</summary>
        public static string DoorFront(SortModel m, int i, string hinge, float w, float h)
        {
            var c = m.C;
            float rad = DoorRadius(m), bw = 2.5f;
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Radius = rad, BorderWidth = bw, BorderColor = c.Trim });
            Clip(s, 0, 0, w, h, R4(rad), bw);
            float px = bw, py = bw, pw = w - 2 * bw, ph = h - 2 * bw;
            bool left = hinge == "left";
            Grad(s, px, py, pw, ph, c.Door, null, left ? 0 : 1, 0, left ? 1 : 0, 1);
            s.Box(left ? px + 6 : px + pw - 6 - 5, py + 8, 5, ph - 16, new BoxStyle { Background = "rgba(255,255,255,0.6)", Radius = 3 });
            Deco(s, m, i, hinge, px, py, pw, ph, w, h);
            Handle(s, m, left, px, py, pw, ph, w, h);
            s.Close();
            s.Box(0, 0, w, h, new BoxStyle { Radius = rad, BorderWidth = bw, BorderColor = c.Trim });
            return s.Markup;
        }

        static readonly string[] BOTTLES = { "#ffffff", "#ff5a4a", "#ffb02e", "#7be884", "#5fb8ff" };

        /// <summary>A door's inside (w x h, as seen from the front once it has swung past 90°, so mirrored here).</summary>
        public static string DoorBack(SortModel m, float w, float h)
        {
            var c = m.C;
            bool fridge = m.Kind == "fridge";
            float rad = DoorRadius(m), bw = fridge ? 4 : 2.5f;
            string bc = fridge ? "#c9d3dc" : c.Trim;
            var s = new UiSvg(w, h);
            s.Open($"transform=\"matrix(-1 0 0 1 {F(w)} 0)\"");
            s.Box(0, 0, w, h, new BoxStyle { Radius = rad, BorderWidth = bw, BorderColor = bc });
            Clip(s, 0, 0, w, h, R4(rad), bw);
            float px = bw, py = bw, pw = w - 2 * bw, ph = h - 2 * bw;
            Grad(s, px, py, pw, ph, c.DoorInner);
            int bins = fridge ? Math.Max(1, Math.Min(5, (int)JsRound(h / 85))) : 0;
            for (int k = 0; k < bins; k++)
            {
                float y = h * (k + 0.78f) / bins - 6, bh = Math.Min(28, h / bins * 0.5f);
                for (int j = 0; j < 2; j++)
                {
                    float x = j == 0 ? 0.2f : 0.52f;
                    s.Box(px + pw * x, py + y - bh + 4, Math.Max(8, w * 0.16f), bh, new BoxStyle { Background = BOTTLES[(k * 2 + j) % BOTTLES.Length], Radii = new[] { 4f, 4, 0, 0 }, BorderWidth = 1, BorderColor = "rgba(0,0,0,0.12)" });
                }
                s.Box(px + 5, py + y, pw - 10, 10, new BoxStyle { Background = c.Shelf.Face, Radius = 3, Borders = new[] { 0f, 0, 2.5f, 0 }, BorderColor = c.Shelf.Edge });
            }
            if (!fridge) Inset(s, m, px, py, pw, 10, 10, false, 0.25f, ph);
            s.Close();
            s.Box(0, 0, w, h, new BoxStyle { Radius = rad, BorderWidth = bw, BorderColor = bc });
            s.Close();
            return s.Markup;
        }

        /// <summary>Where the doors are in the body: (x, y) of door `i`, its width, the doors' height.</summary>
        public static (float x, float y, float w, float h, string hinge) DoorBox(SortModel m, ContainerGeo g, int i)
        {
            float x0 = INSET, y0 = RING + BORDER + g.Top - g.Up, dh = g.H + g.Crisper + g.Up;
            if (m.Doors == 1) return (x0, y0, g.W, dh, m.Hinge);
            return (x0 + (i == 0 ? 0 : g.W / 2), y0, g.W / 2, dh, i == 0 ? "left" : "right");
        }

        // ---- the tray (landscape: a column at the right) ----------------------------------------------------------------
        /// <summary>The tray in the play area's coordinates (its own box: tw x th at tx, ty; the label pokes 10 dp above).</summary>
        public static string Tray(SortThemeLook t, TrayGeo tg, int cap)
        {
            var s = new UiSvg(tg.Tw, tg.Th);
            s.Box(0, 0, tg.Tw, tg.Th, new BoxStyle { Background = t.TrayRing, Radius = 24 });
            float x = 2.5f, y = 2.5f, w = tg.Tw - 5, h = tg.Th - 2.5f - 7;
            Clip(s, x, y, w, h, R4(21.5f), 3);
            Grad(s, x + 3, y + 3, w - 6, h - 6, t.TrayColors, new[] { 0, 0.6f, 1 });
            float px = x + 3, py = y + 3, pw = w - 6;
            s.Box(px + 14, py + 3, pw - 28, 8, new BoxStyle { Background = "rgba(255,255,255,0.6)", Radius = 4 });
            for (int j = 0; j < cap; j++)
            {
                var (cx, cy) = TrayCenter(tg, j);
                s.Box(px + cx - tg.Tx - 2.5f - tg.Cell * 0.36f, py + cy - tg.Ty - 2.5f + tg.Cell * 0.22f, tg.Cell * 0.72f, tg.Cell * 0.2f, new BoxStyle { Background = "rgba(69,16,122,0.1)", Radius = 999 });
            }
            s.Close();
            s.Box(x, y, w, h, new BoxStyle { Radius = 21.5f, BorderWidth = 3, BorderColor = "#ffffff" });
            var lt = T(Display, 10, "#ffffff", 1);
            float lw = UiSvg.BoxWidth(t.TrayLabel, lt) + 20 + 4, lh = UiSvg.LineBox(lt) + 2 + 4;
            float lx = (tg.Tw - lw) / 2;
            s.Box(lx, -10, lw, lh, new BoxStyle { Background = t.TrayRing, Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text(t.TrayLabel, lx + 2 + 10, -10 + 2 + 1, lt);
            return s.Markup;
        }

        // ---- a squishy's marks (Game.js Piece; each its own piece over or under the picture, P x P) ---------------------
        /// <summary>The soft floor shadow: 74 % x 14 % of the piece, at its bottom, centred (its own box).</summary>
        public static string PieceShadow(float w, float h)
        {
            var s = new UiSvg(w, h);
            s.Def("<radialGradient id=\"pieceFloor\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#45107a\" stop-opacity=\"0.28\"/><stop offset=\"1\" stop-color=\"#45107a\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(w / 2)}\" ry=\"{F(h / 2)}\" fill=\"url(#pieceFloor)\"/>");
            return s.Markup;
        }

        public static string SelRing(float p)
        {
            float i = p * 0.04f;
            return new UiSvg(p, p).Box(i, i, p - 2 * i, p - 2 * i, new BoxStyle { Background = "rgba(255,240,150,0.35)", Radius = 999, BorderWidth = 3, BorderColor = "#ffd23a" }).Markup;
        }

        /// <summary>The mixed-up one's "?" (22 x 22).</summary>
        public static string Huh()
        {
            var s = new UiSvg(22, 22);
            s.Box(0, 0, 22, 22, new BoxStyle { Background = "#ff8a3d", Radius = 11, BorderWidth = 2, BorderColor = "#ffffff" });
            var t = T(Display, 13, "#ffffff");
            s.Text("?", 2, 2 + (18 - UiSvg.LineBox(t)) / 2, t, 18, 0.5f);
            return s.Markup;
        }

        /// <summary>The tick on one that's home (20 x 20).</summary>
        public static string Tick()
        {
            var s = new UiSvg(20, 20);
            s.Box(0, 0, 20, 20, new BoxStyle { Background = "#26a94e", Radius = 10, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Raw(Svg(4, 5, 12, 10, "0 0 12 10", "<path d=\"M1.5 5 L4.5 8 L10.5 2\" stroke=\"#ffffff\" stroke-width=\"2.4\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>"));
            return s.Markup;
        }

        /// <summary>The spot under a dragged squishy (S x S).</summary>
        public static string Hover(float S) => new UiSvg(S, S).Box(0, 0, S, S, new BoxStyle { Background = "rgba(255,230,120,0.28)", Radius = S * 0.24f, BorderWidth = 3, BorderColor = "#ffd23a" }).Markup;

        // ---- the banner (Game.js Banner) -------------------------------------------------------------------------------
        static Shadow[] Outline3(string color, float down) => new[] { new Shadow(color, 0, down, 0), new Shadow(color, 1, 0, 0), new Shadow(color, -1, 0, 0) };

        /// <summary>The big words over the container, `w` wide (the area's width); returns the markup and its height.</summary>
        public static (string markup, float h) Banner(float w, string text, bool small, string ink, string[] chips, string sub)
        {
            var big = new TextStyle { Font = Display, Size = small ? 30 : 40, Color = "#ffffff", Shadows = Outline3(ink ?? INK, 3) };
            float y = 0;
            var s = new UiSvg(w, 400);
            s.Text(text, 0, y, big, w, 0.5f);
            y += UiSvg.LineBox(big);
            if (chips != null && chips.Length > 0)
            {
                var ct = T(Display, 12, "#ffffff", 0.6f);
                y += 8;
                float ch = UiSvg.LineBox(ct) + 6 + 4, total = -6;
                foreach (var c in chips) total += UiSvg.BoxWidth(c, ct) + 18 + 4 + 6;
                float cx = (w - total) / 2;
                foreach (var c in chips)
                {
                    float cw = UiSvg.BoxWidth(c, ct) + 18 + 4;
                    s.Box(cx, y, cw, ch, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                    s.Text(c, cx + 2 + 9, y + 2 + 3, ct);
                    cx += cw + 6;
                }
                y += ch;
            }
            if (sub != null)
            {
                var st = T(Display, 13, "#ffffff");
                y += 6;
                float sw = UiSvg.BoxWidth(sub, st) + 24, sh = UiSvg.LineBox(st) + 8;
                s.Box((w - sw) / 2, y, sw, sh, new BoxStyle { Background = "rgba(69,16,122,0.8)", Radius = 999 });
                s.Text(sub, (w - sw) / 2 + 12, y + 4, st);
                y += sh;
            }
            var mk = s.Markup.Replace($"height=\"400\" viewBox=\"0 0 {F(w)} 400\"", $"height=\"{F(y)}\" viewBox=\"0 0 {F(w)} {F(y)}\"");
            return (mk, y);
        }

        // ---- the HUD's left column (Game.js topEl in landscape: wLeft 236 dp) --------------------------------------------
        public const float LeftW = 236;
        public sealed class Hud
        {
            public string Theme, ModelName, BarLabel;
            public bool BarRed, ShowBar;
            public string[] BarColors;
            public int Lv, Tier, Hearts;
            /// <summary>Blitz (Game.js `blitz`): BLITZ ⚡ · the model, ROUND n/10, the revive chip in the hearts' place
            /// and the pips' row (Ui/Blitz Pips, drawn by the level) between the top bar and the bar.</summary>
            public bool Blitz, Revived;
            public int Round, Rounds = 10;
        }

        // the revive chip (squishdoku/ui.js Chip: 9 x 3 padding, a 2 dp white border, Fredoka 11.5 letter-spaced 0.5)
        static readonly TextStyle ChipText = T(Display, 11.5f, "#ffffff", 0.5f);
        static float ChipH => UiSvg.LineBox(ChipText) + 6 + 4;
        // the top bar's second line: the hearts' pill (38 tall) or, in Blitz, the revive chip
        static float Line2H(Hud d) => d.Blitz ? ChipH : 38;
        /// <summary>Blitz: the pips' row's top (Game.js styles.pips: marginTop 8 under the top bar, the column's gap 4).</summary>
        public static float PipsY(Hud d) => 6 + (6 + Math.Max(40, TitleBoxH()) + 6 + Line2H(d)) + 4 + 8;
        /// <summary>Characters Blitz's HUD has that its fonts don't (the title's ⚡, Chrome's colour emoji; the revive chip's
        /// ♥), by "ch|size": the picture Chrome draws (export-sort.mjs: Resources/Sort/blitz.json, img/blitz-n), its box's
        /// width (the advance Chrome gave it) and height, and its top below the text's. Without one, the fallback outline.</summary>
        public static readonly Dictionary<string, (string href, float w, float h, float dy)> Rasters = new Dictionary<string, (string, float, float, float)>();

        static bool RasterOf(char ch, TextStyle t, out (string href, float w, float h, float dy) r) =>
            Rasters.TryGetValue(ch + "|" + t.Size.ToString(CultureInfo.InvariantCulture), out r);

        /// <summary>A line's width with those characters at Chrome's advance.</summary>
        static float WidthR(string text, TextStyle t)
        {
            float w = 0; int a = 0;
            for (int i = 0; i <= text.Length; i++)
            {
                if (i < text.Length && !RasterOf(text[i], t, out _)) continue;
                if (i > a) w += UiSvg.BoxWidth(text.Substring(a, i - a), t);
                if (i < text.Length) { RasterOf(text[i], t, out var r); w += r.w; }
                a = i + 1;
            }
            return w;
        }

        /// <summary>A line of text with those characters as Chrome's pictures of them, where Chrome put them.</summary>
        static void TextR(UiSvg s, string text, float x, float y, TextStyle t)
        {
            int a = 0;
            for (int i = 0; i <= text.Length; i++)
            {
                if (i < text.Length && !RasterOf(text[i], t, out _)) continue;
                if (i > a) { var run = text.Substring(a, i - a); if (run.Trim().Length > 0) s.Text(run, x, y, t); x += UiSvg.BoxWidth(run, t); }
                if (i < text.Length)
                {
                    RasterOf(text[i], t, out var r);
                    s.Raw($"<image href=\"{r.href}\" x=\"{F(x)}\" y=\"{F(y + r.dy)}\" width=\"{F(r.w)}\" height=\"{F(r.h)}\" preserveAspectRatio=\"none\"/>");
                    x += r.w;
                }
                a = i + 1;
            }
        }

        static readonly TextStyle LevelText = new TextStyle { Font = Display, Size = 18, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 2.5f, 1) } };
        static readonly TextStyle ChallengeText = T(Display, 10, "#ffffff", 0.6f);

        /// <summary>A line cut to `w` with "…" as Chrome does (numberOfLines 1).</summary>
        static string Ellipsis(string text, TextStyle t, float w)
        {
            if (UiSvg.BoxWidth(text, t) <= w + 0.01f) return text;
            for (int n = text.Length - 1; n > 0; n--) { var c = text.Substring(0, n) + "…"; if (UiSvg.BoxWidth(c, t) <= w + 0.01f) return c; }
            return "…";
        }

        static string EllipsisR(string text, TextStyle t, float w)
        {
            if (WidthR(text, t) <= w + 0.01f) return text;
            for (int n = text.Length - 1; n > 0; n--) { var c = text.Substring(0, n) + "…"; if (WidthR(c, t) <= w + 0.01f) return c; }
            return "…";
        }

        /// <summary>The top bar's lines (not the back orb, a piece of its own) as laid out at 236 x 384: returns where
        /// the hearts and the bar row are, for the pieces that move (the hearts pop, the bar's fill slides).</summary>
        public static (float heartsX, float heartsY, float barY, float trackX, float trackW) HudLayout(Hud d)
        {
            float line1 = Math.Max(40, TitleBoxH());
            float heartsY = 6 + 6 + line1 + 6;
            float hudH = 6 + line1 + 6 + Line2H(d);
            float barY = d.Blitz ? PipsY(d) + 17 + 4 + 6 : 6 + hudH + 4 + 6;
            var bl = T(Display, 13, INK, 0.6f);
            float lw = Math.Max(64, UiSvg.BoxWidth(d.BarLabel ?? " ", bl));
            float trackX = 16 + lw + 8;
            return (12, heartsY, barY, trackX, LeftW - 16 - trackX);
        }

        static float TitleBoxH() => UiSvg.LineBox(T(Display, 13, "#000", 1)) + Math.Max(UiSvg.LineBox(LevelText), UiSvg.LineBox(ChallengeText) + 2 + 4);

        /// <summary>The top bar's title, the hearts' pill, the bar's label and empty track (236 x 384).</summary>
        public static string LeftColumn(Hud d, float h)
        {
            var s = new UiSvg(LeftW, h);
            float line1 = Math.Max(40, TitleBoxH());
            float tx = 12 + 40 + 10, tw = LeftW - 12 - tx;
            float ty = 12 + (line1 - TitleBoxH()) / 2;
            var tn = T(Display, 13, SortModels.THEMES[d.Theme].Ring, 1);
            var title = d.Blitz ? "BLITZ ⚡ · " + d.ModelName.ToUpperInvariant() : d.ModelName.ToUpperInvariant();
            if (d.Blitz) TextR(s, EllipsisR(title, tn, tw), tx, ty, tn);
            else s.Text(Ellipsis(title, tn, tw), tx, ty, tn);
            float ry = ty + UiSvg.LineBox(tn);
            float rowH = Math.Max(UiSvg.LineBox(LevelText), UiSvg.LineBox(ChallengeText) + 6);
            var lvl = d.Blitz ? $"ROUND {d.Round}" : "LEVEL " + d.Lv;
            var tier = Levels.TIER_NAMES[d.Tier];
            float chipW = UiSvg.BoxWidth(tier, ChallengeText) + 14 + 4, chipH = UiSvg.LineBox(ChallengeText) + 2 + 4;
            // (numberOfLines 1: a line too long for the row beside its chip shrinks and ends in "…", as ROUND 10/10 does)
            float lvlW = Math.Min(UiSvg.BoxWidth(lvl, LevelText), tw - 6 - chipW);
            s.Text(Ellipsis(lvl, LevelText, lvlW), tx, ry + (rowH - UiSvg.LineBox(LevelText)) / 2, LevelText);
            float chipX = tx + lvlW + 6;
            float cy = ry + (rowH - chipH) / 2;
            s.Box(chipX, cy, chipW, chipH, new BoxStyle { Background = Levels.TIER_COLORS[d.Tier], Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text(tier, chipX + 2 + 7, cy + 2 + 1, ChallengeText);
            // the hearts' pill on the wrapped line (the hearts are pieces of their own)
            var L = HudLayout(d);
            if (d.Blitz)
            {
                // the endless run's rule (develop, 2026-11-17: no revive; the rounds cleared are the pips' count)
                var label = "1 MISTAKE = GAME OVER";
                float cw = WidthR(label, ChipText) + 18 + 4;
                s.Box(12, L.heartsY, cw, ChipH, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                TextR(s, label, 12 + 2 + 9, L.heartsY + 2 + 3, ChipText);
            }
            else s.Box(12, L.heartsY, 3 * 24 + 2 * 3 + 16 + 4, 38, new BoxStyle { Background = "rgba(255,255,255,0.8)", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            // the bar row: 30 tall, centred
            var bl = T(Display, 13, d.BarRed ? "#e01e4a" : INK, 0.6f);
            if (!string.IsNullOrEmpty(d.BarLabel)) s.Text(d.BarLabel, 16, L.barY + (30 - UiSvg.LineBox(bl)) / 2, bl);
            if (d.ShowBar) s.Box(L.trackX, L.barY + 8, L.trackW, 14, new BoxStyle { Background = "rgba(69,16,122,0.18)", Radius = 7, BorderWidth = 2, BorderColor = "#ffffff" });
            return s.Markup;
        }

        /// <summary>The bar's fill (the track's inside: its gradient across and its shine), slid `shift` dp left and
        /// clipped by the track (trackW x 14).</summary>
        public static string BarFill(float trackW, string[] colors, float shift)
        {
            var s = new UiSvg(trackW, 14);
            Clip(s, 0, 0, trackW, 14, R4(7), 2);
            float x = 2 - shift, w = trackW - 4;
            GradAcross(s, x, 2, w, 10, colors);
            s.Box(x + 4, 2 + 1.5f, w - 8, 3, new BoxStyle { Background = "rgba(255,255,255,0.6)", Radius = 2 });
            s.Close();
            return s.Markup;
        }

        /// <summary>A heart of the HUD (24 x 24): the empty one under, the full one (its own piece) over it.</summary>
        const string HUD_HEART_D = "M12 21 C5 15.5 2 12 2 7.8 C2 4.6 4.4 2.5 7.2 2.5 C9.2 2.5 11 3.6 12 5.4 C13 3.6 14.8 2.5 16.8 2.5 C19.6 2.5 22 4.6 22 7.8 C22 12 19 15.5 12 21 Z";
        public static string HeartEmpty() => new UiSvg(24, 24).Raw(Svg(0, 0, 24, 24, "0 0 24 24", $"<path d=\"{HUD_HEART_D}\" fill=\"rgba(69,16,122,0.22)\" stroke=\"#ffffff\" stroke-width=\"2\"/>")).Markup;
        public static string HeartFull() => new UiSvg(24, 24).Raw(Svg(0, 0, 24, 24, "0 0 24 24",
            $"<path d=\"{HUD_HEART_D}\" fill=\"#ff4d7d\" stroke=\"#ffffff\" stroke-width=\"2\"/><path d=\"M6.5 7 C7 5.6 8.2 5 9.2 5.2\" stroke=\"#ffd6e4\" stroke-width=\"1.6\" stroke-linecap=\"round\" fill=\"none\"/>")).Markup;
    }
}
