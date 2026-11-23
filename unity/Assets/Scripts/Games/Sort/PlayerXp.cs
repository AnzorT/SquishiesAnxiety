// The player's XP, as far as Squish Sort needs it: ported from
// src/playerXp.js (addXp, gameXp, winXp, xpRules, pxpOf, playerLevel) and
// functions/squad.js (levelsOf's xpPerLevel / xp.replay / xp.games /
// xp.blitz.sort, xpToNext, xpToReach, playerLevel). The rest of config/levels
// (the road, the other XP rules) is not Squish Sort's and is not here.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    // { level, into, need }
    public sealed class PlayerLevelInfo
    {
        public int Level;
        public double Into;
        public double Need;
    }

    // { xp, before, after, levelUps }
    public sealed class XpGain
    {
        public double Xp;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
        public List<int> LevelUps = new List<int>();
    }

    public static class PlayerXp
    {
        public const double DefaultXpPerLevel = 100;
        public const double DefaultReplay = 0.5;
        public const double DefaultGames = 1;
        public const double DefaultBlitzSort = 200;

        // config/levels as levelsOf reads it (the parts used here)
        public static double XpPerLevel { get; private set; } = DefaultXpPerLevel;
        public static double Replay { get; private set; } = DefaultReplay;
        public static double Games { get; private set; } = DefaultGames;
        public static double BlitzSort { get; private set; } = DefaultBlitzSort;

        static bool PosNum(object v, out double d)
        {
            d = 0;
            if (!JsMath.IsNumber(v)) return false;
            d = JsMath.AsDouble(v);
            return !double.IsNaN(d) && !double.IsInfinity(d) && d > 0;
        }

        // setLevelsConfig(cfg): the config/levels doc (null: the defaults);
        // anything missing or broken falls back to the defaults, as levelsOf.
        public static void SetLevelsConfig(IDictionary<string, object> cfg)
        {
            XpPerLevel = DefaultXpPerLevel;
            Replay = DefaultReplay;
            Games = DefaultGames;
            BlitzSort = DefaultBlitzSort;
            if (cfg == null) return;
            double d;
            if (PosNum(JsMath.Get(cfg, "xpPerLevel"), out d)) XpPerLevel = d;
            var x = JsMath.AsMap(JsMath.Get(cfg, "xp"));
            if (x == null) return;
            object r = JsMath.Get(x, "replay");
            if (JsMath.IsNumber(r))
            {
                double rv = JsMath.AsDouble(r);
                if (rv >= 0 && rv <= 1) Replay = rv;
            }
            if (PosNum(JsMath.Get(x, "games"), out d)) Games = d;
            var b = JsMath.AsMap(JsMath.Get(x, "blitz"));
            if (b != null && PosNum(JsMath.Get(b, "sort"), out d)) BlitzSort = d;
        }

        public static double XpToNext(double L) => XpPerLevel * (JsMath.Max(1, Math.Floor(L)) + 1);
        public static double XpToReach(double L) => L <= 1 ? 0 : (XpPerLevel * (L * (L + 1) - 2)) / 2;

        static double Num(double n) => double.IsNaN(n) || double.IsInfinity(n) ? 0 : n;

        public static PlayerLevelInfo PlayerLevel(double pxp)
        {
            double per = XpPerLevel;
            double x = Math.Max(0, Math.Floor(Num(pxp)));
            double L = JsMath.Max(1, Math.Floor((Math.Sqrt(9 + (8 * x) / per) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return new PlayerLevelInfo { Level = (int)L, Into = x - XpToReach(L), Need = XpToNext(L) };
        }

        // a profile from before player XP: the XP of its level plus its
        // Squishdoku Puzzle XP
        static double LegacyXp(IDictionary<string, object> profile)
        {
            object lv = JsMath.Get(profile, "level");
            double level = lv == null ? 1 : JsMath.ToNum(lv);
            object sx = JsMath.Get(JsMath.AsMap(JsMath.Get(profile, "sdk")), "xp");
            double sdk = sx == null ? 0 : JsMath.ToNum(sx);
            return XpToReach(JsMath.Max(1, Math.Floor(level))) + JsMath.Max(0, Math.Floor(sdk));
        }

        public static double PxpOf(IDictionary<string, object> profile)
        {
            object p = JsMath.Get(profile, "pxp");
            return JsMath.IsNumber(p) ? JsMath.Max(0, JsMath.AsDouble(p)) : LegacyXp(profile);
        }

        // `n` more XP
        public static XpGain AddXp(IDictionary<string, object> profile, double n)
        {
            double xp = JsMath.Max(0, JsMath.Round(double.IsNaN(n) ? 0 : n));
            double total = PxpOf(profile);
            var before = PlayerLevel(total);
            var after = PlayerLevel(total + xp);
            var gain = new XpGain { Xp = xp, Before = before, After = after };
            for (int L = before.Level + 1; L <= after.Level; L++) gain.LevelUps.Add(L);
            return gain;
        }

        // a mini-game level's XP, x config's `games`
        public static double GameXp(double n) => JsMath.Round(n * Games);

        // `full` the first time, else the better of the replay share and what
        // it adds over `prevFull`
        public static double WinXp(double full, double? prevFull = null) => prevFull == null ? full : JsMath.Max(JsMath.Round(full * Replay), full - prevFull.Value);
    }
}
