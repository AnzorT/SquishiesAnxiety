// What the sound code asks of the player, one call per expo-av call the app makes (Audio.Sound.createAsync, replayAsync,
// setVolumeAsync, setRateAsync(r, shouldCorrectPitch false), playAsync, pauseAsync, unloadAsync, setAudioModeAsync).
// UnityAudio implements it with AudioSources; tools/unity/audio-test records it, next to the same calls the JS makes.
namespace SquishSquad.Audio
{
    /// <summary>The status a sound is made with (createAsync's initial status).</summary>
    public struct SoundInit
    {
        public bool ShouldPlay, Looping;
        public double Volume, Rate;

        public static SoundInit Effect(double volume = 1) => new SoundInit { Volume = volume, Rate = 1 };
    }

    public interface ISoundBackend
    {
        /// <summary>Makes a player for `file` (the app's path under assets/audio, e.g. "sfx/tap.wav"). 0: it couldn't
        /// (createAsync rejected).</summary>
        int Create(string file, SoundInit init);

        /// <summary>From the top, playing; `rate` (speed and pitch together, as expo-av with shouldCorrectPitch false)
        /// when given, else the rate it had.</summary>
        void Replay(int sound, double? rate);

        void SetVolume(int sound, double volume);
        void SetRate(int sound, double rate);
        void Play(int sound);
        void Pause(int sound);
        void Unload(int sound);

        /// <summary>Audio.setAudioModeAsync (mix with other apps, duck them on Android): once.</summary>
        void SetMode();
    }

    /// <summary>The device file the switches are kept in (the app: documentDirectory/soundSettings.json).</summary>
    public interface ISettingsFile
    {
        /// <summary>The file's text, or null when there's none.</summary>
        string Read();

        void Write(string text);
    }
}
