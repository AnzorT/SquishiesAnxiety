// The app's vibration, on Android exactly as expo-haptics 13 makes it: Vibrator.vibrate(VibrationEffect.createWaveform(
// timings, amplitudes, -1)) with its patterns (below), or the old vibrate(pattern, -1) before Android 8. Unity has no
// such API, so it's called through JNI (AndroidVibrator); elsewhere (the editor, iOS) it does nothing. (iOS: the app
// uses the Taptic Engine's styles, which need a native plugin in Unity; not done.)
//
// Two users, as in the app:
//   GameHaptics (src/squishdoku/game.js makeHaptics(on), shared by Squishdoku, Sort, Stack and Hop; `on` is the
//   Vibration switch, App.js's vibrationEnabled): Tap = selection, Place = impact medium, Wrong = notification error,
//   Win = notification success, Tick = impact light.
//   SquishHaptics (src/haptics/squishHaptics.js, the squish stage, its strength = Poke strength 1-5): Press when the
//   finger lands (level 5 adds a light tap 70 ms later), Move on every real movement (rate-limited to one per
//   tickMs), Release when it lets go. The Android table (expo-haptics has three real strengths there).
using System;

namespace SquishSquad.Audio
{
    /// <summary>A vibration as expo-haptics sends it on Android.</summary>
    public sealed class HapticPattern
    {
        public readonly string Name;
        public readonly long[] Timings;
        public readonly int[] Amplitudes;
        public readonly long[] OldSdkPattern;

        public HapticPattern(string name, long[] timings, int[] amplitudes, long[] oldSdk)
        {
            Name = name;
            Timings = timings;
            Amplitudes = amplitudes;
            OldSdkPattern = oldSdk;
        }

        // expo-haptics/android HapticsImpactType, HapticsNotificationType, HapticsSelectionType
        public static readonly HapticPattern Light = new HapticPattern("impact light", new long[] { 0, 50 }, new[] { 0, 30 }, new long[] { 0, 20 });
        public static readonly HapticPattern Soft = new HapticPattern("impact soft", new long[] { 0, 50 }, new[] { 0, 30 }, new long[] { 0, 20 });
        public static readonly HapticPattern Medium = new HapticPattern("impact medium", new long[] { 0, 43 }, new[] { 0, 50 }, new long[] { 0, 43 });
        public static readonly HapticPattern Rigid = new HapticPattern("impact rigid", new long[] { 0, 43 }, new[] { 0, 50 }, new long[] { 0, 43 });
        public static readonly HapticPattern Heavy = new HapticPattern("impact heavy", new long[] { 0, 60 }, new[] { 0, 70 }, new long[] { 0, 61 });
        public static readonly HapticPattern Success = new HapticPattern("notification success", new long[] { 0, 40, 100, 40 }, new[] { 0, 50, 0, 60 }, new long[] { 0, 40, 100, 40 });
        public static readonly HapticPattern Warning = new HapticPattern("notification warning", new long[] { 0, 40, 120, 60 }, new[] { 0, 40, 0, 60 }, new long[] { 0, 40, 120, 60 });
        public static readonly HapticPattern Error = new HapticPattern("notification error", new long[] { 0, 60, 100, 40, 80, 50 }, new[] { 0, 50, 0, 40, 0, 50 }, new long[] { 0, 60, 100, 40, 80, 50 });
        public static readonly HapticPattern Selection = new HapticPattern("selection", new long[] { 0, 50 }, new[] { 0, 30 }, new long[] { 0, 70 });
    }

    public interface IVibrator
    {
        void Vibrate(HapticPattern p);
    }

    /// <summary>squishdoku/game.js makeHaptics(on).</summary>
    public sealed class GameHaptics
    {
        readonly bool _on;
        readonly IVibrator _v;

        public GameHaptics(bool on, IVibrator v = null)
        {
            _on = on;
            _v = v ?? AndroidVibrator.Shared;
        }

        void Fire(HapticPattern p)
        {
            if (_on) _v.Vibrate(p);
        }

        public void Tap() => Fire(HapticPattern.Selection);
        public void Place() => Fire(HapticPattern.Medium);
        public void Wrong() => Fire(HapticPattern.Error);
        public void Win() => Fire(HapticPattern.Success);
        public void Tick() => Fire(HapticPattern.Light);
    }

    /// <summary>src/haptics/squishHaptics.js (Android's table).</summary>
    public sealed partial class SquishHaptics
    {
        public struct Level
        {
            public HapticPattern Press, Tick, Release;
            public bool PressDouble;
            public double TickMs;
        }

        public static readonly Level[] Levels =
        {
            new Level { Press = HapticPattern.Light, PressDouble = false, Tick = HapticPattern.Light, TickMs = 150, Release = HapticPattern.Light },
            new Level { Press = HapticPattern.Medium, PressDouble = false, Tick = HapticPattern.Light, TickMs = 110, Release = HapticPattern.Light },
            new Level { Press = HapticPattern.Medium, PressDouble = false, Tick = HapticPattern.Medium, TickMs = 90, Release = HapticPattern.Light },
            new Level { Press = HapticPattern.Heavy, PressDouble = false, Tick = HapticPattern.Medium, TickMs = 75, Release = HapticPattern.Medium },
            new Level { Press = HapticPattern.Heavy, PressDouble = true, Tick = HapticPattern.Heavy, TickMs = 65, Release = HapticPattern.Medium },
        };

        public const double DoubleTapMs = 70;

        readonly IVibrator _v;
        readonly JsTimers _t;
        double _lastTickAt;

        public SquishHaptics(JsTimers timers, IVibrator v = null)
        {
            _t = timers;
            _v = v ?? AndroidVibrator.Shared;
        }

        /// <summary>levelFor: LEVELS[max(1, min(5, round(strength || 3)))].</summary>
        public static Level LevelFor(double strength)
        {
            double s = strength == 0 || double.IsNaN(strength) ? 3 : strength;
            int k = (int)Math.Max(1, Math.Min(5, Math.Floor(s + 0.5)));
            return Levels[k - 1];
        }

        /// <summary>The finger landed on the creature.</summary>
        public void Press(double strength)
        {
            var cfg = LevelFor(strength);
            _v.Vibrate(cfg.Press);
            if (cfg.PressDouble) _t.SetTimeout(() => _v.Vibrate(HapticPattern.Light), DoubleTapMs);
            _lastTickAt = _t.Now;
        }

        /// <summary>The finger moved (every real movement; rate-limited here).</summary>
        public void Move(double strength)
        {
            var cfg = LevelFor(strength);
            var now = _t.Now;
            if (now - _lastTickAt < cfg.TickMs) return;
            _lastTickAt = now;
            _v.Vibrate(cfg.Tick);
        }

        /// <summary>The finger let go of a squish.</summary>
        public void Release(double strength) => _v.Vibrate(LevelFor(strength).Release);
    }
}
