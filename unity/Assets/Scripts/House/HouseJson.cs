// JSON the way the house's JS sees it, so a save read and written in C# is byte-for-byte what the page writes:
// objects keep their keys in JS order (integer-like keys first, ascending, then the rest in insertion order; a deleted
// key that comes back goes to the end), numbers are doubles printed like JS's String(n), JSON.stringify's escaping.
// Unknown keys are just kept: a save from a newer design survives a round trip.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.House
{
    /// <summary>A JS object: string keys in JS property order.</summary>
    public sealed class JObj
    {
        readonly List<string> order = new List<string>();
        readonly Dictionary<string, object> map = new Dictionary<string, object>();

        public int Count => map.Count;
        public bool Has(string k) => map.ContainsKey(k);
        public IEnumerable<string> Keys { get { foreach (var k in OrderedKeys()) yield return k; } }

        public object this[string k]
        {
            get => map.TryGetValue(k, out var v) ? v : null;
            set { if (!map.ContainsKey(k)) order.Add(k); map[k] = value; }
        }

        public bool Remove(string k) { if (!map.Remove(k)) return false; order.Remove(k); return true; }

        static bool IsIndex(string k, out uint n)
        {
            n = 0;
            if (k.Length == 0 || k.Length > 10 || (k.Length > 1 && k[0] == '0')) return false;
            foreach (var c in k) if (c < '0' || c > '9') return false;
            if (!uint.TryParse(k, NumberStyles.None, CultureInfo.InvariantCulture, out n)) return false;
            return n != uint.MaxValue;
        }

        List<string> OrderedKeys()
        {
            List<(uint, string)> idx = null;
            var rest = new List<string>(order.Count);
            foreach (var k in order) { if (IsIndex(k, out var n)) (idx = idx ?? new List<(uint, string)>()).Add((n, k)); else rest.Add(k); }
            if (idx == null) return rest;
            idx.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            var all = new List<string>(order.Count);
            foreach (var p in idx) all.Add(p.Item2);
            all.AddRange(rest);
            return all;
        }

        // typed helpers
        public JObj Obj(string k) => this[k] as JObj;
        public List<object> Arr(string k) => this[k] as List<object>;
        public string Str(string k) => this[k] as string;
        public double Num(string k, double def = 0) => this[k] is double d ? d : def;
        public bool Truthy(string k) => HouseJson.Truthy(this[k]);
        /// <summary>o[k] = o[k] || {} : the object at k, made when it's missing or falsy.</summary>
        public JObj Ensure(string k) { if (this[k] is JObj o) return o; var n = new JObj(); this[k] = n; return n; }
        public List<object> EnsureArr(string k) { if (this[k] is List<object> l) return l; var n = new List<object>(); this[k] = n; return n; }
    }

    public static class HouseJson
    {
        /// <summary>A key that exists with the value undefined (JSON.stringify leaves it out, its place in the order stays).</summary>
        public static readonly object Undefined = new object();

        /// <summary>JS truthiness of a parsed value.</summary>
        public static bool Truthy(object v) => v switch
        {
            null => false,
            bool b => b,
            object u when u == Undefined => false,
            double d => d != 0 && !double.IsNaN(d),
            string s => s.Length > 0,
            _ => true,
        };

        /// <summary>a || b, JS style.</summary>
        public static object Or(object a, object b) => Truthy(a) ? a : b;

        /// <summary>String(v) as JS prints it (for keys made of values: 'i' + uid).</summary>
        public static string JsString(object v) => v switch
        {
            null => "null",
            string s => s,
            bool b => b ? "true" : "false",
            double d => SquishSquad.Anim.JsNumber.ToString(d),
            _ => Convert.ToString(v, CultureInfo.InvariantCulture),
        };

        // ---- reading ----
        public static object Parse(string s)
        {
            int i = 0;
            Ws(s, ref i);
            var v = Value(s, ref i);
            Ws(s, ref i);
            if (i != s.Length) throw new FormatException("JSON: trailing text at " + i);
            return v;
        }

        static void Ws(string s, ref int i) { while (i < s.Length && (s[i] == ' ' || s[i] == '\t' || s[i] == '\n' || s[i] == '\r')) i++; }

        static object Value(string s, ref int i)
        {
            if (i >= s.Length) throw new FormatException("JSON: unexpected end");
            char c = s[i];
            if (c == '{')
            {
                var o = new JObj(); i++; Ws(s, ref i);
                if (s[i] == '}') { i++; return o; }
                for (;;)
                {
                    Ws(s, ref i); var k = Str(s, ref i); Ws(s, ref i);
                    if (s[i] != ':') throw new FormatException("JSON: ':' expected at " + i);
                    i++; Ws(s, ref i);
                    o[k] = Value(s, ref i); Ws(s, ref i);
                    if (s[i] == ',') { i++; continue; }
                    if (s[i] == '}') { i++; return o; }
                    throw new FormatException("JSON: ',' or '}' expected at " + i);
                }
            }
            if (c == '[')
            {
                var a = new List<object>(); i++; Ws(s, ref i);
                if (s[i] == ']') { i++; return a; }
                for (;;)
                {
                    Ws(s, ref i); a.Add(Value(s, ref i)); Ws(s, ref i);
                    if (s[i] == ',') { i++; continue; }
                    if (s[i] == ']') { i++; return a; }
                    throw new FormatException("JSON: ',' or ']' expected at " + i);
                }
            }
            if (c == '"') return Str(s, ref i);
            if (s.Length - i >= 4 && string.CompareOrdinal(s, i, "true", 0, 4) == 0) { i += 4; return true; }
            if (s.Length - i >= 5 && string.CompareOrdinal(s, i, "false", 0, 5) == 0) { i += 5; return false; }
            if (s.Length - i >= 4 && string.CompareOrdinal(s, i, "null", 0, 4) == 0) { i += 4; return null; }
            int st = i;
            while (i < s.Length && "+-0123456789.eE".IndexOf(s[i]) >= 0) i++;
            if (st == i) throw new FormatException("JSON: unexpected '" + c + "' at " + i);
            return double.Parse(s.Substring(st, i - st), NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        static string Str(string s, ref int i)
        {
            if (s[i] != '"') throw new FormatException("JSON: string expected at " + i);
            i++;
            var sb = new StringBuilder();
            while (s[i] != '"')
            {
                char c = s[i++];
                if (c != '\\') { sb.Append(c); continue; }
                char e = s[i++];
                switch (e)
                {
                    case 'n': sb.Append('\n'); break;
                    case 't': sb.Append('\t'); break;
                    case 'r': sb.Append('\r'); break;
                    case 'b': sb.Append('\b'); break;
                    case 'f': sb.Append('\f'); break;
                    case 'u': sb.Append((char)int.Parse(s.Substring(i, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture)); i += 4; break;
                    default: sb.Append(e); break;
                }
            }
            i++;
            return sb.ToString();
        }

        // ---- writing: JSON.stringify ----
        public static string Stringify(object v) { var sb = new StringBuilder(); Write(sb, v); return sb.ToString(); }

        static void Write(StringBuilder sb, object v)
        {
            switch (v)
            {
                case null: sb.Append("null"); return;
                case bool b: sb.Append(b ? "true" : "false"); return;
                case double d: sb.Append(double.IsNaN(d) || double.IsInfinity(d) ? "null" : SquishSquad.Anim.JsNumber.ToString(d)); return;
                case int n: sb.Append(n.ToString(CultureInfo.InvariantCulture)); return;
                case string s: Quote(sb, s); return;
                case JObj o:
                {
                    sb.Append('{'); bool first = true;
                    foreach (var k in o.Keys) { var v2 = o[k]; if (v2 == Undefined) continue; if (!first) sb.Append(','); first = false; Quote(sb, k); sb.Append(':'); Write(sb, v2); }
                    sb.Append('}'); return;
                }
                case List<object> a:
                {
                    sb.Append('['); for (int i = 0; i < a.Count; i++) { if (i > 0) sb.Append(','); Write(sb, a[i] == Undefined ? null : a[i]); }
                    sb.Append(']'); return;
                }
                default: Quote(sb, Convert.ToString(v, CultureInfo.InvariantCulture)); return;
            }
        }

        public static void Quote(StringBuilder sb, string s)
        {
            sb.Append('"');
            foreach (char c in s)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    default:
                        if (c < 0x20) sb.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
                        else sb.Append(c);
                        break;
                }
            }
            sb.Append('"');
        }
    }
}
