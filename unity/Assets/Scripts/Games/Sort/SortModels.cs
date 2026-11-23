// The drawing data of Squish Sort's fridges and cupboards (src/sort/models.js: the seven of each, their parts and
// colours over the fridge's or the cupboard's defaults) and of its two themes (src/sort/themes.js: the HUD's colour,
// the tray). Catalog.cs has the names the rules use; this is what SortArt draws them from.
using System.Collections.Generic;

namespace SquishSquad.Games.Sort
{
    public sealed class ShelfLook { public string Top, Face, Edge; public bool Wire; }

    public sealed class ModelColors
    {
        public string Ring, TrimC, Feet, Lamp, Dark;
        public string[] Body, Door, DoorInner, Inside, Handle;
        public ShelfLook Shelf;
        public string Trim => TrimC;
    }

    public sealed class SortModel
    {
        public string Kind, Key, Name, Size;
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
        public ModelColors C;
        public bool Has(string deco) { foreach (var d in Deco) if (d == deco) return true; return false; }
    }

    public sealed class SortThemeLook
    {
        public string Key, Name, Ring;
        public string TrayRing, TrayLabel;
        public string[] TrayColors;
    }

    public static class SortModels
    {
        // ---- the colours they start from ----------------------------------------------------------------------------
        sealed class Partial
        {
            public string Ring, Trim, Feet, Lamp, Dark;
            public string[] Body, Door, DoorInner, Inside, Handle;
            public ShelfLook Shelf;
        }

        // (each model's own colours, until Build lays them over the defaults, as models.js mix())
        static readonly Dictionary<SortModel, Partial> Own = new Dictionary<SortModel, Partial>();

        static readonly Partial FRIDGE = new Partial
        {
            Ring = "#34485c", Body = new[] { "#ffffff", "#f2f6f9", "#dbe4ec" }, Door = new[] { "#ffffff", "#f4f8fb", "#e1e9f0" },
            DoorInner = new[] { "#f4f9fc", "#dcebf4" }, Inside = new[] { "#ffffff", "#eef7fc", "#d6ebf6" },
            Shelf = new ShelfLook { Top = "rgba(255,255,255,0.95)", Face = "rgba(186,224,246,0.6)", Edge = "#9ccbe4" },
            Trim = "#c3d1dd", Handle = new[] { "#ffffff", "#dfe6ec", "#9eabb8" }, Feet = "#4c5b69", Lamp = "#ffffff", Dark = "#2b3540",
        };
        static readonly Partial CUPBOARD = new Partial
        {
            Ring = "#5a3412", Body = new[] { "#f6d3a2", "#e3b277", "#c98f50" }, Door = new[] { "#f8dcb2", "#e9bc84", "#d29a5b" },
            DoorInner = new[] { "#f2cf9d", "#d9a668" }, Inside = new[] { "#fff3de", "#f6dfb9", "#e9c690" },
            Shelf = new ShelfLook { Top = "#f2c78e", Face = "#c98f50", Edge = "#8a5a2b" },
            Trim = "#8a5a2b", Handle = new[] { "#fff6b0", "#f0c43a", "#b88a10" }, Feet = "#5a3412", Lamp = "#fff3c4", Dark = "#4a2a0e",
        };
        // stainless steel
        static Partial Steel() => new Partial { Body = new[] { "#f4f6f8", "#d3d9df", "#b3bcc6" }, Door = new[] { "#f7f9fa", "#d8dee4", "#b9c2cb" }, Trim = "#9aa5b1", Handle = new[] { "#ffffff", "#c9d0d7", "#7d8894" } };

        static SortModel M(string key, string name, float share, int doors, string hinge, float r0, float r1, string top, float ta, float tb, float? keep,
            string bottom, float ba, float bb, bool crisper, string feet, string handle, string[] deco, Partial c)
        {
            var m = new SortModel { Key = key, Name = name, Share = share, Doors = doors, Hinge = hinge, Radius = new[] { r0, r1 }, TopKind = top, TopA = ta, TopB = tb, TopKeep = keep,
                BottomKind = bottom, BottomA = ba, BottomB = bb, Crisper = crisper, FeetKind = feet, Handle = handle, Deco = deco };
            Own[m] = c;
            return m;
        }

