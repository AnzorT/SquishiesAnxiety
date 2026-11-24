// The Animated port's differential test, C# side: replays fixtures/*.json (written by fixtures.mjs from
// react-native-web's JS) through unity/Assets/Scripts/Anim and compares everything with tolerance 0:
// doubles bit for bit (NaN equals NaN), strings exactly, callbacks/listener calls in the same order, on the
// same frame, with the same {finished} and values.
//
//   node tools/unity/anim/fixtures.mjs && dotnet run -c Release --project tools/unity/anim [-- fixturesDir]
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using SquishSquad.Anim;

static class Program
{
    static long checks, mismatches;
    static readonly Dictionary<string, long[]> sections = new Dictionary<string, long[]>();
    static string section;
    static int shown;
    const int MaxShown = 40;

    static void Section(string name) { section = name; if (!sections.ContainsKey(name)) sections[name] = new long[2]; }
    static void Check(bool ok, Func<string> what)
    {
        checks++; sections[section][0]++;
        if (ok) return;
        mismatches++; sections[section][1]++;
        if (shown++ < MaxShown) Console.WriteLine("MISMATCH [" + section + "] " + what());
    }

    static bool Same(double a, double b)
    {
        if (double.IsNaN(a)) return double.IsNaN(b);
        return BitConverter.DoubleToInt64Bits(a) == BitConverter.DoubleToInt64Bits(b);
    }
    static string R(double d) { return d.ToString("R", System.Globalization.CultureInfo.InvariantCulture); }

    static bool IsNum(JsonElement e)
    {
        return e.ValueKind == JsonValueKind.Number || (e.ValueKind == JsonValueKind.String && e.GetString().StartsWith("~", StringComparison.Ordinal));
    }
    static double Num(JsonElement e)
    {
        if (e.ValueKind == JsonValueKind.Number) return e.GetDouble();
        switch (e.GetString())
        {
            case "~NaN": return double.NaN;
            case "~Inf": return double.PositiveInfinity;
            case "~-Inf": return double.NegativeInfinity;
            case "~-0": return -0.0;
        }
        throw new FormatException("not a number: " + e);
    }
    static double[] Nums(JsonElement a)
    {
        var r = new double[a.GetArrayLength()];
        int i = 0;
        foreach (var e in a.EnumerateArray()) r[i++] = Num(e);
        return r;
    }
    static bool Has(JsonElement o, string k, out JsonElement v) { return o.TryGetProperty(k, out v) && v.ValueKind != JsonValueKind.Undefined; }

    static JsonDocument Load(string dir, string name)
    {
        return JsonDocument.Parse(File.ReadAllBytes(Path.Combine(dir, name)), new JsonDocumentOptions { MaxDepth = 512 });
    }

    static int Main(string[] args)
    {
        string dir = args.Length > 0 ? args[0] : FindFixtures();
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Misc(dir);
        EasingCases(dir);
        InterpCases(dir);
        int nScen = 0; long nFrames = 0, nEvents = 0;
        for (int i = 0; File.Exists(Path.Combine(dir, "scenarios-" + i + ".json")); i++)
        {
            using (var doc = Load(dir, "scenarios-" + i + ".json"))
            {
                foreach (var sc in doc.RootElement.EnumerateArray())
                {
                    nScen++;
                    nFrames += sc.GetProperty("times").GetArrayLength() - 1;
                    nEvents += sc.GetProperty("events").GetArrayLength();
                    new ScenarioRun(sc).Run();
                }
            }
        }
        Allocations();
        Console.WriteLine();
        foreach (var kv in sections) Console.WriteLine($"  {kv.Key,-22} {kv.Value[0],10} checks  {kv.Value[1],6} mismatches");
        Console.WriteLine($"scenarios: {nScen}, frames: {nFrames}, JS callback/listener events: {nEvents}");
        Console.WriteLine($"TOTAL {checks} checks, {mismatches} mismatches (tolerance 0) in {sw.ElapsedMilliseconds} ms");
        return mismatches == 0 ? 0 : 1;
    }

