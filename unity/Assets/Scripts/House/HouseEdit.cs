// Renovate (HOUSE_PORT_PLAN.md stage 6): the page's edit mode. Pieces dragged on the floor (snapping flat against a
// side wall when brought close: wallPose), on the walls (side walls pick the spot along the wall and the height; the
// back wall slides; ceiling pieces slide along the ceiling), small pieces onto hosts' tops (dragSmall), rotated (the
// 0..360 slider: rotSet, or 45° steps: editRot), resized (editSize, szFit keeping them on their wall), put away
// (editStore), taken out of storage (placeNew); the ceiling light dragged along the ceiling, resized and put away
// (lightDown, lightSize, lightStore, lightBack); the renovated surfaces put up (useRSurf). Friends on a piece being
// edited are held off it (edHold) and put back when Renovate is done (edBack). Positions are the room box's px
// (toLocal: the view converts). tools/unity/house-test `edit` replays the page's trace (creature-trace.mjs ops).
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class EditHold { public string Id, Mode, WSt, NapSt; public int K; public bool Use; public HouseAct UseA; public double UseEnd, EatEnd, BowlEnd; }

    public sealed partial class HouseCreatures
    {
        public const double WALLR = 69;
        public static readonly double[] ROTS = { 0, 45, 90, 135, 180, 225, 270, 315 };
        public static readonly string[] DIRN = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
        public static readonly Dictionary<string, string> RTABL = new Dictionary<string, string> { ["furn"] = "Furniture", ["ceil"] = "Ceiling", ["wall"] = "Walls", ["floor"] = "Floors", ["trim"] = "Trim", ["win"] = "Windows", ["light"] = "Lights", ["art"] = "Art", ["door"] = "Doors", ["fence"] = "Fence", ["ground"] = "Ground", ["ylight"] = "Yard lights" };
        public static readonly Dictionary<string, string> BTABL = new Dictionary<string, string> { ["fence"] = "Pier", ["ground"] = "Sand", ["ylight"] = "Lights" };

        // the page's edit state: eSel (a piece's id, "__light", null), rOpen (the toolbox drawer; null = not set yet: open),
        // rTab, tbC (the piece whose tools were hidden), txE (the sign being written)
        public string ESel, RTab = "furn", TbC, TxE;
        public bool? ROpen;
        /// <summary>The beach's sand and sea placement (stage 10: Beach.itemX, randSand, randSea); null elsewhere.</summary>
        public Func<double, double, double, bool, double> BeachItemX;
        public Func<bool, double[]> BeachRand;
        sealed class DragSt { public string Id; public double Dx, Dy; }
        DragSt _drag;
        bool _rotMoved, _snapTold;
        double _lDx; bool _lDrag;
        public bool Dragging => _drag != null || _lDrag;

        static double MOD(double a, double n) => (a % n + n) % n;
        static double JR(double v) => HouseGeo.JsRound(v);
        List<object> RoomList() { var R = S.H.Ensure("rooms"); if (!(R[S.Cur] is List<object> l)) R[S.Cur] = l = new List<object>(); return l; }
        double TopOf(JObj it) => Cat(it)?.Num("topOf") ?? 0;
        (double hx, double hz) Half(JObj D, double r) => S.Geo.Half(D.Num("w"), D.Num("d"), r);
        double Elev(JObj it) => new RoomModel(S).Elev(it);

        void SaveNow() => Saved?.Invoke();
        /// <summary>The edit UI's own state changed (rOpen, rTab, tbC, eSel): the room and UI redraw.</summary>
        public void Bumped() => Bump();

        // ---- starting and ending ----
        /// <summary>startEdit</summary>
        public void StartEdit() { Edit = true; Sel = null; ESel = null; RTab = "furn"; ROpen = false; Bump(); }
        /// <summary>doneEdit: friends back on what they were on, out of Renovate.</summary>
        public void DoneEdit(double now) { EdBack(now); Edit = false; ESel = null; TxE = null; Bump(); }
        /// <summary>A tap on the room's floor in Renovate: the selection goes.</summary>
        public void EditFloorTap() { if (ESel != null) { ESel = null; Bump(); } }

        /// <summary>edHold: he gets off the piece being edited, remembering how he was on it.</summary>
        public void EdHold(HouseCreature c, double now)
        {
            if (c.ReHold == null)
            {
                var sk = c.Seat?.Split(':');
                c.ReHold = sk != null ? new EditHold { Id = c.SeatItem, K = int.Parse(sk[sk.Length - 1]), Mode = c.Mode, WSt = c.WSt, NapSt = c.NapSt }
                    : c.UseItem != null ? new EditHold { Id = c.UseItem, Use = true, Mode = c.Mode, WSt = c.WSt, UseA = c.UseA, UseEnd = c.UseEnd, EatEnd = c.EatEnd, BowlEnd = c.BowlEnd } : null;
            }
            Leave(c, true, now); c.Moving = false; c.Arrive = null;
        }

        void HoldOn(string id, double now) { foreach (var c in Vis) if (c.SeatItem == id || c.UseItem == id) EdHold(c, now); }

        /// <summary>edBack: everyone held off a piece goes back onto it where it is now (if it's still in the room).</summary>
        public void EdBack(double now)
        {
            var G = S.Geo;
            foreach (var c in Vis)
            {
                var R = c.ReHold; c.ReHold = null; if (R == null) continue;
                var it = FindItem(R.Id); var D = Cat(it); if (D == null) continue;
                double s0 = Zs0(it), s1 = ZsY(it);
                c.Moving = false; c.Arrive = null; c.Keep = null; c.StandUntil = 0;
                if (!R.Use)
                {
                    var seats = D.Arr("seats"); if (seats == null || R.K >= seats.Count || seats[R.K] == null || Taken(c, it.Str("id") + ":" + R.K)) continue;
                    var q = SeatXY(D, it.Num("r"), R.K); double x = it.Num("x") + q.x * s0, y = it.Num("y") + q.z * G.SA * s1;
                    c.X = c.Tx = x; c.Y = c.Ty = y; c.Seat = it.Str("id") + ":" + R.K; c.SeatItem = it.Str("id"); c.LiftTo = c.Lift = q.h * G.CA * s1;
                    c.Z = JR(it.Num("y")) + (q.z >= -6 || HasFront(it.Str("id")) ? 1 : -1); c.Face = it.Num("r") + q.f;
                    c.Mode = R.Mode == "snuggle" || R.Mode == "watch" ? "sit" : R.Mode; c.WSt = R.WSt; c.NapSt = R.NapSt;
                    var st = c.WSt ?? c.NapSt ?? (c.Mode == "nap" || c.Mode == "sun" ? "sleep" : SEATED.Contains(c.Mode) ? c.Mode : "happy"); Play(c, st);
                    continue;
                }
                var use = D.Obj("use"); if (use == null || InUse(c, it.Str("id"))) continue;
                var u = G.UseXY(use.Num("x"), use.Num("z"), it.Num("r")); bool inside = use.Truthy("inside"); double uh = use.Num("h");
                double tx = it.Num("x") + u.x * s0, ty = it.Num("y") + u.z * G.SA * s0;
                c.X = c.Tx = tx; c.Y = c.Ty = ty; c.UseItem = it.Str("id"); c.Mode = R.Mode; c.UseA = R.UseA; c.UseEnd = R.UseEnd; c.EatEnd = R.EatEnd; c.BowlEnd = R.BowlEnd; c.WSt = R.WSt;
                c.Face = inside ? 0 : FaceTo(c, it);
                if (inside) c.Z = JR(it.Num("y")) + 1; if (uh != 0) c.LiftTo = c.Lift = uh * G.FS * G.CA * s0; if (c.UseA?.V != null) SetVar(it.Str("id"), c.UseA.V);
                Play(c, c.WSt ?? c.UseA?.Anim ?? "happy");
            }
            Bump();
        }

        // ---- dragging ----
        /// <summary>itemDown in Renovate: the piece picked up at room point (x, y), selected.</summary>
        public void EditDown(string id, double x, double y, double now)
        {
            var it = FindItem(id); if (it == null) return;
            _drag = new DragSt { Id = id, Dx = x - it.Num("x"), Dy = y - (it.Num("y") - LiftPx(it)) };
            HoldOn(id, now); ESel = id; ROpen = false; Bump();
        }

        public JObj WallPose(JObj it, string side, double y)
        {
            var G = S.Geo; var D = Cat(it); double r = side == "L" ? WALLR : 360 - WALLR, tr = r * Math.PI / 180, sn = Math.Sin(tr), cs = Math.Cos(tr), k = G.FS, yy = y;
            for (int n = 0; n < 3; n++)
            {
                double s = G.SAt(yy), lo = 0;
                foreach (var (a, b) in new[] { (-1, -1), (1, -1), (-1, 1), (1, 1) }) lo = Math.Min(lo, (-a * D.Num("w") / 2 * sn + b * D.Num("d") / 2 * cs) * k * s * G.SA);
                if (yy + lo < 104) yy = 104 - lo; else break;
            }
            double s2 = G.SAt(yy), bx = -D.Num("d") / 2 * sn * k * s2, yb = yy - D.Num("d") / 2 * cs * k * s2 * G.SA; if (yb > 250) return null;
            double e = G.Edge(yb);
            return new JObj { ["r"] = r, ["x"] = side == "L" ? e - bx + 3 : G.VW - e - bx - 3, ["y"] = yy };
        }

        /// <summary>dragMove: the held piece follows the room point.</summary>
        public void DragMove(double px, double py)
        {
            if (_drag == null) return; var it = FindItem(_drag.Id); if (it == null) return;
            var Df = Cat(it); double sy = py - _drag.Dy, raw = px - _drag.Dx, ox = it.Num("x"), oy = it.Num("y");
            if (Df.Truthy("mount")) DragWall(it, Df, raw, sy); else if (Df.Truthy("small")) DragSmall(it, Df, raw, sy); else DragFloor(it, Df, raw, Math.Max(112, Math.Min(342, sy)));
            if (S.CanSize(it)) SzFit(it);
            double dx = it.Num("x") - ox, dy = it.Num("y") - oy;
            if (dx != 0 || dy != 0) foreach (var k in RoomItems()) if (k["on"] is string on && on == it.Str("id")) { k["x"] = k.Num("x") + dx; k["y"] = k.Num("y") + dy; }
            Bump();
        }

        void DragFloor(JObj it, JObj Df, double raw, double y)
        {
            var G = S.Geo;
            if (!Df.Truthy("flat") && !Df.Truthy("reno"))
                foreach (var side in new[] { "L", "R" })
                {
                    var q = WallPose(it, side, y);
                    if (q != null && Math.Abs(raw - q.Num("x")) < 46)
                    {
                        if (!it.Truthy("w")) { it["r0"] = it["r"]; if (!_snapTold) { _snapTold = true; Toast("Lined up with the wall"); } }
                        it["w"] = side; it["r"] = q["r"]; it["x"] = q["x"]; it["y"] = q["y"]; return;
                    }
                }
            if (it.Truthy("w")) { it["w"] = null; it["r"] = it["r0"] is double r0 ? r0 : 0.0; }
            double s = G.SAt(y); var h = Half(Df, it.Num("r"));
            double m = Df.Truthy("flat") ? G.Edge(Math.Min(y, 262)) * 0.6 : G.Edge(Math.Min(y, 262)) + h.hx * s * Zk(it) * (Df.Truthy("small") ? 0.3 : 0.6);
            it["x"] = Math.Max(m, Math.Min(G.VW - m, raw)); it["y"] = y;
            if (S.Cur == "beach" && BeachItemX != null) it["x"] = BeachItemX(it.Num("x"), y, h.hx * s, Df.Truthy("sea"));
        }

        double MinE(JObj it)
        {
            var G = S.Geo; var D = Cat(it); if (D == null || !D.Truthy("mount") || D.Str("rL") == "ceil") return 0;
            var b = S.SzBox(it); double z = S.CanSize(it) ? S.SzXY(it)[1] : 1;
            return Math.Min(0, (b[1] + b[3]) * z / (G.FS * G.CA));
        }

        void DragWall(JObj it, JObj D, double raw, double sy)
        {
            var G = S.Geo; string rL = D.Str("rL");
            if (rL != "ceil" && (!D.Truthy("reno") || rL == "wall"))
            {
                double e0 = G.Edge(101), hy = 10; string w = it["w"] as string;
                foreach (var side in new[] { "L", "R" })
                {
                    bool inS = side == "L" ? raw < e0 + (w == "L" ? hy : -hy) : raw > G.VW - e0 - (w == "R" ? hy : -hy); if (!inS) continue;
                    JObj q = null; double bd = 1e9;
                    for (int y = 104; y <= 258; y += 2) { var p = WallPose(it, side, y); if (p == null) continue; double d = Math.Abs(p.Num("x") - raw); if (d < bd) { bd = d; q = p; } }
                    if (q == null) continue;
                    double s = G.SAt(q.Num("y")), k = G.FS * G.CA * s, zy = S.CanSize(it) ? S.SzXY(it)[1] : 1, maxL = q.Num("y") + S.SzBox(it)[1] * s * zy + 45;
                    it["w"] = side; it["r"] = q["r"]; it["x"] = q["x"]; it["y"] = q["y"]; it["e"] = Math.Max(MinE(it) * k, Math.Min(maxL, q.Num("y") - sy)) / k; return;
                }
            }
            it["w"] = null; it["r"] = 0.0;
            if (rL == "ceil") { double m0 = G.Edge(101) + Half(D, 0).hx * G.SAt(it.Num("y")) * 0.9; it["x"] = Math.Max(m0, Math.Min(G.VW - m0, raw)); return; }
            double yA = S.BackY(D), s1 = G.SAt(yA), k1 = G.FS * G.CA * s1, maxL1 = yA + S.SzBox(it)[1] * s1 * (S.CanSize(it) ? S.SzXY(it)[1] : 1) + 45;
            it["e"] = Math.Max(MinE(it) * k1, Math.Min(maxL1, yA - sy)) / k1;
            double m = G.Edge(101) + Half(D, 0).hx * s1 * 0.9; it["x"] = Math.Max(m, Math.Min(G.VW - m, raw)); it["y"] = yA;
        }

        List<JObj> Hosts(string skip) => RoomItems().FindAll(h => h.Str("id") != skip && Cat(h) != null && !Cat(h).Truthy("small") && TopOf(h) > 0);

        void DragSmall(JObj it, JObj D, double raw, double sy)
        {
            var G = S.Geo; var H = Hosts(it.Str("id")); StableSort(H, (a, b) => Math.Sign(b.Num("y") - a.Num("y")));
            foreach (var h in H)
            {
                var Dh = Cat(h); double s = G.SAt(h.Num("y")); var hz = Half(Dh, h.Num("r"));
                double cy = h.Num("y") - LiftPx(h) - TopOf(h) * ZkY(h) * G.FS * G.CA * s, ax = hz.hx * s * Zk(h), az = hz.hz * s * Zk(h) * G.SA;
                if (Math.Abs(raw - h.Num("x")) <= ax * 0.92 && Math.Abs(sy - cy) <= az + 8)
                {
                    it["on"] = h.Str("id"); it["w"] = null; it["x"] = Math.Max(h.Num("x") - ax * 0.8, Math.Min(h.Num("x") + ax * 0.8, raw));
                    it["y"] = h.Num("y") + Math.Max(-az * 0.7, Math.Min(az * 0.7, sy - cy)); return;
                }
            }
            it["on"] = null; DragFloor(it, D, raw, Math.Max(112, Math.Min(342, sy)));
        }

        /// <summary>dragEnd</summary>
        public void DragEnd() { if (_drag == null) return; _drag = null; SaveNow(); }

        double[] SzWall(JObj it)
        {
            var G = S.Geo; var D = Cat(it); double P = 5, e0 = G.Edge(101);
            if (D != null && D.Truthy("mount")) { var w = it["w"] as string; if (w == "L") return new[] { P, e0 - P }; if (w == "R") return new[] { G.VW - e0 + P, G.VW - P }; return new[] { e0 + P, G.VW - e0 - P }; }
            return new[] { P, G.VW - P };
        }

        /// <summary>szFit: a resized piece kept inside its wall, on the wall and off the ceiling.</summary>
        public void SzFit(JObj it)
        {
            var G = S.Geo; var D = Cat(it); if (D == null || !S.CanSize(it)) return;
            var b = S.SzBox(it); var z = S.SzXY(it); double sa = G.SAt(it.Num("y")); var W = SzWall(it);
            if (!it.Truthy("w")) { double l = it.Num("x") + b[0] * z[0] * sa, r = it.Num("x") + (b[0] + b[2]) * z[0] * sa; if (r - l <= W[1] - W[0] + 0.5) { if (l < W[0]) it["x"] = it.Num("x") + W[0] - l; else if (r > W[1]) it["x"] = it.Num("x") - (r - W[1]); } }
            if (D.Truthy("mount") && D.Str("rL") == "ceil" && D.Truthy("reno")) it["e"] = S.CeilE(it, D);
            if (D.Truthy("mount") && D.Str("rL") != "ceil")
            {
                double k = G.FS * G.CA * sa, y0 = it.Num("y") - LiftPx(it), t = y0 + b[1] * z[1] * sa, bt = y0 + (b[1] + b[3]) * z[1] * sa, e = Elev(it);
                if (t < -45) e -= (-45 - t) / k; else if (bt > it.Num("y")) e += (bt - it.Num("y")) / k;
                it["e"] = Math.Max(MinE(it), e);
            }
        }

        // ---- the toolbar ----
        public JObj ESelItem => ESel != null && ESel != "__light" ? FindItem(ESel) : null;

        /// <summary>The rotation slider pressed: rotSet calls follow, RotEnd saves if it turned.</summary>
        public void RotStart() => _rotMoved = false;
        public void RotEnd() { if (_rotMoved) SaveNow(); }

        /// <summary>rotSet: 0..360, snapping to 45° within 4°, else 5° steps.</summary>
        public void RotSet(JObj it, double deg, double now)
        {
            deg = Math.Max(0, Math.Min(360, deg)); double nr = JR(deg / 45) * 45; if (Math.Abs(nr - deg) <= 4) deg = nr; else deg = JR(deg / 5) * 5;
            if (deg == it.Num("r")) return;
            if (!_rotMoved) { _rotMoved = true; HoldOn(it.Str("id"), now); }
            it["r"] = deg; it["w"] = null; Bump();
        }

        /// <summary>slKey: the slider's arrow keys (±15°).</summary>
        public void RotKey(int d, double now) { var it = ESelItem; if (it == null || d == 0) return; _rotMoved = false; double cur = it.Num("r") == 360 ? 360 : MOD(it.Num("r"), 360); RotSet(it, cur + d * 15, now); SaveNow(); }

        /// <summary>editRot: a piece that can't spin flips between its two angles; a wall piece says to drag it; else 45° on.</summary>
        public void EditRot(double now)
        {
            var it = ESelItem; if (it == null) return; var D = Cat(it);
            if (D != null && D.Truthy("reno") && !S.CanSpin(it)) { it["r"] = MOD(it.Num("r"), 360) == 30 ? 330.0 : 30.0; HoldOn(it.Str("id"), now); SaveNow(); Bump(); return; }
            if (D != null && D.Truthy("mount")) { Toast("Drag it to the wall you want"); return; }
            int ri = Array.FindIndex(ROTS, v => v > it.Num("r") + 0.5); it["r"] = ri < 0 ? 0 : ROTS[ri]; it["w"] = null;
            HoldOn(it.Str("id"), now); SaveNow(); Bump();
        }

        /// <summary>editSize: a quarter bigger or smaller (ax "sw" / "sh": width or height alone, for free-sized screens).</summary>
        public void EditSize(int d, string ax = null)
        {
            var it = ESelItem; if (it == null || !S.CanSize(it)) return; var D = Cat(it); var L = S.SzLim(it);
            string k = ax != null && S.SzFree(it) ? ax : "sz"; double lim = k == "sw" ? L[0] : k == "sh" ? L[1] : Math.Min(L[0], L[1]), z0 = k == "sz" ? S.SzOf(it) : S.SzAx(it, k, lim);
            double z = JR((z0 + d * 0.25) * 4) / 4; if (z > lim) z = lim; double zm = S.SzMin(it); if (z < zm) z = zm;
            if (Math.Abs(z - z0) < 0.004) { Toast(d > 0 ? (D.Truthy("mount") ? "It fills the wall now" : "That’s as big as it gets") : "That’s as small as it gets"); return; }
            it[k] = z; SzFit(it); SaveNow(); Bump();
        }

        /// <summary>editStore: the piece back into storage (friends on it get off; small pieces on it stay where they are).</summary>
        public void EditStore(double now)
        {
            var id = ESel; var L = RoomList(); int i = L.FindIndex(o => o is JObj j && j.Str("id") == id); if (i < 0) return;
            foreach (var c in Vis) if (c.SeatItem == id || c.UseItem == id) Leave(c, false, now);
            L.RemoveAt(i); foreach (var o in L) if (o is JObj k && k["on"] is string on && on == id) k["on"] = null;
            TxE = null; SaveNow(); ESel = null; Bump(); Toast("Put away in your stuff");
        }

        /// <summary>freeCount: how many of a piece are in storage (owned and not out in any room).</summary>
        public int FreeCount(string t)
        {
            var H = S.H; int n = 0;
            foreach (var rk in S.D.RKeys) foreach (var o in H.Obj("rooms")?[rk] as List<object> ?? new List<object>()) if (o is JObj it && it.Str("t") == t) n++;
            return (int)(H.Obj("owned")?.Num(t) ?? 0) - n;
        }

        /// <summary>placeNew: a stored piece out into the room (a free spot; wall pieces on the back wall; small ones on a
        /// host), selected in Renovate.</summary>
        public void PlaceNew(string t, double c = 0)
        {
            if (FreeCount(t) <= 0) { Toast("All of them are already out"); return; }
            var G = S.Geo; var H = S.H; double x = 426, y = 240;
            for (int k = 0; k < 30; k++) { double yy = 180 + Rand() * 130, a = G.Edge(yy) + 90, b = G.VW - G.Edge(yy) - 90, xx = a + Rand() * (b - a); if (!Blocked(xx, yy)) { x = xx; y = yy; break; } }
            var D = S.D.CatOf(t);
            if (S.Cur == "beach" && BeachRand != null && BeachItemX != null)
                for (int k = 0; k < 20; k++) { bool sea = D != null && D.Truthy("sea"); var q = BeachRand(sea); if (!Blocked(q[0], q[1])) { x = sea ? q[0] : BeachItemX(q[0], q[1], Half(D, 330).hx * G.SAt(q[1]), false); y = q[1]; break; } }
            double uid = H.Num("uid"); H["uid"] = uid + 1;
            var it = new JObj { ["id"] = "i" + HouseJson.JsString(uid), ["t"] = t, ["x"] = x, ["y"] = y, ["r"] = D.Truthy("reno") && !D.Truthy("mount") ? 330.0 : 0.0, ["c"] = c != 0 ? c : 0.0 };
            if (D.Truthy("mount"))
            {
                double s = G.SAt(101), m = G.Edge(101) + Half(D, 0).hx * s;
                it["y"] = S.BackY(D); it["x"] = m + Rand() * Math.Max(0, G.VW - 2 * m); if (D.Str("rL") == "ceil") it["e"] = S.CeilE(it, D); else if (D["elev"] != null) it["e"] = D["elev"];
            }
            else if (D.Truthy("small"))
            {
                var hs = Hosts(null);
                if (hs.Count > 0) { var h = hs[(int)Math.Floor(Rand() * hs.Count)]; double s = G.SAt(h.Num("y")); var hz = Half(Cat(h), h.Num("r")); it["on"] = h.Str("id"); it["x"] = h.Num("x") + (Rand() - 0.5) * hz.hx * s; it["y"] = h["y"]; }
            }
            RoomList().Add(it); SaveNow();
            Edit = true; ESel = it.Str("id"); ROpen = false; Shop = false; Det = null; Bump();
        }

        // ---- the ceiling light ----
        public double? LxOf(string rk) { var v = S.H.Obj("lx")?[rk]; if (v is double d) return d; var R = S.D.Room(rk); return R != null && R["lightX"] is double lx ? lx : (double?)null; }
        public double LzOf(string rk) { var v = S.H.Obj("lz")?[rk]; return v is double d && d != 0 ? d : 1; }

        /// <summary>lightDown: the ceiling light picked up at room x (Renovate only).</summary>
        public void LightDown(double x)
        {
            if (!Edit) return; _lDx = x - (LxOf(S.Cur) ?? 0); _lDrag = true; S.H.Ensure("lx"); ESel = "__light"; ROpen = false; Bump();
        }
        public void LightMove(double x)
        {
            if (!_lDrag) return; double nx = JR(Math.Max(70, Math.Min(782, x - _lDx)));
            var L = S.H.Ensure("lx"); if (!(L[S.Cur] is double o && o == nx)) { L[S.Cur] = nx; Bump(); }
        }
        public void LightUp() { if (!_lDrag) return; _lDrag = false; SaveNow(); }
        /// <summary>The toolbar's "back to the middle".</summary>
        public void LightMid() { var L = S.H.Obj("lx"); if (L != null && L[S.Cur] != null) { L.Remove(S.Cur); SaveNow(); Bump(); } }

        public void LightSize(int d)
        {
            string rk = S.Cur; double z0 = LzOf(rk), z = Math.Max(0.5, Math.Min(2, JR((z0 + d * 0.25) * 4) / 4));
            if (z == z0) { Toast(d > 0 ? "That’s as big as it gets" : "That’s as small as it gets"); return; }
            var L = S.H.Ensure("lz"); if (z == 1) L.Remove(rk); else L[rk] = z; SaveNow(); Bump();
        }

        string DefLight => S.D.Def["light"] as string;

        public void LightStore()
        {
            string rk = S.Cur; var sf = S.H.Ensure("surf").Ensure(rk); var old = sf["light"] as string ?? DefLight; if (old == "l_none") return;
            if (!old.StartsWith("rv_")) S.H.Ensure("lOff")[rk] = old;
            sf["light"] = "l_none"; SaveNow(); ESel = null; Bump(); Toast("Put away. Find it in the Lights tab");
        }

        public void LightBack(string id)
        {
            string rk = S.Cur; var sf = S.H.Ensure("surf").Ensure(rk); var old = sf["light"] as string ?? DefLight;
            if (old != id && !old.StartsWith("rv_") && old != "l_none") S.H.Ensure("lOff")[rk] = old;
            sf["light"] = id; SaveNow(); Bump(); Toast("The light is up!");
        }

        // ---- the renovated surfaces (the toolbox's Walls / Floors / Ceiling / Lights tabs) ----
        public static readonly HashSet<string> TEXK = new HashSet<string> { "wall", "floor", "ceil", "fence", "ground" };

        /// <summary>rnSlot: which tab a renovation row goes under (null: not a surface).</summary>
        public string RnSlot(JObj r)
        {
            return S.D.SlotOf(r);   // (the page's answer for every row: export-edit.mjs)
        }

        public string[] RnTabs(string rk) => S.D.Room(rk)?.Truthy("out") == true ? new[] { "furn", "fence", "ground", "ylight" } : new[] { "furn", "wall", "floor", "ceil", "light" };
        public string CurTab() => Array.IndexOf(RnTabs(S.Cur), RTab) >= 0 ? RTab : "furn";

        public bool RnIsOn(JObj r)
        {
            string rk = S.D.RMap(r.Str("room")), slot = RnSlot(r); if (slot == null) return false;
            return TEXK.Contains(slot) ? S.H.Obj("rtex")?.Obj(rk)?.Str(slot) == r.Str("id") : S.H.Obj("surf")?.Obj(rk)?.Str(slot) == "rv_" + r.Str("id");
        }

        /// <summary>useRSurf: an owned renovated surface put up in this room.</summary>
        public void UseRSurf(string id)
        {
            var r = S.D.Row(id); string rk = S.Cur; var H = S.H; if (r == null) return; var slot = RnSlot(r);
            if (S.D.RMap(r.Str("room")) != rk) { Toast("That goes in the " + (HouseFrame.RLAB.TryGetValue(S.D.RMap(r.Str("room")) ?? "", out var rl) ? rl : null)); return; }
            if (slot == null) { Toast("That one does not fit this room"); return; }
            if (TEXK.Contains(slot))
            {
                var o = new JObj(); if (H.Obj("rtex")?.Obj(rk) is JObj a) foreach (var k in a.Keys) o[k] = a[k]; o[slot] = id; H.Ensure("rtex")[rk] = o;
            }
            else
            {
                var sf = H.Ensure("surf").Ensure(rk);
                if (slot == "light") { var old = sf["light"] as string ?? DefLight; if (!old.StartsWith("rv_") && old != "l_none") H.Ensure("lOff")[rk] = old; }
                sf[slot] = "rv_" + id;
            }
            SaveNow(); Bump(); Toast(S.D.ShortName(r) + " is up!");
        }

        /// <summary>The toolbox's tray: trayVals' pieces (in storage for this room) or surfaces (owned for this tab), in order.</summary>
        public List<(string id, string name, string n, bool hasN, bool on, bool isPiece)> Tray()
        {
            var H = S.H; string rk = S.Cur, tab = CurTab(); var o = new List<(string, string, string, bool, bool, bool)>();
            if (tab == "furn")
            {
                var ts = new List<string>(); foreach (var t in H.Obj("owned")?.Keys ?? new List<string>()) { var D = S.D.CatOf(t); if (D != null && D.Truthy("reno") && D.Str("room") == rk && FreeCount(t) > 0) ts.Add(t); }
                StableSort(ts, (a, b) => S.D.CatOf(a).Num("lv").CompareTo(S.D.CatOf(b).Num("lv")));
                foreach (var t in ts) o.Add((t, S.D.ShortName(S.D.Row(S.D.CatOf(t).Str("reno"))), "x" + FreeCount(t), true, false, true));
                return o;
            }
            if (tab == "light")
            {
                var sid = H.Obj("lOff")?.Str(rk);
                if (sid != null && sid != "l_none" && S.D.Spec(sid)) { bool on = (H.Obj("surf")?.Obj(rk)?.Str("light") ?? DefLight) == sid; o.Add(("stock_" + sid, S.D.SurfName(sid) ?? "Ceiling light", "ON", on, on, false)); }
            }
            var rows = new List<JObj>(); foreach (var id in H.Obj("rOwn")?.Keys ?? new List<string>()) { var r = S.D.Row(id); if (r != null && S.D.RMap(r.Str("room")) == rk && RnSlot(r) == tab) rows.Add(r); }
            StableSort(rows, (a, b) => a.Num("lv").CompareTo(b.Num("lv")));
            foreach (var r in rows) { bool on = RnIsOn(r); o.Add((r.Str("id"), S.D.ShortName(r), "ON", on, on, false)); }
            return o;
        }

        /// <summary>A tray card tapped: a piece out of storage, a surface up, the stock light back.</summary>
        public void TrayGo(string id) { if (id.StartsWith("stock_")) LightBack(id.Substring(6)); else if (CurTab() == "furn") PlaceNew(id); else UseRSurf(id); }

        static void StableSort<T>(List<T> l, Comparison<T> cmp)
        {
            var ix = new Dictionary<T, int>(); for (int i = 0; i < l.Count; i++) ix[l[i]] = i;
            l.Sort((a, b) => { int c = cmp(a, b); return c != 0 ? c : ix[a] - ix[b]; });
        }
    }
}
