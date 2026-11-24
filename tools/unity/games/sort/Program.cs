// Squish Sort's differential test, C# side: loads fixtures/*.json (inputs
// and the JS's outputs, written by fixtures.mjs), replays every case through
// the port in unity/Assets/Scripts/Games/Sort and compares deeply. Prints
// the pass counts per area and the first mismatches; exits 1 on any.
//
//   node tools/unity/games/sort/fixtures.mjs && dotnet run -c Release --project tools/unity/games/sort
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using SquishSquad.Games.Sort;

static class Program
{
    sealed class Area { public int Pass, Fail; public List<string> First = new List<string>(); }
    static readonly SortedDictionary<string, Area> Areas = new SortedDictionary<string, Area>(StringComparer.Ordinal);

    static void Check(string area, string label, Func<string> run)
    {
        Area a;
        if (!Areas.TryGetValue(area, out a)) Areas[area] = a = new Area();
        string diff;
        try { diff = run(); }
        catch (Exception ex) { diff = "threw " + ex.GetType().Name + ": " + ex.Message; }
        if (diff == null) { a.Pass++; return; }
        a.Fail++;
        if (a.First.Count < 5) a.First.Add(label + ": " + diff);
    }

    static string Here([CallerFilePath] string p = "") => Path.GetDirectoryName(p);

    static int Main(string[] args)
    {
        string dir = args.Length > 0 ? args[0] : Path.Combine(Here(), "fixtures");
        if (!File.Exists(Path.Combine(dir, "boards.json")))
        {
            Console.Error.WriteLine("no fixtures in " + dir + ": run node tools/unity/games/sort/fixtures.mjs first");
            return 2;
        }
        using (var boards = Load(dir, "boards.json")) Boards(boards.RootElement);
        using (var plays = Load(dir, "plays.json")) Plays(plays.RootElement);
        using (var levels = Load(dir, "levels.json")) LevelsArea(levels.RootElement);
        using (var profiles = Load(dir, "profiles.json")) Profiles(profiles.RootElement);

        int fails = 0, total = 0;
        foreach (var e in Areas)
        {
            Console.WriteLine($"{e.Key,-14} {e.Value.Pass,6} passed  {e.Value.Fail,4} failed");
            foreach (var f in e.Value.First) Console.WriteLine("    " + f);
            fails += e.Value.Fail;
            total += e.Value.Pass + e.Value.Fail;
        }
        Console.WriteLine(fails == 0 ? $"sort diff: all {total} cases match the JS" : $"sort diff: {fails} of {total} cases differ from the JS");
        return fails == 0 ? 0 : 1;
    }

    static JsonDocument Load(string dir, string name) => JsonDocument.Parse(File.ReadAllBytes(Path.Combine(dir, name)), new JsonDocumentOptions { MaxDepth = 256 });

    // --- inputs ----------------------------------------------------------------------

    // a number input: "undefined" -> null, "NaN" -> NaN
    static double? Num(JsonElement e)
    {
        if (e.ValueKind == JsonValueKind.String)
        {
            string s = e.GetString();
            if (s == "undefined") return null;
            if (s == "NaN") return double.NaN;
            throw new FormatException("bad number input " + s);
        }
        if (e.ValueKind == JsonValueKind.Null) return null;
        return e.GetDouble();
    }

    static int IntOr0(JsonElement o, string key)
    {
        JsonElement v;
        return o.TryGetProperty(key, out v) && v.ValueKind == JsonValueKind.Number ? v.GetInt32() : 0;
    }

    // JSON -> the profile's plain data
    static object ToObj(JsonElement e)
    {
        switch (e.ValueKind)
        {
            case JsonValueKind.Object:
                var d = new Dictionary<string, object>();
                foreach (var p in e.EnumerateObject()) d[p.Name] = ToObj(p.Value);
                return d;
            case JsonValueKind.Array:
                var l = new List<object>();
                foreach (var x in e.EnumerateArray()) l.Add(ToObj(x));
                return l;
            case JsonValueKind.Number: return e.GetDouble();
            case JsonValueKind.String: return e.GetString();
            case JsonValueKind.True: return true;
            case JsonValueKind.False: return false;
            default: return null;
        }
    }

