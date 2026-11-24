// A chest being opened over a screen (ShopScreen.js / LevelRoadScreen.js `smash` + VaultLoader): the smash comes up at
// once on the chest that was tapped (its server answer on its way), "To the treasure vault" over it until the smash has
// painted and at least 1.6 s have gone by; the answer fills it in when it lands (no answer: an error, the opening ends);
// COLLECT opens the next chest of a bundle or a claim (Rolled) on the same page, or ends it (OnDone, with each result
// collected: the host's toast).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui.Screens;

namespace SquishSquad.Screens
{
    public sealed class ChestOpening : IScreenView
    {
        readonly Ticker _t;
        public readonly ChestSmashView Smash;
        VaultView _vault;
        readonly Queue<IDictionary<string, object>> _queue = new Queue<IDictionary<string, object>>();
        IDictionary<string, object> _current;
        bool _shown;
        public Action<IDictionary<string, object>> OnCollected;
        public Action OnDone;
        public bool Finished { get; private set; }

        /// <summary>`buddyKey`: the player's squishy's picture in the vault's coin (null: a paw). `random`: the engine's
        /// generator (default: seeded from the clock).</summary>
        public ChestOpening(ChestRequest req, float w, float h, Ticker ticker, string buddyKey, Func<double> random = null)
        {
            _t = ticker;
            Smash = new ChestSmashView(w, h, ticker, random ?? new XorShift((uint)(Environment.TickCount | 1)).Next);
            _vault = new VaultView(w, h, ticker, buddyKey, (int)(DateTime.Now.Ticks % VaultView.TIPS.Length));
            _vault.OnDone = () => _vault = null;
            Smash.OnShown = () => { _shown = true; _vault?.Ready(); };
            Smash.OnCollect = Collect;
            if (req.Rolled != null && req.Rolled.Count > 0)
            {
                foreach (var r in req.Rolled) _queue.Enqueue(r);
                Next();
            }
            else
            {
                Smash.Start(req.Group, req.Size, null);
                Await(req);
            }
        }

        async void Await(ChestRequest req)
        {
            IDictionary<string, object> r = null;
            try { r = req.Result != null ? await req.Result : null; } catch (Exception) { }
            if (r == null) { Finish(); return; }
            _current = r;
            // the answer for the chest up, or a chest of its own (another group or size)
            if (Prof.Str(Prof.Get(r, "group")) == req.Group && Prof.Str(Prof.Get(r, "size")) == req.Size) Smash.Fill(r);
            else Smash.Start(Prof.Str(r["group"]), Prof.Str(r["size"]), r);
        }

        void Next()
        {
            _current = _queue.Dequeue();
            Smash.Start(Prof.Str(_current["group"]), Prof.Str(_current["size"]), _current);
        }

        void Collect()
        {
            Audio.Snd.Play("coinShower");
            if (_current != null) OnCollected?.Invoke(_current);
            if (_queue.Count > 0) { Next(); return; }
            Finish();
        }

        void Finish()
        {
            if (Finished) return;
            Finished = true;
            OnDone?.Invoke();
        }

        public List<ScreenPiece> Pieces()
        {
            var list = new List<ScreenPiece>();
            // (unseen until it has painted: the vault covers it)
            if (_shown) list.AddRange(Smash.Pieces());
            if (_vault != null) list.AddRange(_vault.Pieces());
            return list;
        }

        public void Down(float x, float y) { if (_vault == null) Smash.Down(x, y); }
        public void Move(float x, float y) { if (_vault == null) Smash.Move(x, y); }
        public void Up(float x, float y) { if (_vault == null) Smash.Up(x, y); }
    }

    /// <summary>A screen with a chest opening over it (the Shop, the Level Road): taps go to the opening while it's up.</summary>
    public sealed class WithChests : IScreenView, IWheel
    {
        public readonly IScreenView Under;
        public ChestOpening Opening;
        public WithChests(IScreenView under) { Under = under; }
        public List<ScreenPiece> Pieces()
        {
            if (Opening != null && Opening.Finished) Opening = null;
            var l = Under.Pieces();
            if (Opening != null) l.AddRange(Opening.Pieces());
            return l;
        }
        public void Down(float x, float y) { if (Opening != null) Opening.Down(x, y); else Under.Down(x, y); }
        public void Move(float x, float y) { if (Opening != null) Opening.Move(x, y); else Under.Move(x, y); }
        public void Up(float x, float y) { if (Opening != null) Opening.Up(x, y); else Under.Up(x, y); }
        public void Wheel(float x, float y, float dy) { if (Opening == null && Under is IWheel w) w.Wheel(x, y, dy); }
    }
}
