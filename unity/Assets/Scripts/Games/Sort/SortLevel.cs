// One level of Squish Sort and the ones after it, as src/sort/Game.js plays it (Blitz's own branches: SortBlitz.cs),
// in landscape (REDESIGN_V8: the HUD in a 236 dp column on the left, the play area beside it with the tray standing at
// its right):
//   intro   the level's number and its twists, the container pops in      deal    the squishies pop onto the shelves
//   peek    REMEMBER! (the level's peek time; sneaky swaps near its end)     close   the doors swing shut
//   shake   it rattles and jumps twice                                       open    the doors fly open, the lamp flickers
//   tumble  everyone falls out into the tray (the mixed-up ones stay inside, in the wrong spots)
//   place   drag each one home, or tap it and then its spot; the clock runs; three mistakes and it's over
//   won     the result card 1500 ms later: NEXT / REPLAY / MENU     lost   the fail card 1700 ms later: RETRY / MENU
//   The back orb (or Android's back) while sorting pauses: the clock stops, the pause card (RESUME / RESTART LEVEL / QUIT).
// Every motion is the app's: the same Animated timings, springs and easings (SquishSquad.Anim is React Native's Animated
// in C#), the same geometry (SortGeometry), the same drawings (SortArt). Pure C#: no UnityEngine, so the tests run it
// frame by frame next to the app (tools/unity/sort-test); SortGame shows its layers in Unity.
// Not ported: saving to Firestore.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Blitz;
using SquishSquad.Vector;
using static SquishSquad.Games.Sort.SortGeometry;

namespace SquishSquad.Games.Sort
{
    /// <summary>One drawn piece of the level: an SVG (or a picture, `contain`ed in its box) in its own box, where it is
    /// this frame (a 2D transform, screen dp), how opaque; a door is projected (Door) instead.</summary>
    public sealed class SortLayer
    {
        public readonly string Name;
        public string Markup { get; private set; }
        public string Picture { get; private set; }
        public float W { get; private set; }
        public float H { get; private set; }
        public float Margin { get; private set; } = 6;
        public int Version { get; private set; }
        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        public DoorView Door;

        public SortLayer(string name) { Name = name; }

        public void Set(string markup, float w, float h, float margin = 6)
        {
            if (markup == Markup && w == W && h == H && margin == Margin && Picture == null) return;
            Markup = markup; Picture = null; W = w; H = h; Margin = margin; Version++;
        }

        public void SetPicture(string href, float w, float h)
        {
            if (href == Picture && w == W && h == H && Markup == null) return;
            Picture = href; Markup = null; W = w; H = h; Margin = 0; Version++;
        }
    }

    /// <summary>A door turning about its hinge with CSS's perspective (Container.js Door): `transform: perspective(p)
    /// translateX(±w/2) rotateY(θ) translateX(∓w/2)` about the door's centre, then Post (its place on screen).</summary>
    public sealed class DoorView
    {
        public float W, H, Sign, Persp;
        public double Deg;
        public Affine Post = Affine.Identity;

        /// <summary>A point of the door (its box, dp) on screen.</summary>
        public Vec2 Map(double u, double v)
        {
            double a = Deg * Math.PI / 180;
            double x1 = u - W / 2.0 - Sign * W / 2.0, y = v - H / 2.0;
            double z = -x1 * Math.Sin(a);
            double x2 = x1 * Math.Cos(a) + Sign * W / 2.0;
            double k = Persp / (Persp - z);
            return Post.Apply(new Vec2(x2 * k + W / 2.0, y * k + H / 2.0));
        }
    }

    /// <summary>What the level draws from: the clutter's drawings (Resources/Sort/props.json) and each container's
    /// squishies (Resources/Sort/sort.json, pictures in Resources/Stack/art).</summary>
    public sealed class SortData
    {
        public Dictionary<string, List<string>> Props = new Dictionary<string, List<string>>();
        public Dictionary<string, List<PoolEntry>> Pools = new Dictionary<string, List<PoolEntry>>();
        public string BackXml;   // Resources/Sort/back.xml
    }

    public sealed partial class SortLevel
    {
        // ---- setup --------------------------------------------------------------------------------------------------
        public Action OnExit;
        public Action<int> OnLevel;   // the level now playing (NEXT moves it on)
        public IDictionary<string, object> Profile;
        /// <summary>Tests: the board for a spec instead of a fresh random deal.</summary>
        public Func<LevelSpec, BoardData> MakeBoardHook;
        public Func<double> Random = new System.Random().NextDouble;

        string _theme;   // (Blitz: the round's, fridge and cupboard taking turns)
        readonly float _sw, _sh;           // the screen, dp
        readonly SortData _data;
        readonly Ticker _tk;
        int _lv, _round;
        public LevelSpec Spec { get; private set; }
        public BoardData Board { get; private set; }
        SortModel _m;
        ContainerGeo _g;
        TrayGeo _tg;
        float _P, _Q, _trayScale;
        public const float AreaX = SortArt.LeftW;
        float AreaW => _sw - AreaX;
        float AreaH => _sh;

        public SortLevel(string theme, int startLv, float screenW, float screenH, SortData data, IDictionary<string, object> profile)
        {
            _theme = theme == "cupboard" ? "cupboard" : "fridge";
            _lv = Math.Max(1, Math.Min(Levels.LEVELS, startLv));
            _sw = screenW; _sh = screenH; _data = data; Profile = profile;
            _tk = Ticker.Default;
        }

        // ---- animated things --------------------------------------------------------------------------------------
        readonly AnimatedValue _door = new AnimatedValue(1), _light = new AnimatedValue(1), _pop = new AnimatedValue(0), _rot = new AnimatedValue(0),
            _tx = new AnimatedValue(0), _ty = new AnimatedValue(0), _sq = new AnimatedValue(0), _peekBar = new AnimatedValue(1), _clutterIn = new AnimatedValue(0);
        readonly AnimatedValue _hoverX = new AnimatedValue(0), _hoverY = new AnimatedValue(0), _hoverO = new AnimatedValue(0);

