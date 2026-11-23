// A creature run live: the app's own rig code (rive-rig.js, rive-generic.js, the defs and move files, unchanged) in a
// JS engine inside Unity (PuerTS, V8 on Android), on the browser stand-in (tools/unity/rig/dom-shim.js) with the
// virtual clock, as tools/unity/rig/record.mjs runs it in Node. Every creature works (not only the recorded ones), and
// Play(move) plays any of its moves.
//
// The code comes from Resources/Rig (tools/unity/rig/bundle.mjs): scripts.bytes (dom-shim, live-host, the clock, the
// rig scripts, in order) and files.bytes (the creature art the rig fetches). One engine and one clock for every
// creature on screen; the clock moves once per Unity frame (16 ms steps, as the recordings), capped at 250 ms after a
// pause.
//
// Built only with the scripting define SQUISH_PUERTS (Player Settings → Scripting Define Symbols), once the PuerTS
// packages are in Packages/manifest.json (see UNITY_TODO.md); without it Rigs.For plays the recordings. V8 by default;
// SQUISH_PUERTS_QUICKJS as well picks QuickJS. Checked off Unity by tools/unity/rig/live-test (PuerTS on .NET).
#if SQUISH_PUERTS
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Puerts;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class LiveRig : IRigFrames, IDisposable
    {
        static ScriptEnv _env;
        static bool _failed;
        static Func<string, double> _mount;
        static Action<double, string> _play;
        static Action<double> _frame, _unmount;
        static Func<double, string> _svg;
        static int _lastFrame = -1;
        static double _jsMs, _t0 = -1;

        readonly double _id;
        string _last;
        bool _gone;

        LiveRig(double id) { _id = id; }

        /// <summary>The creature mounted in the engine, or null when the engine or the creature failed (the caller falls
        /// back to its recording).</summary>
        public static LiveRig Create(string key)
        {
            if (!Boot()) return null;
            try { return new LiveRig(_mount(key)); }
            catch (Exception e) { Debug.LogWarning("[LiveRig] mount " + key + ": " + e.Message); return null; }
        }

        static string Gunzip(string resource)
        {
            var asset = Resources.Load<TextAsset>(resource);
            if (asset == null) return null;
            using var gz = new GZipStream(new MemoryStream(asset.bytes), CompressionMode.Decompress);
            using var r = new StreamReader(gz, Encoding.UTF8);
            var text = r.ReadToEnd();
            Resources.UnloadAsset(asset);
            return text;
        }

        static bool Boot()
        {
            if (_env != null) return true;
            if (_failed) return false;
            try
            {
                var scripts = Gunzip("Rig/scripts") ?? throw new InvalidOperationException("Resources/Rig/scripts.bytes is missing: run node tools/unity/rig/bundle.mjs");
                var files = Gunzip("Rig/files") ?? "{}";
#if SQUISH_PUERTS_QUICKJS
                _env = new ScriptEnv(new BackendQuickJS());   // (the small engine: no JIT, a smaller app)
#else
                _env = new ScriptEnv(new BackendV8());
#endif
                foreach (var o in (IList<object>)Backend.Json.Parse(scripts))
                {
                    var pair = (IList<object>)o;
                    string name = (string)pair[0], code = (string)pair[1];
                    bool core = name == "dom-shim.js" || name == "live-host.js" || name == "virtual-clock.js";
                    try { _env.Eval(code, name); }
                    catch (Exception e)
                    {
                        if (core) throw;
                        Debug.LogWarning("[LiveRig] " + name + ": " + e.Message);   // (the app goes on without it too)
                    }
                    if (name == "live-host.js")
                    {
                        // the art the rig fetches, from the bundle (no network: the app's fetch of its own files)
                        _env.Eval("var __rigFiles = " + files + ";\n__live.install(function (p) { return Object.prototype.hasOwnProperty.call(__rigFiles, p) ? __rigFiles[p] : null; });", "install");
                    }
                }
                _mount = _env.Eval<Func<string, double>>("__live.mount", "mount");
                _play = _env.Eval<Action<double, string>>("__live.play", "play");
                _frame = _env.Eval<Action<double>>("__live.frame", "frame");
                _svg = _env.Eval<Func<double, string>>("__live.svg", "svg");
                _unmount = _env.Eval<Action<double>>("__live.unmount", "unmount");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogWarning("[LiveRig] the JS engine didn't start, playing the recordings: " + e);
                _failed = true;
                _env?.Dispose();
                _env = null;
                return false;
            }
        }

        // the one clock: up to now, in 16 ms steps, once per Unity frame
        static void Advance()
        {
            if (Time.frameCount == _lastFrame) return;
            _lastFrame = Time.frameCount;
            double now = Time.unscaledTimeAsDouble * 1000;
            if (_t0 < 0) _t0 = now;
            double target = now - _t0, dt = Math.Min(250, target - _jsMs);
            while (dt >= 16) { _frame(16); dt -= 16; }
            if (dt > 0) _frame(dt);
            _jsMs = target;
            _env.Tick();   // (the promises: the art arriving, the rig's own)
        }

        public string FrameAt(float seconds)
        {
            if (_gone || _env == null) return _last;
            try
            {
                Advance();
                var svg = _svg(_id);
                if (svg != null) _last = svg;
            }
            catch (Exception e) { Debug.LogWarning("[LiveRig] frame: " + e.Message); }
            return _last;
        }

        public void Play(string move)
        {
            if (_gone || _env == null) return;
            try { _play(_id, move); }
            catch (Exception e) { Debug.LogWarning("[LiveRig] play " + move + ": " + e.Message); }
        }

        public void Dispose()
        {
            if (_gone) return;
            _gone = true;
            try { if (_env != null) _unmount(_id); }
            catch (Exception) { /* the engine is going too */ }
        }
    }
}
#endif
