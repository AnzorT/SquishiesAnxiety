// The Level Road in Unity (RoadView on screen, src/screens/LevelRoadScreen.js landscape): Settings' / the menu's level
// chip and the LEVEL UP card's COLLECT (`autoClaim`: the levels to claim as it opens) open it:
//   var r = RoadScreen.Create(parent, profile, fb, uid); r.OnExit = ...;
// Claims are the `squad` Cloud Function's (levelClaim / levelClaimAll, ShopWrites); a chest prize opens over it
// (ChestOpening: the treasure vault and the smash). The profile feed brings each claim in.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class RoadScreen : ScreenViewHost
    {
        IDictionary<string, object> _profile;
        FirebaseClient _fb;
        IList<int> _auto;
        WithChests _stack;
        RoadView _road;

        public static RoadScreen Create(Transform parent, IDictionary<string, object> profile, FirebaseClient fb, string uid, IList<int> autoClaim = null, float screenW = 0, float screenH = 0)
        {
            var s = Make<RoadScreen>(parent, "Level Road", screenW, screenH);
            s._profile = profile; s._fb = fb; s._auto = autoClaim;
            s.Follow(fb?.Data.Feed);
            return s;
        }

        protected override IScreenView Build(float w, float h)
        {
            var v = new RoadView(_profile, w, h, Clock, () => DateTime.Now, null, _auto)
            {
                OnBack = Exit,
                OnSquad = (move, args) => _fb != null ? ShopWrites.Squad(_fb.Functions, move, args, DateTime.Now) : Task.FromException<IDictionary<string, object>>(new SquadError("offline")),
            };
            _road = v;
            _stack = new WithChests(v);
            v.OnOpenChest = req => _stack.Opening = new ChestOpening(req, w, h, Clock, ShopScreen.BuddyKey(_profile));
            return _stack;
        }

        protected override void Back() { if (_stack?.Opening == null) Exit(); }

        protected override void ProfileChanged(IDictionary<string, object> profile)
        {
            _profile = profile;
            _road?.SetProfile(profile);
        }
    }
}
