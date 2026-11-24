// The Game Park's games carousel on screen: ParkModel says what to draw where (the app's showGames, its layout and
// every motion), this puts it there. Pictures are quads with the ParkPiece shader; each card is drawn into its own
// layer first (a RenderTexture, as CSS composites a card with its opacity and filter as one), then shown with the
// card's transform, opacity and brightness. The middle card plays its game's clip (VideoPlayer, from
// StreamingAssets/Park) over its first frame once a frame has arrived, as the app's <video> does over its poster.
// Pure placement and drawing: MenuView ticks it, MenuScreen hands it the taps.
using System;
using System.Collections.Generic;
using System.IO;
using SquishSquad.Vector;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

namespace SquishSquad.Menu
{
    public sealed class ParkCarousel : IDisposable
    {
        /// <summary>The game last chosen (webgame/app/menu.js keeps it in localStorage under the same key).</summary>
        public const string LastGameKey = "squishsquad.park.v1";

        public readonly ParkModel Model;
        readonly ParkLayout _layout;
        readonly Transform _root;
        readonly int _order;
        readonly Material _mat;
        readonly Dictionary<string, Texture2D> _tex = new Dictionary<string, Texture2D>();
        readonly Dictionary<string, Quad> _quads = new Dictionary<string, Quad>();
        readonly Dictionary<string, Mesh> _layerMeshes = new Dictionary<string, Mesh>();
        readonly Dictionary<string, RenderTexture> _layers = new Dictionary<string, RenderTexture>();
        readonly Dictionary<int, Clip> _clips = new Dictionary<int, Clip>();
        readonly CommandBuffer _cb = new CommandBuffer { name = "SquishSquad.Park" };
        bool _disposed;   // (Dispose runs once; a Tick after it does nothing: its command buffer is released)
        readonly MaterialPropertyBlock _props = new MaterialPropertyBlock();
        static readonly int PxToClip = Shader.PropertyToID("_ParkPxToClip");

        public static ParkLayout LoadLayout()
        {
            var text = Resources.Load<TextAsset>(ParkLayout.Root + "park");
            if (text == null) return null;   // not exported: tools/unity/export-park.mjs
            var l = JsonUtility.FromJson<ParkLayout>(text.text);
            Resources.UnloadAsset(text);
            return l;
        }

        /// <param name="startId">the game in the middle (null: the one last chosen)</param>
        public ParkCarousel(ParkLayout layout, Transform parent, float w, float h, double now, bool instant, string startId, int order)
        {
            _layout = layout;
            _order = order;
            _root = new GameObject("Park carousel").transform;
            _root.SetParent(parent, false);
            _mat = new Material(Resources.Load<Shader>("MenuShaders/ParkPiece")) { hideFlags = HideFlags.HideAndDontSave };
            var id = startId ?? PlayerPrefs.GetString(LastGameKey, "");
            int cur = Math.Max(0, Array.FindIndex(layout.games, g => g.id == id));
            Model = new ParkModel(layout, w, h, cur, now, instant) { OnSelect = i => Remember(i) };
        }

        public void Remember(int i)
        {
            PlayerPrefs.SetString(LastGameKey, _layout.games[i].id);
            PlayerPrefs.Save();
        }

        public ParkLayout.Game Game(int i) => _layout.games[i];

        public void Tick(double now)
        {
            if (_disposed) return;
            var draws = Model.Draws(now);
            var used = new HashSet<string>();
            var usedClips = new HashSet<int>();
            for (int i = 0; i < draws.Count; i++)
            {
                var d = draws[i];
                used.Add(d.Key);
                Texture tex; bool straight = true, opaque = false;
                if (d.Res == "card") { tex = Layer(d, usedClips); straight = false; }
                else tex = Picture(d.Res);
                var q = QuadFor(d.Key);
                q.Show(d, tex, straight, opaque, d.Mask != null ? Picture(d.Mask) : null, _order + i, _props);
            }
            foreach (var kv in _quads) if (!used.Contains(kv.Key)) kv.Value.Hide();
            // (a card off the middle is invisible at rest: its layer goes until it's drawn again)
            var idle = new List<string>();
            foreach (var kv in _layers) if (!used.Contains(kv.Key)) idle.Add(kv.Key);
            foreach (var k in idle) { _layers[k].Release(); Kill(_layers[k]); _layers.Remove(k); }
            var stale = new List<int>();
            foreach (var kv in _clips) if (!usedClips.Contains(kv.Key)) stale.Add(kv.Key);
            foreach (var i in stale) { _clips[i].Dispose(); _clips.Remove(i); }
        }

