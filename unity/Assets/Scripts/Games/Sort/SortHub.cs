// Squish Sort's screen for GameScreen (src/screens/SortScreen.js) and its hub (src/sort/Hub.js, landscape: develop's
// GameHub, Squishdoku's pieces with this game's pictures: REGULAR MODE, the fridge's 50 levels; BLITZ MODE, the best
// run; HOW TO PLAY). Only the fridge since 2026-11-17 (the Toy Cupboard is gone). Its map: a banner per fridge (its
// picture over it) and per shelf it gains.
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
        public override string Title => "SQUISH SORT";
        // (develop: the title on a plaque over the kitchen behind the map)
        public override bool Plaque => true;
        public override string Sub => $"{(int)Levels.DoneIn(Rec, ThemeKey)} / {Levels.LEVELS} levels";
        public override string Stars => ((int)Levels.StarsIn(Rec, ThemeKey)).ToString();
        public override bool Seen => Rec.Seen;
        public override void MarkSeen()
        {
            if (!(_profile.TryGetValue("sort", out var v) && v is IDictionary<string, object> d)) _profile["sort"] = d = new Dictionary<string, object>();
            d["seen"] = true;
            SortSave.Record(new Dictionary<string, object> { { "sort.seen", true } });   // SortScreen.js
        }

        /// <summary>Whether the creature with this key is out (config/roster: Screens/RosterConfig sets it in Unity; null,
        /// in tools/unity's tests: every one).</summary>
        public static Func<string, bool> KeyIsOut;

        // (src/sort/themes.js poolOf: only the ones that are out, config/roster; the cut-outs are named by key)
        public static List<string> Pool(string theme)
        {
            var files = theme == "cupboard" ? HubsData.Current.sortPools.cupboard : HubsData.Current.sortPools.fridge;
            var outs = files == null || KeyIsOut == null ? null : System.Array.FindAll(files, f => KeyIsOut(f));
            return HubsData.Arts(outs != null && outs.Length > 0 ? outs : files);
        }
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
            // develop: the kitchen behind the map (SortScreen.js roomOf), the row on its floor (ROW_ON_FLOOR)
            var map = new LevelMap(list, w, top, h, Pool(theme), Banner, Icon, roomOf: _ => "kitchen", rowAt: 0.75f);
            Refresh(map);
            return map;
        }

        public override void Refresh(LevelMap map)
        {
            var t = Rec.Of(ThemeKey);
            map.SetRecord((int)t.Lv, lv => (int)JsMath.OrNum(JsMath.Get(t.Best, JsMath.Key(lv)), 0));
        }

        public override Hub NewHub(GameScreen screen) => SortHub.New(_profile, screen);
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
            // (the floor shadow spills past the body's box)
            return new MapIcon($"{theme}|{model}|{rows}|{cols}", s.Markup, c.W, c.H) { Margin = (float)Math.Ceiling(SortArt.BodyMargin(c.G) * c.K + 2) };
        }

        /// <summary>Its layers (prefix `name`) at `at` (its box's top-left on screen): open by `door`, `uris` inside.</summary>
        public void Draw(LayerFrame f, string name, Affine at, float opacity, double door, IList<string> uris)
        {
            var g = G;
            string key = $"{_theme}|{_model}|{_rows}|{g.Cols}";
            var mini = at * Affine.ScaleBy(K, K);
            var body = f.L(name + " body"); body.Set(key, () => SortArt.Body(M, g), g.BodyW, g.BodyH + g.Feet, SortArt.BodyMargin(g)); body.Transform = mini; body.Opacity = opacity;
            var inside = mini * Affine.Translate(SortArt.InsideX, SortArt.InsideY(g));
            float hd = g.H + g.Crisper;
            var ib = f.L(name + " inside back"); ib.Set(key, () => SortArt.InsideBack(M, g), g.W, hd, 1); ib.Transform = inside; ib.Opacity = opacity;
            var lamp = f.L(name + " lamp"); lamp.Set(key, () => SortArt.Lamp(M, g), g.W, hd, 1); lamp.Transform = inside; lamp.Opacity = opacity;
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

    /// <summary>src/sort/Hub.js (develop, 2026-11-17: "make sure the screens of squish sort matches the other game's
    /// screen"): the new design's GameHub (Games/Shared/ModeHub) with Squish Sort's pictures; REGULAR MODE is the fridge's
    /// 50-level map (only the fridge since 2026-11-17).</summary>
    public static class SortHub
    {
        public static Hub New(IDictionary<string, object> profile, GameScreen screen)
        {
            var rec = Levels.Record(profile);
            return new ModeHub("SQUISH SORT", "Sort", (int)rec.Fridge.Lv, (int)Levels.DoneIn(rec, "fridge"), Levels.LEVELS, (int)(rec.Blitz.Top ?? 0),
                () => screen.Go("map"), () => screen.OnBlitz?.Invoke(null), () => screen.ShowRules(true));
        }
    }
}
