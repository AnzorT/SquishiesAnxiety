// The Main Menu screen: a camera that shows the screen in pixels, the menu (MenuView), touches, and a small dev panel
// (frame rate, level and season, sign out). Signed in (App/AppFlow.cs), the HUD shows the player's coins, gems, level
// and XP (SetPlayer) and the house is the player's level's; offline / signed out (the dev menu) it keeps the exported
// numbers and the dev panel's level.
using SquishSquad.Games.Stack;
using SquishSquad.Ui;
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

        void OpenStack()
        {
            BeforeGame();
            var g = StackGame.Create(transform, MenuState.StackLevel);
            g.OnExit = AfterGame;
            _game = g;
        }

        // (the app's Sort hub picks the fridge or the cupboard; until the hub is ported, the fridge)
        void OpenSort()
        {
            BeforeGame();
            var g = SquishSquad.Games.Sort.SortGame.Create(transform, MenuState.SortLevel, 0, 0, "fridge");
            g.OnLevel = lv => MenuState.SortLevel = lv;
            g.OnExit = AfterGame;
            _game = g;
        }

        // Squishdoku: the level it's on and HEAD START are kept by SquishdokuGame (PlayerPrefs) until the profile has them
        void OpenSquishdoku()
        {
            BeforeGame();
            var g = SquishSquad.Games.Squishdoku.SquishdokuGame.Create(transform, SquishSquad.Games.Squishdoku.SquishdokuGame.Level);
            g.OnExit = AfterGame;
            _game = g;
        }

        void OpenHop()
        {
            BeforeGame();
            var g = SquishSquad.Games.Hop.HopGame.Create(transform, MenuState.HopLevel);
            g.OnExit = () => { if (g.Level != null) MenuState.HopLevel = g.Level.Lv; AfterGame(); };
            _game = g;
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
                case ParkModel.Hit.Back: _view.LeavePark(NowMs); break;
                case ParkModel.Hit.Prev: m.Go(m.Cur - 1, NowMs); break;
                case ParkModel.Hit.Next: m.Go(m.Cur + 1, NowMs); break;
                case ParkModel.Hit.Dot: m.Go(dot, NowMs); break;
                case ParkModel.Hit.Play:
                    if (!c.Game(m.Cur).open) ShowToast(c.Game(m.Cur).name + " isn't open yet");
                    else m.Play(NowMs);
                    break;
            }
        }

        void Update()
        {
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
            if (tap == "play" && _view.EnterPark(NowMs)) return;
            if ((tap == "characters" || tap == "level") && OpenPage(tap)) return;
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
