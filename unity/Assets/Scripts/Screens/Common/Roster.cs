// The creatures the screens count and show: functions/squad.js's roster (Resources/Screens/roster.json, written by
// tools/unity/export-screens.mjs): id, art key, name, group, rarity; the groups and their members. And each one's
// picture: the Stack cut-out (Resources/Stack/art/<key>.png, its height / width in Resources/Stack/stack.json), as
// src/web/Preview.js shows them (the app's real plush art comes from Firebase Storage).
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Backend;

namespace SquishSquad.Screens
{
    public sealed class Creature
    {
        public string Id, Key, Name, Set;
        public int Rar;
    }

    public static class Roster
    {
        /// <summary>A text file from Resources (the host sets this: Resources.Load&lt;TextAsset&gt;): "Screens/roster" → its text.</summary>
        public static Func<string, string> ReadText;

        static List<Creature> _all;
        static string[] _rarity, _sets;
        static Dictionary<string, string[]> _setIds;
        static Dictionary<string, float> _ar;

        static void Load()
        {
            if (_all != null) return;
            var j = Prof.Map(Json.Parse(ReadText?.Invoke("Screens/roster") ?? throw new InvalidOperationException("Resources/Screens/roster.json is missing: run node tools/unity/export-screens.mjs")));
            _rarity = Prof.List(j["rarity"]).Select(x => (string)x).ToArray();
            _sets = Prof.List(j["sets"]).Select(x => (string)x).ToArray();
            _setIds = Prof.List(j["setOf"]).Select(Prof.Map).ToDictionary(m => (string)m["key"], m => Prof.List(m["ids"]).Select(x => (string)x).ToArray());
            _all = Prof.List(j["creatures"]).Select(Prof.Map).Select(m => new Creature { Id = (string)m["id"], Key = (string)m["key"], Name = (string)m["name"], Set = (string)m["set"], Rar = (int)Prof.Num(m["rar"]) }).ToList();
        }

        public static IReadOnlyList<Creature> All { get { Load(); return _all; } }
        public static Creature ById(string id) { Load(); return _all.FirstOrDefault(c => c.Id == id); }
        public static string[] Sets { get { Load(); return _sets; } }
        public static string[] SetIds(string set) { Load(); return _setIds.TryGetValue(set, out var l) ? l : new string[0]; }
        public static string TierOf(string id) { Load(); var c = ById(id); return c == null ? null : _rarity[c.Rar]; }

        /// <summary>App.js `counted`: the roster without what isn't out yet (config/roster, RosterConfig: by default the
        /// Masked and Elemental Heroes, and Prickle, retired), unless the player owns it.</summary>
        public static List<Creature> Counted(IDictionary<string, object> profile)
        {
            Load();
            return _all.Where(c => RosterConfig.IsOut(c.Set, c.Id) || Prof.Owns(profile, c.Id)).ToList();
        }

        // ---- pictures ------------------------------------------------------------------------------------------------
        /// <summary>The creature's still, as the app's thumbnails (src/squad/looks.js withLooks): its border-look
        /// picture (Resources/Chests/look/&lt;key&gt;, square, in the look tools/unity/export-chest.mjs exported:
        /// config/roster's, 3 since 2026-11-26), else the cut-out; null when it has neither. (The games' pieces stay
        /// cut-outs, as in the app.)</summary>
        public static string Picture(Creature c) => c == null ? null : HasLook(c.Key) ? "Chests/look/" + c.Key : Ar(c.Key) > 0 ? "Stack/art/" + c.Key : null;

        /// <summary>Where Picture's picture of the creature `key` sits in a box of 1 x 1: x, y, w, h.</summary>
        public static (float x, float y, float w, float h) PictureFrame(string key) => Frame(HasLook(key) ? 1 : Ar(key));

        static HashSet<string> _lookKeys;
        /// <summary>The creatures with a border-look still (Resources/Chests/cards4.json `looks`: all but Prickle and
        /// Wisecrack); none when it can't be read.</summary>
        public static IReadOnlyCollection<string> LookKeys
        {
            get
            {
                if (_lookKeys != null) return _lookKeys;
                var set = new HashSet<string>();
                try
                {
                    var t = ReadText?.Invoke("Chests/cards4");
                    if (t == null) return set;   // (not cached: the host may set ReadText later)
                    foreach (var k in Prof.List(Prof.Map(Json.Parse(t))["looks"])) set.Add((string)k);
                }
                catch (Exception) { }
                return _lookKeys = set;
            }
        }
        public static bool HasLook(string key) => key != null && LookKeys.Contains(key);

        /// <summary>The cut-out's height / width (0: none).</summary>
        public static float Ar(string key)
        {
            if (_ar == null)
            {
                _ar = new Dictionary<string, float>();
                var t = ReadText?.Invoke("Stack/stack");
                if (t != null)
                    foreach (var a in Prof.List(Prof.Map(Json.Parse(t))["artList"]).Select(Prof.Map))
                        _ar[(string)a["key"]] = (float)Prof.Num(a["ar"]);
            }
            return key != null && _ar.TryGetValue(key, out var v) ? v : 0;
        }

        /// <summary>Where the picture sits in a box of 1 x 1 (Preview.js fitFrame): x, y, w, h.</summary>
        public static (float x, float y, float w, float h) Frame(float ar) => ar >= 1 ? ((1 - 1 / ar) / 2, 0, 1 / ar, 1) : (0, (1 - ar) / 2, 1, ar);
    }
}
