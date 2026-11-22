// Where a creature's frames come from. Each frame is the creature's <svg> markup as the app's own rig code produces
// it (rive-rig.js and friends, unchanged). Two sources:
//   RecordedRig: frames recorded from the rig code by tools/unity/rig/record.mjs, played back in a loop. What the
//     app runs until the JS engine is in the project.
//   a live host (next): the rig code itself running in a JS engine inside Unity on tools/unity/rig/dom-shim.js,
//     driven by Unity's clock, so moves, pokes and the house's behaviours all work.
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public interface IRigFrames
    {
        /// <summary>The creature's SVG markup at this time (seconds since it appeared).</summary>
        string FrameAt(float seconds);
        /// <summary>Plays a move ("idle", "dance", "hop", ...). A recording only has the moves it was recorded with.</summary>
        void Play(string move);
    }

    public sealed class RecordedRig : IRigFrames
    {
        readonly string[] _frames;
        readonly float _fps;

        RecordedRig(string[] frames, float fps) { _frames = frames; _fps = fps; }

        /// <summary>Resources/Creatures/&lt;key&gt;.bytes, or null when the creature hasn't been recorded.</summary>
        public static RecordedRig Load(string key)
        {
            var asset = Resources.Load<TextAsset>("Creatures/" + key);
            if (asset == null) return null;
            string text;
            using (var gz = new GZipStream(new MemoryStream(asset.bytes), CompressionMode.Decompress))
            using (var r = new StreamReader(gz, Encoding.UTF8)) text = r.ReadToEnd();
            Resources.UnloadAsset(asset);
            int nl = text.IndexOf('\n');
            if (nl < 0) return null;
            float fps = float.Parse(text.Substring(0, nl), System.Globalization.CultureInfo.InvariantCulture);
            var frames = text.Substring(nl + 1).Split('\n');
            return frames.Length == 0 ? null : new RecordedRig(frames, fps);
        }

        public int Count => _frames.Length;
        public float Fps => _fps;
        public string FrameAt(float seconds) => _frames[Mathf.Abs((int)(seconds * _fps)) % _frames.Length];
        public void Play(string move) { }
    }
}
