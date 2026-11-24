// Numbers to text and back, as JS does it (the rig writes every coordinate into its SVG through these, so they must be
// the same characters as V8's): Number::toString (the shortest digits that read back the same, fixed between 1e-6 and
// 1e21), toFixed (exact, half up), toString(radix) (V8's DoubleToRadixCString), the string-to-number grammar, parseFloat.
using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace SquishSquad.Creatures.Js
{
    public static class JsNumber
    {
        static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        static readonly double[] Pow10 = { 1, 10, 100, 1000, 10000, 100000, 1000000 };

        public static string ToString(double d)
        {
            if (d == 0) return "0";
            if (double.IsNaN(d)) return "NaN";
            if (double.IsInfinity(d)) return d > 0 ? "Infinity" : "-Infinity";
            bool neg = d < 0;
            double a = neg ? -d : d;
            if (a < 9007199254740992.0 && a == Math.Floor(a))
            {
                long l = (long)a;
                return (neg ? "-" : "") + l.ToString(Inv);
            }
            // a few decimals (what the rig's r2 / toFixed leave): the k-place decimal that is exactly this double
            if (a < 1e7 && a >= 1e-6)
            {
                for (int k = 1; k <= 6; k++)
                {
                    double r = Math.Round(a * Pow10[k]);
                    if (r / Pow10[k] == a)
                    {
                        long q = (long)r;
                        string digits = q.ToString(Inv);
                        var sb = new StringBuilder(digits.Length + 3);
                        if (neg) sb.Append('-');
                        if (digits.Length <= k) { sb.Append("0."); sb.Append('0', k - digits.Length); sb.Append(digits); }
                        else { sb.Append(digits, 0, digits.Length - k); sb.Append('.'); sb.Append(digits, digits.Length - k, k); }
                        return sb.ToString();
                    }
                }
            }
            Shortest(a, out string ds, out int n);
            return (neg ? "-" : "") + Format(ds, n);
        }

        /// <summary>The shortest decimal digits that read back as `a` (> 0) and the decimal point's place n
        /// (a = 0.ds × 10^n).</summary>
        public static void Shortest(double a, out string digits, out int n)
        {
            string s = null;
            for (int p = 1; p <= 17; p++)
            {
                s = a.ToString("E" + (p - 1), Inv);
                if (p == 17 || double.Parse(s, NumberStyles.Float, Inv) == a) break;
            }
            int e = s.IndexOf('E');
            string mant = s.Substring(0, e).Replace(".", "");
            int exp = int.Parse(s.Substring(e + 1), NumberStyles.AllowLeadingSign, Inv);
            mant = mant.TrimEnd('0');
            if (mant.Length == 0) mant = "0";
            digits = mant; n = exp + 1;
        }

        static string Format(string ds, int n)
        {
            int k = ds.Length;
            if (k <= n && n <= 21) return ds + new string('0', n - k);
            if (0 < n && n <= 21) return ds.Substring(0, n) + "." + ds.Substring(n);
            if (-6 < n && n <= 0) return "0." + new string('0', -n) + ds;
            int e = n - 1;
            string es = (e >= 0 ? "+" : "-") + Math.Abs(e).ToString(Inv);
            return k == 1 ? ds + "e" + es : ds.Substring(0, 1) + "." + ds.Substring(1) + "e" + es;
        }

        /// <summary>Number.prototype.toFixed(f): the integer n for which n / 10^f - x is closest to zero (the larger on
        /// a tie), from the double's exact value.</summary>
        public static string ToFixed(double x, int f)
        {
            if (double.IsNaN(x)) return "NaN";
            if (Math.Abs(x) >= 1e21 || double.IsInfinity(x)) return ToString(x);
            string sign = "";
            if (x < 0) { sign = "-"; x = -x; }
            long bits = BitConverter.DoubleToInt64Bits(x);
            int bexp = (int)((bits >> 52) & 0x7ff);
            long mant = bits & 0xfffffffffffffL;
            if (bexp == 0) bexp++; else mant |= 1L << 52;
            int e2 = bexp - 1075;   // x = mant * 2^e2
            BigInteger num = new BigInteger(mant) * BigInteger.Pow(10, f), q;
            if (e2 >= 0) q = num << e2;
            else
            {
                BigInteger den = BigInteger.One << -e2;
                q = BigInteger.DivRem(num, den, out var rem);
                if (rem * 2 >= den) q += 1;
            }
            string s = q.ToString(Inv);
            if (f == 0) return sign + s;
            if (s.Length <= f) s = new string('0', f - s.Length + 1) + s;
            return sign + s.Substring(0, s.Length - f) + "." + s.Substring(s.Length - f);
        }

        /// <summary>Number.prototype.toString(radix), as V8's DoubleToRadixCString.</summary>
        public static string ToRadix(double value, int radix)
        {
            if (radix == 10) return ToString(value);
            if (double.IsNaN(value)) return "NaN";
            if (double.IsInfinity(value)) return value > 0 ? "Infinity" : "-Infinity";
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            var frac = new StringBuilder();
            bool negative = value < 0;
            if (negative) value = -value;
            double integer = Math.Floor(value), fraction = value - integer;
            double delta = 0.5 * (NextUp(value) - value);
            delta = Math.Max(NextUp(0.0), delta);
            if (fraction >= delta)
            {
                frac.Append('.');
                do
                {
                    fraction *= radix; delta *= radix;
                    int digit = (int)fraction;
                    frac.Append(chars[digit]);
                    fraction -= digit;
                    if (fraction > 0.5 || (fraction == 0.5 && (digit & 1) != 0))
                    {
                        if (fraction + delta > 1)
                        {
                            for (;;)
                            {
                                int cur = frac.Length - 1;
                                if (cur == 0) { integer += 1; frac.Length = 0; break; }
                                char c = frac[cur];
                                int dg = c > '9' ? (c - 'a' + 10) : (c - '0');
                                frac.Length = cur;
                                if (dg + 1 < radix) { frac.Append(chars[dg + 1]); break; }
                            }
                            break;
                        }
                    }
                } while (fraction >= delta);
                if (frac.Length == 1) frac.Length = 0;
            }
            var ip = new StringBuilder();
            while (Exponent(integer / radix) > 0) { integer /= radix; ip.Insert(0, '0'); }
            do
            {
                double rem = integer % radix;
                ip.Insert(0, chars[(int)rem]);
                integer = (integer - rem) / radix;
            } while (integer > 0);
            if (negative) ip.Insert(0, '-');
            return ip.ToString() + frac.ToString();
        }
        static double NextUp(double v)
        {
            if (double.IsNaN(v) || v == double.PositiveInfinity) return v;
            if (v == 0) return double.Epsilon;
            long b = BitConverter.DoubleToInt64Bits(v);
            b += v > 0 ? 1 : -1;
            return BitConverter.Int64BitsToDouble(b);
        }
        // V8's Double::Exponent(): the exponent with the significand as a 53-bit integer
        static int Exponent(double d)
        {
            long bits = BitConverter.DoubleToInt64Bits(d);
            int be = (int)((bits >> 52) & 0x7ff);
            if (be == 0) return -1074;
            return be - 1075;
        }

        public static string ToPrecision(double x, int p)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return ToString(x);
            if (x == 0) return p == 1 ? "0" : "0." + new string('0', p - 1);
            string sign = x < 0 ? "-" : ""; if (x < 0) x = -x;
            string s = x.ToString("E" + (p - 1), Inv);
            int e = s.IndexOf('E');
            string m = s.Substring(0, e).Replace(".", "");
            int ex = int.Parse(s.Substring(e + 1), NumberStyles.AllowLeadingSign, Inv);
            if (ex < -6 || ex >= p) return sign + m.Substring(0, 1) + (p > 1 ? "." + m.Substring(1) : "") + "e" + (ex >= 0 ? "+" : "-") + Math.Abs(ex);
            if (ex == p - 1) return sign + m;
            if (ex >= 0) return sign + m.Substring(0, ex + 1) + "." + m.Substring(ex + 1);
            return sign + "0." + new string('0', -(ex + 1)) + m;
        }

        // ------------------------------------------------------------------ text to number
        static bool IsWs(char c) => c == ' ' || c == '\t' || c == '\n' || c == '\r' || c == '\v' || c == '\f' || c == '\u00a0' || c == '\ufeff' || c == '\u2028' || c == '\u2029' || (c > 127 && char.IsWhiteSpace(c));
        static string Trim(string s)
        {
            int a = 0, b = s.Length;
            while (a < b && IsWs(s[a])) a++;
            while (b > a && IsWs(s[b - 1])) b--;
            return a == 0 && b == s.Length ? s : s.Substring(a, b - a);
        }
        public static double StringToNumber(string s)
        {
            s = Trim(s);
            if (s.Length == 0) return 0;
            if (s.Length > 2 && s[0] == '0')
            {
                char p = s[1];
                int radix = p == 'x' || p == 'X' ? 16 : p == 'o' || p == 'O' ? 8 : p == 'b' || p == 'B' ? 2 : 0;
                if (radix != 0)
                {
                    double v = 0;
                    for (int i = 2; i < s.Length; i++) { int d = DigitOf(s[i]); if (d < 0 || d >= radix) return double.NaN; v = v * radix + d; }
                    return v;
                }
            }
            if (s == "Infinity" || s == "+Infinity") return double.PositiveInfinity;
            if (s == "-Infinity") return double.NegativeInfinity;
            int end = DecimalPrefix(s, 0);
            if (end != s.Length || end == 0) return double.NaN;
            return ParseDec(s);
        }
        static int DigitOf(char c) => c >= '0' && c <= '9' ? c - '0' : c >= 'a' && c <= 'z' ? c - 'a' + 10 : c >= 'A' && c <= 'Z' ? c - 'A' + 10 : -1;
        // the length of a StrDecimalLiteral (no Infinity) at s[i..]: sign, digits, '.', digits, exponent; 0 if none
        static int DecimalPrefix(string s, int i)
        {
            int start = i, n = s.Length;
            if (i < n && (s[i] == '+' || s[i] == '-')) i++;
            int d0 = i;
            while (i < n && s[i] >= '0' && s[i] <= '9') i++;
            int intDigits = i - d0, fracDigits = 0;
            if (i < n && s[i] == '.') { int f0 = ++i; while (i < n && s[i] >= '0' && s[i] <= '9') i++; fracDigits = i - f0; if (intDigits == 0 && fracDigits == 0) return 0; }
            else if (intDigits == 0) return 0;
            if (i < n && (s[i] == 'e' || s[i] == 'E'))
            {
                int j = i + 1;
                if (j < n && (s[j] == '+' || s[j] == '-')) j++;
                int e0 = j;
                while (j < n && s[j] >= '0' && s[j] <= '9') j++;
                if (j > e0) i = j;
            }
            return i - start;
        }
        static double ParseDec(string s)
        {
            try { return double.Parse(s, NumberStyles.Float, Inv); }
            catch (OverflowException) { return s.TrimStart()[0] == '-' ? double.NegativeInfinity : double.PositiveInfinity; }
        }
        public static double ParseFloat(string s)
        {
            int a = 0;
            while (a < s.Length && IsWs(s[a])) a++;
            if (string.CompareOrdinal(s, a, "Infinity", 0, 8) == 0 || string.CompareOrdinal(s, a, "+Infinity", 0, 9) == 0) return double.PositiveInfinity;
            if (string.CompareOrdinal(s, a, "-Infinity", 0, 9) == 0) return double.NegativeInfinity;
            int len = DecimalPrefix(s, a);
            if (len == 0) return double.NaN;
            return ParseDec(s.Substring(a, len));
        }
        public static double ParseInt(string s, int radix)
        {
            int i = 0;
            while (i < s.Length && IsWs(s[i])) i++;
            bool neg = false;
            if (i < s.Length && (s[i] == '+' || s[i] == '-')) { neg = s[i] == '-'; i++; }
            bool strip = true;
            if (radix != 0) { if (radix < 2 || radix > 36) return double.NaN; if (radix != 16) strip = false; } else radix = 10;
            if (strip && i + 1 < s.Length && s[i] == '0' && (s[i + 1] == 'x' || s[i + 1] == 'X')) { i += 2; radix = 16; }
            int st = i;
            double v = 0;
            while (i < s.Length) { int d = DigitOf(s[i]); if (d < 0 || d >= radix) break; v = v * radix + d; i++; }
            if (i == st) return double.NaN;
            if (radix == 10 && i - st > 15) v = ParseDec(s.Substring(st, i - st));
            return neg ? -v : v;
        }
    }
}
