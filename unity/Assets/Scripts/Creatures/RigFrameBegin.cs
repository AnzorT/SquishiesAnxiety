// The start of the rig's part of a frame (Creatures/NativeRig.FrameBegin): before every other LateUpdate, the creatures
// on screen read their frames and the clock's step goes to the rig thread, to run while they're drawn.
using UnityEngine;

namespace SquishSquad.Creatures
{
    [DefaultExecutionOrder(-30000)]
    public sealed class RigFrameBegin : MonoBehaviour
    {
        void LateUpdate() => NativeRig.FrameBegin();
    }
}
