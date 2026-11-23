// How the squish stage's picture is made, in C# (no Unity): the light set-up of SquishScreen's Canvas, three's
// MeshStandardMaterial fragment for the card (src/components/squishCard.js cardMaterial + CARD_FRAGMENT: the map and
// emissive map decoded from sRGB in the shader, alphaTest 0.5, roughness 0.85, 30 % lit + 70 % self-lit), and
// src/components/Supersample.js (the scene drawn at 2x into an 8-bit sRGB target with every light and the emissive
// divided by HEADROOM = 4, then a quad that averages it down, multiplies by 4, applies Neutral tone mapping and
// encodes sRGB, blended premultiplied over the page).
//
// Resources/SquishShaders/SquishCard.shader and SquishResolve.shader do this on the GPU, line by line; Lights() gives
// them their uniforms. Render() is the CPU reference rasteriser tools/unity/squish-test compares with the app's
// frames (and so with what those shaders compute).
using System;

namespace SquishSquad.Games.Squish
{
    public static class SquishShade
    {
        public const double Headroom = 4;               // Supersample.js HEADROOM
        public const double CardLit = 0.3, CardSelf = 0.7, Roughness = 0.85, AlphaTest = 0.5;   // CARD_LOOK, cardMaterial

        /// <summary>three's Color.setHex: an sRGB hex colour to linear.</summary>
        public static double[] HexLinear(int hex) => new[] { SrgbToLinear(((hex >> 16) & 255) / 255.0), SrgbToLinear(((hex >> 8) & 255) / 255.0), SrgbToLinear((hex & 255) / 255.0) };
        public static double SrgbToLinear(double c) => c < 0.04045 ? c * 0.0773993808 : Math.Pow(c * 0.9478672986 + 0.0521327014, 2.4);
        // ColorManagement's LinearToSRGB (exact; what an 8-bit sRGB target stores)
        public static double LinearToSrgbExact(double c) => c < 0.0031308 ? c * 12.92 : 1.055 * Math.Pow(c, 0.41666) - 0.055;

        /// <summary>The lights' uniforms in view space, with the supersampler's 1/HEADROOM: three directional lights
        /// (direction, colour x intensity), the hemisphere (direction, sky, ground) and the ambient, as three uploads them.</summary>
        public sealed class LightSet
        {
            public double[][] DirDirection = new double[3][], DirColor = new double[3][];
            public double[] HemiDirection, HemiSky, HemiGround, Ambient;
        }

        static double[] Scale(double[] c, double k) => new[] { c[0] * k, c[1] * k, c[2] * k };

        public static LightSet Lights(StageCamera cam, double headroom = Headroom)
        {
            var view = cam.MatrixWorldInverse;
            double[] TransformDirection(V3 d)
            {
                // Vector3.transformDirection(viewMatrix): the upper 3x3, then normalize
                var v = new V3(view[0] * d.X + view[4] * d.Y + view[8] * d.Z, view[1] * d.X + view[5] * d.Y + view[9] * d.Z, view[2] * d.X + view[6] * d.Y + view[10] * d.Z).Normalized();
                return new[] { v.X, v.Y, v.Z };
            }
            double k = 1 / headroom;
            var L = new LightSet();
            // <directionalLight color intensity position />, target at the origin
            (int hex, double intensity, V3 pos)[] dirs = { (0xffffff, 1.2, new V3(2, 3, 3)), (0xd8ccff, 0.3, new V3(-2.5, -1, 2)), (0xffffff, 0.35, new V3(-1.5, 2, -3)) };
            for (int i = 0; i < 3; i++)
            {
                L.DirDirection[i] = TransformDirection(dirs[i].pos);
                L.DirColor[i] = Scale(HexLinear(dirs[i].hex), dirs[i].intensity * k);
            }
            // <hemisphereLight args={[0xffffff, 0x9aa8bc, 3.5]} />: at Object3D.DEFAULT_UP
            L.HemiDirection = TransformDirection(new V3(0, 1, 0));
            L.HemiSky = Scale(HexLinear(0xffffff), 3.5 * k);
            L.HemiGround = Scale(HexLinear(0x9aa8bc), 3.5 * k);
            // <ambientLight intensity={0.6} />
            L.Ambient = Scale(HexLinear(0xffffff), 0.6 * k);
            return L;
        }

