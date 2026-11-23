// Firestore REST values ⇄ the shape the port's game code reads profiles in (Games/*/Levels.cs):
//   mapValue → Dictionary<string, object> (IDictionary<string, object>), arrayValue → List<object>,
//   integerValue / doubleValue → double (a JS number), booleanValue → bool, stringValue → string, nullValue → null,
//   timestampValue → DateTime (UTC), bytesValue → byte[], referenceValue → DocumentRef, geoPointValue → GeoPoint.
//
// Writing goes the other way and also takes int / long / float, any IDictionary<string, object> and any IList. A whole
// number that's a safe integer goes up as integerValue, anything else as doubleValue, as the JS SDK does with a JS
// number. FieldValue sentinels (increment, arrayUnion, serverTimestamp…) aren't values: Firestore.cs pulls them out
// into field transforms before anything reaches here.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Backend
{
    // A Firestore reference value: the document's path inside the database ("users/abc").
    public sealed class DocumentRef : IEquatable<DocumentRef>
    {
        public readonly string Path;
        public DocumentRef(string path) => Path = path;
        public bool Equals(DocumentRef o) => o != null && o.Path == Path;
        public override bool Equals(object o) => Equals(o as DocumentRef);
        public override int GetHashCode() => Path?.GetHashCode() ?? 0;
        public override string ToString() => Path;
    }

    public readonly struct GeoPoint : IEquatable<GeoPoint>
    {
        public readonly double Latitude, Longitude;

        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool Equals(GeoPoint o) => o.Latitude == Latitude && o.Longitude == Longitude;
        public override bool Equals(object o) => o is GeoPoint g && Equals(g);
        public override int GetHashCode() => Latitude.GetHashCode() * 31 + Longitude.GetHashCode();
    }

    public static class FirestoreValues
    {
        const double MaxSafeInteger = 9007199254740991; // Number.MAX_SAFE_INTEGER

        // --- REST → app ----------------------------------------------------------------------------------------

        // A document's (or a mapValue's) `fields` → a map. Null / missing fields → an empty map.
        public static Dictionary<string, object> DecodeFields(object fields, string dbPrefix = null)
        {
            var d = new Dictionary<string, object>();
            if (fields is IDictionary<string, object> m)
                foreach (var kv in m)
                    d[kv.Key] = Decode(kv.Value, dbPrefix);
            return d;
        }

        // One Value object ({ "integerValue": "3" } …) → the app shape. `dbPrefix` ("projects/p/databases/(default)/
        // documents/") is cut off reference values so they hold the in-database path.
        public static object Decode(object value, string dbPrefix = null)
        {
            var v = value as IDictionary<string, object>;
            if (v == null || v.Count == 0) return null;
            foreach (var kv in v)
            {
                object x = kv.Value;
                switch (kv.Key)
                {
                    case "nullValue": return null;
                    case "booleanValue": return x is bool b ? b : Convert.ToBoolean(x, CultureInfo.InvariantCulture);
                    case "integerValue":
                        if (x is double dx) return dx;
                        return (double)long.Parse(Convert.ToString(x, CultureInfo.InvariantCulture), NumberStyles.Integer, CultureInfo.InvariantCulture);
                    case "doubleValue":
                        if (x is double dd) return dd;
                        // NaN / Infinity come as strings
                        return ParseDoubleWord(Convert.ToString(x, CultureInfo.InvariantCulture));
                    case "stringValue": return x as string ?? "";
                    case "timestampValue": return ParseTimestamp(Convert.ToString(x, CultureInfo.InvariantCulture));
                    case "bytesValue": return Convert.FromBase64String(Convert.ToString(x, CultureInfo.InvariantCulture) ?? "");
                    case "referenceValue":
                    {
                        string p = Convert.ToString(x, CultureInfo.InvariantCulture) ?? "";
                        if (dbPrefix != null && p.StartsWith(dbPrefix, StringComparison.Ordinal)) p = p.Substring(dbPrefix.Length);
                        return new DocumentRef(p);
                    }
                    case "geoPointValue":
                        return new GeoPoint(Num(Json.Get(x, "latitude")), Num(Json.Get(x, "longitude")));
                    case "arrayValue":
                    {
                        var list = new List<object>();
                        if (Json.Get(x, "values") is IList vals)
                            foreach (var item in vals)
                                list.Add(Decode(item, dbPrefix));
                        return list;
                    }
                    case "mapValue": return DecodeFields(Json.Get(x, "fields"), dbPrefix);
                }
            }
            return null; // an unknown value type
        }

        static double Num(object o) => o == null ? 0 : Convert.ToDouble(o, CultureInfo.InvariantCulture);

        static double ParseDoubleWord(string s)
        {
            switch (s)
            {
                case "NaN": return double.NaN;
                case "Infinity": return double.PositiveInfinity;
                case "-Infinity": return double.NegativeInfinity;
            }
            return double.Parse(s, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        // RFC 3339 with up to nanoseconds ("2026-11-23T10:00:00.123456789Z"); kept to DateTime's 100 ns ticks.
        public static DateTime ParseTimestamp(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new FormatException("empty timestamp");
            int dot = s.IndexOf('.');
            string frac = "";
            string rest = s;
            if (dot >= 0)
            {
                int end = dot + 1;
                while (end < s.Length && char.IsDigit(s[end])) end++;
                frac = s.Substring(dot + 1, end - dot - 1);
                rest = s.Substring(0, dot) + s.Substring(end);
            }
            var dto = DateTimeOffset.Parse(rest, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            long ticks = 0;
            if (frac.Length > 0)
            {
                string seven = (frac + "0000000").Substring(0, 7);
                ticks = long.Parse(seven, CultureInfo.InvariantCulture);
            }
            return new DateTime(dto.UtcDateTime.Ticks + ticks, DateTimeKind.Utc);
        }

        public static string FormatTimestamp(DateTime t)
        {
            var u = t.Kind == DateTimeKind.Local ? t.ToUniversalTime() : DateTime.SpecifyKind(t, DateTimeKind.Utc);
            return u.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", CultureInfo.InvariantCulture);
        }

        // --- app → REST ----------------------------------------------------------------------------------------

        // A map → a `fields` object.
        public static Dictionary<string, object> EncodeFields(IDictionary<string, object> map, string dbPrefix)
        {
            var f = new Dictionary<string, object>();
            if (map != null)
                foreach (var kv in map)
                    f[kv.Key] = Encode(kv.Value, dbPrefix);
            return f;
        }

        // `dbPrefix` turns a DocumentRef's path into the full resource name a referenceValue needs.
        public static Dictionary<string, object> Encode(object v, string dbPrefix)
        {
            switch (v)
            {
                case null: return One("nullValue", null);
                case bool b: return One("booleanValue", b);
                case string s: return One("stringValue", s);
                case double d: return Number(d);
                case float f: return Number(f);
                case int i: return One("integerValue", i.ToString(CultureInfo.InvariantCulture));
                case long l: return One("integerValue", l.ToString(CultureInfo.InvariantCulture));
                case short sh: return One("integerValue", sh.ToString(CultureInfo.InvariantCulture));
                case byte by: return One("integerValue", by.ToString(CultureInfo.InvariantCulture));
                case uint ui: return One("integerValue", ui.ToString(CultureInfo.InvariantCulture));
                case decimal m: return Number((double)m);
                case DateTime t: return One("timestampValue", FormatTimestamp(t));
                case DateTimeOffset to: return One("timestampValue", FormatTimestamp(to.UtcDateTime));
                case byte[] bytes: return One("bytesValue", Convert.ToBase64String(bytes));
                case DocumentRef r: return One("referenceValue", (dbPrefix ?? "") + r.Path);
                case GeoPoint g:
                    return One("geoPointValue", new Dictionary<string, object> { { "latitude", g.Latitude }, { "longitude", g.Longitude } });
                case FieldValue fv:
                    throw new ArgumentException("FieldValue." + fv.Kind + " can't sit inside an array (Firestore has no transform there)");
                case IDictionary<string, object> map:
                    return One("mapValue", new Dictionary<string, object> { { "fields", EncodeFields(map, dbPrefix) } });
                case IDictionary dict:
                {
                    var m2 = new Dictionary<string, object>();
                    foreach (DictionaryEntry e in dict) m2[Convert.ToString(e.Key, CultureInfo.InvariantCulture)] = e.Value;
                    return Encode(m2, dbPrefix);
                }
                case IEnumerable list:
                {
                    var vals = new List<object>();
                    foreach (var item in list)
                    {
                        if (item is IList && !(item is byte[])) throw new ArgumentException("Firestore arrays can't hold arrays");
                        vals.Add(Encode(item, dbPrefix));
                    }
                    return One("arrayValue", new Dictionary<string, object> { { "values", vals } });
                }
            }
            throw new ArgumentException("Firestore can't store a " + v.GetType().Name);
        }

        // A JS number: a safe integer (not -0) is an integerValue, the rest doubleValue (NaN / ±Infinity as words).
        static Dictionary<string, object> Number(double d)
        {
            if (double.IsNaN(d)) return One("doubleValue", "NaN");
            if (double.IsPositiveInfinity(d)) return One("doubleValue", "Infinity");
            if (double.IsNegativeInfinity(d)) return One("doubleValue", "-Infinity");
            bool negZero = d == 0 && double.IsNegative(d);
            if (!negZero && d == Math.Floor(d) && Math.Abs(d) <= MaxSafeInteger)
                return One("integerValue", ((long)d).ToString(CultureInfo.InvariantCulture));
            return One("doubleValue", d);
        }

        static Dictionary<string, object> One(string k, object v) => new Dictionary<string, object> { { k, v } };

        // --- field paths ---------------------------------------------------------------------------------------

        // "stack.best.3" → ["stack", "best", "3"]. Backtick-quoted segments (`a.b`) keep their dots, as in the
        // REST API's own syntax.
        public static List<string> SplitPath(string dotted)
        {
            var parts = new List<string>();
            var sb = new StringBuilder();
            bool quoted = false;
            for (int i = 0; i < dotted.Length; i++)
            {
                char c = dotted[i];
                if (quoted)
                {
                    if (c == '\\' && i + 1 < dotted.Length) sb.Append(dotted[++i]);
                    else if (c == '`') quoted = false;
                    else sb.Append(c);
                }
                else if (c == '`') quoted = true;
                else if (c == '.')
                {
                    parts.Add(sb.ToString());
                    sb.Clear();
                }
                else sb.Append(c);
            }
            parts.Add(sb.ToString());
            foreach (var p in parts)
                if (p.Length == 0) throw new ArgumentException("bad field path: " + dotted);
            return parts;
        }

        // The REST form of a path: a segment that isn't a plain identifier ([A-Za-z_][A-Za-z0-9_]*) is
        // backtick-quoted, so "stack.best.3" goes up as stack.best.`3` and "xp.12" as xp.`12`.
        public static string QuotePath(IList<string> segments)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < segments.Count; i++)
            {
                if (i > 0) sb.Append('.');
                string s = segments[i];
                if (IsSimple(s)) sb.Append(s);
                else sb.Append('`').Append(s.Replace("\\", "\\\\").Replace("`", "\\`")).Append('`');
            }
            return sb.ToString();
        }

        static bool IsSimple(string s)
        {
            if (s.Length == 0) return false;
            char c0 = s[0];
            if (!(c0 == '_' || (c0 >= 'a' && c0 <= 'z') || (c0 >= 'A' && c0 <= 'Z'))) return false;
            foreach (char c in s)
                if (!(c == '_' || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                    return false;
            return true;
        }
    }
}
