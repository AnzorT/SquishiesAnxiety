package com.plushcrush.unity.ads;

import android.app.Activity;

import com.google.android.gms.ads.AdError;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.FullScreenContentCallback;
import com.google.android.gms.ads.LoadAdError;
import com.google.android.gms.ads.MobileAds;
import com.google.android.gms.ads.rewarded.RewardedAd;
import com.google.android.gms.ads.rewarded.RewardedAdLoadCallback;

/**
 * One rewarded ad kept loaded, as the app's src/components/useRewardedAd.js: show() plays it, closed(earned) comes
 * after it's closed (earned only if its reward was), and a fresh one starts loading right after. For App/Ads.cs
 * (Listener is an AndroidJavaProxy; its calls come on the UI thread).
 */
public class RewardedAds {
    public interface Listener {
        void ready(boolean ready);
        void closed(boolean earned);
    }

    private final Activity activity;
    private final String unitId;
    private final Listener listener;
    private RewardedAd ad;
    private boolean earned, loading;

    public RewardedAds(Activity activity, String unitId, Listener listener) {
        this.activity = activity;
        this.unitId = unitId;
        this.listener = listener;
        activity.runOnUiThread(() -> MobileAds.initialize(activity, status -> load()));
    }

    private void load() {
        if (loading) return;
        loading = true;
        ad = null;
        listener.ready(false);
        RewardedAd.load(activity, unitId, new AdRequest.Builder().build(), new RewardedAdLoadCallback() {
            @Override
            public void onAdLoaded(RewardedAd loaded) {
                loading = false;
                ad = loaded;
                listener.ready(true);
            }

            @Override
            public void onAdFailedToLoad(LoadAdError error) {
                loading = false;
                ad = null;
                listener.ready(false);
            }
        });
    }

    /** Plays the loaded ad: true if there was one. */
    public boolean show() {
        final RewardedAd a = ad;
        if (a == null) return false;
        ad = null;
        earned = false;
        listener.ready(false);
        activity.runOnUiThread(() -> {
            a.setFullScreenContentCallback(new FullScreenContentCallback() {
                @Override
                public void onAdDismissedFullScreenContent() {
                    listener.closed(earned);
                    load();
                }

                @Override
                public void onAdFailedToShowFullScreenContent(AdError error) {
                    listener.closed(false);
                    load();
                }
            });
            a.show(activity, reward -> earned = true);
        });
        return true;
    }
}
