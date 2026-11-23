// The Daily Spin in Unity (SpinView on screen): once a day before the menu (ScreenWrites.SpinDue), SPIN calls spinWheel
// through the Backend client (the server rolls and pays); "Continue to my squad" calls OnExit (then App.js shows the
// streak screen if ScreenWrites.StreakIntroDue). Offline (no client): a made-up answer after 800 ms, as Preview.js.
// The bonus spin needs a rewarded video in the app; Unity has no ads yet, so it's offered only with Remove Ads.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class SpinScreen : ScreenViewHost
    {
        IDictionary<string, object> _profile;
        FirebaseClient _fb;

        public static SpinScreen Create(Transform parent, IDictionary<string, object> profile, FirebaseClient fb, float screenW = 0, float screenH = 0)
        {
            var s = Make<SpinScreen>(parent, "Daily Spin", screenW, screenH);
            s._profile = profile; s._fb = fb;
            return s;
        }

        protected override IScreenView Build(float w, float h)
        {
            var now = DateTime.Now;
            var v = new SpinView(Prof.Str(Prof.Get(_profile, "nickname")), ScreenWrites.AdSpinsLeft(_profile, now), Prof.Truthy(Prof.Get(_profile, "adsFree")), w, h, Clock) { OnDone = Exit };
            v.OnSpin = async bonus =>
            {
                if (_fb == null)
                {
                    var tcs = new TaskCompletionSource<SpinResult>();
                    int i = UnityEngine.Random.Range(0, 8);
                    Clock.SetTimeout(() => tcs.SetResult(new SpinResult { Index = i, Kind = SpinView.WHEEL[i].kind, Amount = SpinView.WHEEL[i].amount, Jackpot = i == 7 }), 800);
                    return await tcs.Task;
                }
                try { return await ScreenWrites.Spin(_fb.Functions, bonus, DateTime.Now); }
                catch (Exception e) { Debug.LogWarning("spinWheel failed: " + e.Message); return new SpinResult { Error = true }; }
            };
            return v;
        }

        protected override void Back() { if (((SpinView)View).Phase != "spinning") Exit(); }
    }
}
