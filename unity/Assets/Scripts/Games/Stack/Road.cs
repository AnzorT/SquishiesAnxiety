// Squish Stack's forest road (develop: src/stack/road.js, 2026-11-17, the user: "let it be the trees forest", the
// background scrolling with the road, the road part of the background): the forest pictures (Resources/Stack/forest/
// <season>-<i>.jpg, assets/stack/forest-*.jpg, drawn by tools/stack/forest.mjs with this road baked in) side by side,
// and the levels standing on the same road like stepping stones, a band's wooden sign at its far edge. Pure numbers,
// in the pictures' own units (a tile is 1000 x 460; the map scales them to its height).
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Stack
{
    public static class Road
    {
        public const double TILE_W = 1000, TILE_H = 460;
        public const int TILES = 4;
        public const double ROAD_W = 58;
        public const double GAP = 128, SIGN_GAP = 150, START = 150, END = 260;
        const double TAU = Math.PI * 2;

        /// <summary>The road's middle line at x (repeats every tile).</summary>
        public static double Y(double x) => 304 + 24 * Math.Sin(TAU * x / 500 + 0.4) + 12 * Math.Sin(3 * TAU * x / TILE_W + 1.1);

        /// <summary>layout(list): the levels' places along the road and the bands' signs (i: the band's first level's index).</summary>
        public static (List<double> nodes, List<(double x, int i)> signs, double width) Layout(IReadOnlyList<int> bands)
        {
            var nodes = new List<double>();
            var signs = new List<(double, int)>();
            double x = START;
            for (int i = 0; i < bands.Count; i++)
            {
                if (i == 0 || bands[i] != bands[i - 1])
                {
                    if (i > 0) x += SIGN_GAP - GAP;
                    signs.Add((x, i));
                    x += SIGN_GAP;
                }
                nodes.Add(x);
                x += GAP;
            }
            return (nodes, signs, x - GAP + END);
        }
    }
}
