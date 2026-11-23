// Project settings kept in code, so the project needs no hand-edited settings files: applied whenever the editor loads
// the project (and by CI before a build). Idempotent: it only writes what differs.
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SquishSquad.EditorTools
{
    [InitializeOnLoad]
    public static class ProjectSetup
    {
        public const string MainScene = "Assets/Scenes/Main.unity";
        // its own id, so it installs next to the current app on the same phone for side-by-side testing.
        // (The Firebase config is keyed to com.plushcrush.app; Firebase needs this id added, or the switch, later.)
        public const string AppId = "com.plushcrush.unity";

        static ProjectSetup() => EditorApplication.delayCall += Apply;

        [MenuItem("Squish Squad/Apply project settings")]
        public static void Apply()
        {
            if (PlayerSettings.companyName != "PlushCrush") PlayerSettings.companyName = "PlushCrush";
            if (PlayerSettings.productName != "Squish Squad") PlayerSettings.productName = "Squish Squad";
            foreach (var t in new[] { NamedBuildTarget.Android, NamedBuildTarget.iOS, NamedBuildTarget.Standalone })
                if (PlayerSettings.GetApplicationIdentifier(t) != AppId) PlayerSettings.SetApplicationIdentifier(t, AppId);

            // the web page blends in sRGB ("gamma") space; so must Unity, or every soft edge and shadow comes out different
            if (PlayerSettings.colorSpace != ColorSpace.Gamma) PlayerSettings.colorSpace = ColorSpace.Gamma;

            // landscape only, both ways round
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToPortrait = false;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;

            // Android: 64-bit ARM needs IL2CPP; the current app's minimum is API 23
            if (PlayerSettings.GetScriptingBackend(NamedBuildTarget.Android) != ScriptingImplementation.IL2CPP)
                PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            if (PlayerSettings.Android.minSdkVersion < AndroidSdkVersions.AndroidApiLevel23)
                PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;

            // the menu reads touches through UnityEngine.Input (the Input Manager); takes effect after an editor restart
            SetProjectSetting("activeInputHandler", 0);

            EnsureMainScene();
        }

        static void SetProjectSetting(string name, int value)
        {
            var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/ProjectSettings.asset").FirstOrDefault();
            if (asset == null) return;
            var so = new SerializedObject(asset);
            var p = so.FindProperty(name);
            if (p == null || p.intValue == value) return;
            p.intValue = value;
            so.ApplyModifiedProperties();
        }

        // an empty scene: Boot (RuntimeInitializeOnLoadMethod) builds the menu in whatever scene runs
        public static void EnsureMainScene()
        {
            if (!File.Exists(MainScene))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(MainScene));
                var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                EditorSceneManager.SaveScene(scene, MainScene);
                AssetDatabase.Refresh();
            }
            var list = EditorBuildSettings.scenes;
            if (list.Length != 1 || list[0].path != MainScene || !list[0].enabled)
                EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(MainScene, true) };
        }
    }

    // The menu's (and the Game Park carousel's) pictures go in exactly as exported: no resizing, no compression, no mipmaps (pixel for pixel with the
    // app on the reference screen). The house pictures are JPEG bytes (.bytes), decoded at run time, so they aren't
    // textures here at all.
    public sealed class MenuArtImport : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            var ti = (TextureImporter)assetImporter;
            if (assetPath.StartsWith("Assets/Resources/Creatures/"))
            {
                // the rigs' fabric-grain tile: exact pixels, repeated over the creature
                ti.textureType = TextureImporterType.Default; ti.npotScale = TextureImporterNPOTScale.None; ti.mipmapEnabled = false;
                ti.wrapMode = TextureWrapMode.Repeat; ti.filterMode = FilterMode.Point; ti.sRGBTexture = true; ti.alphaSource = TextureImporterAlphaSource.FromInput;
                ti.textureCompression = TextureImporterCompression.Uncompressed;
                return;
            }
            if (assetPath.StartsWith("Assets/Resources/Stack/art/"))
            {
                // the squishies' cut-outs (every game uses them): drawn at many sizes, often well below their own, so
                // mipmapped (trilinear) like Chrome's smooth downscaling; kept exact, never resized to a power of two
                ti.textureType = TextureImporterType.Default; ti.npotScale = TextureImporterNPOTScale.None;
                ti.mipmapEnabled = true; ti.filterMode = FilterMode.Trilinear; ti.wrapMode = TextureWrapMode.Clamp;
                ti.alphaIsTransparency = true; ti.alphaSource = TextureImporterAlphaSource.FromInput; ti.sRGBTexture = true;
                ti.textureCompression = TextureImporterCompression.Uncompressed;
                return;
            }
            // (Resources/Park: the Game Park's carousel, tools/unity/export-park.mjs; the games' pieces and rooms)
            string[] exact = { "Assets/Resources/Menu/", "Assets/Resources/Park/", "Assets/Resources/Stack/", "Assets/Resources/Sort/", "Assets/Resources/Hop/", "Assets/Resources/Squishdoku/", "Assets/Resources/Cards/" };
            bool ours = false;
            foreach (var e in exact) if (assetPath.StartsWith(e)) { ours = true; break; }
            if (!ours) return;
            ti.textureType = TextureImporterType.Default;
            ti.npotScale = TextureImporterNPOTScale.None;
            ti.mipmapEnabled = false;
            ti.alphaIsTransparency = true;     // spreads edge colours into transparent pixels: no dark fringes when scaled
            ti.alphaSource = TextureImporterAlphaSource.FromInput;
            ti.wrapMode = TextureWrapMode.Clamp;
            ti.filterMode = FilterMode.Bilinear;
            ti.sRGBTexture = true;
            ti.isReadable = false;
            ti.maxTextureSize = 4096;
            ti.textureCompression = TextureImporterCompression.Uncompressed;
            foreach (var platform in new[] { "Android", "iPhone", "Standalone" })
            {
                var s = ti.GetPlatformTextureSettings(platform);
                s.overridden = true;
                s.maxTextureSize = 4096;
                s.format = TextureImporterFormat.RGBA32;
                s.textureCompression = TextureImporterCompression.Uncompressed;
                ti.SetPlatformTextureSettings(s);
            }
        }
    }
}
