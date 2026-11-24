// Squish Hop's drawings as SVG, copied from the app's components (src/hop/Pieces.js, the styles in src/hop/Game.js,
// src/crib/Hud.js's RoomTitle): the cushions and dance tiles in the board's perspective (BoardGeometry), the arrows
// printed on them, the dents under them, the hint's glow, the bubbles, the ★ with its lock count, the numbered
// friends' chips, a squishy's shadow, the goal card's flat cushion and stickers, the stars meter and the pills.
// Units are dp. The markup is what react-native-svg writes on the web page (radial gradients keep their rx / ry,
// which Chrome ignores and the vector renderer ignores too).
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;

namespace SquishSquad.Games.Hop
{
    public static class HopArt
    {
        public const string DARK = "#140818";
        public const double GAP = 0.04;          // between cushions, in tiles
        public const double PILE_Z = 0.17;       // how high the top cushion of a pile sits
        public const double PILE_TOP = PILE_Z;
        public static readonly string[] DANCE_TILE = { "#7cb8ff", "#ff5c8a", "#ffd66b", "#5cf2c8" };
        public static readonly string[] BEAT_COL = { "#ff5c8a", "#7cb8ff", "#ffd66b" };
        public static readonly string[] BEAT_NAMES = { "pink", "blue", "yellow" };
        public const string STAR_D = "M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z";

        public static readonly Dictionary<string, (string c1, string c2, string ring)> CUSH = new Dictionary<string, (string, string, string)>
        {
            ["pink"] = ("#ffd9f3", "#ff86d3", "#a3168f"),
            ["mint"] = ("#cffff7", "#3fd6c6", "#0b6670"),
            ["lilac"] = ("#ebdcff", "#a77bff", "#4b1ca0"),
            ["peach"] = ("#fff0cf", "#ffb257", "#9c4d06"),
        };

        static string F(double v) => UiSvg.F(v);
        // JS's String(number) for numbers that go into markup the app writes as they are (close enough: 6 places)
        static string N(double v) => Math.Round(v, 6).ToString("0.######", CultureInfo.InvariantCulture);

        // a colour mixed toward the dance floor's dark (`k` of the colour)
        static string Dim(string hex, double k)
        {
            int n = Convert.ToInt32(hex.Substring(1), 16), d = Convert.ToInt32(DARK.Substring(1), 16);
            int Mix(int sh) => (int)Math.Floor(((n >> sh) & 255) * k + ((d >> sh) & 255) * (1 - k) + 0.5);
            return $"rgb({Mix(16)},{Mix(8)},{Mix(0)})";
        }

        // ---- the board ---------------------------------------------------------------------------------------------

        /// <summary>A cushion on cell (x, y) at height z, `k` of full size, relative to (ox, oy) (Pieces.js cushionParts).</summary>
        public static void Cushion(System.Text.StringBuilder sb, BoardLayout B, int x, int y, double z, double k, string col, string id, double ox, double oy)
        {
            var c = CUSH[col];
            double S = (1 - 2 * GAP) * k, cx = x + 0.5, cy = y + 0.5;
            double Rr(double d) => Math.Max(0.01, (S / 2 - d) * 0.42);
            string Rect(double d, double dv = 0) => BoardGeometry.RoundRect(B, cx - S / 2 + d, cy - S / 2 + d + dv, cx + S / 2 - d, cy + S / 2 - d + dv, Rr(d), z, ox, oy);
            var mid = BoardGeometry.Project(B, cx, cy + 0.03 * S, z);
            double px = mid.S;
            double stroke = Math.Max(1.2, B.T * 0.032);
            sb.Append($"<defs><radialGradient cx=\"50%\" cy=\"34%\" rx=\"70%\" ry=\"70%\" id=\"{id}\"><stop offset=\"0\" stop-color=\"{c.c1}\"/><stop offset=\"1\" stop-color=\"{c.c2}\"/></radialGradient></defs>");
            sb.Append($"<path d=\"{Rect(0, 0.06 * S)}\" fill=\"{c.ring}\"/>");
            sb.Append($"<path d=\"{Rect(0)}\" fill=\"{c.ring}\"/>");
            sb.Append($"<path d=\"{Rect(0.035 * S)}\" fill=\"#ffffff\"/>");
            sb.Append($"<path d=\"{Rect(0.075 * S)}\" fill=\"url(#{id})\"/>");
            sb.Append($"<path d=\"{Rect(0.17 * S)}\" fill=\"none\" stroke=\"rgba(255,255,255,0.75)\" stroke-width=\"{N(stroke)}\" stroke-dasharray=\"{N(stroke * 2.5)} {N(stroke * 2)}\"/>");
            sb.Append($"<ellipse cx=\"{N(mid.X - ox)}\" cy=\"{N(mid.Y - oy)}\" rx=\"{N(0.065 * S * px)}\" ry=\"{N(0.055 * S * px * 0.8)}\" fill=\"{c.ring}\" opacity=\"0.45\"/>");
        }

