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
}
bool same = Tags(at1) == Tags(RecordedRig.Load("mittens").FrameAt(1f));
Console.WriteLine($"240 frames of 2 creatures in {sw.ElapsedMilliseconds} ms; Mittens {a?.Length} chars, Lumi {b?.Length} chars; Mittens at 1 s has the recording's elements: {same}");
m.Dispose();
l.Dispose();
return a != null && b != null && same ? 0 : 1;
