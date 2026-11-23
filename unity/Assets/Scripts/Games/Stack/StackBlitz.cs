// Squish Stack's BLITZ as src/stack/Game.js plays it with `blitz` (the same StackGame, these are its Blitz branches):
// ten puzzles (Levels.BlitzSpec at the player's Blitz skill) on one 4:00 clock (Levels.BLITZ_MS), no HINT.
//   countdown  the run opens with 3, 2, 1, GO! (700 ms apart from 200, Ui/Blitz Countdown over the cushions): the first
//              puzzle drops in on GO, its clock starts once it's dealt
//   intro      every later puzzle: PUZZLE n and its chips, dealt 1250 ms later; the run's clock goes on where it was
//   play       as a level; cleared: everyone hops, its pip fills 300 ms later, the next puzzle at 1300 (the tenth: the
//              BLITZ CHAMPION! card at 1000, coins and XP from Levels.AfterBlitz)
//   held       a big one dropped on a smaller one is a mistake: the clock stops, 1000 ms later the revive card (REVIVE,
//              free with Remove Ads, once a run) or, revived already, the run's over
//   lost       the run's over (a mistake, BACK TO PUZZLE 1, the clock): BACK TO PUZZLE 1!, the pips drain; GO AGAIN / QUIT
//   The back orb (Escape, Android's back) while playing pauses: the clock frozen (RESUME / START OVER / QUIT).
// The HUD in Blitz: SQUISH STACK · BLITZ ⚡, PUZZLE n/10, the revive chip, the pips, the goal, the run's clock and bar, the
// rule. The run itself (its pips, revive, the cards and their timings) is Ui/Blitz BlitzRun; the countdown and the pips
// Ui/Blitz's. What happens on the app's next render (a state change's effects) runs on the next frame here (Effect).
//   var g = StackGame.CreateBlitz(parent);  g.OnExit = ...;  (after Init, g.Run holds the run's ad hooks, for when there are ads)
// Not ported: sounds, haptics, the dust / spark / confetti on the board, the rewarded ad (Unity has none: AdsFree).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Stack
{
    public sealed partial class StackGame
    {
        /// <summary>Squish Stack's Blitz run (the hub's BLITZ GO): call Init (or let Unity's Start) as for a level.</summary>
        public static StackGame CreateBlitz(Transform parent, float screenW = 0, float screenH = 0)
        {
            var g = Create(parent, 1, screenW, screenH);
            g._blitz = true;
            g.gameObject.name = "Squish Stack Blitz";
            return g;
        }

        // ---- the host's (and the tests') ------------------------------------------------------------------------------
        /// <summary>A puzzle for a spec (default: Engine.MakePuzzle). Tests hand in the app's.</summary>
        public Func<LevelSpec, Puzzle> PuzzleSource;
        /// <summary>`n` squishies for a puzzle (default: PickCast).</summary>
        public Func<int, Squishy[]> CastSource;
        /// <summary>The win card's three creatures (Resources paths; default: three random squishies).</summary>
        public Func<string[]> WinPictures;
        /// <summary>Whether the run's record and pay go into Profile (the app's `uid`; off as the app's preview player).</summary>
        public bool Save = true;
        /// <summary>The run (Blitz, once Init has run): its ad hooks (AdsFree, AdReady, ShowAd) for when there are ads.</summary>
        public BlitzRun Run => _run;
        /// <summary>When the countdown's timers were set (tests line the app's up with it); -1 before.</summary>
        public double CountdownAt { get; private set; } = -1;
        public bool IsBlitz => _blitz;
        public string Phase => _phase;

        bool _blitz;
        BlitzRun _run;
        StackClock _clk;
        Countdown _countdown;
        Pips _pips;
        bool _runStarted;
        int _bSecs;
        int _interval = -1;
        UiPiece _barPiece;
        (float x, float y, float w) _bar;
        float _down, _backDy;   // PUZZLE n/10 wrapped: the pips (and the orb half as much) lower
        double _barFrac = double.NaN;
        float _barW;
        readonly Dictionary<CardLayer, (UiPiece piece, int version)> _layerPieces = new Dictionary<CardLayer, (UiPiece, int)>();
        readonly HashSet<CardLayer> _layersSeen = new HashSet<CardLayer>();

        // A state change's effects: React runs them once it has rendered. Set off by a timer, that's the end of the frame (the
        // Ticker's frame callbacks); by a tap (between frames) or by the run's timers (ticked after the frame, below), now.
        bool _inTick;
        void Effect(Action a) { if (_inTick) _anim.RequestAnimationFrame(() => { if (this != null) a(); }); else a(); }

        // The run's timers (BlitzRun's pips, next puzzle, cards) on their own Ticker, ticked once the frame's done: what
        // they set off starts at the frame's end, as the app's cards and pips start on the render after the timer.
        Ticker _runTk;
        void TickAll(double now)
        {
            _inTick = true;
            try { _anim.Tick(now); } finally { _inTick = false; }
            _runTk?.Tick(_anim.Now);
        }

        // a call into the run, its clock first brought up to now (its timers count from here)
        void RunCall(Action a)
        {
            bool was = _inTick;
            _inTick = false;
            _runTk.Tick(_anim.Now);
            _inTick = was;
            a();
        }

        void BlitzInit()
        {
            _clk = new StackClock(_anim);
            _countdown = new Countdown();
            _pips = new Pips(Levels.BLITZ_ROUNDS, small: true);
            _pips.Mount();
            _barPiece = Piece("clock bar", 11);
            _bSecs = Levels.BLITZ_MS / 1000;
            _runTk = new Ticker(_anim.Now);
            Ticker.Default = _runTk;   // (BlitzRun times its own steps on the Ticker it's made with)
            _run = new BlitzRun(W, H, "puzzle", new BlitzRun.Timings { MistakeMs = 1000, NextMs = 1300, WinMs = 1000 }) { AdsFree = AdsFree, AdReady = () => AdReady };
            Ticker.Default = _anim;
            _run.Best = () => (int)Levels.Record(Profile).Blitz.Reached;
            _run.OnNext = i => NewPuzzle();
            _run.OnLost = BlitzLost;
            _run.OnWon = BlitzWon;
            _run.OnRevived = BlitzRevived;
            _run.OnAgain = BlitzAgain;
            _run.OnQuit = Leave;
            _run.OnResume = BlitzResumed;
            _run.OnDone = d => _pips.SetDone(d);
        }

        // the first puzzle of a run: 3, 2, 1, GO! (the first puzzle drops in on GO); true when it counts down
        bool BlitzIntro()
        {
            if (_runStarted) return false;
            CountdownAt = _anim.Now;
            var steps = new[] { "3", "2", "1", "GO!" };
            for (int i = 0; i < steps.Length; i++)
            {
                var v = steps[i];
                Later(200 + i * 700, () =>
                {
                    Effect(() => _countdown.Set(v));
                    if (v == "GO!") Deal();
                });
            }
            Later(200 + 4 * 700, () => Effect(() => _countdown.Set(null)));
            return true;
        }

        void BlitzStartPlay()
        {
            // the run's one clock goes on from where the last puzzle left it
            if (_runStarted) _clk.Resume();
            else
            {
                _runStarted = true;
                _bSecs = Levels.BLITZ_MS / 1000;
                _clk.Start(Levels.BLITZ_MS);
            }
            Effect(StartInterval);
            Hud();
        }

        // the time left, by the second, and the clock running out (Game.js's 250 ms interval while playing)
        void StartInterval()
        {
            StopInterval();
            if (_phase != "play" || _paused) return;
            void Tick()
            {
                _interval = _anim.SetTimeout(Tick, 250);
                double ms = _clk.Limit - _clk.Elapsed;
                int s = Math.Max(0, (int)Math.Ceiling(ms / 1000));
                if (s != _bSecs) { _bSecs = s; Hud(); }
                if (ms <= 0) Lose();
            }
            _interval = _anim.SetTimeout(Tick, 250);
        }

        void StopInterval()
        {
            if (_interval >= 0) _anim.ClearTimeout(_interval);
            _interval = -1;
        }

        // a mistake stops the clock; then the revive, or the run's over
        void BlitzMistake()
        {
            _clk.Pause();
            StopInterval();
            _phase = "held";
            _glow = null;
            if (_held.HasValue) Drop(_held.Value.from);
            RunCall(_run.Mistake);
            Hud();
        }

        // the run's over (BlitzRun has opened the fail card)
        void BlitzLost(string reason, int reached)
        {
            _phase = "lost";
            _clk.Pause();
            StopInterval();
            _glow = null;
            if (_held.HasValue) Drop(_held.Value.from);
            var outc = Levels.AfterBlitz(Profile, false, reached, 0);
            if (Save) { StackSave.Record(outc.Update); Apply(outc.Update); }
            Hud();
        }

        BlitzCards.WinResult BlitzWon()
        {
            double ms = _clk.Elapsed;
            var rec = Levels.Record(Profile);
            var outc = Levels.AfterBlitz(Profile, true, Levels.BLITZ_ROUNDS, ms);
            if (Save) { StackSave.Paid(outc, Profile); Apply(outc.Update); }
            Hud();
            return new BlitzCards.WinResult
            {
                Ms = ms, Coins = outc.Coins, Xp = outc.Xp,
                NewBest = rec.Blitz.BestMs == 0 || double.IsNaN(rec.Blitz.BestMs) || ms < rec.Blitz.BestMs,
                LevelUps = outc.LevelUps?.Count ?? 0,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
                Pictures = WinPictures != null ? WinPictures() : ThreePictures(),
            };
        }

        // squishdoku/game.js pickCreatures(roster, 3)
        string[] ThreePictures()
        {
            var pool = new List<Squishy>(_layout.art.Values);
            var rand = new System.Random();
            var o = new string[3];
            for (int i = 0; i < 3 && pool.Count > 0; i++) { int j = rand.Next(pool.Count); o[i] = pool[j].Picture; pool.RemoveAt(j); }
            return o;
        }

        // the run's one revive: back to it
        void BlitzRevived()
        {
            _phase = "play";
            _clk.Resume();
            Effect(StartInterval);
            Hud();
        }

        void BlitzPause()
        {
            _clk.Pause();
            StopInterval();
            _paused = true;
            RunCall(_run.Pause);
            Hud();
        }

        void BlitzResumed()
        {
            _paused = false;
            _clk.Resume();
            Effect(StartInterval);
            Hud();
        }

        // GO AGAIN, START OVER, AGAIN: a fresh run from puzzle 1 (BlitzRun has closed its cards and emptied the pips)
        void BlitzAgain()
        {
            ClearTimers();
            StopInterval();
            _clk.Reset();
            _runStarted = false;
            _paused = false;
            Effect(() => _countdown.Set(null));
            Effect(NewPuzzle);
            Hud();
        }

        void BlitzHud()
        {
            var d = new StackArt.BlitzHud
            {
                Round = _spec.Round ?? 1, Rounds = Levels.BLITZ_ROUNDS, Tier = _spec.Tier, K = _spec.K, Star = _puzzle.Star,
                Who = _who, Goal = _puzzle.Goal, Revived = _run.Revived,
                ClockText = Levels.Clock((_runStarted ? _bSecs : Levels.BLITZ_MS / 1000) * 1000.0),
                ClockRed = _phase == "play" && _bSecs <= 15,
            };
            _left.SetSvg(StackArt.BlitzLeftColumn(d, H, out _bar, out _down), LeftW, H, 4);
            _backDy = _down / 2;
            _back.Transform = Affine.Translate(_layout.back[0], _layout.back[1] + _backDy);
            bool playing = _phase == "play" && !_paused;
            _btns[0].SetOn(playing && _canUndo);
            _btns[1].SetOn(playing && _moves > 0);
        }

        // every frame: the clock's bar, the pips, the countdown
        void BlitzDraw()
        {
            double frac = _clk.Frac.GetValue();
            if (_bar.w != _barW || Math.Abs(frac - _barFrac) * _bar.w > 0.1)   // (drawn again every 0.1 dp it moves)
            {
                _barW = _bar.w; _barFrac = frac;
                _barPiece.SetSvg(StackArt.BlitzBar(_bar.w, frac), _bar.w, 14, 2);
            }
            _barPiece.Transform = Affine.Translate(_bar.x, _bar.y);
            _pips.Current = _run.CurrentPip;
            _pips.Place((LeftW - _pips.W) / 2, StackArt.PipsY + _down);
            _countdown.Place(LeftW, 0, W - LeftW - RightW, H);
            _layersSeen.Clear();
            SyncLayers(_pips.Layers, 12);
            SyncLayers(_countdown.Layers, 250);
            var gone = new List<CardLayer>();
            foreach (var l in _layerPieces.Keys) if (!_layersSeen.Contains(l)) gone.Add(l);
            foreach (var l in gone) { Destroy(_layerPieces[l].piece.gameObject); _layerPieces.Remove(l); }
        }

        void SyncLayers(List<CardLayer> layers, int order)
        {
            foreach (var l in layers)
            {
                _layersSeen.Add(l);
                if (!_layerPieces.TryGetValue(l, out var e)) e = (Piece(l.Name, 0), -1);
                if (e.version != l.Version) { e.piece.SetSvg(l.Markup, l.W, l.H, l.Margin); e.version = l.Version; }
                _layerPieces[l] = e;
                e.piece.Transform = l.Transform;
                e.piece.Opacity = l.Opacity;
                e.piece.Visible = l.Visible;
                e.piece.Order = order++;
            }
        }

        // ---- the cards over the game: the level's, or the run's ---------------------------------------------------------
        bool AnyCardOpen => _blitz ? _run.CardOpen : CardOpen;

        void CardsDown(float x, float y)
        {
            if (_blitz) { RunCall(() => _run.Down(x, y)); return; }
            for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Down(x, y)) break;
        }

        void CardsUp(float x, float y)
        {
            if (_blitz) { RunCall(() => _run.Up(x, y)); return; }
            for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Up(x, y)) break;
        }

        /// <summary>Taps the open card's button whose label starts with `label` (Android's back resumes a Blitz pause with
        /// it; tests press the cards' buttons with it). False when there's none.</summary>
        public bool PressCard(string label)
        {
            var list = new List<Card>(_blitz ? _run.Cards() : Cards);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var c = list[i];
                if (!c.Visible) continue;
                c.Update();
                foreach (var b in c.Buttons)
                {
                    if (!b.Look.Label.StartsWith(label, StringComparison.Ordinal)) continue;
                    var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                    CardsDown((float)p.X, (float)p.Y);
                    CardsUp((float)p.X, (float)p.Y);
                    return true;
                }
            }
            return false;
        }

        /// <summary>A tap on the back orb (tests): pauses while playing, else leaves.</summary>
        public void TapBack()
        {
            if (AnyCardOpen) return;
            if (_phase == "play") Pause(); else Leave();
        }
    }

    /// <summary>squishdoku/game.js useClock: a clock that can pause, on the game's Ticker; Frac (1 → 0) drives the bar.</summary>
    public sealed class StackClock
    {
        readonly Ticker _tk;
        public readonly AnimatedValue Frac = new AnimatedValue(1);
        double _limit = 1, _used, _since;
        bool _running;
        CompositeAnimation _anim;

        public StackClock(Ticker tk) { _tk = tk; }
        public double Limit => _limit;
        public bool Running => _running;
        public double Elapsed => _used + (_running ? _tk.Now - _since : 0);

        void Run()
        {
            _anim?.Stop();
            Frac.SetValue(Math.Max(0, 1 - _used / _limit));
            _anim = Animated.Timing(Frac, new TimingConfig { ToValue = 0, Duration = Math.Max(1, _limit - _used), Easing = Easing.Linear, UseNativeDriver = true });
            _anim.Start();
        }

        public void Start(double limit, double used = 0) { _limit = limit; _used = used; _since = _tk.Now; _running = true; Run(); }
        public void Pause() { if (!_running) return; _used += _tk.Now - _since; _running = false; _anim?.Stop(); Frac.SetValue(Math.Max(0, 1 - _used / _limit)); }
        public void Resume() { if (_running) return; _since = _tk.Now; _running = true; Run(); }
        public void Reset() { _anim?.Stop(); _limit = 1; _used = 0; _since = 0; _running = false; Frac.SetValue(1); }
    }
}
