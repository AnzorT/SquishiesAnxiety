// The Characters page (webgame/app/menu.js §5 M.characters) and its loading screen (gatherSquad, "Gathering your
// squad"), as plain C#: what the page shows for the player (the creatures owned, the one in use, the one looked at),
// where every piece is and how it moves, as a list of draws (CharactersPageKit.cs). No UnityEngine here:
// tools/unity/pages-test draws the same list outside Unity and compares it with the app's screenshots;
// CharactersPage puts it on screen and saves the choice.
//
// The page (pu): the rays behind the platform turning (60 s a turn, sqSpin); the platform at (326, 190): its gold side,
// its plate turning (12 s a turn) and its 16 lights riding round its rim (bulbRun: 49 keyframes, linear); the creature
// over it at (351, 68) 150 x 150 (its still picture: the app's live rig isn't in Unity yet), popping in when another is
// picked (sqPop .55s cubic-bezier(.2,1.4,.4,1)), greyed (.sil) when not owned; its tags and name plate in a row at
// 247 (gaps of 12, centred between 146 and 146 from the edges); CHOOSE (owned, not in use) or "Find it in chests"
// (not owned) at (565, 118); the row of cards at 284 to the bottom (group by group, a group's label sticking to the
// row's left edge while its cards pass under it, a line between groups), dragged sideways (dragRow), the arrows at its
// ends jumping a group (380 ms ease-in-out). A tap on a card picks it; CHOOSE puts it in front of the house (the app's
// toast at the bottom right for 2.4 s).
// The loading screen over it while it opens: five of the player's creatures dealt from the deck (one every 200 ms
// from 160 ms, each turned over 300 ms after it lands), a bar filling, a tip changing every 2.8 s; once the page is
// ready (Unity: at once) and 1.9 s have passed, the cards fly up and fade, then the screen fades.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Vector;

namespace SquishSquad.Menu
{
    public sealed class CharactersModel
    {
        public enum HitKind { None, Back, Prev, Next, Act, Card }

        public readonly CharactersLayout L;
        public readonly PageGeom G;
        public readonly DragScroll Row = new DragScroll();
        public readonly double OpenedAt;
        readonly HashSet<string> _owned;
        public string InUse { get; private set; }
        public string Pick { get; private set; }
        /// <summary>CHOOSE: the creature to put in front of the house.</summary>
        public Action<string> OnChoose;
        /// <summary>"Find it in chests".</summary>
        public Action OnShop;
        /// <summary>When the endless motions count from (the tests hold them where the app's screenshot has them).</summary>
        public double EndlessEpoch;
        double _popAt = double.NegativeInfinity;
        string _toast; double _toastAt = -1;
        int _tip;
        readonly List<CharactersLayout.Creature> _all = new List<CharactersLayout.Creature>();
        readonly Dictionary<string, CharactersLayout.Creature> _byKey = new Dictionary<string, CharactersLayout.Creature>();
        readonly List<(string key, double x, double y, double w, double h)> _cards = new List<(string, double, double, double, double)>();
        string _pressed; double _pressAt, _releaseAt = double.NegativeInfinity; string _released;

        public CharactersModel(CharactersLayout layout, double screenW, double screenH, IEnumerable<string> owned, string inUse, double now, int tip = 0)
        {
            L = layout;
            G = new PageGeom(layout.reference, screenW, screenH);
            OpenedAt = EndlessEpoch = now;
            _owned = new HashSet<string>(owned ?? new string[0]);
            foreach (var c in layout.roster) { _all.Add(c); _byKey[c.key] = c; }
            InUse = inUse != null && _byKey.ContainsKey(inUse) ? inUse : _all.Count > 0 ? _all[0].key : null;
            Pick = InUse;
            for (int gi = 0; gi < layout.groups.Length; gi++)
            {
                var g = layout.groups[gi];
                for (int i = 0; i < g.ids.Length; i++)
                {
                    var c = _all.Find(x => x.id == g.ids[i]);
                    if (c != null) _cards.Add((c.key, g.cards[i * 4], g.cards[i * 4 + 1], g.cards[i * 4 + 2], g.cards[i * 4 + 3]));
                }
            }
            ClientW = Math.Floor(G.PgW + 0.5);
            Row.Max = Math.Max(0, layout.row.scrollWidth - ClientW);
            // the picked card in the middle of the row
            var pc = _cards.Find(c => c.key == Pick);
            // (menu.js measures it on screen, k = the row's width / its clientWidth; Chrome keeps whole page px)
            if (pc.key != null) { Row.Value = Math.Max(0, Math.Floor(pc.x * ClientW / G.PgW - (ClientW - pc.w) / 2 + 0.5)); Row.Clamp(); }
            _tip = Math.Max(0, tip) % Math.Max(1, layout.gs?.tips?.Length ?? 1);
            _deal = DealList();
        }