    static LevelSpec BoardSpec(JsonElement s) => new LevelSpec
    {
        Rows = s.GetProperty("rows").GetInt32(),
        Cols = s.GetProperty("cols").GetInt32(),
        Count = s.GetProperty("count").GetInt32(),
        Foods = IntOr0(s, "foods"),
        Decoys = IntOr0(s, "decoys"),
        Swaps = IntOr0(s, "swaps"),
        Mixed = IntOr0(s, "mixed"),
    };

    static List<PoolEntry> PoolOf(int n)
    {
        var l = new List<PoolEntry>();
        for (int i = 0; i < n; i++) l.Add(new PoolEntry(i.ToString(CultureInfo.InvariantCulture), "u" + i.ToString(CultureInfo.InvariantCulture)));
        return l;
    }

    static LevelSpec SpecOf(JsonElement s)
    {
        double skill = s.GetProperty("skill").GetDouble();
        return s.GetProperty("kind").GetString() == "blitz" ? Levels.BlitzSpec(s.GetProperty("i").GetInt32(), skill) : Levels.LevelSpec(s.GetProperty("lv").GetDouble(), skill);
    }

    static BoardData ParseBoard(JsonElement b)
    {
        var board = new BoardData
        {
            Rows = b.GetProperty("rows").GetInt32(),
            Cols = b.GetProperty("cols").GetInt32(),
            Slots = b.GetProperty("slots").GetInt32(),
            TrayCap = b.GetProperty("trayCap").GetInt32(),
        };
        foreach (var p in b.GetProperty("pieces").EnumerateArray())
        {
            var h = p.GetProperty("home");
            var u = p.GetProperty("uri");
            board.Pieces.Add(new Piece { Id = p.GetProperty("id").GetString(), Uri = u.ValueKind == JsonValueKind.Null ? null : u.GetString(), Home = h.ValueKind == JsonValueKind.Null ? (int?)null : h.GetInt32() });
        }
        foreach (var e in b.GetProperty("start").EnumerateArray()) board.Start[e[0].GetInt32()] = e[1].GetInt32();
        foreach (var e in b.GetProperty("swaps").EnumerateArray())
            board.Swaps.Add(new int?[] { e[0].ValueKind == JsonValueKind.Null ? (int?)null : e[0].GetInt32(), e[1].ValueKind == JsonValueKind.Null ? (int?)null : e[1].GetInt32() });
        foreach (var e in b.GetProperty("after").EnumerateArray()) board.After[e[0].GetInt32()] = new Place(e[1].GetString(), e[2].GetInt32());
        foreach (var e in b.GetProperty("foodBefore").EnumerateArray()) board.FoodBefore[e[0].GetInt32()] = e[1].GetInt32();
        foreach (var e in b.GetProperty("foodAfter").EnumerateArray()) board.FoodAfter[e[0].GetInt32()] = e[1].GetInt32();
        return board;
    }

    // --- outputs as plain trees (to compare with the JS's JSON) --------------------------

    static Dictionary<string, object> Obj(params object[] kv)
    {
        var d = new Dictionary<string, object>();
        for (int i = 0; i < kv.Length; i += 2) d[(string)kv[i]] = kv[i + 1];
        return d;
    }

    static List<object> PairList(SortedDictionary<int, int> m)
    {
        var l = new List<object>();
        foreach (var e in m) l.Add(new List<object> { e.Key, e.Value });
        return l;
    }

    static List<object> PlaceList(SortedDictionary<int, Place> m)
    {
        var l = new List<object>();
        foreach (var e in m) l.Add(new List<object> { e.Key, e.Value.Kind, e.Value.I });
        return l;
    }

    static object BoardTree(BoardData b)
    {
        var pieces = new List<object>();
        foreach (var p in b.Pieces) pieces.Add(Obj("id", p.Id, "uri", p.Uri, "home", p.Home));
        var swaps = new List<object>();
        foreach (var s in b.Swaps) swaps.Add(new List<object> { s[0], s[1] });
        return Obj("rows", b.Rows, "cols", b.Cols, "slots", b.Slots, "pieces", pieces, "start", PairList(b.Start), "swaps", swaps, "after", PlaceList(b.After), "foodBefore", PairList(b.FoodBefore), "foodAfter", PairList(b.FoodAfter), "trayCap", b.TrayCap);
    }

