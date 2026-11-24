// JavaScript number semantics the Squish Sort port needs to match the JS
// exactly (src/sort/*.js): Math.round, `x | 0`, truthiness, `||` fallbacks
// and ToNumber over the loosely typed profile values (double, bool, null,
// IDictionary<string, object>).
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Games.Sort
{
    internal static class JsMath
    {
        // Math.round: halves go toward +infinity (-2.5 -> -2), and
        // 0.49999999999999994 -> 0 (unlike Math.Floor(x + 0.5)).
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            double f = Math.Floor(x);
            return x - f >= 0.5 ? f + 1 : f;
        }

        // Math.max / Math.min: NaN if either is NaN (as .NET Core's Math.Max).
        public static double Max(double a, double b) => double.IsNaN(a) || double.IsNaN(b) ? double.NaN : (a > b ? a : (b > a ? b : (a == 0 && b == 0 ? (IsNegZero(a) ? b : a) : a)));
        public static double Min(double a, double b) => double.IsNaN(a) || double.IsNaN(b) ? double.NaN : (a < b ? a : (b < a ? b : (a == 0 && b == 0 ? (IsNegZero(a) ? a : b) : a)));
        static bool IsNegZero(double d) => d == 0 && double.IsNegative(d);

        // `x | 0` (ToInt32)
        public static int ToInt32(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return 0;
            double t = Math.Truncate(x);
            double m = t % 4294967296.0;
            if (m < 0) m += 4294967296.0;
            return unchecked((int)(uint)m);
        }

        public static bool IsNumber(object v) => v is double || v is float || v is int || v is long || v is short || v is byte || v is uint || v is ulong || v is decimal || v is sbyte || v is ushort;

        public static double AsDouble(object v) => Convert.ToDouble(v, CultureInfo.InvariantCulture);

        // JS truthiness of a profile value
        public static bool Truthy(object v)
        {
            if (v == null) return false;
            if (v is bool b) return b;
            if (IsNumber(v))
            {
                double d = AsDouble(v);
                return d != 0 && !double.IsNaN(d);
            }
            if (v is string s) return s.Length > 0;
            return true;
        }

        // ToNumber for the values the profile holds (numbers, null, bools);
        // anything else is NaN (strings are not supported: Firestore only
        // writes numbers in these fields).
        public static double ToNum(object v)
        {
            if (v == null) return 0;
            if (v is bool b) return b ? 1 : 0;
            if (IsNumber(v)) return AsDouble(v);
            return double.NaN;
        }

        // `v || fallback`, as a number
        public static double OrNum(object v, double fallback) => Truthy(v) ? ToNum(v) : fallback;

        public static IDictionary<string, object> AsMap(object v) => v as IDictionary<string, object>;

        // map[key] (undefined -> found false)
        public static object Get(IDictionary<string, object> map, string key, out bool found)
        {
            found = false;
            if (map == null) return null;
            object v;
            if (map.TryGetValue(key, out v)) { found = true; return v; }
            return null;
        }

        public static object Get(IDictionary<string, object> map, string key)
        {
            bool found;
            return Get(map, key, out found);
        }

        // String(n) for the integers used as keys
        public static string Key(double n) => n == Math.Floor(n) && Math.Abs(n) < 1e15 ? ((long)n).ToString(CultureInfo.InvariantCulture) : n.ToString("R", CultureInfo.InvariantCulture);
    }
}
