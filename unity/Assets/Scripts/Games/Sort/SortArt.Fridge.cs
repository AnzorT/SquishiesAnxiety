// Squish Sort's fridge as develop's src/sort/Container.js draws it since 2026-11-17 (the user: "the fridges dont look
// realistic and high detaield enough"): enamel with a soft reflection or brushed steel with its grain, bevelled doors
// with hinge caps, round chrome handles standing off on their posts, a rubber gasket and moulded bins full of bottles,
// cartons and eggs inside each door, and an inside with depth: side walls, a ceiling with an LED strip, a ribbed back
// wall with a vent, glass (or wire) shelves with their trims and the shadows under them, frosted salad drawers with the
// vegetables showing through. The app draws it all with react-native-svg; this writes the same SVG (each of the app's
// <Svg>s at its place, its gradients with ids of their own), so the pieces SortLevel and SortHub place are the app's:
//   Body       the floor shadow, the feet, the cabinet, what's above and below the inside (bodyW x bodyH + feet, the
//              shadow spilling past it: BodyMargin)
//   InsideBack the inside (W x H + crisper, clipped to its 4 dp corners): walls, shelves, salad drawers
//   Lamp       the LED strip lit and its glow (its opacity is the game's `light`)
//   DoorFront  a door's outside; DoorBack its inside (mirrored: it's seen once the door has swung past 90°)
using System;
using System.Text;
using SquishSquad.Ui;
using static SquishSquad.Games.Sort.SortGeometry;

namespace SquishSquad.Games.Sort
{
    public static partial class SortArt
    {
        // ---- numbers as the app writes them -------------------------------------------------------------------------
        // n1: JS Math.round(v * 10) / 10 (half up)
        static string N1(double v) => F(Math.Floor(v * 10 + 0.5) / 10);
        static string D(double v) => F(v);
        // (written with single quotes for the source's sake; the markup's users rename ids by `id="`)
        static string Dq(string markup) => markup.Replace('\'', '"');

        // a rounded rect with its own top and bottom corner radii (Container.js rr: quadratic corners)
        static string RR(double x, double y, double w, double h, double rt = 0, double? rbq = null)
        {
            double rb = rbq ?? rt;
            double a = Math.Max(0, Math.Min(rt, Math.Min(w / 2, h / 2)));
            double b = Math.Max(0, Math.Min(rb, Math.Min(w / 2, h / 2)));
            return $"M{N1(x + a)} {N1(y)}H{N1(x + w - a)}Q{N1(x + w)} {N1(y)} {N1(x + w)} {N1(y + a)}V{N1(y + h - b)}Q{N1(x + w)} {N1(y + h)} {N1(x + w - b)} {N1(y + h)}H{N1(x + b)}Q{N1(x)} {N1(y + h)} {N1(x)} {N1(y + h - b)}V{N1(y + a)}Q{N1(x)} {N1(y)} {N1(x + a)} {N1(y)}Z";
        }

        // ---- elements (react-native-svg's, as the web writes them) ----------------------------------------------------
        static void Rect(StringBuilder o, double x, double y, double w, double h, string rest, double rx = 0)
        {
            if (!(w > 0) || !(h > 0)) return;
            o.Append("<rect x='").Append(D(x)).Append("' y='").Append(D(y)).Append("' width='").Append(D(w)).Append("' height='").Append(D(h)).Append('\'');
            if (rx > 0) o.Append(" rx='").Append(D(rx)).Append('\'');
            o.Append(' ').Append(rest).Append("/>");
        }
        static void Path(StringBuilder o, string d, string rest) => o.Append("<path d='").Append(d).Append("' ").Append(rest).Append("/>");
        static void Circle(StringBuilder o, double cx, double cy, double r, string rest) =>
            o.Append("<circle cx='").Append(D(cx)).Append("' cy='").Append(D(cy)).Append("' r='").Append(D(r)).Append("' ").Append(rest).Append("/>");
        static void Ellipse(StringBuilder o, double cx, double cy, double rx, double ry, string rest) =>
            o.Append("<ellipse cx='").Append(D(cx)).Append("' cy='").Append(D(cy)).Append("' rx='").Append(D(rx)).Append("' ry='").Append(D(ry)).Append("' ").Append(rest).Append("/>");

        // colours spread evenly over a gradient
        static string Spread(string[] colors, double op = 1)
        {
            var o = new StringBuilder();
            for (int i = 0; i < colors.Length; i++)
                o.Append("<stop offset='").Append(D(colors.Length > 1 ? (double)i / (colors.Length - 1) : 0)).Append("' stop-color='").Append(colors[i]).Append("' stop-opacity='").Append(D(op)).Append("'/>");
            return o.ToString();
        }
        static string Stop(double off, string color, double op) => $"<stop offset='{D(off)}' stop-color='{color}' stop-opacity='{D(op)}'/>";
        static string LG(string id, string x1, string y1, string x2, string y2, string stops) => $"<linearGradient id='{id}' x1='{x1}' y1='{y1}' x2='{x2}' y2='{y2}'>{stops}</linearGradient>";
        static string Across(string id, string stops) => LG(id, "0", "0", "1", "0", stops);
        static string Down(string id, string stops) => LG(id, "0", "0", "0", "1", stops);

        // ---- the finish -----------------------------------------------------------------------------------------------
        // brushed steel's grain: fine upright lines, some light, some dark, unevenly spaced
        static (string lite, string dark) GrainOf(double x, double y, double w, double h)
        {
            var lite = new StringBuilder();
            var dark = new StringBuilder();
            int k = 0;
            for (double X = x + 1.2; X < x + w - 0.5;)
            {
                var seg = $"M{N1(X)} {N1(y)}V{N1(y + h)}";
                if (k % 3 == 0) dark.Append(seg);
                else if (k % 3 == 1) lite.Append(seg);
                k++;
                X += 1.4 + ((k * 7) % 5) * 0.55;
            }
            return (lite.ToString(), dark.ToString());
        }

        // The gradients of a finish: across the front, a light-to-shade fall top to bottom, the reflection's band and the
        // bevel's light; `d` is the shape the grain and the reflection are clipped to.
        static string MatDefs(string id, Finish f, string d)
        {
            bool steel = f.Steel;
            return Across(id + "A", Spread(f.Across))
                + Down(id + "V", Stop(0, "#ffffff", steel ? 0.18 : 0.32) + Stop(0.3, "#ffffff", 0) + Stop(0.72, "#000000", 0) + Stop(1, "#000000", steel ? 0.18 : 0.12))
                + Across(id + "R", Stop(0, "#ffffff", 0) + Stop(0.5, "#ffffff", 1) + Stop(1, "#ffffff", 0))
                + LG(id + "B", "0", "0", "1", "1", Stop(0, "#ffffff", 0.95) + Stop(0.4, "#ffffff", 0.12) + Stop(1, "#000000", 0.4))
                + $"<clipPath id='{id}C'><path d='{d}'/></clipPath>";
        }

        // a shape `d` (x, y, w, h its box) filled with the finish
        static void MatFill(StringBuilder o, string id, Finish f, string d, double x, double y, double w, double h)
        {
            bool steel = f.Steel;
            var band = $"M{N1(x + w * 0.5)} {N1(y)}L{N1(x + w * 0.78)} {N1(y)}L{N1(x + w * 0.4)} {N1(y + h)}L{N1(x + w * 0.12)} {N1(y + h)}Z";
            var thin = $"M{N1(x + w * 0.84)} {N1(y)}L{N1(x + w * 0.9)} {N1(y)}L{N1(x + w * 0.52)} {N1(y + h)}L{N1(x + w * 0.46)} {N1(y + h)}Z";
            var (lite, dark) = steel ? GrainOf(x, y, w, h) : ("", "");
            Path(o, d, $"fill='url(#{id}A)'");
            Path(o, d, $"fill='url(#{id}V)'");
            o.Append($"<g clip-path='url(#{id}C)'>");
            if (lite.Length > 0) Path(o, lite, "stroke='#ffffff' stroke-opacity='0.16' stroke-width='0.7'");
            if (dark.Length > 0) Path(o, dark, "stroke='#000000' stroke-opacity='0.09' stroke-width='0.7'");
            Path(o, band, $"fill='url(#{id}R)' opacity='{(steel ? "0.24" : "0.5")}'");
            Path(o, thin, $"fill='url(#{id}R)' opacity='{(steel ? "0.14" : "0.26")}'");
            o.Append("</g>");
        }

