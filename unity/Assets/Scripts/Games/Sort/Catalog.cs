// The small data Squish Sort's engine and screens name, ported from
// src/sort/props.js (KINDS), src/sort/models.js (the sizes and the seven
// fridges and cupboards, by key and name) and src/sort/themes.js (the two
// containers and their groups). The drawing data (shapes, colours) is not
// here: it belongs with the views.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    public static class Props
    {
        // kinds of clutter (foods in the fridge, toys in the cupboard)
        public const int Kinds = 16;
    }

    public sealed class ContainerModel
    {
        public string Kind;   // 'fridge' | 'cupboard'
        public string Key;
        public string Name;
        public string Size;   // SIZE_NAMES[Index]
        public int Index;
    }

    public static class Models
    {
        public static readonly IReadOnlyList<string> SIZE_NAMES = new[] { "SMALL", "MEDIUM", "BIG", "LARGE", "EXTRA LARGE", "XXL", "VERY VERY LARGE" };

        static readonly string[] FridgeKeys = { "mini", "retro", "topFreezer", "bottomFreezer", "sideBySide", "frenchDoor", "restaurant" };
        static readonly string[] FridgeNames = { "Mini Fridge", "Retro Fridge", "Top-Freezer Fridge", "Bottom-Freezer Fridge", "Side-by-Side Fridge", "French-Door Fridge", "Restaurant Fridge" };
        static readonly string[] CupboardKeys = { "bedside", "hall", "toy", "wardrobe", "mirror", "armoire", "grand" };
        static readonly string[] CupboardNames = { "Bedside Cabinet", "Hall Cupboard", "Toy Cupboard", "Wardrobe", "Mirror Wardrobe", "Grand Armoire", "Giant Wardrobe" };

        public static readonly IReadOnlyList<ContainerModel> FRIDGES = Build("fridge", FridgeKeys, FridgeNames);
        public static readonly IReadOnlyList<ContainerModel> CUPBOARDS = Build("cupboard", CupboardKeys, CupboardNames);
        public static readonly int MODEL_COUNT = FridgeKeys.Length;

        static List<ContainerModel> Build(string kind, string[] keys, string[] names)
        {
            var l = new List<ContainerModel>();
            for (int i = 0; i < keys.Length; i++) l.Add(new ContainerModel { Kind = kind, Key = keys[i], Name = names[i], Size = SIZE_NAMES[i], Index = i });
            return l;
        }

        // the fridge number i (0 SMALL ... 6 VERY VERY LARGE), `i | 0` clamped
        // to 0-6; `theme` is always the fridge now (kept for the callers)
        public static ContainerModel ModelOf(string theme, double i) => FRIDGES[Math.Max(0, Math.Min(6, JsMath.ToInt32(i)))];
    }

    public sealed class SortTheme
    {
        public string Key;
        public string Name;
        public string Blurb;
        public IReadOnlyList<string> Groups;
    }

    public static class Themes
    {
        public static readonly SortTheme Fridge = new SortTheme { Key = "fridge", Name = "Snack Fridge", Blurb = "Snacks, fruit and bakes", Groups = new[] { "snack", "fruit", "bakery" } };
        public static readonly SortTheme Cupboard = new SortTheme { Key = "cupboard", Name = "Toy Cupboard", Blurb = "Pets, forest, dream and sky friends", Groups = new[] { "pet", "forest", "dream", "sky" } };

        public static readonly IReadOnlyDictionary<string, SortTheme> THEMES = new Dictionary<string, SortTheme> { { "fridge", Fridge }, { "cupboard", Cupboard } };
    }
}
