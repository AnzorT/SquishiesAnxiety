// The screen around the stage: composed from the exported pieces with the Unity code's own layout (SquishLayout) and
// the pieces it makes itself (SquishHudArt: the coin pill with its number, the rings), drawn with the vector reference
// rasteriser, against the app's screenshots (hud.mjs: tools/unity/squish-test/ref/squish-a15.png, the settings card in
// squish-settings-a15.png, the punishment in squish-punish-a15.png).
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using SquishSquad.Backend;
using SquishSquad.Games.Squish;
using SquishSquad.Ui;
using SquishSquad.Vector;

static class HudTest
{
    static string X(string n) => File.ReadAllText(Program.Res("Squish/hud/" + n + ".xml"));

    public static int Run(string dir)
    {
        Directory.CreateDirectory(dir);
        var opts = new JsonSerializerOptions { IncludeFields = true };
        UiFont.ReadJson = n => File.ReadAllText(Program.Res("Fonts/" + n + ".json"));
        UiFont.ParseJson = j => JsonSerializer.Deserialize<UiFontData>(j, opts);
        SquishHudArt.Xml = X;
        var hud = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Program.Res("Squish/hud.json")));
        var L = new SquishLayout(832, 384, hud);
        string N(string svg, HudBox b, string extra = "") => SquishHudArt.Nest(svg, b.X, b.Y, extra);
        string Op(string inner, float o) => $"<g opacity=\"{o}\">{inner}</g>";

        // the screen as it opens: sky, the top left, the gear and its hint, the stage's hints, the boosts
        var sb = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        sb.Append(N(X("sky"), new HudBox(0, 0, 832, 384)));
        for (int i = 0; i < 2; i++)
        {
            sb.Append(N(X("hand-" + (i + 1)), L.HintHands[i]));
            sb.Append(Op(N(SquishHudArt.Ring(26, 2.5f, "#ff6fbd"), L.HintRings[i]), 0.95f));
            sb.Append(N(X("hint-" + (i + 1)), L.HintLabels[i]));
        }
        sb.Append(N(X("back"), L.Back));
        sb.Append(N(SquishHudArt.Pill(0, out _, out _), L.Pill));
        sb.Append(Op(N(SquishHudArt.Ring(52, 3, "#ff8a3d"), L.GearHalo), 0.95f));
        sb.Append(N(X("hand-0"), L.SettingsHand));
        sb.Append(N(X("hint-0"), L.SettingsHint));
        sb.Append(N(X("gear"), L.Gear));
        sb.Append(N(X("gear-glyph"), L.GearGlyph));
        sb.Append(N(X("boosts"), L.Boosts));
        sb.Append("</svg>");
        int fails = 0;
        if (Environment.GetEnvironmentVariable("ONLY") == "punish") goto punish;
        fails += Compare(sb.ToString(), Path.Combine(Program.Root, "tools/unity/squish-test/ref/squish-a15.png"), dir, "screen", null);

        // the settings card (the 'on' states: its own picture) and a toggle / choice swapped in (off, 1, pop out)
        var card = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        card.Append(N(X("settings"), L.Settings));
        card.Append("</svg>");
        fails += Compare(card.ToString(), Path.Combine(Program.Root, "tools/unity/squish-test/ref/squish-settings-a15.png"), dir, "settings", L.Settings);

        punish:
        var pun = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"832\" height=\"384\" viewBox=\"0 0 832 384\">");
        // (under it: the screen with its hints gone, dimmed rgba(50,24,6,0.55))
        pun.Append(N(X("sky"), new HudBox(0, 0, 832, 384)));
        pun.Append(N(X("back"), L.Back));
        pun.Append(N(SquishHudArt.Pill(0, out _, out _), L.Pill));
        pun.Append(N(X("gear"), L.Gear));
        pun.Append(N(X("gear-glyph"), L.GearGlyph));
        pun.Append(N(X("boosts"), L.Boosts));
        pun.Append(N(SquishHudArt.Dim(832, 384, "rgba(50,24,6,0.55)"), new HudBox(0, 0, 832, 384)));
        pun.Append(N(X("punish"), L.Punish));
        pun.Append(N(SquishHudArt.PunishTitle().Markup(), L.A15["punishTitle"].Move(L.Punish.X - L.A15["punish"].X, L.Punish.Y - L.A15["punish"].Y)));
        pun.Append("</svg>");
        fails += Compare(pun.ToString(), Path.Combine(Program.Root, "tools/unity/squish-test/ref/squish-punish-a15.png"), dir, "punish", L.Punish);
        return fails == 0 ? 0 : 1;
    }

    static readonly Dictionary<string, (int, int, float[])> Images = new Dictionary<string, (int, int, float[])>();
    static (int, int, float[]) Load(string href)
    {
        if (Images.TryGetValue(href, out var c)) return c;
        var f = Program.Res(href + ".png");
        if (!File.Exists(f)) return (0, 0, null);
        var (w, h, rgba) = Png.Read(f);
        var px = new float[w * h * 4];
        for (int i = 0; i < px.Length; i++) px[i] = rgba[i] / 255f;
        return Images[href] = (w, h, px);
    }

    // `only`: compare inside that box (dp), else the whole screen
    static int Compare(string svg, string appPng, string dir, string name, HudBox? only)
    {
        var (W, H, reference) = Png.Read(appPng);
        ReferenceRaster.LoadImage = Load;
        var scene = SvgScene.Compile(SvgMarkup.Parse(svg), W, H, Affine.Identity, href => { var i = Load(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });
        var ours = ReferenceRaster.Resolve(ReferenceRaster.Render(scene, W, H, 2), 2, W, H);
        Png.Write(Path.Combine(dir, name + "-unity.png"), W, H, ours);
        double k = W / 832.0;
        int visible = 0, counted = 0;
        var diff = new byte[W * H * 4];
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                bool use = only == null || only.Value.Contains((float)(x / k), (float)(y / k));
                int d = Math.Max(Math.Abs(reference[i] - ours[i]), Math.Max(Math.Abs(reference[i + 1] - ours[i + 1]), Math.Abs(reference[i + 2] - ours[i + 2])));
                if (use) { counted++; if (d > 24) visible++; }
                byte g = (byte)(ours[i] * 0.3 + 150);
                bool bad = d > 24 && use;
                diff[i] = bad ? (byte)255 : g; diff[i + 1] = bad ? (byte)0 : g; diff[i + 2] = bad ? (byte)60 : g; diff[i + 3] = 255;
            }
        Png.Write(Path.Combine(dir, name + "-diff.png"), W, H, diff);
        double pct = 100.0 * visible / counted;
        Console.WriteLine($"{name}: {visible} of {counted} px differ visibly (>24/255): {pct:0.00} %");
        return pct < 3 ? 0 : 1;
    }
}
