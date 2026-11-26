// The house map's UI (HOUSE_PORT_PLAN.md stage 8), as Squad House v6.dc.html draws it while state.map: the sea, the
// map's picture (House/HouseMap.cs: the page's template with the page's mapVals) scaled 0.92 -> 1 as it opens and
// zoomed 2.6x into a picked room (0.6 s cubic-bezier(.45,0,.3,1)) as the page fades to cream (0.3 s after 0.3 s), each
// room's label at its spot (You're here, its name, the padlock and level, its chip, the friends in it), the Back button
// and weather chip (the page's, export-map.mjs), the hint and the level chip; and the room's House map button
// (top-left in a room). The faces in the labels: the creatures' pictures cropped as the page does (export-faces.mjs).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseMapView
    {
        readonly HouseCreatures _sim;
        readonly Transform _parent;
        readonly float _k;
        readonly JObj _P;
        readonly List<object> _bits;
        readonly string _tpl;
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly Dictionary<string, string> _drawn = new Dictionary<string, string>();
        readonly HashSet<string> _used = new HashSet<string>();
        const int O = 33000;
        static readonly Func<double, double> Move = Easing.Bezier(0.45, 0, 0.3, 1), Ease = Easing.Bezier(0.25, 0.1, 0.25, 1);
        double _sc = 0.92, _scFrom = 0.92, _scTo = 0.92, _scT0, _op, _opFrom, _opTo, _opT0, _fade, _fadeT0 = -1;
        double _ox = 426, _oy = 196.5;
        bool _wasMap;
        public Action<string> Toast;

        public HouseMapView(Transform parent, HouseCreatures sim, float screenK, string mapJson, string bitsJson, string template)
        {
            _parent = parent; _sim = sim; _k = screenK; _P = ((JObj)HouseJson.Parse(mapJson)).Obj("pieces"); _bits = ((JObj)HouseJson.Parse(bitsJson)).Arr("svgs"); _tpl = template;
        }

        Affine Frame => Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp);
        // (the room's map button, the map's Back and weather chip keep to the frame's top-left: patches.mjs houseBox)
        double[] R(string id) { var a = _P.Arr(id); return a == null ? null : new[] { (double)a[0] - HouseFrame.MX, (double)a[1] - HouseFrame.MY, (double)a[2], (double)a[3] }; }
        // the whole frame (room px): the sea, the cream fade
        static double FX0 => -HouseFrame.MX; static double FY0 => -HouseFrame.MY; static float FW => (float)(852 + 2 * HouseFrame.MX); static float FH => (float)(393 + 2 * HouseFrame.MY);
        static string N(double v) => HouseGeo.N(Math.Round(v * 1000) / 1000);

        UiPiece Piece(string id, int order) { if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_parent, "map " + id, order); _p[id] = p; } p.Visible = true; p.Opacity = 1; p.Order = order; _used.Add(id); return p; }
        UiPiece Fixed(string id, int order)
        {
            var r = R(id); if (r == null) return null; bool fresh = !_p.ContainsKey(id); var p = Piece(id, order);
            if (fresh) p.SetSvg(HouseRoomView.Res("map/" + id), (float)r[2], (float)r[3], 12);
            p.Transform = Frame * Affine.Translate(r[0], r[1]); return p;
        }
        UiPiece Drawn(string id, string key, Func<(string svg, float w, float h)> draw, int order, float margin = 16)
        {
            var p = Piece(id, order);
            if (!_drawn.TryGetValue(id, out var k0) || k0 != key) { var d = draw(); p.SetSvg(d.svg, d.w, d.h, margin); _drawn[id] = key; }
            return p;
        }

        /// <summary>The room's House map button (top-left: the map and the room's name), shown in the room.</summary>
        public void RoomButton(bool show)
        {
            if (!show) return;
            var p = Fixed("btn-" + _sim.S.Cur, O - 2000);
            if (p != null && Held == "btn") p.Transform = p.Transform * Shrunk("btn-" + _sim.S.Cur);
        }
        // a held Fixed piece: 92 % about its own centre (like the menu's Level crest)
        Affine Shrunk(string id) { var r = R(id); double w = r[2], h = r[3]; return Affine.Translate(w / 2, h / 2) * Affine.ScaleBy(0.92, 0.92) * Affine.Translate(-w / 2, -h / 2); }

        // ---- the press: what's under the finger shrinks to 92 % while it stays there (the room's map button, Back, a room) ----
        string _downId;
        public string Held { get; private set; }
        string HitId(double fx, double fy, double now)
        {
            if (!_sim.Map) return OnRoomButton(fx, fy) ? "btn" : null;
            var b = R("back"); if (b != null && fx >= b[0] && fx <= b[0] + b[2] && fy >= b[1] && fy <= b[1] + b[3]) return "back";
            if (_sim.MapGo != null) return null;
            double s = Sc(now), mx = _ox + (fx - _ox) / s, my = _oy + (fy - _oy) / s;
            foreach (var t in _tiles) if (mx >= t.x0 && mx <= t.x1 && my >= t.y0 && my <= t.y1) return "room:" + t.rk;
            return null;
        }
        /// <summary>A press began at a frame point (the map's taps, or the room's map button): what it's on is held.</summary>
        public void PressDown(double fx, double fy, double now) => _downId = Held = HitId(fx, fy, now);
        /// <summary>The finger moved: held only while it's still on what the press began on.</summary>
        public void PressMove(double fx, double fy, double now) => Held = _downId != null && HitId(fx, fy, now) == _downId ? _downId : null;
        public void PressUp() => _downId = Held = null;
        public bool OnRoomButton(double fx, double fy) { var r = R("btn-" + _sim.S.Cur); return r != null && fx >= r[0] && fx <= r[0] + r[2] && fy >= r[1] && fy <= r[1] + r[3]; }

        JObj _vals; List<(string rk, double x0, double y0, double x1, double y1)> _tiles = new List<(string, double, double, double, double)>();

        public void Update(double now, bool roomButton)
        {
            _used.Clear();
            if (roomButton && !_sim.Map) RoomButton(true);
            if (!_sim.Map) { _wasMap = false; foreach (var kv in _p) if (!_used.Contains(kv.Key)) kv.Value.Visible = false; return; }
            _sim.MapTick(now);
            if (!_sim.Map) { foreach (var p in _p.Values) p.Visible = false; return; }
            _vals = _sim.MapVals();
            if (_vals == null) { Toast?.Invoke("The map needs the drawing engine"); _sim.CloseMap(); return; }
            if (!_wasMap) { _wasMap = true; _sc = _scFrom = _scTo = 0.92; _op = _opFrom = _opTo = 0; _fade = 0; _fadeT0 = -1; }
            // the zoom: scale(0.92) -> scale(1) as it shows; scale(2.6) about the picked room
            var mx = _vals.Obj("mx"); var go = _sim.MapGo;
            double sc = go != null ? 2.6 : _sim.MapIn ? 1 : 0.92, op = _sim.MapIn || go != null ? 1 : 0;
            if (sc != _scTo) { _scFrom = Sc(now); _scTo = sc; _scT0 = now; }
            if (op != _opTo) { _opFrom = Op(now); _opTo = op; _opT0 = now; }
            if (go != null && _fadeT0 < 0) _fadeT0 = now + 300;
            var mo = _vals.Str("mapO"); var mm = Regex.Match(mo ?? "", "(-?[\\d.]+)px (-?[\\d.]+)px"); if (mm.Success) { _ox = double.Parse(mm.Groups[1].Value, CultureInfo.InvariantCulture); _oy = double.Parse(mm.Groups[2].Value, CultureInfo.InvariantCulture); } else { _ox = 426; _oy = 196.5; }
            double s = Sc(now); float o = (float)Op(now);
            var zoom = Affine.Translate(_ox, _oy) * Affine.ScaleBy(s, s) * Affine.Translate(-_ox, -_oy);
            // the sea behind, the picture
            // (patches.mjs: the sea round the map is its gradient carried on, sea0 at the map's top and sea1 at its bottom)
            string s0 = mx.Str("sea0") ?? mx.Str("seaBg") ?? "#4d8ea9", s1 = mx.Str("sea1") ?? s0, seaKey = s0 + s1 + FW + "x" + FH;
            var bg = Drawn("sea", seaKey, () => (new UiSvg(FW, FH).Box(0, 0, FW, FH, new BoxStyle { Gradient = new[] { s0, s0, s1, s1 }, GradientStops = new[] { 0f, (float)(HouseFrame.MY / FH), (float)((393 + HouseFrame.MY) / FH), 1f } }).Markup, FW, FH), O, 0); bg.Transform = Frame * Affine.Translate(FX0, FY0);
            string svg = null; string key = HouseJson.Stringify(_vals.Arr("mapTiles")?.ConvertAll(t => (object)((t as JObj)?.Num("glow") ?? 0))) + mx.Str("grass") + mx.Str("label") + _sim.SeasonNow();
            var pic = Drawn("pic", key, () => { svg ??= HouseCreatures.MapSvg(_tpl, _vals); return (svg, 852, 393); }, O + 1, 0);
            pic.Transform = Frame * zoom; pic.Opacity = o;
            Labels(zoom, o);
            // the cream fade as the room is entered
            double ft = _fadeT0 < 0 ? 0 : Math.Max(0, Math.Min(1, Ease(Math.Max(0, Math.Min(1, (now - _fadeT0) / 300)))));
            if (ft > 0) { var fd = Drawn("fade", "f" + FW + "x" + FH, () => (new UiSvg(FW, FH).Box(0, 0, FW, FH, new BoxStyle { Background = "#fff6e2" }).Markup, FW, FH), O + 40, 0); fd.Transform = Frame * Affine.Translate(FX0, FY0); fd.Opacity = (float)ft; }
            // Back, the weather, the hint, the level chip
            var bk = Fixed("back", O + 50); if (bk != null && Held == "back") bk.Transform = bk.Transform * Shrunk("back");
            Fixed("weather-" + _sim.SeasonNow(), O + 50);
            var hst = new TextStyle { Font = "Fredoka_600SemiBold", Size = 12.5f, Color = "#6b4426", LineHeight = 18 }; string hint = _sim.MapHint;
            float hw = UiSvg.BoxWidth(hint, hst) + 20, hh = 22;
            var hp = Drawn("hint", hint, () => { var u = new UiSvg(hw, hh); u.Box(0, 0, hw, hh, new BoxStyle { Background = "#fff6e2", Radius = 6, Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 2), new Shadow("rgba(107,68,38,0.35)", 0, 2, 0, 2) } }); u.Text(hint, 10, 2, hst); return (u.Markup, hw, hh); }, O + 50);
            hp.Transform = Frame * Affine.Translate(14 - HouseFrame.MX + hw / 2, 393 + HouseFrame.MY - 12 - hh / 2) * Affine.Rotate(-1.5) * Affine.Translate(-hw / 2, -hh / 2);
            var lst = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#5b3418" }; string lt = "Lv " + _sim.S.Level + " · " + mx.Str("label");
            float lw = 2 + 6 + 16 + 5 + UiSvg.BoxWidth(lt, lst) + 11 + 2;
            var lp = Drawn("lvchip", lt, () =>
            {
                var u = new UiSvg(lw, 28); u.Box(0, 0, lw, 28, new BoxStyle { Gradient = new[] { "#ffe9a0", "#e2b14a", "#b8862a" }, GradientStops = new[] { 0f, 0.6f, 1f }, Radius = 7, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 2.5f, 0) } });
                u.Raw("<g transform=\"translate(8 6)\">" + Regex.Replace((string)_bits[4], "^<svg[^>]*>|</svg>$", "") + "</g>");
                u.Text(lt, 2 + 6 + 16 + 5, (28 - UiSvg.LineBox(lst)) / 2, lst); return (u.Markup, lw, 28);
            }, O + 50);
            lp.Transform = Frame * Affine.Translate(852 + HouseFrame.MX - 16 - lw, 12 - HouseFrame.MY);
            foreach (var kv in _p) if (!_used.Contains(kv.Key)) kv.Value.Visible = false;
        }
        double Sc(double now) { double t = (now - _scT0) / 600; return t >= 1 ? _scTo : t <= 0 ? _scFrom : _scFrom + (_scTo - _scFrom) * Move(t); }
        double Op(double now) { double t = (now - _opT0) / 350; return t >= 1 ? _opTo : t <= 0 ? _opFrom : _opFrom + (_opTo - _opFrom) * Ease(t); }

        // the creatures with a face picture (Resources/House/faces.json)
        static HashSet<string> _faces;
        static bool HasFace(string key)
        {
            if (key == null) return false;
            if (_faces == null)
            {
                _faces = new HashSet<string>();
                var j = Resources.Load<TextAsset>("House/faces");
                if (j != null && HouseJson.Parse(j.text) is JObj o && o.Arr("keys") is List<object> l) foreach (var k in l) if (k is string ks) _faces.Add(ks);
            }
            return _faces.Contains(key);
        }

        // each room's label: translate(-50%, -50%) scale(sc) at (lx, ly), under the map's zoom
        void Labels(Affine zoom, float op)
        {
            _tiles.Clear();
            var tiles = _vals.Arr("mapTiles"); if (tiles == null) return;
            var nst = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#5b3418", LineHeight = 18 };
            for (int i = 0; i < tiles.Count; i++)
            {
                var m = (JObj)tiles[i]; string rk = m.Str("id");
                bool lockIc = m.Truthy("lockIc"), chip = m.Truthy("chip"), here = m.Truthy("here");
                string name = m.Str("name") ?? "", lockTxt = m.Str("lockTxt") ?? "", chipTxt = m.Str("chipTxt") ?? "";
                var faces = m.Arr("faces") ?? new List<object>(); bool more = m.Truthy("more");
                var ltS = new TextStyle { Font = "Fredoka_700Bold", Size = 11.5f, Color = "#b23a2e", LineHeight = 18 }; var chS = new TextStyle { Font = "Fredoka_700Bold", Size = 11, Color = m.Str("chipCol") ?? "#5b3418", LineHeight = 16 };
                var nS = new TextStyle { Font = nst.Font, Size = nst.Size, Color = m.Str("nameCol") ?? "#5b3418", LineHeight = 18 };
                double pillW = 2 * 10 + (lockIc ? 12 + 5 : 0) + UiSvg.BoxWidth(name, nS) + (lockIc ? 5 + UiSvg.BoxWidth(lockTxt, ltS) : 0) + (chip ? 5 + UiSvg.BoxWidth(chipTxt, chS) + 14 : 0), pillH = 22;
                var moS = new TextStyle { Font = "Fredoka_700Bold", Size = 11, Color = "#5b3418" }; double moreW = more ? Math.Max(24, UiSvg.BoxWidth(m.Str("moreN") ?? "", moS) + 8) : 0;
                double rowW = pillW + faces.Count * (24 + 4) + (more ? 4 + moreW : 0), rowH = Math.Max(pillH, faces.Count > 0 || more ? 24 : 0);
                var hereS = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, Color = "#b23a2e", LineHeight = 16 }; double hereW = here ? 20 + 3 + UiSvg.BoxWidth("You're here", hereS) + 12 : 0, hereH = here ? 27 : 0;
                // the column's layout height (the pin's row has margin-top -30: it sits up over the label) and where the
                // canvas (4 px margin round what's drawn) starts in the column's box
                double W = Math.Max(rowW, hereW), Hl = here ? hereH - 30 + 2 + rowH : rowH, canvasTop = here ? -30 - 4 : -4;
                string key = HouseJson.Stringify(m.Obj("faces") ?? (object)faces) + name + lockTxt + chipTxt + here + m.Str("sbg") + m.Str("nameCol");
                float cw = (float)W + 8, ch = (float)(rowH + (here ? hereH : 0)) + 8;
                var p = Drawn("lab" + i, key, () =>
                {
                    var u = new UiSvg(cw, ch); double y = 4;
                    if (here)
                    {
                        double hx = 4 + (W - hereW) / 2;
                        u.Raw($"<g transform=\"translate({N(hx)} {N(y)})\">" + Regex.Replace((string)_bits[0], "^<svg[^>]*>|</svg>$", m2 => m2.Value.StartsWith("<svg") ? "<svg width=\"20\" height=\"27\" viewBox=\"0 0 22 30\">" : m2.Value) + "</g>");
                        float tw = UiSvg.BoxWidth("You're here", hereS) + 12;
                        u.Box((float)(hx + 23), (float)(y + 27 - 5 - 16), tw, 16, new BoxStyle { Background = "#fff6e2", Radius = 4, Shadows = new[] { new Shadow("#4a2e1a", 0, 0, 0, 1.5f) } });
                        u.Text("You're here", (float)(hx + 23 + 6), (float)(y + 27 - 5 - 16), hereS);
                        y = 4 + hereH + 2;   // (the label row below the pin's)
                    }
                    double x = 4 + (W - rowW) / 2;
                    u.Box((float)x, (float)y, (float)pillW, (float)pillH, new BoxStyle { Background = m.Str("sbg") ?? "#fff6e2", Radius = 7, Shadows = new[] { new Shadow("#4a2e1a", 0, 0, 0, 2), new Shadow("rgba(74,46,26,0.35)", 0, 3, 0, 2) } });
                    double tx = x + 10;
                    if (lockIc) { u.Raw($"<g transform=\"translate({N(tx)} {N(y + 5)})\">" + Regex.Replace((string)_bits[1], "^<svg[^>]*>|</svg>$", m2 => m2.Value.StartsWith("<svg") ? "<svg width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"#b23a2e\" stroke-width=\"3\" stroke-linecap=\"round\">" : m2.Value) + "</g>"); tx += 12 + 5; }
                    u.Text(name, (float)tx, (float)y + 2, nS); tx += UiSvg.BoxWidth(name, nS);
                    if (lockIc) { tx += 5; u.Text(lockTxt, (float)tx, (float)y + 2, ltS); tx += UiSvg.BoxWidth(lockTxt, ltS); }
                    if (chip) { tx += 5; float cw2 = UiSvg.BoxWidth(chipTxt, chS) + 14; u.Box((float)tx, (float)y + 3, cw2, 16, new BoxStyle { Background = m.Str("chipBg") ?? "#fff6e2", Radius = 8 }); u.Text(chipTxt, (float)tx + 7, (float)y + 3, chS); }
                    double fx = x + pillW + 4, fy = y + (pillH - 24) / 2;
                    foreach (JObj f in faces)
                    {
                        u.Box((float)fx, (float)fy, 24, 24, new BoxStyle { Background = "#fff6e2", Radius = 12, BorderWidth = 2, BorderColor = "#fff6e2", Shadows = new[] { new Shadow("#4a2e1a", 0, 0, 0, 1.5f), new Shadow("rgba(74,46,26,0.3)", 0, 2, 0, 1.5f) } });
                        // its face: the creature's picture as the page crops it (SquishSquad.src at 140 %, 50 % 20 %), inside the
                        // 2 px border (Resources/House/faces, tools/unity/house/export-faces.mjs; none: the cream circle)
                        if (HasFace(f.Str("id"))) u.Raw("<image href=\"House/faces/" + f.Str("id") + "\" x=\"" + (fx + 2).ToString(CultureInfo.InvariantCulture) + "\" y=\"" + (fy + 2).ToString(CultureInfo.InvariantCulture) + "\" width=\"20\" height=\"20\" preserveAspectRatio=\"none\"/>");
                        if (f.Truthy("low")) u.Box((float)fx + 16, (float)fy + 16, 10, 10, new BoxStyle { Background = f.Str("lc") ?? "#f28a1e", Radius = 5, BorderWidth = 1.5f, BorderColor = "#4a2e1a" });
                        fx += 28;
                    }
                    if (more) { u.Box((float)fx, (float)fy, (float)moreW, 24, new BoxStyle { Background = "#fff6e2", Radius = 12, Shadows = new[] { new Shadow("#4a2e1a", 0, 0, 0, 1.5f) } }); u.Text(m.Str("moreN"), (float)(fx + (moreW - UiSvg.BoxWidth(m.Str("moreN"), moS)) / 2), (float)(fy + (24 - UiSvg.LineBox(moS)) / 2), moS); }
                    return (u.Markup, cw, ch);
                }, O + 5);
                double lx = m.Num("lx"), ly = m.Num("ly"), sc = m.Num("sc", 1), ps = Held == "room:" + rk ? 0.92 : 1;   // (held: 92 % about the label's centre)
                p.Transform = Frame * zoom * Affine.Translate(lx, ly) * Affine.ScaleBy(sc * ps, sc * ps) * Affine.Translate(-cw / 2, -Hl / 2 + canvasTop);
                p.Opacity = op;
                // where a tap picks this room: its label, and its silhouette's box
                _tiles.Add((rk, lx - cw / 2 * sc, ly + (-Hl / 2 + canvasTop) * sc, lx + cw / 2 * sc, ly + (-Hl / 2 + canvasTop + ch) * sc));
                var nums = Regex.Matches(m.Str("sil") ?? "", "-?[\\d.]+"); double x0 = 1e9, y0 = 1e9, x1 = -1e9, y1 = -1e9;
                for (int k = 0; k + 1 < nums.Count; k += 2) { double a = double.Parse(nums[k].Value, CultureInfo.InvariantCulture), b = double.Parse(nums[k + 1].Value, CultureInfo.InvariantCulture); x0 = Math.Min(x0, a); y0 = Math.Min(y0, b); x1 = Math.Max(x1, a); y1 = Math.Max(y1, b); }
                if (x0 < x1) _tiles.Add((rk, x0, y0, x1, y1));
            }
        }

        /// <summary>A tap while the map is open (it takes every tap).</summary>
        public void Tap(double fx, double fy, double now)
        {
            var b = R("back"); if (b != null && fx >= b[0] && fx <= b[0] + b[2] && fy >= b[1] && fy <= b[1] + b[3]) { _sim.CloseMap(); return; }
            if (_sim.MapGo != null) return;
            // the map's point under the tap (its zoom undone)
            double s = Sc(now), mx = _ox + (fx - _ox) / s, my = _oy + (fy - _oy) / s;
            foreach (var t in _tiles) if (mx >= t.x0 && mx <= t.x1 && my >= t.y0 && my <= t.y1) { _sim.MapPick(t.rk, now); return; }
        }

        public void Destroy() { foreach (var p in _p.Values) if (p != null) Object.Destroy(p.gameObject); _p.Clear(); }
    }
}
