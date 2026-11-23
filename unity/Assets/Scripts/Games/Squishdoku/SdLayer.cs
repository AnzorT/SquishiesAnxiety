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
            return l;
        }
    }

    /// <summary>A creature the board stands up: its cut-out (Resources path) and its height / width.</summary>
    public sealed class SdCreature
    {
        public string Key, Picture;
        public float Ar;
        public SdCreature(string key, string picture, float ar) { Key = key; Picture = picture; Ar = ar; }
    }
}