        public readonly double ClientW;
        public bool Owns(string key) => key != null && _owned.Contains(key);

        /// <summary>The player's creatures changed (the profile): owned and in use.</summary>
        public void SetOwned(IEnumerable<string> owned, string inUse)
        {
            _owned.Clear();
            foreach (var k in owned) _owned.Add(k);
            if (inUse != null && _byKey.ContainsKey(inUse)) InUse = inUse;
        }

        // ---- taps ------------------------------------------------------------------------------------------------------
        public HitKind HitTest(double xPx, double yPx, out string key)
        {
            key = null;
            double x = xPx / G.Pu, y = yPx / G.Pu;
            if (Loading(_lastNow)) return HitKind.None;   // (the loading screen covers the page, its back orb too)
            if (PageGeom.In(Arr(L.back), x, y)) return HitKind.Back;
            if (In(10, 330, 34, 34, x, y)) return HitKind.Prev;
            if (In(G.PgW - 10 - 34, 330, 34, 34, x, y)) return HitKind.Next;
            var act = ActPic();
            if (act != null && PageGeom.In(Arr(act.box), x, y)) return HitKind.Act;
            if (y >= 284)
                foreach (var c in _cards)
                {
                    double cx = c.x - Row.Value, cy = 284 + c.y;
                    if (In(cx, cy, c.w, c.h, x, y)) { key = c.key; return HitKind.Card; }
                }
            return HitKind.None;
        }

        static bool In(double bx, double by, double w, double h, double x, double y) => x >= bx && y >= by && x < bx + w && y < by + h;
        static double[] Arr(float[] f) => Array.ConvertAll(f, v => (double)v);

        public void Press(string key, double now) { _pressed = key; _pressAt = now; }
        public void Release(double now) { if (_pressed != null) { _released = _pressed; _releaseAt = now; } _pressed = null; }

        /// <summary>A card tapped: it's the one looked at (popping in if it's another).</summary>
        public void Choose(string key, double now)
        {
            if (!_byKey.ContainsKey(key)) return;
            bool changed = key != Pick;
            Pick = key;
            if (changed) _popAt = now;
        }

        /// <summary>CHOOSE: the one looked at goes in front of the house.</summary>
        public void Confirm(double now)
        {
            if (!Owns(Pick) || Pick == InUse) return;
            InUse = Pick;
            OnChoose?.Invoke(Pick);
            _toast = _byKey[Pick].name + " is in front of your house!"; _toastAt = now;
        }

        public void Act(double now)
        {
            if (!Owns(Pick)) { OnShop?.Invoke(); return; }
            Confirm(now);
        }

        // the arrows: the previous / next group
        double[] Starts() { var s = new double[L.groups.Length]; for (int i = 0; i < s.Length; i++) s[i] = L.groups[i].box[0] - 44; return s; }
        int GroupAt() { var s = Starts(); double x0 = Row.Value + 8; int i = 0; for (int j = 0; j < s.Length; j++) if (s[j] <= x0) i = j; return i; }
        public bool PrevOff => GroupAt() == 0 && Row.Value < 8;
        public bool NextOff => GroupAt() >= L.groups.Length - 1 || Row.Value >= Row.Max - 4;
        static readonly Func<double, double> EIO = t => t < 0.5 ? 2 * t * t : 1 - Math.Pow(-2 * t + 2, 2) / 2;

        public void Jump(int dir, double now)
        {
            var s = Starts();
            if (dir < 0) dir = Row.Value > s[GroupAt()] + 8 ? 0 : -1;
            int i = Math.Max(0, Math.Min(s.Length - 1, GroupAt() + dir));
            Row.TweenTo(Math.Max(0, Math.Min(Row.Max, s[i])), now, 380, EIO);
        }

        // ---- the loading screen's timeline (gatherSquad) -----------------------------------------------------------------
        const double MIN = 1900;
        readonly List<string> _deal;
        /// <summary>When the loading screen's cards fly off (null: from its own rule: the page ready at once, then the
        /// first frame 1.9 s in with the bar full). The tests give the app's own moment.</summary>
        public double? AwayAt;
        double _lastNow;

