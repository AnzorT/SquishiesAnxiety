// SQUISH TIME in Unity: src/screens/SquishScreen.js (landscape, as the app shows it) around the squish stage
// (SquishToy + SquishStage). The menu opens it with the player's creature:
//   var s = SquishTime.Create(parent, "mittens", profile, fb, uid[, screenW, screenH]); s.OnExit = ...;
//   then Init(nowMs) (Unity's Start does it) and, outside play mode (CI screenshots), Advance(nowMs).
// `parent` as the other game screens: under the menu's pixel camera (world units = screen px, y up, the screen's
// top-left at the parent's origin). fb / uid null: offline (nothing written).
//
// What a squish does, as the app: a press dents the card where the finger is (one finger; two fingers turn it), the
// finger moving on it earns EARN_PER_TICK coins every EARN_TICK_MS of movement (x the streak's bonus, x10 in the
// tutorial's goal step), shown as a spinning coin and "+N" rising from the finger and counted on the "+N EARNED"
// pill; on release the coins banked are paid (addCoins + the 'earn' daily challenge), the press is recorded
// (recordPress: presses, longest hold, play time, the creature's growth XP) and counts toward the 'squish' daily
// challenge and its XP; 60 releases in a minute earn Speed Tapper; five jabs in a second (or seven in two) bring up
// the punishment card. The gesture hints and the settings hint show until the first touch; the gear opens the
// settings (poke strength 1-5, push in / pop out; the sound, vibration and FPS switches: the creature's squish loop,
// the coin ding, the release pop and the squish haptics, as SquishScreen.js). Not ported: the ×2/×3/×4 boosts (they're rewarded ads: the panel is shown,
// a tap says so), the ad behind ACCEPT PUNISHMENT (it closes the card, as with Remove Ads), the tutorial's coach marks.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Ui;
using SquishSquad.Vector;
using SquishSquad.Audio;
using UnityEngine;

namespace SquishSquad.Games.Squish
{
    public sealed class SquishTime : MonoBehaviour
    {
        /// <summary>Back out (the back orb, Android's back): the screen is gone after this.</summary>
        public Action OnExit;

        // the squish screen's settings (App.js keeps them for the session, not on the profile)
        public static bool SquishSoundOn = true, CoinSoundOn = true, ReleaseSoundOn = true, VibrationOn = true, ShowFps;
        public static int PokeStrength = 3;
        public static bool PokeOutward;

        string _key, _uid;
        IDictionary<string, object> _profile;
        FirebaseClient _fb;
        float _screenW, _screenH, _w, _h;
        bool _started;
        Ticker _tk;
        double _last;

        SquishToy _toy;
        SquishStage _stage;
        SquishLayout _L;
        string _creatureId;
        SquishSounds _snd;      // the creature's squish loop, the coin ding, the release pop (SquishScreen.js)
        SquishHaptics _hap;
        double _coinMultiplier = 1;

        // the HUD
        UiPiece _sky, _back, _pill, _gear, _gearGlyph, _boosts, _halo, _setHand, _setHint;
        readonly UiPiece[] _hands = new UiPiece[2], _labels = new UiPiece[2], _rings = new UiPiece[2];
        readonly List<UiPiece> _ripples = new List<UiPiece>(), _coins = new List<UiPiece>(), _stickers = new List<UiPiece>();
        readonly AnimatedValue[] _rippleT = new AnimatedValue[3], _coinT = new AnimatedValue[3];
        readonly Vector2[] _rippleAt = new Vector2[3], _coinAt = new Vector2[3];
        readonly int[] _coinAmount = new int[3];
        int _nextRipple, _nextCoin;
        UiPiece _setCard, _punDim, _punCard, _punTitle;
        readonly UiPiece[] _toggles = new UiPiece[5];
        UiPiece _strength, _direction;
        AnimatedValue _wheel, _hintOpacity, _setHintOpacity, _squishAnim, _rotateAnim, _touchAnim, _bobAnim, _pulseAnim, _punT;
        bool _showHints, _showSetHint, _setHintGone, _settingsOpen, _punishOpen;
        int _setHintTimer = -1;
        double _earned;
        string _toast;
        double _toastUntil;

        // the gesture (PanResponder)
        enum Gesture { None, Poke, Orbit }
        Gesture _mode;
        bool _hadTwo, _gestureOn, _hudDown;
        Vector2 _lastTouch, _soundAnchor, _lastCentroid, _hudAt;
        double _holdStart;
        readonly SquishRules.Earner _earner = new SquishRules.Earner();
        readonly SquishRules.AbuseGuard _abuse = new SquishRules.AbuseGuard();
        readonly SquishRules.SpeedTaps _speed = new SquishRules.SpeedTaps();

