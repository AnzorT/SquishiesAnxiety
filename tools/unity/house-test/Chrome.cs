// `chrome`: the stage-2 pieces against the page's own numbers (Squad House v6.dc.html): the camera's ease and its
// toLocal, the beach gate's hit path and tapDoor, the drawer and the toast (Resources/House/hud.json).
using System;
using System.Collections.Generic;
using System.IO;
using SquishSquad.House;

static class Chrome
{
    static int bad;
    static void Check(string what, bool ok) { if (!ok) bad++; Console.WriteLine((ok ? "  ok   " : "  FAIL ") + what); }
    static bool Near(double a, double b, double e = 1e-6) => Math.Abs(a - b) <= e;

    public static int Run()
    {
        // the camera: CSS ease (cubic-bezier(.25,.1,.25,1)) over 450 ms; ease(0.5) = 0.8024033877399112
        var cam = new HouseCamera();
        cam.Set(0.85, 0, false);
        Check("camera starts at 0.85", Near(cam.K(0), 0.85));
        cam.Set(1, 1000);
        Check("camera half way (ease 0.5)", Near(cam.K(1225), 0.85 + 0.15 * 0.8024033877399112, 1e-4));
        Check("camera there after 450 ms", Near(cam.K(1450), 1) && !cam.Moving(1450));
        Check("camK: 0.85 indoors, 1 dance / out / beach", HouseCamera.KFor("living", false, false) == 0.85 && HouseCamera.KFor("dance", false, false) == 1 && HouseCamera.KFor("backyard", true, false) == 1);
        // toLocal: x 426 + (fx - 426) / K, y 343 + (fy - 393) / K; ToFrame its inverse
        var b = HouseCamera.ToBox(100, 200, 0.85);
        Check("toLocal", Near(b.x, 426 + (100 - 426) / 0.85) && Near(b.y, 343 + (200 - 393) / 0.85));
        var f = HouseCamera.ToFrame(b.x, b.y, 0.85);
        Check("ToFrame inverts toLocal", Near(f.x, 100) && Near(f.y, 200));

        // the beach's gate (the only door of the current design): its hit path, its tapDoor
        var d = Program.Data();
        JObj beach = null;
        foreach (var k in d.Shells.Keys) if (k.StartsWith("beach|")) beach = d.Shells.Obj(k);
        Check("the beach shell has its gate", beach?.Arr("doors")?.Count == 1);
        Check("a tap on the gate post hits it", HouseDoors.At(beach, 45, 130)?.Str("to") == "backyard");
        Check("a tap on the sign hits it", HouseDoors.At(beach, 40, 66) != null);
        Check("a tap on the sand doesn't", HouseDoors.At(beach, 400, 300) == null);
        var s = new HouseSave(d);
        s.Load(null, 30, new List<int> { 1 }, "beach");
        var toast = HouseDoors.Tap(s, beach.Arr("doors")[0] as JObj);
        Check("tapDoor goes to the backyard", toast == null && s.Cur == "backyard");
        var locked = new JObj(); locked["to"] = "movie"; locked["lock"] = 12.0; locked["hit"] = "M0 0H1V1Z";
        Check("a locked door's toast", HouseDoors.Tap(s, locked) == "Boarded up! The Movie Room opens at level 12" && s.Cur == "backyard");

        // the drawer and the toast
        var hud = new HouseHud(File.ReadAllText(Path.Combine(Program.Res, "hud.json")));
        Check("drawer closed: translateY 72", Near(hud.DrawerTy(0), 72));
        var tab = hud.Pieces["tab"];
        Check("a tap on the closed drawer's tab", hud.Tap(tab.X + tab.W / 2, tab.Y + 72 + tab.H / 2, 0) == "tab");
        hud.SetOpen(true, 0);
        Check("drawer open after 0.75 s: translateY -16, arrow 180", Near(hud.DrawerTy(750), -16) && Near(hud.ArrowDeg(250), 180));
        Check("cubic-bezier(.25,1.15,.4,1) overshoots on the way", hud.DrawerTy(500) < -16);
        var ren = hud.Buttons["renovate"];
        Check("RENOVATE once open", hud.Tap(ren.X + ren.W / 2, ren.Y - 16 + ren.H / 2, 800) == "renovate");
        hud.ShowToast("Hi", 0);
        var t0 = hud.ToastAt(0); var t1 = hud.ToastAt(250);
        Check("the toast pops in (hsToast)", t0 != null && Near(t0.Value.op, 0) && Near(t0.Value.dy, -8) && Near(t1.Value.op, 1) && Near(t1.Value.dy, 0));
        Check("the toast is gone after 2.4 s", hud.ToastAt(2399) != null && hud.ToastAt(2400) == null);
        Console.WriteLine(bad == 0 ? "chrome: all ok" : $"chrome: {bad} failed");
        return bad == 0 ? 0 : 1;
    }
}

