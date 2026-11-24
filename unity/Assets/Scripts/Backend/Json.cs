// A small JSON reader / writer for the Firebase REST client (Unity has no System.Text.Json, and JsonUtility can't read
// free-form maps). Reading gives the same shape the rest of the port uses for Firestore data: objects as
// Dictionary<string, object>, arrays as List<object>, numbers as double, plus bool, string and null.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Backend
{
    public static class Json
    {
        // --- reading ---------------------------------------------------------------------------------------------

        public static object Parse(string text)
        {
            if (text == null) throw new FormatException("JSON: null input");
            var r = new Reader(text);
            r.SkipWs();
            object v = r.Value();
            r.SkipWs();
            if (r.Pos != text.Length) throw r.Error("trailing characters");
            return v;
        }

        // Parse, or null when the text is empty or not JSON (an HTML error page, say).
        public static object TryParse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            try
            {
                return Parse(text);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        sealed class Reader
        {
            readonly string s;
            public int Pos;
            int depth;

            public Reader(string s)
            {
                this.s = s;
            }

            public FormatException Error(string what) => new FormatException("JSON: " + what + " at " + Pos);

            public void SkipWs()
            {
                while (Pos < s.Length)
                {
                    char c = s[Pos];
                    if (c == ' ' || c == '\t' || c == '\n' || c == '\r') Pos++;
                    else break;
                }
            }

            public object Value()
            {
                if (Pos >= s.Length) throw Error("unexpected end");
                char c = s[Pos];
                switch (c)
                {
                    case '{': return Obj();
                    case '[': return Arr();
                    case '"': return Str();
                    case 't': Word("true"); return true;
                    case 'f': Word("false"); return false;
                    case 'n': Word("null"); return null;
                    default:
                        if (c == '-' || (c >= '0' && c <= '9')) return Num();
                        throw Error("unexpected '" + c + "'");
                }
            }

            void Word(string w)
            {
                if (string.CompareOrdinal(s, Pos, w, 0, w.Length) != 0) throw Error("bad literal");
                Pos += w.Length;
            }

            void Enter()
            {
                if (++depth > 256) throw Error("nested too deep");
            }

            Dictionary<string, object> Obj()
            {
                Enter();
                var d = new Dictionary<string, object>();
                Pos++; // {
                SkipWs();
                if (Pos < s.Length && s[Pos] == '}')
                {
                    Pos++;
                    depth--;
                    return d;
                }
                while (true)
                {
                    SkipWs();
                    if (Pos >= s.Length || s[Pos] != '"') throw Error("expected a key");
                    string k = Str();
                    SkipWs();
                    if (Pos >= s.Length || s[Pos] != ':') throw Error("expected ':'");
                    Pos++;
                    SkipWs();
                    d[k] = Value();
                    SkipWs();
                    if (Pos >= s.Length) throw Error("unexpected end");
                    if (s[Pos] == ',')
                    {
                        Pos++;
                        continue;
                    }
                    if (s[Pos] == '}')
                    {
                        Pos++;
                        depth--;
                        return d;
                    }
                    throw Error("expected ',' or '}'");
                }
            }

            List<object> Arr()
            {
                Enter();
                var l = new List<object>();
                Pos++; // [
                SkipWs();
                if (Pos < s.Length && s[Pos] == ']')
                {
                    Pos++;
                    depth--;
                    return l;
                }
                while (true)
                {
                    SkipWs();
                    l.Add(Value());
                    SkipWs();
                    if (Pos >= s.Length) throw Error("unexpected end");
                    if (s[Pos] == ',')
                    {
                        Pos++;
                        continue;
                    }
                    if (s[Pos] == ']')
                    {
                        Pos++;
                        depth--;
                        return l;
                    }
                    throw Error("expected ',' or ']'");
                }
            }

            string Str()
            {
                Pos++; // "
                var sb = new StringBuilder();
                while (true)
                {
                    if (Pos >= s.Length) throw Error("unterminated string");
                    char c = s[Pos++];
                    if (c == '"') return sb.ToString();
                    if (c != '\\')
                    {
                        sb.Append(c);
                        continue;
                    }
                    if (Pos >= s.Length) throw Error("bad escape");
                    char e = s[Pos++];
                    switch (e)
                    {
                        case '"': sb.Append('"'); break;
                        case '\\': sb.Append('\\'); break;
                        case '/': sb.Append('/'); break;
                        case 'b': sb.Append('\b'); break;
                        case 'f': sb.Append('\f'); break;
                        case 'n': sb.Append('\n'); break;
                        case 'r': sb.Append('\r'); break;
                        case 't': sb.Append('\t'); break;
                        case 'u':
                            if (Pos + 4 > s.Length) throw Error("bad \\u escape");
                            int code;
                            if (!int.TryParse(s.Substring(Pos, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out code))
                                throw Error("bad \\u escape");
                            sb.Append((char)code);
                            Pos += 4;
                            break;
                        default: throw Error("bad escape");
                    }
                }
            }

            double Num()
            {
                int start = Pos;
                if (s[Pos] == '-') Pos++;
                while (Pos < s.Length)
                {
                    char c = s[Pos];
                    if ((c >= '0' && c <= '9') || c == '.' || c == 'e' || c == 'E' || c == '+' || c == '-') Pos++;
                    else break;
                }
                double d;
                if (!double.TryParse(s.Substring(start, Pos - start), NumberStyles.Float, CultureInfo.InvariantCulture, out d))
                    throw Error("bad number");
                return d;
            }
        }

        // --- writing ---------------------------------------------------------------------------------------------

        // Maps (IDictionary with string keys), lists (any IEnumerable that isn't a string), strings, bools, numbers
        // and null. A number that's NaN / Infinity has no JSON form and is written as null, like JSON.stringify.
        public static string Write(object value)
        {
            var sb = new StringBuilder();
            WriteValue(sb, value, 0);
            return sb.ToString();
        }

        static void WriteValue(StringBuilder sb, object v, int depth)
        {
            if (depth > 256) throw new InvalidOperationException("JSON: nested too deep");
            switch (v)
            {
                case null:
                    sb.Append("null");
                    return;
                case string str:
                    WriteString(sb, str);
                    return;
                case bool b:
                    sb.Append(b ? "true" : "false");
                    return;
                case double d:
                    WriteNumber(sb, d);
                    return;
                case float f:
                    WriteNumber(sb, f);
                    return;
                case int _:
                case long _:
                case short _:
                case byte _:
                case uint _:
                case ulong _:
                case sbyte _:
                case ushort _:
                    sb.Append(Convert.ToString(v, CultureInfo.InvariantCulture));
                    return;
                case decimal m:
                    sb.Append(m.ToString(CultureInfo.InvariantCulture));
                    return;
                case IDictionary<string, object> map:
                {
                    sb.Append('{');
                    bool first = true;
                    foreach (var kv in map)
                    {
                        if (!first) sb.Append(',');
                        first = false;
                        WriteString(sb, kv.Key);
                        sb.Append(':');
                        WriteValue(sb, kv.Value, depth + 1);
                    }
                    sb.Append('}');
                    return;
                }
                case IDictionary dict:
                {
                    sb.Append('{');
                    bool first = true;
                    foreach (DictionaryEntry kv in dict)
                    {
                        if (!first) sb.Append(',');
                        first = false;
                        WriteString(sb, Convert.ToString(kv.Key, CultureInfo.InvariantCulture));
                        sb.Append(':');
                        WriteValue(sb, kv.Value, depth + 1);
                    }
                    sb.Append('}');
                    return;
                }
                case IEnumerable list:
                {
                    sb.Append('[');
                    bool first = true;
                    foreach (var item in list)
                    {
                        if (!first) sb.Append(',');
                        first = false;
                        WriteValue(sb, item, depth + 1);
                    }
                    sb.Append(']');
                    return;
                }
                default:
                    WriteString(sb, Convert.ToString(v, CultureInfo.InvariantCulture));
                    return;
            }
        }

        static void WriteNumber(StringBuilder sb, double d)
        {
            if (double.IsNaN(d) || double.IsInfinity(d))
            {
                sb.Append("null");
                return;
            }
            // whole numbers without an exponent or ".0" where they fit (JSON.stringify(250) → 250)
            if (d == Math.Floor(d) && Math.Abs(d) < 1e15)
            {
                sb.Append(((long)d).ToString(CultureInfo.InvariantCulture));
                return;
            }
            sb.Append(d.ToString("R", CultureInfo.InvariantCulture));
        }

        public static void WriteString(StringBuilder sb, string s)
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
                        if (c < 0x20 || c == (char)0x2028 || c == (char)0x2029)
                            sb.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
                        else sb.Append(c);
                        break;
                }
            }
            sb.Append('"');
        }

        // --- reading helpers for responses ------------------------------------------------------------------------

        internal static string Str(object map, string key)
        {
            var d = map as IDictionary<string, object>;
            object v;
            return d != null && d.TryGetValue(key, out v) && v != null ? Convert.ToString(v, CultureInfo.InvariantCulture) : null;
        }

        internal static object Get(object map, string key)
        {
            var d = map as IDictionary<string, object>;
            object v;
            return d != null && d.TryGetValue(key, out v) ? v : null;
        }
    }
}
