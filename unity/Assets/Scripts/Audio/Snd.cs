// The game code's door to the sound and haptics, with no UnityEngine in it, so the test harnesses (tools/unity/*-test)
// compile the game files as they are (there the calls do nothing). In the app, Sfx wires it at start-up
// (Sfx.Wire, before the first scene loads): Snd.Play is Sfx.Play, Snd.Tap() etc. are squishdoku/game.js makeHaptics.
using System;
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public interface ISndLoop
    {
        void SetRate(double r);
        void SetVolume(double v);
        void Stop();
    }

    public static class Snd
    {
        public static Action<string, double, double?> PlayFn;
        public static Func<string, double, double, ISndLoop> LoopFn;
        public static Action<IEnumerable<string>> PreloadFn;
        public static Action<int> BudgetFn;
        /// <summary>"tap", "place", "wrong", "win", "tick", "light", "medium", "heavy", "success", "warning", "error", "selection".</summary>
        public static Action<string> HapticFn;

        /// <summary>The game's haptics switch (the profile's; Squish Time's own Vibration switch sets it too).</summary>
        public static bool HapticsOn = true;

        public static void Play(string name, double delay = 0, double? rate = null) => PlayFn?.Invoke(name, delay, rate);
        public static ISndLoop Loop(string name, double volume = 1, double rate = 1) => LoopFn?.Invoke(name, volume, rate);
        public static void Preload(IEnumerable<string> names) => PreloadFn?.Invoke(names);
        /// <summary>A screen's sound budget on open; 0 on its close (the app's setBudget(null)).</summary>
        public static void Budget(int n) => BudgetFn?.Invoke(n);

        public static void Haptic(string kind)
        {
            if (HapticsOn) HapticFn?.Invoke(kind);
        }

        public static void Tap() => Haptic("tap");
        public static void Place() => Haptic("place");
        public static void Wrong() => Haptic("wrong");
        public static void Win() => Haptic("win");
        public static void Tick() => Haptic("tick");
    }
}
