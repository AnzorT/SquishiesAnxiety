// What the menu shows: the player's level (1-30) and the season. Until the Firebase profile is ported, the level is a
// local setting; the season follows the month exactly like main-menu-scene.js autoSeason().
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

        public static string Season => SeasonSetting == "auto" ? AutoSeason(DateTime.Now) : SeasonSetting;

        // main-menu-scene.js: Dec-Feb snowy, May-Sep sunny, otherwise rainy
        public static string AutoSeason(DateTime now)
        {
            int mo = now.Month - 1;
            return mo == 11 || mo <= 1 ? "snowy" : mo >= 4 && mo <= 8 ? "sunny" : "rainy";
        }
    }
}