        /// <summary>An arrow printed on a cushion: the chevron, white over a shadow of `ink`.</summary>
        static void Arrow(System.Text.StringBuilder sb, BoardLayout B, int x, int y, double z, int dir, double size, string ink, double ox, double oy)
        {
            var pts = BoardGeometry.Chevron(x + 0.5, y + 0.5, dir, size);
            var d = BoardGeometry.PolyPath(B, pts, z, ox, oy);
            var sh = new double[3][];
            for (int i = 0; i < 3; i++) sh[i] = new[] { pts[i][0], pts[i][1] + 0.03 };
            var shadow = BoardGeometry.PolyPath(B, sh, z, ox, oy);
            double w = Math.Max(2.4, B.T * 0.11 * size);
            sb.Append($"<path d=\"{shadow}\" stroke=\"{ink}\" stroke-width=\"{N(w)}\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>");
            sb.Append($"<path d=\"{d}\" stroke=\"#ffffff\" stroke-width=\"{N(w)}\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>");
        }

        /// <summary>A dance-floor tile: its colour with a light rim and a glow; a beat tile is dark until it's lit.</summary>
        static void DanceTile(System.Text.StringBuilder sb, BoardLayout B, int x, int y, string col, bool beat, bool lit, string id, double ox, double oy)
        {
            double g = Math.Min(0.03, 1.5 / B.T);
            var shape = BoardGeometry.RoundRect(B, x + g, y + g, x + 1 - g, y + 1 - g, 0.06, 0, ox, oy);
            var inner = BoardGeometry.RoundRect(B, x + 0.07, y + 0.07, x + 0.93, y + 0.93, 0.05, 0, ox, oy);
            bool off = beat && !lit;
            sb.Append($"<defs><radialGradient cx=\"50%\" cy=\"45%\" rx=\"62%\" ry=\"62%\" id=\"{id}\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"{(off ? "0.12" : "0.75")}\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient></defs>");
            if (lit) sb.Append($"<path d=\"{BoardGeometry.RoundRect(B, x - 0.05, y - 0.05, x + 1.05, y + 1.05, 0.12, 0, ox, oy)}\" fill=\"{col}\" opacity=\"0.45\"/>");
            sb.Append($"<path d=\"{shape}\" fill=\"{(off ? Dim(col, 0.32) : col)}\"/>");
            sb.Append($"<path d=\"{inner}\" fill=\"none\" stroke=\"{(off ? col : lit ? "rgba(255,255,255,0.9)" : "rgba(255,255,255,0.28)")}\" stroke-width=\"{N(Math.Max(2, B.T * 0.045))}\"/>");
            sb.Append($"<path d=\"{shape}\" fill=\"url(#{id})\"/>");
        }

        /// <summary>The dance floor's tile colour for cell (x, y).</summary>
        public static string DanceColor(int x, int y, bool goal, int beat, bool beats)
        {
            if (goal) return "#ffffff";
            if (beat >= 0) return BEAT_COL[beat];
            if (beats) return DANCE_TILE[3];
            return DANCE_TILE[y % 2 == 0 ? (x % 2 != 0 ? 1 : 0) : x % 2 != 0 ? 2 : 3];
        }

        /// <summary>How a cell looks (Game.js looks): fixed for the level, but a beat tile has a lit look too.</summary>
        public struct Look
        {
            public bool Dance, Goal, Pile, Beats, Lit;
            public string Color;
            public int Arrow, Beat;
        }

        /// <summary>Tile's box: what cell i's drawing fits in.</summary>
        public static CellBox TileBox(BoardLayout B, int i, bool pile) => BoardGeometry.CellBoxOf(B, i % B.W, i / B.W, pile ? PILE_Z + 0.04 : 0.02, 0.1);

        /// <summary>Pieces.js Tile: the bottom cushion (or dance tile) of cell i, in its box.</summary>
        public static string TileBottom(BoardLayout B, int i, Look look, CellBox box)
        {
            int x = i % B.W, y = i / B.W;
            double ox = box.Left, oy = box.Top;
            string ink = look.Dance ? DARK : CUSH[look.Color].ring;
            var sb = new System.Text.StringBuilder();
            if (look.Dance)
            {
                DanceTile(sb, B, x, y, DanceColor(x, y, look.Goal, look.Beat, look.Beats), look.Beat >= 0, look.Lit, $"hop{i}d", ox, oy);
                if (look.Arrow >= 0 && !look.Pile) Arrow(sb, B, x, y, 0, look.Arrow, 0.62, ink, ox, oy);
            }
            else
            {
                Cushion(sb, B, x, y, 0, 1, look.Goal ? "peach" : look.Color, $"hop{i}a", ox, oy);
                if (look.Arrow >= 0 && !look.Pile) Arrow(sb, B, x, y, 0, look.Arrow, 0.5, ink, ox, oy);
            }
            return Wrap(sb, box.Width, box.Height);
        }

        /// <summary>Pieces.js Tile: the top cushion of a pile (in the Dance Room, a ring of light), in its box.</summary>
        public static string TileTop(BoardLayout B, int i, Look look, CellBox box)
        {
            int x = i % B.W, y = i / B.W;
            double ox = box.Left, oy = box.Top;
            string ink = look.Dance ? DARK : CUSH[look.Color].ring;
            var sb = new System.Text.StringBuilder();
            if (look.Dance)
            {
                var ring = BoardGeometry.RoundRect(B, x + 0.19, y + 0.19, x + 0.81, y + 0.81, 0.12, 0.02, ox, oy);
                double w = Math.Max(2, B.T * 0.05);
                sb.Append($"<path d=\"{ring}\" fill=\"none\" stroke=\"rgba(255,255,255,0.35)\" stroke-width=\"{N(w * 3)}\"/>");
                sb.Append($"<path d=\"{ring}\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"{N(w)}\"/>");
                if (look.Arrow >= 0) Arrow(sb, B, x, y, 0.02, look.Arrow, 0.5, ink, ox, oy);
            }
            else
            {
                Cushion(sb, B, x, y, PILE_Z, 0.94, look.Color, $"hop{i}b", ox, oy);
                if (look.Arrow >= 0) Arrow(sb, B, x, y, PILE_Z, look.Arrow, 0.47, ink, ox, oy);
            }
            return Wrap(sb, box.Width, box.Height);
        }

        // an <svg> of w x h (react-native-svg's, which clips to its box)
        static string Wrap(System.Text.StringBuilder inner, double w, double h) =>
            $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{N(w)}\" height=\"{N(h)}\" viewBox=\"0 0 {N(w)} {N(h)}\">{inner}</svg>";

        /// <summary>Pieces.js Under: the dents where the cushions are (they show once a cushion has puffed away), or the
        /// Dance Room's dark floor with its pink glow; the area's size.</summary>
        public static string Under(BoardLayout B, IList<int> cells, bool dance, string dent, double width, double height)
        {
            var sb = new System.Text.StringBuilder();
            if (dance)
            {
                var edge = BoardGeometry.RoundRect(B, -0.08, -0.08, B.W + 0.08, B.H + 0.08, 0.3, 0, 0, 0);
                sb.Append($"<path d=\"{edge}\" fill=\"none\" stroke=\"rgba(255,92,198,0.3)\" stroke-width=\"{N(B.T * 0.2)}\"/>");
                sb.Append($"<path d=\"{edge}\" fill=\"{DARK}\" stroke=\"#2a1430\" stroke-width=\"3\"/>");
            }
            else
            {
                double w = Math.Max(1.6, B.T * 0.04);
                foreach (int i in cells)
                {
                    int x = i % B.W, y = i / B.W;
                    double S = (1 - 2 * GAP) * 0.84;
                    sb.Append($"<path d=\"{BoardGeometry.RoundRect(B, x + 0.5 - S / 2, y + 0.5 - S / 2, x + 0.5 + S / 2, y + 0.5 + S / 2, S * 0.22, 0, 0, 0)}\" fill=\"none\" stroke=\"{dent ?? "rgba(91,58,41,0.4)"}\" stroke-width=\"{N(w)}\" stroke-dasharray=\"{N(w * 2.4)} {N(w * 1.8)}\"/>");
                }
            }
            return Wrap(sb, width, height);
        }

        /// <summary>Pieces.js HintGlow: a gold outline round the cell to hop to (pulsing: its opacity), in its box.</summary>
        public static string HintGlow(BoardLayout B, int i, double z, out CellBox box)
        {
            int x = i % B.W, y = i / B.W;
            box = BoardGeometry.CellBoxOf(B, x, y, z, 0.16);
            var d = BoardGeometry.RoundRect(B, x - 0.04, y - 0.04, x + 1.04, y + 1.04, 0.26, z, box.Left, box.Top);
            double w = Math.Max(2.5, B.T * 0.055);
            var sb = new System.Text.StringBuilder();
            sb.Append($"<path d=\"{d}\" fill=\"rgba(255,226,92,0.25)\" stroke=\"rgba(255,226,92,0.55)\" stroke-width=\"{N(w * 3)}\"/>");
            sb.Append($"<path d=\"{d}\" fill=\"none\" stroke=\"#ffd23a\" stroke-width=\"{N(w)}\"/>");
            return Wrap(sb, box.Width, box.Height);
        }

        /// <summary>Pieces.js Bubble: a soap bubble `size` across.</summary>
        public static string Bubble(int i, double size)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append($"<defs><radialGradient cx=\"34%\" cy=\"30%\" rx=\"75%\" ry=\"75%\" id=\"bub{i}\">" +
                "<stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.12\" stop-color=\"#ffffff\"/><stop offset=\"0.15\" stop-color=\"#ffffff\" stop-opacity=\"0.6\"/>" +
                "<stop offset=\"0.42\" stop-color=\"#96d6ff\" stop-opacity=\"0.55\"/><stop offset=\"0.72\" stop-color=\"#c8aaff\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#ffaae1\" stop-opacity=\"0.75\"/></radialGradient></defs>");
            sb.Append($"<circle cx=\"{N(size / 2)}\" cy=\"{N(size / 2)}\" r=\"{N(size / 2 - 1)}\" fill=\"url(#bub{i})\" stroke=\"rgba(60,120,190,0.55)\" stroke-width=\"1.5\"/>");
            sb.Append($"<circle cx=\"{N(size / 2)}\" cy=\"{N(size / 2)}\" r=\"{N(size / 2 - 2.6)}\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.2\"/>");
            return Wrap(sb, size, size);
        }