    static string FindFixtures()
    {
        var d = new DirectoryInfo(AppContext.BaseDirectory);
        while (d != null && !File.Exists(Path.Combine(d.FullName, "AnimDiff.csproj"))) d = d.Parent;
        if (d == null) throw new DirectoryNotFoundException("run from tools/unity/anim or pass the fixtures dir");
        return Path.Combine(d.FullName, "fixtures");
    }

    // ------------------------------------------------------------ per-frame allocations
    // A running timing, spring and decay, a listener, a numeric interpolation and a '6deg' one read with
    // GetNumber: once started, a frame must allocate nothing (starting an animation does allocate).
    static void Allocations()
    {
        Section("no per-frame allocs");
        var ticker = new Ticker(1000);
        Ticker.Default = ticker;
        var a = new AnimatedValue(0);
        var b = new AnimatedValue(0);
        var c = new AnimatedValue(0);
        double sink = 0;
        a.AddListener(x => sink += x);
        var scale = a.Interpolate(new double[] { 0, 0.5, 1 }, new double[] { 1, 1.3, 1 }, Extrapolate.Clamp, Easing.Out(Easing.Quad));
        var rot = b.Interpolate(new double[] { 0, 1 }, new[] { "0deg", "6deg" });
        Animated.Parallel(
            Animated.Timing(a, new TimingConfig { ToValue = 1, Duration = 600000, Easing = Easing.Bezier(0.55, 0, 1, 0.45) }),
            Animated.Spring(b, new SpringConfig { ToValue = 1, Stiffness = 1, Damping = 0.001, Mass = 50 }),
            Animated.Decay(c, new DecayConfig { Velocity = 5, Deceleration = 0.99999 })).Start(r => sink += 1);
        double t = 1000;
        for (int i = 0; i < 200; i++) { t += 16.6; ticker.Tick(t); sink += scale.GetValue() + rot.GetNumber(0); }
        long before = GC.GetAllocatedBytesForCurrentThread();
        const int frames = 2000;
        for (int i = 0; i < frames; i++) { t += 16.6; ticker.Tick(t); sink += scale.GetValue() + rot.GetNumber(0); }
        long bytes = GC.GetAllocatedBytesForCurrentThread() - before;
        Check(bytes == 0 && a.IsAnimating && b.IsAnimating && c.IsAnimating, () => $"{bytes} bytes allocated over {frames} frames (still animating: {a.IsAnimating} {b.IsAnimating} {c.IsAnimating})");
        Console.WriteLine($"per-frame allocations: {bytes} bytes over {frames} frames of a running timing + spring + decay + listener + 2 interpolations ({sink > 0})");
        Ticker.Default = new Ticker();
    }

    // ------------------------------------------------------------ misc: math, String(number), colors, spring params
    static void Misc(string dir)
    {
        using (var doc = Load(dir, "misc.json"))
        {
            var root = doc.RootElement;
            Section("JsMath exp/sin/cos/pow");
            foreach (var row in root.GetProperty("math").EnumerateArray())
            {
                var r = Nums(row);
                double x = r[0], y = r[1];
                double[] got = { JsMath.Exp(x), JsMath.Sin(x), JsMath.Cos(x), JsMath.Pow(x, y), JsMath.Pow(Math.Abs(x), y) };
                string[] fn = { "exp", "sin", "cos", "pow", "pow|x|" };
                for (int k = 0; k < 5; k++)
                {
                    int kk = k;
                    Check(Same(got[k], r[2 + k]), () => $"{fn[kk]}({R(x)}, {R(y)}) = {R(got[kk])}, JS {R(r[2 + kk])}");
                }
            }
            Section("String(number)");
            foreach (var row in root.GetProperty("numbers").EnumerateArray())
            {
                double x = Num(row[0]);
                string want = row[1].GetString();
                string got = JsNumber.ToString(x);
                Check(got == want, () => $"String({R(x)}) = {got}, JS {want}");
            }
            Section("normalizeColor");
            foreach (var row in root.GetProperty("colors").EnumerateArray())
            {
                string s = row[0].GetString();
                uint? got = NormalizeColor.Normalize(s);
                uint? want = row[1].ValueKind == JsonValueKind.Null ? (uint?)null : (uint)row[1].GetDouble();
                Check(got == want, () => $"normalizeColor({s}) = {got}, JS {want}");
            }
            Section("spring config");
            foreach (var row in root.GetProperty("springParams").EnumerateArray())
            {
                var cfg = row.GetProperty("cfg");
                var sc = new SpringConfig { ToValue = 1 };
                SpringFields(cfg, sc);
                bool wantErr = Has(row, "error", out _);
                SpringAnimation a = null;
                bool gotErr = false;
                try { a = new SpringAnimation(sc); } catch (ArgumentException) { gotErr = true; }
                Check(gotErr == wantErr, () => $"spring {cfg} error {gotErr}, JS {wantErr}");
                if (!gotErr && !wantErr)
                {
                    double ws = Num(row.GetProperty("stiffness")), wd = Num(row.GetProperty("damping")), wm = Num(row.GetProperty("mass"));
                    Check(Same(a.Stiffness, ws) && Same(a.Damping, wd) && Same(a.Mass, wm),
                        () => $"spring {cfg}: k={R(a.Stiffness)} c={R(a.Damping)} m={R(a.Mass)}, JS k={R(ws)} c={R(wd)} m={R(wm)}");
                }
            }
        }
    }

