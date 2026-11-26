// The robot vacuum and a kicked toy, frame by frame (for a video):
//   dotnet run -c Release --project tools/unity/house-test -- vacframes <out dir>
// The decorated fixture's living room by day (tools/unity/house/fixtures/decorated.json, camera at 1), with the Robo-Vac
// & Charging Dock (LIV-136) and a ball added. Driven by Unity's own house code (House/HouseCreatures, HouseVac.cs, the
// toy's roll): the dock tapped (RnTap: the robot out, cleaning), the ball kicked twice while it cleans, the dock tapped
// again (it drives home). Every frame: the room as Unity composes it (the dock's picture by its state, the toys left out),
// the ball's two layers (RoomLayers: its shadow, and the part that spins, about 50 % 60 %), the robot's sprite (the
// dock's drawing's Dr.vac at runtime, its SMIL at 12 frames a second: House/Smil.cs) with its wiggle and jitter, and its
// dust, placed as House/View/HouseVacView.cs and HouseRoomView place them. Over the room (no furniture in front of
// them). 1040 x 480 px, 20 frames a second.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SquishSquad.Creatures.Js;
using SquishSquad.House;
using SquishSquad.Ui;
using SquishSquad.Vector;

static partial class Program
{
    static int VacFrames(string outDir)
    {
        Directory.CreateDirectory(outDir);
        var opts = new System.Text.Json.JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Path.Combine(Repo, "unity/Assets/Resources/Fonts", n + ".json"));
        UiFont.ParseJson = j => System.Text.Json.JsonSerializer.Deserialize<UiFontData>(j, opts);
        SvgText.Install();
        string work = Path.Combine(Repo, "webgame/test/out/unity-webgame");
        if (!RigHost.Boot(p => { var f = Path.Combine(work, p); return File.Exists(f) ? File.ReadAllText(f) : null; })) { Console.WriteLine("the rig didn't start: " + string.Join("; ", RigHost.BootErrors)); return 2; }
        for (int i = 0; i < 20; i++) RigHost.Frame(40);
        HouseDraw.Eval = RigHost.HouseEval;
        RigHost.HouseError = (n, e) => Console.WriteLine("[house] " + n + ": " + e.Message);

