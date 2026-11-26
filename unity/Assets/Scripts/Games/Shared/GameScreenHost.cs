// A game's whole screen in Unity (StackScreen, SortScreen, HopScreen): GameScreen's layers as pieces (UiPiece; a Sort
// container's doors as SortDoorPiece), its cards with CardPieces, the page under it all, the player's touches handed to
// it in dp (Escape is Android's back), and the level: when GameScreen says its view is built, the game is created in a
// slot that slides and fades as the view does (the game draws itself; its touches are its own), and when it hands
// control back (its OnExit) the screen goes back to the map.
//   var s = StackScreen.Create(parent[, screenW, screenH]); s.OnExit = ...;   then Init(nowMs) (Unity's Start does it)
//   and, outside play mode (CI screenshots), Advance(nowMs).
// BLITZ: OpenBlitz (the menu opens the game's run over its hub: Stack, Sort, Hop), else a note says it isn't in Unity yet.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Games.Sort;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using UnityEngine;

namespace SquishSquad.Games.Shared
{
    [DefaultExecutionOrder(-50)]   // (before the game's Update: a game's animations land on a ticker already at this frame)
    public abstract class GameScreenHost : MonoBehaviour
    {
        /// <summary>Back out of the screen (its back orb on the hub, Android's back): the screen is gone after this.</summary>
        public Action OnExit;
        /// <summary>BLITZ on the hub (Squish Sort: null, both containers). Unset: a note that it isn't in Unity yet.</summary>
        public Action<string> OpenBlitz;

        protected GameScreen Screen;
        protected float ScreenW, ScreenH;   // px (0: Screen)
        Ticker _tk;
        bool _started;
        float _w, _h;
        UiPiece _bg;
        CardPieces _cards;
        Transform _slot;
        SlotFade _fade;
        MonoBehaviour _game;
        int _frame;
        readonly Dictionary<ScreenLayer, Entry> _pieces = new Dictionary<ScreenLayer, Entry>();
        sealed class Entry { public Component Piece; public int Version = -1; public int Seen; }
        readonly Dictionary<ScreenLayer, (Ui.Cards.CardPieces.ILive live, int seen)> _live = new Dictionary<ScreenLayer, (Ui.Cards.CardPieces.ILive, int)>();
        string _toast;
        float _toastUntil;

        protected abstract GameDef MakeDef(IDictionary<string, object> profile);
        protected abstract IDictionary<string, object> Profile { get; }
        /// <summary>Creates the level's game under `parent`, calling `onExit` when it hands control back.</summary>
        protected abstract MonoBehaviour MakeLevel(Transform parent, int lv, string theme, Action onExit);

        protected static T Make<T>(Transform parent, string name, float screenW, float screenH) where T : GameScreenHost
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var s = go.AddComponent<T>();
            s.ScreenW = screenW; s.ScreenH = screenH;
            return s;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        static string Text(string path) => Resources.Load<TextAsset>(path)?.text ?? throw new InvalidOperationException("Resources/" + path + " is missing: run node tools/unity/export-maps.mjs");

