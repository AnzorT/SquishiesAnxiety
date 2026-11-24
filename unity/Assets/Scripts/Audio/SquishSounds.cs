// The squish stage's sounds for Games/Squish/SquishTime, as SquishScreen.js makes them: on open the creature's squish
// loop (SquishLoop.SourceFor), the coin ding and the release pop are loaded; on close they're unloaded. The caller
// checks the stage's own switches (SquishTime.SquishSoundOn, CoinSoundOn, ReleaseSoundOn) where the app does:
//
//   press (one finger)              if (SquishSoundOn) sounds.Squish.Start()
//   real movement (>= 3 dp)         if (SquishSoundOn) sounds.Squish.NoteMotion()
//   each coin banked                if (CoinSoundOn) sounds.Coin()
//   release of a poke               sounds.Squish.Stop(); if (ReleaseSoundOn) sounds.Pop()
//   second finger / orbit / cancel  sounds.Squish.Stop()
//   Squish sound switched off       sounds.Squish.Stop()
//
// A custom creature's own sound (its `audio` URL) is downloaded first, as expo-av streams a remote uri; until it's
// here the press is silent, as in the app while its player loads.
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace SquishSquad.Audio
{
    public sealed class SquishSounds
    {
        public readonly SquishLoop Squish;
        readonly OneShot _coin, _pop;
        bool _gone;

        SquishSounds(UnityAudio host)
        {
            Squish = new SquishLoop(host, host.Timers);
            _coin = OneShot.Coin(host);
            _pop = OneShot.Pop(host);
        }

        /// <summary>The stage opened with this creature (null in edit mode).</summary>
        public static SquishSounds Open(string creatureId, string audioUrl = null)
        {
            var host = UnityAudio.Instance;
            if (host == null) return null;
            var s = new SquishSounds(host);
            var src = SquishLoop.SourceFor(creatureId, audioUrl);
            if (src.Contains("://")) host.StartCoroutine(s.Fetch(host, src));
            else s.Squish.Load(src);
            s._coin.Load();
            s._pop.Load();
            return s;
        }

        IEnumerator Fetch(UnityAudio host, string url)
        {
            var lower = url.ToLowerInvariant();
            var type = lower.Contains(".wav") ? AudioType.WAV : lower.Contains(".ogg") ? AudioType.OGGVORBIS : lower.Contains(".m4a") || lower.Contains(".aac") ? AudioType.ACC : AudioType.MPEG;
            using (var req = UnityWebRequestMultimedia.GetAudioClip(url, type))
            {
                yield return req.SendWebRequest();
                if (_gone || req.result != UnityWebRequest.Result.Success) yield break;
                var clip = DownloadHandlerAudioClip.GetContent(req);
                if (clip == null) yield break;
                Squish.Attach(host.CreateFromClip(clip, new SoundInit { Looping = true, Volume = 0, Rate = 1 }));
            }
        }

        public void Coin() => _coin.Play();

        public void Pop() => _pop.Play();

        /// <summary>The stage closed.</summary>
        public void Close()
        {
            _gone = true;
            Squish.Unload();
            _coin.Unload();
            _pop.Unload();
        }
    }
}