        List<string> DealList()
        {
            // (the roster's own order, not the row's)
            var byId = new List<CharactersLayout.Creature>(_all);
            byId.Sort((a, b) => a.id.CompareTo(b.id));
            var own = new List<string>();
            if (InUse != null && Owns(InUse)) own.Add(InUse);
            foreach (var c in byId) if (Owns(c.key) && c.key != InUse) own.Add(c.key);
            if (own.Count == 0) foreach (var c in byId) { own.Add(c.key); if (own.Count == 5) break; }
            return own.Count > 15 ? own.GetRange(0, 15) : own;
        }

        // the bar: p0 eased each frame toward its goal (0.14 of the way once ready; ready at the first frame)
        static double Progress(double t)
        {
            if (t <= 0) return 0;
            int frames = (int)Math.Floor(t / (1000 / 60.0)) + 1;   // (its first step at the first frame)
            double p = 1 - Math.Pow(0.86, frames);
            return 1 - p < 0.005 ? 1 : p;
        }

        double Away()
        {
            if (AwayAt.HasValue) return AwayAt.Value;
            // the first frame at or after MIN once the bar is full (it is long before)
            double fr = 1000 / 60.0;
            double t = Math.Ceiling(MIN / fr) * fr;
            while (Progress(t) < 1) t += fr;
            return t;
        }

        public bool Loading(double now) => now - OpenedAt < Away() + 900;

        // ---- drawing ---------------------------------------------------------------------------------------------------
        static readonly Func<double, double> Ease = CssEase.Ease, EaseIn = CssEase.EaseIn, PopCurve = CssEase.Bezier(.2, 1.4, .4, 1),
            DealCurve = CssEase.Bezier(.2, .9, .3, 1.05);

