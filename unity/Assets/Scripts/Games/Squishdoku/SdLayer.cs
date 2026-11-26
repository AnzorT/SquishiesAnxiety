// One drawn piece of the Squishdoku screen: an SVG (made by SdArt or exported from the app) or a picture (a creature's
// cut-out, a Resources path), its box (dp), and each frame where it is (a 2D transform, screen dp), how opaque, whether
// it's shown. SdLevel lists them in paint order; Unity shows each as a UiPiece (SquishdokuGame), the tests draw them all
// into one SVG (tools/unity/squishdoku-test). No UnityEngine here.
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdLayer
    {
        public readonly string Name;
        public string Markup { get; private set; }
        /// <summary>A picture (Resources path) filling the box, instead of markup.</summary>
        public string Picture { get; private set; }
        public float W { get; private set; }
        public float H { get; private set; }
        public float Margin { get; private set; } = 6;
        /// <summary>Goes up whenever what's drawn changes.</summary>
        public int Version { get; private set; }

        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        /// <summary>A card's live character (the result card's three, the fail card's sad one: CardLayer.Creature): the host
        /// draws the creature (Transform maps its rig's 0-100 box to the screen) instead of the markup.</summary>
        public CardCreature Creature;

        public SdLayer(string name) { Name = name; }

        public SdLayer Set(string markup, float w, float h, float margin = 6)
        {
            if (markup == Markup && Picture == null && w == W && h == H && margin == Margin) return this;
            Markup = markup; Picture = null; W = w; H = h; Margin = margin;
            Version++;
            return this;
        }

        public SdLayer SetPicture(string href, float w, float h)
        {
            if (href == Picture && w == W && h == H) return this;
            Picture = href; Markup = null; W = w; H = h; Margin = 0;
            Version++;
            return this;
        }

        /// <summary>A card's layer as one of these (same markup, place and opacity), kept per card layer.</summary>
        public static SdLayer Mirror(CardLayer c, System.Collections.Generic.Dictionary<CardLayer, SdLayer> cache)
        {
            if (!cache.TryGetValue(c, out var l)) cache[c] = l = new SdLayer(c.Name);
            l.Set(c.Markup, c.W, c.H, c.Margin);
            l.Transform = c.Transform; l.Opacity = c.Opacity; l.Visible = c.Visible;
            l.Creature = c.Creature;
            return l;
        }
    }

    /// <summary>A creature the board stands up: its cut-out (Resources path) and its height / width; and, when it has
    /// them (src/squishdoku/bodies.js, Resources/Squishdoku/bodies), its whole body in three faces: `Body` + "-idle",
    /// "-happy", "-sad" (and "-red", the red flash's shape), `BodyAr` their height / width.</summary>
    public sealed class SdCreature
    {
        /// <summary>Resources/Squishdoku/bodies.json: each creature with faces, its height / width (set by the host).</summary>
        public static System.Collections.Generic.IDictionary<string, float> Bodies = new System.Collections.Generic.Dictionary<string, float>();
        public string Key, Picture;
        public float Ar;
        public string Body => Bodies.ContainsKey(Key) ? "Squishdoku/bodies/" + Key : null;
        public float BodyAr => Bodies.TryGetValue(Key, out var ar) ? ar : Ar;
        public SdCreature(string key, string picture, float ar) { Key = key; Picture = picture; Ar = ar; }
        /// <summary>The player owns it (a board takes the player's own first).</summary>
        public bool Mine;

        /// <summary>`k` creatures for a board or the score: the player's own first (at random among them), then the others
        /// (at random), no repeats while there are more; repeated only when the roster is smaller than `k`. (The app took
        /// the player's own alone: one owned made every piece that one. Since 2026-11-26, the user: the others fill in.)</summary>
        public static SdCreature[] Pick(SdCreature[] roster, int k)
        {
            var mine = new System.Collections.Generic.List<SdCreature>();
            var rest = new System.Collections.Generic.List<SdCreature>();
            foreach (var c in roster) if (c != null) (c.Mine ? mine : rest).Add(c);
            var o = new System.Collections.Generic.List<SdCreature>();
            foreach (var pool in new[] { mine, rest })
                while (o.Count < k && pool.Count > 0) { int i = (int)System.Math.Floor(SdLevel.Random() * pool.Count); o.Add(pool[i]); pool.RemoveAt(i); }
            while (o.Count < k) o.Add(roster.Length > 0 ? roster[o.Count % roster.Length] : null);
            return o.ToArray();
        }

        /// <summary>bodies.json's { key: ar } (flat: one number per key).</summary>
        public static System.Collections.Generic.Dictionary<string, float> ParseBodies(string json)
        {
            var o = new System.Collections.Generic.Dictionary<string, float>();
            foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(json ?? "", "\"(\\w+)\"\\s*:\\s*([0-9.]+)"))
                o[m.Groups[1].Value] = float.Parse(m.Groups[2].Value, System.Globalization.CultureInfo.InvariantCulture);
            return o;
        }
    }
}