        public static SquishTime Create(Transform parent, string creatureKey, IDictionary<string, object> profile, FirebaseClient fb, string uid, float screenW = 0, float screenH = 0)
        {
            var go = new GameObject("Squish Time");
            go.transform.SetParent(parent, false);
            var s = go.AddComponent<SquishTime>();
            s._key = creatureKey; s._profile = profile != null ? new Dictionary<string, object>(profile) : new Dictionary<string, object>();
            s._fb = fb; s._uid = uid; s._screenW = screenW; s._screenH = screenH;
            return s;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        static string Text(string path) => Resources.Load<TextAsset>(path)?.text ?? throw new InvalidOperationException("Resources/" + path + " is missing: run node tools/unity/export-squish.mjs");

        /// <summary>Builds the screen with the clock at `nowMs`.</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            UiFont.ReadJson ??= name => Resources.Load<TextAsset>("Fonts/" + name)?.text;
            UiFont.ParseJson ??= json => JsonUtility.FromJson<UiFontData>(json);
            SquishHudArt.Xml = n => Text("Squish/hud/" + n);
            _tk = new Ticker(nowMs);
            Ticker.Default = _tk;
            _last = nowMs;
            _w = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp;
            _h = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            _L = new SquishLayout(_w, _h, (IDictionary<string, object>)Json.Parse(Text("Squish/hud")));

            // the creature: its card data, its growth stage, its atlas
            var data = (IDictionary<string, object>)Json.Parse(Text("Squish/squish"));
            var roster = ((IList<object>)data["roster"]).Cast<IDictionary<string, object>>().ToList();
            var me = roster.FirstOrDefault(c => (string)c["key"] == _key);
            _creatureId = me != null ? (string)me["id"] : "1";
            _snd = SquishSounds.Open(_creatureId, me != null && me.TryGetValue("audio", out var au) ? au as string : null);
            if (UnityAudio.Instance != null) _hap = new SquishHaptics(UnityAudio.Instance.Timers);
            var moves = SquishCard.ParseMoves((IDictionary<string, object>)data["moves"]);
            int stage = SquishRules.StageOf(_profile, _creatureId);
            var atlas = LoadAtlas(_key) ?? LoadCached(_creatureId);
            bool fetch = atlas == null;   // not shipped (the app's six are): its card from Storage, as the app's card.url
            atlas ??= LoadAtlas("mittens");
            var crownBytes = Resources.Load<TextAsset>("Squish/crown.png");
            Texture2D crown = null;
            if (crownBytes != null) { crown = new Texture2D(2, 2, TextureFormat.RGBA32, true, true); crown.LoadImage(crownBytes.bytes); crown.wrapMode = TextureWrapMode.Clamp; }
            _toy = SquishToy.MakeCard(moves.TryGetValue(_creatureId, out var cd) ? cd : null, stage, UnityEngine.Random.value * 10000, UnityEngine.Random.value * 10);
            _toy.Random = () => UnityEngine.Random.value;
            _toy.SetPoke(SquishRules.PokeStrengthScales[Mathf.Clamp(PokeStrength, 1, 5) - 1], PokeOutward);
            _coinMultiplier = SquishRules.CoinMultiplier(_profile, DateTime.Now);
            bool tutorial = SquishRules.TutorialOn(_profile);
            _showHints = _showSetHint = !tutorial;
            _setHintGone = tutorial;

            BuildHud(atlas, crown);
            if (fetch) FetchCard(_creatureId);
            Advance(nowMs);
        }

        static Texture2D LoadAtlas(string key)
        {
            var bytes = Resources.Load<TextAsset>("Squish/cards/" + key + ".png");
            if (bytes == null) return null;
            // as three uploads it: the PNG's raw values (the shader decodes sRGB), mipmapped, clamped
            var t = new Texture2D(2, 2, TextureFormat.RGBA32, true, true) { name = "card " + key };
            t.LoadImage(bytes.bytes);
            t.wrapMode = TextureWrapMode.Clamp;
            t.filterMode = FilterMode.Trilinear;
            t.anisoLevel = 16;
            return t;
        }
        static Texture2D Atlas(byte[] png, string name)
        {
            // as three uploads it: the PNG's raw values (the shader decodes sRGB), mipmapped, clamped
            var t = new Texture2D(2, 2, TextureFormat.RGBA32, true, true) { name = name };
            if (!t.LoadImage(png)) { Destroy(t); return null; }
            t.wrapMode = TextureWrapMode.Clamp;
            t.filterMode = FilterMode.Trilinear;
            t.anisoLevel = 16;
            return t;
        }

        static string CachePath(string id) => System.IO.Path.Combine(Application.persistentDataPath, "cards", id + ".png");

