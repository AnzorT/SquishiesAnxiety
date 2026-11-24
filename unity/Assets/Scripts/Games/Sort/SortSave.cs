// Saving Squish Sort to the player's account: src/firebase/firestore.js saveSort, called where src/sort/Game.js and
// src/screens/SortScreen.js call it (a level won or lost, a Blitz run over, the first visit's `sort.seen`). To is set
// by Games/Shared/AccountSaves.cs when a player is signed in (Backend/GameSaves.cs: UserData.SaveSort, fire and
// forget); null offline, when the in-memory Profile keeps the record as before.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    public static class SortSave
    {
        /// <summary>(update, coins, xp, profile, levelAfter): saveSort(uid, update, coins, xp, profile), and the level
        /// the XP reached when it rose.</summary>
        public static Action<IDictionary<string, object>, double, double, IDictionary<string, object>, double?> To;

        /// <summary>saveSort(uid, out.update, out.coins, out.xp, profile): what a win (or a run) paid.
        /// `profile`: the one the outcome was worked out from, before the game applies it.</summary>
        public static void Paid(SortOutcome o, IDictionary<string, object> profile)
        {
            if (o == null) return;
            bool up = o.LevelUps != null && o.LevelUps.Count > 0 && o.After != null;
            Send(o.Update, o.Coins, o.Xp, profile, up ? o.After.Level : (double?)null);
        }

        /// <summary>saveSort(uid, update, 0): a loss's record, a flag ('sort.seen': true).</summary>
        public static void Record(IDictionary<string, object> update) => Send(update, 0, 0, null, null);

        static void Send(IDictionary<string, object> update, double coins, double xp, IDictionary<string, object> profile, double? levelAfter)
        {
            var to = To;
            // (no account: the dev menu's offline wallet takes the coins: Backend/OfflineWallet.cs)
            if (to == null) { if (coins > 0) SquishSquad.Backend.OfflineWallet.Paid(coins); return; }
            if (update == null) return;
            try { to(new Dictionary<string, object>(update), coins, xp, profile, levelAfter); }
            catch (Exception e) { Console.WriteLine("saveSort failed: " + e.Message); }
        }
    }
}
