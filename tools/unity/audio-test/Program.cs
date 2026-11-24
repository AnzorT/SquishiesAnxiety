// dotnet run -c Release --project tools/unity/audio-test — the Unity port's sound code against the app's (run
// `node tools/unity/audio-test/run.mjs` first: it writes out/*.json from src/audio, App.js and the call sites):
//   1. the tables: SoundFiles.g.cs equals sfx.js's EFFECTS and MUSIC, the squish stage's files and volumes; each file
//      is in unity/Assets/Resources/Audio, byte for byte the app's
//   2. every sound name used anywhere in src (and App.js) resolves; the menu page's are MenuSynth's
//   3. each call site's rate / delay / volume formula (read from its JS) equals SfxRates' on its inputs
//   4. App.js's music rule (musicFor and the effect's guard), the whoosh between screens and the coins' sounds
//   5. behaviour: every scenario run on SfxCore / SquishLoop / OneShot / SquishHaptics / GameHaptics makes the same
//      player calls (create, replay with its rate, volume steps of every fade, rate, play, pause, unload, the settings
//      file, the switches' notifications, vibrations) at the same virtual times as the app's JS
//   6. the menu's synth sounds: the same tone / noise calls as yard-games.js's SFX
// Exit code 1 on any mismatch.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using SquishSquad.Audio;

static class Program
{
    static int _fail, _pass;
    static string Here, Repo, OutDir;

    static void Check(bool ok, string what)
    {
        if (ok) _pass++;
        else
        {
            _fail++;
            if (_fail <= 60) Console.WriteLine("  MISMATCH " + what);
        }
    }

    static JsonElement Load(string name) => JsonDocument.Parse(File.ReadAllText(Path.Combine(OutDir, name))).RootElement;

    static int Main(string[] args)
    {
        Here = AppContext.BaseDirectory;
        var d = new DirectoryInfo(Here);
        while (d != null && !File.Exists(Path.Combine(d.FullName, "run.mjs"))) d = d.Parent;
        Here = d?.FullName ?? Directory.GetCurrentDirectory();
        Repo = Path.GetFullPath(Path.Combine(Here, "../../.."));
        OutDir = Path.Combine(Here, "out");
        if (!File.Exists(Path.Combine(OutDir, "js-traces.json")))
        {
            Console.WriteLine("run `node tools/unity/audio-test/run.mjs` first");
            return 2;
        }
        Section("1. tables", Tables);
        Section("2. names", Names);
        Section("3. formulas", Formulas);
        Section("4. App.js rules", Rules);
        Section("5. behaviour", Behaviour);
        Section("6. menu synth", Synth);
        Console.WriteLine(_fail == 0 ? $"OK: {_pass} checks, 0 mismatches" : $"FAILED: {_fail} mismatches ({_pass} checks passed)");
        return _fail == 0 ? 0 : 1;
    }

    static void Section(string name, Action fn)
    {
        int p0 = _pass, f0 = _fail;
        fn();
        Console.WriteLine($"{name}: {_pass - p0} checks, {_fail - f0} mismatches");
    }

    // ---- 1 -------------------------------------------------------------------------------------------------------------
    static void SameTable(JsonElement js, IReadOnlyDictionary<string, string> cs, string what)
    {
        var keys = js.EnumerateObject().Select(p => p.Name).ToList();
        Check(keys.Count == cs.Count, $"{what}: {keys.Count} in the app, {cs.Count} in SoundFiles");
        foreach (var p in js.EnumerateObject())
            Check(cs.TryGetValue(p.Name, out var f) && f == p.Value.GetString(), $"{what}[{p.Name}] = {p.Value} (Unity: {(cs.TryGetValue(p.Name, out var g) ? g : "missing")})");
        foreach (var k in cs.Keys) Check(keys.Contains(k), $"{what}: {k} isn't the app's");
    }

