// Strings built without the garbage: the rig writes its path data as `s += r2(x) + ' ' + r2(y) + ' '` point after
// point, which in C# would copy the whole string at every step and make a string for every number. jsc.mjs gives such
// a variable (a let that's only ever a string added to) a JsStrBuf: the parts, numbers too, written into one growing
// buffer, the string made once when it's read. A concatenation `'M' + x + ' ' + y` is written the same way into a
// buffer lent for the expression (Cat.Begin ... End). Same characters as JS's + (numbers as Number::toString).
using System;
using System.Runtime.CompilerServices;

namespace SquishSquad.Creatures.Js
{
    public sealed class JsStrBuf
    {
        char[] _b;
        int _n;
        string _s;
        public JsStrBuf(string init) { _b = new char[Math.Max(64, init.Length * 2)]; Append(init); _s = init; }
        JsStrBuf(int cap) { _b = new char[cap]; }

        /// <summary>The string so far (made once until the next part is added).</summary>
        public string Str => _s ?? (_s = new string(_b, 0, _n));
        public int Length => _n;

        void Append(string s)
        {
            int k = s.Length;
            if (_n + k > _b.Length) Grow(k);
            s.CopyTo(0, _b, _n, k);
            _n += k;
        }
        void Grow(int k) { var nb = new char[Math.Max(_b.Length * 2, _n + k + 16)]; Array.Copy(_b, nb, _n); _b = nb; }
        internal void Put(char c) { if (_n == _b.Length) Grow(1); _b[_n++] = c; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public JsStrBuf S(string s) { _s = null; Append(s); return this; }
        public JsStrBuf N(double d) { _s = null; JsNumber.Write(this, d); return this; }
        public JsStrBuf V(V v)
        {
            _s = null;
            if (v.O == Tag.Num) JsNumber.Write(this, v.D);
            else if (v.O is string s) Append(s);
            else Append(Rt.ToStr(v));
            return this;
        }
        public JsStrBuf B(bool b) { _s = null; Append(b ? "true" : "false"); return this; }
        /// <summary>s = value: the buffer starts again.</summary>
        public JsStrBuf Set(string s) { _n = 0; Append(s); _s = s; return this; }

        // ---- a concatenation's buffer: a stack, as concatenations nest (a part can be a call that concatenates)
        [ThreadStatic] static JsStrBuf[] _cat;
        [ThreadStatic] static int _depth;
        public static JsStrBuf Begin()
        {
            var c = _cat ?? (_cat = new JsStrBuf[16]);
            if (_depth >= c.Length) Array.Resize(ref _cat, c.Length * 2);
            var b = _cat[_depth] ?? (_cat[_depth] = new JsStrBuf(256));
            _depth++;
            b._n = 0; b._s = null;
            return b;
        }
        /// <summary>The concatenation's string; its buffer goes back.</summary>
        public string End() { if (_depth > 0) _depth--; return new string(_b, 0, _n); }
        /// <summary>No concatenation is half done (a throw in the middle of one leaves its buffer lent): the host calls
        /// this between frames.</summary>
        public static void ResetCat() => _depth = 0;
    }

    /// <summary>for-of without an enumerator object for arrays (the common case): a struct foreach can use.</summary>
    public struct JsIter
    {
        readonly JsArray _a;
        readonly System.Collections.Generic.IEnumerator<V> _e;
        int _i;
        V _cur;
        public JsIter(V v)
        {
            _a = v.O as JsArray; _i = -1; _cur = default;
            _e = _a == null ? Rt.Iterate(v).GetEnumerator() : null;
        }
        public JsIter GetEnumerator() => this;
        public bool MoveNext()
        {
            if (_a != null) { if (++_i < _a.Len) { _cur = _a.At(_i); return true; } return false; }
            if (_e.MoveNext()) { _cur = _e.Current; return true; }
            return false;
        }
        public V Current => _cur;
    }
}
