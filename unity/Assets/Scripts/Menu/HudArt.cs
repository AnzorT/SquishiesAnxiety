// The Main Menu's HUD parts that show the player's numbers, drawn from the Unity code so they can change: the coin and
// gem pills (webgame/app/menu.js + main-menu.js: the wood pill, its rim, stripes, shadows and the number with its
// outline; the pill grows with the number and the top row reflows from the right edge) and the level crest's number
// and XP ring (menu.js M.crest). Everything else of the HUD stays the exported pictures (tools/unity/export-menu.mjs:
// the pill's coin / gem picture, the crest without its number). Plain C#, no Unity: MenuView puts the SVGs on screen,
// tools/unity/auth-test checks them against the app's menu with the same numbers.
//
// Units: the HUD's own CSS px (the page scales the whole HUD by k = 384 / 393 on a phone held sideways); the SVGs are
// drawn at that scale so they come out in dp.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Ui;

namespace SquishSquad.Menu
{
    /// <summary>What the HUD shows of the player (App.js gamePlayer: coins, wallet gems, xpView).</summary>
    public sealed class HudValues
    {
        public double Coins = 100, Gems = 600;
        public int Level = 1;
        public double Into, Need;
        public bool HasXp;              // a signed-in player's profile (the crest shows the XP ring)

        /// <summary>What the exported menu shows (the prototype's demo save, no XP): the offline / signed-out dev menu.</summary>
        public static HudValues Baked => new HudValues();

        public const double XpPerLevel = 100;   // config/levels' default (functions/squad.js DEFAULT_LEVELS)
        public const double StartGems = 600;    // functions/squad.js START.gems: a profile without `gems` yet

        static double Num(object v) => v is double d && !double.IsNaN(d) && !double.IsInfinity(d) ? d : v is long l ? l : v is int i ? i : 0;

        public static double XpToNext(double L) => XpPerLevel * (Math.Max(1, Math.Floor(L)) + 1);
        public static double XpToReach(double L) => L <= 1 ? 0 : XpPerLevel * (L * (L + 1) - 2) / 2;

        /// <summary>src/playerXp.js pxpOf: `pxp`, or a profile from before player XP: its level's XP plus its Squishdoku XP.</summary>
        public static double PxpOf(IDictionary<string, object> p)
        {
            if (p != null && p.TryGetValue("pxp", out var x) && x is double d) return Math.Max(0, d);
            double level = p != null && p.TryGetValue("level", out var lv) && lv != null ? Num(lv) : 1;
            double sdk = 0;
            if (p != null && p.TryGetValue("sdk", out var s) && s is IDictionary<string, object> sm && sm.TryGetValue("xp", out var sx)) sdk = Num(sx);
            return XpToReach(Math.Max(1, Math.Floor(level))) + Math.Max(0, Math.Floor(sdk));
        }