    static object StateTree(PlayState s)
    {
        var locked = new List<object>();
        foreach (var k in s.Locked) locked.Add(k);
        var gone = new List<object>();
        foreach (var k in s.Gone) gone.Add(k);
        return Obj("at", PlaceList(s.At), "locked", locked, "gone", gone);
    }

    static object SpecTree(LevelSpec s)
    {
        var d = Obj("lv", s.Lv, "band", s.Band, "model", s.Model, "first", s.First, "more", s.More, "rows", s.Rows, "cols", s.Cols, "tier", s.Tier, "baseTier", s.BaseTier, "count", s.Count, "foods", s.Foods, "decoys", s.Decoys, "swaps", s.Swaps, "mixed", s.Mixed, "peekMs", s.PeekMs, "limitMs", s.LimitMs, "parMs", s.ParMs);
        if (s.Round.HasValue) d["round"] = s.Round.Value;
        return d;
    }

    static object LevelTree(PlayerLevelInfo p) => Obj("level", p.Level, "into", p.Into, "need", p.Need);

    static object OutcomeTree(SortOutcome o, bool level, bool won)
    {
        var ups = new List<object>();
        foreach (var u in o.LevelUps) ups.Add(u);
        var d = Obj("update", new Dictionary<string, object>(o.Update), "coins", o.Coins, "xp", o.Xp, "levelUps", ups);
        if (won) { d["before"] = LevelTree(o.Before); d["after"] = LevelTree(o.After); }
        if (level) { d["stars"] = o.Stars; d["unlocked"] = o.Unlocked; }
        else d["newTop"] = o.NewTop;
        return d;
    }

    static object RecordTree(SortRecord r)
    {
        Func<ThemeRecord, object> t = x => Obj("lv", x.Lv, "best", x.Best, "skill", x.Skill);
        return Obj("fridge", t(r.Fridge), "plays", r.Plays, "wins", r.Wins, "seen", r.Seen, "bSkill", r.BSkill,
            "blitz", Obj("top", r.Blitz.Top, "runs", r.Blitz.Runs, "reached", r.Blitz.Reached, "bestMs", r.Blitz.BestMs, "wins", r.Blitz.Wins));
    }

    static List<object> Strings(IEnumerable<string> l)
    {
        var o = new List<object>();
        foreach (var s in l) o.Add(s);
        return o;
    }

    // --- deep comparison -----------------------------------------------------------------

    static bool IsNum(object a) => a is int || a is long || a is double || a is float;

    static string Show(object a)
    {
        if (a == null) return "null";
        if (a is string s) return "\"" + s + "\"";
        if (a is bool b) return b ? "true" : "false";
        if (IsNum(a)) return Convert.ToDouble(a, CultureInfo.InvariantCulture).ToString("R", CultureInfo.InvariantCulture);
        if (a is IDictionary) return "{...}";
        if (a is IList) return "[...]";
        return a.ToString();
    }

