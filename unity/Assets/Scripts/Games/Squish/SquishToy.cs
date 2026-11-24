// The squish itself (src/components/SquishyToy.js), ported line by line for the card (the only creature the squish
// game shows since REDESIGN_V6 step 4): the press points and their springs, the pointed funnel's mean (the puff),
// picking on the rest surface (the triangle grid and its ray walk, the nearest-vertex fallback), the drag that
// starts new press points (the jelly lag), the whole-body squash / wobble / orbit springs, and the card's own motion
// (SquishCard). Numbers are doubles as in JavaScript; the mesh's arrays are float as three's Float32Arrays.
//
// The dent is drawn by the vertex shader (Resources/SquishShaders/SquishCard.shader, the GLSL of SQUISH_VERTEX_GLSL
// line by line); this class hands it the same uniforms (PressUniform, Count, Dir, Dent) as uploadSquish.
// SquishShaderMath is that shader in C#, for the tests.
//
// Use: Tick(dt seconds, nowMs) once a frame (useFrame: applyPendingMove, then tickPhysics), then draw with
// MatrixWorld; PointerDown / PointerMove / PointerUp / Orbit / EndOrbit / CancelPoke from the touches (SquishScreen's
// PanResponder), ndc in -1..1 of the square stage, y up.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squish
{
    public enum PokeMode { None, Poke, Orbit }

    public sealed class Press
    {
        public double X, Y, Z, Amp, Vel, Target, MeanF;
        public bool Driven;
    }

    public sealed class TriangleGrid
    {
        public int N;
        public double MinX, MinY, MinZ, MaxX, MaxY, MaxZ, CsX, CsY, CsZ;
        public uint[] CellOffsets, CellTris;
    }

    public sealed class SquishToy
    {
        // PHYS (src/data/creatures.js)
        public const double PhysStiff = 0.55, PhysDamp = 0.68, WobbleKick = 0.4;
        public const int MaxPresses = 24;            // SQUISH_MAX_PRESSES
        const double MaxBulge = 1.14;
        const double FallEps = 2e-3;
        const double PressMoveEps = 0.008;
        const double RestEps = 1e-4;

        // --- the mesh (shared by every card) ---
        public readonly CardGeometry Geo;
        public readonly TriangleGrid Grid;
        public readonly double BoundRadius;
        public readonly int SampleStride;
        public readonly double DentDepthC, DentRadiusC, DentTipC;

        // --- makeSquishState() ---
        public readonly List<Press> Presses = new List<Press>();
        public readonly float[] PressUniform = new float[MaxPresses * 4];
        public double DentUserScale = 1, DentSign = 1;
        public V3 PressDir = new V3(0, 0, -1);
        public double Lift = 1;
        public bool DentTargetActive, AtRest = true;
        public V3? PendingMove;
        public PokeMode Mode = PokeMode.None;
        public V3? DragStartWorld, PressLocalSmoothed;
        public double PressHoldTime;
        public double GlobalSquash, GlobalSquashV, GlobalSquashTarget;
        public double WobbleRotX, WobbleRotXV, WobbleRotZ, WobbleRotZV;
        public double UserRotY, UserRotX, OrbitTargetY, OrbitTargetX, OrbitVelY, OrbitVelX;
        public double IdlePhase;

        // --- cardState() ---
        public bool Card, Crown;
        public Dictionary<string, Dictionary<string, Wave>> Moves;
        public double Head, Seed, ReactT, StK0 = 1, StK1 = 1, StY, SqSt = 0.4, SqDp = 0.72, SqX = 0.14, SqY = 0.26, SqR, GlowOpacity;
        public Move Mv = new Move();

        // --- the group's transform (Object3D: position, rotation (Euler XYZ), scale) and its world matrix ---
        public V3 Position, Scale = new V3(1, 1, 1);
        public double RotX, RotY, RotZ;
        public double[] MatrixWorld = M4.Identity();

        // --- the shader's uniforms (uploadSquish) ---
        public int UniformCount;
        public float[] UniformDir = { 0, 0, -1 };
        public float[] UniformDent = new float[4];
        public bool Uploaded;   // false until the first upload (three compiles the program on the first render)

        public readonly StageCamera Camera;
        /// <summary>Math.random (the release wobble's kick).</summary>
        public Func<double> Random = () => RandomSource.NextDouble();
        static readonly Random RandomSource = new Random();
        public Action OnSquish;
        public Action<double> OnRelease;

        int[] _rayStamp;
        uint _rayStampCounter;
        double[] _pickScratch;

        static CardGeometry _cardGeo;
        static TriangleGrid _cardGrid;

        /// <summary>A card (loadCardDataFromUrl + buildModelCreature(id, CARD_TUNING, ...) + cardState): one geometry
        /// and pick grid shared by every card.</summary>
        public static SquishToy MakeCard(CardData data, int stage, double seed, double idlePhase, StageCamera camera = null)
        {
            if (_cardGeo == null) { _cardGeo = SquishCard.Geometry(); _cardGrid = BuildTriangleGrid(_cardGeo.BasePos, _cardGeo.Index); }
            var s = new SquishToy(_cardGeo, _cardGrid, SquishCard.DentDepth, SquishCard.DentRadius, SquishCard.DentTip, camera ?? new StageCamera()) { IdlePhase = idlePhase };
            SquishCard.InitState(s, data, stage, seed);
            s.UpdateMatrix();
            return s;
        }

        public SquishToy(CardGeometry geo, TriangleGrid grid, double dentDepth, double dentRadius, double dentTip, StageCamera camera)
        {
            Geo = geo; Grid = grid; Camera = camera;
            DentDepthC = dentDepth; DentRadiusC = dentRadius; DentTipC = dentTip;
            BoundRadius = ComputeBoundRadius(geo.BasePos);
            SampleStride = Math.Max(1, (int)Math.Ceiling(geo.VertCount / 1500.0));
        }

        static double ComputeBoundRadius(float[] basePos)
        {
            double r2 = 0;
            for (int i = 0; i < basePos.Length; i += 3)
            {
                double d2 = (double)basePos[i] * basePos[i] + (double)basePos[i + 1] * basePos[i + 1] + (double)basePos[i + 2] * basePos[i + 2];
                if (d2 > r2) r2 = d2;
            }
            return Math.Sqrt(r2) * MaxBulge * 1.01;
        }

        // buildTriangleGrid
        public static TriangleGrid BuildTriangleGrid(float[] basePos, int[] indexArray)
        {
            int triCount = indexArray.Length / 3;
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity, minZ = double.PositiveInfinity;
            double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity, maxZ = double.NegativeInfinity;
            for (int i = 0; i < basePos.Length; i += 3)
            {
                double x = basePos[i], y = basePos[i + 1], z = basePos[i + 2];
                if (x < minX) minX = x;
                if (x > maxX) maxX = x;
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
                if (z < minZ) minZ = z;
                if (z > maxZ) maxZ = z;
            }
            const double pad = 1e-3;
            minX -= pad; minY -= pad; minZ -= pad;
            maxX += pad; maxY += pad; maxZ += pad;
            int n = (int)Math.Max(6, Math.Min(28, JsRound(Math.Cbrt(triCount) * 0.8)));
            double csX = (maxX - minX) / n, csY = (maxY - minY) / n, csZ = (maxZ - minZ) / n;
            int cellCount = n * n * n;
            var cellOffsets = new uint[cellCount + 1];
            var bounds = new int[triCount * 6];
            int CellOf(double v, double lo, double cs) => (int)Math.Max(0, Math.Min(n - 1, Math.Floor((v - lo) / cs)));
            for (int t = 0; t < triCount; t++)
            {
                int a = indexArray[t * 3] * 3, b = indexArray[t * 3 + 1] * 3, c = indexArray[t * 3 + 2] * 3;
                int x0 = CellOf(Min3(basePos[a], basePos[b], basePos[c]), minX, csX), x1 = CellOf(Max3(basePos[a], basePos[b], basePos[c]), minX, csX);
                int y0 = CellOf(Min3(basePos[a + 1], basePos[b + 1], basePos[c + 1]), minY, csY), y1 = CellOf(Max3(basePos[a + 1], basePos[b + 1], basePos[c + 1]), minY, csY);
                int z0 = CellOf(Min3(basePos[a + 2], basePos[b + 2], basePos[c + 2]), minZ, csZ), z1 = CellOf(Max3(basePos[a + 2], basePos[b + 2], basePos[c + 2]), minZ, csZ);
                bounds[t * 6] = x0; bounds[t * 6 + 1] = x1; bounds[t * 6 + 2] = y0; bounds[t * 6 + 3] = y1; bounds[t * 6 + 4] = z0; bounds[t * 6 + 5] = z1;
                for (int ix = x0; ix <= x1; ix++)
                    for (int iy = y0; iy <= y1; iy++)
                        for (int iz = z0; iz <= z1; iz++) cellOffsets[(ix * n + iy) * n + iz + 1]++;
            }
            for (int c = 0; c < cellCount; c++) cellOffsets[c + 1] += cellOffsets[c];
            var cursor = new uint[cellCount];
            var cellTris = new uint[cellOffsets[cellCount]];
            for (int t = 0; t < triCount; t++)
                for (int ix = bounds[t * 6]; ix <= bounds[t * 6 + 1]; ix++)
                    for (int iy = bounds[t * 6 + 2]; iy <= bounds[t * 6 + 3]; iy++)
                        for (int iz = bounds[t * 6 + 4]; iz <= bounds[t * 6 + 5]; iz++)
                        {
                            int cell = (ix * n + iy) * n + iz;
                            cellTris[cellOffsets[cell] + cursor[cell]] = (uint)t;
                            cursor[cell]++;
                        }
            return new TriangleGrid { N = n, MinX = minX, MinY = minY, MinZ = minZ, MaxX = maxX, MaxY = maxY, MaxZ = maxZ, CsX = csX, CsY = csY, CsZ = csZ, CellOffsets = cellOffsets, CellTris = cellTris };
        }

        static double Min3(double a, double b, double c) => Math.Min(a, Math.Min(b, c));
        static double Max3(double a, double b, double c) => Math.Max(a, Math.Max(b, c));
        /// <summary>JavaScript's Math.round (halves round up).</summary>
        public static double JsRound(double v) => Math.Floor(v + 0.5);
        static double Clamp(double v, double lo, double hi) => Math.Max(lo, Math.Min(hi, v));

        // meanFunnel: the funnel's mean over the mesh for a press at p (the whole-body puff)
        double MeanFunnel(double px, double py, double pz)
        {
            double radius = DentRadiusC, tip = DentTipC, tip2 = tip * tip;
            double reach = tip + radius * Math.Log(1 / FallEps), reach2 = reach * reach;
            var b = Geo.BasePos;
            int n = Geo.VertCount, stride = SampleStride;
            double sum = 0;
            int count = 0;
            for (int i = 0; i < n; i += stride)
            {
                double dx = b[i * 3] - px, dy = b[i * 3 + 1] - py, dz = b[i * 3 + 2] - pz;
                double d2 = dx * dx + dy * dy + dz * dz;
                if (d2 < reach2) sum += Math.Exp(-(Math.Sqrt(d2 + tip2) - tip) / radius);
                count++;
            }
            return count > 0 ? sum / count : 0;
        }

        // computeDentFall: the press point moved
        void ComputeDentFall(V3 p)
        {
            double px = p.X, py = p.Y, pz = p.Z;
            Press current = null;
            for (int j = 0; j < Presses.Count; j++) if (Presses[j].Driven) current = Presses[j];
            if (current != null)
            {
                double dx = current.X - px, dy = current.Y - py, dz = current.Z - pz;
                if (dx * dx + dy * dy + dz * dz < PressMoveEps * PressMoveEps)
                {
                    current.X = px; current.Y = py; current.Z = pz;
                    current.MeanF = MeanFunnel(px, py, pz);
                }
                else
                {
                    current.Driven = false;
                    current = null;
                }
            }
            if (current == null)
            {
                if (Presses.Count >= MaxPresses)
                {
                    // full (a long fast drag): fold the faintest old press into its nearest neighbour
                    int weakest = 0;
                    for (int j = 1; j < Presses.Count; j++)
                        if (Math.Abs(Presses[j].Amp) + Math.Abs(Presses[j].Vel) < Math.Abs(Presses[weakest].Amp) + Math.Abs(Presses[weakest].Vel)) weakest = j;
                    var w = Presses[weakest];
                    int nearest = -1;
                    double nearestD = double.PositiveInfinity;
                    for (int j = 0; j < Presses.Count; j++)
                    {
                        if (j == weakest) continue;
                        double d = Math.Pow(Presses[j].X - w.X, 2) + Math.Pow(Presses[j].Y - w.Y, 2) + Math.Pow(Presses[j].Z - w.Z, 2);
                        if (d < nearestD) { nearestD = d; nearest = j; }
                    }
                    if (nearest >= 0) { Presses[nearest].Amp += w.Amp; Presses[nearest].Vel += w.Vel; }
                    Presses.RemoveAt(weakest);
                }
                Presses.Add(new Press { X = px, Y = py, Z = pz, MeanF = MeanFunnel(px, py, pz), Driven = true });
            }
            // push direction: from the touch point straight in toward the body's centre
            double len = Hypot(px, py, pz);
            if (len > 1e-6) PressDir = new V3(-px / len, -py / len, -pz / len);
        }

        /// <summary>Math.hypot for three numbers (V8: scaled by the largest, then sqrt of the sum of squares).</summary>
        public static double Hypot(double a, double b, double c)
        {
            a = Math.Abs(a); b = Math.Abs(b); c = Math.Abs(c);
            double max = Math.Max(a, Math.Max(b, c));
            if (double.IsInfinity(max)) return double.PositiveInfinity;
            if (max == 0) max = 1;
            // V8's Math.hypot: Kahan summation of (x / max)^2
            double sum = 0, compensation = 0;
            foreach (var x in new[] { a, b, c })
            {
                double r = x / max, summand = r * r - compensation, preliminary = sum + summand;
                compensation = (preliminary - sum) - summand;
                sum = preliminary;
            }
            return Math.Sqrt(sum) * max;
        }

        // applyDentScale: a press goes straight to 60 % of the full depth, then sinks the rest over about a second
        void ApplyDentScale(double holdSeconds)
        {
            double tipDepth = DentDepthC * DentUserScale * (0.6 + 0.4 * (1 - Math.Exp(-holdSeconds * 1.5)));
            for (int j = 0; j < Presses.Count; j++) Presses[j].Target = Presses[j].Driven ? tipDepth : 0;
            DentTargetActive = true;
            AtRest = false;
        }

        void ResetDentTargets()
        {
            for (int j = 0; j < Presses.Count; j++) { Presses[j].Driven = false; Presses[j].Target = 0; }
            DentTargetActive = false;
        }

        // triHit: Möller–Trumbore, FrontSide culled (three's Ray.intersectTriangle on the flat arrays)
        static double TriHit(float[] pos, int[] index, int t, double ox, double oy, double oz, double dx, double dy, double dz)
        {
            int a = index[t * 3] * 3, b = index[t * 3 + 1] * 3, c = index[t * 3 + 2] * 3;
            double ax = pos[a], ay = pos[a + 1], az = pos[a + 2];
            double e1x = pos[b] - ax, e1y = pos[b + 1] - ay, e1z = pos[b + 2] - az;
            double e2x = pos[c] - ax, e2y = pos[c + 1] - ay, e2z = pos[c + 2] - az;
            double nx = e1y * e2z - e1z * e2y, ny = e1z * e2x - e1x * e2z, nz = e1x * e2y - e1y * e2x;
            double DdN = dx * nx + dy * ny + dz * nz;
            if (DdN >= 0) return double.PositiveInfinity;
            DdN = -DdN;
            double qx = ox - ax, qy = oy - ay, qz = oz - az;
            double DdQxE2 = -(dx * (qy * e2z - qz * e2y) + dy * (qz * e2x - qx * e2z) + dz * (qx * e2y - qy * e2x));
            if (DdQxE2 < 0) return double.PositiveInfinity;
            double DdE1xQ = -(dx * (e1y * qz - e1z * qy) + dy * (e1z * qx - e1x * qz) + dz * (e1x * qy - e1y * qx));
            if (DdE1xQ < 0) return double.PositiveInfinity;
            if (DdQxE2 + DdE1xQ > DdN) return double.PositiveInfinity;
            double QdN = qx * nx + qy * ny + qz * nz;
            if (QdN < 0) return double.PositiveInfinity;
            return QdN / DdN;
        }

        // raycastGrid: the nearest front-facing hit along a ray (mesh-local) through the triangle grid (Amanatides–Woo)
        double RaycastGrid(double ox, double oy, double oz, double dx, double dy, double dz)
        {
            var g = Grid;
            int n = g.N;
            double tEnter = 0, tExit = double.PositiveInfinity;
            if (dx != 0)
            {
                double t1 = (g.MinX - ox) / dx, t2 = (g.MaxX - ox) / dx;
                if (t1 > t2) { double tmp = t1; t1 = t2; t2 = tmp; }
                if (t1 > tEnter) tEnter = t1;
                if (t2 < tExit) tExit = t2;
            }
            else if (ox < g.MinX || ox > g.MaxX) return double.PositiveInfinity;
            if (dy != 0)
            {
                double t1 = (g.MinY - oy) / dy, t2 = (g.MaxY - oy) / dy;
                if (t1 > t2) { double tmp = t1; t1 = t2; t2 = tmp; }
                if (t1 > tEnter) tEnter = t1;
                if (t2 < tExit) tExit = t2;
            }
            else if (oy < g.MinY || oy > g.MaxY) return double.PositiveInfinity;
            if (dz != 0)
            {
                double t1 = (g.MinZ - oz) / dz, t2 = (g.MaxZ - oz) / dz;
                if (t1 > t2) { double tmp = t1; t1 = t2; t2 = tmp; }
                if (t1 > tEnter) tEnter = t1;
                if (t2 < tExit) tExit = t2;
            }
            else if (oz < g.MinZ || oz > g.MaxZ) return double.PositiveInfinity;
            if (tEnter > tExit) return double.PositiveInfinity;

            double px = ox + dx * tEnter, py = oy + dy * tEnter, pz = oz + dz * tEnter;
            int ix = (int)Math.Max(0, Math.Min(n - 1, Math.Floor((px - g.MinX) / g.CsX)));
            int iy = (int)Math.Max(0, Math.Min(n - 1, Math.Floor((py - g.MinY) / g.CsY)));
            int iz = (int)Math.Max(0, Math.Min(n - 1, Math.Floor((pz - g.MinZ) / g.CsZ)));
            int stepX = dx > 0 ? 1 : -1, stepY = dy > 0 ? 1 : -1, stepZ = dz > 0 ? 1 : -1;
            double adx = Math.Abs(dx), ady = Math.Abs(dy), adz = Math.Abs(dz);
            double tDeltaX = adx > 0 ? g.CsX / adx : double.PositiveInfinity;
            double tDeltaY = ady > 0 ? g.CsY / ady : double.PositiveInfinity;
            double tDeltaZ = adz > 0 ? g.CsZ / adz : double.PositiveInfinity;
            double tMaxX = adx > 0 ? tEnter + (dx > 0 ? g.MinX + (ix + 1) * g.CsX - px : px - (g.MinX + ix * g.CsX)) / adx : double.PositiveInfinity;
            double tMaxY = ady > 0 ? tEnter + (dy > 0 ? g.MinY + (iy + 1) * g.CsY - py : py - (g.MinY + iy * g.CsY)) / ady : double.PositiveInfinity;
            double tMaxZ = adz > 0 ? tEnter + (dz > 0 ? g.MinZ + (iz + 1) * g.CsZ - pz : pz - (g.MinZ + iz * g.CsZ)) / adz : double.PositiveInfinity;

            var pos = Geo.BasePos;
            var index = Geo.Index;
            if (_rayStamp == null) _rayStamp = new int[index.Length / 3];
            uint stamp = ++_rayStampCounter;
            double bestT = double.PositiveInfinity;
            for (int guard = 3 * n + 3; guard > 0; guard--)
            {
                int cell = (ix * n + iy) * n + iz;
                for (uint k = g.CellOffsets[cell], k1 = g.CellOffsets[cell + 1]; k < k1; k++)
                {
                    int tri = (int)g.CellTris[k];
                    if (_rayStamp[tri] == (int)stamp) continue;
                    _rayStamp[tri] = (int)stamp;
                    double h = TriHit(pos, index, tri, ox, oy, oz, dx, dy, dz);
                    if (h < bestT) bestT = h;
                }
                int axis;
                double tNext;
                if (tMaxX < tMaxY)
                {
                    if (tMaxX < tMaxZ) { axis = 0; tNext = tMaxX; } else { axis = 2; tNext = tMaxZ; }
                }
                else if (tMaxY < tMaxZ) { axis = 1; tNext = tMaxY; }
                else { axis = 2; tNext = tMaxZ; }
                if (bestT <= tNext || tNext > tExit) break;
                if (axis == 0) { ix += stepX; if (ix < 0 || ix >= n) break; tMaxX += tDeltaX; }
                else if (axis == 1) { iy += stepY; if (iy < 0 || iy >= n) break; tMaxY += tDeltaY; }
                else { iz += stepZ; if (iz < 0 || iz >= n) break; tMaxZ += tDeltaZ; }
            }
            return bestT;
        }

        // raycastLocal: the nearest front-facing hit on the REST surface, in the mesh's local space
        V3? RaycastLocal(double ndcX, double ndcY)
        {
            Camera.Ray(ndcX, ndcY, out var o, out var d);
            StageCamera.RayApply(ref o, ref d, M4.Invert(MatrixWorld));
            double ox = o.X, oy = o.Y, oz = o.Z, dx = d.X, dy = d.Y, dz = d.Z;
            double tc = -(ox * dx + oy * dy + oz * dz);
            double cx = ox + dx * tc, cy = oy + dy * tc, cz = oz + dz * tc;
            if (cx * cx + cy * cy + cz * cz > BoundRadius * BoundRadius) return null;
            double bestT = RaycastGrid(ox, oy, oz, dx, dy, dz);
            if (double.IsPositiveInfinity(bestT)) return null;
            return new V3(ox + dx * bestT, oy + dy * bestT, oz + dz * bestT);
        }

        // pickContactLocal: a triangle hit, else the nearest front-facing base vertex on screen
        public V3? PickContactLocal(double ndcX, double ndcY)
        {
            var hit = RaycastLocal(ndcX, ndcY);
            if (hit.HasValue) return hit;
            var m = MatrixWorld;
            var v = Camera.MatrixWorldInverse;
            var p = Camera.Projection;
            var bp = Geo.BasePos;
            int n = Geo.VertCount, stride = n > 3000 ? 2 : 1;
            if (_pickScratch == null) _pickScratch = new double[n * 2];
            var scratch = _pickScratch;
            double minCam = double.PositiveInfinity, maxCam = double.NegativeInfinity;
            double camX = StageCamera.Position.X, camY = StageCamera.Position.Y, camZ = StageCamera.Position.Z;
            for (int i = 0; i < n; i += stride)
            {
                double x = bp[i * 3], y = bp[i * 3 + 1], z = bp[i * 3 + 2];
                double w = 1 / (m[3] * x + m[7] * y + m[11] * z + m[15]);
                double wx = (m[0] * x + m[4] * y + m[8] * z + m[12]) * w;
                double wy = (m[1] * x + m[5] * y + m[9] * z + m[13]) * w;
                double wz = (m[2] * x + m[6] * y + m[10] * z + m[14]) * w;
                double ex = wx - camX, ey = wy - camY, ez = wz - camZ;
                double cd = ex * ex + ey * ey + ez * ez;
                if (cd < minCam) minCam = cd;
                if (cd > maxCam) maxCam = cd;
                w = 1 / (v[3] * wx + v[7] * wy + v[11] * wz + v[15]);
                double vx = (v[0] * wx + v[4] * wy + v[8] * wz + v[12]) * w;
                double vy = (v[1] * wx + v[5] * wy + v[9] * wz + v[13]) * w;
                double vz = (v[2] * wx + v[6] * wy + v[10] * wz + v[14]) * w;
                w = 1 / (p[3] * vx + p[7] * vy + p[11] * vz + p[15]);
                double sx = (p[0] * vx + p[4] * vy + p[8] * vz + p[12]) * w;
                double sy = (p[1] * vx + p[5] * vy + p[9] * vz + p[13]) * w;
                double qx = sx - ndcX, qy = sy - ndcY;
                scratch[i * 2] = cd;
                scratch[i * 2 + 1] = qx * qx + qy * qy;
            }
            double midCam = (minCam + maxCam) / 2;
            int best = -1, bestAny = -1;
            double bestScreen = double.PositiveInfinity, bestAnyScreen = double.PositiveInfinity;
            for (int i = 0; i < n; i += stride)
            {
                double cd = scratch[i * 2], sd = scratch[i * 2 + 1];
                if (sd < bestAnyScreen) { bestAnyScreen = sd; bestAny = i; }
                if (cd <= midCam && sd < bestScreen) { bestScreen = sd; best = i; }
            }
            int pick = best >= 0 ? best : bestAny;
            if (pick < 0) return null;
            return new V3(bp[pick * 3], bp[pick * 3 + 1], bp[pick * 3 + 2]);
        }

        // applyPendingMove: the drag's pick + dent reshape, at most once per frame
        void ApplyPendingMove()
        {
            if (!PendingMove.HasValue) return;
            var move = PendingMove.Value;
            PendingMove = null;
            if (Mode != PokeMode.Poke) return;
            var local = PickContactLocal(move.X, move.Y) ?? DragStartWorld;
            if (!local.HasValue) return;
            if (!PressLocalSmoothed.HasValue) PressLocalSmoothed = local.Value;
            PressLocalSmoothed = PressLocalSmoothed.Value.Lerp(local.Value, 0.7);
            DragStartWorld = local;
            ComputeDentFall(PressLocalSmoothed.Value);
        }

        void SettleToRest()
        {
            Presses.Clear();
            Lift = 1;
            AtRest = true;
        }

        // uploadSquish: the live press points into the shader's uniforms
        void UploadSquish()
        {
            for (int j = 0; j < Presses.Count; j++)
            {
                var pr = Presses[j];
                PressUniform[j * 4] = (float)pr.X;
                PressUniform[j * 4 + 1] = (float)pr.Y;
                PressUniform[j * 4 + 2] = (float)pr.Z;
                PressUniform[j * 4 + 3] = (float)pr.Amp;
            }
            UniformCount = Presses.Count;
            double sign = DentSign, invLift = 1 / Lift;
            UniformDir[0] = (float)(PressDir.X * sign * invLift);
            UniformDir[1] = (float)(PressDir.Y * sign * invLift);
            UniformDir[2] = (float)(PressDir.Z * sign * invLift);
            UniformDent[0] = (float)DentRadiusC; UniformDent[1] = (float)DentTipC; UniformDent[2] = (float)(DentDepthC * DentUserScale * 1.5); UniformDent[3] = 0;
            Uploaded = true;
        }

        /// <summary>One frame (useFrame): applyPendingMove, then tickPhysics(clamp(delta, 0, 0.05)); `now` is Date.now()
        /// (the card's move cycle). Then MatrixWorld is what the frame draws with.</summary>
        public void Tick(double delta, double now)
        {
            ApplyPendingMove();
            TickPhysics(Clamp(delta, 0, 0.05), now);
            UpdateMatrix();
        }

        public void UpdateMatrix() => MatrixWorld = M4.Compose(Position, Quat.FromEulerXYZ(RotX, RotY, RotZ), Scale);

        void TickPhysics(double dt, double now)
        {
            double k = dt * 60;
            IdlePhase += 0.016 * k;
            if (Mode == PokeMode.Poke && PressLocalSmoothed.HasValue)
            {
                PressHoldTime += dt;
                ApplyDentScale(PressHoldTime);
            }
            double dentStiff = 1 - Math.Pow(1 - PhysStiff, k);
            double dentDamp = Math.Pow(PhysDamp, k);
            double meanDent = 0;
            if (!AtRest)
            {
                double motion = 0;
                for (int j = Presses.Count - 1; j >= 0; j--)
                {
                    var pr = Presses[j];
                    pr.Vel += (pr.Target - pr.Amp) * dentStiff;
                    pr.Vel *= dentDamp;
                    pr.Amp += pr.Vel;
                    double aa = Math.Abs(pr.Amp), av = Math.Abs(pr.Vel);
                    if (!pr.Driven && aa < RestEps && av < RestEps)
                    {
                        Presses.RemoveAt(j);
                        continue;
                    }
                    if (aa > motion) motion = aa;
                    if (av > motion) motion = av;
                    meanDent += pr.Amp * pr.MeanF;
                }
                Lift = Math.Min(1 + DentSign * meanDent * 0.2, MaxBulge);
                if (!DentTargetActive && (Presses.Count == 0 || motion < RestEps))
                {
                    SettleToRest();
                    meanDent = 0;
                }
                UploadSquish();
            }

            double squashStiff = 1 - Math.Pow(1 - (SqSt != 0 ? SqSt : 0.4), k);
            double squashDamp = Math.Pow(SqDp != 0 ? SqDp : 0.72, k);
            GlobalSquashV += (GlobalSquashTarget - GlobalSquash) * squashStiff;
            GlobalSquashV *= squashDamp;
            GlobalSquash += GlobalSquashV;

            double wobbleStiff = 1 - Math.Pow(1 - 0.08, k), wobbleDamp = Math.Pow(0.87, k);
            WobbleRotXV += (0 - WobbleRotX) * wobbleStiff;
            WobbleRotXV *= wobbleDamp;
            WobbleRotX += WobbleRotXV;
            WobbleRotZV += (0 - WobbleRotZ) * wobbleStiff;
            WobbleRotZV *= wobbleDamp;
            WobbleRotZ += WobbleRotZV;

            if (Mode != PokeMode.Orbit)
            {
                double orbitDecay = Math.Pow(0.93, k);
                OrbitVelY *= orbitDecay;
                OrbitVelX *= orbitDecay;
                OrbitTargetY += OrbitVelY * k;
                OrbitTargetX += OrbitVelX * k;
            }
            if (Card) SquishCard.Sway(this);
            double orbitCatchup = Math.Min(1, 0.22 * k);
            UserRotY += (OrbitTargetY - UserRotY) * orbitCatchup;
            UserRotX += (OrbitTargetX - UserRotX) * orbitCatchup;

            double breathe = 1 + Math.Sin(IdlePhase * 0.45) * 0.012;
            double lift = Lift;
            double sqX = SqX != 0 ? SqX : 0.14, sqY = SqY != 0 ? SqY : 0.26;
            double sx = (1 + GlobalSquash * sqX) * breathe * lift;
            double sy = (1 - GlobalSquash * sqY) * breathe * lift;
            double sz = (1 + GlobalSquash * sqX) * breathe * lift;
            RotY = UserRotY;
            RotX = UserRotX + WobbleRotX;
            RotZ = WobbleRotZ;
            Scale = new V3(sx, sy, sz);
            if (Card) SquishCard.Motion(this, k, sx, sy, sz, now);
        }

        // --- the imperative handle (SquishScreen's PanResponder calls these) -------------------------------------------
        public void PointerDown(double ndcX, double ndcY)
        {
            var local = PickContactLocal(ndcX, ndcY);
            if (!local.HasValue) return;
            Mode = PokeMode.Poke;
            DragStartWorld = local;
            PressLocalSmoothed = local;
            PressHoldTime = 0;
            PendingMove = null;
            ComputeDentFall(local.Value);
            ApplyDentScale(0);
            GlobalSquashTarget = 0.55 * DentSign;
            OnSquish?.Invoke();
        }

        public void PointerMove(double ndcX, double ndcY)
        {
            if (Mode != PokeMode.Poke) return;
            PendingMove = new V3(ndcX, ndcY, 0);
        }

        public void Orbit(double dxScreen, double dyScreen)
        {
            Mode = PokeMode.Orbit;
            OrbitTargetY += dxScreen * 0.01;
            OrbitTargetX += dyScreen * 0.006;
            OrbitVelY = OrbitVelY * 0.5 + dxScreen * 0.002;
            OrbitVelX = OrbitVelX * 0.5 + dyScreen * 0.0012;
        }

        public void EndOrbit()
        {
            if (Mode == PokeMode.Orbit) Mode = PokeMode.None;
        }

        public void CancelPoke()
        {
            ResetDentTargets();
            GlobalSquashTarget = 0;
            PressLocalSmoothed = null;
            PressHoldTime = 0;
            PendingMove = null;
            if (Mode == PokeMode.Poke) Mode = PokeMode.None;
        }

        /// <summary>pointerUp: (wasPoke, holdSeconds). `now` is Date.now() (the card's happy reaction).</summary>
        public (bool wasPoke, double holdSeconds) PointerUp(double now)
        {
            if (Mode != PokeMode.Poke)
            {
                Mode = PokeMode.None;
                return (false, 0);
            }
            double holdSeconds = PressHoldTime;
            ResetDentTargets();
            GlobalSquashTarget = 0;
            double kick = WobbleKick;
            WobbleRotXV += Clamp((Random() - 0.5) * kick, -kick, kick);
            WobbleRotZV += Clamp((Random() - 0.5) * kick, -kick, kick);
            PressLocalSmoothed = null;
            PressHoldTime = 0;
            PendingMove = null;
            Mode = PokeMode.None;
            if (Card) ReactT = now;
            OnRelease?.Invoke(holdSeconds);
            return (true, holdSeconds);
        }

        /// <summary>The player's poke settings: depth multiplier (POKE_STRENGTH_SCALES), push in / pop out.</summary>
        public void SetPoke(double dentScale, bool outward)
        {
            DentUserScale = dentScale;
            DentSign = outward ? -1 : 1;
        }
    }
}
