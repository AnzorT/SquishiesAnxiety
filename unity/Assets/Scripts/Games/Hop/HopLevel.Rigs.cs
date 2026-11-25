// Squish Hop's characters as the design's live 2.5D rigs (develop's src/hop/Game.js with tools/rig/hop.html through
// RigStage.js): one page, as big as the screen, draws the hopper and every friend on the board; the level tells it
// what happens (they drop and pop in, the hopper hops leg by leg and boings off bubbles, bumps and shakes its head,
// friends hop for joy and fly to the goal card, three happy jumps on the ★, stuck's droop and sweat, a giggle when
// tapped). The board's cast is sent as the board comes in (its tag: the characters' keys); once the page has drawn it
// (RigCast), the rigs are on and the cut-outs step aside, as do the bursts a rig makes itself (the bubble's poof, the
// landing's puff). The level only makes the calls (Rig: HopGame hands them to Creatures/RigStage) and hears back, so
// it stays Unity-free.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Hop
{
    public sealed partial class HopLevel
    {
        /// <summary>The rig page's calls (tools/rig/hop.html hopStage: origin, cast, place, show, enter, hop, bump, pickup,
        /// restore, win, stuck, unstuck, giggle) with their arguments; null: no rig page (the cut-outs play).</summary>
        public Action<string, object[]> Rig;
        void R(string fn, params object[] args) => Rig?.Invoke(fn, args);

        string _rigTag;
        // this board's cast, named by its characters (Game.js castTag)
        string CastTag
        {
            get
            {
                var k = new List<string> { _hopper?.Key ?? "" };
                if (_friends != null) foreach (var f in _friends) k.Add(f?.Key ?? "");
                return string.Join(",", k);
            }
        }
        /// <summary>Whether the rigs draw the characters now (the page has drawn this board's cast).</summary>
        public bool RigsOn => _rigTag != null && _rigTag == CastTag;
        /// <summary>The rig page over the screen is shown (not while Blitz hides the board), drawn from this order up.</summary>
        public bool RigsShown => !BoardHidden;
        public int RigOrder => O_BANNER - 30;
        /// <summary>Paused (the pause card): the rig page's clock holds too.</summary>
        public bool Paused => _paused;
        /// <summary>(tests) the hopper's cell, each friend's cell, and how many cushions each cell has left.</summary>
        public int HopperCell => G.St.Cur;
        public int[] FriendCells => _board.Friends;
        public int LifeAt(int cell) => G.St.Life[cell];

        /// <summary>The rig page is up: it gets the board (Game.js onRigReady).</summary>
        public void RigReady() => SendCast();
        /// <summary>The page has drawn a cast (or couldn't: a rig's art didn't load, and the cut-outs stay).</summary>
        public void RigCast(string tag, bool ok) { if (ok) _rigTag = tag; }

        static Dictionary<string, object> O(params object[] kv)
        {
            var d = new Dictionary<string, object>();
            for (int i = 0; i + 1 < kv.Length; i += 2) d[(string)kv[i]] = kv[i + 1];
            return d;
        }
        // where a character stands on `cell` (on a pile's top if `life` is 2): its feet in the board's area, scale, z
        Dictionary<string, object> RigAt(int cell, int k, int life)
        {
            var q = BoardGeometry.StandOn(B, cell, life == 2 ? HopArt.PILE_TOP : 0);
            return O("x", (double)q.X, "y", (double)q.Y, "s", q.S / B.T, "z", (double)ZOf(cell, k));
        }
        static Dictionary<string, object> With(Dictionary<string, object> d, params object[] kv)
        {
            var o = new Dictionary<string, object>(d);
            for (int i = 0; i + 1 < kv.Length; i += 2) o[(string)kv[i]] = kv[i + 1];
            return o;
        }

        // everyone where they are now (a new board, the page ready): the page's origin is the board area's place
        void SendCast()
        {
            if (B == null || _hopper == null || Rig == null) return;
            var life = G.St.Life;
            var list = new List<object> { With(RigAt(G.St.Cur, 2, life[G.St.Cur]), "id", "p", "key", _hopper.Key, "W", (double)_pw) };
            for (int k = 0; k < _board.Friends.Length && k < _friends.Count; k++)
            {
                int cell = _board.Friends[k]; var c = _friends[k];
                if (c == null) continue;
                list.Add(With(RigAt(cell, 1, _board.Life[cell]), "id", "f" + k, "key", c.Key, "W", (double)_fw, "o", (G.St.Got & _board.Fbit[cell]) != 0 ? 0.0 : 1.0));
            }
            R("origin", (double)LeftW, 0.0);
            R("cast", list, CastTag);
        }

        // the hopper's legs onto each cell of a hop (Game.js hop: the last on what's left of it, a bubble boings it on)
        List<object> Legs(MoveResult m, HopState nxt)
        {
            var legs = new List<object>();
            for (int k = 0; k < m.Cells.Length; k++)
            {
                int c = m.Cells[k]; bool last = k == m.Cells.Length - 1;
                legs.Add(With(RigAt(c, 2, last ? nxt.Life[c] : 1), "ms", last ? 190.0 : 170.0, "h", B.T * (k > 0 ? 0.8 : 0.5) * (BoardGeometry.StandOn(B, c).S / B.T), "boing", k > 0));
            }
            return legs;
        }
    }
}
