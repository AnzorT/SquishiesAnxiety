// The app's fonts (the same TTFs React Native loads in App.js), from Resources/Fonts.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlushCrush.App
{
    public static class Fonts
    {
        public const string Baloo500 = "Baloo2_500Medium";
        public const string Baloo700 = "Baloo2_700Bold";
        public const string Baloo800 = "Baloo2_800ExtraBold";
        public const string Nunito400 = "Nunito_400Regular";
        public const string Nunito600 = "Nunito_600SemiBold";
        public const string Nunito700 = "Nunito_700Bold";
        public const string Nunito800 = "Nunito_800ExtraBold";
        public const string Nunito900 = "Nunito_900Black";
        public const string Fredoka500 = "Fredoka_500Medium";
        public const string Fredoka600 = "Fredoka_600SemiBold";
        public const string Fredoka700 = "Fredoka_700Bold";

        public static readonly string[] All =
        {
            Baloo500, Baloo700, Baloo800, Nunito400, Nunito600, Nunito700, Nunito800, Nunito900, Fredoka500, Fredoka600, Fredoka700,
        };

        static readonly Dictionary<string, Font> Cache = new Dictionary<string, Font>();

        public static Font Get(string name)
        {
            if (!Cache.TryGetValue(name, out var font))
            {
                font = Resources.Load<Font>("Fonts/" + name);
                if (font == null) Debug.LogWarning("[PlushCrush] Font missing: Resources/Fonts/" + name);
                Cache[name] = font;
            }
            return font;
        }

        /// <summary>Set an element's font (children inherit it).</summary>
        public static T Use<T>(this T element, string name) where T : VisualElement
        {
            var font = Get(name);
            if (font != null) element.style.unityFontDefinition = FontDefinition.FromFont(font);
            return element;
        }
    }
}
