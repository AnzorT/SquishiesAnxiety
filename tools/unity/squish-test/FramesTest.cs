// Draws the stage at ref.mjs's screenshot frames with the CPU reference (SquishShade.Render: the port's mesh, dent
// shader maths, lights, material and supersampling, on the C# toy's replayed state) and compares the pictures with
// the app's (frame-N.png), pixel by pixel.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SquishSquad.Backend;
using SquishSquad.Games.Squish;

static class FramesTest
{
    public static int Run(string dir, string only)
    {
        var r = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Path.Combine(dir, "frames.json")));
        string key = (string)r["key"];
        string bgHex = ((string)r["bg"]).TrimStart('#');
        var bg = new byte[] { Convert.ToByte(bgHex.Substring(0, 2), 16), Convert.ToByte(bgHex.Substring(2, 2), 16), Convert.ToByte(bgHex.Substring(4, 2), 16) };
        var (tw, th, trgba) = Png.Read(Program.Res($"Squish/cards/{key}.png.bytes"));
        var tex = new SquishShade.Tex { W = tw, H = th, Rgba = trgba };
        var shots = ((IList<object>)((IDictionary<string, object>)r["scenario"])["shots"]).Select(o => (int)(double)o).ToHashSet();
        if (only != null) shots = new HashSet<int>(only.Split(',').Select(int.Parse));
        int fails = 0;
        double sumPct = 0; int n = 0;
        ToyTest.Replay(dir, (f, toy, st) =>
        {
            if (!shots.Contains(f)) return;
            var app = Path.Combine(dir, $"frame-{f}.png");
            if (!File.Exists(app)) return;
            var (W, H, a) = Png.Read(app);
            var mine = SquishShade.Render(toy, tex, W, 2, bg);
            Png.Write(Path.Combine(dir, $"unity-{f}.png"), W, W, mine);
            int diff = 0, card = 0; double sum = 0; int maxd = 0;
            var heat = new byte[W * W * 4];
            for (int i = 0; i < W * W; i++)
            {
                int d = 0;
                for (int c = 0; c < 3; c++) d = Math.Max(d, Math.Abs(a[i * 4 + c] - mine[i * 4 + c]));
                bool onCard = Math.Abs(a[i * 4] - bg[0]) + Math.Abs(a[i * 4 + 1] - bg[1]) + Math.Abs(a[i * 4 + 2] - bg[2]) > 0 || Math.Abs(mine[i * 4] - bg[0]) + Math.Abs(mine[i * 4 + 1] - bg[1]) + Math.Abs(mine[i * 4 + 2] - bg[2]) > 0;
                if (onCard) card++;
                sum += d; if (d > maxd) maxd = d;
                if (d > 8) diff++;
                heat[i * 4] = (byte)Math.Min(255, d * 8); heat[i * 4 + 1] = (byte)(a[i * 4 + 1] / 3); heat[i * 4 + 2] = (byte)(a[i * 4 + 2] / 3); heat[i * 4 + 3] = 255;
            }
            Png.Write(Path.Combine(dir, $"diff-{f}.png"), W, W, heat);
            double pct = 100.0 * diff / (W * W), pctCard = card > 0 ? 100.0 * diff / card : 0;
            sumPct += pct; n++;
            Console.WriteLine($"frame {f,3}: {diff,6} px visibly differ (>8/255) = {pct:F3} % of the stage, {pctCard:F3} % of the card; mean {sum / (W * W):F3}, max {maxd}");
            if (pct > 1) fails++;
        });
        Console.WriteLine($"{n} frames, mean {sumPct / Math.Max(1, n):F3} % visibly different");
        return fails == 0 ? 0 : 1;
    }
}
