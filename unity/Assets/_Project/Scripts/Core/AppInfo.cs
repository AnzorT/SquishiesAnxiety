// Facts about the app shared by every part of the port. Core holds plain game logic and data (no UI, no scenes),
// ported from the React Native app's src/*.js and testable on its own.
namespace PlushCrush.Core
{
    public static class AppInfo
    {
        /// <summary>Android/iOS app id, the same as the React Native app (google-services.json is keyed to it).</summary>
        public const string AppId = "com.plushcrush.app";

        /// <summary>The Firebase project the React Native app uses; the Unity app talks to the same one.</summary>
        public const string FirebaseProject = "squishy-app-61445";

        /// <summary>The layout size in dp: a Galaxy A15 held landscape (src/web/README.md).</summary>
        public const int RefWidthDp = 832, RefHeightDp = 384;
    }
}
