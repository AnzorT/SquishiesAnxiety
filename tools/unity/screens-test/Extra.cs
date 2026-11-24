// The other screens' views for Program.Make.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Screens;

static partial class Program
{
    /// <summary>The shot's spin answer (shots.mjs `spin`: window.__spinAnswer), or null: Preview.js's default.</summary>
    static IDictionary<string, object> SpinAnswer;

    static IScreenView Extra(string preview, IDictionary<string, object> profile, Ticker t, List<Creature> all, Func<DateTime> now)
    {
        switch (preview)
        {
            case "scr-streak": case "scr-streak-zero": case "scr-streak-long": return new StreakView(profile, "Mittens", false, W, H, t, now);
            case "scr-streak-intro": case "scr-streak-done": return new StreakView(profile, "Mittens", true, W, H, t, now);
            case "scr-daily": case "scr-daily-ready": case "scr-daily-done": return new DailySheetView(profile, W, H, t, now) { ShowBackground = true };
            case "scr-stats": case "scr-stats-new": return new StatsView(all, profile, W, H, t);
            case "scr-settings": return new SettingsView("Mia", false, W, H, t);
            case "scr-settings-tester": return new SettingsView("Mia", true, W, H, t) { Wallet = new TestWalletView(t, 2450, 85, 4) };
            case "scr-spin":
            {
                // Preview.js's "server": answers 800 ms after the tap (window.__spinAnswer, by default 500 coins, slice 6)
                var v = new SpinView("Mia", 1, true, W, H, t, now);
                v.OnSpin = bonus =>
                {
                    var tcs = new System.Threading.Tasks.TaskCompletionSource<SpinResult>();
                    var answer = SpinAnswer;
                    t.SetTimeout(() => tcs.SetResult(answer != null ? SpinResult.From(answer) : new SpinResult { Index = 6, Kind = "coins", Amount = 500 }), 800);
                    return tcs.Task;
                };
                return v;
            }
        }
        return null;
    }
}
