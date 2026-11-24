// The squish game's creature: the design's "card" (src/components/squishCard.js), ported line by line. A 2.5-unit
// plane, 40 x 40 segments, domed a little toward the viewer, with the creature's front art; a mirrored copy (the
// plane turned half round) carries its back art; one mesh over one atlas (front left, back right). On top of the
// squish it moves like the design's: every 3 s it steps through idle, dance, idle, happy, idle, clean, idle, spin with
// the creature's own move curves (src/squad/cardMoves.js, exported to Resources/Squish/squish.json); it reacts with
// `happy` for 1.6 s after a squish; it sways while nobody touches it; its squash springs are its own; its growth stage
// scales it (STAGE_FX: Baby smaller and rounder), with a crown and a gold glow at Best Friend.
using System;
using System.Collections.Generic;

namespace SquishSquad.Games.Squish
{
    public sealed class CardGeometry
    {
        public float[] BasePos, BaseNormals, Uv;
        public int[] Index;
        public int VertCount;
    }

    /// <summary>A move channel: [base, amp, period ms, phase, shape, extra].</summary>
    public sealed class Wave
    {
        public double B, A, P, Ph;
        public string Sh = "sin";
        public double ExStart, ExEnd, ExWin, ExSub;
    }

    /// <summary>One creature's card data (cardMoves.js): head (% from the top, for the crown), moves (idle / happy /
    /// dance: channel -> wave), squish springs.</summary>
    public sealed class CardData
    {
        public double Head = 20;
        public Dictionary<string, Dictionary<string, Wave>> Moves;   // null: none
        public double? K, Z, X, Y, R;                                // sq (each may be missing)
    }

    public static class SquishCard
    {
        public const double CardW = 2.5;
        const int Seg = 40;
        const double Dome = 0.07;
        const double Deg = Math.PI / 180;
        // CARD_TUNING: the dent for a flat card (shallower than a 3D body's)
        public const double Visual = CardW, DentDepth = 0.36, DentRadius = 0.3, DentTip = 0.05;

        /// <summary>STAGE_FX (src/squad/data.js): sx, sy, crown by growth stage (0 Baby, 1, 2 Best Friend).</summary>
        public static readonly (double sx, double sy, bool crown)[] StageFx = { (0.8, 0.72, false), (1, 1, false), (1.04, 1.04, true) };

        // cardGeometryData()
        public static CardGeometry Geometry()
        {
            const int n = Seg + 1;
            const double half = CardW / 2;
            int vertCount = n * n * 2;
            var pos = new float[vertCount * 3];
            var uv = new float[vertCount * 2];
            for (int r = 0; r <= Seg; r++)
                for (int c = 0; c <= Seg; c++)
                {
                    double x = -half + ((double)c / Seg) * CardW;
                    double y = half - ((double)r / Seg) * CardW;
                    double nx = x / half, ny = y / half;
                    double z = Dome * Math.Max(0, 1 - (nx * nx + ny * ny) * 0.5);
                    int i = r * n + c, j = n * n + i;
                    pos[i * 3] = (float)x; pos[i * 3 + 1] = (float)y; pos[i * 3 + 2] = (float)z;
                    pos[j * 3] = (float)-x; pos[j * 3 + 1] = (float)y; pos[j * 3 + 2] = (float)-z;
                    uv[i * 2] = (float)(((double)c / Seg) * 0.5); uv[i * 2 + 1] = (float)(1 - (double)r / Seg);
                    uv[j * 2] = (float)(0.5 + ((double)c / Seg) * 0.5); uv[j * 2 + 1] = (float)(1 - (double)r / Seg);
                }
            var index = new int[Seg * Seg * 6 * 2];
            int k = 0;
            foreach (int off in new[] { 0, n * n })
                for (int r = 0; r < Seg; r++)
                    for (int c = 0; c < Seg; c++)
                    {
                        int a = off + r * n + c, b = a + 1, d = a + n, e = d + 1;
                        index[k++] = a; index[k++] = d; index[k++] = b; index[k++] = d; index[k++] = e; index[k++] = b;
                    }
            return new CardGeometry { BasePos = pos, Uv = uv, Index = index, VertCount = vertCount, BaseNormals = VertexNormals(pos, index, vertCount) };
        }

