// The Characters page's scenes: the opening (its loading screen) at the exporter's moments, and the page at rest with
// Mittens, Biscuit looked at, Biscuit chosen, a creature not owned, and the row scrolled.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Menu;

static partial class Program
{
    static IEnumerable<object> CharactersScenes()
    {
        var text = File.ReadAllText(Res("Characters/characters.json"));
        var L = JsonSerializer.Deserialize<CharactersLayout>(text, Opts);
        var doc = JsonDocument.Parse(text).RootElement;
        double W = L.reference.px[0], H = L.reference.px[1];
        // the row against the app's: the sticky labels
        foreach (var st in L.row.sticky)
        {
            var m = new CharactersModel(L, W, H, L.demo.owned, L.demo.sel, 0) { };
            m.Row.Value = st.scroll;
            double worst = 0;
            for (int i = 0; i < L.groups.Length; i++)
            {
                var g = L.groups[i];
                double lx = Math.Max(g.label[0], Math.Min(st.scroll + m.StickyEdge, g.box[0] + g.box[2] - g.label[2]));
                worst = Math.Max(worst, Math.Abs(lx - st.x[i]));
            }
            Console.WriteLine($"row at {st.scroll}: the group labels {worst:0.###} pu from the app's");
        }
        var tips = L.gs?.tipsText ?? new string[0];
        foreach (var s in doc.GetProperty("shots").GetProperty("list").EnumerateArray())
        {
            string name = s.GetProperty("name").GetString();
            bool opening = s.TryGetProperty("ms", out var msE);
            double now = opening ? msE.GetDouble() : 20000, endless = s.GetProperty("endless").GetDouble();
            string tip = s.TryGetProperty("tip", out var tp) && tp.ValueKind == JsonValueKind.String ? tp.GetString() : null;
            var m = new CharactersModel(L, W, H, L.demo.owned, L.demo.sel, 0, Math.Max(0, Array.IndexOf(tips, tip)));
            if (L.awayAt > 0) m.AwayAt = L.awayAt;
            if (s.TryGetProperty("awayAt", out var aw) && aw.ValueKind == JsonValueKind.Number) m.AwayAt = aw.GetDouble();
            string pick = s.GetProperty("pick").GetString(), inUse = s.TryGetProperty("inUse", out var iu) ? iu.GetString() : null;
            if (inUse != null && inUse != m.InUse) { m.Choose(inUse, now - 9000); m.Confirm(now - 9000); }
            if (pick != m.Pick) m.Choose(pick, now - 5000);
            if (s.TryGetProperty("toast", out _)) { m.Choose(pick, now - 5000); }
            if (name == "ch-chosen") { var m2 = new CharactersModel(L, W, H, L.demo.owned, L.demo.sel, 0); m = m2; if (L.awayAt > 0) m.AwayAt = L.awayAt; m.Choose("biscuit", now - 5000); m.Confirm(now - 300); }
            if (s.TryGetProperty("scroll", out var sc) && sc.ValueKind == JsonValueKind.Number) m.Row.Value = sc.GetDouble();
            m.EndlessEpoch = now - endless;
            yield return Scene(name, s.GetProperty("file").GetString(), (s.TryGetProperty("plate", out var pl1) ? pl1.GetString() : doc.GetProperty("shots").GetProperty("plate").GetString()), "Characters", m.Draw(now));
        }
    }
}