        static readonly SortModel[] FRIDGES =
        {
            M("mini", "Mini Fridge", 0.56f, 1, "right", 16, 16, "icebox", 12, 0.5f, 4, "grille", 14, 0, false, "nubs", "recess", new[] { "note" }, new Partial()),
            M("retro", "Retro Fridge", 0.58f, 1, "left", 46, 14, "icebox", 36, 0.45f, 28, "chrome", 12, 0, false, "legs", "lever", new[] { "badge" },
                new Partial { Ring = "#1d5a52", Body = new[] { "#dcfff4", "#aaeeda", "#7ed8bf" }, Door = new[] { "#e2fff6", "#b4f1df", "#88dcc4" }, DoorInner = new[] { "#effffa", "#c9f2e5" }, Trim = "#5fbfa5", Feet = "#9aa5b1" }),
            M("topFreezer", "Top-Freezer Fridge", 0.62f, 1, "right", 14, 12, "freezer", 16, 0.95f, null, "kick", 12, 0, true, "none", "pocket", new[] { "magnets" },
                new Partial { Ring = "#5a4a2a", Body = new[] { "#fffaf0", "#f5ead2", "#e4d3ad" }, Door = new[] { "#fffbf3", "#f7eed9", "#e8d9b8" }, Trim = "#cdb98d", Handle = new[] { "#fffdf6", "#e9dcc0", "#b9a37a" } }),
            M("bottomFreezer", "Bottom-Freezer Fridge", 0.64f, 1, "left", 12, 12, "band", 10, 0, null, "drawer", 18, 0.85f, true, "none", "bar", new[] { "brushed" }, Steel()),
            M("sideBySide", "Side-by-Side Fridge", 0.7f, 2, null, 12, 12, "band", 10, 0, null, "grille", 14, 0, true, "none", "bar", new[] { "dispenser", "brushed" },
                new Partial { Ring = "#1c2229", Body = new[] { "#6e7884", "#4a525c", "#30363e" }, Door = new[] { "#78838f", "#525b66", "#363d46" }, DoorInner = new[] { "#f4f9fc", "#dcebf4" }, Trim = "#262c33", Handle = new[] { "#f2f4f6", "#b4bcc4", "#6b7682" } }),
            M("frenchDoor", "French-Door Fridge", 0.72f, 2, null, 12, 12, "band", 10, 0, null, "drawers", 16, 0.62f, true, "none", "bar", new[] { "dispenser", "display", "brushed" },
                With(Steel(), p => { p.Ring = "#2e3d52"; p.Body = new[] { "#eef3f9", "#c7d3e0", "#a3b2c3" }; p.Door = new[] { "#f3f7fb", "#cdd8e4", "#a9b8c8" }; })),
            M("restaurant", "Restaurant Fridge", 0.8f, 2, null, 8, 8, "header", 18, 0.3f, null, "grille", 14, 0, false, "casters", "long", new[] { "brushed", "lock" },
                With(Steel(), p => { p.Ring = "#2a3138"; p.Inside = new[] { "#f6f8fa", "#e2e7ec", "#cbd3db" }; p.Shelf = new ShelfLook { Top = "rgba(255,255,255,0.9)", Face = "rgba(150,162,176,0.55)", Edge = "#7d8894", Wire = true }; p.DoorInner = new[] { "#eef1f4", "#d0d7de" }; })),
        };

