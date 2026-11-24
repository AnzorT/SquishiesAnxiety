// Port of react-native-web/dist/vendor/react-native/Animated/Easing.js and bezier.js (RN 0.74's Easing).
// Same formulas in the same operation order; Math.pow/cos go through JsMath so the doubles match V8.
//
// Use exactly like JS: Easing.Out(Easing.Quad), Easing.Bezier(0.55, 0, 1, 0.45), Easing.Out(Easing.Back(1.6)),
// Easing.Bounce, Easing.InOut(Easing.Sin). An easing is a Func<double, double>; the plain ones are methods,
// so pass them as method groups (Easing.Quad), the configurable ones are factories (Easing.Poly(4)).
using System;

namespace SquishSquad.Anim
{
    public static class Easing
    {
        public static double Step0(double n) { return n > 0 ? 1 : 0; }
        public static double Step1(double n) { return n >= 1 ? 1 : 0; }
        public static double Linear(double t) { return t; }

        static Func<double, double> _ease;
        /// <summary>bezier(0.42, 0, 1, 1)</summary>
        public static double Ease(double t)
        {
            if (_ease == null) _ease = Bezier(0.42, 0, 1, 1);
            return _ease(t);
        }

        public static double Quad(double t) { return t * t; }
        public static double Cubic(double t) { return t * t * t; }

        public static Func<double, double> Poly(double n) { return t => JsMath.Pow(t, n); }

        public static double Sin(double t) { return 1 - JsMath.Cos(t * JsMath.PI / 2); }
        public static double Circle(double t) { return 1 - Math.Sqrt(1 - t * t); }
        public static double Exp(double t) { return JsMath.Pow(2, 10 * (t - 1)); }

        public static Func<double, double> Elastic(double bounciness = 1)
        {
            double p = bounciness * JsMath.PI;
            return t => 1 - JsMath.Pow(JsMath.Cos(t * JsMath.PI / 2), 3) * JsMath.Cos(t * p);
        }

        public static Func<double, double> Back(double s = 1.70158)
        {
            return t => t * t * ((s + 1) * t - s);
        }

        public static double Bounce(double t)
        {
            if (t < 1 / 2.75)
            {
                return 7.5625 * t * t;
            }
            if (t < 2 / 2.75)
            {
                double t1 = t - 1.5 / 2.75;
                return 7.5625 * t1 * t1 + 0.75;
            }
            if (t < 2.5 / 2.75)
            {
                double t2 = t - 2.25 / 2.75;
                return 7.5625 * t2 * t2 + 0.9375;
            }
            double t3 = t - 2.625 / 2.75;
            return 7.5625 * t3 * t3 + 0.984375;
        }

        /// <summary>CSS cubic-bezier(x1, y1, x2, y2). Throws if an x is outside [0, 1], like the JS.</summary>
        public static Func<double, double> Bezier(double x1, double y1, double x2, double y2)
        {
            return new BezierEasing(x1, y1, x2, y2).Evaluate;
        }

        public static Func<double, double> In(Func<double, double> easing) { return easing; }

        public static Func<double, double> Out(Func<double, double> easing)
        {
            return t => 1 - easing(1 - t);
        }

        public static Func<double, double> InOut(Func<double, double> easing)
        {
            return t =>
            {
                if (t < 0.5) return easing(t * 2) / 2;
                return 1 - easing((1 - t) * 2) / 2;
            };
        }
    }

    /// <summary>gre/bezier-easing as vendored in RN (bezier.js), including its Float32Array sample table.</summary>
    public sealed class BezierEasing
    {
        const int NEWTON_ITERATIONS = 4;
        const double NEWTON_MIN_SLOPE = 0.001;
        const double SUBDIVISION_PRECISION = 0.0000001;
        const int SUBDIVISION_MAX_ITERATIONS = 10;
        const int kSplineTableSize = 11;
        const double kSampleStepSize = 1.0 / (kSplineTableSize - 1.0);

        readonly double mX1, mY1, mX2, mY2;
        // float32-rounded samples, held as doubles so later arithmetic is double like the JS
        readonly double[] sampleValues = new double[kSplineTableSize];

        static double A(double aA1, double aA2) { return 1.0 - 3.0 * aA2 + 3.0 * aA1; }
        static double B(double aA1, double aA2) { return 3.0 * aA2 - 6.0 * aA1; }
        static double C(double aA1) { return 3.0 * aA1; }
        static double CalcBezier(double aT, double aA1, double aA2) { return ((A(aA1, aA2) * aT + B(aA1, aA2)) * aT + C(aA1)) * aT; }
        static double GetSlope(double aT, double aA1, double aA2) { return 3.0 * A(aA1, aA2) * aT * aT + 2.0 * B(aA1, aA2) * aT + C(aA1); }

        static double BinarySubdivide(double aX, double aA, double aB, double x1, double x2)
        {
            double currentX, currentT;
            int i = 0;
            do
            {
                currentT = aA + (aB - aA) / 2.0;
                currentX = CalcBezier(currentT, x1, x2) - aX;
                if (currentX > 0.0) aB = currentT;
                else aA = currentT;
            } while (Math.Abs(currentX) > SUBDIVISION_PRECISION && ++i < SUBDIVISION_MAX_ITERATIONS);
            return currentT;
        }

        static double NewtonRaphsonIterate(double aX, double aGuessT, double x1, double x2)
        {
            for (int i = 0; i < NEWTON_ITERATIONS; ++i)
            {
                double currentSlope = GetSlope(aGuessT, x1, x2);
                if (currentSlope == 0.0) return aGuessT;
                double currentX = CalcBezier(aGuessT, x1, x2) - aX;
                aGuessT -= currentX / currentSlope;
            }
            return aGuessT;
        }

        public BezierEasing(double x1, double y1, double x2, double y2)
        {
            if (!(x1 >= 0 && x1 <= 1 && x2 >= 0 && x2 <= 1))
                throw new ArgumentException("bezier x values must be in [0, 1] range");
            mX1 = x1; mY1 = y1; mX2 = x2; mY2 = y2;
            if (mX1 != mY1 || mX2 != mY2)
            {
                for (int i = 0; i < kSplineTableSize; ++i)
                    sampleValues[i] = (float)CalcBezier(i * kSampleStepSize, mX1, mX2);
            }
        }

        double GetTForX(double aX)
        {
            double intervalStart = 0.0;
            int currentSample = 1;
            const int lastSample = kSplineTableSize - 1;
            for (; currentSample != lastSample && sampleValues[currentSample] <= aX; ++currentSample)
                intervalStart += kSampleStepSize;
            --currentSample;

            double dist = (aX - sampleValues[currentSample]) / (sampleValues[currentSample + 1] - sampleValues[currentSample]);
            double guessForT = intervalStart + dist * kSampleStepSize;
            double initialSlope = GetSlope(guessForT, mX1, mX2);
            if (initialSlope >= NEWTON_MIN_SLOPE) return NewtonRaphsonIterate(aX, guessForT, mX1, mX2);
            if (initialSlope == 0.0) return guessForT;
            return BinarySubdivide(aX, intervalStart, intervalStart + kSampleStepSize, mX1, mX2);
        }

        public double Evaluate(double x)
        {
            if (mX1 == mY1 && mX2 == mY2) return x;
            if (x == 0) return 0;
            if (x == 1) return 1;
            return CalcBezier(GetTForX(x), mY1, mY2);
        }
    }
}
