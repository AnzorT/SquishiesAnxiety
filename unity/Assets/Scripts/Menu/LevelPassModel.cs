// The Level Pass (webgame/app/menu.js §4 M.levels), as plain C#: what the page shows for the player (levelData, the
// rows, the selected level's panel, CLAIM / CLAIM ALL, the pending claims, the flying coins of a claim) and where
// every piece of it is, each frame, as a list of draws (CharactersPageKit.cs). No UnityEngine here:
// tools/unity/pages-test draws the same list outside Unity and compares it with the app's screenshots;
// LevelPassPage puts it on screen and talks to the backend.
//
// The page, as menu.js lays it out (pu):
//   header (.mm-pgh, left 16, top 12, 46 tall, a row with gaps of 12): the back orb and the title (a picture), then
//     from the right edge: the coins pill (the coin, the number), the LV pill (LV n, the XP bar 118 wide, into / need
//     XP) and CLAIM ALL (n) when more than one level waits
//   the row of levels (.sq-lvtrack: top 60, 118 tall, the whole width, scrolled sideways): a level every 84 from 44,
//     the rail under them (its gold fill to the player's level and the XP into the next), the "you" marker over the
//     fill's end; each level's button: lit once reached, 1.12x for the player's level, bobbing (sqClaim 1.2s
//     ease-in-out) while its prize waits, ringed with an arrow when selected; its badge (claimed, waiting, locked)
//   the panel (.sq-lvpan: left / right 16, top 184, bottom 12): the selected level's title, a line, its button
//     (CLAIM, Claiming…, CLAIMED, n XP to go), and its rewards' cards (196 wide, centred, gaps of 12)
// A tap picks a level; a second tap on a level waiting claims it (as CLAIM does). Every change redraws the row (new
// elements in the page: nothing slides, and the bobbing starts over). Closing removes the page at once.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Vector;

namespace SquishSquad.Menu
{
    /// <summary>What the Level Pass shows of the player (src/game/player.js gamePlayer: xp, road; the coins).</summary>
    public sealed class LevelPassData
    {
        public int Level = 1;
        public double Into, Need;
        public double Coins;
        public HashSet<int> Got = new HashSet<int>();   // profile.levelGot
        public string Day;                               // the player's day 'YYYY-MM-DD' (the chests' group)
        public string YouKey = "mittens";               // the creature in the marker (the one in use)

        /// <summary>From the profile (src/playerXp.js xpView, roadView; profile.levelGot). config/levels isn't read
        /// (the defaults: 100 XP a level, the default road), as HudValues.</summary>
        public static LevelPassData FromProfile(IDictionary<string, object> p, string day, string youKey)
        {
            var d = new LevelPassData { Day = day, YouKey = youKey ?? "mittens" };
            if (p == null) return d;
            var (lv, into, need) = HudValues.PlayerLevel(HudValues.PxpOf(p));
            d.Level = lv; d.Into = into; d.Need = need;
            if (p.TryGetValue("coins", out var c)) d.Coins = c is double x ? x : c is long l ? l : 0;
            if (p.TryGetValue("levelGot", out var g) && g is IDictionary<string, object> gm)
                foreach (var kv in gm)
                    if (kv.Value is bool b && b && int.TryParse(kv.Key, NumberStyles.Integer, CultureInfo.InvariantCulture, out int L)) d.Got.Add(L);
            return d;
        }
    }

    public sealed class LevelPassModel
    {
        public enum HitKind { None, Back, ClaimAll, Level, Claim }

        public readonly LevelPassLayout L;
        public readonly PageGeom G;
        public LevelPassData Data { get; private set; }
        public readonly DragScroll Track = new DragScroll();
        public int Sel { get; private set; }
        public readonly double OpenedAt;
        /// <summary>When the row was last drawn anew (its levels' bobbing starts there).</summary>
        public double RedrawAt;
        /// <summary>A claim to send to the app: the levels (one, or every waiting one for CLAIM ALL).</summary>
        public Action<int[], bool> OnClaim;

        const double COL = 84;
        static double CxOf(int L) => 44 + (L - 1) * COL;
        readonly Dictionary<int, int> _pend = new Dictionary<int, int>();   // 1: waiting for the app, 2: done
        readonly List<Fly> _fly = new List<Fly>();
        string _toast; double _toastAt = -1;
        readonly Random _rnd = new Random(7);

        sealed class Fly { public double At, Ax, Ay, Bx, By; public bool Gem; }

