// The cards' little motions, each a literal port of the app's (SquishSquad.Anim is React Native's Animated):
//   PopIn, SlideIn, Rock (a keyframe loop), CountUp     src/squishdoku/fx.js
//   Spin (RaysSpin's turn)                              src/components/candy/Decor.js
//   Burst (FxLayer's particle bursts)                   src/squishdoku/fx.js
//   XpFill (XpBar's fill and level number)              src/squishdoku/Overlays.js
//   Press (a held button shrinks, as the Level crest)   src/squishdoku/ui.js's SdButton timing
// Each gives its transform about a view's centre (as React Native's transform origin) and its opacity. Timers and
// frames run on Ticker.Default (the screen's clock), as the app's setTimeout / requestAnimationFrame do.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    public static class Fx
    {
        public static Interpolator Lerp(double[] input, double[] output, bool clamp = false) =>
            new Interpolator(input, output, null, clamp ? Extrapolate.Clamp : Extrapolate.Extend, null, null);

        public static SpringConfig Spring(double to, double friction, double tension, double delay = 0) =>
            new SpringConfig { ToValue = to, Friction = friction, Tension = tension, Delay = delay, UseNativeDriver = true };

        public static TimingConfig Timing(double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            new TimingConfig { ToValue = to, Duration = ms, Easing = easing, Delay = delay, UseNativeDriver = true };

        /// <summary>A view's transform list applied about the centre of its w x h box (React Native's origin).</summary>
        public static Affine About(float w, float h, Affine m) => Affine.Translate(w / 2.0, h / 2.0) * m * Affine.Translate(-w / 2.0, -h / 2.0);

        /// <summary>A button's press (as the menu's Level crest): the whole w x h button shrinks to 0.92 about its centre,
        /// in its own space; `t` 0 up, 1 held (or a press animation's value in between).</summary>
        public static Affine Pressed(float w, float h, double t) { double s = Press.ScaleAt(t); return About(w, h, Affine.ScaleBy(s, s)); }

        /// <summary>Math.random() for the particle bursts.</summary>
        public static Func<double> Random = new Random().NextDouble;

        /// <summary>Copies two quirks of Expo web, only to compare with the app's web pictures (tools/unity/stack-test
        /// cards): it plays the endless loops (Rock, RaysSpin) once, as react-native-web does with a native-driver
        /// Animated.loop, and every star's rays take the first one's fade, as two &lt;svg&gt;s defining the same gradient id
        /// ("rayFade") do in one web page. The phone loops and scopes ids to each drawing, and so does Unity.</summary>
        public static bool LikeWeb;
    }

    /// <summary>Springs its children in from nothing after `delay` ms (with a little twist), every time it's triggered.</summary>
    public sealed class PopIn
    {
        readonly AnimatedValue _t = new AnimatedValue(0);
        CompositeAnimation _a;
        readonly double _delay, _friction, _tension;
        readonly Interpolator _scale, _rotate;
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 0.0, 1, 1 }, true);

        public PopIn(double delay = 0, double from = 0, double twist = 8, double friction = 5, double tension = 120)
        {
            _delay = delay; _friction = friction; _tension = tension;
            _scale = Fx.Lerp(new[] { 0.0, 1 }, new[] { from, 1 });
            _rotate = Fx.Lerp(new[] { 0.0, 1 }, new[] { -twist, 0 });
        }

        public void Trigger()
        {
            _a?.Stop();
            _t.SetValue(0);
            _a = Animated.Spring(_t, Fx.Spring(1, _friction, _tension, _delay));
            _a.Start();
        }

        public void Stop() { _a?.Stop(); _a = null; }

        public float Opacity => (float)Op.Evaluate(_t.GetValue());
        public Affine Local(float w, float h)
        {
            double t = _t.GetValue(), s = _scale.Evaluate(t);
            return Fx.About(w, h, Affine.ScaleBy(s, s) * Affine.Rotate(_rotate.Evaluate(t)));
        }
    }

    /// <summary>Slides in from `dy` below (or above, negative) after `delay`, every time it's triggered.</summary>
    public sealed class SlideIn
    {
        readonly AnimatedValue _t = new AnimatedValue(0);
        CompositeAnimation _a;
        readonly double _delay;
        readonly Interpolator _y;
        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.3, 1 }, new[] { 0.0, 1, 1 }, true);

        public SlideIn(double delay = 0, double dy = 40)
        {
            _delay = delay;
            _y = Fx.Lerp(new[] { 0.0, 1 }, new[] { dy, 0 });
        }

        public void Trigger()
        {
            _a?.Stop();
            _t.SetValue(0);
            _a = Animated.Spring(_t, Fx.Spring(1, 7, 90, _delay));
            _a.Start();
        }

        public void Stop() { _a?.Stop(); _a = null; }

        public float Opacity => (float)Op.Evaluate(_t.GetValue());
        public Affine Local => Affine.Translate(0, _y.Evaluate(_t.GetValue()));
    }

    /// <summary>src/components/idleLoop.js useKeyLoop: a linear phase 0 → 1 every `ms`, read through keyframes, started
    /// `delay` ms after it's mounted (a setTimeout), forever. (develop's idleLoop.js phaseLoop runs it on JS on the web,
    /// 2026-11-20, so Expo web loops too now; it used to play a native-driver loop once only.)</summary>
    public sealed class KeyLoop
    {
        public static readonly double[] PHASE = MakePhase();
        public static readonly double[] SWING = Array.ConvertAll(PHASE, p => JsMath.Sin(2 * JsMath.PI * p));
        public static readonly double[] UP_DOWN = Array.ConvertAll(PHASE, p => (1 - JsMath.Cos(2 * JsMath.PI * p)) / 2);
        static double[] MakePhase() { var a = new double[17]; for (int i = 0; i < 17; i++) a[i] = i / 16.0; return a; }

        readonly AnimatedValue _phase = new AnimatedValue(0);
        readonly Interpolator _value;
        readonly double _ms, _delay;
        CompositeAnimation _loop;
        int _timer;
        Ticker _tk;

        public KeyLoop(double ms, double[] at, double[] values, double delay = 0)
        {
            _ms = ms; _delay = delay;
            _value = new Interpolator(at, values, null, null, null, null);
        }

        public void Mount()
        {
            Unmount();
            _tk = Ticker.Default;
            _loop = Animated.Loop(Animated.Timing(_phase, Fx.Timing(1, _ms, Easing.Linear)), -1);
            var loop = _loop;
            _timer = _tk.SetTimeout(() => loop.Start(), _delay);
        }

        public void Unmount()
        {
            if (_tk != null) _tk.ClearTimeout(_timer);
            _loop?.Stop();
            _loop = null;
            _phase.SetValue(0);
        }

        public double Value => _value.Evaluate(_phase.GetValue());
    }

    /// <summary>fx.js Rock: a forever side-to-side rock (rotate ±deg), one keyframe loop.</summary>
    public sealed class Rock
    {
        readonly KeyLoop _loop;
        readonly Interpolator _deg;
        public Rock(double deg = 4, double ms = 2400)
        {
            _loop = new KeyLoop(ms, KeyLoop.PHASE, KeyLoop.SWING);
            _deg = Fx.Lerp(new[] { -1.0, 1 }, new[] { -deg, deg });
        }
        public void Mount() => _loop.Mount();
        public void Unmount() => _loop.Unmount();
        public Affine Local(float w, float h) => Fx.About(w, h, Affine.Rotate(_deg.Evaluate(_loop.Value)));
    }

    /// <summary>Decor.js RaysSpin's turn: 0 → 360° linearly every `ms`, forever, from when it's mounted.</summary>
    public sealed class Spin
    {
        readonly AnimatedValue _spin = new AnimatedValue(0);
        readonly double _ms;
        CompositeAnimation _loop;
        static readonly Interpolator Deg = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.0, 360 });
        public Spin(double ms = 14000) { _ms = ms; }
        public void Mount()
        {
            _loop?.Stop();
            _loop = Animated.Loop(Animated.Timing(_spin, Fx.Timing(1, _ms, Easing.Linear)), Fx.LikeWeb ? 1 : -1);
            _loop.Start();
        }
        public void Unmount() { _loop?.Stop(); _loop = null; }
        public double Degrees => Deg.Evaluate(_spin.GetValue());
    }

    /// <summary>fx.js Burst: one particle burst (dust, sparks, gold...) round (x, y), each particle its own
    /// interpolation of one value. Its layers are the particles; it's over when Done.</summary>
    public sealed class Burst
    {
        sealed class Kind
        {
            public int Count; public double Life; public double[] Size, Dist, Up; public string[] Colors; public string Shape; public double SpreadY, Fall;
        }

        static readonly Dictionary<string, Kind> KINDS = new Dictionary<string, Kind>
        {
            ["dust"] = new Kind { Count = 7, Life = 420, Size = new[] { 5.0, 10 }, Dist = new[] { 14.0, 30 }, Up = new[] { -4.0, 6 }, Colors = new[] { "#ffffff", "#fff6fb" }, Shape = "dot", SpreadY = 0.25, Fall = 0 },
            // Squish Hop's landing: a bigger puff fanning out low along the cushion, round the squishy's feet
            ["puff"] = new Kind { Count = 10, Life = 460, Size = new[] { 6.0, 12 }, Dist = new[] { 28.0, 50 }, Up = new[] { -1.0, 5 }, Colors = new[] { "#ffffff", "#fdf3ff", "#efe4ff" }, Shape = "dot", SpreadY = 0.16, Fall = 3 },
            ["pop"] = new Kind { Count = 10, Life = 420, Size = new[] { 4.0, 7 }, Dist = new[] { 26.0, 40 }, Up = new[] { 0.0, 0 }, Colors = new[] { "#ff8fd0", "#ffffff", "#ffe066", "#9ce8ff" }, Shape = "dot", SpreadY = 1, Fall = 0 },
            ["spark"] = new Kind { Count = 8, Life = 560, Size = new[] { 5.0, 9 }, Dist = new[] { 22.0, 46 }, Up = new[] { -6.0, 6 }, Colors = new[] { "#fff3a0", "#ffffff", "#ffd1f5", "#c9f5ff" }, Shape = "star", SpreadY = 1, Fall = 10 },
            ["poof"] = new Kind { Count = 9, Life = 500, Size = new[] { 7.0, 14 }, Dist = new[] { 16.0, 34 }, Up = new[] { -8.0, 2 }, Colors = new[] { "#e6dcf0", "#ffffff", "#d6c8e8" }, Shape = "dot", SpreadY = 1, Fall = -6 },
            ["angry"] = new Kind { Count = 6, Life = 380, Size = new[] { 4.0, 7 }, Dist = new[] { 18.0, 30 }, Up = new[] { -4.0, 4 }, Colors = new[] { "#ff4d6d", "#ff8fa3" }, Shape = "dot", SpreadY = 1, Fall = 0 },
            ["confetti"] = new Kind { Count = 34, Life = 1700, Size = new[] { 7.0, 12 }, Dist = new[] { 60.0, 190 }, Up = new[] { -260.0, -120 }, Colors = new[] { "#ff5cc6", "#ffd23a", "#3ddc97", "#5fb8ff", "#b65cff", "#ff8a4a", "#ffffff" }, Shape = "rect", SpreadY = 0.5, Fall = 420 },
            ["gold"] = new Kind { Count = 12, Life = 700, Size = new[] { 6.0, 11 }, Dist = new[] { 40.0, 80 }, Up = new[] { -10.0, 10 }, Colors = new[] { "#ffd23a", "#fff3a0", "#ffffff" }, Shape = "star", SpreadY = 1, Fall = 18 },
            ["coin"] = new Kind { Count = 8, Life = 650, Size = new[] { 9.0, 12 }, Dist = new[] { 20.0, 50 }, Up = new[] { -60.0, -30 }, Colors = new[] { "#ffc233", "#ffe38a" }, Shape = "dot", SpreadY = 0.4, Fall = 80 },
        };

        sealed class Part
        {
            public double Size, W, H;
            public Interpolator Tx, Ty, Rot;
            public CardLayer Layer;
        }

        static readonly Interpolator Op = Fx.Lerp(new[] { 0, 0.08, 0.7, 1 }, new[] { 0.0, 1, 1, 0 });
        readonly Interpolator _sc;
        readonly Kind _k;
        readonly double _x, _y;
        readonly List<Part> _parts = new List<Part>();
        readonly AnimatedValue _t = new AnimatedValue(0);
        CompositeAnimation _a;
        public bool Done { get; private set; }
        public readonly List<CardLayer> Layers = new List<CardLayer>();

        static double Rnd(double a, double b) => a + Fx.Random() * (b - a);

        public Burst(string kind, double x, double y, double scale = 1)
        {
            _k = KINDS[kind];
            _x = x; _y = y;
            _sc = Fx.Lerp(new[] { 0, 0.15, 1 }, new[] { 0.2, 1, _k.Shape == "rect" ? 0.9 : 0.4 });
            for (int i = 0; i < _k.Count; i++)
            {
                double a = (double)i / _k.Count * Math.PI * 2 + Rnd(-0.3, 0.3);
                double d = Rnd(_k.Dist[0], _k.Dist[1]) * scale;
                double dx = Math.Cos(a) * d;
                double dy = Math.Sin(a) * d * _k.SpreadY + Rnd(_k.Up[0], _k.Up[1]) * scale;
                double fall = _k.Fall * scale * Rnd(0.7, 1.3);
                double size = Rnd(_k.Size[0], _k.Size[1]) * scale;
                string color = _k.Colors[i % _k.Colors.Length];
                double spin = Rnd(-1, 1) * (_k.Shape == "rect" ? 900 : 240);
                double s0 = _k.Shape == "rect" ? Rnd(0, 0.12) : 0;
                double s0x = s0 != 0 ? s0 : 0.0001;
                var p = new Part
                {
                    Size = size, W = size, H = _k.Shape == "rect" ? size * 0.5 : size,
                    Tx = Fx.Lerp(new[] { 0, s0x, 1 }, new[] { 0, 0, dx }),
                    // up and out, then the fall: a parabola from three points
                    Ty = Fx.Lerp(new[] { 0, s0x, 0.45, 1 }, new[] { 0, 0, dy * 0.8, dy + fall }),
                    Rot = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0, spin }),
                };
                double radius = _k.Shape == "rect" ? 2 : _k.Shape == "star" ? size * 0.18 : size;
                p.Layer = new CardLayer("burst " + kind);
                p.Layer.Set(new UiSvg((float)p.W, (float)p.H).Box(0, 0, (float)p.W, (float)p.H, new BoxStyle { Background = color, Radius = (float)radius }).Markup, (float)p.W, (float)p.H, 2);
                _parts.Add(p);
                Layers.Add(p.Layer);
            }
        }

        public void Start(Action onDone = null)
        {
            _a = Animated.Timing(_t, Fx.Timing(1, _k.Life, Easing.Out(Easing.Quad)));
            _a.Start(r => { Done = true; onDone?.Invoke(); });
        }

        public void Stop() { _a?.Stop(); Done = true; }

        /// <summary>Places the particles: `parent` maps the burst layer's coordinates to the screen.</summary>
        public void Place(Affine parent, float opacity)
        {
            double t = _t.GetValue(), op = Op.Evaluate(t), sc = _sc.Evaluate(t);
            foreach (var p in _parts)
            {
                var m = Affine.Translate(p.Tx.Evaluate(t), p.Ty.Evaluate(t)) * Affine.Rotate(p.Rot.Evaluate(t)) * Affine.ScaleBy(sc, sc);
                if (_k.Shape == "star") m = m * Affine.Rotate(45);
                p.Layer.Transform = parent * Affine.Translate(_x - p.Size / 2, _y - p.Size / 2) * Fx.About((float)p.W, (float)p.H, m);
                p.Layer.Opacity = (float)Math.Max(0, Math.Min(1, op)) * opacity;
            }
        }
    }

    /// <summary>fx.js CountUp: a number counting up to `value` over `ms` from `delay` (eased out, cubic), calling
    /// onTick now and then (the coin ticks).</summary>
    public sealed class CountUp
    {
        readonly double _value, _ms, _delay;
        readonly int _ticks;
        public Action<int> OnTick = _ => Snd.Play("sd_coinTick");
        public int Shown { get; private set; }
        Ticker _tk;
        int _timer, _raf;

        public CountUp(double value, double ms = 900, double delay = 0, int ticks = 10) { _value = value; _ms = ms; _delay = delay; _ticks = ticks; }

        public void Mount()
        {
            Unmount();
            Shown = 0;
            _tk = Ticker.Default;
            int lastTick = -1;
            _timer = _tk.SetTimeout(() =>
            {
                double t0 = _tk.Now;
                Action step = null;
                step = () =>
                {
                    double k = Math.Min(1, (_tk.Now - t0) / _ms);
                    double eased = 1 - JsMath.Pow(1 - k, 3);
                    Shown = (int)JsMath.Round(_value * eased);
                    int tick = (int)Math.Floor(k * _ticks);
                    if (tick != lastTick && k < 1)
                    {
                        lastTick = tick;
                        OnTick?.Invoke(tick);
                    }
                    if (k < 1) _raf = _tk.RequestAnimationFrame(step);
                };
                step();
            }, _delay);
        }

        public void Unmount()
        {
            if (_tk == null) return;
            _tk.ClearTimeout(_timer);
            _tk.CancelAnimationFrame(_raf);
        }
    }

    /// <summary>Overlays.js XpBar's motion: the fill from before → after (player levels), rolling over on each level up
    /// (the number goes up 651 ms apart).</summary>
    public sealed class XpFill
    {
        readonly AnimatedValue _t = new AnimatedValue(0);
        readonly double _delay;
        readonly double _beforeLv;
        readonly int _ups;
        readonly List<(double from, double to)> _legs = new List<(double, double)>();
        readonly List<int> _timers = new List<int>();
        CompositeAnimation _a;
        Ticker _tk;
        public double Level { get; private set; }
        public Action OnStart = () => Snd.Play("sd_xpFill");

        public XpFill(double beforeLevel, double beforeInto, double beforeNeed, double afterLevel, double afterInto, double afterNeed, double delay)
        {
            _delay = delay;
            _beforeLv = beforeLevel;
            _ups = (int)(afterLevel - beforeLevel);
            double from = beforeInto / beforeNeed;
            for (int i = 0; i < _ups; i++) { _legs.Add((from, 1)); from = 0; }
            _legs.Add((from, afterInto / afterNeed));
            Level = beforeLevel;
        }

        public void Mount()
        {
            Unmount();
            _tk = Ticker.Default;
            Level = _beforeLv;
            _t.SetValue(_legs[0].from);
            _timers.Add(_tk.SetTimeout(() => OnStart?.Invoke(), _delay));
            var seq = new List<CompositeAnimation>();
            for (int i = 0; i < _legs.Count; i++)
            {
                var leg = new List<CompositeAnimation>();
                if (i > 0) leg.Add(Animated.Timing(_t, new TimingConfig { ToValue = 0, Duration = 1, UseNativeDriver = false }));
                leg.Add(Animated.Timing(_t, new TimingConfig { ToValue = _legs[i].to, Duration = 650, Delay = i == 0 ? _delay : 0, Easing = Easing.Out(Easing.Cubic), UseNativeDriver = false }));
                seq.Add(Animated.Sequence(leg));
            }
            _a = Animated.Sequence(seq);
            _a.Start();
            for (int i = 1; i <= _ups; i++)
            {
                int lv = i;
                _timers.Add(_tk.SetTimeout(() => Level = _beforeLv + lv, _delay + i * 651));
            }
        }

        public void Unmount()
        {
            if (_tk != null) foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            _a?.Stop();
        }

        /// <summary>The fill, 0..1 of the track.</summary>
        public double Frac => _t.GetValue();
    }

    /// <summary>A button's press: in over 70 ms, back with a bouncy spring. While held the whole button (lip, face and
    /// label) shrinks to 0.92 about its centre, as the menu's Level crest does.</summary>
    public sealed class Press
    {
        /// <summary>How far a held button shrinks (to 1 - Shrink).</summary>
        public const double Shrink = 0.08;
        readonly AnimatedValue _t = new AnimatedValue(0);
        /// <summary>Pressed: it shrinks, with the app's button "tap" (CandyButton / SdButton onPressIn).</summary>
        public void Down() { Audio.Snd.Play("tap"); Animated.Timing(_t, Fx.Timing(1, 70)).Start(); }
        public void Up() => Animated.Spring(_t, Fx.Spring(0, 3.5, 260)).Start();
        public double T => _t.GetValue();
        /// <summary>The button's scale now: 1 → 0.92 as the press goes in.</summary>
        public double Scale => ScaleAt(T);
        /// <summary>The press's shrink about the centre of a w x h button, in the button's own space.</summary>
        public Affine Local(float w, float h) => Fx.Pressed(w, h, T);
        /// <summary>The scale for a press at `t` (0 up, 1 held).</summary>
        public static double ScaleAt(double t) => 1 - Shrink * t;
    }
}
