// Squish Stack's BLITZ MODE as develop's src/stack/Game.js plays it with `blitz` (the same StackGame, these are its Blitz
// branches; 2026-11-16, the user: "the same thing" as Squishdoku's): puzzle after puzzle (Levels.BlitzSpec at the
// player's Blitz skill: a ten-puzzle climb, then 7-on-4 for five, then 8-on-4 for good), with no end and no clock, no HINT.
//   countdown  the run opens with 3, 2, 1, GO! (700 ms apart from 200, Ui/Blitz Countdown over the cushions): the first
//              puzzle drops in on GO
//   intro      every later puzzle: PUZZLE n and its chips, dealt 1250 ms later
//   play       as a level; cleared: everyone hops, CLEARED goes up 300 ms later, the next puzzle at 1300
//   held       a big one dropped on a smaller one is the mistake that stops the run: everyone droops and sways sadly
//              (280 ms), the save card at 1500 (SAVE IT: once with a rewarded ad, free with Remove Ads; SAVE FOR <gem>
//              n: gems, each save twice the last, functions/squad.js blitzSave; END RUN); saved, the run goes on from
//              the same puzzle
//   lost       END RUN: GAME OVER, the puzzles cleared and what they paid (Levels.AfterBlitz: coins for each one, a tenth
//              of xp.blitz.stack each), confetti and NEW BEST! for a new best; PLAY AGAIN / QUIT
//   The back orb (Escape, Android's back) while playing pauses (the shared pause card: RESUME / QUIT). Leaving or
//   starting over in the middle of a run pays out what it cleared.
// The counter in Blitz: CLEARED n, BEST n (NEW BEST in gold once beaten), the tier, 1 MISTAKE = GAME OVER. The cards are
// Squishdoku's (Overlays.js BlitzSaveCard / BlitzOverCard with unit "puzzle": Games/Squishdoku/SdBlitzCards). What happens
// on the app's next render (a state change's effects) runs on the next frame here (Effect).
//   var g = StackGame.CreateBlitz(parent);  g.OnExit = ...;
using System;
using System.Collections.Generic;
using SquishSquad.Audio;
using SquishSquad.Anim;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Stack
{
    public sealed partial class StackGame
    {
        /// <summary>Squish Stack's Blitz run (the hub's BLITZ MODE): call Init (or let Unity's Start) as for a level.</summary>
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
        /// <summary>Whether the run's record and pay go into Profile (the app's `uid`; off as the app's preview player).</summary>
        public bool Save = true;
        /// <summary>A rewarded ad, then `back` once it's earned (Ui/AdHook).</summary>
        public Action<Action> ShowAd = back => AdHook.Show(back);
        /// <summary>When the countdown's timers were set (tests line the app's up with it); -1 before.</summary>
        public double CountdownAt { get; private set; } = -1;
        public bool IsBlitz => _blitz;
        public string Phase => _phase;
        /// <summary>Blitz: the card up ("save", "over") or null.</summary>
        public string BlitzCard => _blitzCard;
        public int Cleared => _cleared;

        bool _blitz;
        Countdown _countdown;
        bool _runStarted, _ended, _adUsed, _saving;
        int _idx, _cleared, _gemSaves;
        string _blitzCard, _failReason = "mistake", _saveErr, _saveKey;
        BroadCard _saveCard, _overCard;
        readonly List<ICardView> _bcards = new List<ICardView>();
        readonly Dictionary<CardLayer, (UiPiece piece, int version)> _layerPieces = new Dictionary<CardLayer, (UiPiece, int)>();
        readonly HashSet<CardLayer> _layersSeen = new HashSet<CardLayer>();

        // A state change's effects: React runs them once it has rendered. Set off by a timer, that's the end of the frame (the
        // Ticker's frame callbacks); by a tap (between frames), now.
        bool _inTick;
        void Effect(Action a) { if (_inTick) _anim.RequestAnimationFrame(() => { if (this != null) a(); }); else a(); }

        void TickAll(double now)
        {
            _inTick = true;
            try { _anim.Tick(now); } finally { _inTick = false; }
        }

        void BlitzInit() => _countdown = new Countdown();

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
                    Snd.Play(v == "GO!" ? "sd_go" : "sd_count");
                    Snd.Tick();
                    if (v == "GO!") Deal();
                });
            }
            Later(200 + 4 * 700, () => Effect(() => _countdown.Set(null)));
            return true;
        }

        // one more cleared; on to the next puzzle (Game.js win with `blitz`)
        void BlitzCleared()
        {
            int i = _idx;
            Later(300, () =>
            {
                _cleared = i + 1;
                Snd.Play("sd_pip", rate: 0.9 + Math.Min(12, i) * 0.05);
                Hud();
            });
            Later(1300, () =>
            {
                Snd.Play("sd_blitzNext");
                _idx = i + 1;
                Effect(NewPuzzle);
            });
        }

        // everyone droops and sways sadly (until the run's saved, or a new one); `now`: at once (a new puzzle)
        void Sad(bool on, bool now = false)
        {
            if (_anims == null) return;
            for (int r = 0; r < _anims.Length; r++)
            {
                var A = _anims[r];
                A.Droop.StopAnimation();
                if (now) A.Droop.SetValue(on ? 1 : 0);
                else Animated.Timing(A.Droop, Timing(on ? 1 : 0, on ? 520 : 200, Easing.Out(Easing.Quad))).Start();
                if (on) { int rr = r; Later(r * 120, () => { var B = _anims[rr]; if (!B.Swaying) { B.Swaying = true; B.Sway.Mount(); } }); }
                else if (A.Swaying) { A.Swaying = false; A.Sway.Unmount(); }
            }
        }

        // a mistake stops the run; then the save card
        void BlitzMistake()
        {
            _phase = "held";
            _glow = null;
            if (_held.HasValue) Drop(_held.Value.from);
            // everyone droops and sways sadly, and the save card comes once that's shown (1.5 s: it covers the cushions)
            Later(280, () => Sad(true));
            Later(1500, () => OfferSave("mistake"));
            Hud();
        }

        int Gems() => (int)(Profile.TryGetValue("gems", out var g) && g is double d ? d : 0);

        SdBlitzCards.SaveState SaveState() => new SdBlitzCards.SaveState
        {
            Reason = _failReason, Unit = "puzzle", Board = _idx + 1, Cleared = _cleared, AdUsed = _adUsed, AdReady = AdReady, AdsFree = AdsFree,
            Gems = Gems(), Price = Squishdoku.Levels.BlitzSaveGems(_gemSaves), Saving = _saving, Error = _saveErr,
        };

        void OfferSave(string reason)
        {
            _failReason = reason;
            _saveErr = null;
            _blitzCard = "save";
            var st = SaveState();
            _saveKey = $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";
            Effect(() => { _saveCard = SdBlitzCards.Save(W, H, st, SaveByAd, SaveByGems, EndRun); OpenB(_saveCard); });
        }

        // the save card's row again when what it shows changed (the ad loading, SAVING…, an error)
        void RefreshSave()
        {
            if (_saveCard == null || !_saveCard.Shown || _blitzCard != "save") return;
            var st = SaveState();
            var key = $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";
            if (key == _saveKey) return;
            _saveKey = key;
            ((ButtonRowItem)_saveCard.Items[_saveCard.Items.Count - 1]).SetRow(SdBlitzCards.SaveRow(st, SaveByAd, SaveByGems, EndRun));
        }

        void OpenB(ICardView c) { _bcards.Remove(c); _bcards.Add(c); c.Show(); }
        void CloseB(ref BroadCard c) { c?.Hide(); c = null; }

        // the run goes on from the same puzzle
        void GoOn()
        {
            _saving = false;
            _blitzCard = null;
            CloseB(ref _saveCard);
            Snd.Play("sd_revive");
            Sad(false);
            _phase = "play";
            Hud();
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

        // signed in, Game.js saveByGems: SAVING… while the `squad` callable takes the gems (squad.blitzSave, the same move
        // as Squishdoku's); then on from the same puzzle, or the card's error
        async void SaveByGemsOnServer()
        {
            _saving = true;
            RefreshSave();
            int price = Squishdoku.Levels.BlitzSaveGems(_gemSaves);
            string err;
            try { err = await SdSave.BlitzSave(_gemSaves); }
            catch (Exception e) { err = e.Message ?? "error"; }
            if (this == null) return;
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

        // Pays the run out once (the puzzles it cleared) and saves the record. Also when the player quits or starts over in
        // the middle of a run, so cleared puzzles always count.
        StackOutcome PayOut()
        {
            if (!_blitz || !_runStarted || _ended) return null;
            _ended = true;
            var outc = Levels.AfterBlitz(Profile, _cleared);
            if (Save) { StackSave.Paid(outc, Profile); Apply(outc.Update); }
            return outc;
        }

        // GAME OVER: the puzzles cleared, the best, and what they paid
        void EndRun()
        {
            _phase = "lost";
            _glow = null;
            if (_held.HasValue) Drop(_held.Value.from);
            int top = (int)Levels.Record(Profile).Blitz.Top;
            var outc = PayOut();
            var res = new SdBlitzCards.OverResult
            {
                Cleared = _cleared, Best = Math.Max(top, _cleared), NewTop = outc?.NewTop ?? false,
                Coins = outc?.Coins ?? 0, Xp = outc?.Xp ?? 0, LevelUps = outc?.LevelUps?.Count ?? 0,
                Before = outc?.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc?.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            _blitzCard = "over";
            CloseB(ref _saveCard);
            Effect(() => { _overCard = SdBlitzCards.Over(W, H, res, Again, Leave, "puzzle"); OpenB(_overCard); });
            if (res.NewTop)
            {
                Snd.Play("sd_blitzWin");
                Snd.Win();
                // (over the cards: the screen's quarters, 30 % down)
                for (int i = 0; i < 3; i++) { int k = i; Later(k * 300, () => Spray("confetti", W * (0.25 + 0.25 * k) - AreaX, H * 0.3 - _areaY, 1)); }
            }
            else
            {
                Snd.Play("sd_blitzFail");
                Snd.Wrong();
                Later(600, () => Snd.Play("sd_drain"));
            }
            Hud();
        }

        // PLAY AGAIN: a fresh run from puzzle 1 (the one before is paid out first)
        void Again()
        {
            PayOut();
            ClearTimers();
            _runStarted = false; _ended = false;
            _blitzCard = null;
            CloseB(ref _saveCard); CloseB(ref _overCard);
            _adUsed = false; _gemSaves = 0; _saving = false; _saveErr = null;
            _cleared = 0; _idx = 0;
            _paused = false;
            Effect(() => _countdown.Set(null));
            Effect(NewPuzzle);
            Hud();
        }

        StackArt.Counter BlitzCounter()
        {
            int best = (int)Levels.Record(Profile).Blitz.Top;
            return new StackArt.Counter { Blitz = true, Tier = _spec.Tier, Cleared = _cleared, Best = Math.Max(best, _cleared), Beat = _cleared > best && best > 0 };
        }

        // every frame: the countdown over the cushions, the save card's row
        void BlitzDraw()
        {
            RefreshSave();
            _countdown.Place(AreaX, _areaY, W - 2 * SideW, H - _areaY);
            _layersSeen.Clear();
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

        // ---- the cards over the game: the level's (the pause card in Blitz too), then the run's -----------------------------
        IEnumerable<ICardView> AllCards()
        {
            foreach (var c in _cards) yield return new CardView(c.card);
            _bcards.RemoveAll(c => !c.Shown);
            foreach (var c in _bcards) yield return c;
        }

        bool AnyCardOpen { get { if (CardOpen) return true; foreach (var c in _bcards) if (c.Visible) return true; return false; } }

        void CardsDown(float x, float y)
        {
            for (int i = _bcards.Count - 1; i >= 0; i--) if (_bcards[i].Visible && _bcards[i].Down(x, y)) return;
            for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Down(x, y)) break;
        }

        void CardsUp(float x, float y)
        {
            for (int i = _bcards.Count - 1; i >= 0; i--) if (_bcards[i].Visible && _bcards[i].Up(x, y)) return;
            for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Up(x, y)) break;
        }

        /// <summary>Taps the open card's button whose label starts with `label` (tests press the cards' buttons with it).
        /// False when there's none.</summary>
        public bool PressCard(string label)
        {
            var list = new List<ICardView>(AllCards());
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
}
