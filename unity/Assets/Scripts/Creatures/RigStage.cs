// A mini-game's rig stage: the app's own page that draws the game's squishies as live rigs (tools/rig/sort.html for
// Squish Sort, tools/rig/hop.html for Squish Hop), its script compiled into the rig's realm by tools/unity/rig/jsc.mjs
// (in a window of its own) and talked to through tools/unity/rig/stage-host.js. The game calls it as the app's game
// calls src/hop/RigStage.js (cast, hold, correct...; hop, bump...), the page runs its moves on the rig's one clock, and
// each frame the screen reads every squishy back (where the page put its box, how opaque, its z, whether its rig drew)
// and draws it with CreatureView (Creatures/StageView.cs). Unity-free.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Creatures.Js;
using SquishSquad.Vector;

namespace SquishSquad.Creatures
{
    /// <summary>A rig that may not have drawn since the last frame (CreatureView then keeps its picture).</summary>
    public interface IRigDirty { bool Dirty { get; } }

    public sealed class RigStage
    {
        public readonly string Page;
        public RigStage(string page) { Page = page; }

        static V H => Rt.G("__stage");
        /// <summary>Whether the realm has this page (compiled in) and it has booted.</summary>
        public bool Ready { get { try { return RigThread.Run(() => !H.IsNullish && Rt.Truthy(Rt.Invoke(H, "ready", Page))); } catch (Exception) { return false; } } }

        /// <summary>The play area, dp (the page's innerWidth / innerHeight).</summary>
        public void Size(double w, double h) => RigThread.Run(() => { if (!H.IsNullish) Rt.Invoke(H, "size", Page, w, h); });

        /// <summary>One of the stage's calls, its arguments as the app passes them (numbers, strings, bools, null, lists,
        /// dictionaries). False when the page has no such call (or isn't up).</summary>
        public bool Call(string fn, params object[] args)
        {
            var json = new StringBuilder();
            Json(json, args);
            var text = json.ToString();
            return RigThread.Run(() =>
            {
                if (H.IsNullish) return false;
                var r = Rt.Invoke(H, "call", Page, fn, text);
                Rt.RunMicrotasks();
                return Rt.Truthy(r);
            });
        }

        /// <summary>What the page posted since the last call: ("ready" | "cast" | "error", the message's fields).</summary>
        public List<Dictionary<string, object>> Messages() => RigThread.Run(MessagesHere);
        List<Dictionary<string, object>> MessagesHere()
        {
            var o = new List<Dictionary<string, object>>();
            if (H.IsNullish) return o;
            var arr = Rt.Invoke(Rt.G("JSON"), "parse", Rt.Invoke(H, "out", Page));
            if (!(arr.O is JsArray a)) return o;
            for (int i = 0; i < a.Len; i++)
            {
                var m = a.At(i); var d = new Dictionary<string, object>();
                foreach (var k in new[] { "type", "tag", "ok", "key", "message" })
                {
                    var v = Rt.Get(m, k);
                    if (v.IsNullish) continue;
                    d[k] = v.O is string s ? s : v.IsBool ? (object)Rt.Truthy(v) : Rt.ToNum(v);
                }
                o.Add(d);
            }
            return o;
        }

        /// <summary>A squishy as the page placed it this frame.</summary>
        public sealed class Item
        {
            public string Id, Key;
            public V Host;
            /// <summary>Its rig's 0-100 box onto the play area (dp, y down).</summary>
            public Affine Box;
            public double Opacity, Z;
            /// <summary>Whether its rig drew this frame (sort.html lets only the moving ones draw).</summary>
            public bool Drew;
            public int Index;
            /// <summary>sort.html's floor shadow (.sh: a 100 x 100 round radial gradient): its box, opacity and z.</summary>
            public bool HasShadow;
            public Affine ShadowBox;
            public double ShadowOpacity, ShadowZ;
        }

        /// <summary>Every squishy now, in the order the page added them.</summary>
        public List<Item> Read() => RigThread.Run(ReadHere);
        List<Item> ReadHere()
        {
            var o = new List<Item>();
            if (H.IsNullish) return o;
            if (!(Rt.Invoke(H, "read", Page).O is JsArray a)) return o;
            for (int i = 0; i < a.Len; i++)
            {
                if (!(a.At(i).O is JsArray r) || r.Len < 12) continue;
                double N(int j) => Rt.ToNum(r.At(j));
                var it = new Item
                {
                    Id = Rt.ToStr(r.At(0)), Key = Rt.ToStr(r.At(1)), Host = r.At(2),
                    Box = new Affine(N(3), N(4), N(5), N(6), N(7), N(8)), Opacity = N(9), Z = N(10), Drew = N(11) != 0, Index = i,
                };
                if (r.Len >= 20) { it.HasShadow = true; it.ShadowBox = new Affine(N(12), N(13), N(14), N(15), N(16), N(17)); it.ShadowOpacity = N(18); it.ShadowZ = N(19); }
                o.Add(it);
            }
            return o;
        }

