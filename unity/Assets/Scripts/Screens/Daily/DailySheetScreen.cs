// The daily challenges sheet in Unity (DailySheetView on screen), over whatever is under it (the menu): CLAIM writes the
// challenge (ScreenWrites.ClaimDailyChallenge), OPEN the chest (ClaimDailyChest, with the server's dailyGift), the
// rows follow the profile feed. The scrim and the close button call OnExit; OPEN CRIB calls OnOpenCrib (null: from the
// Crib: "YOU ARE HERE" moves over). OnToast: the app's toast line ("+40 coins · +25 XP!").
using System;
using System.Collections.Generic;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class DailySheetScreen : ScreenViewHost
    {
        public Action OnOpenCrib;
        public Action<string> OnToast;
        IDictionary<string, object> _profile;
        FirebaseClient _fb;
        string _uid;
        bool _fromMenu;

        public static DailySheetScreen Create(Transform parent, IDictionary<string, object> profile, FirebaseClient fb, string uid, bool fromMenu = true, float screenW = 0, float screenH = 0)
        {
            var s = Make<DailySheetScreen>(parent, "Daily challenges", screenW, screenH);
            s._profile = profile; s._fb = fb; s._uid = uid; s._fromMenu = fromMenu;
            s.Follow(fb?.Data.Feed);
            return s;
        }

        protected override IScreenView Build(float w, float h)
        {
            var v = new DailySheetView(_profile, w, h, Clock, () => DateTime.Now, _fromMenu) { OnClose = Exit, OnOpenCrib = () => OnOpenCrib?.Invoke() };
            v.OnClaim = async id =>
            {
                if (_fb == null || _uid == null) return;
                try { var t = await ScreenWrites.ClaimDailyChallenge(_fb.Data, _uid, _profile, id, DateTime.Now); if (t != null) OnToast?.Invoke(t); }
                catch (Exception e) { Debug.LogWarning("claimDailyChallenge failed: " + e.Message); }
            };
            v.OnClaimChest = async () =>
            {
                if (_fb == null || _uid == null) return;
                try { var t = await ScreenWrites.ClaimDailyChest(_fb.Data, _fb.Functions, _uid, _profile, DateTime.Now); if (t != null) OnToast?.Invoke(t); }
                catch (Exception e) { Debug.LogWarning("claimDailyChest failed: " + e.Message); }
            };
            return v;
        }

        protected override void ProfileChanged(IDictionary<string, object> profile) { _profile = profile; ((DailySheetView)View).SetProfile(profile); }
    }
}
