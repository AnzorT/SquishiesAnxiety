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

        /// <summary>The page with only the creatures `on` says (webgame/app/menu.js M.characters: `all =
        /// ROSTER.filter(on)`, SquishConfig.creatureOn: the app's hiddenKeys, config/roster), a group left with none
        /// gone, the row laid out again as the page's flex row does: each group's cards 63 apart, the groups 22 apart,
        /// the same room after the last. All out: this page as it is.</summary>
        public CharactersLayout Only(Func<Creature, bool> on)
        {
            const float STEP = 63, GAP = 22;
            if (groups == null || groups.Length == 0 || roster == null) return this;
            var byId = new System.Collections.Generic.Dictionary<int, Creature>();
            foreach (var c in roster) byId[c.id] = c;
            bool Shown(int id) => !byId.TryGetValue(id, out var c) || on(c);
            bool all = true;
            foreach (var g in groups) foreach (var id in g.ids) if (!Shown(id)) all = false;
            if (all) return this;
            var last = groups[groups.Length - 1];
            float tail = row != null ? row.scrollWidth - (last.box[0] + last.box[2]) : 54;
            var gs = new System.Collections.Generic.List<Group>();
            var ls = new System.Collections.Generic.List<Label>();
            float x = groups[0].box[0];
            for (int gi = 0; gi < groups.Length; gi++)
            {
                var g = groups[gi];
                var keep = new System.Collections.Generic.List<int>();
                for (int i = 0; i < g.ids.Length; i++) if (Shown(g.ids[i])) keep.Add(i);
                if (keep.Count == 0) continue;
                float dx = x - g.box[0];
                var ng = new Group
                {
                    name = g.name, ids = new int[keep.Count], cards = new float[keep.Count * 4],
                    box = new[] { x, g.box[1], g.box[2] - (g.ids.Length - keep.Count) * STEP, g.box[3] },
                    label = g.label == null ? null : new[] { g.label[0] + dx, g.label[1], g.label[2], g.label[3] },
                };
                for (int k = 0; k < keep.Count; k++)
                {
                    int i = keep[k];
                    ng.ids[k] = g.ids[i];
                    ng.cards[k * 4] = x + (g.cards[0] - g.box[0]) + k * STEP;
                    ng.cards[k * 4 + 1] = g.cards[i * 4 + 1]; ng.cards[k * 4 + 2] = g.cards[i * 4 + 2]; ng.cards[k * 4 + 3] = g.cards[i * 4 + 3];
                }
                gs.Add(ng);
                ls.Add(labels != null && gi < labels.Length ? labels[gi] : null);   // (its picture; it's placed by the group's `label`)
                x += ng.box[2] + GAP;
            }
            var page = (CharactersLayout)MemberwiseClone();
            page.groups = gs.ToArray();
            page.labels = ls.ToArray();
            page.roster = Array.FindAll(roster, c => on(c));
            if (row != null) page.row = new Row { scrollWidth = gs.Count > 0 ? x - GAP + tail : row.clientWidth, clientWidth = row.clientWidth, box = row.box, sticky = row.sticky };
            return page;
        }

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
