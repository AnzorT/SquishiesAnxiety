// A rig stage's squishies on screen (Creatures/RigStage.cs: the app's tools/rig/sort.html or hop.html running in the
// rig's realm): each one's rig drawn by a CreatureView where the page put its box this frame (any 2D transform: the
// page's squash and tilt about the feet included), as opaque as the page has it, stacked as the page stacks them
// (z-index, then the order they were added); sort.html's floor shadows (.sh: a soft purple round, under each squishy)
// as UiPieces; the board's clip (Squish Sort's doors shutting) cuts them all. A rig that didn't draw this frame keeps
// its picture (sort.html lets only the moving ones draw). The game calls Draw each frame with where the play area is
// (dp) and the sorting order to start from, and gets the next free order back.
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
        sealed class One { public CreatureView V; public StageRig Rig; public int Size; public UiPiece Shadow; public bool DrewLast; public V Host; }
        readonly Dictionary<string, One> _ones = new Dictionary<string, One>();
        readonly HashSet<string> _seen = new HashSet<string>();
        readonly List<(double z, int dom, One one, RigStage.Item it, bool shadow)> _draw = new List<(double, int, One, RigStage.Item, bool)>();

        /// <summary>`rigShadow`: the page's CSS on the rig's own floor shadow (0: hidden, as sort.html; 0.45: hop.html).</summary>
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
                    one.V = CreatureView.Create(_parent, one.Rig, new Rect(0, 0, one.Size, one.Size), order);
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