        /// <summary>Pieces.js Star: the ★ badge, grey while it's shut, as markup in a `size` box at (x, y).</summary>
        public static string StarAt(double x, double y, double size, bool shut) =>
            $"<svg x=\"{N(x)}\" y=\"{N(y)}\" width=\"{N(size)}\" height=\"{N(size)}\" viewBox=\"0 0 24 24\">" +
            $"<path d=\"{STAR_D}\" fill=\"{(shut ? "#9a8fa8" : "#b86200")}\" stroke-linejoin=\"round\" transform=\"translate(0 1.4)\"/>" +
            $"<path d=\"{STAR_D}\" fill=\"{(shut ? "#e3dcea" : "#ffd23a")}\" stroke=\"#ffffff\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/></svg>";

        static readonly TextStyle Display = new TextStyle { Font = "Fredoka_700Bold", Color = "#ffffff" };

        /// <summary>A round orange chip with a number (GoalStar's lock count, OrderChip): box (x, y), its height, at least
        /// `minW` wide, 3 dp padding, a 2 dp white border; the number centred. Returns its width.</summary>
        public static float Chip(UiSvg s, float x, float y, float minW, float h, float radius, string text, float fontSize, bool rightAligned = false)
        {
            var t = new TextStyle { Font = Display.Font, Size = fontSize, Color = "#ffffff" };
            float tw = UiSvg.BoxWidth(text, t);
            float w = Math.Max(minW, tw + 2 * 3 + 2 * 2);
            if (rightAligned) x -= w;
            s.Box(x, y, w, h, new BoxStyle { Background = "#ff8a3d", Radius = radius, BorderWidth = 2, BorderColor = "#ffffff" });
            float lh = UiSvg.LineBox(t);
            s.Text(text, x + 2 + 3, y + 2 + (h - 4 - lh) / 2, t, w - 10, 0.5f);
            return w;
        }

