// SquishRules against the app's src/progression.js (rules.mjs): today's challenges, bumpDaily (the written `daily`,
// the challenges it completes, the squishes' XP), the streak's multiplier on squish coins.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SquishSquad.Backend;
using SquishSquad.Games.Squish;

static class RulesTest
{
    static double D(object o) => o is double d ? d : 0;

    public static int Run(string dir)
    {
        var r = (IDictionary<string, object>)Json.Parse(File.ReadAllText(Path.Combine(dir, "rules.json")));
        int bad = 0, n = 0;
        foreach (IDictionary<string, object> c in (IList<object>)r["challenges"])
        {
            n++;
            var mine = SquishRules.ChallengesFor((string)c["date"]);
            var js = ((IList<object>)c["list"]).Cast<IDictionary<string, object>>().ToList();
            if (js.Count != mine.Count || js.Where((x, i) => (string)x["id"] != mine[i].Id || (int)D(x["goal"]) != mine[i].Goal || (string)x["side"] != mine[i].Side).Any()) bad++;
        }
        Console.WriteLine($"challengesFor: {n} dates, {bad} differ");
        int bb = 0, nb = 0;
        foreach (IDictionary<string, object> b in (IList<object>)r["bumps"])
        {
            nb++;
            var profile = (IDictionary<string, object>)b["profile"];
            var o = (IDictionary<string, object>)b["out"];
            var mine = SquishRules.BumpDaily(profile, (string)b["ev"], D(b["n"]), (string)b["date"]);
            string a = Json.Write(((IDictionary<string, object>)o["update"])["daily"]), m = Json.Write(mine.Daily);
            var jsDone = ((IList<object>)o["completed"]).Cast<string>().ToList();
            bool same = Canon(a) == Canon(m) && jsDone.SequenceEqual(mine.Completed) && D(o["xp"]) == mine.Xp;
            if (!same) { bb++; if (bb <= 3) Console.WriteLine($"  bump differs: js {a} {string.Join("|", jsDone)} {o["xp"]} / port {m} {string.Join("|", mine.Completed)} {mine.Xp}"); }
        }
        Console.WriteLine($"bumpDaily: {nb} cases, {bb} differ");
        int bs = 0, ns = 0;
        foreach (IDictionary<string, object> s in (IList<object>)r["streaks"])
        {
            ns++;
            var nw = (IList<object>)s["now"];
            var now = new DateTime((int)D(nw[0]), (int)D(nw[1]), (int)D(nw[2]), 12, 0, 0);
            if (Math.Abs(SquishRules.StreakMultiplier((IDictionary<string, object>)s["profile"], now) - D(s["mult"])) > 1e-12) bs++;
        }
        Console.WriteLine($"streakMultiplier: {ns} cases, {bs} differ");
        bool ok = bad == 0 && bb == 0 && bs == 0;
        Console.WriteLine(ok ? "OK" : "MISMATCH");
        return ok ? 0 : 1;
    }

    // the same map whatever its key order
    static string Canon(string json) => Json.Write(Sort(Json.Parse(json)));
    static object Sort(object o) => o is IDictionary<string, object> d ? d.OrderBy(k => k.Key, StringComparer.Ordinal).ToDictionary(k => k.Key, k => Sort(k.Value)) : o is IList<object> l ? l.Select(Sort).ToList() : o;
}