        public PageDraw Draw(double now)
        {
            _lastNow = now;
            Row.Tick(now);
            var g = G;
            var d = new List<PageDraw>();
            double t = now - OpenedAt, te = now - EndlessEpoch;
            d.Add(g.Screen("bg", L.bg));
            d.Add(g.At("head", L.head));
            // the rays (sqSpin 60 s linear) about their middle
            d.Add(g.Pic("rays", L.rays, 426 - 410, 170 - 410, 1, PageGeom.About(410, 410, Affine.Rotate(360 * Frac(te / 60000)))));
            // the platform
            d.Add(g.At("side", L.side));
            d.Add(g.At("glow", L.glow));
            double deg = 360 * Frac(te / 12000) % 30;
            var stripe = L.stripes[(int)Math.Round(deg / 0.5) % L.stripes.Length];
            d.Add(g.At("stripes", stripe));
            d.Add(g.At("centre", L.centre));
            double rx = L.ring[0], ry = L.ring[1];
            for (int i = 0; i < 16; i++)
            {
                double p = Frac((te + i * 750) / 12000);
                var (x, y, s) = Bulb(p);
                var pic = i % 2 == 1 ? L.bulbW : L.bulb;
                d.Add(g.Pic("bulb" + i, pic, rx + x - 7, ry + y - 7, 1, PageGeom.About(7, 7, Affine.ScaleBy(s, s))));
            }
            // the creature on it
            var st = Array.Find(L.stills, q => q.key == Pick);
            if (st != null)
            {
                double pt = now - _popAt, op = 1;
                Affine css = Affine.Identity;
                if (pt < 550)
                {
                    double k = PopCurve(Math.Max(0, pt) / 550);
                    double sc = .55 + (1 - .55) * k, ty = 20 * (1 - k);
                    css = PageGeom.About(75, 75, Affine.ScaleBy(sc, sc) * Affine.Translate(0, ty));
                    op = k;   // (opacity 0 -> 1 along the same curve, clamped)
                    op = Math.Max(0, Math.Min(1, op));
                }
                d.Add(g.Pic("rig", Owns(Pick) ? st.still : st.sil, L.rig[0], L.rig[1], op, css));
            }
            // its tags and name plate
            var c = _byKey.TryGetValue(Pick ?? "", out var cc) ? cc : null;
            if (c != null)
            {
                var rt = Array.Find(L.rarTags, q => q.rar == Math.Max(0, Math.Min(4, c.rar)));
                var pl = Array.Find(L.plates, q => q.key == c.key);
                var stg = Array.Find(L.setTags, q => q.set == c.set);
                double w1 = rt?.box[2] ?? 0, w2 = pl?.box[2] ?? 0, w3 = stg?.box[2] ?? 0, total = w1 + 12 + w2 + 12 + w3;
                double x = 146 + (G.PgW - 292 - total) / 2;
                if (rt != null) d.Add(g.Pic("rar", rt, x, rt.box[1]));
                if (pl != null) d.Add(g.Pic("plate", pl, x + w1 + 12, pl.box[1]));
                if (stg != null) d.Add(g.Pic("set", stg, x + w1 + 12 + w2 + 12, stg.box[1]));
            }
            var act = ActPic();
            if (act != null) d.Add(g.At("act", act));

            // the row
            int from = d.Count;
            double sx = -Row.Value, top = 284;
            PageDraw? meTag = null;
            for (int gi = 0; gi < L.groups.Length; gi++)
            {
                var gr = L.groups[gi];
                if (gr.box[0] + gr.box[2] + sx < -20 || gr.box[0] + sx > G.PgW + 20) continue;
                if (gi > 0) d.Add(g.Pic("sep" + gi, L.sep, sx + gr.box[0], top + gr.box[1]));
                for (int i = 0; i < gr.ids.Length; i++)
                {
                    double cx = gr.cards[i * 4] + sx, cy = top + gr.cards[i * 4 + 1], cw = gr.cards[i * 4 + 2], ch = gr.cards[i * 4 + 3];
                    if (cx + cw < -20 || cx > G.PgW + 20) continue;
                    var cr = _all.Find(q => q.id == gr.ids[i]);
                    if (cr == null) continue;
                    var set = Array.Find(L.cards, q => q.key == cr.key);
                    if (set == null) continue;
                    // :active scale(.95), transition .15s
                    double ps = PressScale(cr.key, now);
                    var css = ps == 1 ? Affine.Identity : PageGeom.About(cw / 2, ch / 2, Affine.ScaleBy(ps, ps));
                    if (cr.key == Pick && L.pv != null) d.Add(g.Pic("pv", L.pv, cx, cy, 1, css));
                    d.Add(g.Pic("card-" + cr.key, Owns(cr.key) ? set.card : set.locked, cx, cy, 1, css));
                    if (cr.key == InUse && L.me != null) meTag = g.Pic("me", L.me, cx, cy, 1, css);   // (z-index 3: over the labels)
                }
            }
            // the group labels (sticky: at the row's left edge while their group passes, within their group)
            for (int gi = 0; gi < L.groups.Length; gi++)
            {
                var gr = L.groups[gi];
                var lab = gi < L.labels.Length ? L.labels[gi] : null;
                if (lab == null) continue;
                double lw = gr.label[2];
                double lx = Math.Max(gr.label[0], Math.Min(Row.Value + StickyEdge, gr.box[0] + gr.box[2] - lw));
                if (lx + lw + sx < -20 || lx + sx > G.PgW + 20) continue;
                d.Add(g.Pic("label" + gi, lab, lx + sx, top + gr.label[1]));
            }
            if (meTag.HasValue) d.Add(meTag.Value);
            g.ClipTo(d, from, 0, 284, G.PgW, 393 - 284);
            d.Add(g.Pic("prev", L.prev, 10, 330, PrevOff ? 0.4 : 1));
            d.Add(g.Pic("next", L.next, G.PgW - 10 - 34, 330, NextOff ? 0.4 : 1));
            // CHOOSE's toast (.sq-toast.r: at the bottom right, no motion, 2.4 s)
            if (_toast != null && now - _toastAt < 2400)
            {
                var ts = PageText.OnGold(13);
                double tw = PageText.Width(_toast, ts), w = tw + 40, x = G.PgW - 18 - w, y = 393 - 20 - 30;
                g.Slice(d, "toast", L.toast, x, y, w, 16, 16);
                string text = _toast;
                d.Add(g.Svg("toast-text", x + 20, y + 2 + (26 - PageText.Line(ts)) / 2, tw, PageText.Line(ts), (s, ox, oy) => s.Text(text, ox, oy, ts)));
            }
            else _toast = null;
            // the loading screen over it
            if (L.gs != null && t < Away() + 900) d.Add(Loader(t));
            return PageMotion.Layer(g, d, t);
        }

