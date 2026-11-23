// The squish stage's own sounds, line by line from the app (plain C#, played through ISoundBackend):
//
// SquishLoop (src/audio/SquishSound.js): one looping sample that plays while the creature is squished, and only while
// the finger moves. A press starts it at full volume; once the finger rests 180 ms it fades out over 350 ms and
// pauses; the next movement fades it back in over 120 ms from where it stopped; letting go fades it out over 400 ms.
// Every fade starts from the volume it's at (20 ms steps), so a finger that stops and starts mid-fade never hears a
// jump; the player is paused, not stopped, so the loop resumes where it was. Which sample: SquishLoop.SourceFor.
//
// OneShot (src/audio/OneShotSound.js): three players replayed round robin, so fast triggers each ring out: the coin
// ding on every coin earned (CoinSound.js: coin.mp3 at 0.8) and the release pop (PopSound.js: pop.mp3 at 1).
//
// Neither follows Settings' "Sound effects" switch or the app being in the background: the squish stage has its own
// switches (Squish sound, Coin sound, Release sound), as in the app.
using System;

namespace SquishSquad.Audio
{
    public sealed class SquishLoop
    {
        public const double FadeStepMs = 20, ReleaseFadeMs = 400, IdlePauseMs = 180, IdleFadeMs = 350, ResumeFadeMs = 120;

        readonly ISoundBackend _p;
        readonly JsTimers _t;
        int _sound;
        int _fadeTimer, _idleTimer;
        double? _fadeTarget;
        bool _held, _audible;
        double _volume;

        public SquishLoop(ISoundBackend player, JsTimers timers)
        {
            _p = player;
            _t = timers;
        }

        public double Volume => _volume;
        public bool Audible => _audible;
        public bool Held => _held;
        public bool Loaded => _sound != 0;

        /// <summary>creatureSquish.js squishSoundFor: a custom creature's own `audio` URL, else the premade creature's
        /// recording (creatures/&lt;id&gt;.ogg), else the generic slime loop.</summary>
        public static string SourceFor(string creatureId, string audioUrl = null)
        {
            if (!string.IsNullOrEmpty(audioUrl)) return audioUrl;
            if (creatureId != null && SoundFiles.CreatureSquish.TryGetValue(creatureId, out var own)) return own;
            return SoundFiles.DefaultSquish;
        }

        void ClearFade()
        {
            if (_fadeTimer != 0)
            {
                _t.Clear(_fadeTimer);
                _fadeTimer = 0;
            }
            _fadeTarget = null;
        }

        void ClearIdle()
        {
            if (_idleTimer != 0)
            {
                _t.Clear(_idleTimer);
                _idleTimer = 0;
            }
        }

        void SetVolume(double v)
        {
            _volume = v;
            if (_sound == 0) return;
            _p.SetVolume(_sound, v);
        }

        void FadeTo(double target, double ms, Action done)
        {
            ClearFade();
            _fadeTarget = target;
            double from = _volume;
            int steps = Math.Max(1, (int)Math.Floor(ms / FadeStepMs + 0.5));
            int step = 0;
            _fadeTimer = _t.SetInterval(() =>
            {
                step += 1;
                SetVolume(from + ((target - from) * step) / steps);
                if (step >= steps)
                {
                    ClearFade();
                    done?.Invoke();
                }
            }, FadeStepMs);
        }

        void Pause()
        {
            _audible = false;
            if (_sound == 0) return;
            _p.Pause(_sound);
        }

        void PlayNow()
        {
            _audible = true;
            if (_sound == 0) return;
            _p.Play(_sound);
        }

        void ArmIdle()
        {
            ClearIdle();
            _idleTimer = _t.SetTimeout(() =>
            {
                _idleTimer = 0;
                FadeTo(0, IdleFadeMs, Pause);
            }, IdlePauseMs);
        }

        /// <summary>load(source): the looping player, silent. A URL source is the host's to fetch (Attach).</summary>
        public void Load(string file)
        {
            int s = _p.Create(file, new SoundInit { Looping = true, Volume = 0, Rate = 1 });
            _sound = s;
        }

        /// <summary>A player made elsewhere (a custom creature's sound, downloaded).</summary>
        public void Attach(int sound) => _sound = sound;

        /// <summary>A poke started: plays at once, then fades unless the finger keeps moving.</summary>
        public void Start()
        {
            if (_sound == 0) return;
            _held = true;
            ClearFade();
            SetVolume(1);
            PlayNow();
            ArmIdle();
        }

        /// <summary>The finger moved (by SquishRules.SoundMotionDp): keep it going, or bring it back.</summary>
        public void NoteMotion()
        {
            if (_sound == 0 || !_held) return;
            ArmIdle();
            if (!_audible) PlayNow();
            if (_volume < 1 && _fadeTarget != 1) FadeTo(1, ResumeFadeMs, null);
        }

        /// <summary>Letting go: fade out and pause.</summary>
        public void Stop()
        {
            _held = false;
            ClearIdle();
            if (_sound == 0) return;
            if (!_audible && _fadeTimer == 0) return;   // already quiet
            FadeTo(0, ReleaseFadeMs, Pause);
        }

        public void Unload()
        {
            ClearFade();
            ClearIdle();
            _held = false;
            _audible = false;
            if (_sound == 0) return;
            _p.Unload(_sound);
            _sound = 0;
        }
    }

    public sealed class OneShot
    {
        public const int VoiceCount = 3;

        readonly ISoundBackend _p;
        readonly string _file;
        readonly double _volume;
        int[] _voices = new int[0];
        bool _loading;
        int _next;

        public OneShot(ISoundBackend player, string file, double volume = 1)
        {
            _p = player;
            _file = file;
            _volume = volume;
        }

        public static OneShot Coin(ISoundBackend p) => new OneShot(p, SoundFiles.Coin, SoundFiles.CoinVolume);
        public static OneShot Pop(ISoundBackend p) => new OneShot(p, SoundFiles.Pop, SoundFiles.PopVolume);

        public void Load()
        {
            if (_loading) return;
            _loading = true;
            var made = new System.Collections.Generic.List<int>();
            for (int i = 0; i < VoiceCount; i++)
            {
                int s = _p.Create(_file, SoundInit.Effect(_volume));
                if (s != 0) made.Add(s);
            }
            _voices = made.ToArray();
        }

        public void Play()
        {
            if (_voices.Length == 0) Load();
            int n = _voices.Length;
            int idx = _next % (n == 0 ? 1 : n);
            _next += 1;
            if (n == 0) return;
            _p.Replay(_voices[idx], null);
        }

        public void Unload()
        {
            var sounds = _voices;
            _voices = new int[0];
            _loading = false;
            foreach (var s in sounds) _p.Unload(s);
        }
    }
}