        /// <summary>The board's clip (sort.html's doors shutting over the shelves): the band of x kept, dp; null: none.</summary>
        public (double left, double right)? Clip() => RigThread.Run<(double, double)?>(() =>
        {
            if (H.IsNullish) return null;
            if (!(Rt.Invoke(H, "clip", Page).O is JsArray a) || a.Len < 2) return null;
            return (Rt.ToNum(a.At(0)), Rt.ToNum(a.At(1)));
        });

        // ---- the arguments as JSON ----
        static void Json(StringBuilder sb, object v)
        {
            switch (v)
            {
                case null: sb.Append("null"); return;
                case string s: Str(sb, s); return;
                case bool b: sb.Append(b ? "true" : "false"); return;
                case double d: Num(sb, d); return;
                case float f: Num(sb, f); return;
                case int n: sb.Append(n.ToString(CultureInfo.InvariantCulture)); return;
                case long l: sb.Append(l.ToString(CultureInfo.InvariantCulture)); return;
                case IDictionary<string, object> m:
                    {
                        sb.Append('{'); bool first = true;
                        foreach (var kv in m) { if (!first) sb.Append(','); first = false; Str(sb, kv.Key); sb.Append(':'); Json(sb, kv.Value); }
                        sb.Append('}'); return;
                    }
                case IEnumerable e:
                    {
                        sb.Append('['); bool first = true;
                        foreach (var x in e) { if (!first) sb.Append(','); first = false; Json(sb, x); }
                        sb.Append(']'); return;
                    }
                default: Num(sb, Convert.ToDouble(v, CultureInfo.InvariantCulture)); return;
            }
        }
        static void Num(StringBuilder sb, double d) => sb.Append(double.IsNaN(d) || double.IsInfinity(d) ? "null" : d.ToString("R", CultureInfo.InvariantCulture));
        static void Str(StringBuilder sb, string s)
        {
            sb.Append('"');
            foreach (char c in s)
            {
                if (c == '"' || c == '\\') sb.Append('\\').Append(c);
                else if (c < 0x20) sb.Append("\\u").Append(((int)c).ToString("x4"));
                else sb.Append(c);
            }
            sb.Append('"');
        }
    }

    /// <summary>A squishy's rig on a stage page (its host: the .ch box's inner div) for CreatureView: its tree straight
    /// from the stand-in, with the page's one CSS rule on the rig's own floor shadow (sort.html hides it, hop.html dims
    /// it to 0.45); `Dirty` as the stage says it drew.</summary>
    public sealed class StageRig
#if UNITY_5_3_OR_NEWER
        : IRigFrames, IRigTree, IRigDirty
#else
        : IRigDirty
#endif
    {
        readonly V _host; readonly RigTree _tree = new RigTree();
        readonly double _shadowOpacity;   // 0: hidden
        public bool Dirty { get; set; } = true;
        public StageRig(V host, double shadowOpacity) { _host = host; _shadowOpacity = shadowOpacity; }
        public string FrameAt(float s) => RigThread.Run(() => { var svg = Dom.FirstSvg(_host); return svg.IsNullish ? null : Dom.Serialize(svg); });
        public SvgNode TreeAt(float s) => RigThread.Run(() =>
        {
            var svg = Dom.FirstSvg(_host);
            if (svg.IsNullish) return null;
            var t = _tree.Build(svg);
            if (t != null) Shadow(t);
            return t;
        });
        public void Play(string move) { }

        // .ch ellipse[fill="#6a1b9a"] { display: none } (sort) / { opacity: 0.45 } (hop)
        void Shadow(SvgNode n)
        {
            var kids = n.Children;
            for (int i = kids.Count - 1; i >= 0; i--)
            {
                var c = kids[i];
                if (c.Tag == "ellipse" && Attr(c, "fill") == "#6a1b9a")
                {
                    if (_shadowOpacity <= 0) { kids.RemoveAt(i); continue; }
                    SetAttr(c, "opacity", _shadowOpacity.ToString("R", CultureInfo.InvariantCulture));
                    continue;
                }
                if (c.Children.Count > 0) Shadow(c);
            }
        }
        static string Attr(SvgNode n, string k) { foreach (var kv in n.Attrs) if (kv.Key == k) return kv.Value; return null; }
        static void SetAttr(SvgNode n, string k, string v)
        {
            for (int i = 0; i < n.Attrs.Count; i++) if (n.Attrs[i].Key == k) { n.Attrs[i] = new KeyValuePair<string, string>(k, v); return; }
            n.Attrs.Add(new KeyValuePair<string, string>(k, v));
        }
    }
}
