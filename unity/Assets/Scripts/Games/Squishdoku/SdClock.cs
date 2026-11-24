// game.js useClock (Squishdoku's, and the Blitz runs' boards' clocks: Squish Hop's too). No UnityEngine here.
using System;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Squishdoku
{
    /// <summary>game.js useClock: a clock that can pause; Frac (1 → 0) drives the timer bar.</summary>
    public sealed class SdClock
    {
        readonly Ticker _tk;
        public readonly AnimatedValue Frac = new AnimatedValue(1);
        double _limit = 1, _used, _since;
        bool _running;
        CompositeAnimation _anim;
        public SdClock(Ticker tk) { _tk = tk; }
        public double Limit => _limit;
        public bool Running => _running;
        public double Elapsed => _used + (_running ? _tk.Now - _since : 0);
        void Run()
        {
            _anim?.Stop();
            Frac.SetValue(Math.Max(0, 1 - _used / _limit));
            _anim = Animated.Timing(Frac, Fx.Timing(0, Math.Max(1, _limit - _used), Easing.Linear));
            _anim.Start();
        }
        public void Start(double limit, double used = 0) { _limit = limit; _used = used; _since = _tk.Now; _running = true; Run(); }
        public void Pause() { if (!_running) return; _used += _tk.Now - _since; _running = false; _anim?.Stop(); Frac.SetValue(Math.Max(0, 1 - _used / _limit)); }
        public void Resume() { if (_running) return; _since = _tk.Now; _running = true; Run(); }
        public void Reset() { _anim?.Stop(); _limit = 1; _used = 0; _since = 0; _running = false; Frac.SetValue(1); }
    }
}