        // BufferGeometry.computeVertexNormals for an indexed mesh: face normals (cb x ab) summed per vertex in the
        // Float32 attribute, then normalised (normalizeNormals), as three does.
        public static float[] VertexNormals(float[] p, int[] index, int vertCount)
        {
            var nrm = new float[vertCount * 3];
            for (int i = 0; i < index.Length; i += 3)
            {
                int vA = index[i], vB = index[i + 1], vC = index[i + 2];
                double ax = p[vA * 3], ay = p[vA * 3 + 1], az = p[vA * 3 + 2];
                double bx = p[vB * 3], by = p[vB * 3 + 1], bz = p[vB * 3 + 2];
                double cx = p[vC * 3], cy = p[vC * 3 + 1], cz = p[vC * 3 + 2];
                var cb = new V3(cx - bx, cy - by, cz - bz);
                var ab = new V3(ax - bx, ay - by, az - bz);
                var f = V3.Cross(cb, ab);
                foreach (int v in new[] { vA, vB, vC })
                {
                    nrm[v * 3] = (float)(nrm[v * 3] + f.X);
                    nrm[v * 3 + 1] = (float)(nrm[v * 3 + 1] + f.Y);
                    nrm[v * 3 + 2] = (float)(nrm[v * 3 + 2] + f.Z);
                }
            }
            for (int v = 0; v < vertCount; v++)
            {
                var q = new V3(nrm[v * 3], nrm[v * 3 + 1], nrm[v * 3 + 2]).Normalized();
                nrm[v * 3] = (float)q.X; nrm[v * 3 + 1] = (float)q.Y; nrm[v * 3 + 2] = (float)q.Z;
            }
            return nrm;
        }

        // --- the creatures' data (Resources/Squish/squish.json "moves", by roster id) ----------------------------------
        public static Dictionary<string, CardData> ParseMoves(IDictionary<string, object> moves)
        {
            var all = new Dictionary<string, CardData>();
            foreach (var kv in moves)
            {
                var m = kv.Value as IDictionary<string, object>;
                var d = new CardData();
                if (m == null) { all[kv.Key] = d; continue; }
                if (m.TryGetValue("head", out var h) && h is double hd) d.Head = hd;
                if (m.TryGetValue("moves", out var mv) && mv is IDictionary<string, object> mm)
                {
                    d.Moves = new Dictionary<string, Dictionary<string, Wave>>();
                    foreach (var move in mm)
                    {
                        var ch = new Dictionary<string, Wave>();
                        if (move.Value is IDictionary<string, object> chans)
                            foreach (var c in chans)
                                if (c.Value is IList<object> arr) ch[c.Key] = ParseWave(arr);
                        d.Moves[move.Key] = ch;
                    }
                }
                if (m.TryGetValue("sq", out var sq) && sq is IDictionary<string, object> s)
                {
                    double? G(string k) => s.TryGetValue(k, out var v) && v is double dv ? dv : (double?)null;
                    d.K = G("k"); d.Z = G("z"); d.X = G("x"); d.Y = G("y"); d.R = G("r");
                }
                all[kv.Key] = d;
            }
            return all;
        }

        static Wave ParseWave(IList<object> a)
        {
            double N(int i, double dflt) => a.Count > i && a[i] is double v ? v : dflt;
            var w = new Wave { B = N(0, 0), A = N(1, 0), P = N(2, 1), Ph = N(3, 0) };
            if (a.Count > 4 && a[4] is string sh) w.Sh = sh;
            if (a.Count > 5 && a[5] is IDictionary<string, object> ex)
            {
                double E(string k) => ex.TryGetValue(k, out var v) && v is double dv ? dv : 0;
                w.ExStart = E("start"); w.ExEnd = E("end"); w.ExWin = E("win"); w.ExSub = E("sub");
            }
            return w;
        }

        // --- the wave shapes (squish-rig.js wave, creatures-v2.js w2) ---------------------------------------------------
        const double Tau = Math.PI * 2;

