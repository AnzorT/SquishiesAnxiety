// A door of the fridge or cupboard on screen: like UiPiece (an SVG drawn once into its own texture at the screen's
// density), but placed by a perspective projection, not a 2D transform: the door turns about its hinge with CSS's
// `perspective(p) ... rotateY(θ)` (SortLevel's DoorView). UiPiece moves a quad's four corners, which can't show a
// perspective (the two triangles would bend the picture along their diagonal), so the door is a grid of 32 x 16 cells,
// each vertex projected: within a cell the projection is near enough straight to be drawn affine.
// (Workaround in this folder: UiPiece could take a DoorView-like mapping and do the same, see the report.)
using SquishSquad.Ui;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Games.Sort
{
    public sealed class SortDoorPiece : MonoBehaviour
    {
        const int NX = 32, NY = 16;
        float _w, _h, _margin;
        RenderTexture _rt;
        VectorRenderer _renderer;
        MeshRenderer _mr;
        MeshFilter _mf;
        MaterialPropertyBlock _props;
        string _markup;
        Vector3[] _verts;
        static Material _show;

        public DoorView View;
        public float Opacity = 1;

        public static SortDoorPiece Create(Transform parent, string name, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var p = go.AddComponent<SortDoorPiece>();
            p._mf = go.AddComponent<MeshFilter>();
            p._mr = go.AddComponent<MeshRenderer>();
            if (_show == null) _show = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { hideFlags = HideFlags.HideAndDontSave };
            p._mr.sharedMaterial = _show;
            p._mr.sortingOrder = order;
            p._props = new MaterialPropertyBlock();
            return p;
        }

        public int Order { get => _mr.sortingOrder; set => _mr.sortingOrder = value; }
        public bool Visible { get => _mr.enabled; set => _mr.enabled = value; }

        public void SetSvg(string markup, float w, float h, float margin)
        {
            if (markup == _markup && w == _w && h == _h && _rt != null) return;
            _markup = markup; _w = w; _h = h; _margin = margin;
            float k = UiPiece.PxPerDp;
            int pw = Mathf.Max(1, Mathf.CeilToInt((w + 2 * margin) * k)), ph = Mathf.Max(1, Mathf.CeilToInt((h + 2 * margin) * k));
            if (_rt == null || _rt.width != pw || _rt.height != ph)
            {
                if (_rt != null) { _rt.Release(); Kill(_rt); }
                _rt = new RenderTexture(pw, ph, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = name, hideFlags = HideFlags.HideAndDontSave };
                _rt.Create();
            }
            _renderer ??= new VectorRenderer();
            var scene = SvgScene.Compile(SvgMarkup.Parse(markup), w * k, h * k, Affine.Translate(margin * k, margin * k), _ => null);
            _renderer.Render(scene, _rt);
            BuildMesh();
        }

        void BuildMesh()
        {
            var mesh = _mf.sharedMesh;
            if (mesh != null) return;
            mesh = new Mesh { name = name, hideFlags = HideFlags.HideAndDontSave };
            mesh.MarkDynamic();
            _verts = new Vector3[(NX + 1) * (NY + 1)];
            var uv = new Vector2[_verts.Length];
            for (int j = 0; j <= NY; j++)
                for (int i = 0; i <= NX; i++) uv[j * (NX + 1) + i] = new Vector2((float)i / NX, 1 - (float)j / NY);
            var tris = new int[NX * NY * 6];
            int t = 0;
            for (int j = 0; j < NY; j++)
                for (int i = 0; i < NX; i++)
                {
                    int a = j * (NX + 1) + i, b = a + 1, c = a + NX + 1, d = c + 1;
                    tris[t++] = a; tris[t++] = b; tris[t++] = d; tris[t++] = a; tris[t++] = d; tris[t++] = c;
                }
            mesh.vertices = _verts;
            mesh.uv = uv;
            mesh.triangles = tris;
            _mf.sharedMesh = mesh;
        }

        void LateUpdate() => Apply();

        /// <summary>Projects every vertex of the grid (the texture's box: the door plus its margin) where View says.</summary>
        public void Apply()
        {
            var mesh = _mf != null ? _mf.sharedMesh : null;
            if (mesh == null || View == null) return;
            float k = UiPiece.PxPerDp;
            for (int j = 0; j <= NY; j++)
                for (int i = 0; i <= NX; i++)
                {
                    double u = -_margin + (_w + 2 * _margin) * i / NX, v = -_margin + (_h + 2 * _margin) * j / NY;
                    var p = View.Map(u, v);
                    _verts[j * (NX + 1) + i] = new Vector3((float)p.X * k, -(float)p.Y * k, 0);
                }
            mesh.vertices = _verts;
            mesh.RecalculateBounds();
            transform.localPosition = Vector3.zero; transform.localRotation = Quaternion.identity; transform.localScale = Vector3.one;
            _props.SetTexture("_MainTex", _rt != null ? (Texture)_rt : Texture2D.blackTexture);
            _props.SetFloat("_Opacity", Mathf.Clamp01(Opacity));
            _props.SetFloat("_Straight", 0);
            _mr.SetPropertyBlock(_props);
            _mr.forceRenderingOff = Opacity <= 0;
        }

        void OnDestroy()
        {
            _renderer?.Dispose();
            if (_rt != null) { _rt.Release(); Kill(_rt); }
            if (_mf != null) Kill(_mf.sharedMesh);
        }

        static void Kill(Object o) { if (o == null) return; if (Application.isPlaying) Destroy(o); else DestroyImmediate(o); }
    }
}
