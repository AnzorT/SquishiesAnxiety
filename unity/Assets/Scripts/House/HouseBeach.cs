// The Beach (HOUSE_PORT_PLAN.md stage 10): beach.js's walk geometry (the shore, the pier, the sea, clamp, randSand,
// randSea, itemX) and the page's beach methods (bStep: wading, swimming, surfing, fishing, roasting; bTick: the sea
// pieces bobbing, shells washing up; bAct: swim / shells / fish; bSurf; bPick; bReset). The scene itself, the props and
// the creatures' gear are drawn by View/HouseBeachView.cs. Plain C#.
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed partial class HouseCreature
    {
        // the beach (bStep): wading (Wet, its depth Wd), swimming (Rsw), surfing (Surf), the gear shown (board / rod),
        // the next splash, the fishing spot taken and when the fish bites
        public bool Wet, Rsw; public double Wd, Bfx, FishEnd; public string Gear; public int? Fish;
        public sealed class SurfRun { public double T0, Y0, Xs, L; }
        public SurfRun Surf;
    }

    public sealed partial class HouseCreatures
    {
        // ---------- beach.js geometry (room px: x 0..852, floor y 100..393) ----------
        public static class Beach
        {
            public const double SO = 540, BY0 = 104, BM = 22, VW = 852;
            public static readonly double PY0 = 226, PY1 = 248, Py0 = 212, Py1 = 258, XE = 742, XP1 = 828;
            public static double PX0 => Math.Round(Shore(237) - 58);
            public static readonly (double x, double y, double face)[] FISH = { (806, 232, 90), (770, 250, 20) };
            public static string Season = "sunny";
            public static double Shore(double y) => y >= 100 ? SO + 0.95 * (y - 100) - 0.0009 * (y - 100) * (y - 100) : SO - (100 - y) * 2.4;
            public static double Ice() => Season == "snowy" ? 62 : 0;
            public static bool OnPier(double x, double y) => (x >= PX0 + 4 && x <= XE + 2 && y >= PY0 + 2 && y <= PY1 - 2) || (x > XE - 6 && x <= XP1 - 6 && y >= Py0 + 4 && y <= Py1 - 4);
            public static bool InSea(double x, double y) => x > Shore(y) + Ice();
            public static bool WetAt(double x, double y) => InSea(x, y) && !OnPier(x, y);
            public static bool NearPier(double x, double y) => (x >= PX0 && x <= XE && y >= PY0 - 8 && y <= PY1 + 8) || (x > XE - 6 && x <= XP1 + 10 && y >= Py0 - 8 && y <= Py1 + 8);
            public static (double x, double y) Clamp(HouseGeo G, double x, double y, double? m, bool sea)
            {
                y = Math.Max(BY0, Math.Min(G.FY1, y)); double L = G.Edge(y) + (m == null ? BM : Math.Min(m.Value, BM));
                if (NearPier(x, y) && x > Shore(y) - 24)
                {
                    if (x > XE - 6) return (Math.Min(XP1 - 10, x), Math.Max(Py0 + 6, Math.Min(Py1 - 6, y)));
                    return (Math.Max(PX0 + 8, x), Math.Max(PY0 + 4, Math.Min(PY1 - 4, y)));
                }
                if (sea)
                {
                    double xs = Math.Min(834, x);
                    if (xs > Shore(y) + Ice() + 10) { double yy = y; if (xs > PX0 && yy > Py0 - 16 && yy < Py1 + 12) yy = yy < (Py0 + Py1) / 2 ? Py0 - 16 : Py1 + 12; return (xs, Math.Max(BY0, Math.Min(G.FY1, yy))); }
                }
                return (Math.Max(L, Math.Min(Shore(y) + Ice() - 18, x)), y);
            }
            public static double[] RandSand(HouseGeo G, Func<double> R) { double y = 118 + R() * (G.FY1 - 118), a = G.Edge(y) + 40, b = Shore(y) + Ice() - 40; return new[] { a + R() * Math.Max(10, b - a), y }; }
            public static double[] RandSea(HouseGeo G, Func<double> R)
            {
                for (int i = 0; i < 20; i++) { double y = 140 + R() * (G.FY1 - 140); if (y > Py0 - 16 && y < Py1 + 12) continue; double a = Shore(y) + Ice() + 34, b = 826; if (b - a < 20) continue; return new[] { a + R() * (b - a), y }; }
                return new[] { 760.0, 300 };
            }
            public static double ItemX(double x, double y, double hx, bool sea) { double s = Shore(y) + Ice(); return sea ? Math.Max(s + hx + 8, Math.Min(VW - 14, x)) : Math.Min(s - hx * 0.6 - 6, x); }
        }

        bool OnBeach => S.Cur == "beach";
        /// <summary>beach.js's own random draws (the page's checks replay its stream apart); null: Rand.</summary>
        public Func<double> RandB;
        public double[] RandSand() => Beach.RandSand(S.Geo, RandB ?? Rand);
        public double[] RandSea() => Beach.RandSea(S.Geo, RandB ?? Rand);
        /// <summary>Hooks the edit mode's placement to the beach (Renovate on the sand and in the sea).</summary>
        public void BeachHooks() { BeachItemX = Beach.ItemX; BeachRand = sea => sea ? RandSea() : RandSand(); }

        /// <summary>The page's bBob: each sea piece's bob this frame (px), by id; the view moves those pieces.</summary>
        public readonly Dictionary<string, double> BBob = new Dictionary<string, double>();
        /// <summary>The shells on the sand (H.bsh: id, x, y, kind), changed: the view redraws them.</summary>
        public int ShellsVer;
        public double BshAt;

        /// <summary>bReset: dry, no gear, no surf (on entering a room).</summary>
        public void BReset(HouseCreature c) { c.Rsw = false; c.Wet = false; c.Wd = 0; c.Surf = null; c.Gear = null; }

        /// <summary>bStep: the sea under him (wading, swimming), surfing, fishing, roasting.</summary>
        void BStep(HouseCreature c, double now, double dt)
        {
            if (c.Mode == "surf" && c.Surf != null)
            {
                var S0 = c.Surf; double u = (now - S0.T0) / 9000;
                if (u >= 1) { c.LiftTo = 0; Say(c, "Totally tubular!", now); var q = RandSand(); double ty = S0.Y0; GoTo(c, Math.Min(q[0], Beach.Shore(ty) - 40), ty, null, now); c.Surf = null; c.Gear = null; Play(c, "happy"); }
                else
                {
                    double e = (1 - Math.Cos(u * Math.PI * 2)) / 2; c.X = S0.Xs + e * S0.L; c.Y = S0.Y0 + Math.Sin(u * Math.PI * 4) * 22; c.Face = u < 0.5 ? 90 : -90; c.LiftTo = 4; c.Oy += Math.Sin(now * 0.006) * 3; c.Rot = Math.Sin(now * 0.004) * 7;
                    c.N["f"] = Math.Min(100, c.N["f"] + 7 * dt); c.N["c"] = Math.Min(100, c.N["c"] + 4 * dt); if (now > c.Bfx) { c.Bfx = now + 260; Emit(c, "drop", now); }
                }
                c.Wet = false; return;
            }
            bool w = c.SeatItem == null && Beach.WetAt(c.X, c.Y);
            double dep = w ? Math.Max(0, Math.Min(1, (c.X - Beach.Shore(c.Y) - Beach.Ice()) / 70)) : 0;
            bool deep = w && dep > 0.4 && HsGet(c, "swimin") != null;
            if (deep && !c.Rsw) { c.Rsw = true; c.Wet = false; Play(c, "swimin"); }
            else if (c.Rsw && !(w && dep > 0.28)) { c.Rsw = false; var so = HsGet(c, "swimout"); Play(c, "swimout"); c.StandUntil = now + (so != null ? so.Num("dur") - 250 : 600); }
            if (!c.Rsw && (w != c.Wet || (w && Math.Abs(dep - c.Wd) > 0.08))) { c.Wet = w; c.Wd = dep; }
            if (w) { c.Oy += Math.Sin(now * 0.0032 + c.I * 1.3) * 2.2 * dep; c.N["c"] = Math.Min(100, c.N["c"] + 7 * dt); c.N["f"] = Math.Min(100, c.N["f"] + 3 * dt); if (!c.Moving && now > c.Bfx) { c.Bfx = now + 800 + Rand() * 600; Emit(c, "drop", now); } }
            if (c.SeatItem == null && c.UseItem == null) c.LiftTo = Beach.OnPier(c.X, c.Y) ? 4 : 0;
            if (c.SeatItem != null && BBob.TryGetValue(c.SeatItem, out var bb)) c.Oy += bb;
            if (c.Mode == "roast" && c.RoastAt != 0 && now > c.RoastAt) { c.RoastAt = 0; c.Mode = "eat"; c.EatEnd = now + 4500; c.N["h"] = Math.Min(100, c.N["h"] + 10); Play(c, EatS()); Say(c, "Toasty!", now); }
            if (c.Mode == "fish" && now > c.FishEnd)
            {
                c.Gear = null; c.Fish = null; c.Mode = "eat"; c.EatEnd = now + 4000; c.N["h"] = Math.Min(100, c.N["h"] + 20); c.N["f"] = Math.Min(100, c.N["f"] + 12); Play(c, EatS());
                Say(c, new[] { "A fish!", "Got one!", "A big one!", "Lunch!" }[(int)Math.Floor(Rand() * 4)], now); Toast(c.Name + " caught a fish!");
            }
        }

        /// <summary>bTick: the sea pieces bob; five shells to start with, another every 25 s (up to 6).</summary>
        void BTick(double now)
        {
            BBob.Clear();
            foreach (var it in RoomItems()) { var D = Cat(it); if (D == null || !D.Truthy("sea")) continue; BBob[it.Str("id")] = Math.Sin(now * 0.0026 + it.Num("x") * 0.13 + it.Num("y") * 0.07) * 2.4; }
            if (!(S.H["bsh"] is List<object>)) { S.H["bsh"] = new List<object>(); for (int i = 0; i < 5; i++) BShell(); ShellsVer++; }
            if (now > BshAt) { bool first = BshAt == 0; BshAt = now + 25000; if (!first && Shells.Count < 6) { BShell(); ShellsVer++; } }
        }
        public List<object> Shells => S.H["bsh"] as List<object> ?? new List<object>();
        void BShell()
        {
            var G = S.Geo;
            for (int t = 0; t < 20; t++)
            {
                double y = 150 + Rand() * 180, x = Beach.Shore(y) + Beach.Ice() - 30 - Rand() * 150;
                if (Beach.NearPier(x, y) || x < G.Edge(y) + 40) continue;
                double uid = S.H.Num("uid"); S.H["uid"] = uid + 1;
                Shells.Add(new JObj { ["id"] = "sh" + HouseJson.JsString(uid), ["x"] = Math.Round(x), ["y"] = Math.Round(y), ["k"] = Math.Floor(Rand() * 5) });
                return;
            }
        }
        /// <summary>bPick: the selected friend walks to the shell and picks it up.</summary>
        public void BPick(JObj s, double now)
        {
            var c = SelC; if (c == null) { Toast("Tap a friend first, then a shell"); return; }
            GoTo(c, s.Num("x") - 12, s.Num("y") + 6, () =>
            {
                double t = Last; int i = Shells.IndexOf(s); c.Mode = "free"; if (i < 0) { Say(c, "Gone...", t); return; }
                Shells.RemoveAt(i); S.H["shells"] = S.H.Num("shells") + 1; c.Face = 30; c.N["f"] = Math.Min(100, c.N["f"] + 10);
                var sp = HsGet(c, "shellpick"); Play(c, sp != null ? "shellpick" : "happy"); if (sp != null) c.StandUntil = t + sp.Num("dur") - 200;
                Say(c, "A shell!", t); Toast("Found a shell! " + HouseJson.JsString(S.H.Num("shells")) + " collected"); ShellsVer++; Saved?.Invoke();
            }, now);
        }
        /// <summary>bAct: swim (a spot in the sea), shells (the nearest), fish (a free spot on the pier).</summary>
        void BAct(string id, HouseCreature c, double now)
        {
            if (!OnBeach) { Toast("That one is at the Beach"); return; }
            if (id == "swim") { var q = RandSea(); GoTo(c, q[0], q[1], null, now, false, true); Say(c, "Swim time!", now); return; }
            if (id == "shell")
            {
                var L = Shells; if (L.Count == 0) { Toast("No shells right now. More wash up soon!"); return; }
                JObj b = (JObj)L[0]; double bd = 1e9; foreach (JObj q in L) { double d = Math.Sqrt(Math.Pow(q.Num("x") - c.X, 2) + Math.Pow(q.Num("y") - c.Y, 2)); if (d < bd) { bd = d; b = q; } }
                BPick(b, now); return;
            }
            if (id == "fish")
            {
                var used = new HashSet<int>(); foreach (var o in Vis) if (o != c && o.Fish != null) used.Add(o.Fish.Value);
                int k = -1; for (int i = 0; i < Beach.FISH.Length; i++) if (!used.Contains(i)) { k = i; break; }
                if (k < 0) { Toast("Both fishing spots are taken"); return; }
                var F = Beach.FISH[k];
                GoTo(c, F.x, F.y, () =>
                {
                    double t = Last; c.X = F.x; c.Y = F.y; c.Mode = "fish"; c.Fish = k; c.Face = F.face; var FS = HsGet(c, "fishing");
                    if (FS != null) { c.FishEnd = t + FS.Num("catchEnd") + 400; Play(c, "fishing"); } else { c.FishEnd = t + 6000 + Rand() * 4000; c.Gear = "rod"; Play(c, "idle"); }
                    Say(c, "Fishing...", t);
                }, now);
                c.Fish = k; Say(c, "Gone fishing!", now);
            }
        }
        /// <summary>bSurf: to the water's edge with the board, then the ride (bStep).</summary>
        void BSurf(HouseCreature c, JObj it, double now)
        {
            double y0 = Math.Max(150, Math.Min(322, c.Y + 20));
            if (y0 > Beach.Py0 - 34 && y0 < Beach.Py1 + 30) y0 = y0 < (Beach.Py0 + Beach.Py1) / 2 ? Beach.Py0 - 34 : Beach.Py1 + 30;
            double xs = Beach.Shore(y0) + Beach.Ice() + 16;
            GoTo(c, xs, y0, () => { c.Mode = "surf"; c.Surf = new HouseCreature.SurfRun { T0 = Last, Y0 = y0, Xs = xs, L = Math.Max(60, 812 - xs) }; c.Gear = "board"; Play(c, HsGet(c, "surf") != null ? "surf" : "happy"); Say(c, "Surf’s up!", Last); }, now, false, true);
        }
        /// <summary>The fishing sign shows while nobody fishes.</summary>
        public bool FishSign { get { foreach (var o in Vis) if (o.Fish != null) return false; return true; } }
    }
}