        // a card's layer: its pieces drawn into its own picture (its px: y down, top-left 0, 0)
        RenderTexture Layer(ParkModel.Draw g, HashSet<int> usedClips)
        {
            if (!_layers.TryGetValue(g.Key, out var rt) || rt.width != g.W || rt.height != g.H)
            {
                if (rt != null) { rt.Release(); Kill(rt); }
                rt = new RenderTexture(g.W, g.H, 0, RenderTextureFormat.ARGB32) { name = g.Key, hideFlags = HideFlags.HideAndDontSave, filterMode = FilterMode.Bilinear, wrapMode = TextureWrapMode.Clamp };
                rt.Create();
                _layers[g.Key] = rt;
            }
            _cb.Clear();
            _cb.SetRenderTarget(rt);
            _cb.ClearRenderTarget(false, true, Color.clear);
            _cb.SetGlobalMatrix(PxToClip, GL.GetGPUProjectionMatrix(Matrix4x4.Ortho(0, g.W, g.H, 0, -1, 1), true));
            foreach (var c in g.Children)
            {
                Texture tex; bool straight = true, opaque = false;
                if (c.Res.StartsWith("clip:"))
                {
                    int ci = int.Parse(c.Res.Substring(5));
                    usedClips.Add(ci);
                    var clip = ClipFor(ci);
                    if (clip == null || !clip.HasFrame) continue;   // the first frame (in the card) until the clip plays
                    tex = clip.Target; opaque = true;
                }
                else tex = Picture(c.Res);
                if (tex == null) continue;
                var mesh = LayerMesh(c.Key);
                Fill(mesh, c, false);
                var p = new MaterialPropertyBlock();
                Props(p, c, tex, straight, opaque, c.Mask != null ? Picture(c.Mask) : null, true);
                _cb.DrawMesh(mesh, Matrix4x4.identity, _mat, 0, 0, p);
            }
            Graphics.ExecuteCommandBuffer(_cb);
            return rt;
        }

        Mesh LayerMesh(string key)
        {
            if (_layerMeshes.TryGetValue(key, out var m)) return m;
            m = NewMesh(key);
            _layerMeshes[key] = m;
            return m;
        }

        static Mesh NewMesh(string name)
        {
            var m = new Mesh { name = name, hideFlags = HideFlags.HideAndDontSave };
            m.MarkDynamic();
            m.SetVertices(new Vector3[4]);
            m.SetUVs(0, new Vector2[4]);
            m.SetUVs(1, new Vector2[4]);
            m.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            return m;
        }

        static readonly Vector3[] V = new Vector3[4];
        static readonly Vector2[] Uv = new Vector2[4], Uv2 = new Vector2[4];

        // the draw's quad: its part of the picture mapped by M; `scene`: world units (y up), else the layer's px (y down)
        static void Fill(Mesh mesh, ParkModel.Draw d, bool scene)
        {
            double x0 = d.U0 * d.W, x1 = d.U1 * d.W, y0 = d.V0 * d.H, y1 = d.V1 * d.H;
            var pts = new[] { new Vec2(x0, y0), new Vec2(x1, y0), new Vec2(x1, y1), new Vec2(x0, y1) };
            var uvs = new[] { new Vector2((float)d.U0, 1 - (float)d.V0), new Vector2((float)d.U1, 1 - (float)d.V0), new Vector2((float)d.U1, 1 - (float)d.V1), new Vector2((float)d.U0, 1 - (float)d.V1) };
            var inv = d.Mask != null ? d.MaskM.Inverse() : Affine.Identity;
            for (int k = 0; k < 4; k++)
            {
                var s = d.M.Apply(pts[k]);
                V[k] = new Vector3((float)s.X, scene ? -(float)s.Y : (float)s.Y, 0);
                Uv[k] = uvs[k];
                if (d.Mask != null) { var mp = inv.Apply(s); Uv2[k] = new Vector2((float)(mp.X / d.MaskW), 1 - (float)(mp.Y / d.MaskH)); }
                else Uv2[k] = Vector2.zero;
            }
            mesh.SetVertices(V);
            mesh.SetUVs(0, Uv);
            mesh.SetUVs(1, Uv2);
            mesh.RecalculateBounds();
        }

        static void Props(MaterialPropertyBlock p, ParkModel.Draw d, Texture tex, bool straight, bool opaque, Texture mask, bool intoRt)
        {
            p.SetTexture("_MainTex", tex != null ? tex : Texture2D.blackTexture);
            p.SetTexture("_Mask", mask != null ? mask : Texture2D.whiteTexture);
            p.SetFloat("_Opacity", Mathf.Clamp01((float)d.Opacity));
            p.SetFloat("_Bright", (float)d.Bright);
            p.SetFloat("_Straight", straight ? 1 : 0);
            p.SetFloat("_Opaque", opaque ? 1 : 0);
            p.SetFloat("_UseMask", mask != null ? 1 : 0);
            p.SetFloat("_IntoRt", intoRt ? 1 : 0);
        }

