// Ports of nodes/AnimatedNode.js, AnimatedValue.js, AnimatedValueXY.js and the arithmetic nodes
// (AnimatedAddition/Subtraction/Multiplication/Division/Modulo/DiffClamp.js).
//
// Values are pull-based like the JS: read GetValue() whenever you need it (e.g. after Animator.Tick).
// Listeners (AddListener) are supported on AnimatedValue / AnimatedValueXY, called on every update as in JS.
// Not ported: tracking (toValue given as another animated node), native-driver plumbing, the view-attach
// graph (_flush / __attach, which only matters for React views).
using System;
using System.Collections.Generic;

namespace SquishSquad.Anim
{
    public abstract class AnimatedNode
    {
        public abstract double GetValue();

        public AnimatedInterpolation Interpolate(InterpolationConfig config)
        {
            return new AnimatedInterpolation(this, config);
        }

        public AnimatedInterpolation Interpolate(double[] inputRange, double[] outputRange, Extrapolate extrapolate = Extrapolate.Extend, Func<double, double> easing = null)
        {
            return new AnimatedInterpolation(this, new InterpolationConfig { InputRange = inputRange, OutputRange = outputRange, Extrapolate = extrapolate, Easing = easing });
        }

        public AnimatedInterpolation Interpolate(double[] inputRange, string[] outputRange, Extrapolate extrapolate = Extrapolate.Extend, Func<double, double> easing = null)
        {
            return new AnimatedInterpolation(this, new InterpolationConfig { InputRange = inputRange, OutputRangeStrings = outputRange, Extrapolate = extrapolate, Easing = easing });
        }

        /// <summary>A plain number where a node is expected (Animated.add(v, 5)) becomes an AnimatedValue, as in JS.</summary>
        public static implicit operator AnimatedNode(double value) { return new AnimatedValue(value); }
    }

    public class AnimatedValue : AnimatedNode
    {
        double _value;
        double _offset;
        readonly double _startingValue;
        Animation _animation;

        sealed class Listener { public int Id; public Action<double> Callback; public bool Removed; }
        readonly List<Listener> _listeners = new List<Listener>();
        int _iterating;
        bool _dirty;
        static int _uniqueId = 1;

        Action<double> _updateFromAnimation;

        public AnimatedValue(double value)
        {
            _startingValue = _value = value;
            _offset = 0;
        }

        /// <summary>value + offset (JS __getValue).</summary>
        public override double GetValue() { return _value + _offset; }

        /// <summary>The value without the offset (JS _value).</summary>
        public double BaseValue => _value;
        public double Offset => _offset;
        public bool IsAnimating => _animation != null;

        /// <summary>Stops any running animation and sets the value; listeners are called.</summary>
        public void SetValue(double value)
        {
            if (_animation != null)
            {
                _animation.Stop();
                _animation = null;
            }
            UpdateValue(value);
        }

        public void SetOffset(double offset) { _offset = offset; }

        public void FlattenOffset()
        {
            _value += _offset;
            _offset = 0;
        }

        public void ExtractOffset()
        {
            _offset += _value;
            _value = 0;
        }

        /// <summary>Stops any running animation; callback gets the value it stopped at.</summary>
        public void StopAnimation(Action<double> callback = null)
        {
            StopTracking();
            var a = _animation;
            if (a != null) a.Stop();
            _animation = null;
            if (callback != null) callback(GetValue());
        }

        /// <summary>Stops any animation and resets the value to the one it was created with (no listeners called).</summary>
        public void ResetAnimation(Action<double> callback = null)
        {
            StopAnimation(callback);
            _value = _startingValue;
        }

        /// <summary>Runs an animation on this value (normally via Animated.Timing etc.). Stops the previous one.</summary>
        public void Animate(Animation animation, Action<EndResult> callback)
        {
            var previousAnimation = _animation;
            var cur = _animation;
            if (cur != null) cur.Stop();
            _animation = animation;
            if (_updateFromAnimation == null) _updateFromAnimation = UpdateValue;
            animation.Start(_value, _updateFromAnimation, result =>
            {
                _animation = null;
                if (callback != null) callback(result);
            }, previousAnimation, this);
        }

        internal void StopTracking() { }

        public int AddListener(Action<double> callback)
        {
            int id = _uniqueId++;
            _listeners.Add(new Listener { Id = id, Callback = callback });
            return id;
        }

        public void RemoveListener(int id)
        {
            for (int i = 0; i < _listeners.Count; i++)
            {
                var l = _listeners[i];
                if (l.Id == id && !l.Removed)
                {
                    l.Removed = true;
                    if (_iterating > 0) _dirty = true;
                    else _listeners.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAllListeners()
        {
            for (int i = 0; i < _listeners.Count; i++) _listeners[i].Removed = true;
            if (_iterating > 0) _dirty = true;
            else _listeners.Clear();
        }

        public bool HasListeners
        {
            get
            {
                for (int i = 0; i < _listeners.Count; i++) if (!_listeners[i].Removed) return true;
                return false;
            }
        }

        void UpdateValue(double value)
        {
            _value = value;
            CallListeners(GetValue());
        }

        // JS iterates the listener object with for-in: listeners added meanwhile aren't visited, removed ones are skipped.
        void CallListeners(double value)
        {
            int n = _listeners.Count;
            if (n == 0) return;
            _iterating++;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    var l = _listeners[i];
                    if (!l.Removed) l.Callback(value);
                }
            }
            finally
            {
                _iterating--;
                if (_iterating == 0 && _dirty)
                {
                    _dirty = false;
                    _listeners.RemoveAll(l => l.Removed);
                }
            }
        }
    }