        // a metal's gradients, across an upright bar (M) and down a lying one (N)
        static string MetalDefs(string id, string[] metal) => Across(id + "M", Spread(metal)) + Down(id + "N", Spread(metal));

        // a round bar handle standing off the door on two posts, its shadow cast down and right: upright (VBar) or lying
        // (HBar)
        static void VBar(StringBuilder o, string id, double x, double y, double w, double h)
        {
            double post = Math.Max(5, w * 0.75);
            Rect(o, x + 3, y + 5, w, h, "fill='#000000' opacity='0.2'", w / 2);
            Rect(o, x + (w - post) / 2, y - 3, post, 9, $"fill='url(#{id}M)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", 2);
            Rect(o, x + (w - post) / 2, y + h - 6, post, 9, $"fill='url(#{id}M)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", 2);
            Rect(o, x, y + 3, w, h - 6, $"fill='url(#{id}M)' stroke='#000000' stroke-opacity='0.35' stroke-width='0.7'", w / 2);
            Rect(o, x + w * 0.32, y + 7, Math.Max(1, w * 0.14), Math.Max(2, h - 14), "fill='#ffffff' opacity='0.8'", w * 0.07);
        }
        static void HBar(StringBuilder o, string id, double x, double y, double w, double h)
        {
            double post = Math.Max(5, h * 0.75);
            Rect(o, x + 3, y + 4, w, h, "fill='#000000' opacity='0.2'", h / 2);
            Rect(o, x - 3, y + (h - post) / 2, 9, post, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", 2);
            Rect(o, x + w - 6, y + (h - post) / 2, 9, post, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", 2);
            Rect(o, x + 3, y, w - 6, h, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.35' stroke-width='0.7'", h / 2);
            Rect(o, x + 8, y + h * 0.28, Math.Max(2, w - 16), Math.Max(1, h * 0.16), "fill='#ffffff' opacity='0.8'", h * 0.08);
        }

        // ---- a panel: the top-freezer's door, a freezer drawer --------------------------------------------------------
        // `x`, `y`, `w`, `h` in its parent's space; its gap to the body shows round it. handle: "pocket" (a moulded pull on
        // `free`'s side) or "bar" (a long lying bar along the top)
        static void Panel(StringBuilder o, string id, SortModel m, double x, double y, double w, double h, double r, string handle, string free = "left", (double x, double y)? snow = null)
        {
            var f = m.Finish;
            const double p = 2;
            var face = RR(p + 1, p + 1, w - 2, h - 2, r - 1, r - 1);
            o.Append($"<g transform='translate({D(x - p)} {D(y - p)})'><defs>{MatDefs(id, f, face)}{MetalDefs(id, m.Metal)}</defs>");
            Path(o, RR(0, 0, w + 2 * p, h + 2 * p, r + p), $"fill='{f.Seam}' opacity='0.9'");
            Path(o, RR(p, p, w, h, r), $"fill='{f.Edge}'");
            MatFill(o, id, f, face, p + 1, p + 1, w - 2, h - 2);
            Path(o, RR(p + 2, p + 2, w - 4, h - 4, r - 2), $"fill='none' stroke='url(#{id}B)' stroke-width='1.5'");
            if (snow.HasValue)
            {
                double sx = p + snow.Value.x, sy = p + snow.Value.y;
                o.Append("<g opacity='0.55'>");
                foreach (var a in new[] { 0, 60, 120 })
                    Path(o, $"M{D(sx)} {D(sy - 8)}V{D(sy + 8)}M{D(sx)} {D(sy - 5)}l-2.5 -2.5M{D(sx)} {D(sy - 5)}l2.5 -2.5M{D(sx)} {D(sy + 5)}l-2.5 2.5M{D(sx)} {D(sy + 5)}l2.5 2.5",
                        $"stroke='#7fb2d1' stroke-width='1.6' stroke-linecap='round' fill='none' transform='rotate({a} {D(sx)} {D(sy)})'");
                o.Append("</g>");
            }
            if (handle == "bar") HBar(o, id, p + w * 0.16, p + Math.Min(8, h * 0.18), w * 0.68, Math.Max(6, Math.Min(9, h * 0.2)));
            else if (handle == "pocket") Pocket(o, id, f, free == "right" ? p + w - 16 : p + 4, 0, Math.Max(16, h * 0.45), p + h);
            o.Append("</g>");
        }

        // a moulded pull, `ph` high at px; its top at `top`, or (top 0) ending 6 above `bottom`
        static void Pocket(StringBuilder o, string id, Finish f, double px, double top, double ph, double bottom = 0)
        {
            double py = bottom > 0 ? bottom - ph - 6 : top;
            Rect(o, px + 2, py + 3, 12, ph, "fill='#000000' opacity='0.16'", 5);
            Rect(o, px, py, 12, ph, $"fill='url(#{id}M)' stroke='{f.Edge}' stroke-opacity='0.5' stroke-width='0.7'", 5);
            Rect(o, px + 3, py + 4, 6, ph - 8, "fill='#000000' opacity='0.3'", 3);
            Rect(o, px + 1.5, py + 2, 1.6, ph - 4, "fill='#ffffff' opacity='0.75'", 0.8);
        }

        // a kick-plate grille: a recess with louvred slats (dark, or in the body's own shade)
        static void Grille(StringBuilder o, SortModel m, double x, double y, double w, double h, bool dark)
        {
            int n = Math.Max(2, (int)Math.Floor((h - 2) / 3.4));
            double step = (h - 3) / n;
            o.Append($"<g transform='translate({D(x)} {D(y)})'>");
            Path(o, RR(0, 0, w, h, 3), $"fill='{(dark ? "#11161a" : m.Finish.Shade)}'");
            for (int i = 0; i < n; i++)
            {
                Rect(o, 3, 1.5 + i * step, w - 6, step * 0.58, $"fill='{(dark ? "#3b444d" : m.Finish.Edge)}' opacity='{(dark ? "1" : "0.45")}'", 1);
                Rect(o, 3, 1.5 + i * step, w - 6, 0.8, $"fill='#ffffff' opacity='{(dark ? "0.22" : "0.35")}'");
            }
            o.Append("</g>");
        }

        // ---- above the inside (in the face's space: `w` the face's width, W x h the inside's width and the room, `up`
        // how much of it the door covers too) ------------------------------------------------------------------------
        static void IceBox(StringBuilder o, SortModel m, double W, double h, double up)
        {
            const string id = "ib";
            double y0 = h - up, bx = WALL + W * 0.07, bw = W * 0.86, by = y0 + 5, bh = Math.Max(8, up - 10);
            o.Append($"<defs>{Down(id + "al", Spread(new[] { "#f7fafc", "#dfe6eb", "#bfcad3" }))}{Down(id + "N", Spread(SortModels.CHROME))}</defs>");
            // a retro fridge's chrome strip on its rounded top
            if (m.Radius[0] > 30)
            {
                Rect(o, WALL + W * 0.22 + 2, y0 * 0.42, W * 0.56, 7, "fill='#000000' opacity='0.15'", 3.5);
                Rect(o, WALL + W * 0.22, y0 * 0.42 - 3, W * 0.56, 7, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", 3.5);
            }
            // the liner behind the freezer box (inside, under the door)
            Path(o, RR(WALL, y0, W, up + 12, 10, 0), $"fill='{m.Liner.Back}'");
            Path(o, RR(WALL + 4, y0 + 2, W - 8, up + 8, 8, 0), $"fill='{m.Liner.Top}' opacity='0.8'");
            // the freezer box, frosted, its flap and the drip tray under it
            Path(o, RR(bx, by, bw, bh, 5), $"fill='url(#{id}al)' stroke='#8796a2' stroke-width='1.2'");
            Path(o, $"M{N1(bx + 5)} {N1(by + 3)}Q{N1(bx + bw * 0.3)} {N1(by + 6.5)} {N1(bx + bw * 0.5)} {N1(by + 3)}T{N1(bx + bw - 5)} {N1(by + 3)}", "stroke='#ffffff' stroke-width='3' stroke-linecap='round' fill='none' opacity='0.9'");
            Path(o, RR(bx + 3, by + bh * 0.36, bw - 6, bh * 0.58, 3), "fill='#edf2f5' stroke='#9aa8b4' stroke-width='1'");
            Rect(o, bx + bw * 0.38, by + bh * 0.36 + 3, bw * 0.24, 3.2, "fill='#7d8b97'", 1.6);
            Rect(o, bx + bw * 0.08, by + bh * 0.36 + 2, bw * 0.2, 1.4, "fill='#ffffff' opacity='0.9'", 0.7);
            Rect(o, bx - 2, by + bh + 1, bw + 4, 3, "fill='#b2bec8'", 1.5);
        }

        static readonly TextStyle LcdText = T(Display, 11, "#ff4a3d", 0.6f), PlateText = T(Display, 7.5f, "#3e4852", 1.6f);
        static readonly TextStyle BadgeText = T(Display, 10.5f, "#2f3a44", 0.6f), DisplayText = T(Display, 11, "#5fd4ff"), DisplaySmall = T(Display, 7.5f, "#7be884", 0.8f);

        // a line of text centred in a box (a View with alignItems / justifyContent centre)
        static void TextIn(UiSvg s, string text, TextStyle t, float x, float y, float w, float h) => s.Text(text, x, y + (h - UiSvg.LineBox(t)) / 2, t, w, 0.5f);

        // a restaurant fridge's header: a digital thermometer, a maker's plate and the condenser's louvres (drawn in the
        // face's space: the group round it is already open in `s`)
        static void Header(UiSvg s, StringBuilder o, double W, double h)
        {
            const string id = "hd";
            double x0 = WALL - 2, pw = W + 4, lw = Math.Min(110, W * 0.3);
            const int n = 4;
            double lcdR = x0 + 8 + 46, louvL = x0 + pw - lw - 8;
            double plW = Math.Min(56, louvL - lcdR - 12), plX = (lcdR + louvL) / 2 - plW / 2;
            o.Append($"<defs>{Down(id + "h", Spread(new[] { "#454d56", "#2a3037", "#1c2126" }))}{Across(id + "p", Spread(new[] { "#8d97a1", "#e3e7eb", "#b8c0c8", "#f1f3f5", "#9aa4ae" }))}</defs>");
            Path(o, RR(x0, 3, pw, h - 6, 5), $"fill='url(#{id}h)' stroke='#0c0f12' stroke-width='1'");
            Rect(o, x0 + 3, 4, pw - 6, 1, "fill='#ffffff' opacity='0.25'");
            // the thermometer's window
            Path(o, RR(x0 + 8, h / 2 - 8, 46, 16, 3), "fill='#040506' stroke='#5a6570' stroke-width='1'");
            Rect(o, x0 + 10, h / 2 - 6, 42, 2, "fill='#ffffff' opacity='0.08'");
            // the maker's plate
            if (plW >= 34)
            {
                Path(o, RR(plX, h / 2 - 6, plW, 12, 2.5), $"fill='url(#{id}p)' stroke='#3e4852' stroke-width='0.8'");
                foreach (var cx in new[] { plX + 4, plX + plW - 4 }) Circle(o, cx, h / 2, 1.3, "fill='#56616c'");
            }
            // the louvres
            for (int i = 0; i < n; i++)
            {
                double y = 7 + i * ((h - 14) / n);
                Rect(o, x0 + pw - lw - 8, y, lw, (h - 14) / n - 1.5, "fill='#0b0e11'", 1);
                Rect(o, x0 + pw - lw - 8, y, lw, 1.2, "fill='#7d8894' opacity='0.7'");
            }
            // (the words are Views over the drawing)
            s.Raw(o.ToString()); o.Clear();
            TextIn(s, "3°C", LcdText, (float)(x0 + 8), (float)(h / 2 - 8), 46, 16);
            if (plW >= 34) TextIn(s, "SQUISH", PlateText, (float)(plX + 6), (float)(h / 2 - 6), (float)(plW - 12), 12);
        }

        // a slim control strip under the top edge: two status lights and a light bar behind dark glass
        static void Band(StringBuilder o, double w, double h)
        {
            Path(o, RR(w / 2 - 28, h / 2 - 4.5, 56, 9, 4.5), "fill='#0a0d10' opacity='0.88'");
            Rect(o, w / 2 - 25, h / 2 - 3.5, 50, 1.2, "fill='#ffffff' opacity='0.18'", 0.6);
            Circle(o, w / 2 - 17, h / 2, 2.1, "fill='#5fd4ff'");
            Circle(o, w / 2 - 10, h / 2, 2.1, "fill='#7be884'");
            Rect(o, w / 2 - 3, h / 2 - 1, 22, 2, "fill='#5fd4ff' opacity='0.65'", 1);
        }

        static void Top(UiSvg s, StringBuilder o, SortModel m, double w, double W, double h, double up)
        {
            switch (m.TopKind)
            {
                case "icebox": IceBox(o, m, W, h, up); break;
                case "freezer":
                {
                    // the freezer: its own door, the pull on the same side as the fridge's, a snowflake by its hinge
                    var free = m.Hinge == "left" ? "right" : "left";
                    Panel(o, "fz", m, WALL, 3, W, h - 7, 10, "pocket", free, (m.Hinge == "left" ? 18 : W - 18, (h - 7) / 2));
                    break;
                }
                case "band": Band(o, w, h); break;
                case "header": Header(s, o, W, h); break;
            }
        }

        // ---- below the inside ------------------------------------------------------------------------------------------
        static void ChromeStrip(StringBuilder o, double x, double y, double w, double h)
        {
            const string id = "cs";
            o.Append($"<g transform='translate({D(x)} {D(y)})'><defs>{Down(id + "N", Spread(SortModels.CHROME))}</defs>");
            Rect(o, 2, 3, w, h, "fill='#000000' opacity='0.15'", h / 2);
            Rect(o, 0, 0, w, h, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.6'", h / 2);
            Rect(o, 6, h * 0.26, w - 12, Math.Max(1, h * 0.14), "fill='#ffffff' opacity='0.85'", 1);
            o.Append("</g>");
        }

        static void Bottom(StringBuilder o, SortModel m, double W, double y, double h)
        {
            switch (m.BottomKind)
            {
                case "grille": Grille(o, m, WALL + 2, y + 3, W - 4, h - 6, true); break;
                case "kick": Grille(o, m, WALL + 6, y + 3, W - 12, h - 6, false); break;
                case "chrome": ChromeStrip(o, WALL, y + 3, W, h - 7); break;
                case "drawer":
                    // the freezer drawer, and the grille under it
                    Panel(o, "dr0", m, WALL, y + 4, W, h - 16, 8, "bar");
                    Grille(o, m, WALL + 8, y + h - 10, W - 16, 8, true);
                    break;
                case "drawers":
                    Panel(o, "dr0", m, WALL, y + 4, W / 2 - 2, h - 16, 8, "bar");
                    Panel(o, "dr1", m, WALL + W / 2 + 2, y + 4, W / 2 - 2, h - 16, 8, "bar");
                    Grille(o, m, WALL + 8, y + h - 10, W - 16, 8, true);
                    break;
            }
        }

        // ---- what it stands on, and its shadow on the floor ------------------------------------------------------------
        static void Feet(StringBuilder o, SortModel m, double w, double h)
        {
            const string id = "ft";
            var at = new[] { w * 0.13, w * 0.87 };
            var shapes = new StringBuilder();
            switch (m.FeetKind)
            {
                case "legs":
                    // a retro fridge's splayed chrome legs, rubber tips
                    for (int i = 0; i < 2; i++)
                    {
                        double x = at[i], sg = i == 1 ? 1 : -1;
                        Path(shapes, $"M{N1(x - 7)} 0H{N1(x + 7)}L{N1(x + 3 + sg * 5)} {N1(h - 3)}H{N1(x - 3 + sg * 5)}Z", $"fill='url(#{id}M)' stroke='#3e4852' stroke-width='0.8' stroke-linejoin='round'");
                        Ellipse(shapes, x + sg * 5, h - 2.5, 4.5, 2.2, "fill='#1d2126'");
                    }
                    break;
                case "casters":
                    foreach (var x in new[] { w * 0.1, w * 0.5, w * 0.9 })
                    {
                        Rect(shapes, x - 9, 0, 18, 4, $"fill='url(#{id}N)'", 1.5);
                        Rect(shapes, x - 2, 4, 4, h * 0.18, "fill='#5b6570'");
                        Path(shapes, $"M{N1(x - 7)} {N1(4 + h * 0.18)}H{N1(x + 7)}L{N1(x + 5)} {N1(h - 6)}H{N1(x - 5)}Z", "fill='#6b7682' stroke='#2f363d' stroke-width='0.8'");
                        Circle(shapes, x, h - 7, 6.5, $"fill='url(#{id}W)'");
                        Circle(shapes, x, h - 7, 2.6, "fill='#c9d0d7' stroke='#56616c' stroke-width='0.8'");
                        Path(shapes, $"M{N1(x - 4.5)} {N1(h - 10.5)}Q{N1(x)} {N1(h - 13.5)} {N1(x + 4.5)} {N1(h - 10.5)}", "stroke='#ffffff' stroke-opacity='0.35' stroke-width='1' fill='none'");
                    }
                    break;
                case "nubs":
                    foreach (var x in at)
                    {
                        Path(shapes, RR(x - 9, 0, 18, h, 0, 4), $"fill='url(#{id}R)'");
                        Rect(shapes, x - 7, h - 3, 14, 1, "fill='#ffffff' opacity='0.25'", 0.5);
                    }
                    break;
                default: return;
            }
            o.Append("<defs>").Append(Across(id + "M", Spread(SortModels.CHROME))).Append(Down(id + "N", Spread(SortModels.CHROME)))
                .Append(Down(id + "R", Spread(new[] { "#4a5159", "#23282d", "#0f1214" })))
                .Append($"<radialGradient id='{id}W' cx='45%' cy='40%' r='60%'>{Spread(new[] { "#4b535c", "#22272d", "#0e1013" })}</radialGradient></defs>");
            o.Append(shapes);
        }

        static void FloorShadow(StringBuilder o, double w)
        {
            o.Append($"<defs><radialGradient id='fss' cx='50%' cy='50%' r='50%'>{Stop(0, "#1a0f08", 0.42)}{Stop(0.6, "#1a0f08", 0.18)}{Stop(1, "#1a0f08", 0)}</radialGradient></defs>");
            Ellipse(o, w / 2, 8, w / 2, 8, "fill='url(#fss)'");
        }

        /// <summary>How far past its box the body's drawing reaches (the shadow on the floor), dp.</summary>
        public static float BodyMargin(ContainerGeo g) => (float)Math.Ceiling(g.BodyW * 0.08 + 2);

        /// <summary>The floor shadow, the feet, the cabinet (its outline, the finish with its rounded edges and the
        /// bevel's light, the dark base, the gap round the opening the doors close over, the hinge caps) and what's above
        /// and below the inside: bodyW x (bodyH + feet).</summary>
        public static string Body(SortModel m, ContainerGeo g)
        {
            var f = m.Finish;
            float bodyW = g.BodyW, bodyH = g.BodyH, W = g.W;
            var s = new UiSvg(bodyW, bodyH + g.Feet);
            var o = new StringBuilder();
            // its shadow on the floor, then its feet
            o.Append($"<g transform='translate({D(-bodyW * 0.08)} {D(bodyH + g.Feet - 9)})'>");
            FloorShadow(o, bodyW * 1.16);
            o.Append("</g>");
            if (g.Feet > 0)
            {
                o.Append($"<g transform='translate(0 {D(bodyH - 6)})'>");
                Feet(o, m, bodyW, g.Feet + 6);
                o.Append("</g>");
            }
            // the cabinet
            const string id = "bd";
            double rt = m.Radius[0], rb = m.Radius[1];
            double fw = bodyW - 2 * RING, fh = bodyH - 2 * RING - LIP;
            var face = RR(RING, RING, fw, fh, Math.Max(2, rt - RING), Math.Max(2, rb - RING));
            double doorTop = RING + BORDER + g.Top - g.Up, dh = g.H + g.Crisper + g.Up;
            var hinges = m.Doors == 1 ? new double[] { m.Hinge == "left" ? INSET : INSET + W } : new double[] { INSET, INSET + W };
            o.Append($"<defs>{MatDefs(id, f, face)}{MetalDefs(id, m.Metal)}{Down(id + "P", Spread(new[] { f.Shade, f.Edge }))}</defs>");
            Path(o, RR(0, 0, bodyW, bodyH, rt, rb), $"fill='{f.Edge}'");
            Path(o, RR(RING, bodyH - RING - LIP - 2, fw, LIP + 2, 0, Math.Max(1, rb - RING)), $"fill='url(#{id}P)'");
            MatFill(o, id, f, face, RING, RING, fw, fh);
            Path(o, RR(RING + 1, RING + 1, fw - 2, fh - 2, Math.Max(1, rt - RING - 1), Math.Max(1, rb - RING - 1)), $"fill='none' stroke='url(#{id}B)' stroke-width='2'");
            // the gap round the doors (and the opening, when they swing open)
            Path(o, RR(INSET - 2.5, doorTop - 2.5, W + 5, dh + 5, 7), $"fill='{f.Seam}'");
            Path(o, RR(INSET - 1, doorTop - 1, W + 2, dh + 2, 6), "fill='#000000' opacity='0.4'");
            foreach (var hx in hinges)
            {
                Path(o, RR(hx - 7, doorTop - 6, 14, 5, 2), $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.5'");
                Path(o, RR(hx - 7, doorTop + dh + 1, 14, 5, 2), $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.3' stroke-width='0.5'");
            }
            // what's above and below the inside, in the face's own space
            const float fo = RING + BORDER;
            o.Append($"<g transform='translate({D(fo)} {D(fo)})'>");
            s.Raw(o.ToString()); o.Clear();
            Top(s, o, m, bodyW - 2 * fo, W, g.Top, g.Up);
            Bottom(o, m, W, g.Top + g.H + g.Crisper, g.Bottom);
            o.Append("</g>");
            s.Raw(o.ToString());
            return Dq(s.Markup);
        }

        // ---- a door ------------------------------------------------------------------------------------------------------
        static float DoorRadius(SortModel m) => Math.Min(10, m.Radius[1]);

        // its handle, by the edge away from the hinge (`free`)
        static void HandleArt(StringBuilder o, SortModel m, string id, string free, double w, double h)
        {
            var f = m.Finish;
            bool right = free == "right";
            switch (m.Handle)
            {
                case "recess":
                {
                    // a finger groove moulded into the door's edge
                    const double gw = 7;
                    double x = right ? w - gw - 3 : 3, y = h * 0.1, gh = Math.Max(20, h * 0.5);
                    Rect(o, x, y, gw, gh, $"fill='{f.Shade}'", 3.5);
                    Rect(o, right ? x : x + gw - 3, y + 1, 3, gh - 2, "fill='#000000' opacity='0.3'", 1.5);
                    Rect(o, right ? x + gw - 1.4 : x + 0.4, y + 2, 1, gh - 4, "fill='#ffffff' opacity='0.8'");
                    Rect(o, x, y, gw, 2, "fill='#000000' opacity='0.18'", 1);
                    break;
                }
                case "lever":
                {
                    // a retro chrome lever on its plate
                    double lw = Math.Min(48, w * 0.34), py = h * 0.34;
                    double plateX = right ? w - 20 : 6, barX = right ? plateX - lw + 10 : plateX + 4;
                    Rect(o, plateX + 2, py - 13, 14, 32, "fill='#000000' opacity='0.18'", 7);
                    Rect(o, plateX, py - 15, 14, 32, $"fill='url(#{id}M)' stroke='#000000' stroke-opacity='0.35' stroke-width='0.7'", 7);
                    HBar(o, id, barX, py - 4, lw, 9);
                    double kx = right ? barX + 2 : barX + lw - 2;
                    Circle(o, kx, py + 0.5, 6.5, $"fill='url(#{id}M)' stroke='#000000' stroke-opacity='0.35' stroke-width='0.7'");
                    Circle(o, kx - 2, py - 1.5, 1.8, "fill='#ffffff' opacity='0.85'");
                    break;
                }
                case "pocket":
                    Pocket(o, id, f, right ? w - 16 : 4, Math.Max(6, h * 0.05), Math.Max(22, h * 0.26));
                    break;
                case "bar":
                case "long":
                {
                    bool lng = m.Handle == "long";
                    double bw = lng ? 11 : 8, y0 = h * (lng ? 0.16 : 0.12), y1 = h * (lng ? 0.62 : 0.66);
                    VBar(o, id, right ? w - 8 - bw : 8, y0, bw, y1 - y0);
                    break;
                }
            }
        }

        // what's on the door (its SVG part): a note, a drawing and magnets, a badge and a trim, an ice and water
        // dispenser, a display, a lock, a kick plate. `i`: which door (0 the left one or the only one, 1 the right one)
        static void DecoArt(StringBuilder o, SortModel m, string id, int i, string hinge, string free, double w, double h)
        {
            var f = m.Finish;
            foreach (var d in m.Deco)
            {
                if (d == "note")
                {
                    double nw = Math.Min(Math.Min(46, w * 0.3), h * 0.55);
                    double x = hinge == "left" ? w * 0.2 : w - w * 0.2 - nw, y = Math.Max(8, h * 0.16);
                    o.Append($"<g transform='rotate(-6 {N1(x + nw / 2)} {N1(y + nw / 2)})'>");
                    Rect(o, x + 2, y + 3, nw, nw * 1.05, "fill='#000000' opacity='0.14'");
                    Rect(o, x, y, nw, nw * 1.05, "fill='#fff4a8'");
                    Rect(o, x, y, nw, nw * 0.18, "fill='#ffe86b'");
                    foreach (var k in new[] { 0.42, 0.58, 0.74 }) Rect(o, x + nw * 0.16, y + nw * k, nw * (k > 0.7 ? 0.42 : 0.66), 1.4, "fill='#5b7fb0' opacity='0.75'", 0.7);
                    Circle(o, x + nw / 2, y + 1, 4.5, "fill='#e23d4a'");
                    Circle(o, x + nw / 2 - 1.4, y - 0.5, 1.4, "fill='#ffffff' opacity='0.7'");
                    o.Append("</g>");
                }
                else if (d == "magnets")
                {
                    // a child's drawing held up by a magnet, a strawberry magnet and a shopping list
                    double nw = Math.Min(56, w * 0.32);
                    double x = hinge == "left" ? w * 0.14 : w - w * 0.14 - nw, y = h * 0.13;
                    double lx = hinge == "left" ? w * 0.5 : w * 0.5 - nw * 0.62;
                    o.Append($"<g transform='rotate(5 {N1(x + nw / 2)} {N1(y + nw * 0.4)})'>");
                    Rect(o, x + 2, y + 3, nw, nw * 0.8, "fill='#000000' opacity='0.13'");
                    Rect(o, x, y, nw, nw * 0.8, "fill='#ffffff'");
                    Circle(o, x + nw * 0.24, y + nw * 0.2, nw * 0.09, "fill='#ffc83a'");
                    Path(o, $"M{N1(x + nw * 0.08)} {N1(y + nw * 0.68)}Q{N1(x + nw / 2)} {N1(y + nw * 0.6)} {N1(x + nw * 0.92)} {N1(y + nw * 0.68)}", "stroke='#3ddc97' stroke-width='2.2' fill='none' stroke-linecap='round'");
                    Circle(o, x + nw * 0.6, y + nw * 0.42, nw * 0.15, "fill='none' stroke='#ff8a3d' stroke-width='1.8'");
                    Circle(o, x + nw * 0.55, y + nw * 0.4, 1, "fill='#45107a'");
                    Circle(o, x + nw * 0.65, y + nw * 0.4, 1, "fill='#45107a'");
                    Path(o, $"M{N1(x + nw * 0.54)} {N1(y + nw * 0.47)}Q{N1(x + nw * 0.6)} {N1(y + nw * 0.52)} {N1(x + nw * 0.66)} {N1(y + nw * 0.47)}", "stroke='#45107a' stroke-width='1.1' fill='none' stroke-linecap='round'");
                    Circle(o, x + nw / 2, y + 1, 4.2, "fill='#2f7fd6'");
                    Circle(o, x + nw / 2 - 1.3, y - 0.3, 1.3, "fill='#ffffff' opacity='0.7'");
                    o.Append("</g>");
                    o.Append($"<g transform='rotate(-4 {N1(lx + nw * 0.3)} {N1(h * 0.52)})'>");
                    Rect(o, lx + 2, h * 0.44 + 3, nw * 0.62, nw * 0.9, "fill='#000000' opacity='0.12'");
                    Rect(o, lx, h * 0.44, nw * 0.62, nw * 0.9, "fill='#fdfaf0'");
                    foreach (var k in new[] { 0.2, 0.36, 0.52, 0.68 }) Rect(o, lx + nw * 0.08, h * 0.44 + nw * k, nw * (k > 0.6 ? 0.28 : 0.44), 1.3, "fill='#c0392b' opacity='0.7'", 0.6);
                    Path(o, $"M{N1(lx + nw * 0.31)} {N1(h * 0.44 - 4)}c-4 0 -6 3 -6 6 0 4 6 8 6 8s6 -4 6 -8c0 -3 -2 -6 -6 -6z", "fill='#ff4a5c'");
                    Path(o, $"M{N1(lx + nw * 0.31 - 3)} {N1(h * 0.44 - 4)}l3 2 3 -2", "stroke='#3ddc97' stroke-width='1.6' fill='none' stroke-linecap='round'");
                    o.Append("</g>");
                }
                else if (d == "badge")
                {
                    double bw = Math.Min(74, w * 0.46), y = Math.Max(8, h * 0.08);
                    Rect(o, w / 2 - bw / 2 + 1.5, y + 2.5, bw, 18, "fill='#000000' opacity='0.18'", 9);
                    Rect(o, w / 2 - bw / 2, y, bw, 18, $"fill='url(#{id}N)' stroke='#000000' stroke-opacity='0.35' stroke-width='0.7'", 9);
                }
                else if (d == "stripe")
                {
                    Rect(o, 7, h * 0.9 + 2, w - 12, 4, "fill='#000000' opacity='0.15'", 2);
                    Rect(o, 6, h * 0.9, w - 12, 4, $"fill='url(#{id}N)'", 2);
                }
                else if (d == "dispenser" && i == 0)
                {
                    // ice and water: a recess with its controls, a paddle, a light and a drip grille
                    double x = w * 0.18, dw = w * 0.64, y = h * 0.13, dh = Math.Min(h * 0.3, w * 0.9);
                    Path(o, RR(x - 2.5, y - 2.5, dw + 5, dh + 5, 10), $"fill='{f.Seam}'");
                    Path(o, RR(x, y, dw, dh, 8), $"fill='url(#{id}D)'");
                    Ellipse(o, x + dw / 2, y + 14, dw * 0.36, 8, "fill='#5fd4ff' opacity='0.16'");
                    Path(o, RR(x + 4, y + 4, dw - 8, 9, 3), "fill='#05070a' stroke='#3a444e' stroke-width='0.8'");
                    Rect(o, x + dw / 2 - 13, y + 6.5, 4, 4, "fill='#5fd4ff'", 0.8);
                    Path(o, $"M{N1(x + dw / 2 - 1)} {N1(y + 6.3)}q2 2.6 0 4.2q-2 -1.6 0 -4.2z", "fill='#5fd4ff' opacity='0.6'");
                    Circle(o, x + dw / 2 + 10, y + 8.5, 2, "fill='#5fd4ff' opacity='0.6'");
                    Rect(o, x + dw * 0.44, y + 15, dw * 0.12, 4, "fill='#6b7682'", 1);
                    Path(o, RR(x + dw * 0.3, y + 19, dw * 0.4, dh * 0.42, 4), $"fill='url(#{id}Q)' stroke='#1c2126' stroke-width='0.8'");
                    Path(o, RR(x + 5, y + dh - 9, dw - 10, 6, 2), "fill='#2c343c'");
                    int nk = Math.Max(3, (int)Math.Floor((dw - 14) / 5));
                    for (int k = 0; k < nk; k++) Rect(o, x + 8 + k * 5, y + dh - 8, 2, 4, "fill='#0b0e11'", 1);
                }
                else if (d == "display" && i == 1)
                {
                    Path(o, RR(w * 0.25 - 2, h * 0.16 - 2, w * 0.5 + 4, 26, 7), $"fill='{f.Seam}'");
                    Path(o, RR(w * 0.25, h * 0.16, w * 0.5, 22, 5), "fill='#05080b' stroke='#3a444e' stroke-width='0.8'");
                    Rect(o, w * 0.25 + 3, h * 0.16 + 2, w * 0.5 - 6, 2, "fill='#ffffff' opacity='0.12'", 1);
                }
                else if (d == "lock" && i == 0)
                {
                    double cx = free == "right" ? w - 15 : 15, cy = h * 0.72;
                    Circle(o, cx + 1.5, cy + 2, 7, "fill='#000000' opacity='0.18'");
                    Circle(o, cx, cy, 7, $"fill='url(#{id}M)' stroke='#2f363d' stroke-width='0.8'");
                    Circle(o, cx, cy, 4.3, "fill='#9aa4ae' stroke='#56616c' stroke-width='0.6'");
                    Rect(o, cx - 0.9, cy - 2.8, 1.8, 5.6, "fill='#2f363d'", 0.9);
                }
                else if (d == "plate")
                {
                    // a kick plate, screwed on
                    double ph = Math.Max(14, h * 0.1), y = h - ph - 6;
                    Path(o, RR(5, y, w - 10, ph, 2), $"fill='{f.Shade}' stroke='{f.Edge}' stroke-width='0.8'");
                    Rect(o, 7, y + 1.5, w - 14, 1, "fill='#ffffff' opacity='0.45'");
                    foreach (var (sx, sy) in new[] { (9.0, y + 4), (w - 9, y + 4), (9.0, y + ph - 4), (w - 9, y + ph - 4) })
                        Circle(o, sx, sy, 1.6, "fill='#c9d0d7' stroke='#3e4852' stroke-width='0.6'");
                }
            }
        }

        // the door's words: a retro badge (Fredoka with Chrome's synthesised slant), a display
        static void DecoText(UiSvg s, SortModel m, int i, float w, float h)
        {
            if (m.Has("badge"))
            {
                float bw = Math.Min(74, w * 0.46f), x = w / 2 - bw / 2, y = Math.Max(8, h * 0.08f);
                float top = y + (18 - UiSvg.LineBox(BadgeText)) / 2, baseline = UiSvg.Baseline(BadgeText, top);
                // italic: skewX(-14°) about the baseline (Skia's fake italic, a quarter across per unit up)
                s.Open($"transform=\"matrix(1 0 -0.25 1 {F(0.25 * baseline)} 0)\"");
                s.Text("Squishy", x, top, BadgeText, bw, 0.5f);
                s.Close();
            }
            if (m.Has("display") && i == 1)
            {
                // a row: "3°C" and "ECO" 5 apart, centred both ways in w / 2 x 22
                float x = w * 0.25f, y = h * 0.16f, dw = w * 0.5f;
                float a = UiSvg.BoxWidth("3°C", DisplayText), b = UiSvg.BoxWidth("ECO", DisplaySmall);
                float cx = x + (dw - a - 5 - b) / 2;
                s.Text("3°C", cx, y + (22 - UiSvg.LineBox(DisplayText)) / 2, DisplayText);
                s.Text("ECO", cx + a + 5, y + (22 - UiSvg.LineBox(DisplaySmall)) / 2, DisplaySmall);
            }
        }

        /// <summary>A door's outside (w x h): the finish with its bevel and reflection, a little shade on its hinge edge,
        /// what's on it and its handle.</summary>
        public static string DoorFront(SortModel m, int i, string hinge, float w, float h)
        {
            const string id = "df";
            var f = m.Finish;
            double r = DoorRadius(m);
            var free = hinge == "left" ? "right" : "left";
            var face = RR(1, 1, w - 2, h - 2, Math.Max(1, r - 1));
            var s = new UiSvg(w, h);
            var o = new StringBuilder();
            o.Append($"<defs>{MatDefs(id, f, face)}{MetalDefs(id, m.Metal)}{Down(id + "D", Spread(new[] { "#262d34", "#151a1f", "#0b0e11" }))}{Across(id + "Q", Spread(new[] { "#3a424b", "#6b7682", "#4b545e" }))}</defs>");
            Path(o, RR(0, 0, w, h, r), $"fill='{f.Edge}'");
            MatFill(o, id, f, face, 1, 1, w - 2, h - 2);
            Path(o, RR(2, 2, w - 4, h - 4, Math.Max(1, r - 2)), $"fill='none' stroke='url(#{id}B)' stroke-width='1.6'");
            Rect(o, hinge == "left" ? 1 : w - 7, 2, 6, h - 4, "fill='#000000' opacity='0.07'");
            DecoArt(o, m, id, i, hinge, free, w, h);
            HandleArt(o, m, id, free, w, h);
            s.Raw(o.ToString());
            DecoText(s, m, i, w, h);
            return Dq(s.Markup);
        }

        // what stands in a door bin: bottles, cartons, a jug, cans, eggs (each standing on `b`, `w` wide and `h` high
        // from `x`)
        static void Bottle(StringBuilder o, double x, double b, double w, double h, string body, string cap, string label = null)
        {
            Path(o, $"M{N1(x)} {N1(b)}V{N1(b - h * 0.6)}Q{N1(x)} {N1(b - h * 0.78)} {N1(x + w * 0.32)} {N1(b - h * 0.84)}V{N1(b - h)}H{N1(x + w * 0.68)}V{N1(b - h * 0.84)}Q{N1(x + w)} {N1(b - h * 0.78)} {N1(x + w)} {N1(b - h * 0.6)}V{N1(b)}Z", $"fill='{body}'");
            Rect(o, x + w * 0.26, b - h - 3, w * 0.48, 4, $"fill='{cap}'", 1);
            if (label != null) Rect(o, x, b - h * 0.5, w, h * 0.24, $"fill='{label}'");
            Rect(o, x + w * 0.16, b - h * 0.58, Math.Max(1, w * 0.12), h * 0.5, "fill='#ffffff' opacity='0.5'", 0.8);
        }
        static void Carton(StringBuilder o, double x, double b, double w, double h, string body, string top)
        {
            Rect(o, x, b - h * 0.84, w, h * 0.84, $"fill='{body}'");
            Path(o, $"M{N1(x)} {N1(b - h * 0.84)}L{N1(x + w / 2)} {N1(b - h)}L{N1(x + w)} {N1(b - h * 0.84)}Z", $"fill='{top}'");
            Rect(o, x + w * 0.38, b - h - 2, w * 0.24, 3, $"fill='{top}'");
            Rect(o, x, b - h * 0.56, w, h * 0.2, "fill='#ffffff' opacity='0.85'");
            Rect(o, x + w * 0.08, b - h * 0.82, Math.Max(1, w * 0.14), h * 0.78, "fill='#ffffff' opacity='0.28'");
        }
        static void Jug(StringBuilder o, double x, double b, double w, double h)
        {
            Path(o, $"M{N1(x)} {N1(b)}V{N1(b - h * 0.7)}Q{N1(x)} {N1(b - h * 0.86)} {N1(x + w * 0.3)} {N1(b - h * 0.88)}V{N1(b - h)}H{N1(x + w * 0.6)}V{N1(b - h * 0.88)}Q{N1(x + w)} {N1(b - h * 0.86)} {N1(x + w)} {N1(b - h * 0.7)}V{N1(b)}Z", "fill='#fbfdff' stroke='#c9d6e0' stroke-width='0.7'");
            Path(o, $"M{N1(x + w * 0.72)} {N1(b - h * 0.78)}Q{N1(x + w * 1.06)} {N1(b - h * 0.6)} {N1(x + w * 0.74)} {N1(b - h * 0.42)}", "stroke='#dbe5ec' stroke-width='2' fill='none'");
            Rect(o, x + w * 0.26, b - h - 3, w * 0.38, 4, "fill='#2f7fd6'", 1);
            Rect(o, x + w * 0.1, b - h * 0.45, w * 0.6, h * 0.18, "fill='#5fb8ff' opacity='0.7'", 1);
        }
        static void Can(StringBuilder o, double x, double b, double w, double h, string body)
        {
            Rect(o, x, b - h, w, h, $"fill='{body}'", w * 0.12);
            Rect(o, x, b - h, w, h * 0.1, "fill='#d6dde3'", w * 0.1);
            Rect(o, x + w * 0.16, b - h * 0.86, Math.Max(1, w * 0.16), h * 0.76, "fill='#ffffff' opacity='0.45'");
            Rect(o, x, b - h * 0.55, w, h * 0.12, "fill='#ffffff' opacity='0.75'");
        }
        static void Eggs(StringBuilder o, double x0, double x1, double b, double s)
        {
            int n = Math.Max(2, (int)Math.Floor((x1 - x0) / (s * 0.7)));
            double step = (x1 - x0) / n;
            for (int k = 0; k < n; k++)
            {
                Ellipse(o, x0 + step * (k + 0.5), b - s * 0.62, s * 0.29, s * 0.38, "fill='#fff1db' stroke='#dcc6a0' stroke-width='0.7'");
                Ellipse(o, x0 + step * (k + 0.5) - s * 0.09, b - s * 0.76, s * 0.07, s * 0.12, "fill='#ffffff' opacity='0.9'");
            }
        }
        // a bin's things, by which bin it is
        static void BinThings(StringBuilder o, int k, int bins, double x0, double x1, double b, double h)
        {
            double W = x1 - x0;
            if (k == 0 && bins >= 2) { Eggs(o, x0, x1, b, Math.Min(h * 0.95, 24)); return; }
            int set = k % 3;
            if (set == 0 || bins == 1)
            {
                Jug(o, x0 + W * 0.02, b, W * 0.26, h);
                Carton(o, x0 + W * 0.36, b, W * 0.24, h * 0.92, "#ff9a2e", "#ffd23a");
                Bottle(o, x0 + W * 0.7, b, W * 0.22, h * 0.95, "#e8303f", "#ffffff", "#ffd23a");
            }
            else if (set == 1)
            {
                Bottle(o, x0 + W * 0.02, b, W * 0.22, h, "#9fd8f6", "#2f7fd6", "#5fb8ff");
                Can(o, x0 + W * 0.32, b, W * 0.18, h * 0.62, "#e23d4a");
                Can(o, x0 + W * 0.54, b, W * 0.18, h * 0.62, "#2fbf71");
                Bottle(o, x0 + W * 0.76, b, W * 0.2, h * 0.86, "#ffd23a", "#c0392b");
            }
            else
            {
                Carton(o, x0 + W * 0.04, b, W * 0.26, h, "#ffffff", "#5fb8ff");
                Bottle(o, x0 + W * 0.38, b, W * 0.22, h * 0.9, "#7b3fa0", "#ffd23a", "#ffffff");
                Bottle(o, x0 + W * 0.68, b, W * 0.24, h * 0.8, "#3ddc97", "#ffffff");
            }
        }

        /// <summary>A door's inside (w x h, as seen from the front once it has swung past 90°, so mirrored here): its
        /// edge, the rubber gasket round it, the moulded liner and the bins with what's in them.</summary>
        public static string DoorBack(SortModel m, float w, float h)
        {
            const string id = "dk";
            double r = DoorRadius(m);
            int bins = Math.Max(1, Math.Min(5, (int)JsRound(h / 85.0)));
            var o = new StringBuilder();
            o.Append($"<g transform='matrix(-1 0 0 1 {D(w)} 0)'>");
            o.Append($"<defs>{Across(id + "l", Spread(new[] { "#dfe6ec", "#f7f9fb", "#eef2f5", "#d8e0e7" }))}{Down(id + "b", Stop(0, "#e9f6fd", 0.55) + Stop(1, "#9cc9e4", 0.85))}</defs>");
            Path(o, RR(0, 0, w, h, r), $"fill='{m.Finish.Edge}'");
            Path(o, RR(1.5, 1.5, w - 3, h - 3, Math.Max(1, r - 1)), $"fill='url(#{id}l)'");
            // the gasket
            Path(o, RR(4, 4, w - 8, h - 8, Math.Max(1, r - 1)), "fill='none' stroke='#a6b1bb' stroke-width='5'");
            Path(o, RR(2.6, 2.6, w - 5.2, h - 5.2, Math.Max(1, r - 1)), "fill='none' stroke='#dde3e8' stroke-width='1'");
            Path(o, RR(6.8, 6.8, w - 13.6, h - 13.6, Math.Max(1, r - 2)), "fill='none' stroke='#76828d' stroke-width='0.8' opacity='0.7'");
            // the moulded panel
            Path(o, RR(10, 10, w - 20, h - 20, 6), "fill='#ffffff' opacity='0.6' stroke='#c3cdd5' stroke-width='1'");
            for (int k = 0; k < bins; k++)
            {
                double y = h * (k + 0.78) / bins - 6, ih = Math.Min(34, h / bins * 0.62);
                BinThings(o, k, bins, 14, w - 14, y + 9, ih);
                Path(o, RR(9, y - 2, w - 18, 13, 3), $"fill='url(#{id}b)' stroke='#7aa6c2' stroke-width='0.9'");
                Rect(o, 11, y - 1.2, w - 22, 1.4, "fill='#ffffff' opacity='0.95'", 0.7);
                Rect(o, 9, y + 11, w - 18, 2, "fill='#000000' opacity='0.1'");
            }
            o.Append("</g>");
            return Dq(new UiSvg(w, h).Raw(o.ToString()).Markup);
        }

        // ---- the inside ------------------------------------------------------------------------------------------------
        // vegetables in a salad drawer: lettuce in the left one, tomatoes and carrots in the right one
        static void Veg(StringBuilder o, int k, double x, double y, double w, double h)
        {
            if (k == 0)
            {
                double r = Math.Min(h * 0.42, w * 0.16);
                var us = new[] { 0.22, 0.45, 0.68 };
                for (int j = 0; j < 3; j++)
                {
                    double u = us[j];
                    Circle(o, x + w * u, y + h * 0.58, r * (j == 1 ? 1.15 : 1), $"fill='{(j == 1 ? "#5fc96b" : "#7bdc6f")}'");
                    Path(o, $"M{N1(x + w * u)} {N1(y + h * 0.58 - r * 0.8)}V{N1(y + h * 0.58 + r * 0.8)}M{N1(x + w * u)} {N1(y + h * 0.58)}l{N1(-r * 0.5)} {N1(-r * 0.4)}M{N1(x + w * u)} {N1(y + h * 0.58)}l{N1(r * 0.5)} {N1(-r * 0.4)}", "stroke='#c9f5c0' stroke-width='1' fill='none'");
                }
                Circle(o, x + w * 0.88, y + h * 0.66, r * 0.7, "fill='#9c5fd0'");
                return;
            }
            double rr = Math.Min(h * 0.32, w * 0.12);
            foreach (var u in new[] { 0.2, 0.42 })
            {
                Circle(o, x + w * u, y + h * 0.62, rr, "fill='#ef3b2d'");
                Circle(o, x + w * u - rr * 0.35, y + h * 0.62 - rr * 0.35, rr * 0.28, "fill='#ffffff' opacity='0.6'");
                Path(o, $"M{N1(x + w * u - rr * 0.4)} {N1(y + h * 0.62 - rr)}l{N1(rr * 0.4)} {N1(rr * 0.3)} {N1(rr * 0.4)} {N1(-rr * 0.3)}", "stroke='#2e9e4f' stroke-width='1.4' fill='none'");
            }
            var cs = new[] { 0.62, 0.8 };
            for (int j = 0; j < 2; j++)
            {
                double u = cs[j];
                o.Append($"<g transform='rotate({(j == 1 ? 14 : -10)} {N1(x + w * u)} {N1(y + h * 0.6)})'>");
                Path(o, $"M{N1(x + w * u - rr * 0.5)} {N1(y + h * 0.3)}H{N1(x + w * u + rr * 0.5)}L{N1(x + w * u)} {N1(y + h)}Z", "fill='#ff8a1e'");
                Path(o, $"M{N1(x + w * u)} {N1(y + h * 0.3)}l-2.5 -5M{N1(x + w * u)} {N1(y + h * 0.3)}l2.5 -5M{N1(x + w * u)} {N1(y + h * 0.3)}v-6", "stroke='#3ddc6a' stroke-width='1.4' fill='none' stroke-linecap='round'");
                o.Append("</g>");
            }
        }

        // how deep it looks: the side walls' width, the ceiling's and the floor's height
        static int Depth(ContainerGeo g) => Math.Max(5, Math.Min(14, (int)JsRound(g.S * 0.12)));

        // the inside's View clips to its 4 dp corners (overflow: hidden, borderRadius 4)
        static string ClipOpen(UiSvg s, float W, float hd)
        {
            var cid = s.NewId("in");
            s.Def($"<clipPath id=\"{cid}\"><path d=\"{UiSvg.RRect(0, 0, W, hd, R4(4))}\"/></clipPath>");
            return $"<g clip-path='url(#{cid})'>";
        }

        /// <summary>The inside (W x H + crisper): the back wall with its ribs and vent, the ceiling, the side walls and
        /// the floor, the LED strip unlit, the shelves (glass or wire) each on its supports with its shadow below it, the
        /// salad drawers with the vegetables through their frosted fronts.</summary>
        public static string InsideBack(SortModel m, ContainerGeo g)
        {
            const string id = "is";
            var L = m.Liner;
            float S = g.S, W = g.W, H = g.H, crisper = g.Crisper, hd = H + crisper;
            int rows = g.Rows, cols = g.Cols;
            bool wire = m.Shelf == "wire";
            int d = Depth(g);
            double bt = d, bb = hd - JsRound(d * 0.7), dd = Math.Max(3, d * 0.55);
            var ribs = new StringBuilder();
            int nr = Math.Max(2, cols * 2);
            for (int k = 1; k < nr; k++) ribs.Append($"M{D(d + (W - 2 * d) * k / (double)nr)} {D(bt)}V{D(bb)}");
            var s = new UiSvg(W, hd);
            var o = new StringBuilder();
            o.Append(ClipOpen(s, W, hd));
            o.Append("<defs>")
                .Append(Down(id + "bk", Spread(new[] { L.Top, L.Bottom })))
                .Append(Across(id + "lw", Spread(new[] { L.Front, L.Back })))
                .Append(LG(id + "rw", "1", "0", "0", "0", Spread(new[] { L.Front, L.Back })))
                .Append(Down(id + "cl", Spread(new[] { "#ffffff", L.Back })))
                .Append(LG(id + "fl", "0", "1", "0", "0", Spread(new[] { L.Front, L.Back })))
                .Append(Down(id + "tr", Spread(new[] { "#ffffff", "#eef3f6", "#c0ccd5" })))
                .Append(Down(id + "sh", Stop(0, "#36495a", 0.2) + Stop(1, "#36495a", 0)))
                .Append(Down(id + "cr", Stop(0, "#f2fafe", 0.5) + Stop(1, "#a9d2ea", 0.78)))
                .Append(Down(id + "rod", Spread(SortModels.CHROME)))
                .Append("</defs>");
            Rect(o, 0, 0, W, hd, $"fill='{L.Back}'");
            // the back wall, its ribs and its vent
            Rect(o, d, bt, W - 2 * d, bb - bt, $"fill='url(#{id}bk)'");
            Path(o, ribs.ToString(), $"stroke='{L.Rib}' stroke-width='1' opacity='0.45'");
            Path(o, RR(W / 2 - 20, bt + 3, 40, 9, 3), $"fill='{L.Rib}' opacity='0.55'");
            for (int k = 0; k < 5; k++) Rect(o, W / 2 - 16 + k * 7, bt + 5, 4, 5, "fill='#7c8d9b' opacity='0.6'", 1);
            // the ceiling, the side walls and the floor
            Path(o, $"M0 0H{D(W)}L{D(W - d)} {D(bt)}H{D(d)}Z", $"fill='url(#{id}cl)'");
            Path(o, $"M0 0L{D(d)} {D(bt)}V{D(bb)}L0 {D(hd)}Z", $"fill='url(#{id}lw)'");
            Path(o, $"M{D(W)} 0L{D(W - d)} {D(bt)}V{D(bb)}L{D(W)} {D(hd)}Z", $"fill='url(#{id}rw)'");
            Path(o, $"M0 {D(hd)}L{D(d)} {D(bb)}H{D(W - d)}L{D(W)} {D(hd)}Z", $"fill='url(#{id}fl)'");
            Path(o, $"M0 0L{D(d)} {D(bt)}M{D(W)} 0L{D(W - d)} {D(bt)}M0 {D(hd)}L{D(d)} {D(bb)}M{D(W)} {D(hd)}L{D(W - d)} {D(bb)}M{D(d)} {D(bt)}V{D(bb)}M{D(W - d)} {D(bt)}V{D(bb)}", $"stroke='{L.Rib}' stroke-width='0.8' opacity='0.7'");
            // the LED strip, unlit
            Rect(o, d + 4, 1, W - 2 * d - 8, 3, "fill='#d5e0e7'", 1.5);
            // the shelves: glass or wire, each on its supports, its shadow below it
            for (int r = 0; r < rows; r++)
            {
                double y = (r + 1) * (S + SHELF) - SHELF;
                Rect(o, d, y + SHELF, W - 2 * d, Math.Min(12, S * 0.14), $"fill='url(#{id}sh)'");
                Path(o, $"M0 {N1(y + SHELF * 0.6)}L{D(d)} {N1(y - dd + 2)}M{D(W)} {N1(y + SHELF * 0.6)}L{D(W - d)} {N1(y - dd + 2)}", $"stroke='{L.Rib}' stroke-width='2.4'");
                if (wire)
                {
                    int nw = Math.Max(3, (int)Math.Floor(W / 9.0));
                    int den = Math.Max(2, (int)Math.Floor(W / 9.0) - 1);
                    var wd = new StringBuilder();
                    for (int k = 0; k < nw; k++)
                    {
                        double x = 4 + k * (W - 8) / (double)den;
                        wd.Append($"M{N1(x)} {N1(y + 1)}L{N1(d + x / W * (W - 2 * d))} {N1(y - dd)}");
                    }
                    Path(o, wd.ToString(), "stroke='#8f9aa5' stroke-width='1'");
                    Path(o, $"M{D(d)} {N1(y - dd)}H{D(W - d)}", "stroke='#8f9aa5' stroke-width='1.4'");
                    Rect(o, 0, y, W, 3.5, $"fill='url(#{id}rod)'", 1.75);
                    Rect(o, 0, y + 5, W, 2, $"fill='url(#{id}rod)' opacity='0.85'", 1);
                }
                else
                {
                    Path(o, $"M1 {N1(y)}L{D(d)} {N1(y - dd)}H{D(W - d)}L{D(W - 1)} {N1(y)}Z", "fill='#cbe7f5' opacity='0.5'");
                    Path(o, $"M{D(d)} {N1(y - dd)}H{D(W - d)}", "stroke='#ffffff' stroke-opacity='0.85' stroke-width='0.8'");
                    Rect(o, 0, y, W, SHELF, $"fill='url(#{id}tr)'");
                    Rect(o, 0, y, W, 1.3, "fill='#8fd0ec'");
                    Rect(o, 0, y + SHELF - 1, W, 1, "fill='#7f909e' opacity='0.75'");
                    Rect(o, W * 0.08, y + 2.4, W * 0.24, 1.2, "fill='#ffffff'", 0.6);
                }
            }
            // the salad drawers: the vegetables through their frosted fronts
            if (crisper > 0)
                for (int k = 0; k < 2; k++)
                {
                    double x = k == 1 ? W / 2 + 2 : 4, cw = W / 2 - 6, cy = H + 2, ch = crisper - 6;
                    Veg(o, k, x, cy, cw, ch);
                    Path(o, RR(x, cy, cw, ch, 5), $"fill='url(#{id}cr)' stroke='#86aac0' stroke-width='1.2'");
                    Rect(o, x + 3, cy + 1.6, cw - 6, 2, "fill='#ffffff' opacity='0.95'", 1);
                    Rect(o, x + cw * 0.36, cy + 5, cw * 0.28, 4, "fill='#4f6f84' opacity='0.45'", 2);
                    Path(o, $"M{N1(x + cw * 0.6)} {N1(cy + ch - 3)}L{N1(x + cw * 0.74)} {N1(cy + 6)}M{N1(x + cw * 0.7)} {N1(cy + ch - 3)}L{N1(x + cw * 0.78)} {N1(cy + 10)}", "stroke='#ffffff' stroke-opacity='0.55' stroke-width='1.6'");
                }
            o.Append("</g>");
            return Dq(s.Raw(o.ToString()).Markup);
        }

        /// <summary>The lamp: the LED strip lit and its glow down the inside (its opacity is the game's `light`).</summary>
        public static string Lamp(SortModel m, ContainerGeo g)
        {
            float W = g.W, hd = g.H + g.Crisper;
            int d = Depth(g);
            var s = new UiSvg(W, hd);
            var o = new StringBuilder();
            o.Append(ClipOpen(s, W, hd));
            o.Append($"<defs><radialGradient id='lamp' cx='50%' cy='0%' r='85%'>{Stop(0, "#ffffff", 0.9)}{Stop(0.45, "#f2fbff", 0.32)}{Stop(1, "#f2fbff", 0)}</radialGradient>");
            o.Append(Down("led", Stop(0, "#ffffff", 0.95) + Stop(1, "#ffffff", 0))).Append("</defs>");
            Rect(o, 0, 0, W, hd, "fill='url(#lamp)'");
            Rect(o, d + 4, 0, W - 2 * d - 8, 12, "fill='url(#led)'");
            Rect(o, d + 4, 1, W - 2 * d - 8, 3, "fill='#ffffff'", 1.5);
            o.Append("</g>");
            return Dq(s.Raw(o.ToString()).Markup);
        }
    }
}
