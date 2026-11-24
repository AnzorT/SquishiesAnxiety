// The player under the sound code: one AudioSource per expo-av Sound the app would have (an effect's voice, a loop,
// the music, the squish stage's own players), on one DontDestroyOnLoad object made on first use. It also runs the JS
// timers every frame on the real clock and tells the code when the app goes to the background.
//
// The app's rate is expo-av's with shouldCorrectPitch false: ExoPlayer's PlaybackParameters(rate, pitch = rate), i.e.
// played faster and higher together. AudioSource.pitch is exactly that (it resamples). Volumes are linear gains in
// both. Clips come from Resources/Audio (tools/unity/export-audio.mjs), loaded synchronously the first time a sound
// needs them, as the app's players are made on first use.
using System.Collections.Generic;
using UnityEngine;

namespace SquishSquad.Audio
{
    public sealed class UnityAudio : MonoBehaviour, ISoundBackend
    {
        static UnityAudio _instance;
        static bool _quitting;

        /// <summary>The player (made on first use, while the app runs; null in edit mode or while quitting).</summary>
        public static UnityAudio Instance
        {
            get
            {
                if (_instance != null || _quitting || !Application.isPlaying) return _instance;
                var go = new GameObject("Audio");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<UnityAudio>();
                return _instance;
            }
        }

        /// <summary>The JS clock: ms, from a large start (Date.now's size, so the first tap is never "too soon").</summary>
        public static double NowMs => 1.7e12 + Time.realtimeSinceStartupAsDouble * 1000.0;

        JsTimers _timers;
        public JsTimers Timers => _timers ??= new JsTimers(NowMs);

        sealed class Player
        {
            public AudioSource Src;
            public string File;
            public bool Paused;
        }

        readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();
        readonly Stack<AudioSource> _free = new Stack<AudioSource>();
        readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();
        readonly Dictionary<string, int> _clipUsers = new Dictionary<string, int>();
        int _nextId = 1;

        /// <summary>Called with false when the app goes to the background, true when it's back.</summary>
        public event System.Action<bool> ActiveChanged;

        void Update() => Timers.AdvanceTo(NowMs);

        void OnApplicationPause(bool paused) => ActiveChanged?.Invoke(!paused);

        void OnApplicationQuit() => _quitting = true;

        void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }

        /// <summary>A clip from Resources/Audio by the app's file name (null when it's missing).</summary>
        public AudioClip Clip(string file)
        {
            if (_clips.TryGetValue(file, out var c) && c != null) return c;
            c = Resources.Load<AudioClip>(SoundFiles.ResourcePath(file));
            if (c == null) Debug.LogWarning("[Audio] no clip for " + file + " (run tools/unity/export-audio.mjs)");
            _clips[file] = c;
            return c;
        }

        AudioSource Take()
        {
            while (_free.Count > 0)
            {
                var s = _free.Pop();
                if (s != null) return s;
            }
            var src = gameObject.AddComponent<AudioSource>();
            src.playOnAwake = false;
            src.spatialBlend = 0;   // 2D, as a phone speaker
            src.dopplerLevel = 0;
            return src;
        }

        // ---- ISoundBackend ---------------------------------------------------------------------------------------------

        public int Create(string file, SoundInit init)
        {
            var clip = Clip(file);
            if (clip == null) return 0;
            if (clip.loadState == AudioDataLoadState.Unloaded) clip.LoadAudioData();
            return CreateWith(clip, file, init);
        }

        /// <summary>A player for a clip made at run time (a downloaded sound).</summary>
        public int CreateFromClip(AudioClip clip, SoundInit init) => clip == null ? 0 : CreateWith(clip, "clip:" + clip.GetInstanceID(), init);

        int CreateWith(AudioClip clip, string file, SoundInit init)
        {
            var src = Take();
            src.clip = clip;
            src.loop = init.Looping;
            src.volume = (float)init.Volume;
            src.pitch = (float)(init.Rate == 0 ? 1 : init.Rate);
            src.time = 0;
            int id = _nextId++;
            _players[id] = new Player { Src = src, File = file };
            _clipUsers[file] = (_clipUsers.TryGetValue(file, out var n) ? n : 0) + 1;
            if (init.ShouldPlay) src.Play();
            return id;
        }

        public void Replay(int sound, double? rate)
        {
            if (!_players.TryGetValue(sound, out var p)) return;
            if (rate.HasValue) p.Src.pitch = (float)rate.Value;
            p.Src.Stop();
            p.Src.time = 0;
            p.Src.Play();
            p.Paused = false;
        }

        public void SetVolume(int sound, double volume)
        {
            if (_players.TryGetValue(sound, out var p)) p.Src.volume = Mathf.Clamp01((float)volume);
        }

        public void SetRate(int sound, double rate)
        {
            if (_players.TryGetValue(sound, out var p)) p.Src.pitch = (float)rate;
        }

        public void Play(int sound)
        {
            if (!_players.TryGetValue(sound, out var p)) return;
            if (p.Paused) p.Src.UnPause();
            else if (!p.Src.isPlaying) p.Src.Play();
            p.Paused = false;
        }

        public void Pause(int sound)
        {
            if (!_players.TryGetValue(sound, out var p)) return;
            p.Src.Pause();
            p.Paused = true;
        }

        public void Unload(int sound)
        {
            if (!_players.TryGetValue(sound, out var p)) return;
            _players.Remove(sound);
            p.Src.Stop();
            if (p.File.StartsWith("clip:") && p.Src.clip != null) Destroy(p.Src.clip);   // a downloaded one
            p.Src.clip = null;
            p.Src.pitch = 1;
            p.Src.volume = 1;
            p.Src.loop = false;
            _free.Push(p.Src);
            // the app frees a player's decoder with it; here the clip's samples go once no player uses them
            if (_clipUsers.TryGetValue(p.File, out var n) && --n <= 0)
            {
                _clipUsers.Remove(p.File);
                if (_clips.TryGetValue(p.File, out var c) && c != null) c.UnloadAudioData();
            }
            else _clipUsers[p.File] = n;
        }

        // Mixing with other apps and ducking them is Android's default for a game's audio focus; nothing to set.
        public void SetMode() { }

        /// <summary>Whether a sound is audible now (the dev panel, tests in the editor).</summary>
        public bool IsPlaying(int sound) => _players.TryGetValue(sound, out var p) && p.Src.isPlaying;
    }
}
