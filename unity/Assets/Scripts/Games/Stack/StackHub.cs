// Squish Stack's screen for GameScreen (src/screens/StackScreen.js) and its hub (src/stack/Hub.js, landscape): the
// title with two squishies' heads bobbing round it, the line about the game and HOW TO PLAY on the left; REGULAR (the
// 50-level map, its progress bar) and BLITZ on the right. Its map is the shared one with this game's levels, a banner
// per size band ("4 SQUISHIES · 3 CUSHIONS"). The record is the profile's `stack` (Levels.Record).
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Games.Shared;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Stack
{
    public sealed class StackDef : GameDef
    {
        readonly IDictionary<string, object> _profile;
        public StackDef(IDictionary<string, object> profile) { _profile = profile; }
        StackRecord Rec => Levels.Record(_profile);
        public override string Id => "stack";
        public override string Title => "SQUISH STACK";
        public override string Sub => $"{(int)Levels.DoneOf(Rec)} / {Levels.LEVELS} levels";
        public override string Stars => ((int)Levels.StarsOf(Rec)).ToString();
        public override bool Seen => Rec.Seen;
        public override void MarkSeen() => Section(_profile, "stack")["seen"] = true;
        public static List<string> Cast => HubsData.Arts(HubsData.Current.stackCast);

        internal static IDictionary<string, object> Section(IDictionary<string, object> profile, string key)
        {
            if (profile.TryGetValue(key, out var v) && v is IDictionary<string, object> d) return d;
            var n = new Dictionary<string, object>();
            profile[key] = n;
            return n;
        }

        public override LevelMap NewMap(float w, float top, float h)
        {
            var list = new List<MapLevel>();
            foreach (var l in Levels.LEVEL_LIST) list.Add(new MapLevel(l.Band, l.Tier));
            var map = new LevelMap(list, w, top, h, Cast, i => $"{Levels.LEVEL_LIST[i].N} SQUISHIES · {Levels.LEVEL_LIST[i].K} CUSHIONS");
            Refresh(map);
            return map;
        }

        public override void Refresh(LevelMap map)
        {
            var rec = Rec;
            map.SetRecord((int)rec.Lv, lv => (int)Js.ToNum(Js.Or(Js.Get(rec.Best, Js.Int(lv)), 0.0)));
        }

        public override Hub NewHub(GameScreen screen) => new StackHub(this, _profile, screen);
    }

    public sealed class StackHub : Hub
    {
        readonly IDictionary<string, object> _profile;
        readonly GameScreen _screen;
        float _w, _top, _h;
        FlexNode _float1, _float2, _titleN, _taglineN, _rulesN;
        CardArt.Title _title;
        Para _tagline;
        ModeCard _regular, _blitz;
        HubButton _rules;
        readonly PopIn _titlePop = new PopIn(60, 0.3, -10), _taglinePop = new PopIn(220);
        readonly SlideIn _rulesSlide = new SlideIn(540, 30);
        readonly Rock _titleRock = new Rock(2, 3400), _rock1 = new Rock(8, 3000), _rock2 = new Rock(10, 2600);
        readonly SquishSquad.Ui.Cards.KeyLoop _bob1 = new SquishSquad.Ui.Cards.KeyLoop(2600, SquishSquad.Ui.Cards.KeyLoop.PHASE, SquishSquad.Ui.Cards.KeyLoop.UP_DOWN),
            _bob2 = new SquishSquad.Ui.Cards.KeyLoop(2200, SquishSquad.Ui.Cards.KeyLoop.PHASE, SquishSquad.Ui.Cards.KeyLoop.UP_DOWN, 400);
        string _head1, _head2;
        static readonly TextStyle Tagline = new TextStyle { Font = MapArt.Heavy, Size = 13, Color = MapArt.INK, LineHeight = 18 };

        public StackHub(StackDef def, IDictionary<string, object> profile, GameScreen screen) { _profile = profile; _screen = screen; }

        public override IEnumerable<HubButton> Buttons { get { yield return _rules; yield return _regular.Cta; yield return _blitz.Cta; } }

        public override void Build(float w, float top, float h)
        {
            _w = w; _top = top; _h = h;
            var rec = Levels.Record(_profile);
            var uris = StackDef.Cast;
            string Pick(double k) => uris.Count > 0 ? uris[(int)(k % uris.Count)] : null;
            _head1 = Pick(rec.Plays + 3); _head2 = Pick(rec.Plays + 11);

            var root = new FlexNode("hub").Size(w, h).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).PadH(24).Padding(YGEdge.Bottom, 10).Gap(28);
            var col1 = root.Add(new FlexNode("col1").Width(350).AlignItems(YGAlign.Center).Gap(12));
            var area = col1.Add(new FlexNode("titleArea").AlignSelf(YGAlign.Stretch).AlignItems(YGAlign.Center).Padding(YGEdge.Top, 8).Gap(6));
            _float1 = area.Add(new FlexNode("float1").Absolute().Pos(YGEdge.Left, 6).Pos(YGEdge.Top, 2).Size(48, 48));
            _float2 = area.Add(new FlexNode("float2").Absolute().Pos(YGEdge.Right, 8).Pos(YGEdge.Top, 10).Size(42, 42));
            _title = new CardArt.Title("SQUISH STACK", 34, "gold");
            // (the app's OutlinedTitle measures this word 1 dp wider than its laid-out text: its box is 251, the word centred)
            _titleN = area.Add(new FlexNode("title").Size(_title.W + 1, _title.H));
            _tagline = new Para("Move the squishies one at a time.\nA big one never sits on a smaller one!", Tagline, 0.5f);
            _taglineN = area.Add(_tagline.Leaf("tagline"));
            _rules = HubButton.Drawn("hub rules", new CardArt.ButtonLook("white", "HOW TO PLAY", 14, 16, 8), () => _screen.ShowRules(true));
            _rulesN = col1.Add(new FlexNode("rules").Size(_rules.W, _rules.H));
            var col2 = root.Add(new FlexNode("col2").Width(350).AlignItems(YGAlign.Center).Gap(12));
            double done = Levels.DoneOf(rec);
            var b = rec.Blitz;
            _regular = new ModeCard("hub regular", "regular", "REGULAR",
                new[] { $"Level {Math.Min((int)rec.Lv, Levels.LEVELS)} of {Levels.LEVELS} · ★ {(int)Levels.StarsOf(rec)}", "Fewest moves for 3 stars" }, 300,
                () => _screen.Go("map"), done / Levels.LEVELS);
            _blitz = new ModeCard("hub blitz", "blitz", "BLITZ ⚡",
                new[] { $"{Levels.BLITZ_ROUNDS} puzzles · {Levels.Clock(Levels.BLITZ_MS)}", "Big on small = back to puzzle 1",
                    b.Reached > 0 ? $"Best: puzzle {b.Reached}{(b.Wins > 0 ? $" · {b.Wins} win{(b.Wins > 1 ? "s" : "")}" : "")}" : "No runs yet" }, 420,
                () => _screen.OnBlitz?.Invoke(null));
            col2.Add(_regular.Build());
            col2.Add(_blitz.Build());
            root.Layout(w, h);
            root.Offset(0, top);
        }

        public override void Mount()
        {
            _titlePop.Trigger(); _taglinePop.Trigger(); _rulesSlide.Trigger();
            _titleRock.Mount(); _rock1.Mount(); _rock2.Mount(); _bob1.Mount(); _bob2.Mount();
            _regular.Mount(); _blitz.Mount();
        }

        public override void Unmount()
        {
            _titlePop.Stop(); _taglinePop.Stop(); _rulesSlide.Stop();
            _titleRock.Unmount(); _rock1.Unmount(); _rock2.Unmount(); _bob1.Unmount(); _bob2.Unmount();
            _regular.Unmount(); _blitz.Unmount();
        }

        public override void Draw(LayerFrame f, Affine view, float opacity)
        {
            // the heads first (the title is drawn over them), each bobbing and rocking
            void Head(string name, FlexNode n, string pic, SquishSquad.Ui.Cards.KeyLoop bob, float dy, Rock rock)
            {
                var l = f.L(name);
                float s = n.Frame.W;
                l.Set(pic ?? "", () => MapArt.Head(s, pic), s, s, 2);
                l.Transform = view * Affine.Translate(n.Frame.X, n.Frame.Y - dy * bob.Value) * rock.Local(s, s);
                l.Opacity = opacity;
            }
            Head("hub head 1", _float1, _head1, _bob1, 9, _rock1);
            Head("hub head 2", _float2, _head2, _bob2, 7, _rock2);
            var t = f.L("hub title");
            var tf = _titleN.Frame;
            t.Set("title", () => { var s = new UiSvg(tf.W, tf.H); _title.Draw(s, (tf.W - _title.W) / 2, 0); return s.Markup; }, tf.W, tf.H, 8);
            t.Transform = view * Affine.Translate(tf.X, tf.Y) * _titlePop.Local(tf.W, tf.H) * _titleRock.Local(tf.W, tf.H);
            t.Opacity = opacity * _titlePop.Opacity;
            var g = f.L("hub tagline");
            var gf = _taglineN.Frame;
            g.Set("tagline", () => { var s = new UiSvg(gf.W, gf.H); _tagline.Draw(s, 0, 0, gf.W); return s.Markup; }, gf.W, gf.H, 2);
            g.Transform = view * Affine.Translate(gf.X, gf.Y) * _taglinePop.Local(gf.W, gf.H);
            g.Opacity = opacity * _taglinePop.Opacity;
            var rf = _rulesN.Frame;
            _rules.Draw(f, view * Affine.Translate(rf.X, rf.Y) * _rulesSlide.Local, opacity * _rulesSlide.Opacity);
            _regular.Draw(f, view, opacity);
            _blitz.Draw(f, view, opacity);
        }
    }
}
