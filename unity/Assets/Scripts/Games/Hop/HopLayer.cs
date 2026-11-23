// One drawn thing of the Squish Hop screen (the room picture, a cushion, a squishy, the HUD...): what it shows and,
// every frame, where (a 2D transform to screen dp), how opaque and in what paint order. HopLevel keeps a list of these;
// Unity shows each as a piece (HopGame), the test draws them all into one SVG (tools/unity/hop-test). No UnityEngine
// here, so the level runs outside Unity as well.
//   an SVG (Markup, W x H dp, with Margin of room around it), or
//   a picture (Picture: a Resources path) filling W x H, optionally showing only part of it (Clip: the box it's cut
//   to, in its own dp; Tile: repeated every TileW x TileH dp), or
//   a picture laid on the board's plane in perspective (Grid: the screen points of a (GridN+1)² grid over it, row by row)
using SquishSquad.Vector;

namespace SquishSquad.Games.Hop
{
    public sealed class HopLayer
    {
        public readonly string Name;
        public string Markup { get; private set; }
        public float W { get; private set; }
        public float H { get; private set; }
        public float Margin { get; private set; } = 6;
        /// <summary>Goes up whenever what it shows changes (Unity draws its texture again).</summary>
        public int Version { get; private set; }

        public string Picture { get; private set; }
        public float[] Clip { get; private set; }       // x, y, w, h (its own dp), or null
        public float TileW { get; private set; }        // > 0: the picture repeats
        public float TileH { get; private set; }
        public double[] Grid { get; private set; }      // x, y pairs, screen dp (Transform is not applied)
        public int GridN { get; private set; }

        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        public int Order;

        public HopLayer(string name, int order = 0) { Name = name; Order = order; }

        public HopLayer Svg(string markup, float w, float h, float margin = 6)
        {
            if (markup == Markup && w == W && h == H && margin == Margin && Picture == null) return this;
            Markup = markup; W = w; H = h; Margin = margin; Picture = null; Grid = null;
            Version++;
            return this;
        }

        public HopLayer Pic(string picture, float w, float h, float[] clip = null, float tileW = 0, float tileH = 0)
        {
            if (picture == Picture && w == W && h == H && Same(clip, Clip) && tileW == TileW && tileH == TileH && Grid == null) return this;
            Picture = picture; W = w; H = h; Clip = clip; TileW = tileW; TileH = tileH; Markup = null; Grid = null;
            Version++;
            return this;
        }

        public HopLayer Plane(string picture, double[] grid, int n)
        {
            Picture = picture; Grid = grid; GridN = n; Markup = null; Clip = null; W = H = 0;
            Version++;
            return this;
        }

        static bool Same(float[] a, float[] b)
        {
            if (a == null || b == null) return a == b;
            for (int i = 0; i < 4; i++) if (a[i] != b[i]) return false;
            return true;
        }
    }
}
