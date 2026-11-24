#nullable enable

using System;

namespace Facebook.Yoga
{
    public static class NumericComparison
    {
        public static bool IsUndefined(float value)
        {
            return float.IsNaN(value);
        }
    }

    public struct CachedMeasurement : IEquatable<CachedMeasurement>
    {
        public float AvailableWidth;
        public float AvailableHeight;
        public SizingMode WidthSizingMode;
        public SizingMode HeightSizingMode;

        public float ComputedWidth;
        public float ComputedHeight;

        // C# 9 has no parameterless struct constructors: this factory replaces the
        // upstream `public CachedMeasurement()` constructor (same initial values).
        public static CachedMeasurement Create()
        {
            CachedMeasurement m = default;
            m.AvailableWidth = -1;
            m.AvailableHeight = -1;
            m.WidthSizingMode = SizingMode.MaxContent;
            m.HeightSizingMode = SizingMode.MaxContent;
            m.ComputedWidth = -1;
            m.ComputedHeight = -1;
            return m;
        }

        public bool Equals(CachedMeasurement measurement)
        {
            bool isEqual = WidthSizingMode == measurement.WidthSizingMode &&
                           HeightSizingMode == measurement.HeightSizingMode;

            if (!NumericComparison.IsUndefined(AvailableWidth) ||
                !NumericComparison.IsUndefined(measurement.AvailableWidth))
            {
                isEqual = isEqual && AvailableWidth == measurement.AvailableWidth;
            }

            if (!NumericComparison.IsUndefined(AvailableHeight) ||
                !NumericComparison.IsUndefined(measurement.AvailableHeight))
            {
                isEqual = isEqual && AvailableHeight == measurement.AvailableHeight;
            }

            if (!NumericComparison.IsUndefined(ComputedWidth) ||
                !NumericComparison.IsUndefined(measurement.ComputedWidth))
            {
                isEqual = isEqual && ComputedWidth == measurement.ComputedWidth;
            }

            if (!NumericComparison.IsUndefined(ComputedHeight) ||
                !NumericComparison.IsUndefined(measurement.ComputedHeight))
            {
                isEqual = isEqual && ComputedHeight == measurement.ComputedHeight;
            }

            return isEqual;
        }

        public static bool operator ==(CachedMeasurement left, CachedMeasurement right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CachedMeasurement left, CachedMeasurement right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is CachedMeasurement measurement && Equals(measurement);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                AvailableWidth, AvailableHeight,
                WidthSizingMode, HeightSizingMode,
                ComputedWidth, ComputedHeight
            );
        }
    }
}

