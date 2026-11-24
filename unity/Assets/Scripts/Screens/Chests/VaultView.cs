// "To the treasure vault" (src/components/VaultLoader.js, REDESIGN_V9 step 7), as pure C#: over a chest smash while it
// gets ready. The treasure map on the wood table (pictures: Resources/Chests/vault-*, tools/unity/export-shop.mjs); a
// red dotted trail shows dot by dot from Home towards the X as the bar fills (creeping to 90 % over 5.2 s, ease out
// cubic), the player's squishy hopping along it in a gold coin (a paw with no picture), the candle's light flickering,
// a tip changing every 2.8 s. Once the smash is ready (Ready(), and at least 1.6 s on screen) the bar fills (260 ms),
// the map zooms into the X in a golden glow (620 ms, ease in cubic) and the screen fades off the chest (from 430 ms,
// 240 ms); then OnDone. Laid out in the recording's frame (639 x 295), scaled to fit the screen. Its layout:
// Resources/Chests/vault.json (src/components/vaultArt.js).
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class VaultView : IScreenView
    {
        public readonly float W, H;
        public Action OnDone;
        readonly Ticker _t;
        readonly string _buddy;   // the squishy's picture key (Stack art), or null: the paw
        public static readonly string[] TIPS =
        {
            "The lucky meter guarantees an Epic or better at least every 10 chests",
            "Rarities: Common, Rare, Epic, Legendary, Rainbow",
            "Smash a Common or Rare chest hard: its first hit can upgrade it",
            "Collect a whole group to earn its Rainbow chest",
        };
        const double MIN_MS = 1600, CREEP_MS = 5200;
        const float ZOOM = 2.6f, COIN = 30;

        static float FW, FH, MX, MY, MW, MH, PAD, BX, BY, BW, BH, XX, XY;
        static float[][] TRAIL;
        static double[] AT;

        readonly AnimatedValue _prog = new AnimatedValue(0), _zoom = new AnimatedValue(0), _out = new AnimatedValue(0), _hop = new AnimatedValue(0), _flick = new AnimatedValue(0), _tipFade = new AnimatedValue(1);
        readonly double _t0;
        int _tip;
        bool _leaving;
        public bool Done { get; private set; }

        /// <summary>`tip`: the first tip (the app's is random: Math.floor(Math.random() * 4)).</summary>
        public VaultView(float w, float h, Ticker ticker, string buddyKey, int tip)
        {
            W = w; H = h; _t = ticker; _buddy = buddyKey; _tip = tip % TIPS.Length;
            Load();
            _t0 = _t.Now;
            Motion.Timing(_out, 1, 180, Easing.InOut(Easing.Ease)).Start();
            Motion.Timing(_prog, 0.9, CREEP_MS, Easing.Out(Easing.Cubic)).Start();
            Animated.Loop(Animated.Sequence(Motion.Timing(_hop, 1, 170, Easing.Out(Easing.Quad)), Motion.Timing(_hop, 0, 170, Easing.In(Easing.Quad)))).Start();
            Animated.Loop(Animated.Sequence(Motion.Timing(_flick, 1, 420, Easing.InOut(Easing.Sin)), Motion.Timing(_flick, 0, 560, Easing.InOut(Easing.Sin)))).Start();
            void Tips()
            {
                Motion.Timing(_tipFade, 0, 220, Easing.InOut(Easing.Ease)).Start(r =>
                {
                    _tip = (_tip + 1) % TIPS.Length;
                    Motion.Timing(_tipFade, 1, 260, Easing.InOut(Easing.Ease)).Start();
                });
            }
            _tipTimer = Every(Tips, 2800);
        }

        readonly Action _tipTimer;
        Action Every(Action a, double ms)
        {
            bool on = true;
            void Next() => _t.SetTimeout(() => { if (!on) return; a(); Next(); }, ms);
            Next();
            return () => on = false;
        }

        static void Load()
        {
            if (TRAIL != null) return;
            var j = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/vault") ?? throw new InvalidOperationException("Resources/Chests/vault.json is missing: run node tools/unity/export-shop.mjs")));
            float N(object o, string k) => (float)Prof.Num(Prof.Get(Prof.Map(o), k));
            FW = N(j["FRAME"], "w"); FH = N(j["FRAME"], "h");
            MX = N(j["MAP"], "x"); MY = N(j["MAP"], "y"); MW = N(j["MAP"], "w"); MH = N(j["MAP"], "h");
            PAD = (float)Prof.Num(j["MAP_PAD"]);
            BX = N(j["BAR"], "x"); BY = N(j["BAR"], "y"); BW = N(j["BAR"], "w"); BH = N(j["BAR"], "h");
            var x = Prof.List(j["X"]); XX = (float)Prof.D(x[0]); XY = (float)Prof.D(x[1]);
            TRAIL = Prof.List(j["TRAIL"]).Select(p => Prof.List(p).Select(v => (float)Prof.D(v)).ToArray()).ToArray();
            int n = TRAIL.Length;
            AT = Enumerable.Range(0, n).Select(i => (double)i / (n - 1) * 0.985).ToArray();
        }

        /// <summary>The smash has painted: the bar fills and the map zooms in (at least MIN_MS after it came up).</summary>
        public void Ready()
        {
            if (_leaving) return;
            double wait = MIN_MS - (_t.Now - _t0);
            if (wait > 0) { _t.SetTimeout(Go, wait); return; }
            Go();
        }

        void Go()
        {
            if (_leaving) return;
            _leaving = true;
            _prog.StopAnimation();
            Motion.Timing(_prog, 1, 260, Easing.Out(Easing.Quad)).Start(r =>
            {
                Animated.Parallel(
                    Motion.Timing(_zoom, 1, 620, Easing.In(Easing.Cubic)),
                    Animated.Sequence(Animated.Delay(430), Motion.Timing(_out, 0, 240, Easing.InOut(Easing.Ease)))
                ).Start(e => { Done = true; _tipTimer(); OnDone?.Invoke(); });
            });
        }

        public void Down(float x, float y) { }
        public void Move(float x, float y) { }
        public void Up(float x, float y) { }

        static readonly TextStyle PctT0 = T(Kit.Display, 11.5f, CREAM);

        public List<ScreenPiece> Pieces()
        {
            float s = Math.Min(W / FW, H / FH), ox = (W - FW * s) / 2, oy = (H - FH * s) / 2;
            float Fx(float u) => ox + u * s;
            float Fy(float u) => oy + u * s;
            double prog = _prog.GetValue(), zoom = _zoom.GetValue(), op = _out.GetValue(), hop = _hop.GetValue(), flick = _flick.GetValue();
            // the whole screen fades as one (an Animated.View's opacity): drawn as one picture when it isn't whole
            var list = new List<ScreenPiece>();
            var bg = new UiSvg(W, H);
            bg.Box(0, 0, W, H, new BoxStyle { Background = "#8a5a32" });
            bg.Image("Chests/vault-table", 0, 0, W, H, "xMidYMid slice");
            list.Add(Piece("table", bg, 0, 0, 1, null, 0));
            var glow = new UiSvg(68 * s, 68 * s);
            glow.Image("Chests/vault-glow", 0, 0, 68 * s, 68 * s);
            list.Add(Piece("candle", glow, Fx(48) - 34 * s, Fy(22) - 34 * s, (float)(0.28 + 0.22 * flick), null, 0));
            // the map, its trail, the glow at the X and the coin, zooming as one about the X
            float mw = (MW + PAD * 2) * s, mh = (MH + PAD * 2) * s;
            float Mx(float u) => (PAD + u) * s;
            float xX = Mx(XX), xY = Mx(XY);
            var map = new UiSvg(mw, mh);
            map.Image("Chests/vault-map", 0, 0, mw, mh);
            for (int i = 0; i < TRAIL.Length; i++)
            {
                double a = Motion.Lerp(prog, new[] { Math.Max(0, AT[i] - 0.012), AT[i] + 0.0001 }, new[] { 0.0, 1 });
                if (a <= 0) continue;
                map.Box(Mx(TRAIL[i][0]) - 1.8f * s, Mx(TRAIL[i][1]) - 1.8f * s, 3.6f * s, 3.6f * s, new BoxStyle { Radius = 1.8f * s, Background = "#d0402e", Opacity = (float)a });
            }
            double glowOp = Motion.Lerp(zoom, new[] { 0, 0.35, 1 }, new[] { 0, 0.85, 1 });
            float gs = 150 * s;
            if (glowOp > 0) map.Image("Chests/vault-glow", xX - gs / 2, xY - gs / 2, gs, gs, "none", (float)glowOp);
            // the coin along the trail, hopping
            float cs = COIN * s;
            double tx = Motion.Lerp(prog, AT, TRAIL.Select(p => (double)(Mx(p[0]) - cs / 2)).ToArray());
            double ty = Motion.Lerp(prog, AT, TRAIL.Select(p => (double)(Mx(p[1]) - cs * 0.62f)).ToArray()) - 5 * s * hop;
            Coin(map, (float)tx, (float)ty, cs);
            float z = (float)(1 + (ZOOM - 1) * zoom);
            var mm = Affine.Translate(Fx(MX - PAD), Fy(MY - PAD)) * Affine.Translate((1 - ZOOM) * (xX - mw / 2) * zoom, (1 - ZOOM) * (xY - mh / 2) * zoom) * About(mw, mh, Affine.ScaleBy(z, z));
            list.Add(new ScreenPiece { Id = "map", Svg = map.Markup, W = mw, H = mh, Margin = 8, Transform = mm });
            // the title
            float ls = (float)Math.Round(25 * s);
            var (lw, lh) = LetteringSize("To the treasure vault", ls);
            var title = new UiSvg(lw, lh);
            Lettering(title, "To the treasure vault", "gold", ls, 0, 0);
            list.Add(Piece("title", title, (W - lw) / 2, Fy(10)));
            // the bar: the fill sliding in from the left in the groove, the key riding its end
            float inset = 3 * s, innerW = BW * s - inset * 2, innerH = BH * s - inset * 2;
            float bw = BW * s, bh = BH * s;
            var bar = new UiSvg(bw, bh);
            bar.Box(0, 0, bw, bh, new BoxStyle { Radius = bh / 2, Background = "#fff1c4", BorderWidth = Bw(1.5f), BorderColor = "#6b4426", Shadows = new[] { new Shadow("rgba(42,20,4,0.5)", 0, 2, 4) } });
            float gx = inset, gy = inset;
            // (the groove: padding inset - 1.5 s inside the 1.5 border)
            float pad = inset - 1.5f * s + Bw(1.5f);
            gx = pad; gy = pad;
            float gw = bw - 2 * pad, gh = bh - 2 * pad;
            bar.Box(gx, gy, gw, gh, new BoxStyle { Radius = innerH / 2, Background = "#7a4a22" });
            var clip = bar.NewId("vg");
            bar.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(gx + 1, gy + 1, gw - 2, gh - 2, new[] { innerH / 2 - 1, innerH / 2 - 1, innerH / 2 - 1, innerH / 2 - 1 })}\"/></clipPath>");
            bar.Open($"clip-path=\"url(#{clip})\"");
            float fx = gx + 1 + (float)(-innerW + innerW * prog);
            var fclip = bar.NewId("vf");
            bar.Def($"<clipPath id=\"{fclip}\"><path d=\"{UiSvg.RRect(fx, gy + 1, innerW, innerH, new[] { innerH / 2, innerH / 2, innerH / 2, innerH / 2 })}\"/></clipPath>");
            bar.Open($"clip-path=\"url(#{fclip})\"");
            bar.Image("Chests/vault-fill", fx, gy + 1, innerW, innerH);
            bar.Close();
            bar.Close();
            bar.Box(gx, gy, gw, gh, new BoxStyle { Radius = innerH / 2, BorderWidth = 1, BorderColor = "#5e3a1c" });
            list.Add(Piece("bar", bar, Fx(BX), Fy(BY), 1, null, 8));
            var key = new UiSvg(28 * s, 28 * s);
            key.Image("Chests/vault-key", 0, 0, 28 * s, 28 * s);
            list.Add(Piece("key", key, Fx(BX) + inset - 14 * s + (float)(innerW * prog), Fy(BY + BH / 2) - 14 * s, 1, null, 0));
            // the percentage and the tip
            var pt = T(Kit.Display, 11.5f * s, CREAM, 0, 18 * s, new[] { new Shadow("#3a1e08", 0, 1.5f, 1) });
            string pct = $"{(int)Math.Round(prog * 100)}%";
            var ps = new UiSvg(Math.Max(1, W(pct, pt)), LH(pt));
            ps.Text(pct, 0, 0, pt);
            list.Add(Piece("pct", ps, Fx(BX + BW + 9), Fy(BY + BH / 2) - 9 * s, 1, null, 4));
            var tipT = T(Heavy, 9.6f * s, CREAM, 0, 0, new[] { new Shadow("#3a1e08", 0, 1, 1) });
            var headT = T(Heavy, 9.6f * s, "#ffd56b", 0, 0, new[] { new Shadow("#3a1e08", 0, 1, 1) });
            string tip = TIPS[_tip];
            float hw = W("Tip: ", headT), tw = hw + W(tip, tipT);
            var tsv = new UiSvg(tw, LH(tipT));
            tsv.Text("Tip: ", 0, 0, headT);
            tsv.Text(tip, hw, 0, tipT);
            list.Add(Piece("tip", tsv, (W - tw) / 2, Fy(272), (float)_tipFade.GetValue(), null, 4));
            if (op >= 0.999) return list;
            return new List<ScreenPiece> { Piece("vault", Pieces2(list), W, H, 0, 0, (float)op, null, 0) };
        }

        string Pieces2(List<ScreenPiece> l) => SquishSquad.Ui.Screens.Pieces.Compose(l, W, H);

        /// <summary>The squishy in its gold coin (VaultLoader.js Coin): the gold ring (9 % padding), the cream face with
        /// the picture (96 %) or a paw.</summary>
        void Coin(UiSvg s, float x, float y, float size)
        {
            var g = s.NewId("cg");
            s.Def($"<filter id=\"{g}\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur in=\"SourceAlpha\" stdDeviation=\"1.5\"/><feOffset dy=\"2\" result=\"b\"/><feFlood flood-color=\"#3a1e08\" flood-opacity=\"0.45\"/><feComposite in2=\"b\" operator=\"in\"/></filter>");
            s.Raw($"<circle cx=\"{F(x + size / 2)}\" cy=\"{F(y + size / 2)}\" r=\"{F(size / 2)}\" fill=\"#000\" filter=\"url(#{g})\"/>");
            s.Box(x, y, size, size, new BoxStyle { Radius = size / 2, Gradient = new[] { "#fff1b0", "#f2c24a", "#c98a1c" }, BorderWidth = 1, BorderColor = "#8a5a1a" });
            float p = size * 0.09f + 1, fw = size - 2 * p;
            s.Box(x + p, y + p, fw, fw, new BoxStyle { Radius = size / 2, Background = "#fff6e2", BorderWidth = 1, BorderColor = "#b8801c" });
            var clip = s.NewId("cc");
            s.Def($"<clipPath id=\"{clip}\"><circle cx=\"{F(x + size / 2)}\" cy=\"{F(y + size / 2)}\" r=\"{F(fw / 2 - 1)}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            float iw = (fw - 2) * 0.96f;
            if (_buddy != null && Roster.Ar(_buddy) > 0) ShopView.CreaturePicPublic(s, _buddy, x + size / 2 - iw / 2, y + size / 2 - iw / 2, iw);
            else
            {
                // 🐾 as Chrome draws it (Resources/Chests/paw.png at 48 px, its box in paw.json), its box centred
                var pj = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Chests/paw") ?? "{}"));
                float k = size * 0.42f / 48f, bw = (float)Prof.Num(Prof.Get(pj, "w")) * k, bh = (float)Prof.Num(Prof.Get(pj, "h")) * k;
                float px = (float)Prof.Num(Prof.Get(pj, "px")) * k, py = (float)Prof.Num(Prof.Get(pj, "py")) * k, pw = (float)Prof.Num(Prof.Get(pj, "pw")) * k, ph = (float)Prof.Num(Prof.Get(pj, "ph")) * k;
                s.Image("Chests/paw", x + size / 2 - bw / 2 + px, y + size / 2 - bh / 2 + py, pw, ph);
            }
            s.Close();
        }
    }
}
