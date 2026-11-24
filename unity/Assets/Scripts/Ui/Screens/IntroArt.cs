// src/squad/IntroBackground.js: the intro screens' background (log in / register, verify, the splash): blue at the
// top through pale blue to cream and peach, under white dots every 26 dp. The app's own SVG, except its <pattern>
// (the vector renderer has none): each tile's dot is drawn as the pattern draws it, a circle r 1.3 at (1, 1) cut by
// its tile's top and left edges.
using System;
using System.Globalization;
using System.Text;

namespace SquishSquad.Ui.Screens
{
    public static class IntroArt
    {
        static string F(double v) => Math.Round(v, 4).ToString("0.####", CultureInfo.InvariantCulture);

        static string _cached; static float _cw, _ch;

        public static string Svg(float w, float h)
        {
            if (_cached != null && _cw == w && _ch == h) return _cached;
            _cw = w; _ch = h;
            return _cached = Build(w, h);
        }

        static string Build(float w, float h)
        {
            var sb = new StringBuilder();
            sb.Append($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w)} {F(h)}\">");
            sb.Append("<defs><linearGradient id=\"introBg\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\">");
            sb.Append("<stop offset=\"0\" stop-color=\"#8fd0ff\"/><stop offset=\"0.38\" stop-color=\"#b9e2ff\"/><stop offset=\"0.68\" stop-color=\"#fff1d6\"/><stop offset=\"1\" stop-color=\"#ffd9a8\"/>");
            sb.Append("</linearGradient></defs>");
            sb.Append($"<rect width=\"{F(w)}\" height=\"{F(h)}\" fill=\"url(#introBg)\"/>");
            sb.Append("<path fill=\"rgb(255,255,255)\" fill-opacity=\"0.8\" d=\"").Append(Dots(w, h)).Append("\"/>");
            sb.Append("</svg>");
            return sb.ToString();
        }

        // circle (1, 1) r 1.3 inside x >= 0, y >= 0: the edge crosses x = 0 at y = 1 -+ c and y = 0 at x = 1 -+ c
        static string Dots(float w, float h)
        {
            const double r = 1.3, c = 0.830662386;   // sqrt(1.3^2 - 1)
            var sb = new StringBuilder();
            for (double ty = 0; ty < h; ty += 26)
                for (double tx = 0; tx < w; tx += 26)
                {
                    // from (0, 1 - c) down the cut to (0, 1 + c), the big arc round to (1 + c, 0), along the cut to (1 - c, 0),
                    // the small arc back to the start
                    sb.Append('M').Append(F(tx)).Append(' ').Append(F(ty + 1 - c))
                      .Append('L').Append(F(tx)).Append(' ').Append(F(ty + 1 + c))
                      .Append($"A{F(r)} {F(r)} 0 1 0 {F(tx + 1 + c)} {F(ty)}")
                      .Append('L').Append(F(tx + 1 - c)).Append(' ').Append(F(ty))
                      .Append($"A{F(r)} {F(r)} 0 0 0 {F(tx)} {F(ty + 1 - c)}Z");
                }
            return sb.ToString();
        }
    }
}
