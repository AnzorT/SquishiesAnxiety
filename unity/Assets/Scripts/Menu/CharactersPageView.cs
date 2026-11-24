// Puts a page's draw list (CharactersPageKit.cs PageDraw: the Characters page, the Level Pass) on screen. Each layer
// (the page, its loading screen) is drawn into its own RenderTexture first, as CSS composites an element with its
// opacity as one, then the page's layer is shown on a quad over the menu with its opening motion. Pictures are the
// exported PNG / JPEG bytes (Resources/<page>/<res>.png.bytes, decoded here: exactly as cut, whatever the import
// settings), loaded the first time they're drawn; the texts Unity draws are SVGs rendered by the vector renderer
// (Vector/Gpu) once per text. Drawing uses the Game Park's piece shader (MenuShaders/ParkPiece: straight or
// premultiplied pictures, opacity, a mask, here a white one for a scroll box's clip).
using System;
using System.Collections.Generic;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;
using UnityEngine.Rendering;

namespace SquishSquad.Menu
{
    public sealed class CharactersPageView : IDisposable
    {
        readonly string _root;              // Resources folder ("Characters/", "LevelPass/")
        readonly Transform _parent;
        readonly int _order;
        readonly Material _mat;
        readonly Dictionary<string, Texture2D> _pics = new Dictionary<string, Texture2D>();
        readonly Dictionary<string, RenderTexture> _svgs = new Dictionary<string, RenderTexture>();
        readonly Dictionary<string, RenderTexture> _layers = new Dictionary<string, RenderTexture>();
        readonly List<Mesh> _meshes = new List<Mesh>();
        readonly List<MaterialPropertyBlock> _blocks = new List<MaterialPropertyBlock>();
        readonly CommandBuffer _cb = new CommandBuffer { name = "SquishSquad.Page" };
        VectorRenderer _vr;
        GameObject _quad;
        Mesh _quadMesh;
        MeshRenderer _mr;
        MaterialPropertyBlock _quadProps;
        int _used;
        bool _disposed;   // (Dispose runs once; a Show after it does nothing: its command buffer is released)
        static readonly int PxToClip = Shader.PropertyToID("_ParkPxToClip");

        /// <summary>Pictures of another page's folder ("LevelPass/you/...": the marker's creatures) by a prefix.</summary>
        public Func<string, string> ResolveRes = null;

        public CharactersPageView(string resourcesRoot, Transform parent, int order)
        {
            _root = resourcesRoot;
            _parent = parent;
            _order = order;
            _mat = new Material(Resources.Load<Shader>("MenuShaders/ParkPiece")) { hideFlags = HideFlags.HideAndDontSave };
        }

        /// <summary>Draws the page (its root draw: the page's layer) for this frame.</summary>
        public void Show(PageDraw root)
        {
            if (_disposed) return;
            _used = 0;
            Texture tex = root.Layer != null ? Layer(root) : Picture(root.Res, root.Jpeg);
            EnsureQuad();
            var m = root.M;
            Vector3 P(double x, double y) { var v = m.Apply(new Vec2(x, y)); return new Vector3((float)v.X, -(float)v.Y, 0); }
            _quadMesh.SetVertices(new[] { P(0, 0), P(root.W, 0), P(root.W, root.H), P(0, root.H) });
            _quadMesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            _quadMesh.RecalculateBounds();
            _quadProps.Clear();
            _quadProps.SetTexture("_MainTex", tex != null ? tex : Texture2D.blackTexture);
            _quadProps.SetTexture("_Mask", Texture2D.whiteTexture);
            _quadProps.SetFloat("_Opacity", Mathf.Clamp01((float)root.Opacity));
            _quadProps.SetFloat("_Bright", 1);
            _quadProps.SetFloat("_Straight", root.Layer != null ? 0 : 1);
            _quadProps.SetFloat("_Opaque", 0);
            _quadProps.SetFloat("_UseMask", 0);
            _quadProps.SetFloat("_IntoRt", 0);
            _mr.SetPropertyBlock(_quadProps);
            _mr.enabled = root.Opacity > 0;
        }

