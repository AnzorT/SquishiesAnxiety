// Squishdoku's whole screen (src/screens/SquishdokuScreen.js) in landscape: the hub, the level map, a Regular level or a
// Blitz run, each sliding in over the last (src/components/ViewSwitch.js: the new view springs in from 60 dp right,
// friction 8, tension 70, fading in over the first 40%; it shows its placeholders (Skeleton.js ViewBones, a white shine
// sweeping across them) until it's built two frames later, then fades in over them in 160 ms). The wood page behind the
// hub, the menu's world behind the map (fading in with its slide); the top bar (back, LEVELS, LV n) over both; the map
// kept, asleep, under a level, so leaving the level is instant; HOW TO PLAY over everything (on the first visit too).
//   hub   → Regular → map → a level → (MAP / QUIT) map   ·  hub → Blitz → (QUIT) hub  ·  back: rules → map → hub → out
// No UnityEngine here: SquishdokuScreen shows the layers and feeds the touches; tools/unity/squishdoku-test runs it as is.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Games.Shared;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdScreen
    {
        /// <summary>Leaving Squishdoku (the top bar's back on the hub, Android's back there).</summary>
        public Action OnExit;
        /// <summary>The month, for the map's world (royal/WorldBg.js seasonNow).</summary>
        public static Func<DateTime> Today = () => DateTime.Now;
        /// <summary>Blitz's: Remove Ads, the ad, whether the record and pay are saved (the app's uid).</summary>
        public bool AdsFree, Save = true;
        public Func<bool> AdReady = () => AdHook.Ready();
        public Action<Action> ShowAd = back => AdHook.Show(back);
        /// <summary>A Blitz board's puzzle (tests hand in the app's); null: the engine's.</summary>
        public Func<int, int, Puzzle> PuzzleSource;
        /// <summary>HEAD START flipped (saved by the host: the profile's sdk.head).</summary>
        public Action<bool> OnHeadChanged;

        readonly float W, H;
        readonly Ticker _tk;
        readonly SdCreature[] _cast;
        readonly SdCreature _buddy;
        readonly Func<string, string> _xml;
        readonly Func<SdCreature, string> _headOf;
        bool _head;

        public SdScreen(float screenW, float screenH, SdCreature[] cast, SdCreature buddy, Func<string, string> xml, Func<SdCreature, string> headOf, Ticker tk)
        {
            W = screenW; H = screenH; _cast = cast; _buddy = buddy; _xml = xml; _headOf = headOf; _tk = tk;
            Ticker.Default = tk;
            var rec = Levels.Record(SdLevel.Profile);
            _head = rec.Head;
            _wood = new SdLayer("wood").SetPicture("Squishdoku/wood-bg", 0, 0);
            _world = new SdLayer("world");
            _orb = new SdLayer("back").Set(xml("orb-back"), 40, 40, 8);
            _title = new SdLayer("levels title");
            _pill = new SdLayer("lv pill");
            _bonesL = new SdLayer("bones");
            _hub = MakeHub();
            _built = "hub";
            _ready = true;
            _hub.Mount();
            Snd.Budget(30);
            // first visit: the rules
            if (rec.Plays == 0) _tk.SetTimeout(() => SetRules(true), 700);
        }

        // React: what a state change starts runs once rendered
        bool _input;
        void Effect(Action a) { if (_input) a(); else _tk.RequestAnimationFrame(a); }
        void AsInput(Action a) { bool was = _input; _input = true; try { a(); } finally { _input = was; } }

        // ---- the view switch ---------------------------------------------------------------------------------------------
        public string View { get; private set; } = "hub";   // hub | map | play | blitz
        readonly AnimatedValue _slide = new AnimatedValue(1);
        CompositeAnimation _slideA;
        string _built;            // the view whose content is up
        bool _ready;              // the view's content built (else its placeholders)
        readonly AnimatedValue _reveal = new AnimatedValue(1);
        bool _bonesUp;
        string _bonesKind;
        int _goGen;
        // royal/WorldBg.js useRoomUnder (2026-11-20, the user: flickering): the map's room stays up, at full opacity, under
        // a level that has just started until 900 ms after the level is built, then goes (the level covers it)
        bool _roomUnder;
        int _underTimer = -1;

        SdHub _hub;
        // the level map: the games' own (Games/Shared/LevelMap, as Squish Hop's since 2026-11-26, the user): every level
        // in one long row through the chapters' rooms, a banner (the room's card, CHAPTER n · ROOM) opening each chapter
        LevelMap _map;
        readonly LayerFrame _mapFrame = new LayerFrame();
        readonly Dictionary<ScreenLayer, SdLayer> _mapLayers = new Dictionary<ScreenLayer, SdLayer>();
        bool _mapKept;
        SdLevel _level;
        SdBlitz _blitz;
        int _playLv = 1;
        int? _justUnlocked;

        public SdHub Hub => _hub;
        public LevelMap Map => _map;
        public SdLevel Level => _level;
        public SdBlitz Blitz => _blitz;
        /// <summary>The view's content is built (its placeholders gone or going).</summary>
        public bool Ready => _ready;

        static readonly Interpolator SlideOp = Fx.Lerp(new[] { 0, 0.4, 1 }, new[] { 0.0, 1, 1 });
        static readonly Interpolator SlideX = Fx.Lerp(new[] { 0.0, 1 }, new[] { 60.0, 0 });

        void Go(string next)
        {
            _slide.SetValue(0);
            _slideA?.Stop();
            _slideA = Animated.Spring(_slide, Fx.Spring(1, 8, 70));
            _slideA.Start();
            string was = View;
            View = next;
            _tk.ClearTimeout(_underTimer);
            _roomUnder = next == "play";
            // what goes: the hub and a level or a run (their ViewSlot is keyed by the view); the map unless a level is
            // opened from it (KeptView)
            if (was == "hub") { _hub?.Unmount(); _hub = null; }
            if (was == "play") { _level = null; }
            if (was == "blitz") { _blitz = null; }
            if (was == "map" && next != "play") { _map?.Unmount(); _map = null; _mapKept = false; }
            if (was == "map" && next == "play") _mapKept = _map != null;
            if (next != "play" && next != "map") { _map?.Unmount(); _map = null; _mapKept = false; }
            // back to the kept map: it's up at once
            if (next == "map" && _mapKept && _map != null)
            {
                _ready = true; _built = "map"; _bonesUp = false; _reveal.SetValue(1);
                RefreshMap(Levels.Record(SdLevel.Profile));
                return;
            }
            _ready = false;
            _built = null;
            _bonesUp = true;
            _bonesKind = next == "map" ? "map" : next == "hub" ? "hub" : "game";
            _reveal.SetValue(0);
            BonesMount();
            int gen = ++_goGen;
            Effect(() => _tk.RequestAnimationFrame(() => _tk.RequestAnimationFrame(() => { if (gen == _goGen) BuildView(); })));
        }

        void BuildView()
        {
            var rec = Levels.Record(SdLevel.Profile);
            switch (View)
            {
                case "hub": _hub = MakeHub(); _hub.Mount(); break;
                case "map":
                    _map = NewMap(rec);
                    _map.Mount();
                    NodePops();
                    break;
                case "play":
                    _level = new SdLevel(W, H, _playLv, _head, _cast, _buddy, _xml, _tk);
                    _level.OnExit = unlocked => AsInput(() => LeaveLevel(unlocked));
                    Effect(() => _underTimer = _tk.SetTimeout(() => _roomUnder = false, 900));
                    break;
                case "blitz":
                    _blitz = new SdBlitz(W, H, _cast, _buddy, _xml, _tk) { AdsFree = AdsFree, AdReady = AdReady, ShowAd = ShowAd, Save = Save };
                    if (PuzzleSource != null) _blitz.PuzzleSource = PuzzleSource;
                    _blitz.OnExit = () => AsInput(() => { Snd.Play("sd_boardOut"); Go("hub"); });
                    break;
            }
            _built = View;
            _ready = true;
            // the content fades in over its placeholders
            Animated.Timing(_reveal, Fx.Timing(1, 160, Easing.Out(Easing.Quad))).Start(r => { if (r.Finished) { _bonesUp = false; BonesUnmount(); } });
        }

        SdHub MakeHub() => new SdHub(W, H, _xml, _head)
        {
            OnRegular = () => Go("map"),
            OnBlitz = () => Go("blitz"),
            OnRules = () => SetRules(true),
            OnToggleHead = () => { _head = !_head; _hub?.SetHead(_head); OnHeadChanged?.Invoke(_head); },
        };

        void StartLevel(int lv) { _playLv = lv; _justUnlocked = null; Go("play"); }

        // ---- the level map (Hop's) ------------------------------------------------------------------------------------------
        // under the screen's top bar (48 dp)
        const float MapTop = 48;
        // the nodes popping in as the map opens (Squishdoku's own sound)
        static void NodePops() { for (int k = 0; k < 6; k++) Snd.Play("sd_nodePop", delay: 120 + k * 70, rate: 0.9 + k * 0.07); }
        LevelMap NewMap(SdkRecord rec)
        {
            var list = new List<MapLevel>();
            for (int i = 0; i < Levels.LevelCount; i++) list.Add(new MapLevel(Levels.ChapterOf(i + 1) - 1, Levels.LevelList[i].Tier));
            var heads = new List<string>();
            foreach (var c in _cast) if (c?.Picture != null) heads.Add(c.Picture);
            // the rooms behind the map, the row on their floor (as Hop's: ROW_ON_FLOOR)
            var map = new LevelMap(list, W, MapTop, H - MapTop, heads, MapBanner, MapRoomCard, roomOf: i => Levels.RoomOfChapter(Levels.ChapterOf(i + 1)), rowAt: 0.75f)
            {
                OnPlay = lv => AsInput(() => StartLevel(lv)),
            };
            RefreshMap(rec, map);
            return map;
        }
        void RefreshMap(SdkRecord rec, LevelMap map = null)
        {
            map ??= _map;
            map?.SetRecord((int)rec.Lv, lv => (int)Js.OrNumber(rec.Best.TryGetValue(Js.IntKey(lv), out var b) ? b : null, 0));
        }
        // a chapter's banner: CHAPTER n · ROOM (`i`: its first level, from 0)
        static string MapBanner(int i)
        {
            int c = Levels.ChapterOf(i + 1);
            return $"CHAPTER {c} · {Rooms.Of(Levels.RoomOfChapter(c)).Name.ToUpperInvariant()}";
        }
        static readonly Dictionary<string, MapIcon> RoomCards = new Dictionary<string, MapIcon>();
        // the room's card over its banner (hop/Room.js RoomCard, exported: Resources/Maps/room-<room>), as Hop's
        static MapIcon MapRoomCard(int i)
        {
            string room = Levels.RoomOfChapter(Levels.ChapterOf(i + 1));
            if (HubsData.Current == null || HubsData.LoadXml == null) return null;
            if (!RoomCards.TryGetValue(room, out var ic))
            {
                try
                {
                    var (w, h) = HubsData.Current.Size("room-" + room);
                    var xml = HubsData.LoadXml("Maps/room-" + room);
                    ic = xml != null ? new MapIcon(room, xml, w, h) : null;
                }
                catch (Exception) { ic = null; }   // (no card: the banner alone)
                RoomCards[room] = ic;
            }
            return ic;
        }
        // the map's layers (LevelMap draws into a LayerFrame) as the screen's own
        void MapLayers(List<SdLayer> o, Action<LayerFrame> draw)
        {
            _mapFrame.Begin();
            draw(_mapFrame);
            foreach (var sl in _mapFrame.List)
            {
                if (!_mapLayers.TryGetValue(sl, out var l)) _mapLayers[sl] = l = new SdLayer(sl.Name);
                if (sl.Picture != null) l.SetPicture(sl.Picture, sl.W, sl.H); else l.Set(sl.Markup, sl.W, sl.H, sl.Margin);
                l.Transform = sl.Transform; l.Opacity = sl.Opacity; l.Visible = sl.Visible; l.Creature = sl.Creature;
                o.Add(l);
            }
        }
        void LeaveLevel(int? unlocked) { _justUnlocked = unlocked; Snd.Play("sd_boardOut"); Go("map"); }

        // ---- HOW TO PLAY ---------------------------------------------------------------------------------------------------
        Card _rules;
        public bool RulesOpen => _rules != null && _rules.Visible;
        /// <summary>HOW TO PLAY's buttons while it's up (tests).</summary>
        public IEnumerable<CardButton> RulesButtons() => _rules != null && _rules.Visible ? _rules.Buttons : new CardButton[0];
        void SetRules(bool on)
        {
            if (on)
            {
                if (RulesOpen) return;
                _rules = SdRules.Card(W, H, _cast, _headOf, () => SetRules(false));
                var c = _rules;
                Effect(() => c.Show());
            }
            else _rules?.Hide();
        }

        /// <summary>Android's back: the rules close, the map goes back to the hub, the hub leaves; a level or a run handle
        /// their own.</summary>
        public void Back() => AsInput(() =>
        {
            if (View == "play") { _level?.Back(); return; }
            if (View == "blitz") { _blitz?.Back(); return; }
            if (RulesOpen) SetRules(false);
            else if (View == "map") Go("hub");
            else { Snd.Budget(0); OnExit?.Invoke(); }
            Snd.Play("sd_boardOut");
        });

        // ---- placeholders (Skeleton.js ViewBones, tone "wood") ---------------------------------------------------------------
        // the one shine every bone shares: 1.4 s a pass, across in the first 70% (ease in-out quad), resting off to the right
        CompositeAnimation _sweepA;
        readonly AnimatedValue _sweep = new AnimatedValue(0);
        void BonesMount() { if (_sweepA != null) return; _sweepA = Animated.Loop(Animated.Timing(_sweep, Fx.Timing(1, 1400, Easing.Linear))); _sweepA.Start(); }
        void BonesUnmount() { _sweepA?.Stop(); _sweepA = null; _sweep.SetValue(0); }

        static readonly double[] SWEEP_AT = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 1 };

        // develop's ViewBones (wood, sideways: Games/Shared/ViewSwitch Bones.Layout) in the view's slot under `top`
        List<(float x, float y, float w, float h, float r)> Bones(string kind, float top, float h)
        {
            var o = new List<(float, float, float, float, float)>();
            foreach (var b in SquishSquad.Games.Shared.Bones.Layout(kind, W, h - top)) o.Add((b.X, top + b.Y, b.W, b.H, b.R));
            return o;
        }

        string BonesSvg(string kind, float top)
        {
            double p = _sweep.GetValue(), at = 0;
            // (the sweep's keyframes: 0 → 0.7 eased across, then resting)
            double k = Math.Min(1, p / 0.7), e = k < 0.5 ? 2 * k * k : 1 - Math.Pow(-2 * k + 2, 2) / 2;
            at = -90 + (W + 90) * e;
            at = Math.Round(at * 4) / 4;
            var s = new UiSvg(W, H);
            foreach (var b in Bones(kind, top, H))
            {
                if (b.y > H) continue;
                // (tone 'wood': a soft brown on the warm page, its shine dimmed to a fifth)
                s.Box(b.x, b.y, b.w, b.h, new BoxStyle { Background = "rgba(107,68,38,0.22)", Radius = b.r });
                var clip = s.NewId("bn");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(b.x, b.y, b.w, b.h, new[] { b.r, b.r, b.r, b.r })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                // the band: 90 wide, 10 over the bone's top and bottom, skewed -14° about its centre
                double bh = b.h + 20, cx = b.x + at + 45, cy = b.y - 10 + bh / 2;
                s.Open($"transform=\"translate({UiSvg.F(cx)} {UiSvg.F(cy)}) skewX(-14) translate({UiSvg.F(-cx)} {UiSvg.F(-cy)})\"");
                s.Box((float)(b.x + at), b.y - 10, 90, (float)bh, new BoxStyle { Gradient = new[] { "rgba(255,255,255,0)", "rgba(255,255,255,0.75)", "rgba(255,255,255,0)" }, GradientAngle = 90, Opacity = 0.2f });
                s.Close();
                s.Close();
            }
            return s.Markup;
        }

        // ---- the top bar (hub and map) ------------------------------------------------------------------------------------
        readonly SdLayer _wood, _world, _orb, _title, _pill, _bonesL;
        static readonly TextStyle TitleText = new TextStyle { Font = SdArt.Display, Size = 22, LetterSpacing = 1.5f, Color = "#ffffff", Shadows = new[] { new Shadow(SdArt.INK, 0, 2.5f, 1) } };
        static readonly TextStyle PillText = new TextStyle { Font = SdArt.Display, Size = 13, Color = "#ffffff" };
        string _pillKey;
        bool _orbDown;

        void Cover(SdLayer l, string picture, double iw, double ih)
        {
            double k = Math.Max(W / iw, H / ih);
            float w = (float)(iw * k), h = (float)(ih * k);
            l.SetPicture(picture, w, h);
            l.Transform = Affine.Translate((W - w) / 2, (H - h) / 2);
        }

        static string Season(DateTime d)
        {
            int mo = d.Month - 1;
            return mo == 11 || mo <= 1 ? "snowy" : mo >= 4 && mo <= 8 ? "sunny" : "rainy";
        }

        // ---- every frame ---------------------------------------------------------------------------------------------------
        readonly List<SdLayer> _frame = new List<SdLayer>();
        readonly Dictionary<SdLayer, SdLayer> _proxies = new Dictionary<SdLayer, SdLayer>();
        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();

        SdLayer Proxy(SdLayer src, Affine view, float op)
        {
            if (!_proxies.TryGetValue(src, out var p)) _proxies[src] = p = new SdLayer(src.Name);
            if (src.Picture != null) p.SetPicture(src.Picture, src.W, src.H); else p.Set(src.Markup, src.W, src.H, src.Margin);
            p.Transform = view * src.Transform;
            p.Opacity = src.Opacity * op;
            p.Visible = src.Visible;
            p.Creature = src.Creature;
            return p;
        }

        /// <summary>Everything on screen now, bottom first (call after the Ticker's tick).</summary>
        public List<SdLayer> Layers()
        {
            var o = _frame;
            o.Clear();
            var rec = Levels.Record(SdLevel.Profile);
            double sl = _slide.GetValue();
            float viewOp = (float)SlideOp.Evaluate(sl);
            var view = Affine.Translate(SlideX.Evaluate(sl), 0);
            bool full = View == "play" || View == "blitz";
            // the wood page (the room covers it in a level or a run)
            Cover(_wood, "Squishdoku/wood-bg", 2340, 1080);
            o.Add(_wood);
            bool under = View == "play" && _roomUnder;
            // the chapters' rooms behind the map (the games' LevelMap DrawRooms: each chapter's room by day, its door post
            // between two), moved by the map's scroll; under a level opened from it a moment longer
            if ((View == "map" || under) && _map != null && _map.HasRooms)
                MapLayers(o, f => _map.DrawRooms(f, under ? 1 : viewOp, H));
            else if (View == "map")
            {
                Cover(_world, "Squishdoku/levels-" + Season(Today()), 2340, 1080);
                _world.Opacity = viewOp;
                o.Add(_world);
            }
            if (!full)
            {
                _orb.Transform = Affine.Translate(14, 6) * Fx.Pressed(_orb.W, _orb.H, _orbDown ? 1 : 0);
                o.Add(_orb);
                if (View == "map")
                {
                    var lv = (int)PlayerXp.PlayerLevel(PlayerXp.PxpOf(SdLevel.Profile)).Level;
                    var t = $"LV {lv}";
                    if (t != _pillKey)
                    {
                        _pillKey = t;
                        float pw = UiSvg.BoxWidth(t, PillText) + 20 + 5, ph = UiSvg.LineBox(PillText) + 8 + 5;
                        _pill.Set(new UiSvg(pw, ph).Box(0, 0, pw, ph, new BoxStyle { Background = "#b8641c", Radius = 999, BorderWidth = 2.5f, BorderColor = "#ffffff" }).Text(t, 12.5f, 6.5f, PillText).Markup, pw, ph, 2);
                        float tw = W - 28 - 40 - pw;
                        _title.Set(new UiSvg(tw, 40).Text("LEVELS", 0, (40 - UiSvg.LineBox(TitleText)) / 2, TitleText, tw, 0.5f).Markup, tw, 40, 6);
                    }
                    _pill.Transform = Affine.Translate(W - 14 - _pill.W, 6 + (40 - _pill.H) / 2);
                    _title.Transform = Affine.Translate(54, 6);
                    o.Add(_title); o.Add(_pill);
                }
            }
            // the view, sliding in
            float content = _bonesUp ? (float)_reveal.GetValue() : 1;
            if (_ready)
            {
                if (View == "hub" && _hub != null) _hub.Layers(rec, view, viewOp * content, o);
                else if (View == "map" && _map != null) MapLayers(o, f => _map.Draw(f, view, viewOp * content));
                else if (View == "play" && _level != null) foreach (var l in _level.Layers()) o.Add(Proxy(l, view, viewOp * content));
                else if (View == "blitz" && _blitz != null) foreach (var l in _blitz.Layers()) o.Add(Proxy(l, view, viewOp * content));
            }
            if (_bonesUp)
            {
                _bonesL.Set(BonesSvg(_bonesKind, full ? 0 : SdHub.Top), W, H, 0);
                _bonesL.Transform = view;
                _bonesL.Opacity = viewOp * (1 - (_ready ? (float)_reveal.GetValue() : 0));
                o.Add(_bonesL);
            }
            if (_rules != null)
            {
                _rules.Update();
                foreach (var l in _rules.Layers()) o.Add(SdLayer.Mirror(l, _mirrors));
                if (!_rules.Shown) _rules = null;
            }
            if (_proxies.Count > o.Count + 64)
            {
                var seen = new HashSet<SdLayer>(o);
                var dead = new List<SdLayer>();
                foreach (var kv in _proxies) if (!seen.Contains(kv.Value)) dead.Add(kv.Key);
                foreach (var d in dead) _proxies.Remove(d);
            }
            return o;
        }

        // ---- touches (screen dp) ------------------------------------------------------------------------------------------
        int _downOn;   // 1 the card, 2 the back orb, 3 the view
        bool OnOrb(float x, float y) => x >= 14 - 8 && x <= 54 + 8 && y >= 6 - 8 && y <= 46 + 8;

        public void Down(float x, float y) => AsInput(() =>
        {
            _downOn = 0;
            if (_rules != null && _rules.Visible) { _rules.Down(x, y); _downOn = 1; return; }
            bool full = View == "play" || View == "blitz";
            if (!full && OnOrb(x, y)) { _orbDown = true; _downOn = 2; return; }
            if (!_ready) return;
            _downOn = 3;
            if (View == "hub") _hub?.Down(x, y);
            else if (View == "map") { if (y >= MapTop) _map?.Down(x, y); }
            else if (View == "play") _level?.Down(x, y);
            else _blitz?.Down(x, y);
        });

        public void Move(float x, float y) => AsInput(() =>
        {
            if (_downOn != 3) return;
            if (View == "map") _map?.Move(x, y);
            else if (View == "play") _level?.Move(x, y);
            else if (View == "blitz") _blitz?.Move(x, y);
        });

        public void Up(float x, float y) => AsInput(() =>
        {
            int was = _downOn;
            _downOn = 0;
            if (was == 1) { _rules?.Up(x, y); return; }
            if (was == 2)
            {
                _orbDown = false;
                if (OnOrb(x, y)) { Snd.Play("sd_boardOut"); if (View == "map") Go("hub"); else { Snd.Budget(0); OnExit?.Invoke(); } }
                return;
            }
            if (was != 3) return;
            if (View == "hub") _hub?.Up(x, y);
            else if (View == "map") _map?.Up(x, y);
            else if (View == "play") _level?.Up(x, y);
            else _blitz?.Up(x, y);
        });

        /// <summary>HEAD START as the hub's switch shows it.</summary>
        public bool HeadStart => _head;

        /// <summary>Presses a button of whatever card is up by its label (tests).</summary>
        public bool Press(string label)
        {
            Layers();
            var all = new List<CardButton>(RulesButtons());
            if (_level != null) foreach (var c in _level.Cards) if (c.Visible) all.AddRange(c.Buttons);
            if (_blitz != null) foreach (var c in _blitz.Cards) if (c.Visible) all.AddRange(c.Buttons);
            foreach (var b in all)
                if (b.Look.Label.StartsWith(label))
                {
                    var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                    Tap((float)p.X, (float)p.Y);
                    return true;
                }
            return false;
        }

        /// <summary>A tap (tests).</summary>
        public void Tap(float x, float y) { Down(x, y); Up(x, y); }
    }
}
