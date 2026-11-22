// Draws a reference screenshot of the React Native app / design over the Unity screen, half see-through, to check a
// rebuilt screen matches 1:1. Driven from the Editor (menu PlushCrush > Reference Overlay); does nothing in builds.
using UnityEngine;
using UnityEngine.UIElements;

namespace PlushCrush.App
{
    public static class ReferenceOverlay
    {
        static VisualElement _overlay;

        public static bool IsInstalled => _overlay != null && _overlay.panel != null;

        internal static void Install(VisualElement root)
        {
#if UNITY_EDITOR
            _overlay = new VisualElement { name = "reference-overlay", pickingMode = PickingMode.Ignore };
            _overlay.style.position = Position.Absolute;
            _overlay.style.left = 0; _overlay.style.top = 0; _overlay.style.right = 0; _overlay.style.bottom = 0;
            _overlay.style.backgroundSize = new BackgroundSize(Length.Percent(100), Length.Percent(100));
            _overlay.style.display = DisplayStyle.None;
            root.Add(_overlay);
#endif
        }

        public static void Show(Texture2D image, float opacity)
        {
            if (!IsInstalled) return;
            _overlay.style.backgroundImage = new StyleBackground(image);
            _overlay.style.opacity = Mathf.Clamp01(opacity);
            _overlay.style.display = image != null ? DisplayStyle.Flex : DisplayStyle.None;
            _overlay.BringToFront();
        }

        public static void Hide()
        {
            if (IsInstalled) _overlay.style.display = DisplayStyle.None;
        }
    }
}
