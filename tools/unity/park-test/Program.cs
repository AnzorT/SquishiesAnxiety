// node tools/unity/export-park.mjs, then:
//   dotnet run -c Release --project tools/unity/park-test [-- <W> <H>]
// Runs the Unity carousel's own code (unity/Assets/Scripts/Menu/ParkModel.cs: placement, transitions, keyframes) for
// the moments the exporter screenshotted in the app (each game in the middle at rest, the carousel coming in, a change
// of game) and writes what it would draw (draws.json), then compose.py draws that over the app's park without the
// carousel with Pillow and counts the pixels that differ visibly from the app's screenshot.
// With a W and H, it writes a picture of the carousel at rest on that screen shape instead (no comparison).
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Menu;

static class Program
{
    static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));

    static int Main(string[] args)
    {
        var opts = new JsonSerializerOptions { IncludeFields = true };
        var layout = JsonSerializer.Deserialize<ParkLayout>(File.ReadAllText(Path.Combine(Root, "unity/Assets/Resources/Park/park.json")), opts);
        var shots = JsonDocument.Parse(File.ReadAllText(Path.Combine(Root, "unity/Assets/Resources/Park/park.json"))).RootElement.GetProperty("shots");
        var outDir = Path.Combine(Root, shots.GetProperty("dir").GetString(), "unity");
        Directory.CreateDirectory(outDir);
        var scenes = new List<object>();
        int n = layout.games.Length;
        double W = layout.reference.px[0], H = layout.reference.px[1];
        if (args.Length >= 2)
        {
            W = double.Parse(args[0]); H = double.Parse(args[1]);
            for (int i = 0; i < n; i++)
            {
                var m = new ParkModel(layout, W, H, i, 0, true);
                double t = 1900 * 6;
                scenes.Add(Scene($"shape-{W}x{H}-{layout.games[i].id}", null, m.Draws(t)));
            }
        }
        else
        {
            // at rest, each game in the middle (the app opened straight into the park; Squish Time's keyframes at 0)
            for (int i = 0; i < n; i++)
            {
                var m = new ParkModel(layout, W, H, i, 0, true);
                scenes.Add(Scene("rest-" + layout.games[i].id, "park-" + layout.games[i].id + ".png", m.Draws(1900 * 6)));
            }
            foreach (var mo in shots.GetProperty("motion").EnumerateArray())
            {
                string kind = mo.GetProperty("kind").GetString();
                double ms = mo.GetProperty("ms").GetDouble();
                ParkModel m;
                if (kind == "in")
                {
                    // .in comes 33 ms after the carousel is made: made at -33, so the transitions start at 0
                    m = new ParkModel(layout, W, H, mo.GetProperty("from").GetInt32(), -33, false);
                }
                else
                {
                    m = new ParkModel(layout, W, H, mo.GetProperty("from").GetInt32(), -100000, true);
                    m.Go(mo.GetProperty("to").GetInt32(), 0);
                }
                m.SquishEpoch = ms;   // (the exporter holds the endless keyframes at 0)
                // the numbers against what Chrome computed at that moment (transform matrices, opacity, filter)
                double worst = 0;
                int ci = 0;
                foreach (var cs in mo.GetProperty("css").EnumerateArray())
                {
                    var v = m.Css(ci++, ms);
                    double[] Mat(string t) { if (t == "none") return new[] { 1.0, 0, 0, 1, 0, 0 }; return t.Substring(7, t.Length - 8).Split(',').Select(x => double.Parse(x)).ToArray(); }
                    var sm = Mat(cs.GetProperty("slot").GetString()); var gm = Mat(cs.GetProperty("gc").GetString());
                    string f = cs.GetProperty("filter").GetString();
                    double fb = f == "none" ? 1 : double.Parse(f.Substring(11, f.Length - 12));
                    var diffs = new[] { sm[4] - v[0], sm[0] - v[1], cs.GetProperty("slotO").GetDouble() - v[2], gm[4] - v[3] * gm[0] / Math.Max(1e-9, gm[0]) , gm[0] - v[4], cs.GetProperty("gcO").GetDouble() - v[5], fb - v[6] };
                    // (the card's matrix is translateX(a) scale(s): its e is a)
                    diffs[3] = gm[4] - v[3];
                    worst = Math.Max(worst, diffs.Max(Math.Abs));
                }
                Console.WriteLine($"{kind}-{ms}: the cards' transforms, opacities and brightness vs Chrome's computed style: worst difference {worst:0.0000}");
                scenes.Add(Scene($"{kind}-{ms}", mo.GetProperty("file").GetString(), m.Draws(ms)));
            }
        }
        var json = Path.Combine(outDir, "draws.json");
        File.WriteAllText(json, JsonSerializer.Serialize(new { screen = new[] { W, H }, res = Path.Combine(Root, "unity/Assets/Resources/Park"), shots = Path.Combine(Root, shots.GetProperty("dir").GetString()), plate = args.Length >= 2 ? null : shots.GetProperty("plate").GetString(), scenes }));
        var p = Process.Start(new ProcessStartInfo("python3", $"\"{Path.Combine(Root, "tools/unity/park-test/compose.py")}\" \"{json}\" \"{outDir}\"") { UseShellExecute = false });
        p.WaitForExit();
        return p.ExitCode;
    }

    static object Scene(string name, string reference, List<ParkModel.Draw> draws) => new { name, reference, draws = List(draws) };

    static List<object> List(List<ParkModel.Draw> draws) => draws.Where(d => !d.Res.StartsWith("clip:")).Select(d => (object)new
    {
        key = d.Key, res = d.Res, m = new[] { d.M.A, d.M.B, d.M.C, d.M.D, d.M.E, d.M.F }, w = d.W, h = d.H,
        uv = new[] { d.U0, d.V0, d.U1, d.V1 }, opacity = d.Opacity, bright = d.Bright,
        mask = d.Mask, maskM = d.Mask == null ? null : new[] { d.MaskM.A, d.MaskM.B, d.MaskM.C, d.MaskM.D, d.MaskM.E, d.MaskM.F },
        children = d.Children == null ? null : List(d.Children),
    }).ToList();
}