        var d = Data(); var tpl = Template();
        var fx = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Repo, "tools/unity/house/fixtures/decorated.json")));
        var hs = new HouseSave(d);
        hs.Load(fx.Str("house"), (int)fx.Obj("profile").Num("level"), new List<int>(), "living");
        if (hs.Cur != "living") hs.EnterRoom("living");
        hs.H.Obj("night").Remove("living");
        var items = (List<object>)hs.H.Obj("rooms")["living"];
        var dock = new JObj { ["id"] = "vac1", ["t"] = "R:LIV-136", ["x"] = Env("VAC_X", 160.0), ["y"] = Env("VAC_Y", 300.0), ["r"] = -30.0 };
        items.Add(dock);
        var toys = (List<object>)hs.H.Obj("toys")["living"];
        var ball = new JObj { ["id"] = "livingt0", ["k"] = "ball", ["x"] = 560.0, ["y"] = 318.0 };
        toys.Add(ball);

        var walk = new HouseWalk(File.ReadAllText(Path.Combine(Res, "walk.json")));
        var sim = new HouseCreatures(hs, walk);
        RoomModel model = null;
        JObj Build() { model = new RoomModel(hs) { StateOf = sim.RStOf, VarOf = sim.VarOf }; var v = model.Build("living"); v["camK"] = 1.0; return v; }
        sim.RnI = id => model != null && model.RnI.TryGetValue(id, out var ri) ? ri : null;

        const int PW = 1040, PH = 480, FPS = 20; double k0 = PW / 852.0;
        ReferenceRaster.LoadImage = href => LoadPng(href);
        var comp = Composer(d); var files = comp.PicSvg; comp.PicSvg = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : files(n);
        var rooms = new Dictionary<string, ReferenceRaster.Buffer>();
        ReferenceRaster.Buffer Room()
        {
            // (the room without its toys: the ball is drawn on its own)
            string key = sim.RStOf(dock, d.Row("LIV-136")) ?? "";
            if (rooms.TryGetValue(key, out var b)) return b;
            var saved = new List<object>(toys); toys.Clear();
            var vals = Build();
            toys.AddRange(saved);
            var svg = comp.Compose(tpl.Render(vals), vals.Obj("rt")?.Str("fenceHtml"));
            b = rooms[key] = Raster(svg, 852, 393, Affine.ScaleBy(k0, k0));
            Console.WriteLine($"room with the dock \"{key}\" drawn");
            return b;
        }
        ReferenceRaster.Buffer Raster(string svg, double w, double h, Affine m)
        {
            var root = SvgMarkup.Parse(svg);
            PatternExpand.Expand(root);
            var scene = SvgScene.Compile(root, w, h, m, href => { var p = LoadPng(href); return p.px == null ? ((int, int)?)null : (p.w, p.h); });
            return ReferenceRaster.Render(scene, PW, PH, 1);
        }
        // the ball's layers, as HouseRoomView cuts them (its region and box at its rest spot)
        List<RoomLayers.Layer> ballLayers = null; double bx0 = 0, by0 = 0;
        void Cut()
        {
            var vals = Build();
            // (HouseRoomView.View: the frame and its margins at the camera's widest, 0.85)
            var a = HouseCamera.ToBox(-HouseFrame.MX, -HouseFrame.MY, 0.85); var b = HouseCamera.ToBox(852 + HouseFrame.MX, 393 + HouseFrame.MY, 0.85);
            double vx0 = Math.Floor(a.x), vy0 = Math.Floor(a.y + HouseFrame.BoxTop), view1 = Math.Ceiling(b.x), view2 = Math.Ceiling(b.y + HouseFrame.BoxTop);
            var L = RoomLayers.Split(tpl.Render(vals), new[] { vx0, vy0, view1 - vx0, view2 - vy0 }, () => Composer(d));
            ballLayers = L.Pieces.Where(p => p.Kind == "toy" || p.Kind == "toyshadow").ToList();
            bx0 = ball.Num("x"); by0 = ball.Num("y");
        }
        Cut();
        Console.WriteLine($"the ball: {ballLayers.Count} layers ({string.Join(", ", ballLayers.Select(l => l.Kind))})");

        if (Environment.GetEnvironmentVariable("VAC_CHECK") == "1")
        {
            // the split's check: the room drawn whole (the ball in it) against the room without it and the ball's two
            // layers over it, unmoved: the pixels that differ visibly
            var whole = Build(); var wsvg = comp.Compose(tpl.Render(whole), whole.Obj("rt")?.Str("fenceHtml"));
            var A = Raster(wsvg, 852, 393, Affine.ScaleBy(k0, k0));
            var Bf = new ReferenceRaster.Buffer(PW, PH); var r0 = Room(); Array.Copy(r0.P, Bf.P, r0.P.Length);
            foreach (var l in ballLayers) Over(Bf, Raster(l.Svg, l.Region[2], l.Region[3], Affine.ScaleBy(k0, k0) * Affine.Translate(l.Region[0], l.Region[1])));
            var pa = ReferenceRaster.Resolve(A, 1, PW, PH); var pb = ReferenceRaster.Resolve(Bf, 1, PW, PH);
            int bad = 0, near = 0;
            for (int i = 0; i < pa.Length; i += 4) { int dd = Math.Max(Math.Abs(pa[i] - pb[i]), Math.Max(Math.Abs(pa[i + 1] - pb[i + 1]), Math.Abs(pa[i + 2] - pb[i + 2]))); if (dd > 24) bad++; else if (dd > 0) near++; }
            Console.WriteLine($"the ball split: {bad} px differ visibly, {near} slightly, of {PW * PH}");
            Png.Write(Path.Combine(outDir, "check-whole.png"), PW, PH, pa); Png.Write(Path.Combine(outDir, "check-split.png"), PW, PH, pb);
            return bad == 0 ? 0 : 1;
        }
        var G = hs.Geo;
        // the script (ms): the dock tapped at 1 s, the ball kicked at 5 and 9 s, the dock tapped again at 13 s, the end
        // 2.5 s after it's parked
        double now = 0, parked = -1; int f = 0; bool tapped = false, kick1 = false, kick2 = false, home = false;
        while (true)
        {
            now += 1000.0 / FPS;
            sim.Tick(now);
            if (!tapped && now >= 1000) { tapped = true; Console.WriteLine("tap: " + sim.RnTap(dock, null, now) + ", out: " + sim.VacBusy("vac:vac1")); }
            if (!kick1 && now >= 5000) { kick1 = true; sim.Kick(ball, now); }
            if (!kick2 && now >= 9000) { kick2 = true; sim.Kick(ball, now); }
            if (!home && now >= 13000) { home = true; sim.RnTap(dock, null, now); Console.WriteLine("tap again: heading home"); }
            if (home && parked < 0 && !sim.VacBusy("vac:vac1") && !sim.Vacs.ContainsKey("vac:vac1")) parked = now;
            if (parked >= 0 && now >= parked + 2500) break;
            if (now > 40000) break;

            var frame = new ReferenceRaster.Buffer(PW, PH);
            var room = Room(); Array.Copy(room.P, frame.P, room.P.Length);
            // the ball: moved, scaled for its depth, its top part turned
            {
                double x = ball.Num("x"), y = ball.Num("y"), hop = 0, spin = 0;
                if (sim.Rolling != null) { var r = sim.RollAt(now); x = r.x; y = r.y; hop = r.hop; spin = r.spin; }
                double rel = G.SAt(y) / G.SAt(by0);
                foreach (var l in ballLayers)
                {
                    var B = l.Box; double cx = B[0] + B[2] / 2, cy = B[1] + B[3], lift = 16.2 * (B[3] / 40), rot = l.Kind == "toy" ? spin : 0;
                    double dx = x - bx0, dy = y - by0 - hop;
                    var m = Affine.ScaleBy(k0, k0) * Affine.Translate(cx + dx, cy + dy) * Affine.ScaleBy(rel, rel) * Affine.Translate(0, -lift) * Affine.Rotate(rot) * Affine.Translate(-cx, -(cy - lift)) * Affine.Translate(l.Region[0], l.Region[1]);
                    Over(frame, Raster(l.Svg, l.Region[2], l.Region[3], m));
                }
            }
            // the robot and its dust
            if (sim.Vacs.TryGetValue("vac:vac1", out var vac) && !vac.Dead)
            {
                var o = HouseDraw.Vac("LIV-136", dock.Num("r"), "living");
                var bb = o.Arr("bb").Select(Convert.ToDouble).ToArray();
                var nodes = Smil.Parse(o.Str("src"));
                double t = Math.Floor(Math.Max(0, now - vac.T0) / 1000 * 12) / 12;
                var sb = new StringBuilder(); foreach (var n in nodes) Smil.Write(n, sb, t);
                foreach (var dd in vac.Dusts)
                {
                    var (op, sc, ty) = HouseVac.DustAt(dd, now);
                    var dm = Affine.ScaleBy(k0, k0) * Affine.Translate(0, HouseFrame.BoxTop) * Affine.Translate(dd.L + dd.Size / 2, dd.T + dd.Size / 2) * Affine.ScaleBy(sc, sc) * Affine.Translate(0, ty) * Affine.ScaleBy(dd.Size / 100, dd.Size / 100) * Affine.Translate(-50, -50);
                    Over(frame, Raster(Dust, 100, 100, dm), (float)op);
                }
                var (x, y, s, z, wig, lift, jit) = vac.Pose(now);
                var vm = Affine.ScaleBy(k0, k0) * Affine.Translate(0, HouseFrame.BoxTop) * Affine.Translate(x, y) * Affine.ScaleBy(s, s) * Affine.Rotate(wig) * Affine.Translate(0, -lift)
                    * Affine.Translate(bb[0] + bb[2] / 2, bb[1] + bb[3] / 2) * Affine.Rotate(jit) * Affine.Translate(-bb[2] / 2, -bb[3] / 2);
                Over(frame, Raster(sb.ToString(), bb[2], bb[3], vm));
            }
            Png.Write(Path.Combine(outDir, $"frame-{f++:0000}.png"), PW, PH, ReferenceRaster.Resolve(frame, 1, PW, PH));
            if (f % 40 == 0) Console.WriteLine($"{f} frames ({now / 1000:0.0} s){(sim.Vacs.TryGetValue("vac:vac1", out var vv) ? ", robot " + vv.Mode : "")}");
        }
        Console.WriteLine($"{f} frames in {outDir}");
        return 0;
    }

    const string Dust = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 100 100\"><defs><radialGradient id=\"vd\" gradientUnits=\"userSpaceOnUse\" cx=\"50\" cy=\"50\" r=\"70.71\">"
        + "<stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.18\" stop-color=\"#ffffff\"/><stop offset=\"0.34\" stop-color=\"#dff6ff\" stop-opacity=\"0.7\"/><stop offset=\"0.68\" stop-color=\"#dff6ff\" stop-opacity=\"0\"/></radialGradient></defs>"
        + "<polygon points=\"50,0 61,39 100,50 61,61 50,100 39,61 0,50 39,39\" fill=\"url(#vd)\"/></svg>";

    static void Over(ReferenceRaster.Buffer into, ReferenceRaster.Buffer b, float op = 1)
    {
        for (int i = 0; i < into.P.Length; i += 4)
        {
            float sa = b.P[i + 3] * op; if (sa <= 0) continue;
            float k = 1 - sa;
            into.P[i] = b.P[i] * op + into.P[i] * k; into.P[i + 1] = b.P[i + 1] * op + into.P[i + 1] * k;
            into.P[i + 2] = b.P[i + 2] * op + into.P[i + 2] * k; into.P[i + 3] = sa + into.P[i + 3] * k;
        }
    }
}
