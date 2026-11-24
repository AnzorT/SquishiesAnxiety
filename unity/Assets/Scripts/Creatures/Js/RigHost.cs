// The compiled rig's host side (Unity-free: Creatures/NativeRig.cs uses it in the app, tools/unity/rig-test off it):
// runs the compiled scripts once in the page's order (Gen/Scripts.cs), the browser stand-in installed after
// live-host.js with the creature art it fetches, then drives creatures through live-host.js's __live (mount, play,
// ext, frame, svg...), as Creatures/LiveRig.cs drove the JS engine. One clock for every creature.
using System;
using System.Collections.Generic;

namespace SquishSquad.Creatures.Js
{
    public static class RigHost
    {
        static bool _booted, _failed;
        static V _live;
        /// <summary>Script errors at boot (the app goes on without a script that throws, as the page does).</summary>
        public static readonly List<string> BootErrors = new List<string>();

        /// <summary>Runs the scripts (once). readFile: the files the rig fetch()es (a creature's art), null when missing.</summary>
        public static bool Boot(Func<string, string> readFile)
        {
            if (_booted) return true;
            if (_failed) return false;
            try
            {
                foreach (var (name, run) in Gen.Scripts.All)
                {
                    bool core = name == "dom-shim.js" || name == "live-host.js" || name == "virtual-clock.js" || name == "native-host.js";
                    try { run(); }
                    catch (Exception e)
                    {
                        if (core) throw;
                        BootErrors.Add(name + ": " + e.Message);
                    }
                    Rt.RunMicrotasks();
                    if (name == "live-host.js")
                    {
                        _live = Rt.G("__live");
                        var rf = Rt.Fn((s, n, a, b, c, d, r) => { string t = null; try { t = readFile?.Invoke(Rt.ToStr(a)); } catch (Exception) { } return t; }, 1, "readFile", false);
                        Rt.Invoke(_live, "install", rf);
                    }
                }
                _booted = true;
                return true;
            }
            catch (Exception e)
            {
                BootErrors.Add("boot: " + e);
                _failed = true;
                return false;
            }
        }
        public static bool Booted => _booted;

        public static V Live => _live;
        public static int Mount(string key) { var id = Rt.Invoke(_live, "mount", key); Rt.RunMicrotasks(); return (int)Rt.ToNum(id); }
        public static void Play(int id, string move) { Rt.Invoke(_live, "play", id, move); Rt.RunMicrotasks(); }
        /// <summary>The one clock: `ms` on (timers due fire in order, then the frame's callbacks), then the promise jobs.</summary>
        public static void Frame(double ms) { Rt.Invoke(_live, "frame", ms); Rt.RunMicrotasks(); }
        public static double Now => Rt.ToNum(Rt.Invoke(_live, "now"));
        /// <summary>The creature's &lt;svg&gt; markup now, as live-host.js's svg(id) gives it (the fabric tile as
        /// href="grain", one line), written natively (run.mjs checks it against the JS).</summary>
        public static string Svg(int id)
        {
            var el = Rt.Invoke(Rt.G("__native"), "host", id);
            if (el.IsNullish) return null;
            var svg = Dom.FirstSvg(el);
            if (svg.IsNullish) return null;
            var s = Dom.Serialize(svg);
            if (s.IndexOf("shim-canvas:", StringComparison.Ordinal) >= 0) s = Canvas.Replace(s, "href=\"grain\"");
            return s.Replace('\n', ' ');
        }
        static readonly System.Text.RegularExpressions.Regex Canvas = new System.Text.RegularExpressions.Regex("href=\"shim-canvas:[^\"]*\"");
        public static void Unmount(int id) { Rt.Invoke(_live, "unmount", id); Rt.RunMicrotasks(); }
        public static void Yaw(int id, double deg) => Rt.Invoke(_live, "yaw", id, deg);
        public static void Fidgets(int id, bool on) => Rt.Invoke(_live, "fidgets", id, on);
        public static bool InFidget(int id) => Rt.Truthy(Rt.Invoke(_live, "fidg", id));
        /// <summary>The walk's / card's ext channels for this frame (the last ones zeroed first).</summary>
        public static void Ext(int id, IDictionary<string, double> e)
        {
            var o = Rt.NewObj(e.Count);
            foreach (var kv in e) o.Put(kv.Key, double.IsNaN(kv.Value) || double.IsInfinity(kv.Value) ? 0 : kv.Value);
            Rt.Invoke(Rt.G("__native"), "ext", id, o.V);
        }
        public static string[] Events(int id)
        {
            var l = Rt.Invoke(Rt.G("__native"), "events", id).O as JsArray;
            if (l == null || l.Count == 0) return Array.Empty<string>();
            var o = new string[l.Count]; for (int i = 0; i < l.Count; i++) o[i] = Rt.ToStr(l.At(i)); return o;
        }
        /// <summary>The creature's body box at rest [x, y, w, h] (native-host.js restBox), null until it's drawn.</summary>
        public static double[] RestBox(int id)
        {
            var b = Rt.Invoke(Rt.G("__native"), "restBox", id).O as JsArray;
            if (b == null) return null;
            return new[] { Rt.ToNum(b.At(0)), Rt.ToNum(b.At(1)), Rt.ToNum(b.At(2)), Rt.ToNum(b.At(3)) };
        }

        /// <summary>Calls one of native-host.js's helpers (__native.name(args)).</summary>
        public static V Native(string name, params V[] args) => Rt.InvokeSpread(Rt.G("__native"), name, new JsArray(args).V);
    }
}
