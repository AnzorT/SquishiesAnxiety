// A few threads of their own that make the live creatures' shapes (SvgScene.Compile of a frame's node tree) while the
// main thread does the rest of the frame (Creatures/CreatureView: one job per view, reused). Not .NET's thread pool:
// in Unity its threads are shared with everything else (the network's async calls, Unity's own tasks), and a job
// queued there waited 10-30 ms for a thread in the Editor, longer than making the shapes takes (1-3 ms). Unity-free.
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace SquishSquad.Vector
{
    /// <summary>One view's shapes job: started each frame (Start), waited for when they're drawn (Wait).</summary>
    public sealed class ShapeJob
    {
        internal Func<SvgScene> Work;
        internal SvgScene Result;
        internal Exception Error;
        internal readonly ManualResetEventSlim Done = new ManualResetEventSlim(false);
        /// <summary>The time the shapes took on their thread (ms).</summary>
        public double Ms { get; internal set; }
        /// <summary>A job is out (started and not yet waited for).</summary>
        public bool Out { get; private set; }

        /// <summary>Hands `work` to the shape threads.</summary>
        public void Start(Func<SvgScene> work)
        {
            if (Out) Wait();
            Work = work; Result = null; Error = null; Done.Reset(); Out = true;
            ShapeWorkers.Queue(this);
        }

        /// <summary>The shapes (waits for them); what the work threw, thrown here.</summary>
        public SvgScene Wait()
        {
            Done.Wait();
            Out = false;
            var r = Result; var e = Error;
            Result = null; Error = null; Work = null;
            if (e != null) throw new InvalidOperationException("making the shapes failed: " + e.Message, e);
            return r;
        }
    }

    public static class ShapeWorkers
    {
        static readonly ConcurrentQueue<ShapeJob> Jobs = new ConcurrentQueue<ShapeJob>();
        static readonly SemaphoreSlim Ready = new SemaphoreSlim(0);
        static readonly object Gate = new object();
        static Thread[] _threads;

        /// <summary>How many threads (the cores less the main, the render and the rig thread; 1 to 3).</summary>
        public static int Count => Math.Max(1, Math.Min(3, Environment.ProcessorCount - 3));

        internal static void Queue(ShapeJob j)
        {
            if (_threads == null) lock (Gate) if (_threads == null)
            {
                var t = new Thread[Count];
                for (int i = 0; i < t.Length; i++) { t[i] = new Thread(Loop) { IsBackground = true, Name = "shapes " + i }; t[i].Start(); }
                _threads = t;
            }
            Jobs.Enqueue(j);
            Ready.Release();
        }

        static void Loop()
        {
            while (true)
            {
                Ready.Wait();
                if (!Jobs.TryDequeue(out var j)) continue;
                long a = System.Diagnostics.Stopwatch.GetTimestamp();
                try { j.Result = j.Work(); }
                catch (Exception e) { j.Error = e; }
                j.Ms = (System.Diagnostics.Stopwatch.GetTimestamp() - a) * 1000.0 / System.Diagnostics.Stopwatch.Frequency;
                j.Done.Set();
            }
        }
    }
}
