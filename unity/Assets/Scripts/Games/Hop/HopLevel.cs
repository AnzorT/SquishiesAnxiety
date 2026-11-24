// One level of Squish Hop and the ones after it, as src/hop/Game.js plays it (regular levels), in landscape
// (REDESIGN_V8: the Crib's top bar and the goal strip in a 250 dp column on the left, the board in the middle on the
// room's floor, UNDO / RESTART / HINT down a 150 dp column on the right). A line-by-line port: the same state, the same
// Animated timings, springs and easings (SquishSquad.Anim is React Native's Animated in C#), the same geometry
// (BoardGeometry), the same rules (Engine, Levels).
//   The board fluffs in back to front, the hopper drops in, the friends pop up; LEVEL n (and a new twist's banner).
//   Swipe (a hop each half a tile of drag, so a long one can turn corners) or tap a cushion next to the squishy: it
//   hops, the cushion it left puffs away (a pile loses its top one), bubbles bounce it on, friends fly to the goal card;
//   a bump (and why, in the tip) when it can't. The ★: two happy hops, the result card 1300 ms later. Nowhere left to
//   hop: a wobble, STUCK! 1000 ms later. UNDO puffs the cushions back; the first HINT asks first, then glows the next
//   hop (going back to the last spot a full clear still had, if needed). The back button pauses.
// No UnityEngine here: HopGame shows its layers (HopLayer) and cards in Unity, tools/unity/hop-test draws them.
// Not ported: sounds, haptics, ads (Unity has none: a hint is free, as with Remove Ads), the board moving when the
// screen's layout changes mid-level. Profile is kept in memory (signed in: a copy of the account's, and each outcome is
// saved there too: HopSave).
using System;
using System.Collections.Generic;
using System.Linq;
using SquishSquad.Anim;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Hop
{
    public sealed partial class HopLevel
    {
        // ---- setup --------------------------------------------------------------------------------------------------
        public Action OnExit;
        public IDictionary<string, object> Profile;
        /// <summary>Remove Ads: Unity has no ads yet, so the game behaves as for a player who bought it (a hint is free).</summary>
        public bool AdsFree => AdHook.AdsFree(Profile);   // (Remove Ads, or no ads in this build)
        public bool AdReady => AdHook.Ready();
        /// <summary>Resources/Hop/&lt;name&gt;.xml's text (the exported buttons).</summary>
        public static Func<string, string> LoadXml;

        public readonly float W, H;          // the screen, dp
        /// <summary>The screen's pixels per dp: the room's pictures land on whole pixels, as Chrome paints a picture (a
        /// view's background) in its box snapped to the pixel grid. 0: as laid out.</summary>
        public static float PixelSnap;
        public const float LeftW = 250, RightW = 150;
        public float AreaW => W - LeftW - (_blitz ? BlitzRightW : RightW);
        readonly Ticker _tk;
        readonly IList<HopSquishy> _cast;
        readonly List<HopLayer> _layers = new List<HopLayer>();
        /// <summary>What's on screen (Blitz: the board's area left out while paused, and during the countdown until GO).</summary>
        public IReadOnlyList<HopLayer> Layers => BoardHidden ? _layers.FindAll(l => l.Order < O_RUG || l.Order >= O_CHIPS + 50) : _layers;

        const double PLAYER_W = 0.86, FRIEND_W = 0.72;
        static readonly Dictionary<string, string> WHY = new Dictionary<string, string>
        {
            ["arrow"] = "Arrow cushions only let you hop off the way they point.",
            ["bounce"] = "That bubble has nowhere to bounce you.",
            ["order"] = "Pick up the friends in order: 1, 2, 3…",
            ["beat"] = "That tile isn't lit on this hop. Wait for its beat!",
            ["locked"] = "Pick up every friend first. Then the ★ opens!",
        };

        public HopLevel(float screenW, float screenH, int startLv, IList<HopSquishy> cast, IDictionary<string, object> profile, Ticker ticker, bool blitz = false, Func<int, int> seedOf = null)
        {
            W = screenW; H = screenH;
            _blitz = blitz;
            if (seedOf != null) SeedOf = seedOf;
            _tk = ticker;
            Ticker.Default = ticker;
            _cast = cast;
            Profile = profile ?? new Dictionary<string, object>();
            HopRoster.MarkMine(_cast, Profile);
            _lv = Levels.ClampLv(startLv);
            _hopper = HopRoster.HopperOf(_cast, Profile);
            _player = new Pose();
            if (_blitz) BlitzInit();
            BuildFixed();
            BuildLevel();
            NewGo();
        }

        // ---- the level ----------------------------------------------------------------------------------------------
        int _lv, _round;
        bool _fresh = true;          // a new go that also forgets the hint (not RESTART / RETRY)
        LevelSpec _spec;
        Level _board;
        RoomInfo _room;
        readonly HopSquishy _hopper;
        List<HopSquishy> _friends;
        int[] _slotOrder;
        BoardLayout B;
        List<int> _cells;
        float _pw, _ph, _fw;
        Look[] _looks;
        public int Lv => _lv;
        public BoardLayout Board => B;
        public LevelSpec Spec => _spec;

        struct Look { public HopArt.Look Off, On; }

        static double JsRound(double v) => Math.Floor(v + 0.5);

        // the result card's three (Game.js trio): a friend, the hopper in the middle, the other friend
        string[] Trio()
        {
            var want = new List<string> { _friends != null && _friends.Count > 0 ? _friends[0].Key : null, _hopper?.Key, _friends != null && _friends.Count > 1 ? _friends[1].Key : null };
            var pool = new List<string>();
            foreach (var c in _cast) pool.Add(c.Key);
            return GameCards.TrioOf(want, pool);
        }

        // src/hop/Room.js roomGeometry, landscape: the picture spans the width, raised so its floor line sits 30 % down
        const double RATIO = 1704.0 / 786;
        (double W, double H, double top, double floorY) RoomGeom()
        {
            double h = W / RATIO;
            double top = Math.Min(0, JsRound(H * 0.3) - h * _room.Floor);
            return (W, h, top, h * _room.Floor + top);
        }

        // ---- animated values: the cushions, bubbles, ★, squishies ------------------------------------------------------
        sealed class CellA { public readonly AnimatedValue A0 = new AnimatedValue(0), A1 = new AnimatedValue(0); }
        CellA[] _cellA;
        AnimatedValue[] _bubbleA;
        readonly Pose _player;
        Pose[] _friendA;
        AnimatedValue[] _slotPop;
        AnimatedValue _starPop, _starGone;
        readonly AnimatedValue _shake = new AnimatedValue(0), _flash = new AnimatedValue(0);

        // Pieces.js freshPose: where it stands (x, y, k), a hop (hp, liftH), the landing, a bump, a rock, its opacity
        sealed class Pose
        {
            public readonly AnimatedValue X = new AnimatedValue(0), Y = new AnimatedValue(0), K = new AnimatedValue(1), O = new AnimatedValue(1),
                Shadow = new AnimatedValue(1), Rot = new AnimatedValue(0), Hp = new AnimatedValue(0), LiftH = new AnimatedValue(0),
                Land = new AnimatedValue(1), Bump = new AnimatedValue(0), Dx = new AnimatedValue(0), Dy = new AnimatedValue(0);
            public readonly AnimatedNode Arc, Lift, Bx, By, Sx, Sy;
            public Pose()
            {
                Arc = Hp.Interpolate(new[] { 0, 0.25, 0.5, 0.75, 1 }, new[] { 0, -0.75, -1, -0.75, 0.0 });
                var out_ = Bump.Interpolate(new[] { 0, 0.4, 1 }, new[] { 0, 1, 0.0 });
                Lift = Animated.Multiply(Arc, LiftH);
                Bx = Animated.Multiply(out_, Dx);
                By = Animated.Multiply(out_, Dy);
                Sx = Animated.Multiply(Hp.Interpolate(new[] { 0, 0.4, 1 }, new[] { 1, 0.9, 1.0 }), Land.Interpolate(new[] { 0, 0.55, 1 }, new[] { 1.14, 0.96, 1 }));
                Sy = Animated.Multiply(Hp.Interpolate(new[] { 0, 0.4, 1 }, new[] { 1, 1.12, 1.0 }), Land.Interpolate(new[] { 0, 0.55, 1 }, new[] { 0.86, 1.05, 1 }));
            }
        }

        // ---- the game's state ----------------------------------------------------------------------------------------
        sealed class GState
        {
            public HopState St;
            public List<HopState> Hist = new List<HopState>();
            public List<int> Moves = new List<int>();
            public bool Hinted, Busy, Over, Won, Feasible = true;
            // the RESTARTs and RETRYs on this level (the stars: develop, 2026-11-16)
            public int Takebacks;
            public List<Action> Queue = new List<Action>();
            public int Shown;
            public int[] Life;
            public int TipT = -1;
            // okAt[k]: whether a full clear was still possible after k hops (Blitz's save goes back to the last one that was)
            public List<bool> OkAt = new List<bool> { true };
        }
        readonly GState G = new GState();

        struct ViewState { public int Hops, Moves, Left, Got, Cur; public bool Feasible, Hinted; }
        ViewState _view;
        int _shown, _playerZ = 10, _glow = -1, _glowKey;
        string _phase = "load";       // load | play | won | stuck
        string _tip;
        bool _stuck, _paused, _hintAsk;
        HopCards.Result _result;
        bool Blocked => _paused || _hintAsk || _result != null || _stuck || _blitzCard != null;
        public string Phase => _phase;

        void Sync()
        {
            _view = new ViewState { Hops = G.St.Hops, Moves = G.Moves.Count, Left = Engine.LeftOf(_board, G.St.Life), Got = G.St.Got, Cur = G.St.Cur, Feasible = G.Feasible, Hinted = G.Hinted };
        }

        // timers, cleared on a new go and on leaving
        readonly List<int> _timers = new List<int>();
        bool _alive = true;
        void Later(double ms, Action fn) => _timers.Add(_tk.SetTimeout(() => { if (_alive) fn(); }, ms));
        void ClearTimers() { foreach (var t in _timers) _tk.ClearTimeout(t); _timers.Clear(); }

        static TimingConfig T(double to, double ms, Func<double, double> easing = null, double delay = 0) =>
            new TimingConfig { ToValue = to, Duration = ms, Easing = easing ?? Easing.InOut(Easing.Quad), Delay = delay, UseNativeDriver = true };
        static CompositeAnimation Timing(AnimatedValue v, double to, double ms, Func<double, double> easing = null, double delay = 0) => Animated.Timing(v, T(to, ms, easing, delay));
        int ZOf(int cell, int k) => 10 + cell / _board.W * 3 + k;

        // a squishy's pose standing on `cell` (on top of a pile if `life` is 2)
        (double x, double y, double k) PoseOn(int cell, double w, double h, int life)
        {
            var q = BoardGeometry.StandOn(B, cell, life == 2 ? HopArt.PILE_TOP : 0);
            return PoseAt(w, h, q.X, q.Y, q.S / B.T);
        }
        static (double x, double y, double k) PoseAt(double w, double h, double x, double y, double k) => (x - w / 2, y - (h / 2) * (1 + k), k);
        static void Place(Pose a, (double x, double y, double k) p) { a.X.SetValue(p.x); a.Y.SetValue(p.y); a.K.SetValue(p.k); }

        // ---- the cushions ---------------------------------------------------------------------------------------------
        // a cell to `life` hops left, puffing away or back
        void SetCell(int i, int life, bool anim = true)
        {
            var A = _cellA[i];
            if (A == null || i == _board.Goal) return;
            int from = G.Life[i];
            if (from == life) return;
            G.Life[i] = life;
            var bub = _bubbleA[i];
            if (!anim)
            {
                A.A0.SetValue(life > 0 ? 1 : 0);
                A.A1.SetValue(life > 1 ? 1 : 0);
                bub?.SetValue(life > 0 ? 1 : 0);
                return;
            }
            if (life < from)
            {
                if (from == 2) Timing(A.A1, 0, 260, Easing.Out(Easing.Quad)).Start();
                if (life == 0)
                {
                    Timing(A.A0, 0, 260, Easing.Out(Easing.Quad)).Start();
                    var q = BoardGeometry.StandOn(B, i);
                    if (bub != null)
                    {
                        Timing(bub, 0, 220, Easing.Out(Easing.Quad)).Start();
                        Spray("poof", q.X, q.Y - q.S * 0.45, q.S / 60);
                        Snd.Play("tap");
                    }
                    else { Spray("pop", q.X, q.Y - q.S * 0.1, q.S / 60); Snd.Play("fs_pop"); }
                }
            }
            else
            {
                if (from == 0)
                {
                    Timing(A.A0, 1, 300, Easing.Out(Easing.Back(1.4))).Start();
                    if (bub != null) Timing(bub, 1, 260, Easing.Out(Easing.Quad)).Start();
                }
                if (life == 2) Timing(A.A1, 1, 300, Easing.Out(Easing.Back(1.4)), from == 0 ? 80 : 0).Start();
            }
        }

        // ---- moving the squishies ---------------------------------------------------------------------------------------
        // hop squishy `a` (w x h) onto `cell` in `ms`, `hopH` tiles high
        void MoveTo(Pose a, double w, double h, int cell, double ms, int life, double hopH, Action done)
        {
            var p = PoseOn(cell, w, h, life);
            if (a == _player) _playerZ = ZOf(cell, 2);
            a.Hp.SetValue(0);
            a.LiftH.SetValue(B.T * hopH);
            Animated.Parallel(Timing(a.X, p.x, ms), Timing(a.Y, p.y, ms), Timing(a.K, p.k, ms), Timing(a.Hp, 1, ms, Easing.Linear)).Start(_ =>
            {
                a.Land.SetValue(0);
                Timing(a.Land, 1, 220, Easing.Out(Easing.Quad)).Start();
                done?.Invoke();
            });
        }

        // a bump toward d (`by` tiles), or a little nudge
        void Nudge(int d, double by, double ms = 200, double delay = 0, Action done = null)
        {
            _player.Dx.SetValue(Engine.DIRS[d][0] * B.T * by);
            _player.Dy.SetValue(Engine.DIRS[d][1] * B.T * by * 0.6);
            _player.Bump.SetValue(0);
            Timing(_player.Bump, 1, ms, Easing.Out(Easing.Quad), delay).Start(_ => done?.Invoke());
        }

        void Wobble(double[] seq, double ms)
        {
            Animated.Sequence(seq.Select(v => Timing(_player.Rot, v, ms / seq.Length)).ToArray()).Start();
        }

        void TryDir(int d)
        {
            var m = Engine.TryMove(_board, G.St, d);
            if (!m.Ok) { Bump(d, m); return; }
            Hop(d, m);
        }

        void Bump(int d, MoveResult m)
        {
            Snd.Play("bonk");
            Snd.Tap();
            G.Busy = true;
            Nudge(d, 0.14, done: () => { G.Busy = false; Drain(); });
            if (m.Why == "locked")
            {
                _shake.SetValue(0);
                Timing(_shake, 1, 320, Easing.Linear).Start();
            }
            if (m.Why != null && WHY.TryGetValue(m.Why, out var why)) FlashTip(why);
        }

        void FlashTip(string text)
        {
            _tip = text;
            if (G.TipT >= 0) _tk.ClearTimeout(G.TipT);
            G.TipT = _tk.SetTimeout(() => { if (_alive) _tip = null; }, 2400);
        }

        void Hop(int d, MoveResult m)
        {
            var prev = G.St;
            var nxt = m.St;
            G.Hist.Add(prev);
            G.Moves.Add(d);
            G.St = nxt;
            G.Busy = true;
            SetGlow(-1);
            Snd.Play("st_lift");
            Snd.Tap();
            SetCell(prev.Cur, nxt.Life[prev.Cur]);
            // onto each cell in turn; a bubble pops as it bounces you on
            void Step(int k)
            {
                if (k == m.Cells.Length) { Landed(); return; }
                int c = m.Cells[k];
                bool last = k == m.Cells.Length - 1;
                MoveTo(_player, _pw, _ph, c, last ? 190 : 170, last ? nxt.Life[c] : 1, k > 0 ? 0.8 : 0.5, () =>
                {
                    if (!_alive || G.St != nxt) return;
                    if (!last) SetCell(c, nxt.Life[c]);
                    Step(k + 1);
                });
            }
            void Landed()
            {
                var q = BoardGeometry.StandOn(B, nxt.Cur);
                Spray("dust", q.X, q.Y, q.S / 60);
                foreach (var c in m.Cells)
                    if ((nxt.Got & _board.Fbit[c]) != 0 && (prev.Got & _board.Fbit[c]) == 0) Collect(c);
                if (nxt.Done) { Win(); return; }
                Check();
                SetOkAt(G.Moves.Count, G.Feasible);
                Sync();
                bool stuckNow = Engine.Moves(_board, G.St).Count == 0;
                // Blitz: a hop that leaves no full clear is the mistake that stops the run (or getting stuck, if the solver
                // gave up)
                if (_blitz && (!G.Feasible || stuckNow)) { BlitzMistake(G.Feasible ? "stuck" : "mistake"); return; }
                if (stuckNow) { GoStuck(); return; }
                G.Busy = false;
                Drain();
            }
            Step(0);
        }

        // the queued hops (taps and swipes during a hop), one at a time
        void Drain()
        {
            if (G.Busy || G.Over || G.Queue.Count == 0) return;
            var fn = G.Queue[0];
            G.Queue.RemoveAt(0);
            fn();
        }

        void Input(Action fn)
        {
            if (G.Over || Blocked || _phase != "play") return;
            if (G.Busy)
            {
                if (G.Queue.Count < 2) G.Queue.Add(fn);
                return;
            }
            fn();
        }

        // where slot k's middle is, in the board area's coordinates (Game.js measureSlots)
        (double x, double y, double size) SlotMid(int k)
        {
            int j = Array.IndexOf(_slotOrder, k);
            var (sx, sy) = HopHud.SlotAt(_friends.Count, j);
            float size = HopHud.SlotSize(_friends.Count);
            return (HopHud.GoalX + sx + size / 2 - LeftW, HopHud.GoalY + sy + size / 2, size);
        }

        // a friend hopped onto: off to its place in the goal card
        void Collect(int cell)
        {
            int k = Array.IndexOf(_board.Friends, cell);
            if (k < 0 || k >= _friends.Count) return;
            var a = _friendA[k];
            var c = _friends[k];
            Snd.Play("sd_squeak");
            double fh = c.BodyH(_fw);
            var to = SlotMid(k);
            a.Shadow.SetValue(0);
            a.Hp.SetValue(0);
            a.LiftH.SetValue(B.T * 0.9);
            var anims = new List<CompositeAnimation> { Timing(a.Hp, 1, 640, Easing.Linear) };
            var p = PoseAt(_fw, fh, to.x, to.y + to.size / 2, to.size / _fw);
            anims.Add(Timing(a.X, p.x, 640)); anims.Add(Timing(a.Y, p.y, 640)); anims.Add(Timing(a.K, p.k, 640));
            anims.Add(Timing(a.O, 0.5, 640, Easing.In(Easing.Quad)));
            Animated.Parallel(anims).Start(_ =>
            {
                a.O.SetValue(0);
                if (!_alive || (G.St.Got & _board.Fbit[cell]) == 0) return;
                G.Shown |= _board.Fbit[cell];
                _shown = G.Shown;
                _slotPop[k].SetValue(0.4);
                Animated.Spring(_slotPop[k], new SpringConfig { ToValue = 1, Friction = 4, Tension = 160, UseNativeDriver = true }).Start();
                if (G.Shown == _board.All)
                {
                    _starPop.SetValue(0);
                    Timing(_starPop, 1, 520, Easing.Out(Easing.Quad)).Start();
                    var q = BoardGeometry.StandOn(B, _board.Goal);
                    Spray("spark", q.X, q.Y - B.T * 0.4, q.S / 60);
                    Snd.Play("sd_unlock");
                }
            });
        }

        // back to an earlier state: cushions puff back, friends hop back on
        void RestoreTo(HopState target, double ms, Action done)
        {
            G.St = target;
            foreach (int i in _cells) SetCell(i, i == _board.Goal ? 1 : target.Life[i]);
            for (int k = 0; k < _board.Friends.Length; k++)
            {
                int cell = _board.Friends[k];
                if ((target.Got & _board.Fbit[cell]) != 0) continue;
                if (k >= _friends.Count) continue;
                var a = _friendA[k];
                var c = _friends[k];
                a.X.StopAnimation(); a.Y.StopAnimation(); a.K.StopAnimation(); a.O.StopAnimation();
                var p = PoseOn(cell, _fw, c.BodyH(_fw), _board.Life[cell]);
                Place(a, (p.x, p.y, p.k * 0.3));
                a.Shadow.SetValue(1);
                a.Hp.SetValue(0);
                if ((G.Shown & _board.Fbit[cell]) != 0) a.O.SetValue(0);
                Animated.Parallel(Timing(a.K, p.k, 300, Easing.Out(Easing.Back(1.6))), Timing(a.Y, p.y, 300, Easing.Out(Easing.Back(1.6))), Timing(a.O, 1, 200)).Start();
            }
            G.Shown &= target.Got;
            _shown = G.Shown;
            MoveTo(_player, _pw, _ph, target.Cur, ms, target.Life[target.Cur], 0.5, done);
        }

        void Undo()
        {
            if (G.Hist.Count == 0 || G.Won || _phase == "load") return;
            // mid-hop: after it lands
            if (G.Busy && !G.Over)
            {
                if (G.Queue.Count < 2) G.Queue.Add(Undo);
                return;
            }
            SetGlow(-1);
            var prev = G.Hist[G.Hist.Count - 1];
            G.Hist.RemoveAt(G.Hist.Count - 1);
            G.Moves.RemoveAt(G.Moves.Count - 1);
            if (G.Over)
            {
                G.Over = false;
                SetStuck(false);
                _phase = "play";
                _player.Rot.StopAnimation();
                _player.Rot.SetValue(0);
            }
            Snd.Play("st_undo");
            G.Busy = true;
            RestoreTo(prev, 190, () => { G.Busy = false; Drain(); });
            Check();
            Sync();
        }

        // the same board again from the start (the hint stays taken)
        void Restart()
        {
            if (G.St.Hops == 0 && !G.Over) return;
            G.Takebacks += 1;
            _fresh = false;
            NewRound();
        }

        // Can every cushion still be cleared? With one full clear (every level from 5), only by following it; on the
        // first few, the solver looks.
        bool OnSolution()
        {
            if (G.Moves.Count > _spec.Sol.Length) return false;
            for (int k = 0; k < G.Moves.Count; k++) if (G.Moves[k] != _spec.Sol[k]) return false;
            return true;
        }
        void Check()
        {
            if (_spec.Sols == 1) { G.Feasible = OnSolution(); return; }
            var r = Engine.Search(_board, G.St, new SearchOptions { Limit = 60000 });
            G.Feasible = r.Path != null || r.Aborted;
        }

        // ---- the hint -------------------------------------------------------------------------------------------------
        void AskHint()
        {
            if (G.Won || G.Busy || _phase != "play") return;
            if (G.Hinted) WatchHint();
            else SetHintAsk(true);
        }
        void WatchHint()
        {
            SetHintAsk(false);
            // (without Remove Ads, a rewarded ad first; the hint once its reward is earned)
            if (AdsFree) Later(200, GiveHint);
            else AdHook.Show(() => Later(200, GiveHint));
        }
        // back to the last spot on a full clear (k moves in)
        int RewindTo(int k)
        {
            int back = G.Hist.Count - k;
            var target = G.Hist[k];
            G.Hist.RemoveRange(k, G.Hist.Count - k);
            G.Moves.RemoveRange(k, G.Moves.Count - k);
            RestoreTo(target, 280, null);
            return back;
        }
        // The next hop of a full clear: from here if there is one, else after going back to the last spot that had one.
        void GiveHint()
        {
            if (G.Won) return;
            if (G.Over)
            {
                G.Over = false;
                SetStuck(false);
                _phase = "play";
                _player.Rot.SetValue(0);
            }
            G.Hinted = true;
            int back = 0, d = -1;
            if (_spec.Sols == 1)
            {
                int k = 0;
                while (k < G.Moves.Count && k < _spec.Sol.Length && G.Moves[k] == _spec.Sol[k]) k++;
                if (k < G.Moves.Count) back = RewindTo(k);
                d = k < _spec.Sol.Length ? _spec.Sol[k] : -1;
            }
            else
            {
                var r = Engine.Search(_board, G.St, new SearchOptions { Limit = 300000 });
                for (int k = G.Hist.Count - 1; r.Path == null && k >= 0; k--)
                {
                    var t = Engine.Search(_board, G.Hist[k], new SearchOptions { Limit = 300000 });
                    if (t.Path != null) { back = RewindTo(k); r = t; }
                }
                if (r.Path != null && r.Path.Length > 0) d = r.Path[0];
            }
            Check();
            Sync();
            if (d < 0) return;
            var m = Engine.TryMove(_board, G.St, d);
            if (!m.Ok) return;
            Snd.Play("st_hint");
            SetGlow(m.Cells[0]);
            int key = _glowKey;
            Later(3200, () => { if (_glowKey == key) SetGlow(-1); });
            Nudge(d, 0.1, 360, back > 0 ? 320 : 0);
            if (back > 0) FlashTip($"Went back {back} hop{(back == 1 ? "" : "s")}. Try the glowing one!");
        }

        // ---- the end of a level ------------------------------------------------------------------------------------------
        void Win()
        {
            G.Over = true;
            G.Won = true;
            G.Busy = true;
            if (_blitz) _clk.Pause();
            _phase = "won";
            _warn = false;
            Sync();
            var q = BoardGeometry.StandOn(B, _board.Goal);
            Snd.Play("st_land");
            Timing(_starGone, 1, 420, Easing.Out(Easing.Quad)).Start();
            Spray("spark", q.X, q.Y - B.T * 0.5, q.S / 60);
            Later(160, () =>
            {
                Snd.Play("sd_solve");
                if (!_blitz) Snd.Play("sd_confetti");
                Snd.Win();
                if (!_blitz) Spray("confetti", q.X, q.Y - B.T * 0.6, 1);
                // two happy hops on the ★
                _player.Hp.SetValue(0);
                _player.LiftH.SetValue(B.T * 0.55);
                Animated.Sequence(Timing(_player.Hp, 1, 340, Easing.Linear), Animated.Timing(_player.Hp, new TimingConfig { ToValue = 0, Duration = 0, UseNativeDriver = true }), Timing(_player.Hp, 1, 340, Easing.Linear)).Start();
            });
            if (_blitz) { BlitzCleared(); return; }
            int left = Engine.LeftOf(_board, G.St.Life);
            var outc = Levels.AfterLevel(Profile, _spec, new HopResult { Takebacks = G.Takebacks, Hinted = G.Hinted });
            HopSave.Paid(outc, Profile);   // (signed in: saveHop)
            Apply(outc.Update);
            var res = new HopCards.Result
            {
                Stars = outc.Stars, Coins = outc.Coins, Xp = outc.Xp, LevelUps = outc.LevelUps?.Count ?? 0, Unlocked = outc.Unlocked,
                Before = outc.Before != null ? new XpLevel(outc.Before.Level, outc.Before.Into, outc.Before.Need) : (XpLevel?)null,
                After = outc.After != null ? new XpLevel(outc.After.Level, outc.After.Into, outc.After.Need) : default,
                Hops = G.Moves.Count, Left = left, Hinted = G.Hinted,
            };
            Later(1300, () => SetResult(res));
        }

        void GoStuck()
        {
            G.Over = true;
            G.Busy = false;
            _phase = "stuck";
            Snd.Play("sd_wrong");
            Snd.Wrong();
            Wobble(new[] { -0.8, 0.8, -0.5, 0 }, 800);
            Later(1000, () => { if (G.Over && !G.Won) SetStuck(true); });
        }

        // the profile update as Firestore takes it: dotted field paths ("hop.best.12") into nested maps
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

        // ---- a new go at the level -----------------------------------------------------------------------------------------
        void NewRound() { _round++; NewGo(); }

        void SetLevel(int lv)
        {
            _lv = lv;
            BuildLevel();
            NewGo();
        }

        // the go effect: a new level or round
        void NewGo()
        {
            ClearTimers();
            bool forget = _fresh;
            _fresh = true;
            G.St = Engine.NewState(_board);
            G.Hist = new List<HopState>();
            G.Moves = new List<int>();
            G.OkAt = new List<bool> { true };
            if (forget) { G.Hinted = false; G.Takebacks = 0; }
            G.Over = false;
            G.Won = false;
            G.Busy = false;
            G.Queue = new List<Action>();
            G.Shown = 0;
            G.Life = (int[])_board.Life.Clone();
            Check();
            Sync();
            _shown = 0;
            SetResult(null);
            SetStuck(false);
            SetPaused(false);
            SetHintAsk(false);
            SetGlow(-1);
            _tip = null;
            // everything hidden, ready to come in
            foreach (int i in _cells)
            {
                _cellA[i].A0.SetValue(0);
                _cellA[i].A1.SetValue(0);
                _bubbleA[i]?.SetValue(0);
            }
            _starPop.SetValue(0);
            _starGone.SetValue(0);
            _player.O.SetValue(0);
            foreach (var a in _friendA) a.O.SetValue(0);
            if (_blitz) { BlitzGo(); _hudKey = null; return; }
            Enter();
            _phase = "play";
            if (forget)
            {
                Say($"LEVEL {_spec.Lv}", chips: new[] { Levels.TIER_NAMES[_spec.Tier], _room.Name.ToUpperInvariant() }, hold: 800);
                var rec = Levels.Record(Profile);
                bool seen = rec.Best != null && rec.Best.ContainsKey(Js.KeyOf(_spec.Lv)) && Js.Truthy(rec.Best[Js.KeyOf(_spec.Lv)]);
                var news = _spec.News != null && !seen && Levels.TWISTS.TryGetValue(_spec.News, out var tw) ? tw : null;
                if (news != null) Later(1500, () => { Snd.Play("st_news"); Say(news.Text, small: true, sub: news.Sub, hold: 1700, ink: "#0c5a9c"); });
            }
            _hudKey = null;
        }

        // the board fluffs in, back to front; the hopper drops in, the friends pop up
        void Enter()
        {
            // the board fluffs in, back to front
            foreach (int i in _cells)
            {
                var A = _cellA[i];
                double d = (i % _board.W + i / _board.W) * 24;
                A.A0.SetValue(0);
                A.A1.SetValue(0);
                Timing(A.A0, 1, 300, Easing.Out(Easing.Back(1.4)), d).Start();
                if (_board.Life[i] == 2) Timing(A.A1, 1, 300, Easing.Out(Easing.Back(1.4)), d + 70).Start();
                var bub = _bubbleA[i];
                if (bub != null)
                {
                    bub.SetValue(0);
                    Timing(bub, 1, 260, Easing.Out(Easing.Quad), 360).Start();
                }
            }
            // the hopper drops in, the friends pop up
            var p = PoseOn(_board.Start, _pw, _ph, _board.Life[_board.Start]);
            _playerZ = ZOf(_board.Start, 2);
            foreach (var v in new[] { _player.Rot, _player.Bump, _player.Hp }) { v.StopAnimation(); v.SetValue(0); }
            _player.Land.SetValue(1);
            _player.Shadow.SetValue(1);
            Place(_player, (p.x, p.y - B.T * 1.2, p.k));
            _player.O.SetValue(0);
            Animated.Parallel(Timing(_player.Y, p.y, 420, Easing.Out(Easing.Back(1.5)), 260), Timing(_player.O, 1, 160, Easing.Linear, 260)).Start();
            for (int k = 0; k < _board.Friends.Length && k < _friends.Count; k++)
            {
                int cell = _board.Friends[k];
                var a = _friendA[k];
                var c = _friends[k];
                var q = PoseOn(cell, _fw, c.BodyH(_fw), _board.Life[cell]);
                Place(a, (q.x, q.y, q.k * 0.3));
                a.O.SetValue(0);
                a.Shadow.SetValue(1);
                a.Hp.SetValue(0);
                a.Land.SetValue(1);
                double dl = 320 + k * 90;
                Animated.Parallel(Timing(a.K, q.k, 320, Easing.Out(Easing.Back(1.6)), dl), Timing(a.Y, q.y, 320, Easing.Out(Easing.Back(1.6)), dl), Timing(a.O, 1, 160, Easing.Linear, dl)).Start();
                _slotPop[k].SetValue(1);
            }
            Snd.Play("sd_boardIn");
        }

        // ---- moving on, pausing and leaving ------------------------------------------------------------------------------
        void GoTo(int n)
        {
            int to = Math.Max(1, Math.Min(Levels.LEVELS, n));
            _fresh = true;
            if (Levels.StageOf(to).Key == Levels.StageOf(_lv).Key || to == _lv)
            {
                if (to == _lv) NewRound();
                else SetLevel(to);
                return;
            }
            // a new room (or time of day): the Crib's room-switch flash
            Snd.Play("swoosh");
            Timing(_flash, 1, 200, Easing.Linear).Start(_ =>
            {
                SetLevel(to);
                _tk.SetTimeout(() => Timing(_flash, 0, 320, Easing.Linear, 120).Start(), 30);
            });
        }

        void Pause()
        {
            if (Blocked || _phase != "play") return;
            if (_blitz)
            {
                _clk.Pause();
                Snd.Play("sd_pause");
            }
            SetPaused(true);
        }

        void Resume()
        {
            SetPaused(false);
            if (_blitz && _phase == "play") _clk.Resume();
        }

        void Leave()
        {
            PayOut();
            if (_blitz) { _clk.Pause(); StopInterval(); }
            ClearTimers();
            _alive = false;
            OnExit?.Invoke();
        }

        void Retry()
        {
            var stuck = Levels.AfterStuck(Profile);
            HopSave.Record(stuck);
            Apply(stuck);
            SetStuck(false);
            G.Takebacks += 1;
            _fresh = false;
            NewRound();
        }

        /// <summary>Android's back (Escape): the hint card closes, a pause resumes, the result or STUCK! leaves, play pauses.</summary>
        public void Back()
        {
            if (_hintAsk) SetHintAsk(false);
            else if (_paused) Resume();
            else if (_blitzCard == "save") EndRun();
            else if (_result != null || _stuck || _blitzCard == "over") Leave();
            else if (_blitz && _phase != "play") return;
            else Pause();
        }

        /// <summary>The app went to the background (AppState): it pauses.</summary>
        public void AppPaused() => Pause();

        // ---- the cards over the game -----------------------------------------------------------------------------------
        Card _resultCard, _stuckCard, _pauseCard, _hintCard;
        readonly List<(Card card, int rank)> _cards = new List<(Card, int)>();   // on screen (closing ones too), bottom first
        const int RESULT = 0, STUCK = 1, PAUSE = 2, HINT = 3;   // Game.js's order: a later one shows over an earlier one
        public IEnumerable<Card> Cards { get { foreach (var c in _cards) yield return c.card; } }
        bool CardOpen { get { foreach (var c in _cards) if (c.card.Visible) return true; return false; } }

        Card Open(Card c, int rank)
        {
            int at = _cards.Count;
            while (at > 0 && _cards[at - 1].rank > rank) at--;
            _cards.Insert(at, (c, rank));
            c.Show();
            return c;
        }
        static void Close(ref Card c, bool emptied = false) { c?.Hide(emptied); c = null; }


        void SetResult(HopCards.Result res)
        {
            _result = res;
            if (res == null) { Close(ref _resultCard, true); return; }
            Close(ref _resultCard, true);
            _resultCard = Open(HopCards.ResultCard(W, H, res, _lv >= Levels.LEVELS, () => GoTo(_lv + 1), () => GoTo(_lv), Leave, Trio()), RESULT);
        }

        void SetStuck(bool on)
        {
            if (on == _stuck) return;
            _stuck = on;
            if (!on) { Close(ref _stuckCard); return; }
            int n = _board.Friends.Length;
            bool shut = _board.Nbrs[_view.Cur].Contains(_board.Goal) && Popcount(_view.Got) < n;
            _stuckCard = Open(HopCards.StuckCard(W, H, _hopper, shut, Retry), STUCK);
        }

        void SetPaused(bool on)
        {
            if (on == _paused) return;
            _paused = on;
            if (!on) { Close(ref _pauseCard); return; }
            _pauseCard = Open(HopCards.PauseCard(W, H, Resume, Leave), PAUSE);
        }

        void SetHintAsk(bool on)
        {
            if (on == _hintAsk) return;
            _hintAsk = on;
            if (!on) { Close(ref _hintCard); return; }
            _hintCard = Open(HopCards.HintCard(W, H, AdReady, AdsFree, WatchHint, () => SetHintAsk(false)), HINT);
        }

        static int Popcount(int n) { int c = 0; while (n != 0) { c += n & 1; n = (int)((uint)n >> 1); } return c; }

        void SetGlow(int cell)
        {
            if (cell == _glow) return;
            _glow = cell;
            _glowKey++;
            _glowPulse?.Unmount();
            _glowPulse = null;
            if (cell >= 0)
            {
                // usePingPong(500, { from: 0.45, to: 1, eased: false }), mounted with the glow
                _glowPulse = new KeyLoop(500, KeyLoop.PHASE, Array.ConvertAll(TRIANGLE, k => 0.45 + 0.55 * k));
                _glowPulse.Mount();
            }
        }

        static readonly double[] TRIANGLE = Array.ConvertAll(KeyLoop.PHASE, p => p < 0.5 ? 2 * p : 2 - 2 * p);

        // ---- the line under the stars: what to do, or why 3 stars are gone ------------------------------------------------
        string TipFor()
        {
            string what = _room.Dance ? "tile" : "cushion";
            long all = _board.All;
            if (!_view.Feasible) return $"Some {what}s can't be cleared now. UNDO to go for 3 stars!";
            if (_spec.Lv == 1 && _view.Hops == 0) return "Swipe, or tap a cushion next to you, to hop.";
            if (_spec.Lv == 1) return "Cushions puff away behind you. Clear them all, then hop onto the ★!";
            if (_spec.News == "friends" && _view.Got != all) return "Pick up the friend. The ★ opens when everyone is with you.";
            if (_spec.News == "arrows") return "Arrow cushions: you can only hop off them the way they point.";
            if (_spec.News == "bubbles") return "Hop onto a bubble and it bounces you one cushion further.";
            if (_spec.News == "piles") return "A pile of two cushions takes two hops to clear.";
            if (_spec.News == "ordered") return "Pick up the friends in number order: 1, then 2, then 3.";
            if (_spec.Beats) return $"Coloured tiles are lit on their beat only. Next hop: the {HopArt.BEAT_NAMES[(_view.Hops + 1) % 3]} ones.";
            if (_board.Friends.Length > 0 && _view.Got != all) return $"Pick up every friend{(_spec.Twists.Contains("ordered") ? " in order" : "")}, clear every {what}, then the ★.";
            return $"Clear every {what}, then hop onto the ★.";
        }

        // ---- the banner (sort/Game.js Banner, top 4 in the board's area) -------------------------------------------------
        readonly AnimatedValue _bannerT = new AnimatedValue(0);
        CompositeAnimation _bannerAnim;
        float _bannerW, _bannerH;

        void Say(string text, bool small = false, string ink = "#5b3418", double hold = 700, string sub = null, string[] chips = null)
        {
            var big = new TextStyle { Font = "Fredoka_700Bold", Size = small ? 30 : 40, Color = "#ffffff", Shadows = new[] { new Shadow(ink, 0, 3, 0), new Shadow(ink, 1, 0, 0), new Shadow(ink, -1, 0, 0) } };
            float lineH = UiSvg.LineBox(big);
            float w = AreaW;
            float y = 0;
            var s = new UiSvg(w, 200);
            s.Text(text, 0, y, big, w, 0.5f);
            y += lineH;
            if (chips != null && chips.Length > 0)
            {
                var ct = new TextStyle { Font = "Fredoka_700Bold", Size = 12, LetterSpacing = 0.6f, Color = "#ffffff" };
                y += 8;
                float total = -6, ch = UiSvg.LineBox(ct) + 6 + 4;
                // (Blitz's "⏱ 0:14": no font has ⏱, Chrome draws its emoji: Resources/Screens/emoji/timer-11, at 12)
                const float EK = 12f / 11, EW = 8.59375f * EK, EH = 15 * EK, EADV = 8.579940795898438f * EK, EBASE = 11 * EK;
                float TextW(string c) => c.StartsWith("⏱") ? EADV + UiSvg.Width(c.Substring(1), ct) : UiSvg.Width(c, ct);
                foreach (var c in chips) total += TextW(c) + 18 + 4 + 6;
                float cx = (w - total) / 2;
                foreach (var c in chips)
                {
                    float cw = TextW(c) + 18 + 4;
                    s.Box(cx, y, cw, ch, new BoxStyle { Background = "#e01e4a", Radius = 999, BorderWidth = 2, BorderColor = "#ffffff" });
                    if (c.StartsWith("⏱"))
                    {
                        s.Image("Screens/emoji/timer-11", cx + 2 + 9, UiSvg.Baseline(ct, y + 2 + 3) - EBASE, EW, EH);
                        s.Text(c.Substring(1), cx + 2 + 9 + EADV, y + 2 + 3, ct);
                    }
                    else s.Text(c, cx + 2 + 9, y + 2 + 3, ct);
                    cx += cw + 6;
                }
                y += ch;
            }
            if (sub != null)
            {
                var st = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#ffffff" };
                y += 6;
                float sw = UiSvg.Width(sub, st) + 24, sh = UiSvg.LineBox(st) + 8;
                s.Box((w - sw) / 2, y, sw, sh, new BoxStyle { Background = "rgba(69,16,122,0.8)", Radius = 999 });
                s.Text(sub, (w - sw) / 2 + 12, y + 4, st);
                y += sh;
            }
            _bannerW = w; _bannerH = y;
            _banner.Svg(s.Markup.Replace("height=\"200\"", $"height=\"{UiSvg.F(y)}\"").Replace("viewBox=\"0 0 " + UiSvg.F(w) + " 200\"", $"viewBox=\"0 0 {UiSvg.F(w)} {UiSvg.F(y)}\""), w, y, 12);
            _bannerT.SetValue(0);
            _bannerAnim?.Stop();
            _bannerAnim = Animated.Sequence(
                Animated.Spring(_bannerT, new SpringConfig { ToValue = 1, Friction = 5, Tension = 140, UseNativeDriver = true }),
                Animated.Timing(_bannerT, new TimingConfig { ToValue = 1, Duration = hold, UseNativeDriver = true }),
                Animated.Timing(_bannerT, T(2, 220, Easing.In(Easing.Quad))));
            _bannerAnim.Start();
        }

        // ---- the effects (squishdoku/fx.js FxLayer, over the board's area) ------------------------------------------------
        readonly List<(Ui.Cards.Burst burst, List<HopLayer> layers)> _bursts = new List<(Ui.Cards.Burst, List<HopLayer>)>();
        void Spray(string kind, double x, double y, double scale)
        {
            var b = new Ui.Cards.Burst(kind, x, y, scale);
            var ls = new List<HopLayer>();
            foreach (var l in b.Layers) { var h = new HopLayer("fx " + kind, 0).Svg(l.Markup, l.W, l.H, l.Margin); ls.Add(h); _layers.Add(h); }
            _bursts.Add((b, ls));
            b.Start();
        }

        // ---- the pieces ------------------------------------------------------------------------------------------------
        // paint order (Unity's sortingOrder): the room, then the board's area (zIndex 2), in tree order: the rug, the dents,
        // the cushions, the hint's glow, the squishies, bubbles and ★ (one view: react-native-web's views are stacking
        // contexts, so their zIndex orders them among themselves only), the banner, the effects; over them the order
        // chips (zIndex 95); then the HUD columns (zIndex 3), the cards, the room-switch flash
        const int O_ROOM = 0, O_RUG = 100, O_UNDER = 101, O_TILES = 200, O_GLOW = 900, O_Z = 1000, O_BANNER = 4800, O_FX = 4810, O_CHIPS = 4950,
            O_HUD = 6000, O_BUTTONS = 6100, O_FLASH = 9000;
        public const int CardOrder = 7000;

        HopLayer _bg, _base, _under_, _over, _tint, _rug, _underBoard, _glowLayer, _banner, _starLayer, _hud, _goal, _backLip, _backTop, _flashGlow, _flashDots;
        HopLayer[] _copies = new HopLayer[0], _tiles0, _tiles1, _bubbles, _fShadow, _fPic, _chips, _slots;
        HopLayer _pShadow, _pPic;
        KeyLoop[] _bubbleBob, _fBreathe, _fPeek;
        KeyLoop _starBob, _pBreathe, _glowPulse;
        readonly List<Btn> _btns = new List<Btn>();

        HopLayer Add(string name, int order) { var l = new HopLayer(name, order); _layers.Add(l); return l; }
        void Remove(HopLayer l) { if (l != null) _layers.Remove(l); }
        void Remove(HopLayer[] ls) { if (ls != null) foreach (var l in ls) Remove(l); }

        // what stays through every level: the HUD, the buttons, the hopper, the banner, the flash
        void BuildFixed()
        {
            _hud = Add("hud", O_HUD);
            _goal = Add("goal card", O_HUD + 1);
            _backLip = Add("back lip", O_HUD + 20).Svg(LoadXml("back-lip"), 48, 48, 4);
            _backTop = Add("back top", O_HUD + 21).Svg(LoadXml("back-top"), 48, 52, 4);
            // the right column: three 55 dp buttons 10 apart after 8 dp of padding, centred down it
            float bx = W - RightW + 14, by0 = (H - 193) / 2 + 8;
            // (Blitz: no UNDO, RESTART or hints; the rule and the board's clock on the glass instead)
            if (!_blitz)
            {
                _btns.Add(new Btn(this, "undo", bx, by0, O_BUTTONS, () => Undo()));
                _btns.Add(new Btn(this, "restart", bx, by0 + 65, O_BUTTONS + 2, () => Restart()));
                _btns.Add(new Btn(this, "hint", bx, by0 + 130, O_BUTTONS + 4, () => AskHint()));
            }
            _banner = Add("banner", O_BANNER);
            _pShadow = Add("hopper shadow", O_Z);
            _pPic = Add("hopper", O_Z);
            _pBreathe = new KeyLoop(2600, KeyLoop.PHASE, KeyLoop.UP_DOWN);
            _pBreathe.Mount();
            _flashGlow = Add("flash glow", O_FLASH).Pic("Hop/flash-glow", W, H);
            _flashDots = Add("flash dots", O_FLASH + 1).Pic("Hop/flash-dots", W, H, null, 22, 22);
        }

        // what a level has: the room, the board, the friends (Game.js's useMemos on the level)
        void BuildLevel()
        {
            _spec = _blitz ? Blitz.BlitzSpec(_idx, _seed) : Levels.LevelSpec(_lv);
            _board = _spec.Board;
            _room = Levels.ROOMS[_spec.Room];
            _friends = HopRoster.FriendsOf(_cast, _hopper, _board.Friends.Length, _blitz ? 101 + _idx * 31 + (_seed & 1023) : _lv);
            _slotOrder = Enumerable.Range(0, _board.Friends.Length).OrderBy(k => _board.Order[_board.Friends[k]]).ToArray();
            var g = RoomGeom();
            B = BoardGeometry.Layout(_board.W, _board.H, AreaW, H, g.floorY);
            _cells = new List<int>();
            for (int i = 0; i < _board.Life.Length; i++) if (_board.Life[i] > 0) _cells.Add(i);
            _pw = (float)(B.T * PLAYER_W);
            _ph = _hopper != null ? _hopper.BodyH(_pw) : 0;
            _fw = (float)(B.T * FRIEND_W);

            _cellA = new CellA[_board.Life.Length];
            _bubbleA = new AnimatedValue[_board.Life.Length];
            for (int i = 0; i < _board.Life.Length; i++)
            {
                if (_board.Life[i] > 0) _cellA[i] = new CellA();
                if (_board.Bubble[i]) _bubbleA[i] = new AnimatedValue(0);
            }
            if (_friendA != null) foreach (var l in _fBreathe.Concat(_fPeek)) l?.Unmount();
            _friendA = new Pose[_board.Friends.Length];
            for (int k = 0; k < _friendA.Length; k++) _friendA[k] = new Pose();
            _slotPop = new AnimatedValue[_board.Friends.Length];
            for (int k = 0; k < _slotPop.Length; k++) _slotPop[k] = new AnimatedValue(1);
            _starPop = new AnimatedValue(0);
            _starGone = new AnimatedValue(0);

            var looks = new Look[_board.Life.Length];
            for (int i = 0; i < looks.Length; i++)
            {
                if (_board.Life[i] == 0) continue;
                var off = new HopArt.Look { Dance = _room.Dance, Color = _room.Cushion ?? "pink", Goal = i == _board.Goal, Pile = _board.Life[i] == 2, Arrow = _board.Arrow[i], Beat = _board.Beat[i], Beats = _spec.Beats, Lit = false };
                var on = off;
                if (_board.Beat[i] >= 0) on.Lit = true;
                looks[i] = new Look { Off = off, On = on };
            }
            _looks = looks;
            BuildPieces(g);
        }

        void BuildPieces((double W, double H, double top, double floorY) g)
        {
            // the last level's
            foreach (var l in new[] { _bg, _base, _under_, _over, _tint, _rug, _underBoard, _glowLayer, _starLayer }) Remove(l);
            Remove(_copies); Remove(_tiles0); Remove(_tiles1); Remove(_bubbles); Remove(_fShadow); Remove(_fPic); Remove(_chips); Remove(_slots);
            _glowLayer = null;
            _bubbleBob?.ToList().ForEach(b => b?.Unmount());
            _starBob?.Unmount();

            // the room (src/hop/Room.js): its colour, the floor again and again below, the room's things down to the floor
            // line, the tint for the time of day
            float iw = (float)g.W, ih = (float)g.H, t0 = (float)g.top;
            _bg = Add("room colour", O_ROOM).Svg(new UiSvg(W, H).Box(0, 0, W, H, new BoxStyle { Background = _room.Bg }).Markup, W, H, 0);
            _bg.Transform = Affine.Identity;
            double step = ih * (1 - _room.Floor) - ih * 0.06;
            var copies = new List<double>();
            for (int k = 1; t0 + ih + (k - 1) * step < H; k++) copies.Add(ih + (k - 1) * step - (_room.Floor + 0.05) * ih);
            copies.Reverse();
            string pic(string layer) => $"Hop/rooms/{_room.Key}-{layer}";
            _copies = copies.Select((top, k) => Snapped(Add("floor " + k, O_ROOM + 1 + k), pic("base"), iw, ih, t0 + top)).ToArray();
            int o = O_ROOM + 1 + copies.Count;
            var under = Phases(_room.Key, "under");
            _under_ = under.Contains(_spec.Phase) ? Snapped(Add("room under", o++), pic("under-" + _spec.Phase), iw, ih, t0) : null;
            _base = Snapped(Add("room", o++), pic("base"), iw, ih, t0);
            var over = Phases(_room.Key, "over");
            _over = over.Contains(_spec.Phase) ? Snapped(Add("room over", o++), pic("over-" + _spec.Phase), iw, ih, t0, ih * (_room.Floor + 0.012)) : null;
            string tint = _spec.Phase == "morning" ? "rgba(255,170,140,0.05)" : _spec.Phase == "evening" ? "rgba(90,20,120,0.1)" : _spec.Phase == "night" ? "rgba(20,24,70,0.22)" : null;
            _tint = tint != null ? Add("tint", o++).Svg(new UiSvg(W, H).Box(0, 0, W, H, new BoxStyle { Background = tint }).Markup, W, H, 0) : null;

            // the Living Room's rug, laid on the floor under the board: its picture's corners on the plane
            if (_room.Rug)
            {
                const int N = 24;
                var grid = new double[(N + 1) * (N + 1) * 2];
                for (int r = 0; r <= N; r++)
                    for (int c = 0; c <= N; c++)
                    {
                        double u = (-0.16 + 1.32 * c / N) * B.W, v = (-0.12 + 1.24 * r / N) * B.H;
                        var p = BoardGeometry.Project(B, u, v);
                        grid[(r * (N + 1) + c) * 2] = p.X + LeftW;
                        grid[(r * (N + 1) + c) * 2 + 1] = p.Y;
                    }
                _rug = Add("rug", O_RUG).Plane("Hop/rug", grid, N);
            }
            else _rug = null;
            _underBoard = Add("dents", O_UNDER).Svg(HopArt.Under(B, _cells, _room.Dance, _room.Dent, AreaW, H), AreaW, H, 4);
            _underBoard.Transform = Affine.Translate(LeftW, 0);

            // the cushions: each cell's bottom one and a pile's top one, each its own piece (puffing away and back)
            _tiles0 = new HopLayer[_board.Life.Length];
            _tiles1 = new HopLayer[_board.Life.Length];
            int n = 0;
            foreach (int i in _cells)
            {
                _tiles0[i] = Add("cushion " + i, O_TILES + n++);
                if (_board.Life[i] == 2) _tiles1[i] = Add("pile " + i, O_TILES + n++);
            }
            _tileLit = new bool?[_board.Life.Length];

            _bubbles = new HopLayer[_board.Life.Length];
            _bubbleBob = new KeyLoop[_board.Life.Length];
            foreach (int i in _cells)
            {
                if (!_board.Bubble[i]) continue;
                var q = BoardGeometry.Project(B, i % _board.W + 0.5, i / _board.W + 0.56);
                double size = q.S * 0.62;
                _bubbles[i] = Add("bubble " + i, 0).Svg(HopArt.Bubble(i, size), (float)size, (float)size, 4);
                _bubbleBob[i] = new KeyLoop(2200, KeyLoop.PHASE, Array.ConvertAll(KeyLoop.UP_DOWN, k => -size * 0.1 * k), (i * 370) % 2000);
                _bubbleBob[i].Mount();
            }
            {
                var q = BoardGeometry.Project(B, _board.Goal % _board.W + 0.5, _board.Goal / _board.W + 0.56);
                double size = q.S * 0.52;
                _starLayer = Add("goal star", 0);
                _starBob = new KeyLoop(1800, KeyLoop.PHASE, Array.ConvertAll(KeyLoop.UP_DOWN, k => -size * 0.08 * k));
                _starBob.Mount();
                _starLeft = -1;
            }
            int nf = _board.Friends.Length;
            _fShadow = new HopLayer[nf]; _fPic = new HopLayer[nf]; _chips = new HopLayer[nf]; _slots = new HopLayer[nf];
            _fBreathe = new KeyLoop[nf]; _fPeek = new KeyLoop[nf];
            string shade = _room.Dance ? "rgba(255,255,255,0.3)" : "rgba(69,16,122,0.28)";
            for (int k = 0; k < nf && k < _friends.Count; k++)
            {
                var c = _friends[k];
                float fh = c.BodyH(_fw);
                _fShadow[k] = Add("friend shadow " + k, 0).Svg(HopArt.Shadow(_fw * 0.72f, fh * 0.15f, shade), _fw * 0.72f, fh * 0.15f, 2);
                _fPic[k] = PicOf(Add("friend " + c.Key, 0), c, _fw);
                _fBreathe[k] = new KeyLoop(2200, KeyLoop.PHASE, KeyLoop.UP_DOWN, k * 900);
                _fBreathe[k].Mount();
                _fPeek[k] = new KeyLoop(6000, PEEK_AT, PEEK_DEG, k * 900);
                _fPeek[k].Mount();
                int cell = _board.Friends[k];
                if (_board.Order[cell] > 0)
                {
                    var q = BoardGeometry.StandOn(B, cell, _board.Life[cell] == 2 ? HopArt.PILE_TOP : 0);
                    float size = (float)Math.Max(18, q.S * 0.3);
                    double hh = fh * (q.S / B.T);
                    double x = q.X + _fw * (q.S / B.T) * 0.42, y = q.Y - hh * 0.9;
                    _chips[k] = Add("order chip " + k, O_CHIPS + k).Svg(HopArt.OrderChip(_board.Order[cell], size, out _), size, size, 4);
                    _chips[k].Transform = Affine.Translate(LeftW + x - size / 2, y - size / 2);
                }
                float ss = HopHud.SlotSize(nf);
                _slots[k] = Add("slot " + k, O_HUD + 2 + k);
            }
            _pShadow.Svg(HopArt.Shadow(_pw * 0.72f, _ph * 0.15f, shade), _pw * 0.72f, _ph * 0.15f, 2);
            if (_hopper != null) PicOf(_pPic, _hopper, _pw);
            _slotKey = new string[nf];
        }

        // A room picture (resizeMode cover, the box already its shape) in the box w x h at (0, top), cut to `clipH` of its
        // height, as Chrome paints a view's background picture: the box in layout units (1/64 dp, cut toward zero),
        // snapped to the screen's pixels, the picture stretched over the snapped box.
        static HopLayer Snapped(HopLayer l, string picture, float w, float h, double top, double clipH = 0)
        {
            double k = PixelSnap;
            if (k <= 0) { l.Pic(picture, w, h, clipH > 0 ? new[] { 0, 0, w, (float)clipH } : null); l.Transform = Affine.Translate(0, top); return l; }
            double Lu(double v) => Math.Truncate(v * 64) / 64;
            double Px(double v) => Math.Floor(v * k + 0.5) / k;
            double t = Lu(top);
            double y0 = Px(t), y1 = Px(t + Lu(h)), bw = Px(Lu(w)), bh = y1 - y0;
            double cut = clipH > 0 ? Math.Min(bh, Px(t + Lu(clipH)) - y0) : 0;
            l.Pic(picture, (float)bw, (float)bh, cut > 0 ? new[] { 0, 0, (float)bw, (float)cut } : null);
            l.Transform = Affine.Translate(0, y0);
            return l;
        }

        static readonly double[] PEEK_AT = { 0, 0.84, 0.88, 0.92, 0.96, 1 };
        static readonly double[] PEEK_DEG = { 0, 0, -9, 8, -3, 0 };

        // a squishy's picture (stack/Pieces.js Squishy): its body fills w x bodyH; a still's margins hang outside it
        static HopLayer PicOf(HopLayer l, HopSquishy c, float w)
        {
            float sw = w / (c.Box[2] - c.Box[0]), sh = sw * c.Ar;
            if (c.Picture == null) { l.Svg(new UiSvg(w, c.BodyH(w)).Markup, w, c.BodyH(w), 0); return l; }
            return l.Pic(c.Picture, sw, sh);
        }

        // the time-of-day pictures a room has (src/crib/roomArt.js)
        static string[] Phases(string room, string layer)
        {
            if (layer == "under") return room == "yard" ? new[] { "day", "evening", "morning", "night" } : new string[0];
            switch (room)
            {
                case "bath": case "dance": return new[] { "day" };
                case "yard": return new string[0];
                default: return new[] { "day", "evening", "morning", "night" };
            }
        }

        // ---- every frame ------------------------------------------------------------------------------------------------
        bool?[] _tileLit;
        int _starLeft = -1;
        string _hudKey;
        string[] _slotKey;
        bool _backDown;

        static Affine About(double w, double h, Affine m) => Affine.Translate(w / 2, h / 2) * m * Affine.Translate(-w / 2, -h / 2);

        /// <summary>Places every piece for the clock's current time (call after the Ticker's tick).</summary>
        public void Update()
        {
            _cards.RemoveAll(c => !c.card.Shown);
            int nf = _friends.Count;
            int leftToOpen = _board.Friends.Length - Popcount(_shown);
            int nextBeat = (_view.Hops + 1) % 3;
            bool playing = _phase == "play" && !_paused;
            var area = Affine.Translate(LeftW, 0);

            // the cushions (Pieces.js Tile + puff)
            foreach (int i in _cells)
            {
                bool lit = _board.Beat[i] >= 0 && _board.Beat[i] == nextBeat;
                var look = lit ? _looks[i].On : _looks[i].Off;
                var box = HopArt.TileBox(B, i, look.Pile);
                if (_tileLit[i] != lit)
                {
                    _tileLit[i] = lit;
                    _tiles0[i].Svg(HopArt.TileBottom(B, i, look, box), box.Width, box.Height, 4);
                    _tiles1[i]?.Svg(HopArt.TileTop(B, i, look, box), box.Width, box.Height, 4);
                }
                Puff(_tiles0[i], _cellA[i].A0.GetValue(), box, area);
                if (_tiles1[i] != null) Puff(_tiles1[i], _cellA[i].A1.GetValue(), box, area);
            }
            // the hint's glow, pulsing
            if (_glow >= 0)
            {
                if (_glowLayer == null || _glowLayer.Name != "glow " + _glowKey)
                {
                    Remove(_glowLayer);
                    _glowLayer = Add("glow " + _glowKey, O_GLOW);
                    var markup = HopArt.HintGlow(B, _glow, G.Life[_glow] == 2 ? HopArt.PILE_TOP : 0, out var gb);
                    _glowLayer.Svg(markup, gb.Width, gb.Height, 6);
                    _glowLayer.Transform = area * Affine.Translate(gb.Left, gb.Top);
                }
                _glowLayer.Opacity = (float)_glowPulse.Value;
            }
            else if (_glowLayer != null) { Remove(_glowLayer); _glowLayer = null; }

            // the zIndexed things over the board: bubbles, the ★, the friends, the hopper (ties in tree order)
            foreach (int i in _cells)
            {
                var l = _bubbles[i];
                if (l == null) continue;
                var q = BoardGeometry.Project(B, i % _board.W + 0.5, i / _board.W + 0.56);
                double size = q.S * 0.62, a = _bubbleA[i].GetValue();
                double sc = 1.5 + (1 - 1.5) * a;
                l.Transform = area * Affine.Translate(q.X - size / 2, q.Y - size - q.S * 0.1) * About(size, size, Affine.Translate(0, _bubbleBob[i].Value) * Affine.ScaleBy(sc, sc));
                l.Opacity = (float)a;
                l.Order = O_Z + ZOf(i, 0) * 40 + (i % _board.W) * 2;
            }
            {
                var q = BoardGeometry.Project(B, _board.Goal % _board.W + 0.5, _board.Goal / _board.W + 0.56);
                double size = q.S * 0.52, gone = _starGone.GetValue(), pop = _starPop.GetValue();
                if (_starLeft != leftToOpen) { _starLeft = leftToOpen; _starLayer.Svg(HopArt.GoalStar(size, leftToOpen), (float)size, (float)size, (float)(size * 0.2 + 4)); }
                double popAdd = pop <= 0.45 ? pop / 0.45 * 0.5 : 0.5 + (pop - 0.45) / 0.55 * -0.5;
                double sc = (1 + 0.4 * gone) + popAdd;
                _starLayer.Transform = area * Affine.Translate(q.X - size / 2, q.Y - size - q.S * 0.16) * About(size, size, Affine.Translate(0, _starBob.Value) * Affine.Translate(0, -size * 0.7 * gone) * Affine.ScaleBy(sc, sc));
                _starLayer.Opacity = (float)(1 - gone);
                _starLayer.Order = O_Z + ZOf(_board.Goal, 0) * 40 + 20;
            }
            for (int k = 0; k < nf; k++)
            {
                var c = _friends[k];
                PlacePiece(_fShadow[k], _fPic[k], _friendA[k], c, _fw, c.BodyH(_fw), _fBreathe[k], _fPeek[k], ZOf(_board.Friends[k], 1), 11 + k, 0.03);
                if (_chips[k] != null) _chips[k].Visible = (G.St.Got & _board.Fbit[_board.Friends[k]]) == 0;
            }
            if (_hopper != null) PlacePiece(_pShadow, _pPic, _player, _hopper, _pw, _ph, _pBreathe, null, _playerZ, 18, 0.03);

            // the banner: over the area's top, scaled and turned about its centre
            double bt = _bannerT.GetValue();
            _banner.Opacity = (float)Piecewise(bt, new[] { 0.0, 0.2, 1, 2 }, new[] { 0.0, 1, 1, 0 });
            double bs = Piecewise(bt, new[] { 0.0, 1, 2 }, new[] { 0.3, 1, 1.25 }), br = Piecewise(bt, new[] { 0.0, 1, 2 }, new[] { -12.0, -3, 0 });
            _banner.Transform = area * Affine.Translate(0, 4) * About(_bannerW, _bannerH, Affine.ScaleBy(bs, bs) * Affine.Rotate(br));
            _banner.Visible = _bannerW > 0;

            // the effects
            for (int b = _bursts.Count - 1; b >= 0; b--)
            {
                var (burst, ls) = _bursts[b];
                if (burst.Done) { foreach (var l in ls) Remove(l); _bursts.RemoveAt(b); continue; }
                burst.Place(area, 1);
                for (int i = 0; i < ls.Count; i++) { ls[i].Transform = burst.Layers[i].Transform; ls[i].Opacity = burst.Layers[i].Opacity; ls[i].Order = O_FX + Math.Min(b, 100); }
            }

            // the HUD
            int can = _view.Feasible ? 3 : 2;
            if (_view.Hinted) can = Math.Max(1, can - 1);
            var hud = new HopHud.Hud
            {
                Room = _room.Name, Lv = _lv, Tier = _spec.Tier, Stars = can, Left = _view.Left, Hops = _view.Moves, NextBeat = nextBeat,
                Beats = _spec.Beats, Dance = _room.Dance, TipWarn = !_view.Feasible && _phase != "won", Tip = _tip ?? TipFor(),
                Friends = _board.Friends.Length, LeftToOpen = leftToOpen,
            };
            if (_blitz)
            {
                // Blitz: the boards cleared this run, and the best run (gold once it's beaten)
                int bestRun = (int)Js.ToNumber(Levels.Record(Profile).BlitzTop);
                hud.Blitz = true; hud.Room = "Blitz Mode"; hud.Cleared = _cleared; hud.Best = Math.Max(bestRun, _cleared); hud.BestBeaten = _cleared > bestRun && bestRun > 0;
                hud.Tip = null; hud.TipWarn = false;
            }
            string key = $"{hud.Room}|{hud.Lv}|{hud.Tier}|{hud.Stars}|{hud.Left}|{hud.Hops}|{hud.NextBeat}|{hud.Beats}|{hud.TipWarn}|{hud.Tip}|{hud.LeftToOpen}|{hud.Cleared}|{hud.Best}|{hud.BestBeaten}";
            if (key != _hudKey)
            {
                _hudKey = key;
                _hud.Svg(HopHud.Column(hud, H), LeftW, H, 4);
                _goal.Svg(HopHud.GoalCard(hud), HopHud.GoalW, HopHud.GoalH, 4);
            }
            double shakeX = Piecewise(_shake.GetValue(), new[] { 0, 0.25, 0.5, 0.75, 1 }, new[] { 0.0, -6, 6, -3, 0 });
            _goal.Transform = Affine.Translate(HopHud.GoalX + shakeX, HopHud.GoalY);
            float ssz = HopHud.SlotSize(_board.Friends.Length);
            for (int j = 0; j < _slotOrder.Length; j++)
            {
                int k = _slotOrder[j];
                if (k >= nf) continue;
                var c = _friends[k];
                int cell = _board.Friends[k];
                bool got = (_shown & _board.Fbit[cell]) != 0;
                string sk = got ? "1" : "0";
                if (_slotKey[k] != sk) { _slotKey[k] = sk; _slots[k].Svg(HopHud.Slot(ssz, c.Happy, c.Picture, got, _board.Order[cell]), ssz, ssz, 7); }
                var (sx, sy) = HopHud.SlotAt(_board.Friends.Length, j);
                double pop = _slotPop[k].GetValue();
                _slots[k].Transform = Affine.Translate(HopHud.GoalX + shakeX + sx, HopHud.GoalY + sy) * About(ssz, ssz, Affine.ScaleBy(pop, pop));
            }
            _backLip.Transform = Affine.Translate(10, 8.9453125 + 4);   // (pressed, the button moves down 3 and its lip up 3)
            _backTop.Transform = Affine.Translate(10, 8.9453125 + (_backDown ? 3 : 0));
            if (!_blitz)
            {
                _btns[0].SetOn(!(!(playing || _phase == "stuck") || _view.Hops == 0));
                _btns[1].SetOn(!(!(playing || _phase == "stuck") || _view.Hops == 0));
                _btns[2].SetOn(!(!playing || (_view.Hinted && !AdsFree && !AdReady)));
                foreach (var b in _btns) b.Draw();
            }
            else BlitzDraw();

            // the room-switch flash
            float fl = (float)_flash.GetValue();
            _flashGlow.Opacity = _flashDots.Opacity = fl;
            _flashGlow.Visible = _flashDots.Visible = fl > 0;
        }

        // Pieces.js puff: going, it squashes flat and shrinks away; coming back it does that backwards
        static void Puff(HopLayer l, double a, CellBox box, Affine area)
        {
            double op = Piecewise(a, new[] { 0, 0.35, 1 }, new[] { 0.0, 1, 1 });
            double sx = Piecewise(a, new[] { 0, 0.7, 1 }, new[] { 0.25, 1.16, 1 }), sy = Piecewise(a, new[] { 0, 0.7, 1 }, new[] { 0.25, 0.62, 1 });
            l.Transform = area * Affine.Translate(box.Left, box.Top) * About(box.Width, box.Height, Affine.ScaleBy(sx, sy));
            l.Opacity = (float)op;
        }

        // Pieces.js Piece: placed and sized by x, y, k; its shadow (shrinking as it hops); hopping up, nudged, squashed
        // and rocked from its feet; breathing (and a friend peeking about)
        void PlacePiece(HopLayer shadow, HopLayer pic, Pose a, HopSquishy c, double w, double h, KeyLoop breathe, KeyLoop peek, int z, int tie, double _)
        {
            var area = Affine.Translate(LeftW, 0);
            double k = a.K.GetValue();
            var outer = area * About(w, h, Affine.Translate(a.X.GetValue(), a.Y.GetValue()) * Affine.ScaleBy(k, k));
            float o = (float)a.O.GetValue();
            double arc = a.Arc.GetValue();
            double ss = Piecewise(arc, new[] { -1.0, 0 }, new[] { 0.6, 1.0 });
            double sw = w * 0.72, sh = h * 0.15;
            shadow.Transform = outer * Affine.Translate(w * 0.14, h * 0.9) * About(sw, sh, Affine.ScaleBy(ss, ss));
            shadow.Opacity = o * (float)a.Shadow.GetValue();
            shadow.Order = O_Z + z * 40 + tie * 2;
            var view1 = Affine.Translate(a.Bx.GetValue(), a.Lift.GetValue() + a.By.GetValue());
            Affine Feet(Affine m) => About(w, h, Affine.Translate(0, h / 2) * m * Affine.Translate(0, -h / 2));
            var view2 = Feet(Affine.ScaleBy(a.Sx.GetValue(), a.Sy.GetValue()) * Affine.Rotate(a.Rot.GetValue() * 10));
            double b = breathe.Value;
            var view3 = Feet(Affine.ScaleBy(1 + 0.03 * b, 1 - 0.03 * b) * Affine.Rotate(peek != null ? peek.Value : 0));
            double pw = w / (c.Box[2] - c.Box[0]), phh = pw * c.Ar;
            pic.Transform = outer * view1 * view2 * view3 * Affine.Translate(-c.Box[0] * pw, -c.Box[1] * phh);
            pic.Opacity = o;
            pic.Order = O_Z + z * 40 + tie * 2 + 1;
        }

        static double Lerp(double v, double i0, double i1, double o0, double o1) => o0 + (v - i0) / (i1 - i0) * (o1 - o0);
        // Animated's interpolate with "extend" at both ends
        static double Piecewise(double v, double[] input, double[] output)
        {
            int i = 1;
            while (i < input.Length - 1 && v > input[i]) i++;
            return Lerp(v, input[i - 1], input[i], output[i - 1], output[i]);
        }

        // ---- touch ----------------------------------------------------------------------------------------------------
        sealed class Touch { public double X0, Y0, Gx, Gy, Sx, Sy; public bool Moved; }
        Touch _touch;
        Btn _pressed;
        bool _cardDown;

        /// <summary>A finger (or the mouse) down at (x, y), screen dp.</summary>
        public void Down(float x, float y)
        {
            if (BlitzCardOpen) { BlitzCardsDown(x, y); _cardDown = true; _touch = null; return; }
            if (CardOpen)
            {
                for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Down(x, y)) break;
                _cardDown = true;
                _touch = null;
                return;
            }
            // the back button (hitSlop 4) and the right column's buttons
            if (x >= 10 - 4 && x <= 58 + 4 && y >= 8.94 - 4 && y <= 60.94 + 4) { _backDown = true; return; }
            foreach (var b in _btns) if (b.Hit(x, y) && b.On) { _pressed = b; b.Press(true); return; }
            // the board's area: where the finger went down
            float ax = x - LeftW;
            if (ax >= 0 && ax < AreaW) _touch = new Touch { X0 = ax, Y0 = y, Sx = x, Sy = y };
        }

        /// <summary>The finger moved to (x, y): a hop each half a tile of drag.</summary>
        public void Move(float x, float y)
        {
            var T = _touch;
            if (T == null || _cardDown || _pressed != null || _backDown) return;
            double gdx = x - T.Sx, gdy = y - T.Sy;
            double dx = gdx - T.Gx, dy = gdy - T.Gy;
            if (Math.Max(Math.Abs(dx), Math.Abs(dy)) < Math.Max(24, B.T * 0.45)) return;
            T.Moved = true;
            T.Gx = gdx;
            T.Gy = gdy;
            int d = Math.Abs(dx) > Math.Abs(dy) ? (dx > 0 ? 1 : 3) : dy > 0 ? 2 : 0;
            Input(() => TryDir(d));
        }

        /// <summary>The finger up at (x, y).</summary>
        public void Up(float x, float y)
        {
            if (_cardDown)
            {
                _cardDown = false;
                if (BlitzCardsUp(x, y)) return;
                for (int i = _cards.Count - 1; i >= 0; i--) if (_cards[i].card.Up(x, y)) break;
                return;
            }
            if (_backDown)
            {
                _backDown = false;
                if (x >= 6 && x <= 62 && y >= 4.94 && y <= 64.94) { if (_phase == "play") Pause(); else if (!(_blitz && _phase != "won" && _blitzCard == null)) Leave(); }
                return;
            }
            if (_pressed != null)
            {
                var b = _pressed;
                _pressed = null;
                b.Press(false);
                if (b.Hit(x, y)) b.Action();
                return;
            }
            var T = _touch;
            _touch = null;
            if (T == null) return;
            double gdx = x - T.Sx, gdy = y - T.Sy;
            // a quick flick can end before any move event got a hop's worth away: if it went most of the way, it's a hop
            if (!T.Moved && Math.Max(Math.Abs(gdx), Math.Abs(gdy)) >= Math.Max(24, B.T * 0.45) * 0.6)
            {
                int dd = Math.Abs(gdx) > Math.Abs(gdy) ? (gdx > 0 ? 1 : 3) : gdy > 0 ? 2 : 0;
                Input(() => TryDir(dd));
                return;
            }
            if (T.Moved || Math.Sqrt(gdx * gdx + gdy * gdy) > 12) return;
            int cur = G.St.Cur;
            int j = BoardGeometry.CellAt(B, T.X0, T.Y0);
            if (j == cur)
            {
                Snd.Play("sd_squeak");
                Wobble(new[] { -0.6, 0.6, 0 }, 360);
                return;
            }
            if (j < 0) return;
            int px = cur % _board.W, py = cur / _board.W, jx = j % _board.W, jy = j / _board.W;
            if (Math.Abs(jx - px) + Math.Abs(jy - py) != 1) return;
            int d = jy < py ? 0 : jx > px ? 1 : jy > py ? 2 : 3;
            Input(() => TryDir(d));
        }

        /// <summary>A tap on board cell `i` (tests).</summary>
        public void TapCell(int i)
        {
            var q = BoardGeometry.Project(B, i % _board.W + 0.5, i / _board.W + 0.5);
            Down((float)(q.X + LeftW), (float)q.Y);
            Up((float)(q.X + LeftW), (float)q.Y);
        }

        /// <summary>Goes to level `lv` as the game's own setLv does (tests: the app's level switched in its state).</summary>
        public void Switch(int lv) { _fresh = true; SetLevel(Levels.ClampLv(lv)); }

        /// <summary>Opens a card as the game would (tests): "result" (Preview.js's sample), "stuck", "pause", "hint".</summary>
        public void ShowCard(string which)
        {
            switch (which)
            {
                case "pause": Pause(); break;
                case "hint": AskHint(); break;
                case "stuck": _phase = "stuck"; G.Over = true; SetStuck(true); break;
            }
        }

        // ---- a button (squishdoku/ui.js SdButton): the lip stays, the face moves down 4 dp while pressed and the whole
        // button shrinks to 0.93 (timing 70 ms in, spring friction 3.5 tension 260 out)
        sealed class Btn
        {
            readonly string _name;
            readonly HopLayer _lip, _face;
            readonly float _x, _y;
            public readonly Action Action;
            readonly AnimatedValue _t = new AnimatedValue(0);
            public bool On { get; private set; }
            bool _built;
            const float BW = 122, BH = 55, Lip = 5;

            public Btn(HopLevel g, string name, float x, float y, int order, Action action)
            {
                _name = name; _x = x; _y = y; Action = action;
                _lip = g.Add(name + " lip", order);
                _face = g.Add(name + " face", order + 1);
                SetOn(false, true);
            }

            public void SetOn(bool on, bool force = false)
            {
                if (on == On && _built && !force) return;
                On = on; _built = true;
                var key = $"btn-{_name}-{(on ? "on" : "off")}";
                _lip.Svg(LoadXml(key + "-lip"), BW, 50);
                _face.Svg(LoadXml(key + "-face"), BW, 50);
            }

            public bool Hit(float x, float y) => x >= _x - 6 && x <= _x + BW + 6 && y >= _y - 6 && y <= _y + BH + 6;   // hitSlop 6

            public void Press(bool down)
            {
                if (down) Animated.Timing(_t, new TimingConfig { ToValue = 1, Duration = 70, UseNativeDriver = true }).Start();
                else Animated.Spring(_t, new SpringConfig { ToValue = 0, Friction = 3.5, Tension = 260, UseNativeDriver = true }).Start();
            }

            public void Draw()
            {
                double t = _t.GetValue();
                double s = 1 + (0.93 - 1) * t, ty = (Lip - 1) * t;
                var whole = Affine.Translate(_x, _y) * About(BW, BH, Affine.ScaleBy(s, s));
                _lip.Transform = whole * Affine.Translate(0, Lip);
                _face.Transform = whole * Affine.Translate(0, ty);
            }
        }
    }
}
