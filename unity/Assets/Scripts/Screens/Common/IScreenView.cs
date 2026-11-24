// What every screen here is, as pure C# (no UnityEngine, so tools/unity/screens-test runs it frame by frame next to the
// app): the pieces it shows this frame (screen dp, y down) and the pointer (screen dp). Its motions run on the Ticker
// it was given (Anim: React Native's Animated). ScreenHostBehaviour puts it on screen in Unity.
using System.Collections.Generic;
using SquishSquad.Ui.Screens;

namespace SquishSquad.Screens
{
    public interface IScreenView
    {
        List<ScreenPiece> Pieces();
        void Down(float x, float y);
        void Move(float x, float y);
        void Up(float x, float y);
    }
}

namespace SquishSquad.Screens
{
    /// <summary>A screen that scrolls with a mouse wheel (the editor, desktop): dy dp down at (x, y).</summary>
    public interface IWheel
    {
        void Wheel(float x, float y, float dy);
    }
}
