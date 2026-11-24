// A creature animated natively: the app's own rig code (rive-rig.js, rive-generic.js, the defs and move files, with
// the browser stand-in it runs on), compiled to C# by tools/unity/rig/jsc.mjs (Creatures/Js, Creatures/Js/Gen) and run
// in Unity as it runs in the app's page: every creature, every move, the same frames (tools/unity/rig-test checks them
// against the JS, markup for markup). No JS engine, no recordings.
//
// One clock for every creature on screen (the page's virtual clock: performance.now, timers, requestAnimationFrame),
// moved once per Unity frame in 16 ms steps (as the recordings were made), at most 250 ms after a pause. The creature
// art the rig fetches (the Tripo creatures' outlines) comes from Resources/Rig/files.bytes (tools/unity/rig/bundle.mjs).
// Each frame is the creature's <svg> markup, as CreatureView draws it.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using SquishSquad.Creatures.Js;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class NativeRig : IRigFrames, IHouseRig, IDisposable
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
            if (_boot != null || RigHost.Booted) return;
            LoadFiles();
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

        // the files the rig fetch()es, from the bundle (no network: the app's fetch of its own files)
        static string ReadFile(string path)
        {
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

        // the one clock: up to now, in 16 ms steps, once per Unity frame
        static void Advance()
        {
            if (Time.frameCount == _lastFrame) return;
            _lastFrame = Time.frameCount;
            LastFrameMs = _spent; _spent = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            double now = Time.unscaledTimeAsDouble * 1000;
            if (_t0 < 0) _t0 = now;
            double target = now - _t0, dt = Math.Min(250, target - _clockMs);
            try
            {
                while (dt >= 16) { RigHost.Frame(16); dt -= 16; _clockMs += 16; }
            }
            catch (Exception e) { Debug.LogWarning("[NativeRig] frame: " + e.Message); }
            if (target - _clockMs > 250) _clockMs = target - 16;   // (after a pause: no catching up)
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

        internal int Id => _id;

        public void Dispose()
        {
            if (_gone) return;
            _gone = true;
            try { RigHost.Unmount(_id); } catch (Exception) { /* as the app */ }
        }
    }
}