static class WalkCheck
{
    // `walk`: House/HouseWalk.cs against house-walk.js (tools/unity/house/walk-trace.mjs): every channel, v and fx
    public static int Run()
    {
        var W = new HouseWalk(File.ReadAllText(Path.Combine(Program.Res, "walk.json"))) { Rand = () => 0.5 };
        var trace = (List<object>)HouseJson.Parse(File.ReadAllText(Path.Combine(Program.Repo, "tools/unity/house-test/out/walk-trace.json")));
        int bad = 0, n = 0;
        foreach (JObj c in trace)
        {
            var st = new HouseWalk.State { Run = c.Num("run") != 0 };
            var frames = c.Arr("frames");
            for (int f = 0; f < frames.Count; f++)
            {
                var fr = (JObj)frames[f]; var E = new Dictionary<string, double>();
                double w = Math.Min(1, f / 20.0), spin = (f * 7) % 360 - 180;
                var r = W.Step(c.Str("key"), st, E, w, 0.016, f < 70 ? 1 : 0, spin);
                var je = fr.Obj("E"); string why = null;
                foreach (var k in je.Keys) if (!E.TryGetValue(k, out var v) || Math.Abs(v - je.Num(k)) > 1e-9) why ??= $"{k} {(E.TryGetValue(k, out var vv) ? vv : double.NaN)} vs {je.Num(k)}";
                foreach (var k in E.Keys) if (!je.Has(k)) why ??= "extra " + k;
                if (Math.Abs(r.V - fr.Num("v")) > 1e-9) why ??= $"v {r.V} vs {fr.Num("v")}";
                if (r.Fx != fr.Str("fx")) why ??= $"fx {r.Fx} vs {fr.Str("fx")}";
                n++;
                if (why != null) { if (bad++ < 8) Console.WriteLine($"  {c.Str("key")} frame {f}: {why}"); }
            }
        }
        Console.WriteLine(bad == 0 ? $"walk: {n} frames, all equal" : $"walk: {bad} of {n} frames differ");
        return bad == 0 ? 0 : 1;
    }
}

