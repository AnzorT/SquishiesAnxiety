// Squish Sort's squishies as the design's live 2.5D rigs (develop's src/sort/Game.js with tools/rig/sort.html through
// hop/RigStage.js): one page draws every squishy in play over the play area, and the level tells it what happens.
// Picked up, they stretch and wiggle; in the right spot they squash in and hop for joy; in a wrong one they shake
// their heads and bounce back sweating; an impostor found out jumps guiltily and spins away; the win is a bounce wave
// as the doors shut; a loss, everyone droops. A deal's rigs are sent to the page as it starts (its cast, named by a
// tag) and load through the peek; the page says when it has drawn them all (RigCast). From the tumble on, the deal is
// played by the rigs if they're drawn by then (RigLive), else by the stills (SortLevel.cs's own moves). While the rigs
// draw, the stills only show the chosen ring (under the rigs) and the ? and ✓ marks (over them).
// The level only makes the calls (Rig: the screen hands them to Creatures/RigStage, SortGame.cs) and hears back
// (RigReady, RigCast), so it stays Unity-free.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    public sealed partial class SortLevel
    {
        /// <summary>The rig page's calls (tools/rig/sort.html sortStage: cast, place, hideAll, tumble, hold, drag, go,
        /// correct, wrong, caught, huh, win, unshut, lose) with their arguments; null: no rig page (the stills play).</summary>
        public Action<string, object[]> Rig;
        void R(string fn, params object[] args) => Rig?.Invoke(fn, args);

        string _castTag = "", _rigTag;
        List<object> _castList;
        bool _rigLive;
        int _castN;
        /// <summary>Whether the rigs play this deal (from the tumble on), not the stills.</summary>
        public bool RigLive => _rigLive;
        /// <summary>Paused (the pause card): the rig page's clock holds too.</summary>
        public bool Paused => _paused;
        /// <summary>The play area the rig page covers, dp (its window).</summary>
        public float StageW => AreaW;
        public float StageH => AreaH;
        // each piece's id on the page (Game.js rids: the squad id, `id#k` for a second of the same)
        string[] _rids = new string[0];
        string Rid(int k) => k >= 0 && k < _rids.Length ? _rids[k] : null;

        /// <summary>The rig page is up: it gets this deal's squishies (Game.js onRigReady).</summary>
        public void RigReady() { if (_castList != null) R("cast", _castList, _castTag); }
        /// <summary>The page has drawn a cast's rigs (or couldn't: a rig's art didn't load, and the stills play it).</summary>
        public void RigCast(string tag, bool ok) { if (ok) _rigTag = tag; }

        static Dictionary<string, object> O(params object[] kv)
        {
            var d = new Dictionary<string, object>();
            for (int i = 0; i + 1 < kv.Length; i += 2) d[(string)kv[i]] = kv[i + 1];
            return d;
        }
        // a spot as the page takes it ({ x, y, s }: the still's top-left and scale), opaque if `o` is given
        static Dictionary<string, object> Spot((float x, float y, float s) p, double? o = null)
        {
            var d = O("x", (double)p.x, "y", (double)p.y, "s", (double)p.s);
            if (o != null) d["o"] = o.Value;
            return d;
        }
        // a squishy's rig: its cut-out's name (Resources/Stack/art/<key>), as the result card's trio takes it
        static string RigKey(string uri) => string.IsNullOrEmpty(uri) ? null : uri.Substring(uri.LastIndexOf('/') + 1);

        // a new deal (Game.js's reset): the rigs off until the page has drawn this one's cast, which goes now
        void CastDeal()
        {
            _rigLive = false;
            _castTag = Board.Pieces.Count + ":" + (++_castN) + ":" + (long)_tk.Now;
            var seen = new HashSet<string>();
            _rids = new string[Board.Pieces.Count];
            var list = new List<object>();
            bool all = true;
            for (int k = 0; k < Board.Pieces.Count; k++)
            {
                var id = Board.Pieces[k].Id ?? ("p" + k);
                _rids[k] = seen.Contains(id) ? id + "#" + k : id;
                seen.Add(id);
                var key = RigKey(Board.Pieces[k].Uri);
                if (key == null) all = false;
                list.Add(O("id", _rids[k], "key", key, "P", (double)_P));
            }
            _castList = all ? list : null;
            if (_castList != null) R("cast", _castList, _castTag);
            else R("hideAll");
        }

        // a squishy chosen by a tap is held up and wiggles: the rig too (Game.js setSelected)
        void SetSelected(int? k)
        {
            var prev = _selected;
            _selected = k;
            if (!_rigLive || prev == k) return;
            if (prev != null) R("hold", Rid(prev.Value), null);
            if (k != null) R("hold", Rid(k.Value), "tap");
        }

        // the mixed-up ones (on a shelf, not home) look round, puzzled, one at a time now and then (every 2.6 s while
        // sorting with the rigs; the turn starts over when sorting stops and starts)
        int _huhTimer = -1, _huhN;
        void SyncHuh()
        {
            bool want = Phase == "place" && _rigLive && !_paused;
            if (want == (_huhTimer >= 0)) return;
            if (!want) { _tk.ClearTimeout(_huhTimer); _huhTimer = -1; return; }
            _huhN = 0;
            void Tick()
            {
                var ks = new List<int>();
                for (int k = 0; k < Board.Pieces.Count; k++)
                    if (!_play.Gone.Contains(k) && !_play.Locked.Contains(k) && _play.At[k].IsSlot && k != _selected && !(_touch != null && _touch.K == k)) ks.Add(k);
                if (ks.Count > 0) R("huh", Rid(ks[_huhN++ % ks.Count]));
                _huhTimer = _tk.SetTimeout(Tick, 2600);
            }
            _huhTimer = _tk.SetTimeout(Tick, 2600);
        }
        void StopHuh() { if (_huhTimer >= 0) _tk.ClearTimeout(_huhTimer); _huhTimer = -1; }

        // the doors as the page clips its squishies to them (Game.js win: Container.js's doors in the play area)
        List<object> DoorsForRigs()
        {
            var G = _g;
            return _m.Doors == 1
                ? new List<object> { O("x0", (double)G.Ix, "w", (double)G.Dw, "hinge", _m.Hinge) }
                : new List<object> { O("x0", (double)G.Ix, "w", (double)G.Dw, "hinge", "left"), O("x0", (double)(G.Ix + G.Dw), "w", (double)G.Dw, "hinge", "right") };
        }
    }
}
