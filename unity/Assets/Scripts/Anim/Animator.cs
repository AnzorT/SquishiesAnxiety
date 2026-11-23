// The clock and frame loop the Animated port runs on: stands in for the browser's Date.now(),
// requestAnimationFrame and setTimeout, with time supplied by the caller.
//
//   Animator.Default.Tick(nowMs);   // once per frame, e.g. from a MonoBehaviour's Update
//
// Tick(now) does what one browser frame does for these animations:
//   1. timers that are due by `now` fire in due-time order (ties: the order they were set). Each runs with
//      Now = its due time (a browser fires a timeout on time, between frames), never earlier than the last Now.
//      A timer set while this runs fires in this same Tick if it is due by `now`.
//   2. Now = now, and the frame callbacks requested before this point run in request order. A callback
//      cancelled meanwhile is skipped; callbacks requested while they run wait for the next Tick.
// Date.now() inside the animations is Now. To mimic Date.now() exactly, pass whole milliseconds.
// setTimeout delays are converted like a browser does (ToInt32, negatives to 0).
//
// Exceptions thrown by a callback don't stop the frame: the other callbacks still run (as in a browser).
// They are passed to Error if it has handlers, otherwise the first one is rethrown when Tick returns.
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace SquishSquad.Anim
{
    public sealed class Animator
    {
        /// <summary>The animator every animation started from now on schedules itself on (JS: the globals).</summary>
        public static Animator Default { get; set; } = new Animator();

        public Animator(double startMs = 0) { Now = startMs; }

        /// <summary>Date.now() for the animations, in ms.</summary>
        public double Now { get; private set; }

        /// <summary>Number of Tick calls so far.</summary>
        public int FrameCount { get; private set; }

        public event Action<Exception> Error;

        struct FrameCb { public int Id; public Action Callback; }
        struct TimerCb { public int Id; public double Due; public Action Callback; }

        List<FrameCb> _queue = new List<FrameCb>();
        List<FrameCb> _running = new List<FrameCb>();
        int _runIndex = -1;
        int _nextFrameId = 1;
        readonly List<TimerCb> _timers = new List<TimerCb>();
        int _nextTimerId = 1;
        ExceptionDispatchInfo _pending;

        public bool HasPendingFrames => _queue.Count > 0;
        public bool HasPendingTimers => _timers.Count > 0;
        public bool IsIdle => _queue.Count == 0 && _timers.Count == 0;

        public int RequestAnimationFrame(Action callback)
        {
            int id = _nextFrameId++;
            _queue.Add(new FrameCb { Id = id, Callback = callback });
            return id;
        }

        public void CancelAnimationFrame(int id)
        {
            if (id <= 0) return;
            for (int i = 0; i < _queue.Count; i++)
            {
                if (_queue[i].Id == id) { _queue.RemoveAt(i); return; }
            }
            for (int i = _runIndex + 1; i < _running.Count; i++)
            {
                if (_running[i].Id == id) { _running[i] = new FrameCb { Id = id, Callback = null }; return; }
            }
        }

        public int SetTimeout(Action callback, double delayMs)
        {
            int ms = JsMath.ToInt32(delayMs);
            if (ms < 0) ms = 0;
            int id = _nextTimerId++;
            _timers.Add(new TimerCb { Id = id, Due = Now + ms, Callback = callback });
            return id;
        }

        public void ClearTimeout(int id)
        {
            if (id <= 0) return;
            for (int i = 0; i < _timers.Count; i++)
            {
                if (_timers[i].Id == id) { _timers.RemoveAt(i); return; }
            }
        }

        /// <summary>Runs one frame at time nowMs (ms, same clock as Now). Times before Now are treated as Now.</summary>
        public void Tick(double nowMs)
        {
            if (!(nowMs >= Now)) nowMs = Now;
            FrameCount++;

            // 1. timers
            while (true)
            {
                int best = -1;
                for (int i = 0; i < _timers.Count; i++)
                {
                    var t = _timers[i];
                    if (t.Due > nowMs) continue;
                    if (best < 0 || t.Due < _timers[best].Due || (t.Due == _timers[best].Due && t.Id < _timers[best].Id)) best = i;
                }
                if (best < 0) break;
                var timer = _timers[best];
                _timers.RemoveAt(best);
                if (timer.Due > Now) Now = timer.Due;
                Invoke(timer.Callback);
            }

            // 2. frame callbacks
            Now = nowMs;
            var run = _queue;
            _queue = _running;
            _queue.Clear();
            _running = run;
            for (_runIndex = 0; _runIndex < _running.Count; _runIndex++)
            {
                var cb = _running[_runIndex].Callback;
                if (cb != null) Invoke(cb);
            }
            _runIndex = -1;
            _running.Clear();

            if (_pending != null)
            {
                var p = _pending;
                _pending = null;
                p.Throw();
            }
        }

        void Invoke(Action cb)
        {
            try
            {
                cb();
            }
            catch (Exception e)
            {
                if (Error != null) Error(e);
                else if (_pending == null) _pending = ExceptionDispatchInfo.Capture(e);
            }
        }
    }
}
