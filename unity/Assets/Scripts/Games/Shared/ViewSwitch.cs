// src/components/ViewSwitch.js and Skeleton.js, as the game screens use them:
//   ViewSwitch   the hub, the level map and a level slide in over each other: on a switch the view's slide jumps to 0 and
//                springs to 1 (friction 8, tension 70): its opacity 0 → 1 over the first 40 %, 60 dp from the right to
//                its place. The new view is built two frames later (two requestAnimationFrames), placeholders first.
//   Reveal       swaps the placeholders for the built content: the content fades in over 160 ms (ease-out quad) while
//                the placeholders over it fade out, then they go
//   Bones        the placeholders (ViewBones): soft brown blocks in the wood look, sideways, in the shape of what's
//                coming ("hub", "map", "game"; develop, 2026-11-20), a dimmed white shine sweeping across them all
//                together, one 1.4 s pass (one loop for every bone on screen)
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    public sealed class ViewSwitch
    {
        readonly AnimatedValue _slide = new AnimatedValue(1);
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.4, 1 }, new[] { 0.0, 1, 1 });
        static readonly Interpolator Tx = Fx.Lerp(new[] { 0.0, 1 }, new[] { 60.0, 0 });
        public string View { get; private set; }
        public string Built { get; private set; }
        public bool Ready => Built == View;
        /// <summary>The new view is built (its content mounts now).</summary>
        public Action<string> OnBuilt;
        Ticker _tk;
        int _r1, _r2;

        public ViewSwitch(string initial) { View = Built = initial; }

        public void Go(string next)
        {
            _slide.SetValue(0);
            Animated.Spring(_slide, Fx.Spring(1, 8, 70)).Start();
            View = next;
            _tk ??= Ticker.Default;
            _tk.CancelAnimationFrame(_r1); _tk.CancelAnimationFrame(_r2);
            if (Built == View) return;
            _r1 = _tk.RequestAnimationFrame(() => _r2 = _tk.RequestAnimationFrame(() => { Built = View; OnBuilt?.Invoke(View); }));
        }

        public float Opacity => (float)Op.Evaluate(_slide.GetValue());
        /// <summary>The views' transform (translateX).</summary>
        public Affine Transform => Affine.Translate(Tx.Evaluate(_slide.GetValue()), 0);
        public double Slide => _slide.GetValue();
    }

    public sealed class Reveal
    {
        readonly AnimatedValue _t;
        public bool Bones { get; private set; }
        public bool Ready { get; private set; }
        CompositeAnimation _a;

        public Reveal(bool ready)
        {
            Ready = ready;
            Bones = !ready;
            _t = new AnimatedValue(ready ? 1 : 0);
        }

        public void SetReady()
        {
            if (Ready) return;
            Ready = true;
            if (!Bones) return;
            _a = Animated.Timing(_t, Fx.Timing(1, 160, Easing.Out(Easing.Quad)));
            _a.Start(r => { if (r.Finished) Bones = false; });
        }

        public void Stop() => _a?.Stop();

        public float ContentOpacity => (float)Math.Max(0, Math.Min(1, _t.GetValue()));
        public float BonesOpacity => 1 - ContentOpacity;
    }

    /// <summary>ViewBones in a box W wide (the window's width), the sweep shared by all of them.</summary>
    public static class Bones
    {
        static readonly AnimatedValue Sweep = new AnimatedValue(0);
        static int _users;
        static CompositeAnimation _loop;
        const float BAND = 90;
        static readonly double[] SWEEP_AT = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 1 };

        public static void Mount()
        {
            if (_users++ == 0)
            {
                _loop = Animated.Loop(Animated.Timing(Sweep, Fx.Timing(1, 1400, Easing.Linear)), Fx.LikeWeb ? 1 : -1);
                _loop.Start();
            }
        }

        public static void Unmount()
        {
            if (_users <= 0) return;
            if (--_users == 0) { _loop?.Stop(); _loop = null; Sweep.SetValue(0); }
        }

        /// <summary>The band's x in a bone (from its left) now.</summary>
        static double BandX(float winW)
        {
            var outs = new double[SWEEP_AT.Length];
            for (int i = 0; i < outs.Length; i++) outs[i] = -BAND + (winW + BAND) * Ease(Math.Min(1, SWEEP_AT[i] / 0.7));
            return new Interpolator(SWEEP_AT, outs, null, null, null, null).Evaluate(Sweep.GetValue());
        }
        static double Ease(double t) => Easing.InOut(Easing.Quad)(t);

        public struct Box { public float X, Y, W, H, R; public Box(float x, float y, float w, float h, float r) { X = x; Y = y; W = w; H = h; R = r; } }

        /// <summary>The kind's bones in its view's box (w x h): develop's ViewBones, in the wood look and sideways like the
        /// game's screens (2026-11-20: they were the old design's portrait shapes in translucent white, which flashed white
        /// circles on the wood as a level map opened). 'map' a row of level stones across the middle, 'game' a column, the
        /// board, a column, 'hub' two big cards side by side with a bar under them.</summary>
        public static List<Box> Layout(string kind, float w, float h)
        {
            var l = new List<Box>();
            if (kind == "map")
            {
                // mapRow: seven 58 dp stones, every other one 26 lower, spaced evenly (paddingH 30, paddingBottom 40), centred down
                float inner = w - 60, gap = (inner - 7 * 58) / 8, ch = h - 40;
                for (int i = 0; i < 7; i++)
                {
                    float mt = i % 2 == 1 ? 26 : 0;
                    l.Add(new Box(30 + gap + i * (58 + gap), (ch - (58 + mt)) / 2 + mt, 58, 58, 29));
                }
                return l;
            }
            if (kind == "game")
            {
                // gameRow: paddingH 18, gap 18, centred down: a 170 dp column (120, 30 at 60 %), the board (86 % of the height,
                // square), a 170 dp column (110, 44, 44), each column's gap 12
                float board = h * 0.86f, x = 18;
                float ly = (h - (120 + 12 + 30)) / 2;
                l.Add(new Box(x, ly, 170, 120, 20));
                l.Add(new Box(x + (170 - 102) / 2, ly + 132, 102, 30, 15));
                x += 170 + 18;
                l.Add(new Box(x, (h - board) / 2, board, board, 24));
                x += board + 18;
                float ry = (h - (110 + 12 + 44 + 12 + 44)) / 2;
                l.Add(new Box(x, ry, 170, 110, 20));
                l.Add(new Box(x, ry + 122, 170, 44, 20));
                l.Add(new Box(x, ry + 178, 170, 44, 20));
                return l;
            }
            // hub: paddingH 22, paddingTop 8, paddingBottom 18, gap 14: two cards side by side (gap 16) filling the height
            // above the bar, then the bar centred: 56 % x 52 and 20 % x 44, 16 apart
            float cw = w - 44, barH = 52, cardH = h - 8 - 18 - 14 - barH, card = (cw - 16) / 2;
            l.Add(new Box(22, 8, card, cardH, 26));
            l.Add(new Box(22 + card + 16, 8, card, cardH, 26));
            float b1 = cw * 0.56f, b2 = cw * 0.2f, bx = 22 + (cw - b1 - 16 - b2) / 2, by = 8 + cardH + 14;
            l.Add(new Box(bx, by, b1, 52, 22));
            l.Add(new Box(bx + b1 + 16, by + 4, b2, 44, 22));
            return l;
        }

        /// <summary>The bones as one SVG (w x h), each with the shine where the sweep has it now.</summary>
        public static string Markup(string kind, float w, float h, float winW)
        {
            var s = new UiSvg(w, h);
            double bx = BandX(winW);
            var id = s.NewId("shine");
            s.Def($"<linearGradient id=\"{id}\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>");
            foreach (var b in Layout(kind, w, h))
            {
                if (b.Y > h) continue;
                // (tone 'wood': a soft brown on the warm page, its shine dimmed to a fifth)
                s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Background = "rgba(107,68,38,0.22)", Radius = b.R });
                double x0 = b.X + bx;
                if (x0 > b.X + b.W + 40 || x0 + BAND < b.X - 40) continue;
                var clip = s.NewId("bc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(b.X, b.Y, b.W, b.H, new[] { b.R, b.R, b.R, b.R })}\"/></clipPath>");
                double cx = x0 + BAND / 2, cy = b.Y + b.H / 2;
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Raw($"<g transform=\"translate({UiSvg.F(cx)} {UiSvg.F(cy)}) skewX(-14) translate({UiSvg.F(-cx)} {UiSvg.F(-cy)})\"><rect x=\"{UiSvg.F(x0)}\" y=\"{UiSvg.F(b.Y - 10)}\" width=\"{UiSvg.F(BAND)}\" height=\"{UiSvg.F(b.H + 20)}\" fill=\"url(#{id})\" opacity=\"0.2\"/></g>");
                s.Close();
            }
            return s.Markup;
        }

        /// <summary>A key that changes when the bones' picture does (the shine moved).</summary>
        public static string Key(string kind, float winW) => kind + "|" + Math.Round(BandX(winW), 2);
    }
}
