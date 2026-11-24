// The Yard Games (develop: the menu's games page in yard mode, opened from the backyard's YARD GAMES button): the page
// of the seven games (YardPageModel.cs: wide poster cards dragged sideways, a game locked until one of its toys is
// bought in the Backyard's catalog) and a game across the page as the app plays it. The games are the app's own
// (yard-games.js v6, yg-intros.js, yg-*.js, landscape, compiled with the rig: YardJs), on the rig's one clock: their
// own layers and creatures are drawn straight from them; the top bar, the hint, their pills and buttons, the toasts,
// the intro's how-to sheet and the results card in the app's look (YardGameArt.cs); their synth sounds as the old
// port's clips (Resources/Yard/sfx). The bests are kept on the device as the page keeps them (yardgames.v1).
//   var y = YardScreen.Create(parent, rosterKeys, nameOf, player, open, need);   y.OnExit = ...;
using System;
using System.Collections.Generic;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Menu;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Yard.View
{
    public sealed class YardScreen : MonoBehaviour
    {
        public Action OnExit;
        IList<string> _roster; Func<string, string> _nameOf;
        const float Off = 20000;
        const string SaveKey = "yardgames.v1";
        static float pk => UiPiece.PxPerDp;
        static readonly Dictionary<string, string> NAMES = new Dictionary<string, string>
        {
            ["hoop"] = "Hoop Shot", ["soccer"] = "Penalty Kick", ["hop"] = "Hopscotch", ["tramp"] = "Bounce Up", ["slide"] = "Slide & Splash", ["corn"] = "Cornhole", ["pong"] = "Ping-Pong",
        };

        Camera _cam; Transform _root;
        float _w, _h;
        YardSave _save = new YardSave();
        bool _muted;

        // pieces
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly HashSet<string> _used = new HashSet<string>();
        const int O = 200;
        AudioSource _au; readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

        /// <summary>player: the menu's creature (it plays every game, as the app's page picks it); open: is a game open
        /// (HouseYard.Locked: a toy of it bought); need: what a locked game's tap says (HouseYard.NeedText).</summary>
        public static YardScreen Create(Transform parent, IList<string> roster, Func<string, string> nameOf, string player = null, Func<string, bool> open = null, Func<string, string> need = null)
        {
            var go = new GameObject("yard games"); go.transform.SetParent(parent, false);
            var s = go.AddComponent<YardScreen>();
            s._player = player; s._open = open; s._need = need;
            s._roster = roster != null && roster.Count > 0 ? roster : new[] { "biscuit", "pip", "mallow", "nimbo", "ribbit", "bao", "mittens", "sealy", "frybo", "poppy" };
            s._nameOf = nameOf ?? (k => string.IsNullOrEmpty(k) ? k : char.ToUpperInvariant(k[0]) + k.Substring(1));
            return s;
        }

        double Now => Time.unscaledTimeAsDouble * 1000;
        string PlayerKey => _player != null && _roster.Contains(_player) ? _player : _roster.Contains("mittens") ? "mittens" : _roster[0];

        void Start()
        {
            _w = Screen.width; _h = Screen.height;
            _cam = gameObject.AddComponent<Camera>();
            _cam.orthographic = true; _cam.orthographicSize = _h / 2f; _cam.depth = 20;
            _cam.clearFlags = CameraClearFlags.SolidColor; _cam.backgroundColor = new Color32(0x6b, 0x44, 0x26, 0xff);
            _cam.nearClipPlane = -10; _cam.farClipPlane = 10;
            transform.localPosition = new Vector3(Off + _w / 2f, -_h / 2f, -5f);
            _root = new GameObject("yard world").transform; _root.SetParent(transform.parent, false); _root.localPosition = new Vector3(Off, 0, 0);
            _au = gameObject.AddComponent<AudioSource>(); _au.playOnAwake = false;
            SvgText.Install();
            Load();
        }

        void OnDestroy()
        {
            EndGame(); ClosePage();
            if (_root != null) Destroy(_root.gameObject);
        }

        // ---------- saving (the page's yardgames.v1, as it is) ----------
        void Load()
        {
            try { _save = YardSave.Parse(PlayerPrefs.GetString(SaveKey, "{}")); } catch (Exception) { _save = new YardSave(); }
            _muted = PlayerPrefs.GetString(SaveKey + ".mute", "0") == "1";
        }
        // after a game: the realm's copy (its bests and plays) kept on the device
        void SyncSave()
        {
            string s = null;
            try { s = YardJs.Saved(); } catch (Exception) { }
            if (string.IsNullOrEmpty(s)) return;
            _save = YardSave.Parse(s);
            PlayerPrefs.SetString(SaveKey, s);
            PlayerPrefs.Save();
        }

        void Sfx(string n)
        {
            if (_muted || !SquishSquad.Audio.Sfx.EffectsOn) return;
            if (!_clips.TryGetValue(n, out var c)) { c = Resources.Load<AudioClip>("Yard/sfx/" + n); _clips[n] = c; }
            if (c != null) _au.PlayOneShot(c, 0.8f);
        }

        // ---------- pieces ----------
        UiPiece P(string id, int order)
        {
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_root, "yard " + id, order); _p[id] = p; }
            p.Visible = true; p.Opacity = 1; p.Order = order; _used.Add(id); return p;
        }
        // (a toast's piece goes with it: each toast has its own)
        void HideUnused()
        {
            List<string> gone = null;
            foreach (var kv in _p)
            {
                if (_used.Contains(kv.Key)) continue;
                if (kv.Key.StartsWith("toast", StringComparison.Ordinal)) (gone ??= new List<string>()).Add(kv.Key); else kv.Value.Visible = false;
            }
            if (gone != null) foreach (var k in gone) { Destroy(_p[k].gameObject); _p.Remove(k); }
        }
        void Show(string id, YardDraw d, int order)
        {
            var p = P(id, order);
            p.SetSvg(d.Svg, (float)(d.W * _gm.G.K), (float)(d.H * _gm.G.K), (float)(d.Margin * _gm.G.K));
            p.Transform = d.M;
            p.Opacity = (float)d.Opacity;
        }

        // ---------- a game ----------
        string _game, _lastPhase; YardGameModel _gm;
        readonly Dictionary<object, Cr> _crs = new Dictionary<object, Cr>();
        readonly Dictionary<string, string> _layerMarkup = new Dictionary<string, string>();
        UiPiece _bg; Texture2D _bgTex;

        sealed class Cr { public GameObject Root, Inner; public CreatureView V; public double S0; public bool Seen; }
        // a rig a game mounted (its host's <svg> on the stand-in), for CreatureView
        sealed class HostRig : IRigFrames, IRigTree
        {
            readonly V _host; readonly RigTree _tree = new RigTree();
            public HostRig(V host) { _host = host; }
            public string FrameAt(float s) { var svg = Dom.FirstSvg(_host); return svg.IsNullish ? null : Dom.Serialize(svg); }
            public SvgNode TreeAt(float s) { var svg = Dom.FirstSvg(_host); return svg.IsNullish ? null : _tree.Build(svg); }
            public void Play(string move) { }
        }

        void Play(string id)
        {
            EndGame(); ClosePage();
            bool ok = false;
            try { ok = NativeRig.Tick() && YardJs.Available && YardJs.Open(id, PlayerKey); }
            catch (Exception e) { Debug.LogWarning("[YardScreen] " + id + ": " + e.Message); }
            if (!ok) { Debug.LogWarning("[YardScreen] the yard games can't run"); OpenPage(); return; }
            _game = id;
            _gm = new YardGameModel(_w / pk, _h / pk);
        }

        void EndGame()
        {
            if (_game == null) return;
            try { YardJs.Close(); } catch (Exception) { }
            SyncSave();
            foreach (var c in _crs.Values) if (c.Root != null) Destroy(c.Root);
            _crs.Clear(); _layerMarkup.Clear();
            _game = null; _gm = null;
            _down = false; _press = null;
        }

        void DrawGame(double now)
        {
            var g = _gm.G;
            var u = YardJs.Ui();
            // the page's wood behind the frame, the frame and its ring
            Backdrop();
            Show("frame", _gm.Frame(u.Phase == "intro" ? "#24103e" : "#eaf7ff"), O - 5);
            // the game's layers bottom to top: its <svg>s (each cut to the frame, every layer's shared defs in each) and
            // its creature layers (each creature by its depth)
            var stage = YardJs.Stage();
            var defs = new System.Text.StringBuilder();
            var svgs = new List<(int i, string inner)>();
            for (int i = 0; i < stage.Count; i++)
                if (YardJs.Tag(stage[i]) == "svg") { var inner = Inner(YardJs.Markup(stage[i])); svgs.Add((i, inner)); foreach (System.Text.RegularExpressions.Match m in Defs.Matches(inner)) defs.Append(m.Groups[1].Value); }
            var seen = new HashSet<object>();
            int order = O;
            for (int i = 0; i < stage.Count; i++)
            {
                var el = stage[i];
                if (YardJs.Tag(el) == "svg")
                {
                    var inner = svgs.Find(x => x.i == i).inner;
                    string id = "layer" + i, key = inner;
                    var p = P(id, order++);
                    if (!_layerMarkup.TryGetValue(id, out var last) || last != key)
                    {
                        _layerMarkup[id] = key;
                        p.SetSvg(StageSvg(defs.ToString(), inner), (float)(780 * g.Su * g.K), (float)(360 * g.Su * g.K), 2);
                    }
                    p.Transform = g.Page * Affine.Translate(g.FX, g.FY);
                    continue;
                }
                if (!YardJs.Has(el, "yg-crl")) continue;
                var hosts = YardJs.Children(el);
                var byZ = new List<(double z, int k, double[] box)>();
                for (int k = 0; k < hosts.Count; k++) { var b = YardJs.Box(hosts[k]); byZ.Add((b[7], k, b)); }
                byZ.Sort((a, b) => a.z != b.z ? a.z.CompareTo(b.z) : a.k.CompareTo(b.k));
                foreach (var (_, k, box) in byZ) { seen.Add(hosts[k].O); PlaceCr(hosts[k], box, order++); }
            }
            foreach (var key in new List<object>(_crs.Keys)) if (!seen.Contains(key)) { if (_crs[key].Root != null) Destroy(_crs[key].Root); _crs.Remove(key); }
            // the intro's poster (its creature a still in it: posterRig)
            if (u.Phase == "intro")
            {
                var art = YardJs.Art();
                var svg = art.IsNullish ? V.Null : YardJs.FirstSvg(art);
                if (!svg.IsNullish)
                {
                    var inner = Inner(YardJs.Markup(svg));
                    var p = P("poster", order++);
                    if (!_layerMarkup.TryGetValue("poster", out var last) || last != inner)
                    {
                        _layerMarkup["poster"] = inner;
                        // (the rig's fabric tile: left out, as the poster's still is drawn here as one picture)
                        p.SetSvg(StageSvg("", Grain.Replace(inner, "data-grain=\"")), (float)(780 * g.Su * g.K), (float)(360 * g.Su * g.K), 2);
                    }
                    p.Transform = g.Page * Affine.Translate(g.FX, g.FY);
                }
            }
            // what Unity draws itself: the top bar, the hint, the games' own pills and buttons, the toasts, the cards
            _gm.Held = Held();
            int n = 0;
            foreach (var d in _gm.Draw(u, now)) Show(Head(d.Key), d, O + 1000 + n++);
            // (the bests kept as soon as the results are up)
            if (u.Phase == "result" && _lastPhase != "result") SyncSave();
            _lastPhase = u.Phase;
        }

        static readonly System.Text.RegularExpressions.Regex Defs = new System.Text.RegularExpressions.Regex("<defs>(.*?)</defs>", System.Text.RegularExpressions.RegexOptions.Singleline);
        static readonly System.Text.RegularExpressions.Regex Grain = new System.Text.RegularExpressions.Regex("href=\"shim-canvas:");
        static string Head(string key) { int i = key.IndexOf('|'); return i < 0 ? key : key.Substring(0, i); }
        static string Inner(string svg) { int a = svg.IndexOf('>') + 1, b = svg.LastIndexOf("</svg>", StringComparison.Ordinal); return a > 0 && b > a ? svg.Substring(a, b - a) : ""; }
        // a stage layer as a piece: 780 x 360 stage units over the frame, cut to its rounded corners
        string StageSvg(string defs, string inner)
        {
            var g = _gm.G;
            return $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{UiSvg.F(780 * g.Su * g.K)}\" height=\"{UiSvg.F(360 * g.Su * g.K)}\" viewBox=\"0 0 780 360\" preserveAspectRatio=\"none\" overflow=\"visible\"><defs>{defs}{_gm.ClipPath("ygFrameClip")}</defs><g clip-path=\"url(#ygFrameClip)\">{inner}</g></svg>";
        }

        void Backdrop()
        {
            if (_bgTex == null)
            {
                var b = Resources.Load<TextAsset>(YardPageLayout.Root + "bg.jpg");
                if (b != null) { _bgTex = new Texture2D(2, 2, TextureFormat.RGB24, false) { name = "yard bg", hideFlags = HideFlags.HideAndDontSave }; _bgTex.LoadImage(b.bytes, true); Resources.UnloadAsset(b); }
            }
            if (_bg == null) _bg = UiPiece.Create(_root, "yard bg", O - 10);
            _bg.Visible = _bgTex != null;
            if (_bgTex != null) { _bg.SetPicture(_bgTex, _w / pk, _h / pk); _bg.Transform = Affine.Identity; }
        }

        // a creature the game mounted: its host's box (% of the stage), its turn about (ox, oy) % of its box, drawn by
        // CreatureView from its rig's own tree on the stand-in
        void PlaceCr(V host, double[] b, int order)
        {
            var g = _gm.G;
            double unitPx = g.Su * g.K * pk;
            double S = 780 * b[2] / 100, L = 780 * b[0] / 100, T = 360 * b[1] / 100, px = L + b[5] / 100 * S, py = T + b[6] / 100 * S;
            if (!_crs.TryGetValue(host.O, out var o))
            {
                o = new Cr { S0 = Math.Max(10, S) };
                o.Root = new GameObject("yard creature"); o.Root.transform.SetParent(_root, false);
                o.Inner = new GameObject("inner"); o.Inner.transform.SetParent(o.Root.transform, false);
                float s = (float)(o.S0 * unitPx);
                o.V = CreatureView.Create(o.Inner.transform, new HostRig(host), new Rect(0, 0, s, s), order);
                _crs[host.O] = o;
            }
            bool show = b[8] == 0 && b[9] == 0 && S > 0;
            o.Root.SetActive(show); if (!show) return;
            var at = g.Stage.Apply(new Vec2(px, py));
            o.Root.transform.localPosition = new Vector3((float)(at.X * pk), (float)-(at.Y * pk), 0);
            o.Root.transform.localRotation = Quaternion.Euler(0, 0, (float)-b[4]);
            float k = (float)(S / o.S0); o.Root.transform.localScale = new Vector3(k, k, 1);
            o.Inner.transform.localPosition = new Vector3((float)((L - px) / k * unitPx), (float)(-(T - py) / k * unitPx), 0);
            o.V.Order = order;
        }

        // ---------- the loop ----------
        void Update()
        {
            if (_root == null) return;
            double now = Now;
            _used.Clear();
            if (Input.GetKeyDown(KeyCode.Escape)) { if (_game != null) { Sfx("tap"); EndGame(); OpenPage(); } else { Exit(); return; } }
            if (_game == null)
            {
                PageInput(now);
                if (_game == null) { if (_bg != null) _bg.Visible = false; HideUnused(); DrawPage(now); return; }
            }
            else GameInput();
            // the one clock (the game's loop and its creatures), then what it says
            if (!NativeRig.Tick()) { EndGame(); OpenPage(); return; }
            foreach (var s in YardJs.Sfx()) Sfx(s);
            if (YardJs.Closed) { EndGame(); OpenPage(); HideUnused(); DrawPage(now); return; }
            DrawGame(now);
            HideUnused();
        }
        void Exit() { OnExit?.Invoke(); Destroy(gameObject); }

        // ---------- the game's touches ----------
        // a press on one of Unity's controls (the back orbs, PLAY, the options, the results' buttons, a game's own
        // button) or on the game itself (its input layer, in stage units)
        bool _down; string _press; Vector2 _downAt; double _lx, _ly; bool _moved;
        string Held()
        {
            if (!_down || _press == null || _press == "game") return null;
            if (_press.StartsWith("btn:", StringComparison.Ordinal)) return _press;   // (a game's own button fired on the press: held while the finger stays)
            return !_moved && _gm.Hit(_lx, _ly) == _press ? _press : null;
        }
        void GameInput()
        {
            bool down = Input.GetMouseButtonDown(0), up = Input.GetMouseButtonUp(0), held = Input.GetMouseButton(0);
            Vector2 pos = Input.mousePosition;
            if (Input.touchCount > 0) { var t = Input.GetTouch(0); pos = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up; }
            double xdp = pos.x / pk, ydp = (_h - pos.y) / pk;
            var (sx, sy) = _gm.G.ToStage(xdp, ydp);
            if (down)
            {
                _down = true; _moved = false; _downAt = pos; _lx = xdp; _ly = ydp;
                _press = _gm.Hit(xdp, ydp);
                if (_press != null && _press.StartsWith("btn:")) { YardJs.Press(int.Parse(_press.Substring(4))); return; }
                if (_press == null) { _press = "game"; YardJs.Pointer("pointerdown", sx, sy); }
                return;
            }
            if (!_down) return;
            _lx = xdp; _ly = ydp;
            if ((pos - _downAt).magnitude > 10 * pk) _moved = true;
            if (held && !up) { if (_press == "game") YardJs.Pointer("pointermove", sx, sy); return; }
            _down = false;
            var pr = _press; _press = null;
            if (pr == "game") { YardJs.Pointer("pointerup", sx, sy); return; }
            if (pr == null || pr.StartsWith("btn:") || _moved || _gm.Hit(xdp, ydp) != pr) return;
            if (pr == "back") YardJs.Click("back");
            else if (pr == "iback") YardJs.Click("iback");
            else if (pr == "play") YardJs.Click("play");
            else if (pr.StartsWith("opt:")) YardJs.Click("opt", int.Parse(pr.Substring(4)));
            else if (pr.StartsWith("res:")) YardJs.Click("res", int.Parse(pr.Substring(4)));
        }

        // ---------- the page of the games ----------
        string _player; Func<string, bool> _open; Func<string, string> _need;
        static YardPageLayout _layout;
        YardPageModel _page; CharactersPageView _pv;
        readonly Dictionary<string, string> _crSvg = new Dictionary<string, string>();
        readonly Dictionary<string, string> _opp = new Dictionary<string, string>();
        void OpenPage()
        {
            if (_page != null) return;
            if (_layout == null) { var t = Resources.Load<TextAsset>(YardPageLayout.Root + "yardpage"); if (t == null) return; _layout = JsonUtility.FromJson<YardPageLayout>(t.text); Resources.UnloadAsset(t); }
            UiFont.ReadJson ??= n => Resources.Load<TextAsset>("Fonts/" + n)?.text;
            UiFont.ParseJson ??= j => JsonUtility.FromJson<UiFontData>(j);
            _page = new YardPageModel(_layout, _w, _h)
            {
                Open = id => _open == null || _open(id),
                Best = id => _save.Best.TryGetValue(id, out var b) ? b : 0,
                Creature = PosterCreature,
                Scroll = _pageScroll,
            };
            _pv = new CharactersPageView(YardPageLayout.Root, _root, O);
        }
        double _pageScroll;
        void ClosePage() { if (_page != null) _pageScroll = _page.Scroll; _page = null; _pv?.Dispose(); _pv = null; }
        void DrawPage(double now)
        {
            if (_page == null) OpenPage();
            if (_page == null) { Exit(); return; }   // (not exported: tools/unity/house/export-yardpage.mjs)
            _pv.Show(_page.Draw(now));
        }

        // a creature in a poster (yg-intros.js posterRig): the player's rig (the opponent's: one of the yard's pool) posed
        // as the poster says (its ext channels, its yaw), let settle ~0.9 s and kept as a still. develop draws it in the
        // rig's look 3 (the bold ink line), which the Unity rigs don't have; nor the ping-pong paddle on its paw.
        string PosterCreature(string game, int i, bool grey)
        {
            string ck = game + "|" + i + "|" + grey;
            if (_crSvg.TryGetValue(ck, out var done)) return done;
            var g = Array.Find(_layout.games, x => x.id == game); var sl = g.slots[i];
            string key = PlayerKey;
            if (sl.who == "opp")
            {
                if (!_opp.TryGetValue(game, out key)) { var pool = new List<string>(_roster); pool.Remove(PlayerKey); key = pool.Count > 0 ? pool[UnityEngine.Random.Range(0, pool.Count)] : null; _opp[game] = key; }
            }
            string svg = null;
            var rig = key != null ? Rigs.For(key) : null;
            if (rig != null)
            {
                try
                {
                    if (rig is IHouseRig hr)
                    {
                        hr.Fidgets(false);
                        var e = new Dictionary<string, double>(); for (int k = 0; k < (sl.poseK?.Length ?? 0); k++) e[sl.poseK[k]] = sl.poseV[k];
                        hr.Ext(e); if (sl.yaw != 0) hr.Yaw(sl.yaw);
                    }
                    for (int f = 0; f <= 9; f++) svg = rig.FrameAt(f * 0.1f);
                }
                catch (Exception) { svg = null; }
                (rig as IDisposable)?.Dispose();
            }
            if (svg != null)
            {
                // the rig's own svg in the slot's box: (-w/2, -0.93 w), w x w
                int a = svg.IndexOf("<svg", StringComparison.Ordinal), b = a >= 0 ? svg.IndexOf('>', a) : -1;
                if (b > a)
                {
                    var head = System.Text.RegularExpressions.Regex.Replace(svg.Substring(a, b - a), "\\s(x|y|width|height|overflow)=\"[^\"]*\"", "");
                    svg = head + $" x=\"{UiSvg.F(-sl.w / 2)}\" y=\"{UiSvg.F(-sl.w * 0.93)}\" width=\"{UiSvg.F(sl.w)}\" height=\"{UiSvg.F(sl.w)}\" overflow=\"visible\"" + svg.Substring(b);
                    if (grey) svg = YardPageModel.Greyed(svg);
                }
                else svg = null;
            }
            _crSvg[ck] = svg;
            return svg;
        }

        // the page's touches: the back orb leaves, a card plays its game (a locked one says what to buy), the row drags
        bool _pDown; string _pHit; YardPageModel.Hit _pKind;
        void PageInput(double now)
        {
            if (_page == null) return;
            bool down = Input.GetMouseButtonDown(0), up = Input.GetMouseButtonUp(0), held = Input.GetMouseButton(0);
            Vector2 pos = Input.mousePosition;
            if (Input.touchCount > 0) { var t = Input.GetTouch(0); pos = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up; }
            double px = pos.x, py = _h - pos.y;
            float wh = Input.mouseScrollDelta.y; if (wh != 0) _page.Wheel(-wh * 100);
            if (down) { _pDown = true; _pKind = _page.HitTest(px, py, out _pHit); _page.Down(px, now); PageHeld(px, py); return; }
            if (!_pDown) return;
            if (held && !up) { _page.Move(px, now); PageHeld(px, py); return; }
            _pDown = false;
            _page.Held = YardPageModel.Hit.None; _page.HeldGame = null;
            if (_page.Up(now)) return;   // (a drag isn't a tap)
            var k = _page.HitTest(px, py, out var id);
            if (k != _pKind || id != _pHit) return;
            if (k == YardPageModel.Hit.Back) { Sfx("tap"); Exit(); return; }
            if (k != YardPageModel.Hit.Card || !NAMES.ContainsKey(id)) return;
            if (!_page.Open(id)) { _page.Toast(_need?.Invoke(id) ?? NAMES[id] + " opens with the Backyard", now); return; }
            Sfx("pop"); Play(id);
        }

        // what's held shrinks while the finger stays on it (not once the row is dragged)
        void PageHeld(double px, double py)
        {
            var on = _page.HitTest(px, py, out var id);
            bool still = _pKind != YardPageModel.Hit.None && on == _pKind && id == _pHit && !_page.Dragged;
            _page.Held = still ? on : YardPageModel.Hit.None; _page.HeldGame = still ? id : null;
        }
    }
}
