// Where things are in a Squishdoku level, as the app works them out:
//   Board     src/hop/board.js: the board lying on the room's floor, leaned back and seen in perspective (worked out by
//             hand, not a 3D transform, so the cushions, the creatures standing on them and the taps all use the same
//             numbers). Board units: a cell is 1 x 1, (u, v) a point on the plane, z its height, in cells.
//   Room      src/hop/Room.js roomGeometry (the room picture's size and place) and src/hop/levels.js ROOMS.
// Pure functions, no UnityEngine. Units are dp.
using System;
using System.Globalization;
using System.Text;

namespace SquishSquad.Games.Squishdoku
{
    /// <summary>board.js layout(): { w, h, T, cx, cy, tilt, c, sn }.</summary>
    public sealed class Board
    {
        public int W, H;
        public double T, Cx, Cy, Tilt, C, Sn;

        public const double TILT = 38, DEPTH = 13;
        /// <summary>RoomBoard.js SDK_TILT: leaned back less than Squish Hop's, so the bigger boards keep big cells.</summary>
        public const double SDK_TILT = 30;

        public struct P { public double X, Y, S; public P(double x, double y, double s) { X = x; Y = y; S = s; } }

        static P Unit(double w, double h, double u, double v, double z, double c, double sn)
        {
            double X = u - w / 2, Y = v - h / 2;
            double yr = Y * c - z * sn, zr = Y * sn + z * c;
            double s = DEPTH / (DEPTH - zr);
            return new P(X * s, yr * s, s);
        }

        /// <summary>Where a w x h board goes in an area aw x ah whose floor starts floorY down.</summary>
        public static Board Layout(int w, int h, double aw, double ah, double floorY = 0, double tilt = TILT, double maxT = 96)
        {
            double c = Math.Cos(tilt * Math.PI / 180), sn = Math.Sin(tilt * Math.PI / 180);
            var front = Unit(w, h, w, h, 0, c, sn);
            var back = Unit(w, h, 0, 0, 0, c, sn);
            double uw = 2 * front.X, uh = front.Y - back.Y;
            double top = Math.Max(0, floorY);
            double space = ah - top + ah * 0.06;
            double T = Math.Max(26, Math.Floor(Math.Min(Math.Min((aw - 10) / uw, space / uh), maxT)));
            double bottom = Math.Min(ah - 8, top + (ah - top) / 2 + uh * T / 2);
            return new Board { W = w, H = h, T = T, Cx = aw / 2, Cy = bottom - front.Y * T, Tilt = tilt, C = c, Sn = sn };
        }

        /// <summary>A point on the board on screen: { x, y, s } (s: dp per cell there).</summary>
        public P Project(double u, double v, double z = 0)
        {
            var p = Unit(W, H, u, v, z, C, Sn);
            return new P(Cx + p.X * T, Cy + p.Y * T, p.S * T);
        }

        /// <summary>The cell under a point (in the board area), or -1.</summary>
        public int CellAt(double sx, double sy)
        {
            double x = (sx - Cx) / T, y = (sy - Cy) / T;
            double Y = y * DEPTH / (DEPTH * C + y * Sn);
            double s = DEPTH / (DEPTH - Y * Sn);
            double u = x / s + W / 2.0, v = Y + H / 2.0;
            if (u < 0 || v < 0 || u >= W || v >= H) return -1;
            return (int)Math.Floor(v) * W + (int)Math.Floor(u);
        }

        /// <summary>Where a creature stands on cell i (a bit in front of the middle), `z` up.</summary>
        public P StandOn(int i, double z = 0) => Project(i % W + 0.5, i / W + 0.56, z);

        // ---- shapes, as SVG paths relative to (ox, oy) ---------------------------------------------------------------
        /// <summary>JS toFixed(1).</summary>
        public static string Fx1(double v)
        {
            double r = Math.Floor(v * 10 + 0.5) / 10;
            var s = r.ToString("0.0", CultureInfo.InvariantCulture);
            return s == "-0.0" ? "0.0" : s;
        }

