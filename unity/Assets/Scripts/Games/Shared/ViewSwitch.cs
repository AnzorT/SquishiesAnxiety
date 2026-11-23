// src/components/ViewSwitch.js and Skeleton.js, as the game screens use them:
//   ViewSwitch   the hub, the level map and a level slide in over each other: on a switch the view's slide jumps to 0 and
//                springs to 1 (friction 8, tension 70): its opacity 0 → 1 over the first 40 %, 60 dp from the right to
//                its place. The new view is built two frames later (two requestAnimationFrames), placeholders first.
//   Reveal       swaps the placeholders for the built content: the content fades in over 160 ms (ease-out quad) while
//                the placeholders over it fade out, then they go
//   Bones        the placeholders (ViewBones): soft blocks in the shape of what's coming ("hub", "map", "game"), a white
//                shine sweeping across them all together, one 1.4 s pass (one loop for every bone on screen)
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

        /// <summary>The kind's bones in its view's box (w x h).</summary>
        public static List<Box> Layout(string kind, float w, float h)
        {
            var l = new List<Box>();
            if (kind == "map")
            {
                var xs = new[] { 0.62f, 0.3f, 0.5f, 0.72f, 0.4f, 0.58f };
                for (int i = 0; i < xs.Length; i++) l.Add(new Box(w * (xs[i] - 0.09f), 40 + i * (62 + 34), 62, 62, 31));
                return l;
            }
            float cw = w - 32;
            if (kind == "game")
            {
                float mid = cw * 0.4f, extra = (cw - (44 + mid + 70) - 20) / 2;
                l.Add(new Box(16, 14, 44, 44, 22));
                l.Add(new Box(16 + 44 + 10 + extra, 14 + 4, mid, 36, 18));
                l.Add(new Box(16 + cw - 70, 14 + 4, 70, 36, 18));
                l.Add(new Box(16, 14 + 44 + 14, cw, cw, 24));
                return l;
            }
            // hub: centred, paddingTop 24, gap 14
            float y = 24;
            void Add(float bw, float bh, float r, float mt = 0) { y += mt; l.Add(new Box(16 + (cw - bw) / 2, y, bw, bh, r)); y += bh + 14; }
            Add(cw * 0.62f, 40, 20); Add(cw * 0.74f, 12, 6); Add(cw, 128, 26, 10); Add(cw, 128, 26); Add(cw * 0.46f, 46, 23);
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
                s.Box(b.X, b.Y, b.W, b.H, new BoxStyle { Background = "rgba(255,255,255,0.5)", Radius = b.R });
                double x0 = b.X + bx;
                if (x0 > b.X + b.W + 40 || x0 + BAND < b.X - 40) continue;
                var clip = s.NewId("bc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(b.X, b.Y, b.W, b.H, new[] { b.R, b.R, b.R, b.R })}\"/></clipPath>");
                double cx = x0 + BAND / 2, cy = b.Y + b.H / 2;
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Raw($"<g transform=\"translate({UiSvg.F(cx)} {UiSvg.F(cy)}) skewX(-14) translate({UiSvg.F(-cx)} {UiSvg.F(-cy)})\"><rect x=\"{UiSvg.F(x0)}\" y=\"{UiSvg.F(b.Y - 10)}\" width=\"{UiSvg.F(BAND)}\" height=\"{UiSvg.F(b.H + 20)}\" fill=\"url(#{id})\"/></g>");
                s.Close();
            }
            return s.Markup;
        }

        /// <summary>A key that changes when the bones' picture does (the shine moved).</summary>
        public static string Key(string kind, float winW) => kind + "|" + Math.Round(BandX(winW), 2);
    }
}
