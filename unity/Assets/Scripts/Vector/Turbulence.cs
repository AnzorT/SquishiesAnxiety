// feTurbulence, exactly as the SVG specification's reference code defines it (SVG 1.1, 15.20): Perlin noise with a
// lattice and gradients from the spec's seeded generator, summed over octaves. The rigs' fabric grain and fuzz are
// this noise at fixed settings, so Unity can compute it once into a texture.
using System;
using System.Collections.Generic;

namespace SquishSquad.Vector
{
    public sealed class Turbulence
    {
        const int BSize = 0x100, BM = 0xff, PerlinN = 0x1000;
        const long RandM = 2147483647, RandA = 16807, RandQ = 127773, RandR = 2836;

        readonly int[] _lattice = new int[BSize + BSize + 2];
        readonly double[,,] _gradient = new double[4, BSize + BSize + 2, 2];

        static readonly Dictionary<long, Turbulence> Cache = new Dictionary<long, Turbulence>();
        public static Turbulence For(long seed)
        {
            lock (Cache)
            {
                if (!Cache.TryGetValue(seed, out var t)) Cache[seed] = t = new Turbulence(seed);
                return t;
            }
        }

        static long SetupSeed(long s) { if (s <= 0) s = -(s % (RandM - 1)) + 1; if (s > RandM - 1) s = RandM - 1; return s; }
        static long Random(long s) { long r = RandA * (s % RandQ) - RandR * (s / RandQ); if (r <= 0) r += RandM; return r; }

        Turbulence(long seed)
        {
            seed = SetupSeed(seed);
            int i, j, k;
            for (k = 0; k < 4; k++)
            {
                for (i = 0; i < BSize; i++)
                {
                    _lattice[i] = i;
                    for (j = 0; j < 2; j++) _gradient[k, i, j] = (double)(((seed = Random(seed)) % (BSize + BSize)) - BSize) / BSize;
                    double s = Math.Sqrt(_gradient[k, i, 0] * _gradient[k, i, 0] + _gradient[k, i, 1] * _gradient[k, i, 1]);
                    _gradient[k, i, 0] /= s; _gradient[k, i, 1] /= s;
                }
            }
            for (i = BSize - 1; i > 0; i--)
            {
                k = _lattice[i];
                _lattice[i] = _lattice[j = (int)((seed = Random(seed)) % BSize)];
                _lattice[j] = k;
            }
            for (i = 0; i < BSize + 2; i++)
            {
                _lattice[BSize + i] = _lattice[i];
                for (k = 0; k < 4; k++) for (j = 0; j < 2; j++) _gradient[k, BSize + i, j] = _gradient[k, i, j];
            }
        }

        static double SCurve(double t) => t * t * (3.0 - 2.0 * t);
        static double Lerp(double t, double a, double b) => a + t * (b - a);

        double Noise2(int ch, double vx, double vy)
        {
            double t = vx + PerlinN;
            int bx0 = ((int)t) & BM, bx1 = (bx0 + 1) & BM;
            double rx0 = t - (int)t, rx1 = rx0 - 1.0;
            t = vy + PerlinN;
            int by0 = ((int)t) & BM, by1 = (by0 + 1) & BM;
            double ry0 = t - (int)t, ry1 = ry0 - 1.0;
            int i = _lattice[bx0], j = _lattice[bx1];
            int b00 = _lattice[i + by0], b10 = _lattice[j + by0], b01 = _lattice[i + by1], b11 = _lattice[j + by1];
            double sx = SCurve(rx0), sy = SCurve(ry0);
            double u = rx0 * _gradient[ch, b00, 0] + ry0 * _gradient[ch, b00, 1];
            double v = rx1 * _gradient[ch, b10, 0] + ry0 * _gradient[ch, b10, 1];
            double a = Lerp(sx, u, v);
            u = rx0 * _gradient[ch, b01, 0] + ry1 * _gradient[ch, b01, 1];
            v = rx1 * _gradient[ch, b11, 0] + ry1 * _gradient[ch, b11, 1];
            double b = Lerp(sx, u, v);
            return Lerp(sy, a, b);
        }

        // the spec's turbulence(): channel 0-3 (R, G, B, A) at a point, no stitching
        public double Turb(int channel, double[] point, double baseFreqX, double baseFreqY, int octaves, bool fractalSum)
        {
            double sum = 0, vx = point[0] * baseFreqX, vy = point[1] * baseFreqY, ratio = 1;
            for (int o = 0; o < octaves; o++)
            {
                double n = Noise2(channel, vx, vy);
                sum += fractalSum ? n / ratio : Math.Abs(n) / ratio;
                vx *= 2; vy *= 2; ratio *= 2;
            }
            return sum;
        }

        // the colour channel value feTurbulence outputs (0..1): fractalNoise maps -1..1 to 0..1
        public float Value(int channel, double x, double y, double baseFreqX, double baseFreqY, int octaves, bool fractalSum)
        {
            double v = Turb(channel, new[] { x, y }, baseFreqX, baseFreqY, octaves, fractalSum);
            if (fractalSum) v = (v + 1) / 2;
            return (float)Math.Max(0, Math.Min(1, v));
        }
    }
}
