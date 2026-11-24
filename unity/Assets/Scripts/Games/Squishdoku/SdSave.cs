// Saving Squishdoku to the player's account: src/firebase/firestore.js saveSquishdoku, called where
// src/squishdoku/RegularGame.js, BlitzGame.js and src/screens/SquishdokuScreen.js call it (a level solved, the clock or
// the hearts run out, a Blitz run settled, HEAD START flipped), and Blitz's gem save (squad.blitzSave). To and BlitzSave
// are set by Games/Shared/AccountSaves.cs when a player is signed in (Backend/GameSaves.cs: UserData.SaveSquishdoku,
// fire and forget; the `squad` callable); null offline, when the in-memory Profile keeps the record as before.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdSave
    {
        /// <summary>(update, coins, xp, profile, levelAfter): saveSquishdoku(uid, update, coins, xp, profile), and the level
        /// the XP reached when it rose.</summary>
        public static Action<IDictionary<string, object>, double, double, IDictionary<string, object>, double?> To;

        /// <summary>Blitz's gem save on the server (BlitzGame.js saveByGems → squad.blitzSave(i), `i` the run's gem
        /// saves so far): null when paid, else the error ("not_enough_gems", or why the call failed). null offline:
        /// SdBlitz.SpendGems takes the gems off the in-memory profile.</summary>
        public static Func<int, System.Threading.Tasks.Task<string>> BlitzSave;

        /// <summary>saveSquishdoku(uid, out.update, out.coins, out.xp, profile): what a win (or a run) paid.
        /// `profile`: the one the outcome was worked out from, before the game applies it.</summary>
        public static void Paid(LevelOutcome o, IDictionary<string, object> profile)
        {
            if (o == null) return;
            bool up = o.LevelUps != null && o.LevelUps.Count > 0 && o.After != null;
            Send(o.Update, o.Coins, o.Xp, profile, up ? o.After.Level : (double?)null);
        }

        public static void Paid(BlitzOutcome o, IDictionary<string, object> profile)
        {
            if (o == null) return;
            bool up = o.LevelUps != null && o.LevelUps.Count > 0 && o.After != null;
            Send(o.Update, o.Coins, o.Xp, profile, up ? o.After.Level : (double?)null);
        }

        /// <summary>saveSquishdoku(uid, update, 0): a loss's record, a flag ('sdk.head').</summary>
        public static void Record(IDictionary<string, object> update) => Send(update, 0, 0, null, null);

        static void Send(IDictionary<string, object> update, double coins, double xp, IDictionary<string, object> profile, double? levelAfter)
        {
            var to = To;
            if (to == null || update == null) return;
            try { to(new Dictionary<string, object>(update), coins, xp, profile, levelAfter); }
            catch (Exception e) { Console.WriteLine("saveSquishdoku failed: " + e.Message); }
        }
    }
}
