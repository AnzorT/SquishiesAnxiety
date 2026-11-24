// Squish Time's 3D stage in Unity: the card (SquishToy's mesh, its atlas, the dent uniforms) drawn with three's own
// matrices (StageCamera: fov 30 at (0, 0.1, 4.6) looking at the origin; the group's matrixWorld) into a square
// RenderTexture at Supersample's factor 2 (SquishCard.shader: the dent, the card's lighting, the sRGB target), then
// shown by a quad on the stage's box that resolves it (SquishResolve.shader: average, x4, Neutral tone map, sRGB,
// premultiplied blend over the sky), as src/screens/SquishScreen.js SquishStage + src/components/Supersample.js draw
// it. Every frame: Draw(toy) after toy.Tick.
//
// Culling: three keeps the card's front faces (counter-clockwise on screen, y up); Unity's culling convention and
// its render-texture flip differ per graphics API, so on the first frame a test triangle wound like a three front
// face is drawn with Cull Back into a 4 x 4 target and read back, and the card's shader culls Back or Front from it.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace SquishSquad.Games.Squish
{
    public sealed class SquishStage
    {
        public const int Factor = 2;   // <Supersample factor={2} /> (the app steps down to 1.5 / 1 on a slow GPU: not done)

        readonly Transform _root;
        readonly Mesh _mesh, _glow, _crown;
        readonly Material _card, _resolve, _glowMat, _crownMat;
        readonly MaterialPropertyBlock _props = new MaterialPropertyBlock();
        readonly CommandBuffer _cb = new CommandBuffer { name = "Squish stage" };
        readonly GameObject _quad;
        readonly MeshFilter _quadMf;
        readonly MeshRenderer _quadMr;
        RenderTexture _rt;
        int _px;
        bool _disposed;   // (Dispose runs once; a Draw after it does nothing: its command buffer is released)
        bool _calibrated;
        readonly SquishShade.LightSet _lights;
        readonly Vector4[] _press = new Vector4[SquishToy.MaxPresses];

        /// <summary>The card's atlas changed (it downloaded): the same card, its own art.</summary>
        public void SetAtlas(Texture2D atlas) { if (atlas != null) _card.SetTexture("_MainTex", atlas); }

        public SquishStage(Transform parent, Texture2D atlas, Texture2D crown, int sortingOrder)
        {
            _root = parent;
            var geo = SquishToy.MakeCard(null, 1, 0, 0).Geo;
            _mesh = CardMesh(geo);
            _card = new Material(Resources.Load<Shader>("SquishShaders/SquishCard")) { hideFlags = HideFlags.HideAndDontSave };
            _card.SetTexture("_MainTex", atlas);
            _resolve = new Material(Resources.Load<Shader>("SquishShaders/SquishResolve")) { hideFlags = HideFlags.HideAndDontSave };
            var basic = Resources.Load<Shader>("SquishShaders/SquishBasic");
            _glowMat = new Material(basic) { hideFlags = HideFlags.HideAndDontSave };
            _crownMat = new Material(basic) { hideFlags = HideFlags.HideAndDontSave };
            _glow = Circle((float)SquishCard.GlowRadius, 48);
            _crown = Plane((float)SquishCard.CrownW, (float)SquishCard.CrownH);
            if (crown != null) { _crownMat.SetTexture("_MainTex", crown); _crownMat.SetFloat("_Decode", 1); _crownMat.SetFloat("_AlphaTest", 0.1f); }
            _lights = SquishShade.Lights(new StageCamera());

            _quad = new GameObject("squish stage");
            _quad.transform.SetParent(parent, false);
            _quadMf = _quad.AddComponent<MeshFilter>();
            _quadMr = _quad.AddComponent<MeshRenderer>();
            _quadMr.sharedMaterial = _resolve;
            _quadMr.sortingOrder = sortingOrder;
            var q = new Mesh { name = "squish stage quad", hideFlags = HideFlags.HideAndDontSave };
            q.SetVertices(new[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero });
            q.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            q.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            _quadMf.sharedMesh = q;
        }

        // three's attributes and triangles as they are (its coordinates, uvs and winding: Calibrate picks the cull)
        static Mesh CardMesh(CardGeometry g)
        {
            var m = new Mesh { name = "squish card", hideFlags = HideFlags.HideAndDontSave, indexFormat = IndexFormat.UInt32 };
            var v = new Vector3[g.VertCount]; var n = new Vector3[g.VertCount]; var uv = new Vector2[g.VertCount];
            for (int i = 0; i < g.VertCount; i++)
            {
                v[i] = new Vector3(g.BasePos[i * 3], g.BasePos[i * 3 + 1], g.BasePos[i * 3 + 2]);
                n[i] = new Vector3(g.BaseNormals[i * 3], g.BaseNormals[i * 3 + 1], g.BaseNormals[i * 3 + 2]);
                uv[i] = new Vector2(g.Uv[i * 2], g.Uv[i * 2 + 1]);
            }
            m.vertices = v; m.normals = n; m.uv = uv;
            m.SetTriangles(g.Index, 0);
            // (the dent moves vertices by up to ~0.6 units: no culling by Unity's bounds)
            m.bounds = new Bounds(Vector3.zero, Vector3.one * 100);
            return m;
        }

        static Mesh Circle(float r, int seg)
        {
            var v = new List<Vector3> { Vector3.zero }; var uv = new List<Vector2> { new Vector2(0.5f, 0.5f) }; var t = new List<int>();
            for (int i = 0; i <= seg; i++)
            {
                float a = i / (float)seg * Mathf.PI * 2;
                v.Add(new Vector3(Mathf.Cos(a) * r, Mathf.Sin(a) * r, 0));
                uv.Add(new Vector2((Mathf.Cos(a) + 1) / 2, (Mathf.Sin(a) + 1) / 2));
                if (i > 0) { t.Add(0); t.Add(i); t.Add(i + 1); }
            }
            var m = new Mesh { hideFlags = HideFlags.HideAndDontSave };
            m.SetVertices(v); m.SetUVs(0, uv); m.SetTriangles(t, 0);
            m.bounds = new Bounds(Vector3.zero, Vector3.one * 100);
            return m;
        }

        static Mesh Plane(float w, float h)
        {
            var m = new Mesh { hideFlags = HideFlags.HideAndDontSave };
            m.SetVertices(new[] { new Vector3(-w / 2, -h / 2, 0), new Vector3(w / 2, -h / 2, 0), new Vector3(w / 2, h / 2, 0), new Vector3(-w / 2, h / 2, 0) });
            m.SetUVs(0, new[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            m.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            m.bounds = new Bounds(Vector3.zero, Vector3.one * 100);
            return m;
        }

        static Matrix4x4 M(double[] te)
        {
            var m = new Matrix4x4();
            for (int r = 0; r < 4; r++) for (int c = 0; c < 4; c++) m[r, c] = (float)te[c * 4 + r];
            return m;
        }

        static Matrix4x4 M3(double[] te)
        {
            var m = Matrix4x4.identity;
            for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++) m[r, c] = (float)te[c * 3 + r];
            return m;
        }

        static Vector4 V(double[] a) => new Vector4((float)a[0], (float)a[1], (float)a[2], 0);

        void EnsureTarget(int stagePx)
        {
            int T = stagePx * Factor;
            if (_rt != null && _px == stagePx) return;
            if (_rt != null) { _rt.Release(); Object.Destroy(_rt); }
            _px = stagePx;
            _rt = new RenderTexture(T, T, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear)
            {
                name = "squish stage x2", filterMode = FilterMode.Point, wrapMode = TextureWrapMode.Clamp, antiAliasing = 1, useMipMap = false, hideFlags = HideFlags.HideAndDontSave,
            };
            _rt.Create();
            _resolve.SetTexture("_MainTex", _rt);
            _resolve.SetFloat("_Headroom", (float)SquishShade.Headroom);
        }

        // three's front face (counter-clockwise in NDC, y up) drawn with Cull Back: kept -> Cull Back, else Cull Front
        void Calibrate()
        {
            _calibrated = true;
            var rt = RenderTexture.GetTemporary(4, 4, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
            var tri = new Mesh { hideFlags = HideFlags.HideAndDontSave };
            tri.SetVertices(new[] { new Vector3(-1, -1, 0), new Vector3(3, -1, 0), new Vector3(-1, 3, 0) });   // CCW
            tri.SetUVs(0, new[] { Vector2.zero, Vector2.zero, Vector2.zero });
            tri.SetNormals(new[] { Vector3.forward, Vector3.forward, Vector3.forward });
            tri.SetTriangles(new[] { 0, 1, 2 }, 0);
            tri.bounds = new Bounds(Vector3.zero, Vector3.one * 100);
            var probe = new Material(_card) { hideFlags = HideFlags.HideAndDontSave };
            probe.SetFloat("_SqCull", (float)CullMode.Back);
            probe.SetTexture("_MainTex", Texture2D.whiteTexture);
            var p = new MaterialPropertyBlock();
            p.SetMatrix("_SqClip", GL.GetGPUProjectionMatrix(Matrix4x4.identity, true));
            p.SetMatrix("_SqMV", Matrix4x4.identity);
            p.SetMatrix("_SqNrm", Matrix4x4.identity);
            p.SetInt("_SqCount", 0);
            p.SetVector("_SqDent", new Vector4(0.3f, 0.05f, 0.54f, 0));
            p.SetVector("_SqLook", new Vector4(1, 1, 0.85f, 0.5f));
            var cb = new CommandBuffer();
            cb.SetRenderTarget(rt);
            cb.ClearRenderTarget(true, true, Color.clear);
            cb.DrawMesh(tri, Matrix4x4.identity, probe, 0, 0, p);
            Graphics.ExecuteCommandBuffer(cb);
            var prev = RenderTexture.active;
            RenderTexture.active = rt;
            var read = new Texture2D(4, 4, TextureFormat.RGBA32, false);
            read.ReadPixels(new Rect(0, 0, 4, 4), 0, 0);
            read.Apply();
            RenderTexture.active = prev;
            bool kept = read.GetPixel(1, 1).a > 0.5f;
            _card.SetFloat("_SqCull", (float)(kept ? CullMode.Back : CullMode.Front));
            Object.Destroy(read); Object.Destroy(probe); Object.Destroy(tri);
            cb.Release();
            RenderTexture.ReleaseTemporary(rt);
        }

        /// <summary>Draws the toy's frame and places the stage's quad on `stage` (dp, y down, from the screen's top-left).</summary>
        public void Draw(SquishToy toy, HudBox stage, float pxPerDp)
        {
            if (_disposed) return;
            int px = Mathf.Max(1, Mathf.RoundToInt(stage.W * pxPerDp));
            EnsureTarget(px);
            if (!_calibrated) Calibrate();
            var cam = toy.Camera;
            var view = cam.MatrixWorldInverse;
            var mv = M4.Multiply(view, toy.MatrixWorld);
            var gpuProj = GL.GetGPUProjectionMatrix(M(cam.Projection), true);
            _props.Clear();
            _props.SetMatrix("_SqMV", M(mv));
            _props.SetMatrix("_SqClip", gpuProj * M(mv));
            _props.SetMatrix("_SqNrm", M3(M4.NormalMatrix(mv)));
            for (int j = 0; j < SquishToy.MaxPresses; j++)
                _press[j] = new Vector4(toy.PressUniform[j * 4], toy.PressUniform[j * 4 + 1], toy.PressUniform[j * 4 + 2], toy.PressUniform[j * 4 + 3]);
            _props.SetVectorArray("_SqPress", _press);
            _props.SetInt("_SqCount", toy.Uploaded ? toy.UniformCount : 0);
            _props.SetVector("_SqDir", new Vector4(toy.UniformDir[0], toy.UniformDir[1], toy.UniformDir[2], 0));
            _props.SetVector("_SqDent", toy.Uploaded ? new Vector4(toy.UniformDent[0], toy.UniformDent[1], toy.UniformDent[2], 0)
                : new Vector4((float)toy.DentRadiusC, (float)toy.DentTipC, (float)(toy.DentDepthC * 1.5), 0));
            _props.SetVectorArray("_SqLightDir", new[] { V(_lights.DirDirection[0]), V(_lights.DirDirection[1]), V(_lights.DirDirection[2]) });
            _props.SetVectorArray("_SqLightCol", new[] { V(_lights.DirColor[0]), V(_lights.DirColor[1]), V(_lights.DirColor[2]) });
            _props.SetVector("_SqHemiDir", V(_lights.HemiDirection));
            _props.SetVector("_SqHemiSky", V(_lights.HemiSky));
            _props.SetVector("_SqHemiGround", V(_lights.HemiGround));
            _props.SetVector("_SqAmbient", V(_lights.Ambient));
            _props.SetVector("_SqLook", new Vector4((float)SquishShade.CardLit, (float)(SquishShade.CardSelf / SquishShade.Headroom), (float)SquishShade.Roughness, (float)SquishShade.AlphaTest));

            _cb.Clear();
            _cb.SetRenderTarget(_rt);
            _cb.ClearRenderTarget(true, true, Color.clear);
            _cb.DrawMesh(_mesh, Matrix4x4.identity, _card, 0, 0, _props);
            if (toy.Crown)
            {
                // the glow (behind the card, depth-tested) then the crown, as three sorts its transparent objects
                var glowM = M4.Multiply(toy.MatrixWorld, M4.Compose(new V3(0, 0, SquishCard.GlowZ), new Quat(0, 0, 0, 1), new V3(1, 1, 1)));
                var gp = new MaterialPropertyBlock();
                gp.SetMatrix("_SqClip", gpuProj * M(M4.Multiply(view, glowM)));
                var gc = SquishShade.HexLinear(0xffd24a);
                gp.SetVector("_Color", new Vector4((float)gc[0], (float)gc[1], (float)gc[2], (float)toy.GlowOpacity));
                _cb.DrawMesh(_glow, Matrix4x4.identity, _glowMat, 0, 0, gp);
                var crownM = M4.Multiply(toy.MatrixWorld, M4.Compose(SquishCard.CrownPosition(toy.Head), Quat.FromEulerXYZ(0, 0, SquishCard.CrownRotZ), new V3(1, 1, 1)));
                var cp = new MaterialPropertyBlock();
                cp.SetMatrix("_SqClip", gpuProj * M(M4.Multiply(view, crownM)));
                cp.SetVector("_Color", Vector4.one);
                _cb.DrawMesh(_crown, Matrix4x4.identity, _crownMat, 0, 0, cp);
            }
            Graphics.ExecuteCommandBuffer(_cb);

            // the quad: world units are screen pixels, y up, the screen's top-left at the parent's origin
            float k = pxPerDp, x0 = Mathf.Round(stage.X * k), y0 = Mathf.Round(stage.Y * k);
            var q = _quadMf.sharedMesh;
            q.SetVertices(new[] { new Vector3(x0, -y0, 0), new Vector3(x0 + px, -y0, 0), new Vector3(x0 + px, -(y0 + px), 0), new Vector3(x0, -(y0 + px), 0) });
            q.RecalculateBounds();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            if (_rt != null) { _rt.Release(); Object.Destroy(_rt); }
            _cb.Release();
            Object.Destroy(_mesh); Object.Destroy(_glow); Object.Destroy(_crown);
            Object.Destroy(_card); Object.Destroy(_resolve); Object.Destroy(_glowMat); Object.Destroy(_crownMat);
            if (_quad != null) Object.Destroy(_quad);
        }
    }
}
