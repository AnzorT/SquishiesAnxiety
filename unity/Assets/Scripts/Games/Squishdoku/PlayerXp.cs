// The slice of src/playerXp.js (and functions/squad.js levelsOf / xpToNext / xpToReach / playerLevel) that
// Squishdoku's rewards use: the player's XP total on the profile (`pxp`), the level curve, and config/levels' XP
// rules. The XP rules are Firestore config in the app; set PlayerXp.Rules to the values levelsOf() validated (the
// defaults otherwise). A shared PlayerXp port can replace this one later. Pure C#, no Unity dependencies.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squishdoku
{
    /// <summary>config/levels as squad.levelsOf returns it (only what Squishdoku reads).</summary>
    public sealed class XpRules
    {
        public double XpPerLevel = 100;
        public double Games = 1;
        public double Replay = 0.5;
        public double BlitzSquishdoku = 400;
    }

    /// <summary>playerLevel(): { level, into, need }.</summary>
    public sealed class PlayerLevelInfo
    {
        public int Level;
        public double Into;
        public double Need;
    }

    /// <summary>addXp(): { xp, before, after, levelUps }.</summary>
    public sealed class XpGain
    {
        public double Xp;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
        public List<int> LevelUps;
    }

    public static class PlayerXp
    {
        public static XpRules Rules = new XpRules();

        public static double XpToNext(double L)
        {
            return Rules.XpPerLevel * (Math.Max(1, Math.Floor(L)) + 1);
        }

        public static double XpToReach(double L)
        {
            return L <= 1 ? 0 : (Rules.XpPerLevel * (L * (L + 1) - 2)) / 2;
        }

        public static PlayerLevelInfo PlayerLevel(double pxp)
        {
            double per = Rules.XpPerLevel;
            double x = Math.Max(0, Math.Floor(double.IsNaN(pxp) || double.IsInfinity(pxp) ? 0 : pxp));
            double L = Math.Max(1, Math.Floor((Math.Sqrt(9 + (8 * x) / per) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return new PlayerLevelInfo { Level = (int)L, Into = x - XpToReach(L), Need = XpToNext(L) };
        }

        static object Get(IDictionary<string, object> d, string key)
        {
            object v;
            return d != null && d.TryGetValue(key, out v) ? v : null;
        }

        // a profile from before player XP: the XP of the level it had, plus its old Squishdoku Puzzle XP
        static double LegacyXp(IDictionary<string, object> profile)
        {
            object level = Get(profile, "level");
            var sdk = Get(profile, "sdk") as IDictionary<string, object>;
            object sdkXp = Get(sdk, "xp");
            return XpToReach(Math.Max(1, Math.Floor(level == null ? 1 : Js.ToNumber(level)))) + Math.Max(0, Math.Floor(sdkXp == null ? 0 : Js.ToNumber(sdkXp)));
        }

        public static double PxpOf(IDictionary<string, object> profile)
        {
            object pxp = Get(profile, "pxp");
            return Js.IsNumber(pxp) ? Math.Max(0, Js.ToNumber(pxp)) : LegacyXp(profile);
        }

        public static XpGain AddXp(IDictionary<string, object> profile, double n)
        {
            double xp = Math.Max(0, Js.Round(double.IsNaN(n) ? 0 : n));
            double total = PxpOf(profile);
            var before = PlayerLevel(total);
            var after = PlayerLevel(total + xp);
            var levelUps = new List<int>();
            for (int L = before.Level + 1; L <= after.Level; L++) levelUps.Add(L);
            return new XpGain { Xp = xp, Before = before, After = after, LevelUps = levelUps };
        }

        /// <summary>A mini-game level's XP, × config's `games`.</summary>
        public static double GameXp(double n)
        {
            return Js.Round(n * Rules.Games);
        }

        /// <summary>XP after a win: `full` the first time, else the better of the replay share and what it adds over
        /// prevFull.</summary>
        public static double WinXp(double full, double? prevFull = null)
        {
            return prevFull == null ? full : Math.Max(Js.Round(full * Rules.Replay), full - prevFull.Value);
        }
    }
}