        static double Clamp01(double v) => v < 0 ? 0 : v > 1 ? 1 : v;
        static double Pow2(double x) => x * x;

        /// <summary>The card's fragment (three r166 meshphysical.glsl for MeshStandardMaterial, as compiled for it):
        /// `tex` the map's raw sample (0..1, the shader decodes it), n the normalised view-space normal, v the
        /// normalised view direction, geometryRoughness from the normal's screen derivatives. Linear rgb out, or null
        /// when alphaTest discards it.</summary>
        public static double[] Fragment(double[] tex, double[] n, double[] v, double geometryRoughness, LightSet L, double headroom = Headroom)
        {
            double a = tex[3];
            if (a < AlphaTest) return null;
            var dec = new double[3];
            // CARD_FRAGMENT's inline decode: mix(pow(c * 0.9478672986 + 0.0521327014, 2.4), c * 0.0773993808, c <= 0.04045)
            for (int i = 0; i < 3; i++) dec[i] = tex[i] <= 0.04045 ? tex[i] * 0.0773993808 : Math.Pow(tex[i] * 0.9478672986 + 0.0521327014, 2.4);
            double[] diffuse = { CardLit * dec[0], CardLit * dec[1], CardLit * dec[2] };
            double emK = CardSelf / headroom;
            double[] emissive = { emK * dec[0], emK * dec[1], emK * dec[2] };
            double roughness = Math.Min(Math.Max(Roughness, 0.0525) + geometryRoughness, 1.0);
            const double f0 = 0.04, f90 = 1.0;
            double alpha = Pow2(roughness);
            double[] dd = new double[3], ds = new double[3];
            for (int i = 0; i < 3; i++)
            {
                var l = L.DirDirection[i];
                double dotNL = Clamp01(n[0] * l[0] + n[1] * l[1] + n[2] * l[2]);
                // BRDF_GGX
                double hx = l[0] + v[0], hy = l[1] + v[1], hz = l[2] + v[2];
                double hl = Math.Sqrt(hx * hx + hy * hy + hz * hz);
                hx /= hl; hy /= hl; hz /= hl;
                double dotNV = Clamp01(n[0] * v[0] + n[1] * v[1] + n[2] * v[2]);
                double dotNH = Clamp01(n[0] * hx + n[1] * hy + n[2] * hz);
                double dotVH = Clamp01(v[0] * hx + v[1] * hy + v[2] * hz);
                double fresnel = Math.Pow(2, (-5.55473 * dotVH - 6.98316) * dotVH);
                double F = f0 * (1.0 - fresnel) + f90 * fresnel;
                double a2 = Pow2(alpha);
                double gv = dotNL * Math.Sqrt(a2 + (1.0 - a2) * Pow2(dotNV));
                double gl = dotNV * Math.Sqrt(a2 + (1.0 - a2) * Pow2(dotNL));
                double V = 0.5 / Math.Max(gv + gl, 1e-6);
                double denom = Pow2(dotNH) * (a2 - 1.0) + 1.0;
                double D = 0.3183098861837907 * a2 / Pow2(denom);
                double spec = F * (V * D);
                var c = L.DirColor[i];
                for (int ch = 0; ch < 3; ch++)
                {
                    double irr = dotNL * c[ch];
                    ds[ch] += irr * spec;
                    dd[ch] += irr * 0.3183098861837907 * diffuse[ch];
                }
            }
            // indirect: ambient + hemisphere (RE_IndirectDiffuse); RE_IndirectSpecular gets iblIrradiance = 0: nothing
            double hdot = n[0] * L.HemiDirection[0] + n[1] * L.HemiDirection[1] + n[2] * L.HemiDirection[2];
            double w = 0.5 * hdot + 0.5;
            var outp = new double[3];
            for (int ch = 0; ch < 3; ch++)
            {
                double irr = L.Ambient[ch] + (L.HemiGround[ch] + (L.HemiSky[ch] - L.HemiGround[ch]) * w);
                double id = irr * 0.3183098861837907 * diffuse[ch];
                outp[ch] = dd[ch] + id + ds[ch] + emissive[ch];
            }
            return outp;
        }

