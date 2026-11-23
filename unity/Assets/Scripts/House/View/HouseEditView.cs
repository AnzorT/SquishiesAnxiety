// Renovate's UI (HOUSE_PORT_PLAN.md stage 6), as Squad House v6.dc.html draws it while state.edit: the Done and House
// shop buttons (bottom right), the toolbox (its tab, the wood box with the label card, the tray of what's in storage or
// owned for the tab, the tab buttons; sliding up and down: translateY 0 / 134 px, 0.75 s cubic-bezier(.25,1.15,.4,1)), the
// toolbar for the selected piece or the ceiling light (its tab; the direction label, Confirm, the rotation slider or
// Rotate, the size buttons and label, the sign's Aa, the light's name, swap and middle buttons, Put away; at left 14,
// bottom 6 or 140 px, sliding 0.75 s, its height 64 / 0 over 0.45 s) and the ceiling light's dashed handle in the room.
// The fixed pieces are the page's own (tools/unity/house/export-edit.mjs); what changes with the piece (the toolbar's
// box and labels, the slider's track and fill, the tray's cards) is drawn here from the page's styles. Logic:
// House/HouseEdit.cs. The sign editor (Aa) comes with the signs (not yet: its button says so).
using System;
using System.Collections.Generic;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseEditView
    {
        sealed class Tw
        {
            double _from, _to, _t0; readonly double _ms; readonly Func<double, double> _e;
            public Tw(double v, double ms, Func<double, double> e) { _from = _to = v; _ms = ms; _e = e; }
            public double At(double now) { double t = (now - _t0) / _ms; return t >= 1 ? _to : t <= 0 ? _from : _from + (_to - _from) * _e(t); }
            public void Set(double v, double now) { if (v == _to) return; _from = At(now); _to = v; _t0 = now; }
        }
        static readonly Func<double, double> Spring = Easing.Bezier(0.25, 1.15, 0.4, 1), Ease = Easing.Bezier(0.25, 0.1, 0.25, 1);

        readonly HouseCreatures _sim;
        readonly Transform _parent;
        readonly float _k;
        readonly JObj _E;
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly Dictionary<string, string> _drawn = new Dictionary<string, string>();
        readonly Tw _rvTy = new Tw(134, 750, Spring), _rvTab = new Tw(0, 300, Ease), _rvRot = new Tw(0, 250, Ease), _tbBot = new Tw(6, 750, Spring), _tbCh = new Tw(0, 450, Spring), _tbRot = new Tw(0, 250, Ease);
        double _scroll, _scrollMax;
        const int O = 31010;
        public Func<string, string> Pic;   // a picture's SVG by name
        public Action<string> Toast;

        public HouseEditView(Transform parent, HouseCreatures sim, float screenK, string editJson)
        {
            _parent = parent; _sim = sim; _k = screenK; _E = (JObj)HouseJson.Parse(editJson);
        }

        Affine Frame => Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp);
        double[] R(string id) { var a = _E.Obj("pieces").Arr(id); return a == null ? null : new[] { (double)a[0], (double)a[1], (double)a[2], (double)a[3] }; }

        // a fixed piece by id (its SVG from Resources/House/edit), placed at frame (x, y), optionally turned about its centre
        UiPiece Fixed(string id, double x, double y, int order, double deg = 0, float op = 1)
        {
            var r = R(id); if (r == null) return null;
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_parent, "edit " + id, order); p.SetSvg(HouseRoomView.Res("edit/" + id), (float)r[2], (float)r[3], 14); _p[id] = p; }
            p.Visible = true; p.Opacity = op;
            p.Transform = Frame * Affine.Translate(x + r[2] / 2, y + r[3] / 2) * Affine.Rotate(deg) * Affine.Translate(-r[2] / 2, -r[3] / 2);
            _used.Add(id);
            return p;
        }
        // a piece drawn here (UiSvg markup), redrawn when its key changes
        UiPiece Drawn(string id, string key, Func<UiSvg> draw, double x, double y, int order, float op = 1)
        {
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_parent, "edit " + id, order); _p[id] = p; }
            if (!_drawn.TryGetValue(id, out var k0) || k0 != key) { var s = draw(); p.SetSvg(s.Markup, s.W, s.H, 16); _drawn[id] = key; }
            p.Visible = true; p.Opacity = op; p.Transform = Frame * Affine.Translate(x, y); _used.Add(id);
            return p;
        }
        readonly HashSet<string> _used = new HashSet<string>();

        // ---- the toolbar's layout (frame px): each element's id, x, width; the box ----
        sealed class Tb { public bool On, Lt, Turn, Spin, Rsz, Free, Sign; public string Dir, SzTxt, WTxt, HTxt, LtName; public double Deg, DnOp = 1, UpOp = 1, WDnOp = 1, WUpOp = 1, HDnOp = 1, HUpOp = 1, MidOp = 1; public List<(string id, double x, double w)> Els = new List<(string, double, double)>(); public double W; }
        static readonly TextStyle LabelSt = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#5b3418" };
        static readonly TextStyle LetterSt = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#fff6e2", Shadows = new[] { new Shadow("#6b4426", 0, 1.3f, 0) } };

        Tb Toolbar()
        {
            var tb = new Tb(); var S = _sim.S; string cur = S.Cur;
            var es = _sim.Edit ? _sim.ESelItem : null;
            if (es != null)
            {
                var D = S.D.CatOf(es.Str("t")); double r = es.Num("r"), m = ((r % 360) + 360) % 360, shown = r == 360 ? 360 : m;
                bool rz = S.CanSize(es), zf = rz && S.SzFree(es), wl = D.Truthy("mount"), sp = S.CanSpin(es);
                double zv = S.SzOf(es); var zq = S.SzXY(es); var zL = rz ? S.SzLim(es) : new double[] { 3, 3 }; double mn = S.SzMin(es);
                tb.On = true; tb.Spin = sp; tb.Turn = !sp && !wl; tb.Rsz = rz; tb.Free = zf; tb.Sign = D.Truthy("sign") || (S.RowOf(D)?["texts"] != null);
                tb.Dir = HouseCreatures.DIRN[(int)Math.Round(m / 45, MidpointRounding.AwayFromZero) % 8] + (sp ? " " + Math.Round(shown, MidpointRounding.AwayFromZero) + "\u00b0" : "");
                tb.Deg = Math.Round(shown, MidpointRounding.AwayFromZero);
                tb.SzTxt = Math.Round(zv * 100, MidpointRounding.AwayFromZero) + "%"; tb.WTxt = Math.Round(zq[0] * 100, MidpointRounding.AwayFromZero) + "%"; tb.HTxt = Math.Round(zq[1] * 100, MidpointRounding.AwayFromZero) + "%";
                tb.DnOp = zv <= mn + 0.004 ? 0.45 : 1; tb.UpOp = zv >= Math.Min(zL[0], zL[1]) - 0.004 ? 0.45 : 1;
                tb.WDnOp = zq[0] <= mn + 0.004 ? 0.45 : 1; tb.WUpOp = zq[0] >= zL[0] - 0.004 ? 0.45 : 1; tb.HDnOp = zq[1] <= mn + 0.004 ? 0.45 : 1; tb.HUpOp = zq[1] >= zL[1] - 0.004 ? 0.45 : 1;
            }
            else if (_sim.Edit && _sim.ESel == "__light")
            {
                var lid = S.H.Obj("surf")?.Obj(cur)?.Str("light");
                string ln = lid != null && lid.StartsWith("rv_") ? S.D.Row(lid.Substring(3))?.Str("name") : lid != null ? S.D.SurfName(lid) : null;
                double lz = _sim.LzOf(cur);
                tb.On = true; tb.Lt = true; tb.Rsz = true; tb.SzTxt = Math.Round(lz * 100, MidpointRounding.AwayFromZero) + "%"; tb.DnOp = lz <= 0.5 ? 0.45 : 1; tb.UpOp = lz >= 2 ? 0.45 : 1;
                tb.LtName = string.IsNullOrEmpty(ln) ? "Ceiling light" : ln; tb.MidOp = S.H.Obj("lx")?[cur] != null ? 1 : 0.45;
            }
            if (!tb.On) return tb;
            // the row: padding 5 8 inside a 2.5 border, gap 7 (4 inside the size groups)
            double x = 14 + 2.5 + 8; bool firstEl = true;
            void Add(string id, double w) { if (!firstEl) x += 7; firstEl = false; tb.Els.Add((id, x, w)); x += w; }
            void Sub(string id, double w) { tb.Els.Add((id, x, w)); x += w; }
            if (tb.Turn) Add("dir", 82);
            Add("tb-confirm-placement", 36);
            if (tb.Spin) Add("slider", 136);
            if (tb.Turn) Add("tb-rotate", 36);
            if (tb.Rsz && !tb.Free) { Add("tb-make-smaller", 36); x += 4; Sub("sz", 50); x += 4; Sub("tb-make-bigger", 36); }
            if (tb.Free)
            {
                double lw = UiSvg.BoxWidth("W", LetterSt) + 2, lh = UiSvg.BoxWidth("H", LetterSt) + 2;
                Add("W", lw); x += 4; Sub("tb-width-smaller", 36); x += 4; Sub("wl", 50); x += 4; Sub("tb-width-bigger", 36);
                Add("H", lh); x += 4; Sub("tb-height-smaller", 36); x += 4; Sub("hl", 50); x += 4; Sub("tb-height-bigger", 36);
            }
            if (tb.Sign) Add("tb-write-on-the-sign", 36);
            if (tb.Lt) { Add("ltname", UiSvg.BoxWidth(tb.LtName, LabelSt) + 24); Add("tb-change-the-light", 36); Add("tb-move-the-light-back-to-the-middle", 36); }
            Add("tb-put-away-in-storage", 36);
            tb.W = x + 8 + 2.5 - 14;
            return tb;
        }

        // ---- per frame ----
        Tb _tb;
        double _tbTop;     // the toolbar box's top (frame px) now
        public void Update(double now)
        {
            _used.Clear();
            var S = _sim.S; string cur = S.Cur;
            if (!_sim.Edit) { Hide(); return; }
            bool open = _sim.ROpen != false;
            _tb = Toolbar();
            bool tOpen = _tb.On && _sim.ROpen == false && _sim.TbC != _sim.ESel;
            double tbShift = tOpen ? Math.Max(0, Math.Min(330, 14 + _tb.W + 12 - 356)) : 0;
            _rvTy.Set(open ? 0 : 134, now); _rvTab.Set(_tb.On ? tbShift : 0, now); _rvRot.Set(open ? 180 : 0, now);
            double ty = _rvTy.At(now);
            // the Done and House shop buttons
            var d = R("done"); Fixed("done", d[0], d[1], O + 9); var sh = R("shop"); Fixed("shop", sh[0], sh[1], O + 9);
            // the toolbox
            var tab = R("rv-tab"); double tx = tab[0] + _rvTab.At(now);
            Fixed("rv-tab", tx, tab[1] + ty, O + 2);
            var ar = R("rv-arrow"); Fixed("rv-arrow", ar[0] + (tx - tab[0]), ar[1] + ty, O + 3, _rvRot.At(now));
            var box = R("rv-box"); Fixed("rv-box", box[0], box[1] + ty, O);
            var well = R("rv-well"); Fixed("rv-well", well[0], well[1] + ty, O + 1);
            int h = _sim.ESel == null ? 0 : _sim.ESel == "__light" ? 2 : 1;
            var lb = R($"label-{cur}-{h}") != null ? $"label-{cur}-{h}" : $"label-{cur}-0";
            if (R(lb) != null) { var lr = R(lb); Fixed(lb, lr[0], lr[1] + ty, O + 2); }
            var tabs = _E.Obj("tabs").Arr(cur); string ct = _sim.CurTab();
            if (tabs != null) foreach (List<object> t in tabs)
                {
                    string k = (string)t[0], id = $"tab-{k}{(cur == "beach" ? "-b" : "")}-{(k == ct ? "on" : "off")}";
                    Fixed(id, (double)t[1], (double)t[2] + ty, k == ct ? O + 4 : O + 3);
                }
            DrawTray(well[0], well[1] + ty, well[2], well[3]);
            DrawToolbar(now, tOpen, open);
            DrawLightHandle();
            foreach (var kv in _p) if (!_used.Contains(kv.Key)) kv.Value.Visible = false;
        }

        void Hide() { foreach (var p in _p.Values) p.Visible = false; }

        // ---- the tray: cards 78 x 72, gap 9, from 10 px in, 8 px down; scrolled; clipped to the well ----
        List<(string id, string name, string n, bool hasN, bool on, bool isPiece)> _tray;
        void DrawTray(double wx, double wy, double ww, double wh)
        {
            _tray = _sim.Tray();
            _scrollMax = Math.Max(0, 10 + _tray.Count * 87 - 9 + 10 - ww);
            _scroll = Math.Max(0, Math.Min(_scrollMax, _scroll));
            var sb = new StringBuilder(); foreach (var c in _tray) sb.Append(c.id).Append(c.n).Append(c.on).Append('|');
            string key = sb + "@" + Math.Round(_scroll) + "#" + _sim.CurTab();
            Drawn("tray", key, () =>
            {
                var s = new UiSvg((float)ww, (float)wh);
                string clip = s.NewId("tc");
                s.Def($"<clipPath id=\"{clip}\"><rect x=\"0\" y=\"0\" width=\"{N(ww)}\" height=\"{N(wh)}\" rx=\"10\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                if (_tray.Count == 0)
                {
                    string tab = _sim.CurTab(), lab = _sim.S.Cur == "beach" && HouseCreatures.BTABL.TryGetValue(tab, out var bl) ? bl : HouseCreatures.RTABL[tab];
                    string empty = tab == "furn" ? "Nothing left for this room. Get more in the Catalog." : "No " + lab.ToLowerInvariant() + " yet. Find some in the Catalog.";
                    var st = new TextStyle { Font = "Fredoka_600SemiBold", Size = 12.5f, Color = "#8a6a4a" };
                    s.Text(empty, 16, (float)(8 + (wh - 8 - UiSvg.LineBox(st)) / 2), st);
                }
                for (int i = 0; i < _tray.Count; i++) Card(s, _tray[i], 10 + i * 87 - _scroll, 8, ((i * 37) % 5 - 2) * 0.7, i);
                s.Close();
                return s;
            }, wx, wy, O + 1);
        }

        static string N(double v) => HouseGeo.N(Math.Round(v * 1000) / 1000);

        void Card(UiSvg s, (string id, string name, string n, bool hasN, bool on, bool isPiece) c, double x, double y, double rot, int i)
        {
            double W = 78, H = 72;
            s.Open($"transform=\"translate({N(x + W / 2)} {N(y + H / 2)}) rotate({N(rot)}) translate({N(-W / 2)} {N(-H / 2)})\"");
            s.Box(0, 0, (float)W, (float)H, new BoxStyle { Background = c.on ? "#eef6df" : "#fff6e2", Radius = 6, Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 1.5f), new Shadow("rgba(107,68,38,0.35)", 0, 2.5f, 0, 1.5f) } });
            s.Box(35.5f, 3, 7, 7, new BoxStyle { Background = "#f1dcb4", Radius = 3.5f, Shadows = new[] { new Shadow("#b8862a", 0, 0, 0, 1.5f) } });
            // the picture: contained in 64 x 42 at (7, 10)
            var pic = CardPic(c);
            if (pic != null)
            {
                var svg = new RoomCompose().InlineImages(pic, 0);
                var pre = "c" + i + "_";
                svg = System.Text.RegularExpressions.Regex.Replace(svg, "\\bid=\"([^\"]+)\"", m => "id=\"" + pre + m.Groups[1].Value + "\"");
                svg = svg.Replace("url(#", "url(#" + pre).Replace("href=\"#", "href=\"#" + pre);
                var m0 = System.Text.RegularExpressions.Regex.Match(svg, "<svg\\b[^>]*>");
                var vb = System.Text.RegularExpressions.Regex.Match(m0.Value, "viewBox=\"([^\"]+)\"").Groups[1].Value;
                if (m0.Success) s.Raw($"<svg x=\"7\" y=\"10\" width=\"64\" height=\"42\" viewBox=\"{vb}\" preserveAspectRatio=\"xMidYMid meet\">" + svg.Substring(m0.Index + m0.Length));
            }
            var nst = new TextStyle { Font = "Fredoka_600SemiBold", Size = 10, Color = "#5b3418" };
            string name = c.name; while (name.Length > 1 && UiSvg.BoxWidth(name, nst) > 72) name = name.Substring(0, name.Length - 2) + "\u2026";
            float nw = UiSvg.BoxWidth(name, nst); s.Text(name, (float)(W - nw) / 2, (float)(H - 4 - UiSvg.LineBox(nst)), nst);
            if (c.hasN)
            {
                string sc = c.isPiece ? "#c4651f" : "#2f7a42";
                var bst = new TextStyle { Font = "Fredoka_700Bold", Size = 10.5f, Color = sc, LineHeight = 15 };
                float bw = UiSvg.BoxWidth(c.n, bst) + 10 + 4, bh = 15 + 4;
                s.Open($"transform=\"translate({N(W + 6 - bw / 2)} {N(-7 + bh / 2)}) rotate(9) translate({N(-bw / 2)} {N(-bh / 2)})\"");
                s.Box(0, 0, bw, bh, new BoxStyle { Background = "#fff6e2", Radius = 4, BorderWidth = 2, BorderColor = sc });
                s.Text(c.n, 7, 2, bst);
                s.Close();
            }
            s.Close();
        }

        readonly Dictionary<string, string> _cardPic = new Dictionary<string, string>();
        string CardPic((string id, string name, string n, bool hasN, bool on, bool isPiece) c)
        {
            if (_cardPic.TryGetValue(c.id, out var p)) return p;
            var S = _sim.S; string rid = c.isPiece ? S.D.CatOf(c.id)?.Str("reno") : c.id.StartsWith("stock_") ? null : c.id;
            string svg = null;
            if (rid != null)
            {
                var v = S.D.Variants.Obj(rid + "|||-30") ?? HouseDraw.Variant(rid, null, "", null, S.Cur);
                var name = v?.Str("whole"); if (!string.IsNullOrEmpty(name)) svg = Pic?.Invoke(name);
            }
            _cardPic[c.id] = svg;
            return svg;
        }

        // ---- the toolbar ----
        void DrawToolbar(double now, bool tOpen, bool rvOpen)
        {
            var tb = _tb;
            _tbBot.Set(tOpen ? 6 : (rvOpen ? 140 : 6), now); _tbCh.Set(tOpen ? 64 : 0, now); _tbRot.Set(tOpen ? 180 : 0, now);
            if (!tb.On) return;
            double line = 393 - _tbBot.At(now), ch = _tbCh.At(now);
            // the tab (margin-left 44) sits on the clip box; the box shows while the clip box has any height
            var t = R("tb-tab"); double tabY = line - ch - t[3] + 2.5;
            Fixed("tb-tab", 14 + 44, tabY, O + 21); var ta = R("tb-arrow"); Fixed("tb-arrow", 14 + 44 + (t[2] - ta[2]) / 2, tabY + (t[3] - 2.5 - ta[3]) / 2, O + 22, _tbRot.At(now));
            if (ch < 1) { _tbTop = -1e9; return; }
            double top = line - ch; _tbTop = top;
            double bw = tb.W, bh = 51;
            Drawn("tb-box", "box" + Math.Round(bw * 10), () =>
            {
                var s = new UiSvg((float)bw, (float)bh);
                s.Box(0, 0, (float)bw, (float)bh, new BoxStyle { Gradient = new[] { "#ffe9a0", "#e2b14a", "#b8862a" }, GradientStops = new[] { 0f, 0.55f, 1f }, Radius = 12, BorderWidth = 2.5f, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 3, 0), new Shadow("rgba(60,30,10,0.3)", 0, 8, 14) } });
                s.Box(2.5f, 2.5f, (float)bw - 5, 1.5f, new BoxStyle { Background = "rgba(255,255,255,0.6)", Radius = 1 });   // (the inset top light)
                return s;
            }, 14, top, O + 20);
            double y0 = top + 2.5 + 5;
            foreach (var (id, x, w) in tb.Els)
            {
                switch (id)
                {
                    case "dir": Label("tb-dir", tb.Dir, x, y0, 82); break;
                    case "sz": Label("tb-sz", tb.SzTxt, x, y0, 50); break;
                    case "wl": Label("tb-wl", tb.WTxt, x, y0, 50); break;
                    case "hl": Label("tb-hl", tb.HTxt, x, y0, 50); break;
                    case "ltname": Label("tb-ltname", tb.LtName, x, y0, w); break;
                    case "W": case "H": Drawn("tb-" + id, id, () => { var s = new UiSvg((float)w, 36); s.Text(id, 0, (36 - UiSvg.LineBox(LetterSt)) / 2, LetterSt); return s; }, x, y0, O + 23); break;
                    case "slider": Slider(x, y0, tb.Deg); break;
                    default:
                        double op = id == "tb-make-smaller" ? tb.DnOp : id == "tb-make-bigger" ? tb.UpOp : id == "tb-width-smaller" ? tb.WDnOp : id == "tb-width-bigger" ? tb.WUpOp : id == "tb-height-smaller" ? tb.HDnOp : id == "tb-height-bigger" ? tb.HUpOp : id == "tb-move-the-light-back-to-the-middle" ? tb.MidOp : 1;
                        Fixed(id, x, y0, O + 23, 0, (float)op); break;
                }
            }
        }

        void Label(string id, string text, double x, double y, double w)
        {
            Drawn(id, text + "|" + w, () =>
            {
                var s = new UiSvg((float)w, 36);
                s.Box(0, 0, (float)w, 36, new BoxStyle { Background = "#fff6e2", Radius = 9, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 2, 0) } });
                float tw = UiSvg.BoxWidth(text, LabelSt); s.Text(text, (float)(w - tw) / 2, (36 - UiSvg.LineBox(LabelSt)) / 2, LabelSt);
                return s;
            }, x, y, O + 23);
        }

        double _slX = -1e9;
        void Slider(double x, double y, double deg)
        {
            _slX = x;
            double fillW = Math.Round(Math.Max(10, deg / 360 * 116 + 6) * 10) / 10, kx = Math.Round((10 + deg / 360 * 116) * 10) / 10;
            Drawn("tb-track", "t" + fillW, () =>
            {
                var s = new UiSvg(136, 36);
                s.Box(10, 13, 116, 10, new BoxStyle { Background = "#fff6e2", Radius = 5, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 2, 0) } });
                s.Box(10, 13, (float)fillW, 10, new BoxStyle { Gradient = new[] { "#f3cc98", "#d39a5e", "#ad723c" }, GradientStops = new[] { 0f, 0.6f, 1f }, Radius = 5, BorderWidth = 2, BorderColor = "#6b4426" });
                for (int i = 0; i < 5; i++) s.Box(10 + i * (116 - 2) / 4f, 26, 2, i % 2 == 0 ? 5 : 4, new BoxStyle { Background = "#6b4426", Radius = 1, Opacity = i % 2 == 0 ? 1 : 0.6f });
                return s;
            }, x, y, O + 23);
            Fixed("tb-knob", x + kx - 13, y + 5, O + 24);
        }

        // ---- the ceiling light's handle (z-index 880 in the room box: scaled with the camera) ----
        double _camK = 1;
        public void SetCamera(double k) => _camK = k;
        void DrawLightHandle()
        {
            var lh = new RoomModel(_sim.S).LightHandle(_sim.S.Cur, _sim.Edit);
            if (!lh.on || _sim.ESel != "__light") return;
            double w = lh.w, hh = lh.h;
            var p = Drawn("lh", N(w) + "|" + N(hh), () => { var s = new UiSvg((float)w, (float)hh); s.Box(0, 0, (float)w, (float)hh, new BoxStyle { Radius = 24, BorderWidth = 2.5f, BorderColor = "#fffaf1", Dashed = true }); return s; }, 0, 0, 2000 + 880 * 4);
            var f = HouseCamera.ToFrame(lh.x - w / 2, -6, _camK);
            p.Transform = Frame * Affine.Translate(f.x, f.y) * Affine.ScaleBy(_camK, _camK);
        }
        /// <summary>Whether a room point (box px) is on the light's handle.</summary>
        public bool OnLight(double bx, double by)
        {
            var lh = new RoomModel(_sim.S).LightHandle(_sim.S.Cur, _sim.Edit);
            return lh.on && bx >= lh.x - lh.w / 2 && bx <= lh.x + lh.w / 2 && by >= -6 && by <= -6 + lh.h;
        }

        // ---- taps and drags (frame px) ----
        /// <summary>What a press at a frame point lands on: "ui" (handled on release by Tap), "slider", "tray", or null (the room).</summary>
        public string Press(double fx, double fy, double now)
        {
            if (!_sim.Edit) return null;
            bool In(double[] r, double dy = 0) => r != null && fx >= r[0] && fx <= r[0] + r[2] && fy >= r[1] + dy && fy <= r[1] + dy + r[3];
            if (In(R("done")) || In(R("shop"))) return "ui";
            double ty = _rvTy.At(now);
            var tab = R("rv-tab"); if (tab != null && fx >= tab[0] + _rvTab.At(now) && fx <= tab[0] + _rvTab.At(now) + tab[2] && fy >= tab[1] + ty && fy <= tab[1] + ty + tab[3]) return "ui";
            var tabs = _E.Obj("tabs").Arr(_sim.S.Cur);
            if (tabs != null) foreach (List<object> t in tabs) { double x = (double)t[1], y = (double)t[2] + ty, w = (double)t[3]; if (fx >= x && fx <= x + w && fy >= y && fy <= y + 29) return "ui"; }
            if (In(R("rv-well"), ty)) return "tray";
            if (In(R("rv-box"), ty)) return "ui";
            if (_tb != null && _tb.On)
            {
                var t = R("tb-tab"); double line = 393 - _tbBot.At(now), ch = _tbCh.At(now), tabY = line - ch - t[3] + 2.5;
                if (fx >= 58 && fx <= 58 + t[2] && fy >= tabY && fy <= tabY + t[3]) return "ui";
                if (_tbTop > -1e8 && fy >= _tbTop && fy <= _tbTop + 51 && fx >= 14 && fx <= 14 + _tb.W)
                    return _slX > -1e8 && _tb.Spin && fx >= _slX && fx <= _slX + 136 ? "slider" : "ui";
            }
            return null;
        }

        /// <summary>A tap (press and release on the UI): the button under it does its thing.</summary>
        public void Tap(double fx, double fy, double now)
        {
            bool In(double[] r, double dy = 0) => r != null && fx >= r[0] && fx <= r[0] + r[2] && fy >= r[1] + dy && fy <= r[1] + dy + r[3];
            if (In(R("done"))) { _sim.DoneEdit(now); return; }
            if (In(R("shop"))) { Toast?.Invoke("The catalog isn't in the Unity version yet"); return; }
            double ty = _rvTy.At(now); bool open = _sim.ROpen != false;
            var tab = R("rv-tab"); double tx = tab[0] + _rvTab.At(now);
            if (fx >= tx && fx <= tx + tab[2] && fy >= tab[1] + ty && fy <= tab[1] + ty + tab[3]) { _sim.ROpen = !open; _sim.Bumped(); return; }
            var tabs = _E.Obj("tabs").Arr(_sim.S.Cur);
            if (tabs != null) foreach (List<object> t in tabs) { double x = (double)t[1], y = (double)t[2] + ty, w = (double)t[3]; if (fx >= x && fx <= x + w && fy >= y && fy <= y + 29) { _sim.RTab = (string)t[0]; _sim.ROpen = true; _scroll = 0; _sim.Bumped(); return; } }
            if (_tb == null || !_tb.On) return;
            var tt = R("tb-tab"); double line = 393 - _tbBot.At(now), ch = _tbCh.At(now), tabY = line - ch - tt[3] + 2.5;
            bool tOpen = _sim.ROpen == false && _sim.TbC != _sim.ESel;
            if (fx >= 58 && fx <= 58 + tt[2] && fy >= tabY && fy <= tabY + tt[3]) { if (tOpen) _sim.TbC = _sim.ESel; else { _sim.TbC = null; _sim.ROpen = false; } _sim.Bumped(); return; }
            if (_tbTop < -1e8 || fy < _tbTop || fy > _tbTop + 51) return;
            foreach (var (id, x, w) in _tb.Els)
            {
                if (fx < x || fx > x + w) continue;
                switch (id)
                {
                    case "tb-confirm-placement": _sim.ESel = null; _sim.TxE = null; _sim.Bumped(); break;
                    case "tb-rotate": _sim.EditRot(now); break;
                    case "tb-make-smaller": if (_tb.Lt) _sim.LightSize(-1); else _sim.EditSize(-1); break;
                    case "tb-make-bigger": if (_tb.Lt) _sim.LightSize(1); else _sim.EditSize(1); break;
                    case "tb-width-smaller": _sim.EditSize(-1, "sw"); break;
                    case "tb-width-bigger": _sim.EditSize(1, "sw"); break;
                    case "tb-height-smaller": _sim.EditSize(-1, "sh"); break;
                    case "tb-height-bigger": _sim.EditSize(1, "sh"); break;
                    case "tb-write-on-the-sign": Toast?.Invoke("Writing on signs isn't in the Unity version yet"); break;
                    case "tb-change-the-light": _sim.RTab = "light"; _sim.ROpen = true; _sim.Bumped(); break;
                    case "tb-move-the-light-back-to-the-middle": _sim.LightMid(); break;
                    case "tb-put-away-in-storage": _sim.TxE = null; if (_tb.Lt) _sim.LightStore(); else _sim.EditStore(now); break;
                }
                return;
            }
        }

        /// <summary>The rotation slider pressed or dragged at frame x (slDown's at()).</summary>
        public void SliderAt(double fx, double now) { var it = _sim.ESelItem; if (it == null || _slX < -1e8) return; _sim.RotSet(it, (fx - _slX - 10) / 116 * 360, now); }

        /// <summary>The tray dragged by dx frame px (its scroll), or tapped at frame x: the card under it.</summary>
        public void TrayScroll(double dx) { _scroll = Math.Max(0, Math.Min(_scrollMax, _scroll - dx)); }
        public void TrayTap(double fx)
        {
            var well = R("rv-well"); double x = fx - well[0] - 10 + _scroll; if (x < 0 || _tray == null) return;
            int i = (int)Math.Floor(x / 87); if (i >= _tray.Count || x - i * 87 > 78) return;
            _sim.TrayGo(_tray[i].id);
        }

        public void Destroy() { foreach (var p in _p.Values) if (p != null) Object.Destroy(p.gameObject); _p.Clear(); }
    }
}
