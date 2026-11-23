// Who's in a Squish Hop level (src/hop/roster.js): the hopper is the player's own squishy (the one on the Lobby), the
// friends to pick up are others, the player's own first, in an order fixed by the level (a seeded random), so a level
// has the same friends every time. The cast is Squish Stack's (src/stack/roster.js castOf): each squishy drawn by its
// body cut-out (Resources/Stack/art), its head from Resources/Hop/heads (src/squishdoku/heads.js).
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Games.Hop
{
    public sealed class HopSquishy
    {
        public string Id, Key;
        /// <summary>The cut-out (a Resources path), or null: a creature with no cut-out (the app shows its still).</summary>
        public string Picture;
        /// <summary>Its head with a face (Resources paths), or null when heads.js has none.</summary>
        public string Happy, Sad;
        public float Ar = 1;
        /// <summary>Where the body sits in the picture: left, top, right, bottom (fractions).</summary>
        public float[] Box = { 0, 0, 1, 1 };
        public bool Mine;

        /// <summary>stack/Pieces.js bodyH: the body's height at width w.</summary>
        public float BodyH(float w) => w / (Box[2] - Box[0]) * Ar * (Box[3] - Box[1]);
    }

    public static class HopRoster
    {
        // a seeded random (the level number), so a level always has the same friends (Park–Miller, as roster.js)
        public static Func<double> Rng(int seed)
        {
            long s = (long)((seed * 2654435761.0) % 2147483647);
            if (s == 0) s = 1;
            return () =>
            {
                s = s * 16807 % 2147483647;
                return (s - 1) / 2147483646.0;
            };
        }

        static List<T> Shuffle<T>(List<T> a, Func<double> rand)
        {
            var b = new List<T>(a);
            for (int i = b.Count - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(rand() * (i + 1));
                (b[i], b[j]) = (b[j], b[i]);
            }
            return b;
        }

        /// <summary>The creatures the player owns (squad/lobby.js ownedIdList: the profile's col keys and ownedIds).</summary>
        public static List<string> OwnedIds(IDictionary<string, object> profile)
        {
            var ids = new List<string>();
            if (profile == null) return ids;
            if (profile.TryGetValue("col", out var col) && col is IDictionary<string, object> m) foreach (var k in m.Keys) if (!ids.Contains(k)) ids.Add(k);
            if (profile.TryGetValue("ownedIds", out var o) && o is System.Collections.IEnumerable list && !(o is string))
                foreach (var v in list) { var k = Convert.ToString(v, System.Globalization.CultureInfo.InvariantCulture); if (!ids.Contains(k)) ids.Add(k); }
            return ids;
        }

        /// <summary>squad/lobby.js selectedId: the Lobby's pick if owned, else '1' if owned, else the first owned, else '0'.</summary>
        public static string SelectedId(IDictionary<string, object> profile)
        {
            var own = OwnedIds(profile);
            if (profile != null && profile.TryGetValue("lobby", out var lob) && lob is IDictionary<string, object> l && l.TryGetValue("sel", out var sel) && sel != null)
            {
                var s = Convert.ToString(sel, System.Globalization.CultureInfo.InvariantCulture);
                if (own.Contains(s)) return s;
            }
            return own.Contains("1") ? "1" : own.Count > 0 ? own[0] : "0";
        }

        /// <summary>The hopper: the Lobby's squishy, else the first owned one, else anyone.</summary>
        public static HopSquishy HopperOf(IList<HopSquishy> cast, IDictionary<string, object> profile)
        {
            string id = profile != null ? SelectedId(profile) : "";
            return cast.FirstOrDefault(c => c.Id == id) ?? cast.FirstOrDefault(c => c.Mine) ?? cast.FirstOrDefault();
        }

        /// <summary>Level `lv`'s `n` friends: owned ones first, in an order fixed by the level.</summary>
        public static List<HopSquishy> FriendsOf(IList<HopSquishy> cast, HopSquishy hopper, int n, int lv)
        {
            if (n == 0) return new List<HopSquishy>();
            var rand = Rng(lv);
            var rest = cast.Where(c => hopper == null || c.Id != hopper.Id).ToList();
            var pool = Shuffle(rest.Where(c => c.Mine).ToList(), rand);
            pool.AddRange(Shuffle(rest.Where(c => !c.Mine).ToList(), rand));
            return pool.Take(n).ToList();
        }

        /// <summary>Marks the player's own (castOf's `mine`).</summary>
        public static void MarkMine(IList<HopSquishy> cast, IDictionary<string, object> profile)
        {
            var own = OwnedIds(profile);
            foreach (var c in cast) c.Mine = own.Contains(c.Id);
        }
    }
}