static class CreatureCheck
{
    // `creatures`: House/HouseCreatures.cs replaying tools/unity/house/creature-trace.mjs's page run frame by frame
    public static int Run()
    {
        var T = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Program.Repo, "tools/unity/house-test/out/creature-trace.json")));
        var d = Program.Data(); var hs = Program.LoadFixture(d, T.Str("fixture"));
        hs.EnterRoomSaveOnly(T.Str("room"));
        var walk = new HouseWalk(File.ReadAllText(Path.Combine(Program.Res, "walk.json")));
        var sim = new HouseCreatures(hs, walk);
        // the page's draws: the creature functions' share of its own stream, and house-walk.js's
        var page = new Queue<double>(); var hw = new Queue<double>(); var other = new Dictionary<string, int>();
        foreach (List<object> e in T.Arr("rng"))
        {
            string k = (string)e[0], fn = (string)e[1]; double v = (double)e[2];
            if (k == "house-page") page.Enqueue(v); else if (k == "house-walk.js") hw.Enqueue(v); else other[k] = other.TryGetValue(k, out var n) ? n + 1 : 1;
        }
        sim.Rand = () => page.Count > 0 ? page.Dequeue() : throw new Exception("out of page draws");
        walk.Rand = () => hw.Count > 0 ? hw.Dequeue() : throw new Exception("out of walk draws");
        var fq = new Queue<bool>(); foreach (var o in T.Arr("fidg")) fq.Enqueue(HouseJson.Truthy(o));
        sim.Fidg = c => fq.Count > 0 && fq.Dequeue();
        var st = T.Obj("start");
        HouseCreature Load(JObj o)
        {
            var c = new HouseCreature { Key = o.Str("key"), Room = o.Str("room"), Home = o.Str("home"), PosRoom = o.Str("posRoom"), Mode = o.Str("mode"), N = new Dictionary<string, double>() };
            c.X = o.Num("x"); c.Y = o.Num("y"); c.Tx = o.Num("tx"); c.Ty = o.Num("ty"); c.Moving = o.Truthy("moving"); c.Spin = o.Num("spin"); c.Face = o.Num("face"); c.Wk = o.Num("wk"); c.Ph = o.Num("ph");
            c.Lift = o.Num("lift"); c.LiftTo = o.Num("liftTo"); c.WanderAt = o.Num("wanderAt"); c.Hold = o.Num("hold"); c.Run = o.Truthy("run"); c.Gv = o.Num("gv", 1); c.NeedAt = o.Num("needAt");
            c.StandUntil = o.Num("standUntil"); c.TurnAt = o.Num("turnAt"); c.Z = o["z"] is double z ? z : (double?)null;
            foreach (var k in o.Obj("N").Keys) c.N[k] = o.Obj("N").Num(k);
            var g = o.Obj("gs"); c.Gs.Ph = g.Num("ph"); c.Gs.T = g.Num("t"); c.Gs.Rk = g.Num("rk"); c.Gs.FxAt = g.Num("fxAt"); c.Gs.RuAt = g.Num("ruAt"); c.Gs.Ld = g.Truthy("ld"); c.Gs.Ra = g.Num("ra"); c.Gs.Rv = g.Num("rv");
            foreach (var k in o.Obj("ext").Keys) c.Ext[k] = o.Obj("ext").Num(k);
            if (o.Truthy("arrive")) Console.WriteLine("  (" + c.Key + " has an arrive callback at the start: not replayable)");
            return c;
        }
        foreach (JObj o in st.Arr("cs")) sim.Cs.Add(Load(o));
        var vis = st.Arr("vis").ConvertAll(k => (string)k);
        sim.Vis = sim.Cs.FindAll(c => vis.Contains(c.Key));
        sim.Vis.Sort((a, b) => vis.IndexOf(a.Key) - vis.IndexOf(b.Key));
        sim.Sel = st["sel"] is double sd ? (int)sd : (int?)null;
        sim.Last = st.Num("last");
        int bad = 0; double worst = 0; string first = null;
        var frames = T.Arr("frames");
        for (int f = 0; f < frames.Count; f++)
        {
            var fr = (JObj)frames[f];
            sim.Tick(fr.Num("last"));
            foreach (JObj o in fr.Arr("cs"))
            {
                var c = sim.Cs.Find(x => x.Key == o.Str("key"));
                double e = Math.Max(Math.Abs(c.X - o.Num("x")), Math.Abs(c.Y - o.Num("y")));
                e = Math.Max(e, Math.Max(Math.Abs(c.Spin - o.Num("spin")), Math.Abs(c.Wk - o.Num("wk"))));
                foreach (var k in new[] { "h", "c", "e", "f" }) e = Math.Max(e, Math.Abs(c.N[k] - o.Obj("N").Num(k)));
                if (vis.Contains(c.Key)) foreach (var k in o.Obj("ext").Keys) e = Math.Max(e, Math.Abs((c.Ext.TryGetValue(k, out var v) ? v : 0) - o.Obj("ext").Num(k)));
                if (c.Moving != o.Truthy("moving")) e = Math.Max(e, 1);
                worst = Math.Max(worst, e);
                if (e > 1e-6) { bad++; first ??= $"frame {f} {c.Key}: x {c.X} vs {o.Num("x")}, y {c.Y} vs {o.Num("y")}, spin {c.Spin} vs {o.Num("spin")}, moving {c.Moving} vs {o.Truthy("moving")}"; }
            }
        }
        Console.WriteLine($"creatures: {frames.Count} frames; draws left: page {page.Count}, walk {hw.Count}, fidg {fq.Count}; others not replayed {string.Join(", ", other)}");
        Console.WriteLine(bad == 0 ? $"creatures: every creature every frame equal (worst {worst:g3})" : $"creatures: {bad} creature-frames differ (worst {worst:g3}); first: {first}");
        return bad == 0 ? 0 : 1;
    }
}

