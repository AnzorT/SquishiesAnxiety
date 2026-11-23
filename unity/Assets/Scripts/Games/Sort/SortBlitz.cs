// Squish Sort's BLITZ (src/sort/Game.js's `blitz` branches, SortBlitz): ten rounds (Levels.BlitzSpec: levels 2, 5, 8 ...
// 33 of the map at the Blitz skill), the Snack Fridge and the Toy Cupboard taking turns (Levels.BlitzTheme), each round
// played as a Regular level (intro ROUND n with the container's name, deal, peek, shut, shake, tumble, sort) on one 5:00
// clock for the run that runs only while sorting. The HUD: BLITZ ⚡ · the model, ROUND n/10 and its tier, the revive
// chip (♥ 1 REVIVE / REVIVE USED) in the hearts' place, the run's ten pips (Ui/Blitz Pips, small), the clock all along.
//   a round sorted   the hop wave; its pip fills 300 ms later; the next round 1500 ms after (the last: BLITZ CHAMPION!
//                    1100 ms after, Levels.AfterBlitz's coins and XP)
//   a mistake        the clock stops ("held"); 800 ms later OOPS! (REVIVE, free: Unity has no ads unless the host
//                    hooks Run.AdsFree / AdReady / ShowAd) or, the revive used, BACK TO ROUND 1!
//   the clock out    BACK TO ROUND 1! (GO AGAIN / QUIT); the pips drain
//   pause            the back orb (or Android's back) while sorting: the Blitz pause card (RESUME / START OVER / QUIT)
// The run's rules and cards are the shared Ui/Blitz BlitzRun's (MistakeMs 800, NextMs 1500, WinMs 1100); this file is
// SortLevel's Blitz half (the level's timeline, drawing and touch are SortLevel.cs's, with `_blitz` branches where
// Game.js has them). Open it with SortLevel.Blitz(...) (SortGame.CreateBlitz in Unity). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Sort
{
    public sealed partial class SortLevel
    {
        bool _blitz;
        BlitzRun _run;
        Pips _pips;
        bool _runStarted;   // Game.js runStarted: the run's clock has been started (its first sorting)

        /// <summary>Blitz: the run (its round, pips, revive, cards); the host sets AdsFree / AdReady / ShowAd / Sound on it.</summary>
        public BlitzRun Run => _run;
        public bool IsBlitz => _blitz;
        /// <summary>Blitz: whether the run's record and pay go into Profile (the app's `uid`; off as its preview player).</summary>
        public bool Save = true;
        /// <summary>Blitz: the win card's three creatures from every squishy both containers draw from (squishdoku/game.js
        /// pickCreatures); tests hand in the app's.</summary>
        public Func<IList<string>, int, string[]> PickCreatures;

        /// <summary>A Blitz run from round 1 on a `screenW` x `screenH` dp screen; then Start() as a level.</summary>
        public static SortLevel Blitz(float screenW, float screenH, SortData data, IDictionary<string, object> profile)
        {
            var l = new SortLevel("fridge", 1, screenW, screenH, data, profile) { _blitz = true };
            l.PickCreatures = l.Pick;
            var run = new BlitzRun(screenW, screenH, "round", new BlitzRun.Timings { MistakeMs = 800, NextMs = 1500, WinMs = 1100 }, Levels.BLITZ_ROUNDS)
            {
                AdsFree = true,
                Best = () => (int)(Levels.Record(l.Profile).Blitz.Reached ?? 0),
            };
            l._run = run;
            l._pips = new Pips(Levels.BLITZ_ROUNDS, small: true);   // (landscape's narrow column)
            run.OnNext = _ => l.NewRound();
            run.OnLost = l.RunLost;
            run.OnWon = l.RunWon;
            run.OnRevived = l.Revived;
            run.OnAgain = l.Again;
            run.OnResume = l.Resume;
            run.OnQuit = l.Leave;
            // Hud.js Pips: its effect on `done` once React has rendered it
            run.OnDone = d => l.Effect(() => l._pips.SetDone(d));
            return l;
        }

        // Game.js mistake(), blitz: one mistake and the clock stops; the revive, or the run's over
        void BlitzMistake()
        {
            _clk.Pause();
            Phase = "held";
            _selected = null;
            _run.Mistake();
        }

        // Game.js startPlace(), blitz: the run's one clock goes on from where the last round left it
        void BlitzClock()
        {
            if (_runStarted) _clk.Resume();
            else
            {
                _runStarted = true;
                _left = Levels.BLITZ_MS / 1000;
                _clk.Start(Levels.BLITZ_MS);
            }
        }

        // Game.js endRun: the run's over (the card and the pips are BlitzRun's)
        void RunLost(string reason, int reached)
        {
            Phase = "lost";
            _clk.Pause();
            _selected = null;
            _hoverO.SetValue(0);
            var outc = Levels.AfterBlitz(Profile, false, reached);
            if (Save) Apply(outc.Update);
        }

        // Game.js win(), blitz, the last round: what the run paid, for BLITZ CHAMPION!
        BlitzCards.WinResult RunWon()
        {
            double ms = _clk.Elapsed();
            var rec = Levels.Record(Profile);
            var outc = Levels.AfterBlitz(Profile, true, Levels.BLITZ_ROUNDS, ms);
            if (Save) Apply(outc.Update);
            var all = new List<string>();
            foreach (var t in new[] { "fridge", "cupboard" }) if (_data.Pools.TryGetValue(t, out var pool)) foreach (var p in pool) all.Add(p.Uri);
            double best = rec.Blitz.BestMs ?? 0;
            return new BlitzCards.WinResult
            {
                Ms = ms, Coins = outc.Coins, Xp = outc.Xp, LevelUps = outc.LevelUps?.Count ?? 0,
                NewBest = best == 0 || double.IsNaN(best) || ms < best,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
                Pictures = PickCreatures(all, 3),
            };
        }

        string[] Pick(IList<string> roster, int k)
        {
            var pool = new List<string>(roster);
            var outp = new List<string>();
            while (outp.Count < k && pool.Count > 0) { int i = (int)Math.Floor(Random() * pool.Count); outp.Add(pool[i]); pool.RemoveAt(i); }
            while (outp.Count < k) outp.Add(roster.Count > 0 ? roster[outp.Count % roster.Count] : null);
            return outp.ToArray();
        }

        // Game.js revive(): back to sorting, the clock running on
        void Revived()
        {
            Phase = "place";
            _clk.Resume();
            Effect(() => { if (Phase == "place" && !_paused) StartInterval(); });
        }

        // Game.js again(): a fresh run from round 1 (BlitzRun has emptied the pips and closed the cards)
        void Again()
        {
            ClearTimers();
            _clk.Reset();
            _runStarted = false;
            _left = 0;
            _paused = false;
            NewRound();
        }

        // Android's back on the pause card: its RESUME
        void BlitzResume()
        {
            foreach (var c in _run.Cards())
                foreach (var b in c.Buttons)
                    if (b.Look.Label == "RESUME") { b.OnPress?.Invoke(); return; }
            Resume();
        }

        // the pips' row (Game.js styles.pips under the top bar, centred in the column), as level layers
        readonly Dictionary<CardLayer, string> _pipNames = new Dictionary<CardLayer, string>();
        void DrawPips(SortArt.Hud hud)
        {
            _pips.Current = _run.CurrentPip;
            _pips.Place((SortArt.LeftW - _pips.W) / 2, SortArt.PipsY(hud));
            foreach (var cl in _pips.Layers)
            {
                if (!_pipNames.TryGetValue(cl, out var name)) _pipNames[cl] = name = "pips " + _pipNames.Count;
                var l = L(name);
                l.Set(cl.Markup, cl.W, cl.H, cl.Margin);
                l.Transform = cl.Transform;
                l.Opacity = cl.Opacity;
                l.Visible = cl.Visible;
            }
        }
    }
}