    // ------------------------------------------------------------ easing
    public static Func<double, double> Ease(JsonElement spec)
    {
        if (spec.ValueKind == JsonValueKind.Null || spec.ValueKind == JsonValueKind.Undefined) return null;
        if (spec.ValueKind == JsonValueKind.String)
        {
            switch (spec.GetString())
            {
                case "linear": return Easing.Linear;
                case "ease": return Easing.Ease;
                case "quad": return Easing.Quad;
                case "cubic": return Easing.Cubic;
                case "sin": return Easing.Sin;
                case "circle": return Easing.Circle;
                case "exp": return Easing.Exp;
                case "bounce": return Easing.Bounce;
                case "step0": return Easing.Step0;
                case "step1": return Easing.Step1;
            }
            throw new ArgumentException("easing " + spec);
        }
        JsonElement v;
        switch (spec.GetProperty("f").GetString())
        {
            case "poly": return Easing.Poly(Num(spec.GetProperty("n")));
            case "elastic": return Has(spec, "b", out v) ? Easing.Elastic(Num(v)) : Easing.Elastic();
            case "back": return Has(spec, "s", out v) ? Easing.Back(Num(v)) : Easing.Back();
            case "bezier": { var p = Nums(spec.GetProperty("p")); return Easing.Bezier(p[0], p[1], p[2], p[3]); }
            case "in": return Easing.In(Ease(spec.GetProperty("e")));
            case "out": return Easing.Out(Ease(spec.GetProperty("e")));
            case "inOut": return Easing.InOut(Ease(spec.GetProperty("e")));
        }
        throw new ArgumentException("easing " + spec);
    }

    static void EasingCases(string dir)
    {
        using (var doc = Load(dir, "easing.json"))
        {
            var root = doc.RootElement;
            var xs = Nums(root.GetProperty("xs"));
            Section("Easing");
            foreach (var c in root.GetProperty("cases").EnumerateArray())
            {
                var spec = c.GetProperty("spec");
                var f = Ease(spec);
                var ys = Nums(c.GetProperty("ys"));
                for (int i = 0; i < xs.Length; i++)
                {
                    double got = f(xs[i]);
                    int ii = i;
                    Check(Same(got, ys[i]), () => $"{spec}({R(xs[ii])}) = {R(got)}, JS {R(ys[ii])}");
                }
            }
            foreach (var c in root.GetProperty("bezierErrors").EnumerateArray())
            {
                var p = Nums(c.GetProperty("p"));
                bool threw = false;
                try { Easing.Bezier(p[0], p[1], p[2], p[3]); } catch (ArgumentException) { threw = true; }
                bool want = c.GetProperty("threw").GetBoolean();
                Check(threw == want, () => $"bezier({string.Join(",", p)}) threw {threw}, JS {want}");
            }
        }
    }

