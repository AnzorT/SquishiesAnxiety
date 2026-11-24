// JavaScript's setTimeout / setInterval / Date.now on a millisecond clock that the host moves (Unity: every frame, from
// the real time; tools/unity/audio-test: a virtual clock, the same one the JS side runs on). The sound code is a
// line-by-line port of src/audio/*.js, so it keeps the JS's timers.
//
// A timer fires once the clock has reached its due time, with Now set to that due time; timers due together fire in
// the order they were armed; an interval is re-armed at due + interval. Plain C#, no Unity.
using System;
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public sealed class JsTimers
    {
        sealed class Timer
        {
            public int Id;
            public double Due, Every;
            public long Seq;
            public Action Fn;
        }

        readonly List<Timer> _live = new List<Timer>();
        int _nextId = 1;
        long _seq;

        public JsTimers(double nowMs) { Now = nowMs; }

        /// <summary>Date.now(): the clock, in ms.</summary>
        public double Now { get; private set; }

        public int SetTimeout(Action fn, double ms) => Arm(fn, ms, 0);

        public int SetInterval(Action fn, double ms) => Arm(fn, ms, Math.Max(1, ms));

        int Arm(Action fn, double ms, double every)
        {
            var t = new Timer { Id = _nextId++, Due = Now + Math.Max(0, ms), Every = every, Seq = ++_seq, Fn = fn };
            _live.Add(t);
            return t.Id;
        }

        public void Clear(int id)
        {
            if (id == 0) return;
            for (int i = 0; i < _live.Count; i++)
                if (_live[i].Id == id) { _live.RemoveAt(i); return; }
        }

        public int Pending => _live.Count;

        /// <summary>Moves the clock to `nowMs`, firing every timer due by then in order.</summary>
        public void AdvanceTo(double nowMs)
        {
            while (true)
            {
                Timer next = null;
                foreach (var t in _live)
                    if (t.Due <= nowMs && (next == null || t.Due < next.Due || (t.Due == next.Due && t.Seq < next.Seq))) next = t;
                if (next == null) break;
                if (next.Due > Now) Now = next.Due;
                if (next.Every > 0)
                {
                    next.Due += next.Every;
                    next.Seq = ++_seq;
                }
                else _live.Remove(next);
                next.Fn();
            }
            if (nowMs > Now) Now = nowMs;
        }
    }
}
