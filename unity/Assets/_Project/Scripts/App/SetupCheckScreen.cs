// The first screen while the port is being built: shows whether the project set itself up correctly
// (render pipeline, UI scale, fonts), so a screenshot of it says what, if anything, needs fixing.
// It is replaced by the real Splash screen once that is ported.
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace PlushCrush.App
{
    public sealed class SetupCheckScreen : AppScreen
    {
        static readonly Color Bg = new Color32(0x2A, 0x16, 0x08, 0xFF);
        static readonly Color Cream = new Color32(0xFF, 0xF4, 0xE0, 0xFF);
        static readonly Color Gold = new Color32(0xFF, 0xC9, 0x3C, 0xFF);
        static readonly Color Good = new Color32(0x7E, 0xE0, 0x8A, 0xFF);
        static readonly Color Bad = new Color32(0xFF, 0x7A, 0x7A, 0xFF);

        protected override VisualElement Build()
        {
            var root = new VisualElement();
            root.style.backgroundColor = Bg;
            root.style.paddingLeft = 32; root.style.paddingRight = 32; root.style.paddingTop = 20; root.style.paddingBottom = 20;
            root.style.flexDirection = FlexDirection.Row;

            // Left: title and checks
            var left = new VisualElement();
            left.style.flexGrow = 1;
            left.style.flexBasis = 0;
            root.Add(left);

            var title = new Label("PlushCrush").Use(Fonts.Baloo800);
            title.style.fontSize = 40; title.style.color = Gold;
            title.style.marginBottom = -6;
            left.Add(title);

            var sub = new Label("Unity port · setup check").Use(Fonts.Nunito700);
            sub.style.fontSize = 14; sub.style.color = Cream; sub.style.marginBottom = 14;
            left.Add(sub);

            var pipeline = GraphicsSettings.currentRenderPipeline;
            bool urp = pipeline != null && pipeline.GetType().Name.Contains("Universal");
            left.Add(Check("Render pipeline", urp ? "URP" : (pipeline == null ? "Built-in (URP not set up yet)" : pipeline.GetType().Name), urp));

            float scale = Screen.height / (float)AppRoot.RefHeight;
            left.Add(Check("Screen", $"{Screen.width} x {Screen.height} px  ·  1 dp = {scale:0.###} px", true));
            left.Add(Check("UI units", $"{AppRoot.RefWidth} x {AppRoot.RefHeight} dp at the A15's shape (2340 x 1080 px)",
                Mathf.Abs(Screen.width / (float)Screen.height - 2340f / 1080f) < 0.02f));
            left.Add(Check("Color space", QualitySettings.activeColorSpace.ToString(), QualitySettings.activeColorSpace == ColorSpace.Linear));

            int missing = 0;
            foreach (var f in Fonts.All) if (Fonts.Get(f) == null) missing++;
            left.Add(Check("Fonts", missing == 0 ? $"all {Fonts.All.Length} loaded" : $"{missing} missing", missing == 0));

            var hint = new Label("Next: the app's screens are rebuilt here one by one. " +
                                 "Check each against the original with PlushCrush > Reference Overlay.").Use(Fonts.Nunito600);
            hint.style.fontSize = 12; hint.style.color = Cream; hint.style.opacity = 0.75f;
            hint.style.whiteSpace = WhiteSpace.Normal; hint.style.marginTop = 12;
            left.Add(hint);

            // Right: every font, so wrong weights or fallbacks are easy to spot
            var right = new VisualElement();
            right.style.width = 300;
            right.style.justifyContent = Justify.Center;
            root.Add(right);
            foreach (var f in Fonts.All)
            {
                var sample = new Label(f.Replace('_', ' ') + "  Squish 123").Use(f);
                sample.style.fontSize = 15; sample.style.color = Cream; sample.style.marginBottom = 1;
                right.Add(sample);
            }
            return root;
        }

        static VisualElement Check(string name, string value, bool ok)
        {
            var row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.alignItems = Align.Center;
            row.style.marginBottom = 6;

            var dot = new VisualElement();
            dot.style.width = 10; dot.style.height = 10;
            dot.style.borderTopLeftRadius = 5; dot.style.borderTopRightRadius = 5;
            dot.style.borderBottomLeftRadius = 5; dot.style.borderBottomRightRadius = 5;
            dot.style.backgroundColor = ok ? Good : Bad;
            dot.style.marginRight = 8;
            row.Add(dot);

            var label = new Label(name).Use(Fonts.Nunito800);
            label.style.fontSize = 14; label.style.color = Cream; label.style.width = 120;
            row.Add(label);

            var val = new Label(value).Use(Fonts.Nunito600);
            val.style.fontSize = 13; val.style.color = ok ? Cream : Bad;
            val.style.whiteSpace = WhiteSpace.Normal; val.style.flexShrink = 1;
            row.Add(val);
            return row;
        }
    }
}
