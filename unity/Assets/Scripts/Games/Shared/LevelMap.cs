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
        public LevelMap(IReadOnlyList<MapLevel> list, float width, float top, float height, IList<string> uris, Func<int, string> bannerOf, Func<int, MapIcon> iconOf = null)
        {
            _list = list; _n = list.Count; _width = width; _top = top; _H = (float)Math.Round(height);
            _uris = uris ?? new List<string>(); _bannerOf = bannerOf; _iconOf = iconOf;
            _anims = new NodeAnim[_n];
            for (int i = 0; i < _n; i++) _anims[i] = new NodeAnim();
            _hasIcon = new bool[_n];
            _points = new Point[_n];
            // a gentle wave about the middle line (a little above it: the stars hang under a beaten level)
            double amp = Math.Min(22, _H * 0.07), mid = _H * 0.5 - 10;
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

        string Mascot => _uris.Count > 0 ? _uris[(_cur * 11) % _uris.Count] : null;

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
            // the dots
            for (int i = 0; i < _n - 1; i++)
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
            // the signs: a picture over the banner, the two centred down the row's height (top -10)
            for (int i = 0; i < _n; i++)
            {
                if (_points[i].Sign == null) continue;
                float sw = _hasIcon[i] ? SIGN_W : SIGN_W_TEXT, x = _points[i].Sign.Value;
                if (!OnScreen(x, x + sw)) continue;
                var text = _bannerOf(i);
                var (lines, bw, bh) = MapArt.BannerBox(text, sw);
                var icon = _hasIcon[i] ? _iconOf(i) : null;
                float total = (icon != null ? icon.H + 8 : 0) + bh;
                float y = -10 + (_H - total) / 2;
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
                double s = t * PulseScale.Evaluate(A.Pulse != null ? A.Pulse.Value : 0);
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
        }

        // ---- touch (screen dp) -------------------------------------------------------------------------------------------
        int _downNode = -1;

        public void Down(float x, float y)
        {
            Scroll.Down(x, _tk?.Now ?? 0);
            _downNode = Scroll.NotATap ? -1 : NodeAt(x, y);
        }

        public void Move(float x, float y)
        {
            Scroll.Move(x, _tk?.Now ?? 0);
            if (Scroll.NotATap) _downNode = -1;
        }

        public void Up(float x, float y)
        {
            Scroll.Up(x, _tk?.Now ?? 0);
            int n = _downNode;
            _downNode = -1;
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
