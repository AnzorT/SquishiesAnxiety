using System;
using System.Linq;
using SquishSquad.House;
static partial class Program
{
    static int DebugRt(string fx, string rk)
    {
        var d = Data();
        foreach (var r in Rooms(d, fx)) if (r.rk == rk) { Console.WriteLine(HouseJson.Stringify(r.vals.Obj("rt"))); break; }
        return 0;
    }
}
static partial class Program
{
    static int ComposeOnly(string fx, string rk)
    {
        var d = Data(); var tpl = Template();
        foreach (var r in Rooms(d, fx == "all" ? null : fx))
        {
            if (rk != "all" && (r.rk != rk || r.night)) continue;
            var c = Composer(d); var svg = c.Compose(tpl.Render(r.vals), null);
            var root = SquishSquad.Vector.SvgMarkup.Parse(svg);
            PatternExpand.Expanded = PatternExpand.Tiles = 0; PatternExpand.Expand(root);
            int Count(SquishSquad.Vector.SvgNode n) { int k = 1; foreach (var x in n.Children) k += Count(x); return k; }
            Console.WriteLine($"{r.fx} {r.rk} {(r.night ? "night" : "day")}: svg {svg.Length / 1024} KB, {Count(root)} nodes after expand, {PatternExpand.Expanded} fills, {PatternExpand.Tiles} tiles, capped {PatternExpand.Capped}");
            System.IO.File.WriteAllText(System.IO.Path.Combine(Repo, "tools/unity/house-test/out", r.fx + "-" + r.rk + (rk == "all" ? (r.night ? "-night" : "-day") : "") + ".svg"), svg);
        }
        return 0;
    }
}
