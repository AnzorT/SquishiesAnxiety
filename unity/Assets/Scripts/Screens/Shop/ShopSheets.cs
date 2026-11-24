// The Shop's sheets in the royal look (ShopScreen.js Sheet `royal`): over the scrim, a pearl panel in the middle
// (springing in: opacity and 0.92 → 1, friction 8, tension 80) with the 36 dp close orb at its corner:
//   gchest  a chest's (ShopChests.js ChestSheetBody `wide`, REDESIGN_V8): its art on the group's backdrop and the
//           buy button on the left; its size and group, name, the upgrade chance, the odds, who's inside (with the
//           copies found), what a duplicate pays on the right. An earned Rainbow chest: EarnedSheetBody.
//   odds    every size's drop odds (OddsSheetBody)
//   broke   not enough coins / gems, GET COINS / GET GEMS (to the Gems tab)
// The panel's content scrolls (a drag or the wheel) when it's taller than the panel allows.
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;
using static SquishSquad.Screens.ShopArt;

namespace SquishSquad.Screens
{
    public sealed partial class ShopView
    {
        sealed class Sheet { public string Type, Gk, Size, Cur; public double Need; }
        Sheet _sheet;
        readonly AnimatedValue _up = new AnimatedValue(0);
        Loop _sheetBob;
        float _sheetScroll, _sheetMax;
        string _sheetSvg;

        public string SheetType => _sheet?.Type;

        void OpenSheet(Sheet s)
        {
            _sheet = s;
            _sheetScroll = 0;
            _sheetSvg = null;
            _up.StopAnimation();
            _up.SetValue(0);
            Animated.Spring(_up, new SpringConfig { ToValue = 1, Friction = 8, Tension = 80 }).Start();
            _sheetBob = new Loop(_t, 2600);
        }

        void CloseSheet() { _sheet = null; _sheetSvg = null; }

        void SheetWheel(float dy)
        {
            float s = Math.Max(0, Math.Min(_sheetMax, _sheetScroll + dy));
            if (s != _sheetScroll) { _sheetScroll = s; _sheetSvg = null; }
        }

        static readonly string[] TC_C = { "#a0623a", "#2f7ad6", "#8a3cff", "#d98200", "#d6249a" };
        static readonly (string name, string bg, string ink)[] RAR_ROW = { ("Common", "#e3f1ff", "#2f6fc0"), ("Rare", "#e3fbe9", "#17803a"), ("Epic", "#f1e6ff", "#6a22d6"), ("Legendary", "#fff3d6", "#b86200") };
        static readonly Dictionary<string, string> GROUP_CAPS = ShopData.GROUP_LABEL.ToDictionary(kv => kv.Key, kv => kv.Value.ToUpperInvariant());

        static readonly TextStyle SheetName = T(Kit.Display, 26, "#5b3418", 0, 28);
        static readonly TextStyle SheetUp = T(Heavy, 12, "#17803a");
        static readonly TextStyle OddPct0 = T(Kit.Display, 16, "#000"), OddName0 = T(Black, 9.5f, "#000");
        static readonly TextStyle Inside = T(Black, 12.5f, "#5b3418"), HaveT = T(Heavy, 11.5f, "#9a6a3a");
        static readonly TextStyle CoinsLine = T(Body, 11.5f, "#9a6a3a");
        static readonly TextStyle MonNew = T(Black, 8, "#ffffff");

