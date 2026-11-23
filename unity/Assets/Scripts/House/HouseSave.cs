// The house's save (H, localStorage 'ssHouse5b' / Firestore users/{uid}/crib/house6 { data, t }): loading it the way
// Squad House v6 does (initH with every one-shot migration, unlockRooms, rnStart, wallStart, rnPrune, the starting room,
// the first render's ceiling-light fix) and writing it back (save). A port of the page's code line by line: the same
// key order, the same numbers, so the JSON is byte-for-byte the page's.
//
// The page rebuilds H from a fixed list of keys, so keys it doesn't list are dropped on load (also lz, lOff, home and
// the migration flags it sets only once). ToJson() writes exactly what the page writes; ToJsonKeepingUnknown() also
// carries over the keys of the loaded save that the page would drop, the round-trip rule of HOUSE_PORT_PLAN.md.
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public sealed class HouseSave
    {
        public readonly HouseData D;
        public readonly HouseGeo Geo;
        public JObj H;
        public JObj Loaded;            // the save as read (for ToJsonKeepingUnknown)
        public int Level = 1;
        public string Cur = "living";  // state.cur
        public readonly List<Creature> Cs = new List<Creature>();
        /// <summary>szBx: the boxes rnItem noted for pieces (the page keeps them between renders; sizes use them).</summary>
        public readonly Dictionary<string, double[]> SzBx = new Dictionary<string, double[]>();

        public sealed class Creature { public string Key, Name, Room, Home; public int I, Id; public double[] N; }

        static readonly string[] PICK = { "mittens", "pip", "boba", "jelli", "mallow", "scoop" };
        static readonly string[] HOME = { "living", "living", "kitchen", "bedroom", "backyard", "dance" };
        static readonly double[][] SEEDN = { new double[] { 30, 70, 80, 60 }, new double[] { 85, 32, 60, 70 }, new double[] { 70, 80, 28, 50 }, new double[] { 60, 55, 75, 24 }, new double[] { 38, 90, 65, 35 }, new double[] { 80, 30, 36, 75 } };
        static readonly string[] NK = { "h", "c", "e", "f" };
        public static readonly Dictionary<string, string> RCODE = new Dictionary<string, string> { { "living", "LIV" }, { "kitchen", "KIT" }, { "bathroom", "BTH" }, { "bedroom", "BED" }, { "backyard", "YRD" }, { "dance", "CLB" }, { "movie", "MOV" }, { "beach", "BCH" } };
        public static readonly Dictionary<string, string> RMAP = new Dictionary<string, string> { { "MOV", "movie" }, { "LIV", "living" }, { "KIT", "kitchen" }, { "BTH", "bathroom" }, { "BED", "bedroom" }, { "YRD", "backyard" }, { "CLB", "dance" }, { "BCH", "beach" } };
        static readonly Dictionary<string, object[][]> WSTART = new Dictionary<string, object[][]>
        {
            { "living", new[] { new object[] { "LIV-012" } } }, { "kitchen", new[] { new object[] { "KIT-012" } } }, { "bedroom", new[] { new object[] { "BED-012" } } },
            { "bathroom", new[] { new object[] { "KIT-012" }, new object[] { "BTH-010", 520.0 } } }, { "dance", new[] { new object[] { "CLB-108", 410.0, "DANCE" } } },
        };
        static readonly Regex WINIDS = new Regex("^(LIV|KIT|BED)-0(12|32|52|72|92)$");
        static readonly Dictionary<string, string[]> RSTART = new Dictionary<string, string[]>
        {
            { "living", new[] { "Primary Couch", "Center Table", "Media Center" } }, { "kitchen", new[] { "Fridge Progression", "Base Cabinetry", "Cooking Range", "Counter Stool" } },
            { "bathroom", new[] { "Primary Tub", "Washbasin", "Clothes Care" } }, { "bedroom", new[] { "Primary Bed", "Bedside Table", "Clothes Storage" } },
            { "backyard", new[] { "Accent Seating", "Primary Outdoor Seating", "Aquatic Centerpiece" } }, { "dance", new[] { "DJ Console", "Club Audio", "VIP Lounge Sofa" } },
            { "beach", new[] { "Sun Lounger", "Beach Umbrella", "Sandcastle" } },
        };
        // the keys initH carries over, in its order
        static readonly string[] HKEYS = { "owned", "rooms", "toys", "cr", "needs", "cur", "night", "uid", "surf", "sOwn", "open", "seenLv", "rOwn", "rtex", "lx" };

        public HouseSave(HouseData d) { D = d; Geo = new HouseGeo(d); }

        static double R1(double v) => HouseGeo.JsRound(v * 10) / 10;
        string Uid() { double u = H.Num("uid"); H["uid"] = u + 1; return "i" + HouseJson.JsString(u); }

        // ---- the page's helpers ----
        public JObj Room(string rk) => D.Room(rk);
        public bool IsOpen(string rk) { var R = D.Room(rk); return H != null && HouseJson.Truthy(H.Obj("open")?[rk]) && R != null && Level >= R.Num("unlock"); }
        public JObj RnReg(string id) => D.Pieces.Obj("R:" + id);
        public double BackY(JObj A) => 100 + A.Num("d") / 2 * Geo.FS * Geo.SA * Geo.SAt(101) + 1;
        string HomeFor(int i) { var h = HOME[i % HOME.Length]; return IsOpen(h) ? h : "living"; }

        // ---- load: initH + init + the start room + the first render ----
        /// <summary>
        /// The house as the page has it once it's open: json = the save (null: a new house), level = the player's level,
        /// owned = the roster ids the player owns in roster order (SquishSquad.ownedIds()), startRoom = the room asked for
        /// (App / the menu: 'living').
        /// </summary>
        public void Load(string json, int level, IList<int> owned, string startRoom = "living")
        {
            Level = Math.Max(1, Math.Min(30, level));
            object s0 = null; try { s0 = json == null ? null : HouseJson.Parse(json); } catch (FormatException) { }
            Loaded = s0 as JObj;
            InitH(Loaded);
            // init(): rnRegAll (prune), wall pieces not snapped to a side wall face the front
            RnPrune();
            foreach (var rk in H.Obj("rooms").Keys) foreach (var it in Items(rk)) { var A = D.CatOf(it.Str("t")); if (A != null && A.Has("reno") && HouseJson.Truthy(A["mount"]) && !HouseJson.Truthy(it["w"])) it["r"] = 0.0; }
            Pick(owned);
            if (!HouseJson.Truthy(H["seenLv"])) H["seenLv"] = (double)Level;
            var room = IsOpen(startRoom) ? startRoom : IsOpen(H.Str("cur")) ? H.Str("cur") : "living";
            EnterRoom(room);
            FirstRender();
        }

        IEnumerable<JObj> Items(string rk) { if (H.Obj("rooms")[rk] is List<object> L) foreach (var o in L) if (o is JObj j) yield return j; }

        void InitH(JObj s)
        {
            s = s ?? new JObj();
            H = new JObj();
            H["owned"] = Or(s["owned"]); H["rooms"] = Or(s["rooms"]); H["toys"] = Or(s["toys"]); H["cr"] = Or(s["cr"]); H["needs"] = Or(s["needs"]);
            H["cur"] = s.Has("cur") ? s["cur"] : HouseJson.Undefined;
            H["night"] = Or(s["night"]); H["uid"] = HouseJson.Or(s["uid"], 1.0); H["surf"] = Or(s["surf"]); H["sOwn"] = Or(s["sOwn"]); H["open"] = Or(s["open"]);
            H["seenLv"] = HouseJson.Or(s["seenLv"], 0.0); H["rOwn"] = Or(s["rOwn"]); H["rtex"] = Or(s["rtex"]); H["lx"] = Or(s["lx"]);
            var owned = H.Obj("owned"); var rooms = H.Obj("rooms"); var toys = H.Obj("toys");
            foreach (var id in D.Surf.Keys) { var m = D.Surf.Obj(id); if (m.Truthy("start") || m.Truthy("hidden")) H.Obj("sOwn")[id] = 1.0; }
            if (!s.Truthy("noLivJunk"))
            {
                if (HouseJson.Truthy(rooms["living"]) && rooms["living"] is List<object> L)
                {
                    int n = L.Count; var K = L.FindAll(it => !(it is JObj j && j.Str("t") == "dentedBowl")); rooms["living"] = K;
                    if (n != K.Count && owned.Truthy("dentedBowl")) owned["dentedBowl"] = Math.Max(0, owned.Num("dentedBowl") - (n - K.Count));
                }
                if (HouseJson.Truthy(toys["living"]) && toys["living"] is List<object> T) toys["living"] = T.FindAll(y => !(y is JObj j && j.Str("k") == "ball"));
            }
            if (HouseJson.Truthy(toys["backyard"]) && toys["backyard"] is List<object> TB) toys["backyard"] = TB.FindAll(y => !(y is JObj j && j.Str("k") == "ball"));
            {
                int n = 0; foreach (var rk in rooms.Keys) if (rooms[rk] is List<object> L) foreach (var it in L) if (it is JObj j && j.Str("t") == "dentedBowl") n++;
                if ((owned.Truthy("dentedBowl") ? owned.Num("dentedBowl") : 0) > n) { if (n > 0) owned["dentedBowl"] = (double)n; else owned.Remove("dentedBowl"); }
            }
            H["noLivJunk"] = 1.0;
            if (!s.Truthy("tvFix"))
            {
                var L = HouseJson.Truthy(rooms["living"]) ? rooms["living"] as List<object> : null; if (L == null) { L = new List<object>(); rooms["living"] = L; }
                if (owned.Truthy("R:LIV-011") && !L.Exists(it => it is JObj j && j.Str("t") == "R:LIV-011")) L.Add(Item(Uid(), "R:LIV-011", 232, 156, 330));
                H["tvFix"] = 1.0;
            }
            HangLights(s, "liv21", new Regex("^LIV-0(18|38|58|78|98)$"));
            HangLights(s, "kit27", new Regex("^KIT-0(17|37|57|77|97)$"));
            HangLights(s, "bed30a", new Regex("^BED-0(10|30)$"));
            HangLights(s, "bed30b", new Regex("^BED-0(50|70|90)$"));
            if (!s.Truthy("bed30c"))
            {
                foreach (var rk in rooms.Keys) if (rooms[rk] is List<object> L) foreach (var it in L) if (it is JObj j && j.Str("t") == "R:BED-080") { j["y"] = 101.0; j.Remove("e"); }
                H["bed30c"] = 1.0;
            }
            if (!s.Truthy("win31"))
            {
                foreach (var id in H.Obj("rOwn").Keys) if (WINIDS.IsMatch(id) && !owned.Truthy("R:" + id)) owned["R:" + id] = 1.0;
                foreach (var rk in new List<string>(rooms.Keys))
                {
                    var R = D.Room(rk); var L = rooms[rk] as List<object>;
                    if (R == null || R.Truthy("out") || !HouseJson.Truthy(rooms[rk]) || L == null) continue;
                    var surf = H.Obj("surf"); var sf = surf[rk] as JObj; if (!HouseJson.Truthy(surf[rk]) || sf == null) { sf = new JObj(); surf[rk] = sf; }
                    var v = HouseJson.Truthy(sf["win"]) ? HouseJson.JsString(sf["win"]) : "";
                    string bought = v.StartsWith("rv_") && WINIDS.IsMatch(v.Substring(3)) ? v.Substring(3) : null;
                    sf.Remove("win");
                    if (WSTART.TryGetValue(rk, out var ws))
                        for (int i = 0; i < ws.Length; i++) { var w = ws[i]; var id = i == 0 && bought != null && WINIDS.IsMatch((string)w[0]) ? bought : (string)w[0]; WallStart(rk, L, id, w.Length > 1 ? (double?)w[1] : null, w.Length > 2 ? (string)w[2] : null, id == bought); }
                }
                H["win31"] = 1.0;
            }
            HangLights(s, "clb31a", new Regex("^CLB-0(06|26)$"));
            UnlockRooms();
        }

        static object Or(object v) => HouseJson.Truthy(v) ? v : new JObj();

        static JObj Item(string id, string t, double x, double y, double r)
        { var o = new JObj(); o["id"] = id; o["t"] = t; o["x"] = x; o["y"] = y; o["r"] = r; o["c"] = 0.0; return o; }

        // liv21 / kit27 / bed30a / bed30b / clb31a: lights that were room surfaces became hanging pieces
        void HangLights(JObj s, string flag, Regex LT)
        {
            if (s.Truthy(flag)) return;
            var owned = H.Obj("owned"); var rooms = H.Obj("rooms"); var surf = H.Obj("surf");
            foreach (var id in H.Obj("rOwn").Keys) if (LT.IsMatch(id) && !owned.Truthy("R:" + id)) owned["R:" + id] = 1.0;
            foreach (var rk in new List<string>(surf.Keys))
            {
                var sr = surf[rk] as JObj;
                var v = sr != null && HouseJson.Truthy(sr["light"]) ? HouseJson.JsString(sr["light"]) : "";
                if (v.Length < 3 || !LT.IsMatch(v.Substring(3)) || !v.StartsWith("rv_")) continue;
                var id = v.Substring(3);
                var L = HouseJson.Truthy(rooms[rk]) ? rooms[rk] as List<object> : null; if (L == null) { L = new List<object>(); rooms[rk] = L; }
                sr.Remove("light");
                if (!owned.Truthy("R:" + id)) owned["R:" + id] = 1.0;
                if (!L.Exists(it => it is JObj j && j.Str("t") == "R:" + id)) L.Add(Item(Uid(), "R:" + id, 426, 101, 0));
            }
            H[flag] = 1.0;
        }

        public string UnlockRooms()
        {
            string opened = null;
            foreach (var rk in D.RKeys)
            {
                var R = D.Room(rk);
                if (Level < R.Num("unlock") || HouseJson.Truthy(H.Obj("open")[rk])) continue;
                H.Obj("open")[rk] = 1.0;
                var surf = H.Obj("surf"); if (!HouseJson.Truthy(surf[rk])) surf[rk] = new JObj();
                if (!HouseJson.Truthy(H.Obj("rooms")[rk])) H.Obj("rooms")[rk] = RnStart(rk);
                if (!HouseJson.Truthy(H.Obj("toys")[rk]))
                {
                    var T = new List<object>(); var rt = R.Arr("toys");
                    if (rt != null) for (int i = 0; i < rt.Count; i++) { var a = (List<object>)rt[i]; var y = new JObj(); y["id"] = rk + "t" + i; y["k"] = a[0]; y["x"] = a[1]; y["y"] = a[2]; T.Add(y); }
                    H.Obj("toys")[rk] = T;
                }
                opened = rk;
            }
            return opened;
        }

        public List<object> RnStart(string rk)
        {
            var R = D.Room(rk); var pos = R?.Arr("start") ?? new List<object>(); var code = RCODE[rk]; var used = new List<string>();
            var cand = D.Rows.FindAll(r => r.Str("room") == code && r.Num("tier") == 1 && RnReg(r.Str("id")) is JObj A && A.Str("rL") == "floor" && !A.Truthy("flat"));
            if (RSTART.TryGetValue(rk, out var slots))
                foreach (var sl in slots) { var r = cand.Find(c => !used.Contains(c.Str("id")) && c.Str("slotName") == sl); if (r != null) used.Add(r.Str("id")); }
            var owned = H.Obj("owned"); var outL = new List<object>();
            for (int i = 0; i < used.Count; i++)
            {
                double x, y;
                if (i < pos.Count && pos[i] is List<object> p) { x = (double)p[1]; y = (double)p[2]; } else { x = 300 + i * 120; y = 230; }
                var t = "R:" + used[i]; owned[t] = (owned.Truthy(t) ? owned.Num(t) : 0) + 1;
                outL.Add(Item(Uid(), t, x, y, 330));
            }
            if (WSTART.TryGetValue(rk, out var ws)) foreach (var w in ws) WallStart(rk, outL, (string)w[0], w.Length > 1 ? (double?)w[1] : null, w.Length > 2 ? (string)w[2] : null, false);
            return outL;
        }

        public void WallStart(string rk, List<object> L, string id, double? x, string txt, bool had)
        {
            var t = "R:" + id; if (L.Exists(it => it is JObj j && j.Str("t") == t)) return;
            var A = RnReg(id); if (A == null) return; var R = D.Room(rk) ?? new JObj(); var owned = H.Obj("owned");
            if (!had || !owned.Truthy(t)) owned[t] = (owned.Truthy(t) ? owned.Num(t) : 0) + 1;
            var it2 = Item(Uid(), t, x ?? (R["winX0"] is double w0 ? w0 : 300), BackY(A), 0);
            it2["e"] = A["elev"] is double e ? e : 40.0;
            if (!string.IsNullOrEmpty(txt)) it2["txt"] = txt;
            L.Add(it2);
        }

        // pieces whose catalog row was deleted leave the rooms and the owned lists (only with the full catalog in)
        public void RnPrune()
        {
            if (D.ById.Count < 300) return;
            bool Gone(object t) { var s = HouseJson.JsString(t); return s.StartsWith("R:") && !D.ById.ContainsKey(s.Substring(2)); }
            var rooms = H.Obj("rooms");
            foreach (var k in new List<string>(rooms.Keys)) { if (!(rooms[k] is List<object> L)) continue; var L2 = L.FindAll(it => !(it is JObj j && Gone(j["t"]))); if (L2.Count != L.Count) rooms[k] = L2; }
            var owned = H.Obj("owned"); foreach (var t in new List<string>(owned.Keys)) if (Gone(t)) owned.Remove(t);
            var rOwn = H.Obj("rOwn"); foreach (var id in new List<string>(rOwn.Keys)) if (!D.ById.ContainsKey(id)) rOwn.Remove(id);
        }

        // pick(): up to 4 creatures, the player's own first, then the page's favourites, then the roster
        void Pick(IList<int> owned)
        {
            Cs.Clear(); var seen = new HashSet<string>(); const int n = 4;
            void Add(JObj c, int id) { if (c != null && c.Truthy("art") && !seen.Contains(c.Str("key")) && Cs.Count < n) { seen.Add(c.Str("key")); Cs.Add(new Creature { Key = c.Str("key"), Name = c.Str("name"), Id = id }); } }
            if (owned != null) foreach (var id in owned) if (id >= 0 && id < D.Roster.Count) Add(D.Roster[id], id);
            foreach (var k in PICK) { int i = D.Roster.FindIndex(c => c.Str("key") == k); if (i >= 0) Add(D.Roster[i], i); }
            for (int i = 0; i < D.Roster.Count; i++) Add(D.Roster[i], i);
            var cr = H.Obj("cr"); var needs = H.Obj("needs");
            for (int i = 0; i < Cs.Count; i++)
            {
                var c = Cs[i]; c.I = i;
                var saved = cr[c.Key]; c.Room = HouseJson.Truthy(saved) && IsOpen(HouseJson.JsString(saved)) ? HouseJson.JsString(saved) : HomeFor(i);
                c.Home = HomeFor(i);   // (H.home is never loaded: initH doesn't carry it over)
                c.N = (double[])SEEDN[i % SEEDN.Length].Clone();
                if (needs[c.Key] is JObj nv) for (int k = 0; k < 4; k++) if (nv.Has(NK[k])) c.N[k] = nv[NK[k]] is double dv ? dv : double.NaN;
            }
        }

        public void EnterRoom(string room)
        {
            Geo.SetRoom(room);
            var rooms = H.Obj("rooms");
            foreach (var rk in new List<string>(rooms.Keys))
            {
                var L = rooms[rk] as List<object> ?? new List<object>();
                var K = L.FindAll(it => { var j = it as JObj; var A = j == null ? null : D.CatOf(j.Str("t")); return A == null || !A.Truthy("room") || A.Str("room") == rk; });
                if (K.Count != L.Count)
                {
                    var ids = new HashSet<string>(); foreach (var it in K) ids.Add(((JObj)it).Str("id"));
                    foreach (var it in K) { var j = (JObj)it; if (j.Truthy("on") && !ids.Contains(HouseJson.JsString(j["on"]))) j["on"] = null; }
                    rooms[rk] = K;
                }
            }
            foreach (var it in Items(room)) { var A = D.CatOf(it.Str("t")); if (it.Num("y") > 342 && !(A != null && A.Truthy("mount"))) it["y"] = 342.0; }
            if (!IsOpen(room)) room = "living";
            var prevR = Cur;
            if (room != "beach") { foreach (var c in Cs) if (c.Room == "beach") c.Room = c.Home != null && c.Home != "beach" && IsOpen(c.Home) ? c.Home : HomeFor(c.I); }
            else if (prevR != "beach" && !Cs.Exists(c => c.Room == "beach")) foreach (var c in Cs) if (c.Room == prevR) { c.Home = c.Room; c.Room = "beach"; }
            Cur = room;
        }

        /// <summary>The first render of the room: ceiling pieces not yet hung are moved up to the ceiling line.</summary>
        public void FirstRender()
        {
            Geo.SetRoom(Cur);
            foreach (var it in Items(Cur))
            {
                var A = D.CatOf(it.Str("t")); if (A == null) continue;
                if (A.Has("reno") && A.Str("rL") == "ceil" && !it.Truthy("cl"))
                { it["cl"] = 1.0; it["on"] = null; it["w"] = null; it["r"] = 0.0; it["y"] = BackY(A); it["e"] = CeilE(it, A); }
            }
        }

        // ---- sizes (the page's canSize / szXY family) ----
        public JObj RowOf(JObj A) => A != null && A.Has("reno") ? D.Row(A.Str("reno")) : null;
        public static string CatOfRow(JObj r)
        {
            if (r.Truthy("catO")) return r.Str("catO");
            var nm = r.Str("name") ?? "";
            if (Regex.IsMatch(nm, "dartboard", RegexOptions.IgnoreCase)) return "Walls";
            if (Regex.IsMatch(nm, "washer|dryer|dry-cleaning", RegexOptions.IgnoreCase)) return "Electronics";
            return HouseTables.SLOTCAT.TryGetValue(r.Str("slotName") ?? "", out var c) ? c : "Furniture";
        }
        public static string RoleOf(JObj r) { if (r.Truthy("role")) return r.Str("role"); var sn = r.Str("slotName"); return sn == "Main Screen" ? "screen" : sn == "Projector / Player" ? "player" : Regex.IsMatch(sn ?? "", "^(Speakers|Club Audio)$") ? "spk" : ""; }
        static readonly Regex PROJ = new Regex("Project|Bedsheet|Cinema Screen|Drive-In|Holo-Screen", RegexOptions.IgnoreCase);

        public bool CanSpin(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A == null || A.Truthy("mount")) return false; if (A.Truthy("flat")) return true;
            if (A.Has("reno")) { var r = RowOf(A); if (r == null) return false; var c = CatOfRow(r); if ((c == "Walls" || c == "Floor" || c == "Ceiling") && !(r.Str("room") == "YRD" && c == "Ceiling")) return false; }
            return true;
        }
        public bool IsTvMount(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A.Str("arch") == "projector") return false;
            if (A.Str("anim") == "tv" || Regex.IsMatch(A.Str("arch") ?? "", "^(tv|screen|wallTv|tvWall)$", RegexOptions.IgnoreCase)) return true;
            if (!A.Has("reno")) return false; var r = RowOf(A); if (r == null) return false;
            var nm = r.Str("name") ?? ""; if (PROJ.IsMatch(nm)) return false; if (RoleOf(r) == "screen") return true;
            return Regex.IsMatch(nm, @"\b(TV|Screen|Television)\b", RegexOptions.IgnoreCase) && !Regex.IsMatch(nm, "Window", RegexOptions.IgnoreCase);
        }
        public bool RsOK(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A == null || !A.Has("reno") || A.Truthy("mount") || A.Truthy("small") || A.Truthy("flat")) return false;
            var r = RowOf(A); if (r == null) return false; var sn = r.Str("slotName") ?? "";
            if (Regex.IsMatch(sn, "^(Speakers|Club Audio)$")) return true; if (r.Str("room") == "KIT") return true;
            if (r.Str("room") == "YRD" && (sn == "Pergola / Canopy" || sn == "Aquatic Centerpiece" || r.Str("catO") == "Games")) return true;
            return r.Str("room") == "BTH" && Regex.IsMatch(sn, "^(Shower Fixture|Thermal Station|Washbasin|Clothes Care|Towel & Robe Storage|Spa Plants|Primary Tub)$");
        }
        public double SzMin(JObj it) => RsOK(it) ? 0.75 : 0.5;
        public bool CanSize(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A == null) return false; if (RsOK(it)) return true; if (A.Truthy("mount") && !IsTvMount(it)) return true;
            if (!A.Has("reno")) return A.Str("arch") == "projector";
            var r = RowOf(A); if (r == null || !PROJ.IsMatch(r.Str("name") ?? "")) return false;
            if (A.Str("anim") == "tv" || RoleOf(r) == "screen") return true;
            if (A.Obj("draw")?["screen"] is JObj) return true;
            var nm = r.Str("name"); return Regex.IsMatch(nm, @"\b(TV|Screen|Television)\b", RegexOptions.IgnoreCase) && !Regex.IsMatch(nm, "Window", RegexOptions.IgnoreCase);
        }
        public bool SzFree(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A == null || !CanSize(it)) return false; if (!A.Has("reno")) return A.Str("arch") == "projector";
            var r = RowOf(A); return r != null && (PROJ.IsMatch(r.Str("name") ?? "") || (r.Str("room") == "YRD" && r.Str("slotName") == "Aquatic Centerpiece"));
        }
        double[] SzWall(JObj it)
        {
            var A = D.CatOf(it.Str("t")); const double P = 5; double e0 = Geo.Edge(101);
            if (A != null && A.Truthy("mount")) { var w = it["w"] as string; if (w == "L") return new[] { P, e0 - P }; if (w == "R") return new[] { Geo.VW - e0 + P, Geo.VW - P }; return new[] { e0 + P, Geo.VW - e0 - P }; }
            return new[] { P, Geo.VW - P };
        }
        public double[] SzBox(JObj it)
        {
            if (SzBx.TryGetValue(it.Str("id") ?? "", out var b)) return b;
            var R = Render(it.Str("t"), it.Num("r"), it.Num("c"), "");
            var bb = R?.Obj("bb"); return bb == null ? new double[] { 0, 0, 1, 1 } : new[] { bb.Num("x"), bb.Num("y"), bb.Num("w"), bb.Num("h") };
        }
        public JObj Render(string t, double r, double c, string v) => D.Renders.Obj(t + "|" + HouseJson.JsString(r) + "|" + HouseJson.JsString(c) + "|" + v);
        double RsMx(JObj it) { var A = D.CatOf(it.Str("t")); var r = RowOf(A); return r != null && r.Str("room") == "YRD" && (r.Str("slotName") == "Pergola / Canopy" || r.Str("slotName") == "Aquatic Centerpiece" || r.Str("catO") == "Games") ? 2 : 1.5; }
        public double[] SzLim(JObj it)
        {
            var b = SzBox(it); double sa = Geo.SAt(it.Num("y")); var W = SzWall(it);
            var L = new[] { Math.Max(0.5, (W[1] - W[0]) / Math.Max(1, b[2] * sa)), Math.Max(0.5, (it.Num("y") + 45) / Math.Max(1, b[3] * sa)) };
            double mx = RsMx(it);
            return RsOK(it) ? new[] { Math.Max(0.75, Math.Min(mx, L[0])), Math.Max(0.75, Math.Min(mx, L[1])) } : L;
        }
        static double Plus(object v) => v is double d ? d : v is string s && double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var x) ? x : v is bool b ? (b ? 1 : 0) : v == null ? 0 : double.NaN;
        static double OrOne(double v) => v != 0 && !double.IsNaN(v) ? v : 1;
        public double SzOf(JObj it) { if (!CanSize(it)) return 1; var L = SzLim(it); return Math.Max(SzMin(it), Math.Min(Math.Min(L[0], L[1]), OrOne(it.Has("sz") ? Plus(it["sz"]) : double.NaN))); }
        double SzAx(JObj it, string a, double L) { object v = it[a] ?? it["sz"]; var n = v == null || v == HouseJson.Undefined ? 1 : OrOne(Plus(v)); return Math.Max(SzMin(it), Math.Min(L, n)); }
        public double[] SzXY(JObj it)
        {
            if (!CanSize(it)) return new double[] { 1, 1 };
            if (SzFree(it)) { var L = SzLim(it); return new[] { SzAx(it, "sw", L[0]), SzAx(it, "sh", L[1]) }; }
            var z = SzOf(it); return new[] { z, z };
        }

        public double CeilE(JObj it, JObj A)
        {
            double s = Geo.SAt(it.Num("y")), k = Geo.FS * Geo.CA * s;
            var bb = A.Obj("draw")?.Arr("bb");
            double f = OrOne(A.Num("zs", 1)) / OrOne(A.Num("_z0", 1)), z = SzXY(it)[1], top = (bb != null ? (double)bb[1] : -80) * f * z * s;
            return Math.Max(0, (it.Num("y") + top + 62) / k);
        }

        // ---- save ----
        public JObj Snapshot()
        {
            H["cur"] = Cur;
            foreach (var c in Cs)
            {
                H.Obj("cr")[c.Key] = c.Room;
                if (!string.IsNullOrEmpty(c.Home)) H.Ensure("home")[c.Key] = c.Home;
                var n = new JObj(); for (int k = 0; k < 4; k++) n[NK[k]] = R1(c.N[k]); H.Obj("needs")[c.Key] = n;
            }
            return H;
        }
        /// <summary>save(): exactly what the page writes.</summary>
        public string ToJson() => HouseJson.Stringify(Snapshot());
        /// <summary>What the page writes plus the loaded save's keys the page drops (a newer design's data survives).</summary>
        public string ToJsonKeepingUnknown()
        {
            var o = Snapshot();
            if (Loaded == null) return HouseJson.Stringify(o);
            var copy = (JObj)HouseJson.Parse(HouseJson.Stringify(o));
            foreach (var k in Loaded.Keys) if (!copy.Has(k)) copy[k] = Loaded[k];
            return HouseJson.Stringify(copy);
        }
    }
}
