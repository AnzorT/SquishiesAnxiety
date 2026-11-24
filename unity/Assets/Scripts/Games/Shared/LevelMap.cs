// The games' level map (src/sort/LevelMap.js, landscape): Squish Stack's, Squish Sort's (each container's) and Squish
// Hop's, each with its own levels and banners. The levels run left to right in a gentle wave along the middle of the
// scroll view, the page scrolling sideways:
//   a node per level     beaten (gold, its stars under it), the current one (orange, pulsing, a squishy's head bobbing
//                        beside it), locked (grey, a padlock); the dot on it is its tier
//   three dots           between two levels, gold up to the current one (none through a band's sign)
//   a sign per band      its banner (bannerOf), with a picture over it when iconOf draws one (Sort's containers, Hop's
//                        rooms), standing in the row before the band's first level
//   building             the nodes nearest the current one first: 12 at once, then 10 a frame (useProgressive); each
//                        springs in (friction 5, tension 150) |lv - current| x 45 ms late (at most 700)
//   opening              scrolled so the current level is in the middle (a setTimeout 0 after it's built)
//   scrolling            a finger drags it and flings it (MapScroll: Android's feel); a tap on a node plays it, on a
//                        locked one it shakes
// Pure C#: the clock is Ticker.Default (frames and timers), as the app's requestAnimationFrame / setTimeout; the tests
// (tools/unity/maps-test) run it frame by frame next to the app. Not copied: the sounds, the spark burst on a tap.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    /// <summary>A level on the map: its band (a banner opens each) and tier (0-3: its dot's colour).</summary>
    public struct MapLevel
    {
        public int Band, Tier;
        public MapLevel(int band, int tier) { Band = band; Tier = tier; }
    }

    /// <summary>A picture over a band's banner (iconOf): an SVG w x h.</summary>
    public sealed class MapIcon
    {
        public string Key, Markup;
        public float W, H, Margin = 4;
        /// <summary>`key`: the same key, the same picture (its texture isn't drawn again).</summary>
        public MapIcon(string key, string markup, float w, float h) { Key = key; Markup = markup; W = w; H = h; }
    }

    /// <summary>A map whose levels stand on a road painted into its background (develop: Squish Stack's forest,
    /// src/stack/ForestMap.js): the pictures (`Tiles`, Resources paths of JPEG bytes, shown in turn, each TileW x TileH
    /// units, scaled to the map's height), the levels' places along the road (`Nodes`, units), the bands' signs (`Signs`:
    /// x and the band's first level), the road's middle line (`RoadY`) and width, and the map's length.</summary>
    public sealed class MapForest
    {
        public string[] Tiles;
        public double TileW = 1000, TileH = 460, RoadW = 58, Width;
        public IReadOnlyList<double> Nodes;
        public IReadOnlyList<(double x, int i)> Signs;
        public Func<double, double> RoadY;
        /// <summary>The walker: the player's selected character's key (null: none) and its cut-out's height / width.</summary>
        public string Walker;
        public float WalkerAr;
        /// <summary>Set by Unity's creature code: whether a creature can walk the road live (else its cut-out stands).</summary>
        public static Func<string, bool> LiveWalker;
    }

    public sealed class LevelMap
    {
        // LevelMap.js's constants (landscape)
        const float GAP_X = 92, SIGN_W = 210, SIGN_W_TEXT = 150, SIGN_GAP = 50, NODE = MapArt.NODE;
        public static readonly string[] TIER_COLORS = { "#3ddc97", "#5fb8ff", "#ff8a4a", "#e01e4a" };

        readonly IReadOnlyList<MapLevel> _list;
        readonly Func<int, string> _bannerOf;      // by level index
        readonly Func<int, MapIcon> _iconOf;       // by level index (null: none)
        readonly IList<string> _uris;
        readonly float _width, _top, _H;
        readonly int _n;

        public Action<int> OnPlay;
        public readonly MapScroll Scroll = new MapScroll();
        public float ContentW { get; private set; }

        struct Point { public float X, Y; public float? Sign; }
        readonly Point[] _points;
        readonly bool[] _hasIcon;

        // the record
        int _cur;
        Func<int, int> _stars;   // a level's best (0: none)

        sealed class NodeAnim
        {
            public readonly AnimatedValue T = new AnimatedValue(0), Shake = new AnimatedValue(0);
            public KeyLoop Pulse, Bob;
            public double Delay = -1;
            public bool Mounted;
        }
        readonly NodeAnim[] _anims;
        int[] _order;
        int _built;
        bool _mounted;
        Ticker _tk;
        int _raf, _scrollTimer;
        static readonly Interpolator PulseScale = Fx.Lerp(new[] { 0.0, 1 }, new[] { 1, 1.08 });
        static readonly Interpolator ShakeX = Fx.Lerp(new[] { -1.0, 1 }, new[] { -6.0, 6 });
        static readonly Interpolator ShakeDeg = Fx.Lerp(new[] { -1.0, 1 }, new[] { -8.0, 8 });
        static readonly Interpolator BobY = Fx.Lerp(new[] { 0.0, 1 }, new[] { 0.0, -6 });

        /// <summary>`width`: the screen's (the map's) width; `top`, `height`: the scroll view's box on the screen (dp).</summary>
        readonly MapForest _forest;
        readonly float _k;   // a forest map: px per picture unit (its height / TileH)

        /// <summary>`roomOf` (develop, 2026-11-17: the map's background is the room its levels are played in): the room
        /// level i is played in, drawn behind the map (DrawRooms); `rowAt`: where the row's middle line runs, as a fraction
        /// of the map's height (lower over a room's floor: royal/WorldBg.js ROW_ON_FLOOR, 0.75).</summary>
        public LevelMap(IReadOnlyList<MapLevel> list, float width, float top, float height, IList<string> uris, Func<int, string> bannerOf, Func<int, MapIcon> iconOf = null, MapForest forest = null, Func<int, string> roomOf = null, float rowAt = 0.5f)
        {
            _list = list; _n = list.Count; _width = width; _top = top; _H = (float)Math.Round(height);
            _uris = uris ?? new List<string>(); _bannerOf = bannerOf; _iconOf = iconOf;
            _anims = new NodeAnim[_n];
            for (int i = 0; i < _n; i++) _anims[i] = new NodeAnim();
            _hasIcon = new bool[_n];
            _points = new Point[_n];
            _forest = forest;
            if (forest != null)
            {
                // the levels on the road (ForestMap.js: x * k, roadY(x) * k), the signs drawn by the road (Draw)
                _k = (float)(_H / forest.TileH);
                for (int i = 0; i < _n; i++) _points[i] = new Point { X = (float)(forest.Nodes[i] * _k), Y = (float)(forest.RoadY(forest.Nodes[i]) * _k) };
                ContentW = (float)(forest.Width * _k);
                Scroll.Max = Math.Max(0, ContentW - width);
                return;
            }
            // a gentle wave about the middle line (a little above it: the stars hang under a beaten level)
            _rowAt = rowAt;
            double amp = Math.Min(rowAt > 0.6 ? 14 : 22, _H * 0.07), mid = _H * rowAt - 10;
            double x = 0;
            for (int i = 0; i < _n; i++)
            {
                float? sign = null;
                if (i == 0 || list[i].Band != list[i - 1].Band)
                {
                    sign = i == 0 ? 20 : _points[i - 1].X + SIGN_GAP;
                    _hasIcon[i] = _iconOf != null && _iconOf(i) != null;
                    x = sign.Value + (_hasIcon[i] ? SIGN_W : SIGN_W_TEXT) + SIGN_GAP;
                }
                _points[i] = new Point { X = (float)x, Y = (float)(mid + JsMath.Sin(i * 1.05) * amp), Sign = sign };
                x += GAP_X;
            }
            ContentW = _points[_n - 1].X + 120;
            Scroll.Max = Math.Max(0, ContentW - width);
            // the rooms along the page: a room from where its first band starts (between the last band's last level and
            // the sign) to the next room's
            if (roomOf != null)
            {
                _rooms = new List<(string room, float x0, float x1)>();
                for (int i = 0; i < _n; i++)
                {
                    if (_points[i].Sign == null) continue;
                    string room = roomOf(i);
                    if (_rooms.Count > 0 && _rooms[_rooms.Count - 1].room == room) continue;
                    float x0 = i == 0 ? 0 : _points[i].Sign.Value - (SIGN_GAP - NODE / 2) / 2;
                    if (_rooms.Count > 0) { var l = _rooms[_rooms.Count - 1]; _rooms[_rooms.Count - 1] = (l.room, l.x0, x0); }
                    _rooms.Add((room, x0, 0));
                }
                var last = _rooms[_rooms.Count - 1];
                _rooms[_rooms.Count - 1] = (last.room, last.x0, Math.Max(ContentW, width));
            }
        }

        List<(string room, float x0, float x1)> _rooms;
        float _rowAt = 0.5f;
        public bool HasRooms => _rooms != null;
        const float POST_W = 16;

        /// <summary>royal/WorldBg.js RoomBackdrop: the rooms the levels are played in, behind the map and its header, a
        /// picture a screen wide (Room.js `full`, in daylight) repeated side by side for as long as its levels run, a
        /// wooden post where one room gives way to the next; moved by the map's scroll, faded with the map (not slid).
        /// Only the pictures about the screen are drawn.</summary>
        public void DrawRooms(LayerFrame f, float opacity, float screenH)
        {
            if (_rooms == null) return;
            double sx = Scroll.X, lo = sx - _width, hi = sx + 2 * _width;
            for (int j = 0; j < _rooms.Count; j++)
            {
                var (room, x0, x1) = _rooms[j];
                double from = x0 + Math.Max(0, Math.Floor((lo - x0) / _width)) * _width;
                for (double x = from; x < Math.Min(x1, hi); x += _width)
                {
                    float w = (float)Math.Min(_width, x1 - x);
                    var l = f.L($"map room {j} {x:0}");
                    l.Set(room + "|" + w, () => SquishSquad.Games.Squishdoku.Rooms.Svg(room, "day", _width, screenH, true, w), w, screenH, 0);
                    l.Transform = Affine.Translate(x - sx, 0);
                    l.Opacity = opacity;
                }
                if (j > 0 && x0 > lo - POST_W && x0 < hi + POST_W)
                {
                    var p = f.L("map room post " + j);
                    p.Set("post", () => new UiSvg(POST_W, screenH).Box(0, 0, POST_W, screenH, new BoxStyle { Background = "#7a4a22" }).Box(3, 0, POST_W - 6, screenH, new BoxStyle { Background = "#c7884a" }).Markup, POST_W, screenH, 0);
                    p.Transform = Affine.Translate(x0 - POST_W / 2 - sx, 0);
                    p.Opacity = opacity;
                }
            }
        }

        /// <summary>The player's record: the level they're on and each level's best stars (0 if none).</summary>
        public void SetRecord(int cur, Func<int, int> starsOf)
        {
            bool first = _stars == null;
            _cur = Math.Max(1, Math.Min(_n, cur));
            _stars = starsOf;
            var order = new int[_n];
            for (int i = 0; i < _n; i++) order[i] = i;
            int c = _cur;
            // (a stable sort: JS's Array.prototype.sort)
            _order = MergeSort(order, (a, b) => Math.Abs(a + 1 - c).CompareTo(Math.Abs(b + 1 - c)));
            if (!first && _mounted)
            {
                // the nodes re-render: a node whose delay changed springs again (to 1, where it is), the pulse follows
                // the current level
                for (int i = 0; i < _n; i++) if (_anims[i].Mounted) MountNode(i, false);
            }
        }

        static int[] MergeSort(int[] a, Comparison<int> cmp)
        {
            var l = new List<int>(a);
            var keyed = new List<(int v, int i)>();
            for (int i = 0; i < l.Count; i++) keyed.Add((l[i], i));
            keyed.Sort((x, y) => { int r = cmp(x.v, y.v); return r != 0 ? r : x.i.CompareTo(y.i); });
            var o = new int[a.Length];
            for (int i = 0; i < o.Length; i++) o[i] = keyed[i].v;
            return o;
        }

        string StateOf(int lv) => lv < _cur ? "done" : lv == _cur ? (_stars(lv) > 0 ? "done" : "current") : "locked";

        // (a forest map: no head by the current level; the app's walker, the selected character's live rig, stands there)
        string Mascot => _forest == null && _uris.Count > 0 ? _uris[(_cur * 11) % _uris.Count] : null;

        // ---- mounting: the first 12 nodes now, 10 more every frame, the scroll a timer later -------------------------
        public void Mount()
        {
            _tk = Ticker.Default;
            _mounted = true;
            _built = Math.Min(_n, 12);
            for (int k = 0; k < _built; k++) MountNode(_order[k], true);
            var p = _points[_cur - 1];
            _scrollTimer = _tk.SetTimeout(() => Scroll.ScrollTo(Math.Max(0, p.X - _width / 2)), 0);
            // the nodes round the current one pop in with rising bubbles
            for (int k = 0; k < 6; k++) Snd.Play("sd_nodePop", delay: 120 + k * 70, rate: 0.9 + k * 0.07);
            Grow();
        }

        void Grow()
        {
            if (_built >= _n) return;
            _raf = _tk.RequestAnimationFrame(() =>
            {
                int to = Math.Min(_n, _built + 10);
                for (int k = _built; k < to; k++) MountNode(_order[k], true);
                _built = to;
                Grow();
            });
        }

        public void Unmount()
        {
            if (_tk != null) { _tk.CancelAnimationFrame(_raf); _tk.ClearTimeout(_scrollTimer); }
            _mounted = false;
            foreach (var a in _anims) { a.Pulse?.Unmount(); a.Bob?.Unmount(); a.T.StopAnimation(); a.Shake.StopAnimation(); a.Mounted = false; a.Delay = -1; }
        }

        void MountNode(int i, bool fresh)
        {
            var A = _anims[i];
            int lv = i + 1;
            double delay = Math.Min(700, Math.Abs(lv - _cur) * 45);
            if (fresh || delay != A.Delay)
            {
                A.Delay = delay;
                Animated.Spring(A.T, Fx.Spring(1, 5, 150, delay)).Start();
            }
            A.Mounted = true;
            bool current = StateOf(lv) == "current";
            // the pulse: one loop while it's the current level; the head bobs beside it
            if (current && A.Pulse == null) { A.Pulse = new KeyLoop(1400, KeyLoop.PHASE, KeyLoop.UP_DOWN); A.Pulse.Mount(); }
            if (!current && A.Pulse != null) { A.Pulse.Unmount(); A.Pulse = null; }
            bool head = current && Mascot != null;
            if (head && A.Bob == null) { A.Bob = new KeyLoop(1400, KeyLoop.PHASE, KeyLoop.UP_DOWN); A.Bob.Mount(); }
            if (!head && A.Bob != null) { A.Bob.Unmount(); A.Bob = null; }
        }

        bool Built(int i) => _anims[i].Mounted;

        // ---- every frame ------------------------------------------------------------------------------------------------
        /// <summary>Adds the map's layers to `f` (prefix "map "): `view` is its view's transform (the slide), `opacity` its.</summary>
        public void Draw(LayerFrame f, Affine view, float opacity)
        {
            if (_tk != null) Scroll.Update(_tk.Now);
            var content = view * Affine.Translate(-Scroll.X, _top);
            double sx = Scroll.X;
            bool OnScreen(float x0, float x1) => x1 - sx > -40 && x0 - sx < _width + 40;
            if (_forest != null) DrawForest(f, content, opacity, OnScreen);
            // the dots
            for (int i = 0; _forest == null && i < _n - 1; i++)
            {
                if (!Built(i) || !Built(i + 1) || _points[i + 1].Sign != null) continue;
                var a = _points[i]; var b = _points[i + 1];
                if (!OnScreen(a.X, b.X)) continue;
                string color = i + 1 < _cur ? "#ffd23a" : "rgba(255,255,255,0.75)";
                var d = MapArt.Dots(a.X, a.Y, b.X, b.Y, color);
                var l = f.L("map dots " + i);
                l.Set(color, () => d.markup, d.w, d.h, 1);
                l.Transform = content * Affine.Translate(d.x0, d.y0);
                l.Opacity = opacity;
            }
            // the signs: a picture over the banner, the two centred on the row's middle line (H x rowAt - 10)
            for (int i = 0; _forest == null && i < _n; i++)
            {
                if (_points[i].Sign == null) continue;
                float sw = _hasIcon[i] ? SIGN_W : SIGN_W_TEXT, x = _points[i].Sign.Value;
                if (!OnScreen(x, x + sw)) continue;
                var text = _bannerOf(i);
                var (lines, bw, bh) = MapArt.BannerBox(text, sw);
                var icon = _hasIcon[i] ? _iconOf(i) : null;
                float total = (icon != null ? icon.H + 8 : 0) + bh;
                float y = _H * _rowAt - 10 - total / 2;
                if (icon != null)
                {
                    if (Built(i))
                    {
                        var il = f.L("map icon " + i);
                        il.Set(icon.Key, () => icon.Markup, icon.W, icon.H, icon.Margin);
                        il.Transform = content * Affine.Translate(x + (sw - icon.W) / 2, y);
                        il.Opacity = opacity;
                    }
                    y += icon.H + 8;
                }
                var bl = f.L("map banner " + i);
                bl.Set(text, () => MapArt.Banner(lines, bw, bh), bw, bh, 2);
                bl.Transform = content * Affine.Translate(x + (sw - bw) / 2, y);
                bl.Opacity = opacity;
            }
            // the nodes
            string mascot = Mascot;
            for (int i = 0; i < _n; i++)
            {
                if (!Built(i)) continue;
                var p = _points[i];
                if (!OnScreen(p.X - NODE / 2 - 50, p.X + NODE / 2 + 50)) continue;
                int lv = i + 1;
                string state = StateOf(lv);
                int stars = _stars(lv);
                var A = _anims[i];
                float h = MapArt.NodeH(state);
                double t = A.T.GetValue(), sh = A.Shake.GetValue();
                double s = t * PulseScale.Evaluate(A.Pulse != null ? A.Pulse.Value : 0) * (i == _heldNode ? 0.92 : 1);   // (held: it shrinks to 0.92, as every button does)
                var m = content * Affine.Translate(p.X - NODE / 2, p.Y - NODE / 2) * Fx.About(NODE, h, Affine.ScaleBy(s, s) * Affine.Translate(ShakeX.Evaluate(sh), 0) * Affine.Rotate(ShakeDeg.Evaluate(sh)));
                float op = opacity * (float)Math.Max(0, Math.Min(1, t));
                var l = f.L("map node " + lv);
                l.Set($"{state}|{stars}", () => MapArt.Node(lv, state, stars, TIER_COLORS[Math.Max(0, Math.Min(3, _list[i].Tier))]), NODE, h, 8);
                l.Transform = m; l.Opacity = op;
                if (state == "current" && mascot != null)
                {
                    // (mascotLeft: the head sits left of the node, right: NODE + 6, unless a sign stands there)
                    float mx = p.Sign == null ? NODE - (NODE + 6) - 40 : NODE + 6;
                    var hl = f.L("map head");
                    hl.Set(mascot, () => MapArt.Head(40, mascot), 40, 40, 2);
                    hl.Transform = m * Affine.Translate(mx, 8 + BobY.Evaluate(A.Bob != null ? A.Bob.Value : 0));
                    hl.Opacity = op;
                }
            }
            if (_forest != null && _forest.Walker != null) DrawWalker(f, content, opacity, OnScreen);
        }

        // ---- the walker (ForestMap.js) ----------------------------------------------------------------------------------
        // The player's selected character stands on the next level to play and, back on the map after beating it, walks
        // the road to the new one while the map follows (too far, back down, or never drawn: just there). Live: the
        // rig turned side-on, its own gait, turned back, a happy bounce (rig/walk.html); without the live creatures (the
        // tests, a creature not recorded) its cut-out stands there.
        const float W_BODY = 52, ON_ROAD = 6, ON_NODE = NODE / 2 - 8;
        const double TURN = 300;
        static readonly Func<double, double> WalkEase = Easing.Bezier(0.3, 0, 0.7, 1);
        int _stand = -1, _walkTo;
        double _seenAt = -1, _walkT0 = -1, _walkMs;
        List<(float x, float y)> _walkPts;
        CardCreature _walker;
        bool _walkerLive;

        static float Smooth(float u) => u * u * (3 - 2 * u);
        // its feet at road place x (picture units): stepping down off a level onto the road and up onto the next
        (float x, float y) Feet(double x)
        {
            double d = double.MaxValue;
            foreach (var nx in _forest.Nodes) d = Math.Min(d, Math.Abs(nx - x));
            float u = (float)Math.Max(0, 1 - d * _k / (NODE * 0.75));
            return ((float)(x * _k), (float)(_forest.RoadY(x) * _k - (ON_ROAD + (ON_NODE - ON_ROAD) * Smooth(u))));
        }

        void DrawWalker(LayerFrame f, Affine content, float opacity, Func<float, float, bool> onScreen)
        {
            var F = _forest;
            double now = _tk != null ? _tk.Now : 0;
            int target = _cur - 1;
            if (_walker == null || _walker.Key != F.Walker)
            {
                _walkerLive = MapForest.LiveWalker != null && MapForest.LiveWalker(F.Walker);
                _walker = new CardCreature { Key = F.Walker, Kind = "walk", State = "idle" };
                _stand = target; _walkT0 = -1;
            }
            if (_stand < 0) _stand = target;
            // back with the next level further on: walk there 650 ms after the map shows
            if (_walkT0 < 0 && _stand != target)
            {
                bool far = target < _stand || target - _stand > 6 || !_walkerLive;
                if (_seenAt < 0) _seenAt = now;
                if (far) _stand = target;
                else if (now - _seenAt >= 650)
                {
                    double x0 = F.Nodes[_stand], x1 = F.Nodes[target];
                    _walkMs = Math.Round(Math.Min(4200, Math.Max(1100, Math.Abs(x1 - x0) * _k / 0.11)));
                    int n = Math.Max(2, (int)Math.Ceiling(Math.Abs(x1 - x0) / 10) + 1);
                    _walkPts = new List<(float, float)>();
                    for (int i = 0; i < n; i++) _walkPts.Add(Feet(x0 + (x1 - x0) * i / (n - 1)));
                    _walkTo = target; _walkT0 = now;
                    _walker.WalkSpin = x1 > x0 ? 90 : -90;
                    // the camera: both ends on screen when they fit, else from where it starts
                    double X0 = x0 * _k, X1 = x1 * _k;
                    Scroll.ScrollTo(Math.Abs(X1 - X0) < _width - 160 ? (X0 + X1) / 2 - _width / 2 : X1 > X0 ? X0 - 100 : X0 - _width + 100);
                }
            }
            if (_walkT0 < 0) _seenAt = _stand == target ? -1 : _seenAt;
            // where it is: on its level, or along the road (the steps start once it has turned)
            (float x, float y) at = Feet(F.Nodes[Math.Min(_stand, _n - 1)]);
            if (_walkT0 >= 0)
            {
                double t = now - _walkT0, u = Math.Max(0, Math.Min(1, (t - TURN) / _walkMs)), e = WalkEase(u);
                double pos = e * (_walkPts.Count - 1);
                int i0 = Math.Min(_walkPts.Count - 2, (int)Math.Floor(pos));
                double fr = pos - i0;
                at = ((float)(_walkPts[i0].x + (_walkPts[i0 + 1].x - _walkPts[i0].x) * fr), (float)(_walkPts[i0].y + (_walkPts[i0 + 1].y - _walkPts[i0].y) * fr));
                // walk.html: turn side-on (TURN), walk its gait, turn back (TURN + 40), then a happy bounce
                double turnIn = Math.Min(1, t / TURN), walkT = (t - TURN) / _walkMs, back = Math.Max(0, Math.Min(1, (t - TURN - _walkMs) / (TURN + 40)));
                _walker.Yaw = _walker.WalkSpin * (back > 0 ? 1 - back : turnIn);
                _walker.Walk = walkT < 0 || walkT >= 1 ? 0 : Math.Max(0, Math.Min(1, Math.Min(walkT / 0.08, (1 - walkT) / 0.1)));
                // the camera follows a long walk on toward where it's going
                if (t >= TURN + _walkMs * 0.45 && Math.Abs(_walkPts[_walkPts.Count - 1].x - _walkPts[0].x) >= _width - 160)
                {
                    float X1 = _walkPts[_walkPts.Count - 1].x;
                    Scroll.ScrollTo(_walker.WalkSpin > 0 ? X1 - _width + 120 : X1 - 120);
                }
                if (t >= TURN + _walkMs)
                {
                    _stand = _walkTo;
                    if (back >= 1) { _walkT0 = -1; _walker.Yaw = 0; _walker.Walk = 0; _walker.State = "happy"; }
                }
            }
            if (!onScreen(at.x - 70, at.x + 70)) return;
            if (_walkerLive)
            {
                // its body W_BODY dp wide (a tall one by its height), its feet on the road
                var b = _walker.Body;
                var l = f.L("map walker");
                l.Creature = _walker;
                l.Opacity = opacity;
                if (b == null) { l.Opacity = 0; return; }
                double k = W_BODY / Math.Max(b.Bw, b.Bh * 0.8);
                _walker.Unit = (float)k;
                l.Transform = content * Affine.Translate(at.x - b.Cx * k, at.y - b.Gy * k) * Affine.ScaleBy(k, k);
                if (_walker.Failed) _walkerLive = false;
                return;
            }
            // (its cut-out, the body W_BODY wide)
            float ar = F.WalkerAr > 0 ? F.WalkerAr : 1, w = (float)Math.Min(W_BODY, W_BODY * 1.25 / ar), h = w * ar;
            var still = f.L("map walker still");
            still.SetPicture("Stack/art/" + F.Walker, w, h);
            still.Transform = content * Affine.Translate(at.x - w / 2, at.y - h);
            still.Opacity = opacity;
        }

        // ---- the forest (ForestMap.js) --------------------------------------------------------------------------------
        const float FSIGN_W = 136, FSIGN_H = 70;
        static readonly TextStyle SignText = new TextStyle { Font = MapArt.Display, Size = 12, LineHeight = 15, LetterSpacing = 1.2f, Color = "#ffffff" };

        void DrawForest(LayerFrame f, Affine content, float opacity, Func<float, float, bool> onScreen)
        {
            var F = _forest;
            // the pictures side by side, the whole height (each 1 px wider: no hairline between them)
            double tileW = F.TileW * _k;
            for (int i = 0; i * tileW < ContentW; i++)
            {
                float x = (float)Math.Floor(i * tileW), w = (float)Math.Ceiling(tileW) + 1;
                if (!onScreen(x, x + w)) continue;
                var l = f.L("map tile " + i);
                l.SetPicture(F.Tiles[i % F.Tiles.Length], w, _H);
                l.Transform = content * Affine.Translate(x, 0);
                l.Opacity = opacity;
            }
            // a band's wooden sign on the road's far edge
            foreach (var (sx, si) in F.Signs)
            {
                float cx = (float)(sx * _k), y = (float)((F.RoadY(sx) - F.RoadW / 2) * _k + 6);
                if (!onScreen(cx - FSIGN_W / 2, cx + FSIGN_W / 2)) continue;
                var text = _bannerOf(si);
                var l = f.L("map sign " + si);
                l.Set(text, () => WoodSign(text), FSIGN_W, FSIGN_H, 6);
                l.Transform = content * Affine.Translate(cx - FSIGN_W / 2, y - FSIGN_H);
                l.Opacity = opacity;
            }
        }

        /// <summary>ForestMap.js Sign: in a 136 x 70 box, at its bottom: the board (#b8641c, a 2.5 dp cream border, radius 10,
        /// 10 x 3 in, its text's two halves on two lines) on two posts (6 x 16, 44 dp apart).</summary>
        static string WoodSign(string text)
        {
            var parts = text.Split(new[] { " · " }, StringSplitOptions.None);
            float lh = 15, tw = 0;
            foreach (var t in parts) tw = Math.Max(tw, UiSvg.BoxWidth(t, SignText));
            float bw = tw + 2 * 10 + 5, bh = parts.Length * lh + 2 * 3 + 5;
            float by = FSIGN_H - 16 - bh, bx = (FSIGN_W - bw) / 2;
            var s = new UiSvg(FSIGN_W, FSIGN_H);
            // the posts (borderLeft / borderRight 1.5 #4a2a10)
            float px = (FSIGN_W - (6 + 44 + 6)) / 2;
            foreach (var x in new[] { px, px + 50 })
            {
                s.Box(x, FSIGN_H - 16, 6, 16, new BoxStyle { Background = "#4a2a10" });
                s.Box(x + 1.5f, FSIGN_H - 16, 3, 16, new BoxStyle { Background = "#7a4a22" });
            }
            s.Box(bx, by, bw, bh, new BoxStyle { Background = "#b8641c", Radius = 10, BorderWidth = 2.5f, BorderColor = "#fff3dc", Shadows = new[] { new Shadow("rgba(42,22,8,0.35)", 0, 2, 3) } });
            for (int i = 0; i < parts.Length; i++) s.Text(parts[i], bx + 12.5f, by + 2.5f + 3 + i * lh, SignText, tw, 0.5f);
            return s.Markup;
        }

        // ---- touch (screen dp) -------------------------------------------------------------------------------------------
        int _downNode = -1, _heldNode = -1;   // the node the press began on; the one drawn held (the finger still on it)

        public void Down(float x, float y)
        {
            Scroll.Down(x, _tk?.Now ?? 0);
            _heldNode = _downNode = Scroll.NotATap ? -1 : NodeAt(x, y);
        }

        public void Move(float x, float y)
        {
            Scroll.Move(x, _tk?.Now ?? 0);
            if (Scroll.NotATap) _downNode = -1;
            _heldNode = _downNode >= 0 && NodeAt(x, y) == _downNode ? _downNode : -1;
        }

        public void Up(float x, float y)
        {
            Scroll.Up(x, _tk?.Now ?? 0);
            int n = _downNode;
            _downNode = _heldNode = -1;
            if (n < 0 || Scroll.NotATap || NodeAt(x, y) != n) return;
            Press(n);
        }

        // a node's Pressable: its 60 x 60, hitSlop 8; the last drawn on top
        int NodeAt(float x, float y)
        {
            double cx = x + Scroll.X, cy = y - _top;
            for (int i = _n - 1; i >= 0; i--)
            {
                if (!Built(i)) continue;
                var p = _points[i];
                if (Math.Abs(cx - p.X) <= NODE / 2 + 8 && Math.Abs(cy - p.Y) <= NODE / 2 + 8) return i;
            }
            return -1;
        }

        public void Press(int i)
        {
            int lv = i + 1;
            if (StateOf(lv) == "locked")
            {
                Snd.Play("sd_locked");
                var A = _anims[i];
                A.Shake.SetValue(0);
                var steps = new List<CompositeAnimation>();
                foreach (var k in new[] { 1, -1, 0.7, -0.7, 0.3, 0 }) steps.Add(Animated.Timing(A.Shake, Fx.Timing(k, 45)));
                Animated.Sequence(steps).Start();
                return;
            }
            Snd.Play("sd_select");
            OnPlay?.Invoke(lv);
        }

        /// <summary>Where level `lv`'s node is on the screen now (tests).</summary>
        public (float x, float y) NodeCenter(int lv) => ((float)(_points[lv - 1].X - Scroll.X), _top + _points[lv - 1].Y);
    }
}