        /// <summary>Pieces.js GoalStar's drawing: the ★ `size` across and, while cushions are still to clear, how many
        /// are left (a chip at its top right). Drawn in a size x size box.</summary>
        public static string GoalStar(double size, int left)
        {
            var s = new UiSvg((float)size, (float)size);
            s.Raw(StarAt(0, 0, size, left > 0));
            if (left > 0)
            {
                float h = (float)(size * 0.46);
                // right: -16 %, top: -10 % of the star's box
                Chip(s, (float)(size * 1.16), (float)(-size * 0.1), h, h, (float)size, left.ToString(CultureInfo.InvariantCulture), (float)Math.Max(9, Math.Floor(size * 0.34 + 0.5)), true);
            }
            return s.Markup;
        }

        /// <summary>Pieces.js OrderChip: a numbered friend's chip, `size` tall, centred on (size / 2, size / 2) of its own
        /// box. Returns its markup; `w` its width.</summary>
        public static string OrderChip(int n, float size, out float w)
        {
            var t = new TextStyle { Font = Display.Font, Size = Math.Max(9, size * 0.5f) };
            w = Math.Max(size, UiSvg.BoxWidth(n.ToString(CultureInfo.InvariantCulture), t) + 10);
            var s = new UiSvg(w, size);
            Chip(s, 0, 0, size, size, size, n.ToString(CultureInfo.InvariantCulture), Math.Max(9, size * 0.5f));
            return s.Markup;
        }

