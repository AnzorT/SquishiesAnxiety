// JS's Number-to-String (ECMAScript Number::toString, radix 10) and the bits of parseInt/parseFloat that
// AnimatedInterpolation and normalize-colors use. String interpolation outputs ('6deg', 'rgba(…)') are
// built with String(number), so they have to print exactly like JS.
using System;
using System.Globalization;
using System.Text;

namespace SquishSquad.Anim
{
    public static class JsNumber
    {
        static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        static readonly string[] EFormats = { "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "E10", "E11", "E12", "E13", "E14", "E15", "E16" };

        /// <summary>String(v) as JS prints it: shortest round-trip digits, JS's exponent rules.</summary>
        public static string ToString(double v)
        {
            if (double.IsNaN(v)) return "NaN";
            if (v == 0) return "0";
            if (double.IsPositiveInfinity(v)) return "Infinity";
            if (double.IsNegativeInfinity(v)) return "-Infinity";
            if (v < 0) return "-" + ToString(-v);
            if (v < 9007199254740992.0 && v == Math.Floor(v)) return ((long)v).ToString(Inv);

            string digits; int n;
            Shortest(v, out digits, out n);
            int k = digits.Length;
            if (k <= n && n <= 21) return digits + new string('0', n - k);
            if (0 < n && n <= 21) return digits.Substring(0, n) + "." + digits.Substring(n);
            if (-6 < n && n <= 0) return "0." + new string('0', -n) + digits;
            int e = n - 1;
            string es = e < 0 ? "-" + (-e).ToString(Inv) : "+" + e.ToString(Inv);
            if (k == 1) return digits + "e" + es;
            return digits.Substring(0, 1) + "." + digits.Substring(1) + "e" + es;
        }

        // The fewest significant digits that read back as v (v > 0, finite), as a digit string and the decimal
        // exponent n with v ~= 0.d1d2...dk * 10^n. Correct rounding to p digits round-trips for every p at or
        // above the minimum, so a binary search finds it.
        static void Shortest(double v, out string digits, out int n)
        {
            int lo = 1, hi = 17;
            while (lo < hi)
            {
                int mid = (lo + hi) >> 1;
                if (double.Parse(v.ToString(EFormats[mid - 1], Inv), NumberStyles.Float, Inv) == v) hi = mid;
                else lo = mid + 1;
            }
            string s = v.ToString(EFormats[lo - 1], Inv); // d.dddE+xxx
            int ePos = s.IndexOf('E');
            var sb = new StringBuilder(lo);
            for (int i = 0; i < ePos; i++) if (s[i] != '.') sb.Append(s[i]);
            int len = sb.Length;
            while (len > 1 && sb[len - 1] == '0') len--;
            sb.Length = len;
            digits = sb.ToString();
            n = int.Parse(s.Substring(ePos + 1), NumberStyles.AllowLeadingSign, Inv) + 1;
        }

        /// <summary>JS unary plus / Number(s) for the strings the string-shape regex matches.</summary>
        public static double ParseNumber(string s)
        {
            return double.Parse(s, NumberStyles.Float, Inv);
        }

        /// <summary>parseInt(s, 10) for strings of the form [-+]?\d*\.?\d+ (NaN when no leading digits).</summary>
        public static double ParseInt(string s)
        {
            int i = 0;
            bool neg = false;
            if (i < s.Length && (s[i] == '+' || s[i] == '-')) { neg = s[i] == '-'; i++; }
            int start = i;
            double r = 0;
            while (i < s.Length && s[i] >= '0' && s[i] <= '9') { r = r * 10 + (s[i] - '0'); i++; }
            if (i == start) return double.NaN;
            if (i - start > 15) r = double.Parse(s.Substring(start, i - start), NumberStyles.None, Inv);
            return neg ? -r : r;
        }

        /// <summary>parseFloat(s) for NUMBER or NUMBER% strings.</summary>
        public static double ParseFloat(string s)
        {
            if (s.EndsWith("%", StringComparison.Ordinal)) s = s.Substring(0, s.Length - 1);
            return double.Parse(s, NumberStyles.Float, Inv);
        }
    }
}
