// Math's functions with V8's last bits: V8 computes Math.sin / cos (and friends) with its port of fdlibm
// (v8/src/base/ieee754.cc), not the C library, so the same port here makes the rig's numbers the same as the app's on
// every phone (Android's libm, the PC's and V8's all differ in the last bit now and then). Where a function isn't
// ported, the platform's is used (System.Math).
using System;

namespace SquishSquad.Creatures.Js
{
    public static class FdLibm
    {
        static int Hi(double x) => (int)(BitConverter.DoubleToInt64Bits(x) >> 32);
        static uint Lo(double x) => (uint)BitConverter.DoubleToInt64Bits(x);
        static double Make(int hi, uint lo) => BitConverter.Int64BitsToDouble(((long)hi << 32) | lo);

        const double S1 = -1.66666666666666324348e-01, S2 = 8.33333333332248946124e-03, S3 = -1.98412698298579493134e-04,
            S4 = 2.75573137070700676789e-06, S5 = -2.50507602534068634195e-08, S6 = 1.58969099521155010221e-10;
        static double KernelSin(double x, double y, int iy)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix < 0x3e400000) { if ((int)x == 0) return x; }
            double z = x * x, v = z * x, r = S2 + z * (S3 + z * (S4 + z * (S5 + z * S6)));
            if (iy == 0) return x + v * (S1 + z * r);
            return x - ((z * (0.5 * y - v * r) - y) - v * S1);
        }
        const double C1 = 4.16666666666666019037e-02, C2 = -1.38888888888741095749e-03, C3 = 2.48015872894767294178e-05,
            C4 = -2.75573143513906633035e-07, C5 = 2.08757232129817482790e-09, C6 = -1.13596475577881948265e-11;
        static double KernelCos(double x, double y)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix < 0x3e400000) { if ((int)x == 0) return 1.0; }
            double z = x * x, r = z * (C1 + z * (C2 + z * (C3 + z * (C4 + z * (C5 + z * C6)))));
            if (ix < 0x3FD33333) return 1.0 - (0.5 * z - (z * r - x * y));
            double qx = ix > 0x3fe90000 ? 0.28125 : Make(ix - 0x00200000, 0);
            double iz = 0.5 * z - qx, a = 1.0 - qx;
            return a - (iz - (z * r - x * y));
        }

        const double InvPio2 = 6.36619772367581382433e-01, Pio2_1 = 1.57079632673412561417e+00, Pio2_1t = 6.07710050650619224932e-11,
            Pio2_2 = 6.07710050630396597660e-11, Pio2_2t = 2.02226624879595063154e-21, Pio2_3 = 2.02226624871116645580e-21, Pio2_3t = 8.47842766036889956997e-32;
        static readonly int[] Npio2Hw = MakeNpio2();
        static int[] MakeNpio2() { var t = new int[32]; for (int n = 1; n <= 32; n++) t[n - 1] = Hi(n * (Math.PI / 2)); return t; }

        // __ieee754_rem_pio2 for |x| up to 2^19 pi/2 (beyond: -1, the caller uses the platform's)
        static int RemPio2(double x, out double y0, out double y1)
        {
            int hx = Hi(x), ix = hx & 0x7fffffff;
            if (ix <= 0x3fe921fb) { y0 = x; y1 = 0; return 0; }
            if (ix < 0x4002d97c)
            {
                double z;
                if (hx > 0)
                {
                    z = x - Pio2_1;
                    if (ix != 0x3ff921fb) { y0 = z - Pio2_1t; y1 = (z - y0) - Pio2_1t; }
                    else { z -= Pio2_2; y0 = z - Pio2_2t; y1 = (z - y0) - Pio2_2t; }
                    return 1;
                }
                z = x + Pio2_1;
                if (ix != 0x3ff921fb) { y0 = z + Pio2_1t; y1 = (z - y0) + Pio2_1t; }
                else { z += Pio2_2; y0 = z + Pio2_2t; y1 = (z - y0) + Pio2_2t; }
                return -1;
            }
            if (ix <= 0x413921fb)
            {
                double t = Math.Abs(x);
                int n = (int)(t * InvPio2 + 0.5);
                double fn = n, r = t - fn * Pio2_1, w = fn * Pio2_1t;
                if (n < 32 && ix != Npio2Hw[n - 1]) y0 = r - w;
                else
                {
                    int j = ix >> 20;
                    y0 = r - w;
                    int i = j - ((Hi(y0) >> 20) & 0x7ff);
                    if (i > 16)
                    {
                        t = r; w = fn * Pio2_2; r = t - w; w = fn * Pio2_2t - ((t - r) - w); y0 = r - w;
                        i = j - ((Hi(y0) >> 20) & 0x7ff);
                        if (i > 49) { t = r; w = fn * Pio2_3; r = t - w; w = fn * Pio2_3t - ((t - r) - w); y0 = r - w; }
                    }
                }
                y1 = (r - y0) - w;
                if (hx < 0) { y0 = -y0; y1 = -y1; return -n; }
                return n;
            }
            y0 = y1 = 0;
            return int.MinValue;
        }

        public static double Sin(double x)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix <= 0x3fe921fb) return KernelSin(x, 0, 0);
            if (ix >= 0x7ff00000) return double.NaN;
            int n = RemPio2(x, out double y0, out double y1);
            if (n == int.MinValue) return Math.Sin(x);
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
            if (ix <= 0x3fe921fb) return KernelCos(x, 0);
            if (ix >= 0x7ff00000) return double.NaN;
            int n = RemPio2(x, out double y0, out double y1);
            if (n == int.MinValue) return Math.Cos(x);
            switch (n & 3)
            {
                case 0: return KernelCos(y0, y1);
                case 1: return -KernelSin(y0, y1, 1);
                case 2: return -KernelCos(y0, y1);
                default: return KernelSin(y0, y1, 1);
            }
        }

        static double SetLo(double x, uint lo) => Make(Hi(x), lo);
        static double SetHi(double x, int hi) => Make(hi, Lo(x));

        // ---- tan (k_tan.c)
        static readonly double[] T = { 3.33333333333334091986e-01, 1.33333333333201242699e-01, 5.39682539762260521377e-02, 2.18694882948595424599e-02,
            8.86323982359930005737e-03, 3.59207910759131235356e-03, 1.45620945432529025516e-03, 5.88041240820264096874e-04, 2.46463134818469906812e-04,
            7.81794442939557092300e-05, 7.14072491382608190305e-05, -1.85586374855275456654e-05, 2.59073051863633712884e-05 };
        const double Pio4 = 7.85398163397448278999e-01, Pio4lo = 3.06161699786838301793e-17;
        static double KernelTan(double x, double y, int iy)
        {
            double z, r, v, w, s;
            int hx = Hi(x), ix = hx & 0x7fffffff;
            if (ix < 0x3e300000)
            {
                if ((int)x == 0)
                {
                    if (((ix | (int)Lo(x)) | (iy + 1)) == 0) return 1.0 / Math.Abs(x);
                    if (iy == 1) return x;
                    double a, t;
                    z = w = x + y; z = SetLo(z, 0); v = y - (z - x);
                    t = a = -1.0 / w; t = SetLo(t, 0); s = 1.0 + t * z;
                    return t + a * (s + t * v);
                }
            }
            if (ix >= 0x3FE59428)
            {
                if (hx < 0) { x = -x; y = -y; }
                z = Pio4 - x; w = Pio4lo - y; x = z + w; y = 0.0;
            }
            z = x * x; w = z * z;
            r = T[1] + w * (T[3] + w * (T[5] + w * (T[7] + w * (T[9] + w * T[11]))));
            v = z * (T[2] + w * (T[4] + w * (T[6] + w * (T[8] + w * (T[10] + w * T[12])))));
            s = z * x;
            r = y + z * (s * (r + v) + y);
            r += T[0] * s;
            w = x + r;
            if (ix >= 0x3FE59428)
            {
                v = iy;
                return (1 - ((hx >> 30) & 2)) * (v - 2.0 * (x - (w * w / (w + v) - r)));
            }
            if (iy == 1) return w;
            {
                double a, t;
                z = w; z = SetLo(z, 0); v = r - (z - x);
                t = a = -1.0 / w; t = SetLo(t, 0); s = 1.0 + t * z;
                return t + a * (s + t * v);
            }
        }
        public static double Tan(double x)
        {
            int ix = Hi(x) & 0x7fffffff;
            if (ix <= 0x3fe921fb) return KernelTan(x, 0, 1);
            if (ix >= 0x7ff00000) return double.NaN;
            int n = RemPio2(x, out double y0, out double y1);
            if (n == int.MinValue) return Math.Tan(x);
            return KernelTan(y0, y1, 1 - ((n & 1) << 1));
        }

        // ---- atan, atan2 (s_atan.c, e_atan2.c)
        static readonly double[] AtanHi = { 4.63647609000806093515e-01, 7.85398163397448278999e-01, 9.82793723247329054082e-01, 1.57079632679489655800e+00 };
        static readonly double[] AtanLo = { 2.26987774529616870924e-17, 3.06161699786838301793e-17, 1.39033110312309984516e-17, 6.12323399573676603587e-17 };
        static readonly double[] AT = { 3.33333333333329318027e-01, -1.99999999998764832476e-01, 1.42857142725034663711e-01, -1.11111104054623557880e-01,
            9.09088713343650656196e-02, -7.69187620504482999495e-02, 6.66107313738753120669e-02, -5.83357013379057348645e-02, 4.97687799461593236017e-02,
            -3.65315727442169155270e-02, 1.62858201153657823623e-02 };
        public static double Atan(double x)
        {
            int hx = Hi(x), ix = hx & 0x7fffffff, id;
            if (ix >= 0x44100000)
            {
                if (ix > 0x7ff00000 || (ix == 0x7ff00000 && Lo(x) != 0)) return x + x;
                return hx > 0 ? AtanHi[3] + AtanLo[3] : -AtanHi[3] - AtanLo[3];
            }
            if (ix < 0x3fdc0000)
            {
                if (ix < 0x3e400000) return x;
                id = -1;
            }
            else
            {
                x = Math.Abs(x);
                if (ix < 0x3ff30000)
                {
                    if (ix < 0x3fe60000) { id = 0; x = (2.0 * x - 1.0) / (2.0 + x); }
                    else { id = 1; x = (x - 1.0) / (x + 1.0); }
                }
                else
                {
                    if (ix < 0x40038000) { id = 2; x = (x - 1.5) / (1.0 + 1.5 * x); }
                    else { id = 3; x = -1.0 / x; }
                }
            }
            double z = x * x, w = z * z;
            double s1 = z * (AT[0] + w * (AT[2] + w * (AT[4] + w * (AT[6] + w * (AT[8] + w * AT[10])))));
            double s2 = w * (AT[1] + w * (AT[3] + w * (AT[5] + w * (AT[7] + w * AT[9]))));
            if (id < 0) return x - x * (s1 + s2);
            z = AtanHi[id] - ((x * (s1 + s2) - AtanLo[id]) - x);
            return hx < 0 ? -z : z;
        }
        const double Tiny = 1.0e-300, PiO4 = 7.8539816339744827900E-01, PiO2 = 1.5707963267948965580E+00, Pi = 3.1415926535897931160E+00, PiLo = 1.2246467991473531772E-16;
        public static double Atan2(double y, double x)
        {
            int hx = Hi(x), ix = hx & 0x7fffffff, hy = Hi(y), iy = hy & 0x7fffffff;
            uint lx = Lo(x), ly = Lo(y);
            if (double.IsNaN(x) || double.IsNaN(y)) return x + y;
            if (((hx - 0x3ff00000) | (int)lx) == 0) return Atan(y);
            int m = ((hy >> 31) & 1) | ((hx >> 30) & 2);
            if ((iy | (int)ly) == 0)
            {
                switch (m) { case 0: case 1: return y; case 2: return Pi + Tiny; default: return -Pi - Tiny; }
            }
            if ((ix | (int)lx) == 0) return hy < 0 ? -PiO2 - Tiny : PiO2 + Tiny;
            if (ix == 0x7ff00000)
            {
                if (iy == 0x7ff00000)
                {
                    switch (m) { case 0: return PiO4 + Tiny; case 1: return -PiO4 - Tiny; case 2: return 3.0 * PiO4 + Tiny; default: return -3.0 * PiO4 - Tiny; }
                }
                switch (m) { case 0: return 0.0; case 1: return -0.0; case 2: return Pi + Tiny; default: return -Pi - Tiny; }
            }
            if (iy == 0x7ff00000) return hy < 0 ? -PiO2 - Tiny : PiO2 + Tiny;
            int k = (iy - ix) >> 20;
            double z;
            if (k > 60) { z = PiO2 + 0.5 * PiLo; m &= 1; }
            else if (hx < 0 && k < -60) z = 0.0;
            else z = Atan(Math.Abs(y / x));
            switch (m)
            {
                case 0: return z;
                case 1: return -z;
                case 2: return Pi - (z - PiLo);
                default: return (z - PiLo) - Pi;
            }
        }

        // ---- asin, acos (e_asin.c, e_acos.c)
        const double Pio2Hi = 1.57079632679489655800e+00, Pio2Lo = 6.12323399573676603587e-17, Pio4Hi = 7.85398163397448278999e-01,
            PS0 = 1.66666666666666657415e-01, PS1 = -3.25565818622400915405e-01, PS2 = 2.01212532134862925881e-01, PS3 = -4.00555345006794114027e-02,
            PS4 = 7.91534994289814532176e-04, PS5 = 3.47933107596021167570e-05, QS1 = -2.40339491173441421878e+00, QS2 = 2.02094576023350569471e+00,
            QS3 = -6.88283971605453293030e-01, QS4 = 7.70381505559019352791e-02;
        public static double Asin(double x)
        {
            double t = 0, w, p, q, c, r, s;
            int hx = Hi(x), ix = hx & 0x7fffffff;
            if (ix >= 0x3ff00000)
            {
                if (((ix - 0x3ff00000) | (int)Lo(x)) == 0) return x * Pio2Hi + x * Pio2Lo;
                return double.NaN;
            }
            if (ix < 0x3fe00000)
            {
                if (ix < 0x3e400000) return x;
                t = x * x;
                p = t * (PS0 + t * (PS1 + t * (PS2 + t * (PS3 + t * (PS4 + t * PS5)))));
                q = 1.0 + t * (QS1 + t * (QS2 + t * (QS3 + t * QS4)));
                w = p / q;
                return x + x * w;
            }
            w = 1.0 - Math.Abs(x);
            t = w * 0.5;
            p = t * (PS0 + t * (PS1 + t * (PS2 + t * (PS3 + t * (PS4 + t * PS5)))));
            q = 1.0 + t * (QS1 + t * (QS2 + t * (QS3 + t * QS4)));
            s = Math.Sqrt(t);
            if (ix >= 0x3FEF3333) { w = p / q; t = Pio2Hi - (2.0 * (s + s * w) - Pio2Lo); }
            else
            {
                w = SetLo(s, 0);
                c = (t - w * w) / (s + w);
                r = p / q;
                p = 2.0 * s * r - (Pio2Lo - 2.0 * c);
                q = Pio4Hi - 2.0 * w;
                t = Pio4Hi - (p - q);
            }
            return hx > 0 ? t : -t;
        }
        public static double Acos(double x)
        {
            double z, p, q, r, w, s, c, df;
            int hx = Hi(x), ix = hx & 0x7fffffff;
            if (ix >= 0x3ff00000)
            {
                if (((ix - 0x3ff00000) | (int)Lo(x)) == 0) return hx > 0 ? 0.0 : Pi + 2.0 * Pio2Lo;
                return double.NaN;
            }
            if (ix < 0x3fe00000)
            {
                if (ix <= 0x3c600000) return Pio2Hi + Pio2Lo;
                z = x * x;
                p = z * (PS0 + z * (PS1 + z * (PS2 + z * (PS3 + z * (PS4 + z * PS5)))));
                q = 1.0 + z * (QS1 + z * (QS2 + z * (QS3 + z * QS4)));
                r = p / q;
                return Pio2Hi - (x - (Pio2Lo - x * r));
            }
            if (hx < 0)
            {
                z = (1.0 + x) * 0.5;
                p = z * (PS0 + z * (PS1 + z * (PS2 + z * (PS3 + z * (PS4 + z * PS5)))));
                q = 1.0 + z * (QS1 + z * (QS2 + z * (QS3 + z * QS4)));
                s = Math.Sqrt(z);
                r = p / q;
                w = r * s - Pio2Lo;
                return Pi - 2.0 * (s + w);
            }
            z = (1.0 - x) * 0.5;
            s = Math.Sqrt(z);
            df = SetLo(s, 0);
            c = (z - df * df) / (s + df);
            p = z * (PS0 + z * (PS1 + z * (PS2 + z * (PS3 + z * (PS4 + z * PS5)))));
            q = 1.0 + z * (QS1 + z * (QS2 + z * (QS3 + z * QS4)));
            r = p / q;
            w = r * s + c;
            return 2.0 * (df + w);
        }

        // ---- exp (e_exp.c)
        const double OThreshold = 7.09782712893383973096e+02, UThreshold = -7.45133219101941108420e+02, Ln2Hi0 = 6.93147180369123816490e-01, Ln2Lo0 = 1.90821492927058770002e-10,
            InvLn2 = 1.44269504088896338700e+00, P1 = 1.66666666666666019037e-01, P2 = -2.77777777770155933842e-03, P3 = 6.61375632143793436117e-05,
            P4 = -1.65339022054652515390e-06, P5 = 4.13813679705723846039e-08, Twom1000 = 9.33263618503218878990e-302;
        public static double Exp(double x)
        {
            double y, hi = 0, lo = 0, c, t;
            int k = 0, xsb, hx = Hi(x);
            xsb = (hx >> 31) & 1;
            hx &= 0x7fffffff;
            if (hx >= 0x40862E42)
            {
                if (hx >= 0x7ff00000)
                {
                    if (((hx & 0xfffff) | (int)Lo(x)) != 0) return x + x;
                    return xsb == 0 ? x : 0.0;
                }
                if (x > OThreshold) return double.PositiveInfinity;
                if (x < UThreshold) return 0.0;
            }
            if (hx > 0x3fd62e42)
            {
                if (hx < 0x3FF0A2B2) { hi = x - (xsb == 0 ? Ln2Hi0 : -Ln2Hi0); lo = xsb == 0 ? Ln2Lo0 : -Ln2Lo0; k = 1 - xsb - xsb; }
                else
                {
                    k = (int)(InvLn2 * x + (xsb == 0 ? 0.5 : -0.5));
                    t = k;
                    hi = x - t * Ln2Hi0;
                    lo = t * Ln2Lo0;
                }
                x = hi - lo;
            }
            else if (hx < 0x3e300000) return 1.0 + x;
            else k = 0;
            t = x * x;
            c = x - t * (P1 + t * (P2 + t * (P3 + t * (P4 + t * P5))));
            if (k == 0) return 1.0 - ((x * c) / (c - 2.0) - x);
            y = 1.0 - ((lo - (x * c) / (2.0 - c)) - hi);
            if (k >= -1021)
            {
                if (k == 1024) return y * 2.0 * 8.98846567431157953865e+307;
                return y * Make(0x3ff00000 + (k << 20), 0);
            }
            return y * Make(0x3ff00000 + ((k + 1000) << 20), 0) * Twom1000;
        }

        // ---- log (e_log.c)
        const double Lg1 = 6.666666666666735130e-01, Lg2 = 3.999999999940941908e-01, Lg3 = 2.857142874366239149e-01, Lg4 = 2.222219843214978396e-01,
            Lg5 = 1.818357216161805012e-01, Lg6 = 1.531383769920937332e-01, Lg7 = 1.479819860511658591e-01, Two54 = 1.80143985094819840000e+16;
        public static double Log(double x)
        {
            double hfsq, f, s, z, R, w, t1, t2, dk;
            int k = 0, hx = Hi(x), i, j;
            uint lx = Lo(x);
            if (hx < 0x00100000)
            {
                if (((hx & 0x7fffffff) | (int)lx) == 0) return double.NegativeInfinity;
                if (hx < 0) return double.NaN;
                k -= 54; x *= Two54; hx = Hi(x);
            }
            if (hx >= 0x7ff00000) return x + x;
            k += (hx >> 20) - 1023;
            hx &= 0x000fffff;
            i = (hx + 0x95f64) & 0x100000;
            x = SetHi(x, hx | (i ^ 0x3ff00000));
            k += i >> 20;
            f = x - 1.0;
            if ((0x000fffff & (2 + hx)) < 3)
            {
                if (f == 0) { if (k == 0) return 0; dk = k; return dk * Ln2Hi0 + dk * Ln2Lo0; }
                R = f * f * (0.5 - 0.33333333333333333 * f);
                if (k == 0) return f - R;
                dk = k; return dk * Ln2Hi0 - ((R - dk * Ln2Lo0) - f);
            }
            s = f / (2.0 + f);
            dk = k;
            z = s * s;
            i = hx - 0x6147a;
            w = z * z;
            j = 0x6b851 - hx;
            t1 = w * (Lg2 + w * (Lg4 + w * Lg6));
            t2 = z * (Lg1 + w * (Lg3 + w * (Lg5 + w * Lg7)));
            i |= j;
            R = t2 + t1;
            if (i > 0)
            {
                hfsq = 0.5 * f * f;
                if (k == 0) return f - (hfsq - s * (hfsq + R));
                return dk * Ln2Hi0 - ((hfsq - (s * (hfsq + R) + dk * Ln2Lo0)) - f);
            }
            if (k == 0) return f - s * (f - R);
            return dk * Ln2Hi0 - ((s * (f - R) - dk * Ln2Lo0) - f);
        }
        public static double Log2(double x) => Math.Log(x) / 0.6931471805599453;
        public static double Log10(double x) => Math.Log10(x);
        public static double Log1p(double x) => Math.Abs(x) < 1e-5 ? x - x * x / 2 + x * x * x / 3 : Math.Log(1 + x);
        public static double Expm1(double x) => Math.Abs(x) < 1e-5 ? x + x * x / 2 + x * x * x / 6 : Math.Exp(x) - 1;
        public static double Cbrt(double x) => Math.Cbrt(x);
        public static double Sinh(double x) => Math.Sinh(x);
        public static double Cosh(double x) => Math.Cosh(x);
        public static double Tanh(double x) => Math.Tanh(x);
        // ---- pow (e_pow.c)
        static readonly double[] Bp = { 1.0, 1.5 }, DpH = { 0.0, 5.84962487220764160156e-01 }, DpL = { 0.0, 1.35003920212974897128e-08 };
        const double Two53 = 9007199254740992.0, Huge = 1.0e300,
            L1 = 5.99999999999994648725e-01, L2 = 4.28571428578550184252e-01, L3 = 3.33333329818377432918e-01, L4 = 2.72728123808534006489e-01,
            L5 = 2.30660745775561754067e-01, L6 = 2.06975017800338417784e-01, Lg2_ = 6.93147180559945286227e-01, Lg2H = 6.93147182464599609375e-01,
            Lg2L = -1.90465429995776804525e-09, Ovt = 8.0085662595372944372e-17, Cp = 9.61796693925975554329e-01, CpH = 9.61796700954437255859e-01,
            CpL = -7.02846165095275826516e-09, IvLn2 = 1.44269504088896338700e+00, IvLn2H = 1.44269502162933349609e+00, IvLn2L = 1.92596299112661746887e-08;
        public static double Pow(double x, double y)
        {
            double z, ax, z_h, z_l, p_h, p_l, y1, t1, t2, r, s, t, u, v, w;
            int i, j, k, yisint, n, hx = Hi(x), hy = Hi(y), ix, iy;
            uint lx = Lo(x), ly = Lo(y);
            ix = hx & 0x7fffffff; iy = hy & 0x7fffffff;
            if ((iy | (int)ly) == 0) return 1.0;
            if (ix > 0x7ff00000 || (ix == 0x7ff00000 && lx != 0) || iy > 0x7ff00000 || (iy == 0x7ff00000 && ly != 0)) return x + y;
            yisint = 0;
            if (hx < 0)
            {
                if (iy >= 0x43400000) yisint = 2;
                else if (iy >= 0x3ff00000)
                {
                    k = (iy >> 20) - 0x3ff;
                    if (k > 20) { uint jj = ly >> (52 - k); if ((jj << (52 - k)) == ly) yisint = 2 - (int)(jj & 1); }
                    else if (ly == 0) { j = iy >> (20 - k); if ((j << (20 - k)) == iy) yisint = 2 - (j & 1); }
                }
            }
            if (ly == 0)
            {
                if (iy == 0x7ff00000)
                {
                    if (((ix - 0x3ff00000) | (int)lx) == 0) return y - y;
                    if (ix >= 0x3ff00000) return hy >= 0 ? y : 0.0;
                    return hy < 0 ? -y : 0.0;
                }
                if (iy == 0x3ff00000) return hy < 0 ? 1.0 / x : x;
                if (hy == 0x40000000) return x * x;
                if (hy == 0x3fe00000 && hx >= 0) return Math.Sqrt(x);
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
                    if (ix <= 0x3fefffff) return hy < 0 ? Huge * Huge : Tiny * Tiny;
                    if (ix >= 0x3ff00000) return hy > 0 ? Huge * Huge : Tiny * Tiny;
                }
                if (ix < 0x3fefffff) return hy < 0 ? s * Huge * Huge : s * Tiny * Tiny;
                if (ix > 0x3ff00000) return hy > 0 ? s * Huge * Huge : s * Tiny * Tiny;
                t = ax - 1.0;
                w = (t * t) * (0.5 - t * (0.3333333333333333333333 - t * 0.25));
                u = IvLn2H * t;
                v = t * IvLn2L - w * IvLn2;
                t1 = SetLo(u + v, 0);
                t2 = v - (t1 - u);
            }
            else
            {
                double ss, s2, s_h, s_l, t_h, t_l;
                n = 0;
                if (ix < 0x00100000) { ax *= Two53; n -= 53; ix = Hi(ax); }
                n += (ix >> 20) - 0x3ff;
                j = ix & 0x000fffff;
                ix = j | 0x3ff00000;
                if (j <= 0x3988E) k = 0;
                else if (j < 0xBB67A) k = 1;
                else { k = 0; n += 1; ix -= 0x00100000; }
                ax = SetHi(ax, ix);
                u = ax - Bp[k];
                v = 1.0 / (ax + Bp[k]);
                ss = u * v;
                s_h = SetLo(ss, 0);
                t_h = Make(((ix >> 1) | 0x20000000) + 0x00080000 + (k << 18), 0);
                t_l = ax - (t_h - Bp[k]);
                s_l = v * ((u - s_h * t_h) - s_h * t_l);
                s2 = ss * ss;
                r = s2 * s2 * (L1 + s2 * (L2 + s2 * (L3 + s2 * (L4 + s2 * (L5 + s2 * L6)))));
                r += s_l * (s_h + ss);
                s2 = s_h * s_h;
                t_h = SetLo(3.0 + s2 + r, 0);
                t_l = r - ((t_h - 3.0) - s2);
                u = s_h * t_h;
                v = s_l * t_h + t_l * ss;
                p_h = SetLo(u + v, 0);
                p_l = v - (p_h - u);
                z_h = CpH * p_h;
                z_l = CpL * p_h + p_l * Cp + DpL[k];
                t = n;
                t1 = SetLo(((z_h + z_l) + DpH[k]) + t, 0);
                t2 = z_l - (((t1 - t) - DpH[k]) - z_h);
            }
            y1 = SetLo(y, 0);
            p_l = (y - y1) * t1 + y * t2;
            p_h = y1 * t1;
            z = p_l + p_h;
            j = Hi(z);
            i = (int)Lo(z);
            if (j >= 0x40900000)
            {
                if (((j - 0x40900000) | i) != 0) return s * Huge * Huge;
                if (p_l + Ovt > z - p_h) return s * Huge * Huge;
            }
            else if ((j & 0x7fffffff) >= 0x4090cc00)
            {
                if (((j - unchecked((int)0xc090cc00)) | i) != 0) return s * Tiny * Tiny;
                if (p_l <= z - p_h) return s * Tiny * Tiny;
            }
            i = j & 0x7fffffff;
            k = (i >> 20) - 0x3ff;
            n = 0;
            if (i > 0x3fe00000)
            {
                n = j + (0x00100000 >> (k + 1));
                k = ((n & 0x7fffffff) >> 20) - 0x3ff;
                t = Make(n & ~(0x000fffff >> k), 0);
                n = ((n & 0x000fffff) | 0x00100000) >> (20 - k);
                if (j < 0) n = -n;
                p_h -= t;
            }
            t = SetLo(p_l + p_h, 0);
            u = t * Lg2H;
            v = (p_l - (t - p_h)) * Lg2_ + t * Lg2L;
            z = u + v;
            w = v - (z - u);
            t = z * z;
            t1 = z - t * (P1 + t * (P2 + t * (P3 + t * (P4 + t * P5))));
            r = (z * t1) / (t1 - 2.0) - (w + z * w);
            z = 1.0 - (r - z);
            j = Hi(z);
            j += n << 20;
            if ((j >> 20) <= 0) z = Scalbn(z, n);
            else z = SetHi(z, Hi(z) + (n << 20));
            return s * z;
        }
        static double Scalbn(double x, int n)
        {
            // (only for a subnormal result: exact multiplications by powers of two)
            while (n > 1023) { x *= 8.98846567431157953865e+307; n -= 1023; }
            while (n < -1022) { x *= 2.2250738585072014e-308; n += 1022; }
            return x * Make((n + 1023) << 20, 0);
        }
    }
}
