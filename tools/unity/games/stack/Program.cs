// dotnet run -c Release --project tools/unity/games/stack/StackDiff.csproj [fixtures/stack.json]
//
// Replays fixtures.mjs's inputs through the C# port of Squish Stack (unity/Assets/Scripts/Games/Stack) and compares
// every answer with what the JS gave, deeply and exactly (doubles bit for bit, key sets of maps, the count of random
// numbers drawn). Prints per-area pass counts and the first mismatches; exits 1 on any.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Games.Stack;

static class Program
{
    sealed class Area
    {
        public int Pass, Fail;
        public readonly List<string> First = new List<string>();
    }

    static readonly Dictionary<string, Area> areas = new Dictionary<string, Area>();
    static readonly List<string> order = new List<string>();

    static int Main(string[] args)
    {
        string file = args.Length > 0 ? args[0] : FindFixtures();
        if (file == null || !File.Exists(file))
        {
            Console.Error.WriteLine("no fixtures: run `node tools/unity/games/stack/fixtures.mjs` first");
            return 2;
        }
        Dictionary<string, object> fx;
        using (var doc = JsonDocument.Parse(File.ReadAllText(file))) fx = (Dictionary<string, object>)FromJson(doc.RootElement);

        RunConsts(D(fx["consts"]));
        RunBasics(L(fx["basics"]), L(fx["sames"]));
        RunSolves(L(fx["solves"]));
        RunPuzzles(L(fx["puzzles"]));
        RunSpecs(fx);
        RunScoring(fx);
        RunProfiles(L(fx["profiles"]));
        foreach (var c in L(fx["clocks"]).Select(D)) Check("clock", "clock(" + Num(c["ms"]) + ")", c["out"], Levels.Clock(Num(c["ms"])));

        int fails = 0, passes = 0;
        Console.WriteLine();
        foreach (var name in order)
        {
            var a = areas[name];
            passes += a.Pass;
            fails += a.Fail;
            Console.WriteLine($"{name,-14} {a.Pass,7} pass {a.Fail,5} fail");
            foreach (var m in a.First) Console.WriteLine("    " + m);
        }
        Console.WriteLine($"{"total",-14} {passes,7} pass {fails,5} fail");
        Timing(L(fx["timing"]));
        Console.WriteLine(fails == 0 ? "stack C#: matches the JS" : "stack C#: MISMATCHES");
        return fails == 0 ? 0 : 1;
    }

