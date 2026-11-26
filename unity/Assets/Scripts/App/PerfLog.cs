// Where a slow frame's time goes, in the log (the Editor and development builds only): every 2 s that averaged under
// 50 fps, one "[Perf]" line with the frame time and what the timed parts took per frame: the creature rig's clock
// and frames (NativeRig.LastFrameMs), each live creature's tree read and its drawing (Creatures/CreatureView), the
// pictures drawn again (Ui/UiPiece.SetSvg), the cards (Ui/Cards/CardPieces). The Editor's code optimization (Debug or
// Release: the bug icon at the bottom right) is logged once, since Debug makes the compiled rig several times slower.
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SquishSquad.App
{
    public sealed class PerfLog : MonoBehaviour
    {
        const float Window = 2f, SlowFps = 50f;
        static readonly Dictionary<string, (double ms, int n)> Parts = new Dictionary<string, (double, int)>();
        static readonly List<string> Order = new List<string>();
        // who in a part took the time (a picture's name), and how big it was last (its markup's length)
        static readonly Dictionary<string, (double ms, int n, int size)> Who = new Dictionary<string, (double, int, int)>();
        static bool _on;
        int _frames, _gc0;
        double _frameMs, _worst, _rigMs;
        long _heap0;
        float _t0;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Install()
        {
            if (!Application.isEditor && !Debug.isDebugBuild) return;
            var go = new GameObject("PerfLog");
            DontDestroyOnLoad(go);
            go.AddComponent<PerfLog>();
            _on = true;
#if UNITY_EDITOR
            Debug.Log("[Perf] the Editor's code optimization: " + UnityEditor.Compilation.CompilationPipeline.codeOptimization);
#endif
        }

        /// <summary>A timestamp to time a part from (cheap; 0 when the log is off).</summary>
        public static long Mark() => _on ? Stopwatch.GetTimestamp() : 0;
        /// <summary>Adds the time since `t0` (Mark) to the part `what`.</summary>
        public static void Add(string what, long t0)
        {
            if (!_on || t0 == 0) return;
            double ms = (Stopwatch.GetTimestamp() - t0) * 1000.0 / Stopwatch.Frequency;
            if (!Parts.TryGetValue(what, out var a)) Order.Add(what);
            Parts[what] = (a.ms + ms, a.n + 1);
        }
        /// <summary>Adds `ms` to the part `what` (a time taken elsewhere: the rig thread's step).</summary>
        public static void AddMs(string what, double ms)
        {
            if (!_on) return;
            if (!Parts.TryGetValue(what, out var a)) Order.Add(what);
            Parts[what] = (a.ms + ms, a.n + 1);
        }
        /// <summary>The same, naming who took it (the line lists the three that took the most) and its size.</summary>
        public static void Add(string what, long t0, string who, int size)
        {
            if (!_on || t0 == 0) return;
            double ms = (Stopwatch.GetTimestamp() - t0) * 1000.0 / Stopwatch.Frequency;
            if (!Parts.TryGetValue(what, out var a)) Order.Add(what);
            Parts[what] = (a.ms + ms, a.n + 1);
            string k = what + "|" + who;
            Who.TryGetValue(k, out var w);
            Who[k] = (w.ms + ms, w.n + 1, size);
        }

        void Start() { _t0 = Time.unscaledTime; _gc0 = System.GC.CollectionCount(0); _heap0 = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong(); }

        void Update()
        {
            double dt = Time.unscaledDeltaTime * 1000;
            _frames++; _frameMs += dt; if (dt > _worst) _worst = dt;
            _rigMs += SquishSquad.Creatures.NativeRig.LastFrameMs;
            float span = Time.unscaledTime - _t0;
            if (span < Window) return;
            double fps = _frames / span;
            if (fps < SlowFps)
            {
                var sb = new StringBuilder();
                sb.Append($"[Perf] {fps:0} fps: frame {_frameMs / _frames:0.0} ms (worst {_worst:0}); rig clock + frames {_rigMs / _frames:0.0} ms");
                foreach (var k in Order)
                {
                    var p = Parts[k];
                    if (p.n == 0) continue;
                    sb.Append($"; {k} {p.ms / _frames:0.0} ms ({(double)p.n / _frames:0.#}x)");
                }
                // what the parts above don't cover (the main thread's: the parts on other threads are marked so; the
                // pictures are drawn inside the screens' updates, so not counted twice), and
                // the garbage collections in the window (the rig allocates a lot: UNITY_TODO.md)
                double parts = _rigMs;
                foreach (var k in Order) if (!k.Contains("(its thread)") && !k.Contains("(workers)") && k != "creature tree" && k != "creature frames read" && k != "picture redraw") parts += Parts[k].ms;
                int gcs = System.GC.CollectionCount(0) - _gc0;
                long heap = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
                sb.Append($"; the rest {(_frameMs - parts) / _frames:0.0} ms per frame; {gcs} GC in {span:0.0} s, heap {heap / 1048576.0:0} MB ({(heap - _heap0) / 1048576.0:+0;-0} MB)");
                var top = new List<KeyValuePair<string, (double ms, int n, int size)>>(Who);
                top.Sort((x, y) => y.Value.ms.CompareTo(x.Value.ms));
                for (int i = 0; i < top.Count && i < 3; i++)
                {
                    var w = top[i]; int bar = w.Key.IndexOf('|');
                    sb.Append(i == 0 ? " | most: " : "; ").Append($"{w.Key.Substring(bar + 1)} ({w.Key.Substring(0, bar)}) {w.Value.ms / _frames:0.0} ms, {(double)w.Value.n / _frames:0.#}x, {w.Value.size / 1024.0:0.#} KB");
                }
                Debug.Log(sb.ToString());
            }
            _frames = 0; _frameMs = _worst = _rigMs = 0; _t0 = Time.unscaledTime;
            _gc0 = System.GC.CollectionCount(0); _heap0 = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
            foreach (var k in Order) Parts[k] = (0, 0);
            Who.Clear();
        }
    }
}
