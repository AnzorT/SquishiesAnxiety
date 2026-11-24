// markup: the C# room's markup (HouseTemplate over RoomModel's values) vs the page's DOM, element by element
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SquishSquad.House;

static partial class Program
{
    public static HouseTemplate Template() => new HouseTemplate(File.ReadAllText(Path.Combine(Res, "room-template.html")));

    // the page's captures in the order they were taken (each room day, then night), with the C# house walked the same way
    public static IEnumerable<(string fx, string rk, bool night, JObj cap, HouseSave hs, JObj vals, RoomModel model)> Rooms(HouseData d, string only)
    {
        foreach (var fx in Fixtures(only))
        {
            var hs = LoadFixture(d, fx);
            var order = new[] { "living", "kitchen", "bathroom", "bedroom", "backyard", "dance", "movie", "beach" };
            foreach (var rk in order) foreach (var night in new[] { false, true })
            {
                var f = Path.Combine(Cap, fx, rk + "-" + (night ? "night" : "day") + ".json");
                if (!File.Exists(f)) continue;
                var cap = (JObj)HouseJson.Parse(File.ReadAllText(f));
                if (hs.Cur != rk) hs.EnterRoom(rk);
                var nk = rk == "beach" ? "bedroom" : rk; if (night) hs.H.Obj("night")[nk] = 1.0; else hs.H.Obj("night").Remove(nk);
                var m = new RoomModel(hs);
                var es = Environment.GetEnvironmentVariable("EDIT_SEL"); if (es != null) { m.EditOn = true; m.ESel = es; }   // (Renovate's footprints: a visual check)
                var vals = m.Build(rk);
                yield return (fx, rk, night, cap, hs, vals, m);
            }
        }
    }

    static readonly HashSet<string> StyleKeep = new HashSet<string> { "left", "top", "width", "height", "z-index", "transform", "transform-origin", "opacity", "background", "visibility" };
    static string Num6(string s) => Regex.Replace(s, @"-?\d+(\.\d+)?(e-?\d+)?", m => { var v = double.Parse(m.Value, CultureInfo.InvariantCulture); var r = v.ToString("G6", CultureInfo.InvariantCulture); return r == "-0" ? "0" : r; });
    public static string NormStyle(string st)
    {
        var parts = new SortedDictionary<string, string>();
        foreach (var p in st.Split(';'))
        {
            int i = p.IndexOf(':'); if (i < 0) continue;
            var k = p.Substring(0, i).Trim().ToLowerInvariant(); var v0 = p.Substring(i + 1).Trim();
            if (k == "inset") { var q = v0.Split(' ', StringSplitOptions.RemoveEmptyEntries); parts["top"] = Regex.Replace(Num6(q[0]), @"\b0px\b", "0"); parts["left"] = Regex.Replace(Num6(q.Length == 4 ? q[3] : q.Length >= 2 ? q[1] : q[0]), @"\b0px\b", "0"); continue; }
            if (!StyleKeep.Contains(k)) continue;
            var v = Num6(v0.Replace("(ellipse at", "(at").Replace("linear-gradient(to bottom,", "linear-gradient(")); v = Regex.Replace(v, @"\b0px\b", "0"); v = Regex.Replace(v, @"\s+", "");
            parts[k] = v;
        }
        return string.Join("; ", parts.Select(kv => kv.Key + ": " + kv.Value));
    }

    static void Lines(Dom n, int depth, List<string> o)
    {
        if (n.Tag == "#text") { o.Add(new string(' ', depth) + "\"" + n.Text + "\""); return; }
        if (n.Tag.StartsWith("animate") || n.Tag == "set" || n.Tag == "animateTransform" || n.Tag == "animateMotion") return;   // SMIL: stills strip it (the capture's later states lack it)
        var sb = new StringBuilder(new string(' ', depth)).Append(n.Tag.ToLowerInvariant());
        foreach (var a in n.Attrs) { if (a.Key == "data-dc-tpl") continue; var v = a.Key == "style" ? NormStyle(a.Value) : a.Value; sb.Append(' ').Append(a.Key).Append("=\"").Append(v.Length > 160 ? v.Substring(0, 120) + "…#" + v.GetHashCode().ToString("x") : v).Append('"'); }
        o.Add(sb.ToString());
        foreach (var c in n.Children) Lines(c, depth + 1, o);
    }

