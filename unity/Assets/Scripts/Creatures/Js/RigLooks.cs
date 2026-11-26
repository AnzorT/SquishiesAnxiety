// The creatures' border looks on the live rigs (2026-11-26, the user: "i want all of them to have the number 3"):
// Firestore config/roster's `look` (everyone; 4 when unset) and `looks` (single creatures), as the app reads them
// (src/squad/looks.js lookOf): 1 shading only, 2 thin ink line, 3 bold ink line, 4 bold line in each part's own darker
// colour, 0 none. The rig draws the look itself (rive-rig.js applyLook / outline, with the stand-in's geometry:
// tools/unity/rig/dom-shim.js); native-host.js gives every creature mounted its look (__native.looks), and a change
// reaches the creatures already on screen. Screens/RosterConfig sets it from the document (and the last one read, kept
// in PlayerPrefs, from the start). A creature with no look pictures (KeysOf: the ones the look stills have) gets none,
// as the app's rigLookOf. Unity-free (the rig tests build it with dotnet).
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.Creatures.Js
{
    public static class RigLooks
    {
        public const int Default = 4;
        static int _n = Default;
        static Dictionary<string, int> _over = new Dictionary<string, int>();
        static List<string> _keys;
        static bool _pushed;

        /// <summary>Everyone's look (0-4).</summary>
        public static int N => _n;

        /// <summary>The creatures with look pictures (null: every creature); asked by Set, on the caller's thread (it
        /// may read Unity's Resources), never on the rig's.</summary>
        public static Func<IList<string>> KeysOf;

        /// <summary>The look a creature's rig is drawn in.</summary>
        public static int Of(string key)
        {
            var keys = _keys;
            if (keys != null && key != null && !keys.Contains(key)) return 0;
            return key != null && _over.TryGetValue(key, out var m) ? m : _n;
        }

        /// <summary>Sets the looks (`over` by creature key) and hands them to the rig now if it runs, else when it
        /// boots. Nothing happens when they're the ones it already has.</summary>
        public static void Set(int n, IDictionary<string, int> over)
        {
            n = Clamp(n);
            var o = new Dictionary<string, int>();
            if (over != null) foreach (var kv in over) if (!string.IsNullOrEmpty(kv.Key)) o[kv.Key] = Clamp(kv.Value);
            var k = SafeKeys();
            var keys = k != null ? new List<string>(k) : null;
            if (_pushed && n == _n && Same(o, _over) && SameList(keys, _keys)) return;
            _n = n; _over = o; _keys = keys;
            if (RigHost.Booted) RigThread.Run(Push);
        }

        /// <summary>On the rig thread: the looks into the realm (RigHost calls it once it has booted).</summary>
        internal static void Push()
        {
            try
            {
                var keys = _keys;
                Rt.InvokeSpread(Rt.G("__native"), "looks", new JsArray(new V[] { _n, Json(_over), keys != null ? (V)JsonList(keys) : V.Null }).V);
                Rt.RunMicrotasks();
                _pushed = true;
            }
            catch (Exception) { /* (an old realm without looks: the rig's own default) */ }
        }

        static IList<string> SafeKeys() { try { return KeysOf?.Invoke(); } catch (Exception) { return null; } }
        static int Clamp(int n) => n < 0 ? 0 : n > 4 ? 4 : n;
        static bool SameList(List<string> a, List<string> b)
        {
            if (a == null || b == null) return a == b;
            if (a.Count != b.Count) return false;
            for (int i = 0; i < a.Count; i++) if (a[i] != b[i]) return false;
            return true;
        }
        static bool Same(Dictionary<string, int> a, Dictionary<string, int> b)
        {
            if (a.Count != b.Count) return false;
            foreach (var kv in a) if (!b.TryGetValue(kv.Key, out var v) || v != kv.Value) return false;
            return true;
        }
        static string Json(Dictionary<string, int> o)
        {
            var sb = new StringBuilder("{");
            foreach (var kv in o) { if (sb.Length > 1) sb.Append(','); Str(sb, kv.Key); sb.Append(':').Append(kv.Value); }
            return sb.Append('}').ToString();
        }
        static string JsonList(IList<string> keys)
        {
            var sb = new StringBuilder("[");
            for (int i = 0; i < keys.Count; i++) { if (i > 0) sb.Append(','); Str(sb, keys[i]); }
            return sb.Append(']').ToString();
        }
        static void Str(StringBuilder sb, string s)
        {
            sb.Append('"');
            foreach (var c in s)
            {
                if (c == '"' || c == '\\') sb.Append('\\').Append(c);
                else if (c < ' ') sb.Append("\\u").Append(((int)c).ToString("x4"));
                else sb.Append(c);
            }
            sb.Append('"');
        }
    }
}
