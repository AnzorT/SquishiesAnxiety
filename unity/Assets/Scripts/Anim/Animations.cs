// Ports of react-native-web/dist/vendor/react-native/Animated/animations/{Animation,TimingAnimation,
// SpringAnimation,DecayAnimation}.js and SpringConfig.js, JS-driven (there is no native driver here: a
// config's UseNativeDriver is accepted and ignored, as react-native-web does when the native module is
// missing). isInteraction / InteractionManager and native `iterations` are not ported (no effect on values).
//
// Each animation runs on the Animator that is Animator.Default when it starts.
using System;

namespace SquishSquad.Anim
{
    /// <summary>The {finished} object passed to completion callbacks.</summary>
    public readonly struct EndResult
    {
        public readonly bool Finished;
        public EndResult(bool finished) { Finished = finished; }
        public static readonly EndResult Done = new EndResult(true);
        public static readonly EndResult Interrupted = new EndResult(false);
        public override string ToString() { return Finished ? "{finished: true}" : "{finished: false}"; }
    }

    /// <summary>Animation.js. start() and stop() are each called at most once; an animation is not reused.</summary>
    public abstract class Animation
    {
        protected Animator animator;
        protected bool active;
        protected Action<double> onUpdate;
        Action<EndResult> _onEnd;

        public abstract void Start(double fromValue, Action<double> onUpdate, Action<EndResult> onEnd, Animation previousAnimation, AnimatedValue animatedValue);

        public virtual void Stop() { }

        protected void Begin(Action<double> update, Action<EndResult> end)
        {
            animator = Animator.Default;
            active = true;
            onUpdate = update;
            _onEnd = end;
        }

        /// <summary>Makes sure onEnd is only called once.</summary>
        protected void DebouncedOnEnd(EndResult result)
        {
            var onEnd = _onEnd;
            _onEnd = null;
            if (onEnd != null) onEnd(result);
        }
    }

    public sealed class TimingConfig
    {
        public double ToValue;
        /// <summary>null: Easing.InOut(Easing.Ease), the JS default.</summary>
        public Func<double, double> Easing;
        public double Duration = 500;
        public double Delay = 0;
        public Action<EndResult> OnComplete;
        /// <summary>Ignored: everything is JS-driven.</summary>
        public bool UseNativeDriver;

        public TimingConfig Clone() { return (TimingConfig)MemberwiseClone(); }
    }

    public sealed class TimingAnimation : Animation
    {
        static Func<double, double> _easeInOut;
        static Func<double, double> EaseInOut()
        {
            if (_easeInOut == null) _easeInOut = Anim.Easing.InOut(Anim.Easing.Ease);
            return _easeInOut;
        }

        readonly double _toValue;
        readonly Func<double, double> _easing;
        readonly double _duration;
        readonly double _delay;
        double _fromValue;
        double _startTime;
        int _animationFrame;
        int _timeout;
        Action _onFrame;

        public TimingAnimation(TimingConfig config)
        {
            _toValue = config.ToValue;
            _easing = config.Easing ?? EaseInOut();
            _duration = config.Duration;
            _delay = config.Delay;
        }

        public override void Start(double fromValue, Action<double> update, Action<EndResult> onEnd, Animation previousAnimation, AnimatedValue animatedValue)
        {
            Begin(update, onEnd);
            _fromValue = fromValue;
            _onFrame = OnFrame;
            if (_delay != 0 && !double.IsNaN(_delay)) _timeout = animator.SetTimeout(StartNow, _delay);
            else StartNow();
        }

        void StartNow()
        {
            if (_duration == 0)
            {
                onUpdate(_toValue);
                DebouncedOnEnd(EndResult.Done);
            }
            else
            {
                _startTime = animator.Now;
                _animationFrame = animator.RequestAnimationFrame(_onFrame);
            }
        }

