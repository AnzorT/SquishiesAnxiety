// Stats in Unity (StatsView on screen), opened from Settings' "Stats"; its back orb (or Android's back) calls OnExit.
using System.Collections.Generic;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class StatsScreen : ScreenViewHost
    {
        IDictionary<string, object> _profile;
        IList<Creature> _creatures;

        public static StatsScreen Create(Transform parent, IDictionary<string, object> profile, IProfileFeed feed = null, IList<Creature> creatures = null, float screenW = 0, float screenH = 0)
        {
            var s = Make<StatsScreen>(parent, "Stats", screenW, screenH);
            s._profile = profile; s._creatures = creatures;
            s.Follow(feed);
            return s;
        }

        protected override IScreenView Build(float w, float h) => new StatsView(_creatures, _profile, w, h, Clock) { OnBack = Exit };
        protected override void ProfileChanged(IDictionary<string, object> profile) { _profile = profile; View = Build(Wdp, Hdp); }
    }
}
