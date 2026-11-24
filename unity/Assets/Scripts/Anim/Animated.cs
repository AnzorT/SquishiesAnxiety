// Port of AnimatedImplementation.js: Animated.timing / spring / decay (incl. ValueXY), sequence, parallel,
// stagger, loop, delay and the arithmetic node factories, with the same callback order and {finished}
// semantics (including the JS's quirks: a sequence remembers where it got to until reset(), a parallel
// remembers which children ended, onComplete runs before the start() callback, a loop's reset() restores the
// values the AnimatedValues were created with).
//
//   var scale = new AnimatedValue(1);
//   Animated.Sequence(
//       Animated.Timing(scale, new TimingConfig { ToValue = 1.2, Duration = 120, Easing = Easing.Out(Easing.Quad) }),
//       Animated.Spring(scale, new SpringConfig { ToValue = 1, Friction = 4, Tension = 120 })
//   ).Start(r => { if (r.Finished) Done(); });
//   ... each frame: Ticker.Default.Tick(nowMs); transform.localScale = Vector3.one * (float)scale.GetValue();
using System;
using System.Collections.Generic;

namespace SquishSquad.Anim
{
    /// <summary>What Animated.timing(...) etc. return: start(callback), stop(), reset().</summary>
    public abstract class CompositeAnimation
    {
        public abstract void Start(Action<EndResult> callback = null);
        public abstract void Stop();
        public abstract void Reset();
    }

    public static class Animated
    {
        static Action<EndResult> CombineCallbacks(Action<EndResult> callback, Action<EndResult> onComplete)
        {
            if (callback != null && onComplete != null)
            {
                return r =>
                {
                    onComplete(r);
                    callback(r);
                };
            }
            return callback ?? onComplete;
        }

        sealed class TimingComposite : CompositeAnimation
        {
            readonly AnimatedValue _value;
            readonly TimingConfig _config;
            public TimingComposite(AnimatedValue value, TimingConfig config) { _value = value; _config = config; }
            public override void Start(Action<EndResult> callback = null)
            {
                callback = CombineCallbacks(callback, _config.OnComplete);
                _value.StopTracking();
                _value.Animate(new TimingAnimation(_config), callback);
            }
            public override void Stop() { _value.StopAnimation(); }
            public override void Reset() { _value.ResetAnimation(); }
        }

        sealed class SpringComposite : CompositeAnimation
        {
            readonly AnimatedValue _value;
            readonly SpringConfig _config;
            public SpringComposite(AnimatedValue value, SpringConfig config) { _value = value; _config = config; }
            public override void Start(Action<EndResult> callback = null)
            {
                callback = CombineCallbacks(callback, _config.OnComplete);
                _value.StopTracking();
                _value.Animate(new SpringAnimation(_config), callback);
            }
            public override void Stop() { _value.StopAnimation(); }
            public override void Reset() { _value.ResetAnimation(); }
        }

        sealed class DecayComposite : CompositeAnimation
        {
            readonly AnimatedValue _value;
            readonly DecayConfig _config;
            public DecayComposite(AnimatedValue value, DecayConfig config) { _value = value; _config = config; }
            public override void Start(Action<EndResult> callback = null)
            {
                callback = CombineCallbacks(callback, _config.OnComplete);
                _value.StopTracking();
                _value.Animate(new DecayAnimation(_config), callback);
            }
            public override void Stop() { _value.StopAnimation(); }
            public override void Reset() { _value.ResetAnimation(); }
        }

        public static CompositeAnimation Timing(AnimatedValue value, TimingConfig config)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (config == null) throw new ArgumentNullException(nameof(config));
            return new TimingComposite(value, config);
        }

