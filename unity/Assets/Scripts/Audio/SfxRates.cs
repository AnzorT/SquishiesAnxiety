// The rates (and the few volumes and timings) the app's call sites give their sounds, one function per formula, so a
// ported screen plays the same pitch where the app does. tools/unity/audio-test evaluates each against the formula as
// written at its call site in src (it reads the expression out of the JS file), on a spread of inputs.
// Math.random() draws are the caller's (pass the draw; JsRandom-free, so a game's own seeded random can be used).
using System;

namespace SquishSquad.Audio
{
    public static class SfxRates
    {
        // ---- Squish Stack (src/stack/Game.js) ------------------------------------------------------------------------
        /// <summary>rateOf(r): st_lift / st_land / st_cushion by the squishy's size rank r (0 = biggest) of n.</summary>
        public static double Stack(int r, int n) => 1.25 - (0.45 * r) / Math.Max(1, n - 1);
        /// <summary>RESTART's st_undo.</summary>
        public const double StackRestart = 0.8;
        /// <summary>the clock's sd_tick in its last seconds (s = seconds left).</summary>
        public static double StackTick(int s) => s <= 5 ? 1.3 : 1;

        // ---- Blitz pips (Sort's and Stack's Game.js; Squishdoku's BlitzGame.js) ---------------------------------------
        /// <summary>sd_pip when round i (0-based) is cleared, Sort and Stack.</summary>
        public static double BlitzPip(int i) => 0.9 + i * 0.06;
        /// <summary>sd_pip in Squishdoku's Blitz (idx = the puzzle cleared, 0-based).</summary>
        public static double SdBlitzPip(int idx) => 0.9 + Math.Min(12, idx) * 0.05;

        // ---- Squish Sort (src/sort/Game.js) ------------------------------------------------------------------------------
        /// <summary>the deal: fs_pop for the n-th squishy (dealt every 110 ms).</summary>
        public static double SortDeal(int n) => 0.9 + n * 0.07;
        public const double SortDealGapMs = 110;
        /// <summary>the second fs_jump of a jump out.</summary>
        public const double SortJumpAgain = 1.12;

        // ---- Squishdoku (RegularGame.js, BlitzGame.js) -------------------------------------------------------------------
        /// <summary>sd_place, higher with the combo.</summary>
        public static double SdPlace(int combo) => 1 + Math.Min(8, combo) * 0.06;
        /// <summary>sd_tick in the last seconds (sec = seconds left).</summary>
        public static double SdTick(int sec) => sec <= 3 ? 1.3 : 1;
        /// <summary>sd_squeak (a tap on the buddy): rnd = Math.random().</summary>
        public static double SdSqueak(double rnd) => 0.85 + rnd * 0.35;
        /// <summary>sd_x / sd_xOff while dragging marks (a plain tap has no rate): rnd = Math.random().</summary>
        public static double SdMarkDrag(double rnd) => 1 + rnd * 0.2;
        /// <summary>the solve's sd_hop for row r: Regular (delay r x 75 ms).</summary>
        public static double SdHop(int r) => 0.9 + r * 0.06;
        public static double SdHopDelay(int r) => r * 75;
        /// <summary>the solve's sd_hop for row r in Blitz (delay r x 70 ms).</summary>
        public static double SdBlitzHop(int r) => 0.95 + r * 0.06;
        public static double SdBlitzHopDelay(int r) => r * 70;

        // ---- level maps (src/sort/LevelMap.js, src/squishdoku/LevelMap.js; Stack and Hop use Sort's) --------------------
        /// <summary>a map's arrival: six sd_nodePop, k = 0..5, at 120 + k x 70 ms.</summary>
        public static double MapPop(int k) => 0.9 + k * 0.07;
        public static double MapPopAt(int k) => 120 + k * 70;
        public const int MapPops = 6;

        // ---- the game picker (src/screens/GamePicker.js) -----------------------------------------------------------------
        /// <summary>each game's card pops in: sd_nodePop at 200 + index x 110 ms.</summary>
        public static double PickerPop(int index) => 0.95 + index * 0.1;
        public static double PickerPopAt(int index) => 200 + index * 110;

        // ---- the result cards' stars (Stack / Sort / Hop Cards.js: STEP 480 from 380; Squishdoku Overlays.js: 520 from 420)
        /// <summary>the star i (0..2) sound: sd_star1..3 when won, sd_starEmpty when not; sd_perfect after the third.</summary>
        public static string Star(int i, int stars) => i < stars ? "sd_star" + (i + 1) : "sd_starEmpty";
        public static double StarAt(int i, bool squishdoku = false) => squishdoku ? 420 + i * 520 : 380 + i * 480;

        // ---- the locked creature's hold-to-unlock (src/components/CreatureCard.js) ---------------------------------------
        /// <summary>holdLoop starts at this volume; p = the hold's progress 0..1.</summary>
        public const double HoldStartVolume = 0.42;
        public static double HoldRate(double p) => (260 + p * 700) / 260;
        public static double HoldVolume(double p) => (0.05 + p * 0.07) / 0.12;
        public static int HoldStep(double p) => (int)Math.Floor(p * 10);
        /// <summary>the hum's rate is only sent when it moved more than this.</summary>
        public const double HoldRateEpsilon = 0.04;
    }

    /// <summary>CreatureCard.js's hold-to-unlock sound: the hum rises with the hold and a holdStep ticks every tenth.</summary>
    public sealed class HoldHum
    {
        readonly SfxCore.LoopHandle _hum;
        int _lastStep;
        double _lastRate = 1;

        HoldHum(SfxCore.LoopHandle hum) { _hum = hum; }

        public static HoldHum Start() => new HoldHum(Sfx.Loop("holdLoop", SfxRates.HoldStartVolume));

        /// <summary>The hold's progress moved (every frame).</summary>
        public void Progress(double p)
        {
            double rate = SfxRates.HoldRate(p);
            if (Math.Abs(rate - _lastRate) > SfxRates.HoldRateEpsilon)
            {
                _lastRate = rate;
                _hum?.SetRate(rate);
                _hum?.SetVolume(SfxRates.HoldVolume(p));
            }
            int step = SfxRates.HoldStep(p);
            if (step > _lastStep)
            {
                _lastStep = step;
                Sfx.Play("holdStep", rate: rate);
            }
        }

        public void Stop() => _hum?.Stop();
    }
}
