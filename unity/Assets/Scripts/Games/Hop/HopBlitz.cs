// Squish Hop's BLITZ MODE as develop's src/hop/Game.js plays it with `blitz` (the same HopLevel, these are its Blitz
// branches; 2026-11-16, the user: "the same thing" as Squishdoku's): fresh small boards (Blitz.BlitzSpec, blitz.js) one
// after another in the Dance Room, each on its own short clock. No UNDO, RESTART or hints.
//   countdown  the run opens with 3, 2, 1, GO! (700 ms apart from 200, Ui/Blitz Countdown over the board): the first
//              board drops in on GO, its clock starts 760 ms after GO
//   intro      every later board drops in at once with BOARD n and its chips (its size, its clock); its clock starts
//              760 ms later
//   play       a hop that leaves no full clear (the solver checks after every hop), getting stuck, or the clock running
//              out stops the run (held): the hopper droops, looks about and sways sadly, the save card 1000 ms later (the clock: 900): SAVE IT once
//              with a rewarded ad (free with Remove Ads), SAVE FOR gems (each save twice the last, functions/squad.js
//              blitzSave), END RUN. Saved: the hops since the last spot a full clear was possible from are taken back
//              (stuck: at least one), the clock running on; after the clock, from where it stood with the board's clock
//              started again
//   won        the ★: the happy jumps (900 ms), CLEARED goes up 300 ms later, the next board at 1100
//   over       END RUN: GAME OVER, the boards cleared and what they paid (Blitz.AfterBlitz), confetti for a new best;
//              PLAY AGAIN (a new run, its own seed) / QUIT
//   The back button while playing pauses (the shared pause card: RESUME / QUIT). Leaving or starting over in the middle of
//   a run pays out what it cleared.
// The HUD in Blitz: "Blitz Mode", CLEARED n and BEST n (NEW BEST in gold once beaten) in the left column, the rule
// (1 MISTAKE = GAME OVER) and the board's clock (Hud.js TimerBar, 124 wide) on the brown glass in the right one. The
// cards are Squishdoku's (Overlays.js BlitzSaveCard / BlitzOverCard: Games/Squishdoku/SdBlitzCards). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Ui;
using SquishSquad.Ui.Blitz;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Hop
{
    public sealed partial class HopLevel
    {
        public const float BlitzRightW = 150;
        const double HURRY_MS = 5000;   // the last seconds of a board's clock tick
        const float BAR_W = 124;

        // ---- the host's (and the tests') ------------------------------------------------------------------------------
        /// <summary>Run `run`'s seed for its boards (Game.js: (Date.now() ^ Math.imul(run + 1, 2654435761)) | 0); tests hand
        /// in the app's.</summary>
        public Func<int, int> SeedOf = run => unchecked((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() ^ (run + 1) * (int)2654435761u);
        /// <summary>Whether the run's record and pay go into Profile (the app's `uid`).</summary>
        public bool Save = true;
        /// <summary>A rewarded ad, then `back` once it's earned (Ui/AdHook).</summary>
        public Action<Action> ShowAd = back => AdHook.Show(back);
        public bool IsBlitz => _blitz;
        /// <summary>Blitz: the card up ("save", "over") or null.</summary>
        public string BlitzCard => _blitzCard;
        public int Cleared => _cleared;
        public int Idx => _idx;
        public bool ClockRunning => _clk != null && _clk.Running;
        public double ClockLeft => _clk == null ? 0 : _clk.Limit - _clk.Elapsed;
        /// <summary>When the countdown's timers were set (tests line the app's up with it); -1 before.</summary>
        public double CountdownAt { get; private set; } = -1;
        public int GemSaves => _gemSaves;
        /// <summary>The hops made on this board (tests).</summary>
        public int MovesMade => G.Moves.Count;
        /// <summary>Where the hopper stands and the board's state (tests: a hop that leaves no full clear).</summary>
        public HopState State => G.St;
        public bool AdUsed => _adUsed;

        readonly bool _blitz;
        int _run, _idx, _seed, _cleared, _gemSaves, _interval = -1, _lastSecond = -1;
        bool _runStarted, _runEnded, _adUsed, _saving, _warn;
        string _blitzCard, _failReason = "mistake", _saveErr, _saveKey, _label = "";
        SdClock _clk;
        Countdown _countdown;
        BroadCard _saveCard, _overCard;
        readonly List<ICardView> _bcards = new List<ICardView>();
        HopLayer _glassL, _chipL, _barL, _barTextL;
        readonly Dictionary<CardLayer, (HopLayer layer, int version)> _cdLayers = new Dictionary<CardLayer, (HopLayer, int)>();
        KeyLoop _warnLoop;

        bool BoardHidden => _blitz && (_paused || (_countdown?.Value != null && _countdown.Value != "GO!"));

        void BlitzInit()
        {
            _clk = new SdClock(_tk);
            _countdown = new Countdown();
            _seed = SeedOf(_run);
        }

        // okAt[k] for the k-th hop (Game.js G.okAt[G.moves.length] = G.feasible)
        void SetOkAt(int k, bool ok)
        {
            while (G.OkAt.Count <= k) G.OkAt.Add(false);
            G.OkAt[k] = ok;
        }

        // ---- a new board (the go effect with `blitz`) ----------------------------------------------------------------------
        // no hops until the board's clock starts; the run's first board drops in on GO
        void BlitzGo()
        {
            _phase = "intro";
            _warn = false;
            _lastSecond = -1;
            _label = Squishdoku.Levels.Clock(_spec.Ms);
            _clk.Reset();
            StopInterval();
            void StartClock()
            {
                _runStarted = true;
                _phase = "play";
                _clk.Start(_spec.Ms);
                StartInterval();
                _hudKey = null;
            }
            if (!_runStarted)
            {
                CountdownAt = _tk.Now;
                var steps = new[] { "3", "2", "1", "GO!" };
                for (int i = 0; i < steps.Length; i++)
                {
                    var v = steps[i];
                    Later(200 + i * 700, () =>
                    {
                        _countdown.Set(v);
                        Snd.Play(v == "GO!" ? "sd_go" : "sd_count");
                        Snd.Tick();
                        if (v == "GO!") Enter();
                    });
                }
                Later(200 + 4 * 700, () => _countdown.Set(null));
                Later(200 + 3 * 700 + 760, StartClock);
            }
            else
            {
                Enter();
                Say($"BOARD {_spec.Lv}", chips: new[] { _spec.Size, "⏱ " + Squishdoku.Levels.Clock(_spec.Ms) }, hold: 700);
                Later(760, StartClock);
            }
        }

        // the board's clock (its last seconds tick; at 0, TIME'S UP)
        void StartInterval()
        {
            StopInterval();
            Action tick = null;
            tick = () =>
            {
                _interval = _tk.SetTimeout(tick, 150);
                if (_phase != "play" || _paused) return;
                double rest = _clk.Limit - _clk.Elapsed;
                _label = Squishdoku.Levels.Clock(rest);
                int sec = (int)Math.Ceiling(rest / 1000);
                if (rest <= HURRY_MS && rest > 0 && sec != _lastSecond)
                {
                    _lastSecond = sec;
                    Snd.Play("sd_tick", rate: sec <= 3 ? 1.3 : 1);
                    _warn = true;
                }
                if (rest <= 0) TimeUp();
            };
            _interval = _tk.SetTimeout(tick, 150);
        }
        void StopInterval() { if (_interval >= 0) _tk.ClearTimeout(_interval); _interval = -1; }

        // one more cleared; on to the next board (Game.js win with `blitz`)
        void BlitzCleared()
        {
            int i = _idx;
            _runCleared = i + 1;
            Later(300, () =>
            {
                _cleared = i + 1;
                Snd.Play("sd_pip", rate: 0.9 + Math.Min(12, i) * 0.05);
                _hudKey = null;
            });
            Later(1100, () =>
            {
                Snd.Play("sd_blitzNext");
                _idx = i + 1;
                NextBoard();
            });
        }
        int _runCleared;

        void NextBoard()
        {
            BuildLevel();
            NewGo();
        }

        // ---- a mistake or the clock, the save, GAME OVER -------------------------------------------------------------------

        void BlitzMistake(string why)
        {
            _clk.Pause();
            G.Over = true;
            G.Busy = false;
            _phase = "held";
            _warn = false;
            Snd.Play("sd_wrong");
            Snd.Wrong();
            Sadden();
            Later(1000, () => OfferSave(why));
        }

        // the board's clock ran out (not mid-hop: a hop under way still counts)
        void TimeUp()
        {
            if (G.Busy || G.Over || _phase != "play") return;
            _clk.Pause();
            G.Over = true;
            _phase = "held";
            _warn = false;
            Snd.Play("sd_timeUp");
            Snd.Wrong();
            Sadden();
            Later(900, () => OfferSave("time"));
        }

        int Gems() => (int)(Profile.TryGetValue("gems", out var g) && g is double d ? d : 0);

        SdBlitzCards.SaveState SaveState() => new SdBlitzCards.SaveState
        {
            Reason = _failReason, Unit = "board", Board = _idx + 1, Cleared = _cleared, AdUsed = _adUsed, AdReady = AdReady, AdsFree = AdsFree,
            Gems = Gems(), Price = Squishdoku.Levels.BlitzSaveGems(_gemSaves), Saving = _saving, Error = _saveErr,
            Why = _failReason == "mistake" ? $"That hop left {(_room.Dance ? "tile" : "cushion")}s you can't clear." : _failReason == "stuck" ? "Nowhere left to hop." : null,
        };

        void OfferSave(string reason)
        {
            _failReason = reason;
            _saveErr = null;
            _blitzCard = "save";
            var st = SaveState();
            _saveKey = $"{st.AdUsed}{st.AdReady}{st.Gems}{st.Price}{st.Saving}{st.Error}";
            _saveCard = SdBlitzCards.Save(W, H, st, SaveByAd, SaveByGems, EndRun);
            OpenB(_saveCard);
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
        static void CloseB(ref BroadCard c) { c?.Hide(); c = null; }

        // The run goes on from the same board: after a mistake, back to the last spot a full clear was still possible
        // from, with the clock running on; after the clock ran out, from where it stood, with the board's clock started again.
        void GoOn()
        {
            _saving = false;
            _blitzCard = null;
            CloseB(ref _saveCard);
            Snd.Play("sd_revive");
            _lastSecond = -1;
            _warn = false;
            CheerUp();
            G.Over = false;
            G.Queue = new List<Action>();
            if (_failReason != "time")
            {
                // (stuck: at least one hop back, even if the solver had given up on the spot it stopped at)
                int k = Math.Min(G.OkAt.Count - 1, _failReason == "stuck" ? G.Moves.Count - 1 : G.Moves.Count);
                while (k > 0 && !G.OkAt[k]) k--;
                k = Math.Max(0, k);
                if (k < G.Moves.Count)
                {
                    var target = G.Hist[k];
                    G.Hist.RemoveRange(k, G.Hist.Count - k);
                    G.Moves.RemoveRange(k, G.Moves.Count - k);
                    G.Busy = true;
                    RestoreTo(target, 280, () => { G.Busy = false; Drain(); });
                }
                if (G.OkAt.Count > k + 1) G.OkAt.RemoveRange(k + 1, G.OkAt.Count - k - 1);
                G.Feasible = true;
                Sync();
            }
            _phase = "play";
            if (_failReason == "time") _clk.Start(_spec.Ms);
            else _clk.Resume();
            _hudKey = null;
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
        // as Squishdoku's); then on from the same board, or the card's error
        async void SaveByGemsOnServer()
        {
            _saving = true;
            RefreshSave();
            int price = Squishdoku.Levels.BlitzSaveGems(_gemSaves);
            string err;
            try { err = await SdSave.BlitzSave(_gemSaves); }
            catch (Exception e) { err = e.Message ?? "error"; }
            if (!_alive) return;
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

        // Pays the run out once (the boards it cleared) and saves the record. Also when the player quits or starts over in
        // the middle of a run, so cleared boards always count.
        AfterBlitzResult PayOut()
        {
            if (!_blitz || !_runStarted || _runEnded) return null;
            _runEnded = true;
            var outc = Blitz.AfterBlitz(Profile, _runCleared);
            if (Save) { HopSave.Paid(outc, Profile); Apply(outc.Update); }
            return outc;
        }

        // GAME OVER: the boards cleared, the best, and what they paid
        void EndRun()
        {
            _clk.Pause();
            G.Over = true;
            _phase = "held";
            int top = (int)Js.ToNumber(Levels.Record(Profile).BlitzTop);
            int n = _runCleared;
            var outc = PayOut();
            var res = new SdBlitzCards.OverResult
            {
                Cleared = n, Best = Math.Max(top, n), NewTop = outc?.NewTop ?? false,
                Coins = outc?.Coins ?? 0, Xp = outc?.Xp ?? 0, LevelUps = outc?.LevelUps?.Count ?? 0,
                Before = outc?.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc?.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
            };
            _blitzCard = "over";
            CloseB(ref _saveCard);
            _overCard = SdBlitzCards.Over(W, H, res, Again, Leave, "board");
            OpenB(_overCard);
            if (res.NewTop)
            {
                Snd.Play("sd_blitzWin");
                Snd.Win();
                // (over the cards: the screen's quarters, 30 % down)
                for (int i = 0; i < 3; i++) { int k = i; Later(k * 300, () => Spray("confetti", W * (0.25 + 0.25 * k) - LeftW, H * 0.3, 1)); }
            }
            else
            {
                Snd.Play("sd_blitzFail");
                Later(600, () => Snd.Play("sd_drain"));
            }
            _hudKey = null;
        }

        // PLAY AGAIN: a fresh run from board 1 (the one before is paid out first), with its own seed
        void Again()
        {
            PayOut();
            ClearTimers();
            StopInterval();
            _clk.Reset();
            _runStarted = false; _runEnded = false; _runCleared = 0;
            _blitzCard = null;
            CloseB(ref _saveCard); CloseB(ref _overCard);
            _adUsed = false; _gemSaves = 0; _saving = false; _saveErr = null;
            _cleared = 0; _idx = 0;
            _countdown.Set(null);
            SetPaused(false);
            _warn = false;
            _run++;
            _seed = SeedOf(_run);
            NextBoard();
        }

        // ---- the cards over the game: the level's (the pause card in Blitz too), then the run's -----------------------------
        /// <summary>Every card on screen, bottom first (the level's, then the run's save and GAME OVER cards).</summary>
        public IEnumerable<ICardView> AllCards
        {
            get
            {
                foreach (var c in _cards) yield return new CardView(c.card);
                _bcards.RemoveAll(c => !c.Shown);
                foreach (var c in _bcards) yield return c;
            }
        }

        bool BlitzCardOpen { get { foreach (var c in _bcards) if (c.Visible) return true; return false; } }

        void BlitzCardsDown(float x, float y) { for (int i = _bcards.Count - 1; i >= 0; i--) if (_bcards[i].Visible && _bcards[i].Down(x, y)) return; }
        bool BlitzCardsUp(float x, float y)
        {
            for (int i = _bcards.Count - 1; i >= 0; i--) if (_bcards[i].Visible && _bcards[i].Up(x, y)) return true;
            return BlitzCardOpen;
        }

        /// <summary>Taps the open card's button whose label starts with `label` (tests). False when there's none.</summary>
        public bool PressCard(string label)
        {
            var list = new List<ICardView>(AllCards);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var c = list[i];
                if (!c.Visible) continue;
                c.Update();
                foreach (var b in c.Buttons)
                {
                    if (!b.Look.Label.StartsWith(label, StringComparison.Ordinal)) continue;
                    var p = b.Face.Transform.Apply(new Vec2(b.W / 2, b.H / 2));
                    Down((float)p.X, (float)p.Y);
                    Up((float)p.X, (float)p.Y);
                    return true;
                }
            }
            return false;
        }

        /// <summary>A hop that way as the arrow keys or a swipe would (tests: 0 up, 1 right, 2 down, 3 left).</summary>
        public void HopDir(int d) => Input(() => TryDir(d));

        // ---- every frame: the right column's glass (the rule, the board's clock), the countdown, the save card's row ---------
        static readonly double[] TRI = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        void BlitzDraw()
        {
            RefreshSave();
            if (_warn && _warnLoop == null) { _warnLoop = new KeyLoop(500, KeyLoop.PHASE, TRI); _warnLoop.Mount(); }
            else if (!_warn && _warnLoop != null) { _warnLoop.Unmount(); _warnLoop = null; }
            // the glass: 10 in from the column's sides, padding 12 x 8, gap 8, marginTop 6, centred down the column; the chip (ui.js Chip,
            // wrapping inside the glass) over the TimerBar (124 wide: wider than the glass's inside, so it hangs out evenly)
            if (_glassL == null)
            {
                const string rule = "1 MISTAKE = GAME OVER";
                float gx = W - BlitzRightW + 10, gw = BlitzRightW - 20, inner = gw - 4 - 24;
                var ct = SdArt.ChipText;
                var lines = CardArt.Wrap(rule, ct, inner - 22);
                float lh = UiSvg.LineBox(ct), tw = 0;
                foreach (var l in lines) tw = Math.Max(tw, UiSvg.BoxWidth(l, ct));
                // (a chip whose text wraps takes the glass's whole inside, as Chrome sizes a wrapping box)
                float cw = lines.Count > 1 ? inner : Math.Min(inner, tw + 22), ch = lines.Count * lh + 6 + 4;
                // centred down the column under its marginTop 6
                float gh = 2 + 8 + ch + 8 + SdArt.BarH + 8 + 2, gy = (H - gh - 6) / 2 + 6;
                var g = new UiSvg(gw, gh);
                g.Box(0, 0, gw, gh, new BoxStyle { Background = "rgba(91,58,41,0.75)", Radius = 20, BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
                float cx = (gw - cw) / 2, cy = 2 + 8;
                g.Box(cx, cy, cw, ch, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                for (int i = 0; i < lines.Count; i++) g.Text(lines[i], cx + 2 + 9, cy + 2 + 3 + i * lh, ct);
                _glassL = Add("blitz glass", O_HUD + 2).Svg(g.Markup, gw, gh, 4);
                _glassL.Transform = Affine.Translate(gx, gy);
                _barX = gx + gw / 2 - BAR_W / 2;
                _barY = gy + 2 + 8 + ch + 8;
                _barL = Add("blitz bar", O_HUD + 3);
                _barTextL = Add("blitz bar label", O_HUD + 4);
            }
            double warn = _warnLoop?.Value ?? 0, frac = _clk.Frac.GetValue();
            string bk = $"{Math.Round(frac * 1900)}|{Math.Round(warn * 50)}";
            if (bk != _barKey) { _barKey = bk; _barL.Svg(SdArt.Bar(Math.Round(frac * 1900) / 1900, Math.Round(warn * 50) / 50, BAR_W), BAR_W, SdArt.BarH, 2); }
            string tk = _label + _warn;
            if (tk != _barTextKey) { _barTextKey = tk; _barTextL.Svg(SdArt.BarText(_label, _warn, BAR_W), BAR_W, SdArt.BarH, 2); }
            var bar = Affine.Translate(_barX, _barY) * About(BAR_W, SdArt.BarH, Affine.ScaleBy(1 + 0.04 * warn, 1 + 0.04 * warn));
            _barL.Transform = _barTextL.Transform = bar;
            // the countdown, over the board's area
            _countdown.Place(LeftW, 0, AreaW, H);
            var seen = new HashSet<CardLayer>();
            int order = O_CHIPS + 60;
            foreach (var l in _countdown.Layers)
            {
                seen.Add(l);
                if (!_cdLayers.TryGetValue(l, out var e)) e = (Add("countdown", order), -1);
                if (e.version != l.Version) { e.layer.Svg(l.Markup, l.W, l.H, l.Margin); e.version = l.Version; }
                _cdLayers[l] = e;
                var h = e.layer;
                h.Transform = l.Transform; h.Opacity = l.Opacity; h.Visible = l.Visible; h.Order = order++;
            }
            foreach (var l in new List<CardLayer>(_cdLayers.Keys)) if (!seen.Contains(l)) { Remove(_cdLayers[l].layer); _cdLayers.Remove(l); }
        }
        float _barX, _barY;
        string _barKey, _barTextKey;
    }
}
