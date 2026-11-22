// Entry points for CI (.github/workflows/unity.yml), also usable from the editor's "Squish Squad" menu.
//   -executeMethod SquishSquad.EditorTools.CiBuild.CaptureMenu   screenshots of the Main Menu -> CiOut/*.png
//   -executeMethod SquishSquad.EditorTools.CiBuild.BuildAndroid  the APK -> Builds/Android/SquishSquad.apk (or -customBuildPath)
using System;
using System.IO;
using SquishSquad.Menu;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SquishSquad.EditorTools
{
    public static class CiBuild
    {
        // the reference phone first (compared with unity/Reference/menu-a15.png), then other screen shapes to look at
        static readonly (string name, int w, int h)[] Screens =
        {
            ("menu-a15", 2340, 1080),       // Galaxy A15 landscape
            ("menu-2400x1080", 2400, 1080), // a 20:9 phone
            ("menu-1920x1080", 1920, 1080), // 16:9
            ("menu-2048x1536", 2048, 1536), // a 4:3 tablet
        };

        [MenuItem("Squish Squad/Capture menu screenshots")]
        public static void CaptureMenu()
        {
            try
            {
                ProjectSetup.Apply();
                var layout = MenuLayout.Load();
                var outDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "CiOut"));
                Directory.CreateDirectory(outDir);
                EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                foreach (var (name, w, h) in Screens)
                {
                    var root = new GameObject("Capture").transform;
                    var cam = MenuScreen.CreateCamera(root);
                    MenuScreen.FitCamera(cam, w, h);
                    var view = new MenuView(layout, root, w, h, layout.reference.level, layout.reference.season);
                    view.Tick(0f);
                    var png = Render(cam, w, h);
                    File.WriteAllBytes(Path.Combine(outDir, name + ".png"), png);
                    Debug.Log($"[CiBuild] {name}.png {w}x{h}");
                    view.Dispose();
                    UnityEngine.Object.DestroyImmediate(root.gameObject);
                }
                Exit(0);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Exit(1);
            }
        }

        static byte[] Render(Camera cam, int w, int h)
        {
            var rt = new RenderTexture(w, h, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB) { antiAliasing = 1 };
            var prev = RenderTexture.active;
            cam.targetTexture = rt;
            cam.aspect = (float)w / h;
            cam.Render();
            RenderTexture.active = rt;
            var tex = new Texture2D(w, h, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, w, h), 0, 0);
            tex.Apply();
            RenderTexture.active = prev;
            cam.targetTexture = null;
            var png = tex.EncodeToPNG();
            UnityEngine.Object.DestroyImmediate(tex);
            rt.Release();
            UnityEngine.Object.DestroyImmediate(rt);
            return png;
        }

        [MenuItem("Squish Squad/Build Android APK")]
        public static void BuildAndroid()
        {
            ProjectSetup.Apply();
            var path = Arg("-customBuildPath") ?? "Builds/Android/SquishSquad.apk";
            if (Directory.Exists(path) || !path.EndsWith(".apk")) path = Path.Combine(path, "SquishSquad.apk");
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
            EditorUserBuildSettings.buildAppBundle = false;
            var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = new[] { ProjectSetup.MainScene },
                locationPathName = path,
                target = BuildTarget.Android,
                options = BuildOptions.None,
            });
            Debug.Log($"[CiBuild] Android build: {report.summary.result}, {report.summary.totalSize / 1048576f:0.0} MB, {report.summary.totalErrors} errors -> {path}");
            Exit(report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded ? 0 : 1);
        }

        static string Arg(string name)
        {
            var a = Environment.GetCommandLineArgs();
            for (int i = 0; i < a.Length - 1; i++) if (a[i] == name) return a[i + 1];
            return null;
        }

        static void Exit(int code)
        {
            if (Application.isBatchMode) EditorApplication.Exit(code);
        }
    }
}