    static string Diff(JsonElement e, object a, string path)
    {
        switch (e.ValueKind)
        {
            case JsonValueKind.Null:
                return a == null ? null : $"{path}: JS null, C# {Show(a)}";
            case JsonValueKind.True:
            case JsonValueKind.False:
                return a is bool b && b == e.GetBoolean() ? null : $"{path}: JS {e.GetRawText()}, C# {Show(a)}";
            case JsonValueKind.Number:
                return IsNum(a) && Convert.ToDouble(a, CultureInfo.InvariantCulture) == e.GetDouble() ? null : $"{path}: JS {e.GetRawText()}, C# {Show(a)}";
            case JsonValueKind.String:
                return a is string s && s == e.GetString() ? null : $"{path}: JS {e.GetRawText()}, C# {Show(a)}";
            case JsonValueKind.Array:
            {
                var l = a as IList;
                if (l == null) return $"{path}: JS array, C# {Show(a)}";
                int n = e.GetArrayLength();
                if (n != l.Count) return $"{path}: JS {n} items, C# {l.Count}";
                int i = 0;
                foreach (var x in e.EnumerateArray())
                {
                    var d = Diff(x, l[i], path + "[" + i + "]");
                    if (d != null) return d;
                    i++;
                }
                return null;
            }
            case JsonValueKind.Object:
            {
                var m = a as IDictionary<string, object>;
                if (m == null) return $"{path}: JS object, C# {Show(a)}";
                int n = 0;
                foreach (var p in e.EnumerateObject())
                {
                    n++;
                    object v;
                    if (!m.TryGetValue(p.Name, out v)) return $"{path}.{p.Name}: missing in C#";
                    var d = Diff(p.Value, v, path + "." + p.Name);
                    if (d != null) return d;
                }
                if (n != m.Count)
                {
                    foreach (var k in m.Keys)
                    {
                        JsonElement _;
                        if (!e.TryGetProperty(k, out _)) return $"{path}.{k}: only in C# ({Show(m[k])})";
                    }
                }
                return null;
            }
        }
        return $"{path}: unexpected JSON {e.ValueKind}";
    }

    // --- the areas -----------------------------------------------------------------------

    static void Boards(JsonElement root)
    {
        foreach (var c in root.EnumerateArray())
        {
            string label = c.GetProperty("label").GetString();
            Check("makeBoard", label, () =>
            {
                var rand = new List<double>();
                foreach (var x in c.GetProperty("rand").EnumerateArray()) rand.Add(x.GetDouble());
                int idx = 0;
                Func<double> f = () =>
                {
                    if (idx >= rand.Count) throw new InvalidOperationException($"C# drew more than the JS's {rand.Count} random numbers");
                    return rand[idx++];
                };
                var b = Board.MakeBoard(BoardSpec(c.GetProperty("spec")), PoolOf(c.GetProperty("poolSize").GetInt32()), f, c.GetProperty("kinds").GetInt32());
                if (idx != rand.Count) return $"C# drew {idx} random numbers, the JS {rand.Count}";
                return Diff(c.GetProperty("board"), BoardTree(b), "board");
            });
        }
    }

    static void Plays(JsonElement root)
    {
        foreach (var c in root.EnumerateArray())
        {
            string label = c.GetProperty("label").GetString();
            var board = ParseBoard(c.GetProperty("board"));
            var st = Board.StartState(board);
            Check("startState", label, () => Diff(c.GetProperty("start"), StateTree(st), "start"));
            int n = 0;
            foreach (var s in c.GetProperty("steps").EnumerateArray())
            {
                int step = n++;
                var prev = st;
                DropResult r = null;
                Check("drop", label + " step " + step, () =>
                {
                    int k = s.GetProperty("k").GetInt32();
                    var t = s.GetProperty("t");
                    Place target = null;
                    if (t.ValueKind != JsonValueKind.Null)
                    {
                        JsonElement iv;
                        target = new Place(t.GetProperty("kind").GetString(), t.TryGetProperty("i", out iv) ? iv.GetInt32() : 0);
                    }
                    r = Board.Drop(board, prev, k, target);
                    var occ = new List<object>();
                    for (int i = -1; i <= board.Slots; i++) occ.Add(Board.Occupant(r.State, i));
                    var got = Obj("k", k, "o", r.Outcome, "b", r.Bumped, "same", ReferenceEquals(r.State, prev), "st", StateTree(r.State), "occ", occ, "sol", Board.Solved(board, r.State));
                    return Diff(Without(s, "t"), got, "step");
                });
                if (r == null) break; // threw: the rest can't line up
                st = r.State;
            }
        }
    }

    // the step's JSON without its input target (compared separately: it is the input)
    static JsonElement Without(JsonElement o, string key)
    {
        var d = new Dictionary<string, JsonElement>();
        foreach (var p in o.EnumerateObject()) if (p.Name != key) d[p.Name] = p.Value;
        return JsonSerializer.SerializeToElement(d);
    }

