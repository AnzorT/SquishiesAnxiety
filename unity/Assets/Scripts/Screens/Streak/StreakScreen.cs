// The daily streak in Unity (StreakView on screen). Two ways in, as App.js:
//   intro   once a day after the Daily Spin while a streak is alive and today's chest is shut
//           (ScreenWrites.StreakIntroDue; this marks it seen: UserData.MarkStreakSeen): LET'S GO! → OnOpenDaily,
//           Later / CONTINUE → OnExit
//   menu    the flame on the menu: the back orb; DAILY CHALLENGES → OnOpenDaily
// OnOpenDaily: the host closes this and opens the daily challenges sheet (DailySheetScreen), as streakToDaily does.
using System;
using System.Collections.Generic;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class StreakScreen : ScreenViewHost
    {
        public Action OnOpenDaily;
        IDictionary<string, object> _profile;
        bool _intro;
        string _mascot;

        /// <summary>`mascot`: the squishy's name in its line (App.js streakMascot: the owned one squished longest).</summary>
        public static StreakScreen Create(Transform parent, IDictionary<string, object> profile, bool intro, FirebaseClient fb = null, string uid = null, string mascot = null, float screenW = 0, float screenH = 0)
        {
            var s = Make<StreakScreen>(parent, "Streak", screenW, screenH);
            s._profile = profile; s._intro = intro; s._mascot = mascot ?? Mascot(profile);
            if (intro && fb != null && uid != null) _ = fb.Data.MarkStreakSeen(uid, Prof.DayKey(DateTime.Now));
            s.Follow(fb?.Data.Feed);
            return s;
        }

        /// <summary>App.js streakMascot's name: the owned creature with the most squish time, or the first owned.</summary>
        public static string Mascot(IDictionary<string, object> profile)
        {
            ScreenViewHost.EnsureLoaders();
            var owned = Prof.Owned(profile);
            var time = Prof.Map(Prof.At(profile, "stats.playTime"));
            Creature best = null;
            double bestMs = -1;
            foreach (var c in Roster.All)
            {
                if (!owned.Contains(c.Id)) continue;
                double ms = Prof.Num(Prof.Get(time, c.Id));
                if (ms > bestMs) { best = c; bestMs = ms; }
            }
            return best?.Name;
        }

        protected override IScreenView Build(float w, float h) => Make(_profile, w, h);

        StreakView Make(IDictionary<string, object> p, float w, float h) =>
            new StreakView(p, _mascot, _intro, w, h, Clock, () => DateTime.Now) { OnClose = Exit, OnOpenDaily = () => OnOpenDaily?.Invoke() };

        protected override void ProfileChanged(IDictionary<string, object> profile) { _profile = profile; View = Make(profile, Wdp, Hdp); }
    }
}