    static string FindFixtures()
    {
        foreach (var start in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
        {
            for (var dir = new DirectoryInfo(start); dir != null; dir = dir.Parent)
            {
                var f = Path.Combine(dir.FullName, "fixtures", "stack.json");
                if (File.Exists(f) && File.Exists(Path.Combine(dir.FullName, "fixtures.mjs"))) return f;
                f = Path.Combine(dir.FullName, "tools", "unity", "games", "stack", "fixtures", "stack.json");
                if (File.Exists(f)) return f;
            }
        }
        return null;
    }

    // --- areas --------------------------------------------------------------------------------------

    static void RunConsts(Dictionary<string, object> c)
    {
        Check("consts", "LEVELS", c["LEVELS"], Levels.LEVELS);
        Check("consts", "LEVEL_LIST", c["LEVEL_LIST"], Levels.LEVEL_LIST.Select(e => (object)new Dictionary<string, object>
        {
            { "band", e.Band }, { "n", e.N }, { "k", e.K }, { "tier", e.Tier },
        }).ToList());
        Check("consts", "TIER_NAMES", c["TIER_NAMES"], Levels.TIER_NAMES);
        Check("consts", "TIER_COLORS", c["TIER_COLORS"], Levels.TIER_COLORS);
        Check("consts", "PICTURE_FROM", c["PICTURE_FROM"], Levels.PICTURE_FROM);
        Check("consts", "LATE_FROM", c["LATE_FROM"], Levels.LATE_FROM);
        Check("consts", "SKILL_MIN", c["SKILL_MIN"], Levels.SKILL_MIN);
        Check("consts", "SKILL_MAX", c["SKILL_MAX"], Levels.SKILL_MAX);
        Check("consts", "BLITZ_COINS", c["BLITZ_COINS"], Levels.BLITZ_COINS.ToDictionary(kv => kv.Key.ToString(System.Globalization.CultureInfo.InvariantCulture), kv => (object)kv.Value));
        foreach (var s in L(c["skillShift"]).Select(D)) Check("skillShift", "skillShift(" + Num(s["skill"]) + ")", s["out"], Levels.SkillShift(Num(s["skill"])));
    }

    static void RunBasics(List<object> basics, List<object> sames)
    {
        foreach (var c in basics.Select(D))
        {
            var pos = Ints(c["pos"]);
            int k = (int)Num(c["k"]);
            string label = "pos [" + string.Join(",", pos) + "] k " + k;
            var cushions = Enumerable.Range(-1, k + 2).ToArray();
            Check("stackOf", label, c["stackOf"], cushions.Select(p => (object)Engine.StackOf(pos, p)).ToList());
            Check("topOf", label, c["topOf"], cushions.Select(p => (object)Engine.TopOf(pos, p)).ToList());
            Check("canMove", label, c["canMove"], cushions.Select(a => (object)cushions.Select(b => (object)Engine.CanMove(pos, a, b)).ToList()).ToList());
        }
        foreach (var c in sames.Select(D))
            Check("same", "same", c["same"], Engine.Same(Ints(c["a"]), Ints(c["b"])));
    }

    static uint DistHash(short[] dist)
    {
        uint h = 2166136261;
        unchecked
        {
            for (int i = 0; i < dist.Length; i++) h = (h ^ (uint)(dist[i] & 0xffff)) * 16777619;
        }
        return h;
    }

    static List<object> Walk(Solution sol, int[] p)
    {
        var path = new List<object>();
        for (var m = Engine.BestMove(sol, p); m != null; m = Engine.BestMove(sol, p))
        {
            path.Add(m);
            p = (int[])p.Clone();
            p[m[0]] = m[2];
            if (path.Count > 10000) break;
        }
        return path;
    }

    // the same checks fixtures.mjs solCheck() made, on the same positions
    static Dictionary<string, object> SolCheck(Solution sol, Dictionary<string, object> expected)
    {
        var pos = L(expected["pos"]).Select(D).Select(x =>
        {
            var p = Ints(x["p"]);
            return (object)new Dictionary<string, object> { { "p", p }, { "left", Engine.Left(sol, p) }, { "best", Engine.BestMove(sol, p) } };
        }).ToList();
        var walks = L(expected["walks"]).Select(D).Select(x =>
        {
            var p = Ints(x["p"]);
            return (object)new Dictionary<string, object> { { "p", p }, { "path", Walk(sol, p) } };
        }).ToList();
        int max = -1;
        foreach (var d in sol.Dist) max = Math.Max(max, d);
        return new Dictionary<string, object>
        {
            { "size", sol.Dist.Length },
            { "hash", (double)DistHash(sol.Dist) },
            { "max", max },
            { "dist", sol.Dist.Length <= 4096 ? sol.Dist.Select(d => (object)(int)d).ToList() : null },
            { "pos", pos },
            { "walks", walks },
        };
    }

    static void RunSolves(List<object> solves)
    {
        foreach (var c in solves.Select(D))
        {
            int n = (int)Num(c["n"]), k = (int)Num(c["k"]);
            var goal = Ints(c["goal"]);
            var sol = Engine.Solve(n, k, goal);
            var actual = SolCheck(sol, c);
            actual["n"] = n;
            actual["k"] = k;
            actual["goal"] = goal;
            Check("solve", $"solve({n}, {k}, [{string.Join(",", goal)}])", c, actual);
        }
    }

    sealed class Tape
    {
        readonly double[] v;
        public int Used;
        public Tape(double[] v) { this.v = v; }

        public double Next()
        {
            if (Used >= v.Length) throw new InvalidOperationException("drew more random numbers than the JS did");
            return v[Used++];
        }
    }

    static LevelSpec SpecFrom(Dictionary<string, object> s) => new LevelSpec
    {
        Lv = s.ContainsKey("lv") ? (int)Num(s["lv"]) : 0,
        Round = s.ContainsKey("round") ? (int?)(int)Num(s["round"]) : null,
        Band = s.ContainsKey("band") ? (int)Num(s["band"]) : 0,
        N = (int)Num(s["n"]),
        K = (int)Num(s["k"]),
        Tier = s.ContainsKey("tier") ? (int)Num(s["tier"]) : 0,
        BaseTier = s.ContainsKey("baseTier") ? (int)Num(s["baseTier"]) : 0,
        Start = (string)s["start"],
        Goal = (string)s["goal"],
        Par = s["par"] == null ? null : Ints(s["par"]),
        Past = s.ContainsKey("past") ? (int)Num(s["past"]) : 0,
        News = s.ContainsKey("news") ? (string)s["news"] : null,
    };

    static void RunPuzzles(List<object> puzzles)
    {
        foreach (var c in puzzles.Select(D))
        {
            var spec = SpecFrom(D(c["spec"]));
            var tape = new Tape(L(c["tape"]).Select(Num).ToArray());
            var actual = new Dictionary<string, object>();
            try
            {
                var P = Engine.MakePuzzle(spec, tape.Next);
                actual["draws"] = tape.Used;
                actual["start"] = P.Start;
                actual["goal"] = P.Goal;
                actual["star"] = P.Star;
                actual["par"] = P.Par;
                actual["hint"] = Engine.BestMove(P.Sol, P.Start);
                actual["sol"] = SolCheck(P.Sol, D(c["sol"]));
            }
            catch (Exception e)
            {
                actual["error"] = e.Message;
            }
            var expected = new Dictionary<string, object>();
            foreach (var key in new[] { "draws", "start", "goal", "star", "par", "hint", "sol" }) expected[key] = c[key];
            Check("makePuzzle", (string)c["what"] + " seed " + Num(c["seed"]), expected, actual);
        }
    }

    static Dictionary<string, object> SpecOut(LevelSpec s)
    {
        var d = new Dictionary<string, object>
        {
            { "lv", s.Lv }, { "band", s.Band }, { "n", s.N }, { "k", s.K }, { "tier", s.Tier }, { "baseTier", s.BaseTier },
            { "start", s.Start }, { "goal", s.Goal }, { "par", s.Par }, { "news", s.News },
        };
        if (s.Round.HasValue) { d["round"] = s.Round.Value; d["past"] = s.Past; }
        return d;
    }

    static void RunSpecs(Dictionary<string, object> fx)
    {
        foreach (var c in L(fx["specs"]).Select(D))
        {
            double lv = Num(c["lv"]);
            var spec = c["skill"] == null ? Levels.LevelSpec(lv) : Levels.LevelSpec(lv, Num(c["skill"]));
            Check("levelSpec", $"levelSpec({lv}, {c["skill"] ?? "-"})", c["spec"], SpecOut(spec));
        }
        foreach (var c in L(fx["blitzSpecs"]).Select(D))
        {
            int i = (int)Num(c["i"]);
            var spec = c["skill"] == null ? Levels.BlitzSpec(i) : Levels.BlitzSpec(i, Num(c["skill"]));
            Check("blitzSpec", $"blitzSpec({i}, {c["skill"] ?? "-"})", c["spec"], SpecOut(spec));
        }
    }

    static LevelSpec CaseSpec(Dictionary<string, object> c) =>
        c["blitz"] != null ? Levels.BlitzSpec((int)Num(c["blitz"]), Num(c["skill"])) : Levels.LevelSpec(Num(c["lv"]), Num(c["skill"]));

    static void RunScoring(Dictionary<string, object> fx)
    {
        foreach (var c in L(fx["nextSkills"]).Select(D))
            Check("nextSkill", $"nextSkill({Num(c["skill"])}, won {c["won"]} stars {Num(c["stars"])} hinted {c["hinted"]})", c["out"],
                Levels.NextSkill(Num(c["skill"]), (bool)c["won"], (int)Num(c["stars"]), (bool)c["hinted"]));
        foreach (var c in L(fx["twoStars"]).Select(D))
            Check("twoStarMoves", $"twoStarMoves({Num(c["par"])})", c["out"], Levels.TwoStarMoves((int)Num(c["par"])));
        foreach (var c in L(fx["starsFor"]).Select(D))
            Check("starsFor", $"starsFor({Num(c["par"])}, {Num(c["moves"])}, {c["hinted"]})", c["out"], Levels.StarsFor((int)Num(c["par"]), Num(c["moves"]), (bool)c["hinted"]));
        foreach (var c in L(fx["coins"]).Select(D))
            Check("coinsFor", $"coinsFor(lv {Num(c["lv"])} skill {Num(c["skill"])} blitz {c["blitz"] ?? "-"}, {Num(c["par"])}, {Num(c["stars"])})", c["out"],
                Levels.CoinsFor(CaseSpec(c), Num(c["par"]), (int)Num(c["stars"])));
        foreach (var c in L(fx["xps"]).Select(D))
            Check("xpFor", $"xpFor(lv {Num(c["lv"])} skill {Num(c["skill"])} blitz {c["blitz"] ?? "-"}, {Num(c["stars"])})", c["out"], Levels.XpFor(CaseSpec(c), Num(c["stars"])));
    }

    static Dictionary<string, object> LevelOut(PlayerLevel p) =>
        p == null ? null : new Dictionary<string, object> { { "level", p.Level }, { "into", p.Into }, { "need", p.Need } };

    static Dictionary<string, object> OutcomeOut(StackOutcome o, bool level) => new Dictionary<string, object>
    {
        { "update", o.Update }, { "coins", o.Coins }, { "xp", o.Xp }, { "before", LevelOut(o.Before) }, { "after", LevelOut(o.After) },
        { "levelUps", o.LevelUps }, { "stars", level ? (object)o.Stars : null }, { "unlocked", level ? (object)o.Unlocked : null }, { "newTop", level ? null : (object)o.NewTop },
    };

    static void RunProfiles(List<object> configs)
    {
        foreach (var cfg in configs.Select(D))
        {
            var r = D(cfg["rules"]);
            StackXp.Rules = new XpRules { XpPerLevel = Num(r["xpPerLevel"]), Games = Num(r["games"]), Replay = Num(r["replay"]), BlitzStack = Num(r["blitzStack"]) };
            int ci = 0;
            foreach (var c in L(cfg["cases"]).Select(D))
            {
                string label = $"cfg {r["xpPerLevel"]} case {ci++} {Show(c["profile"])}";
                var profile = c["profile"] as IDictionary<string, object>;
                var rec = Levels.Record(profile);
                Check("record", label, c["record"], new Dictionary<string, object>
                {
                    { "lv", rec.Lv }, { "best", rec.Best }, { "skill", rec.Skill }, { "plays", rec.Plays }, { "wins", rec.Wins }, { "seen", rec.Seen },
                    { "bSkill", rec.BSkill },
                    { "blitz", new Dictionary<string, object> { { "top", rec.Blitz.Top }, { "runs", rec.Blitz.Runs }, { "reached", rec.Blitz.Reached }, { "bestMs", rec.Blitz.BestMs }, { "wins", rec.Blitz.Wins } } },
                });
                Check("starsOf/doneOf", label, new List<object> { c["starsOf"], c["doneOf"] }, new List<object> { Levels.StarsOf(rec), Levels.DoneOf(rec) });
                Check("pxpOf", label, c["pxp"], StackXp.PxpOf(profile));
                foreach (var t in L(c["levels"]).Select(D))
                {
                    int lv = (int)Num(t["lv"]);
                    var spec = (bool)t["blitz"] ? Levels.BlitzSpec(lv, Num(t["skill"])) : Levels.LevelSpec(lv, Num(t["skill"]));
                    var o = Levels.AfterLevel(profile, spec, (int)Num(t["par"]), (bool)t["won"], Num(t["moves"]), (bool)t["hinted"]);
                    Check("afterLevel", $"{label} lv {lv} blitz {t["blitz"]} par {Num(t["par"])} won {t["won"]} moves {Num(t["moves"])} hinted {t["hinted"]}", t["out"], OutcomeOut(o, true));
                }
                foreach (var t in L(c["prizes"]).Select(D))
                {
                    var (coins, xp) = Levels.BlitzPrize((int)Num(t["cleared"]), Num(t["skill"]));
                    Check("blitzPrize", $"{label} cleared {Num(t["cleared"])}", t["out"], new Dictionary<string, object> { { "coins", coins }, { "xp", xp } });
                }
                foreach (var t in L(c["blitzes"]).Select(D))
                {
                    var o = Levels.AfterBlitz(profile, (int)Num(t["cleared"]));
                    Check("afterBlitz", $"{label} cleared {Num(t["cleared"])}", t["out"], OutcomeOut(o, false));
                }
                foreach (var t in L(c["adds"]).Select(D))
                {
                    double xp;
                    PlayerLevel before, after;
                    List<int> ups;
                    StackXp.AddXp(profile, Num(t["n"]), out xp, out before, out after, out ups);
                    Check("addXp", $"{label} n {Num(t["n"])}", t["out"], new Dictionary<string, object>
                    {
                        { "xp", xp }, { "before", LevelOut(before) }, { "after", LevelOut(after) }, { "levelUps", ups },
                    });
                }
            }
        }
        StackXp.Rules = null;
    }

    static void Timing(List<object> timing)
    {
        Console.WriteLine();
        Console.WriteLine("solve() timing, mean per call (C# Release vs JS node):");
        foreach (var t in timing.Select(D))
        {
            int n = (int)Num(t["n"]), k = (int)Num(t["k"]), runs = (int)Num(t["runs"]);
            var goals = L(t["goals"]).Select(Ints).ToList();
            foreach (var g in goals) Engine.Solve(n, k, g);
            int reps = runs * 10;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < reps; i++) Engine.Solve(n, k, goals[i % goals.Count]);
            sw.Stop();
            double ms = sw.Elapsed.TotalMilliseconds / reps;
            Console.WriteLine($"  {n} on {k} ({Math.Pow(k, n),6} states): C# {ms,7:F3} ms   JS {Num(t["jsMs"]),7:F3} ms");
        }
    }

