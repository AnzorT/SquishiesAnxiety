// Runs Creatures/LiveRig.cs (the app's rig code in PuerTS) off Unity, on Resources/Rig from tools/unity/rig/bundle.mjs:
// Mittens and Lumi (whose art is fetched from the bundle) for 8 s at 30 fps, and Mittens' frame at 1 s against its
// recording (the same elements in the same order). QuickJS, since V8 crashes in some sandboxes; run from the output
// folder, where PuerTS's own scripts are:
//   cd tools/unity/rig/live-test && dotnet build && (cd bin/Debug/net8.0 && dotnet LiveTest.dll)
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using SquishSquad.Creatures;
using UnityEngine;

var m = LiveRig.Create("mittens");
var l = LiveRig.Create("lumi");
if (m == null || l == null) { Console.WriteLine("FAIL: the engine or a creature didn't start"); return 1; }
m.Play("idle");
string Tags(string s) => string.Join(",", Regex.Matches(s, "<([a-zA-Z]+)").Select(x => x.Groups[1].Value));
var sw = Stopwatch.StartNew();
string at1 = null, a = null, b = null;
for (int f = 1; f <= 240; f++)
{
    Time.frameCount = f;
    Time.unscaledTimeAsDouble = f / 30.0;
    a = m.FrameAt(0);
    b = l.FrameAt(0);
    if (f == 30) at1 = a;
    if (f == 120) l.Play("dance");
    if (f > 30) m.Ext(new System.Collections.Generic.Dictionary<string, double> { { "spin", f * 3.0 }, { "footL", 2 * Math.Sin(f / 3.0) } });
    m.Fidgets(true);
    _ = m.InFidget();
}
bool same = Tags(at1) == Tags(RecordedRig.Load("mittens").FrameAt(1f));
Console.WriteLine($"240 frames of 2 creatures in {sw.ElapsedMilliseconds} ms; Mittens {a?.Length} chars, Lumi {b?.Length} chars; Mittens at 1 s has the recording's elements: {same}");
// the house's runtime drawings through the same engine (House/HouseDraw.cs): a piece drawn again, named as the export
var wire = typeof(LiveRig).GetMethod("WireHouseDraw", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
wire.Invoke(null, null);
var pieces = (SquishSquad.House.JObj)SquishSquad.House.HouseJson.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(Resources.Root, "House/house-pieces.json")));
int dOk = 0, dAll = 0;
foreach (var key in new[] { "LIV-012|||0", "KIT-012|||0", "BED-012|||0" })
{
    var p = key.Split('|'); var want = pieces.Obj("variants").Obj(key);
    var got = SquishSquad.House.HouseDraw.Variant(p[0], p[1] == "" ? null : p[1], p[2], double.Parse(p[3]), p[0].StartsWith("KIT") ? "kitchen" : p[0].StartsWith("BED") ? "bedroom" : "living");
    dAll++; if (got != null && got.Str("src") == want.Str("src")) dOk++;
}
Console.WriteLine($"house drawings through HouseDraw: {dOk} of {dAll} named as the export");
m.Dispose();
l.Dispose();
return a != null && b != null && same && dOk == dAll ? 0 : 1;
