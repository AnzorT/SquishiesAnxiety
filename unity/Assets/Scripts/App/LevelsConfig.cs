// config/levels from Firestore (src/firebase/firestore.js subscribeToLevels, read once when the menu opens): the XP
// curve and what earns XP, handed to every place that reads them, as the app's playerXp.js levelsOf does. Until it
// arrives (or offline), the defaults (functions/squad.js DEFAULT_LEVELS: 100 XP per level, replays pay half, ...).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.App
{
    public static class LevelsConfig
    {
        static bool _loading;

        static bool Num(IDictionary<string, object> m, string k, out double d)
        {
            d = 0;
            if (m == null || !m.TryGetValue(k, out var v) || !(v is double x) || double.IsNaN(x) || double.IsInfinity(x)) return false;
            d = x;
            return true;
        }

        static IDictionary<string, object> Map(IDictionary<string, object> m, string k) =>
            m != null && m.TryGetValue(k, out var v) ? v as IDictionary<string, object> : null;

        /// <summary>The document (or null: the defaults) to the XP code of the menu and every game.</summary>
        public static void Apply(IDictionary<string, object> cfg)
        {
            Games.Sort.PlayerXp.SetLevelsConfig(cfg);
            Games.Hop.PlayerXp.SetLevelsConfig(cfg);
            double per = Num(cfg, "xpPerLevel", out var p) && p > 0 ? p : 100;
            var xp = Map(cfg, "xp");
            var blitz = Map(xp, "blitz");
            double replay = Num(xp, "replay", out var r) && r >= 0 && r <= 1 ? r : 0.5;
            double games = Num(xp, "games", out var g) && g > 0 ? g : 1;
            Menu.HudValues.XpPerLevel = per;
            Games.Stack.StackXp.Rules = new Games.Stack.XpRules
            {
                XpPerLevel = per, Games = games, Replay = replay,
                BlitzStack = Num(blitz, "stack", out var bs) && bs > 0 ? bs : 200,
            };
            Games.Squishdoku.PlayerXp.Rules = new Games.Squishdoku.XpRules
            {
                XpPerLevel = per, Games = games, Replay = replay,
                BlitzSquishdoku = Num(blitz, "squishdoku", out var bq) && bq > 0 ? bq : 400,
            };
        }

        /// <summary>Reads config/levels once (signed in) and applies it.</summary>
        public static async Task Load(FirebaseClient fb)
        {
            if (fb == null || _loading) return;
            _loading = true;
            try { Apply(await fb.Data.ReadConfig("levels")); }
            catch (Exception e) { Debug.LogWarning("[LevelsConfig] " + e.Message); _loading = false; }
        }
    }
}
