// Squish Hop's whole screen in Unity (src/screens/HopScreen.js): the level map (the shared LevelMap, a band per Crib
// room) and a level (HopGame) sliding in over it; the "?" orb and the first visit open HOW TO PLAY. See
// Games/Shared/GameScreenHost.cs. The record is HopGame.Profile (in memory until Firebase).
//   var s = HopScreen.Create(parent); s.OnExit = ...;
using System;
using System.Collections.Generic;
using SquishSquad.Games.Shared;
using UnityEngine;

namespace SquishSquad.Games.Hop
{
    public sealed class HopScreen : GameScreenHost
    {
        public static HopScreen Create(Transform parent, float screenW = 0, float screenH = 0) => Make<HopScreen>(parent, "Squish Hop", screenW, screenH);

        /// <summary>The level last played (for the menu to remember).</summary>
        public Action<int> OnLevel;

        protected override IDictionary<string, object> Profile => HopGame.Profile;
        protected override GameDef MakeDef(IDictionary<string, object> profile) => new HopDef(profile);

        protected override MonoBehaviour MakeLevel(Transform parent, int lv, string theme, Action onExit)
        {
            var g = HopGame.Create(parent, lv, ScreenW, ScreenH);
            g.OnExit = () => { if (g.Level != null) OnLevel?.Invoke(g.Level.Lv); onExit(); };
            g.Init(Time.unscaledTimeAsDouble * 1000);
            return g;
        }
    }
}
