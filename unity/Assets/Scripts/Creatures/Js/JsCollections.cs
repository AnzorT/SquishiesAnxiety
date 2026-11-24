// Map, Set (insertion order, SameValueZero keys), iterators, typed arrays (over a shared byte buffer: dom-shim.js's
// nextUp reads a float's bits through a Uint32Array), promises and the microtask queue they run on.
using System;
using System.Collections.Generic;

namespace SquishSquad.Creatures.Js
{
    /// <summary>A Map / Set key: numbers by value (NaN equal to itself, -0 as 0), strings by text, the rest by reference.</summary>
    readonly struct MapKey : IEquatable<MapKey>
    {
        readonly object _o; readonly double _d;
        public MapKey(V v) { _o = v.O; _d = v.O == Tag.Num ? (v.D == 0 ? 0 : v.D) : 0; }
        public bool Equals(MapKey k)
        {
            if (_o == Tag.Num) return k._o == Tag.Num && (_d == k._d || (double.IsNaN(_d) && double.IsNaN(k._d)));
            if (_o is string s) return k._o is string t && s == t;
            return _o == k._o;
        }
        public override bool Equals(object obj) => obj is MapKey k && Equals(k);
        public override int GetHashCode() => _o == Tag.Num ? (double.IsNaN(_d) ? 1 : _d.GetHashCode()) : _o is string s ? s.GetHashCode() : _o == null ? 0 : System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(_o);
    }

    public class JsMap : JsObject
    {
        internal readonly List<V> Keys = new List<V>();
        internal readonly List<V> Vals = new List<V>();
        internal readonly List<bool> Live = new List<bool>();
        readonly Dictionary<MapKey, int> _ix = new Dictionary<MapKey, int>();
        int _count;
        public JsMap(JsObject proto) : base(proto) { }
        public override string ClassName => "Map";
        public int Size => _count;
        public bool Has(V k) => _ix.ContainsKey(new MapKey(k));
        public V GetV(V k) => _ix.TryGetValue(new MapKey(k), out int i) ? Vals[i] : default;
        public void SetV(V k, V v)
        {
            var mk = new MapKey(k);
            if (_ix.TryGetValue(mk, out int i)) { Vals[i] = v; return; }
            if (k.O == Tag.Num && k.D == 0) k = 0.0;
            _ix[mk] = Keys.Count; Keys.Add(k); Vals.Add(v); Live.Add(true); _count++;
        }
        public bool DeleteV(V k)
        {
            var mk = new MapKey(k);
            if (!_ix.TryGetValue(mk, out int i)) return false;
            _ix.Remove(mk); Live[i] = false; Keys[i] = default; Vals[i] = default; _count--;
            return true;
        }
        public void Clear() { for (int i = 0; i < Live.Count; i++) Live[i] = false; _ix.Clear(); _count = 0; }
        // live: entries added while iterating are visited, deleted ones aren't
        public IEnumerable<V> Entries() { for (int i = 0; i < Keys.Count; i++) if (Live[i]) yield return Rt.Arr(Keys[i], Vals[i]); }
        public IEnumerable<V> KeysSeq() { for (int i = 0; i < Keys.Count; i++) if (Live[i]) yield return Keys[i]; }
        public IEnumerable<V> ValuesSeq() { for (int i = 0; i < Keys.Count; i++) if (Live[i]) yield return Vals[i]; }
    }

    public sealed class JsSet : JsMap
    {
        public JsSet(JsObject proto) : base(proto) { }
        public override string ClassName => "Set";
        public IEnumerable<V> Values() => KeysSeq();
    }

    /// <summary>An iterator object (map.keys(), matchAll...): next() and for-of.</summary>
    public sealed class JsIterator : JsObject
    {
        readonly IEnumerator<V> _e;
        bool _done;
        public JsIterator(IEnumerable<V> seq) : base(Rt.IteratorProto) { _e = seq.GetEnumerator(); }
        public bool Next(out V v)
        {
            if (!_done && _e.MoveNext()) { v = _e.Current; return true; }
            _done = true; v = default; return false;
        }
    }

    public sealed class JsArrayBuffer : JsObject
    {
        public readonly byte[] Bytes;
        public JsArrayBuffer(int n) : base(Rt.ObjectProto) { Bytes = new byte[n]; }
        public override string ClassName => "ArrayBuffer";
    }

