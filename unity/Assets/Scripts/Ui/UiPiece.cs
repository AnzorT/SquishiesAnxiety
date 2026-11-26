// One piece of UI on screen: an SVG (UiSvg / an exported piece) drawn once into its own texture at the screen's
// density, or a picture (a squishy), on a quad that the owner places each frame with any 2D transform and opacity,
// the way React Native moves a view with its transform and opacity styles.
//   Units: dp, y down, (0, 0) the screen's top-left. UiPiece.PxPerDp maps them to the screen's pixels (world units are
//   pixels, y up: MenuScreen's camera).
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Ui
{
    public sealed class UiPiece : MonoBehaviour
    {
        /// <summary>Screen pixels per dp (the screen's height / 384 on phones held sideways).</summary>
        public static float PxPerDp = 2.8125f;
        /// <summary>Pictures an SVG names in &lt;image href&gt; (Resources paths without the extension).</summary>
        /// <summary>An &lt;image&gt;'s picture: a Resources texture, or "still:&lt;key&gt;" a creature's cut-out (the Characters
        /// screen's, Resources/Characters/still/&lt;key&gt;.png.bytes).</summary>
        public static System.Func<string, Texture2D> LoadPicture = name => name != null && name.StartsWith("still:") ? Still(name.Substring(6)) : Resources.Load<Texture2D>(name);
        static Texture2D Still(string key)
        {
            var b = Resources.Load<TextAsset>("Characters/still/" + key + ".png");
            if (b == null) return null;
            var t = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "still " + key, wrapMode = TextureWrapMode.Clamp };
            bool ok = t.LoadImage(b.bytes, true);
            Resources.UnloadAsset(b);
            return ok ? t : null;
        }

        float _w, _h, _margin;      // the piece's box and the room drawn around it (shadows, overhangs), dp
        RenderTexture _rt;
        VectorRenderer _renderer;
        MeshRenderer _mr;
        MeshFilter _mf;
        MaterialPropertyBlock _props;
        Texture _tex;
        bool _straight;
        string _markup;

        /// <summary>Piece-local dp (its box's top-left is 0, 0) to screen dp.</summary>
        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public float Width => _w;
        public float Height => _h;

        static Material _show;

        public static UiPiece Create(Transform parent, string name, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var p = go.AddComponent<UiPiece>();
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

        /// <summary>Draws `markup` (an SVG w x h dp) into the piece's texture; nothing happens if it's unchanged.</summary>
        public void SetSvg(string markup, float w, float h, float margin = 6)
        {
            if (markup == _markup && w == _w && h == _h && _rt != null) return;
            long perf = SquishSquad.App.PerfLog.Mark();
            _markup = markup; _w = w; _h = h; _margin = margin; _straight = false;
            int pw = Mathf.Max(1, Mathf.CeilToInt((w + 2 * margin) * PxPerDp)), ph = Mathf.Max(1, Mathf.CeilToInt((h + 2 * margin) * PxPerDp));
            if (_rt == null || _rt.width != pw || _rt.height != ph)
            {
                if (_rt != null) { _rt.Release(); Kill(_rt); }
                _rt = new RenderTexture(pw, ph, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = name, hideFlags = HideFlags.HideAndDontSave };
                _rt.Create();
            }
            if (markup == null)
            {
                // nothing to draw yet (the result card's "trio edge" until its shine rises): a clear texture
                var was = RenderTexture.active;
                RenderTexture.active = _rt;
                GL.Clear(true, true, Color.clear);
                RenderTexture.active = was;
                _tex = _rt;
                Quad(-margin, -margin, w + 2 * margin, h + 2 * margin);
                return;
            }
            _renderer ??= new VectorRenderer();
            var root = SvgMarkup.Parse(markup);
            // an <svg> with no viewBox is in the piece's own units (dp), as if its viewBox were its box; without this its
            // units were the texture's px, so it came out PxPerDp times too small in the top-left corner (the intro's
            // box, shadow, ring, sparks and peeking squad)
            var outer = Affine.Translate(margin * PxPerDp, margin * PxPerDp);
            if (!HasViewBox(root)) outer = outer * Affine.ScaleBy(PxPerDp, PxPerDp);
            var scene = SvgScene.Compile(root, w * PxPerDp, h * PxPerDp, outer, Size);
            foreach (var href in Hrefs(root)) if (!_renderer.Images.ContainsKey(href)) { var t = Picture(href); if (t != null) _renderer.Images[href] = (t, Vector2.one); }
            _renderer.Render(scene, _rt);
            _tex = _rt;
            Quad(-margin, -margin, w + 2 * margin, h + 2 * margin);
            SquishSquad.App.PerfLog.Add("picture redraw", perf, name, markup?.Length ?? 0);
        }

        static bool HasViewBox(SvgNode root)
        {
            foreach (var c in root.Children) if (c.Tag == "svg") return !string.IsNullOrWhiteSpace(c["viewBox"]);
            return false;
        }

        /// <summary>Shows a picture (straight alpha) filling the box w x h dp.</summary>
        public void SetPicture(Texture tex, float w, float h)
        {
            _markup = null; _w = w; _h = h; _margin = 0; _straight = true; _tex = tex;
            Quad(0, 0, w, h);
        }

        float _qx, _qy, _qw, _qh;   // the quad, piece-local dp
        readonly Vector3[] _verts = new Vector3[4];

        void Quad(float x, float y, float w, float h)
        {
            _qx = x; _qy = y; _qw = w; _qh = h;
            var mesh = _mf.sharedMesh;
            if (mesh == null)
            {
                mesh = new Mesh { name = name, hideFlags = HideFlags.HideAndDontSave };
                mesh.MarkDynamic();
                _mf.sharedMesh = mesh;
                mesh.SetVertices(_verts);
                mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
                mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            }
            Apply();
        }

        void LateUpdate() => Apply();

        /// <summary>Puts the quad where Transform says (every frame; CI screenshots call it directly). Its four corners
        /// are moved, so any 2D transform works, skews included (a squash around a wiggle).</summary>
        public void Apply()
        {
            var mesh = _mf != null ? _mf.sharedMesh : null;
            if (mesh == null) return;
            var m = Transform;
            float k = PxPerDp;
            Vector3 Map(float x, float y) => new Vector3((float)(m.A * x + m.C * y + m.E) * k, -(float)(m.B * x + m.D * y + m.F) * k, 0);
            _verts[0] = Map(_qx, _qy); _verts[1] = Map(_qx + _qw, _qy); _verts[2] = Map(_qx + _qw, _qy + _qh); _verts[3] = Map(_qx, _qy + _qh);
            mesh.SetVertices(_verts);
            mesh.RecalculateBounds();
            transform.localPosition = Vector3.zero; transform.localRotation = Quaternion.identity; transform.localScale = Vector3.one;
            _props.SetTexture("_MainTex", _tex != null ? _tex : Texture2D.blackTexture);
            _props.SetFloat("_Opacity", Mathf.Clamp01(Opacity));
            _props.SetFloat("_Straight", _straight ? 1 : 0);
            _mr.SetPropertyBlock(_props);
            _mr.forceRenderingOff = Opacity <= 0;
        }

        (int w, int h)? Size(string href)
        {
            var t = Picture(href);
            return t == null ? ((int, int)?)null : (t.width, t.height);
        }

        static readonly System.Collections.Generic.Dictionary<string, Texture2D> Pictures = new System.Collections.Generic.Dictionary<string, Texture2D>();

        static Texture2D Picture(string href)
        {
            if (Pictures.TryGetValue(href, out var t)) return t;
            t = LoadPicture(href);
            Pictures[href] = t;
            return t;
        }

        static System.Collections.Generic.IEnumerable<string> Hrefs(SvgNode n)
        {
            if (n.Tag == "image") { var h = n["href"] ?? n["xlink:href"]; if (h != null) yield return h; }
            foreach (var c in n.Children) foreach (var h in Hrefs(c)) yield return h;
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
