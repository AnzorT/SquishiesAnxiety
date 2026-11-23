// Where everything of a Squish Sort level goes (src/sort/Container.js geometry / sizes / slotCenter / slotAt and
// src/sort/Game.js trayGeo / trayGeoWide / trayCenter), in dp, the play area's top-left at 0, 0. The same numbers the
// app works out, so the game hits the rects it draws.
using System;

namespace SquishSquad.Games.Sort
{
    public sealed class ContainerGeo
    {
        public float S, W, H, Top, Up, Bottom, Crisper, BodyW, BodyH, Feet, Dw, Persp, Deg, Bx, By, Ix, Iy;
        public int Rows, Cols;
    }

    public sealed class TrayGeo
    {
        public float Cell, Tw, Th, Tx, Ty;
        public int PerRow, Rows;
        public bool Wide;
    }

    public static class SortGeometry
    {
        public const float RING = 3, BORDER = 3, WALL = 8, SHELF = 8, LIP = 7;
        public const float INSET = RING + BORDER + WALL;
        static readonly float[] DEGS = { 106, 102, 98, 94, 90 };

        public static float FeetOf(string kind) => kind switch
        {
            "nubs" => 7, "legs" => 16, "casters" => 16, "tapered" => 14, "balls" => 12, "buns" => 11, "bracket" => 10, _ => 0,
        };

        // how far a door `dw` wide, opened `deg` with perspective `p`, reaches past its hinge on screen
        static double Reach(double dw, double deg, double p)
        {
            double a = deg * Math.PI / 180;
            double f = p / (p - dw * Math.Sin(a));
            return (dw / 2 - dw * Math.Cos(a)) * f - dw / 2;
        }

        static float PerspOf(float dw) => Math.Max(900, JsRound(dw * 5));
        public static float JsRound(double v) => (float)Math.Floor(v + 0.5);

        public static ContainerGeo Sizes(SortModel m, int rows, int cols, float S)
        {
            float W = S * cols, H = rows * (S + SHELF);
            float top = JsRound(m.TopA + m.TopB * S), bottom = JsRound(m.BottomA + m.BottomB * S);
            float crisper = m.Crisper ? JsRound(S * 0.4 + 8) : 0;
            float bodyW = W + 2 * INSET;
            float bodyH = 2 * (RING + BORDER) + LIP + top + H + crisper + bottom;
            float dw = m.Doors == 1 ? W : W / 2;
            float up = m.TopKeep.HasValue ? top - m.TopKeep.Value : 0;
            return new ContainerGeo { S = S, W = W, H = H, Rows = rows, Cols = cols, Top = top, Up = up, Bottom = bottom, Crisper = crisper, BodyW = bodyW, BodyH = bodyH, Feet = FeetOf(m.FeetKind), Dw = dw, Persp = PerspOf(dw), Deg = DEGS[0] };
        }

        /// <summary>Container.js geometry: a `rows` x `cols` `m` in a `w` x `h` area, `trayH` left at the bottom.</summary>
        public static ContainerGeo Geometry(float w, float h, int rows, int cols, SortModel m, float trayH, float maxS = 96)
        {
            float availH = h - trayH - 10;
            float perS = rows + m.TopB + m.BottomB + (m.Crisper ? 0.4f : 0);
            float fixedH = 2 * (RING + BORDER) + LIP + m.TopA + m.BottomA + (m.Crisper ? 8 : 0) + rows * SHELF + FeetOf(m.FeetKind);
            // (JS doubles: w * share, then floor)
            double s = Math.Min(Math.Min(((double)w * m.Share - 2 * INSET) / cols, ((double)availH - fixedH) / perS), maxS);
            float S = (float)Math.Max(30, Math.Floor(s));
            var z = Sizes(m, rows, cols, S);
            float room = m.Doors == 1 ? w - z.BodyW - 8 : (w - z.BodyW) / 2 - 2;
            float deg = DEGS[DEGS.Length - 1];
            foreach (var d in DEGS) if (Reach(z.Dw, d, z.Persp) - INSET <= room) { deg = d; break; }
            double over = Math.Max(0, Reach(z.Dw, deg, z.Persp) - INSET);
            double shift = m.Doors == 1 ? (m.Hinge == "right" ? -over / 2 : over / 2) : 0;
            z.Deg = deg;
            z.Bx = JsRound((w - z.BodyW) / 2.0 + shift);
            z.By = Math.Max(4, JsRound((availH - (z.BodyH + z.Feet)) / 2.0) + 2);
            z.Ix = z.Bx + INSET;
            z.Iy = z.By + RING + BORDER + z.Top;
            return z;
        }

        public static (float x, float y) SlotCenter(ContainerGeo g, int i) => (g.Ix + (i % g.Cols) * g.S + g.S / 2, g.Iy + (i / g.Cols) * (g.S + SHELF) + g.S / 2);

        /// <summary>The slot under a point inside, or -1.</summary>
        public static int SlotAt(ContainerGeo g, float x, float y)
        {
            const float pad = 12;
            if (x < g.Ix - pad || x > g.Ix + g.W + pad || y < g.Iy - pad || y > g.Iy + g.H + pad) return -1;
            int c = Math.Max(0, Math.Min(g.Cols - 1, (int)Math.Floor((x - g.Ix) / g.S)));
            int r = Math.Max(0, Math.Min(g.Rows - 1, (int)Math.Floor((y - g.Iy) / (g.S + SHELF))));
            return r * g.Cols + c;
        }

        // the tray: one row up to 6, else two (upright)
        public static TrayGeo Tray(float w, float h, int cap)
        {
            int perRow = cap > 6 ? (int)Math.Ceiling(cap / 2.0) : Math.Max(cap, 4);
            int rows = cap > 6 ? 2 : 1;
            float cell = (float)Math.Floor(Math.Min(58, (w - 48) / perRow));
            float tw = perRow * cell + 24, th = rows * cell + 26;
            return new TrayGeo { Cell = cell, PerRow = perRow, Rows = rows, Tw = tw, Th = th, Tx = JsRound((w - tw) / 2), Ty = h - th - 6 };
        }

        // landscape: a column at the right of the play area, one or two spots across
        public static TrayGeo TrayWide(float w, float h, int cap)
        {
            int perRow = cap > 4 ? 2 : 1;
            int rows = (int)Math.Ceiling(cap / (double)perRow);
            float cell = (float)Math.Floor(Math.Min(58, (h - 44) / rows));
            float tw = perRow * cell + 24, th = rows * cell + 26;
            return new TrayGeo { Cell = cell, PerRow = perRow, Rows = rows, Tw = tw, Th = th, Tx = w - tw - 10, Ty = JsRound((h - th) / 2), Wide = true };
        }

        public static (float x, float y) TrayCenter(TrayGeo tg, int j) => (tg.Tx + 12 + (j % tg.PerRow) * tg.Cell + tg.Cell / 2, tg.Ty + 15 + (j / tg.PerRow) * tg.Cell + tg.Cell / 2);
    }
}
