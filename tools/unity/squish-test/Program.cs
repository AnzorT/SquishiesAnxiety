// Checks the Unity port of Squish Time against the app (tools/unity/squish-test):
//   dotnet run -c Release --project tools/unity/squish-test -- toy <ref dir>      the squish's state, frame by frame
//   dotnet run -c Release --project tools/unity/squish-test -- frames <ref dir>   the stage's pictures (CPU reference)
//   dotnet run -c Release --project tools/unity/squish-test -- shader <dir>       the dent shader vs the GLSL on the GPU
//   dotnet run -c Release --project tools/unity/squish-test -- rules <dir>       the rules vs the JS
//   dotnet run -c Release --project tools/unity/squish-test -- hud <dir>          the HUD vs the app's screen
// <ref dir> comes from ref.mjs (the app's own stage, driven frame by frame); shader.mjs, rules.mjs and hud.mjs
// write the others (hud.mjs: into ref/, from tools/unity/export-squish.mjs).
using System;
using System.IO;

static class Program
{
    public static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
    public static string Res(string p) => Path.Combine(Root, "unity/Assets/Resources", p);

    static int Main(string[] args)
    {
        switch (args.Length > 0 ? args[0] : "")
        {
            case "toy": return ToyTest.Run(args[1]);
            case "frames": return FramesTest.Run(args[1], args.Length > 2 ? args[2] : null);
            case "shader": return ShaderTest.Run(args[1]);
            case "rules": return RulesTest.Run(args[1]);
            case "hud": return HudTest.Run(args[1]);
        }
        Console.WriteLine("usage: toy|frames|shader|rules|hud <dir>");
        return 2;
    }
}
