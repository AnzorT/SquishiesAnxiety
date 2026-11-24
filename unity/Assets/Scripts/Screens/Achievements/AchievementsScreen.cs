// Achievements in Unity (AchievementsView on screen): the menu's trophy opens it, its back orb (or Android's back)
// calls OnExit. It follows the profile while open (a badge done meanwhile turns gold).
//   var s = AchievementsScreen.Create(parent, profile, fb?.Data.Feed); s.OnExit = () => Destroy(s.gameObject);
using System.Collections.Generic;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class AchievementsScreen : ScreenViewHost
    {
        IDictionary<string, object> _profile;
        IList<Creature> _creatures;
        int _custom;

        /// <summary>`creatures`: the catalog the app counts (null: the roster without what isn't out yet); `customCount`:
        /// the player's own creations; `feed`: the profile to follow, if any.</summary>
        public static AchievementsScreen Create(Transform parent, IDictionary<string, object> profile, IProfileFeed feed = null, IList<Creature> creatures = null, int customCount = 0, float screenW = 0, float screenH = 0)
        {
            var s = Make<AchievementsScreen>(parent, "Achievements", screenW, screenH);
            s._profile = profile; s._creatures = creatures; s._custom = customCount;
            s.Follow(feed);
            return s;
        }

        protected override IScreenView Build(float w, float h) => new AchievementsView(_creatures, _profile, w, h, Clock, _custom) { OnBack = Exit };

        protected override void ProfileChanged(IDictionary<string, object> profile)
        {
            // the app recomputes the list (the carousel keeps its place)
            int index = ((AchievementsView)View).Index;
            _profile = profile;
            View = new AchievementsView(_creatures, profile, Wdp, Hdp, Clock, _custom, index) { OnBack = Exit };
        }
    }
}
