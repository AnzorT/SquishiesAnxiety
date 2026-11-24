// A picture on screen that UiPiece can't show: cut to a box (the room's things down to the floor line), repeated (the
// room-switch flash's dots), or laid on the board's plane in perspective (the Living Room's rug: a grid of small
// quads whose corners are the plane's points on screen, so each is drawn with the board's own perspective). Units: dp,
// y down, as UiPiece; the same shader (straight alpha).
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Games.Hop
{
    public sealed class HopMesh : MonoBehaviour
    {
        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        MeshRenderer _mr;
        MeshFilter _mf;
        MaterialPropertyBlock _props;
        Texture _tex;
        Vector2[] _local;          // the vertices, piece-local dp (a grid: screen dp)
        bool _screen;              // a grid: its points are on the screen already
        Vector3[] _verts;
        static Material _show;

        public static HopMesh Create(Transform parent, string name, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var m = go.AddComponent<HopMesh>();
            m._mf = go.AddComponent<MeshFilter>();
            m._mr = go.AddComponent<MeshRenderer>();
            if (_show == null) _show = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { hideFlags = HideFlags.HideAndDontSave };
            m._mr.sharedMaterial = _show;
            m._mr.sortingOrder = order;
            m._props = new MaterialPropertyBlock();
            return m;
        }

        public int Order { get => _mr.sortingOrder; set => _mr.sortingOrder = value; }
        public bool Visible { get => _mr.enabled; set => _mr.enabled = value; }

        public void Set(HopLayer l, Texture2D tex)
        {
            _tex = tex;
            var mesh = _mf.sharedMesh;
            if (mesh == null) { mesh = new Mesh { name = name, hideFlags = HideFlags.HideAndDontSave }; mesh.MarkDynamic(); _mf.sharedMesh = mesh; }
            mesh.Clear();
            if (l.Grid != null)
            {
                int n = l.GridN, row = n + 1;
                _screen = true;
                _local = new Vector2[row * row];
                var uv = new Vector2[row * row];
                for (int r = 0; r <= n; r++)
                    for (int c = 0; c <= n; c++)
                    {
                        int i = r * row + c;
                        _local[i] = new Vector2((float)l.Grid[i * 2], (float)l.Grid[i * 2 + 1]);
                        uv[i] = new Vector2((float)c / n, 1 - (float)r / n);
                    }
                var tris = new int[n * n * 6];
                int t = 0;
                for (int r = 0; r < n; r++)
                    for (int c = 0; c < n; c++)
                    {
                        int a = r * row + c;
                        tris[t++] = a; tris[t++] = a + 1; tris[t++] = a + row + 1;
                        tris[t++] = a; tris[t++] = a + row + 1; tris[t++] = a + row;
                    }
                _verts = new Vector3[_local.Length];
                Place();
                mesh.vertices = _verts;
                mesh.uv = uv;
                mesh.triangles = tris;
            }
            else
            {
                _screen = false;
                float x = 0, y = 0, w = l.W, h = l.H;
                if (l.Clip != null) { x = l.Clip[0]; y = l.Clip[1]; w = l.Clip[2]; h = l.Clip[3]; }
                _local = new[] { new Vector2(x, y), new Vector2(x + w, y), new Vector2(x + w, y + h), new Vector2(x, y + h) };
                Vector2[] uv;
                if (l.TileW > 0)
                {
                    if (tex != null) tex.wrapMode = TextureWrapMode.Repeat;
                    float u1 = w / l.TileW, v1 = h / l.TileH;
                    uv = new[] { new Vector2(0, 1), new Vector2(u1, 1), new Vector2(u1, 1 - v1), new Vector2(0, 1 - v1) };
                }
                else
                {
                    float u0 = x / l.W, u1 = (x + w) / l.W, v0 = 1 - y / l.H, v1 = 1 - (y + h) / l.H;
                    uv = new[] { new Vector2(u0, v0), new Vector2(u1, v0), new Vector2(u1, v1), new Vector2(u0, v1) };
                }
                _verts = new Vector3[4];
                Place();
                mesh.vertices = _verts;
                mesh.uv = uv;
                mesh.triangles = new[] { 0, 1, 2, 0, 2, 3 };
            }
            Apply();
        }

        void Place()
        {
            var m = _screen ? Affine.Identity : Transform;
            float k = Ui.UiPiece.PxPerDp;
            for (int i = 0; i < _local.Length; i++)
            {
                float x = _local[i].x, y = _local[i].y;
                _verts[i] = new Vector3((float)(m.A * x + m.C * y + m.E) * k, -(float)(m.B * x + m.D * y + m.F) * k, 0);
            }
        }

        void LateUpdate() => Apply();

        public void Apply()
        {
            var mesh = _mf != null ? _mf.sharedMesh : null;
            if (mesh == null || _local == null) return;
            Place();
            mesh.vertices = _verts;
            mesh.RecalculateBounds();
            transform.localPosition = Vector3.zero; transform.localRotation = Quaternion.identity; transform.localScale = Vector3.one;
            _props.SetTexture("_MainTex", _tex != null ? _tex : Texture2D.blackTexture);
            _props.SetFloat("_Opacity", Mathf.Clamp01(Opacity));
            _props.SetFloat("_Straight", 1);
            _mr.SetPropertyBlock(_props);
            _mr.forceRenderingOff = Opacity <= 0;
        }

        void OnDestroy()
        {
            if (_mf != null && _mf.sharedMesh != null) { if (Application.isPlaying) Destroy(_mf.sharedMesh); else DestroyImmediate(_mf.sharedMesh); }
        }
    }
}