        // bez(x1, y1, x2, y2)(t): CSS's cubic-bezier, Newton's method as the design does it
        public static double Bez(double x1, double y1, double x2, double y2, double t)
        {
            if (t <= 0) return 0;
            if (t >= 1) return 1;
            double u = t;
            for (int i = 0; i < 8; i++)
            {
                double x = 3 * (1 - u) * (1 - u) * u * x1 + 3 * (1 - u) * u * u * x2 + u * u * u - t;
                double dx = 3 * (1 - u) * (1 - u) * x1 + 6 * (1 - u) * u * (x2 - x1) + 3 * u * u * (1 - x2);
                if (Math.Abs(dx) < 1e-6) break;
                u = Math.Min(1, Math.Max(0, u - x / dx));
            }
            return 3 * (1 - u) * (1 - u) * u * y1 + 3 * (1 - u) * u * u * y2 + u * u * u;
        }
        static double Soft(double t) => Bez(0.45, 0, 0.55, 1, t);

        public static double WaveAt(Wave c, double t)
        {
            double b = c.B, a = c.A, P = c.P;
            double u = t / P + c.Ph;
            string sh = c.Sh;
            if (sh == "sq") return b + (a * Math.Tanh(4 * Math.Sin(Tau * u))) / Math.Tanh(4);
            if (sh == "hop2")
            {
                double x = JsMod(t, P) / P;
                return x < 0.5 ? b + a * Math.Abs(Math.Sin(Tau * x * 2)) : b;
            }
            if (sh == "sin") return b + a * Math.Sin(Tau * u);
            if (sh == "cos") return b + a * Math.Cos(Tau * u);
            if (sh == "hop") return b + a * Math.Abs(Math.Sin(Math.PI * u));
            if (sh == "spin" || sh == "pulse")
            {
                double x = JsMod(t, P) / P;
                if (x < c.ExStart || x > c.ExEnd) return b;
                double v = (x - c.ExStart) / (c.ExEnd - c.ExStart);
                return sh == "spin" ? b + a * Soft(v) : b + a * Math.Sin(Math.PI * v);
            }
            if (sh == "spinsq")
            {
                double x = JsMod(t, P) / P;
                double f = 0;
                if (x < 0.2) f = -Math.Sin((Math.PI * x) / 0.2);
                else if (x < 0.7) f = 0.7 * Math.Sin((Math.PI * (x - 0.2)) / 0.5);
                else if (x < 0.9) f = -1.2 * Math.Sin((Math.PI * (x - 0.7)) / 0.2);
                return b + a * f;
            }
            if (sh == "shake")
            {
                double x = JsMod(t, P) / P;
                return x >= c.ExWin ? b : b + a * Math.Sin((Tau * t) / c.ExSub) * Math.Sin((Math.PI * x) / c.ExWin);
            }
            return b;
        }

        /// <summary>JavaScript's a % b for doubles (fmod: the result has the dividend's sign).</summary>
        public static double JsMod(double a, double b) => a % b;   // (C#'s % on doubles is fmod, as JS's)

        static double Clamp(double v, double lo, double hi) => Math.Max(lo, Math.Min(hi, v));

        // cardState(id, stage, group): the card's own state, merged into the toy's
        public static void InitState(SquishToy s, CardData data, int stage, double seed)
        {
            data = data ?? new CardData();
            var fx = stage >= 0 && stage < StageFx.Length ? StageFx[stage] : StageFx[1];
            s.Card = true;
            s.Moves = data.Moves;
            s.Head = data.Head;
            s.Crown = fx.crown;
            s.Seed = seed;
            s.ReactT = 0;
            s.StK0 = fx.sx; s.StK1 = fx.sy;
            s.StY = -(1 - fx.sy) * CardW * 0.46;
            s.Mv = new Move();
            s.SqSt = Clamp((data.K ?? 500) / 1250, 0.15, 0.75);
            s.SqDp = Clamp(0.92 - (data.Z ?? 0.32) * 0.6, 0.6, 0.9);
            s.SqX = 0.14 * ((data.X ?? 0.2) / 0.2);
            s.SqY = 0.26 * ((data.Y ?? 0.26) / 0.26);
            s.SqR = data.R ?? 0;
        }

        /// <summary>The crown's place in the group (cardState): position and z rotation.</summary>
        public static V3 CrownPosition(double head) => new V3(0.2, ((50 - head) / 100) * CardW + 0.17, 0.12);
        public const double CrownRotZ = -0.22, CrownW = 0.62, CrownH = 0.465, GlowRadius = 1.35, GlowZ = -0.25;