        public string RoundRect(double x0, double y0, double x1, double y1, double r, double z, double ox, double oy)
        {
            var sb = new StringBuilder();
            const int seg = 4;
            double[][] corners = { new[] { x1 - r, y0 + r, -Math.PI / 2 }, new[] { x1 - r, y1 - r, 0 }, new[] { x0 + r, y1 - r, Math.PI / 2 }, new[] { x0 + r, y0 + r, Math.PI } };
            int k = 0;
            foreach (var c in corners)
                for (int j = 0; j <= seg; j++)
                {
                    double a = c[2] + (double)j / seg * (Math.PI / 2);
                    var p = Project(c[0] + r * Math.Cos(a), c[1] + r * Math.Sin(a), z);
                    if (k > 0) sb.Append(' ');
                    sb.Append(k++ > 0 ? 'L' : 'M').Append(Fx1(p.X - ox)).Append(' ').Append(Fx1(p.Y - oy));
                }
            return sb.Append(" Z").ToString();
        }

        public string PolyPath(double[][] pts, double z, double ox, double oy)
        {
            var sb = new StringBuilder();
            for (int k = 0; k < pts.Length; k++)
            {
                var p = Project(pts[k][0], pts[k][1], z);
                if (k > 0) sb.Append(' ');
                sb.Append(k > 0 ? 'L' : 'M').Append(Fx1(p.X - ox)).Append(' ').Append(Fx1(p.Y - oy));
            }
            return sb.ToString();
        }

        public struct Box { public double Left, Top, Width, Height; }

        /// <summary>The box on screen that cell (x, y)'s drawing fits in, up to height z.</summary>
        public Box CellBox(int x, int y, double z = 0, double pad = 0.06)
        {
            P[] pts =
            {
                Project(x - pad, y - pad, z), Project(x + 1 + pad, y - pad, z), Project(x - pad, y + 1 + pad, 0),
                Project(x + 1 + pad, y + 1 + pad, 0), Project(x - pad, y - pad, 0), Project(x + 1 + pad, y - pad, 0),
            };
            double l = double.MaxValue, t = double.MaxValue, r = double.MinValue, b = double.MinValue;
            foreach (var p in pts) { l = Math.Min(l, p.X); t = Math.Min(t, p.Y); r = Math.Max(r, p.X); b = Math.Max(b, p.Y); }
            double left = Math.Floor(l), top = Math.Floor(t);
            return new Box { Left = left, Top = top, Width = Math.Ceiling(r) - left, Height = Math.Ceiling(b) - top };
        }
    }

    /// <summary>The Crib's rooms (hop/levels.js ROOMS) and how a room picture is laid out (hop/Room.js).</summary>
    public static class Rooms
    {
        public sealed class Room { public string Key, Name, Bg; public double Floor, Cx; public bool Dance; }

        public static readonly Room[] All =
        {
            new Room { Key = "living", Name = "Living Room", Floor = 200 / 393.0, Cx = 0.5, Bg = "#dba163" },
            new Room { Key = "kitchen", Name = "Kitchen", Floor = 236 / 393.0, Cx = 0.42, Bg = "#efc499" },
            new Room { Key = "bath", Name = "Bathroom", Floor = 236 / 393.0, Cx = 0.45, Bg = "#ffffff" },
            new Room { Key = "bed", Name = "Bedroom", Floor = 212 / 393.0, Cx = 0.5, Bg = "#dba163" },
            new Room { Key = "yard", Name = "Yard", Floor = 214 / 393.0, Cx = 0.66, Bg = "#96cb74" },
            new Room { Key = "dance", Name = "Dance Room", Floor = 200 / 393.0, Cx = 0.24, Bg = "#3b2030", Dance = true },
        };

        public static Room Of(string key) { foreach (var r in All) if (r.Key == key) return r; return All[0]; }

        /// <summary>crib/data.js PH: each time of day's label, sun colour and tint over the scene.</summary>
        public static (string label, string sun, string tint) Phase(string phase)
        {
            switch (phase)
            {
                case "morning": return ("MORNING", "#ffe38a", "rgba(255,170,140,0.05)");
                case "evening": return ("EVENING", "#ffb36b", "rgba(90,20,120,0.1)");
                case "night": return ("NIGHT", "#fff6d8", "rgba(20,24,70,0.22)");
                default: return ("DAYTIME", "#fff3a0", null);
            }
        }

