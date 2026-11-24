// What the squad does in the house (HOUSE_PORT_PLAN.md stage 4), as Squad House v6.dc.html: act (sit, lounge, nap,
// bath, ride, swing, perform... on a piece's seats; feed, cook, wash, watch, play... at a piece's use spot; snuggle;
// dance; the lights and party toggles), finishUse, leave (standing up, waking, climbing out), seats and use spots taken,
// snuggles, naps (bean / lie / bed), onRig (the rig back to idle: the hold state again, eating done), the quick-action
// wheel's rooms (qaGo / firstAct), the needs recovering by mode. The rig: Play (ctrl.play) and the house moves'
// metadata (RiveRig.HS: Resources/House/walk.json `hs`). Later stages: items' own reactions (setVar's pictures, TV
// channels, reno squish: 5), the beach's acts (10), the movie (9).
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class HouseAct
    {
        public string Id, Label, Cd, Kind, Mode, On, SeatAct, Then, V, Anim, Say, Fn;
        public double Dur;
    }

    public sealed partial class HouseCreatures
    {
        static HouseAct A(string id, string label, string cd, string kind, string mode = null, double dur = 0, string then = null, string v = null, string say = null, string on = null, string seatAct = null, string anim = null, string fn = null) =>
            new HouseAct { Id = id, Label = label, Cd = cd, Kind = kind, Mode = mode, Dur = dur, Then = then, V = v, Say = say, On = on, SeatAct = seatAct, Anim = anim, Fn = fn };

        public static readonly Dictionary<string, HouseAct> ACT = new Dictionary<string, HouseAct>
        {
            ["feed"] = A("feed", "Feed", "orange", "use", "eat"),
            ["snack"] = A("snack", "Snack", "orange", "use", "fridge", 1400, "eat", "open", "Snack time!"),
            ["cook"] = A("cook", "Cook", "yellow", "use", "cook", 3800, "eat", "on", "Yummy!"),
            ["wash"] = A("wash", "Wash", "teal", "use", "wash", 4200, say: "Fresh!"),
            ["brush"] = A("brush", "Brush", "sky", "use", "brush", 4200, say: "Sparkly teeth!", on: "wash"),
            ["dine"] = A("dine", "Eat", "orange", "seat", "dine", say: "Dinner time!", seatAct: "sit"),
            ["water"] = A("water", "Water", "lime", "use", "water", 5000, say: "Grow, grow!"),
            ["shower"] = A("shower", "Shower", "sky", "use", "shower", say: "La la la!"),
            ["watch"] = A("watch", "Watch", "sky", "use", "watch", 7000, v: "on", say: "Cartoons!", anim: "happy"),
            ["snuggle"] = A("snuggle", "Snuggle", "purple", "snug", "snuggle", say: "Snuggles!"),
            ["snugseat"] = A("snugseat", "Snuggle", "purple", "seat", "snuggle", say: "Scoot over!", seatAct: "sit"),
            ["play"] = A("play", "Play", "lime", "use", "play", 4200, v: "on", say: "So fun!", anim: "hop"),
            ["dig"] = A("dig", "Dig", "yellow", "use", "dig", 4500, say: "Treasure!", anim: "hop"),
            ["bounce"] = A("bounce", "Bounce", "lime", "use", "bounce", 4200, say: "Boing!", anim: "hop"),
            ["slide"] = A("slide", "Slide", "sky", "use", "slide", 2600, say: "Wheee!", anim: "happy"),
            ["sit"] = A("sit", "Sit", "teal", "seat", "sit", say: "Comfy!"),
            ["lounge"] = A("lounge", "Relax", "blue", "seat", "lounge", say: "Ahh...", seatAct: "sit"),
            ["nap"] = A("nap", "Nap", "blue", "seat", "nap", say: "Zzz"),
            ["bath"] = A("bath", "Bath", "sky", "seat", "bath", say: "Bubbles!"),
            ["sauna"] = A("sauna", "Sauna", "orange", "seat", "lounge", say: "So steamy!"),
            ["splash"] = A("splash", "Splash", "sky", "seat", "splash", say: "Splash!"),
            ["ride"] = A("ride", "Ride", "orange", "seat", "ride", say: "Wheee!"),
            ["perform"] = A("perform", "Stage", "purple", "seat", "perform", say: "Showtime!"),
            ["swing"] = A("swing", "Swing", "teal", "seat", "swing", say: "Wheee!"),
            ["party"] = A("party", "Party", "yellow", "toggle"),
            ["lights"] = A("lights", "Lights", "yellow", "toggle"),
            ["dance"] = A("dance", "Dance", "purple", "dance"),
            ["sun"] = A("sun", "Sunbathe", "yellow", "seat", "sun", say: "So warm!"),
            ["roast"] = A("roast", "Roast", "orange", "seat", "roast", say: "Marshmallows!"),
            ["build"] = A("build", "Build", "yellow", "use", "dig", 5000, say: "My castle!", anim: "hop"),
            ["surf"] = A("surf", "Surf", "sky", "use", "busy", say: "Surf’s up!", fn: "bSurf"),
            ["treat"] = A("treat", "Treat", "orange", "use", "fridge", 1200, "eat", say: "Yummy treat!"),
            ["swim"] = A("swim", "Swim", "sky", "beach"), ["fish"] = A("fish", "Fish", "teal", "beach"), ["shell"] = A("shell", "Shells", "yellow", "beach"),
        };
        static readonly HouseAct WATCHSEAT = A("watch", "Watch", null, "seat", "watch", say: "Cartoons!", seatAct: "sit");
        public static readonly string[] ORDER = { "swim", "fish", "shell", "sun", "treat", "roast", "build", "surf", "feed", "snack", "cook", "dine", "sit", "lounge", "snuggle", "watch", "nap", "bath", "sauna", "shower", "wash", "brush", "ride", "play", "bounce", "slide", "perform", "party", "swing", "splash", "dig", "water", "lights" };
        static readonly HashSet<string> SEATED = new HashSet<string> { "sit", "lounge", "watch", "snuggle" };
        static readonly HashSet<string> BSEAT = new HashSet<string> { "dine", "sun", "roast" };
        static readonly HashSet<string> BHOLD = new HashSet<string> { "dine", "sun", "roast", "wash", "brush", "dig", "bounce", "play", "dishes", "grill" };
        public sealed class QaRoom { public string Id, Label, Cd, Room, Say; public string[] Acts; public bool Dance; }
        public static readonly QaRoom[] QA =
        {
            new QaRoom { Id = "dance", Label = "Dance", Cd = "purple", Say = "Party!" },
            new QaRoom { Id = "bath", Label = "Bath", Cd = "sky", Room = "bathroom", Acts = new[] { "bath", "sauna", "splash", "wash" }, Say = "Bath time!" },
            new QaRoom { Id = "kitchen", Label = "Kitchen", Cd = "orange", Room = "kitchen", Acts = new[] { "snack", "cook", "feed" }, Say = "Snack time!" },
            new QaRoom { Id = "club", Label = "Club", Cd = "yellow", Room = "dance", Dance = true, Say = "Let’s dance!" },
            new QaRoom { Id = "sleep", Label = "Sleep", Cd = "blue", Room = "bedroom", Acts = new[] { "nap" }, Say = "Sleepy..." },
            new QaRoom { Id = "movie", Label = "Movies", Cd = "teal", Room = "movie", Acts = new[] { "watch", "sit", "nap" }, Say = "Movie night!" },
            new QaRoom { Id = "yard", Label = "Yard", Cd = "lime", Room = "backyard", Acts = new[] { "swing", "play", "splash", "bounce", "slide", "dig" }, Say = "Outside!" },
        };
        static readonly Dictionary<string, string> FXM = new Dictionary<string, string> { { "dishes", "bubble" }, { "water", "drop" }, { "bath", "bubble" }, { "wash", "bubble" }, { "cook", "steam" }, { "dance", "note" }, { "perform", "note" }, { "splash", "drop" }, { "dig", "sand" }, { "play", "spark" }, { "ride", "spark" }, { "bounce", "spark" }, { "slide", "spark" } };
        static readonly Dictionary<string, double> FXR = new Dictionary<string, double> { { "steam", 260 }, { "bubble", 300 }, { "note", 650 }, { "drop", 220 }, { "sand", 150 }, { "spark", 450 } };
        static readonly Dictionary<string, (string k, double v)> REC = new Dictionary<string, (string, double)>
        {
            { "eat", ("h", 14) }, { "nap", ("e", 3.5) }, { "sit", ("e", 0.6) }, { "lounge", ("e", 1.1) }, { "bath", ("c", 9) }, { "shower", ("c", 11) }, { "wash", ("c", 12) },
            { "dance", ("f", 5) }, { "perform", ("f", 6) }, { "swing", ("f", 6) }, { "ride", ("f", 6) }, { "splash", ("f", 5) }, { "dig", ("f", 6) }, { "play", ("f", 6) },
            { "sun", ("e", 3.2) }, { "roast", ("f", 5) }, { "fish", ("f", 2.5) }, { "bounce", ("f", 7) }, { "slide", ("f", 7) }, { "brush", ("c", 10) }, { "dine", ("h", 12) }, { "rplay", ("f", 6) },
        };

        // ---- the rig and the screen ----
        /// <summary>ctrl.play(name) on his rig.</summary>
        public Action<HouseCreature, string> Play = (c, n) => { };
        /// <summary>toast(text) on the screen.</summary>
        public Action<string> Toast = t => { };
        /// <summary>Whether a piece (by id) has a front part drawn over its sitters (hasFr).</summary>
        public Func<string, bool> HasFront = id => false;
        /// <summary>A piece's state picture ('on', 'open') changed (setVar): the room redraws it (stage 5).</summary>
        public Action<string> VarChanged = id => { };
        public readonly Dictionary<string, string> Vars = new Dictionary<string, string>();
        public readonly Dictionary<string, double> Tv = new Dictionary<string, double>();
        public readonly HashSet<string> TvAuto = new HashSet<string>();
        public bool Party; public double PartyEnd;
        JObj _hs; bool _eatCookie;

        /// <summary>The house moves' metadata (walk.json's hs, eatCookie).</summary>
        public void SetMoves(string walkJson)
        {
            var j = (JObj)HouseJson.Parse(walkJson);
            _hs = j.Obj("hs") ?? new JObj(); _eatCookie = j.Truthy("eatCookie");
        }

        /// <summary>hsGet: his own version of a house move (name@key), else the shared one, else null.</summary>
        public JObj HsGet(HouseCreature c, string n) => _hs == null ? null : _hs.Obj(n + "@" + c.Key) ?? _hs.Obj(n);
        string EatS() => _eatCookie ? "eat_cookie" : "happy";

        JObj FindItem(string id) { foreach (var it in RoomItems()) if (it.Str("id") == id) return it; return null; }
        JObj Cat(JObj it) => it == null ? null : S.D.CatOf(it.Str("t"));
        double Zk(JObj it) { var D = Cat(it); return D != null && !D.Truthy("mount") && S.CanSize(it) ? S.SzXY(it)[0] : 1; }
        double ZkY(JObj it) { var D = Cat(it); return D != null && !D.Truthy("mount") && S.CanSize(it) ? S.SzXY(it)[1] : 1; }
        double Zs0(JObj it) => S.Geo.SAt(it.Num("y")) * Zk(it);
        double ZsY(JObj it) => S.Geo.SAt(it.Num("y")) * ZkY(it);
        double FaceTo(HouseCreature c, JObj it) => Math.Atan2(it.Num("x") - c.X, (it.Num("y") - c.Y) / S.Geo.SA) * 180 / Math.PI;

        (double x, double z, double h, double f, string k) SeatXY(JObj D, double rot, int k)
        {
            var s = (JObj)D.Arr("seats")[k]; double tr = rot * Math.PI / 180, c = Math.Cos(tr), sn = Math.Sin(tr), FS = S.Geo.FS;
            return ((s.Num("x") * c + s.Num("z") * sn) * FS, (-s.Num("x") * sn + s.Num("z") * c) * FS, s.Num("h") * FS, s.Num("f"), s.Str("k") ?? D.Str("act"));
        }
        static string SeatK(JObj D, int k) => ((JObj)D.Arr("seats")[k]).Str("k") ?? D.Str("act");

        bool InUse(HouseCreature c, string id) => Vis.Exists(o => o != c && (o.UseItem == id || (o.UseRes == id && o.Moving && o.Arrive != null)));
        bool Taken(HouseCreature c, string key) => Vis.Exists(o => o != c && (o.Seat == key || (o.SeatRes == key && o.Moving && o.Arrive != null)));

        bool FreeSeat(List<JObj> items, HouseCreature c)
        {
            foreach (var it in items) { var D = Cat(it); var seats = D?.Arr("seats"); if (seats == null) continue; for (int k = 0; k < seats.Count; k++) if (SeatK(D, k) == "sit" && !Taken(c, it.Str("id") + ":" + k)) return true; }
            return false;
        }

        void SetVar(string id, string v)
        {
            if (v != null) Vars[id] = v;
            else { Vars.Remove(id); if (TvAuto.Contains(id)) { Tv.Remove(id); TvAuto.Remove(id); } }
            VarChanged(id);
        }

        /// <summary>leave: he gets off what he was on (standing up, waking, climbing out: his rig's way), free again.</summary>
        public void Leave(HouseCreature c, bool quiet, double now)
        {
            string was = c.Mode, nap = was == "nap" ? c.NapSt : null, wst = c.WSt;
            HouseCreature.KeepPose kp = nap != null || (wst != null && wst != "shower") ? new HouseCreature.KeepPose { Lift = c.LiftTo, Face = c.Face, Z = c.Z, Seat = c.SeatItem } : null;
            c.TurnAt = 0; c.NapSt = null; c.WSt = null; c.Keep = null;
            if (c.UseItem != null && Vars.ContainsKey(c.UseItem) && c.UseA?.V != null) SetVar(c.UseItem, null);
            c.Seat = null; c.SeatRes = null; c.UseRes = null; c.SeatItem = null; c.UseItem = null; c.LiftTo = 0; c.Z = null; c.UseEnd = 0; c.UseA = null; c.Face = 0; c.Mode = "free";
            c.RoastAt = 0; c.BowlEnd = 0; c.RnGo = null; c.Pa = null; c.PRig = false;
            if (was == "snuggle") Unsnug(c); if (was == "watch") Unwatch(c); c.SnugSt = null; c.WatchTv = null;
            var wk = nap != null ? HsGet(c, nap + "wake") : null; var ou = nap != null ? HsGet(c, nap + "out") : null;
            var wo = nap == null && wst != null ? HsGet(c, wst + "out") : null;
            if (!quiet && wo != null) { Play(c, wst + "out"); c.StandUntil = now + wo.Num("dur") - 250; if (kp != null) { kp.Until = now + wo.Num("hop") + 150; c.Keep = kp; } }
            else if (!quiet && wk != null && ou != null) { Play(c, nap + "wake"); c.StandUntil = now + wk.Num("dur") + ou.Num("dur") - 250; kp.Until = now + wk.Num("dur") + ou.Num("hop") + 150; c.Keep = kp; }
            else if (!quiet && SEATED.Contains(was)) { Play(c, "standup"); c.StandUntil = now + 620; }
            else if (!quiet && was != "free" && was != "busy") Play(c, "idle");
        }

        HouseCreature SnugMate(HouseCreature c) => Vis.Find(o => o != c && o.SeatItem != null && o.SeatItem == c.SeatItem && !o.Moving && SEATED.Contains(o.Mode) && (o.Mode != "snuggle" || o.SnugW == c));

        (HouseCreature mate, JObj it)? SnugTarget(HouseCreature c)
        {
            if (c.SeatItem != null && SEATED.Contains(c.Mode) && SnugMate(c) != null) return (SnugMate(c), null);
            var items = RoomItems();
            foreach (var o in Vis)
            {
                if (o == c || o.SeatItem == null || o.Moving || !SEATED.Contains(o.Mode) || o.Mode == "snuggle") continue;
                var it = items.Find(i => i.Str("id") == o.SeatItem); var D = Cat(it); var seats = D?.Arr("seats"); if (seats == null) continue;
                for (int k = 0; k < seats.Count; k++) if (SeatK(D, k) == "sit" && !Taken(c, it.Str("id") + ":" + k)) return (o, it);
            }
            return null;
        }

        void SnugPair(HouseCreature c, HouseCreature p, double now)
        {
            int sd = p.X >= c.X ? 1 : -1;
            foreach (var (a, b, s) in new[] { (c, p, sd), (p, c, -sd) }) { if (a.Mode == "watch") Unwatch(a); a.Mode = "snuggle"; a.SnugW = b; a.SnugSt = s > 0 ? "snuggleR" : "snuggleL"; Play(a, a.SnugSt); }
            Say(c, "Snuggles!", now);
        }

        void Unsnug(HouseCreature c)
        {
            var p = c.SnugW; c.SnugW = null; c.SnugSt = null;
            if (p != null && p.Mode == "snuggle" && p.SnugW == c) { p.Mode = "sit"; p.SnugW = null; p.SnugSt = null; Play(p, "sit"); }
        }

        void Unwatch(HouseCreature c)
        {
            var id = c.WatchTv; c.WatchTv = null;
            if (id != null && TvAuto.Contains(id) && !Vis.Exists(o => o != c && ((o.Mode == "watch" && o.WatchTv == id) || o.UseItem == id))) { Tv.Remove(id); TvAuto.Remove(id); VarChanged(id); }
        }

        void SnugAct(HouseCreature c, double now)
        {
            var T = SnugTarget(c);
            if (T == null) { Toast("Sit a friend on the sofa first"); return; }
            if (T.Value.it == null) { if (c.Mode == "watch") Unwatch(c); SnugPair(c, T.Value.mate, now); return; }
            var m = T.Value.mate; c.SnugTo = m; var sv = c.SnugTo; Act("snugseat", T.Value.it.Str("id"), now); c.SnugTo = sv;
        }

        static string NapKind(JObj it, JObj D)
        {
            var s = string.Join(" ", new[] { D?.Str("arch"), it?.Str("t"), D?.Str("n") }).Trim();
            bool M(string re) => System.Text.RegularExpressions.Regex.IsMatch(s, re, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (M("bean|pouf|pet ?bed|cushion|nest|basket")) return "bean";
            if (M("hammock|chaise|bench|towel|umbrella|cabana|lounger|sofa|futon|couch")) return "lie";
            if (M("bed|crib|bunk|cot\\b")) return "bed";
            return "lie";
        }
        static bool IsPouf(JObj it, JObj D) => System.Text.RegularExpressions.Regex.IsMatch(string.Join(" ", new[] { D?.Str("n"), D?.Str("arch"), it?.Str("t") }), "pouf|bouncy|puff seat", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        /// <summary>The quilt colour a napper's rig tucks him under (quiltCol: the piece's colour).</summary>
        public static string QuiltCol(JObj it, JObj D)
        {
            var cs = D?.Arr("cols"); var q = cs != null && cs.Count > 0 ? (cs[Math.Min(cs.Count - 1, (int)(it?.Num("c") ?? 0))] as JObj ?? cs[0] as JObj) : null;
            var v = q?.Str("a") ?? q?.Str("b");
            return v != null && System.Text.RegularExpressions.Regex.IsMatch(v, "^#[0-9a-f]{6}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase) ? v : "#7f9fd0";
        }
        public Action<HouseCreature, string> Quilt = (c, col) => { };
        void NapIn(HouseCreature c, JObj it, JObj D)
        {
            var k = NapKind(it, D); c.NapSt = HsGet(c, k + "in") != null ? k : null;
            Quilt(c, QuiltCol(it, D));
            Play(c, c.NapSt != null ? k + "in" : "sleep");
        }

        /// <summary>The acts a piece in this room offers (renderVals' present: the action bar's keys, up to 6 and Dance).</summary>
        public List<string> Present(HouseCreature c)
        {
            var present = new HashSet<string>(); var items = RoomItems();
            foreach (var it in items) { var D = Cat(it); if (D != null && D.Truthy("act")) present.Add(D.Str("act")); }
            if (present.Contains("sit")) present.Add("lounge"); if (present.Contains("wash")) present.Add("brush");
            if (present.Contains("sit") && items.Exists(it => { var D = Cat(it); return D != null && System.Text.RegularExpressions.Regex.IsMatch((D.Str("arch") ?? "") + " " + (D.Str("n") ?? ""), "table|desk|island|counter|dining", System.Text.RegularExpressions.RegexOptions.IgnoreCase); })) present.Add("dine");
            if (present.Contains("sit") && c != null && SnugTarget(c) != null) present.Add("snuggle");
            if (S.Cur == "beach") { present.Add("swim"); present.Add("fish"); present.Add("shell"); }
            var o = new List<string>(); foreach (var k in ORDER) if (present.Contains(k) && o.Count < 6) o.Add(k);
            o.Add("dance");
            return o;
        }

        /// <summary>act(id, itemId?): the selected friend does it (or the toggle is flipped).</summary>
        public void Act(string id, string itemId, double now)
        {
            if (!ACT.TryGetValue(id, out var Ac)) return;
            var G = S.Geo;
            if (Ac.Kind == "toggle") { Toggle(id, now); return; }
            var c = SelC; if (c == null) { Toast("Tap a friend first"); return; }
            if (Ac.Kind == "beach") { BAct(id, c, now); return; }
            if (Ac.Kind == "dance") { Leave(c, false, now); c.Moving = false; c.Mode = "dance"; Play(c, "dance"); Say(c, "Party!", now); return; }
            var items = RoomItems();
            if (Ac.Kind == "snug") { SnugAct(c, now); return; }
            if (id == "watch")
            {
                var tvI = items.Find(it => (itemId == null || it.Str("id") == itemId) && Cat(it)?.Str("act") == "watch");
                if (tvI != null)
                {
                    var tid = tvI.Str("id");
                    if (!Tv.ContainsKey(tid)) { Tv[tid] = 1; TvAuto.Add(tid); VarChanged(tid); }
                    if (c.SeatItem != null && !c.Moving && SEATED.Contains(c.Mode)) { if (c.Mode == "snuggle") Unsnug(c); c.Mode = "watch"; c.WatchTv = tid; Play(c, "watch"); Say(c, Ac.Say, now); return; }
                    if (FreeSeat(items, c)) { Ac = WATCHSEAT; itemId = null; c.WatchTv = tid; }
                }
            }
            if (Ac.Mode == "dine" && itemId == null && c.SeatItem != null && !c.Moving && SEATED.Contains(c.Mode) && HsGet(c, "dine") != null)
            { if (c.Mode == "snuggle") Unsnug(c); if (c.Mode == "watch") Unwatch(c); c.Mode = "dine"; c.WSt = "dine"; Play(c, "dine"); Say(c, Ac.Say, now); return; }
            if (Ac.Kind == "seat" && itemId == null && c.SeatItem != null && !c.Moving && SEATED.Contains(c.Mode) && (Ac.Mode == "sit" || Ac.Mode == "lounge"))
            {
                if (c.Mode == "snuggle") Unsnug(c); if (c.Mode == "watch") Unwatch(c);
                if (c.Mode != Ac.Mode || c.WSt == "pouf") { c.Mode = Ac.Mode; c.WSt = null; Play(c, Ac.Mode); }
                if (Ac.Say != null) Say(c, Ac.Say, now);
                return;
            }
            var act = Ac;
            if (act.Kind == "seat")
            {
                JObj bIt = null, bD = null; int bK = -1; (double x, double z, double h, double f, string k) bQ = default; double bx = 0, by = 0, bs1 = 1, bd = 1e9;
                foreach (var it in items)
                {
                    if (itemId != null && it.Str("id") != itemId) continue;
                    var D = Cat(it); var seats = D?.Arr("seats"); if (seats == null) continue;
                    for (int k = 0; k < seats.Count; k++)
                    {
                        if (SeatK(D, k) != (act.SeatAct ?? id)) continue;
                        if (Taken(c, it.Str("id") + ":" + k)) continue;
                        var q = SeatXY(D, it.Num("r"), k); double s0 = Zs0(it), s1 = ZsY(it), x = it.Num("x") + q.x * s0, y = it.Num("y") + q.z * G.SA * s1, d = Math.Sqrt((x - c.X) * (x - c.X) + (y - c.Y) * (y - c.Y));
                        if (d < bd) { bd = d; bIt = it; bD = D; bK = k; bQ = q; bx = x; by = y; bs1 = s1; }
                    }
                }
                if (bIt == null) { Toast(itemId != null ? "That spot is taken" : "Nowhere free to " + act.Label.ToLowerInvariant() + " here"); return; }
                var it2 = bIt; var D2 = bD; int k2 = bK; var q2 = bQ; double x2 = bx, y2 = by, s12 = bs1;
                GoTo(c, x2, y2, () => Seated(c, act, it2, D2, k2, q2, x2, y2, s12), now);
                c.Tx = x2; c.Ty = y2; c.SeatRes = it2.Str("id") + ":" + k2;
            }
            else
            {
                JObj bIt = null, bD = null; double bd = 1e9;
                foreach (var it in items)
                {
                    if (itemId != null && it.Str("id") != itemId) continue;
                    var D = Cat(it); if (D == null || D.Str("act") != (act.On ?? id) || D.Obj("use") == null) continue;
                    if (InUse(c, it.Str("id"))) continue;
                    double d = Math.Sqrt((it.Num("x") - c.X) * (it.Num("x") - c.X) + (it.Num("y") - c.Y) * (it.Num("y") - c.Y));
                    if (d < bd) { bd = d; bIt = it; bD = D; }
                }
                if (bIt == null) { Toast(itemId != null ? "Someone is using that" : "Nothing here for that"); return; }
                var it2 = bIt; var D2 = bD; double s0 = Zs0(it2);
                var use = D2.Obj("use"); var u = G.UseXY(use.Num("x"), use.Num("z"), it2.Num("r")); bool inside = use.Truthy("inside"); double uh = use.Num("h");
                if (id == "feed" && c.X < it2.Num("x")) u = (-u.x, u.z);
                double tx = it2.Num("x") + u.x * s0, ty = it2.Num("y") + u.z * G.SA * ZsY(it2);
                GoTo(c, tx, ty, () => Used(c, id, act, it2, inside, uh, s0, tx, ty), now);
                c.Tx = tx; c.Ty = ty; c.UseRes = it2.Str("id");
            }
        }

        // the seat reached (act's seat branch's arrive)
        void Seated(HouseCreature c, HouseAct Ac, JObj it, JObj D, int k, (double x, double z, double h, double f, string k) q, double x, double y, double s1)
        {
            double now = Last; var G = S.Geo;
            c.X = x; c.Y = y; c.Seat = it.Str("id") + ":" + k; c.SeatItem = it.Str("id"); c.LiftTo = q.h * G.CA * s1;
            c.Z = Math.Round(it.Num("y"), MidpointRounding.AwayFromZero) + (q.z >= -6 || HasFront(it.Str("id")) ? 1 : -1);
            c.Mode = Ac.Mode; c.Face = it.Num("r") + q.f;
            var M = Ac.Mode;
            if (M == "roast" && HsGet(c, "roastin") == null) c.RoastAt = now + 4500;
            if (BSEAT.Contains(M) && HsGet(c, M + "in") != null) { c.WSt = M; Play(c, M + "in"); }
            else if (M == "nap") NapIn(c, it, D);
            else if (M == "sun") Play(c, "sleep");
            else if (M == "watch") Play(c, "sitdown_watch");
            else if (M == "snuggle")
            {
                c.Mode = "sit"; Play(c, "sitdown");
                var p = c.SnugTo; c.SnugTo = null;
                Later(1100, () => { if (p != null && c.SeatItem != null && p.SeatItem == c.SeatItem && c.Mode == "sit") SnugPair(c, p, Last); });
            }
            else if (M == "sit" && IsPouf(it, D) && HsGet(c, "poufin") != null) { c.WSt = "pouf"; Play(c, "poufin"); }
            else if (M == "sit" || M == "lounge") Play(c, M == "sit" ? "sitdown" : "sitdown_lounge");
            else if (M == "perform") { c.WSt = HsGet(c, "perform") != null ? "perform" : null; Play(c, c.WSt ?? "dance"); }
            else if (M == "splash" && HsGet(c, "splashin") != null) { c.WSt = "splash"; Play(c, "splashin"); }
            else if ((M == "swing" || M == "ride") && HsGet(c, M + "in") != null) { c.WSt = M; Play(c, M + "in"); }
            else if ((M == "bath" || M == "splash") && HsGet(c, "tubin") != null) { c.WSt = M == "bath" ? "tub" : "swim"; Play(c, c.WSt + "in"); }
            else Play(c, "happy");
            if (Ac.Say != null) Say(c, Ac.Say, now);
        }

        // the use spot reached (act's use branch's arrive)
        void Used(HouseCreature c, string id, HouseAct Ac, JObj it, bool inside, double uh, double s0, double tx, double ty)
        {
            double now = Last; var G = S.Geo;
            if (Ac.Fn != null) { c.X = tx; c.Y = ty; if (Ac.Fn == "bSurf") BSurf(c, it, now); return; }
            c.X = tx; c.Y = ty; c.Face = inside ? 0 : FaceTo(c, it); c.Mode = Ac.Mode; c.UseItem = it.Str("id"); c.UseA = Ac;
            if (inside) c.Z = Math.Round(it.Num("y"), MidpointRounding.AwayFromZero) + 1;
            if (uh != 0) c.LiftTo = uh * G.FS * G.CA * s0;
            if (Ac.Mode == "eat")
            {
                c.UseA = null; var bw = HsGet(c, "bowl");
                if (bw != null) { c.WSt = "bowl"; c.BowlEnd = c.EatEnd = now + Math.Min(bw.Num("loop"), 11000); Play(c, "bowl"); return; }
                c.EatEnd = now + 6000; Play(c, EatS()); return;
            }
            if (Ac.Mode == "shower") { c.WSt = HsGet(c, "showerin") != null ? "shower" : null; if (Ac.V != null) SetVar(it.Str("id"), Ac.V); Play(c, c.WSt != null ? "showerin" : "happy"); return; }
            if (Ac.Mode == "cook" && HsGet(c, "cookin") != null) { var a = HsGet(c, "cookin"); var b = HsGet(c, "cook"); c.UseEnd = now + a.Num("dur") + (b?.Num("loop") ?? 0); if (Ac.V != null) SetVar(it.Str("id"), Ac.V); Play(c, "cookin"); return; }
            if (Ac.Mode == "fridge" && Ac.V == "open" && HsGet(c, "fridge") != null) { var f = HsGet(c, "fridge"); c.UseEnd = now + f.Num("dur") - 120; c.TurnAt = now + f.Num("turn"); SetVar(it.Str("id"), Ac.V); Play(c, "fridge"); return; }
            c.UseEnd = now + Ac.Dur;
            if (Ac.Mode == "watch" && !Tv.ContainsKey(it.Str("id"))) { Tv[it.Str("id")] = 1; TvAuto.Add(it.Str("id")); }
            if (Ac.V != null) SetVar(it.Str("id"), Ac.V);
            if (Ac.Anim != null) Play(c, Ac.Anim);
        }

        void FinishUse(HouseCreature c, double now)
        {
            var Ac = c.UseA; c.UseEnd = 0; if (Ac == null) return;
            if (Ac.V != null && c.UseItem != null) SetVar(c.UseItem, null);
            c.UseA = null;
            if (Ac.Then == "eat") { c.Mode = "eat"; c.Face = 0; c.EatEnd = now + 5500; Play(c, EatS()); Say(c, Ac.Say, now); }
            else { c.Mode = "free"; c.Face = 0; c.Z = null; c.LiftTo = 0; c.UseItem = null; Say(c, Ac.Say, now); Play(c, "happy"); c.WanderAt = now + 5000; }
        }

        void BowlDone(HouseCreature c, double now) { c.BowlEnd = 0; c.WSt = null; c.Mode = "free"; c.Face = 0; c.Z = null; c.UseItem = null; Play(c, "happy"); Say(c, "Yum!", now); c.WanderAt = now + 4000; }

        /// <summary>toggle: the lights (the room's night) or a dance party (16 s, everyone dancing).</summary>
        public void Toggle(string key, double now)
        {
            var H = S.H; var cur = S.Cur;
            if (key == "lights")
            {
                var night = H.Ensure("night"); bool on = !night.Truthy(cur); night[cur] = on;
                Saved?.Invoke(); Toast(on ? "Lights out. Sweet dreams!" : "Good morning!"); RoomChanged?.Invoke(); return;
            }
            if (Party) { EndParty(now); return; }
            PartyEnd = now + 16000; Party = true; Toast("Dance party!");
            foreach (var c in Vis) { Leave(c, true, now); c.Moving = false; c.Arrive = null; c.Mode = "dance"; Play(c, "dance"); }
        }

        public void EndParty(double now)
        {
            Party = false;
            foreach (var c in Vis) if (c.Mode == "dance") { c.Mode = "free"; Play(c, "idle"); c.WanderAt = now + 1500; }
        }

        /// <summary>The save changed (the screen saves); the room's look changed (the screen redraws it).</summary>
        public Action Saved, RoomChanged;

        /// <summary>A quick-action wheel's button: a room's acts (going there first), the dance, sleeping.</summary>
        public bool QaGo(QaRoom q, double now, Action<string, HouseCreature> enterRoom)
        {
            var c = SelC; if (c == null) return false;
            if (q.Room == null) { Act("dance", null, now); return true; }
            if (!S.IsOpen(q.Room)) { Toast("The " + HouseFrame.RLAB[q.Room] + " opens at level " + HouseJson.JsString(S.D.Room(q.Room)?["unlock"])); Say(c, "Locked...", now); return true; }
            void Then()
            {
                if (SelC != c) return;
                Say(c, q.Say, Last);
                if (q.Dance) { Act("dance", null, Last); return; }
                var k = FirstAct(q.Acts);
                if (k != null) Act(k, null, Last);
                else if (q.Id == "sleep") { Leave(c, false, Last); c.Moving = false; c.Mode = "nap"; Play(c, "sleep"); }
            }
            if (S.Cur == q.Room) { Then(); return true; }
            enterRoom(q.Room, c);
            Later(500, Then);
            return true;
        }

        string FirstAct(string[] list)
        {
            var has = new HashSet<string>();
            foreach (var it in RoomItems()) { var D = Cat(it); if (D == null) continue; if (D.Truthy("act")) has.Add(D.Str("act")); foreach (var s in D.Arr("seats") ?? new List<object>()) if (s is JObj j && j.Truthy("k")) has.Add(j.Str("k")); }
            foreach (var k in list ?? new string[0]) if (has.Contains(k) && ACT.TryGetValue(k, out var a) && a.Kind != "toggle") return k;
            return null;
        }

        /// <summary>onRig: his rig went into state n; back to 'idle' while holding a pose plays the pose again (220 ms on),
        /// eating ends, a dance stops.</summary>
        public void OnRig(HouseCreature c, string n, double now)
        {
            if (n != "idle" || !Vis.Contains(c)) return;
            void Again(string st) => Later(220, () => { if (Vis.Contains(c)) Play(c, st); });
            if (c.WSt != null && (c.Mode == "bath" || c.Mode == "splash" || c.Mode == "shower" || c.Mode == "swing" || c.Mode == "ride" || BHOLD.Contains(c.Mode))) Again(c.WSt);
            else if (c.Mode == "nap" && c.NapSt != null) Again(c.NapSt);
            else if (c.Mode == "nap" || c.Mode == "sun") Again("sleep");
            else if (SEATED.Contains(c.Mode)) Again(c.Mode == "snuggle" ? c.SnugSt ?? "sit" : c.Mode);
            else if (c.Mode == "eat") { if (now < c.EatEnd) Again(EatS()); else { c.Mode = c.Seat != null ? "sit" : "free"; c.Face = 0; Say(c, "Yum!", now); Play(c, "happy"); } }
            else if (c.Mode == "perform" || (c.Mode == "dance" && (Party || Jams.Count > 0))) Again(c.Mode == "perform" && c.WSt != null ? c.WSt : "dance");
            else if (c.Mode == "rplay") Again(c.PAnim ?? "happy");
            else if (c.Mode == "dance") c.Mode = "free";
            else if (c.UseA?.Anim != null && now < c.UseEnd) Again(c.UseA.Anim);
        }

        // setTimeout on the simulation's clock
        readonly List<(double at, Action f)> _later = new List<(double, Action)>();
        void Later(double ms, Action f) => _later.Add((Last + ms, f));
        void RunLater(double now)
        {
            for (int i = 0; i < _later.Count; i++) if (_later[i].at <= now) { var f = _later[i].f; _later.RemoveAt(i--); f(); }
        }

        // the per-creature part of tick after the walk: hold poses, mode bobs, uses ending, mode particles, recovery
        void ActTick(HouseCreature c, double now, double dt, bool standing)
        {
            if (c.Keep != null && now >= c.Keep.Until) c.Keep = null;
            if (!c.Moving || standing)
            {
                if ((c.Mode == "splash" || c.Mode == "bath") && c.WSt == null) c.Oy = Math.Sin(now * 0.004 + c.I) * 1.6;
                else if (c.Mode == "bounce" && c.WSt == null) c.Oy = -Math.Abs(Math.Sin(now * 0.006)) * 26;
            }
            if (OnBeach) BStep(c, now, dt);
            MvStep(c, now);
            if (c.UseEnd != 0 && now >= c.UseEnd) FinishUse(c, now);
            if (c.BowlEnd != 0 && now >= c.BowlEnd) BowlDone(c, now);
            string fx = c.Mode == "rplay" ? (c.PRig ? null : c.PAnim == "dance" ? "note" : "spark") : c.WSt != null ? null : FXM.TryGetValue(c.Mode, out var m) ? m : null;
            if (fx != null && !c.Moving && now > c.FxAt) { c.FxAt = now + FXR[fx] * (0.7 + Rand() * 0.6); Emit(c, fx, now); }
            if (REC.TryGetValue(c.Mode, out var rec) && !c.Moving)
                c.N[rec.k] = Math.Min(100, c.N[rec.k] + rec.v * dt * (S.H.Obj("night").Truthy(S.Cur) && c.Mode == "nap" ? 2 : 1));
        }
    }
}
