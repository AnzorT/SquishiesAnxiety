// Squishdoku's level map in landscape (src/squishdoku/LevelMap.js, REDESIGN_V8): a chapter (20 levels, one Crib room) a
// page, scrolling sideways: the chapter's room, its name, its levels' sizes and ◀ ▶ at the start, then its levels on a
// gentle wave about the middle line, dots between them (gold up to the current one), and CHAPTER n+1 ▶ at the end. Done
// levels are gold with the three creatures they earned under them, the current one orange and pulsing with a creature
// bobbing beside it, the rest grey and locked (a tap rattles the lock). Nodes pop in round the current one (45 ms a
// level further, at most 700), the 12 nearest built first and the rest a frame later; a level just unlocked breaks its
// lock open. The page opens scrolled to the current level. It sits under the screen's top bar (48 dp); SdScreen hosts
// it (the world picture behind is the screen's). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdMap
    {
        public const float Top = 48;
        const float NODE = 62, HEAD_W = 214, FIRST_X = HEAD_W + 78, GAP_X = 96;
        public Action<int> OnPlay;

        readonly float W, H, MapH;
        readonly Ticker _tk;
        readonly Func<string, string> _xml;
        readonly SdCreature[] _roster;
        SdkRecord _rec;
        int _cur;
        int? _justUnlocked;
        int _chapter, _from, _count;
        float _contentW;
        (float x, float y)[] _points;
        int[] _order;
        int _built;
        Node[] _nodes;
        SdLayer _chapterL, _dotsL, _nextL;
        readonly SdLayer _orbL, _orbR;
        readonly List<int> _timers = new List<int>();

        /// <summary>The page's scroll (dp from its start).</summary>
        public float ScrollX { get; private set; }

        sealed class Node
        {
            public int Lv;
            public float X, Y, BoxH;
            public string State;
            public readonly AnimatedValue T = new AnimatedValue(0), Shake = new AnimatedValue(0), Lock = new AnimatedValue(1);
            public KeyLoop Pulse, Bob;
            public SdLayer Body, LockL, Mascot;
            public bool MascotLeft, Unlocking;
            public readonly List<Burst> Bursts = new List<Burst>();
        }

        public SdMap(float screenW, float screenH, SdkRecord rec, SdCreature[] roster, int? justUnlocked, Func<string, string> xml, Ticker tk)
        {
            W = screenW; H = screenH; MapH = screenH - Top; _rec = rec; _roster = roster; _justUnlocked = justUnlocked; _xml = xml; _tk = tk;
            _cur = (int)Math.Min(rec.Lv, Levels.LevelCount);
            _orbL = new SdLayer("orb left").Set(xml("orb-left"), 36, 36, 8);
            _orbR = new SdLayer("orb right").Set(xml("orb-right"), 36, 36, 8);
            _chapter = Levels.ChapterOf(justUnlocked ?? _cur);
        }

        /// <summary>Back to the map kept under a level (KeptView): the same page, its nodes as the profile now says (a level
        /// done turns gold, the next one current), and the level just unlocked breaking its lock open.</summary>
        public void Refresh(SdkRecord rec, int? justUnlocked)
        {
            _rec = rec;
            _cur = (int)Math.Min(rec.Lv, Levels.LevelCount);
            _justUnlocked = justUnlocked;
            _dotsKey = null;
            for (int i = 0; i < _count; i++)
            {
                var n = _nodes[i];
                if (n == null) continue;
                var state = StateOf(n.Lv);
                bool unlocking = justUnlocked == n.Lv;
                bool mascot = n.Lv == _cur && _roster.Length > 0;
                if (state == n.State && unlocking == n.Unlocking && mascot == (n.Mascot != null)) continue;
                n.State = state; n.Unlocking = unlocking;
                n.BoxH = state == "done" ? NODE + 4 + 22 : NODE;
                n.Body.Set(NodeSvg(n, i), NODE, n.BoxH, 10);
                if (state != "locked" && !unlocking) n.LockL = null;
                n.Pulse?.Unmount(); n.Pulse = null;
                if (state == "current") { n.Pulse = new KeyLoop(1400, KeyLoop.PHASE, KeyLoop.UP_DOWN); n.Pulse.Mount(); }
                n.Bob?.Unmount(); n.Bob = null; n.Mascot = null;
                if (mascot)
                {
                    var s = new UiSvg(40, 40);
                    CardArt.Head(s, 0, 0, 40, RosterPic(_cur * 11), "#ffffff", "#f6efff");
                    n.Mascot = new SdLayer("mascot").Set(s.Markup, 40, 40, 2);
                    n.Bob = new KeyLoop(1400, KeyLoop.PHASE, Array.ConvertAll(KeyLoop.UP_DOWN, k => -6 * k));
                    n.Bob.Mount();
                }
                if (unlocking) Unlock(n, Math.Min(700, Math.Abs(n.Lv - _cur) * 45));
            }
        }

        // a lock rattling, then bursting off
        void Unlock(Node n, double delay) =>
            Later(delay + 500, () =>
            {
                var seq = new List<CompositeAnimation>();
                foreach (var k in new[] { 1, -1, 1, -1, 0.5, 0 }) seq.Add(Animated.Timing(n.Shake, Fx.Timing(k, 55)));
                seq.Add(Animated.Timing(n.Lock, Fx.Timing(0, 1)));
                Animated.Sequence(seq).Start();
                Later(330, () => { var b = new Burst("gold", NODE / 2, NODE / 2, 1); n.Bursts.Add(b); b.Start(() => n.Bursts.Remove(b)); });
            });

        /// <summary>The map's content mounts (built behind its placeholders).</summary>
        public void Mount() => Build();

        public void Unmount()
        {
            foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            if (_nodes != null) foreach (var n in _nodes) { n?.Pulse?.Unmount(); n?.Bob?.Unmount(); }
        }

        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));

        void Build()
        {
            Unmount();
            _from = (_chapter - 1) * Levels.Chapter;
            _count = Math.Min(Levels.Chapter, Levels.LevelCount - _from);
            float amp = Math.Min(24, MapH * 0.075f);
            _points = new (float, float)[_count];
            for (int i = 0; i < _count; i++) _points[i] = (FIRST_X + i * GAP_X, (float)(MapH * 0.5 - 10 + Math.Sin((_from + i) * 1.05) * amp));
            _contentW = _points[_count - 1].x + 190;
            var order = new List<int>();
            for (int i = 0; i < _count; i++) order.Add(i);
            order.Sort((a, b) => { int da = Math.Abs(_from + a + 1 - _cur), db = Math.Abs(_from + b + 1 - _cur); return da != db ? da.CompareTo(db) : a.CompareTo(b); });
            _order = order.ToArray();
            _nodes = new Node[_count];
            _built = 0;
            Grow(12);
            // useProgressive: 10 more a frame
            Action more = null;
            more = () => { Grow(10); if (_built < _count) _tk.RequestAnimationFrame(more); };
            if (_built < _count) _tk.RequestAnimationFrame(more);
            DrawChapter();
            // the current level in view (the start of the page on another chapter), once laid out
            int ci = _cur - 1 - _from;
            bool at = ci >= 0 && ci < _count;
            Later(0, () => ScrollX = Clamp(at ? Math.Max(0, _points[ci].x - W / 2) : 0));
        }

        float Clamp(float x) => Math.Max(0, Math.Min(Math.Max(0, _contentW - W), x));

        void Grow(int k)
        {
            for (int j = _built; j < Math.Min(_count, _built + k); j++) MakeNode(_order[j]);
            _built = Math.Min(_count, _built + k);
            _dotsKey = null;
        }

        string StateOf(int lv) => lv < _cur ? "done" : lv == _cur ? (Best(lv) > 0 ? "done" : "current") : "locked";
        int Best(int lv) => (int)Js.OrNumber(_rec.Best.TryGetValue(Js.IntKey(lv), out var b) ? b : null, 0);
        bool PerfectOf(int lv) => Js.Truthy(_rec.Perfect.TryGetValue(Js.IntKey(lv), out var p) ? p : null);
        string RosterPic(int i) => _roster.Length > 0 ? _roster[((i % _roster.Length) + _roster.Length) % _roster.Length]?.Picture : null;

        void MakeNode(int i)
        {
            int lv = _from + i + 1;
            var n = _nodes[i] = new Node { Lv = lv, X = _points[i].x, Y = _points[i].y, State = StateOf(lv), Unlocking = _justUnlocked == lv, MascotLeft = _points[i].x > W / 2 };
            if (n.Unlocking) n.Lock.SetValue(0);
            n.BoxH = n.State == "done" ? NODE + 4 + 22 : NODE;
            n.Body = new SdLayer("level " + lv).Set(NodeSvg(n, i), NODE, n.BoxH, 10);
            if (n.State == "locked" || n.Unlocking) n.LockL = new SdLayer("lock " + lv).Set(LockSvg(), 26, 28, 4);
            if (lv == _cur && _roster.Length > 0)
            {
                var pic = RosterPic(_cur * 11);
                var s = new UiSvg(40, 40);
                CardArt.Head(s, 0, 0, 40, pic, "#ffffff", "#f6efff");
                n.Mascot = new SdLayer("mascot").Set(s.Markup, 40, 40, 2);
                n.Bob = new KeyLoop(1400, KeyLoop.PHASE, Array.ConvertAll(KeyLoop.UP_DOWN, k => -6 * k));
                n.Bob.Mount();
            }
            if (n.State == "current") { n.Pulse = new KeyLoop(1400, KeyLoop.PHASE, KeyLoop.UP_DOWN); n.Pulse.Mount(); }
            double delay = Math.Min(700, Math.Abs(lv - _cur) * 45);
            Animated.Spring(n.T, Fx.Spring(1, 5, 150, delay)).Start();
            if (n.Unlocking) Unlock(n, delay);
        }

        static readonly TextStyle Num = new TextStyle { Font = SdArt.Display, Size = 22, Color = "#ffffff", Shadows = new[] { new Shadow(SdArt.INK, 0, 2, 1) } };
        static readonly TextStyle NumLocked = new TextStyle { Font = SdArt.Display, Size = 22, Color = "#8f80a3", Shadows = new[] { new Shadow(SdArt.INK, 0, 2, 1) } };

        string NodeSvg(Node n, int i)
        {
            var colors = n.State == "done" ? new[] { "#fff7b0", "#ffd23a", "#ff9c0a" } : n.State == "current" ? new[] { "#ffe2c8", "#ff9a4a", "#e0601c" } : new[] { "#f1ebe4", "#dacdbf", "#c2b2a1" };
            var ring = n.State == "done" ? "#9c4d06" : n.State == "current" ? "#8a3a0e" : "#7a6a8c";
            int tier = Levels.LevelList[n.Lv - 1].Tier;
            var s = new UiSvg(NODE, n.BoxH);
            s.Box(0, 5, NODE, NODE, new BoxStyle { Background = ring, Radius = NODE / 2 });
            s.Box(0, 0, NODE, NODE, new BoxStyle { Background = ring, Radius = NODE / 2 });
            float f = NODE - 5;
            s.Box(2.5f, 2.5f, f, f, new BoxStyle { Gradient = colors, GradientStops = new[] { 0f, 0.5f, 1 }, Radius = NODE / 2 });
            var clip = s.NewId("nc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(5.5f, 5.5f, f - 6, f - 6, new[] { 28f, 28, 28, 28 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(5.5f + 8, 5.5f + 3, f - 6 - 16, (f - 6) * 0.38f, new BoxStyle { Background = "rgba(255,255,255,0.5)", Radius = 99 });
            var t = n.State == "locked" ? NumLocked : Num;
            var label = n.Lv.ToString();
            s.Text(label, 5.5f, 5.5f + (f - 6 - UiSvg.LineBox(t)) / 2, t, f - 6, 0.5f);
            s.Box(5.5f + (f - 6 - 8) / 2, 5.5f + f - 6 - 5 - 8, 8, 8, new BoxStyle { Background = SdArt.TIER_COLORS[tier], Radius = 4, BorderWidth = 1.5f, BorderColor = "#ffffff" });
            s.Close();
            s.Box(2.5f, 2.5f, f, f, new BoxStyle { BorderWidth = 3, BorderColor = "#ffffff", Radius = NODE / 2 });
            if (PerfectOf(n.Lv))
            {
                s.Box(-6, -6, 22, 22, new BoxStyle { Background = "#e01e4a", Radius = 11, BorderWidth = 2, BorderColor = "#ffffff" });
                var pt = new TextStyle { Font = SdArt.Display, Size = 11, Color = "#ffffff" };
                s.Text("P", -4, -4 + (18 - UiSvg.LineBox(pt)) / 2, pt, 18, 0.5f);
            }
            if (n.State == "done")
            {
                int stars = Best(n.Lv);
                float x = 0;
                for (int k = 0; k < 3; k++)
                {
                    float size = k == 1 ? 22 : 19;
                    var pic = RosterPic((_from + i + 1) * 7 + k * 13);
                    CardArt.Head(s, x, NODE + 4 + (k == 1 ? 0 : 3), size, pic, k < stars ? "#ffd23a" : "#ffffff", "#f6efff", k >= stars);
                    x += size + 1;
                }
            }
            return s.Markup;
        }

        static string LockSvg()
        {
            var s = new UiSvg(26, 28);
            s.Box(6, 0, 14, 14, new BoxStyle { Radius = 7, Borders = new[] { 3.5f, 3.5f, 0, 3.5f }, BorderColor = "#7a6a8c" });
            s.Box(2, 11, 22, 15, new BoxStyle { Background = "#7a6a8c", Radius = 5, BorderWidth = 2, BorderColor = "#ffffff" });
            return s.Markup;
        }

        // ---- the chapter's column, the dots, NEXT ------------------------------------------------------------------------
        static readonly TextStyle Banner = new TextStyle { Font = SdArt.Display, Size = 11.5f, LetterSpacing = 1, Color = "#ffffff" };
        static readonly TextStyle Sub = new TextStyle { Font = SdArt.Display, Size = 11, LetterSpacing = 1, Color = SdArt.INK };
        static readonly TextStyle NextText = new TextStyle { Font = SdArt.Display, Size = 15, LetterSpacing = 1.5f, Color = "#ffffff" };
        float ChapterTop => MapH / 2 - 112;
        float ArrowsY { get { return ChapterTop + 110 + 6 + (UiSvg.LineBox(Banner) + 11) + 6 + UiSvg.LineBox(Sub) + 6 + 4; } }

        void DrawChapter()
        {
            var room = Levels.RoomOfChapter(_chapter);
            var R = Rooms.Of(room);
            var s = new UiSvg(HEAD_W + 28, MapH);
            float cx = 14 + HEAD_W / 2f, y = ChapterTop;
            // RoomCard 190 x 104 in a 3 dp white rim
            float cw = 190, ch = 104, x0 = cx - (cw + 6) / 2;
            s.Box(x0, y, cw + 6, ch + 6, new BoxStyle { Background = "#ffffff", Radius = 16 });
            var clip = s.NewId("rc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(x0 + 3, y + 3, cw, ch, new[] { 13f, 13, 13, 13 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(x0 + 3, y + 3, cw, ch, new BoxStyle { Background = R.Bg });
            float pw = (float)(ch * Rooms.RATIO), left = (float)Math.Min(0, Math.Max(cw - pw, cw / 2 - R.Cx * pw));
            string P(string n) => "Squishdoku/rooms/" + room + "-" + n;
            if (room == "yard") s.Image(P("under-day"), x0 + 3 + left, y + 3, pw, ch);
            s.Image(P("base"), x0 + 3 + left, y + 3, pw, ch);
            if (room != "yard") s.Image(P("over-day"), x0 + 3 + left, y + 3, pw, ch);
            s.Close();
            y += ch + 6 + 6;
            // CHAPTER n · ROOM (one line, at most the column's width)
            var text = $"CHAPTER {_chapter} · {R.Name.ToUpperInvariant()}";
            float bw = Math.Min(HEAD_W, UiSvg.BoxWidth(text, Banner) + 20 + 4), bh = UiSvg.LineBox(Banner) + 6 + 4;
            s.Box(cx - bw / 2, y, bw, bh, new BoxStyle { Background = "#b8641c", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
            s.Text(text, cx - bw / 2 + 12, y + 5, Banner);
            y += bh + 6;
            var sizes = new SortedSet<int>();
            for (int i = 0; i < _count; i++) sizes.Add(Levels.LevelList[_from + i].N);
            var parts = new List<string>();
            foreach (var n in sizes) parts.Add($"{n}×{n}");
            var sub = $"LEVELS {_from + 1}-{_from + _count} · {string.Join(" ", parts)}";
            s.Text(sub, Card.Snap(cx - UiSvg.BoxWidth(sub, Sub) / 2), y, Sub);
            _chapterL = new SdLayer("chapter").Set(s.Markup, HEAD_W + 28, MapH, 4);
            if (_chapter < Levels.Chapters)
            {
                var nt = $"CHAPTER {_chapter + 1} ▶";
                float nw = UiSvg.BoxWidth(nt, NextText) + 44 + 6, nh = UiSvg.LineBox(NextText) + 18 + 6;
                _nextL = new SdLayer("next chapter").Set(new UiSvg(nw, nh).Box(0, 0, nw, nh, new BoxStyle { Background = "#b8641c", Radius = 999, BorderWidth = 3, BorderColor = "#ffffff" }).Text(nt, 25, 12, NextText).Markup, nw, nh, 2);
            }
            else _nextL = null;
        }

        string _dotsKey;
        void DrawDots()
        {
            var key = $"{_chapter}|{_built}";
            if (key == _dotsKey) return;
            _dotsKey = key;
            var s = new UiSvg(_contentW, MapH);
            bool Built(int i) => _nodes[i] != null;
            for (int i = 0; i < _count - 1; i++)
            {
                if (!Built(i) || !Built(i + 1)) continue;
                var a = _points[i]; var b = _points[i + 1];
                for (int k = 1; k <= 3; k++)
                {
                    float f = k / 4f;
                    s.Box(a.x + (b.x - a.x) * f - 4, a.y + (b.y - a.y) * f - 4, 8, 8, new BoxStyle { Background = _from + i + 1 < _cur ? "#ffd23a" : "rgba(255,255,255,0.75)", Radius = 4 });
                }
            }
            (_dotsL ??= new SdLayer("dots")).Set(s.Markup, _contentW, MapH, 2);
        }

        // ---- every frame ---------------------------------------------------------------------------------------------------
        static readonly Interpolator LockK = Fx.Lerp(new[] { 0.0, 1 }, new[] { 1.8, 1 });

        public void Layers(Affine view, float opacity, List<SdLayer> o)
        {
            Fling();
            var page = view * Affine.Translate(-ScrollX, Top);
            _chapterL.Transform = page; _chapterL.Opacity = opacity; o.Add(_chapterL);
            float ax = 14 + HEAD_W / 2f - 45;
            _orbL.Transform = page * Affine.Translate(ax, ArrowsY + (_down == -1 ? 2 : 0)); _orbL.Opacity = opacity * (_chapter <= 1 ? 0.4f : 1); o.Add(_orbL);
            _orbR.Transform = page * Affine.Translate(ax + 54, ArrowsY + (_down == -2 ? 2 : 0)); _orbR.Opacity = opacity * (_chapter >= Levels.Chapters ? 0.4f : 1); o.Add(_orbR);
            DrawDots();
            _dotsL.Transform = page; _dotsL.Opacity = opacity; o.Add(_dotsL);
            foreach (var n in _nodes)
            {
                if (n == null) continue;
                double t = n.T.GetValue(), pulse = 1 + 0.08 * (n.Pulse?.Value ?? 0), sh = n.Shake.GetValue();
                var m = page * Affine.Translate(n.X - NODE / 2, n.Y - NODE / 2) * Fx.About(NODE, n.BoxH, Affine.ScaleBy(t * pulse, t * pulse) * Affine.Translate(6 * sh, 0) * Affine.Rotate(8 * sh));
                float op = (float)Math.Max(0, Math.Min(1, t)) * opacity;
                n.Body.Transform = m; n.Body.Opacity = op; o.Add(n.Body);
                if (n.LockL != null)
                {
                    double l = n.Lock.GetValue(), k = LockK.Evaluate(l);
                    n.LockL.Transform = m * Affine.Translate(NODE + 6 - 26, -6) * Fx.About(26, 28, Affine.ScaleBy(k, k));
                    n.LockL.Opacity = op * (float)Math.Max(0, Math.Min(1, l));
                    if (n.LockL.Opacity > 0) o.Add(n.LockL);
                }
                if (n.Mascot != null)
                {
                    n.Mascot.Transform = m * Affine.Translate(n.MascotLeft ? -6 - 40 : NODE + 6, 8 + (n.Bob?.Value ?? 0));
                    n.Mascot.Opacity = op; o.Add(n.Mascot);
                }
                foreach (var b in n.Bursts) { b.Place(m, op); foreach (var l in b.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
            }
            if (_nextL != null)
            {
                _nextL.Transform = page * Affine.Translate(_points[_count - 1].x + 54, MapH / 2 - 24 + (_down == -3 ? 0 : 0));
                _nextL.Opacity = opacity; o.Add(_nextL);
            }
        }
        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();

        // ---- touches: drag to scroll (with a fling), tap a node, the arrows, NEXT --------------------------------------------
        int _down;       // >0 a node's level, -1 ◀, -2 ▶, -3 NEXT
        float _x0, _y0, _sx0, _lastX;
        double _lastT, _vel;
        bool _dragging, _moved;

        int Hit(float x, float y)
        {
            float cx = x + ScrollX, cy = y - Top;
            float ax = 14 + HEAD_W / 2f - 45;
            if (cx >= ax - 8 && cx <= ax + 44 && cy >= ArrowsY - 8 && cy <= ArrowsY + 44) return -1;
            if (cx >= ax + 54 - 8 && cx <= ax + 98 && cy >= ArrowsY - 8 && cy <= ArrowsY + 44) return -2;
            if (_nextL != null)
            {
                float nx = _points[_count - 1].x + 54, ny = MapH / 2 - 24;
                if (cx >= nx - 8 && cx <= nx + _nextL.W + 8 && cy >= ny - 8 && cy <= ny + _nextL.H + 8) return -3;
            }
            foreach (var n in _nodes)
                if (n != null && cx >= n.X - NODE / 2 - 8 && cx <= n.X + NODE / 2 + 8 && cy >= n.Y - NODE / 2 - 8 && cy <= n.Y + NODE / 2 + 8) return n.Lv;
            return 0;
        }

        public void Down(float x, float y)
        {
            _down = Hit(x, y);
            _x0 = x; _y0 = y; _sx0 = ScrollX; _lastX = x; _lastT = _tk.Now; _vel = 0;
            _dragging = true; _moved = false;
        }

        public void Move(float x, float y)
        {
            if (!_dragging) return;
            if (!_moved && Math.Abs(x - _x0) > 8) { _moved = true; _down = 0; }
            if (!_moved) return;
            double dt = Math.Max(1, _tk.Now - _lastT);
            _vel = 0.8 * ((_lastX - x) / dt) + 0.2 * _vel;
            _lastX = x; _lastT = _tk.Now;
            ScrollX = Clamp(_sx0 - (x - _x0));
        }

        public void Up(float x, float y)
        {
            _dragging = false;
            int was = _down;
            _down = 0;
            if (_moved) { _flingT = _tk.Now; return; }
            if (was == 0 || Hit(x, y) != was) return;
            if (was == -1) Turn(_chapter - 1);
            else if (was == -2 || was == -3) Turn(_chapter + 1);
            else Press(was);
        }

        double _flingT = -1;
        void Fling()
        {
            if (_flingT < 0 || _dragging) return;
            double dt = _tk.Now - _flingT;
            _flingT = _tk.Now;
            _vel *= Math.Pow(0.998, dt);
            if (Math.Abs(_vel) < 0.02) { _flingT = -1; return; }
            float next = Clamp(ScrollX + (float)(_vel * dt));
            if (next == ScrollX) { _flingT = -1; return; }
            ScrollX = next;
        }

        void Turn(int c)
        {
            if (c < 1 || c > Levels.Chapters) return;
            _chapter = c;
            Build();
        }

        void Press(int lv)
        {
            Node n = null;
            foreach (var k in _nodes) if (k != null && k.Lv == lv) n = k;
            if (n == null) return;
            if (n.State == "locked")
            {
                n.Shake.SetValue(0);
                var seq = new List<CompositeAnimation>();
                foreach (var k in new[] { 1, -1, 0.7, -0.7, 0.3, 0 }) seq.Add(Animated.Timing(n.Shake, Fx.Timing(k, 45)));
                Animated.Sequence(seq).Start();
                return;
            }
            OnPlay?.Invoke(lv);
        }

        /// <summary>Where level `lv`'s node is on screen (tests), or null when it's not on this page.</summary>
        public (float x, float y)? NodeAt(int lv)
        {
            int i = lv - 1 - _from;
            if (i < 0 || i >= _count) return null;
            return (_points[i].x - ScrollX, _points[i].y + Top);
        }
        public int Chapter => _chapter;
    }
}
