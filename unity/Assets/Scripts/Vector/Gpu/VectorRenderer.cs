// Draws an SvgScene into a RenderTexture on the GPU: every shape by stencil-then-cover (fans into the stencil, a quad
// over its box with the paint), layers into temporary targets (filters as chains of passes, then clip, mask and
// opacity as they're composited onto the layer below). The target needs a stencil buffer (depth 24) and should have
// MSAA (4x): that's the anti-aliasing. Checked against Chrome by tools/unity/vector-test (the same scene, drawn by a
// reference rasteriser that fills the way this stencil does) and by CI screenshots.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace SquishSquad.Vector.Gpu
{
    public sealed class VectorRenderer : IDisposable
    {
        readonly Material _stencil, _cover, _composite, _filter;
        readonly CommandBuffer _cb = new CommandBuffer { name = "SquishSquad.Vector" };
        readonly Mesh _mesh;
        readonly List<Vector3> _verts = new List<Vector3>(8192);
        readonly List<List<int>> _subs = new List<List<int>>();
        int _usedSubs;
        Texture2D _ramp;
        readonly List<Paint> _rampPaints = new List<Paint>();
        readonly Dictionary<Paint, int> _rampRow = new Dictionary<Paint, int>();
        readonly Dictionary<string, Texture2D> _noise = new Dictionary<string, Texture2D>();
        int _tempSeq;
        float _w, _h;
        int _fullQuad = -1;

        // feImage sources by href (the rigs' fabric tile is href="grain": a 128 px tile repeated 8 x 8 over the image box)
        public readonly Dictionary<string, (Texture tex, Vector2 repeat)> Images = new Dictionary<string, (Texture, Vector2)>();
        public static readonly RenderTextureFormat FilterFormat = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;

        static readonly int PxToClip = Shader.PropertyToID("_PxToClip"), Size = Shader.PropertyToID("_Size"), MainTex = Shader.PropertyToID("_MainTex"),
            SecondTex = Shader.PropertyToID("_SecondTex"), ClipTex = Shader.PropertyToID("_Clip"), MaskTex = Shader.PropertyToID("_Mask"), RampTex = Shader.PropertyToID("_Ramp");

        public VectorRenderer()
        {
            Material Load(string name)
            {
                var sh = Resources.Load<Shader>("VectorShaders/" + name);
                if (sh == null) throw new InvalidOperationException("missing shader Resources/VectorShaders/" + name);
                return new Material(sh) { hideFlags = HideFlags.HideAndDontSave };
            }
            _stencil = Load("VectorStencil"); _cover = Load("VectorCover"); _composite = Load("VectorComposite"); _filter = Load("VectorFilter");
            _mesh = new Mesh { name = "VectorShapes", indexFormat = IndexFormat.UInt32, hideFlags = HideFlags.HideAndDontSave };
            _mesh.MarkDynamic();
            _ramp = new Texture2D(256, RampRows, TextureFormat.RGBA32, false, true) { name = "gradient ramps", wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear, hideFlags = HideFlags.HideAndDontSave };
        }

        public void Dispose()
        {
            _cb.Release();
            Kill(_mesh); Kill(_stencil); Kill(_cover); Kill(_composite); Kill(_filter); Kill(_ramp);
            foreach (var t in _noise.Values) Kill(t);
            _noise.Clear();
        }

        static void Kill(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o); }

        // ---- one frame --------------------------------------------------------------------------------------------
        public void Render(SvgScene scene, RenderTexture target)
        {
            _w = target.width; _h = target.height;
            _verts.Clear(); _usedSubs = 0; _tempSeq = 0;
            _rampPaints.Clear(); _rampRow.Clear();
            _cb.Clear();
            _fullQuad = Quad(new Box { X0 = 0, Y0 = 0, X1 = _w, Y1 = _h });
            var proj = GL.GetGPUProjectionMatrix(Matrix4x4.Ortho(0, _w, _h, 0, -1, 1), true);
            _cb.SetGlobalMatrix(PxToClip, proj);
            _cb.SetGlobalVector(Size, new Vector4(_w, _h, 0, 0));
            _cb.SetGlobalTexture(RampTex, _ramp);   // filled below, before the buffer runs
            _cb.SetRenderTarget(target);
            _cb.ClearRenderTarget(true, true, Color.clear);
            Draw(scene.Root.Children, target);
            UploadMesh();
            UploadRamp();
            Graphics.ExecuteCommandBuffer(_cb);
        }

        void Draw(List<RenderNode> nodes, RenderTargetIdentifier into)
        {
            foreach (var n in nodes)
            {
                if (n is FillNode f) Fill(f);
                else if (n is LayerNode l) Layer(l, into);
            }
        }

        void Fill(FillNode f)
        {
            var props = PaintProps(f.Paint, f.Opacity, f.UserToPx, f.UserBox);
            if (props == null) return;
            Shape(f.Shape, props);
        }

        void Shape(Shape s, MaterialPropertyBlock props)
        {
            int fan = Fans(s);
            if (fan < 0) return;
            var b = s.Bounds;
            int cover = Quad(new Box { X0 = b.X0 - 1, Y0 = b.Y0 - 1, X1 = b.X1 + 1, Y1 = b.Y1 + 1 });
            int pass = s.Rule == FillRule.NonZero ? 0 : s.Rule == FillRule.EvenOdd ? 1 : 2;
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _stencil, fan, pass);
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _cover, cover, 0, props);
        }

        int Temp(bool msaa, RenderTextureFormat fmt)
        {
            int id = Shader.PropertyToID("_SquishVecTmp" + (_tempSeq++));
            _cb.GetTemporaryRT(id, (int)_w, (int)_h, msaa ? 24 : 0, FilterMode.Bilinear, fmt, RenderTextureReadWrite.Default, msaa ? 4 : 1);
            return id;
        }

        void Layer(LayerNode l, RenderTargetIdentifier parent)
        {
            int layer = Temp(true, RenderTextureFormat.ARGB32);
            _cb.SetRenderTarget(layer);
            _cb.ClearRenderTarget(true, true, Color.clear);
            Draw(l.Children, layer);
            var temps = new List<int> { layer };
            RenderTargetIdentifier result = layer;
            if (l.Filter != null) result = Filter(l, layer, temps);

            int clip = -1, mask = -1;
            if (l.Clip != null)
            {
                clip = Temp(true, RenderTextureFormat.ARGB32); temps.Add(clip);
                _cb.SetRenderTarget(clip);
                _cb.ClearRenderTarget(true, true, Color.clear);
                var white = SolidProps(new RGBA(1, 1, 1, 1), 1);
                foreach (var s in l.Clip) Shape(s, white);
            }
            if (l.Mask != null)
            {
                mask = Temp(true, RenderTextureFormat.ARGB32); temps.Add(mask);
                _cb.SetRenderTarget(mask);
                _cb.ClearRenderTarget(true, true, Color.clear);
                Draw(l.Mask.Children, mask);
            }

            _cb.SetRenderTarget(parent);
            var p = new MaterialPropertyBlock();
            p.SetFloat("_Opacity", l.Opacity);
            p.SetFloat("_UseClip", clip >= 0 ? 1 : 0);
            p.SetFloat("_UseMask", mask >= 0 ? 1 : 0);
            var r = l.MaskRegionPx;
            p.SetVector("_MaskRect", r.IsEmpty ? new Vector4(-1e6f, -1e6f, 1e6f, 1e6f) : new Vector4((float)r.X0, (float)r.Y0, (float)r.X1, (float)r.Y1));
            _cb.SetGlobalTexture(MainTex, result);
            if (clip >= 0) _cb.SetGlobalTexture(ClipTex, clip);
            if (mask >= 0) _cb.SetGlobalTexture(MaskTex, mask);
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _composite, _fullQuad, 0, p);
            foreach (var t in temps) _cb.ReleaseTemporaryRT(t);
        }

        // ---- filters: the <filter>'s primitives in order, each one pass (or a cached noise texture) ------------------
        RenderTargetIdentifier Filter(LayerNode l, int source, List<int> temps)
        {
            var f = l.Filter;
            var results = new Dictionary<string, RenderTargetIdentifier>();
            int src = Temp(false, FilterFormat); temps.Add(src);
            Pass(0, src, source, null, null);
            results["SourceGraphic"] = src;
            RenderTargetIdentifier last = src;
            var inv = l.UserToPx.Inverse();
            double scale = l.UserToPx.Scale;
            RenderTargetIdentifier In(string name) => name != null && results.TryGetValue(name, out var r) ? r : last;
            foreach (var prim in f.Children)
            {
                RenderTargetIdentifier outp;
                var mp = new MaterialPropertyBlock();
                switch (prim.Tag)
                {
                    case "feTurbulence":
                        outp = Noise(prim, l.UserToPx);
                        break;
                    case "feImage":
                    {
                        var href = prim["href"] ?? prim["xlink:href"] ?? "";
                        if (!Images.TryGetValue(href, out var img) || img.tex == null) { outp = Blank(temps); break; }
                        // px -> user -> image box (0..1, v up)
                        double x = prim.Num("x"), y = prim.Num("y"), w = prim.Num("width", 1), h = prim.Num("height", 1);
                        var toImg = new Affine(1 / w, 0, 0, -1 / h, -x / w, 1 + y / h) * inv;
                        mp.SetVector("_Img0", new Vector4((float)toImg.A, (float)toImg.C, (float)toImg.E, 1));
                        mp.SetVector("_Img1", new Vector4((float)toImg.B, (float)toImg.D, (float)toImg.F, 0));
                        mp.SetVector("_P", new Vector4(img.repeat.x, img.repeat.y, 0, 0));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        PassTex(7, o, img.tex, mp);
                        outp = o;
                        break;
                    }
                    case "feColorMatrix":
                    {
                        var m = ColorMatrix(prim);
                        mp.SetVector("_M0", new Vector4(m[0], m[1], m[2], m[3])); mp.SetVector("_M1", new Vector4(m[5], m[6], m[7], m[8]));
                        mp.SetVector("_M2", new Vector4(m[10], m[11], m[12], m[13])); mp.SetVector("_M3", new Vector4(m[15], m[16], m[17], m[18]));
                        mp.SetVector("_M4", new Vector4(m[4], m[9], m[14], m[19]));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(2, o, In(prim["in"]), null, mp);
                        outp = o;
                        break;
                    }
                    case "feComposite":
                    {
                        var op = prim["operator"] ?? "over";
                        mp.SetVector("_K", new Vector4(op == "in" ? 1 : op == "out" ? 2 : op == "atop" ? 3 : op == "xor" ? 4 : 0, 0, 0, 0));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(3, o, In(prim["in"]), In(prim["in2"]), mp);
                        outp = o;
                        break;
                    }
                    case "feBlend":
                    {
                        var mode = prim["mode"] ?? "normal";
                        mp.SetVector("_K", new Vector4(mode == "multiply" ? 1 : mode == "screen" ? 2 : 0, 0, 0, 0));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(4, o, In(prim["in"]), In(prim["in2"]), mp);
                        outp = o;
                        break;
                    }
                    case "feDisplacementMap":
                    {
                        int Ch(string v) { int k = "RGBA".IndexOf((v ?? "A")[0]); return k < 0 ? 3 : k; }
                        mp.SetVector("_P", new Vector4((float)(prim.Num("scale") * scale), Ch(prim["xChannelSelector"]), Ch(prim["yChannelSelector"]), 0));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(5, o, In(prim["in"]), In(prim["in2"]), mp);
                        outp = o;
                        break;
                    }
                    case "feGaussianBlur":
                    {
                        var sd = (prim["stdDeviation"] ?? "0").Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        float sx = (float)((sd.Length > 0 ? SvgNum.Parse(sd[0]) : 0) * scale), sy = (float)((sd.Length > 1 ? SvgNum.Parse(sd[1]) : (sd.Length > 0 ? SvgNum.Parse(sd[0]) : 0)) * scale);
                        int a = Temp(false, FilterFormat), b = Temp(false, FilterFormat); temps.Add(a); temps.Add(b);
                        var mx = new MaterialPropertyBlock(); mx.SetVector("_P", new Vector4(1, 0, sx, 0));
                        Pass(6, a, In(prim["in"]), null, mx);
                        mp.SetVector("_P", new Vector4(0, 1, sy, 0));
                        Pass(6, b, a, null, mp);
                        outp = b;
                        break;
                    }
                    case "feOffset":
                    {
                        var d = l.UserToPx.ApplyVector(new Vec2(prim.Num("dx"), prim.Num("dy")));
                        mp.SetVector("_P", new Vector4((float)d.X, (float)d.Y, 0, 0));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(9, o, In(prim["in"]), null, mp);
                        outp = o;
                        break;
                    }
                    case "feFlood":
                    {
                        Colors.TryParse(prim.Prop("flood-color") ?? "#000", out var c);
                        mp.SetVector("_Color", new Vector4(c.R, c.G, c.B, c.A * Mathf.Clamp01(SvgNum.Parse(prim.Prop("flood-opacity") ?? "1", 1))));
                        int o = Temp(false, FilterFormat); temps.Add(o);
                        Pass(8, o, null, null, mp);
                        outp = o;
                        break;
                    }
                    case "feMerge":
                    {
                        RenderTargetIdentifier acc = Blank(temps);
                        foreach (var node in prim.Children)
                        {
                            if (node.Tag != "feMergeNode") continue;
                            int o = Temp(false, FilterFormat); temps.Add(o);
                            Pass(10, o, In(node["in"]), acc, null);
                            acc = o;
                        }
                        outp = acc;
                        break;
                    }
                    default:
                        outp = In(prim["in"]);
                        break;
                }
                last = outp;
                var res = prim["result"];
                if (res != null) results[res] = outp;
            }
            int back = Temp(false, RenderTextureFormat.ARGB32); temps.Add(back);
            Pass(1, back, last, null, null);
            // the filter region (objectBoundingBox units by default: -10 % / 120 % of the box), in px
            var region = Region(l, f);
            if (region.IsEmpty) return back;
            int clipped = Temp(false, RenderTextureFormat.ARGB32); temps.Add(clipped);
            var rp = new MaterialPropertyBlock();
            rp.SetVector("_Rect", new Vector4((float)region.X0, (float)region.Y0, (float)region.X1, (float)region.Y1));
            Pass(11, clipped, back, null, rp);
            return clipped;
        }

        static Box Region(LayerNode l, SvgNode f)
        {
            var b = l.UserBox;
            if (b.IsEmpty) return Box.Empty;
            Box r;
            if (f["filterUnits"] == "userSpaceOnUse") r = new Box { X0 = f.Num("x", -1e6f), Y0 = f.Num("y", -1e6f), X1 = f.Num("x", -1e6f) + f.Num("width", 2e6f), Y1 = f.Num("y", -1e6f) + f.Num("height", 2e6f) };
            else
            {
                double fx = Colors.Fraction(f["x"], -0.1), fy = Colors.Fraction(f["y"], -0.1), fw = Colors.Fraction(f["width"], 1.2), fh = Colors.Fraction(f["height"], 1.2);
                r = new Box { X0 = b.X0 + fx * b.W, Y0 = b.Y0 + fy * b.H, X1 = b.X0 + (fx + fw) * b.W, Y1 = b.Y0 + (fy + fh) * b.H };
            }
            var px = Box.Empty;
            foreach (var p in new[] { new Vec2(r.X0, r.Y0), new Vec2(r.X1, r.Y0), new Vec2(r.X0, r.Y1), new Vec2(r.X1, r.Y1) }) px.Add(l.UserToPx.Apply(p));
            return px;
        }

        RenderTargetIdentifier Blank(List<int> temps)
        {
            int o = Temp(false, FilterFormat); temps.Add(o);
            _cb.SetRenderTarget(o);
            _cb.ClearRenderTarget(false, true, Color.clear);
            return o;
        }

        void Pass(int pass, int into, RenderTargetIdentifier? a, RenderTargetIdentifier? b, MaterialPropertyBlock p)
        {
            if (a.HasValue) _cb.SetGlobalTexture(MainTex, a.Value);
            if (b.HasValue) _cb.SetGlobalTexture(SecondTex, b.Value);
            _cb.SetRenderTarget(into);
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _filter, _fullQuad, pass, p);
        }

        void PassTex(int pass, int into, Texture tex, MaterialPropertyBlock p)
        {
            _cb.SetGlobalTexture(MainTex, tex);
            _cb.SetRenderTarget(into);
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _filter, _fullQuad, pass, p);
        }

        // feTurbulence over the whole target, in the filtered element's user space: computed once per settings and
        // placement (the creature's frame doesn't move), premultiplied linearRGB like the other filter results
        Texture2D Noise(SvgNode prim, Affine userToPx)
        {
            var bf = (prim["baseFrequency"] ?? "0").Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double fx = bf.Length > 0 ? SvgNum.Parse(bf[0]) : 0, fy = bf.Length > 1 ? SvgNum.Parse(bf[1]) : fx;
            int oct = (int)prim.Num("numOctaves", 1); long seed = (long)Math.Round(prim.Num("seed", 0));
            bool fractal = prim["type"] == "fractalNoise";
            string key = $"{fx},{fy},{oct},{seed},{fractal},{_w}x{_h},{userToPx.A:0.####},{userToPx.D:0.####},{userToPx.E:0.##},{userToPx.F:0.##}";
            if (_noise.TryGetValue(key, out var tex) && tex != null) return tex;
            int w = (int)_w, h = (int)_h;
            tex = new Texture2D(w, h, TextureFormat.RGBAHalf, false, true) { name = "noise " + key, wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear, hideFlags = HideFlags.HideAndDontSave };
            var px = new Color[w * h];
            var T = Turbulence.For(seed);
            var inv = userToPx.Inverse();
            var pt = new double[2];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var u = inv.Apply(new Vec2(x + 0.5, y + 0.5));
                    pt[0] = u.X; pt[1] = u.Y;
                    float r = Ch(T, 0), g = Ch(T, 1), b = Ch(T, 2), a = Ch(T, 3);
                    // texture rows go bottom-up: row 0 is the bottom of the target
                    px[(h - 1 - y) * w + x] = new Color(r * a, g * a, b * a, a);
                }
            float Ch(Turbulence t, int c) { double v = t.Turb(c, pt, fx, fy, oct, fractal); if (fractal) v = (v + 1) / 2; return (float)Math.Max(0, Math.Min(1, v)); }
            tex.SetPixels(px);
            tex.Apply(false, true);
            _noise[key] = tex;
            return tex;
        }

        static float[] ColorMatrix(SvgNode p)
        {
            var type = p["type"] ?? "matrix";
            var vals = (p["values"] ?? "").Split(new[] { ' ', ',', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (type == "matrix" && vals.Length >= 20) { var m = new float[20]; for (int k = 0; k < 20; k++) m[k] = SvgNum.Parse(vals[k]); return m; }
            if (type == "saturate")
            {
                float s = vals.Length > 0 ? SvgNum.Parse(vals[0]) : 1;
                return new[] { 0.213f + 0.787f * s, 0.715f - 0.715f * s, 0.072f - 0.072f * s, 0, 0, 0.213f - 0.213f * s, 0.715f + 0.285f * s, 0.072f - 0.072f * s, 0, 0, 0.213f - 0.213f * s, 0.715f - 0.715f * s, 0.072f + 0.928f * s, 0, 0, 0, 0, 0, 1, 0 };
            }
            if (type == "hueRotate")
            {
                float h = (vals.Length > 0 ? SvgNum.Parse(vals[0]) : 0) * Mathf.Deg2Rad, c = Mathf.Cos(h), s = Mathf.Sin(h);
                return new[] { 0.213f + c * 0.787f - s * 0.213f, 0.715f - c * 0.715f - s * 0.715f, 0.072f - c * 0.072f + s * 0.928f, 0, 0,
                               0.213f - c * 0.213f + s * 0.143f, 0.715f + c * 0.285f + s * 0.140f, 0.072f - c * 0.072f - s * 0.283f, 0, 0,
                               0.213f - c * 0.213f - s * 0.787f, 0.715f - c * 0.715f + s * 0.715f, 0.072f + c * 0.928f + s * 0.072f, 0, 0, 0, 0, 0, 1, 0 };
            }
            if (type == "luminanceToAlpha") return new[] { 0f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.2125f, 0.7154f, 0.0721f, 0, 0 };
            return new[] { 1f, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 };
        }

        // ---- paints -------------------------------------------------------------------------------------------------
        MaterialPropertyBlock SolidProps(RGBA c, float opacity)
        {
            var p = new MaterialPropertyBlock();
            p.SetFloat("_Kind", 0);
            p.SetVector("_Color", new Vector4(c.R, c.G, c.B, c.A));
            p.SetFloat("_Opacity", opacity);
            return p;
        }

        MaterialPropertyBlock PaintProps(Paint paint, float opacity, Affine userToPx, Box userBox)
        {
            if (paint.Kind == PaintKind.None || opacity <= 0) return null;
            if (paint.Kind == PaintKind.Solid) return paint.Color.A <= 0 ? null : SolidProps(paint.Color, opacity);
            // px -> user -> objectBoundingBox -> gradient space
            var m = userToPx.Inverse();
            if (paint.BoundingBoxUnits)
            {
                if (userBox.IsEmpty || userBox.W <= 0 || userBox.H <= 0) return null;
                m = Affine.ScaleBy(1 / userBox.W, 1 / userBox.H) * Affine.Translate(-userBox.X0, -userBox.Y0) * m;
            }
            m = paint.GradientTransform.Inverse() * m;
            var p = new MaterialPropertyBlock();
            p.SetFloat("_Kind", paint.Kind == PaintKind.Linear ? 1 : 2);
            p.SetVector("_G0", new Vector4((float)m.A, (float)m.C, (float)m.E, 0));
            p.SetVector("_G1", new Vector4((float)m.B, (float)m.D, (float)m.F, 0));
            p.SetVector("_Lin", new Vector4((float)paint.X1, (float)paint.Y1, (float)paint.X2, (float)paint.Y2));
            p.SetVector("_Rad", new Vector4((float)paint.Cx, (float)paint.Cy, (float)paint.R, 0));
            p.SetVector("_Foc", new Vector4((float)paint.Fx, (float)paint.Fy, 0, 0));
            p.SetFloat("_Spread", paint.Spread);
            p.SetFloat("_Opacity", opacity);
            if (!_rampRow.TryGetValue(paint, out int row)) { row = Math.Min(_rampPaints.Count, RampRows - 1); if (_rampPaints.Count < RampRows) _rampPaints.Add(paint); _rampRow[paint] = row; }
            // (a property block is copied into the command buffer as the draw is recorded: the row is final here)
            p.SetFloat("_RampV", (row + 0.5f) / RampRows);
            return p;
        }

        // one row of 256 colours per gradient in the frame (a frame has ~10-80); more than this share the last row
        const int RampRows = 256;

        void UploadRamp()
        {
            var px = new Color32[256 * _ramp.height];
            for (int r = 0; r < _rampPaints.Count; r++)
                for (int i = 0; i < 256; i++)
                {
                    var c = _rampPaints[r].At(i / 255.0);
                    px[r * 256 + i] = new Color32((byte)Mathf.RoundToInt(c.R * 255), (byte)Mathf.RoundToInt(c.G * 255), (byte)Mathf.RoundToInt(c.B * 255), (byte)Mathf.RoundToInt(c.A * 255));
                }
            _ramp.SetPixels32(px);
            _ramp.Apply(false, false);
        }

        // ---- geometry: one mesh per frame, a submesh per fan set and per quad ----------------------------------------
        List<int> NextSub()
        {
            if (_usedSubs == _subs.Count) _subs.Add(new List<int>(256));
            var l = _subs[_usedSubs++];
            l.Clear();
            return l;
        }

        int Fans(Shape s)
        {
            int sub = _usedSubs;
            var idx = NextSub();
            foreach (var poly in s.Polygons)
            {
                if (poly.Count < 3) continue;
                int b = _verts.Count;
                foreach (var v in poly) _verts.Add(new Vector3((float)v.X, (float)v.Y, 0));
                for (int i = 1; i + 1 < poly.Count; i++) { idx.Add(b); idx.Add(b + i); idx.Add(b + i + 1); }
            }
            if (idx.Count == 0) { _usedSubs--; return -1; }
            return sub;
        }

        int Quad(Box b)
        {
            int sub = _usedSubs;
            var idx = NextSub();
            int i = _verts.Count;
            _verts.Add(new Vector3((float)b.X0, (float)b.Y0, 0)); _verts.Add(new Vector3((float)b.X1, (float)b.Y0, 0));
            _verts.Add(new Vector3((float)b.X1, (float)b.Y1, 0)); _verts.Add(new Vector3((float)b.X0, (float)b.Y1, 0));
            idx.Add(i); idx.Add(i + 1); idx.Add(i + 2); idx.Add(i); idx.Add(i + 2); idx.Add(i + 3);
            return sub;
        }

        void UploadMesh()
        {
            _mesh.Clear();
            _mesh.SetVertices(_verts);
            _mesh.subMeshCount = _usedSubs;
            for (int i = 0; i < _usedSubs; i++) _mesh.SetTriangles(_subs[i], i, false);
            _mesh.bounds = new Bounds(new Vector3(_w / 2, _h / 2, 0), new Vector3(_w * 4, _h * 4, 10));
        }
    }
}