        public sealed class RowInfo
        {
            public int L;
            public LevelPassLayout.Prize R;     // null: no prize
            public string[] Unlocks;
            public bool Reached, Got, Claimable;
        }
        List<RowInfo> _rows;

        public LevelPassModel(LevelPassLayout layout, double screenW, double screenH, LevelPassData data, double now)
        {
            L = layout;
            G = new PageGeom(layout.reference, screenW, screenH);
            OpenedAt = RedrawAt = now;
            SetData(data, now, true);
            var first = _rows.Find(r => r.Claimable);
            Sel = first != null ? first.L : Math.Min(_rows.Count, Data.Level + 1);
            Track.Max = ScrollWidth - Math.Floor(G.PgW + 0.5);
            Track.Value = Math.Max(0, CxOf(Sel) - Math.Floor(G.PgW + 0.5) / 2); Track.Clamp();
        }

        public double ScrollWidth => CxOf(_rows.Count) + 44;
        public IReadOnlyList<RowInfo> Rows => _rows;

        /// <summary>New player data (the profile changed): the rows again, the levels now claimed no longer pending.</summary>
        public void SetData(LevelPassData data, double now, bool first = false)
        {
            Data = data;
            var road = L.road;
            int n = Math.Max(road.Length, 30);
            _rows = new List<RowInfo>(n);
            for (int lv = 1; lv <= n; lv++)
            {
                var r = lv <= road.Length ? road[lv - 1] : null;
                var row = Array.Find(L.rows, x => x.L == lv);
                bool reached = data.Level >= lv;
                _rows.Add(new RowInfo { L = lv, R = r, Unlocks = row?.unlocks ?? new string[0], Reached = reached, Got = r != null && reached && data.Got.Contains(lv), Claimable = r != null && reached && !data.Got.Contains(lv) });
            }
            if (first) return;
            foreach (var lv in new List<int>(_pend.Keys)) if (lv <= _rows.Count && _rows[lv - 1].Got) _pend.Remove(lv);
            RedrawAt = now;
        }

        int NClaim() { int c = 0; foreach (var r in _rows) if (r.Claimable && !_pend.ContainsKey(r.L)) c++; return c; }

        // ---- the day's chest group (functions/squad.js prizeGroup -> lineup(day)[0]) ---------------------------------
        public static string LineupFirst(LevelPassLayout l, string day)
        {
            // dayNumber: the day's number from 'YYYY-MM-DD' (UTC midnight / 864e5)
            double d = 0;
            if (DateTime.TryParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var dt))
                d = Math.Floor((dt - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 864e5);
            var keys = new List<string>();
            foreach (var g in l.groups) keys.Add(g.key);   // (every group but the season's, in GROUPS order)
            double seed = ((d % 233280) * 9301 + 49297) % 233280;
            double Rnd() { seed = (seed * 9301 + 49297) % 233280; return seed / 233280; }
            for (int i = keys.Count - 1; i > 0; i--)
            {
                int j = (int)Math.Floor(Rnd() * (i + 1));
                (keys[i], keys[j]) = (keys[j], keys[i]);
            }
            foreach (var k in keys) { var g = Array.Find(l.groups, x => x.key == k); if (g != null && g.@out) return k; }
            return keys.Count > 0 ? keys[0] : "snack";
        }

        static string Shown(string t) => t == "set" ? "legendary" : t;   // (a Rainbow one comes as a Legendary)

        string PrizeKey(LevelPassLayout.Prize r) =>
            r.k == "chest" ? $"chest-{LineupFirst(L, Data.Day)}-{Shown(r.t)}" : r.k + "-" + ((int)r.n).ToString(CultureInfo.InvariantCulture);

        // ---- taps ------------------------------------------------------------------------------------------------------
        public HitKind HitTest(double xPx, double yPx, out int level)
        {
            level = 0;
            double x = xPx / G.Pu, y = yPx / G.Pu;
            if (PageGeom.In(Arr(L.back), x, y)) return HitKind.Back;
            var (allX, _, _, _) = HeaderXs();
            if (NClaim() > 1 && allX >= 0 && x >= allX && x < allX + AllWidth() && y >= 20 && y < 50) return HitKind.ClaimAll;
            if (y >= 60 && y < 178)
            {
                double cx = x + Track.Value;
                for (int lv = 1; lv <= _rows.Count; lv++)
                    if (Math.Abs(cx - CxOf(lv)) <= 23 && y >= 101 && y < 147) { level = lv; return HitKind.Level; }
                return HitKind.None;
            }
            var a = Arr(L.measured.act);
            var row = _rows[Sel - 1];
            if (row.R != null && row.Claimable && !_pend.ContainsKey(Sel) && PageGeom.In(a, x, y)) { level = Sel; return HitKind.Claim; }
            return HitKind.None;
        }