        // cardSway(s): idle sway while untouched (the design's orbit target), before the group's rotation is set
        public static void Sway(SquishToy s)
        {
            if (s.Mode == PokeMode.None) s.OrbitTargetY = Math.Sin(s.IdlePhase * 0.08) * 0.35;
        }

        static readonly string[] Seq = { "idle", "dance", "idle", "happy", "idle", "clean", "idle", "spin" };
        static readonly string[] MoveKeys = { "sx", "sy", "rot", "tx", "ty", "spin" };

        // cardMotion(s, k, sx, sy, sz): after the group's squash / rotation are set, the move cycle on top
        public static void Motion(SquishToy s, double k, double sx, double sy, double sz, double now)
        {
            var M = s.Moves;
            bool react = s.ReactT != 0 && now - s.ReactT < 1600;
            double cyT = now + s.Seed;
            double cyU = JsMod(cyT, 3000) / 3000;
            string cyM = react ? "happy" : Seq[(int)(Math.Floor(cyT / 3000) % Seq.Length)];
            Dictionary<string, Wave> ch = null;
            if (!(M == null || s.Mode == PokeMode.Poke) && cyM != "clean")
            {
                if (cyM == "spin") ch = M.TryGetValue("happy", out var hp) ? hp : M.TryGetValue("idle", out var id0) ? id0 : null;
                else ch = M.TryGetValue(cyM, out var m) ? m : M.TryGetValue("idle", out var id1) ? id1 : null;
            }
            var v = new Move();
            if (ch != null)
            {
                double t = react ? now - s.ReactT : now + s.Seed;
                foreach (var key in ch.Keys)
                    if (key != "spin" && Array.IndexOf(MoveKeys, key) >= 0) v.Set(key, WaveAt(ch[key], t));
            }
            if (!react && s.Mode != PokeMode.Poke && M != null && cyM == "clean")
            {
                v.Rot = 7 * Math.Sin(now / 230);
                v.Ty = -4 * Math.Abs(Math.Sin(now / 230));
                v.Sx = 1 + 0.03 * Math.Sin(now / 115);
            }
            double cySpin = 0;
            if (!react && s.Mode != PokeMode.Poke && cyM == "spin")
            {
                double e = Math.Min(1, cyU / 0.5);
                cySpin = 360 * (e * e * (3 - 2 * e));
                v.Ty = -18 * Math.Sin(Math.PI * Math.Min(1, cyU / 0.5));
            }
            double w = Math.Min(1, 0.18 * k), fast = Math.Min(1, 0.45 * k);
            double f = react || ch == null ? fast : w;
            // (for (const key in v): sx, sy, rot, tx, ty, spin)
            s.Mv.Sx += (v.Sx - s.Mv.Sx) * f;
            s.Mv.Sy += (v.Sy - s.Mv.Sy) * f;
            s.Mv.Rot += (v.Rot - s.Mv.Rot) * f;
            s.Mv.Tx += (v.Tx - s.Mv.Tx) * f;
            s.Mv.Ty += (v.Ty - s.Mv.Ty) * f;
            s.Mv.Spin += (v.Spin - s.Mv.Spin) * f;
            s.Position = new V3(s.Mv.Tx * 0.012, -s.Mv.Ty * 0.012 + s.StY, 0);
            s.GlowOpacity = 0.16 + 0.1 * Math.Sin(now / 420);
            s.RotY += Math.Sin(s.IdlePhase * 0.2) * 0.03 + (s.Mv.Spin + cySpin) * Deg;
            s.RotZ += -(s.Mv.Rot + s.SqR * s.GlobalSquash) * Deg;
            s.Scale = new V3(sx * s.Mv.Sx * s.StK0, sy * s.Mv.Sy * s.StK1, sz * s.Mv.Sx * s.StK0);
        }
    }

    /// <summary>The card's move state (s.mv): sx, sy, rot, tx, ty, spin.</summary>
    public sealed class Move
    {
        public double Sx = 1, Sy = 1, Rot, Tx, Ty, Spin;
        public void Set(string k, double v)
        {
            switch (k)
            {
                case "sx": Sx = v; break;
                case "sy": Sy = v; break;
                case "rot": Rot = v; break;
                case "tx": Tx = v; break;
                case "ty": Ty = v; break;
                case "spin": Spin = v; break;
            }
        }
    }
}
