// The house's synthesized sounds (movie-night.js's own, on Audio/WebSynth.cs; its context: out gain 0.5, a compressor
// at -14 dB, ratio 4, the rest Chrome's defaults; noise through a biquad, highpass at 6000 Hz and Q 0.7 unless set, the
// gain up exponentially by `at` and down to 0.0001 by its end):
//   ShowStart   the projector whirring up as a show starts (noise 1.1 s, lowpass 1400 -> 160 Hz) and its click as
//               the picture comes on (DIM - 0.18 s: a 30 ms bandpass tick at 3200 Hz)
//   Whoosh(on)  full screen in (bandpass 500 -> 3000 Hz) or out (2600 -> 420 Hz), 0.5 s
// Played by Snd.Synth (House/View/HouseMovieView.cs). No UnityEngine.
using System;

namespace SquishSquad.Audio
{
    public static class HouseSounds
    {
        static readonly Random R = new Random();
        static Random Gen() { lock (R) return new Random(R.Next()); }
        static WebSynth Movie() => new WebSynth(ChestSounds.Rate, Gen()) { CompThreshold = -14, CompKnee = 30, CompRatio = 4, CompAttack = 0.003, CompRelease = 0.25, OutGain = 0.5 };
        static void Noise(WebSynth s, double t, double dur, string ft = "highpass", double f = 6000, double fTo = 0, double q = 0.7, double vol = 0.1, double at = 0.002)
            => s.Noise(t, dur, ft: ft, f: f, fTo: fTo, q: q, vol: vol, a: at, expAttack: true);

        const double DIM = 1.2;

        public static float[] ShowStart()
        {
            var s = Movie();
            Noise(s, 0, 1.1, ft: "lowpass", f: 1400, fTo: 160, vol: 0.06, at: 0.3);
            Noise(s, DIM - 0.18, 0.03, ft: "bandpass", f: 3200, q: 2, vol: 0.25);
            return s.Render();
        }

        public static float[] Whoosh(bool on)
        {
            var s = Movie();
            Noise(s, 0, 0.5, ft: "bandpass", f: on ? 500 : 2600, fTo: on ? 3000 : 420, q: 1.1, vol: 0.05, at: 0.22);
            return s.Render();
        }
    }
}