    static string Sha(string f) => Convert.ToHexString(SHA1.HashData(File.ReadAllBytes(f)));

    static void Tables()
    {
        var t = Load("tables.json");
        SameTable(t.GetProperty("effects"), SoundFiles.Effects, "EFFECTS");
        SameTable(t.GetProperty("music"), SoundFiles.Music, "MUSIC");
        SameTable(t.GetProperty("creatureSquish"), SoundFiles.CreatureSquish, "creatureSquishFiles");
        foreach (var p in t.GetProperty("squishSoundFor").EnumerateObject())
        {
            string js = p.Value.ValueKind == JsonValueKind.String ? p.Value.GetString() : p.Value.GetProperty("uri").GetString();
            string cs = p.Name == "(audio url)" ? SquishLoop.SourceFor("3", "https://example.invalid/x.mp3")
                : p.Name == "(no creature)" ? SquishLoop.SourceFor(null)
                : SquishLoop.SourceFor(p.Name);
            Check(js == cs, $"squishSoundFor({p.Name}) = {js} (Unity {cs})");
        }
        Check(t.GetProperty("coin").GetProperty("file").GetString() == SoundFiles.Coin && t.GetProperty("coin").GetProperty("volume").GetDouble() == SoundFiles.CoinVolume, "CoinSound");
        Check(t.GetProperty("pop").GetProperty("file").GetString() == SoundFiles.Pop && t.GetProperty("pop").GetProperty("volume").GetDouble() == SoundFiles.PopVolume, "PopSound");
        // every file in the Unity project, as the app's
        var files = SoundFiles.Effects.Values.Concat(SoundFiles.Music.Values).Concat(SoundFiles.CreatureSquish.Values)
            .Concat(new[] { SoundFiles.Coin, SoundFiles.Pop, SoundFiles.DefaultSquish }).Distinct();
        foreach (var f in files)
        {
            var a = Path.Combine(Repo, "assets/audio", f);
            var b = Path.Combine(Repo, "unity/Assets/Resources/Audio", f);
            Check(File.Exists(b) && Sha(a) == Sha(b), $"Resources/Audio/{f} is the app's file");
        }
    }

    // ---- 2 -------------------------------------------------------------------------------------------------------------
    static void Names()
    {
        var n = Load("names.json");
        var names = new SortedSet<string>();
        foreach (var s in n.GetProperty("sites").EnumerateArray())
        {
            var name = s.GetProperty("name").GetString();
            names.Add(name);
            var jsFile = s.GetProperty("file_");
            Check(jsFile.ValueKind == JsonValueKind.String, $"{s.GetProperty("file").GetString()}:{s.GetProperty("line")} '{name}' isn't one of the app's effects either");
            Check(Sfx_Knows(name) && (jsFile.ValueKind != JsonValueKind.String || SoundFiles.Effects[name] == jsFile.GetString()),
                $"{s.GetProperty("file").GetString()}:{s.GetProperty("line")} {s.GetProperty("kind").GetString()} '{name}' doesn't resolve in Unity");
        }
        foreach (var u in n.GetProperty("uncovered").EnumerateArray()) Check(false, "a name the test can't see: " + u);
        foreach (var m in n.GetProperty("menu").EnumerateArray())
            Check(MenuSynth.Sounds.ContainsKey(m.GetProperty("name").GetString()), $"webgame/app/menu.js:{m.GetProperty("line")} sfx('{m.GetProperty("name").GetString()}') isn't a MenuSynth sound");
        var unused = SoundFiles.Effects.Keys.Where(k => !names.Contains(k)).ToList();
        Console.WriteLine($"  {names.Count} names used in src, all resolve; effects in the table no code plays: {string.Join(", ", unused)}");
    }

    static bool Sfx_Knows(string name) => SoundFiles.Effects.ContainsKey(name);

    // ---- 3 -------------------------------------------------------------------------------------------------------------
    static double I(JsonElement a, int k) => a[k].GetDouble();

