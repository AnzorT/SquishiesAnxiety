// The realm's own thread: every call into the compiled scripts runs on it, with a big stack. Some compiled functions
// are huge (rive-generic.js's biggest closure is ~370 KB of IL with ~2,600 locals), and an unoptimized JIT gives each
// its own wide frame: Mittens' mount alone needs 256-512 KB of stack under .NET's debug JIT, more under the Editor's
// Mono, and Unity's main thread has 1 MB (Unity.exe), so the first mount overflowed it and took the Editor's scripting
// down with it. The boot already ran on a 16 MB thread (NativeRig.Prewarm); this is the same for everything after it.
//
// The caller waits while the call runs, so the realm is still only ever on one thread at a time; a call made from the
// rig thread itself (a callback into the host that calls back in) runs inline. Exceptions come back to the caller as
// they were thrown. Post hands over a call without waiting (the clock's step, while Unity draws the frames read before
// it: Creatures/NativeRig.FrameBegin / FrameEnd); the next Run, Post or Wait waits for it first, so the realm is still
// never touched by two threads at once. Unity-free (the tests drive it with plain dotnet the same way).
using System;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace SquishSquad.Creatures.Js
{
    public static class RigThread
    {
        /// <summary>The rig thread's stack (a reservation: only the pages it touches are used).</summary>
        public const int StackBytes = 64 << 20;

        static readonly object Gate = new object();
        static readonly SemaphoreSlim Go = new SemaphoreSlim(0), Done = new SemaphoreSlim(0);
        static Thread _thread;
        static Action _job;
        static ExceptionDispatchInfo _error;
        static bool _pending;
        [ThreadStatic] static bool _onRig;

        /// <summary>What a posted call threw (it has no caller to throw to).</summary>
        public static Action<Exception> PostError;

        /// <summary>Whether this is the rig thread.</summary>
        public static bool On => _onRig;

        /// <summary>Runs `a` on the rig thread and waits for it (inline when already there).</summary>
        public static void Run(Action a)
        {
            if (_onRig) { a(); return; }
            ExceptionDispatchInfo err;
            lock (Gate)
            {
                Finish();
                Begin(a);
                Done.Wait();
                err = _error; _error = null; _job = null;
            }
            err?.Throw();
        }

        /// <summary>Hands `a` to the rig thread and goes on (inline when already there).</summary>
        public static void Post(Action a)
        {
            if (_onRig) { a(); return; }
            lock (Gate)
            {
                Finish();
                Begin(a);
                _pending = true;
            }
        }

        /// <summary>Waits for a posted call to be done.</summary>
        public static void Wait()
        {
            if (_onRig) return;
            lock (Gate) Finish();
        }

        /// <summary>Whether a posted call may still be running.</summary>
        public static bool Pending => _pending;

        // (under Gate)
        static void Begin(Action a)
        {
            if (_thread == null)
            {
                _thread = new Thread(Loop, StackBytes) { IsBackground = true, Name = "rig" };
                _thread.Start();
            }
            _job = a;
            Go.Release();
        }
        static void Finish()
        {
            if (!_pending) return;
            Done.Wait();
            _pending = false;
            var e = _error; _error = null; _job = null;
            if (e != null) PostError?.Invoke(e.SourceException);
        }

        /// <summary>Runs `f` on the rig thread and gives its value.</summary>
        public static T Run<T>(Func<T> f)
        {
            if (_onRig) return f();
            T r = default;
            Run(() => { r = f(); });
            return r;
        }

        static void Loop()
        {
            _onRig = true;
            while (true)
            {
                Go.Wait();
                try { _job(); }
                catch (Exception e) { _error = ExceptionDispatchInfo.Capture(e); }
                Done.Release();
            }
        }
    }
}
