// A chest opening on its own (the treasure vault, then the smash): for a chest another screen got from the server (the
// Level Pass's chest prize, a bundle, the daily gift's chest):
//   var c = ChestScreen.Create(parent, new List<IDictionary<string, object>> { result.chest }, profile);
//   c.OnCollected = r => ...toast...; c.OnExit = () => Destroy(c.gameObject);
// or for a move still on its way: ChestScreen.Create(parent, group, size, task, profile).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class ChestScreen : ScreenViewHost
    {
        ChestRequest _req;
        IDictionary<string, object> _profile;
        public Action<IDictionary<string, object>> OnCollected;

        /// <summary>Chests the server has rolled (squad results: { group, size, final, id, … }), opened one after the other.</summary>
        public static ChestScreen Create(Transform parent, List<IDictionary<string, object>> rolled, IDictionary<string, object> profile, float screenW = 0, float screenH = 0)
        {
            var s = Make<ChestScreen>(parent, "Chest", screenW, screenH);
            s._req = new ChestRequest { Group = Prof.Str(rolled[0]["group"]), Size = Prof.Str(rolled[0]["size"]), Rolled = rolled };
            s._profile = profile;
            return s;
        }

        /// <summary>A chest whose move is on its way: the smash comes up on `group` / `size` at once.</summary>
        public static ChestScreen Create(Transform parent, string group, string size, Task<IDictionary<string, object>> result, IDictionary<string, object> profile, float screenW = 0, float screenH = 0)
        {
            var s = Make<ChestScreen>(parent, "Chest", screenW, screenH);
            s._req = new ChestRequest { Group = group, Size = size, Result = result };
            s._profile = profile;
            return s;
        }

        protected override IScreenView Build(float w, float h)
        {
            var o = new ChestOpening(_req, w, h, Clock, ShopScreen.BuddyKey(_profile))
            {
                OnCollected = r => OnCollected?.Invoke(r),
                OnDone = Exit,
            };
            return o;
        }

        // (Android's back doesn't leave a chest half open, as the app's smash)
        protected override void Back() { }
    }
}
