// Squish Hop's differential test, the C# half. Loads fixtures/*.json (inputs + the JS outputs, from fixtures.mjs),
// runs the same inputs through SquishSquad.Games.Hop and compares the results deeply: numbers exactly (board geometry
// within 1e-9, relative), strings, bools, nulls, list lengths and object keys in order. Prints pass counts per area
// and the first mismatches; exits 1 on any mismatch.
//
//   node tools/unity/games/hop/fixtures.mjs && dotnet run -c Release --project tools/unity/games/hop/hop-test.csproj
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using SquishSquad.Games.Hop;

namespace HopTest
{
    static class Program
    {
        static string dir;
        static int totalFail;
        static readonly List<string> report = new List<string>();

        static int Main(string[] args)
        {
            dir = args.Length > 0 ? args[0] : FindFixtures();
            if (!File.Exists(Path.Combine(dir, "parse.json")))
            {
                Console.Error.WriteLine($"no fixtures in {dir}: run node tools/unity/games/hop/fixtures.mjs first");
                return 2;
            }
            Run("parse", ParseArea);
            Run("walks", WalksArea);
            Run("search", SearchArea);
            Run("levels", LevelsArea);
            Run("profile", ProfileArea);
            Run("board", BoardArea);
            Console.WriteLine();
            foreach (var r in report) Console.WriteLine(r);
            Console.WriteLine(totalFail == 0 ? "\nALL PASS: 0 mismatches" : $"\nFAIL: {totalFail} mismatches");
            return totalFail == 0 ? 0 : 1;
        }

        static string FindFixtures()
        {
            var d = AppContext.BaseDirectory;
            for (int i = 0; i < 8 && d != null; i++)
            {
                var f = Path.Combine(d, "fixtures");
                if (File.Exists(Path.Combine(f, "parse.json"))) return f;
                d = Path.GetDirectoryName(d.TrimEnd(Path.DirectorySeparatorChar));
            }
            return Path.Combine(Directory.GetCurrentDirectory(), "tools/unity/games/hop/fixtures");
        }

        // ---- the comparison -------------------------------------------------------------------------------------

        sealed class Area
        {
            public string Name;
            public int Pass, Fail;
            public readonly List<string> First = new List<string>();
        }
        static Area cur;

