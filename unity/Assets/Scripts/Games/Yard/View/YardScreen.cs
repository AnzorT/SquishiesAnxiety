// The Yard Games (HOUSE_PORT_PLAN.md stage 11; Yard Mini Games.dc.html + yard-games.js): the page of the seven games
// (develop: the menu's games page in yard mode, YardPageModel.cs: wide poster cards dragged sideways, a game locked
// until one of its toys is bought in the Backyard's catalog) or a game in one phone-shaped frame in the middle of the
// screen (the games are still the portrait ones of the Nov 13 prototype: develop's landscape versions, yard-games.js
// v4-v6, aren't ported yet): its layers (bg, the creatures behind, mid, the creatures, fg; Games/Yard), the top
// bar (back, the name, the score and time pills), the hint, the games' own pills and buttons, the toasts, the intro
// card (how to play, the options) and the results card (stars, the best, the coins preview). Opened from the
// backyard's Yard Games button (HouseScreen); the bests are kept on the device (the page's localStorage yardgames.v1).
//   var y = YardScreen.Create(parent, rosterKeys, nameOf, player, open, need);   y.OnExit = ...;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Creatures;
using SquishSquad.House;
using SquishSquad.House.View;
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
        const float Off = 20000, cq = 3.6f, W = 360, H = 640;
        const string SaveKey = "yardgames.v1";
        static float pk => UiPiece.PxPerDp;
        static readonly Func<double, double> EaseOut = Easing.Bezier(0, 0, 0.58, 1), Pop = Easing.Bezier(0.2, 1.4, 0.4, 1), StarPop = Easing.Bezier(0.2, 1.6, 0.4, 1);

        Camera _cam; Transform _root;
        float _w, _h, _fx, _fy, _fw, _fh, _K;
        readonly YardSave _save = new YardSave();
        bool _muted;
        readonly Dictionary<string, string> _opts = new Dictionary<string, string>();
        static readonly Type[] Games = { typeof(YardHoop), typeof(YardSoccer), typeof(YardHop), typeof(YardTramp), typeof(YardSlide), typeof(YardCorn), typeof(YardPong) };
        readonly List<YardGame> _defs = new List<YardGame>();

        // what's showing
        YardGame _g; YardCtx _c; string _ov; double _ovT0; double _t0;
        (string title, int stars, bool nb, int best, int coins) _res; string _resSub;
        readonly Dictionary<string, int> _ver = new Dictionary<string, int>();
        readonly List<(string id, float x, float y, float w, float h)> _hits = new List<(string, float, float, float, float)>();

        // pieces
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly Dictionary<string, string> _drawn = new Dictionary<string, string>();
        readonly HashSet<string> _used = new HashSet<string>();
        const int O = 200;

        sealed class Cr { public YardCreature C; public GameObject Root, Inner; public CreatureView V; public IHouseRig Live; public double S0; public UiPiece Still; }
        readonly List<Cr> _crs = new List<Cr>();
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

        void Start()
        {
            _w = Screen.width; _h = Screen.height;
            _cam = gameObject.AddComponent<Camera>();
            _cam.orthographic = true; _cam.orthographicSize = _h / 2f; _cam.depth = 20;
            _cam.clearFlags = CameraClearFlags.SolidColor; _cam.backgroundColor = new Color32(0xbf, 0xe6, 0xff, 0xff);
            _cam.nearClipPlane = -10; _cam.farClipPlane = 10;
            transform.localPosition = new Vector3(Off + _w / 2f, -_h / 2f, -5f);
            _root = new GameObject("yard world").transform; _root.SetParent(transform.parent, false); _root.localPosition = new Vector3(Off, 0, 0);
            _fh = _h - 24; _fw = _fh * 0.5625f; if (_fw > _w - 24) { _fw = _w - 24; _fh = _fw / 0.5625f; }
            _fx = (_w - _fw) / 2; _fy = (_h - _fh) / 2; _K = _fw / W;
            _au = gameObject.AddComponent<AudioSource>(); _au.playOnAwake = false;
            if (YardCreature.Walker == null) try { YardCreature.Walker = new HouseWalk(HouseRoomView.Res("walk")); } catch (Exception) { }
            foreach (var t in Games) _defs.Add((YardGame)Activator.CreateInstance(t));
            Load();
            if (_player != null && _roster.Contains(_player)) _save.Player = _player;
            El.TextHook = TextEl;
            Hub();
        }

        void OnDestroy()
        {
            EndGame(); ClosePage();
            if (_root != null) Destroy(_root.gameObject);
        }

        // ---------- saving ----------
        void Load()
        {
            try
            {
                var o = (JObj)HouseJson.Parse(PlayerPrefs.GetString(SaveKey, "{}"));
                if (o.Obj("best") is JObj b) foreach (var k in b.Keys) _save.Best[k] = (int)b.Num(k);
                if (o.Obj("plays") is JObj p) foreach (var k in p.Keys) _save.Plays[k] = (int)p.Num(k);
                _save.Player = o.Str("player");
            }
            catch (Exception) { }
            _muted = PlayerPrefs.GetString(SaveKey + ".mute", "0") == "1";
            if (_save.Player == null || !_roster.Contains(_save.Player)) _save.Player = _roster.Contains("mittens") ? "mittens" : _roster[0];
        }
        void Save()
        {
            var b = new JObj(); foreach (var kv in _save.Best) b[kv.Key] = (double)kv.Value;
            var p = new JObj(); foreach (var kv in _save.Plays) p[kv.Key] = (double)kv.Value;
            PlayerPrefs.SetString(SaveKey, HouseJson.Stringify(new JObj { ["best"] = b, ["plays"] = p, ["player"] = _save.Player }));
            PlayerPrefs.Save();
        }

        void Sfx(string n)
        {
            if (_muted || !SquishSquad.Audio.Sfx.EffectsOn) return;
            if (!_clips.TryGetValue(n, out var c)) { c = Resources.Load<AudioClip>("Yard/sfx/" + n); _clips[n] = c; }
            if (c != null) _au.PlayOneShot(c, 0.8f);
        }

        // ---------- pieces ----------
        static string F(double v) => UiSvg.F(v);
        UiPiece P(string id, int order)
        {
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_root, "yard " + id, order); _p[id] = p; }
            p.Visible = true; p.Opacity = 1; p.Order = order; _used.Add(id); return p;
        }
        /// <summary>A piece drawn in stage units: the region (ux, uy) uw x uh of the frame, redrawn when `key` changes.</summary>
        UiPiece Draw(string id, string key, float ux, float uy, float uw, float uh, int order, Func<UiSvg, UiSvg> draw, float margin = 12)
        {
            var p = P(id, order);
            if (!_drawn.TryGetValue(id, out var k0) || k0 != key)
            {
                float dw = uw * _K / pk, dh = uh * _K / pk;
                var u = draw(new UiSvg(uw, uh));
                p.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(dw)}\" height=\"{F(dh)}\" viewBox=\"0 0 {F(uw)} {F(uh)}\" overflow=\"visible\">{u.Markup}</svg>", dw, dh, margin * _K / pk);
                _drawn[id] = key;
            }
            p.Transform = At(ux, uy);
            return p;
        }
        Affine At(double ux, double uy) => Affine.Translate((_fx + ux * _K) / pk, (_fy + uy * _K) / pk);
        /// <summary>A piece drawn at (x, y) scaled s about the stage point (cx, cy) (the bumps, the pops).</summary>
        Affine Around(double x, double y, double cx, double cy, double s) => At(cx, cy) * Affine.ScaleBy(s, s) * Affine.Translate(-(cx - x) * _K / pk, -(cy - y) * _K / pk);
        void HideUnused() { foreach (var kv in _p) if (!_used.Contains(kv.Key)) kv.Value.Visible = false; }

        static TextStyle TS(string font, float size, string col, float lh = 0, float ls = 0) => new TextStyle { Font = font, Size = size * cq, Color = col, LineHeight = lh > 0 ? size * cq * lh : 0, LetterSpacing = ls };
        const string Fred = "Fredoka_700Bold", Nun7 = "Nunito_700Bold", Nun8 = "Nunito_800ExtraBold";
        static List<string> Wrap(string s, TextStyle t, float maxW)
        {
            var lines = new List<string>(); string cur = "";
            foreach (var w in (s ?? "").Split(' '))
            {
                var tr = cur.Length == 0 ? w : cur + " " + w;
                if (cur.Length > 0 && UiSvg.Width(tr, t) > maxW) { lines.Add(cur); cur = w; } else cur = tr;
            }
            if (cur.Length > 0) lines.Add(cur);
            return lines;
        }
        static float Lh(TextStyle t) => t.LineHeight > 0 ? t.LineHeight : UiSvg.LineBox(t);
        static string Mix(string a, double pa, string b)
        {
            Color ca, cb; ColorUtility.TryParseHtmlString(a, out ca); ColorUtility.TryParseHtmlString(b, out cb);
            var c = Color.Lerp(cb, ca, (float)pa); return "#" + ColorUtility.ToHtmlStringRGB(c);
        }
        static BoxStyle Pill(string bg, string shadow = null, float sy = 0.8f) => new BoxStyle { Background = bg, Radius = 999, Shadows = shadow != null ? new[] { new Shadow(shadow, 0, sy * cq, 0) } : null };
        static string Star(float cx, float cy, float r, string fill)
        {
            var sb = new StringBuilder("<path d=\"");
            for (int i = 0; i < 10; i++) { double a = -Math.PI / 2 + i * Math.PI / 5, rr = i % 2 == 0 ? r : r * 0.45; sb.Append(i == 0 ? "M" : "L").Append(F(cx + Math.Cos(a) * rr)).Append(' ').Append(F(cy + Math.Sin(a) * rr)); }
            return sb.Append("Z\" fill=\"").Append(fill).Append("\" stroke=\"").Append(fill).Append("\" stroke-width=\"").Append(F(r * 0.12)).Append("\" stroke-linejoin=\"round\"/>").ToString();
        }
        /// <summary>An icon's SVG fitted (sliced) into the box: its viewBox cropped to the box's shape.</summary>
        static string Icon(string svg, float x, float y, float w, float h)
        {
            if (string.IsNullOrEmpty(svg)) return "";
            var m = System.Text.RegularExpressions.Regex.Match(svg, "viewBox=\"([\\d.\\s-]+)\"");
            var vb = m.Success ? Array.ConvertAll(m.Groups[1].Value.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), s => double.Parse(s, CultureInfo.InvariantCulture)) : new double[] { 0, 0, 120, 84 };
            double vw = vb[2], vh = vb[3], ar = w / h;
            if (vw / vh > ar) { double nw = vh * ar; vb[0] += (vw - nw) / 2; vw = nw; } else { double nh = vw / ar; vb[1] += (vh - nh) / 2; vh = nh; }
            int a = svg.IndexOf('>'), b = svg.LastIndexOf("</svg>", StringComparison.Ordinal);
            var inner = a >= 0 && b > a ? svg.Substring(a + 1, b - a - 1) : svg;
            return $"<svg x=\"{F(x)}\" y=\"{F(y)}\" width=\"{F(w)}\" height=\"{F(h)}\" viewBox=\"{F(vb[0])} {F(vb[1])} {F(vw)} {F(vh)}\">{inner}</svg>";
        }

        // the games' own <text>: glyph paths (their stroke under the fill: paint-order stroke)
        StringBuilder _tdefs = new StringBuilder(); readonly Dictionary<string, string> _tids = new Dictionary<string, string>();
        string TextEl(El e)
        {
            string fam = e.Get("font-family") ?? "Fredoka", wg = e.Get("font-weight") ?? "700";
            string font = fam.StartsWith("Nunito") ? (wg == "900" ? "Nunito_900Black" : wg == "800" ? Nun8 : Nun7) : (wg == "500" ? "Fredoka_500Medium" : wg == "600" ? "Fredoka_600SemiBold" : Fred);
            float Num(string k, float d) => float.TryParse(e.Get(k), NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : d;
            var f = UiFont.Get(font); float size = Num("font-size", 16), x = Num("x", 0), y = Num("y", 0);
            string txt = e.TextContent(); if (txt.Length == 0) return "";
            float w = f.BoxWidth(txt, size, 0); var an = e.Get("text-anchor");
            if (an == "middle") x -= w / 2; else if (an == "end") x -= w;
            var sb = new StringBuilder("<g");
            foreach (var k in new[] { "transform", "opacity" }) if (e.Get(k) != null) sb.Append(' ').Append(k).Append("=\"").Append(e.Get(k)).Append('"');
            sb.Append('>');
            string fill = e.Get("fill") ?? "#000", st = e.Get("stroke");
            if (st != null && st != "none")
                sb.Append("<g stroke=\"").Append(st).Append("\" stroke-width=\"").Append(F(Num("stroke-width", 1) * f.UnitsPerEm / size)).Append("\" stroke-linejoin=\"round\">").Append(f.Svg(txt, x, y, size, 0, st, _tdefs, _tids)).Append("</g>");
            sb.Append(f.Svg(txt, x, y, size, 0, fill, _tdefs, _tids)).Append("</g>");
            return sb.ToString();
        }
        const string Clip = "<clipPath id=\"ygFrame\"><rect width=\"360\" height=\"640\" rx=\"30\"/></clipPath>";
        void Layer(string id, El el, int order)
        {
            var p = P(id, order);
            if (!_ver.TryGetValue(id, out var v) || v != el.Ver || !_drawn.ContainsKey(id))
            {
                _ver[id] = el.Ver; _tdefs = new StringBuilder(); _tids.Clear();
                var body = new StringBuilder(); el.Write(body);
                float dw = W * _K / pk, dh = H * _K / pk;
                p.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{F(dw)}\" height=\"{F(dh)}\" viewBox=\"0 0 360 640\"><defs>{YK.Defs}{Clip}{_tdefs}</defs><g clip-path=\"url(#ygFrame)\">{body}</g></svg>", dw, dh, 2);
                _drawn[id] = "v";
            }
            p.Transform = At(0, 0);
        }

        // ---------- creatures ----------
        Cr MakeCr(YardCreature c, Transform parent = null)
        {
            var o = new Cr { C = c, S0 = Math.Max(10, c.Size) };
            o.Root = new GameObject("yard creature " + c.Key); o.Root.transform.SetParent(parent ?? _root, false);
            o.Inner = new GameObject("inner"); o.Inner.transform.SetParent(o.Root.transform, false);
            float s = (float)(o.S0 * _K);
            var rig = Rigs.For(c.Key);
            if (rig != null)
            {
                o.V = CreatureView.Create(o.Inner.transform, rig, new Rect(-s / 2, -s * 0.93f, s, s), O + 20);
                o.Live = rig as IHouseRig; o.Live?.Fidgets(false);
                o.V.Play(c.Move);
                c.OnPlay = n => o.V.Play(n);
            }
            else
            {
                var tex = Resources.Load<Texture2D>("Stack/art/" + c.Key);
                if (tex != null) { o.Still = UiPiece.Create(_root, "yard still", O + 20); o.Still.SetPicture(tex, (float)(o.S0 * 0.8 * _K / pk), (float)(o.S0 * 0.8 * _K / pk)); }
            }
            return o;
        }
        void PlaceCr(Cr o, int order)
        {
            var c = o.C; double S = c.Size, L = c.X - S / 2, T = c.Y - S * 0.93, px = L + c.Ox / 100 * S, py = T + c.Oy / 100 * S;
            bool show = !c.Hidden && !c.Gone;
            if (o.V != null)
            {
                o.Root.SetActive(show); if (!show) return;
                o.Root.transform.localPosition = new Vector3((float)(_fx + px * _K), (float)-(_fy + py * _K), 0);
                o.Root.transform.localRotation = Quaternion.Euler(0, 0, (float)-c.R);
                float k = (float)(S / o.S0); o.Root.transform.localScale = new Vector3(k, k, 1);
                o.Inner.transform.localPosition = new Vector3((float)((c.X - px) / k * _K), (float)(-(c.Y - py) / k * _K), 0);
                o.V.GetComponent<MeshRenderer>().sortingOrder = order;
                o.Live?.Ext(c.E); o.Live?.Yaw(c.YawDeg);
            }
            else if (o.Still != null)
            {
                o.Still.Visible = show; o.Still.Order = order;
                o.Still.Transform = At(c.X, c.Y) * Affine.Rotate(c.R) * Affine.ScaleBy(S / o.S0, S / o.S0) * Affine.Translate(-o.S0 * 0.4 * _K / pk, -o.S0 * 0.8 * _K / pk);
            }
        }
        void KillCr(Cr o) { if (o.Root != null) Destroy(o.Root); if (o.Still != null) Destroy(o.Still.gameObject); }

        // ---------- the hub and a game ----------
        void Hub() { EndGame(); _g = null; _c = null; _ov = null; }
        void EndGame()
        {
            if (_g != null) try { _g.Destroy(); } catch (Exception) { }
            foreach (var o in _crs) KillCr(o); _crs.Clear();
            foreach (var id in new[] { "bg", "mid", "fg" }) { _drawn.Remove(id); _ver.Remove(id); }
        }
        void Play(YardGame def)
        {
            EndGame(); ClosePage();
            _g = (YardGame)Activator.CreateInstance(def.GetType());
            if (_opts.TryGetValue(_g.Id ?? def.Id, out var op)) _g.Opt = op;
            var key = _save.Player;
            _c = new YardCtx(_g, key, _nameOf(key)) { Sfx = Sfx, NameOf = _nameOf, Roster = () => _roster, CreatureMade = c => _crs.Add(MakeCr(c)) };
            _c.Finished = Results;
            _c.timer(_g.Dur > 0 ? _g.Dur + "s" : ""); _c.HintTxt = _g.Hint ?? "";
            _g.Make(_c);
            if (_g.Opt == null && _g.Options != null && _g.Options.Length > 0) _g.Opt = _g.Options[0].id;
            _ov = "intro"; _ovT0 = Now; _t0 = Now;
        }
        void Results(Dictionary<string, object> extra)
        {
            extra.TryGetValue("title", out var t); extra.TryGetValue("sub", out var s);
            _res = _save.Result(_g, _c.score, t as string); Save();
            _resSub = (s is string ss && ss.Length > 0 ? ss + " · " : "") + (_res.nb ? "New best!" : "Best " + _res.best);
            if (_res.nb || _res.stars >= 2) Sfx("win");
            _ov = "res"; _ovT0 = Now;
            try { _g.Celebrate(_res.stars); } catch (Exception) { }
        }
        void Begin() { _ov = null; if (_g.Opt != null) _opts[_g.Id] = _g.Opt; _c.Begin(); }

        // ---------- the loop ----------
        void Update()
        {
            if (_root == null) return;
            double now = Now;
            if (Input.GetKeyDown(KeyCode.Escape)) { if (_g != null) { Hub(); return; } Exit(); return; }
            if (_g == null) { PageInput(now); if (_g == null) { _used.Clear(); HideUnused(); DrawPage(now); return; } }
            else HandleInput(now);
            var was = _held; _held = Held();
            if (was != null && was != _held && was.StartsWith("btn:")) _btnUp[was] = now;
            _used.Clear(); _hits.Clear();
            Backdrop();
            if (_g != null) DrawGame(now);
            HideUnused();
        }
        void Exit() { Save(); OnExit?.Invoke(); Destroy(gameObject); }

        void Backdrop()
        {
            Draw("screen", "s", -_fx / _K, -_fy / _K, _w / _K, _h / _K, O - 10, u => u.Box(0, 0, u.W, u.H, new BoxStyle { Gradient = new[] { "#8fd0ff", "#c4e9ff", "#d9f2c6", "#a8dc8a" }, GradientStops = new[] { 0f, 0.45f, 0.78f, 1f } }), 0);
            Draw("frame", "f", 0, 0, W, H, O - 9, u => u.Box(0, 0, W, H, new BoxStyle { Background = "#eaf7ff", Radius = 30, Shadows = new[] { new Shadow("#ffffff", 0, 0, 0, 6), new Shadow("#c9b6f2", 0, 0, 0, 9), new Shadow("rgba(60,30,110,0.28)", 0, 18, 40) } }), 60);
        }

        void DrawGame(double now)
        {
            var c = _c;
            if (_ov == null) c.Step(Math.Min(0.05, Time.unscaledDeltaTime));
            Layer("bg", c.bg, O);
            Layer("mid", c.mid, O + 3);
            Layer("fg", c.fg, O + 60);
            foreach (var o in _crs) PlaceCr(o, o.C.Behind ? O + 1 : O + 10 + Mathf.Clamp(Mathf.RoundToInt((float)o.C.Z), -5, 45));
            Hud(now);
            if (_ov == "intro") Intro(now); else if (_ov == "res") ResultCard(now);
        }

        void Hud(double now)
        {
            var c = _c; int H0 = O + 70;
            float barH = 15.2f * cq;
            bool backDown = _held == "back";
            Draw("top", _g.Id + (backDown ? "|p" : ""), 0, 0, W, barH, H0, u =>
            {
                u.Box(0, 0, W, barH, new BoxStyle { Gradient = new[] { "rgba(255,255,255,0.85)", "rgba(255,255,255,0)" }, Radii = new[] { 30f, 30f, 0, 0 } });
                float bx = 3 * cq, by = 2.6f * cq, bs = 10 * cq;
                if (backDown) u.Open(PressG(bx + bs / 2, by + bs / 2));
                u.Box(bx, by, bs, bs, new BoxStyle { Background = "#ffffff", Radius = 999, Shadows = new[] { new Shadow("#c9b6f2", 0, 0.8f * cq, 0) } });
                u.Raw($"<path d=\"M{F(bx + bs * 0.56)} {F(by + bs * 0.3)}L{F(bx + bs * 0.4)} {F(by + bs * 0.5)}L{F(bx + bs * 0.56)} {F(by + bs * 0.7)}\" fill=\"none\" stroke=\"#6a2fb0\" stroke-width=\"{F(1.3 * cq)}\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>");
                if (backDown) u.Close();
                var t = TS(Fred, 5.2f, "#4a1a73", 1.1f); u.Text(_g.Name, 15 * cq, by + bs / 2 - Lh(t) / 2, t);
                return u;
            });
            _hits.Add(("back", 3 * cq, 2.6f * cq, 10 * cq, 10 * cq));
            // the pills, right to left: the time, the score
            float pr = W - 3 * cq, cy = 7.6f * cq, ph = 7.2f * cq;
            var pt = TS(Fred, 4.4f, "#4a1a73", 1);
            if (!string.IsNullOrEmpty(c.TimerTxt))
            {
                string col = c.Hurry ? "#ff7a8a" : "#ffffff", tc = c.Hurry ? "#ffffff" : "#4a1a73";
                float w = Math.Max(11 * cq, UiSvg.BoxWidth(c.TimerTxt, pt) + 5.6f * cq);
                Draw("time", c.TimerTxt + col, pr - w, cy - ph / 2, w, ph, H0 + 1, u => u.Box(0, 0, w, ph, Pill(col, "rgba(106,47,176,0.25)")).Text(c.TimerTxt, 0, (ph - Lh(pt)) / 2, TS(Fred, 4.4f, tc, 1), w, 0.5f));
                pr -= w + 1.6f * cq;
            }
            {
                string s = c.score.ToString(CultureInfo.InvariantCulture);
                float w = Math.Max(11 * cq, UiSvg.BoxWidth(s, pt) + 5.6f * cq);
                var p = Draw("score", s, pr - w, cy - ph / 2, w, ph, H0 + 1, u => u.Box(0, 0, w, ph, Pill("#ffe36e", "rgba(106,47,176,0.25)")).Text(s, 0, (ph - Lh(pt)) / 2, pt, w, 0.5f));
                double bu = (c.Now - c.ScoreBumpAt) / 350;
                if (bu >= 0 && bu < 1) { double sc = bu < 0.4 ? 1 + 0.25 * EaseOut(bu / 0.4) : 1.25 - 0.25 * EaseOut((bu - 0.4) / 0.6); p.Transform = Around(pr - w, cy - ph / 2, pr - w / 2, cy, sc); }
            }
            // the hint
            if (!string.IsNullOrEmpty(c.HintTxt))
            {
                var ht = TS(Nun8, 3.6f, "#ffffff", 1.25f); ht.Shadows = new[] { new Shadow("rgba(40,60,20,0.6)", 0, 1, 0), new Shadow("rgba(40,60,20,0.45)", 0, 0, 6) };
                var lines = Wrap(c.HintTxt, ht, W - 8 * cq); float lh = Lh(ht), hh = lines.Count * lh;
                Draw("hint", c.HintTxt, 4 * cq, H - 3.5f * cq - hh, W - 8 * cq, hh, H0, u => { for (int i = 0; i < lines.Count; i++) u.Text(lines[i], 0, i * lh, ht, u.W, 0.5f); return u; });
            }
            // the games' own: the marks, the badge, the centre pill, the buttons
            if (c.Dots != null && c.Dots.Count > 0)
            {
                var key = new StringBuilder(); foreach (var d in c.Dots) key.Append(d.ch).Append(d.col);
                var dt = new TextStyle { Font = Fred, Size = 14, Color = "#4a1a73" };
                float w = 20; foreach (var d in c.Dots) w += UiSvg.BoxWidth(d.ch, dt) + 6; w -= 6; float h = 12 + Lh(dt);
                Draw("dots", key.ToString(), W / 2 - w / 2, 80, w, h, H0 + 1, u =>
                {
                    u.Box(0, 0, w, h, Pill("#ffffff", "rgba(106,47,176,0.25)")); float x = 10;
                    foreach (var d in c.Dots) { var s2 = new TextStyle { Font = Fred, Size = 14, Color = d.col }; u.Text(d.ch, x, 6, s2); x += UiSvg.BoxWidth(d.ch, s2) + 6; }
                    return u;
                });
            }
            void PillAt(string id, string txt, float size, float padY, float padX, float? right, float? cx)
            {
                if (string.IsNullOrEmpty(txt)) return;
                var t = new TextStyle { Font = Fred, Size = size, Color = "#4a1a73", LineHeight = size };
                float w = UiSvg.BoxWidth(txt, t) + 2 * padX, h = size + 2 * padY, x = right != null ? W - right.Value - w : cx.Value - w / 2;
                Draw(id, txt, x, 80, w, h, H0 + 1, u => u.Box(0, 0, w, h, Pill("#ffffff", "rgba(106,47,176,0.25)")).Text(txt, 0, padY, t, w, 0.5f));
            }
            PillAt("badge", c.Badge, 13, 5, 9, 3 * 3.6f, null);
            PillAt("cpill", c.CenterPill, 14, 6, 12, null, W / 2);
            if (c.Buttons != null && c.Buttons.Count > 0)
            {
                int n = c.Buttons.Count; float gap = W * 0.03f, avail = W * 0.92f, bw = Math.Min(W * 0.92f * 0.3f, (avail - gap * (n - 1)) / n), bh = bw / 1.65f;
                float x0 = W / 2 - (bw * n + gap * (n - 1)) / 2, y0 = H - H * 0.022f - bh;
                for (int i = 0; i < n; i++)
                {
                    // shrunk to 92 % while the finger is on it, then springing back to 100 % over 150 ms from the release
                    var b = c.Buttons[i]; float x = x0 + i * (bw + gap); string hid = "btn:" + b.Id;
                    double pu = _held == hid ? 0 : _btnUp.TryGetValue(hid, out var upAt) ? (now - upAt) / 150 : (c.Now - b.PressedAt) / 150;
                    var p = Draw("btn" + i, b.Id + b.Lit + b.Label, x, y0, bw, bh, H0 + 2, u =>
                    {
                        u.Box(0, 0, bw, bh, new BoxStyle { Background = b.Lit ? Mix(b.Color, 0.18, "#ffffff") : "#ffffff", Radius = bw * 0.22f, BorderWidth = b.Lit ? 0.8f * cq : 0, BorderColor = b.Color, Shadows = new[] { new Shadow(Mix(b.Color, 0.55, "#3b2457"), 0, 1.2f * cq, 0) } });
                        float ic = bh * 0.46f; u.Raw(Icon(b.Icon, bw / 2 - ic / 2, bh * 0.1f, ic, ic));
                        var lt = new TextStyle { Font = Fred, Size = Mathf.Clamp(4.6f * cq, 12, 20), Color = b.Color, LineHeight = Mathf.Clamp(4.6f * cq, 12, 20) };
                        u.Text(b.Label, 0, bh * 0.1f + ic + bh * 0.04f, lt, bw, 0.5f); return u;
                    });
                    if (pu >= 0 && pu < 1) p.Transform = Around(x, y0, x + bw / 2, y0 + bh / 2, 1 - (1 - Shrink) * (1 - pu));
                    _hits.Add(("btn:" + b.Id, x, y0, bw, bh));
                }
            }
            // the toasts
            for (int i = 0; i < 8; i++)
            {
                if (i >= c.Toasts.Count) continue;
                var t = c.Toasts[i]; double dur = t.Big ? 1400 : 1000, u0 = (c.Now - t.T0) / dur; if (u0 < 0 || u0 > 1) continue;
                float size = (t.Big ? 12 : 6) * cq; var ft = UiFont.Get(Fred);
                float w = ft.BoxWidth(t.Txt, size, 0), bx = w + 4 * cq, by = size * 1.5f;
                var p = Draw("toast" + i, t.Txt + t.Col + t.Big + t.T0, (float)t.X - bx / 2, (float)t.Y - by / 2, bx, by, H0 + 10, u =>
                    u.Glyphs(t.Txt, 2 * cq, by / 2 + size * 0.35f, Fred, size, 0, "#4a1a73", $"stroke=\"#4a1a73\" stroke-width=\"{F(0.5f * cq * ft.UnitsPerEm / size)}\" stroke-linejoin=\"round\"").Glyphs(t.Txt, 2 * cq, by / 2 + size * 0.35f, Fred, size, 0, t.Col));
                // ygToast: 0 (op 0, -30%, 0.6) 18% (op 1, -50%, 1.12) 30% (1) 75% (op 1) 100% (op 0, -110%)
                double sc, dy, op;
                if (u0 < 0.18) { double e = EaseOut(u0 / 0.18); op = e; sc = 0.6 + 0.52 * e; dy = (0.2 - 0.2 * e) * size; }
                else if (u0 < 0.3) { double e = EaseOut((u0 - 0.18) / 0.12); op = 1; sc = 1.12 - 0.12 * e; dy = 0; }
                else if (u0 < 0.75) { double e = EaseOut((u0 - 0.3) / 0.45); op = 1; sc = 1; dy = -0.6 * size * e * (0.45 / 0.7); }
                else { double e = EaseOut((u0 - 0.75) / 0.25); op = 1 - e; sc = 1; dy = -0.6 * size * ((0.45 + 0.25 * e) / 0.7); }
                p.Opacity = (float)op;
                p.Transform = At(t.X, t.Y + dy) * Affine.ScaleBy(sc, sc) * Affine.Translate(-bx / 2 * _K / pk, -by / 2 * _K / pk);
            }
        }

        // ---------- the cards ----------
        double PopK(double now) { double u = Math.Min(1, (now - _ovT0) / 350); return 0.7 + 0.3 * Pop(u); }
        void Shade() => Draw("shade", "s", 0, 0, W, H, O + 89, u => u.Box(0, 0, W, H, new BoxStyle { Background = "rgba(58,30,100,0.32)", Radius = 30 }), 0);
        void Card(string id, string key, float h, double now, Func<UiSvg, float, UiSvg> draw, List<(string id, float x, float y, float w, float h)> hits)
        {
            Shade();
            float cw = W - 12 * cq, x = 6 * cq, y = H / 2 - h / 2;
            var p = Draw(id, key, x, y, cw, h, O + 90, u => draw(u.Box(0, 0, cw, h, new BoxStyle { Background = "#ffffff", Radius = 7 * cq, Shadows = new[] { new Shadow("#c9b6f2", 0, 2 * cq, 0), new Shadow("rgba(40,10,80,0.3)", 0, 6 * cq, 16 * cq) } }), cw), 90);
            double k = PopK(now); p.Opacity = (float)Math.Min(1, (now - _ovT0) / 350 * 1.6);
            p.Transform = Around(x, y, W / 2, H / 2, k);
            foreach (var hh in hits) _hits.Add((hh.id, x + hh.x, y + hh.y, hh.w, hh.h));
        }
        void Btn(UiSvg u, string label, float x, float y, float w, float h, float font, bool ghost, bool pressed = false)
        {
            if (pressed) u.Open(PressG(x + w / 2, y + h / 2));
            var st = ghost ? new BoxStyle { Background = "#f1eafc", Radius = 999, Shadows = new[] { new Shadow("#c9b6f2", 0, 1.4f * cq, 0) } }
                           : new BoxStyle { Gradient = new[] { "#ff8fd2", "#e0479f" }, Radius = 999, Shadows = new[] { new Shadow("#a8287a", 0, 1.4f * cq, 0) } };
            u.Box(x, y, w, h, st); var t = TS(Fred, font, ghost ? "#6a2fb0" : "#ffffff", 1); u.Text(label, x, y + (h - Lh(t)) / 2, t, w, 0.5f);
            if (pressed) u.Close();
        }

        void Intro(double now)
        {
            var G = _g; float cw = W - 12 * cq, pad = 6 * cq, iw = cw - 2 * pad;
            var ttl = TS(Fred, 8, "#4a1a73", 1.05f); var sub = TS(Nun8, 3.4f, "#8a5bb8", 1.3f); var how = TS(Nun7, 3.9f, "#4a3566", 1.35f);
            var opt = TS(Nun8, 3.6f, "#4a1a73", 1); var best = TS(Nun8, 3.4f, "#8a5bb8", 1);
            var hows = new List<List<string>>(); foreach (var s in G.How ?? new string[0]) hows.Add(Wrap(s, how, iw - 5 * cq));
            // the layout, top down
            float y = pad - 2 * cq; float icY = y; y += 24 * cq + 1 * cq;
            float tY = y; y += Lh(ttl); float sY = y + 1 * cq; y = sY + Lh(sub);
            y += 4 * cq; float hY = y; foreach (var l in hows) y += l.Count * Lh(how) + 2 * cq; 
            var hits = new List<(string, float, float, float, float)>(); var opts = new List<(string id, string label, float x, float w)>(); float oY = 0, oh = 3.6f * cq + 3.2f * cq + 1.2f * cq;
            if (G.Options != null && G.Options.Length > 0)
            {
                y += 2 * cq; oY = y; float tw = 0; foreach (var o in G.Options) tw += UiSvg.BoxWidth(o.label, opt) + 6.8f * cq + 1.2f * cq; tw += 2 * cq * (G.Options.Length - 1);
                float x = cw / 2 - tw / 2; foreach (var o in G.Options) { float w = UiSvg.BoxWidth(o.label, opt) + 8 * cq; opts.Add((o.id, o.label, x, w)); hits.Add(("opt:" + o.id, x, oY, w, oh)); x += w + 2 * cq; }
                y += oh + 1 * cq;
            }
            y += 3 * cq; float gw = UiSvg.BoxWidth("Play", TS(Fred, 6.4f, "#fff")) + 28 * cq, gh = 6.4f * cq + 7.2f * cq, gY = y; hits.Add(("play", cw / 2 - gw / 2, gY, gw, gh)); y += gh + 1.4f * cq;
            y += 3 * cq; float bY = y; y += Lh(best) + 5 * cq;
            _save.Best.TryGetValue(G.Id, out var bv); string bt = bv > 0 ? "Best " + bv : "No best yet";
            string ih = _held != null && (_held == "play" || _held.StartsWith("opt:")) ? _held : "";
            Card("intro", G.Id + G.Opt + "|" + ih, y, now, (u, w) =>
            {
                u.Raw(Icon(G.Icon, w / 2 - 17 * cq, icY, 34 * cq, 24 * cq));
                u.Text(G.Name, 0, tY, ttl, w, 0.5f); u.Text("Yard: " + G.Item, 0, sY, sub, w, 0.5f);
                float yy = hY;
                foreach (var l in hows) { u.Raw($"<circle cx=\"{F(pad + 2 * cq)}\" cy=\"{F(yy + Lh(how) / 2)}\" r=\"{F(0.7 * cq)}\" fill=\"#4a3566\"/>"); foreach (var s in l) { u.Text(s, pad + 5 * cq, yy, how); yy += Lh(how); } yy += 2 * cq; }
                foreach (var o in opts)
                {
                    bool on = o.id == G.Opt, pr = ih == "opt:" + o.id;
                    if (pr) u.Open(PressG(o.x + o.w / 2, oY + oh / 2));
                    u.Box(o.x, oY, o.w, oh, new BoxStyle { Background = on ? "#6a2fb0" : "#faf6ff", Radius = 999, BorderWidth = 0.6f * cq, BorderColor = on ? "#6a2fb0" : "#e0d2f7" });
                    u.Text(o.label, o.x, oY + (oh - Lh(opt)) / 2, TS(Nun8, 3.6f, on ? "#ffffff" : "#4a1a73", 1), o.w, 0.5f);
                    if (pr) u.Close();
                }
                Btn(u, "Play", w / 2 - gw / 2, gY, gw, gh, 6.4f, false, ih == "play");
                u.Text(bt, 0, bY, best, w, 0.5f); return u;
            }, hits);
        }

        void ResultCard(double now)
        {
            var r = _res; float pad = 6 * cq;
            var ttl = TS(Fred, 8.6f, "#4a1a73", 1.05f); var sc = TS(Fred, 14, "#e0479f", 1); var sub = TS(Nun8, 3.8f, "#6b5590", 1.3f); var coin = TS(Nun8, 3.6f, "#7a5200", 1);
            float y = pad, tY = y; y += Lh(ttl) + 2 * cq; float stY = y; y += 11 * cq + 1 * cq; float sY = y; y += Lh(sc); float bY = y + 1 * cq; y = bY + Lh(sub);
            y += 3 * cq; float cY = y; string ct = "+" + r.coins + " coins (preview)"; float cwid = UiSvg.BoxWidth(ct, coin) + 8 * cq, ch = 3.6f * cq + 3.2f * cq; y += ch + 4 * cq;
            float bh = 5.4f * cq + 6.4f * cq, w1 = UiSvg.BoxWidth("Yard", TS(Fred, 5.4f, "#fff")) + 14 * cq, w2 = UiSvg.BoxWidth("Play again", TS(Fred, 5.4f, "#fff")) + 14 * cq, rY = y; y += bh + 1.4f * cq + 5 * cq;
            float cw = W - 12 * cq, bx = cw / 2 - (w1 + w2 + 3 * cq) / 2;
            var hits = new List<(string, float, float, float, float)> { ("hub", bx, rY, w1, bh), ("again", bx + w1 + 3 * cq, rY, w2, bh) };
            // the stars pop in one by one (0.1 s, 0.25 s, 0.4 s): the card redraws until they're in
            double since = (now - _ovT0) / 1000; int phase = since < 0.1 ? 0 : (int)Math.Min(10, Math.Floor((since - 0.1) / 0.05)) + 1;
            string rh = _held == "hub" || _held == "again" ? _held : "";
            Card("res", "r" + _c.score + r.title + phase + "|" + rh, y, now, (u, w) =>
            {
                u.Text(r.title, 0, tY, ttl, w, 0.5f);
                float sz = 11 * cq, gap = 2 * cq, x0 = w / 2 - (3 * sz + 2 * gap) / 2;
                for (int i = 0; i < 3; i++)
                {
                    float cx = x0 + i * (sz + gap) + sz / 2, cy = stY + sz / 2;
                    if (i < r.stars)
                    {
                        double su = Math.Max(0, Math.Min(1, (since - (i * 0.15 + 0.1)) / 0.45)), k = StarPop(su); if (k <= 0.01) continue;
                        u.Raw($"<g transform=\"translate({F(cx)} {F(cy)}) rotate({F(-40 * (1 - su))}) scale({F(k)})\">{Star(0, 0.8f * cq, sz * 0.46f, "#e09a14")}{Star(0, 0, sz * 0.46f, "#ffc93c")}</g>");
                    }
                    else u.Raw(Star(cx, cy, sz * 0.46f, "#e6dcf5"));
                }
                u.Text(_c.score.ToString(CultureInfo.InvariantCulture), 0, sY, sc, w, 0.5f);
                u.Text(_resSub, 0, bY, sub, w, 0.5f);
                u.Box(w / 2 - cwid / 2, cY, cwid, ch, new BoxStyle { Background = "#fff3c2", Radius = 999 }); u.Text(ct, w / 2 - cwid / 2, cY + (ch - Lh(coin)) / 2, coin, cwid, 0.5f);
                Btn(u, "Yard", bx, rY, w1, bh, 5.4f, true, rh == "hub"); Btn(u, "Play again", bx + w1 + 3 * cq, rY, w2, bh, 5.4f, false, rh == "again");
                return u;
            }, hits);
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
            string key = _save.Player;
            if (sl.who == "opp")
            {
                if (!_opp.TryGetValue(game, out key)) { var pool = new List<string>(_roster); pool.Remove(_save.Player); key = pool.Count > 0 ? pool[UnityEngine.Random.Range(0, pool.Count)] : null; _opp[game] = key; }
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
                    svg = head + $" x=\"{F(-sl.w / 2)}\" y=\"{F(-sl.w * 0.93)}\" width=\"{F(sl.w)}\" height=\"{F(sl.w)}\" overflow=\"visible\"" + svg.Substring(b);
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
            if (k != YardPageModel.Hit.Card) return;
            var def = _defs.Find(d => d.Id == id); if (def == null) return;
            if (!_page.Open(id)) { _page.Toast(_need?.Invoke(id) ?? def.Name + " opens with the Backyard", now); return; }
            Sfx("pop"); Play(def);
        }

        // what's held shrinks while the finger stays on it (not once the row is dragged)
        void PageHeld(double px, double py)
        {
            var on = _page.HitTest(px, py, out var id);
            bool still = _pKind != YardPageModel.Hit.None && on == _pKind && id == _pHit && !_page.Dragged;
            _page.Held = still ? on : YardPageModel.Hit.None; _page.HeldGame = still ? id : null;
        }

        // ---------- input ----------
        bool _down, _moved; Vector2 _downAt; double _lastY, _lastX; string _press, _pressOn;
        // the control under a held finger (drawn shrunk to 92 % about its centre, like the menu's Level crest) and when
        // each game button was let go (they spring back to full size from then)
        string _held; readonly Dictionary<string, double> _btnUp = new Dictionary<string, double>();
        const float Shrink = 0.92f;
        // a held control drawn in a picture: a <g>'s attributes shrinking what it holds about (cx, cy)
        static string PressG(float cx, float cy) => $"transform=\"translate({F(cx)} {F(cy)}) scale({F(Shrink)}) translate({F(-cx)} {F(-cy)})\"";
        /// <summary>The control being held: the press started on it, the finger is still on it and it hasn't turned into a
        /// drag (a game button, which fired on the down, stays held while the finger is on it).</summary>
        string Held()
        {
            if (!_down || _pressOn == null || Hit(_lastX, _lastY) != _pressOn) return null;
            if (_pressOn.StartsWith("btn:")) return _press == "used" ? _pressOn : null;
            return !_moved && _press == _pressOn ? _pressOn : null;
        }
        void HandleInput(double now)
        {
            bool down = Input.GetMouseButtonDown(0), up = Input.GetMouseButtonUp(0), held = Input.GetMouseButton(0);
            Vector2 pos = Input.mousePosition;
            if (Input.touchCount > 0) { var t = Input.GetTouch(0); pos = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up; }
            double ux = (pos.x - _fx) / _K, uy = (_h - pos.y - _fy) / _K;
            if (down)
            {
                _down = true; _moved = false; _downAt = pos; _lastX = ux; _lastY = uy; _press = _pressOn = Hit(ux, uy);
                if (_g != null && _ov == null)
                {
                    if (_press != null && _press.StartsWith("btn:")) { _c.PressButton(_press.Substring(4)); _press = "used"; return; }
                    if (_press == "back") return;
                    _press = "game"; if (_c.playing) _g.Down(ux, uy, _c.Now);
                }
                return;
            }
            if (!_down) return;
            if ((pos - _downAt).magnitude > 10 * _K) _moved = true;
            if (held && !up)
            {
                if (_press == "game") { if (_c.playing) _g.Move(ux, uy, _c.Now); }
                _lastX = ux; _lastY = uy;
                return;
            }
            _down = false;
            if (_press == "game") { if (_c.playing) _g.Up(ux, uy, _c.Now); return; }
            if (_moved || _press == null || _press == "used") return;
            var h = Hit(ux, uy); if (h != _press) return;
            Tap(h);
        }
        string Hit(double x, double y)
        {
            for (int i = _hits.Count - 1; i >= 0; i--) { var h = _hits[i]; if (x >= h.x && x <= h.x + h.w && y >= h.y && y <= h.y + h.h) return h.id; }
            return null;
        }
        void Tap(string h)
        {
            if (h == "back" || h == "hub") { Sfx("tap"); Hub(); return; }
            if (h == "play") { Begin(); return; }
            if (h == "again") { Sfx("pop"); Play(_g); return; }
            if (h.StartsWith("opt:")) { _g.Opt = h.Substring(4); _opts[_g.Id] = _g.Opt; Sfx("tap"); return; }
        }
    }
}
