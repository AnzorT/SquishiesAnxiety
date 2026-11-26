// A rig stage's squishies on screen (Creatures/RigStage.cs: the app's tools/rig/sort.html or hop.html running in the
// rig's realm): each one's rig drawn by a CreatureView where the page put its box this frame (any 2D transform: the
// page's squash and tilt about the feet included), as opaque as the page has it, stacked as the page stacks them
// (z-index, then the order they were added); the pages' floor shadows (.sh: a soft purple round under each squishy
// that stays on the floor as it hops: sort.html, and hop.html since 2026-11-26) as UiPieces; the board's clip (Squish
// Sort's doors shutting) cuts them all. A rig that didn't draw this frame keeps its picture (sort.html lets only the
// moving ones draw). The game calls Draw each frame with where the play area is (dp) and the sorting order to start
// from, and gets the next free order back.
using System;
using System.Collections.Generic;
using SquishSquad.Creatures.Js;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class StageView
    {
        readonly Transform _parent;
        readonly RigStage _stage;
        readonly double _rigShadow;
        const float TOP_ROOM = 0.45f;   // the texture's room above the 0-100 box (CreatureView's marginTop; 0.25 elsewhere)
        sealed class One { public CreatureView V; public StageRig Rig; public int Size; public UiPiece Shadow; public bool DrewLast; public V Host; }
        readonly Dictionary<string, One> _ones = new Dictionary<string, One>();
        readonly HashSet<string> _seen = new HashSet<string>();
        readonly List<(double z, int dom, One one, RigStage.Item it, bool shadow)> _draw = new List<(double, int, One, RigStage.Item, bool)>();

        /// <summary>`rigShadow`: the page's CSS on the rig's own floor shadow (0: hidden, as sort.html and hop.html do: they
        /// draw their own, .sh).</summary>
        public StageView(Transform parent, RigStage stage, double rigShadow)
        {
            _parent = parent; _stage = stage; _rigShadow = rigShadow;
        }

        const string SHADOW = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\" viewBox=\"0 0 100 100\"><defs><radialGradient id=\"sh\" cx=\"50\" cy=\"50\" r=\"50\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-color=\"#6a1b9a\" stop-opacity=\"0.34\"/><stop offset=\"0.55\" stop-color=\"#6a1b9a\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#6a1b9a\" stop-opacity=\"0\"/></radialGradient></defs><circle cx=\"50\" cy=\"50\" r=\"50\" fill=\"url(#sh)\"/></svg>";

        /// <summary>Draws the stage now: `area` the play area's place on screen (page dp → screen dp), sorting orders from
        /// `order` up; returns the next free order.</summary>
        public int Draw(Affine area, int order, bool visible = true)
        {
            var items = visible ? _stage.Read() : new List<RigStage.Item>();
            Watch(items);
            var clip = visible ? _stage.Clip() : null;
            double cl = double.NegativeInfinity, cr = double.PositiveInfinity;
            if (clip != null) { cl = area.Apply(new Vec2(clip.Value.left, 0)).X; cr = area.Apply(new Vec2(clip.Value.right, 0)).X; }
            _seen.Clear(); _draw.Clear();
            float k = UiPiece.PxPerDp;
            foreach (var it in items)
            {
                if (string.IsNullOrEmpty(it.Id)) continue;
                _seen.Add(it.Id);
                var box = area * it.Box;
                // the texture: the box's size on screen now (with room for a stretch), made again if it grows past that
                int want = Mathf.Clamp(Mathf.CeilToInt((float)(Math.Sqrt(Math.Abs(box.A * box.D - box.B * box.C)) * 100 * k * 1.15)), 32, 1024);
                if (!_ones.TryGetValue(it.Id, out var one) || one.Host.O != it.Host.O) { if (one != null) Kill(one); one = _ones[it.Id] = new One { Host = it.Host }; }
                if (one.V == null || want > one.Size * 1.3)
                {
                    if (one.V != null) Destroy(one.V.gameObject);
                    one.Size = Math.Max(want, one.Size);
                    one.Rig = new StageRig(it.Host, _rigShadow);
                    // (more room above the box than round it: a hop's stretch, a bubble's boing and the win's raised arms
                    // reach up to a third of the box over it, measured 2026-11-26; the height off the floor is the box's)
                    one.V = CreatureView.Create(_parent, one.Rig, new Rect(0, 0, one.Size, one.Size), order, TOP_ROOM);
                    one.V.gameObject.name = "stage " + it.Key;
                }
                _draw.Add((it.Z, it.Index * 2 + 1, one, it, false));
                if (it.HasShadow) _draw.Add((it.ShadowZ, it.Index * 2, one, it, true));
            }
            // gone from the page: gone from the screen
            List<string> gone = null;
            foreach (var id in _ones.Keys) if (!_seen.Contains(id)) (gone ??= new List<string>()).Add(id);
            if (gone != null) foreach (var id in gone) { Kill(_ones[id]); _ones.Remove(id); }
            _draw.Sort((a, b) => a.z != b.z ? a.z.CompareTo(b.z) : a.dom.CompareTo(b.dom));
            foreach (var (_, _, one, it, shadow) in _draw)
            {
                if (shadow)
                {
                    if (one.Shadow == null) { one.Shadow = UiPiece.Create(_parent, "stage shadow " + it.Key, order); one.Shadow.SetSvg(SHADOW, 100, 100, 1); }
                    var m = area * it.ShadowBox;
                    double cx = m.Apply(new Vec2(50, 50)).X;
                    one.Shadow.Transform = m;
                    one.Shadow.Opacity = (float)it.ShadowOpacity;
                    one.Shadow.Visible = it.ShadowOpacity > 0 && cx >= cl && cx <= cr;
                    one.Shadow.Order = order++;
                    continue;
                }
                one.Rig.Dirty = it.Drew || one.DrewLast;
                one.DrewLast = it.Drew;
                one.V.SetOpacity((float)it.Opacity);
                one.V.Order = order++;
                one.V.Place(area * it.Box * Affine.ScaleBy(100.0 / one.Size, 100.0 / one.Size), k, cl, cr);
            }
            return order;
        }

        // ---- the jump monitor (the Editor and development builds; 2026-11-26, the user: "monitor the jumps"): while a
        // squishy's box moves, each frame's Unity delta, the rig clock's step since the frame before and how far its feet
        // went (dp); one "[HopJump]" line in the log per move, once it has stood still for 12 frames. The box only moves
        // when the rig's clock steps, so a 0 in the middle of a move is a frame that showed the same place twice.
        static readonly bool Watching = Application.isEditor || Debug.isDebugBuild;
        sealed class Track { public Vec2 Last; public bool Has; public int Still; public readonly List<(float dt, double step, double moved, double y)> F = new List<(float, double, double, double)>(); }
        readonly Dictionary<string, Track> _tracks = new Dictionary<string, Track>();
        double _clock = -1;
        void Watch(List<RigStage.Item> items)
        {
            if (!Watching || items.Count == 0) return;
            double now;
            try { now = RigThread.Run(() => Rt.ToNum(Rt.Invoke(Rt.G("performance"), "now"))); } catch (Exception) { return; }
            double step = _clock < 0 ? 0 : now - _clock; _clock = now;
            float dt = Time.unscaledDeltaTime * 1000;
            foreach (var it in items)
            {
                if (string.IsNullOrEmpty(it.Id)) continue;
                var feet = it.Box.Apply(new Vec2(50, 100));
                if (!_tracks.TryGetValue(it.Id, out var t)) _tracks[it.Id] = t = new Track();
                double moved = t.Has ? Math.Sqrt((feet.X - t.Last.X) * (feet.X - t.Last.X) + (feet.Y - t.Last.Y) * (feet.Y - t.Last.Y)) : 0;
                t.Last = feet; t.Has = true;
                if (moved > 0.25 && it.Opacity > 0.05) { t.Still = 0; t.F.Add((dt, step, moved, feet.Y)); }
                else if (t.F.Count > 0)
                {
                    t.F.Add((dt, step, moved, feet.Y));
                    if (++t.Still >= 12) { Report(it.Id, it.Key, t.F, t.F.Count - t.Still); t.F.Clear(); t.Still = 0; }
                }
            }
        }
        static void Report(string id, string key, List<(float dt, double step, double moved, double y)> f, int n)
        {
            if (n < 3) return;
            var dts = new List<float>(); double ms = 0, y0 = f[0].y - f[0].moved, top = 0;
            for (int i = 0; i < n; i++) { dts.Add(f[i].dt); ms += f[i].dt; top = Math.Min(top, f[i].y - y0); }
            dts.Sort(); float med = dts[n / 2];
            int slow = 0, noStep = 0, bigStep = 0; float worst = 0;
            for (int i = 0; i < n; i++)
            {
                if (f[i].dt > med * 1.5f) slow++;
                if (f[i].dt > worst) worst = f[i].dt;
                if (i > 0 && i < n - 1 && f[i].moved <= 0.25) noStep++;
                if (f[i].step > 1.5 * med + 2) bigStep++;
            }
            var sb = new System.Text.StringBuilder();
            sb.Append($"[HopJump] {id} {key}: {n} frames in {ms:0} ms (median frame {med:0.0} ms, worst {worst:0}; {slow} slow frames, {noStep} frames showing the same place twice, {bigStep} rig steps over 1.5 frames); went up {-top:0} dp");
            sb.Append(" | frame ms:"); for (int i = 0; i < n; i++) sb.Append(' ').Append(f[i].dt.ToString("0"));
            sb.Append(" | rig step ms:"); for (int i = 0; i < n; i++) sb.Append(' ').Append(f[i].step.ToString("0"));
            sb.Append(" | moved dp:"); for (int i = 0; i < n; i++) sb.Append(' ').Append(f[i].moved.ToString("0.0"));
            Debug.Log(sb.ToString());
        }

        /// <summary>Every squishy off the screen (the stage itself keeps them).</summary>
        public void Clear() { foreach (var one in _ones.Values) Kill(one); _ones.Clear(); }

        static void Kill(One one)
        {
            if (one.V != null) Destroy(one.V.gameObject);
            if (one.Shadow != null) Destroy(one.Shadow.gameObject);
            one.V = null; one.Shadow = null;
        }
        static void Destroy(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o); }
    }
}