        void OnFrame()
        {
            double now = animator.Now;
            if (now >= _startTime + _duration)
            {
                if (_duration == 0) onUpdate(_toValue);
                else onUpdate(_fromValue + _easing(1) * (_toValue - _fromValue));
                DebouncedOnEnd(EndResult.Done);
                return;
            }
            onUpdate(_fromValue + _easing((now - _startTime) / _duration) * (_toValue - _fromValue));
            if (active) _animationFrame = animator.RequestAnimationFrame(_onFrame);
        }

        public override void Stop()
        {
            active = false;
            if (animator != null)
            {
                animator.ClearTimeout(_timeout);
                animator.CancelAnimationFrame(_animationFrame);
            }
            DebouncedOnEnd(EndResult.Interrupted);
        }
    }

    public sealed class SpringConfig
    {
        public double ToValue;
        public bool OvershootClamping;
        public double RestDisplacementThreshold = 0.001;
        public double RestSpeedThreshold = 0.001;
        public double Velocity;
        public double Delay;
        // One of: Stiffness/Damping/Mass, Bounciness/Speed, Tension/Friction (default tension 40, friction 7).
        public double? Stiffness, Damping, Mass;
        public double? Bounciness, Speed;
        public double? Tension, Friction;
        public Action<EndResult> OnComplete;
        /// <summary>Ignored: everything is JS-driven.</summary>
        public bool UseNativeDriver;

        public SpringConfig Clone() { return (SpringConfig)MemberwiseClone(); }
    }

    /// <summary>SpringConfig.js: origami tension/friction and bounciness/speed to stiffness/damping.</summary>
    public static class SpringParams
    {
        static double StiffnessFromOrigamiValue(double oValue) { return (oValue - 30) * 3.62 + 194; }
        static double DampingFromOrigamiValue(double oValue) { return (oValue - 8) * 3 + 25; }

        public static void FromOrigamiTensionAndFriction(double tension, double friction, out double stiffness, out double damping)
        {
            stiffness = StiffnessFromOrigamiValue(tension);
            damping = DampingFromOrigamiValue(friction);
        }

        static double Normalize(double value, double startValue, double endValue) { return (value - startValue) / (endValue - startValue); }
        static double ProjectNormal(double n, double start, double end) { return start + n * (end - start); }
        static double LinearInterpolation(double t, double start, double end) { return t * end + (1 - t) * start; }
        static double QuadraticOutInterpolation(double t, double start, double end) { return LinearInterpolation(2 * t - t * t, start, end); }
        static double B3Friction1(double x) { return 0.0007 * JsMath.Pow(x, 3) - 0.031 * JsMath.Pow(x, 2) + 0.64 * x + 1.28; }
        static double B3Friction2(double x) { return 0.000044 * JsMath.Pow(x, 3) - 0.006 * JsMath.Pow(x, 2) + 0.36 * x + 2; }
        static double B3Friction3(double x) { return 0.00000045 * JsMath.Pow(x, 3) - 0.000332 * JsMath.Pow(x, 2) + 0.1078 * x + 5.84; }
        static double B3Nobounce(double tension)
        {
            if (tension <= 18) return B3Friction1(tension);
            if (tension > 18 && tension <= 44) return B3Friction2(tension);
            return B3Friction3(tension);
        }

        public static void FromBouncinessAndSpeed(double bounciness, double speed, out double stiffness, out double damping)
        {
            double b = Normalize(bounciness / 1.7, 0, 20);
            b = ProjectNormal(b, 0, 0.8);
            double s = Normalize(speed / 1.7, 0, 20);
            double bouncyTension = ProjectNormal(s, 0.5, 200);
            double bouncyFriction = QuadraticOutInterpolation(b, B3Nobounce(bouncyTension), 0.01);
            stiffness = StiffnessFromOrigamiValue(bouncyTension);
            damping = DampingFromOrigamiValue(bouncyFriction);
        }
    }

    public sealed class SpringAnimation : Animation
    {
        const double MAX_STEPS = 64;

