// Port of nodes/AnimatedInterpolation.js: value.interpolate({inputRange, outputRange, easing, extrapolate*}).
// Numeric output ranges give a number (GetValue). String output ranges ('0deg'..'6deg', '0%', '#rrggbb',
// 'rgba(...)', any strings of the same shape) give the string RN would produce (GetString), and each number
// in it separately (GetNumber(i)), after the same rounding (r, g, b to integers and alpha to 3 decimals when
// the shape is rgb/rgba).
// The JS's dev-mode checks (ranges of 2+ values, same lengths, non-decreasing input, not ]-inf, +inf[, same
// string shapes) throw ArgumentException here.
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SquishSquad.Anim
{
    public enum Extrapolate { Extend, Clamp, Identity }

    public sealed class InterpolationConfig
    {
        public double[] InputRange;
        /// <summary>Numeric output range (set this or OutputRangeStrings).</summary>
        public double[] OutputRange;
        /// <summary>String output range, e.g. { "0deg", "6deg" } or colors.</summary>
        public string[] OutputRangeStrings;
        /// <summary>null: linear.</summary>
        public Func<double, double> Easing;
        public Extrapolate? Extrapolate;
        public Extrapolate? ExtrapolateLeft;
        public Extrapolate? ExtrapolateRight;
    }

    /// <summary>The numeric interpolation function (createInterpolation for number outputs).</summary>
    public sealed class Interpolator
    {
        readonly double[] _inputRange;
        readonly double[] _outputRange;
        readonly Func<double, double> _easing;
        readonly Extrapolate _left, _right;

        public Interpolator(double[] inputRange, double[] outputRange, Func<double, double> easing, Extrapolate? extrapolate, Extrapolate? extrapolateLeft, Extrapolate? extrapolateRight)
        {
            if (inputRange == null || outputRange == null) throw new ArgumentException("inputRange and outputRange are required");
            CheckInfiniteRange("outputRange", outputRange);
            CheckInfiniteRange("inputRange", inputRange);
            CheckValidInputRange(inputRange);
            if (inputRange.Length != outputRange.Length)
                throw new ArgumentException("inputRange (" + inputRange.Length + ") and outputRange (" + outputRange.Length + ") must have the same length");
            _inputRange = (double[])inputRange.Clone();
            _outputRange = (double[])outputRange.Clone();
            _easing = easing;
            _left = extrapolateLeft ?? extrapolate ?? Anim.Extrapolate.Extend;
            _right = extrapolateRight ?? extrapolate ?? Anim.Extrapolate.Extend;
        }

        public double Evaluate(double input)
        {
            int range = FindRange(input, _inputRange);
            return Interpolate(input, _inputRange[range], _inputRange[range + 1], _outputRange[range], _outputRange[range + 1], _easing, _left, _right);
        }

        static double Interpolate(double input, double inputMin, double inputMax, double outputMin, double outputMax, Func<double, double> easing, Extrapolate extrapolateLeft, Extrapolate extrapolateRight)
        {
            double result = input;
            if (result < inputMin)
            {
                if (extrapolateLeft == Extrapolate.Identity) return result;
                if (extrapolateLeft == Extrapolate.Clamp) result = inputMin;
            }
            if (result > inputMax)
            {
                if (extrapolateRight == Extrapolate.Identity) return result;
                if (extrapolateRight == Extrapolate.Clamp) result = inputMax;
            }
            if (outputMin == outputMax) return outputMin;
            if (inputMin == inputMax)
            {
                if (input <= inputMin) return outputMin;
                return outputMax;
            }

            if (double.IsNegativeInfinity(inputMin)) result = -result;
            else if (double.IsPositiveInfinity(inputMax)) result = result - inputMin;
            else result = (result - inputMin) / (inputMax - inputMin);

            result = easing == null ? result : easing(result);

            if (double.IsNegativeInfinity(outputMin)) result = -result;
            else if (double.IsPositiveInfinity(outputMax)) result = result + outputMin;
            else result = result * (outputMax - outputMin) + outputMin;
            return result;
        }

        static int FindRange(double input, double[] inputRange)
        {
            int i;
            for (i = 1; i < inputRange.Length - 1; ++i)
            {
                if (inputRange[i] >= input) break;
            }
            return i - 1;
        }

        static void CheckValidInputRange(double[] arr)
        {
            if (arr.Length < 2) throw new ArgumentException("inputRange must have at least 2 elements");
            for (int i = 1; i < arr.Length; ++i)
            {
                if (!(arr[i] >= arr[i - 1])) throw new ArgumentException("inputRange must be monotonically non-decreasing");
            }
        }

        static void CheckInfiniteRange(string name, double[] arr)
        {
            if (arr.Length < 2) throw new ArgumentException(name + " must have at least 2 elements");
            if (arr.Length == 2 && double.IsNegativeInfinity(arr[0]) && double.IsPositiveInfinity(arr[1]))
                throw new ArgumentException(name + "cannot be ]-infinity;+infinity[");
        }
    }

    /// <summary>createInterpolationFromStringOutputRange.</summary>
    public sealed class StringInterpolator
    {
        static readonly Regex StringShape = new Regex(@"[+-]?(?:\d+\.?\d*|\.\d+)(?:[eE][+-]?\d+)?", RegexOptions.ECMAScript | RegexOptions.CultureInvariant);

        readonly string[] _literals; // text around the numbers of outputRange[0]: literals.Length == numbers + 1
        readonly Interpolator[] _interpolations;
        readonly bool _shouldRound;
        readonly StringBuilder _sb = new StringBuilder(32);

        public int ComponentCount => _interpolations.Length;

        public StringInterpolator(InterpolationConfig config)
        {
            var outputRange = config.OutputRangeStrings;
            if (outputRange == null || outputRange.Length < 2) throw new ArgumentException("Bad output range");
            var mapped = new string[outputRange.Length];
            for (int i = 0; i < outputRange.Length; i++) mapped[i] = ColorToRgba(outputRange[i]);
            CheckPattern(mapped);

            var first = StringShape.Matches(mapped[0]);
            if (first.Count == 0) throw new ArgumentException("outputRange has no numbers: " + mapped[0]);
            var ranges = new List<double>[first.Count];
            for (int i = 0; i < ranges.Length; i++) ranges[i] = new List<double>();
            foreach (var value in mapped)
            {
                var ms = StringShape.Matches(value);
                for (int i = 0; i < ms.Count; i++)
                {
                    if (i >= ranges.Length) throw new ArgumentException("invalid pattern " + mapped[0] + " and " + value);
                    ranges[i].Add(JsNumber.ParseNumber(ms[i].Value));
                }
            }

            _interpolations = new Interpolator[first.Count];
            for (int i = 0; i < first.Count; i++)
                _interpolations[i] = new Interpolator(config.InputRange, ranges[i].ToArray(), config.Easing, config.Extrapolate, config.ExtrapolateLeft, config.ExtrapolateRight);

            _literals = new string[first.Count + 1];
            int pos = 0;
            for (int i = 0; i < first.Count; i++)
            {
                _literals[i] = mapped[0].Substring(pos, first[i].Index - pos);
                pos = first[i].Index + first[i].Length;
            }
            _literals[first.Count] = mapped[0].Substring(pos);
            _shouldRound = mapped[0].StartsWith("rgb", StringComparison.Ordinal);
        }

        /// <summary>The i-th number of the output for this input, rounded as RN rounds it before printing.</summary>
        public double EvaluateComponent(int i, double input)
        {
            double val = _interpolations[i].Evaluate(input);
            if (_shouldRound) val = i < 3 ? JsMath.Round(val) : JsMath.Round(val * 1000) / 1000;
            return val;
        }

        public string Evaluate(double input)
        {
            _sb.Length = 0;
            for (int i = 0; i < _interpolations.Length; i++)
            {
                _sb.Append(_literals[i]);
                _sb.Append(JsNumber.ToString(EvaluateComponent(i, input)));
            }
            _sb.Append(_literals[_interpolations.Length]);
            return _sb.ToString();
        }

        /// <summary>colorToRgba: a color string becomes "rgba(r, g, b, a)"; anything else is returned as is.</summary>
        public static string ColorToRgba(string input)
        {
            uint? n = NormalizeColor.Normalize(input);
            if (!n.HasValue) return input;
            uint c = n.Value;
            uint r = (c & 0xff000000) >> 24;
            uint g = (c & 0x00ff0000) >> 16;
            uint b = (c & 0x0000ff00) >> 8;
            double a = (c & 0x000000ff) / 255.0;
            return "rgba(" + r + ", " + g + ", " + b + ", " + JsNumber.ToString(a) + ")";
        }

        static void CheckPattern(string[] arr)
        {
            string pattern = StringShape.Replace(arr[0], "");
            for (int i = 1; i < arr.Length; ++i)
            {
                if (pattern != StringShape.Replace(arr[i], ""))
                    throw new ArgumentException("invalid pattern " + arr[0] + " and " + arr[i]);
            }
        }
    }

    public sealed class AnimatedInterpolation : AnimatedNode
    {
        readonly AnimatedNode _parent;
        readonly Interpolator _numeric;
        readonly StringInterpolator _string;

        public AnimatedInterpolation(AnimatedNode parent, InterpolationConfig config)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
            if (config.OutputRangeStrings != null) _string = new StringInterpolator(config);
            else _numeric = new Interpolator(config.InputRange, config.OutputRange, config.Easing, config.Extrapolate, config.ExtrapolateLeft, config.ExtrapolateRight);
        }

        public bool IsString => _string != null;

        /// <summary>The interpolated number. Throws for string output ranges (use GetString / GetNumber).</summary>
        public override double GetValue()
        {
            if (_string != null) throw new InvalidOperationException("Cannot interpolate an input which is not a number: this interpolation has string outputs (use GetString or GetNumber)");
            return _numeric.Evaluate(_parent.GetValue());
        }

        /// <summary>The output as RN gives it: the string for string ranges, String(number) for numeric ones.</summary>
        public string GetString()
        {
            if (_string != null) return _string.Evaluate(_parent.GetValue());
            return JsNumber.ToString(_numeric.Evaluate(_parent.GetValue()));
        }

        /// <summary>Number of numbers in a string output (1 for '6deg', 4 for colors); 1 for numeric outputs.</summary>
        public int ComponentCount => _string != null ? _string.ComponentCount : 1;

        /// <summary>The i-th number of the output (e.g. the degrees of '6deg', or r, g, b, a), allocation-free.</summary>
        public double GetNumber(int i = 0)
        {
            if (_string != null) return _string.EvaluateComponent(i, _parent.GetValue());
            if (i != 0) throw new ArgumentOutOfRangeException(nameof(i));
            return _numeric.Evaluate(_parent.GetValue());
        }
    }
}
