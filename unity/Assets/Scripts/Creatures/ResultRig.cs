// A result card's character (Ui/Cards/TrioItem.cs, src/squishdoku/Trio.js): the creature's rig with the result page's
// own states (tools/rig/result.html addStates: resWait, resWow → resHappy, resMiss → resSad, and its bigger particles),
// without its floor shadow (the card draws its own). Two ways, as Rigs.For:
//   native    the rig itself (Creatures/NativeRig.cs), the page's states compiled in with it (tools/unity/rig/jsc.mjs
//             takes them from result.html), each one played as the card asks, the card's arms and turns handed over
//             every frame (ext), its particle bursts: every creature
//   recorded  four clips per creature from the same code (record.mjs <key> --clip result): <key>-res-wait (a loop),
//             -res-fill (the fill and the jump, arms and bursts in it), -res-happy (a loop of its happy moves), -res-miss
//             (the sigh, then held): the fallback if the native rig can't run.
// Can(key) says whether a creature can be drawn either way; the card shows the stars when one of its three can't.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class ResultRig : IRigFrames, IDisposable
    {
        static readonly string[] Clips = { "wait", "fill", "happy", "miss" };
        // the rig's own floor shadow (result.html hides it: .ch ellipse[fill="#6a1b9a"])
        static readonly Regex Shadow = new Regex("<ellipse[^>]*fill=\"#6a1b9a\"[^>]*?(/>|></ellipse>)", RegexOptions.Compiled);

        IRigFrames _live;
        readonly Dictionary<string, RecordedRig> _rec;
        RecordedRig _clip;
        float _clipT0;
        string _last;

        ResultRig(IRigFrames live, Dictionary<string, RecordedRig> rec) { _live = live; _rec = rec; }

        internal static bool LiveReady() => NativeRig.Ready();

        /// <summary>Whether `key` can be drawn as a result character (native, or its four clips recorded).</summary>
        public static bool Can(string key)
        {
            if (NativeRig.Ready()) return true;
            foreach (var c in Clips) if (Resources.Load<TextAsset>("Creatures/" + key + "-res-" + c) == null) return false;
            return true;
        }

        /// <summary>Squish Stack's forest walker (src/stack/ForestMap.js, rig/walk.html): the plain rig, native (turned,
        /// walking its gait: Yaw, Gait) or its idle recording (standing; it slides along the road).</summary>
        public static ResultRig ForWalk(string key)
        {
            var live = NativeRig.Create(key);
            if (live != null) { live.Fidgets(false); return new ResultRig(live, null) { _key = key }; }
            var r = RecordedRig.Load(key);
            if (r == null) return null;
            var rr = new ResultRig(null, new Dictionary<string, RecordedRig> { ["idle"] = r }) { _key = key };
            rr.Clip("idle");
            return rr;
        }
        string _key;

        /// <summary>The walker's turn (native: the rig's spinOff).</summary>
        public void Yaw(double deg) { (_live as IHouseRig)?.Yaw(deg); }

        /// <summary>The walker's gait this frame (native: walk.html step(), the Squad House's HouseWalk.step on the rig's
        /// ext): weight 0..1, `dt` seconds, the way it walks (±90).</summary>
        public void Gait(double w, double dt, double spin) { (_live as NativeRig)?.WalkStep(w, dt, spin); }

        public static ResultRig For(string key)
        {
            var live = NativeRig.Create(key);
            if (live != null)
            {
                live.Fidgets(false); live.Play("resWait");
                return new ResultRig(live, null);
            }
            var rec = new Dictionary<string, RecordedRig>();
            foreach (var c in Clips)
            {
                var r = RecordedRig.Load(key + "-res-" + c);
                if (r == null) return null;
                r.Loop = c == "wait" || c == "happy";
                rec[c] = r;
            }
            var rr = new ResultRig(null, rec);
            rr.Clip("wait");
            return rr;
        }

        /// <summary>The rig's state now (live), as TrioItem's CardCreature.State.</summary>
        public void State(string s) { if (_live != null) _live.Play(s); }

        /// <summary>The recorded stretch now, from its start (recorded), as CardCreature.Clip.</summary>
        public void Clip(string c)
        {
            if (_rec == null || !_rec.TryGetValue(c, out var r)) return;
            _clip = r; _clipT0 = Time.realtimeSinceStartup;
        }

        /// <summary>The card's moves on the rig this frame (live: rive-rig's ext).</summary>
        public void Ext(IDictionary<string, double> e) { (_live as IHouseRig)?.Ext(e); }

        /// <summary>A particle burst (native): result.html burst(): RiveRig.emit at x, y (rig units) or the rig's own spot.</summary>
        public void Emit(string kind, string at, double x, double y, int n) { (_live as NativeRig)?.Emit(kind, at, x, y, n); }

        public void Play(string move) => State(move);

        public string FrameAt(float seconds)
        {
            string m = _live != null ? _live.FrameAt(seconds) : _clip?.FrameAt(Time.realtimeSinceStartup - _clipT0);
            if (m == null) return _last;
            if (!ReferenceEquals(m, _lastRaw)) { _lastRaw = m; _last = Shadow.Replace(m, ""); }
            return _last;
        }
        string _lastRaw;

        /// <summary>The body's box at rest in its 0-100 units (result.html measure()), from a frame: the union of what it
        /// fills (its floor shadow and particles left out); null while it hasn't drawn.</summary>
        public static RigBody BodyOf(string markup)
        {
            if (string.IsNullOrEmpty(markup)) return null;
            try
            {
                // (its particles left out: the rig draws them in its last group, rive-rig.js drawParts)
                int g = markup.LastIndexOf("<g>", StringComparison.Ordinal);
                if (g >= 0 && markup.IndexOf("<g", g + 3, StringComparison.Ordinal) < 0) markup = markup.Substring(0, g) + "</svg>";
                var scene = SvgScene.Compile(SvgMarkup.Parse(markup), 100, 100);
                var b = Box.Empty;
                void Walk(LayerNode l) { foreach (var n in l.Children) { if (n is LayerNode k) Walk(k); else if (n is FillNode f && f.Opacity > 0) b.Add(f.Shape.Bounds); } }
                Walk(scene.Root);
                if (b.IsEmpty || b.X1 - b.X0 < 1) return null;
                return new RigBody { Cx = (b.X0 + b.X1) / 2, Gy = b.Y1, Bw = b.X1 - b.X0, Bh = b.Y1 - b.Y0, Top = b.Y0, Left = b.X0 };
            }
            catch (Exception) { return null; }
        }

        public void Dispose() { (_live as IDisposable)?.Dispose(); _live = null; }
    }

    /// <summary>A result card's live character on screen (Ui/Cards/CardPieces.cs ILive): its rig made once, its body
    /// measured from its first frame (the card waits for it), then a CreatureView placed where the layer's transform puts
    /// its 0-100 box, faded, greyed above the colour's edge, playing what the card asks.</summary>
    public sealed class CardCreatureView : CardPieces.ILive
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Wire()
        {
            CardPieces.CanLive = ResultRig.Can;
            CardPieces.MakeLive = (parent, c) => new CardCreatureView(parent, c);
            // Squish Stack's walker: native, or a recorded idle
            SquishSquad.Games.Shared.MapForest.LiveWalker = key => CardPieces.LiveCharacters && (ResultRig.LiveReady() || Resources.Load<TextAsset>("Creatures/" + key) != null);
        }

        readonly Transform _parent;
        readonly CardCreature _c;
        readonly ResultRig _rig;
        GameObject _holder;
        CreatureView _view;
        string _state, _clip;
        double _clipAt = -1;
        int _size;

        CardCreatureView(Transform parent, CardCreature c)
        {
            _parent = parent; _c = c;
            _walk = c.Kind == "walk";
            _rig = _walk ? ResultRig.ForWalk(c.Key) : ResultRig.For(c.Key);
            if (_rig == null) c.Failed = true;
        }
        readonly bool _walk;
        float _lastT = -1;

        public void Sync(Affine transform, float opacity, int order)
        {
            var cc = _c;
            if (_rig == null) return;
            if (cc.Body == null) { cc.Body = ResultRig.BodyOf(_rig.FrameAt(0)); return; }
            if (_view == null)
            {
                // (its texture as big as the box shows on screen at rest: the owner sets Unit once the body is known)
                if (cc.Unit <= 0) return;
                _size = Mathf.Clamp(Mathf.RoundToInt(100 * cc.Unit * UiPiece.PxPerDp), 32, 1024);
                _holder = new GameObject("card creature " + cc.Key);
                _holder.transform.SetParent(_parent, false);
                _view = CreatureView.Create(_holder.transform, _rig, new Rect(0, 0, _size, _size), order);
                _view.Failed = _ => cc.Failed = true;
            }
            if (cc.State != _state) { _state = cc.State; _rig.State(cc.State); }
            if (_walk)
            {
                float now = Time.realtimeSinceStartup, dt = _lastT < 0 ? 0.016f : Mathf.Min(0.05f, now - _lastT);
                _lastT = now;
                _rig.Yaw(cc.Yaw);
                _rig.Gait(cc.Walk, dt, cc.WalkSpin);
            }
            else
            {
                if (cc.Clip != _clip || cc.ClipAt != _clipAt) { _clip = cc.Clip; _clipAt = cc.ClipAt; _rig.Clip(cc.Clip); }
                _rig.Ext(cc.Ext);
            }
            foreach (var b in cc.Bursts) _rig.Emit(b.kind, b.at, b.x, b.y, b.n);
            cc.Bursts.Clear();
            _view.Order = order;
            _view.SetOpacity(opacity);
            _view.GreyAbove(_walk ? -1 : cc.GreyAbove);
            Place(_holder.transform, transform, _size);
        }

        // the layer's transform (rig units → screen dp, y down) as the holder's position, turn and scale (world units are
        // screen pixels, y up; the view's box is `size` px for the 100 units). A squash and a turn, never a skew.
        static void Place(Transform t, Affine m, int size)
        {
            float k = UiPiece.PxPerDp, q = k * 100f / size;
            double a = m.A * q, b = -m.B * q, c = -m.C * q, d = m.D * q;   // the 2 x 2 on (px right, px up)
            double sx = Math.Sqrt(a * a + b * b), rot = Math.Atan2(b, a), sy = sx > 1e-9 ? (a * d - b * c) / sx : 0;
            t.localPosition = new Vector3((float)(m.E * k), (float)(-m.F * k), 0);
            t.localRotation = Quaternion.Euler(0, 0, (float)(rot * 180 / Math.PI));
            t.localScale = new Vector3((float)sx, (float)sy, 1);
        }

        public void Destroy()
        {
            _rig?.Dispose();
            if (_holder != null) { if (Application.isPlaying) UnityEngine.Object.Destroy(_holder); else UnityEngine.Object.DestroyImmediate(_holder); }
        }
    }
}
