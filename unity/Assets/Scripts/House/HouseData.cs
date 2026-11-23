// The house's exported tables (tools/unity/house/export-house.mjs -> Resources/House): the renovation catalog, the
// piece table (what rnReg registers for each piece), rooms, slots, defaults, the roster order, and the drawings the
// rooms use (RenoDraw variants, house4 renders, room shells, renovated surfaces). Plain C#: the caller hands in the
// files' text (Unity: Resources.Load<TextAsset>("House/<name>").text).
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class HouseData
    {
        public readonly List<JObj> Rows = new List<JObj>();
        public readonly Dictionary<string, JObj> ById = new Dictionary<string, JObj>();
        public JObj Cat, Pieces, Rooms, Def, Surf, Consts, Legacy;
        public List<string> RKeys = new List<string>(), SlotsIn = new List<string>(), SlotsOut = new List<string>();
        public HashSet<string> WinIr = new HashSet<string>();
        public List<JObj> Roster = new List<JObj>();
        public List<JObj> Bands = new List<JObj>();
        // drawings (only what's been exported: the fixtures' rooms for now)
        public List<object> Foods = new List<object>();
        public JObj Gls = new JObj(), Variants = new JObj(), Renders = new JObj(), Grads = new JObj(), Pics = new JObj(), Shells = new JObj(), Tex = new JObj();
        public double FS, SA, CA, VW, FY0, FY1;

        /// <summary>load(name) returns the text of Resources/House/&lt;name&gt;.json (or null when it isn't there).</summary>
        public static HouseData Load(Func<string, string> load)
        {
            var d = new HouseData();
            foreach (var r in (List<object>)HouseJson.Parse(load("catalog"))) { var o = (JObj)r; d.Rows.Add(o); d.ById[o.Str("id")] = o; }
            d.Cat = (JObj)HouseJson.Parse(load("house-cat"));
            d.Pieces = d.Cat.Obj("pieces"); d.Rooms = d.Cat.Obj("rooms"); d.Def = d.Cat.Obj("def"); d.Surf = d.Cat.Obj("surf"); d.Consts = d.Cat.Obj("consts"); d.Legacy = d.Cat.Obj("legacy") ?? new JObj();
            foreach (var k in d.Cat.Arr("rkeys")) d.RKeys.Add((string)k);
            foreach (var k in d.Cat.Arr("slotsIn")) d.SlotsIn.Add((string)k);
            foreach (var k in d.Cat.Arr("slotsOut")) d.SlotsOut.Add((string)k);
            foreach (var k in d.Cat.Arr("winIr")) d.WinIr.Add((string)k);
            foreach (var k in d.Cat.Arr("roster")) d.Roster.Add((JObj)k);
            foreach (var k in d.Cat.Arr("bands")) d.Bands.Add((JObj)k);
            d.FS = d.Consts.Num("FS"); d.SA = d.Consts.Num("SA"); d.CA = d.Consts.Num("CA"); d.VW = d.Consts.Num("VW"); d.FY0 = d.Consts.Num("FY0"); d.FY1 = d.Consts.Num("FY1");
            var p = load("house-pieces");
            if (p != null) { var o = (JObj)HouseJson.Parse(p); d.Variants = o.Obj("variants"); d.Renders = o.Obj("renders"); d.Grads = o.Obj("grads"); d.Pics = o.Obj("pics"); d.Gls = o.Obj("gls") ?? new JObj(); d.Foods = o.Arr("foods") ?? new List<object>(); }
            var s = load("shells"); if (s != null) d.Shells = (JObj)HouseJson.Parse(s);
            var t = load("tex"); if (t != null) d.Tex = (JObj)HouseJson.Parse(t);
            var e = load("edit"); if (e != null) d.Edit = (JObj)HouseJson.Parse(e);
            return d;
        }

        public JObj Room(string rk) => Rooms.Obj(rk);
        public JObj Row(string id) => id != null && ById.TryGetValue(id, out var r) ? r : null;
        /// <summary>X.CAT[t]: a renovation piece ('R:&lt;id&gt;') as rnReg registered it, or a legacy house4 piece.</summary>
        public JObj CatOf(string t) => t == null ? null : Pieces.Obj(t) ?? Legacy.Obj(t);
        // Renovate's tables (stage 6, edit.json): RMAP, the short names, the surfaces' names, the lights SPEC knows, the
        // rows' toolbox tabs (rnSlot), the edit UI's pieces
        public JObj Edit = new JObj();
        public string RMap(string code) => Edit.Obj("rmap")?.Str(code);
        /// <summary>SN: a row's short name (RenoShort), else its name.</summary>
        public string ShortName(JObj r) => r == null ? "" : Edit.Obj("short")?.Str(r.Str("id")) ?? r.Str("name") ?? "";
        public string SurfName(string id) => Edit.Obj("surfN")?.Str(id);
        public bool Spec(string id) => Edit.Arr("spec")?.Contains(id) == true;
        public string SlotOf(JObj r) => r == null ? null : Edit.Obj("slot")?.Str(r.Str("id"));

        public List<string> SlotsOf(string rk) => Room(rk).Truthy("out") ? SlotsOut : SlotsIn;
    }
}
