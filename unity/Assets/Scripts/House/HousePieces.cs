// The pieces' own life in the house (HOUSE_PORT_PLAN.md stage 5), as Squad House v6.dc.html: a tap on a piece
// (itemDown: a seated friend's sit / lounge / snuggle cycle, then rnTap for renovation pieces, a house4 TV's channels,
// else its act), rnTap's kinds (TV channels with or without speakers, games and their players, fireplace / grill,
// toaster, dishwasher, growing plants, paintings, squishies, shells, calendar, speakers, fog, a snack table, modes),
// each piece's runtime state (rst) and the state its picture shows (rStOf), rnUse / rnPlayer / rnStop, rnTick (games
// ending, jams), the yard ball (kick, kickBy, launch, rollStep: rallies). The room redraws a piece when its state
// changes (RoomChanged). The speakers' music and the fog's look are stage 9's (MovieNight, ClubFog): here their state
// and messages; the robot vacuum's run is the view's (VacBot).
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public sealed class PieceState { public double Ch, At, End, Pl; public bool Play; public string K; }

    public sealed partial class HouseCreatures
    {
        public readonly Dictionary<string, PieceState> Rst = new Dictionary<string, PieceState>();
        /// <summary>Speakers / DJ decks playing (MovieNight's keys: 'it:id', 'dj:id') and fog machines on ('it:id').</summary>
        public readonly HashSet<string> Jams = new HashSet<string>(), Fogs = new HashSet<string>();
        /// <summary>A piece's drawing data (the room's rnI: k, kx, ky, fl, Dr), from the room model.</summary>
        public Func<string, (double k, double kx, double ky, bool fl, JObj dr)?> RnI = id => null;
        /// <summary>The robot vacuum: start (true when it set off) / stop / busy, by key 'vac:id' (the view runs it).</summary>
        public Func<string, JObj, bool> VacStart = (k, it) => false;
        public Action<string> VacStop = k => { };
        public Func<string, bool> VacBusy = k => false;

        static readonly Dictionary<string, string[]> RPLAY = new Dictionary<string, string[]>
        {
            ["pin"] = new[] { "Pinball", "hop", "Flippers flapping!" }, ["dance"] = new[] { "Dance-off", "dance", "Dance battle!" }, ["table"] = new[] { "Match", "hop", "Match on!" },
            ["dj"] = new[] { "DJ set", "dance", "Drop the beat!" }, ["fire"] = new[] { "Fireplace", "happy", "So cosy!" }, ["grill"] = new[] { "BBQ grill", "happy", "Sizzle!" },
            ["coals"] = new[] { "Charcoal", "happy", "Coals glowing!" }, ["game"] = new[] { "Game", "hop", "Game on!" }, ["tip"] = new[] { "Tip it over", "happy", "Whoops!" },
            ["open"] = new[] { "Opens", "happy", "Opened!" }, ["show"] = new[] { "Tap to run", "happy", "Here it goes!" },
        };
        static readonly Dictionary<double, string> FOGS = new Dictionary<double, string> { { 1, "Bubbles blowing!" }, { 2, "Light fog rolling" }, { 3, "Haze settling in" }, { 4, "Heavy fog!" }, { 5, "Max mist!" } };
        static readonly HashSet<string> PHOP = new HashSet<string> { "gjump", "gbounce", "ghop", "gsplash", "gfetch" };
        static readonly Dictionary<string, string> GMOVE = new Dictionary<string, string>
        {
            { "dj", "dj" }, { "pin", "pinball" }, { "dance", "dancecab" }, { "pool", "billiards" }, { "hockey", "hockey" }, { "watch", "g_cheer" }, { "gkick", "g_goal" }, { "gkeep", "g_keep" },
            { "grun", "g_agility" }, { "gjump", "g_hoop" }, { "gswing", "g_golf" }, { "gclimb", "g_dome" }, { "gbounce", "bounce" }, { "gsee", "g_villa" }, { "ghop", "g_hop" }, { "gtoss", "g_cornhole" },
            { "gteth", "g_tether" }, { "gcrawl", "g_tunnel" }, { "gsplash", "splash" }, { "grest", "g_villa" }, { "gfetch", "g_frisbee" },
        };
        static readonly (Regex re, string n)[] GNAME =
        {
            (new Regex("tetherball|tether"), "g_tether"), (new Regex("hopscotch"), "g_hop"), (new Regex("horseshoe"), "g_shoe"), (new Regex("cornhole|bean ?bag toss"), "g_cornhole"),
            (new Regex("bocce|boules|lawn bowl"), "g_bocce"), (new Regex("frisbee|flying disc"), "g_frisbee"), (new Regex("ping|pong|table tennis"), "g_pong"), (new Regex("putt|golf"), "g_golf"),
            (new Regex("hoop|basket"), "g_hoop"), (new Regex("climb|dome|jungle"), "g_dome"), (new Regex("agility|a-frame|hurdle|weave"), "g_agility"), (new Regex("tunnel"), "g_tunnel"),
            (new Regex("villa|dog ?house|pet ?house"), "g_villa"), (new Regex("tramp|bounce"), "bounce"), (new Regex("goal|soccer|football"), "g_goal"),
        };
        static readonly Dictionary<string, double> VFACE = new Dictionary<string, double> { { "front", 0 }, { "back", 180 }, { "left", -90 }, { "right", 90 } };
        static readonly string[] CHN = { "", "Squish Toons", "Squish Cup", "Space Trip" };
        /// <summary>The house4 TV's channels (TVCH's names: the page's channel pictures are the view's).</summary>
        public static readonly string[] TVCH = { "Cartoons", "Sports", "Nature" };

        PieceState RS(JObj it) { var id = it.Str("id"); if (!Rst.TryGetValue(id, out var R)) Rst[id] = R = new PieceState(); return R; }
        JObj Row(JObj it) => S.RowOf(Cat(it));
        void Bump() => RoomChanged?.Invoke();
        void RnSet(JObj it, Action<PieceState> f) { f(RS(it)); Bump(); }

        public bool SpkIn() => RoomItems().Exists(it => { var r = Row(it); return r != null && HouseSave.RoleOf(r) == "tvspk"; });
        public bool TvOnNow() => RoomItems().Exists(it => { var r = Row(it); return r != null && HouseSave.RoleOf(r) == "tv" && Rst.TryGetValue(it.Str("id"), out var R) && R.Ch > 0; }) && SpkIn();

        /// <summary>rStOf: the state a renovation piece's picture shows now.</summary>
        public string RStOf(JObj it, JObj r)
        {
            var id = it.Str("id"); Rst.TryGetValue(id, out var R); R ??= new PieceState();
            var modes = r.Arr("modes"); string b = it.Truthy("st") ? HouseJson.JsString(it["st"]) : modes != null && modes.Count > 0 ? HouseJson.JsString(modes[0]) : "";
            string ky = "it:" + id, kind = r.Str("kind"), role = HouseSave.RoleOf(r);
            if (r.Truthy("sauna31")) return Vis.Exists(c => c.SeatItem == id && !c.Moving) ? "play" : "";
            if (kind == "toast" || kind == "dish") return R.K ?? "";
            if (r.Truthy("vac")) return R.Play ? "out" : "";
            if (kind == "fridge") return Vars.TryGetValue(id, out var v1) && v1 == "open" ? "play" : "";
            if (kind == "stove") return Vars.TryGetValue(id, out var v2) && v2 == "on" ? "play" : "";
            if (role == "tv") { var n = (int)R.Ch; return n == 0 ? "" : SpkIn() ? (n == 1 ? "play" : "play|ch" + n) : "noise"; }
            if (r.Truthy("play")) return R.Play ? (b != "" ? b + "|play" : "play") : b;
            if (role == "tvspk") return TvOnNow() ? "play" : "";
            if (role == "spk") return Jams.Contains(ky) ? "play" : "";
            if (r.Truthy("fog")) return Fogs.Contains(ky) ? "on" : "";
            return b;
        }

        /// <summary>A house4 piece's state picture (vars) and the party's 'on'.</summary>
        public string VarOf(JObj it) { var D = Cat(it); string v = Vars.TryGetValue(it.Str("id"), out var x) ? x : ""; if (D != null && D.Truthy("party") && Party) v = "on"; return v; }

        /// <summary>itemDown: a tap on a piece (not in Renovate).</summary>
        public void ItemDown(string id, double now)
        {
            var it = FindItem(id); if (it == null) return;
            var D = Cat(it);
            var c = SelC;
            if (c != null && c.SeatItem == id && !c.Moving && SEATED.Contains(c.Mode))
            {
                var p = SnugMate(c); string nx = c.Mode == "sit" ? "lounge" : c.Mode == "lounge" && p != null ? "snuggle" : "sit";
                if (c.Mode == "snuggle") Unsnug(c); if (c.Mode == "watch") Unwatch(c);
                if (nx == "snuggle") { SnugPair(c, p, now); return; }
                c.Mode = nx; Play(c, nx); Say(c, nx == "lounge" ? "Ahh..." : "Comfy!", now); return;
            }
            if (D != null && D.Has("reno") && RnTap(it, D, now)) return;
            if (D != null && D.Str("anim") == "tv" && D.Str("act") == "watch")
            {
                TvTap(it);
                if (c != null && Tv.ContainsKey(id) && c.UseItem != id && !(c.Mode == "watch" && c.WatchTv == id)) Act("watch", id, now);
                return;
            }
            if (D != null && D.Truthy("act")) Act(D.Str("act"), id, now);
        }

        /// <summary>tvTap: a house4 TV: off, CH 1, CH 2, CH 3, off.</summary>
        void TvTap(JObj it)
        {
            var id = it.Str("id");
            int n = ((Tv.TryGetValue(id, out var cur) ? (int)cur : 0) + 1) % (TVCH.Length + 1); TvAuto.Remove(id);
            if (n != 0) { Tv[id] = n; Toast("CH " + n + " · " + TVCH[n - 1]); }
            else
            {
                Tv.Remove(id);
                foreach (var c in Vis) { if (c.UseItem == id) Leave(c, false, Last); else if (c.Mode == "watch" && c.WatchTv == id) { c.Mode = "sit"; c.WatchTv = null; Play(c, "sit"); } }
                Toast("TV off");
            }
            VarChanged(id);
        }

        string GameSt(HouseCreature c, JObj it, string a)
        {
            var D = Cat(it); var s = string.Join(" ", new[] { D?.Str("n"), D?.Str("arch"), it.Str("t") }).Trim().ToLowerInvariant(); string n = null;
            if (a == "table") n = Regex.IsMatch(s, "pong|ping|tennis") ? "g_pong" : Regex.IsMatch(s, "billiard|pool|snooker|cue") ? "billiards" : "hockey";
            else if (a == "game" || (a ?? "").StartsWith("g"))
            {
                foreach (var g in GNAME) if (g.re.IsMatch(s)) { n = g.n; break; }
                if (n == "g_goal" && a == "gkeep") n = "g_keep";
                if (n == null && a != null) GMOVE.TryGetValue(a, out n);
            }
            else if (a != null) GMOVE.TryGetValue(a, out n);
            return n != null && HsGet(c, n) != null ? n : null;
        }

        void RnEatNow(HouseCreature c, string say, double now)
        {
            c.UseItem = null; c.UseA = null; c.UseEnd = 0; c.Mode = "eat"; c.Face = 0; c.EatEnd = now + 5500; Play(c, EatS());
            if (!string.IsNullOrEmpty(say)) Say(c, say, now);
        }

        public sealed class UseOpt { public string Mode, Anim, Say, Then; public double Dur; public bool Eat; public Action<HouseCreature> On; }

        /// <summary>rnUse: he walks to the piece's use spot (or in front of it) and uses it.</summary>
        void RnUse(HouseCreature c, JObj it, UseOpt o, double now)
        {
            var G = S.Geo; var D = Cat(it); double s0 = Zs0(it); (double x, double z) u;
            var use = D.Obj("use");
            if (use != null) u = G.UseXY(use.Num("x"), use.Num("z"), it.Num("r"));
            else { var h = G.Half(D.Num("w"), D.Num("d"), it.Num("r")); u = (0, h.hz + 16); }
            var id = it.Str("id");
            GoTo(c, it.Num("x") + u.x * s0, it.Num("y") + u.z * G.SA * ZsY(it), () =>
            {
                c.RnGo = null; c.Face = FaceTo(c, it); c.UseItem = id;
                if (o.Eat) { RnEatNow(c, o.Say, Last); o.On?.Invoke(c); return; }
                c.Mode = o.Mode ?? "rnuse"; c.UseA = new HouseAct { Anim = o.Anim, Say = o.Say, Then = o.Then }; c.UseEnd = o.Dur != 0 ? Last + o.Dur : 0;
                o.On?.Invoke(c);
                if (o.Anim != null) Play(c, o.Anim);
            }, now);
            c.RnGo = id;
        }

        // a2r: a point of the piece's drawing (its players' spots) -> the room
        (double x, double y) A2R(JObj it, (double k, double kx, double ky, bool fl, JObj dr) I, double qx, double qy)
        {
            double sa = S.Geo.SAt(it.Num("y")), kx = I.kx * sa, ky = I.ky * sa;
            return (it.Num("x") + (I.fl ? -qx : qx) * kx, it.Num("y") - LiftPx(it) + qy * ky);
        }
        double LiftPx(JObj it) => new RoomModel(S).LiftPx(it);

        void RnPlayer(HouseCreature o, JObj it, JObj q, string[] RP, double now)
        {
            var G = S.Geo; var I = RnI(it.Str("id")); var id = it.Str("id"); string a = q?.Str("a") ?? ""; (double x, double y) p;
            if (I != null && q != null) { var xy = q["x"] is double ? (q.Num("x"), q.Num("y")) : (0.0, 0.0); p = A2R(it, I.Value, xy.Item1, xy.Item2); }
            else { var h = G.Half(Cat(it).Num("w"), Cat(it).Num("d"), it.Num("r")); p = (it.Num("x"), it.Num("y") + (h.hz + 16) * G.SA * G.SAt(it.Num("y"))); }
            GoTo(o, p.x, p.y, () =>
            {
                if (!RS(it).Play) { o.Mode = "free"; o.RnGo = null; return; }
                o.X = p.x; o.Y = p.y; o.RnGo = null; o.UseItem = id; o.Mode = "rplay"; o.Pa = a; o.Pd = q?.Num("d") ?? 0;
                o.PAnim = a == "dj" || a == "dance" ? "dance" : PHOP.Contains(a) ? "hop" : RP[1] ?? "happy";
                o.Z = q != null && q.Truthy("b") ? Math.Round(it.Num("y"), MidpointRounding.AwayFromZero) - 1 : Math.Round(it.Num("y"), MidpointRounding.AwayFromZero) + 2;
                var gs = GameSt(o, it, a == "idle" || a == "" ? (Row(it)?.Str("play") ?? a) : a); o.PRig = gs != null; if (gs != null) o.PAnim = gs;
                double? vf = q != null && q.Str("v") != null && VFACE.TryGetValue(q.Str("v"), out var vv) ? vv : (double?)null;
                o.Face = vf == null ? FaceTo(o, it) : (I != null && I.Value.fl && Math.Abs(vf.Value) == 90 ? -vf.Value : vf.Value);
                Play(o, o.PAnim);
            }, now);
            o.RnGo = id;
        }

        void RnStop(JObj it, string msg, double now)
        {
            var R = RS(it); R.Play = false; R.Pl = 0; var id = it.Str("id");
            foreach (var o in Vis)
            {
                if (o.UseItem == id && (o.Mode == "rplay" || o.Mode == "rnuse")) { Leave(o, false, now); if (!string.IsNullOrEmpty(msg)) Say(o, msg, now); Play(o, "happy"); o.WanderAt = now + 4000; }
                else if (o.RnGo == id) { o.RnGo = null; o.Arrive = null; o.Mode = "free"; }
            }
            RnJam("dj:" + id, false);
            Bump();
        }

        void RnJam(string key, bool on)
        {
            if (on) Jams.Add(key);
            else if (Jams.Remove(key) && Jams.Count == 0 && !Party) foreach (var c in Vis) if (c.Mode == "dance") { c.Mode = "free"; Play(c, "idle"); }
        }

        void ToastCatch(HouseCreature w, JObj it, double now)
        {
            var S0 = HsGet(w, "toast");
            if (S0 == null) { RnEatNow(w, "Toast!", now); RnSet(it, R => R.K = ""); return; }
            w.WSt = null; w.Mode = "rnuse"; w.UseEnd = 0; w.UseA = null; Play(w, "toast"); Say(w, "Hot hot!", now);
            Later(S0.Num("dur") - 120, () => { if (w.UseItem == it.Str("id")) { RnEatNow(w, "Crunchy toast!", Last); RnSet(it, R => R.K = ""); } });
        }

        /// <summary>rnTap: a renovation piece tapped; true when it took the tap.</summary>
        public bool RnTap(JObj it, JObj D, double now)
        {
            var r = Row(it); if (r == null) return false;
            var c = SelC; var R = RS(it); var role = HouseSave.RoleOf(r); string id = it.Str("id"), ky = "it:" + id, kind = r.Str("kind");
            var I = RnI(id); var Dr = I?.dr;
            if (r.Truthy("vac"))
            {
                var key = "vac:" + id;
                if (VacBusy(key)) { VacStop(key); Toast("Robo-Vac is heading home"); return true; }
                if (VacStart(key, it)) { R.Play = true; Toast("Robo-Vac is cleaning the room!"); if (c != null) Say(c, "Vroom!", now); Bump(); }
                return true;
            }
            if (role == "tvspk") return true;
            if (role == "tv")
            {
                bool sp = SpkIn(); int n0 = (int)R.Ch;
                R.Ch = sp ? (n0 + 1) % 4 : (n0 != 0 ? 0 : 1);
                Toast(R.Ch == 0 ? "TV off" : sp ? "CH " + R.Ch + " · " + CHN[(int)R.Ch] : "Just static… add speakers to watch with sound");
                if (R.Ch != 0 && c != null && !c.Moving) Say(c, sp ? (R.Ch == 2 ? "Goooal!" : R.Ch == 3 ? "Whoa, space!" : "Cartoons!") : "Huh? Only fuzz...", now);
                Bump(); return true;
            }
            if (role == "screen" || role == "player")
            {
                // the show: paused / resumed, or started (the theater synced); else what's missing for one
                var th = Th ?? TheaterNow();
                if (th.Synced)
                {
                    if (Showing) { TogglePause(); Toast(Paused ? "Movie paused" : "Movie playing"); }
                    else { Th = th; PlayMovie(); Toast(Show != null ? "Now showing: " + Show.Mv.Str("title") : "Now showing!"); }
                    Bump(); return true;
                }
                Toast(TheaterText()); return true;
            }
            if (r.Truthy("play"))
            {
                string play = r["play"] is string ps ? ps : HouseJson.JsString(r["play"]);
                if (R.Play) { RnStop(it, Regex.IsMatch(play, "^(tip|open|show)$") ? "" : "Good game!", now); Toast(play == "tip" ? "Stood back up" : play == "open" ? "Closed" : "Stopped"); return true; }
                var P = Dr?.Arr("players") ?? new List<object>(); double need = r.Num("need");
                var RP = RPLAY.TryGetValue(play, out var rp) ? rp : new[] { "Play", "hop", "Fun!" };
                if (P.Count > 0)
                {
                    var pool = new List<HouseCreature>(); if (c != null) pool.Add(c); pool.AddRange(Vis.FindAll(o => o != c && o.Mode == "free" && !o.Moving));
                    if (pool.Count < Math.Max(1, need)) { Toast(need > 1 ? "Needs " + need + " friends in this room (" + pool.Count + " here)" : "No friends free to play"); return true; }
                    int n = (int)Math.Min(P.Count, need != 0 ? Math.Max(need, Math.Min(r.Num("max") != 0 ? r.Num("max") : need, pool.Count)) : pool.Count);
                    R.Play = true; R.At = now; R.End = r.Num("loop") != 0 ? now + r.Num("loop") * 1000 + 4000 : 0; R.Pl = 1;
                    for (int k = 0; k < n; k++) RnPlayer(pool[k], it, P[k] as JObj, RP, now);
                }
                else
                {
                    R.Play = true; R.At = now; R.End = 0; R.Pl = 0;
                    if (c != null)
                    {
                        if (play == "grill" || play == "coals") RnUse(c, it, new UseOpt { Mode = HsGet(c, "grill") != null ? "grill" : "cook", Anim = "happy", Dur = 3800, Then = "eat", Say = "BBQ!" }, now);
                        else if (play != "tip" && play != "open") { var gs = GameSt(c, it, play); RnUse(c, it, new UseOpt { Anim = gs ?? "happy", Dur = gs != null ? 9000 : 3000, Say = RP[2] }, now); }
                    }
                }
                if (play == "dj") RnJam("dj:" + id, true);
                Toast(RP[2]); Bump(); return true;
            }
            if (kind == "toast")
            {
                if (R.K == "in") { Toast("Toasting... " + Math.Max(1, Math.Ceiling((R.At - now) / 1000)) + " s"); return true; }
                if (R.K == "pop") { if (c != null) RnUse(c, it, new UseOpt { Say = "", On = cc => ToastCatch(cc, it, Last) }, now); else Toast("Ding! Tap a friend, then the toaster"); return true; }
                RnSet(it, x => { x.K = "in"; x.At = now + 5000; }); Toast("Toasting... 5 s");
                Later(5000, () =>
                {
                    RnSet(it, x => x.K = "pop");
                    var w = Vis.Find(o => o.UseItem == id && (o.Mode == "rnuse" || o.Mode == "toastw"));
                    if (w != null) ToastCatch(w, it, Last); else Toast("Ding! Toast is up");
                });
                if (c != null) RnUse(c, it, new UseOpt { Say = "", Mode = "toastw" }, now);
                return true;
            }
            if (kind == "dish")
            {
                if (R.K == "load" || R.K == "wash") { Toast("Washing..."); return true; }
                if (R.K == "clean") { RnSet(it, x => x.K = ""); Toast("Dishes put away"); if (c != null) Say(c, "All done!", now); return true; }
                RnSet(it, x => x.K = "load"); Toast("Loading the dirty dishes...");
                Later(1700, () => { RnSet(it, x => x.K = "wash"); Later(4500, () => { RnSet(it, x => x.K = "clean"); Toast("Sparkling clean!"); }); });
                if (c != null) RnUse(c, it, new UseOpt { Mode = "dishes", Anim = "happy", Dur = 6200, Say = "Squeaky clean!" }, now);
                return true;
            }
            var modes = r.Arr("modes");
            string Mode(int i) => HouseJson.JsString(modes[i]);
            int ModeIx() { var st = it.Truthy("st") ? HouseJson.JsString(it["st"]) : Mode(0); for (int i = 0; i < modes.Count; i++) if (Mode(i) == st) return i; return -1; }
            if (kind == "grow" && modes != null && modes.Count > 0)
            {
                int gi = Math.Max(0, ModeIx()), last = modes.Count - 1; it["st"] = Mode(gi >= last ? 0 : gi + 1); Saved?.Invoke(); Bump();
                if (gi == last - 1) { Toast("Harvest!"); if (c != null) RnUse(c, it, new UseOpt { Eat = true, Say = "Fresh!" }, now); }
                else if (gi >= last) Toast("Planted again");
                else { Toast("Watered · " + it["st"]); if (c != null) RnUse(c, it, new UseOpt { Mode = "water", Anim = "happy", Dur = 2200, Say = "Grow, grow!" }, now); }
                return true;
            }
            if (kind == "paint" && modes != null && modes.Count > 0) { int i = ModeIx(); it["st"] = Mode((i + 1) % modes.Count); Saved?.Invoke(); Bump(); Toast(HouseJson.JsString(it["st"])); if (c != null) Say(c, "Ooh, art!", now); return true; }
            if (kind == "squish") { Squish?.Invoke(id); if (c != null) Say(c, "Squishy!", now); return true; }
            if (kind == "shells") { Toast("Shells found: " + HouseJson.JsString(S.H["shells"] ?? 0.0)); if (c != null) Say(c, "So pretty!", now); return true; }
            if (kind == "cal") { Toast(DateTime.Now.ToString("dddd, d MMMM", System.Globalization.CultureInfo.CurrentCulture)); return true; }
            if (role == "spk")
            {
                bool on = !Jams.Contains(ky); RnJam(ky, on); if (r.Truthy("fog")) RnFog(ky, on);
                Toast(on ? (r.Truthy("fog") ? "Bass on · haze rolling" : "Music on! Everybody dance") : "Music off"); if (c != null && on) Say(c, "My song!", now); Bump(); return true;
            }
            if (r.Truthy("fog")) { bool on = !Fogs.Contains(ky); RnFog(ky, on); Toast(on ? (FOGS.TryGetValue(r.Obj("fog")?.Num("t") ?? 0, out var ft) ? ft : "Fog on") : "Fog off"); Bump(); return true; }
            if (Dr != null && Dr["top"] is JObj && food > 0 && c != null) { RnUse(c, it, new UseOpt { Eat = true, Say = "Snacks!" }, now); return true; }
            if (modes != null && modes.Count > 1 && !r.Truthy("kind") && !D.Truthy("act") && !(Dr?.Arr("seats")?.Count > 0)) { int i = ModeIx(); it["st"] = Mode((i + 1) % modes.Count); Saved?.Invoke(); Bump(); Toast(HouseJson.JsString(it["st"])); return true; }
            return false;
        }

        void RnFog(string ky, bool on) { if (on) Fogs.Add(ky); else Fogs.Remove(ky); }

        /// <summary>The theater's message: what's missing for a show.</summary>
        string TheaterText()
        {
            bool scr = false, pl = false, spk = false;
            foreach (var it in RoomItems()) { var r = Row(it); if (r == null) continue; var ro = HouseSave.RoleOf(r); if (ro == "screen") scr = true; else if (ro == "player") pl = true; else if (ro == "spk" || ro == "tvspk") spk = true; }
            var miss = new List<string>(); if (!scr) miss.Add("a screen"); if (!pl) miss.Add("a projector"); if (!spk) miss.Add("speakers");
            if (miss.Count == 0) return "Home theater is getting ready…";
            return "To play a movie, add " + (miss.Count == 1 ? miss[0] : string.Join(", ", miss.GetRange(0, miss.Count - 1)) + " and " + miss[miss.Count - 1]);
        }

        /// <summary>A squishy piece squished (rnSquish: the view's wobble).</summary>
        public Action<string> Squish;
        /// <summary>The snack table's food (the room model's: how many snacks are out).</summary>
        public double food;

        double _rnAt;
        // rnTick: every 0.5 s, games end (their time up, or no player left), jams make free friends dance
        void RnTick(double now)
        {
            if (now - _rnAt <= 500) return;
            _rnAt = now;
            foreach (var kv in new List<KeyValuePair<string, PieceState>>(Rst))
            {
                var R = kv.Value; if (!R.Play) continue;
                var it = FindItem(kv.Key); if (it == null) { R.Play = false; continue; }
                if (R.End != 0 && now > R.End) { RnStop(it, "Good game!", now); continue; }
                if (R.Pl != 0 && now - R.At > 2500 && !Vis.Exists(o => o.UseItem == kv.Key || o.RnGo == kv.Key)) RnStop(it, null, now);
            }
            if (Jams.Count > 0) foreach (var c in Vis) if (c.Mode == "free" && !c.Moving && c.Arrive == null && now > c.JamAt) { c.JamAt = now + 2000; c.Mode = "dance"; Play(c, "dance"); }
        }

        // ---- the yard ball / bath duck (toys) ----
        public sealed class Roll { public JObj Y; public string Room; public double X0, Y0, X1, Y1, T0, D, Dir; public HouseCreature By; }
        public Roll Rolling;
        public List<JObj> Toys() { var l = new List<JObj>(); foreach (var o in S.H.Obj("toys")?[S.Cur] as List<object> ?? new List<object>()) if (o is JObj j) l.Add(j); return l; }

        /// <summary>kick: a tap on a toy: the selected friend kicks it (his own kick), or it rolls off.</summary>
        public void Kick(JObj y, double now)
        {
            if (Rolling != null || (y.Num("kb") != 0 && now - y.Num("kb") < 5000)) return;
            var c = SelC; var K = c != null && c.Seat == null && !SEATED.Contains(c.Mode) ? HsGet(c, "kick") : null;
            if (K != null) { y["rally"] = 0.0; KickBy(c, y, K, false, now); return; }
            Launch(y, 0, null, now);
        }

        void KickBy(HouseCreature c, JObj y, JObj K, bool run, double now)
        {
            int side = c.X <= y.Num("x") ? -1 : 1; y["kb"] = now;
            GoTo(c, y.Num("x") + side * 30, y.Num("y") + 2, () =>
            {
                if (Rolling != null) { y["kb"] = 0.0; return; }
                c.Face = side < 0 ? 70 : -70; c.Mode = "busy"; Play(c, "kick"); c.StandUntil = Last + K.Num("dur") - 150;
                Later(K.Truthy("hit") ? K.Num("hit") : 500, () => { y["kb"] = 0.0; if (c.Mode == "busy") c.Mode = "free"; c.Hold = Last + 2500; Launch(y, -side, c, Last); });
                Later(K.Num("dur") + 300, () => { if (c.Mode == "free" && !c.Moving) c.Face = 0; });
            }, now, run);
        }

        void Launch(JObj y, int dir, HouseCreature by, double now)
        {
            if (Rolling != null) return;
            double a = dir != 0 ? (dir > 0 ? 0 : Math.PI) + (Rand() - 0.5) * 1.1 : Rand() * Math.PI * 2, d = 110 + Rand() * 110;
            var p = ClampF(y.Num("x") + Math.Cos(a) * d, y.Num("y") + Math.Sin(a) * d * 0.6, 50);
            Rolling = new Roll { Y = y, Room = S.Cur, X0 = y.Num("x"), Y0 = y.Num("y"), X1 = p.x, Y1 = p.y, T0 = now, D = 950, Dir = p.x > y.Num("x") ? 1 : -1, By = by };
        }

        /// <summary>Where the rolling toy is now (x, y, hop, spin degrees), for the view.</summary>
        public (double x, double y, double hop, double spin) RollAt(double now)
        {
            var R = Rolling; double u = Math.Min(1, (now - R.T0) / R.D), e = 1 - Math.Pow(1 - u, 3);
            double x = R.X0 + (R.X1 - R.X0) * e, y = R.Y0 + (R.Y1 - R.Y0) * e, hop = Math.Abs(Math.Sin(u * Math.PI * 3)) * (1 - u) * 16;
            double spin = R.Y.Str("k") == "duck" ? Math.Sin(u * Math.PI * 8) * (1 - u) * 18 : e * 600 * R.Dir;
            return (x, y, hop, spin);
        }

        void RollStep(double now)
        {
            var R = Rolling; var Y = R.Y; double u = Math.Min(1, (now - R.T0) / R.D);
            if (u < 1) return;
            var (x, y, _, _) = RollAt(now);
            Rolling = null; Y["x"] = R.X1; Y["y"] = R.Y1; Saved?.Invoke(); Bump();
            if (R.Room != S.Cur) return;
            HouseCreature best = null; double bd = 1e9;
            foreach (var c in Vis) { if (c.Mode != "free" || c.Seat != null) continue; double d = Math.Sqrt((c.X - x) * (c.X - x) + (c.Y - y) * (c.Y - y)); if (d < bd) { bd = d; best = c; } }
            if (best == null) return;
            int side = best.X < x ? -1 : 1; var K2 = Y.Str("k") != "duck" ? HsGet(best, "kick") : null; int rl = (int)Y.Num("rally") + 1;
            if (K2 != null && rl < 4 && Rand() < 0.65) { Y["rally"] = (double)rl; Say(best, "My turn!", now); KickBy(best, Y, K2, true, now); }
            else
            {
                Y["rally"] = 0.0; var b = best;
                GoTo(b, x + side * 34, y - 4, () =>
                {
                    b.Face = side < 0 ? 35 : -35; Play(b, "happy"); b.N["f"] = Math.Min(100, b.N["f"] + 15); Say(b, Y.Str("k") == "duck" ? "Squeak!" : "Got it!", Last);
                    Later(1600, () => { if (b.Mode == "free") b.Face = 0; });
                }, now, true);
            }
        }

        /// <summary>The pieces' part of tick: rnTick, the rolling toy, a party ending.</summary>
        void PieceTick(double now)
        {
            RnTick(now);
            if (Rolling != null) RollStep(now);
        }
    }
}