    // --- comparing ------------------------------------------------------------------------------------

    static void Check(string area, string label, object expected, object actual)
    {
        Area a;
        if (!areas.TryGetValue(area, out a))
        {
            a = new Area();
            areas[area] = a;
            order.Add(area);
        }
        string diff = Diff(expected, Norm(actual), "");
        if (diff == null) a.Pass++;
        else
        {
            a.Fail++;
            if (a.First.Count < 5) a.First.Add(Trim(label, 220) + "\n        " + Trim(diff, 400));
        }
    }

    static string Trim(string s, int n) => s.Length <= n ? s : s.Substring(0, n) + "…";

    // C# answers → the JSON shapes: numbers as double, maps, lists
    static object Norm(object v)
    {
        if (v == null || v is string || v is bool || v is double) return v;
        if (v is int || v is long || v is short || v is uint || v is float) return Convert.ToDouble(v, CultureInfo.InvariantCulture);
        if (v is IDictionary<string, object> m)
        {
            var d = new Dictionary<string, object>();
            foreach (var kv in m) d[kv.Key] = Norm(kv.Value);
            return d;
        }
        if (v is IEnumerable e)
        {
            var l = new List<object>();
            foreach (var x in e) l.Add(Norm(x));
            return l;
        }
        throw new ArgumentException("can't compare a " + v.GetType());
    }

