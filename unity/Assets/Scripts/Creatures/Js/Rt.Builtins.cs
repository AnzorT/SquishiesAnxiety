// The JS built-ins the rig code and the browser stand-in use: Object, Function, Array, String, Number, Boolean, Math,
// JSON, Date, RegExp, the Errors, Map, Set, Promise, the typed arrays and the global functions, made once (Rt.Init).
// Behaviour as ECMAScript's (and V8's where the spec leaves it open: a stable sort, Math.hypot's summation...).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SquishSquad.Creatures.Js
{
    public static partial class Rt
    {
        static JsFunction Native(string name, int arity, JsFn fn) => new JsFunction(fn, arity, name, false, true);
        static JsFunction Def(JsObject o, string name, int arity, JsFn fn) { var f = Native(name, arity, fn); o.Put(name, f.V, 1); return f; }
        static void DefGet(JsObject o, string name, JsFn fn) => o.PutAccessor(name, Native("get " + name, 0, fn).V, default, false);
        static JsFunction Ctor(string name, int arity, JsFn call, JsObject proto, Func<JsFunction, int, V, V, V, V, V[], V> ctor)
        {
            var f = new JsFunction(call, arity, name, false, true) { Ctor = ctor };
            f.Put("prototype", proto.V, 1);
            proto.Put("constructor", f.V, 1);
            Global.Put(name, f.V, 1);
            return f;
        }
        static System.Random _rand = new System.Random(1);

        static void Init()
        {
            ObjectProto = new JsObject(null);
            FunctionProto = new JsObject(ObjectProto);
            ArrayProto = new JsObject(ObjectProto);
            StringProto = new JsObject(ObjectProto);
            NumberProto = new JsObject(ObjectProto);
            BooleanProto = new JsObject(ObjectProto);
            ErrorProto = new JsObject(ObjectProto);
            RegExpProto = new JsObject(ObjectProto);
            IteratorProto = new JsObject(ObjectProto);
            PromiseProto = new JsObject(ObjectProto);
            MapProto = new JsObject(ObjectProto);
            SetProto = new JsObject(ObjectProto);
            Global = new JsObject(ObjectProto);
            GlobalV = Global.V;
            Global.Put("globalThis", GlobalV, 1);
            Global.Put("undefined", default, 5);
            Global.Put("NaN", double.NaN, 5);
            Global.Put("Infinity", double.PositiveInfinity, 5);

            InitObject(); InitFunction(); InitArray(); InitString(); InitNumber(); InitMath(); InitJson(); InitDate();
            InitRegExp(); InitErrors(); InitCollections(); InitPromise(); InitTyped(); InitGlobals();
        }

        // ------------------------------------------------------------------ Object
        static JsObject ToObj(V v, string what)
        {
            if (v.O is JsObject o) return o;
            if (v.IsNullish) throw TypeErr("Cannot convert undefined or null to object");
            return null;
        }
        public static V Object_keys(V o)
        {
            var a = new JsArray();
            if (o.O is string s) { for (int i = 0; i < s.Length; i++) a.Push(IndexKey(i)); return a.V; }
            var obj = ToObj(o, "keys");
            if (obj != null) foreach (var k in obj.OwnKeys(true)) a.Push(k);
            return a.V;
        }
        public static V Object_values(V o)
        {
            var a = new JsArray(); var obj = ToObj(o, "values");
            if (obj != null) foreach (var k in obj.OwnKeys(true)) a.Push(obj.Get(k, o));
            return a.V;
        }
        public static V Object_entries(V o)
        {
            var a = new JsArray(); var obj = ToObj(o, "entries");
            if (obj != null) foreach (var k in obj.OwnKeys(true)) a.Push(Arr(k, obj.Get(k, o)));
            return a.V;
        }
        public static V Object_assign(V target, params V[] sources)
        {
            var t = ToObj(target, "assign");
            foreach (var src in sources)
            {
                if (src.O is JsObject so) foreach (var k in so.OwnKeys(true)) t.Set(k, so.Get(k, src));
                else if (src.O is string s) for (int i = 0; i < s.Length; i++) t.Set(IndexKey(i), CharStr(s[i]));
            }
            return target;
        }
        public static V Object_create(V proto) => Object_create(proto, default);
        public static V Object_create(V proto, V props)
        {
            if (!(proto.O is JsObject) && proto.O != Tag.Null) throw TypeErr("Object prototype may only be an Object or null");
            var o = new JsObject(proto.O as JsObject);
            if (props.O is JsObject p) foreach (var k in p.OwnKeys(true)) DefineOwn(o, k, p.Get(k, props));
            return o.V;
        }
        static void DefineOwn(JsObject o, string k, V descV)
        {
            if (!(descV.O is JsObject desc)) throw TypeErr("Property description must be an object");
            bool has(string n) { for (var q = desc; q != null; q = q.Proto) if (q.HasOwn(n)) return true; return false; }
            var get = desc.Get("get", descV); var set = desc.Get("set", descV);
            int i = o.Find(k);
            bool exists = i >= 0;
            byte old = exists ? o.FlagsAt(i) : (byte)(1 | 4);
            bool enumerable = has("enumerable") ? Truthy(desc.Get("enumerable", descV)) : (old & 1) == 0;
            if (has("get") || has("set"))
            {
                if (exists && (old & 2) == 0) o.RemoveSlot(i);
                o.PutAccessor(k, get, set, enumerable);
                return;
            }
            bool writable = has("writable") ? Truthy(desc.Get("writable", descV)) : (exists && (old & 4) == 0 && (old & 2) == 0);
            V val = has("value") ? desc.Get("value", descV) : exists && (old & 2) == 0 ? o.Vs[i] : default;
            if (exists && (old & 2) != 0) o.RemoveSlot(i);
            if (o is JsArray arr && (k == "length" || IsIndexKey(k))) { arr.Set(k, val); return; }
            o.Put(k, val, (byte)((enumerable ? 0 : 1) | (writable ? 0 : 4)));
        }
        public static V Object_defineProperty(V o, V k, V desc)
        {
            if (!(o.O is JsObject obj)) throw TypeErr("Object.defineProperty called on non-object");
            DefineOwn(obj, ToKey(k), desc);
            return o;
        }
        public static V Object_getPrototypeOf(V o)
        {
            if (o.O is JsObject obj) return obj.Proto != null ? obj.Proto.V : V.Null;
            if (o.O is string) return StringProto.V;
            if (o.O == Tag.Num) return NumberProto.V;
            if (o.IsBool) return BooleanProto.V;
            throw TypeErr("Cannot convert undefined or null to object");
        }
        public static V Object_setPrototypeOf(V o, V p) { if (o.O is JsObject obj) obj.Proto = p.O as JsObject; return o; }
        public static V Object_freeze(V o) { if (o.O is JsObject obj) { obj.Extensible = false; for (int i = 0; i < obj.N; i++) { if (obj.F == null) obj.F = new byte[obj.K.Length]; obj.F[i] |= 4; } } return o; }
        public static V Object_getOwnPropertyNames(V o) { var a = new JsArray(); var obj = ToObj(o, "names"); if (obj != null) foreach (var k in obj.OwnKeys(false)) a.Push(k); return a.V; }
        public static V Object_fromEntries(V it)
        {
            var o = NewObj(4);
            foreach (var e in Iterate(it)) o.Put(ToKey(GetIdx(e, 0)), GetIdx(e, 1), 0);
            return o.V;
        }
        static void InitObject()
        {
            var P = ObjectProto;
            var ctor = Ctor("Object", 1, (s, n, a, b, c, d, r) => n == 0 || a.IsNullish ? NewObj(0).V : a, P,
                (f, n, a, b, c, d, r) => n == 0 || a.IsNullish ? NewObj(0).V : a);
            Def(ctor, "keys", 1, (s, n, a, b, c, d, r) => Object_keys(a));
            Def(ctor, "values", 1, (s, n, a, b, c, d, r) => Object_values(a));
            Def(ctor, "entries", 1, (s, n, a, b, c, d, r) => Object_entries(a));
            Def(ctor, "assign", 2, (s, n, a, b, c, d, r) => { var l = new List<V>(); for (int i = 1; i < n; i++) l.Add(Arg(i, n, a, b, c, d, r)); return Object_assign(a, l.ToArray()); });
            Def(ctor, "create", 2, (s, n, a, b, c, d, r) => Object_create(a, b));
            Def(ctor, "defineProperty", 3, (s, n, a, b, c, d, r) => Object_defineProperty(a, b, c));
            Def(ctor, "defineProperties", 2, (s, n, a, b, c, d, r) => { if (a.O is JsObject o && b.O is JsObject p) foreach (var k in p.OwnKeys(true)) DefineOwn(o, k, p.Get(k, b)); return a; });
            Def(ctor, "getPrototypeOf", 1, (s, n, a, b, c, d, r) => Object_getPrototypeOf(a));
            Def(ctor, "setPrototypeOf", 2, (s, n, a, b, c, d, r) => Object_setPrototypeOf(a, b));
            Def(ctor, "freeze", 1, (s, n, a, b, c, d, r) => Object_freeze(a));
            Def(ctor, "isFrozen", 1, (s, n, a, b, c, d, r) => a.O is JsObject o ? !o.Extensible : true);
            Def(ctor, "getOwnPropertyNames", 1, (s, n, a, b, c, d, r) => Object_getOwnPropertyNames(a));
            Def(ctor, "fromEntries", 1, (s, n, a, b, c, d, r) => Object_fromEntries(a));
            Def(ctor, "is", 2, (s, n, a, b, c, d, r) => a.O == Tag.Num && b.O == Tag.Num ? (a.D.Equals(b.D) && double.IsNegative(a.D) == double.IsNegative(b.D)) || (double.IsNaN(a.D) && double.IsNaN(b.D)) : SEq(a, b));
            Def(ctor, "getOwnPropertyDescriptor", 2, (s, n, a, b, c, d, r) =>
            {
                if (!(a.O is JsObject o)) return default;
                string k = ToKey(b); int i = o.Find(k);
                if (i < 0) { if (o.GetOwn(k, out var sv)) return NewObj(4).Put("value", sv).Put("writable", true).Put("enumerable", true).Put("configurable", true).V; return default; }
                byte f = o.FlagsAt(i);
                if ((f & 2) != 0) { var acc = (Accessor)o.Vs[i].O; return NewObj(4).Put("get", acc.Get).Put("set", acc.Set).Put("enumerable", (f & 1) == 0).Put("configurable", true).V; }
                return NewObj(4).Put("value", o.Vs[i]).Put("writable", (f & 4) == 0).Put("enumerable", (f & 1) == 0).Put("configurable", true).V;
            });
            Def(P, "hasOwnProperty", 1, (s, n, a, b, c, d, r) =>
            {
                string k = ToKey(a);
                if (s.O is JsObject o) return o.HasOwn(k);
                if (s.O is string str) return k == "length" || (IsIndexKey(k) && int.Parse(k) < str.Length);
                return false;
            });
            Def(P, "isPrototypeOf", 1, (s, n, a, b, c, d, r) => { if (!(a.O is JsObject o) || !(s.O is JsObject me)) return false; for (var q = o.Proto; q != null; q = q.Proto) if (q == me) return true; return false; });
            Def(P, "propertyIsEnumerable", 1, (s, n, a, b, c, d, r) => { if (!(s.O is JsObject o)) return false; var k = ToKey(a); int i = o.Find(k); return i >= 0 ? (o.FlagsAt(i) & 1) == 0 : o.HasOwn(k); });
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => "[object " + (s.IsUndef ? "Undefined" : s.O == Tag.Null ? "Null" : s.O is JsObject o ? (o is JsFunction ? "Function" : o is JsArray ? "Array" : o.ClassName == "Error" ? "Error" : "Object") : s.O is string ? "String" : s.O == Tag.Num ? "Number" : "Boolean") + "]");
            Def(P, "toLocaleString", 0, (s, n, a, b, c, d, r) => Invoke(s, "toString"));
            Def(P, "valueOf", 0, (s, n, a, b, c, d, r) => s);
        }

        // ------------------------------------------------------------------ Function
        static void InitFunction()
        {
            var P = FunctionProto;
            Ctor("Function", 1, (s, n, a, b, c, d, r) => throw TypeErr("Function() is not supported"), P, (f, n, a, b, c, d, r) => throw TypeErr("Function() is not supported"));
            Def(P, "call", 1, (s, n, a, b, c, d, r) =>
            {
                var fn = FnOf(s, "call");
                if (n <= 1) return fn.Fn(a, 0, default, default, default, default, null);
                V e4 = n > 4 ? r[0] : default;
                V[] rest = null;
                if (n > 5) { rest = new V[n - 5]; Array.Copy(r, 1, rest, 0, n - 5); }
                return fn.Fn(a, n - 1, b, c, d, e4, rest);
            });
            Def(P, "apply", 2, (s, n, a, b, c, d, r) =>
            {
                var fn = FnOf(s, "apply");
                if (b.IsNullish) return fn.Fn(a, 0, default, default, default, default, null);
                return CallList(fn, a, ArrayLike(b));
            });
            Def(P, "bind", 1, (s, n, a, b, c, d, r) =>
            {
                var fn = FnOf(s, "bind");
                var bound = new List<V>();
                for (int i = 1; i < n; i++) bound.Add(Arg(i, n, a, b, c, d, r));
                V self = a;
                var bf = new JsFunction((s2, n2, a2, b2, c2, d2, r2) =>
                {
                    var l = new List<V>(bound);
                    for (int i = 0; i < n2; i++) l.Add(Arg(i, n2, a2, b2, c2, d2, r2));
                    return CallList(fn, self, l);
                }, Math.Max(0, fn.Arity - bound.Count), "bound " + fn.Name, false, true);
                if (fn.Ctor != null || !fn.Arrow) bf.Ctor = (f2, n2, a2, b2, c2, d2, r2) =>
                {
                    var l = new List<V>(bound);
                    for (int i = 0; i < n2; i++) l.Add(Arg(i, n2, a2, b2, c2, d2, r2));
                    return NewList(fn.V, l);
                };
                return bf.V;
            });
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => "function " + (s.O is JsFunction f ? f.Name : "") + "() { [native code] }");
        }
        /// <summary>An array or array-like ({ length, 0, 1... }) as a list.</summary>
        internal static IList<V> ArrayLike(V v)
        {
            if (v.O is JsArray a) { var l = new V[a.Len]; for (int i = 0; i < a.Len; i++) l[i] = a.At(i); return l; }
            if (v.O is JsObject o)
            {
                int len = (int)ToUint32(ToNum(o.Get("length", v)));
                var l = new V[len]; for (int i = 0; i < len; i++) l[i] = GetIdx(v, i); return l;
            }
            if (v.O is string s) { var l = new V[s.Length]; for (int i = 0; i < s.Length; i++) l[i] = CharStr(s[i]); return l; }
            return Array.Empty<V>();
        }

        // ------------------------------------------------------------------ Array
        static JsArray ThisArr(V s, string m)
        {
            if (s.O is JsArray a) return a;
            if (s.O is JsObject || s.O is string) return new JsArray(ArrayLike(s) is V[] l ? l : new List<V>(ArrayLike(s)).ToArray());
            throw TypeErr("Array.prototype." + m + " called on null or undefined");
        }
        static JsFunction Cb(V f, string m) => f.O as JsFunction ?? throw TypeErr(ToStrSafe(f) + " is not a function");
        static int RelIndex(V v, int len, int dflt)
        {
            if (v.IsUndef) return dflt;
            double d = ToNum(v);
            if (double.IsNaN(d)) d = 0;
            d = Math.Truncate(d);
            if (d < 0) return (int)Math.Max(0, len + d);
            return (int)Math.Min(d, len);
        }
        public static V Array_from(V src) => Array_from(src, default);
        public static V Array_from(V src, V mapFn)
        {
            var a = new JsArray();
            var fn = mapFn.O as JsFunction;
            IEnumerable<V> items;
            if (src.O is JsArray || src.O is string || src.O is JsMap || src.O is JsIterator || src.O is JsTypedArray) items = Iterate(src);
            else if (src.IsNullish) throw TypeErr("Cannot convert undefined or null to object");
            else items = ArrayLike(src);
            int i = 0;
            foreach (var x in items) { a.Push(fn != null ? fn.Fn(default, 2, x, i, default, default, null) : x); i++; }
            return a.V;
        }
        public static V Array_of(params V[] items) => new JsArray((V[])items.Clone()).V;
        static void InitArray()
        {
            var P = ArrayProto;
            var ctor = Ctor("Array", 1, (s, n, a, b, c, d, r) => MakeArray(n, a, b, c, d, r), P, (f, n, a, b, c, d, r) => MakeArray(n, a, b, c, d, r));
            Def(ctor, "isArray", 1, (s, n, a, b, c, d, r) => a.O is JsArray);
            Def(ctor, "from", 1, (s, n, a, b, c, d, r) => Array_from(a, b));
            Def(ctor, "of", 0, (s, n, a, b, c, d, r) => { var l = new JsArray(); for (int i = 0; i < n; i++) l.Push(Arg(i, n, a, b, c, d, r)); return l.V; });
            Def(P, "push", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "push"); for (int i = 0; i < n; i++) t.Push(Arg(i, n, a, b, c, d, r)); return t.Len; });
            Def(P, "pop", 0, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "pop"); if (t.Len == 0) return default; var v = t.At(t.Len - 1); t.SetLength(t.Len - 1); return v; });
            Def(P, "shift", 0, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "shift"); if (t.Len == 0) return default; var v = t.At(0); Array.Copy(t.A, 1, t.A, 0, t.Len - 1); t.SetLength(t.Len - 1); return v; });
            Def(P, "unshift", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "unshift"); int old = t.Len;
                t.SetLength(old + n); Array.Copy(t.A, 0, t.A, n, old);
                for (int i = 0; i < n; i++) t.A[i] = Arg(i, n, a, b, c, d, r);
                return t.Len;
            });
            Def(P, "slice", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "slice"); int st = RelIndex(a, t.Len, 0), en = RelIndex(b, t.Len, t.Len);
                var o = new JsArray(Math.Max(0, en - st));
                for (int i = st; i < en; i++) { if (t.HasAt(i)) o.SetAt(i - st, t.A[i]); else o.SetLength(i - st + 1); }
                return o.V;
            });
            Def(P, "splice", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "splice"); int len = t.Len, st = RelIndex(a, len, 0);
                int del = n == 0 ? 0 : n == 1 ? len - st : (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), len - st);
                var removed = new JsArray(del);
                for (int i = 0; i < del; i++) removed.Push(t.At(st + i));
                var ins = new List<V>(); for (int i = 2; i < n; i++) ins.Add(Arg(i, n, a, b, c, d, r));
                var tail = new V[len - st - del]; Array.Copy(t.A, st + del, tail, 0, tail.Length);
                t.SetLength(st);
                foreach (var x in ins) t.Push(x);
                foreach (var x in tail) t.Push(x);
                return removed.V;
            });
            Def(P, "concat", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "concat"); var o = new JsArray(t.Len);
                for (int i = 0; i < t.Len; i++) o.Push(t.A[i]);
                for (int i = 0; i < n; i++) { var x = Arg(i, n, a, b, c, d, r); if (x.O is JsArray xa) for (int j = 0; j < xa.Len; j++) o.Push(xa.A[j]); else o.Push(x); }
                return o.V;
            });
            Def(P, "join", 1, (s, n, a, b, c, d, r) => Join(ThisArr(s, "join"), a.IsUndef ? "," : ToStr(a)));
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => s.O is JsArray t ? Join(t, ",") : (V)"[object Object]");
            Def(P, "reverse", 0, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "reverse"); Array.Reverse(t.A, 0, t.Len); return s; });
            Def(P, "indexOf", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "indexOf"); for (int i = RelIndex(b, t.Len, 0); i < t.Len; i++) if (t.HasAt(i) && SEq(t.A[i], a)) return i; return -1; });
            Def(P, "lastIndexOf", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "lastIndexOf"); int from = n > 1 ? (int)Math.Min(ToNum(b) < 0 ? t.Len + ToNum(b) : ToNum(b), t.Len - 1) : t.Len - 1; for (int i = from; i >= 0; i--) if (t.HasAt(i) && SEq(t.A[i], a)) return i; return -1; });
            Def(P, "includes", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "includes"); for (int i = RelIndex(b, t.Len, 0); i < t.Len; i++) { var x = t.At(i); if (SEq(x, a) || (x.IsNum && a.IsNum && double.IsNaN(x.D) && double.IsNaN(a.D))) return true; } return false; });
            Def(P, "find", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "find"); var f = Cb(a, "find"); for (int i = 0; i < t.Len; i++) { var x = t.At(i); if (Truthy(f.Fn(b, 3, x, i, s, default, null))) return x; } return default; });
            Def(P, "findIndex", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "findIndex"); var f = Cb(a, "findIndex"); for (int i = 0; i < t.Len; i++) if (Truthy(f.Fn(b, 3, t.At(i), i, s, default, null))) return i; return -1; });
            Def(P, "findLast", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "findLast"); var f = Cb(a, "findLast"); for (int i = t.Len - 1; i >= 0; i--) { var x = t.At(i); if (Truthy(f.Fn(b, 3, x, i, s, default, null))) return x; } return default; });
            Def(P, "findLastIndex", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "findLastIndex"); var f = Cb(a, "findLastIndex"); for (int i = t.Len - 1; i >= 0; i--) if (Truthy(f.Fn(b, 3, t.At(i), i, s, default, null))) return i; return -1; });
            Def(P, "filter", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "filter"); var f = Cb(a, "filter"); var o = new JsArray(); int len = t.Len; for (int i = 0; i < len && i < t.Len; i++) { if (!t.HasAt(i)) continue; var x = t.A[i]; if (Truthy(f.Fn(b, 3, x, i, s, default, null))) o.Push(x); } return o.V; });
            Def(P, "map", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "map"); var f = Cb(a, "map"); int len = t.Len; var o = new JsArray(len);
                for (int i = 0; i < len; i++) { if (i < t.Len && t.HasAt(i)) o.SetAt(i, f.Fn(b, 3, t.A[i], i, s, default, null)); }
                if (o.Len < len) o.SetLength(len);
                return o.V;
            });
            Def(P, "forEach", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "forEach"); var f = Cb(a, "forEach"); int len = t.Len; for (int i = 0; i < len && i < t.Len; i++) if (t.HasAt(i)) f.Fn(b, 3, t.A[i], i, s, default, null); return default; });
            Def(P, "some", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "some"); var f = Cb(a, "some"); int len = t.Len; for (int i = 0; i < len && i < t.Len; i++) if (t.HasAt(i) && Truthy(f.Fn(b, 3, t.A[i], i, s, default, null))) return true; return false; });
            Def(P, "every", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "every"); var f = Cb(a, "every"); int len = t.Len; for (int i = 0; i < len && i < t.Len; i++) if (t.HasAt(i) && !Truthy(f.Fn(b, 3, t.A[i], i, s, default, null))) return false; return true; });
            Def(P, "reduce", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "reduce"); var f = Cb(a, "reduce"); int i = 0, len = t.Len; V acc;
                if (n >= 2) acc = b;
                else { while (i < len && !t.HasAt(i)) i++; if (i >= len) throw TypeErr("Reduce of empty array with no initial value"); acc = t.A[i++]; }
                for (; i < len && i < t.Len; i++) if (t.HasAt(i)) acc = f.Fn(default, 4, acc, t.A[i], i, s, null);
                return acc;
            });
            Def(P, "reduceRight", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "reduceRight"); var f = Cb(a, "reduceRight"); int i = t.Len - 1; V acc;
                if (n >= 2) acc = b;
                else { while (i >= 0 && !t.HasAt(i)) i--; if (i < 0) throw TypeErr("Reduce of empty array with no initial value"); acc = t.A[i--]; }
                for (; i >= 0; i--) if (t.HasAt(i)) acc = f.Fn(default, 4, acc, t.A[i], i, s, null);
                return acc;
            });
            Def(P, "sort", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "sort"); SortArray(t, a.O as JsFunction); return s; });
            Def(P, "fill", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "fill"); int st = RelIndex(b, t.Len, 0), en = RelIndex(c, t.Len, t.Len); for (int i = st; i < en; i++) t.A[i] = a; return s; });
            Def(P, "flat", 0, (s, n, a, b, c, d, r) => { var o = new JsArray(); Flatten(ThisArr(s, "flat"), o, a.IsUndef ? 1 : (int)ToNum(a)); return o.V; });
            Def(P, "flatMap", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisArr(s, "flatMap"); var f = Cb(a, "flatMap"); var o = new JsArray();
                for (int i = 0; i < t.Len; i++) { if (!t.HasAt(i)) continue; var x = f.Fn(b, 3, t.A[i], i, s, default, null); if (x.O is JsArray xa) { for (int j = 0; j < xa.Len; j++) if (xa.HasAt(j)) o.Push(xa.A[j]); } else o.Push(x); }
                return o.V;
            });
            Def(P, "at", 1, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "at"); double i = Truncz(ToNum(a)); if (i < 0) i += t.Len; return i >= 0 && i < t.Len ? t.At((int)i) : default; });
            Def(P, "keys", 0, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "keys"); return new JsIterator(Count(t)).V; });
            Def(P, "values", 0, (s, n, a, b, c, d, r) => new JsIterator(Iterate(s)).V);
            Def(P, "entries", 0, (s, n, a, b, c, d, r) => { var t = ThisArr(s, "entries"); return new JsIterator(EntriesOf(t)).V; });
        }
        static IEnumerable<V> Count(JsArray t) { for (int i = 0; i < t.Len; i++) yield return i; }
        static IEnumerable<V> EntriesOf(JsArray t) { for (int i = 0; i < t.Len; i++) yield return Arr(i, t.At(i)); }
        static double Truncz(double d) => double.IsNaN(d) ? 0 : Math.Truncate(d);
        static V MakeArray(int n, V a, V b, V c, V d, V[] r)
        {
            if (n == 1 && a.O == Tag.Num)
            {
                uint len = ToUint32(a.D);
                if (len != a.D) throw new JsThrow(MakeError("RangeError", "Invalid array length"));
                var arr = new JsArray((int)len); arr.SetLength((int)len); return arr.V;
            }
            var l = new JsArray(n); for (int i = 0; i < n; i++) l.Push(Arg(i, n, a, b, c, d, r)); return l.V;
        }
        static void Flatten(JsArray src, JsArray o, int depth)
        {
            for (int i = 0; i < src.Len; i++)
            {
                if (!src.HasAt(i)) continue;
                var x = src.A[i];
                if (depth > 0 && x.O is JsArray xa) Flatten(xa, o, depth - 1); else o.Push(x);
            }
        }
        public static string Join(JsArray t, string sep)
        {
            if (t.Len == 0) return "";
            if (t.Len == 1) { var v = t.A[0]; return v.IsNullish || v.IsHole ? "" : ToStr(v); }
            var sb = new StringBuilder();
            for (int i = 0; i < t.Len; i++)
            {
                if (i > 0) sb.Append(sep);
                var v = t.A[i];
                if (!v.IsNullish && !v.IsHole) sb.Append(ToStr(v));
            }
            return sb.ToString();
        }
        // a stable merge sort (V8's TimSort is stable: the same order for any consistent comparator); undefined last,
        // holes after them
        static void SortArray(JsArray t, JsFunction cmp)
        {
            var vals = new List<V>(t.Len); int undef = 0, holes = 0;
            for (int i = 0; i < t.Len; i++) { var v = t.A[i]; if (v.IsHole) holes++; else if (v.IsUndef) undef++; else vals.Add(v); }
            var arr = vals.ToArray();
            Comparison<V> c;
            if (cmp != null) c = (x, y) => { double r = ToNum(cmp.Fn(default, 2, x, y, default, default, null)); return r < 0 ? -1 : r > 0 ? 1 : 0; };
            else
            {
                var strs = new Dictionary<int, string>();
                c = (x, y) => string.CompareOrdinal(ToStr(x), ToStr(y));
            }
            MergeSort(arr, new V[arr.Length], 0, arr.Length, c);
            int k = 0;
            foreach (var v in arr) t.A[k++] = v;
            for (int i = 0; i < undef; i++) t.A[k++] = default;
            for (int i = 0; i < holes; i++) t.A[k++] = V.HoleV;
        }
        static void MergeSort(V[] a, V[] tmp, int lo, int hi, Comparison<V> c)
        {
            if (hi - lo < 2) return;
            if (hi - lo <= 10)
            {
                for (int i = lo + 1; i < hi; i++) { var x = a[i]; int j = i - 1; while (j >= lo && c(a[j], x) > 0) { a[j + 1] = a[j]; j--; } a[j + 1] = x; }
                return;
            }
            int mid = (lo + hi) / 2;
            MergeSort(a, tmp, lo, mid, c); MergeSort(a, tmp, mid, hi, c);
            if (c(a[mid - 1], a[mid]) <= 0) return;
            Array.Copy(a, lo, tmp, lo, hi - lo);
            int p = lo, q = mid, o = lo;
            while (p < mid && q < hi) a[o++] = c(tmp[q], tmp[p]) < 0 ? tmp[q++] : tmp[p++];
            while (p < mid) a[o++] = tmp[p++];
            while (q < hi) a[o++] = tmp[q++];
        }

        // ------------------------------------------------------------------ String
        static string ThisStr(V s, string m)
        {
            if (s.O is string str) return str;
            if (s.IsNullish) throw TypeErr("String.prototype." + m + " called on null or undefined");
            return ToStr(s);
        }
        public static string String_fromCharCode(params V[] codes)
        {
            var sb = new StringBuilder(codes.Length);
            foreach (var c in codes) sb.Append((char)(ToUint32(ToNum(c)) & 0xffff));
            return sb.ToString();
        }
        static bool IsJsWs(char c) => c == ' ' || c == '\t' || c == '\n' || c == '\r' || c == '\v' || c == '\f' || c == '\u00a0' || c == '\ufeff' || c == '\u2028' || c == '\u2029' || c == ' ' || (c >= ' ' && c <= ' ') || c == ' ' || c == ' ' || c == '　';
        static string JsTrim(string s, bool start, bool end)
        {
            int a = 0, b = s.Length;
            if (start) while (a < b && IsJsWs(s[a])) a++;
            if (end) while (b > a && IsJsWs(s[b - 1])) b--;
            return a == 0 && b == s.Length ? s : s.Substring(a, b - a);
        }
        static JsRegExp AsRegExp(V v, string flags) => v.O as JsRegExp ?? new JsRegExp(JsRegExp.Compile(v.IsUndef ? "(?:)" : RegexSrcOf(ToStr(v)), flags), v.IsUndef ? "(?:)" : ToStr(v), flags);
        static string RegexSrcOf(string s) => s;
        static string Escape(string s) => System.Text.RegularExpressions.Regex.Escape(s);
        static void InitString()
        {
            var P = StringProto;
            var ctor = Ctor("String", 1, (s, n, a, b, c, d, r) => n == 0 ? "" : ToStr(a), P, (f, n, a, b, c, d, r) => n == 0 ? "" : ToStr(a));
            Def(ctor, "fromCharCode", 1, (s, n, a, b, c, d, r) => { var l = new V[n]; for (int i = 0; i < n; i++) l[i] = Arg(i, n, a, b, c, d, r); return String_fromCharCode(l); });
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => ThisStr(s, "toString"));
            Def(P, "valueOf", 0, (s, n, a, b, c, d, r) => ThisStr(s, "valueOf"));
            Def(P, "charAt", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "charAt"); double i = Truncz(ToNum(a)); return i >= 0 && i < t.Length ? CharStr(t[(int)i]) : ""; });
            Def(P, "charCodeAt", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "charCodeAt"); double i = Truncz(ToNum(a)); return i >= 0 && i < t.Length ? (double)t[(int)i] : double.NaN; });
            Def(P, "codePointAt", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "codePointAt"); double i = Truncz(ToNum(a)); if (!(i >= 0 && i < t.Length)) return default; int k = (int)i; return char.IsHighSurrogate(t[k]) && k + 1 < t.Length && char.IsLowSurrogate(t[k + 1]) ? char.ConvertToUtf32(t[k], t[k + 1]) : t[k]; });
            Def(P, "at", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "at"); double i = Truncz(ToNum(a)); if (i < 0) i += t.Length; return i >= 0 && i < t.Length ? (V)CharStr(t[(int)i]) : default; });
            Def(P, "indexOf", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "indexOf"); int from = (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length); return t.IndexOf(ToStr(a), from, StringComparison.Ordinal); });
            Def(P, "lastIndexOf", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "lastIndexOf"); var sub = ToStr(a);
                double pos = ToNum(b); int from = double.IsNaN(pos) ? t.Length : (int)Math.Min(Math.Max(Math.Truncate(pos), 0), t.Length);
                for (int i = Math.Min(from, t.Length - sub.Length); i >= 0; i--) if (string.CompareOrdinal(t, i, sub, 0, sub.Length) == 0) return i;
                return -1;
            });
            Def(P, "includes", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "includes"); int from = (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length); return t.IndexOf(ToStr(a), from, StringComparison.Ordinal) >= 0; });
            Def(P, "startsWith", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "startsWith"); var sub = ToStr(a); int p = (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length); return p + sub.Length <= t.Length && string.CompareOrdinal(t, p, sub, 0, sub.Length) == 0; });
            Def(P, "endsWith", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "endsWith"); var sub = ToStr(a); int e = b.IsUndef ? t.Length : (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length); int st = e - sub.Length; return st >= 0 && string.CompareOrdinal(t, st, sub, 0, sub.Length) == 0; });
            Def(P, "slice", 2, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "slice"); int st = RelIndex(a, t.Length, 0), en = RelIndex(b, t.Length, t.Length); return st < en ? t.Substring(st, en - st) : ""; });
            Def(P, "substring", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "substring");
                int st = (int)Math.Min(Math.Max(Truncz(ToNum(a)), 0), t.Length), en = b.IsUndef ? t.Length : (int)Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length);
                if (st > en) { int x = st; st = en; en = x; }
                return t.Substring(st, en - st);
            });
            Def(P, "substr", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "substr"); int st = RelIndex(a, t.Length, 0);
                double len = b.IsUndef ? t.Length - st : Math.Min(Math.Max(Truncz(ToNum(b)), 0), t.Length - st);
                return len <= 0 ? "" : t.Substring(st, (int)len);
            });
            Def(P, "toUpperCase", 0, (s, n, a, b, c, d, r) => ThisStr(s, "toUpperCase").ToUpperInvariant());
            Def(P, "toLowerCase", 0, (s, n, a, b, c, d, r) => ThisStr(s, "toLowerCase").ToLowerInvariant());
            Def(P, "toLocaleUpperCase", 0, (s, n, a, b, c, d, r) => ThisStr(s, "toUpperCase").ToUpperInvariant());
            Def(P, "toLocaleLowerCase", 0, (s, n, a, b, c, d, r) => ThisStr(s, "toLowerCase").ToLowerInvariant());
            Def(P, "trim", 0, (s, n, a, b, c, d, r) => JsTrim(ThisStr(s, "trim"), true, true));
            Def(P, "trimStart", 0, (s, n, a, b, c, d, r) => JsTrim(ThisStr(s, "trimStart"), true, false));
            Def(P, "trimEnd", 0, (s, n, a, b, c, d, r) => JsTrim(ThisStr(s, "trimEnd"), false, true));
            Def(P, "padStart", 2, (s, n, a, b, c, d, r) => Pad(ThisStr(s, "padStart"), a, b, true));
            Def(P, "padEnd", 2, (s, n, a, b, c, d, r) => Pad(ThisStr(s, "padEnd"), a, b, false));
            Def(P, "repeat", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "repeat"); double k = Truncz(ToNum(a)); if (k < 0 || double.IsInfinity(k)) throw new JsThrow(MakeError("RangeError", "Invalid count value")); var sb = new StringBuilder(); for (int i = 0; i < k; i++) sb.Append(t); return sb.ToString(); });
            Def(P, "concat", 1, (s, n, a, b, c, d, r) => { var sb = new StringBuilder(ThisStr(s, "concat")); for (int i = 0; i < n; i++) sb.Append(ToStr(Arg(i, n, a, b, c, d, r))); return sb.ToString(); });
            Def(P, "localeCompare", 1, (s, n, a, b, c, d, r) => (double)Math.Sign(string.Compare(ThisStr(s, "localeCompare"), ToStr(a), StringComparison.InvariantCulture)));
            Def(P, "split", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "split");
                uint lim = b.IsUndef ? uint.MaxValue : ToUint32(ToNum(b));
                if (a.O is JsRegExp re) return re.Split(t, lim);
                var o = new JsArray();
                if (lim == 0) return o.V;
                if (a.IsUndef) { o.Push(t); return o.V; }
                var sep = ToStr(a);
                if (sep.Length == 0) { for (int i = 0; i < t.Length && o.Len < lim; i++) o.Push(CharStr(t[i])); return o.V; }
                int p = 0;
                for (;;)
                {
                    int q = t.IndexOf(sep, p, StringComparison.Ordinal);
                    if (q < 0) break;
                    o.Push(t.Substring(p, q - p));
                    if (o.Len == lim) return o.V;
                    p = q + sep.Length;
                }
                o.Push(t.Substring(p));
                return o.V;
            });
            Def(P, "replace", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "replace");
                if (a.O is JsRegExp re) return re.Replace(t, b);
                var pat = ToStr(a);
                int at = t.IndexOf(pat, StringComparison.Ordinal);
                if (at < 0) return t;
                return t.Substring(0, at) + Substitute(t, pat, at, b) + t.Substring(at + pat.Length);
            });
            Def(P, "replaceAll", 2, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "replaceAll");
                if (a.O is JsRegExp re) { if (!re.Global) throw TypeErr("replaceAll must be called with a global RegExp"); return re.Replace(t, b); }
                var pat = ToStr(a);
                var sb = new StringBuilder(); int p = 0;
                var positions = new List<int>();
                if (pat.Length == 0) { for (int i = 0; i <= t.Length; i++) positions.Add(i); }
                else { int q = t.IndexOf(pat, 0, StringComparison.Ordinal); while (q >= 0) { positions.Add(q); q = t.IndexOf(pat, q + pat.Length, StringComparison.Ordinal); } }
                foreach (var q in positions) { sb.Append(t, p, q - p); sb.Append(Substitute(t, pat, q, b)); p = q + pat.Length; }
                if (p <= t.Length) sb.Append(t, p, t.Length - p);
                return sb.ToString();
            });
            Def(P, "match", 1, (s, n, a, b, c, d, r) =>
            {
                var t = ThisStr(s, "match"); var re = AsRegExp(a, "");
                if (re.Global) return re.MatchAllArray(t);
                return re.Exec(t);
            });
            Def(P, "matchAll", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "matchAll"); var re = AsRegExp(a, "g"); return new JsIterator(re.MatchAllExec(t)).V; });
            Def(P, "search", 1, (s, n, a, b, c, d, r) => { var t = ThisStr(s, "search"); var re = AsRegExp(a, ""); var m = re.Rx.Match(t); return m.Success ? m.Index : -1; });
        }
        static string Pad(string t, V lenV, V fillV, bool start)
        {
            int len = (int)Math.Max(0, Truncz(ToNum(lenV)));
            string fill = fillV.IsUndef ? " " : ToStr(fillV);
            if (len <= t.Length || fill.Length == 0) return t;
            var sb = new StringBuilder(); int need = len - t.Length;
            while (sb.Length < need) sb.Append(fill);
            sb.Length = need;
            return start ? sb + t : t + sb;
        }
        static string Substitute(string t, string matched, int pos, V repl)
        {
            if (repl.O is JsFunction f) return ToStr(f.Fn(default, 3, matched, pos, t, default, null));
            var rs = ToStr(repl);
            if (rs.IndexOf('$') < 0) return rs;
            var sb = new StringBuilder();
            for (int i = 0; i < rs.Length; i++)
            {
                char ch = rs[i];
                if (ch != '$' || i + 1 >= rs.Length) { sb.Append(ch); continue; }
                char nx = rs[i + 1];
                if (nx == '$') { sb.Append('$'); i++; }
                else if (nx == '&') { sb.Append(matched); i++; }
                else if (nx == '`') { sb.Append(t, 0, pos); i++; }
                else if (nx == '\'') { int e = pos + matched.Length; sb.Append(t, e, t.Length - e); i++; }
                else sb.Append(ch);
            }
            return sb.ToString();
        }

        // ------------------------------------------------------------------ Number, Boolean
        static double ThisNum(V s) { if (s.O == Tag.Num) return s.D; throw TypeErr("Number.prototype method called on incompatible receiver"); }
        static void InitNumber()
        {
            var P = NumberProto;
            var ctor = Ctor("Number", 1, (s, n, a, b, c, d, r) => n == 0 ? 0 : ToNum(a), P, (f, n, a, b, c, d, r) => n == 0 ? 0 : ToNum(a));
            ctor.Put("EPSILON", Math.Pow(2, -52), 5); ctor.Put("MAX_SAFE_INTEGER", 9007199254740991.0, 5); ctor.Put("MIN_SAFE_INTEGER", -9007199254740991.0, 5);
            ctor.Put("MAX_VALUE", double.MaxValue, 5); ctor.Put("MIN_VALUE", double.Epsilon, 5); ctor.Put("NaN", double.NaN, 5);
            ctor.Put("POSITIVE_INFINITY", double.PositiveInfinity, 5); ctor.Put("NEGATIVE_INFINITY", double.NegativeInfinity, 5);
            Def(ctor, "isFinite", 1, (s, n, a, b, c, d, r) => a.IsNum && !double.IsNaN(a.D) && !double.IsInfinity(a.D));
            Def(ctor, "isNaN", 1, (s, n, a, b, c, d, r) => a.IsNum && double.IsNaN(a.D));
            Def(ctor, "isInteger", 1, (s, n, a, b, c, d, r) => a.IsNum && !double.IsInfinity(a.D) && Math.Floor(a.D) == a.D);
            Def(ctor, "isSafeInteger", 1, (s, n, a, b, c, d, r) => a.IsNum && Math.Floor(a.D) == a.D && Math.Abs(a.D) <= 9007199254740991.0);
            Def(ctor, "parseFloat", 1, (s, n, a, b, c, d, r) => ParseFloat(a));
            Def(ctor, "parseInt", 2, (s, n, a, b, c, d, r) => ParseInt(a, b));
            Def(P, "toString", 1, (s, n, a, b, c, d, r) => { double x = ThisNum(s); int radix = a.IsUndef ? 10 : (int)ToNum(a); if (radix < 2 || radix > 36) throw new JsThrow(MakeError("RangeError", "toString() radix must be between 2 and 36")); return JsNumber.ToRadix(x, radix); });
            Def(P, "toFixed", 1, (s, n, a, b, c, d, r) => { double x = ThisNum(s); int f = (int)Truncz(ToNum(a)); if (f < 0 || f > 100) throw new JsThrow(MakeError("RangeError", "toFixed() digits argument must be between 0 and 100")); return JsNumber.ToFixed(x, f); });
            Def(P, "toPrecision", 1, (s, n, a, b, c, d, r) => { double x = ThisNum(s); if (a.IsUndef) return JsNumber.ToString(x); return JsNumber.ToPrecision(x, (int)ToNum(a)); });
            Def(P, "valueOf", 0, (s, n, a, b, c, d, r) => ThisNum(s));
            Def(P, "toLocaleString", 0, (s, n, a, b, c, d, r) => JsNumber.ToString(ThisNum(s)));
            var B = BooleanProto;
            Ctor("Boolean", 1, (s, n, a, b, c, d, r) => Truthy(a), B, (f, n, a, b, c, d, r) => Truthy(a));
            Def(B, "toString", 0, (s, n, a, b, c, d, r) => s.O == Tag.True ? "true" : "false");
            Def(B, "valueOf", 0, (s, n, a, b, c, d, r) => s);
        }
        public static double ParseFloat(V v) => JsNumber.ParseFloat(ToStr(v));
        public static double ParseInt(V v, V radix) => JsNumber.ParseInt(ToStr(v), radix.IsUndef ? 0 : ToInt32(ToNum(radix)));
        public static bool IsFiniteV(V v) { double d = ToNum(v); return !double.IsNaN(d) && !double.IsInfinity(d); }

        // ------------------------------------------------------------------ Math
        static void InitMath()
        {
            var M = NewObj(48);
            Global.Put("Math", M.V, 1);
            M.Put("PI", Math.PI, 5); M.Put("E", Math.E, 5); M.Put("LN2", 0.6931471805599453, 5); M.Put("LN10", 2.302585092994046, 5);
            M.Put("LOG2E", 1.4426950408889634, 5); M.Put("LOG10E", 0.4342944819032518, 5); M.Put("SQRT2", 1.4142135623730951, 5); M.Put("SQRT1_2", 0.7071067811865476, 5);
            void F1(string name, Func<double, double> f) => Def(M, name, 1, (s, n, a, b, c, d, r) => f(ToNum(a)));
            F1("abs", Math.Abs); F1("floor", Math.Floor); F1("ceil", Math.Ceiling); F1("round", Round); F1("trunc", Math.Truncate); F1("sign", Sign);
            F1("sqrt", Math.Sqrt); F1("cbrt", FdLibm.Cbrt); F1("sin", FdLibm.Sin); F1("cos", FdLibm.Cos); F1("tan", FdLibm.Tan); F1("asin", FdLibm.Asin);
            F1("acos", FdLibm.Acos); F1("atan", FdLibm.Atan); F1("exp", FdLibm.Exp); F1("log", FdLibm.Log); F1("log2", FdLibm.Log2); F1("log10", FdLibm.Log10);
            F1("log1p", FdLibm.Log1p); F1("expm1", FdLibm.Expm1); F1("sinh", FdLibm.Sinh); F1("cosh", FdLibm.Cosh); F1("tanh", FdLibm.Tanh);
            F1("asinh", x => Math.Log(x + Math.Sqrt(x * x + 1))); F1("acosh", x => Math.Log(x + Math.Sqrt(x * x - 1))); F1("atanh", x => 0.5 * Math.Log((1 + x) / (1 - x)));
            F1("fround", x => (double)(float)x);
            F1("clz32", x => { uint u = ToUint32(x); int k = 0; if (u == 0) return 32; while ((u & 0x80000000u) == 0) { u <<= 1; k++; } return k; });
            Def(M, "imul", 2, (s, n, a, b, c, d, r) => (double)unchecked(ToInt32(ToNum(a)) * ToInt32(ToNum(b))));
            Def(M, "atan2", 2, (s, n, a, b, c, d, r) => FdLibm.Atan2(ToNum(a), ToNum(b)));
            Def(M, "pow", 2, (s, n, a, b, c, d, r) => Pow(ToNum(a), ToNum(b)));
            Def(M, "random", 0, (s, n, a, b, c, d, r) => _rand.NextDouble());
            Def(M, "hypot", 2, (s, n, a, b, c, d, r) => { var l = new double[n]; for (int i = 0; i < n; i++) l[i] = ToNum(Arg(i, n, a, b, c, d, r)); return Hypot(l); });
            Def(M, "max", 2, (s, n, a, b, c, d, r) => { double m = double.NegativeInfinity; bool nan = false; for (int i = 0; i < n; i++) { double x = ToNum(Arg(i, n, a, b, c, d, r)); if (double.IsNaN(x)) nan = true; m = Max(m, x); } return nan ? double.NaN : m; });
            Def(M, "min", 2, (s, n, a, b, c, d, r) => { double m = double.PositiveInfinity; bool nan = false; for (int i = 0; i < n; i++) { double x = ToNum(Arg(i, n, a, b, c, d, r)); if (double.IsNaN(x)) nan = true; m = Min(m, x); } return nan ? double.NaN : m; });
        }

        // ------------------------------------------------------------------ JSON
        static void InitJson()
        {
            var J = NewObj(4);
            Global.Put("JSON", J.V, 1);
            Def(J, "stringify", 3, (s, n, a, b, c, d, r) =>
            {
                string gap = c.O == Tag.Num ? new string(' ', (int)Math.Min(10, Math.Max(0, c.D))) : c.O is string gs ? (gs.Length > 10 ? gs.Substring(0, 10) : gs) : "";
                var sb = new StringBuilder();
                var stack = new List<object>();
                return JsonStr(sb, a, b.O as JsFunction, gap, "", stack, NewObj(1).Put("", a).V, "") ? (V)sb.ToString() : default;
            });
            Def(J, "parse", 2, (s, n, a, b, c, d, r) => new JsonParser(ToStr(a)).ParseTop());
        }
        static bool JsonStr(StringBuilder sb, V v, JsFunction replacer, string gap, string indent, List<object> stack, V holder, string key)
        {
            if (v.O is JsObject o0) { var tj = o0.Get("toJSON", v); if (tj.O is JsFunction tf) v = tf.Fn(v, 1, key, default, default, default, null); }
            if (replacer != null) v = replacer.Fn(holder, 2, key, v, default, default, null);
            var o = v.O;
            if (o == Tag.Null) { sb.Append("null"); return true; }
            if (o == Tag.True) { sb.Append("true"); return true; }
            if (o == Tag.False) { sb.Append("false"); return true; }
            if (o is string s) { Quote(sb, s); return true; }
            if (o == Tag.Num) { sb.Append(double.IsNaN(v.D) || double.IsInfinity(v.D) ? "null" : JsNumber.ToString(v.D)); return true; }
            if (o == null || o is JsFunction) return false;
            var obj = (JsObject)o;
            if (stack.Contains(obj)) throw TypeErr("Converting circular structure to JSON");
            stack.Add(obj);
            string inner = indent + gap;
            if (obj is JsArray arr)
            {
                sb.Append('[');
                for (int i = 0; i < arr.Len; i++)
                {
                    if (i > 0) sb.Append(',');
                    if (gap.Length > 0) sb.Append('\n').Append(inner);
                    if (!JsonStr(sb, arr.At(i), replacer, gap, inner, stack, v, IndexKey(i))) sb.Append("null");
                }
                if (gap.Length > 0 && arr.Len > 0) sb.Append('\n').Append(indent);
                sb.Append(']');
            }
            else
            {
                sb.Append('{');
                bool any = false;
                foreach (var k in obj.OwnKeys(true))
                {
                    int mark = sb.Length;
                    if (any) sb.Append(',');
                    if (gap.Length > 0) sb.Append('\n').Append(inner);
                    Quote(sb, k); sb.Append(gap.Length > 0 ? ": " : ":");
                    if (!JsonStr(sb, obj.Get(k, v), replacer, gap, inner, stack, v, k)) { sb.Length = mark; continue; }
                    any = true;
                }
                if (gap.Length > 0 && any) sb.Append('\n').Append(indent);
                sb.Append('}');
            }
            stack.RemoveAt(stack.Count - 1);
            return true;
        }
        static void Quote(StringBuilder sb, string s)
        {
            sb.Append('"');
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 0x20 || (char.IsSurrogate(c) && !(char.IsHighSurrogate(c) && i + 1 < s.Length && char.IsLowSurrogate(s[i + 1])) && !(char.IsLowSurrogate(c) && i > 0 && char.IsHighSurrogate(s[i - 1]))))
                            sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else sb.Append(c);
                        break;
                }
            }
            sb.Append('"');
        }
        sealed class JsonParser
        {
            readonly string _s; int _i;
            public JsonParser(string s) { _s = s; }
            Exception Err() => new JsThrow(MakeError("SyntaxError", "Unexpected token in JSON at position " + _i));
            void Ws() { while (_i < _s.Length && (_s[_i] == ' ' || _s[_i] == '\t' || _s[_i] == '\n' || _s[_i] == '\r')) _i++; }
            public V ParseTop() { Ws(); var v = Value(); Ws(); if (_i != _s.Length) throw Err(); return v; }
            V Value()
            {
                Ws();
                if (_i >= _s.Length) throw Err();
                char c = _s[_i];
                if (c == '{')
                {
                    _i++; var o = NewObj(4); Ws();
                    if (_i < _s.Length && _s[_i] == '}') { _i++; return o.V; }
                    for (;;)
                    {
                        Ws(); if (_i >= _s.Length || _s[_i] != '"') throw Err();
                        var k = Str(); Ws(); if (_i >= _s.Length || _s[_i] != ':') throw Err(); _i++;
                        o.Put(k, Value(), 0); Ws();
                        if (_i < _s.Length && _s[_i] == ',') { _i++; continue; }
                        if (_i < _s.Length && _s[_i] == '}') { _i++; return o.V; }
                        throw Err();
                    }
                }
                if (c == '[')
                {
                    _i++; var a = new JsArray(); Ws();
                    if (_i < _s.Length && _s[_i] == ']') { _i++; return a.V; }
                    for (;;)
                    {
                        a.Push(Value()); Ws();
                        if (_i < _s.Length && _s[_i] == ',') { _i++; continue; }
                        if (_i < _s.Length && _s[_i] == ']') { _i++; return a.V; }
                        throw Err();
                    }
                }
                if (c == '"') return Str();
                if (_s.Length - _i >= 4 && string.CompareOrdinal(_s, _i, "true", 0, 4) == 0) { _i += 4; return true; }
                if (_s.Length - _i >= 5 && string.CompareOrdinal(_s, _i, "false", 0, 5) == 0) { _i += 5; return false; }
                if (_s.Length - _i >= 4 && string.CompareOrdinal(_s, _i, "null", 0, 4) == 0) { _i += 4; return V.Null; }
                int st = _i;
                if (c == '-') _i++;
                while (_i < _s.Length && (char.IsDigit(_s[_i]) || _s[_i] == '.' || _s[_i] == 'e' || _s[_i] == 'E' || _s[_i] == '+' || _s[_i] == '-')) _i++;
                if (_i == st) throw Err();
                return double.Parse(_s.Substring(st, _i - st), NumberStyles.Float, CultureInfo.InvariantCulture);
            }
            string Str()
            {
                _i++; var sb = new StringBuilder();
                while (_i < _s.Length)
                {
                    char c = _s[_i++];
                    if (c == '"') return sb.ToString();
                    if (c != '\\') { sb.Append(c); continue; }
                    char e = _s[_i++];
                    switch (e)
                    {
                        case 'n': sb.Append('\n'); break; case 't': sb.Append('\t'); break; case 'r': sb.Append('\r'); break;
                        case 'b': sb.Append('\b'); break; case 'f': sb.Append('\f'); break;
                        case 'u': sb.Append((char)Convert.ToInt32(_s.Substring(_i, 4), 16)); _i += 4; break;
                        default: sb.Append(e); break;
                    }
                }
                throw Err();
            }
        }

        // ------------------------------------------------------------------ Date (the clock sets Date.now)
        static void InitDate()
        {
            var P = new JsObject(ObjectProto);
            var ctor = Ctor("Date", 7, (s, n, a, b, c, d, r) => DateStr(NowMs()), P, (f, n, a, b, c, d, r) =>
            {
                double t;
                if (n == 0) t = NowMs();
                else if (n == 1) t = a.O is string ds ? (DateTime.TryParse(ds, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var dt) ? (dt - Epoch).TotalMilliseconds : double.NaN) : ToNum(a);
                else t = Utc(n, a, b, c, d, r) + 0;
                var o = new JsObject(P); o.Put("__t", t, 1); return o.V;
            });
            Def(ctor, "UTC", 7, (s, n, a, b, c, d, r) => Utc(n, a, b, c, d, r));
            Def(ctor, "now", 0, (s, n, a, b, c, d, r) => NowMs());
            double T(V s) => s.O is JsObject o ? ToNum(o.Get("__t", s)) : double.NaN;
            DateTime DT(V s) => Epoch.AddMilliseconds(T(s));
            Def(P, "getTime", 0, (s, n, a, b, c, d, r) => T(s));
            Def(P, "valueOf", 0, (s, n, a, b, c, d, r) => T(s));
            Def(P, "getFullYear", 0, (s, n, a, b, c, d, r) => DT(s).Year);
            Def(P, "getMonth", 0, (s, n, a, b, c, d, r) => DT(s).Month - 1);
            Def(P, "getDate", 0, (s, n, a, b, c, d, r) => DT(s).Day);
            Def(P, "getDay", 0, (s, n, a, b, c, d, r) => (int)DT(s).DayOfWeek);
            Def(P, "getHours", 0, (s, n, a, b, c, d, r) => DT(s).Hour);
            Def(P, "getMinutes", 0, (s, n, a, b, c, d, r) => DT(s).Minute);
            Def(P, "getSeconds", 0, (s, n, a, b, c, d, r) => DT(s).Second);
            Def(P, "getMilliseconds", 0, (s, n, a, b, c, d, r) => DT(s).Millisecond);
            Def(P, "getTimezoneOffset", 0, (s, n, a, b, c, d, r) => 0);
            Def(P, "toISOString", 0, (s, n, a, b, c, d, r) => DT(s).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture));
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => DateStr(T(s)));
        }
        static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>`new Date()` without the page's clock: real time (as in a browser), unless the host fixes it.</summary>
        public static Func<double> RealNow = () => (DateTime.UtcNow - Epoch).TotalMilliseconds;
        static double NowMs() => RealNow();
        static string DateStr(double t) => double.IsNaN(t) ? "Invalid Date" : Epoch.AddMilliseconds(t).ToString("ddd MMM dd yyyy HH:mm:ss 'GMT+0000'", CultureInfo.InvariantCulture);
        static double Utc(int n, V a, V b, V c, V d, V[] r)
        {
            double y = ToNum(a), mo = n > 1 ? ToNum(b) : 0, dd = n > 2 ? ToNum(c) : 1, h = n > 3 ? ToNum(d) : 0, mi = n > 4 ? ToNum(r[0]) : 0, se = n > 5 ? ToNum(r[1]) : 0, ms = n > 6 ? ToNum(r[2]) : 0;
            if (double.IsNaN(y + mo + dd + h + mi + se + ms)) return double.NaN;
            var dt = new DateTime((int)y, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths((int)mo).AddDays(dd - 1);
            return (dt - Epoch).TotalMilliseconds + h * 3600000 + mi * 60000 + se * 1000 + ms;
        }

        // ------------------------------------------------------------------ RegExp
        public static V NewRegExp(System.Text.RegularExpressions.Regex rx, string src, string flags) => new JsRegExp(rx, src, flags).V;
        static JsRegExp ThisRe(V s) => s.O as JsRegExp ?? throw TypeErr("RegExp method called on incompatible receiver");
        static void InitRegExp()
        {
            var P = RegExpProto;
            JsFn make = (s, n, a, b, c, d, r) =>
            {
                string src = a.O is JsRegExp ra ? ra.Source : a.IsUndef ? "(?:)" : ToStr(a);
                string fl = b.IsUndef ? (a.O is JsRegExp rb ? rb.Flags : "") : ToStr(b);
                return new JsRegExp(JsRegExp.Compile(src, fl), src, fl).V;
            };
            Ctor("RegExp", 2, make, P, (f, n, a, b, c, d, r) => make(default, n, a, b, c, d, r));
            Def(P, "exec", 1, (s, n, a, b, c, d, r) => ThisRe(s).Exec(ToStr(a)));
            Def(P, "test", 1, (s, n, a, b, c, d, r) => !ThisRe(s).Exec(ToStr(a)).IsNullish);
            Def(P, "toString", 0, (s, n, a, b, c, d, r) => "/" + ThisRe(s).Source + "/" + ThisRe(s).Flags);
            DefGet(P, "source", (s, n, a, b, c, d, r) => ThisRe(s).Source);
            DefGet(P, "flags", (s, n, a, b, c, d, r) => ThisRe(s).Flags);
            DefGet(P, "global", (s, n, a, b, c, d, r) => ThisRe(s).Global);
            DefGet(P, "sticky", (s, n, a, b, c, d, r) => ThisRe(s).Sticky);
            DefGet(P, "ignoreCase", (s, n, a, b, c, d, r) => ThisRe(s).Flags.IndexOf('i') >= 0);
            DefGet(P, "multiline", (s, n, a, b, c, d, r) => ThisRe(s).Flags.IndexOf('m') >= 0);
        }

        // ------------------------------------------------------------------ errors
        static void InitErrors()
        {
            JsFunction MakeErr(string name, JsObject proto)
            {
                proto.Put("name", name, 1);
                proto.Put("message", "", 1);
                Func<JsFunction, int, V, V, V, V, V[], V> make = (f, n, a, b, c, d, r) =>
                {
                    var p = f.Get("prototype").O as JsObject ?? proto;
                    var e = new JsObject(p);
                    if (!a.IsUndef) e.Put("message", ToStr(a), 1);
                    e.Put("stack", name + ": " + (a.IsUndef ? "" : ToStr(a)), 1);
                    return e.V;
                };
                JsFunction self = null;
                self = Ctor(name, 1, (s, n, a, b, c, d, r) => make(self, n, a, b, c, d, r), proto, make);
                return self;
            }
            MakeErr("Error", ErrorProto);
            Def(ErrorProto, "toString", 0, (s, n, a, b, c, d, r) => { var nm = ToStr(Get(s, "name")); var m = ToStr(Get(s, "message")); return m.Length == 0 ? nm : nm.Length == 0 ? m : nm + ": " + m; });
            foreach (var n in new[] { "TypeError", "RangeError", "ReferenceError", "SyntaxError", "EvalError", "URIError" }) MakeErr(n, new JsObject(ErrorProto));
        }

        // ------------------------------------------------------------------ Map, Set, iterators
        static JsMap ThisMap(V s) => s.O as JsMap ?? throw TypeErr("Map method called on incompatible receiver");
        static void InitCollections()
        {
            Def(IteratorProto, "next", 0, (s, n, a, b, c, d, r) =>
            {
                var it = s.O as JsIterator ?? throw TypeErr("not an iterator");
                bool ok = it.Next(out var v);
                return NewObj(2).Put("value", v).Put("done", !ok).V;
            });
            var M = MapProto;
            Ctor("Map", 0, (s, n, a, b, c, d, r) => throw TypeErr("Constructor Map requires 'new'"), M, (f, n, a, b, c, d, r) =>
            {
                var m = new JsMap(f.Get("prototype").O as JsObject ?? MapProto);
                if (!a.IsNullish) foreach (var e in Iterate(a)) m.SetV(GetIdx(e, 0), GetIdx(e, 1));
                return m.V;
            });
            Def(M, "get", 1, (s, n, a, b, c, d, r) => ThisMap(s).GetV(a));
            Def(M, "set", 2, (s, n, a, b, c, d, r) => { ThisMap(s).SetV(a, b); return s; });
            Def(M, "has", 1, (s, n, a, b, c, d, r) => ThisMap(s).Has(a));
            Def(M, "delete", 1, (s, n, a, b, c, d, r) => ThisMap(s).DeleteV(a));
            Def(M, "clear", 0, (s, n, a, b, c, d, r) => { ThisMap(s).Clear(); return default; });
            DefGet(M, "size", (s, n, a, b, c, d, r) => ThisMap(s).Size);
            Def(M, "forEach", 1, (s, n, a, b, c, d, r) => { var m = ThisMap(s); var f = Cb(a, "forEach"); for (int i = 0; i < m.Keys.Count; i++) if (m.Live[i]) f.Fn(b, 3, m.Vals[i], m.Keys[i], s, default, null); return default; });
            Def(M, "keys", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).KeysSeq()).V);
            Def(M, "values", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).ValuesSeq()).V);
            Def(M, "entries", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).Entries()).V);
            var S = SetProto;
            Ctor("Set", 0, (s, n, a, b, c, d, r) => throw TypeErr("Constructor Set requires 'new'"), S, (f, n, a, b, c, d, r) =>
            {
                var m = new JsSet(f.Get("prototype").O as JsObject ?? SetProto);
                if (!a.IsNullish) foreach (var e in Iterate(a)) m.SetV(e, e);
                return m.V;
            });
            Def(S, "add", 1, (s, n, a, b, c, d, r) => { ThisMap(s).SetV(a, a); return s; });
            Def(S, "has", 1, (s, n, a, b, c, d, r) => ThisMap(s).Has(a));
            Def(S, "delete", 1, (s, n, a, b, c, d, r) => ThisMap(s).DeleteV(a));
            Def(S, "clear", 0, (s, n, a, b, c, d, r) => { ThisMap(s).Clear(); return default; });
            DefGet(S, "size", (s, n, a, b, c, d, r) => ThisMap(s).Size);
            Def(S, "forEach", 1, (s, n, a, b, c, d, r) => { var m = ThisMap(s); var f = Cb(a, "forEach"); for (int i = 0; i < m.Keys.Count; i++) if (m.Live[i]) f.Fn(b, 3, m.Keys[i], m.Keys[i], s, default, null); return default; });
            Def(S, "values", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).KeysSeq()).V);
            Def(S, "keys", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).KeysSeq()).V);
            Def(S, "entries", 0, (s, n, a, b, c, d, r) => new JsIterator(ThisMap(s).Entries()).V);
            foreach (var w in new[] { "WeakMap", "WeakSet" })
            {
                var proto = w == "WeakMap" ? M : S;
                var wp = new JsObject(proto);
                Ctor(w, 0, (s, n, a, b, c, d, r) => throw TypeErr(w + " requires 'new'"), wp, (f, n, a, b, c, d, r) => (proto == M ? (JsMap)new JsMap(wp) : new JsSet(wp)).V);
            }
        }

        // ------------------------------------------------------------------ Promise
        static void InitPromise()
        {
            var P = PromiseProto;
            V Resolver(JsPromise p, bool ok) => Fn((s, n, a, b, c, d, r) => { if (ok) p.Resolve(a); else p.Reject(a); return default; }, 1, "", true);
            var ctor = Ctor("Promise", 1, (s, n, a, b, c, d, r) => throw TypeErr("Promise constructor cannot be invoked without 'new'"), P, (f, n, a, b, c, d, r) =>
            {
                var p = new JsPromise();
                var ex = Cb(a, "Promise");
                try { ex.Fn(default, 2, Resolver(p, true), Resolver(p, false), default, default, null); }
                catch (Exception e) { p.Reject(Caught(e)); }
                return p.V;
            });
            Def(ctor, "resolve", 1, (s, n, a, b, c, d, r) => { if (a.O is JsPromise) return a; var p = new JsPromise(); p.Resolve(a); return p.V; });
            Def(ctor, "reject", 1, (s, n, a, b, c, d, r) => { var p = new JsPromise(); p.Reject(a); return p.V; });
            Def(ctor, "all", 1, (s, n, a, b, c, d, r) =>
            {
                var all = new JsPromise(); var items = new List<V>(Iterate(a)); var res = new JsArray(items.Count); res.SetLength(items.Count);
                int left = items.Count;
                if (left == 0) { all.Resolve(res.V); return all.V; }
                for (int i = 0; i < items.Count; i++)
                {
                    int k = i;
                    var pi = items[i].O as JsPromise; if (pi == null) { pi = new JsPromise(); pi.Resolve(items[i]); }
                    pi.Then(Fn((s2, n2, a2, b2, c2, d2, r2) => { res.A[k] = a2; if (--left == 0) all.Resolve(res.V); return default; }, 1, "", true),
                        Fn((s2, n2, a2, b2, c2, d2, r2) => { all.Reject(a2); return default; }, 1, "", true));
                }
                return all.V;
            });
            Def(P, "then", 2, (s, n, a, b, c, d, r) => (s.O as JsPromise ?? throw TypeErr("not a promise")).Then(a, b).V);
            Def(P, "catch", 1, (s, n, a, b, c, d, r) => (s.O as JsPromise ?? throw TypeErr("not a promise")).Then(default, a).V);
            Def(P, "finally", 1, (s, n, a, b, c, d, r) =>
            {
                var p = s.O as JsPromise ?? throw TypeErr("not a promise"); var f = a;
                return p.Then(Fn((s2, n2, a2, b2, c2, d2, r2) => { if (f.O is JsFunction ff) ff.Fn(default, 0, default, default, default, default, null); return a2; }, 1, "", true),
                    Fn((s2, n2, a2, b2, c2, d2, r2) => { if (f.O is JsFunction ff) ff.Fn(default, 0, default, default, default, default, null); throw new JsThrow(a2); }, 1, "", true)).V;
            });
        }

        // ------------------------------------------------------------------ typed arrays
        static void InitTyped()
        {
            var bufP = new JsObject(ObjectProto);
            Ctor("ArrayBuffer", 1, (s, n, a, b, c, d, r) => throw TypeErr("ArrayBuffer requires 'new'"), bufP, (f, n, a, b, c, d, r) => new JsArrayBuffer((int)ToNum(a)) { Proto = bufP }.V);
            DefGet(bufP, "byteLength", (s, n, a, b, c, d, r) => s.O is JsArrayBuffer ab ? ab.Bytes.Length : 0);
            var kinds = new (string, JsTypedArray.Kind)[] { ("Float32Array", JsTypedArray.Kind.F32), ("Float64Array", JsTypedArray.Kind.F64), ("Uint32Array", JsTypedArray.Kind.U32),
                ("Int32Array", JsTypedArray.Kind.I32), ("Uint8Array", JsTypedArray.Kind.U8), ("Uint8ClampedArray", JsTypedArray.Kind.U8C), ("Int8Array", JsTypedArray.Kind.I8),
                ("Uint16Array", JsTypedArray.Kind.U16), ("Int16Array", JsTypedArray.Kind.I16) };
            foreach (var (name, kind) in kinds)
            {
                var P = new JsObject(ObjectProto);
                int size = JsTypedArray.SizeOf(kind);
                Ctor(name, 3, (s, n, a, b, c, d, r) => throw TypeErr(name + " requires 'new'"), P, (f, n, a, b, c, d, r) =>
                {
                    if (a.O is JsArrayBuffer ab)
                    {
                        int off = b.IsUndef ? 0 : (int)ToNum(b);
                        int len = c.IsUndef ? (ab.Bytes.Length - off) / size : (int)ToNum(c);
                        return new JsTypedArray(kind, P, ab, off, len).V;
                    }
                    if (a.O is JsObject src)
                    {
                        var items = ArrayLike(a);
                        var t = new JsTypedArray(kind, P, new JsArrayBuffer(items.Count * size), 0, items.Count);
                        for (int i = 0; i < items.Count; i++) t.SetAt(i, ToNum(items[i]));
                        return t.V;
                    }
                    int count = a.IsUndef ? 0 : (int)ToNum(a);
                    return new JsTypedArray(kind, P, new JsArrayBuffer(count * size), 0, count).V;
                });
                Def(P, "set", 2, (s, n, a, b, c, d, r) => { var t = (JsTypedArray)s.O; var items = ArrayLike(a); int off = b.IsUndef ? 0 : (int)ToNum(b); for (int i = 0; i < items.Count; i++) t.SetAt(off + i, ToNum(items[i])); return default; });
                Def(P, "fill", 1, (s, n, a, b, c, d, r) => { var t = (JsTypedArray)s.O; int st = RelIndex(b, t.Length, 0), en = RelIndex(c, t.Length, t.Length); for (int i = st; i < en; i++) t.SetAt(i, ToNum(a)); return s; });
                Def(P, "forEach", 1, (s, n, a, b, c, d, r) => { var t = (JsTypedArray)s.O; var fn = Cb(a, "forEach"); for (int i = 0; i < t.Length; i++) fn.Fn(b, 3, t.GetAt(i), i, s, default, null); return default; });
            }
        }

        // ------------------------------------------------------------------ the global functions
        static void InitGlobals()
        {
            Def(Global, "parseFloat", 1, (s, n, a, b, c, d, r) => ParseFloat(a));
            Def(Global, "parseInt", 2, (s, n, a, b, c, d, r) => ParseInt(a, b));
            Def(Global, "isNaN", 1, (s, n, a, b, c, d, r) => double.IsNaN(ToNum(a)));
            Def(Global, "isFinite", 1, (s, n, a, b, c, d, r) => IsFiniteV(a));
            Def(Global, "encodeURIComponent", 1, (s, n, a, b, c, d, r) => Uri.EscapeDataString(ToStr(a)).Replace("%21", "!").Replace("%27", "'").Replace("%28", "(").Replace("%29", ")").Replace("%2A", "*"));
            Def(Global, "encodeURI", 1, (s, n, a, b, c, d, r) => Uri.EscapeUriString(ToStr(a)));
            Def(Global, "decodeURIComponent", 1, (s, n, a, b, c, d, r) => Uri.UnescapeDataString(ToStr(a)));
            Def(Global, "decodeURI", 1, (s, n, a, b, c, d, r) => Uri.UnescapeDataString(ToStr(a)));
            var con = NewObj(4);
            JsFn log = (s, n, a, b, c, d, r) => { OnConsole?.Invoke(Args(n, a, b, c, d, r)); return default; };
            foreach (var k in new[] { "log", "warn", "error", "info", "debug" }) Def(con, k, 0, log);
            Global.Put("console", con.V, 1);
        }
        /// <summary>console.* from the scripts (the tests print them).</summary>
        public static Action<string> OnConsole;
        static string Args(int n, V a, V b, V c, V d, V[] r)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++) { if (i > 0) sb.Append(' '); var v = Arg(i, n, a, b, c, d, r); try { sb.Append(v.O is JsObject o && o.GetOwn("stack", out var st) ? ToStr(st) : ToStr(v)); } catch (Exception) { sb.Append("(object)"); } }
            return sb.ToString();
        }
    }
}
