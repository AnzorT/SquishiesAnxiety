// MY HOUSE: the walk to the door and the camera's flight in through it, and back out (Main Menu.dc.html main-menu.js
// goHome / back with app/menu.js M.zoom): the HUD, the hot spots and the name plate go; the creature turns its back to
// us (430 ms, its recorded clip <key>-home-enter: spinOff + 180) and walks up the path to the doorway (1250 ms,
// tween's ease-in-out: stageAt, from the pad (500, 421) to (DOOR x, 300) and down to 0.26 of its size about 50 % / 95.5 %
// of its box, bobbing (mmBob .32 s: up 5 % and -2 -> 2°), fading out over the last 16 %); then the camera flies in:
// the world scaled 1 -> 6.2 about the door (DOOR, 500, 282) over 900 ms (t³), the door's warm veil (a radial gradient
// round the door: #fffdf0, #ffe9a8 40 %, #ffc25e) fading in from 45 % of it. The house opens under the veil. Coming
// back: the world out from 6.2 over 850 ms (1 - (1 - t)³) as the veil fades (gone at 55 %), the creature walks back
// down facing us (1100 ms, fading in over the first 16 %), then the HUD comes back and it plays 'happy'.
// Not here yet: the door's opening (main-menu.js doorOpen: the scene's door is in the house's picture) and develop's
// "Heading home" screen between the walk and the flight (app/menu.js M.headingHome: night falls on the house, its rooms
// light up as the house loads, the wooden bar and a tip): the flight follows the walk at once.
using System;
using SquishSquad.Creatures;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        const float TurnMs = 430, WalkMs = 1250, ZoomInMs = 900, ZoomOutMs = 850, WalkBackMs = 1100, DoorX = 500, DoorY = 282, PadY = 421, PathY = 300;
        float _homeT = -1; Action _onHome; SpriteRenderer _veil; Texture2D _veilTex;
        static float EaseInOutCss(float x)   // CSS ease-in-out (cubic-bezier(.42,0,.58,1)): mmBob's timing
        {
            if (x <= 0 || x >= 1) return x;
            float lo = 0, hi = 1, t = x;
            for (int i = 0; i < 24; i++) { t = (lo + hi) / 2; float bx = 3 * (1 - t) * (1 - t) * t * .42f + 3 * (1 - t) * t * t * .58f + t * t * t; if (bx < x) lo = t; else hi = t; }
            return 3 * (1 - t) * t * t + t * t * t;
        }

        /// <summary>MY HOUSE: starts the walk to the door; `arrived` runs once the camera is through it (the house opens).</summary>
        public bool GoHome(float nowMs, Action arrived)
        {
            if (Where != Place.Home) return false;
            Where = Place.ToHouse; _homeT = nowMs; _onHome = arrived;
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
                float zt = Mathf.Clamp01((t - TurnMs - WalkMs) / ZoomInMs);
                Zoom(1 + 5.2f * zt * zt * zt, zt > 0.45f ? Mathf.Min(1, (zt - 0.45f) / 0.5f) : 0);
                if (zt >= 1) { Where = Place.House; var a = _onHome; _onHome = null; a?.Invoke(); }
                return;
            }
            if (Where == Place.House) { Zoom(6.2f, 1); return; }
            // back: the flight out, then the walk down
            float ot = Mathf.Clamp01(t / ZoomOutMs), e = 1 - Mathf.Pow(1 - ot, 3);
            Zoom(1 + 5.2f * (1 - e), Mathf.Max(0, 1 - ot / 0.55f));
            float bt = Mathf.Clamp01((t - ZoomOutMs) / WalkBackMs);
            Stage(1 - EIO(bt), Mathf.Min(1, bt / 0.16f), t > ZoomOutMs && t < ZoomOutMs + WalkBackMs ? t - ZoomOutMs : -1);
            if (bt < 1) return;
            Where = Place.Home; Zoom(1, 0); Stage(0, 1, -1); Fade(1, ms);
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
