// The end of the rig's part of a frame (Creatures/NativeRig.FrameEnd): after every other LateUpdate, the main thread
// waits for the clock's step, so the realm is idle again by the next frame's Update.
using UnityEngine;

namespace SquishSquad.Creatures
{
    [DefaultExecutionOrder(30000)]
    public sealed class RigFrameEnd : MonoBehaviour
    {
        void LateUpdate() => NativeRig.FrameEnd();
    }
}