    static object CsFormula(string id, JsonElement a)
    {
        switch (id)
        {
            case "Stack": return SfxRates.Stack((int)I(a, 0), (int)I(a, 1));
            case "StackRestart": return SfxRates.StackRestart;
            case "StackTick": return SfxRates.StackTick((int)I(a, 0));
            case "BlitzPip": return SfxRates.BlitzPip((int)I(a, 0));
            case "SdBlitzPip": return SfxRates.SdBlitzPip((int)I(a, 0));
            case "SortDeal": return SfxRates.SortDeal((int)I(a, 0));
            case "SortDealGapMs": return SfxRates.SortDealGapMs;
            case "SortJumpAgain": return SfxRates.SortJumpAgain;
            case "SdPlace": return SfxRates.SdPlace((int)I(a, 0));
            case "SdTick": return SfxRates.SdTick((int)I(a, 0));
            case "SdSqueak": return SfxRates.SdSqueak(I(a, 0));
            case "SdMarkDrag": return SfxRates.SdMarkDrag(I(a, 0));
            case "SdHop": return SfxRates.SdHop((int)I(a, 0));
            case "SdHopDelay": return SfxRates.SdHopDelay((int)I(a, 0));
            case "SdBlitzHop": return SfxRates.SdBlitzHop((int)I(a, 0));
            case "SdBlitzHopDelay": return SfxRates.SdBlitzHopDelay((int)I(a, 0));
            case "MapPops": return (double)SfxRates.MapPops;
            case "MapPop": return SfxRates.MapPop((int)I(a, 0));
            case "MapPopAt": return SfxRates.MapPopAt((int)I(a, 0));
            case "PickerPop": return SfxRates.PickerPop((int)I(a, 0));
            case "PickerPopAt": return SfxRates.PickerPopAt((int)I(a, 0));
            case "Star": return SfxRates.Star((int)I(a, 0), (int)I(a, 1));
            case "StarAt": return SfxRates.StarAt((int)I(a, 0));
            case "SdStarAt": return SfxRates.StarAt((int)I(a, 0), squishdoku: true);
            case "HoldStartVolume": return SfxRates.HoldStartVolume;
            case "HoldRate": return SfxRates.HoldRate(I(a, 0));
            case "HoldVolume": return SfxRates.HoldVolume(I(a, 0));
            case "HoldStep": return (double)SfxRates.HoldStep(I(a, 0));
            case "HoldRateEpsilon": return SfxRates.HoldRateEpsilon;
        }
        throw new Exception("no C# for formula " + id);
    }

    static void Formulas()
    {
        foreach (var f in Load("formulas.json").EnumerateArray())
        {
            var id = f.GetProperty("id").GetString();
            var ins = f.GetProperty("inputs");
            var vals = f.GetProperty("values");
            for (int k = 0; k < ins.GetArrayLength(); k++)
            {
                var cs = CsFormula(id, ins[k]);
                var js = vals[k];
                bool ok = js.ValueKind == JsonValueKind.String ? cs is string s && s == js.GetString() : cs is double v && v == js.GetDouble();
                Check(ok, $"{id} ({f.GetProperty("file").GetString()}: {f.GetProperty("expr").GetString()}) at {ins[k]}: JS {js}, C# {cs}");
            }
        }
    }

