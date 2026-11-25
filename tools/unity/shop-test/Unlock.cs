// The chest unlock as Unity plays it, frame by frame, with its creature live after the BAM (for a video):
//   dotnet run -c Release --project tools/unity/shop-test -- unlockframes <shots dir> <out dir> [from ms] [to ms] [every]
// The smash-unlock shot of capture.mjs's shots.json (its result and taps) on the same virtual clock as `shots`; every
// `every`-th 16 ms frame from `from` to `to` drawn at 1040 x 480 px: the screen's pieces under the hero's slot, the
// creature on the native rig (Creatures/Js, Gen: the app's rig compiled to C#) placed by Creatures/HeroPop.cs as
// HeroCreature.cs places it in the app (the BAM's pop, the hop, the landing, then its idle), the pieces over the slot.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Backend;
using SquishSquad.Creatures;
using SquishSquad.Creatures.Js;
using SquishSquad.Screens;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

static partial class Program
{
    sealed class HeroRig : IHeroRig
    {
        public readonly int Id;
        public HeroRig(string key) { Id = RigHost.Mount(key); }
        public void Play(string move) => RigHost.Play(Id, move);
        public void Ext(IDictionary<string, double> e) => RigHost.Ext(Id, e);
        public void Emit(string kind, double x, double y) => RigHost.Native("emit", Id, kind, V.Null, x, y, 0);
    }

    static int UnlockFrames(string shotsDir, string outDir, double from, double to, int every)
    {
        Directory.CreateDirectory(outDir);
        string work = Path.Combine(Root, "webgame/test/out/unity-webgame");
        if (!RigHost.Boot(p => { var f = Path.Combine(work, p); return File.Exists(f) ? File.ReadAllText(f) : null; }))
        { Console.Error.WriteLine("the rig didn't start: " + string.Join("; ", RigHost.BootErrors)); return 2; }
        ChestSmashView.LiveHero = _ => true;
        ReferenceRaster.LoadImage = LoadImage;

        var shot = Prof.List(Json.Parse(File.ReadAllText(Path.Combine(shotsDir, "shots.json")))).Select(Prof.Map).First(s => (string)s["name"] == "smash-unlock");
        var t = new Ticker(0);
        Ticker.Default = t;
        var view = Make(shot, t);
        var taps = (Prof.List(Prof.Get(shot, "taps")) ?? new List<object>()).Select(tp => Prof.List(tp).Select(v => (float)Prof.Num(v)).ToArray()).ToList();
        int ti = 0, n = 0, f = (int)Math.Round(from / 16.0 / every);   // (frames numbered from 0 ms: ranges rendered apart join up)
        HeroRig rig = null; HeroPop pop = null;
        const int PW = 1040, PH = 480, SS = 2;
        var px = Affine.ScaleBy(PW / W, PH / H);
        for (double ms = 0; ms <= to; ms += 16)
        {
            t.Tick(ms); Frame(view);
            while (ti < taps.Count && taps[ti][0] <= ms) { view.Pieces(); view.Down(taps[ti][1], taps[ti][2]); view.Up(taps[ti][1], taps[ti][2]); ti++; }
            if (rig != null) RigHost.Frame(16);   // (the rig's one clock, once a frame, from when the creature came out)
            // the hero's slot, every frame from the BAM on (as HeroCreature syncs it each Unity frame), drawn or not
            bool draw = ms >= from && n++ % every == 0;
            List<ScreenPiece> pieces = null;
            int slot = -1;
            Affine m = Affine.Identity;
            if (draw || ms >= 6000)
            {
                pieces = view.Pieces();
                slot = pieces.FindIndex(p => p.Slot && p.Live != null);
                if (slot >= 0)
                {
                    var p = pieces[slot];
                    if (rig == null)
                    {
                        rig = new HeroRig(p.Live.Key);
                        RigHost.Frame(16);
                        pop = new HeroPop(RigHost.RestBox(rig.Id) ?? new double[] { 30, 20, 40, 70 });
                    }
                    m = p.Transform * pop.Step(p.Live, rig);
                }
            }
            if (!draw) continue;

            var under = slot < 0 ? pieces : pieces.Take(slot).ToList();
            var over = slot < 0 ? new List<ScreenPiece>() : pieces.Skip(slot + 1).ToList();
            var buf = ReferenceRaster.Render(Screen(under, PW, PH), PW, PH, SS);
            if (slot >= 0)
            {
                var tree = RigHost.Svg(rig.Id);
                if (tree != null && pieces[slot].Opacity > 0)
                    Over(buf, ReferenceRaster.Render(SvgScene.Compile(SvgMarkup.Parse(tree), 100, 100, px * m), PW, PH, SS), pieces[slot].Opacity);
            }
            if (over.Count > 0) Over(buf, ReferenceRaster.Render(Screen(over, PW, PH), PW, PH, SS), 1);
            Png.Write(Path.Combine(outDir, $"frame-{f++:0000}.png"), PW, PH, ReferenceRaster.Resolve(buf, SS, PW, PH));
            if (f % 20 == 0) Console.WriteLine($"{f} frames ({ms} ms)");
        }
        Console.WriteLine($"{f} frames, one every {every * 16} ms, in {outDir}");
        return 0;
    }

    // the pieces as one scene at w x h px (their pictures sized as `shots` sizes them)
    static SvgScene Screen(List<ScreenPiece> pieces, int w, int h)
        => SvgScene.Compile(SvgMarkup.Parse(Pieces.Compose(pieces, W, H)), w, h, Affine.Identity, href => { var i = LoadImage(href); return i.Item3 == null ? ((int, int)?)null : (i.Item1, i.Item2); });

    static void Over(ReferenceRaster.Buffer into, ReferenceRaster.Buffer b, float op)
    {
        for (int i = 0; i < into.P.Length; i += 4)
        {
            float sa = b.P[i + 3] * op; if (sa <= 0) continue;
            float k = 1 - sa;
            into.P[i] = b.P[i] * op + into.P[i] * k; into.P[i + 1] = b.P[i + 1] * op + into.P[i + 1] * k;
            into.P[i + 2] = b.P[i + 2] * op + into.P[i + 2] * k; into.P[i + 3] = sa + into.P[i + 3] * k;
        }
    }
}
