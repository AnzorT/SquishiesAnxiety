// The parts of src/playerXp.js (and the curve in functions/squad.js levelsOf / xpToNext / xpToReach / playerLevel)
// that Squish Hop's afterLevel() uses: addXp, gameXp and winXp. A local port, so the Hop port is complete and checked
// on its own; when the app's shared player-XP port lands, afterLevel can call that instead (same numbers).
//
// config/levels: SetLevelsConfig mirrors setLevelsConfig (null: the defaults). Only the fields these use are read,
// with levelsOf's checks: xpPerLevel and xp.games must be positive finite numbers, xp.replay a number in 0..1.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Hop
{
    // playerLevel(): { level, into, need }
    public sealed class PlayerLevelInfo
    {
        public int Level;
        public double Into;
        public double Need;
    }

    // addXp(): { xp, before, after, levelUps }
    public sealed class XpGain
    {
        public double Xp;
        public PlayerLevelInfo Before;
        public PlayerLevelInfo After;
        public List<int> LevelUps;
    }

    public static class PlayerXp
    {
        public const double DefaultXpPerLevel = 100, DefaultGames = 1, DefaultReplay = 0.5;
        static double xpPerLevel = DefaultXpPerLevel, games = DefaultGames, replay = DefaultReplay;

        static double PosNum(object v, double d)
        {
            if (!Js.IsNumber(v)) return d;
            double x = Js.AsDouble(v);
            return !double.IsNaN(x) && !double.IsInfinity(x) && x > 0 ? x : d;
        }

        public static void SetLevelsConfig(IDictionary<string, object> cfg)
        {
            if (cfg == null) { xpPerLevel = DefaultXpPerLevel; games = DefaultGames; replay = DefaultReplay; return; }
            object v;
            xpPerLevel = PosNum(Js.TryGet(cfg, "xpPerLevel", out v) ? v : null, DefaultXpPerLevel);
            var x = Js.TryGet(cfg, "xp", out v) ? v as IDictionary<string, object> : null;
            games = PosNum(Js.TryGet(x, "games", out v) ? v : null, DefaultGames);
            object r;
            if (Js.TryGet(x, "replay", out r) && Js.IsNumber(r) && Js.AsDouble(r) >= 0 && Js.AsDouble(r) <= 1) replay = Js.AsDouble(r);
            else replay = DefaultReplay;
        }

        public static double XpToNext(double L) { return xpPerLevel * (Math.Max(1, Math.Floor(L)) + 1); }

        public static double XpToReach(double L) { return L <= 1 ? 0 : (xpPerLevel * (L * (L + 1) - 2)) / 2; }

        static double Num(double n) { return double.IsNaN(n) || double.IsInfinity(n) ? 0 : n; }

        public static PlayerLevelInfo PlayerLevel(double pxp)
        {
            double per = xpPerLevel;
            double x = Math.Max(0, Math.Floor(Num(pxp)));
            double L = Math.Max(1, Math.Floor((Math.Sqrt(9 + (8 * x) / per) - 1) / 2));
            while (L > 1 && XpToReach(L) > x) L--;
            while (XpToReach(L + 1) <= x) L++;
            return new PlayerLevelInfo { Level = (int)L, Into = x - XpToReach(L), Need = XpToNext(L) };
        }

        // `profile?.k ?? d` for a number (a non-number value counts as ToNumber of it)
        static double NumOr(IDictionary<string, object> p, string k, double d)
        {
            object v;
            if (!Js.TryGet(p, k, out v) || v == null) return d;
            return Js.ToNumber(v);
        }

        static double LegacyXp(IDictionary<string, object> profile)
        {
            double level = NumOr(profile, "level", 1);
            object sdk;
            double sx = Js.TryGet(profile, "sdk", out sdk) ? NumOr(sdk as IDictionary<string, object>, "xp", 0) : 0;
            return XpToReach(Math.Max(1, Math.Floor(level))) + Math.Max(0, Math.Floor(sx));
        }

        public static double PxpOf(IDictionary<string, object> profile)
        {
            object v;
            if (Js.TryGet(profile, "pxp", out v) && Js.IsNumber(v)) return Math.Max(0, Js.AsDouble(v));
            return LegacyXp(profile);
        }

        // `n` more XP: before / after are PlayerLevel()s, LevelUps the levels reached
        public static XpGain AddXp(IDictionary<string, object> profile, double n)
        {
            double xp = Math.Max(0, Js.Round(double.IsNaN(n) ? 0 : n));
            double total = PxpOf(profile);
            var before = PlayerLevel(total);
            var after = PlayerLevel(total + xp);
            var ups = new List<int>();
            for (int L = before.Level + 1; L <= after.Level; L++) ups.Add(L);
            return new XpGain { Xp = xp, Before = before, After = after, LevelUps = ups };
        }

        // a mini-game level's XP, × config's `games`
        public static double GameXp(double n) { return Js.Round(n * games); }

        // `full` the first time, else the better of config's `replay` share of it and what it adds over `prevFull`
        public static double WinXp(double full, double? prevFull = null)
        {
            return prevFull == null ? full : Math.Max(Js.Round(full * replay), full - prevFull.Value);
        }
    }
}
