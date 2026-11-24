// The Yard Games page (unity/Assets/Scripts/Games/Yard/View/YardPageModel.cs) at the moments
// tools/unity/house/export-yardpage.mjs screenshotted it in the app: hoop and tramp bought (tramp's best 240), the row
// at its start, scrolled and at its end. The posters' creatures are left out on both sides (the app's were not drawn:
// YardGames.posterRig off; Unity's are the live rigs, not run here).
//   dotnet run -c Release --project tools/unity/pages-test -- yd
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SquishSquad.Games.Yard.View;

static partial class Program
{
    static IEnumerable<object> YardScenes()
    {
        var text = File.ReadAllText(Res("Yard/page/yardpage.json"));
        var L = JsonSerializer.Deserialize<YardPageLayout>(text, Opts);
        var doc = JsonDocument.Parse(text).RootElement;
        double W = L.reference.px[0], H = L.reference.px[1];
        foreach (var s in doc.GetProperty("shots").EnumerateArray())
        {
            var owned = new HashSet<string>(); foreach (var o in s.GetProperty("owned").EnumerateArray()) owned.Add(o.GetString());
            var best = new Dictionary<string, int>(); foreach (var b in s.GetProperty("best").EnumerateObject()) best[b.Name] = b.Value.GetInt32();
            var m = new YardPageModel(L, W, H) { Open = owned.Contains, Best = id => best.TryGetValue(id, out var v) ? v : 0, Scroll = s.GetProperty("scroll").GetDouble() };
            Console.WriteLine($"{s.GetProperty("name").GetString()}: scroll {m.Scroll} of {m.ScrollMax:0.##} (app {L.scrollMax})");
            yield return Scene(s.GetProperty("name").GetString(), s.GetProperty("file").GetString(), null, "Yard/page", m.Draw(5000), new[] { W, H });
        }
    }
}