    // ------------------------------------------------------------ interpolation
    public static InterpolationConfig InterpCfg(JsonElement cfg)
    {
        var c = new InterpolationConfig();
        JsonElement v;
        if (Has(cfg, "inputRange", out v)) c.InputRange = Nums(v);
        if (Has(cfg, "outputRange", out v))
        {
            bool strings = false;
            foreach (var e in v.EnumerateArray()) if (!IsNum(e)) strings = true;
            if (strings)
            {
                var s = new List<string>();
                foreach (var e in v.EnumerateArray()) s.Add(e.ValueKind == JsonValueKind.String ? e.GetString() : e.GetRawText());
                c.OutputRangeStrings = s.ToArray();
            }
            else c.OutputRange = Nums(v);
        }
        if (Has(cfg, "easing", out v)) c.Easing = Ease(v);
        if (Has(cfg, "extrapolate", out v)) c.Extrapolate = Ex(v.GetString());
        if (Has(cfg, "extrapolateLeft", out v)) c.ExtrapolateLeft = Ex(v.GetString());
        if (Has(cfg, "extrapolateRight", out v)) c.ExtrapolateRight = Ex(v.GetString());
        return c;
    }
    static Extrapolate Ex(string s)
    {
        switch (s) { case "clamp": return Extrapolate.Clamp; case "identity": return Extrapolate.Identity; default: return Extrapolate.Extend; }
    }

    // the numbers String(number) can print inside an interpolated string
    static readonly Regex PrintedNumber = new Regex(@"-?Infinity|NaN|[+-]?(?:\d+\.?\d*|\.\d+)(?:[eE][+-]?\d+)?", RegexOptions.ECMAScript);

    /// <summary>A node whose value is set directly, so inputs reach the interpolation unchanged (even -0), as the
    /// JS fixture calls the interpolation function directly. (AnimatedValue gives value + offset: -0 + 0 = +0.)</summary>
    sealed class RawNode : AnimatedNode { public double X; public override double GetValue() { return X; } }

    static void InterpCases(string dir)
    {
        using (var doc = Load(dir, "interp.json"))
        {
            var root = doc.RootElement;
            var xs = Nums(root.GetProperty("xs"));
            Section("interpolate");
            foreach (var c in root.GetProperty("cases").EnumerateArray())
            {
                var cfgJson = c.GetProperty("cfg");
                bool wantErr = Has(c, "error", out _);
                var value = new RawNode();
                AnimatedInterpolation interp = null;
                bool gotErr = false;
                try { interp = value.Interpolate(InterpCfg(cfgJson)); } catch (ArgumentException) { gotErr = true; }
                Check(gotErr == wantErr, () => $"interpolate {cfgJson}: error {gotErr}, JS {wantErr}");
                if (gotErr || wantErr) continue;
                var ys = c.GetProperty("ys");
                int i = 0;
                foreach (var y in ys.EnumerateArray())
                {
                    double x = xs[i++];
                    value.X = x;
                    if (interp.IsString)
                    {
                        string want = y.GetString();
                        string got = interp.GetString();
                        Check(got == want, () => $"interpolate {cfgJson} ({R(x)}) = {got}, JS {want}");
                        // the allocation-free per-number path gives the numbers the string prints
                        var ms = PrintedNumber.Matches(want);
                        bool ok = ms.Count == interp.ComponentCount;
                        for (int k = 0; ok && k < ms.Count; k++) ok = JsNumber.ToString(interp.GetNumber(k)) == ms[k].Value;
                        Check(ok, () => $"interpolate {cfgJson} ({R(x)}) GetNumber() differs from {want}");
                    }
                    else
                    {
                        double want = Num(y);
                        double got = interp.GetValue();
                        Check(Same(got, want), () => $"interpolate {cfgJson} ({R(x)}) = {R(got)}, JS {R(want)}");
                    }
                }
            }
        }
    }