        static void Run(string name, Action<JsonElement> fn)
        {
            cur = new Area { Name = name };
            var sw = Stopwatch.StartNew();
            using (var doc = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(dir, name + ".json")), new JsonDocumentOptions { MaxDepth = 256 }))
            {
                try { fn(doc.RootElement); }
                catch (Exception e) { Fail($"{name}: crashed: {e}"); }
            }
            Console.WriteLine($"{name,-8} {cur.Pass,7} pass {cur.Fail,5} fail   ({sw.ElapsedMilliseconds} ms)");
            foreach (var f in cur.First) Console.WriteLine("    " + f);
            report.Add($"{name,-8} {cur.Pass} / {cur.Pass + cur.Fail}");
            totalFail += cur.Fail;
        }

        static void Fail(string msg)
        {
            cur.Fail++;
            if (cur.First.Count < 8) cur.First.Add(msg.Length > 1500 ? msg.Substring(0, 1500) + "…" : msg);
        }

        // one checked item: expected (the JS output) against the C# tree
        static bool Check(string what, JsonElement exp, object act, double tol = 0)
        {
            string why = Diff(exp, act, "", tol);
            if (why == null) { cur.Pass++; return true; }
            Fail($"{what}: {why}");
            return false;
        }

        static bool IsNum(object a) { return a is int || a is long || a is double || a is float || a is uint; }
        static double Num(object a) { return Convert.ToDouble(a, System.Globalization.CultureInfo.InvariantCulture); }

        static string Show(object a)
        {
            if (a == null) return "null";
            if (a is string s) return "\"" + s + "\"";
            if (a is bool b) return b ? "true" : "false";
            if (IsNum(a)) return Num(a).ToString("R", System.Globalization.CultureInfo.InvariantCulture);
            if (a is IDictionary<string, object> d) return "{" + string.Join(",", d.Select(kv => kv.Key + ":" + Show(kv.Value))) + "}";
            if (a is IEnumerable e) return "[" + string.Join(",", e.Cast<object>().Select(Show)) + "]";
            return a.ToString();
        }

        static string Clip(string s) { return s.Length > 300 ? s.Substring(0, 300) + "…" : s; }

        static string Diff(JsonElement e, object a, string at, double tol)
        {
            switch (e.ValueKind)
            {
                case JsonValueKind.Null:
                    return a == null ? null : $"{at}: JS null, C# {Clip(Show(a))}";
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return a is bool b && b == (e.ValueKind == JsonValueKind.True) ? null : $"{at}: JS {e}, C# {Clip(Show(a))}";
                case JsonValueKind.String:
                    return a is string s && s == e.GetString() ? null : $"{at}: JS \"{e.GetString()}\", C# {Clip(Show(a))}";
                case JsonValueKind.Number:
                {
                    if (!IsNum(a)) return $"{at}: JS {e}, C# {Clip(Show(a))}";
                    double x = e.GetDouble(), y = Num(a);
                    if (x == y) return null;
                    if (tol > 0 && Math.Abs(x - y) <= tol * Math.Max(1, Math.Max(Math.Abs(x), Math.Abs(y)))) return null;
                    return $"{at}: JS {x:R}, C# {y:R}";
                }
                case JsonValueKind.Array:
                {
                    if (a == null || a is string || a is IDictionary<string, object> || !(a is IEnumerable)) return $"{at}: JS array, C# {Clip(Show(a))}";
                    var list = ((IEnumerable)a).Cast<object>().ToList();
                    int n = e.GetArrayLength();
                    if (n != list.Count) return $"{at}: JS {n} items, C# {list.Count}: JS {Clip(e.ToString())} C# {Clip(Show(a))}";
                    int i = 0;
                    foreach (var item in e.EnumerateArray())
                    {
                        var w = Diff(item, list[i], at + "[" + i + "]", tol);
                        if (w != null) return w;
                        i++;
                    }
                    return null;
                }
                case JsonValueKind.Object:
                {
                    if (e.TryGetProperty("$num", out var special))
                    {
                        double y = IsNum(a) ? Num(a) : double.NaN;
                        string sv = special.GetString();
                        bool ok = IsNum(a) && (sv == "NaN" ? double.IsNaN(y) : sv == "Infinity" ? double.IsPositiveInfinity(y) : double.IsNegativeInfinity(y));
                        return ok ? null : $"{at}: JS {sv}, C# {Clip(Show(a))}";
                    }
                    if (!(a is IDictionary<string, object> d)) return $"{at}: JS object, C# {Clip(Show(a))}";
                    var keys = e.EnumerateObject().Select(p => p.Name).ToList();
                    if (!keys.SequenceEqual(d.Keys)) return $"{at}: keys JS [{string.Join(",", keys)}], C# [{string.Join(",", d.Keys)}]";
                    foreach (var p in e.EnumerateObject())
                    {
                        var w = Diff(p.Value, d[p.Name], at + "." + p.Name, tol);
                        if (w != null) return w;
                    }
                    return null;
                }
            }
            return $"{at}: unexpected JSON {e.ValueKind}";
        }

        // ---- JSON inputs -> C# values --------------------------------------------------------------------------

        static object Decode(JsonElement e)
        {
            switch (e.ValueKind)
            {
                case JsonValueKind.Null: return null;
                case JsonValueKind.True: return true;
                case JsonValueKind.False: return false;
                case JsonValueKind.String: return e.GetString();
                case JsonValueKind.Number: return e.GetDouble();
                case JsonValueKind.Array: return e.EnumerateArray().Select(Decode).ToList();
                case JsonValueKind.Object:
                    if (e.TryGetProperty("$num", out var s)) return D(e);
                    var d = new Dictionary<string, object>();
                    foreach (var p in e.EnumerateObject()) d[p.Name] = Decode(p.Value);
                    return d;
            }
            throw new Exception("bad JSON " + e.ValueKind);
        }

        static double D(JsonElement e)
        {
            if (e.ValueKind == JsonValueKind.Number) return e.GetDouble();
            if (e.ValueKind == JsonValueKind.Object && e.TryGetProperty("$num", out var s))
                return s.GetString() == "NaN" ? double.NaN : s.GetString() == "Infinity" ? double.PositiveInfinity : double.NegativeInfinity;
            throw new Exception("not a number: " + e);
        }
        static int I(JsonElement e) { return (int)D(e); }
        static bool Has(JsonElement e, string k, out JsonElement v)
        {
            v = default;
            return e.ValueKind == JsonValueKind.Object && e.TryGetProperty(k, out v) && v.ValueKind != JsonValueKind.Null;
        }
        static string[] Rows(JsonElement e) { return e.EnumerateArray().Select(x => x.GetString()).ToArray(); }
        static int[] Ints(JsonElement e) { return e.EnumerateArray().Select(I).ToArray(); }

        static HopState State(JsonElement e)
        {
            return new HopState { Cur = I(e.GetProperty("cur")), Life = Ints(e.GetProperty("life")), Got = I(e.GetProperty("got")), Hops = I(e.GetProperty("hops")), Done = e.GetProperty("done").GetBoolean() };
        }

        // ---- C# results -> trees shaped like the JS objects -------------------------------------------------------

        static Dictionary<string, object> O(params object[] kv)
        {
            var d = new Dictionary<string, object>();
            for (int i = 0; i < kv.Length; i += 2) d[(string)kv[i]] = kv[i + 1];
            return d;
        }

        static object T(Level lv)
        {
            return O("w", lv.W, "h", lv.H, "life", lv.Life, "start", lv.Start, "goal", lv.Goal, "friends", lv.Friends, "nb", lv.Nb, "nbrs", lv.Nbrs,
                "fbit", lv.Fbit, "need", lv.Need, "order", lv.Order, "arrow", lv.Arrow, "bubble", lv.Bubble, "beat", lv.Beat, "all", lv.All);
        }
        static object T(HopState s) { return O("cur", s.Cur, "life", s.Life, "got", s.Got, "hops", s.Hops, "done", s.Done); }
        static object T(MoveResult m)
        {
            if (m.Ok) return O("ok", true, "cells", m.Cells, "st", T(m.St));
            var d = O("ok", false, "why", m.Why, "cell", m.Cell);
            if (m.HasAt) d["at"] = m.At;
            return d;
        }
        static object T(Move m) { return O("d", m.D, "cells", m.Cells, "st", T(m.St)); }
        static object T(SearchResult r) { return O("path", r.Path, "sols", r.Sols, "count", r.Count, "nodes", r.Nodes, "aborted", r.Aborted); }
        static object T(ReplayResult r) { return O("ok", r.Ok, "steps", r.Steps.Select(T).ToList(), "st", T(r.St)); }
        static object T(LevelSpec s)
        {
            return O("lv", s.Lv, "map", s.Map, "tier", s.Tier, "news", s.News, "sols", s.Sols, "effort", s.Effort, "board", T(s.Board), "sol", s.Sol,
                "room", s.Room, "phase", s.Phase, "stageKey", s.StageKey, "beats", s.Beats, "cushions", s.Cushions, "twists", s.Twists);
        }
        static object T(Stage s) { return O("room", s.Room, "phase", s.Phase, "key", s.Key); }
        static object T(PlayerLevelInfo p) { return O("level", p.Level, "into", p.Into, "need", p.Need); }
        static object T(ScreenPoint p) { return O("x", p.X, "y", p.Y, "s", p.S); }
        static object T(BoardLayout B) { return O("w", B.W, "h", B.H, "T", B.T, "cx", B.Cx, "cy", B.Cy, "tilt", B.Tilt, "c", B.C, "sn", B.Sn); }
        static object T(CellBox b) { return O("left", b.Left, "top", b.Top, "width", b.Width, "height", b.Height); }

        // mulberry32, as fixtures.mjs has it
        static Func<double> Mulberry32(uint a)
        {
            return () =>
            {
                a += 0x6d2b79f5;
                uint t = (a ^ (a >> 15)) * (1 | a);
                t = (t + (t ^ (t >> 7)) * (61 | t)) ^ t;
                return (t ^ (t >> 14)) / 4294967296.0;
            };
        }

        // ---- the areas -------------------------------------------------------------------------------------------

        static void ParseArea(JsonElement root)
        {
            var c = root.GetProperty("consts");
            Check("DIRS", c.GetProperty("DIRS"), Engine.DIRS);
            Check("DCH", c.GetProperty("DCH"), Engine.DCH);
            Check("ARROWS", c.GetProperty("ARROWS"), Engine.ARROWS.ToDictionary(kv => kv.Key.ToString(), kv => (object)kv.Value));
            Check("BEATS", c.GetProperty("BEATS"), Engine.BEATS.ToDictionary(kv => kv.Key.ToString(), kv => (object)kv.Value));
            foreach (var cs in root.GetProperty("cases").EnumerateArray())
            {
                string name = cs.GetProperty("name").GetString();
                var rows = Rows(cs.GetProperty("rows"));
                Level lv = null;
                string err = null;
                try { lv = Engine.Parse(rows); }
                catch (ArgumentException e) { err = e.Message; }
                if (cs.TryGetProperty("error", out var je))
                {
                    string jm = je.GetString();
                    // JS's other error is the RangeError of new Array(NaN) for no rows; any throw matches that
                    if (err == null) Fail($"{name}: JS threw '{jm}', C# parsed");
                    else if (jm == "a level needs S and G" && err != jm) Fail($"{name}: JS '{jm}', C# '{err}'");
                    else cur.Pass++;
                    continue;
                }
                if (err != null) { Fail($"{name}: C# threw '{err}'"); continue; }
                Check(name, cs.GetProperty("out"), O("lv", T(lv), "newState", T(Engine.NewState(lv)), "leftOf", Engine.LeftOf(lv, lv.Life), "parityOk", Engine.ParityOk(lv)));
            }
        }

        static void WalksArea(JsonElement root)
        {
            foreach (var w in root.EnumerateArray())
            {
                string name = w.GetProperty("name").GetString();
                var lv = Engine.Parse(Rows(w.GetProperty("rows")));
                var st = Engine.NewState(lv);
                int k = 0;
                foreach (var step in w.GetProperty("steps").EnumerateArray())
                {
                    string at = $"{name} step {k++}";
                    Check(at + " state", step.GetProperty("st"), T(st));
                    Check(at + " moves", step.GetProperty("moves"), Engine.Moves(lv, st).Select(T).ToList());
                    var blocks = step.GetProperty("blocks");
                    if (blocks.GetArrayLength() > 0)
                        Check(at + " blockOf", blocks, Enumerable.Range(0, 4).Select(d => Engine.BlockOf(lv, st.Life, st.Got, st.Hops, lv.Nb[st.Cur][d])).ToList());
                    var probe = Ints(step.GetProperty("probe"));
                    Check(at + " blockOf probes", step.GetProperty("probes"), probe.Select(j => Engine.BlockOf(lv, st.Life, st.Got, st.Hops, j)).ToList());
                    Check(at + " leftOf", step.GetProperty("left"), Engine.LeftOf(lv, st.Life));
                    var res = Engine.TryMove(lv, st, I(step.GetProperty("d")));
                    Check(at + " tryMove", step.GetProperty("res"), T(res));
                    if (res.Ok) st = res.St;
                }
                Check(name + " end", w.GetProperty("end"), T(st));
                int r = 0;
                foreach (var rp in w.GetProperty("replays").EnumerateArray())
                {
                    var s0 = Has(rp, "st0", out var sj) ? State(sj) : null;
                    Check($"{name} replay {r++}", rp.GetProperty("out"), T(Engine.Replay(lv, Ints(rp.GetProperty("dirs")), s0)));
                }
            }
        }

        static void SearchArea(JsonElement root)
        {
            var times = new List<Tuple<double, double, string, int>>();
            foreach (var cs in root.GetProperty("cases").EnumerateArray())
            {
                string name = cs.GetProperty("name").GetString();
                var lv = Engine.Parse(Rows(cs.GetProperty("rows")));
                var st = Has(cs, "st", out var sj) ? State(sj) : Engine.NewState(lv);
                var o = cs.GetProperty("opts");
                var opts = new SearchOptions();
                if (Has(o, "limit", out var l)) opts.Limit = D(l);
                if (Has(o, "count", out var cnt)) opts.Count = cnt.GetBoolean();
                if (Has(o, "cap", out var cap)) opts.Cap = I(cap);
                if (Has(cs, "seed", out var seed)) opts.Rand = Mulberry32((uint)I(seed));
                var stateBefore = (int[])st.Life.Clone();
                var sw = Stopwatch.StartNew();
                var r = Engine.Search(lv, st, opts);
                times.Add(Tuple.Create(sw.Elapsed.TotalMilliseconds, D(cs.GetProperty("ms")), name, r.Nodes));
                Check(name, cs.GetProperty("out"), T(r));
                if (!stateBefore.SequenceEqual(st.Life)) Fail($"{name}: search changed the state it was given");
            }
            Console.WriteLine("  slowest fixture searches (single run, C# first-call JIT included):");
            foreach (var t in times.OrderByDescending(t => t.Item1).Take(4))
                Console.WriteLine($"    {t.Item3,-24} {t.Item4,6} nodes   JS {t.Item2,7:F2} ms   C# {t.Item1,7:F2} ms");
            Console.WriteLine("  search timing, hardest levels (default search from the start; best of 5 after warm-up):");
            foreach (var t in root.GetProperty("timing").EnumerateArray())
            {
                int level = I(t.GetProperty("level"));
                var lv = Engine.Parse(Levels.LevelSpec(level).Map);
                double best = double.MaxValue;
                int nodes = 0;
                for (int k = 0; k < 6; k++)
                {
                    var sw = Stopwatch.StartNew();
                    var r = Engine.Search(lv, Engine.NewState(lv));
                    double ms = sw.Elapsed.TotalMilliseconds;
                    if (k > 0) best = Math.Min(best, ms);
                    nodes = r.Nodes;
                }
                Console.WriteLine($"    level {level,3}: {nodes,6} nodes   JS {D(t.GetProperty("ms")),7:F2} ms   C# {best,7:F2} ms");
            }
        }

        static object RoomTree(RoomInfo r)
        {
            var d = O("name", r.Name, "floor", r.Floor, "cx", r.Cx);
            if (r.Cushion != null) d["cushion"] = r.Cushion;
            if (r.Rug) d["rug"] = true;
            if (r.Dance) d["dance"] = true;
            d["bg"] = r.Bg;
            if (r.Dent != null) d["dent"] = r.Dent;
            return d;
        }

        static void LevelsArea(JsonElement root)
        {
            var c = root.GetProperty("consts");
            Check("LEVELS", c.GetProperty("LEVELS"), Levels.LEVELS);
            Check("TIER_NAMES", c.GetProperty("TIER_NAMES"), Levels.TIER_NAMES);
            Check("TIER_COLORS", c.GetProperty("TIER_COLORS"), Levels.TIER_COLORS);
            var rooms = new Dictionary<string, object>();
            foreach (var r in Levels.ROOM_LIST) rooms[r.Key] = RoomTree(r);
            Check("ROOMS", c.GetProperty("ROOMS"), rooms);
            var tw = new Dictionary<string, object>();
            foreach (var t in Levels.TWIST_LIST) tw[t.Key] = O("name", t.Name, "text", t.Text, "sub", t.Sub);
            Check("TWISTS", c.GetProperty("TWISTS"), tw);
            Check("CHAPTERS", c.GetProperty("CHAPTERS"), Levels.CHAPTERS.Select(ch => O("room", ch.Room, "from", ch.From, "to", ch.To)).ToList());
            Check("LEVEL_LIST", c.GetProperty("LEVEL_LIST"), Levels.LEVEL_LIST.Select(e => O("band", e.Band, "room", e.Room, "tier", e.Tier, "news", e.News)).ToList());
            Check("LEVEL_DATA", c.GetProperty("LEVEL_DATA"), LevelData.All.Select(d => O("map", d.Map, "room", d.Room, "tier", d.Tier, "news", d.News, "sols", d.Sols, "effort", d.Effort, "solution", d.Solution)).ToList());
            foreach (var s in root.GetProperty("specs").EnumerateArray())
                Check($"levelSpec({s.GetProperty("in")})", s.GetProperty("out"), T(Levels.LevelSpec(D(s.GetProperty("in")))));
            foreach (var s in root.GetProperty("stages").EnumerateArray())
                Check($"stageOf({s.GetProperty("in")})", s.GetProperty("out"), T(Levels.StageOf(D(s.GetProperty("in")))));
            foreach (var s in root.GetProperty("stars").EnumerateArray())
            {
                int left = I(s.GetProperty("left"));
                bool h = s.GetProperty("hinted").GetBoolean();
                Check($"starsFor({left}, {h})", s.GetProperty("out"), Levels.StarsFor(left, h));
                Check($"engine starsFor({left}, {h})", s.GetProperty("eng"), Engine.StarsFor(left, h));
            }
            var specs = new Dictionary<int, LevelSpec>();
            Func<int, LevelSpec> spec = lv => specs.TryGetValue(lv, out var x) ? x : (specs[lv] = Levels.LevelSpec(lv));
            foreach (var s in root.GetProperty("coins").EnumerateArray())
                Check($"coinsFor({s.GetProperty("lv")}, {s.GetProperty("stars")})", s.GetProperty("out"), Levels.CoinsFor(spec(I(s.GetProperty("lv"))), I(s.GetProperty("stars"))));
            foreach (var s in root.GetProperty("xps").EnumerateArray())
                Check($"xpFor({s.GetProperty("lv")}, {s.GetProperty("stars")})", s.GetProperty("out"), Levels.XpFor(spec(I(s.GetProperty("lv"))), D(s.GetProperty("stars"))));
        }

        static void ProfileArea(JsonElement root)
        {
            var profiles = root.GetProperty("profiles").EnumerateArray().Select(p => Decode(p) as IDictionary<string, object>).ToList();
            int i = 0;
            foreach (var r in root.GetProperty("records").EnumerateArray())
            {
                var p = Decode(r.GetProperty("profile")) as IDictionary<string, object>;
                string at = $"profile {i++} {Clip(Show(p))}";
                var rec = Levels.Record(p);
                Check(at + " record", r.GetProperty("out"), O("lv", rec.Lv, "best", rec.Best, "plays", rec.Plays, "wins", rec.Wins, "seen", rec.Seen));
                Check(at + " starsOf", r.GetProperty("starsOf"), Levels.StarsOf(rec));
                Check(at + " doneOf", r.GetProperty("doneOf"), Levels.DoneOf(rec));
                Check(at + " afterStuck", r.GetProperty("afterStuck"), Levels.AfterStuck(p));
            }
            foreach (var a in root.GetProperty("after").EnumerateArray())
            {
                PlayerXp.SetLevelsConfig(Decode(a.GetProperty("config")) as IDictionary<string, object>);
                int pi = I(a.GetProperty("profile"));
                int lv = I(a.GetProperty("lv"));
                var res = a.GetProperty("result");
                var hr = new HopResult { Left = I(res.GetProperty("left")), Hinted = res.TryGetProperty("hinted", out var h) && Js.Truthy(Decode(h)) };
                var o = Levels.AfterLevel(profiles[pi], Levels.LevelSpec(lv), hr);
                Check($"afterLevel(profile {pi} {Clip(Show(profiles[pi]))}, {lv}, {res}) config {a.GetProperty("config")}", a.GetProperty("out"),
                    O("update", o.Update, "coins", o.Coins, "xp", o.Xp, "before", T(o.Before), "after", T(o.After), "levelUps", o.LevelUps, "stars", o.Stars, "unlocked", o.Unlocked));
            }
            PlayerXp.SetLevelsConfig(null);
        }

        static double? Opt(JsonElement e, string k) { return Has(e, k, out var v) ? D(v) : (double?)null; }

        static void BoardArea(JsonElement root)
        {
            const double tol = 1e-9;
            Check("TILT", root.GetProperty("TILT"), BoardGeometry.TILT);
            Check("DEPTH", root.GetProperty("DEPTH"), BoardGeometry.DEPTH);
            foreach (var c in root.GetProperty("cases").EnumerateArray())
            {
                var a = c.GetProperty("args").EnumerateArray().ToList();
                double? arg(int k) { return k < a.Count && a[k].ValueKind != JsonValueKind.Null ? D(a[k]) : (double?)null; }
                int w = I(a[0]), h = I(a[1]);
                double aw = D(a[2]), ah = D(a[3]);
                BoardLayout B;
                // pass exactly the arguments JS was given (a null is JS's undefined: the default)
                if (a.Count <= 4) B = BoardGeometry.Layout(w, h, aw, ah);
                else if (a.Count == 5) B = BoardGeometry.Layout(w, h, aw, ah, arg(4) ?? 0);
                else if (a.Count == 6) B = BoardGeometry.Layout(w, h, aw, ah, arg(4) ?? 0, arg(5) ?? BoardGeometry.TILT);
                else B = BoardGeometry.Layout(w, h, aw, ah, arg(4) ?? 0, arg(5) ?? BoardGeometry.TILT, arg(6) ?? 96);
                string at = $"layout({c.GetProperty("args")})";
                Check(at, c.GetProperty("B"), T(B), tol);
                foreach (var p in c.GetProperty("project").EnumerateArray())
                {
                    double? z = Opt(p, "z");
                    var r = z == null ? BoardGeometry.Project(B, D(p.GetProperty("u")), D(p.GetProperty("v"))) : BoardGeometry.Project(B, D(p.GetProperty("u")), D(p.GetProperty("v")), z.Value);
                    Check($"{at} project({p.GetProperty("u")}, {p.GetProperty("v")}, {z})", p.GetProperty("out"), T(r), tol);
                }
                foreach (var p in c.GetProperty("cellAt").EnumerateArray())
                    Check($"{at} cellAt({p.GetProperty("sx")}, {p.GetProperty("sy")})", p.GetProperty("out"), BoardGeometry.CellAt(B, D(p.GetProperty("sx")), D(p.GetProperty("sy"))));
                foreach (var p in c.GetProperty("standOn").EnumerateArray())
                {
                    double? z = Opt(p, "z");
                    int i = I(p.GetProperty("i"));
                    Check($"{at} standOn({i}, {z})", p.GetProperty("out"), T(z == null ? BoardGeometry.StandOn(B, i) : BoardGeometry.StandOn(B, i, z.Value)), tol);
                }
                foreach (var p in c.GetProperty("cellBox").EnumerateArray())
                {
                    double? z = Opt(p, "z"), pad = Opt(p, "pad");
                    double x = D(p.GetProperty("x")), y = D(p.GetProperty("y"));
                    var r = z == null ? BoardGeometry.CellBoxOf(B, x, y) : pad == null ? BoardGeometry.CellBoxOf(B, x, y, z.Value) : BoardGeometry.CellBoxOf(B, x, y, z.Value, pad.Value);
                    Check($"{at} cellBox({x}, {y}, {z}, {pad})", p.GetProperty("out"), T(r));
                }
                foreach (var p in c.GetProperty("roundRect").EnumerateArray())
                {
                    var g = p.GetProperty("args").EnumerateArray().Select(D).ToArray();
                    Check($"{at} roundRect({p.GetProperty("args")})", p.GetProperty("out"), BoardGeometry.RoundRect(B, g[0], g[1], g[2], g[3], g[4], g[5], g[6], g[7]));
                }
                foreach (var p in c.GetProperty("polyPath").EnumerateArray())
                {
                    var pts = p.GetProperty("pts").EnumerateArray().Select(q => q.EnumerateArray().Select(D).ToArray()).ToList();
                    Check($"{at} polyPath({p.GetProperty("pts")})", p.GetProperty("out"), BoardGeometry.PolyPath(B, pts, D(p.GetProperty("z")), D(p.GetProperty("ox")), D(p.GetProperty("oy"))));
                }
                foreach (var p in c.GetProperty("chevron").EnumerateArray())
                    Check($"chevron({p})", p.GetProperty("out"), BoardGeometry.Chevron(D(p.GetProperty("u")), D(p.GetProperty("v")), I(p.GetProperty("dir")), D(p.GetProperty("size"))), tol);
            }
            foreach (var f in root.GetProperty("fixed").EnumerateArray())
                Check($"toFixed({f.GetProperty("x")}, 1)", f.GetProperty("out"), Js.ToFixed(D(f.GetProperty("x")), 1));
        }
    }
}
