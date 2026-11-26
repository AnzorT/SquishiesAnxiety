// `mapframe`: the house map as the app shows it (its SMIL paused at the moment menu.js freezes it) against Unity's
// (House/HouseMap.cs MapSvg, the same moment sampled by House/Smil.cs), for each fixture map-frozen.mjs captured
// (tools/unity/house-test/out/mapframe-<fixture>.png / .json): the share of pixels that differ visibly (any channel
// > 24), Unity's picture and a diff written next to it; and the same with the SMIL left out (as Unity drew it before),
// for comparison.
//   node tools/unity/rig/bundle.mjs && node tools/unity/house/map-frozen.mjs
//   dotnet run -c Release --project tools/unity/house-test -- mapframe
using System;
using System.IO;
using System.Linq;
using SquishSquad.Creatures.Js;
using SquishSquad.House;
using SquishSquad.Vector;

static partial class Program
{
    static int MapFrame()
    {
        string work = Path.Combine(Repo, "webgame/test/out/unity-webgame");
        if (!RigHost.Boot(p => { var f = Path.Combine(work, p); return File.Exists(f) ? File.ReadAllText(f) : null; })) { Console.WriteLine("the rig didn't start"); return 2; }
        for (int i = 0; i < 20; i++) RigHost.Frame(40);
        HouseDraw.Eval = RigHost.HouseEval;
        ReferenceRaster.LoadImage = href => LoadPng(href);
        var tpl = File.ReadAllText(Path.Combine(Res, "map-template.html"));
        string dir = Path.Combine(Repo, "tools/unity/house-test/out");
        int bad = 0;
        foreach (var f in Directory.GetFiles(dir, "mapframe-*.json").OrderBy(x => x))
        {
            var j = (JObj)HouseJson.Parse(File.ReadAllText(f)); string name = Path.GetFileNameWithoutExtension(f);
            var vals = HouseJson.Parse(HouseDraw.Eval("__house.map(" + HouseJson.Stringify(HouseJson.Stringify(j.Obj("st"))) + ")")) as JObj;
            var (w, h, app) = Png.Read(Path.Combine(dir, name + ".png"));
            double Diff(string svg, string outName)
            {
                var root = SvgMarkup.Parse(svg); PatternExpand.Expand(root);
                var scene = SvgScene.Compile(root, w, h, Affine.Identity, href => { var p = LoadPng(href); return p.px == null ? ((int, int)?)null : (p.w, p.h); });
                var mine = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, w, h, 2), 2, w, h);
                Png.Write(Path.Combine(dir, outName + ".unity.png"), w, h, mine);
                var dif = new byte[w * h * 4]; int n = 0;
                for (int i = 0; i < w * h * 4; i += 4)
                {
                    // (over the page's clear background: both composed on white)
                    float aa = app[i + 3] / 255f, am = mine[i + 3] / 255f; int d = 0;
                    for (int c = 0; c < 3; c++) d = Math.Max(d, (int)Math.Abs((app[i + c] * aa + 255 * (1 - aa)) - (mine[i + c] * am + 255 * (1 - am))));
                    bool b = d > 24; if (b) n++;
                    byte g = (byte)(app[i] * 0.3 + 150); dif[i] = b ? (byte)255 : g; dif[i + 1] = b ? (byte)0 : g; dif[i + 2] = b ? (byte)60 : g; dif[i + 3] = 255;
                }
                Png.Write(Path.Combine(dir, outName + ".diff.png"), w, h, dif);
                return 100.0 * n / (w * h);
            }
            File.WriteAllText(Path.Combine(dir, name + ".unity.svg"), HouseCreatures.MapSvg(tpl, vals));
            File.WriteAllText(Path.Combine(dir, name + ".unity-raw.svg"), HouseCreatures.MapSvg(tpl, vals, null));   // (for drawing in Chrome: tools/unity/house/map-frozen.mjs --svg)
            double now = Diff(HouseCreatures.MapSvg(tpl, vals), name), was = Diff(HouseCreatures.MapSvg(tpl, vals, null), name + "-unfrozen");
            Console.WriteLine($"{name,-26} {now,6:0.00} % of pixels differ visibly  (with the SMIL left out, as before: {was:0.00} %)");
            if (now > 3) bad++;
        }
        return bad == 0 ? 0 : 1;
    }
}
