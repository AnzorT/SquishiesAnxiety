// A live creature on screen: each frame its node tree (IRigTree: the native rig, no text) or its SVG (a recording)
// is compiled (SvgScene) and drawn on the GPU
// (VectorRenderer) into its own RenderTexture, shown on a quad. World units are screen pixels with y down as -y, like
// MenuView: the creature's box is `boxPx` (left, top, width, height) on the screen, and the quad covers it plus a
// margin of Margin x its size on each side (creatures draw outside their box: the app's SVG has overflow visible), and
// above it a margin of its own (Create's marginTop: Squish Hop's stage, whose hops stretch the rig up past the box).
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
        readonly Vec2Pool _pool = new Vec2Pool();
        float _t0;
        int _size, _rtW, _rtH, _padTop;
        float _scaleK = 1;
        const float Margin = 0.25f;

        /// <summary>The time used for the frame; by default seconds since Show.</summary>
        public float? FixedTime;

        // the views on screen, for NativeRig.FrameBegin: their frames are read before the clock's step, which then runs
        // on the rig thread while they're drawn (LateUpdate draws the frame read)
        internal static readonly System.Collections.Generic.List<CreatureView> Live = new System.Collections.Generic.List<CreatureView>();
        void OnEnable() { if (!Live.Contains(this)) Live.Add(this); }
        void OnDisable() => Live.Remove(this);
        SvgNode _pre;
        bool _hasPre;
        bool TreePath => _rig is IRigTree && !(_rig is ResultRig rr && !rr.Trees);

        /// <summary>Reads this frame's tree now, if LateUpdate is going to draw one (NativeRig.FrameBegin).</summary>
        internal void Prefetch()
        {
            _hasPre = false; _pre = null;
            if (_rig == null || _failed || !TreePath || !isActiveAndEnabled) return;
            if (_rig is IRigDirty dirty && !dirty.Dirty && _drawn) return;
            try { _pre = ((IRigTree)_rig).TreeAt(FixedTime ?? (Time.realtimeSinceStartup - _t0)); _hasPre = true; }
            catch (System.Exception) { /* RenderAt asks again, and reports it */ }
            if (_pre != null) Shapes(_pre);
        }

        // the frame's shapes, made on the shape threads (Vector/ShapeWorkers: plain C#, the tree is the view's own copy, its
        // point lists from the view's pool) while the rig steps and the other views make theirs; RenderAt waits for them
        readonly ShapeJob _shapes = new ShapeJob();
        void Shapes(SvgNode tree)
        {
            int pad = _pad, top = _padTop, size = _size;
            var pool = _pool;
            _shapes.Start(() => { using (Vec2Pool.Lend(pool)) return SvgScene.Compile(tree, size, size, Affine.Translate(pad, top)); });
        }

        /// <summary>`marginTop`: the room above the box (x its size; the sides and the bottom keep Margin).</summary>
        public static CreatureView Create(Transform parent, IRigFrames rig, Rect boxPx, int sortingOrder, float marginTop = Margin)
        {
            var go = new GameObject("creature (live)");
            go.transform.SetParent(parent, false);
            var v = go.AddComponent<CreatureView>();
            v.Init(rig, boxPx, sortingOrder, marginTop);
            return v;
        }

        void Init(IRigFrames rig, Rect boxPx, int order, float marginTop)
        {
            _rig = rig;
            _renderer = new VectorRenderer();
            var tile = Resources.Load<Texture2D>("Creatures/grain-tile");
            if (tile != null) _renderer.Images["grain"] = (tile, new Vector2(8, 8));   // a 128 px tile over the 1024 px pattern
            _size = Mathf.Max(16, Mathf.RoundToInt(boxPx.width));
            int pad = Mathf.RoundToInt(_size * Margin), padTop = Mathf.RoundToInt(_size * Mathf.Max(0, marginTop));
            _rtW = _size + 2 * pad; _rtH = _size + padTop + pad; _padTop = padTop;
            _rt = new RenderTexture(_rtW, _rtH, 24, RenderTextureFormat.ARGB32) { antiAliasing = 4, name = "creature", hideFlags = HideFlags.HideAndDontSave };
            _rt.Create();
            float k = boxPx.width / _size;   // screen px per texture px (1 on the reference screen)
            _scaleK = k;
            transform.localPosition = new Vector3(boxPx.x - pad * k, -(boxPx.y - padTop * k), 0);
            float w = _rtW * k, h = _rtH * k;
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

        /// <summary>The whole picture's opacity.</summary>
        public void SetOpacity(float o) { _opacity = o; if (_show != null) _show.SetFloat("_Opacity", Mathf.Clamp01(o)); if (_mr != null) _mr.forceRenderingOff = o <= 0; }

        /// <summary>Grey above a line `frac` of the box down from its top (2: all grey, negative: none): the result card's
        /// characters filling with colour from their feet up (tools/rig/result.html setFill).</summary>
        public void GreyAbove(float frac)
        {
            if (_show == null) return;
            float v = frac < 0 ? 2 : frac >= 1.5f ? -1 : 1 - (_padTop + frac * _size) / _rtH;
            _show.SetFloat("_GreyV", v);
        }

        /// <summary>A world point on the rig's 0-100 box (the box given to Create: x right, y down; what the rig's touch
        /// handlers read, CreatureTouch), through the creature's own transform (a walk's move, scale, turn). For a picture
        /// on its own quad (not Place()d).</summary>
        public Vector2 BoxPoint(Vector3 world)
        {
            var l = transform.InverseTransformPoint(world);
            float tx = l.x / _qk, ty = -l.y / _qk;   // (texture px, y down)
            return new Vector2((tx - _pad) / _size * 100f, (ty - _padTop) / _size * 100f);
        }

        /// <summary>Its sorting order (it draws among the UiPieces of a screen).</summary>
        public int Order { get => _mr != null ? _mr.sortingOrder : 0; set { if (_mr != null) _mr.sortingOrder = value; } }

        Mesh _mesh; float _qk, _clip = -1; int _pad;
        /// <summary>Cuts the picture off below a line `frac` of the box down from its top (the beach's wading: the
        /// page's clip-path inset(0 0 ins px 0)); a negative frac shows it all.</summary>
        public void ClipBottom(float frac)
        {
            if (_mesh == null || frac == _clip) return; _clip = frac;
            float w = _rtW * _qk, cut = frac < 0 ? _rtH : Mathf.Clamp(_padTop + frac * _size, 0, _rtH), h = cut * _qk, v = 1 - cut / (float)_rtH;
            _mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(w, 0, 0), new Vector3(w, -h, 0), new Vector3(0, -h, 0) });
            _mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, v), new Vector2(0, v) });
            _mesh.RecalculateBounds();
        }

        /// <summary>Puts the picture where `box` says: its box (0..the width given to Create, y down) onto the parent's dp
        /// (y down), any 2D transform (a squash under a tilt included), the quad cut to the band clipL ≤ x ≤ clipR (dp)
        /// when given (a rig stage's clip-path inset: Squish Sort's doors shutting).</summary>
        public void Place(Affine box, float pxPerDp, double clipL = double.NegativeInfinity, double clipR = double.PositiveInfinity)
        {
            if (_mesh == null) return;
            transform.localPosition = Vector3.zero; transform.localRotation = Quaternion.identity; transform.localScale = Vector3.one;
            double ax = -_pad * _qk, bx = (_rtW - _pad) * _qk, ay = -_padTop * _qk, by = (_rtH - _padTop) * _qk;
            _poly.Clear();
            void Corner(double x, double y, float u, float v) { var p = box.Apply(new Vec2(x, y)); _poly.Add((p.X, p.Y, u, v)); }
            Corner(ax, ay, 0, 1); Corner(bx, ay, 1, 1); Corner(bx, by, 1, 0); Corner(ax, by, 0, 0);
            if (!double.IsNegativeInfinity(clipL)) Cut(clipL, 1);
            if (!double.IsPositiveInfinity(clipR)) Cut(clipR, -1);
            _placed = true;
            if (_poly.Count < 3) { _mr.forceRenderingOff = true; return; }
            _pv.Clear(); _puv.Clear(); _pt.Clear();
            foreach (var (x, y, u, v) in _poly) { _pv.Add(new Vector3((float)(x * pxPerDp), (float)(-y * pxPerDp), 0)); _puv.Add(new Vector2(u, v)); }
            for (int i = 1; i + 1 < _poly.Count; i++) { _pt.Add(0); _pt.Add(i); _pt.Add(i + 1); }
            _mesh.Clear();
            _mesh.SetVertices(_pv); _mesh.SetUVs(0, _puv); _mesh.SetTriangles(_pt, 0);
            _mesh.RecalculateBounds();
            _mr.forceRenderingOff = _opacity <= 0;
        }
        readonly System.Collections.Generic.List<(double x, double y, float u, float v)> _poly = new System.Collections.Generic.List<(double, double, float, float)>(8), _cut = new System.Collections.Generic.List<(double, double, float, float)>(8);
        readonly System.Collections.Generic.List<Vector3> _pv = new System.Collections.Generic.List<Vector3>(8);
        readonly System.Collections.Generic.List<Vector2> _puv = new System.Collections.Generic.List<Vector2>(8);
        readonly System.Collections.Generic.List<int> _pt = new System.Collections.Generic.List<int>(18);
        bool _placed; float _opacity = 1;
        // the polygon kept on one side of the line x = at (side 1: x ≥ at, -1: x ≤ at), its uv carried along
        void Cut(double at, int side)
        {
            _cut.Clear();
            for (int i = 0; i < _poly.Count; i++)
            {
                var p = _poly[i]; var q = _poly[(i + 1) % _poly.Count];
                bool pin = side * (p.x - at) >= 0, qin = side * (q.x - at) >= 0;
                if (pin) _cut.Add(p);
                if (pin != qin)
                {
                    double t = (at - p.x) / (q.x - p.x);
                    _cut.Add((at, p.y + (q.y - p.y) * t, (float)(p.u + (q.u - p.u) * t), (float)(p.v + (q.v - p.v) * t)));
                }
            }
            _poly.Clear(); _poly.AddRange(_cut);
        }

        /// <summary>Switches to other frames (a recorded clip), from their start.</summary>
        public void SetFrames(IRigFrames rig) { _rig = rig; _last = null; _t0 = Time.realtimeSinceStartup; }
        public float Seconds => Time.realtimeSinceStartup - _t0;

        /// <summary>Called once if drawing fails, so the owner can show the creature's still instead.</summary>
        public System.Action<System.Exception> Failed;
        bool _failed, _reported, _drawn;

        /// <summary>Draws the frame for time t now (CI screenshots call this outside play mode).</summary>
        public void RenderAt(float t)
        {
            if (_failed) return;
            // (a rig stage's squishy that didn't draw since: the picture stays)
            if (_rig is IRigDirty dirty && !dirty.Dirty && _drawn) return;
            try
            {
                int pad = _pad, top = _padTop;
                SvgScene scene;
                // the native rig: its node tree straight from the rig (no text), the outlines' point lists lent by the
                // view's pool and taken back once drawn; a recording: its markup, parsed
                long t0 = SquishSquad.App.PerfLog.Mark();
                SvgNode tree;
                if (_hasPre) { tree = _pre; _hasPre = false; _pre = null; }
                else tree = TreePath ? ((IRigTree)_rig).TreeAt(t) : null;
                SquishSquad.App.PerfLog.Add("creature tree", t0);
                if (_shapes.Out)
                {
                    long t1 = SquishSquad.App.PerfLog.Mark();
                    scene = _shapes.Wait();
                    SquishSquad.App.PerfLog.Add("creature shapes wait", t1);
                    SquishSquad.App.PerfLog.AddMs("creature shapes (workers)", _shapes.Ms);
                    long t2 = SquishSquad.App.PerfLog.Mark();
                    _renderer.Render(scene, _rt);
                    _pool.Recycle();
                    SquishSquad.App.PerfLog.Add("creature GPU draw", t2);
                    _drawn = true;
                }
                else if (tree != null)
                {
                    long t1 = SquishSquad.App.PerfLog.Mark();
                    using (Vec2Pool.Lend(_pool)) { scene = SvgScene.Compile(tree, _size, _size, Affine.Translate(pad, top)); _renderer.Render(scene, _rt); }
                    _pool.Recycle();
                    SquishSquad.App.PerfLog.Add("creature draw", t1);
                    _drawn = true;
                }
                else
                {
                    var markup = _rig.FrameAt(t);
                    if (markup == _last) return;
                    _last = markup;
                    scene = SvgScene.Compile(SvgMarkup.Parse(markup), _size, _size, Affine.Translate(pad, top));
                    _renderer.Render(scene, _rt);
                }
                if (!_reported)
                {
                    // one line to find this creature by, and to see what it drew
                    _reported = true;
                    Debug.Log($"[CreatureView] drawing live: texture {_rtW}x{_rtH} (MSAA {_rt.antiAliasing}), quad at {transform.position} size {_rtW * _scaleK:0}x{_rtH * _scaleK:0}, " +
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