        void SheetPieces(List<ScreenPiece> list)
        {
            if (_sheet == null) return;
            double up = _up.GetValue();
            list.Add(Piece("scrim", new UiSvg(SW, SH).Box(0, 0, SW, SH, new BoxStyle { Background = "rgba(30,0,60,0.55)" }), 0, 0, 1, null, 0));
            _hits.Add("scrim", 0, 0, SW, SH);
            bool wide = _sheet.Type == "gchest";
            float pw = wide ? 700 : 540, maxH = wide ? 352 : 340, vw = pw - 36;
            var (content, ch) = SheetContent(vw);
            float ph = Math.Min(maxH, 16 + ch + 6 + 14), vh = ph - 30;
            _sheetMax = Math.Max(0, ch + 6 - vh);
            float px = (SW - pw) / 2, py = (SH - ph) / 2;
            var m = Affine.Translate(px, py) * About(pw, ph, Affine.ScaleBy(0.92 + 0.08 * up, 0.92 + 0.08 * up));
            // (the panel, its content and the orb fade as one: an Animated.View's opacity is the group's)
            var group = new List<ScreenPiece>();
            var s = new UiSvg(pw, ph);
            Plaque(s, 0, 0, pw, ph, "pearl", 24, 3.5f, 2, 4);
            group.Add(Piece("sheet", s, 0, 0, 1, m, 10));
            // the content, clipped to the scroll view and scrolled
            if (_sheetSvg == null)
            {
                var v = new UiSvg(vw, vh);
                var clip = v.NewId("sv");
                v.Def($"<clipPath id=\"{clip}\"><rect x=\"0\" y=\"0\" width=\"{F(vw)}\" height=\"{F(vh)}\"/></clipPath>");
                v.Open($"clip-path=\"url(#{clip})\"");
                v.Open($"transform=\"translate(0 {F(-_sheetScroll)})\"");
                v.Raw(content.inner);
                v.Def(content.defs);
                v.Close();
                v.Close();
                _sheetSvg = v.Markup;
            }
            group.Add(Piece("sheet-body", _sheetSvg, vw, vh, 0, 0, 1, m * Affine.Translate(18, 16), 0));
            // the chest bobbing on its backdrop, and the buy button (pieces of their own: they move)
            foreach (var p in _sheetLive) { p.Transform = m * Affine.Translate(18, 16 - _sheetScroll) * p.Transform; group.Add(p); }
            group.Add(Piece("orb-close", ShopXml("orb-close36"), 36, 36, 0, 0, 1, m * Affine.Translate(pw - 36 + 12, -12) * Shrink(_pressed == "sheet-close", 18, 18)));
            float op = (float)Math.Min(1, Math.Max(0, up));
            if (op < 0.999f) list.Add(Piece("sheet-all", SquishSquad.Ui.Screens.Pieces.Compose(group, SW, SH), SW, SH, 0, 0, op, null, 0));
            else list.AddRange(group);
            _hits.Add("sheet", px, py, pw, ph);
            foreach (var h in _sheetHits) _hits.Add(h.id, px + 18 + h.x, py + 16 - _sheetScroll + h.y, h.w, h.h);
            _hits.Add("sheet-close", px + pw - 36 + 12, py - 12, 36, 36, 8);
        }

        static readonly Dictionary<string, string> ShopXmls = new Dictionary<string, string>();
        public static string ShopXml(string name)
        {
            if (ShopXmls.TryGetValue(name, out var x)) return x;
            x = Roster.ReadText?.Invoke("Shop/" + name) ?? throw new InvalidOperationException($"Resources/Shop/{name}.xml is missing: run node tools/unity/export-shop.mjs");
            return ShopXmls[name] = x;
        }

        readonly List<ScreenPiece> _sheetLive = new List<ScreenPiece>();
        readonly List<(string id, float x, float y, float w, float h)> _sheetHits = new List<(string, float, float, float, float)>();

        /// <summary>The scroll view's content (its inner SVG and defs) and height, width `vw`.</summary>
        ((string inner, string defs), float h) SheetContent(float vw)
        {
            _sheetLive.Clear();
            _sheetHits.Clear();
            var s = new UiSvg(vw, 2000);
            float h = 0;
            if (_sheet.Type == "odds") h = OddsBody(s, vw);
            else if (_sheet.Type == "broke") h = BrokeBody(s, vw);
            else if (_sheet.Type == "gchest") h = ChestBody(s, vw);
            string m = s.Markup;
            int a = m.IndexOf("<defs>") + 6, b = m.IndexOf("</defs>");
            string defs = m.Substring(a, b - a);
            string inner = m.Substring(b + 7, m.LastIndexOf("</svg>") - b - 7);
            return ((inner, defs), h);
        }

        static readonly TextStyle OddsName0 = T(Kit.Display, 14, "#000"), OddsOdds = T(Heavy, 11.5f, "#5b3418"), OddsNote = T(Body, 11, "#9a6a3a", 0, 15.5f);

