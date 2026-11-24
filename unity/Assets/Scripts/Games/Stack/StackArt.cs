// Squish Stack's drawings as SVG for UiPiece, copied from the app's components (src/stack/Pieces.js, the styles in
// src/stack/Game.js): the cushions, the star badge, the goal card, and the counter at the top in the middle (develop:
// MOVES n / par and the tier; Blitz: CLEARED, BEST and its rule). Positions are what Chrome lays out, checked by
// tools/unity/stack-test. Units are dp.
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
        public const string INK = "#5b3418";   // squishdoku/theme.js

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

        // ---- the counter (Game.js counterEl: develop, the user 2026-11-16: "my attempt / attempts for 3 stars", no stars, no
        // level, no game name, no clock) -------------------------------------------------------------------------------------
        static readonly TextStyle StatLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 9.5f, LetterSpacing = 1, Color = "#ffe6c2" };
        static readonly TextStyle StatNum = new TextStyle { Font = "Fredoka_700Bold", Size = 21, Color = "#ffe045" };
        static readonly TextStyle CountNum = new TextStyle { Font = "Fredoka_700Bold", Size = 22, Color = "#ffe045" };
        static readonly TextStyle CountPar = new TextStyle { Font = "Fredoka_700Bold", Size = 16, Color = "#ffe6c2" };
        static readonly TextStyle ChallengeText = new TextStyle { Font = "Fredoka_700Bold", Size = 10, LetterSpacing = 0.6f, Color = "#ffffff" };
        static readonly TextStyle ChipText = new TextStyle { Font = "Fredoka_700Bold", Size = 11.5f, LetterSpacing = 0.5f, Color = "#ffffff" };
        static readonly TextStyle GoalLabel = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, LetterSpacing = 1.2f, Color = "#6b3fa0" };

        /// <summary>The two side columns (Game.js styles.side: as wide as each other, so the cushions sit in the middle).</summary>
        public const float SideW = 200;

        public sealed class Counter
        {
            public bool Blitz;
            public int Moves, Par, Tier;        // a level: MOVES n / par (n red past par), the tier
            public int Cleared, Best;           // Blitz: CLEARED n, BEST n (NEW BEST in gold once beaten), the rule's chip
            public bool Beat;
        }

        // a Stat (label over number, centred, at least 44 wide): its width and height
        static (float w, float h) StatSize(string label, string value) =>
            (Math.Max(44, Math.Max(UiSvg.Width(label, StatLabel), UiSvg.Width(value, StatNum))), UiSvg.LineBox(StatLabel) + UiSvg.LineBox(StatNum));

        static (float w, float h) MovesSize(Counter d)
        {
            string num = d.Moves.ToString(CultureInfo.InvariantCulture), par = " / " + d.Par.ToString(CultureInfo.InvariantCulture);
            float lw = UiSvg.Width(num, CountNum) + UiSvg.Width(par, CountPar);
            return (Math.Max(44, Math.Max(UiSvg.Width("MOVES", StatLabel), lw)), UiSvg.LineBox(StatLabel) + UiSvg.LineBox(CountNum));
        }

        static float ChipW(string text, TextStyle t, float padH) => UiSvg.Width(text, t) + 2 * padH + 2 * 2;

        /// <summary>The counter's box: a row (gap 12, 12 x 3 padding, a 2 dp border) of the stats and the chips.</summary>
        public static (float w, float h) CounterSize(Counter d)
        {
            var parts = new List<(float w, float h)>();
            if (d.Blitz) { parts.Add(StatSize("CLEARED", d.Cleared.ToString(CultureInfo.InvariantCulture))); parts.Add(StatSize(d.Beat ? "NEW BEST" : "BEST", d.Best.ToString(CultureInfo.InvariantCulture))); }
            else parts.Add(MovesSize(d));
            parts.Add((ChipW(Levels.TIER_NAMES[d.Tier], ChallengeText, 7), UiSvg.LineBox(ChallengeText) + 2 + 4));
            if (d.Blitz) parts.Add((ChipW("1 MISTAKE = GAME OVER", ChipText, 9), UiSvg.LineBox(ChipText) + 6 + 4));
            float w = 0, h = 0;
            foreach (var p in parts) { w += p.w; h = Math.Max(h, p.h); }
            return (w + 12 * (parts.Count - 1) + 2 * 12 + 2 * 2, h + 2 * 3 + 2 * 2);
        }

        /// <summary>The counter (Game.js styles.counter): on dark glass with a white rim, its parts centred down the row.</summary>
        public static string CounterSvg(Counter d)
        {
            var (w, h) = CounterSize(d);
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 16, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            float x = 2 + 12, inner = h - 4 - 6, top = 2 + 3;
            void Stat(string label, string value, bool gold)
            {
                var (sw, sh) = StatSize(label, value);
                float y = top + (inner - sh) / 2;
                var lt = gold ? new TextStyle { Font = StatLabel.Font, Size = StatLabel.Size, LetterSpacing = StatLabel.LetterSpacing, Color = "#ffd23a" } : StatLabel;
                var nt = gold ? new TextStyle { Font = StatNum.Font, Size = StatNum.Size, Color = "#ffd23a" } : StatNum;
                s.Text(label, x, y, lt, sw, 0.5f);
                s.Text(value, x, y + UiSvg.LineBox(StatLabel), nt, sw, 0.5f);
                x += sw + 12;
            }
            void Chip(string text, TextStyle t, float padH, float padV, string bg)
            {
                float cw = ChipW(text, t, padH), ch = UiSvg.LineBox(t) + 2 * padV + 4;
                float y = top + (inner - ch) / 2;
                s.Box(x, y, cw, ch, new BoxStyle { Background = bg, Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(text, x + 2 + padH, y + 2 + padV, t);
                x += cw + 12;
            }
            if (d.Blitz)
            {
                Stat("CLEARED", d.Cleared.ToString(CultureInfo.InvariantCulture), false);
                Stat(d.Beat ? "NEW BEST" : "BEST", d.Best.ToString(CultureInfo.InvariantCulture), d.Beat);
            }
            else
            {
                // MOVES over "n / par" (one line: the number and the par sit on one baseline; n turns pink past par)
                var (mw, mh) = MovesSize(d);
                float y = top + (inner - mh) / 2;
                s.Text("MOVES", x, y, StatLabel, mw, 0.5f);
                string num = d.Moves.ToString(CultureInfo.InvariantCulture), par = " / " + d.Par.ToString(CultureInfo.InvariantCulture);
                var nt = d.Moves > d.Par ? new TextStyle { Font = CountNum.Font, Size = CountNum.Size, Color = "#ff8fa3" } : CountNum;
                float lw = UiSvg.Width(num, nt) + UiSvg.Width(par, CountPar), lx = x + (mw - lw) / 2, ly = y + UiSvg.LineBox(StatLabel);
                s.Text(num, lx, ly, nt);
                float baseline = UiSvg.Baseline(nt, ly);
                s.Text(par, lx + UiSvg.Width(num, nt), baseline - (UiSvg.Baseline(CountPar, 0)), CountPar);
                x += mw + 12;
            }
            Chip(Levels.TIER_NAMES[d.Tier], ChallengeText, 7, 1, Levels.TIER_COLORS[d.Tier]);
            if (d.Blitz) Chip("1 MISTAKE = GAME OVER", ChipText, 9, 3, "#e01e4a");
            return s.Markup;
        }

        /// <summary>Pieces.js GoalCard on its own (118 wide): (markup, height).</summary>
        public static (string svg, float h) Goal(Squishy[] who, int[] goal, int k, int star)
        {
            var probe = new UiSvg(118, 200);
            float h = GoalCard(probe, 0, 0, 118, who, goal, k, star);
            var s = new UiSvg(118, h);
            GoalCard(s, 0, 0, 118, who, goal, k, star);
            return (s.Markup, h);
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