    static void LevelsArea(JsonElement root)
    {
        var k = root.GetProperty("constants");
        Check("constants", "constants", () =>
        {
            var list = new List<object>();
            foreach (var L in Levels.LEVEL_LIST) list.Add(Obj("band", L.Band, "model", L.Model, "rows", L.Rows, "cols", L.Cols, "base", L.Base, "tier", L.Tier, "first", L.First, "more", L.More));
            var starts = new List<object>();
            foreach (var s in Levels.MODEL_STARTS) starts.Add(s);
            var got = Obj("LEVELS", Levels.LEVELS, "LEVEL_LIST", list, "MODEL_STARTS", starts, "TIER_NAMES", Strings(Levels.TIER_NAMES), "TIER_COLORS", Strings(Levels.TIER_COLORS), "HEARTS", Levels.HEARTS,
                "SKILL_MIN", Levels.SKILL_MIN, "SKILL_MAX", Levels.SKILL_MAX,
                "THEME_KEYS", Strings(Levels.THEME_KEYS), "KINDS", Props.Kinds, "SIZE_NAMES", Strings(Models.SIZE_NAMES), "MODEL_COUNT", Models.MODEL_COUNT);
            return Diff(k, got, "constants");
        });
        foreach (var c in root.GetProperty("levelSpecs").EnumerateArray())
            Check("levelSpec", c.GetProperty("lv").GetRawText() + "@" + c.GetProperty("skill").GetRawText(), () =>
            {
                double lv = Num(c.GetProperty("lv")) ?? double.NaN;
                double? skill = Num(c.GetProperty("skill"));
                var s = skill == null ? Levels.LevelSpec(lv) : Levels.LevelSpec(lv, skill.Value);
                return Diff(c.GetProperty("out"), SpecTree(s), "spec");
            });
        foreach (var c in root.GetProperty("blitzSpecs").EnumerateArray())
            Check("blitzSpec", c.GetProperty("i").GetRawText() + "@" + c.GetProperty("skill").GetRawText(), () =>
            {
                double? skill = Num(c.GetProperty("skill"));
                int i = c.GetProperty("i").GetInt32();
                var s = skill == null ? Levels.BlitzSpec(i) : Levels.BlitzSpec(i, skill.Value);
                return Diff(c.GetProperty("out"), SpecTree(s), "spec");
            });
        foreach (var c in root.GetProperty("blitzCoins").EnumerateArray())
            Check("blitzCoins", c.GetRawText(), () => Diff(c.GetProperty("out"), Levels.BlitzCoins(Levels.BlitzSpec(c.GetProperty("i").GetInt32(), c.GetProperty("skill").GetDouble())), "coins"));
        foreach (var c in root.GetProperty("skillShifts").EnumerateArray())
            Check("skillShift", c.GetProperty("skill").GetRawText(), () => Diff(c.GetProperty("out"), Levels.SkillShift(c.GetProperty("skill").GetDouble()), "shift"));
        foreach (var c in root.GetProperty("nextSkills").EnumerateArray())
            Check("nextSkill", c.GetRawText(), () =>
            {
                double? skill = Num(c.GetProperty("skill"));
                double? stars = Num(c.GetProperty("stars"));
                double? mistakes = Num(c.GetProperty("mistakes"));
                var v = Levels.NextSkill(skill ?? 0, c.GetProperty("won").GetBoolean(), stars ?? 0, mistakes ?? 0);
                return Diff(c.GetProperty("out"), v, "skill");
            });
        foreach (var c in root.GetProperty("starsFor").EnumerateArray())
            Check("starsFor", c.GetRawText(), () => Diff(c.GetProperty("out"), Levels.StarsFor(SpecOf(c.GetProperty("spec")), Num(c.GetProperty("mistakes")), Num(c.GetProperty("ms"))), "stars"));
        foreach (var c in root.GetProperty("coins").EnumerateArray())
            Check("coinsFor", c.GetRawText(), () => Diff(c.GetProperty("out"), Levels.CoinsFor(SpecOf(c.GetProperty("spec")), c.GetProperty("stars").GetDouble()), "coins"));
        foreach (var c in root.GetProperty("xps").EnumerateArray())
            Check("xpFor", c.GetRawText(), () => Diff(c.GetProperty("out"), Levels.XpFor(SpecOf(c.GetProperty("spec")), c.GetProperty("stars").GetDouble()), "xp"));
        foreach (var c in root.GetProperty("clocks").EnumerateArray())
            Check("clock", c.GetRawText(), () => Diff(c.GetProperty("out"), Levels.Clock(c.GetProperty("ms").GetDouble()), "clock"));
        foreach (var c in root.GetProperty("models").EnumerateArray())
            Check("modelOf", c.GetRawText(), () =>
            {
                var m = Models.ModelOf(c.GetProperty("theme").GetString(), Num(c.GetProperty("i")) ?? double.NaN);
                return Diff(c.GetProperty("out"), Obj("kind", m.Kind, "key", m.Key, "name", m.Name, "size", m.Size, "index", m.Index), "model");
            });
    }

