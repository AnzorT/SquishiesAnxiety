// What a ported screen draws, as a list of pieces: each an SVG in its own dp box (UiSvg), where it goes (any 2D
// transform, in screen dp) and its opacity, in drawing order. The Unity host (App/ScreenHost.cs) shows each one as a
// UiPiece (redrawn only when its SVG changes, so a piece that only moves costs nothing); the checks
// (tools/unity/auth-test) put them all into one SVG and draw that next to the app's screenshot.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Screens
{
    public sealed class ScreenPiece
    {
        public string Id;
        public string Svg;          // UiSvg markup, W x H dp, (0, 0) its top-left
        public float W, H;
        public float Margin = 6;    // dp drawn round the box (shadows, outlines that reach out)
        public Affine Transform = Affine.Identity;   // piece dp -> screen dp
        public float Opacity = 1;
        /// <summary>Not an SVG: a slot the host fills (the live creature), at Transform, W x H.</summary>
        public bool Slot;
        /// <summary>A live creature the host draws on its rig (with Slot): the chest unlock's hero.</summary>
        public LiveCreature Live;

        public ScreenPiece At(float x, float y) { Transform = Affine.Translate(x, y); return this; }
    }

    /// <summary>The chest unlock's creature on its rig (tools/chest/host.html rigLive / popAt): which one, how long since
    /// the BAM brought it out, its place (feet at Fx, Fy, its body as big as fits W x H, screen dp) and the burst's
    /// middle (Cy), which it grows out of.</summary>
    public sealed class LiveCreature
    {
        public string Key;
        public double Ms;
        public float Fx, Fy, W, H, Cy;
    }

    public static class Pieces
    {
        /// <summary>Device pixels per dp to snap the pieces' positions to (0, the default: not snapped; snapping to
        /// 2.8125 made the comparison with Chrome slightly worse, tools/unity/auth-test).</summary>
        public static float SnapScale = 0;
        public static float Snap(float dp) => SnapScale > 0 ? (float)(Math.Round(dp * SnapScale) / SnapScale) : dp;

        static string F(double v) => v.ToString("0.####", CultureInfo.InvariantCulture);

        /// <summary>All the pieces as one SVG (w x h dp): each nested with its transform and opacity, its ids prefixed
        /// so they don't clash.</summary>
        public static string Compose(IEnumerable<ScreenPiece> pieces, float w, float h)
        {
            var sb = new StringBuilder($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"0 0 {F(w)} {F(h)}\">");
            int n = 0;
            foreach (var p in pieces)
            {
                if (p.Slot || string.IsNullOrEmpty(p.Svg) || p.Opacity <= 0) continue;
                var pre = "q" + (n++) + "-";
                var svg = p.Svg;
                int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>");
                var inner = svg.Substring(a, b - a).Replace("id=\"", "id=\"" + pre).Replace("href=\"#", "href=\"#" + pre).Replace("url(#", "url(#" + pre);
                var m = p.Transform;
                sb.Append($"<g transform=\"matrix({F(m.A)} {F(m.B)} {F(m.C)} {F(m.D)} {F(m.E)} {F(m.F)})\"");
                if (p.Opacity < 1) sb.Append($" opacity=\"{F(p.Opacity)}\"");
                sb.Append('>').Append(inner).Append("</g>");
            }
            sb.Append("</svg>");
            return sb.ToString();
        }
    }
}
