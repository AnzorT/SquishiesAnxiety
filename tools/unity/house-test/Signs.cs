// A sign written in Renovate, frame by frame (for a video):
//   dotnet run -c Release --project tools/unity/house-test -- signframes <out dir>
// The decorated fixture's living room (tools/unity/house/fixtures/decorated.json, by day) with its sign piece made the
// Glowing Neon Script Wall Quote (LIV-105); the sign's text set frame by frame as a player would write it (the editor
// open, the text cleared, "Squish Squad" typed, the "Welcome Home" preset tapped, Done); every frame the room drawn as
// Unity draws it (RoomModel, the template, RoomCompose), the sign's drawing made at runtime by the house's own drawing
// code compiled to C# (RigHost.HouseEval, Unity's HouseDraw.Eval), and the sign editor's panel (House/SignPanel.cs)
// over it. 1040 x 480 px, 10 frames a second.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SquishSquad.Creatures.Js;
using SquishSquad.House;
using SquishSquad.Ui;
using SquishSquad.Vector;

static partial class Program
{
    static double Env(string k, double d) => double.TryParse(Environment.GetEnvironmentVariable(k), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var v) ? v : d;

    static int SignFrames(string outDir)
    {
        Directory.CreateDirectory(outDir);
        var opts = new System.Text.Json.JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Path.Combine(Repo, "unity/Assets/Resources/Fonts", n + ".json"));
        UiFont.ParseJson = j => System.Text.Json.JsonSerializer.Deserialize<UiFontData>(j, opts);
        SvgText.Install();   // (<text> in the house's drawings, as Unity draws it)
        // the drawing code, as Unity runs it
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
        var sign = ((List<object>)hs.H.Obj("rooms")["living"]).Cast<JObj>().First(it => it.Str("id") == "i29");
        sign["t"] = "R:LIV-105";
        // (for the video: on the back wall's right, where the editor doesn't cover it, and bigger)
        sign["x"] = Env("SIGN_X", 655); sign["e"] = Env("SIGN_E", 120); sign["sz"] = Env("SIGN_SZ", 2.6);
        var row = d.Row("LIV-105");
        var presets = ((List<object>)row["texts"]).Select(o => (string)o).ToList();
        // the script: (the text, the panel shown, typing, the part held)
        var steps = new List<(string txt, bool panel, bool typing, string held)>();
        void Hold(string t, bool panel, bool typing, int n, string held = null) { for (int i = 0; i < n; i++) steps.Add((t, panel, typing, held)); }
        string start = row.Str("txt0") ?? "Home Sweet Home";
        Hold(start, false, false, 8);                     // the room, the sign as it is
        Hold(start, true, false, 8);                      // Aa: the editor opens
        Hold(start, true, true, 4, "sg-input");           // the text box tapped
        foreach (var t in new[] { "Home Sweet", "Home", "" }) Hold(t, true, true, 2);   // cleared
        const string typed = "Squish Squad";
        foreach (var t in new[] { "Squ", "Squish", "Squish Sq", typed }) Hold(t, true, true, 4);   // typed
        Hold(typed, true, true, 10);
        int wi = presets.IndexOf("Welcome Home");
        Hold(typed, true, false, 2, "sg-pre:" + wi);      // a preset tapped
        Hold("Welcome Home", true, false, 10);
        Hold("Welcome Home", true, false, 2, "sg-done");  // Done
        Hold("Welcome Home", false, false, 12);

