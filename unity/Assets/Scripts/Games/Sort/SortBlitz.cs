// Squish Sort's BLITZ MODE (src/sort/Game.js's `blitz` branches, SortBlitz; develop, 2026-11-17, the user: "its
// unlimited and it should behave like the others, 1 fail means you failed it all"): round after round with no end
// (Levels.BlitzSpec: Regular levels from further up the map at the Blitz skill, then the very very large fridge's
// eight-shelf levels for good), each round on its own clock (BlitzSpec's LimitMs: a third more than its 3-star time,
// 3 % shorter a round past the climb, down to three quarters), running only while sorting.
//   a round sorted   the bounce wave inside as the doors swing shut over it; CLEARED goes up 300 ms later; the next
//                    round 1700 ms after
//   a mistake / the clock out   the run stops ("held"); 800 ms later (the clock: 900) the save card: SAVE IT (a rewarded
//                    ad, once a run; free with Remove Ads), SAVE FOR <gem> n (squad.blitzSave, twice the last), END RUN.
//                    Saved after a mistake the round's clock runs on; after the clock ran out it starts again
//   END RUN          GAME OVER 1100 ms later: the rounds cleared, the best, what they paid (Levels.AfterBlitz: coins for
//                    each round, a tenth of xp.blitz.sort each); PLAY AGAIN / QUIT. Leaving or starting over pays out.
//   pause            the back orb (or Android's back) while sorting: the shared pause card (RESUME / QUIT)
// The cards are Squishdoku's (Overlays.js BlitzSaveCard / BlitzOverCard, unit "round": Games/Squishdoku/SdBlitzCards).
// The HUD is SortLevel's (develop's: "Blitz Mode", CLEARED / BEST and the rule on the glass, the pause icon while
// sorting). At GAME OVER everyone droops (SortLevel.Droop). This file is SortLevel's Blitz half. Open it with SortLevel.Blitz(...)
// (SortGame.CreateBlitz in Unity). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Sort
{
    public sealed partial class SortLevel
    {
        bool _blitz;
        bool _runStarted, _ended, _adUsed, _saving;   // Game.js runStarted: a round of this run has been sorted in
        int _idx, _cleared, _gemSaves;
        string _blitzCard, _failReason = "mistake", _saveErr, _saveKey;
        BroadCard _saveCard, _overCard;
        readonly List<ICardView> _bcards = new List<ICardView>();

        public bool IsBlitz => _blitz;
        /// <summary>Blitz: whether the run's record and pay go into Profile (the app's `uid`; off as its preview player).</summary>
        public bool Save = true;
        /// <summary>Blitz: a rewarded ad, then `back` once it's earned (Ui/AdHook).</summary>
        public Action<Action> ShowAd = back => AdHook.Show(back);
        public bool AdsFree;
        /// <summary>Blitz: the card up ("save", "over") or null; the rounds cleared; the round being played (0 = the first).</summary>
        public string BlitzCard => _blitzCard;
        public int Cleared => _cleared;
        public int RoundIdx => _idx;

        /// <summary>A Blitz run from round 1 on a `screenW` x `screenH` dp screen; then Start() as a level.</summary>
        public static SortLevel Blitz(float screenW, float screenH, SortData data, IDictionary<string, object> profile) =>
            new SortLevel("fridge", 1, screenW, screenH, data, profile) { _blitz = true, AdsFree = AdHook.AdsFree(profile) };

        // Game.js blitzStop: a mistake ('mistake') or the round's clock running out ('time') stops the run, and the save
        // card comes up
        void BlitzStop(string reason)
        {
            _clk.Pause();
            StopInterval();
            Phase = "held";
            SetSelected(null);
            _hoverO.SetValue(0);
            _failReason = reason;
            _saveErr = null;
            if (reason == "time") Snd.Play("sd_timeUp");
            Snd.Wrong();
            Later(reason == "time" ? 900 : 800, () =>
            {
                _blitzCard = "save";
                var st = SaveState();
                _saveKey = Key(st);
                _saveCard = SdBlitzCards.Save(_sw, _sh, st, SaveByAd, SaveByGems, EndRun);
                OpenB(_saveCard);
            });
        }

        // Game.js win(), blitz: one more cleared; on to the next round
        void BlitzCleared()
        {
            int i = _idx;
            Later(300, () => { _cleared = i + 1; Snd.Play("sd_pip", rate: 0.9 + Math.Min(12, i) * 0.05); });
            Later(1700, () => { Snd.Play("sd_blitzNext"); _idx = i + 1; NewRound(); });
        }

        int Gems() => (int)(Profile.TryGetValue("gems", out var g) && g is double d ? d : 0);

        SdBlitzCards.SaveState SaveState() => new SdBlitzCards.SaveState
        {
            Reason = _failReason, Unit = "round", Board = _idx + 1, Cleared = _cleared, AdUsed = _adUsed, AdReady = AdHook.Ready(), AdsFree = AdsFree,
            Gems = Gems(), Price = Squishdoku.Levels.BlitzSaveGems(_gemSaves), Saving = _saving, Error = _saveErr,
        };
        static string Key(SdBlitzCards.SaveState st) => $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";

        // the save card's row again when what it shows changed (the ad loading, SAVING…, an error)
        void RefreshSave()
        {
            if (_saveCard == null || !_saveCard.Shown || _blitzCard != "save") return;
            var st = SaveState();
            var key = Key(st);
            if (key == _saveKey) return;
            _saveKey = key;
            ((ButtonRowItem)_saveCard.Items[_saveCard.Items.Count - 1]).SetRow(SdBlitzCards.SaveRow(st, SaveByAd, SaveByGems, EndRun));
        }

        void OpenB(ICardView c) { _bcards.Remove(c); _bcards.Add(c); Effect(c.Show); }
        static void CloseB(ref BroadCard c) { c?.Hide(); c = null; }

        // Game.js goOn: the run goes on from the same round: after a mistake its clock runs on, after the clock ran out
        // it starts again
        void GoOn()
        {
            _saving = false;
            _blitzCard = null;
            CloseB(ref _saveCard);
            Snd.Play("sd_revive");
            Phase = "place";
            if (_failReason == "time") { _left = (int)Math.Ceiling(Spec.LimitMs / 1000.0); _clk.Start(Spec.LimitMs); }
            else _clk.Resume();
            Effect(() => { if (Phase == "place" && !_paused) StartInterval(); });
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
            // offline: the gems come off the game's copy of the profile
            int price = Squishdoku.Levels.BlitzSaveGems(_gemSaves), have = Gems();
            if (have < price) { _saveErr = "Not enough gems"; RefreshSave(); return; }
            Profile["gems"] = (double)(have - price);
            _gemSaves++;
            GoOn();
        }

        // signed in: SAVING… while the `squad` callable takes the gems (squad.blitzSave, Squishdoku's move); then on, or
        // the card's error
        async void SaveByGemsOnServer()
        {
            _saving = true;
            RefreshSave();
            int price = Squishdoku.Levels.BlitzSaveGems(_gemSaves);
            string err;
            try { err = await SdSave.BlitzSave(_gemSaves); }
            catch (Exception e) { err = e.Message ?? "error"; }
            if (_exited) return;
            if (err == null)
            {
                Profile["gems"] = (double)Math.Max(0, Gems() - price);
                _gemSaves++;
                if (_blitzCard == "save") GoOn(); else _saving = false;
                return;
            }
            _saving = false;
            _saveErr = err == "not_enough_gems" ? "Not enough gems" : "Couldn't reach the server. Try again?";
            RefreshSave();
        }

        // Game.js payOut: the run's rounds pay once (also when the player quits or starts over in the middle of a run)
        SortOutcome PayOut()
        {
            if (!_blitz || !_runStarted || _ended) return null;
            _ended = true;
            var outc = Levels.AfterBlitz(Profile, _cleared);
            if (Save) { SortSave.Paid(outc, Profile); Apply(outc.Update); }
            return outc;
        }

        // Game.js endRun: GAME OVER, 1100 ms later the card with the rounds cleared, the best and what they paid
        void EndRun()
        {
            Phase = "lost";
            _clk.Pause();
            StopInterval();
            SetSelected(null);
            _hoverO.SetValue(0);
            _blitzCard = null;
            CloseB(ref _saveCard);
            // everyone droops where they are
            var sadList = new List<(int k, double delay)>();
            for (int k = 0; k < Board.Pieces.Count; k++) if (!_play.Gone.Contains(k)) sadList.Add((k, 150 + sadList.Count * 60));
            Droop(sadList);
            int top = (int)(Levels.Record(Profile).Blitz.Top ?? 0);
            var outc = PayOut();
            var res = new SdBlitzCards.OverResult
            {
                Cleared = _cleared, Best = Math.Max(top, _cleared), NewTop = outc?.NewTop ?? false,
                Coins = outc?.Coins ?? 0, Xp = outc?.Xp ?? 0, LevelUps = outc?.LevelUps?.Count ?? 0,
                Before = outc?.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc?.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            Later(1100, () =>
            {
                _blitzCard = "over";
                _overCard = SdBlitzCards.Over(_sw, _sh, res, Again, Leave, "round");
                OpenB(_overCard);
                if (res.NewTop)
                {
                    Snd.Play("sd_blitzWin");
                    Snd.Win();
                    for (int i = 0; i < 3; i++) { int k = i; Later(k * 300, () => Spray("confetti", _sw * (0.25 + 0.25 * k) - AreaX, _sh * 0.3, 1)); }
                }
                else
                {
                    Snd.Play("sd_blitzFail");
                    Snd.Wrong();
                    Later(600, () => Snd.Play("sd_drain"));
                }
            });
        }

        // Game.js again(): a fresh run from round 1 (the one before is paid out first)
        void Again()
        {
            PayOut();
            ClearTimers();
            StopInterval();
            _clk.Reset();
            _runStarted = false; _ended = false;
            _blitzCard = null;
            CloseB(ref _saveCard); CloseB(ref _overCard);
            _adUsed = false; _gemSaves = 0; _saving = false; _saveErr = null;
            _cleared = 0; _idx = 0;
            _left = 0;
            _paused = false;
            _countdown.Set(null);
            NewRound();
        }

        // ---- the countdown (Ui/Blitz Countdown over the play area) -----------------------------------------------------------
        readonly Countdown _countdown = new Countdown();
        /// <summary>When the countdown's timers were set (tests line the app's up with it); -1 before.</summary>
        public double CountdownAt { get; private set; } = -1;

        void DrawCountdown()
        {
            _countdown.Place(AreaX, 0, AreaW, _sh);
            int i = 0;
            foreach (var c in _countdown.Layers)
            {
                var l = L("countdown " + i++);
                l.Set(c.Markup, c.W, c.H, c.Margin);
                l.Transform = c.Transform; l.Opacity = c.Opacity; l.Visible = c.Visible;
            }
        }

        // the level's cards (the pause card in Blitz too), then the run's
        IEnumerable<ICardView> AllCards()
        {
            foreach (var c in _cards) yield return new CardView(c);
            foreach (var c in _bcards) yield return c;
        }

        bool BCardOpen { get { foreach (var c in _bcards) if (c.Visible) return true; return false; } }
    }
}