        /// <summary>The row's left edge for a sticky label (pu, from the row's scroll position): measured from the app.</summary>
        public double StickyEdge = 54;
        /// <summary>The loading screen deals from its first frame (requestAnimationFrame after it's made).</summary>
        public double DealDelay = 16;

        double PressScale(string key, double now)
        {
            if (key == _pressed) return 1 - 0.05 * Ease(Math.Min(1, (now - _pressAt) / 150));
            if (key == _released && now - _releaseAt < 150) return 0.95 + 0.05 * Ease((now - _releaseAt) / 150);
            return 1;
        }

        PagePic ActPic() => Pick == null ? null : !Owns(Pick) ? L.shop : Pick != InUse ? L.choose : null;

        static double Frac(double v) => v - Math.Floor(v);

        // bulbRun: 49 points the same distance apart round the plate's rim (an ellipse 100 x 20), linear between them
        static (double at, double x, double y, double s)[] _bulbKf;
        static (double x, double y, double s) Bulb(double p)
        {
            if (_bulbKf == null)
            {
                const int N = 720, K = 48;
                var pts = new (double x, double y)[N + 1];
                var len = new double[N + 1];
                for (int i = 0; i <= N; i++)
                {
                    double a = (double)i / N * 2 * Math.PI;
                    pts[i] = (100 * Math.Cos(a), 20 * Math.Sin(a));
                    if (i > 0) len[i] = len[i - 1] + Math.Sqrt(Math.Pow(pts[i].x - pts[i - 1].x, 2) + Math.Pow(pts[i].y - pts[i - 1].y, 2));
                }
                double Lt = len[N];
                int j = 0;
                _bulbKf = new (double, double, double, double)[K + 1];
                for (int k = 0; k <= K; k++)
                {
                    double s = (double)k / K * Lt;
                    while (j < N - 1 && len[j + 1] < s) j++;
                    double den = len[j + 1] - len[j];
                    double f = (s - len[j]) / (den == 0 ? 1 : den), x = pts[j].x + (pts[j + 1].x - pts[j].x) * f, y = pts[j].y + (pts[j + 1].y - pts[j].y) * f;
                    _bulbKf[k] = (R((double)k / K * 100, 3) / 100, R(x + 100, 1), R(y + 20, 1), R(0.95 + 0.11 * y / 20, 3));
                }
            }
            var kf = _bulbKf;
            for (int i = 1; i < kf.Length; i++)
                if (p <= kf[i].at)
                {
                    double u = (p - kf[i - 1].at) / Math.Max(1e-9, kf[i].at - kf[i - 1].at);
                    return (kf[i - 1].x + (kf[i].x - kf[i - 1].x) * u, kf[i - 1].y + (kf[i].y - kf[i - 1].y) * u, kf[i - 1].s + (kf[i].s - kf[i - 1].s) * u);
                }
            return (kf[0].x, kf[0].y, kf[0].s);
        }

        static double R(double v, int digits) => Math.Round(v, digits, MidpointRounding.AwayFromZero);

