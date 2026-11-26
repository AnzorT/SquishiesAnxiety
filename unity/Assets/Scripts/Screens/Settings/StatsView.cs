// src/screens/StatsScreen.js, landscape (REDESIGN_V7 step 3), as pure C#: the header (back orb, "Your Stats"), on the
// left the favourite creature (the longest squished) and the three most squished with their bars, on the right the
// totals as eight wood tiles. Everything from the profile (stats, totalEarned, boxOpens, maxMult), the catalog and the
// achievements (AchievementList). In the design's 393-tall units (royal Stage). Opened from Settings' "Stats".
// The creatures are their stills (Roster.Picture: their border-look pictures); the app's thumbnails breathe (CreatureThumbnail 'idle'), not ported.
// Custom creatures (`custom:` ids in playTime) aren't shown: the Unity version has no custom creatures yet.
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;

namespace SquishSquad.Screens
{
    public sealed class StatsView : IScreenView
    {
        public readonly float ScreenW, ScreenH, K, SW, SH = 393;
        public Action OnBack;
        readonly List<(Creature c, double ms)> _ranked;
        readonly List<(string label, string value)> _tiles;
        readonly double _totalMs;

        public StatsView(IList<Creature> creatures, IDictionary<string, object> profile, float screenW, float screenH, Ticker ticker = null)
        {
            ScreenW = screenW; ScreenH = screenH; K = StageK(screenW, screenH); SW = Math.Max(screenW, screenH) / K;
            profile ??= new Dictionary<string, object>();
            creatures ??= Roster.Counted(profile);
            var stats = Prof.Map(Prof.Get(profile, "stats")) ?? new Dictionary<string, object>();
            var pt = Prof.Map(Prof.Get(stats, "playTime")) ?? new Dictionary<string, object>();
            _ranked = pt.Where(kv => Prof.Num(kv.Value) > 0 && !kv.Key.StartsWith("custom:"))
                .Select(kv => (c: creatures.FirstOrDefault(c => c.Id == kv.Key), ms: Prof.Num(kv.Value)))
                .Where(x => x.c != null).OrderByDescending(x => x.ms).ToList();
            _totalMs = pt.Values.Sum(v => Math.Max(0, Prof.Num(v)));
            var roster = creatures.Where(c => c.Id.All(char.IsDigit)).ToList();
            var ownedIds = Prof.Owned(profile);
            int owned = roster.Count(c => ownedIds.Contains(c.Id));
            int rosterSize = roster.Count > 0 ? roster.Count : creatures.Count;
            var ach = AchievementList.Compute(creatures, profile, 0);
            double maxMult = Prof.Num(Prof.Get(profile, "maxMult"));
            _tiles = new List<(string, string)>
            {
                ("SQUISHES", Prof.Fmt(Prof.Num(Prof.Get(stats, "presses")))),
                ("LONGEST HOLD", Prof.Fixed1(Prof.Num(Prof.Get(stats, "longestHoldMs")) / 1000) + "s"),
                ("TIME SQUISHING", FormatDuration(_totalMs)),
                ("COINS EARNED", Prof.Fmt(Prof.Num(Prof.Get(profile, "totalEarned")))),
                ("CREATURES", $"{owned}/{rosterSize}"),
                ("ACHIEVEMENTS", $"{ach.Count(a => a.Done)}/{ach.Count}"),
                ("BOXES OPENED", Prof.Fmt(Prof.Num(Prof.Get(profile, "boxOpens")))),
                ("BIGGEST BOOST", maxMult > 0 ? "×" + Prof.JsStr(maxMult) : "—"),
            };
        }

        /// <summary>754000 → "12m 34s"; 4500000 → "1h 15m"; 8000 → "8s".</summary>
        public static string FormatDuration(double ms)
        {
            long s = (long)Math.Floor(ms / 1000);
            if (s < 60) return $"{s}s";
            long m = s / 60;
            if (m < 60) return $"{m}m {s % 60}s";
            return $"{m / 60}h {m % 60}m";
        }

        // ---- the pointer ---------------------------------------------------------------------------------------------
        bool _backDown;
        bool OnOrb(float sx, float sy) { float x = sx / K, y = sy / K; return x >= 16 - 8 && x < 56 + 8 && y >= 15 - 8 && y < 55 + 8; }
        public void Down(float x, float y) { _backDown = OnOrb(x, y); }
        public void Move(float x, float y) { if (_backDown && !OnOrb(x, y)) _backDown = false; }
        public void Up(float x, float y) { if (_backDown && OnOrb(x, y)) OnBack?.Invoke(); _backDown = false; }

        // ---- the pieces --------------------------------------------------------------------------------------------------
        static readonly TextStyle Kicker = T(Black, 10, "#ffe27a", 1.4f);
        static readonly TextStyle Sub = T(Body, 11.5f, CREAM);
        static readonly TextStyle RankName = T(Kit.Display, 13.5f, "#ffffff");
        static readonly TextStyle RankTime = T(Heavy, 11, "#ffe9a8");
        static readonly TextStyle TileLabel = T(Black, 9.5f, CREAM, 1);

        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", PageBg(SW, SH), SW, SH, 0, 0, 1, null, 0));
            Header(list, "Your Stats", null, _backDown);
            Left(list);
            Grid(list);
            return Staged(list, K);
        }

