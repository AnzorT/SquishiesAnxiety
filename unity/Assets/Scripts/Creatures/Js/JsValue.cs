// The values the compiled rig works with (tools/unity/rig/jsc.mjs turns the app's rig scripts into C# that uses these):
// V, one JS value in a struct (a number needs no allocation), and the objects: JsObject (properties in the order they
// were added, as JS keeps them; accessors; a prototype), JsArray, JsFunction. Unity-free, so tools/unity/rig-test runs
// the same code with plain dotnet.
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SquishSquad.Creatures.Js
{
    /// <summary>What a V holds besides strings and objects (compared by reference).</summary>
    public sealed class Tag
    {
        public static readonly Tag Num = new Tag(), Null = new Tag(), True = new Tag(), False = new Tag(), Hole = new Tag();
    }

    /// <summary>One JS value: undefined (O null), a number (O Tag.Num, D), null, a boolean, a string or an object.</summary>
    public readonly struct V
    {
        public readonly object O;
        public readonly double D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public V(object o, double d) { O = o; D = d; }

        public static readonly V Undef = default;
        public static readonly V Null = new V(Tag.Null, 0);
        public static readonly V True = new V(Tag.True, 1);
        public static readonly V False = new V(Tag.False, 0);
        internal static readonly V HoleV = new V(Tag.Hole, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator V(double d) => new V(Tag.Num, d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator V(string s) => s == null ? Null : new V(s, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator V(bool b) => b ? True : False;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator V(JsObject o) => o == null ? Null : new V(o, 0);

        public bool IsUndef { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => O == null; }
        public bool IsNullish { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => O == null || O == Tag.Null; }
        public bool IsNum { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => O == Tag.Num; }
        public bool IsStr => O is string;
        public bool IsObj => O is JsObject;
        public bool IsBool => O == Tag.True || O == Tag.False;
        internal bool IsHole => O == Tag.Hole;
        public JsObject Obj => O as JsObject;
        public string Str => O as string;
        public override string ToString() => Rt.ToStr(this);
    }

    /// <summary>A JS function's body: this, the number of arguments, the first four, the rest (null when four or fewer).</summary>
    public delegate V JsFn(V self, int argc, V a0, V a1, V a2, V a3, V[] rest);

    /// <summary>A variable a named function expression's body reads its own function from.</summary>
    public sealed class Box { public V v; }

    /// <summary>A JS throw (or a TypeError the runtime raises), carrying the thrown value.</summary>
    public sealed class JsThrow : Exception
    {
        public readonly V Value;
        public JsThrow(V v) : base(null) { Value = v; }
        public override string Message
        {
            get
            {
                try
                {
                    if (Value.O is JsObject o && o.GetOwn("message", out var m)) return Rt.ToStr(o.Get("name", Value)) + ": " + Rt.ToStr(m);
                    return Rt.ToStr(Value);
                }
                catch (Exception) { return "(a JS exception)"; }
            }
        }
    }

    sealed class Accessor { public V Get, Set; }

    public class JsObject
    {
        public JsObject Proto;
        // own properties in the order they were made: keys, values, flags (bit 0 not enumerable, 1 accessor, 2 read-only)
        internal string[] K;
        internal V[] Vs;
        internal byte[] F;
        internal int N;
        Dictionary<string, int> _idx;
        bool _intKeys;

        public JsObject(JsObject proto) { Proto = proto; }
        public JsObject(JsObject proto, int cap) { Proto = proto; if (cap > 0) { K = new string[cap]; Vs = new V[cap]; } }

        public virtual string ClassName => "Object";
        public V V => new V(this, 0);

        // ---------- own slots
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int Find(string k)
        {
            if (_idx != null) return _idx.TryGetValue(k, out int i) ? i : -1;
            var keys = K;
            for (int i = 0; i < N; i++) { var s = keys[i]; if ((object)s == k || (s.Length == k.Length && string.Equals(s, k))) return i; }
            return -1;
        }
        internal int AddSlot(string k, V v, byte flags)
        {
            if (K == null) { K = new string[6]; Vs = new V[6]; }
            else if (N == K.Length) { Array.Resize(ref K, N * 2); Array.Resize(ref Vs, N * 2); if (F != null) Array.Resize(ref F, N * 2); }
            K[N] = k; Vs[N] = v;
            if (flags != 0) { if (F == null) F = new byte[K.Length]; F[N] = flags; }
            else if (F != null) F[N] = 0;
            if (_idx != null) _idx[k] = N;
            else if (N >= 12) { _idx = new Dictionary<string, int>(N * 2); for (int i = 0; i <= N; i++) _idx[K[i]] = i; }
            if (!_intKeys && k.Length > 0 && k[0] >= '0' && k[0] <= '9' && Rt.IsIndexKey(k)) _intKeys = true;
            return N++;
        }
        internal void RemoveSlot(int i)
        {
            N--;
            Array.Copy(K, i + 1, K, i, N - i); Array.Copy(Vs, i + 1, Vs, i, N - i); if (F != null) Array.Copy(F, i + 1, F, i, N - i);
            K[N] = null; Vs[N] = default;
            if (_idx != null) { _idx.Clear(); for (int j = 0; j < N; j++) _idx[K[j]] = j; }
        }
        internal byte FlagsAt(int i) => F == null ? (byte)0 : F[i];
        /// <summary>Whether it has an own enumerable property (for-in walks its prototypes only when they do).</summary>
        internal virtual bool HasEnumerable()
        {
            if (F == null) return N > 0;
            for (int i = 0; i < N; i++) if ((F[i] & 1) == 0) return true;
            return false;
        }

        /// <summary>An own property's value (an accessor's getter called on this object).</summary>
        public virtual bool GetOwn(string k, out V v)
        {
            int i = Find(k);
            if (i < 0) { v = default; return false; }
            v = (FlagsAt(i) & 2) != 0 ? CallGetter(Vs[i], new V(this, 0)) : Vs[i];
            return true;
        }
        public virtual bool HasOwn(string k) => Find(k) >= 0;

        static V CallGetter(V acc, V receiver)
        {
            var a = (Accessor)acc.O;
            return a.Get.O is JsFunction g ? g.Fn(receiver, 0, default, default, default, default, null) : default;
        }

        /// <summary>[[Get]]: own, then the prototypes', accessors called on `receiver`.</summary>
        public virtual V Get(string k, V receiver)
        {
            for (var o = this; o != null; o = o.Proto)
            {
                if (o.Special) { if (o.GetSpecial(k, receiver, out var sv)) return sv; }
                int i = o.Find(k);
                if (i >= 0) return (o.FlagsAt(i) & 2) != 0 ? CallGetter(o.Vs[i], receiver) : o.Vs[i];
            }
            return default;
        }
        public V Get(string k) => Get(k, new V(this, 0));

        /// <summary>Objects whose own properties aren't all in the slots (arrays' length and items, functions'
        /// prototype, strings...): GetSpecial / SetSpecial are asked first.</summary>
        internal bool Special;
        internal virtual bool GetSpecial(string k, V receiver, out V v) { v = default; return false; }
        internal virtual bool SetSpecial(string k, V v) => false;

        /// <summary>[[Set]]: an own data property is written; else a setter up the chain is called, a read-only one
        /// refuses, or a new own property is made.</summary>
        public virtual void Set(string k, V v)
        {
            if (Special && SetSpecial(k, v)) return;
            int i = Find(k);
            if (i >= 0)
            {
                byte f = FlagsAt(i);
                if (f == 0) { Vs[i] = v; return; }
                if ((f & 2) != 0) { CallSetter(Vs[i], v); return; }
                if ((f & 4) == 0) Vs[i] = v;
                return;
            }
            for (var o = Proto; o != null; o = o.Proto)
            {
                int j = o.Find(k);
                if (j < 0) continue;
                byte f = o.FlagsAt(j);
                if ((f & 2) != 0) { CallSetter(o.Vs[j], v); return; }
                if ((f & 4) != 0) return;
                break;
            }
            if (!Extensible) return;
            AddSlot(k, v, 0);
        }
        public bool Extensible = true;
        void CallSetter(V acc, V v)
        {
            var a = (Accessor)acc.O;
            if (a.Set.O is JsFunction s) s.Fn(new V(this, 0), 1, v, default, default, default, null);
        }

        /// <summary>Makes or replaces an own data property (an object literal's, defineProperty's).</summary>
        public void Put(string k, V v, byte flags = 0)
        {
            int i = Find(k);
            if (i >= 0) { Vs[i] = v; if (flags != 0 || F != null) { if (F == null) F = new byte[K.Length]; F[i] = flags; } return; }
            AddSlot(k, v, flags);
        }
        public void PutAccessor(string k, V getter, V setter, bool enumerable)
        {
            int i = Find(k);
            byte fl = (byte)(2 | (enumerable ? 0 : 1));
            if (i >= 0 && (FlagsAt(i) & 2) != 0)
            {
                var a = (Accessor)Vs[i].O;
                if (!getter.IsUndef) a.Get = getter;
                if (!setter.IsUndef) a.Set = setter;
                return;
            }
            var acc = new V(new Accessor { Get = getter, Set = setter }, 0);
            if (i >= 0) { Vs[i] = acc; if (F == null) F = new byte[K.Length]; F[i] = fl; return; }
            AddSlot(k, acc, fl);
        }

        public virtual bool Delete(string k)
        {
            int i = Find(k);
            if (i >= 0) RemoveSlot(i);
            return true;
        }

        /// <summary>Own string keys in JS order: array indexes ascending, then the rest as they were made.</summary>
        public virtual List<string> OwnKeys(bool enumerableOnly)
        {
            var l = new List<string>(N);
            for (int i = 0; i < N; i++) if (!enumerableOnly || (FlagsAt(i) & 1) == 0) l.Add(K[i]);
            if (_intKeys) SortIndexKeys(l);
            return l;
        }
        internal static void SortIndexKeys(List<string> l)
        {
            var idx = new List<(double, string)>(); var rest = new List<string>();
            foreach (var k in l) { if (Rt.IsIndexKey(k)) idx.Add((double.Parse(k, System.Globalization.CultureInfo.InvariantCulture), k)); else rest.Add(k); }
            if (idx.Count == 0) return;
            idx.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            l.Clear(); foreach (var p in idx) l.Add(p.Item2); l.AddRange(rest);
        }

        // ---------- the compiled code's object-literal builder (NewObj(n).Put(...).Getter(...).V)
        public JsObject Put(string k, V v) { Put(k, v, 0); return this; }
        public JsObject PutK(V k, V v) { Put(Rt.ToKey(k), v, 0); return this; }
        public JsObject Getter(string k, V f) { PutAccessor(k, f, default, true); return this; }
        public JsObject Setter(string k, V f) { PutAccessor(k, default, f, true); return this; }
        public JsObject GetterK(V k, V f) => Getter(Rt.ToKey(k), f);
        public JsObject SetterK(V k, V f) => Setter(Rt.ToKey(k), f);
        public JsObject Spread(V src)
        {
            if (src.O is JsObject o) foreach (var k in o.OwnKeys(true)) Put(k, o.Get(k, src), 0);
            else if (src.O is string s) for (int i = 0; i < s.Length; i++) Put(Rt.IndexKey(i), s[i].ToString(), 0);
            return this;
        }
    }

    public sealed class JsArray : JsObject
    {
        internal V[] A;
        internal int Len;
        public JsArray() : base(Rt.ArrayProto) { A = Empty; Special = true; }
        public JsArray(int cap) : base(Rt.ArrayProto) { A = cap > 0 ? new V[cap] : Empty; Special = true; }
        public JsArray(V[] items) : base(Rt.ArrayProto) { A = items; Len = items.Length; Special = true; }
        static readonly V[] Empty = new V[0];
        public override string ClassName => "Array";
        public int Count => Len;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public V At(int i) { if ((uint)i < (uint)Len) { var v = A[i]; return v.O == Tag.Hole ? default : v; } return default; }
        internal bool HasAt(int i) => (uint)i < (uint)Len && A[i].O != Tag.Hole;
        public void Push(V v) { if (Len == A.Length) Array.Resize(ref A, Len < 16 ? 16 : Len * 2); A[Len++] = v; }
        public void SetAt(int i, V v)
        {
            if (i < Len) { A[i] = v; return; }
            if (i >= A.Length) Array.Resize(ref A, Math.Max(i + 1, Math.Max(4, A.Length * 2)));
            for (int j = Len; j < i; j++) A[j] = V.HoleV;
            A[i] = v; Len = i + 1;
        }
        public void SetLength(int n)
        {
            if (n < Len) { Array.Clear(A, n, Len - n); Len = n; return; }
            if (n > A.Length) Array.Resize(ref A, n);
            for (int j = Len; j < n; j++) A[j] = V.HoleV;
            Len = n;
        }
        internal override bool GetSpecial(string k, V receiver, out V v)
        {
            if (k.Length == 6 && k == "length") { v = Len; return true; }
            if (k.Length > 0 && k[0] >= '0' && k[0] <= '9' && Rt.IsIndexKey(k)) { int i = int.Parse(k, System.Globalization.CultureInfo.InvariantCulture); v = At(i); return HasAt(i); }
            v = default; return false;
        }
        internal override bool SetSpecial(string k, V v)
        {
            if (k == "length") { SetLength((int)Rt.ToUint32(Rt.ToNum(v))); return true; }
            if (k.Length > 0 && k[0] >= '0' && k[0] <= '9' && Rt.IsIndexKey(k)) { SetAt(int.Parse(k, System.Globalization.CultureInfo.InvariantCulture), v); return true; }
            return false;
        }
        public override bool GetOwn(string k, out V v) { if (GetSpecial(k, new V(this, 0), out v)) return true; return base.GetOwn(k, out v); }
        public override bool HasOwn(string k) => GetSpecial(k, default, out _) || base.HasOwn(k);
        public override bool Delete(string k)
        {
            if (k.Length > 0 && k[0] >= '0' && k[0] <= '9' && Rt.IsIndexKey(k)) { int i = int.Parse(k, System.Globalization.CultureInfo.InvariantCulture); if (i < Len) A[i] = V.HoleV; return true; }
            return base.Delete(k);
        }
        internal override bool HasEnumerable() => Len > 0 || base.HasEnumerable();
        public override List<string> OwnKeys(bool enumerableOnly)
        {
            var l = new List<string>(Len + N);
            for (int i = 0; i < Len; i++) if (A[i].O != Tag.Hole) l.Add(Rt.IndexKey(i));
            if (!enumerableOnly) l.Add("length");
            l.AddRange(base.OwnKeys(enumerableOnly));
            return l;
        }
    }

    public sealed class JsFunction : JsObject
    {
        public readonly JsFn Fn;
        public readonly int Arity;
        public readonly string Name;
        public readonly bool Arrow;
        /// <summary>A built-in constructor's own `new` (Map, Set, Promise...); null: the ordinary one.</summary>
        public Func<JsFunction, int, V, V, V, V, V[], V> Ctor;
        bool _protoMade;
        public JsFunction(JsFn fn, int arity, string name, bool arrow, bool native = false) : base(Rt.FunctionProto)
        {
            Fn = fn; Arity = arity; Name = name ?? ""; Arrow = arrow; Special = true; _protoMade = arrow || native;
        }
        public override string ClassName => "Function";
        void MakeProto()
        {
            _protoMade = true;
            if (Find("prototype") >= 0) return;
            var p = new JsObject(Rt.ObjectProto);
            p.Put("constructor", new V(this, 0), 1);
            Put("prototype", p.V, 1);
        }
        internal override bool GetSpecial(string k, V receiver, out V v)
        {
            if (!_protoMade && k == "prototype") MakeProto();
            if (k == "length" && Find("length") < 0) { v = Arity; return true; }
            if (k == "name" && Find("name") < 0) { v = Name; return true; }
            v = default; return false;
        }
        internal override bool SetSpecial(string k, V v)
        {
            if (!_protoMade && k == "prototype") _protoMade = true;
            return false;
        }
        public override bool HasOwn(string k) => k == "length" || k == "name" || (k == "prototype" && !Arrow) || base.HasOwn(k);
    }

    /// <summary>A class (the one in rive-rig.js: Fol): its constructor, methods on its prototype.</summary>
    public sealed class ClassBuilder
    {
        readonly JsFunction _f;
        public ClassBuilder(JsFunction f) { _f = f; }
        JsObject Proto => (JsObject)_f.Get("prototype").O;
        public ClassBuilder Method(V k, V fn) { Proto.Put(Rt.ToKey(k), fn, 1); return this; }
        public ClassBuilder Static(V k, V fn) { _f.Put(Rt.ToKey(k), fn, 1); return this; }
        public ClassBuilder ProtoGetter(V k, V fn) { Proto.PutAccessor(Rt.ToKey(k), fn, default, false); return this; }
        public ClassBuilder ProtoSetter(V k, V fn) { Proto.PutAccessor(Rt.ToKey(k), default, fn, false); return this; }
        public V V => new V(_f, 0);
    }

    /// <summary>An array literal with spreads: [a, ...b, c].</summary>
    public sealed class ArrBuilder
    {
        readonly JsArray _a = new JsArray();
        public ArrBuilder Add(V v) { _a.Push(v); return this; }
        public ArrBuilder Spread(V v) { foreach (var x in Rt.Iterate(v)) _a.Push(x); return this; }
        public V V => new V(_a, 0);
        internal JsArray Array => _a;
    }
}