    static string Diff(object e, object a, string path)
    {
        if (e == null || a == null) return e == null && a == null ? null : $"{path}: JS {Show(e)} C# {Show(a)}";
        if (e is double de)
        {
            if (!(a is double da)) return $"{path}: JS {Show(e)} C# {Show(a)}";
            return de.Equals(da) ? null : $"{path}: JS {de.ToString("R", CultureInfo.InvariantCulture)} C# {da.ToString("R", CultureInfo.InvariantCulture)}";
        }
        if (e is string || e is bool) return e.Equals(a) ? null : $"{path}: JS {Show(e)} C# {Show(a)}";
        if (e is Dictionary<string, object> me)
        {
            if (!(a is Dictionary<string, object> ma)) return $"{path}: JS {Show(e)} C# {Show(a)}";
            foreach (var key in me.Keys) if (!ma.ContainsKey(key)) return $"{path}.{key}: missing in C# (JS {Show(me[key])})";
            foreach (var key in ma.Keys) if (!me.ContainsKey(key)) return $"{path}.{key}: extra in C# ({Show(ma[key])})";
            foreach (var key in me.Keys)
            {
                var d = Diff(me[key], ma[key], path + "." + key);
                if (d != null) return d;
            }
            return null;
        }
        if (e is List<object> le)
        {
            if (!(a is List<object> la)) return $"{path}: JS {Show(e)} C# {Show(a)}";
            if (le.Count != la.Count) return $"{path}: JS length {le.Count} C# {la.Count}: JS {Show(e)} C# {Show(a)}";
            for (int i = 0; i < le.Count; i++)
            {
                var d = Diff(le[i], la[i], path + "[" + i + "]");
                if (d != null) return d;
            }
            return null;
        }
        return $"{path}: can't compare {e.GetType()}";
    }

