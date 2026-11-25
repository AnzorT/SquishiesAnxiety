// A small offline Web Audio: the node graphs the app's web pages build for their synthesized sounds (the chest smash's
// chest-sfx.js and tools/chest/host.html), rendered ahead into a buffer with Web Audio's own maths, so the C# side
// plays the same sounds. Each voice is an oscillator (sine, square, sawtooth, triangle; the edges band-limited) or white
// noise, through an optional biquad (lowpass / highpass / bandpass: the spec's formulas, the lowpass and highpass Q in
// dB as Web Audio reads it; its frequency ramped exponentially), through a gain envelope (setValueAtTime 0.0001, a
// linear or exponential ramp up to the voice's volume, an exponential ramp down to 0.0001), into a bus:
//   out   straight on
//   dist  a WaveShaper (curve (1 + k) x / (1 + k |x|), k 14), then gain 0.55, into out
//   verb  a send (the voice's level x its send) into a gain, a ConvolverNode (an impulse of white noise x (1 - i/n)^4,
//         0.9 s), into out
// then out's gain and a DynamicsCompressor as Chrome's (Compress). No UnityEngine: Audio/ChestSounds.cs makes the
// graphs, Snd.Synth plays the buffer; tools/unity/sound-test checks them against Chrome's.
using System;
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public sealed class WebSynth
    {
        public readonly int Rate;
        readonly Random _r;

        // the graph's fixed parts
        public double OutGain = 1, DistGain = 0.55, DistK = 14, VerbIn = 0.35, VerbSeconds = 0.9;
        public double CompThreshold = -24, CompKnee = 30, CompRatio = 12, CompAttack = 0.003, CompRelease = 0.25;
        public bool Compressor = true;

        public WebSynth(int rate = 44100, Random random = null) { Rate = rate; _r = random ?? new Random(); }
        public double Rr(double a, double b) => a + _r.NextDouble() * (b - a);
        public double Random() => _r.NextDouble();

        enum Src { Sine, Square, Saw, Triangle, Noise }
        enum Flt { None, Lowpass, Highpass, Bandpass }
        sealed class Voice
        {
            public Src S; public double T, Dur, Stop, F, To, Slide;
            public double Vol, A; public bool ExpAttack;
            public Flt Ft; public double Ff, FTo, Q;
            public bool Dist; public double Verb;
        }
        readonly List<Voice> _v = new List<Voice>();

        static Src SrcOf(string type) => type == "square" ? Src.Square : type == "sawtooth" ? Src.Saw : type == "triangle" ? Src.Triangle : Src.Sine;
        static Flt FltOf(string ft) => ft == "lowpass" ? Flt.Lowpass : ft == "highpass" ? Flt.Highpass : Flt.Bandpass;

        /// <summary>An oscillator at f (ramped exponentially to `to` over `slide`, the duration when 0) from t for dur, its
        /// gain up to vol by `a` (linear, or exponential with expAttack) and down to 0.0001 by t + dur (or t + decayEnd),
        /// stopped `stopPad` after; through a lowpass at `lp` (Q 1, dB) when set.</summary>
        public void Tone(double f, double t, double dur, string type = "sine", double to = 0, double slide = 0, double vol = 0.3, double a = 0.002,
            double lp = 0, bool dist = false, double verb = 0, bool expAttack = false, double decayEnd = -1, double stopPad = 0.05)
        {
            t = Math.Max(0, t);
            _v.Add(new Voice { S = SrcOf(type), T = t, Dur = decayEnd > 0 ? decayEnd : dur, Stop = t + dur + stopPad, F = f, To = to, Slide = slide > 0 ? slide : dur,
                Vol = vol, A = a, ExpAttack = expAttack, Ft = lp > 0 ? Flt.Lowpass : Flt.None, Ff = lp, Q = 1, Dist = dist, Verb = verb });
        }

        /// <summary>White noise through a biquad (`ft`, f ramped exponentially to fTo over dur when set, Q) from t for dur,
        /// its gain as Tone's.</summary>
        public void Noise(double t, double dur, string ft = "bandpass", double f = 1000, double fTo = 0, double q = 1, double vol = 0.2, double a = 0.001,
            bool dist = false, double verb = 0, bool expAttack = false, double decayEnd = -1, double stopPad = 0.05)
        {
            t = Math.Max(0, t);
            _v.Add(new Voice { S = Src.Noise, T = t, Dur = decayEnd > 0 ? decayEnd : dur, Stop = t + dur + stopPad, Vol = vol, A = a, ExpAttack = expAttack,
                Ft = FltOf(ft), Ff = f, FTo = fTo, Q = q, Dist = dist, Verb = verb, Slide = dur });
        }

        public int Voices => _v.Count;

        // ---- rendering ---------------------------------------------------------------------------------------------------
        /// <summary>The graph rendered from time 0 to the last voice's end (and the reverb's tail): mono samples.</summary>
        public float[] Render()
        {
            double end = 0; bool anyVerb = false;
            foreach (var v in _v) { end = Math.Max(end, v.Stop); if (v.Verb > 0) anyVerb = true; }
            end += (anyVerb ? VerbSeconds : 0) + 0.1;
            int n = Math.Max(1, (int)Math.Ceiling(end * Rate));
            var main = new double[n]; var dist = new double[n]; double[] verb = anyVerb ? new double[n] : null;
            foreach (var v in _v) RenderVoice(v, main, dist, verb);
            // the WaveShaper bus
            for (int i = 0; i < n; i++)
            {
                double x = dist[i]; if (x == 0) continue;
                x = Math.Max(-1, Math.Min(1, x));
                main[i] += DistGain * (1 + DistK) * x / (1 + DistK * Math.Abs(x));
            }
            // the reverb bus (only as far as anything was sent into it)
            if (verb != null)
            {
                int last = n - 1; while (last > 0 && verb[last] == 0) last--;
                var (len, hr, hi, scale) = Impulse(last + 1);
                var xr = new double[len]; var xi = new double[len];
                Array.Copy(verb, xr, last + 1);
                Fft(xr, xi, false);
                for (int i = 0; i < len; i++) { double r = xr[i] * hr[i] - xi[i] * hi[i], im = xr[i] * hi[i] + xi[i] * hr[i]; xr[i] = r; xi[i] = im; }
                Fft(xr, xi, true);
                double k = VerbIn * scale;
                for (int i = 0, e = Math.Min(n, len); i < e; i++) main[i] += k * xr[i];
            }
            var outp = new float[n];
            if (!Compressor) { for (int i = 0; i < n; i++) outp[i] = (float)Math.Max(-1, Math.Min(1, main[i] * OutGain)); return outp; }
            Compress(main, outp);
            return outp;
        }

        // ---- the DynamicsCompressor, as Chrome's (Chromium's DynamicsCompressorKernel) -----------------------------------
        // The static curve: straight up to the threshold, an exponential knee from there (its k found so that its slope
        // at threshold + knee is 1 / ratio), then the ratio; the make-up gain (1 / the curve at 1)^0.6; a detector on the
        // undelayed signal (its saturated release 2.5 ms), the gain following it in 32-frame steps (the attack's rate
        // from the largest compression asked so far, the release adaptive: faster the more it's compressing), sine-warped;
        // the signal 6 ms behind the detector (those 6 ms of silence cut off the front here).
        static double Db2Lin(double db) => Math.Pow(10, db / 20);
        static double Lin2Db(double x) => x <= 0 ? -1000 : 20 * Math.Log10(x);
        double _linTh, _kneeTh, _kneeThDb, _yKneeThDb, _slope, _k;

        double KneeCurve(double x, double k) => x < _linTh ? x : _linTh + (1 - Math.Exp(-k * (x - _linTh))) / k;
        double Saturate(double x, double k)
        {
            if (x < _kneeTh) return KneeCurve(x, k);
            return Db2Lin(_yKneeThDb + _slope * (Lin2Db(x) - _kneeThDb));
        }
        double SlopeAt(double x, double k)
        {
            if (x < _linTh) return 1;
            double x2 = x * 1.001, xDb = Lin2Db(x), x2Db = Lin2Db(x2), yDb = Lin2Db(KneeCurve(x, k)), y2Db = Lin2Db(KneeCurve(x2, k));
            return (y2Db - yDb) / (x2Db - xDb);
        }
        void Curve()
        {
            _linTh = Db2Lin(CompThreshold); _slope = 1 / CompRatio;
            double x = Db2Lin(CompThreshold + CompKnee), minK = 0.1, maxK = 10000, k = 5;
            for (int i = 0; i < 15; i++)
            {
                if (SlopeAt(x, k) < _slope) maxK = k; else minK = k;
                k = Math.Sqrt(minK * maxK);
            }
            _k = k;
            _kneeThDb = CompThreshold + CompKnee; _kneeTh = Db2Lin(_kneeThDb);
            _yKneeThDb = Lin2Db(KneeCurve(_kneeTh, k));
        }

        void Compress(double[] input, float[] outp)
        {
            int n = input.Length;
            Curve();
            double k = _k, master = Math.Pow(1 / Saturate(1, k), 0.6);
            double attackFrames = Math.Max(0.001, CompAttack) * Rate, releaseFrames = CompRelease * Rate, satReleaseFrames = 0.0025 * Rate;
            double y1 = releaseFrames * 0.09, y2 = releaseFrames * 0.16, y3 = releaseFrames * 0.42, y4 = releaseFrames * 0.98;
            double kA = 0.9999999999999998 * y1 + 1.8432219684323923e-16 * y2 - 1.9373394351676423e-16 * y3 + 8.824516011816245e-18 * y4;
            double kB = -1.5788320352845888 * y1 + 2.3305837032074286 * y2 - 0.9141194204840429 * y3 + 0.1623677525612032 * y4;
            double kC = 0.5334142869106424 * y1 - 1.272736789213631 * y2 + 0.9258856042207512 * y3 - 0.18656310191776226 * y4;
            double kD = 0.08783463138207234 * y1 - 0.1694162967925622 * y2 + 0.08588057951595272 * y3 - 0.00429891410546283 * y4;
            double kE = -0.042416883008123074 * y1 + 0.1115693827987602 * y2 - 0.09764676325265872 * y3 + 0.028494263462021576 * y4;
            int pre = (int)(0.006 * Rate);
            double detector = 0, gain = 1, maxAttackDiffDb = -1, satRelease2 = Db2Lin(2 / satReleaseFrames) - 1, lastGain = -1, warped = 0;
            var full = new double[n + pre];
            for (int f0 = 0; f0 < n + pre; f0 += 32)
            {
                if (double.IsNaN(detector) || double.IsInfinity(detector)) detector = 1;
                double scaledDesired = Math.Asin(Math.Min(1, detector)) / (Math.PI / 2), rate;
                bool releasing = scaledDesired > gain;
                double diffDb = Lin2Db(gain / scaledDesired);
                if (releasing)
                {
                    maxAttackDiffDb = -1;
                    if (double.IsNaN(diffDb) || double.IsInfinity(diffDb)) diffDb = -1;
                    double x = 0.25 * (Math.Max(-12, Math.Min(0, diffDb)) + 12), x2 = x * x;
                    double rf = kA + kB * x + kC * x2 + kD * x2 * x + kE * x2 * x2;
                    rate = Db2Lin(5 / rf);
                }
                else
                {
                    if (double.IsNaN(diffDb) || double.IsInfinity(diffDb)) diffDb = 1;
                    if (maxAttackDiffDb == -1 || maxAttackDiffDb < diffDb) maxAttackDiffDb = diffDb;
                    rate = 1 - Math.Pow(0.25 / Math.Max(0.5, maxAttackDiffDb), 1 / attackFrames);
                }
                for (int f = f0, e = Math.Min(n + pre, f0 + 32); f < e; f++)
                {
                    double ax = f < n ? Math.Abs(input[f] * OutGain) : 0;
                    // (below the threshold the curve is straight: no attenuation, the release at its 2 dB floor)
                    double att = ax <= 0.0001 || ax < _linTh ? 1 : Saturate(ax, k) / ax;
                    double satRelease = att == 1 ? satRelease2 : Db2Lin(Math.Max(2, -Lin2Db(att)) / satReleaseFrames) - 1;
                    detector += (att - detector) * (att > detector ? satRelease : 1);
                    detector = Math.Min(1, detector);
                    if (double.IsNaN(detector) || double.IsInfinity(detector)) detector = 1;
                    if (rate < 1) gain += (scaledDesired - gain) * rate;
                    else gain = Math.Min(1, gain * rate);
                    if (gain != lastGain) { lastGain = gain; warped = Math.Sin(Math.PI / 2 * gain); }
                    double total = master * warped;
                    int src = f - pre;
                    full[f] = src >= 0 ? input[src] * OutGain * total : 0;
                }
            }
            // (the 6 ms the signal waits behind the detector: silence at the front, cut)
            for (int i = 0; i < n; i++) outp[i] = (float)Math.Max(-1, Math.Min(1, full[i + pre]));
        }

        // the room: one impulse (white noise x (1 - i/m)^4 over VerbSeconds; one per context in the page too), its
        // spectrum kept for each FFT size, and ConvolverNode's normalize: the impulse scaled by the spec's calibration
        // (GainCalibration 0.00125 over its RMS power, at least 0.000125; x 44100 / the rate)
        static readonly Dictionary<(int, int, int), (double[], double[], double)> Impulses = new Dictionary<(int, int, int), (double[], double[], double)>();
        /// <summary>The room's spectra made ahead for the two sizes most sounds take (so the first isn't slower).</summary>
        public void Warm() { int m = (int)(VerbSeconds * Rate); Impulse(1); Impulse(65536 - m + 1); }

        (int len, double[] re, double[] im, double scale) Impulse(int input)
        {
            int m = (int)(VerbSeconds * Rate), len = 1;
            while (len < input + m) len <<= 1;
            var key = (Rate, m, len);
            lock (Impulses)
            {
                if (Impulses.TryGetValue(key, out var c)) return (len, c.Item1, c.Item2, c.Item3);
                var r = new Random(m);
                var re = new double[len]; var im = new double[len];
                double power = 0;
                for (int i = 0; i < m; i++) { re[i] = (r.NextDouble() * 2 - 1) * Math.Pow(1 - (double)i / m, 4); power += re[i] * re[i]; }
                power = Math.Sqrt(power / m);
                if (power < 0.000125 || double.IsNaN(power)) power = 0.000125;
                double scale = 0.00125 / power * (44100.0 / Rate);
                Fft(re, im, false);
                Impulses[key] = (re, im, scale);
                return (len, re, im, scale);
            }
        }

        void RenderVoice(Voice v, double[] main, double[] dist, double[] verb)
        {
            int n = main.Length, i0 = (int)Math.Round(v.T * Rate), i1 = Math.Min(n, (int)Math.Round(v.Stop * Rate));
            if (i1 <= i0) return;
            double dt = 1.0 / Rate;
            // the envelope: 0.0001 at T, up to Vol by T + A, down to 0.0001 by T + Dur, then held
            double vol = Math.Max(0.0002, v.Vol), a = Math.Max(1e-5, v.A), d = Math.Max(a + 1e-5, v.Dur);
            int ia = (int)Math.Round(a * Rate), id = (int)Math.Round(d * Rate);
            double g = 0.0001, ga = v.ExpAttack ? Math.Pow(vol / 0.0001, 1.0 / Math.Max(1, ia)) : (vol - 0.0001) / Math.Max(1, ia);
            double gd = Math.Pow(0.0001 / vol, 1.0 / Math.Max(1, id - ia));
            // the frequency: F, ramped exponentially to To over Slide
            double f = v.F, fr = v.To > 0 && v.F > 0 ? Math.Pow(v.To / v.F, 1.0 / Math.Max(1, (int)Math.Round(v.Slide * Rate))) : 1;
            int islide = (int)Math.Round(v.Slide * Rate);
            double ph = 0;   // (oscillators start at phase 0)
            ulong ns = ((ulong)_r.Next() << 32) ^ (ulong)_r.Next() ^ 0x9E3779B97F4A7C15UL;   // (the noise: xorshift64)
            // the filter
            double ff = v.Ff, ffr = v.Ft != Flt.None && v.FTo > 0 && v.Ff > 0 ? Math.Pow(v.FTo / v.Ff, 1.0 / Math.Max(1, (int)Math.Round(v.Slide * Rate))) : 1;
            int ifs = (int)Math.Round(v.Slide * Rate);
            double b0 = 1, b1 = 0, b2 = 0, a1 = 0, a2 = 0, x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            void Coef()
            {
                double fc = Math.Max(10, Math.Min(Rate * 0.49, ff)), w0 = 2 * Math.PI * fc / Rate, cs = Math.Cos(w0), sn = Math.Sin(w0), al, a0;
                switch (v.Ft)
                {
                    case Flt.Lowpass: { double qq = Math.Pow(10, v.Q / 20); al = sn / (2 * qq); a0 = 1 + al; b0 = (1 - cs) / 2 / a0; b1 = (1 - cs) / a0; b2 = b0; a1 = -2 * cs / a0; a2 = (1 - al) / a0; break; }
                    case Flt.Highpass: { double qq = Math.Pow(10, v.Q / 20); al = sn / (2 * qq); a0 = 1 + al; b0 = (1 + cs) / 2 / a0; b1 = -(1 + cs) / a0; b2 = b0; a1 = -2 * cs / a0; a2 = (1 - al) / a0; break; }
                    default: { double qq = Math.Max(1e-4, v.Q); al = sn / (2 * qq); a0 = 1 + al; b0 = al / a0; b1 = 0; b2 = -al / a0; a1 = -2 * cs / a0; a2 = (1 - al) / a0; break; }
                }
            }
            if (v.Ft != Flt.None) Coef();
            for (int i = i0, k = 0; i < i1; i++, k++)
            {
                // source
                double x;
                if (v.S == Src.Noise) { ns ^= ns << 13; ns ^= ns >> 7; ns ^= ns << 17; x = (ns >> 11) * (2.0 / (1UL << 53)) - 1; }
                else
                {
                    double inc = f * dt;
                    switch (v.S)
                    {
                        case Src.Sine: { double u = ph * SinN; int k0 = (int)u; x = Sin[k0] + (Sin[k0 + 1] - Sin[k0]) * (u - k0); break; }
                        case Src.Square: x = (ph < 0.5 ? 1 : -1) + Blep(ph, inc) - Blep((ph + 0.5) % 1, inc); break;
                        case Src.Saw: x = 2 * ph - 1 - Blep(ph, inc); break;
                        default: x = ph < 0.5 ? 4 * ph - 1 : 3 - 4 * ph; break;
                    }
                    ph += inc; if (ph >= 1) ph -= Math.Floor(ph);
                    if (k < islide) f *= fr;
                }
                // filter
                if (v.Ft != Flt.None)
                {
                    if (ffr != 1 && k < ifs && (k & 31) == 0) { ff *= Math.Pow(ffr, 32); Coef(); }
                    double y = b0 * x + b1 * x1 + b2 * x2 - a1 * y1 - a2 * y2;
                    x2 = x1; x1 = x; y2 = y1; y1 = y; x = y;
                }
                // envelope
                double s = x * g;
                if (k < ia) g = v.ExpAttack ? g * ga : g + ga;
                else if (k < id) g *= gd;
                if (v.Dist) dist[i] += s; else main[i] += s;
                if (verb != null && v.Verb > 0) verb[i] += s * v.Verb;
            }
        }

        // a sine table (linear between its points: under -100 dB of error)
        const int SinN = 4096;
        static readonly double[] Sin = MakeSin();
        static double[] MakeSin() { var t = new double[SinN + 2]; for (int i = 0; i < t.Length; i++) t[i] = Math.Sin(2 * Math.PI * i / SinN); return t; }

        // PolyBLEP: the step at a phase wrap smoothed over one sample either side (a band-limited edge)
        static double Blep(double t, double dt)
        {
            if (dt <= 0) return 0;
            if (t < dt) { t /= dt; return t + t - t * t - 1; }
            if (t > 1 - dt) { t = (t - 1) / dt; return t * t + t + t + 1; }
            return 0;
        }

        // ---- the FFT ----------------------------------------------------------------------------------------------------
        static void Fft(double[] re, double[] im, bool inverse)
        {
            int n = re.Length;
            for (int i = 1, j = 0; i < n; i++)
            {
                int bit = n >> 1;
                for (; (j & bit) != 0; bit >>= 1) j ^= bit;
                j ^= bit;
                if (i < j) { (re[i], re[j]) = (re[j], re[i]); (im[i], im[j]) = (im[j], im[i]); }
            }
            for (int len = 2; len <= n; len <<= 1)
            {
                double ang = 2 * Math.PI / len * (inverse ? 1 : -1), wr = Math.Cos(ang), wi = Math.Sin(ang);
                for (int i = 0; i < n; i += len)
                {
                    double cr = 1, ci = 0;
                    for (int j = 0; j < len / 2; j++)
                    {
                        int u = i + j, v = i + j + len / 2;
                        double tr = re[v] * cr - im[v] * ci, ti = re[v] * ci + im[v] * cr;
                        re[v] = re[u] - tr; im[v] = im[u] - ti; re[u] += tr; im[u] += ti;
                        double ncr = cr * wr - ci * wi; ci = cr * wi + ci * wr; cr = ncr;
                    }
                }
            }
            if (inverse) for (int i = 0; i < n; i++) { re[i] /= n; im[i] /= n; }
        }
    }
}
