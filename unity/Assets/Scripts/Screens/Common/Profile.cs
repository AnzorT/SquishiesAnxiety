// Reading the player's profile document (Backend: IDictionary<string, object>, numbers as double or long, maps as
// IDictionary, arrays as IList) the way the app's JS reads it: `profile?.stats?.presses ?? 0`, truthiness, dates as
// the player's own day ("2026-11-23", src/dailySpin.js todayKey).
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SquishSquad.Screens
{
    public static class Prof
    {
        public static object Get(IDictionary<string, object> m, string key)
        {
            if (m == null || key == null) return null;
            return m.TryGetValue(key, out var v) ? v : null;
        }

        /// <summary>A dotted path ("stats.playTime"): null when any step is missing.</summary>
        public static object At(IDictionary<string, object> m, string path)
        {
            object cur = m;
            foreach (var k in path.Split('.'))
            {
                var map = Map(cur);
                if (map == null) return null;
                cur = Get(map, k);
            }
            return cur;
        }

        public static bool IsNum(object v) => v is double || v is float || v is long || v is int || v is short || v is decimal || v is uint || v is ulong;
        public static double D(object v) => Convert.ToDouble(v, CultureInfo.InvariantCulture);
        /// <summary>`v ?? def` for a number (anything else: def).</summary>
        public static double Num(object v, double def = 0) => IsNum(v) ? D(v) : def;
        public static double Num(IDictionary<string, object> m, string path, double def = 0) => Num(At(m, path), def);
        public static string Str(object v) => v as string;
        public static IDictionary<string, object> Map(object v) => v as IDictionary<string, object>;
        public static IList<object> List(object v)
        {
            if (v is IList<object> l) return l;
            if (v is System.Collections.IList il) { var r = new List<object>(); foreach (var x in il) r.Add(x); return r; }
            return null;
        }

        /// <summary>JS truthiness.</summary>
        public static bool Truthy(object v)
        {
            if (v == null) return false;
            if (v is bool b) return b;
            if (IsNum(v)) { double d = D(v); return d != 0 && !double.IsNaN(d); }
            if (v is string s) return s.Length > 0;
            return true;
        }

        /// <summary>ownedIds as strings.</summary>
        public static HashSet<string> Owned(IDictionary<string, object> p)
        {
            var set = new HashSet<string>();
            var l = List(Get(p, "ownedIds"));
            if (l != null) foreach (var x in l) if (x != null) set.Add(IsNum(x) ? D(x).ToString(CultureInfo.InvariantCulture) : x.ToString());
            return set;
        }

        /// <summary>functions/squad.js owns: in the collection (`col`) or in ownedIds.</summary>
        public static bool Owns(IDictionary<string, object> p, string id) => Truthy(Get(Map(Get(p, "col")), id)) || Owned(p).Contains(id);

        // ---- days -------------------------------------------------------------------------------------------------
        /// <summary>The player's calendar day of a local time (todayKey).</summary>
        public static string DayKey(DateTime local) => local.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public static DateTime ParseDay(string day) => DateTime.ParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        public static string DayBefore(string day) => DayKey(ParseDay(day).AddDays(-1));

        // ---- numbers as the app writes them -------------------------------------------------------------------------
        /// <summary>format.js fmtNum: whole numbers with thousands commas.</summary>
        public static string Fmt(double n)
        {
            double v = JsRound(double.IsNaN(n) ? 0 : n);
            string s = Math.Abs(v).ToString("#,0", CultureInfo.InvariantCulture);
            return v < 0 ? "-" + s : s;
        }

        public static double JsRound(double v) => Math.Floor(v + 0.5);

        /// <summary>JS String(n) for the numbers the screens show (whole numbers, or a few decimals).</summary>
        public static string JsStr(double v)
        {
            if (v == Math.Floor(v) && Math.Abs(v) < 1e15) return ((long)v).ToString(CultureInfo.InvariantCulture);
            return v.ToString("R", CultureInfo.InvariantCulture);
        }

        /// <summary>Number.prototype.toFixed(1).</summary>
        public static string Fixed1(double v) => (Math.Round(v * 10, MidpointRounding.AwayFromZero) / 10).ToString("0.0", CultureInfo.InvariantCulture);
    }
}