        /// <summary>functions/squad.js playerLevel: { level, into, need }.</summary>
        public static (int level, double into, double need) PlayerLevel(double pxp)
        {
            double x = Math.Max(0, Math.Floor(double.IsNaN(pxp) || double.IsInfinity(pxp) ? 0 : pxp));
            double L = Math.Max(1, Math.Floor((Math.Sqrt(9 + 8 * x / XpPerLevel) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return ((int)L, x - XpToReach(L), XpToNext(L));
        }

        public static HudValues FromProfile(IDictionary<string, object> p)
        {
            if (p == null) return Baked;
            var (lv, into, need) = PlayerLevel(PxpOf(p));
            p.TryGetValue("coins", out var c);
            p.TryGetValue("gems", out var g);
            return new HudValues { Coins = Num(c), Gems = g == null ? StartGems : Num(g), Level = lv, Into = into, Need = need, HasXp = true };
        }

        /// <summary>Number(n).toLocaleString('en-US'): 1,234,567 (up to 3 decimals).</summary>
        public static string Fmt(double n)
        {
            var s = Math.Round(n, 3).ToString("#,##0.###", CultureInfo.InvariantCulture);
            return s == "-0" ? "0" : s;
        }

        public bool SameAs(HudValues o) => o != null && o.Coins == Coins && o.Gems == Gems && o.Level == Level && o.Into == Into && o.Need == Need && o.HasXp == HasXp;
    }

    public static class HudArt
    {
        public const float K = 384f / 393f;      // the HUD's scale on a 384 dp tall screen (main-menu.js layout(): H / 393)
        const string Ink = "#6b4426";

        // ---- the pills (.mm-pill.mm-p.v-vel, REDESIGN_V8 wood) ------------------------------------------------------
        public const float PillH = 32, PillBorder = 2, PadL = 32, PadR = 14;
        public static readonly TextStyle PillText = new TextStyle
        {
            Font = "Fredoka_700Bold", Size = 14, LetterSpacing = 0.6f, Color = "#fff6e2",
            // .tx-w: text-shadow 0 1.6px 0, 1.2px 0 0, -1.2px 0 0, 0 -1.2px 0, 1px 1px 0, -1px 1px 0 (the ink)
            Shadows = new[] { new Shadow(Ink, 0, 1.6f, 0), new Shadow(Ink, 1.2f, 0, 0), new Shadow(Ink, -1.2f, 0, 0), new Shadow(Ink, 0, -1.2f, 0), new Shadow(Ink, 1, 1, 0), new Shadow(Ink, -1, 1, 0) },
        };

        /// <summary>A pill's width (HUD px) for this number.</summary>
        public static float PillWidth(string text) => PillBorder * 2 + PadL + PadR + UiSvg.BoxWidth(text, PillText);

        /// <summary>The top row's pills (HUD px, from the HUD's left; the HUD is `hudW` px wide): .mm-top right 30, the
        /// gear and trophy orbs 40 wide, gaps 7 plus their margins (10, 14, 26).</summary>
        public static (float coinsX, float coinsW, float gemsX, float gemsW, float y) PillRow(float hudW, string coins, string gems)
        {
            float right = hudW - 30 - 40 - (10 + 7) - 40 - (14 + 7);
            float gw = PillWidth(gems), cw = PillWidth(coins);
            float gx = right - gw, cx = gx - (26 + 7) - cw;
            return (cx, cw, gx, gw, 9 + (40 - PillH) / 2);
        }

        static string F(double v) => UiSvg.F(v);

        /// <summary>The pill (its box, shadows reaching out round it) and its number, as SVG `w` x PillH HUD px drawn at
        /// `scale` (K: dp).</summary>
        public static UiSvg Pill(string text, float scale = K)
        {
            float w = PillWidth(text), h = PillH;
            var s = new UiSvg(w * scale, h * scale);
            s.Open($"transform=\"scale({F(scale)})\"");
            Body(s, w, h, PillBorder, 999, 22, "rgba(107,68,38,0.09)",
                new[] { "#e6b47c", "#cf955a", "#b47a42" }, new[] { 0f, 0.55f, 1f },
                new[] { "#f8dcae", "#d9a066", "#a86e3a" }, new[] { 0f, 0.5f, 1f });
            float tw = UiSvg.BoxWidth(text, PillText);
            float lh = UiSvg.LineBox(PillText);
            s.Text(text, PillBorder + PadL, PillBorder + (h - 2 * PillBorder - lh) / 2, PillText);
            s.Close();
            return s;
        }

        /// <summary>A .mm-p wood box: box-shadows (the ink ring and lip, a soft drop), the rim gradient in the border, the
        /// panel gradient and its stripes in the padding box, and the two inset shadows (a light top edge, a dark bottom).</summary>
        static void Body(UiSvg s, float w, float h, float bw, float radius, float stripe, string stripeColor, string[] panel, float[] panelStops, string[] rim, float[] rimStops)
        {
            float R = Math.Min(radius, Math.Min(w, h) / 2);
            float[] Rs(float r) => new[] { r, r, r, r };
            // outer shadows, the last listed at the bottom
            s.Box(0, 0, w, h, new BoxStyle
            {
                Radius = R,
                Shadows = new[] { new Shadow(Ink, 0, 0, 0, 1.6f), new Shadow(Ink, 0, 3, 0, 1.6f), new Shadow("rgba(20,0,50,0.38)", 0, 6, 12) },
            });
            // the rim: a gradient over the border box
            s.Box(0, 0, w, h, new BoxStyle { Radius = R, Gradient = rim, GradientStops = rimStops });
            // the panel and the stripes, in the padding box
            float px = bw, py = bw, pw = w - 2 * bw, ph = h - 2 * bw, pr = Math.Max(0, R - bw);
            s.Box(px, py, pw, ph, new BoxStyle { Radius = pr, Gradient = panel, GradientStops = panelStops });
            var clip = s.NewId("pc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, py, pw, ph, Rs(pr))}\"/></clipPath>");
            var sb = new StringBuilder();
            for (float x = 0; x < pw; x += stripe) sb.Append($"M{F(px + x)} {F(py)}h2v{F(ph)}h-2Z");
            s.Raw($"<g clip-path=\"url(#{clip})\"><path d=\"{sb}\" fill=\"{stripeColor}\"/>");
            // inset shadows: inside the padding box, around it shifted by the offset
            string hole(float dx, float dy) => UiSvg.RRect(px + dx, py + dy, pw, ph, Rs(pr));
            string big = $"M{F(px - 50)} {F(py - 50)}H{F(px + pw + 50)}V{F(py + ph + 50)}H{F(px - 50)}Z";
            s.Raw($"<path fill-rule=\"evenodd\" d=\"{big} {hole(0, 1.5f)}\" fill=\"rgba(255,255,255,0.55)\"/>");
            var blur = s.NewId("ib");
            s.Def($"<filter id=\"{blur}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"3\"/></filter>");
            s.Raw($"<path fill-rule=\"evenodd\" d=\"{big} {hole(0, -3)}\" fill=\"rgba(20,0,60,0.35)\" filter=\"url(#{blur})\"/></g>");
        }

        // ---- the crest's number and XP ring (in the crest's viewBox, 0 0 120 104) -------------------------------------
        public sealed class CrestNumber
        {
            public float Y;          // the baseline
            public string Fill;      // a colour, or "gradient"
            public string Stroke;
            public float StrokeWidth;
        }

        /// <summary>M.crest's two number texts: the dark copy 1.5 lower (stroke 6), then the gold one (stroke 3).</summary>
        public static readonly CrestNumber[] Numbers =
        {
            new CrestNumber { Y = 67.5f, Fill = "#3d1268", Stroke = "#3d1268", StrokeWidth = 6 },
            new CrestNumber { Y = 66f, Fill = "gradient", Stroke = "#3d1268", StrokeWidth = 3 },
        };
        // the crest's gold (main-menu.js crest(): `g`)
        static readonly (float off, string color)[] Gold = { (0, "#fffbe0"), (0.35f, "#ffd85a"), (0.7f, "#f0a21c"), (1, "#b8640a") };

        /// <summary>The XP ring's arc after `ms` of its first showing (its SMIL animation: 0 -> f in 1.4 s from 0.3 s,
        /// spline .2 .9 .25 1); `animate` false: at once.</summary>
        public static double RingAt(double f, double ms, bool animate)
        {
            if (!animate) return f;
            double t = (ms - 300) / 1400;
            if (t <= 0) return 0;
            if (t >= 1) return f;
            return f * Anim.Easing.Bezier(0.2, 0.9, 0.25, 1)(t);
        }

        /// <summary>The number (and the ring under it: the dark track and the gold arc, `ringF` of the way round) as SVG
        /// in the crest's viewBox units, `w` x `h` of them, drawn at `scale` dp per unit.</summary>
        public static UiSvg CrestText(int level, bool ring, double ringF, float scale)
        {
            var s = new UiSvg(120 * scale, 104 * scale);
            s.Open($"transform=\"scale({F(scale)})\"");
            if (ring)
            {
                double C = 2 * Math.PI * 27.2, a = C * Math.Max(0, Math.Min(1, ringF));
                var id = s.NewId("cr");
                // the ring lies under the LEVEL ribbon (drawn after it in the crest): clipped out where the ribbon (and its
                // 2-wide outline) covers it
                var clip = s.NewId("rb");
                s.Def($"<clipPath id=\"{clip}\"><path clip-rule=\"evenodd\" d=\"M-10 -10H130V114H-10Z M32 82.4 Q60 76.9 88 82.4 L88 98.1 Q60 92.6 32 98.1Z\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Def($"<linearGradient id=\"{id}\" x1=\"1\" y1=\"0\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#fffae5\"/><stop offset=\".5\" stop-color=\"#fff0b7\"/><stop offset=\"1\" stop-color=\"#ffe079\"/></linearGradient>");
                s.Raw("<circle cx=\"60\" cy=\"58\" r=\"27.2\" fill=\"none\" stroke=\"#6b4426\" stroke-opacity=\".55\" stroke-width=\"4.4\"/>");
                string da = a.ToString("0.0", CultureInfo.InvariantCulture);
                // a dash of length 0 is still its round cap in Chrome: a dot at the top
                if (da == "0.0") s.Raw("<circle cx=\"60\" cy=\"30.8\" r=\"2.2\" fill=\"#fffae5\"/>");
                else s.Raw($"<circle cx=\"60\" cy=\"58\" r=\"27.2\" fill=\"none\" stroke=\"url(#{id})\" stroke-width=\"4.4\" stroke-linecap=\"round\" transform=\"rotate(-90 60 58)\" stroke-dasharray=\"{da} {C.ToString("0.0", CultureInfo.InvariantCulture)}\"/>");
                s.Close();
            }
            string t = level.ToString(CultureInfo.InvariantCulture);
            float size = level > 9 ? 24 : 27;
            var font = UiFont.Get("Fredoka_700Bold");
            font.Layout(t, size, 0, out float adv);
            float x = 60 - adv / 2;
            float k = size / font.UnitsPerEm;
            foreach (var n in Numbers)
            {
                string fill = n.Fill;
                if (fill == "gradient")
                {
                    // objectBoundingBox of SVG text: its glyph cells, the font's ascent to descent. In the glyphs' own space
                    // (each glyph is a <use> scaled by k and flipped), so the same for every glyph
                    var id = s.NewId("cg");
                    var sb = new StringBuilder($"<linearGradient id=\"{id}\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"{F(font.Ascender)}\" x2=\"0\" y2=\"{F(font.Descender)}\">");
                    foreach (var (off, c) in Gold) sb.Append($"<stop offset=\"{F(off)}\" stop-color=\"{c}\"/>");
                    s.Def(sb.Append("</linearGradient>").ToString());
                    fill = $"url(#{id})";
                }
                // paint-order stroke: the outline under the fill (stroke widths in the glyphs' units)
                s.Glyphs(t, x, n.Y, "Fredoka_700Bold", size, 0, "none", $"stroke=\"{n.Stroke}\" stroke-width=\"{F(n.StrokeWidth / k)}\" stroke-linejoin=\"round\"");
                s.Glyphs(t, x, n.Y, "Fredoka_700Bold", size, 0, fill);
            }
            s.Close();
            return s;
        }

        /// <summary>.sq-cin's flourish (sqFloat, 0.9 s ease-in-out): up 4 px and 1.05x at 40 %, about 50 % 62 % of its box.
        /// Returns (dy px, scale) at `t` ms into it.</summary>
        public static (float dy, float scale) Float(double t)
        {
            if (t < 0 || t >= 900) return (0, 1);
            var ease = Anim.Easing.Bezier(0.42, 0, 0.58, 1);
            double p = t / 900, v = p < 0.4 ? ease(p / 0.4) : 1 - ease((p - 0.4) / 0.6);
            return ((float)(-4 * v), (float)(1 + 0.05 * v));
        }
    }
}