        const int PW = 1040, PH = 480; int SS = (int)Env("SIGN_SS", 1);
        double k0 = PW / 852.0;
        if (Environment.GetEnvironmentVariable("SIGN_ONE") == "1") steps = steps.Take(1).ToList();
        ReferenceRaster.LoadImage = href => LoadPng(href);
        var rooms = new Dictionary<string, ReferenceRaster.Buffer>();
        int f = 0;
        foreach (var (txt, panel, typing, held) in steps)
        {
            if (!rooms.TryGetValue(txt, out var room))
            {
                sign["txt"] = txt;
                var vals = new RoomModel(hs).Build("living");
                // (pictures made at runtime first, as Unity's HouseRoomView composes)
                var comp = Composer(d); var files = comp.PicSvg; comp.PicSvg = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : files(n);
                var svg = comp.Compose(tpl.Render(vals), vals.Obj("rt")?.Str("fenceHtml"));
                var root = SvgMarkup.Parse(svg);
                PatternExpand.Expand(root);
                var scene = SvgScene.Compile(root, 852 * k0, 393 * k0, Affine.Identity, href => { var p = LoadPng(href); return p.px == null ? ((int, int)?)null : (p.w, p.h); });
                room = rooms[txt] = ReferenceRaster.Render(scene, PW, PH, SS);
                Console.WriteLine($"room with \"{txt}\" drawn");
            }
            var frame = new ReferenceRaster.Buffer(room.W, room.H);
            Array.Copy(room.P, frame.P, room.P.Length);
            if (panel)
            {
                var ed = new HouseCreatures.SignEd { Val = txt, Style = row.Str("name"), Presets = presets, Max = 26 };
                bool caret = typing && (f / 5) % 2 == 0;
                var ps = SignPanel.Draw(ed, typing, caret, held);
                double ph = ps.H;
                var m = Affine.ScaleBy(k0, k0) * Affine.Translate(SignPanel.X + SignPanel.W / 2, SignPanel.Y + ph / 2) * Affine.Rotate(-1) * Affine.Translate(-SignPanel.W / 2, -ph / 2);
                var pscene = SvgScene.Compile(SvgMarkup.Parse(ps.Markup), SignPanel.W, ph, m, null);
                var pb = ReferenceRaster.Render(pscene, PW, PH, SS);
                for (int i = 0; i < frame.P.Length; i += 4)
                {
                    float a = pb.P[i + 3]; if (a <= 0) continue; float kk = 1 - a;
                    frame.P[i] = pb.P[i] + frame.P[i] * kk; frame.P[i + 1] = pb.P[i + 1] + frame.P[i + 1] * kk; frame.P[i + 2] = pb.P[i + 2] + frame.P[i + 2] * kk; frame.P[i + 3] = a + frame.P[i + 3] * kk;
                }
            }
            Png.Write(Path.Combine(outDir, $"frame-{f++:0000}.png"), PW, PH, ReferenceRaster.Resolve(frame, SS, PW, PH));
        }
        Console.WriteLine($"{f} frames in {outDir}");
        return 0;
    }
}

