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
                // menu-a15.png (compared with the app's screenshot) shows the creature's still, as the reference does;
                // menu-a15-live.png and the others show it drawn live from its recorded rig frames (frame 0)
                foreach (var (name, w, h) in Screens) Shot(layout, outDir, name, w, h, name != "menu-a15");
                Shot(layout, outDir, "menu-a15-live", 2340, 1080, true);
                Shot(layout, outDir, "menu-a15-park", 2340, 1080, true, 3200f);   // after PLAY's walk to the Game Park
                // the games carousel at rest, 1.5 s after the walk ends (3060 ms), Squish Time in the middle (compare with
                // unity/Reference/park-a15.png around the creature, which is drawn live here), and on other screen shapes
                Shot(layout, outDir, "park-a15", 2340, 1080, true, 4560f);
                Shot(layout, outDir, "park-2400x1080", 2400, 1080, true, 4560f);
                Shot(layout, outDir, "park-2048x1536", 2048, 1536, true, 4560f);
                // Squish Stack, level 12: the intro banner, the deal, playing (compare with unity/Reference/stack-level-12.png:
                // the squishies are picked at random, so only the screen around them matches), and a move
                StackShots(outDir, 2340, 1080, "stack-a15", new[] { (600.0, "intro"), (2200.0, "deal"), (6500.0, "play"), (8000.0, "moved") });
                StackShots(outDir, 2400, 1080, "stack-2400x1080", new[] { (6500.0, "play") });
                StackShots(outDir, 2048, 1536, "stack-2048x1536", new[] { (6500.0, "play") });
                // its cards, opened at 6.5 s and settled 7.2 s later (compare with tools/unity/stack-test cards.mjs's pictures,
                // stack-result-7200.png and so on: the same sample result; the page behind is the level here)
                foreach (var card in new[] { "result", "fail", "pause", "hint" }) StackShots(outDir, 2340, 1080, "stack-a15", new[] { (6500.0, "card-" + card) });
                Exit(0);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Exit(1);
            }
        }

        static void Shot(MenuLayout layout, string outDir, string name, int w, int h, bool live, float parkMs = -1)
        {
            var root = new GameObject("Capture").transform;
            var cam = MenuScreen.CreateCamera(root);
            MenuScreen.FitCamera(cam, w, h);
            var view = new MenuView(layout, root, w, h, layout.reference.level, layout.reference.season, "mittens", live);
            view.ParkStartGame = "squish";   // (not the editor's remembered game: the same picture every run)
            view.Tick(0f);
            if (parkMs >= 0)
            {
                view.EnterPark(0f);
                view.Tick(parkMs);
            }
            if (view.Creature != null) view.Creature.RenderAt(parkMs >= 0 ? parkMs / 1000f : 0f);
            var png = Render(cam, w, h);
            File.WriteAllBytes(Path.Combine(outDir, name + ".png"), png);
            Debug.Log($"[CiBuild] {name}.png {w}x{h}{(view.Creature != null ? " (live creature)" : "")}");
            view.Dispose();
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static void StackShots(string outDir, int w, int h, string name, (double ms, string label)[] times)
        {
            var root = new GameObject("Capture").transform;
            var cam = MenuScreen.CreateCamera(root);
            MenuScreen.FitCamera(cam, w, h);
            SquishSquad.Ui.UiPiece.PxPerDp = h / 384f;
            var game = SquishSquad.Games.Stack.StackGame.Create(root, 12, w, h);
            game.Init(0);
            double t = 0;
            foreach (var (ms, label) in times)
            {
                // (the move at 7 s: the first cushion's top squishy onto the next cushion)
                if (label == "moved") { for (; t <= 7000; t += 1000.0 / 60) game.Advance(t); game.TapMove(0, 1); }
                var at = ms;
                if (label.StartsWith("card-")) { for (; t <= ms; t += 1000.0 / 60) game.Advance(t); game.ShowCard(label.Substring(5)); at = ms + 7200; }
                for (; t <= at; t += 1000.0 / 60) game.Advance(t);   // every frame, as the springs need
                File.WriteAllBytes(Path.Combine(outDir, $"{name}-{label}.png"), Render(cam, w, h));
                Debug.Log($"[CiBuild] {name}-{label}.png {w}x{h}");
            }
            UnityEngine.Object.DestroyImmediate(root.gameObject);
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
