// A game's whole screen (src/screens/StackScreen.js, SortScreen.js, HopScreen.js, landscape): the page, the header
// (the back orb; on the map the game's title, "n / 50 levels" and the star pill; Squish Hop's "?" orb), and the views
// sliding in over each other (ViewSwitch): the hub, the level map (in the menu's world, MapBackdrop, fading in with
// it) and a level, each placeholders first; the map stays built under a level, so leaving the level is instant.
// The first visit opens HOW TO PLAY 700 ms in. Back (the orb, Android's back): the rules card → the map → the hub → out.
// A level isn't drawn here: when its view is built the host opens the game (OpenLevel) and slides / fades it with
// SlotTransform / SlotOpacity; the game hands control back through LevelExited.
// Pure C# (no UnityEngine): the clock is Ticker.Default; the tests draw Layers and Cards next to the app.
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    /// <summary>A game's hub (its front page): built in its box under the header, drawn in the sliding view.</summary>
    public abstract class Hub
    {
        public abstract void Build(float w, float top, float h);
        public abstract void Mount();
        public abstract void Unmount();
        public abstract void Draw(LayerFrame f, Affine view, float opacity);
        /// <summary>The hub's buttons, for taps (topmost last).</summary>
        public abstract IEnumerable<HubButton> Buttons { get; }
    }

    /// <summary>What a game's screen shows: its record, title, map, hub and rules.</summary>
    public abstract class GameDef
    {
        public abstract string Id { get; }
        public virtual bool HasHub => true;
        public virtual bool HelpOrb => false;
        public abstract string Title { get; }
        public virtual string TitleColor => "#8a3a0e";
        public abstract string Sub { get; }        // "n / 50 levels"
        public abstract string Stars { get; }      // the star pill's number
        public abstract bool Seen { get; }
        public abstract void MarkSeen();
        /// <summary>The map of the theme being played (Sort: the fridge's or the cupboard's).</summary>
        public abstract LevelMap NewMap(float w, float top, float h);
        /// <summary>The map is the whole screen with the header over it, and draws its own background (develop: Squish
        /// Stack's forest, StackScreen.js "the map is the forest, the whole screen, with this bar over its sky").</summary>
        public virtual bool FullMap => false;
        /// <summary>The map's title and line on a plaque, to read over the room behind the map (develop's SortScreen.js /
        /// HopScreen.js styles.plaque).</summary>
        public virtual bool Plaque => false;
        /// <summary>Today's season (the screen's, for the map's pictures).</summary>
        public string Season = "sunny";
        /// <summary>The player's selected character's key (the Menu's pick: Squish Stack's forest walker), or null.</summary>
        public string Walker;
        /// <summary>The map's record again (after a level).</summary>
        public abstract void Refresh(LevelMap map);
        public virtual Hub NewHub(GameScreen screen) => null;
        /// <summary>The theme a level is played in (Sort), or null.</summary>
        public virtual string Theme => null;
    }

    public sealed class GameScreen
    {
        public readonly GameDef Def;
        public readonly float W, H;
        public readonly ViewSwitch Sw;
        public readonly LayerFrame Frame = new LayerFrame();
        public readonly List<Card> Cards = new List<Card>();
        /// <summary>Where the menu's world is (Maps/world-&lt;season&gt;.jpg).</summary>
        public string Season = "rainy";

        public Action OnExit;
        /// <summary>A level's view is built: the host opens the game (level, Sort's theme or null).</summary>
        public Action<int, string> OpenLevel;
        /// <summary>BLITZ on a hub (the theme for Sort's, or null).</summary>
        public Action<string> OnBlitz;

        Hub _hub;
        LevelMap _map;
        Reveal _hubReveal, _mapReveal, _gameReveal;
        bool _mapKept;
        int _playLv = 1;
        Card _rules;
        bool _rulesOpen;
        Ticker _tk;
        readonly HashSet<Reveal> _bonesUp = new HashSet<Reveal>();

        public GameScreen(GameDef def, float w, float h)
        {
            Def = def; W = w; H = h;
            Sw = new ViewSwitch(def.HasHub ? "hub" : "map") { OnBuilt = Built };
        }

        public string View => Sw.View;
        public LevelMap Map => _map;
        public Hub HubView => _hub;
        public bool RulesOpen => _rulesOpen;

        // ---- the header ----------------------------------------------------------------------------------------------
        static readonly TextStyle HeadTitle = new TextStyle { Font = MapArt.Display, Size = 20, LetterSpacing = 1 };
        static readonly TextStyle HeadSub = new TextStyle { Font = MapArt.Heavy, Size = 11.5f, Color = MapArt.INK };
        static readonly TextStyle Pill = new TextStyle { Font = MapArt.Display, Size = 14, Color = "#b86200" };
        // over a full-screen map's sky (StackScreen.js headerTitle / headerSub): white, with a soft brown shadow
        TextStyle TitleStyle => Def.FullMap
            ? new TextStyle { Font = HeadTitle.Font, Size = HeadTitle.Size, LetterSpacing = HeadTitle.LetterSpacing, Color = "#ffffff", Shadows = new[] { new Shadow("rgba(90,40,10,0.85)", 0, 2, 3) } }
            : new TextStyle { Font = HeadTitle.Font, Size = HeadTitle.Size, LetterSpacing = HeadTitle.LetterSpacing, Color = Def.TitleColor };
        TextStyle SubStyle => Def.FullMap
            ? new TextStyle { Font = HeadSub.Font, Size = HeadSub.Size, Color = "#ffffff", Shadows = new[] { new Shadow("rgba(60,30,10,0.8)", 0, 1, 2) } }
            : HeadSub;
        Frame _back, _help, _titleBox, _plaque, _title, _sub, _pill, _pillText;
        float _headerH;
        string _headerFor;

        bool Playing => Sw.View == "game";
        bool Titled => Sw.View == "map" || !Def.HasHub;

        /// <summary>The header laid out for the view (StackScreen.js styles.header).</summary>
        float LayoutHeader()
        {
            string key = Titled + "|" + Def.Title + "|" + Def.Sub + "|" + Def.Stars;
            if (key == _headerFor) return _headerH;
            _headerFor = key;
            var root = new FlexNode("header").Row().AlignItems(YGAlign.Center).Gap(10).PadH(14).Padding(YGEdge.Top, 6).Padding(YGEdge.Bottom, 2);
            var back = root.Add(new FlexNode("back").Size(40, 40));
            FlexNode box = null, plaque = null, title = null, sub = null, help = null, pill = null, pillText = null;
            if (Titled)
            {
                box = root.Add(new FlexNode("titleBox").Flex(1).AlignItems(YGAlign.Center));
                var inner = box;
                if (Def.Plaque) inner = plaque = box.Add(new FlexNode("plaque").AlignItems(YGAlign.Center).PadH(16).Padding(YGEdge.Top, 1).Padding(YGEdge.Bottom, 3).Border(2));
                title = inner.Add(new Para(Def.Title, TitleStyle).Leaf("title"));
                sub = inner.Add(new Para(Def.Sub, SubStyle).Leaf("sub"));
                if (Def.HelpOrb) help = root.Add(new FlexNode("help").Size(40, 40));
                pill = root.Add(new FlexNode("pill").PadH(10).PadV(4).Border(2.5f));
                pillText = pill.Add(new Para("★ " + Def.Stars, Pill).Leaf("pillText"));
            }
            root.Layout(W, float.NaN);
            _back = back.Frame; _titleBox = box?.Frame ?? default; _plaque = plaque?.Frame ?? default; _title = title?.Frame ?? default; _sub = sub?.Frame ?? default;
            _help = help?.Frame ?? default; _pill = pill?.Frame ?? default; _pillText = pillText?.Frame ?? default;
            _headerH = root.Frame.H;
            return _headerH;
        }

        /// <summary>The views' box: under the header (hub, map), or the whole screen (a level).</summary>
        public float ViewTop => Playing ? 0 : LayoutHeader();

        // ---- the flow -----------------------------------------------------------------------------------------------------
        // sounds kept loaded while the game is open (the screens' SOUND_BUDGET)
        int Budget => Def.Id == "sort" ? 26 : Def.Id == "squishdoku" ? 30 : 28;

        void Exit()
        {
            Snd.Budget(0);
            OnExit?.Invoke();
        }

        public void Start()
        {
            _tk = Ticker.Default;
            Snd.Budget(Budget);
            if (Def.HasHub) { _hubReveal = new Reveal(true); MountHub(); }
            else { _mapReveal = new Reveal(true); MountMap(); _mapKept = true; }
            // first visit: how to play
            if (!Def.Seen)
            {
                // (the card's state is set in the timer; it springs up when React renders it, at the frame's time)
                _tk.SetTimeout(() => _tk.RequestAnimationFrame(() => ShowRules(true)), 700);
                Def.MarkSeen();
            }
        }

        void MountHub()
        {
            _hub = Def.NewHub(this);
            float top = LayoutHeader();
            _hub.Build(W, top, H - top);
            _hub.Mount();
        }

        void MountMap()
        {
            _headerFor = null;
            float top = Def.FullMap ? 0 : LayoutHeader();
            Def.Season = Season;
            _map = Def.NewMap(W, top, H - top);
            _map.OnPlay = Play;
            _map.Mount();
        }

        public void Go(string view)
        {
            string from = Sw.View;
            if (from == view) return;
            // the old view goes (the map stays, asleep, under a level)
            if (from == "hub") { _hub?.Unmount(); _hub = null; Frame.Drop("hub "); _hubReveal = null; }
            if (from == "game") _gameReveal = null;
            if (view != "game" && view != "map" && _map != null) { _map.Unmount(); _map = null; _mapKept = false; _mapReveal = null; Frame.Drop("map "); }
            Sw.Go(view);
            _headerFor = null;
            if (view == "hub") _hubReveal = new Reveal(false);
            if (view == "game") _gameReveal = new Reveal(false);
            if (view == "map" && !_mapKept) _mapReveal = new Reveal(false);
        }

        void Built(string view)
        {
            if (view == "hub") { MountHub(); _hubReveal.SetReady(); }
            if (view == "map" && !_mapKept) { _mapReveal.SetReady(); MountMap(); _mapKept = true; }
            if (view == "game") { _gameReveal.SetReady(); OpenLevel?.Invoke(_playLv, Def.Theme); }
        }

        void Play(int lv)
        {
            _playLv = lv;
            Go("game");
        }

        /// <summary>The level's game handed control back (its MENU / QUIT): back to the map.</summary>
        public void LevelExited()
        {
            Ticker.Default = _tk;
            if (_map != null) Def.Refresh(_map);
            _headerFor = null;
            Snd.Play("sd_boardOut");
            Go("map");
        }

        /// <summary>Android's back (Escape): the rules → the map → the hub → out. A level handles its own.</summary>
        public void Back()
        {
            if (Playing) return;
            if (_rulesOpen) ShowRules(false);
            else if (Sw.View == "map" && Def.HasHub) Go("hub");
            else Exit();
            Snd.Play("sd_boardOut");
        }

        public void OpenHub(string view) => Go(view);

        public void ShowRules(bool on)
        {
            if (on)
            {
                _rules ??= RulesCard.Build(Def.Id, W, H, () => ShowRules(false));
                if (!Cards.Contains(_rules)) Cards.Add(_rules);
                _rules.Show();
            }
            else _rules?.Hide();
            _rulesOpen = on;
        }

        // ---- every frame ---------------------------------------------------------------------------------------------
        public float SlotOpacity { get; private set; }
        public Affine SlotTransform { get; private set; } = Affine.Identity;

        public void Update()
        {
            Frame.Begin();
            float vop = Sw.Opacity;
            var view = Sw.Transform;
            // the page is the host's (exported PageBg); the map's world fades in with the map (MapBackdrop)
            if (Sw.View == "map" && !Def.FullMap)
            {
                // develop: the rooms the levels are played in (royal/WorldBg.js RoomBackdrop), else the season's world
                if (_map != null && _map.HasRooms) _map.DrawRooms(Frame, vop * (_mapReveal?.ContentOpacity ?? 1), H);
                else
                {
                    var bg = Frame.L("world");
                    bg.SetPicture($"Maps/world-{Season}.jpg", W, H);
                    bg.Opacity = vop;
                }
            }
            float top = ViewTop;
            // the kept map, then the view's slot
            if (Sw.View == "map" && _mapReveal != null)
            {
                if (_map != null) _map.Draw(Frame, view, vop * _mapReveal.ContentOpacity);
                if (_mapReveal.Bones) DrawBones("map", view, top, vop * _mapReveal.BonesOpacity);
            }
            if (Sw.View == "hub" && _hubReveal != null)
            {
                if (_hub != null && _hubReveal.Ready) _hub.Draw(Frame, view, vop * _hubReveal.ContentOpacity);
                if (_hubReveal.Bones) DrawBones("hub", view, top, vop * _hubReveal.BonesOpacity);
            }
            SlotOpacity = 0;
            if (Sw.View == "game" && _gameReveal != null)
            {
                SlotOpacity = _gameReveal.Ready ? vop * _gameReveal.ContentOpacity : 0;
                SlotTransform = view;
                if (_gameReveal.Bones) DrawBones("game", view, 0, vop * _gameReveal.BonesOpacity);
            }
            SyncBones();
            if (!Playing) DrawHeader();
            foreach (var c in Cards) c.Update();
            Cards.RemoveAll(c => !c.Shown);
        }

        void DrawBones(string kind, Affine view, float top, float opacity)
        {
            var l = Frame.L("bones " + kind);
            float h = H - top;
            l.Set(Bones.Key(kind, W), () => Bones.Markup(kind, W, h, W), W, h, 1);
            l.Transform = view * Affine.Translate(0, top);
            l.Opacity = opacity;
        }

        void SyncBones()
        {
            foreach (var r in new[] { _hubReveal, _mapReveal, _gameReveal })
            {
                if (r == null) continue;
                bool up = r.Bones;
                if (up && _bonesUp.Add(r)) Bones.Mount();
            }
            var gone = new List<Reveal>();
            foreach (var r in _bonesUp) if (!r.Bones || (r != _hubReveal && r != _mapReveal && r != _gameReveal)) gone.Add(r);
            foreach (var r in gone) { _bonesUp.Remove(r); Bones.Unmount(); }
        }

        bool _backDown, _helpDown;

        void DrawHeader()
        {
            LayoutHeader();
            var back = Frame.L("header back");
            back.Set("back", () => HubsData.LoadXml("Hubs/back"), 40, 40, 6);
            back.Transform = Affine.Translate(_back.X, _back.Y) * Fx.Pressed(40, 40, _backDown ? 1 : 0);
            if (!Titled) return;
            var tl = Frame.L("header title");
            string key = Def.Title + "|" + Def.Sub;
            var b = _titleBox;
            tl.Set(key, () =>
            {
                var s = new UiSvg(b.W, b.H);
                if (Def.Plaque) s.Box(_plaque.X - b.X, _plaque.Y - b.Y, _plaque.W, _plaque.H, new BoxStyle { Background = "rgba(255,247,234,0.94)", Radius = 16, BorderWidth = FlexNode.Bw(2), BorderColor = "#e2b27a" });
                new Para(Def.Title, TitleStyle).Draw(s, _title.X - b.X, _title.Y - b.Y, _title.W);
                new Para(Def.Sub, SubStyle).Draw(s, _sub.X - b.X, _sub.Y - b.Y, _sub.W);
                return s.Markup;
            }, b.W, b.H, 4);
            tl.Transform = Affine.Translate(b.X, b.Y);
            if (Def.HelpOrb)
            {
                var hl = Frame.L("header help");
                hl.Set("help", () => HubsData.LoadXml("Hubs/help"), 40, 40, 6);
                hl.Transform = Affine.Translate(_help.X, _help.Y) * Fx.Pressed(40, 40, _helpDown ? 1 : 0);
            }
            var pl = Frame.L("header pill");
            var p = _pill; var pt = _pillText;
            pl.Set("★ " + Def.Stars, () =>
            {
                var s = new UiSvg(p.W, p.H);
                s.Box(0, 0, p.W, p.H, new BoxStyle { Background = "#ffffff", Radius = 999, BorderWidth = FlexNode.Bw(2.5f), BorderColor = "#ffd23a" });
                new Para("★ " + Def.Stars, Pill).Draw(s, pt.X - p.X, pt.Y - p.Y, pt.W);
                return s.Markup;
            }, p.W, p.H, 2);
            pl.Transform = Affine.Translate(p.X, p.Y);
        }

        // ---- touch (screen dp) ----------------------------------------------------------------------------------------
        HubButton _pressed;
        bool _onMap, _cardDown;

        static bool In(Frame f, float x, float y, float slop) => x >= f.X - slop && x <= f.Right + slop && y >= f.Y - slop && y <= f.Bottom + slop;

        public void Down(float x, float y)
        {
            if (Playing) return;
            foreach (var c in Cards) if (c.Visible) { c.Down(x, y); _cardDown = true; return; }
            if (In(_back, x, y, 8)) { _backDown = true; return; }
            if (Def.HelpOrb && Titled && In(_help, x, y, 8)) { _helpDown = true; return; }
            if (Sw.View == "hub" && _hub != null && _hubReveal != null && _hubReveal.Ready)
            {
                HubButton hit = null;
                foreach (var b in _hub.Buttons) if (b.Hit(x, y)) hit = b;
                if (hit != null) { _pressed = hit; hit.Down(); return; }
            }
            if (Sw.View == "map" && _map != null && y >= ViewTop) { _onMap = true; _map.Down(x, y); }
        }

        public void Move(float x, float y)
        {
            if (_onMap && _map != null) _map.Move(x, y);
        }

        public void Up(float x, float y)
        {
            if (_cardDown)
            {
                _cardDown = false;
                foreach (var c in Cards.ToArray()) if (c.Visible) { c.Up(x, y); break; }
                return;
            }
            if (_backDown)
            {
                _backDown = false;
                if (In(_back, x, y, 8)) { Snd.Play("sd_boardOut"); if (Sw.View == "map" && Def.HasHub) Go("hub"); else Exit(); }
                return;
            }
            if (_helpDown)
            {
                _helpDown = false;
                if (In(_help, x, y, 8)) ShowRules(true);
                return;
            }
            if (_pressed != null)
            {
                var b = _pressed;
                _pressed = null;
                b.Up();
                if (b.Hit(x, y)) b.OnPress?.Invoke();
                return;
            }
            if (_onMap) { _onMap = false; _map?.Up(x, y); }
        }
    }

    /// <summary>Each game's HOW TO PLAY (stack/Cards.js, sort/Cards.js, hop/Cards.js RulesCard): its two columns as
    /// the app draws them (exported: Resources/Hubs/rules-&lt;game&gt;-left / -right), GOT IT! under the right one.</summary>
    public static class RulesCard
    {
        sealed class Column : CardItem
        {
            readonly string _xml, _prefix;
            public CardArt.Title Title;
            public float TitleX, TitleY, TitleW;
            public Column(string xml, string prefix, float w, float h) { _xml = xml; _prefix = prefix; W = w; H = h; }
            public override void Measure(float colW) { }
            public override void DrawStatic(UiSvg s)
            {
                s.Raw(Nest.Svg(_xml, _prefix, X, Y));
                // the title in its box as the app laid it out (an svg: on whole dp, as Chrome paints it)
                if (Title != null)
                {
                    float x = X + TitleX + (TitleW - Title.W) / 2, y = Y + TitleY;
                    var (dx, dy) = (Card.Whole(OX + x) - (OX + x), Card.Whole(OY + y) - (OY + y));
                    Title.Draw(s, x + dx, y + dy);
                }
            }
        }

        public static Card Build(string game, float screenW, float screenH, Action onClose)
        {
            var d = HubsData.Current;
            var info = d.RulesOf(game);
            var c = new Card(screenW, screenH);
            var (lw, lh) = d.Size($"rules-{game}-left");
            var (rw, _) = d.Size($"rules-{game}-right");
            c.Left.Add(new Column(HubsData.LoadXml($"Hubs/rules-{game}-left"), "rl", lw, lh)
            {
                Title = new CardArt.Title(info.title, info.titleSize, info.titleFill),
                TitleX = info.titleAt[0], TitleY = info.titleAt[1], TitleW = info.titleAt[2],
            });
            // the right column's words: everything above the button (the column's gap, 6, and the button's margin)
            c.Right.Add(new Column(HubsData.LoadXml($"Hubs/rules-{game}-right"), "rr", rw, info.at[1] - 6 - info.marginTop));
            var btn = new CardButton(new CardArt.ButtonLook(info.kind, info.label, info.fontSize, info.padH, info.padV), onClose);
            c.Right.Add(new ButtonsItem(false, btn) { MarginTop = info.marginTop });
            return c;
        }
    }
}
