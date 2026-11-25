// The chest's synthesized sounds (Audio/ChestSounds.cs on Audio/WebSynth.cs), rendered offline:
//   dotnet run -c Release --project tools/unity/sound-test -- <dir>
//       each sound to <dir>/<name>.wav (44.1 kHz mono) with its length, peak, RMS and render time; then, if
//       <dir>/web-<name>.json is there (node tools/unity/sound-test/web.mjs <dir>: the page's own chest-sfx.js in
//       Chrome's OfflineAudioContext), the loudness of the first 300 ms against Chrome's.
//   dotnet run -c Release --project tools/unity/sound-test -- speed
//       the average render time of a hit and of a KO.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Audio;

static class Program
{
    static readonly ChestSounds.Spec Wood = new ChestSounds.Spec("wood", 1), Steel = new ChestSounds.Spec("steel", 1.05, "iron"), Gem = new ChestSounds.Spec("crystal", 1, "rainbow", "juice");

    // (the same calls as web.mjs's)
    static readonly (string name, Func<float[]> f)[] Cases =
    {
        ("hit-wood", () => ChestSounds.Hit("poke", false, "fruit", 0, 0.1, false, Wood)),
        ("hit-wood-hv", () => ChestSounds.Hit("poke", true, "fruit", 0, 0.6, false, Wood)),
        ("hit-steel", () => ChestSounds.Hit("poke", false, "heroes", 3, 0.4, false, Steel)),
        ("hit-gem-ko", () => ChestSounds.Hit("poke", true, "fruit", 4, 1, true, Gem)),
        ("bounce", () => ChestSounds.Bounce(900, "fruit", 0, Wood)),
        ("charge", () => ChestSounds.Charge(1.2)),
        ("poof3", () => ChestSounds.Poof(3)),
        ("burst4", () => ChestSounds.Burst(4, "fruit", Gem)),
        ("card0", () => ChestSounds.Card(0)), ("card6", () => ChestSounds.Card(6)),
        ("fly", ChestSounds.Fly), ("full", ChestSounds.Full), ("gather", () => ChestSounds.Gather(1.43)), ("bam", ChestSounds.Bam), ("land", ChestSounds.Land),
    };

    static int Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "speed") return Speed();
        string dir = args.Length > 0 ? args[0] : "sound-test";
        Directory.CreateDirectory(dir);
        ChestSounds.Warm();
        foreach (var (name, f) in Cases)
        {
            var sw = Stopwatch.StartNew(); var s = f(); sw.Stop();
            double pk = 0, e = 0; bool nan = false;
            foreach (var x in s) { if (float.IsNaN(x)) nan = true; pk = Math.Max(pk, Math.Abs(x)); e += x * x; }
            Wav(Path.Combine(dir, name + ".wav"), s, ChestSounds.Rate);
            string vs = "";
            var web = Path.Combine(dir, "web-" + name + ".json");
            if (File.Exists(web))
            {
                var w = JsonSerializer.Deserialize<double[]>(File.ReadAllText(web));
                vs = $"  first 300 ms {Db(Env(s).Take(30)),6:0.0} dB, Chrome's {Db(w.Take(30)),6:0.0} dB";
            }
            Console.WriteLine($"{name,-12} {s.Length / (double)ChestSounds.Rate,5:0.00} s  peak {pk:0.000}  rms {Math.Sqrt(e / s.Length):0.0000}{(nan ? "  NaN!" : "")}  {sw.ElapsedMilliseconds,4} ms{vs}");
        }
        return 0;
    }

    static int Speed()
    {
        ChestSounds.Warm();
        for (int k = 0; k < 3; k++) ChestSounds.Hit("poke", false, "fruit", 0, 0.1, false, Wood);
        var sw = Stopwatch.StartNew();
        for (int k = 0; k < 20; k++) ChestSounds.Hit("poke", false, "fruit", 0, 0.1, false, Wood);
        Console.WriteLine($"a hit: {sw.ElapsedMilliseconds / 20.0:0.0} ms");
        sw.Restart();
        for (int k = 0; k < 20; k++) ChestSounds.Hit("poke", true, "fruit", 4, 1, true, Gem);
        Console.WriteLine($"a KO: {sw.ElapsedMilliseconds / 20.0:0.0} ms");
        return 0;
    }

    // the 10 ms RMS envelope
    static IEnumerable<double> Env(float[] s)
    {
        for (int i = 0; i + 441 <= s.Length; i += 441) { double e = 0; for (int j = i; j < i + 441; j++) e += s[j] * s[j]; yield return Math.Sqrt(e / 441); }
    }
    static double Db(IEnumerable<double> env) { var l = env.ToList(); return 20 * Math.Log10(Math.Max(1e-9, Math.Sqrt(l.Sum(x => x * x) / Math.Max(1, l.Count)))); }

    static void Wav(string f, float[] s, int rate)
    {
        using var w = new BinaryWriter(File.Create(f));
        w.Write("RIFF"u8.ToArray()); w.Write(36 + s.Length * 2); w.Write("WAVEfmt "u8.ToArray()); w.Write(16); w.Write((short)1); w.Write((short)1);
        w.Write(rate); w.Write(rate * 2); w.Write((short)2); w.Write((short)16);
        w.Write("data"u8.ToArray()); w.Write(s.Length * 2);
        foreach (var x in s) w.Write((short)Math.Round(Math.Max(-1, Math.Min(1, x)) * 32767));
    }
}
