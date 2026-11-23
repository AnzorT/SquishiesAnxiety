// The app's `sfx` (src/audio/sfx.js) for the Unity screens: the same calls, names and behaviour (SfxCore), played by
// UnityAudio. Call from anywhere on the main thread; the first call sets it up (as App.js's sfx.init() at start-up:
// the remembered switches, then "tap" and "whoosh" loaded).
//
//   Sfx.Play("st_lift", rate: SfxRates.Stack(r, n));     Sfx.Play("achievement", delay: 250);
//   var hum = Sfx.Loop("holdLoop", volume: 0.42);  hum.SetRate(r);  hum.Stop();
//   Sfx.Preload(new[] { "fs_pop", ... });  Sfx.SetBudget(26) on a screen's open, Sfx.SetBudget(0) on its close
//   Sfx.Music("theme") / Sfx.Music(null)   (or Music.Follow(stage, onGame): App.js's rule)
//   Sfx.SetMusicOn(b), Sfx.SetEffectsOn(b), Sfx.Subscribe((effects, music) => ...)   (Settings' two switches)
//
// The switches are kept where the app keeps them, per device: <persistentDataPath>/soundSettings.json, the app's file
// name and JSON ({"effects":true,"music":true}); the app doesn't put them in the profile. They're also mirrored to
// PlayerPrefs squishsquad.sound.music / squishsquad.sound.effects (1 / 0), the keys Screens/Settings already uses, and
// read from there when the file isn't there yet.
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SquishSquad.Audio
{
    public static class Sfx
    {
        public const string PrefMusic = "squishsquad.sound.music", PrefEffects = "squishsquad.sound.effects";

        static SfxCore _core;

        sealed class DeviceFile : ISettingsFile
        {
            static string PathOf => System.IO.Path.Combine(Application.persistentDataPath, SfxCore.SettingsFileName);

            public string Read()
            {
                try
                {
                    if (File.Exists(PathOf)) return File.ReadAllText(PathOf);
                }
                catch (Exception)
                {
                    // as no file
                }
                // not written yet: what Settings stored in PlayerPrefs before the sound was ported
                if (!PlayerPrefs.HasKey(PrefMusic) && !PlayerPrefs.HasKey(PrefEffects)) return null;
                return SfxCore.SettingsJson(PlayerPrefs.GetInt(PrefEffects, 1) == 1, PlayerPrefs.GetInt(PrefMusic, 1) == 1);
            }

            public void Write(string text)
            {
                try { File.WriteAllText(PathOf, text); }
                catch (Exception e) { Debug.LogWarning("[Audio] " + e.Message); }
            }
        }

        /// <summary>The sound code (null in edit mode).</summary>
        public static SfxCore Core
        {
            get
            {
                if (_core != null) return _core;
                var host = UnityAudio.Instance;
                if (host == null) return null;
                _core = new SfxCore(host, host.Timers, new DeviceFile());
                host.ActiveChanged += a => _core?.SetActive(a);
                _core.Subscribe((effects, music) =>
                {
                    PlayerPrefs.SetInt(PrefEffects, effects ? 1 : 0);
                    PlayerPrefs.SetInt(PrefMusic, music ? 1 : 0);
                });
                _core.Init();
                return _core;
            }
        }

        /// <summary>sfx.init(): call once at start-up (App.js does at import), or let the first call do it.</summary>
        public static void Init() => _ = Core;

        public static bool EffectsOn => Core?.EffectsOn ?? true;
        public static bool MusicOn => Core?.MusicOn ?? true;

        /// <summary>A one-shot effect; `delay` in ms; `rate` plays it faster and higher (null: the player's rate as is).</summary>
        public static void Play(string name, double delay = 0, double? rate = null)
        {
            if (!Knows(name)) Debug.LogWarning("[Audio] no effect named " + name);
            Core?.Play(name, delay, rate);
        }

        public static SfxCore.LoopHandle Loop(string name, double volume = 1, double rate = 1) => Core?.Loop(name, volume, rate);

        public static void Preload(IEnumerable<string> names) => Core?.Preload(names);

        /// <summary>How many effects may stay loaded while a screen is open (0 = back to the app's 8).</summary>
        public static void SetBudget(int n) => Core?.SetBudget(n);

        public static void Music(string name) => Core?.Music(name);

        public static void SetEffectsOn(bool on) => Core?.SetEffectsOn(on);

        public static void SetMusicOn(bool on) => Core?.SetMusicOn(on);

        /// <summary>fn(effects, music) now and on every change; returns the unsubscribe.</summary>
        public static Action Subscribe(Action<bool, bool> fn) => Core?.Subscribe(fn) ?? (() => { });

        public static bool Knows(string name) => name != null && SoundFiles.Effects.ContainsKey(name);
    }
}
