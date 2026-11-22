// The Main Menu screen: a camera that shows the screen in pixels, the menu (MenuView), touches, and a small dev panel
// (frame rate, level and season) until the real profile and the other screens are ported.
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed class MenuScreen : MonoBehaviour
    {
        public static MenuScreen Instance { get; private set; }

        /// <summary>Fired with the piece's tap name ("play", "shop", "characters", "level", ...).</summary>
        public static event System.Action<string> Tapped;

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
            _view?.Dispose();
            _w = Screen.width; _h = Screen.height;
            FitCamera(_cam, _w, _h);
            _view = new MenuView(_layout, transform, _w, _h, MenuState.Level, MenuState.Season);
            _t0 = Time.unscaledTime;
            _view.Tick(0f);
        }

        void Update()
        {
            if (Screen.width != _w || Screen.height != _h) Rebuild();
            _view.Tick((Time.unscaledTime - _t0) * 1000f);
            HandleInput();

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

            // in the Game Park (its games carousel isn't ported yet): back or a tap walks home
            if (_view.Where == MenuView.Place.Park && ((down && !InPanel(page)) || Input.GetKeyDown(KeyCode.Escape)))
            {
                _view.LeavePark(NowMs);
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
            Tapped?.Invoke(tap);
            if (Tapped == null) ShowToast(tap.ToUpperInvariant() + " isn't in the Unity version yet");
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
        Rect PanelRect => new Rect(_w * 0.3f, _h * 0.12f, _w * 0.4f, _h * 0.42f);
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
                GUILayout.Label($"Level {MenuState.Level} · {MenuState.Season} ({MenuState.SeasonSetting})", label);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Level -", btn)) SetState(MenuState.Level - 1, MenuState.SeasonSetting);
                if (GUILayout.Button("Level +", btn)) SetState(MenuState.Level + 1, MenuState.SeasonSetting);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                foreach (var s in new[] { "auto", "sunny", "rainy", "snowy" })
                    if (GUILayout.Button(s, btn)) SetState(MenuState.Level, s);
                GUILayout.EndHorizontal();
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