static partial class Program
{
    //   dotnet run -c Release --project tools/unity/house-test -- housepics <out dir>
    // The house map (House/HouseMap.cs's template filled with __house.map's values) and the beach (lv30-beach's room,
    // __house.beach's scene over it, its moving parts at their first moment) by day and at night, with the house's
    // drawing code compiled to C# (RigHost.HouseEval, Unity's HouseDraw.Eval): what Unity couldn't draw before.
    static int HousePics(string outDir)
    {
        Directory.CreateDirectory(outDir);
        string work = Path.Combine(Repo, "webgame/test/out/unity-webgame");
        var opts = new System.Text.Json.JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Path.Combine(Repo, "unity/Assets/Resources/Fonts", n + ".json"));
        UiFont.ParseJson = j => System.Text.Json.JsonSerializer.Deserialize<UiFontData>(j, opts);
        SvgText.Install();
        if (!RigHost.Boot(p => { var f = Path.Combine(work, p); return File.Exists(f) ? File.ReadAllText(f) : null; })) return 2;
        for (int i = 0; i < 20; i++) RigHost.Frame(40);
        HouseDraw.Eval = RigHost.HouseEval;
        RigHost.HouseError = (n, e) => Console.WriteLine("[house] " + n + ": " + e.Message);
        ReferenceRaster.LoadImage = href => LoadPng(href);
        const int PW = 1040, PH = 480, SS = 2; double k0 = PW / 852.0;
        byte[] Draw(string svg)
        {
            var root = SvgMarkup.Parse(svg); PatternExpand.Expand(root);
            var scene = SvgScene.Compile(root, 852 * k0, 393 * k0, Affine.Identity, href => { var p = LoadPng(href); return p.px == null ? ((int, int)?)null : (p.w, p.h); });
            return ReferenceRaster.Resolve(ReferenceRaster.Render(scene, PW, PH, SS), SS, PW, PH);
        }
        // the map, as a level-24 house with the starter rooms open and Mittens in the living room
        var tpl = File.ReadAllText(Path.Combine(Res, "map-template.html"));
        foreach (var (name, st) in new[] {
            ("map-lv24-sunny", "{\"lvl\":24,\"cur\":\"living\",\"open\":[\"living\",\"bedroom\",\"bathroom\",\"kitchen\",\"movie\",\"dance\"],\"b0\":{},\"cs\":[{\"key\":\"mittens\",\"name\":\"Mittens\",\"room\":\"living\",\"N\":{\"h\":80,\"c\":60,\"e\":70,\"f\":50},\"id\":1}],\"season\":\"sunny\",\"mapIn\":true}"),
            ("map-lv5-snowy", "{\"lvl\":5,\"cur\":\"living\",\"open\":[\"living\",\"bedroom\"],\"b0\":{},\"cs\":[],\"season\":\"snowy\",\"mapIn\":true}") })
        {
            var vals = HouseJson.Parse(HouseDraw.Eval("__house.map(" + HouseJson.Stringify(st) + ")")) as JObj;
            if (vals == null) { Console.WriteLine(name + ": no values"); continue; }
            Png.Write(Path.Combine(outDir, name + ".png"), PW, PH, Draw(HouseCreatures.MapSvg(tpl, vals)));
            Console.WriteLine(name + " drawn");
        }
        // the beach: lv30-beach's beach room, the scene injected as the room svg's last child (HouseBeachView)
        var d = Data(); var room = Template();
        var fx = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Repo, "tools/unity/house/fixtures/lv30-beach.json")));
        foreach (var night in new[] { false, true })
        {
            var hs = new HouseSave(d);
            hs.Load(fx.Str("house"), (int)fx.Obj("profile").Num("level"), new List<int>(), "beach");
            if (hs.Cur != "beach") hs.EnterRoom("beach");
            if (night) hs.H.Obj("night")["bedroom"] = 1.0; else hs.H.Obj("night").Remove("bedroom");
            var vals = new RoomModel(hs).Build("beach");
            var comp = Composer(d); var files = comp.PicSvg; comp.PicSvg = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : files(n);
            var svg = comp.Compose(room.Render(vals), vals.Obj("rt")?.Str("fenceHtml"));
            var o = "{\"season\":\"sunny\",\"night\":" + (night ? "true" : "false") + ",\"sand\":null,\"pier\":null,\"light\":null}";
            var be = HouseJson.Parse(HouseDraw.Eval("__house.beach(" + HouseJson.Stringify(o) + ")")) as JObj;
            if (be != null)
            {
                // (SMIL dropped: the first moment)
                string body = System.Text.RegularExpressions.Regex.Replace(be.Str("body") ?? "", "<(animate|animateTransform|animateMotion|set)\\b[^>]*/>", "");
                body = System.Text.RegularExpressions.Regex.Replace(body, "<(animate|animateTransform|animateMotion|set)\\b[^>]*>[\\s\\S]*?</\\1>", "");
                int end = svg.LastIndexOf("</svg>", StringComparison.Ordinal);
                svg = svg.Substring(0, end) + "<defs>" + be.Str("defs") + "</defs>" + body + svg.Substring(end);
            }
            var nm = "beach-" + (night ? "night" : "day");
            Png.Write(Path.Combine(outDir, nm + ".png"), PW, PH, Draw(svg));
            Console.WriteLine(nm + " drawn" + (be == null ? " (no beach scene)" : ""));
        }
        return 0;
    }
}