        /// <summary>royal/parts.js PageHeader: the back orb, the gold title, a note.</summary>
        public static void Header(List<ScreenPiece> list, string title, string note, bool backDown)
        {
            // (held: the orb shrinks to 92 % about its middle, as the menu's Level crest does)
            list.Add(Piece("orb-back", Xml("orb-back"), 40, 40, 16, 15, 1, backDown ? About(40, 40, Affine.ScaleBy(0.92, 0.92)) : (Affine?)null));
            var (lw, lh) = LetteringSize(title, 30);
            var s = new UiSvg(lw, lh);
            Lettering(s, title, "gold", 30, 0, 0);
            list.Add(Piece("title", s, 16 + 40 + 12, 12 + (46 - lh) / 2));
            if (note != null)
            {
                var nt = T(Body, 11.5f, CREAM);
                list.Add(Piece("note", TextBox(note, nt), 16 + 40 + 12 + lw + 12, 12 + (46 - LH(nt)) / 2));
            }
        }

        void Left(List<ScreenPiece> list)
        {
            float x = 22, y = 72, w = 300, h = SH - 72 - 22;
            var s = new UiSvg(w, h);
            Plaque(s, 0, 0, w, h, "vel", 22, 3.5f, 2, 4);
            float cx = 16, cw = w - 32, cy = 12;
            var fav = _ranked.Count > 0 ? _ranked[0] : default;
            // favRow: the 92 box with the creature (72) and, beside it, FAVORITE, the name, the time
            float colX = cx + 92 + 14, colW = cw - 92 - 14;
            string sub = fav.c != null ? $"{FormatDuration(fav.ms)} of squishing" : "Squish a creature to find your favorite!";
            var subFlow = new TextFlow(sub, Sub);
            float subH = subFlow.Measure(colW).h;
            var (nw, nh) = fav.c != null ? LetteringSize(fav.c.Name, 20) : (0f, 0f);
            float colH = LH(Kicker) + nh + subH;
            float rowH = Math.Max(92, colH);
            if (fav.c != null) Picture(s, fav.c, cx + 10, cy + (rowH - 72) / 2, 72);
            float ty = cy + (rowH - colH) / 2;
            s.Text("FAVORITE", colX, ty, Kicker);
            ty += LH(Kicker);
            if (fav.c != null) { Lettering(s, fav.c.Name, "gold", 20, colX, ty); ty += nh; }
            subFlow.Draw(s, colX, ty, colW);
            cy += rowH + 6;
            var top = _ranked.Take(5).ToList();
            if (top.Count > 0)
            {
                s.Text("MOST SQUISHED", cx, cy + 4, Kicker);
                cy += 4 + LH(Kicker) + 6;
            }
            var ink = Ink(14);
            for (int i = 0; i < Math.Min(3, top.Count); i++)
            {
                var (c, ms) = top[i];
                // rankTop: name and time on one baseline, then the bar (7 + 4)
                float aN = UiSvg.Baseline(RankName, 0), aT = UiSvg.Baseline(RankTime, 0);
                float asc = Math.Max(aN, aT), desc = Math.Max(LH(RankName) - aN, LH(RankTime) - aT);
                float flexH = asc + desc + 4 + 11;
                float rh = Math.Max(40, Math.Max(LH(ink), flexH));
                float ry = cy + 3;
                string n = (i + 1).ToString();
                float nx = cx;
                s.Text(n, nx, ry + (rh - LH(ink)) / 2, ink);
                float ax = nx + W(n, ink) + 8;
                Picture(s, c, ax + 5, ry + (rh - 30) / 2, 30);
                float fx = ax + 40 + 8, fw = cx + cw - fx, fy = ry + (rh - flexH) / 2;
                string time = FormatDuration(ms);
                float tw = W(time, RankTime);
                s.Text(Ellipsize(c.Name, RankName, fw - tw - 8), fx, fy + asc - aN, RankName);
                s.Text(time, fx + fw - tw, fy + asc - aT, RankTime);
                Progress(s, fx, fy + asc + desc + 4, fw, (float)(ms / top[0].ms * 100), 7, INK, new[] { "#ffe08a", "#f0a21c" });
                cy += rh + 6 + 6;
            }
            list.Add(Piece("left", s, x, y, 1, null, 8));
        }

        static void Picture(UiSvg s, Creature c, float x, float y, float size)
        {
            var pic = Roster.Picture(c);
            if (pic == null) return;
            var (fx, fy, fw, fh) = Roster.PictureFrame(c.Key);
            s.Image(pic, x + fx * size, y + fy * size, fw * size, fh * size, "none");
        }

        void Grid(List<ScreenPiece> list)
        {
            float gx = 340, gy = 72, gw = SW - 340 - 22, gh = SH - 72 - 22;
            float tw = gw * 0.235f, th = 136;
            int perRow = Math.Max(1, (int)Math.Floor((gw + 0.001f) / tw));
            int rows = (_tiles.Count + perRow - 1) / perRow;
            for (int i = 0; i < _tiles.Count; i++)
            {
                int r = i / perRow, c = i % perRow;
                int inRow = Math.Min(perRow, _tiles.Count - r * perRow);
                float gapX = inRow > 1 ? (gw - inRow * tw) / (inRow - 1) : 0;
                float gapY = rows > 1 ? (gh - rows * th) / (rows - 1) : 0;
                float x = gx + c * (tw + gapX), y = gy + r * (th + gapY);
                var (label, value) = _tiles[i];
                var s = new UiSvg(tw, th);
                Plaque(s, 0, 0, tw, th, "vel", 18, 3, 2, 4);
                var (lw, lh) = LetteringSize(value, 22);
                float colH = lh + 6 + LH(TileLabel);
                float ty = (th - colH) / 2;
                Lettering(s, value, "gold", 22, (tw - lw) / 2, ty);
                s.Text(Ellipsize(label, TileLabel, tw - 16), 8, ty + lh + 6, TileLabel, tw - 16, 0.5f);
                list.Add(Piece("tile" + i, s, x, y, 1, null, 8));
            }
        }
    }
}
