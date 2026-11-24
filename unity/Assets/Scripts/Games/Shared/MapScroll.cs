// A sideways ScrollView's finger and fling, as the phone does it: React Native's horizontal ScrollView is Android's
// HorizontalScrollView, and Chrome on Android flings with a port of the same OverScroller (ui/events/android/scroller),
// so the feel is Android's in both:
//   drag   nothing moves until the finger has gone the touch slop (8 dp) sideways; from there the content follows it
//          1:1 (the slop taken off, so it doesn't jump)
//   fling  on lifting, the finger's velocity (VelocityTracker's default "lsq2": a quadratic fitted to the last 100 ms
//          of moves) flings it if it's over 50 dp/s (at most 8000 dp/s), along OverScroller's spline: the distance and
//          the duration from the velocity and the scroll friction (0.015), slowing down along the spline's table; a
//          fling that would pass an edge stops on it, its duration cut where the spline reaches it (adjustDuration)
//   a finger down while it flings stops it, and that touch drags (it isn't a tap)
// Not copied: the edge's overscroll glow / stretch. Units: dp and ms in, the density for the physics' pixels.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Shared
{
    public sealed class MapScroll
    {
        public float Density = 2.8125f;            // px per dp (the physics are Android's, in px)
        public double X;                           // the scroll offset, dp
        public double Max;                         // the furthest it scrolls, dp
        public bool Dragging { get; private set; }
        public bool Flinging => _fling != null;
        /// <summary>The touch went down on a moving fling, or moved past the slop: it isn't a tap.</summary>
        public bool NotATap { get; private set; }

        const float TouchSlopDp = 8, MinFlingDp = 50, MaxFlingDp = 8000;
        float _lastX;
        bool _down;
        readonly List<(double t, double x)> _samples = new List<(double, double)>();
        Fling _fling;

        public void ScrollTo(double x) { _fling = null; X = Clamp(x); }
        double Clamp(double x) => Math.Max(0, Math.Min(Max, x));

        public void Down(float x, double now)
        {
            _down = true;
            NotATap = _fling != null;
            Dragging = _fling != null;
            _fling = null;
            _lastX = x;
            _samples.Clear();
            _samples.Add((now, x));
        }

        public void Move(float x, double now)
        {
            if (!_down) return;
            _samples.Add((now, x));
            float delta = _lastX - x;
            float slop = TouchSlopDp;
            if (!Dragging && Math.Abs(delta) > slop)
            {
                Dragging = true;
                NotATap = true;
                delta += delta > 0 ? -slop : slop;
            }
            if (Dragging)
            {
                _lastX = x;
                X = Clamp(X + delta);
            }
        }

        public void Up(float x, double now)
        {
            if (!_down) return;
            Move(x, now);
            _down = false;
            bool dragged = Dragging;
            Dragging = false;
            if (!dragged) return;
            double v = Velocity(now) * Density;   // px/s
            double max = MaxFlingDp * Density, min = MinFlingDp * Density;
            v = Math.Max(-max, Math.Min(max, v));
            if (Math.Abs(v) > min) _fling = new Fling(X * Density, -v, 0, Max * Density, now, Density);
        }

        /// <summary>Moves a fling on to `now`.</summary>
        public void Update(double now)
        {
            if (_fling == null) return;
            bool done = _fling.Update(now);
            X = Clamp(_fling.Position / Density);
            if (done) _fling = null;
        }

        // ---- VelocityTracker, "lsq2" (unweighted): x(t) fitted by a quadratic over the last 100 ms, dx/dt at the last
        // sample, in dp/s; nothing if the finger had stopped 40 ms before it lifted
        double Velocity(double now)
        {
            if (_samples.Count == 0) return 0;
            var last = _samples[_samples.Count - 1];
            var pts = new List<(double t, double x)>();
            for (int i = _samples.Count - 1; i >= 0 && pts.Count < 20; i--)
            {
                var s = _samples[i];
                if (last.t - s.t > 100) break;
                if (pts.Count > 0 && pts[pts.Count - 1].t - s.t > 40) break;
                pts.Add(((s.t - last.t) / 1000.0, s.x));
            }
            int n = pts.Count;
            if (n < 2) return 0;
            int degree = Math.Min(2, n - 1);
            // least squares: sum over samples of [1 t t²] ⊗ [1 t t²], against x
            int k = degree + 1;
            var A = new double[k, k + 1];
            foreach (var (t, x) in pts)
            {
                var row = new double[k];
                for (int j = 0; j < k; j++) row[j] = Math.Pow(t, j);
                for (int r = 0; r < k; r++) { for (int c = 0; c < k; c++) A[r, c] += row[r] * row[c]; A[r, k] += row[r] * x; }
            }
            // Gauss-Jordan
            for (int c = 0; c < k; c++)
            {
                int p = c;
                for (int r = c + 1; r < k; r++) if (Math.Abs(A[r, c]) > Math.Abs(A[p, c])) p = r;
                if (Math.Abs(A[p, c]) < 1e-12) return 0;
                if (p != c) for (int j = 0; j <= k; j++) { var tmp = A[c, j]; A[c, j] = A[p, j]; A[p, j] = tmp; }
                for (int r = 0; r < k; r++)
                {
                    if (r == c) continue;
                    double f = A[r, c] / A[c, c];
                    for (int j = c; j <= k; j++) A[r, j] -= f * A[c, j];
                }
            }
            return A[1, k] / A[1, 1];
        }

        // ---- OverScroller's SplineOverScroller.fling -----------------------------------------------------------------
        sealed class Fling
        {
            const int NB_SAMPLES = 100;
            const float INFLEXION = 0.35f, START_TENSION = 0.5f, END_TENSION = 1.0f;
            const float P1 = START_TENSION * INFLEXION, P2 = 1.0f - END_TENSION * (1.0f - INFLEXION);
            static readonly float DECELERATION_RATE = (float)(Math.Log(0.78) / Math.Log(0.9));
            static readonly float[] SPLINE_POSITION = new float[NB_SAMPLES + 1], SPLINE_TIME = new float[NB_SAMPLES + 1];

            static Fling()
            {
                float x_min = 0.0f, y_min = 0.0f;
                for (int i = 0; i < NB_SAMPLES; i++)
                {
                    float alpha = (float)i / NB_SAMPLES;
                    float x_max = 1.0f, x, tx, coef;
                    while (true)
                    {
                        x = x_min + (x_max - x_min) / 2.0f;
                        coef = 3.0f * x * (1.0f - x);
                        tx = coef * ((1.0f - x) * P1 + x * P2) + x * x * x;
                        if (Math.Abs(tx - alpha) < 1E-5) break;
                        if (tx > alpha) x_max = x; else x_min = x;
                    }
                    SPLINE_POSITION[i] = coef * ((1.0f - x) * START_TENSION + x) + x * x * x;
                    float y_max = 1.0f, y, dy;
                    while (true)
                    {
                        y = y_min + (y_max - y_min) / 2.0f;
                        coef = 3.0f * y * (1.0f - y);
                        dy = coef * ((1.0f - y) * START_TENSION + y) + y * y * y;
                        if (Math.Abs(dy - alpha) < 1E-5) break;
                        if (dy > alpha) y_max = y; else y_min = y;
                    }
                    SPLINE_TIME[i] = coef * ((1.0f - y) * P1 + y * P2) + y * y * y;
                }
                SPLINE_POSITION[NB_SAMPLES] = SPLINE_TIME[NB_SAMPLES] = 1.0f;
            }

            readonly double _start, _t0, _splineDistance, _splineDuration;
            double _duration;
            public double Position;

            public Fling(double start, double velocity, double min, double max, double now, float density)
            {
                float ppi = density * 160.0f;
                double physicalCoeff = 9.80665f * 39.37f * ppi * 0.84f;
                const float friction = 0.015f;
                double l = Math.Log(INFLEXION * Math.Abs(velocity) / (friction * physicalCoeff));
                _duration = _splineDuration = (int)(1000.0 * Math.Exp(l / (DECELERATION_RATE - 1.0)));
                double total = friction * physicalCoeff * Math.Exp(DECELERATION_RATE / (DECELERATION_RATE - 1.0) * l);
                _splineDistance = (int)(total * Math.Sign(velocity));
                _start = start; _t0 = now; Position = start;
                double fin = start + _splineDistance;
                if (fin < min) Adjust(fin - start, min - start);
                else if (fin > max) Adjust(fin - start, max - start);
            }

            // adjustDuration: the fling stops where the spline reaches the edge
            void Adjust(double oldDistance, double newDistance)
            {
                float x = (float)Math.Abs(newDistance / oldDistance);
                int index = (int)(NB_SAMPLES * x);
                if (index < NB_SAMPLES)
                {
                    float x_inf = (float)index / NB_SAMPLES, x_sup = (float)(index + 1) / NB_SAMPLES;
                    float t_inf = SPLINE_TIME[index], t_sup = SPLINE_TIME[index + 1];
                    float timeCoef = t_inf + (x - x_inf) / (x_sup - x_inf) * (t_sup - t_inf);
                    _duration *= timeCoef;
                }
            }

            /// <summary>true when it's over (update(): the spline over its own duration, finished at mDuration).</summary>
            public bool Update(double now)
            {
                double t = Math.Min(now - _t0, _duration);
                float x = _splineDuration > 0 ? (float)(t / _splineDuration) : 1;
                int index = (int)(NB_SAMPLES * x);
                float coef = 1;
                if (index < NB_SAMPLES)
                {
                    float t_inf = (float)index / NB_SAMPLES, t_sup = (float)(index + 1) / NB_SAMPLES;
                    float d_inf = SPLINE_POSITION[index], d_sup = SPLINE_POSITION[index + 1];
                    coef = d_inf + (x - t_inf) * ((d_sup - d_inf) / (t_sup - t_inf));
                }
                Position = _start + Math.Round(coef * _splineDistance);
                return now - _t0 >= _duration;
            }
        }
    }
}