        /// <summary>Pieces.js Piece's shadow: a rounded bar of `shade`, w x h.</summary>
        public static string Shadow(float w, float h, string shade) => new UiSvg(w, h).Box(0, 0, w, h, new BoxStyle { Background = shade, Radius = 999 }).Markup;

        /// <summary>Pieces.js FlatCushion: a cushion seen from straight above, as markup at (x, y).</summary>
        public static string FlatCushion(double x, double y, double size, string col, string id)
        {
            var c = CUSH[col];
            double k = size / 2, r = k - 1;
            double Rr(double d) => (r - d) * 0.42;
            string Rect(double d, double dy = 0)
            {
                double x0 = k - r + d, y0 = k - r + d + dy, s = 2 * (r - d), q = Rr(d);
                return $"M{N(x0 + q)} {N(y0)} H{N(x0 + s - q)} Q{N(x0 + s)} {N(y0)} {N(x0 + s)} {N(y0 + q)} V{N(y0 + s - q)} Q{N(x0 + s)} {N(y0 + s)} {N(x0 + s - q)} {N(y0 + s)} H{N(x0 + q)} Q{N(x0)} {N(y0 + s)} {N(x0)} {N(y0 + s - q)} V{N(y0 + q)} Q{N(x0)} {N(y0)} {N(x0 + q)} {N(y0)} Z";
            }
            return $"<svg x=\"{N(x)}\" y=\"{N(y)}\" width=\"{N(size)}\" height=\"{N(size * 1.06)}\" overflow=\"visible\"><defs><radialGradient cx=\"50%\" cy=\"34%\" rx=\"70%\" ry=\"70%\" id=\"{id}\"><stop offset=\"0\" stop-color=\"{c.c1}\"/><stop offset=\"1\" stop-color=\"{c.c2}\"/></radialGradient></defs>" +
                $"<path d=\"{Rect(0, size * 0.06)}\" fill=\"{c.ring}\"/><path d=\"{Rect(0)}\" fill=\"{c.ring}\"/><path d=\"{Rect(size * 0.035)}\" fill=\"#ffffff\"/><path d=\"{Rect(size * 0.075)}\" fill=\"url(#{id})\"/>" +
                $"<path d=\"{Rect(size * 0.17)}\" fill=\"none\" stroke=\"rgba(255,255,255,0.75)\" stroke-width=\"{N(Math.Max(1, size / 30))}\" stroke-dasharray=\"{N(size / 12)} {N(size / 15)}\"/>" +
                $"<ellipse cx=\"{N(k)}\" cy=\"{N(k + size * 0.03)}\" rx=\"{N(size * 0.065)}\" ry=\"{N(size * 0.055)}\" fill=\"{c.ring}\" opacity=\"0.45\"/></svg>";
        }
    }
}