        static double[] Arr(float[] f) => Array.ConvertAll(f, v => (double)v);

        /// <summary>A tap on a level: picks it; a second tap on one waiting claims it.</summary>
        public void TapLevel(int lv, double now)
        {
            if (lv == Sel) { Claim(lv, now); return; }
            Sel = lv; RedrawAt = now;
        }

        /// <summary>CLAIM (online: OnClaim asks the server, Answer comes back; offline the app's own fake: done at once).</summary>
        public void Claim(int lv, double now)
        {
            var row = lv >= 1 && lv <= _rows.Count ? _rows[lv - 1] : null;
            if (row == null || !row.Claimable || _pend.ContainsKey(lv)) return;
            _pend[lv] = 1; RedrawAt = now;
            if (OnClaim != null) OnClaim(new[] { lv }, false);
            else { _pend[lv] = 2; Burst(lv, now); }
        }

        public void ClaimAll(double now)
        {
            var ls = new List<int>();
            foreach (var r in _rows) if (r.Claimable && !_pend.ContainsKey(r.L)) ls.Add(r.L);
            if (ls.Count == 0) return;
            foreach (var lv in ls) _pend[lv] = 1;
            RedrawAt = now;
            if (OnClaim != null) OnClaim(ls.ToArray(), true);
            else foreach (var lv in ls) { _pend[lv] = 2; Burst(lv, now); }
        }

        /// <summary>The app's answer to a claim ('claimed'): ok -> done (and the coins fly), else the claim undone and a
        /// note. `chest`: the app opens its level road for a chest (not in Unity yet): undone, no note here.</summary>
        public void Answer(bool ok, string error, double now)
        {
            var ls = new List<int>();
            foreach (var kv in _pend) if (kv.Value == 1) ls.Add(kv.Key);
            if (ok) foreach (var lv in ls) { _pend[lv] = 2; Burst(lv, now); }
            else
            {
                foreach (var lv in ls) _pend.Remove(lv);
                if (error != null) Toast(error == "claimed" ? "Already claimed" : error == "need_level" ? "Reach that level first" : "Something went wrong. Try again!", now);
            }
            RedrawAt = now;
        }

        public void Toast(string text, double now) { _toast = text; _toastAt = now; }

        // the coins (or gems) flying from the level to the coins pill: 9 of them, each 55 ms after the one before
        void Burst(int lv, double now)
        {
            var row = _rows[lv - 1];
            if (row.R == null || row.R.k == "chest") return;
            double ax, ay;
            if (Sel == lv) { var it = CardBoxes(); ax = it.Count > 0 ? it[0].x + it[0].w / 2 : 0; ay = 197 + 12 + 43; }   // the first card's picture (.sq-it .ar: 86 tall, 12 down)
            else { ax = CxOf(lv) - Track.Value; ay = 60 + 41 + 23; }
            var (_, _, pillX, _) = HeaderXs();
            double bx = pillX - 4 + 14 - 13, by = 21 + 14 - 13;
            for (int i = 0; i < 9; i++)
            {
                double fx = ax - 13 + (_rnd.NextDouble() - 0.5) * 40, fy = ay - 13 + (_rnd.NextDouble() - 0.5) * 30;
                _fly.Add(new Fly { At = now + 30 + i * 55, Ax = fx, Ay = fy, Bx = bx, By = by, Gem = row.R.k == "gems" });
            }
        }

        // ---- the header's row ------------------------------------------------------------------------------------------
        static readonly TextStyle LvText = PageText.White(15), PillText = PageText.White(13.5f), AllText = PageText.OnGold(12.5f), TogoText = PageText.White(14), ToastText = PageText.OnGold(13);

