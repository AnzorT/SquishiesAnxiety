// Haptics on the phone: Android's Vibrator through JNI (Haptics.cs has the app's patterns and rules, plain C#).
using System;
using UnityEngine;

namespace SquishSquad.Audio
{
    public sealed partial class SquishHaptics
    {
        static SquishHaptics _shared;
        /// <summary>The app's one (module-level lastTickAt). Null in edit mode.</summary>
        public static SquishHaptics Shared
        {
            get
            {
                if (_shared != null) return _shared;
                var host = UnityAudio.Instance;
                return host == null ? null : _shared = new SquishHaptics(host.Timers);
            }
        }
    }

    /// <summary>Android's Vibrator through JNI, as expo-haptics calls it. Needs android.permission.VIBRATE, which Unity
    /// adds to the manifest because the Android build of this script references Handheld.Vibrate (its fallback).</summary>
    public sealed class AndroidVibrator : IVibrator
    {
        public static readonly AndroidVibrator Shared = new AndroidVibrator();

        /// <summary>Every vibration asked for, for the editor's console (off by default).</summary>
        public static bool LogInEditor;

#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaObject _vibrator;
        int _sdk = -1;
        bool _failed;

        AndroidJavaObject Vibrator()
        {
            if (_vibrator != null || _failed) return _vibrator;
            try
            {
                using (var version = new AndroidJavaClass("android.os.Build$VERSION")) _sdk = version.GetStatic<int>("SDK_INT");
                using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                using (var activity = player.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    if (_sdk >= 31)
                    {
                        using (var manager = activity.Call<AndroidJavaObject>("getSystemService", "vibrator_manager"))
                            _vibrator = manager.Call<AndroidJavaObject>("getDefaultVibrator");
                    }
                    else _vibrator = activity.Call<AndroidJavaObject>("getSystemService", "vibrator");
                }
            }
            catch (Exception e)
            {
                _failed = true;
                Debug.LogWarning("[Haptics] " + e.Message);
            }
            return _vibrator;
        }
#endif

        public void Vibrate(HapticPattern p)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var v = Vibrator();
            if (v == null) { Handheld.Vibrate(); return; }
            try
            {
                if (_sdk >= 26)
                {
                    using (var cls = new AndroidJavaClass("android.os.VibrationEffect"))
                    using (var effect = cls.CallStatic<AndroidJavaObject>("createWaveform", p.Timings, p.Amplitudes, -1))
                        v.Call("vibrate", effect);
                }
                else v.Call("vibrate", p.OldSdkPattern, -1);
            }
            catch (Exception)
            {
                // no vibrator (emulator) or haptics off: nothing to do, as the app
            }
#else
            if (LogInEditor) Debug.Log("[Haptics] " + p.Name);
#endif
        }
    }
}
