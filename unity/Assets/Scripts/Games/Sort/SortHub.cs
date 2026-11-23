// Squish Sort's screen for GameScreen (src/screens/SortScreen.js) and its hub (src/sort/Hub.js, landscape): the title,
// the line about the game, BLITZ and HOW TO PLAY on the left; a card per container on the right (the Snack Fridge and
// the Toy Cupboard), each with the fridge or cupboard the player is up to, its doors opening and shutting forever with
// squishies inside, its level and stars, and PLAY (its own 50-level map). Each container has its own record and map:
// a banner per fridge (its picture over it) and per shelf it gains.
// MiniContainer (sort/Container.js): a container drawn full size and shrunk to fit; shut for good on the map.
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Games.Shared;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Sort
{
    public sealed class SortDef : GameDef
    {
        readonly IDictionary<string, object> _profile;
        public string ThemeKey = "fridge";
        public SortDef(IDictionary<string, object> profile) { _profile = profile; }
        SortRecord Rec => Levels.Record(_profile);
        public override string Id => "sort";
        public override string Theme => ThemeKey;
        public override string Title => SortModels.THEMES[ThemeKey].Name.ToUpperInvariant();
        public override string TitleColor => SortModels.THEMES[ThemeKey].Ring;
        public override string Sub => $"{(int)Levels.DoneIn(Rec, ThemeKey)} / {Levels.LEVELS} levels";
        public override string Stars => ((int)Levels.StarsIn(Rec, ThemeKey)).ToString();
        public override bool Seen => Rec.Seen;
        public override void MarkSeen()
        {
            if (!(_profile.TryGetValue("sort", out var v) && v is IDictionary<string, object> d)) _profile["sort"] = d = new Dictionary<string, object>();
            d["seen"] = true;
            SortSave.Record(new Dictionary<string, object> { { "sort.seen", true } });   // SortScreen.js
        }

        public static List<string> Pool(string theme) => HubsData.Arts(theme == "cupboard" ? HubsData.Current.sortPools.cupboard : HubsData.Current.sortPools.fridge);
        static string ShelvesOf(int n) => $"{n} {(n > 1 ? "SHELVES" : "SHELF")}";

        public override LevelMap NewMap(float w, float top, float h)
        {
            string theme = ThemeKey;
            var list = new List<MapLevel>();
            foreach (var l in Levels.LEVEL_LIST) list.Add(new MapLevel(l.Band, l.Tier));
            var icons = new Dictionary<int, MapIcon>();
            MapIcon Icon(int i)
            {
                var L = Levels.LEVEL_LIST[i];
                if (!L.First) return null;
                if (!icons.TryGetValue(i, out var ic)) icons[i] = ic = MiniContainer.Still(theme, L.Model, L.Rows, L.Cols, 84);
                return ic;
            }
            string Banner(int i)
            {
                var L = Levels.LEVEL_LIST[i];
                var m = SortModels.ModelOf(theme, L.Model);
                return L.First ? $"{m.Size}\n{m.Name.ToUpperInvariant()}" : $"+1 SHELF · {ShelvesOf(L.Rows)}";
            }
            var map = new LevelMap(list, w, top, h, Pool(theme), Banner, Icon);
            Refresh(map);
            return map;
        }

        public override void Refresh(LevelMap map)
        {
            var t = Rec.Of(ThemeKey);
            map.SetRecord((int)t.Lv, lv => (int)JsMath.OrNum(JsMath.Get(t.Best, JsMath.Key(lv)), 0));
        }

        public override Hub NewHub(GameScreen screen) => new SortHub(this, _profile, screen);
    }

    /// <summary>sort/Container.js MiniContainer: `m` with `rows` x `cols` shelves drawn full size (S 64) and shrunk to
    /// `size` wide (1.3 x that high at most); with a door (0 shut … 1 open to 90°) it shows its inside and squishies.</summary>
    public sealed class MiniContainer
    {
        public readonly SortModel M;
        public readonly ContainerGeo G;
        public readonly float K, W, H;
        readonly string _theme;
        readonly int _model, _rows;

        public MiniContainer(string theme, int model, int rows, int cols, float size)
        {
            _theme = theme; _model = model; _rows = rows;
            M = SortModels.ModelOf(theme, model);
            int C = cols > 0 ? cols : (M.Doors == 2 ? 4 : 3);
            G = SortGeometry.Sizes(M, rows, C, 64);
            G.Deg = 90;
            K = Math.Min(size / G.BodyW, size * 1.3f / (G.BodyH + G.Feet));
            W = G.BodyW * K; H = (G.BodyH + G.Feet) * K;
        }

        /// <summary>Shut for good (the map's picture): the body and its doors, one SVG W x H.</summary>
        public static MapIcon Still(string theme, int model, int rows, int cols, float size)
        {
            var c = new MiniContainer(theme, model, rows, cols, size);
            var s = new UiSvg(c.W, c.H);
            string k = UiSvg.F(c.K);
            s.Raw(Nest.Svg(SortArt.Body(c.M, c.G), "b", 0, 0, $"scale({k})"));
            for (int i = 0; i < c.M.Doors; i++)
            {
                var (dx, dy, dw, dh, hinge) = SortArt.DoorBox(c.M, c.G, i);
                s.Raw(Nest.Svg(SortArt.DoorFront(c.M, i, hinge, dw, dh), "d" + i, dx * c.K, dy * c.K, $"scale({k})"));
            }
            return new MapIcon($"{theme}|{model}|{rows}|{cols}", s.Markup, c.W, c.H);
        }

        /// <summary>Its layers (prefix `name`) at `at` (its box's top-left on screen): open by `door`, `uris` inside.</summary>
        public void Draw(LayerFrame f, string name, Affine at, float opacity, double door, IList<string> uris)
        {
            var g = G;
            string key = $"{_theme}|{_model}|{_rows}|{g.Cols}";
            var mini = at * Affine.ScaleBy(K, K);
            var body = f.L(name + " body"); body.Set(key, () => SortArt.Body(M, g), g.BodyW, g.BodyH + g.Feet, 4); body.Transform = mini; body.Opacity = opacity;
            var inside = mini * Affine.Translate(SortArt.InsideX, SortArt.InsideY(g));
            float hd = g.H + g.Crisper;
            var ib = f.L(name + " inside back"); ib.Set(key, () => SortArt.InsideBack(M, g), g.W, hd, 1); ib.Transform = inside; ib.Opacity = opacity;
            var lamp = f.L(name + " lamp"); lamp.Set(key, () => SortArt.Lamp(M, g), g.W, hd, 1); lamp.Transform = inside; lamp.Opacity = opacity;
            var inf = f.L(name + " inside front"); inf.Set(key, () => SortArt.InsideFront(M, g), g.W, hd, 1); inf.Transform = inside; inf.Opacity = opacity;
            int C = g.Cols;
            var spots = new[] { 0, C - 1, C + 1 };
            for (int i = 0; i < Math.Min(3, uris.Count); i++)
            {
                if (uris[i] == null) continue;
                int sp = spots[i] % (_rows * C);
                var p = f.L(name + " squishy " + i);
                p.SetPicture(uris[i], g.S - 12, g.S - 12);
                p.Transform = inside * Affine.Translate((sp % C) * g.S + 6, (sp / C) * (g.S + SortGeometry.SHELF) + 6);
                p.Opacity = opacity;
            }
            // the doors: the front until the door has turned 90°, then its inside
            for (int i = 0; i < M.Doors; i++)
            {
                var (dx, dy, dw, dh, hinge) = SortArt.DoorBox(M, g, i);
                double sign = hinge == "left" ? -1 : 1;
                double fcut = Math.Min(0.998, 90 / g.Deg);
                double frontOp = door <= fcut ? 1 : door >= fcut + 0.001 ? 0 : 1 - (door - fcut) / 0.001;
                var view = new DoorView { W = dw, H = dh, Sign = (float)sign, Persp = g.Persp, Deg = door * sign * g.Deg, Post = mini * Affine.Translate(dx, dy) };
                int di = i;
                var fr = f.L(name + " door front " + i); fr.Set(key, () => SortArt.DoorFront(M, di, hinge, dw, dh), dw, dh, 2); fr.Door = view; fr.Opacity = opacity * (float)frontOp; fr.Visible = frontOp > 0;
                var bk = f.L(name + " door back " + i); bk.Set(key, () => SortArt.DoorBack(M, dw, dh), dw, dh, 2); bk.Door = view; bk.Opacity = opacity * (float)(1 - frontOp); bk.Visible = frontOp < 1;
            }
        }
    }

    /// <summary>Hub.js useDoorLoop: the doors open, stay, shut, rattle and open again, forever.</summary>
    public sealed class DoorLoop
    {
        public readonly AnimatedValue Door = new AnimatedValue(1), Wob = new AnimatedValue(0);
        CompositeAnimation _loop;
        static readonly Interpolator Deg = Fx.Lerp(new[] { -1.0, 1 }, new[] { -5.0, 5 });

        public void Mount()
        {
            CompositeAnimation T(double v, double ms, Func<double, double> ease = null, AnimatedValue val = null) =>
                Animated.Timing(val ?? Door, Fx.Timing(v, ms, ease ?? Easing.InOut(Easing.Quad)));
            var rattle = new List<CompositeAnimation>();
            foreach (var v in new[] { 1.0, -1, 1, -1, 0 }) rattle.Add(T(v, 90, Easing.InOut(Easing.Quad), Wob));
            _loop = Animated.Loop(Animated.Sequence(T(1, 1400), T(0, 380, Easing.In(Easing.Quad)), Animated.Sequence(rattle), T(0, 200), T(1, 420, Easing.Out(Easing.Back(1.4)))));
            _loop.Start();
        }

        public void Unmount() { _loop?.Stop(); _loop = null; }
        public double Rotate => Deg.Evaluate(Wob.GetValue());
    }

    public sealed class SortHub : Hub
    {
        readonly IDictionary<string, object> _profile;
        readonly GameScreen _screen;
        readonly SortDef _def;
        FlexNode _titleN, _taglineN, _rulesN;
        CardArt.Title _title;
        Para _tagline;
        ModeCard _blitz;
        HubButton _rules;
        readonly PopIn _titlePop = new PopIn(60, 0.3, -10), _taglinePop = new PopIn(220);
        readonly SlideIn _rulesSlide = new SlideIn(640, 30);
        readonly Rock _titleRock = new Rock(2, 3400);
        readonly List<ThemeCard> _cards = new List<ThemeCard>();
        static readonly TextStyle Tagline = new TextStyle { Font = MapArt.Heavy, Size = 13, Color = MapArt.INK, LineHeight = 18 };

        public SortHub(SortDef def, IDictionary<string, object> profile, GameScreen screen) { _def = def; _profile = profile; _screen = screen; }

        public override IEnumerable<HubButton> Buttons
        {
            get { yield return _blitz.Cta; yield return _rules; foreach (var c in _cards) yield return c.Play; }
        }

        public override void Build(float w, float top, float h)
        {
            var rec = Levels.Record(_profile);
            var root = new FlexNode("hub").Size(w, h).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).PadH(24).Padding(YGEdge.Bottom, 10).Gap(28);
            var col1 = root.Add(new FlexNode("col1").Width(350).AlignItems(YGAlign.Center).Gap(12));
            _title = new CardArt.Title("SQUISH SORT", 36, "gold");
            _titleN = col1.Add(new FlexNode("title").Size(_title.W, _title.H));
            _tagline = new Para("Remember who sits where.\nThe doors shut, it shakes… sort them back!", Tagline, 0.5f);
            _taglineN = col1.Add(_tagline.Leaf("tagline"));
            var b = rec.Blitz;
            double reached = b.Reached ?? 0, wins = b.Wins ?? 0;
            _blitz = new ModeCard("hub blitz", "blitz", "BLITZ ⚡",
                new[] { $"{Levels.BLITZ_ROUNDS} rounds · {Levels.Clock(Levels.BLITZ_MS)} · fridge & cupboard", "1 mistake = back to round 1",
                    reached > 0 ? $"Best: round {reached}{(wins > 0 ? $" · {wins} win{(wins > 1 ? "s" : "")}" : "")}" : "No runs yet" }, 540,
                () => _screen.OnBlitz?.Invoke(null));
            col1.Add(_blitz.Build());
            _rules = HubButton.Drawn("hub rules", new CardArt.ButtonLook("white", "HOW TO PLAY", 14, 16, 8), () => _screen.ShowRules(true));
            _rulesN = col1.Add(new FlexNode("rules").Size(_rules.W, _rules.H));
            var col2 = root.Add(new FlexNode("col2").Width(350).AlignItems(YGAlign.Center).Gap(12));
            int i = 0;
            foreach (var k in new[] { "fridge", "cupboard" })
            {
                var pool = SortDef.Pool(k);
                var uris = pool.GetRange(Math.Min(pool.Count, i * 3), Math.Max(0, Math.Min(3, pool.Count - i * 3)));
                string key = k;
                var card = new ThemeCard(k, rec, uris, 300 + i * 120, () => { _def.ThemeKey = key; _screen.Go("map"); });
                _cards.Add(card);
                col2.Add(card.Build());
                i++;
            }
            root.Layout(w, h);
            root.Offset(0, top);
        }

        public override void Mount()
        {
            _titlePop.Trigger(); _taglinePop.Trigger(); _rulesSlide.Trigger(); _titleRock.Mount();
            _blitz.Mount();
            foreach (var c in _cards) c.Mount();
        }

        public override void Unmount()
        {
            _titlePop.Stop(); _taglinePop.Stop(); _rulesSlide.Stop(); _titleRock.Unmount();
            _blitz.Unmount();
            foreach (var c in _cards) c.Unmount();
        }

        public override void Draw(LayerFrame f, Affine view, float opacity)
        {
            var t = f.L("hub title");
            var tf = _titleN.Frame;
            t.Set("title", _title.Markup, tf.W, tf.H, 8);
            t.Transform = view * Affine.Translate(tf.X, tf.Y) * _titlePop.Local(tf.W, tf.H) * _titleRock.Local(tf.W, tf.H);
            t.Opacity = opacity * _titlePop.Opacity;
            var g = f.L("hub tagline");
            var gf = _taglineN.Frame;
            g.Set("tagline", () => { var s = new UiSvg(gf.W, gf.H); _tagline.Draw(s, 0, 0, gf.W); return s.Markup; }, gf.W, gf.H, 2);
            g.Transform = view * Affine.Translate(gf.X, gf.Y) * _taglinePop.Local(gf.W, gf.H);
            g.Opacity = opacity * _taglinePop.Opacity;
            _blitz.Draw(f, view, opacity);
            var rf = _rulesN.Frame;
            _rules.Draw(f, view * Affine.Translate(rf.X, rf.Y) * _rulesSlide.Local, opacity * _rulesSlide.Opacity);
            foreach (var c in _cards) c.Draw(f, view, opacity);
        }

        /// <summary>Hub.js ThemeCard (landscape: the shorter card, no blurb).</summary>
        sealed class ThemeCard
        {
            readonly string _k;
            readonly SlideIn _slide;
            readonly DoorLoop _doors = new DoorLoop();
            readonly MiniContainer _mini;
            readonly IList<string> _uris;
            public readonly HubButton Play;
            readonly string _ring, _name, _modelLine, _chip, _stars;
            readonly string[] _colors;
            FlexNode _wrap, _face, _miniN, _titleN, _modelN, _chipN, _chipText, _starsN, _playN;
            static readonly TextStyle Model = new TextStyle { Font = MapArt.Display, Size = 11, LetterSpacing = 0.6f };
            static readonly TextStyle Chip = new TextStyle { Font = MapArt.Display, Size = 11, LetterSpacing = 0.6f, Color = "#ffffff" };
            static readonly TextStyle StarsText = new TextStyle { Font = MapArt.Display, Size = 14, Color = "#b86200" };

            public ThemeCard(string k, SortRecord rec, IList<string> uris, double delay, Action onPlay)
            {
                _k = k; _uris = uris;
                _slide = new SlideIn(delay, 50);
                bool fridge = k == "fridge";
                _ring = fridge ? "#1f5f7a" : "#6a3a12";
                _colors = fridge ? new[] { "#f0fbff", "#bfe9fb", "#7fd0f0" } : new[] { "#fff6e6", "#ffd9a8", "#f0a860" };
                var t = rec.Of(k);
                int lv = (int)t.Lv;
                var L = Levels.LEVEL_LIST[Math.Max(0, Math.Min(Levels.LEVELS, lv) - 1)];
                var m = SortModels.ModelOf(k, L.Model);
                _mini = new MiniContainer(k, L.Model, Math.Min(3, L.Rows), L.Cols, 74);
                _name = SortModels.THEMES[k].Name.ToUpperInvariant();
                _modelLine = $"{m.Size} · {m.Name.ToUpperInvariant()}";
                _chip = $"LEVEL {lv}/{Levels.LEVELS}";
                _stars = $"★ {(int)Levels.StarsIn(rec, k)}";
                Play = HubButton.Drawn("hub play " + k, new CardArt.ButtonLook("green", "PLAY ▶", 17, 18, 6), onPlay).Pulsing(1.05, 1300);
            }

            TextStyle TitleStyle => new TextStyle { Font = MapArt.Display, Size = 22, LetterSpacing = 0.8f, Color = _ring };
            TextStyle ModelStyle => new TextStyle { Font = Model.Font, Size = Model.Size, LetterSpacing = Model.LetterSpacing, Color = _ring };

            public FlexNode Build()
            {
                _wrap = new FlexNode("card " + _k).AlignSelf(YGAlign.Stretch);
                var ring = _wrap.Add(new FlexNode("ring").Padding(2.5f).Padding(YGEdge.Bottom, 7));
                _face = ring.Add(new FlexNode("face").Row().AlignItems(YGAlign.Center).PadH(14).PadV(8).Gap(12).Border(3));
                _miniN = _face.Add(new FlexNode("mini").Size(_mini.W, _mini.H));
                var body = _face.Add(new FlexNode("body").Flex(1).Gap(2));
                _titleN = body.Add(new Para(_name, TitleStyle).Leaf("title"));
                _modelN = body.Add(new Para(_modelLine, ModelStyle).Leaf("model"));
                var row = body.Add(new FlexNode("row6").Row().AlignItems(YGAlign.Center).Gap(6).Margin(YGEdge.Top, 2));
                _chipN = row.Add(new FlexNode("chip").PadH(8).PadV(2).Border(2));
                _chipText = _chipN.Add(new Para(_chip, Chip).Leaf("chipText"));
                _starsN = row.Add(new Para(_stars, StarsText).Leaf("stars"));
                _playN = body.Add(new FlexNode("play").Size(Play.W, Play.H).AlignSelf(YGAlign.FlexStart).Margin(YGEdge.Top, 4));
                return _wrap;
            }

            public void Mount() { _slide.Trigger(); _doors.Mount(); Play.Mount(); }
            public void Unmount() { _slide.Stop(); _doors.Unmount(); Play.Unmount(); }

            string Markup()
            {
                var w = _wrap.Frame;
                float ox = w.X, oy = w.Y;
                var s = new UiSvg(w.W, w.H);
                s.Box(0, 0, w.W, w.H, new BoxStyle { Background = _ring, Radius = 26 });
                var fc = _face.Frame;
                float fx = fc.X - ox, fy = fc.Y - oy, b = FlexNode.Bw(3);
                s.Box(fx, fy, fc.W, fc.H, new BoxStyle { Background = "#ffffff", Radius = 23.5f });
                float px = fx + b, py = fy + b, pw = fc.W - 2 * b, ph = fc.H - 2 * b, r = 23.5f - b;
                s.Box(px, py, pw, ph, new BoxStyle { Gradient = _colors, GradientStops = new[] { 0f, 0.55f, 1 }, Radius = r });
                var clip = s.NewId("tc");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(px, py, pw, ph, new[] { r, r, r, r })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                s.Box(px + 14, py + 3, pw - 28, ph * 0.3f, new BoxStyle { Background = "rgba(255,255,255,0.4)", Radius = 20 });
                s.Close();
                new Para(_name, TitleStyle).Draw(s, _titleN.Frame.X - ox, _titleN.Frame.Y - oy, _titleN.Frame.W);
                new Para(_modelLine, ModelStyle).Draw(s, _modelN.Frame.X - ox, _modelN.Frame.Y - oy, _modelN.Frame.W);
                var c = _chipN.Frame;
                s.Box(c.X - ox, c.Y - oy, c.W, c.H, new BoxStyle { Background = _ring, Radius = 999, BorderWidth = FlexNode.Bw(2), BorderColor = "#ffffff" });
                new Para(_chip, Chip).Draw(s, _chipText.Frame.X - ox, _chipText.Frame.Y - oy, _chipText.Frame.W);
                new Para(_stars, StarsText).Draw(s, _starsN.Frame.X - ox, _starsN.Frame.Y - oy, _starsN.Frame.W);
                return s.Markup;
            }

            public void Draw(LayerFrame f, Affine view, float opacity)
            {
                var w = _wrap.Frame;
                var at = view * Affine.Translate(w.X, w.Y) * _slide.Local;
                float op = opacity * _slide.Opacity;
                var l = f.L("hub card " + _k);
                l.Set(_chip + _stars, Markup, w.W, w.H, 4);
                l.Transform = at; l.Opacity = op;
                var mf = _miniN.Frame;
                // the container rattles about its middle (rotate ±5°) inside the card, clipped by it (not copied: the clip)
                var mat = at * Affine.Translate(mf.X - w.X, mf.Y - w.Y) * Fx.About(mf.W, mf.H, Affine.Rotate(_doors.Rotate));
                _mini.Draw(f, "hub mini " + _k, mat, op, _doors.Door.GetValue(), _uris);
                Play.Draw(f, at * Affine.Translate(_playN.Frame.X - w.X, _playN.Frame.Y - w.Y), op);
            }
        }
    }
}
