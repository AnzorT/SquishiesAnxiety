// A room of the Squad House drawn from a save (HOUSE_PORT_PLAN.md stage 1: static, no creatures): the save loaded the
// way the page loads it (HouseSave), the room's values (RoomModel), the page's own room markup (HouseTemplate, from
// Resources/House/room-template.html), composed into one SVG (RoomCompose; pictures from Resources/House/pics as SVG
// text or PNG textures), <pattern> fills expanded (PatternExpand, until the vector renderer draws them), and drawn once
// by the GPU vector renderer into a texture shown on a quad.
//
// Framing: the menu's (Main Menu.dc.html .mm-house-in): the 852 x 393 house box scaled to the screen's width, from the
// top-left. Placement follows MenuView's convention: page px, y down, World(p) = (x, -y).
using System.Collections.Generic;
using SquishSquad.Vector;
using SquishSquad.Vector.Gpu;
using UnityEngine;

namespace SquishSquad.House.View
{
    public sealed class HouseRoomView : MonoBehaviour
    {
        public int SortingOrder = 10;
        public int Msaa = 8;

        HouseData _data;
        HouseTemplate _tpl;
        RenderTexture _tex;
        readonly List<Object> _made = new List<Object>();
        public HouseSave Save { get; private set; }
        public List<string> Notes { get; } = new List<string>();

        public static string Res(string name) { var a = Resources.Load<TextAsset>("House/" + name); var s = a != null ? a.text : null; if (a != null) Resources.UnloadAsset(a); return s; }

        HouseData Data() => _data ??= HouseData.Load(Res);

        /// <summary>Loads a save (json: the house6 document's data, or null for a new house) for a player.</summary>
        public void Load(string json, int level, IList<int> ownedRosterIds, string room = "living")
        {
            Save = new HouseSave(Data());
            Save.Load(json, level, ownedRosterIds, room);
        }

        /// <summary>Draws the current room (Save.Cur) at the menu's framing on a screen of width x height px.</summary>
        public void Draw(float width, float height)
        {
            Clear();
            _tpl ??= new HouseTemplate(Res("room-template"));
            var model = new RoomModel(Save);
            var vals = model.Build(Save.Cur);
            Notes.Clear(); Notes.AddRange(model.Missing);
            if (vals == null) return;
            var compose = new RoomCompose { PicSvg = n => Res("pics/" + n), PicPng = n => Resources.Load<Texture2D>("House/pics/" + n) != null ? n : null };
            var svg = compose.Compose(_tpl.Render(vals), null);
            Notes.AddRange(compose.Notes);
            var root = SvgMarkup.Parse(svg);
            PatternExpand.Expand(root);
            float k = width / 852f;
            int tw = Mathf.CeilToInt(852 * k), th = Mathf.CeilToInt(393 * k);
            var images = new Dictionary<string, Texture2D>();
            (int, int)? Size(string href)
            {
                if (!images.TryGetValue(href, out var t)) images[href] = t = Resources.Load<Texture2D>("House/pics/" + href);
                return t == null ? ((int, int)?)null : (t.width, t.height);
            }
            var scene = SvgScene.Compile(root, 852 * k, 393 * k, Affine.Identity, Size);
            var msaa = new RenderTexture(tw, th, 24, RenderTextureFormat.ARGB32) { antiAliasing = Msaa };
            msaa.Create();
            using (var vr = new VectorRenderer())
            {
                foreach (var kv in images) if (kv.Value != null) vr.Images[kv.Key] = (kv.Value, Vector2.one);
                vr.Render(scene, msaa);
            }
            _tex = new RenderTexture(tw, th, 0, RenderTextureFormat.ARGB32) { name = "house room" };
            _tex.Create();
            Graphics.Blit(msaa, _tex);
            msaa.Release(); Destroy(msaa);
            _made.Add(_tex);
            var go = new GameObject("room");
            go.transform.SetParent(transform, false);
            go.transform.localPosition = Vector3.zero;
            var mesh = new Mesh { name = "room quad" };
            mesh.SetVertices(new[] { new Vector3(0, 0, 0), new Vector3(tw, 0, 0), new Vector3(tw, -th, 0), new Vector3(0, -th, 0) });
            mesh.SetUVs(0, new[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) });
            mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0);
            _made.Add(mesh); _made.Add(go);
            go.AddComponent<MeshFilter>().sharedMesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            var mat = new Material(Resources.Load<Shader>("VectorShaders/VectorShow")) { mainTexture = _tex };
            _made.Add(mat);
            mr.sharedMaterial = mat;
            mr.sortingOrder = SortingOrder;
            foreach (var t in images.Values) if (t != null) Resources.UnloadAsset(t);
        }

        void Clear()
        {
            foreach (var o in _made) if (o != null) { if (o is RenderTexture rt) rt.Release(); Destroy(o); }
            _made.Clear();
        }

        void OnDestroy() => Clear();
    }
}