    public readonly struct XY
    {
        public readonly double X, Y;
        public XY(double x, double y) { X = x; Y = y; }
        public override string ToString() { return "{x: " + JsNumber.ToString(X) + ", y: " + JsNumber.ToString(Y) + "}"; }
    }

    /// <summary>AnimatedValueXY.js: two AnimatedValues animated together.</summary>
    public sealed class AnimatedValueXY
    {
        public readonly AnimatedValue X;
        public readonly AnimatedValue Y;
        readonly Dictionary<int, KeyValuePair<int, int>> _listeners = new Dictionary<int, KeyValuePair<int, int>>();
        static int _uniqueId = 1;

        public AnimatedValueXY(double x = 0, double y = 0)
        {
            X = new AnimatedValue(x);
            Y = new AnimatedValue(y);
        }

        public AnimatedValueXY(AnimatedValue x, AnimatedValue y)
        {
            X = x ?? throw new ArgumentNullException(nameof(x));
            Y = y ?? throw new ArgumentNullException(nameof(y));
        }

        public XY GetValue() { return new XY(X.GetValue(), Y.GetValue()); }
        public void SetValue(double x, double y) { X.SetValue(x); Y.SetValue(y); }
        public void SetOffset(double x, double y) { X.SetOffset(x); Y.SetOffset(y); }
        public void FlattenOffset() { X.FlattenOffset(); Y.FlattenOffset(); }
        public void ExtractOffset() { X.ExtractOffset(); Y.ExtractOffset(); }

        public void ResetAnimation(Action<XY> callback = null)
        {
            X.ResetAnimation();
            Y.ResetAnimation();
            if (callback != null) callback(GetValue());
        }

        public void StopAnimation(Action<XY> callback = null)
        {
            X.StopAnimation();
            Y.StopAnimation();
            if (callback != null) callback(GetValue());
        }

        /// <summary>Called when either axis updates, with both values.</summary>
        public int AddListener(Action<XY> callback)
        {
            int id = _uniqueId++;
            Action<double> joint = _ => callback(GetValue());
            _listeners[id] = new KeyValuePair<int, int>(X.AddListener(joint), Y.AddListener(joint));
            return id;
        }

        public void RemoveListener(int id)
        {
            KeyValuePair<int, int> ids;
            if (!_listeners.TryGetValue(id, out ids)) return;
            X.RemoveListener(ids.Key);
            Y.RemoveListener(ids.Value);
            _listeners.Remove(id);
        }

        public void RemoveAllListeners()
        {
            X.RemoveAllListeners();
            Y.RemoveAllListeners();
            _listeners.Clear();
        }
    }

    public sealed class AnimatedAddition : AnimatedNode
    {
        readonly AnimatedNode _a, _b;
        public AnimatedAddition(AnimatedNode a, AnimatedNode b) { _a = a; _b = b; }
        public override double GetValue() { return _a.GetValue() + _b.GetValue(); }
    }

    public sealed class AnimatedSubtraction : AnimatedNode
    {
        readonly AnimatedNode _a, _b;
        public AnimatedSubtraction(AnimatedNode a, AnimatedNode b) { _a = a; _b = b; }
        public override double GetValue() { return _a.GetValue() - _b.GetValue(); }
    }

    public sealed class AnimatedMultiplication : AnimatedNode
    {
        readonly AnimatedNode _a, _b;
        public AnimatedMultiplication(AnimatedNode a, AnimatedNode b) { _a = a; _b = b; }
        public override double GetValue() { return _a.GetValue() * _b.GetValue(); }
    }

    /// <summary>a / b, and 0 when b is 0 (the JS also logs an error).</summary>
    public sealed class AnimatedDivision : AnimatedNode
    {
        readonly AnimatedNode _a, _b;
        public AnimatedDivision(AnimatedNode a, AnimatedNode b) { _a = a; _b = b; }
        public override double GetValue()
        {
            double a = _a.GetValue();
            double b = _b.GetValue();
            if (b == 0) return 0;
            return a / b;
        }
    }

    public sealed class AnimatedModulo : AnimatedNode
    {
        readonly AnimatedNode _a;
        readonly double _modulus;
        public AnimatedModulo(AnimatedNode a, double modulus) { _a = a; _modulus = modulus; }
        public override double GetValue() { return (_a.GetValue() % _modulus + _modulus) % _modulus; }
    }

    /// <summary>Stateful: each GetValue() moves by the parent's change since the last read, clamped.</summary>
    public sealed class AnimatedDiffClamp : AnimatedNode
    {
        readonly AnimatedNode _a;
        readonly double _min, _max;
        double _value, _lastValue;
        public AnimatedDiffClamp(AnimatedNode a, double min, double max)
        {
            _a = a; _min = min; _max = max;
            _value = _lastValue = _a.GetValue();
        }
        public override double GetValue()
        {
            double value = _a.GetValue();
            double diff = value - _lastValue;
            _lastValue = value;
            _value = JsMath.Min(JsMath.Max(_value + diff, _min), _max);
            return _value;
        }
    }
}
