// A finger on the creature in front of the house and in the Game Park: its rig takes it (Creatures/CreatureTouch: a tap
// pokes the spot it lands on, a hold squeezes, a drag sideways turns it), within the design's hit on it (main-menu.js
// .mm-hit). Only the native rig reacts (a recording can't). MenuScreen hands it the touches the HUD didn't take.
using SquishSquad.Creatures;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        readonly CreatureTouch _touch = new CreatureTouch();

        /// <summary>Whether the creature takes touches now: standing in front of the house or in the park (not walking).</summary>
        public bool CreatureTouchable => Creature != null && _idle is NativeRig && Creature.gameObject.activeInHierarchy && !IntroOn
                                         && (Where == Place.Home || Where == Place.Park);

        /// <summary>A finger down at page px `p` (y down): true when it's on the creature, whose rig now has it.</summary>
        public bool CreatureDown(Vector2 p)
        {
            if (!CreatureTouchable) return false;
            var b = Creature.BoxPoint(PageToWorld(p));
            if (!CreatureTouch.InMenuHit(b)) return false;
            _touch.Down((NativeRig)_idle, b);
            return true;
        }

        /// <summary>Whether a finger is on the creature (MenuScreen sends it the moves and the lift).</summary>
        public bool CreatureHeld => _touch.Active;

        public void CreatureMove(Vector2 p)
        {
            if (!_touch.Active) return;
            if (Creature == null) { _touch.Drop(); return; }
            _touch.Move(Creature.BoxPoint(PageToWorld(p)));
        }

        public void CreatureUp()
        {
            if (Creature == null) _touch.Drop();
            else _touch.Up();
        }

        // a page pixel (y down) in the world the menu is drawn in (a piece at page (x, y) sits at the root's (x, -y))
        Vector3 PageToWorld(Vector2 p) => _root.TransformPoint(new Vector3(p.x, -p.y, 0));
    }
}
