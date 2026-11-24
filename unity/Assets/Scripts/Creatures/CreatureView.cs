// A live creature on screen: each frame its SVG (from IRigFrames) is compiled (SvgScene) and drawn on the GPU
// (VectorRenderer) into its own RenderTexture, shown on a quad. World units are screen pixels with y down as -y, like
// MenuView: the creature's box is `boxPx` (left, top, width, height) on the screen, and the quad covers it plus a
// margin of Margin x its size on each side (creatures draw outside their box: the app's SVG has overflow visible).
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.Creatures
{
    public sealed class CreatureView : MonoBehaviour
    {
        IRigFrames _rig;
        VectorRenderer _renderer;
        RenderTexture _rt;
        MeshRenderer _mr;
        Material _show;
        string _last;
        float _t0;
        int _size, _rtSize;
        float _scaleK = 1;
        const float Margin = 0.25f;

        /// <summary>The time used for the frame; by default seconds since Show.</summary>
        public float? FixedTime;

        public static CreatureView Create(Transform parent, IRigFrames rig, Rect boxPx, int sortingOrder)
        {
            var go = new GameObject("creature (live)");
            go.transform.SetParent(parent, false);
            var v = go.AddComponent<CreatureView>();
            v.Init(rig, boxPx, sortingOrder);
            return v;
        }

        void Init(IRigFrames rig, Rect boxPx, int order)
        {
            _rig = rig;
            _renderer = new VectorRenderer();
            var tile = Resources.Load<Texture2D>("Creatures/grain-tile");
            if (tile != null) _renderer.Images["grain"] = (tile, new Vector2(8, 8));   // a 128 px tile over the 1024 px pattern
            _size = Mathf.Max(16, Mathf.RoundToInt(boxPx.width));
            int pad = Mathf.RoundToInt(_size * Margin);
            _rtSize = _size + 2 * pad;
            _rt = new RenderTexture(_rtSize, _rtSize, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = "creature", hideFlags = HideFlags.HideAndDontSave };
            _rt.Create();
            float k = boxPx.width / _size;   // screen px per texture px (1 on the reference screen)
            _scaleK = k;
            transform.localPosition = new Vector3(boxPx.x - pad * k, -(boxPx.y - pad * k), 0);
            float w = _rtSize * k, h = _rtSize * k;
            var mesh = new Mesh { name = "creature quad", hideFlags = HideFlags.HideAndDontSave };
            mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(w, 0, 0), new Vector3(w, -h, 0), new Vector3(0, -h, 0) });
            mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            gameObject.AddComponent<MeshFilter>().sharedMesh = mesh; _mesh = mesh; _qk = k; _pad = pad;
            _mr = gameObject.AddComponent<MeshRenderer>();
            _show = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { hideFlags = HideFlags.HideAndDontSave, mainTexture = _rt };
            _mr.sharedMaterial = _show;
            _mr.sortingOrder = order;
            _t0 = Time.realtimeSinceStartup;
        }

        public void Play(string move) => _rig?.Play(move);

        /// <summary>Its colour times `tint`, saturated by `sat` (white, 1: as drawn): the game intro's night light (menu.js
        /// light(): CSS brightness / saturate / a little sepia on the stage).</summary>
        public void SetTint(Color tint, float sat)
        {
            if (_show == null) return;
            _show.SetColor("_Tint", tint);
            _show.SetFloat("_Sat", sat);
        }

        Mesh _mesh; float _qk, _clip = -1; int _pad;
        /// <summary>Cuts the picture off below a line `frac` of the box down from its top (the beach's wading: the
        /// page's clip-path inset(0 0 ins px 0)); a negative frac shows it all.</summary>
        public void ClipBottom(float frac)
        {
            if (_mesh == null || frac == _clip) return; _clip = frac;
            float w = _rtSize * _qk, cut = frac < 0 ? _rtSize : Mathf.Clamp(_pad + frac * _size, 0, _rtSize), h = cut * _qk, v = 1 - cut / _rtSize;
            _mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(w, 0, 0), new Vector3(w, -h, 0), new Vector3(0, -h, 0) });
            _mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, v), new Vector2(0, v) });
            _mesh.RecalculateBounds();
        }

        /// <summary>Switches to other frames (a recorded clip), from their start.</summary>
        public void SetFrames(IRigFrames rig) { _rig = rig; _last = null; _t0 = Time.realtimeSinceStartup; }
        public float Seconds => Time.realtimeSinceStartup - _t0;

        /// <summary>Called once if drawing fails, so the owner can show the creature's still instead.</summary>
        public System.Action<System.Exception> Failed;
        bool _failed, _reported;

        /// <summary>Draws the frame for time t now (CI screenshots call this outside play mode).</summary>
        public void RenderAt(float t)
        {
            if (_failed) return;
            try
            {
                var markup = _rig.FrameAt(t);
                if (markup == _last) return;
                _last = markup;
                int pad = (_rtSize - _size) / 2;
                var scene = SvgScene.Compile(SvgMarkup.Parse(markup), _size, _size, Affine.Translate(pad, pad));
                _renderer.Render(scene, _rt);
                if (!_reported)
                {
                    // one line to find this creature by, and to see what it drew
                    _reported = true;
                    Debug.Log($"[CreatureView] drawing live: texture {_rtSize}x{_rtSize} (MSAA {_rt.antiAliasing}), quad at {transform.position} size {_rtSize * _scaleK:0}, " +
                              $"{Count(scene.Root)} shapes/layers in frame 1, shaders ok: {Shader.Find("Hidden/SquishSquad/VectorCover") != null}");
                }
            }
            catch (System.Exception e)
            {
                _failed = true;
                Debug.LogError("[CreatureView] live drawing failed, showing the still instead: " + e);
                if (_mr != null) _mr.enabled = false;
                Failed?.Invoke(e);
            }
        }

        static int Count(LayerNode l) { int n = 0; foreach (var c in l.Children) n += c is LayerNode k ? 1 + Count(k) : 1; return n; }

        void LateUpdate()
        {
            if (_rig == null) return;
            RenderAt(FixedTime ?? (Time.realtimeSinceStartup - _t0));
        }

        void OnDestroy()
        {
            (_rig as System.IDisposable)?.Dispose();   // (a live creature leaves the engine)
            _renderer?.Dispose();
            if (_rt != null) { _rt.Release(); Kill(_rt); }
            Kill(_show);
            var mf = GetComponent<MeshFilter>();
            if (mf != null) Kill(mf.sharedMesh);
        }

        static void Kill(Object o) { if (o == null) return; if (Application.isPlaying) Destroy(o); else DestroyImmediate(o); }
    }
}
