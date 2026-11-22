// Makes URP the project's render pipeline, once URP is installed (ProjectSetup.cs installs it).
// This file's assembly only compiles when com.unity.render-pipelines.universal is present (see the .asmdef's
// versionDefines/defineConstraints), so the project opens cleanly before the package arrives.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PlushCrush.EditorTools
{
    [InitializeOnLoad]
    static class UrpSetup
    {
        const string Folder = "Assets/_Project/Settings/Rendering";
        const string AssetPath = Folder + "/PlushCrush_URP.asset";
        const string RendererPath = Folder + "/PlushCrush_Renderer.asset";

        static UrpSetup()
        {
            EditorApplication.delayCall += () =>
            {
                if (Application.isBatchMode || EditorApplication.isPlayingOrWillChangePlaymode) return;
                if (GraphicsSettings.defaultRenderPipeline != null) return; // already set (by us or by hand)
                Assign();
            };
        }

        [MenuItem("PlushCrush/Setup/Assign URP Pipeline Asset")]
        static void Assign()
        {
            try
            {
                var asset = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(AssetPath);
                if (asset == null)
                {
                    Directory.CreateDirectory(Folder);
                    var renderer = AssetDatabase.LoadAssetAtPath<UniversalRendererData>(RendererPath);
                    if (renderer == null)
                    {
                        renderer = ScriptableObject.CreateInstance<UniversalRendererData>();
                        AssetDatabase.CreateAsset(renderer, RendererPath);
                    }
                    asset = UniversalRenderPipelineAsset.Create(renderer);
                    asset.supportsHDR = false;      // phone UI game: HDR buys nothing, costs bandwidth
                    asset.msaaSampleCount = 4;      // smooth edges on the 3D squish toy
                    AssetDatabase.CreateAsset(asset, AssetPath);
                    AssetDatabase.SaveAssets();
                }
                GraphicsSettings.defaultRenderPipeline = asset;
                // Quality levels with their own pipeline asset would override the default; clear them so ours applies.
                int current = QualitySettings.GetQualityLevel();
                for (int i = 0; i < QualitySettings.names.Length; i++)
                {
                    QualitySettings.SetQualityLevel(i, false);
                    if (QualitySettings.renderPipeline != null) QualitySettings.renderPipeline = null;
                }
                QualitySettings.SetQualityLevel(current, false);
                AssetDatabase.SaveAssets();
                Debug.Log("[PlushCrush] URP is now the render pipeline (" + AssetPath + ").");
            }
            catch (Exception e)
            {
                Debug.LogError("[PlushCrush] Couldn't set up URP automatically: " + e.Message +
                               "\nBy hand: Assets > Create > Rendering > URP Asset (with Universal Renderer), then " +
                               "Edit > Project Settings > Graphics > Default Render Pipeline = that asset.");
            }
        }
    }
}
