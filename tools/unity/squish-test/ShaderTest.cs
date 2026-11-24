// The dent: the port's SquishShaderMath (what SquishCard.shader computes, line by line) against the app's GLSL run
// on the GPU (shader.mjs), over the card's vertices for many random press sets; and the port's card geometry
// (SquishCard.Geometry: positions, uvs, index, three's computeVertexNormals) against the app's cardGeometryData.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SquishSquad.Backend;
using SquishSquad.Games.Squish;

static class ShaderTest
{
    static float[] F(object o) => ((IList<object>)o).Select(v => (float)(double)v).ToArray();

    public static int Run(string dir)
    {
        var r = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Path.Combine(dir, "shader.json")));
        var geo = SquishCard.Geometry();
        float[] bp = F(r["basePos"]), bn = F(r["baseNormals"]), uv = F(r["uv"]);
        var index = ((IList<object>)r["index"]).Select(v => (int)(double)v).ToArray();
        double gp = Max(bp, geo.BasePos), gn = Max(bn, geo.BaseNormals), gu = Max(uv, geo.Uv);
        bool gi = index.SequenceEqual(geo.Index);
        Console.WriteLine($"geometry: {geo.VertCount} vertices; positions max |diff| {gp:G3}, normals {gn:G3}, uvs {gu:G3}, index {(gi ? "identical" : "DIFFERENT")}");
        var cases = (IList<object>)r["cases"];
        var outs = (IList<object>)r["outs"];
        double worstP = 0, worstN = 0, sumP = 0, sumN = 0, maxDisp = 0;
        long n = 0;
        int worstCase = -1;
        for (int k = 0; k < cases.Count; k++)
        {
            var c = (IDictionary<string, object>)cases[k];
            float[] press = F(c["press"]), dirv = F(c["dir"]), dent = F(c["dent"]);
            int count = (int)(double)c["count"];
            var o = F(outs[k]);
            for (int i = 0; i < geo.VertCount; i++)
            {
                SquishShaderMath.Displace(bp, bn, i, press, count, dirv, dent, out var tx, out var ty, out var tz, out var nx, out var ny, out var nz);
                double dp = Math.Max(Math.Abs(tx - o[i * 6]), Math.Max(Math.Abs(ty - o[i * 6 + 1]), Math.Abs(tz - o[i * 6 + 2])));
                double dn = Math.Max(Math.Abs(nx - o[i * 6 + 3]), Math.Max(Math.Abs(ny - o[i * 6 + 4]), Math.Abs(nz - o[i * 6 + 5])));
                double disp = Math.Sqrt(Math.Pow(o[i * 6] - bp[i * 3], 2) + Math.Pow(o[i * 6 + 1] - bp[i * 3 + 1], 2) + Math.Pow(o[i * 6 + 2] - bp[i * 3 + 2], 2));
                if (disp > maxDisp) maxDisp = disp;
                if (dp > worstP) { worstP = dp; worstCase = k; }
                if (dn > worstN) worstN = dn;
                sumP += dp; sumN += dn; n++;
            }
        }
        Console.WriteLine($"dent: {cases.Count} press sets x {geo.VertCount} vertices = {n} displaced vertices (displacements up to {maxDisp:F3} units), GPU ({r["renderer"]}) vs C#:");
        Console.WriteLine($"  position max |diff| {worstP:G3} (case {worstCase}), mean {sumP / n:G3}");
        Console.WriteLine($"  normal   max |diff| {worstN:G3}, mean {sumN / n:G3}");
        bool ok = gp == 0 && gn < 1e-6 && gu == 0 && gi && worstP < 1e-5 && worstN < 1e-4;
        Console.WriteLine(ok ? "OK: float32 rounding only" : "MISMATCH");
        return ok ? 0 : 1;
    }

    static double Max(float[] a, float[] b)
    {
        if (a.Length != b.Length) return double.PositiveInfinity;
        double m = 0;
        for (int i = 0; i < a.Length; i++) m = Math.Max(m, Math.Abs(a[i] - b[i]));
        return m;
    }
}
