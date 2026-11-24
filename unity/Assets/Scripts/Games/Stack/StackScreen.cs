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
        protected override GameDef MakeDef(IDictionary<string, object> profile) => new StackDef(profile);

        protected override MonoBehaviour MakeLevel(Transform parent, int lv, string theme, Action onExit)
        {
            var g = StackGame.Create(parent, lv, ScreenW, ScreenH);
            g.OnExit = onExit;
            g.Init(Time.unscaledTimeAsDouble * 1000);
            return g;
        }
    }
}