        /// <summary>three's NeutralToneMapping (exposure 1).</summary>
        public static void NeutralToneMap(double[] c)
        {
            const double StartCompression = 0.8 - 0.04, Desaturation = 0.15;
            double x = Math.Min(c[0], Math.Min(c[1], c[2]));
            double offset = x < 0.08 ? x - 6.25 * x * x : 0.04;
            c[0] -= offset; c[1] -= offset; c[2] -= offset;
            double peak = Math.Max(c[0], Math.Max(c[1], c[2]));
            if (peak < StartCompression) return;
            double d = 1 - StartCompression;
            double newPeak = 1 - d * d / (peak + d - StartCompression);
            for (int i = 0; i < 3; i++) c[i] *= newPeak / peak;
            double g = 1 - 1 / (Desaturation * (peak - newPeak) + 1);
            for (int i = 0; i < 3; i++) c[i] = c[i] + (newPeak - c[i]) * g;
        }

        /// <summary>three's sRGBTransferOETF (the shader's own: pow 0.41666).</summary>
        public static double Oetf(double v) => v <= 0.0031308 ? v * 12.92 : Math.Pow(v, 0.41666) * 1.055 - 0.055;

        static byte U8(double v) => (byte)Math.Round(Math.Max(0, Math.Min(1, v)) * 255);

        // ---- the CPU reference ------------------------------------------------------------------------------------------
        /// <summary>A texture as raw RGBA8.</summary>
        public sealed class Tex
        {
            public int W, H;
            public byte[] Rgba;
            // bilinear, clamp to edge, base level (the card is magnified on the stage), raw values 0..1
            public void Sample(double u, double v, double[] o)
            {
                // GL: t = 1 - v flips nothing: three uploads with flipY, so v = 0 is the image's bottom row
                double x = u * W - 0.5, y = (1 - v) * H - 0.5;
                int x0 = (int)Math.Floor(x), y0 = (int)Math.Floor(y);
                double fx = x - x0, fy = y - y0;
                for (int c = 0; c < 4; c++) o[c] = 0;
                for (int j = 0; j < 2; j++)
                    for (int i = 0; i < 2; i++)
                    {
                        int xi = Math.Max(0, Math.Min(W - 1, x0 + i)), yi = Math.Max(0, Math.Min(H - 1, y0 + j));
                        double wt = (i == 0 ? 1 - fx : fx) * (j == 0 ? 1 - fy : fy);
                        int p = (yi * W + xi) * 4;
                        for (int c = 0; c < 4; c++) o[c] += wt * Rgba[p + c] / 255.0;
                    }
            }
        }

