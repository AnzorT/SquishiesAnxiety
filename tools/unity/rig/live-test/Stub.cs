// Just enough of UnityEngine for Creatures/LiveRig.cs and RigFrames.cs to run on .NET.
namespace UnityEngine
{
    public class Object { }
    public class TextAsset : Object { public byte[] bytes; }
    public static class Resources
    {
        public static string Root = System.IO.Path.Combine(System.AppContext.BaseDirectory, "../../../../../../../unity/Assets/Resources/");
        public static T Load<T>(string p) where T : Object { var f = Root + p + ".bytes"; return System.IO.File.Exists(f) ? (T)(Object)new TextAsset { bytes = System.IO.File.ReadAllBytes(f) } : null; }
        public static void UnloadAsset(Object o) { }
    }
    public static class Debug { public static void LogWarning(object m) => System.Console.WriteLine("WARN " + m); public static void Log(object m) => System.Console.WriteLine(m); }
    public static class Time { public static int frameCount; public static double unscaledTimeAsDouble; }
    public static class Mathf { public static int Max(int a, int b) => System.Math.Max(a, b); public static int Min(int a, int b) => System.Math.Min(a, b); }
}