        string LvLabel => "LV " + Data.Level.ToString(CultureInfo.InvariantCulture);
        string XpLabel => Data.Need > 0 ? PageText.Fmt(Data.Into) + " / " + PageText.Fmt(Data.Need) + " XP" : "";
        string AllLabel => "CLAIM ALL (" + NClaim().ToString(CultureInfo.InvariantCulture) + ")";
        double PillWidth() => 28 + PageText.Width(PageText.Fmt(Data.Coins), PillText) + 13;
        double LvxWidth() => 2 + 8 + PageText.Width(LvLabel, LvText) + 9 + 118 + 9 + PageText.Width(XpLabel, PageText.Small) + 14 + 2;
        double AllWidth() => 2 + 13 + PageText.Width(AllLabel, AllText) + 13 + 2;

        /// <summary>The header's right-hand items' left edges (pu): CLAIM ALL (-1: none), the LV pill, the coins pill.</summary>
        public (double all, double lvx, double pill, double right) HeaderXs()
        {
            double right = G.PgW - 16, pill = right - PillWidth(), lvx = pill - 12 - LvxWidth();
            double all = NClaim() > 1 ? lvx - 12 - AllWidth() : -1;
            return (all, lvx, pill, right);
        }

        // ---- the panel's cards -------------------------------------------------------------------------------------------
        List<(string key, double x, double w)> CardBoxes()
        {
            var row = _rows[Sel - 1];
            var keys = new List<string>();
            if (row.R != null) keys.Add(PrizeKey(row.R));
            keys.AddRange(row.Unlocks);
            int n = keys.Count;
            double areaX = 16 + 3 + 16 + 156 + 16, areaW = (G.PgW - 16 - 3 - 16) - areaX;
            double cw = n == 0 ? 0 : Math.Min(196, (areaW - 12 * (n - 1)) / n);
            double total = n * cw + 12 * Math.Max(0, n - 1), x = areaX + (areaW - total) / 2;
            var list = new List<(string, double, double)>();
            foreach (var k in keys) { list.Add((n >= 3 ? k + "-w" + n.ToString(CultureInfo.InvariantCulture) : k, x, cw)); x += cw + 12; }
            return list;
        }

        // ---- drawing ---------------------------------------------------------------------------------------------------
        static readonly Func<double, double> EaseInOut = CssEase.EaseInOut, Ease = CssEase.Ease, FlyCurve = CssEase.Bezier(.5, -0.2, .7, 1);

        /// <summary>When the endless motions (the waiting levels' bob) count from (the tests hold them where the app's
        /// screenshot has them); NaN: from the last redraw, as in the app.</summary>
        public double BobEpoch = double.NaN;

