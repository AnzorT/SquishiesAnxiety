// The squad in the house (HOUSE_PORT_PLAN.md stage 3), as Squad House v6.dc.html runs it: init's creatures (picked by
// HouseSave), enterRoom's placing (the one carried through a door at its spawn walking in, the others where they were or
// at a free spot), wander / goTo / freeSpot / blocked / clampF, the selection, and the walking part of tick: moving at
// 86 * 1.25 * sAt(y) px/s (x the gait's speed, x 1.7 running), turning toward where they go (HouseWalk's max facing
// angle), the walk weight easing in and out, the gait (HouseWalk) on the rig's ext channels, the needs decaying and the
// "Hungry..." line, speech bubbles (1.6 s) and the particles (emit / spawn). Plain C#: `Rand` is the page's
// Math.random (tools/unity/house's split streams can replay it), times are ms.
// Later stages: actions, seats, using items (4), items' own animations (5), the beach's sand and sea (10).
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed partial class HouseCreature
    {
        public string Key, Name, Room, Home, PosRoom, Mode = "free";
        public int I, Id;
        public Dictionary<string, double> N;
        public double X = 400, Y = 240, Tx = 400, Ty = 240, Spin, Face, Wk, Ph, Lift, LiftTo, WanderAt, Hold, Gv = 1, NeedAt, Ox, Oy, Rot, StandUntil, TurnAt;
        public double? Z;
        public bool Moving, Run;
        public Action Arrive;
        public readonly Dictionary<string, double> Ext = new Dictionary<string, double>();
        public readonly HouseWalk.State Gs = new HouseWalk.State();
        // speech (say): the text and when it was said; shown 1.6 s
        public string SayText;
        public double SayAt = -1e9;
        // what he's doing (stage 4: HouseActions)
        public string Seat, SeatItem, UseItem, SeatRes, UseRes, WSt, NapSt, SnugSt, WatchTv;
        public HouseAct UseA;
        public string RnGo, Pa, PAnim;   // (stage 5: walking to a piece; playing at it: his spot's move, his animation)
        public double Pd, JamAt;
        public bool PRig;
        public double UseEnd, EatEnd, BowlEnd, RoastAt, FxAt;
        public HouseCreature SnugW, SnugTo;
        /// <summary>The pose he holds while getting off something (keep: lift, facing, z, the seat) until a time.</summary>
        public sealed class KeepPose { public double Lift, Face, Until; public double? Z; public string Seat; }
        public KeepPose Keep;
        public EditHold ReHold;   // (stage 6: held off a piece being edited)
        // watching a movie (stage 9: mvStep): a reaction under way, dozing off, the next munch
        public sealed class MvReact { public string K; public double T0, D; }
        public MvReact MvR; public bool MvDz; public double MvMn;
    }

    public sealed class HouseParticle { public string Type, Glyph, Color; public double X, Y, Born, Sx, Size, Ms; }

    public sealed partial class HouseCreatures
    {
        public static readonly string[] HOME = { "living", "living", "kitchen", "bedroom", "backyard", "dance" };
        static readonly Dictionary<string, double>[] SEEDN =
        {
            new Dictionary<string, double> { { "h", 30 }, { "c", 70 }, { "e", 80 }, { "f", 60 } }, new Dictionary<string, double> { { "h", 85 }, { "c", 32 }, { "e", 60 }, { "f", 70 } },
            new Dictionary<string, double> { { "h", 70 }, { "c", 80 }, { "e", 28 }, { "f", 50 } }, new Dictionary<string, double> { { "h", 60 }, { "c", 55 }, { "e", 75 }, { "f", 24 } },
            new Dictionary<string, double> { { "h", 38 }, { "c", 90 }, { "e", 65 }, { "f", 35 } }, new Dictionary<string, double> { { "h", 80 }, { "c", 30 }, { "e", 36 }, { "f", 75 } },
        };
        public static readonly Dictionary<string, string> NEEDLOW = new Dictionary<string, string> { { "h", "Hungry..." }, { "c", "Itchy..." }, { "e", "Sleepy..." }, { "f", "Bored..." } };
        static readonly Dictionary<string, double> DECAY = new Dictionary<string, double> { { "h", 0.045 }, { "c", 0.03 }, { "e", 0.035 }, { "f", 0.05 } };
        public static readonly string[] NEONC = { "#ff4fd8", "#4fe0d0", "#ffd84a", "#7c5cff", "#ff8a3d", "#5cff8a" };
        /// <summary>X.CRDEF (house4-cat4.js): the creatures' scale in the house; tagT its name tag's top.</summary>
        public const double CRDEF = 1.09;
        public static readonly double TagT = JsRound(80 - 100 * CRDEF);
        public const double SayMs = 1600;

        public readonly HouseSave S;
        readonly HouseWalk _walk;
        public readonly List<HouseCreature> Cs = new List<HouseCreature>();
        public List<HouseCreature> Vis = new List<HouseCreature>();
        public readonly List<HouseParticle> Particles = new List<HouseParticle>();
        public int? Sel;
        public bool Edit;
        public double Speed = 1, NeedRate = 1;
        public Func<double> Rand = () => Shared.NextDouble();
        /// <summary>fidg(c): whether his rig is in one of its idle fidgets (it holds off wandering; goTo stops it with
        /// PlayIdle). The rig's answer (LiveRig); false without one.</summary>
        public Func<HouseCreature, bool> Fidg = c => false;
        public Action<HouseCreature> PlayIdle;
        static readonly Random Shared = new Random();
        public double Last;

        static double JsRound(double x) => Math.Floor(x + 0.5);

        public HouseCreatures(HouseSave s, HouseWalk walk) { S = s; _walk = walk; }

        /// <summary>init: the picked creatures, in their saved rooms (or their homes), with their needs; then the room.</summary>
        public void Init(double now, string startRoom = null)
        {
            var H = S.H; var cr = H.Obj("cr"); var needs = H.Obj("needs");
            Cs.Clear();
            for (int i = 0; i < S.Cs.Count; i++)
            {
                var e = S.Cs[i];
                var c = new HouseCreature { Key = e.Key, Name = e.Name, Id = e.Id, I = i, Ph = Rand() * 6, NeedAt = now + 6000 + i * 4000 };
                var saved = cr?[e.Key];
                c.Room = HouseJson.Truthy(saved) && S.IsOpen(HouseJson.JsString(saved)) ? HouseJson.JsString(saved) : HomeFor(i);
                c.Home = HomeFor(i);   // (H.home is never loaded: initH doesn't carry it over)
                c.N = new Dictionary<string, double>(SEEDN[i % SEEDN.Length]);
                if (needs?.Obj(e.Key) is JObj n) foreach (var k in n.Keys) if (n[k] is double v) c.N[k] = v;
                Cs.Add(c);
            }
            Last = now;
            Enter(startRoom != null && S.IsOpen(startRoom) ? startRoom : S.Cur, null, null, now);
        }

        string HomeFor(int i) { var h = HOME[i % HOME.Length]; return S.IsOpen(h) ? h : "living"; }

        public HouseCreature SelC => Sel != null && Sel.Value < Vis.Count ? Vis[Sel.Value] : null;

        /// <summary>enterRoom: the save's part (HouseSave.EnterRoom) and the squad's: who's in the room and where.</summary>
        public void Enter(string room, HouseCreature carry, string from, double now)
        {
            foreach (var c0 in Vis) BReset(c0);
            string prevR = S.Cur;
            foreach (var c in Vis) { Leave(c, true, now); c.Moving = false; c.Arrive = null; }
            Party = false; Vars.Clear(); Tv.Clear(); TvAuto.Clear();
            if (room != "beach") { foreach (var c in Cs) if (c.Room == "beach" && c != carry) { c.Room = c.Home != null && c.Home != "beach" && S.IsOpen(c.Home) ? c.Home : HomeFor(c.I); c.PosRoom = null; } }
            else
            {
                if (carry != null && carry.Room != "beach") carry.Home = carry.Room;
                if (carry == null && prevR != "beach" && !Cs.Exists(c => c.Room == "beach")) foreach (var c in Cs) if (c.Room == prevR) { c.Home = c.Room; c.Room = "beach"; c.PosRoom = null; }
            }
            S.EnterRoomSaveOnly(room);
            room = S.Cur;
            if (carry != null) carry.Room = room;
            Vis = Cs.FindAll(c => c.Room == room);
            JObj dIn = null;
            if (from != null) foreach (var d in Shell(room)?.Arr("doors") ?? new List<object>()) if (d is JObj j && j.Str("to") == from) { dIn = j; break; }
            for (int i = 0; i < Vis.Count; i++)
            {
                var c = Vis[i];
                c.Spin = 0; c.Face = 0; c.Wk = 0; c.Lift = 0; c.LiftTo = 0; c.Z = null; c.Mode = "free"; c.Hold = 0;
                if (c == carry)
                {
                    var sp = dIn != null ? Pt(dIn.Arr("spawn")) : (426, 210); var wk = dIn != null ? Pt(dIn.Arr("walk")) : (426, 250);
                    c.X = sp.Item1; c.Y = sp.Item2; c.PosRoom = room;
                    c.Spin = dIn != null ? Math.Atan2(wk.Item1 - sp.Item1, (wk.Item2 - sp.Item2) * 1.4) * 180 / Math.PI : 0;
                    GoTo(c, wk.Item1, wk.Item2, null, now); c.WanderAt = now + 6000;
                }
                else
                {
                    if (c.PosRoom != room) { var p = FreeSpot(room); c.X = p.x; c.Y = p.y; c.PosRoom = room; }
                    c.Tx = c.X; c.Ty = c.Y; c.WanderAt = now + 1500 + i * 1600;
                }
            }
            int si = carry != null ? Vis.IndexOf(carry) : -1;
            Sel = si >= 0 ? si : (int?)null;
        }

        static (double, double) Pt(List<object> a) => ((double)a[0], (double)a[1]);

        JObj Shell(string rk) => new RoomModel(S).ShellOf(rk);

        List<JObj> RoomItems(string rk = null)
        {
            var l = new List<JObj>();
            foreach (var o in S.H.Obj("rooms")?[rk ?? S.Cur] as List<object> ?? new List<object>()) if (o is JObj j) l.Add(j);
            return l;
        }

        public bool Blocked(double x, double y, string rk = null)
        {
            var G = S.Geo;
            foreach (var it in RoomItems(rk))
            {
                var D = S.D.CatOf(it.Str("t"));
                if (D == null || D.Truthy("flat") || D.Truthy("noBlock")) continue;
                var z = S.SzXY(it); double s = G.SAt(it.Num("y")) * z[0], sy = G.SAt(it.Num("y")) * z[1];
                var h = G.Half(D.Num("w"), D.Num("d"), it.Num("r"));
                if (Math.Abs(x - it.Num("x")) < h.hx * s + 12 && Math.Abs(y - it.Num("y")) < h.hz * G.SA * sy + 8) return true;
            }
            return false;
        }

        public (double x, double y) FreeSpot(string rk)
        {
            var G = S.Geo;
            if (rk == "beach") { for (int t = 0; t < 30; t++) { var p = RandSand(); if (!Blocked(p[0], p[1], rk)) return (p[0], p[1]); } return (200, 300); }
            for (int t = 0; t < 40; t++)
            {
                double y = 190 + Rand() * (G.FY1 - 190), a = G.Edge(y) + 60, b = G.VW - G.Edge(y) - 60, x = a + Rand() * (b - a);
                if (!Blocked(x, y, rk)) return (x, y);
            }
            return (426, 300);
        }

        public (double x, double y) ClampF(double x, double y, double? m = null, bool sea = false)
        {
            var G = S.Geo;
            if (OnBeach) return Beach.Clamp(G, x, y, m, sea);
            y = Math.Max(G.FY0, Math.Min(G.FY1, y));
            double e = G.Edge(y) + (m ?? 34);
            return (Math.Max(e, Math.Min(G.VW - e, x)), y);
        }

        public void GoTo(HouseCreature c, double x, double y, Action cb, double now, bool run = false, bool sea = false)
        {
            if (Fidg(c)) PlayIdle?.Invoke(c);
            Leave(c, false, now);
            var (tx, ty) = ClampF(x, y, null, sea);
            c.Tx = tx; c.Ty = ty; c.Moving = true; c.Arrive = cb; c.Mode = cb != null ? "busy" : "free"; c.Hold = now + 12000; c.Run = run;
        }

        public void Wander(HouseCreature c, double now)
        {
            var G = S.Geo;
            if (OnBeach)
            {
                bool inS = Beach.WetAt(c.X, c.Y);
                for (int t = 0; t < 10; t++) { bool sw = Rand() < (inS ? 0.45 : 0.14); var p = sw ? RandSea() : RandSand(); if (!Blocked(p[0], p[1]) && Math.Sqrt((p[0] - c.X) * (p[0] - c.X) + (p[1] - c.Y) * (p[1] - c.Y)) > 50) { GoTo(c, p[0], p[1], null, now, false, sw); c.Hold = 0; return; } }
                c.WanderAt = now + 3000; return;
            }
            for (int t = 0; t < 12; t++)
            {
                double y = G.FY0 + 20 + Rand() * (G.FY1 - G.FY0 - 20), a = G.Edge(y) + 44, b = G.VW - G.Edge(y) - 44, x = a + Rand() * (b - a);
                if (!Blocked(x, y) && Math.Sqrt((x - c.X) * (x - c.X) + (y - c.Y) * (y - c.Y)) > 60) { GoTo(c, x, y, null, now); c.Hold = 0; return; }
            }
            c.WanderAt = now + 3000;
        }

        /// <summary>say: the bubble over him for 1.6 s.</summary>
        public void Say(HouseCreature c, string txt, double now) { c.SayText = txt; c.SayAt = now; }

        /// <summary>A tap on a creature (its up handler): select it, or let go; a wanderer stops where it is.</summary>
        public void TapCreature(int i, double now)
        {
            if (Edit || i >= Vis.Count) return;
            var c = Vis[i];
            if (Sel != i && c.Mode == "free" && c.Moving && c.Arrive == null) { c.Tx = c.X; c.Ty = c.Y; c.Moving = false; c.WanderAt = now + 4000; }
            Sel = Sel == i ? (int?)null : i;
        }

        /// <summary>floorDown: the selected friend walks there (returns false when none is selected: the page's toast).</summary>
        public bool FloorDown(double x, double y, double now)
        {
            var c = SelC; if (c == null) return false;
            var p = ClampF(x, y);
            GoTo(c, p.x, p.y, null, now);
            return true;
        }

        // ---- particles (emit / spawn) ----
        void Emit(HouseCreature c, string fx, double now)
        {
            double s = S.Geo.SAt(c.Y), top = c.Y - c.Lift + c.Oy;
            double Rx() => Rand() - 0.5;
            var it = c.UseItem != null ? FindItem(c.UseItem) : null;
            // itemTop(it, h): the top of the piece he's using, h px up
            (double x, double y) Top(double h) => (it.Num("x"), it.Num("y") - h * S.Geo.CA * S.Geo.SAt(it.Num("y")));
            if (fx == "steam" && it != null) { var p = Top(92); Spawn(fx, p.x - 18 * S.Geo.SAt(it.Num("y")) + Rx() * 10, p.y, now); return; }
            if (fx == "bubble" && (c.Mode == "wash" || c.Mode == "dishes") && it != null) { var p = Top(62); Spawn(fx, p.x + Rx() * 30, p.y, now); return; }
            if (fx == "spark" && (c.Mode == "play" || c.Mode == "rplay") && it != null) { var p = Top(64); Spawn(fx, p.x + Rx() * 40, p.y, now); return; }
            if (fx == "bubble") Spawn(fx, c.X + Rx() * 70 * s, top - 30 * s, now);
            else if (fx == "note") Spawn(fx, c.X + Rx() * 70 * s, top - 92 * s, now);
            else if (fx == "drop") Spawn(fx, c.X + Rx() * 60 * s, top - 20 * s, now);
            else if (fx == "sand") Spawn(fx, c.X + Rx() * 40 * s, top - 4, now);
            else Spawn(fx, c.X + Rx() * 70 * s, top - 70 * s, now);
        }

        void Spawn(string type, double x, double y, double now)
        {
            var p = new HouseParticle { Type = type, X = x, Y = y, Born = now, Sx = (Rand() - 0.5) * 36, Ms = 1100 };
            if (type == "bubble") { p.Size = 7 + Rand() * 10; p.Ms = 1600; }
            else if (type == "steam") p.Ms = 1700;
            else if (type == "note") { p.Glyph = Rand() < 0.5 ? "♪" : "♫"; p.Color = NEONC[(int)(Rand() * 6)]; p.Ms = 1700; }
            else if (type == "drop") p.Ms = 800;
            else if (type == "sand") p.Ms = 700;
            Particles.Add(p);
        }

        /// <summary>The walking part of tick (ms). Returns nothing; read the creatures (Transform) and Particles.</summary>
        double _mvLast;
        public void Tick(double now)
        {
            double dt = Math.Min(0.1, Math.Max(0, (now - Last) / 1000)); Last = now;
            var G = S.Geo; double spd = Speed;
            RunLater(now);
            _mvNow = now;
            MovieTick(now, (now - _mvLast) / 1000); _mvLast = now;   // (the show's own clock: movie-night.js frame())
            foreach (var c in Vis)
            {
                double tgt = c.Face;
                bool standing = now < c.StandUntil;
                var kp = c.Keep != null && now < c.Keep.Until ? c.Keep : (c.Keep = null);
                if (kp != null) tgt = kp.Face;
                if (c.Moving && !standing)
                {
                    double dx = c.Tx - c.X, dy = c.Ty - c.Y, d = Math.Sqrt(dx * dx + dy * dy), sp = 86 * 1.25 * spd * G.SAt(c.Y) * c.Gv * (c.Run ? 1.7 : 1);
                    if (d <= sp * dt || d < 0.5) { c.X = c.Tx; c.Y = c.Ty; c.Moving = false; var f = c.Arrive; c.Arrive = null; c.WanderAt = now + 4000 + Rand() * 7000; f?.Invoke(); }
                    else
                    {
                        c.X += dx / d * sp * dt; c.Y += dy / d * sp * dt; tgt = Math.Atan2(dx, dy * 1.4) * 180 / Math.PI;
                        var sm = _walk.Prof(c.Key).Sm;
                        if (sm != null && sm.Value != 0) { double a = Math.Abs(tgt), sg = tgt < 0 ? -1 : 1; tgt = sg * (a <= 90 ? Math.Min(a, sm.Value) : Math.Max(a, 180 - sm.Value)); }
                    }
                }
                else if (c.Mode == "free" && now > c.WanderAt && now > c.Hold && !Edit && SelC != c && !Fidg(c)) Wander(c, now);
                double dd = ((tgt - c.Spin) % 360 + 540) % 360 - 180; c.Spin += dd * Math.Min(1, dt * 7);
                c.Wk += ((c.Moving && !standing ? 1 : 0) - c.Wk) * Math.Min(1, dt * 8);
                if (c.Moving && !standing) c.Ph += dt * 11 * spd;
                c.Lift += ((kp != null ? kp.Lift : c.LiftTo) - c.Lift) * Math.Min(1, dt * 9);
                double w = c.Wk;
                foreach (var k in new List<string>(c.Ext.Keys)) c.Ext[k] = 0;
                c.Gs.Run = c.Run && c.Moving;
                var g = _walk.Step(c.Key, c.Gs, c.Ext, w, dt, c.Moving && !standing ? spd : 0, c.Spin);
                c.Ext["spin"] = c.Spin; c.Gv = 1 + (g.V - 1) * w;
                if (g.Fx != null) Emit(c, g.Fx, now);
                c.Ox = 0; c.Oy = 0; c.Rot = 0;
                if (c.TurnAt != 0 && now >= c.TurnAt) { c.TurnAt = 0; c.Face = 0; }
                ActTick(c, now, dt, standing);
                if (c.Mode == "free" && !c.Moving && now > c.NeedAt)
                {
                    c.NeedAt = now + 14000 + Rand() * 9000;
                    string low = "h"; foreach (var k in new[] { "h", "c", "e", "f" }) if (c.N.TryGetValue(k, out var v) && v < c.N[low]) low = k;
                    if (c.N[low] < 30) Say(c, NEEDLOW[low], now);
                }
            }
            if (OnBeach) BTick(now);
            PieceTick(now);   // (the page: rnTick every 0.5 s and the rolling toy, after the squad)
            if (Party && now > PartyEnd) EndParty(now);
            double rate = NeedRate * dt;
            foreach (var c in Cs) foreach (var k in new[] { "h", "c", "e", "f" }) c.N[k] = Math.Max(0, (c.N.TryGetValue(k, out var v) ? v : 0) - DECAY[k] * rate);
            Particles.RemoveAll(p => now - p.Born >= p.Ms);
        }

        /// <summary>His box (120 x 120 room px) as the page places it: translate, rotate, scale about (60, 108); z-index.</summary>
        public (double tx, double ty, double rot, double s, int z) Transform(HouseCreature c)
        {
            double? cz = c.Keep != null && c.Keep.Z != null ? c.Keep.Z : c.Z;
            return (c.X - 60 + c.Ox, c.Y - 108 - c.Lift + c.Oy, c.Rot, S.Geo.SAt(c.Y), (int)JsRound(cz ?? c.Y) + 1);
        }

        /// <summary>Before saving: each one's room, home and needs into the save's creatures (HouseSave.Snapshot writes
        /// them as the page's save() does).</summary>
        public void SyncSave()
        {
            foreach (var c in Cs)
            {
                var e = S.Cs.Find(x => x.Key == c.Key); if (e == null) continue;
                e.Room = c.Room; e.Home = c.Home;
                e.N = new[] { c.N["h"], c.N["c"], c.N["e"], c.N["f"] };
            }
        }
    }
}
