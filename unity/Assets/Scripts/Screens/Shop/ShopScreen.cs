// The Shop in Unity (ShopView on screen, the royal Shop of src/screens/ShopScreen.js): the menu's SHOP, its coin / gem
// pills (tab "gems"), Characters' "Find it in chests" (tab "chests") open it:
//   var s = ShopScreen.Create(parent, profile, fb, uid, "daily"); s.OnExit = ...;
// Its moves are the `squad` Cloud Function's (ShopWrites); a chest opens over it (ChestOpening: the treasure vault and
// the smash) and its COLLECT shows the app's toast. The profile feed brings each move's result in.
// Real money: OnBuyProduct is the hook (a PRODUCTS key: 'removeAds', 'gems450',
// 'offer:starter' → the grant { granted: 'bundle' | 'pass' | 'gems', chests, gems, offer }, or null; it may throw: its message is shown);
// the menu sets it to Backend/Billing (Google Play). PriceOf gives the store's price labels (default: the set prices, economy.js).
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class ShopScreen : ScreenViewHost
    {
        IDictionary<string, object> _profile, _offers;
        FirebaseClient _fb;
        string _tab;
        WithChests _stack;
        public ShopView Shop { get; private set; }
        /// <summary>A real-money purchase (null: not possible in Unity yet).</summary>
        public Func<string, Task<IDictionary<string, object>>> OnBuyProduct;
        public Func<string, string> PriceOf;

        /// <summary>`tab`: daily | chests | deals | gems. `offers`: config/offers (null: the design's defaults).</summary>
        public static ShopScreen Create(Transform parent, IDictionary<string, object> profile, FirebaseClient fb, string uid, string tab = "chests", IDictionary<string, object> offers = null, float screenW = 0, float screenH = 0)
        {
            var s = Make<ShopScreen>(parent, "Shop", screenW, screenH);
            s._profile = profile; s._fb = fb; s._tab = tab; s._offers = offers;
            s.Follow(fb?.Data.Feed);
            return s;
        }

        protected override IScreenView Build(float w, float h)
        {
            var v = new ShopView(_profile, _offers, _tab, w, h, Clock, () => DateTime.Now)
            {
                OnBack = Exit,
                PriceOf = PriceOf,
                OnBuyProduct = OnBuyProduct,
                OnSquad = (move, args) => _fb != null ? ShopWrites.Squad(_fb.Functions, move, args, DateTime.Now) : Task.FromException<IDictionary<string, object>>(new SquadError("offline")),
            };
            Shop = v;
            _stack = new WithChests(v);
            v.OnOpenChest = req =>
            {
                var o = new ChestOpening(req, w, h, Clock, BuddyKey(_profile));
                o.OnCollected = v.Collected;
                _stack.Opening = o;
            };
            return _stack;
        }

        /// <summary>The player's squishy (squad/lobby.js selectedId): its picture key, for the vault's coin.</summary>
        public static string BuddyKey(IDictionary<string, object> p)
        {
            ShopData.Ensure();
            var sel = Prof.Get(Prof.Map(Prof.Get(p, "lobby")), "sel");
            string id = sel != null && Prof.Owns(p, Prof.IsNum(sel) ? Prof.JsStr(Prof.D(sel)) : sel.ToString()) ? (Prof.IsNum(sel) ? Prof.JsStr(Prof.D(sel)) : sel.ToString()) : Prof.Owns(p, "1") ? "1" : "0";
            return ShopData.ById.TryGetValue(id, out var c) ? c.Key : null;
        }

        /// <summary>Opened again on a tab (a pill, GET SEASON CHEST…): that tab, no sheet up.</summary>
        public void GoTab(string tab) => Shop?.GoTab(tab);

        protected override void Back() { if (_stack?.Opening == null) Exit(); }

        protected override void ProfileChanged(IDictionary<string, object> profile)
        {
            _profile = profile;
            Shop?.SetProfile(profile);
        }
    }
}
