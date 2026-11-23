// The rules of a ten-round Blitz run that Squish Stack and Squish Sort share (src/stack/Game.js, src/sort/Game.js):
// one clock for the run; a round cleared fills its pip 300 ms later and moves on (or, the last one, wins the run); a
// mistake stops the clock, then (after `MistakeMs`) the revive card, or, with the revive used, the run's over; the run
// over (a mistake, the revive turned down, the clock) shows the fail card and empties the pips (600 ms after, or 1500
// after the clock ran out). It owns the run's state and its cards (Ui/Blitz BlitzCards), on the screen's clock (Ticker):
// the game says what happened (Cleared, Mistake, TimeUp...), and hears back through the callbacks (sounds, saving,
// resetting its board). The game draws Cards()'s layers over its screen and Pips (or its own), and feeds the cards taps.
//   Stack: new BlitzRun(w, h, "puzzle", new BlitzRun.Timings { MistakeMs = 1000, NextMs = 1300, WinMs = 1000 })
//   Sort:  new BlitzRun(w, h, "round",  new BlitzRun.Timings { MistakeMs = 800,  NextMs = 1500, WinMs = 1100 })
// No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Ui.Blitz
{
    public sealed class BlitzRun
    {
        public sealed class Timings
        {
            /// <summary>From a mistake to the revive card (or the fail card, the revive used).</summary>
            public double MistakeMs = 1000;
            /// <summary>From a round cleared to the next round (setIdx).</summary>
            public double NextMs = 1300;
            /// <summary>From the last round cleared to the win card.</summary>
            public double WinMs = 1000;
            /// <summary>From a round cleared to its pip filling.</summary>
            public double PipMs = 300;
        }

        public readonly int Rounds;
        public readonly string Unit;
        readonly float _w, _h;
        readonly Timings _tm;
        readonly List<int> _timers = new List<int>();
        Ticker _tk;

        /// <summary>The round being played (0-based).</summary>
        public int Idx { get; private set; }
        /// <summary>The pips filled.</summary>
        public int Done { get; private set; }
        public bool Revived { get; private set; }
        /// <summary>null, "revive", "fail" or "win".</summary>
        public string CardName { get; private set; }
        public string FailReason { get; private set; } = "mistake";
        public bool Paused { get; private set; }
        /// <summary>The pip that pulses: the current round's, none once the run's over.</summary>
        public int CurrentPip => CardName == "fail" || CardName == "win" ? -1 : Idx;

        // the game's side
        public Func<bool> AdReady = () => false;
        public bool AdsFree;
        /// <summary>The record: the furthest round reached (the fail card's "best").</summary>
        public Func<int> Best = () => 0;
        /// <summary>A rewarded ad: show it, then call back (not called with Remove Ads).</summary>
        public Action<Action> ShowAd = back => back();
        /// <summary>The next round starts (Idx went up): deal it.</summary>
        public Action<int> OnNext;
        /// <summary>The run's over, lost: (reason, reached) to save (afterBlitz won: false).</summary>
        public Action<string, int> OnLost;
        /// <summary>The run's won: what it paid and the three creatures, for the win card (afterBlitz won: true).</summary>
        public Func<BlitzCards.WinResult> OnWon;
        /// <summary>The revive: the game goes back to playing (its clock resumes).</summary>
        public Action OnRevived;
        /// <summary>GO AGAIN / START OVER: a new run from round 1 (the game resets its clock and deals round 1).</summary>
        public Action OnAgain;
        /// <summary>QUIT / DONE.</summary>
        public Action OnQuit;
        /// <summary>Pause card: RESUME.</summary>
        public Action OnResume;
        /// <summary>The pips changed (Done); for a game that draws its own.</summary>
        public Action<int> OnDone;
        /// <summary>Sounds the run's moments make (sd_pip, sd_blitzNext, sd_blitzFail, sd_drain, sd_timeUp, sd_blitzWin,
        /// sd_revive), with when ("ms after").</summary>
        public Action<string> Sound = n => Snd.Play(n);
        /// <summary>The pip's rate for round i (Sort and Stack: 0.9 + i * 0.06; Squishdoku sets its own).</summary>
        public Func<int, double> PipRate = i => 0.9 + i * 0.06;

        Card _revive, _fail, _win, _pause;
        readonly List<Card> _cards = new List<Card>();
        public IEnumerable<Card> Cards() { _cards.RemoveAll(c => !c.Shown); return _cards; }
        public bool CardOpen { get { foreach (var c in _cards) if (c.Visible) return true; return false; } }

        public BlitzRun(float screenW, float screenH, string unit, Timings timings = null, int rounds = 10)
        {
            _w = screenW; _h = screenH; Unit = unit; Rounds = rounds; _tm = timings ?? new Timings();
            _tk = Ticker.Default;
        }

        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(fn, ms));
        public void ClearTimers() { foreach (var t in _timers) _tk.ClearTimeout(t); _timers.Clear(); }
        void SetDone(int d) { Done = d; OnDone?.Invoke(d); }

        void Open(ref Card slot, Card c) { slot?.Hide(); slot = c; _cards.Add(c); c.Show(); }
        void Close(ref Card slot) { slot?.Hide(); slot = null; }

        /// <summary>The round was cleared: its pip fills, then the next round or the win.</summary>
        public void Cleared()
        {
            int i = Idx;
            Later(_tm.PipMs, () => { SetDone(i + 1); Snd.Play("sd_pip", rate: PipRate(i)); });
            if (i < Rounds - 1)
            {
                Later(_tm.NextMs, () => { Sound?.Invoke("sd_blitzNext"); Idx = i + 1; OnNext?.Invoke(Idx); });
                return;
            }
            Later(_tm.WinMs, () =>
            {
                var res = OnWon?.Invoke() ?? new BlitzCards.WinResult();
                CardName = "win";
                Open(ref _win, BlitzCards.Win(_w, _h, res, Unit, Again, Quit, Rounds));
                Sound?.Invoke("sd_blitzWin");
                Snd.Win();
            });
        }

        /// <summary>A mistake (the game has stopped its clock): the revive, or the run's over.</summary>
        public void Mistake()
        {
            Later(_tm.MistakeMs, () =>
            {
                if (Revived) EndRun("mistake");
                else { CardName = "revive"; Open(ref _revive, BlitzCards.Revive(_w, _h, Idx + 1, Unit, AdReady(), AdsFree, Revive, () => EndRun("mistake"))); }
            });
        }

        /// <summary>The run's clock ran out.</summary>
        public void TimeUp() => EndRun("time");

        /// <summary>The run's over: the fail card, the pips drain.</summary>
        public void EndRun(string reason)
        {
            FailReason = reason;
            Close(ref _revive);
            CardName = "fail";
            Open(ref _fail, BlitzCards.Fail(_w, _h, reason, Idx + 1, Best(), Unit, Again, Quit));
            if (reason == "time") Sound?.Invoke("sd_timeUp");
            Snd.Wrong();
            Later(reason == "time" ? 900 : 0, () => Sound?.Invoke("sd_blitzFail"));
            Later(reason == "time" ? 1500 : 600, () => { Sound?.Invoke("sd_drain"); SetDone(0); });
            OnLost?.Invoke(reason, Idx + 1);
        }

        void Revive()
        {
            void Back()
            {
                Revived = true;
                CardName = null;
                Close(ref _revive);
                Sound?.Invoke("sd_revive");
                OnRevived?.Invoke();
            }
            if (AdsFree) Back(); else ShowAd(Back);
        }

        public void Pause()
        {
            if (Paused || CardName != null) return;
            Paused = true;
            Open(ref _pause, BlitzCards.Pause(_w, _h, Resume, Again, Quit));
        }

        void Resume() { Paused = false; Close(ref _pause); OnResume?.Invoke(); }

        /// <summary>A new run (GO AGAIN, START OVER, AGAIN).</summary>
        public void Again()
        {
            ClearTimers();
            Close(ref _revive); Close(ref _fail); Close(ref _win); Close(ref _pause);
            Paused = false;
            CardName = null;
            Revived = false;
            SetDone(0);
            Idx = 0;
            OnAgain?.Invoke();
        }

        void Quit() { ClearTimers(); OnQuit?.Invoke(); }

        /// <summary>Card taps: true when a card took it.</summary>
        public bool Down(float x, float y) { for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].Down(x, y)) return true; return false; }
        public bool Up(float x, float y) { for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].Up(x, y)) return true; return false; }

        /// <summary>Places the cards (call each frame after the Ticker's tick) and lists their layers, bottom first.</summary>
        public IEnumerable<CardLayer> Layers()
        {
            foreach (var c in Cards()) { c.Update(); foreach (var l in c.Layers()) yield return l; }
        }
    }
}
