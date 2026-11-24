// The other shots' views: the Level Road, the treasure vault, the chest smash.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Anim;
using SquishSquad.Screens;

static partial class Program
{
    static IScreenView MoreViews(IDictionary<string, object> shot, string preview, IDictionary<string, object> profile, Ticker t, Func<DateTime> now)
    {
        if (preview == "road" || preview == "road-new")
        {
            var v = new RoadView(profile, W, H, t, now);
            v.OnSquad = (move, args) =>
            {
                var tcs = new TaskCompletionSource<IDictionary<string, object>>();
                t.SetTimeout(() => tcs.SetResult(FakeSquad(move, args, now())), 600);
                return tcs.Task;
            };
            return v;
        }
        if (preview == "vault")
        {
            // Preview.js VaultPreview: no picture (the paw); ready after 4.5 s. The first tip is the page's first
            // Math.random (virtual-clock.js's seeded generator): 0.428 → 1.
            var v = new VaultView(W, H, t, null, 1);
            // (the page's timer sets React state at 4500; VaultLoader's effect runs with the next frame's render)
            t.SetTimeout(v.Ready, 4516);
            return v;
        }
        if (preview == "smash")
        {
            // the page's engine rolls virtual-clock.js's generator from the page's start
            var v = new ChestSmashView(W, H, t, new XorShift().Next);
            var r = Prof.Map(shot["result"]);
            v.Start(Prof.Str(r["group"]), Prof.Str(r["size"]), r);
            return v;
        }
        return null;
    }
}