        static Texture2D LoadCached(string id)
        {
            try { var f = CachePath(id); return System.IO.File.Exists(f) ? Atlas(System.IO.File.ReadAllBytes(f), "card " + id) : null; }
            catch (Exception) { return null; }
        }

        // the creature's published card (Storage, its catalog entry's card.url), kept on the phone for next time; until
        // it's here (or offline) Mittens' card stands in
        async void FetchCard(string id)
        {
            if (!Online) { Debug.LogWarning($"[SquishTime] no card for '{_key}' offline: showing Mittens'"); return; }
            try
            {
                var list = await _fb.Data.ListCreatures();
                var me = list.FirstOrDefault(c => c.TryGetValue("id", out var x) && (x as string) == id);
                var url = me != null && me.TryGetValue("card", out var card) && card is IDictionary<string, object> cm && cm.TryGetValue("url", out var u) ? u as string : null;
                if (string.IsNullOrEmpty(url)) { Debug.LogWarning($"[SquishTime] '{_key}' has no published card: showing Mittens'"); return; }
                using var req = UnityEngine.Networking.UnityWebRequest.Get(url);
                var op = req.SendWebRequest();
                while (!op.isDone) await System.Threading.Tasks.Task.Yield();
                if (req.result != UnityEngine.Networking.UnityWebRequest.Result.Success || this == null) return;
                var png = req.downloadHandler.data;
                var tex = Atlas(png, "card " + id);
                if (tex == null) return;
                try { System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(CachePath(id))); System.IO.File.WriteAllBytes(CachePath(id), png); }
                catch (Exception) { /* next time it downloads again */ }
                _stage?.SetAtlas(tex);
            }
            catch (Exception e) { Debug.LogWarning("[SquishTime] card: " + e.Message); }
        }

        // ---- the HUD -----------------------------------------------------------------------------------------------------
        UiPiece Piece(string name, int order, string svg, HudBox b, float margin = 6)
        {
            var p = UiPiece.Create(transform, name, order);
            p.SetSvg(svg, b.W, b.H, margin);
            p.Transform = Affine.Translate(b.X, b.Y);
            return p;
        }
        string X(string name) => Text("Squish/hud/" + name);
        HudBox A(string name) => _L.A15[name];

        void BuildHud(Texture2D atlas, Texture2D crown)
        {
            // the sky (SkyBackground), stretched to the screen
            _sky = Piece("sky", -100, X("sky"), new HudBox(0, 0, 832, 384), 0);
            _sky.Transform = Affine.ScaleBy(_w / 832, _h / 384);
            _stage = new SquishStage(transform, atlas, crown, -50);
            // the stage's hints (the hands with their pulsing rings, the captions)
            for (int i = 0; i < 2; i++)
            {
                _hands[i] = Piece("hand", -40, X("hand-" + (i + 1)), _L.HintHands[i]);
                _rings[i] = Piece("touch ring", -39, SquishHudArt.Ring(26, 2.5f, "#ff6fbd"), new HudBox(0, 0, 26, 26));
                _labels[i] = Piece("hint", -40, X("hint-" + (i + 1)), _L.HintLabels[i], 10);
            }
            // the touch ripples and the floating coins (pooled, as StageEffects)
            for (int i = 0; i < 3; i++)
            {
                var r = Piece("ripple", -30, SquishHudArt.Ring((float)SquishRules.RippleMax, 3, "rgba(255,111,189,0.7)"), new HudBox(0, 0, 180, 180));
                r.Opacity = 0; _ripples.Add(r); _rippleT[i] = new AnimatedValue(1);
                var c = Piece("coin", -20, X("float-coin"), new HudBox(0, 0, 30, 30), 14);
                c.Opacity = 0; _coins.Add(c); _coinT[i] = new AnimatedValue(1);
                var st = UiPiece.Create(transform, "+N", -20); st.Opacity = 0; _stickers.Add(st);
            }
            // the top left, the gear, its hint, the boosts' panel
            _back = Piece("back", 10, X("back"), _L.Back);
            _pill = UiPiece.Create(transform, "earned", 10);
            SetPill(0);
            _gear = Piece("gear", 10, X("gear"), _L.Gear);
            _gearGlyph = Piece("gear glyph", 11, X("gear-glyph"), _L.GearGlyph);
            _halo = Piece("gear halo", 12, SquishHudArt.Ring(52, 3, "#ff8a3d"), _L.GearHalo);
            _setHand = Piece("settings hand", 12, X("hand-0"), _L.SettingsHand);
            _setHint = Piece("settings hint", 12, X("hint-0"), _L.SettingsHint, 10);
            _boosts = Piece("boosts", 10, X("boosts"), _L.Boosts, 14);
            // the settings card (hidden) with its switches and choices
            _setCard = Piece("settings", 100, X("settings"), _L.Settings, 24);
            for (int i = 0; i < 5; i++) _toggles[i] = UiPiece.Create(transform, "toggle " + i, 101);
            _strength = UiPiece.Create(transform, "poke strength", 101);
            _direction = UiPiece.Create(transform, "poke direction", 101);
            // the punishment (hidden)
            _punDim = Piece("punish dim", 200, SquishHudArt.Dim(_w, _h, "rgba(50,24,6,0.55)"), new HudBox(0, 0, _w, _h), 0);
            _punCard = Piece("punish", 201, X("punish"), _L.Punish, 24);
            var title = SquishHudArt.PunishTitle();
            _punTitle = Piece("punish title", 202, title.Markup(), new HudBox(0, 0, title.W, title.H), 8);

            // the loops (useLoopAnim: 0 -> 1 -> 0, inOut(ease), forever)
            _squishAnim = Loop(1700); _rotateAnim = Loop(1700); _touchAnim = Loop(1700);
            _bobAnim = Loop(650); _pulseAnim = Loop(900);
            _hintOpacity = new AnimatedValue(1);
            _setHintOpacity = new AnimatedValue(1);
            _wheel = new AnimatedValue(0);
            _punT = new AnimatedValue(0);
        }

