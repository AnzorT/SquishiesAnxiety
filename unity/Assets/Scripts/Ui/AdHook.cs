// The games' door to the rewarded ads (src/components/useRewardedAd.js), with no UnityEngine in it so the test
// harnesses compile the game code as it is. On Android, App/Ads.cs fills it at start-up (Google Mobile Ads: one
// rewarded ad kept loaded); elsewhere (the editor, the harnesses) there are no ads and the games behave as with Remove
// Ads (Available false), as before ads were ported.
using System;
using System.Collections.Generic;

namespace SquishSquad.Ui
{
    public static class AdHook
    {
        /// <summary>Whether this build shows ads at all (the ad SDK started).</summary>
        public static bool Available;
        /// <summary>Whether a rewarded ad is loaded right now.</summary>
        public static Func<bool> Ready = () => false;
        /// <summary>Plays the ad; `onEarned` runs after it's closed, only if its reward was earned. Without ads: at once.</summary>
        public static Action<Action> Show = onEarned => onEarned();

        /// <summary>The player bought Remove Ads (the profile's adsFree), or this build has no ads.</summary>
        public static bool AdsFree(IDictionary<string, object> profile) =>
            !Available || (profile != null && profile.TryGetValue("adsFree", out var v) && v is bool b && b);
    }
}
