// The weather the game shows (src/weather.js, 2026-11-21, the user: "Firebase says how many weathers we have; more than
// one, we pick today's"): the main menu's world, the intro, the house (its map, the Dance Room's glass dome, the beach)
// and Squish Stack's forest all read it through MenuState.Season.
//
// Firestore config/weather, edited by hand in the Firebase console:
//   { options: ['sunny', 'rainy', 'snowy'] }
// - one option: the game always shows that weather;
// - more than one: today's weather by the month, as before (December-February snowy, May-September sunny, the other
//   months rainy); if that one isn't in the list, the first in the list;
// - no doc, or nothing usable in it: all three (the game as it was).
// The app subscribes to the doc (App.js, src/firebase/firestore.js subscribeToWeather); here it is read once when the
// menu opens, signed in (App/AppFlow.cs, like config/levels). Offline or until it arrives: all three (the month's).
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Menu
{
    public static class Weather
    {
        public static readonly string[] All = { "sunny", "rainy", "snowy" };

        static List<string> _options = new List<string>(All);
        static bool _loading;

        /// <summary>weather.js setWeatherConfig: the doc (or null). A list; one text, or several split by commas (as
        /// typed in the console), counts too.</summary>
        public static void SetConfig(IDictionary<string, object> cfg)
        {
            object raw = null;
            if (cfg != null) cfg.TryGetValue("options", out raw);
            var arr = new List<string>();
            if (raw is string s) arr.AddRange(s.Split(','));
            else if (raw is IEnumerable e) foreach (var o in e) arr.Add(o?.ToString() ?? "");
            var ok = new List<string>();
            foreach (var o in arr) { var w = o.Trim().ToLowerInvariant(); if (Array.IndexOf(All, w) >= 0 && !ok.Contains(w)) ok.Add(w); }
            _options = ok.Count > 0 ? ok : new List<string>(All);
        }

        public static IReadOnlyList<string> Options => _options;

        /// <summary>weatherByMonth: the design's own rule (main-menu-scene.js autoSeason).</summary>
        public static string ByMonth(DateTime now)
        {
            int mo = now.Month - 1;
            return mo == 11 || mo <= 1 ? "snowy" : mo >= 4 && mo <= 8 ? "sunny" : "rainy";
        }

        /// <summary>weatherToday: one option, always it; more, the month's (or the first listed).</summary>
        public static string Today(DateTime now)
        {
            if (_options.Count == 1) return _options[0];
            var m = ByMonth(now);
            return _options.Contains(m) ? m : _options[0];
        }

        /// <summary>Reads config/weather once (signed in) and applies it; a failure leaves the month's rule.</summary>
        public static async Task Load(FirebaseClient fb)
        {
            if (fb == null || _loading) return;
            _loading = true;
            try { SetConfig(await fb.Data.ReadConfig("weather")); }
            catch (Exception e) { Debug.LogWarning("[Weather] " + e.Message); _loading = false; }
        }
    }
}
