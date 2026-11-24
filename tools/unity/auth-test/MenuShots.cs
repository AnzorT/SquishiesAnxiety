// The menu's coin / gem pills and the crest's number and XP ring for several players (menu.mjs), drawn from the Unity
// code (Menu/HudArt.cs, placed as Menu/HudLayer.cs places them; the coin / gem pictures are the exported ones) over the
// app's menu with those parts hidden, and compared with the app's menu.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Menu;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;

static class MenuShots
{
    const float Dpr = 2.8125f;
    static string F(double v) => UiSvg.F(v);

    public static int Run(string dir)
    {
        var layout = JsonDocument.Parse(File.ReadAllText(Program.Res("Menu/menu.json"))).RootElement;
        var ht = layout.GetProperty("hudText");
        float hudW = (float)ht.GetProperty("hudWidth").GetDouble();
        var crest = ht.GetProperty("crest").GetProperty("svg");
        float[] R(JsonElement e) { var a = new float[e.GetArrayLength()]; for (int i = 0; i < a.Length; i++) a[i] = (float)e[i].GetDouble(); return a; }
        var hud = new Dictionary<string, JsonElement>();
        foreach (var p in layout.GetProperty("hud").EnumerateArray()) hud[p.GetProperty("id").GetString()] = p;
        var refPills = new Dictionary<string, float[]>();
        foreach (var p in ht.GetProperty("pills").EnumerateArray()) refPills[p.GetProperty("id").GetString()] = R(p.GetProperty("pill"));
        var cs = R(crest);

        var players = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir, "profiles.json"))).RootElement;
        int n = 0, bad = 0;
        foreach (var pl in players.EnumerateArray())
        {
            bool baked = pl.TryGetProperty("baked", out var bk) && bk.GetBoolean();
            var v = baked ? HudValues.Baked : HudValues.FromProfile(new Dictionary<string, object> { ["coins"] = pl.GetProperty("coins").GetDouble(), ["gems"] = pl.GetProperty("gems").GetDouble(), ["pxp"] = pl.GetProperty("pxp").GetDouble() });
            bool same = baked || (v.Level == pl.GetProperty("level").GetInt32() && v.Into == pl.GetProperty("into").GetDouble() && v.Need == pl.GetProperty("need").GetDouble());
            if (!same) bad++;
            string coins = HudValues.Fmt(v.Coins), gems = HudValues.Fmt(v.Gems);

            var svg = new StringBuilder($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
            svg.Append($"<image href=\"{Path.Combine(dir, $"menu-{n}-bare")}\" x=\"0\" y=\"0\" width=\"832\" height=\"384\"/>");
            var pieces = new List<ScreenPiece>();
            var (cx, cw, gx, gw, y) = HudArt.PillRow(hudW, coins, gems);
            foreach (var (id, text, x) in new[] { ("pill-coins", coins, cx), ("pill-gems", gems, gx) })
            {
                var pill = HudArt.Pill(text);
                pieces.Add(new ScreenPiece { Id = id, Svg = pill.Markup, W = pill.W, H = pill.H }.At(x * HudArt.K, y * HudArt.K));
                // the exported coin / gem picture, where it sits from its pill
                var h = hud[id];
                var rect = R(h.GetProperty("rect"));
                float ix = x * HudArt.K * Dpr + (rect[0] - refPills[id][0]), iy = y * HudArt.K * Dpr + (rect[1] - refPills[id][1]);
                var img = new UiSvg(rect[2] / Dpr, rect[3] / Dpr).Image("Menu/" + h.GetProperty("res").GetString(), 0, 0, rect[2] / Dpr, rect[3] / Dpr);
                pieces.Add(new ScreenPiece { Id = id + "-icon", Svg = img.Markup, W = img.W, H = img.H }.At(ix / Dpr, iy / Dpr));
            }
            // the crest's number and ring, in its <svg>'s viewBox (meet)
            float s = Math.Min(cs[2] / 120f, cs[3] / 104f);
            float ox = cs[0] + (cs[2] - 120 * s) / 2, oy = cs[1] + (cs[3] - 104 * s) / 2;
            var ct = HudArt.CrestText(v.Level, v.HasXp, v.Need > 0 ? Math.Min(1, v.Into / v.Need) : 0, s / Dpr);
            pieces.Add(new ScreenPiece { Id = "crest-text", Svg = ct.Markup, W = ct.W, H = ct.H }.At(ox / Dpr, oy / Dpr));
            var composed = Pieces.Compose(pieces, 832, 384);
            svg.Append(composed.Substring(composed.IndexOf('>') + 1).Replace("</svg>", ""));
            svg.Append("</svg>");
            var file = Path.Combine(dir, $"menu-{n}.unity.svg");
            File.WriteAllText(file, svg.ToString());
            var (w, hgt, reference) = Png.Read(Path.Combine(dir, $"menu-{n}.png"));
            var ours = Program.Draw(svg.ToString(), w, hgt);
            Png.Write(Path.Combine(dir, $"menu-{n}.unity.png"), w, hgt, ours);
            var pillsBox = new Frame(Math.Min(cx, gx) * HudArt.K - 20, 0, (gx + gw - Math.Min(cx, gx)) * HudArt.K + 26, 56);
            var crestBox = new Frame(cs[0] / Dpr - 6, cs[1] / Dpr - 6, cs[2] / Dpr + 12, cs[3] / Dpr + 12);
            var (p1, n1) = Program.Diff(reference, ours, w, hgt, Path.Combine(dir, $"menu-{n}.pills.diff.png"), null, pillsBox);
            var (p2, n2) = Program.Diff(reference, ours, w, hgt, Path.Combine(dir, $"menu-{n}.crest.diff.png"), null, crestBox);
            var (p3, n3) = Program.Diff(reference, ours, w, hgt, Path.Combine(dir, $"menu-{n}.diff.png"), null);
            Console.WriteLine($"{(baked ? "offline (exported values)" : "player " + n)}: coins {coins}, gems {gems}, level {v.Level} ({v.Into}/{v.Need} XP){(same ? "" : " LEVEL MISMATCH")}: " +
                $"pills {p1:0.00} % ({n1} px), crest {p2:0.00} % ({n2} px), whole screen {p3:0.000} % ({n3} px) differ visibly");
            n++;
        }
        return bad;
    }
}
