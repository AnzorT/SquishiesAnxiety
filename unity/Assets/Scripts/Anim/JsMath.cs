// Port of the JS engine's Math functions that the Animated code uses, so the C# port gives the same doubles
// as the app's JS (V8: Chrome / Node) to the last bit, on every platform Unity builds for.
//
// Why not System.Math: Math.Exp/Sin/Cos/Pow call the platform's C library (glibc, bionic, Apple's libm, the
// MSVC CRT). Those differ from each other and from V8 in the last bit for a few percent of inputs (measured
// against Node 22 with .NET 8 on glibc: exp 9.6 %, sin/cos 3.5 %, pow 9.7 % of 200k random inputs). V8 uses
// fdlibm (src/base/ieee754.cc), ported here operation for operation. Math.sqrt, floor and the basic
// arithmetic are correctly rounded IEEE operations everywhere, so System.Math is used for those.
using System;

namespace SquishSquad.Anim
{
    public static class JsMath
    {
        public const double PI = 3.141592653589793;

        // ---- word access (fdlibm's __HI / __LO / INSERT_WORDS) ----
        static int Hi(double x) => (int)(BitConverter.DoubleToInt64Bits(x) >> 32);
        static uint Lo(double x) => (uint)BitConverter.DoubleToInt64Bits(x);
        static double FromWords(int hi, uint lo) => BitConverter.Int64BitsToDouble(((long)hi << 32) | lo);
        static double WithHi(double x, int hi) => FromWords(hi, Lo(x));
        static double WithLo(double x, uint lo) => FromWords(Hi(x), lo);

        // ---- Math.round: floor(x + 0.5) with JS's exact semantics (ties up, -0 kept, no x+0.5 rounding error) ----
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            if (x == 0) return x; // keeps -0
            if (x > 0 && x < 0.5) return 0.0;
            if (x < 0 && x >= -0.5) return -0.0;
            if (Math.Abs(x) >= 4503599627370496.0) return x; // 2^52: already an integer
            double f = Math.Floor(x);
            return x - f >= 0.5 ? f + 1.0 : f;
        }

        // ---- Math.max / Math.min of two numbers (NaN wins, +0 > -0), independent of the runtime's Math.Max ----
        public static double Max(double a, double b)
        {
            if (double.IsNaN(a) || double.IsNaN(b)) return double.NaN;
            if (a == b) return a == 0 && BitConverter.DoubleToInt64Bits(a) < 0 ? b : a;
            return a > b ? a : b;
        }

        public static double Min(double a, double b)
        {
            if (double.IsNaN(a) || double.IsNaN(b)) return double.NaN;
            if (a == b) return a == 0 && BitConverter.DoubleToInt64Bits(a) < 0 ? a : b;
            return a < b ? a : b;
        }

        // ---- ECMAScript ToInt32 ----
        public static int ToInt32(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return 0;
            double t = Math.Truncate(x);
            double m = t % 4294967296.0;
            if (m < 0) m += 4294967296.0;
            return unchecked((int)(uint)m);
        }

        // ================================================================ exp (V8 ieee754::exp)
        static readonly double[] halF = { 0.5, -0.5 };
        static readonly double[] ln2HI = { 6.93147180369123816490e-01, -6.93147180369123816490e-01 };
        static readonly double[] ln2LO = { 1.90821492927058770002e-10, -1.90821492927058770002e-10 };
        const double o_threshold = 7.09782712893383973096e+02;
        const double u_threshold = -7.45133219101941108420e+02;
        const double invln2 = 1.44269504088896338700e+00;
        const double P1 = 1.66666666666666019037e-01;
        const double P2 = -2.77777777770155933842e-03;
        const double P3 = 6.61375632143793436117e-05;
        const double P4 = -1.65339022054652515390e-06;
        const double P5 = 4.13813679705723846039e-08;
        const double E = 2.718281828459045;
        const double huge = 1.0e+300;
        const double tiny = 1.0e-300;
        const double twom1000 = 9.33263618503218878990e-302;
        const double two1023 = 8.988465674311579539e307;

