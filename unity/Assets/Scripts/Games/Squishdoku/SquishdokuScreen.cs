// Squishdoku in Unity, the whole screen as src/screens/SquishdokuScreen.js shows it: the hub, the level map, a Regular
// level, a Blitz run (SdScreen, no UnityEngine) shown as UiPieces, with the touches and Android's back fed to it.
// Opened like the games:
//   var s = SquishdokuScreen.Create(parent);  s.OnExit = () => ...;   (Start() runs Init; CI screenshots call
//   Init(nowMs) and Advance(nowMs) themselves; screenW / screenH in device pixels, 0: the screen's)
// The player (until Firebase): SdLevel.Profile in memory, seeded from what SquishdokuGame keeps in PlayerPrefs (the
// level reached, HEAD START) and written back as the player goes; the creatures are SquishdokuGame.Owned and BuddyKey.
// The pieces: Resources/Squishdoku (tools/unity/export-squishdoku.mjs), the creatures' cut-outs Resources/Stack/art.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using UnityEngine;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SquishdokuScreen : MonoBehaviour
    {
        public Action OnExit;
        /// <summary>Remove Ads (Blitz's save is free).</summary>
        public bool AdsFree;

        float _screenW, _screenH;
        bool _started;
        Ticker _tk;
        SdScreen _screen;
        readonly Dictionary<SdLayer, (UiPiece piece, int version)> _pieces = new Dictionary<SdLayer, (UiPiece, int)>();
        readonly HashSet<SdLayer> _seen = new HashSet<SdLayer>();
        readonly List<SdLayer> _gone = new List<SdLayer>();
        readonly HashSet<string> _heads = new HashSet<string>();
        // the cards' live characters (the result card's three, the fail card's sad one), as CardPieces draws them
        readonly Dictionary<SdLayer, CardPieces.ILive> _live = new Dictionary<SdLayer, CardPieces.ILive>();

        public static SquishdokuScreen Create(Transform parent, float screenW = 0, float screenH = 0)
        {
            var go = new GameObject("Squishdoku");
            go.transform.SetParent(parent, false);
            var s = go.AddComponent<SquishdokuScreen>();
            s._screenW = screenW; s._screenH = screenH;
            return s;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen (the hub) with the clock at `nowMs`.</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            _tk = new Ticker(nowMs);
            Ticker.Default = _tk;
            Card.LoadXml ??= name => Resources.Load<TextAsset>("Cards/" + name)?.text ?? throw new InvalidOperationException("Resources/Cards/" + name + ".xml is missing: run node tools/unity/export-cards.mjs");
            CardPieces.Init();   // (the cards' live characters: Squishdoku draws its cards itself, not through CardPieces)
            float w = (_screenW > 0 ? _screenW : Screen.width) / UiPiece.PxPerDp, h = (_screenH > 0 ? _screenH : Screen.height) / UiPiece.PxPerDp;
            SeedProfile();
            var art = SdArtList.Load();
            // (src/squishdoku/roster.js rosterOf: out (config/roster), never the Masked or Elemental Heroes; else, should
            // none be, every one.) The player's own first, then the rest: the app took the player's own alone, so one
            // owned made every piece that one (only Mittens); since 2026-11-26 (the user) the others fill in (SdCreature.Pick)
            var fit = new Dictionary<string, SdCreature>();
            foreach (var kv in art) if (SquishSquad.Screens.RosterConfig.InGames(kv.Key, pass: true)) fit[kv.Key] = kv.Value;
            if (fit.Count == 0) fit = art;
            var cast = new List<SdCreature>();
            foreach (var c in fit.Values) c.Mine = false;
            foreach (var k in SquishdokuGame.Owned) if (fit.TryGetValue(k, out var c) && !c.Mine) { c.Mine = true; cast.Add(c); }
            foreach (var c in fit.Values) if (!c.Mine) cast.Add(c);
            // the level map's room cards (Games/Shared/LevelMap, as Squish Hop's: Resources/Maps, Hubs/hubs.json)
            SquishSquad.Games.Shared.HubsData.LoadXml ??= path => Resources.Load<TextAsset>(path)?.text;
            SquishSquad.Games.Shared.HubsData.Current ??= JsonUtility.FromJson<SquishSquad.Games.Shared.HubsData>(Resources.Load<TextAsset>("Hubs/hubs")?.text ?? "{}");
            art.TryGetValue(SquishdokuGame.BuddyKey, out var buddy);
            _screen = new SdScreen(w, h, cast.ToArray(), buddy, Xml, HeadOf, _tk) { AdsFree = AdsFree, Save = true };
            _screen.OnExit = Leave;
            _screen.OnHeadChanged = on =>
            {
                SquishdokuGame.HeadStart = on;
                Sdk()["head"] = on;
                SdSave.Record(new Dictionary<string, object> { { "sdk.head", on } });   // (signed in: SquishdokuScreen.js toggleHead)
            };
            Sync();
        }

        // the profile's sdk record from what's kept on the phone until Firebase (the level reached, HEAD START)
        static IDictionary<string, object> Sdk()
        {
            if (!(SdLevel.Profile.TryGetValue("sdk", out var s) && s is IDictionary<string, object> d)) SdLevel.Profile["sdk"] = d = new Dictionary<string, object>();
            return d;
        }
        static void SeedProfile()
        {
            var sdk = Sdk();
            if (SdSave.To != null) return;   // signed in: the account's own record, as the app reads it
            if (!sdk.ContainsKey("lv")) sdk["lv"] = (double)SquishdokuGame.Level;
            if (!sdk.ContainsKey("head")) sdk["head"] = SquishdokuGame.HeadStart;
            if (!sdk.ContainsKey("plays")) sdk["plays"] = (double)PlayerPrefs.GetInt("sdk.plays", 0);
        }
        static void SaveProfile()
        {
            var rec = Levels.Record(SdLevel.Profile);
            if ((int)rec.Lv != SquishdokuGame.Level) SquishdokuGame.Level = (int)rec.Lv;
            if ((int)rec.Plays != PlayerPrefs.GetInt("sdk.plays", 0)) { PlayerPrefs.SetInt("sdk.plays", (int)rec.Plays); PlayerPrefs.Save(); }
        }

        static string Xml(string name) => Resources.Load<TextAsset>("Squishdoku/" + name)?.text
            ?? throw new InvalidOperationException("Resources/Squishdoku/" + name + ".xml is missing: run node tools/unity/export-squishdoku.mjs");

        string HeadOf(SdCreature c)
        {
            if (c == null) return null;
            var p = "Squishdoku/heads/" + c.Key;
            if (_heads.Contains(p)) return p;
            if (Resources.Load<Texture2D>(p) == null) return null;
            _heads.Add(p);
            return p;
        }

        /// <summary>Runs the clock to `nowMs` and places everything (CI screenshots step the screen with it).</summary>
        public void Advance(double nowMs)
        {
            if (!_started) Init(nowMs);
            _tk.Tick(nowMs);
            Sync();
        }

        /// <summary>The screen itself (CI screenshots: taps, views).</summary>
        public SdScreen Model => _screen;

        // (the time it takes, in the [Perf] log: App/PerfLog)

        void Update()

        {

            long perf = SquishSquad.App.PerfLog.Mark();

            try { UpdateHere(); } finally { SquishSquad.App.PerfLog.Add("Squishdoku update", perf); }

        }

        void UpdateHere()
        {
            if (!_started) return;
            Ticker.Default = _tk;
            _tk.Tick(Time.unscaledTimeAsDouble * 1000);
            HandleInput();
            if (_screen != null) Sync();
        }

        void OnApplicationPause(bool paused)
        {
            if (!paused || _screen == null) return;
            // AppState: a level or a run pauses
            _screen.Level?.Pause();
            _screen.Blitz?.Pause();
            SaveProfile();
        }

        void Sync()
        {
            _seen.Clear();
            int order = 0;
            foreach (var l in _screen.Layers())
            {
                if (!_seen.Add(l)) continue;
                if (l.Creature != null)
                {
                    if (!_live.TryGetValue(l, out var live)) _live[l] = live = CardPieces.MakeLive?.Invoke(transform, l.Creature);
                    if (live == null) l.Creature.Failed = true; else live.Sync(l.Transform, l.Visible ? l.Opacity : 0, order);
                    order++;
                    continue;
                }
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
                e.piece.Visible = l.Visible && l.Opacity > 0;
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
            _gone.Clear();
            foreach (var l in _live.Keys) if (!_seen.Contains(l)) _gone.Add(l);
            foreach (var l in _gone) { _live[l]?.Destroy(); _live.Remove(l); }
        }

        // ---- touches (one finger, or the mouse) and Android's back -------------------------------------------------------------
        bool _down;

        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) { _screen.Back(); return; }
            bool down, held, up;
            Vector2 px;
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                px = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up;
            }
            else { px = Input.mousePosition; down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0); held = Input.GetMouseButton(0); }
            float x = px.x / UiPiece.PxPerDp, y = (Screen.height - px.y) / UiPiece.PxPerDp;
            if (down) { _down = true; _screen.Down(x, y); }
            else if (_down && up) { _down = false; _screen.Up(x, y); }
            else if (_down && held) _screen.Move(x, y);
        }

        void Leave()
        {
            SaveProfile();
            OnExit?.Invoke();
            Destroy(gameObject);
        }
    }
}
