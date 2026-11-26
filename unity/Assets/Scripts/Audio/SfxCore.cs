// src/audio/sfx.js, line by line: the app's ~95 effects and its one music track.
//
//   Play("tap")                      one-shot effect (delay ms, rate = speed and pitch together)
//   var h = Loop("reelLoop")         looping effect -> h.SetRate(r), h.SetVolume(v), h.Stop()
//   Music("theme")                   fades the track in (null = silence); Music(name, ms, power): a longer, eased fade
//
// Effects are kept loaded and restarted on each play, at most `budget` of them (8, or what the screen open asks for:
// SetBudget), the least recently played released first; "tap" and "whoosh" are loaded at the start and never released.
// "boxBell" has two players, round robin, so a fast repeat doesn't cut the last one short; every other effect has one,
// so a replay restarts it. A player keeps the rate it was last given: a Play without a rate plays at the rate of the
// previous one (expo-av's replayAsync only changes what it's given; the app relies on this nowhere, but it's what
// the app does). A second "tap" within 100 ms is dropped. Preload makes players one every 40 ms.
// Music: 0.3 x the track's gain (Velvet Map Study: 0.5) = 0.15; fades in over 1200 ms and out over 900 ms in 50 ms
// steps; the same track asked again keeps playing. Both switches (Settings) are kept in soundSettings.json on the
// device, `{"effects":true,"music":true}`, and nothing plays while the app is in the background.
// Plain C#: the host (UnityAudio) gives it a player and the clock.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SquishSquad.Audio
{
    public sealed class SfxCore
    {
        // ---- the app's numbers (sfx.js) ----------------------------------------------------------------------------
        public const double TapGapMs = 100;
        public const double MusicVolume = 0.3;
        public static readonly IReadOnlyDictionary<string, double> TrackGain = new Dictionary<string, double> { { "theme", 0.5 } };
        public const double FadeInMs = 1200, FadeOutMs = 900, FadeStepMs = 50;
        public static readonly string[] Warm = { "tap", "whoosh" };
        public const int MaxLoaded = 8;
        public static readonly IReadOnlyDictionary<string, int> Voices = new Dictionary<string, int> { { "boxBell", 2 } };
        public const double PreloadGap = 40;
        public const string SettingsFileName = "soundSettings.json";

        public static double VolumeOf(string name) => MusicVolume * (TrackGain.TryGetValue(name, out var g) ? g : 1);

        // ---- state ---------------------------------------------------------------------------------------------------
        readonly ISoundBackend _p;
        readonly JsTimers _t;
        readonly ISettingsFile _file;
        readonly IReadOnlyDictionary<string, string> _effects, _music;

        sealed class Entry
        {
            public string Name;
            public int[] Voices;   // 0: that player failed to load
            public int Next;
            public double Used;
        }

        sealed class Track
        {
            public string Name;
            public int Sound;
            public bool Stopped;
        }

        public bool EffectsOn { get; private set; } = true;
        public bool MusicOn { get; private set; } = true;
        public bool Active { get; private set; } = true;
        public int Budget => _budget;

        readonly List<Entry> _players = new List<Entry>();   // in the order they were made (a JS Map's order)
        readonly List<LoopHandle> _loops = new List<LoopHandle>();
        Track _track;
        string _want;
        readonly Dictionary<int, int> _fading = new Dictionary<int, int>();   // sound -> interval
        readonly List<Action<bool, bool>> _listeners = new List<Action<bool, bool>>();
        int _budget = MaxLoaded;
        double _lastTap;
        bool _modeSet;
        readonly List<string> _preloadQueue = new List<string>();
        int _preloading;   // the pump's timer, 0 = idle
        bool _pumping;

        public SfxCore(ISoundBackend player, JsTimers timers, ISettingsFile file, IReadOnlyDictionary<string, string> effects = null,
            IReadOnlyDictionary<string, string> music = null, bool active = true)
        {
            _p = player;
            _t = timers;
            _file = file;
            _effects = effects ?? SoundFiles.Effects;
            _music = music ?? SoundFiles.Music;
            Active = active;
        }

        /// <summary>The names Play knows (the app's EFFECTS).</summary>
        public bool Knows(string name) => name != null && _effects.ContainsKey(name);

        /// <summary>Effects loaded now (in the order they were made), for tests and the dev panel.</summary>
        public IEnumerable<string> Loaded => _players.Select(e => e.Name);

        /// <summary>The track playing (or fading in), null for none.</summary>
        public string Playing => _track?.Name;

        void SetMode()
        {
            if (_modeSet) return;
            _modeSet = true;
            _p.SetMode();
        }

        Entry Find(string name)
        {
            foreach (var e in _players) if (e.Name == name) return e;
            return null;
        }

        Entry GetEntry(string name)
        {
            if (!Knows(name)) return null;
            var e = Find(name);
            if (e == null)
            {
                SetMode();
                int n = Voices.TryGetValue(name, out var v) ? v : 1;
                var file = _effects[name];
                var voices = new int[n];
                for (int i = 0; i < n; i++) voices[i] = _p.Create(file, SoundInit.Effect());
                e = new Entry { Name = name, Voices = voices, Next = 0, Used = 0 };
                _players.Add(e);
                Evict(name);
            }
            e.Used = _t.Now;
            return e;
        }

        // Release the least recently played effects beyond the budget.
        void Evict(string keep)
        {
            var loaded = _players.Where(p => p.Name != keep && Array.IndexOf(Warm, p.Name) < 0).ToList();
            int extra = _players.Count - _budget;
            if (extra <= 0) return;
            foreach (var e in loaded.OrderBy(p => p.Used).Take(extra).ToList())
            {
                _players.Remove(e);
                foreach (var v in e.Voices) if (v != 0) _p.Unload(v);
            }
        }

        // ---- effects ---------------------------------------------------------------------------------------------------

        /// <summary>How many effects may stay loaded (0 or less = back to 8).</summary>
        public void SetBudget(int n)
        {
            _budget = n > 0 ? n : MaxLoaded;
            Evict(null);
        }

        void PumpPreload()
        {
            if (_preloadQueue.Count == 0)
            {
                _preloading = 0;
                _pumping = false;
                return;
            }
            var name = _preloadQueue[0];
            _preloadQueue.RemoveAt(0);
            if (EffectsOn && Find(name) == null) GetEntry(name);
            _pumping = true;
            _preloading = _t.SetTimeout(PumpPreload, PreloadGap);
        }

        /// <summary>Loads a screen's effects ahead of time, one every 40 ms.</summary>
        public void Preload(IEnumerable<string> names)
        {
            if (!EffectsOn) return;
            foreach (var n in names)
                if (Find(n) == null && !_preloadQueue.Contains(n)) _preloadQueue.Add(n);
            if (!_pumping) PumpPreload();
        }

        /// <summary>sfx.play(name, { delay, rate }): rate 0 / null = the player's rate as it is.</summary>
        public void Play(string name, double delay = 0, double? rate = null)
        {
            if (!EffectsOn || !Active) return;
            if (name == "tap" && delay == 0)
            {
                var now = _t.Now;
                if (now - _lastTap < TapGapMs) return;
                _lastTap = now;
            }
            void Go()
            {
                var e = GetEntry(name);
                if (e == null) return;
                var voice = e.Voices[e.Next];
                e.Next = (e.Next + 1) % e.Voices.Length;
                if (voice == 0) return;
                _p.Replay(voice, rate.HasValue && rate.Value != 0 && !double.IsNaN(rate.Value) ? rate : null);
            }
            if (delay != 0 && !double.IsNaN(delay)) _t.SetTimeout(Go, delay);
            else Go();
        }

        /// <summary>A looping effect, its own player (the reel's ticking, the unlock hold's hum, the wheel's whirl).</summary>
        public sealed class LoopHandle
        {
            readonly SfxCore _s;
            internal int Sound;
            internal bool Stopped;
            public double Volume { get; private set; }
            public double Rate { get; private set; }

            internal LoopHandle(SfxCore s, double volume, double rate)
            {
                _s = s;
                Volume = volume;
                Rate = rate;
            }

            public void SetRate(double r)
            {
                if (_s == null) return;
                Rate = r;
                if (Sound != 0) _s._p.SetRate(Sound, r);
            }

            public void SetVolume(double v)
            {
                if (_s == null) return;
                Volume = v;
                if (Sound != 0) _s._p.SetVolume(Sound, v);
            }

            public void Stop()
            {
                if (_s == null) return;
                Stopped = true;
                _s._loops.Remove(this);
                if (Sound != 0) _s._p.Unload(Sound);
            }
        }

        static readonly LoopHandle Silent = new LoopHandle(null, 0, 1);

        public LoopHandle Loop(string name, double volume = 1, double rate = 1)
        {
            if (!EffectsOn || !Knows(name)) return Silent;
            var h = new LoopHandle(this, volume, rate);
            SetMode();
            var s = _p.Create(_effects[name], new SoundInit { ShouldPlay = Active, Looping = true, Volume = volume, Rate = rate });
            if (s != 0)
            {
                h.Sound = s;
                _loops.Add(h);
            }
            return h;
        }

        // ---- music -------------------------------------------------------------------------------------------------------

        // power 1: sfx.js's straight line; 2 and up: the volume follows progress^power (stays soft longer, then swells)
        void Fade(int sound, double from, double to, double ms, Action done, double power = 1)
        {
            if (_fading.TryGetValue(sound, out var prev)) _t.Clear(prev);
            int steps = Math.Max(1, (int)Math.Floor(ms / FadeStepMs + 0.5));
            int i = 0;
            _p.SetVolume(sound, from);
            int timer = 0;
            timer = _t.SetInterval(() =>
            {
                i++;
                _p.SetVolume(sound, power == 1 ? from + ((to - from) * i) / steps : from + (to - from) * Math.Pow((double)i / steps, power));
                if (i >= steps)
                {
                    _t.Clear(timer);
                    _fading.Remove(sound);
                    done?.Invoke();
                }
            }, FadeStepMs);
            _fading[sound] = timer;
        }

        void StopTrack()
        {
            var tr = _track;
            _track = null;
            if (tr == null) return;
            tr.Stopped = true;
            if (tr.Sound != 0) Fade(tr.Sound, VolumeOf(tr.Name), 0, FadeOutMs, () => _p.Unload(tr.Sound));
        }

        void StartTrack(string name, double fadeInMs, double fadePower)
        {
            SetMode();
            var tr = new Track { Name = name };
            _track = tr;
            var s = _p.Create(_music[name], new SoundInit { ShouldPlay = Active, Looping = true, Volume = 0, Rate = 1 });
            if (s == 0) return;
            if (tr.Stopped) { _p.Unload(s); return; }
            tr.Sound = s;
            Fade(s, 0, VolumeOf(name), fadeInMs, null, fadePower);
        }

        /// <summary>sfx.music(name): the track to play (null = none); the one playing keeps playing. A track that starts
        /// fades in over `fadeInMs` (sfx.js: 1200), its volume following progress^`fadePower` (sfx.js: 1, a straight line).</summary>
        public void Music(string name, double fadeInMs = FadeInMs, double fadePower = 1)
        {
            _want = name != null && _music.ContainsKey(name) ? name : null;
            if (_track != null && _track.Name == _want && MusicOn) return;
            StopTrack();
            if (_want != null && MusicOn) StartTrack(_want, fadeInMs, fadePower);
        }

        // ---- switches ----------------------------------------------------------------------------------------------------

        static string B(bool v) => v ? "true" : "false";

        /// <summary>The settings file's text, as JSON.stringify writes it.</summary>
        public static string SettingsJson(bool effects, bool music) => "{\"effects\":" + B(effects) + ",\"music\":" + B(music) + "}";

        void SaveSettings() => _file?.Write(SettingsJson(EffectsOn, MusicOn));

        void Notify()
        {
            foreach (var fn in _listeners.ToArray()) fn(EffectsOn, MusicOn);
        }

        public void SetEffectsOn(bool on)
        {
            EffectsOn = on;
            if (!on) foreach (var h in _loops.ToArray()) if (h.Sound != 0) _p.Pause(h.Sound);
            SaveSettings();
            Notify();
        }

        public void SetMusicOn(bool on)
        {
            MusicOn = on;
            if (!on) StopTrack();
            else if (_want != null) Music(_want);
            SaveSettings();
            Notify();
        }

        /// <summary>Settings' switches: fn(effects, music) now and on every change; returns the unsubscribe.</summary>
        public Action Subscribe(Action<bool, bool> fn)
        {
            _listeners.Add(fn);
            fn(EffectsOn, MusicOn);
            return () => _listeners.Remove(fn);
        }

        // JSON.parse(text) then `saved.effects !== false`: only a literal false turns a switch off; text that isn't a JSON
        // object (or null) keeps the defaults.
        static readonly Regex ObjectRx = new Regex(@"^\s*\{[\s\S]*\}\s*$");
        static bool? SavedFalse(string text, string key)
        {
            var m = Regex.Match(text, "\"" + key + "\"\\s*:\\s*(true|false|null|-?[0-9.eE+-]+|\"(?:[^\"\\\\]|\\\\.)*\"|\\{|\\[)");
            return m.Success && m.Groups[1].Value == "false";
        }

        /// <summary>The remembered switches, then "tap" and "whoosh" loaded.</summary>
        public void Init()
        {
            try
            {
                var text = _file?.Read();
                if (text != null && ObjectRx.IsMatch(text))
                {
                    EffectsOn = SavedFalse(text, "effects") != true;
                    MusicOn = SavedFalse(text, "music") != true;
                    Notify();
                    if (!MusicOn) StopTrack();
                }
            }
            catch (Exception)
            {
                // defaults
            }
            foreach (var n in Warm) GetEntry(n);
        }

        /// <summary>AppState: nothing plays while the app is in the background (music and loops pause, and resume).</summary>
        public void SetActive(bool active)
        {
            if (active == Active) return;
            Active = active;
            var sounds = new List<int>();
            if (_track != null && _track.Sound != 0) sounds.Add(_track.Sound);
            if (EffectsOn) foreach (var h in _loops) if (h.Sound != 0) sounds.Add(h.Sound);
            foreach (var s in sounds)
                if (active) _p.Play(s);
                else _p.Pause(s);
        }
    }
}
