// Squish Stack's drawings as SVG for UiPiece, copied from the app's components (src/stack/Pieces.js, the styles in
// src/stack/Game.js): the cushions, the star badge, the stars meter, the goal card, and the HUD's left column as the
// landscape layout lays it out (REDESIGN_V8: wLeft is 250 dp wide; positions are what Chrome lays out, checked by
// tools/unity/stack-test). Units are dp.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;

namespace SquishSquad.Games.Stack
{
    /// <summary>A squishy: its cut-out (Resources/Stack/art/&lt;file&gt;) and its height / width.</summary>
    public sealed class Squishy
    {
        public string Key, Picture;
        public float Ar;
        public float BodyH(float w) => w * Ar;   // a bundled cut-out is just the body (box 0, 0, 1, 1)
    }

    public static class StackArt
    {
        public const float OVER = 0.24f;

        public static readonly (string c1, string c2, string ring)[] CUSHIONS =
        {
            ("#ffd9f3", "#ff86d3", "#a3168f"),
            ("#cffff7", "#3fd6c6", "#0b6670"),
            ("#ebdcff", "#a77bff", "#4b1ca0"),
            ("#fff0cf", "#ffb257", "#9c4d06"),
        };

        const string STAR_D = "M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z";
        static string F(double v) => UiSvg.F(v);

        // Pieces.js Cushion: a puffy cushion seen from the front (w x h + its 5 dp lip)
        public static string Cushion(float w, float h, int i)
        {
            var c = CUSHIONS[i % CUSHIONS.Length];
            const float lip = 5;
            string id = "stackCush" + i;
            var s = new UiSvg(w, h + lip);
            s.Def($"<radialGradient id=\"{id}\" cx=\"50%\" cy=\"26%\" rx=\"62%\" ry=\"78%\"><stop offset=\"0\" stop-color=\"{c.c1}\"/><stop offset=\"1\" stop-color=\"{c.c2}\"/></radialGradient>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2 + lip)}\" rx=\"{F(w / 2 - 1)}\" ry=\"{F(h / 2 - 1)}\" fill=\"{c.ring}\"/>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(w / 2 - 1)}\" ry=\"{F(h / 2 - 1)}\" fill=\"{c.ring}\"/>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(w / 2 - 3)}\" ry=\"{F(h / 2 - 3)}\" fill=\"#ffffff\"/>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(w / 2 - 6)}\" ry=\"{F(h / 2 - 6)}\" fill=\"url(#{id})\"/>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h / 2)}\" rx=\"{F(Math.Max(4, w / 2 - 14))}\" ry=\"{F(Math.Max(3, h / 2 - 9))}\" fill=\"none\" stroke=\"rgba(255,255,255,0.75)\" stroke-width=\"2\" stroke-dasharray=\"5 4\"/>");
            s.Raw($"<ellipse cx=\"{F(w / 2)}\" cy=\"{F(h * 0.56)}\" rx=\"4.5\" ry=\"3\" fill=\"{c.ring}\" opacity=\"0.45\"/>");
            return s.Markup;
        }

        // Pieces.js StarBadge, as markup inside a `size` box at (x, y)
        public static string StarBadgeAt(float x, float y, float size) =>
            $"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(size)}\" height=\"{F(size)}\" viewBox=\"0 0 24 24\" overflow=\"visible\">" +
            $"<path d=\"{STAR_D}\" fill=\"#b86200\" transform=\"translate(0 1.4)\" stroke-linejoin=\"round\"/>" +
            $"<path d=\"{STAR_D}\" fill=\"#ffd23a\" stroke=\"#ffffff\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/></svg>";

        public static string StarBadge(float size) => new UiSvg(size, size).Raw(StarBadgeAt(0, 0, size)).Markup;

