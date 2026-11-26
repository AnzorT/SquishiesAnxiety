// The game intro (develop's webgame/app/intro.js, "Squish wakes the house", 2026-11-16 and after) on the menu's own
// house, after log in, once a launch: the night, a box drops ("Tap the box!"), Mittens pops out, three squishes of him
// light three rooms (sparks fly to them, chimes), the whole house glows, dawn into a morning in today's weather, the squad
// peeks out of the windows and waves, the plush SQUISH SQUAD logo drops in letter by letter, "TAP TO START". Skip (top
// right) ends it at once. Every moment and curve is intro.js's.
//   - what Unity's renderer can't draw (the night's veil with its holes, the halos in `screen`, the panes in
//     `soft-light`, the dawn in `multiply`) is the app's own pictures (tools/unity/export-intro.mjs: Resources/Intro/
//     <weather>/<state>.jpg on the house pictures' canvas), crossfaded as the lights come on: night, lit1-3, lit6,
//     dawn1-3, morning
//   - the box, the ring, the sparks, bursts and puffs, the squad peeking out are drawn here (UiPiece, the scene's units)
//   - the captions, Skip, TAP TO START and the logo's letters are the app's pictures (the overlay: 852 x 393 units scaled
//     to the screen's height)
//   - the rain or snow of a rainy / snowy day (IntroRain.cs): on the frame over the house, under the captions, from the
//     night into the morning, fading with the rest at the end
//   - Mittens: the menu's creature, the recorded moves (surprised, look, dance), lit for the night (menu.js light():
//     brightness / saturate / a little sepia: CreatureView.SetTint)
using System;
using System.Collections.Generic;
using SquishSquad.Audio;
using SquishSquad.Creatures;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        // ---- intro.js's numbers -------------------------------------------------------------------------------------
        static readonly Dictionary<string, (char k, float a, float b, float c, float d)[]> IWIN = new Dictionary<string, (char, float, float, float, float)[]>
        {
            ["living"] = new[] { ('r', 434f, 218f, 36f, 40f), ('r', 530f, 218f, 36f, 40f) },
            ["bedroom"] = new[] { ('a', 298f, 164f, 42f, 48f), ('r', 366f, 176f, 30f, 30f) },
            ["bathroom"] = new[] { ('c', 629f, 185f, 17f, 0f), ('r', 668f, 164f, 46f, 44f) },
            ["kitchen"] = new[] { ('r', 282f, 246f, 62f, 36f), ('c', 385f, 265f, 13f, 0f) },
            ["movie"] = new[] { ('r', 604f, 242f, 92f, 40f), ('r', 712f, 248f, 16f, 34f) },
            ["dance"] = new[] { ('d', 500f, 170f, 46f, 0f) },
        };
        static readonly string[] IORDER = { "living", "bedroom", "bathroom" };
        static readonly (string key, string room, int wi, float cx)[] IPEEK =
        {
            ("biscuit", "living", 0, 0), ("berri", "living", 1, 0), ("nibbles", "bedroom", 0, 0), ("appy", "bedroom", 1, 0), ("peachy", "bathroom", 0, 0),
            ("scoop", "bathroom", 1, 0), ("truffle", "kitchen", 0, 0), ("boba", "movie", 0, 628), ("bao", "movie", 0, 672),
        };
        const float BX = IntroArt.BX, BY = IntroArt.BY, BW = IntroArt.BW, BH = IntroArt.BH, FX0 = IntroArt.FX0, FX1 = IntroArt.FX1, FTOP = IntroArt.FTOP;
        static string F(double v) => UiSvg.F(v);
        static string Pt(double x, double y) => IntroArt.Pt(x, y);
        static string Star(double X, double Y, double r) => IntroArt.Star(X, Y, r);

        static (float x, float y, float w, float h) WBox((char k, float a, float b, float c, float d) w) =>
            w.k == 'r' || w.k == 'a' ? (w.a, w.b, w.c, w.d) : w.k == 'c' ? (w.a - w.c, w.b - w.c, 2 * w.c, 2 * w.c) : (w.a - w.c, w.b - w.c, 2 * w.c, w.c);
        static string WShape((char k, float a, float b, float c, float d) w, string at)
        {
            string F(double v) => UiSvg.F(v);
            if (w.k == 'r') return $"<rect x=\"{F(w.a)}\" y=\"{F(w.b)}\" width=\"{F(w.c)}\" height=\"{F(w.d)}\" rx=\"1.5\" {at}/>";
            if (w.k == 'a') return $"<path d=\"M{F(w.a)} {F(w.b + w.d)} V{F(w.b + w.c / 2)} A{F(w.c / 2)} {F(w.c / 2)} 0 0 1 {F(w.a + w.c)} {F(w.b + w.c / 2)} V{F(w.b + w.d)}Z\" {at}/>";
            if (w.k == 'd') return $"<path d=\"M{F(w.a - w.c)} {F(w.b)} A{F(w.c)} {F(w.c)} 0 0 1 {F(w.a + w.c)} {F(w.b)}Z\" {at}/>";
            return $"<circle cx=\"{F(w.a)}\" cy=\"{F(w.b)}\" r=\"{F(w.c)}\" {at}/>";
        }
        static (float, float) RoomCentre(string room)
        {
            float x = 0, y = 0; var ws = IWIN[room];
            foreach (var w in ws) { var b = WBox(w); x += b.x + b.w / 2; y += b.y + b.h / 2; }
            return (x / ws.Length, y / ws.Length);
        }

        static double Clamp01(double v) => v < 0 ? 0 : v > 1 ? 1 : v;
        static double EaseIO3(double t) => t < 0.5 ? 4 * t * t * t : 1 - Math.Pow(-2 * t + 2, 3) / 2;
        static double EaseOut3(double t) => 1 - Math.Pow(1 - t, 3);
        static double EaseIn3(double t) => t * t * t;
        static double BackOut(double t) { const double c = 1.9; return 1 + (c + 1) * Math.Pow(t - 1, 3) + c * Math.Pow(t - 1, 2); }
        static double BounceOut(double t)
        {
            const double n = 7.5625, d = 2.75;
            if (t < 1 / d) return n * t * t;
            if (t < 2 / d) { t -= 1.5 / d; return n * t * t + 0.75; }
            if (t < 2.5 / d) { t -= 2.25 / d; return n * t * t + 0.9375; }
            t -= 2.625 / d; return n * t * t + 0.984375;
        }
        static double CssEaseT(double t) => CssEase((float)Clamp01(t));

        // ---- state ----------------------------------------------------------------------------------------------------
        sealed class Intro
        {
            public double T0;                 // the menu's clock when it started
            public string Weather;
            public Action Awake, Done;
            public Texture2D[] States;        // night lit1 lit2 lit3 lit6 dawn1 dawn2 dawn3 morning
            public SpriteRenderer PicA, PicB, Black;
            public UiPiece BoxBack, BoxFront, Shadow, Ring, Fx;
            public readonly List<UiPiece> Peeks = new List<UiPiece>();
            public readonly List<(UiPiece p, IntroRain.Layer l)> Rain = new List<(UiPiece, IntroRain.Layer)>();
            public readonly Dictionary<string, SpriteRenderer> Caps = new Dictionary<string, SpriteRenderer>();
            public SpriteRenderer Skip, Tap;
            public readonly List<(Transform pivot, SpriteRenderer sr)> Letters = new List<(Transform, SpriteRenderer)>();
            public double Tb = -1;            // the box tapped
            public int N;                     // rooms lit by squishes
            public double PressAt = -1, FlyAt = -1;   // a squish held / flying to its room
            public readonly double[] LitAt = { -1, -1, -1 };   // when each squish's room started lighting
            public double Tr = -1;            // the rest of the house (after the third)
            public bool Finished; public double FinishAt = -1;
            public string Cap; public double CapAt = -9999; public string CapOld; public double PopAt = -9999;
            public readonly List<(double at, float x, float y, int n, string[] cols, double spd, double life, int seed)> Bursts = new List<(double, float, float, int, string[], double, double, int)>();
            public readonly List<(double at, float x, float y)> Puffs = new List<(double, float, float)>();
            public (double at, float x0, float y0, float x1, float y1) Spark = (-1, 0, 0, 0, 0);
            public readonly HashSet<string> Sounded = new HashSet<string>();
            public double RingOffAt = -1, RingOnAt = -1;
            public bool AwakeSent;
        }
        Intro _intro;
        SpriteRenderer _sceneSr;
        public bool IntroOn => _intro != null;

        /// <summary>Plays the intro over the house (`weather`: today's), `awake` as the logo's first letter starts to drop
        /// (the music may start), `done` once it has handed the screen back.</summary>
        public void StartIntro(float nowMs, string weather, Action awake, Action done)
        {
            if (_intro != null) return;
            var data = Resources.Load<TextAsset>("Intro/intro");
            if (data == null || _sceneSr == null) { done?.Invoke(); return; }
            var J = SquishSquad.Backend.Json.Parse(data.text) as IDictionary<string, object>;
            var wx = J["weathers"] as IDictionary<string, object>;
            if (!wx.ContainsKey(weather)) weather = "sunny";
            var it = new Intro { T0 = nowMs, Weather = weather, Awake = awake, Done = done };
            var list = (IList<object>)wx[weather];
            it.States = new Texture2D[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                var res = (string)((IDictionary<string, object>)list[i])["res"];
                var bytes = Resources.Load<TextAsset>(res);
                var tex = new Texture2D(2, 2, TextureFormat.RGB24, false) { name = res, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp };
                tex.LoadImage(bytes.bytes, true);
                Resources.UnloadAsset(bytes);
                _made.Add(tex);
                it.States[i] = tex;
            }
            // the house pictures' place (the intro's are on the same canvas)
            float s = _k * _layout.scene.unitsPerPx;
            var pos = Snap(new Vector2(_ox + _layout.scene.originUnits[0] * _k, _oy + _layout.scene.originUnits[1] * _k), s);
            it.PicA = Picture("intro night", _world, it.States[0], pos, s, SceneOrder);
            it.PicB = Picture("intro next", _world, it.States[0], pos, s, SceneOrder + 1);
            it.PicB.color = new Color(1, 1, 1, 0);
            _sceneSr.enabled = false;
            if (_vignette != null) _vignette.enabled = false;
            foreach (var b in _birds) b.T.gameObject.SetActive(false);   // (the intro's own sky: the menu's weather layer is hidden, sq-intro)
            // the black it fades in from (#05060f, 1.4 s ease, from 60 ms)
            var white = Texture2D.whiteTexture;
            it.Black = Picture("intro black", _root, white, Vector2.zero, 1, 60);
            it.Black.transform.localScale = new Vector3(_w / white.width, _h / white.height, 1);
            it.Black.color = new Color(5 / 255f, 6 / 255f, 15 / 255f, 1);
            // the world's pieces (in the scene's units, moved with the camera)
            int co = CreatureOrder;
            it.Shadow = UiPiece.Create(_world, "intro box shadow", co - 2);
            it.BoxBack = UiPiece.Create(_world, "intro box back", co - 1);
            it.BoxFront = UiPiece.Create(_world, "intro box front", co + 2);
            it.Ring = UiPiece.Create(_world, "intro ring", co + 3);
            it.Fx = UiPiece.Create(_world, "intro fx", co + 4);
            for (int i = 0; i < IPEEK.Length; i++) { var p = UiPiece.Create(_world, "intro peek " + i, SceneOrder + 3); p.Visible = false; it.Peeks.Add(p); }
            // the rain or snow (rainBuild): on the frame, in front of the world, under the overlay's pictures (52+)
            foreach (var l in IntroRain.Layers(_w / UiPiece.PxPerDp, _h / UiPiece.PxPerDp, weather))
            {
                var p = UiPiece.Create(_root, "intro rain", 51);
                p.SetSvg(l.Svg, l.W, l.H, 4);
                it.Rain.Add((p, l));
            }
            // the overlay's pictures
            var ov = J["overlay"] as IDictionary<string, object>;
            foreach (var kv in (IDictionary<string, object>)ov["captions"]) it.Caps[kv.Key] = OverlayPic("intro cap " + kv.Key, (IDictionary<string, object>)kv.Value, 52, true);
            it.Skip = OverlayPic("intro skip", (IDictionary<string, object>)ov["skip"], 53, false, right: true);
            it.Tap = OverlayPic("intro tap", (IDictionary<string, object>)ov["tap"], 53, true);
            foreach (var o in (IList<object>)J["logo"])
            {
                var L = (IDictionary<string, object>)o;
                var box = Floats(L["box"]);
                // the letter turns and squashes about 50 % 96 % of its box
                var pivot = new GameObject("intro letter").transform;
                pivot.SetParent(_root, false);
                var pv = new Vector2((float)(box[0] + box[2] / 2), (float)(box[1] + box[3] * 0.96));
                var sr = OverlayPic("letter", L, 54, true, parent: pivot, origin: pv);
                it.Letters.Add((pivot, sr));
            }
            foreach (var c in it.Caps.Values) c.color = new Color(1, 1, 1, 0);
            it.Tap.color = new Color(1, 1, 1, 0);
            foreach (var l in it.Letters) l.sr.color = new Color(1, 1, 1, 0);
            // its made-up tones (the peeks', the logo's thuds) rendered ahead on the sounds' worker, as its named sounds
            // were at launch (MenuSynth.Unity.cs): the first is wanted after the third squish, many seconds from now
            var tones = new List<string>();
            for (int i = 0; i < IPEEK.Length; i++) tones.Add(PeekTone(i));
            for (int j = 0; j < it.Letters.Count; j++) tones.Add(ThudTone(j));
            MenuSynth.Prebuild(tones);
            _intro = it;
            Fade(0, nowMs);   // the menu's HUD goes (x.fade(false))
            if (Creature != null) { Creature.gameObject.SetActive(false); Creature.SetTint(NightTint(0).c, NightTint(0).sat); }
            _pieces.Find(x => x.Data.id == "creature")?.HideStill(true);   // (a still, when its rig can't start: hidden too)
            TickIntro(nowMs);
        }

        int CreatureOrder { get { var p = _pieces.Find(x => x.Data.id == "creature"); return p != null ? p.Order : WorldOrder; } }

        // the overlay (852 x 393 units, scaled by the screen's height / 393): a centred piece moves with the screen's
        // middle, Skip with its right edge
        float OvK => _h / 393f;
        float OvDx(bool centred, bool right) { float ovW = _w / OvK, ovRef = 2340f / (1080f / 393f); return right ? ovW - ovRef : centred ? (ovW - ovRef) / 2 : 0; }
        static float[] Floats(object o) { var l = (IList<object>)o; var f = new float[l.Count]; for (int i = 0; i < f.Length; i++) f[i] = Convert.ToSingle(l[i]); return f; }
        SpriteRenderer OverlayPic(string name, IDictionary<string, object> piece, int order, bool centred, bool right = false, Transform parent = null, Vector2? origin = null)
        {
            var tex = Resources.Load<Texture2D>((string)piece["res"]);
            if (tex == null) throw new InvalidOperationException("missing picture Resources/" + piece["res"]);
            _textures.Add(tex);
            var at = Floats(piece["at"]);
            float dx = OvDx(centred, right), k = OvK;
            var px = new Vector2((at[0] + dx) * k, at[1] * k);
            if (origin.HasValue && parent != null)
            {
                var o = new Vector2((origin.Value.x + dx) * k, origin.Value.y * k);
                parent.localPosition = World(o);
                px -= o;
            }
            return Picture(name, parent ?? _root, tex, px, _h / 1080f, order);
        }

        // menu.js light(nightLight(n)): brightness(.5 + .5 L) saturate(.6 + .4 L) sepia(.25 warm), L the tint's lightness
        // against the day's, warm the rim's growth (n / 3)
        static (Color c, float sat) NightTint(double n)
        {
            Color mix(Color a, Color b, float t) => Color.Lerp(a, b, t);
            var tint = mix(new Color(0x8f / 255f, 0x99 / 255f, 0xcc / 255f), new Color(0xef / 255f, 0xe2 / 255f, 0xd2 / 255f), (float)(n / 3));
            float lum(Color c) => 0.299f * c.r + 0.587f * c.g + 0.114f * c.b;
            float L = Mathf.Clamp01(lum(tint) / lum(new Color(0xef / 255f, 0xe2 / 255f, 0xd2 / 255f)));
            float b = 0.5f + 0.5f * L, sep = 0.25f * (float)(n / 3);
            return (new Color(b, b * (1 - 0.12f * sep), b * (1 - 0.4f * sep), 1), 0.6f + 0.4f * L);
        }

        // ---- taps ----------------------------------------------------------------------------------------------------
        /// <summary>A finger down / up on the screen (page px, y down) while the intro plays.</summary>
        public void IntroPointer(bool down, bool up, Vector2 pagePx, float nowMs)
        {
            var it = _intro;
            if (it == null || it.Finished) return;
            double t = nowMs - it.T0;
            if (up && SkipHit(pagePx) && it.Tap.color.a <= 0) { FinishIntro(nowMs); return; }
            if (TapToStart(t) && up) { MenuSynth.Play("intro-start"); FinishIntro(nowMs); return; }
            if (it.Tb < 0 && t >= 5350 && up && BoxHit(pagePx)) { it.Tb = t; return; }
            if (SquishOn(t) && it.N < 3 && it.FlyAt < 0)
            {
                if (down && CreatureHit(pagePx)) { it.PressAt = t; it.RingOffAt = t; MenuSynth.Play("intro-press"); NativeSquish(true); }
                if (up && it.PressAt >= 0) { NativeSquish(false); it.PressAt = -1; it.FlyAt = t; MenuSynth.Play("intro-squish" + it.N); it.Bursts.Add((t, 500, 330, 10, Warm, 120, 600, it.Bursts.Count)); var (cx, cy) = RoomCentre(IORDER[it.N]); it.Spark = (t, 500, 335, cx, cy); }
            }
        }

        // intro.js tone()s: a squad member peeking out (the ord-th to come up), a logo letter landing
        static string PeekTone(int ord) => MenuSynth.Tone(880 + ord * 90, 0.14, "triangle", 0.025);
        static string ThudTone(int j) => MenuSynth.Tone(240 + j * 22, 0.16, "triangle", 0.045);

        static readonly string[] Warm = { "#fff3c0", "#ffd76a", "#ffffff" };
        static readonly string[] Confetti = { "#ff8fd0", "#ffe27a", "#8fe0ff", "#b8f0a0", "#ffffff" };

        bool SkipHit(Vector2 p)
        {
            var sr = _intro.Skip; var tl = sr.transform.localPosition; var size = sr.sprite.rect.size * (_h / 1080f);
            return new Rect(tl.x - 8, -tl.y - 8, size.x + 16, size.y + 16).Contains(p);
        }
        Vector2 ToScreen(float u, float v) { var w = _world.TransformPoint(new Vector3(_ox + u * _k, -(_oy + v * _k), 0)); var r = _root.InverseTransformPoint(w); return new Vector2(r.x, -r.y); }
        bool BoxHit(Vector2 p) { var a = ToScreen(FX0 - 16, FTOP - 40); var b = ToScreen(FX1 + 16, FTOP - 40 + BH + 52); return new Rect(a.x, a.y, b.x - a.x, b.y - a.y).Contains(p); }
        bool CreatureHit(Vector2 p) { var piece = _pieces.Find(x => x.Data.id == "creature"); return piece != null && piece.Hit.Contains(p); }
        bool SquishOn(double t) => _intro.Tb >= 0 && t >= _intro.Tb + 3330;
        bool TapToStart(double t) => _intro.Tr >= 0 && t >= LogoAt + 80 * _intro.Letters.Count + 1000;
        double DawnAt => _intro.Tr + 1200;
        double PeekAt => DawnAt + 2800;
        double LogoAt => PeekAt + 1100;

        /// <summary>Skip, the end, or the menu closing: the menu's own scene back under the intro's layers as they fade.</summary>
        public void FinishIntro(float nowMs)
        {
            var it = _intro;
            if (it == null || it.Finished) return;
            it.Finished = true; it.FinishAt = nowMs - it.T0;
            _sceneSr.enabled = true;
            if (_vignette != null) _vignette.enabled = true;
            foreach (var b in _birds) b.T.gameObject.SetActive(true);
            _pieces.Find(x => x.Data.id == "creature")?.HideStill(false);
            if (Creature != null)
            {
                Creature.gameObject.SetActive(true);
                Creature.SetTint(Color.white, 1);
                Creature.transform.localPosition = _creatureHome; Creature.transform.localScale = Vector3.one;
                if (_idle != null) Creature.SetFrames(_idle);
            }
            _world.localScale = Vector3.one; _world.localPosition = Vector3.zero;
            Fade(1, nowMs);
            if (!it.AwakeSent) { it.AwakeSent = true; it.Awake?.Invoke(); }
        }

        // ---- every frame ---------------------------------------------------------------------------------------------
        void TickIntro(float nowMs)
        {
            var it = _intro;
            if (it == null) return;
            double t = nowMs - it.T0;
            float P = UiPiece.PxPerDp;
            var S = Affine.Translate(_ox / P, _oy / P) * Affine.ScaleBy(_k / P, _k / P);   // scene units -> dp
            foreach (var (p, l) in it.Rain) { var (x, y) = l.At(t); p.Transform = Affine.Translate(x, y); }
            if (it.Finished)
            {
                // the intro's layers fade away over the menu (.7 s ease), then go
                double f = 1 - CssEaseT((t - it.FinishAt) / 700);
                SetAlpha(it.PicA, (float)f); SetAlpha(it.PicB, Mathf.Min(it.PicB.color.a, (float)f));
                foreach (var p in new[] { it.BoxBack, it.BoxFront, it.Shadow, it.Ring, it.Fx }) p.Opacity = Math.Min(p.Opacity, (float)f);
                foreach (var p in it.Peeks) p.Opacity = (float)f;
                foreach (var (p, _) in it.Rain) p.Opacity = (float)f;
                foreach (var c in it.Caps.Values) SetAlpha(c, Mathf.Min(c.color.a, (float)f));
                SetAlpha(it.Skip, Mathf.Min(it.Skip.color.a, (float)f)); SetAlpha(it.Tap, Mathf.Min(it.Tap.color.a, (float)f));
                foreach (var l in it.Letters) SetAlpha(l.sr, Mathf.Min(l.sr.color.a, (float)f));
                SetAlpha(it.Black, 0);
                if (t - it.FinishAt >= 800) EndIntro();
                return;
            }

            // the black, the camera (scale 1.2 -> 1 about 50 % 64 %, translateY 3 % -> 0, 4.2 s ease-in-out from 60 ms)
            SetAlpha(it.Black, t < 60 ? 1 : (float)(1 - CssEaseT((t - 60) / 1400)));
            {
                double e = EaseIO3(Clamp01((t - 60) / 4200)), sc = 1.2 - 0.2 * e, ty = 0.03 * (1 - e) * _h;
                var O = new Vector3(_w * 0.5f, -_h * 0.64f, 0);
                _world.localScale = new Vector3((float)sc, (float)sc, 1);
                _world.localPosition = O * (1 - (float)sc) + new Vector3(0, -(float)(ty * sc), 0);
            }

            // the captions
            if (t >= 960 && it.Cap == null && it.CapOld == null) Say(it, "house", 960, false);
            if (t >= 3860 && it.Cap == "house") Hush(it, 3860);
            if (t >= 5350 && it.Tb < 0 && it.Cap != "box") Say(it, "box", 5350, true);
            if (it.Tb >= 0 && it.Cap == "box") Hush(it, it.Tb);
            if (it.Tb >= 0 && t >= it.Tb + 3330 && it.N == 0 && it.Cap != "squish0") Say(it, "squish0", it.Tb + 3330, true);
            if (it.Tb < 0 && t >= 5350 && ((t - 5350) % 3200) < 16 && t > 5400) it.PopAt = t;   // (the nudge every 3.2 s)
            DrawCaptions(it, t);
            SetAlpha(it.Skip, (float)(TapToStart(t) ? 0 : Math.Min(1, t / 450) * 0.92));

            // the box: drops (bounce, 900 ms from 4210), squashes, wobbles until tapped, shakes, opens, falls away
            DrawBox(it, t, S);

            // Mittens
            DrawMittens(it, t);

            // the squishes: each spark lands at 700 ms, its room lights (500 ms), the next caption
            if (it.FlyAt >= 0 && t >= it.FlyAt + 700)
            {
                int n = it.N;
                MenuSynth.Play("intro-chime" + n);
                var (cx, cy) = RoomCentre(IORDER[n]);
                it.Bursts.Add((t, cx, cy, 16, Warm, 130, 900, it.Bursts.Count + 7));
                it.LitAt[n] = t;
                it.N = n + 1; it.FlyAt = -1; it.Spark = (-1, 0, 0, 0, 0);
                Say(it, "squish" + it.N, t, true);
                if (it.N == 1) it.RingOnAt = t + 2500;
                if (it.N >= 3) { it.RingOffAt = t; it.Tr = t + 700; }
            }
            // the rest of the house: kitchen, movie, the dome, 280 ms apart, chimes; then dawn
            if (it.Tr >= 0)
                for (int i = 0; i < 3; i++) if (t >= it.Tr + i * 280) Once(it, "rest" + i, () => MenuSynth.Play("intro-rest" + i));
            if (it.Tr >= 0 && t >= DawnAt) { Hush(it, DawnAt); Once(it, "dawn", () => { MenuSynth.Play("intro-dawn"); IntroMove("dance", ref _danceClip); }); }

            // the house's lights: the pictures crossfaded
            DrawLights(it, t);
            DrawRing(it, t, S);
            DrawFx(it, t, S);
            DrawPeeks(it, t, S);
            // the music comes in with the logo (the user, 2026-11-26: as the SQUISH letters start dropping)
            if (it.Tr >= 0 && t >= LogoAt && !it.AwakeSent) { it.AwakeSent = true; it.Awake?.Invoke(); }
            DrawLogo(it, t);
            if (TapToStart(t))
            {
                double u = t - (LogoAt + 80 * it.Letters.Count + 1000);
                SetAlpha(it.Tap, (float)CssEaseT(u / 600));
                double pulse = 1 + 0.09 * (0.5 - 0.5 * Math.Cos(u / 1300 * 2 * Math.PI));   // (about its middle)
                var size = it.Tap.sprite.rect.size * (_h / 1080f);
                if (!_capHome.TryGetValue(it.Tap, out var home)) _capHome[it.Tap] = home = it.Tap.transform.localPosition;
                it.Tap.transform.localScale = new Vector3(_h / 1080f * (float)pulse, _h / 1080f * (float)pulse, 1);
                it.Tap.transform.localPosition = home + new Vector3(-(float)(pulse - 1) * size.x / 2, (float)(pulse - 1) * size.y / 2, 0);
            }
        }

        void EndIntro()
        {
            var it = _intro;
            _intro = null;
            foreach (var p in new[] { it.BoxBack, it.BoxFront, it.Shadow, it.Ring, it.Fx }) if (p != null) Kill(p.gameObject);
            foreach (var p in it.Peeks) Kill(p.gameObject);
            foreach (var (p, _) in it.Rain) Kill(p.gameObject);
            foreach (var c in it.Caps.Values) Kill(c.gameObject);
            foreach (var l in it.Letters) Kill(l.pivot.gameObject);
            Kill(it.Skip.gameObject); Kill(it.Tap.gameObject); Kill(it.Black.gameObject); Kill(it.PicA.gameObject); Kill(it.PicB.gameObject);
            it.Done?.Invoke();
        }

        static void SetAlpha(SpriteRenderer sr, float a) { if (sr == null) return; var c = sr.color; c.a = Mathf.Clamp01(a); sr.color = c; }
        static void Once(Intro it, string key, Action a) { if (it.Sounded.Add(key)) a(); }

        // say(): the shown caption fades out (.45 s) and the new one comes 300 ms later (.45 s ease), popping when asked
        static void Say(Intro it, string key, double at, bool pop) { if (it.Cap == key) return; it.CapOld = it.Cap; it.Cap = key; it.CapAt = at; if (pop) it.PopAt = at + 300; }
        static void Hush(Intro it, double at) { if (it.Cap == null) return; it.CapOld = it.Cap; it.Cap = null; it.CapAt = at; }
        void DrawCaptions(Intro it, double t)
        {
            foreach (var kv in it.Caps)
            {
                double a = 0;
                if (kv.Key == it.Cap) a = it.CapOld != null ? CssEaseT((t - it.CapAt - 300) / 450) : CssEaseT((t - it.CapAt) / 450);
                else if (kv.Key == it.CapOld) a = 1 - CssEaseT((t - it.CapAt) / 450);
                SetAlpha(kv.Value, (float)a);
                // .pop: scale(1.1) for 280 ms (cubic-bezier(.3,1.6,.5,1) .3 s each way), about its middle
                double pp = t - it.PopAt, sc = 1;
                if (kv.Key == it.Cap && pp >= 0 && pp < 580) sc = 1 + 0.1 * (pp < 280 ? Clamp01(pp / 300) : 1 - Clamp01((pp - 280) / 300));
                var sr = kv.Value; var size = sr.sprite.rect.size * (_h / 1080f);
                float k = (float)sc * (_h / 1080f);
                sr.transform.localScale = new Vector3(k, k, 1);
                if (!_capHome.TryGetValue(sr, out var home)) _capHome[sr] = home = sr.transform.localPosition;
                sr.transform.localPosition = home + new Vector3(-(float)(sc - 1) * size.x / 2, (float)(sc - 1) * size.y / 2, 0);
            }
        }
        readonly Dictionary<SpriteRenderer, Vector3> _capHome = new Dictionary<SpriteRenderer, Vector3>();

        void DrawLights(Intro it, double t)
        {
            // which two pictures and how far: lit n during its 500 ms tween, lit6 over the rest's 1010 ms, then dawn
            int from = 0, to = 0; double k = 0;
            for (int n = 0; n < 3; n++) if (it.LitAt[n] >= 0 && t >= it.LitAt[n]) { from = n; to = n + 1; k = CssEaseT((t - it.LitAt[n]) / 500); }
            if (it.Tr >= 0 && t >= it.Tr) { from = 3; to = 4; k = Clamp01((t - it.Tr) / 1010); }
            if (it.Tr >= 0 && t >= DawnAt)
            {
                double d = Clamp01((t - DawnAt) / 2800) * 4;   // lit6 -> dawn1 -> dawn2 -> dawn3 -> morning
                int i = Math.Min(3, (int)Math.Floor(d));
                from = 4 + i; to = Math.Min(8, 5 + i); k = d - i;
                if (Creature != null) { var nt = d / 4 < 0.55 ? NightTint(3) : (Color.white, 1f); Creature.SetTint(nt.Item1, nt.Item2); }
            }
            if (it.PicA.sprite.texture != it.States[from]) it.PicA.sprite = MakeSprite(it.States[from]);
            if (it.PicB.sprite.texture != it.States[to]) it.PicB.sprite = MakeSprite(it.States[to]);
            SetAlpha(it.PicB, from == to ? 0 : (float)k);
        }

        RecordedRig _surprised, _look, _danceClip;
        // the native rig plays the intro's own states (intro.js play('surprised') ... play('dance')); a recording, its clips
        void IntroMove(string move, ref RecordedRig clip)
        {
            if (Creature == null) return;
            if (_idle is NativeRig) { if (move == "idle") Creature.SetFrames(_idle); Creature.Play(move); return; }
            if (move == "idle") { if (_idle != null) Creature.SetFrames(_idle); return; }
            clip ??= RecordedRig.Load(_creatureKey + "-intro-" + move);
            if (clip == null) return;
            clip.Loop = move == "dance";
            Creature.SetFrames(clip);
        }
        // intro.js's squish: the rig squeezes at once (i.press) and lets go on the rig's own pointer up (native only;
        // a recording is squashed by the stage, below)
        void NativeSquish(bool down)
        {
            if (!(_idle is NativeRig n)) return;
            if (down) { n.Pointer("pointerdown", 50, 60); n.Press(); }
            else n.Pointer("pointerup", 50, 60);
        }

        void DrawMittens(Intro it, double t)
        {
            if (Creature == null || it.Tb < 0) return;
            double u = t - it.Tb - 300;
            if (u < 0) return;
            if (!Creature.gameObject.activeSelf)
            {
                Creature.gameObject.SetActive(true);
                IntroMove("surprised", ref _surprised);
            }
            if (t >= it.Tb + 1830) Once(it, "look", () => IntroMove("look", ref _look));
            if (t >= it.Tb + 3330) Once(it, "idle", () => { RecordedRig none = null; IntroMove("idle", ref none); });
            var piece = _pieces.Find(x => x.Data.id == "creature");
            if (piece == null) return;
            // he grows up out of the box from his feet (.3 -> 1, backOut) with a little jump (720 ms); a squish squeezes him
            double sx = 1, sy = 1, jump = 0;
            if (u < 720) { double s = 0.3 + 0.7 * BackOut(u / 720); sx = sy = s; jump = Math.Sin(Math.Min(1, u / 720 * 1.3) * Math.PI) * 20; }
            if (it.PressAt >= 0 && !(_idle is NativeRig)) { double p = Clamp01((t - it.PressAt) / 120); sx *= 1 + 0.08 * p; sy *= 1 - 0.12 * p; }
            var hit = piece.Hit;
            var pivot = World(new Vector2(hit.x + hit.width * 0.5f, hit.y + hit.height * 0.96f));
            var q = pivot - _creatureHome;
            Creature.transform.localScale = new Vector3((float)sx, (float)sy, 1);
            Creature.transform.localPosition = _creatureHome + new Vector3(q.x * (1 - (float)sx), q.y * (1 - (float)sy), 0) + new Vector3(0, (float)(jump / 100 * hit.height), 0);
            if (it.Tr < 0 || t < DawnAt) { var nt = NightTint(it.N); Creature.SetTint(nt.c, nt.sat); }
        }

        // ---- the box (intro.js boxB / boxF, brightness(.62) saturate(.85) at night) -----------------------------------
        string _boxBackKey;
        void DrawBox(Intro it, double t, Affine S)
        {
            double dy = -480, rot = 0, sx = 1, sy = 1, op = 1, flaps = 0, shadow = 0;
            bool shown = t >= 4210;
            if (t >= 4210) { double e = BounceOut(Clamp01((t - 4210) / 900)); dy = -480 * (1 - e); shadow = 0.42 * e; }
            if (t >= 5110) { Once(it, "land", () => { it.Puffs.Add((t, BX, BY)); MenuSynth.Play("intro-land"); }); }
            if (t >= 5110 && t < 5350) { double k = Math.Sin((t - 5110) / 240 * Math.PI); sx = 1 + 0.08 * k; sy = 1 - 0.1 * k; }
            if (t >= 5350 && it.Tb < 0)
            {
                double s = (t - 5350) / 1000, ph = s % 1.7, hop = ph < 0.34 ? Math.Sin(ph / 0.34 * Math.PI) : 0;
                dy = -10 * hop; rot = Math.Sin(s * 9) * 1.6 * (0.3 + hop) + (ph < 0.34 ? Math.Sin(s * 34) * 2.4 : 0);
                sx = 1 + 0.04 * hop; sy = 1 - 0.05 * hop + 0.015 * Math.Sin(s * 6); flaps = 0.07 * hop;
            }
            if (it.Tb >= 0)
            {
                double u = t - it.Tb;
                if (u < 300) { double k = u / 300, wv = Math.Sin(k * Math.PI * 4) * (1 - k); dy = 0; rot = wv * 5; sx = 1 + 0.07 * Math.Sin(k * Math.PI); sy = 1 - 0.1 * Math.Sin(k * Math.PI); }
                else
                {
                    dy = 0; rot = 0; sx = sy = 1;
                    Once(it, "open", () => { MenuSynth.Play("intro-open"); it.Bursts.Add((t, BX, FTOP - 6, 30, Confetti, 260, 1200, 3)); });
                    flaps = BackOut(Clamp01((u - 300) / 420));
                    if (u >= 1270) { double k = Clamp01((u - 1270) / 560); sx = 1 + 0.18 * k; sy = 1 - 0.9 * EaseIn3(k); op = 1 - EaseIn3(k); shadow = 0.42 * (1 - k); }
                    if (u >= 1830) { shown = false; Once(it, "fallen", () => it.Puffs.Add((t, BX, BY - 2))); }
                }
            }
            it.BoxBack.Visible = it.BoxFront.Visible = shown; it.Shadow.Visible = t >= 4210 && shadow > 0;
            if (!shown) return;
            // its place: translate(BX, BY + dy) rotate(rot) scale(sx, sy) translate(-BX, -BY), in a box round it
            const float x0 = FX0 - 60, y0 = FTOP - 150, w = BW + 120, h = BH + 170;
            var M = S * Affine.Translate(BX, BY + dy) * Affine.Rotate(rot) * Affine.ScaleBy(sx, sy) * Affine.Translate(-BX, -BY) * Affine.Translate(x0, y0);
            string key = F(Math.Round(flaps, 3));
            if (key != _boxBackKey)
            {
                _boxBackKey = key;
                it.BoxBack.SetSvg($"<svg><g transform=\"translate({F(-x0)} {F(-y0)})\">{IntroArt.BoxBack(flaps)}</g></svg>", w, h, 0);
            }
            if (_boxFrontSvg == null) { _boxFrontSvg = $"<svg><g transform=\"translate({F(-x0)} {F(-y0)})\">{IntroArt.BoxFront()}</g></svg>"; it.BoxFront.SetSvg(_boxFrontSvg, w, h, 0); }
            it.BoxBack.Transform = it.BoxFront.Transform = M;
            it.BoxBack.Opacity = it.BoxFront.Opacity = (float)op;
            if (it.Shadow.Visible)
            {
                if (_shadowDrawn == false) { _shadowDrawn = true; it.Shadow.SetSvg($"<svg><ellipse cx=\"{F(BW * 0.6 + 2)}\" cy=\"11\" rx=\"{F(BW * 0.6)}\" ry=\"9\" fill=\"#0c0820\"/></svg>", (float)(BW * 1.2 + 4), 22, 0); }
                it.Shadow.Transform = S * Affine.Translate(BX - BW * 0.6 - 2, BY + 1 - 11);
                it.Shadow.Opacity = (float)shadow;
            }
        }
        string _boxFrontSvg; bool _shadowDrawn;

        // ---- the ring round what to tap (siRing: two rings .55 -> 1.5, fading, 1.25 s, the second .62 s later) ---------
        void DrawRing(Intro it, double t, Affine S)
        {
            float cx = 0, cy = 0, r = 0; bool on = false;
            if (it.Tb < 0 && t >= 5350) { on = true; cx = BX; cy = FTOP + BH / 2; r = 46; }
            // on Mittens once he's out, off at the first press; back 2.5 s after the first room lights, off at the next press
            if (SquishOn(t) && it.N < 3 && it.PressAt < 0 && it.FlyAt < 0 && (it.N == 0 ? it.RingOffAt < 0 : it.N == 1 && it.RingOnAt >= 0 && t >= it.RingOnAt && it.RingOffAt < it.RingOnAt))
            { on = true; cx = 500; cy = 352; r = 58; }
            it.Ring.Visible = on;
            if (!on) return;
            double since = t - (it.Tb < 0 ? 5350 : it.Tb + 3330);
            var sb = new System.Text.StringBuilder();
            float R = r * 1.6f + 4;
            foreach (var d in new[] { 0.0, 620.0 })
            {
                double p = ((since - d) % 1250 + 1250) % 1250 / 1250, e = 1 - Math.Pow(1 - p, 2);   // (ease-out)
                if (since < d) continue;
                double sc = 0.55 + (1.5 - 0.55) * e, o = 0.95 * (1 - e);
                sb.Append($"<circle cx=\"{F(R)}\" cy=\"{F(R)}\" r=\"{F(30 * sc * r / 30)}\" fill=\"none\" stroke=\"#ffe8a0\" stroke-width=\"{F(3 * sc)}\" opacity=\"{F(o)}\"/>");
            }
            it.Ring.SetSvg($"<svg>{sb}</svg>", 2 * R, 2 * R, 0);
            it.Ring.Transform = S * Affine.Translate(cx - R, cy - R);
        }

        // ---- sparks, bursts, puffs ------------------------------------------------------------------------------------
        void DrawFx(Intro it, double t, Affine S)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var b in it.Bursts.ToArray())
            {
                double u = (t - b.at) / b.life;
                if (u >= 1) { it.Bursts.Remove(b); continue; }
                var rnd = new System.Random(b.seed * 7919 + 13);
                double k = u * b.life / 1000;
                for (int i = 0; i < b.n; i++)
                {
                    double a = -Math.PI / 2 + (rnd.NextDouble() - 0.5) * Math.PI * 1.6, v = b.spd * (0.45 + rnd.NextDouble() * 0.75), r = 2.2 + rnd.NextDouble() * 3.2, rot0 = rnd.NextDouble() * 360;
                    double X = b.x + Math.Cos(a) * v * k, Y = b.y + Math.Sin(a) * v * k + 300 * k * k, o = 1 - u * u;
                    string c = b.cols[i % b.cols.Length];
                    if (i % 3 == 0) sb.Append($"<circle cx=\"{F(X)}\" cy=\"{F(Y)}\" r=\"{F(r)}\" fill=\"{c}\" opacity=\"{F(o)}\"/>");
                    else if (i % 3 == 1) sb.Append($"<rect x=\"{F(X - r)}\" y=\"{F(Y - r * 0.6)}\" width=\"{F(r * 2)}\" height=\"{F(r * 1.2)}\" rx=\"{F(r * 0.6)}\" fill=\"{c}\" opacity=\"{F(o)}\" transform=\"rotate({F(rot0 + u * 500)} {F(X)} {F(Y)})\"/>");
                    else sb.Append($"<path d=\"{Star(X, Y, r)}\" fill=\"{c}\" opacity=\"{F(o)}\"/>");
                }
            }
            foreach (var p in it.Puffs.ToArray())
            {
                double u = (t - p.at) / 700;
                if (u >= 1) { it.Puffs.Remove(p); continue; }
                foreach (var s in new[] { -1, 1 })
                    for (int i = 0; i < 3; i++)
                    {
                        double X = p.x + s * (36 + i * 24) * EaseOut3(u), R = (9 + i * 4) * (0.6 + u * 0.8);
                        sb.Append($"<circle cx=\"{F(X)}\" cy=\"{F(p.y - 4 - i * 2 - u * 9)}\" r=\"{F(R)}\" fill=\"#8f8aa6\" opacity=\"{F((1 - u) * 0.5)}\"/>");
                    }
            }
            if (it.Spark.at >= 0)
            {
                // a spark flies from Mittens to the room along an arc (700 ms), leaving a twinkly trail
                var sp = it.Spark;
                double cxq = (sp.x0 + sp.x1) / 2 + (sp.x1 < 500 ? 40 : -40), cyq = Math.Min(sp.y0, sp.y1) - 110;
                (double, double) At(double tt) { double e = EaseIO3(Clamp01(tt)), u2 = 1 - e; return (u2 * u2 * sp.x0 + 2 * u2 * e * cxq + e * e * sp.x1, u2 * u2 * sp.y0 + 2 * u2 * e * cyq + e * e * sp.y1); }
                double tt0 = (t - sp.at) / 700;
                for (int i = 0; i < 16; i++)
                {
                    double ti = tt0 - (15 - i) * 16.0 / 700; if (ti < 0) continue;
                    var (X, Y) = At(ti); double kk = (i + 1) / 16.0;
                    sb.Append($"<circle cx=\"{F(X + Math.Sin(i * 2.3 + tt0 * 20) * 2.5)}\" cy=\"{F(Y + Math.Cos(i * 1.7 + tt0 * 17) * 2)}\" r=\"{F(0.8 + kk * 2.4)}\" fill=\"{(i % 3 != 0 ? "#ffe08a" : "#ffffff")}\" opacity=\"{F(kk * 0.85)}\"/>");
                }
                var (sx, sy) = At(tt0);
                sb.Append($"<defs><radialGradient id=\"siGlowF\"><stop offset=\"0\" stop-color=\"#fffbe0\" stop-opacity=\"1\"/><stop offset=\"0.35\" stop-color=\"#ffd76a\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#ffb02a\" stop-opacity=\"0\"/></radialGradient></defs>");
                sb.Append($"<circle cx=\"{F(sx)}\" cy=\"{F(sy)}\" r=\"18\" fill=\"url(#siGlowF)\"/><path d=\"{Star(sx, sy, 5.5)}\" fill=\"#fffbe6\" transform=\"rotate({F(tt0 * 360)} {F(sx)} {F(sy)})\"/>");
            }
            it.Fx.Visible = sb.Length > 0;
            if (sb.Length == 0) return;
            // (the whole scene's box: the effects reach anywhere over the house)
            it.Fx.SetSvg($"<svg>{sb}</svg>", 1000, 460, 0);
            it.Fx.Transform = S;
        }

        // ---- the squad peeking out of the windows (each clipped to its window; up, backOut, 150 ms apart, then waving) --
        int[] _peekOrder;
        void DrawPeeks(Intro it, double t, Affine S)
        {
            if (it.Tr < 0 || t < PeekAt) return;
            if (_peekOrder == null)
            {
                var rnd = new System.Random(1123);
                var l = new List<int>(); for (int i = 0; i < IPEEK.Length; i++) l.Insert(rnd.Next(l.Count + 1), i);
                _peekOrder = l.ToArray();
            }
            for (int i = 0; i < IPEEK.Length; i++)
            {
                var (key, room, wi, pcx) = IPEEK[i];
                var w = IWIN[room][wi]; var bx = WBox(w);
                int ord = Array.IndexOf(_peekOrder, i);
                double d = ord * 150, u = Clamp01((t - PeekAt - d) / 700);
                if (t - PeekAt >= 200 + 150 * ord) Once(it, "peek" + i, () => MenuSynth.Play(PeekTone(ord)));
                float sz = Math.Min(bx.w * 1.1f, bx.h * 1.3f), cx = pcx != 0 ? pcx : bx.x + bx.w / 2;
                double y0 = bx.y + bx.h, y1 = bx.y + bx.h - sz * 0.8, y = y0 + (y1 - y0) * BackOut(u), base_ = bx.y + bx.h + sz * 0.3;
                double since = t - PeekAt - d, wv = u >= 1 ? Math.Sin(since / 240) * 8 * Math.Min(1, (since - 700) / 400) : 0;
                if (u >= 1) y += Math.Abs(Math.Sin(since / 480)) * -1.5;
                var p = it.Peeks[i]; p.Visible = true;
                float m = 4; var pb = (x: bx.x - m, y: bx.y - m, w: bx.w + 2 * m, h: bx.h + 2 * m);
                string clip = "pk" + i;
                p.SetSvg($"<svg><g transform=\"translate({F(-pb.x)} {F(-pb.y)})\"><clipPath id=\"{clip}\">{WShape(w, "")}</clipPath><g clip-path=\"url(#{clip})\"><image href=\"Intro/peek/{key}\" x=\"{F(cx - sz / 2)}\" y=\"{F(y)}\" width=\"{F(sz)}\" height=\"{F(sz)}\" transform=\"rotate({F(wv)} {F(cx)} {F(base_)})\"/></g></g></svg>", pb.w, pb.h, 0);
                p.Transform = S * Affine.Translate(pb.x, pb.y);
            }
        }

        // ---- the plush logo: each letter drops in (bounceOut, 720 ms, 80 ms apart), lands with a squash, then bobs -----
        void DrawLogo(Intro it, double t)
        {
            if (it.Tr < 0 || t < LogoAt) return;
            double k = OvK / 1f, now = t - LogoAt;
            for (int j = 0; j < it.Letters.Count; j++)
            {
                var (pivot, sr) = it.Letters[j];
                double u = Clamp01((now - j * 80) / 720), y = -190 * (1 - BounceOut(u)), land = u > 0.36 && u < 0.62 ? Math.Sin((u - 0.36) / 0.26 * Math.PI) : 0;
                double idle = u >= 1 ? Math.Sin(now / 380 + j * 0.7) * 2.2 : 0, rot = u >= 1 ? Math.Sin(now / 520 + j) * 2 : 0;
                if (u > 0.36) Once(it, "thud" + j, () => MenuSynth.Play(ThudTone(j)));
                SetAlpha(sr, now - j * 80 >= 0 ? 1 : 0);
                if (!_capHome.TryGetValue(sr, out var home)) _capHome[sr] = home = pivot.localPosition;
                pivot.localPosition = home + new Vector3(0, -(float)((y + idle) * k), 0);
                pivot.localScale = new Vector3((float)(1 + 0.16 * land), (float)(1 - 0.2 * land), 1);
                pivot.localRotation = Quaternion.Euler(0, 0, -(float)rot);
            }
        }
    }
}
