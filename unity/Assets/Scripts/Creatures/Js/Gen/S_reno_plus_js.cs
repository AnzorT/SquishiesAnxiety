// reno-plus.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[^a-z]+", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("\\s+", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("Hearth Feature|Outdoor Hearth", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile(">", "g");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("&", "g");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("pit sofa|curved|conversation", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("horseshoe|u-shaped|booth", "");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("l-shaped|sectional|banquette", "");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("two-seater|loveseat|2-seat|pair|bench", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("levitat|floating|anti-grav|zero-g|hover", "");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("wingback|throne", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("tufted|chesterfield|wingback", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("^#(e|f|d)", "i");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("^#(e|f)", "i");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile("boucl\u00e9|boucle|upholstered|dining armchair", "");
        static readonly System.Text.RegularExpressions.Regex RX17 = JsRegExp.Compile("papasan", "");
        static readonly System.Text.RegularExpressions.Regex RX18 = JsRegExp.Compile("thonet|bentwood|cane", "");
        static readonly System.Text.RegularExpressions.Regex RX19 = JsRegExp.Compile("windsor|spindle", "");
        static readonly System.Text.RegularExpressions.Regex RX20 = JsRegExp.Compile("folding", "");
        static readonly System.Text.RegularExpressions.Regex RX21 = JsRegExp.Compile("brass|gold", "");
        static readonly System.Text.RegularExpressions.Regex RX22 = JsRegExp.Compile("levitat|hydraulic", "");
        static readonly System.Text.RegularExpressions.Regex RX23 = JsRegExp.Compile("emerald", "");
        static readonly System.Text.RegularExpressions.Regex RX24 = JsRegExp.Compile("leather|tractor", "");
        static readonly System.Text.RegularExpressions.Regex RX25 = JsRegExp.Compile("countertop|portable|mini", "");
        static readonly System.Text.RegularExpressions.Regex RX26 = JsRegExp.Compile("wood-panel|integrated", "");
        static readonly System.Text.RegularExpressions.Regex RX27 = JsRegExp.Compile("plasma|robotic", "");
        static readonly System.Text.RegularExpressions.Regex RX28 = JsRegExp.Compile("obsidian", "");
        static readonly System.Text.RegularExpressions.Regex RX29 = JsRegExp.Compile("navy", "");
        static readonly System.Text.RegularExpressions.Regex RX30 = JsRegExp.Compile("^chair(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX31 = JsRegExp.Compile("^pit(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX32 = JsRegExp.Compile("^usofa(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX33 = JsRegExp.Compile("^lsofa(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX34 = JsRegExp.Compile("^armchair(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX35 = JsRegExp.Compile("^(sofa|longSofa)(?=$|[.@*+])", "");
        static readonly System.Text.RegularExpressions.Regex RX36 = JsRegExp.Compile("\\b(burgundy|crimson|red|cherry|mustard|yellow|orange|lavender|purple|plum|navy|blue|teal|mint|sage|green|emerald|olive|charcoal|black|white|cream|ivory|gray|grey|silver|gold|golden|pastel|cobalt|beige)\\b", "gi");
        public static void Run()
        {
Call(Named(boot_229 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cush_13 = default;
V cyl_14 = default;
V ball_15 = default;
V slab_16 = default;
V slabX_17 = default;
V arcW_18 = default;
V disc_19 = default;
V pillowY_20 = default;
V pillowZ_21 = default;
V shade_22 = default;
V f1_23 = default;
V N_24 = default;
V M_25 = default;
V em_26 = default;
V NE_27 = default;
V GOLD_28 = default;
V CH_29 = default;
V WH_30 = default;
V GL_31 = default;
double PI_32 = 0;
V IRON_33 = default;
V metal_34 = default;
V mt_35 = default;
V rep_36 = default;
V an_37 = default;
V at_38 = default;
V P2_39 = default;
V about_40 = default;
V @fixed_41 = default;
V n4_42 = default;
V mtx_43 = default;
V plane_44 = default;
V planeH_45 = default;
V xe_46 = default;
V bob_47 = default;
V GLOW_48 = default;
V steam_49 = default;
V drip_50 = default;
V spark_51 = default;
V bubbles_52 = default;
V plate_53 = default;
V hash_54 = default;
V rng_55 = default;
V PAINT_56 = default;
V PASTEL_57 = default;
V PALS_58 = default;
V MODES_59 = default;
V LUXC_60 = default;
V LROT_61 = default;
V POUF_62 = default;
V QUOTES_63 = default;
V SIGNTX_64 = default;
V DEL_65 = default;
V SET_66 = default;
V Q_67 = default;
V SG_68 = default;
V LED_69 = default;
V ADD_70 = default;
V COLW_71 = default;
V consolidate_72 = default;
V edit_73 = default;
V FOOD_74 = default;
if (_self1.IsNullish) _self1 = GlobalV;
consolidate_72 = Fn((V _self75, int _argc76, V R_82, V _a79, V _a80, V _a81, V[] _rest77) => {
V G_83 = default;
V drop_84 = default;
if (_self75.IsNullish) _self75 = GlobalV;
G_83 = New(G("Map"));
Invoke(R_82, "forEach", Fn((V _arrowThis92, int _argc85, V r_91, V _a88, V _a89, V _a90, V[] _rest86) => {
V k_93 = default;
k_93 = ((V)(JsStrBuf.Begin().V(Get(r_91, "room")).S("|").V(Get(r_91, "slot")).S("|").V(Invoke(Invoke(Invoke(Invoke(Get(r_91, "name"), "toLowerCase"), "replace", COLW_71, ((V)(""))), "replace", NewRegExp(RX0, "[^a-z]+", "g"), ((V)(" "))), "trim")).End()));
if (!(Truthy(Invoke(G_83, "has", k_93)))) {
Invoke(G_83, "set", k_93, Arr());
}
Invoke(Invoke(G_83, "get", k_93), "push", r_91);
return default;
}, 1, "", true));
drop_84 = New(G("Set"));
Invoke(G_83, "forEach", Fn((V _arrowThis101, int _argc94, V g_100, V _a97, V _a98, V _a99, V[] _rest95) => {
V keep_102 = default;
if (Truthy(((LtN(Get(g_100, "length"), 2D) ? V.True : V.False) is var _t111 && Truthy(_t111) ? _t111 : Invoke(g_100, "some", Fn((V _arrowThis110, int _argc103, V r_109, V _a106, V _a107, V _a108, V[] _rest104) => {
return Get(r_109, "colors");
}, 1, "", true))))) {
return default;
}
keep_102 = GetIdx(g_100, 0D);
Set(keep_102, "colors", Invoke(g_100, "map", Fn((V _arrowThis119, int _argc112, V r_118, V _a115, V _a116, V _a117, V[] _rest113) => {
V w_120 = default;
w_120 = GetIdx((Invoke(Get(r_118, "name"), "match", COLW_71) is var _t121 && Truthy(_t121) ? _t121 : Arr(((V)("Colour")))), 0D);
return NewObj(2).Put("n", Add(Invoke(GetIdx(w_120, 0D), "toUpperCase"), Invoke(Invoke(w_120, "slice", ((V)(1D))), "toLowerCase"))).Put("c", Get(Invoke(RD_8, "colorsOf", Get(r_118, "name"), ((V)("cot"))), "a")).V;
return default;
}, 1, "", true)));
Set(keep_102, "name", Invoke(Invoke(Invoke(Get(keep_102, "name"), "replace", COLW_71, ((V)(""))), "replace", NewRegExp(RX1, "\\s+", "g"), ((V)(" "))), "trim"));
Invoke(Invoke(g_100, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis129, int _argc122, V r_128, V _a125, V _a126, V _a127, V[] _rest123) => {
return Invoke(drop_84, "add", r_128);
}, 1, "", true));
return default;
}, 1, "", true));
return Invoke(R_82, "filter", Fn((V _arrowThis137, int _argc130, V r_136, V _a133, V _a134, V _a135, V[] _rest131) => {
return (!(Truthy(Invoke(drop_84, "has", r_136))) ? V.True : V.False);
}, 1, "", true));
return default;
}, 1, "consolidate", false);
edit_73 = Fn((V _self138, int _argc139, V rows_145, V _a142, V _a143, V _a144, V[] _rest140) => {
V R_146 = default;
if (_self138.IsNullish) _self138 = GlobalV;
R_146 = Invoke(Invoke(rows_145, "filter", Fn((V _arrowThis162, int _argc155, V r_161, V _a158, V _a159, V _a160, V[] _rest156) => {
return (!(Truthy(Invoke(DEL_65, "has", Get(r_161, "id")))) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis154, int _argc147, V r_153, V _a150, V _a151, V _a152, V[] _rest148) => {
return (Truthy(GetK(SET_66, Get(r_153, "id"))) ? Object_assign(NewObj(0).V, r_153, GetK(SET_66, Get(r_153, "id"))) : r_153);
}, 1, "", true));
Invoke(ADD_70, "forEach", Fn((V _arrowThis188, int _argc163, V _a165, V _a166, V _a167, V _a168, V[] _rest164) => {
V same_189 = default;
V b_190 = default;
V room_171 = default;
V num_173 = default;
V tier_175 = default;
V bs_177 = default;
V slot_179 = default;
V slotName_181 = default;
V name_183 = default;
V spec_185 = default;
V ex_187 = default;
{ V _t169 = ListOf(_a165);
{ V _t170 = GetIdx(_t169, 0D);
room_171 = _t170; }
{ V _t172 = GetIdx(_t169, 1D);
num_173 = _t172; }
{ V _t174 = GetIdx(_t169, 2D);
tier_175 = _t174; }
{ V _t176 = GetIdx(_t169, 3D);
bs_177 = _t176; }
{ V _t178 = GetIdx(_t169, 4D);
slot_179 = _t178; }
{ V _t180 = GetIdx(_t169, 5D);
slotName_181 = _t180; }
{ V _t182 = GetIdx(_t169, 6D);
name_183 = _t182; }
{ V _t184 = GetIdx(_t169, 7D);
spec_185 = _t184; }
{ V _t186 = GetIdx(_t169, 8D);
ex_187 = _t186; }
}
same_189 = Invoke(rows_145, "filter", Fn((V _arrowThis198, int _argc191, V r_197, V _a194, V _a195, V _a196, V[] _rest192) => {
return (SEq(Get(r_197, "room"), room_171) ? V.True : V.False);
}, 1, "", true));
b_190 = (Invoke(same_189, "find", Fn((V _arrowThis206, int _argc199, V r_205, V _a202, V _a203, V _a204, V[] _rest200) => {
return ((SEq(Get(r_205, "tier"), tier_175) && SEq(Get(r_205, "slot"), bs_177)) ? V.True : V.False);
}, 1, "", true)) is var _t215 && Truthy(_t215) ? _t215 : Invoke(same_189, "find", Fn((V _arrowThis214, int _argc207, V r_213, V _a210, V _a211, V _a212, V[] _rest208) => {
return (SEq(Get(r_213, "tier"), tier_175) ? V.True : V.False);
}, 1, "", true)));
if (Truthy(b_190)) {
Invoke(R_146, "push", Object_assign(NewObj(0).V, b_190, NewObj(6).Put("id", ((V)(JsStrBuf.Begin().V(room_171).S("-").V(num_173).End()))).Put("slot", slot_179).Put("slotName", slotName_181).Put("name", name_183).Put("spec", spec_185).Put("add", ((V)(1D))).V, ex_187));
}
return default;
}, 1, "", true));
R_146 = Call(consolidate_72, V.Undef, R_146);
Invoke(R_146, "forEach", Fn((V _arrowThis223, int _argc216, V r_222, V _a219, V _a220, V _a221, V[] _rest217) => {
if ((SEqS(Get(r_222, "room"), "YRD") && ((SEqN(Get(r_222, "slot"), 16D) || SEqN(Get(r_222, "slot"), 17D)) || SEqN(Get(r_222, "slot"), 21D)))) {
Set(r_222, "catO", ((V)("Games")));
}
if (Truthy(Invoke(NewRegExp(RX2, "Hearth Feature|Outdoor Hearth", ""), "test", Get(r_222, "slotName")))) {
Set(r_222, "live", ((V)("Live fire")));
}
return default;
}, 1, "", true));
return R_146;
return default;
}, 1, "edit", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((RD_8 is var _t224 && !Truthy(_t224) ? _t224 : Get(RD_8, "H")) is var _t225 && !Truthy(_t225) ? _t225 : X_9) is var _t226 && !Truthy(_t226) ? _t226 : Get(X_9, "ARCH")) is var _t227 && !Truthy(_t227) ? _t227 : Get(Get(X_9, "ARCH"), "sign")) is var _t228 && !Truthy(_t228) ? _t228 : Get(X_9, "SIGNST"))))) {
Call(G("setTimeout"), V.Undef, boot_229.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t230 = K_10;
if (_t230.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t230));
{ V _t231 = Get(_t230, "solid");
solid_11 = _t231; }
{ V _t232 = Get(_t230, "box");
box_12 = _t232; }
{ V _t233 = Get(_t230, "cush");
cush_13 = _t233; }
{ V _t234 = Get(_t230, "cyl");
cyl_14 = _t234; }
{ V _t235 = Get(_t230, "ball");
ball_15 = _t235; }
{ V _t236 = Get(_t230, "slab");
slab_16 = _t236; }
{ V _t237 = Get(_t230, "slabX");
slabX_17 = _t237; }
{ V _t238 = Get(_t230, "arcW");
arcW_18 = _t238; }
{ V _t239 = Get(_t230, "disc");
disc_19 = _t239; }
{ V _t240 = Get(_t230, "pillowY");
pillowY_20 = _t240; }
{ V _t241 = Get(_t230, "pillowZ");
pillowZ_21 = _t241; }
{ V _t242 = Get(_t230, "shade");
shade_22 = _t242; }
{ V _t243 = Get(_t230, "f1");
f1_23 = _t243; } }
N_24 = Get(RD_8, "N");
M_25 = Get(RD_8, "MAP");
em_26 = Get(Get(RD_8, "H"), "em");
NE_27 = Get(K_10, "NEON");
GOLD_28 = ((V)("#e2b14a"));
CH_29 = ((V)("#d5dde2"));
WH_30 = ((V)("#ffffff"));
GL_31 = ((V)("#cfe8f2"));
PI_32 = System.Math.PI;
IRON_33 = ((V)("#3b3c40"));
metal_34 = Fn((V _arrowThis251, int _argc244, V k_250, V _a247, V _a248, V _a249, V[] _rest245) => {
return (SEqS(k_250, "royal") ? GOLD_28 : (SEqS(k_250, "candy") ? ((V)("#e9ecef")) : (SEqS(k_250, "junk") ? ((V)("#7d7f84")) : (SEqS(k_250, "mod") ? ((V)("#2c2d31")) : (SEqS(k_250, "retro") ? CH_29 : IRON_33)))));
}, 1, "", true);
mt_35 = Fn((V _arrowThis259, int _argc252, V o_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return Object_assign(NewObj(1).Put("mat", ((V)("metal"))).V, (o_258 is var _t260 && Truthy(_t260) ? _t260 : NewObj(0).V));
}, 1, "", true);
rep_36 = Fn((V _arrowThis269, int _argc261, V n_267, V f_268, V _a265, V _a266, V[] _rest262) => {
return Array_from(NewObj(1).Put("length", n_267).V, Fn((V _arrowThis278, int _argc270, V __276, V i_277, V _a274, V _a275, V[] _rest271) => {
return Call(f_268, V.Undef, i_277);
}, 2, "", true));
}, 2, "", true);
an_37 = Fn((V _arrowThis290, int _argc279, V a_285, V v_286, V d_287, V b_288, V[] _rest280) => {
V kt_289 = default;
kt_289 = (_argc279 > 4 ? _rest280[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_285).S("\" values=\"").V(v_286).S("\" dur=\"").V(d_287).S("s\"").S((Truthy(kt_289) ? JsStrBuf.Begin().S(" keyTimes=\"").V(kt_289).S("\"").End() : "")).S((Truthy(b_288) ? JsStrBuf.Begin().S(" begin=\"").V(b_288).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
at_38 = Fn((V _arrowThis302, int _argc291, V t_297, V v_298, V d_299, V b_300, V[] _rest292) => {
V kt_301 = default;
kt_301 = (_argc291 > 4 ? _rest292[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_297).S("\" values=\"").V(v_298).S("\" dur=\"").V(d_299).S("s\"").S((Truthy(kt_301) ? JsStrBuf.Begin().S(" keyTimes=\"").V(kt_301).S("\"").End() : "")).S((Truthy(b_300) ? JsStrBuf.Begin().S(" begin=\"").V(b_300).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
P2_39 = Fn((V _arrowThis310, int _argc303, V q_309, V _a306, V _a307, V _a308, V[] _rest304) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_309, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_309, 1D))).End()));
}, 1, "", true);
about_40 = Fn((V _arrowThis320, int _argc311, V q_317, V anim_318, V s_319, V _a316, V[] _rest312) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_39, V.Undef, q_317)).S(")\"><g>").V(anim_318).S("<g transform=\"translate(").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_317, 0D))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_317, 1D))))))).S(")\">").V(s_319).S("</g></g></g>").End()));
}, 3, "", true);
@fixed_41 = Fn((V _arrowThis330, int _argc321, V q_327, V tf_328, V s_329, V _a326, V[] _rest322) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_39, V.Undef, q_327)).S(") ").V(tf_328).S(" translate(").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_327, 0D))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_327, 1D))))))).S(")\">").V(s_329).S("</g>").End()));
}, 3, "", true);
n4_42 = Fn((V _arrowThis338, int _argc331, V v_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return ((V)((Round((ToNum(v_337) * 10000D)) / 10000D)));
}, 1, "", true);
mtx_43 = Fn((V _arrowThis348, int _argc339, V o_345, V a_346, V b_347, V _a344, V[] _rest340) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_346, 0D)) - ToNum(GetIdx(o_345, 0D))))), ((V)((ToNum(GetIdx(a_346, 1D)) - ToNum(GetIdx(o_345, 1D))))), ((V)((ToNum(GetIdx(b_347, 0D)) - ToNum(GetIdx(o_345, 0D))))), ((V)((ToNum(GetIdx(b_347, 1D)) - ToNum(GetIdx(o_345, 1D))))), GetIdx(o_345, 0D), GetIdx(o_345, 1D)), "map", n4_42), "join", ((V)(" ")))).S(")").End()));
}, 3, "", true);
plane_44 = Fn((V _arrowThis358, int _argc349, V p_355, V z_356, V y_357, V _a354, V[] _rest350) => {
return Call(mtx_43, V.Undef, Call(p_355, V.Undef, ((V)(0D)), y_357, z_356), Call(p_355, V.Undef, ((V)(1D)), y_357, z_356), Call(p_355, V.Undef, ((V)(0D)), ((V)((ToNum(y_357) - 1D))), z_356));
}, 3, "", true);
planeH_45 = Fn((V _arrowThis367, int _argc359, V p_365, V y_366, V _a363, V _a364, V[] _rest360) => {
return Call(mtx_43, V.Undef, Call(p_365, V.Undef, ((V)(0D)), y_366, ((V)(0D))), Call(p_365, V.Undef, ((V)(1D)), y_366, ((V)(0D))), Call(p_365, V.Undef, ((V)(0D)), y_366, ((V)(1D))));
}, 2, "", true);
xe_46 = Fn((V _arrowThis375, int _argc368, V s_374, V _a371, V _a372, V _a373, V[] _rest369) => {
return Invoke(Invoke(Invoke(Invoke(((V)(ToStrS(s_374))), "replace", NewRegExp(RX6, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX5, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX4, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX3, "\"", "g"), ((V)("&quot;")));
}, 1, "", true);
bob_47 = Fn((V _arrowThis384, int _argc376, V a_382, V d_383, V _a380, V _a381, V[] _rest377) => {
return Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").N((-ToNum(a_382))).S(";0 0").End())), d_383);
}, 2, "", true);
GLOW_48 = ((V)("<filter id=\"gw\" x=\"-40%\" y=\"-80%\" width=\"180%\" height=\"260%\"><feGaussianBlur stdDeviation=\"1.6\" result=\"b\"/><feMerge><feMergeNode in=\"b\"/><feMergeNode in=\"SourceGraphic\"/></feMerge></filter>"));
steam_49 = Fn((V _arrowThis397, int _argc385, V c_391, V x_392, V y_393, V z_394, V[] _rest386) => {
V q_398 = default;
JsStrBuf o_399 = null;
V s_395 = default;
V n_396 = default;
s_395 = (_argc385 > 4 ? _rest386[0] : V.Undef);
n_396 = (_argc385 > 5 ? _rest386[1] : V.Undef);
q_398 = Invoke(c_391, "p", x_392, y_393, z_394);
o_399 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_39, V.Undef, q_398)).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(c_391, "k")) * ToNum((s_395 is var _t400 && Truthy(_t400) ? _t400 : ((V)(1D))))))))).S(")\">").End());
{
double i_401 = 0;
i_401 = 0D;
while (true) {
if (!(Lt(((V)(i_401)), (n_396 is var _t403 && Truthy(_t403) ? _t403 : ((V)(3D)))))) break;
double dx_404 = 0;
dx_404 = ((i_401 - ((ToNum((n_396 is var _t405 && Truthy(_t405) ? _t405 : ((V)(3D)))) - 1D) / 2D)) * 4D);
o_399.S("<path d=\"M").N(dx_404).S(" 0q-3 -5 0 -10t0 -10\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.5\" stroke-linecap=\"round\" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;0.8;0")), ((V)(2.4)), ((V)(((-i_401) * 0.8))))).V(Call(at_38, V.Undef, ((V)("translate")), ((V)("0 0;0 -9")), ((V)(2.4)), ((V)(((-i_401) * 0.8))))).S("</path>");
i_401++;
}
}
return ((V)(string.Concat(o_399.Str, "</g>")));
return default;
}, 6, "", true);
drip_50 = Fn((V _arrowThis420, int _argc406, V c_412, V x_413, V y0_414, V y1_415, V[] _rest407) => {
V a_421 = default;
V e_422 = default;
V z_416 = default;
V col_417 = default;
V d_418 = default;
V b_419 = default;
z_416 = (_argc406 > 4 ? _rest407[0] : V.Undef);
col_417 = (_argc406 > 5 ? _rest407[1] : V.Undef);
d_418 = (_argc406 > 6 ? _rest407[2] : V.Undef);
b_419 = (_argc406 > 7 ? _rest407[3] : V.Undef);
a_421 = Invoke(c_412, "p", x_413, y0_414, z_416);
e_422 = Invoke(c_412, "p", x_413, y1_415, z_416);
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_421, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_421, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(Get(c_412, "k"))))))).S("\" fill=\"").V(col_417).S("\">").V(Call(an_37, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_421, 1D))).S(";").V(Call(f1_23, V.Undef, GetIdx(e_422, 1D))).End())), (d_418 is var _t423 && Truthy(_t423) ? _t423 : ((V)(0.9))), b_419)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;1;0")), (d_418 is var _t424 && Truthy(_t424) ? _t424 : ((V)(0.9))), b_419)).S("</circle>").End()));
return default;
}, 8, "", true);
spark_51 = Fn((V _arrowThis438, int _argc425, V c_431, V x_432, V y_433, V z_434, V[] _rest426) => {
V s_435 = default;
V b_436 = default;
V col_437 = default;
s_435 = (_argc425 > 4 ? _rest426[0] : V.Undef);
b_436 = (_argc425 > 5 ? _rest426[1] : V.Undef);
col_437 = (_argc425 > 6 ? _rest426[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_39, V.Undef, Invoke(c_431, "p", x_432, y_433, z_434))).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(c_431, "k")) * ToNum((s_435 is var _t439 && Truthy(_t439) ? _t439 : ((V)(1D))))))))).S(")\"><path d=\"M0 -4L1 -1L4 0L1 1L0 4L-1 1L-4 0L-1 -1Z\" fill=\"").V((col_437 is var _t440 && Truthy(_t440) ? _t440 : ((V)("#ffffff")))).S("\" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(1.8)), b_436)).S("</path></g>").End()));
}, 7, "", true);
bubbles_52 = Fn((V _arrowThis454, int _argc441, V c_447, V x_448, V y_449, V z_450, V[] _rest442) => {
V w_451 = default;
V n_452 = default;
V col_453 = default;
w_451 = (_argc441 > 4 ? _rest442[0] : V.Undef);
n_452 = (_argc441 > 5 ? _rest442[1] : V.Undef);
col_453 = (_argc441 > 6 ? _rest442[2] : V.Undef);
return Invoke(Call(rep_36, V.Undef, n_452, Fn((V _arrowThis462, int _argc455, V i_461, V _a458, V _a459, V _a460, V[] _rest456) => {
V q_463 = default;
V r_464 = default;
V d_465 = default;
V b_466 = default;
q_463 = Invoke(c_447, "p", Add(x_448, ((V)((((((ToNum(i_461) * 37D) % 100D) / 100D) - 0.5) * ToNum(w_451))))), y_449, z_450);
r_464 = Call(f1_23, V.Undef, ((V)(((1D + ((ToNum(i_461) % 3D) * 0.6)) * ToNum(Get(c_447, "k"))))));
d_465 = Invoke(((V)((1.6 + ((ToNum(i_461) % 4D) * 0.3)))), "toFixed", ((V)(1D)));
b_466 = Invoke(((V)(((-ToNum(i_461)) * 0.37))), "toFixed", ((V)(2D)));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_463, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_463, 1D))).S("\" r=\"").V(r_464).S("\" fill=\"none\" stroke=\"").V((col_453 is var _t467 && Truthy(_t467) ? _t467 : ((V)("#ffffff")))).S("\" stroke-width=\"0.7\">").V(Call(an_37, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_463, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_463, 1D)) - (22D * ToNum(Get(c_447, "k")))))))).End())), d_465, b_466)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_465, b_466)).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 7, "", true);
plate_53 = Fn((V _arrowThis480, int _argc468, V x_474, V y_475, V z_476, V r_477, V[] _rest469) => {
V col_478 = default;
V o_479 = default;
col_478 = (_argc468 > 4 ? _rest469[0] : V.Undef);
o_479 = (_argc468 > 5 ? _rest469[1] : V.Undef);
return Call(solid_11, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_476, y_475)).Put("a", r_477).Put("b", r_477).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((ToNum(x_474) - 0.7))), ((V)(0D))), Arr(Add(x_474, ((V)(0.7))), ((V)(0D))))).Put("col", col_478).Put("mat", ((V)("cer"))).V, (o_479 is var _t481 && Truthy(_t481) ? _t481 : NewObj(0).V)));
}, 6, "", true);
hash_54 = Fn((V _arrowThis489, int _argc482, V s_488, V _a485, V _a486, V _a487, V[] _rest483) => {
double h_490 = 0;
h_490 = 7D;
{
foreach (V _k491 in new JsIter(((V)(ToStrS(s_488))))) {
V ch_492 = default;
ch_492 = _k491;
h_490 = ((double)(ToInt32(ToNum(Add(((V)((h_490 * 31D))), Invoke(ch_492, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return ((V)(System.Math.Abs(h_490)));
return default;
}, 1, "", true);
rng_55 = Fn((V _arrowThis500, int _argc493, V s_499, V _a496, V _a497, V _a498, V[] _rest494) => {
V h_501 = default;
h_501 = (Call(hash_54, V.Undef, s_499) is var _t502 && Truthy(_t502) ? _t502 : ((V)(1D)));
return Fn((V _arrowThis509, int _argc503, V _a505, V _a506, V _a507, V _a508, V[] _rest504) => {
h_501 = ((V)(((double)(ToInt32(((ToNum(h_501) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_501)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
Set(N_24, "rsofa", Fn((V _arrowThis517, int _argc510, V S_516, V _a513, V _a514, V _a515, V[] _rest511) => {
V nm_518 = default;
V k_519 = default;
V v_520 = default;
V shp_521 = default;
V n_522 = default;
V fl_523 = default;
V met_524 = default;
double SW_525 = 0;
double AW_526 = 0;
double Dp_527 = 0;
double ext_528 = 0;
double by_529 = 0;
V wing_530 = default;
V anim_531 = default;
V pad_532 = default;
V cols_533 = default;
double Wd_534 = 0;
V xs_535 = default;
V eL_536 = default;
V eR_537 = default;
V seats_538 = default;
nm_518 = Get(S_516, "nm");
k_519 = Get(S_516, "k");
v_520 = Get(S_516, "v");
shp_521 = (Get(S_516, "shape") is var _t542 && Truthy(_t542) ? _t542 : ((V)((Truthy(((SEqS(v_520, "L") ? V.True : V.False) is var _t541 && Truthy(_t541) ? _t541 : Invoke(NewRegExp(RX9, "l-shaped|sectional|banquette", ""), "test", nm_518))) ? "L" : (Truthy(((SEqS(v_520, "U") ? V.True : V.False) is var _t540 && Truthy(_t540) ? _t540 : Invoke(NewRegExp(RX8, "horseshoe|u-shaped|booth", ""), "test", nm_518))) ? "U" : (Truthy(((SEqS(v_520, "pit") ? V.True : V.False) is var _t539 && Truthy(_t539) ? _t539 : Invoke(NewRegExp(RX7, "pit sofa|curved|conversation", ""), "test", nm_518))) ? "pit" : ""))))));
n_522 = (Get(S_516, "n") is var _t543 && Truthy(_t543) ? _t543 : ((V)((SEqS(v_520, "1") ? 1D : (Truthy(Invoke(NewRegExp(RX10, "two-seater|loveseat|2-seat|pair|bench", ""), "test", nm_518)) ? 2D : (SEqS(shp_521, "L") ? 4D : (Truthy(shp_521) ? 5D : 3D)))))));
if (SEqN(n_522, 1D)) {
shp_521 = ((V)(""));
}
if ((SEqS(shp_521, "L") && LtN(n_522, 3D))) {
n_522 = ((V)(3D));
}
if ((SEqS(shp_521, "U") && LtN(n_522, 4D))) {
n_522 = ((V)(4D));
}
fl_523 = (Get(S_516, "float") is var _t544 && Truthy(_t544) ? _t544 : Invoke(NewRegExp(RX11, "levitat|floating|anti-grav|zero-g|hover", ""), "test", nm_518));
met_524 = Call(metal_34, V.Undef, k_519);
SW_525 = 58D;
AW_526 = (SEqN(n_522, 1D) ? 18D : 20D);
Dp_527 = 88D;
ext_528 = 62D;
by_529 = (9D + (Truthy(fl_523) ? 14D : 0D));
wing_530 = Invoke(NewRegExp(RX12, "wingback|throne", ""), "test", nm_518);
anim_531 = (Truthy(fl_523) ? Call(bob_47, V.Undef, ((V)(5D)), ((V)(3.2))) : ((V)("")));
pad_532 = (Truthy(fl_523) ? Arr(((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(0D))) : V.Null);
if (SEqS(shp_521, "pit")) {
double R0_545 = 0;
double Rz_546 = 0;
double a0_547 = 0;
double a1_548 = 0;
double zc_549 = 0;
V sp_550 = default;
R0_545 = (30D + (ToNum(n_522) * 16D));
Rz_546 = (R0_545 * 0.75);
a0_547 = (PI_32 * 1.02);
a1_548 = (PI_32 * 1.98);
zc_549 = (R0_545 * 0.35);
sp_550 = Call(rep_36, V.Undef, n_522, Fn((V _arrowThis558, int _argc551, V i_557, V _a554, V _a555, V _a556, V[] _rest552) => {
double a_559 = 0;
a_559 = (a0_547 + (((a1_548 - a0_547) * ToNum(Add(i_557, ((V)(0.5))))) / ToNum(n_522)));
return NewObj(3).Put("x", ((V)((FdLibm.Cos(a_559) * (R0_545 - 30D))))).Put("z", ((V)((zc_549 + (FdLibm.Sin(a_559) * (Rz_546 - 30D)))))).Put("a", ((V)(a_559))).V;
return default;
}, 1, "", true));
return NewObj(7).Put("w", ((V)(((R0_545 * 2D) + 10D)))).Put("d", ((V)((Rz_546 * 2D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(sp_550, "map", Fn((V _arrowThis567, int _argc560, V s_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return NewObj(3).Put("x", Get(s_566, "x")).Put("z", Get(s_566, "z")).Put("h", ((V)((by_529 + 30D)))).V;
}, 1, "", true))).Put("anim", anim_531).Put("pad", pad_532).Put("build", Fn((V _arrowThis575, int _argc568, V P_574, V _a571, V _a572, V _a573, V[] _rest569) => {
V o_576 = default;
o_576 = Arr();
if (Truthy(fl_523)) {
Invoke(o_576, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((by_529 - 7D))), ((V)((zc_549 - (Rz_546 * 0.4)))), ((V)((R0_545 * 0.7))), ((V)(2D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(3).Put("rz", ((V)((Rz_546 * 0.4)))).Put("op", ((V)(0.5))).Put("n", ((V)(20D))).V)));
} else {
Call(rep_36, V.Undef, Add(n_522, ((V)(1D))), Fn((V _arrowThis584, int _argc577, V i_583, V _a580, V _a581, V _a582, V[] _rest578) => {
double a_585 = 0;
a_585 = (a0_547 + (((a1_548 - a0_547) * ToNum(i_583)) / ToNum(n_522)));
Invoke(o_576, "push", Call(cyl_14, V.Undef, ((V)((FdLibm.Cos(a_585) * (R0_545 - 20D)))), ((V)(0D)), ((V)((zc_549 + (FdLibm.Sin(a_585) * (Rz_546 - 20D))))), ((V)(2.6)), ((V)(by_529)), met_524, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
}
Invoke(o_576, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)((by_529 - 3D))), ((V)(zc_549)), ((V)((R0_545 - 2D))), ((V)((Rz_546 - 2D))), ((V)(54D)), ((V)(3D)), ((V)(a0_547)), ((V)(a1_548)), met_524, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(by_529)), ((V)(zc_549)), ((V)(R0_545)), ((V)(Rz_546)), ((V)(58D)), ((V)(15D)), ((V)(a0_547)), ((V)(a1_548)), Get(P_574, "aD"), NewObj(3).Put("n", ((V)(18D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)((by_529 + 12D))), ((V)(zc_549)), ((V)((R0_545 + 2D))), ((V)((Rz_546 + 2D))), ((V)(14D)), ((V)(46D)), ((V)(a0_547)), ((V)(a1_548)), Get(P_574, "a"), NewObj(3).Put("n", ((V)(18D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(sp_550, "forEach", Fn((V _arrowThis593, int _argc586, V s_592, V _a589, V _a590, V _a591, V[] _rest587) => {
return Invoke(o_576, "push", Call(pillowY_20, V.Undef, Get(s_592, "x"), ((V)((by_529 + 14D))), Get(s_592, "z"), ((V)(50D)), ((V)(16D)), ((V)(44D)), Get(P_574, "aL"), NewObj(1).Put("yaw", Add(Get(s_592, "a"), ((V)((PI_32 / 2D))))).V));
}, 1, "", true));
Invoke(Arr(((V)(a0_547)), ((V)(a1_548))), "forEach", Fn((V _arrowThis601, int _argc594, V a_600, V _a597, V _a598, V _a599, V[] _rest595) => {
return Invoke(o_576, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(ToNum(a_600)) * (R0_545 - 26D)))), ((V)((by_529 + 4D))), ((V)((zc_549 + (FdLibm.Sin(ToNum(a_600)) * (Rz_546 - 26D))))), ((V)(15D)), Get(P_574, "a"), NewObj(4).Put("k", ((V)(6D))).Put("n", ((V)(14D))).Put("soft", ((V)(1D))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
return o_576;
return default;
}, 1, "build", true)).V;
}
cols_533 = (SEqS(shp_521, "L") ? ((V)((ToNum(n_522) - 1D))) : (SEqS(shp_521, "U") ? ((V)((ToNum(n_522) - 2D))) : n_522));
Wd_534 = ((ToNum(cols_533) * SW_525) + (AW_526 * 2D));
xs_535 = Call(rep_36, V.Undef, cols_533, Fn((V _arrowThis609, int _argc602, V i_608, V _a605, V _a606, V _a607, V[] _rest603) => {
return ((V)(((((-Wd_534) / 2D) + AW_526) + (SW_525 * ToNum(Add(i_608, ((V)(0.5))))))));
}, 1, "", true));
eL_536 = ((SEqS(shp_521, "L") || SEqS(shp_521, "U")) ? V.True : V.False);
eR_537 = (SEqS(shp_521, "U") ? V.True : V.False);
seats_538 = Invoke(xs_535, "map", Fn((V _arrowThis617, int _argc610, V x_616, V _a613, V _a614, V _a615, V[] _rest611) => {
return NewObj(3).Put("x", x_616).Put("z", ((V)(6D))).Put("h", ((V)((by_529 + 30D)))).V;
}, 1, "", true));
if (Truthy(eL_536)) {
Invoke(seats_538, "push", NewObj(3).Put("x", GetIdx(xs_535, 0D)).Put("z", ((V)((((Dp_527 / 2D) + (ext_528 / 2D)) - 2D)))).Put("h", ((V)((by_529 + 30D)))).V);
}
if (Truthy(eR_537)) {
Invoke(seats_538, "push", NewObj(3).Put("x", GetIdx(xs_535, (ToNum(cols_533) - 1D))).Put("z", ((V)((((Dp_527 / 2D) + (ext_528 / 2D)) - 2D)))).Put("h", ((V)((by_529 + 30D)))).V);
}
return NewObj(7).Put("w", ((V)(Wd_534))).Put("d", ((V)((Dp_527 + (Truthy(eL_536) ? ext_528 : 0D))))).Put("act", ((V)("sit"))).Put("seats", seats_538).Put("anim", anim_531).Put("pad", pad_532).Put("build", Fn((V _arrowThis625, int _argc618, V P_624, V _a621, V _a622, V _a623, V[] _rest619) => {
V o_626 = default;
V fab_627 = default;
V fL_628 = default;
V fD_629 = default;
V tuft_630 = default;
double bh_631 = 0;
double bz_632 = 0;
o_626 = Arr();
fab_627 = Get(P_624, "a");
fL_628 = Get(P_624, "aL");
fD_629 = Get(P_624, "aD");
tuft_630 = (((SEqS(k_519, "royal") || SEqS(k_519, "cot")) ? V.True : V.False) is var _t633 && Truthy(_t633) ? _t633 : Invoke(NewRegExp(RX13, "tufted|chesterfield|wingback", ""), "test", nm_518));
if (!(Truthy(fl_523))) {
double lx_634 = 0;
double lz_635 = 0;
V L_636 = default;
lx_634 = ((Wd_534 / 2D) - 7D);
lz_635 = ((Dp_527 / 2D) - 9D);
L_636 = Arr(Arr(((V)((-lx_634))), ((V)((-lz_635)))), Arr(((V)(lx_634)), ((V)((-lz_635)))), Arr(((V)((-lx_634))), ((V)(lz_635))), Arr(((V)(lx_634)), ((V)(lz_635))));
if (Truthy(eL_536)) {
Invoke(L_636, "push", Arr(((V)((-lx_634))), ((V)((lz_635 + ext_528)))));
}
if (Truthy(eR_537)) {
Invoke(L_636, "push", Arr(((V)(lx_634)), ((V)((lz_635 + ext_528)))));
}
if ((Wd_534 > 200D)) {
Invoke(L_636, "push", Arr(((V)(0D)), ((V)((-lz_635)))), Arr(((V)(0D)), ((V)(lz_635))));
}
Invoke(L_636, "forEach", Fn((V _arrowThis648, int _argc637, V _a639, V _a640, V _a641, V _a642, V[] _rest638) => {
V x_645 = default;
V z_647 = default;
{ V _t643 = ListOf(_a639);
{ V _t644 = GetIdx(_t643, 0D);
x_645 = _t644; }
{ V _t646 = GetIdx(_t643, 1D);
z_647 = _t646; }
}
return Invoke(o_626, "push", (SEqS(k_519, "royal") ? Call(ball_15, V.Undef, x_645, ((V)(0D)), z_647, ((V)(4.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)) : Call(cyl_14, V.Undef, x_645, ((V)(0D)), z_647, ((V)(2.6)), ((V)((by_529 - 1D))), met_524, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.65))), Arr(((V)((by_529 - 1D))), ((V)(0D)), ((V)(1.1))))).V))));
}, 1, "", true));
} else {
Invoke(o_626, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((by_529 - 7D))), ((V)(0D)), ((V)(((Wd_534 / 2D) - 16D))), ((V)(2D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(3).Put("rz", ((V)(((Dp_527 / 2D) - 14D)))).Put("op", ((V)(0.55))).Put("n", ((V)(20D))).V)));
}
Invoke(o_626, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((by_529 - 3D))), ((V)(0D)), ((V)((Wd_534 - 4D))), ((V)(3D)), ((V)((Dp_527 - 4D))), met_524, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(by_529)), ((V)(0D)), ((V)((Wd_534 - 6D))), ((V)(15D)), ((V)((Dp_527 - 6D))), fD_629, NewObj(3).Put("r", ((V)(12D))).Put("bev", ((V)(4D))).Put("mat", ((V)("fab"))).V));
Invoke(Invoke(Arr((eL_536 is var _t659 && !Truthy(_t659) ? _t659 : ((V)((-1D)))), (eR_537 is var _t660 && !Truthy(_t660) ? _t660 : ((V)(1D)))), "filter", G("Boolean")), "forEach", Fn((V _arrowThis656, int _argc649, V sg_655, V _a652, V _a653, V _a654, V[] _rest650) => {
double xc_657 = 0;
double zc_658 = 0;
xc_657 = (ToNum(sg_655) * ((Wd_534 / 2D) - ((AW_526 + SW_525) / 2D)));
zc_658 = (((Dp_527 / 2D) + (ext_528 / 2D)) - 6D);
Invoke(o_626, "push", Call(box_12, V.Undef, ((V)(xc_657)), ((V)((by_529 - 3D))), ((V)(zc_658)), ((V)(((AW_526 + SW_525) - 4D))), ((V)(3D)), ((V)((ext_528 + 6D))), met_524, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(xc_657)), ((V)(by_529)), ((V)(zc_658)), ((V)(((AW_526 + SW_525) - 6D))), ((V)(15D)), ((V)((ext_528 + 6D))), fD_629, NewObj(3).Put("r", ((V)(10D))).Put("bev", ((V)(4D))).Put("mat", ((V)("fab"))).V), Call(pillowY_20, V.Undef, ((V)((ToNum(sg_655) * (((Wd_534 / 2D) - AW_526) - (SW_525 / 2D))))), ((V)((by_529 + 14D))), ((V)((((Dp_527 / 2D) + (ext_528 / 2D)) - 3D))), ((V)((SW_525 - 3D))), ((V)(16D)), ((V)((ext_528 - 4D))), fL_628));
return default;
}, 1, "", true));
Invoke(xs_535, "forEach", Fn((V _arrowThis668, int _argc661, V x_667, V _a664, V _a665, V _a666, V[] _rest662) => {
return Invoke(o_626, "push", Call(pillowY_20, V.Undef, x_667, ((V)((by_529 + 14D))), ((V)(6D)), ((V)((SW_525 - 3D))), ((V)(16D)), ((V)((Dp_527 - 32D))), fL_628));
}, 1, "", true));
bh_631 = (Truthy(wing_530) ? 62D : (SEqS(k_519, "mod") ? 40D : 48D));
bz_632 = (((-Dp_527) / 2D) + 8D);
Invoke(o_626, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)((by_529 + 12D))), ((V)(bz_632)), ((V)(((Wd_534 - (AW_526 * 2D)) + 8D))), ((V)(bh_631)), ((V)(14D)), fab_627, NewObj(3).Put("r", ((V)((SEqS(k_519, "mod") ? 8D : 16D)))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(xs_535, "forEach", Fn((V _arrowThis676, int _argc669, V x_675, V _a672, V _a673, V _a674, V[] _rest670) => {
Invoke(o_626, "push", Call(pillowZ_21, V.Undef, x_675, ((V)((by_529 + 26D))), ((V)((bz_632 + 12D))), ((V)((SW_525 - 4D))), ((V)((bh_631 - 12D))), ((V)(12D)), fL_628));
if (Truthy(tuft_630)) {
Invoke(Arr(((V)((-14D))), ((V)(0D)), ((V)(14D))), "forEach", Fn((V _arrowThis684, int _argc677, V t_683, V _a680, V _a681, V _a682, V[] _rest678) => {
return Invoke(o_626, "push", Call(ball_15, V.Undef, Add(x_675, t_683), ((V)(((by_529 + 26D) + ((bh_631 - 12D) * 0.55)))), ((V)((bz_632 + 18.2))), ((V)(1.7)), (SEqS(k_519, "royal") ? GOLD_28 : Call(shade_22, V.Undef, fab_627, ((V)(0.7)))), Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
}
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis692, int _argc685, V sg_691, V _a688, V _a689, V _a690, V[] _rest686) => {
V e_693 = default;
double z0_694 = 0;
double z1_695 = 0;
double x_696 = 0;
double ah_697 = 0;
e_693 = (LtN(sg_691, 0D) ? eL_536 : eR_537);
z0_694 = (((-Dp_527) / 2D) + 3D);
z1_695 = (((Dp_527 / 2D) - 3D) + (Truthy(e_693) ? ext_528 : 0D));
x_696 = (ToNum(sg_691) * ((Wd_534 / 2D) - (AW_526 / 2D)));
ah_697 = (Truthy(wing_530) ? 40D : 32D);
Invoke(o_626, "push", Call(box_12, V.Undef, ((V)(x_696)), ((V)(by_529)), ((V)(((z0_694 + z1_695) / 2D))), ((V)(AW_526)), ((V)(ah_697)), ((V)((z1_695 - z0_694))), fab_627, NewObj(3).Put("r", ((V)(7D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_696)), ((V)((by_529 + ah_697))))).Put("a", ((V)(((AW_526 / 2D) + 2.5)))).Put("b", ((V)(7D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(z0_694)), ((V)(2.5)), ((V)(0.85))), Arr(((V)((z0_694 + 2.5))), ((V)(0D))), Arr(((V)((z1_695 - 2.5))), ((V)(0D))), Arr(((V)(z1_695)), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_627).Put("soft", ((V)(1D))).V), Call(disc_19, V.Undef, ((V)(x_696)), ((V)((by_529 + (ah_697 * 0.5)))), ((V)((z1_695 + 0.2))), ((V)(((AW_526 / 2D) - 2.5))), ((V)(1.4)), met_524, Call(mt_35, V.Undef)));
if (Truthy(wing_530)) {
Invoke(o_626, "push", Call(slab_16, V.Undef, ((V)(x_696)), ((V)(((by_529 + ah_697) + 4D))), ((V)((bz_632 + 10D))), ((V)((AW_526 + 2D))), ((V)(26D)), ((V)(16D)), fab_627, NewObj(2).Put("r", ((V)(12D))).Put("soft", ((V)(1D))).V));
}
return default;
}, 1, "", true));
Invoke(o_626, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_529 + 1D))), ((V)(((Dp_527 / 2D) - 2.2))), ((V)((Wd_534 - 10D))), ((V)(2D)), ((V)(1.6)), met_524, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return o_626;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "luxSofa", Fn((V _arrowThis705, int _argc698, V S_704, V _a701, V _a702, V _a703, V[] _rest699) => {
V n_706 = default;
V st_707 = default;
V gold_708 = default;
V legc_709 = default;
double SW_710 = 0;
double AW_711 = 0;
double Dp_712 = 0;
double Wd_713 = 0;
double by_714 = 0;
V xs_715 = default;
double ah_716 = 0;
double bh_717 = 0;
double bz_718 = 0;
V brass_719 = default;
double cz_720 = 0;
double cd_721 = 0;
double cf_722 = 0;
n_706 = (Get(S_704, "n") is var _t723 && Truthy(_t723) ? _t723 : ((V)(3D)));
st_707 = (Get(S_704, "st") is var _t724 && Truthy(_t724) ? _t724 : ((V)("chester")));
gold_708 = (!(!(Truthy(Get(S_704, "gold")))) ? V.True : V.False);
legc_709 = (Truthy(gold_708) ? GOLD_28 : (Get(S_704, "wood") is var _t725 && Truthy(_t725) ? _t725 : ((V)("#4a2c1a"))));
SW_710 = 56D;
AW_711 = 24D;
Dp_712 = 88D;
Wd_713 = ((ToNum(n_706) * SW_710) + (AW_711 * 2D));
by_714 = 16D;
xs_715 = Call(rep_36, V.Undef, n_706, Fn((V _arrowThis733, int _argc726, V i_732, V _a729, V _a730, V _a731, V[] _rest727) => {
return ((V)(((((-Wd_713) / 2D) + AW_711) + (SW_710 * ToNum(Add(i_732, ((V)(0.5))))))));
}, 1, "", true));
ah_716 = (SEqS(st_707, "chester") ? 40D : 30D);
bh_717 = (SEqS(st_707, "chester") ? 40D : 54D);
bz_718 = (((-Dp_712) / 2D) + 9D);
brass_719 = (gold_708 is var _t734 && Truthy(_t734) ? _t734 : Get(S_704, "brass"));
cz_720 = 8D;
cd_721 = (Dp_712 - 34D);
cf_722 = (cz_720 + (cd_721 / 2D));
return NewObj(5).Put("w", ((V)((Wd_713 + 8D)))).Put("d", ((V)(Dp_712))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_715, "map", Fn((V _arrowThis742, int _argc735, V x_741, V _a738, V _a739, V _a740, V[] _rest736) => {
return NewObj(3).Put("x", x_741).Put("z", ((V)(8D))).Put("h", ((V)((by_714 + 30D)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis750, int _argc743, V P_749, V _a746, V _a747, V _a748, V[] _rest744) => {
V o_751 = default;
V fab_752 = default;
V fL_753 = default;
V fD_754 = default;
V pip_755 = default;
V plc_756 = default;
V lm_757 = default;
V pil_758 = default;
V thr_759 = default;
o_751 = Arr();
fab_752 = Get(P_749, "a");
fL_753 = Call(shade_22, V.Undef, fab_752, ((V)(1.07)));
fD_754 = Call(shade_22, V.Undef, fab_752, ((V)(0.82)));
pip_755 = (Truthy(brass_719) ? GOLD_28 : Call(shade_22, V.Undef, fab_752, ((V)(0.68))));
plc_756 = Get(S_704, "plinth");
lm_757 = (Truthy(gold_708) ? Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V) : NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("wood"))).V);
pil_758 = (Get(S_704, "pil") is var _t760 && Truthy(_t760) ? _t760 : ((V)((Truthy(Invoke(NewRegExp(RX14, "^#(e|f|d)", "i"), "test", fab_752)) ? "#8a6a48" : "#e9d9b0"))));
thr_759 = ((V)((Truthy(Invoke(NewRegExp(RX15, "^#(e|f)", "i"), "test", fab_752)) ? "#6b4426" : "#efe4cc")));
if (Truthy(plc_756)) {
V R_761 = default;
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_713 - 8D))), ((V)((by_714 - 2D))), ((V)((Dp_712 - 10D))), plc_756, NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((by_714 - 2.4))), ((V)(0D)), ((V)((Wd_713 - 7D))), ((V)(1.2)), ((V)((Dp_712 - 9D))), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
R_761 = Call(rng_55, V.Undef, Get(S_704, "nm"));
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis768, int _argc762, V _a764, V _a765, V _a766, V _a767, V[] _rest763) => {
return Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(((ToNum(Call(R_761, V.Undef)) - 0.5) * (Wd_713 - 30D)))), ((V)(((by_714 - 6D) - (ToNum(Call(R_761, V.Undef)) * 6D)))), ((V)(((Dp_712 / 2D) - 4.9))), ((V)((18D + (ToNum(Call(R_761, V.Undef)) * 20D)))), ((V)(0.6)), ((V)(0.2)), ((V)("#c9b98a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
} else {
double lx_769 = 0;
double lz_770 = 0;
V L_771 = default;
double nb_772 = 0;
lx_769 = ((Wd_713 / 2D) - 9D);
lz_770 = ((Dp_712 / 2D) - 11D);
L_771 = Arr(Arr(((V)((-lx_769))), ((V)((-lz_770)))), Arr(((V)(lx_769)), ((V)((-lz_770)))), Arr(((V)((-lx_769))), ((V)(lz_770))), Arr(((V)(lx_769)), ((V)(lz_770))));
if (GeN(n_706, 4D)) {
Invoke(L_771, "push", Arr(((V)(0D)), ((V)(lz_770))), Arr(((V)(0D)), ((V)((-lz_770)))));
}
Invoke(L_771, "forEach", Fn((V _arrowThis784, int _argc773, V _a775, V _a776, V _a777, V _a778, V[] _rest774) => {
V x_781 = default;
V z_783 = default;
{ V _t779 = ListOf(_a775);
{ V _t780 = GetIdx(_t779, 0D);
x_781 = _t780; }
{ V _t782 = GetIdx(_t779, 1D);
z_783 = _t782; }
}
return Invoke(o_751, "push", Call(ball_15, V.Undef, x_781, ((V)(2.4)), z_783, ((V)(3.6)), legc_709, (Truthy(gold_708) ? Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V) : NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("wood"))).V)), Call(cyl_14, V.Undef, x_781, ((V)(4D)), z_783, ((V)(3D)), ((V)((by_714 - 8D))), legc_709, Object_assign(NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(((by_714 - 8D) * 0.5))), ((V)(0D)), ((V)(1.15))), Arr(((V)((by_714 - 8D))), ((V)(0D)), ((V)(0.8))))).V, (Truthy(gold_708) ? NewObj(1).Put("mat", ((V)("metal"))).V : NewObj(1).Put("mat", ((V)("wood"))).V))), Call(cyl_14, V.Undef, x_781, ((V)(0D)), z_783, ((V)(2.6)), ((V)(1.4)), (Truthy(brass_719) ? GOLD_28 : ((V)("#2a1a10"))), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((by_714 - 6D))), ((V)(0D)), ((V)((Wd_713 - 6D))), ((V)(5D)), ((V)((Dp_712 - 8D))), legc_709, (Truthy(gold_708) ? Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V) : NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("wood"))).V)));
nb_772 = System.Math.Floor(((Wd_713 - 16D) / 7D));
Call(rep_36, V.Undef, ((V)(nb_772)), Fn((V _arrowThis792, int _argc785, V i_791, V _a788, V _a789, V _a790, V[] _rest786) => {
return Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(((((-Wd_713) / 2D) + 8D) + ((ToNum(Add(i_791, ((V)(0.5)))) * (Wd_713 - 16D)) / nb_772)))), ((V)((by_714 - 4.8))), ((V)(((Dp_712 / 2D) - 3.6))), ((V)(1.3)), (Truthy(gold_708) ? GOLD_28 : Call(shade_22, V.Undef, legc_709, ((V)(1.25)))), Object_assign(NewObj(2).Put("sz", ((V)(0.6))).Put("noOut", ((V)(1D))).V, lm_757)));
}, 1, "", true));
Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)((by_714 - 5D))), ((V)(((Dp_712 / 2D) - 3.2))), ((V)(4.2)), (Truthy(gold_708) ? GOLD_28 : Call(shade_22, V.Undef, legc_709, ((V)(1.2)))), Object_assign(NewObj(2).Put("sy", ((V)(0.7))).Put("sz", ((V)(0.5))).V, lm_757)));
if (Truthy(gold_708)) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis800, int _argc793, V sg_799, V _a796, V _a797, V _a798, V[] _rest794) => {
return Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)((ToNum(sg_799) * 14D))), ((V)((by_714 - 5D))), ((V)(((Dp_712 / 2D) - 3.4))), ((V)(2.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(4).Put("sy", ((V)(0.6))).Put("sz", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
}
}
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(by_714)), ((V)(0D)), ((V)((Wd_713 - 6D))), ((V)(16D)), ((V)((Dp_712 - 6D))), fD_754, NewObj(3).Put("r", ((V)(10D))).Put("bev", ((V)(4D))).Put("mat", ((V)("fab"))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_714 + 0.6))), ((V)(((Dp_712 / 2D) - 3.2))), ((V)((Wd_713 - 10D))), ((V)(1.6)), ((V)(1.6)), pip_755, (Truthy(brass_719) ? Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V) : NewObj(2).Put("r", ((V)(0.8))).Put("mat", ((V)("fab"))).V)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_714 + 14D))), ((V)(((Dp_712 / 2D) - 3.6))), ((V)((Wd_713 - (AW_711 * 2D)))), ((V)(1.2)), ((V)(1.2)), Call(shade_22, V.Undef, fab_752, ((V)(0.7))), NewObj(3).Put("r", ((V)(0.6))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V));
if (Truthy(brass_719)) {
double nn_801 = 0;
nn_801 = System.Math.Floor(((Wd_713 - 20D) / 5D));
Call(rep_36, V.Undef, ((V)(nn_801)), Fn((V _arrowThis809, int _argc802, V i_808, V _a805, V _a806, V _a807, V[] _rest803) => {
return Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(((((-Wd_713) / 2D) + 10D) + ((ToNum(Add(i_808, ((V)(0.5)))) * (Wd_713 - 20D)) / nn_801)))), ((V)((by_714 + 4D))), ((V)(((Dp_712 / 2D) - 2.6))), ((V)(0.95)), GOLD_28, Call(mt_35, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}
Invoke(xs_715, "forEach", Fn((V _arrowThis817, int _argc810, V x_816, V _a813, V _a814, V _a815, V[] _rest811) => {
Invoke(o_751, "push", Call(pillowY_20, V.Undef, x_816, ((V)((by_714 + 15D))), ((V)(cz_720)), ((V)((SW_710 - 3D))), ((V)(15D)), ((V)(cd_721)), fL_753), Call(box_12, V.Undef, x_816, ((V)((by_714 + 16D))), ((V)((cf_722 - 1.4))), ((V)((SW_710 - 7D))), ((V)(10D)), ((V)(2.4)), Call(shade_22, V.Undef, fab_752, ((V)(0.97))), NewObj(3).Put("r", ((V)(2D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((by_714 + 16.2))), ((V)((by_714 + 26.4)))), "forEach", Fn((V _arrowThis825, int _argc818, V y_824, V _a821, V _a822, V _a823, V[] _rest819) => {
return Invoke(o_751, "push", Call(slabX_17, V.Undef, x_816, y_824, ((V)((cf_722 - 0.1))), ((V)((SW_710 - 7D))), ((V)(1.1)), ((V)(1.1)), pip_755, (Truthy(brass_719) ? Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).V) : NewObj(3).Put("r", ((V)(0.5))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
if (SEqS(st_707, "chester")) {
Invoke(o_751, "push", Call(ball_15, V.Undef, x_816, ((V)((by_714 + 30.6))), ((V)((cz_720 + 4D))), ((V)(1.6)), (Truthy(brass_719) ? GOLD_28 : Call(shade_22, V.Undef, fab_752, ((V)(0.6)))), Call(mt_35, V.Undef, NewObj(4).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
}
return default;
}, 1, "", true));
Invoke(o_751, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)((by_714 + 12D))), ((V)(bz_718)), ((V)(((Wd_713 - (AW_711 * 2D)) + 8D))), ((V)(bh_717)), ((V)(16D)), fab_752, NewObj(3).Put("r", ((V)((SEqS(st_707, "chester") ? 6D : 14D)))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
if (SEqS(st_707, "chester")) {
double rows_826 = 0;
double cols_827 = 0;
rows_826 = 3D;
cols_827 = ((ToNum(n_706) * 3D) + 1D);
Call(rep_36, V.Undef, ((V)(rows_826)), Fn((V _arrowThis835, int _argc828, V j_834, V _a831, V _a832, V _a833, V[] _rest829) => {
return Call(rep_36, V.Undef, ((V)((cols_827 - (ToNum(j_834) % 2D)))), Fn((V _arrowThis843, int _argc836, V i_842, V _a839, V _a840, V _a841, V[] _rest837) => {
double x_844 = 0;
double y_845 = 0;
x_844 = ((((-Wd_713) / 2D) + AW_711) + (((Wd_713 - (AW_711 * 2D)) * ToNum(Add(i_842, ((V)((NumTruthy((ToNum(j_834) % 2D)) ? 1D : 0.5)))))) / cols_827));
y_845 = ((by_714 + 20D) + (ToNum(j_834) * 10D));
Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(x_844)), ((V)(y_845)), ((V)((bz_718 + 8.1))), ((V)(3.6)), Call(shade_22, V.Undef, fab_752, ((V)(0.8))), NewObj(5).Put("sz", ((V)(0.22))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V), Call(ball_15, V.Undef, ((V)(x_844)), ((V)(y_845)), ((V)((bz_718 + 8.7))), ((V)(1.8)), (Truthy(brass_719) ? GOLD_28 : Call(shade_22, V.Undef, fab_752, ((V)(0.58)))), Call(mt_35, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(o_751, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((bz_718 + 2D))), ((V)(((by_714 + 12D) + bh_717))))).Put("a", ((V)(9D))).Put("b", ((V)(6D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(((((-Wd_713) / 2D) + AW_711) - 2D))), ((V)(2.5)), ((V)(0.85))), Arr(((V)(((((-Wd_713) / 2D) + AW_711) + 1D))), ((V)(0D))), Arr(((V)((((Wd_713 / 2D) - AW_711) - 1D))), ((V)(0D))), Arr(((V)((((Wd_713 / 2D) - AW_711) + 2D))), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_752).Put("soft", ((V)(1D))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((((by_714 + 12D) + bh_717) - 5.4))), ((V)((bz_718 + 9.4))), ((V)(((Wd_713 - (AW_711 * 2D)) - 2D))), ((V)(1.4)), ((V)(1.2)), pip_755, (Truthy(brass_719) ? Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V) : NewObj(2).Put("r", ((V)(0.6))).Put("mat", ((V)("fab"))).V)));
if (Truthy(gold_708)) {
Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)((((by_714 + 12D) + bh_717) + 6D))), ((V)((bz_718 + 2D))), ((V)(4D)), GOLD_28, Call(mt_35, V.Undef, NewObj(4).Put("sy", ((V)(0.8))).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}
} else {
Invoke(xs_715, "forEach", Fn((V _arrowThis853, int _argc846, V x_852, V _a849, V _a850, V _a851, V[] _rest847) => {
return Invoke(Arr(((V)((-1D))), ((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis861, int _argc854, V t_860, V _a857, V _a858, V _a859, V[] _rest855) => {
return Invoke(o_751, "push", Call(pillowZ_21, V.Undef, Add(x_852, ((V)((ToNum(t_860) * 17D)))), ((V)((by_714 + 26D))), ((V)((bz_718 + 9D))), ((V)(16D)), ((V)((bh_717 - 14D))), ((V)(8D)), (Truthy(t_860) ? fab_752 : fL_753)));
}, 1, "", true));
}, 1, "", true));
}
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis869, int _argc862, V sg_868, V _a865, V _a866, V _a867, V[] _rest863) => {
double x_870 = 0;
double z0_871 = 0;
double z1_872 = 0;
double xr_873 = 0;
x_870 = (ToNum(sg_868) * ((Wd_713 / 2D) - (AW_711 / 2D)));
z0_871 = (((-Dp_712) / 2D) + 3D);
z1_872 = ((Dp_712 / 2D) - 3D);
xr_873 = (x_870 + (ToNum(sg_868) * 2D));
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(x_870)), ((V)(by_714)), ((V)(((z0_871 + z1_872) / 2D))), ((V)((AW_711 - 2D))), ((V)(ah_716)), ((V)((z1_872 - z0_871))), fab_752, NewObj(3).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(xr_873)), ((V)((by_714 + ah_716))))).Put("a", ((V)(((AW_711 / 2D) + 4D)))).Put("b", ((V)(8D))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)(z0_871)), ((V)(2.5)), ((V)(0.85))), Arr(((V)((z0_871 + 2.5))), ((V)(0D))), Arr(((V)((z1_872 - 2.5))), ((V)(0D))), Arr(((V)(z1_872)), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_752).Put("soft", ((V)(1D))).V));
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(x_870)), ((V)((by_714 + 2D))), ((V)((z1_872 + 0.1))), ((V)((AW_711 - 7D))), ((V)((ah_716 - 8D))), ((V)(1D)), Call(shade_22, V.Undef, fab_752, ((V)(0.92))), NewObj(3).Put("r", ((V)(3D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(disc_19, V.Undef, ((V)(xr_873)), ((V)((by_714 + ah_716))), ((V)((z1_872 + 0.3))), ((V)(((AW_711 / 2D) + 1D))), ((V)(1.2)), Call(shade_22, V.Undef, fab_752, ((V)(0.9))), NewObj(1).Put("mat", ((V)("fab"))).V));
Invoke(o_751, "push", Call(solid_11, V.Undef, Object_assign(NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(xr_873)), ((V)((by_714 + ah_716))))).Put("a", ((V)(((AW_711 / 2D) + 1.6)))).Put("b", ((V)(8.6))).Put("th", ((V)(1D))).Put("a0", ((V)(0D))).Put("a1", ((V)((2D * PI_32)))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)((z1_872 + 0.9))), ((V)(0D))), Arr(((V)((z1_872 + 1.7))), ((V)(0D))))).Put("col", pip_755).Put("noOut", ((V)(1D))).V, (Truthy(brass_719) ? NewObj(1).Put("mat", ((V)("metal"))).V : NewObj(1).Put("mat", ((V)("fab"))).V))));
Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(xr_873)), ((V)((by_714 + ah_716))), ((V)((z1_872 + 1.6))), ((V)(2.8)), (Truthy(gold_708) ? GOLD_28 : Call(shade_22, V.Undef, fab_752, ((V)(0.75)))), Object_assign(NewObj(1).Put("sz", ((V)(0.5))).V, (Truthy(gold_708) ? Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V) : NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("fab"))).V))));
if (Truthy(brass_719)) {
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis881, int _argc874, V i_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return Invoke(o_751, "push", Call(ball_15, V.Undef, ((V)(x_870)), ((V)(((by_714 + 4D) + ((ToNum(i_880) * (ah_716 - 12D)) / 5D)))), ((V)((z1_872 + 0.8))), ((V)(1.1)), GOLD_28, Call(mt_35, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}
Invoke(o_751, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-4D))), ((V)((by_714 + 26D))))).Put("a", ((V)(9D))).Put("b", ((V)(9D))).Put("n", ((V)(14D))).Put("rings", Invoke(Arr(Arr(((V)((ToNum(sg_868) * (((Wd_713 / 2D) - AW_711) - 1D)))), ((V)(0D)), ((V)(0.7))), Arr(((V)((ToNum(sg_868) * (((Wd_713 / 2D) - AW_711) - 24D)))), ((V)(0D)), ((V)(0.7)))), "sort", Fn((V _arrowThis890, int _argc882, V a_888, V b_889, V _a886, V _a887, V[] _rest883) => {
return ((V)((ToNum(GetIdx(a_888, 0D)) - ToNum(GetIdx(b_889, 0D)))));
}, 2, "", true))).Put("col", Call(shade_22, V.Undef, fab_752, ((V)(1.14)))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((ToNum(sg_868) * (((Wd_713 / 2D) - AW_711) - 1.5)))), ((V)((ToNum(sg_868) * (((Wd_713 / 2D) - AW_711) - 23.5))))), "forEach", Fn((V _arrowThis898, int _argc891, V px_897, V _a894, V _a895, V _a896, V[] _rest892) => {
return Invoke(o_751, "push", Call(solid_11, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-4D))), ((V)((by_714 + 26D))))).Put("a", ((V)(6D))).Put("b", ((V)(6D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((ToNum(px_897) - 0.5))), ((V)(0D))), Arr(Add(px_897, ((V)(0.5))), ((V)(0D))))).Put("col", pip_755).Put("noOut", ((V)(1D))).V, (Truthy(brass_719) ? NewObj(1).Put("mat", ((V)("metal"))).V : NewObj(1).Put("mat", ((V)("fab"))).V))));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis906, int _argc899, V sg_905, V _a902, V _a903, V _a904, V[] _rest900) => {
double px_907 = 0;
double pz_908 = 0;
V pc_909 = default;
px_907 = (ToNum(sg_905) * (((Wd_713 / 2D) - AW_711) - 22D));
pz_908 = (bz_718 + 19D);
pc_909 = (LtN(sg_905, 0D) ? pil_758 : Call(shade_22, V.Undef, pil_758, ((V)(0.88))));
Invoke(o_751, "push", Call(pillowZ_21, V.Undef, ((V)(px_907)), ((V)((by_714 + 27D))), ((V)(pz_908)), ((V)(30D)), ((V)(28D)), ((V)(10D)), pc_909), Call(slabX_17, V.Undef, ((V)(px_907)), ((V)(((by_714 + 27D) + 27D))), ((V)((pz_908 + 2D))), ((V)(28D)), ((V)(1D)), ((V)(1D)), Call(shade_22, V.Undef, pc_909, ((V)(0.7))), NewObj(3).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-14D))), ((V)(14D))), "forEach", Fn((V _arrowThis917, int _argc910, V t_916, V _a913, V _a914, V _a915, V[] _rest911) => {
return Invoke(o_751, "push", Call(ball_15, V.Undef, Add(((V)(px_907)), t_916), ((V)(((by_714 + 27D) + 28D))), ((V)((pz_908 + 3D))), ((V)(1.6)), (Truthy(brass_719) ? GOLD_28 : Call(shade_22, V.Undef, pc_909, ((V)(0.7)))), NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
if (GeN(n_706, 3D)) {
Invoke(o_751, "push", Call(pillowZ_21, V.Undef, ((V)(0D)), ((V)((by_714 + 28D))), ((V)((bz_718 + 20D))), ((V)(36D)), ((V)(16D)), ((V)(9D)), (Truthy(Get(S_704, "pil")) ? Call(shade_22, V.Undef, Get(S_704, "pil"), ((V)(1.1))) : Call(shade_22, V.Undef, fab_752, ((V)(1.18))))), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_714 + 36D))), ((V)((bz_718 + 25D))), ((V)(30D)), ((V)(4D)), ((V)(0.6)), pip_755, (Truthy(brass_719) ? Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V) : NewObj(3).Put("r", ((V)(0.4))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}
{
double x_918 = 0;
double tz_919 = 0;
x_918 = ((-((Wd_713 / 2D) - (AW_711 / 2D))) - 2D);
tz_919 = 2D;
Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(x_918)), ((V)(((by_714 + ah_716) + 5.6))), ((V)(tz_919)), ((V)((AW_711 + 6D))), ((V)(3.2)), ((V)(30D)), thr_759, NewObj(4).Put("r", ((V)(1.6))).Put("bev", ((V)(1.4))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(box_12, V.Undef, ((V)((((-Wd_713) / 2D) - 2.6))), ((V)(((by_714 + ah_716) - 16D))), ((V)(tz_919)), ((V)(2.6)), ((V)(24D)), ((V)(30D)), thr_759, NewObj(3).Put("r", ((V)(1.2))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-9D))), ((V)(9D))), "forEach", Fn((V _arrowThis927, int _argc920, V dz_926, V _a923, V _a924, V _a925, V[] _rest921) => {
return Invoke(o_751, "push", Call(box_12, V.Undef, ((V)(x_918)), ((V)(((by_714 + ah_716) + 8.9))), Add(((V)(tz_919)), dz_926), ((V)((AW_711 + 6.4))), ((V)(0.3)), ((V)(3D)), pil_758, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)((((-Wd_713) / 2D) - 4D))), ((V)(((by_714 + ah_716) - 16D))), Add(((V)(tz_919)), dz_926), ((V)(0.3)), ((V)(24.4)), ((V)(3D)), pil_758, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Call(rep_36, V.Undef, ((V)(8D)), Fn((V _arrowThis935, int _argc928, V i_934, V _a931, V _a932, V _a933, V[] _rest929) => {
return Invoke(o_751, "push", Call(box_12, V.Undef, ((V)((((-Wd_713) / 2D) - 2.6))), ((V)(((by_714 + ah_716) - 20D))), ((V)(((tz_919 - 13D) + (ToNum(i_934) * 3.7)))), ((V)(1D)), ((V)(4D)), ((V)(1D)), Call(shade_22, V.Undef, thr_759, ((V)(0.9))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
}
return o_751;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "luxDChair", Fn((V _arrowThis943, int _argc936, V S_942, V _a939, V _a940, V _a941, V[] _rest937) => {
V gold_944 = default;
V legc_945 = default;
V st_946 = default;
gold_944 = (!(!(Truthy(Get(S_942, "gold")))) ? V.True : V.False);
legc_945 = (Truthy(gold_944) ? GOLD_28 : (Get(S_942, "wood") is var _t947 && Truthy(_t947) ? _t947 : ((V)("#4a2c1a"))));
st_946 = (Get(S_942, "st") is var _t948 && Truthy(_t948) ? _t948 : ((V)("tuft")));
return NewObj(5).Put("w", ((V)(52D))).Put("d", ((V)(54D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(4D))).Put("h", ((V)(46D))).V)).Put("build", Fn((V _arrowThis956, int _argc949, V P_955, V _a952, V _a953, V _a954, V[] _rest950) => {
V o_957 = default;
V fab_958 = default;
V lm_959 = default;
double bh_960 = 0;
o_957 = Arr();
fab_958 = Get(P_955, "a");
lm_959 = (Truthy(gold_944) ? Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V) : NewObj(2).Put("n", ((V)(8D))).Put("mat", ((V)("wood"))).V);
Invoke(Arr(Arr(((V)((-17D))), ((V)((-17D)))), Arr(((V)(17D)), ((V)((-17D)))), Arr(((V)((-17D))), ((V)(17D))), Arr(((V)(17D)), ((V)(17D)))), "forEach", Fn((V _arrowThis972, int _argc961, V _a963, V _a964, V _a965, V _a966, V[] _rest962) => {
V x_969 = default;
V z_971 = default;
{ V _t967 = ListOf(_a963);
{ V _t968 = GetIdx(_t967, 0D);
x_969 = _t968; }
{ V _t970 = GetIdx(_t967, 1D);
z_971 = _t970; }
}
return Invoke(o_957, "push", Call(cyl_14, V.Undef, x_969, ((V)(0D)), z_971, ((V)(2.4)), ((V)(34D)), legc_945, Object_assign(NewObj(0).V, lm_959, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))), Arr(((V)(34D)), ((V)(0D)), ((V)(1.1))))).V)));
}, 1, "", true));
if (Truthy(gold_944)) {
Invoke(Arr(((V)((-17D))), ((V)(17D))), "forEach", Fn((V _arrowThis980, int _argc973, V x_979, V _a976, V _a977, V _a978, V[] _rest974) => {
return Invoke(o_957, "push", Call(ball_15, V.Undef, x_979, ((V)(0.6)), ((V)(17D)), ((V)(2.6)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
}
Invoke(o_957, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(1D)), ((V)(42D)), ((V)(4D)), ((V)(42D)), legc_945, (Truthy(gold_944) ? Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V) : NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("wood"))).V)), Call(cush_13, V.Undef, ((V)(0D)), ((V)(35D)), ((V)(2D)), ((V)(40D)), ((V)(9D)), ((V)(40D)), fab_958, NewObj(1).Put("r", ((V)(12D))).V));
bh_960 = 52D;
Invoke(o_957, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)((-19D))), ((V)(40D)), ((V)(bh_960)), ((V)(7D)), legc_945, (Truthy(gold_944) ? Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(12D))).V) : NewObj(2).Put("r", ((V)(12D))).Put("mat", ((V)("wood"))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(41D)), ((V)((-15.4))), ((V)(34D)), ((V)((bh_960 - 6D))), ((V)(4D)), fab_958, NewObj(3).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
if (SEqS(st_946, "tuft")) {
Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis988, int _argc981, V j_987, V _a984, V _a985, V _a986, V[] _rest982) => {
return Call(rep_36, V.Undef, ((V)((3D - (ToNum(j_987) % 2D)))), Fn((V _arrowThis996, int _argc989, V i_995, V _a992, V _a993, V _a994, V[] _rest990) => {
return Invoke(o_957, "push", Call(ball_15, V.Undef, ((V)((((-11D) + (ToNum(i_995) * 11D)) + ((ToNum(j_987) % 2D) * 5.5)))), ((V)((52D + (ToNum(j_987) * 11D)))), ((V)((-13D))), ((V)(1.5)), (Truthy(gold_944) ? GOLD_28 : Call(shade_22, V.Undef, fab_958, ((V)(0.6)))), Call(mt_35, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
} else {
Invoke(Arr(((V)((-10D))), ((V)(0D)), ((V)(10D))), "forEach", Fn((V _arrowThis1004, int _argc997, V x_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
return Invoke(o_957, "push", Call(pillowZ_21, V.Undef, x_1003, ((V)(44D)), ((V)((-13.2))), ((V)(9.4)), ((V)((bh_960 - 12D))), ((V)(3D)), Call(shade_22, V.Undef, fab_958, ((V)(1.06)))));
}, 1, "", true));
}
if (Truthy(gold_944)) {
Invoke(o_957, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)(((38D + bh_960) + 1D))), ((V)((-19D))), ((V)(3.2)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}
return o_957;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "futon", Fn((V _arrowThis1012, int _argc1005, V S_1011, V _a1008, V _a1009, V _a1010, V[] _rest1006) => {
double W_1013 = 0;
double Dp_1014 = 0;
double by_1015 = 0;
V pine_1016 = default;
V pD_1017 = default;
W_1013 = 150D;
Dp_1014 = 72D;
by_1015 = 13D;
pine_1016 = ((V)("#c9a26b"));
pD_1017 = Call(shade_22, V.Undef, pine_1016, ((V)(0.8)));
return NewObj(5).Put("w", ((V)((W_1013 + 12D)))).Put("d", ((V)((Dp_1014 + 6D)))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-32D)))).Put("z", ((V)(8D))).Put("h", ((V)((by_1015 + 22D)))).V, NewObj(3).Put("x", ((V)(32D))).Put("z", ((V)(8D))).Put("h", ((V)((by_1015 + 22D)))).V)).Put("build", Fn((V _arrowThis1025, int _argc1018, V P_1024, V _a1021, V _a1022, V _a1023, V[] _rest1019) => {
V o_1026 = default;
V fab_1027 = default;
V fL_1028 = default;
V fD_1029 = default;
V tie_1030 = default;
o_1026 = Arr();
fab_1027 = ((V)("#5d6b8a"));
fL_1028 = Call(shade_22, V.Undef, fab_1027, ((V)(1.08)));
fD_1029 = Call(shade_22, V.Undef, fab_1027, ((V)(0.78)));
tie_1030 = Call(shade_22, V.Undef, fab_1027, ((V)(0.62)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1038, int _argc1031, V sg_1037, V _a1034, V _a1035, V _a1036, V[] _rest1032) => {
double x_1039 = 0;
x_1039 = (ToNum(sg_1037) * ((W_1013 / 2D) + 2D));
Invoke(Arr(((V)((((-Dp_1014) / 2D) + 4D))), ((V)(((Dp_1014 / 2D) - 4D)))), "forEach", Fn((V _arrowThis1047, int _argc1040, V z_1046, V _a1043, V _a1044, V _a1045, V[] _rest1041) => {
return Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(x_1039)), ((V)(0D)), z_1046, ((V)(6D)), ((V)(40D)), ((V)(6D)), pD_1017, NewObj(2).Put("r", ((V)(1.5))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(x_1039)), ((V)(26D)), ((V)(0D)), ((V)(7D)), ((V)(5D)), ((V)(Dp_1014)), pine_1016, NewObj(2).Put("r", ((V)(1.5))).Put("mat", ((V)("wood"))).V), Call(box_12, V.Undef, ((V)(x_1039)), ((V)(8D)), ((V)(0D)), ((V)(5D)), ((V)(4D)), ((V)((Dp_1014 - 8D))), pD_1017, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("wood"))).V));
Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1055, int _argc1048, V i_1054, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
return Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(x_1039)), ((V)(12D)), ((V)(((((-Dp_1014) / 2D) + 18D) + (ToNum(i_1054) * 18D)))), ((V)(4D)), ((V)(14D)), ((V)(3D)), pine_1016, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((by_1015 - 4D))), ((V)(0D)), ((V)(W_1013)), ((V)(4D)), ((V)((Dp_1014 - 6D))), pD_1017, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("wood"))).V));
Call(rep_36, V.Undef, ((V)(7D)), Fn((V _arrowThis1063, int _argc1056, V i_1062, V _a1059, V _a1060, V _a1061, V[] _rest1057) => {
return Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(((((-W_1013) / 2D) + 10D) + ((ToNum(i_1062) * (W_1013 - 20D)) / 6D)))), ((V)((by_1015 + 8D))), ((V)((((-Dp_1014) / 2D) + 1D))), ((V)(4D)), ((V)(44D)), ((V)(3D)), pine_1016, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
Invoke(o_1026, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_1015 + 50D))), ((V)((((-Dp_1014) / 2D) + 1D))), ((V)((W_1013 + 4D))), ((V)(5D)), ((V)(4D)), pine_1016, NewObj(2).Put("r", ((V)(1.5))).Put("mat", ((V)("wood"))).V));
Invoke(o_1026, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(by_1015)), ((V)(3D)), ((V)((W_1013 - 2D))), ((V)(10D)), ((V)((Dp_1014 - 16D))), fD_1029, NewObj(3).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1071, int _argc1064, V sg_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
return Invoke(o_1026, "push", Call(pillowY_20, V.Undef, ((V)((ToNum(sg_1070) * 38D))), ((V)((by_1015 + 9D))), ((V)(5D)), ((V)(64D)), ((V)(8D)), ((V)((Dp_1014 - 20D))), fL_1028, NewObj(1).Put("mat", ((V)("fab"))).V));
}, 1, "", true));
Invoke(o_1026, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((((-Dp_1014) / 2D) + 12D))), ((V)((by_1015 + 13D))))).Put("a", ((V)(9D))).Put("b", ((V)(8D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((((-W_1013) / 2D) + 1D))), ((V)(2D)), ((V)(0.85))), Arr(((V)((((-W_1013) / 2D) + 3D))), ((V)(0D))), Arr(((V)(((W_1013 / 2D) - 3D))), ((V)(0D))), Arr(((V)(((W_1013 / 2D) - 1D))), ((V)(2D)), ((V)(0.85))))).Put("col", fab_1027).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(o_1026, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)((by_1015 + 14D))), ((V)((((-Dp_1014) / 2D) + 10D))), ((V)((W_1013 - 2D))), ((V)(34D)), ((V)(12D)), fab_1027, NewObj(3).Put("r", ((V)(9D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-48D))), ((V)((-16D))), ((V)(16D)), ((V)(48D))), "forEach", Fn((V _arrowThis1079, int _argc1072, V x_1078, V _a1075, V _a1076, V _a1077, V[] _rest1073) => {
Invoke(o_1026, "push", Call(ball_15, V.Undef, x_1078, ((V)((by_1015 + 16.6))), ((V)(4D)), ((V)(1.6)), tie_1030, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V), Call(ball_15, V.Undef, x_1078, ((V)((by_1015 + 34D))), ((V)((((-Dp_1014) / 2D) + 16.4))), ((V)(1.6)), tie_1030, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
return o_1026;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "rchair", Fn((V _arrowThis1087, int _argc1080, V S_1086, V _a1083, V _a1084, V _a1085, V[] _rest1081) => {
V k_1088 = default;
V nm_1089 = default;
V met_1090 = default;
V st_1091 = default;
V LG_1092 = default;
k_1088 = Get(S_1086, "k");
nm_1089 = Get(S_1086, "nm");
met_1090 = Call(metal_34, V.Undef, k_1088);
st_1091 = (Get(S_1086, "st2") is var _t1093 && Truthy(_t1093) ? _t1093 : ((V)((Truthy(Invoke(NewRegExp(RX20, "folding", ""), "test", nm_1089)) ? "fold" : (Truthy(Invoke(NewRegExp(RX19, "windsor|spindle", ""), "test", nm_1089)) ? "windsor" : (Truthy(Invoke(NewRegExp(RX18, "thonet|bentwood|cane", ""), "test", nm_1089)) ? "thonet" : (Truthy(Invoke(NewRegExp(RX17, "papasan", ""), "test", nm_1089)) ? "papasan" : (Truthy(Invoke(NewRegExp(RX16, "boucl\u00e9|boucle|upholstered|dining armchair", ""), "test", nm_1089)) ? "tub" : "mod"))))))));
LG_1092 = Arr(Arr(((V)((-17D))), ((V)((-17D)))), Arr(((V)(17D)), ((V)((-17D)))), Arr(((V)((-17D))), ((V)(17D))), Arr(((V)(17D)), ((V)(17D))));
if (SEqS(st_1091, "fold")) {
return NewObj(5).Put("w", ((V)(48D))).Put("d", ((V)(48D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(4D))).Put("h", ((V)(46D))).V)).Put("build", Fn((V _arrowThis1101, int _argc1094, V P_1100, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
V o_1102 = default;
V ir_1103 = default;
V wd_1104 = default;
o_1102 = Arr();
ir_1103 = (SEqS(k_1088, "junk") ? ((V)("#6b6e73")) : IRON_33);
wd_1104 = ((V)("#c49a62"));
Invoke(LG_1092, "forEach", Fn((V _arrowThis1116, int _argc1105, V _a1107, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
V x_1113 = default;
V z_1115 = default;
{ V _t1111 = ListOf(_a1107);
{ V _t1112 = GetIdx(_t1111, 0D);
x_1113 = _t1112; }
{ V _t1114 = GetIdx(_t1111, 1D);
z_1115 = _t1114; }
}
return Invoke(o_1102, "push", Call(cyl_14, V.Undef, x_1113, ((V)(0D)), z_1115, ((V)(1.7)), ((V)(38D)), ir_1103, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
Invoke(o_1102, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(17D)), ((V)(36D)), ((V)(1.6)), ((V)(1.6)), ir_1103, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(12D)), ((V)((-17D))), ((V)(36D)), ((V)(1.6)), ((V)(1.6)), ir_1103, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(2D)), ((V)(42D)), ((V)(3.4)), ((V)(40D)), wd_1104, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)((-17D))), ((V)(38D)), ((V)((-18D))), ((V)(1.7)), ((V)(40D)), ir_1103, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_14, V.Undef, ((V)(17D)), ((V)(38D)), ((V)((-18D))), ((V)(1.7)), ((V)(40D)), ir_1103, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(60D)), ((V)((-18.5))), ((V)(40D)), ((V)(14D)), ((V)(3D)), wd_1104, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(pillowY_20, V.Undef, ((V)(0D)), ((V)(39.4)), ((V)(4D)), ((V)(34D)), ((V)(7D)), ((V)(30D)), Get(P_1100, "a")));
return o_1102;
return default;
}, 1, "build", true)).V;
}
if (SEqS(st_1091, "windsor")) {
return NewObj(5).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(3D))).Put("h", ((V)(44D))).V)).Put("build", Fn((V _arrowThis1124, int _argc1117, V P_1123, V _a1120, V _a1121, V _a1122, V[] _rest1118) => {
V o_1125 = default;
V pc_1126 = default;
double sh_1127 = 0;
o_1125 = Arr();
pc_1126 = Get(P_1123, "a");
sh_1127 = 38D;
Invoke(LG_1092, "forEach", Fn((V _arrowThis1139, int _argc1128, V _a1130, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
V x_1136 = default;
V z_1138 = default;
{ V _t1134 = ListOf(_a1130);
{ V _t1135 = GetIdx(_t1134, 0D);
x_1136 = _t1135; }
{ V _t1137 = GetIdx(_t1134, 1D);
z_1138 = _t1137; }
}
return Invoke(o_1125, "push", Call(cyl_14, V.Undef, ((V)((ToNum(x_1136) * 0.95))), ((V)(0D)), ((V)((ToNum(z_1138) * 0.95))), ((V)(2.2)), ((V)(sh_1127)), pc_1126, NewObj(3).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)((sh_1127 * 0.5))), ((V)(0D)), ((V)(1.15))), Arr(((V)(sh_1127)), ((V)(0D)), ((V)(0.9))))).Put("mat", ((V)("paint"))).V));
}, 1, "", true));
Invoke(o_1125, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(34D)), ((V)(2D)), ((V)(2D)), pc_1126, NewObj(1).Put("r", ((V)(1D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(sh_1127)), ((V)(2D)), ((V)(23D)), ((V)(5D)), pc_1126, NewObj(3).Put("rz", ((V)(21D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(3D)), ((V)(0D)), ((V)(1.02))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.97))))).Put("mat", ((V)("paint"))).V), Call(cyl_14, V.Undef, ((V)((-19D))), ((V)((sh_1127 + 4D))), ((V)((-17D))), ((V)(1.6)), ((V)(12D)), pc_1126, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_14, V.Undef, ((V)(19D)), ((V)((sh_1127 + 4D))), ((V)((-17D))), ((V)(1.6)), ((V)(12D)), pc_1126, NewObj(1).Put("n", ((V)(6D))).V));
Invoke(o_1125, "push", Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)((sh_1127 + 15D))))).Put("a", ((V)(20D))).Put("b", ((V)(30D))).Put("th", ((V)(3.2))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_32))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-18.5))), ((V)(0D))), Arr(((V)((-15.5))), ((V)(0D))))).Put("col", pc_1126).Put("mat", ((V)("paint"))).V));
Invoke(Arr(((V)((-13D))), ((V)((-6.5))), ((V)(0D)), ((V)(6.5)), ((V)(13D))), "forEach", Fn((V _arrowThis1147, int _argc1140, V x_1146, V _a1143, V _a1144, V _a1145, V[] _rest1141) => {
double top_1148 = 0;
top_1148 = (((sh_1127 + 15D) + (30D * System.Math.Sqrt(Max(0D, (1D - Pow((ToNum(x_1146) / 18.4), 2D)))))) - 2D);
Invoke(o_1125, "push", Call(cyl_14, V.Undef, x_1146, ((V)((sh_1127 + 4D))), ((V)((-17D))), ((V)(1.1)), ((V)(((top_1148 - sh_1127) - 4D))), Call(shade_22, V.Undef, pc_1126, ((V)(0.92))), NewObj(2).Put("n", ((V)(6D))).Put("mat", ((V)("paint"))).V));
return default;
}, 1, "", true));
return o_1125;
return default;
}, 1, "build", true)).V;
}
if (SEqS(st_1091, "thonet")) {
return NewObj(5).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(2D))).Put("h", ((V)(44D))).V)).Put("build", Fn((V _arrowThis1156, int _argc1149, V P_1155, V _a1152, V _a1153, V _a1154, V[] _rest1150) => {
V o_1157 = default;
V wd_1158 = default;
double sh_1159 = 0;
o_1157 = Arr();
wd_1158 = ((V)("#5e3a22"));
sh_1159 = 38D;
Invoke(LG_1092, "forEach", Fn((V _arrowThis1171, int _argc1160, V _a1162, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {
V x_1168 = default;
V z_1170 = default;
{ V _t1166 = ListOf(_a1162);
{ V _t1167 = GetIdx(_t1166, 0D);
x_1168 = _t1167; }
{ V _t1169 = GetIdx(_t1166, 1D);
z_1170 = _t1169; }
}
return Invoke(o_1157, "push", Call(cyl_14, V.Undef, ((V)((ToNum(x_1168) * 0.9))), ((V)(0D)), ((V)((ToNum(z_1170) * 0.9))), ((V)(1.9)), ((V)(sh_1159)), wd_1158, NewObj(3).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(sh_1159)), ((V)(0D)), ((V)(1.05))))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
Invoke(o_1157, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)(13D)), ((V)(0D)), ((V)(17D)), ((V)(17D)), ((V)(1.8)), ((V)(1.8)), ((V)(0D)), ((V)((2D * PI_32))), wd_1158, NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(sh_1159)), ((V)(1D)), ((V)(21D)), ((V)(4D)), wd_1158, NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((sh_1159 + 4D))), ((V)(1D)), ((V)(17.5)), ((V)(0.8)), ((V)("#d8b278")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("fab"))).V));
Invoke(o_1157, "push", Call(cyl_14, V.Undef, ((V)((-15D))), ((V)((sh_1159 + 2D))), ((V)((-15D))), ((V)(1.8)), ((V)(26D)), wd_1158, NewObj(2).Put("n", ((V)(6D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(15D)), ((V)((sh_1159 + 2D))), ((V)((-15D))), ((V)(1.8)), ((V)(26D)), wd_1158, NewObj(2).Put("n", ((V)(6D))).Put("mat", ((V)("wood"))).V), Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)((sh_1159 + 28D))))).Put("a", ((V)(15D))).Put("b", ((V)(16D))).Put("th", ((V)(2.6))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_32))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-16.3))), ((V)(0D))), Arr(((V)((-13.7))), ((V)(0D))))).Put("col", wd_1158).Put("mat", ((V)("wood"))).V), Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)((sh_1159 + 20D))))).Put("a", ((V)(9D))).Put("b", ((V)(12D))).Put("th", ((V)(2D))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_32))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)((-14D))), ((V)(0D))))).Put("col", wd_1158).Put("mat", ((V)("wood"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)((sh_1159 + 6D))), ((V)((-15D))), ((V)(30D)), ((V)(10D)), ((V)(2D)), ((V)("#d8b278")), NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("fab"))).V));
return o_1157;
return default;
}, 1, "build", true)).V;
}
if (SEqS(st_1091, "tub")) {
return NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(54D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(4D))).Put("h", ((V)(44D))).V)).Put("build", Fn((V _arrowThis1179, int _argc1172, V P_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
V o_1180 = default;
V c_1181 = default;
V br_1182 = default;
double sh_1183 = 0;
o_1180 = Arr();
c_1181 = Get(P_1178, "a");
br_1182 = (Truthy(((SEqS(k_1088, "royal") ? V.True : V.False) is var _t1184 && Truthy(_t1184) ? _t1184 : Invoke(NewRegExp(RX21, "brass|gold", ""), "test", nm_1089))) ? GOLD_28 : met_1090);
sh_1183 = 30D;
Invoke(LG_1092, "forEach", Fn((V _arrowThis1196, int _argc1185, V _a1187, V _a1188, V _a1189, V _a1190, V[] _rest1186) => {
V x_1193 = default;
V z_1195 = default;
{ V _t1191 = ListOf(_a1187);
{ V _t1192 = GetIdx(_t1191, 0D);
x_1193 = _t1192; }
{ V _t1194 = GetIdx(_t1191, 1D);
z_1195 = _t1194; }
}
return Invoke(o_1180, "push", Call(cyl_14, V.Undef, ((V)((ToNum(x_1193) * 1.05))), ((V)(0D)), ((V)((ToNum(z_1195) * 1.05))), ((V)(1.9)), ((V)(sh_1183)), br_1182, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(sh_1183)), ((V)(0D)), ((V)(1.1))))).V)));
}, 1, "", true));
Invoke(o_1180, "push", Call(cush_13, V.Undef, ((V)(0D)), ((V)(sh_1183)), ((V)(2D)), ((V)(50D)), ((V)(12D)), ((V)(48D)), c_1181, NewObj(1).Put("r", ((V)(18D))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)((sh_1183 + 2D))), ((V)(2D)), ((V)(26D)), ((V)(25D)), ((V)(8D)), ((V)(30D)), ((V)((PI_32 * 0.92))), ((V)((PI_32 * 2.08))), c_1181, NewObj(3).Put("n", ((V)(14D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)((sh_1183 + 31.4))), ((V)(2D)), ((V)(26D)), ((V)(25D)), ((V)(8D)), ((V)(1.4)), ((V)((PI_32 * 0.92))), ((V)((PI_32 * 2.08))), br_1182, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(pillowY_20, V.Undef, ((V)(0D)), ((V)((sh_1183 + 9D))), ((V)(6D)), ((V)(38D)), ((V)(6D)), ((V)(30D)), Call(shade_22, V.Undef, c_1181, ((V)(1.05)))));
return o_1180;
return default;
}, 1, "build", true)).V;
}
if (SEqS(st_1091, "papasan")) {
return NewObj(6).Put("w", ((V)(84D))).Put("d", ((V)(80D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("h", ((V)(40D))).V)).Put("build", Fn((V _arrowThis1204, int _argc1197, V P_1203, V _a1200, V _a1201, V _a1202, V[] _rest1198) => {
V rt_1205 = default;
rt_1205 = ((V)("#c99a5a"));
return Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(4D)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(2D)), ((V)(38D)), ((V)(22D)), rt_1205, NewObj(4).Put("n", ((V)(24D))).Put("rz", ((V)(34D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("wood"))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(2D)), ((V)(39D)), ((V)(35D)), ((V)(2.4)), ((V)(2.4)), ((V)(0D)), ((V)((2D * PI_32))), Call(shade_22, V.Undef, rt_1205, ((V)(0.8))), NewObj(2).Put("n", ((V)(24D))).Put("mat", ((V)("wood"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(4D)), ((V)(33D)), Get(P_1203, "a"), NewObj(6).Put("sy", ((V)(0.32))).Put("sz", ((V)(0.85))).Put("k", ((V)(6D))).Put("n", ((V)(22D))).Put("soft", ((V)(1D))).Put("shine", ((V)(0D))).V), Call(pillowZ_21, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-18D))), ((V)(46D)), ((V)(22D)), ((V)(12D)), Call(shade_22, V.Undef, Get(P_1203, "a"), ((V)(1.08)))));
return default;
}, 1, "build", true)).V;
}
return NewObj(5).Put("w", ((V)(52D))).Put("d", ((V)(52D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(3D))).Put("h", ((V)(46D))).V)).Put("build", Fn((V _arrowThis1213, int _argc1206, V P_1212, V _a1209, V _a1210, V _a1211, V[] _rest1207) => {
V o_1214 = default;
double sh_1215 = 0;
o_1214 = Arr();
sh_1215 = 36D;
Invoke(LG_1092, "forEach", Fn((V _arrowThis1227, int _argc1216, V _a1218, V _a1219, V _a1220, V _a1221, V[] _rest1217) => {
V x_1224 = default;
V z_1226 = default;
{ V _t1222 = ListOf(_a1218);
{ V _t1223 = GetIdx(_t1222, 0D);
x_1224 = _t1223; }
{ V _t1225 = GetIdx(_t1222, 1D);
z_1226 = _t1225; }
}
return Invoke(o_1214, "push", Call(cyl_14, V.Undef, x_1224, ((V)(0D)), z_1226, ((V)(2D)), ((V)(sh_1215)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_1214, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(17D)), ((V)(34D)), ((V)(1.6)), ((V)(1.6)), met_1090, Call(mt_35, V.Undef)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-17D))), ((V)(34D)), ((V)(1.6)), ((V)(1.6)), met_1090, Call(mt_35, V.Undef)), Call(box_12, V.Undef, ((V)(0D)), ((V)(sh_1215)), ((V)(2D)), ((V)(46D)), ((V)(4D)), ((V)(44D)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(cush_13, V.Undef, ((V)(0D)), ((V)((sh_1215 + 3D))), ((V)(3D)), ((V)(44D)), ((V)(7D)), ((V)(42D)), Get(P_1212, "a"), NewObj(1).Put("r", ((V)(12D))).V), Call(cyl_14, V.Undef, ((V)((-18D))), ((V)((sh_1215 + 3D))), ((V)((-19D))), ((V)(1.8)), ((V)(34D)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_14, V.Undef, ((V)(18D)), ((V)((sh_1215 + 3D))), ((V)((-19D))), ((V)(1.8)), ((V)(34D)), met_1090, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)((sh_1215 + 12D))), ((V)((-19.5))), ((V)(44D)), ((V)(26D)), ((V)(4D)), Get(P_1212, "a"), NewObj(2).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).V));
return o_1214;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "barstool", Fn((V _arrowThis1235, int _argc1228, V S_1234, V _a1231, V _a1232, V _a1233, V[] _rest1229) => {
V k_1236 = default;
double h_1237 = 0;
V fl_1238 = default;
V met_1239 = default;
V LP_1240 = default;
k_1236 = Get(S_1234, "k");
h_1237 = 62D;
fl_1238 = Invoke(NewRegExp(RX22, "levitat|hydraulic", ""), "test", Get(S_1234, "nm"));
met_1239 = (SEqS(k_1236, "junk") ? ((V)("#7d7f84")) : (SEqS(k_1236, "cot") ? ((V)("#a86b36")) : (SEqS(k_1236, "mod") ? IRON_33 : (SEqS(k_1236, "royal") ? GOLD_28 : ((V)("#e9ecef"))))));
LP_1240 = Call(rep_36, V.Undef, ((V)(4D)), Fn((V _arrowThis1248, int _argc1241, V i_1247, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
double t_1249 = 0;
t_1249 = ((((-7.5) + (90D * ToNum(i_1247))) * PI_32) / 180D);
return Arr(((V)((13D * FdLibm.Cos(t_1249)))), ((V)((13D * FdLibm.Sin(t_1249)))));
return default;
}, 1, "", true));
return NewObj(8).Put("w", ((V)(44D))).Put("d", ((V)(44D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)((h_1237 + (Truthy(fl_1238) ? 16D : 9D))))).V)).Put("anim", (Truthy(fl_1238) ? Call(bob_47, V.Undef, ((V)(4D)), ((V)(2.6))) : ((V)("")))).Put("pad", (Truthy(fl_1238) ? Arr(((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(0D))) : V.Null)).Put("build", Fn((V _arrowThis1257, int _argc1250, V P_1256, V _a1253, V _a1254, V _a1255, V[] _rest1251) => {
V o_1258 = default;
o_1258 = Arr();
if (Truthy(fl_1238)) {
Invoke(o_1258, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(17D)), ((V)(4D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(12D)), ((V)(1.2)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(3.4)), ((V)(36D)), ((V)("#c9d0d6")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(6D)), ((V)(1.2)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.7))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((h_1237 + 4D))), ((V)(0D)), ((V)(14D)), ((V)(2D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.6))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((h_1237 + 7D))), ((V)(0D)), ((V)(19D)), ((V)(9D)), ((V)("#f1eee8")), NewObj(3).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.92))))).Put("soft", ((V)(1D))).V));
return o_1258;
}
Invoke(LP_1240, "forEach", Fn((V _arrowThis1270, int _argc1259, V _a1261, V _a1262, V _a1263, V _a1264, V[] _rest1260) => {
V x_1267 = default;
V z_1269 = default;
{ V _t1265 = ListOf(_a1261);
{ V _t1266 = GetIdx(_t1265, 0D);
x_1267 = _t1266; }
{ V _t1268 = GetIdx(_t1265, 1D);
z_1269 = _t1268; }
}
return Invoke(o_1258, "push", Call(cyl_14, V.Undef, x_1267, ((V)(0D)), z_1269, ((V)((SEqS(k_1236, "royal") ? 1.9 : 2.2))), ((V)(h_1237)), met_1239, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(h_1237)), ((V)(0D)), ((V)(1.05))))).V)));
}, 1, "", true));
Invoke(o_1258, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)((h_1237 * 0.32))), ((V)(0D)), ((V)(15D)), ((V)(15D)), ((V)(2D)), ((V)(2D)), ((V)(0D)), ((V)((2D * PI_32))), (SEqS(k_1236, "royal") ? GOLD_28 : met_1239), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((h_1237 - 3D))), ((V)(0D)), ((V)(14D)), ((V)(3D)), met_1239, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
if (SEqS(k_1236, "junk")) {
Invoke(o_1258, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(h_1237)), ((V)(0D)), ((V)(16D)), ((V)(4D)), ((V)("#8a8f94")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(ball_15, V.Undef, ((V)((-6D))), ((V)((h_1237 + 3.4))), ((V)(4D)), ((V)(2.4)), ((V)("#a0603a")), NewObj(3).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_15, V.Undef, ((V)(7D)), ((V)((h_1237 + 3.4))), ((V)((-3D))), ((V)(1.8)), ((V)("#a0603a")), NewObj(3).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
} else {
if (SEqS(k_1236, "cot")) {
Invoke(o_1258, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(h_1237)), ((V)(0D)), ((V)(18D)), ((V)(6D)), ((V)("#b98a58")), NewObj(3).Put("rz", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.96))))).Put("mat", ((V)("wood"))).V));
} else {
if (SEqS(k_1236, "royal")) {
InvokeSpread(o_1258, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)((h_1237 - 1D))), ((V)(0D)), ((V)(18D)), ((V)(2D)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))).Add(Call(cush_13, V.Undef, ((V)(0D)), ((V)(h_1237)), ((V)(0D)), ((V)(34D)), ((V)(10D)), ((V)(34D)), ((V)((Truthy(Invoke(NewRegExp(RX23, "emerald", ""), "test", Get(S_1234, "nm"))) ? "#1f6a4c" : "#7f2030"))), NewObj(1).Put("r", ((V)(15D))).V)).Spread(Invoke(Arr(Arr(((V)((-7D))), ((V)((-7D)))), Arr(((V)(7D)), ((V)((-7D)))), Arr(((V)((-7D))), ((V)(7D))), Arr(((V)(7D)), ((V)(7D))), Arr(((V)(0D)), ((V)(0D)))), "map", Fn((V _arrowThis1282, int _argc1271, V _a1273, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
V x_1279 = default;
V z_1281 = default;
{ V _t1277 = ListOf(_a1273);
{ V _t1278 = GetIdx(_t1277, 0D);
x_1279 = _t1278; }
{ V _t1280 = GetIdx(_t1277, 1D);
z_1281 = _t1280; }
}
return Call(ball_15, V.Undef, x_1279, ((V)((h_1237 + 9.4))), z_1281, ((V)(1.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true))).V);
} else {
InvokeSpread(o_1258, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(h_1237)), ((V)(1D)), ((V)(18D)), ((V)(5D)), (Truthy(Invoke(NewRegExp(RX24, "leather|tractor", ""), "test", Get(S_1234, "nm"))) ? ((V)("#a8592b")) : Get(P_1256, "a")), NewObj(3).Put("rz", ((V)(15D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.92))))).Put("shine", ((V)(1D))).V)).Spread(Invoke(Arr(Arr(((V)((-6D))), ((V)(0D))), Arr(((V)(0D)), ((V)((-4D)))), Arr(((V)(6D)), ((V)(0D))), Arr(((V)(0D)), ((V)(5D)))), "map", Fn((V _arrowThis1294, int _argc1283, V _a1285, V _a1286, V _a1287, V _a1288, V[] _rest1284) => {
V x_1291 = default;
V z_1293 = default;
{ V _t1289 = ListOf(_a1285);
{ V _t1290 = GetIdx(_t1289, 0D);
x_1291 = _t1290; }
{ V _t1292 = GetIdx(_t1289, 1D);
z_1293 = _t1292; }
}
return Call(cyl_14, V.Undef, x_1291, ((V)((h_1237 + 5D))), Add(z_1293, ((V)(1D))), ((V)(1.4)), ((V)(0.4)), ((V)("#3a2a20")), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))).V);
}
}
}
return o_1258;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "puffPouf", Fn((V _arrowThis1302, int _argc1295, V S_1301, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
return NewObj(8).Put("w", ((V)(72D))).Put("d", ((V)(72D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("squish", ((V)(1D))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)(34D))).V)).Put("wrap", Fn((V _arrowThis1311, int _argc1303, V p_1309, V s_1310, V _a1307, V _a1308, V[] _rest1304) => {
return Call(about_40, V.Undef, Call(p_1309, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), Call(at_38, V.Undef, ((V)("scale")), ((V)("1 1;1.035 0.95;0.985 1.03;1 1")), ((V)(2.6))), s_1310);
}, 2, "wrap", true)).Put("build", Fn((V _arrowThis1319, int _argc1312, V P_1318, V _a1315, V _a1316, V _a1317, V[] _rest1313) => {
V c_1320 = default;
V o_1321 = default;
c_1320 = Get(P_1318, "a");
o_1321 = Arr(Call(ball_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(33D)), c_1320, NewObj(6).Put("sy", ((V)(0.64))).Put("k", ((V)(8D))).Put("n", ((V)(22D))).Put("soft", ((V)(1D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V));
Invoke(o_1321, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(33.4)), ((V)(33.4)), ((V)(1D)), ((V)(1.6)), ((V)(0D)), ((V)((2D * PI_32))), Call(shade_22, V.Undef, c_1320, ((V)(0.82))), NewObj(2).Put("n", ((V)(22D))).Put("noOut", ((V)(1D))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(40.6)), ((V)(0D)), ((V)(3.4)), Call(shade_22, V.Undef, c_1320, ((V)(0.72))), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis1329, int _argc1322, V i_1328, V _a1325, V _a1326, V _a1327, V[] _rest1323) => {
double a_1330 = 0;
a_1330 = ((((ToNum(i_1328) / 6D) * 2D) * PI_32) + 0.3);
Invoke(o_1321, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1330) * 15D))), ((V)(37.6)), ((V)((FdLibm.Sin(a_1330) * 15D))), ((V)(2D)), Call(shade_22, V.Undef, c_1320, ((V)(0.8))), NewObj(4).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
return o_1321;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "calendar", Fn((V _arrowThis1338, int _argc1331, V S_1337, V _a1334, V _a1335, V _a1336, V[] _rest1332) => {
return NewObj(5).Put("w", ((V)(76D))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis1346, int _argc1339, V P_1345, V _a1342, V _a1343, V _a1344, V[] _rest1340) => {
return Arr(Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1.6))), ((V)(72D)), ((V)(98D)), ((V)(1.6)), ((V)("#c49a62")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("wood"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0.1)), ((V)(66D)), ((V)(90D)), ((V)(0.9)), ((V)("#fffdf6")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("paint"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(82D)), ((V)(1.1)), ((V)(66D)), ((V)(10D)), ((V)(0.5)), ((V)("#d9483b")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(93D)), ((V)(1.6)), ((V)(2.6)), ((V)("#3f7fc8")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1354, int _argc1347, V c_1353, V _a1350, V _a1351, V _a1352, V[] _rest1348) => {
V d_1355 = default;
V Y_1356 = default;
V Mo_1357 = default;
V td_1358 = default;
V f0_1359 = default;
V nd_1360 = default;
V mk_1361 = default;
V MN_1362 = default;
V WD_1363 = default;
JsStrBuf g_1364 = null;
d_1355 = New(G("Date"));
Y_1356 = Invoke(d_1355, "getFullYear");
Mo_1357 = Invoke(d_1355, "getMonth");
td_1358 = Invoke(d_1355, "getDate");
f0_1359 = Invoke(New(G("Date"), Y_1356, Mo_1357, ((V)(1D))), "getDay");
nd_1360 = Invoke(New(G("Date"), Y_1356, Add(Mo_1357, ((V)(1D))), ((V)(0D))), "getDate");
mk_1361 = New(G("Set"), Invoke(Invoke(Invoke(((V)(ToStrS((Get(S_1337, "ex") is var _t1365 && Truthy(_t1365) ? _t1365 : ((V)("")))))), "split", ((V)(","))), "filter", G("Boolean")), "map", G("Number")));
MN_1362 = GetK(Arr(((V)("JANUARY")), ((V)("FEBRUARY")), ((V)("MARCH")), ((V)("APRIL")), ((V)("MAY")), ((V)("JUNE")), ((V)("JULY")), ((V)("AUGUST")), ((V)("SEPTEMBER")), ((V)("OCTOBER")), ((V)("NOVEMBER")), ((V)("DECEMBER"))), Mo_1357);
WD_1363 = GetK(Arr(((V)("Sun")), ((V)("Mon")), ((V)("Tue")), ((V)("Wed")), ((V)("Thu")), ((V)("Fri")), ((V)("Sat"))), Invoke(d_1355, "getDay"));
g_1364 = new JsStrBuf(JsStrBuf.Begin().S("<text x=\"0\" y=\"7.4\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-weight=\"700\" font-size=\"5.6\" fill=\"#ffffff\">").V(MN_1362).S(" ").V(Y_1356).S("</text>").End());
Invoke(Invoke(((V)("SMTWTFS")), "split", ((V)(""))), "forEach", Fn((V _arrowThis1374, int _argc1366, V w_1372, V i_1373, V _a1370, V _a1371, V[] _rest1367) => {
return ((V)(g_1364.S("<text x=\"").V(Call(f1_23, V.Undef, ((V)(((-28.3) + (ToNum(i_1373) * 9.43)))))).S("\" y=\"15.6\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3.6\" fill=\"").S((Truthy(i_1373) ? "#6b4426" : "#d9483b")).S("\">").V(w_1372).S("</text>").Str));
}, 2, "", true));
{
double i_1375 = 0;
i_1375 = 0D;
while (true) {
if (!(Lt(((V)(i_1375)), nd_1360))) break;
V cell_1377 = default;
V cx_1378 = default;
double cy_1379 = 0;
double day_1380 = 0;
cell_1377 = Add(f0_1359, ((V)(i_1375)));
cx_1378 = Call(f1_23, V.Undef, ((V)(((-28.3) + ((ToNum(cell_1377) % 7D) * 9.43)))));
cy_1379 = (23D + (System.Math.Floor((ToNum(cell_1377) / 7D)) * 9.6));
day_1380 = (i_1375 + 1D);
if (SEqN(td_1358, day_1380)) {
g_1364.S("<circle cx=\"").V(cx_1378).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((cy_1379 - 1.3))))).S("\" r=\"4.2\" fill=\"#d9483b\">").V(Call(an_37, V.Undef, ((V)("r")), ((V)("4.2;4.8;4.2")), ((V)(1.6)))).S("</circle>");
}
g_1364.S("<text x=\"").V(cx_1378).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(cy_1379)))).S("\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3.8\" fill=\"").S((SEqN(td_1358, day_1380) ? "#ffffff" : "#3b2614")).S("\">").N(day_1380).S("</text>");
if (Lt(((V)(day_1380)), td_1358)) {
g_1364.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(cx_1378) - 3D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((cy_1379 - 4.4))))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(cx_1378) + 3D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((cy_1379 + 1.4))))).S("M").V(Call(f1_23, V.Undef, ((V)((ToNum(cx_1378) + 3D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((cy_1379 - 4.4))))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(cx_1378) - 3D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((cy_1379 + 1.4))))).S("\" stroke=\"#d9483b\" stroke-width=\"0.7\" opacity=\"0.55\"/>");
}
if (Truthy(Invoke(mk_1361, "has", ((V)(day_1380))))) {
g_1364.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(cx_1378) + 3.3))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((cy_1379 - 4.2))))).S("\" r=\"1.7\" fill=\"#3f9a5a\" stroke=\"#ffffff\" stroke-width=\"0.4\"/>");
}
i_1375++;
}
}
g_1364.S("<text x=\"0\" y=\"86\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3.8\" fill=\"#8a5a34\">Today \u00b7 ").V(WD_1363).S(" ").V(td_1358).S("</text>");
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_1353, "p"), ((V)(1.1)), ((V)(92D)))).S("\">").S(g_1364.Str).S("</g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
PAINT_56 = Arr(((V)("Sunset Sea")), ((V)("Starry Swirl")), ((V)("Flower Garden")), ((V)("Squish Portrait")), ((V)("Abstract Flow")));
Set(N_24, "masterpiece", Fn((V _arrowThis1388, int _argc1381, V S_1387, V _a1384, V _a1385, V _a1386, V[] _rest1382) => {
return NewObj(5).Put("w", ((V)(130D))).Put("d", ((V)(12D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis1396, int _argc1389, V P_1395, V _a1392, V _a1393, V _a1394, V[] _rest1390) => {
V o_1397 = default;
o_1397 = Arr(Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-2.4))), ((V)(126D)), ((V)(100D)), ((V)(5D)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(1.2)), ((V)(112D)), ((V)(86D)), ((V)(1.4)), Call(shade_22, V.Undef, GOLD_28, ((V)(0.82))), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(2.2)), ((V)(104D)), ((V)(78D)), ((V)(0.6)), ((V)("#2a2440")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(Arr(((V)((-60D))), ((V)(2D))), Arr(((V)(60D)), ((V)(2D))), Arr(((V)((-60D))), ((V)(96D))), Arr(((V)(60D)), ((V)(96D)))), "forEach", Fn((V _arrowThis1409, int _argc1398, V _a1400, V _a1401, V _a1402, V _a1403, V[] _rest1399) => {
V x_1406 = default;
V y_1408 = default;
{ V _t1404 = ListOf(_a1400);
{ V _t1405 = GetIdx(_t1404, 0D);
x_1406 = _t1405; }
{ V _t1407 = GetIdx(_t1404, 1D);
y_1408 = _t1407; }
}
return Invoke(o_1397, "push", Call(ball_15, V.Undef, x_1406, ((V)((ToNum(y_1408) - 3D))), ((V)(2.4)), ((V)(4.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Invoke(o_1397, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)(95D)), ((V)(2.6)), ((V)(5D)), GOLD_28, Call(mt_35, V.Undef, NewObj(3).Put("sx", ((V)(2.4))).Put("sy", ((V)(0.7))).Put("k", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(100D)), ((V)(2D)), ((V)(3D)), ((V)(7D)), ((V)(6D)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(106D)), ((V)(7D)), ((V)(56D)), ((V)(4.4)), ((V)(5D)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(105.4)), ((V)(9.6)), ((V)(50D)), ((V)(1D)), ((V)(1D)), ((V)("#fff1b0")), Call(em_26, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
return o_1397;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1417, int _argc1410, V c_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
double sty_1418 = 0;
V id_1419 = default;
V R_1420 = default;
JsStrBuf g_1421 = null;
sty_1418 = ((double)(ToInt32(Max(0D, ToNum(Invoke(PAINT_56, "indexOf", Get(S_1387, "st"))))) | ToInt32(0D)));
id_1419 = ((V)(JsStrBuf.Begin().S("mp").N(sty_1418).End()));
R_1420 = Call(rng_55, V.Undef, Add(Get(Get(S_1387, "row"), "id"), ((V)(sty_1418))));
g_1421 = new JsStrBuf(JsStrBuf.Begin().S("<clipPath id=\"").V(id_1419).S("\"><rect x=\"-52\" y=\"0\" width=\"104\" height=\"78\"/></clipPath><g clip-path=\"url(#").V(id_1419).S(")\">").End());
if ((sty_1418 == 0D)) {
g_1421.S("<defs><linearGradient id=\"").V(id_1419).S("s\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffd27a\"/><stop offset=\"0.6\" stop-color=\"#ff8a5a\"/><stop offset=\"1\" stop-color=\"#8a5ab0\"/></linearGradient></defs><rect x=\"-52\" y=\"0\" width=\"104\" height=\"50\" fill=\"url(#").V(id_1419).S("s)\"/>").S("<circle cx=\"14\" cy=\"38\" r=\"11\" fill=\"#fff1b0\">").V(Call(an_37, V.Undef, ((V)("r")), ((V)("11;12.6;11")), ((V)(4D)))).S("</circle>").V(Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1429, int _argc1422, V i_1428, V _a1425, V _a1426, V _a1427, V[] _rest1423) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").N(((-30D) + (ToNum(i_1428) * 30D))).S("\" cy=\"").N((10D + (ToNum(i_1428) * 5D))).S("\" rx=\"13\" ry=\"3.6\" fill=\"#ffe6c4\" opacity=\"0.8\">").V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").N((8D + (ToNum(i_1428) * 3D))).S(" 0;0 0").End())), ((V)((9D + (ToNum(i_1428) * 2D)))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"-52\" y=\"46\" width=\"104\" height=\"32\" fill=\"#2f5f9a\"/><path d=\"M8 47h12l-2 4h-8Z\" fill=\"#ffd27a\" opacity=\"0.8\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.5;0.95;0.5")), ((V)(2D)))).S("</path>").V(Invoke(Call(rep_36, V.Undef, ((V)(4D)), Fn((V _arrowThis1437, int _argc1430, V i_1436, V _a1433, V _a1434, V _a1435, V[] _rest1431) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Invoke(Call(rep_36, V.Undef, ((V)(10D)), Fn((V _arrowThis1445, int _argc1438, V j_1444, V _a1441, V _a1442, V _a1443, V[] _rest1439) => {
return ((V)(JsStrBuf.Begin().S((Truthy(j_1444) ? "" : JsStrBuf.Begin().S("M-76 ").N((52D + (ToNum(i_1436) * 7D))).End())).S("q6 -").N((2D + (ToNum(i_1436) % 2D))).S(" 12 0t12 0").End()));
}, 1, "", true)), "join", ((V)("")))).S("\" fill=\"none\" stroke=\"").V(GetK(Arr(((V)("#9fd2f2")), ((V)("#cfe8f2")), ((V)("#6ac8ff")), ((V)("#ffffff"))), i_1436)).S("\" stroke-width=\"1.5\" opacity=\"0.85\">").V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").N((NumTruthy((ToNum(i_1436) % 2D)) ? 24D : (-24D))).S(" 0").End())), ((V)((2.6 + (ToNum(i_1436) * 0.6)))))).S("</path>").End()));
}, 1, "", true)), "join", ((V)(""))));
} else {
if ((sty_1418 == 1D)) {
g_1421.S("<rect x=\"-52\" y=\"0\" width=\"104\" height=\"78\" fill=\"#1d2f6a\"/>").V(Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1453, int _argc1446, V i_1452, V _a1449, V _a1450, V _a1451, V[] _rest1447) => {
V x_1454 = default;
V y_1455 = default;
V r_1456 = default;
x_1454 = GetK(Arr(((V)((-24D))), ((V)(10D)), ((V)(34D))), i_1452);
y_1455 = GetK(Arr(((V)(22D)), ((V)(16D)), ((V)(34D))), i_1452);
r_1456 = GetK(Arr(((V)(14D)), ((V)(10D)), ((V)(8D))), i_1452);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_1454).S(" ").V(y_1455).S(")\"><g>").V(Call(at_38, V.Undef, ((V)("rotate")), ((V)(string.Concat((NumTruthy((ToNum(i_1452) % 2D)) ? "360" : "0"), ";", (NumTruthy((ToNum(i_1452) % 2D)) ? "0" : "360")))), ((V)((12D + (ToNum(i_1452) * 4D)))))).S("<path d=\"M-").V(r_1456).S(" 0a").V(r_1456).S(" ").V(r_1456).S(" 0 1 1 ").N((2D * ToNum(r_1456))).S(" 0a").N((ToNum(r_1456) * 0.7)).S(" ").N((ToNum(r_1456) * 0.7)).S(" 0 1 1 -").N((ToNum(r_1456) * 1.4)).S(" 0\" fill=\"none\" stroke=\"").V(GetK(Arr(((V)("#9fd2f2")), ((V)("#ffd66b")), ((V)("#cfe8f2"))), i_1452)).S("\" stroke-width=\"2.4\" stroke-dasharray=\"5 3\" opacity=\"0.9\"/></g></g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_36, V.Undef, ((V)(12D)), Fn((V _arrowThis1464, int _argc1457, V i_1463, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((-48D) + (ToNum(Call(R_1420, V.Undef)) * 96D)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((4D + (ToNum(Call(R_1420, V.Undef)) * 40D)))))).S("\" r=\"1.4\" fill=\"#fff4b0\">").V(Call(an_37, V.Undef, ((V)("r")), ((V)("0.8;2;0.8")), ((V)((1.4 + ((ToNum(i_1463) % 4D) * 0.4)))), ((V)(((-ToNum(i_1463)) * 0.3))))).S("</circle>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"38\" cy=\"10\" r=\"7\" fill=\"#ffe680\"/><circle cx=\"41\" cy=\"8\" r=\"6\" fill=\"#1d2f6a\"/><path d=\"M-52 78V58Q-30 48 -8 58T40 54T52 60V78Z\" fill=\"#16233f\"/>").S("<g transform=\"translate(-34 78)\"><g>").V(Call(at_38, V.Undef, ((V)("rotate")), ((V)("-4;4;-4")), ((V)(5D)))).S("<path d=\"M-5 0Q-8 -30 0 -54Q8 -30 5 0Z\" fill=\"#14301e\"/></g></g>");
} else {
if ((sty_1418 == 2D)) {
g_1421.S("<rect x=\"-52\" y=\"0\" width=\"104\" height=\"44\" fill=\"#bfe4f2\"/><rect x=\"-52\" y=\"40\" width=\"104\" height=\"38\" fill=\"#6aa65a\"/><ellipse cx=\"-20\" cy=\"40\" rx=\"44\" ry=\"8\" fill=\"#7fbf64\"/>").V(Invoke(Call(rep_36, V.Undef, ((V)(9D)), Fn((V _arrowThis1472, int _argc1465, V i_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
double x_1473 = 0;
double y_1474 = 0;
double h_1475 = 0;
V col_1476 = default;
x_1473 = ((-46D) + (ToNum(i_1471) * 11.5));
y_1474 = (58D + ((ToNum(i_1471) % 3D) * 6D));
h_1475 = (14D + ((ToNum(i_1471) % 3D) * 5D));
col_1476 = GetIdx(Arr(((V)("#f2c94c")), ((V)("#ef8f7f")), ((V)("#b9a6e0")), ((V)("#ffffff")), ((V)("#e88a3a"))), (ToNum(i_1471) % 5D));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").N(x_1473).S(" ").N(y_1474).S(")\"><g>").V(Call(at_38, V.Undef, ((V)("rotate")), ((V)("-7;7;-7")), ((V)((2.6 + ((ToNum(i_1471) % 3D) * 0.5)))), ((V)(((-ToNum(i_1471)) * 0.4))))).S("<path d=\"M0 0V-").N(h_1475).S("\" stroke=\"#3f7a3a\" stroke-width=\"1.2\"/>").V(Invoke(Call(rep_36, V.Undef, ((V)(5D)), Fn((V _arrowThis1484, int _argc1477, V j_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos((ToNum(j_1483) * 1.256)) * 3D))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-h_1475) + (FdLibm.Sin((ToNum(j_1483) * 1.256)) * 3D)))))).S("\" r=\"2.4\" fill=\"").V(col_1476).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"0\" cy=\"-").N(h_1475).S("\" r=\"1.6\" fill=\"#8a5a34\"/></g></g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("<g><animateMotion dur=\"7s\" repeatCount=\"indefinite\" path=\"M-40 30Q-10 6 14 26T44 18Q20 40 -40 30Z\"/><path d=\"M0 0l-4 -3v6Z M0 0l4 -3v6Z\" fill=\"#ffd66b\"><animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;0.3 1;1 1\" dur=\"0.3s\" repeatCount=\"indefinite\"/></path></g><circle cx=\"38\" cy=\"10\" r=\"6\" fill=\"#fff1b0\"/>");
} else {
if ((sty_1418 == 3D)) {
g_1421.S("<rect x=\"-52\" y=\"0\" width=\"104\" height=\"78\" fill=\"#e9c98a\"/><ellipse cx=\"0\" cy=\"40\" rx=\"50\" ry=\"40\" fill=\"#f6dfaa\" opacity=\"0.6\"/>").S("<g><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -1.4;0 0\" dur=\"2.4s\" repeatCount=\"indefinite\"/><path d=\"M-30 80Q-34 30 0 24Q34 30 30 80Z\" fill=\"#9fdcc4\"/><ellipse cx=\"0\" cy=\"38\" rx=\"26\" ry=\"22\" fill=\"#a9e4cc\"/><path d=\"M-20 22l-6 -12l12 6Z M20 22l6 -12l-12 6Z\" fill=\"#a9e4cc\"/>").V(Invoke(Invoke(Arr(((V)("-9")), ((V)("9"))), "map", Fn((V _arrowThis1492, int _argc1485, V x_1491, V _a1488, V _a1489, V _a1490, V[] _rest1486) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_1491).S("\" cy=\"36\" rx=\"3.4\" ry=\"4.2\" fill=\"#2a1a10\">").V(Call(an_37, V.Undef, ((V)("ry")), ((V)("4.2;4.2;0.4;4.2")), ((V)(4D)), ((V)(0D)), ((V)("0;0.9;0.95;1")))).S("</ellipse><circle cx=\"").N((ToNum(x_1491) + 1.2)).S("\" cy=\"34.4\" r=\"1.2\" fill=\"#ffffff\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<ellipse cx=\"-15\" cy=\"44\" rx=\"4\" ry=\"2.4\" fill=\"#ef8f7f\" opacity=\"0.7\"/><ellipse cx=\"15\" cy=\"44\" rx=\"4\" ry=\"2.4\" fill=\"#ef8f7f\" opacity=\"0.7\"/><path d=\"M-4 45Q0 49 4 45\" fill=\"none\" stroke=\"#2a1a10\" stroke-width=\"1.2\" stroke-linecap=\"round\"/></g>").V(Invoke(Call(rep_36, V.Undef, ((V)(5D)), Fn((V _arrowThis1500, int _argc1493, V i_1499, V _a1496, V _a1497, V _a1498, V[] _rest1494) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N(((-46D) + (ToNum(i_1499) * 22D))).S(" ").N((6D + ((ToNum(i_1499) % 2D) * 8D))).S("l1.4 3l3 1.4l-3 1.4l-1.4 3l-1.4 -3l-3 -1.4l3 -1.4Z\" fill=\"#fffaf1\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)(2D)), ((V)(((-ToNum(i_1499)) * 0.4))))).S("</path>").End()));
}, 1, "", true)), "join", ((V)(""))));
} else {
g_1421.S("<rect x=\"-52\" y=\"0\" width=\"104\" height=\"78\" fill=\"#2a2440\"/>").V(Invoke(Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis1508, int _argc1501, V i_1507, V _a1504, V _a1505, V _a1506, V[] _rest1502) => {
double x_1509 = 0;
double y_1510 = 0;
double r_1511 = 0;
V cs_1512 = default;
x_1509 = ((-40D) + (ToNum(Call(R_1420, V.Undef)) * 80D));
y_1510 = (10D + (ToNum(Call(R_1420, V.Undef)) * 58D));
r_1511 = (14D + (ToNum(Call(R_1420, V.Undef)) * 14D));
cs_1512 = Invoke(Invoke(Invoke(Invoke(Invoke(NE_27, "slice", ((V)((ToNum(i_1507) % 6D)))), "concat", Invoke(NE_27, "slice", ((V)(0D)), ((V)((ToNum(i_1507) % 6D))))), "slice", ((V)(0D)), ((V)(4D))), "concat", GetIdx(NE_27, (ToNum(i_1507) % 6D))), "join", ((V)(";")));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_1509)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_1510)))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(r_1511)))).S("\" opacity=\"0.72\" fill=\"").V(GetIdx(NE_27, (ToNum(i_1507) % 6D))).S("\">").V(Call(an_37, V.Undef, ((V)("fill")), cs_1512, Add(((V)(8D)), i_1507))).V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(Call(f1_23, V.Undef, ((V)(((ToNum(Call(R_1420, V.Undef)) - 0.5) * 30D))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((ToNum(Call(R_1420, V.Undef)) - 0.5) * 20D))))).S(";0 0").End())), ((V)((6D + (ToNum(i_1507) * 1.3)))))).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-52 60Q-20 20 10 50T52 30\" fill=\"none\" stroke=\"#fffaf1\" stroke-width=\"2\" opacity=\"0.6\" stroke-dasharray=\"120\" stroke-dashoffset=\"120\">").V(Call(an_37, V.Undef, ((V)("stroke-dashoffset")), ((V)("120;0;-120")), ((V)(6D)))).S("</path>");
}
}
}
}
g_1421.V(Invoke(Call(rep_36, V.Undef, ((V)(14D)), Fn((V _arrowThis1520, int _argc1513, V i_1519, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-52D) + (ToNum(i_1519) * 8D)))))).S(" 0l-6 78\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.05\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<defs><linearGradient id=\"").V(id_1419).S("h\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\" gradientTransform=\"translate(-1 0)\"><stop offset=\"0.4\" stop-color=\"#fff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff\" stop-opacity=\"0.22\"/><stop offset=\"0.6\" stop-color=\"#fff\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-1 0;1 0;1 0\" keyTimes=\"0;0.4;1\" dur=\"7s\" repeatCount=\"indefinite\"/></linearGradient></defs><rect x=\"-52\" y=\"0\" width=\"104\" height=\"78\" fill=\"url(#").V(id_1419).S("h)\"/></g>");
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_1416, "p"), ((V)(2.9)), ((V)(89D)))).S("\">").S(g_1421.Str).S("<path d=\"M-26 -14H26L44 24H-44Z\" fill=\"#fff6c8\" opacity=\"0.14\"/></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "quote", Fn((V _arrowThis1528, int _argc1521, V S_1527, V _a1524, V _a1525, V _a1526, V[] _rest1522) => {
V k_1529 = default;
V t_1530 = default;
double W_1531 = 0;
double Hh_1532 = 0;
V wood_1533 = default;
k_1529 = Get(S_1527, "k");
t_1530 = Invoke(((Get(S_1527, "txt") is var _t1534 && Truthy(_t1534) ? _t1534 : Get(Get(S_1527, "row"), "txt0")) is var _t1535 && Truthy(_t1535) ? _t1535 : ((V)("Home Sweet Home"))), "slice", ((V)(0D)), ((V)(26D)));
W_1531 = Min(236D, (40D + (ToNum(Get(t_1530, "length")) * 8.6)));
Hh_1532 = 44D;
wood_1533 = ((SEqS(k_1529, "cot") || SEqS(k_1529, "retro")) ? V.True : V.False);
return NewObj(5).Put("w", ((V)((W_1531 + 10D)))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis1543, int _argc1536, V P_1542, V _a1539, V _a1540, V _a1541, V[] _rest1537) => {
V o_1544 = default;
o_1544 = Arr();
if (SEqS(k_1529, "junk")) {
InvokeSpread(o_1544, "push", new ArrBuilder().Add(Call(slab_16, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(W_1531)), ((V)((Hh_1532 - 6D))), ((V)(0.8)), ((V)("#f4efe2")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("paint"))).V)).Spread(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1552, int _argc1545, V s_1551, V _a1548, V _a1549, V _a1550, V[] _rest1546) => {
return Call(slab_16, V.Undef, ((V)((ToNum(s_1551) * ((W_1531 / 2D) - 6D)))), ((V)((Hh_1532 - 8D))), ((V)(0.9)), ((V)(16D)), ((V)(7D)), ((V)(0.4)), ((V)("#f6efc8")), NewObj(3).Put("r", ((V)(0D))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))).Add(Call(slab_16, V.Undef, ((V)(((W_1531 / 2D) - 10D))), ((V)(2D)), ((V)(0.9)), ((V)(14D)), ((V)(6D)), ((V)(0.4)), ((V)("#f6efc8")), NewObj(3).Put("r", ((V)(0D))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).V)).V);
} else {
if (Truthy(wood_1533)) {
Invoke(o_1544, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), ((V)(W_1531)), ((V)(Hh_1532)), ((V)(4D)), ((V)("#a8794a")), NewObj(2).Put("r", ((V)(5D))).Put("mat", ((V)("wood"))).V), Call(ball_15, V.Undef, ((V)((((-W_1531) / 2D) + 8D))), ((V)((Hh_1532 - 7D))), ((V)(3.2)), ((V)(1.8)), ((V)("#6b6f74")), Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(ball_15, V.Undef, ((V)(((W_1531 / 2D) - 8D))), ((V)((Hh_1532 - 7D))), ((V)(3.2)), ((V)(1.8)), ((V)("#6b6f74")), Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
} else {
if (SEqS(k_1529, "candy")) {
InvokeSpread(o_1544, "push", new ArrBuilder().Add(Call(slab_16, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)((-1D))), ((V)((W_1531 + 10D))), ((V)((Hh_1532 + 4D))), ((V)(1.6)), ((V)("#cfe8f2")), NewObj(3).Put("r", ((V)(8D))).Put("op", ((V)(0.3))).Put("mat", ((V)("cer"))).V)).Spread(Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "map", Fn((V _arrowThis1564, int _argc1553, V _a1555, V _a1556, V _a1557, V _a1558, V[] _rest1554) => {
V a_1561 = default;
V b_1563 = default;
{ V _t1559 = ListOf(_a1555);
{ V _t1560 = GetIdx(_t1559, 0D);
a_1561 = _t1560; }
{ V _t1562 = GetIdx(_t1559, 1D);
b_1563 = _t1562; }
}
return Call(disc_19, V.Undef, ((V)((ToNum(a_1561) * (W_1531 / 2D)))), ((V)(((Hh_1532 / 2D) + (ToNum(b_1563) * ((Hh_1532 / 2D) - 4D))))), ((V)(0.6)), ((V)(2.2)), ((V)(2D)), CH_29, Call(mt_35, V.Undef));
}, 1, "", true))).V);
} else {
if (SEqS(k_1529, "royal")) {
InvokeSpread(o_1544, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(((-W_1531) / 3D))), ((V)(0D)), ((V)((W_1531 / 3D)))), "map", Fn((V _arrowThis1572, int _argc1565, V x_1571, V _a1568, V _a1569, V _a1570, V[] _rest1566) => {
return Call(ball_15, V.Undef, x_1571, ((V)(((Hh_1532 / 2D) + 3D))), ((V)((-0.6))), ((V)(1.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true))).V);
} else {
Invoke(o_1544, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1.4))), ((V)(W_1531)), ((V)(Hh_1532)), ((V)(0.4)), ((V)("#ffffff")), NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.04))).Put("noOut", ((V)(1D))).V));
}
}
}
}
return o_1544;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1580, int _argc1573, V c_1579, V _a1576, V _a1577, V _a1578, V[] _rest1574) => {
double z_1581 = 0;
V fam_1582 = default;
double fs_1583 = 0;
V attr_1584 = default;
V g_1585 = default;
z_1581 = (Truthy(wood_1533) ? 3.2 : (SEqS(k_1529, "candy") ? 1D : 0.5));
fam_1582 = ((V)((SEqS(k_1529, "junk") ? "'Comic Sans MS', 'Marker Felt', cursive" : (Truthy(wood_1533) ? "Georgia, 'Times New Roman', serif" : "'Brush Script MT', 'Segoe Script', 'Lucida Handwriting', cursive"))));
fs_1583 = (Truthy((wood_1533 is var _t1586 && Truthy(_t1586) ? _t1586 : (SEqS(k_1529, "junk") ? V.True : V.False))) ? 17D : 24D);
attr_1584 = ((V)(JsStrBuf.Begin().S(" x=\"0\" y=\"").V(Call(f1_23, V.Undef, ((V)((fs_1583 * 0.34))))).S("\" text-anchor=\"middle\" font-family=\"").V(fam_1582).S("\" font-size=\"").N(fs_1583).S("\" textLength=\"").V(Call(f1_23, V.Undef, ((V)((W_1531 - 22D))))).S("\" lengthAdjust=\"spacingAndGlyphs\"").S((Truthy(wood_1533) ? " font-style=\"italic\" font-weight=\"700\"" : "")).End()));
g_1585 = V.Undef;
if (SEqS(k_1529, "candy")) {
g_1585 = ((V)(JsStrBuf.Begin().S("<g filter=\"url(#gw)\"><text").V(attr_1584).S(" fill=\"none\" stroke=\"#ffd66b\" stroke-width=\"2.6\">").V(Call(xe_46, V.Undef, t_1530)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;1;0.55;1;1;0.7;1")), ((V)(5D)))).S("</text><text").V(attr_1584).S(" fill=\"none\" stroke=\"#fffaf1\" stroke-width=\"0.8\">").V(Call(xe_46, V.Undef, t_1530)).S("</text></g>").End()));
} else {
if (SEqS(k_1529, "royal")) {
g_1585 = ((V)(JsStrBuf.Begin().S("<text").V(attr_1584).S(" fill=\"none\" stroke=\"#8a6420\" stroke-width=\"2.8\">").V(Call(xe_46, V.Undef, t_1530)).S("</text><text").V(attr_1584).S(" fill=\"none\" stroke=\"").V(GOLD_28).S("\" stroke-width=\"1.6\">").V(Call(xe_46, V.Undef, t_1530)).S("</text>").End()));
} else {
g_1585 = ((V)(JsStrBuf.Begin().S("<text").V(attr_1584).S(" fill=\"").S((Truthy(wood_1533) ? "#fffaf1" : (SEqS(k_1529, "junk") ? "#2a1a10" : "#2c2d31"))).S("\"").S((SEqS(k_1529, "junk") ? " transform=\"rotate(-2)\"" : "")).S(">").V(Call(xe_46, V.Undef, t_1530)).S("</text>").End()));
}
}
return NewObj(2).Put("defs", GLOW_48).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_1579, "p"), ((V)(z_1581)), ((V)((Hh_1532 / 2D))))).S("\">").V(g_1585).S("</g>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "rsign", Fn((V _arrowThis1594, int _argc1587, V S_1593, V _a1590, V _a1591, V _a1592, V[] _rest1588) => {
V D_1595 = default;
V F_1596 = default;
V T_1597 = default;
V t_1598 = default;
D_1595 = Invoke(Get(X_9, "ARCH"), "sign", S_1593);
F_1596 = Get(D_1595, "face");
T_1597 = (GetK(Get(X_9, "SIGNST"), Get(S_1593, "st")) is var _t1599 && Truthy(_t1599) ? _t1599 : Get(Get(X_9, "SIGNST"), "card"));
t_1598 = Invoke(((Get(S_1593, "txt") is var _t1600 && Truthy(_t1600) ? _t1600 : Get(Get(S_1593, "row"), "txt0")) is var _t1601 && Truthy(_t1601) ? _t1601 : ((V)("DANCE!"))), "slice", ((V)(0D)), ((V)(22D)));
Set(D_1595, "fx", Fn((V _arrowThis1609, int _argc1602, V c_1608, V _a1605, V _a1606, V _a1607, V[] _rest1603) => {
double fs_1610 = 0;
V fam_1611 = default;
V fit_1612 = default;
V glow_1613 = default;
V attr_1614 = default;
JsStrBuf g_1615 = null;
fs_1610 = Min((ToNum(Get(F_1596, "h")) * 0.66), ((ToNum(Get(F_1596, "w")) * 1.7) / Max(4D, ToNum(Get(t_1598, "length")))));
fam_1611 = Invoke(Get(T_1597, "ff"), "replace", NewRegExp(RX3, "\"", "g"), ((V)("'")));
fit_1612 = ((((ToNum(Get(t_1598, "length")) * fs_1610) * ToNum(Get(T_1597, "cw"))) > (ToNum(Get(F_1596, "w")) * 0.92)) ? V.True : V.False);
glow_1613 = (((SEqS(Get(S_1593, "st"), "neon") || SEqS(Get(S_1593, "st"), "led")) || SEqS(Get(S_1593, "st"), "marq")) ? V.True : V.False);
attr_1614 = ((V)(JsStrBuf.Begin().S(" x=\"0\" y=\"").V(Call(f1_23, V.Undef, ((V)((fs_1610 * 0.34))))).S("\" text-anchor=\"middle\" font-family=\"").V(fam_1611).S("\" font-size=\"").V(Call(f1_23, V.Undef, ((V)(fs_1610)))).S("\"").S((Truthy(fit_1612) ? JsStrBuf.Begin().S(" textLength=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(F_1596, "w")) * 0.92))))).S("\" lengthAdjust=\"spacingAndGlyphs\"").End() : "")).S((Truthy(Get(T_1597, "rot")) ? JsStrBuf.Begin().S(" transform=\"rotate(").V(Get(T_1597, "rot")).S(")\"").End() : "")).End()));
g_1615 = new JsStrBuf(JsStrBuf.Begin().S("<text").V(attr_1614).S(" fill=\"").V(Get(T_1597, "col")).S("\">").V(Call(xe_46, V.Undef, t_1598)).S("</text>").End());
if (SEqS(Get(S_1593, "st"), "neon")) {
g_1615.Set(JsStrBuf.Begin().S("<g filter=\"url(#gw)\"><text").V(attr_1614).S(" fill=\"none\" stroke=\"#ff4fd8\" stroke-width=\"2.2\">").V(Call(xe_46, V.Undef, t_1598)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;1;0.5;1;1;1;0.75;1")), ((V)(4.6)))).S("</text><text").V(attr_1614).S(" fill=\"#ffffff\">").V(Call(xe_46, V.Undef, t_1598)).S("</text></g>").End());
}
if (SEqS(Get(S_1593, "st"), "led")) {
g_1615.Set(JsStrBuf.Begin().S("<clipPath id=\"lc\"><rect x=\"").V(Call(f1_23, V.Undef, ((V)(((-ToNum(Get(F_1596, "w"))) / 2D))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((-ToNum(Get(F_1596, "h"))) / 2D))))).S("\" width=\"").V(Call(f1_23, V.Undef, Get(F_1596, "w"))).S("\" height=\"").V(Call(f1_23, V.Undef, Get(F_1596, "h"))).S("\"/></clipPath><g clip-path=\"url(#lc)\" filter=\"url(#gw)\"><g>").V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(Call(f1_23, V.Undef, ((V)((-ToNum(Get(F_1596, "w"))))))).S(" 0;").V(Call(f1_23, V.Undef, Get(F_1596, "w"))).S(" 0;0 0").End())), ((V)(7D)), ((V)(0D)), ((V)("0;0.45;0.4501;1")))).S("<text x=\"0\" y=\"").V(Call(f1_23, V.Undef, ((V)((fs_1610 * 0.34))))).S("\" text-anchor=\"middle\" font-family=\"").V(fam_1611).S("\" font-size=\"").V(Call(f1_23, V.Undef, ((V)(fs_1610)))).S("\" fill=\"").V(Get(T_1597, "col")).S("\" letter-spacing=\"2\">").V(Call(xe_46, V.Undef, t_1598)).S("</text></g></g>").End());
}
if (SEqS(Get(S_1593, "st"), "marq")) {
g_1615.Set(JsStrBuf.Begin().S("<g>").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.86;1")), ((V)(1.2)))).S(g_1615.Str).S("</g>").End());
}
return NewObj(2).Put("defs", (Truthy(glow_1613) ? GLOW_48 : ((V)("")))).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_1608, "p"), Add(Get(F_1596, "z"), ((V)(0.6))), Get(F_1596, "y"))).S("\">").S(g_1615.Str).S("</g>").End()))).V;
return default;
}, 1, "", true));
return D_1595;
return default;
}, 1, "", true));
Set(N_24, "dripCoffee", Fn((V _arrowThis1623, int _argc1616, V S_1622, V _a1619, V _a1620, V _a1621, V[] _rest1617) => {
return NewObj(4).Put("w", ((V)(48D))).Put("d", ((V)(42D))).Put("build", Fn((V _arrowThis1631, int _argc1624, V P_1630, V _a1627, V _a1628, V _a1629, V[] _rest1625) => {
V k_1632 = default;
V b_1633 = default;
V o_1634 = default;
k_1632 = Get(S_1622, "k");
b_1633 = (SEqS(k_1632, "junk") ? ((V)("#2f3034")) : (SEqS(k_1632, "cot") ? ((V)("#f1eee8")) : Get(P_1630, "a")));
o_1634 = Arr();
Invoke(o_1634, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(44D)), ((V)(7D)), ((V)(38D)), b_1633, NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("paint"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(8D)), ((V)(12.5)), ((V)(1.4)), ((V)("#1d1d20")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-13D))), ((V)(44D)), ((V)(66D)), ((V)(14D)), b_1633, NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(44D)), ((V)(14D)), ((V)(40D)), b_1633, NewObj(3).Put("r", ((V)(5D))).Put("bev", ((V)(2D))).Put("mat", ((V)("paint"))).V), Call(slab_16, V.Undef, ((V)((-15D))), ((V)(18D)), ((V)((-5.6))), ((V)(7D)), ((V)(30D)), ((V)(0.6)), ((V)("#9fd2f2")), NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).V), Call(disc_19, V.Undef, ((V)(15D)), ((V)(4D)), ((V)(21.2)), ((V)(2.2)), ((V)(0.8)), ((V)("#ff4a3a")), Call(em_26, V.Undef)));
Invoke(o_1634, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(8D)), ((V)(11D)), ((V)(8D)), ((V)("#3a3a3e")), NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(8.6)), ((V)(8D)), ((V)(11.2)), ((V)(13D)), ((V)("#4a2a14")), NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(10D)), ((V)(0D)), ((V)(1.04))), Arr(((V)(13D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(8.4)), ((V)(8D)), ((V)(12D)), ((V)(27D)), GL_31, NewObj(4).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(10D)), ((V)(0D)), ((V)(1.06))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(27D)), ((V)(0D)), ((V)(0.86))))).Put("op", ((V)(0.5))).Put("mat", ((V)("cer"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(8D)), ((V)(10.6)), ((V)(3D)), ((V)("#1d1d20")), NewObj(1).Put("n", ((V)(14D))).V), Call(box_12, V.Undef, ((V)(14.5)), ((V)(14D)), ((V)(8D)), ((V)(3D)), ((V)(16D)), ((V)(4D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1.4))).V), Call(slabX_17, V.Undef, ((V)(12D)), ((V)(28D)), ((V)(8D)), ((V)(6D)), ((V)(2.4)), ((V)(3D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1D))).V), Call(slabX_17, V.Undef, ((V)(12D)), ((V)(13D)), ((V)(8D)), ((V)(6D)), ((V)(2.4)), ((V)(3D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1D))).V));
if (SEqS(k_1632, "junk")) {
Invoke(o_1634, "push", Call(slab_16, V.Undef, ((V)(4D)), ((V)(13D)), ((V)(20.2)), ((V)(0.7)), ((V)(13D)), ((V)(0.3)), WH_30, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slab_16, V.Undef, ((V)(6D)), ((V)(20D)), ((V)(19.8)), ((V)(0.6)), ((V)(6D)), ((V)(0.3)), WH_30, NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.8))).V));
}
return o_1634;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1642, int _argc1635, V c_1641, V _a1638, V _a1639, V _a1640, V[] _rest1636) => {
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().V(Add(Add(Call(drip_50, V.Undef, c_1641, ((V)(0D)), ((V)(43D)), ((V)(22D)), ((V)(8D)), ((V)("#5a3a20")), ((V)(0.8))), Call(drip_50, V.Undef, c_1641, ((V)(0D)), ((V)(43D)), ((V)(22D)), ((V)(8D)), ((V)("#5a3a20")), ((V)(0.8)), ((V)((-0.4))))), Call(steam_49, V.Undef, c_1641, ((V)(0D)), ((V)(37D)), ((V)(8D)), ((V)(0.8)), ((V)(3D))))).S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(Invoke(c_1641, "p", ((V)(15D)), ((V)(4D)), ((V)(21.4))), 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(Invoke(c_1641, "p", ((V)(15D)), ((V)(4D)), ((V)(21.4))), 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(Get(c_1641, "k"))))))).S("\" fill=\"#ff4a3a\" opacity=\"0.3\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.1;0.5;0.1")), ((V)(1.6)))).S("</circle>").End()))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "podBrewer", Fn((V _arrowThis1650, int _argc1643, V S_1649, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
return NewObj(4).Put("w", ((V)(42D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1658, int _argc1651, V P_1657, V _a1654, V _a1655, V _a1656, V[] _rest1652) => {
V b_1659 = default;
b_1659 = Get(P_1657, "a");
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(6D)), ((V)(44D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(4D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-10D))), ((V)(36D)), ((V)(50D)), ((V)(24D)), b_1659, NewObj(3).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(56D)), ((V)((-4D))), ((V)(36D)), ((V)(10D)), ((V)(36D)), b_1659, NewObj(3).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(66D)), ((V)((-4D))), ((V)(30D)), ((V)(2D)), ((V)(28D)), Call(shade_22, V.Undef, b_1659, ((V)(1.15))), NewObj(1).Put("r", ((V)(6D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-26D))), ((V)(30D)), ((V)(46D)), ((V)(8D)), GL_31, NewObj(3).Put("r", ((V)(4D))).Put("op", ((V)(0.5))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(7D)), ((V)((-26D))), ((V)(27D)), ((V)(32D)), ((V)(6D)), ((V)("#7ac8f0")), NewObj(3).Put("r", ((V)(3D))).Put("op", ((V)(0.7))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(12D)), ((V)(30D)), ((V)(3D)), ((V)(18D)), ((V)("#3a3a3e")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(9D)), ((V)(3D)), ((V)(4D)), ((V)("#2c2d31")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_14, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)(12D)), ((V)(7.5)), ((V)(13D)), WH_30, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V), Call(cyl_14, V.Undef, ((V)((-1D))), ((V)(21.4)), ((V)(12D)), ((V)(6.6)), ((V)(0.6)), ((V)("#5a3a20")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(8.5)), ((V)(13D)), ((V)(12D)), ((V)(3D)), ((V)(8D)), ((V)(2.4)), WH_30, NewObj(1).Put("r", ((V)(1.4))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(2.4)), ((V)(22D)), ((V)(8D)), ((V)(0.6)), ((V)("#1d2030")), NewObj(1).Put("r", ((V)(3D))).V), Call(disc_19, V.Undef, ((V)((-6D))), ((V)(46D)), ((V)(3.2)), ((V)(1.6)), ((V)(0.4)), ((V)("#6ac8ff")), Call(em_26, V.Undef)), Call(disc_19, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(3.2)), ((V)(1.6)), ((V)(0.4)), ((V)("#a6f06a")), Call(em_26, V.Undef)), Call(disc_19, V.Undef, ((V)(6D)), ((V)(46D)), ((V)(3.2)), ((V)(1.6)), ((V)(0.4)), ((V)("#ffd66b")), Call(em_26, V.Undef)));
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1667, int _argc1660, V c_1666, V _a1663, V _a1664, V _a1665, V[] _rest1661) => {
return NewObj(1).Put("front", Add(Add(Call(drip_50, V.Undef, c_1666, ((V)(0D)), ((V)(51D)), ((V)(22D)), ((V)(9D)), ((V)("#5a3a20")), ((V)(0.7))), Call(drip_50, V.Undef, c_1666, ((V)(0D)), ((V)(51D)), ((V)(22D)), ((V)(9D)), ((V)("#5a3a20")), ((V)(0.7)), ((V)((-0.35))))), Call(steam_49, V.Undef, c_1666, ((V)((-1D))), ((V)(23D)), ((V)(12D)), ((V)(0.7)), ((V)(2D))))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "toaster", Fn((V _arrowThis1675, int _argc1668, V S_1674, V _a1671, V _a1672, V _a1673, V[] _rest1669) => {
V st_1676 = default;
V k_1677 = default;
V toast_1678 = default;
V L_1679 = default;
V KT_1680 = default;
V slice_1681 = default;
V sw_1682 = default;
V lever_1683 = default;
st_1676 = Get(S_1674, "st");
k_1677 = Get(S_1674, "k");
toast_1678 = (SEqS(st_1676, "pop") ? V.True : V.False);
L_1679 = ((V)("translate"));
KT_1680 = ((V)("0;0.1;0.16;0.68;0.73;0.8;1"));
slice_1681 = Fn((V _arrowThis1691, int _argc1684, V z_1690, V _a1687, V _a1688, V _a1689, V[] _rest1685) => {
return Fn((V _arrowThis1698, int _argc1692, V _a1694, V _a1695, V _a1696, V _a1697, V[] _rest1693) => {
return Arr(Call(slab_16, V.Undef, ((V)(0D)), ((V)(30.4)), z_1690, ((V)(28D)), ((V)(16D)), ((V)(3.6)), ((V)((Truthy(toast_1678) ? "#8a4a1e" : "#c88a46"))), NewObj(3).Put("r", ((V)(6D))).Put("rb", ((V)(0D))).Put("mat", ((V)("paint"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(30.4)), Add(z_1690, ((V)(0.3))), ((V)(24.6)), ((V)(14D)), ((V)(3.8)), ((V)((Truthy(toast_1678) ? "#c47a3a" : "#f6e2b6"))), NewObj(3).Put("r", ((V)(5D))).Put("rb", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true);
}, 1, "", true);
sw_1682 = Fn((V _arrowThis1706, int _argc1699, V z_1705, V _a1702, V _a1703, V _a1704, V[] _rest1700) => {
return Fn((V _arrowThis1715, int _argc1707, V p_1713, V s_1714, V _a1711, V _a1712, V[] _rest1708) => {
V q_1716 = default;
q_1716 = Call(p_1713, V.Undef, ((V)(0D)), ((V)(30.4)), z_1705);
return (SEqS(st_1676, "in") ? Call(@fixed_41, V.Undef, q_1716, ((V)("scale(1 0.12)")), s_1714) : (SEqS(st_1676, "pop") ? Call(about_40, V.Undef, q_1716, Call(at_38, V.Undef, L_1679, ((V)("0 0;0 -6;0 0;0 0")), ((V)(1.6)), ((V)(0D)), ((V)("0;0.15;0.3;1"))), Call(@fixed_41, V.Undef, q_1716, ((V)("scale(1 1.25)")), s_1714)) : (Truthy(st_1676) ? s_1714 : Call(about_40, V.Undef, q_1716, Call(at_38, V.Undef, ((V)("scale")), ((V)("1 1;1 1;1 0.12;1 0.12;1 1.3;1 1;1 1")), ((V)(8D)), ((V)(0D)), KT_1680), s_1714))));
return default;
}, 2, "", true);
}, 1, "", true);
lever_1683 = Fn((V _arrowThis1725, int _argc1717, V p_1723, V s_1724, V _a1721, V _a1722, V[] _rest1718) => {
V dy_1726 = default;
dy_1726 = Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(Call(p_1723, V.Undef, ((V)(25D)), ((V)(8D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_1723, V.Undef, ((V)(25D)), ((V)(20D)), ((V)(0D))), 1D))))));
return (SEqS(st_1676, "in") ? ((V)(JsStrBuf.Begin().S("<g transform=\"translate(0 ").V(dy_1726).S(")\">").V(s_1724).S("</g>").End())) : (Truthy(st_1676) ? s_1724 : ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_38, V.Undef, L_1679, ((V)(JsStrBuf.Begin().S("0 0;0 0;0 ").V(dy_1726).S(";0 ").V(dy_1726).S(";0 0;0 0;0 0").End())), ((V)(8D)), ((V)(0D)), KT_1680)).V(s_1724).S("</g>").End()))));
return default;
}, 2, "", true);
return NewObj(5).Put("w", ((V)(54D))).Put("d", ((V)(36D))).Put("layers", Arr(NewObj(2).Put("build", Call(slice_1681, V.Undef, ((V)((-5.5))))).Put("wrap", Call(sw_1682, V.Undef, ((V)((-5.5))))).V, NewObj(2).Put("build", Call(slice_1681, V.Undef, ((V)(5.5)))).Put("wrap", Call(sw_1682, V.Undef, ((V)(5.5)))).V, NewObj(2).Put("build", Fn((V _arrowThis1733, int _argc1727, V _a1729, V _a1730, V _a1731, V _a1732, V[] _rest1728) => {
return Arr(Call(box_12, V.Undef, ((V)(25D)), ((V)(20D)), ((V)(0D)), ((V)(3D)), ((V)(3.4)), ((V)(9D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(1D))).V));
}, 0, "build", true)).Put("wrap", lever_1683).V)).Put("build", Fn((V _arrowThis1741, int _argc1734, V P_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
V body_1742 = default;
body_1742 = ((SEqS(k_1677, "junk") || SEqS(k_1677, "mod")) ? CH_29 : Get(P_1740, "a"));
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(48D)), ((V)(4D)), ((V)(30D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(10D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(50D)), ((V)(26D)), ((V)(32D)), body_1742, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(12D))).Put("bev", ((V)(5D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)((-5.5))), ((V)(30D)), ((V)(0.5)), ((V)(4.6)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1.5))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(5.5)), ((V)(30D)), ((V)(0.5)), ((V)(4.6)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1.5))).V), Call(slabX_17, V.Undef, ((V)(25.4)), ((V)(8D)), ((V)(0D)), ((V)(0.6)), ((V)(18D)), ((V)(3D)), ((V)("#1d1d20")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(disc_19, V.Undef, ((V)((-12D))), ((V)(16D)), ((V)(16.2)), ((V)(3.4)), ((V)(1.6)), ((V)("#2c2d31"))), Call(disc_19, V.Undef, ((V)(12D)), ((V)(16D)), ((V)(16.2)), ((V)(2D)), ((V)(1D)), ((V)("#ff6a2a")), Call(em_26, V.Undef)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(4.5)), ((V)(16.2)), ((V)(30D)), ((V)(3D)), ((V)(0.6)), Call(shade_22, V.Undef, body_1742, ((V)(0.8))), NewObj(1).Put("r", ((V)(1D))).V));
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1750, int _argc1743, V c_1749, V _a1746, V _a1747, V _a1748, V[] _rest1744) => {
V gl_1751 = default;
gl_1751 = Invoke(Invoke(Arr(((V)((-5.5))), ((V)(5.5))), "map", Fn((V _arrowThis1759, int _argc1752, V z_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
V a_1760 = default;
V b_1761 = default;
V e_1762 = default;
V d_1763 = default;
a_1760 = Invoke(c_1749, "p", ((V)((-15D))), ((V)(30.6)), ((V)((ToNum(z_1758) - 2D))));
b_1761 = Invoke(c_1749, "p", ((V)(15D)), ((V)(30.6)), ((V)((ToNum(z_1758) - 2D))));
e_1762 = Invoke(c_1749, "p", ((V)(15D)), ((V)(30.6)), Add(z_1758, ((V)(2D))));
d_1763 = Invoke(c_1749, "p", ((V)((-15D))), ((V)(30.6)), Add(z_1758, ((V)(2D))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_39, V.Undef, a_1760)).S("L").V(Call(P2_39, V.Undef, b_1761)).S("L").V(Call(P2_39, V.Undef, e_1762)).S("L").V(Call(P2_39, V.Undef, d_1763)).S("Z\" fill=\"#ff7a2a\"").S((SEqS(st_1676, "in") ? JsStrBuf.Begin().S(" opacity=\"0.85\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.6;0.95;0.6")), ((V)(0.8)))).End() : (Truthy(st_1676) ? " opacity=\"0\">" : JsStrBuf.Begin().S(" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;0;0.85;0.85;0;0;0")), ((V)(8D)), ((V)(0D)), KT_1680)).End()))).S("</path>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
return NewObj(1).Put("front", Add(gl_1751, (SEqS(st_1676, "pop") ? Add(Call(steam_49, V.Undef, c_1749, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(0.6)), ((V)(3D))), Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1771, int _argc1764, V i_1770, V _a1767, V _a1768, V _a1769, V[] _rest1765) => {
return Call(spark_51, V.Undef, c_1749, ((V)(((-10D) + (ToNum(i_1770) * 10D)))), ((V)((52D + ((ToNum(i_1770) % 2D) * 4D)))), ((V)(6D)), ((V)(0.7)), ((V)(((-ToNum(i_1770)) * 0.5))), ((V)("#fff1b0")));
}, 1, "", true)), "join", ((V)("")))) : ((V)(""))))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "dish2", Fn((V _arrowThis1779, int _argc1772, V S_1778, V _a1775, V _a1776, V _a1777, V[] _rest1773) => {
V k_1780 = default;
V st_1781 = default;
V open_1782 = default;
V clean_1783 = default;
V wash_1784 = default;
V nm_1785 = default;
V dirty_1786 = default;
V mini_1787 = default;
V wood_1788 = default;
V plasma_1789 = default;
double Hh_1790 = 0;
double Wd_1791 = 0;
double Dd_1792 = 0;
double zf_1793 = 0;
V body_1794 = default;
V front_1795 = default;
V hd_1796 = default;
V fm_1797 = default;
k_1780 = Get(S_1778, "k");
st_1781 = (Get(S_1778, "st") is var _t1798 && Truthy(_t1798) ? _t1798 : ((V)("")));
open_1782 = ((SEqS(st_1781, "load") || SEqS(st_1781, "clean")) ? V.True : V.False);
clean_1783 = (SEqS(st_1781, "clean") ? V.True : V.False);
wash_1784 = (SEqS(st_1781, "wash") ? V.True : V.False);
nm_1785 = Get(S_1778, "nm");
dirty_1786 = Fn((V _arrowThis1809, int _argc1799, V x_1805, V y_1806, V z_1807, V r_1808, V[] _rest1800) => {
return Arr(Call(plate_53, V.Undef, x_1805, y_1806, z_1807, r_1808, ((V)("#f4f2ee"))), Call(ball_15, V.Undef, Add(x_1805, ((V)(0.9))), ((V)((ToNum(y_1806) - 2D))), Add(z_1807, ((V)(2D))), ((V)(2D)), ((V)("#a0703a")), NewObj(3).Put("sx", ((V)(0.25))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_15, V.Undef, Add(x_1805, ((V)(0.9))), Add(y_1806, ((V)(3D))), ((V)((ToNum(z_1807) - 2.4))), ((V)(1.4)), ((V)("#7a8a3a")), NewObj(3).Put("sx", ((V)(0.25))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 4, "", true);
if (SEqS(k_1780, "junk")) {
return NewObj(4).Put("w", ((V)(92D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1817, int _argc1810, V P_1816, V _a1813, V _a1814, V _a1815, V[] _rest1811) => {
V o_1818 = default;
o_1818 = Arr(Call(box_12, V.Undef, ((V)((-22D))), ((V)(0D)), ((V)(0D)), ((V)(40D)), ((V)(14D)), ((V)(34D)), ((V)("#7fb8d8")), NewObj(2).Put("r", ((V)(6D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)((-22D))), ((V)(11D)), ((V)(0D)), ((V)(35D)), ((V)(1D)), ((V)(29D)), ((V)((Truthy(wash_1784) ? "#e8f4fa" : "#bfe4f2"))), NewObj(3).Put("r", ((V)(5D))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(22D)), ((V)(0D)), ((V)(0D)), ((V)(40D)), ((V)(3D)), ((V)(32D)), ((V)("#f1eee8")), NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("paint"))).V));
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis1826, int _argc1819, V i_1825, V _a1822, V _a1823, V _a1824, V[] _rest1820) => {
return Invoke(o_1818, "push", Call(cyl_14, V.Undef, ((V)(((22D - 16D) + (ToNum(i_1825) * 6.4)))), ((V)(3D)), ((V)((-12D))), ((V)(0.8)), ((V)(16D)), ((V)("#d8d2c6")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_14, V.Undef, ((V)(((22D - 16D) + (ToNum(i_1825) * 6.4)))), ((V)(3D)), ((V)(12D)), ((V)(0.8)), ((V)(9D)), ((V)("#d8d2c6")), NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true));
if (Truthy(clean_1783)) {
Call(rep_36, V.Undef, ((V)(4D)), Fn((V _arrowThis1834, int _argc1827, V i_1833, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
return Invoke(o_1818, "push", Call(plate_53, V.Undef, ((V)((10D + (ToNum(i_1833) * 7.6)))), ((V)(12D)), ((V)(0D)), ((V)(9D)), ((V)("#ffffff"))));
}, 1, "", true));
} else {
Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1842, int _argc1835, V i_1841, V _a1838, V _a1839, V _a1840, V[] _rest1836) => {
return InvokeSpread(o_1818, "push", new ArrBuilder().Spread(Call(dirty_1786, V.Undef, ((V)(((-32D) + (ToNum(i_1841) * 9D)))), ((V)(13D)), ((V)(0D)), ((V)(9D)))).V);
}, 1, "", true));
}
return o_1818;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1850, int _argc1843, V c_1849, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
return NewObj(1).Put("front", Add((Truthy(wash_1784) ? Call(bubbles_52, V.Undef, c_1849, ((V)((-22D))), ((V)(12D)), ((V)(4D)), ((V)(30D)), ((V)(9D))) : ((V)(""))), (Truthy(clean_1783) ? Invoke(Call(rep_36, V.Undef, ((V)(4D)), Fn((V _arrowThis1858, int _argc1851, V i_1857, V _a1854, V _a1855, V _a1856, V[] _rest1852) => {
return Call(spark_51, V.Undef, c_1849, ((V)((10D + (ToNum(i_1857) * 7.6)))), ((V)((18D + ((ToNum(i_1857) % 2D) * 5D)))), ((V)(6D)), ((V)(0.8)), ((V)(((-ToNum(i_1857)) * 0.45))));
}, 1, "", true)), "join", ((V)(""))) : ((V)(""))))).V;
}, 1, "fx", true)).V;
}
mini_1787 = Invoke(NewRegExp(RX25, "countertop|portable|mini", ""), "test", nm_1785);
wood_1788 = Invoke(NewRegExp(RX26, "wood-panel|integrated", ""), "test", nm_1785);
plasma_1789 = Invoke(NewRegExp(RX27, "plasma|robotic", ""), "test", nm_1785);
Hh_1790 = (Truthy(mini_1787) ? 46D : 80D);
Wd_1791 = (Truthy(mini_1787) ? 48D : 60D);
Dd_1792 = (Truthy(mini_1787) ? 42D : 56D);
zf_1793 = (Dd_1792 / 2D);
body_1794 = ((V)((Truthy(plasma_1789) ? "#2a2630" : (Truthy(wood_1788) ? "#a86b36" : "#c9d3d8"))));
front_1795 = ((V)((Truthy(plasma_1789) ? "#3a3448" : (Truthy(wood_1788) ? "#b8794a" : "#d5dde2"))));
hd_1796 = (Truthy(plasma_1789) ? ((V)("#8fe8ff")) : (Truthy(wood_1788) ? GOLD_28 : CH_29));
fm_1797 = ((V)((Truthy(wood_1788) ? "wood" : (Truthy(plasma_1789) ? "paint" : "metal"))));
return NewObj(5).Put("w", ((V)((Wd_1791 + 4D)))).Put("d", ((V)((Dd_1792 + (Truthy(open_1782) ? 50D : 0D))))).Put("anim", (Truthy(wash_1784) ? Call(at_38, V.Undef, ((V)("translate")), ((V)("0 0;0.7 0;-0.7 0;0 0")), ((V)(0.22))) : ((V)("")))).Put("build", Fn((V _arrowThis1866, int _argc1859, V P_1865, V _a1862, V _a1863, V _a1864, V[] _rest1860) => {
V o_1867 = default;
o_1867 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(Wd_1791)), ((V)(Hh_1790)), ((V)(Dd_1792)), body_1794, NewObj(3).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).Put("mat", fm_1797).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)((Hh_1790 - 9D))), ((V)((zf_1793 + 0.3))), ((V)((Wd_1791 - 4D))), ((V)(7D)), ((V)(0.8)), ((V)((Truthy(plasma_1789) ? "#16131c" : "#3e4046"))), NewObj(1).Put("r", ((V)(2D))).V));
if (!(Truthy(open_1782))) {
Invoke(o_1867, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(3D)), ((V)((zf_1793 + 0.4))), ((V)((Wd_1791 - 3D))), ((V)((Hh_1790 - 14D))), ((V)(1.6)), front_1795, NewObj(2).Put("r", ((V)(2D))).Put("mat", fm_1797).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((Hh_1790 - 19D))), ((V)((zf_1793 + 3D))), ((V)((Wd_1791 * 0.7))), ((V)(2.6)), ((V)(2.6)), hd_1796, (Truthy(plasma_1789) ? Call(em_26, V.Undef, NewObj(1).Put("r", ((V)(1.3))).V) : Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.3))).V))));
if (Truthy(wood_1788)) {
Invoke(o_1867, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)((Hh_1790 * 0.45))), ((V)((zf_1793 + 2.2))), ((V)((Wd_1791 - 4D))), ((V)(0.8)), ((V)(0.6)), Call(shade_22, V.Undef, front_1795, ((V)(0.7))), NewObj(1).Put("noOut", ((V)(1D))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((Hh_1790 * 0.3))), ((V)((zf_1793 + 3D))), ((V)((Wd_1791 * 0.6))), ((V)(2.4)), ((V)(2.4)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
}
if (Truthy((plasma_1789 is var _t1868 && !Truthy(_t1868) ? _t1868 : wash_1784))) {
Invoke(o_1867, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((zf_1793 + 2.1))), ((V)((Wd_1791 - 16D))), ((V)((Hh_1790 - 30D))), ((V)(0.4)), ((V)("#b48cff")), Call(em_26, V.Undef, NewObj(2).Put("r", ((V)(6D))).Put("op", ((V)(0.7))).V)));
}
if (!(Truthy(st_1781))) {
Call(rep_36, V.Undef, ((V)(4D)), Fn((V _arrowThis1876, int _argc1869, V i_1875, V _a1872, V _a1873, V _a1874, V[] _rest1870) => {
return Invoke(o_1867, "push", Call(cyl_14, V.Undef, ((V)((-6D))), ((V)((Hh_1790 + (ToNum(i_1875) * 2D)))), ((V)((-4D))), ((V)(10D)), ((V)(1.6)), ((V)("#f4f2ee")), NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).V));
}, 1, "", true));
Invoke(o_1867, "push", Call(ball_15, V.Undef, ((V)((-9D))), ((V)((Hh_1790 + 8D))), ((V)((-2D))), ((V)(2.6)), ((V)("#a0703a")), NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_15, V.Undef, ((V)((-2D))), ((V)((Hh_1790 + 8D))), ((V)((-7D))), ((V)(2D)), ((V)("#7a8a3a")), NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(cyl_14, V.Undef, ((V)(12D)), ((V)(Hh_1790)), ((V)(4D)), ((V)(4D)), ((V)(8D)), ((V)("#cfe8f2")), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.8))).V));
}
} else {
Invoke(o_1867, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(5D)), ((V)((zf_1793 + 0.2))), ((V)((Wd_1791 - 6D))), ((V)((Hh_1790 - 16D))), ((V)(0.6)), ((V)("#2c3238")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((zf_1793 + 25D))), ((V)((Wd_1791 - 3D))), ((V)(2.4)), ((V)(48D)), front_1795, NewObj(2).Put("r", ((V)(2D))).Put("mat", fm_1797).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(4.4)), ((V)((zf_1793 + 22D))), ((V)((Wd_1791 - 10D))), ((V)(8D)), ((V)(38D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.55))).V)));
Call(rep_36, V.Undef, ((V)((Truthy(mini_1787) ? 3D : 5D))), Fn((V _arrowThis1884, int _argc1877, V i_1883, V _a1880, V _a1881, V _a1882, V[] _rest1878) => {
double x_1885 = 0;
x_1885 = (((-((Truthy(mini_1787) ? 3D : 5D) - 1D)) * 4.5) + (ToNum(i_1883) * 9D));
if (Truthy(clean_1783)) {
Invoke(o_1867, "push", Call(plate_53, V.Undef, ((V)(x_1885)), ((V)(13D)), ((V)((zf_1793 + 22D))), ((V)(8D)), ((V)("#ffffff"))));
} else {
InvokeSpread(o_1867, "push", new ArrBuilder().Spread(Call(dirty_1786, V.Undef, ((V)(x_1885)), ((V)(13D)), ((V)((zf_1793 + 22D))), ((V)(8D)))).V);
}
return default;
}, 1, "", true));
}
if (Truthy(plasma_1789)) {
Invoke(o_1867, "push", Call(cyl_14, V.Undef, ((V)(((Wd_1791 / 2D) - 10D))), ((V)(Hh_1790)), ((V)((((-Dd_1792) / 2D) + 10D))), ((V)(5D)), ((V)(4D)), ((V)("#3a3448")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(box_12, V.Undef, ((V)(((Wd_1791 / 2D) - 10D))), ((V)((Hh_1790 + 4D))), ((V)((((-Dd_1792) / 2D) + 10D))), ((V)(3D)), ((V)(18D)), ((V)(3D)), ((V)("#c9d0d6")), Call(mt_35, V.Undef)), Call(box_12, V.Undef, ((V)(((Wd_1791 / 2D) - 18D))), ((V)((Hh_1790 + 20D))), ((V)((((-Dd_1792) / 2D) + 10D))), ((V)(18D)), ((V)(3D)), ((V)(3D)), ((V)("#c9d0d6")), Call(mt_35, V.Undef)), Call(ball_15, V.Undef, ((V)(((Wd_1791 / 2D) - 27D))), ((V)((Hh_1790 + 18D))), ((V)((((-Dd_1792) / 2D) + 10D))), ((V)(3D)), ((V)("#8fe8ff")), Call(em_26, V.Undef)));
}
return o_1867;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1893, int _argc1886, V c_1892, V _a1889, V _a1890, V _a1891, V[] _rest1887) => {
V q_1894 = default;
V col_1895 = default;
JsStrBuf f_1896 = null;
q_1894 = Invoke(c_1892, "p", ((V)(((Wd_1791 / 2D) - 8D))), ((V)((Hh_1790 - 5.5))), ((V)((zf_1793 + 1.4))));
col_1895 = ((V)((Truthy(wash_1784) ? "#6ac8ff" : (Truthy(clean_1783) ? "#a6f06a" : (Truthy(open_1782) ? "#ffd66b" : "#a6f06a")))));
f_1896 = new JsStrBuf(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1894, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1894, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(Get(c_1892, "k"))))))).S("\" fill=\"").V(col_1895).S("\">").V((Truthy((wash_1784 is var _t1897 && Truthy(_t1897) ? _t1897 : (!(Truthy(st_1781)) ? V.True : V.False))) ? Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)((Truthy(wash_1784) ? 0.6 : 2.4)))) : ((V)("")))).S("</circle>").End());
if (Truthy(wash_1784)) {
f_1896.V(Add(Call(bubbles_52, V.Undef, c_1892, ((V)(0D)), ((V)((Hh_1790 - 14D))), ((V)((zf_1793 + 2D))), ((V)((Wd_1791 - 10D))), ((V)(10D))), Call(steam_49, V.Undef, c_1892, ((V)(0D)), ((V)(Hh_1790)), ((V)(0D)), ((V)(0.8)), ((V)(3D)))));
}
if (Truthy(clean_1783)) {
f_1896.V(Add(Invoke(Call(rep_36, V.Undef, ((V)(5D)), Fn((V _arrowThis1905, int _argc1898, V i_1904, V _a1901, V _a1902, V _a1903, V[] _rest1899) => {
return Call(spark_51, V.Undef, c_1892, ((V)(((-18D) + (ToNum(i_1904) * 9D)))), ((V)((20D + ((ToNum(i_1904) % 2D) * 4D)))), ((V)((zf_1793 + 24D))), ((V)(0.9)), ((V)(((-ToNum(i_1904)) * 0.35))));
}, 1, "", true)), "join", ((V)(""))), Call(steam_49, V.Undef, c_1892, ((V)(0D)), ((V)(22D)), ((V)((zf_1793 + 22D))), ((V)(0.7)), ((V)(3D)))));
}
return NewObj(1).Put("front", ((V)(f_1896.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
PASTEL_57 = Arr(NewObj(2).Put("n", ((V)("Mint"))).Put("c", ((V)("#9fdcc4"))).V, NewObj(2).Put("n", ((V)("Butter"))).Put("c", ((V)("#f2dc8a"))).V, NewObj(2).Put("n", ((V)("Sky"))).Put("c", ((V)("#9fc8ec"))).V, NewObj(2).Put("n", ((V)("Lavender"))).Put("c", ((V)("#c3b2e8"))).V, NewObj(2).Put("n", ((V)("Cream"))).Put("c", ((V)("#f1e8d6"))).V);
Set(N_24, "standMixer", Fn((V _arrowThis1913, int _argc1906, V S_1912, V _a1909, V _a1910, V _a1911, V[] _rest1907) => {
return NewObj(4).Put("w", ((V)(100D))).Put("d", ((V)(52D))).Put("build", Fn((V _arrowThis1921, int _argc1914, V P_1920, V _a1917, V _a1918, V _a1919, V[] _rest1915) => {
V a_1922 = default;
V o_1923 = default;
a_1922 = Get(P_1920, "a");
o_1923 = Arr();
Invoke(o_1923, "push", Call(box_12, V.Undef, ((V)((-22D))), ((V)(0D)), ((V)(2D)), ((V)(30D)), ((V)(7D)), ((V)(42D)), a_1922, NewObj(3).Put("r", ((V)(10D))).Put("bev", ((V)(3D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)((-22D))), ((V)(7D)), ((V)((-14D))), ((V)(15D)), ((V)(38D)), ((V)(12D)), a_1922, NewObj(2).Put("r", ((V)(7D))).Put("mat", ((V)("paint"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-22D))), ((V)(50D)))).Put("a", ((V)(11D))).Put("b", ((V)(10D))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((-20D))), ((V)(3D)), ((V)(0.75))), Arr(((V)((-17D))), ((V)(0D)), ((V)(0.95))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(11D)), ((V)(2D)), ((V)(0.85))), Arr(((V)(14D)), ((V)(5D)), ((V)(0.55))))).Put("col", a_1922).Put("shine", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-22D))), ((V)(50D)))).Put("a", ((V)(11.5))).Put("b", ((V)(10.5))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((-4D))), ((V)(0D))), Arr(((V)((-1.6))), ((V)(0D))))).Put("col", CH_29).Put("mat", ((V)("metal"))).V), Call(cyl_14, V.Undef, ((V)((-22D))), ((V)(7D)), ((V)(8D)), ((V)(12D)), ((V)(17D)), CH_29, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(17D)), ((V)(0D)), ((V)(1.08))))).V)), Call(cyl_14, V.Undef, ((V)((-22D))), ((V)(23.4)), ((V)(8D)), ((V)(12.4)), ((V)(0.8)), ((V)("#f4e2b8")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V), Call(cyl_14, V.Undef, ((V)((-22D))), ((V)(24D)), ((V)(8D)), ((V)(1.4)), ((V)(16D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)((-13D))), ((V)(40D)), ((V)((-14D))), ((V)(4D)), ((V)(3D)), ((V)(8D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(o_1923, "push", Call(box_12, V.Undef, ((V)(24D)), ((V)(0D)), ((V)(0D)), ((V)(24D)), ((V)(15D)), ((V)(24D)), ((V)("#f1eee8")), NewObj(3).Put("r", ((V)(5D))).Put("bev", ((V)(2D))).Put("mat", ((V)("paint"))).V), Call(disc_19, V.Undef, ((V)(19D)), ((V)(7D)), ((V)(12.2)), ((V)(1.8)), ((V)(0.8)), ((V)("#3a3a3e"))), Call(disc_19, V.Undef, ((V)(24D)), ((V)(7D)), ((V)(12.2)), ((V)(1.8)), ((V)(0.8)), ((V)("#3a3a3e"))), Call(disc_19, V.Undef, ((V)(29D)), ((V)(7D)), ((V)(12.2)), ((V)(1.8)), ((V)(0.8)), ((V)("#ff6a4a")), Call(em_26, V.Undef)), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(15D)), ((V)(0D)), ((V)(9D)), ((V)(4D)), a_1922, NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(19.6)), ((V)(0D)), ((V)(9D)), ((V)(19D)), ((V)("#f2b04a")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(19D)), ((V)(0D)), ((V)(1.02))))).V), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(19D)), ((V)(0D)), ((V)(9.5)), ((V)(32D)), GL_31, NewObj(4).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(32D)), ((V)(0D)), ((V)(1.12))))).Put("op", ((V)(0.45))).Put("mat", ((V)("cer"))).V), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(51D)), ((V)(0D)), ((V)(10.8)), ((V)(4D)), ((V)("#2c2d31")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(55D)), ((V)(0D)), ((V)(3D)), ((V)(3D)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(8D))).V), Call(box_12, V.Undef, ((V)(34.5)), ((V)(28D)), ((V)(0D)), ((V)(3D)), ((V)(16D)), ((V)(4D)), GL_31, NewObj(2).Put("r", ((V)(1.4))).Put("op", ((V)(0.6))).V));
return o_1923;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1931, int _argc1924, V c_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
V w_1932 = default;
V u_1933 = default;
V v_1934 = default;
V whisk_1935 = default;
V vort_1936 = default;
w_1932 = Invoke(c_1930, "p", ((V)((-22D))), ((V)(30D)), ((V)(8D)));
u_1933 = Get(c_1930, "k");
v_1934 = Invoke(c_1930, "p", ((V)(24D)), ((V)(33D)), ((V)(0D)));
whisk_1935 = Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1944, int _argc1937, V i_1943, V _a1940, V _a1941, V _a1942, V[] _rest1938) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(w_1932, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(w_1932, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(u_1933)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((7D * ToNum(u_1933)))))).S("\" fill=\"none\" stroke=\"#c9d3d8\" stroke-width=\"0.9\">").V(Call(an_37, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((5D * ToNum(u_1933)))))).S(";").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(u_1933)))))).S(";").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(u_1933)))))).End())), ((V)(0.3)), ((V)(((-ToNum(i_1943)) * 0.1))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")));
vort_1936 = Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis1952, int _argc1945, V i_1951, V _a1948, V _a1949, V _a1950, V[] _rest1946) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(v_1934, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(v_1934, 1D), ((V)(((ToNum(i_1951) * 4D) * ToNum(u_1933))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(((6D - (ToNum(i_1951) * 1.5)) * ToNum(u_1933)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_1933)))))).S("\" fill=\"none\" stroke=\"#fff1c4\" stroke-width=\"0.9\" opacity=\"0.8\">").V(Call(an_37, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(((6D - (ToNum(i_1951) * 1.5)) * ToNum(u_1933)))))).S(";").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_1933)))))).S(";").V(Call(f1_23, V.Undef, ((V)(((6D - (ToNum(i_1951) * 1.5)) * ToNum(u_1933)))))).End())), ((V)(0.4)), ((V)(((-ToNum(i_1951)) * 0.13))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")));
return NewObj(1).Put("front", Add(Add(whisk_1935, vort_1936), Call(bubbles_52, V.Undef, c_1930, ((V)(24D)), ((V)(22D)), ((V)(2D)), ((V)(12D)), ((V)(5D)), ((V)("#fff1c4"))))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "espresso", Fn((V _arrowThis1960, int _argc1953, V S_1959, V _a1956, V _a1957, V _a1958, V[] _rest1954) => {
return NewObj(4).Put("w", ((V)(112D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1968, int _argc1961, V P_1967, V _a1964, V _a1965, V _a1966, V[] _rest1962) => {
V o_1969 = default;
V ch_1970 = default;
V wd_1971 = default;
double X0_1972 = 0;
double G_1973 = 0;
o_1969 = Arr();
ch_1970 = CH_29;
wd_1971 = ((V)("#6b4226"));
X0_1972 = (-14D);
Invoke(o_1969, "push", Call(box_12, V.Undef, ((V)(X0_1972)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(4D)), ((V)(46D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_12, V.Undef, ((V)(X0_1972)), ((V)(4D)), ((V)((-2D))), ((V)(64D)), ((V)(50D)), ((V)(42D)), ch_1970, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(X0_1972)), ((V)(54D)), ((V)((-2D))), ((V)(66D)), ((V)(3D)), ((V)(44D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slabX_17, V.Undef, ((V)(X0_1972)), ((V)(60D)), ((V)(17D)), ((V)(62D)), ((V)(1.6)), ((V)(1.6)), ch_1970, Call(mt_35, V.Undef)), Call(slabX_17, V.Undef, ((V)((X0_1972 + 32.4))), ((V)(10D)), ((V)((-2D))), ((V)(1.2)), ((V)(38D)), ((V)(36D)), wd_1971, NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("wood"))).V));
Invoke(Arr(((V)((-31D))), ((V)(31D))), "forEach", Fn((V _arrowThis1981, int _argc1974, V dx_1980, V _a1977, V _a1978, V _a1979, V[] _rest1975) => {
return Invoke(o_1969, "push", Call(cyl_14, V.Undef, Add(((V)(X0_1972)), dx_1980), ((V)(57D)), ((V)(17D)), ((V)(1D)), ((V)(4D)), ch_1970, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-16D))), ((V)(0D)), ((V)(16D))), "forEach", Fn((V _arrowThis1989, int _argc1982, V dx_1988, V _a1985, V _a1986, V _a1987, V[] _rest1983) => {
return Invoke(o_1969, "push", Call(cyl_14, V.Undef, Add(((V)(X0_1972)), dx_1988), ((V)(57D)), ((V)((-6D))), ((V)(4.5)), ((V)(6D)), WH_30, NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V));
}, 1, "", true));
Invoke(Arr(((V)((-14D))), ((V)(14D))), "forEach", Fn((V _arrowThis1997, int _argc1990, V dx_1996, V _a1993, V _a1994, V _a1995, V[] _rest1991) => {
V x_1998 = default;
x_1998 = Add(((V)(X0_1972)), dx_1996);
Invoke(o_1969, "push", Call(cyl_14, V.Undef, x_1998, ((V)(30D)), ((V)(22D)), ((V)(7D)), ((V)(7D)), ch_1970, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, x_1998, ((V)(26D)), ((V)(22D)), ((V)(6D)), ((V)(4D)), ((V)("#3a3a3e")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(box_12, V.Undef, x_1998, ((V)(26D)), ((V)(33D)), ((V)(3.4)), ((V)(3.4)), ((V)(18D)), wd_1971, NewObj(2).Put("r", ((V)(1.6))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, x_1998, ((V)(21D)), ((V)(23D)), ((V)(1D)), ((V)(5D)), ch_1970, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_14, V.Undef, x_1998, ((V)(8.4)), ((V)(24D)), ((V)(4.6)), ((V)(6.4)), WH_30, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V), Call(cyl_14, V.Undef, x_1998, ((V)(14.6)), ((V)(24D)), ((V)(4D)), ((V)(0.4)), ((V)("#a8693a")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, Add(x_1998, ((V)(5D))), ((V)(10D)), ((V)(24D)), ((V)(2D)), ((V)(3.4)), ((V)(1.4)), WH_30, NewObj(1).Put("r", ((V)(0.8))).V));
return default;
}, 1, "", true));
Invoke(o_1969, "push", Call(box_12, V.Undef, ((V)(X0_1972)), ((V)(4D)), ((V)(24D)), ((V)(60D)), ((V)(4D)), ((V)(12D)), ((V)("#3a3a3e")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(disc_19, V.Undef, ((V)(X0_1972)), ((V)(44D)), ((V)(19.4)), ((V)(6.4)), ((V)(1.2)), ch_1970, Call(mt_35, V.Undef)), Call(disc_19, V.Undef, ((V)(X0_1972)), ((V)(44D)), ((V)(20.6)), ((V)(5.2)), ((V)(0.4)), ((V)("#fffaf1"))), Call(cyl_14, V.Undef, ((V)((X0_1972 + 31D))), ((V)(18D)), ((V)(18D)), ((V)(1.2)), ((V)(26D)), ch_1970, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_15, V.Undef, ((V)((X0_1972 + 31D))), ((V)(44D)), ((V)(18D)), ((V)(2.6)), ((V)("#2c2d31")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(disc_19, V.Undef, ((V)((X0_1972 - 24D))), ((V)(44D)), ((V)(19.4)), ((V)(2.6)), ((V)(1.4)), ((V)("#d9483b"))));
G_1973 = 40D;
InvokeSpread(o_1969, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(G_1973)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(30D)), ((V)(26D)), ((V)("#2c2d31")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Add(Call(cyl_14, V.Undef, ((V)(G_1973)), ((V)(30D)), ((V)(0D)), ((V)(9D)), ((V)(4D)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(14D))).V)).Add(Call(cyl_14, V.Undef, ((V)(G_1973)), ((V)(35D)), ((V)(0D)), ((V)(9D)), ((V)(15D)), ((V)("#5a3a20")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(15D)), ((V)(0D)), ((V)(0.95))))).V)).Add(Call(cyl_14, V.Undef, ((V)(G_1973)), ((V)(34D)), ((V)(0D)), ((V)(10D)), ((V)(24D)), GL_31, NewObj(4).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(24D)), ((V)(0D)), ((V)(1.12))))).Put("op", ((V)(0.45))).Put("mat", ((V)("cer"))).V)).Add(Call(cyl_14, V.Undef, ((V)(G_1973)), ((V)(58D)), ((V)(0D)), ((V)(11.4)), ((V)(2.4)), ((V)("#2c2d31")), NewObj(1).Put("n", ((V)(14D))).V)).Add(Call(cyl_14, V.Undef, ((V)(G_1973)), ((V)(6D)), ((V)(14D)), ((V)(4D)), ((V)(6D)), ch_1970, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).Add(Call(disc_19, V.Undef, ((V)(G_1973)), ((V)(20D)), ((V)(13.2)), ((V)(3.4)), ((V)(1.4)), ch_1970, Call(mt_35, V.Undef))).Spread(Invoke(Arr(Arr(((V)((-3D))), ((V)(2D))), Arr(((V)(2D)), ((V)((-2D)))), Arr(((V)(4D)), ((V)(3D)))), "map", Fn((V _arrowThis2010, int _argc1999, V _a2001, V _a2002, V _a2003, V _a2004, V[] _rest2000) => {
V x_2007 = default;
V z_2009 = default;
{ V _t2005 = ListOf(_a2001);
{ V _t2006 = GetIdx(_t2005, 0D);
x_2007 = _t2006; }
{ V _t2008 = GetIdx(_t2005, 1D);
z_2009 = _t2008; }
}
return Call(ball_15, V.Undef, Add(((V)(G_1973)), x_2007), ((V)(49.4)), z_2009, ((V)(1.6)), ((V)("#6b4226")), NewObj(3).Put("sy", ((V)(0.7))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
return o_1969;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2018, int _argc2011, V c_2017, V _a2014, V _a2015, V _a2016, V[] _rest2012) => {
double X0_2019 = 0;
V g_2020 = default;
X0_2019 = (-14D);
g_2020 = Invoke(c_2017, "p", ((V)(X0_2019)), ((V)(44D)), ((V)(21.2)));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_2017, "p"), ((V)(21.2)), ((V)(44D)))).S("\"><g>").V(Call(at_38, V.Undef, ((V)("rotate")), ((V)("-50;30;10;40;-50")), ((V)(5D)))).S("<path d=\"M0 0L0 -4\" stroke=\"#d9483b\" stroke-width=\"0.8\" stroke-linecap=\"round\"/></g><circle r=\"0.8\" fill=\"#2c2d31\"/></g>").V(Invoke(Invoke(Arr(((V)((-14D))), ((V)(14D))), "map", Fn((V _arrowThis2029, int _argc2021, V dx_2027, V i_2028, V _a2025, V _a2026, V[] _rest2022) => {
return Add(Add(Call(drip_50, V.Undef, c_2017, Add(((V)(X0_2019)), dx_2027), ((V)(21D)), ((V)(15D)), ((V)(23D)), ((V)("#6b3a1a")), ((V)(0.5)), ((V)(((-ToNum(i_2028)) * 0.25)))), Call(drip_50, V.Undef, c_2017, Add(((V)(X0_2019)), dx_2027), ((V)(21D)), ((V)(15D)), ((V)(23D)), ((V)("#6b3a1a")), ((V)(0.5)), ((V)((((-ToNum(i_2028)) * 0.25) - 0.25))))), Call(steam_49, V.Undef, c_2017, Add(((V)(X0_2019)), dx_2027), ((V)(15D)), ((V)(24D)), ((V)(0.5)), ((V)(2D))));
}, 2, "", true)), "join", ((V)("")))).V(Call(steam_49, V.Undef, c_2017, ((V)((X0_2019 + 31D))), ((V)(18D)), ((V)(18D)), ((V)(0.6)), ((V)(2D)))).End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "sommelier", Fn((V _arrowThis2037, int _argc2030, V S_2036, V _a2033, V _a2034, V _a2035, V[] _rest2031) => {
return NewObj(6).Put("w", ((V)(64D))).Put("d", ((V)(48D))).Put("glow", Fn((V _arrowThis2044, int _argc2038, V _a2040, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
return NewObj(3).Put("y", ((V)(112D))).Put("r", ((V)(46D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("pad", Arr(((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(0D)))).Put("build", Fn((V _arrowThis2052, int _argc2045, V P_2051, V _a2048, V _a2049, V _a2050, V[] _rest2046) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(4D)), ((V)(44D)), ((V)("#2a2c34")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(10D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(50D)), ((V)(94D)), ((V)(40D)), ((V)("#f1eee8")), NewObj(3).Put("r", ((V)(16D))).Put("bev", ((V)(3D))).Put("mat", ((V)("cer"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(20.4)), ((V)(40D)), ((V)(50D)), ((V)(1D)), ((V)("#121420")), NewObj(1).Put("r", ((V)(10D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(14D)), ((V)(38D)), ((V)(26D)), ((V)(14D)), ((V)("#23252e")), NewObj(1).Put("r", ((V)(8D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(14D)), ((V)(14D)), ((V)(1D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.8))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(15D)), ((V)(6.4)), ((V)(11D)), WH_30, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(19.6)), ((V)(15D)), ((V)(6.2)), ((V)("#f4e6d0")), NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(4D))).Put("n", ((V)(14D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(98D)), ((V)(0D)), ((V)(20D)), ((V)(4D)), ((V)("#2a2c34")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(102D)), ((V)(0D)), ((V)(14D)), ((V)(1.6)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2060, int _argc2053, V c_2059, V _a2056, V _a2057, V _a2058, V[] _rest2054) => {
V ui_2061 = default;
V ring_2062 = default;
V orbit_2063 = default;
V cup_2064 = default;
V u_2065 = default;
ui_2061 = ((V)(JsStrBuf.Begin().S("<rect x=\"-17\" y=\"2\" width=\"34\" height=\"0.8\" fill=\"#8fe8ff\" opacity=\"0.6\">").V(Call(an_37, V.Undef, ((V)("y")), ((V)("2;46;2")), ((V)(3D)))).S("</rect><text x=\"0\" y=\"8\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3.4\" fill=\"#8fe8ff\">AI SOMMELIER</text>").V(Invoke(Call(rep_36, V.Undef, ((V)(9D)), Fn((V _arrowThis2073, int _argc2066, V i_2072, V _a2069, V _a2070, V _a2071, V[] _rest2067) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N(((-15D) + (ToNum(i_2072) * 3.4))).S("\" y=\"16\" width=\"2.2\" height=\"12\" fill=\"").V(GetIdx(NE_27, (ToNum(i_2072) % 6D))).S("\">").V(Call(an_37, V.Undef, ((V)("height")), ((V)(JsStrBuf.Begin().N((4D + ((ToNum(i_2072) % 4D) * 2D))).S(";").N((12D - ((ToNum(i_2072) % 3D) * 2D))).S(";").N((4D + ((ToNum(i_2072) % 4D) * 2D))).End())), ((V)((0.8 + ((ToNum(i_2072) % 3D) * 0.2)))), ((V)(((-ToNum(i_2072)) * 0.1))))).S("</rect>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"0\" cy=\"38\" r=\"6\" fill=\"none\" stroke=\"#3a3c48\" stroke-width=\"1.6\"/><circle cx=\"0\" cy=\"38\" r=\"6\" fill=\"none\" stroke=\"#a6f06a\" stroke-width=\"1.6\" stroke-dasharray=\"38\" stroke-dashoffset=\"38\">").V(Call(an_37, V.Undef, ((V)("stroke-dashoffset")), ((V)("38;0;38")), ((V)(4D)))).S("</circle><text x=\"0\" y=\"39.4\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3\" fill=\"#fffaf1\">98%</text>").End()));
ring_2062 = Fn((V _arrowThis2084, int _argc2074, V y_2080, V rx_2081, V col_2082, V d_2083, V[] _rest2075) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_45, V.Undef, Get(c_2059, "p"), y_2080)).S("\"><ellipse rx=\"").V(rx_2081).S("\" ry=\"").V(rx_2081).S("\" fill=\"none\" stroke=\"").V(col_2082).S("\" stroke-width=\"1.4\" stroke-dasharray=\"6 4\" filter=\"url(#gw)\">").V(Call(an_37, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;40")), d_2083)).S("</ellipse></g>").End()));
}, 4, "", true);
orbit_2063 = Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis2092, int _argc2085, V i_2091, V _a2088, V _a2089, V _a2090, V[] _rest2086) => {
V pts_2093 = default;
pts_2093 = Call(rep_36, V.Undef, ((V)(25D)), Fn((V _arrowThis2101, int _argc2094, V j_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
double a_2102 = 0;
a_2102 = (((ToNum(j_2100) / 24D) * 2D) * PI_32);
return Call(P2_39, V.Undef, Invoke(c_2059, "p", ((V)((FdLibm.Cos(a_2102) * 17D))), ((V)(112D)), ((V)((FdLibm.Sin(a_2102) * 17D)))));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((2.2 * ToNum(Get(c_2059, "k"))))))).S("\" fill=\"").V(GetK(Arr(((V)("#6b4226")), ((V)("#7f2030")), ((V)("#f2c94c"))), i_2091)).S("\"><animateMotion dur=\"5s\" begin=\"").N(((-ToNum(i_2091)) * 1.66)).S("s\" repeatCount=\"indefinite\" path=\"M").V(Invoke(pts_2093, "join", ((V)("L")))).S("Z\"/></circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
cup_2064 = Invoke(c_2059, "p", ((V)(0D)), ((V)(118D)), ((V)(0D)));
u_2065 = Get(c_2059, "k");
return NewObj(2).Put("defs", GLOW_48).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_2059, "p"), ((V)(21.2)), ((V)(90D)))).S("\">").V(ui_2061).S("</g>").V(Call(ring_2062, V.Undef, ((V)(106D)), ((V)(19D)), ((V)("#8fe8ff")), ((V)(3D)))).V(Call(ring_2062, V.Undef, ((V)(126D)), ((V)(13D)), ((V)("#b48cff")), ((V)(2.2)))).V(orbit_2063).S("<g>").V(Call(bob_47, V.Undef, ((V)(3D)), ((V)(2.4)))).S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(cup_2064, 0D)) - (7D * ToNum(u_2065))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(cup_2064, 1D)) - (6D * ToNum(u_2065))))))).S("h").V(Call(f1_23, V.Undef, ((V)((14D * ToNum(u_2065)))))).S("l-2 ").V(Call(f1_23, V.Undef, ((V)((12D * ToNum(u_2065)))))).S("h").V(Call(f1_23, V.Undef, ((V)(((-10D) * ToNum(u_2065)))))).S("Z\" fill=\"#8fe8ff\" fill-opacity=\"0.18\" stroke=\"#8fe8ff\" stroke-width=\"0.9\" filter=\"url(#gw)\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(cup_2064, 0D)) - (3D * ToNum(u_2065))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(cup_2064, 1D)) - (9D * ToNum(u_2065))))))).S("q2 -3 0 -6t0 -6\" fill=\"none\" stroke=\"#c9f4ff\" stroke-width=\"0.8\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), ((V)(1.8)))).S("</path></g>").S("<g transform=\"").V(Call(planeH_45, V.Undef, Get(c_2059, "p"), ((V)(22.2)))).S(" translate(0 15)\"><path d=\"M0 2.4C-3 0 -3 -2.4 -1.4 -2.6C-0.6 -2.7 0 -2 0 -1.4C0 -2 0.6 -2.7 1.4 -2.6C3 -2.4 3 0 0 2.4Z\" fill=\"#a8693a\"/></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "synth", Fn((V _arrowThis2110, int _argc2103, V S_2109, V _a2106, V _a2107, V _a2108, V[] _rest2104) => {
return NewObj(6).Put("w", ((V)(92D))).Put("d", ((V)(62D))).Put("glow", Fn((V _arrowThis2117, int _argc2111, V _a2113, V _a2114, V _a2115, V _a2116, V[] _rest2112) => {
return NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(60D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2125, int _argc2118, V P_2124, V _a2121, V _a2122, V _a2123, V[] _rest2119) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(84D)), ((V)(28D)), ((V)(58D)), ((V)("#23252e")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V))).Add(Call(slabX_17, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(29.4)), ((V)(76D)), ((V)(2.4)), ((V)(0.8)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(slab_16, V.Undef, ((V)((-24D))), ((V)(7D)), ((V)(29.6)), ((V)(26D)), ((V)(11D)), ((V)(0.6)), ((V)("#121420")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(76D)), ((V)(3D)), ((V)(52D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(22D)), ((V)(1.6)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("op", ((V)(0.7))).V))).Spread(Invoke(Arr(Arr(((V)((-36D))), ((V)((-24D)))), Arr(((V)(36D)), ((V)((-24D)))), Arr(((V)((-36D))), ((V)(24D))), Arr(((V)(36D)), ((V)(24D)))), "map", Fn((V _arrowThis2137, int _argc2126, V _a2128, V _a2129, V _a2130, V _a2131, V[] _rest2127) => {
V x_2134 = default;
V z_2136 = default;
{ V _t2132 = ListOf(_a2128);
{ V _t2133 = GetIdx(_t2132, 0D);
x_2134 = _t2133; }
{ V _t2135 = GetIdx(_t2132, 1D);
z_2136 = _t2135; }
}
return Call(box_12, V.Undef, x_2134, ((V)(31D)), z_2136, ((V)(4D)), ((V)(54D)), ((V)(4D)), ((V)("#c9d0d6")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(85D)), ((V)(0D)), ((V)(80D)), ((V)(5D)), ((V)(56D)), ((V)("#23252e")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Add(Call(slabX_17, V.Undef, ((V)(0D)), ((V)(79D)), ((V)(0D)), ((V)(72D)), ((V)(2D)), ((V)(2D)), ((V)("#8a8f98")), Call(mt_35, V.Undef))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(72D)), ((V)(54D)), ((V)(50D)), GL_31, NewObj(4).Put("r", ((V)(2D))).Put("op", ((V)(0.14))).Put("mat", ((V)("cer"))).Put("noOut", ((V)(1D))).V)).V;
}, 1, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis2144, int _argc2138, V _a2140, V _a2141, V _a2142, V _a2143, V[] _rest2139) => {
return Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(32.6)), ((V)(0D)), ((V)(15D)), ((V)(8D)), ((V)("#e8b878")), NewObj(1).Put("n", ((V)(18D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(40.6)), ((V)(0D)), ((V)(15.4)), ((V)(3D)), ((V)("#fff6e8")), NewObj(1).Put("n", ((V)(18D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(43.6)), ((V)(0D)), ((V)(11D)), ((V)(6D)), ((V)("#c9874a")), NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(49.6)), ((V)(0D)), ((V)(11.4)), ((V)(2.4)), ((V)("#fff6e8")), NewObj(1).Put("n", ((V)(16D))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(3.4)), ((V)("#d9483b")), NewObj(1).Put("k", ((V)(4D))).V));
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis2153, int _argc2145, V p_2151, V s_2152, V _a2149, V _a2150, V[] _rest2146) => {
return Call(about_40, V.Undef, Call(p_2151, V.Undef, ((V)(0D)), ((V)(32.6)), ((V)(0D))), Call(at_38, V.Undef, ((V)("scale")), ((V)("1 0.05;1 1;1 1;1 0.05")), ((V)(7D)), ((V)(0D)), ((V)("0;0.55;0.92;1"))), s_2152);
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis2160, int _argc2154, V _a2156, V _a2157, V _a2158, V _a2159, V[] _rest2155) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(74D)), ((V)(0D)), ((V)(12D)), ((V)(9D)), ((V)(12D)), ((V)("#c9d0d6")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(68D)), ((V)(0D)), ((V)(2D)), ((V)(6D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(0D)), ((V)(1.6)), ((V)("#8fe8ff")), Call(em_26, V.Undef)));
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis2169, int _argc2161, V p_2167, V s_2168, V _a2165, V _a2166, V[] _rest2162) => {
V v_2170 = default;
V o_2171 = default;
V dx_2172 = default;
V dy_2173 = default;
v_2170 = Call(p_2167, V.Undef, ((V)(26D)), ((V)(0D)), ((V)(0D)));
o_2171 = Call(p_2167, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dx_2172 = Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(v_2170, 0D)) - ToNum(GetIdx(o_2171, 0D))))));
dy_2173 = Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(v_2170, 1D)) - ToNum(GetIdx(o_2171, 1D))))));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("-").V(dx_2172).S(" -").V(dy_2173).S(";").V(dx_2172).S(" ").V(dy_2173).S(";-").V(dx_2172).S(" -").V(dy_2173).End())), ((V)(1.75)))).V(s_2168).S("</g>").End()));
return default;
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis2181, int _argc2174, V c_2180, V _a2177, V _a2178, V _a2179, V[] _rest2175) => {
V a_2182 = default;
V b_2183 = default;
V u_2184 = default;
double h_2185 = 0;
a_2182 = Invoke(c_2180, "p", ((V)((-36D))), ((V)(31D)), ((V)(26D)));
b_2183 = Invoke(c_2180, "p", ((V)(36D)), ((V)(31D)), ((V)(26D)));
u_2184 = Get(c_2180, "k");
h_2185 = ((54D * ToNum(u_2184)) * ToNum(Get(X_9, "CA")));
return NewObj(2).Put("defs", GLOW_48).Put("front", ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, GetIdx(a_2182, 0D))).S("\" y=\"").V(Call(f1_23, V.Undef, GetIdx(a_2182, 1D))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_2183, 0D)) - ToNum(GetIdx(a_2182, 0D))))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(u_2184)))))).S("\" fill=\"#8fe8ff\" opacity=\"0.8\" filter=\"url(#gw)\">").V(Call(an_37, V.Undef, ((V)("y")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2182, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_2182, 1D)) - h_2185))))).S(";").V(Call(f1_23, V.Undef, GetIdx(a_2182, 1D))).End())), ((V)(3.5)))).S("</rect>").V(Invoke(Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis2193, int _argc2186, V i_2192, V _a2189, V _a2190, V _a2191, V[] _rest2187) => {
return Call(spark_51, V.Undef, c_2180, ((V)(((-26D) + (ToNum(i_2192) * 10D)))), ((V)((40D + ((ToNum(i_2192) % 3D) * 10D)))), ((V)(10D)), ((V)(0.6)), ((V)(((-ToNum(i_2192)) * 0.3))), ((V)("#c9f4ff")));
}, 1, "", true)), "join", ((V)("")))).S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_2180, "p"), ((V)(29.8)), ((V)(18D)))).S("\"><text x=\"-24\" y=\"0\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3.4\" fill=\"#8fe8ff\">PRINTING").S("</text><rect x=\"-34\" y=\"2.4\" width=\"20\" height=\"1.2\" fill=\"#3a3c48\"/><rect x=\"-34\" y=\"2.4\" width=\"20\" height=\"1.2\" fill=\"#a6f06a\">").V(Call(an_37, V.Undef, ((V)("width")), ((V)("0;20;20;0")), ((V)(7D)), ((V)(0D)), ((V)("0;0.55;0.92;1")))).S("</rect></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "fruitJar", Fn((V _arrowThis2201, int _argc2194, V S_2200, V _a2197, V _a2198, V _a2199, V[] _rest2195) => {
return NewObj(3).Put("w", ((V)(96D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis2209, int _argc2202, V P_2208, V _a2205, V _a2206, V _a2207, V[] _rest2203) => {
V o_2210 = default;
V wire_2211 = default;
double bx_2212 = 0;
V apple_2213 = default;
V orange_2214 = default;
double jx_2215 = 0;
o_2210 = Arr();
wire_2211 = ((V)("#3a3a3e"));
bx_2212 = (-20D);
Invoke(o_2210, "push", Call(cyl_14, V.Undef, ((V)(bx_2212)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(2D)), wire_2211, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(arcW_18, V.Undef, ((V)(bx_2212)), ((V)(2D)), ((V)(0D)), ((V)(20D)), ((V)(18D)), ((V)(1.2)), ((V)(1.2)), ((V)(0D)), ((V)((2D * PI_32))), wire_2211, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_18, V.Undef, ((V)(bx_2212)), ((V)(13D)), ((V)(0D)), ((V)(24D)), ((V)(21D)), ((V)(1.4)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_32))), wire_2211, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(rep_36, V.Undef, ((V)(8D)), Fn((V _arrowThis2223, int _argc2216, V i_2222, V _a2219, V _a2220, V _a2221, V[] _rest2217) => {
double a_2224 = 0;
a_2224 = (((ToNum(i_2222) / 8D) * 2D) * PI_32);
Invoke(o_2210, "push", Call(cyl_14, V.Undef, ((V)((bx_2212 + (FdLibm.Cos(a_2224) * 21D)))), ((V)(2D)), ((V)((FdLibm.Sin(a_2224) * 19D))), ((V)(0.8)), ((V)(11D)), wire_2211, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
return default;
}, 1, "", true));
apple_2213 = Fn((V _arrowThis2235, int _argc2225, V x_2231, V y_2232, V z_2233, V col_2234, V[] _rest2226) => {
return Arr(Call(ball_15, V.Undef, x_2231, y_2232, z_2233, ((V)(6.4)), col_2234, NewObj(3).Put("sy", ((V)(0.92))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(cyl_14, V.Undef, x_2231, Add(y_2232, ((V)(11.4))), z_2233, ((V)(0.6)), ((V)(3D)), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_15, V.Undef, Add(x_2231, ((V)(2D))), Add(y_2232, ((V)(12.6))), z_2233, ((V)(2.2)), ((V)("#5fa84a")), NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 4, "", true);
orange_2214 = Fn((V _arrowThis2245, int _argc2236, V x_2242, V y_2243, V z_2244, V _a2241, V[] _rest2237) => {
return Arr(Call(ball_15, V.Undef, x_2242, y_2243, z_2244, ((V)(6.6)), ((V)("#f2932c")), NewObj(2).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(ball_15, V.Undef, x_2242, Add(y_2243, ((V)(12.6))), Add(z_2244, ((V)(1D))), ((V)(1D)), ((V)("#6a8a3a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
}, 3, "", true);
InvokeSpread(o_2210, "push", new ArrBuilder().Spread(Call(orange_2214, V.Undef, ((V)((bx_2212 - 6D))), ((V)(4D)), ((V)((-6D))))).Spread(Call(apple_2213, V.Undef, ((V)((bx_2212 + 2D))), ((V)(4D)), ((V)((-8D))), ((V)("#9fcf4a")))).Spread(Call(apple_2213, V.Undef, ((V)((bx_2212 - 9D))), ((V)(4D)), ((V)(4D)), ((V)("#d9363b")))).Spread(Call(orange_2214, V.Undef, ((V)((bx_2212 + 7D))), ((V)(4D)), ((V)(6D)))).Spread(Call(apple_2213, V.Undef, ((V)((bx_2212 + 1D))), ((V)(13D)), ((V)(0D)), ((V)("#c42a30")))).V);
Invoke(o_2210, "push", Call(arcW_18, V.Undef, ((V)((bx_2212 + 3D))), ((V)(17D)), ((V)(4D)), ((V)(12D)), ((V)(12D)), ((V)(3.4)), ((V)(3.8)), ((V)((PI_32 * 1.12))), ((V)((PI_32 * 1.88))), ((V)("#f6d24a")), NewObj(1).Put("n", ((V)(8D))).V), Call(arcW_18, V.Undef, ((V)((bx_2212 + 3D))), ((V)(20D)), ((V)(2D)), ((V)(12D)), ((V)(12D)), ((V)(3.4)), ((V)(3.8)), ((V)((PI_32 * 1.12))), ((V)((PI_32 * 1.88))), ((V)("#f2c94c")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_14, V.Undef, ((V)(((bx_2212 + 3D) + (FdLibm.Cos((PI_32 * 1.12)) * 10D)))), ((V)(18D)), ((V)((4D + (FdLibm.Sin((PI_32 * 1.12)) * 10D)))), ((V)(1.2)), ((V)(5D)), ((V)("#6b4a20")), NewObj(1).Put("n", ((V)(6D))).V));
Call(rep_36, V.Undef, ((V)(10D)), Fn((V _arrowThis2253, int _argc2246, V i_2252, V _a2249, V _a2250, V _a2251, V[] _rest2247) => {
return Invoke(o_2210, "push", Call(ball_15, V.Undef, ((V)((((bx_2212 + 14D) + ((ToNum(i_2252) % 3D) * 3D)) - 3D))), ((V)(((12D + (System.Math.Floor((ToNum(i_2252) / 3D)) * 3.2)) - (GtN(i_2252, 8D) ? 1D : 0D)))), ((V)(((-2D) + ((ToNum(i_2252) % 2D) * 2.6)))), ((V)(2.3)), ((V)((NumTruthy((ToNum(i_2252) % 2D)) ? "#6b3a8a" : "#7d4a9a"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_2210, "push", Call(ball_15, V.Undef, ((V)((bx_2212 - 15D))), ((V)(10D)), ((V)(4D)), ((V)(5D)), ((V)("#c9d84a")), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V), Call(ball_15, V.Undef, ((V)((bx_2212 - 15D))), ((V)(18D)), ((V)(4D)), ((V)(3.4)), ((V)("#c9d84a")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(cyl_14, V.Undef, ((V)((bx_2212 - 15D))), ((V)(24.4)), ((V)(4D)), ((V)(0.5)), ((V)(3D)), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(4D))).V));
jx_2215 = 28D;
Invoke(o_2210, "push", Call(cyl_14, V.Undef, ((V)(jx_2215)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(2D)), ((V)("#e9e3d6")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V));
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis2261, int _argc2254, V i_2260, V _a2257, V _a2258, V _a2259, V[] _rest2255) => {
double y_2262 = 0;
double x_2263 = 0;
y_2262 = (2D + (ToNum(i_2260) * 4.2));
x_2263 = (jx_2215 + (NumTruthy((ToNum(i_2260) % 2D)) ? 1.5 : (-1.5)));
InvokeSpread(o_2210, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(x_2263)), ((V)(y_2262)), ((V)(((ToNum(i_2260) % 3D) - 1D))), ((V)(9.6)), ((V)(3.4)), ((V)((((ToNum(i_2260) % 3D) == 2D) ? "#7a4a28" : "#d8a060"))), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("paint"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(1.7)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.4)), ((V)(0D)), ((V)(0.94))))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2271, int _argc2264, V j_2270, V _a2267, V _a2268, V _a2269, V[] _rest2265) => {
return Call(ball_15, V.Undef, ((V)((x_2263 + (FdLibm.Cos(((ToNum(i_2260) * 2D) + (ToNum(j_2270) * 2.1))) * 5D)))), ((V)((y_2262 + 2.9))), ((V)((((ToNum(i_2260) % 3D) - 1D) + (FdLibm.Sin(((ToNum(i_2260) * 2D) + (ToNum(j_2270) * 2.1))) * 5D)))), ((V)(1.1)), ((V)((((ToNum(i_2260) % 3D) == 2D) ? "#f4e2b8" : "#3a2010"))), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V);
}, 1, "", true))).V);
return default;
}, 1, "", true));
InvokeSpread(o_2210, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(jx_2215)), ((V)(2D)), ((V)(0D)), ((V)(12.6)), ((V)(30D)), GL_31, NewObj(4).Put("n", ((V)(18D))).Put("op", ((V)(0.16))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.8))))).V)).Add(Call(cyl_14, V.Undef, ((V)(jx_2215)), ((V)(32D)), ((V)(0D)), ((V)(10.6)), ((V)(4D)), ((V)("#efe7d8")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V)).Add(Call(ball_15, V.Undef, ((V)(jx_2215)), ((V)(36D)), ((V)(0D)), ((V)(3.4)), ((V)("#efe7d8")), NewObj(1).Put("k", ((V)(4D))).V)).Add(Call(cyl_14, V.Undef, ((V)((jx_2215 + 6D))), ((V)(0D)), ((V)(16D)), ((V)(8D)), ((V)(3D)), ((V)("#d8a060")), NewObj(1).Put("n", ((V)(16D))).V)).Spread(Invoke(Arr(Arr(((V)(3D)), ((V)(14D))), Arr(((V)(8D)), ((V)(18D))), Arr(((V)(9D)), ((V)(13D)))), "map", Fn((V _arrowThis2283, int _argc2272, V _a2274, V _a2275, V _a2276, V _a2277, V[] _rest2273) => {
V x_2280 = default;
V z_2282 = default;
{ V _t2278 = ListOf(_a2274);
{ V _t2279 = GetIdx(_t2278, 0D);
x_2280 = _t2279; }
{ V _t2281 = GetIdx(_t2278, 1D);
z_2282 = _t2281; }
}
return Call(ball_15, V.Undef, Add(((V)(jx_2215)), x_2280), ((V)(2.6)), z_2282, ((V)(1.1)), ((V)("#3a2010")), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V);
}, 1, "", true))).V);
return o_2210;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "cookieJar", Fn((V _arrowThis2291, int _argc2284, V S_2290, V _a2287, V _a2288, V _a2289, V[] _rest2285) => {
return NewObj(3).Put("w", ((V)(74D))).Put("d", ((V)(52D))).Put("build", Fn((V _arrowThis2299, int _argc2292, V P_2298, V _a2295, V _a2296, V _a2297, V[] _rest2293) => {
V o_2300 = default;
o_2300 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(68D)), ((V)(1.2)), ((V)(48D)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)(0D)), ((V)(66D)), ((V)(3.2)), ((V)(46D)), ((V)("#efebe5")), NewObj(2).Put("r", ((V)(6D))).Put("mat", ((V)("cer"))).V));
Call(rep_36, V.Undef, ((V)(8D)), Fn((V _arrowThis2308, int _argc2301, V i_2307, V _a2304, V _a2305, V _a2306, V[] _rest2302) => {
double y_2309 = 0;
double x_2310 = 0;
V ck_2311 = default;
y_2309 = (4.4 + (ToNum(i_2307) * 3.8));
x_2310 = (NumTruthy((ToNum(i_2307) % 2D)) ? 1.6 : (-1.6));
ck_2311 = ((V)((((ToNum(i_2307) % 4D) == 3D) ? "#7a4a28" : "#d8a060")));
InvokeSpread(o_2300, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(x_2310)), ((V)(y_2309)), ((V)(((ToNum(i_2307) % 3D) - 1D))), ((V)(12D)), ((V)(3.2)), ck_2311, NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("paint"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(1.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.2)), ((V)(0D)), ((V)(0.94))))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis2319, int _argc2312, V j_2318, V _a2315, V _a2316, V _a2317, V[] _rest2313) => {
return Call(ball_15, V.Undef, ((V)((x_2310 + (FdLibm.Cos(((ToNum(i_2307) * 1.7) + (ToNum(j_2318) * 1.6))) * 6.4)))), ((V)((y_2309 + 2.7))), ((V)((((ToNum(i_2307) % 3D) - 1D) + (FdLibm.Sin(((ToNum(i_2307) * 1.7) + (ToNum(j_2318) * 1.6))) * 6.4)))), ((V)(1.3)), ((V)((SEqS(ck_2311, "#7a4a28") ? "#f4e2b8" : "#3a2010"))), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V);
}, 1, "", true))).V);
return default;
}, 1, "", true));
InvokeSpread(o_2300, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4.4)), ((V)(0D)), ((V)(22D)), ((V)(40D)), GL_31, NewObj(4).Put("n", ((V)(22D))).Put("op", ((V)(0.16))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(36D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(40D)), ((V)(0D)), ((V)(0.12))))).V)).Add(Call(ball_15, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)(3.6)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("k", ((V)(4D))).V))).Add(Call(cyl_14, V.Undef, ((V)(22D)), ((V)(4.4)), ((V)(16D)), ((V)(8.6)), ((V)(3D)), ((V)("#d8a060")), NewObj(1).Put("n", ((V)(16D))).V)).Spread(Invoke(Arr(Arr(((V)(19D)), ((V)(14D))), Arr(((V)(24D)), ((V)(19D))), Arr(((V)(25D)), ((V)(13D)))), "map", Fn((V _arrowThis2331, int _argc2320, V _a2322, V _a2323, V _a2324, V _a2325, V[] _rest2321) => {
V x_2328 = default;
V z_2330 = default;
{ V _t2326 = ListOf(_a2322);
{ V _t2327 = GetIdx(_t2326, 0D);
x_2328 = _t2327; }
{ V _t2329 = GetIdx(_t2326, 1D);
z_2330 = _t2329; }
}
return Call(ball_15, V.Undef, x_2328, ((V)(7D)), z_2330, ((V)(1.2)), ((V)("#3a2010")), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V);
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)((-22D))), ((V)(4.4)), ((V)(16D)), ((V)(8.6)), ((V)(3D)), ((V)("#7a4a28")), NewObj(1).Put("n", ((V)(16D))).V)).Spread(Invoke(Arr(Arr(((V)((-24D))), ((V)(14D))), Arr(((V)((-19D))), ((V)(18D)))), "map", Fn((V _arrowThis2343, int _argc2332, V _a2334, V _a2335, V _a2336, V _a2337, V[] _rest2333) => {
V x_2340 = default;
V z_2342 = default;
{ V _t2338 = ListOf(_a2334);
{ V _t2339 = GetIdx(_t2338, 0D);
x_2340 = _t2339; }
{ V _t2341 = GetIdx(_t2338, 1D);
z_2342 = _t2341; }
}
return Call(ball_15, V.Undef, x_2340, ((V)(7D)), z_2342, ((V)(1.2)), ((V)("#f4e2b8")), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V);
}, 1, "", true))).V);
return o_2300;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "luxCounter", Fn((V _arrowThis2351, int _argc2344, V S_2350, V _a2347, V _a2348, V _a2349, V[] _rest2345) => {
V nm_2352 = default;
V obs_2353 = default;
V shp_2354 = default;
V top_2355 = default;
V vein_2356 = default;
V cab_2357 = default;
V hw_2358 = default;
double TH_2359 = 0;
V SEG_2360 = default;
V xs_2361 = default;
V zs_2362 = default;
double W_2363 = 0;
double D_2364 = 0;
V R_2365 = default;
V lift_2366 = default;
nm_2352 = Get(S_2350, "nm");
obs_2353 = Invoke(NewRegExp(RX28, "obsidian", ""), "test", nm_2352);
shp_2354 = (Get(S_2350, "shape") is var _t2367 && Truthy(_t2367) ? _t2367 : ((V)("L")));
top_2355 = ((V)((Truthy(obs_2353) ? "#25222a" : "#f4f1ec")));
vein_2356 = (Truthy(obs_2353) ? GOLD_28 : ((V)("#c9c1b5")));
cab_2357 = ((V)((Truthy(obs_2353) ? "#2e3138" : (Truthy(Invoke(NewRegExp(RX29, "navy", ""), "test", nm_2352)) ? "#22324a" : "#1f4f3e"))));
hw_2358 = GOLD_28;
TH_2359 = 59.2;
SEG_2360 = (SEqS(shp_2354, "U") ? Arr(Arr(((V)((-112D))), ((V)(112D)), ((V)((-68D))), ((V)((-16D)))), Arr(((V)((-164D))), ((V)((-112D))), ((V)((-68D))), ((V)(78D))), Arr(((V)(112D)), ((V)(164D)), ((V)((-68D))), ((V)(78D)))) : (SEqS(shp_2354, "L") ? Arr(Arr(((V)((-70D))), ((V)(120D)), ((V)((-68D))), ((V)((-16D)))), Arr(((V)((-122D))), ((V)((-70D))), ((V)((-68D))), ((V)(86D)))) : Arr(Arr(((V)((-92D))), ((V)(92D)), ((V)((-38D))), ((V)(38D))))));
xs_2361 = Invoke(SEG_2360, "flatMap", Fn((V _arrowThis2375, int _argc2368, V s_2374, V _a2371, V _a2372, V _a2373, V[] _rest2369) => {
return Arr(GetIdx(s_2374, 0D), GetIdx(s_2374, 1D));
}, 1, "", true));
zs_2362 = Invoke(SEG_2360, "flatMap", Fn((V _arrowThis2383, int _argc2376, V s_2382, V _a2379, V _a2380, V _a2381, V[] _rest2377) => {
return Arr(GetIdx(s_2382, 2D), GetIdx(s_2382, 3D));
}, 1, "", true));
W_2363 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2361).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2361).V)));
D_2364 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(zs_2362).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(zs_2362).V)));
R_2365 = Call(rng_55, V.Undef, nm_2352);
lift_2366 = (Truthy(Get(S_2350, "lift")) ? Arr(NewObj(3).Put("build", Fn((V _arrowThis2390, int _argc2384, V _a2386, V _a2387, V _a2388, V _a2389, V[] _rest2385) => {
V o_2391 = default;
o_2391 = Arr(Call(box_12, V.Undef, ((V)((-10D))), ((V)(TH_2359)), ((V)((-60D))), ((V)(120D)), ((V)(46D)), ((V)(14D)), cab_2357, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)((Truthy(obs_2353) ? "paint" : "wood")))).V), Call(box_12, V.Undef, ((V)((-10D))), ((V)((TH_2359 + 46D))), ((V)((-60D))), ((V)(124D)), ((V)(3D)), ((V)(16D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(((V)((-50D))), ((V)((-10D))), ((V)(30D))), "forEach", Fn((V _arrowThis2399, int _argc2392, V x_2398, V _a2395, V _a2396, V _a2397, V[] _rest2393) => {
return Invoke(o_2391, "push", Call(slab_16, V.Undef, x_2398, ((V)((TH_2359 + 4D))), ((V)((-52.6))), ((V)(36D)), ((V)(38D)), ((V)(0.8)), ((V)("#cfe8f2")), NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.6))).V), Call(box_12, V.Undef, Add(x_2398, ((V)(15D))), ((V)((TH_2359 + 14D))), ((V)((-51.6))), ((V)(1.6)), ((V)(12D)), ((V)(1.6)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
return o_2391;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis2408, int _argc2400, V p_2406, V s_2407, V _a2404, V _a2405, V[] _rest2401) => {
return Call(about_40, V.Undef, Call(p_2406, V.Undef, ((V)((-10D))), ((V)(TH_2359)), ((V)((-60D)))), Call(at_38, V.Undef, ((V)("scale")), ((V)("1 0.04;1 1;1 1;1 0.04")), ((V)(8D)), ((V)(0D)), ((V)("0;0.25;0.75;1"))), s_2407);
}, 2, "wrap", true)).Put("back", ((V)(1D))).V) : V.Null);
return NewObj(8).Put("w", ((V)(W_2363))).Put("d", ((V)(D_2364))).Put("topH", ((V)(TH_2359))).Put("topZ", ((V)((SEqS(shp_2354, "I") ? 0D : (-42D))))).Put("topW", ((V)((SEqS(shp_2354, "I") ? 120D : 110D)))).Put("layers", lift_2366).Put("build", Fn((V _arrowThis2416, int _argc2409, V P_2415, V _a2412, V _a2413, V _a2414, V[] _rest2410) => {
V o_2417 = default;
o_2417 = Arr();
Invoke(SEG_2360, "forEach", Fn((V _arrowThis2434, int _argc2418, V _a2420, V si_2424, V _a2422, V _a2423, V[] _rest2419) => {
double cx_2435 = 0;
double cz_2436 = 0;
double w_2437 = 0;
double d_2438 = 0;
V leg_2439 = default;
V door_2440 = default;
V x0_2427 = default;
V x1_2429 = default;
V z0_2431 = default;
V z1_2433 = default;
{ V _t2425 = ListOf(_a2420);
{ V _t2426 = GetIdx(_t2425, 0D);
x0_2427 = _t2426; }
{ V _t2428 = GetIdx(_t2425, 1D);
x1_2429 = _t2428; }
{ V _t2430 = GetIdx(_t2425, 2D);
z0_2431 = _t2430; }
{ V _t2432 = GetIdx(_t2425, 3D);
z1_2433 = _t2432; }
}
cx_2435 = (ToNum(Add(x0_2427, x1_2429)) / 2D);
cz_2436 = (ToNum(Add(z0_2431, z1_2433)) / 2D);
w_2437 = (ToNum(x1_2429) - ToNum(x0_2427));
d_2438 = (ToNum(z1_2433) - ToNum(z0_2431));
leg_2439 = ((d_2438 > 80D) ? V.True : V.False);
Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)(cx_2435)), ((V)(0D)), ((V)(cz_2436)), ((V)((w_2437 - 6D))), ((V)(6D)), ((V)((d_2438 - 6D))), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(cx_2435)), ((V)(6D)), ((V)(cz_2436)), ((V)(w_2437)), ((V)(47.4)), ((V)(d_2438)), cab_2357, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)((Truthy(obs_2353) ? "paint" : "wood")))).V), Call(box_12, V.Undef, ((V)(cx_2435)), ((V)(53.4)), ((V)(cz_2436)), ((V)((w_2437 + 5D))), ((V)(1.4)), ((V)((d_2438 + 5D))), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(cx_2435)), ((V)(54.8)), ((V)(cz_2436)), ((V)((w_2437 + 4D))), ((V)(4.4)), ((V)((d_2438 + 4D))), top_2355, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("cer"))).V));
Call(rep_36, V.Undef, ((V)(5D)), Fn((V _arrowThis2447, int _argc2441, V _a2443, V _a2444, V _a2445, V _a2446, V[] _rest2442) => {
return Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)((cx_2435 + (((ToNum(Call(R_2365, V.Undef)) - 0.5) * w_2437) * 0.8)))), ((V)((TH_2359 + 0.05))), ((V)((cz_2436 + (((ToNum(Call(R_2365, V.Undef)) - 0.5) * d_2438) * 0.7)))), ((V)((26D + (ToNum(Call(R_2365, V.Undef)) * 30D)))), ((V)(0.15)), ((V)(0.9)), vein_2356, NewObj(3).Put("yaw", ((V)(((ToNum(Call(R_2365, V.Undef)) - 0.5) * 1.6)))).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
door_2440 = Fn((V _arrowThis2457, int _argc2448, V x_2454, V z_2455, V ax_2456, V _a2453, V[] _rest2449) => {
if (SEqS(ax_2456, "z")) {
Invoke(o_2417, "push", Call(slab_16, V.Undef, x_2454, ((V)(10D)), Add(z_2455, ((V)(0.3))), ((V)(34D)), ((V)(40D)), ((V)(1D)), Call(shade_22, V.Undef, cab_2357, ((V)(1.12))), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)((Truthy(obs_2353) ? "paint" : "wood")))).V));
Invoke(Arr(((V)((-8D))), ((V)(0D)), ((V)(8D))), "forEach", Fn((V _arrowThis2465, int _argc2458, V t_2464, V _a2461, V _a2462, V _a2463, V[] _rest2459) => {
return Invoke(o_2417, "push", Call(slab_16, V.Undef, Add(x_2454, t_2464), ((V)(13D)), Add(z_2455, ((V)(1.4))), ((V)(1.2)), ((V)(34D)), ((V)(0.6)), Call(shade_22, V.Undef, cab_2357, ((V)(0.82))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_2417, "push", Call(box_12, V.Undef, Add(x_2454, ((V)(13D))), ((V)(26D)), Add(z_2455, ((V)(2.2))), ((V)(2D)), ((V)(14D)), ((V)(2D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
Invoke(o_2417, "push", Call(slabX_17, V.Undef, Add(x_2454, ((V)(0.3))), ((V)(10D)), z_2455, ((V)(1D)), ((V)(40D)), ((V)(34D)), Call(shade_22, V.Undef, cab_2357, ((V)(1.12))), NewObj(1).Put("r", ((V)(2D))).V));
Invoke(Arr(((V)((-8D))), ((V)(0D)), ((V)(8D))), "forEach", Fn((V _arrowThis2473, int _argc2466, V t_2472, V _a2469, V _a2470, V _a2471, V[] _rest2467) => {
return Invoke(o_2417, "push", Call(slabX_17, V.Undef, Add(x_2454, ((V)(1.4))), ((V)(13D)), Add(z_2455, t_2472), ((V)(0.6)), ((V)(34D)), ((V)(1.2)), Call(shade_22, V.Undef, cab_2357, ((V)(0.82))), NewObj(1).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_2417, "push", Call(box_12, V.Undef, Add(x_2454, ((V)(2.2))), ((V)(26D)), ((V)((ToNum(z_2455) - 13D))), ((V)(2D)), ((V)(14D)), ((V)(2D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}
return default;
}, 3, "", true);
if (!(Truthy(leg_2439))) {
double n_2474 = 0;
double pw_2475 = 0;
n_2474 = Round((w_2437 / 38D));
pw_2475 = (w_2437 / n_2474);
Call(rep_36, V.Undef, ((V)(n_2474)), Fn((V _arrowThis2483, int _argc2476, V i_2482, V _a2479, V _a2480, V _a2481, V[] _rest2477) => {
V x_2484 = default;
x_2484 = Add(x0_2427, ((V)((pw_2475 * ToNum(Add(i_2482, ((V)(0.5))))))));
if (Truthy(Invoke(SEG_2360, "some", Fn((V _arrowThis2493, int _argc2485, V s_2491, V j_2492, V _a2489, V _a2490, V[] _rest2486) => {
return (((!SEq(j_2492, si_2424) && GtN(x_2484, (ToNum(GetIdx(s_2491, 0D)) - 4D))) && Lt(x_2484, Add(GetIdx(s_2491, 1D), ((V)(4D))))) ? V.True : V.False);
}, 2, "", true)))) {
return default;
}
Call(door_2440, V.Undef, x_2484, z1_2433, ((V)("z")));
return default;
}, 1, "", true));
} else {
if (LtN(x0_2427, 0D)) {
double n_2494 = 0;
double pz_2495 = 0;
n_2494 = Round((ToNum(Add(z1_2433, ((V)(16D)))) / 38D));
pz_2495 = (ToNum(Add(z1_2433, ((V)(16D)))) / n_2494);
Call(rep_36, V.Undef, ((V)(n_2494)), Fn((V _arrowThis2503, int _argc2496, V i_2502, V _a2499, V _a2500, V _a2501, V[] _rest2497) => {
return Call(door_2440, V.Undef, x1_2429, ((V)(((-16D) + (pz_2495 * ToNum(Add(i_2502, ((V)(0.5)))))))), ((V)("x")));
}, 1, "", true));
}
Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)(cx_2435)), ((V)(0D)), Add(z1_2433, ((V)(2.4))), ((V)((w_2437 + 4D))), ((V)(TH_2359)), ((V)(4.8)), top_2355, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("cer"))).V));
}
if (SEqS(shp_2354, "I")) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2511, int _argc2504, V sg_2510, V _a2507, V _a2508, V _a2509, V[] _rest2505) => {
return Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2510) * ((w_2437 / 2D) + 2.4)))), ((V)(0D)), ((V)(cz_2436)), ((V)(4.8)), ((V)(TH_2359)), ((V)((d_2438 + 4D))), top_2355, NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("cer"))).V));
}, 1, "", true));
}
return default;
}, 2, "", true));
if (Truthy(Get(S_2350, "sink"))) {
double sx_2512 = 0;
sx_2512 = 30D;
Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)(sx_2512)), ((V)((TH_2359 - 0.6))), ((V)((-44D))), ((V)(46D)), ((V)(0.8)), ((V)(28D)), ((V)("#16181c")), NewObj(1).Put("r", ((V)(5D))).V), Call(box_12, V.Undef, ((V)(sx_2512)), ((V)((TH_2359 - 0.2))), ((V)((-44D))), ((V)(40D)), ((V)(0.5)), ((V)(22D)), ((V)("#7ad8ff")), Call(em_26, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.75))).V)), Call(cyl_14, V.Undef, ((V)(sx_2512)), ((V)(TH_2359)), ((V)((-61D))), ((V)(2.2)), ((V)(26D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("x"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)((-52D))), ((V)((TH_2359 + 24D))))).Put("a", ((V)(9D))).Put("b", ((V)(9D))).Put("th", ((V)(2.2))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_32))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((sx_2512 - 1.1))), ((V)(0D))), Arr(((V)((sx_2512 + 1.1))), ((V)(0D))))).Put("col", hw_2358).Put("mat", ((V)("metal"))).V), Call(cyl_14, V.Undef, ((V)(sx_2512)), ((V)((TH_2359 + 19D))), ((V)((-43D))), ((V)(1.6)), ((V)(5D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_14, V.Undef, ((V)((sx_2512 + 14D))), ((V)(TH_2359)), ((V)((-60D))), ((V)(1.8)), ((V)(14D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_15, V.Undef, ((V)((sx_2512 + 14D))), ((V)((TH_2359 + 14D))), ((V)((-60D))), ((V)(2.4)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}
if (Truthy(Get(S_2350, "prep"))) {
Invoke(o_2417, "push", Call(box_12, V.Undef, ((V)(46D)), ((V)((TH_2359 - 0.4))), ((V)(0D)), ((V)(26D)), ((V)(0.8)), ((V)(22D)), ((V)("#16181c")), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_14, V.Undef, ((V)(46D)), ((V)(TH_2359)), ((V)((-16D))), ((V)(1.8)), ((V)(20D)), hw_2358, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("x"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)((-9D))), ((V)((TH_2359 + 18D))))).Put("a", ((V)(7D))).Put("b", ((V)(7D))).Put("th", ((V)(1.8))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_32))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)(45D)), ((V)(0D))), Arr(((V)(47D)), ((V)(0D))))).Put("col", hw_2358).Put("mat", ((V)("metal"))).V), Call(cyl_14, V.Undef, ((V)((-30D))), ((V)(TH_2359)), ((V)(4D)), ((V)(14D)), ((V)(8D)), ((V)("#f4f1ec")), NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).V), Call(ball_15, V.Undef, ((V)((-34D))), ((V)((TH_2359 + 6D))), ((V)(2D)), ((V)(4D)), ((V)("#d9363b"))), Call(ball_15, V.Undef, ((V)((-26D))), ((V)((TH_2359 + 6D))), ((V)(6D)), ((V)(4D)), ((V)("#f2932c"))));
}
if (Truthy(Get(S_2350, "tep"))) {
InvokeSpread(o_2417, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)((-30D))), ((V)((TH_2359 + 0.4))), ((V)(0D)), ((V)(76D)), ((V)(1.8)), ((V)(50D)), ((V)("#a8b0b6")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(Arr(((V)((-44D))), ((V)((-8D)))), Arr(((V)((-36D))), ((V)(8D))), Arr(((V)((-22D))), ((V)((-4D)))), Arr(((V)((-16D))), ((V)(10D)))), "map", Fn((V _arrowThis2525, int _argc2513, V _a2515, V i_2519, V _a2517, V _a2518, V[] _rest2514) => {
V x_2522 = default;
V z_2524 = default;
{ V _t2520 = ListOf(_a2515);
{ V _t2521 = GetIdx(_t2520, 0D);
x_2522 = _t2521; }
{ V _t2523 = GetIdx(_t2520, 1D);
z_2524 = _t2523; }
}
return Call(arcW_18, V.Undef, x_2522, ((V)((TH_2359 + 2.2))), z_2524, ((V)(4D)), ((V)(4D)), ((V)(1.8)), ((V)(2.2)), ((V)(0D)), ((V)((PI_32 * 1.5))), ((V)("#f2935a")), NewObj(1).Put("n", ((V)(6D))).V);
}, 2, "", true))).Add(Call(ball_15, V.Undef, ((V)((-28D))), ((V)((TH_2359 + 1.8))), ((V)((-12D))), ((V)(3D)), ((V)("#6aa65a")), NewObj(1).Put("sy", ((V)(0.6))).V)).Add(Call(box_12, V.Undef, ((V)(50D)), ((V)(TH_2359)), ((V)(8D)), ((V)(28D)), ((V)(1.6)), ((V)(24D)), ((V)("#16181c")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V))).Add(Call(box_12, V.Undef, ((V)(50D)), ((V)((TH_2359 + 1.6))), ((V)(8D)), ((V)(20D)), ((V)(0.4)), ((V)(16D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.5))).V))).V);
}
return o_2417;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2533, int _argc2526, V c_2532, V _a2529, V _a2530, V _a2531, V[] _rest2527) => {
JsStrBuf f_2534 = null;
f_2534 = new JsStrBuf("");
if (Truthy(Get(S_2350, "sink"))) {
f_2534.S("<g transform=\"").V(Call(planeH_45, V.Undef, Get(c_2532, "p"), ((V)((TH_2359 + 0.4))))).S(" translate(30 -44)\">").V(Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis2542, int _argc2535, V i_2541, V _a2538, V _a2539, V _a2540, V[] _rest2536) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"2\" ry=\"2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\">").V(Call(an_37, V.Undef, ((V)("rx")), ((V)("2;16")), ((V)(1.8)), ((V)(((-ToNum(i_2541)) * 0.6))))).V(Call(an_37, V.Undef, ((V)("ry")), ((V)("2;9")), ((V)(1.8)), ((V)(((-ToNum(i_2541)) * 0.6))))).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0")), ((V)(1.8)), ((V)(((-ToNum(i_2541)) * 0.6))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").V(Call(steam_49, V.Undef, c_2532, ((V)(44D)), ((V)((TH_2359 + 16D))), ((V)((-60D))), ((V)(0.6)), ((V)(2D))));
}
if (Truthy(Get(S_2350, "tep"))) {
f_2534.V(Call(steam_49, V.Undef, c_2532, ((V)((-36D))), ((V)((TH_2359 + 4D))), ((V)(0D)), ((V)(0.9)), ((V)(4D)))).S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_2532, "p"), ((V)(20.4)), ((V)((TH_2359 + 1.4))))).S(" translate(50 0)\"><text x=\"0\" y=\"0\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3\" fill=\"#8fe8ff\">").S("0.42 kg").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.4;1")), ((V)(1.2)))).S("</text></g>");
}
if (Truthy(Get(S_2350, "lift"))) {
f_2534.V(Invoke(Call(rep_36, V.Undef, ((V)(3D)), Fn((V _arrowThis2550, int _argc2543, V i_2549, V _a2546, V _a2547, V _a2548, V[] _rest2544) => {
return Call(spark_51, V.Undef, c_2532, ((V)(((-40D) + (ToNum(i_2549) * 30D)))), ((V)((TH_2359 + 50D))), ((V)((-52D))), ((V)(0.7)), ((V)(((-ToNum(i_2549)) * 0.6))), ((V)("#ffe9a0")));
}, 1, "", true)), "join", ((V)(""))));
}
return NewObj(1).Put("front", ((V)(f_2534.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "robotCart", Fn((V _arrowThis2558, int _argc2551, V S_2557, V _a2554, V _a2555, V _a2556, V[] _rest2552) => {
return NewObj(8).Put("w", ((V)(56D))).Put("d", ((V)(42D))).Put("roam", ((V)(1D))).Put("pad", Arr(((V)(44D)), ((V)(6D)), ((V)(44D)), ((V)(0D)))).Put("wrap", Fn((V _arrowThis2567, int _argc2559, V p_2565, V s_2566, V _a2563, V _a2564, V[] _rest2560) => {
V v_2568 = default;
V o_2569 = default;
V dx_2570 = default;
V dy_2571 = default;
v_2568 = Call(p_2565, V.Undef, ((V)(36D)), ((V)(0D)), ((V)(0D)));
o_2569 = Call(p_2565, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dx_2570 = Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(v_2568, 0D)) - ToNum(GetIdx(o_2569, 0D))))));
dy_2571 = Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(v_2568, 1D)) - ToNum(GetIdx(o_2569, 1D))))));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_38, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("-").V(dx_2570).S(" -").V(dy_2571).S(";").V(dx_2570).S(" ").V(dy_2571).S(";").V(dx_2570).S(" ").V(dy_2571).S(";-").V(dx_2570).S(" -").V(dy_2571).S(";-").V(dx_2570).S(" -").V(dy_2571).End())), ((V)(8D)), ((V)(0D)), ((V)("0;0.42;0.5;0.92;1")))).V(s_2566).S("</g>").End()));
return default;
}, 2, "wrap", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis2578, int _argc2572, V _a2574, V _a2575, V _a2576, V _a2577, V[] _rest2573) => {
return Arr(Call(ball_15, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-6D))), ((V)(13D)), ((V)("#f1eee8")), NewObj(4).Put("sy", ((V)(0.8))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(4.4)), ((V)(18D)), ((V)(9D)), ((V)(1D)), ((V)("#1d2030")), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(78D)), ((V)((-6D))), ((V)(0.6)), ((V)(7D)), ((V)("#9aa3a8")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(84D)), ((V)((-6D))), ((V)(1.8)), ((V)("#8fe8ff")), Call(em_26, V.Undef)));
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis2587, int _argc2579, V p_2585, V s_2586, V _a2583, V _a2584, V[] _rest2580) => {
return Call(about_40, V.Undef, Call(p_2585, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-6D)))), Call(at_38, V.Undef, ((V)("rotate")), ((V)("-6;6;-6")), ((V)(3D))), s_2586);
}, 2, "wrap", true)).V)).Put("build", Fn((V _arrowThis2595, int _argc2588, V P_2594, V _a2591, V _a2592, V _a2593, V[] _rest2589) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(46D)), ((V)(10D)), ((V)(34D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(8D))).V))).Spread(Invoke(Arr(Arr(((V)((-18D))), ((V)((-13D)))), Arr(((V)(18D)), ((V)((-13D)))), Arr(((V)((-18D))), ((V)(13D))), Arr(((V)(18D)), ((V)(13D)))), "map", Fn((V _arrowThis2607, int _argc2596, V _a2598, V _a2599, V _a2600, V _a2601, V[] _rest2597) => {
V x_2604 = default;
V z_2606 = default;
{ V _t2602 = ListOf(_a2598);
{ V _t2603 = GetIdx(_t2602, 0D);
x_2604 = _t2603; }
{ V _t2605 = GetIdx(_t2602, 1D);
z_2606 = _t2605; }
}
return Call(ball_15, V.Undef, x_2604, ((V)(0D)), z_2606, ((V)(5D)), ((V)("#1d1d20")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V);
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(16D)), ((V)((-6D))), ((V)(9D)), ((V)(42D)), ((V)("#f1eee8")), NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V)).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(6D)), ((V)(44D)), ((V)(2.4)), ((V)(30D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(6D)), ((V)(40D)), ((V)(2.4)), ((V)(28D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V))).Add(Call(cyl_14, V.Undef, ((V)((-10D))), ((V)(32.4)), ((V)(8D)), ((V)(7D)), ((V)(1.2)), WH_30, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V)).Add(Call(ball_15, V.Undef, ((V)((-10D))), ((V)(33.4)), ((V)(8D)), ((V)(3.6)), ((V)("#e88a3a")), NewObj(1).Put("sy", ((V)(0.6))).V)).Add(Call(cyl_14, V.Undef, ((V)(10D)), ((V)(32.4)), ((V)(6D)), ((V)(6D)), ((V)(1.2)), WH_30, NewObj(1).Put("n", ((V)(14D))).V)).Add(Call(ball_15, V.Undef, ((V)(10D)), ((V)(33.4)), ((V)(6D)), ((V)(3D)), ((V)("#6aa65a")), NewObj(1).Put("sy", ((V)(0.6))).V)).Add(Call(cyl_14, V.Undef, ((V)((-8D))), ((V)(48.4)), ((V)(6D)), ((V)(3.2)), ((V)(7D)), ((V)("#cfe8f2")), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.8))).V)).Add(Call(cyl_14, V.Undef, ((V)(8D)), ((V)(48.4)), ((V)(8D)), ((V)(3.2)), ((V)(7D)), ((V)("#cfe8f2")), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.8))).V)).Add(Call(box_12, V.Undef, ((V)((-22D))), ((V)(36D)), ((V)(6D)), ((V)(3D)), ((V)(14D)), ((V)(3D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef))).Add(Call(box_12, V.Undef, ((V)(22D)), ((V)(36D)), ((V)(6D)), ((V)(3D)), ((V)(14D)), ((V)(3D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef))).Add(Call(slabX_17, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(17.4)), ((V)(30D)), ((V)(2D)), ((V)(0.6)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).V;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2615, int _argc2608, V c_2614, V _a2611, V _a2612, V _a2613, V[] _rest2609) => {
V e_2616 = default;
V u_2617 = default;
e_2616 = Invoke(c_2614, "p", ((V)(0D)), ((V)(66.5)), ((V)(5.4)));
u_2617 = Get(c_2614, "k");
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_38, V.Undef, ((V)("translate")), ((V)("0 0;0 0")), ((V)(1D)))).V(Invoke(Invoke(Arr(((V)("-4.4")), ((V)("4.4"))), "map", Fn((V _arrowThis2625, int _argc2618, V x_2624, V _a2621, V _a2622, V _a2623, V[] _rest2619) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, Add(GetIdx(e_2616, 0D), ((V)(((ToNum(x_2624) * ToNum(u_2617)) * 0.866)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(e_2616, 1D), ((V)((((ToNum(x_2624) * ToNum(u_2617)) * 0.5) * ToNum(Get(X_9, "SA")))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_2617)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.8 * ToNum(u_2617)))))).S("\" fill=\"#8fe8ff\">").V(Call(an_37, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((1.8 * ToNum(u_2617)))))).S(";").V(Call(f1_23, V.Undef, ((V)((1.8 * ToNum(u_2617)))))).S(";").V(Call(f1_23, V.Undef, ((V)((0.2 * ToNum(u_2617)))))).S(";").V(Call(f1_23, V.Undef, ((V)((1.8 * ToNum(u_2617)))))).End())), ((V)(3.6)), ((V)(0D)), ((V)("0;0.9;0.95;1")))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "podSeat", Fn((V _arrowThis2633, int _argc2626, V S_2632, V _a2629, V _a2630, V _a2631, V[] _rest2627) => {
return NewObj(9).Put("w", ((V)(62D))).Put("d", ((V)(62D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(10D))).Put("h", ((V)(36D))).V)).Put("wrap", Fn((V _arrowThis2642, int _argc2634, V p_2640, V s_2641, V _a2638, V _a2639, V[] _rest2635) => {
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(bob_47, V.Undef, ((V)(5D)), ((V)(3D)))).V(s_2641).S("</g>").End()));
}, 2, "wrap", true)).Put("pad", Arr(((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(0D)))).Put("fx", Fn((V _arrowThis2650, int _argc2643, V c_2649, V _a2646, V _a2647, V _a2648, V[] _rest2644) => {
V q_2651 = default;
V u_2652 = default;
q_2651 = Invoke(c_2649, "p", ((V)(0D)), ((V)(0D)), ((V)(0D)));
u_2652 = Get(c_2649, "k");
return NewObj(1).Put("under", ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_2651, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_2651, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((24D * ToNum(u_2652)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((24D * ToNum(u_2652)) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"#8fe8ff\" opacity=\"0.35\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.2;0.5;0.2")), ((V)(3D)))).V(Call(an_37, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((22D * ToNum(u_2652)))))).S(";").V(Call(f1_23, V.Undef, ((V)((26D * ToNum(u_2652)))))).S(";").V(Call(f1_23, V.Undef, ((V)((22D * ToNum(u_2652)))))).End())), ((V)(3D)))).S("</ellipse>").End()))).V;
return default;
}, 1, "fx", true)).Put("build", Fn((V _arrowThis2660, int _argc2653, V P_2659, V _a2656, V _a2657, V _a2658, V[] _rest2654) => {
return Arr(Call(ball_15, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(26D)), ((V)("#f1eee8")), NewObj(4).Put("sy", ((V)(1.15))).Put("k", ((V)(8D))).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V), Call(disc_19, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(17.5)), ((V)(21D)), ((V)(8.6)), Call(shade_22, V.Undef, ((V)("#f1eee8")), ((V)(0.86)))), Call(disc_19, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(19D)), ((V)(18.6)), ((V)(8.4)), ((V)("#d9773f")), NewObj(1).Put("soft", ((V)(1D))).V), Call(disc_19, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(18.8)), ((V)(19.6)), ((V)(0.8)), ((V)("#ff9d4a")), Call(em_26, V.Undef, NewObj(1).Put("op", ((V)(0.6))).V)), Call(pillowY_20, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(16D)), ((V)(30D)), ((V)(8D)), ((V)(20D)), ((V)("#e8955a"))), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(10D)), ((V)(6D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(12D)), ((V)(1D)), ((V)("#8fe8ff")), Call(em_26, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "diningTable", Fn((V _arrowThis2668, int _argc2661, V S_2667, V _a2664, V _a2665, V _a2666, V[] _rest2662) => {
V n_2669 = default;
V round_2670 = default;
V marble_2671 = default;
V vein_2672 = default;
V wood_2673 = default;
double TH_2674 = 0;
double W_2675 = 0;
double Dd_2676 = 0;
V gold_2677 = default;
n_2669 = (Get(S_2667, "n") is var _t2678 && Truthy(_t2678) ? _t2678 : ((V)(6D)));
round_2670 = (!(!(Truthy(Get(S_2667, "round")))) ? V.True : V.False);
marble_2671 = (Get(S_2667, "top") is var _t2679 && Truthy(_t2679) ? _t2679 : ((V)("#f2efea")));
vein_2672 = (Get(S_2667, "vein") is var _t2680 && Truthy(_t2680) ? _t2680 : ((V)("#c9c1b5")));
wood_2673 = (Get(S_2667, "wood") is var _t2681 && Truthy(_t2681) ? _t2681 : ((V)("#6b4226")));
TH_2674 = 60D;
W_2675 = (Truthy(round_2670) ? 120D : (GeN(n_2669, 8D) ? 236D : 184D));
Dd_2676 = (Truthy(round_2670) ? 120D : 96D);
gold_2677 = Get(S_2667, "gold");
return NewObj(5).Put("w", ((V)((W_2675 + 16D)))).Put("d", ((V)((Dd_2676 + 16D)))).Put("topH", ((V)((TH_2674 + 5D)))).Put("topW", ((V)((W_2675 * 0.7)))).Put("build", Fn((V _arrowThis2689, int _argc2682, V P_2688, V _a2685, V _a2686, V _a2687, V[] _rest2683) => {
V o_2690 = default;
V R_2691 = default;
o_2690 = Arr();
if (Truthy(round_2670)) {
Invoke(o_2690, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(5D)), wood_2673, NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(10D)), ((V)((TH_2674 - 10D))), wood_2673, NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)((TH_2674 * 0.3))), ((V)(0D)), ((V)(0.8))), Arr(((V)((TH_2674 - 10D))), ((V)(0D)), ((V)(1.3))))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((TH_2674 - 5D))), ((V)(0D)), ((V)(52D)), ((V)(5D)), wood_2673, NewObj(2).Put("n", ((V)(26D))).Put("mat", ((V)("wood"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((TH_2674 - 0.6))), ((V)(0D)), ((V)(60.8)), ((V)(1.2)), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(TH_2674)), ((V)(0D)), ((V)(60D)), ((V)(5D)), marble_2671, NewObj(2).Put("n", ((V)(28D))).Put("mat", ((V)("cer"))).V));
} else {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2699, int _argc2692, V sg_2698, V _a2695, V _a2696, V _a2697, V[] _rest2693) => {
return Invoke(o_2690, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2698) * ((W_2675 / 2D) - 26D)))), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(5D)), ((V)((Dd_2676 - 20D))), wood_2673, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(box_12, V.Undef, ((V)((ToNum(sg_2698) * ((W_2675 / 2D) - 26D)))), ((V)(5D)), ((V)(0D)), ((V)(10D)), ((V)((TH_2674 - 11D))), ((V)(16D)), wood_2673, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(box_12, V.Undef, ((V)((ToNum(sg_2698) * ((W_2675 / 2D) - 26D)))), ((V)((TH_2674 - 9D))), ((V)(0D)), ((V)(14D)), ((V)(4D)), ((V)((Dd_2676 - 24D))), wood_2673, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
Invoke(o_2690, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)), ((V)((W_2675 - 60D))), ((V)(5D)), ((V)(5D)), wood_2673, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((TH_2674 - 6D))), ((V)(0D)), ((V)((W_2675 - 16D))), ((V)(6D)), ((V)((Dd_2676 - 16D))), wood_2673, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((TH_2674 - 0.6))), ((V)(0D)), ((V)((W_2675 + 1.4))), ((V)(1.2)), ((V)((Dd_2676 + 1.4))), GOLD_28, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(TH_2674)), ((V)(0D)), ((V)(W_2675)), ((V)(5D)), ((V)(Dd_2676)), marble_2671, NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V));
}
R_2691 = Call(rng_55, V.Undef, Get(S_2667, "nm"));
Call(rep_36, V.Undef, ((V)((Truthy(round_2670) ? 5D : 8D))), Fn((V _arrowThis2706, int _argc2700, V _a2702, V _a2703, V _a2704, V _a2705, V[] _rest2701) => {
return Invoke(o_2690, "push", Call(box_12, V.Undef, ((V)((((ToNum(Call(R_2691, V.Undef)) - 0.5) * W_2675) * (Truthy(round_2670) ? 0.6 : 0.8)))), ((V)((TH_2674 + 5.05))), ((V)((((ToNum(Call(R_2691, V.Undef)) - 0.5) * Dd_2676) * 0.6))), ((V)((24D + (ToNum(Call(R_2691, V.Undef)) * 30D)))), ((V)(0.15)), ((V)(0.9)), vein_2672, NewObj(3).Put("yaw", ((V)(((ToNum(Call(R_2691, V.Undef)) - 0.5) * 1.6)))).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
if (!(Truthy(round_2670))) {
Invoke(o_2690, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((TH_2674 + 5.2))), ((V)(0D)), ((V)((W_2675 * 0.62))), ((V)(0.6)), ((V)(26D)), ((V)((Truthy(gold_2677) ? "#7f2030" : "#9fb58c"))), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("fab"))).V));
}
Invoke(o_2690, "push", Call(cyl_14, V.Undef, ((V)((-16D))), ((V)((TH_2674 + 5D))), ((V)(0D)), ((V)(2.4)), ((V)(16D)), ((V)("#fff6e2")), NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_14, V.Undef, ((V)(16D)), ((V)((TH_2674 + 5D))), ((V)(0D)), ((V)(2.4)), ((V)(13D)), ((V)("#fff6e2")), NewObj(1).Put("n", ((V)(10D))).V), Call(ball_15, V.Undef, ((V)((-16D))), ((V)((TH_2674 + 21D))), ((V)(0D)), ((V)(1.6)), ((V)("#ffd66b")), Call(em_26, V.Undef, NewObj(1).Put("sy", ((V)(1.5))).V)), Call(ball_15, V.Undef, ((V)(16D)), ((V)((TH_2674 + 18D))), ((V)(0D)), ((V)(1.6)), ((V)("#ffd66b")), Call(em_26, V.Undef, NewObj(1).Put("sy", ((V)(1.5))).V)));
return o_2690;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
PALS_58 = Arr(NewObj(2).Put("n", ((V)("Party"))).Put("c", NE_27).V, NewObj(2).Put("n", ((V)("Ocean"))).Put("c", Arr(((V)("#4fe0d0")), ((V)("#6ac8ff")), ((V)("#3f7fc8")), ((V)("#8f7bff")))).V, NewObj(2).Put("n", ((V)("Sunset"))).Put("c", Arr(((V)("#ffd66b")), ((V)("#ff9d4a")), ((V)("#ff6a4a")), ((V)("#ffb36a")))).V, NewObj(2).Put("n", ((V)("Aurora"))).Put("c", Arr(((V)("#a6f06a")), ((V)("#4fe0d0")), ((V)("#8f7bff")), ((V)("#6ac8ff")))).V, NewObj(2).Put("n", ((V)("Ice"))).Put("c", Arr(((V)("#ffffff")), ((V)("#bfe4ff")), ((V)("#6ac8ff")), ((V)("#d8f0ff")))).V);
MODES_59 = Arr(((V)("Wave")), ((V)("Pulse")), ((V)("Rainbow")), ((V)("Chase")));
Set(N_24, "ledRig", Fn((V _arrowThis2714, int _argc2707, V S_2713, V _a2710, V _a2711, V _a2712, V[] _rest2708) => {
V pal_2715 = default;
V mode_2716 = default;
V lv_2717 = default;
V vals_2718 = default;
V ca_2719 = default;
V sa_2720 = default;
V grid_2721 = default;
V rig_2722 = default;
pal_2715 = (Get(S_2713, "pal") is var _t2723 && Truthy(_t2723) ? _t2723 : NE_27);
mode_2716 = (Truthy(Invoke(MODES_59, "includes", Get(S_2713, "st"))) ? Get(S_2713, "st") : ((V)("Wave")));
lv_2717 = (Get(S_2713, "lv") is var _t2724 && Truthy(_t2724) ? _t2724 : ((V)(3D)));
vals_2718 = Invoke(Invoke(pal_2715, "concat", GetIdx(pal_2715, 0D)), "join", ((V)(";")));
ca_2719 = Fn((V _arrowThis2734, int _argc2725, V i_2731, V j_2732, V n_2733, V _a2730, V[] _rest2726) => {
double b_2735 = 0;
b_2735 = (SEqS(mode_2716, "Wave") ? ((-ToNum(i_2731)) * 0.18) : (SEqS(mode_2716, "Rainbow") ? ((-ToNum(Add(i_2731, j_2732))) * 0.16) : (SEqS(mode_2716, "Chase") ? ((-(ToNum(Add(i_2731, ((V)((ToNum(j_2732) * 7D))))) % ToNum(n_2733))) * 0.09) : 0D)));
return Add(Call(an_37, V.Undef, ((V)("fill")), vals_2718, ((V)(3D)), ((V)(b_2735))), (SEqS(mode_2716, "Pulse") ? Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.1)), ((V)(((-ToNum(j_2732)) * 0.12)))) : (SEqS(mode_2716, "Chase") ? Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.35;1")), ((V)(0.9)), ((V)(b_2735))) : ((V)("")))));
return default;
}, 3, "", true);
sa_2720 = Fn((V _arrowThis2743, int _argc2736, V i_2742, V _a2739, V _a2740, V _a2741, V[] _rest2737) => {
return Add(Call(an_37, V.Undef, ((V)("stroke")), vals_2718, ((V)(3D)), ((V)((SEqS(mode_2716, "Pulse") ? 0D : ((-ToNum(i_2742)) * 0.5))))), (SEqS(mode_2716, "Pulse") ? Call(an_37, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.1))) : ((V)(""))));
}, 1, "", true);
grid_2721 = Fn((V _arrowThis2757, int _argc2744, V c_2750, V z_2751, V y_2752, V cw_2753, V[] _rest2745) => {
JsStrBuf g_2758 = null;
V chh_2754 = default;
V nx_2755 = default;
V ny_2756 = default;
chh_2754 = (_argc2744 > 4 ? _rest2745[0] : V.Undef);
nx_2755 = (_argc2744 > 5 ? _rest2745[1] : V.Undef);
ny_2756 = (_argc2744 > 6 ? _rest2745[2] : V.Undef);
g_2758 = new JsStrBuf("");
{
double j_2759 = 0;
j_2759 = 0D;
while (true) {
if (!(Lt(((V)(j_2759)), ny_2756))) break;
{
double i_2761 = 0;
i_2761 = 0D;
while (true) {
if (!(Lt(((V)(i_2761)), nx_2755))) break;
g_2758.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((((((-ToNum(nx_2755)) * ToNum(cw_2753)) / 2D) + (i_2761 * ToNum(cw_2753))) + 0.6))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((j_2759 * ToNum(chh_2754)) + 0.6))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(cw_2753) - 1.2))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(chh_2754) - 1.2))))).S("\" rx=\"1\" fill=\"").V(GetIdx(pal_2715, ((i_2761 + j_2759) % ToNum(Get(pal_2715, "length"))))).S("\">").V(Call(ca_2719, V.Undef, ((V)(i_2761)), ((V)(j_2759)), ((V)((ToNum(nx_2755) * ToNum(ny_2756)))))).S("</rect>");
i_2761++;
}
}
j_2759++;
}
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, Get(c_2750, "p"), z_2751, y_2752)).S("\" filter=\"url(#gw)\">").S(g_2758.Str).S("</g>").End()));
return default;
}, 7, "", true);
if (LeN(lv_2717, 2D)) {
return NewObj(5).Put("w", ((V)(162D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis2770, int _argc2763, V P_2769, V _a2766, V _a2767, V _a2768, V[] _rest2764) => {
return Arr(Call(slabX_17, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)), ((V)(154D)), ((V)(4D)), ((V)(6D)), ((V)("#2c2d31")), Call(mt_35, V.Undef)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(61D)), ((V)(3.4)), ((V)(152D)), ((V)(2.2)), ((V)(1.2)), ((V)("#f4f8fb")), NewObj(1).Put("noOut", ((V)(1D))).V), Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1.4))), ((V)(160D)), ((V)(0.6)), ((V)(0.4)), ((V)("#000000")), NewObj(2).Put("op", ((V)(0.01))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2778, int _argc2771, V c_2777, V _a2774, V _a2775, V _a2776, V[] _rest2772) => {
JsStrBuf g_2779 = null;
V w_2780 = default;
g_2779 = new JsStrBuf("");
Call(rep_36, V.Undef, ((V)(16D)), Fn((V _arrowThis2788, int _argc2781, V i_2787, V _a2784, V _a2785, V _a2786, V[] _rest2782) => {
V a_2789 = default;
V b_2790 = default;
a_2789 = Invoke(c_2777, "p", ((V)(((-76D) + (ToNum(i_2787) * 9.5)))), ((V)(62.6)), ((V)(4.2)));
b_2790 = Invoke(c_2777, "p", ((V)(((-76D) + (ToNum(Add(i_2787, ((V)(1D)))) * 9.5)))), ((V)(62.6)), ((V)(4.2)));
g_2779.S("<path d=\"M").V(Call(P2_39, V.Undef, a_2789)).S("L").V(Call(P2_39, V.Undef, b_2790)).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(Get(c_2777, "k"))))))).S("\" stroke-linecap=\"round\" stroke=\"").V(GetIdx(pal_2715, (ToNum(i_2787) % ToNum(Get(pal_2715, "length"))))).S("\">").V(Call(sa_2720, V.Undef, i_2787)).S("</path>");
return default;
}, 1, "", true));
w_2780 = Invoke(c_2777, "p", ((V)(0D)), ((V)(82D)), ((V)(0D)));
return NewObj(2).Put("defs", GLOW_48).Put("front", ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(w_2780, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(w_2780, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((84D * ToNum(Get(c_2777, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((20D * ToNum(Get(c_2777, "k"))))))).S("\" fill=\"").V(GetIdx(pal_2715, 0D)).S("\" opacity=\"0.28\">").V(Call(an_37, V.Undef, ((V)("fill")), vals_2718, ((V)(3D)))).S("</ellipse><g filter=\"url(#gw)\">").S(g_2779.Str).S("</g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}
if (SEqN(lv_2717, 3D)) {
return NewObj(5).Put("w", ((V)(154D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis2798, int _argc2791, V P_2797, V _a2794, V _a2795, V _a2796, V[] _rest2792) => {
return Arr(Call(slab_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-2D))), ((V)(150D)), ((V)(100D)), ((V)(4D)), ((V)("#14151c")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0.2)), ((V)(138D)), ((V)(88D)), ((V)(0.6)), ((V)("#0a0b10")), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2806, int _argc2799, V c_2805, V _a2802, V _a2803, V _a2804, V[] _rest2800) => {
return NewObj(2).Put("defs", GLOW_48).Put("front", Call(grid_2721, V.Undef, c_2805, ((V)(0.9)), ((V)(93D)), ((V)(9.8)), ((V)(10.8)), ((V)(14D)), ((V)(8D)))).V;
}, 1, "fx", true)).V;
}
rig_2722 = Fn((V _arrowThis2814, int _argc2807, V P_2813, V _a2810, V _a2811, V _a2812, V[] _rest2808) => {
V o_2815 = default;
o_2815 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2823, int _argc2816, V s_2822, V _a2819, V _a2820, V _a2821, V[] _rest2817) => {
Invoke(o_2815, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2822) * 80D))), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(6D)), ((V)(30D)), ((V)("#2c2d31")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-4D))), ((V)(4D))), "forEach", Fn((V _arrowThis2831, int _argc2824, V dx_2830, V _a2827, V _a2828, V _a2829, V[] _rest2825) => {
return Invoke(Arr(((V)((-4D))), ((V)(4D))), "forEach", Fn((V _arrowThis2839, int _argc2832, V dz_2838, V _a2835, V _a2836, V _a2837, V[] _rest2833) => {
return Invoke(o_2815, "push", Call(cyl_14, V.Undef, Add(((V)((ToNum(s_2822) * 80D))), dx_2830), ((V)(6D)), dz_2838, ((V)(1D)), ((V)(150D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
}, 1, "", true));
Call(rep_36, V.Undef, ((V)(6D)), Fn((V _arrowThis2847, int _argc2840, V i_2846, V _a2843, V _a2844, V _a2845, V[] _rest2841) => {
return Invoke(o_2815, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2822) * 80D))), ((V)((18D + (ToNum(i_2846) * 24D)))), ((V)(0D)), ((V)(10D)), ((V)(1.4)), ((V)(10D)), CH_29, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
InvokeSpread(o_2815, "push", new ArrBuilder().Add(Call(slabX_17, V.Undef, ((V)(0D)), ((V)(154D)), ((V)(0D)), ((V)(172D)), ((V)(7D)), ((V)(8D)), ((V)("#3a3c48")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Spread(Invoke(Arr(((V)((-40D))), ((V)(0D)), ((V)(40D))), "map", Fn((V _arrowThis2855, int _argc2848, V x_2854, V _a2851, V _a2852, V _a2853, V[] _rest2849) => {
return Call(cyl_14, V.Undef, x_2854, ((V)(132D)), ((V)(0D)), ((V)(0.5)), ((V)(22D)), ((V)("#9aa3a8")), NewObj(1).Put("n", ((V)(4D))).V);
}, 1, "", true))).Add(Call(arcW_18, V.Undef, ((V)(0D)), ((V)(128D)), ((V)(0D)), ((V)(62D)), ((V)(50D)), ((V)(3D)), ((V)(3D)), ((V)(0D)), ((V)((2D * PI_32))), ((V)("#23252e")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))).Add(Call(arcW_18, V.Undef, ((V)(0D)), ((V)(110D)), ((V)(0D)), ((V)(46D)), ((V)(37D)), ((V)(3D)), ((V)(3D)), ((V)(0D)), ((V)((2D * PI_32))), ((V)("#23252e")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(24D))).V))).Add(Call(arcW_18, V.Undef, ((V)(0D)), ((V)(94D)), ((V)(0D)), ((V)(30D)), ((V)(24D)), ((V)(3D)), ((V)(3D)), ((V)(0D)), ((V)((2D * PI_32))), ((V)("#23252e")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(146D)), ((V)(0D)), ((V)(6D)), ((V)(8D)), ((V)("#2c2d31")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).V);
if (GeN(lv_2717, 5D)) {
Invoke(o_2815, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(14D)), ((V)((-52D))), ((V)(150D)), ((V)(96D)), ((V)(4D)), ((V)("#14151c")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)));
}
return o_2815;
return default;
}, 1, "", true);
return NewObj(4).Put("w", ((V)(176D))).Put("d", ((V)((GeN(lv_2717, 5D) ? 120D : 60D)))).Put("build", rig_2722).Put("fx", Fn((V _arrowThis2863, int _argc2856, V c_2862, V _a2859, V _a2860, V _a2861, V[] _rest2857) => {
JsStrBuf f_2864 = null;
V rings_2865 = default;
V fl_2866 = default;
f_2864 = new JsStrBuf("");
if (GeN(lv_2717, 5D)) {
f_2864.V(Call(grid_2721, V.Undef, c_2862, ((V)((-49.6))), ((V)(106D)), ((V)(9.8)), ((V)(10.8)), ((V)(14D)), ((V)(8D))));
}
rings_2865 = Arr(Arr(((V)(131D)), ((V)(62D)), ((V)(50D))), Arr(((V)(113D)), ((V)(46D)), ((V)(37D))), Arr(((V)(97D)), ((V)(30D)), ((V)(24D))));
Invoke(rings_2865, "forEach", Fn((V _arrowThis2881, int _argc2867, V _a2869, V i_2873, V _a2871, V _a2872, V[] _rest2868) => {
V y_2876 = default;
V a_2878 = default;
V b_2880 = default;
{ V _t2874 = ListOf(_a2869);
{ V _t2875 = GetIdx(_t2874, 0D);
y_2876 = _t2875; }
{ V _t2877 = GetIdx(_t2874, 1D);
a_2878 = _t2877; }
{ V _t2879 = GetIdx(_t2874, 2D);
b_2880 = _t2879; }
}
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis2889, int _argc2882, V k2_2888, V _a2885, V _a2886, V _a2887, V[] _rest2883) => {
V a0_2890 = default;
V e_2891 = default;
a0_2890 = Invoke(c_2862, "p", ((V)((((-ToNum(a_2878)) * 0.5) + ((ToNum(k2_2888) * ToNum(a_2878)) * 0.5)))), y_2876, ((V)(0D)));
e_2891 = Invoke(c_2862, "p", ((V)(((((-ToNum(a_2878)) * 0.5) + ((ToNum(k2_2888) * ToNum(a_2878)) * 0.5)) * 2.4))), ((V)(0D)), ((V)(30D)));
f_2864.S("<path d=\"M").V(Call(P2_39, V.Undef, a0_2890)).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(e_2891, 0D)) - (14D * ToNum(Get(c_2862, "k")))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(e_2891, 1D))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(e_2891, 0D), ((V)((14D * ToNum(Get(c_2862, "k")))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(e_2891, 1D))).S("Z\" fill=\"").V(GetIdx(pal_2715, (ToNum(Add(i_2873, k2_2888)) % ToNum(Get(pal_2715, "length"))))).S("\" opacity=\"0.12\">").V(Call(an_37, V.Undef, ((V)("fill")), vals_2718, ((V)(3D)), ((V)(((-ToNum(Add(i_2873, k2_2888))) * 0.4))))).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)((SEqS(mode_2716, "Pulse") ? "0.25;0.02;0.25" : "0.05;0.22;0.05"))), ((V)((SEqS(mode_2716, "Pulse") ? 1.1 : 2.4))), ((V)(((-ToNum(Add(((V)((ToNum(i_2873) * 3D))), k2_2888))) * 0.3))))).S("</path>");
return default;
}, 1, "", true));
return default;
}, 2, "", true));
Invoke(rings_2865, "forEach", Fn((V _arrowThis2906, int _argc2892, V _a2894, V i_2898, V _a2896, V _a2897, V[] _rest2893) => {
V y_2901 = default;
V a_2903 = default;
V b_2905 = default;
{ V _t2899 = ListOf(_a2894);
{ V _t2900 = GetIdx(_t2899, 0D);
y_2901 = _t2900; }
{ V _t2902 = GetIdx(_t2899, 1D);
a_2903 = _t2902; }
{ V _t2904 = GetIdx(_t2899, 2D);
b_2905 = _t2904; }
}
f_2864.S("<g transform=\"").V(Call(planeH_45, V.Undef, Get(c_2862, "p"), Add(y_2901, ((V)(3D))))).S("\"><ellipse rx=\"").V(a_2903).S("\" ry=\"").V(b_2905).S("\" fill=\"none\" stroke-width=\"2.2\" stroke=\"").V(GetIdx(pal_2715, (ToNum(i_2898) % ToNum(Get(pal_2715, "length"))))).S("\"").S((SEqS(mode_2716, "Chase") ? " stroke-dasharray=\"10 6\"" : "")).S(" filter=\"url(#gw)\">").V(Call(sa_2720, V.Undef, i_2898)).V((SEqS(mode_2716, "Chase") ? Call(an_37, V.Undef, ((V)("stroke-dashoffset")), ((V)(string.Concat("0;", (NumTruthy((ToNum(i_2898) % 2D)) ? "-" : ""), "64"))), ((V)(2D))) : ((V)("")))).S("</ellipse></g>");
return default;
}, 2, "", true));
if (GeN(lv_2717, 5D)) {
V h_2907 = default;
h_2907 = Invoke(c_2862, "p", ((V)(0D)), ((V)(146D)), ((V)(0D)));
f_2864.V(Invoke(Call(rep_36, V.Undef, ((V)(5D)), Fn((V _arrowThis2915, int _argc2908, V i_2914, V _a2911, V _a2912, V _a2913, V[] _rest2909) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_39, V.Undef, h_2907)).S(")\"><g>").V(Call(at_38, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().N(((-30D) + (ToNum(i_2914) * 6D))).S(";").N((30D - (ToNum(i_2914) * 6D))).S(";").N(((-30D) + (ToNum(i_2914) * 6D))).End())), ((V)((3D + (ToNum(i_2914) * 0.4)))))).S("<path d=\"M0 0L").V(Call(f1_23, V.Undef, ((V)((((ToNum(i_2914) - 2D) * 20D) * ToNum(Get(c_2862, "k"))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((150D * ToNum(Get(c_2862, "k"))))))).S("\" stroke=\"").V(GetIdx(pal_2715, (ToNum(i_2914) % ToNum(Get(pal_2715, "length"))))).S("\" stroke-width=\"0.9\" opacity=\"0.85\" filter=\"url(#gw)\">").V(Call(sa_2720, V.Undef, i_2914)).S("</path></g></g>").End()));
}, 1, "", true)), "join", ((V)(""))));
}
fl_2866 = Invoke(c_2862, "p", ((V)(0D)), ((V)(0D)), ((V)(30D)));
f_2864.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2866, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2866, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((70D * ToNum(Get(c_2862, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((70D * ToNum(Get(c_2862, "k"))) * ToNum(Get(X_9, "SA"))) * 0.6))))).S("\" fill=\"").V(GetIdx(pal_2715, 0D)).S("\" opacity=\"0.18\">").V(Call(an_37, V.Undef, ((V)("fill")), vals_2718, ((V)(3D)))).S("</ellipse>");
return NewObj(2).Put("defs", GLOW_48).Put("front", ((V)(f_2864.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
LUXC_60 = Arr(NewObj(2).Put("n", ((V)("Emerald Velvet"))).Put("c", ((V)("#1f6a4c"))).V, NewObj(2).Put("n", ((V)("Sapphire Velvet"))).Put("c", ((V)("#2b3f7a"))).V, NewObj(2).Put("n", ((V)("Burgundy Velvet"))).Put("c", ((V)("#7f2030"))).V, NewObj(2).Put("n", ((V)("Plum Velvet"))).Put("c", ((V)("#5a2a5e"))).V, NewObj(2).Put("n", ((V)("Mustard Velvet"))).Put("c", ((V)("#c99a2e"))).V, NewObj(2).Put("n", ((V)("Ivory Boucl\u00e9"))).Put("c", ((V)("#ece5d6"))).V, NewObj(2).Put("n", ((V)("Charcoal Linen"))).Put("c", ((V)("#4a4a4f"))).V);
LROT_61 = Fn((V _arrowThis2923, int _argc2916, V i_2922, V _a2919, V _a2920, V _a2921, V[] _rest2917) => {
return Invoke(Invoke(LUXC_60, "slice", i_2922), "concat", Invoke(LUXC_60, "slice", ((V)(0D)), i_2922));
}, 1, "", true);
POUF_62 = Arr(NewObj(2).Put("n", ((V)("Macram\u00e9 Cream"))).Put("c", ((V)("#efe6d4"))).V, NewObj(2).Put("n", ((V)("Emerald Velvet"))).Put("c", ((V)("#1f6a4c"))).V, NewObj(2).Put("n", ((V)("Cognac Leather"))).Put("c", ((V)("#a8592b"))).V, NewObj(2).Put("n", ((V)("Cloud Lavender"))).Put("c", ((V)("#b9a6e0"))).V, NewObj(2).Put("n", ((V)("Mustard Knit"))).Put("c", ((V)("#d8a531"))).V, NewObj(2).Put("n", ((V)("Navy Velvet"))).Put("c", ((V)("#2f4870"))).V);
QUOTES_63 = Arr(((V)("Home Sweet Home")), ((V)("Living Room")), ((V)("Kitchen")), ((V)("Bedroom")), ((V)("Bath Time")), ((V)("Welcome Home")), ((V)("Squish Squad")), ((V)("Family")), ((V)("Good Vibes")));
SIGNTX_64 = Arr(((V)("DANCE!")), ((V)("Party Time")), ((V)("Good Vibes")), ((V)("Squish Squad")), ((V)("VIP")), ((V)("Disco Night")), ((V)("Turn It Up")));
DEL_65 = New(G("Set"), Arr(((V)("LIV-014")), ((V)("LIV-017")), ((V)("LIV-053")), ((V)("LIV-073")), ((V)("LIV-093")), ((V)("KIT-020")), ((V)("KIT-040")), ((V)("KIT-060")), ((V)("KIT-080")), ((V)("KIT-100")), ((V)("KIT-088")), ((V)("MOV-012")), ((V)("MOV-032")), ((V)("MOV-052")), ((V)("MOV-072")), ((V)("MOV-092")), ((V)("CLB-012")), ((V)("CLB-032")), ((V)("CLB-052")), ((V)("CLB-072")), ((V)("CLB-092")), ((V)("BTH-012")), ((V)("BTH-032")), ((V)("BTH-052")), ((V)("BTH-072")), ((V)("BTH-092"))));
SET_66 = NewObj(65).Put("LIV-004", NewObj(4).Put("name", ((V)("Tacked-Up Wall Calendar (Live Date Tracker)"))).Put("spec", ((V)("calendar"))).Put("kind", ((V)("cal"))).Put("note", ((V)("Always shows today. Tap days to mark them; past days get crossed off."))).V).Put("LIV-084", NewObj(4).Put("spec", ((V)("masterpiece"))).Put("kind", ((V)("paint"))).Put("modes", PAINT_56).Put("note", ((V)("A living painting: it moves on its own. Tap it to repaint."))).V).Put("LIV-033", NewObj(5).Put("name", ((V)("Cloud Puff Pouf"))).Put("spec", ((V)("puffPouf"))).Put("kind", ((V)("squish"))).Put("colors", POUF_62).Put("note", ((V)("One pouf in any colour (replaces the Macram\u00e9 Pouf, Velvet Ottoman, Moroccan Footstool and Levitating Foot Cloud). Squishes when a creature sits or when poked."))).V).Put("MOV-013", NewObj(1).Put("spec", ((V)("futon"))).V).Put("LIV-055", NewObj(1).Put("spec", ((V)("hearth@cot"))).V).Put("LIV-075", NewObj(1).Put("spec", ((V)("hearth@mod"))).V).Put("LIV-006", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(1).Put("n", ((V)(2D))).V).V).Put("LIV-026", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(1).Put("n", ((V)(3D))).V).V).Put("LIV-046", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(2).Put("n", ((V)(4D))).Put("shape", ((V)("L"))).V).V).Put("LIV-066", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(2).Put("n", ((V)(5D))).Put("shape", ((V)("pit"))).V).V).Put("LIV-086", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(2).Put("n", ((V)(3D))).Put("float", ((V)(1D))).V).V).Put("LIV-010", NewObj(1).Put("spec", ((V)("rchair"))).V).Put("LIV-030", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(1).Put("n", ((V)(1D))).V).V).Put("LIV-050", NewObj(2).Put("spec", ((V)("rchair"))).Put("sx", NewObj(1).Put("st2", ((V)("papasan"))).V).V).Put("LIV-070", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(1).Put("n", ((V)(1D))).V).V).Put("LIV-090", NewObj(2).Put("spec", ((V)("rsofa"))).Put("sx", NewObj(2).Put("n", ((V)(1D))).Put("float", ((V)(1D))).V).V).Put("KIT-007", NewObj(1).Put("spec", ((V)("dripCoffee"))).V).Put("KIT-027", NewObj(1).Put("spec", ((V)("podBrewer"))).V).Put("KIT-011", NewObj(3).Put("spec", ((V)("toaster"))).Put("kind", ((V)("toast"))).Put("note", ((V)("Tap to pop bread in; it pops up toasted after 5 seconds."))).V).Put("KIT-006", NewObj(2).Put("spec", ((V)("dish2"))).Put("kind", ((V)("dish"))).V).Put("KIT-026", NewObj(2).Put("spec", ((V)("dish2"))).Put("kind", ((V)("dish"))).V).Put("KIT-046", NewObj(2).Put("spec", ((V)("dish2"))).Put("kind", ((V)("dish"))).V).Put("KIT-066", NewObj(2).Put("spec", ((V)("dish2"))).Put("kind", ((V)("dish"))).V).Put("KIT-086", NewObj(2).Put("spec", ((V)("dish2"))).Put("kind", ((V)("dish"))).V).Put("KIT-031", NewObj(2).Put("spec", ((V)("standMixer"))).Put("colors", PASTEL_57).V).Put("KIT-047", NewObj(1).Put("spec", ((V)("espresso"))).V).Put("KIT-087", NewObj(1).Put("spec", ((V)("sommelier"))).V).Put("KIT-091", NewObj(1).Put("spec", ((V)("synth"))).V).Put("KIT-015", NewObj(1).Put("food", ((V)(1D))).V).Put("KIT-035", NewObj(1).Put("food", ((V)(2D))).V).Put("KIT-055", NewObj(1).Put("food", ((V)(3D))).V).Put("KIT-075", NewObj(1).Put("food", ((V)(4D))).V).Put("KIT-095", NewObj(1).Put("food", ((V)(5D))).V).Put("KIT-028", NewObj(2).Put("name", ((V)("Wire Fruit Basket & Glass Cookie Jar"))).Put("spec", ((V)("fruitJar"))).V).Put("KIT-068", NewObj(2).Put("name", ((V)("Glass Cloche Cookie Jar with Choc-Chip Cookies"))).Put("spec", ((V)("cookieJar"))).V).Put("KIT-019", NewObj(1).Put("spec", ((V)("barstool"))).V).Put("KIT-039", NewObj(1).Put("spec", ((V)("barstool"))).V).Put("KIT-059", NewObj(1).Put("spec", ((V)("barstool"))).V).Put("KIT-079", NewObj(1).Put("spec", ((V)("barstool"))).V).Put("KIT-099", NewObj(1).Put("spec", ((V)("barstool"))).V).Put("KIT-036", NewObj(1).Put("spec", ((V)("rchair"))).V).Put("KIT-056", NewObj(1).Put("spec", ((V)("rchair"))).V).Put("KIT-076", NewObj(1).Put("spec", ((V)("rchair"))).V).Put("KIT-096", NewObj(1).Put("spec", ((V)("podSeat"))).V).Put("KIT-082", NewObj(3).Put("name", ((V)("Ultrasonic Wave-Clean Basin in a Royal Calacatta L-Kitchen"))).Put("spec", ((V)("luxCounter"))).Put("sx", NewObj(2).Put("shape", ((V)("L"))).Put("sink", ((V)(1D))).V).V).Put("KIT-090", NewObj(3).Put("name", ((V)("Self-Healing Obsidian U-Kitchen with Motorized Lift Cabinets"))).Put("spec", ((V)("luxCounter"))).Put("sx", NewObj(2).Put("shape", ((V)("U"))).Put("lift", ((V)(1D))).V).V).Put("KIT-093", NewObj(3).Put("name", ((V)("Gilded Teppanyaki & Smart-Scale Chef's Island"))).Put("spec", ((V)("luxCounter"))).Put("sx", NewObj(2).Put("shape", ((V)("I"))).Put("tep", ((V)(1D))).V).V).Put("KIT-073", NewObj(2).Put("spec", ((V)("luxCounter"))).Put("sx", NewObj(2).Put("shape", ((V)("I"))).Put("prep", ((V)(1D))).V).V).Put("KIT-083", NewObj(2).Put("spec", ((V)("robotCart"))).Put("note", ((V)("Rolls back and forth delivering plates."))).V).Put("YRD-004", NewObj(1).Put("name", ((V)("Junkyard Charm: Flamingo & Garden Gnome"))).V).Put("YRD-024", NewObj(1).Put("name", ((V)("Cottage Garden: Copper Wind Chime & Birdhouse"))).V).Put("YRD-044", NewObj(1).Put("name", ((V)("Tuscan Terrace: Stone Sundial & Tiered Birdbath"))).V).Put("YRD-064", NewObj(1).Put("name", ((V)("Zen Temple Garden: Limestone Buddha & Pagoda Lanterns"))).V).Put("YRD-084", NewObj(1).Put("name", ((V)("Sky Garden: Levitating Mirror-Chrome Wind Sculpture"))).V).Put("YRD-008", NewObj(1).Put("name", ((V)("Junkyard Charm: Rusty Watering Can & Tin Candle"))).V).Put("YRD-028", NewObj(1).Put("name", ((V)("Cottage Garden: Galvanized Drinks Tub & Gingham Napkins"))).V).Put("YRD-048", NewObj(1).Put("name", ((V)("Tuscan Terrace: Terracotta Torch & Hurricane Lantern"))).V).Put("YRD-068", NewObj(1).Put("name", ((V)("Zen Temple Garden: Brass Ice Bucket & Bonsai Shears"))).V).Put("YRD-088", NewObj(1).Put("name", ((V)("Sky Garden: Holo Star-Map Globe & Floating Carafe"))).V).Put("YRD-061", NewObj(1).Put("name", ((V)("Ivy-Covered Limestone Garden Wall with Wrought-Iron Railing"))).V).Put("YRD-003", NewObj(1).Put("name", ((V)("Single Bug-Zapper Bulb on a Post"))).V).Put("YRD-020", NewObj(1).Put("name", ((V)("Muddy Coir Bristle Patio Mat"))).V).Put("BED-072", NewObj(1).Put("name", ((V)("Floor-to-Ceiling French Windows with Juliet Balcony"))).V).Put("BED-011", NewObj(1).Put("name", ((V)("Narrow Plastic-Frame Wall Mirror"))).V).Put("BTH-003", NewObj(1).Put("name", ((V)("Loose Metal Wall Hook"))).V).V;
Q_67 = NewObj(2).Put("texts", QUOTES_63).Put("kind", ((V)("text"))).V;
SG_68 = Fn((V _arrowThis2931, int _argc2924, V st_2930, V _a2927, V _a2928, V _a2929, V[] _rest2925) => {
return NewObj(3).Put("sx", NewObj(1).Put("st", st_2930).V).Put("texts", SIGNTX_64).Put("kind", ((V)("text"))).V;
}, 1, "", true);
LED_69 = Fn((V _arrowThis2939, int _argc2932, V lv_2938, V _a2935, V _a2936, V _a2937, V[] _rest2933) => {
return NewObj(3).Put("sx", NewObj(1).Put("lv", lv_2938).V).Put("colors", PALS_58).Put("modes", MODES_59).V;
}, 1, "", true);
Set(N_24, "abcBlocks", Fn((V _arrowThis2947, int _argc2940, V S_2946, V _a2943, V _a2944, V _a2945, V[] _rest2941) => {
V k_2948 = default;
V cs_2949 = default;
V o_2950 = default;
k_2948 = Get(S_2946, "k");
cs_2949 = (SEqS(k_2948, "candy") ? Arr(GetIdx(NE_27, 0D), GetIdx(NE_27, 2D), GetIdx(NE_27, 4D), GetIdx(NE_27, 1D)) : (SEqS(k_2948, "royal") ? Arr(((V)("#f4f1ea")), GOLD_28, ((V)("#7a1e2c")), ((V)("#f4f1ea"))) : (SEqS(k_2948, "junk") ? Arr(((V)("#c9a36a")), ((V)("#9fb7a0")), ((V)("#d6b65a")), ((V)("#b88a5a"))) : Arr(((V)("#7cc4e8")), ((V)("#8fd3a8")), ((V)("#f6d466")), ((V)("#f29a8a"))))));
o_2950 = NewObj(3).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).Put("mat", ((V)("paint"))).V;
return NewObj(5).Put("w", ((V)(80D))).Put("d", ((V)(54D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(56D))).Put("z", ((V)(14D))).V).Put("build", Fn((V _arrowThis2957, int _argc2951, V _a2953, V _a2954, V _a2955, V _a2956, V[] _rest2952) => {
return Arr(Call(box_12, V.Undef, ((V)((-18D))), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(30D)), ((V)(30D)), GetIdx(cs_2949, 0D), o_2950), Call(box_12, V.Undef, ((V)(16D)), ((V)(0D)), ((V)(6D)), ((V)(30D)), ((V)(30D)), ((V)(30D)), GetIdx(cs_2949, 1D), Object_assign(NewObj(1).Put("yaw", ((V)(0.3))).V, o_2950)), Call(box_12, V.Undef, ((V)((-2D))), ((V)(30D)), ((V)(2D)), ((V)(30D)), ((V)(30D)), ((V)(30D)), GetIdx(cs_2949, 2D), Object_assign(NewObj(1).Put("yaw", ((V)((-0.25)))).V, o_2950)), Call(box_12, V.Undef, ((V)(30D)), ((V)(0D)), ((V)((-16D))), ((V)(16D)), ((V)(16D)), ((V)(16D)), GetIdx(cs_2949, 3D), NewObj(4).Put("r", ((V)(3D))).Put("bev", ((V)(1.5))).Put("yaw", ((V)(0.6))).Put("mat", ((V)("paint"))).V));
}, 0, "build", true)).V;
return default;
}, 1, "", true));
ADD_70 = Arr(Arr(((V)("LIV")), ((V)(101D)), ((V)(1D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Hand-Lettered Paper Banner Quote")), ((V)("quote")), Q_67), Arr(((V)("LIV")), ((V)(102D)), ((V)(2D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Painted Driftwood Plank Quote Sign")), ((V)("quote")), Q_67), Arr(((V)("LIV")), ((V)(103D)), ((V)(3D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Script Vinyl Wall Quote Decal")), ((V)("quote")), Q_67), Arr(((V)("LIV")), ((V)(104D)), ((V)(4D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Brass Wire Script Wall Quote")), ((V)("quote")), Q_67), Arr(((V)("LIV")), ((V)(105D)), ((V)(5D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Glowing Neon Script Wall Quote")), ((V)("quote")), Q_67), Arr(((V)("LIV")), ((V)(106D)), ((V)(5D)), ((V)(2D)), ((V)(2D)), ((V)("Floor Surface")), ((V)("Mirror-Polished Calacatta Gold Marble Floor")), ((V)("s:floor")), NewObj(1).Put("note", ((V)("Pristine showroom marble with gold inlay and a moving shine."))).V), Arr(((V)("KIT")), ((V)(101D)), ((V)(2D)), ((V)(19D)), ((V)(21D)), ((V)("Wall Quote")), ((V)("Painted Wooden 'Kitchen' Sign")), ((V)("quote")), Object_assign(NewObj(1).Put("txt0", ((V)("Kitchen"))).V, Q_67)), Arr(((V)("KIT")), ((V)(102D)), ((V)(3D)), ((V)(10D)), ((V)(22D)), ((V)("Dining Table")), ((V)("Solid Oak & Carrara Marble 4-Seat Round Dining Table")), ((V)("diningTable")), NewObj(2).Put("note", ((V)("Table only - fits 4 dining chairs (sold separately)."))).Put("sx", NewObj(5).Put("n", ((V)(4D))).Put("round", ((V)(1D))).Put("wood", ((V)("#c8925a"))).Put("top", ((V)("#f4f1ec"))).Put("vein", ((V)("#c9c1b5"))).V).V), Arr(((V)("KIT")), ((V)(103D)), ((V)(4D)), ((V)(10D)), ((V)(22D)), ((V)("Dining Table")), ((V)("Walnut Trestle & Calacatta Marble 6-Seat Dining Table")), ((V)("diningTable")), NewObj(2).Put("note", ((V)("Table only - fits 6 dining chairs (sold separately)."))).Put("sx", NewObj(4).Put("n", ((V)(6D))).Put("wood", ((V)("#6b4226"))).Put("top", ((V)("#f2efea"))).Put("vein", ((V)("#c9b98a"))).V).V), Arr(((V)("KIT")), ((V)(104D)), ((V)(5D)), ((V)(10D)), ((V)(22D)), ((V)("Dining Table")), ((V)("Royal Ebony & Gold-Veined Nero Marble 8-Seat Banquet Table")), ((V)("diningTable")), NewObj(2).Put("note", ((V)("Table only - fits 8 dining chairs (sold separately)."))).Put("sx", NewObj(5).Put("n", ((V)(8D))).Put("wood", ((V)("#2c2420"))).Put("top", ((V)("#26232b"))).Put("vein", GOLD_28).Put("gold", ((V)(1D))).V).V), Arr(((V)("KIT")), ((V)(105D)), ((V)(3D)), ((V)(11D)), ((V)(11D)), ((V)("Dining Chair")), ((V)("Walnut & Linen Button-Tufted Dining Chair")), ((V)("luxDChair")), NewObj(2).Put("colors", LUXC_60).Put("sx", NewObj(1).Put("wood", ((V)("#6b4226"))).V).V), Arr(((V)("KIT")), ((V)(106D)), ((V)(4D)), ((V)(11D)), ((V)(11D)), ((V)("Dining Chair")), ((V)("Brushed Brass & Velvet Channel-Back Dining Chair")), ((V)("luxDChair")), NewObj(2).Put("colors", LUXC_60).Put("sx", NewObj(2).Put("gold", ((V)(1D))).Put("st", ((V)("chan"))).V).V), Arr(((V)("KIT")), ((V)(107D)), ((V)(5D)), ((V)(11D)), ((V)(11D)), ((V)("Dining Chair")), ((V)("Royal Ebony & Gold-Leaf Tufted Velvet Dining Chair")), ((V)("luxDChair")), NewObj(2).Put("colors", Call(LROT_61, V.Undef, ((V)(2D)))).Put("sx", NewObj(2).Put("gold", ((V)(1D))).Put("wood", ((V)("#2c2420"))).V).V), Arr(((V)("LIV")), ((V)(107D)), ((V)(3D)), ((V)(8D)), ((V)(8D)), ((V)("Primary Couch")), ((V)("Tufted Velvet Chesterfield Sofa on Walnut Feet")), ((V)("luxSofa")), NewObj(2).Put("colors", LUXC_60).Put("sx", NewObj(2).Put("n", ((V)(3D))).Put("wood", ((V)("#4a2c1a"))).V).V), Arr(((V)("LIV")), ((V)(108D)), ((V)(4D)), ((V)(8D)), ((V)(8D)), ((V)("Primary Couch")), ((V)("Cognac Leather Chesterfield with Brass Nailheads")), ((V)("luxSofa")), NewObj(2).Put("colors", Arr(NewObj(2).Put("n", ((V)("Cognac"))).Put("c", ((V)("#a8592b"))).V, NewObj(2).Put("n", ((V)("Oxblood"))).Put("c", ((V)("#6e2a24"))).V, NewObj(2).Put("n", ((V)("Espresso"))).Put("c", ((V)("#4a3226"))).V, NewObj(2).Put("n", ((V)("Forest"))).Put("c", ((V)("#2f4a36"))).V)).Put("sx", NewObj(3).Put("n", ((V)(3D))).Put("brass", ((V)(1D))).Put("wood", ((V)("#3a2416"))).V).V), Arr(((V)("LIV")), ((V)(109D)), ((V)(4D)), ((V)(8D)), ((V)(8D)), ((V)("Primary Couch")), ((V)("Ivory Boucl\u00e9 Channel-Tufted Sofa on a Calacatta Marble Plinth")), ((V)("luxSofa")), NewObj(2).Put("colors", Call(LROT_61, V.Undef, ((V)(5D)))).Put("sx", NewObj(4).Put("n", ((V)(3D))).Put("st", ((V)("chan"))).Put("plinth", ((V)("#f2efea"))).Put("pil", ((V)("#c9a35a"))).V).V), Arr(((V)("LIV")), ((V)(110D)), ((V)(5D)), ((V)(8D)), ((V)(8D)), ((V)("Primary Couch")), ((V)("Royal Velvet & Gold-Leaf Grand Chesterfield")), ((V)("luxSofa")), NewObj(2).Put("colors", Call(LROT_61, V.Undef, ((V)(2D)))).Put("sx", NewObj(2).Put("n", ((V)(4D))).Put("gold", ((V)(1D))).V).V), Arr(((V)("YRD")), ((V)(101D)), ((V)(1D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Chalk Hopscotch Court")), ((V)("hopscotch")), NewObj(0).V), Arr(((V)("YRD")), ((V)(102D)), ((V)(2D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Driveway Basketball Hoop")), ((V)("hoop")), NewObj(0).V), Arr(((V)("YRD")), ((V)(103D)), ((V)(3D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Tetherball Pole")), ((V)("tether")), NewObj(0).V), Arr(((V)("YRD")), ((V)(104D)), ((V)(4D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Backyard Soccer Goal")), ((V)("goal")), NewObj(0).V), Arr(((V)("YRD")), ((V)(105D)), ((V)(5D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Climbing Dome Jungle Gym")), ((V)("dome")), NewObj(0).V), Arr(((V)("YRD")), ((V)(120D)), ((V)(1D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Patched Hand-Me-Down Trampoline")), ((V)("tramp")), NewObj(0).V), Arr(((V)("YRD")), ((V)(121D)), ((V)(3D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Round Sport Trampoline with Safety Pad")), ((V)("tramp")), NewObj(0).V), Arr(((V)("YRD")), ((V)(122D)), ((V)(5D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Jelly Bounce Trampoline")), ((V)("tramp")), NewObj(0).V), Arr(((V)("YRD")), ((V)(123D)), ((V)(2D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Wooden Playground Slide")), ((V)("slide")), NewObj(0).V), Arr(((V)("YRD")), ((V)(124D)), ((V)(4D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Gilded Garden Slide")), ((V)("slide")), NewObj(0).V), Arr(((V)("YRD")), ((V)(125D)), ((V)(5D)), ((V)(17D)), ((V)(21D)), ((V)("Backyard Games")), ((V)("Rainbow Wave Slide")), ((V)("slide")), NewObj(0).V), Arr(((V)("BED")), ((V)(120D)), ((V)(1D)), ((V)(16D)), ((V)(22D)), ((V)("Toys & Play")), ((V)("Wooden ABC Block Set")), ((V)("abcBlocks")), NewObj(0).V), Arr(((V)("LIV")), ((V)(120D)), ((V)(2D)), ((V)(16D)), ((V)(22D)), ((V)("Toys & Play")), ((V)("Chunky ABC Building Blocks")), ((V)("abcBlocks")), NewObj(0).V), Arr(((V)("CLB")), ((V)(101D)), ((V)(2D)), ((V)(8D)), ((V)(21D)), ((V)("LED Light Design")), ((V)("Colour-Picker LED Strip Cove Kit")), ((V)("ledRig")), Call(LED_69, V.Undef, ((V)(2D)))), Arr(((V)("CLB")), ((V)(102D)), ((V)(3D)), ((V)(8D)), ((V)(21D)), ((V)("LED Light Design")), ((V)("Layered LED Pixel Wall with Custom Patterns")), ((V)("ledRig")), Call(LED_69, V.Undef, ((V)(3D)))), Arr(((V)("CLB")), ((V)(103D)), ((V)(4D)), ((V)(8D)), ((V)(21D)), ((V)("LED Light Design")), ((V)("Tri-Layer Halo Ring & Beam Light Rig")), ((V)("ledRig")), Call(LED_69, V.Undef, ((V)(4D)))), Arr(((V)("CLB")), ((V)(104D)), ((V)(5D)), ((V)(8D)), ((V)(21D)), ((V)("LED Light Design")), ((V)("Multi-Layer Laser, Halo & Pixel Light Show")), ((V)("ledRig")), Call(LED_69, V.Undef, ((V)(5D)))), Arr(((V)("CLB")), ((V)(105D)), ((V)(1D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Handwritten Cardboard Sign Taped to the Wall")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("card")))), Arr(((V)("CLB")), ((V)(106D)), ((V)(2D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Chalkboard Party Sign")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("chalk")))), Arr(((V)("CLB")), ((V)(107D)), ((V)(3D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Marquee Bulb Letter Sign")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("marq")))), Arr(((V)("CLB")), ((V)(108D)), ((V)(4D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Custom Neon Script Sign")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("neon")))), Arr(((V)("CLB")), ((V)(109D)), ((V)(4D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Scrolling LED Ticker Sign")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("led")))), Arr(((V)("CLB")), ((V)(110D)), ((V)(5D)), ((V)(19D)), ((V)(22D)), ((V)("Wall Sign")), ((V)("Royal Gold Marquee Crest Sign")), ((V)("rsign")), Call(SG_68, V.Undef, ((V)("royal")))));
Invoke(Object_values(M_25), "forEach", Fn((V _arrowThis2965, int _argc2958, V arr_2964, V _a2961, V _a2962, V _a2963, V[] _rest2959) => {
return Invoke(arr_2964, "forEach", Fn((V _arrowThis2974, int _argc2966, V e_2972, V i_2973, V _a2970, V _a2971, V[] _rest2967) => {
V fix_2975 = default;
fix_2975 = Fn((V _arrowThis2983, int _argc2976, V s_2982, V _a2979, V _a2980, V _a2981, V[] _rest2977) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(s_2982, "replace", NewRegExp(RX35, "^(sofa|longSofa)(?=$|[.@*+])", ""), ((V)("rsofa"))), "replace", NewRegExp(RX34, "^armchair(?=$|[.@*+])", ""), ((V)("rsofa.1"))), "replace", NewRegExp(RX33, "^lsofa(?=$|[.@*+])", ""), ((V)("rsofa.L"))), "replace", NewRegExp(RX32, "^usofa(?=$|[.@*+])", ""), ((V)("rsofa.U"))), "replace", NewRegExp(RX31, "^pit(?=$|[.@*+])", ""), ((V)("rsofa.pit"))), "replace", NewRegExp(RX30, "^chair(?=$|[.@*+])", ""), ((V)("rchair")));
}, 1, "", true);
if ((e_2972.O is JsArray)) {
SetK(arr_2964, i_2973, Invoke(e_2972, "map", fix_2975));
} else {
SetK(arr_2964, i_2973, Call(fix_2975, V.Undef, e_2972));
}
return default;
}, 2, "", true));
}, 1, "", true));
COLW_71 = NewRegExp(RX36, "\\b(burgundy|crimson|red|cherry|mustard|yellow|orange|lavender|purple|plum|navy|blue|teal|mint|sage|green|emerald|olive|charcoal|black|white|cream|ivory|gray|grey|silver|gold|golden|pastel|cobalt|beige)\\b", "gi");
FOOD_74 = Arr(((V)("tbFruit")), ((V)("tbCake")), ((V)("tbTeapot")), ((V)("tbJar")), ((V)("tbCup")));
Set(RD_8, "food", Fn((V _arrowThis2991, int _argc2984, V i_2990, V _a2987, V _a2988, V _a2989, V[] _rest2985) => {
return Invoke(RD_8, "draw", NewObj(6).Put("id", ((V)(JsStrBuf.Begin().S("FOOD-").V(i_2990).End()))).Put("name", ((V)("snack"))).Put("tier", ((V)(2D))).Put("room", ((V)("KIT"))).Put("slot", ((V)(0D))).Put("spec", GetIdx(FOOD_74, (ToNum(i_2990) % ToNum(Get(FOOD_74, "length"))))).V);
}, 1, "", true));
Object_assign(RD_8, NewObj(7).Put("edit", edit_73).Put("PLUS", ((V)(1D))).Put("PALS", PALS_58).Put("MODES", MODES_59).Put("PAINT", PAINT_56).Put("QUOTES", QUOTES_63).Put("SIGNTX", SIGNTX_64).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
