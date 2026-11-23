// Squish Sort's board, ported from src/sort/board.js (SQUISH_SORT.md):
// dealing a level, and what a drop does. Pure C#; checked against the JS by
// tools/unity/games/sort (fixtures.mjs + SortDiff).
//
// A board is
//   Slots       rows x cols spots, numbered row by row from the top shelf
//   Pieces      the squishies of the level, then the impostors (Home null:
//               never inside)
//   Start       slot -> piece: what the peek shows first
//   Swaps       [slotA, slotB], played in turn near the end of the peek
//   After       piece -> Place: where each one is once the doors open again
//   FoodBefore  slot -> clutter kind during the peek
//   FoodAfter   slot -> clutter kind after the shake
// and a piece's Home is where it sat when the doors closed (after the swaps).
//
// The JS objects keyed by slot / piece number iterate in ascending key
// order, so they are SortedDictionary here: every loop over them visits the
// keys in the same order, and so draws the same random numbers.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    // a squishy to draw from: { id, uri }
    public sealed class PoolEntry
    {
        public string Id;
        public string Uri;
        public PoolEntry() { }
        public PoolEntry(string id, string uri) { Id = id; Uri = uri; }
    }

    public sealed class Piece
    {
        public string Id;
        public string Uri;
        // null: an impostor
        public int? Home;
    }

    // { kind: 'slot' | 'tray', i }; as a drop target, a tray Place's I is
    // ignored. Treated as immutable (shared between play states, as in JS).
    public sealed class Place
    {
        public const string SlotKind = "slot";
        public const string TrayKind = "tray";
        public readonly string Kind;
        public readonly int I;
        public Place(string kind, int i) { Kind = kind; I = i; }
        public static Place Slot(int i) => new Place(SlotKind, i);
        public static Place Tray(int i = 0) => new Place(TrayKind, i);
        public bool IsSlot => Kind == SlotKind;
        public bool IsTray => Kind == TrayKind;
    }

    public sealed class BoardData
    {
        public int Rows;
        public int Cols;
        public int Slots;
        public List<Piece> Pieces = new List<Piece>();
        public SortedDictionary<int, int> Start = new SortedDictionary<int, int>();
        // each [a, b]; a is null only on a board with no squishies (the JS
        // pushes [undefined, b] there)
        public List<int?[]> Swaps = new List<int?[]>();
        public SortedDictionary<int, Place> After = new SortedDictionary<int, Place>();
        public SortedDictionary<int, int> FoodBefore = new SortedDictionary<int, int>();
        public SortedDictionary<int, int> FoodAfter = new SortedDictionary<int, int>();
        public int TrayCap;
    }

    // { at, locked, gone } (gone: an impostor found out). Never mutated:
    // Drop returns a new one (or the same one when nothing changes).
    public sealed class PlayState
    {
        public SortedDictionary<int, Place> At;
        public SortedSet<int> Locked;
        public SortedSet<int> Gone;
    }

    public sealed class DropResult
    {
        public PlayState State;
        // one of Board.Lock, Wrong, Impostor, Tray, None
        public string Outcome;
        public int? Bumped;
    }

    public static class Board
    {
        public const string Lock = "lock";
        public const string Wrong = "wrong";
        public const string Impostor = "impostor";
        public const string Tray = "tray";
        public const string None = "none";

        static readonly Random Shared = new Random();
        static double DefaultRandom() { lock (Shared) return Shared.NextDouble(); }

        // pickN: n distinct from the list, one random number each
        static List<T> PickN<T>(IList<T> list, int n, Func<double> random)
        {
            var pool = new List<T>(list);
            var outList = new List<T>();
            while (outList.Count < n && pool.Count > 0)
            {
                int j = (int)Math.Floor(random() * pool.Count);
                outList.Add(pool[j]);
                pool.RemoveAt(j);
            }
            return outList;
        }

        static List<T> Shuffle<T>(IList<T> list, Func<double> random) => PickN(list, list.Count, random);

        static List<int> Range(int n)
        {
            // [...Array(n).keys()] throws on a negative length
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "Invalid array length");
            var r = new List<int>(n);
            for (int i = 0; i < n; i++) r.Add(i);
            return r;
        }

        // `pool`: distinct squishies to draw from; `kinds`: how many kinds of
        // clutter there are to draw (props.js KINDS).
        public static BoardData MakeBoard(LevelSpec spec, IList<PoolEntry> pool, Func<double> random = null, int kinds = Props.Kinds)
        {
            if (random == null) random = DefaultRandom;
            int slots = spec.Rows * spec.Cols;
            int count = Math.Min(Math.Min(spec.Count, slots), pool.Count);
            var drawn = PickN(pool, count + spec.Decoys, random);
            var real = drawn.GetRange(0, Math.Min(count, drawn.Count));
            var fakes = drawn.Count > count ? drawn.GetRange(count, drawn.Count - count) : new List<PoolEntry>();
            var seats = PickN(Range(slots), count, random);
            var start = new SortedDictionary<int, int>();
            for (int k = 0; k < seats.Count; k++) start[seats[k]] = k;
            // the clutter, on spots no squishy has, all kinds before any repeats
            int nFoods = Math.Max(0, Math.Min(spec.Foods, slots - count - 1));
            var foodKinds = new List<int>();
            while (foodKinds.Count < nFoods)
            {
                // (the JS never ends here with no kinds; a negative count throws)
                if (kinds <= 0) throw new ArgumentOutOfRangeException(nameof(kinds), "no clutter kinds to draw from");
                foodKinds.AddRange(Shuffle(Range(kinds), random));
            }
            if (foodKinds.Count > nFoods) foodKinds.RemoveRange(nFoods, foodKinds.Count - nFoods);
            var foodBefore = new SortedDictionary<int, int>();
            var noSquishy = new List<int>();
            foreach (int s in Range(slots)) if (!start.ContainsKey(s)) noSquishy.Add(s);
            var foodSpots = PickN(noSquishy, nFoods, random);
            for (int j = 0; j < foodSpots.Count; j++) foodBefore[foodSpots[j]] = foodKinds[j];

            // the swaps: the first trades two squishies, the next sends one to
            // an empty spot (not one with clutter) if there is one
            var now = new SortedDictionary<int, int>(start);
            var swaps = new List<int?[]>();
            for (int n = 0; n < spec.Swaps; n++)
            {
                var full = new List<int>(now.Keys);
                var empty = new List<int>();
                foreach (int s in Range(slots)) if (!now.ContainsKey(s) && !foodBefore.ContainsKey(s)) empty.Add(s);
                int?[] pair;
                if (n % 2 == 1 && empty.Count > 0)
                {
                    var pa1 = PickN(full, 1, random);
                    var pb1 = PickN(empty, 1, random);
                    pair = new int?[] { pa1.Count > 0 ? pa1[0] : (int?)null, pb1[0] };
                }
                else if (full.Count >= 2)
                {
                    var p2 = PickN(full, 2, random);
                    pair = new int?[] { p2[0], p2[1] };
                }
                else continue;
                int? a = pair[0];
                int b = pair[1].Value;
                int pa = 0, pb = 0;
                bool hasA = a.HasValue && now.TryGetValue(a.Value, out pa);
                bool hasB = now.TryGetValue(b, out pb);
                if (a.HasValue) now.Remove(a.Value);
                now.Remove(b);
                if (hasA) now[b] = pa;
                if (hasB && a.HasValue) now[a.Value] = pb;
                swaps.Add(pair);
            }
            var home = new Dictionary<int, int>();
            foreach (var e in now) home[e.Value] = e.Key;
            var pieces = new List<Piece>();
            for (int k = 0; k < real.Count; k++)
            {
                int h;
                pieces.Add(new Piece { Id = real[k].Id, Uri = real[k].Uri, Home = home.TryGetValue(k, out h) ? h : (int?)null });
            }
            foreach (var c in fakes) pieces.Add(new Piece { Id = c.Id, Uri = c.Uri, Home = null });
            var homes = new HashSet<int>(home.Values);

            // the shake: `mixed` of them stay inside, each somewhere it doesn't belong
            var mixedK = PickN(Range(count), Math.Min(spec.Mixed, count), random);
            var after = new SortedDictionary<int, Place>();
            List<int> spots = null;
            for (int tries = 0; tries < 200 && spots == null; tries++)
            {
                var pickSpots = PickN(Range(slots), mixedK.Count, random);
                bool ok = true;
                for (int j = 0; j < pickSpots.Count; j++)
                {
                    int h;
                    if (home.TryGetValue(mixedK[j], out h) && pickSpots[j] == h) { ok = false; break; }
                }
                if (ok) spots = pickSpots;
            }
            // (a sure answer: each takes the next one's home; with one mixed-up
            // squishy that is its own home, as in the JS)
            if (spots == null)
            {
                spots = new List<int>();
                for (int j = 0; j < mixedK.Count; j++) spots.Add(home[mixedK[(j + 1) % mixedK.Count]]);
            }
            for (int j = 0; j < mixedK.Count; j++) after[mixedK[j]] = Place.Slot(spots[j]);
            var rest = new List<int>();
            for (int k = 0; k < pieces.Count; k++) if (!after.ContainsKey(k)) rest.Add(k);
            var outK = Shuffle(rest, random);
            for (int j = 0; j < outK.Count; j++) after[outK[j]] = Place.Tray(j);
            // ...and the clutter goes anywhere but a squishy's spot or a mixed-up one
            var taken = new HashSet<int>();
            foreach (int k in mixedK) taken.Add(after[k].I);
            var foodAfter = new SortedDictionary<int, int>();
            var free = new List<int>();
            foreach (int s in Range(slots)) if (!homes.Contains(s) && !taken.Contains(s)) free.Add(s);
            // keep at least one empty spot that isn't anyone's
            var moved = PickN(free, Math.Min(nFoods, Math.Max(0, free.Count - 1)), random);
            for (int j = 0; j < moved.Count; j++) foodAfter[moved[j]] = foodKinds[j];
            return new BoardData
            {
                Rows = spec.Rows,
                Cols = spec.Cols,
                Slots = slots,
                Pieces = pieces,
                Start = start,
                Swaps = swaps,
                After = after,
                FoodBefore = foodBefore,
                FoodAfter = foodAfter,
                TrayCap = count + fakes.Count,
            };
        }

        // --- playing -----------------------------------------------------------------

        public static PlayState StartState(BoardData board) => new PlayState
        {
            At = new SortedDictionary<int, Place>(board.After),
            Locked = new SortedSet<int>(),
            Gone = new SortedSet<int>(),
        };

        // the piece in slot `i` now, or null
        public static int? Occupant(PlayState state, int i)
        {
            foreach (var e in state.At)
            {
                if (!state.Gone.Contains(e.Key) && e.Value.Kind == Place.SlotKind && e.Value.I == i) return e.Key;
            }
            return null;
        }

        static int FreeTray(BoardData board, PlayState state)
        {
            var used = new HashSet<int>();
            foreach (var e in state.At) if (!state.Gone.Contains(e.Key) && e.Value.Kind == Place.TrayKind) used.Add(e.Value.I);
            for (int j = 0; j < board.TrayCap; j++) if (!used.Contains(j)) return j;
            return board.TrayCap;
        }

        static PlayState With(PlayState s, SortedDictionary<int, Place> at = null, SortedSet<int> locked = null, SortedSet<int> gone = null) => new PlayState
        {
            At = at ?? s.At,
            Locked = locked ?? s.Locked,
            Gone = gone ?? s.Gone,
        };

        // Piece `k` dropped on `target` (a slot, the tray, or null: nowhere):
        //   lock      its home: it stays (a mixed-up one sitting there goes where
        //             `k` came from: Bumped)
        //   wrong     not its home: a mistake, it goes back
        //   impostor  an impostor put in: a mistake, and it's found out (gone)
        //   tray      a mixed-up one taken out to the tray (no mistake)
        //   none      nothing happens: dropped nowhere, on a squishy already
        //             home, or on clutter
        public static DropResult Drop(BoardData board, PlayState state, int k, Place target)
        {
            var none = new DropResult { State = state, Outcome = None, Bumped = null };
            Place from;
            if (!state.At.TryGetValue(k, out from) || from == null || state.Locked.Contains(k) || state.Gone.Contains(k)) return none;
            if (target == null || target.Kind == Place.TrayKind)
            {
                if (from.Kind == Place.TrayKind) return none;
                var at1 = new SortedDictionary<int, Place>(state.At);
                at1[k] = Place.Tray(FreeTray(board, state));
                return new DropResult { State = With(state, at: at1), Outcome = Tray, Bumped = null };
            }
            int i = target.I;
            if (board.FoodAfter != null && board.FoodAfter.ContainsKey(i)) return none;
            int? occ = Occupant(state, i);
            if (occ == k || (occ.HasValue && state.Locked.Contains(occ.Value))) return none;
            int? home = board.Pieces[k].Home;
            if (!home.HasValue)
            {
                var gone = new SortedSet<int>(state.Gone) { k };
                return new DropResult { State = With(state, gone: gone), Outcome = Impostor, Bumped = null };
            }
            if (home.Value != i) return new DropResult { State = state, Outcome = Wrong, Bumped = null };
            var at = new SortedDictionary<int, Place>(state.At);
            at[k] = Place.Slot(i);
            if (occ.HasValue) at[occ.Value] = from;
            var locked = new SortedSet<int>(state.Locked) { k };
            return new DropResult { State = With(state, at: at, locked: locked), Outcome = Lock, Bumped = occ };
        }

        // every real squishy home
        public static bool Solved(BoardData board, PlayState state)
        {
            for (int k = 0; k < board.Pieces.Count; k++)
                if (board.Pieces[k].Home.HasValue && !state.Locked.Contains(k)) return false;
            return true;
        }
    }
}