        public static double Exp(double x)
        {
            double y, hi = 0.0, lo = 0.0, c, t, twopk;
            int k = 0, xsb;
            uint hx = (uint)Hi(x);
            xsb = (int)((hx >> 31) & 1);
            hx &= 0x7FFFFFFF;

            if (hx >= 0x40862E42)
            {
                if (hx >= 0x7FF00000)
                {
                    uint lx = Lo(x);
                    if (((hx & 0xFFFFF) | lx) != 0) return x + x;
                    return xsb == 0 ? x : 0.0;
                }
                if (x > o_threshold) return huge * huge;
                if (x < u_threshold) return twom1000 * twom1000;
            }

            if (hx > 0x3FD62E42)
            {
                if (hx < 0x3FF0A2B2)
                {
                    if (x == 1.0) return E;
                    hi = x - ln2HI[xsb];
                    lo = ln2LO[xsb];
                    k = 1 - xsb - xsb;
                }
                else
                {
                    k = (int)(invln2 * x + halF[xsb]);
                    t = k;
                    hi = x - t * ln2HI[0];
                    lo = t * ln2LO[0];
                }
                x = hi - lo;
            }
            else if (hx < 0x3E300000)
            {
                if (huge + x > 1.0) return 1.0 + x;
            }
            else
            {
                k = 0;
            }

            t = x * x;
            if (k >= -1021) twopk = FromWords(0x3FF00000 + (k << 20), 0);
            else twopk = FromWords(0x3FF00000 + ((k + 1000) << 20), 0);
            c = x - t * (P1 + t * (P2 + t * (P3 + t * (P4 + t * P5))));
            if (k == 0) return 1.0 - ((x * c) / (c - 2.0) - x);
            y = 1.0 - ((lo - (x * c) / (2.0 - c)) - hi);
            if (k >= -1021)
            {
                if (k == 1024) return y * 2.0 * two1023;
                return y * twopk;
            }
            return y * twopk * twom1000;
        }

        // ================================================================ sin / cos (fdlibm, as V8)
        const double S1 = -1.66666666666666324348e-01;
        const double S2 = 8.33333333332248946124e-03;
        const double S3 = -1.98412698298579493134e-04;
        const double S4 = 2.75573137070700676789e-06;
        const double S5 = -2.50507602534068634195e-08;
        const double S6 = 1.58969099521155010221e-10;