        void EnsureQuad()
        {
            if (_quad != null) return;
            _quad = new GameObject("page");
            _quad.transform.SetParent(_parent, false);
            _quadMesh = new Mesh { name = "page", hideFlags = HideFlags.HideAndDontSave };
            _quadMesh.MarkDynamic();
            _quadMesh.SetVertices(new Vector3[4]);
            _quadMesh.SetUVs(0, new Vector2[4]);
            _quadMesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            _quad.AddComponent<MeshFilter>().sharedMesh = _quadMesh;
            _mr = _quad.AddComponent<MeshRenderer>();
            _mr.sharedMaterial = _mat;
            _mr.sortingOrder = _order;
            _quadProps = new MaterialPropertyBlock();
        }

        // a layer: its draws into its own texture (its px: y down, top-left 0, 0); nested layers first
        RenderTexture Layer(PageDraw layer)
        {
            // the textures it uses (nested layers drawn before this one's command buffer is built)
            var texs = new Texture[layer.Layer.Count];
            for (int i = 0; i < layer.Layer.Count; i++)
            {
                var d = layer.Layer[i];
                texs[i] = d.Layer != null ? Layer(d) : d.Svg != null ? Svg(d) : Picture(d.Res, d.Jpeg);
            }
            int w = Mathf.Max(1, layer.W), h = Mathf.Max(1, layer.H);
            if (!_layers.TryGetValue(layer.Key, out var rt) || rt.width != w || rt.height != h)
            {
                if (rt != null) { rt.Release(); Kill(rt); }
                rt = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32) { name = layer.Key, hideFlags = HideFlags.HideAndDontSave, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp };
                rt.Create();
                _layers[layer.Key] = rt;
            }
            _cb.Clear();
            _cb.SetRenderTarget(rt);
            _cb.ClearRenderTarget(false, true, Color.clear);
            _cb.SetGlobalMatrix(PxToClip, GL.GetGPUProjectionMatrix(Matrix4x4.Ortho(0, w, h, 0, -1, 1), true));
            for (int i = 0; i < layer.Layer.Count; i++)
            {
                var d = layer.Layer[i];
                if (texs[i] == null || d.Opacity <= 0) continue;
                var mesh = NextMesh(out var props);
                Fill(mesh, d);
                props.Clear();
                props.SetTexture("_MainTex", texs[i]);
                props.SetTexture("_Mask", Texture2D.whiteTexture);
                props.SetFloat("_Opacity", Mathf.Clamp01((float)d.Opacity));
                props.SetFloat("_Bright", 1);
                props.SetFloat("_Straight", d.Layer == null && d.Svg == null ? 1 : 0);
                props.SetFloat("_Opaque", 0);
                props.SetFloat("_UseMask", d.Clip ? 1 : 0);
                props.SetFloat("_IntoRt", 1);
                _cb.DrawMesh(mesh, Matrix4x4.identity, _mat, 0, 0, props);
            }
            Graphics.ExecuteCommandBuffer(_cb);
            return rt;
        }

        Mesh NextMesh(out MaterialPropertyBlock props)
        {
            if (_used == _meshes.Count)
            {
                var m = new Mesh { name = "piece", hideFlags = HideFlags.HideAndDontSave };
                m.MarkDynamic();
                m.SetVertices(new Vector3[4]);
                m.SetUVs(0, new Vector2[4]);
                m.SetUVs(1, new Vector2[4]);
                m.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
                _meshes.Add(m);
                _blocks.Add(new MaterialPropertyBlock());
            }
            props = _blocks[_used];
            return _meshes[_used++];
        }

        static readonly Vector3[] V = new Vector3[4];
        static readonly Vector2[] Uv = new Vector2[4], Uv2 = new Vector2[4];

