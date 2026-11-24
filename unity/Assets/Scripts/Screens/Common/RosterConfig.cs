// config/roster from Firestore (src/firebase/firestore.js subscribeToRoster; App.js rosterCfg), read once when the menu
// opens, signed in (App/AppFlow.cs, like config/levels and config/weather). The admin's switches for the roster
// (tools/admin/roster.mjs): which creature groups and creatures are out (functions/squad.js hiddenOf: the per-group
// switch `groups`, else the older `hidden` list, else HIDDEN; RETIRED always), the copies a creature needs (copiesOf),
// how a Rainbow creature is had (rainbowOf) and whether finishing a set pays (setRewardsOf). ShopData holds what they
// come to. Offline, or until it arrives: functions/squad.js's defaults (the Masked and Elemental Heroes not out).
// What isn't out, the app leaves out everywhere, and so does Unity: the Shop's chests, HOT groups and deals, the Level
// Road's and the Level Pass's chests, the Daily Spin (ShopData.Hidden), the Characters page (CharactersPage), the
// games' casts (InGames) and what the achievements and stats count (Roster.Counted: one already owned still counts).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public static class RosterConfig
    {
        static bool _loading;

        /// <summary>The config/roster document as read (null: none yet: the defaults).</summary>
        public static IDictionary<string, object> Doc { get; private set; }

        /// <summary>Applies a config/roster document (null: the defaults).</summary>
        public static void Set(IDictionary<string, object> cfg)
        {
            Doc = cfg;
            ShopData.ApplyRoster(cfg);
        }

        /// <summary>What isn't out: group keys and creature ids (functions/squad.js hiddenOf).</summary>
        public static string[] Hidden { get { ShopData.Ensure(); return ShopData.Hidden; } }

        /// <summary>isOut: neither its group nor the creature itself is on the hidden list.</summary>
        public static bool IsOut(string set, string id) { var h = Hidden; return Array.IndexOf(h, set) < 0 && Array.IndexOf(h, id) < 0; }

        /// <summary>Whether the creature with this id is out (one the roster doesn't know: yes).</summary>
        public static bool IdOut(string id) { ShopData.Ensure(); return id == null || !ShopData.ById.TryGetValue(id, out var c) || ShopData.IsOut(c, Hidden); }

        /// <summary>Whether the creature with this key is out (one the roster doesn't know: yes).</summary>
        public static bool KeyOut(string key) { ShopData.Ensure(); return key == null || !ShopData.ByKey.TryGetValue(key, out var c) || ShopData.IsOut(c, Hidden); }

        /// <summary>The games' casts (src/squishdoku/roster.js rosterOf, src/stack/roster.js castOf, src/sort/themes.js
        /// poolOf): out, and never the Masked or Elemental Heroes (tall figures); no season-pass creature unless
        /// `pass` (Squishdoku takes one).</summary>
        public static bool InGames(string key, bool pass = false)
        {
            ShopData.Ensure();
            if (key == null || !ShopData.ByKey.TryGetValue(key, out var c)) return true;
            return c.Set != "heroes" && c.Set != "elemental" && (pass || !c.Pass) && ShopData.IsOut(c, Hidden);
        }

        /// <summary>Reads config/roster once (signed in) and applies it; a failure leaves the defaults.</summary>
        public static async Task Load(FirebaseClient fb)
        {
            if (fb == null || _loading) return;
            _loading = true;
            try { Set(await fb.Data.ReadConfig("roster")); }
            catch (Exception e) { Debug.LogWarning("[RosterConfig] " + e.Message); _loading = false; }
        }
    }
}
