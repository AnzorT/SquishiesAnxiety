// The few JavaScript semantics the Squish Hop port has to reproduce exactly: Math.round, truthiness, ToNumber of a
// profile value, Number.prototype.toFixed, and the order Object.keys / Object.values walk a plain object in.
// Profile values follow the Firestore patch model: numbers are double, maps are IDictionary<string, object>, lists
// are IList<object>, and a missing key is "undefined".
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace SquishSquad.Games.Hop
{
    public static class Js
    {
        // Math.round: the nearest integer, .5 toward +infinity (-2.5 -> -2)
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            double f = Math.Floor(x);
            return x - f >= 0.5 ? f + 1 : f;
        }

        public static bool IsNumber(object v)
        {
            return v is double || v is int || v is long || v is float;
        }

        public static double AsDouble(object v)
        {
            if (v is double d) return d;
            if (v is int i) return i;
            if (v is long l) return l;
            if (v is float f) return f;
            return double.NaN;
        }

        public static bool Truthy(object v)
        {
            if (v == null) return false;
            if (v is bool b) return b;
            if (IsNumber(v)) { double d = AsDouble(v); return d != 0 && !double.IsNaN(d); }
            if (v is string s) return s.Length > 0;
            return true;
        }

        // ToNumber for the values a profile can hold. `missing` (JS undefined) is NaN, null is 0. Strings follow
        // StringToNumber for plain decimals, "Infinity" and 0x hex; maps and lists are NaN (JS would stringify a list).
        public static double ToNumber(object v, bool missing = false)
        {
            if (missing) return double.NaN;
            if (v == null) return 0;
            if (v is bool b) return b ? 1 : 0;
            if (IsNumber(v)) return AsDouble(v);
            if (v is string s)
            {
                s = s.Trim();
                if (s.Length == 0) return 0;
                if (s == "Infinity" || s == "+Infinity") return double.PositiveInfinity;
                if (s == "-Infinity") return double.NegativeInfinity;
                if (s.Length > 2 && s[0] == '0' && (s[1] == 'x' || s[1] == 'X'))
                {
                    double h = 0;
                    for (int i = 2; i < s.Length; i++)
                    {
                        int dgt = Uri.IsHexDigit(s[i]) ? Convert.ToInt32(s[i].ToString(), 16) : -1;
                        if (dgt < 0) return double.NaN;
                        h = h * 16 + dgt;
                    }
                    return h;
                }
                foreach (char c in s)
                    if (!(char.IsDigit(c) || c == '.' || c == 'e' || c == 'E' || c == '+' || c == '-')) return double.NaN;
                double r;
                return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out r) ? r : double.NaN;
            }
            return double.NaN;
        }

        // a map's value for `key`, and whether it was there (JS: undefined when not)
        public static bool TryGet(IDictionary<string, object> map, string key, out object v)
        {
            v = null;
            return map != null && map.TryGetValue(key, out v);
        }

        // the order JS walks an object's own keys in: array-index keys ascending, then the rest in insertion order
        public static List<string> Keys(IDictionary<string, object> map)
        {
            var idx = new List<KeyValuePair<uint, string>>();
            var rest = new List<string>();
            foreach (var k in map.Keys)
            {
                uint u;
                if (IsArrayIndex(k, out u)) idx.Add(new KeyValuePair<uint, string>(u, k));
                else rest.Add(k);
            }
            idx.Sort((a, b) => a.Key.CompareTo(b.Key));
            var outp = new List<string>(idx.Count + rest.Count);
            foreach (var p in idx) outp.Add(p.Value);
            outp.AddRange(rest);
            return outp;
        }

        static bool IsArrayIndex(string k, out uint u)
        {
            u = 0;
            if (k.Length == 0 || k.Length > 10) return false;
            if (k.Length > 1 && k[0] == '0') return false;
            ulong acc = 0;
            foreach (char c in k)
            {
                if (c < '0' || c > '9') return false;
                acc = acc * 10 + (ulong)(c - '0');
            }
            if (acc > 4294967294UL) return false;
            u = (uint)acc;
            return true;
        }

        // a JS number as String(n) gives it, for the integer-valued numbers used as keys (a level number)
        public static string KeyOf(int n)
        {
            return n.ToString(CultureInfo.InvariantCulture);
        }

        // Number.prototype.toFixed(digits): the exact binary value rounded half up (away from zero on the
        // magnitude), with "-" kept for negatives that round to zero ("-0.0") but not for -0.
        public static string ToFixed(double x, int digits)
        {
            if (double.IsNaN(x)) return "NaN";
            if (Math.Abs(x) >= 1e21) return x.ToString("R", CultureInfo.InvariantCulture); // JS: ToString(x)
            bool neg = x < 0;
            if (neg) x = -x;
            long bits = BitConverter.DoubleToInt64Bits(x);
            int exp = (int)((bits >> 52) & 0x7FF);
            long frac = bits & 0xFFFFFFFFFFFFFL;
            BigInteger m;
            int e;
            if (exp == 0) { m = frac; e = -1074; }
            else { m = frac | (1L << 52); e = exp - 1075; }
            // x = m * 2^e; n = round-half-up(x * 10^digits)
            BigInteger scaled = m * BigInteger.Pow(10, digits);
            BigInteger nInt;
            if (e >= 0) nInt = scaled << e;
            else
            {
                BigInteger den = BigInteger.One << -e;
                BigInteger q = BigInteger.DivRem(scaled, den, out BigInteger rem);
                if (rem * 2 >= den) q += 1;
                nInt = q;
            }
            string digs = nInt.ToString(CultureInfo.InvariantCulture);
            var sb = new StringBuilder();
            if (neg) sb.Append('-');
            if (digits == 0) sb.Append(digs);
            else
            {
                if (digs.Length <= digits) digs = new string('0', digits + 1 - digs.Length) + digs;
                sb.Append(digs, 0, digs.Length - digits).Append('.').Append(digs, digs.Length - digits, digits);
            }
            return sb.ToString();
        }
    }
}
