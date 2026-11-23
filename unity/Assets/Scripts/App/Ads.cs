// The rewarded ads on Android (Assets/Plugins/Android/RewardedAds.androidlib: Google Mobile Ads, one ad kept loaded),
// as src/components/useRewardedAd.js: started before the first scene, they fill Ui/AdHook, which the games use for
// their revives and hints. The unit is Google's test unit, as src/firebase/ads.js (TestIds.REWARDED) until the real
// one is set there and here. The "adDone" sound plays when a reward was earned, as the app.
using System;
using SquishSquad.Ui;
using UnityEngine;

namespace SquishSquad.App
{
    public static class Ads
    {
        public const string RewardedUnit = "ca-app-pub-3940256099942544/5224354917";   // (TestIds.REWARDED on Android)

#if UNITY_ANDROID && !UNITY_EDITOR
        static AndroidJavaObject _ads;
        static volatile bool _ready;
        static Action _onEarned;

        sealed class Listener : AndroidJavaProxy
        {
            public Listener() : base("com.plushcrush.unity.ads.RewardedAds$Listener") { }
            public void ready(bool r) => _ready = r;
            public void closed(bool earned) => Backend.MainThread.Run(() =>
            {
                var cb = _onEarned;
                _onEarned = null;
                if (!earned) return;
                Audio.Snd.Play("adDone");
                cb?.Invoke();
            });
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Start()
        {
            try
            {
                using var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = player.GetStatic<AndroidJavaObject>("currentActivity");
                _ads = new AndroidJavaObject("com.plushcrush.unity.ads.RewardedAds", activity, RewardedUnit, new Listener());
                AdHook.Available = true;
                AdHook.Ready = () => _ready;
                AdHook.Show = onEarned =>
                {
                    if (!_ready || _ads == null) return;
                    _onEarned = onEarned;
                    if (!_ads.Call<bool>("show")) _onEarned = null;
                };
            }
            catch (Exception e)
            {
                Debug.LogWarning("[Ads] no ads: " + e.Message);
                AdHook.Available = false;
            }
        }
#endif
    }
}
