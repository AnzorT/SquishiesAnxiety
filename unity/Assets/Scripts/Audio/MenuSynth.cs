// The menu's own sounds. The app's Main Menu, Game Park, CHARACTERS and the Level Pass are the designer's web page
// (webgame/app/menu.js) in a WebView, and its sfx(n) plays window.YardGames.SFX[n]: little Web Audio synth sounds from
// yard-games.js, not files, and not under Settings' "Sound effects" switch (the page has only the yard games' own mute,
// localStorage 'yardgames.v1.mute', which the menu never shows). Here they're rendered with Web Audio's own maths:
//   tone(f0, f1, dur, type, vol, delay): an oscillator (band-limited, normalised to a peak of 1, as Web Audio's
//     built-in types) whose frequency ramps exponentially f0 -> f1 over dur (constant when f1 is 0), through a gain
//     set to 0.0001 at the start, ramped exponentially to vol (0.18 when 0) by 12 ms and back to 0.0001 by dur,
//     stopped 20 ms after dur
//   noise(dur, vol, lp, delay): white noise times (1 - i/n)^2, through a lowpass biquad (lp Hz, 1800 when 0, Q 1 as
//     Web Audio's lowpass reads it: dB), times vol (0.2 when 0)
// at 48 kHz (the phone's output rate), with Chromium's own details: its band-limited wave tables (periodic_wave.cc),
// start / stop times rounded to frames, and a frequency set part-way through a 128-frame render quantum running at
// 440 Hz until the next one (the Win's 2nd and 4th notes). tools/unity/audio-test (synth.mjs) renders the page's SFX
// in Chromium's OfflineAudioContext: the eight tones match it sample for sample (within 0.00001). The noise is random
// each time in the page; here each noise sound has three renderings, played in turn (same level and colour).
using System;
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public static partial class MenuSynth
    {
        public const int Rate = 48000;

        // yard-games.js SFX, verbatim
        public static readonly IReadOnlyDictionary<string, Action<Render>> Sounds = new Dictionary<string, Action<Render>>
        {
            { "pop", r => r.Tone(520, 880, 0.09, "sine", 0.16) },
            { "boing", r => r.Tone(180, 520, 0.22, "triangle", 0.18) },
            { "thud", r => { r.Tone(140, 60, 0.12, "sine", 0.22); r.Noise(0.08, 0.12, 600); } },
            { "swish", r => r.Noise(0.22, 0.16, 3200) },
            { "score", r => { r.Tone(660, 0, 0.1, "triangle", 0.16); r.Tone(880, 0, 0.12, "triangle", 0.16, 0.08); r.Tone(1320, 0, 0.16, "triangle", 0.14, 0.16); } },
            { "miss", r => r.Tone(330, 180, 0.25, "sine", 0.14) },
            { "tick", r => r.Tone(1200, 0, 0.04, "square", 0.05) },
            { "splash", r => { r.Noise(0.45, 0.22, 1400); r.Tone(300, 120, 0.2, "sine", 0.1); } },
            { "clang", r => { r.Tone(900, 860, 0.25, "triangle", 0.1); r.Tone(1340, 1300, 0.2, "sine", 0.06); } },
            { "whoosh", r => r.Noise(0.3, 0.1, 900) },
            { "tap", r => r.Tone(760, 0, 0.05, "sine", 0.1) },
            { "win", r => { double[] f = { 523, 659, 784, 1046 }; for (int i = 0; i < f.Length; i++) r.Tone(f[i], 0, 0.18, "triangle", 0.14, i * 0.1); } },
            // the game intro's (webgame/app/intro.js: its own tiny synth, tone / chime / sweep, the same envelope)
            { "intro-land", r => r.Tone(160, 70, 0.25, "sine", 0.12) },
            { "intro-open", r => { r.Tone(300, 900, 0.22, "sine", 0.09); r.Tone(Note.G5, 0, 0.5, "sine", 0.05, 0.06); r.Tone(Note.C6, 0, 0.6, "sine", 0.04, 0.14); } },
            { "intro-press", r => r.Tone(300, 140, 0.18, "sine", 0.05) },
            { "intro-squish0", r => r.Tone(Note.E5, 0, 0.25, "triangle", 0.03) },
            { "intro-squish1", r => r.Tone(Note.E5 * 1.12, 0, 0.25, "triangle", 0.03) },
            { "intro-squish2", r => r.Tone(Note.E5 * 1.24, 0, 0.25, "triangle", 0.03) },
            { "intro-chime0", r => Chime(r, Note.C5) },
            { "intro-chime1", r => Chime(r, Note.E5) },
            { "intro-chime2", r => Chime(r, Note.G5) },
            { "intro-rest0", r => Chime(r, Note.C6 / 2) },
            { "intro-rest1", r => Chime(r, Note.E6 / 2) },
            { "intro-rest2", r => Chime(r, Note.G6 / 2) },
            { "intro-dawn", r => { Chime(r, Note.C5); Chime(r, Note.G5, 0.14); Chime(r, Note.C6, 0.28); Chime(r, Note.E6, 0.42); } },
            { "intro-start", r => Chime(r, Note.G5) },
        };

        static class Note { public const double C5 = 523.25, E5 = 659.25, G5 = 783.99, C6 = 1046.5, E6 = 1318.5, G6 = 1568; }
        /// <summary>intro.js chime: the note, its octave (triangle) and its twelfth, fading over 1.4, 0.8 and 0.4 s.</summary>
        static void Chime(Render r, double f, double at = 0) { r.Tone(f, 0, 1.4, "sine", 0.07, at); r.Tone(f * 2, 0, 0.8, "triangle", 0.025, at); r.Tone(f * 3.01, 0, 0.4, "sine", 0.012, at); }

        /// <summary>A tone made up on the spot (the intro's peeks and its logo's thuds: one per pitch), cached by name;
        /// returns the name to play it by.</summary>
        public static string Tone(double f, double dur, string type, double vol)
        {
            string name = "tone-" + f.ToString("0", System.Globalization.CultureInfo.InvariantCulture) + "-" + type;
            lock (Extra) if (!Extra.ContainsKey(name)) Extra[name] = r => r.Tone(f, 0, dur, type, vol);
            return name;
        }
        // (locked: Prebuild's thread reads it while the main thread adds tones)
        static readonly Dictionary<string, Action<Render>> Extra = new Dictionary<string, Action<Render>>();

        /// <summary>Whether `name` is a sound here (the table's or a made-up tone).</summary>
        public static bool Known(string name) { if (Sounds.ContainsKey(name)) return true; lock (Extra) return Extra.ContainsKey(name); }

        /// <summary>Every rendering of a sound (three for the noisy ones, played in turn), or null for an unknown name.</summary>
        public static float[][] RenderAll(string name)
        {
            if (!Known(name)) return null;
            var all = new float[HasNoise(name) ? 3 : 1][];
            for (int v = 0; v < all.Length; v++) all[v] = Samples(name, v);
            return all;
        }

        // ---- built ahead, off the main thread ----------------------------------------------------------------------------
        // A sound is rendered the first time it plays, and some take a while: the first triangle wave builds its
        // normalisation table (NormOf: 8 million partials), 0.4 s on the Editor's Mono, which froze the intro at the first
        // squish of Mittens. So the intro's sounds are rendered ahead on a worker (Prebuild), and Play takes them from here.
        static readonly Queue<string> Todo = new Queue<string>();
        static readonly HashSet<string> Queued = new HashSet<string>();   // waiting or being rendered
        static readonly Dictionary<string, float[][]> Built = new Dictionary<string, float[][]>();
        static System.Threading.Thread _worker;

        /// <summary>Renders these sounds on a worker thread, in this order, for Play to take (TakeBuilt).</summary>
        public static void Prebuild(IEnumerable<string> names)
        {
            lock (Todo)
            {
                foreach (var n in names) if (!Built.ContainsKey(n) && Queued.Add(n)) Todo.Enqueue(n);
                if (_worker != null || Todo.Count == 0) return;
                _worker = new System.Threading.Thread(BuildQueued) { IsBackground = true, Name = "menu sounds", Priority = System.Threading.ThreadPriority.BelowNormal };
                _worker.Start();
            }
        }

        static void BuildQueued()
        {
            while (true)
            {
                string name;
                lock (Todo) { if (Todo.Count == 0) { _worker = null; return; } name = Todo.Dequeue(); }
                float[][] all = null;
                try { all = RenderAll(name); } catch (Exception) { /* Play renders it itself */ }
                lock (Todo) { if (all != null) Built[name] = all; Queued.Remove(name); }
            }
        }

        /// <summary>A sound Prebuild rendered (handed over once: the caller keeps it), or null if it isn't ready.</summary>
        public static float[][] TakeBuilt(string name)
        {
            lock (Todo) { if (!Built.TryGetValue(name, out var all)) return null; Built.Remove(name); return all; }
        }

        /// <summary>The table's sounds whose names start with `prefix` (the intro's: "intro-"), in the table's order.</summary>
        public static List<string> Named(string prefix)
        {
            var l = new List<string>();
            foreach (var k in Sounds.Keys) if (k.StartsWith(prefix, StringComparison.Ordinal)) l.Add(k);
            return l;
        }

        /// <summary>One sound's samples (mono, Rate), mixed as Web Audio sums its nodes.</summary>
        public sealed class Render
        {
            public readonly List<float> Out = new List<float>();
            /// <summary>Each tone / noise call as made ("tone f0 f1 dur type vol delay"), for tools/unity/audio-test.</summary>
            public readonly List<string> Calls = new List<string>();
            readonly Random _rnd;

            static string N(double v) => v.ToString("R", System.Globalization.CultureInfo.InvariantCulture);

            public Render(int seed) { _rnd = new Random(seed); }

            void Add(int at, double v)
            {
                while (Out.Count <= at) Out.Add(0);
                Out[at] += (float)v;
            }

            public void Tone(double f0, double f1, double dur, string type, double vol, double delay = 0)
            {
                Calls.Add("tone " + N(f0) + " " + N(f1) + " " + N(dur) + " " + type + " " + N(vol) + " " + N(delay));
                if (vol == 0) vol = 0.18;
                // the first frame at or after the start time (Chromium rounds a start time up to a frame)
                int start = (int)Math.Ceiling(delay * Rate);
                int n = (int)Math.Round((delay + dur + 0.02) * Rate) - start;   // stopped 20 ms after dur
                double phase = 0;
                var wave = Wave(type);
                // Chromium: a frequency set (setValueAtTime, no ramp) part-way through a 128-frame render quantum only
                // applies from the next quantum; until then the oscillator runs at the parameter's default, 440 Hz
                int quantumEnd = f1 == 0 && start % Quantum != 0 ? (start / Quantum + 1) * Quantum : start;
                for (int i = 0; i < n; i++)
                {
                    double t = (double)(start + i) / Rate - delay;
                    double f = f1 != 0 && t < dur ? f0 * Math.Pow(f1 / f0, t / dur) : f1 != 0 ? f1 : f0;
                    if (start + i < quantumEnd) f = 440;
                    double g = t < 0.012 ? 0.0001 * Math.Pow(vol / 0.0001, t / 0.012)
                        : t < dur ? vol * Math.Pow(0.0001 / vol, (t - 0.012) / (dur - 0.012))
                        : 0.0001;
                    Add(start + i, g * wave(phase, f));
                    phase += f / Rate;
                    phase -= Math.Floor(phase);
                }
            }

            public void Noise(double dur, double vol, double lp, double delay = 0)
            {
                Calls.Add("noise " + N(dur) + " " + N(vol) + " " + N(lp) + " " + N(delay));
                if (vol == 0) vol = 0.2;
                if (lp == 0) lp = 1800;
                int start = (int)Math.Round(delay * Rate);
                int n = (int)Math.Floor(Rate * dur);
                // Web Audio's lowpass biquad (Q in dB)
                double w0 = 2 * Math.PI * lp / Rate, q = 1, alpha = Math.Sin(w0) / (2 * Math.Pow(10, q / 20)), cw = Math.Cos(w0);
                double a0 = 1 + alpha, b0 = (1 - cw) / 2 / a0, b1 = (1 - cw) / a0, b2 = b0, a1 = -2 * cw / a0, a2 = (1 - alpha) / a0;
                double x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                int tail = Rate / 50;   // the filter rings on a little after the buffer ends
                for (int i = 0; i < n + tail; i++)
                {
                    double x = i < n ? (_rnd.NextDouble() * 2 - 1) * Math.Pow(1 - (double)i / n, 2) : 0;
                    double y = b0 * x + b1 * x1 + b2 * x2 - a1 * y1 - a2 * y2;
                    x2 = x1; x1 = x; y2 = y1; y1 = y;
                    Add(start + i, y * vol);
                }
            }
        }

        // ---- Web Audio's built-in waves, as Chromium makes them (periodic_wave.cc) ------------------------------------------
        // The Fourier series, normalised by the peak of its 2048-partial table; band-limited by a table per 400-cent range
        // of the fundamental (range r keeps 2048 x 2^(-r/3) partials), the two tables around the frequency blended.
        const int Quantum = 128, TableSize = 4096, Ranges = 36;
        const double CentsPerRange = 400, Lowest = Rate / 2.0 / (TableSize / 2);

        static int PartialsFor(int range) => (int)(Math.Pow(2, -range * CentsPerRange / 1200) * (TableSize / 2));
        static readonly Dictionary<string, double> Norm = new Dictionary<string, double>();

        static double Coef(string type, int k)
        {
            if (type == "square") return k % 2 == 1 ? 4 / (Math.PI * k) : 0;   // (2/(kπ))(1 - (-1)^k)
            if (type == "triangle") return 8 * Math.Sin(k * Math.PI / 2) / (Math.PI * Math.PI * k * k);
            if (type == "sawtooth") return 2 * (k % 2 == 1 ? 1 : -1) / (Math.PI * k);
            return k == 1 ? 1 : 0;
        }

        static double NormOf(string type)
        {
            // (locked: Prebuild's thread and the main thread may both want it; the second waits for the first's table)
            lock (Norm)
            {
                if (Norm.TryGetValue(type, out var v)) return v;
                const int N = 4096, K = 2048;
                double peak = 0;
                for (int i = 0; i < N; i++)
                {
                    double x = 0, ph = 2 * Math.PI * i / N;
                    for (int k = 1; k <= K; k++) { double c = Coef(type, k); if (c != 0) x += c * Math.Sin(k * ph); }
                    peak = Math.Max(peak, Math.Abs(x));
                }
                return Norm[type] = peak > 0 ? 1 / peak : 1;
            }
        }

        static Func<double, double, double> Wave(string type)
        {
            if (type == "sine" || type == null) return (ph, f) => Math.Sin(2 * Math.PI * ph);
            double norm = NormOf(type);
            return (ph, f) =>
            {
                double pr = f > 0 ? 1 + Math.Log(f / Lowest, 2) * 1200 / CentsPerRange : 0;
                pr = Math.Max(0, Math.Min(Ranges - 1, pr));
                int r1 = (int)pr, r2 = Math.Min(r1 + 1, Ranges - 1);
                double a = pr - r1;
                int n1 = PartialsFor(r1), n2 = PartialsFor(r2);
                double more = 0, fewer = 0;
                for (int k = 1; k <= n1; k++)
                {
                    double c = Coef(type, k);
                    if (c == 0) continue;
                    double v = c * Math.Sin(2 * Math.PI * k * ph);
                    more += v;
                    if (k <= n2) fewer += v;
                }
                return norm * ((1 - a) * more + a * fewer);
            };
        }

        /// <summary>A sound's samples (variant: which rendering of the noise).</summary>
        public static float[] Samples(string name, int variant = 0) => Rendered(name, variant)?.Out.ToArray();

        public static Render Rendered(string name, int variant = 0)
        {
            Action<Render> make;
            if (!Sounds.TryGetValue(name, out make)) lock (Extra) if (!Extra.TryGetValue(name, out make)) return null;
            int seed = 1 + variant * 7919;
            foreach (var ch in name) seed = seed * 31 + ch;
            var r = new Render(seed);
            make(r);
            return r;
        }

        public static bool HasNoise(string name) => name == "thud" || name == "swish" || name == "splash" || name == "whoosh";
    }
}
