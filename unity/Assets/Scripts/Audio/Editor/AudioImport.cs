// The import settings of the app's sounds (Assets/Resources/Audio, tools/unity/export-audio.mjs), set as each file is
// imported, so they don't depend on hand-made .meta files:
//   effects (sfx/, squishdoku/, sort/, stack/, bubble_tap, coin, pop): Decompress On Load, PCM. The originals are
//     short (0.04-4.3 s) 44.1 kHz mono WAV, and a few Ogg; PCM keeps each exactly as the app decodes it (no second
//     lossy pass) and replays with no decoding, which is what the app's own choice of WAV for short effects is for.
//   the creatures' squish loops (creatures/*.ogg, 6-7.5 s) and the default slime loop (slime.wav, 20 s 48 kHz stereo
//     24-bit): Decompress On Load, Vorbis at quality 1 (one is loaded at a time, on the squish stage).
//   the music (music/velvet_map_study.mp3, 3 min 192 kbps): Streaming, Vorbis at quality 0.7.
// Sample rates are kept, nothing is forced to mono, and every clip is 2D (the sources set spatialBlend 0).
// Bump Version when a setting changes, so Unity imports the files again.
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SquishSquad.Audio.EditorTools
{
    public sealed class AudioImport : AssetPostprocessor
    {
        const string Root = "Assets/Resources/Audio/";
        const uint Version = 1;

        public override uint GetVersion() => Version;

        void OnPreprocessAudio()
        {
            if (!assetPath.StartsWith(Root)) return;
            var ai = (AudioImporter)assetImporter;
            var rel = assetPath.Substring(Root.Length);
            var s = ai.defaultSampleSettings;
            s.sampleRateSetting = AudioSampleRateSetting.PreserveSampleRate;
            if (rel.StartsWith("music/"))
            {
                s.loadType = AudioClipLoadType.Streaming;
                s.compressionFormat = AudioCompressionFormat.Vorbis;
                s.quality = 0.7f;
                s.preloadAudioData = false;
                ai.loadInBackground = true;
            }
            else if (rel.StartsWith("creatures/") || rel == "slime.wav")
            {
                s.loadType = AudioClipLoadType.DecompressOnLoad;
                s.compressionFormat = AudioCompressionFormat.Vorbis;
                s.quality = 1f;
                s.preloadAudioData = false;
                ai.loadInBackground = false;
            }
            else
            {
                s.loadType = AudioClipLoadType.DecompressOnLoad;
                s.compressionFormat = AudioCompressionFormat.PCM;
                s.quality = 1f;
                s.preloadAudioData = true;
                ai.loadInBackground = false;
            }
            ai.defaultSampleSettings = s;
            foreach (var platform in new[] { "Android", "iOS", "Standalone" })
                if (ai.ContainsSampleSettingsOverride(platform)) ai.ClearSampleSettingOverride(platform);
            ai.forceToMono = false;
            ai.ambisonic = false;
        }
    }
}
#endif
