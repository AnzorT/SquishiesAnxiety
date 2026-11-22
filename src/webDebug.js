// Whether the app's WebViews (the menu, the chest smash, the rigs) can be inspected from a computer over USB
// (chrome://inspect, adb forward webview_devtools_remote_<pid>). On in development builds; release builds keep it off.
// (To measure the pages on a phone in a release build, set it to true for that build only.)
export const WEBVIEW_DEBUG = __DEV__;

// Developer mode (2026-11-21, the user: "when we run developer mode, ignore the 2-step authentication we do to new
// registers"): a new email account plays at once, without confirming its address (no verify screen, no email sent).
// On in development builds and in a measuring build (WEBVIEW_DEBUG set true above); always off in a normal release.
export const SKIP_EMAIL_VERIFY = WEBVIEW_DEBUG;
