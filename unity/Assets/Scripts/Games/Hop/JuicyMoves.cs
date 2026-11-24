// How Squish Hop's squishies move (src/hop/Pieces.js, freshPose({ juicy: true }), develop): each move is a phase 0 → 1,
// run as ONE linear timing and read through keyframes here; every keyframe list starts and ends at rest, so a phase can
// be left at 0 or 1. HopLevel's Pose holds the phases; Of() turns them into how the squishy is drawn (Pieces.js Piece:
// the lift, the squash and lean from its feet, the head's turn, the mirror).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Hop
{
    public static class JuicyMoves
    {
        // Of a hop: the crouch before take-off (it doesn't travel yet; Game.js holds the travel this long), and of a boing
        // off a bubble, the squash on it
        public const double CROUCH = 0.24, SPRING = 0.2;
        // a friend picked up: a happy little hop with a wiggle, then off to the goal card in a spin (Game.js holds its
        // flight until HAP_GO)
        public const double HAP_GO = 0.32;
        // how far a hop up or down the board leans it away or toward the camera (degrees)
        public const double LEAN_X = 22;
        // stuck: the slow sad sway starts after the droop and the look (Game.js LOOK_MS)
        public const double SAD_SWAY_AT = 850;

        static Interpolator L(double[] at, double[] v, bool clamp = false) => Fx.Lerp(at, v, clamp);

        // a parabola 0 → -1 → 0 from `t0` to 1 (`peak` high), as keyframes
        static Interpolator ArcFrom(double t0, double peak = 1)
        {
            double[] u = { 0, 0.1, 0.25, 0.5, 0.75, 0.9, 1 };
            var at = new List<double>(); var o = new List<double>();
            if (t0 > 0) { at.Add(0); o.Add(0); }
            foreach (var x in u) { at.Add(t0 + x * (1 - t0)); o.Add(-4 * x * (1 - x) * peak); }
            return L(at.ToArray(), o.ToArray());
        }

        // HOP: squashed down in the crouch, stretched tall as it takes off and while it falls; leans back in the crouch,
        // then into the hop (1 = 10°)
        static readonly Interpolator HopArc = ArcFrom(CROUCH);
        static readonly double[] HOP_S = { 0, 0.2, 0.32, 0.48, 0.66, 0.86, 1 };
        static readonly Interpolator HopSx = L(HOP_S, new[] { 1, 1.2, 0.84, 0.92, 1, 0.93, 1 }), HopSy = L(HOP_S, new[] { 1, 0.76, 1.24, 1.1, 1, 1.09, 1 });
        static readonly Interpolator HopLean = L(new[] { 0, 0.2, 0.36, 0.62, 0.9, 1 }, new[] { 0, -0.45, 1.1, 0.5, 0.1, 0 });
        // BOING: squashed flat on the bubble, sprung up tall, a jelly wobble in the air
        static readonly Interpolator BoingArc = ArcFrom(SPRING, 1.15);
        static readonly double[] BOING_S = { 0, 0.07, SPRING, SPRING + 0.08, 0.45, 0.6, 0.75, 0.9, 1 };
        static readonly Interpolator BoingSx = L(BOING_S, new[] { 1, 1.38, 1.3, 0.78, 0.88, 1.09, 0.95, 1.04, 1 }), BoingSy = L(BOING_S, new[] { 1, 0.62, 0.68, 1.38, 1.16, 0.93, 1.06, 0.97, 1 });
        static readonly Interpolator BoingLean = L(new[] { 0, SPRING, SPRING + 0.12, 0.6, 1 }, new[] { 0, -0.2, 1.2, 0.4, 0 });
        // LAND: squashed flat, a springy wobble back up, and the top carried on into the hop and back
        static readonly double[] LAND_S = { 0, 0.08, 0.2, 0.38, 0.56, 0.74, 0.88, 1 };
        static readonly Interpolator LandSx = L(LAND_S, new[] { 1, 1.3, 1.26, 0.9, 1.06, 0.97, 1.01, 1 }), LandSy = L(LAND_S, new[] { 1, 0.7, 0.74, 1.12, 0.95, 1.03, 0.99, 1 });
        static readonly Interpolator LandLean = L(new[] { 0, 0.15, 0.42, 0.66, 1 }, new[] { 0, 0.6, -0.28, 0.1, 0 });
        // JOY: three happy jumps on the ★ (tilting right, then left), the last one higher with a spin round
        static readonly Interpolator JoyArc = L(
            new[] { 0, 0.05, 0.0975, 0.145, 0.1925, 0.24, 0.34, 0.395, 0.45, 0.505, 0.56, 0.64, 0.7175, 0.795, 0.8725, 0.95, 1 },
            new[] { 0, 0, -0.6, -0.8, -0.6, 0, 0, -0.7, -0.95, -0.7, 0, 0, -1.05, -1.4, -1.05, 0, 0 });
        static readonly double[] JOY_S = { 0, 0.03, 0.07, 0.145, 0.22, 0.26, 0.31, 0.37, 0.45, 0.53, 0.57, 0.615, 0.67, 0.8, 0.92, 0.96, 0.985, 1 };
        static readonly Interpolator JoySx = L(JOY_S, new[] { 1, 1.16, 0.86, 1, 0.94, 1.22, 1.16, 0.86, 1, 0.94, 1.22, 1.26, 0.82, 1, 0.94, 1.24, 0.97, 1 });
        static readonly Interpolator JoySy = L(JOY_S, new[] { 1, 0.8, 1.18, 1, 1.08, 0.78, 0.8, 1.2, 1, 1.08, 0.78, 0.72, 1.26, 1, 1.08, 0.76, 1.03, 1 });
        static readonly Interpolator JoyLean = L(new[] { 0, 0.07, 0.145, 0.24, 0.37, 0.45, 0.56, 1 }, new[] { 0, 0.3, 0.8, 0, -0.3, -0.8, 0, 0 });
        static readonly Interpolator JoySpin = L(new[] { 0, 0.66, 0.92, 1 }, new[] { 0.0, 0, 360, 360 });
        // HAP: a friend's happy hop and wiggle, then its spin off to the goal card
        static readonly Interpolator HapArc = L(new[] { 0, 0.03, 0.08, 0.15, 0.22, 0.28, HAP_GO, 0.47, 0.64, 0.82, 1 }, new[] { 0, 0, -1, -1.35, -1, 0, 0, -1.4, -1.8, -1.4, 0 });
        static readonly double[] HAP_S = { 0, 0.03, 0.07, 0.15, 0.28, HAP_GO, 0.38, 0.6, 1 };
        static readonly Interpolator HapSx = L(HAP_S, new[] { 1, 1.14, 0.86, 1, 1.16, 1.12, 0.88, 1, 1 }), HapSy = L(HAP_S, new[] { 1, 0.84, 1.2, 1, 0.84, 0.86, 1.16, 1, 1 });
        static readonly Interpolator HapLean = L(new[] { 0, 0.06, 0.11, 0.16, 0.21, 0.27, 1 }, new[] { 0, 0.8, -0.8, 0.7, -0.5, 0, 0 });
        static readonly Interpolator HapSpin = L(new[] { 0, 0.4, 0.85, 1 }, new[] { 0.0, 0, 360, 360 });
        // a bump: squished against the way it can't go (by ex, ey); `no`, a shake of the head (degrees)
        static readonly Interpolator BumpSquish = L(new[] { 0, 0.3, 0.42, 0.7, 1 }, new[] { 0, 0.7, 1, 0.15, 0 });
        static readonly Interpolator BumpOut = L(new[] { 0, 0.4, 1 }, new[] { 0.0, 1, 0 });
        static readonly Interpolator NoDeg = L(new[] { 0, 0.22, 0.32, 0.46, 0.6, 0.74, 0.86, 1 }, new[] { 0.0, 0, 36, -32, 22, -11, 4, 0 });
        // stuck: a look to the left, then to the right (degrees)
        static readonly Interpolator LookDeg = L(new[] { 0, 0.25, 0.35, 0.5, 0.62, 0.78, 0.9, 1 }, new[] { 0.0, 0, -32, -32, 32, 32, 0, 0 });
        // a tap on the squishy itself: a wiggle
        static readonly Interpolator Wig = L(new[] { 0, 0.25, 0.6, 1 }, new[] { 0, -0.6, 0.6, 0 });
        // drooped (stuck): sunk down and wide, its top hanging toward the camera
        const double DROOP_X = 1.08, DROOP_Y = 0.86, DROOP_TILT = -14;
        // two squashes at once (a landing still wobbling as the next hop crouches) give way softly
        static readonly Interpolator SoftX = L(new[] { 0, 0.7, 1.34, 3 }, new[] { 0.64, 0.7, 1.34, 1.46 }), SoftY = L(new[] { 0, 0.66, 1.36, 3 }, new[] { 0.6, 0.66, 1.36, 1.5 });
        static readonly Interpolator ShadowK = L(new[] { -1.8, 0 }, new[] { 0.45, 1 }, true);

        /// <summary>How a squishy is drawn this frame: its shadow's scale, the lift and bump (dp), the squash, the lean
        /// sideways (rz, 1 = 10°) and toward the camera (rx, degrees), its head's turn (yaw, degrees) and the mirror.</summary>
        public struct Look { public double ShadowK, Lift, Bx, By, Sx, Sy, Rz, Rx, Yaw, Face; }

        public static Look Of(double hp, double bp, double land, double joy, double hap, double bump, double ex, double ey, double droop,
            double rot, double wig, double lx, double lzDeg, double no, double look, double liftH, double dx, double dy, double face)
        {
            double arc = HopArc.Evaluate(hp) + BoingArc.Evaluate(bp) + JoyArc.Evaluate(joy) + HapArc.Evaluate(hap);
            double lean = HopLean.Evaluate(hp) + BoingLean.Evaluate(bp) + LandLean.Evaluate(land);
            double squish = BumpSquish.Evaluate(bump), o = BumpOut.Evaluate(bump);
            double ax = HopSx.Evaluate(hp) * BoingSx.Evaluate(bp) * LandSx.Evaluate(land) * JoySx.Evaluate(joy) * HapSx.Evaluate(hap) * (1 + squish * ex) * (1 + (DROOP_X - 1) * droop);
            double ay = HopSy.Evaluate(hp) * BoingSy.Evaluate(bp) * LandSy.Evaluate(land) * JoySy.Evaluate(joy) * HapSy.Evaluate(hap) * (1 + squish * ey) * (1 + (DROOP_Y - 1) * droop);
            return new Look
            {
                ShadowK = ShadowK.Evaluate(arc),
                Lift = arc * liftH,
                Bx = o * dx,
                By = o * dy,
                Sx = SoftX.Evaluate(ax),
                Sy = SoftY.Evaluate(ay),
                Rz = rot + Wig.Evaluate(wig) + lean * lx + JoyLean.Evaluate(joy) + HapLean.Evaluate(hap),
                Rx = lean * lzDeg + DROOP_TILT * droop,
                Yaw = NoDeg.Evaluate(no) + LookDeg.Evaluate(look) + JoySpin.Evaluate(joy) + HapSpin.Evaluate(hap),
                Face = face,
            };
        }
    }
}