        public const double RATIO = 1704.0 / 786;   // the room pictures' width / height

        public struct Geo { public double W, H, Left, Top, FloorY; }

        public static double FloorLineOf(double height) => Math.Round(Math.Min(330, Math.Max(190, height * 0.32)));

        public static Geo Geometry(string room, double width, double height)
        {
            var R = Of(room);
            if (width > height)
            {
                // landscape: the picture spans the width, raised so its floor line sits 30% down; the floor repeated below
                double H = width / RATIO;
                double top = Math.Min(0, JsRound(height * 0.3) - H * R.Floor);
                return new Geo { W = width, H = H, Left = 0, Top = top, FloorY = H * R.Floor + top };
            }
            double floorY = FloorLineOf(height);
            double h = floorY / R.Floor;
            if (h * RATIO < width) h = width / RATIO;
            double w = h * RATIO;
            double left = Math.Min(0, Math.Max(width - w, width / 2 - R.Cx * w));
            return new Geo { W = w, H = h, Left = left, Top = 0, FloorY = h * R.Floor };
        }

        static double JsRound(double v) => Math.Floor(v + 0.5);

        /// <summary>The room's pictures (Resources/Squishdoku/rooms): its base, and the layers for the time of day.</summary>
        public static (string under, string bas, string over) Pictures(string room, string phase)
        {
            string P(string n) => "Squishdoku/rooms/" + room + "-" + n;
            switch (room)
            {
                case "yard": return (P("under-" + phase), P("base"), null);
                case "bath": case "dance": return (null, P("base"), P("over-day"));
                default: return (null, P("base"), P("over-" + phase));
            }
        }

        /// <summary>Room.js: the room filling a `width` x `height` screen as one SVG: its colour, the floor repeated below the
        /// picture, the picture's layers (the things over the floor cut off at the floor line), the time of day's tint.</summary>
        public static string Svg(string room, string phase, double width, double height)
        {
            var R = Of(room);
            var g = Geometry(room, width, height);
            var (under, bas, over) = Pictures(room, phase);
            string F(double v) => SquishSquad.Ui.UiSvg.F(v);
            var sb = new StringBuilder($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(width)}\" height=\"{F(height)}\" viewBox=\"0 0 {F(width)} {F(height)}\">");
            sb.Append($"<defs><clipPath id=\"roomClip\"><rect x=\"0\" y=\"0\" width=\"{F(width)}\" height=\"{F(height)}\"/></clipPath>");
            sb.Append($"<clipPath id=\"overClip\"><rect x=\"0\" y=\"0\" width=\"{F(g.W)}\" height=\"{F(g.H * (R.Floor + 0.012))}\"/></clipPath></defs>");
            sb.Append($"<rect x=\"0\" y=\"0\" width=\"{F(width)}\" height=\"{F(height)}\" fill=\"{R.Bg}\"/>");
            sb.Append($"<g clip-path=\"url(#roomClip)\"><g transform=\"translate({F(g.Left)} {F(g.Top)})\">");
            string Img(string href, double top) => $"<image href=\"{href}\" x=\"0\" y=\"{F(top)}\" width=\"{F(g.W)}\" height=\"{F(g.H)}\" preserveAspectRatio=\"none\"/>";
            double step = g.H * (1 - R.Floor) - g.H * 0.06;
            var copies = new System.Collections.Generic.List<double>();
            for (int k = 1; g.Top + g.H + (k - 1) * step < height; k++) copies.Add(g.H + (k - 1) * step - (R.Floor + 0.05) * g.H);
            copies.Reverse();
            foreach (var top in copies) sb.Append(Img(bas, top));
            if (under != null) sb.Append(Img(under, 0));
            sb.Append(Img(bas, 0));
            if (over != null) sb.Append($"<g clip-path=\"url(#overClip)\">{Img(over, 0)}</g>");
            sb.Append("</g></g>");
            var tint = Phase(phase).tint;
            if (tint != null) sb.Append($"<rect x=\"0\" y=\"0\" width=\"{F(width)}\" height=\"{F(height)}\" fill=\"{tint}\"/>");
            return sb.Append("</svg>").ToString();
        }
    }
}
