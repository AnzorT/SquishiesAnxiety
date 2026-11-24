// JavaScript number semantics the Squishdoku port needs to match src/squishdoku/*.js exactly:
// Math.round (halves toward +infinity), truthiness, ToNumber and Number::toString.
// Pure C#, no Unity dependencies.
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SquishSquad.Games.Squishdoku
{
    internal static class Js
    {
        static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        static readonly Regex DecimalLiteral = new Regex(@"^[+-]?(Infinity|(\d+\.?\d*|\.\d+)([eE][+-]?\d+)?)$", RegexOptions.CultureInvariant);
        // the whitespace and line terminators JS's StringToNumber trims (ASCII ones, NBSP, BOM, LS, PS)
        static readonly char[] JsSpace = { ' ', '\t', '\n', '\v', '\f', '\r', (char)0xA0, (char)0xFEFF, (char)0x2028, (char)0x2029 };

        /// <summary>JS Math.round: the nearest integer, halves toward +infinity, keeping -0.</summary>
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            double r = Math.Floor(x);
            if (x - r >= 0.5) r += 1;
            if (r == 0 && (x < 0 || (x == 0 && double.IsNegative(x)))) return -0.0;
            return r;
        }

        public static bool IsNumber(object v)
        {
            return v is double || v is float || v is int || v is long || v is short || v is byte || v is uint || v is ulong || v is decimal;
        }

        /// <summary>JS truthiness for the values a profile can hold (null, bool, numbers, strings, maps, lists).</summary>
        public static bool Truthy(object v)
        {
            if (v == null) return false;
            if (v is bool b) return b;
            if (v is string s) return s.Length > 0;
            if (IsNumber(v))
            {
                double d = Convert.ToDouble(v, Inv);
                return d != 0 && !double.IsNaN(d);
            }
            return true;
        }

        /// <summary>JS ToNumber (Number(v)) for null, bool, numbers and strings; NaN for anything else.</summary>
        public static double ToNumber(object v)
        {
            if (v == null) return 0;
            if (v is bool b) return b ? 1 : 0;
            if (IsNumber(v)) return Convert.ToDouble(v, Inv);
            if (v is string s) return StringToNumber(s);
            return double.NaN;
        }

        static double StringToNumber(string s)
        {
            string t = s.Trim(JsSpace);
            if (t.Length == 0) return 0;
            if (t.Length > 2 && t[0] == '0' && (t[1] == 'x' || t[1] == 'X' || t[1] == 'o' || t[1] == 'O' || t[1] == 'b' || t[1] == 'B'))
            {
                int radix = t[1] == 'x' || t[1] == 'X' ? 16 : t[1] == 'o' || t[1] == 'O' ? 8 : 2;
                double acc = 0;
                for (int i = 2; i < t.Length; i++)
                {
                    int dgt = HexDigit(t[i]);
                    if (dgt < 0 || dgt >= radix) return double.NaN;
                    acc = acc * radix + dgt;
                }
                return acc;
            }
            if (!DecimalLiteral.IsMatch(t)) return double.NaN;
            if (t.EndsWith("Infinity", StringComparison.Ordinal)) return t[0] == '-' ? double.NegativeInfinity : double.PositiveInfinity;
            return double.Parse(t, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, Inv);
        }

        static int HexDigit(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return -1;
        }

        /// <summary>`v || dflt` where the result is used as a number.</summary>
        public static double OrNumber(object v, double dflt)
        {
            return Truthy(v) ? ToNumber(v) : dflt;
        }

        /// <summary>JS Number::toString(10) (String(x), template literals).</summary>
        public static string NumberToString(double x)
        {
            if (double.IsNaN(x)) return "NaN";
            if (x == 0) return "0";
            if (double.IsInfinity(x)) return x > 0 ? "Infinity" : "-Infinity";
            string sign = x < 0 ? "-" : "";
            x = Math.Abs(x);
            // shortest round-trip digits (.NET Core 3.0+ / Unity 2021+), then laid out the ECMAScript way
            string r = x.ToString("R", Inv);
            int e = 0;
            int ei = r.IndexOfAny(new[] { 'E', 'e' });
            string m = r;
            if (ei >= 0)
            {
                e = int.Parse(r.Substring(ei + 1), NumberStyles.AllowLeadingSign, Inv);
                m = r.Substring(0, ei);
            }
            int dot = m.IndexOf('.');
            int intLen = dot < 0 ? m.Length : dot;
            string digits = dot < 0 ? m : m.Remove(dot, 1);
            int n = intLen + e; // value = 0.digits × 10^n
            int lead = 0;
            while (lead < digits.Length - 1 && digits[lead] == '0') lead++;
            digits = digits.Substring(lead);
            n -= lead;
            digits = digits.TrimEnd('0');
            if (digits.Length == 0) return "0";
            int k = digits.Length;
            var sb = new StringBuilder(sign);
            if (k <= n && n <= 21)
            {
                sb.Append(digits).Append('0', n - k);
            }
            else if (0 < n && n <= 21)
            {
                sb.Append(digits, 0, n).Append('.').Append(digits, n, k - n);
            }
            else if (-6 < n && n <= 0)
            {
                sb.Append("0.").Append('0', -n).Append(digits);
            }
            else
            {
                int exp = n - 1;
                sb.Append(digits[0]);
                if (k > 1) sb.Append('.').Append(digits, 1, k - 1);
                sb.Append('e').Append(exp >= 0 ? '+' : '-').Append(Math.Abs(exp).ToString(Inv));
            }
            return sb.ToString();
        }

        public static string IntKey(int v)
        {
            return v.ToString(Inv);
        }
    }
}
