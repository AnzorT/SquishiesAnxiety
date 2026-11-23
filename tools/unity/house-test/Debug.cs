using System.IO;
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

static class CameraLayers
{
    // `camera <fixture> <room>`: the room as HouseRoomView draws it (stage 2): the box at camK 1 over the region the
    // 0.85 zoom shows, and the night overlay on its own over the frame; tools/unity/house/camera-check.mjs zooms the
    // first, lays the second over it and compares with the page's screenshot (out/<fx>-<room>-<day|night>-{room,night,plain}.svg)
    public static int Run(string fx, string rk)
    {
        var d = Program.Data(); var tpl = Program.Template();
        var a = HouseCamera.ToBox(0, 0, 0.85); var b = HouseCamera.ToBox(852, 393, 0.85);
        double x0 = Math.Floor(a.x), y0 = Math.Floor(a.y + HouseFrame.BoxTop), x1 = Math.Ceiling(b.x), y1 = Math.Ceiling(b.y + HouseFrame.BoxTop);
        var view = new[] { x0, y0, x1 - x0, y1 - y0 };
        foreach (var r in Program.Rooms(d, fx))
        {
            if (r.rk != rk) continue;
            string name = r.fx + "-" + r.rk + (r.night ? "-night" : "-day");
            var plain = Program.Composer(d).Compose(tpl.Render(r.vals), null);   // stage 1: camK in the markup
            double k = r.vals["camK"] is double kk ? kk : 1;
            r.vals["camK"] = 1.0;
            var dom = tpl.Render(r.vals);
            var night = dom.FindAll(n => n.Tag == "div" && (n["style"] ?? "").Contains("z-index:860"));
            var room = dom.FindAll(n => !night.Contains(n));
            string Out(string s) => Path.Combine(Program.Repo, "tools/unity/house-test/out", name + "-" + s + ".svg");
            Directory.CreateDirectory(Path.GetDirectoryName(Out("x")));
            File.WriteAllText(Out("plain"), plain);
            File.WriteAllText(Out("room"), Program.Composer(d).Compose(room, null, view));
            File.WriteAllText(Out("night"), Program.Composer(d).Compose(night, null, null, false));
            File.WriteAllText(Out("meta").Replace(".svg", ".json"), $"{{\"k\":{k.ToString(System.Globalization.CultureInfo.InvariantCulture)},\"view\":[{string.Join(",", view)}],\"nightOn\":{(night.Count > 0 ? "true" : "false")}}}");
            Console.WriteLine($"{name}: camK {k}, view [{string.Join(", ", view)}], night layer {night.Count}");
        }
        return 0;
    }
}
