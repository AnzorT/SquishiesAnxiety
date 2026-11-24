// What the menu shows: the player's level (1-30) and the season. Until the Firebase profile is ported, the level is a
// local setting; the season is today's weather as the app picks it (Menu/Weather.cs: Firestore config/weather, else the
// month exactly like main-menu-scene.js autoSeason()), unless the debug panel pins one.
using System;
using UnityEngine;

namespace SquishSquad.Menu
{
    public static class MenuState
    {
        const string LevelKey = "menu.level", SeasonKey = "menu.season";

        public static int Level
        {
            get => Mathf.Clamp(PlayerPrefs.GetInt(LevelKey, 1), 1, 30);
            set { PlayerPrefs.SetInt(LevelKey, Mathf.Clamp(value, 1, 30)); PlayerPrefs.Save(); }
        }

        // "auto" (by month), "sunny", "rainy" or "snowy"
        public static string SeasonSetting
        {
            get => PlayerPrefs.GetString(SeasonKey, "auto");
            set { PlayerPrefs.SetString(SeasonKey, value); PlayerPrefs.Save(); }
        }

        /// <summary>The Squish Stack level the player is on (the profile's stack.lv once Firebase is in).</summary>
        public static int StackLevel
        {
            get => Mathf.Clamp(PlayerPrefs.GetInt("stack.level", 1), 1, 50);
            set { PlayerPrefs.SetInt("stack.level", Mathf.Clamp(value, 1, 50)); PlayerPrefs.Save(); }
        }

        /// <summary>The Squish Sort fridge level the player is on (sort.fridge in the profile once it's wired).</summary>
        public static int SortLevel
        {
            get => Mathf.Clamp(PlayerPrefs.GetInt("sort.level", 1), 1, 50);
            set { PlayerPrefs.SetInt("sort.level", Mathf.Clamp(value, 1, 50)); PlayerPrefs.Save(); }
        }

        /// <summary>The Squish Hop level the player was last on (hop.lv in the profile once it's wired).</summary>
        public static int HopLevel
        {
            get => Mathf.Clamp(PlayerPrefs.GetInt("hop.level", 1), 1, 100);
            set { PlayerPrefs.SetInt("hop.level", Mathf.Clamp(value, 1, 100)); PlayerPrefs.Save(); }
        }

        // 2026-11-21 (webgame/patches.mjs: the menu's world and the house ask the app's SquishWeatherNow before their own
        // month rule): today's weather from config/weather (Weather.Today)
        public static string Season => SeasonSetting == "auto" ? AutoSeason(DateTime.Now) : SeasonSetting;

        // today's weather: config/weather's one option, else the month's (main-menu-scene.js: Dec-Feb snowy, May-Sep
        // sunny, otherwise rainy) when it is listed
        public static string AutoSeason(DateTime now) => Weather.Today(now);
    }
}