        /// <summary>The stage as the app shows it: the toy's mesh, displaced by its uniforms, drawn into a
        /// (stagePx * factor)^2 target, resolved and composited over `bg` (rgb 0..255). RGBA8 stagePx x stagePx, rows top
        /// down.</summary>
        public static byte[] Render(SquishToy s, Tex tex, int stagePx, int factor, byte[] bg)
        {
            int T = stagePx * factor;
            var cam = s.Camera;
            var L = Lights(cam);
            var mv = M4.Multiply(cam.MatrixWorldInverse, s.MatrixWorld);
            var nm = M4.NormalMatrix(mv);
            var P = cam.Projection;
            var g = s.Geo;
            int nv = g.VertCount;
            // vertex stage
            var sx = new double[nv]; var sy = new double[nv]; var sz = new double[nv]; var iw = new double[nv];
            var vn = new double[nv * 3]; var vp = new double[nv * 3];
            float[] press = s.Uploaded ? s.PressUniform : new float[SquishToy.MaxPresses * 4];
            int count = s.Uploaded ? s.UniformCount : 0;
            float[] dir = s.UniformDir, dent = s.Uploaded ? s.UniformDent : new float[] { (float)s.DentRadiusC, (float)s.DentTipC, (float)(s.DentDepthC * 1.5), 0 };
            for (int i = 0; i < nv; i++)
            {
                SquishShaderMath.Displace(g.BasePos, g.BaseNormals, i, press, count, dir, dent, out var tx, out var ty, out var tz, out var nx, out var ny, out var nz);
                double mx = mv[0] * tx + mv[4] * ty + mv[8] * tz + mv[12], my = mv[1] * tx + mv[5] * ty + mv[9] * tz + mv[13], mz = mv[2] * tx + mv[6] * ty + mv[10] * tz + mv[14];
                double cx = P[0] * mx + P[4] * my + P[8] * mz + P[12], cy = P[1] * mx + P[5] * my + P[9] * mz + P[13], cz = P[2] * mx + P[6] * my + P[10] * mz + P[14], cw = P[3] * mx + P[7] * my + P[11] * mz + P[15];
                iw[i] = 1 / cw;
                sx[i] = (cx * iw[i] * 0.5 + 0.5) * T;
                sy[i] = (1 - (cy * iw[i] * 0.5 + 0.5)) * T;
                sz[i] = cz * iw[i];
                double ex = nm[0] * nx + nm[3] * ny + nm[6] * nz, ey = nm[1] * nx + nm[4] * ny + nm[7] * nz, ez = nm[2] * nx + nm[5] * ny + nm[8] * nz;
                double el = Math.Sqrt(ex * ex + ey * ey + ez * ez);
                vn[i * 3] = ex / el; vn[i * 3 + 1] = ey / el; vn[i * 3 + 2] = ez / el;
                vp[i * 3] = -mx; vp[i * 3 + 1] = -my; vp[i * 3 + 2] = -mz;
            }
            // raster stage into the target: linear rgb / HEADROOM, alpha; depth LessEqual
            var target = new float[T * T * 4];
            var depth = new float[T * T];
            for (int i = 0; i < depth.Length; i++) depth[i] = float.PositiveInfinity;
            var idx = g.Index;
            var smp = new double[4];
            var nq = new double[4][];
            for (int q = 0; q < 4; q++) nq[q] = new double[3];
            for (int t = 0; t < idx.Length; t += 3)
            {
                int a = idx[t], b = idx[t + 1], c = idx[t + 2];
                // front faces are counter-clockwise in NDC (y up) = clockwise in these rows (y down)
                double area = (sx[b] - sx[a]) * (sy[c] - sy[a]) - (sx[c] - sx[a]) * (sy[b] - sy[a]);
                if (area >= 0) continue;
                int x0 = Math.Max(0, (int)Math.Floor(Math.Min(sx[a], Math.Min(sx[b], sx[c])))), x1 = Math.Min(T - 1, (int)Math.Ceiling(Math.Max(sx[a], Math.Max(sx[b], sx[c]))));
                int y0 = Math.Max(0, (int)Math.Floor(Math.Min(sy[a], Math.Min(sy[b], sy[c])))), y1 = Math.Min(T - 1, (int)Math.Ceiling(Math.Max(sy[a], Math.Max(sy[b], sy[c]))));
                double inv = 1 / area;
                for (int py = y0; py <= y1; py++)
                    for (int px = x0; px <= x1; px++)
                    {
                        double cxp = px + 0.5, cyp = py + 0.5;
                        Bary(sx, sy, a, b, c, cxp, cyp, inv, out var l0, out var l1, out var l2);
                        if (!Inside(l0, l1, l2, sx, sy, a, b, c)) continue;
                        double z = l0 * sz[a] + l1 * sz[b] + l2 * sz[c];
                        int pi = py * T + px;
                        if (!(z <= depth[pi])) continue;
                        // perspective-correct weights
                        Persp(l0, l1, l2, iw[a], iw[b], iw[c], out var p0, out var p1, out var p2);
                        double u = p0 * g.Uv[a * 2] + p1 * g.Uv[b * 2] + p2 * g.Uv[c * 2];
                        double v = p0 * g.Uv[a * 2 + 1] + p1 * g.Uv[b * 2 + 1] + p2 * g.Uv[c * 2 + 1];
                        tex.Sample(u, v, smp);
                        if (smp[3] < AlphaTest) continue;
                        // the normal at the 2x2 quad's pixels (the GPU's derivatives), from this triangle's interpolation
                        int qx = px & ~1, qy = py & ~1;
                        for (int q = 0; q < 4; q++)
                        {
                            Bary(sx, sy, a, b, c, qx + (q & 1) + 0.5, qy + (q >> 1) + 0.5, inv, out var m0, out var m1, out var m2);
                            Persp(m0, m1, m2, iw[a], iw[b], iw[c], out var w0, out var w1, out var w2);
                            Lerp3(vn, a, b, c, w0, w1, w2, nq[q]);
                            Norm(nq[q]);
                        }
                        int row = (py & 1) << 1;
                        double dxx = Math.Abs(nq[row + 1][0] - nq[row][0]), dxy = Math.Abs(nq[row + 1][1] - nq[row][1]), dxz = Math.Abs(nq[row + 1][2] - nq[row][2]);
                        int col = px & 1;
                        double dyx = Math.Abs(nq[2 + col][0] - nq[col][0]), dyy = Math.Abs(nq[2 + col][1] - nq[col][1]), dyz = Math.Abs(nq[2 + col][2] - nq[col][2]);
                        double geoR = Math.Max(Math.Max(Math.Max(dxx, dyx), Math.Max(dxy, dyy)), Math.Max(dxz, dyz));
                        var n = new double[3];
                        Lerp3(vn, a, b, c, p0, p1, p2, n);
                        Norm(n);
                        var vv = new double[3];
                        Lerp3(vp, a, b, c, p0, p1, p2, vv);
                        Norm(vv);
                        var col3 = Fragment(smp, n, vv, geoR, L);
                        if (col3 == null) continue;
                        depth[pi] = (float)z;
                        // the 8-bit sRGB target (hardware encode, rounded)
                        target[pi * 4] = (float)(U8(LinearToSrgbExact(Clamp01(col3[0]))) / 255.0);
                        target[pi * 4 + 1] = (float)(U8(LinearToSrgbExact(Clamp01(col3[1]))) / 255.0);
                        target[pi * 4 + 2] = (float)(U8(LinearToSrgbExact(Clamp01(col3[2]))) / 255.0);
                        target[pi * 4 + 3] = 1;
                    }
            }
            return Resolve(target, T, factor, bg);
        }

