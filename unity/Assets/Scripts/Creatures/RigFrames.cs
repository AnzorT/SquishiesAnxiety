// Where a creature's frames come from. Each frame is the creature's <svg> markup as the app's own rig code produces
// it (rive-rig.js and friends, unchanged). Two sources:
//   RecordedRig: frames recorded from the rig code by tools/unity/rig/record.mjs, played back in a loop. What the
//     app runs until the JS engine is in the project.
//   LiveRig: the rig code itself running in a JS engine inside Unity on tools/unity/rig/dom-shim.js, driven by
//     Unity's clock, so every creature and move works (built with SQUISH_PUERTS: Creatures/LiveRig.cs).
// Rigs.For(key) picks: live when it's built in and starts, else the recording.
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

    /// <summary>What the house drives on a live rig (LiveRig): the walk's ext channels, the idle fidgets.</summary>
    public interface IHouseRig
    {
        void Ext(System.Collections.Generic.IDictionary<string, double> e);
        void Fidgets(bool on);
        bool InFidget();
    }

    public static class Rigs
    {
        /// <summary>The creature's frames: live (SQUISH_PUERTS) when the engine starts, else its recording (null when
        /// it has none).</summary>
        public static IRigFrames For(string key)
        {
#if SQUISH_PUERTS
            var live = LiveRig.Create(key);
            if (live != null) return live;
#endif
            return RecordedRig.Load(key);
        }
    }

    public sealed class RecordedRig : IRigFrames
    {
        readonly string[] _frames;
        readonly float _fps;
        /// <summary>Loop (an idle) or hold the last frame (a clip such as the walk to the Game Park).</summary>
        public bool Loop = true;

        RecordedRig(string[] frames, float fps) { _frames = frames; _fps = fps; }
        public float Duration => _frames.Length / _fps;

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
        public string FrameAt(float seconds)
        {
            int i = Mathf.Max(0, (int)(seconds * _fps));
            return _frames[Loop ? i % _frames.Length : Mathf.Min(i, _frames.Length - 1)];
        }
        public void Play(string move) { }
    }
}
