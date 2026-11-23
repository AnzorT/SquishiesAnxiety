// A room's drawing values, as the page's renderVals computes them for the room box (no creatures, not in edit mode):
// the shell (palette, floor, decor), the renovated surfaces (rtVals), the ceiling (clVals), the pieces in their order
// with their position, scale, z, footprint shadow and picture (renderVals' items + rnItem), toys, the night overlay,
// the camera. HouseTemplate turns them into the room's markup.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public sealed class RoomModel
    {
        readonly HouseSave S; readonly HouseData D; readonly HouseGeo G;
        public readonly List<string> Missing = new List<string>();   // drawings the export doesn't have yet
        /// <summary>Each renovation piece's drawing scale and flip as the page keeps them (rnI: k, kx, ky, fl) and its
        /// drawing (Dr): where its players stand (a2r), its fog, its vacuum.</summary>
        public readonly Dictionary<string, (double k, double kx, double ky, bool fl, JObj dr)> RnI = new Dictionary<string, (double, double, double, bool, JObj)>();
        /// <summary>A piece's state now (rStOf with the room's runtime state: HouseCreatures); null: at rest.</summary>
        public Func<JObj, JObj, string> StateOf;
        /// <summary>A house4 piece's state picture now (vars: 'on' / 'open'); null: none.</summary>
        public Func<JObj, string> VarOf;
        public string Season = "rainy";

        public RoomModel(HouseSave s) { S = s; D = s.D; G = s.Geo; }

        const string GIF = "gif:empty";   // the page's transparent 1 x 1 gif: no picture
        static double R1(double v) => HouseGeo.JsRound(v * 10) / 10;
        static int Mod(double a, int n) => (int)((a % n + n) % n);
        static string Fixed3(double v) => v.ToString("F3", CultureInfo.InvariantCulture);
        static List<object> L(params object[] a) => new List<object>(a);
        static JObj O(params object[] kv) { var o = new JObj(); for (int i = 0; i < kv.Length; i += 2) o[(string)kv[i]] = kv[i + 1]; return o; }

        // ---- colours (house4.js hx / th / shade) ----
        static int[] Hx(string h) { h = h.Replace("#", ""); if (h.Length == 3) h = "" + h[0] + h[0] + h[1] + h[1] + h[2] + h[2]; int n = int.Parse(h, NumberStyles.HexNumber, CultureInfo.InvariantCulture); return new[] { n >> 16 & 255, n >> 8 & 255, n & 255 }; }
        static string Th(double[] c) { var s = "#"; foreach (var v in c) s += ((int)Math.Max(0, Math.Min(255, HouseGeo.JsRound(v)))).ToString("x2"); return s; }
        public static string Shade(string h, double k) { var c = Hx(h); var o = new double[3]; for (int i = 0; i < 3; i++) o[i] = k <= 1 ? c[i] * k : c[i] + (255 - c[i]) * (k - 1); return Th(o); }

        // ---- the shell ----
        public string ShellKey(string rk)
        {
            var H = S.H; var RT = H.Obj("rtex")?.Obj(rk) ?? new JObj();
            var sf = new JObj(); if (H.Obj("surf")?[rk] is JObj s0) foreach (var k in s0.Keys) sf[k] = s0[k];
            if (RT.Truthy("wall")) sf["wall"] = "w_plaster"; if (RT.Truthy("floor")) sf["floor"] = "f_oak"; if (RT.Truthy("fence") && rk == "backyard") sf["fence"] = "y_hedge";
            var lx = H.Obj("lx")?[rk]; if (lx != null) sf["lx"] = lx;
            var lz = H.Obj("lz")?[rk]; if (HouseJson.Truthy(lz) && !(lz is double z && z == 1)) sf["lz"] = lz;
            var R = D.Room(rk); var locks = new List<string>();
            foreach (var d in R.Arr("doors")) { var to = ((JObj)d).Str("to"); var R2 = D.Room(to); locks.Add(R2 != null && S.Level < R2.Num("unlock") ? HouseJson.JsString(R2["unlock"]) : "0"); }
            var vals = new List<string>(); foreach (var sl in D.SlotsOf(rk)) vals.Add(HouseJson.JsString(HouseJson.Or(sf[sl], D.Def[sl])));
            double kf = HouseGeo.BIGR.TryGetValue(rk, out var k0) ? k0 : 1;
            var win = sf["win"] as string;
            return rk + "|" + string.Join(",", vals) + "|" + string.Join(",", locks) + "|" + HouseJson.JsString(kf) + "|" + (sf["lx"] != null ? HouseJson.JsString(sf["lx"]) : "") + "|" + HouseJson.JsString(HouseJson.Or(sf["lz"], 1.0)) + "|" + (win != null && D.WinIr.Contains(win) ? "ir" : "");
        }

        bool RnFixed(string rk) { var RT = S.H.Obj("rtex")?.Obj(rk); return RT != null && (RT.Truthy("wall") || RT.Truthy("floor")); }

        JObj TexOf(string id) => id == null ? null : D.Tex.Obj(id);
        string T(string id, string k) { var t = TexOf(id); var v = t?.Str(k); if (id != null && t == null) Missing.Add("tex " + id); return string.IsNullOrEmpty(v) ? GIF : v; }

        // rtVals: the renovated wall / floor / ceiling / fence / ground / yard lights
        JObj RtVals(JObj sh, string cur)
        {
            bool rnd = cur == "dance", outd = sh.Truthy("out");
            var RT = sh.Truthy("beach") ? new JObj() : S.H.Obj("rtex")?.Obj(cur) ?? new JObj();
            string w = outd ? null : RT["wall"] as string, f = outd ? RT["ground"] as string : RT["floor"] as string, c = outd ? null : RT["ceil"] as string, fe = outd ? RT["fence"] as string : null;
            string ws = w != null ? T(w, "wallS") : "", bd = w != null ? T(w, "board") : "";
            var cD = TexOf(c); bool cNew = cD != null && cD.Truthy("ceilRoom");
            var sw = S.H.Obj("surf")?.Obj(cur) ?? new JObj();
            var wv = sw["win"] is string sv && sv.StartsWith("rv_") ? sv.Substring(3) : ""; var wD = wv != "" ? TexOf(wv) : null;
            var o = new JObj();
            o["cx"] = cNew ? -203.8 : -117.2; o["cy"] = cNew ? -120.0 : -100.0; o["cw"] = cNew ? 1259.6 : 1086.4; o["ch"] = cNew ? 70.0 : 50.0;
            o["win"] = wD != null && wD.Truthy("win19") ? wD.Str("src") : GIF;
            o["ceilBase"] = cD?.Str("ceilBase") ?? ""; o["ceilTrim"] = cD?.Str("ceilTrim") ?? "";
            o["hasWall"] = w != null; o["wall"] = w != null ? T(w, "wall") : GIF;
            // rnOne
            { var Dw = TexOf(w); bool wr = rnd && Dw != null && Dw.Str("wallRnd") != "", one = Dw != null && Dw.Str("wallOne") != "" && !wr, full = Dw != null && Dw.Truthy("wallOneFull");
              o["hasWR"] = wr; o["wallRnd"] = wr ? Dw.Str("wallRnd") : ""; o["hasOne"] = one && !rnd; o["hasOneP"] = one && rnd && !full; o["hasOneF"] = one && rnd && full;
              o["oneX"] = full ? 100.0 : 319.0; o["oneW"] = full ? 652.0 : 214.0; o["wallOne"] = Dw?.Str("wallOne") ?? ""; o["wallOneR"] = Dw != null ? (Dw.Str("wallOneR") != "" ? Dw.Str("wallOneR") : Dw.Str("wallOne")) : "";
              o["divOp"] = (one && rnd && full) || wr ? 0.0 : 0.22; }
            // rnFlat (the dance room's perspective floor is CSS 3D: drawn from its exported picture, see RoomCompose)
            { var Df = rnd && f != null ? TexOf(f) : null; var FR = Df?.Obj("floorRoom");
              o["flatOn"] = FR != null; o["flatBg"] = FR != null ? "layers" : "none"; }
            o["wallS"] = ws != "" ? ws : (w != null ? T(w, "wall") : GIF);
            o["ws"] = ws != "" ? O("x", 0.0, "y", -480.0, "h", 600.0, "t", "matrix(1 0.0244 0 1 0 0)") : O("x", 100.0, "y", -50.0, "h", 150.0, "t", "matrix(1 0 0 1 0 0)");
            o["trim"] = bd != "" ? bd : sh.Obj("P").Str("trim");
            o["hasFloor"] = f != null; o["floor"] = f != null ? T(f, "floor") : GIF; o["hasCeil"] = c != null; o["ceil"] = c != null ? T(c, "ceil") : GIF; o["hasFence"] = fe != null;
            { var Dfe = TexOf(fe); o["fPat"] = !(Dfe != null && Dfe.Str("wallL") != "") && fe != null; o["fenceHtml"] = Dfe != null && Dfe.Str("wallL") != "" ? (Dfe.Str("wallRoom") != "" ? Dfe.Str("wallRoom") : FenceHtml(Dfe)) : ""; }
            o["fence"] = fe != null ? T(fe, "fence") : GIF; o["fenceR"] = fe != null && !string.IsNullOrEmpty(TexOf(fe)?.Str("fenceR")) ? TexOf(fe).Str("fenceR") : (fe != null ? T(fe, "fence") : GIF);
            { var yid = outd && sw["ylight"] is string yv && yv.StartsWith("rv_") ? yv.Substring(3) : ""; var yD = yid != "" ? TexOf(yid) : null; bool on = yD != null && yD.Str("ylRoom") != ""; o["ylOn"] = on; o["yl"] = on ? yD.Str("ylRoom") : ""; }
            { var Dfe = TexOf(fe); o["fW"] = Dfe != null && Dfe.Num("fW") != 0 ? Dfe.Num("fW") : 80.0; o["fWR"] = Dfe != null && (Dfe.Num("fWR") != 0 || Dfe.Num("fW") != 0) ? (Dfe.Num("fWR") != 0 ? Dfe.Num("fWR") : Dfe.Num("fW")) : 80.0; }
            // rtRound
            o["floorR"] = f != null && rnd; o["ceilR"] = c != null && rnd; o["floorC"] = f != null ? T(f, "floor") : GIF;
            o["ceilC"] = c != null && rnd ? T(c, "ceil") + "#viewBox=17 0 46 25" : (c != null ? T(c, "ceil") : GIF);
            o["floorF"] = f != null && !rnd; o["ceilF"] = c != null && !rnd;
            return o;
        }
        static string FenceHtml(JObj t) { var H = t.Num("fH") != 0 ? t.Num("fH") : 56; return "<g transform=\"matrix(-0.3125 0.50625 0 1 100 " + HouseJson.JsString(100 - H) + ")\">" + t.Str("wallL") + "</g><g transform=\"matrix(0.3125 0.50625 0 1 752 " + HouseJson.JsString(100 - H) + ")\">" + t.Str("wallR") + "</g>"; }

        // ---- pieces ----
        double Elev(JObj it)
        {
            var A = D.CatOf(it.Str("t")); if (A == null) return 0;
            if (A.Truthy("mount")) return it["e"] is double e ? e : A["elev"] is double e2 ? e2 : 60;
            if (A.Truthy("small") && it.Truthy("on")) { var h = Find(HouseJson.JsString(it["on"])); if (h != null) return Elev(h) + D.CatOf(h.Str("t")).Num("topOf") * ZkY(h); }
            return 0;
        }
        double ZkY(JObj it) { var A = D.CatOf(it.Str("t")); return A != null && !A.Truthy("mount") && S.CanSize(it) ? S.SzXY(it)[1] : 1; }
        public double LiftPx(JObj it) => Elev(it) * G.FS * G.CA * G.SAt(it.Num("y"));
        List<object> items;
        JObj Find(string id) { foreach (var o in items) if (o is JObj j && j.Str("id") == id) return j; return null; }

        JObj Variant(JObj A, JObj it)
        {
            var r = S.RowOf(A); bool sp = S.CanSpin(it);
            double? rot = sp ? it.Num("r") : A.Truthy("mount") ? (it.Truthy("w") ? it.Num("r") : 0) : (double?)null;
            string st = r != null ? (StateOf != null ? StateOf(it, r) : RStOf(it, r)) : null;
            double ra = rot == null ? -30 : ((rot.Value % 360) + 360) % 360; if (ra == 330) ra = -30;
            var key = A.Str("reno") + "|" + (st ?? "") + "|" + (it["txt"] is string tx ? tx : "") + "|" + HouseJson.JsString(ra);
            var v = D.Variants.Obj(key);
            if (v == null) { v = HouseDraw.Variant(A.Str("reno"), st, it["txt"] as string, rot, S.Cur); if (v != null) D.Variants[key] = v; }
            if (v == null) Missing.Add("variant " + key);
            return v;
        }

        // the piece's state at rest (no one using it, nothing switched on): rStOf
        static string RStOf(JObj it, JObj r)
        {
            var modes = r.Arr("modes"); string b = it.Truthy("st") ? HouseJson.JsString(it["st"]) : modes != null && modes.Count > 0 ? HouseJson.JsString(modes[0]) : "";
            if (r.Truthy("sauna31")) return "";
            var kind = r.Str("kind"); if (kind == "toast" || kind == "dish") return "";
            if (r.Truthy("vac")) return ""; if (kind == "fridge" || kind == "stove") return "";
            var role = HouseSave.RoleOf(r);
            if (role == "tv") return "";
            if (r.Truthy("play")) return b;
            if (role == "tvspk" || role == "spk") return "";
            if (r.Truthy("fog")) return "";
            return b;
        }

        public JObj Build(string cur)
        {
            G.SetRoom(cur);
            var H = S.H; items = H.Obj("rooms")?[cur] as List<object> ?? new List<object>();
            var key = ShellKey(cur); var sh = D.Shells.Obj(key);
            if (sh == null) { Missing.Add("shell " + key); return null; }
            bool night = cur == "beach" ? H.Obj("night").Truthy("bedroom") : H.Obj("night").Truthy(cur);
            var fo = sh.Arr("fop") ?? L(0.0, 0.0, 0.4);
            var GS = new List<string>(); var outItems = new List<object>();
            double food = 0; foreach (var o in items) { var A0 = D.CatOf((o as JObj)?.Str("t")); var r0 = S.RowOf(A0); if (r0 != null && r0.Truthy("food")) food += r0.Num("food"); }
            this.food = food;
            foreach (var o in items)
            {
                var it = o as JObj; var A = D.CatOf(it?.Str("t")); if (A == null) continue;
                if (A.Has("reno") && A.Str("rL") == "ceil" && !it.Truthy("cl")) { it["cl"] = 1.0; it["on"] = null; it["w"] = null; it["r"] = 0.0; it["y"] = S.BackY(A); it["e"] = S.CeilE(it, A); }
                string v = VarOf?.Invoke(it) ?? ""; if (A.Str("arch") == "nightstand" && night) v = "on";
                var R = S.Render(it.Str("t"), it.Num("r"), it.Num("c"), v); if (R == null) { Missing.Add("render " + it.Str("t") + "|" + it.Num("r") + "|" + it.Num("c") + "|" + v); continue; }
                foreach (var g in R.Arr("gids")) if (!GS.Contains((string)g)) GS.Add((string)g);
                var zxy = S.SzXY(it); double s0 = G.SAt(it.Num("y"));
                string s = Fixed3(s0 * zxy[0]) + ", " + Fixed3(s0 * zxy[1]);
                double lf = LiftPx(it); var host = it.Truthy("on") ? Find(HouseJson.JsString(it["on"])) : null;
                double zz = A.Truthy("mount") ? 5 : host != null ? Math.Max(HouseGeo.JsRound(it.Num("y")), HouseGeo.JsRound(host.Num("y")) + 3) : A.Truthy("flat") ? 4 : HouseGeo.JsRound(it.Num("y"));
                var bb = R.Obj("bb");
                // the footprint shadow, ported (house4.js render's fpR): checked against the exported one
                bool round = A.Truthy("round");
                string shP = G.Footprint(A.Num("w"), A.Num("d"), round, it.Num("r"), 1.04), ctP = G.Footprint(A.Num("w"), A.Num("d"), round, it.Num("r"), 0.9);
                if (shP != R.Str("shadow") || ctP != R.Str("contact")) Missing.Add("footprint differs " + it.Str("t") + " r" + it.Num("r"));
                var f = O("id", it["id"], "x", R1(it.Num("x")), "y", R1(it.Num("y") - lf), "z", zz, "fz", zz + 3, "s", s, "vb", R["vb"], "bx", bb["x"], "by", bb["y"], "bw", bb["w"], "bh", bb["h"],
                    "back", R["back"] ?? L(), "part", R["part"] ?? L(), "tvOn", false, "front", R["front"] ?? L());
                f["hasFront"] = (R.Arr("front")?.Count ?? 0) > 0; var gl = R.Obj("glow"); f["hasGlow"] = gl != null; f["gd"] = gl?["d"] ?? ""; f["gf"] = gl?["f"] ?? "none";
                f["shadow"] = lf > 0.5 || A.Truthy("noShad") ? "" : shP; f["contact"] = lf > 0.5 || A.Truthy("flat") || A.Truthy("noShad") ? "" : ctP;
                f["sg"] = O("on", false); f["foot"] = R["foot"]; f["sel"] = false; f["hl"] = false; f["hfo"] = 0.16; f["cur"] = A.Truthy("act") ? "pointer" : "default";
                if (A.Has("reno")) RnItem(f, A, it, bb); else { f["isImg"] = false; f["src"] = ""; f["srcF"] = ""; f["hasSrcF"] = false; f["kind"] = ""; f["snk"] = L(); }
                outItems.Add(f);
            }
            // toys
            var toys = new List<object>();
            if (H.Obj("toys")?[cur] is List<object> TY) foreach (var o in TY) { var y = (JObj)o; toys.Add(O("id", y["id"], "l", R1(y.Num("x") - 20), "t", R1(y.Num("y") - 40), "z", HouseGeo.JsRound(y.Num("y")), "s", Fixed3(G.SAt(y.Num("y"))), "isBall", y.Str("k") == "ball", "isDuck", y.Str("k") == "duck")); }
            // the night
            var nightV = O("on", false, "bg", "none");
            if (night && cur == "beach") nightV = O("on", true, "bg", "rgba(14,20,60,0.3)");
            else if (night)
            {
                JObj ns = null; foreach (var o in items) { var j = o as JObj; var A = D.CatOf(j?.Str("t")); if (A != null && A.Str("arch") == "nightstand") { ns = j; break; } }
                if (ns != null) { double sA = G.SAt(ns.Num("y")); double px = ns.Num("x"), py = ns.Num("y") - 70 * G.CA * sA;
                    nightV = O("on", true, "bg", "radial-gradient(circle at " + JsFixed0(px) + "px " + JsFixed0(py + 50) + "px, rgba(255,214,140,0.28) 0px, rgba(255,214,140,0.06) 90px, rgba(16,20,56,0.5) 200px, rgba(16,20,56,0.62) 440px)"); }
                else nightV = O("on", true, "bg", "rgba(16,20,56,0.55)");
            }
            var rt = RtVals(sh, cur);
            var P = sh.Obj("P");
            var clOn = cur != "dance" && !sh.Truthy("out") && !sh.Truthy("beach");
            var cl = O("on", clOn, "c", rt.Str("ceilBase") != "" ? rt.Str("ceilBase") : Shade(P.Str("b0"), 1.04), "trim", rt.Str("ceilTrim") != "" ? rt.Str("ceilTrim") : P.Str("trim"));
            var glin = new List<object>(); var grad = new List<object>();
            foreach (var g in GS) { var gr = D.Grads.Obj(g); if (gr == null) continue; var c = O("id", gr["id"], "t", gr["t"], "c0", gr["c0"], "c1", gr["c1"]); if (gr.Str("t") == "R") grad.Add(c); else { var x = gr.Str("t") == "T" ? O("x2", "1", "y2", "0.7") : O("x2", "0.85", "y2", "1"); foreach (var k in c.Keys) x[k] = c[k]; glin.Add(x); } }
            var fl = sh.Obj("floor");
            var rusty = sh.Truthy("rusty") && !RnFixed(cur);
            var vals = new JObj();
            vals["P"] = P; vals["wallFill"] = "url(#p-" + sh.Str("wall") + ")"; vals["indoor"] = !sh.Truthy("out"); vals["rusty"] = rusty; vals["vigOp"] = rusty ? 0.3 : 0.16; vals["rt"] = rt;
            vals["fl"] = O("dark", HouseJson.Or(fl["dark"], "M0 0"), "light", HouseJson.Or(fl["light"], "M0 0"), "lines", HouseJson.Or(fl["lines"], "M0 0"), "dop", fo[0], "lop", fo[1], "nop", fo[2]);
            var texts = new List<object>(); var st = sh.Arr("texts"); if (st != null) for (int i = 0; i < st.Count; i++) { var t = (JObj)st[i]; texts.Add(O("id", "t" + i, "x", t["x"], "y", t["y"], "t", t["t"], "sz", t["sz"], "f", t["f"], "sh", t.Truthy("glow") ? "0 0 2px #4fe0d0, 0 0 10px #4fe0d0, 0 0 22px #4fe0d0" : "none")); }
            vals["decor"] = sh["decor"]; vals["texts"] = texts; vals["doors"] = L(); vals["items"] = outItems; vals["toys"] = toys; vals["night"] = nightV; vals["party"] = false; vals["disco"] = L();
            vals["glin"] = glin; vals["grad"] = grad; vals["ready"] = true;
            vals["flatRoom"] = cur != "dance"; vals["roundRoom"] = cur == "dance"; vals["gls"] = cur == "dance" ? GlsPic(Season + "|" + (H.Obj("night").Truthy("bedroom") ? "true" : "false")) : "";
            vals["camK"] = cur != "dance" && !sh.Truthy("out") && !sh.Truthy("beach") ? 0.85 : 1.0;
            vals["cl"] = cl; vals["lh"] = O("on", false); vals["crVis"] = "visible"; vals["crs"] = L();
            vals["rs"] = cur == "dance" ? O("floor", "M-174 400 A600 300 0 0 1 1026 400 Z", "wall", "M-220 -240 H1072 V400 H1026 A600 300 0 0 0 -174 400 H-220 Z", "edge", "M-174 400 A600 300 0 0 1 1026 400")
                : O("floor", "M100 100 H752 L1052 586 V600 H-200 V586 Z", "wall", "M-200 -119.1 L100 -50 H752 L1052 -119.1 V586 L752 100 H100 L-200 586 Z", "edge", "M-200 586 L100 100 H752 L1052 586");
            vals["qa"] = O("vis", false); vals["bprops"] = L();
            return vals;
        }
        string GlsPic(string k) { var p = D.Gls.Str(k); if (p == null) Missing.Add("glass sky " + k); return p ?? ""; }
        static string JsFixed0(double v) => HouseJson.JsString(Math.Abs(v) < 1e21 ? double.Parse(v.ToString("F0", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture) : v);

        double food;
        void RnItem(JObj o, JObj A, JObj it, JObj rbb)
        {
            var V = Variant(A, it); bool sp = S.CanSpin(it);
            double f = (A.Num("zs", 1) != 0 ? A.Num("zs", 1) : 1) / (A.Num("_z0", 1) != 0 ? A.Num("_z0", 1) : 1);
            var b = V?.Arr("bb"); double b0 = b != null ? (double)b[0] : 0, b1 = b != null ? (double)b[1] : 0, b2 = b != null ? (double)b[2] : 1, b3 = b != null ? (double)b[3] : 1;
            bool fl = !sp && !A.Truthy("mount") && Mod(it.Num("r"), 360) == 30;
            { var zq = S.SzXY(it); if (it.Str("id") != null) RnI[it.Str("id")] = (f * Math.Sqrt(zq[0] * zq[1]), f * zq[0], f * zq[1], fl, V); }
            double ix = b0 * f, iy = b1 * f, iw = b2 * f, ih = b3 * f, x0 = fl ? -(ix + iw) : ix;
            double Rx = rbb.Num("x"), Ry = rbb.Num("y"), Rw = rbb.Num("w"), Rh = rbb.Num("h");
            double bx = Math.Min(Rx, x0), by = Math.Min(Ry, iy), bw = Math.Max(Rx + Rw, x0 + iw) - bx, bh = Math.Max(Ry + Rh, iy + ih) - by;
            double[] tb = null; var tbA = V?.Arr("tb"); if (A.Truthy("mount") && tbA != null) tb = new[] { (double)tbA[0] * f, (double)tbA[1] * f, (double)tbA[2] * f, (double)tbA[3] * f };
            S.SzBx[it.Str("id")] = A.Truthy("mount") && A.Str("rL") != "ceil" && tb != null ? tb : new[] { bx, by, bw, bh };
            string src = V?.Str("src") ?? "", srcF = V?.Str("srcF") ?? "";
            o["isImg"] = true; o["hasSrc"] = (V?.Str("whole") ?? "") != ""; o["src"] = src; o["srcF"] = srcF; o["hasSrcF"] = srcF != "";
            o["ix"] = ix; o["iy"] = iy; o["iw"] = iw; o["ih"] = ih; o["flip"] = fl ? "scale(-1 1)" : "";
            o["vb"] = HouseJson.JsString(bx) + " " + HouseJson.JsString(by) + " " + HouseJson.JsString(bw) + " " + HouseJson.JsString(bh);
            o["bx"] = bx; o["by"] = by; o["bw"] = bw; o["bh"] = bh; o["back"] = L(); o["part"] = L(); o["front"] = L(); o["hasFront"] = srcF != ""; o["hasGlow"] = false; o["sg"] = O("on", false);
            var r = S.RowOf(A); o["kind"] = r != null ? HouseSave.RoleOf(r) : "";
            // the food the room's food pieces put on its tables
            var snk = L(); var top = V?.Obj("top");
            if (food > 0 && top != null && A.Str("rL") == "floor" && D.Foods.Count > 0)
            {
                int nF = (int)Math.Min(5, food); double tw = (top.Num("w") != 0 ? top.Num("w") : 60) * 0.9;
                for (int i = 0; i < nF; i++)
                {
                    var F = i < D.Foods.Count ? D.Foods[i] as JObj : null; if (F == null || F.Str("src") == "") continue;
                    double fw = F.Num("w") * 0.95, fh = F.Num("h") * 0.95, ax = top.Num("x") + (nF > 1 ? ((double)i / (nF - 1) - 0.5) * tw : 0);
                    snk.Add(O("id", "s" + i, "src", F["src"], "x", R1((fl ? -ax : ax) * f - fw * f / 2), "y", R1(top.Num("y") * f - fh * f * 0.8), "w", R1(fw * f), "h", R1(fh * f)));
                }
            }
            o["snk"] = snk;
        }
    }
}
