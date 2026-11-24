// `yard`: each yard game (Games/Yard) made, started and played for 30 s with random presses and drags (no exceptions,
// a score, the right ending), and its opening picture written as SVG (out/yard-<id>.svg: bg, mid, fg; creatures as
// boxes) for tools/unity/house/yard-check.mjs to compare with the page's.
using System;
using System.IO;
using System.Text;
using SquishSquad.Games.Yard;

static class YardCheck
{
    public static YardGame[] All() => new YardGame[] { new YardHoop(), new YardSoccer(), new YardHop(), new YardTramp(), new YardSlide(), new YardCorn(), new YardPong() };
    public static string Svg(YardCtx c)
    {
        var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 360 640\" width=\"360\" height=\"640\"><defs>" + YK.Defs + "</defs>");
        c.bg.Write(sb); c.mid.Write(sb);
        foreach (var cr in c.Creatures) sb.Append($"<rect x=\"{cr.X - cr.Size / 2:F1}\" y=\"{cr.Y - cr.Size * 0.93:F1}\" width=\"{cr.Size:F1}\" height=\"{cr.Size:F1}\" fill=\"none\" stroke=\"#f0f\" stroke-width=\"2\"/>");
        c.fg.Write(sb); sb.Append("</svg>"); return sb.ToString();
    }
    public static int Run()
    {
        int bad = 0; var walk = new SquishSquad.House.HouseWalk(File.ReadAllText(Path.Combine(Program.Res, "walk.json"))); YardCreature.Walker = walk;
        foreach (var g in All())
        {
            try
            {
                var c = new YardCtx(g, "mittens", "Mittens"); bool fin = false; c.Finished = e => fin = true;
                g.Make(c);
                File.WriteAllText(Path.Combine(Program.Repo, "tools/unity/house-test/out/yard-" + g.Id + ".svg"), Svg(c));
                c.Begin(); var R = new Random(1); double down = -1; double dx = 0, dy = 0;
                for (int f = 0; f < 60 * 120 && !fin; f++)
                {
                    c.Step(1 / 60.0);
                    if (down < 0 && R.NextDouble() < 0.03) { down = c.Now; dx = 120 + R.NextDouble() * 120; dy = 380 + R.NextDouble() * 200; g.Down(dx, dy, c.Now); }
                    else if (down >= 0) { double k = (c.Now - down) / 300; double sx = (R.NextDouble() - 0.5) * 160; g.Move(dx + sx * k, dy + (g.Id == "corn" ? 160 : -200) * k, c.Now); if (k >= 1) { g.Up(dx + sx, dy + (g.Id == "corn" ? 160 : -200), c.Now); down = -1; } }
                    if (g.Id == "hop" && R.NextDouble() < 0.04) c.PressButton(new[] { "hop", "split", "leap" }[R.Next(3)]);
                }
                Console.WriteLine($"{g.Id}: {(fin ? "finished" : "still going")} at {c.Now / 1000:F0} s, score {c.score}, {c.Parts.Count} particles, bg {c.bg.Kids.Count} groups");
            }
            catch (Exception e) { bad++; Console.WriteLine($"{g.Id}: {e.GetType().Name} {e.Message}\n{e.StackTrace?.Split('\n')[0]}"); }
        }
        return bad;
    }
}
