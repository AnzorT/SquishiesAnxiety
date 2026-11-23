// The four puzzle games' saves to the player's account, as the app makes them: src/firebase/firestore.js saveStack /
// saveSort / saveHop / saveSquishdoku (UserData.SaveX: the game's dotted-path update, coins and totalEarned increments,
// the XP fields), and Squishdoku Blitz's gem save (src/squad/api.js blitzSave: the `squad` callable's blitzSave move).
//
// Each game calls its own hook where the app calls saveX (Games/*/…Save.cs); Games/Shared/AccountSaves.cs points those
// hooks here when a player is signed in (Use(uid, data)), and clears them offline, when the game's in-memory profile
// (and MenuState's PlayerPrefs levels) keep the record as before.
//
// Fire and forget, as the app's `.catch(logFail(...))`: Save returns at once with a Task that never faults (a failed
// write goes to UserData.Log). The write goes through the profile feed (UserData.UpdateProfile → feed.Track), so the
// menu's profile shows it at once and re-reads the document after.
//
// The game's profile copy: the app's profileRef is the live snapshot, which (latency compensation) already has the
// write's pxp / level / coins when the next level is worked out. The game's copy only gets the game's own fields
// (its Apply), so Save also adds what the write adds to it: pxp, level, coins, totalEarned. Then a second level in a
// row works its XP and level-ups out from the same numbers the app would.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public static class GameSaves
    {
        static string _uid;
        static UserData _data;
        static readonly object Gate = new object();
        static readonly List<Task> Pending = new List<Task>();

        /// <summary>The signed-in player the games save for (null uid or data: offline, nothing is sent).</summary>
        public static void Use(string uid, UserData data)
        {
            bool on = !string.IsNullOrEmpty(uid) && data != null;
            _uid = on ? uid : null;
            _data = on ? data : null;
        }

        public static bool SignedIn => _uid != null;
        public static string Uid => _uid;

        static void Log(string s)
        {
            var log = _data?.Log;
            if (log != null) log(s);
            else Console.WriteLine(s);
        }

        /// <summary>saveX(uid, update, coins, xp, profile): `game` is "stack", "sort", "hop" or "squishdoku"; `profile`
        /// the game's copy the outcome was worked out from (before its Apply; null for a loss or a flag);
        /// `levelAfter` the outcome's After.Level when it has LevelUps.</summary>
        public static Task Save(string game, IDictionary<string, object> update, double coins = 0, double xp = 0,
            IDictionary<string, object> profile = null, double? levelAfter = null)
        {
            string uid = _uid;
            var data = _data;
            if (uid == null || data == null || update == null) return Task.CompletedTask;
            Task t;
            try
            {
                switch (game)
                {
                    case "stack": t = data.SaveStack(uid, update, coins, xp, profile, levelAfter); break;
                    case "sort": t = data.SaveSort(uid, update, coins, xp, profile, levelAfter); break;
                    case "hop": t = data.SaveHop(uid, update, coins, xp, profile, levelAfter); break;
                    case "squishdoku": t = data.SaveSquishdoku(uid, update, coins, xp, profile, levelAfter); break;
                    default: throw new ArgumentException("no such game: " + game);
                }
                // (after: SaveGame has read the profile's pxp for its XP fields)
                if (profile != null) AddPay(data, profile, coins, xp, levelAfter);
            }
            catch (Exception e)
            {
                Log("save" + game + " failed: " + e.Message);
                return Task.CompletedTask;
            }
            Track(t);
            return t;
        }

        // what the write adds to the profile, on the game's copy (see the top)
        static void AddPay(UserData data, IDictionary<string, object> profile, double coins, double xp, double? levelAfter)
        {
            if (xp > 0)
            {
                profile["pxp"] = data.PxpOf(profile) + xp;
                if (levelAfter.HasValue) profile["level"] = levelAfter.Value;
            }
            if (coins > 0)
            {
                profile["coins"] = Num(profile, "coins") + coins;
                profile["totalEarned"] = Num(profile, "totalEarned") + coins;
            }
        }

        static double Num(IDictionary<string, object> p, string k) =>
            p.TryGetValue(k, out var v) && v is double d && !double.IsNaN(d) ? d : 0;

        /// <summary>Squishdoku Blitz's gem save (BlitzGame.js saveByGems → squad.blitzSave(i)): the `squad` callable's
        /// blitzSave move, `i` the gem saves this run has had. null: paid (the server took the gems); else the error code
        /// ("not_enough_gems") or the failure's message. The profile feed re-reads the document after.</summary>
        public static async Task<string> BlitzSave(int i)
        {
            var data = _data;
            if (_uid == null || data == null) return "Not signed in";
            try
            {
                var res = await data.CallAndRefresh("squad", new Dictionary<string, object>
                {
                    ["move"] = "blitzSave",
                    ["i"] = (double)i,
                    ["tzOffsetMinutes"] = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes,
                }).ConfigureAwait(false);
                if (res is IDictionary<string, object> m && m.TryGetValue("error", out var err) && err != null)
                    return Convert.ToString(err, CultureInfo.InvariantCulture);
                return null;
            }
            catch (Exception e)
            {
                Log("blitzSave failed: " + e.Message);
                return string.IsNullOrEmpty(e.Message) ? "error" : e.Message;
            }
        }

        static void Track(Task t)
        {
            lock (Gate) Pending.Add(t);
            t.ContinueWith(_ => { lock (Gate) Pending.Remove(t); }, TaskScheduler.Default);
        }

        /// <summary>Every save still in flight (tests wait on it; the game never does).</summary>
        public static Task Idle()
        {
            Task[] all;
            lock (Gate) all = Pending.ToArray();
            return Task.WhenAll(all);
        }
    }
}