    public sealed class JsTypedArray : JsObject
    {
        public enum Kind { F32, F64, U32, I32, U8, U8C, I8, U16, I16 }
        public readonly Kind K;
        public readonly JsArrayBuffer Buf;
        readonly int _off, _size;
        public readonly int Length;
        public JsTypedArray(Kind k, JsObject proto, JsArrayBuffer buf, int off, int len) : base(proto)
        {
            K = k; Buf = buf; _off = off; Length = len; _size = SizeOf(k); Special = true;
        }
        public static int SizeOf(Kind k) => k == Kind.F64 ? 8 : k == Kind.F32 || k == Kind.U32 || k == Kind.I32 ? 4 : k == Kind.U16 || k == Kind.I16 ? 2 : 1;
        public override string ClassName => K.ToString();
        public V GetAt(int i)
        {
            int p = _off + i * _size;
            var b = Buf.Bytes;
            switch (K)
            {
                case Kind.F32: return (double)BitConverter.ToSingle(b, p);
                case Kind.F64: return BitConverter.ToDouble(b, p);
                case Kind.U32: return (double)BitConverter.ToUInt32(b, p);
                case Kind.I32: return (double)BitConverter.ToInt32(b, p);
                case Kind.U16: return (double)BitConverter.ToUInt16(b, p);
                case Kind.I16: return (double)BitConverter.ToInt16(b, p);
                case Kind.I8: return (double)(sbyte)b[p];
                default: return (double)b[p];
            }
        }
        public void SetAt(int i, double d)
        {
            int p = _off + i * _size;
            var b = Buf.Bytes;
            switch (K)
            {
                case Kind.F32: Write(b, p, BitConverter.GetBytes((float)d)); break;
                case Kind.F64: Write(b, p, BitConverter.GetBytes(d)); break;
                case Kind.U32: Write(b, p, BitConverter.GetBytes(Rt.ToUint32(d))); break;
                case Kind.I32: Write(b, p, BitConverter.GetBytes(Rt.ToInt32(d))); break;
                case Kind.U16: Write(b, p, BitConverter.GetBytes((ushort)Rt.ToInt32(d))); break;
                case Kind.I16: Write(b, p, BitConverter.GetBytes((short)Rt.ToInt32(d))); break;
                case Kind.U8C:
                    {
                        double c = double.IsNaN(d) ? 0 : d < 0 ? 0 : d > 255 ? 255 : d;
                        b[p] = (byte)Math.Round(c, MidpointRounding.ToEven);
                        break;
                    }
                default: b[p] = (byte)Rt.ToInt32(d); break;
            }
        }
        static void Write(byte[] b, int p, byte[] v) { Buffer.BlockCopy(v, 0, b, p, v.Length); }
        internal override bool GetSpecial(string k, V receiver, out V v)
        {
            if (k == "length") { v = Length; return true; }
            if (k == "buffer") { v = Buf.V; return true; }
            if (Rt.IsIndexKey(k)) { int i = int.Parse(k); v = i < Length ? GetAt(i) : default; return true; }
            v = default; return false;
        }
        internal override bool SetSpecial(string k, V v)
        {
            if (Rt.IsIndexKey(k)) { int i = int.Parse(k); if (i < Length) SetAt(i, Rt.ToNum(v)); return true; }
            return false;
        }
    }

    public sealed class JsPromise : JsObject
    {
        public enum St { Pending, Fulfilled, Rejected }
        public St State;
        public V Value;
        readonly List<(JsPromise next, V onOk, V onErr)> _then = new List<(JsPromise, V, V)>();
        public JsPromise() : base(Rt.PromiseProto) { }
        public override string ClassName => "Promise";

        public void Resolve(V v)
        {
            if (State != St.Pending) return;
            if (v.O == this) { Reject(Rt.MakeError("TypeError", "Chaining cycle detected for promise").V); return; }
            if (v.O is JsObject o)
            {
                V then;
                try { then = o.Get("then", v); } catch (Exception e) { Reject(Rt.Caught(e)); return; }
                if (then.O is JsFunction tf)
                {
                    bool called = false;
                    Rt.Enqueue(() =>
                    {
                        try
                        {
                            tf.Fn(v, 2, Rt.Fn((s, n, a, b, c, d, r) => { if (!called) { called = true; Resolve(a); } return default; }, 1, "", true),
                                Rt.Fn((s, n, a, b, c, d, r) => { if (!called) { called = true; Reject(a); } return default; }, 1, "", true), default, default, null);
                        }
                        catch (Exception e) { if (!called) { called = true; Reject(Rt.Caught(e)); } }
                    });
                    return;
                }
            }
            State = St.Fulfilled; Value = v; Flush();
        }
        public void Reject(V v) { if (State != St.Pending) return; State = St.Rejected; Value = v; Flush(); }
        void Flush()
        {
            var l = _then.ToArray(); _then.Clear();
            foreach (var t in l) Schedule(t.next, t.onOk, t.onErr);
        }
        void Schedule(JsPromise next, V onOk, V onErr)
        {
            var st = State; var val = Value;
            Rt.Enqueue(() =>
            {
                var h = st == St.Fulfilled ? onOk : onErr;
                if (!(h.O is JsFunction f)) { if (st == St.Fulfilled) next.Resolve(val); else next.Reject(val); return; }
                try { next.Resolve(f.Fn(default, 1, val, default, default, default, null)); }
                catch (Exception e) { next.Reject(Rt.Caught(e)); }
            });
        }
        public JsPromise Then(V onOk, V onErr)
        {
            var next = new JsPromise();
            if (State == St.Pending) _then.Add((next, onOk, onErr)); else Schedule(next, onOk, onErr);
            return next;
        }
    }

    public static partial class Rt
    {
        public static JsObject IteratorProto, PromiseProto, MapProto, SetProto;
        static readonly Queue<Action> Jobs = new Queue<Action>();
        public static void Enqueue(Action a) => Jobs.Enqueue(a);
        /// <summary>Runs the promise jobs queued (and those they queue) to the end: what an engine does when the stack
        /// empties.</summary>
        public static void RunMicrotasks()
        {
            int guard = 0;
            while (Jobs.Count > 0 && guard++ < 1000000)
            {
                var j = Jobs.Dequeue();
                try { j(); } catch (Exception e) { Caught(e); }
            }
        }
    }
}
