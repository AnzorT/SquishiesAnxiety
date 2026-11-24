// The Catalog (HOUSE_PORT_PLAN.md stage 7): the page's renovation catalog (openCat, rcList, rcVals, rdVals, buyR,
// placeR). One room's book (the room you're in): its categories (Walls, Floor, Ceiling, Furniture, Electronics, All;
// the yard's Fences / Ground / Canopies and Games), 12 cards a spread sorted by level and slot, paging that runs on
// into the next category; a card's BUY spends coins (the app's wallet: Coins / Spend) and opens its detail, whose Place
// it / Put it up takes you to its room and puts it out (placeNew, in Renovate) or up (useRSurf). What the page works
// out with code not ported (the tag line, what it does, its secret, the short note, surface or piece) comes from
// tools/unity/house/export-catalog.mjs (shop.json). tools/unity/house-test `acts` replays the page's trace.
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class ShopCard
    {
        public string Id, Name, Tier, Price, Cnt, BTxt, Look;   // Look: "lock", "own", "buy" (the button's colours)
        public bool HasCnt, Locked, On;
    }

    public sealed partial class HouseCreatures
    {
        public static readonly string[] RCATS = { "Walls", "Floor", "Ceiling", "Furniture", "Electronics" };
        public static readonly (string code, string name)[] RROOMS = { ("MOV", "Movie Room"), ("LIV", "Living Room"), ("KIT", "Kitchen"), ("BTH", "Bath House"), ("BED", "Bedroom"), ("YRD", "Yard"), ("CLB", "Dance Club"), ("BCH", "Beach") };
        public static readonly Dictionary<string, string> RCODE = new Dictionary<string, string> { ["living"] = "LIV", ["kitchen"] = "KIT", ["bathroom"] = "BTH", ["bedroom"] = "BED", ["backyard"] = "YRD", ["dance"] = "CLB", ["movie"] = "MOV", ["beach"] = "BCH" };
        public static string CATL(string rm, string c) => rm == "YRD" ? (c == "Ceiling" ? "Canopies" : c == "Walls" ? "Fences" : c == "Floor" ? "Ground" : c) : c;

        // the page's catalog state: shop, cRm, cCt, cPg, det, detCol
        public bool Shop;
        public string CRm, CCt = "", Det;   // (cRm null until the Catalog first opens: the living room's)
        string Rm => CRm ?? "LIV";
        public int CPg, DetCol;
        /// <summary>The app's wallet: coins now, and spending (false: not enough). FreeShop: the page's freeShop prop.</summary>
        public Func<double> Coins = () => 0;
        public Func<double, bool> Spend = n => false;
        public bool FreeShop;
        /// <summary>Takes the squad to a room (the screen's enterRoom: drawn, saved).</summary>
        public Action<string> GoRoom;

        int Lvl => S.Level;
        JObj ShopRow(string id) => S.D.Shop.Obj("rows")?.Arr(id) is List<object> a ? new JObj { ["tag"] = a[0], ["what"] = a[1], ["sec"] = a[2], ["note"] = a[3], ["surf"] = a[4], ["reg"] = a[5] } : null;
        bool IsSurf(JObj r) => HouseJson.Truthy(ShopRow(r.Str("id"))?["surf"]);

        /// <summary>openCat: the Catalog on the room you're in (lv: at the page with that level's first piece).</summary>
        public void OpenCat(int lv = 0)
        {
            string rm = RCODE.TryGetValue(S.Cur, out var c) ? c : "LIV"; int pg = 0; string ct = "";
            if (lv > 0)
            {
                var hit = RcList(rm, "All").Find(r => r.Num("lv") == lv);
                if (hit != null) { ct = HouseSave.CatOfRow(hit); int i = RcList(rm, ct).IndexOf(hit); if (i >= 0) pg = i / 12; }
            }
            Shop = true; Det = null; CRm = rm; CCt = ct; CPg = pg; Bump();
        }
        public void CloseShop() { Shop = false; Det = null; Bump(); }

        List<JObj> RoomRows(string rm) => S.D.Rows.FindAll(r => r.Str("room") == rm);

        public List<JObj> RcList(string rm, string ct)
        {
            var RA = RoomRows(rm); var l = ct == "All" ? new List<JObj>(RA) : RA.FindAll(r => HouseSave.CatOfRow(r) == ct);
            StableSort(l, (a, b) => { int d = a.Num("lv").CompareTo(b.Num("lv")); return d != 0 ? d : a.Num("slot").CompareTo(b.Num("slot")); });
            return l;
        }

        string[] CatsOf(string rm) { var l = new List<string>(); foreach (var c in RCATS) if (!(rm == "YRD" && c == "Electronics")) l.Add(c); if (rm == "YRD") l.Add("Games"); return l.ToArray(); }

        /// <summary>The category shown (cCt if it has rows, else the first that does, else All).</summary>
        public string CurCat()
        {
            var RA = RoomRows(Rm); var CS = CatsOf(Rm);
            if (CCt == "All" || (Array.IndexOf(CS, CCt) >= 0 && RA.Exists(r => HouseSave.CatOfRow(r) == CCt))) return CCt;
            foreach (var c in CS) if (RA.Exists(r => HouseSave.CatOfRow(r) == c)) return c;
            return "All";
        }

        /// <summary>rcVals' numbers: the page's cards (left 6, right 6), page i of n, the category buttons and the tier line.</summary>
        public (List<ShopCard> cards, int pi, int np, List<(string id, string label, bool on, bool any)> cats, string tierTxt, bool open, string prevC, string nextC) Rc()
        {
            string rm = Rm, ct = CurCat(); var RA = RoomRows(rm); var CS = CatsOf(rm);
            var list = RcList(rm, ct); int np = Math.Max(1, (list.Count + 11) / 12), pi = Math.Max(0, Math.Min(np - 1, CPg));
            var pg = list.GetRange(pi * 12, Math.Min(12, Math.Max(0, list.Count - pi * 12)));
            var cards = pg.ConvertAll(Card);
            var cats = new List<(string, string, bool, bool)>();
            foreach (var c in CS) cats.Add((c, CATL(rm, c), c == ct, RA.Exists(r => HouseSave.CatOfRow(r) == c)));
            cats.Add(("All", "All", ct == "All", RA.Count > 0));
            string tierTxt = ""; if (pg.Count > 0) { double a = pg[0].Num("lv"), b = pg[pg.Count - 1].Num("lv"); tierTxt = a == b ? "Level " + HouseJson.JsString(a) : "Levels " + HouseJson.JsString(a) + "\u2013" + HouseJson.JsString(b); }
            var ORD = new List<string>(); foreach (var c in CS) if (RA.Exists(r => HouseSave.CatOfRow(r) == c)) ORD.Add(c); if (RA.Count > 0) ORD.Add("All");
            int oi = ORD.IndexOf(ct); string prevC = oi > 0 ? ORD[oi - 1] : null, nextC = oi >= 0 && oi < ORD.Count - 1 ? ORD[oi + 1] : null;
            return (cards, pi, np, cats, tierTxt, S.IsOpen(S.D.RMap(rm)), prevC, nextC);
        }

        ShopCard Card(JObj r)
        {
            var H = S.H; string id = r.Str("id"); bool surf = IsSurf(r), lk = r.Num("lv") > Lvl;
            double own = surf ? (HouseJson.Truthy(H.Obj("rOwn")?[id]) ? 1 : 0) : H.Obj("owned")?.Num("R:" + id) ?? 0;
            bool on = surf && own > 0 && RnIsOn(r); string st = lk ? "lock" : surf && own > 0 ? "own" : "buy";
            return new ShopCard { Id = id, Name = S.D.ShortName(r), Tier = "Lv " + HouseJson.JsString(r["lv"]), Price = HouseJson.JsString(r["cost"]), HasCnt = !surf && own > 0, Cnt = "x" + HouseJson.JsString(own), Locked = lk, On = on, Look = st,
                BTxt = lk ? "LV " + HouseJson.JsString(r["lv"]) : st == "own" ? (on ? "IN USE" : "OWNED") : "BUY" };
        }

        /// <summary>A card's button: locked says so; BUY buys and opens its detail; OWNED / IN USE open it.</summary>
        public void CardAct(string id)
        {
            var r = S.D.Row(id); if (r == null) return; var c = Card(r);
            if (c.Locked) { Toast("Reach level " + HouseJson.JsString(r["lv"]) + " to buy this"); return; }
            if (c.Look == "buy") { if (BuyR(id)) OpenDet(id); } else OpenDet(id);
        }
        public void OpenDet(string id) { Det = id; DetCol = 0; Bump(); }
        public void CloseDet() { Det = null; Bump(); }
        public void SetCat(string c) { var RA = RoomRows(Rm); if (c == "All" ? RA.Count > 0 : RA.Exists(r => HouseSave.CatOfRow(r) == c)) { CCt = c; CPg = 0; Det = null; Bump(); } }
        public void PrevPage() { var v = Rc(); if (v.pi > 0) { CPg = v.pi - 1; Det = null; Bump(); } else if (v.prevC != null) { CCt = v.prevC; CPg = (RcList(Rm, v.prevC).Count + 11) / 12 - 1; Det = null; Bump(); } }
        public void NextPage() { var v = Rc(); if (v.pi < v.np - 1) { CPg = v.pi + 1; Det = null; Bump(); } else if (v.nextC != null) { CCt = v.nextC; CPg = 0; Det = null; Bump(); } }

        public sealed class ShopDet { public string Id, Name, LvTxt, Room, Desc, Own, LockTxt, Price, PlaceTxt, What, Sec; public bool Locked, CanBuy, CanAfford, HasPlace, LvLock; }

        /// <summary>rdVals: the detail card.</summary>
        public ShopDet Rd()
        {
            var r = Det != null ? S.D.Row(Det) : null; if (r == null) return null; var H = S.H; string id = r.Str("id");
            bool surf = IsSurf(r), lk = r.Num("lv") > Lvl; string hr = S.D.RMap(r.Str("room"));
            double own = surf ? (HouseJson.Truthy(H.Obj("rOwn")?[id]) ? 1 : 0) : H.Obj("owned")?.Num("R:" + id) ?? 0;
            bool can = FreeShop || Coins() >= r.Num("cost"), on = surf && own > 0 && RnIsOn(r); var T = ShopRow(id);
            string rl = HouseFrame.RLAB.TryGetValue(hr ?? "", out var n) ? n : hr;
            return new ShopDet { Id = id, Name = S.D.ShortName(r), LvTxt = (lk ? "Unlocks at Lv " : "Lv ") + HouseJson.JsString(r["lv"]), LvLock = lk,
                Room = (r.Str("room") == "MOV" ? "Movie Room · " : "") + rl + " · " + r.Str("slotName"), Desc = T?.Str("note") ?? r.Str("note") ?? "",
                Own = surf ? (own > 0 ? (on ? "Up in the " + rl : "You own this") : "") : (own > 0 ? "You own " + HouseJson.JsString(own) : ""),
                Locked = lk, LockTxt = "Unlocks at level " + HouseJson.JsString(r["lv"]), CanBuy = !lk && !(surf && own > 0), Price = HouseJson.JsString(r["cost"]), CanAfford = can,
                HasPlace = !lk && own > 0 && !on, PlaceTxt = surf ? "Put it up" : "Place it", What = T?.Str("what") ?? "", Sec = T?.Str("sec") ?? "" };
        }

        /// <summary>buyR: a row bought with coins (a surface once; a piece into storage).</summary>
        public bool BuyR(string id)
        {
            var r = S.D.Row(id); if (r == null) return false; var H = S.H;
            if (r.Num("lv") > Lvl) { Toast("Reach level " + HouseJson.JsString(r["lv"]) + " to buy this"); return false; }
            bool surf = IsSurf(r); if (surf && HouseJson.Truthy(H.Obj("rOwn")?[id])) return true;
            if (!FreeShop && r.Num("cost") > 0) { bool ok = false; try { ok = Spend(r.Num("cost")); } catch (Exception) { } if (!ok) { Toast("Not enough coins"); return false; } }
            if (surf) H.Ensure("rOwn")[id] = 1.0;
            else { if (S.RnReg(id) == null) { Toast("That piece is not ready yet"); return false; } var o = H.Ensure("owned"); o["R:" + id] = o.Num("R:" + id) + 1; }
            SaveNow(); CoinsChanged?.Invoke(); Bump(); Toast(S.D.ShortName(r) + " is yours!"); return true;
        }
        /// <summary>The coins changed (the header's pill).</summary>
        public Action CoinsChanged;

        /// <summary>placeR: to its room (if it isn't this one), then out of storage in Renovate, or up on the walls.</summary>
        public void PlaceR(string id)
        {
            var r = S.D.Row(id); if (r == null) return; string hr = S.D.RMap(r.Str("room"));
            if (!S.IsOpen(hr)) { Toast("The " + (HouseFrame.RLAB.TryGetValue(hr ?? "", out var n) ? n : hr) + " is still boarded up"); return; }
            bool surf = IsSurf(r); int col = DetCol;
            if (hr != S.Cur) GoRoom?.Invoke(hr);
            if (surf) { Shop = false; Det = null; UseRSurf(id); } else PlaceNew("R:" + id, col);
        }
    }
}
