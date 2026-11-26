// A creature animated natively: the app's own rig code (rive-rig.js, rive-generic.js, the defs and move files, with
// the browser stand-in it runs on), compiled to C# by tools/unity/rig/jsc.mjs (Creatures/Js, Creatures/Js/Gen) and run
// in Unity as it runs in the app's page: every creature, every move, the same frames (tools/unity/rig-test checks them
// against the JS, markup for markup). No JS engine, no recordings.
//
// One clock for every creature on screen (the page's virtual clock: performance.now, timers, requestAnimationFrame),
// moved by one step per Unity frame: the time since the last, at least 12 ms and at most 50 ms. The creature
// art the rig fetches (the Tripo creatures' outlines) comes from Resources/Rig/files.bytes (tools/unity/rig/bundle.mjs).
// Each frame is the creature's node tree, read straight from the rig's elements (RigTree: no SVG text), which
// CreatureView compiles and draws; FrameAt still gives the markup (the result card's first measure, the tests).
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using SquishSquad.Creatures.Js;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class NativeRig : IRigFrames, IRigTree, IHouseRig, IDisposable
    {
        static bool _failed;
        static JsObject _files;
        static int _lastFrame = -1;
        static double _clockMs, _t0 = -1;
        /// <summary>The time the rig took last Unity frame (ms): its clock step and every creature's markup.</summary>
        public static double LastFrameMs { get; private set; }
        static double _spent;

        readonly int _id;
        readonly string _key;
        string _last;
        bool _gone;

        NativeRig(int id, string key) { _id = id; _key = key; }
        public string Key => _key;

        /// <summary>Whether the rig runs (its scripts run once: waits for them if they're still running).</summary>
        public static bool Ready() => Boot();

        // the scripts run once, on a worker thread as the app starts (they take a moment: the house and the menu need
        // the rig at once); Boot waits for it. Nothing else touches the rig until it's done.
        static System.Threading.Thread _boot;
        static bool _bootOk;
        static long _bootMs;
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Prewarm()
        {
            // the house's runtime drawings (House/HouseDraw.cs): the house's scripts are in the same compiled realm; the
            // first call waits for the boot
            SquishSquad.House.HouseDraw.Eval ??= js => Boot() ? RigHost.HouseEval(js) : null;
            RigHost.HouseError ??= (n, e) => Debug.LogWarning("[HouseDraw] " + n + ": " + (e is JsThrow ? e.Message : e.ToString()));
            if (_boot != null || RigHost.Booted) return;
            LoadFiles();
            // the yard games' saved bests, for the realm's localStorage (tools/unity/rig/yard-host.js reads them as a file
            // before yard-games.js does); PlayerPrefs only answers on this thread
            try { _yardSave = PlayerPrefs.GetString("yardgames.v1", null); } catch (Exception) { _yardSave = null; }
            _boot = new System.Threading.Thread(() =>
            {
                var t = System.Diagnostics.Stopwatch.StartNew();
                try { _bootOk = RigHost.Boot(ReadFile); } catch (Exception) { _bootOk = false; }
                _bootMs = t.ElapsedMilliseconds;
            }, 16 << 20) { IsBackground = true, Name = "rig boot" };
            _boot.Start();
        }

        static bool Boot()
        {
            if (_failed) return false;
            if (_boot == null) Prewarm();
            if (_boot != null)
            {
                _boot.Join();
                _boot = null;
                Rt.OnHostError = e => Debug.LogWarning("[NativeRig] " + e);
                foreach (var e in RigHost.BootErrors) Debug.LogWarning("[NativeRig] " + e);
                if (!_bootOk) { _failed = true; Debug.LogWarning("[NativeRig] the rig didn't start: playing the recordings"); return false; }
                Debug.Log($"[NativeRig] the rig's scripts ran in {_bootMs} ms");
                FrameDrivers();
            }
            return RigHost.Booted;
        }

        static byte[] _filesGz;
        static void LoadFiles()
        {
            if (_filesGz != null || _files != null) return;
            var asset = Resources.Load<TextAsset>("Rig/files");
            _filesGz = asset != null ? asset.bytes : Array.Empty<byte>();
            if (asset != null) Resources.UnloadAsset(asset);
        }

        static string _yardSave;

        // the files the rig fetch()es, from the bundle (no network: the app's fetch of its own files)
        static string ReadFile(string path)
        {
            if (path == "local/yardgames.v1") return _yardSave;
            if (_files == null)
            {
                string json = "{}";
                if (_filesGz != null && _filesGz.Length > 0)
                {
                    using (var gz = new GZipStream(new MemoryStream(_filesGz), CompressionMode.Decompress))
                    using (var r = new StreamReader(gz, Encoding.UTF8)) json = r.ReadToEnd();
                }
                _files = Rt.Invoke(Rt.G("JSON"), "parse", json).O as JsObject ?? Rt.NewObj(0);
                _filesGz = null;
            }
            return _files.GetOwn(path, out var v) && v.O is string s ? s : null;
        }

        /// <summary>The creature mounted on the rig, or null when the rig can't run (the caller falls back).</summary>
        public static NativeRig Create(string key)
        {
            if (string.IsNullOrEmpty(key) || !Boot()) return null;
            LoadFiles();
            try { return new NativeRig(RigHost.Mount(key), key); }
            catch (Exception e) { Debug.LogWarning("[NativeRig] mount " + key + ": " + e.Message); return null; }
        }

        /// <summary>Moves the one clock to now (at most once a Unity frame): what runs on it without a creature on screen
        /// asking for its frame (the yard games' loop: Games/Yard/YardJs). False when the rig can't run.</summary>
        public static bool Tick()
        {
            if (!Boot()) return false;
            Advance();
            return true;
        }

        // the one clock: one step per Unity frame, as a browser's requestAnimationFrame: the time since the last step, at
        // least MinStep, at most MaxStep (the rig clamps its own steps at 50 ms too), the rest dropped. It used to catch
        // up in 16 ms steps (up to 250 ms): once a frame took longer than its steps, the next ran more of them and was
        // slower still (the Editor, Hop's result card: 15 steps a frame, 4 fps). MinStep 12, not 16: Unity's frame times
        // wobble about 16.7 ms at 60 Hz, and a frame at 15.9 got no step and the next a double one, a hitch in the
        // fastest moves (the hopper's jump); at 12 every 60 Hz frame steps, and 90 / 120 / 144 Hz step every other frame
        // (22 / 16.7 / 13.9 ms, evenly).
        const double MinStep = 12, MaxStep = 50;

        // In play mode the step runs on the rig thread while Unity draws: early in LateUpdate (RigFrameBegin) every
        // creature on screen reads its frame, the step is posted, the views draw what they read, and the main thread
        // waits for the step at the end of LateUpdate (RigFrameEnd), so the realm is idle again for the next frame's
        // Update (the games' calls, the stage's reads). What's drawn is the frame before the step: one frame behind.
        static GameObject _frames;
        static double _due;
        static long _stepTicks;
        static void FrameDrivers()
        {
            if (_frames != null || !Application.isPlaying) return;
            _frames = new GameObject("rig frame");
            UnityEngine.Object.DontDestroyOnLoad(_frames);
            _frames.AddComponent<RigFrameBegin>();
            _frames.AddComponent<RigFrameEnd>();
            RigThread.PostError ??= e => Debug.LogWarning("[NativeRig] frame: " + e.Message);
        }

        internal static void FrameBegin()
        {
            if (_failed || !RigHost.Booted) return;
            Advance();
            long t0 = SquishSquad.App.PerfLog.Mark();
            var views = CreatureView.Live;
            for (int i = 0; i < views.Count; i++) views[i].Prefetch();
            SquishSquad.App.PerfLog.Add("creature frames read", t0);
            if (_due <= 0) return;
            double step = _due; _due = 0;
            RigThread.Post(() =>
            {
                long a = System.Diagnostics.Stopwatch.GetTimestamp();
                RigHost.Frame(step);
                _stepTicks = System.Diagnostics.Stopwatch.GetTimestamp() - a;
            });
        }

        internal static void FrameEnd()
        {
            if (!RigThread.Pending) return;
            long t0 = SquishSquad.App.PerfLog.Mark();
            RigThread.Wait();
            SquishSquad.App.PerfLog.Add("waiting for the step", t0);
            SquishSquad.App.PerfLog.AddMs("rig step (its thread)", _stepTicks * 1000.0 / System.Diagnostics.Stopwatch.Frequency);
        }

        static void Advance()
        {
            if (Time.frameCount == _lastFrame) return;
            _lastFrame = Time.frameCount;
            LastFrameMs = _spent; _spent = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            double now = Time.unscaledTimeAsDouble * 1000;
            if (_t0 < 0) _t0 = now;
            double target = now - _t0, dt = target - _clockMs;
            if (dt >= MinStep)
            {
                double step = Math.Min(dt, MaxStep);
                if (_frames != null) _due = Math.Min(MaxStep, _due + step);   // FrameBegin posts it, once the frames are read
                else
                {
                    try { RigThread.Run(() => RigHost.Frame(step)); }
                    catch (Exception e) { Debug.LogWarning("[NativeRig] frame: " + e.Message); }
                }
                _clockMs = step < dt ? target : _clockMs + step;   // (behind: no catching up)
            }
            _spent += sw.Elapsed.TotalMilliseconds;
        }

        public string FrameAt(float seconds)
        {
            if (_gone) return _last;
            try
            {
                Advance();
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var svg = RigHost.Svg(_id);
                _spent += sw.Elapsed.TotalMilliseconds;
                if (svg != null) _last = svg;
            }
            catch (Exception e) { Debug.LogWarning("[NativeRig] frame: " + e.Message); }
            return _last;
        }

        /// <summary>The frame as the vector code's node tree, straight from the rig (no markup): what CreatureView draws.</summary>
        public SquishSquad.Vector.SvgNode TreeAt(float seconds)
        {
            if (_gone) return null;
            try
            {
                Advance();
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var tree = _tree ??= new RigTree();
                var t = RigThread.Run(() => tree.Build(RigHost.SvgElement(_id)));
                _spent += sw.Elapsed.TotalMilliseconds;
                return t;
            }
            catch (Exception e) { Debug.LogWarning("[NativeRig] frame: " + e.Message); return null; }
        }
        RigTree _tree;

        public void Play(string move)
        {
            if (_gone) return;
            try { RigHost.Play(_id, move); }
            catch (Exception e) { Debug.LogWarning("[NativeRig] play " + move + ": " + e.Message); }
        }

        /// <summary>The walk's / the result card's channels for this frame (rive-rig's ext, replacing the last ones).</summary>
        public void Ext(IDictionary<string, double> e) { if (!_gone) try { RigHost.Ext(_id, e); } catch (Exception ex) { Debug.LogWarning("[NativeRig] ext: " + ex.Message); } }
        /// <summary>Turns the creature (degrees: 0 faces you, 180 away, 90 right): the rig's spinOff.</summary>
        public void Yaw(double deg) { if (!_gone) try { RigHost.Yaw(_id, deg); } catch (Exception) { } }
        /// <summary>The rig's idle fidgets on (standing free in the house) or off.</summary>
        public void Fidgets(bool on) { if (!_gone) try { RigHost.Fidgets(_id, on); } catch (Exception) { } }
        /// <summary>Whether the rig is in one of its idle fidgets now (the house's fidg).</summary>
        public bool InFidget() { try { return !_gone && RigHost.InFidget(_id); } catch (Exception) { return false; } }
        /// <summary>The states the rig went into since the last call (the house's onRig).</summary>
        public string[] Events() { try { return _gone ? Array.Empty<string>() : RigHost.Events(_id); } catch (Exception) { return Array.Empty<string>(); } }

        /// <summary>tools/rig/walk.html's step: the Squad House's walk on the rig, `w` its weight, `spin` the way it goes.</summary>
        public void WalkStep(double w, double dt, double spin) { if (!_gone) try { RigHost.Native("walkStep", _id, _key, w, dt, spin); } catch (Exception) { } }
        /// <summary>A particle burst (tools/rig/result.html burst()): at the rig's own spot `at` (eyeL...) or at x, y.</summary>
        public void Emit(string kind, string at, double x, double y, int n) { if (!_gone) try { RigHost.Native("emit", _id, kind, at != null ? (V)at : V.Null, x, y, n); } catch (Exception) { } }
        /// <summary>The menu's walk to the Game Park and back (menu.js enterPark / leavePark): started, then each frame.</summary>
        public void ParkStart(bool enter) { if (!_gone) try { RigHost.Native("parkStart", _id, _key, enter); } catch (Exception) { } }
        public void ParkStep(double ms) { if (!_gone) try { RigHost.Native("parkStep", _id, ms); } catch (Exception) { } }
        /// <summary>A pointer on the creature (x, y in its 0-100 box): what the page's touch does to the rig (a poke, a squeeze).</summary>
        public void Pointer(string type, double x, double y) { if (!_gone) try { RigHost.Native("pointer", _id, type, x, y); } catch (Exception) { } }
        /// <summary>The intro's squish (intro.js): the rig squeezes at once, as a held press (it lets go on the pointer up).</summary>
        public void Press() { if (!_gone) try { RigHost.Native("press", _id); } catch (Exception) { } }
        /// <summary>The rig's light (rive-rig ctl.light: the scene's, as JSON; null for its own).</summary>
        public void Light(string json) { if (!_gone) try { RigHost.Native("light", _id, json != null ? (V)json : V.Null); } catch (Exception) { } }
        /// <summary>A border look of its own (0-4) whatever config/roster says (RigLooks): the yard posters' 3.</summary>
        public void Look(int n) { if (!_gone) try { RigHost.Native("look", _id, n); } catch (Exception) { } }

        internal int Id => _id;

        public void Dispose()
        {
            if (_gone) return;
            _gone = true;
            try { RigHost.Unmount(_id); } catch (Exception) { /* as the app */ }
        }
    }
}