    // the page's captured tree (export-house.mjs tree(): { tag, a, c })
    public static Dom FromCap(JObj t)
    {
        var d = new Dom { Tag = t.Str("tag") };
        var a = t.Obj("a"); foreach (var k in a.Keys) d.Attrs.Add(new KeyValuePair<string, string>(k, a.Str(k)));
        foreach (var c in t.Arr("c")) d.Children.Add(FromCap((JObj)c));
        return d;
    }

    // the parts of the C# markup the page's capture has: the shell's svg, the items' divs, toys, the night overlay
    public static (Dom svg, List<Dom> items, List<Dom> toys, List<Dom> roomDivs, string night, Dom room) Parts(List<Dom> top)
    {
        var room = top.FirstOrDefault(x => x.Tag == "div");
        var svg = room.Children.FirstOrDefault(x => x.Tag == "svg");
        var cont = room.Children.FirstOrDefault(x => x.Tag == "div" && (x["style"] ?? "").Contains("z-index:3"));
        var items = cont.Children.Where(x => x["data-u"] != null || x["data-uf"] != null).ToList();
        var toys = cont.Children.Where(x => (x["style"] ?? "").Contains("width:40px")).ToList();
        var roomDivs = room.Children.Where(x => x.Tag == "div" && (x["style"] ?? "").Contains("-220px")).ToList();
        var nightDiv = top.Skip(1).FirstOrDefault(x => x.Tag == "div" && (x["style"] ?? "").Contains("z-index:860"));
        return (svg, items, toys, roomDivs, nightDiv?["style"], room);
    }

    static int Compare(string what, List<string> want, List<string> got, List<string> report)
    {
        int n = Math.Max(want.Count, got.Count), bad = 0;
        for (int i = 0; i < n; i++)
        {
            var w = i < want.Count ? want[i] : "(none)"; var g = i < got.Count ? got[i] : "(none)";
            if (w == g) continue;
            if (bad++ < 4) report.Add($"    {what} #{i}\n      page: {w}\n      C#:   {g}");
        }
        return bad;
    }

    static int Markup(string only)
    {
        var d = Data(); var tpl = Template(); int rooms = 0, ok = 0; long elems = 0;
        foreach (var (fx, rk, night, cap, hs, vals, m) in Rooms(d, only))
        {
            rooms++;
            var name = $"{fx} {rk} {(night ? "night" : "day")}";
            if (vals == null) { Console.WriteLine($"{name}: no drawing data: {string.Join("; ", m.Missing)}"); continue; }
            var top = tpl.Render(vals); var P = Parts(top); var dom = cap.Obj("dom"); var report = new List<string>(); int bad = 0;
            List<string> L(IEnumerable<Dom> ns) { var o = new List<string>(); foreach (var x in ns) Lines(x, 0, o); return o; }
            var wSvg = L(new[] { FromCap(dom.Obj("svg")) }); var gSvg = L(new[] { P.svg });
            bad += Compare("shell svg", wSvg, gSvg, report);
            var wIt = L(dom.Arr("items").Select(x => FromCap((JObj)x))); var gIt = L(P.items);
            bad += Compare("items", wIt, gIt, report);
            bad += Compare("toys", L(dom.Arr("toys").Select(x => FromCap((JObj)x))), L(P.toys), report);
            bad += Compare("room overlays", L(dom.Arr("roomDivs").Select(x => FromCap((JObj)x))), L(P.roomDivs), report);
            var wn = dom.Arr("extra").Count > 0 ? NormStyle((string)dom.Arr("extra")[0]) : "(none)"; var gn = P.night != null ? NormStyle(P.night) : "(none)";
            if (wn != gn) { bad++; report.Add($"    night overlay\n      page: {wn}\n      C#:   {gn}"); }
            if (dom.Arr("texts").Count > 0) { bad++; report.Add("    shell texts: not compared yet"); }
            elems += wSvg.Count + wIt.Count;
            var miss = m.Missing.Count > 0 ? " (missing: " + string.Join("; ", m.Missing.Distinct().Take(4)) + ")" : "";
            if (bad == 0) { ok++; Console.WriteLine($"{name}: identical ({wIt.Count(x => x.StartsWith("div"))} item divs, {wSvg.Count} shell elements){miss}"); }
            else { Console.WriteLine($"{name}: {bad} lines differ{miss}"); foreach (var r in report) Console.WriteLine(r); }
        }
        Console.WriteLine($"markup: {ok} of {rooms} rooms identical ({elems} elements compared)");
        return rooms - ok;
    }
}
