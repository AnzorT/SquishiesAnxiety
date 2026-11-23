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
