// Squish Hop's level screen in Unity: HopLevel (the port of src/hop/Game.js) on screen. Each of its layers is a piece
// (an SVG drawn once into a texture by UiPiece, a picture, or a picture cut to a box, repeated, or laid on the board's
// plane in perspective by HopMesh), placed every frame; its cards are the shared ones (Ui/Cards, CardPieces). Touches
// and the mouse go to the level as the app's PanResponder and buttons take them; Escape is Android's back.
// The art: Resources/Hop (tools/unity/export-hop.mjs), the squishies' cut-outs Resources/Stack/art.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using UnityEngine;

namespace SquishSquad.Games.Hop
{
    public sealed class HopGame : MonoBehaviour
    {
        public Action OnExit;
        /// <summary>The player's profile until Firebase (step 3): Preview.js's made-up player (owns Mittens).</summary>
        public static IDictionary<string, object> Profile = new Dictionary<string, object> { ["ownedIds"] = new List<object> { "1" } };

        HopLevel _level;
        Ticker _anim;
        CardPieces _cardPieces;
        int _startLv;
        float _screenW, _screenH;
        bool _started;
        readonly Dictionary<HopLayer, (Component piece, int version)> _pieces = new Dictionary<HopLayer, (Component, int)>();
        readonly HashSet<HopLayer> _seen = new HashSet<HopLayer>();
        readonly List<HopLayer> _gone = new List<HopLayer>();
        static List<HopSquishy> _cast;

        public static HopGame Create(Transform parent, int startLv, float screenW = 0, float screenH = 0)
        {
            var go = new GameObject("Squish Hop");
            go.transform.SetParent(parent, false);
            var g = go.AddComponent<HopGame>();
            g._startLv = Mathf.Clamp(startLv, 1, Levels.LEVELS);
            g._screenW = screenW; g._screenH = screenH;
            return g;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen with the clock at `nowMs` (Unity calls it; CI screenshots call it outside play mode).</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            HopLevel.LoadXml ??= name => Resources.Load<TextAsset>("Hop/" + name)?.text ?? throw new InvalidOperationException("Resources/Hop/" + name + ".xml is missing: run node tools/unity/export-hop.mjs");
            _cast ??= LoadCast();
            _anim = new Ticker(nowMs);
            HopLevel.PixelSnap = UiPiece.PxPerDp;
            float w = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp, h = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            _cardPieces = new CardPieces(transform, HopLevel.CardOrder);
            _level = new HopLevel(w, h, _startLv, _cast, Profile, _anim) { OnExit = Leave };
            Draw();
        }

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the game with it).</summary>
        public void Advance(double nowMs)
        {
            _anim.Tick(nowMs);
            Draw();
        }

        /// <summary>The level (CI screenshots play hops and open cards through it; Lv is the level being played).</summary>
        public HopLevel Level => _level;

        void Update()
        {
            if (!_started) return;
            _anim.Tick(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            if (_level != null) Draw();
        }

        void OnApplicationPause(bool paused) { if (paused) _level?.AppPaused(); }

        void Draw()
        {
            _level.Update();
            _seen.Clear();
            foreach (var l in _level.Layers)
            {
                if (l.Markup == null && l.Picture == null) continue;   // nothing drawn into it yet
                _seen.Add(l);
                if (!_pieces.TryGetValue(l, out var e) || e.version != l.Version)
                {
                    if (e.piece != null && !Fits(e.piece, l)) { Kill(e.piece.gameObject); e.piece = null; }
                    e.piece ??= l.Markup != null || (l.Grid == null && l.Clip == null && l.TileW == 0) ? (Component)UiPiece.Create(transform, l.Name, l.Order) : HopMesh.Create(transform, l.Name, l.Order);
                    if (e.piece is UiPiece up)
                    {
                        if (l.Markup != null) up.SetSvg(l.Markup, l.W, l.H, l.Margin);
                        else up.SetPicture(Picture(l.Picture), l.W, l.H);
                    }
                    else ((HopMesh)e.piece).Set(l, Picture(l.Picture));
                    e.version = l.Version;
                    _pieces[l] = e;
                }
                if (e.piece is UiPiece p)
                {
                    p.Transform = l.Transform; p.Opacity = l.Opacity; p.Visible = l.Visible; p.Order = l.Order;
                    p.Apply();
                }
                else
                {
                    var m = (HopMesh)e.piece;
                    m.Transform = l.Transform; m.Opacity = l.Opacity; m.Visible = l.Visible; m.Order = l.Order;
                    m.Apply();
                }
            }
            _gone.Clear();
            foreach (var l in _pieces.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone) { Kill(_pieces[l].piece.gameObject); _pieces.Remove(l); }
            _cardPieces.Sync(_level.Cards);
        }

        static bool Fits(Component c, HopLayer l) => c is UiPiece ? l.Markup != null || (l.Grid == null && l.Clip == null && l.TileW == 0) : l.Markup == null && (l.Grid != null || l.Clip != null || l.TileW > 0);

        static readonly Dictionary<string, Texture2D> Pictures = new Dictionary<string, Texture2D>();
        static Texture2D Picture(string path)
        {
            if (path == null) return null;
            if (!Pictures.TryGetValue(path, out var t)) Pictures[path] = t = Resources.Load<Texture2D>(path);
            return t;
        }

        // Resources/Hop/hop.json's cast (the app's castOf), drawn by Squish Stack's cut-outs; heads from Resources/Hop/heads
        [Serializable] sealed class Raw { public CastEntry[] cast; public string[] heads; }
        [Serializable] sealed class CastEntry { public string id, key, file; public float ar; public float[] box; }
        static List<HopSquishy> LoadCast()
        {
            var text = Resources.Load<TextAsset>("Hop/hop")?.text ?? throw new InvalidOperationException("Resources/Hop/hop.json is missing: run node tools/unity/export-hop.mjs");
            var raw = JsonUtility.FromJson<Raw>(text);
            var heads = new HashSet<string>(raw.heads ?? new string[0]);
            var list = new List<HopSquishy>();
            foreach (var c in raw.cast)
                list.Add(new HopSquishy
                {
                    Id = c.id, Key = c.key, Ar = c.ar, Box = c.box != null && c.box.Length == 4 ? c.box : new float[] { 0, 0, 1, 1 },
                    Picture = string.IsNullOrEmpty(c.file) ? null : "Stack/art/" + c.file,
                    Happy = heads.Contains(c.key) ? "Hop/heads/" + c.key + "-happy" : null,
                    Sad = heads.Contains(c.key) ? "Hop/heads/" + c.key + "-sad" : null,
                });
            return list;
        }

        // ---- touch: the mouse or the first finger, in screen dp -------------------------------------------------------
        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) { _level.Back(); return; }
            bool down, held, up;
            Vector2 px;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                px = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up && !down;
            }
            else { px = Input.mousePosition; down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0); held = Input.GetMouseButton(0) && !down; }
            float x = px.x / UiPiece.PxPerDp, y = (Screen.height - px.y) / UiPiece.PxPerDp;
            if (down) _level.Down(x, y);
            else if (up) _level.Up(x, y);
            else if (held) _level.Move(x, y);
        }

        void Leave()
        {
            OnExit?.Invoke();
            Destroy(gameObject);
        }

        static void Kill(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) Destroy(o); else DestroyImmediate(o); }
    }
}