    // ---- 4 -------------------------------------------------------------------------------------------------------------
    static void Rules()
    {
        var r = Load("rules.json");
        foreach (var m in r.GetProperty("music").EnumerateArray())
        {
            var stage = m.GetProperty("stage").GetString();
            bool onGame = m.GetProperty("onGame").GetBoolean();
            var mf = m.GetProperty("musicFor");
            var eff = m.GetProperty("effect");
            Check((mf.ValueKind == JsonValueKind.Null ? null : mf.GetString()) == Music.For(stage, onGame), $"musicFor({stage}, {onGame})");
            bool unchanged = eff.ValueKind == JsonValueKind.String && eff.GetString() == "unchanged";
            Check(unchanged == !Music.Applies(stage, onGame), $"the music effect acts on ({stage}, {onGame})");
            if (!unchanged)
            {
                // Music.Follow plays exactly what the effect plays
                Sfx.Calls.Clear();
                Music.Follow(stage, onGame);
                Check(Sfx.Calls.Count == 1 && Sfx.Calls[0] == "music " + (eff.ValueKind == JsonValueKind.Null ? "null" : eff.GetString()), $"Music.Follow({stage}, {onGame})");
            }
        }
        foreach (var w in r.GetProperty("whoosh").EnumerateArray())
        {
            var a = new AppSounds();
            var seq = w.GetProperty("seq").EnumerateArray().Select(x => x.GetString()).ToList();
            var outs = w.GetProperty("out").EnumerateArray().Select(x => x.GetBoolean()).ToList();
            for (int i = 0; i < seq.Count; i++) Check(a.WhooshOn(seq[i]) == outs[i], $"whoosh at {i} of {string.Join(",", seq)}");
        }
        foreach (var c in r.GetProperty("coins").EnumerateArray())
        {
            var a = new AppSounds();
            var coins = c.GetProperty("coins").EnumerateArray().Select(x => x.ValueKind == JsonValueKind.Null ? (long?)null : (long)x.GetDouble()).ToList();
            var stages = c.GetProperty("stages").EnumerateArray().Select(x => x.GetString()).ToList();
            var outs = c.GetProperty("out").EnumerateArray().Select(x => x.ValueKind == JsonValueKind.Null ? null : x.GetString()).ToList();
            for (int i = 0; i < coins.Count; i++) Check(a.CoinsSound(coins[i], stages[i]) == outs[i], $"coins at {i}: {string.Join(",", coins)}");
        }
    }

    // ---- 5 -------------------------------------------------------------------------------------------------------------
    sealed class Rec : ISoundBackend, IVibrator
    {
        public readonly List<object[]> Log = new List<object[]>();
        public JsTimers T;
        public HashSet<string> Fail = new HashSet<string>();
        int _next = 1;
        void L(params object[] e) => Log.Add(new object[] { T.Now }.Concat(e).ToArray());

        public int Create(string file, SoundInit init)
        {
            var st = new SortedDictionary<string, object> { { "shouldPlay", init.ShouldPlay }, { "loop", init.Looping }, { "volume", init.Volume }, { "rate", init.Rate } };
            if (Fail.Contains(file)) { L("create", 0.0, file, st); return 0; }
            int id = _next++;
            L("create", (double)id, file, st);
            return id;
        }

        public void Replay(int s, double? rate) => L("replay", (double)s, rate);
        public void SetVolume(int s, double v) => L("vol", (double)s, v);
        public void SetRate(int s, double r) => L("rate", (double)s, r);
        public void Play(int s) => L("play", (double)s);
        public void Pause(int s) => L("pause", (double)s);
        public void Unload(int s) => L("unload", (double)s);
        public void SetMode() => L("mode");
        public void Vibrate(HapticPattern p) => L("vib", p.Name);
        public void Write(string text) => L("write", text);
        public void Notify(bool e, bool m) => L("notify", e, m);
    }

    sealed class MemFile : ISettingsFile
    {
        public string Text;
        public Rec R;
        public string Read() => Text;
        public void Write(string text) { Text = text; R.Write(text); }
    }

    static string N(double v) => v.ToString("R", CultureInfo.InvariantCulture);

    static string Canon(object o)
    {
        switch (o)
        {
            case null: return "null";
            case bool b: return b ? "true" : "false";
            case double v: return N(v);
            case int i: return N(i);
            case string s: return JsonSerializer.Serialize(s);
            case object[] a: return "[" + string.Join(",", a.Select(Canon)) + "]";
            case SortedDictionary<string, object> m: return "{" + string.Join(",", m.Select(kv => JsonSerializer.Serialize(kv.Key) + ":" + Canon(kv.Value))) + "}";
        }
        throw new Exception("canon " + o.GetType());
    }

