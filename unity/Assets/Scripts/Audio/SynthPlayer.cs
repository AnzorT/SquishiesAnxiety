// Snd.Synth in the app: a made-up sound (Audio/ChestSounds.cs on WebSynth) rendered on a worker thread, then played on
// the main thread as a one-off AudioClip through its own AudioSource (overlapping plays sum, as each Web Audio graph
// does), the clip freed when it's done. Off with Settings' "Sound effects", as the pages' sounds are (their `sound`).
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SquishSquad.Audio
{
    public sealed class SynthPlayer : MonoBehaviour
    {
        static SynthPlayer _i;
        static readonly ConcurrentQueue<Action> Main = new ConcurrentQueue<Action>();

        sealed class Handle : ISndLoop
        {
            public AudioSource Src;
            public AudioClip Clip;
            public bool Stopped;
            public float Vol = 1, Pitch = 1;
            public void SetRate(double r) { Pitch = (float)r; if (Src != null && !Stopped) Src.pitch = Pitch; }
            public void SetVolume(double v) { Vol = (float)v; if (Src != null && !Stopped) Src.volume = Vol; }
            public void Stop() { Stopped = true; if (Src != null) Src.Stop(); }
        }

        readonly List<Handle> _playing = new List<Handle>();
        readonly Stack<AudioSource> _free = new Stack<AudioSource>();

        /// <summary>Snd.SynthFn.</summary>
        public static ISndLoop Play(Func<float[]> render)
        {
            if (render == null || !Sfx.EffectsOn) return null;
            var host = UnityAudio.Instance;
            if (host == null) return null;
            if (_i == null) _i = host.gameObject.GetComponent<SynthPlayer>();
            if (_i == null) _i = host.gameObject.AddComponent<SynthPlayer>();
            var h = new Handle();
#if UNITY_WEBGL && !UNITY_EDITOR
            // (no threads there)
            _i.Begin(h, Render(render));
#else
            Task.Run(() =>
            {
                var s = Render(render);
                if (s != null) Main.Enqueue(() => { if (_i != null) _i.Begin(h, s); });
            });
#endif
            return h;
        }

        static float[] Render(Func<float[]> render)
        {
            try { return render(); }
            catch (Exception e) { Main.Enqueue(() => Debug.LogWarning("[Audio] a synthesized sound failed: " + e.Message)); return null; }
        }

        void Begin(Handle h, float[] samples)
        {
            if (h.Stopped || samples == null || samples.Length == 0) return;
            var clip = AudioClip.Create("synth", samples.Length, 1, ChestSounds.Rate, false);
            clip.SetData(samples, 0);
            var src = _free.Count > 0 ? _free.Pop() : null;
            if (src == null)
            {
                src = gameObject.AddComponent<AudioSource>();
                src.playOnAwake = false;
                src.spatialBlend = 0;
            }
            src.clip = clip; src.volume = h.Vol; src.pitch = h.Pitch; src.loop = false;
            h.Src = src; h.Clip = clip;
            src.Play();
            _playing.Add(h);
        }

        void Update()
        {
            while (Main.TryDequeue(out var a)) a();
            // done (or stopped): the source back to the pool, the clip freed
            for (int i = _playing.Count - 1; i >= 0; i--)
            {
                var h = _playing[i];
                if (h.Src != null && !h.Stopped && h.Src.isPlaying) continue;
                if (h.Src != null) { h.Src.Stop(); h.Src.clip = null; _free.Push(h.Src); }
                if (h.Clip != null) Destroy(h.Clip);
                h.Src = null; h.Clip = null; h.Stopped = true;
                _playing.RemoveAt(i);
            }
        }
    }
}
