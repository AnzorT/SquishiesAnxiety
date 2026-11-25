// The JS language for the compiled rig (tools/unity/rig/jsc.mjs): conversions, operators, property access, calls, the
// global object, as ECMAScript defines them (what V8 does where it's the engine's choice: number formatting, Math's
// last bits, stable sort). The compiled scripts `using static` this class. Built-ins: Rt.Builtins.cs.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace SquishSquad.Creatures.Js
{
    public static partial class Rt
    {
        public static readonly V Hole = V.HoleV;
        public static JsObject ObjectProto, FunctionProto, ArrayProto, StringProto, NumberProto, BooleanProto, ErrorProto, RegExpProto;
        public static JsObject Global;
        public static V GlobalV;
        /// <summary>Errors that aren't JS throws (a bug in this runtime or the compiled code) caught by the scripts'
        /// try / catch: counted, and handed here (the tests fail on any).</summary>
        public static Action<Exception> OnHostError;
        public static int HostErrors;

        static Rt() { Init(); }

        // ------------------------------------------------------------------ conversions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Truthy(V v)
        {
            var o = v.O;
            if (o == Tag.Num) return v.D != 0 && !double.IsNaN(v.D);
            if (o == null || o == Tag.False || o == Tag.Null) return false;
            if (o is string s) return s.Length != 0;
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NumTruthy(double d) => d != 0 && !double.IsNaN(d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNum(V v) => v.O == Tag.Num ? v.D : ToNumSlow(v);
        static double ToNumSlow(V v)
        {
            var o = v.O;
            if (o == null) return double.NaN;
            if (o == Tag.Null || o == Tag.False) return 0;
            if (o == Tag.True) return 1;
            if (o is string s) return JsNumber.StringToNumber(s);
            return ToNum(ToPrimitive(v, true));
        }
        public static V ToPrimitive(V v, bool numberHint)
        {
            if (!(v.O is JsObject o)) return v;
            string first = numberHint ? "valueOf" : "toString", second = numberHint ? "toString" : "valueOf";
            var f = o.Get(first, v);
            if (f.O is JsFunction fn) { var r = fn.Fn(v, 0, default, default, default, default, null); if (!(r.O is JsObject)) return r; }
            f = o.Get(second, v);
            if (f.O is JsFunction fn2) { var r = fn2.Fn(v, 0, default, default, default, default, null); if (!(r.O is JsObject)) return r; }
            throw TypeErr("Cannot convert object to primitive value");
        }
        public static string ToStr(V v)
        {
            var o = v.O;
            if (o is string s) return s;
            if (o == Tag.Num) return JsNumber.ToString(v.D);
            if (o == null) return "undefined";
            if (o == Tag.Null) return "null";
            if (o == Tag.True) return "true";
            if (o == Tag.False) return "false";
            return ToStr(ToPrimitive(v, false));
        }
        public static string ToStrS(V v) => ToStr(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string NumStr(double d) => JsNumber.ToString(d);

        /// <summary>A property key: strings as they are, numbers as their JS string.</summary>
        public static string ToKey(V k)
        {
            if (k.O is string s) return s;
            if (k.O == Tag.Num) return NumKey(k.D);
            return ToStr(k);
        }
        static readonly string[] SmallInts = MakeSmallInts();
        static string[] MakeSmallInts() { var a = new string[1024]; for (int i = 0; i < a.Length; i++) a[i] = i.ToString(CultureInfo.InvariantCulture); return a; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string IndexKey(int i) => (uint)i < 1024u ? SmallInts[i] : i.ToString(CultureInfo.InvariantCulture);
        public static string NumKey(double d) { int i = (int)d; if (i == d && i >= 0 && !(d == 0 && double.IsNegative(d))) return IndexKey(i); return JsNumber.ToString(d); }
        /// <summary>Whether a key is an array index ("0", "17"; not "01", "-1", "1.5").</summary>
        public static bool IsIndexKey(string k)
        {
            int n = k.Length;
            if (n == 0 || n > 10) return false;
            if (k[0] == '0') return n == 1;
            long v = 0;
            for (int i = 0; i < n; i++) { char c = k[i]; if (c < '0' || c > '9') return false; v = v * 10 + (c - '0'); }
            return v < 4294967295L;
        }

        public static int ToInt32(double d)
        {
            if (d >= -2147483648.0 && d <= 2147483647.0) return (int)d;
            if (double.IsNaN(d) || double.IsInfinity(d)) return 0;
            double t = Math.Truncate(d) % 4294967296.0;
            if (t < 0) t += 4294967296.0;
            return unchecked((int)(uint)t);
        }
        public static uint ToUint32(double d) => unchecked((uint)ToInt32(d));

        // ------------------------------------------------------------------ operators
        public static V Add(V a, V b)
        {
            if (a.O == Tag.Num && b.O == Tag.Num) return a.D + b.D;
            if (a.O is string sa && b.O is string sb) return string.Concat(sa, sb);
            var pa = ToPrimitive(a, false); var pb = ToPrimitive(b, false);
            if (pa.O is string || pb.O is string) return string.Concat(ToStr(pa), ToStr(pb));
            return ToNum(pa) + ToNum(pb);
        }
        public static V Seq(V a, V b) => b;
        public static V DestructureExpr(V v, Action<V> f) { f(v); return v; }

        public static bool SEq(V a, V b)
        {
            if (a.O == Tag.Num) return b.O == Tag.Num && a.D == b.D;
            if (a.O is string s) return b.O is string t && string.Equals(s, t);
            return a.O == b.O;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SEqS(V a, string s) => a.O is string t && string.Equals(t, s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SEqN(V a, double d) => a.O == Tag.Num && a.D == d;
        public static bool LEq(V a, V b)
        {
            for (;;)
            {
                if (a.O == Tag.Num && b.O == Tag.Num) return a.D == b.D;
                if (a.O is string s1 && b.O is string s2) return string.Equals(s1, s2);
                if (a.IsNullish) return b.IsNullish;
                if (b.IsNullish) return false;
                if (a.O is JsObject && b.O is JsObject) return a.O == b.O;
                if (a.IsBool && b.IsBool) return a.O == b.O;
                if (a.O == Tag.Num && b.O is string) return a.D == ToNum(b);
                if (a.O is string && b.O == Tag.Num) return ToNum(a) == b.D;
                if (a.IsBool) { a = a.D; continue; }
                if (b.IsBool) { b = b.D; continue; }
                if (a.O is JsObject) { a = ToPrimitive(a, false); continue; }
                if (b.O is JsObject) { b = ToPrimitive(b, false); continue; }
                return false;
            }
        }
        // < > <= >=: strings by code unit, else numbers (NaN: false)
        static int Cmp(V a, V b, bool leftFirst)
        {
            // -2: undefined (NaN)
            V pa, pb;
            if (leftFirst) { pa = ToPrimitive(a, true); pb = ToPrimitive(b, true); } else { pb = ToPrimitive(b, true); pa = ToPrimitive(a, true); }
            if (pa.O is string s1 && pb.O is string s2) { int c = string.CompareOrdinal(s1, s2); return c < 0 ? -1 : c > 0 ? 1 : 0; }
            double x = ToNum(pa), y = ToNum(pb);
            if (double.IsNaN(x) || double.IsNaN(y)) return -2;
            return x < y ? -1 : x > y ? 1 : 0;
        }
        public static bool Lt(V a, V b) { if (a.O == Tag.Num && b.O == Tag.Num) return a.D < b.D; return Cmp(a, b, true) == -1; }
        public static bool Gt(V a, V b) { if (a.O == Tag.Num && b.O == Tag.Num) return a.D > b.D; return Cmp(a, b, true) == 1; }
        public static bool Le(V a, V b) { if (a.O == Tag.Num && b.O == Tag.Num) return a.D <= b.D; int c = Cmp(a, b, true); return c == -1 || c == 0; }
        public static bool Ge(V a, V b) { if (a.O == Tag.Num && b.O == Tag.Num) return a.D >= b.D; int c = Cmp(a, b, true); return c == 1 || c == 0; }
        public static bool LtN(V a, double b) => a.O == Tag.Num ? a.D < b : Lt(a, b);
        public static bool GtN(V a, double b) => a.O == Tag.Num ? a.D > b : Gt(a, b);
        public static bool LeN(V a, double b) => a.O == Tag.Num ? a.D <= b : Le(a, b);
        public static bool GeN(V a, double b) => a.O == Tag.Num ? a.D >= b : Ge(a, b);

        public static string Typeof(V v)
        {
            var o = v.O;
            if (o == Tag.Num) return "number";
            if (o is string) return "string";
            if (o == null) return "undefined";
            if (o == Tag.True || o == Tag.False) return "boolean";
            if (o == Tag.Null) return "object";
            return o is JsFunction ? "function" : "object";
        }
        public static bool InstanceOf(V o, V f)
        {
            if (!(f.O is JsFunction fn)) throw TypeErr("Right-hand side of 'instanceof' is not callable");
            if (!(o.O is JsObject obj)) return false;
            var p = fn.Get("prototype", f).O as JsObject;
            for (var q = obj.Proto; q != null; q = q.Proto) if (q == p) return true;
            return false;
        }
        public static bool HasProperty(V obj, V key)
        {
            if (!(obj.O is JsObject o)) throw TypeErr("Cannot use 'in' operator to search for '" + ToStr(key) + "' in " + ToStr(obj));
            var k = ToKey(key);
            for (var q = o; q != null; q = q.Proto) if (q.HasOwn(k)) return true;
            return false;
        }

        public static double Pow(double x, double y)
        {
            if (double.IsNaN(y)) return double.NaN;
            if (y == 0) return 1;
            if ((x == 1 || x == -1) && double.IsInfinity(y)) return double.NaN;
            return FdLibm.Pow(x, y);
        }
        public static double Round(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return x;
            double r = Math.Floor(x);
            if (x - r >= 0.5) r += 1;
            if (r == 0 && (x < 0 || double.IsNegative(x))) return -0.0;
            return r;
        }
        public static double Sign(double x) => double.IsNaN(x) ? double.NaN : x > 0 ? 1 : x < 0 ? -1 : x;
        // V8's Math.hypot (math.tq): the largest magnitude out, Kahan-summed squares of the ratios
        public static double Hypot(double a, double b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            if (double.IsInfinity(a) || double.IsInfinity(b)) return double.PositiveInfinity;
            if (double.IsNaN(a) || double.IsNaN(b)) return double.NaN;
            double max = Math.Max(a, b);
            if (max == 0) return 0;
            double sum = 0, comp = 0;
            double n = a / max, s = n * n - comp, p = sum + s; comp = (p - sum) - s; sum = p;
            n = b / max; s = n * n - comp; p = sum + s; comp = (p - sum) - s; sum = p;
            return Math.Sqrt(sum) * max;
        }
        public static double Hypot(double a) => Math.Abs(a);
        public static double Hypot(params double[] v)
        {
            double max = 0; bool nan = false;
            for (int i = 0; i < v.Length; i++) { double x = Math.Abs(v[i]); if (double.IsInfinity(x)) return double.PositiveInfinity; if (double.IsNaN(x)) nan = true; else if (x > max) max = x; }
            if (nan) return double.NaN;
            if (max == 0) return 0;
            double sum = 0, comp = 0;
            for (int i = 0; i < v.Length; i++) { double n = Math.Abs(v[i]) / max, s = n * n - comp, p = sum + s; comp = (p - sum) - s; sum = p; }
            return Math.Sqrt(sum) * max;
        }
        public static double Min() => double.PositiveInfinity;
        public static double Max() => double.NegativeInfinity;
        public static double Min(double a) => a;
        public static double Max(double a) => a;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double a, double b)
        {
            if (a < b) return a; if (b < a) return b;
            if (double.IsNaN(a) || double.IsNaN(b)) return double.NaN;
            return a == 0 && double.IsNegative(b) ? b : a;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double a, double b)
        {
            if (a > b) return a; if (b > a) return b;
            if (double.IsNaN(a) || double.IsNaN(b)) return double.NaN;
            return a == 0 && double.IsNegative(a) ? b : a;
        }
        public static double Min(double a, double b, double c) { double m = Min(a, b); m = Min(m, c); return double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) ? double.NaN : m; }
        public static double Max(double a, double b, double c) { double m = Max(a, b); m = Max(m, c); return double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) ? double.NaN : m; }
        public static double Min(params double[] v) { double m = double.PositiveInfinity; foreach (var x in v) { if (double.IsNaN(x)) return double.NaN; m = Min(m, x); } return m; }
        public static double Max(params double[] v) { double m = double.NegativeInfinity; foreach (var x in v) { if (double.IsNaN(x)) return double.NaN; m = Max(m, x); } return m; }

        public static double PreInc(ref V x, double d) { double n = ToNum(x) + d; x = n; return n; }
        public static double PostInc(ref V x, double d) { double o = ToNum(x); x = o + d; return o; }
        public static double IncM(V o, string k, double d, bool prefix) { double old = ToNum(Get(o, k)); Set(o, k, old + d); return prefix ? old + d : old; }
        public static double IncK(V o, V k, double d, bool prefix) { var key = KeyV(k); double old = ToNum(GetK(o, key)); SetK(o, key, old + d); return prefix ? old + d : old; }
        static V KeyV(V k) => k.O == Tag.Num || k.O is string ? k : (V)ToKey(k);
        public static double GInc(string name, double d, bool prefix) { double old = ToNum(G(name)); GSet(name, old + d); return prefix ? old + d : old; }

        public static V BinOp(int op, V a, V b)
        {
            switch (op)
            {
                case 0: return Add(a, b);
                case 1: return ToNum(a) - ToNum(b);
                case 2: return ToNum(a) * ToNum(b);
                case 3: return ToNum(a) / ToNum(b);
                case 4: return ToNum(a) % ToNum(b);
                case 5: return (double)(ToInt32(ToNum(a)) | ToInt32(ToNum(b)));
                case 6: return (double)(ToInt32(ToNum(a)) & ToInt32(ToNum(b)));
                case 7: return (double)(ToInt32(ToNum(a)) ^ ToInt32(ToNum(b)));
                case 8: return (double)(ToInt32(ToNum(a)) << (int)(ToUint32(ToNum(b)) & 31));
                case 9: return (double)(ToInt32(ToNum(a)) >> (int)(ToUint32(ToNum(b)) & 31));
                case 10: return (double)(ToUint32(ToNum(a)) >> (int)(ToUint32(ToNum(b)) & 31));
                default: return Pow(ToNum(a), ToNum(b));
            }
        }
        public static V OpSet(V o, string k, int op, V rhs) { var r = BinOp(op, Get(o, k), rhs); Set(o, k, r); return r; }
        public static V OpSetK(V o, V k, int op, V rhs) { var key = KeyV(k); var r = BinOp(op, GetK(o, key), rhs); SetK(o, key, r); return r; }

        // ------------------------------------------------------------------ errors
        public static Exception Throw(V v) => new JsThrow(v);
        public static JsObject MakeError(string name, string msg)
        {
            var ctor = Global != null ? Global.Get(name).O as JsFunction : null;
            var proto = ctor != null ? ctor.Get("prototype").O as JsObject : ErrorProto;
            var e = new JsObject(proto ?? ErrorProto);
            e.Put("message", msg, 1);
            e.Put("stack", name + ": " + msg, 1);
            return e;
        }
        public static Exception TypeErr(string msg) => new JsThrow(MakeError("TypeError", msg));
        public static Exception RefErr(string msg) => new JsThrow(MakeError("ReferenceError", msg));
        public static V Caught(Exception e)
        {
            if (e is JsThrow t) return t.Value;
            HostErrors++;
            OnHostError?.Invoke(e);
            if (e is StackOverflowException || e is InsufficientExecutionStackException) return MakeError("RangeError", "Maximum call stack size exceeded");
            return MakeError("Error", "(host) " + e.GetType().Name + ": " + e.Message);
        }

        // ------------------------------------------------------------------ properties
        public static V Get(V o, string k)
        {
            if (o.O is JsObject jo) return jo.Get(k, o);
            if (o.O is string s)
            {
                if (k.Length == 6 && k == "length") return s.Length;
                if (k.Length > 0 && k[0] >= '0' && k[0] <= '9' && IsIndexKey(k)) { int i = int.Parse(k, CultureInfo.InvariantCulture); return i < s.Length ? (V)CharStr(s[i]) : default; }
                return StringProto.Get(k, o);
            }
            if (o.O == Tag.Num) return NumberProto.Get(k, o);
            if (o.O == Tag.True || o.O == Tag.False) return BooleanProto.Get(k, o);
            throw TypeErr("Cannot read properties of " + (o.IsUndef ? "undefined" : "null") + " (reading '" + k + "')");
        }
        static readonly string[] Chars = MakeChars();
        static string[] MakeChars() { var a = new string[128]; for (int i = 0; i < 128; i++) a[i] = ((char)i).ToString(); return a; }
        public static string CharStr(char c) => c < 128 ? Chars[c] : c.ToString();
        public static V GetK(V o, V k)
        {
            if (k.O == Tag.Num) return GetIdx(o, k.D);
            if (k.O is string s) return Get(o, s);
            if (o.IsNullish) throw TypeErr("Cannot read properties of " + (o.IsUndef ? "undefined" : "null") + " (reading '" + ToStr(k) + "')");
            return Get(o, ToKey(k));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V GetIdx(V o, double d)
        {
            if (o.O is JsArray a) { int i = (int)d; if (i == d && (uint)i < (uint)a.Len) { var v = a.A[i]; if (v.O != Tag.Hole) return v; } }
            return GetIdxSlow(o, d);
        }
        static V GetIdxSlow(V o, double d)
        {
            if (o.O is JsTypedArray ta) { int i = (int)d; if (i == d && i >= 0) return i < ta.Length ? ta.GetAt(i) : default; }
            if (o.O is string s) { int i = (int)d; if (i == d && i >= 0) return i < s.Length ? (V)CharStr(s[i]) : default; }
            if (o.IsNullish) throw TypeErr("Cannot read properties of " + (o.IsUndef ? "undefined" : "null") + " (reading '" + NumKey(d) + "')");
            return Get(o, NumKey(d));
        }
        public static V Set(V o, string k, V v)
        {
            if (o.O is JsObject jo) { jo.Set(k, v); return v; }
            if (o.IsNullish) throw TypeErr("Cannot set properties of " + (o.IsUndef ? "undefined" : "null") + " (setting '" + k + "')");
            return v;   // (a primitive: ignored, as sloppy JS does)
        }
        public static V SetK(V o, V k, V v)
        {
            if (k.O == Tag.Num) return SetIdx(o, k.D, v);
            return Set(o, k.O is string s ? s : ToKey(k), v);
        }
        public static V SetIdx(V o, double d, V v)
        {
            if (o.O is JsArray a) { int i = (int)d; if (i == d && i >= 0) { a.SetAt(i, v); return v; } }
            else if (o.O is JsTypedArray ta) { int i = (int)d; if (i == d && i >= 0) { if (i < ta.Length) ta.SetAt(i, ToNum(v)); return v; } }
            return Set(o, NumKey(d), v);
        }
        public static bool Delete(V o, string k) { if (o.O is JsObject jo) return jo.Delete(k); if (o.IsNullish) throw TypeErr("Cannot convert undefined or null to object"); return true; }
        public static bool DeleteK(V o, V k) => Delete(o, ToKey(k));

        // ------------------------------------------------------------------ globals
        public static V G(string name)
        {
            for (var o = Global; o != null; o = o.Proto)
            {
                int i = o.Find(name);
                if (i >= 0) return (o.FlagsAt(i) & 2) != 0 ? o.Get(name, GlobalV) : o.Vs[i];
            }
            throw RefErr(name + " is not defined");
        }
        public static V GSet(string name, V v) { Global.Set(name, v); return v; }
        public static void GDecl(string name) { if (!Global.HasOwn(name)) Global.Put(name, default, 0); }
        public static string GTypeof(string name)
        {
            for (var o = Global; o != null; o = o.Proto) if (o.HasOwn(name)) return Typeof(o.Get(name, GlobalV));
            return "undefined";
        }

        // ------------------------------------------------------------------ functions
        public static V Fn(JsFn f, int arity, string name, bool arrow) => new V(new JsFunction(f, arity, name, arrow), 0);
        public static V Named(Func<Box, V> make) { var b = new Box(); var f = make(b); b.v = f; return f; }
        public static ClassBuilder ClassOf(V ctor) => new ClassBuilder((JsFunction)ctor.O);
        public static JsObject NewObj(int n) => new JsObject(ObjectProto, n);
        public static V Arr() => new V(new JsArray(), 0);
        public static V Arr(params V[] items) => new V(new JsArray(items), 0);
        public static V ArrHoles(params V[] items) => new V(new JsArray(items), 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static JsFunction FnOf(V f) => f.O as JsFunction ?? throw TypeErr(ToStrSafe(f) + " is not a function");
        static JsFunction FnOf(V f, string what) => f.O as JsFunction ?? throw TypeErr(what + " is not a function");
        public static V Call(V f, V self) => FnOf(f).Fn(self, 0, default, default, default, default, null);
        public static V Call(V f, V self, V a) => FnOf(f).Fn(self, 1, a, default, default, default, null);
        public static V Call(V f, V self, V a, V b) => FnOf(f).Fn(self, 2, a, b, default, default, null);
        public static V Call(V f, V self, V a, V b, V c) => FnOf(f).Fn(self, 3, a, b, c, default, null);
        public static V Call(V f, V self, V a, V b, V c, V d) => FnOf(f).Fn(self, 4, a, b, c, d, null);
        public static V Call(V f, V self, V a, V b, V c, V d, V e) => FnOf(f).Fn(self, 5, a, b, c, d, new[] { e });
        public static V Call(V f, V self, V a, V b, V c, V d, V e, V g) => FnOf(f).Fn(self, 6, a, b, c, d, new[] { e, g });
        public static V Call(V f, V self, V a, V b, V c, V d, V e, V g, V h) => FnOf(f).Fn(self, 7, a, b, c, d, new[] { e, g, h });
        public static V Call(V f, V self, V a, V b, V c, V d, V e, V g, V h, params V[] more)
        {
            var rest = new V[3 + more.Length]; rest[0] = e; rest[1] = g; rest[2] = h; Array.Copy(more, 0, rest, 3, more.Length);
            return FnOf(f).Fn(self, 7 + more.Length, a, b, c, d, rest);
        }
        /// <summary>Calls with the arguments in a list (spread calls, apply, Reflect).</summary>
        public static V CallList(JsFunction fn, V self, IList<V> args)
        {
            int n = args.Count;
            V a = n > 0 ? args[0] : default, b = n > 1 ? args[1] : default, c = n > 2 ? args[2] : default, d = n > 3 ? args[3] : default;
            V[] rest = null;
            if (n > 4) { rest = new V[n - 4]; for (int i = 4; i < n; i++) rest[i - 4] = args[i]; }
            return fn.Fn(self, n, a, b, c, d, rest);
        }
        public static V CallSpread(V f, V self, V args) => CallList(FnOf(f), self, ListArgs(args));
        static IList<V> ListArgs(V args) { var a = (JsArray)args.O; var l = new V[a.Len]; for (int i = 0; i < a.Len; i++) l[i] = a.At(i); return l; }

        static JsFunction MethodOf(V o, string k)
        {
            var f = Get(o, k);
            if (f.O is JsFunction fn) return fn;
            throw TypeErr((o.O is JsObject ? "" : Typeof(o) + " ") + "." + k + " is not a function");
        }
        public static V Invoke(V o, string k) => MethodOf(o, k).Fn(o, 0, default, default, default, default, null);
        public static V Invoke(V o, string k, V a) => MethodOf(o, k).Fn(o, 1, a, default, default, default, null);
        public static V Invoke(V o, string k, V a, V b) => MethodOf(o, k).Fn(o, 2, a, b, default, default, null);
        public static V Invoke(V o, string k, V a, V b, V c) => MethodOf(o, k).Fn(o, 3, a, b, c, default, null);
        public static V Invoke(V o, string k, V a, V b, V c, V d) => MethodOf(o, k).Fn(o, 4, a, b, c, d, null);
        public static V Invoke(V o, string k, V a, V b, V c, V d, V e) => MethodOf(o, k).Fn(o, 5, a, b, c, d, new[] { e });
        public static V Invoke(V o, string k, V a, V b, V c, V d, V e, V g) => MethodOf(o, k).Fn(o, 6, a, b, c, d, new[] { e, g });
        public static V Invoke(V o, string k, V a, V b, V c, V d, V e, V g, params V[] more)
        {
            var rest = new V[2 + more.Length]; rest[0] = e; rest[1] = g; Array.Copy(more, 0, rest, 2, more.Length);
            return MethodOf(o, k).Fn(o, 6 + more.Length, a, b, c, d, rest);
        }
        public static V InvokeK(V o, V k) => Invoke(o, ToKey(k));
        public static V InvokeK(V o, V k, V a) => Invoke(o, ToKey(k), a);
        public static V InvokeK(V o, V k, V a, V b) => Invoke(o, ToKey(k), a, b);
        public static V InvokeK(V o, V k, V a, V b, V c) => Invoke(o, ToKey(k), a, b, c);
        public static V InvokeK(V o, V k, V a, V b, V c, V d) => Invoke(o, ToKey(k), a, b, c, d);
        public static V InvokeK(V o, V k, V a, V b, V c, V d, V e, params V[] more) { var l = new List<V> { a, b, c, d, e }; l.AddRange(more); return CallList(MethodOf(o, ToKey(k)), o, l); }
        public static V InvokeSpread(V o, string k, V args) => CallList(MethodOf(o, k), o, ListArgs(args));
        public static V InvokeSpreadK(V o, V k, V args) => InvokeSpread(o, ToKey(k), args);

        public static V NewList(V f, IList<V> args)
        {
            if (!(f.O is JsFunction fn) || fn.Arrow) throw TypeErr(ToStrSafe(f) + " is not a constructor");
            int n = args.Count;
            V a = n > 0 ? args[0] : default, b = n > 1 ? args[1] : default, c = n > 2 ? args[2] : default, d = n > 3 ? args[3] : default;
            V[] rest = null;
            if (n > 4) { rest = new V[n - 4]; for (int i = 4; i < n; i++) rest[i - 4] = args[i]; }
            if (fn.Ctor != null) return fn.Ctor(fn, n, a, b, c, d, rest);
            var proto = fn.Get("prototype", f).O as JsObject ?? ObjectProto;
            var obj = new JsObject(proto);
            var r = fn.Fn(obj.V, n, a, b, c, d, rest);
            return r.O is JsObject ? r : obj.V;
        }
        static string ToStrSafe(V v) { try { return v.O is JsObject ? Typeof(v) : ToStr(v); } catch (Exception) { return "value"; } }
        public static V New(V f) => NewList(f, Array.Empty<V>());
        public static V New(V f, V a) => NewList(f, new[] { a });
        public static V New(V f, V a, V b) => NewList(f, new[] { a, b });
        public static V New(V f, V a, V b, V c) => NewList(f, new[] { a, b, c });
        public static V New(V f, V a, V b, V c, V d, params V[] more) { var l = new List<V> { a, b, c, d }; l.AddRange(more); return NewList(f, l); }
        public static V NewSpread(V f, V args) => NewList(f, ListArgs(args));

        public static V Arguments(int argc, V a0, V a1, V a2, V a3, V[] rest) => RestArgs(0, argc, a0, a1, a2, a3, rest);
        public static V RestArgs(int from, int argc, V a0, V a1, V a2, V a3, V[] rest)
        {
            var arr = new JsArray(Math.Max(0, argc - from));
            for (int i = from; i < argc; i++) arr.Push(i == 0 ? a0 : i == 1 ? a1 : i == 2 ? a2 : i == 3 ? a3 : rest[i - 4]);
            return arr.V;
        }
        /// <summary>A native function's i-th argument.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V Arg(int i, int argc, V a0, V a1, V a2, V a3, V[] rest) => i >= argc ? default : i == 0 ? a0 : i == 1 ? a1 : i == 2 ? a2 : i == 3 ? a3 : rest[i - 4];

        // ------------------------------------------------------------------ iteration, destructuring
        static readonly V[] NoKeys = new V[0];
        /// <summary>for-in's keys: own enumerable ones (indexes first), then the prototypes' not shadowed.</summary>
        public static V[] ForInKeys(V v)
        {
            if (v.IsNullish) return NoKeys;
            if (v.O is string s) { var r = new V[s.Length]; for (int i = 0; i < s.Length; i++) r[i] = IndexKey(i); return r; }
            if (!(v.O is JsObject o)) return NoKeys;
            bool protoKeys = false;
            for (var q = o.Proto; q != null && !protoKeys; q = q.Proto) protoKeys = q.HasEnumerable();
            var own = o.OwnKeys(true);
            if (!protoKeys)
            {
                var r = new V[own.Count];
                for (int i = 0; i < r.Length; i++) r[i] = own[i];
                return r;
            }
            var seen = new List<string>(o.OwnKeys(false));
            var res = new List<V>(own.Count + 4);
            foreach (var k in own) res.Add(k);
            for (var q = o.Proto; q != null; q = q.Proto)
            {
                var en = q.OwnKeys(true);
                foreach (var k in q.OwnKeys(false))
                {
                    if (seen.Contains(k)) continue;
                    seen.Add(k);
                    if (en.Contains(k)) res.Add(k);
                }
            }
            return res.ToArray();
        }
        public static IEnumerable<V> Iterate(V v)
        {
            if (v.O is JsArray a) { for (int i = 0; i < a.Len; i++) yield return a.At(i); yield break; }
            if (v.O is string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsHighSurrogate(s[i]) && i + 1 < s.Length && char.IsLowSurrogate(s[i + 1])) { yield return s.Substring(i, 2); i++; }
                    else yield return CharStr(s[i]);
                }
                yield break;
            }
            // (a Set first: JsSet is a JsMap, whose iteration is its [key, value] entries; a Set's is its values)
            if (v.O is JsSet st) { foreach (var e in st.Values()) yield return e; yield break; }
            if (v.O is JsMap m) { foreach (var e in m.Entries()) yield return e; yield break; }
            if (v.O is JsTypedArray ta) { for (int i = 0; i < ta.Length; i++) yield return ta.GetAt(i); yield break; }
            if (v.O is JsIterator it) { while (it.Next(out var x)) yield return x; yield break; }
            throw TypeErr(ToStrSafe(v) + " is not iterable");
        }
        public static V ListOf(V v)
        {
            if (v.O is JsArray) return v;
            var arr = new JsArray();
            foreach (var x in Iterate(v)) arr.Push(x);
            return arr.V;
        }
        public static V RestFrom(V list, int from)
        {
            var a = (JsArray)list.O; var r = new JsArray(Math.Max(0, a.Len - from));
            for (int i = from; i < a.Len; i++) r.Push(a.At(i));
            return r.V;
        }
        public static V ObjRest(V src, string[] excluded)
        {
            var r = NewObj(4);
            if (src.O is JsObject o) foreach (var k in o.OwnKeys(true)) if (Array.IndexOf(excluded, k) < 0) r.Put(k, o.Get(k, src), 0);
            return r.V;
        }
    }
}
