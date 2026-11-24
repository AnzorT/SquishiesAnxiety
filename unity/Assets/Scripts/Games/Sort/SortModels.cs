// The drawing data of Squish Sort's fridges (src/sort/models.js on develop: seven real fridges, one per size, drawn
// "realistic and high detailed" since 2026-11-17 by Container.js, SortArt / SortFridge here). Only fridges since
// 2026-11-17 (the user: "lets make it only with food ok ? so delete the toy cupboard"): ModelOf ignores the theme, as
// models.js modelOf does. Catalog.cs has the names the rules use; this is what the drawing reads.
//   Share     the body's width, as a share of the play area's
//   Doors     1 (on Hinge's side) or 2
//   Radius    the body's corners [top, bottom]
//   Top*      what's above the inside: a + b x spot high (Keep: the door covers all but that much of it)
//   Bottom*   and below it (a toe-kick grille, chrome trim, freezer drawers)
//   Crisper   the salad drawers under the last shelf
//   FeetKind  what it stands on; Handle the doors' handles; Deco what's on the doors
//   Finish    the body's and the doors' material; Metal the handles'
//   Liner     the inside's plastic, front to back; Shelf "glass" or "wire"
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    /// <summary>A material (models.js): Across the colour left to right over the front (darker ends: its rounded edges;
    /// the bright bit off-centre: the room's light), Edge the outline, Seam the gaps between panels, Shade a darker tone;
    /// Kind "enamel" (glossy paint, a strong soft reflection) or "steel" (a brushed grain and a duller one).</summary>
    public sealed class Finish
    {
        public string Kind, Edge, Seam, Shade;
        public string[] Across;
        public bool Steel => Kind == "steel";
    }

    /// <summary>The inside's plastic liner: the side walls' front and back, the back wall's top and bottom, its ribs.</summary>
    public sealed class Liner { public string Front, Back, Top, Bottom, Rib; }

    public sealed class SortModel
    {
        public string Kind = "fridge", Key, Name, Size;
        public int Index;
        public float Share;
        public int Doors;
        public string Hinge;                   // one door: "left" | "right"
        public float[] Radius;                 // top, bottom
        public string TopKind; public float TopA, TopB; public float? TopKeep;
        public string BottomKind; public float BottomA, BottomB;
        public bool Crisper;
        public string FeetKind, Handle;
        public string[] Deco;
        public Finish Finish;
        public string[] Metal;
        public Liner Liner;
        public string Shelf;                   // "glass" | "wire"
        public bool Has(string deco) { foreach (var d in Deco) if (d == deco) return true; return false; }
    }

    public static class SortModels
    {
        public static readonly string[] SIZE_NAMES = { "SMALL", "MEDIUM", "BIG", "LARGE", "EXTRA LARGE", "XXL", "VERY VERY LARGE" };

        // ---- the materials ----------------------------------------------------------------------------------------------
        static Finish Enamel(string[] across, string edge, string seam, string shade) => new Finish { Kind = "enamel", Across = across, Edge = edge, Seam = seam, Shade = shade };
        static Finish SteelOf(string[] across, string edge, string seam, string shade) => new Finish { Kind = "steel", Across = across, Edge = edge, Seam = seam, Shade = shade };

        static readonly Finish WHITE = Enamel(new[] { "#b9c2cb", "#e7ecf0", "#ffffff", "#fbfcfd", "#eef1f4", "#d5dbe1", "#aeb8c2" }, "#5d6873", "#8a96a2", "#9aa6b2");
        static readonly Finish MINT = Enamel(new[] { "#5aa991", "#93dcc5", "#c9f7e8", "#b9f1de", "#9fe5cd", "#7fceb6", "#559f88" }, "#1f5e4f", "#3d8a74", "#4f9c85");
        static readonly Finish ALMOND = Enamel(new[] { "#cbbd9f", "#ece4d0", "#fffcf4", "#fbf6ea", "#f3ebd8", "#e2d6bb", "#c8b998" }, "#7a6c52", "#aa9c7e", "#b8a98a");
        static readonly Finish STEEL = SteelOf(new[] { "#7f8a95", "#bcc4cc", "#e9edf0", "#d0d6dc", "#f2f4f6", "#c1c8cf", "#98a2ac", "#77818c" }, "#46505a", "#5f6a75", "#7c8692");
        static readonly Finish BLUE_STEEL = SteelOf(new[] { "#7a8798", "#b6c3d2", "#e6edf5", "#cdd7e2", "#eef3f8", "#bdc9d6", "#94a2b3", "#728093" }, "#3e4b5c", "#5a6879", "#788699");
        static readonly Finish BLACK = SteelOf(new[] { "#15191d", "#30363d", "#545d67", "#3b424a", "#646d77", "#3a4048", "#262b31", "#14181c" }, "#07090b", "#0b0e11", "#0e1114");

        // the handles' metal, across a round bar
        public static readonly string[] CHROME = { "#4e5964", "#9aa4ae", "#e9edf0", "#ffffff", "#c9d0d7", "#7d8894", "#4b5560" };
        static readonly string[] BRUSHED = { "#5b6570", "#a3acb5", "#dde2e7", "#f4f6f8", "#b9c1c9", "#7f8994", "#56606b" };
        static readonly string[] DARK_METAL = { "#1b1f24", "#454c55", "#7a838d", "#a3abb3", "#5d6670", "#30363d", "#16191d" };
        static readonly string[] ALMOND_METAL = { "#8f8064", "#cfc3a8", "#f4eedf", "#fffcf5", "#e2d8c2", "#b6a888", "#83755a" };

        static readonly Liner LINER = new Liner { Front = "#f3f7fa", Back = "#cfdbe4", Top = "#fbfdfe", Bottom = "#dde7ee", Rib = "#bccbd6" };
        static readonly Liner LINER_GREY = new Liner { Front = "#eef1f4", Back = "#c5ced7", Top = "#f6f8fa", Bottom = "#d6dde4", Rib = "#b2bdc8" };

        static SortModel M(string key, string name, float share, int doors, string hinge, float r0, float r1, string top, float ta, float tb, float? keep,
            string bottom, float ba, float bb, bool crisper, string feet, string handle, string[] deco, Finish finish, string[] metal, Liner liner, string shelf) =>
            new SortModel
            {
                Key = key, Name = name, Share = share, Doors = doors, Hinge = hinge, Radius = new[] { r0, r1 }, TopKind = top, TopA = ta, TopB = tb, TopKeep = keep,
                BottomKind = bottom, BottomA = ba, BottomB = bb, Crisper = crisper, FeetKind = feet, Handle = handle, Deco = deco,
                Finish = finish, Metal = metal, Liner = liner, Shelf = shelf,
            };

        static readonly SortModel[] FRIDGES = Build(new[]
        {
            M("mini", "Mini Fridge", 0.56f, 1, "right", 16, 16, "icebox", 12, 0.5f, 4, "grille", 14, 0, false, "nubs", "recess", new[] { "note" }, WHITE, CHROME, LINER, "glass"),
            M("retro", "Retro Fridge", 0.58f, 1, "left", 46, 14, "icebox", 36, 0.45f, 28, "chrome", 12, 0, false, "legs", "lever", new[] { "badge", "stripe" }, MINT, CHROME, LINER, "wire"),
            M("topFreezer", "Top-Freezer Fridge", 0.62f, 1, "right", 14, 12, "freezer", 16, 0.95f, null, "kick", 12, 0, true, "none", "pocket", new[] { "magnets" }, ALMOND, ALMOND_METAL, LINER, "glass"),
            M("bottomFreezer", "Bottom-Freezer Fridge", 0.64f, 1, "left", 12, 12, "band", 10, 0, null, "drawer", 18, 0.85f, true, "none", "bar", new string[0], STEEL, BRUSHED, LINER, "glass"),
            M("sideBySide", "Side-by-Side Fridge", 0.7f, 2, null, 12, 12, "band", 10, 0, null, "grille", 14, 0, true, "none", "bar", new[] { "dispenser" }, BLACK, DARK_METAL, LINER, "glass"),
            M("frenchDoor", "French-Door Fridge", 0.72f, 2, null, 12, 12, "band", 10, 0, null, "drawers", 16, 0.62f, true, "none", "bar", new[] { "dispenser", "display" }, BLUE_STEEL, BRUSHED, LINER, "glass"),
            M("restaurant", "Restaurant Fridge", 0.8f, 2, null, 8, 8, "header", 18, 0.3f, null, "grille", 14, 0, false, "casters", "long", new[] { "lock", "plate" }, STEEL, BRUSHED, LINER_GREY, "wire"),
        });

        static SortModel[] Build(SortModel[] list)
        {
            for (int i = 0; i < list.Length; i++) { list[i].Index = i; list[i].Size = SIZE_NAMES[i]; }
            return list;
        }

        /// <summary>The fridge number i (0 SMALL … 6 VERY VERY LARGE); `theme` is always the fridge now (kept for the
        /// callers).</summary>
        public static SortModel ModelOf(string theme, int i) => FRIDGES[System.Math.Max(0, System.Math.Min(6, i))];
        public static int Count => FRIDGES.Length;
    }
}