        /// <summary>Supersample's quad: each stage pixel samples the target bilinearly at its centre (factor 2: the
        /// average of 2x2 texels, decoded to linear before filtering), x HEADROOM, Neutral tone map, sRGB, blended
        /// One / OneMinusSrcAlpha over the page.</summary>
        public static byte[] Resolve(float[] target, int T, int factor, byte[] bg)
        {
            int S = T / factor;
            var outp = new byte[S * S * 4];
            var c = new double[3];
            for (int y = 0; y < S; y++)
                for (int x = 0; x < S; x++)
                {
                    double r = 0, gg = 0, b = 0, al = 0;
                    // the sample point is at (x + 0.5) * factor in the target: the 2x2 texels around it, equally weighted
                    double fx = (x + 0.5) * factor - 0.5, fy = (y + 0.5) * factor - 0.5;
                    int x0 = (int)Math.Floor(fx), y0 = (int)Math.Floor(fy);
                    double ax = fx - x0, ay = fy - y0;
                    for (int j = 0; j < 2; j++)
                        for (int i = 0; i < 2; i++)
                        {
                            int xi = Math.Min(T - 1, Math.Max(0, x0 + i)), yi = Math.Min(T - 1, Math.Max(0, y0 + j));
                            double wgt = (i == 0 ? 1 - ax : ax) * (j == 0 ? 1 - ay : ay);
                            int p = (yi * T + xi) * 4;
                            r += wgt * SrgbToLinearExact(target[p]); gg += wgt * SrgbToLinearExact(target[p + 1]); b += wgt * SrgbToLinearExact(target[p + 2]); al += wgt * target[p + 3];
                        }
                    c[0] = r * Headroom; c[1] = gg * Headroom; c[2] = b * Headroom;
                    NeutralToneMap(c);
                    int o = (y * S + x) * 4;
                    for (int ch = 0; ch < 3; ch++)
                    {
                        // (blended in the framebuffer at float precision, then stored as 8 bits)
                        outp[o + ch] = U8(Oetf(Clamp01(c[ch])) + bg[ch] / 255.0 * (1 - al));
                    }
                    outp[o + 3] = 255;
                }
            return outp;
        }