    public static void SpringFields(JsonElement c, SpringConfig s)
    {
        JsonElement v;
        if (Has(c, "toValue", out v)) s.ToValue = Num(v);
        if (Has(c, "velocity", out v)) s.Velocity = Num(v);
        if (Has(c, "overshootClamping", out v)) s.OvershootClamping = v.GetBoolean();
        if (Has(c, "restDisplacementThreshold", out v)) s.RestDisplacementThreshold = Num(v);
        if (Has(c, "restSpeedThreshold", out v)) s.RestSpeedThreshold = Num(v);
        if (Has(c, "delay", out v)) s.Delay = Num(v);
        if (Has(c, "stiffness", out v)) s.Stiffness = Num(v);
        if (Has(c, "damping", out v)) s.Damping = Num(v);
        if (Has(c, "mass", out v)) s.Mass = Num(v);
        if (Has(c, "bounciness", out v)) s.Bounciness = Num(v);
        if (Has(c, "speed", out v)) s.Speed = Num(v);
        if (Has(c, "tension", out v)) s.Tension = Num(v);
        if (Has(c, "friction", out v)) s.Friction = Num(v);
        if (Has(c, "native", out v)) s.UseNativeDriver = v.GetBoolean();
    }

    // ------------------------------------------------------------ scenarios
    sealed class ScenarioRun
    {
        readonly JsonElement sc;
        readonly string name;
        readonly List<object[]> events = new List<object[]>();
        readonly List<object[]> samples = new List<object[]>();
        int frame;
        AnimatedValue[] values;
        AnimatedValueXY[] xys;
        readonly List<AnimatedNode> nodes = new List<AnimatedNode>();
        readonly List<CompositeAnimation> anims = new List<CompositeAnimation>();
        readonly List<int> listenerIds = new List<int>();
        Ticker ticker;

        public ScenarioRun(JsonElement sc) { this.sc = sc; name = sc.GetProperty("name").GetString(); }

        AnimatedNode Ref(JsonElement r)
        {
            JsonElement v;
            if (Has(r, "v", out v)) return values[v.GetInt32()];
            if (Has(r, "n", out v)) return nodes[v.GetInt32()];
            if (Has(r, "xy", out v)) { var p = xys[v.GetInt32()]; return r.GetProperty("axis").GetString() == "x" ? p.X : p.Y; }
            return Num(r.GetProperty("c")); // a constant becomes an AnimatedValue
        }

        Action<EndResult> EndCb(string cbName)
        {
            if (cbName == null) return null;
            return r =>
            {
                events.Add(new object[] { frame, "cb", cbName, r.Finished });
                JsonElement cbs, list;
                if (Has(sc, "cbs", out cbs) && Has(cbs, cbName, out list)) RunActions(list);
            };
        }
        static string Str(JsonElement o, string k) { JsonElement v; return Has(o, k, out v) && v.ValueKind == JsonValueKind.String ? v.GetString() : null; }

        TimingConfig TimingCfg(JsonElement c)
        {
            var t = new TimingConfig();
            JsonElement v;
            if (Has(c, "toValue", out v)) t.ToValue = Num(v);
            if (Has(c, "easing", out v)) t.Easing = Ease(v);
            if (Has(c, "duration", out v)) t.Duration = Num(v);
            if (Has(c, "delay", out v)) t.Delay = Num(v);
            if (Has(c, "native", out v)) t.UseNativeDriver = v.GetBoolean();
            t.OnComplete = EndCb(Str(c, "onComplete"));
            return t;
        }
        SpringConfig SpringCfg(JsonElement c)
        {
            var s = new SpringConfig();
            SpringFields(c, s);
            s.OnComplete = EndCb(Str(c, "onComplete"));
            return s;
        }
        DecayConfig DecayCfg(JsonElement c)
        {
            var d = new DecayConfig();
            JsonElement v;
            if (Has(c, "velocity", out v)) d.Velocity = Num(v);
            if (Has(c, "deceleration", out v)) d.Deceleration = Num(v);
            d.OnComplete = EndCb(Str(c, "onComplete"));
            return d;
        }

