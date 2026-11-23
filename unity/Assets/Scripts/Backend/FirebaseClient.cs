// The Firebase backend for the Unity port, in one object (UNITY_MIGRATION_PLAN.md step 3):
//
//   var fb = new FirebaseClient(FirebaseConfig.Live(), new PlayerPrefsAuthStore());   // on the main thread
//   fb.Auth.AuthStateChanged += user => { … };                 // onAuthStateChanged
//   await fb.Auth.Start();                                     // the saved session, "Keep me signed in" applied
//   fb.Auth.SetKeepSignedIn(keep);
//   var user = await fb.Auth.LoginWithEmail(email, password);  // FirebaseAuthException.Message: the app's words
//   var feed = fb.Data.SubscribeToUserProfile(user.Uid);       // feed.Changed += profile => …  (IDictionary)
//   fb.Data.SaveStack(uid, outcome.Update, outcome.Coins, outcome.Xp, feed.Current, levelAfter);
//   var prize = await fb.Data.CallAndRefresh("spinWheel", new Dictionary<string, object> { { "tzOffsetMinutes", tz } });
//
// Lower down: fb.Firestore (Get / Set / Update / Add / List / RunTransaction), fb.Functions.Call(name, data).
// Tests and the editor can point it at the Local Emulator Suite with FirebaseConfig.Emulator().
using System;

namespace SquishSquad.Backend
{
    public sealed class FirebaseClient : IDisposable
    {
        public readonly FirebaseConfig Config;
        public readonly IHttp Http;
        public readonly FirebaseAuth Auth;
        public readonly Firestore Firestore;
        public readonly FirebaseFunctions Functions;
        public readonly UserData Data;
        readonly bool ownsHttp;

        public FirebaseClient(FirebaseConfig config, IAuthStore store, IHttp http = null)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            ownsHttp = http == null;
            Http = http ?? new HttpClientHttp();
            Auth = new FirebaseAuth(Config, Http, store);
            Firestore = new Firestore(Config, Http, Auth);
            Functions = new FirebaseFunctions(Config, Http, Auth);
            Data = new UserData(Firestore, Functions);
            // a profile feed belongs to one signed-in user
            Auth.AuthStateChanged += u =>
            {
                if (Data.Feed != null && (u == null || u.Uid != Data.Feed.Uid)) Data.Feed.Dispose();
            };
        }

        public void Dispose()
        {
            Data.Feed?.Dispose();
            if (ownsHttp) (Http as IDisposable)?.Dispose();
        }
    }
}