        public PageDraw Draw(double now)
        {
            Track.Tick(now);
            var d = new List<PageDraw>();
            var g = G;
            d.Add(g.Screen("bg", L.bg));
            d.Add(g.At("head", L.head));
            // the header's right-hand row
            var (allX, lvxX, pillX, _) = HeaderXs();
            if (allX >= 0)
            {
                double w = AllWidth();
                g.Slice(d, "all", L.allBox, allX, 20, w, 16, 16);
                string t = AllLabel;
                d.Add(g.Svg("all-text", allX + 15, 20 + 2 + (26 - PageText.Line(AllText)) / 2, PageText.Width(t, AllText), PageText.Line(AllText), (s, ox, oy) => s.Text(t, ox, oy, AllText)));
            }
            {
                double w = LvxWidth();
                g.Slice(d, "lvx", L.lvxBox, lvxX, 18, w, 18, 18);
                string lv = LvLabel, xp = XpLabel;
                double bw = PageText.Width(lv, LvText), barX = lvxX + 10 + bw + 9;
                d.Add(g.Svg("lv-text", lvxX + 10, 18 + 2 + (30 - PageText.Line(LvText)) / 2, bw, PageText.Line(LvText), (s, ox, oy) => s.Text(lv, ox, oy, LvText)));
                d.Add(g.Pic("bar", L.bar, barX, 29));
                double f = Data.Need > 0 ? Math.Max(0, Math.Min(1, Data.Into / Data.Need)) : 0;
                double fw = Math.Round(f * 1000) / 10 * 1.18;      // style width: (f * 100).toFixed(1) + '%' of 118
                if (fw > 0) g.Slice(d, "bar-fill", L.barFill, barX, 29, fw, Math.Min(6, fw / 2), Math.Min(6, fw / 2));
                if (xp.Length > 0) d.Add(g.Svg("xp-text", barX + 118 + 9, 18 + 2 + (30 - PageText.Line(PageText.Small)) / 2, PageText.Width(xp, PageText.Small), PageText.Line(PageText.Small), (s, ox, oy) => s.Text(xp, ox, oy, PageText.Small)));
            }
            {
                double w = PillWidth();
                g.Slice(d, "pill", L.pillBox, pillX, 20, w, 16, 16);
                d.Add(g.Pic("coin", L.coin, pillX - 4, 21));
                string c = PageText.Fmt(Data.Coins);
                d.Add(g.Svg("coins-text", pillX + 28, 20 + 2 + (26 - PageText.Line(PillText)) / 2, PageText.Width(c, PillText), PageText.Line(PillText), (s, ox, oy) => s.Text(c, ox, oy, PillText)));
            }

            // the row of levels (clipped to the track's box, scrolled)
            int from = d.Count;
            double sx = -Track.Value, top = 60;
            int N = _rows.Count;
            double x0 = CxOf(1);
            double fill = Math.Min(CxOf(N), CxOf(Data.Level) + (Data.Need > 0 ? Math.Max(0, Math.Min(1, Data.Into / Data.Need)) : 0) * COL);
            g.Slice(d, "rail", L.rail, sx + x0, top + 58, CxOf(N) - x0, 8, 8);
            double fillW = Math.Round((fill - x0) * 10) / 10;
            if (fillW > 0) g.Slice(d, "rail-fill", L.railFill, sx + x0, top + 58, fillW, Math.Min(6, fillW / 2), Math.Min(6, fillW / 2));
            double bob = now - (double.IsNaN(BobEpoch) ? RedrawAt : BobEpoch);
            double viewL = Track.Value - 60, viewR = Track.Value + G.PgW + 60;
            foreach (var row in _rows)
            {
                double cx = CxOf(row.L);
                if (cx < viewL || cx > viewR) continue;
                _pend.TryGetValue(row.L, out int p);
                bool cl = row.Claimable && p == 0, got = row.Got || p == 2 || (row.Reached && row.R == null), sel = Sel == row.L, cur = row.L == Data.Level;
                string disc = sel ? (row.Reached ? "sel" : "offsel") : cl ? "cl" : row.Reached ? "on" : "off";
                string badge = cl ? "ex" : got ? "ok" : row.Reached ? null : "lkb";
                Affine css = Affine.Identity;
                if (cl)
                {
                    // sqClaim 1.2s ease-in-out infinite: translateY 0 -> -4px -> 0 (the animation wins over .cur's scale)
                    double ph = (bob % 1200 + 1200) % 1200 / 1200;
                    double y = PageMotion.Keyframes(ph, new[] { (0.0, 0.0), (0.5, -4.0), (1.0, 0.0) }, EaseInOut);
                    css = Affine.Translate(0, y);
                }
                else if (cur) css = PageGeom.About(23, 23, Affine.ScaleBy(1.12, 1.12));
                double bx = sx + cx - 23, by = top + 41;
                var dp = Array.Find(L.discs, q => q.id == disc);
                if (dp != null) d.Add(g.Pic("disc" + row.L, dp, bx, by, 1, css));
                var np = Array.Find(L.nums, q => q.L == row.L && q.on == row.Reached);
                if (np != null) d.Add(g.Pic("num" + row.L, np, bx, by, 1, css * Affine.Translate((np.box[0] - np.button[0]), (np.box[1] - np.button[1]))));
                if (badge != null)
                {
                    var b = Array.Find(L.badges, q => q.id == badge);
                    if (b != null) d.Add(g.Pic("badge" + row.L, b, bx, by, 1, css * Affine.Translate(b.box[0] - b.button[0], b.box[1] - b.button[1])));
                }
                if (sel && L.arrow != null) d.Add(g.Pic("arrow", L.arrow, bx, by, 1, css));
            }
            // the "you" marker, over the levels
            d.Add(g.Pic("you", L.you, sx + fill - 17, top));
            var youArt = new PagePic { res = "you/" + Data.YouKey, at = L.you.at, size = L.you.size, box = L.you.box };
            if (YouArt != null) { var a = YouArt(Data.YouKey); if (a != null) d.Add(g.Pic("you-art", a, sx + fill - 17, top)); }
            d.Add(g.Pic("you-ptr", L.youPtr, sx + fill - 6, top + 35));
            g.ClipTo(d, from, 0, 60, G.PgW, 118);

            // the panel
            g.Slice(d, "panel", L.panel, 16, 184, G.PgW - 32, 30, 30);
            var sr = _rows[Sel - 1];
            _pend.TryGetValue(Sel, out int sp);
            var title = Array.Find(L.titles, q => q.L == Sel && q.reached == sr.Reached);
            if (title != null) d.Add(g.At("title", title));
            int nItems = (sr.R != null ? 1 : 0) + sr.Unlocks.Length;
            string subText = !sr.Reached ? "Reach it to get " + (nItems > 1 ? "these" : "this") : sr.L == Data.Level ? "Your level" : "Reached";
            var sub = Array.Find(L.subs, q => q.text == subText);
            if (sub != null) d.Add(g.At("sub", sub));
            string act = sr.R != null && sr.Claimable && sp == 0 ? "claim" : sp == 1 ? "claiming" : sr.Reached ? "claimed" : "togo";
            var ap = Array.Find(L.acts, q => q.id == act);
            if (ap != null) d.Add(g.At("act", ap));
            if (act == "togo")
            {
                string t = PageText.Fmt(XpTo(Sel)) + " XP to go";
                double tw = PageText.Width(t, TogoText), cw = 17 + 6 + tw, ax = ap.box[0] + 2 + (146 - cw) / 2, ay = ap.box[1] + 2 + (36 - 17) / 2.0;
                d.Add(g.Pic("lock", L.lock16, ax, ay));
                d.Add(g.Svg("togo-text", ax + 23, ap.box[1] + 2 + (36 - PageText.Line(TogoText)) / 2, tw, PageText.Line(TogoText), (s, ox, oy) => s.Text(t, ox, oy, TogoText)));
            }
            foreach (var (key, x, w) in CardBoxes())
            {
                var c = Array.Find(L.cards, q => q.key == key);
                if (c == null) continue;
                d.Add(g.Pic("card-" + key, c, x, 197));
            }

            // the flying coins (.sq-fly: transform .75s cubic-bezier(.5,-.2,.7,1), opacity .2s ease after .62s; gone at 1.3 s)
            _fly.RemoveAll(f => now > f.At + 1270);
            foreach (var f in _fly)
            {
                double t = now - f.At;
                double m = t <= 0 ? 0 : FlyCurve(Math.Min(1, t / 750));
                double s = 1 + (0.7 - 1) * m, op = t <= 620 ? 1 : 1 - Ease(Math.Min(1, (t - 620) / 200));
                var css = PageGeom.About(13, 13, Affine.Translate((f.Bx - f.Ax) * m, (f.By - f.Ay) * m) * Affine.ScaleBy(s, s));
                d.Add(g.Pic("fly", f.Gem ? L.flyGem : L.flyCoin, f.Ax, f.Ay, op, css));
            }
            // a note (.sq-toast: mmToast 2.4s ease)
            if (_toast != null && now - _toastAt < 2400)
            {
                double p = (now - _toastAt) / 2400;
                double op = PageMotion.Keyframes(p, new[] { (0.0, 0.0), (0.1, 1.0), (0.85, 1.0), (1.0, 0.0) }, Ease);
                double dy = PageMotion.Keyframes(p, new[] { (0.0, -8.0), (0.1, 0.0), (1.0, 0.0) }, Ease);
                double tw = PageText.Width(_toast, ToastText), w = tw + 40, x = G.PgW / 2 - w / 2, y = 393 - 20 - 30;
                var t = new List<PageDraw>();
                g.Slice(t, "toast", L.toast, x, y, w, 16, 16);
                string text = _toast;
                t.Add(g.Svg("toast-text", x + 20, y + 2 + (26 - PageText.Line(ToastText)) / 2, tw, PageText.Line(ToastText), (s, ox, oy) => s.Text(text, ox, oy, ToastText)));
                var move = Affine.Translate(0, dy * G.Pu);   // (the slide moves the drawn text too: it's drawn once)
                for (int i = 0; i < t.Count; i++) { var r = t[i]; r.M = move * r.M; t[i] = r; }
                foreach (var q in t) { var r = q; r.Opacity *= op; d.Add(r); }
            }
            else _toast = null;
            return PageMotion.Layer(g, d, now - OpenedAt);
        }

        /// <summary>The marker's creature picture for a key (null: none). LevelPassPage / the test give it.</summary>
        public Func<string, PagePic> YouArt;

        // XP still to earn before level lv (xpTo)
        double XpTo(int lv)
        {
            if (Data.Level >= lv) return 0;
            double n = Math.Max(0, Data.Need - Data.Into), per = HudValues.XpPerLevel;
            for (int j = Data.Level + 1; j < lv; j++) n += per * (j + 1);
            return n;
        }
    }
}