        CompositeAnimation Build(JsonElement spec)
        {
            if (spec.ValueKind == JsonValueKind.Null) return null;
            JsonElement v;
            if (Has(spec, "ref", out v)) return anims[v.GetInt32()];
            string t = spec.GetProperty("t").GetString();
            var items = new List<CompositeAnimation>();
            if (Has(spec, "items", out v)) foreach (var e in v.EnumerateArray()) items.Add(Build(e));
            switch (t)
            {
                case "timing":
                case "spring":
                case "decay":
                {
                    var c = spec.GetProperty("cfg");
                    if (Has(spec, "xy", out v))
                    {
                        var p = xys[v.GetInt32()];
                        if (t == "timing") return Animated.Timing(p, Num(c.GetProperty("toX")), Num(c.GetProperty("toY")), TimingCfg(c));
                        JsonElement vx, vy;
                        double? velX = Has(c, "velocityX", out vx) ? Num(vx) : (double?)null;
                        double? velY = Has(c, "velocityY", out vy) ? Num(vy) : (double?)null;
                        return Animated.Spring(p, Num(c.GetProperty("toX")), Num(c.GetProperty("toY")), SpringCfg(c), velX, velY);
                    }
                    var target = values[spec.GetProperty("v").GetInt32()];
                    if (t == "timing") return Animated.Timing(target, TimingCfg(c));
                    if (t == "spring") return Animated.Spring(target, SpringCfg(c));
                    return Animated.Decay(target, DecayCfg(c));
                }
                case "seq": return Animated.Sequence(items);
                case "par":
                    return Has(spec, "stopTogether", out v) ? Animated.Parallel(items, v.GetBoolean()) : Animated.Parallel(items);
                case "stagger": return Animated.Stagger(Num(spec.GetProperty("time")), items);
                case "loop":
                {
                    int iterations = Has(spec, "iterations", out v) ? v.GetInt32() : -1;
                    bool reset = Has(spec, "resetBeforeIteration", out v) ? v.GetBoolean() : true;
                    return Animated.Loop(Build(spec.GetProperty("item")), iterations, reset);
                }
                case "delay": return Animated.Delay(Num(spec.GetProperty("time")));
            }
            throw new ArgumentException("anim " + spec);
        }

        void Act(JsonElement a)
        {
            string cb = Str(a, "cb");
            switch (a.GetProperty("do").GetString())
            {
                case "start": anims[a.GetProperty("a").GetInt32()].Start(EndCb(cb)); break;
                case "stop": anims[a.GetProperty("a").GetInt32()].Stop(); break;
                case "reset": anims[a.GetProperty("a").GetInt32()].Reset(); break;
                case "set": values[a.GetProperty("v").GetInt32()].SetValue(Num(a.GetProperty("x"))); break;
                case "stopAnim":
                    values[a.GetProperty("v").GetInt32()].StopAnimation(cb == null ? null : (Action<double>)(x => events.Add(new object[] { frame, "val", cb, x })));
                    break;
                case "resetAnim":
                    values[a.GetProperty("v").GetInt32()].ResetAnimation(cb == null ? null : (Action<double>)(x => events.Add(new object[] { frame, "val", cb, x })));
                    break;
                case "offset": values[a.GetProperty("v").GetInt32()].SetOffset(Num(a.GetProperty("x"))); break;
                case "flatten": values[a.GetProperty("v").GetInt32()].FlattenOffset(); break;
                case "extract": values[a.GetProperty("v").GetInt32()].ExtractOffset(); break;
                case "setXY": xys[a.GetProperty("xy").GetInt32()].SetValue(Num(a.GetProperty("x")), Num(a.GetProperty("y"))); break;
                case "stopXY":
                    xys[a.GetProperty("xy").GetInt32()].StopAnimation(cb == null ? null : (Action<XY>)(p => events.Add(new object[] { frame, "xy", cb, p.X, p.Y })));
                    break;
                case "unlisten":
                {
                    int l = a.GetProperty("l").GetInt32();
                    values[sc.GetProperty("listeners")[l].GetProperty("v").GetInt32()].RemoveListener(listenerIds[l]);
                    break;
                }
                default: throw new ArgumentException("action " + a);
            }
        }