        public static CompositeAnimation Spring(AnimatedValue value, SpringConfig config)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (config == null) throw new ArgumentNullException(nameof(config));
            return new SpringComposite(value, config);
        }

        public static CompositeAnimation Decay(AnimatedValue value, DecayConfig config)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (config == null) throw new ArgumentNullException(nameof(config));
            return new DecayComposite(value, config);
        }

        // ValueXY: JS splits each {x, y} config entry into two configs and runs both with stopTogether: false.
        // config.ToValue is ignored; config.OnComplete runs for each axis, as in JS.
        public static CompositeAnimation Timing(AnimatedValueXY value, double toX, double toY, TimingConfig config)
        {
            var cx = config.Clone(); cx.ToValue = toX;
            var cy = config.Clone(); cy.ToValue = toY;
            return Parallel(new CompositeAnimation[] { Timing(value.X, cx), Timing(value.Y, cy) }, false);
        }

        /// <summary>velocityX/Y: null uses config.Velocity for that axis.</summary>
        public static CompositeAnimation Spring(AnimatedValueXY value, double toX, double toY, SpringConfig config, double? velocityX = null, double? velocityY = null)
        {
            var cx = config.Clone(); cx.ToValue = toX; if (velocityX.HasValue) cx.Velocity = velocityX.Value;
            var cy = config.Clone(); cy.ToValue = toY; if (velocityY.HasValue) cy.Velocity = velocityY.Value;
            return Parallel(new CompositeAnimation[] { Spring(value.X, cx), Spring(value.Y, cy) }, false);
        }

        public static CompositeAnimation Decay(AnimatedValueXY value, double velocityX, double velocityY, DecayConfig config)
        {
            var cx = config.Clone(); cx.Velocity = velocityX;
            var cy = config.Clone(); cy.Velocity = velocityY;
            return Parallel(new CompositeAnimation[] { Decay(value.X, cx), Decay(value.Y, cy) }, false);
        }

        sealed class SequenceComposite : CompositeAnimation
        {
            readonly CompositeAnimation[] _animations;
            int _current;
            public SequenceComposite(CompositeAnimation[] animations) { _animations = animations; }

            public override void Start(Action<EndResult> callback = null)
            {
                Action<EndResult> onComplete = null;
                onComplete = result =>
                {
                    if (!result.Finished)
                    {
                        if (callback != null) callback(result);
                        return;
                    }
                    _current++;
                    if (_current == _animations.Length)
                    {
                        if (callback != null) callback(result);
                        return;
                    }
                    _animations[_current].Start(onComplete);
                };
                if (_animations.Length == 0)
                {
                    if (callback != null) callback(EndResult.Done);
                }
                else
                {
                    _animations[_current].Start(onComplete);
                }
            }

            public override void Stop()
            {
                if (_current < _animations.Length) _animations[_current].Stop();
            }

            public override void Reset()
            {
                for (int idx = 0; idx < _animations.Length; idx++)
                {
                    if (idx <= _current) _animations[idx].Reset();
                }
                _current = 0;
            }
        }

        public static CompositeAnimation Sequence(params CompositeAnimation[] animations)
        {
            return new SequenceComposite((CompositeAnimation[])animations.Clone());
        }

        public static CompositeAnimation Sequence(IList<CompositeAnimation> animations)
        {
            var a = new CompositeAnimation[animations.Count];
            animations.CopyTo(a, 0);
            return new SequenceComposite(a);
        }

        sealed class ParallelComposite : CompositeAnimation
        {
            readonly CompositeAnimation[] _animations;
            readonly bool _stopTogether;
            readonly bool[] _hasEnded;
            int _doneCount;

            public ParallelComposite(CompositeAnimation[] animations, bool stopTogether)
            {
                _animations = animations;
                _stopTogether = stopTogether;
                _hasEnded = new bool[animations.Length];
            }

            public override void Start(Action<EndResult> callback = null)
            {
                if (_doneCount == _animations.Length)
                {
                    if (callback != null) callback(EndResult.Done);
                    return;
                }
                for (int idx = 0; idx < _animations.Length; idx++)
                {
                    int i = idx;
                    var animation = _animations[i];
                    Action<EndResult> cb = endResult =>
                    {
                        _hasEnded[i] = true;
                        _doneCount++;
                        if (_doneCount == _animations.Length)
                        {
                            _doneCount = 0;
                            if (callback != null) callback(endResult);
                            return;
                        }
                        if (!endResult.Finished && _stopTogether) Stop();
                    };
                    if (animation == null) cb(EndResult.Done);
                    else animation.Start(cb);
                }
            }

            public override void Stop()
            {
                for (int idx = 0; idx < _animations.Length; idx++)
                {
                    if (!_hasEnded[idx]) _animations[idx].Stop();
                    _hasEnded[idx] = true;
                }
            }

            public override void Reset()
            {
                for (int idx = 0; idx < _animations.Length; idx++)
                {
                    _animations[idx].Reset();
                    _hasEnded[idx] = false;
                    _doneCount = 0;
                }
            }
        }

        /// <summary>Animated.parallel(animations, {stopTogether}). Null entries count as finished, as in JS.</summary>
        public static CompositeAnimation Parallel(IList<CompositeAnimation> animations, bool stopTogether = true)
        {
            var a = new CompositeAnimation[animations.Count];
            animations.CopyTo(a, 0);
            return new ParallelComposite(a, stopTogether);
        }

        public static CompositeAnimation Parallel(params CompositeAnimation[] animations)
        {
            return new ParallelComposite((CompositeAnimation[])animations.Clone(), true);
        }

        public static CompositeAnimation Delay(double time)
        {
            return Timing(new AnimatedValue(0), new TimingConfig { ToValue = 0, Delay = time, Duration = 0 });
        }

        public static CompositeAnimation Stagger(double time, IList<CompositeAnimation> animations)
        {
            var a = new CompositeAnimation[animations.Count];
            for (int i = 0; i < a.Length; i++) a[i] = Sequence(Delay(time * i), animations[i]);
            return new ParallelComposite(a, true);
        }

        public static CompositeAnimation Stagger(double time, params CompositeAnimation[] animations)
        {
            return Stagger(time, (IList<CompositeAnimation>)animations);
        }

        sealed class LoopComposite : CompositeAnimation
        {
            readonly CompositeAnimation _animation;
            readonly int _iterations;
            readonly bool _resetBeforeIteration;
            bool _isFinished;
            int _iterationsSoFar;

            public LoopComposite(CompositeAnimation animation, int iterations, bool resetBeforeIteration)
            {
                _animation = animation;
                _iterations = iterations;
                _resetBeforeIteration = resetBeforeIteration;
            }

            public override void Start(Action<EndResult> callback = null)
            {
                Action<EndResult> restart = null;
                restart = result =>
                {
                    if (_isFinished || _iterationsSoFar == _iterations || result.Finished == false)
                    {
                        if (callback != null) callback(result);
                    }
                    else
                    {
                        _iterationsSoFar++;
                        if (_resetBeforeIteration) _animation.Reset();
                        _animation.Start(restart);
                    }
                };
                if (_animation == null || _iterations == 0)
                {
                    if (callback != null) callback(EndResult.Done);
                }
                else
                {
                    restart(EndResult.Done); // JS-driven loop (no native loops here)
                }
            }

            public override void Stop()
            {
                _isFinished = true;
                _animation.Stop();
            }

            public override void Reset()
            {
                _iterationsSoFar = 0;
                _isFinished = false;
                _animation.Reset();
            }
        }

        /// <summary>Animated.loop(animation, {iterations = -1 (forever), resetBeforeIteration = true}).</summary>
        public static CompositeAnimation Loop(CompositeAnimation animation, int iterations = -1, bool resetBeforeIteration = true)
        {
            return new LoopComposite(animation, iterations, resetBeforeIteration);
        }

        public static AnimatedNode Add(AnimatedNode a, AnimatedNode b) { return new AnimatedAddition(a, b); }
        public static AnimatedNode Subtract(AnimatedNode a, AnimatedNode b) { return new AnimatedSubtraction(a, b); }
        public static AnimatedNode Multiply(AnimatedNode a, AnimatedNode b) { return new AnimatedMultiplication(a, b); }
        public static AnimatedNode Divide(AnimatedNode a, AnimatedNode b) { return new AnimatedDivision(a, b); }
        public static AnimatedNode Modulo(AnimatedNode a, double modulus) { return new AnimatedModulo(a, modulus); }
        public static AnimatedNode DiffClamp(AnimatedNode a, double min, double max) { return new AnimatedDiffClamp(a, min, max); }
    }
}
