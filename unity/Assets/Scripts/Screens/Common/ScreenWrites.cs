// What these screens write, through the Backend client (Backend/UserData, FirebaseFunctions), as the app does
// (src/firebase/firestore.js, App.js handlers):
//   ClaimDailyChallenge  claimDailyChallenge: the challenge claimed, its coins (and totalEarned) and XP
//   ClaimDailyChest      claimDailyChest: the chest, its coins (+ a coins day's reward), XP, the streak, chests + 1,
//                        streakDiscount for day 10; then the streak day's gems / free chest from the server (squad
//                        dailyGift), as App.js handleClaimChest
//   Spin                 spinWheel { tzOffsetMinutes, bonus } (the server rolls and pays)
//   TestWallet           testWallet { ...wallet, tzOffsetMinutes } (a tester's)
//   MarkStreakSeen, UpdateNickname, SubmitFeedback: UserData's own.
// Each returns what the app's toast says. Writes go to the live project in the app; tools/unity/screens-test runs
// them against the Firebase emulators only.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using SquishSquad.Games.Sort;

namespace SquishSquad.Screens
{
    public static class ScreenWrites
    {
        /// <summary>The device's UTC offset in minutes (dailySpin.js tzOffsetMinutes).</summary>
        public static double TzOffsetMinutes(DateTime local) => Math.Round((local - local.ToUniversalTime()).TotalMinutes);

        static Dictionary<string, object> XpFields(IDictionary<string, object> profile, double n)
        {
            var r = PlayerXp.AddXp(profile, n);
            var f = new Dictionary<string, object>();
            if (r.Xp != 0) f["pxp"] = Prof.IsNum(Prof.Get(profile, "pxp")) ? (object)FieldValue.Increment(r.Xp) : PlayerXp.PxpOf(profile) + r.Xp;
            if (r.LevelUps.Count > 0) f["level"] = (double)r.After.Level;
            return f;
        }

        /// <summary>"+40 coins · +25 XP!", or null when it can't be claimed.</summary>
        public static async Task<string> ClaimDailyChallenge(UserData data, string uid, IDictionary<string, object> profile, string id, DateTime now)
        {
            var r = Progression.ClaimDaily(profile, id, Prof.DayKey(now));
            if (r == null) return null;
            var u = new Dictionary<string, object>(r.Update)
            {
                ["coins"] = FieldValue.Increment(r.Coins),
                ["totalEarned"] = FieldValue.Increment(r.Coins),
            };
            foreach (var kv in XpFields(profile, r.Xp)) u[kv.Key] = kv.Value;
            await data.UpdateProfile(uid, u);
            return $"+{Prof.JsStr(r.Coins)} coins · +{Prof.JsStr(r.Xp)} XP!";
        }

        /// <summary>The daily chest; the toast, or null when it isn't ready. `gift`: squad dailyGift (null: skipped).</summary>
        public static async Task<string> ClaimDailyChest(UserData data, FirebaseFunctions functions, string uid, IDictionary<string, object> profile, DateTime now)
        {
            var r = Progression.ClaimChest(profile, Prof.DayKey(now));
            if (r == null) return null;
            double coins = r.Coins;
            var u = new Dictionary<string, object>(r.Update) { ["chests"] = FieldValue.Increment(1) };
            foreach (var kv in XpFields(profile, r.Xp)) u[kv.Key] = kv.Value;
            if (r.Reward.Kind == "coins") coins += r.Reward.Amount;
            else if (r.Reward.Kind == "half") u["streakDiscount"] = true;
            u["coins"] = FieldValue.Increment(coins);
            u["totalEarned"] = FieldValue.Increment(coins);
            await data.UpdateProfile(uid, u);
            if (functions != null && (r.Reward.Kind == "gems" || r.Reward.Kind == "chest"))
            {
                var gift = new Dictionary<string, object> { ["day"] = (double)r.Reward.Day, ["kind"] = r.Reward.Kind, ["label"] = r.Reward.Label };
                if (r.Reward.Kind == "gems") gift["amount"] = r.Reward.Amount;
                try { await functions.Call("squad", new Dictionary<string, object> { ["move"] = "dailyGift", ["reward"] = gift, ["tzOffsetMinutes"] = TzOffsetMinutes(now) }); }
                catch (Exception) { }   // (the app ignores a failed gift: .catch(() => {}))
            }
            string extra = r.Reward.Kind == "gems" ? $" + {Prof.JsStr(r.Reward.Amount)} gems" : r.Reward.Kind == "chest" ? " + a free chest in the Shop" : r.Reward.Kind == "half" ? " + half price on your next creation" : "";
            return $"Daily chest: +{Prof.JsStr(coins)} coins · +{Prof.JsStr(r.Xp)} XP{extra}!";
        }

        /// <summary>spinWheel: the server's prize (or { already } / an error).</summary>
        public static async Task<SpinResult> Spin(FirebaseFunctions functions, bool bonus, DateTime now)
        {
            var res = await functions.Call("spinWheel", new Dictionary<string, object> { ["tzOffsetMinutes"] = TzOffsetMinutes(now), ["bonus"] = bonus });
            return SpinResult.From(res);
        }

        public static Task TestWallet(FirebaseFunctions functions, IDictionary<string, object> wallet, DateTime now)
        {
            var d = new Dictionary<string, object>(wallet) { ["tzOffsetMinutes"] = TzOffsetMinutes(now) };
            return functions.Call("testWallet", d);
        }

        // ---- when the app shows them (App.js) ----------------------------------------------------------------------------
        /// <summary>The Daily Spin shows before the menu once a day: not spun today (dailySpin.js hasSpunToday).</summary>
        public static bool SpinDue(IDictionary<string, object> profile, DateTime now)
        {
            var last = Prof.Str(Prof.Get(profile, "lastSpinDay"));
            return profile != null && !(last != null && string.CompareOrdinal(last, Prof.DayKey(now)) >= 0);
        }

        /// <summary>adSpinsLeft: the bonus spins left today.</summary>
        public static int AdSpinsLeft(IDictionary<string, object> profile, DateTime now)
        {
            var a = Prof.Map(Prof.Get(profile, "adSpins"));
            double used = a != null && Prof.Str(Prof.Get(a, "day")) == Prof.DayKey(now) ? Math.Max(0, Math.Floor(Prof.Num(Prof.Get(a, "n")))) : 0;
            return (int)Math.Max(0, SpinView.MAX_AD_SPINS - used);
        }

        /// <summary>App.js streakIntroDue (the parts about the profile): after the spin, once a day, while a streak is alive
        /// and today's chest is shut, daily challenges unlocked, the tutorial over. The caller marks it seen
        /// (UserData.MarkStreakSeen) when it shows it.</summary>
        public static bool StreakIntroDue(IDictionary<string, object> profile, DateTime now)
        {
            if (profile == null) return false;
            string today = Prof.DayKey(now);
            var tut = Prof.Str(Prof.Get(profile, "tut"));
            bool tutOver = string.IsNullOrEmpty(tut) || tut == "done";
            bool dailyUnlocked = Progression.Level(profile) >= Progression.DAILY_LEVEL && (tutOver || tut == "c_daily" || tut == "c_offers");
            return tutOver && dailyUnlocked && Progression.StreakOf(profile, now) > 0
                && Prof.Str(Prof.Get(profile, "lastFull")) != today && Prof.Str(Prof.Get(profile, "streakSeen")) != today;
        }
    }
}