        readonly bool _overshootClamping;
        readonly double _restDisplacementThreshold;
        readonly double _restSpeedThreshold;
        double _initialVelocity;
        double _lastVelocity;
        readonly double _toValue;
        readonly double _delay;
        readonly double _stiffness, _damping, _mass;
        double _startPosition, _lastPosition, _lastTime, _frameTime;
        int _animationFrame;
        int _timeout;
        Action _onFrame;

        public double Stiffness => _stiffness;
        public double Damping => _damping;
        public double Mass => _mass;

        public SpringAnimation(SpringConfig config)
        {
            _overshootClamping = config.OvershootClamping;
            _restDisplacementThreshold = config.RestDisplacementThreshold;
            _restSpeedThreshold = config.RestSpeedThreshold;
            _initialVelocity = config.Velocity;
            _lastVelocity = config.Velocity;
            _toValue = config.ToValue;
            _delay = config.Delay;

            if (config.Stiffness.HasValue || config.Damping.HasValue || config.Mass.HasValue)
            {
                if (config.Bounciness.HasValue || config.Speed.HasValue || config.Tension.HasValue || config.Friction.HasValue)
                    throw new ArgumentException("You can define one of bounciness/speed, tension/friction, or stiffness/damping/mass, but not more than one");
                _stiffness = config.Stiffness ?? 100;
                _damping = config.Damping ?? 10;
                _mass = config.Mass ?? 1;
            }
            else if (config.Bounciness.HasValue || config.Speed.HasValue)
            {
                if (config.Tension.HasValue || config.Friction.HasValue)
                    throw new ArgumentException("You can define one of bounciness/speed, tension/friction, or stiffness/damping/mass, but not more than one");
                SpringParams.FromBouncinessAndSpeed(config.Bounciness ?? 8, config.Speed ?? 12, out _stiffness, out _damping);
                _mass = 1;
            }
            else
            {
                SpringParams.FromOrigamiTensionAndFriction(config.Tension ?? 40, config.Friction ?? 7, out _stiffness, out _damping);
                _mass = 1;
            }
            if (!(_stiffness > 0)) throw new ArgumentException("Stiffness value must be greater than 0");
            if (!(_damping > 0)) throw new ArgumentException("Damping value must be greater than 0");
            if (!(_mass > 0)) throw new ArgumentException("Mass value must be greater than 0");
        }

        public override void Start(double fromValue, Action<double> update, Action<EndResult> onEnd, Animation previousAnimation, AnimatedValue animatedValue)
        {
            Begin(update, onEnd);
            _startPosition = fromValue;
            _lastPosition = _startPosition;
            _lastTime = animator.Now;
            _frameTime = 0.0;
            var prev = previousAnimation as SpringAnimation;
            if (prev != null)
            {
                _lastPosition = prev._lastPosition;
                _lastVelocity = prev._lastVelocity;
                _initialVelocity = _lastVelocity;
                _lastTime = prev._lastTime;
            }
            _onFrame = OnFrame;
            if (_delay != 0 && !double.IsNaN(_delay)) _timeout = animator.SetTimeout(_onFrame, _delay);
            else OnFrame();
        }

