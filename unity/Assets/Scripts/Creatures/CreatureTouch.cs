// A finger on a live creature, handed to its rig as the app's page hands it a touch (rive-rig.js mount's pointer
// handlers, through native-host.js pointer): a tap pokes the spot it lands on and the creature plays its own reaction
// for it (head, ear, nose, eye, cheek, belly, side, foot, tail, left / right: mittens-moves.js, pet-pokes.js,
// snack-pokes.js and the other groups' anims: contact, notice, reaction, settle); held 170 ms it squeezes, let go it
// springs back; dragged sideways it turns and settles facing front. Points are on the rig's 0-100 box
// (CreatureView.BoxPoint). The user, 2026-11-26: the creatures react to being touched on the main menu, in the Game
// Park and on the Characters screen.
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class CreatureTouch
    {
        NativeRig _rig;
        Vector2 _last;

        /// <summary>Whether a finger is on the creature now.</summary>
        public bool Active => _rig != null;

        /// <summary>The main menu's hit on its creature (the design's main-menu.js .mm-hit, the only part of the stage
        /// that takes touches: an ellipse 22 % in from each side, from 20 % down to 2 % above the bottom).</summary>
        public static bool InMenuHit(Vector2 b)
        {
            float dx = (b.x - 50f) / 28f, dy = (b.y - 59f) / 39f;
            return dx * dx + dy * dy <= 1f;
        }

        /// <summary>Anywhere on the creature's box (the Characters page's .rig: its whole box takes touches).</summary>
        public static bool InBox(Vector2 b) => b.x >= 0 && b.y >= 0 && b.x <= 100 && b.y <= 100;

        public void Down(NativeRig rig, Vector2 box)
        {
            if (rig == null) return;
            if (_rig != null) Up();
            _rig = rig;
            _last = box;
            rig.Pointer("pointerdown", box.x, box.y);
        }

        public void Move(Vector2 box)
        {
            if (_rig == null || (box - _last).sqrMagnitude < 0.0025f) return;
            _last = box;
            _rig.Pointer("pointermove", box.x, box.y);
        }

        /// <summary>The finger lifts: the poke (a tap), the let-go (a squeeze) or the turn's settle (a drag); then, as a
        /// touch does, the pointer leaves (the eyes stop following it).</summary>
        public void Up()
        {
            if (_rig == null) return;
            var r = _rig;
            _rig = null;
            r.Pointer("pointerup", _last.x, _last.y);
            r.Pointer("pointerleave", _last.x, _last.y);
        }

        /// <summary>The creature went away under the finger: nothing more is sent.</summary>
        public void Drop() => _rig = null;
    }
}
