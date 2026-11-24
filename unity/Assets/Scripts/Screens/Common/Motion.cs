// Short forms of React Native's Animated (SquishSquad.Anim, exact) for the screens' motions, and interpolate().
using System;
using SquishSquad.Anim;

namespace SquishSquad.Screens
{
    public static class Motion
    {
        public static CompositeAnimation Timing(AnimatedValue v, double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            Animated.Timing(v, new TimingConfig { ToValue = to, Duration = ms, Easing = easing, Delay = delay, UseNativeDriver = true });

        public static readonly Func<double, double> InOutSin = Easing.InOut(Easing.Sin);
        public static readonly Func<double, double> OutQuad = Easing.Out(Easing.Quad);
        public static readonly Func<double, double> Linear = Easing.Linear;

        /// <summary>Animated.loop(sequence(0 → 1, 1 → 0)), each half `half` ms (an up-and-down breath).</summary>
        public static CompositeAnimation PingPong(AnimatedValue v, double half, Func<double, double> easing = null, double half2 = -1) =>
            Animated.Loop(Animated.Sequence(Timing(v, 1, half, easing ?? InOutSin), Timing(v, 0, half2 < 0 ? half : half2, easing ?? InOutSin)));

        /// <summary>Animated.loop(timing 0 → 1 over `ms`, linear): a phase.</summary>
        public static CompositeAnimation Phase(AnimatedValue v, double ms) => Animated.Loop(Timing(v, 1, ms, Linear));

        /// <summary>interpolate({ inputRange, outputRange }) with clamping or extending at the ends.</summary>
        public static double Lerp(double x, double[] xs, double[] ys, bool clamp = true)
        {
            int n = xs.Length;
            int i = 1;
            while (i < n - 1 && x > xs[i]) i++;
            if (clamp) { if (x <= xs[0]) return ys[0]; if (x >= xs[n - 1]) return ys[n - 1]; }
            double x0 = xs[i - 1], x1 = xs[i];
            if (x1 == x0) return x <= x0 ? ys[i - 1] : ys[i];
            return ys[i - 1] + (ys[i] - ys[i - 1]) * (x - x0) / (x1 - x0);
        }

        /// <summary>idleLoop.js usePingPong's keyframes: 0 → 1 → 0 eased (UP_DOWN) at a phase 0..1.</summary>
        public static double UpDown(double phase)
        {
            // 17 keyframes of (1 - cos 2πp) / 2, read linearly between them as the app's interpolation does
            double p = phase * 16;
            int i = Math.Min(15, (int)Math.Floor(p));
            double a = (1 - Math.Cos(2 * Math.PI * i / 16)) / 2, b = (1 - Math.Cos(2 * Math.PI * (i + 1) / 16)) / 2;
            return a + (b - a) * (p - i);
        }
    }
}