        void RunActions(JsonElement list)
        {
            if (list.ValueKind != JsonValueKind.Array) return;
            foreach (var a in list.EnumerateArray())
            {
                try { Act(a); }
                catch (Exception) { events.Add(new object[] { frame, "err", "action" }); }
            }
        }

        void Sample()
        {
            var s = new List<object>();
            foreach (var v in values) s.Add(v.GetValue());
            foreach (var p in xys) { s.Add(p.X.GetValue()); s.Add(p.Y.GetValue()); }
            foreach (var n in nodes)
            {
                try
                {
                    var ip = n as AnimatedInterpolation;
                    if (ip != null && ip.IsString) s.Add(ip.GetString());
                    else s.Add(n.GetValue());
                }
                catch (InvalidOperationException) { s.Add("!"); }
            }
            samples.Add(s.ToArray());
        }

        public void Run()
        {
            var times = Nums(sc.GetProperty("times"));
            ticker = new Ticker(times[0]);
            Ticker.Default = ticker;
            ticker.Error += e => events.Add(new object[] { frame, "err", "frame" });

            JsonElement v;
            var vs = new List<AnimatedValue>();
            foreach (var e in sc.GetProperty("values").EnumerateArray()) vs.Add(new AnimatedValue(Num(e)));
            values = vs.ToArray();
            var ps = new List<AnimatedValueXY>();
            if (Has(sc, "xys", out v)) foreach (var e in v.EnumerateArray()) ps.Add(new AnimatedValueXY(Num(e[0]), Num(e[1])));
            xys = ps.ToArray();
            if (Has(sc, "nodes", out v))
            {
                foreach (var n in v.EnumerateArray())
                {
                    switch (n.GetProperty("k").GetString())
                    {
                        case "interp": nodes.Add(Ref(n.GetProperty("of")).Interpolate(InterpCfg(n.GetProperty("cfg")))); break;
                        case "add": nodes.Add(Animated.Add(Ref(n.GetProperty("a")), Ref(n.GetProperty("b")))); break;
                        case "sub": nodes.Add(Animated.Subtract(Ref(n.GetProperty("a")), Ref(n.GetProperty("b")))); break;
                        case "mul": nodes.Add(Animated.Multiply(Ref(n.GetProperty("a")), Ref(n.GetProperty("b")))); break;
                        case "div": nodes.Add(Animated.Divide(Ref(n.GetProperty("a")), Ref(n.GetProperty("b")))); break;
                        case "mod": nodes.Add(Animated.Modulo(Ref(n.GetProperty("a")), Num(n.GetProperty("m")))); break;
                        case "diffclamp": nodes.Add(Animated.DiffClamp(Ref(n.GetProperty("a")), Num(n.GetProperty("min")), Num(n.GetProperty("max")))); break;
                    }
                }
            }
            foreach (var spec in sc.GetProperty("anims").EnumerateArray()) anims.Add(Build(spec));
            if (Has(sc, "listeners", out v))
            {
                int idx = 0;
                foreach (var l in v.EnumerateArray())
                {
                    int myIdx = idx++;
                    bool fired = false;
                    JsonElement when;
                    bool hasWhen = Has(l, "when", out when);
                    listenerIds.Add(values[l.GetProperty("v").GetInt32()].AddListener(x =>
                    {
                        events.Add(new object[] { frame, "L", myIdx, x });
                        if (!hasWhen) return;
                        bool once = when.GetProperty("once").GetBoolean();
                        double thr = Num(when.GetProperty("x"));
                        bool cond = when.GetProperty("op").GetString() == "ge" ? x >= thr : x <= thr;
                        if (!(once && fired) && cond) { fired = true; RunActions(when.GetProperty("actions")); }
                    }));
                }
            }

            var byFrame = new Dictionary<int, List<JsonElement>>();
            foreach (var a in sc.GetProperty("actions").EnumerateArray())
            {
                int f = a.GetProperty("f").GetInt32();
                if (!byFrame.ContainsKey(f)) byFrame[f] = new List<JsonElement>();
                byFrame[f].Add(a);
            }
            void Frame(int f)
            {
                List<JsonElement> list;
                if (!byFrame.TryGetValue(f, out list)) return;
                foreach (var a in list)
                {
                    try { Act(a); }
                    catch (Exception) { events.Add(new object[] { frame, "err", "action" }); }
                }
            }

            frame = 0;
            Frame(0);
            Sample();
            for (frame = 1; frame < times.Length; frame++)
            {
                ticker.Tick(times[frame]);
                Frame(frame);
                Sample();
            }
            frame = times.Length - 1;
            Compare();
            Ticker.Default = new Ticker();
        }