    static void Profiles(JsonElement root)
    {
        var configs = new List<IDictionary<string, object>>();
        foreach (var c in root.GetProperty("configs").EnumerateArray()) configs.Add(ToObj(c) as IDictionary<string, object>);
        var profiles = new List<IDictionary<string, object>>();
        foreach (var p in root.GetProperty("profiles").EnumerateArray()) profiles.Add((IDictionary<string, object>)ToObj(p));

        int n = 0;
        foreach (var c in root.GetProperty("records").EnumerateArray())
        {
            int idx = n++;
            Check("record", "profile " + idx, () =>
            {
                var p = (IDictionary<string, object>)ToObj(c.GetProperty("profile"));
                var rec = Levels.Record(p);
                return Diff(c.GetProperty("out"), RecordTree(rec), "record")
                    ?? Diff(c.GetProperty("starsIn"), new List<object> { Levels.StarsIn(rec, "fridge") }, "starsIn")
                    ?? Diff(c.GetProperty("doneIn"), new List<object> { Levels.DoneIn(rec, "fridge") }, "doneIn");
            });
        }
        foreach (var c in root.GetProperty("afterLevels").EnumerateArray())
            Check("afterLevel", c.GetProperty("theme").GetString() + " " + c.GetProperty("spec").GetRawText() + " " + c.GetProperty("result").GetRawText() + " config " + c.GetProperty("config").GetInt32() + " profile " + c.GetProperty("profile").GetInt32(), () =>
            {
                PlayerXp.SetLevelsConfig(configs[c.GetProperty("config").GetInt32()]);
                try
                {
                    var res = c.GetProperty("result");
                    bool won = res.GetProperty("won").GetBoolean();
                    var o = Levels.AfterLevel(profiles[c.GetProperty("profile").GetInt32()], c.GetProperty("theme").GetString(), SpecOf(c.GetProperty("spec")), won, Num(res.GetProperty("mistakes")), Num(res.GetProperty("ms")));
                    return Diff(c.GetProperty("out"), OutcomeTree(o, true, won), "out");
                }
                finally { PlayerXp.SetLevelsConfig(null); }
            });
        foreach (var c in root.GetProperty("afterBlitzes").EnumerateArray())
            Check("afterBlitz", c.GetRawText().Length > 200 ? "config " + c.GetProperty("config").GetInt32() + " profile " + c.GetProperty("profile").GetInt32() : c.GetRawText(), () =>
            {
                PlayerXp.SetLevelsConfig(configs[c.GetProperty("config").GetInt32()]);
                try
                {
                    double cleared = c.GetProperty("cleared").GetDouble();
                    var o = Levels.AfterBlitz(profiles[c.GetProperty("profile").GetInt32()], cleared);
                    return Diff(c.GetProperty("out"), OutcomeTree(o, false, cleared > 0), "out");
                }
                finally { PlayerXp.SetLevelsConfig(null); }
            });
        foreach (var c in root.GetProperty("prizes").EnumerateArray())
            Check("blitzPrize", c.GetRawText(), () =>
            {
                PlayerXp.SetLevelsConfig(configs[c.GetProperty("config").GetInt32()]);
                try
                {
                    var (coins, xp) = Levels.BlitzPrize(c.GetProperty("cleared").GetDouble(), c.GetProperty("skill").GetDouble());
                    return Diff(c.GetProperty("out"), Obj("coins", coins, "xp", xp), "prize");
                }
                finally { PlayerXp.SetLevelsConfig(null); }
            });
    }
}
