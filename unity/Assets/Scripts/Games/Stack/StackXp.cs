// The slice of the player's XP that Squish Stack's rewards use, ported from src/playerXp.js (addXp, gameXp, winXp,
// pxpOf, xpRules) and functions/squad.js (the curve: xpToNext, xpToReach, playerLevel). PLAYER_XP.md.
//
// Kept inside the Stack folder until the shared player-XP module is ported; then this should defer to it. `Rules`
// stands in for setLevelsConfig(): the already-validated numbers of config/levels (squad.levelsOf's result). The
// defaults are DEFAULT_LEVELS.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Stack
{
    // config/levels as read (squad.levelsOf): the bits Squish Stack needs
    public sealed class XpRules
    {
        public double XpPerLevel = 100; // xpPerLevel
        public double Games = 1; // xp.games: × every mini-game level's XP
        public double Replay = 0.5; // xp.replay: a level beaten before pays this share
        public double BlitzStack = 200; // xp.blitz.stack: a won Blitz run
    }

    // playerLevel(): { level, into, need }
    public sealed class PlayerLevel
    {
        public double Level;
        public double Into;
        public double Need;
    }

    public static class StackXp
    {
        static XpRules rules = new XpRules();

        // setLevelsConfig / xpRules: null puts back the defaults
        public static XpRules Rules
        {
            get => rules;
            set => rules = value ?? new XpRules();
        }

        // XP from level L to L + 1
        public static double XpToNext(double L) => rules.XpPerLevel * (Math.Max(1, Math.Floor(L)) + 1);

        // the total XP that reaches level L: (2 + 3 + … + L) × xpPerLevel
        public static double XpToReach(double L) => L <= 1 ? 0 : rules.XpPerLevel * (L * (L + 1) - 2) / 2;

        // { level, into, need } for a total of `pxp`
        public static PlayerLevel PlayerLevelOf(double pxp)
        {
            double per = rules.XpPerLevel;
            double x = Math.Max(0, Math.Floor(double.IsNaN(pxp) || double.IsInfinity(pxp) ? 0 : pxp));
            // the highest L with xpToReach(L) <= x, then nudged past any rounding
            double L = Math.Max(1, Math.Floor((Math.Sqrt(9 + 8 * x / per) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return new PlayerLevel { Level = L, Into = x - XpToReach(L), Need = XpToNext(L) };
        }

        // What a profile from before player XP (no `pxp` yet) counts as: the XP of the level it had, plus its
        // Squishdoku Puzzle XP.
        static double LegacyXp(IDictionary<string, object> profile)
        {
            object level = Js.Get(profile, "level") ?? 1.0;
            object sdkXp = Js.Get(Js.Get(profile, "sdk"), "xp") ?? 0.0;
            return XpToReach(Math.Max(1, Math.Floor(Js.ToNum(level)))) + Math.Max(0, Math.Floor(Js.ToNum(sdkXp)));
        }

        public static double PxpOf(IDictionary<string, object> profile)
        {
            object p = Js.Get(profile, "pxp");
            return Js.IsNumber(p) ? Math.Max(0, Js.ToNum(p)) : LegacyXp(profile);
        }

        // `n` more XP: the XP (rounded, never below 0), the bar before / after, and the levels reached
        public static void AddXp(IDictionary<string, object> profile, double n, out double xp, out PlayerLevel before,
            out PlayerLevel after, out List<int> levelUps)
        {
            xp = Math.Max(0, Js.Round(double.IsNaN(n) ? 0 : n));
            double total = PxpOf(profile);
            before = PlayerLevelOf(total);
            after = PlayerLevelOf(total + xp);
            levelUps = new List<int>();
            for (double L = before.Level + 1; L <= after.Level; L++) levelUps.Add((int)L);
        }

        // A mini-game level's XP, × config's `games`.
        public static double GameXp(double n) => Js.Round(n * rules.Games);

        // A mini-game level's XP after a win: `full` the first time, else the better of config's `replay` share of
        // it and what it adds over `prevFull` (the XP the best result so far would pay now).
        public static double WinXp(double full, double? prevFull = null) =>
            prevFull == null ? full : Math.Max(Js.Round(full * rules.Replay), full - prevFull.Value);
    }
}
