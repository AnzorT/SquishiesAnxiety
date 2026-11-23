// Squish Sort's whole screen in Unity (src/screens/SortScreen.js): the hub (SortHub: the Snack Fridge and the Toy
// Cupboard), the chosen container's 50-level map (the shared LevelMap) and a level (SortGame in that container),
// sliding in over each other; HOW TO PLAY on the first visit. See Games/Shared/GameScreenHost.cs. The record is
// SortGame.Profile (each container's own, in memory until Firebase).
//   var s = SortScreen.Create(parent); s.OnExit = ...;   (BLITZ: s.OpenBlitz, else a note)
using System;
using System.Collections.Generic;
using SquishSquad.Games.Shared;
using UnityEngine;

namespace SquishSquad.Games.Sort
{
    public sealed class SortScreen : GameScreenHost
    {
        public static SortScreen Create(Transform parent, float screenW = 0, float screenH = 0) => Make<SortScreen>(parent, "Squish Sort", screenW, screenH);

        /// <summary>The level playing now in a container (NEXT moves it on): for the menu to remember.</summary>
        public Action<string, int> OnLevel;

        protected override IDictionary<string, object> Profile => SortGame.Profile;
        protected override GameDef MakeDef(IDictionary<string, object> profile) => new SortDef(profile);

        protected override MonoBehaviour MakeLevel(Transform parent, int lv, string theme, Action onExit)
        {
            var g = SortGame.Create(parent, lv, ScreenW, ScreenH, theme);
            g.OnLevel = n => OnLevel?.Invoke(theme, n);
            g.OnExit = onExit;
            g.Init(Time.unscaledTimeAsDouble * 1000);
            return g;
        }
    }
}
