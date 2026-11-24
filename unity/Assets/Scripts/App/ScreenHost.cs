// Puts a ported screen's pieces (Ui/Screens: a list of ScreenPiece, rebuilt whenever something changes) on screen:
// one UiPiece per piece id, redrawn only when its SVG changes (a piece that only moves or fades costs nothing), in list
// order; a "mittens" slot becomes the live creature (CreatureView with the native rig's idle, as on the menu). Also the
// screen's pointer in dp (y down), shared by the start-up screens.
using System;
using System.Collections.Generic;
using SquishSquad.Creatures;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class ScreenHost : IDisposable
    {
        readonly Transform _root;
        readonly Dictionary<string, UiPiece> _pieces = new Dictionary<string, UiPiece>();
        CreatureView _creature;
        Rect _creatureBox;
        bool _creatureFailed;

        public ScreenHost(Transform parent, string name)
        {
            _root = new GameObject(name).transform;
            _root.SetParent(parent, false);
        }

        public bool Shown { get => _root.gameObject.activeSelf; set => _root.gameObject.SetActive(value); }

        public void Show(List<ScreenPiece> list)
        {
            var used = new HashSet<string>();
            for (int i = 0; i < list.Count; i++)
            {
                var p = list[i];
                int order = 1 + i * 2;
                if (p.Slot) { PlaceCreature(p, order); used.Add(p.Id); continue; }
                if (!_pieces.TryGetValue(p.Id, out var piece)) _pieces[p.Id] = piece = UiPiece.Create(_root, p.Id, order);
                piece.Order = order;
                piece.SetSvg(p.Svg, p.W, p.H, p.Margin);
                piece.Transform = p.Transform;
                piece.Opacity = p.Opacity;
                piece.Visible = true;
                piece.Apply();
                used.Add(p.Id);
            }
            foreach (var kv in _pieces) if (!used.Contains(kv.Key)) kv.Value.Visible = false;
            if (_creature != null) _creature.gameObject.SetActive(used.Contains("mittens"));
        }

        // the creature in its box (dp -> page px), made again if its box changes
        void PlaceCreature(ScreenPiece p, int order)
        {
            if (_creatureFailed) return;
            float k = UiPiece.PxPerDp;
            var box = new Rect((float)p.Transform.E * k, (float)p.Transform.F * k, p.W * k, p.H * k);
            if (_creature != null && (Mathf.Abs(box.x - _creatureBox.x) > 0.5f || Mathf.Abs(box.y - _creatureBox.y) > 0.5f || Mathf.Abs(box.width - _creatureBox.width) > 0.5f))
            {
                if (Application.isPlaying) UnityEngine.Object.Destroy(_creature.gameObject); else UnityEngine.Object.DestroyImmediate(_creature.gameObject);
                _creature = null;
            }
            if (_creature != null) return;
            var rig = Rigs.For("mittens");
            if (rig == null) { _creatureFailed = true; return; }
            _creature = CreatureView.Create(_root, rig, box, order);
            _creature.Failed = _ => { _creatureFailed = true; if (_creature != null) _creature.gameObject.SetActive(false); };
            _creatureBox = box;
        }

        /// <summary>The live creature in the "mittens" slot (null until shown, or when it couldn't be made).</summary>
        public CreatureView Creature => _creature;

        public void Dispose()
        {
            if (_root != null)
            {
                if (Application.isPlaying) UnityEngine.Object.Destroy(_root.gameObject);
                else UnityEngine.Object.DestroyImmediate(_root.gameObject);
            }
            _pieces.Clear();
        }

        // ---- the pointer ------------------------------------------------------------------------------------------
        public struct Pointer { public Vector2 Dp; public bool Down, Held, Up; }

        /// <summary>The first touch (or the mouse) this frame, in dp from the screen's top-left.</summary>
        public static Pointer Read()
        {
            Vector2 pos;
            var r = new Pointer();
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                pos = t.position;
                r.Down = t.phase == TouchPhase.Began;
                r.Up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled;
                r.Held = !r.Up;
            }
            else
            {
                pos = Input.mousePosition;
                r.Down = Input.GetMouseButtonDown(0);
                r.Up = Input.GetMouseButtonUp(0);
                r.Held = Input.GetMouseButton(0);
            }
            float k = UiPiece.PxPerDp;
            r.Dp = new Vector2(pos.x / k, (Screen.height - pos.y) / k);
            return r;
        }
    }
}
