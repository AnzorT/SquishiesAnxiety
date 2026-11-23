// The Squad House screen (HOUSE_PORT_PLAN.md stages 2-3): the room (HouseRoomView: the base and each piece in layers)
// in the 852 x 393 frame scaled to the screen's width, the camera easing between rooms, the squad (HouseCreatures +
// HouseSquadView: walking about, sorted between the pieces, tapped to select, sent by a floor tap, carried through a
// door), the bottom drawer (its tab opens and closes it; RENOVATE opens Renovate: HouseEditView, stage 6; CATALOG the
// Catalog: HouseShopView, stage 7, its coins through Coins / Spend) and the toasts,
// as Squad House v6.dc.html; the save every 5 s and on each room change (OnSave). Not yet: actions (4), item taps (5),
// the house map (8: until then the rooms change by their doors and GoTo).
//
//   var s = HouseScreen.Create(parent, houseJson, level, ownedRosterIds);   s.OnExit = ...;   (Android's back leaves)
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.House.View
{
    public sealed class HouseScreen : MonoBehaviour
    {
        public Action OnExit;
        /// <summary>Called with the save's JSON after each change the page saves (the room entered).</summary>
        public Action<string> OnSave;
        /// <summary>The app's wallet for the Catalog: the coins now, and spending them (false: not enough).</summary>
        public Func<double> Coins = () => 0;
        public Func<double, bool> Spend = n => false;

        HouseRoomView _room;
        HouseCreatures _sim;
        HouseSquadView _squad;
        HouseWheel _wheel;
        HouseEditView _edit;
        HouseShopView _shop;
        bool _dirty;
        string _press; double _pressX, _pressY; bool _moved;
        double _saveAt;
        readonly HouseCamera _cam = new HouseCamera();
        HouseHud _hud;
        UiPiece _tab, _arrow, _panel, _toast;
        string _toastDrawn;
        Camera _camera;
        float _w, _h, _k;
        string _json, _start;
        int _level;
        IList<int> _owned;
        bool _down;
        Vector2 _downAt;

        public static HouseScreen Create(Transform parent, string houseJson, int level, IList<int> ownedRosterIds, string room = "living")
        {
            var go = new GameObject("HouseScreen");
            go.transform.SetParent(parent, false);
            var s = go.AddComponent<HouseScreen>();
            s._json = houseJson; s._level = level; s._owned = ownedRosterIds ?? new List<int>(); s._start = room;
            return s;
        }

        double Now => Time.unscaledTimeAsDouble * 1000;

        void Start()
        {
            _w = Screen.width; _h = Screen.height; _k = _w / 852f;
            _camera = gameObject.AddComponent<Camera>();
            _camera.orthographic = true;
            _camera.orthographicSize = _h / 2f;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color32(0xf6, 0xea, 0xd8, 0xff);
            _camera.nearClipPlane = -10; _camera.farClipPlane = 10;
            transform.localPosition = new Vector3(_w / 2f, -_h / 2f, -5f);
            var world = new GameObject("world").transform;
            world.SetParent(transform.parent, false);
            _room = world.gameObject.AddComponent<HouseRoomView>();
            _room.Load(_json, _level, _owned, _start);
            _hit = new List<HouseRoomView.Piece>();
            var walkJson = HouseRoomView.Res("walk");
            _sim = new HouseCreatures(_room.Save, new HouseWalk(walkJson));
            _sim.SetMoves(walkJson);
            _sim.Toast = Toast;
            _sim.HasFront = id => _room.Fronts.TryGetValue(id, out var f) && f;
            _sim.Saved = Save;
            _sim.RoomChanged = () => _dirty = true;   // (drawn once a frame, in Update)
            _room.Sim = _sim;
            _sim.Init(Now, _start);
            _room.Draw(_w, _h);
            _cam.Set(_room.RoomK, Now, false);
            _room.SetCamera(_cam.K(Now));
            _squad = new HouseSquadView(world, _sim, _k);
            _squad.Rebuild();
            _saveAt = Now + 5000;

            _hud = new HouseHud(HouseRoomView.Res("hud"));
            _wheel = new HouseWheel(world, _sim, _k, (JObj)HouseJson.Parse(HouseRoomView.Res("hud")));
            _tab = Piece("hud tab", 31001, "tab");
            _arrow = Piece("hud arrow", 31002, "arrow");
            _panel = Piece("hud panel", 31000, "panel");
            _edit = new HouseEditView(world, _sim, _k, HouseRoomView.Res("edit")) { Toast = Toast, Pic = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : HouseRoomView.Res("pics/" + n) };
            _shop = new HouseShopView(world, _sim, _k, HouseRoomView.Res("shop")) { Pic = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : HouseRoomView.Res("pics/" + n) };
            _sim.Coins = () => Coins(); _sim.Spend = n => Spend(n);
            _sim.GoRoom = room => Enter(room, null, null, Now);
            _toast = UiPiece.Create(world, "toast", 31100);
            _toast.Opacity = 0;
        }

        UiPiece Piece(string name, int order, string id)
        {
            var p = UiPiece.Create(_room.transform, name, order);
            var r = _hud.Pieces[id];
            p.SetSvg(HouseRoomView.Res("hud/" + id), (float)r.W, (float)r.H, 12);
            return p;
        }

        JObj Shell() => new RoomModel(_room.Save).ShellOf(_room.Save.Cur);

        // frame px -> UiPiece's dp (the frame is scaled to the screen's width)
        Affine Frame => Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp);

        void Update()
        {
            if (_room == null) return;
            double now = Now;
            if (Input.GetKeyDown(KeyCode.Escape)) { OnExit?.Invoke(); Destroy(gameObject); return; }
            HandleInput(now);
            _sim.Tick(now);
            if (_dirty) { _dirty = false; _room.Draw(_w, _h); }
            double k = _cam.K(now);
            _room.SetCamera(k);
            _edit.SetCamera(k); _edit.Update(now);
            _shop.Update(now);
            _squad.Update(k, now);
            MoveToy(now);
            _wheel.Update(k, now);
            if (now >= _saveAt) { _saveAt = now + 5000; Save(); }
            // the drawer (translate(-50%, ty): its pieces' rects are at ty 0), the arrow turning about its centre
            double ty = _hud.DrawerTy(now);
            var tab = _hud.Pieces["tab"]; var panel = _hud.Pieces["panel"]; var arrow = _hud.Pieces["arrow"];
            _tab.Visible = _arrow.Visible = _panel.Visible = !_sim.Edit;   // (notEdit)
            _tab.Transform = Frame * Affine.Translate(tab.X, tab.Y + ty);
            _panel.Transform = Frame * Affine.Translate(panel.X, panel.Y + ty);
            _arrow.Transform = Frame * Affine.Translate(arrow.X + arrow.W / 2, arrow.Y + ty + arrow.H / 2) * Affine.Rotate(_hud.ArrowDeg(now)) * Affine.Translate(-arrow.W / 2, -arrow.H / 2);
            DrawToast(now);
        }

        // the page's toast: centred at the top (left 50%, top 58 px), turned -1.2 deg, cream with a brown ring
        void DrawToast(double now)
        {
            var t = _hud.ToastAt(now);
            if (t == null) { _toast.Opacity = 0; return; }
            var (text, op, dy) = t.Value;
            var style = new TextStyle { Font = "Fredoka_600SemiBold", Size = 13.5f, Color = "#5b3418" };
            float tw = UiSvg.BoxWidth(text, style), lh = UiSvg.LineBox(style);
            float w = tw + 28, h = lh + 12;
            string key = text + "|" + _hud.ToastKey;
            if (_toastDrawn != key)
            {
                var s = new UiSvg(w, h).Box(0, 0, w, h, new BoxStyle
                {
                    Background = "#fff6e2", Radius = 7,
                    Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 2), new Shadow("rgba(107,68,38,0.35)", 0, 3, 0, 2), new Shadow("rgba(60,30,10,0.25)", 0, 8, 14, 0) },
                });
                s.Text(text, 14, 6, style);
                _toast.SetSvg(s.Markup, w, h, 24);
                _toastDrawn = key;
            }
            _toast.Opacity = (float)op;
            _toast.Transform = Frame * Affine.Translate(426, 58 + dy + h / 2) * Affine.Rotate(-1.2) * Affine.Translate(-w / 2, -h / 2);
        }

        void Toast(string text) => _hud.ShowToast(text, Now);

        List<HouseRoomView.Piece> _hit;

        // the rolling toy (rollStep): its layer follows the roll and its depth (the spin of its inner part isn't drawn)
        void MoveToy(double now)
        {
            if (_sim.Rolling == null) { foreach (var p in _room.Pieces) if (p.Kind == "toy") { p.Dx = 0; p.Dy = 0; } return; }
            int ix = _sim.Toys().IndexOf(_sim.Rolling.Y);
            foreach (var p in _room.Pieces)
            {
                if (p.Kind != "toy" || p.Toy != ix) continue;
                var (x, y, hop, _) = _sim.RollAt(now);
                p.Dx = x - _sim.Rolling.X0; p.Dy = y - _sim.Rolling.Y0 - hop;
                if (p.Renderer != null) p.Renderer.sortingOrder = HouseRoomView.OrderOf(Math.Round(y));
            }
        }

        // a press, a hold (Renovate's drags: a piece, the light, the rotation slider, the tray's scroll) and a release
        void HandleInput(double now)
        {
            bool down = Input.GetMouseButtonDown(0), up = Input.GetMouseButtonUp(0), held = Input.GetMouseButton(0);
            Vector2 pos = Input.mousePosition;
            if (Input.touchCount > 0) { var t = Input.GetTouch(0); pos = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up; }
            double fx = pos.x / _k, fy = (_h - pos.y) / _k, k = _cam.K(now);
            var b = HouseCamera.ToBox(fx, fy, k);
            if (down)
            {
                _down = true; _downAt = pos; _moved = false; _pressX = fx; _pressY = fy; _press = null;
                if (_sim.Shop) { _press = "shop"; return; }   // (the Catalog covers everything: its taps on release)
                if (_sim.Edit) EditPress(fx, fy, b.x, b.y, now);
                return;
            }
            if (!_down) return;
            if ((pos - _downAt).magnitude > 12 * _k) _moved = true;
            if (held && !up)
            {
                switch (_press)
                {
                    case "slider": _edit.SliderAt(fx, now); break;
                    case "tray": if (_moved) { _edit.TrayScroll(fx - _pressX); _pressX = fx; } break;
                    case "light": _sim.LightMove(b.x); break;
                    case "drag": _sim.DragMove(b.x, b.y); break;
                }
                return;
            }
            if (!up) return;
            _down = false;
            var pr = _press; _press = null;
            switch (pr)
            {
                case "slider": _sim.RotEnd(); return;
                case "tray": if (!_moved) _edit.TrayTap(fx); return;
                case "ui": if (!_moved) _edit.Tap(fx, fy, now); return;
                case "light": _sim.LightUp(); return;
                case "drag": _sim.DragEnd(); return;
                case "none": return;
                case "shop": if (!_moved) _shop.Tap(fx, fy, now); return;
            }
            if (_moved) return;   // (a drag, not a tap)
            Tap(fx, fy, now);
        }

        // Renovate: the edit UI first, then the light's handle, a piece (picked up: itemDown), the floor (the selection goes)
        void EditPress(double fx, double fy, double bx, double by, double now)
        {
            var e = _edit.Press(fx, fy, now);
            if (e == "slider") { _press = "slider"; _sim.RotStart(); _edit.SliderAt(fx, now); return; }
            if (e != null) { _press = e; return; }
            if (_edit.OnLight(bx, by)) { _press = "light"; _sim.LightDown(bx); return; }
            var top = PieceAt(fx, fy, _cam.K(now));
            if (top != null && top.Kind != "toy" && top.Id != null) { _press = "drag"; _sim.EditDown(top.Id, bx, by, now); return; }
            _press = "none"; _sim.EditFloorTap();
        }

        HouseRoomView.Piece PieceAt(double fx, double fy, double k)
        {
            var pb = HouseCamera.ToBox(fx, fy, k); double gx = pb.x, gy = pb.y + HouseFrame.BoxTop;
            HouseRoomView.Piece top = null;
            foreach (var p in _room.Pieces)
            {
                if (p.Kind == "prop" || p.Box == null) continue;
                if (gx >= p.Box[0] + p.Dx && gx <= p.Box[0] + p.Dx + p.Box[2] && gy >= p.Box[1] + p.Dy && gy <= p.Box[1] + p.Dy + p.Box[3] && (top == null || p.Z >= top.Z)) top = p;
            }
            return top;
        }

        /// <summary>A tap at a frame point (852 x 393 px): the drawer, a door, or the floor.</summary>
        public void Tap(double fx, double fy, double now)
        {
            if (_sim.Edit) return;   // (Renovate's presses are handled as they happen)
            if (_hud.Covers(fx, fy, now))
            {
                switch (_hud.Tap(fx, fy, now))
                {
                    case "tab": _hud.SetOpen(!_hud.Open, now); break;
                    case "renovate": _hud.SetOpen(false, now); _wheel.SetOpen(false, now); _sim.StartEdit(); break;
                    case "catalog": _hud.SetOpen(false, now); _sim.OpenCat(); break;
                }
                return;
            }
            double k = _cam.K(now);
            // the wheel (z-index 875: over the creatures), then a creature, a door, the floor
            var w = _wheel.Tap(fx, fy, k);
            if (w == "open") { _wheel.SetOpen(true, now); return; }
            if (w == "close") { _wheel.SetOpen(false, now); return; }
            if (w != null)
            {
                _wheel.SetOpen(false, now);
                foreach (var q in HouseCreatures.QA) if (q.Id == w) _sim.QaGo(q, now, (room, c) => Enter(room, c, null, Now));
                return;
            }
            int hit = _squad.HitCreature(fx, fy, k);
            if (hit >= 0) { _sim.TapCreature(hit, now); _wheel.SetOpen(false, now); return; }
            // a piece or a toy (its box; the topmost by z-index): itemDown, kick
            var top = PieceAt(fx, fy, k);
            if (top != null)
            {
                _wheel.SetOpen(false, now);
                if (top.Kind == "toy") { var toys = _sim.Toys(); if (top.Toy >= 0 && top.Toy < toys.Count) _sim.Kick(toys[top.Toy], now); }
                else if (top.Id != null) _sim.ItemDown(top.Id, now);
                return;
            }
            var b = HouseCamera.ToBox(fx, fy, k);
            var door = HouseDoors.At(Shell(), b.x, b.y);
            if (door != null) { TapDoor(door, now); return; }
            if (!_sim.FloorDown(b.x, b.y, now)) Toast("Tap a squad friend first, then tap the floor");
        }

        // tapDoor: a locked one's toast (and "Locked..." from the selected friend); else the selected friend says
        // "Coming!", walks to the door and the room changes with him, or the room changes at once
        void TapDoor(JObj d, double now)
        {
            if (_sim.Edit) return;
            var c = _sim.SelC;
            if (d.Num("lock") != 0)
            {
                Toast(HouseDoors.LockedText(d));
                if (c != null) _sim.Say(c, "Locked...", now);
                return;
            }
            string to = d.Str("to"), from = _room.Save.Cur;
            void Go() => Enter(to, c, from, Now);
            if (c != null) { _sim.Say(c, "Coming!", now); var sp = d.Arr("spawn"); _sim.GoTo(c, (double)sp[0], (double)sp[1], Go, now); }
            else Go();
        }

        /// <summary>Goes to a room (the house map's pick, a door): drawn, the camera easing to its zoom, saved.</summary>
        public void GoTo(string room) => Enter(room, null, null, Now);

        void Enter(string room, HouseCreature carry, string from, double now)
        {
            _sim.Enter(room, carry, from, now);
            _room.Draw(_w, _h);
            _cam.Set(_room.RoomK, now);
            _room.SetCamera(_cam.K(now));
            _squad.Rebuild();
            Save();   // (the page: setTimeout(save, 0))
        }

        void Save()
        {
            _sim.SyncSave();
            OnSave?.Invoke(_room.Save.ToJsonKeepingUnknown());
        }

        void OnDestroy()
        {
            _squad?.Destroy();
            _wheel?.Destroy();
            _edit?.Destroy();
            _shop?.Destroy();
            if (_room != null) Destroy(_room.gameObject);
            if (_toast != null) Destroy(_toast.gameObject);
        }
    }
}
