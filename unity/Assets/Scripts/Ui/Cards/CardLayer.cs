// One drawn piece of a card (the dimmed screen, the card, a star, a button's face...): its SVG, its box (dp) and,
// every frame, where it is (a 2D transform, screen dp) and how opaque. A card is a list of these in paint order;
// Unity shows each as a UiPiece (CardPieces), the tests draw them all into one SVG (tools/unity/stack-test).
// No UnityEngine here, so the cards run outside Unity as well.
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    public sealed class CardLayer
    {
        public readonly string Name;
        public string Markup { get; private set; }
        public float W { get; private set; }
        public float H { get; private set; }
        /// <summary>Room drawn around the box (strokes, shadows, overhangs), dp.</summary>
        public float Margin { get; private set; } = 6;
        /// <summary>Goes up whenever the markup or box changes (the texture is drawn again).</summary>
        public int Version { get; private set; }

        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        /// <summary>A live character this layer stands for (the result card's three, TrioItem): the host draws the creature
        /// (Transform maps its rig's 0-100 box to the screen) instead of the markup.</summary>
        public CardCreature Creature;

        public CardLayer(string name) { Name = name; }

        public void Set(string markup, float w, float h, float margin = 6)
        {
            if (markup == Markup && w == W && h == H && margin == Margin) return;
            Markup = markup; W = w; H = h; Margin = margin;
            Version++;
        }
    }
}
