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

        /// <summary>The part of the frame (x, y, w, h frame px) the room texture covers: the frame at camK 0.85.</summary>
        public static readonly double[] View = Region(0.85);
        static double[] Region(double k)
        {
            var a = HouseCamera.ToBox(0, 0, k); var b = HouseCamera.ToBox(852, 393, k);
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
        public sealed class Piece { public Mesh Quad; public double[] Region, Box; public double Z; public int Index, Toy; public string Kind, Id; public MeshRenderer Renderer; public double Dx, Dy; }
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
            if (Sim != null) { model.StateOf = Sim.RStOf; model.VarOf = Sim.VarOf; model.EditOn = Sim.Edit; model.ESel = Sim.ESel; }
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
            if (L.Night != null) Quad("night", Render(L.Night, new double[] { 0, 0, 852, 393 }, k), 852 * k, 393 * k, 30000);
        }

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
            var images = new Dictionary<string, Texture2D>();
            (int, int)? Size(string href)
            {
                if (!images.TryGetValue(href, out var t)) images[href] = t = Resources.Load<Texture2D>("House/pics/" + href);
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
            foreach (var t in images.Values) if (t != null) Resources.UnloadAsset(t);
            return tex;
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
            _quad.SetUVs(0, new[] { Uv(0, 0), Uv(852, 0), Uv(852, 393), Uv(0, 393) });
            // a piece's quad: its corners (frame px at camK 1) scaled by k about (426, 393), the box's (426, 343)
            Vector3 V(double gx, double gy) { double fx = 426 + k * (gx - 426), fy = 393 + k * (gy - 393); return new Vector3((float)(fx * _k), (float)(-fy * _k), 0); }
            foreach (var p in Pieces)
            {
                if (p.Quad == null) continue;
                double x = p.Region[0] + p.Dx, y = p.Region[1] + p.Dy, w = p.Region[2], h = p.Region[3];
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
