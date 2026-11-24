// MY HOUSE: the walk to the door and the camera's flight in through it, and back out (Main Menu.dc.html main-menu.js
// goHome / back with app/menu.js M.zoom): the HUD, the hot spots and the name plate go; the creature turns its back to
// us (430 ms, its recorded clip <key>-home-enter: spinOff + 180) and walks up the path to the doorway (1250 ms,
// tween's ease-in-out: stageAt, from the pad (500, 421) to (DOOR x, 300) and down to 0.26 of its size about 50 % / 95.5 %
// of its box, bobbing (mmBob .32 s: up 5 % and -2 -> 2°), fading out over the last 16 %); then the camera flies in:
// the world scaled 1 -> 6.2 about the door (DOOR, 500, 282) over 900 ms (t³), the door's warm veil (a radial gradient
// round the door: #fffdf0, #ffe9a8 40 %, #ffc25e) fading in from 45 % of it. The house opens under the veil. Coming
// back: the world out from 6.2 over 850 ms (1 - (1 - t)³) as the veil fades (gone at 55 %), the creature walks back
// down facing us (1100 ms, fading in over the first 16 %), then the HUD comes back and it plays 'happy'.
// The door swings open as it nears (doorOpen: the door's group squeezed to 0.18 of its width about its left edge and
// skewed -6°, the warm doorway light coming on behind it), drawn here over the house's picture from main-menu-scene.js's
// own door (its colour by the house's tier) and shut again on the way back.
// Between the walk and the flight: develop's "Heading home" (app/menu.js M.headingHome, MenuView.Heading.cs): night
// falls on the house and its rooms light up while the house loads (GoHome's `load`, told done by HomeLoaded); the
// flight starts once it has (and after 2 s at least).
using System;
using SquishSquad.Creatures;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        const float TurnMs = 430, WalkMs = 1250, ZoomInMs = 900, ZoomOutMs = 850, WalkBackMs = 1100, DoorX = 500, DoorY = 282, PadY = 421, PathY = 300;
        float _homeT = -1; Action _onHome; SpriteRenderer _veil; Texture2D _veilTex;
        GameObject _door; RenderTexture _doorRt; Mesh _doorMesh; float _doorDrawn = -1;
        static float EaseInOutCss(float x)   // CSS ease-in-out (cubic-bezier(.42,0,.58,1)): mmBob's timing
        {
            if (x <= 0 || x >= 1) return x;
            float lo = 0, hi = 1, t = x;
            for (int i = 0; i < 24; i++) { t = (lo + hi) / 2; float bx = 3 * (1 - t) * (1 - t) * t * .42f + 3 * (1 - t) * t * t * .58f + t * t * t; if (bx < x) lo = t; else hi = t; }
            return 3 * (1 - t) * t * t + t * t * t;
        }

        /// <summary>MY HOUSE: starts the walk to the door; `load` runs as "Heading home" comes on (the house's loading:
        /// HomeLoaded() once it's in), `arrived` once the camera is through the door (the house opens). Without `load`, the
        /// flight follows the walk at once.</summary>
        public bool GoHome(float nowMs, Action arrived, Action load = null)
        {
            if (Where != Place.Home) return false;
            Where = Place.ToHouse; _homeT = nowMs; _onHome = arrived; _hhLoad = load; _hhLoaded = false; _hhT0 = -1; _zoomT0 = -1;
            Fade(0, nowMs);
            if (!(_idle is IHouseRig)) Clip("home-enter");   // (a live rig turns by its yaw, below)
            return true;
        }

        /// <summary>Back from the house: the flight out and the walk back down the path.</summary>
        public void BackFromHouse(float nowMs)
        {
            if (Where != Place.House) return;
            Where = Place.FromHouse; _homeT = nowMs;
            if (Creature != null && _idle != null) { _clip = null; Creature.SetFrames(_idle); }
            if (_idle is IHouseRig hr) hr.Yaw(0);
        }

        void TickHome(float ms)
        {
            if (Where != Place.ToHouse && Where != Place.House && Where != Place.FromHouse) return;
            float t = ms - _homeT;
            if (Where == Place.ToHouse)
            {
                if (_idle is IHouseRig hr) hr.Yaw(180 * EIO(Mathf.Clamp01(t / TurnMs)));
                float wt = Mathf.Clamp01((t - TurnMs) / WalkMs);
                bool walking = t > TurnMs && t < TurnMs + WalkMs;
                Stage(EIO(wt), wt > 0.84f ? Mathf.Max(0, 1 - (wt - 0.84f) / 0.16f) : 1, walking ? t - TurnMs : -1);
                if (_hhNight == null) Door(Mathf.Clamp01((wt - 0.35f) / 0.45f));   // (under the night: the night has it)
                float zt;
                if (_hhLoad != null)
                {
                    // Heading home, then the flight once the house is in
                    if (t < TurnMs + WalkMs) { Zoom(1, 0); return; }
                    if (_hhT0 < 0) StartHeading(ms);
                    if (TickHeading(ms) && _zoomT0 < 0) _zoomT0 = ms;
                    zt = _zoomT0 < 0 ? 0 : Mathf.Clamp01((ms - _zoomT0) / ZoomInMs);
                }
                else zt = Mathf.Clamp01((t - TurnMs - WalkMs) / ZoomInMs);
                Zoom(1 + 5.2f * zt * zt * zt, zt > 0.45f ? Mathf.Min(1, (zt - 0.45f) / 0.5f) : 0);
                if (zt >= 1) { if (_hhT0 >= 0) KillHeading(); Where = Place.House; var a = _onHome; _onHome = null; a?.Invoke(); }
                return;
            }
            if (Where == Place.House) { Zoom(6.2f, 1); return; }
            // back: the flight out, then the walk down
            float ot = Mathf.Clamp01(t / ZoomOutMs), e = 1 - Mathf.Pow(1 - ot, 3);
            Zoom(1 + 5.2f * (1 - e), Mathf.Max(0, 1 - ot / 0.55f));
            float bt = Mathf.Clamp01((t - ZoomOutMs) / WalkBackMs);
            Stage(1 - EIO(bt), Mathf.Min(1, bt / 0.16f), t > ZoomOutMs && t < ZoomOutMs + WalkBackMs ? t - ZoomOutMs : -1);
            Door(Mathf.Max(0, 1 - bt / 0.7f));
            if (bt < 1) return;
            Where = Place.Home; Zoom(1, 0); Stage(0, 1, -1); Door(0); Fade(1, ms);
            Creature?.Play("happy");
        }

        // stageAt(e): the creature from the pad (0) to the doorway (1), its opacity, the walk's bob (ms into it, or -1)
        void Stage(float e, float opacity, float bobMs)
        {
            if (Creature == null) return;
            var piece = _pieces.Find(x => x.Data.id == "creature"); if (piece == null) return;
            var box = piece.Hit;
            float s = 1 - 0.74f * e, dy = (PathY - PadY) * _k * e;
            float px = box.x + box.width * 0.5f, py = box.y + box.height * 0.955f;   // (transform-origin 50% 95.5%)
            float bobY = 0, rot = 0;
            if (bobMs >= 0)
            {
                float p = Mathf.Repeat(bobMs, 320) / 320, u = p < 0.5f ? EaseInOutCss(p / 0.5f) : 1 - EaseInOutCss((p - 0.5f) / 0.5f);
                bobY = -0.05f * box.height * u; rot = -2 + 4 * u;
            }
            // the quad's top-left (page px) through: the bob (about the box's centre), then the stage's scale about its
            // origin, then its move
            Vector2 o = new Vector2(_creatureHome.x, -_creatureHome.y), c = new Vector2(box.x + box.width / 2, box.y + box.height / 2);
            float a = rot * Mathf.Deg2Rad; Vector2 q = o - c; q = new Vector2(q.x * Mathf.Cos(a) - q.y * Mathf.Sin(a), q.x * Mathf.Sin(a) + q.y * Mathf.Cos(a)) + c + new Vector2(0, bobY);
            Vector2 f = new Vector2(px + s * (q.x - px), py + s * (q.y - py) + dy);
            Creature.transform.localPosition = World(f);
            Creature.transform.localRotation = Quaternion.Euler(0, 0, -rot);
            Creature.transform.localScale = new Vector3(s, s, 1);
            Creature.SetOpacity(opacity);
        }

        // doorOpen(t): main-menu-scene.js's front door (the doorway, its light, the door's group) over the house's picture,
        // the group turned as main-menu.js does it (transform-box fill-box, origin 0% 50%: scaleX(1 - 0.82 t)
        // skewY(-6 t deg)), the light's opacity t; nothing drawn while it's shut (the picture has it)
        void Door(float t)
        {
            t = Mathf.Round(t * 60) / 60;
            if (t <= 0) { if (_door != null) _door.SetActive(false); _doorDrawn = 0; return; }
            float x0 = 480, y0 = 244, w = 40, h = 60, k = _k;
            if (_door == null)
            {
                int pw = Mathf.Max(8, Mathf.CeilToInt(w * k)), ph = Mathf.Max(8, Mathf.CeilToInt(h * k));
                _doorRt = new RenderTexture(pw, ph, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = "door", hideFlags = HideFlags.HideAndDontSave }; _doorRt.Create(); _made.Add(_doorRt);
                _door = new GameObject("door"); _door.transform.SetParent(_world, false); _made.Add(_door);
                _door.transform.localPosition = World(new Vector2(_ox + x0 * k, _oy + y0 * k));
                _doorMesh = new Mesh { name = "door quad", hideFlags = HideFlags.HideAndDontSave }; _made.Add(_doorMesh);
                float qw = pw, qh = ph;
                _doorMesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(qw, 0, 0), new Vector3(qw, -qh, 0), new Vector3(0, -qh, 0) });
                _doorMesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
                _doorMesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
                _door.AddComponent<MeshFilter>().sharedMesh = _doorMesh;
                var mr = _door.AddComponent<MeshRenderer>(); var mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = _doorRt, hideFlags = HideFlags.HideAndDontSave }; _made.Add(mat);
                mr.sharedMaterial = mat; mr.sortingOrder = SceneOrder + 1;
            }
            _door.SetActive(true);
            if (t == _doorDrawn) return;
            _doorDrawn = t;
            // (main-menu-scene.js: the door's colour by the house's tier, L < 5, < 15, < 25, else; OL the outline)
            int tier = Level < 5 ? 0 : Level < 15 ? 1 : Level < 25 ? 2 : 3;
            string door = tier >= 3 ? "#7a2a3a" : tier == 0 ? "#8a6a52" : "#a0643a", OL = "#4a3a2e";
            Color dc; ColorUtility.TryParseHtmlString(door, out dc); var dk = Color.Lerp(dc, Color.black, 0.25f); string seam = "#" + ColorUtility.ToHtmlStringRGB(dk).ToLowerInvariant();
            string F(float v) => v.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
            string arch = "M488 300 V259 A12 12 0 0 1 512 259 V300Z";
            var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + F(w) + "\" height=\"" + F(h) + "\" viewBox=\"" + F(x0) + " " + F(y0) + " " + F(w) + " " + F(h) + "\">"
                + "<defs><radialGradient id=\"mmDoorL\" cx=\"0.5\" cy=\"0.7\" r=\"0.8\"><stop offset=\"0\" stop-color=\"#fffbe6\"/><stop offset=\"0.55\" stop-color=\"#ffe39a\"/><stop offset=\"1\" stop-color=\"#ffb84a\"/></radialGradient></defs>"
                + "<path d=\"" + arch + "\" fill=\"#3a2418\"/><path d=\"" + arch + "\" fill=\"url(#mmDoorL)\" opacity=\"" + F(t) + "\"/>"
                + "<g transform=\"translate(488 273.5) scale(" + F(1 - 0.82f * t) + " 1) skewY(" + F(-6 * t) + ") translate(-488 -273.5)\">"
                + "<path d=\"" + arch + "\" fill=\"" + door + "\" stroke=\"" + OL + "\" stroke-width=\"1.1\"/><path d=\"M494 298 V262 M500 298 V256 M506 298 V262\" stroke=\"" + seam + "\" stroke-width=\"0.8\"/>"
                + "<circle cx=\"500\" cy=\"263\" r=\"4.2\" fill=\"#fff4d0\" stroke=\"" + OL + "\" stroke-width=\"0.9\"/><circle cx=\"507\" cy=\"281\" r=\"1.6\" fill=\"#ffd66b\" stroke=\"#8a6a1a\" stroke-width=\"0.5\"/></g>"
                + DoorFront(OL) + "</svg>";
            using (var vr = new VectorRenderer()) vr.Render(SvgScene.Compile(SvgMarkup.Parse(svg), _doorRt.width, _doorRt.height, Affine.Identity, null), _doorRt);
        }

        // what main-menu-scene.js draws after the door, over its foot: the two steps and the house's foundation strip
        // (x 417, 166 wide, its joints every 14 from 425), clipped to the door's box
        internal static string DoorFront(string OL) =>
            "<rect x=\"478\" y=\"300\" width=\"44\" height=\"5\" rx=\"1\" fill=\"#b8ab98\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<rect x=\"472\" y=\"304\" width=\"56\" height=\"5\" rx=\"1\" fill=\"#a89a86\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<rect x=\"417\" y=\"293\" width=\"166\" height=\"8\" fill=\"#b8ab98\" stroke=\"" + OL + "\" stroke-width=\"1\"/>"
            + "<path d=\"M481 293 V301 M495 293 V301 M509 293 V301\" stroke=\"#8a7c6a\" stroke-width=\"0.7\"/>";

        // the world scaled `k` about the door, the veil at `veil`
        void Zoom(float k, float veil)
        {
            var d = World(new Vector2(_ox + DoorX * _k, _oy + DoorY * _k));
            _world.localScale = new Vector3(k, k, 1);
            _world.localPosition = new Vector3(d.x - k * d.x, d.y - k * d.y, 0);
            if (veil <= 0) { if (_veil != null) _veil.enabled = false; return; }
            if (_veil == null)
            {
                // radial-gradient(circle at the door, #fffdf0 0%, #ffe9a8 40%, #ffc25e 100%): farthest-corner
                int tw = Mathf.Max(8, Mathf.CeilToInt(_w / 4)), th = Mathf.Max(8, Mathf.CeilToInt(_h / 4));
                _veilTex = new Texture2D(tw, th, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, hideFlags = HideFlags.HideAndDontSave };
                float cx = (_ox + DoorX * _k) / 4, cy = (_oy + DoorY * _k) / 4;
                float R = Mathf.Max(Mathf.Max(new Vector2(cx, cy).magnitude, new Vector2(tw - cx, cy).magnitude), Mathf.Max(new Vector2(cx, th - cy).magnitude, new Vector2(tw - cx, th - cy).magnitude));
                Color c0 = new Color32(0xff, 0xfd, 0xf0, 0xff), c1 = new Color32(0xff, 0xe9, 0xa8, 0xff), c2 = new Color32(0xff, 0xc2, 0x5e, 0xff);
                var px = new Color[tw * th];
                for (int y = 0; y < th; y++) for (int x = 0; x < tw; x++)
                {
                    float r = new Vector2(x + 0.5f - cx, y + 0.5f - cy).magnitude / R;
                    px[(th - 1 - y) * tw + x] = r < 0.4f ? Color.Lerp(c0, c1, r / 0.4f) : Color.Lerp(c1, c2, (r - 0.4f) / 0.6f);
                }
                _veilTex.SetPixels(px); _veilTex.Apply(false, true); _made.Add(_veilTex);
                _veil = Picture("door veil", _root, _veilTex, Vector2.zero, 4, 5000);
            }
            _veil.enabled = true;
            var col = _veil.color; col.a = veil; _veil.color = col;
        }
    }
}