    static string Show(object v)
    {
        v = Norm(v);
        if (v == null) return "null";
        if (v is double d) return d.ToString("R", CultureInfo.InvariantCulture);
        if (v is string s) return "\"" + s + "\"";
        if (v is bool b) return b ? "true" : "false";
        if (v is Dictionary<string, object> m) return Trim("{" + string.Join(",", m.Select(kv => kv.Key + ":" + Show(kv.Value))) + "}", 300);
        if (v is List<object> l) return Trim("[" + string.Join(",", l.Select(Show)) + "]", 300);
        return v.ToString();
    }

    // --- JSON ------------------------------------------------------------------------------------------

    static object FromJson(JsonElement el)
    {
        switch (el.ValueKind)
        {
            case JsonValueKind.Object:
                var d = new Dictionary<string, object>();
                foreach (var p in el.EnumerateObject()) d[p.Name] = FromJson(p.Value);
                return d;
            case JsonValueKind.Array:
                var l = new List<object>();
                foreach (var x in el.EnumerateArray()) l.Add(FromJson(x));
                return l;
            case JsonValueKind.Number: return el.GetDouble();
            case JsonValueKind.String: return el.GetString();
            case JsonValueKind.True: return true;
            case JsonValueKind.False: return false;
            default: return null;
        }
    }

    static Dictionary<string, object> D(object o) => (Dictionary<string, object>)o;
    static List<object> L(object o) => (List<object>)o;
    static double Num(object o) => (double)o;
    static int[] Ints(object o) => L(o).Select(x => (int)(double)x).ToArray();
}