        // the draw's quad in its layer's px (y down): its part of the picture mapped by M; uv2: where it is in its clip box
        static void Fill(Mesh mesh, PageDraw d)
        {
            double x0 = d.U0 * d.W, x1 = d.U1 * d.W, y0 = d.V0 * d.H, y1 = d.V1 * d.H;
            var pts = new[] { new Vec2(x0, y0), new Vec2(x1, y0), new Vec2(x1, y1), new Vec2(x0, y1) };
            var uvs = new[] { new Vector2((float)d.U0, 1 - (float)d.V0), new Vector2((float)d.U1, 1 - (float)d.V0), new Vector2((float)d.U1, 1 - (float)d.V1), new Vector2((float)d.U0, 1 - (float)d.V1) };
            for (int k = 0; k < 4; k++)
            {
                var s = d.M.Apply(pts[k]);
                V[k] = new Vector3((float)s.X, (float)s.Y, 0);
                Uv[k] = uvs[k];
                Uv2[k] = d.Clip ? new Vector2((float)((s.X - d.CX0) / (d.CX1 - d.CX0)), (float)((s.Y - d.CY0) / (d.CY1 - d.CY0))) : Vector2.zero;
            }
            mesh.SetVertices(V);
            mesh.SetUVs(0, Uv);
            mesh.SetUVs(1, Uv2);
            mesh.RecalculateBounds();
        }

        /// <summary>An exported picture (decoded from its bytes the first time).</summary>
        public Texture2D Picture(string res, bool jpeg = false)
        {
            if (string.IsNullOrEmpty(res)) return null;
            if (_pics.TryGetValue(res, out var t)) return t;
            string path = ResolveRes?.Invoke(res) ?? _root + res;
            var bytes = Resources.Load<TextAsset>(path + (jpeg ? ".jpg" : ".png"));
            if (bytes == null) { Debug.LogWarning("[Page] missing picture Resources/" + path + (jpeg ? ".jpg" : ".png") + ".bytes"); _pics[res] = null; return null; }
            t = new Texture2D(2, 2, jpeg ? TextureFormat.RGB24 : TextureFormat.RGBA32, false) { name = res, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp, hideFlags = HideFlags.HideAndDontSave };
            if (!t.LoadImage(bytes.bytes, true)) { Kill(t); t = null; }
            Resources.UnloadAsset(bytes);
            _pics[res] = t;
            return t;
        }

        // a drawn SVG (a text with the app's fonts): rendered once into its own texture (premultiplied)
        RenderTexture Svg(PageDraw d)
        {
            string key = d.Svg + "|" + d.W + "|" + d.H;
            if (_svgs.TryGetValue(key, out var rt)) return rt;
            if (_svgs.Count > 64) { foreach (var o in _svgs.Values) { o.Release(); Kill(o); } _svgs.Clear(); }
            rt = new RenderTexture(Mathf.Max(1, d.W), Mathf.Max(1, d.H), 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = "text", hideFlags = HideFlags.HideAndDontSave };
            rt.Create();
            _vr ??= new VectorRenderer();
            var root = SvgMarkup.Parse(d.Svg);
            var svg = FindSvg(root);
            double sw = double.Parse(svg["width"], System.Globalization.CultureInfo.InvariantCulture), sh = double.Parse(svg["height"], System.Globalization.CultureInfo.InvariantCulture);
            _vr.Render(SvgScene.Compile(root, sw * d.SvgScale, sh * d.SvgScale, Affine.Identity, null), rt);
            _svgs[key] = rt;
            return rt;
        }

        static SvgNode FindSvg(SvgNode n) { if (n.Tag == "svg") return n; foreach (var c in n.Children) { var r = FindSvg(c); if (r != null) return r; } return null; }

        static void Kill(UnityEngine.Object o)
        {
            if (o == null) return;
            if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            foreach (var t in _pics.Values) Kill(t);
            _pics.Clear();
            foreach (var r in _svgs.Values) if (r != null) { r.Release(); Kill(r); }
            _svgs.Clear();
            foreach (var r in _layers.Values) if (r != null) { r.Release(); Kill(r); }
            _layers.Clear();
            foreach (var m in _meshes) Kill(m);
            _meshes.Clear();
            _vr?.Dispose();
            _cb.Release();
            if (_quadMesh != null) Kill(_quadMesh);
            if (_quad != null) Kill(_quad);
            Kill(_mat);
        }
    }
}