        Quad QuadFor(string key)
        {
            if (_quads.TryGetValue(key, out var q)) return q;
            q = new Quad(_root, key, _mat);
            _quads[key] = q;
            return q;
        }

        Texture2D Picture(string res)
        {
            if (res == null) return null;
            if (_tex.TryGetValue(res, out var t)) return t;
            t = Resources.Load<Texture2D>(ParkLayout.Root + res);
            if (t == null) Debug.LogWarning("[Park] missing picture Resources/" + ParkLayout.Root + res);
            _tex[res] = t;
            return t;
        }

        Clip ClipFor(int card)
        {
            if (!Application.isPlaying) return null;   // (CI screenshots: the first frame, as the reference)
            if (_clips.TryGetValue(card, out var c)) return c;
            var info = _layout.cards[card].clip;
            if (info == null || string.IsNullOrEmpty(info.file)) return null;
            c = new Clip(_root, Path.Combine(Application.streamingAssetsPath, info.file), info.size[0], info.size[1]);
            _clips[card] = c;
            return c;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            foreach (var c in _clips.Values) c.Dispose();
            _clips.Clear();
            foreach (var q in _quads.Values) q.Dispose();
            _quads.Clear();
            foreach (var m in _layerMeshes.Values) Kill(m);
            _layerMeshes.Clear();
            foreach (var rt in _layers.Values) if (rt != null) { rt.Release(); Kill(rt); }
            _layers.Clear();
            foreach (var t in _tex.Values) if (t != null) Resources.UnloadAsset(t);
            _tex.Clear();
            _cb.Release();
            Kill(_mat);
            if (_root != null) Kill(_root.gameObject);
        }

        static void Kill(UnityEngine.Object o)
        {
            if (o == null) return;
            if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o);
        }

        // ---- a quad in the scene ---------------------------------------------------------------------------------
        sealed class Quad : IDisposable
        {
            readonly GameObject _go;
            readonly MeshRenderer _mr;
            readonly Mesh _mesh;

            public Quad(Transform parent, string name, Material mat)
            {
                _go = new GameObject(name);
                _go.transform.SetParent(parent, false);
                _mesh = NewMesh(name);
                _go.AddComponent<MeshFilter>().sharedMesh = _mesh;
                _mr = _go.AddComponent<MeshRenderer>();
                _mr.sharedMaterial = mat;
            }

            public void Show(ParkModel.Draw d, Texture tex, bool straight, bool opaque, Texture mask, int order, MaterialPropertyBlock p)
            {
                Fill(_mesh, d, true);
                p.Clear();
                Props(p, d, tex, straight, opaque, mask, false);
                _mr.SetPropertyBlock(p);
                _mr.sortingOrder = order;
                _mr.enabled = tex != null && d.Opacity > 0;
            }

            public void Hide() => _mr.enabled = false;

            public void Dispose()
            {
                Kill(_mesh);
                Kill(_go);
            }
        }

        // ---- a game's clip -----------------------------------------------------------------------------------------
        sealed class Clip : IDisposable
        {
            readonly GameObject _go;
            readonly VideoPlayer _vp;
            public readonly RenderTexture Target;
            public bool HasFrame { get; private set; }

            public Clip(Transform parent, string url, int w, int h)
            {
                Target = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32) { name = "clip", hideFlags = HideFlags.HideAndDontSave };
                Target.Create();
                _go = new GameObject("clip");
                _go.transform.SetParent(parent, false);
                _vp = _go.AddComponent<VideoPlayer>();
                _vp.playOnAwake = false;
                _vp.source = VideoSource.Url;
                _vp.url = url;
                _vp.renderMode = VideoRenderMode.RenderTexture;
                _vp.targetTexture = Target;
                _vp.isLooping = true;
                _vp.audioOutputMode = VideoAudioOutputMode.None;   // (muted, as the app's)
                _vp.skipOnDrop = true;
                _vp.waitForFirstFrame = true;
                _vp.sendFrameReadyEvents = true;
                _vp.frameReady += OnFrame;
                _vp.errorReceived += (src, msg) => Debug.LogWarning("[Park] clip " + url + ": " + msg);
                _vp.prepareCompleted += src => src.Play();
                _vp.Prepare();
            }

            void OnFrame(VideoPlayer src, long frame)
            {
                HasFrame = true;
                src.sendFrameReadyEvents = false;   // (one is enough: it costs a CPU sync per frame)
                src.frameReady -= OnFrame;
            }

            public void Dispose()
            {
                if (_vp != null) { _vp.Stop(); }
                Kill(_go);
                if (Target != null) { Target.Release(); Kill(Target); }
            }
        }
    }
}