        /// <summary>Builds the screen with the clock at `nowMs` (Unity calls it; CI screenshots call it outside play mode).</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            UiFont.ReadJson ??= name => Resources.Load<TextAsset>("Fonts/" + name)?.text;
            UiFont.ParseJson ??= json => JsonUtility.FromJson<UiFontData>(json);
            HubsData.LoadXml ??= Text;
            HubsData.Current ??= JsonUtility.FromJson<HubsData>(Text("Hubs/hubs"));
            _tk = new Ticker(nowMs);
            Ticker.Default = _tk;
            _w = (ScreenW > 0 ? ScreenW : UnityEngine.Screen.width) / UiPiece.PxPerDp;
            _h = (ScreenH > 0 ? ScreenH : UnityEngine.Screen.height) / UiPiece.PxPerDp;
            // the page (PageBg: a gradient and rays), stretched over the screen
            _bg = UiPiece.Create(transform, "page", -100);
            _bg.SetSvg(Text("Stack/bg"), 832, 384, 0);
            _bg.Transform = SquishSquad.Vector.Affine.ScaleBy(_w / 832, _h / 384);
            _cards = new CardPieces(transform, 20000);
            _slot = new GameObject("level").transform;
            _slot.SetParent(transform, false);
            _fade = _slot.gameObject.AddComponent<SlotFade>();
            Screen = new GameScreen(MakeDef(Profile), _w, _h)
            {
                Season = SquishSquad.Menu.MenuState.Season,
                OnExit = Exit,
                OpenLevel = OpenLevel,
                OnBlitz = theme => { if (OpenBlitz != null) OpenBlitz(theme); else ShowToast("BLITZ isn't in the Unity version yet"); },
            };
            Screen.Start();
            Draw();
        }

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the screen with it).</summary>
        public void Advance(double nowMs)
        {
            Ticker.Default = _tk;
            _tk.Tick(nowMs);
            Draw();
            foreach (var p in GetComponentsInChildren<UiPiece>(true)) p.Apply();
            foreach (var p in GetComponentsInChildren<SortDoorPiece>(true)) p.Apply();
        }

        /// <summary>The screen's model (tests, CI screenshots: taps through Down / Up, Back).</summary>
        public GameScreen Model => Screen;

        // (the time it takes, in the [Perf] log: App/PerfLog)

        void Update()

        {

            long perf = SquishSquad.App.PerfLog.Mark();

            try { UpdateHere(); } finally { SquishSquad.App.PerfLog.Add("game screen update", perf); }

        }

        void UpdateHere()
        {
            if (!_started) return;
            Ticker.Default = _tk;
            _tk.Tick(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            if (this != null && Screen != null) Draw();
        }

        // ---- the level ---------------------------------------------------------------------------------------------
        void OpenLevel(int lv, string theme)
        {
            if (_game != null) Kill(_game.gameObject);
            _slot.localPosition = Vector3.zero;
            _game = MakeLevel(_slot, lv, theme, LevelExited);
            Ticker.Default = _tk;
        }

        void LevelExited()
        {
            Ticker.Default = _tk;
            _game = null;
            Screen.LevelExited();
        }

        void Exit()
        {
            OnExit?.Invoke();
            Kill(gameObject);
        }

        // ---- layers to pieces ----------------------------------------------------------------------------------------
        static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        static Texture2D Picture(string path)
        {
            if (Textures.TryGetValue(path, out var t)) return t;
            if (path.EndsWith(".jpg"))
            {
                var bytes = Resources.Load<TextAsset>(path)?.bytes;
                if (bytes != null) { t = new Texture2D(2, 2, TextureFormat.RGB24, false) { name = path }; t.LoadImage(bytes); }
            }
            else t = UiPiece.LoadPicture(path);
            return Textures[path] = t;
        }

        void Draw()
        {
            Screen.Update();
            _frame++;
            bool playing = Screen.View == "game";
            int order = playing ? 9000 : 10;
            foreach (var l in Screen.Frame.List)
            {
                order++;
                if (l.Creature != null)
                {
                    // a live character (Squish Stack's walker): drawn by the creature code (Creatures/ResultRig.cs)
                    if (!_live.TryGetValue(l, out var lv)) _live[l] = lv = (Ui.Cards.CardPieces.MakeLive?.Invoke(transform, l.Creature), 0);
                    if (lv.live == null) { l.Creature.Failed = true; continue; }
                    lv.live.Sync(l.Transform, l.Visible ? l.Opacity : 0, order);
                    _live[l] = (lv.live, _frame);
                    continue;
                }
                if (!_pieces.TryGetValue(l, out var e)) _pieces[l] = e = new Entry();
                e.Seen = _frame;
                bool door = l.Door != null;
                if (e.Piece != null && (e.Piece is SortDoorPiece) != door) { Kill(e.Piece.gameObject); e.Piece = null; e.Version = -1; }
                if (e.Piece == null)
                {
                    if (!l.Visible || l.Opacity <= 0) continue;   // (made when it first shows)
                    e.Piece = door ? (Component)SortDoorPiece.Create(transform, l.Name, order) : UiPiece.Create(transform, l.Name, order);
                }
                if (door)
                {
                    var d = (SortDoorPiece)e.Piece;
                    if (e.Version != l.Version) { d.SetSvg(l.Markup, l.W, l.H, l.Margin); e.Version = l.Version; }
                    d.View = l.Door; d.Opacity = l.Opacity; d.Visible = l.Visible; d.Order = order;
                    continue;
                }
                var p = (UiPiece)e.Piece;
                var m = l.Transform;
                if (l.Picture != null)
                {
                    var tex = Picture(l.Picture);
                    if (tex == null) { p.Visible = false; continue; }
                    // a squishy: resizeMode contain, centred in its box; the world: stretched over the screen (cover)
                    float k = l.Picture.EndsWith(".jpg") ? 0 : Mathf.Min(l.W / tex.width, l.H / tex.height);
                    float fw = k > 0 ? tex.width * k : l.W, fh = k > 0 ? tex.height * k : l.H;
                    if (e.Version != l.Version) { p.SetPicture(tex, fw, fh); e.Version = l.Version; }
                    m = m * SquishSquad.Vector.Affine.Translate((l.W - fw) / 2, (l.H - fh) / 2);
                }
                else if (e.Version != l.Version && l.Markup != null) { p.SetSvg(l.Markup, l.W, l.H, l.Margin); e.Version = l.Version; }
                p.Transform = m;
                p.Opacity = l.Opacity;
                p.Visible = l.Visible;
                p.Order = order;
            }
            // live characters not drawn this frame hide; long gone ones go
            foreach (var kv in new List<KeyValuePair<ScreenLayer, (Ui.Cards.CardPieces.ILive live, int seen)>>(_live))
            {
                if (kv.Value.seen == _frame || kv.Value.live == null) continue;
                kv.Value.live.Sync(kv.Key.Transform, 0, 0);
                if (_frame - kv.Value.seen > 300) { kv.Value.live.Destroy(); _live.Remove(kv.Key); }
            }
            // pieces whose layers aren't drawn this frame hide; long gone ones are destroyed
            var gone = new List<ScreenLayer>();
            foreach (var kv in _pieces)
            {
                if (kv.Value.Seen == _frame) continue;
                if (kv.Value.Piece != null)
                {
                    if (kv.Value.Piece is UiPiece u) u.Visible = false; else ((SortDoorPiece)kv.Value.Piece).Visible = false;
                }
                if (_frame - kv.Value.Seen > 300) gone.Add(kv.Key);
            }
            foreach (var l in gone) { if (_pieces[l].Piece != null) Kill(_pieces[l].Piece.gameObject); _pieces.Remove(l); }
            _cards.Sync(Screen.Cards);
            // the level slides and fades with its view
            var st = Screen.SlotTransform;
            _slot.localPosition = new Vector3((float)st.E * UiPiece.PxPerDp, -(float)st.F * UiPiece.PxPerDp, 0);
            _fade.Opacity = Screen.SlotOpacity;
        }

        // ---- touch: one finger (or the mouse) in dp ------------------------------------------------------------------
        bool _down;

        void HandleInput()
        {
            if (Screen.View == "game") { _down = false; return; }   // (the level reads its own)
            if (Input.GetKeyDown(KeyCode.Escape)) { Screen.Back(); return; }
            bool down, held, up;
            Vector2 px;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                px = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up && !down;
            }
            else { px = Input.mousePosition; down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0); held = Input.GetMouseButton(0) && !down; }
            float x = px.x / UiPiece.PxPerDp, y = (UnityEngine.Screen.height - px.y) / UiPiece.PxPerDp;
            if (down) { _down = true; Screen.Down(x, y); }
            else if (_down && up) { _down = false; Screen.Up(x, y); }
            else if (_down && held) Screen.Move(x, y);
        }

        // ---- the note --------------------------------------------------------------------------------------------------
        public void ShowToast(string text, float seconds = 1.8f)
        {
            _toast = text;
            _toastUntil = Time.unscaledTime + seconds;
        }

        void OnGUI()
        {
            if (_toast == null || Time.unscaledTime >= _toastUntil) return;
            float u = UnityEngine.Screen.height / 384f;
            var box = new GUIStyle(GUI.skin.box) { fontSize = Mathf.RoundToInt(13 * u), alignment = TextAnchor.MiddleCenter };
            box.normal.textColor = Color.white;
            float w = UnityEngine.Screen.width, h = UnityEngine.Screen.height;
            GUI.Box(new Rect(w * 0.25f, h * 0.44f, w * 0.5f, h * 0.1f), _toast, box);
        }

        static void Kill(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) Destroy(o); else DestroyImmediate(o); }
    }

    /// <summary>Fades everything under its GameObject (the level in its sliding view) by Opacity: after every piece has
    /// set its own opacity this frame (they all do in LateUpdate), each renderer's is multiplied. (The app fades the view
    /// as one group; piece by piece is the same where they don't overlap, and it lasts ~0.2 s.)</summary>
    [DefaultExecutionOrder(10000)]
    public sealed class SlotFade : MonoBehaviour
    {
        public float Opacity = 1;
        MaterialPropertyBlock _pb;
        static readonly int OpacityId = Shader.PropertyToID("_Opacity");

        void LateUpdate()
        {
            if (Opacity >= 1) return;
            _pb ??= new MaterialPropertyBlock();
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.GetPropertyBlock(_pb);
                if (!_pb.HasFloat(OpacityId)) continue;
                float o = _pb.GetFloat(OpacityId) * Mathf.Clamp01(Opacity);
                _pb.SetFloat(OpacityId, o);
                r.SetPropertyBlock(_pb);
                r.forceRenderingOff = o <= 0;
            }
        }
    }
}
