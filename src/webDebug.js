// Whether the app's WebViews (the menu, the chest smash, the rigs) can be inspected from a computer over USB
// (chrome://inspect, adb forward webview_devtools_remote_<pid>). On in development builds; release builds keep it off.
// (To measure the pages on a phone in a release build, set it to true for that build only.)
export const WEBVIEW_DEBUG = __DEV__;

// Developer mode: development builds (Metro, the web version), and release APKs built for testing with
// `npm run android:dev-apk` (tools/build/dev-apk.mjs), which bakes EXPO_PUBLIC_DEV_MODE=1 into the bundle.
// A normal release build (and every Play Store AAB: android/app/build.gradle refuses one with the switch on) is not.
// Write it out as process.env.EXPO_PUBLIC_DEV_MODE: Expo only inlines that exact spelling at build time.
export const DEV_MODE = __DEV__ || process.env.EXPO_PUBLIC_DEV_MODE === '1';

// Developer mode (2026-11-21, the user: "when we run developer mode, ignore the 2-step authentication we do to new
// registers"; then: test release APKs too): a new email account plays at once, without confirming its address (no
// verify screen, no email sent), so test accounts can use made-up addresses. Also on in a measuring build
// (WEBVIEW_DEBUG set true above). Always off in a store build.
export const SKIP_EMAIL_VERIFY = DEV_MODE || WEBVIEW_DEBUG;