static class ActCheck
{
    // `acts`: the creature trace with scripted acts (creature-trace.mjs ... "frame:op:arg,..."): House/HouseActions.cs
    // replays the ops and the rig's events in the page's order; every creature's state each frame and every ctrl.play
    public static int Run()
    {
        var T = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Program.Repo, "tools/unity/house-test/out/creature-trace.json")));
        DrawServer.Start();   // (pieces in angles and states the export doesn't have: drawn at runtime)
        var d = Program.Data(); var hs = Program.LoadFixture(d, T.Str("fixture"));
        hs.EnterRoomSaveOnly(T.Str("room"));
        var walkJson = File.ReadAllText(Path.Combine(Program.Res, "walk.json"));
        var walk = new HouseWalk(walkJson);
        var sim = new HouseCreatures(hs, walk);
        sim.SetMoves(walkJson);
        var page = new Queue<double>(); var hw = new Queue<double>();
        foreach (List<object> e in T.Arr("rng")) { string k = (string)e[0]; double v = (double)e[2]; if (k == "house-page") page.Enqueue(v); else if (k == "house-walk.js") hw.Enqueue(v); }
        sim.Rand = () => page.Count > 0 ? page.Dequeue() : throw new Exception("out of page draws");
        walk.Rand = () => hw.Count > 0 ? hw.Dequeue() : throw new Exception("out of walk draws");
        var fq = new Queue<bool>(); foreach (var o in T.Arr("fidg")) fq.Enqueue(HouseJson.Truthy(o));
        sim.Fidg = c => fq.Count > 0 && fq.Dequeue();
        int ticks = 0; var plays = new List<string>(); var toasts = new List<string>();
        sim.Play = (c, n) => plays.Add($"{ticks} {c.Key} {n}");
        sim.PlayIdle = c => plays.Add($"{ticks} {c.Key} idle");
        sim.Toast = t => toasts.Add(t);
        sim.Saved = () => { };
        // the room model's answers the screen gives the squad: front parts (hasFr), the pieces' drawing data (rnI)
        var rm = new RoomModel(hs); var rv = rm.Build(T.Str("room"));
        var fronts = new Dictionary<string, bool>(); foreach (var o in rv?.Arr("items") ?? new List<object>()) if (o is JObj f0 && f0.Str("id") != null) fronts[f0.Str("id")] = HouseJson.Truthy(f0["hasFront"]);
        sim.HasFront = id => fronts.TryGetValue(id, out var fr0) && fr0;
        sim.RnI = id => rm.RnI.TryGetValue(id, out var ri) ? ri : null;
        // a change redraws the room (the page renders on setState): its boxes (szBx) and drawing data follow
        sim.RoomChanged = () => { var v2 = rm.Build(T.Str("room")); fronts.Clear(); foreach (var o in v2?.Arr("items") ?? new List<object>()) if (o is JObj f0 && f0.Str("id") != null) fronts[f0.Str("id")] = HouseJson.Truthy(f0["hasFront"]); };
        var st = T.Obj("start");
        foreach (JObj o in st.Arr("cs"))
        {
            var c = new HouseCreature { Key = o.Str("key"), Room = o.Str("room"), Home = o.Str("home"), PosRoom = o.Str("posRoom"), Mode = o.Str("mode"), N = new Dictionary<string, double>() };
            c.X = o.Num("x"); c.Y = o.Num("y"); c.Tx = o.Num("tx"); c.Ty = o.Num("ty"); c.Moving = o.Truthy("moving"); c.Spin = o.Num("spin"); c.Face = o.Num("face"); c.Wk = o.Num("wk"); c.Ph = o.Num("ph");
            c.Lift = o.Num("lift"); c.LiftTo = o.Num("liftTo"); c.WanderAt = o.Num("wanderAt"); c.Hold = o.Num("hold"); c.Run = o.Truthy("run"); c.Gv = o.Num("gv", 1); c.NeedAt = o.Num("needAt");
            c.StandUntil = o.Num("standUntil"); c.TurnAt = o.Num("turnAt"); c.Z = o["z"] is double z ? z : (double?)null;
            foreach (var k in o.Obj("N").Keys) c.N[k] = o.Obj("N").Num(k);
            var g = o.Obj("gs"); c.Gs.Ph = g.Num("ph"); c.Gs.T = g.Num("t"); c.Gs.Rk = g.Num("rk"); c.Gs.FxAt = g.Num("fxAt"); c.Gs.RuAt = g.Num("ruAt"); c.Gs.Ld = g.Truthy("ld"); c.Gs.Ra = g.Num("ra"); c.Gs.Rv = g.Num("rv");
            foreach (var k in o.Obj("ext").Keys) c.Ext[k] = o.Obj("ext").Num(k);
            sim.Cs.Add(c);
        }
        var vis = st.Arr("vis").ConvertAll(k => (string)k);
        sim.Vis = sim.Cs.FindAll(c => vis.Contains(c.Key)); sim.Vis.Sort((a, b) => vis.IndexOf(a.Key) - vis.IndexOf(b.Key));
        sim.Sel = st["sel"] is double sd ? (int)sd : (int?)null;
        sim.Last = st.Num("last");
        var ev = T.Arr("rig"); int ei = 0;
        int bad = 0, edN = 0; string first = null; var frames = T.Arr("frames");
        for (int f = 0; f < frames.Count; f++)
        {
            var fr = (JObj)frames[f];
            while (ei < ev.Count && (int)(double)((List<object>)ev[ei])[0] <= ticks)
            {
                var e = (List<object>)ev[ei++];
                if ((string)e[1] == "op")
                {
                    string k = (string)e[2], a = e[3] as string, b = e[4] as string;
                    if (k == "sel") sim.Sel = int.Parse(a);
                    else if (k == "act") sim.Act(a, b, sim.Last);
                    else if (k == "floor") { var c = sim.SelC; if (c != null) sim.GoTo(c, double.Parse(a), double.Parse(b), null, sim.Last); }
                    else if (k == "tap") sim.ItemDown(a, sim.Last);
                    else EditOp(sim, k, a, b, e.Count > 5 ? e[5] as string : null);
                }
                else { var c = sim.Cs.Find(x => x.Key == (string)e[2]); sim.OnRig(c, (string)e[3], sim.Last); }
            }
            ticks++;
            sim.Tick(fr.Num("last"));
            // the pieces' runtime states (rst: TV channel, playing, toaster...)
            foreach (var id in (fr.Obj("rst") ?? new JObj()).Keys)
            {
                var pr = fr.Obj("rst").Obj(id); sim.Rst.TryGetValue(id, out var R); R ??= new PieceState();
                if (R.Ch != pr.Num("ch") || R.Play != pr.Truthy("play") || (R.K ?? "") != (pr.Str("k") ?? "")) { bad++; first ??= $"frame {f} rst {id}: ch {R.Ch} vs {pr.Num("ch")}, play {R.Play} vs {pr.Truthy("play")}, k {R.K} vs {pr.Str("k")}"; }
            }
            // Renovate (stage 6): the room's pieces, the selection, the light and surfaces, the next id
            if (fr.Obj("ed") is JObj ed)
            {
                edN++;
                var mine = Canon(new JObj { ["eSel"] = sim.ESel, ["items"] = hs.H.Obj("rooms")?[T.Str("room")] ?? new List<object>(), ["lx"] = hs.H["lx"] ?? new JObj(), ["lz"] = hs.H["lz"] ?? new JObj(), ["surf"] = hs.H["surf"] ?? new JObj(), ["rtex"] = hs.H["rtex"] ?? new JObj(), ["lOff"] = hs.H["lOff"] ?? new JObj(), ["uid"] = hs.H["uid"] });
                var theirs = Canon(ed);
                if (mine != theirs) { bad++; if (first == null) { int i = 0; while (i < mine.Length && i < theirs.Length && mine[i] == theirs[i]) i++; first = $"frame {f} edit: C# …{mine.Substring(Math.Max(0, i - 120), Math.Min(260, mine.Length - Math.Max(0, i - 120)))}\n   page …{theirs.Substring(Math.Max(0, i - 120), Math.Min(260, theirs.Length - Math.Max(0, i - 120)))}"; } }
            }
            foreach (JObj o in fr.Arr("cs"))
            {
                var c = sim.Cs.Find(x => x.Key == o.Str("key"));
                var why = new List<string>();
                void Num(string n, double a, double b) { if (Math.Abs(a - b) > 1e-6) why.Add($"{n} {a} vs {b}"); }
                void Str(string n, string a, string b) { if (a != b) why.Add($"{n} {a} vs {b}"); }
                Num("x", c.X, o.Num("x")); Num("y", c.Y, o.Num("y")); Num("spin", c.Spin, o.Num("spin")); Num("lift", c.Lift, o.Num("lift")); Num("liftTo", c.LiftTo, o.Num("liftTo"));
                Str("mode", c.Mode, o.Str("mode")); Str("seat", c.Seat, o.Str("seat")); Str("useItem", c.UseItem, o.Str("useItem")); Str("wSt", c.WSt, o.Str("wSt")); Str("napSt", c.NapSt, o.Str("napSt"));
                Num("z", c.Z ?? -1, o["z"] is double zz ? zz : -1); Num("useEnd", c.UseEnd, o.Num("useEnd")); Num("eatEnd", c.EatEnd, o.Num("eatEnd"));
                foreach (var k in new[] { "h", "c", "e", "f" }) Num("N." + k, c.N[k], o.Obj("N").Num(k));
                if (vis.Contains(c.Key)) foreach (var k in o.Obj("ext").Keys) Num("ext." + k, c.Ext.TryGetValue(k, out var v) ? v : 0, o.Obj("ext").Num(k));
                if (why.Count > 0) { bad++; first ??= $"frame {f} {c.Key}: {string.Join("; ", why)}"; }
            }
        }
        var pagePlays = T.Arr("plays").ConvertAll(o => { var l = (List<object>)o; return $"{(int)(double)l[0]} {l[1]} {l[2]}"; });
        bool playsOk = string.Join("|", plays) == string.Join("|", pagePlays);
        Console.WriteLine($"acts: {frames.Count} frames; plays C# [{string.Join(", ", plays)}]" + (playsOk ? " = page" : $" vs page [{string.Join(", ", pagePlays)}]") + $"; toasts [{string.Join(", ", toasts)}]" + (edN > 0 ? $"; Renovate state compared on {edN} frames" : ""));
        Console.WriteLine(bad == 0 && playsOk ? "acts: every creature every frame equal, every play equal" : $"acts: {bad} creature-frames differ; first: {first}");
        return bad == 0 && playsOk ? 0 : 1;
    }

    static void EditOp(HouseCreatures sim, string k, string a, string b, string c)
    {
        double N(string v) => double.Parse(v, System.Globalization.CultureInfo.InvariantCulture);
        double now = sim.Last;
        switch (k)
        {
            case "edit": sim.StartEdit(); break;
            case "done": sim.DoneEdit(now); break;
            case "down": sim.EditDown(a, N(b), N(c), now); break;
            case "move": sim.DragMove(N(a), N(b)); break;
            case "up": sim.DragEnd(); break;
            case "rot": sim.RotStart(); sim.RotSet(sim.ESelItem, N(a), now); sim.RotEnd(); break;
            case "turn": sim.EditRot(now); break;
            case "size": sim.EditSize((int)N(a), b); break;
            case "store": sim.EditStore(now); break;
            case "place": sim.PlaceNew(a); break;
            case "ldown": sim.LightDown(N(a)); break;
            case "lmove": sim.LightMove(N(a)); break;
            case "lup": sim.LightUp(); break;
            case "lsize": sim.LightSize((int)N(a)); break;
            case "lstore": sim.LightStore(); break;
            case "lback": sim.LightBack(a); break;
            case "lmid": sim.LightMid(); break;
            case "rsurf": sim.UseRSurf(a); break;
            default: throw new Exception("unknown op " + k);
        }
    }

    // JSON with sorted keys and numbers to 6 places (the page's and the port's objects compared as data)
    static string Canon(object o)
    {
        if (o is JObj j) { var ks = new List<string>(j.Keys); ks.Sort(string.CompareOrdinal); var parts = new List<string>(); foreach (var key in ks) { var v = j[key]; if (v == HouseJson.Undefined) continue; parts.Add(HouseJson.Stringify(key) + ":" + Canon(v)); } return "{" + string.Join(",", parts) + "}"; }
        if (o is List<object> l) return "[" + string.Join(",", l.ConvertAll(Canon)) + "]";
        if (o is double d) return Math.Round(d, 6).ToString("R", System.Globalization.CultureInfo.InvariantCulture);
        if (o is string str) return HouseJson.Stringify(str);
        if (o is bool bo) return bo ? "true" : "false";
        return "null";
    }
}