        static readonly SortModel[] CUPBOARDS =
        {
            M("bedside", "Bedside Cabinet", 0.56f, 1, "left", 8, 8, "drawer", 12, 0.42f, null, "base", 8, 0, false, "tapered", "knob", new[] { "panel" }, new Partial()),
            M("hall", "Hall Cupboard", 0.58f, 1, "right", 6, 6, "cornice", 18, 0, null, "plinth", 12, 0, false, "none", "knob", new[] { "panel2" },
                new Partial { Ring = "#4f4334", Body = new[] { "#fffaf0", "#f1e6d1", "#dccbab" }, Door = new[] { "#fffcf5", "#f4ead8", "#e0d1b4" }, DoorInner = new[] { "#f6ecd9", "#e3d2b1" }, Trim = "#b9a682", Feet = "#4f4334" }),
            M("toy", "Toy Cupboard", 0.64f, 2, null, 23, 18, "star", 34, 0, null, "base", 10, 0, false, "balls", "knob", new[] { "cutouts" },
                new Partial { Body = new[] { "#ffd7a3", "#eaa865", "#c47a3a" }, Door = new[] { "#ffe0b6", "#f2b673", "#d68c46" }, DoorInner = new[] { "#f6c58c", "#d99a5a" }, Inside = new[] { "#fff6e6", "#ffe4bf", "#f6cd96" },
                    Shelf = new ShelfLook { Top = "#f2bf86", Face = "#c98a4a", Edge = "#8a4f1e" }, Trim = "#8a4f1e", Handle = new[] { "#fff6b0", "#ffd23a", "#d99400" } }),
            M("wardrobe", "Wardrobe", 0.66f, 2, null, 6, 6, "cornice", 18, 0, null, "drawer1", 14, 0.5f, false, "bracket", "pull", new[] { "panel", "rail" },
                new Partial { Ring = "#2e1a0b", Body = new[] { "#b9835a", "#93603a", "#6e4424" }, Door = new[] { "#c28c62", "#9c6842", "#77492a" }, DoorInner = new[] { "#d9ab7c", "#b9845a" }, Inside = new[] { "#f5dcb8", "#e6c08e", "#d2a66f" },
                    Shelf = new ShelfLook { Top = "#d8a978", Face = "#93603a", Edge = "#5a3518" }, Trim = "#5a3518", Feet = "#2e1a0b" }),
            M("mirror", "Mirror Wardrobe", 0.7f, 2, null, 6, 6, "cornice", 16, 0, null, "drawers2", 14, 0.5f, false, "none", "pull", new[] { "mirror", "rail" },
                new Partial { Ring = "#3f4c5c", Body = new[] { "#ffffff", "#eef1f5", "#d6dce4" }, Door = new[] { "#ffffff", "#f1f4f7", "#dbe1e8" }, DoorInner = new[] { "#f7f9fb", "#e2e7ed" }, Inside = new[] { "#fff6e8", "#f3e1c4", "#e2c9a0" },
                    Shelf = new ShelfLook { Top = "#f1d9b4", Face = "#d2b080", Edge = "#9c7a4c" }, Trim = "#b9c3cf", Handle = new[] { "#ffffff", "#cfd6dd", "#8995a2" }, Feet = "#3f4c5c" }),
            M("armoire", "Grand Armoire", 0.72f, 2, null, 28, 8, "arch", 20, 0.3f, null, "skirt", 14, 0, false, "buns", "knob", new[] { "arched", "rail" },
                new Partial { Ring = "#3a120c", Body = new[] { "#d27258", "#a9472f", "#7c2e1e" }, Door = new[] { "#da7c60", "#b04f35", "#843322" }, DoorInner = new[] { "#e39a78", "#c06e4e" }, Inside = new[] { "#fde7d2", "#f2c9a6", "#e0a982" },
                    Shelf = new ShelfLook { Top = "#e9ad84", Face = "#a9472f", Edge = "#6a2516" }, Trim = "#ffd27a", Feet = "#3a120c", Dark = "#3a120c" }),
            M("grand", "Giant Wardrobe", 0.8f, 2, null, 6, 6, "cabinets", 14, 0.5f, null, "drawersRow", 14, 0.45f, false, "none", "pull", new[] { "panel2", "rail" },
                new Partial { Ring = "#24160a", Body = new[] { "#94704a", "#6f5032", "#4f361f" }, Door = new[] { "#9c7850", "#765638", "#553a22" }, DoorInner = new[] { "#c9a074", "#a37a52" }, Inside = new[] { "#f3ddbb", "#e2c293", "#cfa66f" },
                    Shelf = new ShelfLook { Top = "#d9b07e", Face = "#7a5a38", Edge = "#3f2a15" }, Trim = "#ffd27a", Feet = "#24160a", Dark = "#24160a" }),
        };

        static Partial With(Partial p, System.Action<Partial> f) { f(p); return p; }


        static readonly SortModel[] BuiltFridges = Build("fridge", FRIDGE, FRIDGES);
        static readonly SortModel[] BuiltCupboards = Build("cupboard", CUPBOARD, CUPBOARDS);

        static SortModel[] Build(string kind, Partial b, SortModel[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                var m = list[i];
                var c = OwnOf(m);
                m.Kind = kind; m.Index = i; m.Size = Models.SIZE_NAMES[i];
                m.C = new ModelColors
                {
                    Ring = c.Ring ?? b.Ring, TrimC = c.Trim ?? b.Trim, Feet = c.Feet ?? b.Feet, Lamp = c.Lamp ?? b.Lamp, Dark = c.Dark ?? b.Dark,
                    Body = c.Body ?? b.Body, Door = c.Door ?? b.Door, DoorInner = c.DoorInner ?? b.DoorInner, Inside = c.Inside ?? b.Inside, Handle = c.Handle ?? b.Handle,
                    Shelf = c.Shelf == null ? b.Shelf : new ShelfLook { Top = c.Shelf.Top ?? b.Shelf.Top, Face = c.Shelf.Face ?? b.Shelf.Face, Edge = c.Shelf.Edge ?? b.Shelf.Edge, Wire = c.Shelf.Wire || b.Shelf.Wire },
                };
            }
            return list;
        }

        static Partial OwnOf(SortModel m) => Own.TryGetValue(m, out var p) ? p : new Partial();

        /// <summary>A theme's model number i (0 SMALL … 6 VERY VERY LARGE).</summary>
        public static SortModel ModelOf(string theme, int i) => (theme == "cupboard" ? BuiltCupboards : BuiltFridges)[System.Math.Max(0, System.Math.Min(6, i))];

        public static readonly Dictionary<string, SortThemeLook> THEMES = new Dictionary<string, SortThemeLook>
        {
            ["fridge"] = new SortThemeLook { Key = "fridge", Name = "Snack Fridge", Ring = "#1f5f7a", TrayRing = "#9a5a22", TrayColors = new[] { "#fff8ec", "#ffe6c4", "#f7cf98" }, TrayLabel = "COUNTER" },
            ["cupboard"] = new SortThemeLook { Key = "cupboard", Name = "Toy Cupboard", Ring = "#5a2e0e", TrayRing = "#a01a7a", TrayColors = new[] { "#fff2fb", "#ffd6f0", "#ffb8e4" }, TrayLabel = "TOY RUG" },
        };
    }
}