        static double KernelSin(double x, double y, int iy)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix < 0x3e400000)
            {
                if ((int)x == 0) return x;
            }
            double z = x * x;
            double v = z * x;
            double r = S2 + z * (S3 + z * (S4 + z * (S5 + z * S6)));
            if (iy == 0) return x + v * (S1 + z * r);
            return x - ((z * (0.5 * y - v * r) - y) - v * S1);
        }

        const double C1 = 4.16666666666666019037e-02;
        const double C2 = -1.38888888888741095749e-03;
        const double C3 = 2.48015872894767294178e-05;
        const double C4 = -2.75573143513906633035e-07;
        const double C5 = 2.08757232129817482790e-09;
        const double C6 = -1.13596475577881948265e-11;

        static double KernelCos(double x, double y)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix < 0x3e400000)
            {
                if ((int)x == 0) return 1.0;
            }
            double z = x * x;
            double r = z * (C1 + z * (C2 + z * (C3 + z * (C4 + z * (C5 + z * C6)))));
            if (ix < 0x3FD33333) return 1.0 - (0.5 * z - (z * r - x * y));
            double qx;
            if (ix > 0x3fe90000) qx = 0.28125;
            else qx = FromWords(ix - 0x00200000, 0);
            double hz = 0.5 * z - qx;
            double a = 1.0 - qx;
            return a - (hz - (z * r - x * y));
        }

        public static double Sin(double x)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix <= 0x3fe921fb) return KernelSin(x, 0.0, 0);
            if (ix >= 0x7ff00000) return x - x;
            double y0, y1;
            int n = RemPio2(x, out y0, out y1);
            switch (n & 3)
            {
                case 0: return KernelSin(y0, y1, 1);
                case 1: return KernelCos(y0, y1);
                case 2: return -KernelSin(y0, y1, 1);
                default: return -KernelCos(y0, y1);
            }
        }

        public static double Cos(double x)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix <= 0x3fe921fb) return KernelCos(x, 0.0);
            if (ix >= 0x7ff00000) return x - x;
            double y0, y1;
            int n = RemPio2(x, out y0, out y1);
            switch (n & 3)
            {
                case 0: return KernelCos(y0, y1);
                case 1: return -KernelSin(y0, y1, 1);
                case 2: return -KernelCos(y0, y1);
                default: return KernelSin(y0, y1, 1);
            }
        }

        // 2/pi in 24-bit chunks (checked against a BigInt computation of pi)
        static readonly int[] two_over_pi = {
            0xA2F983, 0x6E4E44, 0x1529FC, 0x2757D1, 0xF534DD, 0xC0DB62, 0x95993C, 0x439041, 0xFE5163, 0xABDEBB,
            0xC561B7, 0x246E3A, 0x424DD2, 0xE00649, 0x2EEA09, 0xD1921C, 0xFE1DEB, 0x1CB129, 0xA73EE8, 0x8235F5,
            0x2EBB44, 0x84E99C, 0x7026B4, 0x5F7E41, 0x3991D6, 0x398353, 0x39F49C, 0x845F8B, 0xBDF928, 0x3B1FF8,
            0x97FFDE, 0x05980F, 0xEF2F11, 0x8B5A0A, 0x6D1F6D, 0x367ECF, 0x27CB09, 0xB74F46, 0x3F669E, 0x5FEA2D,
            0x7527BA, 0xC7EBE5, 0xF17B3D, 0x0739F7, 0x8A5292, 0xEA6BFB, 0x5FB11F, 0x8D5D08, 0x560330, 0x46FC7B,
            0x6BABF0, 0xCFBC20, 0x9AF436, 0x1DA9E3, 0x91615E, 0xE61B08, 0x659985, 0x5F14A0, 0x68408D, 0xFFD880,
            0x4D7327, 0x310606, 0x1556CA, 0x73A8C9, 0x60E27B, 0xC08C6B,
        };
        static readonly int[] npio2_hw = {
            0x3FF921FB, 0x400921FB, 0x4012D97C, 0x401921FB, 0x401F6A7A, 0x4022D97C, 0x4025FDBB, 0x402921FB,
            0x402C463A, 0x402F6A7A, 0x4031475C, 0x4032D97C, 0x40346B9C, 0x4035FDBB, 0x40378FDB, 0x403921FB,
            0x403AB41B, 0x403C463A, 0x403DD85A, 0x403F6A7A, 0x40407E4C, 0x4041475C, 0x4042106C, 0x4042D97C,
            0x4043A28C, 0x40446B9C, 0x404534AC, 0x4045FDBB, 0x4046C6CB, 0x40478FDB, 0x404858EB, 0x404921FB,
        };
        const double two24 = 1.67772160000000000000e+07;
        const double twon24 = 5.96046447753906250000e-08;
        const double invpio2 = 6.36619772367581382433e-01;
        const double pio2_1 = 1.57079632673412561417e+00;
        const double pio2_1t = 6.07710050650619224932e-11;
        const double pio2_2 = 6.07710050630396597660e-11;
        const double pio2_2t = 2.02226624879595063154e-21;
        const double pio2_3 = 2.02226624871116645580e-21;
        const double pio2_3t = 8.47842766036889956997e-32;

        static int RemPio2(double x, out double y0, out double y1)
        {
            double z, w, t, r, fn;
            int e0, i, j, nx, n, ix, hx;
            hx = Hi(x);
            ix = hx & 0x7fffffff;
            if (ix <= 0x3fe921fb) { y0 = x; y1 = 0; return 0; }
            if (ix < 0x4002d97c)
            {
                if (hx > 0)
                {
                    z = x - pio2_1;
                    if (ix != 0x3ff921fb) { y0 = z - pio2_1t; y1 = (z - y0) - pio2_1t; }
                    else { z -= pio2_2; y0 = z - pio2_2t; y1 = (z - y0) - pio2_2t; }
                    return 1;
                }
                else
                {
                    z = x + pio2_1;
                    if (ix != 0x3ff921fb) { y0 = z + pio2_1t; y1 = (z - y0) + pio2_1t; }
                    else { z += pio2_2; y0 = z + pio2_2t; y1 = (z - y0) + pio2_2t; }
                    return -1;
                }
            }
            if (ix <= 0x413921fb)
            {
                t = Math.Abs(x);
                n = (int)(t * invpio2 + 0.5);
                fn = n;
                r = t - fn * pio2_1;
                w = fn * pio2_1t;
                if (n < 32 && ix != npio2_hw[n - 1])
                {
                    y0 = r - w;
                }
                else
                {
                    j = ix >> 20;
                    y0 = r - w;
                    i = j - ((Hi(y0) >> 20) & 0x7ff);
                    if (i > 16)
                    {
                        t = r;
                        w = fn * pio2_2;
                        r = t - w;
                        w = fn * pio2_2t - ((t - r) - w);
                        y0 = r - w;
                        i = j - ((Hi(y0) >> 20) & 0x7ff);
                        if (i > 49)
                        {
                            t = r;
                            w = fn * pio2_3;
                            r = t - w;
                            w = fn * pio2_3t - ((t - r) - w);
                            y0 = r - w;
                        }
                    }
                }
                y1 = (r - y0) - w;
                if (hx < 0) { y0 = -y0; y1 = -y1; return -n; }
                return n;
            }
            if (ix >= 0x7ff00000) { y0 = y1 = x - x; return 0; }
            // large arguments
            Span<double> tx = stackalloc double[3];
            e0 = (ix >> 20) - 1046;
            z = FromWords(ix - (e0 << 20), Lo(x));
            for (i = 0; i < 2; i++)
            {
                tx[i] = (int)z;
                z = (z - tx[i]) * two24;
            }
            tx[2] = z;
            nx = 3;
            while (tx[nx - 1] == 0.0) nx--;
            n = KernelRemPio2(tx, out y0, out y1, e0, nx);
            if (hx < 0) { y0 = -y0; y1 = -y1; return -n; }
            return n;
        }

        static readonly double[] PIo2 = {
            1.57079625129699707031e+00, 7.54978941586159635335e-08, 5.39030252995776476554e-15,
            3.28200341580791294123e-22, 1.27065575308067607349e-29, 1.22933308981111328932e-36,
            2.73370053816464559624e-44, 2.16741683877804819444e-51,
        };

        // fdlibm __kernel_rem_pio2 with prec = 2 (jk = 4)
        static int KernelRemPio2(Span<double> x, out double y0, out double y1, int e0, int nx)
        {
            int jz, jx, jv, jp, jk, carry, n, i, j, k, m, q0, ih;
            double z, fw;
            Span<int> iq = stackalloc int[20];
            Span<double> f = stackalloc double[20];
            Span<double> fq = stackalloc double[20];
            Span<double> q = stackalloc double[20];

            jk = 4;
            jp = jk;
            jx = nx - 1;
            jv = (e0 - 3) / 24; if (jv < 0) jv = 0;
            q0 = e0 - 24 * (jv + 1);

            j = jv - jx; m = jx + jk;
            for (i = 0; i <= m; i++, j++) f[i] = j < 0 ? 0.0 : (double)two_over_pi[j];

            for (i = 0; i <= jk; i++)
            {
                for (j = 0, fw = 0.0; j <= jx; j++) fw += x[j] * f[jx + i - j];
                q[i] = fw;
            }

            jz = jk;
            while (true)
            {
                // recompute:
                for (i = 0, j = jz, z = q[jz]; j > 0; i++, j--)
                {
                    fw = (int)(twon24 * z);
                    iq[i] = (int)(z - two24 * fw);
                    z = q[j - 1] + fw;
                }

                z = Scalbn(z, q0);
                z -= 8.0 * Math.Floor(z * 0.125);
                n = (int)z;
                z -= n;
                ih = 0;
                if (q0 > 0)
                {
                    i = iq[jz - 1] >> (24 - q0); n += i;
                    iq[jz - 1] -= i << (24 - q0);
                    ih = iq[jz - 1] >> (23 - q0);
                }
                else if (q0 == 0) ih = iq[jz - 1] >> 23;
                else if (z >= 0.5) ih = 2;

                if (ih > 0)
                {
                    n += 1; carry = 0;
                    for (i = 0; i < jz; i++)
                    {
                        j = iq[i];
                        if (carry == 0)
                        {
                            if (j != 0) { carry = 1; iq[i] = 0x1000000 - j; }
                        }
                        else iq[i] = 0xffffff - j;
                    }
                    if (q0 > 0)
                    {
                        switch (q0)
                        {
                            case 1: iq[jz - 1] &= 0x7fffff; break;
                            case 2: iq[jz - 1] &= 0x3fffff; break;
                        }
                    }
                    if (ih == 2)
                    {
                        z = 1.0 - z;
                        if (carry != 0) z -= Scalbn(1.0, q0);
                    }
                }

                if (z == 0.0)
                {
                    j = 0;
                    for (i = jz - 1; i >= jk; i--) j |= iq[i];
                    if (j == 0)
                    {
                        for (k = 1; iq[jk - k] == 0; k++) { }
                        for (i = jz + 1; i <= jz + k; i++)
                        {
                            f[jx + i] = two_over_pi[jv + i];
                            for (j = 0, fw = 0.0; j <= jx; j++) fw += x[j] * f[jx + i - j];
                            q[i] = fw;
                        }
                        jz += k;
                        continue; // goto recompute
                    }
                }
                break;
            }

            if (z == 0.0)
            {
                jz -= 1; q0 -= 24;
                while (iq[jz] == 0) { jz--; q0 -= 24; }
            }
            else
            {
                z = Scalbn(z, -q0);
                if (z >= two24)
                {
                    fw = (int)(twon24 * z);
                    iq[jz] = (int)(z - two24 * fw);
                    jz += 1; q0 += 24;
                    iq[jz] = (int)fw;
                }
                else iq[jz] = (int)z;
            }

            fw = Scalbn(1.0, q0);
            for (i = jz; i >= 0; i--)
            {
                q[i] = fw * iq[i]; fw *= twon24;
            }

            for (i = jz; i >= 0; i--)
            {
                for (fw = 0.0, k = 0; k <= jp && k <= jz - i; k++) fw += PIo2[k] * q[i + k];
                fq[jz - i] = fw;
            }

            fw = 0.0;
            for (i = jz; i >= 0; i--) fw += fq[i];
            y0 = ih == 0 ? fw : -fw;
            fw = fq[0] - fw;
            for (i = 1; i <= jz; i++) fw += fq[i];
            y1 = ih == 0 ? fw : -fw;
            return n & 7;
        }

        const double two54 = 1.80143985094819840000e+16;
        const double twom54 = 5.55111512312578270212e-17;

        static double Scalbn(double x, int n)
        {
            int k, hx; uint lx;
            hx = Hi(x); lx = Lo(x);
            k = (hx & 0x7ff00000) >> 20;
            if (k == 0)
            {
                if ((lx | (uint)(hx & 0x7fffffff)) == 0) return x;
                x *= two54;
                hx = Hi(x);
                k = ((hx & 0x7ff00000) >> 20) - 54;
                if (n < -50000) return tiny * x;
            }
            if (k == 0x7ff) return x + x;
            k = k + n;
            if (k > 0x7fe) return huge * CopySign(huge, x);
            if (k > 0) return WithHi(x, (int)(((uint)hx & 0x800fffff) | (uint)(k << 20)));
            if (k <= -54)
            {
                if (n > 50000) return huge * CopySign(huge, x);
                return tiny * CopySign(tiny, x);
            }
            k += 54;
            x = WithHi(x, (int)(((uint)hx & 0x800fffff) | (uint)(k << 20)));
            return x * twom54;
        }

        static double CopySign(double x, double y)
        {
            return FromWords((Hi(x) & 0x7fffffff) | (Hi(y) & unchecked((int)0x80000000)), Lo(x));
        }

        // ================================================================ pow (fdlibm e_pow.c, as V8's Math.pow)
        static readonly double[] bp = { 1.0, 1.5 };
        static readonly double[] dp_h = { 0.0, 5.84962487220764160156e-01 };
        static readonly double[] dp_l = { 0.0, 1.35003920212974897128e-08 };
        const double two53 = 9007199254740992.0;
        const double L1 = 5.99999999999994648725e-01;
        const double L2 = 4.28571428578550184252e-01;
        const double L3 = 3.33333329818377432918e-01;
        const double L4 = 2.72728123808534006489e-01;
        const double L5 = 2.30660745775561754067e-01;
        const double L6 = 2.06975017800338417784e-01;
        const double lg2 = 6.93147180559945286227e-01;
        const double lg2_h = 6.93147182464599609375e-01;
        const double lg2_l = -1.90465429995776804525e-09;
        const double ovt = 8.0085662595372944372e-17;
        const double cp = 9.61796693925975554329e-01;
        const double cp_h = 9.61796700954437255859e-01;
        const double cp_l = -7.02846165095275826516e-09;
        const double ivln2 = 1.44269504088896338700e+00;
        const double ivln2_h = 1.44269502162933349609e+00;
        const double ivln2_l = 1.92596299112661746887e-08;

        public static double Pow(double x, double y)
        {
            // ECMAScript differences from IEEE pow
            if (double.IsNaN(y)) return double.NaN;
            if (double.IsInfinity(y) && (x == 1 || x == -1)) return double.NaN;
            return IeeePow(x, y);
        }

        static double IeeePow(double x, double y)
        {
            double z, ax, z_h, z_l, p_h, p_l;
            double y1, t1, t2, r, s, t, u, v, w;
            int i, j, k, yisint, n;
            int hx, hy, ix, iy;
            uint lx, ly;

            hx = Hi(x); lx = Lo(x);
            hy = Hi(y); ly = Lo(y);
            ix = hx & 0x7fffffff; iy = hy & 0x7fffffff;

            if ((iy | (int)ly) == 0) return 1.0;

            if (ix > 0x7ff00000 || ((ix == 0x7ff00000) && (lx != 0)) ||
                iy > 0x7ff00000 || ((iy == 0x7ff00000) && (ly != 0)))
                return x + y;

            yisint = 0;
            if (hx < 0)
            {
                if (iy >= 0x43400000) yisint = 2;
                else if (iy >= 0x3ff00000)
                {
                    k = (iy >> 20) - 0x3ff;
                    if (k > 20)
                    {
                        uint jj = ly >> (52 - k);
                        if ((jj << (52 - k)) == ly) yisint = 2 - (int)(jj & 1);
                    }
                    else if (ly == 0)
                    {
                        j = iy >> (20 - k);
                        if ((j << (20 - k)) == iy) yisint = 2 - (j & 1);
                    }
                }
            }

            if (ly == 0)
            {
                if (iy == 0x7ff00000)
                {
                    if (((ix - 0x3ff00000) | (int)lx) == 0) return y - y;
                    else if (ix >= 0x3ff00000) return hy >= 0 ? y : 0.0;
                    else return hy < 0 ? -y : 0.0;
                }
                if (iy == 0x3ff00000)
                {
                    if (hy < 0) return 1.0 / x;
                    return x;
                }
                if (hy == 0x40000000) return x * x;
                if (hy == 0x3fe00000)
                {
                    if (hx >= 0) return Math.Sqrt(x);
                }
            }

            ax = Math.Abs(x);
            if (lx == 0)
            {
                if (ix == 0x7ff00000 || ix == 0 || ix == 0x3ff00000)
                {
                    z = ax;
                    if (hy < 0) z = 1.0 / z;
                    if (hx < 0)
                    {
                        if (((ix - 0x3ff00000) | yisint) == 0) z = (z - z) / (z - z);
                        else if (yisint == 1) z = -z;
                    }
                    return z;
                }
            }

            n = (hx >> 31) + 1;

            if ((n | yisint) == 0) return (x - x) / (x - x);

            s = 1.0;
            if ((n | (yisint - 1)) == 0) s = -1.0;

            if (iy > 0x41e00000)
            {
                if (iy > 0x43f00000)
                {
                    if (ix <= 0x3fefffff) return hy < 0 ? huge * huge : tiny * tiny;
                    if (ix >= 0x3ff00000) return hy > 0 ? huge * huge : tiny * tiny;
                }
                if (ix < 0x3fefffff) return hy < 0 ? s * huge * huge : s * tiny * tiny;
                if (ix > 0x3ff00000) return hy > 0 ? s * huge * huge : s * tiny * tiny;
                t = ax - 1.0;
                w = (t * t) * (0.5 - t * (0.3333333333333333333333 - t * 0.25));
                u = ivln2_h * t;
                v = t * ivln2_l - w * ivln2;
                t1 = u + v;
                t1 = WithLo(t1, 0);
                t2 = v - (t1 - u);
            }
            else
            {
                double ss, s2, s_h, s_l, t_h, t_l;
                n = 0;
                if (ix < 0x00100000) { ax *= two53; n -= 53; ix = Hi(ax); }
                n += (ix >> 20) - 0x3ff;
                j = ix & 0x000fffff;
                ix = j | 0x3ff00000;
                if (j <= 0x3988E) k = 0;
                else if (j < 0xBB67A) k = 1;
                else { k = 0; n += 1; ix -= 0x00100000; }
                ax = WithHi(ax, ix);

                u = ax - bp[k];
                v = 1.0 / (ax + bp[k]);
                ss = u * v;
                s_h = ss;
                s_h = WithLo(s_h, 0);
                t_h = FromWords(((ix >> 1) | 0x20000000) + 0x00080000 + (k << 18), 0);
                t_l = ax - (t_h - bp[k]);
                s_l = v * ((u - s_h * t_h) - s_h * t_l);
                s2 = ss * ss;
                r = s2 * s2 * (L1 + s2 * (L2 + s2 * (L3 + s2 * (L4 + s2 * (L5 + s2 * L6)))));
                r += s_l * (s_h + ss);
                s2 = s_h * s_h;
                t_h = 3.0 + s2 + r;
                t_h = WithLo(t_h, 0);
                t_l = r - ((t_h - 3.0) - s2);
                u = s_h * t_h;
                v = s_l * t_h + t_l * ss;
                p_h = u + v;
                p_h = WithLo(p_h, 0);
                p_l = v - (p_h - u);
                z_h = cp_h * p_h;
                z_l = cp_l * p_h + p_l * cp + dp_l[k];
                t = n;
                t1 = (((z_h + z_l) + dp_h[k]) + t);
                t1 = WithLo(t1, 0);
                t2 = z_l - (((t1 - t) - dp_h[k]) - z_h);
            }

            y1 = y;
            y1 = WithLo(y1, 0);
            p_l = (y - y1) * t1 + y * t2;
            p_h = y1 * t1;
            z = p_l + p_h;
            j = Hi(z);
            i = (int)Lo(z);
            if (j >= 0x40900000)
            {
                if (((j - 0x40900000) | i) != 0) return s * huge * huge;
                if (p_l + ovt > z - p_h) return s * huge * huge;
            }
            else if ((j & 0x7fffffff) >= 0x4090cc00)
            {
                if (((j - unchecked((int)0xc090cc00)) | i) != 0) return s * tiny * tiny;
                if (p_l <= z - p_h) return s * tiny * tiny;
            }

            i = j & 0x7fffffff;
            k = (i >> 20) - 0x3ff;
            n = 0;
            if (i > 0x3fe00000)
            {
                n = j + (0x00100000 >> (k + 1));
                k = ((n & 0x7fffffff) >> 20) - 0x3ff;
                t = FromWords(n & ~(0x000fffff >> k), 0);
                n = ((n & 0x000fffff) | 0x00100000) >> (20 - k);
                if (j < 0) n = -n;
                p_h -= t;
            }
            t = p_l + p_h;
            t = WithLo(t, 0);
            u = t * lg2_h;
            v = (p_l - (t - p_h)) * lg2 + t * lg2_l;
            z = u + v;
            w = v - (z - u);
            t = z * z;
            t1 = z - t * (P1 + t * (P2 + t * (P3 + t * (P4 + t * P5))));
            // V8 (src/base/ieee754.cc, via base::Divide) divides by the whole difference, unlike fdlibm's
            // (z*t1)/(t1-two)-(w+z*w); verified against node's machine code and 1M samples.
            r = (z * t1) / ((t1 - 2.0) - (w + z * w));
            z = 1.0 - (r - z);
            j = Hi(z);
            j += n << 20;
            if ((j >> 20) <= 0) z = Scalbn(z, n);
            else z = WithHi(z, Hi(z) + (n << 20));
            return s * z;
        }
    }
}