        float OddsBody(UiSvg s, float vw)
        {
            bool earned = ShopData.RainbowMode == "chest";
            float y = 0;
            var (tw, th) = (W("Drop odds", SheetName), LH(SheetName));
            s.Text("Drop odds", (vw - tw) / 2, y, SheetName);
            y += th + 10;
            for (int i = 0; i < ShopData.Sizes.Count; i++)
            {
                var T0 = ShopData.Sizes[i];
                string odds = earned && T0.K == "set" ? "Not sold: earned once by unlocking a group, with its Rainbow pal" : $"100% {ShopData.SIZE_NAME[T0.I]} pals";
                var flow = new TextFlow(odds, OddsOdds);
                float fw = vw - 24 - 80 - 8, fh = flow.Measure(fw).h;
                var nt = T(Kit.Display, 14, TC_C[i]);
                float rh = Math.Max(LH(nt), fh) + 18;
                s.Box(0, y, vw, rh, new BoxStyle { Radius = 14, Background = "#f6ead8" });
                s.Text(ShopData.SIZE_NAME[i], 12, y + (rh - LH(nt)) / 2, nt);
                flow.Draw(s, 12 + 80 + 8, y + (rh - fh) / 2, fw);
                y += rh + 10;
            }
            string note = "Each chest holds only pals of its own rarity. Common and Rare chests can upgrade on your first smash, and then hold the rarity they became. Duplicates turn into coins." + (earned ? " Rainbow pals come only from their group's Rainbow chest." : "");
            var nf = new TextFlow(note, OddsNote, 0);
            float nh = nf.Measure(vw).h;
            // (a Text in a column with alignItems center: as wide as its longest line, centred)
            nf.Draw(s, 0, y, vw);
            return y + nh;
        }

        float BrokeBody(UiSvg s, float vw)
        {
            bool gems = _sheet.Cur == "gems";
            var tt = T(Kit.Display, 24, "#8a3a0e");
            var st = T(Heavy, 13, "#6a1b9a");
            string title = gems ? "Not enough gems" : "Not enough coins", sub = $"You need {Prof.Fmt(_sheet.Need)} more {(gems ? "gems" : "coins")}";
            float y = 0;
            TxtC(s, title, vw / 2, y, tt); y += LH(tt) + 10;
            TxtC(s, sub, vw / 2, y, st); y += LH(st) + 10;
            // CandyBtn gold, stretched, padV 12, lip 5: GET GEMS / GET COINS
            var bt = T(Kit.Display, 18, "#ffffff", 0, 0, Outline3("#9c4d06", 2));
            float faceH = LH(bt) + 24 + 6, bh = faceH + 5 + 5;
            // (a piece of its own, over the body: it shrinks to 92 % while held, as the chest sheet's buy button)
            var btn = new UiSvg(vw, bh);
            CandyRinged(btn, 0, 0, vw, faceH, "#9c4d06", new[] { "#fff7b0", "#ffd23a", "#ff9c0a" }, 5, 2.5f, 3);
            string label = gems ? "GET GEMS" : "GET COINS";
            TxtC(btn, label, vw / 2, 2.5f + 3 + 12, bt);
            _sheetLive.Add(Piece("broke-go", btn, 0, y, 1, Shrink(_pressed == "broke-go", vw / 2, bh / 2), 4));
            _sheetHits.Add(("broke-go", 0, y, vw, bh));
            return y + bh;
        }

        /// <summary>squad/ui.js Ringed (+ CandyBtn's shine): the ring with its lip, the white border, the gradient face.</summary>
        public static void CandyRingedPublic(UiSvg s, float x, float y, float w, float faceH, string ring, string[] colors, float lip, float ringW, float border, bool shine = true, float radius = 999) => CandyRinged(s, x, y, w, faceH, ring, colors, lip, ringW, border, shine, radius);

