// What the plain C# sound code reaches for in its Unity half (Sfx.cs, Haptics.Android.cs), here on a recording core.
using System;
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public static class Sfx
    {
        public static SfxCore Core;
        public static readonly List<string> Calls = new List<string>();
        public static bool EffectsOn => Core?.EffectsOn ?? true;

        public static void Play(string name, double delay = 0, double? rate = null)
        {
            Calls.Add("play " + name + " " + delay + " " + (rate?.ToString("R") ?? "-"));
            Core?.Play(name, delay, rate);
        }

        public static SfxCore.LoopHandle Loop(string name, double volume = 1, double rate = 1) => Core?.Loop(name, volume, rate);

        public static void Music(string name, double fadeInMs = SfxCore.FadeInMs, double fadePower = 1)
        {
            Calls.Add("music " + (name ?? "null"));
            Core?.Music(name, fadeInMs, fadePower);
        }
    }

    public sealed class AndroidVibrator : IVibrator
    {
        public static readonly AndroidVibrator Shared = new AndroidVibrator();
        public void Vibrate(HapticPattern p) { }
    }
}
