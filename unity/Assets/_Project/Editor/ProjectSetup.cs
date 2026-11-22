// First-open setup for the PlushCrush Unity port.
//
// This project was written by hand, outside the Editor, so the parts that only the Editor can make well are made here,
// the first time the project opens:
//   1. Packages: added by name through the Package Manager, so each resolves to the version that fits this Editor
//      (nothing is guessed in Packages/manifest.json). Runs on every load but only asks for what's missing.
//   2. Player settings: app id, name, landscape, Android IL2CPP + ARM64, linear color. Applied once; the marker file
//      ProjectSettings/PlushCrushSetup.json records it, so a later change made by hand in Player Settings sticks.
//   3. The main scene, saved and put in Build Settings (the app builds its own screens from code, see AppRoot).
// URP's pipeline asset is made by UrpSetup.cs (its own assembly, compiled only once URP is installed).
//
// Run again any time: menu PlushCrush > Setup > Run Project Setup Again.
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlushCrush.EditorTools
{
    [InitializeOnLoad]
    public static class ProjectSetup
    {
        // What the port needs from the Package Manager. Names only: each resolves to the version made for this Editor.
        static readonly string[] Packages =
        {
            "com.unity.render-pipelines.universal", // URP: the render pipeline (2D UI + the 3D squish toy)
            "com.unity.inputsystem",                // touch and multi-touch for squishing
            "com.unity.cloud.gltfast",              // the Tripo .glb creature models, loaded at runtime
            "com.unity.test-framework",             // tests for the ported game logic (economy, XP, levels)
        };

        public const string AppId = "com.plushcrush.app"; // same as the React Native app: google-services.json is keyed to it
        const string ProductName = "PlushCrush";
        const string CompanyName = "PlushCrush";
        const string MainScenePath = "Assets/_Project/Scenes/Main.unity";
        const string MarkerPath = "ProjectSettings/PlushCrushSetup.json";
        const int SetupVersion = 1;

        static AddAndRemoveRequest _request;
        static double _deadline;

        static ProjectSetup()
        {
            // Too early to touch packages or scenes inside the static constructor; wait until the Editor has loaded.
            EditorApplication.delayCall += AutoRun;
        }

        static void AutoRun()
        {
            if (Application.isBatchMode || EditorApplication.isPlayingOrWillChangePlaymode) return;
            EnsurePackages();
            if (ReadMarkerVersion() < SetupVersion)
            {
                ApplyPlayerSettings();
                EnsureMainScene();
                WriteMarker();
                Debug.Log("[PlushCrush] Project setup applied (player settings, main scene). Packages may still be installing.");
            }
        }

        [MenuItem("PlushCrush/Setup/Run Project Setup Again")]
        public static void RunAgain()
        {
            EnsurePackages();
            ApplyPlayerSettings();
            EnsureMainScene();
            WriteMarker();
            Debug.Log("[PlushCrush] Project setup applied again.");
        }

        // ---------- 1. Packages ----------

        static void EnsurePackages()
        {
            if (_request != null) return; // one request at a time
            string[] installed;
            try
            {
                installed = UnityEditor.PackageManager.PackageInfo.GetAllRegisteredPackages().Select(p => p.name).ToArray();
            }
            catch (Exception e)
            {
                Debug.LogWarning("[PlushCrush] Couldn't list packages yet: " + e.Message);
                return;
            }
            var missing = Packages.Where(p => !installed.Contains(p)).ToArray();
            if (missing.Length == 0) return;

            // Don't retry a failed install on every script reload in the same session (no network, etc.).
            const string failedKey = "PlushCrush.PackageInstallFailed";
            if (SessionState.GetBool(failedKey, false)) return;

            Debug.Log("[PlushCrush] Installing packages: " + string.Join(", ", missing));
            _request = Client.AddAndRemove(packagesToAdd: missing, packagesToRemove: null);
            _deadline = EditorApplication.timeSinceStartup + 900;
            EditorApplication.update += PollPackages;
        }

        static void PollPackages()
        {
            if (_request == null) { EditorApplication.update -= PollPackages; return; }
            if (!_request.IsCompleted)
            {
                if (EditorApplication.timeSinceStartup < _deadline) return;
                Debug.LogError("[PlushCrush] Package install timed out. Try PlushCrush > Setup > Run Project Setup Again.");
                SessionState.SetBool("PlushCrush.PackageInstallFailed", true);
            }
            else if (_request.Status == StatusCode.Success)
            {
                Debug.Log("[PlushCrush] Packages ready: " + string.Join(", ", _request.Result.Select(p => p.name + "@" + p.version)));
            }
            else
            {
                Debug.LogError("[PlushCrush] Package install failed: " + _request.Error?.message +
                               "\nOpen Window > Package Manager and add these by name: " + string.Join(", ", Packages));
                SessionState.SetBool("PlushCrush.PackageInstallFailed", true);
            }
            EditorApplication.update -= PollPackages;
            _request = null;
        }

        // Headless use: Unity -batchmode -projectPath <dir> -executeMethod PlushCrush.EditorTools.ProjectSetup.InstallPackagesBatch
        // (no -quit: the Package Manager answers on later Editor ticks; this exits by itself when done)
        public static void InstallPackagesBatch()
        {
            _request = Client.AddAndRemove(packagesToAdd: Packages, packagesToRemove: null);
            _deadline = EditorApplication.timeSinceStartup + 900;
            EditorApplication.update += () =>
            {
                if (_request == null) return;
                if (!_request.IsCompleted && EditorApplication.timeSinceStartup < _deadline) return;
                bool ok = _request.IsCompleted && _request.Status == StatusCode.Success;
                Debug.Log(ok ? "[PlushCrush] Packages ready." : "[PlushCrush] Package install failed: " + _request.Error?.message);
                _request = null;
                EditorApplication.Exit(ok ? 0 : 1);
            };
        }

        // ---------- 2. Player settings ----------

        static void ApplyPlayerSettings()
        {
            PlayerSettings.companyName = CompanyName;
            PlayerSettings.productName = ProductName;
            PlayerSettings.bundleVersion = "1.0.0";
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, AppId);
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.iOS, AppId);
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Standalone, AppId);

            // The app is landscape only (app.json "orientation": "landscape"); either way up.
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToPortrait = false;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToLandscapeRight = true;

            // Google Play needs 64-bit; IL2CPP is the faster backend on phones.
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;

            PlayerSettings.colorSpace = ColorSpace.Linear;
            PlayerSettings.SplashScreen.backgroundColor = new Color32(0x2A, 0x16, 0x08, 0xFF); // app.json splash color

            AssetDatabase.SaveAssets();
        }

        // ---------- 3. Main scene ----------

        static void EnsureMainScene()
        {
            if (!File.Exists(MainScenePath))
            {
                var active = SceneManager.GetActiveScene();
                bool untouchedUntitled = string.IsNullOrEmpty(active.path) && !active.isDirty;
                if (!untouchedUntitled)
                {
                    Debug.LogWarning("[PlushCrush] Main scene not made: save or close the open scene, then PlushCrush > Setup > Run Project Setup Again.");
                    return;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(MainScenePath));
                // Empty on purpose: AppRoot builds the app from code when Play starts.
                var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                EditorSceneManager.SaveScene(scene, MainScenePath);
            }
            if (!EditorBuildSettings.scenes.Any(s => s.path == MainScenePath))
            {
                var list = EditorBuildSettings.scenes.ToList();
                list.Insert(0, new EditorBuildSettingsScene(MainScenePath, true));
                EditorBuildSettings.scenes = list.ToArray();
            }
        }

        // ---------- marker ----------

        [Serializable] class Marker { public int version; public string appliedUtc; }

        static int ReadMarkerVersion()
        {
            try { return File.Exists(MarkerPath) ? JsonUtility.FromJson<Marker>(File.ReadAllText(MarkerPath)).version : 0; }
            catch { return 0; }
        }

        static void WriteMarker()
        {
            File.WriteAllText(MarkerPath, JsonUtility.ToJson(new Marker { version = SetupVersion, appliedUtc = DateTime.UtcNow.ToString("o") }, true));
        }
    }
}
