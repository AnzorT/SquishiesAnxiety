// App.js's stage before Home, as one rule (AppFlow.cs runs it; tools/unity/auth-test checks it with real emulator
// accounts): the splash until it has finished and sign-in is known, then signed out the log in screen, an email
// account that hasn't confirmed its address the verify screen (until "I've verified" says it has), else the menu.
using SquishSquad.Backend;

namespace SquishSquad.Ui.Screens
{
    public static class AppStage
    {
        public const string Splash = "splash", Auth = "auth", Verify = "verify", Menu = "menu";

        public static string Of(bool splashDone, bool authChecked, AuthUser user, bool verifiedNow, bool offline = false)
        {
            if (offline) return Menu;
            if (!(splashDone && authChecked)) return Splash;
            if (user == null) return Auth;
            if (user.NeedsVerification && !verifiedNow) return Verify;
            return Menu;
        }

        /// <summary>SplashScreen's `ready`: sign-in known and, signed in, the profile loaded (App.js also waits for the
        /// creature catalog, which the Unity port doesn't load yet).</summary>
        public static bool SplashReady(bool authChecked, AuthUser user, bool profileLoaded) => authChecked && (user == null || profileLoaded);
    }
}
