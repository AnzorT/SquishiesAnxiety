// src/firebase/firestore.js's profile functions, on the REST client: the same documents, the same fields, the same
// increments / arrayUnions / dotted paths, so the server (firestore.rules, the Cloud Functions) sees exactly what the
// RN app sends. Profiles are maps as the game ports read them (Games/*/Levels.cs): IDictionary<string, object>,
// numbers as double.
//
// The JS functions that end in `.catch(logFail(...))` (fire and forget) return a Task here that never faults (the
// failure goes to Log); the ones the JS awaits (createUserProfile, addCoins, updateNickname…) throw.
//
// Writes to users/{uid} go through the profile feed (Track) when one is open for that uid, so the app sees them at
// once and the server's copy right after.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SquishSquad.Backend
{
    public sealed class UserData
    {
        readonly Firestore fs;
        readonly FirebaseFunctions functions;
        IProfileFeed feed;

        // src/data/creatures.js STARTER_CREATURE_IDS
        public static readonly string[] StarterCreatureIds = { "0" };

        public Action<string> Log = s => Console.WriteLine(s);

        // What a profile without `pxp` (one from before player XP) counts as: src/playerXp.js pxpOf. The default is
        // its formula at the default xpPerLevel (100); point it at the shared player-XP port once there is one.
        public Func<IDictionary<string, object>, double> PxpOf = DefaultPxpOf;

        public UserData(Firestore firestore, FirebaseFunctions functions)
        {
            fs = firestore;
            this.functions = functions;
        }

        static string UserPath(string uid) => "users/" + uid;
        static FieldValue Inc(double n) => FieldValue.Increment(n);

        // --- the profile ----------------------------------------------------------------------------------------

        public async Task CreateUserProfile(string uid, string email, double age, string nickname)
        {
            string nick = string.IsNullOrWhiteSpace(nickname) ? "Squisher" : nickname.Trim();
            await fs.Set(UserPath(uid), new Dictionary<string, object>
            {
                { "email", email },
                { "age", age },
                { "nickname", nick },
                { "coins", 250.0 },
                { "totalEarned", 250.0 },
                { "adsFree", false },
                { "generationCredits", 1.0 },
                { "ownedIds", StarterCreatureIds.Cast<object>().ToList() },
                { "stats", new Dictionary<string, object> { { "presses", 0.0 }, { "longestHoldMs", 0.0 }, { "playTime", new Dictionary<string, object>() } } },
                { "achievements", new Dictionary<string, object> { { "speedTap", false }, { "watchAd", false } } },
                { "tut", "start" },
                { "level", 1.0 },
                { "pxp", 0.0 },
                { "createdAt", FieldValue.ServerTimestamp },
            }).ConfigureAwait(false);
            if (feed != null && feed.Uid == uid) await feed.Refresh().ConfigureAwait(false);
        }

        // subscribeToUserProfile: the live profile (a polling feed for now, see ProfileFeed.cs). One at a time: a new
        // one replaces (and disposes) the last. Dispose it on sign-out.
        public IProfileFeed SubscribeToUserProfile(string uid, TimeSpan? pollInterval = null)
        {
            feed?.Dispose();
            feed = new PollingProfileFeed(fs, uid, pollInterval);
            return feed;
        }

        public IProfileFeed Feed => feed;

        public async Task<IDictionary<string, object>> GetProfile(string uid) => (await fs.Get(UserPath(uid)).ConfigureAwait(false))?.Data;

        // users/{uid}.update(fields): the one door every profile write goes through.
        public Task UpdateProfile(string uid, IDictionary<string, object> fields)
        {
            var write = fs.Update(UserPath(uid), fields);
            return feed != null && feed.Uid == uid ? feed.Track(fields, write) : write;
        }

        Task Quiet(string what, Task t) => t.ContinueWith(x =>
        {
            if (x.IsFaulted) Log?.Invoke(what + " failed: " + x.Exception?.GetBaseException().Message);
        }, TaskScheduler.Default);

        Task QuietUpdate(string what, string uid, IDictionary<string, object> fields) => Quiet(what, UpdateProfile(uid, fields));

        // --- progression -----------------------------------------------------------------------------------------

        public Task SetTutorialStep(string uid, string step) => QuietUpdate("setTutorialStep", uid, new Dictionary<string, object> { { "tut", step } });

        public Task MarkLevelSeen(string uid, double level) => QuietUpdate("markLevelSeen", uid, new Dictionary<string, object> { { "lvSeen", level } });

        public Task MarkStreakSeen(string uid, string date) => QuietUpdate("markStreakSeen", uid, new Dictionary<string, object> { { "streakSeen", date } });

        // xpFields: the fields that add `xp` (already rounded: the game's AddXp result) — an increment, or the whole
        // total for a profile not moved over yet — and the new level when it rose (levelAfter: outcome.After.Level
        // when outcome.LevelUps isn't empty, else null).
        public Dictionary<string, object> XpFields(IDictionary<string, object> profile, double xp, double? levelAfter)
        {
            var f = new Dictionary<string, object>();
            if (xp != 0)
            {
                object p = null;
                profile?.TryGetValue("pxp", out p);
                f["pxp"] = p is double ? (object)Inc(xp) : PxpOf(profile) + xp;
            }
            if (levelAfter.HasValue) f["level"] = levelAfter.Value;
            return f;
        }

        static double DefaultPxpOf(IDictionary<string, object> profile)
        {
            object p = null, level = null, sdk = null;
            profile?.TryGetValue("pxp", out p);
            if (p is double d) return Math.Max(0, d);
            profile?.TryGetValue("level", out level);
            profile?.TryGetValue("sdk", out sdk);
            object sdkXp = null;
            (sdk as IDictionary<string, object>)?.TryGetValue("xp", out sdkXp);
            double L = Math.Max(1, Math.Floor(level is double ld ? ld : 1));
            double toReach = L <= 1 ? 0 : 100 * (L * (L + 1) - 2) / 2;
            return toReach + Math.Max(0, Math.Floor(sdkXp is double sx ? sx : 0));
        }

        // --- the mini-games (saveGame) ---------------------------------------------------------------------------

        // A mini-game's record and what a level or run paid: `update` is the game's Levels.AfterLevel / AfterBlitz
        // Update ("stack.lv", "stack.best.3"…), `coins` and `xp` its Coins and Xp, `levelAfter` as in XpFields.
        public Task SaveGame(string what, string uid, IDictionary<string, object> update, double coins = 0, double xp = 0,
            IDictionary<string, object> profile = null, double? levelAfter = null)
        {
            var all = new Dictionary<string, object>(update);
            if (xp > 0)
                foreach (var kv in XpFields(profile, xp, levelAfter))
                    all[kv.Key] = kv.Value;
            if (coins > 0)
            {
                all["coins"] = Inc(coins);
                all["totalEarned"] = Inc(coins);
            }
            return QuietUpdate(what, uid, all);
        }

        public Task SaveStack(string uid, IDictionary<string, object> update, double coins = 0, double xp = 0, IDictionary<string, object> profile = null, double? levelAfter = null) =>
            SaveGame("saveStack", uid, update, coins, xp, profile, levelAfter);

        public Task SaveSort(string uid, IDictionary<string, object> update, double coins = 0, double xp = 0, IDictionary<string, object> profile = null, double? levelAfter = null) =>
            SaveGame("saveSort", uid, update, coins, xp, profile, levelAfter);

        public Task SaveHop(string uid, IDictionary<string, object> update, double coins = 0, double xp = 0, IDictionary<string, object> profile = null, double? levelAfter = null) =>
            SaveGame("saveHop", uid, update, coins, xp, profile, levelAfter);

        public Task SaveSquishdoku(string uid, IDictionary<string, object> update, double coins = 0, double xp = 0, IDictionary<string, object> profile = null, double? levelAfter = null) =>
            SaveGame("saveSquishdoku", uid, update, coins, xp, profile, levelAfter);

        // --- the lobby, offers ------------------------------------------------------------------------------------

        public Task SetLobbySelected(string uid, string id) => QuietUpdate("setLobbySelected", uid, new Dictionary<string, object>
        {
            { "lobby.sel", id }, { "lobby.seen", FieldValue.ArrayUnion(id) },
        });

        public Task SetOfferSeen(string uid, string id, double atMs) =>
            QuietUpdate("setOfferSeen", uid, new Dictionary<string, object> { { "offerSeen." + id, atMs } });

        public Task MarkSquadSeen(string uid, IEnumerable<string> ids)
        {
            var list = ids.Cast<object>().ToArray();
            if (list.Length == 0) return Task.CompletedTask;
            return QuietUpdate("markSquadSeen", uid, new Dictionary<string, object> { { "lobby.seen", FieldValue.ArrayUnion(list) } });
        }

        // --- coins and the rest --------------------------------------------------------------------------------------

        public Task AddCoins(string uid, double amount)
        {
            if (amount == 0) return Task.CompletedTask;
            return UpdateProfile(uid, new Dictionary<string, object> { { "coins", Inc(amount) }, { "totalEarned", Inc(amount) } });
        }

        public Task CribCoins(string uid, double n)
        {
            if (n == 0) return Task.CompletedTask;
            var u = new Dictionary<string, object> { { "coins", Inc(n) } };
            if (n > 0) u["totalEarned"] = Inc(n);
            return QuietUpdate("cribCoins", uid, u);
        }

        public Task NoteCribBuy(string uid) => QuietUpdate("noteCribBuy", uid, new Dictionary<string, object> { { "cribBuys", Inc(1) } });

        public Task SetCribSize(string uid, double n) => QuietUpdate("setCribSize", uid, new Dictionary<string, object> { { "cribSize", n } });

        public Task UpdateNickname(string uid, string nickname)
        {
            string t = nickname?.Trim();
            if (string.IsNullOrEmpty(t)) return Task.CompletedTask;
            return UpdateProfile(uid, new Dictionary<string, object> { { "nickname", t } });
        }

        public Task MarkAchievement(string uid, string key) =>
            UpdateProfile(uid, new Dictionary<string, object> { { "achievements." + key, true } });

        public Task RecordAdWatched(string uid, double multiplier, double currentMaxMult = 0, bool watched = true)
        {
            var u = new Dictionary<string, object>();
            if (watched) u["adsWatched"] = Inc(1);
            if (multiplier > currentMaxMult) u["maxMult"] = multiplier;
            return u.Count > 0 ? UpdateProfile(uid, u) : Task.CompletedTask;
        }

        public Task EnsureStarterCreaturesOwned(string uid, IList<object> ownedIds)
        {
            var missing = StarterCreatureIds.Where(id => ownedIds == null || !ownedIds.Contains(id)).Cast<object>().ToArray();
            if (missing.Length == 0) return Task.CompletedTask;
            return UpdateProfile(uid, new Dictionary<string, object> { { "ownedIds", FieldValue.ArrayUnion(missing) } });
        }

        // recordPress: one squish-and-release (the longest hold needs a read, so it's a transaction).
        public async Task RecordPress(string uid, string creatureId, double holdMs)
        {
            string path = UserPath(uid);
            Dictionary<string, object> update = null;
            await fs.RunTransaction<bool>(async tx =>
            {
                var snap = await tx.Get(path).ConfigureAwait(false);
                var data = snap?.Data ?? new Dictionary<string, object>();
                var stats = data.TryGetValue("stats", out var s) && s is IDictionary<string, object> sm ? sm : new Dictionary<string, object>();
                double longest = Math.Max(stats.TryGetValue("longestHoldMs", out var lh) && lh is double lhd ? lhd : 0, holdMs);
                var play = stats.TryGetValue("playTime", out var pt) && pt is IDictionary<string, object> ptm ? ptm : new Dictionary<string, object>();
                double prior = play.TryGetValue(creatureId, out var pr) && pr is double prd ? prd : 0;
                update = new Dictionary<string, object>
                {
                    { "stats.presses", Inc(1) },
                    { "stats.longestHoldMs", longest },
                    { "stats.playTime." + creatureId, prior + holdMs },
                };
                if (Regex.IsMatch(creatureId, "^[0-9]+$")) update["xp." + creatureId] = Inc(1);
                tx.Update(path, update);
                return true;
            }).ConfigureAwait(false);
            if (feed != null && feed.Uid == uid) await feed.Track(null, Task.CompletedTask).ConfigureAwait(false);
        }

        public Task SubmitFeedback(string uid, string text)
        {
            string t = text?.Trim();
            if (string.IsNullOrEmpty(t)) return Task.CompletedTask;
            return fs.Add("feedback", new Dictionary<string, object> { { "uid", uid }, { "text", t }, { "createdAt", FieldValue.ServerTimestamp } });
        }

        // --- the Crib (users/{uid}/crib/state) -------------------------------------------------------------------

        public async Task<IDictionary<string, object>> LoadCrib(string uid) =>
            (await fs.Get(UserPath(uid) + "/crib/state").ConfigureAwait(false))?.Data;

        public Task SaveCrib(string uid, IDictionary<string, object> state) => Quiet("saveCrib", fs.Set(UserPath(uid) + "/crib/state", state));

        // --- the Squad House (users/{uid}/crib/house6 = { data: '<the house's save, JSON>', t }) -------------------
        // src/game/gameData.js loadHouse / saveHouse: the same document the app's WebView house reads and writes, so a
        // player's house is the same in both apps (House/HouseSave.cs reads and writes `data`).

        // loadHouse: the save's JSON, or null (no house yet, or the read failed: the house starts a new one)
        public async Task<string> LoadHouse(string uid)
        {
            try
            {
                var d = (await fs.Get(UserPath(uid) + "/crib/house6").ConfigureAwait(false))?.Data;
                return d != null && d.TryGetValue("data", out var v) && v is string s && s.Length > 0 ? s : null;
            }
            catch (Exception e)
            {
                Log("loadHouse failed: " + e.Message);
                return null;
            }
        }

        // saveHouse: { data, t: serverTimestamp() } (fire and forget, like the app's); nothing for an empty save
        public Task SaveHouse(string uid, string data)
        {
            if (string.IsNullOrEmpty(data)) return Task.CompletedTask;
            return Quiet("saveHouse", fs.Set(UserPath(uid) + "/crib/house6", new Dictionary<string, object> { { "data", data }, { "t", FieldValue.ServerTimestamp } }));
        }

        // --- player-made creatures (users/{uid}/customCreatures) ------------------------------------------------

        // subscribeToCustomCreatures' list, read once (ordered by createdAt): each with its `id`.
        public async Task<List<IDictionary<string, object>>> ListCustomCreatures(string uid)
        {
            var docs = await fs.List(UserPath(uid) + "/customCreatures", "createdAt").ConfigureAwait(false);
            return docs.Select(d =>
            {
                var m = new Dictionary<string, object>(d.Data) { ["id"] = d.Id };
                return (IDictionary<string, object>)m;
            }).ToList();
        }

        public Task DeleteCustomCreature(string uid, string creatureId) => fs.Delete(UserPath(uid) + "/customCreatures/" + creatureId);

        // --- shared, read-only data -----------------------------------------------------------------------------

        // config/offers, config/levels, config/roster, config/pricing… (null until it exists)
        public async Task<IDictionary<string, object>> ReadConfig(string name) =>
            (await fs.Get("config/" + name).ConfigureAwait(false))?.Data;

        // the creature catalog, ordered (subscribeToCreatures, read once)
        public async Task<List<IDictionary<string, object>>> ListCreatures()
        {
            var docs = await fs.List("creatures", "order").ConfigureAwait(false);
            return docs.Select(d => (IDictionary<string, object>)new Dictionary<string, object>(d.Data) { ["id"] = d.Id }).ToList();
        }

        // --- Cloud Functions that write the profile ----------------------------------------------------------------

        // callFunction(name, data), then a profile re-read: the function's transaction changed it server-side, and a
        // polling feed wouldn't see that until its next poll (onSnapshot would have).
        public async Task<object> CallAndRefresh(string name, IDictionary<string, object> data)
        {
            try
            {
                return await functions.Call(name, data).ConfigureAwait(false);
            }
            finally
            {
                if (feed != null) await feed.Refresh().ConfigureAwait(false);
            }
        }
    }
}
