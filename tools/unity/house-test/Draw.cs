// The runtime drawings in the .NET checks: tools/unity/house/draw-server.mjs (the Rig bundle in Node) behind
// House/HouseDraw.cs's Eval, as PuerTS runs it in Unity.
using System;
using System.Diagnostics;
using System.IO;
using SquishSquad.House;

static class DrawServer
{
    static Process _p;
    public static void Start()
    {
        if (_p != null) return;
        _p = Process.Start(new ProcessStartInfo("node", Path.Combine(Program.Repo, "tools/unity/house/draw-server.mjs")) { RedirectStandardInput = true, RedirectStandardOutput = true, UseShellExecute = false });
        if (_p.StandardOutput.ReadLine() != "\"ready\"") throw new Exception("draw server didn't start");
        HouseDraw.Eval = js =>
        {
            _p.StandardInput.WriteLine(HouseJson.Stringify(js)); _p.StandardInput.Flush();
            return HouseJson.Parse(_p.StandardOutput.ReadLine()) as string;
        };
        AppDomain.CurrentDomain.ProcessExit += (s, e) => { try { _p.Kill(); } catch (Exception) { } };
    }
}
