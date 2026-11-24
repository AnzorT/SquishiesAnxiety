// `map`: the house map's picture (House/HouseMap.cs: the page's template filled with mapVals from the draw host) against
// the page's own, for each fixture export-map.mjs drew (tools/unity/house-test/out/map-<fixture>.json): the markup
// compared element by element (tags, attributes, text; style attributes and whitespace aside).
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SquishSquad.House;

static class MapCheck
{
    static string Norm(string s)
    {
        s = Regex.Replace(s, "\\s(style|data-[a-z-]+|ref|xmlns(:\\w+)?)=\"[^\"]*\"", "");
        s = Regex.Replace(s, "<(\\w+)([^<>]*?)>\\s*</\\1>", "<$1$2/>");
        s = Regex.Replace(s, ">\\s+<", "><").Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&gt;", ">");
        s = Regex.Replace(s, "\\s+/>", "/>");
        return Regex.Replace(s, "\\s+", " ").Trim();
    }

    public static int Run()
    {
        DrawServer.Start();
        var tpl = File.ReadAllText(Path.Combine(Program.Res, "map-template.html"));
        int bad = 0;
        foreach (var f in Directory.GetFiles(Path.Combine(Program.Repo, "tools/unity/house-test/out"), "map-*.json").OrderBy(x => x))
        {
            var j = (JObj)HouseJson.Parse(File.ReadAllText(f));
            var vals = HouseJson.Parse(HouseDraw.Eval("__house.map(" + HouseJson.Stringify(HouseJson.Stringify(j.Obj("st"))) + ")")) as JObj;
            string mine = Norm(HouseCreatures.MapSvg(tpl, vals)), theirs = Norm(j.Str("svg"));
            var name = Path.GetFileNameWithoutExtension(f);
            if (mine == theirs) { Console.WriteLine($"{name}: identical ({theirs.Length} chars)"); continue; }
            bad++; int i = 0; while (i < mine.Length && i < theirs.Length && mine[i] == theirs[i]) i++;
            Console.WriteLine($"{name}: DIFFERENT at {i} of {theirs.Length}\n  C#:   …{mine.Substring(Math.Max(0, i - 120), Math.Min(260, mine.Length - Math.Max(0, i - 120)))}\n  page: …{theirs.Substring(Math.Max(0, i - 120), Math.Min(260, theirs.Length - Math.Max(0, i - 120)))}");
        }
        return bad;
    }
}
