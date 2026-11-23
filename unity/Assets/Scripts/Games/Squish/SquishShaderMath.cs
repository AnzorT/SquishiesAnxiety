// The squish vertex shader (SquishyToy.js SQUISH_VERTEX_GLSL + SQUISH_NORMAL_GLSL + SQUISH_POSITION_GLSL, as three
// splices them into MeshStandardMaterial's vertex shader) in C#, in 32-bit floats like the GPU, line for line. It is
// what Resources/SquishShaders/SquishCard.shader runs on the GPU; this copy is for the checks in
// tools/unity/squish-test (against the GLSL itself, run by WebGL) and the CPU reference picture.
using System;

namespace SquishSquad.Games.Squish
{
    public static class SquishShaderMath
    {
        /// <summary>squishDepth(p) and its gradient (squishGrad), from the uniforms uSquishPress[count], uSquishDent.</summary>
        public static float Depth(float px, float py, float pz, float[] press, int count, float[] dent, out float gx, out float gy, out float gz)
        {
            float depth = 0f;
            gx = 0f; gy = 0f; gz = 0f;
            float tip = dent[1];
            float invRadius = 1.0f / dent[0];
            for (int j = 0; j < SquishToy.MaxPresses; j++)
            {
                if (j >= count) break;
                float qx = px - press[j * 4], qy = py - press[j * 4 + 1], qz = pz - press[j * 4 + 2];
                float rt = (float)Math.Sqrt(qx * qx + qy * qy + qz * qz + tip * tip);
                float f = (float)Math.Exp(-(rt - tip) * invRadius) * press[j * 4 + 3];
                depth += f;
                float k = f * invRadius / rt;
                gx -= qx * k; gy -= qy * k; gz -= qz * k;
            }
            return depth;
        }

        /// <summary>The displaced vertex and its normal in object space: objectNormal (beginnormal_vertex + the squish's
        /// Sherman–Morrison tilt) and transformed (begin_vertex + the push along uSquishDir).</summary>
        public static void Displace(float[] pos, float[] nrm, int i, float[] press, int count, float[] dir, float[] dent,
            out float tx, out float ty, out float tz, out float nx, out float ny, out float nz)
        {
            float px = pos[i * 3], py = pos[i * 3 + 1], pz = pos[i * 3 + 2];
            nx = nrm[i * 3]; ny = nrm[i * 3 + 1]; nz = nrm[i * 3 + 2];
            float squishD = Depth(px, py, pz, press, count, dent, out var gx, out var gy, out var gz);
            {
                float dn = dir[0] * nx + dir[1] * ny + dir[2] * nz;
                float den = Math.Max(1.0f + (dir[0] * gx + dir[1] * gy + dir[2] * gz), 0.15f);
                float k = dn / den;
                float ox = nx - gx * k, oy = ny - gy * k, oz = nz - gz * k;
                float l = (float)Math.Sqrt(ox * ox + oy * oy + oz * oz);
                nx = ox / l; ny = oy / l; nz = oz / l;
            }
            float m = Math.Min(squishD, dent[2]);
            tx = px + dir[0] * m; ty = py + dir[1] * m; tz = pz + dir[2] * m;
        }
    }
}
