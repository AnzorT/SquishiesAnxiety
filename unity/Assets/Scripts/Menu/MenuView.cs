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
using System.IO;
using System.IO.Compression;
using SquishSquad.Creatures;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView : IDisposable
    {
        const int SceneOrder = 0, WorldOrder = 10, WeatherOrder = 20, HudOrder = 30;

        readonly MenuLayout _layout;
        readonly Transform _root;
        Transform _world;   // what the camera slides (webgame/app/menu.js .mm-world): the house, the park, the creature, its name
        readonly List<Texture2D> _textures = new List<Texture2D>();   // loaded from Resources (unloaded)
        readonly List<UnityEngine.Object> _made = new List<UnityEngine.Object>(); // made here (destroyed)
        readonly List<PieceView> _pieces = new List<PieceView>();
        readonly List<Transform> _bands = new List<Transform>();
        readonly List<BirdView> _birds = new List<BirdView>();
        MenuLayout.Weather _weather;
        float _w, _h;
        string _creatureKey;   // the player's creature (its own still, never Mittens', when it can't be animated: Build)

        // the current screen's geometry
        float _k, _ox, _oy;          // scene: px per viewBox unit and where viewBox (0, 0) lands
        float _kRef, _oxRef, _oyRef; // the same on the reference screen
        float _f;                    // HUD pictures' scale relative to the reference (dp size kept)

        public string Season { get; private set; }
        public int Level { get; private set; }
        public IReadOnlyList<PieceView> Pieces => _pieces;

        // the 'name' piece with this creature's plate (export-menu.mjs --names), or as exported (Mittens')
        MenuLayout.Piece PlateFor(MenuLayout.Piece p, string key)
        {
            var plate = _layout.names == null || key == null ? null : System.Array.Find(_layout.names, n => n.key == key);
            if (plate == null || plate.rect == null || plate.rect.Length != 4) return p;
            return new MenuLayout.Piece
            {
                id = p.id, res = plate.res, rect = plate.rect, world = p.world, tap = p.tap, press = p.press,
                hasFlourish = p.hasFlourish, flourish = p.flourish,
                // (where a tap counts: the plate's own box, as the exported one's is)
                hit = new float[] { plate.rect[0], plate.rect[1], plate.rect[2], plate.rect[3] },
            };
        }

        /// <summary>The creature drawn live from its rig frames (null: its still picture is shown).</summary>
        public CreatureView Creature { get; private set; }

        public MenuView(MenuLayout layout, Transform parent, float width, float height, int level, string season, string creatureKey = "mittens", bool liveCreature = true)
        {
            _creatureKey = liveCreature ? creatureKey : null;
            _layout = layout;
            _root = new GameObject("Menu").transform;
            _root.SetParent(parent, false);
            _world = new GameObject("world").transform;
            _world.SetParent(_root, false);
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
                _sceneSr = Picture("scene", _world, tex, Snap(pos, s), s, SceneOrder);
                // its vignette, faded out while the Game Park is beside the house (menu.js vignette(): opacity .45s ease)
                if (!string.IsNullOrEmpty(_layout.scene.vignette))
                    _vignette = Picture("vignette", _world, Load(_layout.scene.vignette), Snap(pos, s), s, SceneOrder + 2);   // (over the door as it opens: MenuView.Home.cs)
            }

            // 2. the creature and its name plate (they stand in the scene), 3. the weather, 4. the HUD
            // the creature: live when its rig runs, else its own still (never another creature in its place: the user,
            // 2026-11-25, no Mittens fallback); its name plate with it
            var rig = _creatureKey != null ? Rigs.For(_creatureKey) : null;
            string plateKey = _creatureKey ?? "mittens";
            int order = WorldOrder;
            foreach (var p in _layout.hud) if (p.world) _pieces.Add(new PieceView(this, p.id == "name" ? PlateFor(p, plateKey) : p, order++));
            BuildWeather();
            order = HudOrder;
            foreach (var p in _layout.hud) if (!p.world) _pieces.Add(new PieceView(this, p, order++));
            BuildHud();   // the player's numbers (MenuView.Hud.cs)

            // the creature, animated by the app's own rig code (recorded frames for now), in place of its still
            if (_creatureKey != null)
            {
                var piece = _pieces.Find(x => x.Data.id == "creature");
                // (the exported still is Mittens: any other creature's still is its own, for when its rig can't start or fails)
                if (piece != null && _creatureKey != "mittens")
                {
                    var still = LoadStill(_creatureKey);
                    if (still != null) piece.SetStill(this, still);
                }
                if (piece != null && rig != null)
                {
                    Creature = CreatureView.Create(_world, rig, piece.Hit, piece.Order);
                    _creatureHome = Creature.transform.localPosition;
                    _idle = rig;
                    piece.UseLive();
                    Creature.Failed = _ => piece.UseStill();
                }
            }
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
            TickTrip(ms);
            TickHome(ms);
            TickIntro(ms);
            TickHud(ms);
            TickClip();
            if (Carousel != null)
            {
                Carousel.Tick(ms);
                if (Carousel.Model.Done(ms)) { Carousel.Dispose(); Carousel = null; }
            }
        }

        // ---- PLAY: the walk to the Game Park and back (webgame/app/menu.js enterPark / leavePark) ---------------------
        public enum Place { Home, ToPark, Park, ToHome, ToHouse, House, FromHouse }   // (the house's: MenuView.Home.cs)
        public Place Where { get; private set; } = Place.Home;
        float _tripStart = -1, _fadeFrom = 1, _fadeTo = 1, _fadeStart;
        Vector3 _creatureHome;
        IRigFrames _idle;
        RecordedRig _clip;
        NativeRig _parkRig;
        RenderTexture _parkTex;
        GameObject _parkGo;   // hidden at home (menu.js leavePark removes the layer: its seam tree would show at the house's left edge)
        const float ParkPad = 160;   // menu.js PAD: where the creature stands in the park (the house's pad is at 500)
        const float FadeMs = 300;

        static float EIO(float t) => t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
        static float EIOC(float t) => t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
        static float EOUT(float t) => 1 - (1 - t) * (1 - t);

        public bool EnterPark(float nowMs)
        {
            if (Where != Place.Home) return false;
            EnsurePark();
            Where = Place.ToPark;
            _tripStart = nowMs;
            Fade(0, nowMs);
            Vignette(false, nowMs + 16);   // (menu.js: with the park's picture, the frame after the tap)
            Clip("park-enter");
            return true;
        }

        public bool LeavePark(float nowMs)
        {
            if (Where != Place.Park) return false;
            Carousel?.Model.Leave(nowMs);   // the carousel goes out while the creature turns (menu.js leavePark)
            Where = Place.ToHome;
            _tripStart = nowMs;
            Clip("park-leave");
            return true;
        }

        void Clip(string name)
        {
            if (Creature == null || _creatureKey == null) return;
            // the native rig walks it itself (native-host.js parkStart / parkStep: menu.js's turn, HouseWalk's gait, 'happy')
            if (_idle is NativeRig nr && name.StartsWith("park-")) { nr.ParkStart(name == "park-enter"); _parkRig = nr; return; }
            _clip = RecordedRig.Load(_creatureKey + "-" + name);
            if (_clip == null) return;
            _clip.Loop = false;
            Creature.SetFrames(_clip);
        }

        void Fade(float to, float nowMs) { _fadeFrom = CurrentFade(nowMs); _fadeTo = to; _fadeStart = nowMs; }
        float CurrentFade(float ms) => Mathf.Lerp(_fadeFrom, _fadeTo, Mathf.Clamp01((ms - _fadeStart) / FadeMs));

        // the house's vignette: on at home, off in the park, each way an opacity transition of .45s ease
        SpriteRenderer _vignette;
        float _vigFrom = 1, _vigTo = 1, _vigStart;
        void Vignette(bool on, float ms) { _vigFrom = VignetteAt(ms); _vigTo = on ? 1 : 0; _vigStart = ms; }
        float VignetteAt(float ms) => Mathf.Lerp(_vigFrom, _vigTo, CssEase(Mathf.Clamp01((ms - _vigStart) / 450f)));
        // CSS `ease` (cubic-bezier(.25,.1,.25,1))
        static float CssEase(float x)
        {
            if (x <= 0 || x >= 1) return x;
            float lo = 0, hi = 1, t = x;
            for (int i = 0; i < 24; i++)
            {
                t = (lo + hi) / 2;
                float bx = 3 * (1 - t) * (1 - t) * t * .25f + 3 * (1 - t) * t * t * .25f + t * t * t;
                if (bx < x) lo = t; else hi = t;
            }
            return 3 * (1 - t) * (1 - t) * t * .1f + 3 * (1 - t) * t * t + t * t * t;
        }

        void TickTrip(float ms)
        {
            if (_vignette != null) { var c = _vignette.color; c.a = VignetteAt(ms); _vignette.color = c; }
            float a = CurrentFade(ms);
            foreach (var p in _pieces) if (p.Data.id != "creature") p.SetAlpha(a);
            _hudAlpha = a;
            if (Where != Place.ToPark && Where != Place.ToHome) return;
            bool enter = Where == Place.ToPark;
            float turn = enter ? 380 : 340, walk = enter ? 2300 : 2100, t = ms - _tripStart;
            _parkRig?.ParkStep(t);
            float X0 = _ox + 500 * _k, X1 = _ox + ParkPad * _k;
            float wt = Mathf.Clamp01((t - turn) / walk), cam, scr;
            if (enter) { scr = X0 + (X1 - X0) * EOUT(wt); cam = _w * EIOC(Mathf.Clamp01((wt - 0.06f) / 0.94f)); }
            else { scr = X1 + (X0 - X1) * EIO(wt); cam = _w * (1 - EIOC(Mathf.Clamp01(wt / 0.94f))); }
            _world.localPosition = new Vector3(cam, 0, 0);
            if (Creature != null) Creature.transform.localPosition = _creatureHome + new Vector3(scr - X0 - cam, 0, 0);
            if (t < 2 * turn + walk) return;
            // arrived
            _parkRig?.ParkStep(2 * turn + walk); _parkRig = null;   // (its last step: 'happy')
            if (enter) { Where = Place.Park; ShowGames(_tripStart + 2 * turn + walk, false); }
            else
            {
                Where = Place.Home; _world.localPosition = Vector3.zero; if (Creature != null) Creature.transform.localPosition = _creatureHome; Fade(1, ms); Vignette(true, ms);
                // the park's picture reaches past its edge over the house's: back home it goes, or its tree cuts the
                // house's leftmost one (menu.js leavePark removes it; kept here, drawn, for the next PLAY)
                if (_parkGo != null) _parkGo.SetActive(false);
            }
            // the clip ends in 'happy'; back to the idle loop once it has played
        }

        void TickClip()
        {
            if (Creature == null || _clip == null || _idle == null) return;
            if (Creature.Seconds < _clip.Duration + 1.2f) return;
            _clip = null;
            Creature.SetFrames(_idle);
        }

        // ---- the games carousel in the park (menu.js showGames; ParkCarousel / ParkModel) --------------------------
        /// <summary>The carousel while it's on screen (in the park, and while it goes out).</summary>
        public ParkCarousel Carousel { get; private set; }
        /// <summary>The game in the middle when the carousel opens (null: the one last chosen, as the app).</summary>
        public string ParkStartGame;
        ParkLayout _parkLayout;
        const int CarouselOrder = 100;

        /// <summary>The carousel, made at `nowMs` (instant: at once, as when the app comes back into the park from a game).</summary>
        public void ShowGames(double nowMs, bool instant)
        {
            if (Carousel != null) { Carousel.Dispose(); Carousel = null; }
            _parkLayout ??= ParkCarousel.LoadLayout();
            if (_parkLayout == null) return;
            Carousel = new ParkCarousel(_parkLayout, _root, _w, _h, nowMs, instant, ParkStartGame, CarouselOrder);
        }

        // the park's SVG, drawn once by the vector renderer into a texture placed one screen to the left of the house
        void EnsurePark()
        {
            if (_parkTex != null) { if (_parkGo != null) _parkGo.SetActive(true); return; }
            var st = _layout.ParkFor(Season, Level);
            if (st == null) return;
            var asset = Resources.Load<TextAsset>(MenuLayout.Root + st.res);
            if (asset == null) return;
            string svg;
            using (var gz = new GZipStream(new MemoryStream(asset.bytes), CompressionMode.Decompress))
            using (var r = new StreamReader(gz)) svg = r.ReadToEnd();
            Resources.UnloadAsset(asset);
            // the drawing reaches past its viewBox (-60..1060, -20..480): room around the screen-sized box for that
            int padX = Mathf.CeilToInt(Mathf.Max(0, -(_ox - 60 * _k))), padY = Mathf.CeilToInt(20 * _k);
            int tw = Mathf.CeilToInt(_w) + 2 * padX, th = Mathf.CeilToInt(_h) + 2 * padY;
            var msaa = new RenderTexture(tw, th, 24, RenderTextureFormat.ARGB32) { antiAliasing = 8 };
            msaa.Create();
            using (var vr = new VectorRenderer())
                vr.Render(SvgScene.Compile(SvgMarkup.Parse(svg), _w, _h, Affine.Translate(padX, padY)), msaa);
            _parkTex = new RenderTexture(tw, th, 0, RenderTextureFormat.ARGB32) { name = "park" };
            _parkTex.Create();
            Graphics.Blit(msaa, _parkTex);
            msaa.Release(); Kill(msaa);
            _made.Add(_parkTex);
            var go = new GameObject("park");
            _parkGo = go;
            go.transform.SetParent(_world, false);
            go.transform.localPosition = World(new Vector2(-_w - padX, -padY));
            var mesh = new Mesh { name = "park quad" };
            mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(tw, 0, 0), new Vector3(tw, -th, 0), new Vector3(0, -th, 0) });
            mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            _made.Add(mesh);
            go.AddComponent<MeshFilter>().sharedMesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            var mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = _parkTex };
            _made.Add(mat);
            mr.sharedMaterial = mat;
            mr.sortingOrder = SceneOrder + 2;   // menu.js puts the park layer just after the house picture (and its vignette)
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
            Anchor(p, out int ax, out int ay);
            float x = ax < 0 ? refPx.x * _f : ax > 0 ? _w - (W - refPx.x) * _f : _w / 2f + (refPx.x - W / 2f) * _f;
            float y = ay < 0 ? refPx.y * _f : ay > 0 ? _h - (H - refPx.y) * _f : _h / 2f + (refPx.y - H / 2f) * _f;
            return new Vector2(x, y);
        }
        float ScaleOf(MenuLayout.Piece p) => p.world ? _k / _kRef : _f;

        // Which screen edges a HUD piece holds to (-1 left / top, 0 centre, 1 right / bottom). The app lays the HUD out
        // in rows (main-menu.js / app/menu.js CSS): the tabs are one row from the left, the coin and gem pills, the trophy
        // and the gear one row from the right, PLAY in the bottom-left corner, the crest in the bottom-right one. A row
        // moves as one, so its gaps stay as in the app on any screen shape.
        void Anchor(MenuLayout.Piece p, out int ax, out int ay)
        {
            var id = p.id ?? "";
            if (id.StartsWith("tab-")) { ax = -1; ay = -1; return; }
            if (id.StartsWith("pill-") || id.StartsWith("orb-")) { ax = 1; ay = -1; return; }
            if (id == "play") { ax = -1; ay = 1; return; }
            if (id == "crest") { ax = 1; ay = 1; return; }
            var R = _layout.reference;
            float cx = p.hit[0] + p.hit[2] / 2f, cy = p.hit[1] + p.hit[3] / 2f;
            ax = cx < R.px[0] / 3f ? -1 : cx > R.px[0] * 2f / 3f ? 1 : 0;
            ay = cy < R.px[1] / 3f ? -1 : cy > R.px[1] * 2f / 3f ? 1 : 0;
        }

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

        // a creature's still (Resources/Characters/still/<key>.png.bytes, the Characters screen's cut-out), or null
        Texture2D LoadStill(string key)
        {
            var bytes = Resources.Load<TextAsset>("Characters/still/" + key + ".png");
            if (bytes == null) { Debug.LogWarning("[Menu] no still for " + key); return null; }
            var tex = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "still " + key, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp };
            bool ok = tex.LoadImage(bytes.bytes, true);
            Resources.UnloadAsset(bytes);
            _made.Add(tex);
            return ok ? tex : null;
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

        /// <summary>Hides the whole menu (while a game is open over it) or shows it again.</summary>
        public bool Shown { get => _root.gameObject.activeSelf; set => _root.gameObject.SetActive(value); }

        public void Dispose()
        {
            DisposeHud();
            Carousel?.Dispose();
            Carousel = null;
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
            const float PressScale = 0.92f;        // the Level crest's .sq-crest:active scale(.92): every button's press
            public readonly MenuLayout.Piece Data;
            public Rect Hit { get; internal set; }  // page px on this screen (y down)
            readonly Transform _pivot;             // presses scale / move around this point
            readonly Vector3 _pivotPos;
            Vector3 _offset;                       // moved from its exported place (a pill's picture as the row reflows)
            internal Transform Pivot => _pivot;
            internal Vector2 PivotPx => new Vector2(_pivotPos.x, -_pivotPos.y);
            internal bool Pressed => _pressed;
            /// <summary>The press's scale right now (1 when not held) and where it scales about, page px (the pills' live
            /// number boxes shrink with it).</summary>
            internal float PressS => _pressed && _press != null ? _press.scale : 1;
            internal Vector2 PivotNowPx => new Vector2(_pivotPos.x + _offset.x, -(_pivotPos.y + _offset.y));
            readonly MenuLayout.Press _press;
            /// <summary>Moves the piece `px` (page px, y down) from where it was exported.</summary>
            internal void Offset(Vector2 px) { _offset = new Vector3(px.x, -px.y, 0); _pivot.localPosition = _pivotPos + _offset; }
            readonly SpriteRenderer _art, _fl;
            readonly Sprite[] _frames;
            readonly float _scale;
            bool _pressed, _live;
            public readonly int Order;

            // a live creature draws itself (CreatureView): no still, no placeholder breath
            public void UseLive() { _live = true; _art.enabled = false; }
            public void UseStill() { _live = false; _art.enabled = !_stillHidden; }
            bool _stillHidden;
            /// <summary>Hides the still (the intro's night, while the box hasn't dropped); the live creature hides itself.</summary>
            public void HideStill(bool hide) { _stillHidden = hide; if (!_live) _art.enabled = !hide; }

            // The exported creature picture is Mittens, 423 px tall in it (its feet at 424 px, its shadow under) where his
            // Characters still is 355 px: another creature's still at the same scale, its feet where his are, centred.
            const float StillK = 423f / 355f, StillFeet = 424f;
            public void SetStill(MenuView v, Texture2D tex)
            {
                var p = Data;
                var at = v.Map(p, new Vector2(p.rect[0], p.rect[1]));
                float k = StillK * _scale, w = tex.width * k, h = tex.height * k;
                var topLeft = new Vector2(at.x + p.rect[2] * _scale / 2 - w / 2, at.y + StillFeet * _scale - h);
                _art.sprite = v.MakeSprite(tex);
                _art.transform.localPosition = World(Snap(topLeft, k) - PivotPx);
                _art.transform.localScale = new Vector3(k, k, 1f);
            }

            // the HUD's fade (menu.js x.fade): every picture of the piece at this opacity
            public void SetAlpha(float a)
            {
                var c = new Color(1, 1, 1, a);
                if (_art != null) _art.color = c;
                if (_fl != null) _fl.color = c;
            }

            public PieceView(MenuView v, MenuLayout.Piece p, int order)
            {
                Data = p;
                Order = order;
                _scale = v.ScaleOf(p);
                var h0 = v.Map(p, new Vector2(p.hit[0], p.hit[1]));
                Hit = new Rect(h0.x, h0.y, p.hit[2] * _scale, p.hit[3] * _scale);
                var press = p.press ?? new MenuLayout.Press { scale = 1f, pivot = new[] { 0.5f, 0.5f } };
                // every button shrinks while held, as the Level crest does (the user, 2026-11-24: "zoom out and then
                // in, all the buttons"): PLAY's exported press (3 dp down) and the tabs', pills' and orbs' (none: the
                // app has no :active style for them) become the crest's scale(.92) about the button's middle
                if (!string.IsNullOrEmpty(p.tap) && press.scale == 1f)
                    press = new MenuLayout.Press { dy = 0, scale = PressScale, pivot = press.pivot };
                _press = press;
                var pv = press.pivot != null && press.pivot.Length == 2 ? press.pivot : new[] { 0.5f, 0.5f };
                var pivotPx = new Vector2(Hit.x + Hit.width * pv[0], Hit.y + Hit.height * pv[1]);

                _pivot = new GameObject(p.id).transform;
                _pivot.SetParent(p.world ? v._world : v._root, false);
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
                var press = _press;
                if (press == null) return;
                float s = on ? press.scale : 1f;
                _pivot.localScale = new Vector3(s, s, 1f);
                _pivot.localPosition = _pivotPos + _offset + (on ? new Vector3(0f, -press.dy * dpPx, 0f) : Vector3.zero);
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
                if (Data.id == "creature" && !_live)
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