        static double SrgbToLinearExact(double c) => c <= 0.04045 ? c / 12.92 : Math.Pow((c + 0.055) / 1.055, 2.4);

        static void Bary(double[] sx, double[] sy, int a, int b, int c, double x, double y, double inv, out double l0, out double l1, out double l2)
        {
            l0 = ((sx[b] - x) * (sy[c] - y) - (sx[c] - x) * (sy[b] - y)) * inv;
            l1 = ((sx[c] - x) * (sy[a] - y) - (sx[a] - x) * (sy[c] - y)) * inv;
            l2 = 1 - l0 - l1;
        }

        // the top-left rule (rows top down, clockwise triangles): a pixel centre exactly on an edge belongs to the
        // triangle when that edge is a top or left edge
        static bool Inside(double l0, double l1, double l2, double[] sx, double[] sy, int a, int b, int c)
        {
            if (l0 < 0 || l1 < 0 || l2 < 0) return false;
            if (l0 > 0 && l1 > 0 && l2 > 0) return true;
            // on an edge: edge opposite vertex k is (k+1 -> k+2)
            int[] v = { a, b, c };
            double[] l = { l0, l1, l2 };
            for (int k = 0; k < 3; k++)
            {
                if (l[k] != 0) continue;
                int p = v[(k + 1) % 3], q = v[(k + 2) % 3];
                double ex = sx[q] - sx[p], ey = sy[q] - sy[p];
                bool top = ey == 0 && ex < 0, left = ey > 0;
                if (!(top || left)) return false;
            }
            return true;
        }

        static void Persp(double l0, double l1, double l2, double w0, double w1, double w2, out double p0, out double p1, out double p2)
        {
            double a = l0 * w0, b = l1 * w1, c = l2 * w2, s = a + b + c;
            p0 = a / s; p1 = b / s; p2 = c / s;
        }

        static void Lerp3(double[] arr, int a, int b, int c, double w0, double w1, double w2, double[] o)
        {
            for (int k = 0; k < 3; k++) o[k] = w0 * arr[a * 3 + k] + w1 * arr[b * 3 + k] + w2 * arr[c * 3 + k];
        }

        static void Norm(double[] o)
        {
            double l = Math.Sqrt(o[0] * o[0] + o[1] * o[1] + o[2] * o[2]);
            if (l > 0) { o[0] /= l; o[1] /= l; o[2] /= l; }
        }
    }
}
