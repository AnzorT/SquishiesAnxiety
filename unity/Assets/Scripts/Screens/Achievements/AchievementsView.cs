// src/screens/AchievementsScreen.js, landscape (REDESIGN_V8/V9: the wood, the carousel across the whole width, the
// details in one bar under it), as pure C#: its state, its motions on React Native's Animated (SquishSquad.Anim), and
// the pieces it shows each frame (Ui/Screens ScreenPiece, in screen dp). AchievementsScreen puts them on screen.
//   header   back orb, "Achievements", the total bar and "27 / 72"
//   stage    spinning rays and the pulsing halo behind the badges; one big badge at a time, its neighbours fanned out
//            smaller either side (the design's numbers: xOfWide / yOfWide / scaleOf / opacityOf); arrows at the sides
//   details  the current badge's title (gold when done), how to unlock it, its progress; "N OF M" under it
// Swipe sideways (more than 36 dp), tap an arrow or a side badge. Opens on the first achievement not done.
// The whole screen is in the design's 393-tall units, scaled to the phone (royal Stage).
// Not ported: the swoosh sound; a creature badge's mood motion (CreatureThumbnail's 'cycle' / 'idle': here its still).
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
    public sealed class AchievementsView : IScreenView
    {
        const float BADGE = 124, RING = 3, LIP = 7, SLOT = BADGE + RING * 2;
        const int WINDOW = 3;
        static readonly Func<double, double> MoveEase = Easing.Bezier(0.3, 1.3, 0.5, 1), FadeEase = Easing.Bezier(0.25, 0.1, 0.25, 1);

        public readonly List<Achievement> Entries;
        public readonly float ScreenW, ScreenH, K, SW, SH = 393;
        public int Index { get; private set; }
        public int DoneCount => Entries.Count(e => e.Done);
        public Action OnBack;

        readonly Ticker _t;
        readonly AnimatedValue _move, _fade, _detail = new AnimatedValue(0), _halo = new AnimatedValue(0), _rays = new AnimatedValue(0);
        int _spanLo, _spanHi;
        double _swipedAt = -1e9;
        readonly Dictionary<string, string> _bodies = new Dictionary<string, string>();

        public AchievementsView(IList<Creature> creatures, IDictionary<string, object> profile, float screenW, float screenH, Ticker ticker, int customCount = 0, int? startIndex = null)
        {
            _t = ticker;
            Entries = AchievementList.Compute(creatures, profile, customCount);
            ScreenW = screenW; ScreenH = screenH;
            K = StageK(screenW, screenH);
            SW = Math.Max(screenW, screenH) / K;
            int first = Entries.FindIndex(e => !e.Done);
            Index = startIndex.HasValue ? Math.Max(0, Math.Min(Entries.Count - 1, startIndex.Value)) : Math.Max(0, first);
            _spanLo = _spanHi = Index;
            _move = new AnimatedValue(Index);
            _fade = new AnimatedValue(Index);
            Motion.PingPong(_halo, 1000).Start();
            Motion.Phase(_rays, 12000).Start();
            Motion.Timing(_detail, 1, 320, Motion.OutQuad).Start();
        }

        // ---- the design's curves --------------------------------------------------------------------------------------
        static double XOf(int d) => d == 0 ? 0 : Math.Sign(d) * (150 + (Math.Abs(d) - 1) * 118);
        static double YOf(int d) => d == 0 ? -6 : 16 + (Math.Abs(d) - 1) * 6;
        static double ScaleOf(int d) => d == 0 ? 1 : Math.Max(0.5, 0.76 - (Math.Abs(d) - 1) * 0.1);
        static double OpacityOf(int d) => Math.Abs(d) > 3 ? 0 : d == 0 ? 1 : 0.9 - (Math.Abs(d) - 1) * 0.18;
        static double GlowOf(int d) => d == 0 ? 1 : 0;
        static double DimOf(int d) => d == 0 ? 0 : 0.08;

        /// <summary>curve(pos, index, fn): a badge at `index` sits at d = index - pos (key points d = -5 … 5, clamped).</summary>
        static double Curve(double pos, int index, Func<int, double> fn)
        {
            var xs = new double[11]; var ys = new double[11];
            for (int k = 0; k < 11; k++) { int d = 5 - k; xs[k] = index - d; ys[k] = fn(d); }
            return Motion.Lerp(pos, xs, ys);
        }

        // ---- moving --------------------------------------------------------------------------------------------------
        public void Go(int i)
        {
            int next = Math.Max(0, Math.Min(Entries.Count - 1, i));
            int from = Index;
            if (next == from) return;
            Index = next;
            _spanLo = Math.Min(from, next); _spanHi = Math.Max(from, next);
            Motion.Timing(_fade, next, 350, FadeEase).Start();
            Motion.Timing(_move, next, 500, MoveEase).Start(r => { if (r.Finished) { _spanLo = _spanHi = next; } });
            // the details remount (keyed by the entry): they rise in again
            _detail.SetValue(0);
            Motion.Timing(_detail, 1, 320, Motion.OutQuad).Start();
        }

        // ---- the pointer (screen dp) -----------------------------------------------------------------------------------
        float _dx0, _dy0;
        bool _down, _captured;
        string _pressed;

        (float x, float y) ToStage(float x, float y) => (x / K, y / K);

        public void Down(float sx, float sy)
        {
            var (x, y) = ToStage(sx, sy);
            _down = true; _captured = false; _dx0 = x; _dy0 = y;
            _pressed = HitButton(x, y);
        }

        public void Move(float sx, float sy)
        {
            if (!_down) return;
            var (x, y) = ToStage(sx, sy);
            float dx = x - _dx0, dy = y - _dy0;
            // the pan takes over from the badges once it's clearly sideways, and only in the stage
            if (!_captured && Math.Abs(dx) > 10 && Math.Abs(dx) > Math.Abs(dy) && _dy0 >= 60 && _dy0 < SH - 100) { _captured = true; _pressed = null; }
        }

        public void Up(float sx, float sy)
        {
            if (!_down) return;
            _down = false;
            var (x, y) = ToStage(sx, sy);
            float dx = x - _dx0;
            if (_captured)
            {
                if (Math.Abs(dx) > 36) { _swipedAt = _t.Now; Audio.Snd.Play("swoosh"); Go(Index + (dx < 0 ? 1 : -1)); }
                return;
            }
            var hit = HitButton(x, y);
            _pressed = null;
            if (hit != null && hit == HitButton(_dx0, _dy0))
            {
                Audio.Snd.Play(hit == "back" ? "tap" : "swoosh");
                if (hit == "back") OnBack?.Invoke();
                else if (hit == "left") Go(Index - 1);
                else if (hit == "right") Go(Index + 1);
                return;
            }
            int b = HitBadge(x, y);
            if (b >= 0 && b == HitBadge(_dx0, _dy0) && _t.Now - _swipedAt >= 250) { Audio.Snd.Play("swoosh"); Go(b); }
        }

        /// <summary>A tap at (x, y) screen dp.</summary>
        public void Tap(float sx, float sy) { Down(sx, sy); Up(sx, sy); }

        // the orbs' boxes (hitSlop 8)
        (float x, float y) BackAt => (16, 15);
        (float x, float y) LeftAt => (16, 60 + (SH - 160) / 2 - 20);
        (float x, float y) RightAt => (SW - 16 - 40, 60 + (SH - 160) / 2 - 20);

        string HitButton(float x, float y)
        {
            bool In((float x, float y) o) => x >= o.x - 8 && x < o.x + 48 && y >= o.y - 8 && y < o.y + 48;
            if (In(BackAt)) return "back";
            if (In(LeftAt)) return "left";
            if (In(RightAt)) return "right";
            return null;
        }

        int HitBadge(float x, float y)
        {
            if (y < 60 || y >= SH - 100) return -1;
            var order = Mounted().OrderByDescending(i => 50 - Math.Abs(i - Index)).ThenByDescending(i => i);
            foreach (var i in order)
            {
                var m = SlotTransform(i).Inverse();
                var p = m.Apply(new Vec2(x, y));
                if (p.X >= 0 && p.X < SLOT && p.Y >= 0 && p.Y < SLOT + LIP && Curve(_fade.GetValue(), i, OpacityOf) > 0) return i;
            }
            return -1;
        }

        IEnumerable<int> Mounted()
        {
            int lo = Math.Max(0, _spanLo - WINDOW), hi = Math.Min(Entries.Count - 1, _spanHi + WINDOW);
            for (int i = lo; i <= hi; i++) yield return i;
        }

        // ---- layout ----------------------------------------------------------------------------------------------------
        float Cx => SW / 2;
        float Cy => 60 + 0.46f * (SH - 160);

        Affine SlotTransform(int i)
        {
            double pos = _move.GetValue();
            double tx = Curve(pos, i, XOf), ty = Curve(pos, i, YOf), sc = Curve(pos, i, ScaleOf);
            return Affine.Translate(Cx - SLOT / 2, Cy - (SLOT + LIP) / 2) * About(SLOT, SLOT + LIP, Affine.Translate(tx, ty) * Affine.ScaleBy(sc, sc));
        }

        static readonly TextStyle CountText = T(Black, 15, CREAM, 0, 0, Drop(INK, 2));
        static readonly TextStyle DescText = T(Heavy, 14, "#ffffff", 0, 19, Drop(INK, 1.5f));
        static readonly TextStyle ProgText = T(Black, 11, CREAM, 0, 0, Drop(INK, 1.5f));
        static readonly TextStyle PosText = T(Black, 12, CREAM, 1.2f, 0, Drop(INK, 1.5f));
        static readonly string[] BarFill = { "#fff1b0", "#ffd24a", "#f0a21c" };

        /// <summary>The pieces this frame, in screen dp.</summary>
        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            list.Add(Piece("bg", WoodBg(SW, SH), SW, SH, 0, 0, 1, null, 0));

            // the rays (360, 9° rays, 13° gaps, turning every 12 s) and the halo pulsing behind the badges
            list.Add(Piece("rays", CardArtRays(), 360, 360, Cx - 180, Cy - 180, 1, About(360, 360, Affine.Rotate(_rays.GetValue() * 360)), 0));
            double h = _halo.GetValue();
            list.Add(Piece("halo", HaloSvg(), 230, 230, Cx - 115, Cy - 115, (float)(0.55 + 0.4 * h), About(230, 230, Affine.ScaleBy(0.9 + 0.22 * h, 0.9 + 0.22 * h)), 0));

            // the badges: drawn in zIndex order (50 - distance from the current one), ties in the list's order
            double pos = _move.GetValue(), fade = _fade.GetValue();
            // every badge's face and glow are react-native-svg gradients with the same id ("badgeFill", "badgeGlow"), so
            // Chrome paints them all with the first one in the page: the first mounted badge's (and the first glow's)
            var mounted = Mounted().ToList();
            bool firstDone = mounted.Count > 0 && Entries[mounted[0]].Done;
            int firstGlow = mounted.FirstOrDefault(i => Math.Abs(i - Index) <= 1);
            float glowStop = (BADGE / 2 - 4) / (BADGE / 2 + (Entries[firstGlow].Done ? 34 : 16));
            foreach (var i in Mounted().OrderBy(i => 50 - Math.Abs(i - Index)).ThenBy(i => i))
            {
                var e = Entries[i];
                int z = 50 - Math.Abs(i - Index);
                float op = (float)Curve(fade, i, OpacityOf);
                if (op <= 0) continue;
                var m = SlotTransform(i);
                if (z >= 49)
                {
                    float glowR = BADGE / 2 + (e.Done ? 34 : 16);
                    float g = (float)Curve(fade, i, GlowOf);
                    if (g > 0) list.Add(new ScreenPiece { Id = "glow" + i, Svg = GlowSvg(glowR, glowStop), W = glowR * 2, H = glowR * 2, Margin = 0, Opacity = op * g, Transform = m * Affine.Translate(SLOT / 2 - glowR, SLOT / 2 - glowR) });
                }
                list.Add(new ScreenPiece { Id = "badge" + i, Svg = Body(e, firstDone), W = SLOT, H = SLOT + LIP, Opacity = op, Transform = m });
                float dim = (float)Curve(fade, i, DimOf);
                if (dim > 0) list.Add(new ScreenPiece { Id = "dim" + i, Svg = DimSvg, W = SLOT, H = SLOT, Margin = 0, Opacity = op * dim, Transform = m });
            }
            // (the stage clips what's in it: the wood again above and below it)
            list.Add(Piece("wood-top", WoodBg(SW, SH, 0, 60), SW, 60, 0, 0, 1, null, 0));
            list.Add(Piece("wood-bottom", WoodBg(SW, SH, SH - 100, 100), SW, 100, 0, SH - 100, 1, null, 0));

            // the arrows
            list.Add(Orb("left", LeftAt, Index == 0 ? 0.4f : 1));
            list.Add(Orb("right", RightAt, Index == Entries.Count - 1 ? 0.4f : 1));

            Header(list);
            Details(list);
            return Staged(list, K);
        }

        ScreenPiece Orb(string icon, (float x, float y) at, float opacity = 1) =>
            Piece("orb-" + icon, Xml("orb-" + icon), 40, 40, at.x, at.y + (_pressed == icon ? 2 : 0), opacity);

        void Header(List<ScreenPiece> list)
        {
            list.Add(Orb("back", BackAt));
            var (lw, lh) = LetteringSize("Achievements", 30);
            var ls = new UiSvg(lw, lh);
            Lettering(ls, "Achievements", "gold", 30, 0, 0);
            float x = 16 + 40 + 12;
            list.Add(Piece("title", ls, x, 12 + (46 - lh) / 2));
            x += lw + 12;
            string count = $"{DoneCount} / {Entries.Count}";
            float cw = W(count, CountText);
            // wTotal: flex 1, marginLeft 12, maxWidth 300
            float barW = Math.Max(0, Math.Min(300, (SW - 16) - x - 12 - 12 - cw));
            var bar = new UiSvg(barW, 12);
            Bar(bar, 0, 0, barW, 12, Math.Max(3, (float)DoneCount / Math.Max(1, Entries.Count) * 100), "rgba(107,68,38,0.45)", 1.5f, INK, 6, BarFill, null, 5);
            list.Add(Piece("total", bar, x + 12, 12 + 17));
            float ch = LH(CountText);
            list.Add(Piece("count", TextBox(count, CountText), x + 12 + barW + 12, 12 + (46 - ch) / 2));
        }

        void Details(List<ScreenPiece> list)
        {
            if (Entries.Count == 0) return;
            var e = Entries[Index];
            float px = 24, py = SH - 24 - 76, pw = SW - 48;
            float iw = pw - 36;
            var (lw, lh) = LetteringSize(e.Title, 22);
            float descH = 19;
            bool prog = e.HasProgress && !e.Done;
            float progH = prog ? Math.Max(10, LH(ProgText)) : 0;
            float colH = lh + 1 + descH + (prog ? 1 + 3 + progH : 0);
            var s = new UiSvg(pw, 76);
            float y = (76 - colH) / 2;
            Lettering(s, e.Title, e.Done ? "gold" : "white", 22, (pw - lw) / 2, y);
            y += lh + 1;
            var desc = Ellipsize(e.Desc, DescText, iw);
            s.Text(desc, 18, y, DescText, iw, 0.5f);
            y += descH + 1;
            if (prog)
            {
                string label = $"{Prof.Fmt(e.ProgCur)} / {Prof.Fmt(e.ProgMax)}";
                float tw = W(label, ProgText), rw = 170 + 8 + tw;
                float rx = (pw - rw) / 2, ry = y + 3;
                Bar(s, rx, ry + (progH - 10) / 2, 170, 10, (float)Math.Max(3, Math.Min(100, e.ProgCur / e.ProgMax * 100)), "rgba(107,68,38,0.45)", 1.5f, INK, 6, BarFill, null, 5);
                s.Text(label, rx + 178, ry + (progH - LH(ProgText)) / 2, ProgText);
            }
            double t = _detail.GetValue();
            list.Add(Piece("details-" + e.Key, s, px, py, (float)t, Affine.Translate(0, 10 * (1 - t))));
            string posT = $"{Index + 1} OF {Entries.Count}";
            float ph = LH(PosText);
            var pos = new UiSvg(SW, ph);
            pos.Text(posT, 0, 0, PosText, SW, 0.5f);
            list.Add(Piece("pos", pos, 0, SH - 7 - ph));
        }

        // ---- the drawings -------------------------------------------------------------------------------------------
        static string _rays_, _halo_;
        static string CardArtRays() => _rays_ ??= Ui.Cards.CardArt.Rays(360, 9, 13, 0.4f, 0.14f, 0.62f);

        static string HaloSvg()
        {
            if (_halo_ != null) return _halo_;
            var s = new UiSvg(230, 230);
            s.Def("<radialGradient id=\"halo\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.9\"/><stop offset=\"0.3\" stop-color=\"#ffe6a0\" stop-opacity=\"0.55\"/><stop offset=\"0.5\" stop-color=\"#ffa64a\" stop-opacity=\"0.3\"/><stop offset=\"0.7\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw("<circle cx=\"115\" cy=\"115\" r=\"115\" fill=\"url(#halo)\"/>");
            return _halo_ = s.Markup;
        }

        static readonly Dictionary<(float, float), string> Glows = new Dictionary<(float, float), string>();
        static string GlowSvg(float r, float stop)
        {
            if (Glows.TryGetValue((r, stop), out var g)) return g;
            var s = new UiSvg(r * 2, r * 2);
            s.Def($"<radialGradient id=\"badgeGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"{F(stop)}\" stop-color=\"#ffdc78\" stop-opacity=\"0.9\"/><stop offset=\"1\" stop-color=\"#ffdc78\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<circle cx=\"{F(r)}\" cy=\"{F(r)}\" r=\"{F(r)}\" fill=\"url(#badgeGlow)\"/>");
            return Glows[(r, stop)] = s.Markup;
        }

        static string _dim;
        static string DimSvg => _dim ??= new UiSvg(SLOT, SLOT).Box(8, 8, 114, 114, new BoxStyle { Radius = 57, Background = "#000000" }).Markup;

        static readonly (float o, string c, float a)[] DONE_STOPS = { (0, "#fffbe0", 1), (0.3f, "#ffe45c", 1), (0.62f, "#ffc21a", 1), (1, "#e08a00", 1) };
        static readonly (float o, string c, float a)[] LOCKED_STOPS_WOOD = { (0, "#ffffff", 0.6f), (0.45f, "#ffdcae", 0.5f), (1, "#b8763a", 0.6f) };

        string Body(Achievement e, bool firstDone)
        {
            string key = e.Key + (firstDone ? "+" : "-");
            if (_bodies.TryGetValue(key, out var b)) return b;
            bool done = e.Done;
            string ring = done ? "#a0520a" : INK;
            var s = new UiSvg(SLOT, SLOT + LIP);
            s.Box(0, LIP, SLOT, SLOT, new BoxStyle { Radius = SLOT / 2, Background = ring });
            s.Box(0, 0, SLOT, SLOT, new BoxStyle { Radius = SLOT / 2, Background = ring });
            float bw = Bw(5);
            float px = RING + bw, pw = BADGE - 2 * bw;
            var clip = s.NewId("rim");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, px, pw, pw, new[] { BADGE / 2 - bw, BADGE / 2 - bw, BADGE / 2 - bw, BADGE / 2 - bw })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            // the face: react-native-svg's radial over the 114 box (a circle of r 124 at its middle)
            var gid = s.NewId("bf");
            var stops = firstDone ? DONE_STOPS : LOCKED_STOPS_WOOD;
            s.Def($"<radialGradient id=\"{gid}\" cx=\"35%\" cy=\"{(firstDone ? "28%" : "25%")}\" r=\"{(firstDone ? "97%" : "99%")}\">" + string.Concat(stops.Select(st => $"<stop offset=\"{F(st.o)}\" stop-color=\"{st.c}\" stop-opacity=\"{F(st.a)}\"/>")) + "</radialGradient>");
            float inner = BADGE - 10;
            s.Raw($"<svg x=\"{F(px)}\" y=\"{F(px)}\" width=\"{F(inner)}\" height=\"{F(inner)}\" viewBox=\"0 0 {F(inner)} {F(inner)}\" overflow=\"visible\"><circle cx=\"{F(inner / 2)}\" cy=\"{F(inner / 2)}\" r=\"{F(BADGE)}\" fill=\"url(#{gid})\"/></svg>");
            float c = SLOT / 2;
            if (e.Creature != null)
            {
                var pic = Roster.Picture(e.Creature);
                if (pic != null)
                {
                    var (fx, fy, fw, fh) = Roster.Frame(Roster.Ar(e.Creature.Key));
                    s.Image(pic, c - 42 + fx * 84, c - 42 + fy * 84, fw * 84, fh * 84, "none");
                }
            }
            else BadgeLabel(s, e.BadgeLabel, ring, c);
            Shine(s, px, px, inner, inner, inner * 0.16f, 0.38f, 999, BADGE / 2 - bw);
            s.Close();
            // the rim: a white border, nothing behind the face but the ring
            s.Box(RING, RING, BADGE, BADGE, new BoxStyle { Radius = BADGE / 2, BorderWidth = bw, BorderColor = "#ffffff" });
            if (done)
            {
                float x = SLOT - RING - 34, y = RING;
                s.Box(x, y, 34, 34, new BoxStyle { Radius = 17, Background = "#0c5a9c" });
                float fb = Bw(3);
                s.Box(x + 2, y + 2, 30, 30, new BoxStyle { Radius = 15, Background = "#ffffff" });
                s.Box(x + 2 + fb, y + 2 + fb, 30 - 2 * fb, 30 - 2 * fb, new BoxStyle { Radius = 15 - fb, Gradient = new[] { "#b0fbff", "#1695d6" } });
                var ct = T(Black, 15, "#ffffff", 0, 0, Drop("#0c5a9c", 1));
                float tw = W("✓", ct), th = LH(ct);
                s.Text("✓", x + 2 + fb + (30 - 2 * fb - tw) / 2, y + 2 + fb + (30 - 2 * fb - th) / 2, ct);
            }
            else if (e.Creature == null)
            {
                float x = SLOT - RING - 34, y = RING, fb = Bw(3);
                s.Box(x, y, 34, 34, new BoxStyle { Radius = 17, Background = INK });
                s.Box(x + 2, y + 2, 30, 30, new BoxStyle { Radius = 15, Background = "#c98d52", BorderWidth = fb, BorderColor = "#ffffff" });
                float ix = x + 2 + fb, iy = y + 2 + fb, iw = 30 - 2 * fb;
                float top = iy + (iw - 15) / 2;
                s.Box(ix + (iw - 8) / 2, top, 8, 7, new BoxStyle { Radii = new[] { 5f, 5, 0, 0 }, Borders = new[] { 2f, 2, 0, 2 }, BorderColor = "#ffffff" });
                s.Box(ix + (iw - 12) / 2, top + 7, 12, 8, new BoxStyle { Radius = 2, Background = "#ffffff" });
            }
            return _bodies[key] = s.Markup;
        }

        // the badge's label: ShadowText (white Fredoka 40, or 30 past 3 characters) with its ring-coloured copies; a 🔥
        // in it is Chrome's emoji picture (export-screens.mjs)
        static void BadgeLabel(UiSvg s, string label, string ring, float c)
        {
            float size = label.Length > 3 ? 30 : 40;
            var shadows = new[] { new Shadow(ring, 0, 3, 0), new Shadow(ring, 2, 0, 0), new Shadow(ring, -2, 0, 0), new Shadow(ring, 0, -2, 0) };
            var st = T(Display, size, "#ffffff", 0, 0, shadows);
            int fire = label.IndexOf("🔥", StringComparison.Ordinal);
            if (fire < 0)
            {
                float w = W(label, st), h = LH(st);
                s.Text(label, c - w / 2, c - h / 2, st);
                return;
            }
            var em = Emoji.Of(size == 40 ? "fire-40" : "fire-30");
            string pre = label.Substring(0, fire);
            float pw = W(pre, st), lh = Math.Max(LH(st), em.H);
            float x = c - (pw + em.Adv) / 2, y = c - lh / 2;
            // (the copies under it first, the emoji in each)
            for (int i = shadows.Length - 1; i >= -1; i--)
            {
                float dx = i >= 0 ? shadows[i].X : 0, dy = i >= 0 ? shadows[i].Y : 0;
                s.Text(pre, x + dx, y + dy + (lh - LH(st)) / 2, T(Display, size, i >= 0 ? ring : "#ffffff"));
                s.Image("Screens/emoji/" + em.Name, x + pw + dx, y + dy, em.W, em.H, "none");
            }
        }
    }
}