    static string Canon(JsonElement e)
    {
        switch (e.ValueKind)
        {
            case JsonValueKind.Null: return "null";
            case JsonValueKind.True: return "true";
            case JsonValueKind.False: return "false";
            case JsonValueKind.Number: return N(e.GetDouble());
            case JsonValueKind.String: return JsonSerializer.Serialize(e.GetString());
            case JsonValueKind.Array: return "[" + string.Join(",", e.EnumerateArray().Select(Canon)) + "]";
            case JsonValueKind.Object: return "{" + string.Join(",", e.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal).Select(p => JsonSerializer.Serialize(p.Name) + ":" + Canon(p.Value))) + "}";
        }
        throw new Exception("canon " + e.ValueKind);
    }

    // events grouped by time, each group's order not significant (the JS's promise jobs vs C#'s direct calls)
    static List<string> Groups(IEnumerable<(double t, string e)> evs) =>
        evs.GroupBy(x => x.t).OrderBy(g => g.Key).Select(g => N(g.Key) + ": " + string.Join(" | ", g.Select(x => x.e).OrderBy(x => x, StringComparer.Ordinal))).ToList();

    static double? Num(JsonElement st, string k) => st.TryGetProperty(k, out var v) && v.ValueKind == JsonValueKind.Number ? v.GetDouble() : (double?)null;

    static List<object[]> RunCs(JsonElement sc, JsonElement tables)
    {
        var kind = sc.GetProperty("kind").GetString();
        var t = new JsTimers(sc.GetProperty("start").GetDouble());
        var rec = new Rec { T = t };
        foreach (var f in sc.GetProperty("fail").EnumerateArray()) rec.Fail.Add(f.GetString());
        double end = sc.GetProperty("end").GetDouble();
        var steps = sc.GetProperty("steps").EnumerateArray().ToList();
        if (kind == "sfx")
        {
            var fileEl = sc.GetProperty("file");
            var file = new MemFile { Text = fileEl.ValueKind == JsonValueKind.Null ? null : fileEl.GetString(), R = rec };
            bool active = !(sc.TryGetProperty("active", out var a) && a.ValueKind == JsonValueKind.False);
            var core = new SfxCore(rec, t, file, active: active);
            core.Subscribe(rec.Notify);
            var loops = new Dictionary<int, SfxCore.LoopHandle>();
            foreach (var st in steps)
            {
                t.AdvanceTo(st.GetProperty("at").GetDouble());
                var op = st.GetProperty("op").GetString();
                switch (op)
                {
                    case "init": core.Init(); break;
                    case "play": core.Play(st.GetProperty("name").GetString(), Num(st, "delay") ?? 0, Num(st, "rate")); break;
                    case "preload": core.Preload(st.GetProperty("names").EnumerateArray().Select(x => x.GetString()).ToList()); break;
                    case "budget": core.SetBudget((int)(Num(st, "n") ?? 0)); break;
                    case "music": core.Music(st.GetProperty("name").ValueKind == JsonValueKind.Null ? null : st.GetProperty("name").GetString()); break;
                    case "effects": core.SetEffectsOn(st.GetProperty("on").GetBoolean()); break;
                    case "musicOn": core.SetMusicOn(st.GetProperty("on").GetBoolean()); break;
                    case "active": core.SetActive(st.GetProperty("on").GetBoolean()); break;
                    case "loop": loops[(int)Num(st, "h")] = core.Loop(st.GetProperty("name").GetString(), Num(st, "volume") ?? 1, Num(st, "rate") ?? 1); break;
                    case "loopRate": loops[(int)Num(st, "h")].SetRate(Num(st, "v").Value); break;
                    case "loopVolume": loops[(int)Num(st, "h")].SetVolume(Num(st, "v").Value); break;
                    case "loopStop": loops[(int)Num(st, "h")].Stop(); break;
                    default: throw new Exception(op);
                }
            }
        }
        else if (kind == "squish")
        {
            var s = new SquishLoop(rec, t);
            var file = sc.GetProperty("file").GetString();
            foreach (var st in steps)
            {
                t.AdvanceTo(st.GetProperty("at").GetDouble());
                switch (st.GetProperty("op").GetString())
                {
                    case "load": s.Load(file); break;
                    case "start": s.Start(); break;
                    case "motion": s.NoteMotion(); break;
                    case "stop": s.Stop(); break;
                    case "unload": s.Unload(); break;
                }
            }
        }
        else if (kind == "oneshot")
        {
            var w = tables.GetProperty(sc.GetProperty("which").GetString());
            var s = new OneShot(rec, w.GetProperty("file").GetString(), w.GetProperty("volume").GetDouble());
            foreach (var st in steps)
            {
                t.AdvanceTo(st.GetProperty("at").GetDouble());
                switch (st.GetProperty("op").GetString())
                {
                    case "load": s.Load(); break;
                    case "play": s.Play(); break;
                    case "unload": s.Unload(); break;
                }
            }
        }
        else if (kind == "squishHaptics")
        {
            var h = new SquishHaptics(t, rec);
            foreach (var st in steps)
            {
                t.AdvanceTo(st.GetProperty("at").GetDouble());
                double strength = Num(st, "strength") ?? 0;
                switch (st.GetProperty("op").GetString())
                {
                    case "press": h.Press(strength); break;
                    case "move": h.Move(strength); break;
                    case "release": h.Release(strength); break;
                }
            }
        }
        else if (kind == "gameHaptics")
        {
            var h = new GameHaptics(sc.GetProperty("on").GetBoolean(), rec);
            foreach (var st in steps)
            {
                t.AdvanceTo(st.GetProperty("at").GetDouble());
                switch (st.GetProperty("op").GetString())
                {
                    case "tap": h.Tap(); break;
                    case "place": h.Place(); break;
                    case "wrong": h.Wrong(); break;
                    case "win": h.Win(); break;
                    case "tick": h.Tick(); break;
                }
            }
        }
        t.AdvanceTo(end);
        return rec.Log;
    }

    static void Behaviour()
    {
        var tables = Load("tables.json");
        var traces = Load("js-traces.json");
        int events = 0;
        var kinds = new SortedDictionary<string, int>();
        foreach (var sc in Load("scenarios.json").EnumerateArray())
        {
            var id = sc.GetProperty("id").GetString();
            var kind = sc.GetProperty("kind").GetString();
            kinds[kind] = (kinds.TryGetValue(kind, out var k) ? k : 0) + 1;
            var js = Groups(traces.GetProperty(id).EnumerateArray().Select(e => (e[0].GetDouble(), Canon(JsonDocument.Parse("[" + string.Join(",", e.EnumerateArray().Skip(1).Select(x => x.GetRawText())) + "]").RootElement))));
            var csLog = RunCs(sc, tables);
            var cs = Groups(csLog.Select(e => ((double)e[0], Canon(e.Skip(1).ToArray()))));
            events += csLog.Count;
            int n = Math.Max(js.Count, cs.Count);
            int bad = -1;
            for (int i = 0; i < n; i++)
                if (i >= js.Count || i >= cs.Count || js[i] != cs[i]) { bad = i; break; }
            Check(bad < 0, $"{id}: first difference at group {bad}\n      JS: {(bad >= 0 && bad < js.Count ? js[bad] : "(none)")}\n      C#: {(bad >= 0 && bad < cs.Count ? cs[bad] : "(none)")}");
        }
        Console.WriteLine($"  {string.Join(", ", kinds.Select(kv => kv.Value + " " + kv.Key))}; {events} player calls compared");
    }

    // ---- 6 -------------------------------------------------------------------------------------------------------------
    static void Synth()
    {
        var s = Load("synth.json");
        if (s.ValueKind == JsonValueKind.Null) { Console.WriteLine("  (skipped: the prototype's yard-games.js wasn't found)"); return; }
        Check(s.GetProperty("mute").GetBoolean(), "yard-games.js keeps its mute at localStorage 'yardgames.v1.mute'");
        var calls = s.GetProperty("calls");
        var jsNames = calls.EnumerateObject().Select(p => p.Name).ToList();
        Check(jsNames.Count == MenuSynth.Sounds.Count && jsNames.All(MenuSynth.Sounds.ContainsKey), "the same sound names: " + string.Join(",", jsNames));
        foreach (var p in calls.EnumerateObject())
        {
            var r = MenuSynth.Rendered(p.Name);
            if (r == null) continue;
            // the page passes no delay where C# passes 0 (Web Audio adds delay || 0)
            var js = p.Value.EnumerateArray().Select(x => string.Join(" ", x.GetString().Split(' ').Select(w => w == "u" ? "0" : w))).ToList();
            Check(js.SequenceEqual(r.Calls), $"{p.Name}: JS [{string.Join("; ", js)}] C# [{string.Join("; ", r.Calls)}]");
            Check(r.Out.Count > 0 && r.Out.All(v => !float.IsNaN(v) && Math.Abs(v) < 1), $"{p.Name}: rendered");
        }
        // against Chromium's own rendering (synth.mjs): the tones sample by sample, the noises by level and length
        var chromeFile = Path.Combine(OutDir, "synth-chrome.json");
        if (!File.Exists(chromeFile)) { Console.WriteLine("  (run synth.mjs for the comparison with Chromium's rendering)"); return; }
        foreach (var p in JsonDocument.Parse(File.ReadAllText(chromeFile)).RootElement.EnumerateObject())
        {
            var bytes = Convert.FromBase64String(p.Value.GetString());
            var c = new float[bytes.Length / 4];
            Buffer.BlockCopy(bytes, 0, c, 0, bytes.Length);
            var u = MenuSynth.Samples(p.Name);
            int n = Math.Max(c.Length, u.Length);
            double peak = c.Max(v => Math.Abs(v)), err = 0, ec = 0, eu = 0;
            int at = 0;
            for (int i = 0; i < n; i++)
            {
                double a = i < c.Length ? c[i] : 0, b = i < u.Length ? u[i] : 0;
                if (Math.Abs(a - b) > err) { err = Math.Abs(a - b); at = i; }
                ec += a * a;
                eu += b * b;
            }
            double rmsC = Math.Sqrt(ec / n), rmsU = Math.Sqrt(eu / n);
            bool noise = MenuSynth.HasNoise(p.Name);
            // the noise sounds: their level within 1.5 dB; tones: every sample within 0.1 % of the peak
            bool ok = noise ? Math.Abs(20 * Math.Log10(rmsU / rmsC)) < 1.5 : err <= 0.001 * peak;
            Check(ok, $"{p.Name} vs Chromium: max error {err:0.00000} (peak {peak:0.0000}), rms {rmsU:0.00000} vs {rmsC:0.00000}, length {u.Length} vs {c.Length}");
            Console.WriteLine($"  {p.Name,-7} {(noise ? "noise" : "tone ")}  peak {peak:0.0000}  max |Unity - Chromium| {err:0.00000} ({100 * err / peak:0.00} % of peak)  rms {rmsU:0.00000} / {rmsC:0.00000}  samples {u.Length} / {c.Length}  (worst at {at}: {(at < u.Length ? u[at] : 0):0.0000} / {(at < c.Length ? c[at] : 0):0.0000})");
        }
    }
}
