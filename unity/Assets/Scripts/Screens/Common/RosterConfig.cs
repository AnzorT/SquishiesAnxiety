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
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

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
            ApplyLooks(cfg);
        }

        // ---- the creatures' border looks (src/squad/looks.js lookOf; 2026-11-26) ------------------------------------
        // `look`: everyone's (0-4; 4 when unset or not a whole number in range), `looks`: { creature id or key: n } for
        // single creatures. The live creatures take them (Creatures/Js/RigLooks: the rig draws the look); the stills are
        // the look tools/unity/export-chest.mjs exported (Roster.Picture). The last ones read are kept (PlayerPrefs), so
        // the creatures the menu shows before the document arrives are already in them.
        const string LooksPref = "squish.looks";
        const int LookDefault = 4;

        /// <summary>The looks as last read: everyone's, and single creatures' by key.</summary>
        public static int Look { get; private set; } = LookDefault;
        public static IReadOnlyDictionary<string, int> LooksOver { get; private set; } = new Dictionary<string, int>();

        static int? LookNum(object o)
        {
            double d;
            if (o is double x) d = x; else if (o is long l) d = l; else if (o is int i) d = i;
            else if (o is string s && double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var p)) d = p;
            else return null;
            return d >= 0 && d <= 4 && d == Math.Floor(d) ? (int)d : (int?)null;
        }

        static void ApplyLooks(IDictionary<string, object> cfg)
        {
            int n = (cfg != null && cfg.TryGetValue("look", out var l) ? LookNum(l) : null) ?? LookDefault;
            var over = new Dictionary<string, int>();
            if (cfg != null && cfg.TryGetValue("looks", out var lo) && lo is IDictionary<string, object> per)
            {
                ShopData.Ensure();
                foreach (var kv in per)
                {
                    var v = LookNum(kv.Value);
                    if (v == null) continue;
                    // (by id, as tools/admin/roster.mjs writes them, or by key)
                    var key = ShopData.ById != null && ShopData.ById.TryGetValue(kv.Key, out var c) ? c.Key : kv.Key;
                    over[key] = v.Value;
                }
            }
            Look = n; LooksOver = over;
#if UNITY_5_3_OR_NEWER
            // (the rig is Unity's: the tests that build the screens outside Unity leave it out)
            Creatures.Js.RigLooks.Set(n, over);
            try
            {
                var sb = new System.Text.StringBuilder().Append(n);
                foreach (var kv in over) sb.Append('|').Append(kv.Key).Append('=').Append(kv.Value);
                PlayerPrefs.SetString(LooksPref, sb.ToString());
            }
            catch (Exception) { }
#endif
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

#if UNITY_5_3_OR_NEWER
        // the games that build outside Unity too (tools/unity's tests, without the Shop's data) ask through hooks
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void HookGames()
        {
            Games.Sort.SortLevel.IdIsOut = IdOut;
            Games.Sort.SortDef.KeyIsOut = KeyOut;
            Games.Stack.StackGame.InGames = k => InGames(k);
            // the looks: only the creatures with look pictures get one (the app's rigLookOf), and the last ones read
            Creatures.Js.RigLooks.KeysOf = () => { var k = Roster.LookKeys; return k.Count > 0 ? new List<string>(k) : null; };
            try
            {
                var saved = PlayerPrefs.GetString(LooksPref, "");
                if (saved.Length > 0)
                {
                    var parts = saved.Split('|');
                    var over = new Dictionary<string, int>();
                    for (int i = 1; i < parts.Length; i++) { int e = parts[i].LastIndexOf('='); if (e > 0 && int.TryParse(parts[i].Substring(e + 1), out var v)) over[parts[i].Substring(0, e)] = v; }
                    if (int.TryParse(parts[0], out var n)) Creatures.Js.RigLooks.Set(n, over);
                }
            }
            catch (Exception) { }
        }
#endif

        /// <summary>Reads config/roster once (signed in) and applies it; a failure leaves the defaults.</summary>
        public static async Task Load(FirebaseClient fb)
        {
            if (fb == null || _loading) return;
            _loading = true;
#if UNITY_5_3_OR_NEWER
            // the Shop's tables (Resources/Shop/shop.json) come through Roster.ReadText, which a screen sets when it
            // opens; the menu reads config/roster at sign-in, before any has
            ScreenViewHost.EnsureLoaders();
#endif
            try { Set(await fb.Data.ReadConfig("roster")); }
            catch (Exception e)
            {
#if UNITY_5_3_OR_NEWER
                Debug.LogWarning("[RosterConfig] " + e.Message);
#endif
                _loading = false;
            }
        }
    }
}
