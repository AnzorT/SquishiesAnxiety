// MenuSynth's playback in Unity (the renderer is MenuSynth.cs, plain C#).
using System.Collections.Generic;
using UnityEngine;

namespace SquishSquad.Audio
{
    public static partial class MenuSynth
    {
        // ---- playing them -------------------------------------------------------------------------------------------------
        /// <summary>The yard games' mute (the menu never shows it, so it's off).</summary>
        public static bool Muted
        {
            get => PlayerPrefs.GetInt("yardgames.v1.mute", 0) == 1;
            set => PlayerPrefs.SetInt("yardgames.v1.mute", value ? 1 : 0);
        }

        /// <summary>false: as the app (the menu's sounds play with Settings' "Sound effects" off). true: they follow it.</summary>
        public static bool FollowEffectsSwitch = false;

        static readonly Dictionary<string, AudioClip[]> Clips = new Dictionary<string, AudioClip[]>();
        static readonly Dictionary<string, int> Turn = new Dictionary<string, int>();
        static readonly List<AudioSource> Sources = new List<AudioSource>();

        /// <summary>menu.js sfx(n): plays YardGames.SFX[n] (unknown names: nothing, as the page's try / if).</summary>
        public static void Play(string name)
        {
            if (Muted || !Sounds.ContainsKey(name)) return;
            if (FollowEffectsSwitch && !Sfx.EffectsOn) return;
            var host = UnityAudio.Instance;
            if (host == null) return;
            if (!Clips.TryGetValue(name, out var clips))
            {
                int k = HasNoise(name) ? 3 : 1;
                clips = new AudioClip[k];
                for (int v = 0; v < k; v++)
                {
                    var s = Samples(name, v);
                    var c = AudioClip.Create("menu-" + name + "-" + v, s.Length, 1, Rate, false);
                    c.SetData(s, 0);
                    clips[v] = c;
                }
                Clips[name] = clips;
            }
            int turn = Turn.TryGetValue(name, out var t) ? t : 0;
            Turn[name] = turn + 1;
            // each play is its own source, as each Web Audio node graph is: overlapping plays sum
            AudioSource src = null;
            foreach (var a in Sources) if (a != null && !a.isPlaying) { src = a; break; }
            if (src == null)
            {
                src = host.gameObject.AddComponent<AudioSource>();
                src.playOnAwake = false;
                src.spatialBlend = 0;
                Sources.Add(src);
            }
            src.clip = clips[turn % clips.Length];
            src.volume = 1;
            src.pitch = 1;
            src.Play();
        }
    }
}
