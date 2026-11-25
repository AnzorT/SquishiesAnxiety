// Squish Time's sky (src/squad/SkyBackground.js, PERF 2026-11-20): the app draws it as native pieces sized to the
// screen, not one SVG stretched over it: the vertical gradient (blue at the top through sand to peach), a soft white
// glow behind the toy, a warm glow rising from the bottom, three cloud puffs (solid to 52 % of their radius, then the
// linear falloff of assets/squad/sky/puff.png) and the white dot grid every 26 dp (dotgrid.png's dots: r 1.4, 80 %
// white, laid from the top-left corner). The glows' radii come from the screen's size, as the CSS "farthest-corner"
// gradients they replaced. Drawn once per screen size (SquishTime) as one picture; no UnityEngine here.
using System;
using System.Text;
using SquishSquad.Ui;

namespace SquishSquad.Games.Squish
{
    public static class SquishSky
    {
        static readonly (double x, double y, double fade, double a)[] PUFFS = { (0.16, 0.14, 44, 0.75), (0.26, 0.12, 36, 0.7), (0.84, 0.26, 38, 0.6) };
        static readonly (double at, string c)[] SKY = { (0, "#8fd0ff"), (0.38, "#b9e2ff"), (0.68, "#f3e6d6"), (1, "#ffdcb4") };
        const double DOT = 26, DOT_R = 1.4;

        static string F(double v) => UiSvg.F(v);

        /// <summary>The sky for a w x h dp screen, as SVG markup (w x h).</summary>
        public static string Svg(float w, float h)
        {
            var d = new StringBuilder();
            var b = new StringBuilder();
            d.Append("<linearGradient id=\"sky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\">");
            foreach (var (at, c) in SKY) d.Append($"<stop offset=\"{F(at)}\" stop-color=\"{c}\"/>");
            d.Append("</linearGradient>");
            // glow.png: white, alpha 1 at the centre falling linearly to 0 at the edge; puff.png: solid to 52 %
            d.Append("<radialGradient id=\"glow\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>");
            d.Append("<radialGradient id=\"warm\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#ffab5c\"/><stop offset=\"1\" stop-color=\"#ffab5c\" stop-opacity=\"0\"/></radialGradient>");
            d.Append("<radialGradient id=\"puff\" cx=\"0.5\" cy=\"0.5\" r=\"0.5\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.52\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>");

            b.Append($"<rect width=\"{F(w)}\" height=\"{F(h)}\" fill=\"#c9e4ff\"/>");
            b.Append($"<rect width=\"{F(w)}\" height=\"{F(h)}\" fill=\"url(#sky)\"/>");
            // circle at 50% 46%, transparent at 48% of the farthest-corner radius
            double glowR = 0.48 * Math.Sqrt(w / 2.0 * (w / 2.0) + h * 0.54 * (h * 0.54));
            b.Append($"<ellipse cx=\"{F(w / 2.0)}\" cy=\"{F(h * 0.46)}\" rx=\"{F(glowR)}\" ry=\"{F(glowR)}\" fill=\"url(#glow)\" opacity=\"0.55\"/>");
            // ellipse at 50% 112%: the farthest-corner radii are √2 x the side distances
            double rx = 0.62 * Math.Sqrt(2) * (w / 2.0), ry = 0.62 * Math.Sqrt(2) * (h * 1.12);
            b.Append($"<ellipse cx=\"{F(w / 2.0)}\" cy=\"{F(h * 1.12)}\" rx=\"{F(rx)}\" ry=\"{F(ry)}\" fill=\"url(#warm)\" opacity=\"0.6\"/>");
            foreach (var (x, y, fade, a) in PUFFS)
                b.Append($"<circle cx=\"{F(w * x)}\" cy=\"{F(h * y)}\" r=\"{F(fade)}\" fill=\"url(#puff)\" opacity=\"{F(a)}\"/>");
            // the dot grid: a dot at each 26 dp cell's centre (the 260 x 130 blocks laid from 0, 0 tile it exactly)
            b.Append("<g fill=\"#ffffff\" fill-opacity=\"0.8\">");
            for (double y = DOT / 2; y < h + DOT_R; y += DOT)
                for (double x = DOT / 2; x < w + DOT_R; x += DOT)
                    b.Append($"<circle cx=\"{F(x)}\" cy=\"{F(y)}\" r=\"{F(DOT_R)}\"/>");
            b.Append("</g>");
            return $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w)} {F(h)}\"><defs>{d}</defs>{b}</svg>";
        }
    }
}
