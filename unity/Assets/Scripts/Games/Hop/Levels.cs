// Squish Hop's levels, rooms, scoring and rewards, and the profile's `hop` record they're saved in. A port of
// src/hop/levels.js (SQUISH_HOP.md); keep the two the same. Pure functions: the screen writes what they return.
//
// Every level is fixed: LevelData.g.cs (generated from src/hop/levelData.js) holds each board, made and checked by the
// solver ahead of time. A level's tier is how hard its board measured against the other levels. The levels walk
// through the Crib's rooms, each bringing in a twist, and the time of day moves on through each room's levels.
//
// Profiles are Firestore documents as IDictionary<string, object> (numbers double, maps IDictionary<string, object>);
// the update a win writes is a patch keyed like "hop.plays".
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquishSquad.Games.Hop
{
    // one entry of levelData.js
    public sealed class LevelDef
    {
        public string[] Map;
        public string Room;
        public int Tier;        // 0 EASY … 3 EXPERT
        public string News;     // the twist it brings in, or null
        public int Sols;        // how many full clears there are
        public int Effort;      // how many moves the solver tries before it finds the clear
        public string Solution; // the clear, as U R D L moves

        public LevelDef(string[] map, string room, int tier, string news, int sols, int effort, string solution)
        {
            Map = map; Room = room; Tier = tier; News = news; Sols = sols; Effort = effort; Solution = solution;
        }
    }

    public sealed class RoomInfo
    {
        public string Key;
        public string Name;
        public double Floor;    // where the floor starts in the 852 × 393 scene (FLOOR_TOP / SCENE_H)
        public double Cx;       // the part of the room to show on a phone (0 left … 1 right)
        public string Cushion;  // the cushion colour (null for the Dance Room)
        public bool Rug;
        public bool Dance;
        public string Bg;
        public string Dent;     // the dent a cushion leaves (null: the default)
    }

    public sealed class TwistInfo
    {
        public string Key, Name, Text, Sub;
    }

    public sealed class Chapter
    {
        public string Room;
        public int From, To;    // 1-based levels
    }

    public sealed class LevelListEntry
    {
        public int Band;
        public string Room;
        public int Tier;
        public string News;
    }

    public sealed class Stage
    {
        public string Room, Phase, Key;
    }

    public sealed class LevelSpec
    {
        public int Lv;
        public string[] Map;
        public int Tier;
        public string News;
        public int Sols;
        public int Effort;
        public Level Board;
        public int[] Sol;           // the full clear as directions
        public string Room, Phase, StageKey;
        public bool Beats;
        public int Cushions;
        public List<string> Twists;
    }

    // record(): the profile's `hop` record
    public sealed class HopRecord
    {
        public int Lv;
        public IDictionary<string, object> Best;    // level ("5") -> stars; the profile's own map when it has one
        public double Plays;
        public double Wins;
        public bool Seen;
    }

    // afterLevel()'s `result`
    public sealed class HopResult
    {
        public int Left;
        public bool Hinted;
    }

    // afterLevel(): { update, coins, xp, before, after, levelUps, stars, unlocked }
    public sealed class AfterLevelResult
    {
        public Dictionary<string, object> Update;
        public int Coins;
        public double Xp;
        public PlayerLevelInfo Before, After;
        public List<int> LevelUps;
        public int Stars;
        public bool Unlocked;
    }

    public static class Levels
    {
        public static readonly int LEVELS = LevelData.All.Length;

        public static readonly string[] TIER_NAMES = { "EASY", "MEDIUM", "HARD", "EXPERT" };
        public static readonly string[] TIER_COLORS = { "#3ddc97", "#5fb8ff", "#ff8a4a", "#e01e4a" };

        // The Crib's rooms (src/crib/roomArt.js), in levels.js order
        public static readonly RoomInfo[] ROOM_LIST =
        {
            new RoomInfo { Key = "living", Name = "Living Room", Floor = 200.0 / 393, Cx = 0.5, Cushion = "mint", Rug = true, Bg = "#dba163" },
            new RoomInfo { Key = "kitchen", Name = "Kitchen", Floor = 236.0 / 393, Cx = 0.42, Cushion = "lilac", Bg = "#efc499" },
            new RoomInfo { Key = "bath", Name = "Bathroom", Floor = 236.0 / 393, Cx = 0.45, Cushion = "pink", Bg = "#ffffff", Dent = "rgba(60,110,150,0.45)" },
            new RoomInfo { Key = "bed", Name = "Bedroom", Floor = 212.0 / 393, Cx = 0.5, Cushion = "lilac", Bg = "#dba163" },
            new RoomInfo { Key = "yard", Name = "Yard", Floor = 214.0 / 393, Cx = 0.66, Cushion = "pink", Bg = "#96cb74", Dent = "rgba(255,255,255,0.8)" },
            new RoomInfo { Key = "dance", Name = "Dance Room", Floor = 200.0 / 393, Cx = 0.24, Dance = true, Bg = "#3b2030" },
        };
        public static readonly Dictionary<string, RoomInfo> ROOMS = ROOM_LIST.ToDictionary(r => r.Key);

        // the time of day through a room's levels, from the phases its art has
        static readonly string[] PHASE_ORDER = { "morning", "day", "evening", "night" };
        static readonly Dictionary<string, string[]> PHASES_OF = new Dictionary<string, string[]>
        {
            { "living", PHASE_ORDER }, { "kitchen", PHASE_ORDER }, { "bath", new[] { "day" } },
            { "bed", PHASE_ORDER }, { "yard", PHASE_ORDER }, { "dance", new[] { "day" } },
        };

        // what each twist is called on the map and in the banner that brings it in, in levels.js order
        public static readonly TwistInfo[] TWIST_LIST =
        {
            new TwistInfo { Key = "friends", Name = "FRIENDS", Text = "FRIENDS!", Sub = "The ★ opens when everyone is with you" },
            new TwistInfo { Key = "arrows", Name = "ARROWS", Text = "ARROWS!", Sub = "Hop off an arrow cushion the way it points" },
            new TwistInfo { Key = "bubbles", Name = "BUBBLES", Text = "BUBBLES!", Sub = "Land on a bubble and it bounces you one further" },
            new TwistInfo { Key = "piles", Name = "PILES", Text = "PILES!", Sub = "Two cushions on top of each other take two hops" },
            new TwistInfo { Key = "ordered", Name = "IN ORDER", Text = "IN ORDER!", Sub = "Pick the friends up 1, 2, 3…" },
            new TwistInfo { Key = "beats", Name = "ON THE BEAT", Text = "ON THE BEAT!", Sub = "Coloured tiles light up every third hop. Land on them lit" },
        };
        public static readonly Dictionary<string, TwistInfo> TWISTS = TWIST_LIST.ToDictionary(t => t.Key);

        // The rooms in level order (runs of the same room in the level data): the map's bands.
        public static readonly List<Chapter> CHAPTERS = BuildChapters();

        // the map's list: a band per room
        public static readonly List<LevelListEntry> LEVEL_LIST = BuildList();

        static List<Chapter> BuildChapters()
        {
            var chs = new List<Chapter>();
            for (int i = 0; i < LevelData.All.Length; i++)
            {
                var L = LevelData.All[i];
                var last = chs.Count > 0 ? chs[chs.Count - 1] : null;
                if (last != null && last.Room == L.Room) last.To = i + 1;
                else chs.Add(new Chapter { Room = L.Room, From = i + 1, To = i + 1 });
            }
            return chs;
        }

        static List<LevelListEntry> BuildList()
        {
            var list = new List<LevelListEntry>();
            for (int i = 0; i < LevelData.All.Length; i++)
            {
                var L = LevelData.All[i];
                list.Add(new LevelListEntry { Band = ChapterOf(i + 1), Room = L.Room, Tier = L.Tier, News = L.News });
            }
            return list;
        }

        static int ChapterOf(int lv)
        {
            for (int i = 0; i < CHAPTERS.Count; i++) if (lv >= CHAPTERS[i].From && lv <= CHAPTERS[i].To) return i;
            return -1;
        }

        // Math.max(1, Math.min(LEVELS, Math.floor(lv) || 1)): NaN, 0 and -0 count as 1
        public static int ClampLv(double lv)
        {
            double f = Math.Floor(lv);
            if (f == 0 || double.IsNaN(f)) f = 1;
            return (int)Math.Max(1, Math.Min(LEVELS, f));
        }

        // The room and time of day level `lv` is played in. `Key` changes when the picture does.
        public static Stage StageOf(double lv)
        {
            int L = ClampLv(lv);
            var ch = CHAPTERS[ChapterOf(L)];
            string[] phases;
            if (!PHASES_OF.TryGetValue(ch.Room, out phases)) phases = new[] { "day" };
            int k = (int)Math.Min(phases.Length - 1, Math.Floor((double)(L - ch.From) / (ch.To - ch.From + 1) * phases.Length));
            return new Stage { Room = ch.Room, Phase = phases[k], Key = ch.Room + ":" + k };
        }

        // Level `lv` (1-based): its data, the parsed board, the full clear as directions, room, phase, stage key,
        // beats, cushions, twists.
        public static LevelSpec LevelSpec(double lv)
        {
            int L = ClampLv(lv);
            var d = LevelData.All[L - 1];
            var board = Engine.Parse(d.Map);
            var stage = StageOf(L);
            var twists = new List<string>();
            if (board.Friends.Length > 0) twists.Add(board.Order.Any(o => o > 0) ? "ordered" : "friends");
            if (board.Arrow.Any(a => a >= 0)) twists.Add("arrows");
            if (board.Bubble.Any(b => b)) twists.Add("bubbles");
            if (board.Life.Any(x => x == 2)) twists.Add("piles");
            if (board.Beat.Any(b => b >= 0)) twists.Add("beats");
            var sol = new int[d.Solution.Length];
            for (int i = 0; i < sol.Length; i++) sol[i] = Engine.DCH.IndexOf(d.Solution[i]);
            return new LevelSpec
            {
                Lv = L, Map = d.Map, Tier = d.Tier, News = d.News, Sols = d.Sols, Effort = d.Effort, Board = board, Sol = sol,
                Room = stage.Room, Phase = stage.Phase, StageKey = stage.Key,
                Beats = board.Beat.Any(b => b >= 0), Cushions = board.Life.Count(x => x > 0), Twists = twists,
            };
        }

        // --- scoring ---------------------------------------------------------------------------------------------

        // 3: every cushion cleared before the ★; 2: up to 3 left; 1: more left. A hint takes one off, never the last.
        public static int StarsFor(int left, bool hinted) { return Engine.StarsFor(left, hinted); }

        static readonly double[] STAR_MULT = { 0, 1, 1.5, 2 };

        // Bigger boards and more twists pay more; harder tiers 15% more each. `stars` 0..3 (JS gives NaN outside).
        public static int CoinsFor(LevelSpec spec, int stars)
        {
            double bse = 8 + 0.6 * spec.Cushions + 4 * spec.Twists.Count + 2 * spec.Board.Friends.Length;
            return (int)Js.Round(bse * STAR_MULT[stars] * (1 + 0.15 * spec.Tier));
        }

        // The player's XP for a win: Squish Sort's and Squish Stack's formula, by the level number. `stars` may be a
        // profile's stored best, so it's a double as in JS.
        public static int XpFor(LevelSpec spec, double stars)
        {
            return (int)Js.Round((10 + Math.Floor(spec.Lv / 2.0) + 5 * spec.Tier) * (0.6 + 0.2 * stars));
        }

        // --- the profile's record ----------------------------------------------------------------------------------

        public static HopRecord Record(IDictionary<string, object> profile)
        {
            object hv;
            var s = profile != null && Js.TryGet(profile, "hop", out hv) && Js.Truthy(hv) ? hv as IDictionary<string, object> : null;
            object v;
            bool has;
            // lv: clampLv(s.lv || 1)
            has = Js.TryGet(s, "lv", out v);
            double lv = has && Js.Truthy(v) ? Js.ToNumber(v) : 1;
            has = Js.TryGet(s, "best", out v);
            var best = has && Js.Truthy(v) ? v as IDictionary<string, object> : null;
            return new HopRecord
            {
                Lv = ClampLv(lv),
                Best = best ?? new Dictionary<string, object>(),
                Plays = Js.TryGet(s, "plays", out v) && Js.Truthy(v) ? Js.ToNumber(v) : 0,
                Wins = Js.TryGet(s, "wins", out v) && Js.Truthy(v) ? Js.ToNumber(v) : 0,
                Seen = Js.TryGet(s, "seen", out v) && Js.Truthy(v),
            };
        }

        static double BestOf(HopRecord rec, int lv)
        {
            object v;
            return Js.TryGet(rec.Best, Js.KeyOf(lv), out v) && Js.Truthy(v) ? Js.ToNumber(v) : 0;
        }

        // total stars won (summed in JS key order)
        public static double StarsOf(HopRecord rec)
        {
            double a = 0;
            foreach (var k in Js.Keys(rec.Best))
            {
                object v = rec.Best[k];
                a += Js.Truthy(v) ? Js.ToNumber(v) : 0;
            }
            return a;
        }

        // levels beaten
        public static int DoneOf(HopRecord rec)
        {
            object v;
            return rec.Lv - 1 + (Js.TryGet(rec.Best, Js.KeyOf(LEVELS), out v) && Js.Truthy(v) ? 1 : 0);
        }

        // The fields to write after a level is won, and what it paid: coins, the player's XP (half on a replay) and
        // the levels it reached (Before / After: the result's XP bar).
        public static AfterLevelResult AfterLevel(IDictionary<string, object> profile, LevelSpec spec, HopResult result)
        {
            var rec = Record(profile);
            int stars = StarsFor(result.Left, result.Hinted);
            var update = new Dictionary<string, object>
            {
                { "hop.plays", rec.Plays + 1 },
                { "hop.wins", rec.Wins + 1 },
                { "hop.seen", true },
            };
            int coins = CoinsFor(spec, stars);
            double best = BestOf(rec, spec.Lv);
            double? prev = best != 0 && !double.IsNaN(best) ? PlayerXp.GameXp(XpFor(spec, best)) : (double?)null;
            double xp = PlayerXp.WinXp(PlayerXp.GameXp(XpFor(spec, stars)), prev);
            if (stars > best) update["hop.best." + Js.KeyOf(spec.Lv)] = (double)stars;
            bool unlocked = spec.Lv == rec.Lv && rec.Lv < LEVELS;
            if (unlocked) update["hop.lv"] = (double)(rec.Lv + 1);
            var gain = PlayerXp.AddXp(profile, xp);
            return new AfterLevelResult
            {
                Update = update, Coins = coins, Xp = gain.Xp, Before = gain.Before, After = gain.After, LevelUps = gain.LevelUps,
                Stars = stars, Unlocked = unlocked,
            };
        }

        // a RETRY after getting stuck counts as a play
        public static Dictionary<string, object> AfterStuck(IDictionary<string, object> profile)
        {
            return new Dictionary<string, object> { { "hop.plays", Record(profile).Plays + 1 }, { "hop.seen", true } };
        }
    }
}
