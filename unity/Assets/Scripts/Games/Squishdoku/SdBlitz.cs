// Squishdoku's BLITZ MODE as src/squishdoku/BlitzGame.js plays it, in landscape (REDESIGN_V8): board after board, each on
// its own short clock (Levels.BlitzSpecOf), no ✕, in the Crib's Dance Room. The top bar (pause, BLITZ MODE, BOARD n) and
// the run's glass (CLEARED, BEST or NEW BEST!, 1 MISTAKE = GAME OVER, the board's clock) on the left, the board in the
// middle, the buddy and the rule on the right.
//   countdown  the run opens with 3, 2, 1, GO! (700 ms apart from 200): the first board cascades in on GO, its given
//              creature (the first row's) drops in once it's landed, 350 ms later its clock starts
//   intro      every later board: it cascades in 40 ms after it's up, its given creature drops in, then its clock
//   play       a right tap places a creature (the last one clears the board: everyone hops, the CLEARED number goes up
//              300 ms later, the board cascades out at 650, the next one is up at 1000); a wrong one poofs, 1000 ms later
//              the run stops; the clock running out shakes the board, 900 ms later the run stops
//   save       SAVE IT (an ad, once a run) / SAVE FOR gems / END RUN: saved, the run goes on from the same board (after a
//              mistake its clock runs on, after the clock ran out it starts again)
//   over       GAME OVER: the boards cleared pay out (Levels.AfterBlitz), PLAY AGAIN or QUIT
//   paused     the top bar's pause (or Android's back): the board hidden, the clock frozen (RESUME / START OVER / QUIT)
// Every motion and delay is the app's. No UnityEngine here: SquishdokuScreen shows the layers and feeds the touches;
// tools/unity/squishdoku-test runs it as is. Not ported: sounds, haptics, the rewarded ad (ShowAd), the buddy's live rig.
// The profile is SdLevel.Profile, in memory; signed in, the run's pay is saved to the account too and a gem save is the
// server's (SdSave: saveSquishdoku, squad.blitzSave; offline SpendGems takes the gems off the in-memory profile).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    /// <summary>game.js useClock: a clock that can pause; Frac (1 → 0) drives the timer bar.</summary>
    public sealed class SdClock
    {
        readonly Ticker _tk;
        public readonly AnimatedValue Frac = new AnimatedValue(1);
        double _limit = 1, _used, _since;
        bool _running;
        CompositeAnimation _anim;
        public SdClock(Ticker tk) { _tk = tk; }
        public double Limit => _limit;
        public bool Running => _running;
        public double Elapsed => _used + (_running ? _tk.Now - _since : 0);
        void Run()
        {
            _anim?.Stop();
            Frac.SetValue(Math.Max(0, 1 - _used / _limit));
            _anim = Animated.Timing(Frac, Fx.Timing(0, Math.Max(1, _limit - _used), Easing.Linear));
            _anim.Start();
        }
        public void Start(double limit, double used = 0) { _limit = limit; _used = used; _since = _tk.Now; _running = true; Run(); }
        public void Pause() { if (!_running) return; _used += _tk.Now - _since; _running = false; _anim?.Stop(); Frac.SetValue(Math.Max(0, 1 - _used / _limit)); }
        public void Resume() { if (_running) return; _since = _tk.Now; _running = true; Run(); }
        public void Reset() { _anim?.Stop(); _limit = 1; _used = 0; _since = 0; _running = false; Frac.SetValue(1); }
    }

    public sealed class SdBlitz
    {
        static readonly System.Random SndRandom = new System.Random();   // (the sounds' own)
        const string ROOM = "dance";
        const double GIVEN_MS = 350, HURRY_MS = 5000;

        // ---- the host's ------------------------------------------------------------------------------------------------
        /// <summary>QUIT, back once it's over.</summary>
        public Action OnExit;
        /// <summary>The boards' puzzles: (n, tier) → a fresh one (engine.js makePuzzleAsync; tests hand in the app's).</summary>
        public Func<int, int, Puzzle> PuzzleSource = (n, tier) => Engine.MakePuzzle(n, tier, (long)Math.Floor(SdLevel.Random() * 2147483648.0));
        /// <summary>Remove Ads: the save is free.</summary>
        public bool AdsFree;
        public Func<bool> AdReady = () => AdHook.Ready();
        /// <summary>A rewarded ad: show it, then call back (useRewardedAd's show).</summary>
        public Action<Action> ShowAd = back => AdHook.Show(back);
        /// <summary>The player's gems.</summary>
        public Func<int> Gems = () => (int)Js.OrNumber(SdLevel.Profile.TryGetValue("gems", out var g) ? g : null, 0);
        /// <summary>A gem save (functions/squad.js blitzSave): the price paid, or an error ("not_enough_gems", ...).
        /// Offline: the gems come off the in-memory profile.</summary>
        public Func<int, string> SpendGems;
        /// <summary>Whether the run's record and pay are saved (the app's `uid`); off, as the app's preview player.</summary>
        public bool Save = true;

        readonly float W, H;
        readonly Ticker _tk;
        readonly SdCreature[] _cast;
        readonly Func<string, string> _xml;
        public readonly float AreaX, AreaW;

        public SdBlitz(float screenW, float screenH, SdCreature[] cast, SdCreature buddy, Func<string, string> xml, Ticker tk)
        {
            W = screenW; H = screenH; _cast = cast; _xml = xml; _tk = tk;
            Ticker.Default = tk;
            AreaX = SdArt.LeftW; AreaW = W - SdArt.LeftW - SdArt.RightW;
            _buddy = new SdBuddy(buddy, 80, tk);
            _clk = new SdClock(tk);
            SpendGems = price =>
            {
                int have = Gems();
                if (have < price) return "not_enough_gems";
                SdLevel.Profile["gems"] = (double)(have - price);
                return null;
            };
            _room = new SdLayer("room").Set(Rooms.Svg(ROOM, "day", W, H), W, H, 0);
            _cribLip = new SdLayer("crib lip"); _cribFace = new SdLayer("crib face");
            _glass = new SdLayer("glass"); _barL = new SdLayer("timer bar"); _barText = new SdLayer("timer label");
            _right = new SdLayer("right column");
            _input = true;
            NewRun();
            _input = false;
        }

        // React: what a state change starts runs once it's rendered (SdLevel's Effect)
        bool _input;
        void Effect(Action a) { if (_input) a(); else _tk.RequestAnimationFrame(a); }
        void AsInput(Action a) { bool was = _input; _input = true; try { a(); } finally { _input = was; } }

        // ---- state (BlitzGame.js) --------------------------------------------------------------------------------------
        public string Phase { get; private set; } = "loading";   // loading | countdown | intro | play | between | save | over | paused
        public int Idx { get; private set; }
        public int ClearedShown { get; private set; }
        public string Count { get; private set; }
        public BlitzSpec Spec { get; private set; }
        public Puzzle Puzzle { get; private set; }
        public SdBoard Board { get; private set; }
        /// <summary>When the countdown's timers were set (tests line the app's up with it).</summary>
        public double CountdownAt { get; private set; } = -1;
        string _label = "";
        bool _warn, _adUsed, _saving, _started, _ended;
        int _gemSaves, _placed, _combo, _lastSecond = -1, _cleared, _run;
        double _skill;
        string _saveErr, _failReason = "mistake";
        SdBlitzCards.OverResult _over;
        int _given;
        SdCreature[] _pieces;
        readonly SdClock _clk;
        readonly List<int> _timers = new List<int>(), _phaseTimers = new List<int>();
        int _interval = -1;
        bool _dirty = true;
        int Top => (int)Js.OrNumber(Levels.Record(SdLevel.Profile).Blitz["top"], 0);

        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));
        void PhaseLater(double ms, Action fn) => _phaseTimers.Add(_tk.SetTimeout(fn, ms));
        void ClearPhaseTimers() { foreach (var t in _phaseTimers) _tk.ClearTimeout(t); _phaseTimers.Clear(); }

        void SetPhase(string p)
        {
            if (p == Phase) return;
            Phase = p;
            _dirty = true;
            // the effects keyed on the phase: their timers go, the new phase's start once it's rendered
            ClearPhaseTimers();
            StopInterval();
            if (p == "countdown") Effect(() => { if (Phase == "countdown") StartCountdown(); });
            else if (p == "intro") Effect(() => { if (Phase == "intro") StartIntro(); });
            else if (p == "play") Effect(() => { if (Phase == "play") StartInterval(); });
            Effect(SyncCards);
        }

        // ---- a new run ---------------------------------------------------------------------------------------------------
        void NewRun()
        {
            _skill = Levels.Record(SdLevel.Profile).BSkill;
            _started = false; _ended = false; _cleared = 0;
            Idx = 0; ClearedShown = 0;
            _adUsed = false; _gemSaves = 0; _saveErr = null; _warn = false; _over = null;
            _label = Levels.Clock(Levels.BlitzSpecOf(0, _skill).Ms);
            _clk.Reset();
            _dirty = true;
            NewBoard();
        }

        // ---- each board ----------------------------------------------------------------------------------------------------
        void NewBoard()
        {
            var spec = Levels.BlitzSpecOf(Idx, _skill);
            if (Phase != "between") SetPhase("loading");
            _placed = 0; _combo = 0; _lastSecond = -1;
            // (a board made ahead: getPuzzle resolves at once)
            {
                var puzzle = PuzzleSource(spec.N, spec.Tier);
                var mine = new List<SdCreature>(_cast);
                var pieces = Pick(mine.ToArray(), spec.N);
                Board?.Unmount();
                Spec = spec; Puzzle = puzzle; _pieces = pieces; _given = puzzle.Solution[0];
                MakeBoard();
                _label = Levels.Clock(spec.Ms);
                _warn = false;
                _dirty = true;
                SetPhase(_started ? "intro" : "countdown");
            }
        }

        static SdCreature[] Pick(SdCreature[] roster, int k)
        {
            var pool = new List<SdCreature>(roster);
            var o = new List<SdCreature>();
            while (o.Count < k && pool.Count > 0) { int i = (int)Math.Floor(SdLevel.Random() * pool.Count); o.Add(pool[i]); pool.RemoveAt(i); }
            while (o.Count < k) o.Add(roster.Length > 0 ? roster[o.Count % roster.Length] : null);
            return o.ToArray();
        }

        void MakeBoard()
        {
            int n = Puzzle.N;
            var geo = Rooms.Geometry(ROOM, W, H);
            var B = Squishdoku.Board.Layout(n, n, AreaW, H, geo.FloorY - 0, Squishdoku.Board.SDK_TILT, 80);
            Board = new SdBoard(B, n, Puzzle.Regions, Puzzle.Solution, null, _pieces, _tk, () => Phase != "play", false, Effect)
            {
                OnTap = OnTap,
                OnTapPiece = cell => { Snd.Play("sd_squeak", rate: 0.85 + SndRandom.NextDouble() * 0.35); Board.Wiggle(cell); },
            };
        }

        void DropGiven() { Board.Place(_given); Snd.Play("sd_place"); _placed = 1; }
        static double LandMs(int n) => (2 * n - 1) * 34 + 250;

        // 3, 2, 1, GO!
        void StartCountdown()
        {
            CountdownAt = _tk.Now;
            const double GO = 200 + 3 * 700;
            string[] steps = { "3", "2", "1", "GO!" };
            for (int i = 0; i < 4; i++)
            {
                var s = steps[i];
                PhaseLater(200 + i * 700, () =>
                {
                    SetCount(s);
                    Snd.Play(s == "GO!" ? "sd_go" : "sd_count");
                    Snd.Tick();
                    if (s == "GO!") { _buddy.React("start"); Board.Intro(); Snd.Play("sd_boardIn", delay: 120); }
                });
            }
            double settled = GO + LandMs(Spec.N);
            PhaseLater(settled, DropGiven);
            PhaseLater(settled + GIVEN_MS, () =>
            {
                SetCount(null);
                _started = true;
                SetPhase("play");
                _clk.Start(Spec.Ms);
            });
        }

        void SetCount(string s) { Count = s; _dirty = true; Effect(() => _countdown.Set(Count)); }

        void StartIntro()
        {
            double settled = 40 + LandMs(Spec.N);
            PhaseLater(40, () => { Board.Intro(); Snd.Play("sd_boardIn"); });
            PhaseLater(settled, DropGiven);
            PhaseLater(settled + GIVEN_MS, () => { SetPhase("play"); _clk.Start(Spec.Ms); });
        }

        // ---- the clock -------------------------------------------------------------------------------------------------
        void StartInterval()
        {
            StopInterval();
            Action tick = null;
            tick = () =>
            {
                _interval = _tk.SetTimeout(tick, 150);
                if (Phase != "play") return;
                double rest = _clk.Limit - _clk.Elapsed;
                _label = Levels.Clock(rest);
                int sec = (int)Math.Ceiling(rest / 1000);
                if (rest <= HURRY_MS && rest > 0 && sec != _lastSecond)
                {
                    if (_lastSecond < 0) _buddy.React("hurry");
                    _lastSecond = sec;
                    Snd.Play("sd_tick", rate: sec <= 3 ? 1.3 : 1);
                    _warn = true;
                }
                _dirty = true;
                if (rest <= 0) Lose("time");
            };
            _interval = _tk.SetTimeout(tick, 150);
        }
        void StopInterval() { if (_interval >= 0) _tk.ClearTimeout(_interval); _interval = -1; }

        // ---- a mistake or the clock: save the run, or GAME OVER ------------------------------------------------------------
        void Lose(string reason)
        {
            _clk.Pause();
            _failReason = reason;
            _warn = false;
            _saveErr = null;
            if (reason == "time")
            {
                SetPhase("between");
                _buddy.React("timeup");
                Snd.Play("sd_timeUp");
                Board.Shake();
                Later(900, () => SetPhase("save"));
            }
            else SetPhase("save");
        }

        void GoOn()
        {
            _saving = false;
            _lastSecond = -1;
            Snd.Play("sd_revive");
            SetPhase("play");
            if (_failReason == "time") _clk.Start(Spec.Ms);
            else _clk.Resume();
        }

        void SaveByAd()
        {
            void Back() { _adUsed = true; GoOn(); }
            if (AdsFree) Back(); else ShowAd(Back);
        }

        void SaveByGems()
        {
            if (_saving) return;
            _saveErr = null;
            if (SdSave.BlitzSave != null) { SaveByGemsOnServer(); return; }
            var err = SpendGems(Levels.BlitzSaveGems(_gemSaves));
            if (err == null) { _gemSaves++; GoOn(); }
            else { _saveErr = err == "not_enough_gems" ? "Not enough gems" : "Couldn't reach the server. Try again?"; RefreshSave(); }
        }

        // signed in, BlitzGame.js saveByGems: SAVING… while the `squad` callable takes the gems; then on from the same
        // board, or the card's error (the await comes back on Unity's main thread)
        async void SaveByGemsOnServer()
        {
            _saving = true;
            RefreshSave();
            int price = Levels.BlitzSaveGems(_gemSaves);
            string err;
            try { err = await SdSave.BlitzSave(_gemSaves); }
            catch (Exception e) { err = e.Message ?? "error"; }
            if (err == null)
            {
                // what the server took, on the game's copy of the profile (the menu's feed re-reads the account)
                SdLevel.Profile["gems"] = (double)Math.Max(0, Gems() - price);
                _gemSaves++;
                if (Phase == "save") GoOn(); else _saving = false;
                return;
            }
            _saving = false;
            _saveErr = err == "not_enough_gems" ? "Not enough gems" : "Couldn't reach the server. Try again?";
            RefreshSave();
        }

        BlitzOutcome Settle()
        {
            if (!_started || _ended) return null;
            _ended = true;
            var outc = Levels.AfterBlitz(SdLevel.Profile, _cleared);
            if (Save) { SdSave.Paid(outc, SdLevel.Profile); Apply(outc.Update); }
            return outc;
        }

        static void Apply(Dictionary<string, object> update)
        {
            foreach (var kv in update)
            {
                var parts = kv.Key.Split('.');
                IDictionary<string, object> m = SdLevel.Profile;
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (!(m.TryGetValue(parts[i], out var next) && next is IDictionary<string, object> nm)) { nm = new Dictionary<string, object>(); m[parts[i]] = nm; }
                    m = nm;
                }
                m[parts[parts.Length - 1]] = kv.Value;
            }
        }

        void GameOver()
        {
            _clk.Pause();
            int top = Top;
            var outc = Settle();
            _over = new SdBlitzCards.OverResult
            {
                Cleared = _cleared, Best = Math.Max(top, _cleared), NewTop = outc?.NewTop ?? false,
                Coins = outc?.Coins ?? 0, Xp = outc?.Xp ?? 0, LevelUps = outc?.LevelUps?.Count ?? 0,
                Before = outc?.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc?.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            SetPhase("over");
            _buddy.React("timeup");
            if (_over.NewTop) { Snd.Play("sd_blitzWin"); Snd.Win(); }
            else { Snd.Play("sd_blitzFail"); Snd.Play("sd_drain", delay: 600); }
            if (_over.NewTop)
                for (int i = 0; i < 3; i++) { int k = i; Later(k * 300, () => TopBurst(W * (0.25 + 0.25 * k), H * 0.3)); }
        }

        void BoardDone()
        {
            _clk.Pause();
            SetPhase("between");
            int idx = Idx;
            _cleared = idx + 1;
            _buddy.React("solve");
            Board.HopAll();
            for (int r = 0; r < Puzzle.N; r++) Snd.Play("sd_hop", delay: r * 70, rate: 0.95 + r * 0.06);
            Later(300, () => { ClearedShown = idx + 1; _dirty = true; Snd.Play("sd_pip", rate: 0.9 + Math.Min(12, idx) * 0.05); });
            Later(650, () => { Snd.Play("sd_blitzNext"); Board.Outro(); });
            Later(1000, () => { Idx = idx + 1; _dirty = true; Effect(NewBoard); });
        }

        // ---- touches -----------------------------------------------------------------------------------------------------
        void OnTap(int cell)
        {
            if (Phase != "play" || Puzzle == null) return;
            int n = Puzzle.N;
            if (Puzzle.Solution[cell / n] == cell % n)
            {
                Board.Place(cell);
                Snd.Play("sd_place", rate: 1 + Math.Min(8, _combo) * 0.06);
                Snd.Place();
                _combo++;
                if (_placed + 1 < n) _buddy.React("right", _combo);
                _placed++;
                if (_placed == n) BoardDone();
                return;
            }
            _clk.Pause();
            SetPhase("between");
            Board.Wrong(cell);
            Snd.Play("sd_wrong");
            Later(200, Snd.Wrong);
            _buddy.React("wrong");
            _combo = 0;
            Later(1000, () => Lose("mistake"));
        }

        // ---- pause, back, leaving --------------------------------------------------------------------------------------------
        public void Pause() => AsInput(PauseNow);
        void PauseNow()
        {
            if (Phase != "play") return;
            _clk.Pause();
            Snd.Play("sd_pause");
            SetPhase("paused");
        }
        void Resume() { SetPhase("play"); _clk.Resume(); }

        void Exit()
        {
            _clk.Pause();
            Settle();
            foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            ClearPhaseTimers();
            StopInterval();
            Board?.Unmount();
            _buddy.Unmount();
            OnExit?.Invoke();
        }

        /// <summary>BackHandler: playing pauses; the save card ends the run; anything else leaves.</summary>
        public void Back() => AsInput(() => { if (Phase == "play") PauseNow(); else if (Phase == "save") GameOver(); else Exit(); });

        void Again()
        {
            Settle();
            _run++;
            foreach (var t in _timers) _tk.ClearTimeout(t);
            _timers.Clear();
            _over = null;
            NewRun();
        }

        // ---- the cards (PauseCard blitz, BlitzSaveCard, BlitzOverCard: always there, shown by the phase) ----------------
        ICardView _pauseCard, _saveCard, _overCard;
        readonly List<ICardView> _cards = new List<ICardView>();
        public IEnumerable<ICardView> Cards => _cards;
        bool CardOpen { get { foreach (var c in _cards) if (c.Visible) return true; return false; } }
        string _saveKey;

        void Show(ref ICardView slot, ICardView c)
        {
            slot?.Hide();
            slot = c;
            _cards.Remove(c);
            // paint order: pause, save, over (BlitzGame's)
            int rank = c == _pauseCard ? 0 : c == _saveCard ? 1 : 2;
            int at = 0;
            while (at < _cards.Count && Rank(_cards[at]) <= rank) at++;
            _cards.Insert(at, c);
            c.Show();
        }
        int Rank(ICardView c) => c == _pauseCard ? 0 : c == _saveCard ? 1 : 2;

        SdBlitzCards.SaveState SaveState() => new SdBlitzCards.SaveState
        {
            Reason = _failReason, Board = Idx + 1, Cleared = ClearedShown, AdUsed = _adUsed, AdReady = AdReady(), AdsFree = AdsFree,
            Gems = Gems(), Price = Levels.BlitzSaveGems(_gemSaves), Saving = _saving, Error = _saveErr,
        };

        void RefreshSave()
        {
            if (!(_saveCard is BroadCard card) || !card.Shown) return;
            var st = SaveState();
            var key = $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";
            if (key == _saveKey) return;
            _saveKey = key;
            // the card (up, or closing) keeps its motion; its row of buttons is made again from the new props
            ((ButtonRowItem)card.Items[card.Items.Count - 1]).SetRow(SdBlitzCards.SaveRow(st, () => AsInput(SaveByAd), () => AsInput(SaveByGems), () => AsInput(GameOver)));
            card.Relayout();
        }

        void SyncCards()
        {
            if (Phase == "paused" && (_pauseCard == null || !_pauseCard.Visible))
            {
                ICardView c = new CardView(BlitzCards.Pause(W, H, () => AsInput(Resume), () => AsInput(Exit)));
                _pauseCard?.Hide();
                _pauseCard = c;
                Show(ref _pauseCard, c);
            }
            else if (Phase != "paused") _pauseCard?.Hide();
            if (Phase == "save" && (_saveCard == null || !_saveCard.Visible))
            {
                var st = SaveState();
                _saveKey = $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";
                ICardView c = SdBlitzCards.Save(W, H, st, () => AsInput(SaveByAd), () => AsInput(SaveByGems), () => AsInput(GameOver));
                _saveCard?.Hide();
                _saveCard = c;
                Show(ref _saveCard, c);
            }
            else if (Phase != "save") _saveCard?.Hide();
            if (Phase == "over" && _over != null && (_overCard == null || !_overCard.Visible))
            {
                ICardView c = SdBlitzCards.Over(W, H, _over, () => AsInput(Again), () => AsInput(Exit));
                _overCard?.Hide();
                _overCard = c;
                Show(ref _overCard, c);
            }
            // (a new run: its `res` is gone, the card empties as it closes)
            else if (Phase != "over") _overCard?.Hide(_over == null);
        }

        // ---- the screen's confetti (over the cards) ---------------------------------------------------------------------
        readonly List<Burst> _top = new List<Burst>();
        void TopBurst(double x, double y)
        {
            var b = new Burst("confetti", x, y, 1);
            _top.Add(b);
            b.Start(() => _top.Remove(b));
        }

        // =====================================================================================================================
        // ---- the HUD: the left column (the top bar, the glass), the right (the buddy on its glass) -------------------------
        readonly SdLayer _room, _cribLip, _cribFace, _glass, _barL, _barText, _right;
        readonly SdBuddy _buddy;
        readonly Countdown _countdown = new Countdown();
        string _glassKey, _icon;

        static readonly TextStyle BoardNo = new TextStyle { Font = SdArt.Heavy, Size = 11, Color = "#ffffff", LetterSpacing = 0.8f, Shadows = new[] { new Shadow(SdArt.CRIB_INK, 0, 1, 1.5f) } };
        static readonly TextStyle ScoreNum = new TextStyle { Font = SdArt.Display, Size = 30, Color = "#ffffff", Shadows = new[] { new Shadow(SdArt.CRIB_INK, 0, 2, 1.5f) } };
        static readonly TextStyle ScoreLabel = new TextStyle { Font = SdArt.Display, Size = 10.5f, Color = "#ffe6c2", LetterSpacing = 1 };
        public static readonly TextStyle Hint = new TextStyle { Font = SdArt.Heavy, Size = 11.5f, LineHeight = 16, Color = "#ffffff" };
        static readonly string[] HintLines = { "Tap to place · no ✕ in Blitz", "one mistake ends the run!" };

        // where things are (dp): the top bar's row 8 down (the title 40.891, BOARD n under it 2 dp up), the glass 6 + 2 below
        public static float HeaderH => SdArt.TitleH - 2 + UiSvg.LineBox(BoardNo);
        public static float CribY => SdArt.HeaderY + (HeaderH - 52) / 2;
        public static float GlassY => SdArt.HeaderY + HeaderH + 6 + 2;
        const float GlassX = 10, GlassW = SdArt.LeftW - 10;
        static float ScoreH => UiSvg.LineBox(ScoreNum) + UiSvg.LineBox(ScoreLabel) - 2;
        public static float ChipY => GlassY + 2 + 6 + ScoreH + 6;
        public static float BarY => ChipY + 24 + 8;
        public static float GlassH => BarY - GlassY + SdArt.BarH + 6 + 2;
        public static float BarX => GlassX + (GlassW - SdArt.BarW) / 2;

        /// <summary>The right column's glass and where the buddy and the hint go.</summary>
        public static (float gx, float gy, float gw, float gh, float bx, float by, float hx, float hy, float hw) Right(float w, float h)
        {
            float hw = 0;
            foreach (var l in HintLines) hw = Math.Max(hw, UiSvg.BoxWidth(l, Hint));
            float inner = Math.Max(80, hw);
            float gw = 2 + 14 + inner + 14 + 2, gh = 2 + 4 + 80 + 12 + 2 * 16 + 4 + 2;
            float gx = Card.Snap(w - SdArt.RightW + (SdArt.RightW - gw) / 2), gy = h - 10 - gh;
            return (gx, gy, gw, gh, Card.Snap(gx + 16 + (inner - 80) / 2), gy + 6, Card.Snap(gx + 16 + (inner - hw) / 2), gy + 6 + 80 + 12, hw);
        }

        static string GlassSvg(int idx, int cleared, int top, float h)
        {
            var s = new UiSvg(SdArt.LeftW, h);
            SdArt.RoomTitle(s, "Blitz Mode", 66, SdArt.HeaderY);
            s.Text($"BOARD {idx + 1}", 66, SdArt.HeaderY + SdArt.TitleH - 2, BoardNo);
            s.Box(GlassX, GlassY, GlassW, GlassH, new BoxStyle { Background = SdArt.GLASS, Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            // the score row: CLEARED | BEST (or NEW BEST!, gold), each at least 64 wide, 14 apart round a 2 dp line
            bool beat = cleared > top && top > 0;
            string best = Math.Max(top, cleared).ToString(), bestLabel = beat ? "NEW BEST!" : "BEST";
            var gold = new TextStyle { Font = SdArt.Display, Size = 30, Color = "#ffd23a", Shadows = ScoreNum.Shadows };
            var goldLabel = new TextStyle { Font = SdArt.Display, Size = 10.5f, Color = "#ffd23a", LetterSpacing = 1 };
            float w1 = Math.Max(64, Math.Max(UiSvg.BoxWidth(cleared.ToString(), ScoreNum), UiSvg.BoxWidth("CLEARED", ScoreLabel)));
            float w2 = Math.Max(64, Math.Max(UiSvg.BoxWidth(best, ScoreNum), UiSvg.BoxWidth(bestLabel, ScoreLabel)));
            float rowW = w1 + 14 + 2 + 14 + w2, x0 = Card.Snap(GlassX + 2 + 12 + (GlassW - 28 - rowW) / 2), y0 = GlassY + 2 + 6;
            float nh = UiSvg.LineBox(ScoreNum);
            s.Text(cleared.ToString(), x0, y0, ScoreNum, w1, 0.5f);
            s.Text("CLEARED", x0, y0 + nh - 2, ScoreLabel, w1, 0.5f);
            s.Box(x0 + w1 + 14, y0 + 6, 2, ScoreH - 12, new BoxStyle { Background = "rgba(255,255,255,0.35)", Radius = 1 });
            float x2 = x0 + w1 + 14 + 2 + 14;
            s.Text(best, x2, y0, beat ? gold : ScoreNum, w2, 0.5f);
            s.Text(bestLabel, x2, y0 + nh - 2, beat ? goldLabel : ScoreLabel, w2, 0.5f);
            // the rule
            float cw = UiSvg.BoxWidth("1 MISTAKE = GAME OVER", new TextStyle { Font = SdArt.Display, Size = 11.5f, LetterSpacing = 0.5f }) + 22;
            SdArt.Chip(s, Card.Snap(GlassX + (GlassW - cw) / 2), ChipY, "1 MISTAKE = GAME OVER", "#e01e4a");
            return s.Markup;
        }

        // =====================================================================================================================
        readonly Dictionary<CardLayer, SdLayer> _mirrors = new Dictionary<CardLayer, SdLayer>();
        readonly List<SdLayer> _frame = new List<SdLayer>();

        /// <summary>Everything on screen now, bottom first (call after the Ticker's tick). Cards and the top confetti last.</summary>
        public List<SdLayer> Layers()
        {
            var o = _frame;
            o.Clear();
            o.Add(_room);
            if (_dirty) { _dirty = false; }
            RefreshSave();
            // the left column
            var icon = Phase == "play" ? "pause" : "back";
            if (icon != _icon) { _icon = icon; _cribLip.Set(_xml($"crib-{icon}-lip"), 48, 48, 2); _cribFace.Set(_xml($"crib-{icon}-face"), 48, 52, 2); }
            // (held: the whole crib button, lip and face, 48 x 52, shrinks to 0.92 about its centre)
            var crib = Affine.Translate(SdArt.CribX, CribY) * Fx.Pressed(48, 52, _cribPress ? 1 : 0);
            _cribLip.Transform = crib * Affine.Translate(0, 4);
            _cribFace.Transform = crib;
            o.Add(_cribLip); o.Add(_cribFace);
            int top = Top;
            var key = $"{Idx}|{ClearedShown}|{top}";
            if (key != _glassKey) { _glassKey = key; _glass.Set(GlassSvg(Idx, ClearedShown, top, H), SdArt.LeftW, H, 4); }
            o.Add(_glass);
            double frac = _clk.Frac.GetValue();
            _warnPulse(_warn);
            double warn = _warnLoop?.Value ?? 0;
            _barL.Set(SdArt.Bar(Math.Round(frac * 1900) / 1900, Math.Round(warn * 50) / 50), SdArt.BarW, SdArt.BarH, 2);
            var bar = Affine.Translate(BarX, BarY) * Fx.About(SdArt.BarW, SdArt.BarH, Affine.ScaleBy(1 + 0.04 * warn, 1 + 0.04 * warn));
            _barL.Transform = bar; o.Add(_barL);
            _barText.Set(SdArt.BarText(_label, _warn), SdArt.BarW, SdArt.BarH, 2);
            _barText.Transform = bar; o.Add(_barText);
            // the board (hidden while paused, and during the countdown until GO drops it in)
            bool hidden = Phase == "paused" || (Phase == "countdown" && Count != "GO!");
            if (Board != null) Board.Layers(Affine.Translate(AreaX, 0), o, hidden ? 0 : 1);
            _countdown.Place(AreaX, 0, AreaW, H);
            foreach (var l in _countdown.Layers) o.Add(SdLayer.Mirror(l, _mirrors));
            // the right column
            var R = Right(W, H);
            if (_right.Markup == null)
            {
                var s = new UiSvg(W, H);
                s.Box(R.gx, R.gy, R.gw, R.gh, new BoxStyle { Background = SdArt.GLASS, Radius = 22, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
                for (int i = 0; i < HintLines.Length; i++) s.Text(HintLines[i], R.hx, R.hy + i * 16, Hint);
                _right.Set(s.Markup, W, H, 0);
            }
            o.Add(_right);
            _buddy.Layers(R.bx, R.by, o);
            // the cards, then the new best's confetti over them
            foreach (var c in _cards)
            {
                c.Update();
                foreach (var l in c.Layers()) o.Add(SdLayer.Mirror(l, _mirrors));
            }
            _cards.RemoveAll(c => !c.Shown);
            foreach (var b in _top) { b.Place(Affine.Identity, 1); foreach (var l in b.Layers) o.Add(SdLayer.Mirror(l, _mirrors)); }
            if (_mirrors.Count > o.Count + 64)
            {
                var seen = new HashSet<SdLayer>(o);
                var dead = new List<CardLayer>();
                foreach (var kv in _mirrors) if (!seen.Contains(kv.Value)) dead.Add(kv.Key);
                foreach (var d in dead) _mirrors.Remove(d);
            }
            return o;
        }

        KeyLoop _warnLoop;
        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);
        void _warnPulse(bool on)
        {
            if (on && _warnLoop == null) { _warnLoop = new KeyLoop(500, KeyLoop.PHASE, TRIANGLE); _warnLoop.Mount(); }
            else if (!on && _warnLoop != null) { _warnLoop.Unmount(); _warnLoop = null; }
        }

        // ---- input (screen dp) -----------------------------------------------------------------------------------------------
        bool _cribPress, _cardDown, _onBoard;

        public void Down(float x, float y) => AsInput(() => DownNow(x, y));
        public void Move(float x, float y) => AsInput(() => { if (_onBoard) Board?.Move(x - AreaX, y); });
        public void Up(float x, float y) => AsInput(() => UpNow(x, y));

        static bool OnCrib(float x, float y) => x >= SdArt.CribX - 4 && x <= SdArt.CribX + 52 && y >= CribY - 4 && y <= CribY + 56;

        void DownNow(float x, float y)
        {
            if (CardOpen)
            {
                for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].Down(x, y)) break;
                _cardDown = true;
                return;
            }
            if (OnCrib(x, y)) { _cribPress = true; return; }
            if (x >= AreaX && x < AreaX + AreaW && Board != null) { _onBoard = true; Board.Down(x - AreaX, y); }
        }

        void UpNow(float x, float y)
        {
            if (_cardDown) { _cardDown = false; for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].Up(x, y)) break; return; }
            if (_cribPress)
            {
                _cribPress = false;
                if (OnCrib(x, y)) { if (Phase == "play") PauseNow(); else Exit(); }
                return;
            }
            if (_onBoard) { _onBoard = false; Board?.Up(); }
        }

        /// <summary>A tap on cell `cell` as a finger would (tests).</summary>
        public void TapCell(int cell)
        {
            var q = Board.B.Project(cell % Puzzle.N + 0.5, cell / Puzzle.N + 0.5);
            Down((float)(AreaX + q.X), (float)q.Y);
            Up((float)(AreaX + q.X), (float)q.Y);
        }

        /// <summary>Presses a card button by its label (tests).</summary>
        public bool Press(string label)
        {
            Layers();
            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                if (!_cards[i].Visible) continue;
                foreach (var b in _cards[i].Buttons)
                    if (b.Look.Label.StartsWith(label))
                    {
                        var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                        Down((float)p.X, (float)p.Y); Up((float)p.X, (float)p.Y);
                        return true;
                    }
            }
            return false;
        }

        public int Cleared => _cleared;
        public bool AdUsed => _adUsed;
        public int GemSaves => _gemSaves;
        public double ClockLeft => _clk.Limit - _clk.Elapsed;
        public bool ClockRunning => _clk.Running;
    }
}
