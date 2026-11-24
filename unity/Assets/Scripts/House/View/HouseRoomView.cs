// A room of the Squad House drawn from a save (HOUSE_PORT_PLAN.md stage 1: static, no creatures): the save loaded the
// way the page loads it (HouseSave), the room's values (RoomModel), the page's own room markup (HouseTemplate, from
// Resources/House/room-template.html), composed into one SVG (RoomCompose; pictures from Resources/House/pics as SVG
// text or PNG textures), <pattern> fills expanded (PatternExpand, until the vector renderer draws them), and drawn once
// by the GPU vector renderer into a texture shown on a quad.
//
// Framing: the 852 x 393 frame scaled to the screen's width, from the top-left (as the menu's .mm-house-in). The room
// is drawn once at camK 1 over everything the camera can show (View: the frame at the narrowest zoom, 0.85, plus the
// frame itself), and the camera (SetCamera: camK about (426, 343) of the box, House/HouseChrome.cs) only moves the
// quad's texture coordinates: the page scales the whole box, so it's the same picture. Placement follows MenuView's
// convention: page px, y down, World(p) = (x, -y).
using System;
using System.Collections.Generic;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseRoomView : MonoBehaviour
    {
        public int SortingOrder = 10;
        public int Msaa = 8;

        /// <summary>The part of the frame (x, y, w, h frame px) the room texture covers: the frame at camK 0.85 (with its
        /// margins past the 852 x 393 room on a taller or wider screen: HouseFrame.MX / MY).</summary>
        public static double[] View => Region(0.85);
        static double[] Region(double k)
        {
            var a = HouseCamera.ToBox(-HouseFrame.MX, -HouseFrame.MY, k); var b = HouseCamera.ToBox(852 + HouseFrame.MX, 393 + HouseFrame.MY, k);
            double x0 = Math.Floor(a.x), y0 = Math.Floor(a.y + HouseFrame.BoxTop), x1 = Math.Ceiling(b.x), y1 = Math.Ceiling(b.y + HouseFrame.BoxTop);
            return new[] { x0, y0, x1 - x0, y1 - y0 };
        }

        Mesh _quad;
        MeshRenderer _lastRenderer;
        float _k = 1;
        public double CamK { get; private set; } = 1;

        HouseData _data;
        HouseTemplate _tpl;
        readonly List<Object> _made = new List<Object>();
        public HouseSave Save { get; private set; }
        public List<string> Notes { get; } = new List<string>();

        public static string Res(string name) { var a = Resources.Load<TextAsset>("House/" + name); var s = a != null ? a.text : null; if (a != null) Resources.UnloadAsset(a); return s; }

        HouseData Data() => _data ??= HouseData.Load(Res);

        /// <summary>Loads a save (json: the house6 document's data, or null for a new house) for a player.</summary>
        public void Load(string json, int level, IList<int> ownedRosterIds, string room = "living", IList<string> ownedKeys = null)
        {
            Save = new HouseSave(Data());
            // the app's creature keys -> the house's roster ids
            if (ownedKeys != null) { var ids = new List<int>(ownedRosterIds ?? new List<int>()); foreach (var k in ownedKeys) { int i = Save.D.Roster.FindIndex(c => c.Str("key") == k); if (i >= 0 && !ids.Contains(i)) ids.Add(i); } ownedRosterIds = ids; }
            Save.Load(json, level, ownedRosterIds, room);
        }

        /// <summary>A piece of the room drawn on its own (a piece, its front part, a toy): its texture, where it is (frame
        /// px at camK 1) and its CSS z-index among the pieces and the creatures (House/View/HouseScreen sorts by it).</summary>
        public sealed class Piece { public Mesh Quad; public double[] Region, Box; public double Z; public int Index, Toy; public string Kind, Id; public MeshRenderer Renderer; public double Bx, By, Rot, Sx = 1, Sy = 1; public double Dx, Dy; }
        /// <summary>The squad (stage 4-5): the pieces' states its pictures show (rStOf, vars), front parts, drawing data.</summary>
        public HouseCreatures Sim;
        public readonly List<Piece> Pieces = new List<Piece>();
        /// <summary>The sorting order of a z-index among the pieces and creatures (the base room is below, the night over).</summary>
        public static int OrderOf(double z, int sub = 0) => 2000 + (int)Math.Round(z) * 4 + sub;

        /// <summary>Draws the current room (Save.Cur) at the menu's framing on a screen of width x height px: the room box
        /// unzoomed over View (the camera is SetCamera's), without its pieces; each piece, front part and toy as its own
        /// layer sorted by its z-index (the creatures go between them, as in the page's stacking box); over it all,
        /// unzoomed and frame-sized as in the page, the night overlay (a sibling of the box, not inside it).</summary>
        public void Draw(float width, float height)
        {
            Clear();
            _tpl ??= new HouseTemplate(Res("room-template"));
            var model = new RoomModel(Save);
            if (Sim != null) { model.StateOf = Sim.RStOf; model.VarOf = Sim.VarOf; model.EditOn = Sim.Edit; model.ESel = Sim.ESel; model.Season = Sim.SeasonNow(); }
            var vals = model.Build(Save.Cur);
            Notes.Clear(); Notes.AddRange(model.Missing);
            if (vals == null) return;
            RoomK = vals["camK"] is double ck ? ck : 1;
            if (Sim != null) { Sim.RnI = id => model.RnI.TryGetValue(id, out var ri) ? ri : null; }
            Fronts.Clear();
            foreach (var o in vals.Arr("items") ?? new List<object>()) if (o is JObj f && f.Str("id") != null) Fronts[f.Str("id")] = HouseJson.Truthy(f["hasFront"]);
            vals["camK"] = 1.0;   // (the camera is the quad's: SetCamera)
            var L = RoomLayers.Split(_tpl.Render(vals), View, () => new RoomCompose { PicSvg = n => HouseDraw.Pics.TryGetValue(n, out var rt) ? rt : Res("pics/" + n), PicPng = n => Resources.Load<Texture2D>("House/pics/" + n) != null ? n : null });
            float k = width / 852f;
            _k = k;
            Notes.AddRange(L.Notes);
            _quad = Quad("room", Render(L.Base, View, k), 852 * k, 393 * k, SortingOrder);
            for (int idx = 0; idx < L.Pieces.Count; idx++)
            {
                var lp = L.Pieces[idx];
                var q = Quad("piece " + idx, Render(lp.Svg, lp.Region, k), (float)(lp.Region[2] * k), (float)(lp.Region[3] * k), OrderOf(lp.Z, idx % 2));
                Pieces.Add(new Piece { Quad = q, Region = lp.Region, Box = lp.Box, Z = lp.Z, Index = idx, Toy = lp.Index, Kind = lp.Kind, Id = lp.Id, Renderer = _lastRenderer });
            }
            SetCamera(CamK);
            if (_itemsOp < 1) ItemsOpacity(_itemsOp);
            // (the night is the frame's: inset 0, a gradient over the whole frame, so stretched to it)
            if (L.Night != null)
            {
                var nq = Quad("night", Render(L.Night, new double[] { 0, 0, 852, 393 }, k), 852 * k, 393 * k, 30000);
                float x0 = (float)(-HouseFrame.MX * k), y0 = (float)(HouseFrame.MY * k), x1 = (float)((852 + HouseFrame.MX) * k), y1 = (float)(-(393 + HouseFrame.MY) * k);
                nq.SetVertices(new[] { new Vector3(x0, y0, 0), new Vector3(x1, y0, 0), new Vector3(x1, y1, 0), new Vector3(x0, y1, 0) }); nq.RecalculateBounds();
            }
        }

        /// <summary>The furniture layer's opacity (.sq-items: the pieces, toys and props over the bare room; the trip in fades
        /// it in, app/menu.js houseDrawn). Kept across redraws.</summary>
        public void ItemsOpacity(float a)
        {
            _itemsOp = a;
            foreach (var p in Pieces) if (p.Renderer != null) p.Renderer.sharedMaterial.SetFloat("_Opacity", a);
        }
        float _itemsOp = 1;

        /// <summary>The room's camK (renderVals: 0.85 indoors, 1 in the dance room, outdoors and on the beach).</summary>
        public double RoomK { get; private set; } = 1;
        /// <summary>Each piece's id: whether it has a front part drawn over its sitters (hasFr).</summary>
        public readonly Dictionary<string, bool> Fronts = new Dictionary<string, bool>();

        // an SVG layer (RoomLayers) drawn once by the GPU vector renderer, `view` (frame px) at k screen px per px
        RenderTexture Render(string svg, double[] view, float k)
        {
            var root = SvgMarkup.Parse(svg);
            PatternExpand.Expand(root);
            float vw = (float)view[2], vh = (float)view[3];
            int tw = Mathf.CeilToInt(vw * k), th = Mathf.CeilToInt(vh * k);
            var images = new Dictionary<string, Texture2D>(); var made = new HashSet<Texture2D>();
            (int, int)? Size(string href)
            {
                if (!images.TryGetValue(href, out var t))
                {
                    // the dance room's 3D floor: its picture drawn by HouseFlat from the floor's tile (RoomCompose)
                    if (href.StartsWith("flat:")) { t = FlatPicture(href); if (t != null) made.Add(t); }
                    else t = Resources.Load<Texture2D>("House/pics/" + href);
                    images[href] = t;
                }
                return t == null ? ((int, int)?)null : (t.width, t.height);
            }
            var scene = SvgScene.Compile(root, vw * k, vh * k, Affine.Identity, Size);
            var msaa = new RenderTexture(tw, th, 24, RenderTextureFormat.ARGB32) { antiAliasing = Msaa };
            msaa.Create();
            using (var vr = new VectorRenderer())
            {
                foreach (var kv in images) if (kv.Value != null) vr.Images[kv.Key] = (kv.Value, Vector2.one);
                vr.Render(scene, msaa);
            }
            var tex = new RenderTexture(tw, th, 0, RenderTextureFormat.ARGB32) { name = "house layer" };
            tex.Create();
            Graphics.Blit(msaa, tex);
            msaa.Release(); Destroy(msaa);
            _made.Add(tex);
            foreach (var t in images.Values) if (t != null && !made.Contains(t)) Resources.UnloadAsset(t);
            return tex;
        }

        // HouseFlat's picture of a 3D floor as a texture; its tiles read back from the GPU (they aren't imported readable)
        // (kept: the room is drawn again on every change of a piece, the floor's picture takes a moment to make)
        static string _flatKey; static Texture2D _flatTex;
        static Texture2D FlatPicture(string href)
        {
            if (href == _flatKey && _flatTex != null) return _flatTex;
            if (!HouseFlat.Specs.TryGetValue(href, out var spec)) return null;
            if (_flatTex != null) Destroy(_flatTex);
            var (w, h, rgba) = HouseFlat.Render(spec, url =>
            {
                var t = Resources.Load<Texture2D>("House/pics/" + url); if (t == null) return (0, 0, null);
                var rt = RenderTexture.GetTemporary(t.width, t.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
                Graphics.Blit(t, rt); var prev = RenderTexture.active; RenderTexture.active = rt;
                var r = new Texture2D(t.width, t.height, TextureFormat.RGBA32, false); r.ReadPixels(new Rect(0, 0, t.width, t.height), 0, 0); r.Apply();
                RenderTexture.active = prev; RenderTexture.ReleaseTemporary(rt);
                var px = r.GetPixels32(); int tw = t.width, th = t.height; var f = new float[tw * th * 4];
                for (int y = 0; y < th; y++) for (int x = 0; x < tw; x++) { var c = px[(th - 1 - y) * tw + x]; int i = (y * tw + x) * 4; f[i] = c.r / 255f; f[i + 1] = c.g / 255f; f[i + 2] = c.b / 255f; f[i + 3] = c.a / 255f; }
                Destroy(r); Resources.UnloadAsset(t);
                return (tw, th, f);
            });
            var o = new Texture2D(w, h, TextureFormat.RGBA32, false) { name = "flat floor", wrapMode = TextureWrapMode.Clamp };
            var cs = new Color32[w * h];
            for (int y = 0; y < h; y++) for (int x = 0; x < w; x++) { int i = (y * w + x) * 4; cs[(h - 1 - y) * w + x] = new Color32((byte)(rgba[i] * 255 + 0.5f), (byte)(rgba[i + 1] * 255 + 0.5f), (byte)(rgba[i + 2] * 255 + 0.5f), (byte)(rgba[i + 3] * 255 + 0.5f)); }
            o.SetPixels32(cs); o.Apply(false, true);
            _flatKey = href; _flatTex = o;
            return o;
        }

        // a quad covering the frame on screen (fw x fh px from the top-left, y down), showing `tex`
        Mesh Quad(string name, Texture tex, float fw, float fh, int order)
        {
            var go = new GameObject(name);
            go.transform.SetParent(transform, false);
            go.transform.localPosition = Vector3.zero;
            var mesh = new Mesh { name = name + " quad" };
            mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(fw, 0, 0), new Vector3(fw, -fh, 0), new Vector3(0, -fh, 0) });
            mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            _made.Add(mesh); _made.Add(go);
            go.AddComponent<MeshFilter>().sharedMesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            var mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = tex };
            _made.Add(mat);
            mr.sharedMaterial = mat;
            mr.sortingOrder = order;
            _lastRenderer = mr;
            return mesh;
        }

        /// <summary>A frame point (px, 852 x 393) in this view's local space (the frame isn't zoomed: UI over the room).</summary>
        public Vector3 WorldFrame(double fx, double fy) => new Vector3((float)(fx * _k), (float)(-fy * _k), 0);
        /// <summary>A room box point (px) where it is drawn now (the camera's zoom), in this view's local space.</summary>
        public Vector3 World(double bx, double by) { double k = CamK, fx = 426 + k * (bx - 426), fy = 393 + k * (by + HouseFrame.BoxTop - 393); return new Vector3((float)(fx * _k), (float)(-fy * _k), 0); }

        /// <summary>The camera's scale (camK): the frame shows the room box scaled by k about (426, 343) of the box.</summary>
        public void SetCamera(double k)
        {
            CamK = k;
            if (_quad == null) return;
            // a frame corner -> the box at k -> the same point of the unzoomed frame (the texture's) -> its uv
            Vector2 Uv(double fx, double fy)
            {
                var b = HouseCamera.ToBox(fx, fy, k);
                double gx = b.x, gy = b.y + HouseFrame.BoxTop;
                return new Vector2((float)((gx - View[0]) / View[2]), (float)(1 - (gy - View[1]) / View[3]));
            }
            // (the whole frame: the room's picture reaches past the 852 x 393 room, more floor and ceiling show)
            double fx0 = -HouseFrame.MX, fy0 = -HouseFrame.MY, fx1 = 852 + HouseFrame.MX, fy1 = 393 + HouseFrame.MY;
            Vector3 F(double fx, double fy) => new Vector3((float)(fx * _k), (float)(-fy * _k), 0);
            _quad.SetVertices(new[] { F(fx0, fy0), F(fx1, fy0), F(fx1, fy1), F(fx0, fy1) }); _quad.RecalculateBounds();
            _quad.SetUVs(0, new[] { Uv(fx0, fy0), Uv(fx1, fy0), Uv(fx1, fy1), Uv(fx0, fy1) });
            // a piece's quad: its corners (frame px at camK 1) scaled by k about (426, 393), the box's (426, 343)
            Vector3 V(double gx, double gy) { double fx = 426 + k * (gx - 426), fy = 393 + k * (gy - 393); return new Vector3((float)(fx * _k), (float)(-fy * _k), 0); }
            foreach (var p in Pieces)
            {
                if (p.Quad == null) continue;
                double x = p.Region[0] + p.Dx, y = p.Region[1] + p.Dy, w = p.Region[2], h = p.Region[3];
                if (p.Rot != 0 || p.Sx != 1 || p.Sy != 1 || p.Bx != 0 || p.By != 0)
                {
                    // a bounce (the speakers on the beat): translate, rotate, scale about the piece's bottom centre
                    var B = p.Box ?? p.Region; double ox = B[0] + B[2] / 2 + p.Dx, oy = B[1] + B[3] + p.Dy, a = p.Rot * Math.PI / 180, ca = Math.Cos(a), sa = Math.Sin(a);
                    Vector3 T(double gx, double gy) { double u = (gx - ox) * p.Sx, v = (gy - oy) * p.Sy; return V(ox + p.Bx + u * ca - v * sa, oy + p.By + u * sa + v * ca); }
                    p.Quad.SetVertices(new[] { T(x, y), T(x + w, y), T(x + w, y + h), T(x, y + h) });
                    p.Quad.RecalculateBounds(); continue;
                }
                p.Quad.SetVertices(new[] { V(x, y), V(x + w, y), V(x + w, y + h), V(x, y + h) });
                p.Quad.RecalculateBounds();
            }
        }

        void Clear()
        {
            Pieces.Clear();
            foreach (var o in _made) if (o != null) { if (o is RenderTexture rt) rt.Release(); Destroy(o); }
            _made.Clear();
        }

        void OnDestroy() => Clear();
    }
}