        static AnimatedValue Loop(double duration)
        {
            var v = new AnimatedValue(0);
            Animated.Loop(Animated.Sequence(
                Animated.Timing(v, new TimingConfig { ToValue = 1, Duration = duration, Easing = Easing.InOut(Easing.Ease) }),
                Animated.Timing(v, new TimingConfig { ToValue = 0, Duration = duration, Easing = Easing.InOut(Easing.Ease) }))).Start();
            return v;
        }

        void SetPill(double value)
        {
            var svg = SquishHudArt.Pill(value, out var pw, out var ph);
            _pill.SetSvg(svg, pw, ph, 6);
            _pill.Transform = Affine.Translate(_L.Pill.X, _L.Pill.Y);
        }

        // an interpolation (RN's interpolate, clamped at its ends as these ranges are used)
        static double Lerp(double t, double[] input, double[] output)
        {
            if (t <= input[0]) return output[0];
            for (int i = 1; i < input.Length; i++)
                if (t <= input[i]) return output[i - 1] + (output[i] - output[i - 1]) * (t - input[i - 1]) / (input[i] - input[i - 1]);
            return output[output.Length - 1];
        }

        // RN's transform about the view's centre: translate, then the rest
        static Affine About(HudBox b, Affine inner) => Affine.Translate(b.X + b.W / 2, b.Y + b.H / 2) * inner * Affine.Translate(-b.W / 2, -b.H / 2);

        // ---- the frame -----------------------------------------------------------------------------------------------------
        void Update()
        {
            if (!_started) return;
            HandleInput();
            if (this != null) Advance(Time.unscaledTimeAsDouble * 1000);
        }

        /// <summary>Runs the clock to `nowMs`: the toy's frame (useFrame), the stage, the HUD.</summary>
        public void Advance(double nowMs)
        {
            Ticker.Default = _tk;
            _tk.Tick(nowMs);
            double delta = Math.Max(0, (nowMs - _last) / 1000);
            _last = nowMs;
            _toy.Tick(delta, nowMs);
            _stage.Draw(_toy, _L.Stage, UiPiece.PxPerDp);
            PlaceHud();
            foreach (var p in GetComponentsInChildren<UiPiece>(true)) p.Apply();
        }

