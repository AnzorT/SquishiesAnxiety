using System.Collections.Generic;
// The Main Menu screen: a camera that shows the screen in pixels, the menu (MenuView), touches, and a small dev panel
// (frame rate, level and season, sign out). Signed in (App/AppFlow.cs), the HUD shows the player's coins, gems, level
// and XP (SetPlayer) and the house is the player's level's; offline / signed out (the dev menu) it keeps the exported
// numbers and the dev panel's level.
using SquishSquad.Games.Stack;
using SquishSquad.Ui;
using SquishSquad.Audio;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed class MenuScreen : MonoBehaviour
    {
        public static MenuScreen Instance { get; private set; }

        /// <summary>Fired with the piece's tap name ("play", "shop", "characters", "level", ...).</summary>
        public static event System.Action<string> Tapped;
        /// <summary>The dev panel's "Sign out" (the settings screen that has it in the app isn't ported).</summary>
        public static event System.Action SignOutRequested;

        HudValues _player;   // the signed-in player's numbers (null: the exported ones)
        int _playerLevel;    // their level: the house picture's (1-30)

        /// <summary>The signed-in player's numbers (null: offline, the exported ones). A new level rebuilds the house.</summary>
        public void SetPlayer(HudValues v)
        {
            _player = v;
            int lv = v != null ? Mathf.Clamp(v.Level, 1, 30) : 0;
            if (_view == null) { _playerLevel = lv; return; }
            if (lv != _playerLevel && _view.Where == MenuView.Place.Home && _game == null) { _playerLevel = lv; Rebuild(); return; }
            _view.SetHud(v ?? HudValues.Baked, NowMs);
        }

        int ViewLevel => _player != null && _playerLevel > 0 ? _playerLevel : MenuState.Level;

        Camera _cam;
        MenuLayout _layout;
        MenuView _view;
        MenuView.PieceView _down;
        int _w, _h;
        float _t0;

        // dev panel
        bool _panel;
        string _toast;
        float _toastUntil, _fps, _fpsTime;
        int _fpsFrames;

        void Awake()
        {
            Instance = this;
            _cam = CreateCamera(transform);
            _layout = MenuLayout.Load();
        }

        void Start() => Rebuild();

        void OnDestroy()
        {
            ClosePage();   // (the Characters page / Level Pass, if open)
            _view?.Dispose();
            if (Instance == this) Instance = null;
        }

        public static Camera CreateCamera(Transform parent)
        {
            var go = new GameObject("MenuCamera");
            go.transform.SetParent(parent, false);
            var cam = go.AddComponent<Camera>();
            cam.orthographic = true;
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = Color.black;
            cam.nearClipPlane = -10f;
            cam.farClipPlane = 10f;
            cam.allowMSAA = false;
            cam.allowHDR = false;
            FitCamera(cam, Screen.width, Screen.height);
            return cam;
        }

        // one world unit = one screen pixel; world (0, 0) is the screen's top-left, y down the screen is -y
        public static void FitCamera(Camera cam, float w, float h)
        {
            cam.orthographicSize = h / 2f;
            cam.transform.localPosition = new Vector3(w / 2f, -h / 2f, -5f);
        }

        void Rebuild()
        {
            ClosePage();   // (the Characters page / Level Pass, if open)
            _view?.Dispose();
            _w = Screen.width; _h = Screen.height;
            FitCamera(_cam, _w, _h);
            _view = new MenuView(_layout, transform, _w, _h, ViewLevel, MenuState.Season);
            _t0 = Time.unscaledTime;
            if (_player != null) _view.SetHud(_player, 0f);
            _view.Tick(0f);
        }

        // a game open over the menu, started from its card in the Game Park (all four puzzle games; Squish Time isn't ported yet)
        MonoBehaviour _game;

        void BeforeGame()
        {
            UiPiece.PxPerDp = _h / _layout.reference.dp[1];
            _view.Shown = false;
        }

        // back from a game: the app opens the menu straight into the park, the carousel shown at once
        void AfterGame()
        {
            _game = null;
            _view.Shown = true;
            if (_view.Where == MenuView.Place.Park) _view.ShowGames(NowMs, true);
        }

        // The games read the player's progress from their own profile. Signed in: a copy of the account's profile, so the
        // maps show its real levels and stars, and what they win is saved to the account where the app saves it
        // (Games/Shared/AccountSaves.cs; the copy keeps the new values at once, the menu's profile feed after the write).
        // Offline: the levels kept on the device, and what they win stays in memory.
        void SeedGameProfiles()
        {
            var player = CharactersPageLink.Get();
            if (player?.Profile != null && player.Fb != null && !string.IsNullOrEmpty(player.Uid))
            {
                SquishSquad.Games.Stack.StackGame.Profile = DeepCopy(player.Profile);
                SquishSquad.Games.Sort.SortGame.Profile = DeepCopy(player.Profile);
                SquishSquad.Games.Hop.HopGame.Profile = DeepCopy(player.Profile);
                SquishSquad.Games.Squishdoku.SdLevel.Profile = DeepCopy(player.Profile);
                SquishSquad.Games.Shared.AccountSaves.Use(player.Uid, player.Fb.Data);
                return;
            }
            SquishSquad.Games.Shared.AccountSaves.Use(null, null);
            SetLv(SquishSquad.Games.Stack.StackGame.Profile, "stack", MenuState.StackLevel);
            SetLv(SquishSquad.Games.Hop.HopGame.Profile, "hop", MenuState.HopLevel);
        }

        static void SetLv(IDictionary<string, object> p, string game, int lv)
        {
            if (!(p.TryGetValue(game, out var r) && r is IDictionary<string, object> rec)) { rec = new Dictionary<string, object>(); p[game] = rec; }
            if (!rec.TryGetValue("lv", out var have) || System.Convert.ToDouble(have) < lv) rec["lv"] = (double)lv;
        }

        static IDictionary<string, object> DeepCopy(IDictionary<string, object> m)
        {
            var c = new Dictionary<string, object>();
            foreach (var kv in m) c[kv.Key] = Copy(kv.Value);
            return c;
        }

        static object Copy(object v)
        {
            if (v is IDictionary<string, object> d) return DeepCopy(d);
            if (v is IList<object> l) { var c = new List<object>(l.Count); foreach (var x in l) c.Add(Copy(x)); return c; }
            return v;
        }

        // ---- the app's screens over the menu (Screens/): the trophy, the gear, and once a day the spin then the streak ----
        static IDictionary<string, object> ProfileOrEmpty(CharactersPageLink.Player p) => p?.Profile ?? new Dictionary<string, object>();

        // (these screens don't remove themselves when they close, as the games do)
        void CloseScreen(MonoBehaviour s)
        {
            if (s != null) Destroy(s.gameObject);
            if (_game == s) AfterGame();
        }

        void OpenAchievements()
        {
            BeforeGame();
            var p = CharactersPageLink.Get();
            var s = SquishSquad.Screens.AchievementsScreen.Create(transform, ProfileOrEmpty(p));
            s.OnExit = () => CloseScreen(s);
            _game = s;
        }

        void OpenShop(string tab)
        {
            BeforeGame();
            var p = CharactersPageLink.Get();
            var s = SquishSquad.Screens.ShopScreen.Create(transform, ProfileOrEmpty(p), p?.Fb, p?.Uid, tab);
            s.OnExit = () => CloseScreen(s);
            // real money: Google Play (Backend/Billing), granted by the verifyPurchase Cloud Function
            if (p?.Fb != null && p.Uid != null)
            {
                if (!_billingStarted) { _billingStarted = true; _ = SquishSquad.Backend.Billing.Init(p.Fb); }
                s.PriceOf = SquishSquad.Backend.Billing.PriceLabel;
                s.OnBuyProduct = key => SquishSquad.Backend.Billing.Buy(p.Fb, p.Uid, key);
            }
            _game = s;
        }

        static bool _billingStarted;

        void OpenSettings()
        {
            BeforeGame();
            var p = CharactersPageLink.Get();
            var s = SquishSquad.Screens.SettingsScreen.Create(transform, ProfileOrEmpty(p), p?.Fb, p?.Uid);
            s.OnLogout = () => { CloseScreen(s); SignOutRequested?.Invoke(); };
            s.OnExit = () => CloseScreen(s);
            _game = s;
        }

        // App.js: the daily spin (stage 'wheel') when it's due, then the streak's intro (stage 'streak'), then the menu;
        // the streak's DAILY CHALLENGES opens the daily sheet. Checked once, when the signed-in player's profile is in.
        bool _dailyChecked;

        void CheckDaily()
        {
            if (_dailyChecked || _game != null || _page != null || _view == null || _view.Where != MenuView.Place.Home) return;
            var p = CharactersPageLink.Get();
            if (p?.Profile == null) return;
            _dailyChecked = true;
            var now = System.DateTime.Now;
            if (SquishSquad.Screens.ScreenWrites.SpinDue(p.Profile, now))
            {
                BeforeGame();
                var s = SquishSquad.Screens.SpinScreen.Create(transform, p.Profile, p.Fb);
                s.OnExit = () => { CloseScreen(s); StreakIntro(p); };
                _game = s;
            }
            else StreakIntro(p);
        }

        void StreakIntro(CharactersPageLink.Player p)
        {
            if (p?.Profile == null || !SquishSquad.Screens.ScreenWrites.StreakIntroDue(p.Profile, System.DateTime.Now)) return;
            BeforeGame();
            var s = SquishSquad.Screens.StreakScreen.Create(transform, p.Profile, true, p.Fb, p.Uid);
            s.OnExit = () => CloseScreen(s);
            s.OnOpenDaily = () =>
            {
                CloseScreen(s);
                BeforeGame();
                var d = SquishSquad.Screens.DailySheetScreen.Create(transform, p.Profile, p.Fb, p.Uid);
                d.OnExit = () => CloseScreen(d);
                _game = d;
            };
            _game = s;
        }

        // BLITZ from a hub: the run over the hub (hidden meanwhile); leaving the run comes back to the hub
        void OpenBlitzOver(MonoBehaviour hub, System.Func<MonoBehaviour> create)
        {
            hub.gameObject.SetActive(false);
            var run = create();
            switch (run)
            {
                case SquishSquad.Games.Stack.StackGame g: g.OnExit = () => Back(hub); break;
                case SquishSquad.Games.Sort.SortGame g: g.OnExit = () => Back(hub); break;
            }
            _game = run;
        }

        void Back(MonoBehaviour hub)
        {
            if (hub == null) { AfterGame(); return; }
            hub.gameObject.SetActive(true);
            _game = hub;
        }

        // Squish Time (the park's first card): the player's creature in use (Mittens offline)
        void OpenSquish()
        {
            BeforeGame();
            var p = CharactersPageLink.Get();
            var key = "mittens";
            if (p?.Profile != null)
            {
                var id = CharactersPageLink.SelectedId(p.Profile);
                var data = SquishSquad.Backend.Json.Parse(Resources.Load<TextAsset>("Squish/squish").text) as IDictionary<string, object>;
                if (data != null && data["roster"] is IList<object> roster)
                    foreach (var c in roster)
                        if (c is IDictionary<string, object> e && System.Convert.ToString(e["id"]) == id) { key = (string)e["key"]; break; }
            }
            var s = SquishSquad.Games.Squish.SquishTime.Create(transform, key, p?.Profile ?? new Dictionary<string, object>(), p?.Fb, p?.Uid);
            s.OnExit = AfterGame;   // (it removes itself)
            _game = s;
        }

        // each game opens on its hub (Hop: its map), as the app's game screens do
        void OpenStack()
        {
            BeforeGame();
            SeedGameProfiles();
            var s = SquishSquad.Games.Stack.StackScreen.Create(transform);
            s.OnExit = AfterGame;
            s.OpenBlitz = _ => OpenBlitzOver(s, () => SquishSquad.Games.Stack.StackGame.CreateBlitz(transform));
            _game = s;
        }

        void OpenSort()
        {
            BeforeGame();
            SeedGameProfiles();
            var s = SquishSquad.Games.Sort.SortScreen.Create(transform);
            s.OnLevel = (theme, lv) => { if (theme == "fridge") MenuState.SortLevel = lv; };
            s.OnExit = AfterGame;
            s.OpenBlitz = _ => OpenBlitzOver(s, () => SquishSquad.Games.Sort.SortGame.CreateBlitz(transform));
            _game = s;
        }

        void OpenSquishdoku()
        {
            BeforeGame();
            SeedGameProfiles();
            var s = SquishSquad.Games.Squishdoku.SquishdokuScreen.Create(transform);
            s.AdsFree = false;   // (no ads in Unity yet; the save card offers its gem save)
            s.OnExit = AfterGame;
            _game = s;
        }

        void OpenHop()
        {
            BeforeGame();
            SeedGameProfiles();
            var s = SquishSquad.Games.Hop.HopScreen.Create(transform);
            s.OnLevel = lv => MenuState.HopLevel = lv;
            s.OnExit = AfterGame;
            _game = s;
        }

        // PLAY on a card, 420 ms after the tap (menu.js playAt -> x.playGame)
        void PlayGame(int i)
        {
            var c = _view.Carousel;
            var g = c.Game(i);
            c.Remember(i);
            if (g.id == "stack") { OpenStack(); return; }
            if (g.id == "sort") { OpenSort(); return; }
            if (g.id == "squishdoku") { OpenSquishdoku(); return; }
            if (g.id == "hop") { OpenHop(); return; }
            if (g.id == "squish") { OpenSquish(); return; }
            c.Model.PlayDone(NowMs);
            ShowToast(g.name + " isn't in the Unity version yet");
        }

        // the carousel's taps and swipes (menu.js showGames: the back orb, the arrows, the dots, PLAY and the window on
        // the middle card, a swipe over the carousel of more than 36 pu sideways)
        Vector2 _parkDown;
        ParkModel.Hit _parkHit;
        int _parkDot;
        bool _parkPress;

        void HandlePark(bool down, bool held, bool up, Vector2 page)
        {
            var c = _view.Carousel;
            if (c == null) return;
            var m = c.Model;
            if (down && !InPanel(page))
            {
                _parkPress = true;
                _parkDown = page;
                _parkHit = m.HitTest(page.x, page.y, out _parkDot);
                m.PlayPressed = _parkHit == ParkModel.Hit.Play;
            }
            if (!_parkPress || !up) return;
            _parkPress = false;
            m.PlayPressed = false;
            if (m.InCarousel(_parkDown.x, _parkDown.y) && m.Swipe(_parkDown.x, _parkDown.y, page.x, page.y, NowMs)) return;
            var hit = m.HitTest(page.x, page.y, out int dot);
            if (hit != _parkHit || (hit == ParkModel.Hit.Dot && dot != _parkDot)) return;   // (a click: down and up on it)
            switch (hit)
            {
                case ParkModel.Hit.Back: Snd.Play("tap"); _view.LeavePark(NowMs); break;
                case ParkModel.Hit.Prev: Snd.Play("swoosh"); m.Go(m.Cur - 1, NowMs); break;
                case ParkModel.Hit.Next: Snd.Play("swoosh"); m.Go(m.Cur + 1, NowMs); break;
                case ParkModel.Hit.Dot: Snd.Play("swoosh"); m.Go(dot, NowMs); break;
                case ParkModel.Hit.Play:
                    if (!c.Game(m.Cur).open) { Snd.Play("sd_locked"); ShowToast(c.Game(m.Cur).name + " isn't open yet"); }
                    else { Snd.Play("sd_select"); m.Play(NowMs); }
                    break;
            }
        }

        void Update()
        {
            CheckDaily();
            if (_game != null) return;   // (the game reads its own touches)
            if (Screen.width != _w || Screen.height != _h) Rebuild();
            _view.Tick((Time.unscaledTime - _t0) * 1000f);
            TickPage();   // (the Characters page / Level Pass over the menu, if open)
            HandleInput();
            if (_view.Carousel != null && _game == null)
            {
                int g = _view.Carousel.Model.TakePlay(NowMs);
                if (g >= 0) PlayGame(g);
            }

            _fpsFrames++;
            _fpsTime += Time.unscaledDeltaTime;
            if (_fpsTime >= 0.5f) { _fps = _fpsFrames / _fpsTime; _fpsFrames = 0; _fpsTime = 0f; }
        }

        void HandleInput()
        {
            bool down, held, up;
            Vector2 pos;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                pos = t.position;
                down = t.phase == TouchPhase.Began;
                up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled;
                held = !up;
            }
            else
            {
                pos = Input.mousePosition;
                down = Input.GetMouseButtonDown(0);
                up = Input.GetMouseButtonUp(0);
                held = Input.GetMouseButton(0);
            }
            var page = new Vector2(pos.x, _h - pos.y);   // the page's pixels: y down
            float dpPx = _h / _layout.reference.dp[1];
            // a page open over the menu (the Characters page, the Level Pass) takes the touches and Android's back
            if (_page != null) { _page.Input(down, held, up, page, NowMs, Input.GetKeyDown(KeyCode.Escape), Input.mouseScrollDelta.y); return; }

            // in the Game Park: the games carousel; back (Android's, Escape) walks home like its back orb
            if (_view.Where == MenuView.Place.Park)
            {
                if (Input.GetKeyDown(KeyCode.Escape)) { _view.LeavePark(NowMs); return; }
                HandlePark(down, held, up, page);
                return;
            }
            if (_view.Where != MenuView.Place.Home) return;
            if (down && !InPanel(page))
            {
                _down = _view.HitTest(page);
                _down?.SetPressed(true, dpPx);
            }
            if (_down != null && held) _down.SetPressed(_down.Hit.Contains(page), dpPx);
            if (_down != null && up)
            {
                var piece = _down;
                _down = null;
                piece.SetPressed(false, dpPx);
                if (piece.Hit.Contains(page)) OnTap(piece.Data.tap);
            }
        }

        float NowMs => (Time.unscaledTime - _t0) * 1000f;

        void OnTap(string tap)
        {
            Snd.Play("tap");
            if (tap == "play" && _view.EnterPark(NowMs)) { Snd.Play("whoosh"); return; }
            if ((tap == "characters" || tap == "level") && OpenPage(tap)) return;
            if (tap == "trophies") { OpenAchievements(); return; }
            if (tap == "settings") { OpenSettings(); return; }
            if (tap == "shop") { OpenShop("daily"); return; }
            Tapped?.Invoke(tap);
            if (Tapped == null) ShowToast(tap.ToUpperInvariant() + " isn't in the Unity version yet");
        }

        // ---- the Characters page and the Level Pass (CHARACTERS and the level crest; CharactersPage.cs, LevelPassPage.cs) ----
        IMenuPage _page;
        const int PageOrder = 1000;

        bool OpenPage(string tap)
        {
            if (_page != null) return true;
            _page = tap == "level" ? (IMenuPage)LevelPassPage.Open(transform, _w, _h, NowMs, PageOrder) : CharactersPage.Open(transform, _w, _h, NowMs, PageOrder);
            return _page != null;
        }

        void TickPage()
        {
            if (_page == null) return;
            if (!_page.Closed) _page.Tick(NowMs);
            if (_page.Closed) ClosePage();
            else _view.Shown = !_page.Covers;   // (the menu needn't draw under a page that covers it)
        }

        void ClosePage()
        {
            if (_page == null) return;
            _page.Dispose();
            _page = null;
            if (_view != null) _view.Shown = _game == null;
        }

        public void ShowToast(string text, float seconds = 1.6f)
        {
            _toast = text;
            _toastUntil = Time.unscaledTime + seconds;
        }

        public void SetState(int level, string seasonSetting)
        {
            MenuState.Level = level;
            MenuState.SeasonSetting = seasonSetting;
            Rebuild();
        }

        // ---- dev panel (IMGUI): frame rate; tap it for level / season ----------------------------------------------
        Rect FpsRect => new Rect(_w * 0.42f, 4f, _w * 0.16f, _h * 0.05f);
        Rect PanelRect => new Rect(_w * 0.3f, _h * 0.12f, _w * 0.4f, _h * 0.52f);
        bool InPanel(Vector2 page) => FpsRect.Contains(page) || (_panel && PanelRect.Contains(page));

        void OnGUI()
        {
            float u = _h / 384f;   // one dp
            var label = new GUIStyle(GUI.skin.label) { fontSize = Mathf.RoundToInt(11 * u), alignment = TextAnchor.MiddleCenter };
            label.normal.textColor = Color.white;
            if (GUI.Button(FpsRect, $"{_fps:0} fps", label)) _panel = !_panel;

            if (_panel)
            {
                var btn = new GUIStyle(GUI.skin.button) { fontSize = Mathf.RoundToInt(12 * u) };
                GUILayout.BeginArea(PanelRect, GUI.skin.box);
                GUILayout.Label(_player != null ? $"Level {_playerLevel} (the player's) · {MenuState.Season} ({MenuState.SeasonSetting})" : $"Level {MenuState.Level} · {MenuState.Season} ({MenuState.SeasonSetting})", label);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Level -", btn)) SetState(MenuState.Level - 1, MenuState.SeasonSetting);
                if (GUILayout.Button("Level +", btn)) SetState(MenuState.Level + 1, MenuState.SeasonSetting);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                foreach (var s in new[] { "auto", "sunny", "rainy", "snowy" })
                    if (GUILayout.Button(s, btn)) SetState(MenuState.Level, s);
                GUILayout.EndHorizontal();
                if (SignOutRequested != null && GUILayout.Button("Sign out", btn)) { _panel = false; SignOutRequested(); }
                if (GUILayout.Button("Close", btn)) _panel = false;
                GUILayout.EndArea();
            }

            if (_toast != null && Time.unscaledTime < _toastUntil)
            {
                var box = new GUIStyle(GUI.skin.box) { fontSize = Mathf.RoundToInt(13 * u), alignment = TextAnchor.MiddleCenter };
                box.normal.textColor = Color.white;
                GUI.Box(new Rect(_w * 0.25f, _h * 0.44f, _w * 0.5f, _h * 0.1f), _toast, box);
            }
        }
    }
}