        void Compare()
        {
            Section("scenario values");
            var js = sc.GetProperty("samples");
            Check(js.GetArrayLength() == samples.Count, () => $"{name}: {samples.Count} frames sampled, JS {js.GetArrayLength()}");
            int f = 0;
            foreach (var row in js.EnumerateArray())
            {
                if (f >= samples.Count) break;
                var mine = samples[f];
                int ff = f;
                Check(row.GetArrayLength() == mine.Length, () => $"{name} frame {ff}: {mine.Length} samples, JS {row.GetArrayLength()}");
                int i = 0;
                foreach (var e in row.EnumerateArray())
                {
                    if (i >= mine.Length) break;
                    object m = mine[i];
                    int ii = i;
                    if (m is string ms) Check(e.ValueKind == JsonValueKind.String && e.GetString() == ms, () => $"{name} frame {ff} sample {ii}: {ms}, JS {e}");
                    else
                    {
                        double d = (double)m;
                        Check(IsNum(e) && Same(d, Num(e)), () => $"{name} frame {ff} (t={R(Nums(sc.GetProperty("times"))[ff])}) sample {ii}: {R(d)}, JS {e}");
                    }
                    i++;
                }
                f++;
            }

            Section("scenario callbacks");
            var jev = sc.GetProperty("events");
            Check(jev.GetArrayLength() == events.Count, () => $"{name}: {events.Count} events, JS {jev.GetArrayLength()}: first difference at {FirstEventDiff(jev)}");
            int k = 0;
            foreach (var e in jev.EnumerateArray())
            {
                if (k >= events.Count) break;
                var mine = events[k];
                int kk = k;
                Check(EventEq(e, mine), () => $"{name} event {kk}: {Fmt(mine)}, JS {e}");
                k++;
            }
            Check(sc.GetProperty("idle").GetBoolean() == ticker.IsIdle, () => $"{name}: idle at end {ticker.IsIdle}, JS {sc.GetProperty("idle")}");
        }

        string FirstEventDiff(JsonElement jev)
        {
            int k = 0;
            foreach (var e in jev.EnumerateArray())
            {
                if (k >= events.Count) return "#" + k + " JS " + e + ", C# (none)";
                if (!EventEq(e, events[k])) return "#" + k + " JS " + e + ", C# " + Fmt(events[k]);
                k++;
            }
            return k < events.Count ? "#" + k + " C# " + Fmt(events[k]) + ", JS (none)" : "-";
        }

        static string Fmt(object[] ev)
        {
            var parts = new List<string>();
            foreach (var o in ev) parts.Add(o is double d ? R(d) : o is bool b ? (b ? "true" : "false") : o is string s ? "\"" + s + "\"" : o.ToString());
            return "[" + string.Join(",", parts) + "]";
        }

        static bool EventEq(JsonElement e, object[] mine)
        {
            if (e.GetArrayLength() != mine.Length) return false;
            int i = 0;
            foreach (var x in e.EnumerateArray())
            {
                object m = mine[i++];
                switch (m)
                {
                    case int n: if (x.ValueKind != JsonValueKind.Number || x.GetInt32() != n) return false; break;
                    case bool b: if ((x.ValueKind == JsonValueKind.True) != b || (x.ValueKind != JsonValueKind.True && x.ValueKind != JsonValueKind.False)) return false; break;
                    case string s: if (x.ValueKind != JsonValueKind.String || x.GetString() != s) return false; break;
                    case double d: if (!IsNum(x) || !Same(d, Num(x))) return false; break;
                    default: return false;
                }
            }
            return true;
        }
    }
}