        internal static void CandyRinged(UiSvg s, float x, float y, float w, float faceH, string ring, string[] colors, float lip, float ringW, float border, bool shine = true, float radius = 999)
        {
            float H = faceH + 2 * ringW + lip;
            s.Box(x, y, w, H, new BoxStyle { Radius = radius + ringW, Background = ring });
            float ix = x + ringW, iy = y + ringW, iw = w - 2 * ringW;
            float bw = Bw(border);
            s.Box(ix, iy, iw, faceH, new BoxStyle { Radius = radius, Background = "#ffffff" });
            var stops = colors.Length == 3 ? new[] { 0f, 0.5f, 1 } : null;
            var clip = s.NewId("rg");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(ix + bw, iy + bw, iw - 2 * bw, faceH - 2 * bw, new[] { Math.Max(0, radius - bw), Math.Max(0, radius - bw), Math.Max(0, radius - bw), Math.Max(0, radius - bw) })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(ix, iy, iw, faceH, new BoxStyle { Gradient = colors, GradientStops = stops });
            if (shine) s.Box(ix + bw + (iw - 2 * bw) * 0.09f, iy + bw + 2, (iw - 2 * bw) * 0.82f, (faceH - 2 * bw) * 0.42f, new BoxStyle { Radius = 999, Background = "rgba(255,255,255,0.45)" });
            s.Close();
        }

