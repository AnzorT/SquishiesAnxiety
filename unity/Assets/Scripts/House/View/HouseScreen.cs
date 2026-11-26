// The Squad House screen (HOUSE_PORT_PLAN.md stages 2-3): the room (HouseRoomView: the base and each piece in layers)
// in the 852 x 393 frame scaled to the screen's width, the camera easing between rooms, the squad (HouseCreatures +
// HouseSquadView: walking about, sorted between the pieces, tapped to select, sent by a floor tap, carried through a
// door), the bottom drawer (its tab opens and closes it; RENOVATE opens Renovate: HouseEditView, stage 6; CATALOG the
// Catalog: HouseShopView, stage 7, its coins through Coins / Spend) and the toasts,
// as Squad House v6.dc.html; the save every 5 s and on each room change (OnSave); the house map (HouseMapView, stage 8:
// its button top-left in each room).
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
        HouseMapView _map;
        HouseMovieView _movie;
        HouseClubView _club;
        HouseBeachView _beach;
        HouseVacView _vac;
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

        /// <summary>The house for the app's player: their creatures by key (the menu's squad).</summary>
        public static HouseScreen Create(Transform parent, string houseJson, int level, IEnumerable<string> ownedKeys, string room = "living")
        {
            var s = Create(parent, houseJson, level, (IList<int>)null, room);
            s._ownedKeys = ownedKeys != null ? new List<string>(ownedKeys) : null;
            return s;
        }
        List<string> _ownedKeys;
        /// <summary>The menu's creature (the one in use): it plays the yard games.</summary>
        public string PlayerKey;
        const string MoviesKey = "squish.house.movies";

        double Now => Time.unscaledTimeAsDouble * 1000;

        void Start()
        {
            // the frame: the screen at the scale that fits 852 x 393 in it, the room in its middle (patches.mjs, app/menu.js
            // houseBox: on a taller screen more floor and ceiling show, on a wider one more of the side walls)
            _w = Screen.width; _h = Screen.height; _k = Math.Min(_w / 852f, _h / 393f);
            HouseFrame.MX = (_w / _k - 852) / 2; HouseFrame.MY = (_h / _k - 393) / 2;
            HouseCreatures.HoverNone = Application.isMobilePlatform;   // (the map's rooms don't light up under a finger)
            _camera = gameObject.AddComponent<Camera>();
            _camera.orthographic = true;
            _camera.orthographicSize = _h / 2f;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color32(0xf6, 0xea, 0xd8, 0xff);
            _camera.nearClipPlane = -10; _camera.farClipPlane = 10;
            transform.localPosition = new Vector3(_w / 2f, -_h / 2f, -5f);
            var world = new GameObject("world").transform;
            world.SetParent(transform.parent, false);
            world.localPosition = new Vector3((float)(HouseFrame.MX * _k), (float)(-HouseFrame.MY * _k), 0);
            _room = world.gameObject.AddComponent<HouseRoomView>();
            _room.Load(_json, _level, _owned, _start, _ownedKeys);
            _hit = new List<HouseRoomView.Piece>();
            var walkJson = HouseRoomView.Res("walk");
            _sim = new HouseCreatures(_room.Save, new HouseWalk(walkJson));
            _sim.SetMoves(walkJson);
            _sim.Toast = Toast;
            _sim.WeatherNow = () => SquishSquad.Menu.MenuState.Season;   // (today's weather: config/weather, else the month)
            _sim.HasFront = id => _room.Fronts.TryGetValue(id, out var f) && f;
            _sim.Saved = Save;
            _sim.RoomChanged = () => _dirty = true;   // (drawn once a frame, in Update)
            _room.Sim = _sim;
            _sim.Init(Now, _start);
            _room.Draw(852 * _k, 393 * _k);
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
            _map = new HouseMapView(world, _sim, _k, HouseRoomView.Res("map"), HouseRoomView.Res("map-bits"), HouseRoomView.Res("map-template")) { Toast = Toast };
            _sim.GoRoomWith = (room, c) => { Enter(room, c, null, Now); Veil(Now); };   // (from the map: the room comes up under the cream veil)
            // the Movie Room's movies, and where each was left (the page keeps them in localStorage: on the device here)
            var mvj = HouseRoomView.Res("movies"); JObj mvo = mvj != null ? (JObj)HouseJson.Parse(mvj) : null; if (mvo != null) _sim.Movies = mvo.Arr("list").ConvertAll(o => (JObj)o);
            try { var mp = (JObj)HouseJson.Parse(PlayerPrefs.GetString(MoviesKey, "{}")); _sim.MoviePick = mp.Str("pick"); if (mp.Obj("pos") is JObj pos) foreach (var k2 in pos.Keys) _sim.MoviePos[k2] = pos.Num(k2); } catch (Exception) { }
            _sim.MoviesChanged = () => { var pos = new JObj(); foreach (var kv in _sim.MoviePos) pos[kv.Key] = kv.Value; PlayerPrefs.SetString(MoviesKey, HouseJson.Stringify(new JObj { ["pick"] = _sim.MoviePick, ["pos"] = pos })); };
            _movie = new HouseMovieView(_room, _sim, _k, mvo?.Obj("icons"));
            _club = new HouseClubView(_room, _sim);
            _beach = new HouseBeachView(_room, _sim, _k); _sim.BeachHooks();
            _vac = new HouseVacView(_room, _sim, _k);
            // the page's toast is z-index 1100, over the Catalog and the map (1000): a BUY's "Not enough coins" shows over
            // the Catalog (it was drawn under it, so a refused BUY looked like nothing happened)
            _toast = UiPiece.Create(world, "toast", 34000);
            _toast.Opacity = 0;
            _sim.YardNew = id => { var a = YardNewList(); if (!a.Contains(id)) a.Add(id); PlayerPrefs.SetString(YardNewKey, HouseJson.Stringify(a.ConvertAll(x => (object)x))); };
            _fillT0 = Now;   // (the trip in: the bare room first, the furniture, then the creatures one by one)
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

        // the backyard's YARD GAMES button (webgame/app/games.js ensureBtn, tick: the menu's gold tab at the house box's top
        // right, right 22 px, top 14 px; in the backyard when no map, Catalog, Renovate, detail or party is up) and its NEW
        // badge (a game bought since the Yard Games were last opened, pulsing 1 -> 1.14 over 1.4 s), both cut from the
        // menu's page by tools/unity/house/export-hud.mjs; it opens the yard games' page over the house (Games/Yard/View)
        SquishSquad.Games.Yard.View.YardScreen _yard; UiPiece _yardBtn, _yardNew;
        const string YardNewKey = "squishsquad.yard.new.v1";   // (games.js NEWK: the games bought, until the page is seen)
        static List<string> YardNewList()
        {
            var a = new List<string>();
            try { if (HouseJson.Parse(PlayerPrefs.GetString(YardNewKey, "[]")) is List<object> l) foreach (var o in l) if (o is string id) a.Add(id); } catch (Exception) { }
            return a;
        }
        bool YardBtnOn => _sim.S.Cur == "backyard" && !_sim.Map && !_sim.Shop && !_sim.Edit && _sim.Det == null && !_sim.Party;
        double[] YardBox() { var y = _hud.Yard; return y == null ? null : new[] { 852 + HouseFrame.MX - y.Right - y.W, y.Top - HouseFrame.MY, y.W, y.H }; }
        bool OnYardBtn(double fx, double fy) { var b = YardBox(); return YardBtnOn && b != null && fx >= b[0] && fx <= b[0] + b[2] && fy >= b[1] && fy <= b[1] + b[3]; }
        void DrawYardBtn(double now)
        {
            var y = _hud.Yard; if (y == null) return;
            if (_yardBtn == null)
            {
                _yardBtn = UiPiece.Create(_room.transform, "yard games button", 30990);
                _yardBtn.SetSvg(HouseRoomView.Res("hud/yard"), (float)y.Snap[2], (float)y.Snap[3], 24);
                _yardNew = UiPiece.Create(_room.transform, "yard games new", 30991);
                _yardNew.SetSvg(HouseRoomView.Res("hud/yard-new"), (float)y.BadgeSnap[2], (float)y.BadgeSnap[3], 8);
            }
            var b = YardBox(); int n = YardBtnOn ? YardNewList().Count : 0;
            _yardBtn.Visible = YardBtnOn;
            var yardPress = HeldShrink("yardbtn", b[0] + b[2] / 2, b[1] + b[3] / 2);   // (held: the button and its badge shrink about its centre)
            _yardBtn.Transform = Frame * yardPress * Affine.Translate(b[0] + y.Snap[0], b[1] + y.Snap[1]);
            // the badge: "NEW" (its picture); for more than one, "2 NEW"... drawn the badge's way
            _yardNew.Visible = n > 0;
            if (n > 0)
            {
                string txt = n > 1 ? n + " NEW" : "NEW";
                if (_yardNewTxt != txt)
                {
                    _yardNewTxt = txt;
                    if (n == 1) _yardNew.SetSvg(HouseRoomView.Res("hud/yard-new"), (float)y.BadgeSnap[2], (float)y.BadgeSnap[3], 8);
                    else
                    {
                        var st = new TextStyle { Font = "Fredoka_700Bold", Size = 11, Color = "#ffffff", LineHeight = 11, LetterSpacing = 0.5f };
                        float bw = UiSvg.BoxWidth(txt, st) + 14 + 4, bh = (float)y.BadgeSnap[3];
                        var u = new UiSvg(bw, bh).Box(0, 0, bw, bh, new BoxStyle { Gradient = new[] { "#ff8a9e", "#ff3d64" }, Radius = 999, BorderWidth = 2, BorderColor = "#ffffff", Shadows = new[] { new Shadow("#8e1030", 0, 2, 0) } });
                        u.Text(txt, 9, 5, st);
                        _yardNew.SetSvg(u.Markup, bw, bh, 8);
                    }
                }
                // (sqYardB: ease-in-out, 1 -> 1.14 -> 1 about the badge's centre; right -10 px, top -11 px of the button)
                double ph = now % y.PulseMs / y.PulseMs, e = ph < 0.5 ? Ease(ph * 2) : Ease((1 - ph) * 2), sc = 1 + (y.PulseScale - 1) * e;
                double w = n > 1 ? UiSvg.BoxWidth(_yardNewTxt, new TextStyle { Font = "Fredoka_700Bold", Size = 11, LetterSpacing = 0.5f }) + 18 : y.BadgeSnap[2];
                double cx = b[0] + b[2] + 10 - w / 2, cy = b[1] + y.Badge[1] + y.Badge[3] / 2;
                _yardNew.Transform = Frame * yardPress * Affine.Translate(cx, cy) * Affine.ScaleBy(sc, sc) * Affine.Translate(-w / 2, -y.BadgeSnap[3] / 2);
            }
        }
        string _yardNewTxt;
        static readonly Func<double, double> Ease = SquishSquad.Anim.Easing.Bezier(0.42, 0, 0.58, 1);

        // the menu's back orb over the house (Main Menu.dc.html .mm-hback: left 12, bottom 12 of the screen, 44 x 44 in the
        // wood look, app/menu.js REDESIGN_V9; hidden on the house map and over the Catalog), cut by export-hud.mjs: back to
        // the menu
        UiPiece _back;
        bool BackOn => !_sim.Map && !_sim.Shop;
        double[] BackBox() { var o = _hud.Back; if (o == null) return null; double dk = UiPiece.PxPerDp / _k; return new[] { o.Left * dk - HouseFrame.MX, 393 + HouseFrame.MY - (o.Bottom + o.H) * dk, o.W * dk, o.H * dk }; }
        bool OnBack(double fx, double fy) { var b = BackBox(); return BackOn && b != null && fx >= b[0] && fx <= b[0] + b[2] && fy >= b[1] && fy <= b[1] + b[3]; }
        void DrawBack()
        {
            var o = _hud.Back; if (o == null) return;
            if (_back == null) { _back = UiPiece.Create(_room.transform, "back orb", 30995); _back.SetSvg(HouseRoomView.Res("hud/back"), (float)o.Snap[2], (float)o.Snap[3], 16); }
            var b = BackBox(); double dk = UiPiece.PxPerDp / _k;
            _back.Visible = BackOn;
            _back.Transform = Frame * HeldShrink("back", b[0] + b[2] / 2, b[1] + b[3] / 2) * Affine.Translate(b[0], b[1]) * Affine.ScaleBy(dk, dk) * Affine.Translate(o.Snap[0], o.Snap[1]);
        }
        void Leave() { Save(); OnExit?.Invoke(); Destroy(gameObject); }

        // the trip in (PERF 2026-11-21, the user chose it: "room first, creatures after"; app/menu.js houseDrawn / fillEnd):
        // the bare room shows first, its furniture layer (.sq-items: the pieces, toys and the creatures' boxes) see-through;
        // 0.5 s later it fades in (opacity 0.35 s ease) and the creatures arrive one at a time, the first 0.42 s after
        // that, then one every 0.22 s
        double _fillT0 = -1;
        void Fill(double now)
        {
            if (_fillT0 < 0) return;
            double t = now - _fillT0, f = t < 500 ? 0 : Math.Min(1, FillEase((t - 500) / 350));
            int mounted = t < 920 ? 0 : 1 + (int)((t - 920) / 220);
            _room.ItemsOpacity((float)f); _squad.Fade = (float)f; _squad.Mounted = mounted;
            if (f >= 1 && mounted >= _sim.Vis.Count) { _fillT0 = -1; _squad.Mounted = int.MaxValue; }
        }
        static readonly Func<double, double> FillEase = SquishSquad.Anim.Easing.Bezier(0.25, 0.1, 0.25, 1);

        // the cream veil over a room entered from the map (PERF 2026-11-20, app/menu.js SquishVeil: #fff6e2 at 0.99, over
        // the whole house, two frames, then once frames flow again (SquishPerf.steady: 4 good frames) it fades out in
        // 0.28 s ease-out)
        UiPiece _veil; double _veilT0 = -1;
        void Veil(double now) { _veilT0 = now; }
        void DrawVeil(double now)
        {
            if (_veilT0 < 0) { if (_veil != null) _veil.Visible = false; return; }
            if (_veil == null) _veil = UiPiece.Create(_room.transform, "veil", 34500);
            float fw = (float)(852 + 2 * HouseFrame.MX), fh = (float)(393 + 2 * HouseFrame.MY);
            if (_veilKey != fw + "x" + fh) { _veilKey = fw + "x" + fh; _veil.SetSvg(new UiSvg(fw, fh).Box(0, 0, fw, fh, new BoxStyle { Background = "#fff6e2" }).Markup, fw, fh, 0); }
            double t = now - _veilT0 - 100;   // (two frames, then four steady ones)
            double op = t <= 0 ? 0.99 : 0.99 * (1 - VeilEase(Math.Min(1, t / 280)));
            if (t >= 280) { _veilT0 = -1; _veil.Visible = false; return; }
            _veil.Visible = true; _veil.Opacity = (float)op;
            _veil.Transform = Frame * Affine.Translate(-HouseFrame.MX, -HouseFrame.MY);
        }
        string _veilKey;
        static readonly Func<double, double> VeilEase = SquishSquad.Anim.Easing.Bezier(0, 0, 0.58, 1);

        void OpenYard()
        {
            if (_yard != null) return;
            Save();
            PlayerPrefs.DeleteKey(YardNewKey);   // (games.js yardSeen: the NEW badge goes once the games are seen)
            _camera.enabled = false; if (_yardBtn != null) _yardBtn.Visible = false; if (_yardNew != null) _yardNew.Visible = false;
            // (the games page: a game open once a toy of it is bought here, its tap otherwise saying which; the menu's
            // creature plays: games.js yardLocked / yardNeed, main-menu.js playGame's cre())
            var S = _room.Save;
            _yard = SquishSquad.Games.Yard.View.YardScreen.Create(transform.parent, _ownedKeys, null, PlayerKey,
                g => !HouseYard.Locked(g, S.H.Obj("owned"), S.D), g => HouseYard.NeedText(g, S.D));
            _yard.OnExit = () => { _yard = null; if (_camera != null) _camera.enabled = true; };
        }

        // (the time it takes, in the [Perf] log: App/PerfLog)

        void Update()

        {

            long perf = SquishSquad.App.PerfLog.Mark();

            try { UpdateHere(); } finally { SquishSquad.App.PerfLog.Add("house update", perf); }

        }

        void UpdateHere()
        {
            if (_room == null) return;
            if (_yard != null) return;   // (the yard games are up: its own Escape leaves them)
            double now = Now;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Android's back: the Catalog's detail, the Catalog, Renovate, then out of the house (saved)
                if (_sim.Map) { _sim.CloseMap(); return; }
                if (_sim.FzOn) { _sim.Focus(false, now); return; }
                if (_sim.MenuOn) { _sim.MenuOn = false; return; }
                if (_sim.Shop) { if (_sim.Det != null) _sim.CloseDet(); else _sim.CloseShop(); return; }
                if (_sim.Edit) { _sim.DoneEdit(now); return; }
                Leave(); return;
            }
            HandleInput(now);
            if (_yard != null || this == null) return;
            // PERF 2026-11-20 (webgame/patches.mjs safe / loop, app/menu.js SquishPerf.freeze): the house stands still
            // (creatures, clocks, fish...) while its Catalog book or its map covers the room; time doesn't run for it meanwhile
            bool frozen = _sim.Shop || _sim.Map;
            if (frozen) _sim.Freeze(now); else _sim.Tick(now);
            if (_dirty) { _dirty = false; _room.Draw(852 * _k, 393 * _k); }
            _room.DiscoTick(frozen ? 0 : Time.unscaledDeltaTime * 1000.0);   // (the light-up floor: paused while frozen)
            // the beach's sea pieces bob (bTick's translate)
            if (_sim.S.Cur == "beach" && !_sim.Edit) foreach (var p in _room.Pieces) if ((p.Kind == "item" || p.Kind == "front") && p.Id != null) p.Dy = _sim.BBob.TryGetValue(p.Id, out var bob) ? bob : 0;
            double k = _cam.K(now);
            _room.SetCamera(k);
            _edit.SetCamera(k); _edit.Update(now);
            _shop.Update(now);
            _map.Update(now, !_sim.Shop);
            _movie.Update(now);
            if (!frozen) { _club.Update(now); _beach.Update(now); _vac.Update(now); _squad.Update(k, now); MoveToy(now); }
            Fill(now);
            _wheel.Held = _held != null && _held.StartsWith("wheel:") ? _held.Substring(6) : null;
            _wheel.Update(k, now);
            if (now >= _saveAt) { _saveAt = now + 5000; Save(); }
            // the drawer (translate(-50%, ty): its pieces' rects are at ty 0), the arrow turning about its centre
            double ty = _hud.DrawerTy(now);
            var tab = _hud.Pieces["tab"]; var panel = _hud.Pieces["panel"]; var arrow = _hud.Pieces["arrow"];
            _tab.Visible = _arrow.Visible = _panel.Visible = !_sim.Edit;   // (notEdit)
            ty += HouseFrame.MY;   // (the drawer keeps to the frame's bottom)
            var tabPress = HeldShrink("hud:tab", tab.X + tab.W / 2, tab.Y + ty + tab.H / 2);   // (held: the tab and its arrow shrink about the tab's centre)
            _tab.Transform = Frame * tabPress * Affine.Translate(tab.X, tab.Y + ty);
            _panel.Transform = Frame * Affine.Translate(panel.X, panel.Y + ty);
            DrawBtnShade(ty);
            _arrow.Transform = Frame * tabPress * Affine.Translate(arrow.X + arrow.W / 2, arrow.Y + ty + arrow.H / 2) * Affine.Rotate(_hud.ArrowDeg(now)) * Affine.Translate(-arrow.W / 2, -arrow.H / 2);
            DrawYardBtn(now);
            DrawBack();
            DrawToast(now);
            DrawVeil(now);
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
            _toast.Transform = Frame * Affine.Translate(426, 58 - HouseFrame.MY + dy + h / 2) * Affine.Rotate(-1.2) * Affine.Translate(-w / 2, -h / 2);
        }

        void Toast(string text) => _hud.ShowToast(text, Now);

        List<HouseRoomView.Piece> _hit;

        // the rolling toy (rollStep): its layer follows the roll and its depth (the spin of its inner part isn't drawn)
        void MoveToy(double now)
        {
            if (_sim.Rolling == null) { foreach (var p in _room.Pieces) if (p.Kind == "toy" || p.Kind == "toyshadow") { p.Dx = 0; p.Dy = 0; p.Rot = 0; p.Lift = 0; p.Sx = p.Sy = 1; } return; }
            int ix = _sim.Toys().IndexOf(_sim.Rolling.Y);
            foreach (var p in _room.Pieces)
            {
                if ((p.Kind != "toy" && p.Kind != "toyshadow") || p.Toy != ix) continue;
                var (x, y, hop, spin) = _sim.RollAt(now);
                // (rollStep: the box moved and scaled for its depth, sAt(y), about its bottom centre; the inner part turned
                // about 50 % 60 % of its 38 px (inset 1 px), 16.2 px over the 40 px box's bottom at its scale)
                var G = _sim.S.Geo; double s0 = G.SAt(_sim.Rolling.Y0), rel = s0 > 0 ? G.SAt(y) / s0 : 1;
                p.Dx = x - _sim.Rolling.X0; p.Dy = y - _sim.Rolling.Y0 - hop;
                p.Sx = p.Sy = rel;
                p.Lift = 16.2 * ((p.Box ?? p.Region)[3] / 40);   // (the box's own scale: its 40 px as drawn) p.Rot = p.Kind == "toy" ? spin : 0;
                if (p.Renderer != null) p.Renderer.sortingOrder = HouseRoomView.OrderOf(Math.Round(y), p.Kind == "toy" ? 1 : 0);
            }
        }

        // a press, a hold (Renovate's drags: a piece, the light, the rotation slider, the tray's scroll) and a release
        void HandleInput(double now)
        {
            bool down = Input.GetMouseButtonDown(0), up = Input.GetMouseButtonUp(0), held = Input.GetMouseButton(0);
            Vector2 pos = Input.mousePosition;
            if (Input.touchCount > 0) { var t = Input.GetTouch(0); pos = t.position; down = t.phase == TouchPhase.Began; up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled; held = !up; }
            double fx = pos.x / _k - HouseFrame.MX, fy = (_h - pos.y) / _k - HouseFrame.MY, k = _cam.K(now);   // (room px: the room in the frame's middle)
            var b = HouseCamera.ToBox(fx, fy, k);
            if (down)
            {
                _down = true; _downAt = pos; _moved = false; _pressX = fx; _pressY = fy; _press = null;
                // (each press also shows what it's on held: it shrinks until it's let go or the finger leaves it)
                if (_sim.Map) { _press = "map"; _map.PressDown(fx, fy, now); return; }     // (the map covers everything: its taps on release)
                if (_sim.Show != null && (_sim.FzP > 0 || _movie.Hits(fx, fy))) { _press = "theater"; _movie.PressDown(fx, fy, now); return; }   // (the player bar, the picker, full screen)
                if (_sim.Shop) { _press = "shop"; _shop.PressDown(fx, fy, now); return; }   // (the Catalog covers everything: its taps on release)
                if (_map.OnRoomButton(fx, fy)) { _press = "mapbtn"; _map.PressDown(fx, fy, now); return; }
                if (OnYardBtn(fx, fy)) { _press = "yardbtn"; _held = "yardbtn"; return; }
                if (OnBack(fx, fy)) { _press = "back"; _held = "back"; return; }
                if (_sim.Edit) EditPress(fx, fy, b.x, b.y, now);
                else _heldId = _held = HeldAt(fx, fy, now);   // (the drawer, the wheel: their taps on release)
                return;
            }
            if (!_down) return;
            if ((pos - _downAt).magnitude > 12 * _k) _moved = true;
            if (held && !up)
            {
                if (_moved) ReleaseHeld(); else MoveHeld(fx, fy, now);
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
            ReleaseHeld();
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
                case "map": if (!_moved) _map.Tap(fx, fy, now); return;
                case "theater": if (!_moved) _movie.Tap(fx, fy, now); return;
                case "mapbtn": if (!_moved) _sim.OpenMap(now); return;
                case "yardbtn": if (!_moved) OpenYard(); return;
                case "back": if (!_moved) Leave(); return;
            }
            if (_moved) return;   // (a drag, not a tap)
            Tap(fx, fy, now);
        }

        // ---- held buttons: the House's own (Back, Yard Games, the drawer's tab and buttons, the wheel) and, through
        // their PressDown / PressMove / PressUp, the map's, the Catalog's, the theater's and Renovate's
        string _held, _heldId;
        string HeldAt(double fx, double fy, double now)
        {
            if (_hud.Covers(fx, fy, now)) { var h = _hud.Tap(fx, fy, now); return h != null ? "hud:" + h : null; }
            var w = _wheel.Tap(fx, fy, _cam.K(now));
            return w != null ? "wheel:" + w : null;
        }
        void MoveHeld(double fx, double fy, double now)
        {
            switch (_press)
            {
                case "map": case "mapbtn": _map.PressMove(fx, fy, now); break;
                case "theater": _movie.PressMove(fx, fy); break;
                case "shop": _shop.PressMove(fx, fy); break;
                case "ui": case "tray": _edit.PressMove(fx, fy); break;
                case "yardbtn": _held = OnYardBtn(fx, fy) ? "yardbtn" : null; break;
                case "back": _held = OnBack(fx, fy) ? "back" : null; break;
                case null: if (_heldId != null) _held = HeldAt(fx, fy, now) == _heldId ? _heldId : null; break;
            }
        }
        void ReleaseHeld()
        {
            _map.PressUp(); _movie.PressUp(); _shop.PressUp(); _edit.PressUp();
            _held = _heldId = null;
        }
        // a held button shrinks to 92 % about its centre (cx, cy: frame px), like the menu's Level crest; back to 100 % on release
        Affine HeldShrink(string id, double cx, double cy) => _held == id ? Affine.Translate(cx, cy) * Affine.ScaleBy(0.92, 0.92) * Affine.Translate(-cx, -cy) : Affine.Identity;

        // a shade over the drawer's RENOVATE / CATALOG while held (they're part of the drawer's picture)
        UiPiece _btnShade;
        void DrawBtnShade(double ty)
        {
            string id = _held != null && _held.StartsWith("hud:") && _held != "hud:tab" ? _held.Substring(4) : null;
            if (id == null || !_hud.Buttons.TryGetValue(id, out var r)) { if (_btnShade != null) _btnShade.Visible = false; return; }
            if (_btnShade == null) _btnShade = UiPiece.Create(_room.transform, "hud button held", 31003);
            float w = (float)r.W, h = (float)r.H;
            _btnShade.SetSvg(new UiSvg(w, h).Box(0, 0, w, h, new BoxStyle { Radius = Math.Min(w, h) / 2 * 0.6f, Background = "rgba(60,30,10,0.22)" }).Markup, w, h, 2);
            _btnShade.Visible = !_sim.Edit;
            _btnShade.Transform = Frame * Affine.Translate(r.X, r.Y + ty);
        }

        // Renovate: the edit UI first, then the light's handle, a piece (picked up: itemDown), the floor (the selection goes)
        void EditPress(double fx, double fy, double bx, double by, double now)
        {
            var e = _edit.Press(fx, fy, now);
            if (e == "slider") { _press = "slider"; _sim.RotStart(); _edit.SliderAt(fx, now); return; }
            if (e != null) { _press = e; if (e == "ui" || e == "tray") _edit.PressDown(fx, fy, now); return; }
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
            // the beach's props (shells, the fishing sign, snowmen), then a piece or a toy (its box; the topmost by
            // z-index): itemDown, kick
            if (_sim.S.Cur == "beach") { var bb = HouseCamera.ToBox(fx, fy, k); if (_beach.Tap(bb.x, bb.y, now)) return; }
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
            _room.Draw(852 * _k, 393 * _k);
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
            if (_yard != null) Destroy(_yard.gameObject);
            _squad?.Destroy();
            _wheel?.Destroy();
            _edit?.Destroy();
            _beach?.Clear();
            _vac?.Clear();
            _shop?.Destroy();
            _map?.Destroy();
            _movie?.Destroy();
            _club?.Destroy();
            if (_room != null) Destroy(_room.gameObject);
            if (_toast != null) Destroy(_toast.gameObject);
        }
    }
}