        sealed class InsideAnim { public AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), S = new AnimatedValue(0); }
        sealed class PieceAnim
        {
            public AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), S = new AnimatedValue(1), O = new AnimatedValue(0), Lift = new AnimatedValue(0),
                Shake = new AnimatedValue(0), Hop = new AnimatedValue(0), Tick = new AnimatedValue(0);
            // Game.js Piece's loops: the mixed-up wobble (1550 ms keyframes) and the selected pulse (840 ms up and down)
            public KeyLoop Wob = new KeyLoop(1550, WOB_AT, WOB_VALUES), Pulse = new KeyLoop(840, KeyLoop.PHASE, KeyLoop.UP_DOWN);
            public bool WobOn, PulseOn;
        }
        static readonly double[] WOB_AT = { 0, 0.084, 0.168, 0.252, 0.335, 0.377, 0.419, 1 };
        static readonly double[] WOB_VALUES = { 0, 0.71, 1, 0, -1, -0.5, 0, 0 };
        InsideAnim[] _ins;
        PieceAnim[] _anims;

        // the HUD's hearts (components/Hearts.js Heart): 1 full; going out it pops and greys
        readonly AnimatedValue[] _hearts = { new AnimatedValue(1), new AnimatedValue(1), new AnimatedValue(1) };
        readonly bool[] _heartOn = { true, true, true };

        // squishdoku/game.js useClock
        sealed class Clock
        {
            readonly Ticker _tk;
            public readonly AnimatedValue Frac = new AnimatedValue(1);
            double _limit = 1, _used, _since;
            bool _running;
            CompositeAnimation _anim;
            public Clock(Ticker tk) { _tk = tk; }
            void Run()
            {
                _anim?.Stop();
                Frac.SetValue(Math.Max(0, 1 - _used / _limit));
                _anim = Animated.Timing(Frac, new TimingConfig { ToValue = 0, Duration = Math.Max(1, _limit - _used), Easing = Easing.Linear, UseNativeDriver = true });
                _anim.Start();
            }
            public double Elapsed() => _used + (_running ? _tk.Now - _since : 0);
            public void Start(double limit, double used = 0) { _limit = limit; _used = used; _since = _tk.Now; _running = true; Run(); }
            public void Pause() { if (!_running) return; _used += _tk.Now - _since; _running = false; _anim?.Stop(); Frac.SetValue(Math.Max(0, 1 - _used / _limit)); }
            public void Resume() { if (_running) return; _since = _tk.Now; _running = true; Run(); }
            public void Reset() { _anim?.Stop(); _limit = 1; _used = 0; _since = 0; _running = false; Frac.SetValue(1); }
            public double Limit => _limit;
        }
        Clock _clk;

        // ---- state ------------------------------------------------------------------------------------------------
        public string Phase { get; private set; } = "load";
        PlayState _play;
        int _mistakes;
        int? _selected, _dragK;
        int _peekLeft, _left;
        bool _paused, _showInside = true, _foodMoved;
        Dictionary<int, int> _insideNow = new Dictionary<int, int>();
        readonly List<int> _timers = new List<int>();
        int _interval = -1;
        bool _started;

        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));
        // what a component's effect does once React has rendered a state change: at the end of the frame it happened in
        // (Update runs them first)
        readonly List<Action> _effects = new List<Action>();
        void Effect(Action a) => _effects.Add(a);
        void ClearTimers() { foreach (var t in _timers) _tk.ClearTimeout(t); _timers.Clear(); }

        static SpringConfig Spring(double to, double friction, double tension) => new SpringConfig { ToValue = to, Friction = friction, Tension = tension, UseNativeDriver = true };
        static TimingConfig Timing(double to, double ms, Func<double, double> easing = null) => new TimingConfig { ToValue = to, Duration = ms, Easing = easing, UseNativeDriver = true };

        /// <summary>Starts the first level with the clock (Ticker.Default) where it is.</summary>
        static readonly string[] LoadSounds = { "fs_pop", "fs_peek", "fs_doorClose", "fs_doorOpen", "fs_rattle", "fs_jump", "fs_land", "fs_tumble", "fs_pick", "fs_drop", "fs_snap", "fs_wrong", "fs_impostor", "fs_swap", "fs_heart", "fs_mixed", "sd_tick", "sd_solve", "sd_confetti", "sd_boardIn" };

        public void Start()
        {
            if (_started) return;
            _started = true;
            _clk = new Clock(_tk);
            Snd.Preload(LoadSounds);
            NewRound();
        }

        // ---- where a piece sits (Game.js spotOf / insideXY) ---------------------------------------------------------
        (float x, float y, float s) SpotOf(Place loc)
        {
            if (loc.IsSlot)
            {
                var c = SlotCenter(_g, loc.I);
                return (c.x - _P / 2, c.y + _g.S / 2 - _P - 1, 1);
            }
            var t = TrayCenter(_tg, loc.I);
            return (t.x - _P / 2, t.y - _P / 2, _trayScale);
        }

        (float x, float y) InsideXY(int slot) => ((slot % _g.Cols) * _g.S + (_g.S - _P) / 2, (slot / _g.Cols) * (_g.S + SHELF) + _g.S - _P - 1);

        void Fly(int k, Place loc, double bounce = 7, double hop = 0)
        {
            var A = _anims[k];
            var to = SpotOf(loc);
            var list = new List<CompositeAnimation>
            {
                Animated.Spring(A.X, Spring(to.x, bounce, 90)),
                Animated.Spring(A.Y, Spring(to.y, bounce, 90)),
                Animated.Spring(A.S, Spring(to.s, 6, 110)),
                Animated.Timing(A.Lift, Timing(0, 140)),
            };
            if (hop != 0) list.Add(Animated.Sequence(Animated.Timing(A.Hop, Timing(-hop, 160, Easing.Out(Easing.Quad))), Animated.Timing(A.Hop, Timing(0, 200, Easing.In(Easing.Quad)))));
            Animated.Parallel(list).Start();
        }

        void HopInside(int k, int slot)
        {
            var A = _ins[k];
            var to = InsideXY(slot);
            Animated.Parallel(
                Animated.Timing(A.X, Timing(to.x, 560, Easing.InOut(Easing.Quad))),
                Animated.Sequence(
                    Animated.Timing(A.Y, Timing(to.y - _g.S * 0.6, 280, Easing.Out(Easing.Quad))),
                    Animated.Timing(A.Y, Timing(to.y, 280, Easing.In(Easing.Quad))))).Start();
        }

        void SwapNow(int a, int b)
        {
            bool ha = _insideNow.TryGetValue(a, out var pa), hb = _insideNow.TryGetValue(b, out var pb);
            if (ha) HopInside(pa, b);
            if (hb) HopInside(pb, a);
            var next = new Dictionary<int, int>(_insideNow);
            next.Remove(a); next.Remove(b);
            if (ha) next[b] = pa;
            if (hb) next[a] = pb;
            _insideNow = next;
            Snd.Play("fs_swap");
        }

        // ---- the end of a level -----------------------------------------------------------------------------------
        Card _result, _fail, _pause;
        readonly List<Card> _cards = new List<Card>();   // on screen (closing ones too), bottom first: result, fail, pause
        public IEnumerable<ICardView> Cards => AllCards();

        Card Open(Card c, int rank)
        {
            // (the card's Overlay starts once React has rendered it)
            Effect(c.Show);
            _cards.Add(c);
            _ranks[c] = rank;
            _cards.Sort((x, y) => _ranks[x].CompareTo(_ranks[y]));
            return c;
        }
        readonly Dictionary<Card, int> _ranks = new Dictionary<Card, int>();
        static void Close(ref Card c, bool emptied = false) { c?.Hide(emptied); c = null; }

        void Lose(string reason)
        {
            if (Phase != "place") return;
            if (_blitz) { BlitzStop(reason); return; }
            Phase = "lost";
            _clk.Pause();
            _selected = null;
            _hoverO.SetValue(0);
            Snd.Play(reason == "time" ? "sd_timeUp" : "sd_blitzFail");
            Snd.Wrong();
            // show where they all belonged
            for (int k = 0; k < Board.Pieces.Count; k++)
            {
                if (_play.Gone.Contains(k)) continue;
                var A = _anims[k];
                var p = Board.Pieces[k];
                if (p.Home == null)
                    Animated.Parallel(Animated.Timing(A.O, Timing(0, 300)), Animated.Timing(A.S, Timing(0.2, 300))).Start();
                else if (!_play.Locked.Contains(k)) { int kk = k; int home = p.Home.Value; Later(200 + k * 70, () => Fly(kk, Place.Slot(home), hop: 30)); }
            }
            var outc = Levels.AfterLevel(Profile, _theme, Spec, false, _mistakes, null);
            SortSave.Record(outc.Update);   // (signed in: saveSort)
            Apply(outc.Update);
            var uri = Board.Pieces.Count > 0 ? Board.Pieces[0].Uri : null;
            Later(1700, () => _fail = Open(SortCards.FailCard(_sw, _sh, reason, uri, Replay, Leave), 1));
        }

        void Win()
        {
            Phase = "won";
            _clk.Pause();
            _selected = null;
            _hoverO.SetValue(0);
            // impostors still in the tray: poof
            for (int k = 0; k < Board.Pieces.Count; k++)
            {
                if (Board.Pieces[k].Home != null || _play.Gone.Contains(k)) continue;
                var A = _anims[k];
                var pc = TrayCenter(_tg, _play.At[k].I);
                Spray("poof", pc.x, pc.y, 1);
                Animated.Parallel(Animated.Timing(A.O, Timing(0, 260)), Animated.Timing(A.S, Timing(0.1, 260))).Start();
            }
            Snd.Play("sd_solve");
            Snd.Win();
            Later(250, () => { Snd.Play("sd_confetti"); Spray("confetti", _g.Ix + _g.W / 2, _g.Iy + _g.H * 0.3, 1.2); });
            Later(650, () => Spray("confetti", _g.Ix + _g.W * 0.25, _g.Iy + _g.H * 0.5, 1));
            Later(800, () => Spray("confetti", _g.Ix + _g.W * 0.75, _g.Iy + _g.H * 0.5, 1));
            // a hop wave along the shelves, the lamp flashing
            for (int k = 0; k < Board.Pieces.Count; k++)
            {
                var p = Board.Pieces[k];
                if (p.Home == null) continue;
                var A = _anims[k];
                Later(150 + p.Home.Value * 60, () => Animated.Sequence(
                    Animated.Timing(A.Hop, Timing(-_g.S * 0.28, 170, Easing.Out(Easing.Quad))),
                    Animated.Timing(A.Hop, Timing(0, 200, Easing.Bounce))).Start());
            }
            Animated.Sequence(Array.ConvertAll(new[] { 0.4, 1, 0.5, 1 }, v => Animated.Timing(_light, Timing(v, 110)))).Start();
            // Blitz: one more cleared; on to the next round
            if (_blitz) { BlitzCleared(); return; }
            double ms = _clk.Elapsed();
            var outc = Levels.AfterLevel(Profile, _theme, Spec, true, _mistakes, ms);
            SortSave.Paid(outc, Profile);
            Apply(outc.Update);
            var res = new SortCards.Result
            {
                Stars = (int)outc.Stars, Coins = outc.Coins, Xp = outc.Xp, LevelUps = outc.LevelUps?.Count ?? 0, Unlocked = outc.Unlocked, Mistakes = _mistakes, Ms = ms,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            var spec = Spec;
            Later(1500, () => _result = Open(SortCards.ResultCard(_sw, _sh, res, _lv >= Levels.LEVELS, Next, Replay, Leave, Trio()), 0));
        }

        void Mistake()
        {
            _mistakes += 1;
            Snd.Wrong();
            if (_blitz) { BlitzStop("mistake"); return; }
            Later(160, () => Snd.Play("fs_heart"));
            if (_mistakes >= Levels.HEARTS) Later(500, () => Lose("hearts"));
        }

        // a piece let go (or a tapped spot): the board's rule, then the animation
        void HandleDrop(int k, Place target)
        {
            var before = _play;
            var from = before.At[k];
            var r = Sort.Board.Drop(Board, before, k, target);
            _play = r.State;
            _selected = null;
            _hoverO.SetValue(0);
            var A = _anims[k];
            if (r.Outcome == Sort.Board.Lock)
            {
                Snd.Play("fs_snap");
                Snd.Place();
                Fly(k, r.State.At[k], bounce: 5);
                if (target.IsSlot) { var sc = SlotCenter(_g, target.I); Spray("spark", sc.x, sc.y, 1.1); }
                A.Tick.SetValue(0);
                Animated.Sequence(Animated.Spring(A.Tick, Spring(1, 4, 160))).Start();
                if (r.Bumped.HasValue) { int b = r.Bumped.Value; var st = r.State; Later(120, () => { Snd.Play("fs_drop"); Fly(b, st.At[b], hop: 26); }); }
                if (Sort.Board.Solved(Board, r.State)) Later(450, Win);
            }
            else if (r.Outcome == Sort.Board.Wrong)
            {
                Snd.Play("fs_wrong");
                var at = CenterOf(k);
                Spray("angry", at.x, at.y, 1);
                Fly(k, from, hop: 22);
                A.Shake.SetValue(0);
                Animated.Sequence(Array.ConvertAll(new double[] { 10, -9, 7, -5, 3, 0 }, v => Animated.Timing(A.Shake, Timing(v, 50)))).Start();
                Mistake();
            }
            else if (r.Outcome == Sort.Board.Impostor)
            {
                Snd.Play("fs_impostor");
                var ic = CenterOf(k);
                Later(380, () => Spray("poof", ic.x, ic.y, 1.2));
                Say("IMPOSTOR!", ink: "#8e1030", small: true, hold: 500, sub: "It was never inside!");
                Animated.Sequence(
                    Animated.Timing(A.S, Timing(1.3, 160)),
                    Animated.Parallel(Animated.Timing(A.S, Timing(0, 260, Easing.In(Easing.Back(2)))), Animated.Timing(A.O, Timing(0, 260)))).Start();
                Mistake();
            }
            else { Fly(k, r.State.At[k]); Snd.Play("fs_drop"); }
        }

        // ---- the timeline -----------------------------------------------------------------------------------------
        void StartPlace()
        {
            Phase = "place";
            var notes = new List<string>();
            if (Spec.Decoys > 0) notes.Add($"{Spec.Decoys} impostor{(Spec.Decoys > 1 ? "s" : "")} snuck in!");
            if (Spec.Mixed > 0) notes.Add("Some got mixed up inside!");
            if (Spec.Mixed > 0) Later(300, () => Snd.Play("fs_mixed"));
            Say("PUT THEM BACK!", small: true, sub: notes.Count > 0 ? string.Join("  ", notes) : "Drag or tap them home", hold: 900);
            // (Blitz: each round on its own clock, BlitzSpec's)
            _clk.Start(Spec.LimitMs);
            if (_blitz) _runStarted = true;
            Effect(() => { if (Phase == "place" && !_paused) StartInterval(); });
        }

        // the clock running out (and the time left, by the second), every 250 ms while sorting
        void StartInterval()
        {
            StopInterval();
            void Tick()
            {
                if (Phase != "place" || _paused) { _interval = -1; return; }
                double ms = _clk.Limit - _clk.Elapsed();
                _left = (int)Math.Ceiling(ms / 1000);
                if (ms <= 0) Lose("time");
                if (Phase == "place" && !_paused) _interval = _tk.SetTimeout(Tick, 250); else _interval = -1;
            }
            _interval = _tk.SetTimeout(Tick, 250);
        }
        void StopInterval() { if (_interval >= 0) _tk.ClearTimeout(_interval); _interval = -1; }

        void Tumble()
        {
            Phase = "tumble";
            Snd.Play("fs_tumble");
            int n = 0;
            for (int k = 0; k < Board.Pieces.Count; k++)
            {
                var A = _anims[k];
                var a = Board.After[k];
                A.Lift.SetValue(0); A.Hop.SetValue(0); A.Shake.SetValue(0); A.Tick.SetValue(0);
                if (a.IsSlot)
                {
                    var to0 = SpotOf(a);
                    A.X.SetValue(to0.x); A.Y.SetValue(to0.y); A.S.SetValue(1);
                    Animated.Timing(A.O, Timing(1, 140)).Start();
                    continue;
                }
                // out of the middle of the inside, into the tray, one after another
                A.X.SetValue(_g.Ix + _g.W / 2 - _P / 2 + (Random() - 0.5) * _g.W * 0.35);
                A.Y.SetValue(_g.Iy + _g.H * 0.45 - _P / 2 + (Random() - 0.5) * _g.H * 0.3);
                A.S.SetValue(0.75);
                double delay = n * 85;
                n += 1;
                var place = a;
                Later(delay, () =>
                {
                    var to = SpotOf(place);
                    Animated.Parallel(
                        Animated.Timing(A.O, Timing(1, 90)),
                        Animated.Timing(A.X, Timing(to.x, 560, Easing.Out(Easing.Quad))),
                        Animated.Sequence(
                            Animated.Timing(A.Y, Timing(Math.Min(to.y, _g.Iy) - 60, 230, Easing.Out(Easing.Quad))),
                            Animated.Timing(A.Y, Timing(to.y, 330, Easing.Bounce))),
                        Animated.Timing(A.S, Timing(_trayScale, 560))).Start();
                });
            }
            Later(n * 85 + 650, StartPlace);
        }

        void OpenUp()
        {
            Phase = "open";
            Snd.Play("fs_doorOpen");
            Snd.Place();
            Animated.Timing(_door, Timing(1, 440, Easing.Out(Easing.Back(1.5)))).Start();
            var vs = new[] { 0.9, 0.2, 1, 0.5, 1 }; var ms = new double[] { 90, 60, 90, 50, 120 };
            var seq = new CompositeAnimation[5];
            for (int i = 0; i < 5; i++) seq[i] = Animated.Timing(_light, Timing(vs[i], ms[i]));
            Animated.Sequence(seq).Start();
            Later(230, Tumble);
        }

        CompositeAnimation T(AnimatedValue v, double to, double ms, Func<double, double> ease = null) => Animated.Timing(v, Timing(to, ms, ease ?? Easing.InOut(Easing.Quad)));

        void Shake()
        {
            Phase = "shake";
            _showInside = false;
            _foodMoved = true;
            Say("SHAKE SHAKE!", hold: 900);
            Snd.Play("fs_rattle");
            var steps = new List<CompositeAnimation>();
            for (int i = 0; i < 9; i++)
            {
                int s = i % 2 != 0 ? -1 : 1;
                steps.Add(Animated.Parallel(T(_rot, s * (3 + i * 0.35), 85), T(_tx, s * 5, 85)));
            }
            steps.Add(Animated.Parallel(T(_rot, 0, 80), T(_tx, 0, 80)));
            var rattle = Animated.Sequence(steps);
            CompositeAnimation Jump(double height, double spin) => Animated.Sequence(
                Animated.Parallel(T(_sq, 0.6, 90)),
                Animated.Parallel(T(_ty, -height, 250, Easing.Out(Easing.Quad)), T(_sq, -1, 250), T(_rot, spin, 250)),
                Animated.Parallel(T(_ty, 0, 210, Easing.In(Easing.Quad)), T(_sq, 0, 210), T(_rot, 0, 210)));
            rattle.Start(r0 =>
            {
                if (!r0.Finished || !Alive) return;
                Snd.Play("fs_jump");
                Jump(34, -5).Start(r1 =>
                {
                    if (!r1.Finished || !Alive) return;
                    Land();
                    Animated.Sequence(T(_sq, 1, 70), Animated.Spring(_sq, Spring(0, 4, 160))).Start(r2 =>
                    {
                        if (!r2.Finished || !Alive) return;
                        Snd.Play("fs_jump", rate: 1.12);
                        Jump(52, 7).Start(r3 =>
                        {
                            if (!r3.Finished || !Alive) return;
                            Land();
                            Animated.Sequence(T(_sq, 1, 70), Animated.Spring(_sq, Spring(0, 3.5, 160))).Start();
                            Later(380, OpenUp);
                        });
                    });
                });
            });
        }

        void Land()
        {
            Snd.Play("fs_land");
            Snd.Place();
            Spray("dust", _g.Bx + 26, _g.By + _g.BodyH + 8, 1.4);
            Spray("dust", _g.Bx + _g.BodyW - 26, _g.By + _g.BodyH + 8, 1.4);
        }

        bool Alive => _started && !_exited;
        bool _exited;

        void CloseUp()
        {
            Phase = "close";
            Animated.Parallel(Animated.Timing(_door, Timing(0, 400, Easing.In(Easing.Quad))), Animated.Timing(_light, Timing(0, 380))).Start(r =>
            {
                if (!r.Finished || !Alive) return;
                Snd.Play("fs_doorClose");
                Snd.Place();
                Animated.Sequence(Animated.Timing(_sq, Timing(0.45, 60)), Animated.Spring(_sq, Spring(0, 4, 180))).Start();
                Later(320, Shake);
            });
        }

        void Peek()
        {
            Phase = "peek";
            Snd.Play("fs_peek");
            Say("REMEMBER!", hold: 700, sub: Board.Swaps.Count > 0 ? "Keep watching until the doors shut!" : null);
            _peekBar.SetValue(1);
            Animated.Timing(_peekBar, Timing(0, Spec.PeekMs, Easing.Linear)).Start();
            int secsN = (int)Math.Ceiling(Spec.PeekMs / 1000.0);
            _peekLeft = secsN;
            for (int s = 1; s < secsN; s++) { int left = secsN - s; Later(Spec.PeekMs - (secsN - s) * 1000, () => { _peekLeft = left; if (left <= 3) { Snd.Play("sd_tick"); Snd.Tick(); } }); }
            for (int i = 0; i < Board.Swaps.Count; i++)
            {
                var pair = Board.Swaps[i];
                Later(Spec.PeekMs - 450 - (Board.Swaps.Count - i) * 820, () => SwapNow(pair[0] ?? -1, pair[1] ?? -1));
            }
            Later(Spec.PeekMs, CloseUp);
        }

        void Deal()
        {
            Phase = "deal";
            Animated.Timing(_clutterIn, Timing(1, 260)).Start();
            int n = 0;
            foreach (var kv in Board.Start)
            {
                int k = kv.Value;
                int nn = n;
                Later(n * 110, () => { Animated.Spring(_ins[k].S, Spring(1, 4, 170)).Start(); Snd.Play("fs_pop", rate: 0.9 + nn * 0.07); });
                n++;
            }
            Later(n * 110 + 380, Peek);
        }

        // a new deal: reset everything and start (Game.js's effect on [board, readyKey])
        void NewRound()
        {
            _deal++;
            ClearTimers();
            _effects.Clear();
            StopInterval();
            Close(ref _result, true);
            Close(ref _fail);
            Close(ref _pause);
            var rec = Levels.Record(Profile);
            if (_blitz) Spec = Levels.BlitzSpec(_idx, rec.BSkill);
            else Spec = Levels.LevelSpec(_lv, rec.Of(_theme).Skill);
            Board = MakeBoardHook != null ? MakeBoardHook(Spec) : Sort.Board.MakeBoard(Spec, _data.Pools[_theme], Random, Props.Kinds);
            _m = SortModels.ModelOf(_theme, Spec.Model);
            _tg = TrayWide(AreaW, AreaH, Board.TrayCap);
            _g = Geometry(AreaW - _tg.Tw - 20, AreaH, Spec.Rows, Spec.Cols, _m, 0);
            _P = JsRound(_g.S * 0.8); _Q = JsRound(_g.S * 0.74);
            _trayScale = Math.Min(1, _tg.Cell * 0.94f / _P);
            if (_anims != null) foreach (var A in _anims) { A.Wob.Unmount(); A.Pulse.Unmount(); }
            _ins = new InsideAnim[Board.Pieces.Count];
            _anims = new PieceAnim[Board.Pieces.Count];
            for (int k = 0; k < _ins.Length; k++) { _ins[k] = new InsideAnim(); _anims[k] = new PieceAnim(); }

            _clk.Reset();
            _paused = false;
            _selected = null; _dragK = null;
            _bannerOn = false;
            _mistakes = 0;
            _left = 0;
            _play = Sort.Board.StartState(Board);
            _showInside = true;
            _foodMoved = false;
            _clutterIn.SetValue(0);
            _insideNow = new Dictionary<int, int>(Board.Start);
            _door.SetValue(1); _light.SetValue(1);
            _rot.SetValue(0); _tx.SetValue(0); _ty.SetValue(0); _sq.SetValue(0);
            _hoverO.SetValue(0);
            _pop.SetValue(0);
            foreach (var kv in Board.Start) { var p = InsideXY(kv.Key); _ins[kv.Value].X.SetValue(p.x); _ins[kv.Value].Y.SetValue(p.y); }
            Phase = "intro";
            // a bigger fridge (or cupboard) gets its own hello, a new shelf a chip
            bool bigger = !_blitz && Spec.First && Spec.Lv > 1;
            var chips = new List<string>();
            if (bigger) chips.Add($"LEVEL {Spec.Lv}");
            chips.Add(_blitz ? "SNACK FRIDGE" : Levels.TIER_NAMES[Spec.Tier]);
            if (Spec.More && !_blitz) chips.Add("+1 SHELF");
            if (Spec.Decoys > 0) chips.Add($"{Spec.Decoys} IMPOSTOR{(Spec.Decoys > 1 ? "S" : "")}");
            if (Spec.Swaps > 0) chips.Add("SNEAKY SWAP");
            if (Spec.Mixed > 0) chips.Add("MIXED UP");
            var sub = $"{_m.Size} · {_m.Name.ToUpperInvariant()}";
            if (bigger) Say(_theme == "fridge" ? "BIGGER FRIDGE!" : "BIGGER CUPBOARD!", chips: chips.ToArray(), sub: sub, small: true, hold: 1400);
            else Say(_blitz ? $"ROUND {Spec.Round}" : $"LEVEL {Spec.Lv}", chips: chips.ToArray(), sub: sub, hold: 900);
            Snd.Play("sd_boardIn");
            Animated.Spring(_pop, Spring(1, 6, 70)).Start();
            // (the app waits for any picture still downloading; Unity's are all here)
            Later(bigger ? 1800 : 1300, Deal);
            if (!_blitz) OnLevel?.Invoke(_lv);
        }

        // the result card's three: the board's first three that have a home, topped up from the theme's pool (Game.js
        // trio; a piece's cut-out "Stack/art/<key>" names its rig)
        string[] Trio()
        {
            static string KeyOf(string uri) => uri == null ? null : uri.Substring(uri.LastIndexOf('/') + 1);
            var want = new List<string>();
            foreach (var p in Board.Pieces) if (p.Home != null && want.Count < 3) want.Add(KeyOf(p.Uri));
            var pool = new List<string>();
            if (_data.Pools.TryGetValue(_theme, out var l)) foreach (var e in l) pool.Add(KeyOf(e.Uri));
            return GameCards.TrioOf(want, pool);
        }

        void Next() { _lv = Math.Min(Levels.LEVELS, _lv + 1); Replay(); }
        void Replay() { _round++; NewRound(); }

        // ---- pause and leaving ------------------------------------------------------------------------------------
        public void Pause()
        {
            if (Phase != "place" || _paused) return;
            _clk.Pause();
            _paused = true;
            StopInterval();
            _pause = Open(SortCards.PauseCard(_sw, _sh, Resume, Leave), 2);
        }

        void Resume()
        {
            _paused = false;
            Close(ref _pause);
            _clk.Resume();
            if (Phase == "place") Effect(StartInterval);
        }

        void Leave()
        {
            ClearTimers();
            StopInterval();
            _clk.Reset();
            if (_blitz) PayOut();
            _exited = true;
            OnExit?.Invoke();
        }

        /// <summary>Android's back: a pause resumes, sorting pauses, anything else leaves.</summary>
        public void Back()
        {
            if (_paused) Resume();
            else if (Phase == "place") Pause();
            else if (_blitz && _blitzCard == "save") EndRun();
            else if (_blitz && Phase == "held") return;
            else Leave();
        }

        // the profile update as Firestore takes it: dotted field paths into nested maps
        void Apply(Dictionary<string, object> update)
        {
            foreach (var kv in update)
            {
                var parts = kv.Key.Split('.');
                IDictionary<string, object> m = Profile;
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (!(m.TryGetValue(parts[i], out var next) && next is IDictionary<string, object> nm)) { nm = new Dictionary<string, object>(); m[parts[i]] = nm; }
                    m = nm;
                }
                m[parts[parts.Length - 1]] = kv.Value;
            }
        }

        // ---- the banner ------------------------------------------------------------------------------------------
        readonly AnimatedValue _bannerT = new AnimatedValue(0);
        CompositeAnimation _bannerAnim;
        bool _bannerOn;
        string _bannerMarkup;
        float _bannerH;

        void Say(string text, bool small = false, string ink = null, double hold = 700, string sub = null, string[] chips = null)
        {
            (_bannerMarkup, _bannerH) = SortArt.Banner(AreaW, text, small, ink, chips, sub);
            _bannerOn = true;
            Effect(() =>
            {
                _bannerT.SetValue(0);
                _bannerAnim?.Stop();
                _bannerAnim = Animated.Sequence(
                    Animated.Spring(_bannerT, Spring(1, 5, 140)),
                    Animated.Timing(_bannerT, Timing(1, hold)),
                    Animated.Timing(_bannerT, Timing(2, 220, Easing.In(Easing.Quad))));
                _bannerAnim.Start();
            });
        }

        // ---- touch (screen dp) ------------------------------------------------------------------------------------
        sealed class Touch { public float X0, Y0; public int? K; public bool Moved; }
        Touch _touch;
        bool _cardDown, _backDown;
        public (float x, float y, float size) BackOrb = (12, 12, 40);

        bool CardOpen { get { if (BCardOpen) return true; foreach (var c in _cards) if (c.Visible) return true; return false; } }

        int? HitPiece(float x, float y)
        {
            for (int k = Board.Pieces.Count - 1; k >= 0; k--)
            {
                if (_play.Locked.Contains(k) || _play.Gone.Contains(k)) continue;
                var loc = _play.At[k];
                var c = loc.IsSlot ? SlotCenter(_g, loc.I) : TrayCenter(_tg, loc.I);
                float half = loc.IsSlot ? _g.S / 2 : _tg.Cell / 2;
                if (Math.Abs(x - c.x) <= half && Math.Abs(y - c.y) <= half) return k;
            }
            return null;
        }

        Place TargetAt(float x, float y)
        {
            int i = SlotAt(_g, x, y);
            if (i >= 0) return Place.Slot(i);
            if (x >= _tg.Tx - 14 && x <= _tg.Tx + _tg.Tw + 14 && y >= _tg.Ty - 20 && y <= _tg.Ty + _tg.Th + 14) return Place.Tray();
            return null;
        }

        void ShowHover(float x, float y)
        {
            int i = SlotAt(_g, x, y);
            if (i < 0) { _hoverO.SetValue(0); return; }
            var c = SlotCenter(_g, i);
            _hoverX.SetValue(c.x - _g.S / 2); _hoverY.SetValue(c.y - _g.S / 2); _hoverO.SetValue(1);
        }

        // a tap on the cards: the run's first (they're over the level's), then the level's
        void CardsTap(bool down, float sx, float sy)
        {
            for (int i = _bcards.Count - 1; i >= 0; i--) if (_bcards[i].Visible && (down ? _bcards[i].Down(sx, sy) : _bcards[i].Up(sx, sy))) return;
            for (int i = _cards.Count - 1; i >= 0; i--) if (down ? _cards[i].Down(sx, sy) : _cards[i].Up(sx, sy)) break;
        }

        public void Down(float sx, float sy)
        {
            if (CardOpen) { CardsTap(true, sx, sy); _cardDown = true; return; }
            if (Math.Abs(sx - (BackOrb.x + 20)) <= 26 && Math.Abs(sy - (BackOrb.y + 20)) <= 26) { _backDown = true; return; }
            float x = sx - AreaX, y = sy;
            if (x < 0 || x > AreaW || Phase != "place" || _paused) return;
            _touch = new Touch { X0 = x, Y0 = y, K = HitPiece(x, y) };
        }

        public void Move(float sx, float sy)
        {
            var T = _touch;
            if (T == null || T.K == null) return;
            float x = sx - AreaX, y = sy;
            int k = T.K.Value;
            if (!T.Moved)
            {
                if (Math.Sqrt((x - T.X0) * (x - T.X0) + (y - T.Y0) * (y - T.Y0)) < 9) return;
                T.Moved = true;
                Snd.Play("fs_pick");
                Snd.Tap();
                _dragK = k;
                _selected = null;
                Animated.Parallel(Animated.Spring(_anims[k].S, Spring(1.06, 6, 160)), Animated.Timing(_anims[k].Lift, Timing(1, 120))).Start();
            }
            // held a little above the finger, so it can be seen
            _anims[k].X.SetValue(x - _P / 2);
            _anims[k].Y.SetValue(y - _P / 2 - _g.S * 0.42);
            ShowHover(x, y - _g.S * 0.42f);
        }

        public void Up(float sx, float sy)
        {
            if (_cardDown)
            {
                _cardDown = false;
                CardsTap(false, sx, sy);
                return;
            }
            if (_backDown)
            {
                _backDown = false;
                if (Phase == "place") Pause(); else Leave();
                return;
            }
            var T = _touch;
            _touch = null;
            if (T == null || Phase != "place") return;
            float x = sx - AreaX, y = sy;
            if (T.Moved && T.K != null)
            {
                _dragK = null;
                float yy = y - _g.S * 0.42f;
                HandleDrop(T.K.Value, TargetAt(x, yy));
                return;
            }
            // a tap: pick one up, put the picked one down there, or let go of it
            var sel = _selected;
            if (T.K != null && (sel == null || (_play.At[T.K.Value].IsTray && T.K != sel))) { _selected = T.K; Snd.Play("fs_pick"); Snd.Tap(); return; }
            if (sel != null && T.K == sel) { _selected = null; Snd.Play("fs_drop"); return; }
            if (sel != null)
            {
                var target = TargetAt(x, y);
                if (target != null) HandleDrop(sel.Value, target);
                else _selected = null;
            }
        }

        // ---- drawing -----------------------------------------------------------------------------------------------
        readonly List<SortLayer> _layers = new List<SortLayer>();
        public IReadOnlyList<SortLayer> Layers => _layers;
        readonly Dictionary<string, SortLayer> _byName = new Dictionary<string, SortLayer>();
        // a layer's markup, made again only when what it shows (`key`) changes
        readonly Dictionary<string, (string key, string markup)> _memo = new Dictionary<string, (string, string)>();
        void SetM(SortLayer l, string key, Func<string> make, float w, float h, float margin)
        {
            if (!_memo.TryGetValue(l.Name, out var e) || e.key != key) _memo[l.Name] = e = (key, make());
            l.Set(e.markup, w, h, margin);
        }
        int _deal;
        SortLayer L(string name) { if (!_byName.TryGetValue(name, out var l)) _byName[name] = l = new SortLayer(name); _layers.Add(l); return l; }

        static double Lerp(double v, double[] input, double[] output, bool clamp = false)
        {
            if (clamp) v = Math.Max(input[0], Math.Min(input[input.Length - 1], v));
            int i = 1;
            while (i < input.Length - 1 && v > input[i]) i++;
            double i0 = input[i - 1], i1 = input[i];
            return output[i - 1] + (v - i0) / (i1 - i0) * (output[i] - output[i - 1]);
        }

        static Affine About(double w, double h, Affine m) => Affine.Translate(w / 2, h / 2) * m * Affine.Translate(-w / 2, -h / 2);

        /// <summary>Works out every layer for the clock's now (call after Ticker.Default.Tick).</summary>
        public void Update()
        {
            if (!_started || Board == null) return;
            while (_effects.Count > 0) { var fx = _effects.ToArray(); _effects.Clear(); foreach (var f in fx) f(); }
            SyncLoops();
            _layers.Clear();
            var area = Affine.Translate(AreaX, 0);

            // ---- the HUD's left column
            string barLabel; bool showBar = true, red = false; string[] barColors; double frac;
            if (Phase == "peek" || Phase == "deal") { barLabel = Phase == "peek" ? $"REMEMBER! {_peekLeft}" : "GET READY"; barColors = new[] { "#ffe45c", "#ff8a3d" }; frac = _peekBar.GetValue(); }
            else if (Phase == "place" || Phase == "won" || Phase == "lost" || _blitz)
            {
                // (Blitz: the round's clock shows all the time, stopped between the sorting)
                barLabel = Levels.Clock(_left > 0 ? _left * 1000.0 : Spec.LimitMs);
                red = Phase == "place" && _left <= 10;
                barColors = new[] { "#b8ffd9", "#3ddc97" }; frac = _clk.Frac.GetValue();
            }
            else { barLabel = Phase == "shake" || Phase == "close" ? "SHAKING…" : " "; showBar = false; barColors = null; frac = 1; }
            var hud = new SortArt.Hud { Theme = _theme, ModelName = _m.Name, Lv = Spec.Lv, Tier = Spec.Tier, BarLabel = barLabel, BarRed = red, ShowBar = showBar,
                Blitz = _blitz, Round = Spec.Round ?? 0 };
            SetM(L("left column"), $"{_deal}|{barLabel}|{red}|{showBar}|{hud.Revived}", () => SortArt.LeftColumn(hud, _sh), SortArt.LeftW, _sh, 4);
            var hl = SortArt.HudLayout(hud);
            for (int i = 0; i < (_blitz ? 0 : Levels.HEARTS); i++)
            {
                bool on = i < Levels.HEARTS - _mistakes;
                if (on != _heartOn[i])
                {
                    _heartOn[i] = on;
                    if (on) { _hearts[i].StopAnimation(); _hearts[i].SetValue(1); }
                    else Animated.Sequence(Animated.Timing(_hearts[i], Timing(1.6, 120)), Animated.Spring(_hearts[i], Spring(0, 5, 120))).Start();
                }
                float hx = hl.heartsX + 2 + 8 + i * 27, hy = hl.heartsY + 2 + 5;
                var e = L("heart empty " + i); SetM(e, "", SortArt.HeartEmpty, 24, 24, 3); e.Transform = Affine.Translate(hx, hy);
                var f = L("heart " + i); SetM(f, "", SortArt.HeartFull, 24, 24, 3);
                double t = _hearts[i].GetValue();
                double sc = Lerp(t, new[] { 0, 1, 1.6 }, new[] { 0.4, 1, 1.35 }, true);
                f.Opacity = (float)Lerp(t, new[] { 0, 0.3, 1.6 }, new[] { 0.0, 1, 1 }, true);
                f.Transform = Affine.Translate(hx, hy) * About(24, 24, Affine.ScaleBy(sc, sc));
            }
            if (showBar)
            {
                var fl = L("bar fill");
                float shift = (float)((1 - Math.Max(0, Math.Min(1, frac))) * hl.trackW);
                SetM(fl, $"{hl.trackW}|{barColors[0]}|{shift}", () => SortArt.BarFill(hl.trackW, barColors, shift), hl.trackW, 14, 1);
                fl.Transform = Affine.Translate(hl.trackX, hl.barY + 8);
            }
            var back = L("back"); back.Set(_data.BackXml, 40, 40); back.Transform = Affine.Translate(BackOrb.x, BackOrb.y);

            // ---- the tray
            var tray = L("tray");
            SetM(tray, _deal.ToString(), () => SortArt.Tray(SortModels.THEMES[_theme], _tg, Board.TrayCap), _tg.Tw, _tg.Th, 12);
            tray.Transform = area * Affine.Translate(_tg.Tx, _tg.Ty);

            // ---- the container, shaking as one: translate, squash and turn about its middle, popped in
            double sq = _sq.GetValue();
            double wrapW = _g.BodyW, wrapH = _g.BodyH + _g.Feet;
            var wrapM = Affine.Translate(_tx.GetValue(), _ty.GetValue())
                * Affine.Translate(0, Lerp(sq, new[] { -1.0, 0, 1 }, new[] { -_g.BodyH * 0.035, 0, _g.BodyH * 0.05 }))
                * Affine.Rotate(Lerp(_rot.GetValue(), new[] { -10.0, 10 }, new[] { -10.0, 10 }))
                * Affine.ScaleBy(Lerp(sq, new[] { -1.0, 0, 1 }, new[] { 0.95, 1, 1.09 }), Lerp(sq, new[] { -1.0, 0, 1 }, new[] { 1.07, 1, 0.9 }));
            double pop = Lerp(_pop.GetValue(), new[] { 0.0, 1 }, new[] { 0.6, 1 });
            wrapM = wrapM * Affine.ScaleBy(pop, pop);
            var wrap = area * Affine.Translate(_g.Bx, _g.By) * About(wrapW, wrapH, wrapM);
            var body = L("body"); SetM(body, _deal.ToString(), () => SortArt.Body(_m, _g), _g.BodyW, _g.BodyH + _g.Feet, 4); body.Transform = wrap;
            var inside = wrap * Affine.Translate(SortArt.InsideX, SortArt.InsideY(_g));
            float hd = _g.H + _g.Crisper;
            var ib = L("inside back"); SetM(ib, _deal.ToString(), () => SortArt.InsideBack(_m, _g), _g.W, hd, 1); ib.Transform = inside;
            var lamp = L("lamp"); SetM(lamp, _deal.ToString(), () => SortArt.Lamp(_m, _g), _g.W, hd, 1); lamp.Transform = inside; lamp.Opacity = (float)_light.GetValue();
            var inf = L("inside front"); SetM(inf, _deal.ToString(), () => SortArt.InsideFront(_m, _g), _g.W, hd, 1); inf.Transform = inside;
            var cl = L("clutter");
            SetM(cl, $"{_deal}|{_foodMoved}", () => SortArt.Clutter(_m, _g, _foodMoved ? Board.FoodAfter : Board.FoodBefore, _Q, _data.Props[_theme]), _g.W, hd, 1);
            cl.Transform = inside; cl.Opacity = (float)_clutterIn.GetValue();
            if (_showInside)
                foreach (var kv in Board.Start)
                {
                    int k = kv.Value;
                    var p = L("inside " + k);
                    p.SetPicture(Board.Pieces[k].Uri, _P, _P);
                    double s = _ins[k].S.GetValue();
                    p.Transform = inside * Affine.Translate(_ins[k].X.GetValue(), _ins[k].Y.GetValue()) * About(_P, _P, Affine.ScaleBy(s, s));
                    p.Visible = p.Picture != null;
                }
            // the doors: the front until the door has turned 90°, then its inside
            double door = _door.GetValue();
            for (int i = 0; i < _m.Doors; i++)
            {
                var (dx, dy, dw, dh, hinge) = SortArt.DoorBox(_m, _g, i);
                double sign = hinge == "left" ? -1 : 1;
                double fcut = Math.Min(0.998, 90 / _g.Deg);
                double frontOp = Math.Max(0, Math.Min(1, Lerp(door, new[] { 0, fcut, fcut + 0.001, 1 }, new[] { 1.0, 1, 0, 0 })));
                var view = new DoorView { W = dw, H = dh, Sign = (float)sign, Persp = _g.Persp, Deg = door * sign * _g.Deg, Post = wrap * Affine.Translate(dx, dy) };
                var fr = L("door front " + i); int di = i; SetM(fr, _deal.ToString(), () => SortArt.DoorFront(_m, di, hinge, dw, dh), dw, dh, 2); fr.Door = view; fr.Opacity = (float)frontOp; fr.Visible = frontOp > 0;
                var bk = L("door back " + i); SetM(bk, _deal.ToString(), () => SortArt.DoorBack(_m, dw, dh), dw, dh, 2); bk.Door = view; bk.Opacity = (float)(1 - frontOp); bk.Visible = frontOp < 1;
            }
            // the spot under a dragged squishy
            var hov = L("hover"); SetM(hov, _g.S.ToString(), () => SortArt.Hover(_g.S), _g.S, _g.S, 2);
            hov.Transform = area * Affine.Translate(_hoverX.GetValue(), _hoverY.GetValue()); hov.Opacity = (float)_hoverO.GetValue();
            // the squishies in play, from the tumble on (hidden behind the shut doors before); the held one on top
            bool inPlay = !_showInside && Phase != "shake" && Phase != "close";
            if (inPlay)
            {
                var order = new List<int>();
                for (int k = 0; k < Board.Pieces.Count; k++) if (!(k == _dragK || k == _selected)) order.Add(k);
                for (int k = 0; k < Board.Pieces.Count; k++) if (k == _dragK || k == _selected) order.Add(k);
                foreach (var k in order) DrawPiece(k, area);
            }
            if (_bannerOn)
            {
                double t = _bannerT.GetValue();
                var bn = L("banner"); bn.Set(_bannerMarkup, AreaW, _bannerH, 12);
                bn.Opacity = (float)Lerp(t, new[] { 0.0, 0.2, 1, 2 }, new[] { 0.0, 1, 1, 0 });
                double bs = Lerp(t, new[] { 0.0, 1, 2 }, new[] { 0.3, 1, 1.25 }), br = Lerp(t, new[] { 0.0, 1, 2 }, new[] { -12.0, -3, 0 });
                bn.Transform = area * Affine.Translate(0, Math.Max(0, _g.By - 34)) * About(AreaW, _bannerH, Affine.ScaleBy(bs, bs) * Affine.Rotate(br));
            }
            DrawFx(area);
            if (_blitz) RefreshSave();
            foreach (var c in _cards) c.Update();
            _cards.RemoveAll(c => !c.Shown);
            foreach (var c in _bcards) c.Update();
            _bcards.RemoveAll(c => !c.Shown);
        }

        // ---- the effects (squishdoku/fx.js FxLayer over the game: the dust, sparks, poofs, angry puffs and confetti) -----
        readonly List<(int id, Burst b)> _fx = new List<(int, Burst)>();
        int _fxId;
        void Spray(string kind, double x, double y, double scale = 1)
        {
            var b = new Burst(kind, x, y, scale);
            _fx.Add((_fxId++, b));
            b.Start();
        }
        void DrawFx(Affine area)
        {
            for (int i = _fx.Count - 1; i >= 0; i--)
            {
                var (id, b) = _fx[i];
                if (b.Done) { for (int j = 0; j < b.Layers.Count; j++) _byName.Remove($"fx {id} {j}"); _fx.RemoveAt(i); continue; }
                b.Place(area, 1);
                for (int j = 0; j < b.Layers.Count; j++)
                {
                    var c = b.Layers[j];
                    var l = L($"fx {id} {j}");
                    l.Set(c.Markup, c.W, c.H, c.Margin);
                    l.Transform = c.Transform; l.Opacity = c.Opacity; l.Visible = c.Visible;
                }
            }
        }
        (float x, float y) CenterOf(int k) => ((float)_anims[k].X.GetValue() + _P / 2, (float)_anims[k].Y.GetValue() + _P / 2);

        void DrawPiece(int k, Affine area)
        {
            var A = _anims[k];
            var pc = Board.Pieces[k];
            bool mixed = Phase == "place" && !_play.Gone.Contains(k) && _play.At[k].IsSlot && !_play.Locked.Contains(k);
            bool selected = _selected == k, locked = _play.Locked.Contains(k);
            double lift = A.Lift.GetValue() + Lerp(A.Pulse.Value, new[] { 0.0, 1 }, new[] { 0, 0.35 });
            double rot = Lerp(A.Wob.Value, new[] { -1.0, 1 }, new[] { -9.0, 9 });
            double s = A.S.GetValue() * Lerp(lift, new[] { 0, 1.35 }, new[] { 1, 1.16 });
            var m = area * Affine.Translate(A.X.GetValue() + A.Shake.GetValue(), A.Y.GetValue() + A.Hop.GetValue() + Lerp(lift, new[] { 0, 1.35 }, new[] { 0.0, -11 }))
                    * About(_P, _P, Affine.ScaleBy(s, s) * Affine.Rotate(rot));
            float op = (float)A.O.GetValue();
            // a soft floor shadow, smaller while lifted
            float sw = _P * 0.74f, sh = _P * 0.14f;
            var sd = L("shadow " + k); SetM(sd, _P.ToString(), () => SortArt.PieceShadow(sw, sh), sw, sh, 1);
            sd.Transform = m * Affine.Translate((_P - sw) / 2, _P - sh) * About(sw, sh, Affine.ScaleBy(Lerp(lift, new[] { 0, 1.35 }, new[] { 1, 0.7 }), 1));
            sd.Opacity = op * (float)Lerp(lift, new[] { 0, 1.35 }, new[] { 1, 0.5 });
            if (selected) { var r = L("selected " + k); SetM(r, _P.ToString(), () => SortArt.SelRing(_P), _P, _P, 2); r.Transform = m; r.Opacity = op; }
            var img = L("squishy " + k); img.SetPicture(pc.Uri, _P, _P); img.Transform = m; img.Opacity = op; img.Visible = pc.Uri != null;
            if (mixed) { var h = L("huh " + k); SetM(h, "", SortArt.Huh, 22, 22, 2); h.Transform = m * Affine.Translate(_P + 2 - 22, -4); h.Opacity = op; }
            if (locked)
            {
                double t = A.Tick.GetValue();
                var tk = L("tick " + k); SetM(tk, "", SortArt.Tick, 20, 20, 2);
                tk.Transform = m * Affine.Translate(_P - 2 - 20, _P - 2 - 20) * About(20, 20, Affine.ScaleBy(t, t));
                tk.Opacity = op * (float)Math.Max(0, Math.Min(1, t));
            }
        }

        // the pieces' loops, on and off as the app's components mount them (after the state that turns them on)
        void SyncLoops()
        {
            bool inPlay = !_showInside && Phase != "shake" && Phase != "close";
            for (int k = 0; k < _anims.Length; k++)
            {
                var A = _anims[k];
                bool mixed = inPlay && Phase == "place" && !_play.Gone.Contains(k) && _play.At[k].IsSlot && !_play.Locked.Contains(k);
                bool sel = inPlay && _selected == k;
                if (mixed != A.WobOn) { A.WobOn = mixed; if (mixed) A.Wob.Mount(); else A.Wob.Unmount(); }
                if (sel != A.PulseOn) { A.PulseOn = sel; if (sel) A.Pulse.Mount(); else A.Pulse.Unmount(); }
            }
        }

        // ---- for tests and CI screenshots -----------------------------------------------------------------------------
        public ContainerGeo Geo => _g;
        public TrayGeo TrayGeo => _tg;
        public float PieceSize => _P;
        public int Mistakes => _mistakes;
        public PlayState Play => _play;
    }
}