        float ChestBody(UiSvg s, float vw)
        {
            var C = ShopData.Chest(_sheet.Gk, _sheet.Size, _profile, _artIds);
            var w = Wallet;
            float lw = 230, rx = lw + 16, rw = vw - rx;
            // the left: the art (a piece: it bobs) and the buy button
            var clip = s.NewId("sa");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(0, 0, lw, 196, new[] { 22f, 22, 22, 22 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            Cover(s, Backdrop(_sheet.Gk), 0, 0, lw, 196);
            s.Close();
            var art = new UiSvg(240, 184);
            Contain(art, Chest(_sheet.Gk, (C.Earned != null ? "set" : _sheet.Size) + "-grow"), 0, 0, 240, 184);
            _sheetLive.Add(Piece("sheet-art", art, lw / 2 - 120, 10 + _sheetBob.PingPong(0, -7), 1, null, 0));
            bool afford, gems = C.T.Cur == "gems";
            string label;
            string[] bg; string rim, ink, ts;
            if (C.Earned != null)
            {
                var e = C.Earned;
                afford = false;
                label = e.Opened ? "Opened" : e.Ready ? "Open free!" : $"Unlock all {e.Need} pals";
                bg = C.LookBg; rim = C.LookRim; ink = C.LookInk; ts = C.LookTs;
            }
            else
            {
                afford = (gems ? w.gems : w.coins) >= C.T.Price;
                label = afford ? $"Open · {Prof.Fmt(C.T.Price)}" : $"Get more {C.T.Cur}";
                bg = afford ? C.LookBg : ShopData.GREY_LOOK_BG; rim = afford ? C.LookRim : "#b8a8d4"; ink = afford ? C.LookInk : "#8a78b0"; ts = afford ? C.LookTs : null;
            }
            var b = new UiSvg(lw, 61);
            CandyFace(b, 0, 0, lw, 52, rim, bg, 5, 20);
            var lt = T(Kit.Display, 20, ink, 0, 0, ts != null ? new[] { new Shadow(ts, 0, 2, 0), new Shadow(ts, 1.5f, 0, 0), new Shadow(ts, -1.5f, 0, 0), new Shadow(ts, 0, -1.5f, 0) } : null);
            float tw = W(label, lt) + (afford ? 36 : 0), tx = (lw - tw) / 2;
            if (afford) { Contain(b, gems ? Gem(0) : Coin(0), tx, 2 + 11, 30, 30); tx += 36; }
            b.Text(label, tx, 2 + (52 - LH(lt)) / 2, lt);
            bool down = _pressed == "sheet-buy";
            _sheetLive.Add(Piece("sheet-buy", b, 0, 196 + 10, 1, Shrink(down, lw / 2, 61 / 2f), 4));   // (held: 92 %, lip and all)
            _sheetHits.Add(("sheet-buy", 0, 206, lw, 61));
            float leftH = 196 + 10 + 61;
            // the right
            float y = 0, cx = rx + rw / 2;
            var tagT = T(Black, 10.5f, TC_C[C.Ti], 1);
            string tag = C.Earned != null ? $"{GROUP_CAPS[_sheet.Gk]} · RAINBOW · ONCE ONLY" : $"{GROUP_CAPS[_sheet.Gk]} · {ShopData.SIZE_NAME[C.Ti].ToUpperInvariant()}";
            float tgw = W(tag, tagT) + 24, tgh = LH(tagT) + 6;
            s.Box(cx - tgw / 2, y, tgw, tgh, new BoxStyle { Radius = 999, Background = "#f6ead8" });
            s.Text(tag, cx - tgw / 2 + 12, y + 3, tagT);
            y += tgh + 8;
            TxtC(s, C.Name, cx, y, SheetName); y += LH(SheetName) + 8;
            if (C.Earned != null) y = EarnedRight(s, C, rx, rw, y);
            else
            {
                if (C.UpNote != "") { TxtC(s, C.UpNote, cx, y, SheetUp); y += LH(SheetUp) + 8; }
                // the odds
                // (one: each chest holds only its own rarity, 2026-11-18)
                float oh = 7 + LH(OddPct0) + 1 + LH(OddName0) + 7;
                {
                    int i = C.Ti;
                    s.Box(rx, y, rw, oh, new BoxStyle { Radius = 12, Background = RAR_ROW[i].bg });
                    var pt = T(Kit.Display, 16, RAR_ROW[i].ink); var nt = T(Black, 9.5f, RAR_ROW[i].ink);
                    TxtC(s, "100%", rx + rw / 2, y + 7, pt);
                    TxtC(s, RAR_ROW[i].name, rx + rw / 2, y + 7 + LH(pt) + 1, nt);
                }
                y += oh + 8;
                y = InsideRow(s, "Squishies inside", $"{C.Have} / {C.Pool.Count} collected", rx, rw, y);
                y = Mons(s, C.Pool, rx, rw, y, false);
                var line = $"Duplicate: {C.DupeCoins} coins";
                float lw2 = 16 + 4 + W(line, CoinsLine), lx = cx - lw2 / 2, lh = Math.Max(16, LH(CoinsLine));
                Contain(s, Coin(0), lx, y + (lh - 16) / 2, 16, 16);
                s.Text(line, lx + 20, y + (lh - LH(CoinsLine)) / 2, CoinsLine);
                y += lh;
            }
            return Math.Max(leftH, y);
        }

        float InsideRow(UiSvg s, string left, string right, float rx, float rw, float y)
        {
            // (alignItems: baseline)
            float ba = UiSvg.Baseline(Inside, 0), bb = UiSvg.Baseline(HaveT, 0), b = Math.Max(ba, bb);
            s.Text(left, rx, y + b - ba, Inside);
            s.Text(right, rx + rw - W(right, HaveT), y + b - bb, HaveT);
            float h = Math.Max(b - ba + LH(Inside), b - bb + LH(HaveT));
            return y + h + 8;
        }

        float Mons(UiSvg s, List<SquadCreature> pool, float rx, float rw, float y, bool earned)
        {
            float mw = rw * 0.114f;
            int per = Math.Max(1, (int)Math.Floor((rw + 6) / (mw + 6)));
            for (int i = 0; i < pool.Count; i++)
            {
                var c = pool[i];
                float mx = rx + (i % per) * (mw + 6), my = y + (i / per) * (mw + 6);
                bool o = Prof.Owns(_profile, c.Id);
                string bg = earned ? (o ? "#ffffff" : "#f8f1e7") : (o ? "#f8f1e7" : "#ffffff");
                string bc = earned ? (o ? "#26a94e" : "#efe2cf") : (o ? "#efe2cf" : RAR_ROW[ShopData.DropRar(c)].ink);
                s.Box(mx, my, mw, mw, new BoxStyle { Radius = 14, Background = bg });
                var clip = s.NewId("mc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(mx + 2, my + 2, mw - 4, mw - 4, new[] { 12f, 12, 12, 12 })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                float iw = (mw - 4) * 0.86f;
                CreaturePic(s, c.Key, mx + mw / 2 - iw / 2, my + mw / 2 - iw / 2, iw, earned ? (o ? 1 : 0.45f) : (o ? 0.5f : 1));
                if (!o)
                {
                    string cp = $"{Prof.JsStr(ShopData.CopiesHad(_profile, c.Id))}/{Prof.JsStr(ShopData.NeedOf(c))}";
                    float bw = W(cp, MonNew) + 8, bh = LH(MonNew);
                    s.Box(mx + 2 + 3, my + mw - 2 - 3 - bh, bw, bh, new BoxStyle { Radius = 5, Background = "#e01e4a" });
                    s.Text(cp, mx + 2 + 3 + 4, my + mw - 2 - 3 - bh, MonNew);
                }
                s.Close();
                s.Box(mx, my, mw, mw, new BoxStyle { Radius = 14, BorderWidth = 2, BorderColor = bc });
            }
            int rows = (pool.Count + per - 1) / per;
            return y + (rows > 0 ? rows * mw + (rows - 1) * 6 : 0) + 8;
        }

        /// <summary>A creature's still (the Stack cut-out, Roster.Frame) "contain"ed in a square `size` at (x, y).</summary>
        public static void CreaturePicPublic(UiSvg s, string key, float x, float y, float size, float opacity = 1) => CreaturePic(s, key, x, y, size, opacity);

        internal static void CreaturePic(UiSvg s, string key, float x, float y, float size, float opacity = 1)
        {
            float ar = Roster.Ar(key);
            if (ar <= 0) return;
            var (fx, fy, fw, fh) = Roster.Frame(ar);
            s.Image("Stack/art/" + key, x + fx * size, y + fy * size, fw * size, fh * size, "none", opacity);
        }

        float EarnedRight(UiSvg s, ChestInfo C, float rx, float rw, float y)
        {
            var e = C.Earned;
            float cx = rx + rw / 2;
            var nt = T(Heavy, 12.5f, "#8a3a0e", 0, 17);
            string note = e.Opened ? $"Opened: {e.Reward.Name} is in your squad." : "Not sold in the shop. Unlock every other pal of this group and it's yours, once, free.";
            var nf = new TextFlow(note, nt, 0.5f);
            float nh = nf.Measure(rw).h;
            nf.Draw(s, rx, y, rw);
            y += nh + 8;
            if (e.Reward != null)
            {
                var lab = T(Black, 10, "#e0601c", 1); var nm = T(Kit.Display, 20, "#5b3418", 0, 22); var sub = T(Heavy, 11, "#9a7a5a");
                float bh = 72 + 20;
                s.Box(rx, y, rw, bh, new BoxStyle { Radius = 18, Background = "#fff3e0", BorderWidth = 2, BorderColor = "#f2cf9e" });
                s.Box(rx + 12, y + 10, 72, 72, new BoxStyle { Radius = 16, Background = "#ffffff" });
                CreaturePic(s, e.Reward.Key, rx + 12 + 72 * 0.07f, y + 10 + 72 * 0.07f, 72 * 0.86f);
                float th = LH(lab) + 2 + LH(nm) + 2 + LH(sub), ty = y + (bh - th) / 2, tx = rx + 12 + 72 + 12;
                s.Text("INSIDE", tx, ty, lab); ty += LH(lab) + 2;
                s.Text(e.Reward.Name, tx, ty, nm); ty += LH(nm) + 2;
                s.Text("Rainbow pal · joins whole, no copies", tx, ty, sub);
                y += bh + 8;
            }
            y = InsideRow(s, "The rest of the group", $"{e.Have} / {e.Need} unlocked", rx, rw, y);
            return Mons(s, C.Pool, rx, rw, y, true) - 8;
        }

        /// <summary>ShopChests.js Candy: the rim (its lip under it), the white border, the gradient (0, .55, 1), the shine.</summary>
        internal static void CandyFace(UiSvg s, float x, float y, float w, float faceH, string rim, string[] colors, float lip, float radius)
        {
            s.Box(x, y, w, faceH + 4 + lip, new BoxStyle { Radius = radius + 2, Background = rim });
            float ix = x + 2, iy = y + 2, iw = w - 4;
            s.Box(ix, iy, iw, faceH, new BoxStyle { Radius = radius, Background = "#ffffff" });
            var clip = s.NewId("cf");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(ix + 3, iy + 3, iw - 6, faceH - 6, new[] { radius - 3, radius - 3, radius - 3, radius - 3 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(ix, iy, iw, faceH, new BoxStyle { Gradient = colors, GradientStops = colors.Length == 3 ? new[] { 0f, 0.55f, 1 } : null });
            s.Box(ix + 3 + (iw - 6) * 0.08f, iy + 3 + 2, (iw - 6) * 0.84f, (faceH - 6) * 0.4f, new BoxStyle { Radius = 999, Gradient = new[] { "rgba(255,255,255,0.72)", "rgba(255,255,255,0.05)" } });
            s.Close();
        }
    }
}