        void PlaceHud()
        {
            // the stage's hints: the squish hand bobs, the rotate hand tilts, the rings pulse (TouchRing: inside the hand)
            double ho = _showHints ? _hintOpacity.GetValue() : 0;
            for (int i = 0; i < 2; i++)
            {
                var hb = _L.HintHands[i];
                Affine move = i == 0
                    ? Affine.Translate(0, Lerp(_squishAnim.GetValue(), new double[] { 0, 0.5, 1 }, new double[] { 0, 8, 0 }))
                    : Affine.Rotate(Lerp(_rotateAnim.GetValue(), new double[] { 0, 0.5, 1 }, new double[] { 0, -14, 0 }));
                var hand = About(hb, move);
                _hands[i].Transform = hand;
                _hands[i].Opacity = (float)ho;
                var rb = _L.HintRings[i];
                double t = _touchAnim.GetValue();
                var ringLocal = new HudBox(rb.X - hb.X, rb.Y - hb.Y, rb.W, rb.H);
                _rings[i].Transform = hand * About(ringLocal, Affine.ScaleBy(1 + 0.3 * t, 1 + 0.3 * t));
                _rings[i].Opacity = (float)(ho * Lerp(t, new double[] { 0, 0.5, 1 }, new double[] { 0.95, 0.35, 0.95 }));
                _labels[i].Opacity = (float)ho;
            }
            // the settings hint
            double so = _showSetHint ? _setHintOpacity.GetValue() : 0;
            double pulse = _pulseAnim.GetValue();
            _halo.Transform = About(_L.GearHalo, Affine.ScaleBy(1 + 0.28 * pulse, 1 + 0.28 * pulse));
            _halo.Opacity = (float)(so * Lerp(pulse, new double[] { 0, 1 }, new double[] { 0.95, 0.15 }));
            _setHand.Transform = Affine.Translate(_L.SettingsHand.X, _L.SettingsHand.Y - 7 * _bobAnim.GetValue());
            _setHand.Opacity = (float)so;
            _setHint.Opacity = (float)so;
            // the gear's glyph turns half round as the settings open
            _gearGlyph.Transform = About(_L.GearGlyph, Affine.Rotate(180 * _wheel.GetValue()));
            // the ripples: scale 0.25 -> 1, opacity 0 -> 0.5 -> 0
            for (int i = 0; i < 3; i++)
            {
                double t = _rippleT[i].GetValue();
                double s = 0.25 + 0.75 * t;
                var b = new HudBox(_L.Stage.X + _rippleAt[i].x - 90, _L.Stage.Y + _rippleAt[i].y - 90, 180, 180);
                _ripples[i].Transform = About(b, Affine.ScaleBy(s, s));
                _ripples[i].Opacity = (float)Lerp(t, new double[] { 0, 0.15, 1 }, new double[] { 0, 0.5, 0 });
            }
            // the floating coins: up from 8 to -72, opacity 0 -> 1 -> 1 -> 0, the coin turning about its upright
            // (rotateY 0 -> 360 deg under perspective 200: drawn as its width's cosine)
            for (int i = 0; i < 3; i++)
            {
                double t = _coinT[i].GetValue();
                float op = (float)Lerp(t, new double[] { 0, 0.15, 0.75, 1 }, new double[] { 0, 1, 1, 0 });
                double ty = 8 + (-SquishRules.FloatingCoinRise - 8) * t;
                var sticker = SquishHudArt.Sticker(Math.Max(1, _coinAmount[i]));
                SquishHudArt.FloatRow(sticker, out var coinY, out var sx, out var sy, out _, out _);
                double x0 = _L.Stage.X + _coinAt[i].x - 40, y0 = _L.Stage.Y + _coinAt[i].y - 60 + ty;
                double spin = Math.Cos(2 * Math.PI * t);
                _coins[i].Transform = About(new HudBox((float)x0, (float)(y0 + coinY), 30, 30), Affine.ScaleBy(spin, 1));
                _coins[i].Opacity = op;
                _stickers[i].Transform = Affine.Translate(x0 + sx, y0 + sy);
                _stickers[i].Opacity = op;
            }
            // the settings card
            _setCard.Visible = _settingsOpen;
            bool[] on = { SquishSoundOn, CoinSoundOn, ReleaseSoundOn, ShowFps, VibrationOn };
            for (int i = 0; i < 5; i++)
            {
                _toggles[i].Visible = _settingsOpen;
                if (!_settingsOpen) continue;
                var b = _L.InSettings($"toggle-{i}-on");
                _toggles[i].SetSvg(X($"toggle-{i}-{(on[i] ? "on" : "off")}"), b.W, b.H, 6);
                _toggles[i].Transform = Affine.Translate(b.X, b.Y);
            }
            _strength.Visible = _direction.Visible = _settingsOpen;
            if (_settingsOpen)
            {
                var sb = _L.InSettings("strength-" + PokeStrength);
                _strength.SetSvg(X("strength-" + PokeStrength), sb.W, sb.H, 6);
                _strength.Transform = Affine.Translate(sb.X, sb.Y);
                var db = _L.InSettings("direction-" + (PokeOutward ? "out" : "in"));
                _direction.SetSvg(X("direction-" + (PokeOutward ? "out" : "in")), db.W, db.H, 6);
                _direction.Transform = Affine.Translate(db.X, db.Y);
            }
            // the punishment: springs in small and tilted (PunishCard)
            _punDim.Visible = _punCard.Visible = _punTitle.Visible = _punishOpen;
            if (_punishOpen)
            {
                double t = _punT.GetValue();
                var turn = About(_L.Punish, Affine.Rotate(-8 + 8 * t) * Affine.ScaleBy(0.4 + 0.6 * t, 0.4 + 0.6 * t));
                _punCard.Transform = turn;
                _punCard.Opacity = (float)Math.Max(0, Math.Min(1, t));
                var tb = A("punishTitle");
                _punTitle.Transform = turn * Affine.Translate(tb.X - A("punish").X, tb.Y - A("punish").Y);
                _punTitle.Opacity = _punCard.Opacity;
            }
        }

