// Squish Stack's whole screen in Unity (src/screens/StackScreen.js): the hub (StackHub), REGULAR's 50-level map (the
// shared LevelMap) and a level (StackGame), sliding in over each other; HOW TO PLAY on the first visit. See
// Games/Shared/GameScreenHost.cs. The record is StackGame.Profile (in memory until Firebase).
//   var s = StackScreen.Create(parent); s.OnExit = ...;   (BLITZ: s.OpenBlitz, else a note)
using System;
using System.Collections.Generic;
using SquishSquad.Games.Shared;
using UnityEngine;

namespace SquishSquad.Games.Stack
{
    public sealed class StackScreen : GameScreenHost
    {
        public static StackScreen Create(Transform parent, float screenW = 0, float screenH = 0) => Make<StackScreen>(parent, "Squish Stack", screenW, screenH);

        protected override IDictionary<string, object> Profile => StackGame.Profile;
        protected override GameDef MakeDef(IDictionary<string, object> profile) => new StackDef(profile) { Walker = ChosenKey(profile) };

        // the forest map's walker: the player's selected character (StackScreen.js: BY_ID[selectedId(profile)].key; the
        // Menu's pick, src/squad/lobby.js), Mittens when there's none
        static Dictionary<string, string> _keyOfId;
        static string ChosenKey(IDictionary<string, object> profile)
        {
            if (_keyOfId == null)
            {
                _keyOfId = new Dictionary<string, string>();
                var text = Resources.Load<TextAsset>("Squish/squish")?.text;
                if (text != null && Backend.Json.Parse(text) is IDictionary<string, object> data && data.TryGetValue("roster", out var r) && r is IList<object> roster)
                    foreach (var c in roster)
                        if (c is IDictionary<string, object> e && e.TryGetValue("key", out var k) && k is string ks) _keyOfId[Convert.ToString(e["id"], System.Globalization.CultureInfo.InvariantCulture)] = ks;
            }
            var id = profile != null ? Menu.CharactersPageLink.SelectedId(profile) : null;
            return id != null && _keyOfId.TryGetValue(id, out var key) ? key : "mittens";
        }

        protected override MonoBehaviour MakeLevel(Transform parent, int lv, string theme, Action onExit)
        {
            var g = StackGame.Create(parent, lv, ScreenW, ScreenH);
            g.OnExit = onExit;
            g.Init(Time.unscaledTimeAsDouble * 1000);
            return g;
        }
    }
}
