// Squish Sort's level screen in Unity: SortLevel (the port of src/sort/Game.js: the rules, the timeline, every motion)
// shown with UiPieces (each of its layers drawn once into a texture and moved every frame), its doors with
// SortDoorPiece (their perspective), its cards with CardPieces, and the player's touches handed to it in dp.
//   SortGame.Create(parent, startLv[, screenW, screenH, theme]) then Init(nowMs) (Unity's Start does it) and, outside
//   play mode (CI screenshots), Advance(nowMs) to run the clock to a moment and place everything.
//   SortGame.CreateBlitz(parent[, screenW, screenH]): BLITZ (SortBlitz.cs, ten rounds, fridge and cupboard taking turns);
//   the same Init / Advance / OnExit (QUIT, DONE, the back orb outside sorting); `Run` hooks ads and sounds.
// The art: Resources/Sort (tools/unity/export-sort.mjs): the page, the back orb, the clutter, the squishies each
// container draws from (their cut-outs are Resources/Stack/art); the rest is SortArt's.
// Not ported: the effects' bursts, sounds, haptics. Profile is kept in memory
// (signed in: a copy of the account's, and each outcome is saved there too: SortSave).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Sort
{
    public sealed class SortGame : MonoBehaviour
    {
        public Action OnExit;
        /// <summary>The level playing now (NEXT moves it on): for the menu to remember.</summary>
        public Action<int> OnLevel;
        public static IDictionary<string, object> Profile = new Dictionary<string, object>();   // until Firebase (step 3)

        int _startLv;
        bool _blitz;
        string _theme = "fridge";
        float _screenW, _screenH;   // px (default: Screen)
        bool _started;
        Ticker _anim;
        SortLevel _level;
        UiPiece _bg;
        CardPieces _cardPieces;
        readonly Dictionary<SortLayer, UiPiece> _pieces = new Dictionary<SortLayer, UiPiece>();
        readonly Dictionary<SortLayer, SortDoorPiece> _doors = new Dictionary<SortLayer, SortDoorPiece>();
        readonly Dictionary<SortLayer, int> _versions = new Dictionary<SortLayer, int>();
        readonly HashSet<SortLayer> _seen = new HashSet<SortLayer>();
        readonly List<SortLayer> _gone = new List<SortLayer>();
        static SortData _data;
        static readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        /// <summary>`theme`: "fridge" (the Snack Fridge) or "cupboard" (the Toy Cupboard).</summary>
        public static SortGame Create(Transform parent, int startLv, float screenW = 0, float screenH = 0, string theme = "fridge")
        {
            var go = new GameObject("Squish Sort");
            go.transform.SetParent(parent, false);
            var g = go.AddComponent<SortGame>();
            g._startLv = Mathf.Clamp(startLv, 1, Levels.LEVELS);
            g._screenW = screenW; g._screenH = screenH;
            g._theme = theme == "cupboard" ? "cupboard" : "fridge";
            return g;
        }

        /// <summary>BLITZ: a run from round 1 (no ads in Unity yet: its revive is free unless Run.AdsFree is turned off and
        /// Run.AdReady / ShowAd hooked).</summary>
        public static SortGame CreateBlitz(Transform parent, float screenW = 0, float screenH = 0)
        {
            var g = Create(parent, 1, screenW, screenH);
            g.gameObject.name = "Squish Sort Blitz";
            g._blitz = true;
            return g;
        }

        public SortLevel Level => _level;
        /// <summary>Blitz: called with the level made, before it starts (to set Run's hooks).</summary>
        public Action<SortLevel> OnBlitzMade;

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen with the clock at `nowMs` (Unity calls it; CI screenshots call it outside play mode).</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            _data ??= LoadData();
            _anim = new Ticker(nowMs);
            Ticker.Default = _anim;
            float W = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp;
            float H = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            _bg = UiPiece.Create(transform, "bg", 0);
            _bg.SetSvg(Text("Sort/bg"), 832, 384, 0);
            _bg.Transform = Affine.ScaleBy(W / 832, H / 384);   // the page stretched over the screen (a gradient and rays)
            _cardPieces = new CardPieces(transform, 1000);
            if (_blitz) { _level = SortLevel.Blitz(W, H, _data, Profile); OnBlitzMade?.Invoke(_level); }
            else _level = new SortLevel(_theme, _startLv, W, H, _data, Profile);
            _level.OnExit = Leave;
            _level.OnLevel = lv => OnLevel?.Invoke(lv);
            _level.Start();
            Draw();
        }

        static string Text(string name) => Resources.Load<TextAsset>(name)?.text ?? throw new InvalidOperationException("Resources/" + name + " is missing: run node tools/unity/export-sort.mjs");

        [Serializable] sealed class PropsJson { public string[] fridge, cupboard; }
        [Serializable] sealed class PoolJson { public PoolItem[] fridge, cupboard; }
        [Serializable] sealed class PoolItem { public string id, file; }

        static SortData LoadData()
        {
            var d = new SortData { BackXml = Text("Sort/back"), BackLipXml = Text("Hop/back-lip"), BackTopXml = Text("Hop/back-top"), PauseTopXml = Text("Hop/pause-top") };
            var props = JsonUtility.FromJson<PropsJson>(Text("Sort/props"));
            d.Props["fridge"] = new List<string>(props.fridge);
            d.Props["cupboard"] = new List<string>(props.cupboard);
            var pools = JsonUtility.FromJson<PoolJson>(Text("Sort/sort"));
            foreach (var (k, list) in new[] { ("fridge", pools.fridge), ("cupboard", pools.cupboard) })
            {
                var l = new List<PoolEntry>();
                foreach (var p in list) l.Add(new PoolEntry(p.id, "Stack/art/" + p.file));
                d.Pools[k] = l;
            }
            return d;
        }

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the game with it).</summary>
        public void Advance(double nowMs)
        {
            Ticker.Default = _anim;
            _anim.Tick(nowMs);
            Draw();
            foreach (var p in GetComponentsInChildren<UiPiece>(true)) p.Apply();
            foreach (var p in GetComponentsInChildren<SortDoorPiece>(true)) p.Apply();
        }

        void Update()
        {
            if (!_started) return;
            Ticker.Default = _anim;
            _anim.Tick(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            Draw();
        }

        void OnApplicationPause(bool paused) { if (paused) _level?.Pause(); }

        // every layer of the level as a piece, in its paint order; pieces of layers no longer drawn go
        void Draw()
        {
            if (_level == null) return;
            _level.Update();
            _seen.Clear();
            int order = 10;
            foreach (var l in _level.Layers)
            {
                _seen.Add(l);
                order++;
                bool changed = !_versions.TryGetValue(l, out var v) || v != l.Version;
                _versions[l] = l.Version;
                if (l.Door != null)
                {
                    if (!_doors.TryGetValue(l, out var d)) _doors[l] = d = SortDoorPiece.Create(transform, l.Name, order);
                    if (changed) d.SetSvg(l.Markup, l.W, l.H, l.Margin);
                    d.View = l.Door; d.Opacity = l.Opacity; d.Visible = l.Visible; d.Order = order;
                    continue;
                }
                if (!_pieces.TryGetValue(l, out var p)) _pieces[l] = p = UiPiece.Create(transform, l.Name, order);
                var m = l.Transform;
                if (l.Picture != null)
                {
                    // resizeMode contain: the picture's own shape, centred in the box
                    if (!_textures.TryGetValue(l.Picture, out var tex)) _textures[l.Picture] = tex = UiPiece.LoadPicture(l.Picture);
                    if (tex == null) { p.Visible = false; continue; }
                    float k = Mathf.Min(l.W / tex.width, l.H / tex.height), fw = tex.width * k, fh = tex.height * k;
                    if (changed) p.SetPicture(tex, fw, fh);
                    m = m * Affine.Translate((l.W - fw) / 2, (l.H - fh) / 2);
                }
                else if (changed && l.Markup != null) p.SetSvg(l.Markup, l.W, l.H, l.Margin);
                p.Transform = m;
                p.Opacity = l.Opacity;
                p.Visible = l.Visible && (l.Markup != null || l.Picture != null);
                p.Order = order;
            }
            _gone.Clear();
            foreach (var l in _versions.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone)
            {
                if (_pieces.TryGetValue(l, out var p)) { Kill(p.gameObject); _pieces.Remove(l); }
                if (_doors.TryGetValue(l, out var d)) { Kill(d.gameObject); _doors.Remove(l); }
                _versions.Remove(l);
            }
            _cardPieces.Sync(_level.Cards);
        }

        // ---- touch: one finger (or the mouse) in dp; Escape is Android's back ------------------------------------------
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
            Kill(gameObject);
        }

        static void Kill(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) Destroy(o); else DestroyImmediate(o); }
    }
}
