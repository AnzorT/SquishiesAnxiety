// The app's start, as App.js decides its stage: the splash until sign-in is known (and, signed in, the profile is
// here), then the log in / register screen while signed out, the verify screen while an email account hasn't confirmed
// its address (needsVerification, until "I've verified" says it has: verifiedNow), else the Main Menu with the player's
// coins, gems, level and XP (subscribeToUserProfile). Signing out (the menu's dev panel; the app's settings screen isn't
// ported) goes back to the log in screen. "Keep me signed in" left unticked drops the session at the next start
// (FirebaseAuth.Start).
//
// Development builds and the editor also get a small "Dev" button on the start-up screens: the menu offline (the
// exported numbers, no account), as before this flow existed.
using System;
using System.Collections.Generic;
using SquishSquad.Backend;
using SquishSquad.Menu;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class AppFlow : MonoBehaviour
    {
        public static AppFlow Instance { get; private set; }

        FirebaseClient _fb;
        AuthUser _user;
        bool _authChecked, _splashDone, _verifiedNow, _offline;
        IProfileFeed _feed;
        IDictionary<string, object> _profile;
        bool _profileLoaded, _profileDirty;
        Camera _cam;
        SplashView _splash;
        AuthView _auth;
        VerifyView _verify;
        MenuScreen _menu;
        string _stage;
        string _toast;
        float _toastUntil;

        public string Stage => _stage;

        void Awake()
        {
            // the menu's pages (Characters, the Level Pass) read the signed-in player from here
            SquishSquad.Menu.CharactersPageLink.Source = () =>
                _offline || _fb == null || _user == null || _profile == null || string.IsNullOrEmpty(_user.Uid)
                    ? null
                    : new SquishSquad.Menu.CharactersPageLink.Player { Profile = _profile, Uid = _user.Uid, Fb = _fb };
            Instance = this;
            _cam = MenuScreen.CreateCamera(transform);
        }

        void Start()
        {
            _splash = SplashView.Create(transform);
            _splash.Finished += () => _splashDone = true;
            _stage = "splash";
            try
            {
                _fb = new FirebaseClient(FirebaseConfig.Live(), new PlayerPrefsAuthStore());
                _fb.Data.Log = s => Debug.Log("[Firebase] " + s);
                _fb.Auth.AuthStateChanged += OnAuth;
                _ = _fb.Auth.Start();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                _authChecked = true;   // no backend: signed out
            }
        }

        void OnDestroy()
        {
            if (Instance == this) Instance = null;
            MenuScreen.SignOutRequested -= SignOut;
            _fb?.Dispose();
        }

        // subscribeToAuthUser: every sign-in / sign-out
        void OnAuth(AuthUser u)
        {
            if (u?.Uid != _user?.Uid) _verifiedNow = false;   // a different account starts unconfirmed again
            _user = u;
            _authChecked = true;
            if (u == null)
            {
                _feed?.Dispose();
                _feed = null;
                _profile = null;
                _profileLoaded = false;
                _profileDirty = true;
                return;
            }
            if (_feed != null && _feed.Uid == u.Uid) return;
            _feed?.Dispose();
            _profile = null;
            _profileLoaded = false;
            _feed = _fb.Data.SubscribeToUserProfile(u.Uid);
            _feed.Changed += p => { _profile = p; _profileLoaded = true; _profileDirty = true; };
            _feed.Failed += e => Debug.LogWarning("[Firebase] profile: " + e.Message);
        }

        string StageNow() => AppStage.Of(_splashDone, _authChecked, _user, _verifiedNow, _offline);

        void Update()
        {
            // the splash moves on once sign-in is known and, signed in, the profile is here (App.js: and the catalog)
            if (_splash != null && AppStage.SplashReady(_authChecked, _user, _profileLoaded)) _splash.SetReady();
            var stage = StageNow();
            if (stage != _stage) Go(stage);
            if (_menu != null && (_profileDirty || _menuFresh))
            {
                _profileDirty = _menuFresh = false;
                _menu.SetPlayer(_offline || _profile == null ? null : HudValues.FromProfile(_profile));
            }
        }

        bool _menuFresh;

        void Go(string stage)
        {
            var was = _stage;
            _stage = stage;
            if (was == "splash" && _splash != null) { Destroy(_splash.gameObject); _splash = null; }
            if (_auth != null) { Destroy(_auth.gameObject); _auth = null; }
            if (_verify != null) { Destroy(_verify.gameObject); _verify = null; }
            if (stage != "menu" && _menu != null) { MenuScreen.SignOutRequested -= SignOut; Destroy(_menu.gameObject); _menu = null; }
            _cam.enabled = stage != "menu";
            switch (stage)
            {
                case "auth":
                    _auth = AuthView.Create(transform, _fb != null ? new FirebaseAuthBackend(_fb) : null, Toast);
                    break;
                case "verify":
                    _verify = VerifyView.Create(transform, _user?.Email, new FirebaseVerifyBackend(_fb), () => _verifiedNow = true, SignOut);
                    break;
                case "menu":
                    if (_menu == null)
                    {
                        _menu = MenuScreen.Instance != null ? MenuScreen.Instance : new GameObject("MainMenu").AddComponent<MenuScreen>();
                        MenuScreen.SignOutRequested += SignOut;
                    }
                    _menuFresh = true;
                    break;
            }
        }

        // App.js handleLogout -> logout()
        public void SignOut()
        {
            if (_offline) { _offline = false; return; }
            _fb?.Auth.SignOut();
        }

        public void Toast(string text)
        {
            _toast = text;
            _toastUntil = Time.unscaledTime + 1.8f;
        }

        // ---- dev: the menu without an account -------------------------------------------------------------------------
        static bool DevTools => Application.isEditor || Debug.isDebugBuild;
        static Rect DevRect => new Rect(Screen.width * 0.44f, 2f, Screen.width * 0.12f, Screen.height * 0.05f);

        /// <summary>Whether a touch at `dp` (from the top-left) is on the dev button (the screens ignore it).</summary>
        public static bool InDevPanel(Vector2 dp)
        {
            if (!DevTools || Instance == null || Instance._stage == "menu") return false;
            float k = Screen.height / 384f;
            return DevRect.Contains(new Vector2(dp.x * k, dp.y * k));
        }

        void OnGUI()
        {
            float u = Screen.height / 384f;
            if (DevTools && _stage != "menu" && _stage != "splash")
            {
                var st = new GUIStyle(GUI.skin.button) { fontSize = Mathf.RoundToInt(10 * u) };
                if (GUI.Button(DevRect, "Dev: menu offline", st)) _offline = true;
            }
            if (_toast != null && Time.unscaledTime < _toastUntil)
            {
                var box = new GUIStyle(GUI.skin.box) { fontSize = Mathf.RoundToInt(13 * u), alignment = TextAnchor.MiddleCenter };
                box.normal.textColor = Color.white;
                GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.44f, Screen.width * 0.5f, Screen.height * 0.1f), _toast, box);
            }
        }
    }
}
