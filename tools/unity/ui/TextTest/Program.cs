// dotnet run --project tools/unity/ui/TextTest -- <texts.json ...>
// Lays out each text run Chrome drew (snap-test.mjs writes texts.json) with UiFont and compares every character's x.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Ui;

static class Program
{
    static int Main(string[] args)
    {
        var fontDir = Path.Combine(AppContext.BaseDirectory, "../../../../../../../unity/Assets/Resources/Fonts");
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Path.Combine(fontDir, n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        var within = new int[4];
        int runs = 0, glyphs = 0, exact = 0; double worst = 0; string worstRun = "";
        foreach (var file in args)
            foreach (var t in JsonDocument.Parse(File.ReadAllText(file)).RootElement.EnumerateArray())
            {
                var s = t.GetProperty("s").GetString();
                var font = UiFont.Get(t.GetProperty("font").GetString());
                var xs = font.Layout(s, (float)t.GetProperty("size").GetDouble(), (float)t.GetProperty("ls").GetDouble(), out _);
                var cps = UiFont.CodePoints(s);
                var ours = Enumerable.Range(0, cps.Count).Where(i => !char.IsWhiteSpace(char.ConvertFromUtf32(cps[i]), 0) && (font.Has(cps[i]) || UiFont.Get("Fallback").Has(cps[i]))).Select(i => (double)xs[i]).ToArray();
                var chrome = t.GetProperty("xs").EnumerateArray().Select(v => v.GetDouble()).ToArray();
                bool wrapped = s.Contains('\n');
                for (int i = 1; i < chrome.Length; i++) if (chrome[i] < chrome[i - 1]) wrapped = true;
                if (ours.Length != chrome.Length || chrome.Length == 0 || wrapped) continue;   // several lines: not compared here
                runs++;
                for (int i = 0; i < chrome.Length; i++)
                {
                    double d = Math.Abs((ours[i] - ours[0]) - (chrome[i] - chrome[0]));
                    glyphs++;
                    if (d < 1.0 / 128) exact++;
                    if (d >= 1.0 / 128) within[d < 0.05 ? 0 : d < 0.25 ? 1 : d < 1 ? 2 : 3]++;
                    if (d >= 0.05 && Environment.GetEnvironmentVariable("SHOW") != null) Console.WriteLine($"  {d:0.###} \"{s}\" {t.GetProperty("font")} {t.GetProperty("size")} ls {t.GetProperty("ls")} char {i}");
                    if (d > worst) { worst = d; worstRun = $"\"{s}\" {t.GetProperty("font")} {t.GetProperty("size")} char {i}"; }
                }
            }
        Console.WriteLine($"off by <0.05 px: {within[0]}, <0.25: {within[1]}, <1: {within[2]}, more: {within[3]}");
        Console.WriteLine($"{runs} runs, {glyphs} characters: {exact} exact (to 1/64 px), worst {worst:0.###} px ({worstRun})");
        return 0;
    }
}
