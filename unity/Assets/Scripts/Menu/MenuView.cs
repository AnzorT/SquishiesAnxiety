// Builds the Main Menu out of the exported pictures and moves what moves. Pure placement: no input, no Update; the
// owner (MenuScreen, or the CI screenshot) gives it the screen size and the time.
//
// World units are screen pixels with y pointing down the screen as -y (a piece at page pixel (x, y) sits at world
// (x, -y)); MenuScreen's camera shows exactly 0..W x 0..-H. On the reference screen (2340 x 1080) every picture lands
// on whole pixels at scale 1, so Unity draws the same pixels as the app. On other screens the same rules as the web
// page apply: the house picture fills the screen bottom-aligned ("xMidYMax slice"), the creature and its name plate
// move with it, and the HUD keeps its size in dp and holds to the nearest screen edge.
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed class MenuView : IDisposable
    {
        const int SceneOrder = 0, WorldOrder = 10, WeatherOrder = 20, HudOrder = 30;

        readonly MenuLayout _layout;
        readonly Transform _root;
        readonly List<Texture2D> _textures = new List<Texture2D>();   // loaded from Resources (unloaded)
        readonly List<UnityEngine.Object> _made = new List<UnityEngine.Object>(); // made here (destroyed)
        readonly List<PieceView> _pieces = new List<PieceView>();
        readonly List<Transform> _bands = new List<Transform>();
        readonly List<BirdView> _birds = new List<BirdView>();
        MenuLayout.Weather _weather;
        float _w, _h;

        // the current screen's geometry
        float _k, _ox, _oy;          // scene: px per viewBox unit and where viewBox (0, 0) lands
        float _kRef, _oxRef, _oyRef; // the same on the reference screen
        float _f;                    // HUD pictures' scale relative to the reference (dp size kept)

        public string Season { get; private set; }
        public int Level { get; private set; }
        public IReadOnlyList<PieceView> Pieces => _pieces;

        public MenuView(MenuLayout layout, Transform parent, float width, float height, int level, string season)
        {
            _layout = layout;
            _root = new GameObject("Menu").transform;
            _root.SetParent(parent, false);
            Level = level;
            Season = season;
            Build(width, height);
        }

        void Build(float w, float h)
        {
            _w = w; _h = h;
            var R = _layout.reference;
            var vb = _layout.scene.viewBox;
            _k = Mathf.Max(w / vb[2], h / vb[3]);
            _ox = (w - vb[2] * _k) / 2f;
            _oy = h - vb[3] * _k;
            _kRef = Mathf.Max(R.px[0] / vb[2], R.px[1] / vb[3]);
            _oxRef = (R.px[0] - vb[2] * _kRef) / 2f;
            _oyRef = R.px[1] - vb[3] * _kRef;
            float dpPx = h / R.dp[1];               // this screen's px per dp, taking the reference phone's 384 dp height
            _f = dpPx / R.dpr;

            // 1. the house picture
            var st = _layout.SceneFor(Season, Level);
            if (st != null)
            {
                var tex = LoadJpeg(st.res);
                float s = _k * _layout.scene.unitsPerPx;
                var pos = new Vector2(_ox + _layout.scene.originUnits[0] * _k, _oy + _layout.scene.originUnits[1] * _k);
                Picture("scene", _root, tex, Snap(pos, s), s, SceneOrder);
            }

            // 2. the creature and its name plate (they stand in the scene), 3. the weather, 4. the HUD
            int order = WorldOrder;
            foreach (var p in _layout.hud) if (p.world) _pieces.Add(new PieceView(this, p, order++));
            BuildWeather();
            order = HudOrder;
            foreach (var p in _layout.hud) if (!p.world) _pieces.Add(new PieceView(this, p, order++));
        }

        void BuildWeather()
        {
            _weather = _layout.WeatherFor(Season);
            if (_weather == null) return;
            float s = _k / _kRef;
            if (_weather.hasBand && _weather.band != null && !string.IsNullOrEmpty(_weather.band.res))
            {
                var b = _weather.band;
                var tex = Load(b.res);
                var holder = new GameObject("weather").transform;
                holder.SetParent(_root, false);
                _bands.Add(holder);
                foreach (var c in b.copies)
                {
                    var at = new Vector2(b.rectUnits[0] * _k, (b.rectUnits[1] + c * b.period) * _k);
                    Picture("band " + c, holder, tex, at, s, WeatherOrder);
                }
            }
            if (_weather.hasBirds && _weather.birds != null && !string.IsNullOrEmpty(_weather.birds.res))
            {
                var tex = Load(_weather.birds.res);
                for (int i = 0; i < _weather.birds.paths.Length; i++)
                {
                    var t = new GameObject("bird " + i).transform;
                    t.SetParent(_root, false);
                    var a = _weather.birds.anchorUnits;
                    Picture("art", t, tex, new Vector2(a[0] * _k, a[1] * _k), s, WeatherOrder + 1);
                    _birds.Add(new BirdView { T = t, Path = _weather.birds.paths[i] });
                }
            }
        }

        // the time since the menu opened, in ms: weather, flourishes, the creature's placeholder breathing
        public void Tick(float ms)
        {
            if (_root == null) return;
            if (_weather != null && _weather.hasBand && _bands.Count > 0)
            {
                var b = _weather.band;
                float p = Mathf.Repeat(ms, b.ms) / b.ms;
                var off = new Vector2(Mathf.Lerp(b.from[0], b.to[0], p), Mathf.Lerp(b.from[1], b.to[1], p));
                foreach (var t in _bands) t.localPosition = World(new Vector2(_ox + off.x * _k, _oy + off.y * _k));
            }
            foreach (var bird in _birds)
            {
                var pts = bird.Path.points;
                int n = pts.Length / 2 - 1;
                float u = Mathf.Repeat(ms, bird.Path.ms) / bird.Path.ms * n;
                int i = Mathf.Min((int)u, n - 1);
                float f = u - i;
                float x = Mathf.Lerp(pts[i * 2], pts[i * 2 + 2], f), y = Mathf.Lerp(pts[i * 2 + 1], pts[i * 2 + 3], f);
                bird.T.localPosition = World(new Vector2(_ox + x * _k, _oy + y * _k));
            }
            foreach (var p in _pieces) p.Tick(ms);
        }

        public PieceView HitTest(Vector2 pagePx)
        {
            for (int i = _pieces.Count - 1; i >= 0; i--)
                if (!string.IsNullOrEmpty(_pieces[i].Data.tap) && _pieces[i].Hit.Contains(pagePx)) return _pieces[i];
            return null;
        }

        // ---- placement -----------------------------------------------------------------------------------------------

        // a reference-screen pixel position of a piece, on this screen
        Vector2 Map(MenuLayout.Piece p, Vector2 refPx)
        {
            if (p.world)
            {
                var u = new Vector2((refPx.x - _oxRef) / _kRef, (refPx.y - _oyRef) / _kRef);
                return new Vector2(_ox + u.x * _k, _oy + u.y * _k);
            }
            var R = _layout.reference;
            float W = R.px[0], H = R.px[1];
            float cx = p.hit[0] + p.hit[2] / 2f, cy = p.hit[1] + p.hit[3] / 2f;
            float x = cx < W / 3f ? refPx.x * _f : cx > W * 2f / 3f ? _w - (W - refPx.x) * _f : _w / 2f + (refPx.x - W / 2f) * _f;
            float y = cy < H / 3f ? refPx.y * _f : cy > H * 2f / 3f ? _h - (H - refPx.y) * _f : _h / 2f + (refPx.y - H / 2f) * _f;
            return new Vector2(x, y);
        }
        float ScaleOf(MenuLayout.Piece p) => p.world ? _k / _kRef : _f;

        static Vector2 Snap(Vector2 v, float scale) => Mathf.Approximately(scale, 1f) ? new Vector2(Mathf.Round(v.x), Mathf.Round(v.y)) : v;
        public static Vector3 World(Vector2 pagePx) => new Vector3(pagePx.x, -pagePx.y, 0f);

        // the house pictures ship as JPEG bytes (Resources/Menu/scene/*.jpg.bytes) and are decoded here: imported as
        // textures, all 90 of them would go into the app at full size (~9 MB each)
        Texture2D LoadJpeg(string res)
        {
            var bytes = Resources.Load<TextAsset>(MenuLayout.Root + res);
            if (bytes == null) throw new InvalidOperationException("missing picture Resources/" + MenuLayout.Root + res + ".bytes");
            var tex = new Texture2D(2, 2, TextureFormat.RGB24, false) { name = res, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp };
            if (!tex.LoadImage(bytes.bytes, true)) throw new InvalidOperationException("could not decode " + res);
            Resources.UnloadAsset(bytes);
            _made.Add(tex);
            return tex;
        }

        Texture2D Load(string res)
        {
            var tex = Resources.Load<Texture2D>(MenuLayout.Root + res);
            if (tex == null) throw new InvalidOperationException("missing picture Resources/" + MenuLayout.Root + res);
            _textures.Add(tex);
            return tex;
        }

        // a picture with its top-left corner at `pagePx` (relative to the parent), `scale` screen px per picture px
        SpriteRenderer Picture(string name, Transform parent, Texture2D tex, Vector2 pagePx, float scale, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.transform.localPosition = World(pagePx);
            go.transform.localScale = new Vector3(scale, scale, 1f);
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = MakeSprite(tex);
            sr.sortingOrder = order;
            return sr;
        }

        Sprite MakeSprite(Texture2D tex)
        {
            var sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0f, 1f), 1f, 0, SpriteMeshType.FullRect);
            _made.Add(sp);
            return sp;
        }

        static void Kill(UnityEngine.Object o)
        {
            if (o == null) return;
            if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o);
        }

        public void Dispose()
        {
            if (_root != null) Kill(_root.gameObject);
            foreach (var o in _made) Kill(o);
            _made.Clear();
            foreach (var t in _textures) if (t != null) Resources.UnloadAsset(t);
            _textures.Clear();
        }

        sealed class BirdView { public Transform T; public MenuLayout.BirdPath Path; }

        // ---- one HUD piece ------------------------------------------------------------------------------------------
        public sealed class PieceView
        {
            public readonly MenuLayout.Piece Data;
            public readonly Rect Hit;              // page px on this screen (y down)
            readonly Transform _pivot;             // presses scale / move around this point
            readonly Vector3 _pivotPos;
            readonly SpriteRenderer _art, _fl;
            readonly Sprite[] _frames;
            readonly float _scale;
            bool _pressed;

            public PieceView(MenuView v, MenuLayout.Piece p, int order)
            {
                Data = p;
                _scale = v.ScaleOf(p);
                var h0 = v.Map(p, new Vector2(p.hit[0], p.hit[1]));
                Hit = new Rect(h0.x, h0.y, p.hit[2] * _scale, p.hit[3] * _scale);
                var press = p.press ?? new MenuLayout.Press { scale = 1f, pivot = new[] { 0.5f, 0.5f } };
                var pv = press.pivot != null && press.pivot.Length == 2 ? press.pivot : new[] { 0.5f, 0.5f };
                var pivotPx = new Vector2(Hit.x + Hit.width * pv[0], Hit.y + Hit.height * pv[1]);

                _pivot = new GameObject(p.id).transform;
                _pivot.SetParent(v._root, false);
                _pivotPos = World(pivotPx);
                _pivot.localPosition = _pivotPos;

                var at = Snap(v.Map(p, new Vector2(p.rect[0], p.rect[1])), _scale);
                _art = v.Picture("art", _pivot, v.Load(p.res), at - pivotPx, _scale, order);

                if (p.hasFlourish && p.flourish != null && p.flourish.frames != null && p.flourish.frames.Length > 0)
                {
                    var fat = Snap(v.Map(p, new Vector2(p.flourish.rect[0], p.flourish.rect[1])), _scale);
                    _frames = new Sprite[p.flourish.frames.Length];
                    for (int i = 0; i < _frames.Length; i++) _frames[i] = v.MakeSprite(v.Load(p.flourish.frames[i]));
                    _fl = v.Picture("flourish", _pivot, v.Load(p.flourish.frames[0]), fat - pivotPx, _scale, order);
                    _fl.enabled = false;
                }
            }

            public void SetPressed(bool on, float dpPx)
            {
                _pressed = on;
                var press = Data.press;
                if (press == null) return;
                float s = on ? press.scale : 1f;
                _pivot.localScale = new Vector3(s, s, 1f);
                _pivot.localPosition = _pivotPos + (on ? new Vector3(0f, -press.dy * dpPx, 0f) : Vector3.zero);
            }

            public void Tick(float ms)
            {
                if (_fl != null)
                {
                    var f = Data.flourish;
                    // app/menu.js: a setInterval of `every` ms (first one `every` ms after the menu opens), `delay` into it
                    float phase = ms - f.every - f.delay;
                    int frame = -1;
                    if (phase >= 0f && !_pressed)
                    {
                        float inCycle = Mathf.Repeat(phase, f.every);
                        if (inCycle < f.ms) frame = Mathf.Clamp(Mathf.RoundToInt(inCycle / f.ms * (_frames.Length - 1)), 0, _frames.Length - 1);
                    }
                    _fl.enabled = frame >= 0;
                    _art.enabled = frame < 0;
                    if (frame >= 0) _fl.sprite = _frames[frame];
                }
                if (Data.id == "creature")
                {
                    // placeholder until the creature rig is ported: a slow breath around its feet (none at ms = 0, so
                    // the CI screenshot still matches the reference)
                    float b = Mathf.Sin(ms / 1000f * Mathf.PI * 2f / 3.2f);
                    _pivot.localScale = new Vector3(1f - 0.008f * b, 1f + 0.012f * b, 1f);
                }
            }
        }
    }
}