        // ---- the HUD's left column (Game.js topEl, landscape) ----------------------------------------------------------
        static readonly TextStyle GameName = new TextStyle { Font = "Fredoka_700Bold", Size = 13, LetterSpacing = 1, Color = "#8a3a0e" };
        static readonly TextStyle LevelText = new TextStyle { Font = "Fredoka_700Bold", Size = 21, Color = "#ffffff", Shadows = new[] { new Shadow("#6b4426", 0, 2.5f, 1) } };
        static readonly TextStyle ChallengeText = new TextStyle { Font = "Fredoka_700Bold", Size = 10, LetterSpacing = 0.6f, Color = "#ffffff" };
        static readonly TextStyle MovesLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 10, LetterSpacing = 1, Color = "#ffffff" };
        static readonly TextStyle MovesNum = new TextStyle { Font = "Fredoka_700Bold", Size = 22, Color = "#ffe045" };
        static readonly TextStyle GoalLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, LetterSpacing = 1.2f, Color = "#6b3fa0" };
        static readonly TextStyle ParText = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#b86200", LetterSpacing = 0.6f };
        static readonly TextStyle Tip = new TextStyle { Font = "Nunito_800ExtraBold", Size = 12.5f, LineHeight = 16, Color = "#6b4426" };
        static readonly TextStyle ClockText = new TextStyle { Font = "Fredoka_700Bold", Size = 14, Color = "#6b4426" };

        public const float LeftW = 250;

        public sealed class Hud
        {
            public int Lv, Tier, Moves, Par, Stars, K, Star;
            public string TipText;      // null when the level has a clock
            public string ClockText;    // "1:05" (the clock row), or null
            public float ClockFrac;     // the bar, 0..1 of the time left
            public bool ClockRed;
            public Squishy[] Who;
            public int[] Goal;
        }

        /// <summary>The left column (everything but the back orb), 250 x `h` dp from the screen's top-left.</summary>
        public static string LeftColumn(Hud d, float h)
        {
            var s = new UiSvg(LeftW, h);
            // the top bar's title box (the orb is its own piece): x 62 = 12 padding + 40 orb + 10 gap; 41 tall from y 12
            s.Text("SQUISH STACK", 62, 12, GameName);
            var lvl = "LEVEL " + d.Lv;
            s.Text(lvl, 62, 28, LevelText);
            float chipX = 62 + UiSvg.Width(lvl, LevelText) + 6;
            var tier = Levels.TIER_NAMES[d.Tier];
            float chipW = UiSvg.Width(tier, ChallengeText) + 2 * 7 + 2 * 2;
            // the chip: 1 + 2 border + 12 line + ... = 18 tall, centred on the 25 dp row
            s.Box(chipX, 31.5f, chipW, 18, new BoxStyle { Background = Levels.TIER_COLORS[d.Tier], Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text(tier, chipX + 2 + 7, 31.5f + 2 + 1, ChallengeText);
            // the moves pill wraps under the orb: 12, 59; min 64 wide
            var num = d.Moves.ToString(CultureInfo.InvariantCulture);
            float inner = Math.Max(UiSvg.Width("MOVES", MovesLabel), UiSvg.Width(num, MovesNum));
            float pw = Math.Max(64, inner + 2 * 10 + 2 * 2);
            s.Box(12, 59, pw, 48, new BoxStyle { Background = "rgba(107,68,38,0.5)", Radius = 16, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text("MOVES", 12 + 2, 59 + 2 + 3, MovesLabel, pw - 4, 0.5f);
            s.Text(num, 12 + 2, 59 + 2 + 3 + 12, MovesNum, pw - 4, 0.5f);
            // the goal card at 12, 119 (118 wide), then the meter row at 12, 222
            float gh = GoalCard(s, 12, 119, 118, d.Who, d.Goal, d.K, d.Star);
            float ry = 119 + gh + 10;
            float iy = ry;   // (the info column: the goal card, 10 dp, then the meter row)
            Meter(s, 12, iy, d.Stars);
            var par = "PAR " + d.Par;
            float parW = UiSvg.Width(par, ParText) + 2 * 10 + 2 * 2;
            s.Box(92, iy + 1, parW, 24, new BoxStyle { Background = "#ffffff", Radius = 999, BorderWidth = 2, BorderColor = "#ffd23a" });
            s.Text(par, 92 + 12, iy + 1 + 4, ParText);
            if (d.TipText != null) s.Text(d.TipText, 12, iy + 32, Tip);
            else if (d.ClockText != null)
            {
                var ct = d.ClockRed ? new TextStyle { Font = ClockText.Font, Size = ClockText.Size, Color = "#e01e4a" } : ClockText;
                s.Text(d.ClockText, 12, iy + 32, ct);
                float bx = 12 + Math.Max(40, UiSvg.Width(d.ClockText, ct)) + 8;
                Bar(s, bx, iy + 32 + 2.5f, 238 - bx, 12, d.ClockFrac, "#b8ffd9", "#3ddc97");
            }
            return s.Markup;
        }

        // sort/Game.js Bar: a rounded track with the fill's gradient
        static void Bar(UiSvg s, float x, float y, float w, float h, float frac, string c1, string c2)
        {
            s.Box(x, y, w, h, new BoxStyle { Background = "rgba(255,255,255,0.55)", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            float fw = Math.Max(0, Math.Min(1, frac)) * (w - 4);
            if (fw > 0) s.Box(x + 2, y + 2, fw, h - 4, new BoxStyle { Gradient = new[] { c1, c2 }, Radius = 999 });
        }

        // Game.js Meter: three stars (21, 26, 21 dp; the small ones 4 dp lower), gap 1
        public static void Meter(UiSvg s, float x, float y, int stars)
        {
            float cx = x;
            for (int i = 0; i < 3; i++)
            {
                float size = i == 1 ? 26 : 21, top = y + (i == 1 ? 0 : 4);
                bool on = i < stars;
                s.Raw($"<svg x=\"{F(cx)}\" y=\"{F(top)}\" width=\"{F(size)}\" height=\"{F(size)}\" viewBox=\"0 0 24 24\" overflow=\"visible\"><path d=\"{STAR_D}\" fill=\"{(on ? "#ffd23a" : "rgba(255,255,255,0.55)")}\" stroke=\"{(on ? "#b86200" : "#b9a6cc")}\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></svg>");
                cx += size + 1;
            }
        }

        // Pieces.js GoalCard: each cushion with the squishies that end up on it, small. Returns its height.
        public static float GoalCard(UiSvg s, float x, float y, float width, Squishy[] who, int[] goal, int k, int star)
        {
            int n = who.Length;
            const float ROOM = 56;
            Func<float, int, float> sized = (m, r) => m * (n == 1 ? 1 : 0.5f + 0.5f * r / (n - 1));
            Func<float, float> tallest = m =>
            {
                float best = 0;
                for (int p = 0; p < k; p++)
                {
                    float t = 0;
                    for (int r = 0; r < n; r++) if (goal[r] == p) t += who[r].BodyH(sized(m, r)) * (1 - OVER);
                    best = Math.Max(best, t);
                }
                return best;
            };
            float fit = Math.Min(26, (width - 14) / k - 4);
            float maxW = fit * Math.Min(1, ROOM / Math.Max(1, tallest(fit)));
            // columns: bottom to top the cushion (22 x 7), then its squishies biggest first, each sinking OVER into the last
            var colW = new float[k]; var colH = new float[k];
            for (int p = 0; p < k; p++)
            {
                colW[p] = 22; colH[p] = 7;
                for (int r = n - 1; r >= 0; r--)
                    if (goal[r] == p) { float w = sized(maxW, r); colW[p] = Math.Max(colW[p], w); colH[p] += who[r].BodyH(w) * (1 - OVER); }
            }
            float rowH = 0; foreach (var c in colH) rowH = Math.Max(rowH, c);
            float h = 3 + 2 + 12 + 4 + rowH + 6 + 3;
            s.Box(x, y, width, h, new BoxStyle { Background = "rgba(255,255,255,0.95)", Radius = 16, BorderWidth = 3, BorderColor = "#ffffff" });
            s.Text("GOAL", x + 3, y + 3 + 2, GoalLabel, width - 6, 0.5f);
            // justify-content: space-around in the 102 dp between the padding
            float innerX = x + 3 + 5, innerW = width - 6 - 10, used = 0;
            foreach (var c in colW) used += c;
            float around = (innerW - used) / k;
            float bottom = y + h - 3 - 6, cxp = innerX + around / 2;
            for (int p = 0; p < k; p++)
            {
                float mid = cxp + colW[p] / 2;
                var cu = CUSHIONS[p];
                s.Box(mid - 11, bottom - 7, 22, 7, new BoxStyle { Background = cu.c2, Radius = 4, BorderWidth = 1.5f, BorderColor = cu.ring });
                float yb = bottom - 7;
                for (int r = n - 1; r >= 0; r--)
                {
                    if (goal[r] != p) continue;
                    // (its marginBottom of -bh x OVER: it sinks that far into what's under it)
                    float w = sized(maxW, r), bh = who[r].BodyH(w), top = yb + bh * OVER - bh;
                    s.Image(who[r].Picture, mid - w / 2, top, w, bh);
                    yb = top;
                }
                if (star == p) s.Raw(StarBadgeAt(mid - 6, bottom + 9 - 12, 12));
                cxp += colW[p] + around;
            }
            return h;
        }
    }
}
