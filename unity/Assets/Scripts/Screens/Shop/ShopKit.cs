// What the Shop's tabs, sheets and the Level Road draw with, besides Common/Kit: the currency and chest pictures
// (Resources/Shop/img, tools/unity/export-shop.mjs), the royal Btn (a gold or wood plaque with its pulsing glow), the
// candy ShadowText captions, the looping motions (squad/ui.js Bob, idleLoop.js usePingPong) and a hit list.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public static class ShopArt
    {
        public static string Coin(int i) => "Shop/img/coin-" + ((i % 6) + 6) % 6;
        public static string Gem(int i) => "Shop/img/gem-" + ((i % 6) + 6) % 6;
        /// <summary>A group chest's picture: '&lt;size&gt;-grow', 'common-tile', 'rare-tile', 'legendary-deal'.</summary>
        public static string Chest(string gk, string look) => $"Shop/img/gc/{gk}-{look}";
        public static string Backdrop(string gk) => $"Shop/img/gc/bg-{gk}";

        /// <summary>An image "contain"ed in the box.</summary>
        public static void Contain(UiSvg s, string href, float x, float y, float w, float h, float opacity = 1) => s.Image(href, x, y, w, h, "xMidYMid meet", opacity);
        public static void Cover(UiSvg s, string href, float x, float y, float w, float h) => s.Image(href, x, y, w, h, "xMidYMid slice");

        /// <summary>A Text's box drawn at (x, y) (top-left).</summary>
        public static float Txt(UiSvg s, string text, float x, float y, TextStyle t) { s.Text(text, x, y, t); return W(text, t); }
        /// <summary>Centred on cx.</summary>
        public static void TxtC(UiSvg s, string text, float cx, float y, TextStyle t) => s.Text(text, cx - W(text, t) / 2, y, t);

        /// <summary>textDecorationLine: line-through, as Chrome draws it for these fonts (the font's strikeout line).</summary>
        public static void Strike(UiSvg s, string text, float x, float y, TextStyle t)
        {
            s.Text(text, x, y, t);
            float b = UiSvg.Baseline(t, y), th = Math.Max(1, t.Size / 14f);
            s.Box(x, b - t.Size * 0.3f - th / 2, W(text, t), th, new BoxStyle { Background = t.Color });
        }

        /// <summary>The candy ShadowText outline3(c, down).</summary>
        public static TextStyle Candy(string font, float size, string color, string ring, float down = 2, float ls = 0) => T(font, size, color, ls, 0, Outline3(ring, down));

        // ---- the royal Btn: a plaque (gold or wood) with its pulsing glow ------------------------------------------------
        /// <summary>Plaque.js Glow's opacity at a phase of its 2400 ms loop.</summary>
        public static float GlowOpacity(double phase) => (float)(0.35 + 0.65 * Motion.UpDown(phase));

        public static void BtnGlow(List<ScreenPiece> list, string id, float x, float y, float w, float h, float radius, double phase)
        {
            float r = Math.Min(radius, 40);
            list.Add(Piece(id + "-glow", Glow(w, h, r, 10), w + 20, h + 20, x - 10, y - 10, GlowOpacity(phase), null, 0));
        }

        /// <summary>BigFlame (components/StreakIcons.js): `w` wide, 1.15 w tall, warm or cold.</summary>
        public static void BigFlame(UiSvg s, float x, float y, float w, bool cold)
        {
            string[] body = cold ? new[] { "#e0f2ff", "#8cc8ff", "#4f8fd6" } : new[] { "#ffc35a", "#ff7a3a", "#e5352a" };
            string[] heart = cold ? new[] { "#ffffff", "#d6ecff" } : new[] { "#fffbd0", "#ffd23a" };
            string ib = s.NewId("bfb"), ih = s.NewId("bfh");
            s.Def($"<linearGradient id=\"{ib}\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"{body[0]}\"/><stop offset=\"0.5\" stop-color=\"{body[1]}\"/><stop offset=\"1\" stop-color=\"{body[2]}\"/></linearGradient>");
            s.Def($"<linearGradient id=\"{ih}\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"{heart[0]}\"/><stop offset=\"1\" stop-color=\"{heart[1]}\"/></linearGradient>");
            s.Drawing($"<path d=\"M52 6 C67 36 97 46 91 82 C87 105 68 115 52 115 C30 115 14 99 14 76 C14 53 36 45 37 22 C45 30 51 37 52 6Z\" fill=\"url(#{ib})\" stroke=\"{(cold ? "#1d4f9a" : "#7a2310")}\" stroke-width=\"5\" stroke-linejoin=\"round\"/>"
                + $"<path d=\"M52 58 C61 74 72 79 68 95 C65 106 58 110 52 110 C42 110 36 102 36 92 C36 81 48 75 52 58Z\" fill=\"url(#{ih})\"/>"
                + "<path d=\"M33 50 C27 60 26 70 29 78\" stroke=\"#ffffff\" stroke-opacity=\"0.65\" stroke-width=\"6\" stroke-linecap=\"round\" fill=\"none\"/>", x, y, w, w * 1.15f, "0 0 105 121");
        }

        /// <summary>ShopDeals.js / LevelRoad Check: the white disc, the green one and the tick, `size` across.</summary>
        public static void Check(UiSvg s, float x, float y, float size, string color = "#26a94e") =>
            s.Drawing($"<circle cx=\"12\" cy=\"12\" r=\"11\" fill=\"#ffffff\"/><circle cx=\"12\" cy=\"12\" r=\"8.5\" fill=\"{color}\"/><path d=\"M8 12.3 L10.8 15 L16.2 9.4\" stroke=\"#ffffff\" stroke-width=\"2.6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>", x, y, size, size, "0 0 24 24");
    }

    /// <summary>A Bob / usePingPong loop: phase 0..1 every `ms`, started after `delay` (Animated.loop of a linear timing,
    /// as idleLoop.js phaseLoop, so it drifts by a frame a lap as the app's does).</summary>
    public sealed class Loop
    {
        readonly AnimatedValue _v = new AnimatedValue(0);
        public Loop(Ticker t, double ms, double delay = 0)
        {
            var a = Motion.Phase(_v, ms);
            if (delay > 0) t.SetTimeout(() => a.Start(), delay); else a.Start();
        }
        public double Phase => _v.GetValue();
        /// <summary>UP_DOWN from `from` to `to`.</summary>
        public float PingPong(float from, float to) => (float)(from + (to - from) * Motion.UpDown(Phase));
    }

    /// <summary>Where the taps go: boxes in the screen's units, the last added on top.</summary>
    public sealed class Hits
    {
        readonly List<(string id, float x, float y, float w, float h)> _l = new List<(string, float, float, float, float)>();
        public void Clear() => _l.Clear();
        public void Add(string id, float x, float y, float w, float h, float slop = 0) => _l.Add((id, x - slop, y - slop, w + 2 * slop, h + 2 * slop));
        public string At(float x, float y)
        {
            for (int i = _l.Count - 1; i >= 0; i--)
            {
                var h = _l[i];
                if (x >= h.x && x < h.x + h.w && y >= h.y && y < h.y + h.h) return h.id;
            }
            return null;
        }
    }
}
