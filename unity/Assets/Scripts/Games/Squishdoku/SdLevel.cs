// One Regular level of Squishdoku and the ones after it, as src/squishdoku/RegularGame.js plays it, in landscape
// (REDESIGN_V8): the Crib's room behind (hop/Room.js), the board of plush cushions lying on its floor (RoomBoard.js), the
// top bar, the score creatures and the clock in a column on the left (Hud.js), the buddy and the tools on the right.
//   intro    the cushions cascade in, LEVEL n pops; HEAD START's creature drops in; then the clock starts
//   play     tap a cushion to place a creature (right: it drops on, its patch ripples, everyone hops; wrong: it shakes its
//            head and poofs, the board shakes, the cell gets its ✕ a moment later, and from level 46 a heart goes);
//            long-press or the MARK tool to mark ✕ (drag to paint); tap a placed creature to wiggle it. The score
//            creatures fall off as the times A and B pass; a ✕ or a mistake ends the PERFECT run
//   solved   everyone hops row by row, confetti, the result card 1700 ms after: MAP / REPLAY / NEXT
//   timeup   the clock ran out: the board shakes, TIME'S UP (RETRY / MAP);  out / nohearts: the last heart went
//   paused   the top bar's pause (or Android's back): the board is hidden, the clock frozen (RESUME / RESTART / QUIT)
// Every motion is the app's (SquishSquad.Anim is React Native's Animated; the same timings, springs, easings, delays).
// No UnityEngine here: SquishdokuGame shows the layers and feeds the touches; tools/unity/squishdoku-test runs it as is.
// Not ported: sounds, haptics, saving to Firestore (Profile is kept in memory), the buddy's live rig (its still hops
// and shakes instead), Blitz.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdLevel
    {
        // ---- the host's ------------------------------------------------------------------------------------------------
        /// <summary>The player's profile (the `sdk` record), in memory until Firebase.</summary>
        public static IDictionary<string, object> Profile = new Dictionary<string, object>();
        /// <summary>Leaving (MAP, QUIT, back once it's over): the level the player unlocked, if any.</summary>
        public Action<int?> OnExit;
        /// <summary>The level now playing changed (NEXT).</summary>
        public Action<int> OnLevel;
        /// <summary>Math.random (tricks, bursts, the buddy's words, which creatures).</summary>
        public static Func<double> Random = new System.Random().NextDouble;

        readonly float W, H;               // the screen, dp
        readonly Ticker _tk;
        readonly SdCreature[] _cast;       // the player's creatures (the board's pieces and the score heads)
        readonly SdCreature _buddy;
        readonly Func<string, string> _xml;   // exported pieces (Resources/Squishdoku/<name>.xml)
        int _lv, _attempt;
        readonly bool _head;
        int? _unlocked;

        public SdLevel(float screenW, float screenH, int startLv, bool head, SdCreature[] cast, SdCreature buddy, Func<string, string> xml, Ticker tk)
        {
            W = screenW; H = screenH; _lv = startLv; _head = head; _cast = cast; _buddy = buddy; _xml = xml; _tk = tk;
            Ticker.Default = tk;
            AreaX = SdArt.LeftW; AreaW = W - SdArt.LeftW - SdArt.RightW;
            _input = true;
            BuildFixed();
            NewBoard();
            _input = false;
        }

        // React: what a state change starts (an effect: a view mounting and its animation, an interval, a card opening)
        // runs once the change is rendered. A change made by a touch is rendered before the next frame; one made by a
        // timer during a frame, at that frame's end (a frame callback here), as the app's page does on its clock.
        bool _input;
        void Effect(Action a) { if (_input) a(); else _tk.RequestAnimationFrame(a); }
        void AsInput(Action a) { bool was = _input; _input = true; try { a(); } finally { _input = was; } }

        // ---- state (RegularGame.js) --------------------------------------------------------------------------------------
        public LevelSpec Spec { get; private set; }
        public string Phase { get; private set; } = "loading";   // intro | play | paused | solved | result | timeup | out | nohearts
        public int Lv => _lv;
        bool _xTool, _perfect = true, _warn;
        int _left = 3, _heartsLost;
        string _label = "";
        SdCreature[] _pieces, _score;
        int _given = -1;
        int _placedCount, _mistakes, _combo, _lastSecond = -1, _gLeft = 3;
        bool _usedX;
        readonly List<int> _timers = new List<int>();
        int _interval = -1;
        bool _bannerShown;
        public bool XTool => _xTool;

        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));
        void ClearTimers() { foreach (var t in _timers) _tk.ClearTimeout(t); _timers.Clear(); }

        // pickCreatures: k creatures from the roster at random (each once while there are any left), then round again
        SdCreature[] Pick(SdCreature[] roster, int k)
        {
            var pool = new List<SdCreature>(roster);
            var o = new List<SdCreature>();
            while (o.Count < k && pool.Count > 0) { int i = (int)Math.Floor(Random() * pool.Count); o.Add(pool[i]); pool.RemoveAt(i); }
            while (o.Count < k) o.Add(roster.Length > 0 ? roster[o.Count % roster.Length] : null);
            return o.ToArray();
        }

        // ---- a new board ---------------------------------------------------------------------------------------------------
        void NewBoard()
        {
            ClearTimers();
            StopInterval();
            Spec = Levels.SpecOf(_lv, _head);
            _xTool = false; _left = 3; _heartsLost = 0; _perfect = true; _warn = false;
            _label = Levels.Clock(Spec.LimitMs);
            _placedCount = 0; _mistakes = 0; _usedX = false; _combo = 0; _lastSecond = -1; _gLeft = 3;
            ClockReset();
            // the cards close (the result's empties at once: its `res` is gone)
            Close(ref _resultCard, true);
            Close(ref _timeUpCard);
            Close(ref _pauseCard);
            _pieces = Pick(_cast, Spec.N);
            _score = Pick(_cast, 3);
            _given = Spec.Head ? Spec.Puzzle.Solution[0] : -1;
            Phase = "loading";
            SetPerfectProp(false);
            Phase = "intro";
            BuildBoard();
            ScoreRowNewGame();
            Hud();
            // the board cascades in, the level banner pops, HEAD START's creature drops in, then the clock starts
            double settled = 60 + (2 * Spec.N - 1) * 34 + 450;
            Later(60, () => { Intro(); Effect(ShowBanner); });
            if (_given >= 0) Later(settled, () => { Place(_given); _placedCount = 1; });
            Later(settled + (_given >= 0 ? 450 : 0), () =>
            {
                Phase = "play";
                ClockStart(Spec.LimitMs);
                BuddyReact("start");
                Effect(StartInterval);
                Hud();
            });
        }

        // ---- the clock (game.js useClock) ------------------------------------------------------------------------------------
        readonly AnimatedValue _frac = new AnimatedValue(1);
        double _limit = 1, _used, _since;
        bool _running;
        CompositeAnimation _fracAnim;

        void ClockRun()
        {
            _fracAnim?.Stop();
            _frac.SetValue(Math.Max(0, 1 - _used / _limit));
            _fracAnim = Animated.Timing(_frac, Fx.Timing(0, Math.Max(1, _limit - _used), Easing.Linear));
            _fracAnim.Start();
        }
        double Elapsed => _used + (_running ? _tk.Now - _since : 0);
        void ClockStart(double limit) { _limit = limit; _used = 0; _since = _tk.Now; _running = true; ClockRun(); }
        void ClockPause() { if (!_running) return; _used += _tk.Now - _since; _running = false; _fracAnim?.Stop(); _frac.SetValue(Math.Max(0, 1 - _used / _limit)); }
        void ClockResume() { if (_running) return; _since = _tk.Now; _running = true; ClockRun(); }
        void ClockReset() { _fracAnim?.Stop(); _limit = 1; _used = 0; _since = 0; _running = false; _frac.SetValue(1); }

        // every 150 ms while playing: the digits, the creatures falling off, the last ten seconds
        void StartInterval()
        {
            StopInterval();
            Action tick = null;
            tick = () =>
            {
                _interval = _tk.SetTimeout(tick, 150);
                if (Phase != "play") return;
                double ms = Elapsed, rest = Spec.LimitMs - ms;
                _label = Levels.Clock(rest);
                int sec = (int)Math.Ceiling(rest / 1000);
                if (rest <= 10000 && sec != _lastSecond && rest > 0)
                {
                    if (_lastSecond < 0) BuddyReact("hurry");
                    _lastSecond = sec;
                    _warn = true;
                }
                int now = !_usedX && _mistakes == 0 ? 3 : Levels.StarsLeft(Spec, ms, _mistakes);
                if (now != _gLeft) { _gLeft = now; _left = now; }
                Hud();
                if (rest <= 0) TimeUp();
            };
            _interval = _tk.SetTimeout(tick, 150);
        }
        void StopInterval() { if (_interval >= 0) _tk.ClearTimeout(_interval); _interval = -1; }

        void TimeUp()
        {
            if (Phase != "play") return;
            ClockPause();
            Phase = "timeup";
            _warn = false;
            BuddyReact("timeup");
            Shake();
            var r = Levels.AfterLevel(Profile, Spec, false);
            Apply(r.Update);
            StopInterval();
            Effect(() => OpenTimeUp(0));
            Hud();
        }

        // the last heart: the board locks at once, the wrong creature's shake plays out, then the card
        void OutOfHearts()
        {
            ClockPause();
            Phase = "out";
            _warn = false;
            StopInterval();
            var r = Levels.AfterLevel(Profile, Spec, false);
            Apply(r.Update);
            Later(450, () => { BuddyReact("timeup"); Shake(); });
            Later(1000, () => { Phase = "nohearts"; Effect(() => OpenTimeUp(Spec.Hearts)); Hud(); });
            Hud();
        }

        // ---- touches ---------------------------------------------------------------------------------------------------
        void LosePerfect() { _perfect = false; SetPerfectProp(PerfectProp); }
        bool PerfectProp => _perfect && Phase != "loading";

        void Mark(int cell, bool on)
        {
            if (Phase != "play") return;
            SetMark(cell, on);
            if (on && !_usedX) { _usedX = true; LosePerfect(); }
            Hud();
        }

        readonly HashSet<int> _marks = new HashSet<int>();   // RegularGame's marks ref
        void OnMark(int cell, bool on)
        {
            if (on) _marks.Add(cell); else _marks.Remove(cell);
            Mark(cell, on);
        }

        void OnTap(int cell)
        {
            if (Phase != "play") return;
            if (_xTool) { OnMark(cell, !_marks.Contains(cell)); return; }
            int n = Spec.N, r = cell / n, c = cell % n;
            _marks.Remove(cell);
            if (Spec.Puzzle.Solution[r] == c)
            {
                Place(cell);
                BuddyReact("right", _combo + 1);
                _combo++;
                _placedCount++;
                if (_placedCount == n) Solved();
            }
            else
            {
                Wrong(cell);
                BuddyReact("wrong");
                _combo = 0;
                _mistakes++;
                LosePerfect();
                // from level 46: a heart goes, and the last one ends the try
                if (Spec.Hearts > 0)
                {
                    _heartsLost = _mistakes;
                    HeartsChanged();
                    if (_mistakes >= Spec.Hearts) { OutOfHearts(); return; }
                }
                // the cell it can't be gets its ✕ (this one doesn't count as using ✕)
                Later(950, () =>
                {
                    if (Phase == "play" || Phase == "paused") { _marks.Add(cell); SetMark(cell, true); }
                });
            }
            Hud();
        }

        void OnTapPiece(int cell) => Rock(cell, new[] { -0.7, 0.7, -0.4, 0 }, 380);

        // ---- solved ------------------------------------------------------------------------------------------------------
        void Solved()
        {
            double ms = Elapsed;
            ClockPause();
            Phase = "solved";
            _warn = false;
            StopInterval();
            var score = Levels.StarsFor(Spec, ms, _mistakes, _usedX);
            var outc = Levels.AfterLevel(Profile, Spec, true, score.Stars, score.Perfect);
            Apply(outc.Update);
            if (outc.Unlocked) _unlocked = Spec.Lv + 1;
            var res = new SdCards.Result
            {
                Stars = score.Stars, Perfect = score.Perfect, Ms = ms, Mistakes = _mistakes, LevelCoins = outc.LevelCoins ?? 0, Xp = outc.Xp,
                LevelUps = outc.LevelUps?.Count ?? 0, Unlocked = outc.Unlocked,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            Later(420, () => { BuddyReact("solve"); HopAll(); });
            Later(650, () =>
            {
                RootBurst("confetti", W / 2, H * 0.35, 1.1);
                RootBurst("confetti", W * 0.25, H * 0.4, 0.8);
                RootBurst("confetti", W * 0.75, H * 0.4, 0.8);
            });
            Later(1700, () => { Phase = "result"; Effect(() => OpenResult(res)); Hud(); });
            Hud();
        }

        // ---- pause, back, leaving ------------------------------------------------------------------------------------------
        public void Pause() => AsInput(PauseNow);
        void PauseNow()
        {
            if (Phase != "play") return;
            ClockPause();
            Phase = "paused";
            _pauseCard = OpenCard(SdCards.PauseCard(W, H, Resume, Restart, Exit), 0);
            Hud();
        }

        void Resume()
        {
            Phase = "play";
            ClockResume();
            Close(ref _pauseCard);
            Hud();
        }

        void Restart() { _attempt++; NewBoard(); }
        void Next() { _lv = Math.Min(Levels.LevelCount, _lv + 1); OnLevel?.Invoke(_lv); _attempt++; NewBoard(); }

        void Exit()
        {
            ClockPause();
            ClearTimers();
            StopInterval();
            OnExit?.Invoke(_unlocked);
        }

        /// <summary>BackHandler: playing pauses; anything else leaves.</summary>
        public void Back() => AsInput(() => { if (Phase == "play") PauseNow(); else Exit(); });

        void ToggleX() { _xTool = !_xTool; Hud(); }

        // the profile update as Firestore takes it: dotted field paths into nested maps
        static void Apply(Dictionary<string, object> update)
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

        // ---- the cards ---------------------------------------------------------------------------------------------------
        Card _pauseCard, _timeUpCard, _resultCard;
        readonly List<(Card card, int rank)> _cards = new List<(Card, int)>();   // PauseCard, TimeUpCard, ResultCard: later over earlier
        public IEnumerable<Card> Cards { get { foreach (var c in _cards) yield return c.card; } }
        bool CardOpen { get { foreach (var c in _cards) if (c.card.Visible) return true; return false; } }

        Card OpenCard(Card c, int rank)
        {
            int at = _cards.Count;
            while (at > 0 && _cards[at - 1].rank > rank) at--;
            _cards.Insert(at, (c, rank));
            c.Show();
            return c;
        }
        static void Close(ref Card c, bool emptied = false) { c?.Hide(emptied); c = null; }

        void OpenTimeUp(int hearts) => _timeUpCard = OpenCard(SdCards.TimeUpCard(W, H, hearts, _score[0]?.Picture, Restart, Exit), 1);
        void OpenResult(SdCards.Result res)
        {
            var pics = new string[3];
            for (int i = 0; i < 3; i++) pics[i] = _score[i]?.Picture;
            _resultCard = OpenCard(SdCards.ResultCard(W, H, res, Spec.Lv, Spec.N, Spec.Head, pics, _lv >= Levels.LevelCount, Next, Restart, Exit), 2);
        }

        /// <summary>Opens a card as the game would, with src/web/Preview.js's sample data for the result (tests).</summary>
        public void ShowCard(string which) => AsInput(() => ShowCardNow(which));
        void ShowCardNow(string which)
        {
            switch (which)
            {
                case "pause": PauseNow(); break;
                case "timeup": Phase = "timeup"; ClockPause(); OpenTimeUp(0); break;
                case "hearts": Phase = "nohearts"; ClockPause(); OpenTimeUp(3); break;
                case "result":
                    Phase = "result"; ClockPause();
                    OpenResult(new SdCards.Result { Stars = 2, Perfect = false, Ms = 83000, Mistakes = 1, LevelCoins = 90, Xp = 40, LevelUps = 1, Unlocked = true, Before = new XpLevel(6, 560, 700), After = new XpLevel(7, 40, 800) });
                    break;
            }
            Hud();
        }

        // =====================================================================================================================
        // ---- the board (RoomBoard.js) --------------------------------------------------------------------------------------
        public readonly float AreaX;
        readonly float AreaW;
        Board _B;
        int _N;
        public Board BoardGeo => _B;

        sealed class Pose
        {
            public readonly AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), K = new AnimatedValue(1), O = new AnimatedValue(1),
                Shadow = new AnimatedValue(1), Rot = new AnimatedValue(0), Hp = new AnimatedValue(0), LiftH = new AnimatedValue(0),
                Land = new AnimatedValue(1);
            public KeyLoop Breathe, Peek;
            public SdLayer ShadowL, Body;
        }

        sealed class CellA { public readonly AnimatedValue A = new AnimatedValue(0), Bump = new AnimatedValue(0); public SdLayer L; public Board.Box Box; }

        CellA[] _cellA;
        Pose[] _poses;
        bool[] _markOn, _placed, _shown;
        AnimatedValue[] _markT;
        SdLayer[] _markL;
        Board.Box[] _markBox;
        int _red = -1;
        KeyLoop _redPulse;
        SdLayer _redL;
        Board.Box _redBox;
        readonly AnimatedValue _shakeX = new AnimatedValue(0);
        readonly List<(Burst b, bool root)> _bursts = new List<(Burst, bool)>();
        int _trick = -1;
        float _pw;

        static readonly double[] PEEK_AT = { 0, 0.84, 0.88, 0.92, 0.96, 1 };
        static readonly double[] PEEK_DEG = { 0, 0, -9, 8, -3, 0 };
        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        static TimingConfig T(double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            new TimingConfig { ToValue = to, Duration = ms, Easing = easing ?? Easing.Out(Easing.Quad), Delay = delay, UseNativeDriver = true };

        void BuildBoard()
        {
            var geo = Rooms.Geometry(Stage.Room, W, H);
            _B = Board.Layout(Spec.N, Spec.N, AreaW, H, geo.FloorY - 0, Board.SDK_TILT, 80);
            if (_poses != null) foreach (var p in _poses) { p.Breathe?.Unmount(); p.Peek?.Unmount(); }
            _redPulse?.Unmount();
            if (_trick >= 0) _tk.ClearTimeout(_trick);
            foreach (var (b, _) in _bursts) b.Stop();
            _bursts.Clear();
            _N = Spec.N * Spec.N;
            _cellA = new CellA[_N]; _poses = new Pose[_N];
            _markOn = new bool[_N]; _placed = new bool[_N]; _shown = new bool[_N];
            _markT = new AnimatedValue[_N]; _markL = new SdLayer[_N]; _markBox = new Board.Box[_N];
            _red = -1;
            _marks.Clear();
            _shakeX.SetValue(0);
            _pw = (float)(_B.T * 0.7);
            for (int cell = 0; cell < _N; cell++)
            {
                var (svg, box) = SdArt.Cushion(_B, cell, Spec.Puzzle.Colors[Spec.Puzzle.Regions[cell]]);
                _cellA[cell] = new CellA { L = new SdLayer("cushion " + cell).Set(svg, (float)box.Width, (float)box.Height, 2), Box = box };
                var p = _poses[cell] = new Pose();
                var c = PieceOf(cell);
                float h = HOf(cell);
                p.ShadowL = new SdLayer("shadow " + cell).Set(SdArt.Shadow(_pw * 0.72f, h * 0.15f, "rgba(69,16,122,0.28)"), _pw * 0.72f, h * 0.15f, 1);
                p.Body = new SdLayer("creature " + cell).SetPicture(c.Picture, _pw, h);
            }
            // now and then one placed creature does a trick, so a board in progress never sits still
            Action trick = null;
            trick = () =>
            {
                _trick = _tk.SetTimeout(trick, 1400);
                if (Locked) return;
                var on = new List<int>();
                for (int i = 0; i < _N; i++) if (_placed[i]) on.Add(i);
                if (on.Count == 0) return;
                int cell = on[(int)Math.Floor(Random() * on.Count)];
                if (Random() < 0.5) Hop(cell, 0, 0.3);
                else Rock(cell, new[] { -0.5, 0.5, 0 }, 420);
            };
            _trick = _tk.SetTimeout(trick, 1400);
        }

        bool Locked => Phase != "play";
        SdCreature PieceOf(int cell) { int r = Spec.Puzzle.Regions[cell]; return r < _pieces.Length && _pieces[r] != null ? _pieces[r] : _pieces[0]; }
        float HOf(int cell) => _pw * PieceOf(cell).Ar;
        int ZOf(int cell) => 10 + cell / Spec.N * 3;

        (double x, double y, double k) PoseOn(int cell)
        {
            var q = _B.StandOn(cell);
            float h = HOf(cell);
            double k = q.S / _B.T;
            return (q.X - _pw / 2.0, q.Y - h / 2.0 * (1 + k), k);
        }

        void Show(int cell, bool on)
        {
            if (_shown[cell] == on) return;
            _shown[cell] = on;
            var p = _poses[cell];
            if (on)
            {
                // the piece mounts: its breathing and its peeking start (each a native loop, after its delay)
                double delay = cell * 530 % 2600;
                var br = p.Breathe = new KeyLoop(2200, KeyLoop.PHASE, KeyLoop.UP_DOWN, delay);
                var pk = p.Peek = new KeyLoop(6000, PEEK_AT, PEEK_DEG, delay);
                Effect(() => { if (p.Breathe == br) { br.Mount(); pk.Mount(); } });
            }
            else { p.Breathe?.Unmount(); p.Peek?.Unmount(); p.Breathe = p.Peek = null; }
        }

        void SetMark(int cell, bool on)
        {
            if (_markOn[cell] == on) return;
            _markOn[cell] = on;
            if (on && !_placed[cell]) MountMark(cell);
        }

        void MountMark(int cell)
        {
            var (svg, box) = SdArt.XMark(_B, cell);
            _markL[cell] ??= new SdLayer("x " + cell);
            _markL[cell].Set(svg, (float)box.Width, (float)box.Height, 2);
            _markBox[cell] = box;
            var t = _markT[cell] = new AnimatedValue(0);
            Effect(() => Animated.Spring(t, Fx.Spring(1, 5, 180)).Start());
        }

        void Unmark(int cell) { if (_markOn[cell]) _markOn[cell] = false; }

        // a creature drops onto its cushion and lands with a squash; `done` once it's down
        void Drop(int cell, Action done)
        {
            var P = _poses[cell];
            var p = PoseOn(cell);
            P.Rot.SetValue(0); P.Hp.SetValue(0);
            P.Land.SetValue(1); P.Shadow.SetValue(1);
            P.X.SetValue(p.x); P.K.SetValue(p.k);
            P.Y.SetValue(p.y - _B.T * 0.9);
            P.O.SetValue(0);
            Show(cell, true);
            Later(30, () => Animated.Parallel(Animated.Timing(P.Y, T(p.y, 200, Easing.In(Easing.Quad))), Animated.Timing(P.O, T(1, 90, Easing.Linear))).Start(r =>
            {
                P.Land.SetValue(0);
                Animated.Timing(P.Land, T(1, 240)).Start();
                done?.Invoke();
            }));
        }

        // a little hop on the spot
        void Hop(int cell, double delay = 0, double high = 0.45)
        {
            var P = _poses[cell];
            Later(delay, () =>
            {
                P.Hp.SetValue(0);
                P.LiftH.SetValue(_B.T * high);
                Animated.Timing(P.Hp, T(1, 340, Easing.Linear)).Start(r =>
                {
                    P.Land.SetValue(0);
                    Animated.Timing(P.Land, T(1, 200)).Start();
                });
            });
        }

        void Rock(int cell, double[] seq, double ms)
        {
            var a = new CompositeAnimation[seq.Length];
            for (int i = 0; i < seq.Length; i++) a[i] = Animated.Timing(_poses[cell].Rot, T(seq[i], ms / seq.Length, Easing.InOut(Easing.Quad)));
            Animated.Sequence(a).Start();
        }

        void Bounce(int cell, double delay)
        {
            var b = _cellA[cell].Bump;
            Later(delay, () =>
            {
                b.SetValue(0);
                Animated.Sequence(Animated.Timing(b, T(1, 110)), Animated.Timing(b, T(0, 220, Easing.InOut(Easing.Quad)))).Start();
            });
        }

        void Shake()
        {
            _shakeX.SetValue(0);
            var ks = new[] { 1, -0.85, 0.65, -0.45, 0.25, -0.1, 0 };
            var a = new CompositeAnimation[ks.Length];
            for (int i = 0; i < ks.Length; i++) a[i] = Animated.Timing(_shakeX, new TimingConfig { ToValue = ks[i] * 9, Duration = 42, UseNativeDriver = true });
            Animated.Sequence(a).Start();
        }

        void Burst(string kind, double x, double y, double scale)
        {
            // a busy board never piles up more than a dozen at once (FxLayer)
            var b = new Burst(kind, x, y, scale);
            AddBurst(b, false);
        }
        void RootBurst(string kind, double x, double y, double scale) => AddBurst(new Burst(kind, x, y, scale), true);

        void AddBurst(Burst b, bool root)
        {
            int count = 0;
            foreach (var e in _bursts) if (e.root == root) count++;
            for (int i = 0; count > 11 && i < _bursts.Count; i++)
                if (_bursts[i].root == root) { _bursts[i].b.Stop(); _bursts.RemoveAt(i); i--; count--; }
            _bursts.Add((b, root));
            b.Start(() => _bursts.RemoveAll(e => e.b == b));
        }

        // distances through the patch from `from` (the ripple's delays)
        Dictionary<int, int> DistancesInPatch(int from)
        {
            int n = Spec.N;
            var regions = Spec.Puzzle.Regions;
            var dist = new Dictionary<int, int> { [from] = 0 };
            var order = new List<int> { from };
            var todo = new Queue<int>();
            todo.Enqueue(from);
            int[][] dirs = { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
            while (todo.Count > 0)
            {
                int cell = todo.Dequeue(), r = cell / n, c = cell % n;
                foreach (var d in dirs)
                {
                    int rr = r + d[0], cc = c + d[1];
                    if (rr < 0 || rr >= n || cc < 0 || cc >= n) continue;
                    int nb = rr * n + cc;
                    if (regions[nb] != regions[from] || dist.ContainsKey(nb)) continue;
                    dist[nb] = dist[cell] + 1;
                    order.Add(nb);
                    todo.Enqueue(nb);
                }
            }
            return dist;
        }

        // a right creature: it drops onto its cushion, its patch ripples out from it, its row and column bob, sparks fly,
        // everyone cheers with a hop
        void Place(int cell)
        {
            var before = (bool[])_placed.Clone();
            _placed[cell] = true;
            Unmark(cell);
            Drop(cell, () =>
            {
                var q = _B.StandOn(cell);
                Burst("pop", q.X, q.Y - q.S * 0.2, q.S / 56);
                Burst("spark", q.X, q.Y - q.S * 0.5, q.S / 56);
                Hop(cell, 60, 0.35);
            });
            const double land = 200;
            int n = Spec.N;
            var dist = DistancesInPatch(cell);
            // (a Map: in the order the cells were reached)
            foreach (var kv in dist) Bounce(kv.Key, land + kv.Value * 45);
            int r = cell / n, c = cell % n;
            for (int i = 0; i < n; i++)
            {
                int row = r * n + i, col = i * n + c;
                if (!dist.ContainsKey(row)) Bounce(row, land + Math.Abs(i - c) * 35);
                if (!dist.ContainsKey(col)) Bounce(col, land + Math.Abs(i - r) * 35);
            }
            for (int other = 0; other < _N; other++)
            {
                if (!before[other] || other == cell) continue;
                int d = Math.Abs(other / n - r) + Math.Abs(other % n - c);
                Hop(other, land + 60 + d * 55, 0.3);
            }
        }

        // a wrong creature: it drops on, the cell glows red, it shakes its head and shrinks away in a poof; the board
        // shakes, everyone startles
        void Wrong(int cell)
        {
            Unmark(cell);
            SetRed(cell);
            var P = _poses[cell];
            Drop(cell, () =>
            {
                Rock(cell, new[] { -0.9, 0.9, -0.7, 0.7, -0.3, 0 }, 560);
                Later(620, () =>
                {
                    var q = _B.StandOn(cell);
                    Animated.Parallel(Animated.Timing(P.K, T(0.05, 220, Easing.In(Easing.Quad))), Animated.Timing(P.O, T(0, 220))).Start(r =>
                    {
                        Show(cell, false);
                        if (_red == cell) SetRed(-1);
                    });
                    Burst("poof", q.X, q.Y - q.S * 0.3, q.S / 56);
                });
            });
            Later(260, () => { var q = _B.StandOn(cell); Burst("angry", q.X, q.Y - q.S * 0.6, q.S / 56); });
            Later(200, Shake);
            for (int other = 0; other < _N; other++) if (_placed[other]) Hop(other, 240 + Random() * 80, 0.18);
        }

        void SetRed(int cell)
        {
            if (_red == cell) return;
            _redPulse?.Unmount();
            _redPulse = null;
            _red = cell;
            if (cell < 0) return;
            var (svg, box) = SdArt.RedGlow(_B, cell);
            (_redL ??= new SdLayer("red glow")).Set(svg, (float)box.Width, (float)box.Height, 2);
            _redBox = box;
            _redPulse = new KeyLoop(260, KeyLoop.PHASE, Array.ConvertAll(TRIANGLE, k => 0.35 + (0.9 - 0.35) * k));
            var pulse = _redPulse;
            Effect(() => { if (_redPulse == pulse) pulse.Mount(); });
        }

        // the board cascading in, a diagonal wave from the back left
        void Intro()
        {
            int n = Spec.N;
            for (int cell = 0; cell < _N; cell++)
            {
                var A = _cellA[cell];
                A.A.SetValue(0);
                Animated.Timing(A.A, T(1, 300, Easing.Out(Easing.Back(1.4)), (cell % n + cell / n) * 34)).Start();
            }
        }

        // every creature hops, row by row (back to front), and the cushions bob
        void HopAll()
        {
            for (int cell = 0; cell < _N; cell++)
            {
                double d = cell / Spec.N * 75;
                if (_placed[cell]) Hop(cell, d, 0.6);
                Bounce(cell, d + 120);
            }
        }

        // ---- the board's touches: tap, drag-to-mark, long-press-to-mark --------------------------------------------------------
        const double LONG_PRESS_MS = 380, MOVE_SLOP = 8;
        sealed class Gesture { public int Start = -1, Last = -1; public bool Painting, PaintOn = true, Moved, LongDone; public int Timer = -1; public float X0, Y0; }
        Gesture _g;

        void Paint(int cell)
        {
            var g = _g;
            if (cell < 0 || cell == g.Last) return;
            g.Last = cell;
            if (_placed[cell]) return;
            if (_markOn[cell] == g.PaintOn) return;
            OnMark(cell, g.PaintOn);
        }

        void BoardDown(float x, float y)
        {
            var g = _g = new Gesture { X0 = x, Y0 = y };
            g.Start = _B.CellAt(x, y);
            if (Locked || g.Start < 0) return;
            if (_xTool) { g.Painting = true; g.PaintOn = !_markOn[g.Start]; }
            else if (!_placed[g.Start])
                g.Timer = _tk.SetTimeout(() => { g.LongDone = true; g.Painting = true; g.PaintOn = !_markOn[g.Start]; Paint(g.Start); }, LONG_PRESS_MS);
        }

        void BoardMove(float x, float y)
        {
            var g = _g;
            if (g == null || Locked) return;
            if (!g.Moved && Math.Abs(x - g.X0) + Math.Abs(y - g.Y0) > MOVE_SLOP)
            {
                g.Moved = true;
                if (!g.Painting) _tk.ClearTimeout(g.Timer);
                if (g.Painting && g.Last < 0) Paint(g.Start);
            }
            if (g.Painting && g.Moved) Paint(_B.CellAt(x, y));
        }

        void BoardUp()
        {
            var g = _g;
            _g = null;
            if (g == null) return;
            _tk.ClearTimeout(g.Timer);
            if (Locked || g.Start < 0 || g.LongDone || g.Moved) return;
            if (_placed[g.Start]) { OnTapPiece(g.Start); return; }
            OnTap(g.Start);
        }

        // =====================================================================================================================
        // ---- the HUD (RegularGame.js's columns, Hud.js) -------------------------------------------------------------------------
        StageInfo Stage => Levels.StageOf(_lv);
        SdLayer _room, _leftL, _cribLip, _cribFace, _glowL, _barL, _barText, _rightL, _buddyL, _bubbleL, _bannerL;
        readonly SdLayer[] _ghost = new SdLayer[3], _headL = new SdLayer[3], _markerL = new SdLayer[2];
        readonly SdLayer[] _toolLip = new SdLayer[2], _toolFace = new SdLayer[2];
        SdLayer[] _heartE = new SdLayer[0], _heartF = new SdLayer[0];
        AnimatedValue[] _heartT = new AnimatedValue[0];
        readonly AnimatedValue[] _out = { new AnimatedValue(0), new AnimatedValue(0), new AnimatedValue(0) }, _pop = { new AnimatedValue(0), new AnimatedValue(0), new AnimatedValue(0) };
        readonly AnimatedValue _glowOn = new AnimatedValue(0);
        KeyLoop _glowPulse, _warnPulse;
        bool _perfectProp, _scoreMounted;
        readonly AnimatedValue[] _markerV = { new AnimatedValue(0), new AnimatedValue(0) };
        bool[] _markerGone = new bool[2];
        bool _markersOn;
        string _roomKey;

        void BuildFixed()
        {
            _room = new SdLayer("room");
            _leftL = new SdLayer("left column");
            _cribLip = new SdLayer("crib lip"); _cribFace = new SdLayer("crib face");
            _glowL = new SdLayer("glow").Set(SdArt.Glow(), 192, 40, 0);
            for (int i = 0; i < 3; i++) { _ghost[i] = new SdLayer("ghost " + i); _headL[i] = new SdLayer("head " + i); }
            for (int i = 0; i < 2; i++) _markerL[i] = new SdLayer("marker " + i);
            _barL = new SdLayer("timer bar"); _barText = new SdLayer("timer label");
            _rightL = new SdLayer("right column");
            _buddyL = new SdLayer("buddy");
            if (_buddy != null)
            {
                // resizeMode contain in the 84 dp box
                float bw = SdArt.BuddySize, bh = SdArt.BuddySize;
                if (_buddy.Ar >= 1) bw = bh / _buddy.Ar; else bh = bw * _buddy.Ar;
                _buddyL.SetPicture(_buddy.Picture, bw, bh);
            }
            _bubbleL = new SdLayer("bubble");
            _bannerL = new SdLayer("banner");
            for (int i = 0; i < 2; i++) { _toolLip[i] = new SdLayer("tool lip " + i); _toolFace[i] = new SdLayer("tool face " + i); }
        }

        void SetPerfectProp(bool on)
        {
            if (on == _perfectProp && _scoreMounted) return;
            _perfectProp = on;
            Animated.Timing(_glowOn, T(on ? 1 : 0, on ? 700 : 300, Easing.InOut(Easing.Sin))).Start();
            _glowPulse?.Unmount();
            _glowPulse = null;
            if (on) { _glowPulse = new KeyLoop(1400, KeyLoop.PHASE, Array.ConvertAll(KeyLoop.UP_DOWN, k => 1 + (0.45 - 1) * k)); _glowPulse.Mount(); }
        }

        // a new level: everyone pops back in, one after another (the ScoreRow's `uris` changed)
        void ScoreRowNewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                _out[i].SetValue(0);
                _pop[i].SetValue(0);
                Animated.Spring(_pop[i], Fx.Spring(1, 4.5, 160, 120 + i * 110)).Start();
            }
            _scoreMounted = true;
            SetPerfectProp(PerfectProp);
            _shownLeft = 3;
            _markersOn = false;
            // the hearts: all back
            if (_heartT.Length != Spec.Hearts)
            {
                _heartT = new AnimatedValue[Spec.Hearts]; _heartE = new SdLayer[Spec.Hearts]; _heartF = new SdLayer[Spec.Hearts];
                for (int i = 0; i < Spec.Hearts; i++)
                {
                    _heartT[i] = new AnimatedValue(1);
                    _heartE[i] = new SdLayer("heart " + i).Set(SdArt.HeartEmpty(18, "rgba(255,255,255,0.16)"), 18, 18, 1);
                    _heartF[i] = new SdLayer("heart on " + i).Set(SdArt.HeartFull(18), 18, 18, 1);
                }
            }
            _heartOn = new bool[Spec.Hearts];
            for (int i = 0; i < Spec.Hearts; i++) { _heartOn[i] = true; _heartT[i].SetValue(1); }
        }

        bool[] _heartOn = new bool[0];
        void HeartsChanged()
        {
            for (int i = 0; i < _heartT.Length; i++)
            {
                bool on = i < Spec.Hearts - _heartsLost;
                if (on == _heartOn[i]) continue;
                _heartOn[i] = on;
                if (on) _heartT[i].SetValue(1);
                else Animated.Sequence(Animated.Timing(_heartT[i], T(1.6, 120, null)), Animated.Spring(_heartT[i], Fx.Spring(0, 5, 120))).Start();
            }
        }

        int _shownLeft = 3;

        /// <summary>What the HUD shows follows the state (as React renders it): the left column, the score creatures falling
        /// off, the markers, the warning pulse, the tools.</summary>
        bool _hudQueued;
        void Hud()
        {
            if (_input) { HudNow(); return; }
            if (_hudQueued) return;
            _hudQueued = true;
            _tk.RequestAnimationFrame(() => { _hudQueued = false; HudNow(); });
        }

        void HudNow()
        {
            var stage = Stage;
            var room = Rooms.Of(stage.Room);
            if (_roomKey != stage.Room + ":" + stage.Phase)
            {
                _roomKey = stage.Room + ":" + stage.Phase;
                _room.Set(Rooms.Svg(stage.Room, stage.Phase, W, H), W, H, 0);
            }
            SetPerfectProp(PerfectProp);
            var leftSvg = SdArt.LeftColumn(new SdArt.Left
            {
                Room = room.Name, Phase = room.Dance ? null : stage.Phase, Sub = $"LEVEL {_lv} · {Spec.N}×{Spec.N}", Tier = Spec.Tier, Head = Spec.Head, Perfect = _perfect,
            }, H, out float leftW);
            _leftL.Set(leftSvg, leftW, H, 4);
            var icon = Phase == "play" ? "pause" : "back";
            _cribLip.Set(_xml($"crib-{icon}-lip"), 48, 48, 2);
            _cribFace.Set(_xml($"crib-{icon}-face"), 48, 52, 2);
            // the score heads: `left` still on offer, the rest tumble off
            if (_left != _shownLeft)
            {
                _shownLeft = _left;
                for (int i = 0; i < 3; i++)
                {
                    bool gone = i >= _left;
                    Animated.Timing(_out[i], T(gone ? 1 : 0, gone ? 650 : 250, gone ? Easing.In(Easing.Quad) : Easing.Out(Easing.Quad))).Start();
                }
            }
            for (int i = 0; i < 3; i++)
            {
                float size = i == 1 ? 46 : 40;
                var pic = _score[i]?.Picture;
                _ghost[i].Set(SdArt.Head(size, pic, "rgba(255,255,255,0.55)", "rgba(255,255,255,0.35)", true), size, size, 1);
                _headL[i].Set(SdArt.Head(size, pic, PerfectProp ? "#ffd23a" : "#ffffff", "#f6efff"), size, size, 1);
            }
            // the markers ride on the bar once the PERFECT run is gone
            bool markers = !_perfect;
            bool[] gones = { _left < 3, _left < 2 };
            for (int i = 0; i < 2; i++)
            {
                if (markers && !_markersOn) { _markerGone[i] = gones[i]; _markerV[i].SetValue(gones[i] ? 1 : 0); }
                else if (markers && _markerGone[i] != gones[i])
                {
                    _markerGone[i] = gones[i];
                    Animated.Timing(_markerV[i], T(gones[i] ? 1 : 0, gones[i] ? 600 : 200, Easing.In(Easing.Quad))).Start();
                }
                _markerL[i].Set(SdArt.Marker(_score[2 - i]?.Picture), 26, 34, 1);
            }
            _markersOn = markers;
            // the last seconds' pulse
            bool warnOn = _warn;
            if (warnOn && _warnPulse == null) { _warnPulse = new KeyLoop(500, KeyLoop.PHASE, TRIANGLE); _warnPulse.Mount(); }
            else if (!warnOn && _warnPulse != null) { _warnPulse.Unmount(); _warnPulse = null; }
            _barText.Set(SdArt.BarText(_label, _warn), SdArt.BarW, SdArt.BarH, 2);
            // the right column
            _rightL.Set(SdArt.RightColumn(SdArt.Right(W, H, _xTool), W, H, _xTool), W, H, 0);
            string[] tools = { $"tool-place-{(_xTool ? "off" : "on")}", $"tool-mark-{(_xTool ? "on" : "off")}" };
            for (int i = 0; i < 2; i++)
            {
                _toolLip[i].Set(_xml(tools[i] + "-lip"), SdArt.ToolW, 48, 2);
                _toolFace[i].Set(_xml(tools[i] + "-face"), SdArt.ToolW, 48, 2);
            }
        }

        // ---- the banner: LEVEL n pops (PopIn from 2, twist -6), then fades up and away (FadeAway) -------------------------------
        readonly AnimatedValue _bannerPop = new AnimatedValue(0), _bannerFade = new AnimatedValue(1);
        static readonly Interpolator PopOp = Fx.Lerp(new[] { 0, 0.2, 1 }, new[] { 0.0, 1, 1 }, true);

        void ShowBanner()
        {
            _bannerShown = true;
            bool hearts = _lv == Levels.HeartsFrom;
            var (svg, bw, bh) = SdArt.Banner($"LEVEL {_lv}", hearts ? new[] { $"NEW: {Spec.Hearts} HEARTS!", "A MISTAKE COSTS ONE" } : null);
            _bannerL.Set(svg, bw, bh, 8);
            _bannerPop.SetValue(0);
            Animated.Spring(_bannerPop, Fx.Spring(1, 5, 120)).Start();
            _bannerFade.SetValue(1);
            Animated.Timing(_bannerFade, new TimingConfig { ToValue = 0, Duration = 400, Delay = hearts ? 2400 : 750, UseNativeDriver = true }).Start();
        }

        // ---- the buddy (Buddy.js): hops on a right creature, shakes at a mistake, a word for most moments ----------------------
        readonly AnimatedValue _jump = new AnimatedValue(0), _bshake = new AnimatedValue(0), _bubble = new AnimatedValue(0);
        int _hideTimer = -1;
        bool _bubbleBad;
        float _bubbleW, _bubbleH;
        static readonly Dictionary<string, string[]> SAY = new Dictionary<string, string[]>
        {
            ["start"] = new[] { "Let's go!", "You got this!", "Squish time!" },
            ["right"] = new[] { "Yay!", "Nice!", "Squishy!", "Woo!", "Yes!" },
            ["streak"] = new[] { "On fire!", "Unstoppable!", "So good!" },
            ["wrong"] = new[] { "Oops!", "Uh-oh!", "Not there!", "Hmm…" },
            ["hurry"] = new[] { "Hurry!", "Quick quick!" },
            ["solve"] = new[] { "We did it!", "Squishtastic!", "Hooray!" },
            ["timeup"] = new[] { "Aww…", "So close!" },
        };

        void BuddyReact(string kind, int n = 0)
        {
            var k = kind == "right" && n >= 3 ? "streak" : kind;
            if (k == "wrong" || k == "timeup")
            {
                _bshake.SetValue(0);
                var vs = new[] { 1, -1, 0.8, -0.8, 0.4, 0 };
                var a = new CompositeAnimation[vs.Length];
                for (int i = 0; i < vs.Length; i++) a[i] = Animated.Timing(_bshake, new TimingConfig { ToValue = vs[i], Duration = 55, UseNativeDriver = true });
                Animated.Sequence(a).Start();
            }
            else
            {
                double height = k == "solve" ? 1 : k == "streak" ? 0.8 : 0.5;
                _jump.SetValue(0);
                Animated.Sequence(Animated.Timing(_jump, T(height, 180, Easing.Out(Easing.Quad))), Animated.Timing(_jump, T(0, 220, Easing.Bounce))).Start();
            }
            if (k != "right" || Random() < 0.55)
            {
                var list = SAY[k];
                Speak(list[(int)Math.Floor(Random() * list.Length)], k == "wrong" || k == "timeup");
            }
        }

        void Speak(string text, bool bad)
        {
            var (svg, w, h) = SdArt.Bubble(text, bad);
            _bubbleL.Set(svg, w, h + 7, 3);
            _bubbleW = w; _bubbleH = h; _bubbleBad = bad;
            _bubble.SetValue(0);
            Animated.Spring(_bubble, Fx.Spring(1, 5, 180)).Start();
            _tk.ClearTimeout(_hideTimer);
            _hideTimer = _tk.SetTimeout(() => Animated.Timing(_bubble, new TimingConfig { ToValue = 0, Duration = 180, UseNativeDriver = true }).Start(), 1100);
        }

        // =====================================================================================================================
        // ---- every frame: where everything is, in paint order ---------------------------------------------------------------
        static Interpolator L(double[] i, double[] o, bool clamp = false) => Fx.Lerp(i, o, clamp);
        static readonly Interpolator CushScale = L(new[] { 0.0, 1 }, new[] { 0.3, 1 }), BumpScale = L(new[] { 0.0, 1 }, new[] { 1, 1.09 });
        static readonly Interpolator Arc = L(new[] { 0, 0.25, 0.5, 0.75, 1 }, new[] { 0, -0.75, -1, -0.75, 0 });
        static readonly Interpolator HpX = L(new[] { 0, 0.4, 1 }, new[] { 1, 0.9, 1 }), LandX = L(new[] { 0, 0.55, 1 }, new[] { 1.14, 0.96, 1 });
        static readonly Interpolator HpY = L(new[] { 0, 0.4, 1 }, new[] { 1, 1.12, 1 }), LandY = L(new[] { 0, 0.55, 1 }, new[] { 0.86, 1.05, 1 });
        static readonly Interpolator RotDeg = L(new[] { -1.0, 1 }, new[] { -10.0, 10 }), ShadowK = L(new[] { -1.0, 0 }, new[] { 0.6, 1 });
        static readonly Interpolator OutOp = L(new[] { 0, 0.7, 1 }, new[] { 1.0, 1, 0 }), OutY = L(new[] { 0, 0.25, 1 }, new[] { 0.0, -14, 70 }), OutK = L(new[] { 0.0, 1 }, new[] { 1, 0.6 });
        static readonly Interpolator MarkOp = L(new[] { 0, 0.8, 1 }, new[] { 1.0, 1, 0 }), MarkY = L(new[] { 0, 0.2, 1 }, new[] { 0.0, -10, 50 }), MarkRot = L(new[] { 0.0, 1 }, new[] { 0.0, 120 });
        static readonly Interpolator HeartOp = L(new[] { 0, 0.3, 1.6 }, new[] { 0.0, 1, 1 }, true), HeartK = L(new[] { 0, 1, 1.6 }, new[] { 0.4, 1, 1.35 }, true);
        static readonly Interpolator XScale = L(new[] { 0.0, 1 }, new[] { 1.6, 1 });

        static Affine About(double w, double h, Affine m) => Affine.Translate(w / 2, h / 2) * m * Affine.Translate(-w / 2, -h / 2);
        static Affine Feet(double h, Affine m) => Affine.Translate(0, h / 2) * m * Affine.Translate(0, -h / 2);

        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();
        readonly List<SdLayer> _frame = new List<SdLayer>();

        /// <summary>Everything on screen now, bottom first (call after the Ticker's tick). Cards last.</summary>
        public List<SdLayer> Layers()
        {
            var o = _frame;
            o.Clear();
            o.Add(_room);
            bool hidden = Phase == "paused";
            double shake = _shakeX.GetValue();
            var area = Affine.Translate(AreaX + shake, 0);
            // the board (hidden while paused)
            if (_B != null && !hidden)
            {
                for (int cell = 0; cell < _N; cell++)
                {
                    var A = _cellA[cell];
                    double a = A.A.GetValue(), b = A.Bump.GetValue(), k = CushScale.Evaluate(a) * BumpScale.Evaluate(b);
                    A.L.Transform = area * Affine.Translate(A.Box.Left, A.Box.Top) * About(A.Box.Width, A.Box.Height, Affine.Translate(0, b * -_B.T * 0.06) * Affine.ScaleBy(k, k));
                    A.L.Opacity = (float)a;
                    o.Add(A.L);
                }
                for (int cell = 0; cell < _N; cell++)
                {
                    if (!_markOn[cell] || _placed[cell] || _markL[cell] == null) continue;
                    double t = _markT[cell].GetValue(), k = XScale.Evaluate(t);
                    var bx = _markBox[cell];
                    _markL[cell].Transform = area * Affine.Translate(bx.Left, bx.Top) * About(bx.Width, bx.Height, Affine.ScaleBy(k, k));
                    _markL[cell].Opacity = (float)t;
                    o.Add(_markL[cell]);
                }
                if (_red >= 0)
                {
                    _redL.Transform = area * Affine.Translate(_redBox.Left, _redBox.Top);
                    _redL.Opacity = (float)_redPulse.Value;
                    o.Add(_redL);
                }
                var order = new List<int>();
                for (int cell = 0; cell < _N; cell++) if (_shown[cell]) order.Add(cell);
                order.Sort((p, q) => ZOf(p) != ZOf(q) ? ZOf(p).CompareTo(ZOf(q)) : p.CompareTo(q));
                foreach (var cell in order) PlacePiece(cell, area, o);
                foreach (var (bu, root) in _bursts) if (!root) { bu.Place(area, 1); foreach (var l in bu.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
            }
            // the banner, over the board area's middle, 22% down
            if (_bannerShown)
            {
                double p = _bannerPop.GetValue(), f = _bannerFade.GetValue();
                double s = 2 + (1 - 2) * p, rot = 6 * (1 - p);
                float bw = _bannerL.W, bh = _bannerL.H;
                _bannerL.Transform = Affine.Translate(AreaX + Card.Snap((AreaW - bw) / 2), H * 0.22) * About(bw, bh, Affine.ScaleBy(s, s) * Affine.Rotate(rot)) * Affine.Translate(0, -30 * (1 - f));
                _bannerL.Opacity = (float)(PopOp.Evaluate(p) * f);
                if (_bannerL.Opacity > 0) o.Add(_bannerL);
            }
            // the left column
            o.Add(_leftL);
            double press = _cribPress ? 3 : 0;
            _cribLip.Transform = Affine.Translate(SdArt.CribX, SdArt.CribY + 4);
            _cribFace.Transform = Affine.Translate(SdArt.CribX, SdArt.CribY + press);
            o.Add(_cribLip); o.Add(_cribFace);
            double glow = _glowOn.GetValue() * (_glowPulse?.Value ?? 1);
            _glowL.Transform = Affine.Translate(SdArt.RowX - 20, SdArt.RowY + 6) * About(192, 40, Affine.ScaleBy(0.9 + 0.15 * glow, 1));
            _glowL.Opacity = (float)glow;
            o.Add(_glowL);
            for (int i = 0; i < 3; i++)
            {
                float size = i == 1 ? 46 : 40, x = SdArt.SlotX(i) + 3, y = SdArt.RowY + (SdArt.RowH - size) / 2;
                _ghost[i].Transform = Affine.Translate(x, y);
                o.Add(_ghost[i]);
                double v = _out[i].GetValue(), k = _pop[i].GetValue() * OutK.Evaluate(v);
                _headL[i].Transform = Affine.Translate(x, y) * About(size, size, Affine.Translate(0, OutY.Evaluate(v)) * Affine.Rotate((i == 0 ? -50 : 50) * v) * Affine.ScaleBy(k, k));
                _headL[i].Opacity = (float)OutOp.Evaluate(v);
                o.Add(_headL[i]);
            }
            for (int i = 0; i < _heartT.Length; i++)
            {
                float x = SdArt.GlassX + SdArt.GlassW - 2 - 10 - (_heartT.Length * 18 + (_heartT.Length - 1) * 2) + i * 20, y = SdArt.GlassY + 2 + 14;
                _heartE[i].Transform = Affine.Translate(x, y);
                o.Add(_heartE[i]);
                double t = _heartT[i].GetValue(), k = HeartK.Evaluate(t);
                _heartF[i].Transform = Affine.Translate(x, y) * About(18, 18, Affine.ScaleBy(k, k));
                _heartF[i].Opacity = (float)HeartOp.Evaluate(t);
                if (_heartF[i].Opacity > 0) o.Add(_heartF[i]);
            }
            double warn = _warnPulse?.Value ?? 0, frac = _frac.GetValue();
            _barL.Set(SdArt.Bar(Math.Round(frac * 1900) / 1900, Math.Round(warn * 50) / 50), SdArt.BarW, SdArt.BarH, 2);
            var bar = Affine.Translate(SdArt.BarX, SdArt.BarY(_perfect)) * About(SdArt.BarW, SdArt.BarH, Affine.ScaleBy(1 + 0.04 * warn, 1 + 0.04 * warn));
            _barL.Transform = bar;
            o.Add(_barL);
            if (_markersOn)
            {
                double[] at = { 1 - (double)Spec.AMs / Spec.LimitMs, 1 - (double)Spec.BMs / Spec.LimitMs };
                for (int i = 0; i < 2; i++)
                {
                    double v = _markerV[i].GetValue();
                    double mx = 3 + (SdArt.BarW - 6) * at[i];
                    _markerL[i].Transform = bar * Affine.Translate(mx - 13, -20) * About(26, 26, Affine.Translate(0, MarkY.Evaluate(v)) * Affine.Rotate(MarkRot.Evaluate(v)));
                    _markerL[i].Opacity = (float)MarkOp.Evaluate(v);
                    o.Add(_markerL[i]);
                }
            }
            _barText.Transform = bar;
            o.Add(_barText);
            // the right column
            var R = SdArt.Right(W, H, _xTool);
            o.Add(_rightL);
            if (_buddy != null)
            {
                double jy = -SdArt.BuddySize * 0.32 * _jump.GetValue(), sx = SdArt.BuddySize * 0.08 * _bshake.GetValue();
                _buddyL.Transform = Affine.Translate(R.BuddyX + (SdArt.BuddySize - _buddyL.W) / 2 + sx, R.BuddyY + (SdArt.BuddySize - _buddyL.H) / 2 + jy);
                o.Add(_buddyL);
            }
            double bub = _bubble.GetValue();
            if (_bubbleL.Markup != null && bub > 0)
            {
                double k = 0.4 + 0.6 * bub;
                _bubbleL.Transform = Affine.Translate(R.BuddyX + Card.Snap((SdArt.BuddySize - _bubbleW) / 2), R.BuddyY + SdArt.BuddySize - SdArt.BuddySize * 0.86 - _bubbleH)
                    * About(_bubbleW, _bubbleH, Affine.ScaleBy(k, k) * Affine.Rotate(_bubbleBad ? 4 : -4));
                _bubbleL.Opacity = (float)Math.Min(1, bub);
                o.Add(_bubbleL);
            }
            for (int i = 0; i < 2; i++)
            {
                double t = _toolT[i].GetValue(), s = 1 + (0.93 - 1) * t;
                var whole = Affine.Translate(R.ToolX, R.ToolY + i * (SdArt.ToolH + 8)) * About(SdArt.ToolW, SdArt.ToolH, Affine.ScaleBy(s, s));
                _toolLip[i].Transform = whole * Affine.Translate(0, 5);
                _toolFace[i].Transform = whole * Affine.Translate(0, 4 * t);
                o.Add(_toolLip[i]); o.Add(_toolFace[i]);
            }
            // the screen's bursts (the solve's confetti)
            foreach (var (bu, root) in _bursts) if (root) { bu.Place(Affine.Identity, 1); foreach (var l in bu.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
            // the cards: placed, and gone once closed
            foreach (var c in _cards)
            {
                c.card.Update();
                foreach (var l in c.card.Layers()) o.Add(SdLayer.Mirror(l, _mirrors));
            }
            _cards.RemoveAll(c => !c.card.Shown);
            // (mirrors of card and burst layers that are gone go too)
            if (_mirrors.Count > o.Count)
            {
                var seen = new HashSet<SdLayer>(o);
                var dead = new List<CardLayer>();
                foreach (var kv in _mirrors) if (!seen.Contains(kv.Value)) dead.Add(kv.Key);
                foreach (var d in dead) _mirrors.Remove(d);
            }
            return o;
        }

        // hop/Pieces.js Piece: placed and sized by x, y, k; hopping by lift; squashed by sx, sy and rocked by rot from its
        // feet; breathing and peeking about
        void PlacePiece(int cell, Affine area, List<SdLayer> o)
        {
            var P = _poses[cell];
            double w = _pw, h = HOf(cell);
            double hp = P.Hp.GetValue(), land = P.Land.GetValue(), arc = Arc.Evaluate(hp);
            double sx = HpX.Evaluate(hp) * LandX.Evaluate(land), sy = HpY.Evaluate(hp) * LandY.Evaluate(land);
            double br = P.Breathe?.Value ?? 0, peek = P.Peek?.Value ?? 0;
            double k = P.K.GetValue();
            var outer = area * About(w, h, Affine.Translate(P.X.GetValue(), P.Y.GetValue()) * Affine.ScaleBy(k, k));
            float op = (float)P.O.GetValue();
            double sk = ShadowK.Evaluate(arc);
            P.ShadowL.Transform = outer * Affine.Translate(0.14 * w, 0.9 * h) * About(0.72 * w, 0.15 * h, Affine.ScaleBy(sk, sk));
            P.ShadowL.Opacity = op * (float)P.Shadow.GetValue();
            o.Add(P.ShadowL);
            P.Body.Transform = outer * Affine.Translate(0, arc * P.LiftH.GetValue())
                * About(w, h, Feet(h, Affine.ScaleBy(sx, sy) * Affine.Rotate(RotDeg.Evaluate(P.Rot.GetValue()))))
                * About(w, h, Feet(h, Affine.ScaleBy(1 + 0.03 * br, 1 - 0.03 * br) * Affine.Rotate(peek)));
            P.Body.Opacity = op;
            o.Add(P.Body);
        }

        // =====================================================================================================================
        // ---- input (screen dp) -----------------------------------------------------------------------------------------------
        bool _cribPress, _cardDown, _onBoard;
        int _toolDown = -1;
        readonly AnimatedValue[] _toolT = { new AnimatedValue(0), new AnimatedValue(0) };

        public void Down(float x, float y) => AsInput(() => DownNow(x, y));
        public void Move(float x, float y) => AsInput(() => MoveNow(x, y));
        public void Up(float x, float y) => AsInput(() => UpNow(x, y));

        void DownNow(float x, float y)
        {
            if (CardOpen)
            {
                for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Down(x, y)) break;
                _cardDown = true;
                return;
            }
            // the top bar's button (hitSlop 4)
            if (x >= SdArt.CribX - 4 && x <= SdArt.CribX + 52 && y >= SdArt.CribY - 4 && y <= SdArt.CribY + 56) { _cribPress = true; return; }
            var R = SdArt.Right(W, H, _xTool);
            for (int i = 0; i < 2; i++)
            {
                float ty = R.ToolY + i * (SdArt.ToolH + 8);
                if (x >= R.ToolX - 6 && x <= R.ToolX + SdArt.ToolW + 6 && y >= ty - 6 && y <= ty + SdArt.ToolH + 6)
                {
                    _toolDown = i;
                    Animated.Timing(_toolT[i], new TimingConfig { ToValue = 1, Duration = 70, UseNativeDriver = true }).Start();
                    return;
                }
            }
            if (x >= AreaX && x < AreaX + AreaW && !(Phase == "paused") && _B != null) { _onBoard = true; BoardDown(x - AreaX, y); }
        }

        void MoveNow(float x, float y)
        {
            if (_onBoard) BoardMove(x - AreaX, y);
        }

        void UpNow(float x, float y)
        {
            if (_cardDown) { _cardDown = false; for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Up(x, y)) break; return; }
            if (_cribPress)
            {
                _cribPress = false;
                if (x >= SdArt.CribX - 4 && x <= SdArt.CribX + 52 && y >= SdArt.CribY - 4 && y <= SdArt.CribY + 56) { if (Phase == "play") Pause(); else Exit(); }
                return;
            }
            if (_toolDown >= 0)
            {
                int i = _toolDown;
                _toolDown = -1;
                Animated.Spring(_toolT[i], Fx.Spring(0, 3.5, 260)).Start();
                var R = SdArt.Right(W, H, _xTool);
                float ty = R.ToolY + i * (SdArt.ToolH + 8);
                if (x >= R.ToolX - 6 && x <= R.ToolX + SdArt.ToolW + 6 && y >= ty - 6 && y <= ty + SdArt.ToolH + 6)
                {
                    if (i == 0 && _xTool) ToggleX();
                    else if (i == 1 && !_xTool) ToggleX();
                }
                return;
            }
            if (_onBoard) { _onBoard = false; BoardUp(); }
        }

        /// <summary>A tap on cell `cell` as a finger would (tests).</summary>
        public void TapCell(int cell)
        {
            var q = _B.Project(cell % Spec.N + 0.5, cell / Spec.N + 0.5);
            Down((float)(AreaX + q.X), (float)q.Y);
            Up((float)(AreaX + q.X), (float)q.Y);
        }

        public bool IsPlaced(int cell) => _placed[cell];
        public bool IsMarked(int cell) => _markOn[cell];
        public int ScoreLeft => _left;
        public bool Perfect => _perfect;
        public int HeartsLost => _heartsLost;
        public void SetXTool(bool on) { if (on != _xTool) ToggleX(); }
    }
}
