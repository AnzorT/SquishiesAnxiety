// The yard games' saved bests and plays, as the app's page keeps them (yard-games.js: localStorage yardgames.v1,
// { best: { id: n }, plays: { id: n }, player: creature id }). The games themselves (the app's own, compiled: YardJs)
// keep it in the realm's localStorage; Unity keeps the same text on the device (PlayerPrefs "yardgames.v1"), hands it
// to the realm when it starts (NativeRig's file 'local/yardgames.v1') and reads it back after each game, and the Yard
// Games page shows its bests. Plain C#.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SquishSquad.Games.Yard
{
    public sealed class YardSave
    {
        public readonly Dictionary<string, int> Best = new Dictionary<string, int>(), Plays = new Dictionary<string, int>();
        /// <summary>The page's JSON as it is (its other keys kept).</summary>
        public string Json = "{}";

        /// <summary>Reads the page's JSON (best and plays: { "id": n, ... }).</summary>
        public static YardSave Parse(string json)
        {
            var s = new YardSave { Json = string.IsNullOrEmpty(json) ? "{}" : json };
            Read(s.Json, "best", s.Best);
            Read(s.Json, "plays", s.Plays);
            return s;
        }

        static readonly Regex Pair = new Regex("\"([^\"]+)\"\\s*:\\s*(-?[\\d.]+)");
        static void Read(string json, string key, Dictionary<string, int> into)
        {
            int k = json.IndexOf("\"" + key + "\"", StringComparison.Ordinal);
            if (k < 0) return;
            int a = json.IndexOf('{', k), b = a < 0 ? -1 : json.IndexOf('}', a);
            if (a < 0 || b < 0) return;
            foreach (Match m in Pair.Matches(json.Substring(a + 1, b - a - 1)))
                if (double.TryParse(m.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var v)) into[m.Groups[1].Value] = (int)v;
        }
    }
}
