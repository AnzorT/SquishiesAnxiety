// The stand-in a game opens under (Games/Shared/ScreenBones.cs, as Menu/MenuScreen.cs shows it):
// (its check against the app's ScreenBones.js is tools/unity/loading-test `bones`, which has the screens' kit)
//   dotnet run -c Release --project tools/unity/maps-test -- bonesframes <out dir> [card] [hold ms] [to ms] [every]
//       a game opening as the menu opens it, frame by frame (1040 x 480 px, every `every`-th 16 ms frame): the stand-in
//       alone for `hold` ms (in the app it stays as long as the build takes; held here so it can be seen), then the
//       game (`card`: game-stack, game-sort, game-hop) built under it and the stand-in fading out over it (160 ms). The
//       stand-in's background: <out dir>/pagebg.svg (Kit.PageBg, written by loading-test `bones`), else the hub's own
using System;
using System.Collections.Generic;
using System.IO;
using SquishSquad.Anim;
using SquishSquad.Games.Shared;
using SquishSquad.Ui.Cards;

static partial class Program
{
    static int BonesFrames(string dir, string card, double hold, double to, int every)
    {
        Directory.CreateDirectory(dir);
        string page = File.ReadAllText(Res("Stack/bg.xml"));
        var tk = new Ticker(0);
        Ticker.Default = tk;
        Fx.LikeWeb = false;   // (the loops loop, as in the app on the phone)
        Bones.Mount();
        var pbg = Path.Combine(dir, "pagebg.svg");
        string standBg = File.Exists(pbg) ? File.ReadAllText(pbg) : page;
        var bones = new ScreenBones(card == "game-hop" ? "map" : "hub", standBg, 832, 384);
        GameScreen screen = null;
        int f = 0, n = 0;
        for (double ms = 0; ms <= to; ms += 16)
        {
            tk.Tick(ms);
            if (screen == null && ms >= hold)
            {
                var profile = Player();
                GameDef def = card == "game-stack" ? new SquishSquad.Games.Stack.StackDef(profile) { Walker = "mittens" }
                    : card == "game-sort" ? new SquishSquad.Games.Sort.SortDef(profile)
                    : (GameDef)new SquishSquad.Games.Hop.HopDef(profile);
                screen = new GameScreen(def, 832, 384) { Season = "sunny" };
                screen.Start();
                bones.Reveal(ms + 16);   // (MenuScreen: the frame after the build)
            }
            screen?.Update();
            if (n++ % every != 0) continue;
            var over = bones.Done(ms) ? null : bones.Pieces(ms);
            var px = Render.Draw(page, screen != null ? screen.Frame.List : new List<ScreenLayer>(), screen != null ? (IEnumerable<Card>)screen.Cards : new Card[0], 1040, 480, null, over);
            global::Png.Write(Path.Combine(dir, $"frame-{f++:0000}.png"), 1040, 480, px);
        }
        Console.WriteLine($"{f} frames, one every {every * 16} ms, in {dir}");
        return 0;
    }
}
