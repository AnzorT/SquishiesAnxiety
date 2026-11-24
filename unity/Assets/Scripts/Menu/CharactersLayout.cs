// The Characters page as tools/unity/export-pages.mjs cut it out of the app (Resources/Characters/characters.json).
// Plain C#: Unity reads it with JsonUtility, tools/unity/pages-test with System.Text.Json. Units: see CharactersPageKit.cs.
using System;

namespace SquishSquad.Menu
{
    [Serializable]
    public class CharactersLayout
    {
        public const string Root = "Characters/";

        public PageRef reference;
        public PagePic bg, head, rays, side, glow, centre, bulb, bulbW, prev, next, pv, me, choose, shop, toast;
        public Sep sep;
        public float[] back, ring, rig, who, actAt, toastText;
        public Stripe[] stripes;
        public Label[] labels;
        public CardSet[] cards;
        public StillSet[] stills;
        public Plate[] plates;
        public RarTag[] rarTags;
        public SetTag[] setTags;
        public Gs gs;
        public Creature[] roster;
        public Group[] groups;
        public NamedKey[] sets;
        public Rarity[] rar;
        public Row row;
        public Demo demo;
        public float awayAt;

        [Serializable] public class Sep : PagePic { public float[] grp; }
        [Serializable] public class Stripe : PagePic { public float deg; }
        [Serializable] public class Label : PagePic { public string name; }
        [Serializable] public class CardSet { public string key; public PagePic card, locked; }
        [Serializable] public class StillSet { public string key; public PagePic still, sil, you; }
        [Serializable] public class Plate : PagePic { public string key; }
        [Serializable] public class RarTag : PagePic { public int rar; }
        [Serializable] public class SetTag : PagePic { public string set; }
        [Serializable] public class GsCard : PagePic { public string key; }
        [Serializable] public class Tip : PagePic { public string text; }

        /// <summary>The loading screen, "Gathering your squad".</summary>
        [Serializable]
        public class Gs
        {
            public PagePic bg, rays, title, bk, band;
            public float[] table, deck, cw;
            public PagePic[] backs, counts;
            public Tip[] tips;
            public GsCard[] cards;
            public string[] tipsText;
        }

        [Serializable] public class Creature { public int id; public string key, name, set, appId; public int rar; public bool owned; }
        /// <summary>A group in the row: its box, its label's box and its cards' boxes (x, y, w, h each; row content px,
        /// the row's own padding included; y from the row's top) at scroll 0.</summary>
        [Serializable] public class Group { public string name; public float[] box, label, cards; public int[] ids; }
        [Serializable] public class NamedKey { public string key, name; }
        [Serializable] public class Rarity { public string label, dot; }
        [Serializable] public class Sticky { public float scroll; public float[] x; }
        [Serializable] public class Row { public float scrollWidth, clientWidth; public float[] box; public Sticky[] sticky; }
        [Serializable] public class Demo { public string sel; public string[] owned; }
    }
}
