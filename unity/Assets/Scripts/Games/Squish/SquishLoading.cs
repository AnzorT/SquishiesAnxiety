// Squish Time's loading beat (src/screens/LoadingScreen.js): between PLAY and the squish stage, the creature on a warm
// glow over the wood, "Getting ready" with three hopping gold dots while its card loads, then "I AM READY!" popping in
// (the 'ready' sound) and a fade to the stage. With the card already here (the shipped ones, or cached) it's only
// "I AM READY!" and the quick fade (~0.6 s); otherwise the dots show at least 600 ms, longer while the card is still
// coming, never past 8 s.
//
// The creature is its still (Roster.Picture: its border-look picture, as the app's thumbnails) moving as the app's
// CreatureThumbnail mood 'ready' moves it (src/plush/motion.js): a breath, the slow sway, and its little hop at the
// start. No UnityEngine here: SquishTime shows the pieces, the test harness (tools/unity/squish-test `loading`) draws
// them with the reference rasteriser.
//
//   var b = new SquishLoading(key, w, h, quick, nowMs);  b.ModelReady() once the card is in;
//   each frame: b.Tick(nowMs); b.Pieces() (screen dp); b.Done once it has faded out.
using System;
using System.Collections.Generic;
using SquishSquad.Screens;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squish
{
    public sealed class SquishLoading
    {
        // LoadingScreen.js
        public const double PREP_MS = 600, READY_MS = 600, FADE_MS = 260, QUICK_READY_MS = 450, QUICK_FADE_MS = 150, MAX_WAIT_MS = 8000;
        const float SIZE = 210, BLEED = 16, ROW_GAP = 14, ROW_H = 46, HALO = 300;
        const float PIVOT_Y = 0.4f;   // CreatureThumbnail.js PIVOT_Y

        readonly string _key, _pic;
        readonly float _w, _h;
        readonly bool _quick;
        readonly double _t0;
        readonly int _hash;
        double _now, _readyAt = -1, _fadeAt = -1, _doneAt = -1, _modelAt = -1;

        /// <summary>"prep" (the dots) or "ready" ("I AM READY!").</summary>
        public string Stage { get; private set; }
        public bool Done => _doneAt >= 0 && _now >= _doneAt;
        /// <summary>The 'ready' sound's moment came (once).</summary>
        public Action OnReady;

        public SquishLoading(string key, float w, float h, bool quick, double nowMs)
        {
            _key = key; _w = w; _h = h; _quick = quick; _t0 = nowMs; _now = nowMs;
            try { _pic = Roster.Picture(new Creature { Key = key }); } catch (Exception) { _pic = null; }
            _hash = HashOf(key);
            Stage = quick ? "ready" : "prep";
        }

        // motion.js hashOf: the sum of the key's character codes
        public static int HashOf(string key) { int s = 0; foreach (var ch in key ?? "nimbo") s += ch; return s; }

        /// <summary>The creature's card is in (preloadCreatureModel resolved).</summary>
        public void ModelReady() { if (_modelAt < 0) _modelAt = _now; }

        public void Tick(double nowMs)
        {
            _now = nowMs;
            double t = nowMs - _t0;
            if (_readyAt < 0)
            {
                if (_quick) _readyAt = 0;
                else if ((t >= PREP_MS && _modelAt >= 0) || t >= MAX_WAIT_MS) _readyAt = Math.Max(PREP_MS, Math.Min(MAX_WAIT_MS, t));
                if (_readyAt >= 0)
                {
                    Stage = "ready";
                    _fadeAt = _readyAt + (_quick ? QUICK_READY_MS : READY_MS);
                    _doneAt = _fadeAt + (_quick ? QUICK_FADE_MS : FADE_MS);
                    OnReady?.Invoke();
                }
            }
        }

        /// <summary>The whole screen's opacity (the fade to the stage).</summary>
        public float Opacity
        {
            get
            {
                if (_fadeAt < 0) return 1;
                double t = _now - _t0;
                if (t <= _fadeAt) return 1;
                // Animated.timing's default easing: inOut(ease)
                return (float)Math.Max(0, 1 - FadeEase(Math.Min(1, (t - _fadeAt) / (_doneAt - _fadeAt))));
            }
        }

        static readonly Func<double, double> FadeEase = SquishSquad.Anim.Easing.InOut(SquishSquad.Anim.Easing.Ease);

        // ---- the pieces ----------------------------------------------------------------------------------------------------
        string _wood, _halo, _creature, _prep, _ready, _dot;
        float _prepW, _prepH, _readyW, _readyH;

        public List<ScreenPiece> Pieces()
        {
            double t = _now - _t0;
            float op = Opacity;
            var list = new List<ScreenPiece>();
            _wood ??= Kit.WoodBg(_w, _h);
            list.Add(new ScreenPiece { Id = "load-wood", Svg = _wood, W = _w, H = _h, Margin = 0, Opacity = op });
            // the halo: a 300 dp warm disc, centred on the screen (an absolute child of the centred column)
            _halo ??= $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{HALO}\" height=\"{HALO}\"><circle cx=\"150\" cy=\"150\" r=\"150\" fill=\"rgba(255,214,110,0.22)\"/></svg>";
            list.Add(new ScreenPiece { Id = "load-halo", Svg = _halo, W = HALO, H = HALO, Margin = 1, Opacity = op }.At(_w / 2 - HALO / 2, _h / 2 - HALO / 2));

            // the column: the thumbnail (210) and the row under it (14 + 46), centred
            float colY = (_h - (SIZE + ROW_GAP + ROW_H)) / 2, colX = (_w - SIZE) / 2;
            float box = SIZE / ((100 + BLEED * 2) / 100f), inset = (SIZE - box) / 2;
            if (_pic != null)
            {
                if (_creature == null)
                {
                    var s = new UiSvg(box, box);
                    var (fx, fy, fw, fh) = Roster.PictureFrame(_key);
                    s.Image(_pic, fx * box, fy * box, fw * box, fh * box, "none");
                    _creature = s.Markup;
                }
                var m = Body(t, box);
                list.Add(new ScreenPiece { Id = "load-creature", Svg = _creature, W = box, H = box, Margin = box * 0.2f, Opacity = op, Transform = Affine.Translate(colX + inset, colY + inset) * m });
            }

            float rowY = colY + SIZE + ROW_GAP;
            if (Stage == "prep")
            {
                if (_prep == null) (_prep, _prepW, _prepH) = RoyalLettering.Draw("Getting ready", 24, "gold");
                const float dotsW = 3 * 10 + 2 * 6, dotsH = 20;
                float rowW = _prepW + 8 + dotsW, x0 = _w / 2 - rowW / 2;
                list.Add(new ScreenPiece { Id = "load-prep", Svg = _prep, W = _prepW, H = _prepH, Opacity = op }.At(x0, rowY + (ROW_H - _prepH) / 2));
                _dot ??= "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\"><circle cx=\"5\" cy=\"5\" r=\"5\" fill=\"#6b4426\"/><circle cx=\"5\" cy=\"5\" r=\"3\" fill=\"#ffd24a\"/></svg>";
                float dx = x0 + _prepW + 8, dy = rowY + (ROW_H - dotsH) / 2 + 10;
                for (int i = 0; i < 3; i++)
                {
                    // usePingPong(640, 0 → -7, a beat apart): 0 → 1 → 0, eased
                    double d = t - i * 160, y = 0;
                    if (d > 0) { double p = d % 640 / 640; y = -7 * (1 - Math.Cos(2 * Math.PI * p)) / 2; }
                    list.Add(new ScreenPiece { Id = "load-dot" + i, Svg = _dot, W = 10, H = 10, Margin = 1, Opacity = op }.At(dx + i * 16, dy + (float)y));
                }
            }
            else
            {
                if (_ready == null) (_ready, _readyW, _readyH) = RoyalLettering.Draw("I AM READY!", 30, "gold");
                // PopIn: 420 ms, out(quad); opacity 0 → 1 by half-way, scale 0.4 → 1.12 → 1, turning -8° → 3° → 0, about
                // the row's centre (the row is the lettering's width, 46 tall)
                double k = Math.Min(1, Math.Max(0, (t - _readyAt) / 420));
                k = 1 - (1 - k) * (1 - k);
                double o = Lerp(k, 0, 0.5, 1, 0, 1, 1), sc = Lerp(k, 0, 0.6, 1, 0.4, 1.12, 1), rot = Lerp(k, 0, 0.6, 1, -8, 3, 0);
                float cx = _w / 2, cy = rowY + ROW_H / 2;
                var about = Affine.Translate(cx, cy) * Affine.Rotate(rot) * Affine.ScaleBy(sc, sc) * Affine.Translate(-_readyW / 2, -_readyH / 2);
                list.Add(new ScreenPiece { Id = "load-ready", Svg = _ready, W = _readyW, H = _readyH, Opacity = (float)(op * o), Transform = about });
            }
            return list;
        }

        static double Lerp(double t, double a0, double a1, double a2, double v0, double v1, double v2)
            => t <= a1 ? v0 + (v1 - v0) * (t - a0) / (a1 - a0) : v1 + (v2 - v1) * Math.Min(1, (t - a1) / (a2 - a1));

        // ---- the body motion: motion.js moodTracks('ready') through CreatureThumbnail.js bodyStyle --------------------------
        static double Clamp01(double x) => x < 0 ? 0 : x > 1 ? 1 : x;
        static double Ss(double x) { x = Clamp01(x); return x * x * (3 - 2 * x); }
        static double Breath(double q) => q < 0.42 ? Ss(q / 0.42) : 1 - Ss((q - 0.42) / 0.58);
        static double Noise(double t, double s) => (Math.Sin(t * 0.00071 + s) + 0.6 * Math.Sin(t * 0.00117 + s * 1.7) + 0.4 * Math.Sin(t * 0.00029 + s * 2.3)) / 2;

        // anticipation crouch -> stretched takeoff -> arc -> squash landing with damped overshoot (motion.js hop)
        static (double y, double sy) Hop(double ms, double P, double ant, double air, double h, double st, double sq)
        {
            double p = ms % P / P, b = ant + air;
            if (p < ant) return (0, 1 - sq * 0.75 * Ss(p / ant));
            if (p < b) { double q = (p - ant) / air; return (h * 4 * q * (1 - q), 1 + st * Math.Pow(Math.Abs(1 - 2 * q), 2)); }
            double tl = (p - b) * P;
            return (0, 1 - sq * Math.Exp(-tl / 70) * Math.Cos(tl / 46));
        }

        /// <summary>The creature's transform at `t` ms into the screen, in its box's dp (about the box's centre).</summary>
        Affine Body(double t, float box)
        {
            double per = 0.88 + _hash % 7 * 0.04, P = 2800 * per;
            double sy = 1 + 0.022 * Breath(t % P / P);
            double tn = t % 14000;   // (the noise track's loop)
            double rot = 2.4 * Noise(tn, _hash), tx = 1.1 * Noise(tn * 0.7, _hash + 5), ty = 0;
            double q = t % 7400 / 7400;
            if (q < 0.11) { var r = Hop(q * 7400, 814, 0.24, 0.4, 6, 0.06, 0.09); ty = -r.y; sy *= r.sy; }
            double u = box / 150.0, sx = 1.85 - 0.85 * sy, pivot = box * PIVOT_Y;
            // RN: translateX, translateY, translateY(pivot), rotate, scaleX, scaleY, translateY(-pivot), about the centre
            return Affine.Translate(box / 2, box / 2) * Affine.Translate(tx * u, ty * u) * Affine.Translate(0, pivot) * Affine.Rotate(rot)
                * Affine.ScaleBy(sx, sy) * Affine.Translate(0, -pivot) * Affine.Translate(-box / 2, -box / 2);
        }
    }
}
