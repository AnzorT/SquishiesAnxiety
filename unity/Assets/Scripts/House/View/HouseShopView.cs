// The Catalog's UI (HOUSE_PORT_PLAN.md stage 7), as Squad House v6.dc.html draws it while state.shop: the dimmed house,
// the room's tab, the header (House level, the coins, close), the open book with the room's header, the level range,
// 6 + 6 cards (picture, level badge, name in up to two balanced lines, price and coin, BUY / OWNED / IN USE / LV n),
// the category buttons, the paging; and a card's detail (its picture, what it does and its secret, level, name, room
// and slot, note, what you own, Buy · price, Place it / Put it up). The fixed pieces are the page's own
// (tools/unity/house/export-catalog.mjs); the rest is drawn here from the page's styles. Logic: House/HouseShop.cs.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseShopView
    {
        readonly HouseCreatures _sim;
        readonly Transform _parent;
        readonly float _k;
        readonly JObj _E;
        readonly Dictionary<string, UiPiece> _p = new Dictionary<string, UiPiece>();
        readonly Dictionary<string, string> _drawn = new Dictionary<string, string>();
        readonly HashSet<string> _used = new HashSet<string>();
        public Func<string, string> Pic;
        const int O = 32000;
        static readonly string[] BRASS = { "#ffe9a0", "#e2b14a", "#b8862a" }, GREYB = { "#e2dacd", "#bdb2a2" }, GREENB = { "#b6dc96", "#86bd68", "#679f4c" };
        static readonly float[] BRASS_AT = { 0, 0.6f, 1 }, GREENB_AT = { 0, 0.55f, 1 };

        public HouseShopView(Transform parent, HouseCreatures sim, float screenK, string shopJson)
        {
            _parent = parent; _sim = sim; _k = screenK; _E = (JObj)HouseJson.Parse(shopJson);
        }

        Affine Frame => Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp);
        double[] R(string id) { var a = _E.Obj("pieces").Arr(id); return a == null ? null : new[] { (double)a[0], (double)a[1], (double)a[2], (double)a[3] }; }

        UiPiece Fixed(string id, double x, double y, int order, Affine? around = null)
        {
            var r = R(id); if (r == null) return null;
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_parent, "shop " + id, order); p.SetSvg(HouseRoomView.Res("shop/" + id), (float)r[2], (float)r[3], 16); _p[id] = p; }
            p.Visible = true; p.Opacity = 1; p.Order = order;
            p.Transform = Frame * (around ?? Affine.Identity) * Affine.Translate(x, y); _used.Add(id);
            return p;
        }
        UiPiece Drawn(string id, string key, Func<UiSvg> draw, double x, double y, int order, Affine? around = null)
        {
            if (!_p.TryGetValue(id, out var p)) { p = UiPiece.Create(_parent, "shop " + id, order); _p[id] = p; }
            if (!_drawn.TryGetValue(id, out var k0) || k0 != key) { var s = draw(); p.SetSvg(s.Markup, s.W, s.H, 18); _drawn[id] = key; }
            p.Visible = true; p.Opacity = 1; p.Order = order; p.Transform = Frame * (around ?? Affine.Identity) * Affine.Translate(x, y); _used.Add(id);
            return p;
        }

        static string N(double v) => HouseGeo.N(Math.Round(v * 1000) / 1000);
        static TextStyle T(string font, float size, string color, float lh = 0, float ls = 0, Shadow[] sh = null) => new TextStyle { Font = font, Size = size, Color = color, LineHeight = lh, LetterSpacing = ls, Shadows = sh };

        // ---- text: wrapped to a width (greedy), or balanced over its lines (text-wrap: balance) ----
        public static List<string> Wrap(string text, TextStyle st, double width, bool balance = false)
        {
            var words = (text ?? "").Split(' '); var lines = new List<string>(); string cur = "";
            foreach (var w in words) { var t = cur == "" ? w : cur + " " + w; if (cur != "" && UiSvg.BoxWidth(t, st) > width) { lines.Add(cur); cur = w; } else cur = t; }
            if (cur != "") lines.Add(cur);
            if (!balance || lines.Count < 2) return lines;
            // balance: the narrowest width that still gives the same number of lines
            double lo = 0, hi = width;
            for (int i = 0; i < 14; i++) { double mid = (lo + hi) / 2; if (Wrap(text, st, mid).Count <= lines.Count) hi = mid; else lo = mid; }
            return Wrap(text, st, hi + 0.01);
        }
        static float LineH(TextStyle st) => st.LineHeight > 0 ? st.LineHeight : UiSvg.LineBox(st);
        static void Lines(UiSvg s, List<string> lines, double x, double top, double w, TextStyle st, double align)
        {
            float lh = LineH(st);
            for (int i = 0; i < lines.Count; i++) { float tw = UiSvg.BoxWidth(lines[i], st); s.Text(lines[i], (float)(x + (w - tw) * align), (float)(top + i * lh), st); }
        }

        // a picture (a row's drawing) contained in a box; align 1: at the bottom
        static int _picN;
        string PicInBox(string rowId, double x, double y, double w, double h, string par)
        {
            var S = _sim.S; var v = S.D.Variants.Obj(rowId + "|||-30") ?? HouseDraw.Variant(rowId, null, "", null, S.Cur);
            var name = v?.Str("whole"); var svg = string.IsNullOrEmpty(name) ? null : Pic?.Invoke(name);
            if (svg == null) return "";
            svg = new RoomCompose().InlineImages(svg, 0);
            var pre = "s" + (_picN++) + "_";
            svg = Regex.Replace(svg, "\\bid=\"([^\"]+)\"", m => "id=\"" + pre + m.Groups[1].Value + "\"").Replace("url(#", "url(#" + pre).Replace("href=\"#", "href=\"#" + pre);
            var m0 = Regex.Match(svg, "<svg\\b[^>]*>"); if (!m0.Success) return "";
            var vb = Regex.Match(m0.Value, "viewBox=\"([^\"]+)\"").Groups[1].Value;
            return $"<svg x=\"{N(x)}\" y=\"{N(y)}\" width=\"{N(w)}\" height=\"{N(h)}\" viewBox=\"{vb}\" preserveAspectRatio=\"{par}\">" + svg.Substring(m0.Index + m0.Length);
        }

        // ---- per frame ----
        List<(string id, double x, double y, double w, double h, string act)> _hits = new List<(string, double, double, double, double, string)>();
        public bool On => _sim.Shop;

        public void Update(double now)
        {
            _used.Clear(); _hits.Clear();
            if (!_sim.Shop) { foreach (var p in _p.Values) p.Visible = false; return; }
            var S = _sim.S; var v = _sim.Rc(); string rm = _sim.CRm ?? "LIV";
            Drawn("dim", "dim", () => new UiSvg(852, 393).Box(0, 0, 852, 393, new BoxStyle { Background = "rgba(40,22,10,0.55)" }), 0, 0, O);
            var bk = R("book"); Fixed("book", bk[0], bk[1], O + 1);
            string lk = v.open ? "" : "-lock";
            var rt = R("room-" + rm + lk) != null ? "room-" + rm + lk : "room-" + rm; var rr = R(rt); if (rr != null) Fixed(rt, rr[0], rr[1], O + 1);
            var ht = R("head-" + rm + lk) != null ? "head-" + rm + lk : "head-" + rm; var hr = R(ht); if (hr != null) Fixed(ht, hr[0], hr[1], O + 2);
            Header();
            // the level range (right-aligned, the right page's top line)
            var tst = T("Fredoka_600SemiBold", 12, "#8a6a4a");
            Drawn("tier", v.tierTxt, () => { var s = new UiSvg(362, 22); float tw = UiSvg.BoxWidth(v.tierTxt, tst); s.Text(v.tierTxt, 362 - tw, 0, tst); return s; }, 16 + 416, 29 + 14, O + 2);
            // the cards: two 3 x 2 grids, 368 x 282, gap 7
            for (int i = 0; i < 12; i++)
            {
                if (i >= v.cards.Count) continue;
                double gx = 16 + (i < 6 ? 19 : 413), gy = 29 + 38, cw = (368 - 14) / 3.0, ch = (282 - 7) / 2.0;
                int j = i % 6; double x = gx + (j % 3) * (cw + 7), y = gy + (j / 3) * (ch + 7);
                Card(i, v.cards[i], x, y, cw, ch);
            }
            Cats(v.cats);
            Paging(v.pi, v.np, v.prevC != null, v.nextC != null);
            if (v.cards.Count == 0)
            {
                var est = T("Fredoka_600SemiBold", 14, "#5b3418"); float ew = UiSvg.BoxWidth("Nothing here yet", est) + 32, eh = UiSvg.LineBox(est) + 16;
                Drawn("empty", "e", () => { var s = new UiSvg(ew, eh); s.Box(0, 0, ew, eh, new BoxStyle { Background = "#fff6e2", Radius = 8, Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 2), new Shadow("rgba(107,68,38,0.35)", 0, 3, 0, 2) } }); s.Text("Nothing here yet", 16, 8, est); return s; },
                    0, 0, O + 3, Affine.Translate(426, 29 + 150 + eh / 2) * Affine.Rotate(-2) * Affine.Translate(-ew / 2, -eh / 2));
            }
            Detail();
            foreach (var kv in _p) if (!_used.Contains(kv.Key)) kv.Value.Visible = false;
        }

        // the header's right group (right 38, top 1, height 28, gap 6): House level, the coins, close
        void Header()
        {
            var lst = T("Fredoka_700Bold", 13, "#5b3418");
            var li = R("lv-icon"); var ci = R("coin-icon"); var cl = R("close");
            string lvT = "Lv " + _sim.S.Level, coT = _sim.Coins().ToString("#,0", CultureInfo.InvariantCulture);
            double lvW = 2 + 5 + li[2] + 4 + UiSvg.BoxWidth(lvT, lst) + 8 + 2, coW = 2 + 4 + ci[2] + 4 + UiSvg.BoxWidth(coT, lst) + 9 + 2;
            double xc = 852 - 38 - cl[2], xco = xc - 6 - coW, xlv = xco - 6 - lvW, y = 1 + (28 - 25) / 2.0;
            Fixed("close", xc, y, O + 2); _hits.Add(("close", xc, y, cl[2], 25, "closeshop"));
            Drawn("lv", lvT, () => { var s = new UiSvg((float)lvW, 25); s.Box(0, 0, (float)lvW, 25, new BoxStyle { Gradient = BRASS, GradientStops = BRASS_AT, Radius = 7, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 2, 0) } }); s.Text(lvT, (float)(2 + 5 + li[2] + 4), (25 - UiSvg.LineBox(lst)) / 2, lst); return s; }, xlv, y, O + 2);
            Fixed("lv-icon", xlv + 2 + 5, y + (25 - li[3]) / 2, O + 3);
            Drawn("coins", coT, () => { var s = new UiSvg((float)coW, 25); s.Box(0, 0, (float)coW, 25, new BoxStyle { Background = "#fff6e2", Radius = 7, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 2, 0) } }); s.Text(coT, (float)(2 + 4 + ci[2] + 4), (25 - UiSvg.LineBox(lst)) / 2, lst); return s; }, xco, y, O + 2);
            Fixed("coin-icon", xco + 2 + 4, y + (25 - ci[3]) / 2, O + 3);
        }

        void Card(int i, ShopCard c, double x, double y, double w, double h)
        {
            var nst = T("Fredoka_700Bold", 10, "#5b3418", 11.5f);
            var pst = T("Fredoka_700Bold", 11.5f, "#5b3418");
            var bst = T("Fredoka_700Bold", 10, c.Look == "lock" ? "#5a4a3a" : c.Look == "own" ? "#ffffff" : "#5b3418", 0, 0.4f);
            var tst = T("Fredoka_700Bold", 9.5f, "#ffffff", 13);
            double iw = w - 4 - 12, ih = h - 4 - 12 - 8 - 23 - 20 - 6, nameTop = 2 + 6 + 8 + ih + 3, rowTop = nameTop + 23 + 3;
            float pw = UiSvg.BoxWidth(c.Price, pst), bw = UiSvg.BoxWidth(c.BTxt, bst) + 20, rowW = pw + 3 + 11 + 6 + bw;
            double rx = (w - rowW) / 2, bx = rx + pw + 3 + 11 + 6;
            string key = c.Id + c.BTxt + c.Cnt + c.HasCnt + c.Look;
            Drawn("card" + i, key, () =>
            {
                var s = new UiSvg((float)w, (float)h);
                s.Box(0, 0, (float)w, (float)h, new BoxStyle { Gradient = new[] { "#fbefd2", "#f4e2bc" }, Radius = 9, BorderWidth = 2, BorderColor = "#d4b685", Shadows = new[] { new Shadow("rgba(107,68,38,0.18)", 0, 2, 0) } });
                s.Box(3 + 2, 3 + 2, (float)w - 10, (float)h - 10, new BoxStyle { Radius = 6, BorderWidth = 1.5f, BorderColor = "rgba(107,68,38,0.22)", Dashed = true });
                var pic = PicInBox(c.Id, 8, 16, iw, ih, "xMidYMax meet");
                if (pic != "") s.Raw(c.Locked ? "<g opacity=\"0.55\">" + pic + "</g>" : pic);
                float tw = UiSvg.BoxWidth(c.Tier, tst) + 8;
                s.Box(9, 8, tw, 13, new BoxStyle { Background = c.Locked ? "#9a8f80" : "#c98d52", Radius = 4, Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 1.5f) } });
                s.Text(c.Tier, 13, 8, tst);
                var nl = Wrap(c.Name, nst, w - 16, true); if (nl.Count > 2) { nl = nl.GetRange(0, 2); nl[1] += "\u2026"; }
                Lines(s, nl, 8, nameTop + (nl.Count == 1 ? 0 : 0), w - 16, nst, 0.5);
                s.Text(c.Price, (float)rx, (float)(rowTop + (20 - UiSvg.LineBox(pst)) / 2), pst);
                s.Raw($"<defs><radialGradient id=\"cg{i}\" cx=\"0.35\" cy=\"0.3\" r=\"0.75\"><stop offset=\"0\" stop-color=\"#fff3c4\"/><stop offset=\"0.45\" stop-color=\"#f2c255\"/><stop offset=\"1\" stop-color=\"#b8862a\"/></radialGradient></defs><circle cx=\"{N(rx + pw + 3 + 5.5)}\" cy=\"{N(rowTop + 10)}\" r=\"6.25\" fill=\"#6b4426\"/><circle cx=\"{N(rx + pw + 3 + 5.5)}\" cy=\"{N(rowTop + 10)}\" r=\"5.5\" fill=\"url(#cg{i})\"/>");
                var bs = new BoxStyle { Radius = 6, BorderWidth = 2, BorderColor = c.Look == "lock" ? "#7a6a58" : "#6b4426", Shadows = new[] { new Shadow(c.Look == "lock" ? "#7a6a58" : "#6b4426", 0, 2, 0) } };
                if (c.Look == "lock") bs.Gradient = GREYB; else if (c.Look == "own") { bs.Gradient = GREENB; bs.GradientStops = GREENB_AT; } else { bs.Gradient = BRASS; bs.GradientStops = BRASS_AT; }
                s.Box((float)bx, (float)rowTop, bw, 20, bs);
                s.Text(c.BTxt, (float)bx + 10, (float)(rowTop + (20 - UiSvg.LineBox(bst)) / 2), bst);
                return s;
            }, x, y, O + 3);
            _hits.Add(("card-img", x + 8, y + 16, iw, ih, "det:" + c.Id));
            _hits.Add(("card-btn", x + bx, y + rowTop, bw, 20, "act:" + c.Id));
        }

        void Cats(List<(string id, string label, bool on, bool any)> cats)
        {
            var st = T("Fredoka_700Bold", 10.5f, "#5b3418", 10.5f);
            double x = 16 + 20, y = 29 + 327 + (22 - 21) / 2.0;
            for (int i = 0; i < cats.Count; i++)
            {
                var c = cats[i]; float w = UiSvg.BoxWidth(c.label, st) + 16;
                Drawn("cat" + i, c.label + c.on + c.any, () =>
                {
                    var s = new UiSvg(w, 21); var bs = new BoxStyle { Radius = 6, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow(c.on ? "#6b4426" : "rgba(107,68,38,0.35)", 0, 2, 0) }, Opacity = c.any ? 1 : 0.45f };
                    if (c.on) { bs.Gradient = BRASS; bs.GradientStops = BRASS_AT; } else bs.Background = "#fff6e2";
                    s.Box(0, 0, w, 21, bs); var t2 = T(st.Font, st.Size, st.Color, st.LineHeight); t2.Opacity = c.any ? 1 : 0.45f; s.Text(c.label, 8, (21 - 10.5f) / 2, t2); return s;
                }, x, y, O + 3);
                _hits.Add(("cat", x, y, w, 21, "cat:" + c.id));
                x += w + 4;
            }
        }

        void Paging(int pi, int np, bool prevC, bool nextC)
        {
            var st = T("Fredoka_600SemiBold", 11.5f, "#8a6a4a"); string txt = "Page " + (pi + 1) + " of " + np; float tw = UiSvg.BoxWidth(txt, st);
            double right = 16 + 414 + 366, y = 29 + 326, nx = right - 24, tx = nx - 8 - tw, px = tx - 8 - 24;
            var pp = Fixed("prev", px, y, O + 3); pp.Opacity = pi > 0 || prevC ? 1 : 0.4f; _hits.Add(("prev", px, y, 24, 24, "prev"));
            var np2 = Fixed("next", nx, y, O + 3); np2.Opacity = pi < np - 1 || nextC ? 1 : 0.4f; _hits.Add(("next", nx, y, 24, 24, "next"));
            Drawn("page", txt, () => { var s = new UiSvg(tw, 24); s.Text(txt, 0, (24 - UiSvg.LineBox(st)) / 2, st); return s; }, tx, y, O + 3);
        }

        // ---- the detail card ----
        void Detail()
        {
            var d = _sim.Rd(); if (d == null) return;
            Drawn("ddim", "d", () => new UiSvg(852, 393).Box(0, 0, 852, 393, new BoxStyle { Background = "rgba(40,22,10,0.4)" }), 0, 0, O + 10);
            var r = R("det"); double x0 = r[0], y0 = r[1], W = r[2], Hh = r[3];
            var around = Affine.Translate(x0 + W / 2, y0 + Hh / 2) * Affine.Rotate(-0.6) * Affine.Translate(-(x0 + W / 2), -(y0 + Hh / 2));
            Fixed("det", x0, y0, O + 11, around);
            var dc = R("det-close"); Fixed("det-close", dc[0], dc[1], O + 14, around); _hits.Add(("dclose", dc[0], dc[1], dc[2], dc[3], "close"));
            bool fx = d.What != "";
            var wst = T("Fredoka_600SemiBold", 11, "#16668f", 13.42f); var sst = T("Fredoka_700Bold", 11, "#9a6a12", 13.42f); var lst = T("Nunito_900Black", 9, "#1e8fc4", 0, 0.81f);
            var wl = fx ? Wrap(d.What, wst, 184) : new List<string>(); var sl = fx && d.Sec != "" ? Wrap("\u2605 Secret: " + d.Sec, sst, 184) : new List<string>();
            double fxH = fx ? 5 + UiSvg.LineBox(lst) + 3 + wl.Count * 13.42 + (sl.Count > 0 ? 3 + sl.Count * 13.42 : 0) + 5 : 0, imgH = fx ? 122 : 170;
            double colH = Hh - 28, contH = imgH + (fx ? 8 + fxH : 0), cy = y0 + 14 + (colH - contH) / 2;
            string key = d.Id + d.Own + d.CanBuy + d.HasPlace + d.Locked + d.CanAfford;
            Drawn("dbody", key, () =>
            {
                var s = new UiSvg((float)W, (float)Hh);
                // the left column: the picture, then what it does
                var pic = PicInBox(d.Id, 14 + 12, cy - y0, 196, imgH, "xMidYMid meet"); if (pic != "") s.Raw(pic);
                if (fx)
                {
                    double fy = cy - y0 + imgH + 8;
                    s.Box(14 + 10, (float)fy, 200, (float)fxH, new BoxStyle { Background = "#e6f7ff", Radius = 7, Shadows = new[] { new Shadow("#1e8fc4", 0, 0, 0, 1.5f) } });
                    s.Text("WHAT IT DOES", 14 + 18, (float)fy + 5, lst);
                    double ty = fy + 5 + UiSvg.LineBox(lst) + 3; Lines(s, wl, 14 + 18, ty, 184, wst, 0); ty += wl.Count * 13.42;
                    if (sl.Count > 0) Lines(s, sl, 14 + 18, ty + 3, 184, sst, 0);
                }
                // the right column (x 248, 258 wide): level, name, room, note, owned; the buttons at the bottom
                double rx = 14 + 220 + 14, rw = W - 14 - rx, yy = 14 + 4;
                var lvs = T("Fredoka_700Bold", 11, "#fff6e2", 0, 0, new[] { new Shadow("#6b4426", 0, 1, 0) }); float lw = UiSvg.BoxWidth(d.LvTxt, lvs) + 22;
                s.Box((float)rx, (float)yy, lw, 20, new BoxStyle { Background = d.LvLock ? "#9a8f80" : "#c98d52", Radius = 5, BorderWidth = 2, BorderColor = "#6b4426" });
                s.Text(d.LvTxt, (float)rx + 11, (float)(yy + (20 - UiSvg.LineBox(lvs)) / 2), lvs); yy += 20 + 5;
                var nst = T("Fredoka_700Bold", 19, "#5b3418", 21.28f); var nl = Wrap(d.Name, nst, rw, true); Lines(s, nl, rx, yy, rw, nst, 0); yy += nl.Count * 21.28 + 5;
                var rst = T("Nunito_800ExtraBold", 11, "#8a6a4a"); s.Text(d.Room, (float)rx, (float)yy, rst); yy += UiSvg.LineBox(rst) + 5;
                if (d.Desc != "") { var dst = T("Nunito_700Bold", 11.5f, "#7a5a3a", 14.95f); var dl = Wrap(d.Desc, dst, rw); Lines(s, dl, rx, yy, rw, dst, 0); yy += dl.Count * 14.95 + 5; }
                var ost = T("Nunito_800ExtraBold", 11, "#2f7a42"); if (d.Own != "") s.Text(d.Own, (float)rx, (float)yy, ost);
                foreach (var (kind, by) in Buttons(d, Hh))
                {
                    if (kind == "lock")
                    {
                        s.Box((float)rx, (float)by, (float)rw, 36, new BoxStyle { Gradient = GREYB, Radius = 8, BorderWidth = 2, BorderColor = "#7a6a58" });
                        var ls = T("Fredoka_700Bold", 14, "#5a4a3a"); var li = R("lock-icon"); double liw = li != null ? li[2] : 0; float tw = UiSvg.BoxWidth(d.LockTxt, ls);
                        s.Text(d.LockTxt, (float)(rx + (rw - (liw + 6 + tw)) / 2 + liw + 6), (float)(by + (36 - UiSvg.LineBox(ls)) / 2), ls);
                    }
                    else if (kind == "buy")
                    {
                        var bs = new BoxStyle { Radius = 8, BorderWidth = 2.5f, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 3, 0) } };
                        if (d.CanAfford) { bs.Gradient = BRASS; bs.GradientStops = BRASS_AT; } else bs.Gradient = GREYB;
                        s.Box((float)rx, (float)by, (float)rw, 36, bs);
                        var bt = T("Fredoka_700Bold", 15, "#5b3418"); string txt = "Buy \u00b7 " + d.Price; float tw = UiSvg.BoxWidth(txt, bt), cx = (float)(rx + (rw - (16 + 7 + tw)) / 2);
                        s.Raw($"<defs><radialGradient id=\"bcg\" cx=\"0.35\" cy=\"0.3\" r=\"0.75\"><stop offset=\"0\" stop-color=\"#fff3c4\"/><stop offset=\"0.45\" stop-color=\"#f2c255\"/><stop offset=\"1\" stop-color=\"#b8862a\"/></radialGradient></defs><circle cx=\"{N(cx + 8)}\" cy=\"{N(by + 18)}\" r=\"8.75\" fill=\"#6b4426\"/><circle cx=\"{N(cx + 8)}\" cy=\"{N(by + 18)}\" r=\"8\" fill=\"url(#bcg)\"/>");
                        s.Text(txt, cx + 23, (float)(by + (36 - UiSvg.LineBox(bt)) / 2), bt);
                    }
                    else
                    {
                        s.Box((float)rx, (float)by, (float)rw, 36, new BoxStyle { Gradient = GREENB, GradientStops = GREENB_AT, Radius = 8, BorderWidth = 2.5f, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, 3, 0) } });
                        var pt = T("Fredoka_700Bold", 15, "#fff6e2", 0, 0, new[] { new Shadow("#6b4426", 0, 1.5f, 0), new Shadow("#6b4426", 1, 0, 0), new Shadow("#6b4426", -1, 0, 0) }); float tw = UiSvg.BoxWidth(d.PlaceTxt, pt);
                        s.Text(d.PlaceTxt, (float)(rx + (rw - tw) / 2), (float)(by + (36 - UiSvg.LineBox(pt)) / 2), pt);
                    }
                }
                return s;
            }, x0, y0, O + 12, around);
            foreach (var (kind, by) in Buttons(d, Hh))
            {
                double rx = x0 + 14 + 220 + 14, rw = W - 14 - (14 + 220 + 14);
                if (kind == "lock") { var li = R("lock-icon"); if (li != null) { var ls = T("Fredoka_700Bold", 14, "#5a4a3a"); float tw = UiSvg.BoxWidth(d.LockTxt, ls); Fixed("lock-icon", rx + (rw - (li[2] + 6 + tw)) / 2, y0 + by + (36 - li[3]) / 2, O + 13, around); } }
                else _hits.Add((kind, rx, y0 + by, rw, 36, kind == "buy" ? "buy:" + d.Id : "place:" + d.Id));
            }
            _hits.Add(("dcard", x0, y0, W, Hh, "stop"));
            _hits.Add(("dout", 0, 0, 852, 393, "close"));
        }

        // the buttons at the bottom of the detail's right column (top to bottom: locked, buy, place), each 36 high, gap 7
        static List<(string kind, double y)> Buttons(HouseCreatures.ShopDet d, double H)
        {
            var ks = new List<string>(); if (d.Locked) ks.Add("lock"); if (d.CanBuy) ks.Add("buy"); if (d.HasPlace) ks.Add("place");
            double y = H - 14 - (ks.Count * 36 + Math.Max(0, ks.Count - 1) * 7); var o = new List<(string, double)>();
            foreach (var k in ks) { o.Add((k, y)); y += 36 + 7; }
            return o;
        }

        /// <summary>A tap at a frame point while the Catalog is open (it takes every tap).</summary>
        public void Tap(double fx, double fy, double now)
        {
            // the detail first (z 5 over the book), the topmost hit last added among the detail's, else the book's
            var detOpen = _sim.Det != null;
            for (int i = 0; i < _hits.Count; i++)
            {
                var h = _hits[i]; bool det = h.id == "dclose" || h.id == "buy" || h.id == "place" || h.id == "dcard" || h.id == "dout";
                if (detOpen != det) continue;
                if (fx < h.x || fx > h.x + h.w || fy < h.y || fy > h.y + h.h) continue;
                var a = h.act;
                if (a == "stop") return;
                if (a == "close") { _sim.CloseDet(); return; }
                if (a == "closeshop") { _sim.CloseShop(); return; }
                if (a == "prev") { _sim.PrevPage(); return; }
                if (a == "next") { _sim.NextPage(); return; }
                if (a.StartsWith("cat:")) { _sim.SetCat(a.Substring(4)); return; }
                if (a.StartsWith("det:")) { _sim.OpenDet(a.Substring(4)); return; }
                if (a.StartsWith("act:")) { _sim.CardAct(a.Substring(4)); return; }
                if (a.StartsWith("buy:")) { _sim.BuyR(a.Substring(4)); return; }
                if (a.StartsWith("place:")) { _sim.PlaceR(a.Substring(6)); return; }
            }
        }

        public void Destroy() { foreach (var p in _p.Values) if (p != null) Object.Destroy(p.gameObject); _p.Clear(); }
    }
}