        // ---- the loading screen ------------------------------------------------------------------------------------------
        PageDraw Loader(double t)
        {
            var gs = L.gs;
            var g = G;
            var d = new List<PageDraw>();
            double dx = (G.PgW - L.reference.pgW) / 2;   // (what's centred on the page)
            d.Add(g.Screen("gs-bg", gs.bg));
            d.Add(g.Pic("gs-rays", gs.rays, gs.rays.box[0] + dx, gs.rays.box[1], 1, PageGeom.About(gs.rays.box[2] / 2, gs.rays.box[3] / 2, Affine.Rotate(360 * Frac(t / 60000)))));
            d.Add(g.Pic("gs-title", gs.title, gs.title.box[0] + dx, gs.title.box[1]));
            int owned = 0; foreach (var c in _all) if (Owns(c.key)) owned++;
            if (owned >= 1 && owned <= gs.counts.Length) { var cp = gs.counts[owned - 1]; d.Add(g.Pic("gs-count", cp, cp.box[0] + dx, cp.box[1])); }
            // the table: the deck, then the cards
            int n = Math.Min(5, _deal.Count);
            double away = Away();
            t -= DealDelay;   // (the deal starts at the loading screen's first frame)
            int dealtNow = 0;
            for (int i = 0; i < n; i++) if (t >= 160 + i * 200) dealtNow++;
            away -= DealDelay;
            int left = n - dealtNow;
            // the deck: as thick as the cards still in it (deckHolds: back i shows while more than 2 - i are left)
            var deckBox = gs.deck;
            for (int i = 0; i < 3; i++)
            {
                if (!(left > 2 - i)) continue;
                var b = gs.backs[i];
                d.Add(g.Pic("deck" + i, b, deckBox[0] + dx, deckBox[1], 1, Affine.Translate(b.box[0] - deckBox[0], b.box[1] - deckBox[1])));
            }
            for (int i = 0; i < n; i++)
            {
                double dealtAt = 160 + i * 200, upAt = 460 + i * 200;
                if (t < dealtAt) continue;
                double k = (i - (n - 1) / 2.0);
                double fx = Math.Round(k * 122), fy = i % 2 == 1 ? 6 : -2, fr = i % 2 == 1 ? 4 : -4;
                double pm = DealCurve(Math.Min(1, (t - dealtAt) / 450)), po = Ease(Math.Min(1, (t - dealtAt) / 200));
                double tx = fx * pm, ty = fy * pm, rot = fr * pm, op = po;
                if (t >= away)
                {
                    double a = EaseIn(Math.Min(1, (t - away) / 450));
                    ty = fy + (-46) * a; tx = fx; rot = fr;
                    op = 1 - Ease(Math.Min(1, (t - away) / 400));
                }
                // turned over: rotateY 180 -> 0 (.45s ease), drawn as its width (the page's perspective left out)
                double flip = t < upAt ? 180 : 180 * (1 - Ease(Math.Min(1, (t - upAt) / 450)));
                double sxF = Math.Abs(Math.Cos(flip * Math.PI / 180));
                var cw = gs.deck;   // (a card's box before it's dealt: the deck's)
                var css = PageGeom.About(cw[2] / 2, cw[3] / 2, Affine.Translate(tx, ty) * Affine.Rotate(rot) * Affine.ScaleBy(sxF, 1));
                PagePic pic = flip > 90 ? gs.bk : (PagePic)Array.Find(gs.cards, q => q.key == _deal[i]);
                if (pic == null) continue;
                d.Add(g.Pic("gs-card" + i, pic, cw[0] + dx, cw[1], op, css * Affine.Translate(pic.box[0] - cw[0], pic.box[1] - cw[1])));
            }
            t += DealDelay; away += DealDelay;
            // the band and the bar
            g.Slice(d, "gs-band", gs.band, 0, gs.band.box[1], G.PgW, 0, 0);
            d.Add(g.Pic("gs-bar", gs.bar, gs.bar.box[0] + dx, gs.bar.box[1]));
            double p0 = Progress(t);
            double fw = Math.Min(p0 * 440, 434);
            if (fw > 0) g.Slice(d, "gs-fill", gs.fill, gs.fill.box[0] + dx, gs.fill.box[1], fw, Math.Min(8, fw / 2), Math.Min(8, fw / 2));
            d.Add(g.Pic("gs-knob", gs.knob, gs.knob.box[0] + dx + Math.Round(p0 * 1000) / 10 * 4.4, gs.knob.box[1]));
            int pc = (int)Math.Floor(p0 * 100 + 0.5);
            if (pc >= 0 && pc < gs.pcs.Length) { var pp = gs.pcs[pc]; d.Add(g.Pic("gs-pc", pp, pp.box[0] + dx, pp.box[1])); }
            // the tip: another every 2.8 s (out .25s, swapped 260 ms later, back in .25s)
            int tipN = gs.tips.Length;
            if (tipN > 0)
            {
                int cycles = (int)Math.Floor(t / 2800);
                double into = t - cycles * 2800;
                int idx = (_tip + cycles) % tipN;
                double op = 1;
                if (cycles > 0 && into < 260 + 250)
                {
                    if (into < 260) { idx = (idx - 1 + tipN) % tipN; op = 1 - Ease(Math.Min(1, into / 250)); }
                    else op = Ease(Math.Min(1, (into - 260) / 250));
                }
                var tp = gs.tips[idx];
                d.Add(g.Pic("gs-tip", tp, tp.box[0] + dx, tp.box[1], op));
            }
            // the screen fades out 420 ms after the cards go (.45s ease)
            double o = t < away + 420 ? 1 : 1 - Ease(Math.Min(1, (t - away - 420) / 450));
            return new PageDraw { Key = "loader", Layer = d, W = (int)Math.Ceiling(G.W), H = (int)Math.Ceiling(G.H), M = Affine.Identity, U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = o };
        }
    }
}
