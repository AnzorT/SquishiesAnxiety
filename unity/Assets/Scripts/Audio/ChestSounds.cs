// The chest screens' synthesized sounds, as the app's web pages make them, on WebSynth (no UnityEngine):
//   the smash (android/app/src/main/assets/chest/chest-sfx.js, the ChestSFX its chest-models.js plays): a layered
//     impact per hit (a transient crack, a saturated sub kick, a crunchy body, the material's ring, debris, the chest's
//     accents, a room tail), each material its own recipe; the bounces of the flying pieces; the upgrade's charge and
//     poof; the KO's burst.
//   the unlock (tools/chest/host.html SND): a bell a step up the scale for each copy landing, a whoosh for the new one
//     and a chord when it's in, a rising rush as they gather, the BAM, a soft thump as the creature lands.
// Each returns the sound's samples (mono, Rate Hz); Snd.Synth plays them. Its own Random: the chest engine's (seeded in
// the tests) is never drawn from.
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Audio
{
    public static class ChestSounds
    {
        public static int Rate = 44100;
        static readonly Random R = new Random();

        /// <summary>A chest's sound recipe (models.json `mat` .sfx): its material, pitch and accents.</summary>
        public sealed class Spec
        {
            public string M = "wood"; public double P = 1; public string[] X;
            public Spec() { }
            public Spec(string m, double p, params string[] x) { M = m; P = p; X = x.Length > 0 ? x : null; }
        }

        /// <summary>Makes ahead what every sound needs (the room's spectra): when a chest screen opens.</summary>
        public static void Warm() => Smash().Warm();

        // ---- the smash (chest-sfx.js) ------------------------------------------------------------------------------------
        // (each sound its own generator, seeded from R: they render on worker threads)
        static Random Gen() { lock (R) return new Random(R.Next()); }
        static WebSynth Smash() => new WebSynth(Rate, Gen())
        {
            CompThreshold = -16, CompKnee = 4, CompRatio = 8, CompAttack = 0.002, CompRelease = 0.12, OutGain = 1,
        };

        sealed class Mat
        {
            public double Body, Sub, Cr0, Cr1, Q, Hard; public string Deb;
            public double[] Ring; public double RingD, RingV;
        }
        static Mat Mt(double body, double sub, double cr0, double cr1, double q, string deb, double hard, double[] ring = null, double rd = 0, double rv = 0)
            => new Mat { Body = body, Sub = sub, Cr0 = cr0, Cr1 = cr1, Q = q, Deb = deb, Hard = hard, Ring = ring, RingD = rd, RingV = rv };
        // body = the main noise band, sub = the kick's pitch, cr = the crunch band, q = its resonance, deb = the debris,
        // ring = resonant partials (freqs, decay, vol), hard = how much transient / sub punch (0-1)
        static readonly Dictionary<string, Mat> M = new Dictionary<string, Mat>
        {
            ["paper"] = Mt(2600, 150, 2500, 6500, 0.8, "rustle", 0.55),
            ["card"] = Mt(650, 130, 500, 1900, 2, "rustle", 0.75),
            ["plastic"] = Mt(1300, 170, 900, 3000, 4, "clatter", 0.85, new double[] { 620, 1480, 2300 }, 0.12, 0.16),
            ["tin"] = Mt(1800, 160, 1500, 5000, 3, "tink", 0.9, new double[] { 740, 1890, 3100, 4400 }, 0.4, 0.2),
            ["iron"] = Mt(1100, 105, 800, 3200, 2, "tink", 1, new double[] { 310, 845, 1620, 2580 }, 0.95, 0.24),
            ["steel"] = Mt(800, 80, 600, 2600, 2, "tink", 1, new double[] { 175, 520, 1100, 1980, 3050 }, 1.5, 0.26),
            ["gold"] = Mt(1400, 110, 900, 3600, 2, "tink", 1, new double[] { 520, 1310, 2470, 3900 }, 1.1, 0.2),
            ["glass"] = Mt(4200, 150, 3000, 8000, 1.5, "shard", 0.85, new double[] { 2100, 3400, 5200 }, 0.5, 0.14),
            ["crystal"] = Mt(5000, 135, 3500, 9000, 1.2, "shard", 0.9, new double[] { 2600, 3900, 5800, 7400 }, 0.85, 0.12),
            ["sugar"] = Mt(3600, 140, 2500, 7000, 2, "shard", 0.8, new double[] { 1900, 3100, 4600 }, 0.28, 0.1),
            ["candy"] = Mt(2200, 160, 1500, 4500, 5, "clatter", 0.85, new double[] { 1300, 2600, 3900 }, 0.16, 0.14),
            ["wood"] = Mt(950, 145, 700, 2700, 5, "splinter", 0.95, new double[] { 420, 980 }, 0.12, 0.12),
            ["pine"] = Mt(1200, 165, 900, 3200, 6, "splinter", 0.9, new double[] { 520, 1240 }, 0.09, 0.12),
            ["hardwood"] = Mt(750, 120, 600, 2200, 5, "splinter", 1, new double[] { 330, 800 }, 0.18, 0.14),
            ["moss"] = Mt(600, 125, 500, 1600, 3, "splinter", 0.7),
            ["wicker"] = Mt(1700, 150, 1400, 3800, 9, "weave", 0.7),
            ["stone"] = Mt(1500, 110, 1100, 4500, 2, "grit", 1),
            ["pebble"] = Mt(1900, 135, 1500, 5000, 2.5, "grit", 0.9, new double[] { 1250 }, 0.04, 0.12),
            ["rock"] = Mt(1000, 90, 800, 3500, 1.8, "grit", 1),
            ["shell"] = Mt(2200, 150, 1600, 5200, 3, "clatter", 0.85, new double[] { 1100, 2300, 3700 }, 0.12, 0.14),
            ["velvet"] = Mt(500, 120, 400, 1300, 2, "soft", 0.75),
            ["puff"] = Mt(420, 110, 380, 1200, 1, "soft", 0.6),
            ["cake"] = Mt(520, 120, 450, 1400, 3, "soft", 0.65),
            ["frosting"] = Mt(700, 125, 600, 1800, 4, "soft", 0.65),
        };

        // a group's five chests (the fallback when a chest has no recipe of its own)
        static readonly Dictionary<string, Spec[]> CHESTS = new Dictionary<string, Spec[]>
        {
            ["snack"] = new[] { new Spec("paper", 1), new Spec("plastic", 1, "latch"), new Spec("tin", 1, "latch"), new Spec("glass", 1), new Spec("candy", 1, "rainbow", "fizz") },
            ["fruit"] = new[] { new Spec("wood", 1.05), new Spec("wicker", 1), new Spec("wicker", 0.85, "latch"), new Spec("crystal", 0.9, "juice"), new Spec("crystal", 1, "rainbow", "juice") },
            ["ocean"] = new[] { new Spec("pebble", 1), new Spec("shell", 1, "water"), new Spec("shell", 0.92, "pearl", "water"), new Spec("crystal", 1.05, "water"), new Spec("crystal", 1.1, "rainbow", "pearl", "water") },
            ["pet"] = new[] { new Spec("card", 1), new Spec("wood", 1.1, "squeak"), new Spec("velvet", 1, "squeak"), new Spec("crystal", 0.95, "squeak"), new Spec("crystal", 1, "rainbow", "squeak") },
            ["forest"] = new[] { new Spec("moss", 1, "leaf"), new Spec("hardwood", 1, "leaf"), new Spec("hardwood", 0.9, "iron"), new Spec("crystal", 0.85, "leaf"), new Spec("crystal", 1, "rainbow", "chime") },
            ["sky"] = new[] { new Spec("puff", 0.95, "water"), new Spec("puff", 1.1), new Spec("puff", 1.05, "silver"), new Spec("puff", 1.15, "chime"), new Spec("crystal", 1.2, "rainbow", "chime") },
            ["dream"] = new[] { new Spec("stone", 1), new Spec("stone", 1.1, "latch"), new Spec("stone", 0.95, "goldx"), new Spec("crystal", 0.95, "chime"), new Spec("crystal", 1, "rainbow", "chime") },
            ["bakery"] = new[] { new Spec("cake", 1), new Spec("cake", 1.1, "paperx"), new Spec("frosting", 1, "paperx"), new Spec("sugar", 1), new Spec("sugar", 1.1, "rainbow", "fizz") },
            ["heroes"] = new[] { new Spec("card", 0.92), new Spec("plastic", 0.9, "latch"), new Spec("iron", 1), new Spec("steel", 1, "vault"), new Spec("steel", 1.1, "vault", "rainbow") },
            ["elemental"] = new[] { new Spec("rock", 1), new Spec("rock", 1.05, "zap"), new Spec("iron", 1.1, "zap"), new Spec("crystal", 0.9, "zap"), new Spec("crystal", 1, "rainbow", "zap", "fire") },
            ["spooky"] = new[] { new Spec("pine", 1), new Spec("wood", 0.85, "creak"), new Spec("iron", 0.9, "creak"), new Spec("crystal", 0.8, "ghost"), new Spec("crystal", 0.9, "rainbow", "ghost") },
        };
        static Spec SpecOf(Spec mat, string group, int lv)
        {
            if (mat != null && M.ContainsKey(mat.M)) return mat;
            var g = group != null && CHESTS.TryGetValue(group, out var l) ? l : CHESTS["fruit"];
            return lv >= 0 && lv < g.Length ? g[lv] : CHESTS["fruit"][0];
        }

        static double Mtof(double m) => 440 * Math.Pow(2, (m - 69) / 12);
        static void Bell(WebSynth s, double f, double t, double dur, double v)
        {
            s.Tone(f, t, dur, vol: v, verb: 0.6);
            s.Tone(f * 2.76, t, dur * 0.4, vol: v * 0.25, verb: 0.5);
            s.Tone(f * 5.4, t, dur * 0.15, vol: v * 0.1);
        }

        static void Ring(WebSynth s, Mat m, double t, double H, double p, double len)
        {
            if (m.Ring == null) return;
            for (int i = 0; i < m.Ring.Length; i++)
                s.Tone(m.Ring[i] * p * s.Rr(0.98, 1.02), t, m.RingD * (1 - i * 0.12) * len, type: i > 0 ? "sine" : "triangle", vol: m.RingV * H / (1 + i * 0.6), verb: 0.35);
        }

        static void Debris(WebSynth s, Mat m, double t, double H, int n, double spread, double p)
        {
            for (int i = 0; i < n; i++)
            {
                double tt = t + Math.Pow(s.Random(), 1.6) * spread, v = H * Math.Max(0.15, 1 - (tt - t) / (spread * 1.3));
                switch (m.Deb)
                {
                    case "splinter": s.Noise(tt, s.Rr(0.01, 0.035), f: s.Rr(900, 3200) * p, q: 6, vol: 0.22 * v); if (s.Random() < 0.4) s.Tone(s.Rr(260, 700) * p, tt, s.Rr(0.04, 0.09), type: "triangle", vol: 0.12 * v); break;
                    case "grit": s.Noise(tt, s.Rr(0.012, 0.04), f: s.Rr(1500, 6000) * p, q: 3, vol: 0.2 * v); if (s.Random() < 0.35) s.Tone(s.Rr(700, 1600) * p, tt, 0.03, type: "triangle", vol: 0.09 * v); break;
                    case "rustle": s.Noise(tt, s.Rr(0.015, 0.05), ft: "highpass", f: s.Rr(1800, 5000) * p, vol: 0.16 * v); break;
                    case "clatter": s.Tone(s.Rr(1200, 3200) * p, tt, s.Rr(0.02, 0.05), type: "triangle", vol: 0.12 * v); s.Noise(tt, 0.012, f: s.Rr(2000, 5000), q: 4, vol: 0.1 * v); break;
                    case "tink": s.Tone(s.Rr(2500, 6500) * p, tt, s.Rr(0.08, 0.2), vol: 0.07 * v, verb: 0.3); s.Noise(tt, 0.008, ft: "highpass", f: 5000, vol: 0.08 * v); break;
                    case "shard": s.Tone(s.Rr(3000, 8500) * p, tt, s.Rr(0.1, 0.35), vol: 0.07 * v, verb: 0.45); s.Noise(tt, 0.01, ft: "highpass", f: 7000, vol: 0.1 * v); break;
                    case "weave": s.Noise(tt, s.Rr(0.006, 0.018), f: s.Rr(1500, 3500) * p, q: 12, vol: 0.25 * v); if (s.Random() < 0.2) s.Tone(s.Rr(500, 900), tt, 0.05, type: "sawtooth", to: s.Rr(300, 500), vol: 0.03 * v, lp: 1500); break;
                    default: s.Noise(tt, s.Rr(0.03, 0.07), f: s.Rr(500, 1500) * p, q: 2, vol: 0.14 * v); break;
                }
            }
        }

        static void Accent(WebSynth s, string a, double t, double H)
        {
            switch (a)
            {
                case "latch": s.Tone(1800, t + 0.01, 0.03, type: "square", vol: 0.06 * H, lp: 4000); s.Tone(2700, t + 0.04, 0.05, type: "triangle", vol: 0.06 * H); break;
                case "iron": { var fs = new double[] { 330, 880, 1700 }; for (int i = 0; i < 3; i++) s.Tone(fs[i] * s.Rr(0.98, 1.02), t, 0.6 - i * 0.15, vol: 0.12 * H / (i + 1), verb: 0.3); break; }
                case "goldx": foreach (var f in new double[] { 1480, 3720 }) s.Tone(f, t + 0.01, 0.7, vol: 0.07 * H, verb: 0.5); break;
                case "silver": foreach (var f in new double[] { 2350, 4100 }) s.Tone(f, t + 0.01, 0.6, vol: 0.06 * H, verb: 0.5); break;
                case "paperx": for (int i = 0; i < 3; i++) s.Noise(t + i * 0.02, 0.03, ft: "highpass", f: 3500, vol: 0.1 * H); break;
                case "pearl": Bell(s, 2800, t + 0.03, 0.4, 0.06 * H); break;
                case "chime": { var ms = new double[] { 88, 91, 95 }; for (int i = 0; i < ms.Length; i++) Bell(s, Mtof(ms[i]), t + 0.04 + i * 0.05, 0.6, 0.05 * H); break; }
                case "rainbow": { var ms = new double[] { 84, 86, 88, 91, 93, 96 }; for (int i = 0; i < ms.Length; i++) Bell(s, Mtof(ms[i]), t + 0.05 + i * 0.03, 0.5, 0.04 * H); break; }
                case "water":
                    s.Noise(t + 0.01, 0.25, f: 700, fTo: 2600, q: 1.5, vol: 0.2 * H, a: 0.01);
                    for (int i = 0; i < 4; i++) s.Tone(s.Rr(350, 700), t + 0.03 + i * s.Rr(0.02, 0.05), 0.06, to: s.Rr(900, 1600), vol: 0.08 * H);
                    break;
                case "juice": s.Noise(t + 0.02, 0.18, f: 900, fTo: 300, q: 4, vol: 0.18 * H); break;
                case "fizz":
                    s.Noise(t + 0.05, 0.5, ft: "highpass", f: 6000, vol: 0.05 * H, a: 0.05);
                    for (int i = 0; i < 8; i++) s.Tone(s.Rr(3000, 6000), t + 0.05 + s.Rr(0, 0.4), 0.015, vol: 0.04 * H);
                    break;
                case "squeak": s.Tone(1400, t + 0.06, 0.12, to: 2200, slide: 0.06, type: "triangle", vol: 0.06 * H); break;
                case "leaf": s.Noise(t + 0.02, 0.22, ft: "highpass", f: 3000, fTo: 1800, vol: 0.09 * H, a: 0.02); break;
                case "zap":
                    s.Tone(90, t, 0.25, type: "sawtooth", vol: 0.14 * H, lp: 2200, dist: true);
                    for (int i = 0; i < 6; i++) s.Noise(t + s.Rr(0, 0.2), 0.012, ft: "highpass", f: 5000, vol: 0.14 * H);
                    break;
                case "fire": s.Noise(t + 0.02, 0.4, ft: "lowpass", f: 1400, vol: 0.18 * H, a: 0.05); break;
                case "vault": s.Tone(55, t, 0.7, type: "triangle", to: 40, vol: 0.4 * H, dist: true); s.Noise(t + 0.03, 0.3, f: 300, q: 3, vol: 0.12 * H); break;
                case "creak": s.Tone(s.Rr(170, 220), t + 0.04, 0.3, type: "sawtooth", to: s.Rr(110, 140), vol: 0.05 * H, lp: 1100); break;
                case "ghost":
                    s.Tone(320, t + 0.03, 0.6, to: 640, slide: 0.5, vol: 0.06 * H, a: 0.1, verb: 0.7);
                    s.Tone(327, t + 0.03, 0.6, to: 600, slide: 0.5, vol: 0.05 * H, a: 0.1, verb: 0.7);
                    break;
            }
        }

        static void SmashAt(WebSynth s, double t, Spec sp, double H, double len, double deb, double low)
        {
            var m = M[sp.M]; double p = sp.P > 0 ? sp.P : 1, hd = m.Hard;
            s.Noise(t, 0.012, ft: "highpass", f: 2500 * p, vol: 0.9 * H * hd, dist: true);
            s.Tone(3200 * p, t, 0.008, type: "square", vol: 0.25 * H * hd);
            double s0 = m.Sub * p * s.Rr(0.94, 1.06) * low;
            s.Tone(s0 * 1.6, t, 0.28 * len, to: s0 * 0.3, slide: 0.12 * len, vol: 0.95 * H * (0.5 + hd * 0.5), dist: true);
            s.Tone(s0 * 0.5, t, 0.35 * len, to: 32, slide: 0.25 * len, vol: 0.6 * H);
            int nb = (int)Math.Round(6 + 10 * H * len);
            for (int i = 0; i < nb; i++) s.Noise(t + i * s.Rr(0.006, 0.014), s.Rr(0.012, 0.03), f: s.Rr(m.Cr0, m.Cr1) * p, q: m.Q, vol: 0.55 * H * (1 - (double)i / nb * 0.8), dist: true);
            s.Noise(t, 0.09 * len, f: m.Body * p, q: 0.8, vol: 0.5 * H, dist: true, verb: 0.35);
            Ring(s, m, t, H, p, len);
            Debris(s, m, t + 0.03, H, (int)Math.Round(deb), 0.25 * len, p);
            if (sp.X != null) foreach (var a in sp.X) Accent(s, a, t, H);
        }

        static void Voice(WebSynth s, string kind, double t, double H)
        {
            if (kind == "battle") s.Noise(Math.Max(0, t - 0.07), 0.07, f: 600, fTo: 3500, q: 0.8, vol: 0.25 * H, a: 0.06);
            if (kind == "squash") { s.Noise(t + 0.02, 0.3, f: 800, fTo: 200, q: 4, vol: 0.35 * H, a: 0.01); s.Tone(220, t + 0.03, 0.3, type: "sawtooth", to: 90, vol: 0.06 * H, lp: 900); }
            if (kind == "land") { s.Tone(60, t, 0.5, to: 28, vol: 0.8 * H, dist: true); s.Noise(t, 0.5, ft: "lowpass", f: 900, fTo: 150, vol: 0.45 * H); }
        }

        static void Cracks(WebSynth s, double t, Mat m, double p, double dmg, double H)
        {
            int n = (int)Math.Round(2 + dmg * 10);
            for (int i = 0; i < n; i++) s.Noise(t + 0.04 + i * s.Rr(0.01, 0.03), s.Rr(0.008, 0.02), f: s.Rr(m.Cr0, m.Cr1 * 1.3) * p, q: 8, vol: (0.15 + dmg * 0.3) * H, dist: true);
            if (dmg > 0.5) s.Tone(s.Rr(160, 240) * p, t + 0.05, 0.25, type: "sawtooth", to: s.Rr(70, 110), vol: 0.08 * H, lp: 1200);
        }

        /// <summary>ChestSFX.hit: a tap on the chest (`dmg` its damage so far, 0-1; `ko` the last).</summary>
        public static float[] Hit(string kind, bool heavy, string group, int lv, double dmg, bool ko, Spec mat)
        {
            var s = Smash(); var sp = SpecOf(mat, group, lv); var m = M[sp.M];
            const double t = 0.005;
            double H = ko ? 1 : heavy ? 0.95 : 0.65;
            Voice(s, kind, t, H);
            SmashAt(s, t, sp, H, ko ? 1.6 : heavy ? 1.2 : 0.8, ko ? 40 : heavy ? 18 : 8, kind == "land" ? 0.8 : kind == "poke" && !heavy ? 1.2 : 1);
            if (dmg >= 0.25) Cracks(s, t, m, sp.P > 0 ? sp.P : 1, dmg, H);
            if (ko)
            {
                SmashAt(s, t + 0.07, sp, 0.8, 1.4, 25, 0.85);
                s.Tone(45, t, 1.1, to: 25, vol: 0.7, dist: true); s.Noise(t, 1.0, ft: "lowpass", f: 400, fTo: 80, vol: 0.4);
                s.Noise(t + 0.2, 0.45, f: 300, fTo: 3000, q: 1, vol: 0.2, a: 0.4);
            }
            return s.Render();
        }

        /// <summary>ChestSFX.fall: the chest dropping in.</summary>
        public static float[] Fall(bool heavy)
        {
            var s = Smash(); double d = heavy ? 0.68 : 0.48;
            s.Tone(1500, 0, d, to: 380, slide: d, vol: 0.07, type: "triangle", a: 0.05);
            s.Noise(0, d, f: 400, fTo: 2000, q: 1, vol: 0.1, a: d * 0.85);
            return s.Render();
        }

        /// <summary>ChestSFX.bounce: a flying piece hitting the floor at speed v (null when too soft to hear).</summary>
        public static float[] Bounce(double v, string group, int lv, Spec mat)
        {
            double H = Math.Min(0.9, v / 1300);
            if (H < 0.2) return null;
            var s = Smash(); var sp = SpecOf(mat, group, lv);
            SmashAt(s, 0, new Spec { M = sp.M, P = sp.P }, H * 0.75, 0.7, 4 + H * 8, 0.85);
            return s.Render();
        }

        /// <summary>ChestSFX.charge: the upgrade's rise, `dur` seconds.</summary>
        public static float[] Charge(double dur)
        {
            var s = Smash();
            s.Noise(0, dur, f: 300, fTo: 4200, q: 2, vol: 0.13, a: dur * 0.9);
            s.Tone(196, 0, dur, type: "sawtooth", to: 784, slide: dur, vol: 0.035, lp: 1800, a: dur * 0.8);
            return s.Render();
        }

        /// <summary>ChestSFX.poof: the chest changing up to rarity `lv`.</summary>
        public static float[] Poof(int lv)
        {
            var s = Smash();
            s.Noise(0, 0.7, ft: "lowpass", f: 2400, fTo: 180, vol: 0.4, verb: 0.4);
            s.Tone(72, 0, 0.5, to: 34, vol: 0.55, dist: true);
            var ms = new double[] { 72, 76, 79, 84, 88, 91 };
            for (int i = 0; i < Math.Min(ms.Length, 2 + lv); i++) Bell(s, Mtof(ms[i]), 0.05 + i * 0.06, 0.9, 0.11);
            return s.Render();
        }

        /// <summary>ChestSFX.burst: the chest bursting open (rarity `lv`).</summary>
        public static float[] Burst(int lv, string group, Spec mat)
        {
            lv = Math.Max(0, Math.Min(4, lv));
            var s = Smash(); var sp = SpecOf(mat, group, lv);
            const double t = 0.01;
            SmashAt(s, t, sp, 1, 1.8, 50, 0.7);
            s.Tone(38, t, 1.4, to: 22, vol: 0.8, dist: true);
            s.Noise(t, 1.2, ft: "lowpass", f: 2200, fTo: 120, vol: 0.45, verb: 0.5);
            Debris(s, M[sp.M], t + 0.25, 0.5, 22, 0.8, sp.P > 0 ? sp.P : 1);
            var all = new double[] { 72, 76, 79, 84, 88, 91, 96 };
            var fan = all.Take(3 + lv).ToArray();
            for (int i = 0; i < fan.Length; i++) Bell(s, Mtof(fan[i]), t + 0.32 + i * 0.075, 0.9, 0.12);
            double end = t + 0.32 + fan.Length * 0.075;
            foreach (var m in new double[] { 60, 64, 67 }) s.Tone(Mtof(m), end, 1.2 + lv * 0.2, type: "triangle", vol: 0.05, a: 0.04, verb: 0.4);
            int n = new[] { 8, 12, 16, 22, 28 }[lv];
            for (int i = 0; i < n; i++)
            {
                double tt = t + 0.4 + i * s.Rr(0.035, 0.07);
                if (i % 3 == 0) { s.Tone(1318, tt, 0.07, type: "square", vol: 0.03, lp: 5000); Bell(s, 1976, tt + 0.06, 0.35, 0.045); }
                else Bell(s, s.Rr(1700, 3800), tt, 0.4, 0.04);
            }
            return s.Render();
        }

        // ---- the unlock (host.html SND) ----------------------------------------------------------------------------------
        static WebSynth Unlock() => new WebSynth(Rate, Gen())
        {
            CompThreshold = -14, CompKnee = 30, CompRatio = 6, CompAttack = 0.003, CompRelease = 0.25, OutGain = 0.7,
        };
        // host.html's tone / noise: the gain up exponentially to vol by `a`, down by max(d, a + 0.02)
        static void UTone(WebSynth s, double f, double t, double d, string type = "sine", double to = 0, double slide = 0, double a = 0.006, double vol = 0.1)
            => s.Tone(f, t, d, type: type, to: to, slide: slide, vol: vol, a: a, expAttack: true, decayEnd: Math.Max(d, a + 0.02));
        static void UNoise(WebSynth s, double t, double d, string ft = "bandpass", double f = 1000, double fTo = 0, double q = 1, double a = 0.006, double vol = 0.1)
            => s.Noise(t, d, ft: ft, f: f, fTo: fTo, q: q, vol: vol, a: a, expAttack: true, decayEnd: Math.Max(d, a + 0.02));
        static void UBell(WebSynth s, double f, double t, double d, double v)
        {
            UTone(s, f, t, d, vol: v); UTone(s, f * 2.76, t, d * 0.45, vol: v * 0.3); UTone(s, f * 5.4, t, d * 0.2, vol: v * 0.12);
        }
        static readonly int[] PENT = { 0, 2, 4, 7, 9 };

        /// <summary>SND.card(i): the i-th copy landing (a bell a step up the pentatonic scale each).</summary>
        public static float[] Card(int i)
        {
            var s = Unlock(); const double t = 0.005;
            UBell(s, Mtof(67 + 12 * (i / 5) + PENT[((i % 5) + 5) % 5]), t, 0.5, 0.07);
            UNoise(s, t, 0.05, ft: "highpass", f: 4000, vol: 0.04);
            return s.Render();
        }

        /// <summary>SND.fly(): the new copy's whoosh.</summary>
        public static float[] Fly()
        {
            var s = Unlock();
            UNoise(s, 0, 0.6, f: 500, fTo: 3500, q: 1.2, a: 0.45, vol: 0.12);
            return s.Render();
        }

        /// <summary>SND.full(): the chord when the last copy is in.</summary>
        public static float[] Full()
        {
            var s = Unlock(); const double t = 0.01;
            var ms = new double[] { 79, 83, 86, 91 };
            for (int i = 0; i < ms.Length; i++) UBell(s, Mtof(ms[i]), t + i * 0.06, 0.9, 0.08);
            return s.Render();
        }

        /// <summary>SND.gather(d): the rising rush as the copies gather (`d` seconds; stopped at the BAM).</summary>
        public static float[] Gather(double d)
        {
            var s = Unlock();
            UNoise(s, 0, d, f: 250, fTo: 4200, q: 1.4, a: d * 0.95, vol: 0.22);
            UTone(s, 140, 0, d, type: "triangle", to: 880, a: d * 0.9, vol: 0.09);
            return s.Render();
        }

        /// <summary>SND.bam(): the BAM (a deep thump, a blast and a fan of bells and sparkles).</summary>
        public static float[] Bam()
        {
            var s = Unlock(); const double t = 0.005;
            UTone(s, 90, t, 0.9, to: 30, slide: 0.5, vol: 0.9);
            UTone(s, 180, t, 0.3, type: "triangle", to: 60, vol: 0.35);
            UNoise(s, t, 0.9, ft: "lowpass", f: 5000, fTo: 200, vol: 0.55);
            var ms = new double[] { 72, 76, 79, 84, 88, 91, 96 };
            for (int i = 0; i < ms.Length; i++) UBell(s, Mtof(ms[i]), t + 0.12 + i * 0.055, 1.1, 0.07);
            for (int i = 0; i < 12; i++) UBell(s, 1800 + s.Random() * 2400, t + 0.5 + i * (0.04 + s.Random() * 0.05), 0.4, 0.035);
            return s.Render();
        }

        /// <summary>SND.land(): the soft thump as the creature lands.</summary>
        public static float[] Land()
        {
            var s = Unlock();
            UTone(s, 120, 0, 0.22, to: 55, vol: 0.4);
            UNoise(s, 0, 0.18, ft: "lowpass", f: 900, fTo: 200, vol: 0.2);
            return s.Render();
        }
    }
}