        // Closed form of the damped harmonic oscillator, evaluated at the accumulated frame time (see the JS).
        void OnFrame()
        {
            double now = animator.Now;
            if (now > _lastTime + MAX_STEPS) now = _lastTime + MAX_STEPS;
            double deltaTime = (now - _lastTime) / 1000;
            _frameTime += deltaTime;
            double c = _damping;
            double m = _mass;
            double k = _stiffness;
            double v0 = -_initialVelocity;
            double zeta = c / (2 * Math.Sqrt(k * m));
            double omega0 = Math.Sqrt(k / m);
            double omega1 = omega0 * Math.Sqrt(1.0 - zeta * zeta);
            double x0 = _toValue - _startPosition;

            double position;
            double velocity;
            double t = _frameTime;
            if (zeta < 1)
            {
                double envelope = JsMath.Exp(-zeta * omega0 * t);
                position = _toValue - envelope * ((v0 + zeta * omega0 * x0) / omega1 * JsMath.Sin(omega1 * t) + x0 * JsMath.Cos(omega1 * t));
                velocity = zeta * omega0 * envelope * (JsMath.Sin(omega1 * t) * (v0 + zeta * omega0 * x0) / omega1 + x0 * JsMath.Cos(omega1 * t)) - envelope * (JsMath.Cos(omega1 * t) * (v0 + zeta * omega0 * x0) - omega1 * x0 * JsMath.Sin(omega1 * t));
            }
            else
            {
                double envelope = JsMath.Exp(-omega0 * t);
                position = _toValue - envelope * (x0 + (v0 + omega0 * x0) * t);
                velocity = envelope * (v0 * (t * omega0 - 1) + t * x0 * (omega0 * omega0));
            }
            _lastTime = now;
            _lastPosition = position;
            _lastVelocity = velocity;
            onUpdate(position);
            if (!active) return; // a listener might have stopped us in onUpdate

            bool isOvershooting = false;
            if (_overshootClamping && _stiffness != 0)
            {
                if (_startPosition < _toValue) isOvershooting = position > _toValue;
                else isOvershooting = position < _toValue;
            }
            bool isVelocity = Math.Abs(velocity) <= _restSpeedThreshold;
            bool isDisplacement = true;
            if (_stiffness != 0) isDisplacement = Math.Abs(_toValue - position) <= _restDisplacementThreshold;
            if (isOvershooting || (isVelocity && isDisplacement))
            {
                if (_stiffness != 0)
                {
                    _lastPosition = _toValue;
                    _lastVelocity = 0;
                    onUpdate(_toValue);
                }
                DebouncedOnEnd(EndResult.Done);
                return;
            }
            _animationFrame = animator.RequestAnimationFrame(_onFrame);
        }

        public override void Stop()
        {
            active = false;
            if (animator != null)
            {
                animator.ClearTimeout(_timeout);
                animator.CancelAnimationFrame(_animationFrame);
            }
            DebouncedOnEnd(EndResult.Interrupted);
        }
    }

    public sealed class DecayConfig
    {
        public double Velocity;
        public double Deceleration = 0.998;
        public Action<EndResult> OnComplete;
        /// <summary>Ignored: everything is JS-driven.</summary>
        public bool UseNativeDriver;

        public DecayConfig Clone() { return (DecayConfig)MemberwiseClone(); }
    }

    public sealed class DecayAnimation : Animation
    {
        readonly double _deceleration;
        readonly double _velocity;
        double _lastValue, _fromValue, _startTime;
        int _animationFrame;
        Action _onFrame;

        public DecayAnimation(DecayConfig config)
        {
            _deceleration = config.Deceleration;
            _velocity = config.Velocity;
        }

        public override void Start(double fromValue, Action<double> update, Action<EndResult> onEnd, Animation previousAnimation, AnimatedValue animatedValue)
        {
            Begin(update, onEnd);
            _lastValue = fromValue;
            _fromValue = fromValue;
            _startTime = animator.Now;
            _onFrame = OnFrame;
            _animationFrame = animator.RequestAnimationFrame(_onFrame);
        }

        void OnFrame()
        {
            double now = animator.Now;
            double value = _fromValue + _velocity / (1 - _deceleration) * (1 - JsMath.Exp(-(1 - _deceleration) * (now - _startTime)));
            onUpdate(value);
            if (Math.Abs(_lastValue - value) < 0.1)
            {
                DebouncedOnEnd(EndResult.Done);
                return;
            }
            _lastValue = value;
            if (active) _animationFrame = animator.RequestAnimationFrame(_onFrame);
        }

        public override void Stop()
        {
            active = false;
            if (animator != null) animator.CancelAnimationFrame(_animationFrame);
            DebouncedOnEnd(EndResult.Interrupted);
        }
    }
}
