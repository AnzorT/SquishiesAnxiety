// The few JavaScript semantics Squish Stack's rules lean on (Math.round, `||` truthiness, number coercion of the
// values a Firestore profile holds), so the port answers exactly what src/stack/levels.js answers.
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Games.Stack
{
    internal static class Js
    {
        // Math.round: halves go toward +infinity (-2.5 → -2), and 0.49999999999999994 → 0
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            double f = Math.Floor(x);
            return x - f >= 0.5 ? f + 1 : f;
        }

        // `!!v`
        public static bool Truthy(object v)
        {
            if (v == null) return false;
            if (v is bool b) return b;
            if (v is string str) return str.Length > 0;
            if (IsNumber(v))
            {
                double d = Convert.ToDouble(v, CultureInfo.InvariantCulture);
                return !(d == 0 || double.IsNaN(d));
            }
            return true;
        }

        // `v || d`
        public static object Or(object v, object d) => Truthy(v) ? v : d;

        public static bool IsNumber(object v) =>
            v is double || v is int || v is long || v is float || v is short || v is byte || v is uint || v is ulong || v is decimal;

        // Number(v), for what a profile holds: numbers, booleans, null (0), numeric strings; anything else NaN
        public static double ToNum(object v)
        {
            if (v == null) return 0;
            if (v is bool b) return b ? 1 : 0;
            if (IsNumber(v)) return Convert.ToDouble(v, CultureInfo.InvariantCulture);
            if (v is string str)
            {
                str = str.Trim();
                if (str.Length == 0) return 0;
                double d;
                return double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out d) ? d : double.NaN;
            }
            return double.NaN;
        }

        // obj[key], or null (undefined) when missing or obj isn't a map
        public static object Get(object obj, string key)
        {
            var m = obj as IDictionary<string, object>;
            object v;
            return m != null && m.TryGetValue(key, out v) ? v : null;
        }

        // String(n) for the whole numbers these print
        public static string Int(double n) => ((long)n).ToString(CultureInfo.InvariantCulture);
    }
}
