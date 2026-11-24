// Squishdoku's Regular levels in Unity: SdLevel (the level as src/squishdoku/RegularGame.js plays it, no UnityEngine)
// shown as UiPieces, with the touches fed to it. Opened like StackGame:
//   var g = SquishdokuGame.Create(parent, startLv);  g.OnExit = ...;   (Start() runs Init; CI screenshots call
//   Init(nowMs) and Advance(nowMs) themselves)
// HEAD START (the hub's switch, the profile's sdk.head) is SquishdokuGame.HeadStart, kept in PlayerPrefs until Firebase.
// The pieces: Resources/Squishdoku (tools/unity/export-squishdoku.mjs), the creatures' cut-outs Resources/Stack/art.
// Blitz and the hub / map: SquishdokuScreen (the whole screen); this opens a Regular level alone.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using UnityEngine;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SquishdokuGame : MonoBehaviour
    {
        public Action OnExit;
        /// <summary>The level the player unlocked in this visit, if any (onExit's `unlocked`).</summary>
        public int? Unlocked { get; private set; }

        /// <summary>HEAD START: every level starts with its first row's creature placed (20% less time, 40% fewer coins and XP).</summary>
        public static bool HeadStart
        {
            get => PlayerPrefs.GetInt("sdk.head", 0) != 0;
            set { PlayerPrefs.SetInt("sdk.head", value ? 1 : 0); PlayerPrefs.Save(); }
        }

        /// <summary>The player's creatures (stack/art.js keys): the board's pieces and the score heads. Until the profile is
        /// ported, Mittens (creature 1, a new player's), as the app's preview player.</summary>
        public static string[] Owned = { "mittens" };
        /// <summary>The creature picked in the Lobby: the buddy on the right.</summary>
        public static string BuddyKey = "mittens";

        int _startLv;
        float _screenW, _screenH;
        bool _started;
        Ticker _tk;
        SdLevel _level;
        readonly Dictionary<SdLayer, (UiPiece piece, int version)> _pieces = new Dictionary<SdLayer, (UiPiece, int)>();
        readonly HashSet<SdLayer> _seen = new HashSet<SdLayer>();
        readonly List<SdLayer> _gone = new List<SdLayer>();

        public static SquishdokuGame Create(Transform parent, int startLv, float screenW = 0, float screenH = 0)
        {
            var go = new GameObject("Squishdoku");
            go.transform.SetParent(parent, false);
            var g = go.AddComponent<SquishdokuGame>();
            g._startLv = Mathf.Clamp(startLv, 1, Levels.LevelCount);
            g._screenW = screenW; g._screenH = screenH;
            return g;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen with the clock at `nowMs`.</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            _tk = new Ticker(nowMs);
            Ticker.Default = _tk;
            Card.LoadXml ??= name => Resources.Load<TextAsset>("Cards/" + name)?.text ?? throw new InvalidOperationException("Resources/Cards/" + name + ".xml is missing: run node tools/unity/export-cards.mjs");
            float w = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp, h = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            var art = SdArtList.Load();
            var cast = new List<SdCreature>();
            foreach (var k in Owned) if (art.TryGetValue(k, out var c)) cast.Add(c);
            if (cast.Count == 0) cast.AddRange(art.Values);
            art.TryGetValue(BuddyKey, out var buddy);
            _level = new SdLevel(w, h, _startLv, HeadStart, cast.ToArray(), buddy, Xml, _tk);
            _level.OnExit = unlocked => { Unlocked = unlocked; Leave(); };
            _level.OnLevel = lv => Level = lv;
            Sync();
        }

        /// <summary>The Regular level the player is on (the profile's sdk.lv once Firebase is in).</summary>
        public static int Level
        {
            get => Mathf.Clamp(PlayerPrefs.GetInt("sdk.level", 1), 1, Levels.LevelCount);
            set { PlayerPrefs.SetInt("sdk.level", Mathf.Clamp(value, 1, Levels.LevelCount)); PlayerPrefs.Save(); }
        }

        static string Xml(string name) => Resources.Load<TextAsset>("Squishdoku/" + name)?.text
            ?? throw new InvalidOperationException("Resources/Squishdoku/" + name + ".xml is missing: run node tools/unity/export-squishdoku.mjs");

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the game with it).</summary>
        public void Advance(double nowMs)
        {
            if (!_started) Init(nowMs);
            _tk.Tick(nowMs);
            Sync();
        }

        /// <summary>The level itself (CI screenshots: taps on cells, cards).</summary>
        public SdLevel Model => _level;

        void Update()
        {
            if (!_started) return;
            Ticker.Default = _tk;   // (the cards' and the bursts' timers run on the screen's clock)
            _tk.Tick(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            if (_level != null) Sync();
        }

        void OnApplicationPause(bool paused) { if (paused) _level?.Pause(); }

        // ---- the layers on screen as UiPieces (a texture drawn again only when a layer's drawing changes) -------------------
        void Sync()
        {
            if (_level == null) return;
            _seen.Clear();
            int order = 0;
            foreach (var l in _level.Layers())
            {
                _seen.Add(l);
                if (!_pieces.TryGetValue(l, out var e)) e = (UiPiece.Create(transform, l.Name, 0), -1);
                if (e.version != l.Version)
                {
                    if (l.Picture != null) e.piece.SetPicture(UiPiece.LoadPicture(l.Picture), l.W, l.H);
                    else e.piece.SetSvg(l.Markup, l.W, l.H, l.Margin);
                    e.version = l.Version;
                }
                _pieces[l] = e;
                e.piece.Transform = l.Transform;
                e.piece.Opacity = l.Opacity;
                e.piece.Visible = l.Visible;
                e.piece.Order = order++;
                e.piece.Apply();
            }
            _gone.Clear();
            foreach (var l in _pieces.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone)
            {
                var go = _pieces[l].piece.gameObject;
                if (Application.isPlaying) Destroy(go); else DestroyImmediate(go);
                _pieces.Remove(l);
            }
        }

        // ---- touches (one finger, or the mouse) and Android's back -------------------------------------------------------------
        bool _down;

        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) { _level.Back(); return; }
            bool down, held, up;
            Vector2 px;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                px = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up;
            }
            else { px = Input.mousePosition; down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0); held = Input.GetMouseButton(0); }
            float x = px.x / UiPiece.PxPerDp, y = (Screen.height - px.y) / UiPiece.PxPerDp;
            if (down) { _down = true; _level.Down(x, y); }
            else if (_down && up) { _down = false; _level.Up(x, y); }
            else if (_down && held) _level.Move(x, y);
        }

        void Leave()
        {
            OnExit?.Invoke();
            Destroy(gameObject);
        }
    }

    /// <summary>Resources/Squishdoku/squishdoku.json's creatures: stack/art.js keys, their cut-outs (Resources/Stack/art)
    /// and their height / width.</summary>
    public static class SdArtList
    {
        [Serializable] sealed class Raw { public Entry[] artList; }
        [Serializable] sealed class Entry { public string key, file; public float ar; }
        static Dictionary<string, SdCreature> _all;

        public static Dictionary<string, SdCreature> Load()
        {
            if (_all != null) return _all;
            var text = Resources.Load<TextAsset>("Squishdoku/squishdoku")?.text ?? throw new InvalidOperationException("Resources/Squishdoku/squishdoku.json is missing: run node tools/unity/export-squishdoku.mjs");
            var raw = JsonUtility.FromJson<Raw>(text);
            _all = new Dictionary<string, SdCreature>();
            foreach (var a in raw.artList) _all[a.key] = new SdCreature(a.key, "Stack/art/" + a.file, a.ar);
            // the board's creatures in their three faces (export-squishdoku.mjs)
            SdCreature.Bodies = SdCreature.ParseBodies(Resources.Load<TextAsset>("Squishdoku/bodies")?.text);
            return _all;
        }
    }
}