        // ---- the touches ---------------------------------------------------------------------------------------------------
        static Vector2 Dp(Vector2 px) => new Vector2(px.x / UiPiece.PxPerDp, (Screen.height - px.y) / UiPiece.PxPerDp);

        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_settingsOpen) SetSettings(false);
                else Exit();
                return;
            }
            // the touches as dp points (the mouse is one finger)
            var pts = new List<Vector2>();
            bool anyBegan = false, allUp;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    var t = Input.GetTouch(i);
                    if (t.phase == TouchPhase.Began) anyBegan = true;
                    if (t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled) pts.Add(Dp(t.position));
                }
                allUp = pts.Count == 0;
            }
            else
            {
                anyBegan = Input.GetMouseButtonDown(0);
                if (Input.GetMouseButton(0) || anyBegan) pts.Add(Dp(Input.mousePosition));
                allUp = pts.Count == 0;
            }
            double now = _tk.Now;

            if (!_gestureOn && !_hudDown && anyBegan && pts.Count > 0)
            {
                var p = pts[0];
                // the overlays first (they cover the screen), then the HUD, then the stage
                if (_punishOpen || _settingsOpen || !_L.Stage.Contains(p.x, p.y) || HudHit(p)) { _hudDown = true; _hudAt = p; return; }
                Grant(pts, now);
                return;
            }
            if (_hudDown)
            {
                if (allUp) { _hudDown = false; Tap(_hudAt); }
                return;
            }
            if (!_gestureOn) return;
            if (allUp) { Release(now); return; }
            if (pts.Count >= 2 && _mode != Gesture.Orbit)
            {
                // a second finger: the poke becomes a turn (onPanResponderStart / Move)
                _hadTwo = true;
                _snd?.Squish.Stop();
                _toy.CancelPoke();
                StopEarning();
                _mode = Gesture.Orbit;
                _lastCentroid = Centroid(pts);
                return;
            }
            Move(pts, now);
        }

        bool HudHit(Vector2 p) => _L.Back.Contains(p.x, p.y) || _L.Gear.Contains(p.x, p.y) || _L.Boosts.Contains(p.x, p.y);

        Vector2 Local(Vector2 p) => new Vector2(p.x - _L.Stage.X, p.y - _L.Stage.Y);
        static Vector2 Centroid(List<Vector2> pts) { var c = Vector2.zero; foreach (var p in pts) c += p; return c / pts.Count; }
        (double x, double y) Ndc(Vector2 local) => (local.x / _L.StageSize * 2 - 1, -(local.y / _L.StageSize * 2 - 1));

        // onPanResponderGrant
        void Grant(List<Vector2> pts, double now)
        {
            _gestureOn = true;
            if (_showHints || !_setHintGone)
            {
                if (_showHints) Animated.Timing(_hintOpacity, new TimingConfig { ToValue = 0, Duration = 300 }).Start(r => { if (r.Finished) _showHints = false; });
                if (_setHintTimer < 0 && !_setHintGone) _setHintTimer = _tk.SetTimeout(DismissSettingsHint, 4000);
            }
            _hadTwo = pts.Count >= 2;
            if (pts.Count >= 2)
            {
                _mode = Gesture.Orbit;
                _lastCentroid = Centroid(pts);
                return;
            }
            _mode = Gesture.Poke;
            if (SquishSoundOn) _snd?.Squish.Start();
            if (VibrationOn) _hap?.Press(PokeStrength);
            var l = Local(pts[0]);
            _lastTouch = l;
            _soundAnchor = l;
            _holdStart = now;
            var (nx, ny) = Ndc(l);
            _toy.PointerDown(nx, ny);
            var r = _nextRipple++ % 3;
            _rippleAt[r] = l;
            _rippleT[r].SetValue(0);
            Animated.Timing(_rippleT[r], new TimingConfig { ToValue = 1, Duration = SquishRules.RippleLifetimeMs, Easing = Easing.Out(Easing.Quad) }).Start();
            _earner.Start(now);
        }

        // onPanResponderMove
        void Move(List<Vector2> pts, double now)
        {
            if (pts.Count >= 2 || _mode == Gesture.Orbit)
            {
                var c = pts.Count >= 2 ? Centroid(pts) : pts[0];
                if (_mode == Gesture.Orbit) _toy.Orbit(c.x - _lastCentroid.x, c.y - _lastCentroid.y);
                _lastCentroid = c;
                return;
            }
            var l = Local(pts[0]);
            if (l == _lastTouch) return;
            _lastTouch = l;
            var (nx, ny) = Ndc(l);
            _toy.PointerMove(nx, ny);
            var a = l - _soundAnchor;
            if (a.x * a.x + a.y * a.y >= SquishRules.SoundMotionDp * SquishRules.SoundMotionDp)
            {
                _soundAnchor = l;
                if (SquishSoundOn) _snd?.Squish.NoteMotion();
                if (VibrationOn) _hap?.Move(PokeStrength);
                foreach (int gain in _earner.NoteMotion(now, false, 1, _coinMultiplier))
                {
                    _earned += gain;
                    if (CoinSoundOn) _snd?.Coin();
                    SetPill(_earned);
                    var c = _nextCoin++ % 3;
                    _coinAt[c] = _lastTouch;
                    if (_coinAmount[c] != gain)
                    {
                        _coinAmount[c] = gain;
                        var st = SquishHudArt.Sticker(gain);
                        _stickers[c].SetSvg(st.Markup(), st.W, st.H, 8);
                    }
                    _coinT[c].SetValue(0);
                    Animated.Timing(_coinT[c], new TimingConfig { ToValue = 1, Duration = SquishRules.FloatingCoinMs, Easing = Easing.Bezier(0.25, 0.6, 0.35, 1) }).Start();
                }
            }
        }

        // onPanResponderRelease
        void Release(double now)
        {
            var mode = _mode;
            bool hadTwo = _hadTwo;
            _gestureOn = false;
            _mode = Gesture.None;
            _hadTwo = false;
            _snd?.Squish.Stop();
            if (mode == Gesture.Orbit || hadTwo)
            {
                _toy.EndOrbit();
                _toy.PointerUp(now);
                StopEarning();
                return;
            }
            var result = _toy.PointerUp(now);
            if (!result.wasPoke) { StopEarning(); return; }
            double holdMs = now - _holdStart;
            if (_speed.Note(now) >= SquishRules.SpeedTapThreshold && !Achieved("speedTap")) MarkAchievement("speedTap");
            RecordPress(holdMs);
            StopEarning();
            if (ReleaseSoundOn) _snd?.Pop();
            if (VibrationOn) _hap?.Release(PokeStrength);
            if (holdMs < SquishRules.HoldAbuseMs && _abuse.Register(now)) OpenPunishment();
        }

        void StopEarning()
        {
            double earned = _earner.Stop();
            if (earned <= 0) return;
            if (Online) Fire(_fb.Data.AddCoins(_uid, earned), "addCoins");
            else SquishSquad.Backend.OfflineWallet.Paid(earned);   // (the dev menu offline: Backend/OfflineWallet.cs)
            NoteDaily("earn", earned);
        }

        // ---- the taps on the HUD --------------------------------------------------------------------------------------------
        void Tap(Vector2 p)
        {
            if (_punishOpen)
            {
                if (_L.PunishButton.Contains(p.x, p.y)) { _punishOpen = false; _abuse.Dismiss(); }
                return;
            }
            if (_settingsOpen)
            {
                var c = _L.Settings;
                if (!c.Contains(p.x, p.y) || _L.CloseX.Contains(p.x, p.y)) { SetSettings(false); return; }
                for (int i = 0; i < 5; i++)
                    if (_L.InSettings($"toggle-{i}-on").Contains(p.x, p.y))
                    {
                        if (i == 0) { SquishSoundOn = !SquishSoundOn; if (!SquishSoundOn) _snd?.Squish.Stop(); }
                        else if (i == 1) CoinSoundOn = !CoinSoundOn;
                        else if (i == 2) ReleaseSoundOn = !ReleaseSoundOn;
                        else if (i == 3) ShowFps = !ShowFps;
                        else VibrationOn = !VibrationOn;
                        return;
                    }
                var sb = _L.InSettings("strength-1");
                if (sb.Contains(p.x, p.y))
                {
                    // five equal segments, gap 4
                    PokeStrength = Mathf.Clamp(1 + (int)((p.x - sb.X) / ((sb.W + 4) / 5)), 1, 5);
                    _toy.SetPoke(SquishRules.PokeStrengthScales[PokeStrength - 1], PokeOutward);
                    return;
                }
                var db = _L.InSettings("direction-in");
                if (db.Contains(p.x, p.y))
                {
                    PokeOutward = p.x >= db.X + db.W / 2;
                    _toy.SetPoke(SquishRules.PokeStrengthScales[PokeStrength - 1], PokeOutward);
                }
                return;
            }
            if (_L.Back.Contains(p.x, p.y)) { Exit(); return; }
            if (_L.Gear.Contains(p.x, p.y)) { DismissSettingsHint(); SetSettings(true); return; }
            if (_L.Boosts.Contains(p.x, p.y)) ShowToast("Coin boosts come with a video ad: not in the Unity version yet");
        }

        void SetSettings(bool open)
        {
            _settingsOpen = open;
            Animated.Timing(_wheel, new TimingConfig { ToValue = open ? 1 : 0, Duration = 400 }).Start();
        }

        void DismissSettingsHint()
        {
            if (_setHintGone) return;
            _setHintGone = true;
            if (_setHintTimer >= 0) _tk.ClearTimeout(_setHintTimer);
            Animated.Timing(_setHintOpacity, new TimingConfig { ToValue = 0, Duration = 300 }).Start(r => { if (r.Finished) _showSetHint = false; });
        }

        void OpenPunishment()
        {
            _punishOpen = true;
            _punT.SetValue(0);
            Animated.Spring(_punT, new SpringConfig { ToValue = 1, Friction = 5, Tension = 120 }).Start();
        }

        void Exit()
        {
            if (_gestureOn) Release(_tk.Now);
            OnExit?.Invoke();
            _stage?.Dispose();
            if (Application.isPlaying) Destroy(gameObject); else DestroyImmediate(gameObject);
        }

        void OnDestroy() { _stage?.Dispose(); _snd?.Close(); _snd = null; }

        // ---- the profile (App.js's handlers) --------------------------------------------------------------------------------
        bool Online => _fb != null && !string.IsNullOrEmpty(_uid);

        bool Achieved(string key) => _profile.TryGetValue("achievements", out var a) && a is IDictionary<string, object> m && m.TryGetValue(key, out var v) && v is bool b && b;

        void MarkAchievement(string key)
        {
            if (!(_profile.TryGetValue("achievements", out var a) && a is IDictionary<string, object> m)) _profile["achievements"] = m = new Dictionary<string, object>();
            m[key] = true;
            if (Online) Fire(_fb.Data.MarkAchievement(_uid, key), "markAchievement");
        }

        // handleRecordPress: recordPress, then the 'squish' daily challenge
        void RecordPress(double holdMs)
        {
            if (!Online) return;
            Fire(_fb.Data.RecordPress(_uid, _creatureId, holdMs), "recordPress");
            NoteDaily("squish", 1);
        }

        // noteDaily -> firestore.js bumpDaily: today's progress (and a squish's XP), the toast for a challenge done
        void NoteDaily(string ev, double n)
        {
            if (!Online) return;
            if (_fb.Data.Feed != null && _fb.Data.Feed.Uid == _uid && _fb.Data.Feed.Current != null) _profile = new Dictionary<string, object>(_fb.Data.Feed.Current);
            var bump = SquishRules.BumpDaily(_profile, ev, n, SquishRules.TodayKey(DateTime.Now));
            var update = new Dictionary<string, object> { ["daily"] = bump.Daily };
            if (bump.CribCare) update["cribCare"] = FieldValue.Increment(n);
            foreach (var kv in _fb.Data.XpFields(_profile, bump.Xp, SquishRules.LevelAfter(_profile, bump.Xp))) update[kv.Key] = kv.Value;
            // (the profile snapshot brings this back; until then the next bump builds on it)
            _profile["daily"] = bump.Daily;
            if (bump.Xp > 0) _profile["pxp"] = SquishRules.PxpOf(_profile) + bump.Xp;
            Fire(_fb.Data.UpdateProfile(_uid, update), "bumpDaily");
            if (bump.Completed.Count > 0) ShowToast("Challenge complete: " + bump.Completed[0]);
        }

        static void Fire(Task t, string what) =>
            t?.ContinueWith(x => Debug.LogWarning($"[SquishTime] {what} failed: {x.Exception?.GetBaseException().Message}"), TaskContinuationOptions.OnlyOnFaulted);

        // ---- the note ----------------------------------------------------------------------------------------------------
        void ShowToast(string text, double seconds = 2.2)
        {
            _toast = text;
            _toastUntil = Time.unscaledTimeAsDouble + seconds;
        }

        void OnGUI()
        {
            if (_toast == null || Time.unscaledTimeAsDouble >= _toastUntil) return;
            float u = Screen.height / 384f;
            var box = new GUIStyle(GUI.skin.box) { fontSize = Mathf.RoundToInt(13 * u), alignment = TextAnchor.MiddleCenter, wordWrap = true };
            box.normal.textColor = Color.white;
            GUI.Box(new Rect(Screen.width * 0.2f, Screen.height * 0.82f, Screen.width * 0.6f, Screen.height * 0.1f), _toast, box);
        }

        /// <summary>The toy (tests, CI screenshots: press it through PointerDown / PointerMove / PointerUp).</summary>
        public SquishToy Toy => _toy;
    }
}
