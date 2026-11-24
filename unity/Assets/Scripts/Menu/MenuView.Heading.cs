// MY HOUSE's loading screen, "Heading home" (develop: webgame/app/menu.js M.headingHome, REDESIGN_V9 and the PERF
// round of 2026-11-20): after the walk to the door, night falls on the house while the house loads under it. The
// house's picture (the door open) multiplied by the night's colours fades in, stars and the moon come out, the gold
// "Heading home" lettering and a tip at the bottom (a new one every 3 s); the open rooms' windows light up one after
// another as the loading goes (each window the house by day cut to its shape, a warm halo in screen, a pane in soft
// light: drawn once, then faded in), the door last. Once the house has loaded and at least 2 s have passed the camera
// flies in through the door as before (the lettering and the tip fading out over 350 ms), the night going in with it.
// The night and the lights are made the app's way, on the CPU, once: menu.js nightPics' canvas arithmetic (multiply,
// screen, soft-light on sRGB values) over the house picture with the open door drawn in.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Ui;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        static readonly string[] HOME_TIPS = { "The Backyard unlocks the mini games", "Your whole squad lives here. Drop by any time to see what they are up to", "Level up to open more rooms in your house", "Renovate a room to make your squad's home cozier" };
        const float HhMin = 2000;

        // a light (HeadingNight.Light: its windows and its picture) on screen: when it came on, its sprite
        sealed class Lit { public HeadingNight.Light L; public float On = -1; public bool Done; public SpriteRenderer Sr; }

        float _hhT0 = -1, _hhLast, _hhP, _hhReadyAt = -1, _zoomT0 = -1, _hhUiOut = -1, _hhNightAt = -1;
        Action _hhLoad; bool _hhLoaded, _hhGone, _hhNoNight;
        List<Lit> _lights;
        Task<byte[]> _hhWork; int _hhW, _hhH; float _hhS; Vector2 _hhPos;
        SpriteRenderer _hhNight; readonly List<(SpriteRenderer sr, float delay)> _hhStars = new List<(SpriteRenderer, float)>();
        GameObject _hhMoon, _hhTitle, _hhTip; RenderTexture _hhMoonRt, _hhTitleRt; readonly Dictionary<int, RenderTexture> _hhTipRt = new Dictionary<int, RenderTexture>();
        int _hhTipI, _hhTipStart;
        readonly List<UnityEngine.Object> _hhMade = new List<UnityEngine.Object>();

        /// <summary>The house has loaded (its save is in): the flight in may start once the screen has had its 2 s.</summary>
        public void HomeLoaded() { if (_hhReadyAt < 0) _hhReadyAt = _hhLast; _hhLoaded = true; }

        // the screen comes on (the walk is over): the night is made off the main thread, the rest at once
        void StartHeading(float ms)
        {
            _hhT0 = ms; _hhLast = ms; _hhP = 0; _hhReadyAt = _hhLoaded ? ms : -1; _zoomT0 = -1; _hhUiOut = -1; _hhNightAt = -1; _hhGone = false; _hhNoNight = false;
            // the lights in the order they come on: the open rooms' windows by the level they open at, the door last
            var lights = HeadingNight.LightsFor(Level);
            _lights = lights.ConvertAll(l => new Lit { L = l });
            // the house by day (the door open) and the night made from it
            var st = _layout.SceneFor(Season, Level);
            if (st != null)
            {
                try
                {
                    var bytes = Resources.Load<TextAsset>(MenuLayout.Root + st.res);
                    var tex = new Texture2D(2, 2, TextureFormat.RGB24, false);
                    if (bytes != null && tex.LoadImage(bytes.bytes, false))
                    {
                        int W = tex.width, H = tex.height;
                        var day = Rgb(tex.GetPixels32(), W, H);
                        float u = _layout.scene.unitsPerPx, ox = _layout.scene.originUnits[0], oy = _layout.scene.originUnits[1];
                        DoorInto(day, W, H, u, ox, oy);
                        _hhW = W; _hhH = H; _hhS = _k * u; _hhPos = new Vector2(_ox + ox * _k, _oy + oy * _k);
                        _hhWork = Task.Run(() => HeadingNight.Make(day, W, H, u, ox, oy, lights));
                    }
                    if (bytes != null) Resources.UnloadAsset(bytes);
                    Kill(tex);
                }
                catch (Exception e) { Debug.LogWarning("[MenuView] Heading home's night: " + e.Message); }
            }
            BuildSky();
            BuildUi();
            _hhLoad?.Invoke();   // (the house starts loading now that this screen is up: HH.shown())
        }

        // a texture's pixels (rows bottom-up) as HeadingNight's RGB (rows top-down), and back
        static byte[] Rgb(Color32[] px, int W, int H)
        {
            var o = new byte[W * H * 3];
            for (int y = 0; y < H; y++) for (int x = 0; x < W; x++) { var c = px[(H - 1 - y) * W + x]; int j = (y * W + x) * 3; o[j] = c.r; o[j + 1] = c.g; o[j + 2] = c.b; }
            return o;
        }
        Texture2D TexOf(byte[] rgb, int W, int H)
        {
            var flip = new byte[rgb.Length]; int row = W * 3;
            for (int y = 0; y < H; y++) Buffer.BlockCopy(rgb, y * row, flip, (H - 1 - y) * row, row);
            var t = new Texture2D(W, H, TextureFormat.RGB24, false) { wrapMode = TextureWrapMode.Clamp, hideFlags = HideFlags.HideAndDontSave };
            t.LoadRawTextureData(flip); t.Apply(false, true); _hhMade.Add(t);
            return t;
        }

        // the open door (its picture as MenuView.Home.cs draws it) into the house's pixels, at its place
        void DoorInto(byte[] day, int W, int H, float u, float ox, float oy)
        {
            if (_doorRt == null) return;
            var prev = RenderTexture.active;
            var t = new Texture2D(_doorRt.width, _doorRt.height, TextureFormat.RGBA32, false);
            RenderTexture.active = _doorRt; t.ReadPixels(new Rect(0, 0, _doorRt.width, _doorRt.height), 0, 0); t.Apply(false);
            RenderTexture.active = prev;
            var dp = t.GetPixels32(); int dw = t.width, dh = t.height;
            Kill(t);
            // the door's box (scene units 480, 244, 40 x 60) in the picture's px; its texture premultiplied, rows bottom-up
            float x0 = (480 - ox) / u, y0 = (244 - oy) / u, x1 = (520 - ox) / u, y1 = (304 - oy) / u;
            for (int py = Mathf.Max(0, (int)y0); py < Mathf.Min(H, Mathf.CeilToInt(y1)); py++)
                for (int px = Mathf.Max(0, (int)x0); px < Mathf.Min(W, Mathf.CeilToInt(x1)); px++)
                {
                    int sx = Mathf.Clamp((int)((px + 0.5f - x0) / (x1 - x0) * dw), 0, dw - 1), sy = Mathf.Clamp((int)((py + 0.5f - y0) / (y1 - y0) * dh), 0, dh - 1);
                    var s = dp[(dh - 1 - sy) * dw + sx];
                    if (s.a == 0) continue;
                    int j = (py * W + px) * 3; float k = 1 - s.a / 255f;
                    day[j] = (byte)Mathf.Min(255, s.r + day[j] * k); day[j + 1] = (byte)Mathf.Min(255, s.g + day[j + 1] * k); day[j + 2] = (byte)Mathf.Min(255, s.b + day[j + 2] * k);
                }
        }

        // ---- the sky's pieces: the stars and the moon (in the world: they go in with the house) ----------------------
        void BuildSky()
        {
            float dp = _h / _layout.reference.dp[1];   // px per dp
            // a 2 dp star (.stars i: a white dot with box-shadow 0 0 4px 1px rgba(255,255,255,.6)) in a 32 px texture
            // covering 8 dp: the dot (radius 1 dp) over its glow (radius 2 dp, blurred 4 px)
            const int T = 32; const float dpPerTx = 8f / T;
            var starTex = new Texture2D(T, T, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, hideFlags = HideFlags.HideAndDontSave };
            var sp = new Color32[T * T];
            for (int y = 0; y < T; y++) for (int x = 0; x < T; x++)
            {
                float r = Mathf.Sqrt((x + 0.5f - T / 2f) * (x + 0.5f - T / 2f) + (y + 0.5f - T / 2f) * (y + 0.5f - T / 2f)) * dpPerTx;
                float core = Mathf.Clamp01((1 - r) / dpPerTx + 0.5f), glow = 0.6f * Mathf.Clamp01((2 + 2 - r) / 4f);
                float a = core + glow * (1 - core);
                sp[y * T + x] = new Color32(255, 255, 255, (byte)Mathf.RoundToInt(a * 255));
            }
            starTex.SetPixels32(sp); starTex.Apply(false, true); _hhMade.Add(starTex);
            for (int i = 0; i < 46; i++)
            {
                float lx = 2 + (i * 37.7f) % 96, ty = 2 + (i * 53.3f) % 38, size = i % 5 == 0 ? 3 : 2;
                float cx = _w * lx / 100 + size * dp / 2, cy = _h * ty / 100 + size * dp / 2;
                float scale = 8 * dp / T * (size / 2f);   // (a 3 dp star: the same, half as big again)
                var sr = Picture("hh star", _world, starTex, new Vector2(cx - T / 2f * scale, cy - T / 2f * scale), scale, SceneOrder + 4);
                sr.color = new Color(1, 1, 1, 0);
                _hhMade.Add(sr.gameObject);
                _hhStars.Add((sr, (i * 0.37f) % 2.4f));
            }
            // the moon: 52 dp, right 9 %, top 8 %; a crescent (a circle masked by another) with its glow
            float m = 52 * dp, pad = 16 * dp;
            int mp = Mathf.CeilToInt(m + 2 * pad);
            _hhMoonRt = new RenderTexture(mp, mp, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, hideFlags = HideFlags.HideAndDontSave }; _hhMoonRt.Create(); _hhMade.Add(_hhMoonRt);
            string F(float v) => v.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
            var moon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + F(mp) + "\" height=\"" + F(mp) + "\" viewBox=\"" + F(-pad / m * 40) + " " + F(-pad / m * 40) + " " + F(mp / m * 40) + " " + F(mp / m * 40) + "\">"
                + "<defs><mask id=\"m\"><rect x=\"-20\" y=\"-20\" width=\"80\" height=\"80\" fill=\"#fff\"/><circle cx=\"27\" cy=\"15\" r=\"14\" fill=\"#000\"/></mask>"
                + "<filter id=\"g\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"" + F(10 / 2f * 40 / 52f) + "\"/></filter></defs>"
                + "<g filter=\"url(#g)\" opacity=\"0.7\"><circle cx=\"20\" cy=\"20\" r=\"15\" fill=\"#fff6c8\" mask=\"url(#m)\"/></g>"
                + "<circle cx=\"20\" cy=\"20\" r=\"15\" fill=\"#fff6d8\" mask=\"url(#m)\"/></svg>";
            using (var vr = new VectorRenderer()) vr.Render(SvgScene.Compile(SvgMarkup.Parse(moon), mp, mp, Affine.Identity, null), _hhMoonRt);
            _hhMoon = RtQuad("hh moon", _world, _hhMoonRt, new Vector2(_w * 0.91f - m - pad, _h * 0.08f - pad), SceneOrder + 5);
        }

        // a render texture on a quad, its top-left at `pagePx` (px, y down), its own px
        GameObject RtQuad(string name, Transform parent, RenderTexture rt, Vector2 pagePx, int order)
        {
            var go = new GameObject(name); go.transform.SetParent(parent, false); _hhMade.Add(go);
            go.transform.localPosition = World(pagePx);
            var mesh = new Mesh { name = name, hideFlags = HideFlags.HideAndDontSave }; _hhMade.Add(mesh);
            mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(rt.width, 0, 0), new Vector3(rt.width, -rt.height, 0), new Vector3(0, -rt.height, 0) });
            mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            go.AddComponent<MeshFilter>().sharedMesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            var mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = rt, hideFlags = HideFlags.HideAndDontSave }; _hhMade.Add(mat);
            mat.SetFloat("_Opacity", 0);
            mr.sharedMaterial = mat; mr.sortingOrder = order;
            return go;
        }
        static void Opacity(GameObject q, float o) { if (q != null) q.GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Opacity", Mathf.Clamp01(o)); }

        // ---- the lettering and the tip (over the frame, not in the world: they leave as the camera flies) ----------
        float UiK => Mathf.Min(_w / 852f, _h / 393f);   // px per page px (the menu frame's scale)
        void BuildUi()
        {
            float k = UiK;
            // main-menu.js ft('Heading home', 'gold', 34), sized to its text (fitFT), centred 16 px down
            var (svg, w, h) = Lettering("Heading home", 34);
            int pw = Mathf.CeilToInt((w + 40) * k), ph = Mathf.CeilToInt((h + 20) * k);
            _hhTitleRt = new RenderTexture(pw, ph, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, hideFlags = HideFlags.HideAndDontSave }; _hhTitleRt.Create(); _hhMade.Add(_hhTitleRt);
            using (var vr = new VectorRenderer()) vr.Render(SvgScene.Compile(SvgMarkup.Parse(svg), w * k, h * k, Affine.Translate(20 * k, 10 * k), null), _hhTitleRt);
            _hhTitle = RtQuad("hh title", _root, _hhTitleRt, new Vector2(_w / 2 - w * k / 2 - 20 * k, 16 * k - 10 * k), 4000);
            _hhTipStart = _hhTipI = UnityEngine.Random.Range(0, HOME_TIPS.Length);
            ShowTip(_hhTipI);
        }

        void ShowTip(int i)
        {
            float k = UiK;
            if (!_hhTipRt.TryGetValue(i, out var rt))
            {
                var em = new TextStyle { Font = "Nunito_800ExtraBold", Size = 12.5f, Color = "#ffd24a", Shadows = new[] { new Shadow("#2a1608", 0, 1.5f, 0) } };
                var tx = new TextStyle { Font = "Nunito_800ExtraBold", Size = 12.5f, Color = "#fff6e2", Shadows = new[] { new Shadow("#2a1608", 0, 1.5f, 0) } };
                float a = UiSvg.BoxWidth("Tip:", em), sp = UiSvg.BoxWidth(" ", tx), b = UiSvg.BoxWidth(HOME_TIPS[i], tx), w = a + sp + b, h = UiSvg.LineBox(tx);
                var s = new UiSvg(w, h); s.Text("Tip:", 0, 0, em); s.Text(HOME_TIPS[i], a + sp, 0, tx);
                rt = new RenderTexture(Mathf.CeilToInt((w + 8) * k), Mathf.CeilToInt((h + 8) * k), 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, hideFlags = HideFlags.HideAndDontSave }; rt.Create(); _hhMade.Add(rt);
                using (var vr = new VectorRenderer()) vr.Render(SvgScene.Compile(SvgMarkup.Parse(s.Markup), w * k, h * k, Affine.Translate(4 * k, 4 * k), null), rt);
                _hhTipRt[i] = rt;
            }
            if (_hhTip != null) Kill(_hhTip);
            // .bot: bottom 14 px, centred
            _hhTip = RtQuad("hh tip", _root, rt, new Vector2(_w / 2 - rt.width / 2f, _h - 14 * k - (rt.height - 4 * k)), 4000);
        }

        // main-menu.js ft(text, 'gold', size) as SVG (its x numeric: the box's middle), and its box (fitFT's width)
        static (string svg, float w, float h) Lettering(string text, float size)
        {
            float sw = Mathf.Max(2.4f, size * 0.19f), h = Mathf.Ceil(size * 1.32f + sw);
            var f = UiFont.Get("Fredoka_700Bold");
            float tw = f.BoxWidth(text, size, size * 0.02f), w = Mathf.Ceil(tw + sw * 2.4f + 4);
            string F(float v) => v.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
            string T(string extra) => "<text x=\"" + F(w / 2) + "\" y=\"" + F(size * 0.98f + sw / 2) + "\" text-anchor=\"middle\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"" + F(size) + "\" letter-spacing=\"" + F(size * 0.02f) + "\" stroke-linejoin=\"round\" paint-order=\"stroke\" " + extra + ">" + text + "</text>";
            var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + F(w) + "\" height=\"" + F(h) + "\" viewBox=\"0 0 " + F(w) + " " + F(h) + "\" overflow=\"visible\"><defs><linearGradient id=\"hhft\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fffbe6\"/><stop offset=\"0.33\" stop-color=\"#ffe57e\"/><stop offset=\"0.67\" stop-color=\"#ffbe2e\"/><stop offset=\"1\" stop-color=\"#f08c10\"/></linearGradient></defs>"
                + T("fill=\"#ffffff\" stroke=\"#ffffff\" stroke-width=\"" + F(sw * 2.1f) + "\"")
                + T("fill=\"#6b4426\" stroke=\"#6b4426\" stroke-width=\"" + F(sw * 1.25f) + "\" transform=\"translate(0 " + F(size * 0.06f) + ")\"")
                + T("fill=\"url(#hhft)\" stroke=\"#6b4426\" stroke-width=\"" + F(sw) + "\"")
                + T("fill=\"none\" stroke=\"rgba(255,255,255,0.55)\" stroke-width=\"" + F(size * 0.035f) + "\" transform=\"translate(0 " + F(-size * 0.03f) + ")\"") + "</svg>";
            return (svg, w, h);
        }

        static float EaseCss(float x)   // CSS 'ease': cubic-bezier(.25,.1,.25,1)
        {
            if (x <= 0 || x >= 1) return Mathf.Clamp01(x);
            float lo = 0, hi = 1, t = x;
            for (int i = 0; i < 24; i++) { t = (lo + hi) / 2; float bx = 3 * (1 - t) * (1 - t) * t * .25f + 3 * (1 - t) * t * t * .25f + t * t * t; if (bx < x) lo = t; else hi = t; }
            return 3 * (1 - t) * (1 - t) * t * .1f + 3 * (1 - t) * t * t + t * t * t;
        }
        static float EaseOutCss(float x) { if (x <= 0 || x >= 1) return Mathf.Clamp01(x); float lo = 0, hi = 1, t = x; for (int i = 0; i < 24; i++) { t = (lo + hi) / 2; float bx = 3 * (1 - t) * t * t * .58f + t * t * t; if (bx < x) lo = t; else hi = t; } return 3 * (1 - t) * (1 - t) * t + 3 * (1 - t) * t * t + t * t * t; }
        static float Ease3(float ms, float start, float dur) => EaseCss(Mathf.Clamp01((ms - start) / dur));

        /// <summary>The screen's frame: the fades, the stars' twinkle, the tip's turn, the loading's progress and the
        /// lights; true once the camera may fly in.</summary>
        bool TickHeading(float ms)
        {
            float t = ms - _hhT0, dt = Mathf.Min(250, ms - _hhLast); _hhLast = ms;
            // the night: up once made (made late: its own 600 ms fade from then)
            if (_hhNight == null && _hhWork != null && _hhWork.IsCompleted)
            {
                var night = _hhWork.Status == TaskStatus.RanToCompletion ? _hhWork.Result : null;
                _hhWork = null;
                if (night != null)
                {
                    _hhNight = Picture("hh night", _world, TexOf(night, _hhW, _hhH), _hhPos, _hhS, SceneOrder + 3); _hhMade.Add(_hhNight.gameObject);
                    _hhNight.color = new Color(1, 1, 1, 0);
                    _hhNightAt = ms;
                    foreach (var lit in _lights)
                    {
                        var L = lit.L;
                        if (L.Rgb == null) continue;
                        lit.Sr = Picture("hh light", _world, TexOf(L.Rgb, L.PW, L.PH), _hhPos + new Vector2(L.PX * _hhS, L.PY * _hhS), _hhS, SceneOrder + 6); _hhMade.Add(lit.Sr.gameObject);
                        lit.Sr.color = new Color(1, 1, 1, 0);
                        L.Rgb = null;
                    }
                    // the door's own quad goes under the night now (the night has it, open, then its light)
                    if (_door != null) _door.SetActive(false);
                }
                else _hhNoNight = true;
            }
            if (_hhNight != null)
            {
                float nf = t < 900 ? Mathf.Max(Ease3(ms, _hhT0, 900), 0) : 1;
                float late = Ease3(ms, _hhNightAt, 600);
                _hhNight.color = new Color(1, 1, 1, _hhNightAt - _hhT0 < 300 ? nf : late);
            }
            // the stars (1.2 s after 0.5 s), each twinkling .35 <-> 1 over 2.4 s from its delay
            float so = Ease3(ms, _hhT0 + 500, 1200);
            foreach (var (sr, delay) in _hhStars)
            {
                float st = t / 1000f - delay, tw = 1;
                if (st >= 0) { float p = Mathf.Repeat(st, 2.4f) / 2.4f; float e = p < 0.5f ? EaseInOutCss(p / 0.5f) : 1 - EaseInOutCss((p - 0.5f) / 0.5f); tw = Mathf.Lerp(0.35f, 1, 1 - e); }
                sr.color = new Color(1, 1, 1, so * tw);
            }
            // the moon (1 s after 0.4 s, rising 10 px over 1.2 s)
            if (_hhMoon != null)
            {
                Opacity(_hhMoon, Ease3(ms, _hhT0 + 400, 1000));
                float rise = 10 * (_h / _layout.reference.dp[1]) * (1 - Ease3(ms, _hhT0 + 400, 1200));
                float pad = 16 * (_h / _layout.reference.dp[1]);
                _hhMoon.transform.localPosition = World(new Vector2(_w * 0.91f - 52 * (_h / _layout.reference.dp[1]) - pad, _h * 0.08f - pad + rise));
            }
            // the lettering and the tip (600 ms in; 350 ms out as the camera goes), the tip turning every 3 s
            float ui = _hhUiOut < 0 ? Ease3(ms, _hhT0, 600) : 1 - Ease3(ms, _hhUiOut, 350);
            Opacity(_hhTitle, ui);
            // (every 3 s: .sw fades it out over .25 s, 260 ms later the next tip and it fades back in)
            int n = (int)(t / 3000); float ph = t - n * 3000, tipO = 1;
            int want = (_hhTipStart + (ph >= 260 || n == 0 ? n : n - 1)) % HOME_TIPS.Length;
            if (want != _hhTipI) { _hhTipI = want; ShowTip(_hhTipI); }
            if (n >= 1) tipO = ph < 250 ? 1 - EaseCss(ph / 250f) : ph < 260 ? 0 : EaseCss(Mathf.Clamp01((ph - 260) / 250f));
            Opacity(_hhTip, ui * Mathf.Clamp01(tipO));
            // the loading's progress: easing towards 90 % while the house loads, then on to the end
            float goal = _hhReadyAt >= 0 ? 1 : 0.9f * (1 - Mathf.Exp(-t / 2400f));
            _hhP += (goal - _hhP) * (1 - Mathf.Pow(1 - (_hhReadyAt >= 0 ? 0.12f : 0.07f), dt / 16.67f));
            if (_hhReadyAt >= 0 && 1 - _hhP < 0.005f) _hhP = 1;
            // the lights as it goes: each room's at its share of 90 %, the door at 96 %
            int nR = _lights.Count - 1;
            for (int i = 0; i < _lights.Count; i++)
            {
                var L = _lights[i];
                if (L.On < 0 && _hhNight != null && (i < nR ? _hhP >= (i + 1f) / (nR + 1) * 0.9f : _hhP >= 0.96f)) L.On = ms;
                if (L.On >= 0 && L.Sr != null) { float d = i < nR ? 500 : 450, o = EaseOutCss(Mathf.Clamp01((ms - L.On) / d)); L.Sr.color = new Color(1, 1, 1, o); L.Done = o >= 1; }
                else if (L.On >= 0) L.Done = true;
            }
            // (no night made: the lights don't come; the trip goes on)
            if (_hhNight == null && (_hhNoNight || _hhWork == null)) foreach (var L in _lights) L.Done = true;
            if (_hhP >= 1 && t >= HhMin && !_hhGone) { _hhGone = true; _hhUiOut = ms; return true; }
            return _hhGone;
        }

        void KillHeading()
        {
            foreach (var o in _hhMade) if (o != null) { if (o is RenderTexture r) r.Release(); Kill(o); }
            _hhMade.Clear(); _hhStars.Clear(); _hhTipRt.Clear();
            _hhNight = null; _hhMoon = null; _hhTitle = null; _hhTip = null; _lights = null; _hhWork = null; _hhT0 = -1;
        }

    }
}
